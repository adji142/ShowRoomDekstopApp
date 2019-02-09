using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanPLLAccounting : ISA.Controls.BaseForm 
    {
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        String _ToPerusahaan = "";
        String _JudulLaporan = "";    

        public frmLaporanPLLAccounting()
        {
            InitializeComponent();
            fcbo.fillComboPerusahaan(cboPT);
        }

        private void frmLaporanPLLAccounting_Load(object sender, EventArgs e)
        {
            optPLL.Checked = true;
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        String GetPerusahaanName(Guid RowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                return Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
            }
            else
            {
                return "";
            }
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {

            Guid _PerusahaanRowID = (Guid)Guid.Empty;
            if (cboPT.Text != "")
            {
                DataRowView drvPT = (DataRowView)cboPT.Items[cboPT.SelectedIndex];
                _PerusahaanRowID = (Guid)drvPT.Row["RowID"];
                _ToPerusahaan = GetPerusahaanName(_PerusahaanRowID);
            }
            else
            {
                _ToPerusahaan = "Semua Perusahaan";
            }
           

            if (rangeDateBox1.FromDate.ToString() == "" || rangeDateBox1.ToDate.ToString() == "")
            {
                MessageBox.Show("Harus isi Tanggal..!!","Informasi");
                return;
            }
            

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                
                if (optPLL.Checked)
                {
                    _JudulLaporan = "LAPORAN PLL VERSI ACCOUNTING";
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("[rsp_PIUTANGLAINLAIN_PT_SALDO_VERSIACCOUNTING]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@LoginPT", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        if (_PerusahaanRowID == Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TerhadapPT", SqlDbType.UniqueIdentifier, null));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TerhadapPT", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                        }
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }
                else if (optHLL.Checked)
                {
                    _JudulLaporan = "LAPORAN HLL VERSI ACCOUNTING";
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("[rsp_HUTANGLAINLAIN_PT_SALDO_VERSIACCOUNTING]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@LoginPT", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        if (_PerusahaanRowID == Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TerhadapPT", SqlDbType.UniqueIdentifier, null));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TerhadapPT", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                        }
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }
                else if (optogabungan.Checked)
                {
                    _JudulLaporan = "LAPORAN GABUNGAN PLL-HLL VERSI ACCOUNTING";
                    using (Database db = new Database())
                    {

                        db.Commands.Add(db.CreateCommand("[rsp_PLLHLL_PT_SALDO_VERSIACCOUNTING]"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@LoginPT", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        if (_PerusahaanRowID == Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TerhadapPT", SqlDbType.UniqueIdentifier, null));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TerhadapPT", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                        }
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }

                DisplayReport(dt);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            
           
        }

        private void DisplayReport(DataTable dt)
        {
            String fromdate = (Convert.ToDateTime (rangeDateBox1.FromDate)).ToString("dd-MMM-yyyy");
            String todate = (Convert.ToDateTime(rangeDateBox1.ToDate)).ToString("dd-MMM-yyyy");

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("FromDate", fromdate));
            rptParams.Add(new ReportParameter("ToDate", todate));
            rptParams.Add(new ReportParameter("DariPerusahaan", GlobalVar.PerusahaanName ));
            rptParams.Add(new ReportParameter("ToPerusahaan", _ToPerusahaan ));
            rptParams.Add(new ReportParameter("Judul", _JudulLaporan));

            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptPLLAccounting.rdlc", rptParams, dt, "dsPLLHLLAccounting_Data1");
            ifrmReport.Name = "LAPORAN VERSI ACCOUNTING";
            ifrmReport.Show();
        }
    }
}
