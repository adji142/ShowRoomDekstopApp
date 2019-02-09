namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmPengeluaranUangAcc
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmdSimpan = new ISA.Controls.CommandButton();
            this.cmdBatal = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(216, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 18);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Acc";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cmdSimpan
            // 
            this.cmdSimpan.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSimpan.Location = new System.Drawing.Point(118, 152);
            this.cmdSimpan.Name = "cmdSimpan";
            this.cmdSimpan.Size = new System.Drawing.Size(100, 40);
            this.cmdSimpan.TabIndex = 6;
            this.cmdSimpan.Text = "Simpan";
            this.cmdSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSimpan.UseVisualStyleBackColor = true;
            // 
            // cmdBatal
            // 
            this.cmdBatal.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdBatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdBatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBatal.Location = new System.Drawing.Point(243, 152);
            this.cmdBatal.Name = "cmdBatal";
            this.cmdBatal.Size = new System.Drawing.Size(100, 40);
            this.cmdBatal.TabIndex = 7;
            this.cmdBatal.Text = "Batal";
            this.cmdBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBatal.UseVisualStyleBackColor = true;
            this.cmdBatal.Click += new System.EventHandler(this.cmdBatal_Click);
            // 
            // frmPengeluaranUangAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(497, 219);
            this.Controls.Add(this.cmdSimpan);
            this.Controls.Add(this.cmdBatal);
            this.Controls.Add(this.checkBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPengeluaranUangAcc";
            this.Text = "Acc Pengeluaran Uang";
            this.Title = "Acc Pengeluaran Uang";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.cmdBatal, 0);
            this.Controls.SetChildIndex(this.cmdSimpan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private ISA.Controls.CommandButton cmdSimpan;
        private ISA.Controls.CommandButton cmdBatal;
    }
}
