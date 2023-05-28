namespace dor
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
            this.labelConcertName = new System.Windows.Forms.Label();
            this.labelCategoryName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelSelectedDate = new System.Windows.Forms.Label();
            this.minus = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.comboBox_transaksi = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelConcertName
            // 
            this.labelConcertName.AutoSize = true;
            this.labelConcertName.Location = new System.Drawing.Point(103, 30);
            this.labelConcertName.Name = "labelConcertName";
            this.labelConcertName.Size = new System.Drawing.Size(44, 16);
            this.labelConcertName.TabIndex = 0;
            this.labelConcertName.Text = "label1";
            // 
            // labelCategoryName
            // 
            this.labelCategoryName.AutoSize = true;
            this.labelCategoryName.Location = new System.Drawing.Point(103, 83);
            this.labelCategoryName.Name = "labelCategoryName";
            this.labelCategoryName.Size = new System.Drawing.Size(44, 16);
            this.labelCategoryName.TabIndex = 1;
            this.labelCategoryName.Text = "label2";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(103, 129);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(44, 16);
            this.labelPrice.TabIndex = 2;
            this.labelPrice.Text = "label3";
            // 
            // labelSelectedDate
            // 
            this.labelSelectedDate.AutoSize = true;
            this.labelSelectedDate.Location = new System.Drawing.Point(103, 179);
            this.labelSelectedDate.Name = "labelSelectedDate";
            this.labelSelectedDate.Size = new System.Drawing.Size(44, 16);
            this.labelSelectedDate.TabIndex = 3;
            this.labelSelectedDate.Text = "label4";
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(53, 215);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(26, 23);
            this.minus.TabIndex = 4;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(162, 215);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(29, 23);
            this.add.TabIndex = 5;
            this.add.Text = "+";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(103, 218);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(44, 16);
            this.labelCount.TabIndex = 6;
            this.labelCount.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(147, 260);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(44, 16);
            this.label_total.TabIndex = 8;
            this.label_total.Text = "label2";
            // 
            // comboBox_transaksi
            // 
            this.comboBox_transaksi.FormattingEnabled = true;
            this.comboBox_transaksi.Location = new System.Drawing.Point(53, 289);
            this.comboBox_transaksi.Name = "comboBox_transaksi";
            this.comboBox_transaksi.Size = new System.Drawing.Size(121, 24);
            this.comboBox_transaksi.TabIndex = 9;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(652, 396);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click_1);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.comboBox_transaksi);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.add);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.labelSelectedDate);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelCategoryName);
            this.Controls.Add(this.labelConcertName);
            this.Name = "Form5";
            this.Text = "Form5cs";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConcertName;
        private System.Windows.Forms.Label labelCategoryName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelSelectedDate;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.ComboBox comboBox_transaksi;
        private System.Windows.Forms.Button btnConfirm;
    }
}