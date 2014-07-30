using System;

using System.ComponentModel;
using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit.Workers
{
    class RefreshDataWorker : BackgroundWorker
    {
        private Configuration _configuration;

        public RefreshDataWorker()
        {
            DoWork += RefreshDataWorker_DoWork;
            _configuration = UserSettings.getInstance().Configuration;
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        private void checkCanceled(DoWorkEventArgs e)
        {
            if (CancellationPending)
                throw new OperationCanceledException("The operation was canceled by request");
        }
     

        void RefreshDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Quickbooks qb = new Quickbooks();
            Eaglesoft es = new Eaglesoft();

            try
            {
                Configuration configuration = UserSettings.getInstance().Configuration;
                checkCanceled(e);
                qb.Connect();

                checkCanceled(e);
                ReportProgress(15, "Obtaining QB payment types");
                _configuration.QuickbooksPaytypes = qb.getPaymentTypes();

                checkCanceled(e);
                ReportProgress(30, "Obtaining QB Income accounts");
                _configuration.QuickbooksIncomeAccounts = qb.getIncomeAccounts();

                checkCanceled(e);
                ReportProgress(45, "Obtaining QB Bank accounts");
                _configuration.QuickbooksBankAccounts = qb.getBankAccounts();
                
                checkCanceled(e);
                ReportProgress(60, "Obtaining QB Customers");
                _configuration.QuickbooksCustomers = qb.getCustomers();

                checkCanceled(e);
                es.Connect();

                checkCanceled(e);
                ReportProgress(75, "Obtaining ES payment types.");

                checkCanceled(e);
                _configuration.EaglesoftPaytypes = es.getPaytypes();

                checkCanceled(e);
                ReportProgress(90, "Obtaining ES adjustment types.");

                _configuration.EaglesoftAdjustments = es.getAdjustmentTypes();
                _configuration.normalizeConfiguration();
                _configuration.LastRefreshTime = DateTime.Now;
                UserSettings.getInstance().Save();
                ReportProgress(100, "Completes");
            }
            catch (OperationCanceledException)
            {
                e.Cancel = true;
                return;
            }
            finally
            {
                qb.Disconnect();
                es.Disconnect();
            }
        }
    }
}