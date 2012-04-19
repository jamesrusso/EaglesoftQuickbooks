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
