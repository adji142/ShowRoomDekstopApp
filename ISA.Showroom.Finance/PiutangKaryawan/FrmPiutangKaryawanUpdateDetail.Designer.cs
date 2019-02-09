namespace ISA.Showroom.Finance.PiutangKaryawan
{
    partial class FrmPiutangKaryawanUpdateDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPiutangKaryawanUpdateDetail));
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNominalDetail = new ISA.Controls.NumericTextBox();
            this.txtKeteranganDetail = new ISA.Controls.CommonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoBuktiDetail = new ISA.Controls.CommonTextBox();
            this.txtTanggalDetail = new ISA.Controls.DateTextBox();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboKas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoPembayaran = new System.Windows.Forms.RadioButton();
            this.rdoPotongan = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNamaPeminjam = new ISA.Controls.CommonTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSaldoPinjaman = new ISA.Controls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "No.Bukti";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tanggal";
            // 
            // txtNominalDetail
            // 
            this.txtNominalDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNominalDetail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNominalDetail.Location = new System.Drawing.Point(96, 165);
            this.txtNominalDetail.Name = "txtNominalDetail";
            this.txtNominalDetail.Size = new System.Drawing.Size(126, 23);
            this.txtNominalDetail.TabIndex = 4;
            this.txtNominalDetail.Text = "0";
            this.txtNominalDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKeteranganDetail
            // 
            this.txtKeteranganDetail.AcceptsTab = true;
            this.txtKeteranganDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtKeteranganDetail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeteranganDetail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeteranganDetail.Location = new System.Drawing.Point(96, 81);
            this.txtKeteranganDetail.Multiline = true;
            this.txtKeteranganDetail.Name = "txtKeteranganDetail";
            this.txtKeteranganDetail.Size = new System.Drawing.Size(354, 49);
            this.txtKeteranganDetail.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Nominal";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "Keterangan";
            // 
            // txtNoBuktiDetail
            // 
            this.txtNoBuktiDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoBuktiDetail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBuktiDetail.Enabled = false;
            this.txtNoBuktiDetail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoBuktiDetail.Location = new System.Drawing.Point(96, 24);
            this.txtNoBuktiDetail.Name = "txtNoBuktiDetail";
            this.txtNoBuktiDetail.ReadOnly = true;
            this.txtNoBuktiDetail.Size = new System.Drawing.Size(175, 23);
            this.txtNoBuktiDetail.TabIndex = 0;
            this.txtNoBuktiDetail.TabStop = false;
            // 
            // txtTanggalDetail
            // 
            this.txtTanggalDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTanggalDetail.DateValue = null;
            this.txtTanggalDetail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTanggalDetail.Location = new System.Drawing.Point(96, 52);
            this.txtTanggalDetail.MaxLength = 10;
            this.txtTanggalDetail.Name = "txtTanggalDetail";
            this.txtTanggalDetail.Size = new System.Drawing.Size(126, 23);
            this.txtTanggalDetail.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(317, 391);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(211, 391);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cboKas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNoBuktiDetail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTanggalDetail);
            this.groupBox1.Controls.Add(this.txtKeteranganDetail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNominalDetail);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(186, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 200);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cboKas
            // 
            this.cboKas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboKas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboKas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKas.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKas.FormattingEnabled = true;
            this.cboKas.Location = new System.Drawing.Point(96, 136);
            this.cboKas.Name = "cboKas";
            this.cboKas.Size = new System.Drawing.Size(90, 23);
            this.cboKas.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Kas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 29;
            // 
            // rdoPembayaran
            // 
            this.rdoPembayaran.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdoPembayaran.AutoSize = true;
            this.rdoPembayaran.Enabled = false;
            this.rdoPembayaran.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPembayaran.Location = new System.Drawing.Point(7, 23);
            this.rdoPembayaran.Name = "rdoPembayaran";
            this.rdoPembayaran.Size = new System.Drawing.Size(94, 19);
            this.rdoPembayaran.TabIndex = 0;
            this.rdoPembayaran.Text = "Pembayaran";
            this.rdoPembayaran.UseVisualStyleBackColor = true;
            this.rdoPembayaran.CheckedChanged += new System.EventHandler(this.rdoPembayaran_CheckedChanged);
            // 
            // rdoPotongan
            // 
            this.rdoPotongan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdoPotongan.AutoSize = true;
            this.rdoPotongan.Enabled = false;
            this.rdoPotongan.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPotongan.Location = new System.Drawing.Point(7, 45);
            this.rdoPotongan.Name = "rdoPotongan";
            this.rdoPotongan.Size = new System.Drawing.Size(77, 19);
            this.rdoPotongan.TabIndex = 1;
            this.rdoPotongan.Text = "Potongan";
            this.rdoPotongan.UseVisualStyleBackColor = true;
            this.rdoPotongan.CheckedChanged += new System.EventHandler(this.rdoPotongan_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.rdoPotongan);
            this.groupBox2.Controls.Add(this.rdoPembayaran);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(43, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 73);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ Kategori ]";
            // 
            // txtNamaPeminjam
            // 
            this.txtNamaPeminjam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNamaPeminjam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaPeminjam.Enabled = false;
            this.txtNamaPeminjam.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaPeminjam.Location = new System.Drawing.Point(186, 88);
            this.txtNamaPeminjam.Name = "txtNamaPeminjam";
            this.txtNamaPeminjam.ReadOnly = true;
            this.txtNamaPeminjam.Size = new System.Drawing.Size(282, 23);
            this.txtNamaPeminjam.TabIndex = 0;
            this.txtNamaPeminjam.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(48, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 15);
            this.label13.TabIndex = 37;
            this.label13.Text = "Nama Peminjam";
            // 
            // txtSaldoPinjaman
            // 
            this.txtSaldoPinjaman.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSaldoPinjaman.Enabled = false;
            this.txtSaldoPinjaman.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoPinjaman.Location = new System.Drawing.Point(186, 121);
            this.txtSaldoPinjaman.Name = "txtSaldoPinjaman";
            this.txtSaldoPinjaman.ReadOnly = true;
            this.txtSaldoPinjaman.Size = new System.Drawing.Size(141, 23);
            this.txtSaldoPinjaman.TabIndex = 1;
            this.txtSaldoPinjaman.TabStop = false;
            this.txtSaldoPinjaman.Text = "0";
            this.txtSaldoPinjaman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(48, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "Saldo Pinjaman";
            // 
            // FrmPiutangKaryawanUpdateDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(695, 443);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtSaldoPinjaman);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNamaPeminjam);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmPiutangKaryawanUpdateDetail";
            this.Text = "Pembayaran PK";
            this.Title = "Pembayaran PK";
            this.Load += new System.EventHandler(this.PiutangKaryawanUpdateDetail_Load);
            this.Shown += new System.EventHandler(this.FrmPiutangKaryawanUpdateDetail_Shown);
            this.Controls.SetChildIndex(this.txtNamaPeminjam, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtSaldoPinjaman, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.NumericTextBox txtNominalDetail;
        private ISA.Controls.CommonTextBox txtKeteranganDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private ISA.Controls.CommonTextBox txtNoBuktiDetail;
        private ISA.Controls.DateTextBox txtTanggalDetail;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPotongan;
        private System.Windows.Forms.RadioButton rdoPembayaran;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtNamaPeminjam;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.NumericTextBox txtSaldoPinjaman;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboKas;
        private System.Windows.Forms.Label label4;
    }
}
