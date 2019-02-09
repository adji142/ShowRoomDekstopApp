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

namespace ISA.Showroom.Penjualan
{
    public partial class frmPelunasanUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID, _penjRowID, _CustomerRowID;
        string _kodeTrans, _kodeTransPJL;
        string _cabangID = GlobalVar.CabangID;
        DateTime tglJTUM;
        DateTime tglJual;
        String _mode; // "Pelunasan" atau "Tarikan"
        Double _saldo;
        String _nopol;

        AngsuranDetail _selectedAngsuranDetail;
        List<AngsuranIden> _listAngsuranIden;
        int modeBayarTitipan = 0;
        Double tambahanTunaiTitipan = 0;
        Double tambahanTunaiTitipanPembulatan = 0;
        Double bayarBulatTambahanTunaiTitipan = 0;


        bool kenaDenda;
        Double Denda;
        Guid newPembelianRowID = Guid.NewGuid();

        bool kenaBunga;
        Double UMBunga;

        // untuk TLA/sejenisnya
        Double _bungaUM;
        String _flagSource = "ORI";
        Guid penerimaanUangUMBungaRowID = Guid.NewGuid();

        Guid penerimaanUangDendaRowID = Guid.NewGuid();

        public frmPelunasanUpdate(Form caller, Guid penjRowID, String kodeTrans, String mode)
        {
            InitializeComponent();
            _penjRowID = penjRowID;
            _rowID = Guid.NewGuid();
            this.Caller = caller;
            _kodeTrans = kodeTrans;
            _mode = mode;
        }

        private void frmPelunasanUpdate_Load(object sender, EventArgs e)
        {
            // selalu disable yg cbxdenda, kecuali kalau memang ada kena denda
            cbxDenda.Enabled = false;
            cbxDenda.Checked = false;
            cboPembulatan.SelectedIndex = 0;
            txtNominalPembayaranPBL.Enabled = false;
            txtNominalPembulatan.Enabled = false;

            // selalu disable yg urusin bungaUM, kecuali memang kena, nanti diurus di bawah
            cbxBunga.Enabled = false;
            cbxBunga.Checked = false;
            txtBunga.Enabled = false;
            txtBunga.ReadOnly = true;
            txtBayarBunga.Enabled = false;
            txtBayarBunga.ReadOnly = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (_kodeTrans == "LSG" || _kodeTrans == "UMK" || _kodeTrans == "SBD")
                    {
                        lblKopNamaLeasing.Visible = true;
                        lblNamaLeasing.Visible = true;
                        lblNamaLeasing.Text = Tools.isNull(dt.Rows[0]["NamaLeasing"], "").ToString();
                    }
                    else
                    {
                        lblKopNamaLeasing.Visible = false;
                        lblNamaLeasing.Visible = false;
                    }

                    cbxBentukPembayaran.SelectedIndex = 0;
                    _flagSource = Tools.isNull(dt.Rows[0]["FlagSource"], "ORI").ToString();

                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    _nopol = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();

                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblTglJual.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglJual"]);
                    tglJual = (DateTime)dt.Rows[0]["TglJual"];
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    lblSisaUM.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)));
                    tglJTUM = (DateTime)dt.Rows[0]["TglJTUM"];

                    _kodeTransPJL = Tools.isNull(dt.Rows[0]["KodeTransPJL"], "").ToString();

                    _CustomerRowID = new Guid(dt.Rows[0]["CustRowID"].ToString());

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

                    // lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");                           
                    // no trans buatnya belakangan kalo transaksi sukses, biar ngga bolong2

                    txtTglLunas.DateValue = GlobalVar.GetServerDate;
                    txtUraian.Text = "";
                    if (_kodeTrans == "TUN")
                    {
                        //lblKodeTrans.Text = "TUN"; 
                        txtUraian.Text = "PENERIMAAN PELUNASAN TUNAI";
                    }

                    else if (_kodeTrans == "BKS")
                    {
                        //lblKodeTrans.Text = "TUN"; 
                        txtUraian.Text = "PELUNASAN TUNAI BEKAS";
                    }
                    else if (_kodeTrans == "CTP")
                    {
                        //lblKodeTrans.Text = "CTP"; 
                        txtUraian.Text = "PENERIMAAN PELUNASAN CASH TEMPO";
                        txtNominal.Enabled = true;
                        txtNominal.ReadOnly = false;
                    }
                    else if (_kodeTrans == "LSG")
                    {
                        //lblKodeTrans.Text = "LSG";
                        txtUraian.Text = "PENERIMAAN PELUNASAN LEASING";
                    }
                    else if (_kodeTrans == "UMK")
                    {
                        //lblKodeTrans.Text = "UMK";
                        txtUraian.Text = "PENERIMAAN PELUNASAN UANG MUKA";
                    }

                    txtNoBG.Text = "";

                    // pokok nominal yg mesti dibayar
                    txtPokok.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)).ToString();
                    txtTglBG.Text = "";

                    if (_kodeTrans == "CTP")
                    {
                        if (GlobalVar.GetServerDate.Date >= tglJTUM)
                        {
                            kenaDenda = true;
                            // rumus denda -> (harga jadi + BBN - TerimaUM) * 3%
                            Denda = ((Convert.ToDouble(Tools.isNull(dt.Rows[0]["HargaJadi"], 0))
                                   + Convert.ToDouble(Tools.isNull(dt.Rows[0]["BBN"], 0))
                                   - Convert.ToDouble(Tools.isNull(dt.Rows[0]["Nominal"], 0)))
                                   / 100) * 3;
                        }
                    }
                    else
                    {
                        kenaDenda = false;
                        Denda = 0;
                    }
                    txtDenda.Text = Denda.ToString();

                    if (kenaDenda == true)
                    {
                        cbxDenda.Enabled = true;
                        cbxDenda.Checked = true;
                        txtBayarDenda.Text = txtDenda.Text;
                    }

                    // yang mesti dibayar total -> pokok + denda
                    txtNominal.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0))).ToString(); // jangan itung dendanya Denda + 

                    if (_flagSource == "BARU" || GlobalVar.CabangID.Contains("06")) // karena ADS itu ORI
                    {
                        // jadinya itu ngga ada denda, adanya kena bunga
                        txtDenda.Text = "0";
                        txtBayarDenda.Text = "0";
                        cbxDenda.Enabled = false;
                        kenaDenda = false;
                        Denda = 0;

                        if (_kodeTransPJL == "CTP" || _kodeTransPJL == "TUN") // (_kodeTrans == "CTP" || _kodeTrans == "TUN" || _kodeTrans == "UMK")
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

                            if (GlobalVar.GetServerDate.Date >= tglJTUM)
                            {
                                int pengaliBunga = 0;//-1;
                                DateTime templooper = tglJTUM;
                                while (templooper <= GlobalVar.GetServerDate.Date)
                                {
                                    pengaliBunga = pengaliBunga + 1;
                                    templooper = templooper.AddMonths(1);
                                }
                                if (pengaliBunga < 0) pengaliBunga = 0;
                                kenaBunga = true;
                                // rumus Bunga -> (harga jadi + BBN - TerimaUM) * 3%
                                UMBunga = ((Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)) / 100) * _bungaUM) * pengaliBunga;
                            }
                        }
                        else
                        {
                            kenaBunga = false;
                            UMBunga = 0;
                        }
                        txtBunga.Text = UMBunga.ToString();

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

                }

                if (_mode == "Tarikan")
                {
                    this.Text = this.Title = "Kwitansi Tarikan";
                    _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                    txtUraian.Text = "Tarikan Motor";
                    txtNoBG.Text = txtTglBG.Text = "";
                    txtPokok.Enabled = txtNominal.Enabled = cbxBentukPembayaran.Enabled = ntbBiayaKolektor.Enabled = false;
                    cbxBentukPembayaran.SelectedIndex = 0;
                    grpTarikan.Visible = true;
                    ntbBiayaKolektor.Text = "300000";
                    // kalo tarikan denda ngga usah dulu // + Denda 
                    txtNominal.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0))).ToString();

                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        ntbBiayaKolektor.Text = "0";
                    }
                }

                if (GlobalVar.CabangID.Contains("06"))
                {
                    if (_kodeTrans == "CTP" || _kodeTrans == "LSG" || _kodeTrans == "UMK")
                    {
                        txtNominal.Enabled = true;
                        txtNominal.ReadOnly = false;
                    }
                }


                // ngga bisa bayar denda di sini
                cbxDenda.Enabled = false;
                cbxDenda.Checked = false;
                txtBayarDenda.Text = "0";
                cbxDenda.Visible = false;

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
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateSave(ref Decimal decNilaiNominal, ref Decimal decNilaiBGC, ref int bentukPembayaran, ref Guid rekeningPembayaranRowID)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (Convert.ToDecimal(txtNominal.Text) <= 0)
            {
                MessageBox.Show("Nominal harus lebih dari 0");
                return false;
            }

            if (String.IsNullOrEmpty(cbxBentukPembayaran.SelectedItem.ToString()))
            {
                MessageBox.Show("Pilih Bentuk Pembayaran terlebih dahulu!");
                cbxBentukPembayaran.Focus();
                return false;
            }
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                bentukPembayaran = 2;
                rekeningPembayaranRowID = lookUpRekening1.RekeningRowID;
                if (Tools.isNull(lookUpRekening1.NamaRekening, "").ToString() == "" || lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    MessageBox.Show("Rekening Bank belum terisi");
                    lookUpRekening1.Focus();
                    return false;
                }
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                bentukPembayaran = 3;
                decNilaiBGC = Convert.ToDecimal(txtPokok.Text); // sebelumnya Convert.ToDecimal(txtNominal.Text);
                decNilaiNominal = 0;
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
            }

            if (((DateTime)txtTglLunas.DateValue).Date < tglJual.Date)
            {
                MessageBox.Show("Tanggal Pelunasan lebih kecil dari pada Tanggal Penjualan !");
                txtTglLunas.Focus();
                return false;
            }
            if (((DateTime)txtTglLunas.DateValue).Date < GlobalVar.GetServerDate.Date)
            {
                MessageBox.Show("Tanggal Pelunasan lebih kecil dari pada tanggal hari ini !");
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

            /* // yg pin ngga usah dulu
            if (((DateTime)txtTglLunas.DateValue).Date > tglJTUM.Date)
            {
                // PinId.Bagian.Keuangan
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.BatasTempoCashTempo), "Tanggal Pelunasan melebihi Jatuh Tempo Pelunasan !");
                if (GlobalVar.pinResult == false) { return false; }
            }
            */
            if (_mode == "Tarikan")
            {
                // kalo tarikan ngga perlu ada cek nominal, soalnya pasti sama
            }
            else
            {
                if ((_kodeTrans == "CTP") && ((decNilaiNominal + decNilaiBGC) > (Convert.ToDecimal(lblSisaUM.Text)))) // + Convert.ToDecimal(txtDenda.Text)
                {
                    MessageBox.Show("Nominal Pelunasan lebih besar dari pada harga kesepakatan penjualan !");
                    txtNominal.Focus();
                    return false;
                }
                // yg tunai udah dari sananya cek mesti sama
                if ((_kodeTrans == "TUN") && (decNilaiNominal + decNilaiBGC != Convert.ToDecimal(lblSisaUM.Text)))
                {
                    MessageBox.Show("Nominal pelunasan tidak sama dengan harga kesepakatan penjualan !");
                    txtNominal.Focus();
                    return false;
                }
                if ((_kodeTrans == "LSG") && ((decNilaiNominal + decNilaiBGC) > Convert.ToDecimal(lblSisaUM.Text)))
                {
                    MessageBox.Show("Nominal Pelunasan lebih besar dari pada harga kesepakatan penjualan !");
                    txtNominal.Focus();
                    return false;
                }
                if ((_kodeTrans == "UMK") && ((decNilaiNominal + decNilaiBGC) > (Convert.ToDecimal(lblSisaUM.Text))))
                {
                    MessageBox.Show("Nominal Pelunasan lebih besar dari pada Uang Muka !");
                    txtNominal.Focus();
                    return false;
                }
                // diminta kalo leasing (LSG) harus sama nominalnya kalau non TLA
                if (GlobalVar.CabangID.Contains("06"))
                {
                }
                else
                {
                    if ((_kodeTrans == "LSG") && ((decNilaiNominal + decNilaiBGC) != Convert.ToDecimal(lblSisaUM.Text)))
                    {
                        MessageBox.Show("Nominal Pelunasan tidak sama dengan harga kesepakatan penjualan !");
                        txtNominal.Focus();
                        return false;
                    }
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

        private void penerimaanUMInsert(ref Database db, ref int counterdb, Decimal decNilaiNominal, Decimal decNilaiBGC, int bentukPembayaran, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid penerimaanUangDendaRowID, Guid penerimaanPBLRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));

            // sebelumnya -- db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            // sekarang dibuat kalo proses tarikan, _kodeTrans itu selalu dianggap "TRK"
            if (_mode == "Tarikan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "TRK"));
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            }


            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            if (_mode == "Tarikan") // kalau tarikan selalu 5
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5)); // kalau tarikan selalu 5
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, bentukPembayaran));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));

            if (kenaDenda == true)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, Denda));
            }
            // kalau _flagSource nya Baru dan ada bunga, masukkin
            if ((_flagSource == "BARU" || GlobalVar.CabangID.Contains("06")) && kenaBunga == true && Convert.ToDouble(Tools.isNull(txtBunga.Text, "0").ToString()) > 0)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, Convert.ToDouble(txtBunga.Text)));
            }
            if (_mode == "Tarikan")
            {
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }

            /* // data penerimaan denda masuknya di tabel penerimaandenda saja
            if (kenaDenda == true && cbxDenda.Checked == true) // memang dibayar
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@penerimaanDendaRowID", SqlDbType.UniqueIdentifier, penerimaanUangDendaRowID));
            }
            */

            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
            }

            counterdb++;
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
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
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

        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            String KodeTrans = string.Empty;
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPenerimaan = "T"; break;

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
            // ambil kodetrans dulu buat tau tipe angsurannya
            // usp_Penjualan_LIST   dengan @RowID = _penjRowID
            using (Database dbfsub = new Database())
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_Pelunasan_LIST_ALL"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                KodeTrans = dtfsub.Rows[0]["KodeTrans"].ToString();
            }

            //using (Database dbfsub = new Database())
            //{
            //    DataTable dtfsub = new DataTable();
            //    dbfsub.Commands.Add(dbfsub.CreateCommand("usp_Penjualan_LIST"));
            //    dbfsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
            //    dtfsub = dbfsub.Commands[0].ExecuteDataTable();
            //    KodeTrans = dtfsub.Rows[0]["KodeTrans"].ToString();
            //}
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                if (penerimaanUangRowID == penerimaanUangDendaRowID) // berarti lagi nginput yg denda 
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLADenda).ToString()));
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLADenda).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.Denda).ToString()));
                    }
                }
                if (penerimaanUangRowID == penerimaanUangUMBungaRowID) // berarti lagi nginput yg UMBunga
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAUMBunga).ToString()));
                }
                else if (KodeTrans == "FLT")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangBungaTetap).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.FLT).ToString()));
                    }
                }
                else if (KodeTrans == "APD")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangBungaMenurun).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.APD).ToString()));
                    }
                }
                else if (KodeTrans == "UMK")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMK).ToString()));
                }
                else if (KodeTrans == "LSG")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangPokokLeasing).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.LSG).ToString()));
                    }
                }
                else if (KodeTrans == "TUN")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangUangMuka).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TUN).ToString()));
                    }
                }
                //tambahan utk penjualan bekas 06a ke cabang
                else if (KodeTrans == "BKS")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangUangMuka).ToString())); // sama kayak penjTunai baru,ga jadi masuk hutang hi tarikan
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TUN).ToString()));
                    }
                }
                else if (KodeTrans == "CTP")
                {

                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangUangMuka).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.CTP).ToString()));
                    }
                }
                else
                {
                    throw (exDE);
                }

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

            if (penerimaanUangRowID == penerimaanUangDendaRowID) // berarti lagi nginput yg denda
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtBayarDenda.GetDoubleValue));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, txtBayarDenda.GetDoubleValue));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Pelunasan Tunai Denda | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            }
            else if (penerimaanUangRowID == penerimaanUangUMBungaRowID) // berarti lagi nginput yg UMbunga
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtBayarBunga.GetDoubleValue));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, txtBayarBunga.GetDoubleValue));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Pelunasan Tunai UMBunga | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            }
            else
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominal.Text)));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Pelunasan Tunai | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            }

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini uang muka 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        // untuk masukkan data pembulatan
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
                case 3: JnsPenerimaan = "T"; break;// kalau titipan + tunai bisa ke sini
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Pembulatan " + cboPembulatan.Text + " untuk Pelunasan | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini administrasi 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }


        // kalo tarikkan masukkan ke PengeluaranUang
        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran, Guid VendorRowID, Double NominalKeluar, String JnsTransaksi, String InFix)
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

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID));
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

        private void penerimaanDendaInsert(ref Database db, ref int counterdb, Guid PenerimaanDenda, Guid SrcRowID, String Src, Double Nominal, Guid penerimaanUangRowID_Denda, String NoTransDenda)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenDendaRowID", SqlDbType.UniqueIdentifier, PenerimaanDenda));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDendaRowID", SqlDbType.UniqueIdentifier, SrcRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDenda", SqlDbType.VarChar, Src));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTransDenda));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, txtTglLunas.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, (cbxBentukPembayaran.SelectedIndex + 1)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            if (Convert.ToDecimal(txtDenda.Text) > 0 && cbxDenda.Checked == true) // memang dibayarkan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowIDDND", SqlDbType.UniqueIdentifier, penerimaanUangRowID_Denda));
            }

            counterdb++;
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
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTransUMBunga));

            if (Convert.ToDecimal(txtBunga.Text) > 0 && cbxBunga.Checked == true) // memang dibayarkan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }

            counterdb++;
        }

        private void pembayaranPembInsert(ref Database db, ref int counterdb, Guid pengeluaranUangRowID, String Ket, Double Nominal)
        {
            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid())); // _rowID
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            Decimal decNilaiBGC = 0;
            Decimal decNilaiNominal = 0;
            int bentukPembayaran = 1;
            System.Guid rekeningPembayaranRowID = System.Guid.Empty;
            Guid penerimaanPBLRowID = Guid.NewGuid();
            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            int counterdb = 0, counterdbf = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                decNilaiNominal = Convert.ToDecimal(txtPokok.Text); // sebelumnya Convert.ToDecimal(txtNominal.Text);

                if (ValidateSave(ref decNilaiNominal, ref decNilaiBGC, ref bentukPembayaran, ref rekeningPembayaranRowID))
                {

                }
                else
                {
                    return;
                }
                Guid penerimaanUangRowID;
                penerimaanUangRowID = Guid.NewGuid();

                // kalo udah sukses sampe sini baru buat notrans
                lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                bentukPembayaran = (cbxBentukPembayaran.SelectedIndex + 1);

                penerimaanUMInsert(ref db, ref counterdb, decNilaiNominal, decNilaiBGC, bentukPembayaran, rekeningPembayaranRowID, penerimaanUangRowID, penerimaanUangDendaRowID, penerimaanPBLRowID);

                //simpan tarikan 
                if (_mode == "Tarikan")
                {
                    String tempBentukPenerimaan = "";
                    String NoTransPengeluaran = "";
                    Guid tempVendorRowID = Guid.Empty;
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


                    tempVendorRowID = simpanTarikan(ref db, ref counterdb);
                    if (ntbBiayaKolektor.GetDoubleValue > 0)
                    {
                        // ini untuk biaya kolektor
                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
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
                    NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                    pengeluaranUangInsert(ref dbf, ref counterdbf, (Guid) Guid.NewGuid(), tempBentukPenerimaan, NoTransPengeluaran, tempVendorRowID);
                    */
                }
                else
                {
                    // masukkin data ke penerimaan Uang

                    // buat no Bukti PenerimaanUang baru
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

                    if (cbxBentukPembayaran.SelectedIndex + 1 == 4)
                    {
                        Guid PenerimaanDendaNewRowID = Guid.NewGuid();
                        penerimaanTitipanIdenInsert(ref db, ref counterdb, _rowID, PenerimaanDendaNewRowID);

                        if (modeBayarTitipan == 1) // ini berarti titipan + tunai
                        {
                            penerimaanTitipanInsertTambahanTunai(ref db, ref counterdb, tambahanTunaiTitipan, _rowID, lblNoTrans.Text, ref dbf, ref counterdbf, penerimaanPBLRowID);
                        }
                    }
                    else
                    {

                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                    "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                    , 4, false, true);

                        penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanUangRowID, NoTransPenerimaan);
                    }

                    if (kenaDenda == true)
                    {
                        if (cbxDenda.Checked == true && Convert.ToDouble(txtBayarDenda.Text) > 0) // berarti dibayarkan dendanya, masuk ke penerimaan uang
                        {
                            Database dbfNumeratordenda = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaandenda = Numerator.GetNomorDokumen(dbfNumeratordenda, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanUangDendaRowID, NoTransPenerimaandenda);

                            // masuk ke penerimaan denda juga
                            Guid penerimaanDendaNewRowID = Guid.NewGuid();
                            String NoTransDenda = Numerator.NextNumber("NKD");
                            penerimaanDendaInsert(ref db, ref counterdb, penerimaanDendaNewRowID, _rowID, "Pelunasan", Convert.ToDouble(txtBayarDenda.Text.ToString()), penerimaanUangDendaRowID, NoTransDenda);
                        }
                        else if (cbxDenda.Checked == false) // ngga mau bayar denda
                        {
                            // kalo ngga bayar dendanya...
                            // ngga usah masukkin data ke penerimaanUang dan penerimaanDenda
                        }
                    }

                    if (kenaBunga == true)
                    {
                        if (cbxBunga.Checked == true && Convert.ToDouble(txtBayarBunga.Text) > 0 && Convert.ToDouble(txtBunga.Text) > 0) // berarti dibayarkan bunganya
                        {
                            Database dbfNumeratorUMBunga = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaanUMBunga = Numerator.GetNomorDokumen(dbfNumeratorUMBunga, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanUangUMBungaRowID, NoTransPenerimaanUMBunga);

                            // masuk ke penerimaan UMBunga juga
                            Guid penerimaanUMBungaNewRowID = Guid.NewGuid();
                            String NoTransUMBunga = Numerator.NextNumber("NKU");
                            penerimaanUMBungaInsert(ref db, ref counterdb, penerimaanUMBungaNewRowID, _rowID, Convert.ToDouble(txtBayarBunga.Text.ToString()), penerimaanUangUMBungaRowID, NoTransUMBunga);
                        }
                        else if (cbxBunga.Checked == false) // ngga mau bayar UMBunga
                        {
                        }
                    }
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

                String messageTemp;
                messageTemp = "Data berhasil ditambahkan. \n";

                if (kenaDenda)
                {
                    messageTemp = messageTemp + "Terkena Denda : " + Denda + ".\n";
                }

                MessageBox.Show(messageTemp);
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

        // di Penerimaan Titipan 1 data kayak biasa
        private void penerimaanTitipanInsert(ref Database db, ref int counterdb, Double decNilaiBGC, Guid newRowID, String newNoTrans)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, newNoTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); //GlobalVar.GetServerDate
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.UM));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            counterdb++;
        }

        // kalo penerimaan titipan yg tunai tambahan langsung ke titipan, titipaniden, dan penerimaanuang
        private void penerimaanTitipanInsertTambahanTunai(ref Database db, ref int counterdb, Double decNilai, Guid newRowID, String newNoTrans, ref Database dbf, ref int counterdbf, Guid penerimaanPBLRowID)
        {
            Guid PenerimaanUangRowIDTambahan = Guid.NewGuid();
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            String KodeTrans = string.Empty;
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; break;
                case 3: JnsPenerimaan = "K"; break;
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
            // ambil kodetrans dulu buat tau tipe angsurannya
            // usp_Penjualan_LIST   dengan @RowID = _penjRowID
            using (Database dbfsub = new Database())
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_Penjualan_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                KodeTrans = dtfsub.Rows[0]["KdTrans"].ToString();
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TTP).ToString()));  // Titipan Murni/TTP -> Penerimaan Belum Iden (31)
                /*
                if (KodeTrans == "FLT")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PiutangBunga).ToString()));  // ANG 36 - Piutang Bunga
                }
                else if (KodeTrans == "APD")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString()));  // ANG 18 - Pendapatan Bunga Kredit
                }
                else
                {
                    throw (exDE);
                }
                */

                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            String notransTitipTunai = Numerator.NextNumber("NTP");
            // ke penerimaan titipan dulu
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, notransTitipTunai));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // GlobalVar.GetServerDate
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilai)); // tunai
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, 0)); // bukan giro
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1)); // harus tunai
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, null));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, ""));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Murni));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowIDTambahan));

            /*
             * kena pembulatan tapi data pembulatannya di angsurannya aja!!!
            // di penerimaan Titipan kalau lagi yang bayar angsuran dengan Titipan+Tunai kena pembulatan
            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
            }
            */

            counterdb++;

            // ke penerimaan titipaniden
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, decNilai));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;

            string tempBentukPenerimaan = "K"; // mestinya sih selalu K
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
            Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
            String NoTransPenerimaanBaru = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                        string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                        , 4, false, true);

            // ke penerimaanuang

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowIDTambahan));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaanBaru)); // tadinya newNoTrans txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilai));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, decNilai));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (txtUraian.Text + " - Tambahan titipan Tunai") + " | " + lblNama.Text + " | " + _nopol));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini angsuran 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void updateLogST(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@isProcessed", SqlDbType.TinyInt, 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void penerimaanTitipanIdenInsert(ref Database db, ref int counterdb, Guid PenerimaanUMRowID, Guid PenerimaanDendaRowID)
        {
            Double NominalDenda = 0;
            Double Nominal = txtNominal.GetDoubleValue;
            Double tempCurrAmount = 0;
            Double tempCurrInsert = 0;
            if (kenaDenda == true && cbxDenda.Checked == true && txtBayarDenda.GetDoubleValue > 0)
            {
                NominalDenda = txtBayarDenda.GetDoubleValue;
            }
            foreach (AngsuranIden rowAngsuranIden in _listAngsuranIden)
            {
                tempCurrAmount = rowAngsuranIden.NominalIden;
                if (tempCurrAmount > 0 && NominalDenda > 0)
                {
                    if (tempCurrAmount >= NominalDenda)
                    {
                        tempCurrInsert = NominalDenda;
                        tempCurrAmount = tempCurrAmount - NominalDenda;
                        NominalDenda = 0;
                    }
                    else if (tempCurrAmount < NominalDenda)
                    {
                        tempCurrInsert = tempCurrAmount;
                        tempCurrAmount = 0;
                        NominalDenda = NominalDenda - tempCurrAmount;
                    }
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAngsuranIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanDNDRowID", SqlDbType.UniqueIdentifier, PenerimaanDendaRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // GlobalVar.GetServerDate
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
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAngsuranIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); //GlobalVar.GetServerDate
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrInsert));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
                if (tempCurrAmount > 0 && Nominal < 1 && NominalDenda < 1) // kalau masih ada sisa juga, masukkin ke angsurannya aja
                {
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAngsuranIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // GlobalVar.GetServerDate
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrAmount));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
            }
        }


        private void frmPelunasanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPelunasanBrowse)
            {
                Penjualan.frmPelunasanBrowse frmCaller = (Penjualan.frmPelunasanBrowse)this.Caller;
                frmCaller.RefreshRowPiutang(_penjRowID);
                frmCaller.FindRowGrid2("mKodeTrans", _kodeTrans);
                frmCaller.RefreshRowLunas(_rowID);
                frmCaller.FindRowGrid3("dRowID", _rowID.ToString());
            }
        }

        private void txtTglLunas_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = false;

                txtBunga.ReadOnly = false;
                txtNominal.ReadOnly = false;
                
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = true;

                txtBunga.ReadOnly = false;
                txtNominal.ReadOnly = false;
                
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                txtBunga.ReadOnly = false;
                txtNominal.ReadOnly =false;
                
                if (kenaDenda == true || Denda > 0)
                {
                    MessageBox.Show("Pembayaran terlambat yang terkena denda tidak dapat menggunakan giro sebagai bentuk pembayaran!");
                    cbxBentukPembayaran.SelectedIndex = 0;
                    cbxBentukPembayaran.Focus();
                }
                else
                {
                    EnabledControlBG();
                    lookUpRekening1.Enabled = false;
                }
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                cbxDenda.Enabled = false;
                DisabledControlBG();
                lookUpRekening1.Enabled = false;

                _selectedAngsuranDetail = new AngsuranDetail();
                _selectedAngsuranDetail.CustomerRowID = _CustomerRowID;
                _selectedAngsuranDetail.CustomerName = lblNama.Text;
                _selectedAngsuranDetail.SaldoPiutangPokok = Convert.ToDouble(lblSisaUM.Text);
                _selectedAngsuranDetail.NominalPembayaran = Convert.ToDouble(lblSisaUM.Text);


                _selectedAngsuranDetail.Denda = 0;//Convert.ToDouble(txtBayarDenda.Text);
                _selectedAngsuranDetail.TotalAngsuran = 0;// (Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtPokok.Text));
                _selectedAngsuranDetail.PotonganBunga = 0;// Convert.ToDouble(txtBayarPokok.Text);
                _selectedAngsuranDetail.BayarBunga = 0;// Convert.ToDouble(txtBunga.Text);

                if (_kodeTrans == "TUN")
                {
                    _selectedAngsuranDetail.BayarBunga = 0;
                }

                _selectedAngsuranDetail.MataUangID = cboMataUang.SelectedValue.ToString();
                _selectedAngsuranDetail.TipeBunga = _kodeTrans;

                _listAngsuranIden = new List<AngsuranIden>();
                Penjualan.frmAngsuranIden ifrmChild = new Penjualan.frmAngsuranIden(this, _selectedAngsuranDetail, _listAngsuranIden, "Leasing", _kodeTrans);
                ifrmChild.ShowDialog();
                modeBayarTitipan = 99;
                modeBayarTitipan = ifrmChild.modeBayar;
                if (modeBayarTitipan == 1) // ini berarti titipan + tunai
                {
                    tambahanTunaiTitipan = ifrmChild.nominalTambahan;
                    tambahanTunaiTitipanPembulatan = ifrmChild.nominalPembulatan;
                    bayarBulatTambahanTunaiTitipan = ifrmChild.nominalBayarTunaiBulat;
                }
                txtNominal.Text = _selectedAngsuranDetail.TotalNominalIden.ToString();

                if (_kodeTrans == "CTP")
                {
                    txtPokok.Text = _selectedAngsuranDetail.TotalNominalIden.ToString();
                }
                txtBunga.ReadOnly = true;
                txtNominal.ReadOnly = true;
                if (!txtUraian.Text.ToLower().Contains("titipan"))
                {
                    txtUraian.Text = txtUraian.Text + " (TITIPAN)";
                }
                ////this.refresh();
                //cbxBentukPembayaran.Enabled = true;
                //txtPembayaran.Enabled = false;
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

        private void ntbBiayaTarikan_TextChanged(object sender, EventArgs e)
        {
            updateTxtNominal();
        }

        private void updateTxtNominal()
        {
            if (_mode == "Tarikan")
            {   // kalo tarikan denda ngga usah dulu // + Denda 
                txtNominal.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(ntbBiayaTarikan.Text)).ToString();
            }
        }

        private void cbxDenda_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDenda.Checked == true) // bayar denda
            {
                txtBayarDenda.Text = txtDenda.Text;
                // txtNominal.Text = (Convert.ToDouble(txtNominal.Text) + Convert.ToDouble(txtDenda.Text)).ToString();
            }
            else if (cbxDenda.Checked == false) // ngga bayar denda
            {
                txtBayarDenda.Text = "0";
                // txtNominal.Text = (Convert.ToDouble(txtNominal.Text) - Convert.ToDouble(txtDenda.Text)).ToString();
            }
            // kalau ada bayar denda, sekarang itu kehitung HANYA pembulatannya, nominal bayarnya juga tapi tidak masuk ke database
            refreshPembulatan();
        }

        private void refreshPembulatan()
        {
            // saat pelunasan
            Double byrdenda = Convert.ToDouble(txtBayarDenda.Text);
            Double byrbunga = Convert.ToDouble(txtBayarBunga.Text);
            Double nominal = txtNominal.GetDoubleValue;
            Double Value = byrdenda + byrbunga + nominal;
            Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
            txtNominalPembulatan.Text = (PBLValue - Value).ToString();
            txtNominalPembayaranPBL.Text = PBLValue.ToString();
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

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            if (txtNominal.GetDoubleValue > Convert.ToDouble(lblSisaUM.Text))
            {
                txtNominal.Text = lblSisaUM.Text;
            }
            txtPokok.Text = txtNominal.Text;
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

        private void txtBunga_Leave(object sender, EventArgs e)
        {
            if (txtBunga.GetDoubleValue < UMBunga)
            {
                MessageBox.Show("Bunga yg diberikan tidak bisa lebih kecil dari perhitungan awal, gunakan fitur potongan saat bayar di layar UMBunga!");
                txtBunga.Text = UMBunga.ToString("N2");
                txtBunga.Focus();
            }
            if (cbxBunga.Checked == true)
            {
                txtBayarBunga.Text = txtBunga.Text;
                refreshPembulatan();
            }
        }


        private void refreshData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST_ALL"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                dt = db.Commands[0].ExecuteDataTable();

                if (_kodeTrans == "CTP")
                {
                    if (txtTglLunas.DateValue >= tglJTUM)
                    {
                        kenaDenda = true;
                        // rumus denda -> (harga jadi + BBN - TerimaUM) * 3%
                        Denda = ((Convert.ToDouble(Tools.isNull(dt.Rows[0]["HargaJadi"], 0))
                               + Convert.ToDouble(Tools.isNull(dt.Rows[0]["BBN"], 0))
                               - Convert.ToDouble(Tools.isNull(dt.Rows[0]["Nominal"], 0)))
                               / 100) * 3;
                    }
                }
                else
                {
                    kenaDenda = false;
                    Denda = 0;
                }
                txtDenda.Text = Denda.ToString();

                if (kenaDenda == true)
                {
                    cbxDenda.Enabled = true;
                    cbxDenda.Checked = true;
                    txtBayarDenda.Text = txtDenda.Text;
                }

                // yang mesti dibayar total -> pokok + denda
                txtNominal.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0))).ToString(); // jangan itung dendanya Denda + 

                if (_flagSource == "BARU" || GlobalVar.CabangID.Contains("06")) // karena ADS itu ORI
                {
                    // jadinya itu ngga ada denda, adanya kena bunga
                    txtDenda.Text = "0";
                    txtBayarDenda.Text = "0";
                    cbxDenda.Enabled = false;
                    kenaDenda = false;
                    Denda = 0;

                    if (_kodeTransPJL == "CTP" || _kodeTransPJL == "TUN") // (_kodeTrans == "CTP" || _kodeTrans == "TUN" || _kodeTrans == "UMK")
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

                        if (txtTglLunas.DateValue >= tglJTUM)
                        {
                            int pengaliBunga = 0;//-1;
                            DateTime templooper = tglJTUM;
                            while (templooper <= GlobalVar.GetServerDate.Date)
                            {
                                pengaliBunga = pengaliBunga + 1;
                                templooper = templooper.AddMonths(1);
                            }
                            kenaBunga = true;
                            // rumus Bunga -> (harga jadi + BBN - TerimaUM) * 3%
                            UMBunga = ((Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)) / 100) * _bungaUM) * pengaliBunga;
                        }
                    }
                    else
                    {
                        kenaBunga = false;
                        UMBunga = 0;
                    }
                    txtBunga.Text = UMBunga.ToString();

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
            }
            // ngga bisa bayar denda di sini
            cbxDenda.Enabled = false;
            cbxDenda.Checked = false;
            txtBayarDenda.Text = "0";
            cbxDenda.Visible = false;

            // ngga bisa bayar um bunga di sini
            cbxBunga.Enabled = false;
            cbxBunga.Checked = false;
            txtBayarBunga.Text = "0";
            cbxBunga.Visible = false;

            refreshPembulatan();
        }

        private void txtTglLunas_Leave(object sender, EventArgs e)
        {
            refreshData();
        }

    }
}
