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
    public partial class frmDendaUpdate : ISA.Controls.BaseForm
    {
        Guid _srcRowID = Guid.Empty;
        Guid _penjRowID = Guid.Empty;
        Guid _custRowID = Guid.Empty;
        Guid _penjHistRowID = Guid.Empty;
        String _namaCustomer = String.Empty;
        String _src = String.Empty;
        String _uraian = String.Empty;
        String _nopol = String.Empty;
        Guid PenerimaanDendaNewRowID = Guid.NewGuid();
        Double _Nominal;

        DendaDetail _selectedDendaDetail;
        List<DendaIden> _listDendaIden;

        public frmDendaUpdate()
        {
            InitializeComponent();
        }

        public frmDendaUpdate(Form caller, Guid SrcRowID, Guid PenjRowID, String Src, Guid PenjHistRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _srcRowID = SrcRowID;
            _penjRowID = PenjRowID;
            _src = Src;
            _penjHistRowID = PenjHistRowID;
        }

        private void frmDendaUpdate_Load(object sender, EventArgs e)
        {
            // txtnominal.Enabled = false; // bisa isi sendiri sekarang
            // txtUraian.Text = "";
            lookUpRekening1.Enabled = false;
            cboTipeTransaksi.SelectedIndex = 0; // 0 itu yg Pembayaran + Potongan
            // ambil data dari database dulu
            DataTable dummy = new DataTable();
            using(Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_DETAIL_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _srcRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, _src));
                dummy = db.Commands[0].ExecuteDataTable();
            }

            if (dummy.Rows.Count > 0)
            {
                lblDenda.Text = Tools.isNull(dummy.Rows[0]["Nominal"], 0).ToString();
                _Nominal = Convert.ToDouble(lblDenda.Text); 
                lblSaldoDenda.Text= Tools.isNull(dummy.Rows[0]["SaldoDenda"], 0).ToString();
                lblPotonganDenda.Text = Tools.isNull(dummy.Rows[0]["PotonganDenda"], 0).ToString();
                lblPembayaranDenda.Text = Tools.isNull(dummy.Rows[0]["BayarDenda"], 0).ToString();
                lblMataUang.Text = Tools.isNull(dummy.Rows[0]["MataUangIDSrc"], "").ToString();
                lblNoTrans.Text = Tools.isNull(dummy.Rows[0]["NoTrans"], "").ToString();
                lblSrc.Text = Tools.isNull(dummy.Rows[0]["SrcDenda"], "").ToString();
                lblTglTrans.Text = Tools.isNull(dummy.Rows[0]["TanggalTransaksi"], DateTime.MinValue).ToString();
                _uraian = Tools.isNull(dummy.Rows[0]["Uraian"], "").ToString();
                _custRowID = (Guid) Tools.isNull(dummy.Rows[0]["CustRowID"], Guid.Empty);
                _namaCustomer = Tools.isNull(dummy.Rows[0]["Nama"], "").ToString();
                lblNama.Text = _namaCustomer;
                _nopol = Tools.isNull(dummy.Rows[0]["NoPol"], "").ToString();
                lblNopol.Text = _nopol;
                txtnominal.Text = Tools.isNull(dummy.Rows[0]["SaldoDenda"], 0).ToString();
            }
            else
            {
                MessageBox.Show("Data tidak dapat diambil!");
            }

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

            txtTanggal.DateValue = GlobalVar.GetServerDate;

            cboPembulatan.SelectedIndex = 0;
            cboBentukPembayaran.SelectedIndex = 0;
            refreshPembulatan();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void penerimaanDendaInsert(ref Database db, ref int counterdb, Guid PenerimaanDenda, Guid SrcRowID, String Src, Double Nominal, Guid penerimaanPBLRowID, Guid PenerimaanDendaRowID, int bentukpembayaran, String NoTransDenda)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenDendaRowID", SqlDbType.UniqueIdentifier, PenerimaanDenda));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDendaRowID", SqlDbType.UniqueIdentifier, SrcRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDenda", SqlDbType.VarChar, Src));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTransDenda));

            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, txtTanggal.DateValue));
            if (cboBentukPembayaran.Text.ToLower() == "titipan")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 4)); // titipan itu kodenya 4, sebelumnya dianggap 1 kalo titipan anggap tunai
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, bentukpembayaran)); // sebelumnya (cboBentukPembayaran.SelectedIndex + 1) 
            }

            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0 && (cboTipeTransaksi.SelectedIndex == 0 || cboTipeTransaksi.SelectedIndex == 1))
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, Convert.ToDouble(txtpotongan.Text.ToString())));
            if (Convert.ToDouble(Tools.isNull(txtnominal.Text, 0).ToString()) > 0 && (cboTipeTransaksi.SelectedIndex == 0 || cboTipeTransaksi.SelectedIndex == 1))
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanDendaRowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Denda | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            counterdb++;
        }

        private void penerimaanUMUpdateDenda(ref Database db, ref int counterdb, Guid PenerimaanDendaRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_UPDATE_DendaRowID"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _srcRowID));
            db.Commands[0].Parameters.Add(new Parameter("@DendaRowID", SqlDbType.UniqueIdentifier, PenerimaanDendaRowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }
        
        private void penerimaanAngsuranUpdateDenda(ref Database db, ref int counterdb, Guid PenerimaanDendaRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanAngsuran_UPDATE_DendaRowID"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _srcRowID));
            db.Commands[0].Parameters.Add(new Parameter("@DendaRowID", SqlDbType.UniqueIdentifier, PenerimaanDendaRowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String newNoTrans, Decimal newNominal, String suffix, String NoTransPenerimaan)
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

                // kalau di sini, selalu denda

                if (GlobalVar.CabangID.Contains("06"))
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLADenda).ToString()));
                }
                else
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.Denda).ToString()));
                }
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> newNoTrans / txtNoBukti.Text
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, newNominal));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, newNominal));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (_uraian + suffix) + " Denda | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }                   
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void penerimaanTitipanIdenInsert(ref Database db, ref int counterdb)
        {
            foreach(DendaIden rowDendaIden in _listDendaIden)
            {
                db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowDendaIden.TitipanRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanDNDRowID", SqlDbType.UniqueIdentifier, PenerimaanDendaNewRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, (rowDendaIden.NominalIden))); // ngga usah dikurangi potongan - Convert.ToDouble(txtpotongan.Text.ToString())
                db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                counterdb++;
            }
        }

        private void penerimaanPembulatanInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
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
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                if (GlobalVar.CabangID.Contains("06"))
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLADenda).ToString()));
                }
                else
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.Pembulatan).ToString()));  // Pembulatan -> Pendapatan Lain - Lain (32)
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominalPembulatan.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalPembulatan.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Pembulatan " + cboPembulatan.Text + " untuk Denda | " + lblNama.Text.Trim() + " | " + lblNopol.Text.Trim()));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini administrasi 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private bool validateSave()
        {
            bool result = true;
            String tempError = String.Empty;

            /* // nominal bayarnya bebas sekarang
            if (Convert.ToDouble(txtnominal.Text.ToString()) != Convert.ToDouble(lblDenda.Text.ToString()))
            {
                result = false;
                tempError = tempError + "Nominal pembayaran tidak sama dengan nominal denda yg ditetapkan.\n";
            }
            */

            DateTime temp;
            bool tempresult;
            tempresult = DateTime.TryParse(txtTanggal.DateValue.ToString(), out temp);
            if(tempresult == false)
            {
                result = false;
                tempError = tempError + "Data Tanggal tidak dapat diproses.\n";
            }

            if(GlobalVar.CabangID.Contains("06"))
            {
                if (txtTanggal.DateValue.HasValue)
                {
                    if (txtTanggal.DateValue < GlobalVar.GetServerDate.Date || txtTanggal.DateValue > GlobalVar.GetServerDate.Date.AddDays(2))
                    {
                        MessageBox.Show("Tanggal hanya dapat diisikan tanggal hari ini sampai +2 hari ke depan!");
                        txtTanggal.Focus();
                        return false;
                    }
                }

                if (txtTanggal.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
                {
                    if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        txtTanggal.Focus();
                        return false;
                    }
                }
            }

            if (cboMataUang.Text == null || cboMataUang.Text == "")
            {
                result = false;
                tempError = tempError + "Pilih data mata uang terlebih dahulu.\n";
            }

            if (cboBentukPembayaran.SelectedIndex == 0 || cboBentukPembayaran.SelectedIndex == 1 || cboBentukPembayaran.Text.ToLower() == "titipan") { }
            else
            {
                result = false;
                tempError = tempError + "Pilih bentuk pembayaran terlebih dahulu.\n";
            }

            if(cboBentukPembayaran.SelectedIndex == 1)
            {
                if(lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    result = false;
                    tempError = tempError + "Isikan rekening transfer bank terlebih dahulu.\n";
                }
            }

            /* // bisa bayar lebih
            if( (Convert.ToDouble(txtnominal.Text.ToString()) + Convert.ToDouble(txtpotongan.Text.ToString())) 
                 > 
                 Convert.ToDouble(lblSaldoDenda.Text.ToString()) ) // nominalnya sekarang bisa diedit, 
                // jumlah potongan + nominal -> tidak boleh lebih besar dari saldo Denda
            {
                result = false;
                tempError = tempError + "Jumlah nominal dan potongan yang ingin dibayarkan melebihi sisa hutang Denda.\n";
            }
            */

            /*
            if (Convert.ToDouble(txtpotongan.Text.ToString()) > Convert.ToDouble(lblSaldoDenda.Text.ToString()))
            {
                result = false;
                tempError = tempError + "Tidak bisa mengisikan potongan lebih besar dari nominal yg diminta.\n";
            }
            */
            if (result == false && tempError != String.Empty)
            {
                MessageBox.Show(tempError);
            }

            return result;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(validateSave())
            {
                Database db = new Database(GlobalVar.DBShowroom);
                Database dbf = new Database(GlobalVar.DBFinanceOto);
                int counterdb = 0, counterdbf = 0;
                try
                {
                    String tempBentukPenerimaan = "";
                    int bentukpembayaran = 0;
                    switch (cboBentukPembayaran.SelectedIndex + 1)
                    {
                        case 1: // kalau kas
                            tempBentukPenerimaan = "K";
                            bentukpembayaran = 1;
                            break;
                        case 2: // kalau transfer
                            tempBentukPenerimaan = "B";
                            bentukpembayaran = 2;
                            break;
                        /*case 3: // kalau giro
                            tempBentukPenerimaan = "G";
                            bentukpembayaran = 3;
                            break;*/ // karena lagi ngga ada giro makanya geser 1
                        case 3: // kalau titipan
                            tempBentukPenerimaan = "K";
                            bentukpembayaran = 4;
                            break;
                    }

                    // buat Guid PenerimaanUang untuk Denda nya
                    Guid penerimaanUangRowID_Denda = Guid.NewGuid();
                    Guid penerimaanPBLRowID = Guid.NewGuid();

                    // Update ke PenerimaanUM / Angsuran data PenerimaanDendanya 
                    // ~ penerimaan denda sekarang di tabel penerimaan denda sendiri
                    /*
                        if (_src == "Angsuran")
                        {
                            penerimaanAngsuranUpdateDenda(ref db, ref counterdb, penerimaanUangRowID_Denda);
                        }
                        else if (_src == "Pelunasan")
                        {
                            penerimaanUMUpdateDenda(ref db, ref counterdb, penerimaanUangRowID_Denda);
                        }
                    */

                    // masukkan ke Penerimaan Denda
                    // yg dimasukkan itu ngga usah dikurangin potongan, dua2 nya itu sendiri2 ngga usah saling mepengaruhi!!!
                    // pas penampilan sama pemrosesan baru diolah data potongannya, pas simpen biasa aja
                    String NoTransDenda = Numerator.NextNumber("NKD");
                    penerimaanDendaInsert(ref db, ref counterdb, PenerimaanDendaNewRowID, _srcRowID, _src,
                        Convert.ToDouble(txtnominal.Text.ToString()) , // ( - Convert.ToDouble(txtpotongan.Text.ToString())
                        penerimaanPBLRowID, penerimaanUangRowID_Denda, bentukpembayaran, NoTransDenda);
                    // sekarang rowid penerimaanuang untuk denda disimpannya di tabel dendanya

                    // kalo pake titipan ngga perlu masukkin data ke penerimaanUang
                    if (cboBentukPembayaran.Text.ToLower() == "titipan")
                    {
                        // kalo pake titipan cukup masukkin ke titipan iden
                        penerimaanTitipanIdenInsert(ref db, ref counterdb);
                    }
                    else
                    {
                        // hanya buat ke penerimaan uang, kalau nominalnya > 0 pembayarannya
                        if ( Convert.ToDouble(Tools.isNull(txtnominal.Text, 0).ToString()) > 0 &&
                             (cboTipeTransaksi.SelectedIndex == 0 || cboTipeTransaksi.SelectedIndex == 1)
                           )
                        {
                            // buat no trans penerimaanUang nya dulu
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);
                            penerimaanUangInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Denda, lblNoTrans.Text,
                                Convert.ToDecimal(txtnominal.Text), // ngga usah dipotong, yg masuk memang sesuai nominal - Convert.ToDecimal(txtpotongan.Text))
                                " - Denda", NoTransPenerimaan);
                        }
                        // buat masukkin ke penerimaanUang yang Dendanya
                        if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0 &&
                             (cboTipeTransaksi.SelectedIndex == 0 || cboTipeTransaksi.SelectedIndex == 1))
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
                    MessageBox.Show("Data berhasil diproses.");

                    this.Close();
                }
                catch(Exception ex)
                {
                    db.RollbackTransaction();
                    dbf.RollbackTransaction();
                    MessageBox.Show("Data tidak berhasil diproses. " + ex.Message);
                }
            }

        }

        public void RefreshControlsTitipan()
        {
            txtnominal.Text = _selectedDendaDetail.TotalNominalIden.ToString();
            cboBentukPembayaran.Enabled = true;
            txtnominal.Enabled = false;
        }

        private void cboBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipeTransaksi.SelectedIndex == 0 || cboTipeTransaksi.SelectedIndex == 1)
            {
                txtnominal.Enabled = true;
                txtnominal.ReadOnly = false;
            }
            if(cboBentukPembayaran.SelectedIndex == 0) // berarti tunai
            {
                lookUpRekening1.Enabled = false;
                lookUpRekening1.RekeningRowID = Guid.Empty;
                lookUpRekening1.NamaRekening = "";
                lookUpRekening1.NoRekening = "";
                lookUpRekening1.SetLabelNoRekening("");
                lookUpRekening1.SetTextBoxNamaRekening("");
                //txtnominal.Text = lblDenda.Text;
            }
            else if(cboBentukPembayaran.SelectedIndex == 1) // berarti transfer
            {
                lookUpRekening1.Enabled = true;
                //txtnominal.Text = lblDenda.Text;
            }
            else if (cboBentukPembayaran.Text.ToLower() == "titipan")
            {
                lookUpRekening1.Enabled = false;
                lookUpRekening1.RekeningRowID = Guid.Empty;
                lookUpRekening1.NamaRekening = "";
                lookUpRekening1.NoRekening = "";
                lookUpRekening1.SetLabelNoRekening("");
                lookUpRekening1.SetTextBoxNamaRekening("");

                _selectedDendaDetail = new DendaDetail();
                _selectedDendaDetail.CustomerRowID = _custRowID;
                _selectedDendaDetail.CustomerName = _namaCustomer;
                _selectedDendaDetail.NominalPembayaran = Convert.ToDouble(txtnominal.Text); 
                _selectedDendaDetail.MataUangID = cboMataUang.SelectedValue.ToString();

                _listDendaIden = new List<DendaIden>();
                Penjualan.frmDendaIden ifrmChild = new Penjualan.frmDendaIden(this, _selectedDendaDetail, _listDendaIden);
                ifrmChild.ShowDialog();
                Double NomIden = ifrmChild.nominalIden;
                txtnominal.Text = NomIden.ToString();

                txtnominal.Enabled = false;
                txtnominal.ReadOnly = true;
            }

            // update juga pembulatannya -- kalau titipan ada kasus sendiri !!!
            refreshPembulatan();
        }

        private void frmDendaUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Penjualan.frmDendaBrowse Caller = (Penjualan.frmDendaBrowse)this.Caller;
            Caller.refreshGrids(_penjRowID, _srcRowID, _src);
        }

        private void refreshPembulatan()
        {
            if (cboBentukPembayaran.Text.ToLower() == "titipan")
            {
                // kalo titipan ngga ada nominal pembulatan
                txtNominalPembulatan.Text = "0"; // pembulatannya 0
                txtNominalPembayaranPBL.Text = txtnominal.Text; // jadiin sama seperti txtnominal aja
            }
            else
            {
                // index 0 -> 100, 1 -> 500, 2 -> 1000
                if (cboPembulatan.SelectedIndex >= 0 && cboPembulatan.SelectedIndex <= 2)
                {
                    // karena ada potongan, yg dibayarkan dikurangi sama potongannya;
                    Double Value = Convert.ToDouble(Tools.isNull(txtnominal.Text, 0)); // ngga usah dikurangin - Convert.ToDouble(Tools.isNull(txtpotongan.Text, 0)
                    Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                    txtNominalPembulatan.Text = (PBLValue - Value).ToString();
                    txtNominalPembayaranPBL.Text = PBLValue.ToString();
                }
            }
        }

        private void cboPembulatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void controlPembulatanSet()
        {
            txtnominal.Enabled = false;
            txtnominal.ReadOnly = true;
        }

        private void txtnominal_TextChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void txtpotongan_Leave(object sender, EventArgs e)
        {
            // kalau keluar dari control ini dan ngga 0 txtPotongannya, itu mesti minta pin, kalau ngga jadiin 0 lagi
            Double tempPotongan = Convert.ToDouble(txtpotongan.Text);

            if (tempPotongan > 0) // berarti mau dikasih potongan
            {
                // berarti ada mau kasih potongan, mesti minta pin dulu
                // minta pin
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PotonganPenerimaanDenda), "Pemberian potongan Denda memerlukan PIN persetujuan!");
                if (GlobalVar.pinResult == false)
                {
                    txtpotongan.Text = "0";
                    txtpotongan.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToDouble(txtpotongan.Text.ToString()) > Convert.ToDouble(lblSaldoDenda.Text.ToString()))
                    {
                        MessageBox.Show("Potongan tidak boleh lebih besar dari nominal yg diminta!");
                        txtpotongan.Text = txtnominal.Text;
                    }
                }
            }
            else
            {
                txtpotongan.Text = "0";
            }
        }

        private void cboTipeTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0 -> Pembayaran + Potongan, 1 -> Pembayaran, 2 -> Potongan
            if (cboTipeTransaksi.SelectedIndex == 0) // bayar + potong
            {
                // kalo yg ini normal, semuanya di enable, tapi hati2 kalau jenis bayarnya titipan tetep ngga boleh ubah2 nominal
                txtnominal.Enabled = true;
                txtnominal.ReadOnly = false;
                cboBentukPembayaran.Enabled = true;
                txtpotongan.Enabled = true;
                txtpotongan.ReadOnly = false;
                lookUpRekening1.Enabled = false;
                lookUpRekening1.SetLabelNoRekening("");
                lookUpRekening1.SetTextBoxNamaRekening("");
                
                if (cboBentukPembayaran.Text.ToLower() == "titipan")
                {
                    // kalau titipan, txtnominal ngga boleh diapa2in
                    txtnominal.Enabled = false;
                    txtnominal.ReadOnly = true;
                }
                if (cboBentukPembayaran.Text.ToLower() == "transfer")
                {
                    lookUpRekening1.Enabled = true;
                }
                else
                {
                    lookUpRekening1.Enabled = false;
                    lookUpRekening1.RekeningRowID = Guid.Empty;
                    lookUpRekening1.NamaRekening = "";
                    lookUpRekening1.NoRekening = "";
                    lookUpRekening1.SetLabelNoRekening("");
                    lookUpRekening1.SetTextBoxNamaRekening("");
                }
            }
            else if(cboTipeTransaksi.SelectedIndex == 1) // pembayaran saja
            {
                // kalo yg ini bagian potongan ngga boleh diedit
                txtnominal.Enabled = true;
                txtnominal.ReadOnly = false;
                txtnominal.Text = _Nominal.ToString();
                cboBentukPembayaran.Enabled = true;
                txtpotongan.Enabled = false; // ngga boleh
                txtpotongan.ReadOnly = true; // ngga boleh
                txtpotongan.Text = "0";
                lookUpRekening1.Enabled = false;

                if (cboBentukPembayaran.Text.ToLower() == "titipan")
                {
                    // kalau titipan, txtnominal ngga boleh diapa2in
                    txtnominal.Enabled = false;
                    txtnominal.ReadOnly = true;
                }
                if (cboBentukPembayaran.Text.ToLower() == "transfer")
                {
                    lookUpRekening1.Enabled = true;
                }
                else
                {
                    lookUpRekening1.Enabled = false;
                    lookUpRekening1.RekeningRowID = Guid.Empty;
                    lookUpRekening1.NamaRekening = "";
                    lookUpRekening1.NoRekening = "";
                    lookUpRekening1.SetLabelNoRekening("");
                    lookUpRekening1.SetTextBoxNamaRekening("");
                }
            }
            else if (cboTipeTransaksi.SelectedIndex == 2) // potongan saja
            {
                // kalo yg ini bagian potongan ngga boleh diedit
                txtnominal.Enabled = false;// ngga boleh
                txtnominal.ReadOnly = true;// ngga boleh
                txtnominal.Text = "0";
                cboBentukPembayaran.Enabled = false;// ngga boleh
                cboBentukPembayaran.SelectedIndex = 0; // jadiin anggap bayar tunai
                txtpotongan.Enabled = true;
                txtpotongan.ReadOnly = false;
                txtpotongan.Text = _Nominal.ToString();
                lookUpRekening1.Enabled = false;

                if (cboBentukPembayaran.Text.ToLower() == "titipan")
                {
                    // kalau titipan, txtnominal ngga boleh diapa2in
                    txtnominal.Enabled = false;
                    txtnominal.ReadOnly = true;
                }
                if (cboBentukPembayaran.Text.ToLower() == "transfer")
                {
                    lookUpRekening1.Enabled = true;
                }
                else
                {
                    lookUpRekening1.Enabled = false;
                    lookUpRekening1.RekeningRowID = Guid.Empty;
                    lookUpRekening1.NamaRekening = "";
                    lookUpRekening1.NoRekening = "";
                    lookUpRekening1.SetLabelNoRekening("");
                    lookUpRekening1.SetTextBoxNamaRekening("");
                }
            }
        }

        private void txtpotongan_TextChanged(object sender, EventArgs e)
        {
            if (cboTipeTransaksi.SelectedIndex == 0)
            {
                txtpotongan.Text = Tools.isNull(txtpotongan.Text.ToString(), 0).ToString();
                txtnominal.Text = (_Nominal - Convert.ToDouble(Tools.isNull(txtpotongan.Text.ToString(), 0))).ToString();
            }
        }
    }
}
