namespace Portfolio_Manager
{
    partial class Form3
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.companyname3 = new System.Windows.Forms.TextBox();
            this.ticker3 = new System.Windows.Forms.TextBox();
            this.exchange3 = new System.Windows.Forms.TextBox();
            this.insttype3 = new System.Windows.Forms.ComboBox();
            this.call3 = new System.Windows.Forms.RadioButton();
            this.put3 = new System.Windows.Forms.RadioButton();
            this.neither3 = new System.Windows.Forms.RadioButton();
            this.add3 = new System.Windows.Forms.Button();
            this.cancel3 = new System.Windows.Forms.Button();
            this.strike3 = new System.Windows.Forms.NumericUpDown();
            this.tenor3 = new System.Windows.Forms.NumericUpDown();
            this.underlying3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.strike3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenor3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ticker:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exchange:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Underlying:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Strike:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tenor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Inst Type";
            // 
            // companyname3
            // 
            this.companyname3.Location = new System.Drawing.Point(114, 87);
            this.companyname3.Name = "companyname3";
            this.companyname3.Size = new System.Drawing.Size(134, 21);
            this.companyname3.TabIndex = 8;
            // 
            // ticker3
            // 
            this.ticker3.Location = new System.Drawing.Point(114, 112);
            this.ticker3.Name = "ticker3";
            this.ticker3.Size = new System.Drawing.Size(134, 21);
            this.ticker3.TabIndex = 9;
            // 
            // exchange3
            // 
            this.exchange3.Location = new System.Drawing.Point(114, 139);
            this.exchange3.Name = "exchange3";
            this.exchange3.Size = new System.Drawing.Size(134, 21);
            this.exchange3.TabIndex = 10;
            // 
            // insttype3
            // 
            this.insttype3.FormattingEnabled = true;
            this.insttype3.Location = new System.Drawing.Point(114, 298);
            this.insttype3.Name = "insttype3";
            this.insttype3.Size = new System.Drawing.Size(134, 20);
            this.insttype3.TabIndex = 14;
            this.insttype3.SelectedIndexChanged += new System.EventHandler(this.insttype3_SelectedIndexChanged);
            // 
            // call3
            // 
            this.call3.AutoSize = true;
            this.call3.Location = new System.Drawing.Point(125, 247);
            this.call3.Name = "call3";
            this.call3.Size = new System.Drawing.Size(47, 16);
            this.call3.TabIndex = 15;
            this.call3.TabStop = true;
            this.call3.Text = "Call";
            this.call3.UseVisualStyleBackColor = true;
            // 
            // put3
            // 
            this.put3.AutoSize = true;
            this.put3.Location = new System.Drawing.Point(193, 247);
            this.put3.Name = "put3";
            this.put3.Size = new System.Drawing.Size(41, 16);
            this.put3.TabIndex = 16;
            this.put3.TabStop = true;
            this.put3.Text = "Put";
            this.put3.UseVisualStyleBackColor = true;
            // 
            // neither3
            // 
            this.neither3.AutoSize = true;
            this.neither3.Location = new System.Drawing.Point(125, 269);
            this.neither3.Name = "neither3";
            this.neither3.Size = new System.Drawing.Size(65, 16);
            this.neither3.TabIndex = 17;
            this.neither3.TabStop = true;
            this.neither3.Text = "Neither";
            this.neither3.UseVisualStyleBackColor = true;
            // 
            // add3
            // 
            this.add3.Location = new System.Drawing.Point(51, 329);
            this.add3.Name = "add3";
            this.add3.Size = new System.Drawing.Size(75, 23);
            this.add3.TabIndex = 18;
            this.add3.Text = "Add";
            this.add3.UseVisualStyleBackColor = true;
            this.add3.Click += new System.EventHandler(this.add3_Click);
            // 
            // cancel3
            // 
            this.cancel3.Location = new System.Drawing.Point(159, 329);
            this.cancel3.Name = "cancel3";
            this.cancel3.Size = new System.Drawing.Size(75, 23);
            this.cancel3.TabIndex = 19;
            this.cancel3.Text = "Cancel";
            this.cancel3.UseVisualStyleBackColor = true;
            this.cancel3.Click += new System.EventHandler(this.cancel3_Click);
            // 
            // strike3
            // 
            this.strike3.Location = new System.Drawing.Point(114, 194);
            this.strike3.Name = "strike3";
            this.strike3.Size = new System.Drawing.Size(134, 21);
            this.strike3.TabIndex = 20;
            // 
            // tenor3
            // 
            this.tenor3.Location = new System.Drawing.Point(114, 221);
            this.tenor3.Name = "tenor3";
            this.tenor3.Size = new System.Drawing.Size(134, 21);
            this.tenor3.TabIndex = 21;
            // 
            // underlying3
            // 
            this.underlying3.AutoSize = true;
            this.underlying3.Location = new System.Drawing.Point(112, 170);
            this.underlying3.Name = "underlying3";
            this.underlying3.Size = new System.Drawing.Size(0, 12);
            this.underlying3.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 72);
            this.label9.TabIndex = 24;
            this.label9.Text = "Notice: Ticker is very import, please \r\n        make it specificlly.\r\n\r\nExample: " +
    "MSFTC50Euro means Underlying is \r\n         MSFT, Call EuropeanOption with 50 \r\n " +
    "        Strike Price";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(112, 170);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(47, 12);
            this.label.TabIndex = 25;
            this.label.Text = "label10";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 362);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.underlying3);
            this.Controls.Add(this.tenor3);
            this.Controls.Add(this.strike3);
            this.Controls.Add(this.cancel3);
            this.Controls.Add(this.add3);
            this.Controls.Add(this.neither3);
            this.Controls.Add(this.put3);
            this.Controls.Add(this.call3);
            this.Controls.Add(this.insttype3);
            this.Controls.Add(this.exchange3);
            this.Controls.Add(this.ticker3);
            this.Controls.Add(this.companyname3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Instrument";
            ((System.ComponentModel.ISupportInitialize)(this.strike3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenor3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox companyname3;
        private System.Windows.Forms.TextBox ticker3;
        private System.Windows.Forms.TextBox exchange3;
        private System.Windows.Forms.ComboBox insttype3;
        private System.Windows.Forms.RadioButton call3;
        private System.Windows.Forms.RadioButton put3;
        private System.Windows.Forms.RadioButton neither3;
        private System.Windows.Forms.Button add3;
        private System.Windows.Forms.Button cancel3;
        private System.Windows.Forms.NumericUpDown strike3;
        private System.Windows.Forms.NumericUpDown tenor3;
        private System.Windows.Forms.Label underlying3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label;
    }
}