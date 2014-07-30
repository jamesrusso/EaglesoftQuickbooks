using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmDatabaseConnect : Form
    {
        public frmDatabaseConnect()
        {
            InitializeComponent();
        }

        private void frmDatabaseConnect_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add(new Binding("Text", this, "ConnectionString"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eaglesoft es = null;
            try
            {

                es = new Eaglesoft(textBox1.Text);
                es.Connect();
                MessageBox.Show("Connection successful!");

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to Eaglesoft");

            }
            finally
            {
                if (es != null)
                    es.Disconnect();
            }
        }

        public string ConnectionString { get; set; }
    }
}
