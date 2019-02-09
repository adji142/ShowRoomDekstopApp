using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using System.Data.SqlClient;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanRekonsiliasiBank : ISA.Controls.BaseForm
    {
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        double _SaldoAwal;
        double _SaldoAwalORI;

        public frmLaporanRekonsiliasiBank()
        {
            InitializeComponent();
            //fcbo.fillComboBank(comboBox1, true);
            rangeDateBox1.FromDate = GlobalVar.GetServerDate;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;

        }
        
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedIndex != 0 && comboBox1.DisplayMember.ToString() != "")
        //        fcbo.fillComboRekening(comboBox2, (Guid)comboBox1.SelectedValue);
        //}

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            //if (comboBox2.Text == "")
            //{
            //    MessageBox.Show("Anda belum memilih rekening bank yang akan diproses!", "Perhatian!");
            //}

            if (lookUpBankRekening1.txtLookup.Text.Equals(""))
            {
                MessageBox.Show("Anda belum memilih rekening bank yang akan diproses!", "Perhatian!");
            }
            else
            {
                //DataRowView drvBank = (DataRowView)comboBox1.Items[comboBox1.SelectedIndex];
                //DataRowView drvRekening = (DataRowView)comboBox2.Items[comboBox2.SelectedIndex];

                //DataRowView drvBank=(DataRowView)lookUpBankRekening1.
                //DataRowView drvRekening=(DataRowView)

                //string _NamaBank = drvBank.Row["NamaBank"].ToString();
                //string _Rekening = drvRekening.Row["NoRekening"].ToString();
                //string _AtasNama = drvRekening.Row["NamaRekening"].ToString();
                string _NamaBank = lookUpBankRekening1.txtLookup.Text;
                string _Rekening = lookUpBankRekening1.lblNoRekening.Text;
                string _AtasNama = lookUpBankRekening1.lblNamaRekening.Text;

                DateTime _TglDari = (DateTime)rangeDateBox1.FromDate;
                DateTime _TglSampai = (DateTime)rangeDateBox1.ToDate;
                DateTime _TglSampaiAwal = _TglDari.AddDays(-1);
                DateTime _TglDariAwal = _TglSampaiAwal.AddDays(_TglSampaiAwal.Day * -1 + 1);
                string _TahunBulan = _TglDari.Year.ToString() + _TglDari.Month.ToString().PadLeft(2, '0');
                DataTable dtTrans = new DataTable();
                DataTable dtSaldoAwal = new DataTable();
                DataTable dtSaldoRk = new DataTable();

                using (Database db = new Database())
                {
                    //Guid RekeningRowID = (Guid)comboBox2.SelectedValue;
                    Guid RekeningRowID = (Guid)lookUpBankRekening1.RowID;

                    if (rdtglinput.Checked == true)
                    {
                     
                        db.Commands.Add(db.CreateCommand("usp_TransaksiBank_LIST_FILTER_Rekening"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));
                        dtTrans = db.Commands[0].ExecuteDataTable();

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
                        _SaldoAwal = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["Saldo"], 0));
                        _SaldoAwalORI = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["SaldoORI"], 0));


                    }
                    else if (rdtgltransaksi.Checked == true)
                    {

                        db.Commands.Add(db.CreateCommand("usp_TransaksiBank_LIST_FILTER_Rekening_PerTglRk"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));
                        dtTrans = db.Commands[0].ExecuteDataTable();

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
                        _SaldoAwal = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["SaldoAkhirRk"], 0));
                        _SaldoAwalORI = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["SaldoAkhirOriRk"], 0));
                    }


                    //db.Commands.Clear();
                    //db.Commands.Add(db.CreateCommand("usp_GetSaldoBukuBank_BY_TahunBulan"));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    //db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));
                    //if (_TglDari != _TglDari.AddDays(_TglDari.Day * -1 +1))
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDariAwal));
                    //    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampaiAwal));
                    //}
                    //dtSaldoAwal = db.Commands[0].ExecuteDataTable();
                    //double _SaldoAwal = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["Saldo"], 0));
                    //double _SaldoAwalORI = Convert.ToDouble(Tools.isNull(dtSaldoAwal.Rows[0]["SaldoORI"], 0));

                    //double _SaldoAwal = Convert.ToDouble(Tools.isNull(db.Commands[0].ExecuteScalar(), 0));
                    

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_GetSaldoRkBank_BY_TanggalRk"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, _TglSampai));
                    dtSaldoRk = db.Commands[0].ExecuteDataTable();

                    double _SaldoRk = Convert.ToDouble(Tools.isNull(dtSaldoRk.Rows[0]["NominalIDR"], 0));
                    double _SaldoRkORI = Convert.ToDouble(Tools.isNull(dtSaldoRk.Rows[0]["Nominal"], 0));


                    //double _SaldoRk = Convert.ToDouble(Tools.isNull(db.Commands[0].ExecuteDataTable(), 0));

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("NamaBank", _NamaBank));
                    rptParams.Add(new ReportParameter("Rekening", _Rekening));
                    rptParams.Add(new ReportParameter("AtasNama", _AtasNama));
                    rptParams.Add(new ReportParameter("SaldoRk", _SaldoRk.ToString()));
                    rptParams.Add(new ReportParameter("SaldoRkORI", _SaldoRkORI.ToString()));
                    rptParams.Add(new ReportParameter("SaldoAwal", _SaldoAwal.ToString()));
                    rptParams.Add(new ReportParameter("SaldoAwalORI", _SaldoAwalORI.ToString()));
                    rptParams.Add(new ReportParameter("FromDate", _TglDari.ToString()));
                    rptParams.Add(new ReportParameter("ToDate", _TglSampai.ToString()));
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptRekonsiliasiBank.rdlc", rptParams, dtTrans, "dsBank_TransaksiBank");
                    ifrmReport.Show();
                }
            }
        }

        private void frmLaporanRekonsiliasiBank_Load(object sender, EventArgs e)
        {
            rdtglinput.Checked = true;
        }



    }
}
