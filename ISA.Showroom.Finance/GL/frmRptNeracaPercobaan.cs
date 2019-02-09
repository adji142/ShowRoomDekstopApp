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
    public partial class frmRptNeracaPercobaan : ISA.Controls.BaseForm
    {
        string _posisiPeriode;
        string kodeGudang = GlobalVar.Gudang;
        int _C0;

        public frmRptNeracaPercobaan()
        {
            InitializeComponent();
        }

        private void frmRptNeracaPercobaan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, DateTime.DaysInMonth(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month));
            lookupGudang1.GudangID = "";
            if (GlobalVar.PerusahaanID != "HLD") lookupGudang1.Enabled = false;
            initializeUnitCombo();
        }

        private void initializeUnitCombo()
        {
            Dictionary<string, string> lst = new Dictionary<string, string>();
            lst.Add("all", "ALL");
            lst.Add("honda", "HONDA");
            lst.Add("avalis", "AVALIS");
            lst.Add("ahass", "AHASS");
            cboCabang.DataSource = new BindingSource(lst,null);
            cboCabang.DisplayMember = "Key";
            cboCabang.DisplayMember = "Value";
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID == "HLD") kodeGudang = lookupGudang1.GudangID;           
            if (rdoTunggal.Checked && rdoDetail.Checked)
            {
                neraca_percobaan_tunggal_detail();
            }
            else if (rdoPerbandingan.Checked && rdoDetail.Checked)
            {
                neraca_percobaan_perbandingan_detail();
            }
            else if (rdoTunggal.Checked && rdoGlobal.Checked)
            {
                neraca_percobaan_tunggal_global();
            }
            else if (rdoPerbandingan.Checked && rdoGlobal.Checked)
            {
                neraca_percobaan_perbandingan_global();
            }
        }

        private void neraca_percobaan_tunggal_detail()
        {
            try
            {
                //check unit

                KeyValuePair<string, string> hsil = (KeyValuePair<string, string>)cboCabang.SelectedValue;
                string unittype = hsil.Key;

                if (rdoSebelum.Checked)
                {
                    _posisiPeriode = "B";
                }
                else if (rdoSetelah.Checked)
                {
                    _posisiPeriode = "T";
                }


                if (ckbSaldo.Checked)
                {
                    _C0 = 1;
                }
                else
                {
                    _C0 = 0;
                }


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_03_Neraca_Percobaan_Tunggal_Detail_dv"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _posisiPeriode));
                    db.Commands[0].Parameters.Add(new Parameter("@C0", SqlDbType.Int, _C0));
                    db.Commands[0].Parameters.Add(new Parameter("@unittype", SqlDbType.VarChar, unittype));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport_Neraca_Percobaan_Tunggal_Detail(dt);
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

        private void neraca_percobaan_tunggal_detail_ori()
        {
            try
            {


                if (rdoSebelum.Checked)
                {
                    _posisiPeriode = "B";
                }
                else if (rdoSetelah.Checked)
                {
                    _posisiPeriode = "T";
                }


                if(ckbSaldo.Checked)
                {
                    _C0 = 1;
                }
                else
                {
                    _C0 = 0;
                }


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_03_Neraca_Percobaan_Tunggal_Detail"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID",SqlDbType.UniqueIdentifier,GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _posisiPeriode));
                    db.Commands[0].Parameters.Add(new Parameter("@C0", SqlDbType.Int, _C0));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport_Neraca_Percobaan_Tunggal_Detail(dt);
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

        private void neraca_percobaan_perbandingan_detail()
        {
            try
            {

                if (rdoSebelum.Checked)
                {
                    _posisiPeriode = "B";
                }
                else if (rdoSetelah.Checked)
                {
                    _posisiPeriode = "T";
                }

                if(ckbSaldo.Checked)
                {
                    _C0 = 1;
                }
                else
                {
                    _C0 = 0;
                }


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_03_Neraca_Percobaan_Perbandingan_Detail"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _posisiPeriode));
                    db.Commands[0].Parameters.Add(new Parameter("@C0", SqlDbType.Int, _C0));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport_Neraca_Percobaan_Perbandingan_Detail(dt);
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

        private void neraca_percobaan_tunggal_global()
        {
            try
            {


                if (rdoSebelum.Checked)
                {
                    _posisiPeriode = "B";
                }
                else if (rdoSetelah.Checked)
                {
                    _posisiPeriode = "T";
                }


                if (ckbSaldo.Checked)
                {
                    _C0 = 1;
                }
                else
                {
                    _C0 = 0;
                }


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_03_Neraca_Percobaan_Tunggal_Global"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _posisiPeriode));
                    db.Commands[0].Parameters.Add(new Parameter("@C0", SqlDbType.Int, _C0));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport_Neraca_Percobaan_Tunggal_Detail(dt);
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


        private void neraca_percobaan_perbandingan_global()
        {
            try
            {

                if (rdoSebelum.Checked)
                {
                    _posisiPeriode = "B";
                }
                else if (rdoSetelah.Checked)
                {
                    _posisiPeriode = "T";
                }

                if (ckbSaldo.Checked)
                {
                    _C0 = 1;
                }
                else
                {
                    _C0 = 0;
                }


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_GL_03_Neraca_Percobaan_Perbandingan_Global"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _posisiPeriode));
                    db.Commands[0].Parameters.Add(new Parameter("@C0", SqlDbType.Int, _C0));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                }
                else
                {
                    DisplayReport_Neraca_Percobaan_Perbandingan_Detail(dt);
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


        private void  DisplayReport_Neraca_Percobaan_Tunggal_Detail(DataTable dt)
        {
            string fromDate = String.Format("{0}", rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy"));
            string toDate = String.Format("{0}", rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy"));
            string KodeGudang;

            if (string.IsNullOrEmpty(lookupGudang1.GudangID) && GlobalVar.PerusahaanID=="HLD")
            {
                KodeGudang = "KONSOLIDASI";
            }
            else
            {
                KodeGudang = kodeGudang;
            }

            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("FromDate", fromDate));
            rptParams.Add(new ReportParameter("ToDate", toDate));
            rptParams.Add(new ReportParameter("KodeGudang", KodeGudang));



            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rptNeracaPercobaan.rdlc", rptParams, dt, "dsGL_Data");
            ifrmReport.Show();
        }

        private void DisplayReport_Neraca_Percobaan_Perbandingan_Detail(DataTable dt)
        {
            string year1 = String.Format("{0}", rangeDateBox1.FromDate.Value.ToString("yyyy"));
            string year2 = String.Format("{0}", rangeDateBox1.ToDate.Value.ToString("yyyy"));
            string year3 = (int.Parse(year2.Substring(2, 2)) - 1).ToString();
            string KodeGudang;

            if(string.IsNullOrEmpty(lookupGudang1.GudangID) && GlobalVar.PerusahaanID=="HLD")
            {
                KodeGudang = "KONSOLIDASI";
            }
            else
            {
                KodeGudang = kodeGudang;
            }


            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Year1", "Periode: 1-Jan-"+ year1 + " s/d 31-Dec-" + year1 ));
            rptParams.Add(new ReportParameter("Year2", year2.Substring(2,2)));
            rptParams.Add(new ReportParameter("Year3", year3));
            rptParams.Add(new ReportParameter("KodeGudang", KodeGudang));



            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rptNeracaPercobaanPerbandinganDetail.rdlc", rptParams, dt, "dsGL_Data");
            ifrmReport.Show();

        }

        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        
 

   

 
    }
}
