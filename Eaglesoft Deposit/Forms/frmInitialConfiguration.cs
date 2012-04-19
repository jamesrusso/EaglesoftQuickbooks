using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmInitialConfiguration : Form
    {
    
    public static class OdbcWrapper
    {
        [DllImport("odbc32.dll")]
        public static extern int SQLDataSources(int EnvHandle, int Direction, StringBuilder ServerName, int ServerNameBufferLenIn,
            ref int ServerNameBufferLenOut, StringBuilder Driver, int DriverBufferLenIn, ref int DriverBufferLenOut);

        [DllImport("odbc32.dll")]
        public static extern int SQLAllocEnv(ref int EnvHandle);
    }

    public List<String> ListODBCsources()
    {
        List<String> list = new List<String>();
        int envHandle=0;
        const int SQL_FETCH_NEXT = 1;
        const int SQL_FETCH_FIRST_SYSTEM = 32;

        if (OdbcWrapper.SQLAllocEnv(ref envHandle) != -1)
        {
            int ret;
            StringBuilder serverName = new StringBuilder(1024);
            StringBuilder driverName = new StringBuilder(1024);
            int snLen = 0;
            int driverLen = 0;
            ret = OdbcWrapper.SQLDataSources(envHandle, SQL_FETCH_FIRST_SYSTEM, serverName, serverName.Capacity, ref snLen,
                        driverName, driverName.Capacity, ref driverLen);
            
            while (ret == 0)
            {
                list.Add(serverName.ToString());
                ret = OdbcWrapper.SQLDataSources(envHandle, SQL_FETCH_NEXT, serverName, serverName.Capacity, ref snLen,
                        driverName, driverName.Capacity, ref driverLen);
            } 
        }
        return list;
    }

        public frmInitialConfiguration()
        {
            InitializeComponent();
            comboBox1.DataSource = ListODBCsources();
            grpBoxEaglesoft.Visible = true;
            grpBoxQuickbooks.Visible = false;
            
        }

        private void frmInitialConfiguration_Load(object sender, EventArgs e)
        {
        }

        private void btnEaglesoftDBTesxt_Click(object sender, EventArgs e)
        {
            EaglesoftDatabase es = new EaglesoftDatabase();
            UserSettings.getInstance().Configuration.DSN = "DSN=" + comboBox1.SelectedValue as String;
            try
            {
                es.Connect();
                btnEaglesoftDBTesxt.Enabled = false;
                lblESPassFail.Text = "Pass";
                lblESPassFail.ForeColor = Color.Green;
                lblESPassFail.Visible = true;
                UserSettings.getInstance().Configuration.refreshPaymentTypes(es.GetEaglesoftPayTypes());
                es.Disconnect();
                grpBoxEaglesoft.Visible = false;
                grpBoxQuickbooks.Location = grpBoxEaglesoft.Location;
                grpBoxQuickbooks.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("failed to establish connection to ES: {0}", ex.Message));
            }
        }

        private void btnQuickbooksTest_Click(object sender, EventArgs e)
        {
            try
            {
                Quickbooks qb = new Quickbooks();
                qb.Connect();
                lblQuickbooksPassFail.Text = "Pass";
                lblQuickbooksPassFail.ForeColor = Color.Green;
                lblQuickbooksPassFail.Visible = true;
                btnQuickbooksTest.Enabled = false;
                qb.Disconnect();
                UserSettings.getInstance().Configuration.InitialConfigurationComplete = true;
                UserSettings.getInstance().Configuration.LastTimeRun = DateTime.Now.AddDays(-1);
                UserSettings.getInstance().Save();
         
                finishConfiguration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("failed to connect: {0}", ex.Message));
            }
        }

        private void finishConfiguration()
        {
            DialogResult = DialogResult.OK;
            frmPayTypeMappings payTypes = new frmPayTypeMappings();
            payTypes.ShowDialog();
            Close();
        }

        private void grpBoxEaglesoft_VisibleChanged(object sender, EventArgs e)
        {
            if (grpBoxEaglesoft.Visible)
            {
                lblInstructions.Text = "First, we must establish a connection to Eaglesoft in order to obtain the pay types. Please select the ODBC datasource for Eaglesoft and select Test";
            }
        }

        private void grpBoxQuickbooks_VisibleChanged(object sender, EventArgs e)
        {
            if (grpBoxQuickbooks.Visible)
            {
                lblInstructions.Text = "Great. Please open up Quickbooks so that we can make a connection to it. Quickbooks may prompt you for permission to allow this application access. Grant access. Leave Quickbooks running while we finish up the configuration.";
            }

        }



    }
}
