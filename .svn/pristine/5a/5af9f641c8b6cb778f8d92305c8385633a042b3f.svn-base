using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ISA.Showroom.Class;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapSuratJalan : ISA.Controls.BaseForm
    {
        public frmLapSuratJalan()
        {
            InitializeComponent();
        }

        private void frmLapSuratJalan_Load(object sender, EventArgs e)
        {
            cboStatusKirim.SelectedIndex = 0;

            rdtanggal.FromDate = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            rdtanggal.ToDate = GlobalVar.DateOfServer;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenjualanSJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, rdtanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, rdtanggal.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, cboStatusKirim.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Tidak ada data !!");
                return;
            }
            else
            {
                string namafile = "Laporan.rptSuratJalan.rdlc";
                string periode = rdtanggal.FromDate.Value.ToString("dd-MM-yyyy") + " s/d " + rdtanggal.ToDate.Value.ToString("dd-MM-yyyy");

                List<ReportParameter> rptparam = new List<ReportParameter>();
                rptparam.Add(new ReportParameter("Periode", periode));
                rptparam.Add(new ReportParameter("User", SecurityManager.UserName));
                rptparam.Add(new ReportParameter("Tanggal", GlobalVar.GetServerDateTime.ToString()));
                frmReportViewer frm = new frmReportViewer(namafile, rptparam, dt, "dsPenjualan_SuratJalan");
                frm.Show();
            }
        }
    }
}
