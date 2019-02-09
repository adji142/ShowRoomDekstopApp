using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data.SqlTypes;
using System.Globalization;
using System.Transactions;
using System.Text.RegularExpressions;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPegadaianUpdate : ISA.Controls.BaseForm
    {
        enum FormMode { New, Update };
        FormMode mode = new FormMode();
        DateTime TglAwalAngs;
        DateTime TglAkhirAngs;

        Guid _penjualanRowID;
        Guid _pegadaianRowID;
        Guid _pengeluaranUangRowID = Guid.NewGuid(); // ini untuk yg Pinjaman Fisik itu

        // punya penjualan
        Guid _pembRowID, _custRowID, _salesRowID, _kolRowID, _leasingRowID;
        string _pejualan = "";
        bool isCetak1 = false;
        bool isCetak2 = false;
        bool isCetak3 = false;
        bool isCetak4 = false;
        bool isCetak5 = false;
        bool isCetak6 = false;
        bool isCetak7 = false;
        bool isCetak8 = false;
        
        // punya yang pembelian
        Guid _vendorRowID, _typeRowID;
        DateTime TglJT;
        string _pembelian = "";
        string _kondisi = "";
        bool _fisik = false;
        bool _bpkb = false;

        public frmPegadaianUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.New;
            _penjualanRowID = Guid.NewGuid();
            _pegadaianRowID = Guid.NewGuid();
        }

        public frmPegadaianUpdate(Form caller, Guid pegadaianRowID, Guid penjualanRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.Update;
            _penjualanRowID = penjualanRowID;
            _pegadaianRowID = pegadaianRowID;
        }

        // fungsi2 punya penjualan
        private void ListAngsuran() // selalu kredit
        {
            cboJnsAngsuran.DisplayMember = "Text";
            cboJnsAngsuran.ValueMember = "Value";
            var items = new[] 
                {
                    new { Text = "BUNGA MENURUN", Value = "APD" },
                    new { Text = "BUNGA TETAP / FLAT", Value = "FLT" }
                };
            cboJnsAngsuran.DataSource = items;
        }

        private void ListPembulatan()
        {
            cboPembulatan.DisplayMember = "Text";
            cboPembulatan.ValueMember = "Value";
            var items = new[] {
                new { Text = "0", Value = "0" },
                new { Text = "50", Value = "50" },
                new { Text = "100", Value = "100" }
            };
            cboPembulatan.DataSource = items;
        }
        // akhir fungsi2 punya penjualan

        private void frmPegadaianUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                // dari yang penjualan
                DataTable dt = FillComboBox.DBGetMataUang(Guid.Empty, "");
                dt.DefaultView.Sort = "MataUangID ASC";
                cboMataUang.DisplayMember = "MataUangID";
                cboMataUang.ValueMember = "MataUangID";
                cboMataUang.DataSource = dt.DefaultView;

                this.ListPembulatan();

                // dari yang pembelian
                this.Cursor = Cursors.WaitCursor;
                dt = FillComboBox.DBGetProvinsi(Guid.Empty);
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

                if (mode == FormMode.New)
                {
                    // dari yang penjualan
                    txtTglJual.DateValue = GlobalVar.GetServerDate;
                    rbPenjualan2.Checked = true;
                    lookUpCustomer1.txtNamaCustomer.Text = "";
                    lookUpKolektor1.txtNamaKolektor.Text = "";
                    lookUpSalesman1.txtNamaSales.Text = "";
                    this.ListAngsuran();
                    txtVia.Text = "";
                    
                    txtBBN.Text = "0";
                    txtBiayaADM.Text = "0";
                    txtUangMuka.Text = "";
                    txtBunga.Text = "0.00";
                    numKredit.Value = 0;
                    txtTotal.Text = "0";
                    txtTglAwalAngs.Text = "";
                    txtKeterangan.Text = "";
                    txtBunga.ReadOnly = true;
                    cboPembulatan.Enabled = false;
                    cboJnsAngsuran.SelectedValue = "APD";
                    txtUangMuka.ReadOnly = false;
                    numKredit.ReadOnly = false;
                    txtTglAwalAngs.ReadOnly = false;
                    txtBunga.Text = "3.00";

                    // dari yang pembelian
                    txtReferensi.Text = "";
                    lookUpMotor.txtNamaMotor.Text = "";
                    txtWarna.Text = "";
                    numTahun.Value = GlobalVar.GetServerDate.Year;
                    txtNopol.Text = "";
                    rbKondisi1.Checked = true;
                    txtNoRangka.Text = "";
                    txtNoMesin.Text = "";
                    txtNoBPKB.Text = "";
                    txtNamaBPKB.Text = "";
                    txtAlamatBPKB.Text = "";
                    txtKetBPKB.Text = "";

                    txtEstimasi.Text = "0";
                    txtPinjaman.Text = "0";

                    //untuk yang provinsibpkb
                    // ambil dari app setting
                    DataTable dummyPR = new DataTable();
                    using(Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PROVPEMILIKBPKB"));
                        dummyPR = db.Commands[0].ExecuteDataTable();
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
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = db.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }

                }
                else
                {
                    // punya penjualan
                    DataTable _dtc = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_Pegadaian_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjualanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@PegadaianRowID", SqlDbType.UniqueIdentifier, _pegadaianRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                        _dtc = db.Commands[0].ExecuteDataTable();
                    }
                    txtFaktur.Text = Tools.isNull(_dtc.Rows[0]["NoBukti"], "").ToString();
                    txtNoNota.Text = Tools.isNull(_dtc.Rows[0]["NoTrans"], "").ToString();
                    txtTglJual.DateValue = (DateTime)Tools.isNull(_dtc.Rows[0]["TglJual"], DateTime.MinValue);

                    // hanya bisa kredit
                    {
                        rbPenjualan2.Checked = true;
                        this.ListAngsuran();
                        txtUangMuka.ReadOnly = false;
                        numKredit.ReadOnly = false;
                        txtBunga.ReadOnly = true;
                        cboPembulatan.Enabled = true;
                        txtTglAwalAngs.ReadOnly = false;
                    }

                    _pembRowID = (Guid)Tools.isNull(_dtc.Rows[0]["PembRowID"], _pegadaianRowID);
                    _custRowID = (Guid)Tools.isNull(_dtc.Rows[0]["CustRowId"], Guid.Empty);
                    lookUpCustomer1.txtNamaCustomer.Text = Tools.isNull(_dtc.Rows[0]["Customer"], "").ToString();
                    _salesRowID = (Guid)Tools.isNull(_dtc.Rows[0]["SalesRowID"], Guid.Empty);
                    lookUpSalesman1.txtNamaSales.Text = Tools.isNull(_dtc.Rows[0]["Sales"], "").ToString();
                    _kolRowID = (Guid)Tools.isNull(_dtc.Rows[0]["KolektorRowID"], Guid.Empty);
                    lookUpKolektor1.txtNamaKolektor.Text = Tools.isNull(_dtc.Rows[0]["Kolektor"], "").ToString();

                    switch (Tools.isNull(_dtc.Rows[0]["KodeTrans"], "").ToString())
                    {
                        case "APD":
                            cboJnsAngsuran.Text = "Bunga Menurun";
                            break;
                        case "FLT":
                            cboJnsAngsuran.Text = "Bunga Tetap / Flat";
                            break;
                    }
                    cboPembulatan.Text = Tools.isNull(_dtc.Rows[0]["Pembulatan"], "").ToString();
                    txtVia.Text = Tools.isNull(_dtc.Rows[0]["Via"], "").ToString();
                    cboMataUang.Text = Tools.isNull(_dtc.Rows[0]["MataUangID"], "").ToString();

                    txtHarga.Text = Tools.isNull(_dtc.Rows[0]["HargaJadi"], "0").ToString();
                    txtBBN.Text = Tools.isNull(_dtc.Rows[0]["BBN"], "0").ToString();
                    txtBiayaADM.Text = Tools.isNull(_dtc.Rows[0]["BiayaADM"], "0").ToString();
                    txtUangMuka.Text = Tools.isNull(_dtc.Rows[0]["UangMuka"], "0").ToString();
                    numKredit.Value = int.Parse(Tools.isNull(_dtc.Rows[0]["TempoAngsuran"], "0").ToString());
                    txtKeterangan.Text = Tools.isNull(_dtc.Rows[0]["Keterangan"], "").ToString();
                    if (string.IsNullOrEmpty(_dtc.Rows[0]["TglAwalAngs"].ToString())) { txtTglAwalAngs.Text = ""; }
                    else { txtTglAwalAngs.DateValue = (DateTime)Tools.isNull(_dtc.Rows[0]["TglAwalAngs"], DateTime.MinValue); }
                    txtBunga.Text = Tools.isNull(_dtc.Rows[0]["Bunga"], "").ToString();
                    txtTotal.Text = Tools.isNull(_dtc.Rows[0]["HargaOff"], "").ToString();
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak1"], 0)) > 0)
                    {
                        isCetak1 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak2"], 0)) > 0)
                    {
                        isCetak2 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak3"], 0)) > 0)
                    {
                        isCetak3 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak4"], 0)) > 0)
                    {
                        isCetak4 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak5"], 0)) > 0)
                    {
                        isCetak5 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak6"], 0)) > 0)
                    {
                        isCetak6 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak7"], 0)) > 0)
                    {
                        isCetak7 = true;
                    }
                    if (Convert.ToDouble(Tools.isNull(_dtc.Rows[0]["Cetak8"], 0)) > 0)
                    {
                        isCetak8 = true;
                    }

                    // dari yang pegadaian -- pembelian

                    txtReferensi.Text = Tools.isNull(_dtc.Rows[0]["Referensi"], "").ToString();

                    _typeRowID = (Guid)Tools.isNull(_dtc.Rows[0]["TypeRowID"], Guid.Empty);
                    
                    DataTable dtType = FillComboBox.DBGetMotor(Guid.Empty, _typeRowID, "", "");
                    lookUpMotor.txtNamaMotor.Text = Tools.isNull(dtType.Rows[0]["Type"], "").ToString();
                    
                    txtWarna.Text = Tools.isNull(_dtc.Rows[0]["Warna"], "").ToString();
                    numTahun.Value = int.Parse(Tools.isNull(_dtc.Rows[0]["Tahun"], "").ToString());
                    txtNopol.Text = Tools.isNull(_dtc.Rows[0]["Nopol"], "").ToString();

                    if (Tools.isNull(_dtc.Rows[0]["Kondisi"], "").ToString() == "Baru") rbKondisi1.Checked = true;
                    else rbKondisi2.Checked = true;

                    txtNoRangka.Text = Tools.isNull(_dtc.Rows[0]["NoRangka"], "").ToString();
                    txtNoMesin.Text = Tools.isNull(_dtc.Rows[0]["NoMesin"], "").ToString();
                    txtNoBPKB.Text = Tools.isNull(_dtc.Rows[0]["NoBPKB"], "").ToString();
                    txtNamaBPKB.Text = Tools.isNull(_dtc.Rows[0]["NamaBPKB"], "").ToString();
                    txtAlamatBPKB.Text = Tools.isNull(_dtc.Rows[0]["AlamatBPKB"], "").ToString();
                    DataTable dtState = FillComboBox.DBGetStateAll(Guid.Empty, "", Guid.Empty, Tools.isNull(_dtc.Rows[0]["KotaBPKB"], "").ToString(), Guid.Empty, "", Guid.Empty, "");
                    cboProvinsi.Text = Tools.isNull(dtState.Rows[0]["Provinsi"], "").ToString();
                    cboKota.Text = Tools.isNull(_dtc.Rows[0]["KotaBPKB"], "").ToString();
                    txtKetBPKB.Text = Tools.isNull(_dtc.Rows[0]["KeteranganBPKB"], "").ToString();

                    txtPinjaman.Text = Tools.isNull(_dtc.Rows[0]["PinjamanFisik"], 0).ToString();
                    txtEstimasi.Text = Tools.isNull(_dtc.Rows[0]["HargaEstimasiMotor"], 0).ToString();
                    _pengeluaranUangRowID = new Guid(Tools.isNull(_dtc.Rows[0]["PengeluaranUangRowID"], Guid.Empty).ToString());

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

        #region Penjualan_Event
            private void cboJnsAngsuran_SelectedIndexChanged(object sender, EventArgs e)
            {
                switch (cboJnsAngsuran.SelectedValue.ToString())
                {
                    case "APD":
                        txtUangMuka.ReadOnly = false;
                        numKredit.ReadOnly = false;
                        txtTglAwalAngs.ReadOnly = false;
                        txtBunga.Text = "3.00";
                        break;
                    case "FLT":
                        txtUangMuka.ReadOnly = false;
                        numKredit.ReadOnly = false;
                        txtTglAwalAngs.ReadOnly = false;
                        txtBunga.Text = "2.00";
                        break;
                }
            }

            private void numKredit_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            /*
            private void txtHarga_TextChanged(object sender, EventArgs e)
            {
                txtTotal.Text = (txtHarga.GetIntValue + txtBBN.GetIntValue + txtBiayaADM.GetIntValue).ToString();
            }

            private void txtBBN_TextChanged(object sender, EventArgs e)
            {
                txtTotal.Text = (txtHarga.GetIntValue + txtBBN.GetIntValue + txtBiayaADM.GetIntValue).ToString();
            }

            private void txtBiayaADM_TextChanged(object sender, EventArgs e)
            {
                txtTotal.Text = (txtHarga.GetIntValue + txtBBN.GetIntValue + txtBiayaADM.GetIntValue).ToString();
            }
            */
            private void txtTglJual_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }

            private void rbPenjualan2_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    lookUpCustomer1.txtNamaCustomer.Focus();
                }
            }

            private void lookUpCustomer1_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    lookUpSalesman1.txtNamaSales.Focus();
                }
            }

            private void lookUpSalesman1_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    lookUpKolektor1.txtNamaKolektor.Focus();
                }
            }

            private void lookUpKolektor1_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    cboJnsAngsuran.Focus();
                }
            }

            private void cboJnsAngsuran_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }

            private void cboLeasing_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }

            private void txtVia_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    txtKeterangan.Focus();
                }
            }

            private void txtKeterangan_KeyDown(object sender, KeyEventArgs e)
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

            private void txtBBN_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }

            private void txtBiayaADM_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    txtTglAwalAngs.Focus();
                }
            }

            private void txtTglAwalAngs_KeyDown(object sender, KeyEventArgs e)
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

            private void txtBunga_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }

            private void cboPembulatan_KeyDown(object sender, KeyEventArgs e)
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
                    SendKeys.Send("{TAB}");
                }
            }

            private void txtBunga_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                if (txtBunga.ReadOnly == true)
                {
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.BungaAngsuran), "Bunga Angsuran.\nAnda membutuhkan PIN untuk merubah Bunga Angsuran !");
                    if (GlobalVar.pinResult == false) { return; }
                }

                txtBunga.ReadOnly = false;
            }
        #endregion

        #region Pegadaian_Event
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
            private void txtReferensi_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }
            private void rbPembelian2_KeyDown(object sender, KeyEventArgs e)
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


            private void txtNopol_Leave(object sender, EventArgs e)
            {
                txtNopol.Text = txtNopol.Text.ToUpper();
                txtNopol.Text = Regex.Replace(txtNopol.Text, " ", "");
                String strpattern = "^AD[0-9]{1,4}[A-Z]{1,3}$"; // diminta depannya selalu AD // sebelumnya "^[A-Z]{1,2}[0-9]{1,4}[A-Z]{1,3}$"
                Regex regex = new Regex(strpattern);
                if (regex.Match(txtNopol.Text).Success)
                {
                    // passed
                }
                else
                {
                    MessageBox.Show("Input No. Polisi tidak sesuai pola, isikan tanpa spasi dan diawali AD.");
                    txtNopol.Focus();
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
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Tab) )
                {
                    tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                    txtNoBPKB.Focus();
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
        #endregion

            private bool ValidateSave()
            {
                // validasi penjualan
                if (string.IsNullOrEmpty(txtTglJual.Text))
                {
                    MessageBox.Show("Tanggal Penjualan belum diisi !");
                    txtTglJual.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTglAwalAngs.Text))
                {
                    MessageBox.Show("Tanggal Awal Angsuran belum diisi !");
                    txtTglJual.Focus();
                    return false;
                }
                if (Convert.ToDouble(Tools.isNull(txtHarga.Text, 0)) == 0)
                {
                    MessageBox.Show("Harga Jual tidak boleh 0 (nol) !");
                    txtHarga.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(txtBBN.Text))
                {
                    MessageBox.Show("Bea Balik Nama belum diisi !\nIsikan 0 (nol) bila tidak ada Bea Balik Nama.");
                    txtBBN.Focus();
                    return false;
                }
                if (String.IsNullOrEmpty(txtBiayaADM.Text))
                {
                    MessageBox.Show("Biaya Administrasi belum diisi !\nIsikan 0 (nol) bila tidak ada Biaya Administrasi.");
                    txtBiayaADM.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(lookUpCustomer1.txtNamaCustomer.Text) || lookUpCustomer1._customer.RowID == null || lookUpCustomer1._customer.RowID == Guid.Empty)
                {
                    MessageBox.Show("Pelanggan belum diisi !");
                    lookUpCustomer1.txtNamaCustomer.Focus();
                    return false;
                }
                if (lookUpKolektor1._Kolektor.RowID == null || lookUpKolektor1._Kolektor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Kolektor belum diisi !");
                    lookUpKolektor1.Focus();
                    return false;
                }
                if (lookUpSalesman1._sales.RowID == null || lookUpSalesman1._sales.RowID == Guid.Empty)
                {
                    MessageBox.Show("Salesman belum diisi !");
                    lookUpKolektor1.Focus();
                    return false;
                }

                // mulai pengecekan customer ada berapa transaksi yg berjalan
                DataTable dtsub = new DataTable();
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_CekNumTransaksiBerjalanCustomer"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                    dtsub = dbsub.Commands[0].ExecuteDataTable();
                }
                if (dtsub.Rows.Count > 0)
                {
                    int ygtunai = Convert.ToInt32(dtsub.Rows[0]["TunaiBerjalan"].ToString());
                    int ygkredit = Convert.ToInt32(dtsub.Rows[0]["KreditBerjalan"].ToString());
                    // kalo ada data cek yg kredit ada berapa yg berjalan, yg tunai ada berapa
                    if (ygkredit >= 2) // kalo yg berjalan kreditnya itu ada 2 atau lebih
                    {
                        if (rbPenjualan2.Checked == true) // dan masih mau kredit lagi
                        {
                            MessageBox.Show("Masih ada 2 proses kredit yang masih berjalan, tidak dapat melakukan transaksi Pegadaian!");
                            lookUpCustomer1.Focus();
                            return false;
                        }
                    }
                }
                // akhir pengecekan customer ada berapa transaksi yg berjalan

                if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) == 0))
                {
                    MessageBox.Show("Bunga tidak boleh 0 (nol) !");
                    txtBunga.Focus();
                    return false;
                }
                if (rbPenjualan2.Checked == true)
                {
                    if (cboJnsAngsuran.SelectedValue.ToString() == "APD" && numKredit.Value > 12)
                    {
                        MessageBox.Show("Bunga menurun maksimal tempo hanya 12 bln");
                        numKredit.Focus();
                        return false;
                    }
                    else if (cboJnsAngsuran.SelectedValue.ToString() == "FLT" && numKredit.Value > 24)
                    {
                        MessageBox.Show("Bunga menurun maksimal tempo hanya 24 bln");
                        numKredit.Focus();
                        return false;
                    }
                }
                if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 100))
                {
                    MessageBox.Show("Bunga tidak boleh lebih dari 100 !");
                    txtBunga.Focus();
                    return false;
                }
                if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtUangMuka.Text, 0)) > Convert.ToDouble(Tools.isNull(txtTotal.Text, 0))))
                {
                    MessageBox.Show("Uang Muka lebih besar dari pada harga total kesepakatan !");
                    txtUangMuka.Focus();
                    return false;
                }
                if ((rbPenjualan2.Checked == true) && (txtTglAwalAngs.DateValue < txtTglJual.DateValue))
                {
                    MessageBox.Show("Tanggal Awal Angsuran lebih kecil dari pada Tanggal Penjualan !");
                    txtTglAwalAngs.Focus();
                    return false;
                }
                if (((DateTime)txtTglJual.DateValue).Date < GlobalVar.GetServerDate.Date)
                {
                    MessageBox.Show("Tanggal Penjualan lebih kecil dari pada Tanggal Sekarang !");
                    txtTglJual.Focus();
                    return false;
                }

                if (rbPenjualan2.Checked == true)
                {
                    _pejualan = "K";
                    int jmlKredit = int.Parse(numKredit.Value.ToString());
                    TglAwalAngs = (DateTime)txtTglAwalAngs.DateValue;
                    TglAkhirAngs = TglAwalAngs.AddMonths(jmlKredit);
                }

                // validasi pembelian
                if (string.IsNullOrEmpty(lookUpMotor.txtNamaMotor.Text) || lookUpMotor._motor.RowID == null || lookUpMotor._motor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Merk / Type Motor belum dipilih !");
                    lookUpMotor.txtNamaMotor.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtWarna.Text))
                {
                    MessageBox.Show("Warna belum diisi !");
                    txtWarna.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(numTahun.Value.ToString()))
                {
                    MessageBox.Show("Tahun Pembuatan belum diisi !");
                    numTahun.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNopol.Text))
                {
                    MessageBox.Show("Nomor Polisi belum diisi !");
                    txtNopol.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNoRangka.Text))
                {
                    MessageBox.Show("Nomor Rangka belum diisi !");
                    txtNoRangka.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNoMesin.Text))
                {
                    MessageBox.Show("Nomor Mesin belum diisi !");
                    txtNoMesin.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNoBPKB.Text))
                {
                    MessageBox.Show("Nomor BPKB belum diisi !");
                    txtNoBPKB.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNamaBPKB.Text))
                {
                    MessageBox.Show("Nama Pemilik BPKB belum diisi !");
                    txtNamaBPKB.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtAlamatBPKB.Text))
                {
                    MessageBox.Show("Alamat Pemilik BPKB belum diisi !");
                    txtAlamatBPKB.Focus();
                    return false;
                }
                if (rbKondisi1.Checked == true)
                {
                    _kondisi = rbKondisi1.Text;
                }
                else
                {
                    _kondisi = rbKondisi2.Text;
                }

                if (mode == FormMode.Update)
                {
                    if ((isCetak1 == true) || (isCetak2 == true) || (isCetak3 == true) || (isCetak4 == true) ||
                    (isCetak5 == true) || (isCetak6 == true) || (isCetak7 == true) || (isCetak8 == true))
                    {
                        MessageBox.Show("Sudah dilakukan pencetakan tidak diperkenankan diupdate !");
                        return false;
                    }
                }

                // cek pinjaman fisik sama herga estimasi motor
                if (Convert.ToDouble(Tools.isNull(txtPinjaman.Text, 0).ToString()) < 0)
                {
                    MessageBox.Show("Nominal Pinjaman Fisik tidak boleh di bawah 0!");
                    return false;
                }
                
                if (Convert.ToDouble(Tools.isNull(txtEstimasi.Text, 0).ToString()) < 0)
                {
                    MessageBox.Show("Harga Estimasi motor tidak boleh di bawah 0 !");
                    return false;
                }

                return true;
            }

            private void PenjualanInsert(ref Database db, ref int counterdb)
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_INSERT"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjualanRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _pegadaianRowID));  // di pegadaian pembelian row idnya itu rowidnya pegadaian
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoNota.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtFaktur.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, txtTglJual.DateValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, lookUpSalesman1._sales.RowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, _pejualan));
                db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, txtHarga.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@BBN", SqlDbType.Money, txtBBN.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaADM", SqlDbType.Money, txtBiayaADM.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, txtTotal.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Via", SqlDbType.VarChar, txtVia.Text));

                if (txtTglAwalAngs.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Int, Convert.ToInt32(txtTglAwalAngs.Text.ToString().Substring(0, 2))));

                if (txtUangMuka.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, txtUangMuka.Text));

                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga.Text)));

                if (cboPembulatan.Enabled == true)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.Text)));

                if (numKredit.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, numKredit.Value));

                if (txtTglAwalAngs.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngs.DateValue));

                if (txtTglAwalAngs.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, TglAkhirAngs));

                db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, txtKeterangan.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                counterdb++;
            }

            private void PegadaianInsert(ref Database db, ref int counterdb, Guid PengeluaranUangRowID)
            {
                db.Commands.Add(db.CreateCommand("usp_Pegadaian_INSERT"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _pegadaianRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjualanRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoPol", SqlDbType.VarChar, txtNopol.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, lookUpMotor._motor.RowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Tahun", SqlDbType.VarChar, numTahun.Value.ToString()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Warna", SqlDbType.VarChar, txtWarna.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, _kondisi));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoRangka", SqlDbType.VarChar, txtNoRangka.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoMesin", SqlDbType.VarChar, txtNoMesin.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoBPKB", SqlDbType.VarChar, txtNoBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NamaBPKB", SqlDbType.VarChar, txtNamaBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@AlamatBPKB", SqlDbType.VarChar, txtAlamatBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@ProvinsiBPKB", SqlDbType.UniqueIdentifier, (Guid)cboProvinsi.SelectedValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KotaBPKB", SqlDbType.VarChar, cboKota.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganBPKB", SqlDbType.VarChar, txtKetBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                // untuk yang pinjaman fisik, harga estimasi motor
                db.Commands[counterdb].Parameters.Add(new Parameter("@PinjamanFisik", SqlDbType.Money, Tools.isNull(txtPinjaman.GetDoubleValue, 0)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@HargaEstimasiMotor", SqlDbType.Money, Tools.isNull(txtEstimasi.GetDoubleValue, 0)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
                
                counterdb++;

            }

            private void PenjualanUpdate(ref Database db, ref int counterdb)
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjualanRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _pegadaianRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoNota.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtFaktur.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, txtTglJual.DateValue));
                if ((!string.IsNullOrEmpty(lookUpCustomer1.txtNamaCustomer.Text)) && (lookUpCustomer1._customer.RowID == Guid.Empty))
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, _custRowID));
                }
                else
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                }
                if ((!string.IsNullOrEmpty(lookUpSalesman1.txtNamaSales.Text)) && (lookUpSalesman1._sales.RowID == Guid.Empty))
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, _salesRowID));
                }
                else
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, lookUpSalesman1._sales.RowID));
                }
                if ((!string.IsNullOrEmpty(lookUpKolektor1.txtNamaKolektor.Text)) && (lookUpKolektor1._Kolektor.RowID == Guid.Empty))
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, _kolRowID));
                }
                else
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
                }
                db.Commands[counterdb].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, _pejualan));
                db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, txtHarga.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@BBN", SqlDbType.Money, txtBBN.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaADM", SqlDbType.Money, txtBiayaADM.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, txtTotal.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Via", SqlDbType.VarChar, txtVia.Text));

                if (txtTglAwalAngs.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Int, Convert.ToInt32(txtTglAwalAngs.Text.ToString().Substring(0, 2))));
                if (txtUangMuka.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, txtUangMuka.Text));

                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga.Text)));

                if (cboPembulatan.Enabled == true)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.Text)));
                if (numKredit.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, numKredit.Value));
                if (txtTglAwalAngs.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngs.DateValue));
                if (txtTglAwalAngs.ReadOnly == false)
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, TglAkhirAngs));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, txtKeterangan.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                counterdb++;
            }

            private void PegadaianUpdate(ref Database db, ref int counterdb, Guid PengeluaranUangRowID)
            {
                db.Commands.Add(db.CreateCommand("usp_Pegadaian_UPDATE"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _pegadaianRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjualanRowID));

                db.Commands[counterdb].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, txtNopol.Text));
                if (lookUpMotor._motor.RowID == Guid.Empty)
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, _typeRowID));
                }
                else
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, lookUpMotor._motor.RowID));
                }
                db.Commands[counterdb].Parameters.Add(new Parameter("@Tahun", SqlDbType.VarChar, numTahun.Value.ToString()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Warna", SqlDbType.VarChar, txtWarna.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, _kondisi));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoRangka", SqlDbType.VarChar, txtNoRangka.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoMesin", SqlDbType.VarChar, txtNoMesin.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoBPKB", SqlDbType.VarChar, txtNoBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NamaBPKB", SqlDbType.VarChar, txtNamaBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@AlamatBPKB", SqlDbType.VarChar, txtAlamatBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@ProvinsiBPKB", SqlDbType.UniqueIdentifier, (Guid)cboProvinsi.SelectedValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KotaBPKB", SqlDbType.VarChar, cboKota.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganBPKB", SqlDbType.VarChar, txtKetBPKB.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                // untuk yang pinjaman fisik, harga estimasi motor
                db.Commands[counterdb].Parameters.Add(new Parameter("@PinjamanFisik", SqlDbType.Money, Tools.isNull(txtPinjaman.GetDoubleValue, 0)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@HargaEstimasiMotor", SqlDbType.Money, Tools.isNull(txtEstimasi.GetDoubleValue, 0)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
                
                counterdb++;
            }


            // untuk memasukkan data pinjaman fisik, dianggap tunai !!!
            private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran)
            {
                Guid _JnsTransaksiRowID = Guid.Empty, _MataUangRowID = Guid.Empty;
                // [usp_MataUang_LIST] @MataUangID varchar 3
                using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
                {
                    DataTable dtfsub = new DataTable();
                    dbfsub.Commands.Add(dbfsub.CreateCommand("usp_MataUang_LIST"));
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                    dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                    _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
                }
                // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
                using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
                {
                    DataTable dtfsub = new DataTable();
                    dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PinjamanFisik).ToString()));  // Pinjaman Fisik, !!! ubah nanti jnstransaksinya, masih ngarah ke 31
                    dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                    _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
                }
                dbf.Commands.Add(dbf.CreateCommand("usp_PengeluaranUang_INSERT_SIMPLE"));

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.GetServerDate)); // tglrk.DateValue 
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate)); // txtTanggal.DateValue
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, string.Empty)); // txtNoAcc.Text
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, string.Empty)); // txtNoApproval1.Text

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPengeluaran)); // mestinya pake numerator

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, DBNull.Value)); // vendor rowid saat pengeluaran Komisi dibuat null saja
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));  //  31-Biaya Kantor dan PJ Lainnya dulu...
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Tools.isNull(txtPinjaman.GetDoubleValue, 0) ));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Tools.isNull(txtPinjaman.GetDoubleValue, 0) ));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, " Pinjaman Fisik untuk Pegadaian | " + lookUpCustomer1._customer.NamaCustomer.Trim() + " | " + txtNopol.Text.Trim() ));

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9)); // defaultin 9

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukPengeluaran)); // mestinya selalu 'K'
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty)); // kosongin // aman untuk jurnal pengeluaran

                /*
                if (cbxBentukPembayaran.SelectedIndex == 0) // kalo tunai baru kas rowid
                {*/
                // harusnya selalu kas
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // dari globalvar
                /*
                }
                else if (cbxBentukPembayaran.SelectedIndex == 1) // kalo transfer baru rekening rowid
                {
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (Guid)Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty)));
                }*/

                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2)); // defaultin ke 2 (ke perusahaan)
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                counterdbf++;
            }
            
               
            private void PegadaianPinjamanFisikUpdate(ref Database db, ref int counterdb)
            {
                db.Commands.Add(db.CreateCommand("usp_Pegadaian_UPDATE_PinjamanFisik"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PegadaianRowID", SqlDbType.UniqueIdentifier, (Guid) _pegadaianRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PinjamanFisik", SqlDbType.Money, Tools.isNull(txtPinjaman.GetDoubleValue, 0)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.Int, 1 )); // 1 itu kas // Bentuk Pembayarannya (cbxBentukPembayaran.SelectedIndex + 1)
                db.Commands[counterdb].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, "K" )); // selalu 'K' JnsPengeluaran
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                counterdb++;
            }
            

            //penjualan
            private void cmdSAVE_Click(object sender, EventArgs e)
            {
                Database db = new Database();
                Database dbf = new Database(GlobalVar.DBFinanceOto);
                int counterdb = 0;
                int counterdbf = 0;

                try
                {
                    if (ValidateSave())
                    {
                    }
                    else
                    {
                        return;
                    }

                    this.Cursor = Cursors.WaitCursor;
                    switch (mode)
                    {
                        case FormMode.New:
                            // dari yang penjualan punya
                            txtFaktur.Text = Numerator.NextNumber("NFJ");
                            txtNoNota.Text = Numerator.NextNumber("NNJ");
                            PenjualanInsert(ref db, ref counterdb);
                            // pegadaian
                            // masukkin data pengeluaran uang untuk pinjaman fisik
                            PegadaianInsert(ref db, ref counterdb, _pengeluaranUangRowID);
                            // kalau pinjaman fisik dianggap kas terus
                            String tempBentukPengeluaran = "K";
                            // di bawah ini itu ngebentuk Bukti Uang Keluar untuk pinjaman fisik!!!
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPengeluaran + "K/" +
                                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 
                            // mestinya buat 
                            pengeluaranUangInsert(ref dbf, ref counterdbf, _pengeluaranUangRowID, tempBentukPengeluaran, NoTransPengeluaran);
                            break;

                        case FormMode.Update:
                            // dari yang penjualan 
                            PenjualanUpdate(ref db, ref counterdb);
                            // pegadaian
                            PegadaianUpdate(ref db, ref counterdb, _pengeluaranUangRowID);
                            // update data pengeluaran uangnya
                            PegadaianPinjamanFisikUpdate(ref db, ref counterdb);
                            break;
                    }

                    db.BeginTransaction();
                    dbf.BeginTransaction();
                    int looper = 0;
                    for (looper = 0; looper < counterdb; looper++)
                    {
                        db.Commands[looper].ExecuteNonQuery();
                    }
                    for (looper = 0; looper < counterdbf; looper++)
                    {
                        dbf.Commands[looper].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                    dbf.CommitTransaction();
                    MessageBox.Show("Data berhasil diproses.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    dbf.RollbackTransaction();
                    MessageBox.Show("Data gagal diupdate !\n" + ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }

            private void frmPegadaianUpdate_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (this.Caller is Penjualan.frmPegadaianBrowse)
                {
                    Penjualan.frmPegadaianBrowse frmCaller = (Penjualan.frmPegadaianBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("NoBukti", txtFaktur.Text);
                }
            }

            private void cmdCLOSE_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void numKredit_KeyDown_1(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Tab))
                {
                    //SendKeys.Send("{TAB}"); 
                    tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                    txtReferensi.Focus();
                }
            }

            private void txtHarga_Validated(object sender, EventArgs e)
            {
                txtTotal.Text = (txtHarga.GetDoubleValue + txtBBN.GetDoubleValue + txtBiayaADM.GetDoubleValue).ToString();
            }
            private void txtBBN_Validated(object sender, EventArgs e)
            {
                txtTotal.Text = (txtHarga.GetDoubleValue + txtBBN.GetDoubleValue + txtBiayaADM.GetDoubleValue).ToString();
            }

            private void txtBiayaADM_Validated(object sender, EventArgs e)
            {
                txtTotal.Text = (txtHarga.GetDoubleValue + txtBBN.GetDoubleValue + txtBiayaADM.GetDoubleValue).ToString();
            }

            private void lookUpMotor_Load(object sender, EventArgs e)
            {

            }

            private void cmdUbahBunga_Click(object sender, EventArgs e)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                if (txtBunga.ReadOnly == true)
                {
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang,
                                Convert.ToInt32(PinId.ModulId.BungaAngsuran),
                                "Bunga Angsuran.\nAnda membutuhkan PIN untuk merubah Bunga Angsuran !", _penjualanRowID);

                    if (GlobalVar.pinResult == false) { return; }
                }
                txtBunga.Enabled = true;
                txtBunga.ReadOnly = false;
                txtBunga.Focus();
            }

            private void txtBunga_Leave(object sender, EventArgs e)
            {
                txtBunga.Enabled = false;
                txtBunga.ReadOnly = true;
                if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 100)
                {
                    txtBunga.Text = "100.00";
                }
                if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) < 0)
                {
                    txtBunga.Text = "0.00";
                }
            }

            private void lookUpCustomer1_Leave(object sender, EventArgs e)
            {
                if (lookUpCustomer1._customer.RowID == null || lookUpCustomer1._customer.RowID == Guid.Empty)
                {
                    MessageBox.Show("Data Pelanggan masih belum terpilih!");
                }
            }

        // bagian tambahan untuk perhitungan sisa pokok, jml angsuran dan bunga

            private void urusSisaPokok()
            {
                // dari sp nya
                // (ISNULL(@HargaJadi,0) + ISNULL(@BBN,0)) - ISNULL(@UangMuka,0) -> ini itu piutang pokok
                // (txtHarga + txtBBN) - txtUangMuka
                bool tempresult = false;
                double tempdump = 0;
                double temphargajadi;
                double tempBBN;
                double tempUM;

                tempresult = Double.TryParse(txtHarga.Text, out tempdump);
                if (tempresult)
                {
                    temphargajadi = tempdump;
                }
                else
                {
                    temphargajadi = 0;
                }
                tempresult = Double.TryParse(txtBBN.Text, out tempdump);
                if (tempresult)
                {
                    tempBBN = tempdump;
                }
                else
                {
                    tempBBN = 0;
                }
                tempresult = Double.TryParse(txtUangMuka.Text, out tempdump);
                if (tempresult)
                {
                    tempUM = tempdump;
                }
                else
                {
                    tempUM = 0;
                }
                txtSisaPokok.Text = ((temphargajadi + tempBBN) - tempUM).ToString();
            }

            private void urusJmlAngs()
            {
                // dari sp nya
                // FLT -> pokok = SisaPokok / JmlAngsuran
                //        bunga = SisaPokok * (%Bunga / 100)
                //        angs  = pokok + bunga
                // APD -> pokok = SisaPokok / JmlAngsuran
                //        bunga = SisaPokok * (%Bunga / 100)
                //        angs  = pokok + bunga
                // untuk awalan FLT dan APD itu perhitungannya mirip

                if (rbPenjualan2.Checked == true) // kalau kredit
                {
                    int tempTempo = Convert.ToInt32(Tools.isNull(numKredit.Value, 1));
                    double tempPersenBunga = Convert.ToDouble(Tools.isNull(txtBunga.Text, "0"));
                    if (tempTempo == 0 || tempPersenBunga == 0)
                    {
                        txtJmlAngsuran.Text = "0";
                        txtBungaBulanan.Text = "0";
                    }
                    else
                    {
                        double tempSisaPokok = Convert.ToDouble(Tools.isNull(txtSisaPokok.Text, "0"));
                        double tempBunga = tempSisaPokok * (tempPersenBunga / 100);
                        double tempPokok = tempSisaPokok / tempTempo;
                        double tempAngs = tempBunga + tempPokok;
                        txtBungaBulanan.Text = tempBunga.ToString();
                        txtJmlAngsuran.Text = tempAngs.ToString();
                    }
                    if (cboJnsAngsuran.SelectedValue.ToString() == "APD")
                    {
                        txtBungaBulanan.Text = "0";
                    }
                }
                else
                {
                    txtBungaBulanan.Text = "0";
                    txtJmlAngsuran.Text = "0";
                }
            }

            private void txtHarga_TextChanged(object sender, EventArgs e)
            {
                urusSisaPokok();
                urusJmlAngs();
            }

            private void txtBunga_TextChanged(object sender, EventArgs e)
            {
                urusSisaPokok();
                urusJmlAngs();
            }

            private void txtBBN_TextChanged(object sender, EventArgs e)
            {
                urusSisaPokok();
                urusJmlAngs();
            }

            private void numKredit_ValueChanged(object sender, EventArgs e)
            {
                urusSisaPokok();
                urusJmlAngs();
            }

            private void lookUpSalesman1_Leave(object sender, EventArgs e)
            {
                if (lookUpSalesman1._sales.RowID == null || lookUpSalesman1._sales.RowID == Guid.Empty)
                {
                    MessageBox.Show("Data Salesman masih belum dipilih!");
                }
            }

            private void lookUpKolektor1_Leave(object sender, EventArgs e)
            {
                if ( lookUpKolektor1._Kolektor.RowID == null || lookUpKolektor1._Kolektor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Data Kolektor masih belum dipilih!");
                }
            }

            private void lookUpMotor_Leave(object sender, EventArgs e)
            {
                if ( lookUpMotor._motor.RowID == null || lookUpMotor._motor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Data Motor masih belum dipilih!");
                }
            }
    }
}
