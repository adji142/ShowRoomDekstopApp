namespace ISA.Showroom.Finance.Laporan.Finance
{
    partial class frmLaporanTransaksiKas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanTransaksiKas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdPRINT = new ISA.Controls.CommandButton();
            this.rangeDateTrans = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPT = new System.Windows.Forms.ComboBox();
            this.labelPT = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.labelCabang = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBank = new System.Windows.Forms.CheckBox();
            this.checkGiro = new System.Windows.Forms.CheckBox();
            this.checkKas = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.labelVendor = new System.Windows.Forms.Label();
            this.cboKas = new System.Windows.Forms.ComboBox();
            this.labelJnsKas = new System.Windows.Forms.Label();
            this.lblNamaPerusahaan = new System.Windows.Forms.Label();
            this.labelBlankPT = new System.Windows.Forms.Label();
            this.labelBlankCabang = new System.Windows.Forms.Label();
            this.labelBlankKas = new System.Windows.Forms.Label();
            this.checkVendor = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkSort = new System.Windows.Forms.CheckBox();
            this.rbNoBukti = new System.Windows.Forms.RadioButton();
            this.rbTanggal = new System.Windows.Forms.RadioButton();
            this.grbJnsTransaksi = new System.Windows.Forms.GroupBox();
            this.rdoSemua = new System.Windows.Forms.RadioButton();
            this.lblKetJensTransaksi = new System.Windows.Forms.Label();
            this.rdoJnsTransaksi = new System.Windows.Forms.RadioButton();
            this.rdoKasbon = new System.Windows.Forms.RadioButton();
            this.cboJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.rdoPiutangKaryawan = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdtglinput = new System.Windows.Forms.RadioButton();
            this.rdtgltransaksi = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grbJnsTransaksi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.cmdCLOSE);
            this.panel1.Controls.Add(this.cmdPRINT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 533);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 64);
            this.panel1.TabIndex = 9;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(691, 12);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 1;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(12, 12);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 0;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // rangeDateTrans
            // 
            this.rangeDateTrans.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rangeDateTrans.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateTrans.FromDate = null;
            this.rangeDateTrans.Location = new System.Drawing.Point(265, 127);
            this.rangeDateTrans.Name = "rangeDateTrans";
            this.rangeDateTrans.Size = new System.Drawing.Size(257, 22);
            this.rangeDateTrans.TabIndex = 0;
            this.rangeDateTrans.ToDate = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tanggal Transaksi";
            // 
            // cboPT
            // 
            this.cboPT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPT.FormattingEnabled = true;
            this.cboPT.Location = new System.Drawing.Point(265, 298);
            this.cboPT.Name = "cboPT";
            this.cboPT.Size = new System.Drawing.Size(234, 22);
            this.cboPT.TabIndex = 4;
            // 
            // labelPT
            // 
            this.labelPT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPT.AutoSize = true;
            this.labelPT.Location = new System.Drawing.Point(130, 301);
            this.labelPT.Name = "labelPT";
            this.labelPT.Size = new System.Drawing.Size(62, 14);
            this.labelPT.TabIndex = 13;
            this.labelPT.Text = "Dari/Ke PT";
            // 
            // cboCabang
            // 
            this.cboCabang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(265, 326);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(234, 22);
            this.cboCabang.TabIndex = 5;
            // 
            // labelCabang
            // 
            this.labelCabang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCabang.AutoSize = true;
            this.labelCabang.Location = new System.Drawing.Point(130, 329);
            this.labelCabang.Name = "labelCabang";
            this.labelCabang.Size = new System.Drawing.Size(89, 14);
            this.labelCabang.TabIndex = 17;
            this.labelCabang.Text = "Dari/Ke Cabang";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.checkBank);
            this.groupBox1.Controls.Add(this.checkGiro);
            this.groupBox1.Controls.Add(this.checkKas);
            this.groupBox1.Location = new System.Drawing.Point(408, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bentuk Transaksi";
            // 
            // checkBank
            // 
            this.checkBank.AutoSize = true;
            this.checkBank.Checked = true;
            this.checkBank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBank.Location = new System.Drawing.Point(21, 68);
            this.checkBank.Name = "checkBank";
            this.checkBank.Size = new System.Drawing.Size(53, 18);
            this.checkBank.TabIndex = 2;
            this.checkBank.Text = "Bank";
            this.checkBank.UseVisualStyleBackColor = true;
            this.checkBank.CheckedChanged += new System.EventHandler(this.checkKas_CheckedChanged);
            // 
            // checkGiro
            // 
            this.checkGiro.AutoSize = true;
            this.checkGiro.Checked = true;
            this.checkGiro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkGiro.Location = new System.Drawing.Point(21, 44);
            this.checkGiro.Name = "checkGiro";
            this.checkGiro.Size = new System.Drawing.Size(49, 18);
            this.checkGiro.TabIndex = 1;
            this.checkGiro.Text = "Giro";
            this.checkGiro.UseVisualStyleBackColor = true;
            this.checkGiro.CheckedChanged += new System.EventHandler(this.checkKas_CheckedChanged);
            // 
            // checkKas
            // 
            this.checkKas.AutoSize = true;
            this.checkKas.Checked = true;
            this.checkKas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkKas.Location = new System.Drawing.Point(21, 19);
            this.checkKas.Name = "checkKas";
            this.checkKas.Size = new System.Drawing.Size(46, 18);
            this.checkKas.TabIndex = 0;
            this.checkKas.Text = "Kas";
            this.checkKas.UseVisualStyleBackColor = true;
            this.checkKas.CheckedChanged += new System.EventHandler(this.checkKas_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.rbIn);
            this.groupBox2.Controls.Add(this.rbOut);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Location = new System.Drawing.Point(265, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "In/Out";
            // 
            // rbIn
            // 
            this.rbIn.AutoSize = true;
            this.rbIn.Location = new System.Drawing.Point(19, 18);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(91, 18);
            this.rbIn.TabIndex = 5;
            this.rbIn.Text = "Penerimaan";
            this.rbIn.UseVisualStyleBackColor = true;
            this.rbIn.CheckedChanged += new System.EventHandler(this.rbOut_CheckedChanged);
            // 
            // rbOut
            // 
            this.rbOut.AutoSize = true;
            this.rbOut.Location = new System.Drawing.Point(19, 43);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(94, 18);
            this.rbOut.TabIndex = 6;
            this.rbOut.Text = "Pengeluaran";
            this.rbOut.UseVisualStyleBackColor = true;
            this.rbOut.CheckedChanged += new System.EventHandler(this.rbOut_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(19, 67);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(63, 18);
            this.rbAll.TabIndex = 7;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Semua";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbOut_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pilihan / Opsi";
            // 
            // cboVendor
            // 
            this.cboVendor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendor.Enabled = false;
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(284, 354);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(280, 22);
            this.cboVendor.TabIndex = 7;
            // 
            // labelVendor
            // 
            this.labelVendor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVendor.AutoSize = true;
            this.labelVendor.Location = new System.Drawing.Point(130, 357);
            this.labelVendor.Name = "labelVendor";
            this.labelVendor.Size = new System.Drawing.Size(98, 14);
            this.labelVendor.TabIndex = 22;
            this.labelVendor.Text = "Suplier (Vendor)";
            // 
            // cboKas
            // 
            this.cboKas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboKas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKas.FormattingEnabled = true;
            this.cboKas.Location = new System.Drawing.Point(265, 382);
            this.cboKas.Name = "cboKas";
            this.cboKas.Size = new System.Drawing.Size(137, 22);
            this.cboKas.TabIndex = 8;
            // 
            // labelJnsKas
            // 
            this.labelJnsKas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelJnsKas.AutoSize = true;
            this.labelJnsKas.Location = new System.Drawing.Point(130, 385);
            this.labelJnsKas.Name = "labelJnsKas";
            this.labelJnsKas.Size = new System.Drawing.Size(60, 14);
            this.labelJnsKas.TabIndex = 24;
            this.labelJnsKas.Text = "Jenis Kas";
            // 
            // lblNamaPerusahaan
            // 
            this.lblNamaPerusahaan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNamaPerusahaan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaPerusahaan.Location = new System.Drawing.Point(156, 37);
            this.lblNamaPerusahaan.Name = "lblNamaPerusahaan";
            this.lblNamaPerusahaan.Size = new System.Drawing.Size(498, 19);
            this.lblNamaPerusahaan.TabIndex = 25;
            this.lblNamaPerusahaan.Text = "Nama Perusahaan";
            this.lblNamaPerusahaan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBlankPT
            // 
            this.labelBlankPT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBlankPT.AutoSize = true;
            this.labelBlankPT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlankPT.Location = new System.Drawing.Point(505, 301);
            this.labelBlankPT.Name = "labelBlankPT";
            this.labelBlankPT.Size = new System.Drawing.Size(59, 14);
            this.labelBlankPT.TabIndex = 26;
            this.labelBlankPT.Text = "blank = all";
            // 
            // labelBlankCabang
            // 
            this.labelBlankCabang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBlankCabang.AutoSize = true;
            this.labelBlankCabang.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlankCabang.Location = new System.Drawing.Point(505, 329);
            this.labelBlankCabang.Name = "labelBlankCabang";
            this.labelBlankCabang.Size = new System.Drawing.Size(59, 14);
            this.labelBlankCabang.TabIndex = 27;
            this.labelBlankCabang.Text = "blank = all";
            // 
            // labelBlankKas
            // 
            this.labelBlankKas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBlankKas.AutoSize = true;
            this.labelBlankKas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlankKas.Location = new System.Drawing.Point(405, 385);
            this.labelBlankKas.Name = "labelBlankKas";
            this.labelBlankKas.Size = new System.Drawing.Size(59, 14);
            this.labelBlankKas.TabIndex = 29;
            this.labelBlankKas.Text = "blank = all";
            // 
            // checkVendor
            // 
            this.checkVendor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkVendor.AutoSize = true;
            this.checkVendor.Location = new System.Drawing.Point(265, 357);
            this.checkVendor.Name = "checkVendor";
            this.checkVendor.Size = new System.Drawing.Size(15, 14);
            this.checkVendor.TabIndex = 6;
            this.checkVendor.UseVisualStyleBackColor = true;
            this.checkVendor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.checkSort);
            this.groupBox3.Controls.Add(this.rbNoBukti);
            this.groupBox3.Controls.Add(this.rbTanggal);
            this.groupBox3.Location = new System.Drawing.Point(550, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 103);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diurutkan";
            // 
            // checkSort
            // 
            this.checkSort.AutoSize = true;
            this.checkSort.Location = new System.Drawing.Point(21, 70);
            this.checkSort.Name = "checkSort";
            this.checkSort.Size = new System.Drawing.Size(91, 18);
            this.checkSort.TabIndex = 2;
            this.checkSort.Text = "Descending";
            this.checkSort.UseVisualStyleBackColor = true;
            // 
            // rbNoBukti
            // 
            this.rbNoBukti.AutoSize = true;
            this.rbNoBukti.Location = new System.Drawing.Point(21, 46);
            this.rbNoBukti.Name = "rbNoBukti";
            this.rbNoBukti.Size = new System.Drawing.Size(93, 18);
            this.rbNoBukti.TabIndex = 1;
            this.rbNoBukti.Text = "Nomor bukti";
            this.rbNoBukti.UseVisualStyleBackColor = true;
            // 
            // rbTanggal
            // 
            this.rbTanggal.AutoSize = true;
            this.rbTanggal.Checked = true;
            this.rbTanggal.Location = new System.Drawing.Point(21, 22);
            this.rbTanggal.Name = "rbTanggal";
            this.rbTanggal.Size = new System.Drawing.Size(68, 18);
            this.rbTanggal.TabIndex = 0;
            this.rbTanggal.TabStop = true;
            this.rbTanggal.Text = "Tanggal";
            this.rbTanggal.UseVisualStyleBackColor = true;
            // 
            // grbJnsTransaksi
            // 
            this.grbJnsTransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grbJnsTransaksi.Controls.Add(this.rdoSemua);
            this.grbJnsTransaksi.Controls.Add(this.lblKetJensTransaksi);
            this.grbJnsTransaksi.Controls.Add(this.rdoJnsTransaksi);
            this.grbJnsTransaksi.Controls.Add(this.rdoKasbon);
            this.grbJnsTransaksi.Controls.Add(this.cboJenisTransaksi);
            this.grbJnsTransaksi.Controls.Add(this.rdoPiutangKaryawan);
            this.grbJnsTransaksi.Location = new System.Drawing.Point(265, 410);
            this.grbJnsTransaksi.Name = "grbJnsTransaksi";
            this.grbJnsTransaksi.Size = new System.Drawing.Size(426, 79);
            this.grbJnsTransaksi.TabIndex = 33;
            this.grbJnsTransaksi.TabStop = false;
            // 
            // rdoSemua
            // 
            this.rdoSemua.AutoSize = true;
            this.rdoSemua.Location = new System.Drawing.Point(341, 20);
            this.rdoSemua.Name = "rdoSemua";
            this.rdoSemua.Size = new System.Drawing.Size(63, 18);
            this.rdoSemua.TabIndex = 36;
            this.rdoSemua.Text = "Semua";
            this.rdoSemua.UseVisualStyleBackColor = true;
            this.rdoSemua.CheckedChanged += new System.EventHandler(this.rdoSemua_CheckedChanged);
            // 
            // lblKetJensTransaksi
            // 
            this.lblKetJensTransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKetJensTransaksi.AutoSize = true;
            this.lblKetJensTransaksi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetJensTransaksi.Location = new System.Drawing.Point(317, 49);
            this.lblKetJensTransaksi.Name = "lblKetJensTransaksi";
            this.lblKetJensTransaksi.Size = new System.Drawing.Size(59, 14);
            this.lblKetJensTransaksi.TabIndex = 34;
            this.lblKetJensTransaksi.Text = "blank = all";
            // 
            // rdoJnsTransaksi
            // 
            this.rdoJnsTransaksi.AutoSize = true;
            this.rdoJnsTransaksi.Checked = true;
            this.rdoJnsTransaksi.Location = new System.Drawing.Point(23, 20);
            this.rdoJnsTransaksi.Name = "rdoJnsTransaksi";
            this.rdoJnsTransaksi.Size = new System.Drawing.Size(113, 18);
            this.rdoJnsTransaksi.TabIndex = 35;
            this.rdoJnsTransaksi.TabStop = true;
            this.rdoJnsTransaksi.Text = "Jenis Transaksi";
            this.rdoJnsTransaksi.UseVisualStyleBackColor = true;
            this.rdoJnsTransaksi.CheckedChanged += new System.EventHandler(this.rdoJnsTransaksi_CheckedChanged);
            // 
            // rdoKasbon
            // 
            this.rdoKasbon.AutoSize = true;
            this.rdoKasbon.Location = new System.Drawing.Point(269, 20);
            this.rdoKasbon.Name = "rdoKasbon";
            this.rdoKasbon.Size = new System.Drawing.Size(66, 18);
            this.rdoKasbon.TabIndex = 1;
            this.rdoKasbon.Text = "Kasbon";
            this.rdoKasbon.UseVisualStyleBackColor = true;
            this.rdoKasbon.CheckedChanged += new System.EventHandler(this.rdoKasbon_CheckedChanged);
            // 
            // cboJenisTransaksi
            // 
            this.cboJenisTransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJenisTransaksi.FormattingEnabled = true;
            this.cboJenisTransaksi.Location = new System.Drawing.Point(38, 46);
            this.cboJenisTransaksi.Name = "cboJenisTransaksi";
            this.cboJenisTransaksi.Size = new System.Drawing.Size(273, 22);
            this.cboJenisTransaksi.TabIndex = 35;
            // 
            // rdoPiutangKaryawan
            // 
            this.rdoPiutangKaryawan.AutoSize = true;
            this.rdoPiutangKaryawan.Location = new System.Drawing.Point(141, 20);
            this.rdoPiutangKaryawan.Name = "rdoPiutangKaryawan";
            this.rdoPiutangKaryawan.Size = new System.Drawing.Size(122, 18);
            this.rdoPiutangKaryawan.TabIndex = 0;
            this.rdoPiutangKaryawan.Text = "Piutang Karyawan";
            this.rdoPiutangKaryawan.UseVisualStyleBackColor = true;
            this.rdoPiutangKaryawan.CheckedChanged += new System.EventHandler(this.rdoPiutangKaryawan_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "Berdasarkan Tanggal";
            // 
            // rdtglinput
            // 
            this.rdtglinput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdtglinput.AutoSize = true;
            this.rdtglinput.Location = new System.Drawing.Point(279, 96);
            this.rdtglinput.Name = "rdtglinput";
            this.rdtglinput.Size = new System.Drawing.Size(99, 18);
            this.rdtglinput.TabIndex = 35;
            this.rdtglinput.TabStop = true;
            this.rdtglinput.Text = "Tanggal Input";
            this.rdtglinput.UseVisualStyleBackColor = true;
            this.rdtglinput.CheckedChanged += new System.EventHandler(this.rdtglinput_CheckedChanged);
            // 
            // rdtgltransaksi
            // 
            this.rdtgltransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdtgltransaksi.AutoSize = true;
            this.rdtgltransaksi.Location = new System.Drawing.Point(402, 96);
            this.rdtgltransaksi.Name = "rdtgltransaksi";
            this.rdtgltransaksi.Size = new System.Drawing.Size(143, 18);
            this.rdtgltransaksi.TabIndex = 36;
            this.rdtgltransaksi.TabStop = true;
            this.rdtgltransaksi.Text = "Tanggal Transaksi/RK";
            this.rdtgltransaksi.UseVisualStyleBackColor = true;
            this.rdtgltransaksi.CheckedChanged += new System.EventHandler(this.rdtgltransaksi_CheckedChanged);
            // 
            // frmLaporanTransaksiKas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 597);
            this.Controls.Add(this.rdtgltransaksi);
            this.Controls.Add(this.rdtglinput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grbJnsTransaksi);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkVendor);
            this.Controls.Add(this.labelBlankKas);
            this.Controls.Add(this.labelBlankCabang);
            this.Controls.Add(this.labelBlankPT);
            this.Controls.Add(this.lblNamaPerusahaan);
            this.Controls.Add(this.labelJnsKas);
            this.Controls.Add(this.cboKas);
            this.Controls.Add(this.labelVendor);
            this.Controls.Add(this.cboVendor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelCabang);
            this.Controls.Add(this.cboCabang);
            this.Controls.Add(this.labelPT);
            this.Controls.Add(this.cboPT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateTrans);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanTransaksiKas";
            this.Text = "Laporan Transaksi Kas";
            this.Title = "Laporan Transaksi Kas";
            this.Load += new System.EventHandler(this.frmLaporanTransaksiKas_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.rangeDateTrans, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboPT, 0);
            this.Controls.SetChildIndex(this.labelPT, 0);
            this.Controls.SetChildIndex(this.cboCabang, 0);
            this.Controls.SetChildIndex(this.labelCabang, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboVendor, 0);
            this.Controls.SetChildIndex(this.labelVendor, 0);
            this.Controls.SetChildIndex(this.cboKas, 0);
            this.Controls.SetChildIndex(this.labelJnsKas, 0);
            this.Controls.SetChildIndex(this.lblNamaPerusahaan, 0);
            this.Controls.SetChildIndex(this.labelBlankPT, 0);
            this.Controls.SetChildIndex(this.labelBlankCabang, 0);
            this.Controls.SetChildIndex(this.labelBlankKas, 0);
            this.Controls.SetChildIndex(this.checkVendor, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grbJnsTransaksi, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rdtglinput, 0);
            this.Controls.SetChildIndex(this.rdtgltransaksi, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbJnsTransaksi.ResumeLayout(false);
            this.grbJnsTransaksi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.CommandButton cmdPRINT;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.RangeDateBox rangeDateTrans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPT;
        private System.Windows.Forms.Label labelPT;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.Windows.Forms.Label labelCabang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkGiro;
        private System.Windows.Forms.CheckBox checkKas;
        private System.Windows.Forms.CheckBox checkBank;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbIn;
        private System.Windows.Forms.RadioButton rbOut;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.Label labelVendor;
        private System.Windows.Forms.ComboBox cboKas;
        private System.Windows.Forms.Label labelJnsKas;
        private System.Windows.Forms.Label lblNamaPerusahaan;
        private System.Windows.Forms.Label labelBlankPT;
        private System.Windows.Forms.Label labelBlankCabang;
        private System.Windows.Forms.Label labelBlankKas;
        private System.Windows.Forms.CheckBox checkVendor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbNoBukti;
        private System.Windows.Forms.RadioButton rbTanggal;
        private System.Windows.Forms.CheckBox checkSort;
        private System.Windows.Forms.GroupBox grbJnsTransaksi;
        private System.Windows.Forms.RadioButton rdoJnsTransaksi;
        private System.Windows.Forms.RadioButton rdoKasbon;
        private System.Windows.Forms.RadioButton rdoPiutangKaryawan;
        private System.Windows.Forms.ComboBox cboJenisTransaksi;
        private System.Windows.Forms.Label lblKetJensTransaksi;
        private System.Windows.Forms.RadioButton rdoSemua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdtglinput;
        private System.Windows.Forms.RadioButton rdtgltransaksi;
    }
}