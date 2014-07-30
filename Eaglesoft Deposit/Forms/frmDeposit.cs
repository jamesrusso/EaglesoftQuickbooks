using Eaglesoft_Deposit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmDeposit : Form
    {
        private DepositConfiguration _depositconfiguration;

        private BindingList<QuickbooksPaytype> _availableQuickbooksPaymentTypes;
        private BindingList<DepositConfigPayType> _depositConfigPayTypes;
        private Configuration config;

        public class MaxValues
        {
            public MaxValues(int x, String s) { value = x; name = s; }
            Int32 value;
            String name;
            public String Name { get { return name; } }
            public Int32 Value { get { return value; } }
        }

        public frmDeposit(List<QuickbooksPaytype> availableQuickBooksPaymentTypes, DepositConfiguration depositconfig)
        {
            config = UserSettings.getInstance().Configuration;

            InitializeComponent();

            _depositconfiguration = depositconfig;
            _depositConfigPayTypes = new BindingList<DepositConfigPayType>(_depositconfiguration.QuickBooksPaymentTypes);

            txtBoxMemo.DataBindings.Add(new Binding("Text", depositconfig, "Memo"));

            comboDepositToAccount.DataSource = config.QuickbooksBankAccounts;
            comboDepositToAccount.DisplayMember = "Name";
            comboDepositToAccount.DataBindings.Add(new Binding("SelectedItem", _depositconfiguration, "BankAccount", false));

            if (_depositconfiguration.BankAccount == null)
                _depositconfiguration.BankAccount = comboDepositToAccount.SelectedItem as QuickbooksAccount;

            if (_depositconfiguration.Memo == null)
                _depositconfiguration.Memo = txtBoxMemo.Text;

            if (_depositconfiguration == null)
            {
                _depositconfiguration = new DepositConfiguration();
                _depositconfiguration.Memo = "New Deposit";
            }

            _availableQuickbooksPaymentTypes = new BindingList<QuickbooksPaytype>(availableQuickBooksPaymentTypes);
            listBoxAvailablePaymentTypes.DataSource = _availableQuickbooksPaymentTypes;
            listBoxAvailablePaymentTypes.DisplayMember = "Name";

            columnMaximum.Items.Add(new MaxValues(Int32.MaxValue, "(no maximum)"));
            List<MaxValues> maximumValueList = new List<MaxValues>();

            maximumValueList.Add(new MaxValues(Int32.MaxValue, "(no maximum)"));
            for (int i = 1; i <= 30; i++)
                maximumValueList.Add(new MaxValues(i, i.ToString()));

            columnMaximum.DataSource = maximumValueList;
            columnMaximum.DisplayMember = "Name";
            columnMaximum.ValueMember = "Value";
            columnMaximum.DataPropertyName = "Maximum";


            columnPaytype.DataPropertyName = "DisplayValue";
            dataGridDeposit.AutoGenerateColumns = false;

            dataGridDeposit.DataSource = _depositConfigPayTypes;
        }

        private void btnRemoveFromDeposit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selection = dataGridDeposit.SelectedRows;

            if (selection.Count == 0)
                return;

            for (int i = 0; i < selection.Count; i++)
            {
                DepositConfigPayType configPayType =
                    selection[i].DataBoundItem as DepositConfigPayType;

                _depositConfigPayTypes.Remove(configPayType);
                _availableQuickbooksPaymentTypes.Add(configPayType.QuickbooksPaytype);
            }
        }

        private void btnAddToDeposit_Click(object sender, EventArgs e)
        {

            ListBox.SelectedObjectCollection selection = listBoxAvailablePaymentTypes.SelectedItems;

            if (selection.Count == 0)
                return;

            List<QuickbooksPaytype> itemsToRemove = new List<QuickbooksPaytype>();

            for (int i = 0; i < selection.Count; i++)
            {
                QuickbooksPaytype qbPayType = selection[i] as QuickbooksPaytype;
                DepositConfigPayType depositConfigPayType = new DepositConfigPayType() { QuickbooksPaytype = qbPayType, Maximum = Int32.MaxValue };
                _depositConfigPayTypes.Add(depositConfigPayType);
                itemsToRemove.Add(qbPayType);
            }

            foreach (QuickbooksPaytype qbPayType in itemsToRemove)
            {
                _availableQuickbooksPaymentTypes.Remove(qbPayType);
            }
        }

    }
}