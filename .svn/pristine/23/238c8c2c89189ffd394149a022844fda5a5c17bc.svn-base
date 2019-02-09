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
    public partial class frmPelunasanTambahUM : ISA.Controls.BaseForm
    {
        Guid _penjRowID;
        Guid _rowID = Guid.NewGuid();
        String _kodeTrans;
        String _nopol;

        public frmPelunasanTambahUM(Form Caller, Guid PenjRowID, String KodeTrans)
        {
            InitializeComponent();
            this.Caller = Caller;
            _penjRowID = PenjRowID;
            _kodeTrans = KodeTrans;
        }

        private void frmPelunasanTambahUM_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                if (_kodeTrans == "SBD")
                {
                    cboTipe.SelectedIndex = 0;
                }
                else if (_kodeTrans == "UMK")
                {
                    cboTipe.SelectedIndex = 1;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST_TambahUM"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    cboBentukPembayaran.SelectedIndex = 0;

                    if (dt.Rows.Count > 0)
                    {
                        txtTanggal.DateValue = GlobalVar.GetServerDate;

                        lblNamaCustomer.Text = Tools.isNull(dt.Rows[0]["NamaCustomer"], "").ToString();
                        lblAlamatCustomer.Text = Tools.isNull(dt.Rows[0]["AlamatCustomer"], "").ToString();
                        lblKotaProvCustomer.Text = Tools.isNull(dt.Rows[0]["KotaProvCustomer"], "").ToString();

                        lblNamaLeasing.Text = Tools.isNull(dt.Rows[0]["NamaLeasing"], "").ToString();
                        lblAlamatLeasing.Text = Tools.isNull(dt.Rows[0]["AlamatLeasing"], "").ToString();
                        lblKotaProvLeasing.Text = Tools.isNull(dt.Rows[0]["KotaProvLEasing"], "").ToString();

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

                        lblNoKwitansi.Text = "";
                        //cboTipe.Text = "DP Subsidi";
                        txtHarga.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["HargaOff"], 0).ToString()).ToString();
                        txtUangMuka.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["UangMuka"], 0).ToString()).ToString();
                        txtDPSubsidi.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DPSubsidi"], 0).ToString()).ToString();
                        txtDPPelanggan.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DPPelanggan"], 0).ToString()).ToString();

                        txtDPSubsidiTerbayar.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["TotalSBD"], 0).ToString()).ToString();
                        txtUMPelangganTerbayar.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["TotalUM"], 0).ToString()).ToString();

                        txtUraian.Text = "";
                        _nopol = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();
                    }

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateSave()
        {
            // kalau um + dpsubsidi/dppelanggan tambahan > dari harga itu ngga boleh
            if ((txtHarga.GetDoubleValue) < (txtUangMuka.GetDoubleValue + txtNominal.GetDoubleValue))
            {
                MessageBox.Show("Nominal tambahan Uang Muka tidak bisa melampaui harga yg ditetapkan!");
                return false;
            }

            if (txtTanggal.DateValue.Value.Date > GlobalVar.GetServerDate.Date || txtTanggal.DateValue.Value.Date < GlobalVar.GetServerDate.Date)
            {
                MessageBox.Show("Tanggal tidak dapat diubah!");
                txtTanggal.DateValue = GlobalVar.GetServerDate;
                return false;
            }

            if (cboBentukPembayaran.Text.ToString().ToLower() == "transfer")
            {
                if (Tools.isNull(lookUpRekening1.NamaRekening, "").ToString() == "" || lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    MessageBox.Show("Rekening Bank belum dipilih");
                    lookUpRekening1.Focus();
                    return false;
                }
            }

            if (    cboTipe.Text == "DP Subsidi" || cboTipe.Text == "DP Pelanggan" 
                 || cboTipe.Text == "Pengembalian DP Pelanggan" || cboTipe.Text == "Pengurangan DP Subsidi" )
            {
            }
            else
            {
                MessageBox.Show("Pilih Tipe DP yg akan ditambahkan terlebih dahulu!");
                return false;
            }

            if (txtNominal.GetDoubleValue < 1)
            {
                MessageBox.Show("Isikan nominal Tambahan UM terlebih dahulu!");
                return false;
            }

            if (cboTipe.Text == "Pengembalian DP Pelanggan" || cboTipe.SelectedIndex == 2)
            {
                if (Convert.ToDouble(Tools.isNull(txtNominal.Text, 0).ToString()) > txtUMPelangganTerbayar.GetDoubleValue)
                {
                    MessageBox.Show("Tidak bisa mengembalikan lebih dari yg dibayarkan pelanggan!");
                    txtNominal.Focus();
                    return false;
                }
            }

            if (cboTipe.Text == "Pengurangan DP Subsidi" || cboTipe.SelectedIndex == 3)
            {
                if (Convert.ToDouble(Tools.isNull(txtNominal.Text, 0).ToString()) > (txtDPSubsidi.GetDoubleValue - txtDPSubsidiTerbayar.GetDoubleValue))
                {
                    MessageBox.Show("Tidak bisa mengurangi lebih dari yg dp subsidi yg terdaftar!");
                    txtNominal.Focus();
                    return false;
                }
            }

            if (cboTipe.SelectedIndex != 0 && cboBentukPembayaran.SelectedIndex == 2) // bukan DPSubsidi ngga boleh bayar dengan Potongan Pembelian
            {
                MessageBox.Show("Invalid data!");
                cboBentukPembayaran.SelectedIndex = 0;
                return false;
            }

            return true;
        }

        private void updateTambahanUMPelunasan(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_TambahUM_Pelunasan"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TambahanUM", SqlDbType.VarChar, txtNominal.GetDoubleValue));
            if(cboTipe.Text == "DP Subsidi")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@TipeUM", SqlDbType.VarChar, "SBT"));
            }
            else if(cboTipe.Text == "DP Pelanggan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@TipeUM", SqlDbType.VarChar, "UMT"));
            }
            else if (cboTipe.Text == "Pengembalian DP Pelanggan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@TipeUM", SqlDbType.VarChar, "UMP"));
            }
            else if (cboTipe.Text == "Pengurangan DP Subsidi")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@TipeUM", SqlDbType.VarChar, "SBP"));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void DPDetailSubsidiInsert(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_DPSubsidiDetail_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtUraian.Text));
            if (cboTipe.SelectedIndex == 0) // DP Subsidi
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "SBT"));
            }
            else if (cboTipe.SelectedIndex == 1) // DP Pelanggan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMT"));
            } 
            else if (cboTipe.SelectedIndex == 2) // Pengembalian DP Pelanggan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMP"));
            }
            else if (cboTipe.SelectedIndex == 3) // Pengurangan DP Subsidi
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "SBP"));
            }
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void penerimaanUMInsert(ref Database db, ref int counterdb, int bentukPembayaran, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid pengeluaranUangRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoKwitansi.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));

            // sebelumnya -- db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            // sekarang dibuat kalo proses tarikan, _kodeTrans itu selalu dianggap "TRK"
            if (cboTipe.Text == "DP Subsidi")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "SBT"));
            }
            else if (cboTipe.Text == "DP Pelanggan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMT"));
            }
            else if (cboTipe.Text == "Pengembalian DP Pelanggan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMP"));
            }
            else if (cboTipe.Text == "Pengurangan DP Subsidi")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "SBP"));
            }

            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTanggal.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, bentukPembayaran));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));

            if(cboTipe.SelectedIndex == 0 || cboTipe.SelectedIndex == 1)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }
            //else if (cboTipe.SelectedIndex == 2)
            //{
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));
            //}
            counterdb++;
        }

        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            String KodeTrans = string.Empty;
            switch (cboBentukPembayaran.SelectedIndex)
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

                if (cboTipe.Text == "DP Subsidi")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLASBT).ToString()));
                }
                else if (cboTipe.Text == "DP Pelanggan")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMT).ToString()));
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTanggal.DateValue)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominal.Text)));
            if(cboTipe.Text == "DP Subsidi")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Tambahan DP Pelanggan | " + lblNamaCustomer.Text.Trim() + " | " + _nopol.Trim()));
                //dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Tambahan DP Subsidi | " + lblNamaLeasing.Text.Trim() + " | " + _nopol.Trim()));
            }
            else if(cboTipe.Text == "DP Pelanggan")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Tambahan DP Pelanggan | " + lblNamaCustomer.Text.Trim() + " | " + _nopol.Trim()));
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

        // untuk memasukkan data biaya Komisi
        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran)
        {
            Guid _JnsTransaksiRowID = Guid.Empty, _MataUangRowID = Guid.Empty;
            Exception exDE = new DataException();
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

                if (cboTipe.Text == "Pengembalian DP Pelanggan")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMT).ToString()));  // balikkin UMT
                }
                else if (cboTipe.Text == "Pengurangan DP Subsidi")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLASBT).ToString()));  // balikkin SBT
                }
                else
                {
                    throw (exDE);
                }
                
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, txtNominal.GetDoubleValue));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, " Pengembalian DP | " + lblNamaCustomer.Text.Trim() ));

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

        private void penjualanLogInsert(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            if (cboTipe.Text == "DP Subsidi")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanSBD", SqlDbType.Money, txtNominal.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi SBD"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Tambahan DP Subsidi : " + lblNamaCustomer.Text.Trim() + " | " + txtNominal.GetDoubleValue));
            }
            else if (cboTipe.Text == "DP Pelanggan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanUMT", SqlDbType.Money, txtNominal.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi UMT"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Tambahan DP Pelanggan : " + lblNamaCustomer.Text.Trim() + " | " + txtNominal.GetDoubleValue));
            }
            else if (cboTipe.Text == "Pengembalian DP Pelanggan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanUMP", SqlDbType.Money, txtNominal.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi UMP"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Pengembalian DP Pelanggan : " + lblNamaCustomer.Text.Trim() + " | " + txtNominal.GetDoubleValue));
            }
            else if (cboTipe.Text == "Pengurangan DP Subsidi") // Pengurangan DP Subsidi
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanUMP", SqlDbType.Money, txtNominal.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi SBP"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Pengembalian DP Subsidi : " + lblNamaCustomer.Text.Trim() + " | " + txtNominal.GetDoubleValue));
            }
            //db.Commands[counterdb].Parameters.Add(new Parameter("@rowidjournalbatal", SqlDbType.UniqueIdentifier, null));
            counterdb++;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            int bentukPembayaran = 1;
            System.Guid rekeningPembayaranRowID = System.Guid.Empty;
            
            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            
            int counterdb = 0, counterdbf = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ValidateSave())
                {
                }
                else
                {
                    return;
                }

                Guid penerimaanUangRowID;
                Guid pengeluaranUangRowID;
                penerimaanUangRowID = Guid.NewGuid();
                pengeluaranUangRowID = Guid.NewGuid();
                
                Exception exDE = new DataException();
                switch (cboBentukPembayaran.SelectedIndex)
                {
                    case 0: bentukPembayaran = 1; break; // kas
                    case 1: bentukPembayaran = 2; break; // bank
                    case 2: bentukPembayaran = 5; break; // potongan pembelian itu nonkasir
                    default: throw (exDE); break;
                }

                if (bentukPembayaran == 2)
                {
                    rekeningPembayaranRowID = lookUpRekening1.RekeningRowID;
                }

                penjualanLogInsert(ref db, ref counterdb);
                if (cboTipe.Text == "DP Subsidi" || cboTipe.Text == "Pengurangan DP Subsidi")
                {
                    DPDetailSubsidiInsert(ref db, ref counterdb);
                }
                else
                {
                    lblNoKwitansi.Text = "K" + Numerator.NextNumber("NKJ");

                    penerimaanUMInsert(ref db, ref counterdb, bentukPembayaran, rekeningPembayaranRowID, penerimaanUangRowID, pengeluaranUangRowID);
                    DPDetailSubsidiInsert(ref db, ref counterdb);
                    
                    // masukkin data ke penerimaan Uang
                    // buat no Bukti PenerimaanUang baru
                    String tempBentukPenerimaan = "";
                    switch (cboBentukPembayaran.SelectedIndex + 1)
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
                    Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                    
                    if (cboTipe.SelectedIndex == 0 || cboTipe.SelectedIndex == 1) // DP Subsidi / DP Pelanggan
                    {
                        String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                    "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                    , 4, false, true);

                        penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanUangRowID, NoTransPenerimaan);
                    }
                    else if (cboTipe.SelectedIndex == 2) // Pengembalian DP Pelanggan
                    {
                        String tempBentukPengeluaran = tempBentukPenerimaan;

                        // di bawah ini itu ngebentuk Bukti Uang Keluar untuk komisi!!!
                        String NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPengeluaran + "K/" +
                                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                        // -- !!!!!!!!!!!!!!!!!!!! tadinya pengeluaranUangRowID itu newGuid !!!, mesti cepet2 dibenerin!!!
                        pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranUangRowID, tempBentukPengeluaran, NoTransPengeluaran); // ngga kirim vendor rowid saat komisi
                    }
                }

                updateTambahanUMPelunasan(ref db, ref counterdb);

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

        private void cboBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            urusBentukPembayaran();
        }

        private void urusBentukPembayaran()
        {
            if (cboBentukPembayaran.SelectedIndex == 0) // kas
            {
                lookUpRekening1.Enabled = false;
                lookUpRekening1.RekeningRowID = Guid.Empty;
                lookUpRekening1.NamaRekening = "";
            }
            else if (cboBentukPembayaran.SelectedIndex == 1) // bank
            {
                lookUpRekening1.Enabled = true;
            }
            else if (cboBentukPembayaran.SelectedIndex == 2) // potongan pembelian
            {
                lookUpRekening1.Enabled = false;
                if (cboTipe.SelectedIndex == 1) // DP Pelanggan
                {
                    MessageBox.Show("Tidak bisa menggunakan tipe pembayaran ini untuk DP Pelanggan!");
                    cboBentukPembayaran.SelectedIndex = 0;
                }
            }
        }

        private void cboTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipe.SelectedIndex == 0) // dP Subsidi
            {
                // kalau DP Subsidi, bentuk pembayarannya boleh potongan pembelian
            }
            else if (cboTipe.SelectedIndex == 1) // DP Pelanggan
            {
                // klo di sini, itu ngga boleh
                if (cboBentukPembayaran.SelectedIndex == 2) // potongan pembelian
                {
                    MessageBox.Show("Tidak boleh menggunakan tipe pembayaran ini!");
                    cboBentukPembayaran.SelectedIndex = 0;
                }
            }
            else if (cboTipe.SelectedIndex == 2) // Pengembalian DP Pelanggan
            {
            }
            else if (cboTipe.SelectedIndex == 3) // Pengurangan DP Subsidi
            {
            }
        }
    }
}
