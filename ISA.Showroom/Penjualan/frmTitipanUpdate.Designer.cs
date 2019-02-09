namespace ISA.Showroom.Penjualan
{
    partial class frmTitipanUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTitipanUpdate));
            this.label5 = new System.Windows.Forms.Label();
            this.txtTglTitip = new ISA.Controls.DateTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbxBentukPembayaran = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTglBG = new ISA.Controls.DateTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoBG = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPembayaran = new ISA.Controls.NumericTextBox();
            this.cmdSaveTitipan = new ISA.Controls.CommandButton();
            this.cmdCloseTitipan = new ISA.Controls.CommandButton();
            this.txtNoTransaksi = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipeTitipan = new System.Windows.Forms.ComboBox();
            this.lblMotor = new System.Windows.Forms.Label();
            this.lookUpStokMotor1 = new ISA.Showroom.Controls.LookUpStokMotor();
            this.lucPelanggan = new ISA.Showroom.Controls.LookUpCustomer();
            this.lookUpRekening1 = new ISA.Showroom.Controls.LookUpRekening();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 88;
            this.label5.Text = "Pelanggan";
            // 
            // txtTglTitip
            // 
            this.txtTglTitip.DateValue = null;
            this.txtTglTitip.Location = new System.Drawing.Point(171, 95);
            this.txtTglTitip.MaxLength = 10;
            this.txtTglTitip.Name = "txtTglTitip";
            this.txtTglTitip.Size = new System.Drawing.Size(191, 20);
            this.txtTglTitip.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(38, 98);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 14);
            this.label29.TabIndex = 109;
            this.label29.Text = "Tanggal Titip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 110;
            this.label1.Text = "No Transaksi";
            // 
            // cboMataUang
            // 
            this.cboMataUang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(170, 336);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(89, 22);
            this.cboMataUang.TabIndex = 9;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(37, 339);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 121;
            this.label27.Text = "Mata Uang";
            this.label27.Click += new System.EventHandler(this.label27_Click);
            // 
            // cbxBentukPembayaran
            // 
            this.cbxBentukPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBentukPembayaran.FormattingEnabled = true;
            this.cbxBentukPembayaran.Items.AddRange(new object[] {
            "Tunai",
            "Transfer",
            "Giro"});
            this.cbxBentukPembayaran.Location = new System.Drawing.Point(171, 145);
            this.cbxBentukPembayaran.Name = "cbxBentukPembayaran";
            this.cbxBentukPembayaran.Size = new System.Drawing.Size(129, 22);
            this.cbxBentukPembayaran.TabIndex = 3;
            this.cbxBentukPembayaran.SelectedIndexChanged += new System.EventHandler(this.cbxBentukPembayaran_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 14);
            this.label9.TabIndex = 145;
            this.label9.Text = "Bentuk Pembayaran";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 149;
            this.label2.Text = "Rekening";
            // 
            // txtTglBG
            // 
            this.txtTglBG.DateValue = null;
            this.txtTglBG.Location = new System.Drawing.Point(170, 284);
            this.txtTglBG.MaxLength = 10;
            this.txtTglBG.Name = "txtTglBG";
            this.txtTglBG.Size = new System.Drawing.Size(191, 20);
            this.txtTglBG.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 153;
            this.label10.Text = "Tgl. JT BGC";
            // 
            // txtNoBG
            // 
            this.txtNoBG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBG.Location = new System.Drawing.Point(170, 311);
            this.txtNoBG.MaxLength = 15;
            this.txtNoBG.Name = "txtNoBG";
            this.txtNoBG.Size = new System.Drawing.Size(191, 20);
            this.txtNoBG.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 152;
            this.label6.Text = "No. BGC";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(170, 391);
            this.txtUraian.MaxLength = 250;
            this.txtUraian.Multiline = true;
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(218, 73);
            this.txtUraian.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 394);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 14);
            this.label12.TabIndex = 155;
            this.label12.Text = "Uraian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 156;
            this.label3.Text = "Nominal";
            // 
            // txtPembayaran
            // 
            this.txtPembayaran.Format = "N0";
            this.txtPembayaran.Location = new System.Drawing.Point(170, 362);
            this.txtPembayaran.Name = "txtPembayaran";
            this.txtPembayaran.Size = new System.Drawing.Size(191, 20);
            this.txtPembayaran.TabIndex = 10;
            this.txtPembayaran.Text = "0";
            // 
            // cmdSaveTitipan
            // 
            this.cmdSaveTitipan.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSaveTitipan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSaveTitipan.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveTitipan.Image")));
            this.cmdSaveTitipan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveTitipan.Location = new System.Drawing.Point(31, 477);
            this.cmdSaveTitipan.Name = "cmdSaveTitipan";
            this.cmdSaveTitipan.Size = new System.Drawing.Size(100, 40);
            this.cmdSaveTitipan.TabIndex = 12;
            this.cmdSaveTitipan.Text = "SAVE";
            this.cmdSaveTitipan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSaveTitipan.UseVisualStyleBackColor = true;
            this.cmdSaveTitipan.Click += new System.EventHandler(this.cmdSaveTitipan_Click);
            // 
            // cmdCloseTitipan
            // 
            this.cmdCloseTitipan.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCloseTitipan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCloseTitipan.Image = ((System.Drawing.Image)(resources.GetObject("cmdCloseTitipan.Image")));
            this.cmdCloseTitipan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCloseTitipan.Location = new System.Drawing.Point(161, 477);
            this.cmdCloseTitipan.Name = "cmdCloseTitipan";
            this.cmdCloseTitipan.Size = new System.Drawing.Size(100, 40);
            this.cmdCloseTitipan.TabIndex = 13;
            this.cmdCloseTitipan.Text = "CLOSE";
            this.cmdCloseTitipan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCloseTitipan.UseVisualStyleBackColor = true;
            this.cmdCloseTitipan.Click += new System.EventHandler(this.cmdCloseTitipan_Click);
            // 
            // txtNoTransaksi
            // 
            this.txtNoTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoTransaksi.Enabled = false;
            this.txtNoTransaksi.Location = new System.Drawing.Point(171, 69);
            this.txtNoTransaksi.MaxLength = 15;
            this.txtNoTransaksi.Name = "txtNoTransaksi";
            this.txtNoTransaksi.Size = new System.Drawing.Size(191, 20);
            this.txtNoTransaksi.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 162;
            this.label4.Text = "Tipe Titipan";
            // 
            // cboTipeTitipan
            // 
            this.cboTipeTitipan.FormattingEnabled = true;
            this.cboTipeTitipan.Items.AddRange(new object[] {
            "Titipan Lain - Lain",
            "Titipan UM"});
            this.cboTipeTitipan.Location = new System.Drawing.Point(170, 173);
            this.cboTipeTitipan.Name = "cboTipeTitipan";
            this.cboTipeTitipan.Size = new System.Drawing.Size(121, 22);
            this.cboTipeTitipan.TabIndex = 4;
            this.cboTipeTitipan.SelectedIndexChanged += new System.EventHandler(this.cboTipeTitipan_SelectedIndexChanged);
            // 
            // lblMotor
            // 
            this.lblMotor.AutoSize = true;
            this.lblMotor.Location = new System.Drawing.Point(39, 204);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(40, 14);
            this.lblMotor.TabIndex = 165;
            this.lblMotor.Text = "Motor";
            this.lblMotor.Click += new System.EventHandler(this.lblMotor_Click);
            // 
            // lookUpStokMotor1
            // 
            this.lookUpStokMotor1.Location = new System.Drawing.Point(158, 198);
            this.lookUpStokMotor1.Name = "lookUpStokMotor1";
            this.lookUpStokMotor1.Size = new System.Drawing.Size(228, 25);
            this.lookUpStokMotor1.TabIndex = 5;
            this.lookUpStokMotor1.Load += new System.EventHandler(this.lookUpStokMotor1_Load);
            // 
            // lucPelanggan
            // 
            this.lucPelanggan.Location = new System.Drawing.Point(161, 117);
            this.lucPelanggan.Name = "lucPelanggan";
            this.lucPelanggan.Size = new System.Drawing.Size(265, 27);
            this.lucPelanggan.TabIndex = 2;
            // 
            // lookUpRekening1
            // 
            this.lookUpRekening1.Location = new System.Drawing.Point(159, 228);
            this.lookUpRekening1.NamaRekening = null;
            this.lookUpRekening1.Name = "lookUpRekening1";
            this.lookUpRekening1.NoPerkiraanRekening = null;
            this.lookUpRekening1.NoRekening = null;
            this.lookUpRekening1.RekeningRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpRekening1.Size = new System.Drawing.Size(309, 49);
            this.lookUpRekening1.TabIndex = 6;
            // 
            // frmTitipanUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 544);
            this.Controls.Add(this.lookUpStokMotor1);
            this.Controls.Add(this.lblMotor);
            this.Controls.Add(this.cboTipeTitipan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lucPelanggan);
            this.Controls.Add(this.txtNoTransaksi);
            this.Controls.Add(this.cmdCloseTitipan);
            this.Controls.Add(this.cmdSaveTitipan);
            this.Controls.Add(this.txtPembayaran);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTglBG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNoBG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookUpRekening1);
            this.Controls.Add(this.cbxBentukPembayaran);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboMataUang);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTglTitip);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label5);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTitipanUpdate";
            this.Text = "Penerimaan Titipan";
            this.Title = "Penerimaan Titipan";
            this.Load += new System.EventHandler(this.frmTitipanUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTitipanUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label29, 0);
            this.Controls.SetChildIndex(this.txtTglTitip, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.cboMataUang, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cbxBentukPembayaran, 0);
            this.Controls.SetChildIndex(this.lookUpRekening1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNoBG, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtTglBG, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPembayaran, 0);
            this.Controls.SetChildIndex(this.cmdSaveTitipan, 0);
            this.Controls.SetChildIndex(this.cmdCloseTitipan, 0);
            this.Controls.SetChildIndex(this.txtNoTransaksi, 0);
            this.Controls.SetChildIndex(this.lucPelanggan, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboTipeTitipan, 0);
            this.Controls.SetChildIndex(this.lblMotor, 0);
            this.Controls.SetChildIndex(this.lookUpStokMotor1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private ISA.Controls.DateTextBox txtTglTitip;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbxBentukPembayaran;
        private System.Windows.Forms.Label label9;
        private ISA.Showroom.Controls.LookUpRekening lookUpRekening1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.DateTextBox txtTglBG;
        private System.Windows.Forms.Label label10;
        private ISA.Controls.CommonTextBox txtNoBG;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.NumericTextBox txtPembayaran;
        private ISA.Controls.CommandButton cmdSaveTitipan;
        private ISA.Controls.CommandButton cmdCloseTitipan;
        private ISA.Controls.CommonTextBox txtNoTransaksi;
        private ISA.Showroom.Controls.LookUpCustomer lucPelanggan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipeTitipan;
        private System.Windows.Forms.Label lblMotor;
        private ISA.Showroom.Controls.LookUpStokMotor lookUpStokMotor1;
    }
}