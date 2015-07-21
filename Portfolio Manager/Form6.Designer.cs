namespace Portfolio_Manager
{
    partial class Form6
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
            this.instrument6 = new System.Windows.Forms.ComboBox();
            this.timestamp6 = new System.Windows.Forms.Label();
            this.add6 = new System.Windows.Forms.Button();
            this.cancel6 = new System.Windows.Forms.Button();
            this.price6 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.price6)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Timestamp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Instrument:";
            // 
            // instrument6
            // 
            this.instrument6.FormattingEnabled = true;
            this.instrument6.Location = new System.Drawing.Point(88, 19);
            this.instrument6.Name = "instrument6";
            this.instrument6.Size = new System.Drawing.Size(124, 20);
            this.instrument6.TabIndex = 5;
            // 
            // timestamp6
            // 
            this.timestamp6.AutoSize = true;
            this.timestamp6.Location = new System.Drawing.Point(73, 78);
            this.timestamp6.Name = "timestamp6";
            this.timestamp6.Size = new System.Drawing.Size(89, 12);
            this.timestamp6.TabIndex = 6;
            this.timestamp6.Text = "Month/Day/Year";
            // 
            // add6
            // 
            this.add6.Location = new System.Drawing.Point(40, 113);
            this.add6.Name = "add6";
            this.add6.Size = new System.Drawing.Size(58, 23);
            this.add6.TabIndex = 7;
            this.add6.Text = "Add";
            this.add6.UseVisualStyleBackColor = true;
            this.add6.Click += new System.EventHandler(this.add6_Click);
            // 
            // cancel6
            // 
            this.cancel6.Location = new System.Drawing.Point(124, 113);
            this.cancel6.Name = "cancel6";
            this.cancel6.Size = new System.Drawing.Size(58, 23);
            this.cancel6.TabIndex = 8;
            this.cancel6.Text = "Cancel";
            this.cancel6.UseVisualStyleBackColor = true;
            this.cancel6.Click += new System.EventHandler(this.cancel6_Click);
            // 
            // price6
            // 
            this.price6.Location = new System.Drawing.Point(88, 48);
            this.price6.Name = "price6";
            this.price6.Size = new System.Drawing.Size(124, 21);
            this.price6.TabIndex = 9;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 158);
            this.Controls.Add(this.price6);
            this.Controls.Add(this.cancel6);
            this.Controls.Add(this.add6);
            this.Controls.Add(this.timestamp6);
            this.Controls.Add(this.instrument6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Historical Price";
            ((System.ComponentModel.ISupportInitialize)(this.price6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox instrument6;
        private System.Windows.Forms.Label timestamp6;
        private System.Windows.Forms.Button add6;
        private System.Windows.Forms.Button cancel6;
        private System.Windows.Forms.NumericUpDown price6;
    }
}