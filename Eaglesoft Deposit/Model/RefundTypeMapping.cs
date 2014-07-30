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
using System.Linq;
using System.Text;
using Eaglesoft_Deposit.Model;


namespace Eaglesoft_Deposit.Model
{
    public enum RefundCheckRecipient
    {
        ResposibleParty,
        InsuranceCompany
    }

    /**
     * This represents a refund type mapping. This will map an adjustment type on the Eaglesoft side to a pay type on the 
     * QB side.
     */
    public class RefundTypeMapping
    {
        public QuickbooksPaytype QuickbooksPaytype { get; set; }
        public EaglesoftAdjustmentType EaglesoftAdjustment { get; set; }
        public QuickbooksAccount IncomeAccount { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean IssueCheck { get; set; }
        public QuickbooksCustomer Customer { get; set; }
        public RefundCheckRecipient RefundCheckRecipient { get; set; }
        public QuickbooksAccount RefundCheckBankAccount { get; set; }
    }

}
