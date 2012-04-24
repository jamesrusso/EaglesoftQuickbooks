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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Eaglesoft_Deposit
{
    public partial class frmPayTypeMappings : Form
    {
        private Configuration.PayType _currentPayType = null;


        private List<String> quickbooksPaymentTypes;
        private List<String> quickbooksCustomers;
        private List<String> quickbooksAccounts;

        public frmPayTypeMappings()
        {
            InitializeComponent();
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            listBox1.Enabled = false;
            comboQbAccount.Enabled = false;
            comboQbFrom.Enabled = false;
            comboQbPayType.Enabled = false;
            btnOk.Enabled = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            listBox1.Items.Add("Loading...");
            loadWorker.RunWorkerAsync();
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Error occured while getting data: {0}", e.Error.Message));
                Close();
                return;
            }

            listBox1.Enabled = true;
            btnOk.Enabled = true;
            comboQbAccount.Enabled = true;
            comboQbFrom.Enabled = true;
            comboQbPayType.Enabled = true;
        }

        private void setStatus(String s)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                    {
                        setStatus(s);
                    });
            }
            else
            {
                toolStripStatusLabel1.Text = s;
            }
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Configuration configuration = UserSettings.getInstance().Configuration;
            Quickbooks qb = new Quickbooks();
            setStatus("Connecting to quickbooks..");
            qb.Connect();
            setStatus("Getting QB payment types..");
            quickbooksPaymentTypes = qb.getPaymentTypes();
            setStatus("Getting QB income accounts..");
            quickbooksAccounts = qb.getIncomeAccounts();
            setStatus("Getting QB customers..");
            quickbooksCustomers = qb.getCustomers();
            qb.Disconnect();
            setStatus("Connecting to eaglesoft..");
            EaglesoftDatabase db = new EaglesoftDatabase();
            db.Connect();
            setStatus("Getting eaglesoft paytypes");
            List<String> list = db.GetEaglesoftPayTypes();
            db.Disconnect();

            configuration.refreshPaymentTypes(list);

            foreach (Configuration.PayType payType in configuration.PayTypes)
            {

                if (payType.Customer == null)
                    payType.Customer = quickbooksCustomers[0];

                if (payType.IncomeAccount == null)
                    payType.IncomeAccount = quickbooksAccounts[0];

                if (payType.QuickbooksPayType == null)
                    payType.QuickbooksPayType = quickbooksPaymentTypes[0];

            }

            this.Invoke((MethodInvoker)delegate
            {
                _currentPayType = configuration.PayTypes[0];
                comboQbAccount.DataSource = quickbooksAccounts;
                comboQbAccount.SelectedItem = _currentPayType.IncomeAccount;

                comboQbPayType.DataSource = quickbooksPaymentTypes;
                comboQbPayType.SelectedItem = _currentPayType.QuickbooksPayType;

                comboQbFrom.DataSource = quickbooksCustomers;
                comboQbFrom.SelectedItem = _currentPayType.Customer;

                listBox1.DataSource = configuration.PayTypes;
                listBox1.DisplayMember = "EaglesoftPayType";
            });
            setStatus("");
            UserSettings.getInstance().Save();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration.PayType newPayType = listBox1.SelectedValue as Configuration.PayType;
            _currentPayType = null;

            comboQbAccount.SelectedItem = newPayType.IncomeAccount;
            comboQbFrom.SelectedItem = newPayType.Customer;
            comboQbPayType.SelectedItem = newPayType.QuickbooksPayType;

            _currentPayType = newPayType;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboQbAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_currentPayType != null)
                _currentPayType.IncomeAccount = comboQbAccount.SelectedItem as String;
        }

        private void comboQbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_currentPayType != null)
                _currentPayType.QuickbooksPayType = comboQbPayType.SelectedItem as String;
        }

        private void comboQbFrom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_currentPayType != null)
                _currentPayType.Customer = comboQbFrom.SelectedItem as String;
        }
    }
}