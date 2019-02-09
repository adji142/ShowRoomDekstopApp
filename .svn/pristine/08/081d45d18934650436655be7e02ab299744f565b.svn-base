using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Showroom.Finance.Class;
using ISA.DAL;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanPengajuanIdenBBN : ISA.Controls.BaseForm
    {
        DataTable dtHeader, dtDetail;
        DateTime _fromDate, _toDate; 
        public frmLaporanPengajuanIdenBBN()
        {
            InitializeComponent();
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanPengajuanIdenBBN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            rbrekap.Checked = true;
        }

        private void cmdtampil_Click(object sender, EventArgs e)
        {           
            try
            {
                if (rbrekap.Checked == true)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBFinanceOto))
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_IdenPengajuanBBN]"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada data...");
                    }
                    else
                    {
                        DisplayReport(dt);
                    }
                    
                }
                else
                {
                    MessageBox.Show("det");
                }
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

        private void DisplayReport(DataTable dt)
        {
            string _userid = "Created by " + SecurityManager.UserID + " on " + DateTime.Now;
            List<ReportParameter> rptParams = new List<ReportParameter>();


            rptParams.Add(new ReportParameter("fromDate", rangeDateBox1.FromDate.Value.ToString("dd-MM-yyyy")));
            rptParams.Add(new ReportParameter("toDate", rangeDateBox1.ToDate.Value.ToString("dd-MM-yyyy")));
            rptParams.Add(new ReportParameter("userid", _userid));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptIdenPengajuanBBN.rdlc", rptParams, dt, "dsIdenPengajuanBBN_Data");
            ifrmReport.Show();


        }
    }
}
