namespace Portfolio_Manager
{
    partial class Form9
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
            this.cancel5 = new System.Windows.Forms.Button();
            this.ok5 = new System.Windows.Forms.Button();
            this.rate5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.update5 = new System.Windows.Forms.Button();
            this.id5 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tenor5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancel5
            // 
            this.cancel5.Location = new System.Drawing.Point(152, 109);
            this.cancel5.Name = "cancel5";
            this.cancel5.Size = new System.Drawing.Size(64, 23);
            this.cancel5.TabIndex = 11;
            this.cancel5.Text = "Cancel";
            this.cancel5.UseVisualStyleBackColor = true;
            this.cancel5.Click += new System.EventHandler(this.cancel5_Click);
            // 
            // ok5
            // 
            this.ok5.Location = new System.Drawing.Point(16, 109);
            this.ok5.Name = "ok5";
            this.ok5.Size = new System.Drawing.Size(52, 23);
            this.ok5.TabIndex = 10;
            this.ok5.Text = "Delete";
            this.ok5.UseVisualStyleBackColor = true;
            this.ok5.Click += new System.EventHandler(this.ok5_Click);
            // 
            // rate5
            // 
            this.rate5.Location = new System.Drawing.Point(80, 73);
            this.rate5.Name = "rate5";
            this.rate5.Size = new System.Drawing.Size(108, 21);
            this.rate5.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tenor:";
            // 
            // update5
            // 
            this.update5.Location = new System.Drawing.Point(80, 109);
            this.update5.Name = "update5";
            this.update5.Size = new System.Drawing.Size(66, 23);
            this.update5.TabIndex = 12;
            this.update5.Text = "Update";
            this.update5.UseVisualStyleBackColor = true;
            this.update5.Click += new System.EventHandler(this.update5_Click);
            // 
            // id5
            // 
            this.id5.FormattingEnabled = true;
            this.id5.Location = new System.Drawing.Point(80, 16);
            this.id5.Name = "id5";
            this.id5.Size = new System.Drawing.Size(108, 20);
            this.id5.TabIndex = 13;
            this.id5.SelectedIndexChanged += new System.EventHandler(this.id5_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "Id:";
            // 
            // tenor5
            // 
            this.tenor5.Location = new System.Drawing.Point(80, 43);
            this.tenor5.Name = "tenor5";
            this.tenor5.Size = new System.Drawing.Size(108, 21);
            this.tenor5.TabIndex = 15;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 150);
            this.Controls.Add(this.tenor5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.id5);
            this.Controls.Add(this.update5);
            this.Controls.Add(this.cancel5);
            this.Controls.Add(this.ok5);
            this.Controls.Add(this.rate5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Interest Rate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel5;
        private System.Windows.Forms.Button ok5;
        private System.Windows.Forms.TextBox rate5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button update5;
        private System.Windows.Forms.ComboBox id5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tenor5;
    }
}