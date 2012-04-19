using System;
using System.Collections.Generic;
using System.Text;
using Interop.QBFC11;

namespace Eaglesoft_Deposit.Business_Objects
{
    /// <summary>
    /// This class represents a single deposit to be made to quickbooks. It will include 1 or more of payments.
    /// </summary>
    public class Deposit : IComparable<Deposit>
    {
        Dictionary<String, Int32> _payTypeCounts = new Dictionary<String, int>();
        Configuration.DepositConfig _depositConfig;
        List<DepositLine> _lines;

        public Configuration.DepositConfig DepositConfig
        {
            get { return _depositConfig; }
        } 

        public Deposit(Configuration.DepositConfig depositConfig)
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
         * 
         */
        public Boolean isFull(String qbPayType) 
        {
            if (_payTypeCounts.ContainsKey(qbPayType) &&  _payTypeCounts[qbPayType] == _depositConfig.getMaximum(qbPayType))
                return true;
            else
                return false;
        }

        public void addPayment(Payment p)
        {
            Configuration.PayType payType = UserSettings.getInstance().Configuration.getPayTypeByEaglesoftPayType(p.PayType);
            DepositLine line = new DepositLine(p);
            line.IncomeAccount = payType.IncomeAccount;
            line.PaymentMethod = payType.QuickbooksPayType;
            line.Customer = payType.Customer;
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
