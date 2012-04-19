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
