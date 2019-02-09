using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanRekapKasBank : ISA.Controls.BaseForm
    {
        DataTable dt;
        Double AwalKas,AwalBank;

        public frmLaporanRekapKasBank()
        {
            InitializeComponent();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            DateTime _FromDate = (DateTime)rangeDateBox1.FromDate;
            DateTime _ToDate = (DateTime)rangeDateBox1.ToDate;
            DateTime _BulanLalu = _FromDate.AddDays(_FromDate.Day * -1);
            DateTime _AwalBulan = _BulanLalu.AddDays(1);
            DateTime _SblAwalPeriode = _FromDate.AddDays(-1);
            string _TahunBulan = _FromDate.Year.ToString() + _FromDate.Month.ToString().PadLeft(2, '0');

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GetSaldoKas"));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, _TahunBulan));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _AwalBulan));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _SblAwalPeriode));
                AwalKas = Convert.ToDouble(Tools.isNull(db.Commands[0].ExecuteScalar(),0));

                db.Commands.Clear();

                db.Commands.Add(db.CreateCommand("usp_GetSaldoBukuBank"));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _AwalBulan));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _SblAwalPeriode));
                AwalBank = Convert.ToDouble(Tools.isNull(db.Commands[0].ExecuteScalar(),0));

                db.Commands.Clear();

                db.Commands.Add(db.CreateCommand("rsp_RekapKasBank"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@AwalKas", SqlDbType.Money, AwalKas));
                db.Commands[0].Parameters.Add(new Parameter("@AwalBank", SqlDbType.Money, AwalBank));
                dt = db.Commands[0].ExecuteDataTable();
            }
            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NamaPT", GlobalVar.PerusahaanName));
            rptParams.Add(new ReportParameter("FromDate", _FromDate.ToString()));
            rptParams.Add(new ReportParameter("ToDate", _ToDate.ToString()));
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekapKasBank.rdlc", rptParams, dt, "dsRekapKasBank_data");
            ifrmReport.Show();
            this.Close();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanRekapKasBank_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = (DateTime)GlobalVar.GetServerDate.AddDays(GlobalVar.GetServerDate.Day * -1 + 1);
            rangeDateBox1.ToDate = (DateTime)GlobalVar.GetServerDate;
        }
    }
}
