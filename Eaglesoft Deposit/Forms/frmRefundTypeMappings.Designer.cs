namespace Eaglesoft_Deposit
{
    partial class frmRefundTypeMappings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefundTypeMappings));
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxRefundBankAccount = new System.Windows.Forms.ComboBox();
            this.refundTypeMappingDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quickbooksBankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quickbooksIncomeAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.comboBoxCheckRecipient = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxQBIncomeAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxIssueRefundCheck = new System.Windows.Forms.CheckBox();
            this.comboBoxQBFrom = new System.Windows.Forms.ComboBox();
            this.quickbooksCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxQBPaymentType = new System.Windows.Forms.ComboBox();
            this.quickbooksPaytypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxEaglesoftAdjustmentTypes = new System.Windows.Forms.ListBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refundTypeMappingDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksBankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksIncomeAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksPaytypeBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(397, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxRefundBankAccount);
            this.groupBox3.Controls.Add(this.lblBankAccount);
            this.groupBox3.Controls.Add(this.comboBoxCheckRecipient);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxQBIncomeAccount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.checkBoxEnabled);
            this.groupBox3.Controls.Add(this.checkBoxIssueRefundCheck);
            this.groupBox3.Controls.Add(this.comboBoxQBFrom);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBoxQBPaymentType);
            this.groupBox3.Location = new System.Drawing.Point(210, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 200);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quickbooks";
            // 
            // comboBoxRefundBankAccount
            // 
            this.comboBoxRefundBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxRefundBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRefundBankAccount.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refundTypeMappingDTOBindingSource, "QuickbooksRefundCheckBankAccount", true));
            this.comboBoxRefundBankAccount.DataSource = this.quickbooksBankAccountBindingSource;
            this.comboBoxRefundBankAccount.DisplayMember = "Name";
            this.comboBoxRefundBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRefundBankAccount.FormattingEnabled = true;
            this.comboBoxRefundBankAccount.Location = new System.Drawing.Point(99, 169);
            this.comboBoxRefundBankAccount.Name = "comboBoxRefundBankAccount";
            this.comboBoxRefundBankAccount.Size = new System.Drawing.Size(157, 21);
            this.comboBoxRefundBankAccount.TabIndex = 15;
            this.comboBoxRefundBankAccount.ValueMember = "Name";
            // 
            // refundTypeMappingDTOBindingSource
            // 
            this.refundTypeMappingDTOBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.RefundTypeMappingDTO);
            this.refundTypeMappingDTOBindingSource.Filter = " ";
            this.refundTypeMappingDTOBindingSource.Sort = "EaglesoftAdjustment DESC";
            // 
            // quickbooksBankAccountBindingSource
            // 
            this.quickbooksBankAccountBindingSource.DataSource = this.quickbooksIncomeAccountBindingSource;
            // 
            // quickbooksIncomeAccountBindingSource
            // 
            this.quickbooksIncomeAccountBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.QuickbooksAccount);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(18, 172);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(75, 13);
            this.lblBankAccount.TabIndex = 14;
            this.lblBankAccount.Text = "Bank Account";
            // 
            // comboBoxCheckRecipient
            // 
            this.comboBoxCheckRecipient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCheckRecipient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCheckRecipient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheckRecipient.FormattingEnabled = true;
            this.comboBoxCheckRecipient.Location = new System.Drawing.Point(99, 142);
            this.comboBoxCheckRecipient.Name = "comboBoxCheckRecipient";
            this.comboBoxCheckRecipient.Size = new System.Drawing.Size(157, 21);
            this.comboBoxCheckRecipient.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Check Recipient";
            // 
            // comboBoxQBIncomeAccount
            // 
            this.comboBoxQBIncomeAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxQBIncomeAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxQBIncomeAccount.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refundTypeMappingDTOBindingSource, "QuickbooksIncomeAccount", true));
            this.comboBoxQBIncomeAccount.DataSource = this.quickbooksIncomeAccountBindingSource;
            this.comboBoxQBIncomeAccount.DisplayMember = "Name";
            this.comboBoxQBIncomeAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQBIncomeAccount.FormattingEnabled = true;
            this.comboBoxQBIncomeAccount.Location = new System.Drawing.Point(99, 112);
            this.comboBoxQBIncomeAccount.Name = "comboBoxQBIncomeAccount";
            this.comboBoxQBIncomeAccount.Size = new System.Drawing.Size(157, 21);
            this.comboBoxQBIncomeAccount.TabIndex = 11;
            this.comboBoxQBIncomeAccount.ValueMember = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Income Account";
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEnabled.Location = new System.Drawing.Point(99, 19);
            this.checkBoxEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(137, 17);
            this.checkBoxEnabled.TabIndex = 4;
            this.checkBoxEnabled.Text = "Enable Refund Support";
            this.checkBoxEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxIssueRefundCheck
            // 
            this.checkBoxIssueRefundCheck.AutoSize = true;
            this.checkBoxIssueRefundCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIssueRefundCheck.Location = new System.Drawing.Point(99, 38);
            this.checkBoxIssueRefundCheck.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxIssueRefundCheck.Name = "checkBoxIssueRefundCheck";
            this.checkBoxIssueRefundCheck.Size = new System.Drawing.Size(123, 17);
            this.checkBoxIssueRefundCheck.TabIndex = 5;
            this.checkBoxIssueRefundCheck.Text = "Issue Refund Check";
            this.checkBoxIssueRefundCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIssueRefundCheck.UseVisualStyleBackColor = true;
            // 
            // comboBoxQBFrom
            // 
            this.comboBoxQBFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxQBFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxQBFrom.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refundTypeMappingDTOBindingSource, "QuickbooksCustomer", true));
            this.comboBoxQBFrom.DataSource = this.quickbooksCustomerBindingSource;
            this.comboBoxQBFrom.DisplayMember = "Name";
            this.comboBoxQBFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQBFrom.FormattingEnabled = true;
            this.comboBoxQBFrom.Location = new System.Drawing.Point(99, 85);
            this.comboBoxQBFrom.Name = "comboBoxQBFrom";
            this.comboBoxQBFrom.Size = new System.Drawing.Size(157, 21);
            this.comboBoxQBFrom.TabIndex = 9;
            this.comboBoxQBFrom.ValueMember = "Name";
            // 
            // quickbooksCustomerBindingSource
            // 
            this.quickbooksCustomerBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.QuickbooksCustomer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Payment Type";
            // 
            // comboBoxQBPaymentType
            // 
            this.comboBoxQBPaymentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxQBPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxQBPaymentType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.refundTypeMappingDTOBindingSource, "QuickbooksPaytype", true));
            this.comboBoxQBPaymentType.DataSource = this.quickbooksPaytypeBindingSource;
            this.comboBoxQBPaymentType.DisplayMember = "Name";
            this.comboBoxQBPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQBPaymentType.FormattingEnabled = true;
            this.comboBoxQBPaymentType.Location = new System.Drawing.Point(99, 58);
            this.comboBoxQBPaymentType.Name = "comboBoxQBPaymentType";
            this.comboBoxQBPaymentType.Size = new System.Drawing.Size(157, 21);
            this.comboBoxQBPaymentType.TabIndex = 7;
            this.comboBoxQBPaymentType.ValueMember = "Name";
            // 
            // quickbooksPaytypeBindingSource
            // 
            this.quickbooksPaytypeBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.QuickbooksPaytype);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxEaglesoftAdjustmentTypes);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 200);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Eaglesoft Adjustment Types";
            // 
            // listBoxEaglesoftAdjustmentTypes
            // 
            this.listBoxEaglesoftAdjustmentTypes.DataSource = this.refundTypeMappingDTOBindingSource;
            this.listBoxEaglesoftAdjustmentTypes.DisplayMember = "EaglesoftAdjustment";
            this.listBoxEaglesoftAdjustmentTypes.Location = new System.Drawing.Point(6, 19);
            this.listBoxEaglesoftAdjustmentTypes.Name = "listBoxEaglesoftAdjustmentTypes";
            this.listBoxEaglesoftAdjustmentTypes.Size = new System.Drawing.Size(177, 134);
            this.listBoxEaglesoftAdjustmentTypes.TabIndex = 2;
            this.listBoxEaglesoftAdjustmentTypes.ValueMember = "EaglesoftAdjustmentId";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(316, 237);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 18;
            // 
            // frmRefundTypeMappings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(484, 272);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRefundTypeMappings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Refund Type Mappings";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refundTypeMappingDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksBankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksIncomeAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksPaytypeBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxIssueRefundCheck;
        private System.Windows.Forms.ComboBox comboBoxQBFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxQBIncomeAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxQBPaymentType;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBoxEaglesoftAdjustmentTypes;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource refundTypeMappingDTOBindingSource;
        private System.Windows.Forms.BindingSource quickbooksCustomerBindingSource;
        private System.Windows.Forms.BindingSource quickbooksIncomeAccountBindingSource;
        private System.Windows.Forms.BindingSource quickbooksPaytypeBindingSource;
        private System.Windows.Forms.ComboBox comboBoxCheckRecipient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRefundBankAccount;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.BindingSource quickbooksBankAccountBindingSource;
        private System.Windows.Forms.Label label5;


    }
}