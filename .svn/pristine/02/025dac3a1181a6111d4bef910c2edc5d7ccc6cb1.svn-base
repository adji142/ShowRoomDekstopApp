using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;
using System.Transactions;

namespace ISA.Showroom.Penjualan
{
    public partial class frmUangMukaUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID, _penjRowID, _penjHistRowID, _custRowID;
        Guid _RowIDUMBunga;
        string _cabangID = GlobalVar.CabangID;
        DateTime tglJTUM;
        DateTime tglJual, _tglAwalAngs;
        Double _nominal;
        Double _nilaiBG;
        Double _hargaOff;
        Double _saldo;
        bool isCetak = false;
        UangMukaDetail _selectedUangMukaDetail;
        List<UangMukaIden> _listUangMukaIden;

        String _mode; // isinya bisa -> BayarUM , TambahUM , Tarikan 
        string _kodeTrans; // isinya bisa -> UMK , UMT , TRK

        // tambahan untuk nomor polisi
        String _nopol;

        // untuk TLA/sejenisnya
        Double _bungaUM;
        String _flagSource = "ORI";
        Guid PenerimaanUangUMBungaRowID;

        bool kenaBunga;
        Double Bunga;

        Decimal _realBunga = 0;
        Decimal _sisapokok;
        Decimal _angsPBL;

        Guid newPembelianRowID = Guid.NewGuid();

        public frmUangMukaUpdate(Form caller, Guid penjRowID, Guid custRowID, Guid penjHistRowID, DateTime tglAwalAngs, String mode)
        {
            InitializeComponent();
            _penjRowID = penjRowID;

            _penjHistRowID = penjHistRowID;
            _custRowID = custRowID;
            _tglAwalAngs = tglAwalAngs;
            _mode = mode;
            _rowID = Guid.NewGuid();
            _RowIDUMBunga = Guid.NewGuid();
            PenerimaanUangUMBungaRowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public void RefreshControlsTitipan()
        {
            txtNominal.Text = _selectedUangMukaDetail.TotalNominalIden.ToString();
            cbxBentukPembayaran.Enabled = false;
            txtNominal.Enabled = false;
        }

        private void frmUangMukaUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                txtTglLunas.DateValue = GlobalVar.GetServerDate;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    _flagSource = Tools.isNull(dt.Rows[0]["FlagSource"], "ORI").ToString();

                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblTglJual.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglJual"]);
                    tglJual = (DateTime)dt.Rows[0]["TglJual"];
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString(); 
                    lblSisaUM.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)));
                    tglJTUM = (DateTime)dt.Rows[0]["TglJTUM"];
                    _hargaOff = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Harga"], 0));

                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    _nopol = Tools.isNull(dt.Rows[0]["NoPol"], "").ToString();

                    cbxBentukPembayaran.SelectedIndex = 0;

                    DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                    dt2.DefaultView.Sort = "MataUangID ASC";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.ValueMember = "MataUangID";
                    cboMataUang.DataSource = dt2.DefaultView;

                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }

                    // buat nomer transaksi ngga bisa disini lagi, mesti dibuat saat udah tahu mau bentuk giro atau selain giro
                    // lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                    
                    lblKodeTrans.Text = "PENERIMAAN UANG MUKA";

                    if (_mode == "BayarUM")
                    {
                        _kodeTrans = "UMK";
                    }
                    else if (_mode == "TambahUM")
                    {
                        _kodeTrans = "UMT";
                    }
                    else if (_mode == "Tarikan")
                    {
                        _kodeTrans = "TRK";
                    }
                    /*
                    if (GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
                    {
                        txtTglLunas.DateValue = GlobalVar.GetServerDate.AddDays(1);
                    }
                    else
                    {
                        txtTglLunas.DateValue = GlobalVar.GetServerDate;
                    }
                    */
                    txtNoBG.Text = "";

                    _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                    txtNominal.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)).ToString();
                    txtUraian.Text = "PENERIMAAN UANG MUKA " + Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    txtTglBG.Text = "";

                    if (_mode == "Tarikan")
                    {
                        _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                        this.Text = this.Title = "Kwitansi Tarikan";
                        txtUraian.Text = "Tarikan Motor";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtNominal.Enabled = cbxBentukPembayaran.Enabled = ntbBiayaKolektor.Enabled = false;
                        txtNominal.ReadOnly = ntbBiayaKolektor.ReadOnly = true;
                        cbxBentukPembayaran.SelectedIndex = 0;
                        grpTarikan.Visible = true;
                        ntbBiayaKolektor.Text = "300000";
                        ntbBiayaTarikan.Text = "0";

                        if (GlobalVar.CabangID.Contains("06"))
                        {
                            ntbBiayaKolektor.Text = "0";
                        }

                        txtNominal.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0))).ToString();
                    }

                    if ((_flagSource == "BARU" || GlobalVar.CabangID.Contains("06")) && _mode == "BayarUM")
                    {
                        // adanya kena bunga
                        if (GlobalVar.GetServerDate.Date >= tglJTUM)
                        {
                            DataTable dummy = new DataTable();
                            using (Database dbsub = new Database())
                            {
                                dbsub.Commands.Add(dbsub.CreateCommand("usp_AppSetting_LIST"));
                                dbsub.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BUNGATELATUM"));
                                dummy = dbsub.Commands[0].ExecuteDataTable();
                                if (dummy.Rows.Count > 0)
                                {
                                    _bungaUM = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["Value"].ToString(), "3"));
                                }
                            }

                            int pengaliBunga = -1;
                            DateTime templooper = tglJTUM;
                            while (templooper <= GlobalVar.GetServerDate.Date)
                            {
                                pengaliBunga = pengaliBunga + 1;
                                templooper = templooper.AddMonths(1);
                            }
                            if (pengaliBunga < 0) pengaliBunga = 0;
                            kenaBunga = true;
                            // rumus Bunga -> (harga jadi + BBN - TerimaUM) * [AppSetting]%
                            Bunga = ((Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokok"], 0)) / 100) * _bungaUM) * pengaliBunga;
                        }
                        else
                        {
                            kenaBunga = false;
                            Bunga = 0;
                        }
                        txtBunga.Text = Bunga.ToString();

                        if (kenaBunga == true)
                        {
                            cbxBunga.Enabled = true;
                            cbxBunga.Checked = true;
                            txtBayarBunga.Text = txtBunga.Text;
                            txtBunga.Enabled = true;
                            txtBunga.ReadOnly = false;
                        }
                        else
                        {
                            cbxBunga.Enabled = false;
                            cbxBunga.Checked = false;
                            txtBunga.Enabled = false;
                            txtBunga.ReadOnly = true;
                        }
                    }
                    else
                    {
                        kenaBunga = false;
                        cbxBunga.Enabled = false;
                        cbxBunga.Checked = false;
                        txtBunga.Text = "0";
                        txtBayarBunga.Text = "0";
                    }

                }

                // pembulatan
                cboPembulatan.SelectedIndex = 0;
                refreshPembulatan();
                if (_kodeTrans == "UMK")
                {
                    // kalo lagi bayar um biasa, bacanya dari yg pembulatan aja
                    controlPembulatanSet();
                }
                else
                {
                    // selain itu ngga usah dikunci nominalnya, kecuali saat tarikan, tapi itu udah di atas!!!
                }


                if (_kodeTrans == "UMT")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        grpTambahUM.Visible = true;
                        grpTambahUM.Enabled = true;
                    }
                    txtSisaPokok.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokokMurni"], 0)).ToString();
                    txtJmlAngsuran.Text = lblAngsReal.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0)).ToString();
                    lblTempo.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0)).ToString();

                    decimal tempSisaPokok = Convert.ToDecimal(Tools.isNull(txtSisaPokok.Text, "0"));
                    _sisapokok = tempSisaPokok;
                    decimal tempPokok = tempSisaPokok / Convert.ToDecimal(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0));
                    decimal nominalbungatarget = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0)) - tempPokok;
                    _realBunga = (nominalbungatarget / tempSisaPokok) * 100;
                    txtPBunga.Text = lblPBngReal.Text = _realBunga.ToString("N2");
                    _angsPBL = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0));
                    Decimal tempBunga = tempSisaPokok * (_realBunga / 100);
                    txtBungaBulanan.Text = tempBunga.ToString();
                }

                if (_mode == "BayarUM" && GlobalVar.CabangID.Contains("06"))
                {
                    txtNominal.Enabled = true;
                    txtNominal.ReadOnly = false;
                }

                // ngga bisa bayar um bunga di sini
                cbxBunga.Enabled = false;
                cbxBunga.Checked = false;
                txtBayarBunga.Text = "0";
                cbxBunga.Visible = false;
                refreshPembulatan();

                if (GlobalVar.CabangID.Contains("06"))
                {
                    txtTglLunas.Enabled = true;
                    txtTglLunas.ReadOnly = false;
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

        private void refreshData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if ((_flagSource == "BARU" || GlobalVar.CabangID.Contains("06")) && _mode == "BayarUM")
                    {
                        // adanya kena bunga
                        if (txtTglLunas.DateValue >= tglJTUM)
                        {
                            DataTable dummy = new DataTable();
                            using (Database dbsub = new Database())
                            {
                                dbsub.Commands.Add(dbsub.CreateCommand("usp_AppSetting_LIST"));
                                dbsub.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BUNGATELATUM"));
                                dummy = dbsub.Commands[0].ExecuteDataTable();
                                if (dummy.Rows.Count > 0)
                                {
                                    _bungaUM = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["Value"].ToString(), "3"));
                                }
                            }

                            kenaBunga = true;
                            // rumus Bunga -> (harga jadi + BBN - TerimaUM) * [AppSetting]%
                            Bunga = ((Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokok"], 0)) / 100) * _bungaUM);
                        }
                        else
                        {
                            kenaBunga = false;
                            Bunga = 0;
                        }
                        txtBunga.Text = Bunga.ToString();

                        if (kenaBunga == true)
                        {
                            cbxBunga.Enabled = true;
                            cbxBunga.Checked = true;
                            txtBayarBunga.Text = txtBunga.Text;
                            txtBunga.Enabled = true;
                            txtBunga.ReadOnly = false;

                        }
                        else
                        {
                            cbxBunga.Enabled = false;
                            cbxBunga.Checked = false;
                            txtBunga.Enabled = false;
                            txtBunga.ReadOnly = true;
                        }
                    }
                    else
                    {
                        kenaBunga = false;
                        cbxBunga.Enabled = false;
                        cbxBunga.Checked = false;
                        txtBunga.Text = "0";
                        txtBayarBunga.Text = "0";
                    }

                }

                // pembulatan
                cboPembulatan.SelectedIndex = 0;
                refreshPembulatan();
                if (_kodeTrans == "UMK")
                {
                    // kalo lagi bayar um biasa, bacanya dari yg pembulatan aja
                    controlPembulatanSet();
                }
                else
                {
                    // selain itu ngga usah dikunci nominalnya, kecuali saat tarikan, tapi itu udah di atas!!!
                }


                if (_kodeTrans == "UMT")
                {
                    grpTambahUM.Visible = true;
                    grpTambahUM.Enabled = true;
                    txtSisaPokok.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokokMurni"], 0)).ToString();
                    txtJmlAngsuran.Text = lblAngsReal.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0)).ToString();
                    lblTempo.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0)).ToString();

                    decimal tempSisaPokok = Convert.ToDecimal(Tools.isNull(txtSisaPokok.Text, "0"));
                    _sisapokok = tempSisaPokok;
                    decimal tempPokok = tempSisaPokok / Convert.ToDecimal(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0));
                    decimal nominalbungatarget = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0)) - tempPokok;
                    _realBunga = (nominalbungatarget / tempSisaPokok) * 100;
                    txtPBunga.Text = lblPBngReal.Text = _realBunga.ToString("N2");
                    _angsPBL = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0));
                    Decimal tempBunga = tempSisaPokok * (_realBunga / 100);
                    txtBungaBulanan.Text = tempBunga.ToString();
                }

                if (_mode == "BayarUM" && GlobalVar.CabangID.Contains("06"))
                {
                    txtNominal.Enabled = true;
                    txtNominal.ReadOnly = false;
                }

                // ngga bisa bayar um bunga di sini
                cbxBunga.Enabled = false;
                cbxBunga.Checked = false;
                txtBayarBunga.Text = "0";
                cbxBunga.Visible = false;
                refreshPembulatan();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
            } 
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateSave()
        {
            bool isOK = true;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if ( String.IsNullOrEmpty(cbxBentukPembayaran.SelectedItem.ToString()))
            {
                MessageBox.Show("Pilih Bentuk Pembayaran terlebih dahulu.");
                cbxBentukPembayaran.Focus();
                return false;
            }

            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                if ( ( String.IsNullOrEmpty(lookUpRekening1.NamaRekening) || lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty))
                {
                    MessageBox.Show("Rekening Bank belum terisi");
                    lookUpRekening1.Focus();
                    return false;
                }
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                if ((Convert.ToDouble(Tools.isNull(txtNoBG.Text, 0)) > 0) && (String.IsNullOrEmpty(txtNoBG.Text)))
                {
                    MessageBox.Show("No. BG/CH/TR belum diisi !");
                    txtNoBG.Focus();
                    return false;
                }
                if (txtTglBG.Text == "")
                {
                    MessageBox.Show("Tanggal Jatuh Tempo BGC belum diisi !");
                    txtTglBG.Focus();
                    return false;
                }
                if (((DateTime)txtTglBG.DateValue).Date < tglJual.Date)
                {
                    MessageBox.Show("Tanggal Jatuh Tempo BGC belum diisi !");
                    txtTglBG.Focus();
                    return false;
                }
                if (((DateTime)txtTglBG.DateValue).Date > _tglAwalAngs.Date.AddDays(DateTime.DaysInMonth(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month) - 1))
                {
                    MessageBox.Show("Tanggal Jatuh Tempo BGC tidak boleh lebih dari 1 bulan dari tanggal awal Angsuran!");
                    txtTglBG.Focus();
                    return false;
                }
            }
            if (((DateTime)txtTglLunas.DateValue).Date < GlobalVar.GetServerDate.Date || ((DateTime)txtTglLunas.DateValue).Date > GlobalVar.GetServerDate.Date.AddDays(2))
            {
                MessageBox.Show("Tanggal Pelunasan lebih kecil dari pada tanggal hari ini atau melebihi H+2!");
                txtTglLunas.Focus();
                return false;
            }

            if (txtTglLunas.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
            {
                if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                }
                else
                {
                    txtTglLunas.Focus();
                    return false;
                }
            }

            if (((DateTime)txtTglLunas.DateValue).Date > tglJTUM.Date)
            {
                // PinId.Bagian.Keuangan
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.BatasTempoUangMuka), "Tanggal Pelunasan melebihi Jatuh Tempo Pelunasan Uang Muka !");
                if (GlobalVar.pinResult == false) { return false; }
            }

            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                if (_listUangMukaIden.Count == 0)
                {
                    MessageBox.Show("Identifikasi titipan belum dilakukan." + Environment.NewLine + "Pastikan minimal 1 transaksi titipan sudah diiden ke pembayaran ini");
                    return false;
                }
            }
            /*
            if (((DateTime) txtTglLunas.DateValue).Date < tglJual.Date)
            {
                MessageBox.Show("Tanggal Pelunasan lebih kecil dari pada Tanggal Penjualan !");
                txtTglLunas.Focus();
                return false ;
            }
            */
            //if ((Convert.ToDouble(txtNominal.Text) + Convert.ToDouble(txtNilaiBG.Text)) > (Convert.ToDouble(lblSisaUM.Text) + _hargaOff))
            //{
            //    MessageBox.Show("Nominal Pelunasan lebih besar dari pada Harga Kesepakatan !");
            //    txtNominal.Focus();
            //    return false;
            //}

            if (_mode == "BayarUM")
            {
                if (txtNominal.GetDoubleValue > _saldo)
                {
                    MessageBox.Show("Pelunasan Uang Muka tidak dapat melebihi sisa saldo !");
                    txtNominal.Text = _saldo.ToString();
                }
            }

            if (_mode == "Tarikan")
            {
                if (!dtbTglTarikan.DateValue.HasValue)
                {
                    MessageBox.Show("Tgl Tarikan belum diisi");
                    dtbTglTarikan.Focus();
                    return false;
                }

                if (Convert.ToDouble(Tools.isNull(ntbEstimasiHrgMotor.Text, "0")) <= 0)
                {
                    MessageBox.Show("Harga estimasi motor belum diisi");
                    dtbTglTarikan.Focus();
                    return false;
                }
            } 

            return true;
        }

        private void penerimaanTitipanInsert(ref Database db, ref int counterdb, Decimal decNilaiBGC)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _custRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.UM)); // kalo UM itu 1
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            counterdb++;
        }

        private void penerimaanTitipanInsertBayarUMBunga(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDUMBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _custRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, txtBayarBunga.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 3)); // giro itu 3
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _rowID)); // PenerimaanUMRowID nya

            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.UM)); // kalo UM itu 1
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMB")); // UMB untuk bayar UMBunga
            counterdb++;
        }

        private void penerimaanUMInsert(ref Database db, ref int counterdb, Decimal decNilaiBGC, Decimal decNilaiNominal, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid penerimaanPBLRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            if (_mode == "Tarikan") // kalau tarikan bentuk pembayarannya 5
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5)); // selalu 5 bentuk pembayarannya
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));

            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
            }
            else
            {
                // hanya insert parameter ini kalo bukan giro dan bukan titipan
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }

            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
            } 
            
            // kalau _flagSource nya Baru dan ada bunga, masukkin
            if ((_flagSource == "BARU" || GlobalVar.CabangID.Contains("06")) && kenaBunga == true  && Convert.ToDouble(Tools.isNull(txtBunga.Text, "0").ToString()) > 0)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, Convert.ToDouble(txtBunga.Text)));
            }

            counterdb++;
        }

        private void penerimaanTitipanIdenInsert(ref Database db, ref int counterdb, Guid PenerimaanUMBungaRowID)
        {
            Double Nominal = txtNominal.GetDoubleValue;
            Double NominalUMBunga = 0;
            Double tempCurrAmount = 0;
            Double tempCurrInsert = 0;
            if (kenaBunga == true && cbxBunga.Checked == true && txtBayarBunga.GetDoubleValue > 0)
            {
                NominalUMBunga = txtBayarBunga.GetDoubleValue;
            }
            foreach (UangMukaIden rowUangMukaIden in _listUangMukaIden)
            {
                tempCurrAmount = rowUangMukaIden.NominalIden;
                if (tempCurrAmount > 0 && NominalUMBunga > 0)
                {
                    if (tempCurrAmount >= NominalUMBunga)
                    {
                        tempCurrInsert = NominalUMBunga;
                        tempCurrAmount = tempCurrAmount - NominalUMBunga;
                        NominalUMBunga = 0;
                    }
                    else if (tempCurrAmount < NominalUMBunga)
                    {
                        tempCurrInsert = tempCurrAmount;
                        tempCurrAmount = 0;
                        NominalUMBunga = NominalUMBunga - tempCurrAmount;
                    }
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowUangMukaIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMBNGRowID", SqlDbType.UniqueIdentifier, PenerimaanUMBungaRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrInsert));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
                if (tempCurrAmount > 0 && Nominal > 0)
                {
                    if (tempCurrAmount >= Nominal)
                    {
                        tempCurrInsert = Nominal;
                        tempCurrAmount = tempCurrAmount - Nominal;
                        Nominal = 0;
                    }
                    else if (tempCurrAmount < Nominal)
                    {
                        tempCurrInsert = tempCurrAmount;
                        tempCurrAmount = 0;
                        Nominal = Nominal - tempCurrAmount;
                    }
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowUangMukaIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrInsert));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
                if (tempCurrAmount > 0 && Nominal < 1 && NominalUMBunga < 1) // kalau masih ada sisa juga, masukkin ke angsurannya aja
                {
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowUangMukaIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrAmount));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
            }
        }

        private void penerimaanUMBungaInsert(ref Database db, ref int counterdb, Guid PenerimaanUMBungaRowID, Guid PenerimaanUMRowID, Double Nominal, Guid penerimaanUangRowID, String NoTransUMBunga)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMBungaRowID", SqlDbType.UniqueIdentifier, PenerimaanUMBungaRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, txtTglLunas.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, (cbxBentukPembayaran.SelectedIndex + 1)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTransUMBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));

            if (Convert.ToDecimal(txtBunga.Text) > 0 && cbxBunga.Checked == true) // memang dibayarkan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }

            counterdb++;
        }

        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPenerimaan = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (titipan)
            }
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
                // metsi cek kalo uang muka tambahan jenis transaksi nya beda
                if (penerimaanUangRowID == PenerimaanUangUMBungaRowID) // berarti lagi urus UMBunga
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAUMBunga).ToString()));  // UMT -> UMT itu seperti bayar pokok angsuran (24)
                }
                if(_kodeTrans == "UMT")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMT).ToString()));  // UMT -> UMT itu seperti bayar pokok angsuran (24)
                }
                else if (_kodeTrans == "UMK")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMK).ToString() ));  // UM -> Uang Muka Penjualan   (28)
                }
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> lblNoTrans.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            if (penerimaanUangRowID == PenerimaanUangUMBungaRowID) // berarti lagi urus UMBunga
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtBayarBunga.GetDoubleValue));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, txtBayarBunga.GetDoubleValue));
            }
            else
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominal.Text)));
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini uang muka

            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
       
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private Guid simpanTarikan(ref Database db, ref int counterdb)
        {
            //Simpan Info Tarikan 
            System.Guid guidVendorRowID = System.Guid.Empty;
            db.Commands.Add(db.CreateCommand("usp_tarikanpenjualan_update"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(ntbEstimasiHrgMotor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanKolektor", SqlDbType.Money, Convert.ToDouble(ntbBiayaKolektor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanLainLain", SqlDbType.Money, Convert.ToDouble(ntbBiayaTarikan.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganTarikan", SqlDbType.VarChar, txtKeteranganTarikan.Text));
            counterdb++;

            //Copy Customer ke Vendor , sblm insert dicek dl, apakah rowidnya udah ada / blm atau no identitasnya udah ada atau blm 
            db.Commands.Add(db.CreateCommand("usp_CopyCustomerToVendor"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _custRowID));
            object objVendorRowID = db.Commands[counterdb].ExecuteScalar();
            if (objVendorRowID != null)
            {
                guidVendorRowID = new System.Guid(Convert.ToString(objVendorRowID));
            }
            else
            {
                throw new Exception("Data Vendor tidak berhasil dibentuk !");
            }
            counterdb++;

            //Simpan Ke Pembelian                             
            db.Commands.Add(db.CreateCommand("usp_TarikanInsertKePembelian"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NewRowID", SqlDbType.UniqueIdentifier, newPembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, guidVendorRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(ntbEstimasiHrgMotor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserInitial));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTransPembayaranPembelian", SqlDbType.VarChar, Numerator.NextNumber("NTB")));
            counterdb++;

            return guidVendorRowID;
        }

        private void penjualanHistUPDATETambahUM(ref Database db, ref int counterdb, Decimal decNilaiNominal)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_Hist_UPDATE_TambahUM"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TambahanUM", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void penjualanHistUPDATETambahUMBARU(ref Database db, ref int counterdb, Decimal decNilaiNominal)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_Hist_UPDATE_TambahUM"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TambahanUM", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, _flagSource));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RPBunga", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        // kalo tarikkan masukkan ke PengeluaranUang
        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran, Guid VendorRowID, Double NominalKeluar, String JnsTransaksi, String InFix)
        {
            DataTable dtsub = new DataTable();
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
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, JnsTransaksi));  // Pembelian Motor -> (32)
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

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID ));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));  // 32 - Pembelian Motor

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, NominalKeluar));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, NominalKeluar));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Tarikan " + InFix + " | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukPengeluaran)); // dari bentukPembayaran kah???
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty)); // kosongin // aman untuk jurnal pengeluaran

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9)); // defaultin 9

            if (cbxBentukPembayaran.SelectedIndex == 0) // kalo tunai baru kas rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // dari globalvar
            }
            else if (cbxBentukPembayaran.SelectedIndex == 1) // kalo transfer baru rekening rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (Guid)Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty)));
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2)); // defaultin ke 2 (ke perusahaan)
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void penerimaanPembulatanInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPenerimaan = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (titipan)
            }
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
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.Pembulatan).ToString()));  // Pembulatan -> Pendapatan Lain - Lain (32)
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> lblNoTrans.Text / txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominalPembulatan.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalPembulatan.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Pembulatan " + cboPembulatan.Text + " untuk Uang Muka | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini administrasi 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void penjualanLogInsert(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanUMT", SqlDbType.Money, txtNominal.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi UMT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Tambahan DP Pelanggan : " + lblNama.Text.Trim() + " | " + txtNominal.GetDoubleValue));
            counterdb++;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            Decimal decNilaiBGC = 0;
            Decimal decNilaiNominal = 0; 
            int bentukPembayaran = 1 ; 

            System.Guid rekeningPembayaranRowID = System.Guid.Empty;

            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            int counterdb = 0, counterdbf = 0;

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
                decNilaiNominal = Convert.ToDecimal(txtNominal.Text);

                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    // NTP untuk kode dokumen titipan , seperti giro
                    lblNoTrans.Text = Numerator.NextNumber("NTP");
                }
                else
                {
                    // NKJ untuk kode dokumen non giro
                    lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                }      
                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
                {
                    bentukPembayaran = 2;
                    rekeningPembayaranRowID = lookUpRekening1.RekeningRowID; 
                }
                else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    bentukPembayaran = 3;
                    decNilaiBGC = Convert.ToDecimal(txtNominal.Text);
                    decNilaiNominal = 0; 
                }
                Guid penerimaanUangRowID;
                Guid penerimaanPBLRowID = Guid.NewGuid();
                penerimaanUangRowID = Guid.NewGuid();
                
                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    penerimaanTitipanInsert(ref db, ref counterdb, decNilaiBGC);
                    // kalau ada kena Bunga, perlu dimasukkan juga penerimaanTitipan terpisah
                    if (kenaBunga == true && txtBayarBunga.GetDoubleValue > 0)
                    {
                        penerimaanTitipanInsertBayarUMBunga(ref db, ref counterdb);
                    }
                }
                else
                {
                    penerimaanUMInsert(ref db, ref counterdb, decNilaiBGC, decNilaiNominal, rekeningPembayaranRowID, penerimaanUangRowID, penerimaanPBLRowID);
                    
                    // kena bunga, dan bayarnya bukan dengan titipan
                    if (kenaBunga == true && cbxBentukPembayaran.SelectedItem.ToString().ToLower() != "titipan")
                    {
                        if (cbxBunga.Checked == true && Convert.ToDouble(txtBayarBunga.Text) > 0 && Convert.ToDouble(txtBunga.Text) > 0) // berarti dibayarkan bunganya
                        {
                            String tempBentukPenerimaan = "";
                            switch (cbxBentukPembayaran.SelectedIndex + 1)
                            {
                                case 1: // kalau kas
                                    tempBentukPenerimaan = "K";
                                    break;
                                case 2: // kalau transfer
                                    tempBentukPenerimaan = "B";
                                    break;
                                case 3: // kalau giro
                                    tempBentukPenerimaan = "G";
                                    break;
                                case 4: // kalau titipan
                                    tempBentukPenerimaan = "K";
                                    break;
                            }
                            Database dbfNumeratorUMBunga = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaanUMBunga = Numerator.GetNomorDokumen(dbfNumeratorUMBunga, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, PenerimaanUangUMBungaRowID, NoTransPenerimaanUMBunga);

                            // masuk ke penerimaan UMBunga juga
                            Guid penerimaanUMBungaNewRowID = Guid.NewGuid();
                            String NoTransUMBunga = Numerator.NextNumber("NKU");
                            penerimaanUMBungaInsert(ref db, ref counterdb, penerimaanUMBungaNewRowID, _rowID, Convert.ToDouble(txtBayarBunga.Text.ToString()), PenerimaanUangUMBungaRowID, NoTransUMBunga);
                        }
                        else if (cbxBunga.Checked == false) // ngga mau bayar UMBunga
                        {
                        }
                    }

                    // kalo modenya tambah UM -> update ke data penjualan_Hist
                    if (_mode == "TambahUM")
                    {
                        penjualanLogInsert(ref db, ref counterdb);

                        if (GlobalVar.CabangID.Contains("06"))
                        {
                            if (_flagSource == "BARU")
                            {
                                penjualanHistUPDATETambahUMBARU(ref db, ref counterdb, decNilaiNominal);
                            }
                            else if (_flagSource == "ORI")
                            {
                                penjualanHistUPDATETambahUMBARU(ref db, ref counterdb, decNilaiNominal);
                            }
                        }
                        else if (_flagSource == "ORI")
                        {
                            penjualanHistUPDATETambahUM(ref db, ref counterdb, decNilaiNominal);
                        }
                    }

                    //pembayaran ambil dari titipan 
                    if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
                    {
                        // masuk ke penerimaan UMBunga juga
                        Guid penerimaanUMBungaNewRowID = Guid.NewGuid();
                        penerimaanTitipanIdenInsert(ref db, ref counterdb, penerimaanUMBungaNewRowID);
                        if (kenaBunga == true && cbxBunga.Checked == true && Convert.ToDouble(txtBayarBunga.Text) > 0 && Convert.ToDouble(txtBunga.Text) > 0)
                        {
                            String NoTransUMBunga = Numerator.NextNumber("NKU");
                            penerimaanUMBungaInsert(ref db, ref counterdb, penerimaanUMBungaNewRowID, _rowID, Convert.ToDouble(txtBayarBunga.Text.ToString()), PenerimaanUangUMBungaRowID, NoTransUMBunga);
                        }
                    }
                    // selain pembayaran dari giro dan titipan buat data penerimaan uang

                    if (_mode == "Tarikan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                    {
                    }
                    else
                    {
                        // hanya insert parameter ini kalo bukan giro dan bukan titipan
                        // bagian penerimaanUang

                        // buat no Bukti PenerimaanUang baru
                        String tempBentukPenerimaan = "";

                        switch (bentukPembayaran)
                        {
                            case 1 : // kalau kas
                                     tempBentukPenerimaan = "K";
                                     break;
                            case 2 : // kalau transfer
                                     tempBentukPenerimaan = "B";
                                     break;
                            case 3 : // kalau giro
                                     tempBentukPenerimaan = "G";
                                     break;
                            case 4 : // kalau titipan
                                     tempBentukPenerimaan = "K";
                                     break;
                        }
                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                    "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                    , 4, false, true);

                        penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanUangRowID, NoTransPenerimaan);

                        // masukkin data pembulatan ke penerimaanUang
                        if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
                        {
                            Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaanPBL = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);
                            penerimaanPembulatanInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanPBLRowID, NoTransPenerimaanPBL);
                        }

                    }

                    //simpan tarikan 
                    if (_mode == "Tarikan")
                    {
                        Guid tempVendorRowID = Guid.Empty;
                        tempVendorRowID = simpanTarikan(ref db, ref counterdb);
                        
                        // juga masukkan ke pengeluaranUang
                        // di bawah ini itu ngebentuk Bukti Uang Keluar bukan bukti bayar pembelian !!!

                        String tempBentukPenerimaan = "";
                        switch (bentukPembayaran)
                        {
                            case 1: // kalau kas
                                    tempBentukPenerimaan = "K";
                                    break;
                            case 2: // kalau transfer
                                    tempBentukPenerimaan = "B";
                                    break;
                            case 3: // kalau giro
                                    tempBentukPenerimaan = "G";
                                    break;
                            case 4: // kalau titipan
                                    tempBentukPenerimaan = "K";
                                    break;
                        }

                        if (ntbBiayaKolektor.GetDoubleValue > 0)
                        {
                            // ini untuk biaya kolektor
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 
                            Guid pengeluaranKolektorRowID = Guid.NewGuid();

                            pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranKolektorRowID, tempBentukPenerimaan, NoTransPengeluaran, tempVendorRowID, ntbBiayaKolektor.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Kolektor");
                            if (GlobalVar.CabangID.Contains("13")) // cabang 13, KTS-BYL ngga boleh diproses pembayaran pembeliannya
                            {
                            }
                            else
                            {
                                pembayaranPembInsert(ref db, ref counterdb, pengeluaranKolektorRowID, "KOLEKTOR", ntbBiayaKolektor.GetDoubleValue);
                            }
                        }

                        if (ntbBiayaTarikan.GetDoubleValue > 0)
                        {
                            // ini untuk biaya lain - lain
                            Database dbfNumerator2 = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPengeluaran2 = Numerator.GetNomorDokumen(dbfNumerator2, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                            Guid pengeluaranTarikanRowID = Guid.NewGuid();
                            pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranTarikanRowID, tempBentukPenerimaan, NoTransPengeluaran2, tempVendorRowID, ntbBiayaTarikan.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Tarikan");
                            if (GlobalVar.CabangID.Contains("13")) // cabang 13, KTS-BYL ngga boleh diproses pembayaran pembeliannya
                            {
                            }
                            else
                            {
                                pembayaranPembInsert(ref db, ref counterdb, pengeluaranTarikanRowID, "TARIKAN", ntbBiayaTarikan.GetDoubleValue);
                            }
                        }
                        /*
                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                        pengeluaranUangInsert(ref dbf, ref counterdbf, (Guid) Guid.NewGuid(), tempBentukPenerimaan, NoTransPengeluaran, tempVendorRowID);
                        */
                    }
                    else
                    {
                    }

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
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                dbf.RollbackTransaction();
                MessageBox.Show("Data gagal ditambahkan !\n " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pembayaranPembInsert(ref Database db, ref int counterdb, Guid pengeluaranUangRowID, String Ket, Double Nominal)
        {
            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid())); //_rowID
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKB")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "TAM")); // pasti tambahan

            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, newPembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, "TRK|" + Ket + "-" + txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

            // tambahin bentuk pembayarannya sama rekening rowID nya
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1)); // pasti tunai

            counterdb++;
        }


        private void frmUangMukaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmUangMukaBrowse)
            {
                Penjualan.frmUangMukaBrowse frmCaller = (Penjualan.frmUangMukaBrowse)this.Caller;
                frmCaller.RefreshRowUM(_penjRowID);
                frmCaller.FindRowGrid2("mKodeTrans", _kodeTrans);
                frmCaller.RefreshRowLunas(_rowID);                
                frmCaller.FindRowGrid3("dRowID", _rowID.ToString());
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_bungaUM > 0 && kenaBunga == true) cbxBunga.Enabled = true;
            else cbxBunga.Enabled = false;
            if (_kodeTrans == "UMT" || (_kodeTrans == "UMK" && GlobalVar.CabangID.Contains("06")))
            {
                txtNominal.Enabled = true;
                txtNominal.ReadOnly = false;
            }
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = false; 
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = true; 
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                if (_mode == "TambahUM")
                {
                    cbxBentukPembayaran.SelectedIndex = 0;
                    MessageBox.Show("Bentuk Pembayaran Giro tidak dapat dilakukan.");
                }
                else
                {
                    EnabledControlBG();
                    lookUpRekening1.Enabled = false;
                }
                
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                cbxBunga.Enabled = false;

                DisabledControlBG();
                lookUpRekening1.Enabled = false;

                _selectedUangMukaDetail = new UangMukaDetail();
                _selectedUangMukaDetail.CustomerRowID = _custRowID;
                _selectedUangMukaDetail.CustomerName = lblNama.Text;
                _selectedUangMukaDetail.NominalPembayaran = Convert.ToDouble(txtNominal.Text);
                _selectedUangMukaDetail.MataUangID = cboMataUang.SelectedValue.ToString();
                _selectedUangMukaDetail.UMBunga = txtBayarBunga.GetDoubleValue;

                _listUangMukaIden = new List<UangMukaIden>();
                Penjualan.frmUangMukaIden ifrmChild = new Penjualan.frmUangMukaIden(this, _selectedUangMukaDetail, _listUangMukaIden, _kodeTrans);
                ifrmChild.ShowDialog();
                if (_kodeTrans == "UMT" || (_kodeTrans == "UMK" && GlobalVar.CabangID.Contains("06")))
                {
                    txtNominal.Text = _selectedUangMukaDetail.TotalNominalIden.ToString();
                    txtNominal.Enabled = false;
                    txtNominal.ReadOnly = true;
                }
            }
        }


        private void DisabledControlBG()
        {
            txtNoBG.Enabled = false;
            txtTglBG.Enabled = false; 
        }

        private void EnabledControlBG()
        {
            txtNoBG.Enabled = true;
            txtTglBG.Enabled = true;
        }

        private void lookUpRekening1_Load(object sender, EventArgs e)
        {

        }

        private void ntbBiayaTarikan_TextChanged(object sender, EventArgs e)
        {
            updateTxtNominal();
        }

        private void ntbBiayaTarikan_Leave(object sender, EventArgs e)
        {
            updateTxtNominal();
        }

        private void updateTxtNominal()
        {
            if (_mode == "Tarikan")
            {
                txtNominal.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(ntbBiayaTarikan.Text)).ToString();
            }
        }

        private void refreshPembulatan()
        {
            // kalo pas di uang muka, pembulatannya itu perlu di cek, soalnya kalau lagi tambah um, ngga dibuletin, tapi langsung jadi nominal aja
            // ataupun kalau bentuk pembayarannya sedang menggunakan titipan
            if (_kodeTrans == "UMT" || _mode == "TambahUM" || cbxBentukPembayaran.Text.ToLower() == "titipan")
            {
                txtNominalPembulatan.Text = "0"; // pembulatannya 0
                txtNominalPembayaranPBL.Text = txtNominal.Text; // jadiin sama seperti txtnominalnya aja
            }
            else
            {
                if (_flagSource == "BARU" || GlobalVar.CabangID.Contains("06"))
                {
                    // index 0 -> 100, 1 -> 500, 2 -> 1000
                    if (cboPembulatan.SelectedIndex >= 0)
                    {
                        Double Value = Convert.ToDouble(Tools.isNull(txtNominal.Text, 0)) + Convert.ToDouble(Tools.isNull(txtBayarBunga.Text, 0));
                        Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                        txtNominalPembulatan.Text = (PBLValue - Value).ToString();
                        txtNominalPembayaranPBL.Text = PBLValue.ToString();
                    }
                }
                else
                {
                    // index 0 -> 100, 1 -> 500, 2 -> 1000
                    if (cboPembulatan.SelectedIndex >= 0)
                    {
                        Double Value = Convert.ToDouble(Tools.isNull(txtNominal.Text, 0));
                        Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                        txtNominalPembulatan.Text = (PBLValue - Value).ToString();
                        txtNominalPembayaranPBL.Text = PBLValue.ToString();
                    }
                }
            }
        }

        private void cboPembulatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void controlPembulatanSet()
        {
            txtNominal.Enabled = false;
            txtNominal.ReadOnly = true;
        }

        private void txtNominal_TextChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void cbxBunga_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBunga.Checked == true) // berarti mau dibayarkan
            {
                txtBayarBunga.Text = txtBunga.Text;
                // txtPembayaran.Text = (Convert.ToDouble(txtPembayaran.Text.ToString()) + Convert.ToDouble(txtDenda.Text.ToString())).ToString();
            }
            else if (cbxBunga.Checked == false) // berarti ngga mau dibayar
            {
                txtBayarBunga.Text = "0";
                // txtPembayaran.Text = (Convert.ToDouble(txtPembayaran.Text.ToString()) - Convert.ToDouble(txtDenda.Text.ToString())).ToString();
            }
            // kalau ada bayar denda, sekarang itu kehitung HANYA pembulatannya, nominal bayarnya juga tapi tidak masuk ke database
            refreshPembulatan();
        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            if (_mode == "BayarUM")
            {
                if (txtNominal.GetDoubleValue > _saldo)
                {
                    MessageBox.Show("Pelunasan Uang Muka tidak dapat melebihi sisa saldo !");
                    txtNominal.Text = _saldo.ToString();
                }
            }
            else if (_mode == "TambahUM")
            {
                if (GlobalVar.CabangID.Contains("06"))
                {
                    recalculateBunga();
                }
            }
        }

        private void recalculateBunga()
        {
            // cek dulu, jumlah angsuran per bulan yg baru ngga boleh lebih kecil dari angsuran pokok per bulannya
            if (txtNominal.GetDoubleValue > 0 && txtJmlAngsuran.GetDoubleValue > 0) // kalau kredit
            {
                int tempTempo = Convert.ToInt16(lblTempo.Text);
                decimal jmlangsurantarget = Convert.ToDecimal(Tools.isNull(txtJmlAngsuran.Text, "0"));
                
                if (tempTempo == 0)
                {
                    txtJmlAngsuran.Text = "0";
                    txtBungaBulanan.Text = "0";
                    txtPBunga.Text = "0";
                    cmdSave.Enabled = false;
                }
                else
                {
                    Decimal tempSisaPokok = _sisapokok - Convert.ToDecimal(txtNominal.GetDoubleValue);
                    Decimal tempPokok = tempSisaPokok / tempTempo;
                    if (tempPokok != 0 && tempSisaPokok != 0)
                    {
                        if (Convert.ToDecimal(Tools.isNull(txtJmlAngsuran.Text, Decimal.MinValue).ToString()) < tempPokok)
                        {
                            MessageBox.Show("Angsuran yg diinginkan tidak boleh lebih kecil dari angsuran pokok");
                            txtJmlAngsuran.Focus();
                            return;
                        }
                        else
                        {
                            decimal nominalbungatarget = jmlangsurantarget - tempPokok;
                            _realBunga = (nominalbungatarget / tempSisaPokok) * 100;
                            txtPBunga.Text = _realBunga.ToString("N2");
                            txtSisaPokok.Text = tempSisaPokok.ToString();
                            txtBungaBulanan.Text = nominalbungatarget.ToString();
                            
                            // hitung angsuran dan bunga jika kondisinya bukan ikut target
                            tempSisaPokok = Convert.ToDecimal(Tools.isNull(txtSisaPokok.Text, "0"));
                            Decimal tempBunga = tempSisaPokok * (Convert.ToDecimal(lblPBngReal.Text) / 100);
                            tempPokok = tempSisaPokok / tempTempo;
                            Decimal tempAngs = tempBunga + tempPokok;
                            lblAngsReal.Text = tempAngs.ToString("N2");

                            GroupBox target = (GroupBox)grpTambahUM;
                            ToolTip message = new ToolTip();
                            message.Show("Pastikan untuk menentukan jumlah angsuran per bulannya kembali!", target, 200, -12, 1500);
                            
                        }
                    }
                }
            }
            else
            {
                txtBungaBulanan.Text = "0";
                txtPBunga.Text = "0";
            }
        }

        private void txtJmlAngsuran_Leave(object sender, EventArgs e)
        {
            recalculateBunga();
        }

        private void cmdSave_MouseHover(object sender, EventArgs e)
        {
            if (Convert.ToDouble(_angsPBL) == txtJmlAngsuran.GetDoubleValue)
            {
                GroupBox target = (GroupBox)grpTambahUM;
                ToolTip message = new ToolTip();
                message.Show("Target Angsuran per Bulan tidak ada perubahan, pastikan jika isian sudah sesuai!", target, 200, -12, 3000);
            }
        }

        private void txtBunga_Leave(object sender, EventArgs e)
        {
            if (txtBunga.GetDoubleValue < Bunga)
            {
                MessageBox.Show("Bunga yg diberikan tidak bisa lebih kecil dari perhitungan awal, gunakan fitur potongan saat bayar di layar UMBunga!");
                txtBunga.Text = Bunga.ToString("N2");
                txtBunga.Focus();
            }
            if (cbxBunga.Checked == true)
            {
                txtBayarBunga.Text = txtBunga.Text;
                refreshPembulatan();
            }
        }

        private void txtTglLunas_Leave(object sender, EventArgs e)
        {
            refreshData();
        }

    }
}
