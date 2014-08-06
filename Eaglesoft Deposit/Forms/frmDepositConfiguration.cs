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
using System.Windows.Forms;
using System.Linq;
using Eaglesoft_Deposit.Model;

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmDepositConfiguration : Form
    {
        Configuration _configuration = UserSettings.getInstance().Configuration;
        Dictionary<int, DepositConfiguration> rowMappings = new Dictionary<int, DepositConfiguration>();
        BindingList<DepositConfiguration> _depositConfigurations;

        public frmDepositConfiguration(List<DepositConfiguration> depositConfigurations)
        { 
            InitializeComponent();
            _depositConfigurations = new BindingList<DepositConfiguration>(depositConfigurations);
            depositConfigBindingSource.DataSource = _depositConfigurations;
        }

        /**
         * Return all PayTypes which belong to no deposit configurations. This is something which is on the quickbooks
         * side of the PayType, but that Paytype is contained in no deposit.
         * 
         */
        public List<QuickbooksPaytype> getUnconfiguredQuickbookPayTypes()
        {
            List<QuickbooksPaytype> allQuickBooksPayTypes = _configuration.PayTypeMappings.Select(payTypeMapping => payTypeMapping.QuickbooksPayType).ToList();
            List<DepositConfigPayType> configured = _depositConfigurations.SelectMany(x => x.QuickBooksPaymentTypes).ToList();
            List<QuickbooksPaytype> configuredQB = configured.Select(x => x.QuickbooksPaytype).ToList();
            
            return allQuickBooksPayTypes.Where(x => !configuredQB.Any(y => x.Equals(y))).ToList();
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            List<QuickbooksPaytype> availableQuickbooksPayTypes = getUnconfiguredQuickbookPayTypes();
            DepositConfiguration newConfig = new DepositConfiguration();
            frmDeposit frmDeposit = new frmDeposit(availableQuickbooksPayTypes, newConfig);
            
            if (availableQuickbooksPayTypes.Count == 0)
            {
                MessageBox.Show("All payment types are already configured, you must remove a payment type from an existing deposit first.");
                return;
            }

            if (frmDeposit.ShowDialog() == DialogResult.OK)
            {
                _depositConfigurations.Add(newConfig);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            DepositConfiguration selectedItem = dataGridView1.SelectedRows[0].DataBoundItem as DepositConfiguration;
            _depositConfigurations.Remove(selectedItem);
        }

        private void btnEditDeposit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            List<QuickbooksPaytype> availableQuickbooksPayTypes = getUnconfiguredQuickbookPayTypes();
            DepositConfiguration originalConfig = dataGridView1.SelectedRows[0].DataBoundItem as DepositConfiguration;
            DepositConfiguration editedConfig = originalConfig.Clone();
            frmDeposit frmDeposit = new frmDeposit(availableQuickbooksPayTypes, editedConfig);
            frmDeposit.Text = "Edit Deposit: " + originalConfig.Memo;
            if (frmDeposit.ShowDialog() == DialogResult.OK)
            {
                _depositConfigurations[_depositConfigurations.IndexOf(originalConfig)] = editedConfig;
                _depositConfigurations.ResetItem(_depositConfigurations.IndexOf(editedConfig));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                btnEditDeposit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEditDeposit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                btnDelete.Enabled = false;
                btnEditDeposit.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnEditDeposit.Enabled = true;
            }


            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.Count > 1)
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
            }
            else if (dataGridView1.SelectedRows[0].Index == 0)
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = true;
            }
            else if (dataGridView1.SelectedRows[0].Index == dataGridView1.Rows.Count - 1)
            {
                btnMoveUp.Enabled = true;
                btnMoveDown.Enabled = false;
            }
            else
            {
                btnMoveUp.Enabled = true;
                btnMoveDown.Enabled = true;
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            Int32 indexToMove = dataGridView1.SelectedRows[0].Index;

            if (indexToMove == 0)
                return;

            DepositConfiguration selectedConfig = _depositConfigurations[indexToMove];
            _depositConfigurations.RemoveAt(indexToMove);
            _depositConfigurations.Insert(indexToMove - 1, selectedConfig);
            dataGridView1.Rows[indexToMove - 1].Selected = true;
            _depositConfigurations.Select((config, index) => config.Order = index);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            Int32 indexToMove = dataGridView1.SelectedRows[0].Index;

            if (indexToMove == dataGridView1.Rows.Count)
                return;

            DepositConfiguration selectedConfig = _depositConfigurations[indexToMove];
            _depositConfigurations.RemoveAt(indexToMove);
            _depositConfigurations.Insert(indexToMove + 1, selectedConfig);
            dataGridView1.Rows[indexToMove + 1].Selected = true;
            _depositConfigurations.Select((config, index) => config.Order = index);
        }
    }
}
