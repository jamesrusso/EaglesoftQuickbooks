using System;
using System.ComponentModel;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Eaglesoft_Deposit.Business_Objects;
using Eaglesoft_Deposit.Forms;

namespace Eaglesoft_Deposit
{
    public class EaglesoftDatabase
    {
        private List<String> _eaglesoftPaymentTypes;
        private OdbcConnection _odbcConnection;

        public EaglesoftDatabase()
        {
        }

        public void Connect()
        {
            if (_odbcConnection != null)
                if (_odbcConnection.State == System.Data.ConnectionState.Open)
                    return;
                else
                    _odbcConnection.Close();
            // fall through

            _odbcConnection = new OdbcConnection(UserSettings.getInstance().Configuration.DSN);
            _odbcConnection.Open();

        }

        public void Disconnect()
        {
            _odbcConnection.Close();
            _odbcConnection = null;
        }


        public List<string> GetEaglesoftPayTypes()
        {
            if (_eaglesoftPaymentTypes == null)
            {
                _eaglesoftPaymentTypes = new List<String>();
                OdbcCommand command = _odbcConnection.CreateCommand();

                command.CommandText = "select description from paytype";
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _eaglesoftPaymentTypes.Add((string)reader["description"]);
                }
                reader.Close();
            }

            return _eaglesoftPaymentTypes;
        }

      


        public List<ESAdjustmentType> getAdjustmentTypes()
        {
            List<ESAdjustmentType> list = new List<ESAdjustmentType>();
            OdbcCommand command = _odbcConnection.CreateCommand();

            command.CommandText = "select adjustment_type_id,description from adjustment_type";
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ESAdjustmentType((Int16)reader["adjustment_type_id"], (String)reader["description"]));
            }
            reader.Close();
            return list;
        }

      

       
    }
}