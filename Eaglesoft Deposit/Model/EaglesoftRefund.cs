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

namespace Eaglesoft_Deposit.Model
{
    public class EaglesoftRefund
    {
        public String PatientId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }

        public String InsuranceCompany_Name { get; set; }
        public String InsuranceCompany_Address1 { get; set; }
        public String InsuranceCompany_Address2 { get; set; }
        public String InsuranceCompany_City { get; set; }
        public String InsuranceCompany_State { get; set; }
        public String InsuranceCompany_Zip { get; set; }
        
        public Double Amount { get; set; }
        public String Description { get; set; }
        public EaglesoftAdjustmentType AdjustmentType { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1:c}", Description, Amount);
        }
    }
}
