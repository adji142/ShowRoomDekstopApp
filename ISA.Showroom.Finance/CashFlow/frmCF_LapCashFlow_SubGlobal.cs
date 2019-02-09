using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmCF_LapCashFlow_SubGlobal : ISA.Controls.BaseForm
    {
        public frmCF_LapCashFlow_SubGlobal()
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string Bulan = rangeDateBox1.ToDate.Value.Month.ToString().PadLeft(2, '0');
                string Tahun = rangeDateBox1.ToDate.Value.Year.ToString().PadLeft(4, '0');
                string Periode = Tahun + Bulan;
                DateTime FromDate = Convert.ToDateTime(Tahun + "-" + Bulan + "-01");
                DateTime ToDate = FromDate.AddMonths(1).AddDays(-1);
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_CF_CashFlow_Subglobal]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Periode));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                List<ReportParameter> Params = new List<ReportParameter>();
                Params.Add(new ReportParameter("Bulan", rangeDateBox1.ToDate.Value.ToString("MMMM")));
                Params.Add(new ReportParameter("Tahun", rangeDateBox1.ToDate.Value.Year.ToString()));
                Params.Add(new ReportParameter("PT",  GlobalVar.PerusahaanID));
                frmReportViewer ifrmReport = new frmReportViewer("CashFlow.rptCF_CashFlow_SubGlobal.rdlc", Params, dt, "dsCashFlow_LapGlobal");
                ifrmReport.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmCF_LapCashFlow_SubGlobal_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(1).AddDays(-1);
        }
    }
}
