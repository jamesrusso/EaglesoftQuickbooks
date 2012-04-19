using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmDateSelect : Form
    {
        public DateTime SelectionDate
        {
            get { return monthCalendar1.SelectionStart; }
            set { monthCalendar1.SelectionStart = value; monthCalendar1.SelectionEnd = value; }
        } 

        public frmDateSelect()
        {
            InitializeComponent();
            monthCalendar1.MaxDate = DateTime.Now;
            monthCalendar1.SelectionStart = DateTime.Now;
        }
    }
}
