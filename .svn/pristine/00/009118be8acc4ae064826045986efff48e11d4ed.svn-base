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
    public partial class frmAngsuranRefinance : ISA.Controls.BaseForm
    {
        Guid _penjRowID = Guid.Empty;
        Guid _penjHistRowID = Guid.Empty;
        Guid _custRowID = Guid.Empty;
        Double _saldoHutangDenda = 0;
        String _nopol = String.Empty;

        Double _Denda = 0;
        DateTime _nextJTAngs = DateTime.MinValue;
        Double _nextAngs = 0;

        public frmAngsuranRefinance()
        {
            InitializeComponent();
        }

        public frmAngsuranRefinance(Form dCaller, Guid PenjRowID, Guid PenjHistRowID)
        {
            InitializeComponent();
            Caller = dCaller;
            _penjRowID = PenjRowID;
            _penjHistRowID = PenjHistRowID;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool validateSave()
        {
            // yang perlu divalidasi itu data inputan yg baru aja
            if (string.IsNullOrEmpty(txttglRefinance.Text)) 
            {
                MessageBox.Show("Tanggal Refinancing belum diisi !");
                txttglRefinance.Focus();
                return false;
            }
            
            if ( Convert.ToInt32(txtTempoBaru.Text) == 0)
            {
                MessageBox.Show("Tempo cicilan baru tidak bisa 0 kali");
                txtTempoBaru.Focus();
                return false;
            }

            if ((Tools.isNull(txtTglAwalAngsuran.DateValue, "").ToString() == ""))
            {
                MessageBox.Show("Tolong isikan Tanggal Awal Angsuran terlebih dahulu !");
                txtTglAwalAngsuran.Focus();
                return false;
            }

            if ((txtTglAwalAngsuran.DateValue < txttglRefinance.DateValue))
            {
                MessageBox.Show("Tanggal Awal Angsuran lebih kecil dari pada Tanggal Refinancing !");
                txtTglAwalAngsuran.Focus();
                return false;
            }

            if ((txtTglAwalAngsuran.DateValue > GlobalVar.GetServerDate))
            {
                MessageBox.Show("Tanggal Awal Angsuran tidak boleh melebihi tanggal hari ini!");
                txtTglAwalAngsuran.Focus();
                return false;
            }

            if ((txtTglAwalAngsuran.DateValue > txttglRefinance.DateValue.Value.AddMonths(1)))
            {
                MessageBox.Show("Tanggal Awal Angsuran tidak boleh lebih dari 1 bulan dari tanggal penjualan !");
                txtTglAwalAngsuran.Focus();
                return false;
            }

            if (((DateTime)txttglRefinance.DateValue).Date < GlobalVar.GetServerDate.Date)
            {
                MessageBox.Show("Tanggal Refinancing lebih kecil dari pada Tanggal Sekarang !");
                txttglRefinance.Focus();
                return false;
            }

            // kalo nominal potongannya lebih besar dari nominal perpindahan itu ngga boleh
            if( Convert.ToDouble(txtPotongan.Text) > Convert.ToDouble(txtNominalPerpindahan.Text) )
            {
                MessageBox.Show("Nominal Potongan tidak bisa melebihi Nominal Perpindahan!");
                txtPotongan.Focus();
                return false;
            }

            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (validateSave())
            {
                Database db = new Database();
                int counterdb = 0;

                try
                {
                    Guid newRowIDPembelian = Guid.NewGuid();

                    // habis ditarik langsung masukkin ke data penjualan
                    simpanTarikan(ref db, ref counterdb, newRowIDPembelian);
                    penjualanInsert(ref db, ref counterdb, newRowIDPembelian);

                    // masukkin data penerimaan angsuran sebagai pembulat 
                    penerimaanAngsuranInsert(ref db, ref counterdb);

                    db.BeginTransaction();
                    int looper = 0;
                    for (looper = 0; looper < counterdb; looper++)
                    {
                        db.Commands[looper].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                    MessageBox.Show("Data berhasil diproses");
                    this.Close();
                }
                catch(Exception ex)
                {
                    db.RollbackTransaction();
                    MessageBox.Show("Data gagal diproses !\n" + ex.Message);
                }

            }
            else
            {
            }
        }

        private void frmAngsuranRefinance_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            DataTable dummy = new DataTable();
            using(Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanAngsuran_for_Refinancing"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                dummy = db.Commands[0].ExecuteDataTable();
            }

            if(dummy.Rows.Count > 0)
            {
                // bagian yg dari db cukup
                
                // global dulu
                _custRowID = (Guid) Tools.isNull(dummy.Rows[0]["CustomerRowID"], Guid.Empty); 
                _nopol = Tools.isNull(dummy.Rows[0]["NoPol"], "").ToString();
                _nextAngs = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["angsuranke"], 0));
                _nextJTAngs = Convert.ToDateTime(Tools.isNull(dummy.Rows[0]["tgljtangsuran"], DateTime.MinValue));

                txtNoTransLama.Text = Tools.isNull(dummy.Rows[0]["NoTrans"], "").ToString();
                txtTglPenjualan.Text = String.Format("{0:dd-MM-yyyy}", Tools.isNull(dummy.Rows[0]["TglJual"], DateTime.MinValue).ToString()); 
                txtCustomer.Text = Tools.isNull(dummy.Rows[0]["NamaCustomer"], "").ToString();
                txtAlamat.Text = Tools.isNull(dummy.Rows[0]["Alamat"], "").ToString();
                txtKecamatan.Text = Tools.isNull(dummy.Rows[0]["KelKec"], "").ToString();
                txtKota.Text = Tools.isNull(dummy.Rows[0]["KotaProv"], "").ToString();
                txtTempoLama.Text = Tools.isNull(dummy.Rows[0]["Tempo"], 0).ToString();
                txtAngsuranBerjalan.Text = Tools.isNull(dummy.Rows[0]["AngsuranBerjalan"], 0).ToString();

                txtHrgPenjualanLama.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["Harga"], 0)).ToString();
                txtTerimaUM.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["TerimaUM"], 0)).ToString();
                txtPiutangPokokLama.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["PiutangPokok"], 0)).ToString();
                txtTerimaAngsuran.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["TerimaAngsuran"], 0)).ToString();
                txtSaldoPiutangPokok.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["SaldoPiutangPokok"], 0)).ToString();
                txtTerimaDenda.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["TerimaDenda"], 0)).ToString();

                // bagian yang ada rumus perhitungan

                _Denda = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["Denda"], 0).ToString());
                Double tempHutangDenda = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["HutangDenda"], 0).ToString());
                _saldoHutangDenda = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["HutangDenda"], 0)) - Convert.ToDouble(Tools.isNull(dummy.Rows[0]["TerimaDenda"], 0));
                Double tempNominalPerpindahan = 0;
                Double tempHargaJualBaru = 0;

                // harga jual baru itu -> saldo piutang pokok + saldo hutang denda ++ tambahan, ditambah denda juga jadi sama seperti nominal perpindahan
                // nominal perpindahan itu -> saldo piutang pokok + saldo hutang denda + denda jika dibayar di bulan tersebut
                tempNominalPerpindahan = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["SaldoPiutangPokok"], 0)) + _saldoHutangDenda + _Denda;
                tempHargaJualBaru = tempNominalPerpindahan;

                txtHutangDenda.Text = (_saldoHutangDenda + _Denda).ToString();
                txtNominalPerpindahan.Text = tempNominalPerpindahan.ToString();

                txtPotongan.Text = "0"; // potongan itu defaultnya 0
                txtNoTransBaru.Text = txtNoTransLama.Text + "R";
                txttglRefinance.Text = String.Format("{0:dd-MM-yyyy}", GlobalVar.GetServerDate);
                txtTipeBunga.Text = "FLT - Bunga Tetap";
                txtTempoBaru.Text = (24 - Convert.ToInt32(txtTempoLama.Text)).ToString();
                txtHrgPenjualanBaru.Text = (tempHargaJualBaru - Convert.ToDouble(txtPotongan.Text)).ToString();
                txtPiutangPokokBaru.Text = (tempHargaJualBaru - Convert.ToDouble(txtPotongan.Text)).ToString();
                txtTglAwalAngsuran.Text = String.Format("{0:dd-MM-yyyy}", GlobalVar.GetServerDate);

            }
            
        }

        private void txtTempoBaru_Leave(object sender, EventArgs e)
        {
            bool isNum;
            int tempTempoBaru;
            int TempoLama;

            isNum = int.TryParse(txtTempoBaru.Text, out tempTempoBaru);
            TempoLama = Convert.ToInt32(Tools.isNull(txtTempoLama.Text, 0));
            if(isNum == true)
            {
            }
            else
            {
                tempTempoBaru = 0;
            }
            // kalo ditotal itu lebih dari 24, mesti minta PIN
            if (TempoLama + tempTempoBaru > 24)
            {
                // kalo lewat, minta pin
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.RefinanceOverTempo), "Tempo maksimal 24 bulan, lebih dari itu perlu PIN persetujuan!");
                if (GlobalVar.pinResult == false)
                {
                    txtTempoBaru.Text = (24 - Convert.ToInt32(txtTempoLama.Text)).ToString();
                    txtTempoBaru.Focus();
                    return; 
                }
            }
        }

        #region DBFunctions


        private Guid simpanTarikan(ref Database db, ref int counterdb, Guid newRowIDPembelian)
        {
            //Simpan Info Tarikan 
            System.Guid guidVendorRowID = System.Guid.Empty;
            db.Commands.Add(db.CreateCommand("usp_tarikanpenjualan_update"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, txttglRefinance.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, ( Convert.ToDouble(txtNominalPerpindahan.Text) - Convert.ToDouble(txtPotongan.Text) ) )); // selalu nominalperpindahan - potongan
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanKolektor", SqlDbType.Money, 0)); // dibuat 0 ???
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanLainLain", SqlDbType.Money, 0)); // dibuat 0 ???
            db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganTarikan", SqlDbType.VarChar, "Tarikan untuk Refinancing | " + _nopol + " | " + txtCustomer.Text));
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
            db.Commands[counterdb].Parameters.Add(new Parameter("@NewRowID", SqlDbType.UniqueIdentifier, newRowIDPembelian));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, guidVendorRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, txttglRefinance.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, (Convert.ToDouble(txtNominalPerpindahan.Text) - Convert.ToDouble(txtPotongan.Text)) )); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserInitial));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTransPembayaranPembelian", SqlDbType.VarChar, Numerator.NextNumber("NTB")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTarikan", SqlDbType.VarChar, "REF")); // kodenya refinancing
            counterdb++;

            return guidVendorRowID;
        }


        private void penjualanInsert(ref Database db, ref int counterdb, Guid newRowIDPembelian)
        {
            // ambil data penjualan lamanya !
            DataTable dummy = new DataTable();
            using (Database dbsub = new Database())
            {
                dbsub.Commands.Add(db.CreateCommand("usp_Penjualan_LIST"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dummy = dbsub.Commands[0].ExecuteDataTable();
            }

            db.Commands.Add(db.CreateCommand("usp_Penjualan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, newRowIDPembelian ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoTransBaru.Text)); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar,  Numerator.NextNumber("NFJ") ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, txttglRefinance.DateValue)); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, _custRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, (Guid) dummy.Rows[0]["SalesRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, (Guid)dummy.Rows[0]["KolektorRowID"] ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, "K")); // pasti kredit
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"].ToString()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, (Convert.ToDouble(txtNominalPerpindahan.Text) - Convert.ToDouble(txtPotongan.Text)) ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BBN", SqlDbType.Money, 0)); // default 0
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaADM", SqlDbType.Money, 0)); // default 0
            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, (Convert.ToDouble(txtNominalPerpindahan.Text) - Convert.ToDouble(txtPotongan.Text)) ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "FLT")); // selalu angsuran FLT di refinancing
            db.Commands[counterdb].Parameters.Add(new Parameter("@Via", SqlDbType.VarChar, dummy.Rows[0]["Via"].ToString() ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Int, Convert.ToInt32(txtTglAwalAngsuran.Text.ToString().Substring(0, 2))));
            db.Commands[counterdb].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, 0)); // default 0 ngga ada uang muka
            db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(dummy.Rows[0]["Bunga"])));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(dummy.Rows[0]["Pembulatan"].ToString())));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, int.Parse(txtTempoBaru.Text))); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngsuran.DateValue));

            DateTime TglAkhirAngs = txtTglAwalAngsuran.DateValue.Value.AddMonths(int.Parse(txtTempoBaru.Text));

            db.Commands[counterdb].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, TglAkhirAngs));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, "Data Penjualan baru inputan dari Refinancing untuk | " + _nopol + " | " + txtCustomer.Text ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        // pas melakukan save simpan juga 1 data penerimaanAngsuran biar transaksi yang di Refinancing itu saldonya jadi 0

        private void penerimaanAngsuranInsert(ref Database db, ref int counterdb )
        {
            // ambil data penjualan lamanya !
            DataTable dummy = new DataTable();
            using (Database dbsub = new Database())
            {
                dbsub.Commands.Add(db.CreateCommand("usp_Penjualan_LIST"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dummy = dbsub.Commands[0].ExecuteDataTable();
            }

            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid() )); // guid baru
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistRowID)); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKJ") )); // buat notrans baru
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, DBNull.Value )); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "REF" )); // di refinancing itu REF
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Penerimaan Angsuran Pelunasan Refinancing | " ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txttglRefinance.DateValue ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.Date, DBNull.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Date, _nextJTAngs));
            db.Commands[counterdb].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Float, _nextAngs ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"].ToString() ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, 0 )); // pas refinancing hanya pokoknya saja

            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDouble(txtSaldoPiutangPokok.Text) ));

            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0 )); // dianggap kas, jadi 0

            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPokok", SqlDbType.Money, Convert.ToDouble(txtSaldoPiutangPokok.Text) ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, _Denda )); // hanya denda bulan ini yg dimasukkin
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0 ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PotonganRefinance", SqlDbType.Money, Convert.ToDouble(txtPotongan.Text))); // potongan dari yg refinancing
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, (Guid)dummy.Rows[0]["KolektorRowID"] ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5 )); // jadiin nonkasir(5) --- sebelumnya anggap kas aja
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier,  Guid.Empty ));

            counterdb++;
        }



        #endregion

        private void txtPotongan_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Tools.isNull(txtPotongan.Text, 0)) > 0)
            {
                // berarti ada mau kasih potongan, mesti minta pin dulu
                // minta pin
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.RefinancePotongan), "Pemberian potongan harga saat melakukan Refinancing memerlukan PIN persetujuan!");
                if (GlobalVar.pinResult == false)
                {
                    txtPotongan.Text = "0";
                    txtPotongan.Focus();
                    return;
                }
                else
                {
                }
            }
            txtHrgPenjualanBaru.Text = (Convert.ToDouble(txtNominalPerpindahan.Text) - Convert.ToDouble(txtPotongan.Text)).ToString();
            txtPiutangPokokBaru.Text = (Convert.ToDouble(txtNominalPerpindahan.Text) - Convert.ToDouble(txtPotongan.Text)).ToString();
        }

    }
}
