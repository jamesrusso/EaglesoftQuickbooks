using System;
using System.Collections.Generic;
using System.Text;
using Eaglesoft_Deposit.Business_Objects;

namespace Eaglesoft_Deposit.Workers
{
    public class LoadEaglesoftDataWorkerResults
    {
        public DailyDeposit Deposit;
        public List<Refund> Refunds;
        public LoadEaglesoftDataWorkerResults(DailyDeposit deposit, List<Refund> refunds)
        {
            this.Deposit = deposit;
            this.Refunds = refunds;
        }
    }
}
