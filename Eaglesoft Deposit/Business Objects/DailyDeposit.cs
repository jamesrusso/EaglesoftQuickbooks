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

namespace Eaglesoft_Deposit.Business_Objects
{
    /**
     * A Daily deposit consists of one or more deposit objects. 
     *
     */
    public class DailyDeposit
    {
        Configuration _configuration;
        DateTime _depositDate;

        public DateTime DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }
        private Dictionary<Configuration.DepositConfig, Stack<Deposit>> _deposits;

        public DailyDeposit(DateTime date)
        {
            _configuration = UserSettings.getInstance().Configuration;
            _deposits = new Dictionary<Configuration.DepositConfig, Stack<Deposit>>();
            _depositDate = date;
        }

        public void addPayment(Payment p)
        {
            // First get the deposit configuration according to the Eaglesoft payment type. We use this to
            // determine which Quickbooks payment type to use. 
            Configuration.PayType payType = _configuration.getPayTypeByEaglesoftPayType(p.PayType);

            // Find the deposit configuration for this quickbooks pay type.
            Configuration.DepositConfig depositConfig = _configuration.getDepositConfig(payType.QuickbooksPayType);

            Deposit deposit = getDeposit(depositConfig,  payType.QuickbooksPayType);
            deposit.addPayment(p);
        }

        private Deposit getDeposit(Configuration.DepositConfig depositConfig, String qbPayType) { 
            // Lets see if we already have that deposit. 
            if (_deposits.ContainsKey(depositConfig))
            {
                // We already have that one, lets see if it is full or not. 
                Stack<Deposit> stack = _deposits[depositConfig];
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
                _deposits[depositConfig] = newStack;
                return newDeposit;
            }
        }

        public List<Deposit> getDeposits()
        {
            List<Deposit> deposits = new List<Deposit>();
            foreach (Configuration.DepositConfig config in _deposits.Keys) {
                Stack<Deposit> stack = _deposits[config];
                foreach (Deposit d in stack) {
                    deposits.Add(d);
                }
            }

            deposits.Sort();
            return deposits;
        }

        internal void removeAll()
        {
            _deposits.Clear();
        }
    }
}
