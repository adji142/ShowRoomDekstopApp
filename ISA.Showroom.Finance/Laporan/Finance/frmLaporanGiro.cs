using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLaporanGiro : ISA.Controls.BaseForm
    {
        Class.FillComboBox clbo = new ISA.Showroom.Finance.Class.FillComboBox();
        public frmLaporanGiro()
        {
            InitializeComponent();
            clbo.fillComboPerusahaan(cboPT);
            clbo.fillComboBank(cboBank);
        }

        #region functions
        private void DisplayOnOff()
        {   Boolean _LapTrans = Convert.ToBoolean(cboJnsLaporan.SelectedIndex == 0);
            Boolean _LapSaldo = Convert.ToBoolean(cboJnsLaporan.SelectedIndex == 1);
            Boolean _TransBank = false;
            if ( rbTitipGiro.Checked || rbCairGiro.Checked || rbTolakGiro.Checked || rbBatalTitip.Checked || rbBatalCair.Checked || rbBatalTolak.Checked)
            {
                _TransBank = true;
            }
            groupStatus.Enabled = _LapSaldo;
            groupTransaksi.Enabled = _LapTrans;
            labelTanggal.Visible = _LapSaldo;
            txtTanggal.Visible = _LapSaldo;
            labelPeriode.Visible = _LapTrans;
            rangeDatePeriode.Visible = _LapTrans;
            cboBank.Enabled = _LapTrans && _TransBank;
            cboRekening.Enabled = _LapTrans && _TransBank;
            if (!_TransBank)
            {
                if (cboBank.Text != "") cboBank.SelectedIndex = 0;
                if (cboRekening.Text != "") cboRekening.SelectedIndex = 0;
            }
        }
        #endregion

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanGiro_Load(object sender, EventArgs e)
        {
            cboJnsLaporan.SelectedIndex = 0;
            txtTanggal.DateValue = GlobalVar.GetServerDate;
            rangeDatePeriode.FromDate = GlobalVar.GetServerDate;
            rangeDatePeriode.ToDate = GlobalVar.GetServerDate;
            DisplayOnOff();
        }

        private void cboJnsLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayOnOff();
        }

        private void Button_CheckedChanged(object sender, EventArgs e)
        {
            DisplayOnOff();
        }

        private void cboPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPT.SelectedIndex != 0 && cboPT.DisplayMember.ToString() != "")
                clbo.fillComboCabang(cboCabang, (Guid)cboPT.SelectedValue);
        }

        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBank.SelectedIndex != 0 && cboBank.DisplayMember.ToString() != "")
                clbo.fillComboRekening(cboRekening, (Guid)cboBank.SelectedValue);
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (cboJnsLaporan.SelectedIndex == 0) // laporan transaksi
            {
                Guid _PerusahaanRowID = (Guid)Guid.Empty;
                Guid _BankRowID = (Guid)Guid.Empty;
                Guid _RekeningRowID = (Guid)Guid.Empty;
                string _CabangID = "";
                string _Judul = "Laporan ";
                string _Bank = "";
                
                if (cboPT.Text != "") 
                { 
                    DataRowView drvPT = (DataRowView)cboPT.Items[cboPT.SelectedIndex]; 
                    _PerusahaanRowID = (Guid)drvPT.Row["RowID"];  
                }
                if (cboCabang.Text != "") 
                { 
                    DataRowView drvCabang = (DataRowView)cboCabang.Items[cboCabang.SelectedIndex]; 
                    _CabangID = drvCabang.Row["CabangID"].ToString(); 
                }
                if (cboBank.Text != "")
                {
                    DataRowView drvBank = (DataRowView)cboBank.Items[cboBank.SelectedIndex];
                    _BankRowID = (Guid)cboBank.SelectedValue;
                    _Bank = "Bank : " + drvBank.Row["Namabank"].ToString();
                }

                if (cboRekening.Text != "")
                {
                    DataRowView drvRekening = (DataRowView)cboRekening.Items[cboRekening.SelectedIndex];
                    _RekeningRowID = (Guid)cboRekening.SelectedValue;
                    _Bank += " (" + drvRekening.Row["NoRekening"].ToString() + ")";
                }

                int _Pil = 0;
                if ( rbTerimaGiro.Checked )     { _Judul += "Penerimaan Giro"; _Pil = 0; }
                if ( rbTitipGiro.Checked )      { _Judul += "Setoran Giro ke Bank"; _Pil = 1; }
                if ( rbCairGiro.Checked )       { _Judul += "Pencairan Giro"; _Pil = 3; }
                if ( rbTolakGiro.Checked )      { _Judul += "Tolakan Giro"; _Pil = 5; }
                if ( rbBatalTitip.Checked )     { _Judul += "Pembatalan Setoran Giro"; _Pil = 2; }
                if ( rbBatalCair.Checked )      { _Judul += "Pembatalan Pencairan Giro"; _Pil = 4; }
                if ( rbBatalTolak.Checked )     { _Judul += "Pembatalan Tolakan Giro"; _Pil = 6; }
                if (rdbAll.Checked) { _Judul += "Semua Giro"; _Pil = 7; }
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiGiro_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDatePeriode.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDatePeriode.ToDate));
                    if (!rdbAll.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.TinyInt, _Pil));
                    }
                    
                    if (_PerusahaanRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                    if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                    if (_BankRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, _BankRowID));
                    if (_RekeningRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, _RekeningRowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("InitPerusahaan", cboPT.Text));
                    rptParams.Add(new ReportParameter("CabangID", _CabangID));
                    rptParams.Add(new ReportParameter("FromDate", rangeDatePeriode.FromDate.ToString()));
                    rptParams.Add(new ReportParameter("ToDate", rangeDatePeriode.ToDate.ToString()));
                    rptParams.Add(new ReportParameter("Judul", _Judul));
                    rptParams.Add(new ReportParameter("Bank", _Bank));
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptTransaksiGiro.rdlc", rptParams, dt, "dsGiro_GiroMasukan");
                    ifrmReport.Show();

                }
            }
            else // Saldo Giro
            {
                Guid _PerusahaanRowID = (Guid)Guid.Empty;
                string _CabangID = "";
                string _Judul = "Saldo Giro ";

                if (cboPT.Text != "")
                {
                    DataRowView drvPT = (DataRowView)cboPT.Items[cboPT.SelectedIndex];
                    _PerusahaanRowID = (Guid)drvPT.Row["RowID"];
                }
                if (cboCabang.Text != "")
                {
                    DataRowView drvCabang = (DataRowView)cboCabang.Items[cboCabang.SelectedIndex];
                    _CabangID = drvCabang.Row["CabangID"].ToString();
                }

                int _Pil = 0;
                if (rbSaldoGiro.Checked) { _Judul += "Ditangan"; _Pil = 0; }
                if (rbSaldoTitip.Checked) { _Judul += "Titipan"; _Pil = 1; }
                if (rbSaldoTolak.Checked) { _Judul += "Tolak"; _Pil = 5; }

                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SaldoGiro_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, txtTanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.TinyInt, _Pil));
                    if (_PerusahaanRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                    if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("InitPerusahaan", cboPT.Text));
                    rptParams.Add(new ReportParameter("CabangID", _CabangID));
                    rptParams.Add(new ReportParameter("ToDate", txtTanggal.DateValue.ToString()));
                    rptParams.Add(new ReportParameter("Judul", _Judul));
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptSaldoGiro.rdlc", rptParams, dt, "dsGiro_GiroMasukan");
                    ifrmReport.Show();

                }
            }
        }

    }
}
