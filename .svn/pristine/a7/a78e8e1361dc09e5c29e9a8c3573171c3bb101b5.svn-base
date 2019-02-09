using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmCF_LapCashFlow_Harian : ISA.Controls.BaseForm
    {
        public frmCF_LapCashFlow_Harian()
        {
            InitializeComponent();
            myPeriode.Month = GlobalVar.GetServerDate.Month;
            myPeriode.Year = GlobalVar.GetServerDate.Year;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            string Bulan = myPeriode.Month.ToString().PadLeft(2,'0');
            string Tahun = myPeriode.Year.ToString().PadLeft(4, '0');
            DateTime FromDate = Convert.ToDateTime(Tahun + "-" + Bulan + "-01");
            DateTime ToDate = FromDate.AddMonths(1).AddDays(-1);
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_CF_CashFlow_harian"));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Tahun+Bulan.ToString()));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            List<ReportParameter> Params = new List<ReportParameter>();
            Params.Add(new ReportParameter("Bulan", myPeriode.MonthName));
            Params.Add(new ReportParameter("Tahun", myPeriode.Year.ToString()));
            frmReportViewer ifrmReport = new frmReportViewer("CashFlow.rptCF_CashFlow_harian.rdlc", Params, dt, "dsCashFlow_LapPembayaran");
            ifrmReport.Show();
        }
    }
}
