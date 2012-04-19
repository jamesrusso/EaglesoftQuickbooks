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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupPaymentTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupDepositsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupRefundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLastRunTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinceLastImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specificDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.reRunInitialSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(581, 318);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.cancelImportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 30);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupPaymentTypesToolStripMenuItem,
            this.setupDepositsToolStripMenuItem,
            this.setupRefundsToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.setLastRunTimeToolStripMenuItem,
            this.reRunInitialSetupToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(47, 26);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // setupPaymentTypesToolStripMenuItem
            // 
            this.setupPaymentTypesToolStripMenuItem.Name = "setupPaymentTypesToolStripMenuItem";
            this.setupPaymentTypesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.setupPaymentTypesToolStripMenuItem.Text = "Setup Payment Types";
            this.setupPaymentTypesToolStripMenuItem.Click += new System.EventHandler(this.setupPaymentTypesToolStripMenuItem_Click);
            // 
            // setupDepositsToolStripMenuItem
            // 
            this.setupDepositsToolStripMenuItem.Name = "setupDepositsToolStripMenuItem";
            this.setupDepositsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.setupDepositsToolStripMenuItem.Text = "Setup Deposits";
            this.setupDepositsToolStripMenuItem.Click += new System.EventHandler(this.setupDepositsToolStripMenuItem_Click);
            // 
            // setupRefundsToolStripMenuItem
            // 
            this.setupRefundsToolStripMenuItem.Name = "setupRefundsToolStripMenuItem";
            this.setupRefundsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.setupRefundsToolStripMenuItem.Text = "Setup Refunds";
            this.setupRefundsToolStripMenuItem.Click += new System.EventHandler(this.setupRefundsToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // setLastRunTimeToolStripMenuItem
            // 
            this.setLastRunTimeToolStripMenuItem.Name = "setLastRunTimeToolStripMenuItem";
            this.setLastRunTimeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.setLastRunTimeToolStripMenuItem.Text = "Set Last Run Time";
            this.setLastRunTimeToolStripMenuItem.Click += new System.EventHandler(this.setLastRunTimeToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinceLastImportToolStripMenuItem,
            this.todayToolStripMenuItem,
            this.specificDayToolStripMenuItem});
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(77, 26);
            this.importDataToolStripMenuItem.Text = "Import Data";
            // 
            // sinceLastImportToolStripMenuItem
            // 
            this.sinceLastImportToolStripMenuItem.Name = "sinceLastImportToolStripMenuItem";
            this.sinceLastImportToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sinceLastImportToolStripMenuItem.Text = "Since Last Import";
            this.sinceLastImportToolStripMenuItem.Click += new System.EventHandler(this.sinceLastImportToolStripMenuItem_Click);
            // 
            // todayToolStripMenuItem
            // 
            this.todayToolStripMenuItem.Name = "todayToolStripMenuItem";
            this.todayToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.todayToolStripMenuItem.Text = "Today";
            this.todayToolStripMenuItem.Click += new System.EventHandler(this.todayToolStripMenuItem_Click);
            // 
            // specificDayToolStripMenuItem
            // 
            this.specificDayToolStripMenuItem.Name = "specificDayToolStripMenuItem";
            this.specificDayToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.specificDayToolStripMenuItem.Text = "Specific Day";
            this.specificDayToolStripMenuItem.Click += new System.EventHandler(this.specificDayToolStripMenuItem_Click);
            // 
            // cancelImportToolStripMenuItem
            // 
            this.cancelImportToolStripMenuItem.Name = "cancelImportToolStripMenuItem";
            this.cancelImportToolStripMenuItem.Size = new System.Drawing.Size(86, 26);
            this.cancelImportToolStripMenuItem.Text = "Cancel Import";
            this.cancelImportToolStripMenuItem.Visible = false;
            this.cancelImportToolStripMenuItem.Click += new System.EventHandler(this.cancelImportToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBox1.Location = new System.Drawing.Point(3, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(575, 282);
            this.textBox1.TabIndex = 18;
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
            // reRunInitialSetupToolStripMenuItem
            // 
            this.reRunInitialSetupToolStripMenuItem.Name = "reRunInitialSetupToolStripMenuItem";
            this.reRunInitialSetupToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.reRunInitialSetupToolStripMenuItem.Text = "Re-Run initial Setup";
            this.reRunInitialSetupToolStripMenuItem.Click += new System.EventHandler(this.reRunInitialSetupToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(581, 340);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 324);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eaglesoft Quickbooks Deposit";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupPaymentTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupDepositsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupRefundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinceLastImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specificDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem setLastRunTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem cancelImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reRunInitialSetupToolStripMenuItem;
    }
}

