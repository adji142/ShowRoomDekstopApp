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
    public partial class frmLaporanSaldoLeasing : ISA.Controls.BaseForm
    {
        public frmLaporanSaldoLeasing()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_Saldo_Leasing"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rdTanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rdTanggal.ToDate));
                    if ((Guid)cb_Leasing.SelectedValue != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cb_Leasing.SelectedValue));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Periode", rdTanggal.FromDate.Value.ToString("dd-MM-yyyy") +" s/d "+rdTanggal.ToDate.Value.ToString("dd-MM-yyyy")));
                rptParams.Add(new ReportParameter("Leasing", cb_Leasing.Text));
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptSaldoLeasing.rdlc", rptParams, dt, "dsPenerimaanLeasing_SaldoLeasing");
                ifrmReport.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmLaporanSaldoLeasing_Load(object sender, EventArgs e)
        {
            //set cbo leasing
            setcboleasing();

            rdTanggal.FromDate = GlobalVar.GetServerDate.Date.AddDays(-(GlobalVar.GetServerDate.Day - 1));
            rdTanggal.ToDate = (DateTime)GlobalVar.GetServerDate;
        }

        private void setcboleasing()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                db.Commands.Add(db.CreateCommand("usp_Leasing_LIST"));
                dt = db.Commands[0].ExecuteDataTable();

                // Adding new row
                DataRow newRow = dt.NewRow();
                newRow["Nama"] = "ALL";
                newRow["RowID"] = Guid.Empty;
                dt.Rows.InsertAt(newRow, 0);

                cb_Leasing.DataSource = dt;
                cb_Leasing.ValueMember = "RowID";
                cb_Leasing.DisplayMember = "Nama";
            }
        }

    }
}
