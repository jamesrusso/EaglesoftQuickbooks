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
    public class DailyTransactionRange
    {
        DateTime _date;
        Int32 _fromTxn;
        Int32 _toTxn;

        public Int32 FromTxn
        {
            get { return _fromTxn; }
            set { _fromTxn = value; }
        }

        public Int32 ToTxn
        {
            get { return _toTxn; }
            set { _toTxn = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
