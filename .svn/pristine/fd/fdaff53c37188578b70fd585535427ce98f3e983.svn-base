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
    public partial class frmPostingJournalPotongan : ISA.Controls.BaseForm
    {
        DataTable dtPLS = new DataTable();
        DataTable dtUMT = new DataTable();
        DateTime _minDate, _maxDate;

        public frmPostingJournalPotongan()
        {
            InitializeComponent();
        }

        private void frmPostingJournalPotongan_Load(object sender, EventArgs e)
        {
            _minDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            _maxDate = GlobalVar.GetServerDate;
            rgtgTransaksi.FromDate = _minDate;
            rgtgTransaksi.ToDate = _maxDate;
            RefreshData();
        }

        void RefreshData()
        {
            RefreshGrid(dgPLS, ref dtPLS, "usp_PenerimaanANG_PLS_LIST_Posting");

            cmdProses.Enabled = true;
            cmdProses.Refresh();
        }

        void RefreshGrid(DataGridView dgv, ref DataTable dt, string sql)
        {
            using (Database db = new Database(GlobalVar.DBShowroom))
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

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            if (rgtgTransaksi.ToDate.Value < rgtgTransaksi.FromDate)
            {
                DateTime temp = rgtgTransaksi.ToDate.Value;
                rgtgTransaksi.ToDate = rgtgTransaksi.FromDate.Value;
                rgtgTransaksi.FromDate = temp;
            }
            /*
            if (rgtgTransaksi.ToDate > GlobalVar.GetServerDate) // untuk sementara bebasin
            {
                MessageBox.Show("Tidak dapat memproses data jurnal untuk data ke depan.");
                rgtgTransaksi.ToDate = GlobalVar.GetServerDate;
            }
            */
            RefreshData();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            DataTable dtHeader = null;
            DataTable dtDetail = null;
            // Jurnal Transaksi Potongan Piutang Bunga : PLS
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabControl1.TabPages["tabPLS"]);
            if ((dtPLS != null) && (dtPLS.Rows.Count > 0))
            {
                foreach (DataRow dr in dtPLS.Rows)
                {
                    dr["Hasil"] = Class.AutoJournalShowroom.JournalKoreksiPiutangBunga_PLS(false, ref dtHeader, ref dtDetail, (Guid)Tools.isNull(dr["PenjHistRowID"], Guid.Empty));
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
