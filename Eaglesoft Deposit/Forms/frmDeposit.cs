using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmDeposit : Form
    {
        BindingList<String> _availableQuickBooksPaymentTypes;
        Configuration.DepositConfig _config;
        
        public class MaxValues
        {
            public MaxValues(int x, String s) { value = x; name = s; }
            Int32 value;
            String name;
            public String Name { get { return name; } }
            public Int32 Value { get { return value; } }
        }

         public frmDeposit(BindingList<String> availableQuickBooksPaymentTypes, Configuration.DepositConfig config)
        {
            InitializeComponent();
            
            if (config == null)
            {
                config = new Configuration.DepositConfig();
                Text = "Add New Deposit";
                btnOK.Text = "Save";
            }
            else
            {
                Text = "Edit " + config.Memo + " deposit.";
                btnOK.Text = "Save";
            }

            _config = config;
            _availableQuickBooksPaymentTypes = availableQuickBooksPaymentTypes;
            

            txtBoxMemo.DataBindings.Add(new Binding("Text", config, "Memo"));
            Quickbooks qb = new Quickbooks();
            qb.Connect();
            List<String> bankAccounts = qb.getBankAccounts();
            qb.Disconnect();

            comboDepositToAccount.DataSource = bankAccounts;
            comboDepositToAccount.DataBindings.Add(new Binding("SelectedItem", _config, "BankAccount",false));

            if (_config.BankAccount == null)
                _config.BankAccount = comboDepositToAccount.SelectedItem as String;

            if (_config.Memo == null)
                _config.Memo = txtBoxMemo.Text;

            if (_config == null)
            {
                _config = new Configuration.DepositConfig();
                _config.Memo = "New Deposit";
            }

            listBoxAvailablePaymentTypes.DataSource = _availableQuickBooksPaymentTypes;

            columnMaximum.Items.Add(new MaxValues(Int32.MaxValue,"(no maximum)"));
            List<MaxValues> maximumValueList = new List<MaxValues>();

            maximumValueList.Add(new MaxValues(Int32.MaxValue, "(no maximum)"));
             for (int i=1;i<=30;i++) 
                 maximumValueList.Add(new MaxValues(i,i.ToString()));

            columnMaximum.DataSource = maximumValueList;
            columnMaximum.DisplayMember = "Name";
            columnMaximum.ValueMember = "Value";
            columnMaximum.DataPropertyName = "Maximum";
            columnPayType.DataPropertyName = "quickBooksPayType";
            dataGridDeposit.AutoGenerateColumns = false;
            dataGridDeposit.DataSource = _config.PayTypes;
        }

        private void btnRemoveFromDeposit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selection = dataGridDeposit.SelectedRows;
            
            if (selection.Count == 0)
                return;

            for (int i = 0; i < selection.Count; i++)
            {
                Configuration.DepositConfigPayType configPayType =
                    selection[i].DataBoundItem as Configuration.DepositConfigPayType;

                _config.PayTypes.Remove(configPayType);

                _availableQuickBooksPaymentTypes.Add(configPayType.QuickBooksPayType);
            }
        }

        private void btnAddToDeposit_Click(object sender, EventArgs e)
        {
            if (listBoxAvailablePaymentTypes.SelectedItem == null)
                return;

            ListBox.SelectedIndexCollection collection =  
                listBoxAvailablePaymentTypes.SelectedIndices;
            
            int selCount = collection.Count;
            
            List<int> itemsToRemove = new List<int>();

            for (int i = collection.Count - 1; i >= 0; i--)
            {
                int index = collection[i];
                String payType = listBoxAvailablePaymentTypes.Items[index] as String;
                Configuration.DepositConfigPayType depositConfigPayType = new Configuration.DepositConfigPayType(payType, Int32.MaxValue);
                _config.PayTypes.Add(depositConfigPayType);
                itemsToRemove.Add(index);
            }

            foreach (int i in itemsToRemove)
            {
                _availableQuickBooksPaymentTypes.RemoveAt(i);
            }

        }
    }
}