using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmRptJournalTransaksi : ISA.Controls.BaseForm
    {
        DataTable dtLookup, dtLaporan;
        string kodeGudang = GlobalVar.Gudang, keltran="";
        DateTime fromDate, toDate;
        public frmRptJournalTransaksi()
        {
            InitializeComponent();
        }

        private void frmRptJournalTransaksi_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            lookupGudang1.GudangID = "";
            GetKelompokTransaksi();
            rangeDateBox1.Focus();
            if (GlobalVar.PerusahaanID != "HLD")
            {
                lookupGudang1.Enabled = false;
            }
        }

        private void GetKelompokTransaksi()
        {
            dtLookup = new DataTable();
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, "GL_KelTran"));
                dtLookup = db.Commands[0].ExecuteDataTable();
            }
            if (dtLookup.Rows.Count > 0)
            {
                dtLookup.DefaultView.Sort = "RowOrder";
                cbKelTran.DataSource = dtLookup.DefaultView;
                cbKelTran.DisplayMember = "Value";
                cbKelTran.BindingContext = this.BindingContext;
            }
            else
            {
                cbKelTran.DataSource = null;
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID == "HLD") kodeGudang = lookupGudang1.GudangID;
            keltran = cbKelTran.Text;
            if (keltran != "") keltran = keltran.PadRight(3).Substring(0, 3);
            fromDate = (DateTime)rangeDateBox1.FromDate;
            toDate = (DateTime)rangeDateBox1.ToDate;
            dtLaporan = new DataTable();
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                if (keltran != "ALL")
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_01LaporanJournals"));
                    db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, keltran));
                }
                else
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_01LaporanJournals"));
                }
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                dtLaporan = db.Commands[0].ExecuteDataTable();
            }

            if (dtLaporan.Rows.Count > 0)
            {
                ShowReport(dtLaporan);
            }
            else
            {
                MessageBox.Show(Messages.Confirm.NoDataAvailable);
            }
        }

        private void ShowReport(DataTable dt)
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("title", "LAPORAN JOURNAL TRANSAKSI ("+keltran+")"));
                rptParams.Add(new ReportParameter("perusahaanID", kodeGudang));
                rptParams.Add(new ReportParameter("periode", String.Format("{0:dd-MMM-yyyy}",fromDate) + " S/D " + String.Format("{0:dd-MMM-yyyy}",toDate)));
                frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rptJournalperKelompokTransaksi.rdlc", rptParams, dt, "dsJournalTransaksi_Data");
                ifrmReport.Text = "Laporan Journal Transaksi";
                ifrmReport.Show();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
