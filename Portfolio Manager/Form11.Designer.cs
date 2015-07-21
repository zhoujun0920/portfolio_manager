namespace Portfolio_Manager
{
    partial class Form11
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
            this.antithetic = new System.Windows.Forms.CheckBox();
            this.dcv = new System.Windows.Forms.CheckBox();
            this.multi = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.simulate11 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trail11 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.step11 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trail11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step11)).BeginInit();
            this.SuspendLayout();
            // 
            // antithetic
            // 
            this.antithetic.AutoSize = true;
            this.antithetic.Location = new System.Drawing.Point(12, 12);
            this.antithetic.Name = "antithetic";
            this.antithetic.Size = new System.Drawing.Size(174, 16);
            this.antithetic.TabIndex = 0;
            this.antithetic.Text = "Antithemtic Random Number";
            this.antithetic.UseVisualStyleBackColor = true;
            // 
            // dcv
            // 
            this.dcv.AutoSize = true;
            this.dcv.Location = new System.Drawing.Point(12, 34);
            this.dcv.Name = "dcv";
            this.dcv.Size = new System.Drawing.Size(186, 16);
            this.dcv.TabIndex = 1;
            this.dcv.Text = "Delta Based Control Variate";
            this.dcv.UseVisualStyleBackColor = true;
            // 
            // multi
            // 
            this.multi.AutoSize = true;
            this.multi.Enabled = false;
            this.multi.Location = new System.Drawing.Point(12, 56);
            this.multi.Name = "multi";
            this.multi.Size = new System.Drawing.Size(156, 16);
            this.multi.TabIndex = 2;
            this.multi.Text = "Multithreading Process";
            this.multi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Core Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "0";
            // 
            // simulate11
            // 
            this.simulate11.Location = new System.Drawing.Point(21, 136);
            this.simulate11.Name = "simulate11";
            this.simulate11.Size = new System.Drawing.Size(75, 23);
            this.simulate11.TabIndex = 5;
            this.simulate11.Text = "Simulate";
            this.simulate11.UseVisualStyleBackColor = true;
            this.simulate11.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trail:";
            // 
            // trail11
            // 
            this.trail11.Location = new System.Drawing.Point(47, 80);
            this.trail11.Name = "trail11";
            this.trail11.Size = new System.Drawing.Size(49, 21);
            this.trail11.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Steps:";
            // 
            // step11
            // 
            this.step11.Location = new System.Drawing.Point(137, 80);
            this.step11.Name = "step11";
            this.step11.Size = new System.Drawing.Size(49, 21);
            this.step11.TabIndex = 10;
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 171);
            this.Controls.Add(this.step11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trail11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.simulate11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.multi);
            this.Controls.Add(this.dcv);
            this.Controls.Add(this.antithetic);
            this.Name = "Form11";
            this.Text = "Price Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.trail11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox antithetic;
        private System.Windows.Forms.CheckBox dcv;
        private System.Windows.Forms.CheckBox multi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button simulate11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown trail11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown step11;
    }
}