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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit
{
    public partial class frmRefundTypeMappings : Form
    {
        public frmRefundTypeMappings(IList<RefundTypeMappingDTO> refundMappingTypeDTOs)
        {
            InitializeComponent();

    
            checkBoxIssueRefundCheck.DataBindings.Add(new Binding("Checked", refundTypeMappingDTOBindingSource, "IssueCheck", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBoxEnabled.DataBindings.Add(new Binding("Checked", refundTypeMappingDTOBindingSource, "Enabled", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBoxIssueRefundCheck.DataBindings.Add(new Binding("Enabled", refundTypeMappingDTOBindingSource, "Enabled", true, DataSourceUpdateMode.OnPropertyChanged));
            
            comboBoxCheckRecipient.DataBindings.Add(new Binding("Enabled", refundTypeMappingDTOBindingSource, "EnableCheckField", true, DataSourceUpdateMode.OnPropertyChanged));
            comboBoxCheckRecipient.DataBindings.Add(new Binding("SelectedItem", refundTypeMappingDTOBindingSource, "RefundCheckRecipient"));
           
            comboBoxQBFrom.DataBindings.Add(new Binding("Enabled", refundTypeMappingDTOBindingSource, "EnableFromField", true, DataSourceUpdateMode.OnPropertyChanged));
            comboBoxQBPaymentType.DataBindings.Add(new Binding("Enabled", refundTypeMappingDTOBindingSource, "EnableQuickbooksPayTypeField", true, DataSourceUpdateMode.OnPropertyChanged));
            comboBoxQBIncomeAccount.DataBindings.Add(new Binding("Enabled", refundTypeMappingDTOBindingSource, "Enabled", true, DataSourceUpdateMode.OnPropertyChanged));
            comboBoxRefundBankAccount.DataBindings.Add(new Binding("Enabled", refundTypeMappingDTOBindingSource, "EnableBankAccountField", true, DataSourceUpdateMode.OnPropertyChanged));

            comboBoxCheckRecipient.DataSource = Enum.GetValues(typeof(RefundCheckRecipient));

            Configuration configuration = UserSettings.getInstance().Configuration;
            quickbooksPaytypeBindingSource.DataSource = configuration.QuickbooksPaytypes;
            quickbooksCustomerBindingSource.DataSource = configuration.QuickbooksCustomers;
            quickbooksIncomeAccountBindingSource.DataSource = configuration.QuickbooksIncomeAccounts;
            quickbooksBankAccountBindingSource.DataSource = configuration.QuickbooksBankAccounts;
            refundTypeMappingDTOBindingSource.DataSource = refundMappingTypeDTOs.OrderBy(x => x.EaglesoftAdjustment);

        }
    }
}