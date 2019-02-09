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
    public partial class frmTrBermasalah : ISA.Controls.BaseForm
    {
        public frmTrBermasalah()
        {
            InitializeComponent();
        }

        private void frmTrBermasalah_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
             try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    if (cbTarikan.Checked)
                    {
                        db.Commands.Add(db.CreateCommand("usp_LaporanTarikan"));
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_LaporanPembayaranAdj"));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", rangeDateBox1.FromDate)));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", rangeDateBox1.ToDate)));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan!");
                    return;
                }

                printLaporan(dt);
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
            this.Close();
        }

        private void printLaporan(DataTable dt)
        {
            string periode = "Periode "+string.Format("{0:dd MMM yyyy}", rangeDateBox1.FromDate)+ " s/d "+ string.Format("{0:dd MMM yyyy}", rangeDateBox1.ToDate);
            string created = "Created By "+ SecurityManager.UserID + " on "+DateTime.Now;
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("Created", created));

            string _rdlc, _dataset;

             if (cbTarikan.Checked)
            {
               _rdlc="frmTRBermasalahTarikan.rdlc";
               _dataset="dsTrBermasalah_Tarikan";

            }
            else
            {
               _rdlc="frmTRBermasalahAdjustment.rdlc";
               _dataset="dsTrBermasalah_Adjustment";
            }

            frmReportViewer ifrmReport = new frmReportViewer("Laporan."+_rdlc, rptParams, dt, _dataset);
            ifrmReport.Show();
        }
    }
}
