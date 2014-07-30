using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eaglesoft_Deposit.Model
{
    public class PaytypeMappingDTO
    {
        public String EaglesoftPaytype { get; set;}
        public Int32 EaglesoftPaytypeId { get; set; }
        public String QuickbooksPaytype { get; set; }
        public String QuickbooksCustomer { get; set; }
        public String QuickbooksAccount { get; set; }
    }
}
