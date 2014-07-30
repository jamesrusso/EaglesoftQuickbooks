using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Eaglesoft_Deposit.Workers;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmRefreshExternalData : Form
    {
        public frmRefreshExternalData()
        {
            InitializeComponent();
            RefreshDataWorker refreshWorker = new RefreshDataWorker();
            refreshWorker.ProgressChanged += refreshWorker_ProgressChanged;
            refreshWorker.RunWorkerCompleted += refreshWorker_RunWorkerCompleted;
            refreshWorker.RunWorkerAsync();
        }

        void refreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        void refreshWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = e.UserState as String;
            progressBar1.Value = e.ProgressPercentage;
        }

      

    }
}
