namespace Eaglesoft_Deposit
{
    partial class frmRefundConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefundConfiguration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxQuickbooksCheckingAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEaglesoftAdjustmentTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxQuickbooksIncomeAccount = new System.Windows.Forms.ComboBox();
            this.lblQbIncomeAccount = new System.Windows.Forms.Label();
            this.checkBoxRefundsEnabled = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxQuickbooksCheckingAccount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxEaglesoftAdjustmentTypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxQuickbooksIncomeAccount);
            this.groupBox1.Controls.Add(this.lblQbIncomeAccount);
            this.groupBox1.Controls.Add(this.checkBoxRefundsEnabled);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 131);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refunds";
            // 
            // comboBoxQuickbooksCheckingAccount
            // 
            this.comboBoxQuickbooksCheckingAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxQuickbooksCheckingAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxQuickbooksCheckingAccount.FormattingEnabled = true;
            this.comboBoxQuickbooksCheckingAccount.Location = new System.Drawing.Point(163, 93);
            this.comboBoxQuickbooksCheckingAccount.Name = "comboBoxQuickbooksCheckingAccount";
            this.comboBoxQuickbooksCheckingAccount.Size = new System.Drawing.Size(157, 21);
            this.comboBoxQuickbooksCheckingAccount.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Quickbooks Checking Account";
            // 
            // cbESAdjustmentTypes
            // 
            this.comboBoxEaglesoftAdjustmentTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxEaglesoftAdjustmentTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEaglesoftAdjustmentTypes.FormattingEnabled = true;
            this.comboBoxEaglesoftAdjustmentTypes.Location = new System.Drawing.Point(163, 39);
            this.comboBoxEaglesoftAdjustmentTypes.Name = "cbESAdjustmentTypes";
            this.comboBoxEaglesoftAdjustmentTypes.Size = new System.Drawing.Size(157, 21);
            this.comboBoxEaglesoftAdjustmentTypes.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Eaglesoft Adjustment Type";
            // 
            // comboQbAccount
            // 
            this.comboBoxQuickbooksIncomeAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxQuickbooksIncomeAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxQuickbooksIncomeAccount.FormattingEnabled = true;
            this.comboBoxQuickbooksIncomeAccount.Location = new System.Drawing.Point(163, 66);
            this.comboBoxQuickbooksIncomeAccount.Name = "comboQbAccount";
            this.comboBoxQuickbooksIncomeAccount.Size = new System.Drawing.Size(157, 21);
            this.comboBoxQuickbooksIncomeAccount.TabIndex = 11;
            // 
            // lblQbIncomeAccount
            // 
            this.lblQbIncomeAccount.AutoSize = true;
            this.lblQbIncomeAccount.Location = new System.Drawing.Point(6, 69);
            this.lblQbIncomeAccount.Name = "lblQbIncomeAccount";
            this.lblQbIncomeAccount.Size = new System.Drawing.Size(145, 13);
            this.lblQbIncomeAccount.TabIndex = 10;
            this.lblQbIncomeAccount.Text = "Quickbooks Income Account";
            // 
            // checkBox1
            // 
            this.checkBoxRefundsEnabled.AutoSize = true;
            this.checkBoxRefundsEnabled.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxRefundsEnabled.Location = new System.Drawing.Point(96, 16);
            this.checkBoxRefundsEnabled.Name = "checkBox1";
            this.checkBoxRefundsEnabled.Size = new System.Drawing.Size(137, 17);
            this.checkBoxRefundsEnabled.TabIndex = 0;
            this.checkBoxRefundsEnabled.Text = "Enable Refund Support";
            this.checkBoxRefundsEnabled.UseVisualStyleBackColor = true;
            this.checkBoxRefundsEnabled.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(279, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 35);
            this.label3.TabIndex = 6;
            this.label3.Text = "A refund is actually negative income. This is why you specify an income and not e" +
                "xpense account.";
            // 
            // frmRefundConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 182);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefundConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Refund Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxEaglesoftAdjustmentTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxQuickbooksIncomeAccount;
        private System.Windows.Forms.Label lblQbIncomeAccount;
        private System.Windows.Forms.CheckBox checkBoxRefundsEnabled;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox comboBoxQuickbooksCheckingAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}