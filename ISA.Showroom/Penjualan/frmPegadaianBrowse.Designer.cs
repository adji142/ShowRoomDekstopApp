﻿namespace ISA.Showroom.Penjualan
{
    partial class frmPegadaianBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPegadaianBrowse));
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PengeluaranUangRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenjRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenjHistRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nopol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolektor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaJadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PinjamanFisik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaEstimasiMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perantara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UangMuka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAwalAngs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAkhirAngs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bunga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.rdtTanggal = new ISA.Controls.RangeDateBox();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdPRINT = new ISA.Controls.CommandButton();
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
            this.PengeluaranUangRowID,
            this.PenjRowID,
            this.PenjHistRowID,
            this.NoTransaksi,
            this.NoBukti,
            this.Nopol,
            this.TglJual,
            this.Customer,
            this.Sales,
            this.Kolektor,
            this.MataUang,
            this.HargaJadi,
            this.Total,
            this.PinjamanFisik,
            this.HargaEstimasiMotor,
            this.Perantara,
            this.UangMuka,
            this.TglJT,
            this.TglAwalAngs,
            this.TglAkhirAngs,
            this.Tempo,
            this.Bunga,
            this.Keterangan});
            this.dataGridView1.Location = new System.Drawing.Point(31, 102);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(713, 193);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 52;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // PengeluaranUangRowID
            // 
            this.PengeluaranUangRowID.DataPropertyName = "PengeluaranUangRowID";
            this.PengeluaranUangRowID.HeaderText = "Pengeluaran Uang Pinjaman Fisik RowID";
            this.PengeluaranUangRowID.Name = "PengeluaranUangRowID";
            this.PengeluaranUangRowID.ReadOnly = true;
            this.PengeluaranUangRowID.Visible = false;
            // 
            // PenjRowID
            // 
            this.PenjRowID.DataPropertyName = "PenjRowID";
            this.PenjRowID.HeaderText = "Row ID Penjualan";
            this.PenjRowID.Name = "PenjRowID";
            this.PenjRowID.ReadOnly = true;
            this.PenjRowID.Visible = false;
            // 
            // PenjHistRowID
            // 
            this.PenjHistRowID.DataPropertyName = "PenjHistRowID";
            this.PenjHistRowID.HeaderText = "RowID Histori Penjualan";
            this.PenjHistRowID.Name = "PenjHistRowID";
            this.PenjHistRowID.ReadOnly = true;
            this.PenjHistRowID.Visible = false;
            // 
            // NoTransaksi
            // 
            this.NoTransaksi.DataPropertyName = "NoTrans";
            this.NoTransaksi.HeaderText = "No. Transaksi";
            this.NoTransaksi.Name = "NoTransaksi";
            this.NoTransaksi.ReadOnly = true;
            this.NoTransaksi.Width = 110;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No. Bukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
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
            // TglJual
            // 
            this.TglJual.DataPropertyName = "TglJual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TglJual.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglJual.HeaderText = "Tanggal";
            this.TglJual.Name = "TglJual";
            this.TglJual.ReadOnly = true;
            this.TglJual.Width = 108;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Width = 130;
            // 
            // Sales
            // 
            this.Sales.DataPropertyName = "Sales";
            this.Sales.HeaderText = "Sales";
            this.Sales.Name = "Sales";
            this.Sales.ReadOnly = true;
            this.Sales.Width = 130;
            // 
            // Kolektor
            // 
            this.Kolektor.DataPropertyName = "Kolektor";
            this.Kolektor.HeaderText = "Kolektor";
            this.Kolektor.Name = "Kolektor";
            this.Kolektor.ReadOnly = true;
            this.Kolektor.Width = 130;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MataUang.DefaultCellStyle = dataGridViewCellStyle4;
            this.MataUang.HeaderText = "Mata Uang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            this.MataUang.Width = 90;
            // 
            // HargaJadi
            // 
            this.HargaJadi.DataPropertyName = "HargaJadi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.HargaJadi.DefaultCellStyle = dataGridViewCellStyle5;
            this.HargaJadi.HeaderText = "Harga Kosong";
            this.HargaJadi.Name = "HargaJadi";
            this.HargaJadi.ReadOnly = true;
            this.HargaJadi.Width = 120;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "HargaOff";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle6;
            this.Total.HeaderText = "Harga Jual Nett";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 120;
            // 
            // PinjamanFisik
            // 
            this.PinjamanFisik.DataPropertyName = "PinjamanFisik";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.PinjamanFisik.DefaultCellStyle = dataGridViewCellStyle7;
            this.PinjamanFisik.HeaderText = "Pinjaman";
            this.PinjamanFisik.Name = "PinjamanFisik";
            this.PinjamanFisik.ReadOnly = true;
            // 
            // HargaEstimasiMotor
            // 
            this.HargaEstimasiMotor.DataPropertyName = "HargaEstimasiMotor";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.HargaEstimasiMotor.DefaultCellStyle = dataGridViewCellStyle8;
            this.HargaEstimasiMotor.HeaderText = "Harga Motor";
            this.HargaEstimasiMotor.Name = "HargaEstimasiMotor";
            this.HargaEstimasiMotor.ReadOnly = true;
            // 
            // Perantara
            // 
            this.Perantara.DataPropertyName = "Via";
            this.Perantara.HeaderText = "Perantara";
            this.Perantara.Name = "Perantara";
            this.Perantara.ReadOnly = true;
            this.Perantara.Width = 130;
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
            // TglJT
            // 
            this.TglJT.DataPropertyName = "TglJT";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = null;
            this.TglJT.DefaultCellStyle = dataGridViewCellStyle10;
            this.TglJT.HeaderText = "Tgl Angsuran";
            this.TglJT.Name = "TglJT";
            this.TglJT.ReadOnly = true;
            this.TglJT.Width = 105;
            // 
            // TglAwalAngs
            // 
            this.TglAwalAngs.DataPropertyName = "TglAwalAngs";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "dd-MMM-yyyy";
            this.TglAwalAngs.DefaultCellStyle = dataGridViewCellStyle11;
            this.TglAwalAngs.HeaderText = "Tgl Awal Angsuran";
            this.TglAwalAngs.Name = "TglAwalAngs";
            this.TglAwalAngs.ReadOnly = true;
            this.TglAwalAngs.Width = 135;
            // 
            // TglAkhirAngs
            // 
            this.TglAkhirAngs.DataPropertyName = "TglAkhirAngs";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "dd-MMM-yyyy";
            this.TglAkhirAngs.DefaultCellStyle = dataGridViewCellStyle12;
            this.TglAkhirAngs.HeaderText = "Tgl Akhir Angsuran";
            this.TglAkhirAngs.Name = "TglAkhirAngs";
            this.TglAkhirAngs.ReadOnly = true;
            this.TglAkhirAngs.Width = 138;
            // 
            // Tempo
            // 
            this.Tempo.DataPropertyName = "TempoAngsuran";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tempo.DefaultCellStyle = dataGridViewCellStyle13;
            this.Tempo.HeaderText = "Tempo";
            this.Tempo.Name = "Tempo";
            this.Tempo.ReadOnly = true;
            this.Tempo.Width = 50;
            // 
            // Bunga
            // 
            this.Bunga.DataPropertyName = "Bunga";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Bunga.DefaultCellStyle = dataGridViewCellStyle14;
            this.Bunga.HeaderText = "Bunga (%)";
            this.Bunga.Name = "Bunga";
            this.Bunga.ReadOnly = true;
            this.Bunga.Width = 84;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(31, 341);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 51;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 14);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tanggal Pegadaian";
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(381, 65);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(58, 23);
            this.btnCari.TabIndex = 54;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // rdtTanggal
            // 
            this.rdtTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdtTanggal.FromDate = null;
            this.rdtTanggal.Location = new System.Drawing.Point(140, 66);
            this.rdtTanggal.Name = "rdtTanggal";
            this.rdtTanggal.Size = new System.Drawing.Size(257, 22);
            this.rdtTanggal.TabIndex = 53;
            this.rdtTanggal.ToDate = null;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(655, 341);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 57;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(158, 341);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 56;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(276, 341);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 58;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // frmPegadaianBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 393);
            this.Controls.Add(this.cmdPRINT);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.rdtTanggal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdADD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPegadaianBrowse";
            this.Text = "Pegadaian";
            this.Title = "Pegadaian";
            this.Load += new System.EventHandler(this.frmPegadaianBrowse_Load);
            this.Activated += new System.EventHandler(this.frmPegadaianBrowse_Activated);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.rdtTanggal, 0);
            this.Controls.SetChildIndex(this.btnCari, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCari;
        private ISA.Controls.RangeDateBox rdtTanggal;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdPRINT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PengeluaranUangRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjHistRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nopol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolektor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaJadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn PinjamanFisik;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaEstimasiMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perantara;
        private System.Windows.Forms.DataGridViewTextBoxColumn UangMuka;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAwalAngs;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAkhirAngs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bunga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
    }
}