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
using System.Text;
using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit.Model
{
    /**
     * A Daily deposit consists of one or more deposit objects. 
     *
     */

    public class DailyDeposit
    {
        public Configuration Configuration { get; set; }
        public DateTime DepositDate { get; set; }
        public List<CheckToWrite> ChecksToWrite { get; set; }
        public Dictionary<Model.DepositConfiguration, Stack<Deposit>> Deposits;

        public DailyDeposit(DateTime date)
        {
            Configuration = UserSettings.getInstance().Configuration;
            Deposits = new Dictionary<Model.DepositConfiguration, Stack<Deposit>>();
            ChecksToWrite = new List<CheckToWrite>();
            DepositDate = date;
        }


        public void addRefund(EaglesoftRefund refund)
        {

            EaglesoftAdjustmentType adjustmentType = refund.AdjustmentType;

            RefundTypeMapping mapping = Configuration.getRefundTypeByEaglesoftAdjustmentType(adjustmentType);

            if (mapping.Enabled)
            {
                if (mapping.IssueCheck)
                {
                    writeRefundCheck(mapping, refund);
                }
                else
                {
                    addRefundToDeposit(mapping, refund);
                }
            }
        }

        private void addRefundToDeposit(RefundTypeMapping mapping, EaglesoftRefund refund)
        {
            DepositConfiguration depositConfig = Configuration.getDepositConfig(mapping.QuickbooksPaytype);
            Deposit deposit = getDeposit(depositConfig, mapping.QuickbooksPaytype);
            deposit.addRefund(refund);
        }

        private void writeRefundCheck(RefundTypeMapping mapping, EaglesoftRefund refund)
        {
            if (mapping.RefundCheckRecipient == RefundCheckRecipient.ResposibleParty)
            {
                ChecksToWrite.Add(new CheckToWrite() { 
                    RecipientId = refund.PatientId,
                    FullName = refund.FirstName+" "+refund.LastName,
                    Address1 = refund.Address1,
                    Address2 = refund.Address2,
                    Amount = refund.Amount,
                    City = refund.City,
                    State = refund.State,
                    Zip = refund.Zip,
                    Memo = refund.Description,
                    QbBankAccount = mapping.RefundCheckBankAccount.Name,
                    QbIncomeAccount = mapping.IncomeAccount.Name
                });


            }
            else if (mapping.RefundCheckRecipient == RefundCheckRecipient.InsuranceCompany)
            {
                ChecksToWrite.Add(new CheckToWrite()
                {
                    FullName = refund.InsuranceCompany_Name,
                    Address1 = refund.InsuranceCompany_Address1,
                    Address2 = refund.InsuranceCompany_Address2,
                    City = refund.InsuranceCompany_City,
                    State = refund.InsuranceCompany_State,
                    Zip = refund.InsuranceCompany_Zip,
                    Amount = refund.Amount,
                    Memo = refund.Description,
                    QbBankAccount = mapping.RefundCheckBankAccount.Name,
                    QbIncomeAccount = mapping.IncomeAccount.Name
                });
            }
        }

        public void addPayment(EaglesoftPayment p)
        {
            // First get the deposit configuration according to the Eaglesoft payment type. We use this to
            // determine which Quickbooks payment type to use. 
            PaytypeMapping payType = Configuration.getPayTypeByEaglesoftPayType(p.EaglesoftPayType);

            // Find the deposit configuration for this quickbooks pay type.
            DepositConfiguration depositConfig = Configuration.getDepositConfig(payType.QuickbooksPayType);

            Deposit deposit = getDeposit(depositConfig, payType.QuickbooksPayType);
            deposit.addPayment(p);
        }

        private Deposit getDeposit(DepositConfiguration depositConfig, QuickbooksPaytype qbPayType)
        {
            // Lets see if we already have that deposit. 
            if (Deposits.ContainsKey(depositConfig))
            {
                // We already have that one, lets see if it is full or not. 
                Stack<Deposit> stack = Deposits[depositConfig];
                Deposit topDeposit = stack.Peek();

                if (topDeposit.isFull(qbPayType))
                {
                    Deposit deposit = new Deposit(depositConfig);
                    stack.Push(deposit);
                    return deposit;
                }
                else
                {
                    return topDeposit;
                }
            }
            else
            {
                // Don't have this type of deposit. Lets create it. 
                Deposit newDeposit = new Deposit(depositConfig);
                Stack<Deposit> newStack = new Stack<Deposit>();
                newStack.Push(newDeposit);
                Deposits[depositConfig] = newStack;
                return newDeposit;
            }
        }

        public List<Deposit> getDeposits()
        {
            List<Deposit> deposits = new List<Deposit>();
            foreach (DepositConfiguration config in Deposits.Keys)
            {
                Stack<Deposit> stack = Deposits[config];
                foreach (Deposit d in stack)
                {
                    deposits.Add(d);
                }
            }

            deposits.Sort();
            return deposits;
        }

        internal void removeAll()
        {
            Deposits.Clear();
        }

        public Boolean Empty { get { return false; } }
    }
}
