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
    public class Refund
    {
        private String _firstName;

        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private String _lastName;

        private String _patientId;

        public String PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }
            
        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private String _address1;

        public String Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        private String _address2;

        public String Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        private String _city;

        public String City
        {
            get { return _city; }
            set { _city = value; }
        }
        private String _zip;

        public String Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        private String _state;

        public String State
        {
            get { return _state; }
            set { _state = value; }
        }
        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private String _description;

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
