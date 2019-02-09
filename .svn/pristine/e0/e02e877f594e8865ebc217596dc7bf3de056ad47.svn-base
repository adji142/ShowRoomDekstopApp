using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ISA.Showroom.Pembelian
{
    public partial class frmPembelianUpdate : ISA.Controls.BaseForm
    {
        enum FormMode { New, Update };
        FormMode mode = new FormMode();
        Guid _rowID, _vendorRowID, _typeRowID;

        string _pembelian = "";
        string _kondisi = "";
        string _cabangID = GlobalVar.CabangID;
        string _noTransUM = "";
        string _noTransBR = ""; 
        string _noTransBT = "";
        string _noTransBY = "";

        bool _fisik = false;
        bool _bpkb = false;
        bool _stnk = false;
        bool _kontakut = false;
        bool _kontakcad = false;
        bool _kuncipas = false;
        bool _manual = false;
        bool _servis = false;
        DateTime TglJT;
        bool isCetak = false;

        double _hargabeli = 0;
        Guid _rowIDHarga;
        int _cekharga = 0;

        public frmPembelianUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.New;
            _rowID = Guid.NewGuid();
        }

        public frmPembelianUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.Update;
            _rowID = rowID;
        }

        private void frmPembelianUpdate_Load(object sender, EventArgs e)
        {
            if (GlobalVar.CabangID.ToUpper() == "06B" || GlobalVar.CabangID.ToUpper() == "06C" || GlobalVar.CabangID.ToUpper() == "06D" || GlobalVar.CabangID.ToUpper() == "06E")
            {
                rbPembelian2.Visible = false;
                rbPembelian2.Enabled = false;
                rbPembelian2.Checked = false;

                rbKondisi1.Visible = false;
                rbKondisi1.Enabled = false;
                rbKondisi1.Checked = false;
                rbKondisi2.Checked = true;
            }
            try
            {
                rbManual.Checked = true;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = FillComboBox.DBGetProvinsi(Guid.Empty);
                dt.DefaultView.Sort = "Nama ASC";
                cboProvinsi.DisplayMember = "Nama";
                cboProvinsi.ValueMember = "RowID";
                cboProvinsi.DataSource = dt.DefaultView;

                Guid _provRowID = (Guid)cboProvinsi.SelectedValue;
                DataTable dt2 = FillComboBox.DBGetKota(Guid.Empty, _provRowID);
                dt2.DefaultView.Sort = "Nama ASC";
                cboKota.DisplayMember = "Nama";
                cboKota.ValueMember = "RowID";
                cboKota.DataSource = dt2.DefaultView;

                DataTable dt3 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                dt3.DefaultView.Sort = "MataUangID ASC";
                cboMataUang.DisplayMember = "MataUangID";
                cboMataUang.ValueMember = "MataUangID";
                cboMataUang.DataSource = dt3.DefaultView;

                if (mode == FormMode.New)
                {
                    
                    txtTglBeli.DateValue = GlobalVar.GetServerDate;
                    txtReferensi.Text = "";
                    rbPembelian1.Checked = true;
                    lookUpVendor.txtNamaVendor.Text = "";
                    lookUpMotor.txtNamaMotor.Text = "";
                    txtWarna.Text = "";
                    numTahun.Value = GlobalVar.GetServerDate.Year;
                    txtNopol.Text = "";
                   // rbKondisi1.Checked = true;
                    txtNoRangka.Text = "";
                    txtNoMesin.Text = "";
                    txtNoBPKB.Text = "";
                    txtNamaBPKB.Text = "";
                    txtAlamatBPKB.Text = "";
                    txtKetBPKB.Text = "";
                    rbFisik2.Checked = true;
                    rbBPKB2.Checked = true;
                    rbSTNK2.Checked = true;
                    rbKontakUt2.Checked = true;
                    rbKontakCad2.Checked = true;
                    rbKunciPas2.Checked = true;
                    rbManual2.Checked = true;
                    rbServis2.Checked = true;
                    txtHarga.Text = "0";
                    txtUangMuka.Text = "";
                    numKredit.Value = 0;
                    txtTotal.Text = "0";

                    // untuk yang provinsibpkb
                    // ambil dari app setting
                    DataTable dummyPR = new DataTable();
                    using (Database dbsubPR = new Database())
                    {
                        dbsubPR.Commands.Add(dbsubPR.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPR.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PROVPEMILIKBPKB"));
                        dummyPR = dbsubPR.Commands[0].ExecuteDataTable();
                        if (dummyPR.Rows.Count > 0)
                            cboProvinsi.Text = dummyPR.Rows[0]["Value"].ToString();
                    }
                    DataTable dummyKT = new DataTable();
                    using (Database dbsubKT = new Database())
                    {
                        dbsubKT.Commands.Add(dbsubKT.CreateCommand("usp_AppSetting_LIST"));
                        dbsubKT.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KOTAPEMILIKBPKB"));
                        dummyKT = dbsubKT.Commands[0].ExecuteDataTable();
                        if (dummyKT.Rows.Count > 0)
                            cboKota.Text = dummyKT.Rows[0]["Value"].ToString();
                    }
                    
                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }
                }
                else
                {
                    DataTable _dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Pembelian_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        _dt = db.Commands[0].ExecuteDataTable();
                    }
                    txtFaktur.Text = Tools.isNull(_dt.Rows[0]["NoFaktur"], "").ToString();
                    txtNoTrans.Text = Tools.isNull(_dt.Rows[0]["NoTrans"], "").ToString();
                    txtTglBeli.DateValue = (DateTime)Tools.isNull(_dt.Rows[0]["TglBeli"], "");
                    txtReferensi.Text = Tools.isNull(_dt.Rows[0]["Referensi"], "").ToString();
                    if (Tools.isNull(_dt.Rows[0]["Pembelian"], "").ToString() == "Tunai") rbPembelian1.Checked = true;
                    else rbPembelian2.Checked = true;

                    _vendorRowID = (Guid)Tools.isNull(_dt.Rows[0]["VendorRowID"], Guid.Empty);
                    DataTable dtVdr = FillComboBox.DBGetVendor(_vendorRowID);
                    lookUpVendor.txtNamaVendor.Text = Tools.isNull(dtVdr.Rows[0]["Nama"], "").ToString();
                    lookUpVendor._vendor.RowID = _vendorRowID;
                    _typeRowID = (Guid)Tools.isNull(_dt.Rows[0]["TypeRowID"], Guid.Empty);
                    DataTable dtType = FillComboBox.DBGetMotor(Guid.Empty, _typeRowID, "", "");
                    lookUpMotor.txtNamaMotor.Text = Tools.isNull(dtType.Rows[0]["Type"], "").ToString();
                    lookUpMotor._motor.RowID = _typeRowID;
                    txtWarna.Text = Tools.isNull(_dt.Rows[0]["Warna"], "").ToString();
                    numTahun.Value = int.Parse(Tools.isNull(_dt.Rows[0]["Tahun"], "").ToString());
                    txtNopol.Text = Tools.isNull(_dt.Rows[0]["Nopol"], "").ToString();

                    if (Tools.isNull(_dt.Rows[0]["Kondisi"], "").ToString() == "Baru") rbKondisi1.Checked = true;
                    else rbKondisi2.Checked = true;

                    txtNoRangka.Text = Tools.isNull(_dt.Rows[0]["NoRangka"], "").ToString();
                    txtNoMesin.Text = Tools.isNull(_dt.Rows[0]["NoMesin"], "").ToString();
                    txtNoBPKB.Text = Tools.isNull(_dt.Rows[0]["NoBPKB"], "").ToString();
                    txtNamaBPKB.Text = Tools.isNull(_dt.Rows[0]["NamaBPKB"], "").ToString();
                    txtAlamatBPKB.Text = Tools.isNull(_dt.Rows[0]["AlamatBPKB"], "").ToString();
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekFisik"], false) == true) rbFisik1.Checked = true;
                    else rbFisik2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekBPKB"], false) == true) rbBPKB1.Checked = true;
                    else rbBPKB2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekSTNK"], false) == true) rbSTNK1.Checked = true;
                    else rbSTNK2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekManualBook"], false) == true) rbManual1.Checked = true;
                    else rbManual2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekKunciUtama"], false) == true) rbKontakUt1.Checked = true;
                    else rbKontakUt2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekKunciDuplikat"], false) == true) rbKontakCad1.Checked = true;
                    else rbKontakCad2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekKunciPas"], false) == true) rbKunciPas1.Checked = true;
                    else rbKunciPas2.Checked = true;
                    if ((bool)Tools.isNull(_dt.Rows[0]["cekBukuServis"], false) == true) rbServis1.Checked = true;
                    else rbServis2.Checked = true;
                    DataTable dtState = FillComboBox.DBGetStateAll(Guid.Empty, "", Guid.Empty, Tools.isNull(_dt.Rows[0]["KotaBPKB"], "").ToString(), Guid.Empty, "", Guid.Empty, "");
                    cboProvinsi.Text = Tools.isNull(dtState.Rows[0]["Provinsi"], "").ToString();
                    cboKota.Text = Tools.isNull(_dt.Rows[0]["KotaBPKB"], "").ToString();
                    cboMataUang.Text = Tools.isNull(_dt.Rows[0]["MataUangID"], "").ToString();
                    txtKetBPKB.Text = Tools.isNull(_dt.Rows[0]["KeteranganBPKB"], "").ToString();
                    txtHarga.Text = Tools.isNull(_dt.Rows[0]["HargaJadi"], "").ToString();
                    txtUangMuka.Text = Tools.isNull(_dt.Rows[0]["UangMuka"], "").ToString();
                    numKredit.Value = int.Parse(Tools.isNull(_dt.Rows[0]["LamaKredit"], "").ToString());
                    txtTotal.Text = Tools.isNull(_dt.Rows[0]["HargaOff"], "").ToString();
                    if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak1"], 0)) > 0)
                    {
                        isCetak = true;
                    }

                    if (Tools.isNull(_dt.Rows[0]["Transmisi"], "").ToString().ToUpper() == "AUTOMATIC")
                    {
                        rbAutomatic.Checked = true;
                    }
                    else
                    {
                        rbManual.Checked = true;
                    }

                    txtHargaOTR.Text = Tools.isNull(_dt.Rows[0]["HargaOTR"], "").ToString();

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

        private void cboProvinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)cboProvinsi.SelectedValue;
                DataTable dt = FillComboBox.DBGetKota(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKota.DisplayMember = "Nama";
                cboKota.ValueMember = "RowID";
                cboKota.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbPembelian1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPembelian1.Checked == true)
            {
                txtUangMuka.Enabled = false;
                numKredit.Enabled = false;
            }
            else
            {
                txtUangMuka.Enabled = true;
                numKredit.Enabled = true;
            }
        }

        private void rbPembelian2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPembelian2.Checked == true)
            {
                txtUangMuka.Enabled = true;
                numKredit.Enabled = true;
            }
            else
            {
                txtUangMuka.Enabled = false;
                numKredit.Enabled = false;
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {   
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (((DateTime) txtTglBeli.DateValue).Date < GlobalVar.GetServerDate.Date)
                {
                    MessageBox.Show("Tgl. Pembelian lebih kecil dari pada tanggal sekarang !");
                    txtTglBeli.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTglBeli.Text))
                {
                    MessageBox.Show("Tgl. Pembelian belum diisi !");
                    txtTglBeli.Focus();                
                    return;
                }

                if (txtTglBeli.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
                {
                    if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        txtTglBeli.Focus();
                        return;
                    }
                }
                if (string.IsNullOrEmpty(lookUpVendor.txtNamaVendor.Text) || lookUpVendor._vendor.RowID == null || lookUpVendor._vendor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Nama Vendor belum dipilih !");
                    lookUpVendor.txtNamaVendor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(lookUpMotor.txtNamaMotor.Text) || lookUpMotor._motor.RowID == null || lookUpMotor._motor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Merk / Type Motor belum dipilih !");
                    lookUpVendor.txtNamaVendor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtWarna.Text))
                {
                    MessageBox.Show("Warna belum diisi !");
                    txtWarna.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(numTahun.Value.ToString()))
                {
                    MessageBox.Show("Tahun Pembuatan belum diisi !");
                    numTahun.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNopol.Text))
                {
                    if (rbKondisi1.Checked == true && GlobalVar.CabangID.Contains("13"))
                    {
                    }
                    else
                    {
                        MessageBox.Show("Nomor Polisi belum diisi !");
                        txtNopol.Focus();
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txtNoRangka.Text))
                {
                    MessageBox.Show("Nomor Rangka belum diisi !");
                    txtNoRangka.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNoMesin.Text))
                {
                    MessageBox.Show("Nomor Mesin belum diisi !");
                    txtNoMesin.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNoBPKB.Text))
                {
                    MessageBox.Show("Nomor BPKB belum diisi !");
                    txtNoBPKB.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNamaBPKB.Text))
                {
                    MessageBox.Show("Nama Pemilik BPKB belum diisi !");
                    txtNamaBPKB.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtAlamatBPKB.Text))
                {
                    MessageBox.Show("Alamat Pemilik BPKB belum diisi !");
                    txtAlamatBPKB.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtHarga.Text))
                {
                    MessageBox.Show("Harga Jadi belum diisi !");
                    txtHarga.Focus();
                    return;
                }
                if (numKredit.Enabled == true)
                {
                    double jmlKredit = Convert.ToDouble(numKredit.Value);
                    DateTime TglBeli = (DateTime)txtTglBeli.DateValue;
                    TglJT = TglBeli.AddDays(jmlKredit);
                }

                //cekHargaBeli();

                //if (_hargabeli == 0)
                //{
                //    MessageBox.Show("Harga Type Motor " + lookUpMotor.txtNamaMotor.Text + " belum diisi");
                //    return;
                //}

                //if (_hargabeli > txtHarga.GetDoubleValue)
                //{
                //    if (MessageBox.Show("Harga untuk Type Motor " + lookUpMotor.txtNamaMotor.Text + " Rp " + _hargabeli.ToString("N0") + ". Anda yakin ingin melanjutkan proses ini ?", "Alert",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //    {
                //        return;
                //    }
                    
                //}
                //else if (_hargabeli > txtHarga.GetDoubleValue)
                //{
                //    if (MessageBox.Show("Harga untuk Type Motor " + lookUpMotor.txtNamaMotor.Text + " Rp " + _hargabeli.ToString("N0") + ". Anda yakin ingin melanjutkan proses ini ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //    {
                //        return;
                //    }

                //}

                cekAppSetting();
                cekHargaBeli();

                if (_cekharga == 1)
                {
                    if (_hargabeli == 0)
                    {
                        MessageBox.Show("Harga Type Motor " + lookUpMotor.txtNamaMotor.Text + " belum diisi");
                        return;
                    }

                    if (_hargabeli < txtHarga.GetDoubleValue)
                    {
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PembelianHargaLebih), "Harga Jadi > Harga Type Motor. Harga Type Motor Rp " + _hargabeli.ToString("N0"));
                        if (GlobalVar.pinResult == false)
                        {
                            MessageBox.Show("PIN Ditolak.");
                            return;
                        }

                        //MessageBox.Show("Harga Jadi > Harga Type Motor. Harga Type Motor Rp " + _hargabeli.ToString("N0"));
                    }
                }

                // mulai pengecekan nopolisi, kalo di tabel pembelian ada no polisi yang sama, harganya itu dipake buat bandingin
                using (Database db = new Database())
                {
                    DataTable dummy = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Check_LastHargaPembelianbyNopol"));
                    db.Commands[0].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, txtNopol.Text));
                    dummy = db.Commands[0].ExecuteDataTable();
                    if (dummy.Rows.Count > 0)
                    {
                        if ( Convert.ToDouble(dummy.Rows[0]["NumData"].ToString()) > 0)
                        {
                            // berarti ada data harga, bandingin
                            double tempharga = Convert.ToDouble(dummy.Rows[0]["LastPrice"].ToString());
                            if (Convert.ToDouble(txtHarga.Text.ToString()) > tempharga)
                            {
                                /*
                                // kalo harga beli lagi lebih besar dari harga dulu pernah beli, error
                                MessageBox.Show("Pernah ada transaksi pembelian motor dengan nomor polisi sama dengan harga lebih rendah !");
                                txtHarga.Focus();
                                return;
                                */
                                // sekarang dibuat kalau mau beli harganya lebih, kena pin aja
                                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                                DateTime date = GlobalVar.GetServerDate;
                                Calendar cal = dfi.Calendar;
                                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang,
                                            Convert.ToInt32(PinId.ModulId.PembelianHargaLebih),
                                            "Untuk membeli motor dengan harga lebih tinggi dari harga sebelumnya, perlu PIN!", _rowID);
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }
                    }
                }

                if (rbPembelian1.Checked == true)
                {
                    _pembelian = rbPembelian1.Text;
                }
                else
                {
                    _pembelian = rbPembelian2.Text;
                }

                if (rbKondisi1.Checked == true)
                {
                    _kondisi = rbKondisi1.Text;
                }
                else
                {
                    _kondisi = rbKondisi2.Text;
                }

                if (rbFisik1.Checked == true)
                {
                    _fisik = true;
                }
                else
                {
                    _fisik = false;
                }

                if (rbBPKB1.Checked == true)
                {
                    _bpkb = true;
                }
                else
                {
                    _bpkb = false;
                }

                if (rbSTNK1.Checked == true)
                {
                    _stnk = true;
                }
                else
                {
                    _stnk = false;
                }

                if (rbKontakUt1.Checked == true)
                {
                    _kontakut = true;
                }
                else
                {
                    _kontakut = false;
                }

                if (rbKontakCad1.Checked == true)
                {
                    _kontakcad = true;
                }
                else
                {
                    _kontakcad = false;
                }

                if (rbKunciPas1.Checked == true)
                {
                    _kuncipas = true;
                }
                else
                {
                    _kuncipas = false;
                }

                if (rbManual1.Checked == true)
                {
                    _manual = true;
                }
                else
                {
                    _manual = false;
                }

                if (rbServis1.Checked == true)
                {
                    _servis = true;
                }
                else
                {
                    _servis = false;
                }

                // kalau kredit DP nya jangan 0 dong
                if (rbPembelian2.Checked == true)
                {
                    if(txtUangMuka.GetDoubleValue < 1)
                    {
                        MessageBox.Show("Jika pembelian kredit, uang muka tidak boleh bernilai 0");
                        txtUangMuka.Focus();
                        return;
                    }
                }

                if (mode == FormMode.New)
                {
                    txtFaktur.Text = Numerator.NextNumber("NFB");
                    txtNoTrans.Text = Numerator.NextNumber("NTB");                    

                    if (!string.IsNullOrEmpty(txtUangMuka.Text) && txtUangMuka.Text != "0") _noTransUM = Numerator.NextNumber("NKB");
                    if (rbPembelian1.Checked == true) _noTransBY = Numerator.NextNumber("NKB");

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Pembelian_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@NoFaktur", SqlDbType.VarChar, txtFaktur.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoTrans.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBeli", SqlDbType.DateTime, txtTglBeli.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Pembelian", SqlDbType.VarChar, _pembelian));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, lookUpVendor._vendor.RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, txtNopol.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, lookUpMotor._motor.RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.VarChar, numTahun.Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Warna", SqlDbType.VarChar, txtWarna.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, _kondisi));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRangka", SqlDbType.VarChar, txtNoRangka.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoMesin", SqlDbType.VarChar, txtNoMesin.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBPKB", SqlDbType.VarChar, txtNoBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBPKB", SqlDbType.VarChar, txtNamaBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@AlamatBPKB", SqlDbType.VarChar, txtAlamatBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaBPKB", SqlDbType.VarChar, cboKota.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganBPKB", SqlDbType.VarChar, txtKetBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@cekFisik", SqlDbType.Bit, _fisik));
                        db.Commands[0].Parameters.Add(new Parameter("@cekBPKB", SqlDbType.Bit, _bpkb));
                        db.Commands[0].Parameters.Add(new Parameter("@cekSTNK", SqlDbType.Bit, _stnk));
                        db.Commands[0].Parameters.Add(new Parameter("@cekManualBook", SqlDbType.Bit, _manual));
                        db.Commands[0].Parameters.Add(new Parameter("@cekKunciUtama", SqlDbType.Bit, _kontakut));
                        db.Commands[0].Parameters.Add(new Parameter("@cekKunciDuplikat", SqlDbType.Bit, _kontakcad));
                        db.Commands[0].Parameters.Add(new Parameter("@cekKunciPas", SqlDbType.Bit, _kuncipas));
                        db.Commands[0].Parameters.Add(new Parameter("@cekBukuServis", SqlDbType.Bit, _servis));
                        if (numKredit.Enabled == true) db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.DateTime, TglJT));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, txtHarga.Text));
                        if (txtUangMuka.Enabled == true) db.Commands[0].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, txtUangMuka.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, txtTotal.Text));
                        
                        /*
                        if (numKredit.Enabled == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, 0));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, txtHarga.Text));
                        }
                        */

                        if (rbAutomatic.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Transmisi", SqlDbType.VarChar, "AUTOMATIC"));
                        }
                        else if (rbManual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Transmisi", SqlDbType.VarChar, "MANUAL"));
                        }

                        if (numKredit.Enabled == true) db.Commands[0].Parameters.Add(new Parameter("@LamaKredit", SqlDbType.Int, numKredit.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].Parameters.Add(new Parameter("@JenisMotorID", SqlDbType.UniqueIdentifier, _rowIDHarga));
                        db.Commands[0].Parameters.Add(new Parameter("@HargaOTR", SqlDbType.Money, txtHargaOTR.GetDoubleValue));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Data berhasil ditambahkan");
                    this.Close();
                }
                else
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Pembelian_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@NoFaktur", SqlDbType.VarChar, txtFaktur.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoTrans.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBeli", SqlDbType.DateTime, txtTglBeli.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Pembelian", SqlDbType.VarChar, _pembelian));
                        if (lookUpVendor._vendor.RowID == Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, _vendorRowID));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, lookUpVendor._vendor.RowID));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, txtNopol.Text));
                        if (lookUpMotor._motor.RowID == Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, _typeRowID));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, lookUpMotor._motor.RowID));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.VarChar, numTahun.Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Warna", SqlDbType.VarChar, txtWarna.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, _kondisi));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRangka", SqlDbType.VarChar, txtNoRangka.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoMesin", SqlDbType.VarChar, txtNoMesin.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBPKB", SqlDbType.VarChar, txtNoBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBPKB", SqlDbType.VarChar, txtNamaBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@AlamatBPKB", SqlDbType.VarChar, txtAlamatBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaBPKB", SqlDbType.VarChar, cboKota.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganBPKB", SqlDbType.VarChar, txtKetBPKB.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@cekFisik", SqlDbType.Bit, _fisik));
                        db.Commands[0].Parameters.Add(new Parameter("@cekBPKB", SqlDbType.Bit, _bpkb));
                        db.Commands[0].Parameters.Add(new Parameter("@cekSTNK", SqlDbType.Bit, _stnk));
                        db.Commands[0].Parameters.Add(new Parameter("@cekManualBook", SqlDbType.Bit, _manual));
                        db.Commands[0].Parameters.Add(new Parameter("@cekKunciUtama", SqlDbType.Bit, _kontakut));
                        db.Commands[0].Parameters.Add(new Parameter("@cekKunciDuplikat", SqlDbType.Bit, _kontakcad));
                        db.Commands[0].Parameters.Add(new Parameter("@cekKunciPas", SqlDbType.Bit, _kuncipas));
                        db.Commands[0].Parameters.Add(new Parameter("@cekBukuServis", SqlDbType.Bit, _servis));
                        if (numKredit.Enabled == true) db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.DateTime, TglJT));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, txtHarga.Text));
                        if (txtUangMuka.Enabled == true) db.Commands[0].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, txtUangMuka.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, txtTotal.Text));
                        /*
                        if (numKredit.Enabled == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, 0));
                        }
                        else
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, txtHarga.Text));
                        }
                        */

                        if (rbAutomatic.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Transmisi", SqlDbType.VarChar, "AUTOMATIC"));
                        }
                        else if (rbManual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@Transmisi", SqlDbType.VarChar, "MANUAL"));
                        }

                        if (numKredit.Enabled == true) db.Commands[0].Parameters.Add(new Parameter("@LamaKredit", SqlDbType.Int, numKredit.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].Parameters.Add(new Parameter("@JenisMotorID", SqlDbType.UniqueIdentifier, _rowIDHarga));
                        db.Commands[0].Parameters.Add(new Parameter("@HargaOTR", SqlDbType.Money, txtHargaOTR.GetDoubleValue));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Data berhasil diupdate");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal disimpan !\n " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void numTahun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numKredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (txtHarga.GetIntValue).ToString();
        }

        private void frmPembelianUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Pembelian.frmPembelianBrowse)
            {
                Pembelian.frmPembelianBrowse frmCaller = (Pembelian.frmPembelianBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("NoFaktur", txtFaktur.Text);
            }
        }

        private void txtFaktur_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNoTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTglBeli_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtReferensi_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void rbPembelian1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpVendor.txtNamaVendor.Focus();
            }
        }

        private void rbPembelian2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpVendor.txtNamaVendor.Focus();
            }
        }

        private void lookUpVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void lookUpMotor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtWarna_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void numTahun_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }


        private void rbKondisi1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtNoRangka.Focus();
            }
        }

        private void rbKondisi2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtNoRangka.Focus();
            }
        }

        private void txtNoRangka_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtNoMesin.Focus();
            }
        }

        private void txtNoMesin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNoBPKB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNamaBPKB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtAlamatBPKB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboProvinsi_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKota_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtKetBPKB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMataUang_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }  

        private void txtHarga_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtUangMuka_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void numKredit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbFisik1.Focus();
            }
        }

        private void rbFisik1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbBPKB1.Focus();
            }
        }

        private void rbFisik2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbBPKB1.Focus();
            }
        }

        private void rbBPKB1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbSTNK1.Focus();
            }
        }

        private void rbBPKB2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbSTNK1.Focus();
            }
        }

        private void rbSTNK1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbKontakUt1.Focus();
            }
        }

        private void rbSTNK2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbKontakUt1.Focus();
            }
        }

        private void rbKontakUt1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbKontakCad1.Focus();
            }
        }

        private void rbKontakUt2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbKontakCad1.Focus();
            }
        }

        private void rbKontakCad1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbKunciPas1.Focus();
            }
        }

        private void rbKontakCad2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbKunciPas1.Focus();
            }
        }

        private void rbKunciPas1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbManual1.Focus();
            }
        } 

        private void rbKunciPas2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbManual1.Focus();
            }
        }

        private void rbManual1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbServis1.Focus();
            }
        }

        private void rbManual2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                rbServis1.Focus();
            }
        }

        private void rbServis1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cmdSAVE.Focus();
            }
        }

        private void rbServis2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cmdSAVE.Focus();
            }
        }

        private void lookUpVendor_Load(object sender, EventArgs e)
        {

        }


        
        
        private void txtNopol_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            } 
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtNopol_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNopol_Leave(object sender, EventArgs e)
        {
            if (rbKondisi1.Checked == true)
            {
            }
            else
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Check_NoPol_Pembelian_Unsold"));
                    db.Commands[0].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, txtNopol.Text.ToUpper()));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(Tools.isNull(dt.Rows[0]["jdata"].ToString(), "0")) > 0)
                        {
                            MessageBox.Show("Ada data motor dengan nomor polisi sama yg belum terjual!");
                            txtNopol.Focus();
                            return;
                        }
                        else
                        {
                        }
                    }
                }            
            txtNopol.Text = txtNopol.Text.ToUpper();
            txtNopol.Text = Regex.Replace( txtNopol.Text, " ", "");
            String strpattern = "^AD[0-9]{1,4}[A-Z]{1,3}$"; // diminta depannya selalu AD // sebelumnya "^[A-Z]{1,2}[0-9]{1,4}[A-Z]{1,3}$"
            if (GlobalVar.CabangID.Contains("06"))
            {
                strpattern = "^[A-Z]{1,2}[0-9]{1,4}[A-Z]{1,3}$";
            }
            Regex regex = new Regex(strpattern);
            if (regex.Match(txtNopol.Text).Success)
            {
                // passed
            }
            else
            {
                String strpattern2 = "^[A-Z]{1,2}[0-9]{1,4}[A-Z]{1,3}$"; // diminta depannya selalu AD // sebelumnya "^[A-Z]{1,2}[0-9]{1,4}[A-Z]{1,3}$"
                Regex regex2 = new Regex(strpattern2);
                if (regex2.Match(txtNopol.Text).Success)
                {
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.MotorNonAD), "Transaksi Motor Non AD!");
                    if (GlobalVar.pinResult == false)
                    {
                        MessageBox.Show("PIN Ditolak. Input No. Polisi tidak sesuai pola, isikan tanpa spasi dan diawali AD.");
                        txtNopol.Text = "";
                        txtNopol.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Input No. Polisi tidak sesuai pola, isikan tanpa spasi dan diawali AD.");
                    txtNopol.Focus();
                }
            }
        }
        }


        private void rbAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            urusTransmisi();
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            urusTransmisi();
        }

        private void urusTransmisi()
        {
            if (rbAutomatic.Checked == true)
            {
                rbAutomatic.Checked = true;
                rbManual.Checked = false;
            }
            else if (rbManual.Checked == true)
            {
                rbAutomatic.Checked = false;
                rbManual.Checked = true;
            }
        }

        private void cekHargaBeli()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_JenisKendaraan_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TypeID", SqlDbType.UniqueIdentifier, lookUpMotor._motor.RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    _hargabeli = Double.Parse(Tools.isNull(dt.Rows[0]["Harga"], "0").ToString());
                    _rowIDHarga = (Guid)Tools.isNull(dt.Rows[0]["IDHarga"], Guid.Empty);
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cekAppSetting()
        {
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "CEKHPP"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _cekharga = int.Parse(Tools.isNull(dt.Rows[0]["Value"], "0").ToString());
                }

            }
        }

        private void lookUpMotor_SelectData(object sender, EventArgs e)
        {
            Guid _typeID = (Guid)lookUpMotor._motor.RowID;

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_JenisKendaraan_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TypeID", SqlDbType.UniqueIdentifier, _typeID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    txtHargaOTR.Text = Tools.isNull(dt.Rows[0]["Harga"], "0").ToString();
                }
                else
                {
                    txtHargaOTR.Text = "0";
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
