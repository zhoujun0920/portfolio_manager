namespace Portfolio_Manager
{
    partial class Form2
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
            this.insttype2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.down_out2 = new System.Windows.Forms.RadioButton();
            this.down_in2 = new System.Windows.Forms.RadioButton();
            this.up_out2 = new System.Windows.Forms.RadioButton();
            this.up_in2 = new System.Windows.Forms.RadioButton();
            this.barrier2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rebate2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.floating2 = new System.Windows.Forms.RadioButton();
            this.fix2 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.underlying2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.add2 = new System.Windows.Forms.Button();
            this.cancel2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rebate2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inst Type Example:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "EuropeanOption";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Inst Type:";
            // 
            // insttype2
            // 
            this.insttype2.Location = new System.Drawing.Point(83, 100);
            this.insttype2.Name = "insttype2";
            this.insttype2.Size = new System.Drawing.Size(140, 21);
            this.insttype2.TabIndex = 4;
            this.insttype2.TextChanged += new System.EventHandler(this.insttype2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.down_out2);
            this.groupBox1.Controls.Add(this.down_in2);
            this.groupBox1.Controls.Add(this.up_out2);
            this.groupBox1.Controls.Add(this.up_in2);
            this.groupBox1.Controls.Add(this.barrier2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(14, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BarrierOption";
            // 
            // down_out2
            // 
            this.down_out2.AutoSize = true;
            this.down_out2.Enabled = false;
            this.down_out2.Location = new System.Drawing.Point(138, 39);
            this.down_out2.Name = "down_out2";
            this.down_out2.Size = new System.Drawing.Size(71, 16);
            this.down_out2.TabIndex = 5;
            this.down_out2.TabStop = true;
            this.down_out2.Text = "Down_Out";
            this.down_out2.UseVisualStyleBackColor = true;
            // 
            // down_in2
            // 
            this.down_in2.AutoSize = true;
            this.down_in2.Enabled = false;
            this.down_in2.Location = new System.Drawing.Point(75, 39);
            this.down_in2.Name = "down_in2";
            this.down_in2.Size = new System.Drawing.Size(65, 16);
            this.down_in2.TabIndex = 4;
            this.down_in2.TabStop = true;
            this.down_in2.Text = "Down_in";
            this.down_in2.UseVisualStyleBackColor = true;
            // 
            // up_out2
            // 
            this.up_out2.AutoSize = true;
            this.up_out2.Enabled = false;
            this.up_out2.Location = new System.Drawing.Point(141, 20);
            this.up_out2.Name = "up_out2";
            this.up_out2.Size = new System.Drawing.Size(59, 16);
            this.up_out2.TabIndex = 3;
            this.up_out2.Text = "Up_Out";
            this.up_out2.UseVisualStyleBackColor = true;
            // 
            // up_in2
            // 
            this.up_in2.AutoSize = true;
            this.up_in2.Enabled = false;
            this.up_in2.Location = new System.Drawing.Point(82, 20);
            this.up_in2.Name = "up_in2";
            this.up_in2.Size = new System.Drawing.Size(53, 16);
            this.up_in2.TabIndex = 2;
            this.up_in2.TabStop = true;
            this.up_in2.Text = "Up_In";
            this.up_in2.UseVisualStyleBackColor = true;
            // 
            // barrier2
            // 
            this.barrier2.Location = new System.Drawing.Point(18, 32);
            this.barrier2.Name = "barrier2";
            this.barrier2.ReadOnly = true;
            this.barrier2.Size = new System.Drawing.Size(45, 21);
            this.barrier2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Barrier";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rebate2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(14, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 63);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DigitalOption";
            // 
            // rebate2
            // 
            this.rebate2.Location = new System.Drawing.Point(18, 32);
            this.rebate2.Name = "rebate2";
            this.rebate2.ReadOnly = true;
            this.rebate2.Size = new System.Drawing.Size(63, 21);
            this.rebate2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rebate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.floating2);
            this.groupBox3.Controls.Add(this.fix2);
            this.groupBox3.Location = new System.Drawing.Point(120, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 63);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LookBackOption";
            // 
            // floating2
            // 
            this.floating2.AutoSize = true;
            this.floating2.Enabled = false;
            this.floating2.Location = new System.Drawing.Point(14, 39);
            this.floating2.Name = "floating2";
            this.floating2.Size = new System.Drawing.Size(71, 16);
            this.floating2.TabIndex = 1;
            this.floating2.TabStop = true;
            this.floating2.Text = "Floating";
            this.floating2.UseVisualStyleBackColor = true;
            // 
            // fix2
            // 
            this.fix2.AutoSize = true;
            this.fix2.Enabled = false;
            this.fix2.Location = new System.Drawing.Point(14, 17);
            this.fix2.Name = "fix2";
            this.fix2.Size = new System.Drawing.Size(53, 16);
            this.fix2.TabIndex = 0;
            this.fix2.TabStop = true;
            this.fix2.Text = "Fixed";
            this.fix2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "Underlying:";
            // 
            // underlying2
            // 
            this.underlying2.Location = new System.Drawing.Point(83, 128);
            this.underlying2.Name = "underlying2";
            this.underlying2.Size = new System.Drawing.Size(140, 21);
            this.underlying2.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "Underlying Example:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "MSFT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "Gold";
            // 
            // add2
            // 
            this.add2.Location = new System.Drawing.Point(39, 299);
            this.add2.Name = "add2";
            this.add2.Size = new System.Drawing.Size(75, 23);
            this.add2.TabIndex = 13;
            this.add2.Text = "Add";
            this.add2.UseVisualStyleBackColor = true;
            this.add2.Click += new System.EventHandler(this.add2_Click);
            // 
            // cancel2
            // 
            this.cancel2.Location = new System.Drawing.Point(127, 299);
            this.cancel2.Name = "cancel2";
            this.cancel2.Size = new System.Drawing.Size(75, 23);
            this.cancel2.TabIndex = 14;
            this.cancel2.Text = "Cancel";
            this.cancel2.UseVisualStyleBackColor = true;
            this.cancel2.Click += new System.EventHandler(this.cancel2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 329);
            this.Controls.Add(this.cancel2);
            this.Controls.Add(this.add2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.underlying2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.insttype2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Inst Type";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rebate2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox insttype2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton down_out2;
        private System.Windows.Forms.RadioButton down_in2;
        private System.Windows.Forms.RadioButton up_out2;
        private System.Windows.Forms.RadioButton up_in2;
        private System.Windows.Forms.NumericUpDown barrier2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown rebate2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton floating2;
        private System.Windows.Forms.RadioButton fix2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox underlying2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button add2;
        private System.Windows.Forms.Button cancel2;
    }
}