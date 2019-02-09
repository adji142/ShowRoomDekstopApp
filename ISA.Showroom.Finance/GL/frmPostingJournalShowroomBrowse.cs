using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmPostingJournalShowroomBrowse : ISA.Controls.BaseForm
    {
        DataTable dtPenjualan = new DataTable();
        DataTable dtPembelian = new DataTable();
        DataTable dtTarikan = new DataTable();
        DataTable dtPLS = new DataTable();
        DataTable dtPotonganPembelian = new DataTable();
        DataTable dtPembelianTLA = new DataTable();
        DataTable dtHPP = new DataTable();
        DataTable dtREPTAM = new DataTable();
        DataTable dtRecalcUM = new DataTable();
        DataTable dtKoreksiPJL = new DataTable();
        DataTable dtIdenMPM = new DataTable();
        DataTable dtAdjSubsidi = new DataTable();
        DataTable dtAdjAngsuran = new DataTable();

        DateTime _minDate, _maxDate;

        public frmPostingJournalShowroomBrowse()
        {
            InitializeComponent();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            if (rgtgTransaksi.ToDate.Value < rgtgTransaksi.FromDate)
            {
                DateTime temp = rgtgTransaksi.ToDate.Value;
                rgtgTransaksi.ToDate = rgtgTransaksi.FromDate.Value;
                rgtgTransaksi.FromDate = temp;
            }
            if(rgtgTransaksi.ToDate > GlobalVar.GetServerDate)
            {
                MessageBox.Show("Tidak dapat memproses data jurnal untuk data ke depan.");
                rgtgTransaksi.ToDate = GlobalVar.GetServerDate;
            }
            RefreshData();
        }

        void RefreshData()
        {
            RefreshGrid(dgJurnalPenjualan, ref dtPenjualan, "usp_Penjualan_LIST_Posting");
            RefreshGrid(dgJurnalPembelian, ref dtPembelian, "usp_Pembelian_LIST_Posting");
            RefreshGrid(dgJurnalTarikan, ref dtTarikan, "usp_PenjualanTarikan_LIST_Posting");
            RefreshGrid(dgPLS, ref dtPLS, "usp_PenerimaanANG_PLS_LIST_Posting");
            RefreshGrid(dgPotonganPembelian, ref dtPotonganPembelian, "usp_PembayaranPemb_LIST_Potongan_Posting");
            RefreshGrid(dgPenjualanHPP, ref dtHPP, "usp_Penjualan_LIST_POSTINGHPP");
            RefreshGrid(dgPembelianREPTAM, ref dtREPTAM, "usp_PembayaranPemb_LIST_POSTINGREPTAM");
            RefreshGrid(dgRecalcUM, ref dtRecalcUM, "usp_PenjualanLog_LIST_PostingUM");
            RefreshGrid(dgKoreksiPJL, ref dtKoreksiPJL, "usp_PenjualanLog_LIST_PostingKoreksiPJL");
            RefreshGrid(dgIdenMPM, ref dtIdenMPM, "usp_PembayaranMPM_LIST_By_Tanggal");
            RefreshGrid(dgvHAdj, ref dtAdjSubsidi, "usp_idenLeasing_Adj_Journal");
            RefreshGrid(dgvAdjAngs, ref dtAdjAngsuran, "usp_AdjAngsuran_Journal");
            
            
            cmdProses.Enabled = true;
            cmdProses.Refresh();
        }

        void RefreshGrid(DataGridView dgv, ref DataTable dt, string sql)
        {
            using(Database db = new Database(GlobalVar.DBShowroom))
            {
                db.Commands.Add(db.CreateCommand(sql));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rgtgTransaksi.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rgtgTransaksi.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dt = db.Commands[0].ExecuteDataTable();
                dt.Columns.Add("Hasil", typeof(string));
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = dt;
            }
        }

        private void frmPostingJournalPenjualanBrowse_Load(object sender, EventArgs e)
        {
            _minDate = new DateTime( GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            _maxDate = GlobalVar.GetServerDate;
            rgtgTransaksi.FromDate = _minDate;
            rgtgTransaksi.ToDate = _maxDate;

            RefreshData();
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rgtgTransaksi_Load(object sender, EventArgs e)
        {

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
            prosesJournal(true, ref dtHeader, ref dtDetail);

            frmJournalPreview ifrmChild = new frmJournalPreview(this, dtHeader, dtDetail);
            ifrmChild.ShowDialog();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            DataTable dtHeader = null;
            DataTable dtDetail = null;
            prosesJournal(false, ref dtHeader, ref dtDetail);
        }


        private void prosesJournal(bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail)
        {
            // Jurnal Transaksi Showroom : Penjualan
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["JurnalPenjualan"]);
            if ((dtPenjualan != null) && (dtPenjualan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPenjualan.Rows)
                {
                    if (dr["Penjualan"].ToString() == "T") // kalo penjualan tunai, tipe T, ngga usah kasih Guid PenjHistRowID nya
                    {
                        dr["Hasil"] = Class.AutoJournalShowroom.JournalPenjualan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), "T", Guid.Empty);
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                    else if (dr["Penjualan"].ToString() == "K") // kalo penjualan kredit, tipe K, kasih PenjHistRowID nya
                    {
                        dr["Hasil"] = Class.AutoJournalShowroom.JournalPenjualan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), "K", (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                }
            }
            // Jurnal Transaksi Showroom : Pembelian
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["JurnalPembelian"]);
            if ((dtPembelian != null) && (dtPembelian.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPembelian.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPembelian(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Showroom : Penjualan-Tarikan -> Seperti Penjualan bisa 'K-APD', bisa 'T', bisa 'K-FLT' itu semua beda2 perhitungannya
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Tarikan"]);
            if ((dtTarikan != null) && (dtTarikan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtTarikan.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalTarikan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), dr["JnsTRK"].ToString(), (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Potongan Piutang Bunga : PLS
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Pelunasan"]);
            if ((dtPLS != null) && (dtPLS.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPLS.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalKoreksiPiutangBunga_PLS(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Potongan Pembelian : POT
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PotonganPembelian"]);
            if ((dtPotonganPembelian != null) && (dtPotonganPembelian.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPotonganPembelian.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPotonganPembelian(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PembayaranPembRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Reparasi dan Biaya Tambahan Pembelian : REPTAM
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PembelianREPTAM"]);
            if ((dtREPTAM != null) && (dtREPTAM.Rows.Count > 0))
            {
                foreach (DataRow dr in dtREPTAM.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPembelianREPTAM(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PembayaranPembRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi HPP : HPP
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PenjualanHPP"]);
            if ((dtHPP != null) && (dtHPP.Rows.Count > 0))
            {
                foreach (DataRow dr in dtHPP.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPenjualanHPP(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty), Tools.isNull(dr["Src"], "").ToString().Trim(), (Guid)Tools.isNull(dr["SrcRowID"], Guid.Empty), Tools.isNull(dr["Ket"], "").ToString().Trim());
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi RecalcUM : RUM
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["RecalcUM"]);
            if ((dtRecalcUM != null) && (dtRecalcUM.Rows.Count > 0))
            {
                foreach (DataRow dr in dtRecalcUM.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalRecalcUM(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), (Guid)Tools.isNull(dr["LogRowID"], Guid.Empty)); // kasih penjualanRowID
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi KoreksiPJL : KPJ
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["KoreksiPJL"]);
            if ((dtKoreksiPJL != null) && (dtKoreksiPJL.Rows.Count > 0))
            {
                foreach (DataRow dr in dtKoreksiPJL.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalKoreksiPJL(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), (Guid)Tools.isNull(dr["LogRowID"], Guid.Empty)); // kasih penjualanRowID
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Iden Pembayaran MPM
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tabIdenMPM"]);
            if ((dtIdenMPM != null) && (dtIdenMPM.Rows.Count > 0))
            {
                foreach (DataRow dr in dtIdenMPM.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalIdenMPM(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty)); // kasih penjualanRowID
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Adjustment Subsidi LSG
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tbAdjSubsidi"]);
            if ((dtAdjSubsidi != null) && (dtAdjSubsidi.Rows.Count > 0))
            {
                foreach (DataRow dr in dtAdjSubsidi.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalAdjSubsidi(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowIDD"], Guid.Empty)); // Adj Subsidi LSG
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Adjustment Angsuran
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tabAdjAngsuran"]);
            if ((dtAdjAngsuran != null) && (dtAdjAngsuran.Rows.Count > 0))
            {
                foreach (DataRow dr in dtAdjAngsuran.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalAdjAngsuran(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty)); // Adj Subsidi LSG
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            if (isSimulate == true)
            {
            }
            else
            {
                cmdProses.Enabled = false;
                cmdProses.Refresh();
            }
        }

        private void prosesJournalX(bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail)
        {
            // Jurnal Transaksi Showroom : Penjualan
            #region Showroom Penjualan
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["JurnalPenjualan"]);
            if ((dtPenjualan != null) && (dtPenjualan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPenjualan.Rows)
                {
                    if (dr["Penjualan"].ToString() == "T") // kalo penjualan tunai, tipe T, ngga usah kasih Guid PenjHistRowID nya
                    {
                        dr["Hasil"] = Class.AutoJournalShowroom.JournalPenjualan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), "T", Guid.Empty);
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                    else if (dr["Penjualan"].ToString() == "K") // kalo penjualan kredit, tipe K, kasih PenjHistRowID nya
                    {
                        dr["Hasil"] = Class.AutoJournalShowroom.JournalPenjualan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), "K", (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                        if (isSimulate)
                        {
                            dr["Hasil"] = "";
                        }
                    }
                }
            }
            #endregion
            // Jurnal Transaksi Showroom : Pembelian
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["JurnalPembelian"]);
            if ((dtPembelian != null) && (dtPembelian.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPembelian.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPembelian(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Showroom : Penjualan-Tarikan -> Seperti Penjualan bisa 'K-APD', bisa 'T', bisa 'K-FLT' itu semua beda2 perhitungannya
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Tarikan"]);
            if ((dtTarikan != null) && (dtTarikan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtTarikan.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalTarikan(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), dr["JnsTRK"].ToString(), (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Potongan Piutang Bunga : PLS
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["Pelunasan"]);
            if ((dtPLS != null) && (dtPLS.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPLS.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalKoreksiPiutangBunga_PLS(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Potongan Pembelian : POT
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PotonganPembelian"]);
            if ((dtPotonganPembelian != null) && (dtPotonganPembelian.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPotonganPembelian.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPotonganPembelian(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PembayaranPembRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi Reparasi dan Biaya Tambahan Pembelian : REPTAM
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PembelianREPTAM"]);
            if ((dtREPTAM != null) && (dtREPTAM.Rows.Count > 0))
            {
                foreach (DataRow dr in dtREPTAM.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPembelianREPTAM(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PembayaranPembRowID"], Guid.Empty));
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi HPP : HPP
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["PenjualanHPP"]);
            if ((dtHPP != null) && (dtHPP.Rows.Count > 0))
            {
                foreach (DataRow dr in dtHPP.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalPenjualanHPP(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PembRowID"], Guid.Empty), Tools.isNull(dr["Src"], "").ToString().Trim(), (Guid)Tools.isNull(dr["SrcRowID"], Guid.Empty), Tools.isNull(dr["Ket"], "").ToString().Trim());
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi RecalcUM : RUM
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["RecalcUM"]);
            if ((dtRecalcUM != null) && (dtRecalcUM.Rows.Count > 0))
            {
                foreach (DataRow dr in dtRecalcUM.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalRecalcUM(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), (Guid)Tools.isNull(dr["LogRowID"], Guid.Empty)); // kasih penjualanRowID
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Transaksi KoreksiPJL : KPJ
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["KoreksiPJL"]);
            if ((dtKoreksiPJL != null) && (dtKoreksiPJL.Rows.Count > 0))
            {
                foreach (DataRow dr in dtKoreksiPJL.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalKoreksiPJL(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty), (Guid)Tools.isNull(dr["LogRowID"], Guid.Empty)); // kasih penjualanRowID
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Iden Pembayaran MPM
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tabIdenMPM"]);
            if ((dtIdenMPM != null) && (dtIdenMPM.Rows.Count > 0))
            {
                foreach (DataRow dr in dtIdenMPM.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalIdenMPM(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty)); // kasih penjualanRowID
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Adjustment Subsidi LSG
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tbAdjSubsidi"]);
            if ((dtAdjSubsidi != null) && (dtAdjSubsidi.Rows.Count > 0))
            {
                foreach (DataRow dr in dtAdjSubsidi.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalAdjSubsidi(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowIDD"], Guid.Empty)); // Adj Subsidi LSG
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            // Jurnal Adjustment Angsuran
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tabAdjAngsuran"]);
            if ((dtAdjAngsuran != null) && (dtAdjAngsuran.Rows.Count > 0))
            {
                foreach (DataRow dr in dtAdjAngsuran.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalAdjAngsuran(isSimulate, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["RowID"], Guid.Empty)); // Adj Subsidi LSG
                    if (isSimulate)
                    {
                        dr["Hasil"] = "";
                    }
                }
            }

            if (isSimulate == true)
            {
            }
            else
            {
                cmdProses.Enabled = false;
                cmdProses.Refresh();
            }
        }

    }
}
