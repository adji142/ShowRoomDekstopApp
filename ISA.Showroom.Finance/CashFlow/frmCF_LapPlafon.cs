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
    public partial class frmCF_LapPlafon : ISA.Controls.BaseForm
    {
        public frmCF_LapPlafon()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_CF_Plafon"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            List<ReportParameter> Params = new List<ReportParameter>();
            Params.Add(new ReportParameter("FromDate", rangeDateBox1.FromDate.ToString()));
            Params.Add(new ReportParameter("ToDate", rangeDateBox1.ToDate.ToString()));
            Params.Add(new ReportParameter("Perusahaan", GlobalVar.PerusahaanName));
            frmReportViewer ifrmReport = new frmReportViewer("CashFlow.rptCF_Plafon.rdlc", Params, dt, "dsBank_RekapBank");
            ifrmReport.Show();
            this.Close();
        }

        private void frmCF_LapPlafon_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(GlobalVar.GetServerDate.Day * -1 + 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }
    }
}
