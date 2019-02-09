namespace ISA.Showroom.Penjualan
{
    partial class frmDendaUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDendaUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSrc = new System.Windows.Forms.Label();
            this.lblNoTrans = new System.Windows.Forms.Label();
            this.lblTglTrans = new System.Windows.Forms.Label();
            this.lblDenda = new System.Windows.Forms.Label();
            this.lblMataUang = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPotonganDenda = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPembayaranDenda = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblSaldoDenda = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblNopol = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.cboBentukPembayaran = new System.Windows.Forms.ComboBox();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.txtnominal = new ISA.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.grpPBL = new System.Windows.Forms.GroupBox();
            this.txtNominalPembayaranPBL = new ISA.Controls.NumericTextBox();
            this.txtNominalPembulatan = new ISA.Controls.NumericTextBox();
            this.cboPembulatan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpotongan = new ISA.Controls.NumericTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.lookUpRekening1 = new ISA.Showroom.Controls.LookUpRekening();
            this.cboTipeTransaksi = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpPBL.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sumber Denda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "No Transaksi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tanggal Transaksi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nominal Denda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "Mata Uang";
            // 
            // lblSrc
            // 
            this.lblSrc.AutoSize = true;
            this.lblSrc.Location = new System.Drawing.Point(128, 47);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.Size = new System.Drawing.Size(29, 14);
            this.lblSrc.TabIndex = 20;
            this.lblSrc.Text = "-Src";
            // 
            // lblNoTrans
            // 
            this.lblNoTrans.AutoSize = true;
            this.lblNoTrans.Location = new System.Drawing.Point(128, 74);
            this.lblNoTrans.Name = "lblNoTrans";
            this.lblNoTrans.Size = new System.Drawing.Size(56, 14);
            this.lblNoTrans.TabIndex = 21;
            this.lblNoTrans.Text = "-NoTrans";
            // 
            // lblTglTrans
            // 
            this.lblTglTrans.AutoSize = true;
            this.lblTglTrans.Location = new System.Drawing.Point(128, 102);
            this.lblTglTrans.Name = "lblTglTrans";
            this.lblTglTrans.Size = new System.Drawing.Size(59, 14);
            this.lblTglTrans.TabIndex = 22;
            this.lblTglTrans.Text = "-TglTrans";
            // 
            // lblDenda
            // 
            this.lblDenda.AutoSize = true;
            this.lblDenda.Location = new System.Drawing.Point(437, 19);
            this.lblDenda.Name = "lblDenda";
            this.lblDenda.Size = new System.Drawing.Size(45, 14);
            this.lblDenda.TabIndex = 23;
            this.lblDenda.Text = "-Denda";
            // 
            // lblMataUang
            // 
            this.lblMataUang.AutoSize = true;
            this.lblMataUang.Location = new System.Drawing.Point(437, 128);
            this.lblMataUang.Name = "lblMataUang";
            this.lblMataUang.Size = new System.Drawing.Size(64, 14);
            this.lblMataUang.TabIndex = 24;
            this.lblMataUang.Text = "-MataUang";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 25;
            this.label11.Text = "Mata Uang";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblPotonganDenda);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.lblPembayaranDenda);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.lblSaldoDenda);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblNopol);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.lblNama);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblMataUang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblDenda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTglTrans);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblNoTrans);
            this.groupBox1.Controls.Add(this.lblSrc);
            this.groupBox1.Location = new System.Drawing.Point(31, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 153);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Transaksi";
            // 
            // lblPotonganDenda
            // 
            this.lblPotonganDenda.AutoSize = true;
            this.lblPotonganDenda.Location = new System.Drawing.Point(437, 74);
            this.lblPotonganDenda.Name = "lblPotonganDenda";
            this.lblPotonganDenda.Size = new System.Drawing.Size(97, 14);
            this.lblPotonganDenda.TabIndex = 34;
            this.lblPotonganDenda.Text = "-PotonganDenda";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(317, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 14);
            this.label21.TabIndex = 33;
            this.label21.Text = "Potongan Denda";
            // 
            // lblPembayaranDenda
            // 
            this.lblPembayaranDenda.AutoSize = true;
            this.lblPembayaranDenda.Location = new System.Drawing.Point(437, 47);
            this.lblPembayaranDenda.Name = "lblPembayaranDenda";
            this.lblPembayaranDenda.Size = new System.Drawing.Size(113, 14);
            this.lblPembayaranDenda.TabIndex = 32;
            this.lblPembayaranDenda.Text = "-PembayaranDenda";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(317, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 14);
            this.label20.TabIndex = 31;
            this.label20.Text = "Pembayaran Denda";
            // 
            // lblSaldoDenda
            // 
            this.lblSaldoDenda.AutoSize = true;
            this.lblSaldoDenda.Location = new System.Drawing.Point(437, 102);
            this.lblSaldoDenda.Name = "lblSaldoDenda";
            this.lblSaldoDenda.Size = new System.Drawing.Size(75, 14);
            this.lblSaldoDenda.TabIndex = 30;
            this.lblSaldoDenda.Text = "-SaldoDenda";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(317, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 14);
            this.label19.TabIndex = 29;
            this.label19.Text = "Saldo Denda";
            // 
            // lblNopol
            // 
            this.lblNopol.AutoSize = true;
            this.lblNopol.Location = new System.Drawing.Point(128, 128);
            this.lblNopol.Name = "lblNopol";
            this.lblNopol.Size = new System.Drawing.Size(42, 14);
            this.lblNopol.TabIndex = 28;
            this.lblNopol.Text = "-Nopol";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 14);
            this.label17.TabIndex = 27;
            this.label17.Text = "No. Polisi";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(128, 19);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(41, 14);
            this.lblNama.TabIndex = 26;
            this.lblNama.Text = "-Nama";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 14);
            this.label15.TabIndex = 25;
            this.label15.Text = "Nama Pelanggan";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(350, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 14);
            this.label12.TabIndex = 27;
            this.label12.Text = "Bentuk Pembayaran";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Tanggal Bayar";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 338);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 14);
            this.label14.TabIndex = 29;
            this.label14.Text = "Nominal";
            // 
            // cboMataUang
            // 
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(164, 253);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(147, 22);
            this.cboMataUang.TabIndex = 30;
            // 
            // cboBentukPembayaran
            // 
            this.cboBentukPembayaran.FormattingEnabled = true;
            this.cboBentukPembayaran.Items.AddRange(new object[] {
            "Tunai",
            "Transfer",
            "Titipan"});
            this.cboBentukPembayaran.Location = new System.Drawing.Point(478, 217);
            this.cboBentukPembayaran.Name = "cboBentukPembayaran";
            this.cboBentukPembayaran.Size = new System.Drawing.Size(121, 22);
            this.cboBentukPembayaran.TabIndex = 31;
            this.cboBentukPembayaran.SelectedIndexChanged += new System.EventHandler(this.cboBentukPembayaran_SelectedIndexChanged);
            // 
            // txtTanggal
            // 
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(164, 297);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(147, 20);
            this.txtTanggal.TabIndex = 32;
            // 
            // txtnominal
            // 
            this.txtnominal.Location = new System.Drawing.Point(164, 335);
            this.txtnominal.Name = "txtnominal";
            this.txtnominal.Size = new System.Drawing.Size(147, 20);
            this.txtnominal.TabIndex = 33;
            this.txtnominal.Text = "0";
            this.txtnominal.TextChanged += new System.EventHandler(this.txtnominal_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 35;
            this.label6.Text = "No Rekening";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(150, 508);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(44, 508);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpPBL
            // 
            this.grpPBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPBL.Controls.Add(this.txtNominalPembayaranPBL);
            this.grpPBL.Controls.Add(this.txtNominalPembulatan);
            this.grpPBL.Controls.Add(this.cboPembulatan);
            this.grpPBL.Controls.Add(this.label9);
            this.grpPBL.Controls.Add(this.label8);
            this.grpPBL.Controls.Add(this.label7);
            this.grpPBL.Location = new System.Drawing.Point(31, 414);
            this.grpPBL.Name = "grpPBL";
            this.grpPBL.Size = new System.Drawing.Size(635, 88);
            this.grpPBL.TabIndex = 36;
            this.grpPBL.TabStop = false;
            this.grpPBL.Text = "Pembulatan";
            // 
            // txtNominalPembayaranPBL
            // 
            this.txtNominalPembayaranPBL.Enabled = false;
            this.txtNominalPembayaranPBL.Location = new System.Drawing.Point(449, 53);
            this.txtNominalPembayaranPBL.Name = "txtNominalPembayaranPBL";
            this.txtNominalPembayaranPBL.ReadOnly = true;
            this.txtNominalPembayaranPBL.Size = new System.Drawing.Size(147, 20);
            this.txtNominalPembayaranPBL.TabIndex = 5;
            this.txtNominalPembayaranPBL.Text = "0";
            // 
            // txtNominalPembulatan
            // 
            this.txtNominalPembulatan.Enabled = false;
            this.txtNominalPembulatan.Location = new System.Drawing.Point(143, 53);
            this.txtNominalPembulatan.Name = "txtNominalPembulatan";
            this.txtNominalPembulatan.ReadOnly = true;
            this.txtNominalPembulatan.Size = new System.Drawing.Size(147, 20);
            this.txtNominalPembulatan.TabIndex = 4;
            this.txtNominalPembulatan.Text = "0";
            // 
            // cboPembulatan
            // 
            this.cboPembulatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPembulatan.FormattingEnabled = true;
            this.cboPembulatan.Items.AddRange(new object[] {
            "100",
            "500",
            "1000"});
            this.cboPembulatan.Location = new System.Drawing.Point(143, 25);
            this.cboPembulatan.Name = "cboPembulatan";
            this.cboPembulatan.Size = new System.Drawing.Size(147, 22);
            this.cboPembulatan.TabIndex = 3;
            this.cboPembulatan.SelectedIndexChanged += new System.EventHandler(this.cboPembulatan_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nominal Pembayaran";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Nominal Pembulatan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pembulatan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(350, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 14);
            this.label10.TabIndex = 37;
            this.label10.Text = "Potongan";
            // 
            // txtpotongan
            // 
            this.txtpotongan.ForeColor = System.Drawing.Color.Red;
            this.txtpotongan.Location = new System.Drawing.Point(478, 299);
            this.txtpotongan.Name = "txtpotongan";
            this.txtpotongan.Size = new System.Drawing.Size(121, 20);
            this.txtpotongan.TabIndex = 38;
            this.txtpotongan.Text = "0";
            this.txtpotongan.TextChanged += new System.EventHandler(this.txtpotongan_TextChanged);
            this.txtpotongan.Leave += new System.EventHandler(this.txtpotongan_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(352, 338);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 14);
            this.label16.TabIndex = 39;
            this.label16.Text = "Uraian";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(478, 335);
            this.txtUraian.Multiline = true;
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(220, 73);
            this.txtUraian.TabIndex = 40;
            // 
            // lookUpRekening1
            // 
            this.lookUpRekening1.Location = new System.Drawing.Point(467, 258);
            this.lookUpRekening1.NamaRekening = null;
            this.lookUpRekening1.Name = "lookUpRekening1";
            this.lookUpRekening1.NoPerkiraanRekening = null;
            this.lookUpRekening1.NoRekening = null;
            this.lookUpRekening1.RekeningRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpRekening1.Size = new System.Drawing.Size(231, 44);
            this.lookUpRekening1.TabIndex = 34;
            // 
            // cboTipeTransaksi
            // 
            this.cboTipeTransaksi.FormattingEnabled = true;
            this.cboTipeTransaksi.Items.AddRange(new object[] {
            "Pembayaran + Potongan",
            "Pembayaran",
            "Potongan"});
            this.cboTipeTransaksi.Location = new System.Drawing.Point(164, 217);
            this.cboTipeTransaksi.Name = "cboTipeTransaksi";
            this.cboTipeTransaksi.Size = new System.Drawing.Size(147, 22);
            this.cboTipeTransaksi.TabIndex = 42;
            this.cboTipeTransaksi.SelectedIndexChanged += new System.EventHandler(this.cboTipeTransaksi_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(39, 220);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 14);
            this.label18.TabIndex = 41;
            this.label18.Text = "Tipe Transaksi";
            // 
            // frmDendaUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 560);
            this.Controls.Add(this.cboTipeTransaksi);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtpotongan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpPBL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookUpRekening1);
            this.Controls.Add(this.txtnominal);
            this.Controls.Add(this.txtTanggal);
            this.Controls.Add(this.cboBentukPembayaran);
            this.Controls.Add(this.cboMataUang);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDendaUpdate";
            this.Text = "Pembayaran Denda";
            this.Title = "Pembayaran Denda";
            this.Load += new System.EventHandler(this.frmDendaUpdate_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDendaUpdate_FormClosing);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.cboMataUang, 0);
            this.Controls.SetChildIndex(this.cboBentukPembayaran, 0);
            this.Controls.SetChildIndex(this.txtTanggal, 0);
            this.Controls.SetChildIndex(this.txtnominal, 0);
            this.Controls.SetChildIndex(this.lookUpRekening1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.grpPBL, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtpotongan, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.cboTipeTransaksi, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPBL.ResumeLayout(false);
            this.grpPBL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSrc;
        private System.Windows.Forms.Label lblNoTrans;
        private System.Windows.Forms.Label lblTglTrans;
        private System.Windows.Forms.Label lblDenda;
        private System.Windows.Forms.Label lblMataUang;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.ComboBox cboBentukPembayaran;
        private ISA.Controls.DateTextBox txtTanggal;
        private ISA.Controls.NumericTextBox txtnominal;
        private ISA.Showroom.Controls.LookUpRekening lookUpRekening1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpPBL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.NumericTextBox txtNominalPembayaranPBL;
        private ISA.Controls.NumericTextBox txtNominalPembulatan;
        private System.Windows.Forms.ComboBox cboPembulatan;
        private System.Windows.Forms.Label lblNopol;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private ISA.Controls.NumericTextBox txtpotongan;
        private System.Windows.Forms.Label label16;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label lblSaldoDenda;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPembayaranDenda;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblPotonganDenda;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboTipeTransaksi;
        private System.Windows.Forms.Label label18;
    }
}