namespace Eaglesoft_Deposit
{
    partial class frmPayTypeMappings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTypeMappings));
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboQbFrom = new System.Windows.Forms.ComboBox();
            this.paytypeMappingDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quickbooksCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblQbFrom = new System.Windows.Forms.Label();
            this.comboQbAccount = new System.Windows.Forms.ComboBox();
            this.quickbooksAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblQbIncomeAccount = new System.Windows.Forms.Label();
            this.lblQbPayType = new System.Windows.Forms.Label();
            this.comboQbPayType = new System.Windows.Forms.ComboBox();
            this.quickbooksPaytypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paytypeMappingDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksPaytypeBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(404, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboQbFrom);
            this.groupBox2.Controls.Add(this.lblQbFrom);
            this.groupBox2.Controls.Add(this.comboQbAccount);
            this.groupBox2.Controls.Add(this.lblQbIncomeAccount);
            this.groupBox2.Controls.Add(this.lblQbPayType);
            this.groupBox2.Controls.Add(this.comboQbPayType);
            this.groupBox2.Location = new System.Drawing.Point(220, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 162);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quickbooks";
            // 
            // comboQbFrom
            // 
            this.comboQbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboQbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboQbFrom.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.paytypeMappingDTOBindingSource, "QuickbooksCustomer", true));
            this.comboQbFrom.DataSource = this.quickbooksCustomerBindingSource;
            this.comboQbFrom.DisplayMember = "Name";
            this.comboQbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQbFrom.FormattingEnabled = true;
            this.comboQbFrom.Location = new System.Drawing.Point(97, 68);
            this.comboQbFrom.Name = "comboQbFrom";
            this.comboQbFrom.Size = new System.Drawing.Size(157, 21);
            this.comboQbFrom.TabIndex = 11;
            this.comboQbFrom.ValueMember = "Name";
            // 
            // paytypeMappingDTOBindingSource
            // 
            this.paytypeMappingDTOBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.PaytypeMappingDTO);
            // 
            // quickbooksCustomerBindingSource
            // 
            this.quickbooksCustomerBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.QuickbooksCustomer);
            // 
            // lblQbFrom
            // 
            this.lblQbFrom.AutoSize = true;
            this.lblQbFrom.Location = new System.Drawing.Point(59, 71);
            this.lblQbFrom.Name = "lblQbFrom";
            this.lblQbFrom.Size = new System.Drawing.Size(30, 13);
            this.lblQbFrom.TabIndex = 10;
            this.lblQbFrom.Text = "From";
            // 
            // comboQbAccount
            // 
            this.comboQbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboQbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboQbAccount.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.paytypeMappingDTOBindingSource, "QuickbooksAccount", true));
            this.comboQbAccount.DataSource = this.quickbooksAccountBindingSource;
            this.comboQbAccount.DisplayMember = "Name";
            this.comboQbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQbAccount.FormattingEnabled = true;
            this.comboQbAccount.Location = new System.Drawing.Point(97, 44);
            this.comboQbAccount.Name = "comboQbAccount";
            this.comboQbAccount.Size = new System.Drawing.Size(157, 21);
            this.comboQbAccount.TabIndex = 9;
            this.comboQbAccount.ValueMember = "Name";
            // 
            // quickbooksAccountBindingSource
            // 
            this.quickbooksAccountBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.QuickbooksAccount);
            // 
            // lblQbIncomeAccount
            // 
            this.lblQbIncomeAccount.AutoSize = true;
            this.lblQbIncomeAccount.Location = new System.Drawing.Point(6, 47);
            this.lblQbIncomeAccount.Name = "lblQbIncomeAccount";
            this.lblQbIncomeAccount.Size = new System.Drawing.Size(85, 13);
            this.lblQbIncomeAccount.TabIndex = 8;
            this.lblQbIncomeAccount.Text = "Income Account";
            // 
            // lblQbPayType
            // 
            this.lblQbPayType.AutoSize = true;
            this.lblQbPayType.Location = new System.Drawing.Point(16, 22);
            this.lblQbPayType.Name = "lblQbPayType";
            this.lblQbPayType.Size = new System.Drawing.Size(75, 13);
            this.lblQbPayType.TabIndex = 7;
            this.lblQbPayType.Text = "Payment Type";
            // 
            // comboQbPayType
            // 
            this.comboQbPayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboQbPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboQbPayType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.paytypeMappingDTOBindingSource, "QuickbooksPaytype", true));
            this.comboQbPayType.DataSource = this.quickbooksPaytypeBindingSource;
            this.comboQbPayType.DisplayMember = "Name";
            this.comboQbPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQbPayType.FormattingEnabled = true;
            this.comboQbPayType.Location = new System.Drawing.Point(97, 19);
            this.comboQbPayType.Name = "comboQbPayType";
            this.comboQbPayType.Size = new System.Drawing.Size(157, 21);
            this.comboQbPayType.TabIndex = 6;
            this.comboQbPayType.ValueMember = "Name";
            // 
            // quickbooksPaytypeBindingSource
            // 
            this.quickbooksPaytypeBindingSource.DataSource = typeof(Eaglesoft_Deposit.Model.QuickbooksPaytype);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 162);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eaglesoft Payment Types";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.paytypeMappingDTOBindingSource;
            this.listBox1.DisplayMember = "EaglesoftPaytype";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(206, 143);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "EaglesoftPaytypeId";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(324, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmPayTypeMappings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(488, 209);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayTypeMappings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Type Mappings";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paytypeMappingDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quickbooksPaytypeBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboQbFrom;
        private System.Windows.Forms.Label lblQbFrom;
        private System.Windows.Forms.ComboBox comboQbAccount;
        private System.Windows.Forms.Label lblQbIncomeAccount;
        private System.Windows.Forms.Label lblQbPayType;
        private System.Windows.Forms.ComboBox comboQbPayType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource paytypeMappingDTOBindingSource;
        private System.Windows.Forms.BindingSource quickbooksCustomerBindingSource;
        private System.Windows.Forms.BindingSource quickbooksAccountBindingSource;
        private System.Windows.Forms.BindingSource quickbooksPaytypeBindingSource;
        private System.Windows.Forms.Button btnCancel;


    }
}