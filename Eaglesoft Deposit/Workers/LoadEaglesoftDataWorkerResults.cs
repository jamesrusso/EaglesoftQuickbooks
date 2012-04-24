/*
 * Copyright 2007-2012 Halo3 Consulting, LLC
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *     
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

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
