using System;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Eaglesoft_Deposit
{
    [Serializable]
    public class Configuration
    {

        private List<DateTime> _datesRun;
        private String _dsn;
        private Boolean initialConfigurationComplete;

        public Boolean InitialConfigurationComplete
        {
            get { return initialConfigurationComplete; }
            set { initialConfigurationComplete = value; }
        } 


        public String DSN
        {
            get { return _dsn; }
            set { _dsn = value; }
        }

        public List<DateTime> DatesRun
        {
            get { return _datesRun; }
            set { _datesRun = value; }
        }

        /**
         * This class represents a paytype mapping. This contains the Eaglesoft Payment Type, the Quickbooks Payments type, the income account
         * where the payment will be applied and finally the From customer who will get credit for the payment in quickbooks.
         */
        public class PayType
        {
            private String _quickbooksPayType;
            private String _eaglesoftPaytype;
            private String _IncomeAccount;
            private String _customer;

            public PayType()
            {
            }

            public String QuickbooksPayType
            {
                get { return _quickbooksPayType; }
                set { _quickbooksPayType = value; }
            }

            public String EaglesoftPayType
            {
                get { return _eaglesoftPaytype; }
                set { _eaglesoftPaytype = value; }
            }

            public String IncomeAccount
            {
                get { return _IncomeAccount; }
                set { _IncomeAccount = value; }
            }

            public String Customer
            {
                get { return _customer; }
                set { _customer = value; }
            }
        }

        /**
         * Small wrapper class to specify what is the maximum number of times
         * this PayType can be included in the DepositConfiguration.
         * 
         * Ex: Checks can only be included 18 times on a normal deposit ticket. 
         */
        public class DepositConfigPayType
        {
            private Int32 _maximum;
            private String _quickBooksPayType;

            public DepositConfigPayType() { }

            public DepositConfigPayType(String quickbooksPayType, Int32 maximum)
            {
                QuickBooksPayType = quickbooksPayType;
                Maximum =  maximum;
            }

            public String QuickBooksPayType
            {
                get { return _quickBooksPayType; }
                set { _quickBooksPayType = value; }
            }

            public int Maximum
            {
                get { return _maximum; }
                set { _maximum = value; }
            }
        }
        
        /**
         * This represents a deposit which will be made into quickbooks. This deposit
         * will include 1 or more payment types.
         */
        public class DepositConfig : IComparable<DepositConfig>
        {
            private String _Memo;
            private String _BankAccount;
            private Int32 _Order;

            public Int32 Order
            {
                get { return _Order; }
                set { _Order = value; }
            }
            private BindingList<DepositConfigPayType> _payTypes;

            public DepositConfig()
            {
                _payTypes = new BindingList<DepositConfigPayType>();
                Order = 0;
            }

            public BindingList<DepositConfigPayType> PayTypes
            {
                get { return _payTypes; }
            }

            public String Memo
            {
                get { return _Memo; }
                set { _Memo = value; }
            }

            public String PayTypeStrings
            {
                get
                {
                    List<String> s = new List<string>();
                    foreach (Configuration.DepositConfigPayType payType in _payTypes)
                    {
                        if (payType.Maximum == Int32.MaxValue)
                            s.Add(payType.QuickBooksPayType);
                        else
                            s.Add(payType.QuickBooksPayType + " (max " + payType.Maximum + ")");
                    }

                    if (s.Count == 0)
                        return "<None>";
                    return String.Join(", ", s.ToArray());
                }
            }

            public String BankAccount
            {
                get { return _BankAccount; }
                set { _BankAccount = value; }
            }

            public Int32 getMaximum(String qbPaymentType)
            {
                foreach (Configuration.DepositConfigPayType payType in PayTypes)
                {
                    if (payType.QuickBooksPayType.Equals(qbPaymentType))
                        return payType.Maximum;
                }

                throw new Exception(String.Format("{0} is not contained in this deposit configuration", qbPaymentType));
            }

            public DepositConfig Clone()
            {
                DepositConfig newConfig = MemberwiseClone() as DepositConfig;
                newConfig._payTypes = new BindingList<DepositConfigPayType>();
                foreach (DepositConfigPayType p in _payTypes)
                    newConfig._payTypes.Add(p);
                return newConfig;
            }

            #region IComparable<DepositConfig> Members

            public int CompareTo(DepositConfig other)
            {
                return Order.CompareTo(other.Order);
            }

            #endregion
        }
        
        public class RefundConfiguration
        {
            private Boolean _refundsEnabled;
            public Boolean Enabled { get { return _refundsEnabled; } set { _refundsEnabled = value; } }
            private Int16 _ESAdjustmentId;
            private String _QBExpenseAccount;
            
            private String _QBCheckingAccount;

            public String QBExpenseAccount { get { return _QBExpenseAccount; } set { _QBExpenseAccount = value; } }
            public Int16 ESAdjustmentId { get { return _ESAdjustmentId; } set { _ESAdjustmentId = value; } }
            
            public String QBCheckingAccount { get { return _QBCheckingAccount; } set { _QBCheckingAccount = value; } }
        }

        private DateTime _lastTimeRun;
        private BindingList<PayType> _payTypes;
        private List<DepositConfig> _deposits;
        

        public DateTime LastTimeRun
        {
            get { return _lastTimeRun; }
            set { _lastTimeRun = value; }
        }
        public List<DepositConfig> Deposits { get { return _deposits; } }
        public BindingList<PayType> PayTypes { get { return _payTypes; } }

        public Configuration()
        {
            _deposits = new List<DepositConfig>();
            _datesRun = new List<DateTime>();
            _payTypes = new BindingList<PayType>();
            InitialConfigurationComplete = false;
        }

        public DepositConfig getDepositConfig(String qbPayType)
        {
            foreach (DepositConfig config in Deposits)
            {
                foreach (DepositConfigPayType payType in config.PayTypes)
                {
                    if (payType.QuickBooksPayType.Equals(qbPayType))
                        return config;
                }
            }

            return null;
        }

        public void refreshPaymentTypes(List<String> eaglesoftPayTypes)
        {
            Boolean found = false;
            foreach (String s in eaglesoftPayTypes)
            {
                foreach (PayType p in _payTypes)
                {
                    if (s.Equals(p.EaglesoftPayType))
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    PayType t = new PayType();
                    t.EaglesoftPayType = s;
                    t.Customer = null;
                    t.IncomeAccount = null;
                    t.QuickbooksPayType = null;
                    PayTypes.Add(t);
                }
            }
        }
        /**
         * Return all PayTypes which belong to no deposit configurations. This is something which is on the quickbooks
         * side of the PayType, but that Paytype behonds in No Desposit. 
         * 
         */
        public BindingList<String> getUnconfiguredQuickbookPayTypes()
        {
            BindingList<String> unConfiguredPayTypes = new BindingList<String>();
            foreach (PayType payType in PayTypes)
            {
                Boolean found = false;
                foreach (DepositConfig depositConfig in Deposits)
                {
                    foreach (DepositConfigPayType depositPayType in depositConfig.PayTypes)
                    {
                        if (payType.QuickbooksPayType.Equals(depositPayType.QuickBooksPayType))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == true)
                        break;
                }

                if (found == false && unConfiguredPayTypes.Contains(payType.QuickbooksPayType) == false)
                    unConfiguredPayTypes.Add(payType.QuickbooksPayType);
            }

            return unConfiguredPayTypes;
        }

        internal PayType getPayTypeByEaglesoftPayType(string esPayType)
        {
            foreach (PayType p in PayTypes)
            {
                if (p.EaglesoftPayType.Equals(esPayType))
                    return p;
            }

            return null;
        }


    }         
}
