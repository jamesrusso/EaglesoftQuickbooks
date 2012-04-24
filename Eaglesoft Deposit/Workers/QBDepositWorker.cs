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
using Interop.QBFC11;

namespace Eaglesoft_Deposit.Workers
{
    class QBDepositWorker : BackgroundWorker
    {
        private DailyDeposit _deposit;
        private List<Refund> _refunds;
        private Int32 _totalItems;
        private Int32 _currentItem;

        public QBDepositWorker(LoadEaglesoftDataWorkerResults results)
        {
            DoWork += new DoWorkEventHandler(QBDepositWorker_DoWork);
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            _deposit = results.Deposit;
            _refunds = results.Refunds;
        }

        public Int32 calculatePercentageComplete()
        {
            return (Int16)(((Double)_currentItem / (Double)_totalItems) * 100);
        }

        private void UpdateCustomer(Quickbooks qb, ICustomerRet customer, Refund r)
        {
            List<String> account = new List<string>();
            IMsgSetRequest msgRequest = qb.newRequest();
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            ICustomerMod customerMod = msgRequest.AppendCustomerModRq();

            customerMod.ListID.SetValue(customer.ListID.GetValue());
            customerMod.AccountNumber.SetValue(r.PatientId);
            customerMod.Name.SetValue(r.FirstName + " " + r.LastName);
            customerMod.FirstName.SetValue(r.FirstName);
            customerMod.LastName.SetValue(r.LastName);
            customerMod.BillAddress.Addr1.SetValue(customerMod.Name.GetValue());
            customerMod.BillAddress.Addr2.SetValue(r.Address1);
            customerMod.BillAddress.Addr3.SetValue(r.Address2);

            customerMod.Contact.SetValue(customerMod.Name.GetValue());
            customerMod.BillAddress.City.SetValue(r.City);
            customerMod.BillAddress.State.SetValue(r.State);
            customerMod.BillAddress.PostalCode.SetValue(r.Zip);
            customerMod.EditSequence.SetValue(customer.EditSequence.GetValue());
            IMsgSetResponse response = qb.performRequest(msgRequest);

            if (response.ResponseList.GetAt(0).StatusCode != 0)
                throw new Exception("Unable to add customer " + response.ResponseList.GetAt(0).StatusMessage);
        }

        private void WriteRefundCheck(Quickbooks qb,
            Refund r)
        {
            ICustomerRet customer = FindCustomer(qb,r.FirstName, r.LastName);

            if (customer == null)
                customer = addCustomer(qb,r);
            else
                UpdateCustomer(qb, customer, r);

            IMsgSetRequest msgRequest = qb.newRequest();
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;

            ICheckAdd addCheckRequest = msgRequest.AppendCheckAddRq();
            addCheckRequest.PayeeEntityRef.ListID.SetValue(customer.ListID.GetValue());


            addCheckRequest.AccountRef.FullName.SetValue(UserSettings.getInstance().RefundConfiguration.QBCheckingAccount);
            IExpenseLineAdd expenseAdd = addCheckRequest.ExpenseLineAddList.Append();
            expenseAdd.AccountRef.FullName.SetValue("Fee Refunds");
            expenseAdd.Amount.SetValue((double)r.Amount);
            expenseAdd.Memo.SetValue(r.Description);

            addCheckRequest.IsToBePrinted.SetValue(true);
            addCheckRequest.RefNumber.SetEmpty();

            IMsgSetResponse response = qb.performRequest(msgRequest);

            if (response.ResponseList.GetAt(0).StatusCode != 0)
            {
                throw new Exception("failed to write refund check " + response.ResponseList.GetAt(0).StatusMessage);
            }
        }

        private ICustomerRet addCustomer(Quickbooks qb, Refund r)
        {
            IMsgSetRequest msgRequest = qb.newRequest();
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;

            ICustomerAdd addCustomer = msgRequest.AppendCustomerAddRq();

            addCustomer.AccountNumber.SetValue(r.PatientId);
            addCustomer.Name.SetValue(r.FirstName + " " + r.LastName);
            addCustomer.FirstName.SetValue(r.FirstName);
            addCustomer.LastName.SetValue(r.LastName);
            addCustomer.BillAddress.Addr1.SetValue(addCustomer.Name.GetValue());
            addCustomer.BillAddress.Addr2.SetValue(r.Address1);
            addCustomer.BillAddress.Addr3.SetValue(r.Address2);

            addCustomer.Contact.SetValue(addCustomer.Name.GetValue());
            addCustomer.BillAddress.City.SetValue(r.City);
            addCustomer.BillAddress.State.SetValue(r.State);
            addCustomer.BillAddress.PostalCode.SetValue(r.Zip);

            IMsgSetResponse response = qb.performRequest(msgRequest);

            if (response.ResponseList.GetAt(0).StatusCode == 0)
            {
                ICustomerRet result = (ICustomerRet)response.ResponseList.GetAt(0).Detail;
                return result;
            }
            else
            {
                throw new Exception("Unable to add customer " + response.ResponseList.GetAt(0).StatusMessage);
            }
        }

        private ICustomerRet FindCustomer(Quickbooks qb, String firstName, String lastName)
        {
            IMsgSetRequest msgRequest = qb.newRequest();
            ICustomerQuery customerQuery = msgRequest.AppendCustomerQueryRq();
            customerQuery.ORCustomerListQuery.FullNameList.Add(firstName + " " + lastName);
            IMsgSetResponse response = qb.performRequest(msgRequest);

            ICustomerRetList qbCustomers = (ICustomerRetList)response.ResponseList.GetAt(0).Detail;

            if (qbCustomers == null)
                return null;

            return qbCustomers.GetAt(0);
        }

        private void QBDepositWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Quickbooks qb = new Quickbooks();
            List<Deposit> deposits = _deposit.getDeposits();
            _currentItem = 0;
            _totalItems = deposits.Count;
            if (_refunds != null) 
                _totalItems += _refunds.Count;
            e.Result = _deposit.DepositDate;
            ReportProgress(calculatePercentageComplete());
            
            try
            {
                qb.Connect();

                doDeposits(qb, deposits, e);

                if (e.Cancel == false)
                    doRefunds(qb, _refunds, e);

            }
            finally
            {
                qb.Disconnect();
            }
        }

        private void doRefunds(Quickbooks qb, List<Refund> refunds, DoWorkEventArgs e)
        {
            foreach (Refund r in refunds)
            {
                ReportProgress(calculatePercentageComplete(), String.Format("writing refund check to {0} {1}", r.FirstName, r.LastName));
                _currentItem++;
                WriteRefundCheck(qb, r);
            }
        }

        private void doDeposits(Quickbooks qb,List<Deposit> deposits, DoWorkEventArgs e)
        {
            
            foreach (Deposit deposit in deposits)
            {

                _currentItem++;
                IMsgSetRequest qbRequests = qb.newRequest();
                qbRequests.Attributes.OnError = ENRqOnError.roeStop;
                IDepositAdd depositAddRequest = qbRequests.AppendDepositAddRq();
                depositAddRequest.Memo.SetValue(deposit.DepositConfig.Memo);
                depositAddRequest.TxnDate.SetValue(_deposit.DepositDate);
                depositAddRequest.DepositToAccountRef.FullName.SetValue(deposit.DepositConfig.BankAccount);

                foreach (DepositLine line in deposit.Lines)
                {
                    IDepositLineAdd depositLineAdd = depositAddRequest.DepositLineAddList.Append();
                    depositLineAdd.ORDepositLineAdd.DepositInfo.EntityRef.FullName.SetValue(line.Customer);
                    depositLineAdd.ORDepositLineAdd.DepositInfo.AccountRef.FullName.SetValue(line.IncomeAccount);
                    depositLineAdd.ORDepositLineAdd.DepositInfo.Amount.SetValue(line.Amount);

                    if (line.CheckNumber != null)
                        depositLineAdd.ORDepositLineAdd.DepositInfo.CheckNumber.SetValue(line.CheckNumber.Substring(0, Math.Min(line.CheckNumber.Length, 11)));

                    depositLineAdd.ORDepositLineAdd.DepositInfo.PaymentMethodRef.FullName.SetValue(line.PaymentMethod);

                    if (line.Memo != null)
                        depositLineAdd.ORDepositLineAdd.DepositInfo.Memo.SetValue(line.Memo);
                }

                ReportProgress(calculatePercentageComplete(), String.Format("adding deposit {0}", deposit.DepositConfig.Memo)); ;
                IMsgSetResponse response = qb.performRequest(qbRequests);
                List<IResponse> errors = new List<IResponse>();
                for (int i = 0; i < response.ResponseList.Count; i++)
                {
                    if (response.ResponseList.GetAt(i).StatusCode != 0)
                    {
                        throw new Exception(String.Format("Failed to perform deposit {0}", response.ResponseList.GetAt(i).StatusMessage));
                    }
                }
            }
        }
    }

}


