namespace Portfolio_Manager
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.instrument4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.insttype4 = new System.Windows.Forms.Label();
            this.tradeprice = new System.Windows.Forms.Label();
            this.buy4 = new System.Windows.Forms.RadioButton();
            this.sale4 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timestamp4 = new System.Windows.Forms.Label();
            this.add4 = new System.Windows.Forms.Button();
            this.cancel4 = new System.Windows.Forms.Button();
            this.tradeprice4 = new System.Windows.Forms.NumericUpDown();
            this.quantity4 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.price4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tradeprice4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instrument:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inst Type:";
            // 
            // instrument4
            // 
            this.instrument4.FormattingEnabled = true;
            this.instrument4.Location = new System.Drawing.Point(98, 94);
            this.instrument4.Name = "instrument4";
            this.instrument4.Size = new System.Drawing.Size(122, 20);
            this.instrument4.TabIndex = 2;
            this.instrument4.SelectedIndexChanged += new System.EventHandler(this.instrument4_SelectedIndexChanged);
            this.instrument4.Click += new System.EventHandler(this.instrument4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 3;
            // 
            // insttype4
            // 
            this.insttype4.AutoSize = true;
            this.insttype4.Location = new System.Drawing.Point(96, 122);
            this.insttype4.Name = "insttype4";
            this.insttype4.Size = new System.Drawing.Size(29, 12);
            this.insttype4.TabIndex = 4;
            this.insttype4.Text = "Null";
            // 
            // tradeprice
            // 
            this.tradeprice.AutoSize = true;
            this.tradeprice.Location = new System.Drawing.Point(21, 176);
            this.tradeprice.Name = "tradeprice";
            this.tradeprice.Size = new System.Drawing.Size(77, 12);
            this.tradeprice.TabIndex = 5;
            this.tradeprice.Text = "Trade Price:";
            // 
            // buy4
            // 
            this.buy4.AutoSize = true;
            this.buy4.Location = new System.Drawing.Point(55, 237);
            this.buy4.Name = "buy4";
            this.buy4.Size = new System.Drawing.Size(41, 16);
            this.buy4.TabIndex = 7;
            this.buy4.TabStop = true;
            this.buy4.Text = "Buy";
            this.buy4.UseVisualStyleBackColor = true;
            // 
            // sale4
            // 
            this.sale4.AutoSize = true;
            this.sale4.Location = new System.Drawing.Point(137, 237);
            this.sale4.Name = "sale4";
            this.sale4.Size = new System.Drawing.Size(47, 16);
            this.sale4.TabIndex = 8;
            this.sale4.TabStop = true;
            this.sale4.Text = "Sale";
            this.sale4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Timestamp:";
            // 
            // timestamp4
            // 
            this.timestamp4.AutoSize = true;
            this.timestamp4.Location = new System.Drawing.Point(83, 268);
            this.timestamp4.Name = "timestamp4";
            this.timestamp4.Size = new System.Drawing.Size(89, 12);
            this.timestamp4.TabIndex = 12;
            this.timestamp4.Text = "Month/Day/Year";
            // 
            // add4
            // 
            this.add4.Location = new System.Drawing.Point(38, 298);
            this.add4.Name = "add4";
            this.add4.Size = new System.Drawing.Size(75, 23);
            this.add4.TabIndex = 13;
            this.add4.Text = "Add";
            this.add4.UseVisualStyleBackColor = true;
            this.add4.Click += new System.EventHandler(this.add4_Click);
            // 
            // cancel4
            // 
            this.cancel4.Location = new System.Drawing.Point(137, 298);
            this.cancel4.Name = "cancel4";
            this.cancel4.Size = new System.Drawing.Size(75, 23);
            this.cancel4.TabIndex = 14;
            this.cancel4.Text = "Cancel";
            this.cancel4.UseVisualStyleBackColor = true;
            this.cancel4.Click += new System.EventHandler(this.cancel4_Click);
            // 
            // tradeprice4
            // 
            this.tradeprice4.Location = new System.Drawing.Point(98, 174);
            this.tradeprice4.Name = "tradeprice4";
            this.tradeprice4.Size = new System.Drawing.Size(122, 21);
            this.tradeprice4.TabIndex = 15;
            // 
            // quantity4
            // 
            this.quantity4.Location = new System.Drawing.Point(98, 201);
            this.quantity4.Name = "quantity4";
            this.quantity4.Size = new System.Drawing.Size(122, 21);
            this.quantity4.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "UnderlyingPirce:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 72);
            this.label7.TabIndex = 19;
            this.label7.Text = "Notice: The UnderlyingPrice is the \r\n        lastest historical price for\r\n      " +
    "  the instrument.\r\n\r\nWorning: You should add new price in \r\n         HistoricalP" +
    "rice Table first.";
            // 
            // price4
            // 
            this.price4.AutoSize = true;
            this.price4.Location = new System.Drawing.Point(128, 146);
            this.price4.Name = "price4";
            this.price4.Size = new System.Drawing.Size(41, 12);
            this.price4.TabIndex = 20;
            this.price4.Text = "label8";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 326);
            this.Controls.Add(this.price4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quantity4);
            this.Controls.Add(this.tradeprice4);
            this.Controls.Add(this.cancel4);
            this.Controls.Add(this.add4);
            this.Controls.Add(this.timestamp4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sale4);
            this.Controls.Add(this.buy4);
            this.Controls.Add(this.tradeprice);
            this.Controls.Add(this.insttype4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.instrument4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Trade";
            ((System.ComponentModel.ISupportInitialize)(this.tradeprice4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox instrument4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label insttype4;
        private System.Windows.Forms.Label tradeprice;
        private System.Windows.Forms.RadioButton buy4;
        private System.Windows.Forms.RadioButton sale4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label timestamp4;
        private System.Windows.Forms.Button add4;
        private System.Windows.Forms.Button cancel4;
        private System.Windows.Forms.NumericUpDown tradeprice4;
        private System.Windows.Forms.NumericUpDown quantity4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label price4;
    }
}