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
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Eaglesoft_Deposit.Model;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace Eaglesoft_Deposit.Workers
{
    class LoadEaglesoftDataWorker : BackgroundWorker
    {
        private Int32 queryCount;
        private Int32 totalQueryCount;

        public DateTime Date { get; set; }
        public Configuration Configuration { get; set; }

        public LoadEaglesoftDataWorker()
        {
            DoWork += new DoWorkEventHandler(LoadEaglesoftDataWorker_DoWork);
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        private Int32 calculatePercentageComplete()
        {
            return (Int32)(((Double)queryCount / (Double)totalQueryCount) * 100);
        }

        private void LoadEaglesoftDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Eaglesoft es = new Eaglesoft();
            DailyDeposit dailyDeposit = new DailyDeposit(Date);
            try
            {

                if (CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                es.Connect();
                DailyTransactionRange range = es.getTransactionRangeFor(Date);
                if (range == null)
                {
                    ReportProgress(100, "No data available");
                    return;
                }
                queryCount = 0;
                totalQueryCount = es.getPaymentCount(range) + es.getRefundCount(range);

                List<EaglesoftBulkPayment> bulkPaymentsProcessed = new List<EaglesoftBulkPayment>();
                List<Int32> paymentTxnIds = es.getPaymentTransactionIds(range);
                List<Int32> refundTxnIds = es.getRefundTransactionIds(range);
                e.Result = dailyDeposit;

                foreach (Int32 paymentTxnId in paymentTxnIds)
                {
                    EaglesoftPayment payment = es.getPayment(paymentTxnId);
                    EaglesoftBulkPayment bulkPayment = payment as EaglesoftBulkPayment;
                    queryCount++;
                    
                    if (bulkPayment == null)
                    {
                        dailyDeposit.addPayment(payment);
                        ReportProgress(calculatePercentageComplete(), String.Format("{0}", payment));
                    }
                    else if (bulkPayment != null && bulkPaymentsProcessed.Contains(bulkPayment) == false)
                    {
                        dailyDeposit.addPayment(payment);
                        ReportProgress(calculatePercentageComplete(), String.Format("{0}", payment));
                    }

                    if (bulkPayment != null)
                        bulkPaymentsProcessed.Add(bulkPayment);

                    if (CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                foreach (Int32 refundTxnId in refundTxnIds)
                {
                    EaglesoftRefund refund = es.getRefund(refundTxnId);
                    dailyDeposit.addRefund(refund);
                    queryCount++;
                    ReportProgress(calculatePercentageComplete(), String.Format("{0}", refund));
                    if (CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                }

                
            }
            finally
            {
                if (es != null)
                    es.Disconnect();
            }





        }


    }
}
