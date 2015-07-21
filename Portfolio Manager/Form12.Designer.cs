namespace Portfolio_Manager
{
    partial class Form12
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
            this.instrument12 = new System.Windows.Forms.ComboBox();
            this.data12 = new System.Windows.Forms.DataGridView();
            this.ok12 = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data12)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instrument:";
            // 
            // instrument12
            // 
            this.instrument12.FormattingEnabled = true;
            this.instrument12.Location = new System.Drawing.Point(89, 6);
            this.instrument12.Name = "instrument12";
            this.instrument12.Size = new System.Drawing.Size(121, 20);
            this.instrument12.TabIndex = 1;
            this.instrument12.SelectedIndexChanged += new System.EventHandler(this.instrument12_SelectedIndexChanged);
            // 
            // data12
            // 
            this.data12.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.data12.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.data12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data12.Location = new System.Drawing.Point(14, 32);
            this.data12.Name = "data12";
            this.data12.RowHeadersWidth = 21;
            this.data12.RowTemplate.Height = 23;
            this.data12.Size = new System.Drawing.Size(307, 150);
            this.data12.TabIndex = 2;
            // 
            // ok12
            // 
            this.ok12.Location = new System.Drawing.Point(75, 197);
            this.ok12.Name = "ok12";
            this.ok12.Size = new System.Drawing.Size(59, 23);
            this.ok12.TabIndex = 3;
            this.ok12.Text = "Refresh";
            this.ok12.UseVisualStyleBackColor = true;
            this.ok12.Click += new System.EventHandler(this.ok12_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(192, 196);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(67, 25);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 234);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok12);
            this.Controls.Add(this.data12);
            this.Controls.Add(this.instrument12);
            this.Controls.Add(this.label1);
            this.Name = "Form12";
            this.Text = "Price Analysis";
            this.Load += new System.EventHandler(this.Form12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox instrument12;
        private System.Windows.Forms.DataGridView data12;
        private System.Windows.Forms.Button ok12;
        private System.Windows.Forms.Button cancel;
    }
}