﻿namespace ISA.Showroom.Pembelian
{
    partial class frmPembelianBrowseTLA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembelianBrowseTLA));
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.rdtTanggal = new ISA.Controls.RangeDateBox();
            this.cmdPRINT = new System.Windows.Forms.Button();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.cmdBA = new System.Windows.Forms.Button();
            this.cmdCekList = new System.Windows.Forms.Button();
            this.cmdEditTglTerima = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoFaktur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerkMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nopol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaJadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UangMuka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaOTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BPKB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STNK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KontakUt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KontakCad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KunciPas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManualBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BukuServis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JRI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NoTransaksi,
            this.NoFaktur,
            this.NamaVendor,
            this.MerkMotor,
            this.Nopol,
            this.TglBeli,
            this.TglTerima,
            this.TglJT,
            this.TglJual,
            this.MataUang,
            this.HargaJadi,
            this.UangMuka,
            this.HargaOTR,
            this.BPKB,
            this.STNK,
            this.KontakUt,
            this.KontakCad,
            this.KunciPas,
            this.ManualBook,
            this.BukuServis,
            this.JRI,
            this.TJ});
            this.dataGridView1.Location = new System.Drawing.Point(26, 89);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1134, 205);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 14);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tanggal Pembelian";
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(376, 60);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(58, 23);
            this.btnCari.TabIndex = 1;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // rdtTanggal
            // 
            this.rdtTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdtTanggal.FromDate = null;
            this.rdtTanggal.Location = new System.Drawing.Point(135, 61);
            this.rdtTanggal.Name = "rdtTanggal";
            this.rdtTanggal.Size = new System.Drawing.Size(257, 22);
            this.rdtTanggal.TabIndex = 0;
            this.rdtTanggal.ToDate = null;
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = global::ISA.Showroom.Properties.Resources.Printer32;
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(453, 309);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 6;
            this.cmdPRINT.Text = "PRINT FAKTUR";
            this.cmdPRINT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(1053, 309);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 9;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(241, 309);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 4;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(135, 309);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 3;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(29, 309);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 2;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdBA
            // 
            this.cmdBA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBA.Image = global::ISA.Showroom.Properties.Resources.Printer32;
            this.cmdBA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBA.Location = new System.Drawing.Point(559, 309);
            this.cmdBA.Name = "cmdBA";
            this.cmdBA.Size = new System.Drawing.Size(110, 40);
            this.cmdBA.TabIndex = 7;
            this.cmdBA.Text = "PRINT BA";
            this.cmdBA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBA.UseVisualStyleBackColor = true;
            this.cmdBA.Click += new System.EventHandler(this.cmdBA_Click);
            // 
            // cmdCekList
            // 
            this.cmdCekList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCekList.Enabled = false;
            this.cmdCekList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCekList.Image = global::ISA.Showroom.Properties.Resources.Ok32;
            this.cmdCekList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCekList.Location = new System.Drawing.Point(347, 309);
            this.cmdCekList.Name = "cmdCekList";
            this.cmdCekList.Size = new System.Drawing.Size(100, 40);
            this.cmdCekList.TabIndex = 5;
            this.cmdCekList.Text = "CEK LIST";
            this.cmdCekList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCekList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCekList.UseVisualStyleBackColor = true;
            this.cmdCekList.Click += new System.EventHandler(this.cmdCekList_Click);
            // 
            // cmdEditTglTerima
            // 
            this.cmdEditTglTerima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEditTglTerima.Image = global::ISA.Showroom.Properties.Resources.Ok32;
            this.cmdEditTglTerima.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditTglTerima.Location = new System.Drawing.Point(675, 311);
            this.cmdEditTglTerima.Name = "cmdEditTglTerima";
            this.cmdEditTglTerima.Size = new System.Drawing.Size(98, 40);
            this.cmdEditTglTerima.TabIndex = 8;
            this.cmdEditTglTerima.Text = "EDIT TGL TERIMA";
            this.cmdEditTglTerima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditTglTerima.UseVisualStyleBackColor = true;
            this.cmdEditTglTerima.Click += new System.EventHandler(this.cmdEditTglTerima_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Image = global::ISA.Showroom.Properties.Resources.Close16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(861, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 38;
            this.button1.Text = "BATAL PEMBELIAN";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Image = global::ISA.Showroom.Properties.Resources.Edit32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(779, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 40);
            this.button2.TabIndex = 39;
            this.button2.Text = "UBAH HARGA";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NoTransaksi
            // 
            this.NoTransaksi.DataPropertyName = "NoTrans";
            this.NoTransaksi.HeaderText = "No. Transaksi";
            this.NoTransaksi.Name = "NoTransaksi";
            this.NoTransaksi.ReadOnly = true;
            this.NoTransaksi.Width = 110;
            // 
            // NoFaktur
            // 
            this.NoFaktur.DataPropertyName = "NoFaktur";
            this.NoFaktur.HeaderText = "No. Faktur";
            this.NoFaktur.Name = "NoFaktur";
            this.NoFaktur.ReadOnly = true;
            // 
            // NamaVendor
            // 
            this.NamaVendor.DataPropertyName = "NamaVendor";
            this.NamaVendor.HeaderText = "Nama Vendor";
            this.NamaVendor.Name = "NamaVendor";
            this.NamaVendor.ReadOnly = true;
            this.NamaVendor.Width = 150;
            // 
            // MerkMotor
            // 
            this.MerkMotor.DataPropertyName = "MerkType";
            this.MerkMotor.HeaderText = "Merk / Type Motor";
            this.MerkMotor.Name = "MerkMotor";
            this.MerkMotor.ReadOnly = true;
            this.MerkMotor.Width = 150;
            // 
            // Nopol
            // 
            this.Nopol.DataPropertyName = "Nopol";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Nopol.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nopol.HeaderText = "Nopol";
            this.Nopol.Name = "Nopol";
            this.Nopol.ReadOnly = true;
            // 
            // TglBeli
            // 
            this.TglBeli.DataPropertyName = "TglBeli";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TglBeli.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglBeli.HeaderText = "Tgl Pembelian";
            this.TglBeli.Name = "TglBeli";
            this.TglBeli.ReadOnly = true;
            this.TglBeli.Width = 108;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglTerima.HeaderText = "Tgl Terima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            // 
            // TglJT
            // 
            this.TglJT.DataPropertyName = "TglJT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            this.TglJT.DefaultCellStyle = dataGridViewCellStyle5;
            this.TglJT.HeaderText = "Tgl Jatuh Tempo";
            this.TglJT.Name = "TglJT";
            this.TglJT.ReadOnly = true;
            this.TglJT.Width = 125;
            // 
            // TglJual
            // 
            this.TglJual.DataPropertyName = "TglJual";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "dd-MMM-yyyy";
            this.TglJual.DefaultCellStyle = dataGridViewCellStyle6;
            this.TglJual.HeaderText = "Tgl Penjualan";
            this.TglJual.Name = "TglJual";
            this.TglJual.ReadOnly = true;
            this.TglJual.Width = 108;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MataUang.DefaultCellStyle = dataGridViewCellStyle7;
            this.MataUang.HeaderText = "Mata Uang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            this.MataUang.Width = 90;
            // 
            // HargaJadi
            // 
            this.HargaJadi.DataPropertyName = "HargaJadi";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.HargaJadi.DefaultCellStyle = dataGridViewCellStyle8;
            this.HargaJadi.HeaderText = "Harga Jadi";
            this.HargaJadi.Name = "HargaJadi";
            this.HargaJadi.ReadOnly = true;
            // 
            // UangMuka
            // 
            this.UangMuka.DataPropertyName = "UangMuka";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.UangMuka.DefaultCellStyle = dataGridViewCellStyle9;
            this.UangMuka.HeaderText = "Uang Muka";
            this.UangMuka.Name = "UangMuka";
            this.UangMuka.ReadOnly = true;
            // 
            // HargaOTR
            // 
            this.HargaOTR.DataPropertyName = "HargaOTR";
            dataGridViewCellStyle10.Format = "N2";
            this.HargaOTR.DefaultCellStyle = dataGridViewCellStyle10;
            this.HargaOTR.HeaderText = "Harga OTR";
            this.HargaOTR.Name = "HargaOTR";
            this.HargaOTR.ReadOnly = true;
            // 
            // BPKB
            // 
            this.BPKB.DataPropertyName = "cekBPKB";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BPKB.DefaultCellStyle = dataGridViewCellStyle11;
            this.BPKB.HeaderText = "BPKB";
            this.BPKB.Name = "BPKB";
            this.BPKB.ReadOnly = true;
            this.BPKB.Width = 50;
            // 
            // STNK
            // 
            this.STNK.DataPropertyName = "cekSTNK";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STNK.DefaultCellStyle = dataGridViewCellStyle12;
            this.STNK.HeaderText = "STNK";
            this.STNK.Name = "STNK";
            this.STNK.ReadOnly = true;
            this.STNK.Width = 50;
            // 
            // KontakUt
            // 
            this.KontakUt.DataPropertyName = "cekKunciUtama";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KontakUt.DefaultCellStyle = dataGridViewCellStyle13;
            this.KontakUt.HeaderText = "Kunci Kontak Utama";
            this.KontakUt.Name = "KontakUt";
            this.KontakUt.ReadOnly = true;
            this.KontakUt.Width = 140;
            // 
            // KontakCad
            // 
            this.KontakCad.DataPropertyName = "cekKunciDuplikat";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KontakCad.DefaultCellStyle = dataGridViewCellStyle14;
            this.KontakCad.HeaderText = "Kunci Kontak Cadangan";
            this.KontakCad.Name = "KontakCad";
            this.KontakCad.ReadOnly = true;
            this.KontakCad.Width = 160;
            // 
            // KunciPas
            // 
            this.KunciPas.DataPropertyName = "cekKunciPas";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KunciPas.DefaultCellStyle = dataGridViewCellStyle15;
            this.KunciPas.HeaderText = "Toolset";
            this.KunciPas.Name = "KunciPas";
            this.KunciPas.ReadOnly = true;
            this.KunciPas.Width = 70;
            // 
            // ManualBook
            // 
            this.ManualBook.DataPropertyName = "cekManualBook";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ManualBook.DefaultCellStyle = dataGridViewCellStyle16;
            this.ManualBook.HeaderText = "Buku Manual";
            this.ManualBook.Name = "ManualBook";
            this.ManualBook.ReadOnly = true;
            // 
            // BukuServis
            // 
            this.BukuServis.DataPropertyName = "cekBukuServis";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BukuServis.DefaultCellStyle = dataGridViewCellStyle17;
            this.BukuServis.HeaderText = "Buku Servis";
            this.BukuServis.Name = "BukuServis";
            this.BukuServis.ReadOnly = true;
            // 
            // JRI
            // 
            this.JRI.DataPropertyName = "JRI";
            this.JRI.HeaderText = "JRI";
            this.JRI.Name = "JRI";
            this.JRI.ReadOnly = true;
            this.JRI.Visible = false;
            // 
            // TJ
            // 
            this.TJ.DataPropertyName = "TJ";
            this.TJ.HeaderText = "TJ";
            this.TJ.Name = "TJ";
            this.TJ.ReadOnly = true;
            this.TJ.Visible = false;
            // 
            // frmPembelianBrowseTLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 372);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdEditTglTerima);
            this.Controls.Add(this.cmdCekList);
            this.Controls.Add(this.cmdBA);
            this.Controls.Add(this.cmdPRINT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.rdtTanggal);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembelianBrowseTLA";
            this.Text = "Pembelian BARU";
            this.Title = "Pembelian BARU";
            this.Load += new System.EventHandler(this.frmPembelianBrowseTLA_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.rdtTanggal, 0);
            this.Controls.SetChildIndex(this.btnCari, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            this.Controls.SetChildIndex(this.cmdBA, 0);
            this.Controls.SetChildIndex(this.cmdCekList, 0);
            this.Controls.SetChildIndex(this.cmdEditTglTerima, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCari;
        private ISA.Controls.RangeDateBox rdtTanggal;
        private System.Windows.Forms.Button cmdPRINT;
        private System.Windows.Forms.Button cmdBA;
        private System.Windows.Forms.Button cmdCekList;
        private System.Windows.Forms.Button cmdEditTglTerima;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoFaktur;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerkMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nopol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaJadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn UangMuka;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaOTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn BPKB;
        private System.Windows.Forms.DataGridViewTextBoxColumn STNK;
        private System.Windows.Forms.DataGridViewTextBoxColumn KontakUt;
        private System.Windows.Forms.DataGridViewTextBoxColumn KontakCad;
        private System.Windows.Forms.DataGridViewTextBoxColumn KunciPas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManualBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn BukuServis;
        private System.Windows.Forms.DataGridViewTextBoxColumn JRI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TJ;



    }
}