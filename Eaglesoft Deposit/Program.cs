using System;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using Eaglesoft_Deposit.Forms;


namespace Eaglesoft_Deposit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            if (UserSettings.getInstance().Configuration.InitialConfigurationComplete == false)
            {
                frmInitialConfiguration frm = new frmInitialConfiguration();
                if (frm.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmMain());

            } else { 

            Application.Run(new frmMain());
                }
            Properties.Settings.Default.Save();
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is  Quickbooks.QuickbooksConnectionException)
            {
                MessageBox.Show("It appears that QuickBooks is not running?", "Quickbooks running", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(String.Format("An exception has occured. {0}\n\n{1}", e.Exception.Message, e.Exception.StackTrace));
            }
        }
    }
}