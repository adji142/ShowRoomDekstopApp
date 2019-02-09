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
using ISA.Common;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanPerbandinganGLdanRekapBank : ISA.Controls.BaseForm
    {
        string kodeGudang = GlobalVar.Gudang;
        public frmLaporanPerbandinganGLdanRekapBank()
        {
            InitializeComponent();
        }

        private void frmLaporanPerbandinganGLdanRekonBank_Load(object sender, EventArgs e)
        {

        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            if (toDate.Text == "")
            {
                MessageBox.Show("Silakan Isi Tanggal..","Informasi");
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DateTime _toDate = toDate.DateValue.Value;
                    string _TahunBulan = _toDate.Year.ToString() + _toDate.Month.ToString().PadLeft(2, '0');
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_Perbandingan_GL_RekapBank]"));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                        db.Commands[0].Parameters.Add(new Parameter("@cetakNol", SqlDbType.Bit, chkCetakSaldoNol.Checked));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    DisplayData(dt);

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
        }

        private void DisplayData(DataTable dt)
        {
            DateTime firstdate = new DateTime(toDate.DateValue.Value.Year, toDate.DateValue.Value.Month, 1);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("ToDate", toDate.DateValue.ToString()));

            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptPerbandinganGLRekapBank.rdlc", rptParams, dt, "dsPerbandinganSaldo_DataTable1");
            ifrmReport.Name = "LAPORAN PERBANDINGAN SALDO REKAPITULASI BANK DENGAN SALDO JURNAL";
            ifrmReport.Show();
        }

    }

}
