using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Showroom.Finance.DataTemplates;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmRptRencanaDP : ISA.Controls.BaseForm
    {
        private void DisplayReport(DataSet ds)
        {

            try
            {

                

                string periode = string.Empty;
                periode = String.Format("PERIODE : {0} ",  monthYearBox1.FirstDateOfMonth.ToString("MMMM-yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("FirstDate", monthYearBox1.FirstDateOfMonth.ToString("yyyy/MM/dd")));
                rptParams.Add(new ReportParameter("LastDate", monthYearBox1.LastDateOfMonth.Day.ToString()));
                if (comboBox1.SelectedIndex == 1)
                {
                    rptParams.Add(new ReportParameter("Title","Impor"));
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    rptParams.Add(new ReportParameter("Title", "Lokal"));
                }
                else
                {
                    rptParams.Add(new ReportParameter("Title", "ALL"));
                }

               

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsCashFlow_dtRencana");

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("CashFlow.rptRencanaPembayaranDP.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Text = "Rencana  Pembayaran Uang Muka";
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

        public frmRptRencanaDP()
        {
            InitializeComponent();
        }

        private void frmRptRencanaDP_Load(object sender, EventArgs e)
        {
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            comboBox1.SelectedIndex = 0;
            
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[rsp_CF_PembayaranUangMuka]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, monthYearBox1.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, monthYearBox1.LastDateOfMonth));
                    if (comboBox1.SelectedIndex == 1)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@vendor", SqlDbType.Int, 1));
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                    db.Commands[0].Parameters.Add(new Parameter("@vendor", SqlDbType.Int, 0));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                DisplayReport(ds);
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

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
