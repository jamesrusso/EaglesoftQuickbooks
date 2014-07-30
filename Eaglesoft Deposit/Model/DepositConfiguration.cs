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
using System.ComponentModel;
using System.Linq;
using System.Text;
using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit.Model
{
    /**
     * This represents a deposit which will be made into quickbooks. 
     * This deposit will include 1 or more payment types and 0 or more Refund types.
    */
    public class DepositConfiguration : IComparable<DepositConfiguration>
    {
        public String Memo { get; set; }
        public QuickbooksAccount BankAccount { get; set; }
        public Int32 Order { get; set; }
        public List<DepositConfigPayType> QuickBooksPaymentTypes { get; set; }

        public DepositConfiguration()
        {
            Order = 0;
            QuickBooksPaymentTypes = new List<DepositConfigPayType>();
        }

        public String PayTypeStrings
        {
            get
            {
                List<String> s = new List<String>();
                foreach (DepositConfigPayType payType in QuickBooksPaymentTypes)
                {
                    if (payType.Maximum == Int32.MaxValue)
                        s.Add(payType.QuickbooksPaytype.Name);
                    else
                        s.Add(payType.QuickbooksPaytype.Name + " (max " + payType.Maximum + ")");
                }

                if (s.Count == 0)
                    return "<None>";
                return String.Join(", ", s.ToArray());
            }

        }

        public Int32 getMaximum(QuickbooksPaytype qbPaymentType)
        {
            foreach (DepositConfigPayType payType in QuickBooksPaymentTypes)
            {
                if (payType.QuickbooksPaytype.Equals(qbPaymentType))
                    return payType.Maximum;
            }

            throw new Exception(String.Format("{0} is not contained in this deposit configuration", qbPaymentType));
        }

        public DepositConfiguration Clone()
        {
            DepositConfiguration newConfig = new DepositConfiguration() { 
                Memo = this.Memo, 
                Order = this.Order, 
                BankAccount = this.BankAccount, 
                QuickBooksPaymentTypes =  this.QuickBooksPaymentTypes.Select(item => item.Clone()).ToList()
            };

            return newConfig;
        }

        #region IComparable<DepositConfig> Members

        public int CompareTo(DepositConfiguration other)
        {
            return Order.CompareTo(other.Order);
        }

        #endregion
    }
}
