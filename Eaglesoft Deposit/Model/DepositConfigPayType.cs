using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eaglesoft_Deposit.Model
{
    /**
     * Small wrapper class to specify what is the maximum number of times
     * this PayType can be included in the DepositConfiguration.
     * 
     * Ex: Checks can only be included 18 times on a normal deposit ticket.
     */
    public class DepositConfigPayType
    {
        public Int32 Maximum { get; set; }
        public QuickbooksPaytype QuickbooksPaytype { get; set; }
        
        public String DisplayValue { get { 
                return QuickbooksPaytype != null ? QuickbooksPaytype.Name : null; } 
        }
        
        public DepositConfigPayType Clone()
        {
            return new DepositConfigPayType()
            {
                Maximum = this.Maximum,
                QuickbooksPaytype = new QuickbooksPaytype() { Name = this.QuickbooksPaytype.Name }
            };
        }
    }

}
