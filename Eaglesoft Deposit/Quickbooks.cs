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
using Eaglesoft_Deposit.Model;
using QBFC13Lib;

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

        public List<QuickbooksAccount> getIncomeAccounts()
        {
            return getAccounts(ENAccountType.atIncome);
        }

        public List<QuickbooksAccount> getBankAccounts()
        {
            return getAccounts(ENAccountType.atBank);
        }

        /// <summary>
        /// Obtain a list of all QuickBooks accounts.
        /// </summary>
        /// <returns>a list of quickbooks accounts</returns>
        private List<QuickbooksAccount> getAccounts(ENAccountType type)
        {
            List<QuickbooksAccount> account = new List<QuickbooksAccount>();
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            IAccountQuery query = msgRequest.AppendAccountQueryRq();
            query.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(type);
            IMsgSetResponse response = qbMgr.DoRequests(msgRequest);
            IAccountRetList qbAccounts = (IAccountRetList)response.ResponseList.GetAt(0).Detail;


            for (int i = 0; qbAccounts != null && i < qbAccounts.Count; i++)
                account.Add(new QuickbooksAccount() { Name = qbAccounts.GetAt(i).FullName.GetValue() });

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
        public List<QuickbooksPaytype> getPaymentTypes()
        {
            List<QuickbooksPaytype> paymentTypes = new List<QuickbooksPaytype>();
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            msgRequest.AppendPaymentMethodQueryRq();
            IMsgSetResponse response = qbMgr.DoRequests(msgRequest);
            IPaymentMethodRetList payment_methods = (IPaymentMethodRetList)response.ResponseList.GetAt(0).Detail;

            for (int i = 0; i < payment_methods.Count; i++) 
                paymentTypes.Add(new QuickbooksPaytype() { Name = payment_methods.GetAt(i).Name.GetValue() });

            return paymentTypes;
        }

        /// <summary>
        /// Obtain a listing of all quickbooks customers.
        /// </summary>
        /// <returns>a list of all quickbooks customers</returns>
        public List<QuickbooksCustomer> getCustomers()
        {
            List<QuickbooksCustomer> customers = new List<QuickbooksCustomer>();
            IMsgSetRequest msgRequest = qbMgr.CreateMsgSetRequest("US", 4, 0);
            msgRequest.Attributes.OnError = ENRqOnError.roeStop;
            msgRequest.AppendCustomerQueryRq();
            IMsgSetResponse response = qbMgr.DoRequests(msgRequest);
            ICustomerRetList qbCustomers = (ICustomerRetList)response.ResponseList.GetAt(0).Detail;

            for (int i = 0; qbCustomers != null && i < qbCustomers.Count; i++)
                customers.Add(new QuickbooksCustomer() { Name = qbCustomers.GetAt(i).Name.GetValue() });

            return customers;
        }


        internal List<QuickbooksAccount> getExpenseAccounts()
        {
                 return getAccounts(ENAccountType.atExpense);
        }

        
      
    }
}
