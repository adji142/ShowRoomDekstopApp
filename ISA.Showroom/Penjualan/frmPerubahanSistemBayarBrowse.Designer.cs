namespace ISA.Showroom.Penjualan
{
    partial class frmPerubahanSistemBayarBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerubahanSistemBayarBrowse));
            this.dgPenjualan = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PengeluaranKomisiRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nopol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaJadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leasing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIayaKomisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perantara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UangMuka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAwalAngs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAkhirAngs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bunga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeTransPJL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdUbahKeLeasing = new System.Windows.Forms.Button();
            this.cmdUbahKeKredit = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdTUNkeCTP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPenjualan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPenjualan
            // 
            this.dgPenjualan.AllowUserToAddRows = false;
            this.dgPenjualan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgPenjualan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPenjualan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPenjualan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgPenjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPenjualan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.PengeluaranKomisiRowID,
            this.NoTransaksi,
            this.NoBukti,
            this.Nopol,
            this.TglJual,
            this.Customer,
            this.Sales,
            this.Pembayaran,
            this.MataUang,
            this.HargaJadi,
            this.BBN,
            this.Total,
            this.Leasing,
            this.BIayaKomisi,
            this.Perantara,
            this.UangMuka,
            this.Discount,
            this.TglJT,
            this.TglAwalAngs,
            this.TglAkhirAngs,
            this.Tempo,
            this.Bunga,
            this.Keterangan,
            this.KodeTransPJL});
            this.dgPenjualan.Location = new System.Drawing.Point(31, 69);
            this.dgPenjualan.MultiSelect = false;
            this.dgPenjualan.Name = "dgPenjualan";
            this.dgPenjualan.ReadOnly = true;
            this.dgPenjualan.RowHeadersVisible = false;
            this.dgPenjualan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgPenjualan.Size = new System.Drawing.Size(994, 298);
            this.dgPenjualan.StandardTab = true;
            this.dgPenjualan.TabIndex = 53;
            this.dgPenjualan.SelectionChanged += new System.EventHandler(this.dgPenjualan_SelectionChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // PengeluaranKomisiRowID
            // 
            this.PengeluaranKomisiRowID.DataPropertyName = "PengeluaranKomisiRowID";
            this.PengeluaranKomisiRowID.HeaderText = "Pengeluaran Komisi RowID";
            this.PengeluaranKomisiRowID.Name = "PengeluaranKomisiRowID";
            this.PengeluaranKomisiRowID.ReadOnly = true;
            this.PengeluaranKomisiRowID.Visible = false;
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
            // Pembayaran
            // 
            this.Pembayaran.DataPropertyName = "KodeTrans";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Pembayaran.DefaultCellStyle = dataGridViewCellStyle4;
            this.Pembayaran.HeaderText = "Pembayaran";
            this.Pembayaran.Name = "Pembayaran";
            this.Pembayaran.ReadOnly = true;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MataUang.DefaultCellStyle = dataGridViewCellStyle5;
            this.MataUang.HeaderText = "Mata Uang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            this.MataUang.Width = 90;
            // 
            // HargaJadi
            // 
            this.HargaJadi.DataPropertyName = "HargaJadi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.HargaJadi.DefaultCellStyle = dataGridViewCellStyle6;
            this.HargaJadi.HeaderText = "Harga Kosong";
            this.HargaJadi.Name = "HargaJadi";
            this.HargaJadi.ReadOnly = true;
            this.HargaJadi.Width = 120;
            // 
            // BBN
            // 
            this.BBN.DataPropertyName = "BBN";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.BBN.DefaultCellStyle = dataGridViewCellStyle7;
            this.BBN.HeaderText = "BBN";
            this.BBN.Name = "BBN";
            this.BBN.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "HargaOff";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.Total.HeaderText = "Harga Jual Nett";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 120;
            // 
            // Leasing
            // 
            this.Leasing.DataPropertyName = "Leasing";
            this.Leasing.HeaderText = "Leasing";
            this.Leasing.Name = "Leasing";
            this.Leasing.ReadOnly = true;
            this.Leasing.Width = 130;
            // 
            // BIayaKomisi
            // 
            this.BIayaKomisi.DataPropertyName = "BiayaKomisi";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.BIayaKomisi.DefaultCellStyle = dataGridViewCellStyle9;
            this.BIayaKomisi.HeaderText = "Komisi";
            this.BIayaKomisi.Name = "BIayaKomisi";
            this.BIayaKomisi.ReadOnly = true;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.UangMuka.DefaultCellStyle = dataGridViewCellStyle10;
            this.UangMuka.HeaderText = "Uang Muka";
            this.UangMuka.Name = "UangMuka";
            this.UangMuka.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.Discount.DefaultCellStyle = dataGridViewCellStyle11;
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // TglJT
            // 
            this.TglJT.DataPropertyName = "TglJT";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.NullValue = null;
            this.TglJT.DefaultCellStyle = dataGridViewCellStyle12;
            this.TglJT.HeaderText = "Tgl Angsuran";
            this.TglJT.Name = "TglJT";
            this.TglJT.ReadOnly = true;
            this.TglJT.Width = 105;
            // 
            // TglAwalAngs
            // 
            this.TglAwalAngs.DataPropertyName = "TglAwalAngs";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "dd-MMM-yyyy";
            this.TglAwalAngs.DefaultCellStyle = dataGridViewCellStyle13;
            this.TglAwalAngs.HeaderText = "Tgl Awal Angsuran";
            this.TglAwalAngs.Name = "TglAwalAngs";
            this.TglAwalAngs.ReadOnly = true;
            this.TglAwalAngs.Width = 135;
            // 
            // TglAkhirAngs
            // 
            this.TglAkhirAngs.DataPropertyName = "TglAkhirAngs";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "dd-MMM-yyyy";
            this.TglAkhirAngs.DefaultCellStyle = dataGridViewCellStyle14;
            this.TglAkhirAngs.HeaderText = "Tgl Akhir Angsuran";
            this.TglAkhirAngs.Name = "TglAkhirAngs";
            this.TglAkhirAngs.ReadOnly = true;
            this.TglAkhirAngs.Width = 138;
            // 
            // Tempo
            // 
            this.Tempo.DataPropertyName = "TempoAngsuran";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tempo.DefaultCellStyle = dataGridViewCellStyle15;
            this.Tempo.HeaderText = "Tempo";
            this.Tempo.Name = "Tempo";
            this.Tempo.ReadOnly = true;
            this.Tempo.Width = 50;
            // 
            // Bunga
            // 
            this.Bunga.DataPropertyName = "Bunga";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Bunga.DefaultCellStyle = dataGridViewCellStyle16;
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
            // KodeTransPJL
            // 
            this.KodeTransPJL.DataPropertyName = "KodeTransPJL";
            this.KodeTransPJL.HeaderText = "KodeTransPJL";
            this.KodeTransPJL.Name = "KodeTransPJL";
            this.KodeTransPJL.ReadOnly = true;
            this.KodeTransPJL.Visible = false;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(925, 386);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 55;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdUbahKeLeasing
            // 
            this.cmdUbahKeLeasing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUbahKeLeasing.Location = new System.Drawing.Point(31, 386);
            this.cmdUbahKeLeasing.Name = "cmdUbahKeLeasing";
            this.cmdUbahKeLeasing.Size = new System.Drawing.Size(88, 40);
            this.cmdUbahKeLeasing.TabIndex = 56;
            this.cmdUbahKeLeasing.Text = "UBAH KE LEASING";
            this.cmdUbahKeLeasing.UseVisualStyleBackColor = true;
            this.cmdUbahKeLeasing.Click += new System.EventHandler(this.cmdUbahKeLeasing_Click);
            // 
            // cmdUbahKeKredit
            // 
            this.cmdUbahKeKredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUbahKeKredit.Location = new System.Drawing.Point(125, 386);
            this.cmdUbahKeKredit.Name = "cmdUbahKeKredit";
            this.cmdUbahKeKredit.Size = new System.Drawing.Size(88, 40);
            this.cmdUbahKeKredit.TabIndex = 57;
            this.cmdUbahKeKredit.Text = "UBAH KE KREDIT";
            this.cmdUbahKeKredit.UseVisualStyleBackColor = true;
            this.cmdUbahKeKredit.Click += new System.EventHandler(this.cmdUbahKeKredit_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdRefresh.Image = global::ISA.Showroom.Properties.Resources.Refresh;
            this.cmdRefresh.Location = new System.Drawing.Point(478, 386);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(95, 40);
            this.cmdRefresh.TabIndex = 58;
            this.cmdRefresh.Text = "REFRESH";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdTUNkeCTP
            // 
            this.cmdTUNkeCTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTUNkeCTP.Location = new System.Drawing.Point(219, 386);
            this.cmdTUNkeCTP.Name = "cmdTUNkeCTP";
            this.cmdTUNkeCTP.Size = new System.Drawing.Size(91, 40);
            this.cmdTUNkeCTP.TabIndex = 59;
            this.cmdTUNkeCTP.Text = "CASH KE CASH TEMPO";
            this.cmdTUNkeCTP.UseVisualStyleBackColor = true;
            this.cmdTUNkeCTP.Click += new System.EventHandler(this.cmdTUNkeCTP_Click);
            // 
            // frmPerubahanSistemBayarBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 449);
            this.Controls.Add(this.cmdTUNkeCTP);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdUbahKeKredit);
            this.Controls.Add(this.cmdUbahKeLeasing);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.dgPenjualan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPerubahanSistemBayarBrowse";
            this.Text = "Perubahan Sistem Pembayaran";
            this.Title = "Perubahan Sistem Pembayaran";
            this.Load += new System.EventHandler(this.frmPerubahanSistemBayarBrowse_Load);
            this.Controls.SetChildIndex(this.dgPenjualan, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdUbahKeLeasing, 0);
            this.Controls.SetChildIndex(this.cmdUbahKeKredit, 0);
            this.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.Controls.SetChildIndex(this.cmdTUNkeCTP, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgPenjualan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgPenjualan;
        private ISA.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Button cmdUbahKeLeasing;
        private System.Windows.Forms.Button cmdUbahKeKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PengeluaranKomisiRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nopol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaJadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leasing;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIayaKomisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perantara;
        private System.Windows.Forms.DataGridViewTextBoxColumn UangMuka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAwalAngs;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAkhirAngs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bunga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeTransPJL;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdTUNkeCTP;

    }
}