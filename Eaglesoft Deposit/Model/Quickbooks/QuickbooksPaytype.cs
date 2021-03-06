﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eaglesoft_Deposit.Model
{
    public class QuickbooksPaytype
    {
        public String Name { get; set; }

        public override string ToString()
        {
            return String.Format("{0}", Name);
        }

        public override bool Equals(object obj)
        {
            QuickbooksPaytype that = obj as QuickbooksPaytype;

            if (that == null)
                return false;

            return this.Name.Equals(that.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        
    }
}
