namespace ISA.Showroom.Finance.Kasir
{
    partial class frmPembayaranMPM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembayaranMPM));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.cmdBatalIden = new ISA.Controls.CommandButton();
            this.rgtglKlr = new ISA.Controls.RangeDateBox();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JnsTransaksiRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeJnsTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalRk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPerusahaanke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangKeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JnsTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenerimaanUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalSisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusApproval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVDetail = new ISA.Controls.CustomGridView();
            this.PelRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPembelian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoFaktur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaVendorD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerkMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPembelian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisPelunasan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangDet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Niden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalMPMRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdMutasi = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.cmdKoreksi = new ISA.Controls.CommandButton();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.CMDPrintRekap = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal  :";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(345, 51);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 12;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // cmdBatalIden
            // 
            this.cmdBatalIden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBatalIden.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdBatalIden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdBatalIden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBatalIden.Location = new System.Drawing.Point(150, 473);
            this.cmdBatalIden.Name = "cmdBatalIden";
            this.cmdBatalIden.Size = new System.Drawing.Size(100, 40);
            this.cmdBatalIden.TabIndex = 27;
            this.cmdBatalIden.Text = "BATAL IDEN";
            this.cmdBatalIden.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBatalIden.UseVisualStyleBackColor = true;
            this.cmdBatalIden.Click += new System.EventHandler(this.cmdBatalIden_Click);
            // 
            // rgtglKlr
            // 
            this.rgtglKlr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgtglKlr.FromDate = null;
            this.rgtglKlr.Location = new System.Drawing.Point(93, 50);
            this.rgtglKlr.Name = "rgtglKlr";
            this.rgtglKlr.Size = new System.Drawing.Size(257, 22);
            this.rgtglKlr.TabIndex = 28;
            this.rgtglKlr.ToDate = null;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.AllowUserToResizeRows = false;
            this.GVHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.JnsTransaksiRowID,
            this.KodeJnsTransaksi,
            this.IsGroup,
            this.HIRowID,
            this.JournalRowID,
            this.GroupRowID,
            this.LastUpdatedTime,
            this.NoBukti,
            this.TanggalInput,
            this.Tanggal,
            this.TanggalRk,
            this.NamaPerusahaanke,
            this.CabangKeID,
            this.NamaVendor,
            this.JnsTransaksi,
            this.MataUang,
            this.Nominal,
            this.NominalIden,
            this.PenerimaanUang,
            this.NominalSisa,
            this.Uraian,
            this.StatusApproval,
            this.Bank,
            this.NoHI,
            this.IsPembayaran,
            this.NoAcc});
            this.GVHeader.Location = new System.Drawing.Point(32, 98);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(768, 192);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 29;
            this.GVHeader.SelectionRowChanged += new System.EventHandler(this.GVHeader_SelectionRowChanged);
            this.GVHeader.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVHeader_CellClick);
            this.GVHeader.Click += new System.EventHandler(this.GVHeader_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // JnsTransaksiRowID
            // 
            this.JnsTransaksiRowID.DataPropertyName = "JnsTransaksiRowID";
            this.JnsTransaksiRowID.HeaderText = "JnsTransaksiRowID";
            this.JnsTransaksiRowID.Name = "JnsTransaksiRowID";
            this.JnsTransaksiRowID.ReadOnly = true;
            this.JnsTransaksiRowID.Visible = false;
            // 
            // KodeJnsTransaksi
            // 
            this.KodeJnsTransaksi.DataPropertyName = "JnsTransaksi";
            this.KodeJnsTransaksi.HeaderText = "JnsTransaksi";
            this.KodeJnsTransaksi.Name = "KodeJnsTransaksi";
            this.KodeJnsTransaksi.ReadOnly = true;
            this.KodeJnsTransaksi.Visible = false;
            // 
            // IsGroup
            // 
            this.IsGroup.DataPropertyName = "IsGroup";
            this.IsGroup.HeaderText = "IsGroup";
            this.IsGroup.Name = "IsGroup";
            this.IsGroup.ReadOnly = true;
            this.IsGroup.Visible = false;
            // 
            // HIRowID
            // 
            this.HIRowID.DataPropertyName = "HIRowID";
            this.HIRowID.HeaderText = "HIRowID";
            this.HIRowID.Name = "HIRowID";
            this.HIRowID.ReadOnly = true;
            this.HIRowID.Visible = false;
            // 
            // JournalRowID
            // 
            this.JournalRowID.DataPropertyName = "JournalRowID";
            this.JournalRowID.HeaderText = "JournalRowID";
            this.JournalRowID.Name = "JournalRowID";
            this.JournalRowID.ReadOnly = true;
            this.JournalRowID.Visible = false;
            // 
            // GroupRowID
            // 
            this.GroupRowID.DataPropertyName = "GroupRowID";
            this.GroupRowID.HeaderText = "GroupRowID";
            this.GroupRowID.Name = "GroupRowID";
            this.GroupRowID.ReadOnly = true;
            this.GroupRowID.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 74;
            // 
            // TanggalInput
            // 
            this.TanggalInput.DataPropertyName = "CreatedTime";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.TanggalInput.DefaultCellStyle = dataGridViewCellStyle1;
            this.TanggalInput.HeaderText = "Tgl. Input";
            this.TanggalInput.Name = "TanggalInput";
            this.TanggalInput.ReadOnly = true;
            this.TanggalInput.Visible = false;
            this.TanggalInput.Width = 75;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tanggal.HeaderText = "Tanggal Input";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 97;
            // 
            // TanggalRk
            // 
            this.TanggalRk.DataPropertyName = "TanggalRk";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.TanggalRk.DefaultCellStyle = dataGridViewCellStyle3;
            this.TanggalRk.HeaderText = "Tanggal Rk";
            this.TanggalRk.Name = "TanggalRk";
            this.TanggalRk.ReadOnly = true;
            this.TanggalRk.Width = 84;
            // 
            // NamaPerusahaanke
            // 
            this.NamaPerusahaanke.DataPropertyName = "PTKeID";
            this.NamaPerusahaanke.HeaderText = "Ke PT";
            this.NamaPerusahaanke.Name = "NamaPerusahaanke";
            this.NamaPerusahaanke.ReadOnly = true;
            this.NamaPerusahaanke.Visible = false;
            this.NamaPerusahaanke.Width = 70;
            // 
            // CabangKeID
            // 
            this.CabangKeID.DataPropertyName = "CabangKeID";
            this.CabangKeID.HeaderText = "Ke Cab.";
            this.CabangKeID.Name = "CabangKeID";
            this.CabangKeID.ReadOnly = true;
            this.CabangKeID.Visible = false;
            this.CabangKeID.Width = 50;
            // 
            // NamaVendor
            // 
            this.NamaVendor.DataPropertyName = "NamaVendor";
            this.NamaVendor.HeaderText = "Ke Vendor";
            this.NamaVendor.Name = "NamaVendor";
            this.NamaVendor.ReadOnly = true;
            this.NamaVendor.Width = 82;
            // 
            // JnsTransaksi
            // 
            this.JnsTransaksi.DataPropertyName = "NamaTransaksi";
            this.JnsTransaksi.HeaderText = "Jenis Transaksi";
            this.JnsTransaksi.Name = "JnsTransaksi";
            this.JnsTransaksi.ReadOnly = true;
            this.JnsTransaksi.Width = 109;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            this.MataUang.HeaderText = "Mata Uang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            this.MataUang.Width = 81;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle4;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            this.Nominal.Width = 76;
            // 
            // NominalIden
            // 
            this.NominalIden.DataPropertyName = "NominalIden";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.NominalIden.DefaultCellStyle = dataGridViewCellStyle5;
            this.NominalIden.HeaderText = "Nominal Iden";
            this.NominalIden.Name = "NominalIden";
            this.NominalIden.ReadOnly = true;
            this.NominalIden.Width = 95;
            // 
            // PenerimaanUang
            // 
            this.PenerimaanUang.DataPropertyName = "NominalPenerimaan";
            this.PenerimaanUang.HeaderText = "Penerimaan Uang";
            this.PenerimaanUang.Name = "PenerimaanUang";
            this.PenerimaanUang.ReadOnly = true;
            this.PenerimaanUang.Width = 117;
            // 
            // NominalSisa
            // 
            this.NominalSisa.DataPropertyName = "NominalSisa";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.NominalSisa.DefaultCellStyle = dataGridViewCellStyle6;
            this.NominalSisa.HeaderText = "Nominal Sisa";
            this.NominalSisa.Name = "NominalSisa";
            this.NominalSisa.ReadOnly = true;
            this.NominalSisa.Width = 94;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 66;
            // 
            // StatusApproval
            // 
            this.StatusApproval.DataPropertyName = "DescStatusApproval";
            this.StatusApproval.HeaderText = "Status Acc";
            this.StatusApproval.Name = "StatusApproval";
            this.StatusApproval.ReadOnly = true;
            this.StatusApproval.Visible = false;
            this.StatusApproval.Width = 150;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "NamaRekening";
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            this.Bank.Width = 59;
            // 
            // NoHI
            // 
            this.NoHI.DataPropertyName = "NoHI";
            this.NoHI.HeaderText = "No.DKN";
            this.NoHI.Name = "NoHI";
            this.NoHI.ReadOnly = true;
            this.NoHI.Visible = false;
            // 
            // IsPembayaran
            // 
            this.IsPembayaran.DataPropertyName = "IsPembayaran";
            this.IsPembayaran.HeaderText = "IsPembayaran";
            this.IsPembayaran.Name = "IsPembayaran";
            this.IsPembayaran.ReadOnly = true;
            this.IsPembayaran.Visible = false;
            // 
            // NoAcc
            // 
            this.NoAcc.DataPropertyName = "NoAcc";
            this.NoAcc.HeaderText = "NoAcc";
            this.NoAcc.Name = "NoAcc";
            this.NoAcc.ReadOnly = true;
            this.NoAcc.Visible = false;
            // 
            // GVDetail
            // 
            this.GVDetail.AllowUserToAddRows = false;
            this.GVDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GVDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.GVDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PelRowID,
            this.NoPembelian,
            this.NoFaktur,
            this.NamaVendorD,
            this.MerkMotor,
            this.TglPembelian,
            this.NominalBeli,
            this.Jenis,
            this.NoTrans,
            this.JenisPelunasan,
            this.TanggalIden,
            this.MataUangDet,
            this.Niden,
            this.Keterangan,
            this.JournalMPMRowID});
            this.GVDetail.Location = new System.Drawing.Point(32, 296);
            this.GVDetail.MultiSelect = false;
            this.GVDetail.Name = "GVDetail";
            this.GVDetail.ReadOnly = true;
            this.GVDetail.RowHeadersVisible = false;
            this.GVDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVDetail.Size = new System.Drawing.Size(768, 155);
            this.GVDetail.StandardTab = true;
            this.GVDetail.TabIndex = 45;
            this.GVDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVDetail_CellClick);
            this.GVDetail.Click += new System.EventHandler(this.GVDetail_Click);
            // 
            // PelRowID
            // 
            this.PelRowID.DataPropertyName = "RowID";
            this.PelRowID.HeaderText = "RowID";
            this.PelRowID.Name = "PelRowID";
            this.PelRowID.ReadOnly = true;
            this.PelRowID.Visible = false;
            // 
            // NoPembelian
            // 
            this.NoPembelian.DataPropertyName = "NoPembelian";
            this.NoPembelian.HeaderText = "No Pembelian";
            this.NoPembelian.Name = "NoPembelian";
            this.NoPembelian.ReadOnly = true;
            this.NoPembelian.Width = 98;
            // 
            // NoFaktur
            // 
            this.NoFaktur.DataPropertyName = "NoFaktur";
            this.NoFaktur.HeaderText = "No Faktur";
            this.NoFaktur.Name = "NoFaktur";
            this.NoFaktur.ReadOnly = true;
            this.NoFaktur.Width = 78;
            // 
            // NamaVendorD
            // 
            this.NamaVendorD.DataPropertyName = "NamaVendor";
            this.NamaVendorD.HeaderText = "Nama Vendor";
            this.NamaVendorD.Name = "NamaVendorD";
            this.NamaVendorD.ReadOnly = true;
            this.NamaVendorD.Width = 97;
            // 
            // MerkMotor
            // 
            this.MerkMotor.DataPropertyName = "MerkMotor";
            this.MerkMotor.HeaderText = "Merk / Tipe Motor";
            this.MerkMotor.Name = "MerkMotor";
            this.MerkMotor.ReadOnly = true;
            this.MerkMotor.Visible = false;
            // 
            // TglPembelian
            // 
            this.TglPembelian.DataPropertyName = "TglPembelian";
            this.TglPembelian.HeaderText = "TglPembelian";
            this.TglPembelian.Name = "TglPembelian";
            this.TglPembelian.ReadOnly = true;
            this.TglPembelian.Width = 107;
            // 
            // NominalBeli
            // 
            this.NominalBeli.DataPropertyName = "NominalBeli";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.NominalBeli.DefaultCellStyle = dataGridViewCellStyle8;
            this.NominalBeli.HeaderText = "Nominal Beli";
            this.NominalBeli.Name = "NominalBeli";
            this.NominalBeli.ReadOnly = true;
            this.NominalBeli.Width = 91;
            // 
            // Jenis
            // 
            this.Jenis.DataPropertyName = "Jenis";
            this.Jenis.HeaderText = "Jenis";
            this.Jenis.Name = "Jenis";
            this.Jenis.ReadOnly = true;
            this.Jenis.Visible = false;
            // 
            // NoTrans
            // 
            this.NoTrans.DataPropertyName = "NoTrans";
            this.NoTrans.HeaderText = "No. Transaksi Iden";
            this.NoTrans.Name = "NoTrans";
            this.NoTrans.ReadOnly = true;
            this.NoTrans.Width = 122;
            // 
            // JenisPelunasan
            // 
            this.JenisPelunasan.DataPropertyName = "KetJenis";
            this.JenisPelunasan.HeaderText = "Jenis Pelunasan";
            this.JenisPelunasan.Name = "JenisPelunasan";
            this.JenisPelunasan.ReadOnly = true;
            this.JenisPelunasan.Width = 112;
            // 
            // TanggalIden
            // 
            this.TanggalIden.DataPropertyName = "Tanggal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "dd/MM/yyyy";
            this.TanggalIden.DefaultCellStyle = dataGridViewCellStyle9;
            this.TanggalIden.HeaderText = "Tanggal Iden";
            this.TanggalIden.Name = "TanggalIden";
            this.TanggalIden.ReadOnly = true;
            this.TanggalIden.Width = 93;
            // 
            // MataUangDet
            // 
            this.MataUangDet.DataPropertyName = "MataUangID";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MataUangDet.DefaultCellStyle = dataGridViewCellStyle10;
            this.MataUangDet.HeaderText = "";
            this.MataUangDet.Name = "MataUangDet";
            this.MataUangDet.ReadOnly = true;
            this.MataUangDet.Width = 19;
            // 
            // Niden
            // 
            this.Niden.DataPropertyName = "Nominal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.Niden.DefaultCellStyle = dataGridViewCellStyle11;
            this.Niden.HeaderText = "Nominal Iden";
            this.Niden.Name = "Niden";
            this.Niden.ReadOnly = true;
            this.Niden.Width = 95;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 95;
            // 
            // JournalMPMRowID
            // 
            this.JournalMPMRowID.DataPropertyName = "JournalIdenRowID";
            this.JournalMPMRowID.HeaderText = "Journal RowID";
            this.JournalMPMRowID.Name = "JournalMPMRowID";
            this.JournalMPMRowID.ReadOnly = true;
            this.JournalMPMRowID.Visible = false;
            // 
            // cmdMutasi
            // 
            this.cmdMutasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdMutasi.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdMutasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdMutasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMutasi.Location = new System.Drawing.Point(267, 473);
            this.cmdMutasi.Name = "cmdMutasi";
            this.cmdMutasi.Size = new System.Drawing.Size(100, 40);
            this.cmdMutasi.TabIndex = 46;
            this.cmdMutasi.Text = "Mutasi";
            this.cmdMutasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdMutasi.UseVisualStyleBackColor = true;
            this.cmdMutasi.Click += new System.EventHandler(this.cmdMutasi_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(700, 472);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(32, 472);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 8;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdKoreksi
            // 
            this.cmdKoreksi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdKoreksi.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdKoreksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdKoreksi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdKoreksi.Location = new System.Drawing.Point(384, 473);
            this.cmdKoreksi.Name = "cmdKoreksi";
            this.cmdKoreksi.Size = new System.Drawing.Size(100, 40);
            this.cmdKoreksi.TabIndex = 47;
            this.cmdKoreksi.Text = "Koreksi Nominal MPM";
            this.cmdKoreksi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdKoreksi.UseVisualStyleBackColor = true;
            this.cmdKoreksi.Click += new System.EventHandler(this.cmdKoreksi_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(500, 473);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 48;
            this.cmdPrint.Text = "Print Detail";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // CMDPrintRekap
            // 
            this.CMDPrintRekap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CMDPrintRekap.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.CMDPrintRekap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CMDPrintRekap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMDPrintRekap.Location = new System.Drawing.Point(606, 473);
            this.CMDPrintRekap.Name = "CMDPrintRekap";
            this.CMDPrintRekap.Size = new System.Drawing.Size(100, 40);
            this.CMDPrintRekap.TabIndex = 49;
            this.CMDPrintRekap.Text = "Print Rekap Saldo";
            this.CMDPrintRekap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CMDPrintRekap.UseVisualStyleBackColor = true;
            this.CMDPrintRekap.Click += new System.EventHandler(this.CMDPrintRekap_Click);
            // 
            // frmPembayaranMPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 524);
            this.Controls.Add(this.CMDPrintRekap);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdKoreksi);
            this.Controls.Add(this.cmdMutasi);
            this.Controls.Add(this.GVDetail);
            this.Controls.Add(this.GVHeader);
            this.Controls.Add(this.rgtglKlr);
            this.Controls.Add(this.cmdBatalIden);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembayaranMPM";
            this.Text = "Iden Pembayaran MPM";
            this.Title = "Iden Pembayaran MPM";
            this.Load += new System.EventHandler(this.frmPembayaranMPM_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.btn_Search, 0);
            this.Controls.SetChildIndex(this.cmdBatalIden, 0);
            this.Controls.SetChildIndex(this.rgtglKlr, 0);
            this.Controls.SetChildIndex(this.GVHeader, 0);
            this.Controls.SetChildIndex(this.GVDetail, 0);
            this.Controls.SetChildIndex(this.cmdMutasi, 0);
            this.Controls.SetChildIndex(this.cmdKoreksi, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.CMDPrintRekap, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdADD;
        private System.Windows.Forms.Button btn_Search;
        private ISA.Controls.CommandButton cmdBatalIden;
        private ISA.Controls.RangeDateBox rgtglKlr;
        private ISA.Controls.CustomGridView GVHeader;
        private ISA.Controls.CustomGridView GVDetail;
        private ISA.Controls.CommandButton cmdMutasi;
        private ISA.Controls.CommandButton cmdKoreksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JnsTransaksiRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeJnsTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn HIRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalRk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPerusahaanke;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangKeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn JnsTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalIden;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenerimaanUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalSisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusApproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAcc;
        private ISA.Controls.CommandButton cmdPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PelRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPembelian;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoFaktur;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaVendorD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerkMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPembelian;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenis;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisPelunasan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalIden;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangDet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Niden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalMPMRowID;
        private ISA.Controls.CommandButton CMDPrintRekap;
    }
}