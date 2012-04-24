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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Eaglesoft_Deposit.Business_Objects;
using Interop.QBFC11;

namespace Eaglesoft_Deposit
{
    public class Quickbooks
    {
        private QBSessionManager qbMgr;

        public delegate ProgressChanged ProgressChanged(Int32 currentProgress, Int32 totalProgress);
        
        public class QuickbooksConnectionException : Exception
        {
            public QuickbooksConnectionException(String message)
                : base(message)
            {
            }
        }

        /// <summary>
        /// </summary>
        public Quickbooks()
        {
        }

        public void Disconnect()
        {
            if (qbMgr != null)
                qbMgr.EndSession();
        }

        public void Connect()
        {
            qbMgr = new QBSessionManager();
            try
            {
                qbMgr.OpenConnection("EaglesoftDeposit", "Eaglesoft Deposit");
                qbMgr.BeginSession("", ENOpenMode.omDontCare);
            }
            catch (Exception e)
            {
                if (e.Message.Equals("Could not start QuickBooks."))
                    throw new QuickbooksConnectionException(e.Message);
                else
                    throw e;
            }
        }

        public List<String> getIncomeAccounts()
        {
            return getAccounts(ENAccountType.atIncome);
        }

        public List<String> getBankAccounts()
        {
            return getAccounts(ENAccountType.atBank);
        }

        /// <summary>
        /// Obtain a list of all QuickBooks accounts.
        /// </summary>
        /// <returns>a list of quickbooks accounts</returns>
        private List<String> getAccounts(ENAccountType type)
        {
            List<String> account = new List<string>();
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            IAccountQuery query = msgRequest.AppendAccountQueryRq();
            query.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(type);
            IMsgSetResponse response = qbMgr.DoRequests(msgRequest);
            IAccountRetList qbAccounts = (IAccountRetList)response.ResponseList.GetAt(0).Detail;


            for (int i = 0; qbAccounts != null && i < qbAccounts.Count; i++)
                account.Add(qbAccounts.GetAt(i).FullName.GetValue());

            return account;
        }

        public IMsgSetRequest newRequest()
        {
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            return msgRequest;
        }

        public IMsgSetResponse performRequest(IMsgSetRequest request)
        {
            return qbMgr.DoRequests(request);
        }


        /// <summary>
        /// Obtain a listing of all valid payment types in Quickbooks.
        /// </summary>
        /// <returns>a list of all quickbooks payment types</returns>
        public List<String> getPaymentTypes()
        {
            List<String> paymentTypes = new List<string>();
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            msgRequest.AppendPaymentMethodQueryRq();
            IMsgSetResponse response = qbMgr.DoRequests(msgRequest);
            IPaymentMethodRetList payment_methods = (IPaymentMethodRetList)response.ResponseList.GetAt(0).Detail;

            for (int i = 0; i < payment_methods.Count; i++)
                paymentTypes.Add(payment_methods.GetAt(i).Name.GetValue());

            return paymentTypes;
        }

        /// <summary>
        /// Obtain a listing of all quickbooks customers.
        /// </summary>
        /// <returns>a list of all quickbooks customers</returns>
        public List<String> getCustomers()
        {
            List<String> customers = new List<string>();
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            msgRequest.AppendCustomerQueryRq();
            IMsgSetResponse response = qbMgr.DoRequests(msgRequest);
            ICustomerRetList qbCustomers = (ICustomerRetList)response.ResponseList.GetAt(0).Detail;

            for (int i = 0; qbCustomers != null && i < qbCustomers.Count; i++)
                customers.Add(qbCustomers.GetAt(i).Name.GetValue());

            return customers;

        }

        
        internal List<string> getExpenseAccounts()
        {
                 return getAccounts(ENAccountType.atExpense);
        }

           private IDepositAdd _depositAddRq;
        
        /// <summary>
        /// Create a deposit perform it.
        /// </summary>
        /// <param name="deposit">The request where this deposit will be added.</param>
        public void performDeposit(DailyDeposit dailyDeposit) {
            foreach (Deposit deposit in dailyDeposit.getDeposits())  { 

                IMsgSetRequest qbRequests = qbMgr.CreateMsgSetRequest("US", 4, 0);
                qbRequests.Attributes.OnError = ENRqOnError.roeStop;
                _depositAddRq = qbRequests.AppendDepositAddRq();
                _depositAddRq.Memo.SetValue(deposit.DepositConfig.Memo);
                _depositAddRq.TxnDate.SetValue(dailyDeposit.DepositDate);
                _depositAddRq.DepositToAccountRef.FullName.SetValue(deposit.DepositConfig.BankAccount);

                foreach (DepositLine line in deposit.Lines) { 
                    IDepositLineAdd depositLineAdd = _depositAddRq.DepositLineAddList.Append();
                    depositLineAdd.ORDepositLineAdd.DepositInfo.EntityRef.FullName.SetValue(line.Customer);
                    depositLineAdd.ORDepositLineAdd.DepositInfo.AccountRef.FullName.SetValue(line.IncomeAccount);
                    depositLineAdd.ORDepositLineAdd.DepositInfo.Amount.SetValue(line.Amount);
                    
                    if (line.CheckNumber != null) 
                        depositLineAdd.ORDepositLineAdd.DepositInfo.CheckNumber.SetValue(line.CheckNumber.Substring(0, Math.Min(line.CheckNumber.Length, 11)));

                    depositLineAdd.ORDepositLineAdd.DepositInfo.PaymentMethodRef.FullName.SetValue(line.PaymentMethod);

                    if (line.Memo != null) 
                        depositLineAdd.ORDepositLineAdd.DepositInfo.Memo.SetValue(line.Memo);
                }

                IMsgSetResponse response = qbMgr.DoRequests(qbRequests);
                List<IResponse> errors = new List<IResponse>();
                for (int i = 0; i < response.ResponseList.Count; i++)
                {
                    if (response.ResponseList.GetAt(i).StatusCode != 0)
                    {
                        errors.Add(response.ResponseList.GetAt(i));
                    }
                }
            }
        }
    }
}
