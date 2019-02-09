namespace ISA.Showroom.Laporan
{
    partial class frmLapStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapStock));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.rbSemua = new System.Windows.Forms.RadioButton();
            this.rbBekas = new System.Windows.Forms.RadioButton();
            this.rbBaru = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdPRINT = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbBeli = new System.Windows.Forms.RadioButton();
            this.rbTerima = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtTanggal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(72, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 195);
            this.panel1.TabIndex = 5;
            // 
            // txtTanggal
            // 
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(218, 40);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(95, 20);
            this.txtTanggal.TabIndex = 5;
            // 
            // rbSemua
            // 
            this.rbSemua.AutoSize = true;
            this.rbSemua.Location = new System.Drawing.Point(13, 55);
            this.rbSemua.Name = "rbSemua";
            this.rbSemua.Size = new System.Drawing.Size(63, 18);
            this.rbSemua.TabIndex = 4;
            this.rbSemua.Text = "Semua";
            this.rbSemua.UseVisualStyleBackColor = true;
            // 
            // rbBekas
            // 
            this.rbBekas.AutoSize = true;
            this.rbBekas.Location = new System.Drawing.Point(13, 32);
            this.rbBekas.Name = "rbBekas";
            this.rbBekas.Size = new System.Drawing.Size(59, 18);
            this.rbBekas.TabIndex = 3;
            this.rbBekas.Text = "Bekas";
            this.rbBekas.UseVisualStyleBackColor = true;
            // 
            // rbBaru
            // 
            this.rbBaru.AutoSize = true;
            this.rbBaru.Checked = true;
            this.rbBaru.Location = new System.Drawing.Point(13, 9);
            this.rbBaru.Name = "rbBaru";
            this.rbBaru.Size = new System.Drawing.Size(50, 18);
            this.rbBaru.TabIndex = 2;
            this.rbBaru.TabStop = true;
            this.rbBaru.Text = "Baru";
            this.rbBaru.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kondisi Kendaraan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tanggal";
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(160, 288);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 6;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(322, 288);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbBaru);
            this.panel2.Controls.Add(this.rbSemua);
            this.panel2.Controls.Add(this.rbBekas);
            this.panel2.Location = new System.Drawing.Point(218, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 80);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filter Berdasarkan";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbTerima);
            this.panel3.Controls.Add(this.rbBeli);
            this.panel3.Location = new System.Drawing.Point(217, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 22);
            this.panel3.TabIndex = 8;
            // 
            // rbBeli
            // 
            this.rbBeli.AutoSize = true;
            this.rbBeli.Checked = true;
            this.rbBeli.Location = new System.Drawing.Point(13, 3);
            this.rbBeli.Name = "rbBeli";
            this.rbBeli.Size = new System.Drawing.Size(65, 18);
            this.rbBeli.TabIndex = 0;
            this.rbBeli.TabStop = true;
            this.rbBeli.Text = "Tgl Beli";
            this.rbBeli.UseVisualStyleBackColor = true;
            this.rbBeli.CheckedChanged += new System.EventHandler(this.rbBeli_CheckedChanged);
            // 
            // rbTerima
            // 
            this.rbTerima.AutoSize = true;
            this.rbTerima.Location = new System.Drawing.Point(94, 3);
            this.rbTerima.Name = "rbTerima";
            this.rbTerima.Size = new System.Drawing.Size(83, 18);
            this.rbTerima.TabIndex = 1;
            this.rbTerima.Text = "Tgl Terima";
            this.rbTerima.UseVisualStyleBackColor = true;
            this.rbTerima.CheckedChanged += new System.EventHandler(this.rbTerima_CheckedChanged);
            // 
            // frmLapStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdPRINT);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLapStock";
            this.Text = "Laporan Stock";
            this.Title = "Laporan Stock";
            this.Load += new System.EventHandler(this.frmLapStock_Load);
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbSemua;
        private System.Windows.Forms.RadioButton rbBekas;
        private System.Windows.Forms.RadioButton rbBaru;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.DateTextBox txtTanggal;
        private ISA.Controls.CommandButton cmdPRINT;
        private ISA.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbTerima;
        private System.Windows.Forms.RadioButton rbBeli;
    }
}