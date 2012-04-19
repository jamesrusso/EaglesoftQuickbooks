using System;
using System.Collections.Generic;
using System.Text;

namespace Eaglesoft_Deposit.Business_Objects
{
    public class ESAdjustmentType
    {
        private Int16 _id;
        private String _description;
        public Int16 Id { get { return _id; }}
        public String Description { get { return _description; } }

        public ESAdjustmentType(Int16 id, String description)
        {
            _id = id;
            _description = description;
        }
        
    }
}
