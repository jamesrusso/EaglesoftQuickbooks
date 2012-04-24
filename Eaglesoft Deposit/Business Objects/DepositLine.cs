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

namespace Eaglesoft_Deposit.Business_Objects
{

    public class DepositLine
    {
        String _customer;
        String _paymentMethod;
        Double _amount;
        String _incomeAccount;
        String _memo;
        String _checkNumber;

        public String PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        public Double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public String IncomeAccount
        {
            get { return _incomeAccount; }
            set { _incomeAccount = value; }
        }
        
        public String Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
      
        public String CheckNumber
        {
            get { return _checkNumber; }
            set { _checkNumber = value; }
        }


        public String Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public DepositLine(Payment p)
        {
            _amount = p.Amount;
            _checkNumber = p.CheckNumber;
            _memo = p.Description;
        }
    }
}