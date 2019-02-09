namespace ISA.Showroom.Penjualan
{
    partial class frmUMSubsidiBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUMSubsidiBrowse));
            this.dgPenjualanBersubsidi = new ISA.Controls.CustomGridView();
            this.PenjRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSurveyor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subsidi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubsidiTerbayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Via = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDetilPenerimaanSubsidi = new ISA.Controls.CustomGridView();
            this.PenerimaanUMRowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenjRowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BentukPembayaranDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBGCDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeteranganDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenerimaanUangRowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.rdtTanggal = new ISA.Controls.RangeDateBox();
            this.cmdADD = new System.Windows.Forms.Button();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgPenjualanBersubsidi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetilPenerimaanSubsidi)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPenjualanBersubsidi
            // 
            this.dgPenjualanBersubsidi.AllowUserToAddRows = false;
            this.dgPenjualanBersubsidi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgPenjualanBersubsidi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPenjualanBersubsidi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPenjualanBersubsidi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgPenjualanBersubsidi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPenjualanBersubsidi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PenjRowID,
            this.CustRowID,
            this.NoTrans,
            this.NoBukti,
            this.NoPol,
            this.TglJual,
            this.NamaCustomer,
            this.NamaSales,
            this.NamaSurveyor,
            this.MataUang,
            this.Subsidi,
            this.SubsidiTerbayar,
            this.Keterangan,
            this.Via});
            this.dgPenjualanBersubsidi.Location = new System.Drawing.Point(3, 3);
            this.dgPenjualanBersubsidi.Name = "dgPenjualanBersubsidi";
            this.dgPenjualanBersubsidi.ReadOnly = true;
            this.dgPenjualanBersubsidi.RowHeadersVisible = false;
            this.dgPenjualanBersubsidi.Size = new System.Drawing.Size(848, 214);
            this.dgPenjualanBersubsidi.StandardTab = true;
            this.dgPenjualanBersubsidi.TabIndex = 5;
            this.dgPenjualanBersubsidi.SelectionChanged += new System.EventHandler(this.dgPenjualanBersubsidi_SelectionChanged);
            // 
            // PenjRowID
            // 
            this.PenjRowID.DataPropertyName = "PenjRowID";
            this.PenjRowID.HeaderText = "PenjRowID";
            this.PenjRowID.Name = "PenjRowID";
            this.PenjRowID.ReadOnly = true;
            this.PenjRowID.Visible = false;
            // 
            // CustRowID
            // 
            this.CustRowID.DataPropertyName = "CustRowID";
            this.CustRowID.HeaderText = "CustRowID";
            this.CustRowID.Name = "CustRowID";
            this.CustRowID.ReadOnly = true;
            this.CustRowID.Visible = false;
            // 
            // NoTrans
            // 
            this.NoTrans.DataPropertyName = "NoTrans";
            this.NoTrans.HeaderText = "No. Trans";
            this.NoTrans.Name = "NoTrans";
            this.NoTrans.ReadOnly = true;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No. Bukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // NoPol
            // 
            this.NoPol.DataPropertyName = "Nopol";
            this.NoPol.HeaderText = "No. Polisi";
            this.NoPol.Name = "NoPol";
            this.NoPol.ReadOnly = true;
            // 
            // TglJual
            // 
            this.TglJual.DataPropertyName = "TglJual";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.TglJual.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglJual.HeaderText = "Tgl Jual";
            this.TglJual.Name = "TglJual";
            this.TglJual.ReadOnly = true;
            // 
            // NamaCustomer
            // 
            this.NamaCustomer.DataPropertyName = "NamaCustomer";
            this.NamaCustomer.HeaderText = "Customer";
            this.NamaCustomer.Name = "NamaCustomer";
            this.NamaCustomer.ReadOnly = true;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "NamaSales";
            this.NamaSales.HeaderText = "Sales";
            this.NamaSales.Name = "NamaSales";
            this.NamaSales.ReadOnly = true;
            // 
            // NamaSurveyor
            // 
            this.NamaSurveyor.DataPropertyName = "NamaSurveyor";
            this.NamaSurveyor.HeaderText = "Surveyor";
            this.NamaSurveyor.Name = "NamaSurveyor";
            this.NamaSurveyor.ReadOnly = true;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            this.MataUang.HeaderText = "MataUang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            // 
            // Subsidi
            // 
            this.Subsidi.DataPropertyName = "Subsidi";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Subsidi.DefaultCellStyle = dataGridViewCellStyle3;
            this.Subsidi.HeaderText = "Subsidi";
            this.Subsidi.Name = "Subsidi";
            this.Subsidi.ReadOnly = true;
            // 
            // SubsidiTerbayar
            // 
            this.SubsidiTerbayar.DataPropertyName = "SubsidiTerbayar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.SubsidiTerbayar.DefaultCellStyle = dataGridViewCellStyle4;
            this.SubsidiTerbayar.HeaderText = "Subsidi Terbayar";
            this.SubsidiTerbayar.Name = "SubsidiTerbayar";
            this.SubsidiTerbayar.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            // 
            // Via
            // 
            this.Via.DataPropertyName = "Via";
            this.Via.HeaderText = "Via";
            this.Via.Name = "Via";
            this.Via.ReadOnly = true;
            // 
            // dgDetilPenerimaanSubsidi
            // 
            this.dgDetilPenerimaanSubsidi.AllowUserToAddRows = false;
            this.dgDetilPenerimaanSubsidi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgDetilPenerimaanSubsidi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDetilPenerimaanSubsidi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetilPenerimaanSubsidi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDetilPenerimaanSubsidi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetilPenerimaanSubsidi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PenerimaanUMRowIDDetail,
            this.PenjRowIDDetail,
            this.NoTransDetail,
            this.TanggalDetail,
            this.NominalDetail,
            this.BentukPembayaranDetail,
            this.StatusBGCDetail,
            this.KeteranganDetail,
            this.PenerimaanUangRowIDDetail});
            this.dgDetilPenerimaanSubsidi.Location = new System.Drawing.Point(3, 223);
            this.dgDetilPenerimaanSubsidi.Name = "dgDetilPenerimaanSubsidi";
            this.dgDetilPenerimaanSubsidi.ReadOnly = true;
            this.dgDetilPenerimaanSubsidi.RowHeadersVisible = false;
            this.dgDetilPenerimaanSubsidi.Size = new System.Drawing.Size(848, 155);
            this.dgDetilPenerimaanSubsidi.StandardTab = true;
            this.dgDetilPenerimaanSubsidi.TabIndex = 6;
            this.dgDetilPenerimaanSubsidi.SelectionChanged += new System.EventHandler(this.dgDetilPenerimaanSubsidi_SelectionChanged);
            // 
            // PenerimaanUMRowIDDetail
            // 
            this.PenerimaanUMRowIDDetail.DataPropertyName = "PenerimaanUMRowID";
            this.PenerimaanUMRowIDDetail.HeaderText = "PenerimaanUMRowID";
            this.PenerimaanUMRowIDDetail.Name = "PenerimaanUMRowIDDetail";
            this.PenerimaanUMRowIDDetail.ReadOnly = true;
            this.PenerimaanUMRowIDDetail.Visible = false;
            // 
            // PenjRowIDDetail
            // 
            this.PenjRowIDDetail.DataPropertyName = "PenjRowID";
            this.PenjRowIDDetail.HeaderText = "PenjRowID";
            this.PenjRowIDDetail.Name = "PenjRowIDDetail";
            this.PenjRowIDDetail.ReadOnly = true;
            this.PenjRowIDDetail.Visible = false;
            // 
            // NoTransDetail
            // 
            this.NoTransDetail.DataPropertyName = "NoTrans";
            this.NoTransDetail.HeaderText = "No Trans";
            this.NoTransDetail.Name = "NoTransDetail";
            this.NoTransDetail.ReadOnly = true;
            this.NoTransDetail.Width = 125;
            // 
            // TanggalDetail
            // 
            this.TanggalDetail.DataPropertyName = "Tanggal";
            this.TanggalDetail.HeaderText = "Tanggal";
            this.TanggalDetail.Name = "TanggalDetail";
            this.TanggalDetail.ReadOnly = true;
            this.TanggalDetail.Width = 125;
            // 
            // NominalDetail
            // 
            this.NominalDetail.DataPropertyName = "Nominal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.NominalDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.NominalDetail.HeaderText = "Nominal";
            this.NominalDetail.Name = "NominalDetail";
            this.NominalDetail.ReadOnly = true;
            this.NominalDetail.Width = 150;
            // 
            // BentukPembayaranDetail
            // 
            this.BentukPembayaranDetail.DataPropertyName = "BentukPembayaran";
            this.BentukPembayaranDetail.HeaderText = "Bentuk Bayar";
            this.BentukPembayaranDetail.Name = "BentukPembayaranDetail";
            this.BentukPembayaranDetail.ReadOnly = true;
            this.BentukPembayaranDetail.Width = 150;
            // 
            // StatusBGCDetail
            // 
            this.StatusBGCDetail.DataPropertyName = "StatusBGC";
            this.StatusBGCDetail.HeaderText = "Status Giro";
            this.StatusBGCDetail.Name = "StatusBGCDetail";
            this.StatusBGCDetail.ReadOnly = true;
            this.StatusBGCDetail.Width = 150;
            // 
            // KeteranganDetail
            // 
            this.KeteranganDetail.DataPropertyName = "Uraian";
            this.KeteranganDetail.HeaderText = "Keterangan";
            this.KeteranganDetail.Name = "KeteranganDetail";
            this.KeteranganDetail.ReadOnly = true;
            this.KeteranganDetail.Width = 200;
            // 
            // PenerimaanUangRowIDDetail
            // 
            this.PenerimaanUangRowIDDetail.DataPropertyName = "PenerimaanUangRowID";
            this.PenerimaanUangRowIDDetail.HeaderText = "PenerimaanUangRowID";
            this.PenerimaanUangRowIDDetail.Name = "PenerimaanUangRowIDDetail";
            this.PenerimaanUangRowIDDetail.ReadOnly = true;
            this.PenerimaanUangRowIDDetail.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tanggal Penjualan";
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(402, 46);
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
            this.rdtTanggal.Location = new System.Drawing.Point(161, 47);
            this.rdtTanggal.Name = "rdtTanggal";
            this.rdtTanggal.Size = new System.Drawing.Size(257, 22);
            this.rdtTanggal.TabIndex = 53;
            this.rdtTanggal.ToDate = null;
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.Enabled = false;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = global::ISA.Showroom.Properties.Resources.payment;
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(31, 472);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(133, 40);
            this.cmdADD.TabIndex = 92;
            this.cmdADD.Text = "PELUNASAN";
            this.cmdADD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(780, 472);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 60;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgPenjualanBersubsidi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgDetilPenerimaanSubsidi, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.93208F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.06791F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 381);
            this.tableLayoutPanel1.TabIndex = 93;
            // 
            // frmUMSubsidiBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 524);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.rdtTanggal);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUMSubsidiBrowse";
            this.Text = "DP Subsidi Browse";
            this.Title = "DP Subsidi Browse";
            this.Load += new System.EventHandler(this.frmUangMukaSubsidiBrowse_Load);
            this.Controls.SetChildIndex(this.rdtTanggal, 0);
            this.Controls.SetChildIndex(this.btnCari, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgPenjualanBersubsidi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetilPenerimaanSubsidi)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgPenjualanBersubsidi;
        private ISA.Controls.CustomGridView dgDetilPenerimaanSubsidi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCari;
        private ISA.Controls.RangeDateBox rdtTanggal;
        private ISA.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Button cmdADD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenerimaanUMRowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjRowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn BentukPembayaranDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusBGCDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeteranganDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenerimaanUangRowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSurveyor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subsidi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubsidiTerbayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Via;
    }
}