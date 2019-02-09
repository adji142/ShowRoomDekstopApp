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
    public partial class frmLaporanTransaksiKas : ISA.Controls.BaseForm
    {
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        int _pilihanTransaksi = 0;
        public frmLaporanTransaksiKas()
        {
            InitializeComponent();
            rangeDateTrans.FromDate = GlobalVar.GetServerDate;
            rangeDateTrans.ToDate = GlobalVar.GetServerDate;
            fcbo.fillComboPerusahaan(cboPT);
            fcbo.fillComboCabang(cboCabang, GlobalVar.PerusahaanRowID);
            fcbo.fillComboVendor(cboVendor);
            fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
            if (cboKas.Items.Count > 1)
            {
                cboKas.SelectedIndex = 1;
            }
            //else if (cboKas.Items.Count > 0)
            //{
            //    cboKas.SelectedIndex = 0;
            //}
            fcbo.fillComboJnsTransaksi(cboJenisTransaksi);

            rbAll.Checked = true ;
            checkKas.Checked = true;
            checkGiro.Checked = true;
            checkBank.Checked = true;
            lblNamaPerusahaan.Text = GlobalVar.PerusahaanName.Trim();
            
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            Guid _PerusahaanRowID = (Guid)Guid.Empty;
            if (cboPT.Text != "")
            {
                DataRowView drvPT = (DataRowView)cboPT.Items[cboPT.SelectedIndex];
                _PerusahaanRowID = (Guid)drvPT.Row["RowID"];
            }

            string _CabangID = "";
            if (cboCabang.Text != "")
            {
                DataRowView drvCabang = (DataRowView)cboCabang.Items[cboCabang.SelectedIndex];
                _CabangID = drvCabang.Row["CabangID"].ToString();
            }

            Guid _VendorRowID = (Guid)Guid.Empty;
            string _Vendor = "";
            if (cboVendor.Text != "")
            {
                DataRowView drvVendor = (DataRowView)cboVendor.Items[cboVendor.SelectedIndex];
                _VendorRowID = (Guid)drvVendor.Row["RowID"];
                _Vendor = drvVendor.Row["NamaVendor"].ToString();
            }

            //Guid _KasRowID = (Guid)Guid.Empty;
            Guid _KasRowID = new Guid();
            if (cboKas.Text != "")
            {
                DataRowView drvKas = (DataRowView)cboKas.Items[cboKas.SelectedIndex];
                _KasRowID = (Guid)drvKas.Row["RowID"];
            }

            string _InOut = "A".ToString(); 
            if (rbIn.Checked) _InOut = "I";
            else if (rbOut.Checked) _InOut = "O";
            
            Boolean _Kas = checkKas.Checked;
            Boolean _Giro = checkGiro.Checked;
            Boolean _Bank = checkBank.Checked;
            Boolean _IsVendor = checkVendor.Checked;

            string _Jenis = "";
            if (_Kas)
            {
                _Jenis += "Kas";
                if (_KasRowID != Guid.Empty) _Jenis = cboKas.Text.ToString();
            }
            if (_Giro)
            {
                if (_Jenis != "") _Jenis += ", ";
                _Jenis += "Giro";
            }
            if (_Bank)
            {
                if (_Jenis != "") _Jenis += ", ";
                _Jenis += "Bank";
            }
            if (rdoJnsTransaksi.Checked == true) _pilihanTransaksi = 1;
            else if (rdoPiutangKaryawan.Checked == true) _pilihanTransaksi = 2;
            else if (rdoKasbon.Checked == true) _pilihanTransaksi = 3;
            else _pilihanTransaksi = 0;

            DateTime _TglDari = (DateTime)rangeDateTrans.FromDate;
            DateTime _TglSampai = (DateTime)rangeDateTrans.ToDate;
            DataTable dtTrans = new DataTable();

            if (rdtglinput.Checked == true)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiKas_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));
                    db.Commands[0].Parameters.Add(new Parameter("@InOut", SqlDbType.Char, _InOut));
                    db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    if (_PerusahaanRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                    if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                    if (_IsVendor) db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, _VendorRowID));
                    if (_KasRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PilihanTransaksi", SqlDbType.Int, _pilihanTransaksi));
                    if ((Guid)Tools.isNull(cboJenisTransaksi.SelectedValue, Guid.Empty) != Guid.Empty)
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJenisTransaksi.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@IsVendor", SqlDbType.Bit, _IsVendor));
                    db.Commands[0].Parameters.Add(new Parameter("@Kas", SqlDbType.Bit, _Kas));
                    db.Commands[0].Parameters.Add(new Parameter("@Giro", SqlDbType.Bit, _Giro));
                    db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.Bit, _Bank));
                    dtTrans = db.Commands[0].ExecuteDataTable();
                    if (rbTanggal.Checked) dtTrans.DefaultView.Sort = "Tanggal";
                    else dtTrans.DefaultView.Sort = "NoBukti";
                    if (checkSort.Checked) dtTrans.DefaultView.Sort += " DESC";

                    Boolean _isAwal = false;
                    double _KasAwal = 0;
                    if (_CabangID == "" && _InOut == "A" && _Kas && !_Giro && !_Bank && _VendorRowID == Guid.Empty)
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_GetSaldoKasV2"));

                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@tglsaldoawal", SqlDbType.Date, _TglDari));

                        //db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));
                        //db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDariAwal));
                        //db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateTrans.FromDate));
                        _KasAwal = double.Parse(Tools.isNull(db.Commands[0].ExecuteScalar(), "0").ToString());

                        _isAwal = true;
                    }
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("NamaPT", GlobalVar.PerusahaanName));
                    rptParams.Add(new ReportParameter("InitPerusahaan", cboPT.Text));
                    rptParams.Add(new ReportParameter("CabangID", _CabangID));
                    rptParams.Add(new ReportParameter("FromDate", _TglDari.ToString()));
                    rptParams.Add(new ReportParameter("ToDate", _TglSampai.ToString()));
                    rptParams.Add(new ReportParameter("InOut", _InOut));
                    rptParams.Add(new ReportParameter("JnsTransaksi", _Jenis));
                    rptParams.Add(new ReportParameter("Vendor", _Vendor));
                    rptParams.Add(new ReportParameter("SaldoAwal", _KasAwal.ToString()));
                    rptParams.Add(new ReportParameter("isAwal", _isAwal.ToString()));
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptMutasiKas.rdlc", rptParams, dtTrans, "dsKas_TransaksiKas");
                    ifrmReport.Show();
                }
            }
            else if (rdtgltransaksi.Checked == true)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiKas_LIST_FILTER_TanggalRk"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));
                    db.Commands[0].Parameters.Add(new Parameter("@InOut", SqlDbType.Char, _InOut));
                    db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    if (_PerusahaanRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, _PerusahaanRowID));
                    if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                    if (_IsVendor) db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, _VendorRowID));
                    if (_KasRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PilihanTransaksi", SqlDbType.Int, _pilihanTransaksi));
                    if ((Guid)Tools.isNull(cboJenisTransaksi.SelectedValue, Guid.Empty) != Guid.Empty)
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJenisTransaksi.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@IsVendor", SqlDbType.Bit, _IsVendor));
                    db.Commands[0].Parameters.Add(new Parameter("@Kas", SqlDbType.Bit, _Kas));
                    db.Commands[0].Parameters.Add(new Parameter("@Giro", SqlDbType.Bit, _Giro));
                    db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.Bit, _Bank));
                    dtTrans = db.Commands[0].ExecuteDataTable();
                    if (rbTanggal.Checked) dtTrans.DefaultView.Sort = "Tanggal";
                    else dtTrans.DefaultView.Sort = "NoBukti";
                    if (checkSort.Checked) dtTrans.DefaultView.Sort += " DESC";

                    Boolean _isAwal = false;
                    double _KasAwal = 0;
                    if (_CabangID == "" && _InOut == "A" && _Kas && !_Giro && !_Bank && _VendorRowID == Guid.Empty)
                    {
                        DateTime _TglSampaiAwal = _TglDari.AddDays(-1);
                        if (_TglDari.Day == 1) _TglSampaiAwal = _TglDari;
                        DateTime _TglDariAwal = _TglSampaiAwal.AddDays(_TglSampaiAwal.Day * -1 + 1);
                        DateTime _BulanLalu = _TglDariAwal.AddDays(-1);
                        string _TahunBulan = string.Format("{0:yyyyMM}", _TglDariAwal);   //_BulanLalu.Year.ToString() + _BulanLalu.Month.ToString().PadLeft(2, '0');
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_GetSaldoKas_TglRk"));

                        //if (_KasRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));


                        if (_KasRowID == Guid.Empty) //jumlah nominal kasnya [fix krn hanya 2 tipe kas] 
                        {
                            DataRowView drvKas = (DataRowView)cboKas.Items[1];
                            _KasRowID = (Guid)drvKas.Row["RowID"];
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.Char, _TahunBulan));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDariAwal));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateTrans.FromDate));
                        _KasAwal = double.Parse(Tools.isNull(db.Commands[0].ExecuteScalar(), "0").ToString());

                        if (cboKas.Text == "") //kasnya dijumlah 
                        {
                            DataRowView drvKas = (DataRowView)cboKas.Items[2];
                            _KasRowID = (Guid)drvKas.Row["RowID"];

                            db.Commands[0].Parameters[0].Value = _KasRowID;
                            db.Commands[0].Parameters[1].Value = GlobalVar.PerusahaanRowID;
                            db.Commands[0].Parameters[2].Value = _TahunBulan;
                            db.Commands[0].Parameters[3].Value = _TglDariAwal;
                            db.Commands[0].Parameters[4].Value = _TglSampaiAwal;
                            double tmpKas = 0;
                            tmpKas = double.Parse(Tools.isNull(db.Commands[0].ExecuteScalar(), "0").ToString());
                            _KasAwal = tmpKas + _KasAwal;

                        }


                        _isAwal = true;
                    }
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("NamaPT", GlobalVar.PerusahaanName));
                    rptParams.Add(new ReportParameter("InitPerusahaan", cboPT.Text));
                    rptParams.Add(new ReportParameter("CabangID", _CabangID));
                    rptParams.Add(new ReportParameter("FromDate", _TglDari.ToString()));
                    rptParams.Add(new ReportParameter("ToDate", _TglSampai.ToString()));
                    rptParams.Add(new ReportParameter("InOut", _InOut));
                    rptParams.Add(new ReportParameter("JnsTransaksi", _Jenis));
                    rptParams.Add(new ReportParameter("Vendor", _Vendor));
                    rptParams.Add(new ReportParameter("SaldoAwal", _KasAwal.ToString()));
                    rptParams.Add(new ReportParameter("isAwal", _isAwal.ToString()));
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptMutasiKas.rdlc", rptParams, dtTrans, "dsKas_TransaksiKas");
                    ifrmReport.Show();
                }
            }

        }

        private void rbOut_CheckedChanged(object sender, EventArgs e)
        {
            cboVendor.Visible = rbOut.Checked || rbAll.Checked;
            labelVendor.Visible = rbOut.Checked || rbAll.Checked;
            checkVendor.Visible = rbOut.Checked || rbAll.Checked;
            cboVendor.SelectedIndex = 0;
            checkVendor.Checked = false;
            if (rbIn.Checked)
            {
                labelPT.Text = "Dari PT";
                labelCabang.Text = "Dari Cabang";
            }
            if (rbOut.Checked)
            {
                labelPT.Text = "Ke PT";
                labelCabang.Text = "Ke Cabang";
            }
            if (rbAll.Checked)
            {
                labelPT.Text = "Dari/Ke PT";
                labelCabang.Text = "Dari/Ke Cabang";
            }
        }

        private void checkKas_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkKas.Checked && !checkBank.Checked && !checkGiro.Checked)
            {
                MessageBox.Show("Maaf, tidak diperkenankan mengkosongkan semua pilihan Jenis Transaksi!","Perhatian!");
                checkKas.Checked = true;
            }
            cboKas.Visible = checkKas.Checked;
            labelJnsKas.Visible = checkKas.Checked;
            cboKas.SelectedIndex = 1;
            labelBlankKas.Visible = checkKas.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cboVendor.Enabled = checkVendor.Checked;
            cboVendor.SelectedIndex = 0;
        }

        private void frmLaporanTransaksiKas_Load(object sender, EventArgs e)
        {
            rdtglinput.Checked = true;
            //if (cboKas.Items.Count > 0)
            //{
            //    cboKas.SelectedIndex = 0;
            //}
            if (cboKas.Items.Count >= 1)
            {
                cboKas.SelectedIndex = 1;
            }
        }

        private void rdoJnsTransaksi_CheckedChanged(object sender, EventArgs e)
        {
            cboJenisTransaksi.Enabled=rdoJnsTransaksi.Checked;
            lblKetJensTransaksi.Visible = rdoJnsTransaksi.Checked;
        }

        private void rdoPiutangKaryawan_CheckedChanged(object sender, EventArgs e)
        {
            cboJenisTransaksi.SelectedIndex = 0;
            lblKetJensTransaksi.Visible = rdoJnsTransaksi.Checked;
        }

        private void rdoKasbon_CheckedChanged(object sender, EventArgs e)
        {
           cboJenisTransaksi.SelectedIndex = 0;
           lblKetJensTransaksi.Visible = rdoJnsTransaksi.Checked;
        }

        private void rdoSemua_CheckedChanged(object sender, EventArgs e)
        {
            cboJenisTransaksi.SelectedIndex = 0;
            lblKetJensTransaksi.Visible = rdoJnsTransaksi.Checked;
        }

        private void rdtglinput_CheckedChanged(object sender, EventArgs e)
        {
            checkKas.Enabled = true;
            checkGiro.Enabled = true;
        }

        private void rdtgltransaksi_CheckedChanged(object sender, EventArgs e)
        {
            checkBank.Checked = true;
            checkKas.Checked = false;
            checkGiro.Checked = false;
            checkKas.Enabled = false;
            checkGiro.Enabled = false;
        }


        
    }
}
