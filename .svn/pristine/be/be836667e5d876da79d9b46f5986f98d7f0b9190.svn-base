using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.Showroom.Finance.Class.GL;
using ISA.DAL;
using Microsoft.Reporting.WinForms;


namespace ISA.Showroom.Finance.GL
{
    public partial class frmJournalNotaPS : ISA.Controls.BaseForm
    {
        DataTable dtHeaderA = new DataTable();
        DataTable dtHeaderB = new DataTable();
        DataTable dtHeaderC = new DataTable();
        DataTable dtHeaderD = new DataTable();
        DataTable dtHeaderE = new DataTable();
        string Msg = string.Empty;

        private bool NotValid(ref DataTable dtt)
        {
            try
            {
                DateTime FromDate = rangeDateBox1.FromDate.Value;
                DateTime ToDate = rangeDateBox1.ToDate.Value;
                Guid PT = (Guid)cboPers.SelectedValue;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalNota_CHECK_Transaksi]"));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanROwID", SqlDbType.UniqueIdentifier, PT));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dtt = dt;
                if (dt.Rows.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

            return true;
        }

        public frmJournalNotaPS()
        {
            InitializeComponent();
        }

        private void frmJournalNotaPS_Load(object sender, EventArgs e)
        {
            try
            {
                if (GlobalVar.PerusahaanRowID != GlobalVar.GetPT.SAP)
                {
                    MessageBox.Show("Hanya Untuk login SAP");
                    this.Close();
                    return;
                }
                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox1.ToDate = GlobalVar.GetServerDate.AddDays(-2);
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dt.Columns.Add(new DataColumn("RowID", typeof(Guid)));
                dt.Columns.Add(new DataColumn("PT", typeof(string)));
                dt.Rows.Add(GlobalVar.GetPT.ECR, "ECERAN");
                dt.Rows.Add(GlobalVar.GetPT.PBR, "PABRIK");
                cboPers.DropDownStyle = ComboBoxStyle.DropDownList;
                cboPers.DataSource = dt;
                cboPers.DisplayMember = "PT";
                cboPers.ValueMember = "RowID";
                Progress.Visible= false;

              
            }
            catch (System.Exception ex)
            {
                this.Close();
                Error.LogError(ex);
               
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (!rangeDateBox1.FromDate.HasValue || !rangeDateBox1.ToDate.HasValue)
            {
                Error.ErrorMessage(rangeDateBox1,"isi");
                return;
            }
            if (GlobalVar.PerusahaanRowID != GlobalVar.GetPT.SAP)
            {
                MessageBox.Show("Hanya Untuk login SAP");
                this.Close();
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime FromDate = rangeDateBox1.FromDate.Value;
                DateTime ToDate = rangeDateBox1.ToDate.Value;
                Guid PT = (Guid) cboPers.SelectedValue;
                dtHeaderA = JournalPS.dtNota(FromDate, ToDate, PT);
                dtHeaderB = JournalPS.dtRetur(FromDate, ToDate, PT);
                dtHeaderC = JournalPS.dtKPJ(FromDate, ToDate, PT);
                dtHeaderD = JournalPS.dtKRJ(FromDate, ToDate, PT);
                dtHeaderE = JournalPS.dtIden(FromDate, ToDate, PT);
                GvHeaderA.AutoGenerateColumns = true;
                GVHeaderB.AutoGenerateColumns = true;
                GVHeaderC.AutoGenerateColumns = true;
                GVHeaderD.AutoGenerateColumns = true;
                GVHeaderE.AutoGenerateColumns = true;
                GvHeaderA.DataSource = dtHeaderA.DefaultView; GvHeaderA.Refresh();
                GVHeaderB.DataSource = dtHeaderB.DefaultView; GVHeaderB.Refresh();
                GVHeaderC.DataSource = dtHeaderC.DefaultView; GVHeaderC.Refresh();
                GVHeaderD.DataSource = dtHeaderD.DefaultView; GVHeaderD.Refresh();
                GVHeaderE.DataSource = dtHeaderE.DefaultView; GVHeaderE.Refresh();
                foreach (TabPage TB in TabJournal.TabPages )
                {
                     foreach (Control ctrX in TB.Controls)
                {
                    if (ctrX is ISA.Controls.CustomGridView)
                    {
                        ISA.Controls.CustomGridView ctr = (ISA.Controls.CustomGridView)ctrX;
                        foreach (DataGridViewColumn col in ctr.Columns)
                        {
                            if (col.Name.Contains("Row"))
                            {
                                col.Visible = false;
                            }
                            if (col.Name.Contains("HeaderID"))
                            {
                                col.Visible = false;
                            }
                            if (col.Name.Contains("RecordID"))
                            {
                                col.Visible = false;
                            }
                            if (col.Name.Contains("Tanggal") || col.Name.Contains("Tgl"))
                            {
                                col.DefaultCellStyle.Format = "dd-MM-yyyy";
                            }
                            if (col.Name.Contains("Rp") || col.Name.Contains("Amount") || col.Name.Contains("Nominal"))
                            {
                                col.DefaultCellStyle.Format = "N2";
                                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            if (col.Name.Contains("F")  )
                            {
                                col.DefaultCellStyle.Format = "N2";
                                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            if (col.Name.Contains("NoPer"))
                            {
                                col.Visible = false;
                            }
                        }
                    }
                }
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

        private void cmdYes_Click(object sender, EventArgs e)
        {
            cmdYes.Enabled = false;
            cmdSearch.Enabled = false;
            Progress.Visible = true;
            DateTime FromDate = rangeDateBox1.FromDate.Value;
            DateTime ToDate = rangeDateBox1.ToDate.Value;
            DataTable dt = new DataTable();
            if (NotValid(ref dt))
            {
                List<ReportParameter> Params = new List<ReportParameter>();
                Params.Add(new ReportParameter("Periode", string.Format("{0} s/d {1}",FromDate.ToString("dd-MM-yyyy"),ToDate.ToString("dd-MM-yyyy") ) ));
                frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rptJournalPS.rdlc", Params, dt, "dsGL_Data2");
                ifrmReport.Show();
                cmdYes.Enabled = true;
                cmdSearch.Enabled = true;
                return;
          
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
            

                int X = dtHeaderA.DefaultView.Count;
                int i = 0;
               
                Msg = "Nota Penjualan";
                backgroundWorker1.ReportProgress(1);
                foreach (DataRowView dr in dtHeaderA.DefaultView)
                {
                    DataRow drr = dr.Row;
                    JournalPS.AddJournalNota(drr);
                    i++;
                    backgroundWorker1.ReportProgress(i/X);
                }


                  X = dtHeaderB.DefaultView.Count;
                  i = 0;

                Msg = "Retur Penjualan";
                backgroundWorker1.ReportProgress(1);
                foreach (DataRowView dr in dtHeaderB.DefaultView)
                {
                    DataRow drr = dr.Row;
                    JournalPS.AddJournalRetur(drr);
                    i++;
                    backgroundWorker1.ReportProgress(i / X);
                }


                  X = dtHeaderC.DefaultView.Count;
                  i = 0;

                Msg = "Koreksi Penjualan";
                backgroundWorker1.ReportProgress(1);
                foreach (DataRowView dr in dtHeaderC.DefaultView)
                {
                    DataRow drr = dr.Row;
                    JournalPS.AddJournalKPJ(drr);
                    i++;
                    backgroundWorker1.ReportProgress(i / X);
                }


                  X = dtHeaderD.DefaultView.Count;
                  i = 0;

                  Msg = "Koreksi Retur Penjualan";
                backgroundWorker1.ReportProgress(1);
                foreach (DataRowView dr in dtHeaderD.DefaultView)
                {
                    DataRow drr = dr.Row;
                    JournalPS.AddJournalKRJ(drr);
                    i++;
                    backgroundWorker1.ReportProgress(i / X);
                }

                X = dtHeaderE.DefaultView.Count;
                i = 0;
                Msg = "Identifikasi   Penjualan";
                backgroundWorker1.ReportProgress(1);
                foreach (DataRowView dr in dtHeaderE.DefaultView)
                {
                    DataRow drr = dr.Row;
                    JournalPS.AddJournalIden(drr);
                    i++;
                    backgroundWorker1.ReportProgress(i / X);
                }

              
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                Msg = "Error";
                backgroundWorker1.ReportProgress(0);
               
                
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
              Progress.Text = Msg;
                
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {

            }
            else if (e.Error != null)
            {
                Msg = "Error";
                Progress.Text = Msg;
                Error.LogError(e.Error);
                progressBar1.Value = 0;
                cmdSearch.PerformClick();
            }
            else
            {
                Msg = "Succes";
                Progress.Text = Msg;
                progressBar1.Value = 100;
                cmdSearch.PerformClick();
            }
            cmdYes.Enabled = true;
            cmdSearch.Enabled = true;
            cmdSearch.PerformClick();
            dtHeaderA.Rows.Clear();
            dtHeaderB.Rows.Clear();
            dtHeaderC.Rows.Clear();
            dtHeaderD.Rows.Clear();
            dtHeaderE.Rows.Clear();
            GvHeaderA.DataSource = dtHeaderA.DefaultView; GvHeaderA.Refresh();
            GVHeaderB.DataSource = dtHeaderB.DefaultView; GVHeaderB.Refresh();
            GVHeaderC.DataSource = dtHeaderC.DefaultView; GVHeaderC.Refresh();
            GVHeaderD.DataSource = dtHeaderD.DefaultView; GVHeaderD.Refresh();
            GVHeaderE.DataSource = dtHeaderE.DefaultView; GVHeaderE.Refresh();
        }
    }
}
