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
    public partial class frmPostingJournalAccrual : ISA.Controls.BaseForm
    {
        DataTable dtAccrual = new DataTable();
        
        public frmPostingJournalAccrual()
        {
            InitializeComponent();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        void RefreshData()
        {
            // khusus yang accrual ngambil datanya beda sendiri
            // sebelumnya -- RefreshGrid(dgJurnalAccrual,     ref dtAccrual, "usp_PenjualanAccrual_LIST_Posting");
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanAccrual_LIST_Posting"));
                db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, monthYearBox1.Month));
                db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, monthYearBox1.Year));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dtAccrual = db.Commands[0].ExecuteDataTable();
                dtAccrual.Columns.Add("Hasil", typeof(string));
                dgJurnalAccrual.AutoGenerateColumns = false;
                dgJurnalAccrual.DataSource = dtAccrual;
            }

            cmdProses.Enabled = true;
            cmdProses.Refresh();
        }

        private void frmPostingJournalPenjualanBrowse_Load(object sender, EventArgs e)
        {
            // buat yg monthyearbox itu kasih nilai defaultnya itu satu bulan sebelumnya aja
            int tempMonth = GlobalVar.GetServerDate.Month - 1;
            int tempYear = GlobalVar.GetServerDate.Year;
            // kalo bulan 1 - 1 kan jadinya 0, itu berarti pindah ke desember tahun sebelumnya
            if ((tempMonth) < 1)
            {
                tempMonth = 12;
                tempYear = tempYear - 1;
            }
            monthYearBox1.Month = tempMonth;
            monthYearBox1.Year = tempYear;

            RefreshData();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            // Jurnal Transaksi Showroom : Penjualan-Accrual -> selalu Penjualan 'K' dan 'FLT'
            tabControl1.SelectedIndex = 2;
            if ((dtAccrual != null) && (dtAccrual.Rows.Count > 0))
            {
                foreach (DataRow dr in dtAccrual.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalAccrual((Guid)Tools.isNull(dr["PenjRowID"], Guid.Empty), (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty), monthYearBox1.Month, monthYearBox1.Year);
                }
            }

            cmdProses.Enabled = false;
            cmdProses.Refresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
