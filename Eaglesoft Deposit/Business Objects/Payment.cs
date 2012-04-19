using System;
using System.Collections.Generic;
using System.Text;

namespace Eaglesoft_Deposit.Business_Objects
{
    public class Payment 
    {
        private String _name;
        private String _descripion;
        private String _paytype;
        private Double _amount;
        private int _txnId;
        private String _CheckNumber;

        public int TxnId { get { return _txnId; } set { _txnId = value; } } 
        public String Name { get { return _name; } set { _name = value; } }
        public String Description { get { return _descripion; } set { _descripion = value; } }
        public String PayType { get { return _paytype; } set { _paytype = value; } }
        public String CheckNumber { get { return _CheckNumber; } set { _CheckNumber = value; } }
        public Double Amount { get { return _amount; } set { _amount = value; } }
    }

}
