namespace Eaglesoft_Deposit.Forms
{
    partial class frmDeposit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxAvailablePaymentTypes = new System.Windows.Forms.GroupBox();
            this.listBoxAvailablePaymentTypes = new System.Windows.Forms.ListBox();
            this.btnAddToDeposit = new System.Windows.Forms.Button();
            this.btnRemoveFromDeposit = new System.Windows.Forms.Button();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtBoxMemo = new System.Windows.Forms.TextBox();
            this.grpDeposit = new System.Windows.Forms.GroupBox();
            this.dataGridDeposit = new System.Windows.Forms.DataGridView();
            this.columnPayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMaximum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblDepositToAccount = new System.Windows.Forms.Label();
            this.comboDepositToAccount = new System.Windows.Forms.ComboBox();
            this.depositConfigPayTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpBoxAvailablePaymentTypes.SuspendLayout();
            this.grpDeposit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositConfigPayTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(474, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;

            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(393, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // 
            // grpBoxAvailablePaymentTypes
            // 
            this.grpBoxAvailablePaymentTypes.Controls.Add(this.listBoxAvailablePaymentTypes);
            this.grpBoxAvailablePaymentTypes.Location = new System.Drawing.Point(12, 64);
            this.grpBoxAvailablePaymentTypes.Name = "grpBoxAvailablePaymentTypes";
            this.grpBoxAvailablePaymentTypes.Size = new System.Drawing.Size(162, 179);
            this.grpBoxAvailablePaymentTypes.TabIndex = 3;
            this.grpBoxAvailablePaymentTypes.TabStop = false;
            this.grpBoxAvailablePaymentTypes.Text = "Available Payment Types";
            // 
            // listBoxAvailablePaymentTypes
            // 
            this.listBoxAvailablePaymentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAvailablePaymentTypes.FormattingEnabled = true;
            this.listBoxAvailablePaymentTypes.Location = new System.Drawing.Point(3, 16);
            this.listBoxAvailablePaymentTypes.Name = "listBoxAvailablePaymentTypes";
            this.listBoxAvailablePaymentTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxAvailablePaymentTypes.Size = new System.Drawing.Size(156, 160);
            this.listBoxAvailablePaymentTypes.TabIndex = 2;
            // 
            // btnAddToDeposit
            // 
            this.btnAddToDeposit.Location = new System.Drawing.Point(183, 125);
            this.btnAddToDeposit.Name = "btnAddToDeposit";
            this.btnAddToDeposit.Size = new System.Drawing.Size(75, 23);
            this.btnAddToDeposit.TabIndex = 3;
            this.btnAddToDeposit.Text = ">>";
            this.btnAddToDeposit.UseVisualStyleBackColor = true;
            this.btnAddToDeposit.Click += new System.EventHandler(this.btnAddToDeposit_Click);
            // 
            // btnRemoveFromDeposit
            // 
            this.btnRemoveFromDeposit.Location = new System.Drawing.Point(183, 154);
            this.btnRemoveFromDeposit.Name = "btnRemoveFromDeposit";
            this.btnRemoveFromDeposit.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFromDeposit.TabIndex = 4;
            this.btnRemoveFromDeposit.Text = "<<";
            this.btnRemoveFromDeposit.UseVisualStyleBackColor = true;
            this.btnRemoveFromDeposit.Click += new System.EventHandler(this.btnRemoveFromDeposit_Click);
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(37, 14);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(75, 13);
            this.lblMemo.TabIndex = 7;
            this.lblMemo.Text = "Deposit Memo";
            // 
            // txtBoxMemo
            // 
            this.txtBoxMemo.Location = new System.Drawing.Point(118, 11);
            this.txtBoxMemo.Name = "txtBoxMemo";
            this.txtBoxMemo.Size = new System.Drawing.Size(429, 20);
            this.txtBoxMemo.TabIndex = 0;
            // 
            // grpDeposit
            // 
            this.grpDeposit.Controls.Add(this.dataGridDeposit);
            this.grpDeposit.Location = new System.Drawing.Point(264, 64);
            this.grpDeposit.Name = "grpDeposit";
            this.grpDeposit.Size = new System.Drawing.Size(285, 179);
            this.grpDeposit.TabIndex = 10;
            this.grpDeposit.TabStop = false;
            this.grpDeposit.Text = "Payment Types in Deposit";
            // 
            // dataGridDeposit
            // 
            this.dataGridDeposit.AllowUserToAddRows = false;
            this.dataGridDeposit.AllowUserToDeleteRows = false;
            this.dataGridDeposit.AllowUserToResizeColumns = false;
            this.dataGridDeposit.AllowUserToResizeRows = false;
            this.dataGridDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPayType,
            this.columnMaximum});
            this.dataGridDeposit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDeposit.Location = new System.Drawing.Point(3, 16);
            this.dataGridDeposit.Name = "dataGridDeposit";
            this.dataGridDeposit.RowHeadersVisible = false;
            this.dataGridDeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDeposit.Size = new System.Drawing.Size(279, 160);
            this.dataGridDeposit.TabIndex = 5;
            // 
            // columnPayType
            // 
            this.columnPayType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPayType.FillWeight = 60F;
            this.columnPayType.HeaderText = "Pay Type";
            this.columnPayType.Name = "columnPayType";
            this.columnPayType.ReadOnly = true;
            this.columnPayType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // columnMaximum
            // 
            this.columnMaximum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnMaximum.FillWeight = 40F;
            this.columnMaximum.HeaderText = "Max Items";
            this.columnMaximum.Name = "columnMaximum";
            this.columnMaximum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnMaximum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblDepositToAccount
            // 
            this.lblDepositToAccount.AutoSize = true;
            this.lblDepositToAccount.Location = new System.Drawing.Point(10, 40);
            this.lblDepositToAccount.Name = "lblDepositToAccount";
            this.lblDepositToAccount.Size = new System.Drawing.Size(102, 13);
            this.lblDepositToAccount.TabIndex = 11;
            this.lblDepositToAccount.Text = "Deposit To Account";
            // 
            // comboDepositToAccount
            // 
            this.comboDepositToAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboDepositToAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDepositToAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepositToAccount.FormattingEnabled = true;
            this.comboDepositToAccount.Location = new System.Drawing.Point(118, 37);
            this.comboDepositToAccount.Name = "comboDepositToAccount";
            this.comboDepositToAccount.Size = new System.Drawing.Size(259, 21);
            this.comboDepositToAccount.TabIndex = 1;
            // 
            // depositConfigPayTypesBindingSource
            // 
            this.depositConfigPayTypesBindingSource.DataSource = typeof(Eaglesoft_Deposit.Configuration.DepositConfigPayType);
            // 
            // frmDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 279);
            this.ControlBox = false;
            this.Controls.Add(this.comboDepositToAccount);
            this.Controls.Add(this.lblDepositToAccount);
            this.Controls.Add(this.grpDeposit);
            this.Controls.Add(this.txtBoxMemo);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.btnRemoveFromDeposit);
            this.Controls.Add(this.btnAddToDeposit);
            this.Controls.Add(this.grpBoxAvailablePaymentTypes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDeposit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Deposit";
            this.grpBoxAvailablePaymentTypes.ResumeLayout(false);
            this.grpDeposit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositConfigPayTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpBoxAvailablePaymentTypes;
        private System.Windows.Forms.ListBox listBoxAvailablePaymentTypes;
        private System.Windows.Forms.Button btnAddToDeposit;
        private System.Windows.Forms.Button btnRemoveFromDeposit;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtBoxMemo;
        private System.Windows.Forms.GroupBox grpDeposit;
        private System.Windows.Forms.DataGridView dataGridDeposit;
        private System.Windows.Forms.BindingSource depositConfigPayTypesBindingSource;
        private System.Windows.Forms.Label lblDepositToAccount;
        private System.Windows.Forms.ComboBox comboDepositToAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPayType;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnMaximum;
    }
}