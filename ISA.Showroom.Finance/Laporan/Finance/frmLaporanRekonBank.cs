using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Controls;
using ISA.DAL;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanRekonBank : BaseForm
    {
        public frmLaporanRekonBank()
        {
            InitializeComponent();
            rangeDateBoxLapRekonBank.FromDate = GlobalVar.GetServerDate;
            rangeDateBoxLapRekonBank.ToDate = GlobalVar.GetServerDate;
        }


        private void print()
        {

            DateTime _fromdate = (DateTime)rangeDateBoxLapRekonBank.FromDate;
            DateTime _todate = (DateTime)rangeDateBoxLapRekonBank.ToDate;
            DateTime _TglDari = (DateTime)rangeDateBoxLapRekonBank.FromDate;
            DateTime _TglSampai = (DateTime)rangeDateBoxLapRekonBank.ToDate;
            DateTime _TglSampaiAwal = _TglDari.AddDays(-1);
            DateTime _TglDariAwal = _TglSampaiAwal.AddDays(_TglSampaiAwal.Day * -1 + 1);
            Guid RekeningRowID = (Guid)lookUpBankRekening1.RowID;
            string _TahunBulan = _TglDari.Year.ToString() + _TglDari.Month.ToString().PadLeft(2, '0');

            if (tabControl1.SelectedIndex.Equals(0))
            {
                if (dateTextBoxLaprekonBank.Text.Equals(string.Empty)) { return; }
                DateTime _tgl =(DateTime)dateTextBoxLaprekonBank.DateValue;

                if (dateTextBoxLaprekonBank.Text.Equals(string.Empty)) { MessageBox.Show("Tanggal Belum diisi."); return; }
               

                DataTable dt = new DataTable();
                DataTable dtSaldoAwal = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_RekonBank_REPORT"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dateTextBoxLaprekonBank.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();

                    db.Commands.Clear();
                    
                    db.Commands.Add(db.CreateCommand("usp_GetSaldoBukuBank_BY_TahunBulan"));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));

                    if (_TglDari != _TglDari.AddDays(_TglDari.Day * -1 + 1))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDariAwal));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampaiAwal));
                    }


                    dtSaldoAwal = db.Commands[0].ExecuteDataTable();
                    double _SaldoAwal = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["Saldo"], 0));
                    double _SaldoAwalORI = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["SaldoORI"], 0));


                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("Tanggal", _tgl.ToString()));
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("SaldoAwal", _SaldoAwal.ToString()));
                    rptParams.Add(new ReportParameter("SaldoAwalORI", _SaldoAwalORI.ToString()));



                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekonbank.rdlc", rptParams, dt, "dsRekonBank_usp_RekonBank_REPORT");
                    ifrmReport.Show();

                    }
            }
            if (tabControl1.SelectedIndex.Equals(1))
            {

                string _NamaBank = lookUpBankRekening1.lblLookupNamaBank.Text;
                string _Rekening = lookUpBankRekening1.lblNoRekening.Text;
                string _AtasNama = lookUpBankRekening1.lblNamaRekening.Text;

                DataTable dt = new DataTable();
                DataTable dtSaldoAwal = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_RekonBank_REPORT"));
                    db.Commands[0].Parameters.Add(new Parameter("@Fromdate", SqlDbType.Date,rangeDateBoxLapRekonBank.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Todate", SqlDbType.Date, rangeDateBoxLapRekonBank.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    db.Commands.Clear();
                    
                    db.Commands.Add(db.CreateCommand("usp_GetSaldoBukuBank_BY_TahunBulan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));

                    if (_TglDari != _TglDari.AddDays(_TglDari.Day * -1 + 1))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDariAwal));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampaiAwal));
                    }



                    dtSaldoAwal = db.Commands[0].ExecuteDataTable();
                    double _SaldoAwal = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["Saldo"], 0));
                    double _SaldoAwalORI = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["SaldoORI"], 0));


                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("NamaBank", _NamaBank.ToString()));
                    rptParams.Add(new ReportParameter("FromDate", _TglDari.ToString()));
                    rptParams.Add(new ReportParameter("ToDate", _TglSampai.ToString()));
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("SaldoAwal", _SaldoAwal.ToString()));
                    rptParams.Add(new ReportParameter("SaldoAwalORI", _SaldoAwalORI.ToString()));

                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekonBank2.rdlc", rptParams, dt, "dsRekonBank_usp_RekonBank_REPORT");
                    ifrmReport.Show();

                }
            }

        }


        private void cmdPrint_Click(object sender, EventArgs e)
        {
            print();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    

    }
}
