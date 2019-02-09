using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanRekapBank : ISA.Controls.BaseForm
    {
        Class.FillComboBox clbo = new ISA.Showroom.Finance.Class.FillComboBox();
        public frmLaporanRekapBank()
        {
            InitializeComponent();
        }

        private void frmLaporanRekapBank_Load(object sender, EventArgs e)
        {
            rangeDateTrans.FromDate = (DateTime)GlobalVar.GetServerDate;
            rangeDateTrans.ToDate = (DateTime)GlobalVar.GetServerDate;
            clbo.fillComboBank(cboBank);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            string _NamaBank = "";
            DataRowView drvBank = (DataRowView)cboBank.Items[cboBank.SelectedIndex];
            _NamaBank = drvBank.Row["NamaBank"].ToString();
            DateTime _FromDate = (DateTime)rangeDateTrans.FromDate;
            string _TahunBulan = _FromDate.Year.ToString() + _FromDate.Month.ToString().PadLeft(2, '0');
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                Guid _BankRowID = (Guid)cboBank.SelectedValue;
                db.Commands.Add(db.CreateCommand("usp_RekapBank_Aktif"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateTrans.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateTrans.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                if (_BankRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, _BankRowID));
                dt = db.Commands[0].ExecuteDataTable();

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Bank", _NamaBank));
                rptParams.Add(new ReportParameter("FromDate", rangeDateTrans.FromDate.ToString()));
                rptParams.Add(new ReportParameter("ToDate", rangeDateTrans.ToDate.ToString()));
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekapBank.rdlc", rptParams, dt, "dsBank_RekapBank");
                ifrmReport.Show();
            }
        }

    }
}
