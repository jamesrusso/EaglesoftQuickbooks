/*
 * Copyright 2007-2012 Halo3 Consulting, LLC
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *     
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System.Text.RegularExpressions;

using System.IO;
using System.Reflection;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Data.Sql;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Deployment.Application;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Eaglesoft_Deposit.Model;
using Eaglesoft_Deposit.Workers;

namespace Eaglesoft_Deposit.Forms
{
    public delegate void UpdateStatus(String s);

    public partial class frmMain : Form
    {
        private List<EaglesoftPayment> payments = new List<EaglesoftPayment>();
        private List<EaglesoftRefund> refunds = new List<EaglesoftRefund>();
        private Configuration configuration;
        private LoadEaglesoftDataWorker eaglesoftLoadDataWorker;
        private Queue<DateTime> datesToRun = new Queue<DateTime>();

        public frmMain()
        {
            InitializeComponent();
            configuration = UserSettings.getInstance().Configuration;
            eaglesoftLoadDataWorker = new LoadEaglesoftDataWorker();
            eaglesoftLoadDataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(eaglesoftLoadDataWorker_Completed);
            eaglesoftLoadDataWorker.ProgressChanged += new ProgressChangedEventHandler(workerProgressUpdate);
            try
            {
                this.Text += String.Format(" (v{0})", ApplicationDeployment.CurrentDeployment.CurrentVersion);
            }
            catch (InvalidDeploymentException e)
            {
                // Ignore.

            }
            
        }

        public void setStatus(String s)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate() { setStatus(s); }));
            else
            {
                textBox1.AppendText(s + "\r\n");
            }
        }

        private void validateConfiguration()
        {

            if (configuration.Deposits.Count == 0)
            {
                MessageBox.Show("No deposits have been configured, you must configure deposits before you can load data into Quickbooks", "No deposits configured");
                setupDepositsToolStripMenuItem.PerformClick();
                return;
            }

            IList<QuickbooksPaytype> availablePayTypes = configuration.getUnconfiguredQuickbookPayTypes();
            if (availablePayTypes.Count > 0)
            {
                String s = "The below paytypes have are not\n" +
                    "associated with a deposit. All paytypes\n" +
                    "must be assocated with a deposit before\n" +
                    "you can import the data into quickbooks.\n\n";

                foreach (QuickbooksPaytype qbPayType in availablePayTypes)
                {
                    s = s + qbPayType.Name + "\n";
                }

                MessageBox.Show(s, "Paytype assignment error");
                return;
            }
        }
        
        private void runDepositFor(DateTime dateTime)
        {
            if (UserSettings.getInstance().Configuration.DatesRun.Contains(dateTime))
            {
                setStatus(String.Format("skipping already run date {0}.", dateTime));
                processDepositQueue();
            }
            else
            {
                eaglesoftLoadDataWorker.Date = dateTime;
                toolStripProgressBar1.Visible = true;
                setStatus(String.Format("loading data for {0:MM/dd/yy}", dateTime));
                eaglesoftLoadDataWorker.RunWorkerAsync();
            }
        }

        private void RefreshData()
        {
             new frmRefreshExternalData().ShowDialog(this);
        }
        
        private void setupPaymentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
            Configuration config = UserSettings.getInstance().Configuration;
            List<PaytypeMappingDTO> paytypeMappingDTOs = config.ToPaytypeMappingDTOs();

            frmPayTypeMappings f = new frmPayTypeMappings(paytypeMappingDTOs);
            if (f.ShowDialog() == DialogResult.OK)
            {
                config.FromPaytypeMappingDTOs(paytypeMappingDTOs);
                UserSettings.getInstance().Save();

                if (UserSettings.getInstance().Configuration.Deposits.Count == 0)
                {
                    if (MessageBox.Show(
                        "No deposits, are currently configured. Would you like to configure these now?", "No deposits configured",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        setupDepositsToolStripMenuItem.PerformClick();
                    }
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainFormState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainFormSize = this.Size;
                Properties.Settings.Default.MainFormLocation = this.Location;
            }
            else
            {
                Properties.Settings.Default.MainFormSize = this.RestoreBounds.Size;
                Properties.Settings.Default.MainFormLocation = this.RestoreBounds.Location;
            }
            Properties.Settings.Default.Save();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          
  }
        
        private void todayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runDepositFor(DateTime.Now.Date);
        }

        private void specificDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDateSelect dialog = new frmDateSelect();
            dialog.Parent = this.Parent;
            dialog.StartPosition = FormStartPosition.CenterParent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DateTime dateToRun = dialog.SelectionDate.Date;
                UserSettings.getInstance().Configuration.DatesRun.Remove(dateToRun);
                datesToRun.Enqueue(dialog.SelectionDate.Date);
                processDepositQueue();
            }
        }
    
        private void eaglesoftLoadDataWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadEaglesoftDataWorker worker = (LoadEaglesoftDataWorker)sender;

            if (e.Cancelled)
            {
                setStatus("Operation canceled...");
                toolStripProgressBar1.Visible = false;
                setupDepositsToolStripMenuItem.Enabled = true;
                importDataToolStripMenuItem.Enabled = true;
                cancelImportToolStripMenuItem.Visible = false;
                return;
            }

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message+"\n\n"+e.Error.StackTrace);
                toolStripProgressBar1.Visible = false;
                setupDepositsToolStripMenuItem.Enabled = true;
                importDataToolStripMenuItem.Enabled = true;
                cancelImportToolStripMenuItem.Visible = false;
                return;
            }

            if (e.Result == null)
            {
                processDepositQueue();
                return;
            }

            DailyDeposit deposit = e.Result as DailyDeposit;
            if (deposit.Empty) {
                setStatus(String.Format("no payments or refund results for {0:MM/dd/yy}", worker.Date));
                processDepositQueue();
            } else  {
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                setStatus("starting export to quickbooks...");
                QBDepositWorker qbWorker = new QBDepositWorker(deposit);
                qbWorker.ProgressChanged += new ProgressChangedEventHandler(workerProgressUpdate);
                qbWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(qbWorker_RunWorkerCompleted);
                qbWorker.RunWorkerAsync();
            }
        }

        private void workerProgressUpdate(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = e.ProgressPercentage;
            if (e.UserState != null)
                setStatus(e.UserState as String);
        }

        private void qbWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                setStatus(String.Format("An error occurred during QuickBooks import\n\n{0}\n\n{1}", e.Error.Message, e.Error.StackTrace));
                setupDepositsToolStripMenuItem.Enabled = true;
                importDataToolStripMenuItem.Enabled = true;
                cancelImportToolStripMenuItem.Visible = false;
            }
            else
            {
                DateTime depositDate = (DateTime)e.Result;
                setStatus("Quickbooks export is complete.");
                UserSettings.getInstance().Configuration.DatesRun.Add(depositDate);
                UserSettings.getInstance().Configuration.LastTimeRun = depositDate;
                UserSettings.getInstance().Save();
                processDepositQueue();
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream s = sfd.OpenFile();
                Configuration c = UserSettings.getInstance().Configuration;
                XmlSerializer xml = new XmlSerializer(c.GetType());
                xml.Serialize(s, UserSettings.getInstance().Configuration);
                s.Close();
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();

            if (odf.ShowDialog() == DialogResult.OK)
            {
                Stream s = odf.OpenFile();
                XmlSerializer xml = new XmlSerializer(typeof(Configuration));
                UserSettings.getInstance().Configuration = xml.Deserialize(s) as Configuration;
                UserSettings.getInstance().Save();
            }
        }

        private void sinceLastImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime lastTime = UserSettings.getInstance().Configuration.LastTimeRun;
            setStatus(String.Format("last import was on {0}", lastTime));
            DateTime now = DateTime.Now;
            lastTime = lastTime.AddDays(1);

            if (lastTime > DateTime.Now) {
                setStatus("No days available.");
                return;
            }

            while (lastTime < DateTime.Now)
            {
                datesToRun.Enqueue(lastTime);
                lastTime = lastTime.AddDays(1);
            }

            processDepositQueue();
        }

        private void processDepositQueue()
        {
            if (datesToRun.Count > 0)
            {
                setupToolStripMenuItem.Enabled = false;
                importDataToolStripMenuItem.Enabled = false;
                cancelImportToolStripMenuItem.Visible = true;
                DateTime dateToRun = datesToRun.Dequeue();
                runDepositFor(dateToRun);

                if (datesToRun.Count > 0)
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel1.Text = String.Format("{0} days export remaining", datesToRun.Count);
                }
            }
            else
            {
                setupToolStripMenuItem.Enabled = true;
                importDataToolStripMenuItem.Enabled = true;
                cancelImportToolStripMenuItem.Visible = false;
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.Visible = false;
                toolStripProgressBar1.Visible = false;
                setStatus("No more dates in queue to be exported.");
            }
        }

        private void setLastRunTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDateSelect frm = new frmDateSelect();
            DateTime lastRunTime = UserSettings.getInstance().Configuration.LastTimeRun;

            if (lastRunTime < DateTime.Now.AddYears(-100))
                frm.SelectionDate = DateTime.Now;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                UserSettings.getInstance().Configuration.LastTimeRun = frm.SelectionDate;
            }
        }

        private void cancelImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datesToRun.Clear();
            eaglesoftLoadDataWorker.CancelAsync();
        }

        private void setupRefundTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration config = UserSettings.getInstance().Configuration;
            var refundMappingDTOs = config.ToRefundMappingDTOs();

            frmRefundTypeMappings f = new frmRefundTypeMappings(refundMappingDTOs);
            if (f.ShowDialog() == DialogResult.OK)
            {
                config.FromRefundMappingDTOs(refundMappingDTOs);
                UserSettings.getInstance().Save();
            }
        }

        private void setupDepositsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DepositConfiguration> depositConfigurations = configuration.Deposits.Select(item => item.Clone()).ToList();
            frmDepositConfiguration frm = new frmDepositConfiguration(depositConfigurations);
            frm.ShowDialog();

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                configuration.Deposits.Clear();
                configuration.Deposits.AddRange(depositConfigurations);
                UserSettings.getInstance().Save();
            }
        }

        private void setupESDatabaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseConnect frm = new frmDatabaseConnect();
            frm.ConnectionString = UserSettings.getInstance().Configuration.EaglesoftConnectionString;
            frm.ShowDialog(this);

            if (frm.DialogResult == DialogResult.OK)
            {

                UserSettings.getInstance().Configuration.EaglesoftConnectionString = frm.ConnectionString;
                UserSettings.getInstance().Save();  
            }
        }

    }
}