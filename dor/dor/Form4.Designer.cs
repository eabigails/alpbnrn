namespace dor
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
            this.labeldesc = new System.Windows.Forms.Label();
            this.labelSelectedDate = new System.Windows.Forms.Label();
            this.panelSeats = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labeldesc
            // 
            this.labeldesc.AutoSize = true;
            this.labeldesc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labeldesc.Location = new System.Drawing.Point(12, 18);
            this.labeldesc.Name = "labeldesc";
            this.labeldesc.Size = new System.Drawing.Size(44, 16);
            this.labeldesc.TabIndex = 0;
            this.labeldesc.Text = "label1";
            // 
            // labelSelectedDate
            // 
            this.labelSelectedDate.AutoSize = true;
            this.labelSelectedDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSelectedDate.Location = new System.Drawing.Point(12, 44);
            this.labelSelectedDate.Name = "labelSelectedDate";
            this.labelSelectedDate.Size = new System.Drawing.Size(44, 16);
            this.labelSelectedDate.TabIndex = 1;
            this.labelSelectedDate.Text = "label1";
            // 
            // panelSeats
            // 
            this.panelSeats.Location = new System.Drawing.Point(180, 66);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(919, 753);
            this.panelSeats.TabIndex = 2;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1139, 831);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.labelSelectedDate);
            this.Controls.Add(this.labeldesc);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeldesc;
        private System.Windows.Forms.Label labelSelectedDate;
        private System.Windows.Forms.Panel panelSeats;
    }
}