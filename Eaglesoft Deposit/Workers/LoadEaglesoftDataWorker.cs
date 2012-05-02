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
using System.Data.Odbc;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Eaglesoft_Deposit.Business_Objects;

namespace Eaglesoft_Deposit.Workers
{
    class LoadEaglesoftDataWorker : BackgroundWorker
    {
        Int32 _totalQueryCount;
        Int32 _queryCount;
        DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public LoadEaglesoftDataWorker()
        {
            DoWork += new DoWorkEventHandler(LoadEaglesoftDataWorker_DoWork);
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        private Int32 calculatePercentageComplete()
        {
            return (Int32)(((Double)_queryCount / (Double)_totalQueryCount) * 100);
        }

        private Payment getBulkPayment(OdbcConnection dbConnection, Int32 bulk_payment_num)
        {
            OdbcCommand command = dbConnection.CreateCommand();
            command.CommandText = "select ic.name as name, bp.description, pt.description as paytype, pt.paytype_id as paytype_id, bp.amount as amount " +
                                  "from bulk_payments bp, paytype pt,insurance_company ic " +
                                  "where pt.paytype_id = bp.paytype_id and ic.insurance_company_id = bp.insurance_company and bulk_payment_num = ?";

            command.Parameters.Add("bulk_payment_num", OdbcType.Int);
            command.Parameters["bulk_payment_num"].Value = bulk_payment_num;

            OdbcDataReader reader = command.ExecuteReader();
            Payment p = new Payment();

            if (reader.HasRows)
            {
                reader.Read();
                p.Amount = (Double)((Decimal)reader["amount"]);

                if (reader["description"] is DBNull == false)
                    p.Description = (String)reader["description"];
                p.Name = (String)reader["name"];
                p.PayType = (String)reader["paytype"];
                reader.Close();
                return p;
            }
            reader.Close();
            return null;
        }

        private Int32 getPaymentCount(OdbcConnection dbConnection, DailyTransactionRange range)
        {
            OdbcCommand command = dbConnection.CreateCommand();

            command.CommandText = " select count(*) from transactions where" +
                                   " type <> 'S' and type <> 'C' and type <> 'D' and amount <> 0 and status <> 'D'" +
                                   " and bulk_payment_num is null and tran_num >= ? and tran_num <= ?";

            command.Parameters.Add("start", OdbcType.Int);
            command.Parameters["start"].Value = range.FromTxn;
            command.Parameters.Add("stop", OdbcType.Int);
            command.Parameters["stop"].Value = range.ToTxn;
            OdbcDataReader reader = command.ExecuteReader();
            reader.Read();
            Int32 count = (int)reader[0];
            reader.Close();
            return count;
        }

        private Int32 getBulkPaymentCount(OdbcConnection dbConnection, DailyTransactionRange range)
        {
            OdbcCommand command = dbConnection.CreateCommand();

            command.CommandText = " select count(distinct bulk_payment_num) from transactions where" +
                                  " type <> 'S' and type <> 'C' and type <> 'D' and amount <> 0 and status <> 'D'" +
                                  " and bulk_payment_num is not null and tran_num >= ? and tran_num <= ?";

            command.Parameters.Add("start", OdbcType.Int);
            command.Parameters["start"].Value = range.FromTxn;
            command.Parameters.Add("stop", OdbcType.Int);
            command.Parameters["stop"].Value = range.ToTxn;
            int count;

            OdbcDataReader reader = command.ExecuteReader();
            reader.Read();
            count = (int)reader[0];

            reader.Close();

            return count;
        }

        private DailyTransactionRange getTransactionRangeFor(OdbcConnection dbConnection, DateTime date)
        {

            OdbcCommand odbcCommand = dbConnection.CreateCommand();

            odbcCommand.CommandText = "Select min(start_tran_num) as start_tran, max(end_tran_num) as stop_tran from eod where date(time_ran) = date(?)";
            odbcCommand.Parameters.Add("date", OdbcType.DateTime);
            odbcCommand.Parameters["date"].Value = date;

            OdbcDataReader reader = odbcCommand.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                if (reader["start_tran"] != DBNull.Value && reader["stop_tran"] != DBNull.Value)
                {
                    DailyTransactionRange range = new DailyTransactionRange();
                    range.Date = date;
                    range.FromTxn = (int)reader["start_tran"];
                    range.ToTxn = (int)reader["stop_tran"];
                    reader.Close();
                    return range;
                }
            }

            reader.Close();
            return null;
        }

        public void fixupCheckNumber(Payment p)
        {
            Match match = Regex.Match(p.Description, @"Check Number:\s?(\d+)");

            if (match.Success)
            {
                p.CheckNumber = p.Description.Substring(match.Index, match.Length);
            }
        }

        public Int32 getRefundCount(OdbcConnection dbConnection, DailyTransactionRange range)
        {
            OdbcCommand odbcCommand = dbConnection.CreateCommand();
            int count;

            odbcCommand.CommandText = "select count(*) from transactions where transactions.type = 'D' and adjustment_type = ? and transactions.tran_num >= ? and transactions.tran_num <= ? and transactions.status <> 'D'";

            odbcCommand.Parameters.Add("adjtype", OdbcType.Int);
            odbcCommand.Parameters.Add("start", OdbcType.Int);
            odbcCommand.Parameters["start"].Value = range.FromTxn;
            odbcCommand.Parameters.Add("stop", OdbcType.Int);
            odbcCommand.Parameters["stop"].Value = range.ToTxn;
            odbcCommand.Parameters["adjtype"].Value = UserSettings.getInstance().RefundConfiguration.ESAdjustmentId;

            OdbcDataReader reader = odbcCommand.ExecuteReader();
            reader.Read();
            count = (int)reader[0];

            reader.Close();
            return count;
        }

        private void LoadEaglesoftDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReportProgress(0, "connecting to database...");
            OdbcConnection dbConnection = new OdbcConnection(UserSettings.getInstance().Configuration.DSN);
            dbConnection.Open();
            ReportProgress(0, "getting trasaction range...");
            DailyTransactionRange rangeToLoad = getTransactionRangeFor(dbConnection, _date);
            if (rangeToLoad == null)
            {
                e.Result = null;
                ReportProgress(0, "no transactions found,");
                return;
            }

            _queryCount = 0;
            ReportProgress(0, String.Format("found {0} transactions...", rangeToLoad.ToTxn - rangeToLoad.FromTxn));
            ReportProgress(0, "getting actual payment counts...");
            _totalQueryCount = getPaymentCount(dbConnection, rangeToLoad) + getBulkPaymentCount(dbConnection, rangeToLoad);
            ReportProgress(calculatePercentageComplete());

            if (UserSettings.getInstance().RefundConfiguration.Enabled)
                _totalQueryCount += getRefundCount(dbConnection, rangeToLoad);

            ReportProgress(calculatePercentageComplete(), "loading payments...");
            DailyDeposit deposit = loadPayments(dbConnection, rangeToLoad, e);

            List<Refund> refunds = null;

            if (UserSettings.getInstance().RefundConfiguration.Enabled && e.Cancel == false)
            {
                refunds = loadRefunds(dbConnection, rangeToLoad, e);
            }
            ReportProgress(calculatePercentageComplete(), "finished...");
            e.Result = new LoadEaglesoftDataWorkerResults(deposit, refunds);
        }

        private static String getStringNullOk(Object s)
        {
            if (s is DBNull)
                return String.Empty;
            else
                return (String)s;
        }

        public List<Refund> loadRefunds(OdbcConnection dbConnection, DailyTransactionRange range, DoWorkEventArgs e)
        {
            List<Refund> refunds = new List<Refund>();


            OdbcCommand odbcCommand = dbConnection.CreateCommand();
            odbcCommand.CommandText = "select transactions.tran_date, patient.first_name, patient.last_name, patient.address_1, patient.address_2, patient.city, patient.state, patient.zipcode, patient.patient_id, amount, description from patient, transactions where transactions.type = 'D' and adjustment_type = ? and transactions.resp_party_id = patient.patient_id and transactions.tran_num >= ? and transactions.tran_num <= ? and transactions.status <> 'D'";
            odbcCommand.Parameters.Add("adjtype", OdbcType.Int);
            odbcCommand.Parameters.Add("start", OdbcType.Int);
            odbcCommand.Parameters["start"].Value = range.FromTxn;
            odbcCommand.Parameters.Add("stop", OdbcType.Int);
            odbcCommand.Parameters["stop"].Value = range.ToTxn;
            odbcCommand.Parameters["adjtype"].Value = UserSettings.getInstance().RefundConfiguration.ESAdjustmentId;

            OdbcDataReader reader = odbcCommand.ExecuteReader();

            while (reader.Read())
            {
                if (CancellationPending)
                {
                    e.Cancel = true;
                    return null;
                }


                Refund r = new Refund();

                r.FirstName = getStringNullOk(reader["first_name"]);
                r.LastName = getStringNullOk(reader["last_name"]);
                r.PatientId = getStringNullOk(reader["patient_id"]);
                r.Address1 = getStringNullOk(reader["address_1"]);
                r.Address2 = getStringNullOk(reader["address_2"]);
                r.City = getStringNullOk(reader["city"]);
                r.State = getStringNullOk(reader["state"]);
                r.Zip = getStringNullOk(reader["zipcode"]);
                r.Amount = (Double)((Decimal)reader["amount"]);
                r.Description = getStringNullOk(reader["description"]);
                _queryCount++;
                ReportProgress(calculatePercentageComplete(), "loading refund..");
                refunds.Add(r);
            }

            reader.Close();


            return refunds;
        }

        private DailyDeposit loadPayments(OdbcConnection dbConnection, DailyTransactionRange rangeToLoad, DoWorkEventArgs e)
        {

            DailyDeposit dailyDeposit = new DailyDeposit(Date);


            List<Int32> bulkPayments = new List<Int32>();
            OdbcCommand odbcCommand = dbConnection.CreateCommand();

            odbcCommand.CommandText = "select t.tran_num as tran_num, p.first_name+' '+p.last_name as name, t.description as description, " +
                                  "pt.description as paytype, pt.paytype_id as paytype_id, -t.amount as amount, t.bulk_payment_num as bulk_payment_num from transactions t, patient p, paytype pt where " +
                                  "type <> 'S' and type <> 'C' and type <> 'D' and amount <> 0 and t.status <> 'D' and " +
                                  "p.patient_id = t.patient_id and pt.paytype_id = t.paytype_id and t.tran_num >= ? and t.tran_num <= ? order by paytype_id, bulk_payment_num, tran_num";

            odbcCommand.Parameters.Add("start", OdbcType.Int);
            odbcCommand.Parameters["start"].Value = rangeToLoad.FromTxn;
            odbcCommand.Parameters.Add("stop", OdbcType.Int);
            odbcCommand.Parameters["stop"].Value = rangeToLoad.ToTxn;
            OdbcDataReader reader = odbcCommand.ExecuteReader();
            Payment p = null;

            while (reader.Read())
            {
                
                if (CancellationPending)
                {
                    e.Cancel = true;
                    reader.Close();
                    return null;
                }

                // If a bulk payment then we must handle that. 
                if (reader["bulk_payment_num"] is DBNull)
                {
                    p = new Payment();
                    p.Name = (String)reader["name"];
                    if (reader["description"] is DBNull == false)
                        p.Description = (String)reader["description"];
                    p.TxnId = (Int32)reader["tran_num"];
                    p.PayType = (String)reader["paytype"];
                    p.Amount = (Double)((Decimal)reader["amount"]);
                    _queryCount++;
                    ReportProgress(calculatePercentageComplete());
                    fixupCheckNumber(p);
                    ReportProgress(calculatePercentageComplete(), String.Format("adding payment {0}, {1}, {2}", p.TxnId, p.PayType, p.Amount));
                    dailyDeposit.addPayment(p);
                }
                else
                {
                    int bulk_payment_number = (int)reader["bulk_payment_num"];
                    if (bulkPayments.Contains(bulk_payment_number) == false)
                    {
                        p = getBulkPayment(dbConnection, bulk_payment_number);
                        _queryCount++;
                        fixupCheckNumber(p);
                        dailyDeposit.addPayment(p);
                        bulkPayments.Add(bulk_payment_number);
                        ReportProgress(calculatePercentageComplete());
                    }
                }
            }
            reader.Close();
            return dailyDeposit;
        }
    }
}
