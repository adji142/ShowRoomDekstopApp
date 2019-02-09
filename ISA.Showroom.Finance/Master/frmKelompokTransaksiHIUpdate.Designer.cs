namespace ISA.Showroom.Finance.Master
{
    partial class frmKelompokTransaksiHIUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKelompokTransaksiHIUpdate));
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJnsTransaksi = new ISA.Controls.CommonTextBox();
            this.txtNamaTransaksi = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsAktif = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpJnsArus = new System.Windows.Forms.GroupBox();
            this.rdoPengeluaran = new System.Windows.Forms.RadioButton();
            this.rdoPenerimaan = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboUserAcc1 = new System.Windows.Forms.ComboBox();
            this.cboUserAcc2 = new System.Windows.Forms.ComboBox();
            this.cboPerkiraan1 = new System.Windows.Forms.ComboBox();
            this.cboPerkiraan2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.chkIsUploadable = new System.Windows.Forms.CheckBox();
            this.grpJnsArus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(305, 289);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 9;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(168, 289);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 8;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Keterangan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kode";
            // 
            // txtJnsTransaksi
            // 
            this.txtJnsTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJnsTransaksi.Location = new System.Drawing.Point(196, 79);
            this.txtJnsTransaksi.MaxLength = 2;
            this.txtJnsTransaksi.Name = "txtJnsTransaksi";
            this.txtJnsTransaksi.Size = new System.Drawing.Size(30, 20);
            this.txtJnsTransaksi.TabIndex = 10;
            // 
            // txtNamaTransaksi
            // 
            this.txtNamaTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaTransaksi.Location = new System.Drawing.Point(196, 104);
            this.txtNamaTransaksi.MaxLength = 25;
            this.txtNamaTransaksi.Name = "txtNamaTransaksi";
            this.txtNamaTransaksi.Size = new System.Drawing.Size(275, 20);
            this.txtNamaTransaksi.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "No.Perkiraan 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "No. Perkiraan 1";
            // 
            // chkIsAktif
            // 
            this.chkIsAktif.AutoSize = true;
            this.chkIsAktif.Location = new System.Drawing.Point(196, 172);
            this.chkIsAktif.Name = "chkIsAktif";
            this.chkIsAktif.Size = new System.Drawing.Size(15, 14);
            this.chkIsAktif.TabIndex = 22;
            this.chkIsAktif.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Arus ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Aktif";
            // 
            // grpJnsArus
            // 
            this.grpJnsArus.Controls.Add(this.rdoPengeluaran);
            this.grpJnsArus.Controls.Add(this.rdoPenerimaan);
            this.grpJnsArus.Location = new System.Drawing.Point(196, 126);
            this.grpJnsArus.Name = "grpJnsArus";
            this.grpJnsArus.Size = new System.Drawing.Size(226, 40);
            this.grpJnsArus.TabIndex = 25;
            this.grpJnsArus.TabStop = false;
            // 
            // rdoPengeluaran
            // 
            this.rdoPengeluaran.AutoSize = true;
            this.rdoPengeluaran.Location = new System.Drawing.Point(115, 13);
            this.rdoPengeluaran.Name = "rdoPengeluaran";
            this.rdoPengeluaran.Size = new System.Drawing.Size(94, 18);
            this.rdoPengeluaran.TabIndex = 1;
            this.rdoPengeluaran.TabStop = true;
            this.rdoPengeluaran.Text = "Pengeluaran";
            this.rdoPengeluaran.UseVisualStyleBackColor = true;
            this.rdoPengeluaran.CheckedChanged += new System.EventHandler(this.rdoPengeluaran_CheckedChanged);
            // 
            // rdoPenerimaan
            // 
            this.rdoPenerimaan.AutoSize = true;
            this.rdoPenerimaan.Location = new System.Drawing.Point(6, 13);
            this.rdoPenerimaan.Name = "rdoPenerimaan";
            this.rdoPenerimaan.Size = new System.Drawing.Size(90, 18);
            this.rdoPenerimaan.TabIndex = 0;
            this.rdoPenerimaan.TabStop = true;
            this.rdoPenerimaan.Text = "Pemasukan";
            this.rdoPenerimaan.UseVisualStyleBackColor = true;
            this.rdoPenerimaan.CheckedChanged += new System.EventHandler(this.rdoPenerimaan_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "Acc 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 14);
            this.label8.TabIndex = 27;
            this.label8.Text = "Acc 2";
            // 
            // cboUserAcc1
            // 
            this.cboUserAcc1.FormattingEnabled = true;
            this.cboUserAcc1.Location = new System.Drawing.Point(61, 2);
            this.cboUserAcc1.Name = "cboUserAcc1";
            this.cboUserAcc1.Size = new System.Drawing.Size(145, 22);
            this.cboUserAcc1.TabIndex = 28;
            // 
            // cboUserAcc2
            // 
            this.cboUserAcc2.FormattingEnabled = true;
            this.cboUserAcc2.Location = new System.Drawing.Point(61, 28);
            this.cboUserAcc2.Name = "cboUserAcc2";
            this.cboUserAcc2.Size = new System.Drawing.Size(145, 22);
            this.cboUserAcc2.TabIndex = 29;
            // 
            // cboPerkiraan1
            // 
            this.cboPerkiraan1.FormattingEnabled = true;
            this.cboPerkiraan1.Location = new System.Drawing.Point(196, 213);
            this.cboPerkiraan1.Name = "cboPerkiraan1";
            this.cboPerkiraan1.Size = new System.Drawing.Size(197, 22);
            this.cboPerkiraan1.TabIndex = 30;
            // 
            // cboPerkiraan2
            // 
            this.cboPerkiraan2.FormattingEnabled = true;
            this.cboPerkiraan2.Location = new System.Drawing.Point(196, 239);
            this.cboPerkiraan2.Name = "cboPerkiraan2";
            this.cboPerkiraan2.Size = new System.Drawing.Size(197, 22);
            this.cboPerkiraan2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboUserAcc1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboUserAcc2);
            this.panel1.Location = new System.Drawing.Point(428, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 47);
            this.panel1.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 14);
            this.label9.TabIndex = 34;
            this.label9.Text = "Upload ke 00";
            // 
            // chkIsUploadable
            // 
            this.chkIsUploadable.AutoSize = true;
            this.chkIsUploadable.Location = new System.Drawing.Point(196, 192);
            this.chkIsUploadable.Name = "chkIsUploadable";
            this.chkIsUploadable.Size = new System.Drawing.Size(15, 14);
            this.chkIsUploadable.TabIndex = 33;
            this.chkIsUploadable.UseVisualStyleBackColor = true;
            // 
            // frmKelompokTransaksiHIUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkIsUploadable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboPerkiraan2);
            this.Controls.Add(this.cboPerkiraan1);
            this.Controls.Add(this.grpJnsArus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIsAktif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJnsTransaksi);
            this.Controls.Add(this.txtNamaTransaksi);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKelompokTransaksiHIUpdate";
            this.Text = "Jenis Transaksi";
            this.Title = "Jenis Transaksi";
            this.Load += new System.EventHandler(this.frmJnsTransaksiUpdate_Load);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtNamaTransaksi, 0);
            this.Controls.SetChildIndex(this.txtJnsTransaksi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.chkIsAktif, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.grpJnsArus, 0);
            this.Controls.SetChildIndex(this.cboPerkiraan1, 0);
            this.Controls.SetChildIndex(this.cboPerkiraan2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkIsUploadable, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.grpJnsArus.ResumeLayout(false);
            this.grpJnsArus.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtJnsTransaksi;
        private ISA.Controls.CommonTextBox txtNamaTransaksi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsAktif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpJnsArus;
        private System.Windows.Forms.RadioButton rdoPengeluaran;
        private System.Windows.Forms.RadioButton rdoPenerimaan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboUserAcc1;
        private System.Windows.Forms.ComboBox cboUserAcc2;
        private System.Windows.Forms.ComboBox cboPerkiraan1;
        private System.Windows.Forms.ComboBox cboPerkiraan2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkIsUploadable;
    }
}
