using System;
using System.Collections.Generic;
using System.Text;

namespace Eaglesoft_Deposit.Business_Objects
{

    public class DepositLine
    {
        String _customer;
        String _paymentMethod;
        Double _amount;
        String _incomeAccount;
        String _memo;
        String _checkNumber;

        public String PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        public Double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public String IncomeAccount
        {
            get { return _incomeAccount; }
            set { _incomeAccount = value; }
        }
        
        public String Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
      
        public String CheckNumber
        {
            get { return _checkNumber; }
            set { _checkNumber = value; }
        }


        public String Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public DepositLine(Payment p)
        {
            _amount = p.Amount;
            _checkNumber = p.CheckNumber;
            _memo = p.Description;
        }
    }
}