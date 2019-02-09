using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmRpt05CLabaRugi : ISA.Controls.BaseForm
    {
        string kodeGudang = GlobalVar.Gudang;
        public frmRpt05CLabaRugi()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID == "HLD") kodeGudang = lookupGudang1.GudangID;
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_05CLabaRugi"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, dateTextBox2.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                    return;
                }
                ShowReport(dt);

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmRpt05CLabaRugi_Load(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = new DateTime(GlobalVar.GetServerDate.Year, 1, 1);

            dateTextBox2.DateValue = new DateTime(GlobalVar.GetServerDate.Year, 12, 31);

            lookupGudang1.GudangID = "";
            if (GlobalVar.PerusahaanID != "HLD") lookupGudang1.Enabled = false;
        }

        

        private void dateTextBox2_Validated(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = new DateTime(dateTextBox2.DateValue.Value.Year, 1, 1);
        }



        private void ShowReport(DataTable dt)
        {
            //construct parameter
            //string periode;
            DateTime fromDate = (DateTime)dateTextBox1.DateValue;
            DateTime toDate = (DateTime)dateTextBox2.DateValue;

            string strFromDate = String.Format("{0}", fromDate.ToString("dd-MMM-yyyy"));
            string strToDate = String.Format("{0}", toDate.ToString("dd-MMM-yyyy"));
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("FromDate", strFromDate));
                rptParams.Add(new ReportParameter("ToDate", strToDate));
                rptParams.Add(new ReportParameter("KodeGudang", kodeGudang));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rpt05CLabaRugi.rdlc", rptParams, dt, "dsGL_Data");                
                ifrmReport.Show();
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
    }
}
