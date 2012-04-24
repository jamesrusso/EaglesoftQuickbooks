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

namespace Eaglesoft_Deposit.Forms
{
    public partial class frmDepositConfiguration : Form
    {
        Configuration _configuration = UserSettings.getInstance().Configuration;
        Dictionary<int, Configuration.DepositConfig> rowMappings = new Dictionary<int, Configuration.DepositConfig>();
        BindingList<Configuration.DepositConfig> _depositConfigs;

        public frmDepositConfiguration()
        {
            InitializeComponent();
            columnMemo.DataPropertyName = "Memo";
            columnPayTypes.DataPropertyName = "PayTypeStrings";
            dataGridView1.AutoGenerateColumns = false;
            _configuration.Deposits.Sort();
            _depositConfigs = new BindingList<Configuration.DepositConfig>(_configuration.Deposits);
            dataGridView1.DataSource = _configuration.Deposits;
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            BindingList<String> list = _configuration.getUnconfiguredQuickbookPayTypes();
            Configuration.DepositConfig newConfig = new Configuration.DepositConfig();
            frmDeposit frmDeposit = new frmDeposit(list, newConfig);
            if (list.Count == 0)
            {
                MessageBox.Show("All payment types are already configured, you must remove a payment type from an existing deposit first.");
                return;
            }

            if (frmDeposit.ShowDialog() == DialogResult.OK)
            {
                _depositConfigs.Add(newConfig);
            }
        }

        private void editDeposit(Configuration.DepositConfig depositConfig)
        {
            BindingList<String> list = _configuration.getUnconfiguredQuickbookPayTypes();
            Configuration.DepositConfig config = dataGridView1.SelectedRows[0].DataBoundItem as Configuration.DepositConfig;
            Configuration.DepositConfig editedConfig = config.Clone();
            frmDeposit frmDeposit = new frmDeposit(list, editedConfig);
            frmDeposit.Text = "Edit Deposit: " + config.Memo;
            if (frmDeposit.ShowDialog() == DialogResult.OK)
            {

                _depositConfigs[_configuration.Deposits.IndexOf(config)] = editedConfig;
                _depositConfigs.ResetItem(_configuration.Deposits.IndexOf(editedConfig));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            Configuration.DepositConfig config = dataGridView1.SelectedRows[0].DataBoundItem as Configuration.DepositConfig;
            _configuration.Deposits.Remove(config);
        }

        private void btnEditDeposit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            editDeposit(dataGridView1.SelectedRows[0].DataBoundItem as Configuration.DepositConfig);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
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

            Configuration.DepositConfig config = _configuration.Deposits[indexToMove];
            _configuration.Deposits.Remove(config);
            _configuration.Deposits.Insert(indexToMove - 1, config);
            dataGridView1.Rows[indexToMove - 1].Selected = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ((Configuration.DepositConfig)row.DataBoundItem).Order = row.Index;
            }

        }


        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            Int32 indexToMove = dataGridView1.SelectedRows[0].Index;

            if (indexToMove == dataGridView1.Rows.Count)
                return;

            Configuration.DepositConfig config = _configuration.Deposits[indexToMove];
            _configuration.Deposits.Remove(config);
            _configuration.Deposits.Insert(indexToMove + 1, config);
            dataGridView1.Rows[indexToMove + 1].Selected = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ((Configuration.DepositConfig)row.DataBoundItem).Order = row.Index;
            }
        }

    }
}
