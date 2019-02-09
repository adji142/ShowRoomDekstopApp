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
    public partial class frmAdministrasiUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID, _penjRowID, _custRowID, _penjHistRowID;
        string _kodeTrans;
        string _cabangID = GlobalVar.CabangID;
        DateTime tglJTUM;
        DateTime tglJual;
        Double _nominal;
        Double _nilaiBG;
        bool isCetak = false;
        AdministrasiDetail _selectedAdministrasiDetail;
        List<AdministrasiIden> _listAdministrasiIden;

        enum enumTipeTitipan { Murni, UM, Angsuran, Adm };

        String _nopol;

        public void RefreshControlsTitipan()
        {
            txtNominal.Text = _selectedAdministrasiDetail.TotalNominalIden.ToString();
            cbxBentukPembayaran.Enabled = false;
            txtNominal.Enabled = false;
        }

        public frmAdministrasiUpdate(Form caller, Guid penjRowID, Guid custRowID, Guid penjHistRowID)
        {
            InitializeComponent();
            _penjRowID = penjRowID;

            _custRowID = custRowID;
            _penjHistRowID = penjHistRowID;

            _rowID = Guid.NewGuid();
            this.Caller = caller;
        }

        private void frmAdministrasiUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblTglJual.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglJual"]);
                    tglJual = (DateTime)dt.Rows[0]["TglJual"];
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    lblSisaUM.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)));
                    tglJTUM = (DateTime)dt.Rows[0]["TglJTUM"];

                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    _nopol = Tools.isNull(dt.Rows[0]["NoPol"], "").ToString();

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

                    lblKodeTrans.Text = "PENERIMAAN BIAYA ADMINISTRASI";
                    _kodeTrans = "ADM";
                    txtTglLunas.DateValue = GlobalVar.GetServerDate;
                    
                    txtNoBG.Text = "";
                  
                    txtNominal.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0)).ToString();
                    txtUraian.Text = "";
                    txtTglBG.Text = "";

                    cboPembulatan.SelectedIndex = 0;
                    cbxBentukPembayaran.SelectedIndex = 0;
                    refreshPembulatan();
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
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            Decimal decNilaiBGC = 0;
            Decimal decNilaiNominal = 0;

            decNilaiNominal = Convert.ToDecimal(txtNominal.Text);
            if (String.IsNullOrEmpty(cbxBentukPembayaran.SelectedItem.ToString()))
            {
                MessageBox.Show("Pilih Bentuk Pembayaran terlebih dahulu!");
                cbxBentukPembayaran.Focus();
                return false;
            }
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                if (Tools.isNull(lookUpRekening1.NamaRekening, "").ToString() == "" || lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    MessageBox.Show("Rekening Bank belum terisi");
                    lookUpRekening1.Focus();
                    return false;

                }
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                decNilaiBGC = Convert.ToDecimal(txtNominal.Text);
                // kalo di giro decnominalnya jadi 0 aja
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
            if (((DateTime)txtTglLunas.DateValue).Date > tglJTUM.Date)
            {
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.BatasTempoAdministrasi), "Tanggal Pelunasan melebihi Jatuh Tempo Pelunasan Biaya Administrasi !");
                if (GlobalVar.pinResult == false) { return false; }
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

            if ((decNilaiNominal + decNilaiBGC) != Convert.ToDecimal(lblSisaUM.Text))
            {
                MessageBox.Show("Nominal Pelunasan tidak sama dengan Biaya Administrasi !");
                txtNominal.Focus();
                return false;
            }
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                if (_listAdministrasiIden.Count == 0)
                {
                    MessageBox.Show("Identifikasi titipan belum dilakukan." + Environment.NewLine + "Pastikan minimal 1 transaksi titipan sudah diiden ke pembayaran ini");
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
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Adm));
            // kalo ADM ngga ada KodeTrans sih
            // db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, DBNull.Value));

            counterdb++;
        }

        private void penerimaanAdministrasiInsert(ref Database db, ref int counterdb, Decimal decNilaiBGC, Decimal decNilaiNominal, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid penerimaanPBLRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));

            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, decNilaiBGC));

            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
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

            counterdb++;
        }

        private void penerimaanTitipanIdenInsert(ref Database db, ref int counterdb)
        {
            foreach(AdministrasiIden rowAdministrasiIden in _listAdministrasiIden)
            {
                db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAdministrasiIden.TitipanRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanADMRowID", SqlDbType.UniqueIdentifier, _rowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, rowAdministrasiIden.NominalIden));
                db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                counterdb++;
            }
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

                if (GlobalVar.CabangID.Contains("06"))
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAADM).ToString()));  // ADM -> Pendapatan Lain Lain   (32)
                }
                else
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.ADM).ToString()));  // ADM -> Biaya Adm Penjualan   (30)
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominal.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " | " + lblNama.Text + " | " + _nopol));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini administrasi 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }                  
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Pembulatan " + cboPembulatan.Text + " untuk Administrasi | " + lblNama.Text + " | " + _nopol));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini administrasi 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
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

            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            int counterdb = 0, counterdbf = 0;

            try
            {
                if(ValidateSave())
                {
                }
                else
                {
                    return;
                }
    
                this.Cursor = Cursors.WaitCursor;
                decNilaiNominal = Convert.ToDecimal(txtNominal.Text);

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

                Guid penerimaanUangRowID;
                Guid penerimaanPBLRowID;
                penerimaanPBLRowID = Guid.NewGuid();
                penerimaanUangRowID = Guid.NewGuid();

                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    penerimaanTitipanInsert(ref db, ref counterdb, decNilaiBGC);
                }
                else
                {
                    penerimaanAdministrasiInsert(ref db, ref counterdb, decNilaiBGC, decNilaiNominal, rekeningPembayaranRowID, penerimaanUangRowID, penerimaanPBLRowID);

                    //pembayaran ambil dari titipan 
                    if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
                    {
                        penerimaanTitipanIdenInsert(ref db, ref counterdb);
                    }
                    // selain pembayaran dari giro dan titipan buat data penerimaan uang
                    if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                    {
                    }
                    else
                    {
                        // hanya insert ke penerimaan uang kalo bukan giro dan bukan titipan

                        // buat no Bukti PenerimaanUang baru
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
                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                    "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                    , 4, false, true);

                        penerimaanUangInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanUangRowID, NoTransPenerimaan);
                        
                        // kalo nominal pembulatannya ngga 0, masukkin juga ke penerimaanUang
                        if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
                        {
                            Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaanPBL = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            penerimaanPembulatanInsert(ref dbf, ref counterdbf, rekeningPembayaranRowID, penerimaanPBLRowID, NoTransPenerimaanPBL);
                        }
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

        private void frmAdministrasiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmAdministrasiBrowse)
            {
                Penjualan.frmAdministrasiBrowse frmCaller = (Penjualan.frmAdministrasiBrowse)this.Caller;
                frmCaller.RefreshRowADM(_penjRowID);
                frmCaller.FindRowGrid2("mKodeTrans", _kodeTrans);
                frmCaller.RefreshRowLunas(_rowID);
                frmCaller.FindRowGrid3("dRowID", _rowID.ToString());
            }
        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                EnabledControlBG();
                lookUpRekening1.Enabled = false;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = false;
                
                _selectedAdministrasiDetail = new AdministrasiDetail();
                _selectedAdministrasiDetail.CustomerRowID = _custRowID;
                _selectedAdministrasiDetail.CustomerName = lblNama.Text;
                _selectedAdministrasiDetail.NominalPembayaran = Convert.ToDouble(txtNominal.Text);
                _selectedAdministrasiDetail.MataUangID = cboMataUang.SelectedValue.ToString();
                
                _listAdministrasiIden = new List<AdministrasiIden>();
                Penjualan.frmAdministrasiIden ifrmChild = new Penjualan.frmAdministrasiIden(this, _selectedAdministrasiDetail, _listAdministrasiIden);
                ifrmChild.ShowDialog();
                
            }
            refreshPembulatan();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void refreshPembulatan()
        {
            if (cbxBentukPembayaran.Text.ToLower() == "titipan")
            {
                // kalo titipan ngga ada nominal pembulatan
                txtNominalPembulatan.Text = "0"; // pembulatannya 0
                txtNominalPembayaranPBL.Text = txtNominal.Text; // jadiin sama seperti txtNominal aja
            }
            else
            {
                // index 0 -> 100, 1 -> 500, 2 -> 1000
                if (cboPembulatan.SelectedIndex >= 0 && cboPembulatan.SelectedIndex <= 2)
                {
                    Double Value = Convert.ToDouble(Tools.isNull(txtNominal.Text, 0));
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
            txtNominal.Enabled = false;
            txtNominal.ReadOnly = true;
        }

        private void txtNominal_TextChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }
    }
}
