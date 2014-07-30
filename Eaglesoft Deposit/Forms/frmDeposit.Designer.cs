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
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtBoxMemo = new System.Windows.Forms.TextBox();
            this.lblDepositToAccount = new System.Windows.Forms.Label();
            this.comboDepositToAccount = new System.Windows.Forms.ComboBox();
            this.depositConfigPayTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridDeposit = new System.Windows.Forms.DataGridView();
            this.columnPaytype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMaximum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxAvailablePaymentTypes = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.depositConfigPayTypesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeposit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(561, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(36, 12);
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
            // lblDepositToAccount
            // 
            this.lblDepositToAccount.AutoSize = true;
            this.lblDepositToAccount.Location = new System.Drawing.Point(12, 38);
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
            this.comboDepositToAccount.Size = new System.Drawing.Size(218, 21);
            this.comboDepositToAccount.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridDeposit);
            this.groupBox1.Location = new System.Drawing.Point(354, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 179);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Types in Deposit";
            // 
            // dataGridDeposit
            // 
            this.dataGridDeposit.AllowUserToAddRows = false;
            this.dataGridDeposit.AllowUserToDeleteRows = false;
            this.dataGridDeposit.AllowUserToResizeColumns = false;
            this.dataGridDeposit.AllowUserToResizeRows = false;
            this.dataGridDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPaytype,
            this.columnMaximum});
            this.dataGridDeposit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDeposit.Location = new System.Drawing.Point(3, 16);
            this.dataGridDeposit.Name = "dataGridDeposit";
            this.dataGridDeposit.RowHeadersVisible = false;
            this.dataGridDeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDeposit.Size = new System.Drawing.Size(279, 160);
            this.dataGridDeposit.TabIndex = 5;
            // 
            // columnPaytype
            // 
            this.columnPaytype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPaytype.FillWeight = 60F;
            this.columnPaytype.HeaderText = "Pay Type";
            this.columnPaytype.Name = "columnPaytype";
            this.columnPaytype.ReadOnly = true;
            this.columnPaytype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRemoveFromDeposit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnAddToDeposit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxAvailablePaymentTypes);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 179);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Payment Types";
            // 
            // listBoxAvailablePaymentTypes
            // 
            this.listBoxAvailablePaymentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAvailablePaymentTypes.FormattingEnabled = true;
            this.listBoxAvailablePaymentTypes.Location = new System.Drawing.Point(3, 16);
            this.listBoxAvailablePaymentTypes.Name = "listBoxAvailablePaymentTypes";
            this.listBoxAvailablePaymentTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxAvailablePaymentTypes.Size = new System.Drawing.Size(240, 160);
            this.listBoxAvailablePaymentTypes.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(480, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmDeposit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(653, 332);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboDepositToAccount);
            this.Controls.Add(this.lblDepositToAccount);
            this.Controls.Add(this.txtBoxMemo);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDeposit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Deposit";
            ((System.ComponentModel.ISupportInitialize)(this.depositConfigPayTypesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDeposit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtBoxMemo;
        private System.Windows.Forms.BindingSource depositConfigPayTypesBindingSource;
        private System.Windows.Forms.Label lblDepositToAccount;
        private System.Windows.Forms.ComboBox comboDepositToAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridDeposit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxAvailablePaymentTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPaytype;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnMaximum;
        private System.Windows.Forms.Button btnCancel;
    }
}