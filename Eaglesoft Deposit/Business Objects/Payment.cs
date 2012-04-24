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
    public class Payment 
    {
        private String _name;
        private String _descripion;
        private String _paytype;
        private Double _amount;
        private int _txnId;
        private String _CheckNumber;

        public int TxnId { get { return _txnId; } set { _txnId = value; } } 
        public String Name { get { return _name; } set { _name = value; } }
        public String Description { get { return _descripion; } set { _descripion = value; } }
        public String PayType { get { return _paytype; } set { _paytype = value; } }
        public String CheckNumber { get { return _CheckNumber; } set { _CheckNumber = value; } }
        public Double Amount { get { return _amount; } set { _amount = value; } }
    }

}
