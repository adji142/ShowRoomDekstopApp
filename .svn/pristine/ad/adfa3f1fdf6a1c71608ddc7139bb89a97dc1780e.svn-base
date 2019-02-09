using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmRptBukuBesar : ISA.Controls.BaseForm
    {
        string kodeGudang = GlobalVar.Gudang;
        public frmRptBukuBesar()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID == "HLD") kodeGudang = lookupGudang1.GudangID;
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    if (GlobalVar.CabangID.ToUpper().Trim().Contains("06A"))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_GL_02BukuBesar_byCabang"));
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("rsp_GL_02BukuBesar"));
                    }

                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@fromNoPerkiraan", SqlDbType.VarChar, lookupPerkiraan1.NoPerkiraan));
                    db.Commands[0].Parameters.Add(new Parameter("@toNoPerkiraan", SqlDbType.VarChar, lookupPerkiraan2.NoPerkiraan));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    db.Commands[0].Parameters.Add(new Parameter("@cetakNol", SqlDbType.Bit, chkCetakSaldoNol.Checked));
                    db.Commands[0].Parameters.Add(new Parameter("@tabel", SqlDbType.VarChar, cboCabang.SelectedValue));
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
        }

        private void ShowReport(DataTable dt)
        {
            //construct parameter
            //string periode;
            //periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglDO.ToDate).ToString("dd/MM/yyyy"));
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", rangeDateBox1.FromDate.ToString() + "-" + rangeDateBox1.ToDate.ToString()));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rptBukuBesar.rdlc", rptParams, dt, "dsJurnal_Data");
                ifrmReport.Text = "Buku Besar";
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

        private void frmRpt02BukuBesar_Load(object sender, EventArgs e)
        {
            setCboCabang();
            SetControl();   
        }

        private void SetControl()
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(1).AddDays(-1);
            lookupPerkiraan1.NoPerkiraan = "110101200";
            lookupPerkiraan2.NoPerkiraan = "911010100";
            lookupGudang1.GudangID = "";
            if (GlobalVar.PerusahaanID != "HLD") lookupGudang1.Enabled = false;
            cboCabang.SelectedIndex = 0;
        }

        private void setCboCabang() 
        {
            DataTable dtCabang = new DataTable();
            // Define Table
            dtCabang.Columns.Add("Tabel", typeof(string));
            dtCabang.Columns.Add("Nama", typeof(string));
            // Adding new row
            DataRow newRow1 = dtCabang.NewRow();
            newRow1["Tabel"] = "Journal";
            newRow1["Nama"] = "ALL";
            dtCabang.Rows.InsertAt(newRow1, 1);
            DataRow newRow2 = dtCabang.NewRow();
            newRow2["Tabel"] = "JournalHonda";
            newRow2["Nama"] = "HONDA";
            dtCabang.Rows.InsertAt(newRow2, 2);
            DataRow newRow3 = dtCabang.NewRow();
            newRow3["Tabel"] = "JournalAvalis";
            newRow3["Nama"] = "AVALIS";
            dtCabang.Rows.InsertAt(newRow3, 3);
            DataRow newRow4 = dtCabang.NewRow();
            newRow4["Tabel"] = "JournalAhass";
            newRow4["Nama"] = "AHASS";
            dtCabang.Rows.InsertAt(newRow4, 4);

            cboCabang.DataSource = dtCabang;
            cboCabang.DisplayMember = "Nama";
            cboCabang.ValueMember = "Tabel";
        }
    }
}
