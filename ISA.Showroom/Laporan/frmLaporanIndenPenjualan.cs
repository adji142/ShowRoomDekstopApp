using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ISA.Showroom.Class;


namespace ISA.Showroom.Laporan
{
    public partial class frmLaporanIndenPenjualan : ISA.Controls.BaseForm
    {
        public frmLaporanIndenPenjualan()
        {
            InitializeComponent();
        }

        private void frmLaporanIndenPenjualan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-(GlobalVar.GetServerDate.Day - 1));
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            txtStatusInden.SelectedIndex = 0;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IndenPenjualan_ListReport"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.Int, txtStatusInden.SelectedIndex));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data");
                    return;
                }
                generateLaporan(dt);

            }
            catch (Exception ex)
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

        private void generateLaporan(DataTable dt)
        {

            string _periode = "Periode : " + ((DateTime)rangeDateBox1.FromDate).ToString("dd-MMM-yyyy") + " s/d " + ((DateTime)rangeDateBox1.ToDate).ToString("dd-MMM-yyyy");
            string _type = "Type : " + txtStatusInden.Text;
            string _created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.GetServerDateTime;

            List<ReportParameter> rptParam = new List<ReportParameter>();
            rptParam.Add(new ReportParameter("Periode", _periode));
            rptParam.Add(new ReportParameter("Type", _type));
            rptParam.Add(new ReportParameter("Created", _created));
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptLaporanIndenPenjualan.rdlc", rptParam, dt, "dsIndenPenjualan_Data");
            ifrmReport.Show();
        }

    }
}
