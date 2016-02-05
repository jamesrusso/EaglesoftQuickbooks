namespace Eaglesoft_Deposit.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupPaymentTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupRefundTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupDepositsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLastRunTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupESDatabaseConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinceLastImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specificDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1826, 1176);
            this.textBox1.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.cancelImportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1826, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupPaymentTypesToolStripMenuItem,
            this.setupRefundTypesToolStripMenuItem,
            this.setupDepositsToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.setLastRunTimeToolStripMenuItem,
            this.setupESDatabaseConnectionToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // setupPaymentTypesToolStripMenuItem
            // 
            this.setupPaymentTypesToolStripMenuItem.Name = "setupPaymentTypesToolStripMenuItem";
            this.setupPaymentTypesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.setupPaymentTypesToolStripMenuItem.Text = "Setup Payment Types";
            this.setupPaymentTypesToolStripMenuItem.Click += new System.EventHandler(this.setupPaymentTypesToolStripMenuItem_Click);
            // 
            // setupRefundTypesToolStripMenuItem
            // 
            this.setupRefundTypesToolStripMenuItem.Name = "setupRefundTypesToolStripMenuItem";
            this.setupRefundTypesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.setupRefundTypesToolStripMenuItem.Text = "Setup Refund Types";
            this.setupRefundTypesToolStripMenuItem.Click += new System.EventHandler(this.setupRefundTypesToolStripMenuItem_Click);
            // 
            // setupDepositsToolStripMenuItem
            // 
            this.setupDepositsToolStripMenuItem.Name = "setupDepositsToolStripMenuItem";
            this.setupDepositsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.setupDepositsToolStripMenuItem.Text = "Setup Deposits";
            this.setupDepositsToolStripMenuItem.Click += new System.EventHandler(this.setupDepositsToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // setLastRunTimeToolStripMenuItem
            // 
            this.setLastRunTimeToolStripMenuItem.Name = "setLastRunTimeToolStripMenuItem";
            this.setLastRunTimeToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.setLastRunTimeToolStripMenuItem.Text = "Set Last Run Time";
            this.setLastRunTimeToolStripMenuItem.Click += new System.EventHandler(this.setLastRunTimeToolStripMenuItem_Click);
            // 
            // setupESDatabaseConnectionToolStripMenuItem
            // 
            this.setupESDatabaseConnectionToolStripMenuItem.Name = "setupESDatabaseConnectionToolStripMenuItem";
            this.setupESDatabaseConnectionToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.setupESDatabaseConnectionToolStripMenuItem.Text = "Setup ES Database Connection";
            this.setupESDatabaseConnectionToolStripMenuItem.Click += new System.EventHandler(this.setupESDatabaseConnectionToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinceLastImportToolStripMenuItem,
            this.todayToolStripMenuItem,
            this.specificDayToolStripMenuItem});
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.importDataToolStripMenuItem.Text = "Import Data";
            // 
            // sinceLastImportToolStripMenuItem
            // 
            this.sinceLastImportToolStripMenuItem.Name = "sinceLastImportToolStripMenuItem";
            this.sinceLastImportToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.sinceLastImportToolStripMenuItem.Text = "Since Last Import";
            this.sinceLastImportToolStripMenuItem.Click += new System.EventHandler(this.sinceLastImportToolStripMenuItem_Click);
            // 
            // todayToolStripMenuItem
            // 
            this.todayToolStripMenuItem.Name = "todayToolStripMenuItem";
            this.todayToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.todayToolStripMenuItem.Text = "Today";
            this.todayToolStripMenuItem.Click += new System.EventHandler(this.todayToolStripMenuItem_Click);
            // 
            // specificDayToolStripMenuItem
            // 
            this.specificDayToolStripMenuItem.Name = "specificDayToolStripMenuItem";
            this.specificDayToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.specificDayToolStripMenuItem.Text = "Specific Day";
            this.specificDayToolStripMenuItem.Click += new System.EventHandler(this.specificDayToolStripMenuItem_Click);
            // 
            // cancelImportToolStripMenuItem
            // 
            this.cancelImportToolStripMenuItem.Name = "cancelImportToolStripMenuItem";
            this.cancelImportToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.cancelImportToolStripMenuItem.Text = "Cancel Import";
            this.cancelImportToolStripMenuItem.Visible = false;
            this.cancelImportToolStripMenuItem.Click += new System.EventHandler(this.cancelImportToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Eaglesoft_Deposit.Properties.Settings.Default, "MainFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.statusStrip1.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::Eaglesoft_Deposit.Properties.Settings.Default, "MainFormSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = global::Eaglesoft_Deposit.Properties.Settings.Default.MainFormLocation;
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = global::Eaglesoft_Deposit.Properties.Settings.Default.MainFormSize;
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1826, 1198);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 324);
            this.MinimumSize = new System.Drawing.Size(780, 480);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eaglesoft Quickbooks Deposit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupPaymentTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupRefundTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupDepositsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLastRunTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupESDatabaseConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinceLastImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specificDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelImportToolStripMenuItem;
    }
}

