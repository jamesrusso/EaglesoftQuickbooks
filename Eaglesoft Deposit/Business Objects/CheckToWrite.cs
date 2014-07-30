using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eaglesoft_Deposit.Model
{

    public class CheckToWrite
    {
        public String RecipientId { get; set; }
        public Double Amount { get; set; }
        public String FullName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String QbBankAccount { get; set; }
        public String QbIncomeAccount { get; set; }
        public String Memo { get; set; }
    }
}
