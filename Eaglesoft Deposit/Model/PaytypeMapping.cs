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
using System.ComponentModel;

namespace Eaglesoft_Deposit.Model
{
    /**
     * This class represents a paytype mapping. This contains the Eaglesoft payment type, the Quickbooks payment type, the income account
     * where the payment will be applied and finally the customer who will get credit for the payment in quickbooks.
     */
    public class PaytypeMapping
    {
        public QuickbooksPaytype QuickbooksPayType { get; set; }
        public EaglesoftPaymentType EaglesoftPaytype { get; set; }
        public QuickbooksAccount IncomeAccount { get; set; }
        public QuickbooksCustomer Customer { get; set; }
   }

}
