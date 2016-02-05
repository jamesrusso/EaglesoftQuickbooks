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
    /// <summary>
    /// This class represents a single deposit to be made to quickbooks. It will include 1 or more line of payments and possibily refunds.
    /// </summary>
    public class Deposit : IComparable<Deposit>
    {
        Dictionary<QuickbooksPaytype, Int32> _payTypeCounts = new Dictionary<QuickbooksPaytype, int>();
        DepositConfiguration _depositConfig;
        List<DepositLine> _lines;

        public DepositConfiguration DepositConfig
        {
            get { return _depositConfig; }
        } 

        public Deposit(DepositConfiguration depositConfig)
        {
            _depositConfig = depositConfig;
            _lines = new List<DepositLine>();
        }

        public List<DepositLine> Lines
        {
            get { return _lines; }
        }

        /**
         * Return true if we cannot accept any more of the specified deposit pay type. 
         */
        public Boolean isFull(QuickbooksPaytype qbPayType) 
        {
            if (_payTypeCounts.ContainsKey(qbPayType) &&  _payTypeCounts[qbPayType] == _depositConfig.getMaximum(qbPayType))
                return true;
            else
                return false;
        }

        public void addRefund(EaglesoftRefund refund)
        {
            RefundTypeMapping mapping = UserSettings.getInstance().Configuration.getRefundTypeByEaglesoftAdjustmentType(refund.AdjustmentType);
            DepositLine line = new DepositLine();
            line.Customer = mapping.Customer.Name;
            line.Amount = -refund.Amount;
            line.IncomeAccount = mapping.IncomeAccount.Name;
            line.PaymentMethod = mapping.QuickbooksPaytype.Name;
            line.Memo = refund.Description;
            _lines.Add(line);
        }

        public void addPayment(EaglesoftPayment p)
        {
            PaytypeMapping payType = UserSettings.getInstance().Configuration.getPayTypeByEaglesoftPayType(p.EaglesoftPayType);
            DepositLine line = new DepositLine();
            line.Amount = p.Amount;
            line.IncomeAccount = payType.IncomeAccount.Name;
            line.PaymentMethod = payType.QuickbooksPayType.Name;
            line.Customer = payType.Customer.Name;
            line.Memo = p.Description;
            line.CheckNumber = p.CheckNumber;
            _lines.Add(line);

            if (_payTypeCounts.ContainsKey(payType.QuickbooksPayType))
            {
                _payTypeCounts[payType.QuickbooksPayType] = _payTypeCounts[payType.QuickbooksPayType] + 1;
            }
            else
            {
                _payTypeCounts[payType.QuickbooksPayType] = 1;
            }
        }

        public Double DepositTotal() { 
            Double val = 0.0;
            foreach (DepositLine line in Lines) {
                val += line.Amount;
            }
            return val;
        }

        #region IComparable<Deposit> Members

        public int CompareTo(Deposit other)
        {
            // If same configuration, then we go with the value of the deposit.
            if (_depositConfig.CompareTo(other._depositConfig) == 0)
                return DepositTotal().CompareTo(other.DepositTotal());
            else
                return _depositConfig.CompareTo(other._depositConfig);
        }

        #endregion
    }
 }
