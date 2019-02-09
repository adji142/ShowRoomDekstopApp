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
using System.IO;
using System.Diagnostics;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapStockTarikan : ISA.Controls.BaseForm
    {
        public frmLapStockTarikan()
        {
            InitializeComponent();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTanggal.Text))
            {
                MessageBox.Show("Tanggal belum diisi !");
                txtTanggal.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LapStockTarikan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("NamaPT", GlobalVar.PerusahaanName));
                    rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID));
                    rptParams.Add(new ReportParameter("Tanggal", txtTanggal.Text));
                    rptParams.Add(new ReportParameter("DateTime", GlobalVar.GetServerDateTime.ToString()));   
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptStockTarikan.rdlc", rptParams, dt, "dsstocktarikan_Data");
                    ifrmReport.Show();
                }
                else
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan!");
                }
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLapStockTarikan_Load(object sender, EventArgs e)
        {
            txtTanggal.DateValue = GlobalVar.GetServerDate;
        }
    }
}
