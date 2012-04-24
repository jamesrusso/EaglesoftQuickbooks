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
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Eaglesoft_Deposit.Business_Objects;

namespace Eaglesoft_Deposit
{
    public partial class frmRefundConfiguration : Form
    {
        List<ESAdjustmentType> _esAdjustmentTypes;
        BindingList<String> _qbIncomeAccounts;
        BindingList<String> _qbCheckingAccounts;

        public frmRefundConfiguration()
        {
            Configuration.RefundConfiguration _config = UserSettings.getInstance().RefundConfiguration;

            EaglesoftDatabase db = new EaglesoftDatabase();
            db.Connect();
            _esAdjustmentTypes = db.getAdjustmentTypes();
            db.Disconnect();

            Quickbooks qb = new Quickbooks();
            qb.Connect();
            _qbIncomeAccounts = new BindingList<string>(qb.getIncomeAccounts());
            _qbCheckingAccounts = new BindingList<string>(qb.getBankAccounts());
            qb.Disconnect();

            InitializeComponent();

            comboBoxQuickbooksIncomeAccount.DataSource = _qbIncomeAccounts;
            comboBoxEaglesoftAdjustmentTypes.DataSource = _esAdjustmentTypes;
            comboBoxEaglesoftAdjustmentTypes.DisplayMember = "description";
            comboBoxEaglesoftAdjustmentTypes.ValueMember = "id";
            
            if (_config.ESAdjustmentId == 0)
                _config.ESAdjustmentId = _esAdjustmentTypes[0].Id;

            comboBoxEaglesoftAdjustmentTypes.SelectedValue = _config.ESAdjustmentId;
          
            checkBoxRefundsEnabled.Checked = _config.Enabled;
            comboBoxEaglesoftAdjustmentTypes.Enabled = checkBoxRefundsEnabled.Checked;
            comboBoxQuickbooksCheckingAccount.DataSource = _qbCheckingAccounts;

            comboBoxQuickbooksCheckingAccount.SelectedText = _config.QBCheckingAccount;
            comboBoxQuickbooksCheckingAccount.Enabled = checkBoxRefundsEnabled.Checked;
            comboBoxQuickbooksIncomeAccount.Enabled = checkBoxRefundsEnabled.Checked;
            comboBoxEaglesoftAdjustmentTypes.Enabled = checkBoxRefundsEnabled.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Configuration.RefundConfiguration _config = UserSettings.getInstance().RefundConfiguration;
            _config.Enabled = checkBoxRefundsEnabled.Checked;
            _config.ESAdjustmentId = (Int16)comboBoxEaglesoftAdjustmentTypes.SelectedValue;
            _config.QBCheckingAccount = (String)comboBoxQuickbooksCheckingAccount.SelectedValue;
            _config.QBExpenseAccount = (String)comboBoxQuickbooksIncomeAccount.SelectedValue;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEaglesoftAdjustmentTypes.Enabled = checkBoxRefundsEnabled.Checked;
            comboBoxQuickbooksIncomeAccount.Enabled = checkBoxRefundsEnabled.Checked;
            comboBoxQuickbooksCheckingAccount.Enabled = checkBoxRefundsEnabled.Checked;
        }
    }
}