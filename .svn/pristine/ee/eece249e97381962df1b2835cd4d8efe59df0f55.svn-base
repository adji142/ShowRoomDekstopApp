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

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmRptHLLPLL_GL : ISA.Controls.BaseForm
    {

        Class.FillComboBox fcbo = new Class.FillComboBox();

        private void DisplayReport(DataSet ds)
        {

            try
            {

                

                string periode = string.Empty;
                periode = String.Format("PERIODE : {0} ", dateTextBox1.DateValue.Value.ToString("dd-MM-yyyy") );
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                string title = "";
                
                    title = "Perbandingan GL";
                
                 



                string file = string.Empty;

                file = "Laporan.Finance.rptHLLPLL_GL.rdlc";
                
                

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsPLL_dtLain");

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer(file, rptParams, pTable, pDatasetName);
                ifrmReport.Text = title;
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

        public frmRptHLLPLL_GL()
        {
            InitializeComponent();
        }

        private void frmRptPiutangLainLain_Rekap_Load(object sender, EventArgs e)
        {
            try
            {

                dateTextBox1.DateValue = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);

                fcbo.fillComboPerusahaanNoPerusahaanIDLocal(cboPTke ,0);
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dateTextBox1.DateValue.HasValue)
                {
                    Error.ErrorMessage(dateTextBox1, "Must be Fill");
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_HUTANGLAINLAIN_PIUTANGLAINLAIN_GL]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariID", SqlDbType.UniqueIdentifier,GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeID", SqlDbType.UniqueIdentifier, cboPTke.SelectedValue));
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
