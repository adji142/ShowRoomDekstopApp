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
    public partial class frmLaporanRekonsiliasi : ISA.Controls.BaseForm
    {
       // DataTable dt = new DataTable();
   

        public frmLaporanRekonsiliasi()
        {
            InitializeComponent();
        }

        private void frmLaporanRekonsiliasi_Load(object sender, EventArgs e)
        {
            DateTime now = GlobalVar.GetServerDate;
            //rangeDateBox1.FromDate = (DateTime)DateTime.Today.AddDays(DateTime.Today.Day * -1 + 1);
            //rangeDateBox1.ToDate = (DateTime)DateTime.Today;
            rangeDateBox1.FromDate = new DateTime(now.Year, now.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            
            DateTime tglawal = new DateTime(now.Year, now.Month, 1);
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {

            if (lookUpBankRekening1.txtLookup.Text.Equals(""))
            {
                MessageBox.Show("Anda belum memilih rekening bank yang akan diproses!", "Perhatian!");
            }
            else
            {
                DateTime _FromDate = (DateTime)rangeDateBox1.FromDate;
                DateTime _ToDate = (DateTime)rangeDateBox1.ToDate;
                DateTime _TglDari = (DateTime)rangeDateBox1.FromDate;
                DateTime _TglSampai = (DateTime)rangeDateBox1.ToDate;
                String NoRekening = lookUpBankRekening1.NoRekening;
                String NamaRekenig = lookUpBankRekening1.Namarekening;
                String Namabank = lookUpBankRekening1.NamaBank;
                DataTable dtTrans = new DataTable();
                DataTable dtTransPerTglInput = new DataTable();
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    Guid RekeningRowID = (Guid)lookUpBankRekening1.RowID;
                    db.Commands.Clear();

                    db.Commands.Add(db.CreateCommand("[rsp_RekonsiliasiBank]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAwal", SqlDbType.Date, _FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAkhir", SqlDbType.Date, _ToDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, lookUpBankRekening1.BankID.ToString()));
                    //db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, NoRekening));
                    //db.Commands[0].Parameters.Add(new Parameter("@NamaRekening", SqlDbType.VarChar, NamaRekenig));
                    //db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    ds = db.Commands[0].ExecuteDataSet();

                }

                using (Database db = new Database())
                {
         
                    Guid RekeningRowID = (Guid)lookUpBankRekening1.RowID;
                    db.Commands.Add(db.CreateCommand("usp_TransaksiBank_LIST_FILTER_Rekening_PerTglRk"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));
                    dtTrans = db.Commands[0].ExecuteDataTable();
                }

                using (Database db = new Database())
                {

                    Guid RekeningRowID = (Guid)lookUpBankRekening1.RowID;
                    db.Commands.Add(db.CreateCommand("usp_TransaksiBank_LIST_FILTER_Rekening_PerTglInput"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));
                    dtTransPerTglInput = db.Commands[0].ExecuteDataTable();
                }


                DataTable dt1 = ds.Tables[0]; 
                DataTable dt2 = ds.Tables[1];  
                //DataTable dt3 = ds.Tables[2]; 
                //DataTable dt4 = ds.Tables[3]; 
                
                List<DataTable> lRekonBank = new List<DataTable>();
                List<string> lRekonBankDtName = new List<string>();
                lRekonBank.Add(dt1);
                lRekonBank.Add(dt2);
                //lRekonBank.Add(dt3);
                //lRekonBank.Add(dt4);
                lRekonBank.Add(dtTrans);
                lRekonBank.Add(dtTransPerTglInput);
                lRekonBankDtName.Add("dsRekonsiliasi_data");
                lRekonBankDtName.Add("dsRekonsiliasi_data2");
                //lRekonBankDtName.Add("dsRekonsiliasi_data3");
                //lRekonBankDtName.Add("dsRekonsiliasi_data4");
                lRekonBankDtName.Add("dsRekonsiliasi_TransaksiBank");
                lRekonBankDtName.Add("dsRekonsiliasi_TransaksiBankPerTglInput");

                //List<ReportParameter> rptParams = new List<ReportParameter>();
                //rptParams.Add(new ReportParameter("NamaPT", GlobalVar.PerusahaanName));
                //rptParams.Add(new ReportParameter("FromDate", _FromDate.ToString()));
                //rptParams.Add(new ReportParameter("ToDate", _ToDate.ToString()));
                //frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekapKasBank.rdlc", rptParams, lRekonBank, "dsRekapKasBank_data");
                DataTable dtSaldoAwal = new DataTable();
               
                DateTime _TglSampaiAwal = _TglDari.AddDays(-1);
                DateTime _TglDariAwal = _TglSampaiAwal.AddDays(_TglSampaiAwal.Day * -1 + 1);
                string _TahunBulan = _TglDari.Year.ToString() + _TglDari.Month.ToString().PadLeft(2, '0');
                using (Database db = new Database(GlobalVar.DBName))
                {
                    Guid RekeningRowID = (Guid)lookUpBankRekening1.RowID;
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
                }
                double _SaldoAwal = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["Saldo"], 0));

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NoRekening", NoRekening));
                rptParams.Add(new ReportParameter("FromDate", _FromDate.ToString()));
                rptParams.Add(new ReportParameter("ToDate", _ToDate.ToString()));
                rptParams.Add(new ReportParameter("NamaRekening", NamaRekenig));
                rptParams.Add(new ReportParameter("NamaBank", Namabank));
                rptParams.Add(new ReportParameter("SaldoAwal", _SaldoAwal.ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekonsiliasi.rdlc", rptParams, lRekonBank, lRekonBankDtName);
                ifrmReport.Show();
                this.Close();
            }
        }
    }
}
