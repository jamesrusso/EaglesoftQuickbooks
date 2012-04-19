namespace Eaglesoft_Deposit.Forms
{
    partial class frmInitialConfiguration
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.grpBoxEaglesoft = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblESPassFail = new System.Windows.Forms.Label();
            this.btnEaglesoftDBTesxt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxQuickbooks = new System.Windows.Forms.GroupBox();
            this.btnQuickbooksTest = new System.Windows.Forms.Button();
            this.lblQuickbooksPassFail = new System.Windows.Forms.Label();
            this.grpBoxEaglesoft.SuspendLayout();
            this.grpBoxQuickbooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(394, 80);
            this.lblInstructions.TabIndex = 8;
            this.lblInstructions.Text = "For the initial setup we must establish a connection to Eaglesoft as well as Quic" +
                "kbooks. Please select the data source for ES and click test.";
            // 
            // grpBoxEaglesoft
            // 
            this.grpBoxEaglesoft.Controls.Add(this.comboBox1);
            this.grpBoxEaglesoft.Controls.Add(this.lblESPassFail);
            this.grpBoxEaglesoft.Controls.Add(this.btnEaglesoftDBTesxt);
            this.grpBoxEaglesoft.Controls.Add(this.label1);
            this.grpBoxEaglesoft.Location = new System.Drawing.Point(15, 92);
            this.grpBoxEaglesoft.Name = "grpBoxEaglesoft";
            this.grpBoxEaglesoft.Size = new System.Drawing.Size(391, 96);
            this.grpBoxEaglesoft.TabIndex = 11;
            this.grpBoxEaglesoft.TabStop = false;
            this.grpBoxEaglesoft.Text = "Eaglesoft Database Connection";
            this.grpBoxEaglesoft.Visible = false;
            this.grpBoxEaglesoft.VisibleChanged += new System.EventHandler(this.grpBoxEaglesoft_VisibleChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(42, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // lblESPassFail
            // 
            this.lblESPassFail.AutoSize = true;
            this.lblESPassFail.Location = new System.Drawing.Point(338, 42);
            this.lblESPassFail.Name = "lblESPassFail";
            this.lblESPassFail.Size = new System.Drawing.Size(30, 13);
            this.lblESPassFail.TabIndex = 13;
            this.lblESPassFail.Text = "Pass";
            this.lblESPassFail.Visible = false;
            // 
            // btnEaglesoftDBTesxt
            // 
            this.btnEaglesoftDBTesxt.Location = new System.Drawing.Point(257, 37);
            this.btnEaglesoftDBTesxt.Name = "btnEaglesoftDBTesxt";
            this.btnEaglesoftDBTesxt.Size = new System.Drawing.Size(75, 23);
            this.btnEaglesoftDBTesxt.TabIndex = 12;
            this.btnEaglesoftDBTesxt.Text = "Test";
            this.btnEaglesoftDBTesxt.UseVisualStyleBackColor = true;
            this.btnEaglesoftDBTesxt.Click += new System.EventHandler(this.btnEaglesoftDBTesxt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-73, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Eaglesoft DSN";
            // 
            // grpBoxQuickbooks
            // 
            this.grpBoxQuickbooks.Controls.Add(this.btnQuickbooksTest);
            this.grpBoxQuickbooks.Controls.Add(this.lblQuickbooksPassFail);
            this.grpBoxQuickbooks.Location = new System.Drawing.Point(111, 401);
            this.grpBoxQuickbooks.Name = "grpBoxQuickbooks";
            this.grpBoxQuickbooks.Size = new System.Drawing.Size(391, 96);
            this.grpBoxQuickbooks.TabIndex = 12;
            this.grpBoxQuickbooks.TabStop = false;
            this.grpBoxQuickbooks.Text = "Quickbooks Connection Setup";
            this.grpBoxQuickbooks.Visible = false;
            this.grpBoxQuickbooks.VisibleChanged += new System.EventHandler(this.grpBoxQuickbooks_VisibleChanged);
            // 
            // btnQuickbooksTest
            // 
            this.btnQuickbooksTest.Location = new System.Drawing.Point(140, 37);
            this.btnQuickbooksTest.Name = "btnQuickbooksTest";
            this.btnQuickbooksTest.Size = new System.Drawing.Size(75, 23);
            this.btnQuickbooksTest.TabIndex = 3;
            this.btnQuickbooksTest.Text = "Test";
            this.btnQuickbooksTest.UseVisualStyleBackColor = true;
            this.btnQuickbooksTest.Click += new System.EventHandler(this.btnQuickbooksTest_Click);
            // 
            // lblQuickbooksPassFail
            // 
            this.lblQuickbooksPassFail.AutoSize = true;
            this.lblQuickbooksPassFail.Location = new System.Drawing.Point(249, 42);
            this.lblQuickbooksPassFail.Name = "lblQuickbooksPassFail";
            this.lblQuickbooksPassFail.Size = new System.Drawing.Size(30, 13);
            this.lblQuickbooksPassFail.TabIndex = 7;
            this.lblQuickbooksPassFail.Text = "Pass";
            this.lblQuickbooksPassFail.Visible = false;
            // 
            // frmInitialConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 208);
            this.Controls.Add(this.grpBoxEaglesoft);
            this.Controls.Add(this.grpBoxQuickbooks);
            this.Controls.Add(this.lblInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmInitialConfiguration";
            this.Text = "Initial Configuration";
            this.Load += new System.EventHandler(this.frmInitialConfiguration_Load);
            this.grpBoxEaglesoft.ResumeLayout(false);
            this.grpBoxEaglesoft.PerformLayout();
            this.grpBoxQuickbooks.ResumeLayout(false);
            this.grpBoxQuickbooks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.GroupBox grpBoxEaglesoft;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grpBoxQuickbooks;
        private System.Windows.Forms.Button btnQuickbooksTest;
        private System.Windows.Forms.Label lblQuickbooksPassFail;
        private System.Windows.Forms.Label lblESPassFail;
        private System.Windows.Forms.Button btnEaglesoftDBTesxt;
        private System.Windows.Forms.Label label1;
    }
}