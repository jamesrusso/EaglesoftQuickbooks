using System;
using System.Collections.Generic;
using System.Text;

namespace Eaglesoft_Deposit.Business_Objects
{
    public class DailyTransactionRange
    {
        DateTime _date;
        Int32 _fromTxn;
        Int32 _toTxn;

        public Int32 FromTxn
        {
            get { return _fromTxn; }
            set { _fromTxn = value; }
        }

        public Int32 ToTxn
        {
            get { return _toTxn; }
            set { _toTxn = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
