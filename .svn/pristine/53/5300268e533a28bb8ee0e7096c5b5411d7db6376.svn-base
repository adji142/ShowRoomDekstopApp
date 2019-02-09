using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanPelunasanBBN : ISA.Controls.BaseForm
    {
        public frmLaporanPelunasanBBN()
        {
            InitializeComponent();
        }

        private void frmLaporanPelunasanBBN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate =GlobalVar.GetServerDate.Date.AddDays(-(GlobalVar.GetServerDate.Day -1));
            rangeDateBox1.ToDate = (DateTime)GlobalVar.GetServerDate;
            cb_Jenis.SelectedIndex = 0;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_LaporanPelunasanBBN "));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.Int, cb_Jenis.SelectedIndex));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("FromDate", rangeDateBox1.FromDate.Value.ToString("dd-MM-yyyy")));
                rptParams.Add(new ReportParameter("ToDate", rangeDateBox1.ToDate.Value.ToString("dd-MM-yyyy")));
                rptParams.Add(new ReportParameter("Jenis", cb_Jenis.Text));
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptPelunasanBBN.rdlc", rptParams, dt, "dsPengajuanBBN_LaporanPelunasanBBN");
                ifrmReport.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
