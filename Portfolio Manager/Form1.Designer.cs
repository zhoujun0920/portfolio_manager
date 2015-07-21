namespace Portfolio_Manager
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulatePriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.version10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.volatility1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.data1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.data2 = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dividend1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tradeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volatility1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dividend1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.simulatePriceToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumentTypeToolStripMenuItem,
            this.instrumentToolStripMenuItem,
            this.tradeToolStripMenuItem,
            this.interestRateToolStripMenuItem,
            this.historicalPriceToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.newToolStripMenuItem.Text = "New...";
            // 
            // instrumentTypeToolStripMenuItem
            // 
            this.instrumentTypeToolStripMenuItem.Name = "instrumentTypeToolStripMenuItem";
            this.instrumentTypeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.instrumentTypeToolStripMenuItem.Text = "Inst Type";
            this.instrumentTypeToolStripMenuItem.Click += new System.EventHandler(this.instrumentTypeToolStripMenuItem_Click);
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            this.instrumentToolStripMenuItem.Click += new System.EventHandler(this.instrumentToolStripMenuItem_Click);
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tradeToolStripMenuItem.Text = "Trade";
            this.tradeToolStripMenuItem.Click += new System.EventHandler(this.tradeToolStripMenuItem_Click);
            // 
            // interestRateToolStripMenuItem
            // 
            this.interestRateToolStripMenuItem.Name = "interestRateToolStripMenuItem";
            this.interestRateToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.interestRateToolStripMenuItem.Text = "Interest Rate";
            this.interestRateToolStripMenuItem.Click += new System.EventHandler(this.interestRateToolStripMenuItem_Click);
            // 
            // historicalPriceToolStripMenuItem
            // 
            this.historicalPriceToolStripMenuItem.Name = "historicalPriceToolStripMenuItem";
            this.historicalPriceToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.historicalPriceToolStripMenuItem.Text = "Historical Price";
            this.historicalPriceToolStripMenuItem.Click += new System.EventHandler(this.historicalPriceToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instTypeToolStripMenuItem,
            this.instrumentToolStripMenuItem1,
            this.interestRateToolStripMenuItem1,
            this.tradeToolStripMenuItem1});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.deleteToolStripMenuItem.Text = "Delete and Update...";
            // 
            // instTypeToolStripMenuItem
            // 
            this.instTypeToolStripMenuItem.Name = "instTypeToolStripMenuItem";
            this.instTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.instTypeToolStripMenuItem.Text = "Inst Type";
            this.instTypeToolStripMenuItem.Click += new System.EventHandler(this.instTypeToolStripMenuItem_Click);
            // 
            // instrumentToolStripMenuItem1
            // 
            this.instrumentToolStripMenuItem1.Name = "instrumentToolStripMenuItem1";
            this.instrumentToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.instrumentToolStripMenuItem1.Text = "Instrument";
            this.instrumentToolStripMenuItem1.Click += new System.EventHandler(this.instrumentToolStripMenuItem1_Click);
            // 
            // interestRateToolStripMenuItem1
            // 
            this.interestRateToolStripMenuItem1.Name = "interestRateToolStripMenuItem1";
            this.interestRateToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.interestRateToolStripMenuItem1.Text = "Interest Rate";
            this.interestRateToolStripMenuItem1.Click += new System.EventHandler(this.interestRateToolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.refreshToolStripMenuItem.Text = "Refresh Trades From Database";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // simulatePriceToolStripMenuItem
            // 
            this.simulatePriceToolStripMenuItem.Name = "simulatePriceToolStripMenuItem";
            this.simulatePriceToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.simulatePriceToolStripMenuItem.Text = "Price Simulation";
            this.simulatePriceToolStripMenuItem.Click += new System.EventHandler(this.simulatePriceToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.priceAnalysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // priceAnalysisToolStripMenuItem
            // 
            this.priceAnalysisToolStripMenuItem.Name = "priceAnalysisToolStripMenuItem";
            this.priceAnalysisToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.priceAnalysisToolStripMenuItem.Text = "Price Analysis";
            this.priceAnalysisToolStripMenuItem.Click += new System.EventHandler(this.priceAnalysisToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.version10ToolStripMenuItem,
            this.sampleDataToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // version10ToolStripMenuItem
            // 
            this.version10ToolStripMenuItem.Name = "version10ToolStripMenuItem";
            this.version10ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.version10ToolStripMenuItem.Text = "About Portfolio Manager";
            this.version10ToolStripMenuItem.Click += new System.EventHandler(this.version10ToolStripMenuItem_Click);
            // 
            // sampleDataToolStripMenuItem
            // 
            this.sampleDataToolStripMenuItem.Name = "sampleDataToolStripMenuItem";
            this.sampleDataToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.sampleDataToolStripMenuItem.Text = "Sample Data Import";
            this.sampleDataToolStripMenuItem.Click += new System.EventHandler(this.sampleDataToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Volatility:";
            // 
            // volatility1
            // 
            this.volatility1.DecimalPlaces = 2;
            this.volatility1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.volatility1.Location = new System.Drawing.Point(113, 35);
            this.volatility1.Name = "volatility1";
            this.volatility1.Size = new System.Drawing.Size(62, 21);
            this.volatility1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Totals:";
            // 
            // data1
            // 
            this.data1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N5";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data1.DefaultCellStyle = dataGridViewCellStyle1;
            this.data1.Location = new System.Drawing.Point(26, 94);
            this.data1.Name = "data1";
            this.data1.ReadOnly = true;
            this.data1.RowTemplate.Height = 23;
            this.data1.Size = new System.Drawing.Size(647, 43);
            this.data1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trades:";
            // 
            // data2
            // 
            this.data2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.data2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data2.Location = new System.Drawing.Point(26, 174);
            this.data2.Name = "data2";
            this.data2.RowTemplate.Height = 23;
            this.data2.Size = new System.Drawing.Size(647, 119);
            this.data2.TabIndex = 6;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dividend:";
            // 
            // dividend1
            // 
            this.dividend1.DecimalPlaces = 2;
            this.dividend1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.dividend1.Location = new System.Drawing.Point(284, 35);
            this.dividend1.Name = "dividend1";
            this.dividend1.Size = new System.Drawing.Size(75, 21);
            this.dividend1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(641, 36);
            this.label5.TabIndex = 9;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // tradeToolStripMenuItem1
            // 
            this.tradeToolStripMenuItem1.Name = "tradeToolStripMenuItem1";
            this.tradeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.tradeToolStripMenuItem1.Text = "Trade";
            this.tradeToolStripMenuItem1.Click += new System.EventHandler(this.tradeToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 350);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dividend1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.data2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.volatility1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portfolio Manager 1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volatility1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dividend1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView data1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatePriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem instrumentTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem interestRateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem priceAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem version10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        public System.Windows.Forms.NumericUpDown volatility1;
        public System.Windows.Forms.DataGridView data2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown dividend1;
        private System.Windows.Forms.ToolStripMenuItem sampleDataToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem1;
    }
}

