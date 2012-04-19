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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayTypeMappings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.comboQbFrom = new System.Windows.Forms.ComboBox();
            this.lblQbFrom = new System.Windows.Forms.Label();
            this.comboQbAccount = new System.Windows.Forms.ComboBox();
            this.lblQbIncomeAccount = new System.Windows.Forms.Label();
            this.lblQbPayType = new System.Windows.Forms.Label();
            this.comboQbPayType = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 163);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eaglesoft";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(177, 134);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInstructions);
            this.groupBox2.Controls.Add(this.comboQbFrom);
            this.groupBox2.Controls.Add(this.lblQbFrom);
            this.groupBox2.Controls.Add(this.comboQbAccount);
            this.groupBox2.Controls.Add(this.lblQbIncomeAccount);
            this.groupBox2.Controls.Add(this.lblQbPayType);
            this.groupBox2.Controls.Add(this.comboQbPayType);
            this.groupBox2.Location = new System.Drawing.Point(215, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 163);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quickbooks";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(6, 101);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(248, 52);
            this.lblInstructions.TabIndex = 12;
            this.lblInstructions.Text = "Specify the mapping between the eaglesoft payment type and the quickbooks payment" +
                " type. You must also select the income account and from data for each eaglesoft " +
                "payment type.";
            // 
            // comboQbFrom
            // 
            this.comboQbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboQbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboQbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQbFrom.FormattingEnabled = true;
            this.comboQbFrom.Location = new System.Drawing.Point(97, 74);
            this.comboQbFrom.Name = "comboQbFrom";
            this.comboQbFrom.Size = new System.Drawing.Size(157, 21);
            this.comboQbFrom.TabIndex = 11;
            this.comboQbFrom.SelectedValueChanged += new System.EventHandler(this.comboQbFrom_SelectedValueChanged);
            // 
            // lblQbFrom
            // 
            this.lblQbFrom.AutoSize = true;
            this.lblQbFrom.Location = new System.Drawing.Point(61, 77);
            this.lblQbFrom.Name = "lblQbFrom";
            this.lblQbFrom.Size = new System.Drawing.Size(30, 13);
            this.lblQbFrom.TabIndex = 10;
            this.lblQbFrom.Text = "From";
            // 
            // comboQbAccount
            // 
            this.comboQbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboQbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboQbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQbAccount.FormattingEnabled = true;
            this.comboQbAccount.Location = new System.Drawing.Point(97, 46);
            this.comboQbAccount.Name = "comboQbAccount";
            this.comboQbAccount.Size = new System.Drawing.Size(157, 21);
            this.comboQbAccount.TabIndex = 9;
            this.comboQbAccount.SelectedValueChanged += new System.EventHandler(this.comboQbAccount_SelectedValueChanged);
            // 
            // lblQbIncomeAccount
            // 
            this.lblQbIncomeAccount.AutoSize = true;
            this.lblQbIncomeAccount.Location = new System.Drawing.Point(6, 49);
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
            this.comboQbPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQbPayType.FormattingEnabled = true;
            this.comboQbPayType.Location = new System.Drawing.Point(97, 19);
            this.comboQbPayType.Name = "comboQbPayType";
            this.comboQbPayType.Size = new System.Drawing.Size(157, 21);
            this.comboQbPayType.TabIndex = 6;
            this.comboQbPayType.SelectedValueChanged += new System.EventHandler(this.comboQbPayType_SelectedValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(400, 181);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 211);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(483, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // frmPayTypeMappings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 233);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayTypeMappings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paytype Mappings";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboQbAccount;
        private System.Windows.Forms.Label lblQbIncomeAccount;
        private System.Windows.Forms.Label lblQbPayType;
        private System.Windows.Forms.ComboBox comboQbPayType;
        private System.Windows.Forms.ComboBox comboQbFrom;
        private System.Windows.Forms.Label lblQbFrom;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;


    }
}