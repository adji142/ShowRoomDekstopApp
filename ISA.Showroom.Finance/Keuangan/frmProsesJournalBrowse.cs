using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmProsesJournalBrowse : ISA.Controls.BaseForm
    {
        #region Variables declarations
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdProses;
        DateTime _minDate, _maxDate;
        private ISA.Controls.RangeDateBox rgtgTransaksi;
        private Label label1;
        private TabControl tabControl1;
        private TabPage Penerimaan;
        private TabPage Pengeluaran;
        private DataGridView dataGridView1;
        private DataTable dtPenerimaan, dtPengeluaran, dtMutasi, dtGiroMasuk, dtGiroKeluar, dtDKN, dtBS, dtBSDetail, dtPK, dtIdenLeasing, dtIdenNonNota;
        private TabPage Mutasi;
        private TabPage GiroMasuk;
        private TabPage GiroKeluar;
        private TabPage DNKN;
        private DataGridView dataGridView3;
        private DataGridView dataGridView4;
        private ISA.Controls.CommandButton cmdRefresh;
        private DataGridView dataGridView5;
        private DataGridView dataGridView6;
        private TabPage BS;
        private TabPage PiutangKaryawan;
        private DataGridView dataGridView7;
        private DataGridView dataGridView8;
        private ISA.Controls.CommandButton commandButton1;
        private TabPage BonSementara;
        private TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView dtKas1;
        private ISA.Controls.CustomGridView dtKas2;
        private ISA.Controls.CustomGridView dtKas3;
        private DataGridView dataGridView2;
        #endregion

        #region Form Preparation
        DataTable dtKas = new DataTable(), dtVJU = new DataTable(), dtPSL = new DataTable();
        private TabPage Identifikasi;
        private DataGridViewTextBoxColumn PTIRowID;
        private DataGridViewTextBoxColumn SrcRowIDIden;
        private DataGridViewTextBoxColumn SrcIDIden;
        private DataGridViewTextBoxColumn KodeTransIden;
        private DataGridViewTextBoxColumn NoBuktiPJLIden;
        private DataGridViewTextBoxColumn TglIden;
        private DataGridViewTextBoxColumn UraianIden;
        private DataGridViewTextBoxColumn NominalIden;
        private DataGridViewTextBoxColumn NominalPokokIden;
        private DataGridViewTextBoxColumn NominalBungaIden;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Button cmdPreview;
        private DataGridViewTextBoxColumn RowIDPenerimaan;
        private DataGridViewTextBoxColumn Penerimaan_NoBukti;
        private DataGridViewTextBoxColumn Penerimaan_Tanggal;
        private DataGridViewTextBoxColumn Penerimaan_NamaTransaksi;
        private DataGridViewTextBoxColumn Penerimaan_Nominal;
        private DataGridViewTextBoxColumn Penerimaan_Hasil;
        private DataGridViewTextBoxColumn RowIDPengeluaran;
        private DataGridViewTextBoxColumn Pengeluaran_NoBukti;
        private DataGridViewTextBoxColumn Pengeluaran_Tanggal;
        private DataGridViewTextBoxColumn Pengeluaran_CabangDari;
        private DataGridViewTextBoxColumn Pengeluaran_CabangKe;
        private DataGridViewTextBoxColumn Pengeluaran_Nominal;
        private DataGridViewTextBoxColumn Pengeluaran_Hasil;
        private DataGridViewTextBoxColumn RowIDMutasi;
        private DataGridViewTextBoxColumn Mutasi_NoBukti;
        private DataGridViewTextBoxColumn Mutasi_Tanggal;
        private DataGridViewTextBoxColumn Mutasi_NominalDari;
        private DataGridViewTextBoxColumn Mutasi_NominalKe;
        private DataGridViewTextBoxColumn Hasil;
        private DataGridViewTextBoxColumn RowIDGiroMasuk;
        private DataGridViewTextBoxColumn GiroMasuk_NoGiro;
        private DataGridViewTextBoxColumn GiroMasuk_NoBukti;
        private DataGridViewTextBoxColumn GiroMasuk_Tanggal;
        private DataGridViewTextBoxColumn GiroMasuk_StatusGiro;
        private DataGridViewTextBoxColumn GiroMasuk_Nominal;
        private DataGridViewTextBoxColumn GiroMasuk_Hasil;
        private DataGridViewTextBoxColumn RowIDDNKN;
        private DataGridViewTextBoxColumn DKN_NoBukti;
        private DataGridViewTextBoxColumn DKN_Tanggal;
        private DataGridViewTextBoxColumn DKN_CabangDari;
        private DataGridViewTextBoxColumn DKN_CabangKe;
        private DataGridViewTextBoxColumn DKN_Nominal;
        private DataGridViewTextBoxColumn DKN_NoRequest;
        private DataGridViewTextBoxColumn DKN_Hasil;
        private DataGridViewTextBoxColumn RowIDBS;
        private DataGridViewTextBoxColumn BS_NoBukti;
        private DataGridViewTextBoxColumn BS_Tanggal;
        private DataGridViewTextBoxColumn BS_Uraian;
        private DataGridViewTextBoxColumn BS_Nominal;
        private DataGridViewTextBoxColumn BS_Realisasi;
        private DataGridViewTextBoxColumn BS_Penyelesaian;
        private DataGridViewTextBoxColumn BS_Hasil;
        private DataGridViewTextBoxColumn RowIDPK;
        private DataGridViewTextBoxColumn PK_Transaksi;
        private DataGridViewTextBoxColumn PK_NoBukti;
        private DataGridViewTextBoxColumn PK_Tanggal;
        private DataGridViewTextBoxColumn PK_Nominal;
        private DataGridViewTextBoxColumn PK_Uraian;
        private DataGridViewTextBoxColumn PK_Hasil;
        private DataGridViewTextBoxColumn RowIDGiroKeluar;
        private DataGridViewTextBoxColumn RefIDGiroKeluar;
        private DataGridViewTextBoxColumn GiroKeluar_NoGiro;
        private DataGridViewTextBoxColumn GiroKeluar_NoBukti;
        private DataGridViewTextBoxColumn GiroKeluar_Tanggal;
        private DataGridViewTextBoxColumn GiroKeluar_StatusGiro;
        private DataGridViewTextBoxColumn GiroKeluar_Nominal;
        private DataGridViewTextBoxColumn GiroKeluar_Hasil;
        private TabPage IdenNonNota;
        private ISA.Controls.CustomGridView dataGridView9;
        private DataGridViewTextBoxColumn RowID_IdenNonNota;
        private DataGridViewTextBoxColumn IdenNonNota_Tanggal;
        private DataGridViewTextBoxColumn IdenNonNota_NoBukti;
        private DataGridViewTextBoxColumn IdenNonNota_Nominal;
        private DataGridViewTextBoxColumn IdenNonNota_Keterangan;
        private DataGridViewTextBoxColumn IdenNonNota_Hasil;
        private DataGridView dgvIdentifikasi;

        public frmProsesJournalBrowse()
        {
            InitializeComponent();
        }

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProsesJournalBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rgtgTransaksi = new ISA.Controls.RangeDateBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RowIDPenerimaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerimaan_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerimaan_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerimaan_NamaTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerimaan_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penerimaan_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Penerimaan = new System.Windows.Forms.TabPage();
            this.Pengeluaran = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.RowIDPengeluaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengeluaran_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengeluaran_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengeluaran_CabangDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengeluaran_CabangKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengeluaran_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pengeluaran_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mutasi = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.RowIDMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mutasi_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mutasi_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mutasi_NominalDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mutasi_NominalKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.RowIDGiroMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk_NoGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk_StatusGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroMasuk_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.RowIDGiroKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefIDGiroKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar_NoGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar_StatusGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiroKeluar_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identifikasi = new System.Windows.Forms.TabPage();
            this.dgvIdentifikasi = new System.Windows.Forms.DataGridView();
            this.PTIRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcRowIDIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcIDIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeTransIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBuktiPJLIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UraianIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalPokokIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalBungaIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNKN = new System.Windows.Forms.TabPage();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.RowIDDNKN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_CabangDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_CabangKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_NoRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DKN_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS = new System.Windows.Forms.TabPage();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.RowIDBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Realisasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Penyelesaian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiutangKaryawan = new System.Windows.Forms.TabPage();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.RowIDPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_Transaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PK_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonSementara = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtKas1 = new ISA.Controls.CustomGridView();
            this.dtKas2 = new ISA.Controls.CustomGridView();
            this.dtKas3 = new ISA.Controls.CustomGridView();
            this.IdenNonNota = new System.Windows.Forms.TabPage();
            this.dataGridView9 = new ISA.Controls.CustomGridView();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdProses = new ISA.Controls.CommandButton();
            this.cmdRefresh = new ISA.Controls.CommandButton();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.RowID_IdenNonNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdenNonNota_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdenNonNota_NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdenNonNota_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdenNonNota_Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdenNonNota_Hasil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Penerimaan.SuspendLayout();
            this.Pengeluaran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.Mutasi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.GiroMasuk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.GiroKeluar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.Identifikasi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentifikasi)).BeginInit();
            this.DNKN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.BS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.PiutangKaryawan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.BonSementara.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtKas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKas2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKas3)).BeginInit();
            this.IdenNonNota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            this.SuspendLayout();
            // 
            // rgtgTransaksi
            // 
            this.rgtgTransaksi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rgtgTransaksi.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgtgTransaksi.FromDate = null;
            this.rgtgTransaksi.Location = new System.Drawing.Point(339, 61);
            this.rgtgTransaksi.Name = "rgtgTransaksi";
            this.rgtgTransaksi.Size = new System.Drawing.Size(257, 22);
            this.rgtgTransaksi.TabIndex = 7;
            this.rgtgTransaksi.ToDate = null;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDPenerimaan,
            this.Penerimaan_NoBukti,
            this.Penerimaan_Tanggal,
            this.Penerimaan_NamaTransaksi,
            this.Penerimaan_Nominal,
            this.Penerimaan_Hasil});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(877, 235);
            this.dataGridView1.TabIndex = 8;
            // 
            // RowIDPenerimaan
            // 
            this.RowIDPenerimaan.DataPropertyName = "RowID";
            this.RowIDPenerimaan.HeaderText = "RowIDPenerimaan";
            this.RowIDPenerimaan.Name = "RowIDPenerimaan";
            this.RowIDPenerimaan.ReadOnly = true;
            this.RowIDPenerimaan.Visible = false;
            // 
            // Penerimaan_NoBukti
            // 
            this.Penerimaan_NoBukti.DataPropertyName = "NoBukti";
            this.Penerimaan_NoBukti.HeaderText = "No.Bukti";
            this.Penerimaan_NoBukti.Name = "Penerimaan_NoBukti";
            this.Penerimaan_NoBukti.ReadOnly = true;
            // 
            // Penerimaan_Tanggal
            // 
            this.Penerimaan_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Penerimaan_Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Penerimaan_Tanggal.HeaderText = "Tanggal";
            this.Penerimaan_Tanggal.Name = "Penerimaan_Tanggal";
            this.Penerimaan_Tanggal.ReadOnly = true;
            // 
            // Penerimaan_NamaTransaksi
            // 
            this.Penerimaan_NamaTransaksi.DataPropertyName = "NamaTransaksi";
            this.Penerimaan_NamaTransaksi.HeaderText = "Nama Transaksi";
            this.Penerimaan_NamaTransaksi.Name = "Penerimaan_NamaTransaksi";
            this.Penerimaan_NamaTransaksi.ReadOnly = true;
            this.Penerimaan_NamaTransaksi.Width = 200;
            // 
            // Penerimaan_Nominal
            // 
            this.Penerimaan_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Penerimaan_Nominal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Penerimaan_Nominal.HeaderText = "Nominal";
            this.Penerimaan_Nominal.Name = "Penerimaan_Nominal";
            this.Penerimaan_Nominal.ReadOnly = true;
            // 
            // Penerimaan_Hasil
            // 
            this.Penerimaan_Hasil.DataPropertyName = "Hasil";
            this.Penerimaan_Hasil.HeaderText = "Hasil Posting";
            this.Penerimaan_Hasil.Name = "Penerimaan_Hasil";
            this.Penerimaan_Hasil.ReadOnly = true;
            this.Penerimaan_Hasil.Width = 150;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tanggal";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Penerimaan);
            this.tabControl1.Controls.Add(this.Pengeluaran);
            this.tabControl1.Controls.Add(this.Mutasi);
            this.tabControl1.Controls.Add(this.GiroMasuk);
            this.tabControl1.Controls.Add(this.GiroKeluar);
            this.tabControl1.Controls.Add(this.Identifikasi);
            this.tabControl1.Controls.Add(this.DNKN);
            this.tabControl1.Controls.Add(this.BS);
            this.tabControl1.Controls.Add(this.PiutangKaryawan);
            this.tabControl1.Controls.Add(this.BonSementara);
            this.tabControl1.Controls.Add(this.IdenNonNota);
            this.tabControl1.Location = new System.Drawing.Point(12, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 268);
            this.tabControl1.TabIndex = 10;
            // 
            // Penerimaan
            // 
            this.Penerimaan.Controls.Add(this.dataGridView1);
            this.Penerimaan.Location = new System.Drawing.Point(4, 23);
            this.Penerimaan.Name = "Penerimaan";
            this.Penerimaan.Padding = new System.Windows.Forms.Padding(3);
            this.Penerimaan.Size = new System.Drawing.Size(883, 241);
            this.Penerimaan.TabIndex = 0;
            this.Penerimaan.Text = "Penerimaan";
            this.Penerimaan.UseVisualStyleBackColor = true;
            // 
            // Pengeluaran
            // 
            this.Pengeluaran.Controls.Add(this.dataGridView2);
            this.Pengeluaran.Location = new System.Drawing.Point(4, 23);
            this.Pengeluaran.Name = "Pengeluaran";
            this.Pengeluaran.Padding = new System.Windows.Forms.Padding(3);
            this.Pengeluaran.Size = new System.Drawing.Size(883, 241);
            this.Pengeluaran.TabIndex = 1;
            this.Pengeluaran.Text = "Pengeluaran";
            this.Pengeluaran.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDPengeluaran,
            this.Pengeluaran_NoBukti,
            this.Pengeluaran_Tanggal,
            this.Pengeluaran_CabangDari,
            this.Pengeluaran_CabangKe,
            this.Pengeluaran_Nominal,
            this.Pengeluaran_Hasil});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(877, 235);
            this.dataGridView2.TabIndex = 9;
            // 
            // RowIDPengeluaran
            // 
            this.RowIDPengeluaran.DataPropertyName = "RowID";
            this.RowIDPengeluaran.HeaderText = "RowIDPengeluaran";
            this.RowIDPengeluaran.Name = "RowIDPengeluaran";
            this.RowIDPengeluaran.ReadOnly = true;
            this.RowIDPengeluaran.Visible = false;
            // 
            // Pengeluaran_NoBukti
            // 
            this.Pengeluaran_NoBukti.DataPropertyName = "NoBukti";
            this.Pengeluaran_NoBukti.HeaderText = "NoBukti";
            this.Pengeluaran_NoBukti.Name = "Pengeluaran_NoBukti";
            this.Pengeluaran_NoBukti.ReadOnly = true;
            this.Pengeluaran_NoBukti.Width = 120;
            // 
            // Pengeluaran_Tanggal
            // 
            this.Pengeluaran_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.Pengeluaran_Tanggal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Pengeluaran_Tanggal.HeaderText = "Tanggal";
            this.Pengeluaran_Tanggal.Name = "Pengeluaran_Tanggal";
            this.Pengeluaran_Tanggal.ReadOnly = true;
            // 
            // Pengeluaran_CabangDari
            // 
            this.Pengeluaran_CabangDari.DataPropertyName = "CabangDariID";
            this.Pengeluaran_CabangDari.HeaderText = "Cabang Dari";
            this.Pengeluaran_CabangDari.Name = "Pengeluaran_CabangDari";
            this.Pengeluaran_CabangDari.ReadOnly = true;
            // 
            // Pengeluaran_CabangKe
            // 
            this.Pengeluaran_CabangKe.DataPropertyName = "CabangKeID";
            this.Pengeluaran_CabangKe.HeaderText = "Cabang Ke";
            this.Pengeluaran_CabangKe.Name = "Pengeluaran_CabangKe";
            this.Pengeluaran_CabangKe.ReadOnly = true;
            // 
            // Pengeluaran_Nominal
            // 
            this.Pengeluaran_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Pengeluaran_Nominal.DefaultCellStyle = dataGridViewCellStyle4;
            this.Pengeluaran_Nominal.HeaderText = "Nominal";
            this.Pengeluaran_Nominal.Name = "Pengeluaran_Nominal";
            this.Pengeluaran_Nominal.ReadOnly = true;
            // 
            // Pengeluaran_Hasil
            // 
            this.Pengeluaran_Hasil.DataPropertyName = "Hasil";
            this.Pengeluaran_Hasil.HeaderText = "Hasil Posting";
            this.Pengeluaran_Hasil.Name = "Pengeluaran_Hasil";
            this.Pengeluaran_Hasil.ReadOnly = true;
            this.Pengeluaran_Hasil.Width = 150;
            // 
            // Mutasi
            // 
            this.Mutasi.Controls.Add(this.dataGridView3);
            this.Mutasi.Location = new System.Drawing.Point(4, 23);
            this.Mutasi.Name = "Mutasi";
            this.Mutasi.Padding = new System.Windows.Forms.Padding(3);
            this.Mutasi.Size = new System.Drawing.Size(883, 241);
            this.Mutasi.TabIndex = 2;
            this.Mutasi.Text = "Mutasi";
            this.Mutasi.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDMutasi,
            this.Mutasi_NoBukti,
            this.Mutasi_Tanggal,
            this.Mutasi_NominalDari,
            this.Mutasi_NominalKe,
            this.Hasil});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(877, 235);
            this.dataGridView3.TabIndex = 9;
            // 
            // RowIDMutasi
            // 
            this.RowIDMutasi.DataPropertyName = "RowID";
            this.RowIDMutasi.HeaderText = "RowIDMutasi";
            this.RowIDMutasi.Name = "RowIDMutasi";
            this.RowIDMutasi.ReadOnly = true;
            this.RowIDMutasi.Visible = false;
            // 
            // Mutasi_NoBukti
            // 
            this.Mutasi_NoBukti.DataPropertyName = "NoBukti";
            this.Mutasi_NoBukti.HeaderText = "No. Bukti";
            this.Mutasi_NoBukti.Name = "Mutasi_NoBukti";
            this.Mutasi_NoBukti.ReadOnly = true;
            // 
            // Mutasi_Tanggal
            // 
            this.Mutasi_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            dataGridViewCellStyle5.NullValue = null;
            this.Mutasi_Tanggal.DefaultCellStyle = dataGridViewCellStyle5;
            this.Mutasi_Tanggal.HeaderText = "Tanggal";
            this.Mutasi_Tanggal.Name = "Mutasi_Tanggal";
            this.Mutasi_Tanggal.ReadOnly = true;
            // 
            // Mutasi_NominalDari
            // 
            this.Mutasi_NominalDari.DataPropertyName = "NominalDari";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Mutasi_NominalDari.DefaultCellStyle = dataGridViewCellStyle6;
            this.Mutasi_NominalDari.HeaderText = "Nominal (Dari)";
            this.Mutasi_NominalDari.Name = "Mutasi_NominalDari";
            this.Mutasi_NominalDari.ReadOnly = true;
            this.Mutasi_NominalDari.Width = 120;
            // 
            // Mutasi_NominalKe
            // 
            this.Mutasi_NominalKe.DataPropertyName = "NominalKe";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Mutasi_NominalKe.DefaultCellStyle = dataGridViewCellStyle7;
            this.Mutasi_NominalKe.HeaderText = "Nominal (Ke)";
            this.Mutasi_NominalKe.Name = "Mutasi_NominalKe";
            this.Mutasi_NominalKe.ReadOnly = true;
            this.Mutasi_NominalKe.Width = 120;
            // 
            // Hasil
            // 
            this.Hasil.DataPropertyName = "Hasil";
            this.Hasil.HeaderText = "Hasil Posting";
            this.Hasil.Name = "Hasil";
            this.Hasil.ReadOnly = true;
            this.Hasil.Width = 150;
            // 
            // GiroMasuk
            // 
            this.GiroMasuk.Controls.Add(this.dataGridView4);
            this.GiroMasuk.Location = new System.Drawing.Point(4, 23);
            this.GiroMasuk.Name = "GiroMasuk";
            this.GiroMasuk.Size = new System.Drawing.Size(883, 241);
            this.GiroMasuk.TabIndex = 3;
            this.GiroMasuk.Text = "Giro Masuk";
            this.GiroMasuk.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDGiroMasuk,
            this.GiroMasuk_NoGiro,
            this.GiroMasuk_NoBukti,
            this.GiroMasuk_Tanggal,
            this.GiroMasuk_StatusGiro,
            this.GiroMasuk_Nominal,
            this.GiroMasuk_Hasil});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(883, 241);
            this.dataGridView4.TabIndex = 9;
            // 
            // RowIDGiroMasuk
            // 
            this.RowIDGiroMasuk.DataPropertyName = "RowID";
            this.RowIDGiroMasuk.HeaderText = "RowIDGiroMasuk";
            this.RowIDGiroMasuk.Name = "RowIDGiroMasuk";
            this.RowIDGiroMasuk.ReadOnly = true;
            this.RowIDGiroMasuk.Visible = false;
            // 
            // GiroMasuk_NoGiro
            // 
            this.GiroMasuk_NoGiro.DataPropertyName = "NoGiro";
            this.GiroMasuk_NoGiro.HeaderText = "NoGiro";
            this.GiroMasuk_NoGiro.Name = "GiroMasuk_NoGiro";
            this.GiroMasuk_NoGiro.ReadOnly = true;
            // 
            // GiroMasuk_NoBukti
            // 
            this.GiroMasuk_NoBukti.DataPropertyName = "NoBukti";
            this.GiroMasuk_NoBukti.HeaderText = "No.BGM";
            this.GiroMasuk_NoBukti.Name = "GiroMasuk_NoBukti";
            this.GiroMasuk_NoBukti.ReadOnly = true;
            // 
            // GiroMasuk_Tanggal
            // 
            this.GiroMasuk_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            dataGridViewCellStyle8.NullValue = null;
            this.GiroMasuk_Tanggal.DefaultCellStyle = dataGridViewCellStyle8;
            this.GiroMasuk_Tanggal.HeaderText = "Tgl.Status";
            this.GiroMasuk_Tanggal.Name = "GiroMasuk_Tanggal";
            this.GiroMasuk_Tanggal.ReadOnly = true;
            // 
            // GiroMasuk_StatusGiro
            // 
            this.GiroMasuk_StatusGiro.DataPropertyName = "DescStatusGiro";
            this.GiroMasuk_StatusGiro.HeaderText = "Status";
            this.GiroMasuk_StatusGiro.Name = "GiroMasuk_StatusGiro";
            this.GiroMasuk_StatusGiro.ReadOnly = true;
            // 
            // GiroMasuk_Nominal
            // 
            this.GiroMasuk_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.GiroMasuk_Nominal.DefaultCellStyle = dataGridViewCellStyle9;
            this.GiroMasuk_Nominal.HeaderText = "Nominal";
            this.GiroMasuk_Nominal.Name = "GiroMasuk_Nominal";
            this.GiroMasuk_Nominal.ReadOnly = true;
            // 
            // GiroMasuk_Hasil
            // 
            this.GiroMasuk_Hasil.DataPropertyName = "Hasil";
            this.GiroMasuk_Hasil.HeaderText = "Hasil Posting";
            this.GiroMasuk_Hasil.Name = "GiroMasuk_Hasil";
            this.GiroMasuk_Hasil.ReadOnly = true;
            this.GiroMasuk_Hasil.Width = 150;
            // 
            // GiroKeluar
            // 
            this.GiroKeluar.Controls.Add(this.dataGridView5);
            this.GiroKeluar.Location = new System.Drawing.Point(4, 23);
            this.GiroKeluar.Name = "GiroKeluar";
            this.GiroKeluar.Size = new System.Drawing.Size(883, 241);
            this.GiroKeluar.TabIndex = 4;
            this.GiroKeluar.Text = "Giro Keluar";
            this.GiroKeluar.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AllowUserToResizeRows = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDGiroKeluar,
            this.RefIDGiroKeluar,
            this.GiroKeluar_NoGiro,
            this.GiroKeluar_NoBukti,
            this.GiroKeluar_Tanggal,
            this.GiroKeluar_StatusGiro,
            this.GiroKeluar_Nominal,
            this.GiroKeluar_Hasil});
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(0, 0);
            this.dataGridView5.MultiSelect = false;
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(883, 241);
            this.dataGridView5.TabIndex = 10;
            // 
            // RowIDGiroKeluar
            // 
            this.RowIDGiroKeluar.DataPropertyName = "RowID";
            this.RowIDGiroKeluar.HeaderText = "RowIDGiroKeluar";
            this.RowIDGiroKeluar.Name = "RowIDGiroKeluar";
            this.RowIDGiroKeluar.ReadOnly = true;
            this.RowIDGiroKeluar.Visible = false;
            // 
            // RefIDGiroKeluar
            // 
            this.RefIDGiroKeluar.DataPropertyName = "RefID";
            this.RefIDGiroKeluar.HeaderText = "RefIDGiroKeluar";
            this.RefIDGiroKeluar.Name = "RefIDGiroKeluar";
            this.RefIDGiroKeluar.ReadOnly = true;
            this.RefIDGiroKeluar.Visible = false;
            // 
            // GiroKeluar_NoGiro
            // 
            this.GiroKeluar_NoGiro.DataPropertyName = "NoGiro";
            this.GiroKeluar_NoGiro.HeaderText = "No. Giro";
            this.GiroKeluar_NoGiro.Name = "GiroKeluar_NoGiro";
            this.GiroKeluar_NoGiro.ReadOnly = true;
            // 
            // GiroKeluar_NoBukti
            // 
            this.GiroKeluar_NoBukti.DataPropertyName = "NoBukti";
            this.GiroKeluar_NoBukti.HeaderText = "No.BGK";
            this.GiroKeluar_NoBukti.Name = "GiroKeluar_NoBukti";
            this.GiroKeluar_NoBukti.ReadOnly = true;
            // 
            // GiroKeluar_Tanggal
            // 
            this.GiroKeluar_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            this.GiroKeluar_Tanggal.DefaultCellStyle = dataGridViewCellStyle10;
            this.GiroKeluar_Tanggal.HeaderText = "Tgl.Status";
            this.GiroKeluar_Tanggal.Name = "GiroKeluar_Tanggal";
            this.GiroKeluar_Tanggal.ReadOnly = true;
            // 
            // GiroKeluar_StatusGiro
            // 
            this.GiroKeluar_StatusGiro.DataPropertyName = "DescStatusGiro";
            this.GiroKeluar_StatusGiro.HeaderText = "Status";
            this.GiroKeluar_StatusGiro.Name = "GiroKeluar_StatusGiro";
            this.GiroKeluar_StatusGiro.ReadOnly = true;
            // 
            // GiroKeluar_Nominal
            // 
            this.GiroKeluar_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.GiroKeluar_Nominal.DefaultCellStyle = dataGridViewCellStyle11;
            this.GiroKeluar_Nominal.HeaderText = "Nominal";
            this.GiroKeluar_Nominal.Name = "GiroKeluar_Nominal";
            this.GiroKeluar_Nominal.ReadOnly = true;
            // 
            // GiroKeluar_Hasil
            // 
            this.GiroKeluar_Hasil.DataPropertyName = "Hasil";
            this.GiroKeluar_Hasil.HeaderText = "Hasil Posting";
            this.GiroKeluar_Hasil.Name = "GiroKeluar_Hasil";
            this.GiroKeluar_Hasil.ReadOnly = true;
            this.GiroKeluar_Hasil.Width = 150;
            // 
            // Identifikasi
            // 
            this.Identifikasi.Controls.Add(this.dgvIdentifikasi);
            this.Identifikasi.Location = new System.Drawing.Point(4, 23);
            this.Identifikasi.Name = "Identifikasi";
            this.Identifikasi.Size = new System.Drawing.Size(883, 241);
            this.Identifikasi.TabIndex = 9;
            this.Identifikasi.Text = "Identifikasi";
            this.Identifikasi.UseVisualStyleBackColor = true;
            // 
            // dgvIdentifikasi
            // 
            this.dgvIdentifikasi.AllowUserToAddRows = false;
            this.dgvIdentifikasi.AllowUserToDeleteRows = false;
            this.dgvIdentifikasi.AllowUserToResizeRows = false;
            this.dgvIdentifikasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdentifikasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PTIRowID,
            this.SrcRowIDIden,
            this.SrcIDIden,
            this.KodeTransIden,
            this.NoBuktiPJLIden,
            this.TglIden,
            this.UraianIden,
            this.NominalIden,
            this.NominalPokokIden,
            this.NominalBungaIden,
            this.dataGridViewTextBoxColumn5});
            this.dgvIdentifikasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIdentifikasi.Location = new System.Drawing.Point(0, 0);
            this.dgvIdentifikasi.MultiSelect = false;
            this.dgvIdentifikasi.Name = "dgvIdentifikasi";
            this.dgvIdentifikasi.ReadOnly = true;
            this.dgvIdentifikasi.RowHeadersVisible = false;
            this.dgvIdentifikasi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdentifikasi.Size = new System.Drawing.Size(883, 241);
            this.dgvIdentifikasi.TabIndex = 9;
            // 
            // PTIRowID
            // 
            this.PTIRowID.DataPropertyName = "PTIRowID";
            this.PTIRowID.HeaderText = "PTIRowID";
            this.PTIRowID.Name = "PTIRowID";
            this.PTIRowID.ReadOnly = true;
            this.PTIRowID.Visible = false;
            // 
            // SrcRowIDIden
            // 
            this.SrcRowIDIden.DataPropertyName = "SrcRowID";
            this.SrcRowIDIden.HeaderText = "SrcRowIDIden";
            this.SrcRowIDIden.Name = "SrcRowIDIden";
            this.SrcRowIDIden.ReadOnly = true;
            this.SrcRowIDIden.Visible = false;
            // 
            // SrcIDIden
            // 
            this.SrcIDIden.DataPropertyName = "SrcID";
            this.SrcIDIden.HeaderText = "Src Iden";
            this.SrcIDIden.Name = "SrcIDIden";
            this.SrcIDIden.ReadOnly = true;
            // 
            // KodeTransIden
            // 
            this.KodeTransIden.DataPropertyName = "KodeTrans";
            this.KodeTransIden.HeaderText = "KodeTrans";
            this.KodeTransIden.Name = "KodeTransIden";
            this.KodeTransIden.ReadOnly = true;
            // 
            // NoBuktiPJLIden
            // 
            this.NoBuktiPJLIden.DataPropertyName = "NoBuktiPJL";
            this.NoBuktiPJLIden.HeaderText = "No.Bukti";
            this.NoBuktiPJLIden.Name = "NoBuktiPJLIden";
            this.NoBuktiPJLIden.ReadOnly = true;
            // 
            // TglIden
            // 
            this.TglIden.DataPropertyName = "TglIden";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "dd/MM/yyyy";
            this.TglIden.DefaultCellStyle = dataGridViewCellStyle12;
            this.TglIden.HeaderText = "Tanggal";
            this.TglIden.Name = "TglIden";
            this.TglIden.ReadOnly = true;
            // 
            // UraianIden
            // 
            this.UraianIden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UraianIden.DataPropertyName = "Uraian";
            this.UraianIden.HeaderText = "Uraian";
            this.UraianIden.MinimumWidth = 250;
            this.UraianIden.Name = "UraianIden";
            this.UraianIden.ReadOnly = true;
            // 
            // NominalIden
            // 
            this.NominalIden.DataPropertyName = "Nominal";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.NominalIden.DefaultCellStyle = dataGridViewCellStyle13;
            this.NominalIden.HeaderText = "Nominal Iden";
            this.NominalIden.Name = "NominalIden";
            this.NominalIden.ReadOnly = true;
            // 
            // NominalPokokIden
            // 
            this.NominalPokokIden.DataPropertyName = "NominalPokok";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.NominalPokokIden.DefaultCellStyle = dataGridViewCellStyle14;
            this.NominalPokokIden.HeaderText = "Nominal Pokok";
            this.NominalPokokIden.Name = "NominalPokokIden";
            this.NominalPokokIden.ReadOnly = true;
            // 
            // NominalBungaIden
            // 
            this.NominalBungaIden.DataPropertyName = "NominalBunga";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.NominalBungaIden.DefaultCellStyle = dataGridViewCellStyle15;
            this.NominalBungaIden.HeaderText = "NomimalBunga";
            this.NominalBungaIden.Name = "NominalBungaIden";
            this.NominalBungaIden.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Hasil";
            this.dataGridViewTextBoxColumn5.HeaderText = "Hasil Posting";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // DNKN
            // 
            this.DNKN.Controls.Add(this.dataGridView6);
            this.DNKN.Location = new System.Drawing.Point(4, 23);
            this.DNKN.Name = "DNKN";
            this.DNKN.Size = new System.Drawing.Size(883, 241);
            this.DNKN.TabIndex = 5;
            this.DNKN.Text = "DN / KN";
            this.DNKN.UseVisualStyleBackColor = true;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.AllowUserToResizeRows = false;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDDNKN,
            this.DKN_NoBukti,
            this.DKN_Tanggal,
            this.DKN_CabangDari,
            this.DKN_CabangKe,
            this.DKN_Nominal,
            this.DKN_NoRequest,
            this.DKN_Hasil});
            this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView6.Location = new System.Drawing.Point(0, 0);
            this.dataGridView6.MultiSelect = false;
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.RowHeadersVisible = false;
            this.dataGridView6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView6.Size = new System.Drawing.Size(883, 241);
            this.dataGridView6.TabIndex = 11;
            // 
            // RowIDDNKN
            // 
            this.RowIDDNKN.DataPropertyName = "RowID";
            this.RowIDDNKN.HeaderText = "RowIDDNKN";
            this.RowIDDNKN.Name = "RowIDDNKN";
            this.RowIDDNKN.ReadOnly = true;
            this.RowIDDNKN.Visible = false;
            // 
            // DKN_NoBukti
            // 
            this.DKN_NoBukti.DataPropertyName = "NoBukti";
            this.DKN_NoBukti.HeaderText = "No.Bukti";
            this.DKN_NoBukti.Name = "DKN_NoBukti";
            this.DKN_NoBukti.ReadOnly = true;
            // 
            // DKN_Tanggal
            // 
            this.DKN_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "dd/MM/yyyy";
            this.DKN_Tanggal.DefaultCellStyle = dataGridViewCellStyle16;
            this.DKN_Tanggal.HeaderText = "Tanggal";
            this.DKN_Tanggal.Name = "DKN_Tanggal";
            this.DKN_Tanggal.ReadOnly = true;
            // 
            // DKN_CabangDari
            // 
            this.DKN_CabangDari.DataPropertyName = "CabangDariID";
            this.DKN_CabangDari.HeaderText = "Dari Cabang";
            this.DKN_CabangDari.Name = "DKN_CabangDari";
            this.DKN_CabangDari.ReadOnly = true;
            // 
            // DKN_CabangKe
            // 
            this.DKN_CabangKe.DataPropertyName = "CabangKeID";
            this.DKN_CabangKe.HeaderText = "Ke Cabang";
            this.DKN_CabangKe.Name = "DKN_CabangKe";
            this.DKN_CabangKe.ReadOnly = true;
            // 
            // DKN_Nominal
            // 
            this.DKN_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.DKN_Nominal.DefaultCellStyle = dataGridViewCellStyle17;
            this.DKN_Nominal.HeaderText = "Nominal";
            this.DKN_Nominal.Name = "DKN_Nominal";
            this.DKN_Nominal.ReadOnly = true;
            // 
            // DKN_NoRequest
            // 
            this.DKN_NoRequest.DataPropertyName = "NoRequest";
            this.DKN_NoRequest.HeaderText = "No.DKN 00";
            this.DKN_NoRequest.Name = "DKN_NoRequest";
            this.DKN_NoRequest.ReadOnly = true;
            // 
            // DKN_Hasil
            // 
            this.DKN_Hasil.DataPropertyName = "Hasil";
            this.DKN_Hasil.HeaderText = "Hasil Posting";
            this.DKN_Hasil.Name = "DKN_Hasil";
            this.DKN_Hasil.ReadOnly = true;
            this.DKN_Hasil.Width = 150;
            // 
            // BS
            // 
            this.BS.Controls.Add(this.dataGridView7);
            this.BS.Location = new System.Drawing.Point(4, 23);
            this.BS.Name = "BS";
            this.BS.Padding = new System.Windows.Forms.Padding(3);
            this.BS.Size = new System.Drawing.Size(883, 241);
            this.BS.TabIndex = 6;
            this.BS.Text = "BS";
            this.BS.UseVisualStyleBackColor = true;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AllowUserToDeleteRows = false;
            this.dataGridView7.AllowUserToResizeRows = false;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDBS,
            this.BS_NoBukti,
            this.BS_Tanggal,
            this.BS_Uraian,
            this.BS_Nominal,
            this.BS_Realisasi,
            this.BS_Penyelesaian,
            this.BS_Hasil});
            this.dataGridView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView7.Location = new System.Drawing.Point(3, 3);
            this.dataGridView7.MultiSelect = false;
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.ReadOnly = true;
            this.dataGridView7.RowHeadersVisible = false;
            this.dataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView7.Size = new System.Drawing.Size(877, 235);
            this.dataGridView7.TabIndex = 12;
            // 
            // RowIDBS
            // 
            this.RowIDBS.DataPropertyName = "RowID";
            this.RowIDBS.HeaderText = "RowIDBS";
            this.RowIDBS.Name = "RowIDBS";
            this.RowIDBS.ReadOnly = true;
            this.RowIDBS.Visible = false;
            // 
            // BS_NoBukti
            // 
            this.BS_NoBukti.DataPropertyName = "NoBukti";
            this.BS_NoBukti.HeaderText = "No.Bukti";
            this.BS_NoBukti.Name = "BS_NoBukti";
            this.BS_NoBukti.ReadOnly = true;
            // 
            // BS_Tanggal
            // 
            this.BS_Tanggal.DataPropertyName = "Tanggal";
            this.BS_Tanggal.HeaderText = "Tgl.BS";
            this.BS_Tanggal.Name = "BS_Tanggal";
            this.BS_Tanggal.ReadOnly = true;
            // 
            // BS_Uraian
            // 
            this.BS_Uraian.DataPropertyName = "Uraian";
            this.BS_Uraian.HeaderText = "Uraian";
            this.BS_Uraian.Name = "BS_Uraian";
            this.BS_Uraian.ReadOnly = true;
            this.BS_Uraian.Width = 200;
            // 
            // BS_Nominal
            // 
            this.BS_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            this.BS_Nominal.DefaultCellStyle = dataGridViewCellStyle18;
            this.BS_Nominal.HeaderText = "BS";
            this.BS_Nominal.Name = "BS_Nominal";
            this.BS_Nominal.ReadOnly = true;
            // 
            // BS_Realisasi
            // 
            this.BS_Realisasi.DataPropertyName = "Realisasi";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            this.BS_Realisasi.DefaultCellStyle = dataGridViewCellStyle19;
            this.BS_Realisasi.HeaderText = "Realisasi";
            this.BS_Realisasi.Name = "BS_Realisasi";
            this.BS_Realisasi.ReadOnly = true;
            // 
            // BS_Penyelesaian
            // 
            this.BS_Penyelesaian.DataPropertyName = "Penyelesaian";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N2";
            this.BS_Penyelesaian.DefaultCellStyle = dataGridViewCellStyle20;
            this.BS_Penyelesaian.HeaderText = "Penyelesaian";
            this.BS_Penyelesaian.Name = "BS_Penyelesaian";
            this.BS_Penyelesaian.ReadOnly = true;
            // 
            // BS_Hasil
            // 
            this.BS_Hasil.DataPropertyName = "Hasil";
            this.BS_Hasil.HeaderText = "Hasil Posting";
            this.BS_Hasil.Name = "BS_Hasil";
            this.BS_Hasil.ReadOnly = true;
            this.BS_Hasil.Width = 250;
            // 
            // PiutangKaryawan
            // 
            this.PiutangKaryawan.Controls.Add(this.dataGridView8);
            this.PiutangKaryawan.Location = new System.Drawing.Point(4, 23);
            this.PiutangKaryawan.Name = "PiutangKaryawan";
            this.PiutangKaryawan.Padding = new System.Windows.Forms.Padding(3);
            this.PiutangKaryawan.Size = new System.Drawing.Size(883, 241);
            this.PiutangKaryawan.TabIndex = 7;
            this.PiutangKaryawan.Text = "Piutang Karyawan";
            this.PiutangKaryawan.UseVisualStyleBackColor = true;
            // 
            // dataGridView8
            // 
            this.dataGridView8.AllowUserToAddRows = false;
            this.dataGridView8.AllowUserToDeleteRows = false;
            this.dataGridView8.AllowUserToResizeRows = false;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDPK,
            this.PK_Transaksi,
            this.PK_NoBukti,
            this.PK_Tanggal,
            this.PK_Nominal,
            this.PK_Uraian,
            this.PK_Hasil});
            this.dataGridView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView8.Location = new System.Drawing.Point(3, 3);
            this.dataGridView8.MultiSelect = false;
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.ReadOnly = true;
            this.dataGridView8.RowHeadersVisible = false;
            this.dataGridView8.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView8.Size = new System.Drawing.Size(877, 235);
            this.dataGridView8.TabIndex = 12;
            // 
            // RowIDPK
            // 
            this.RowIDPK.DataPropertyName = "RowID";
            this.RowIDPK.HeaderText = "RowIDPK";
            this.RowIDPK.Name = "RowIDPK";
            this.RowIDPK.ReadOnly = true;
            this.RowIDPK.Visible = false;
            // 
            // PK_Transaksi
            // 
            this.PK_Transaksi.DataPropertyName = "Transaksi";
            this.PK_Transaksi.HeaderText = "Transaksi";
            this.PK_Transaksi.Name = "PK_Transaksi";
            this.PK_Transaksi.ReadOnly = true;
            // 
            // PK_NoBukti
            // 
            this.PK_NoBukti.DataPropertyName = "NoBukti";
            this.PK_NoBukti.HeaderText = "NoBukti";
            this.PK_NoBukti.Name = "PK_NoBukti";
            this.PK_NoBukti.ReadOnly = true;
            // 
            // PK_Tanggal
            // 
            this.PK_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Format = "dd/MM/yyyy";
            this.PK_Tanggal.DefaultCellStyle = dataGridViewCellStyle21;
            this.PK_Tanggal.HeaderText = "Tgl.Pinjam";
            this.PK_Tanggal.Name = "PK_Tanggal";
            this.PK_Tanggal.ReadOnly = true;
            // 
            // PK_Nominal
            // 
            this.PK_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            this.PK_Nominal.DefaultCellStyle = dataGridViewCellStyle22;
            this.PK_Nominal.HeaderText = "Nominal";
            this.PK_Nominal.Name = "PK_Nominal";
            this.PK_Nominal.ReadOnly = true;
            // 
            // PK_Uraian
            // 
            this.PK_Uraian.DataPropertyName = "Uraian";
            this.PK_Uraian.HeaderText = "Uraian";
            this.PK_Uraian.Name = "PK_Uraian";
            this.PK_Uraian.ReadOnly = true;
            // 
            // PK_Hasil
            // 
            this.PK_Hasil.DataPropertyName = "Hasil";
            this.PK_Hasil.HeaderText = "Hasil Posting";
            this.PK_Hasil.Name = "PK_Hasil";
            this.PK_Hasil.ReadOnly = true;
            this.PK_Hasil.Width = 250;
            // 
            // BonSementara
            // 
            this.BonSementara.Controls.Add(this.tableLayoutPanel1);
            this.BonSementara.Location = new System.Drawing.Point(4, 23);
            this.BonSementara.Name = "BonSementara";
            this.BonSementara.Padding = new System.Windows.Forms.Padding(3);
            this.BonSementara.Size = new System.Drawing.Size(883, 241);
            this.BonSementara.TabIndex = 8;
            this.BonSementara.Text = "Bon Sementara";
            this.BonSementara.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dtKas1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtKas2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtKas3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtKas1
            // 
            this.dtKas1.AllowUserToAddRows = false;
            this.dtKas1.AllowUserToDeleteRows = false;
            this.dtKas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtKas1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtKas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtKas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtKas1.Location = new System.Drawing.Point(3, 3);
            this.dtKas1.MultiSelect = false;
            this.dtKas1.Name = "dtKas1";
            this.dtKas1.ReadOnly = true;
            this.dtKas1.RowHeadersVisible = false;
            this.dtKas1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtKas1.Size = new System.Drawing.Size(871, 72);
            this.dtKas1.StandardTab = true;
            this.dtKas1.TabIndex = 0;
            // 
            // dtKas2
            // 
            this.dtKas2.AllowUserToAddRows = false;
            this.dtKas2.AllowUserToDeleteRows = false;
            this.dtKas2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtKas2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtKas2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtKas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtKas2.Location = new System.Drawing.Point(3, 81);
            this.dtKas2.MultiSelect = false;
            this.dtKas2.Name = "dtKas2";
            this.dtKas2.ReadOnly = true;
            this.dtKas2.RowHeadersVisible = false;
            this.dtKas2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtKas2.Size = new System.Drawing.Size(871, 72);
            this.dtKas2.StandardTab = true;
            this.dtKas2.TabIndex = 1;
            // 
            // dtKas3
            // 
            this.dtKas3.AllowUserToAddRows = false;
            this.dtKas3.AllowUserToDeleteRows = false;
            this.dtKas3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtKas3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtKas3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtKas3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtKas3.Location = new System.Drawing.Point(3, 159);
            this.dtKas3.MultiSelect = false;
            this.dtKas3.Name = "dtKas3";
            this.dtKas3.ReadOnly = true;
            this.dtKas3.RowHeadersVisible = false;
            this.dtKas3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtKas3.Size = new System.Drawing.Size(871, 73);
            this.dtKas3.StandardTab = true;
            this.dtKas3.TabIndex = 2;
            // 
            // IdenNonNota
            // 
            this.IdenNonNota.Controls.Add(this.dataGridView9);
            this.IdenNonNota.Location = new System.Drawing.Point(4, 23);
            this.IdenNonNota.Name = "IdenNonNota";
            this.IdenNonNota.Size = new System.Drawing.Size(883, 241);
            this.IdenNonNota.TabIndex = 10;
            this.IdenNonNota.Text = "IdenNonNota";
            this.IdenNonNota.UseVisualStyleBackColor = true;
            // 
            // dataGridView9
            // 
            this.dataGridView9.AllowUserToAddRows = false;
            this.dataGridView9.AllowUserToDeleteRows = false;
            this.dataGridView9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView9.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID_IdenNonNota,
            this.IdenNonNota_Tanggal,
            this.IdenNonNota_NoBukti,
            this.IdenNonNota_Nominal,
            this.IdenNonNota_Keterangan,
            this.IdenNonNota_Hasil});
            this.dataGridView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView9.Location = new System.Drawing.Point(0, 0);
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.ReadOnly = true;
            this.dataGridView9.RowHeadersVisible = false;
            this.dataGridView9.Size = new System.Drawing.Size(883, 241);
            this.dataGridView9.StandardTab = true;
            this.dataGridView9.TabIndex = 0;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(527, 359);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 13;
            this.commandButton1.Text = "Closing Kasir";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(799, 359);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdProses
            // 
            this.cmdProses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdProses.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(12, 359);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 5;
            this.cmdProses.Text = "YES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdRefresh.CommandType = ISA.Controls.CommandButton.enCommandType.Refresh;
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(272, 359);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(100, 40);
            this.cmdRefresh.TabIndex = 12;
            this.cmdRefresh.Text = "REFRESH";
            this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPreview.Image = global::ISA.Showroom.Finance.Properties.Resources.Search32;
            this.cmdPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPreview.Location = new System.Drawing.Point(135, 359);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(91, 40);
            this.cmdPreview.TabIndex = 14;
            this.cmdPreview.Text = "PREVIEW";
            this.cmdPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // RowID_IdenNonNota
            // 
            this.RowID_IdenNonNota.DataPropertyName = "RowID";
            this.RowID_IdenNonNota.HeaderText = "RowID";
            this.RowID_IdenNonNota.Name = "RowID_IdenNonNota";
            this.RowID_IdenNonNota.ReadOnly = true;
            this.RowID_IdenNonNota.Visible = false;
            this.RowID_IdenNonNota.Width = 47;
            // 
            // IdenNonNota_Tanggal
            // 
            this.IdenNonNota_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle23.Format = "dd/MM/yyyy";
            this.IdenNonNota_Tanggal.DefaultCellStyle = dataGridViewCellStyle23;
            this.IdenNonNota_Tanggal.HeaderText = "Tanggal";
            this.IdenNonNota_Tanggal.Name = "IdenNonNota_Tanggal";
            this.IdenNonNota_Tanggal.ReadOnly = true;
            this.IdenNonNota_Tanggal.Width = 74;
            // 
            // IdenNonNota_NoBukti
            // 
            this.IdenNonNota_NoBukti.DataPropertyName = "NoBukti";
            this.IdenNonNota_NoBukti.HeaderText = "NoBukti";
            this.IdenNonNota_NoBukti.Name = "IdenNonNota_NoBukti";
            this.IdenNonNota_NoBukti.ReadOnly = true;
            this.IdenNonNota_NoBukti.Width = 74;
            // 
            // IdenNonNota_Nominal
            // 
            this.IdenNonNota_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N2";
            this.IdenNonNota_Nominal.DefaultCellStyle = dataGridViewCellStyle24;
            this.IdenNonNota_Nominal.HeaderText = "Nominal";
            this.IdenNonNota_Nominal.Name = "IdenNonNota_Nominal";
            this.IdenNonNota_Nominal.ReadOnly = true;
            this.IdenNonNota_Nominal.Width = 76;
            // 
            // IdenNonNota_Keterangan
            // 
            this.IdenNonNota_Keterangan.DataPropertyName = "Keterangan";
            this.IdenNonNota_Keterangan.HeaderText = "Keterangan";
            this.IdenNonNota_Keterangan.Name = "IdenNonNota_Keterangan";
            this.IdenNonNota_Keterangan.ReadOnly = true;
            this.IdenNonNota_Keterangan.Width = 95;
            // 
            // IdenNonNota_Hasil
            // 
            this.IdenNonNota_Hasil.DataPropertyName = "Hasil";
            this.IdenNonNota_Hasil.HeaderText = "HasilPosting";
            this.IdenNonNota_Hasil.Name = "IdenNonNota_Hasil";
            this.IdenNonNota_Hasil.ReadOnly = true;
            // 
            // frmProsesJournalBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(914, 411);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgtgTransaksi);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.commandButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmProsesJournalBrowse";
            this.Text = "Posting Journal";
            this.Title = "Posting Journal";
            this.Load += new System.EventHandler(this.frmProsesJournalBrowse_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.rgtgTransaksi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.cmdPreview, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Penerimaan.ResumeLayout(false);
            this.Pengeluaran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.Mutasi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.GiroMasuk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.GiroKeluar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.Identifikasi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentifikasi)).EndInit();
            this.DNKN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.BS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.PiutangKaryawan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.BonSementara.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtKas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKas2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKas3)).EndInit();
            this.IdenNonNota.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        DataTable dtIdentifikasi;

        private void frmProsesJournalBrowse_Load(object sender, EventArgs e)
        {
            //DateTime _harini = GlobalVar.GetServerDate;
            _minDate = (DateTime)Tools.DBGetScalar("usp_GetPostDatedLock", new List<Parameter>());
            _maxDate = (DateTime)Tools.DBGetScalar("usp_GetBackDatedLock", new List<Parameter>());
            rgtgTransaksi.FromDate = _minDate;
            rgtgTransaksi.ToDate = _maxDate;
            RefreshData();

            // untuk sementara TabPage nya ada yg dihapus dulu 
            // 17 Juni 2014, Pak Novi minta yg BS sama PK buka aja
            tabControl1.TabPages.Remove(tabControl1.TabPages["DNKN"]); // Tab DK/KN   
            tabControl1.TabPages.Remove(tabControl1.TabPages["BS"]); // Tab BS
            //tabControl1.TabPages.Remove(tabControl1.TabPages["PiutangKaryawan"]); // Tab Piutang Karyawan
            //tabControl1.TabPages.Remove(tabControl1.TabPages["BonSementara"]); // Tab Bon Sementara

        }

        #region Controls Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion

        #region UDF

        // beberapa proses di comment dulu, karena tab DK/KN, BS,, Piutang Karyawan, Bon Sementara dihapus dulu

        void GetBS()
        {
            if (!rgtgTransaksi.FromDate.HasValue || !rgtgTransaksi.ToDate.HasValue)
            {
                Error.ErrorMessage(rgtgTransaksi, "isi dong");
                return;
            }
            DateTime FRomDate = rgtgTransaksi.FromDate.Value;
            DateTime Todate = rgtgTransaksi.ToDate.Value;

            dtKas = Class.GL.JournalBS.dtKAS(FRomDate, Todate).Copy();
            dtVJU = Class.GL.JournalBS.dtVJU(FRomDate, Todate).Copy();
            dtPSL = Class.GL.JournalBS.dtPSL(FRomDate, Todate).Copy();
            dtKas1.AutoGenerateColumns = true;
            dtKas2.AutoGenerateColumns = true;
            dtKas3.AutoGenerateColumns = true;

            dtKas1.DataSource = dtKas; dtKas1.Refresh();
            dtKas2.DataSource = dtVJU; dtKas2.Refresh();
            dtKas3.DataSource = dtPSL; dtKas3.Refresh();

            foreach (Control ctrX in tableLayoutPanel1.Controls)
            {

                if (ctrX is ISA.Controls.CustomGridView)
                {
                    ISA.Controls.CustomGridView ctr = (ISA.Controls.CustomGridView)ctrX;
                    foreach (DataGridViewColumn col in ctr.Columns)
                    {
                        if (col.Name.Contains("Row") || col.Name.Contains("Last") || col.Name.Contains("Last") || col.Name.Contains("id"))
                        {
                            col.Visible = false;
                        }
                        if (col.Name.Contains("Tanggal") || col.Name.Contains("Tgl"))
                        {
                            col.DefaultCellStyle.Format = "dd-MM-yyyy";
                        }

                        if (col.Name.Contains("Rp") || col.Name.Contains("Amount") || col.Name.Contains("Nominal") || col.Name.Contains("Debet") || col.Name.Contains("Kredit") || col.Name.Contains("Vju") || col.Name.Contains("Bkm") || col.Name.Contains("Realisasi") || col.Name.Contains("Selesai"))
                        {
                            col.DefaultCellStyle.Format = "N2";
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }

                        if (col.Name.Contains("NoPer"))
                        {
                            col.Visible = false;
                        }
                    }
                }
            }
        }


        void RefreshData()
        {
            RefreshGrid(dataGridView1, ref dtPenerimaan, "usp_PenerimaanUang_LIST_Posting");
            RefreshGrid(dataGridView2, ref dtPengeluaran, "usp_PengeluaranUang_LIST_Posting");
            RefreshGrid(dataGridView3, ref dtMutasi, "usp_MutasiUang_LIST_Posting");
            RefreshGrid(dataGridView4, ref dtGiroMasuk, "usp_GiroMasuk_LIST_Posting");
            RefreshGrid(dataGridView5, ref dtGiroKeluar, "usp_GiroKeluar_LIST_Posting");
            RefreshGrid(dataGridView9, ref dtIdenNonNota, "usp_PenerimaanLeasingDetailNonPNJ_Journal");
            RefreshGrid_2(dgvIdentifikasi, ref dtIdentifikasi, "usp_PenerimaanTitipanIden_LIST_Posting", GlobalVar.DBShowroom);
            
            // beberapa proses di comment dulu, karena tab DK/KN, BS,, Piutang Karyawan, Bon Sementara dihapus dulu

            // RefreshGrid(dataGridView6, ref dtDKN, "usp_HubunganIstimewa_LIST_Posting");
            if (GlobalVar.PerusahaanID == "SAP" || GlobalVar.PerusahaanID == "HDA" || GlobalVar.PerusahaanID == "OTO")
            {
                //RefreshGrid(dataGridView7, ref dtBS, "usp_KasBon_LIST_Posting");
                //dtBS.Rows.Clear();
                RefreshGrid(dataGridView8, ref dtPK, "usp_PiutangKaryawan_LIST_Posting");

                GetBS();
            }

            cmdProses.Enabled = true;
            cmdProses.Refresh();
        }

        // beberapa proses di comment dulu, karena tab DK/KN, BS,, Piutang Karyawan, Bon Sementara dihapus dulu

        void SementaraBon(bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail, ref int error)
        {
            try
            {
                foreach (DataRow dr in dtKas.Rows)
                {
                    Class.GL.JournalBS.AddJournalKAS(dr, isSimulate, ref dtHeader, ref dtDetail);
                }

                foreach (DataRow dr in dtVJU.Rows)
                {
                    Class.GL.JournalBS.AddJournalVJU(dr, isSimulate, ref dtHeader, ref dtDetail);
                }

                foreach (DataRow dr in dtPSL.Rows)
                {
                    Class.GL.JournalBS.AddJournalPSL(dr, isSimulate, ref dtHeader, ref dtDetail);
                }

                if (isSimulate == false)
                {
                    dtKas.Rows.Clear();
                    dtVJU.Rows.Clear();
                    dtPSL.Rows.Clear();
                    dtKas1.DataSource = dtKas; dtKas1.Refresh();
                    dtKas2.DataSource = dtVJU; dtKas2.Refresh();
                    dtKas3.DataSource = dtPSL; dtKas3.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                error++;

                dtKas.Rows.Clear();
                dtVJU.Rows.Clear();
                dtPSL.Rows.Clear();
                dtKas1.DataSource = dtKas; dtKas1.Refresh();
                dtKas2.DataSource = dtVJU; dtKas2.Refresh();
                dtKas3.DataSource = dtPSL; dtKas3.Refresh();

                Error.LogError(ex);

            }
        }


        void RefreshGrid(DataGridView dgv, ref DataTable dt, string sql)
        {
            List<Parameter> prm = new List<Parameter>();
            //DataColumn colProses = new DataColumn("Proses",typeof(bool));
            prm.Clear();
            prm.Add(new Parameter("@fromDate", SqlDbType.Date, rgtgTransaksi.FromDate));
            prm.Add(new Parameter("@toDate", SqlDbType.Date, rgtgTransaksi.ToDate));
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

            dt = Tools.DBGetDataTable(sql, prm);
            dt.Columns.Add("Hasil", typeof(string));
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = dt;
        }


        void RefreshGrid_2(DataGridView dgv, ref DataTable dt, string sql, string dbname)
        {
            using (Database db = new Database(dbname))
            {
                db.Commands.Add(db.CreateCommand(sql));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, rgtgTransaksi.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, rgtgTransaksi.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.Columns.Add("Hasil", typeof(string));
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = dt;
            }
        }
        #endregion

        private void commandButton1_Click(object sender, EventArgs e)
        {
            string result = "Ok";
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_SelisihKurs_Posting"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            MessageBox.Show(result);
        }


        private void cmdProses_Click(object sender, EventArgs e)
        {
            DataTable dtHeader = null;
            DataTable dtDetail = null;
            prosesJournal(false, ref dtHeader, ref dtDetail);
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            DataTable dtHeader = new DataTable();
            dtHeader.Columns.Add("RowID", typeof(Guid));
            dtHeader.Columns.Add("RecordID", typeof(String));
            dtHeader.Columns.Add("Tanggal", typeof(DateTime));
            dtHeader.Columns.Add("NoReff", typeof(String));
            dtHeader.Columns.Add("Cbg", typeof(String));
            dtHeader.Columns.Add("Src", typeof(String));
            dtHeader.Columns.Add("Uraian", typeof(String));
            dtHeader.Columns.Add("Debet", typeof(Double));
            dtHeader.Columns.Add("Kredit", typeof(Double));
            dtHeader.Columns.Add("UnitUsaha", typeof(string));
            dtHeader.Columns.Add("Owner", typeof(string));

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("RowID", typeof(Guid));
            dtDetail.Columns.Add("HeaderID", typeof(Guid));
            dtDetail.Columns.Add("RecordID", typeof(String));
            dtDetail.Columns.Add("HRecordID", typeof(String));
            dtDetail.Columns.Add("NoPerkiraan", typeof(String));
            dtDetail.Columns.Add("NamaPerkiraan", typeof(String));
            dtDetail.Columns.Add("Uraian", typeof(String));
            dtDetail.Columns.Add("DK", typeof(String));
            dtDetail.Columns.Add("Debet", typeof(Double));
            dtDetail.Columns.Add("Kredit", typeof(Double));
            dtDetail.Columns.Add("MataUang", typeof(String));
            dtDetail.Columns.Add("NilaiOri", typeof(Double));
            //FilldtBS();
            prosesJournal(true, ref dtHeader, ref dtDetail);

            GL.frmJournalPreview ifrmChild = new GL.frmJournalPreview(this, dtHeader, dtDetail);
            ifrmChild.ShowDialog();
        }

        private void prosesJournal(bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail)
        {
            int error = 0;

            // Jurnal Transaksi Kasir : Penerimaan
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Penerimaan"]);
            if ((dtPenerimaan != null) && (dtPenerimaan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPenerimaan.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalPenerimaan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), ref error);
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Kasir : Pengeluaran
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Pengeluaran"]);
            if ((dtPengeluaran != null) && (dtPengeluaran.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPengeluaran.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalPengeluaran(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), ref error);
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Traksaksi Kasir : Mutasi
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Mutasi"]);
            if ((dtMutasi != null) && (dtMutasi.Rows.Count > 0))
            {
                foreach (DataRow dr in dtMutasi.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalMutasi(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), ref error);
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Kasir : Giro Masuk
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["GiroMasuk"]);
            if ((dtGiroMasuk != null) && (dtGiroMasuk.Rows.Count > 0))
            {
                foreach (DataRow dr in dtGiroMasuk.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalGiroMasuk(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), ref error);
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }
            // Jurnal Transaksi Kasir : Giro Keluar
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["GiroKeluar"]);
            if ((dtGiroKeluar != null) && (dtGiroKeluar.Rows.Count > 0))
            {
                foreach (DataRow dr in dtGiroKeluar.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalPengeluaran(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RefID"], Guid.Empty), ref error);
                    //  dr["Hasil"] = Class.AutoJournal.JournalGiroKeluar((Guid)Tools.isNull(dr["RowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // beberapa proses di comment dulu
            /*
            // Jurnal Transaksi DKN
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["DNKN"]);
            if ((dtDKN != null) && (dtDKN.Rows.Count > 0))
            {

                //foreach (DataRow dr in dtDKN.Rows)
                //    dr["Hasil"] = Class.AutoJournal.JournalDKN((Guid)Tools.isNull(dr["RowID"], Guid.Empty));


                foreach (DataRow dr in dtDKN.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalDKN((Guid)Tools.isNull(dr["RowID"], Guid.Empty));
                }
                //DataTable dtDKNOld = new DataTable();
                // dtDKN.DefaultView.RowFilter = "BranchTo!=''";
                //dtDKNOld = dtDKN.DefaultView.ToTable().Copy();

                //DataColumn cConcatenated = new DataColumn("FromCompany", Type.GetType("System.Guid"), "CompanyTo");
                //foreach (DataRow dr in dtDKNOld.Rows)
                //{
                //    dr["Hasil"] = Class.AutoJournal.JournalDKN((Guid)Tools.isNull(dr["RowID"], Guid.Empty));
                //}
              
            }
            */


            // Jurnal Transaksi Kasir : IdenNonNota
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["IdenNonNota"]);
            if ((dtIdenNonNota != null) && (dtIdenNonNota.Rows.Count > 0))
            {
                foreach (DataRow dr in dtIdenNonNota.Rows)
                {
                    dr["Hasil"] = Class.AutoJournal.JournalIdenNonNota(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), ref error);
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }


            if (GlobalVar.PerusahaanID == "SAP" || GlobalVar.PerusahaanID == "HDA" || GlobalVar.PerusahaanID == "OTO")
            {


                //Jurnal Transaksi KasBon 
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["BonSementara"]);
                if ((dtBS != null) && (dtBS.Rows.Count > 0))
                {
                    foreach (DataRow dr in dtBS.Rows)
                    {
                        dr["Hasil"] = Class.AutoJournal.JournalBS(dr, (DateTime)rgtgTransaksi.FromDate, (DateTime)rgtgTransaksi.ToDate, ref error);
                        //dr["Hasil"] = Class.AutoJournal.JournalBS(dr, (DateTime)rgtgTransaksi.FromDate, (DateTime)rgtgTransaksi.ToDate);
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                }

                //Journal Transaksi Piutang Karyawan
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PiutangKaryawan"]);
                if ((dtPK != null) && (dtPK.Rows.Count > 0))
                {
                    foreach (DataRow dr in dtPK.Rows)
                    {
                        dr["Hasil"] = Class.AutoJournal.JournalPiutangKaryawan(isSimulate, ref dtHeader, ref dtDetail, dr, (DateTime)rgtgTransaksi.FromDate, (DateTime)rgtgTransaksi.ToDate, ref error);
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                }

                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["BonSementara"]);
                SementaraBon(isSimulate ,ref dtHeader, ref dtDetail, ref error); //ini yg ngebikin dia ke link journal ( journalrowid ada isinya)
            }

            // Bagian Proses Identifikasi
            // untuk proses identifikasi ini karena bisa beberapa data untuk 1 transaksi, dikelompokkan per SrcRowIDnya
            // jadinya supaya bisa 1 headerJournal dipakai oleh semua transaksi Idennya
            string tempResult = "";
            Guid tempSrcRowID = Guid.Empty;
            Guid currSrcRowID = Guid.Empty;
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Identifikasi"]);
            if ((dtIdentifikasi != null) && (dtIdentifikasi.Rows.Count > 0))
                foreach (DataRow dr in dtIdentifikasi.Rows)
                {
                    currSrcRowID = (Guid)Tools.isNull(dr["SrcRowID"], Guid.Empty);
                    if (tempSrcRowID == currSrcRowID) // kalo src nya sama berarti sebelumnya udah diproses, ngga usah diproses lagi
                    {
                        dr["Hasil"] = tempResult;
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                    else // selain itu, harus diproses
                    {
                        dr["Hasil"] = Class.AutoJournalShowroom.JournalIdentifikasi(isSimulate, ref dtHeader, ref dtDetail, currSrcRowID, dr["SrcID"].ToString(), dr["KodeTrans"].ToString(), ref error);
                        tempResult = dr["Hasil"].ToString();
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                        tempSrcRowID = currSrcRowID;
                    }
                }
            if (isSimulate == true)
            {

            }
            else
            {
                if (error == 0)
                {
                    MessageBox.Show("Proses Berhasil. . .");
                }

                cmdProses.Enabled = false;
                cmdProses.Refresh();
            }
        }
    }
}
