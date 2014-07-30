using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eaglesoft_Deposit.Model
{

    public class RefundTypeMappingDTO
    {
        public String EaglesoftAdjustment { get; set; }
        public Int32 EaglesoftAdjustmentId { get; set; }
        public String QuickbooksPaytype { get; set; }
        public String QuickbooksCustomer { get; set; }
        public String QuickbooksIncomeAccount { get; set; }
        public String QuickbooksRefundCheckBankAccount { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean IssueCheck { get; set; }
        public RefundCheckRecipient RefundCheckRecipient { get; set; }

        public Boolean EnableCheckField
        {
            get {
                return Enabled && IssueCheck;
            }
        }

        public Boolean EnableFromField
        {
            get
            {
                return Enabled && !IssueCheck;
            }
        }

        public Boolean EnableQuickbooksPayTypeField
        {
            get
            {
                return Enabled && !IssueCheck;
            }
        }

        public Boolean EnableBankAccountField
        {
            get
            {
                return Enabled && IssueCheck;
            }
        }

    }

}
