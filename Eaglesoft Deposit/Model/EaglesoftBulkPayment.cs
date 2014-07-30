using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eaglesoft_Deposit.Model
{
    public class EaglesoftBulkPayment : EaglesoftPayment
    {
        public Int32 BulkPaymentId { get; set; }

        public override bool Equals(object obj)
        {
            EaglesoftBulkPayment payment = (obj as EaglesoftBulkPayment);
            return payment != null && payment.BulkPaymentId == BulkPaymentId;
        }
    }
}
