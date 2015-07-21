namespace Portfolio_Manager
{
    partial class Form5
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
            this.ok5 = new System.Windows.Forms.Button();
            this.cancel5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tenor5 = new System.Windows.Forms.NumericUpDown();
            this.rate5 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tenor5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tenor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rate:";
            // 
            // ok5
            // 
            this.ok5.Location = new System.Drawing.Point(28, 88);
            this.ok5.Name = "ok5";
            this.ok5.Size = new System.Drawing.Size(58, 23);
            this.ok5.TabIndex = 4;
            this.ok5.Text = "OK";
            this.ok5.UseVisualStyleBackColor = true;
            this.ok5.Click += new System.EventHandler(this.ok5_Click);
            // 
            // cancel5
            // 
            this.cancel5.Location = new System.Drawing.Point(101, 88);
            this.cancel5.Name = "cancel5";
            this.cancel5.Size = new System.Drawing.Size(58, 23);
            this.cancel5.TabIndex = 5;
            this.cancel5.Text = "Cancel";
            this.cancel5.UseVisualStyleBackColor = true;
            this.cancel5.Click += new System.EventHandler(this.cancel5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "Notice: Tenor for 1 year is 1,\r\n        for 6 month is 0.5,\r\n        for 3 month " +
    "is 0.25.";
            // 
            // tenor5
            // 
            this.tenor5.DecimalPlaces = 2;
            this.tenor5.Location = new System.Drawing.Point(79, 23);
            this.tenor5.Name = "tenor5";
            this.tenor5.Size = new System.Drawing.Size(80, 21);
            this.tenor5.TabIndex = 7;
            // 
            // rate5
            // 
            this.rate5.DecimalPlaces = 2;
            this.rate5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.rate5.Location = new System.Drawing.Point(79, 53);
            this.rate5.Name = "rate5";
            this.rate5.Size = new System.Drawing.Size(80, 21);
            this.rate5.TabIndex = 8;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 169);
            this.Controls.Add(this.rate5);
            this.Controls.Add(this.tenor5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel5);
            this.Controls.Add(this.ok5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Interest Rate";
            ((System.ComponentModel.ISupportInitialize)(this.tenor5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ok5;
        private System.Windows.Forms.Button cancel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tenor5;
        private System.Windows.Forms.NumericUpDown rate5;
    }
}