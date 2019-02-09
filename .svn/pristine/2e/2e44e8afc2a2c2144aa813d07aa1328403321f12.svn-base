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
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;

namespace ISA.Showroom.Penjualan
{
    public partial class frmUMSubsidiUpdate : ISA.Controls.BaseForm
    {
        Guid _PenjualanRowID = Guid.Empty;
        Guid _LeasingRowID = Guid.Empty;
        Guid _PembelianRowID = Guid.Empty;
        Guid _rowID = Guid.Empty;
        String _kodeTrans = "";
        Double _SisaSBD = 0;
        public frmUMSubsidiUpdate()
        {
            InitializeComponent();
        }

        public frmUMSubsidiUpdate(Form Caller, Guid PenjualanRowID, String KodeTrans)
        {
            InitializeComponent();
            _PenjualanRowID = PenjualanRowID;
            _kodeTrans = KodeTrans;
            this.Caller = Caller;
        }

        private void frmUangMukaSubsidiUpdate_Load(object sender, EventArgs e)
        {
            txtTglJual.Enabled = false;
            txtTglJual.ReadOnly = true;
            txtTglPelunasan.Enabled = false;
            txtTglPelunasan.ReadOnly = true;

            txtTglPelunasan.DateValue = GlobalVar.GetServerDate;
            
            cbxBentukPembayaran.SelectedIndex = 1;
            txtNoTrans.Text = "";
            txtNoTrans.Enabled = false;
            txtNoTrans.ReadOnly = true;
            txtNominal.Text = "0";
            DisabledControlBG();

            DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
            dt2.DefaultView.Sort = "MataUangID ASC";
            cbxMataUang.DisplayMember = "MataUangID";
            cbxMataUang.ValueMember = "MataUangID";
            cbxMataUang.DataSource = dt2.DefaultView;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_for_DPSubsidi"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _PenjualanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                _LeasingRowID = new Guid(Tools.isNull(dt.Rows[0]["LeasingRowID"], "").ToString());
                _PembelianRowID = new Guid(Tools.isNull(dt.Rows[0]["PembRowID"], "").ToString());
                lblAlamat.Text = Tools.isNull(dt.Rows[0]["AlamatLeasing"], "").ToString();
                lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                lblNamaLeasing.Text = Tools.isNull(dt.Rows[0]["NamaLeasing"], "").ToString();
                lblNominalSubsidi.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DPSubsidi"], 0)).ToString("N2");
                lblNopol.Text = Tools.isNull(dt.Rows[0]["NoPol"], "").ToString();
                lblNoTrans.Text = Tools.isNull(dt.Rows[0]["NoTrans"], "").ToString();
                txtTglJual.Text = Tools.isNull(dt.Rows[0]["TglJual"], DateTime.MaxValue).ToString();
                lblSisaSubsidi.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SBDSisa"], 0)).ToString("N2");
                _SisaSBD = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SBDSisa"], 0));
                txtNominal.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SBDSisa"], 0)).ToString();
                txtRefund.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SBDSisa"], 0)).ToString(); ;
                txtSelisih.Text = "0";
            }
            else
            {
                MessageBox.Show("Data tidak dapat ditemukan!");
                this.Close();
            }

            if (GlobalVar.CabangID.Contains("06"))
            {
                txtTglPelunasan.Enabled = true;
                txtTglPelunasan.ReadOnly = false;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateSave()
        {
            bool tempResult = true;
            String tempError = "";

            if (txtTglPelunasan.DateValue.Value < GlobalVar.GetServerDate.Date || txtTglPelunasan.DateValue.Value > GlobalVar.GetServerDate.Date.AddDays(2))
            {
                tempError = tempError + "Tidak dapat menginput data ke belakang tanggal hari ini atau lebih dari H+2 !\n";
                tempResult = false;
            }

            if (txtTglPelunasan.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
            {
                if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                }
                else
                {
                    tempError = tempError + "Silahkan mengisi Tanggal pelunasan terlebih dahulu !\n";
                    txtTglPelunasan.Focus();
                    tempResult = false;
                }
            }

            if(txtNominal.GetDoubleValue == 0 || String.IsNullOrEmpty(txtNominal.Text))
            {
                tempError = tempError + "Isikan Nominal yang mau dibayarkan terlebih dahulu!\n";
                tempResult = false;
            }
            /*
            if(txtNominal.GetDoubleValue < _SisaSBD)
            {
                tempError = tempError + "Nominal yang dibayarkan tidak bisa kurang sisa subsidi!\n";
                tempResult = false;
            }
            */
            // 0 Tunai, 1 Bank, 2 Giro, 3 PotonganPembelian
            if( cbxBentukPembayaran.SelectedIndex == 0 || cbxBentukPembayaran.SelectedIndex == 1 ||
                cbxBentukPembayaran.SelectedIndex == 2 || cbxBentukPembayaran.SelectedIndex == 3 )
            {
            }
            else
            {
                tempError = tempError + "Pilih Bentuk Pembayaran terlebih dahulu!\n";
                tempResult = false;
            }

            if(cbxBentukPembayaran.SelectedIndex == 1) // kalau bank
            {
                if (lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    tempError = tempError + "Pilih rekening terlebih dahulu!\n";
                    tempResult = false;
                }
            }

            if (cbxBentukPembayaran.SelectedIndex == 2) // kalau Giro
            {
                txtNoBG.Enabled = true;
                txtTglBG.Enabled = true;
                if (String.IsNullOrEmpty(txtNoBG.Text.Trim()))
                {
                    tempError = tempError + "Isikan nomor Giro terlebih dahulu!\n";
                    tempResult = false;
                }
                if (String.IsNullOrEmpty(txtTglBG.Text.Trim()))
                {
                    tempError = tempError + "Isikan Tanggal Jatuh Tempo Giro terlebih dahulu!\n";
                    tempResult = false;
                }

                if (((DateTime)txtTglBG.DateValue).Date < txtTglJual.DateValue)
                {
                    tempError = tempError + "Tanggal Jatuh Tempo Giro tidak boleh kurang dari Tanggal Penjualan!\n";
                    tempResult = false;
                }
            }

            if(tempResult == false || tempError.Trim() != "")
            {
                MessageBox.Show(tempError);
                return false;
            }

            return tempResult;
        }

        private void penerimaanUMInsert(ref Database db, ref int counterdb, Guid PenerimaanUMRowID, int bentukPembayaran, Guid penerimaanUangRowID )
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _PenjualanRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));

            // sebelumnya -- db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "SBD")); //SBD - kode untuk transaksi Subsidi
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglPelunasan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cbxMataUang.SelectedValue));
            //
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            if (cbxBentukPembayaran.SelectedIndex == 3) // kalau dipilih potongan pembelian, jenisnya NonKasir
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5)); // kalau Potongan Pembelian selalu 5 -- NONKASIR
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, bentukPembayaran));
            }
            if (bentukPembayaran == 2) // hanya bank dan giro yang pakai rekeningRowID
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            }
            if (bentukPembayaran == 1 || bentukPembayaran == 2) // kas dan bank perlu dikirimkan penerimaanUangRowID nya
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@Refund", SqlDbType.Money, txtRefund.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Selisih", SqlDbType.Money, txtSelisih.GetDoubleValue));
            counterdb++;
        }

        private void penerimaanTitipanInsert(ref Database db, ref int counterdb, Guid PenerimaanUMRowID, int bentukPembayaran)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
            // karena ini di Subsidi, ngga ada CustomerRowID, digantiin sama Leasing RowID
            // db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _custRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cbxMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, txtRefund.GetDoubleValue));// tadinya txtNominal
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, bentukPembayaran)); // Giro itu 3
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _PenjualanRowID));
            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.UM)); // kalo UM itu 1
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "SBD")); // untuk subsidi KodeTrans nya SBD
            counterdb++;
        }

        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid penerimaanUangRowID, String NoTransPenerimaan)
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
                dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cbxMataUang.SelectedValue));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                // Jenis Transaksi untuk UM Subsidi mestinya UMS tapi belum tahu jenisTransaksinya
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLASBD).ToString()));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> lblNoTrans.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglPelunasan.DateValue)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglPelunasan.DateValue)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtRefund.Text))); // tadinya txtNominal
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtRefund.Text))); // tadinya txtNominal
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "DP Subsidi " + txtUraian.Text + " | " + lblNamaLeasing.Text.Trim() + " | " + lblNopol.Text.Trim()));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini uang muka
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            if (JnsPenerimaan == "B")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void penerimaanPotonganPembelian(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_Potongan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "POT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKB")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "Potongan Pembelian DP Subsidi " + txtUraian.Text + " | " + lblNamaLeasing.Text.Trim() + " untuk " + lblNopol.Text.Trim()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _PembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtRefund.GetDoubleValue)); // txtNominal
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5));
            counterdb++;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    MessageBox.Show("Tidak bisa menggunakan giro!");
                    return;
                }

                Database db = new Database();
                Database dbf = new Database(GlobalVar.DBFinanceOto);
                int counterdb = 0, counterdbf = 0;
                Guid PenerimaanUMRowID = Guid.NewGuid();
                Guid PenerimaanUangRowID = Guid.NewGuid();
                _rowID = PenerimaanUMRowID;
                int bentukPembayaran = 1;
                string bentukPenerimaan = "K";        
                switch (cbxBentukPembayaran.SelectedIndex)
                {
                    case 0: // kalau kas
                             bentukPenerimaan = "K";
                             bentukPembayaran = 1;
                             break;
                    case 1 : // kalau transfer
                             bentukPenerimaan = "B";
                             bentukPembayaran = 2;
                             break;
                    case 2 : // kalau giro
                             bentukPenerimaan = "G";
                             bentukPembayaran = 3;
                             break;
                    case 3 : // kalau potongan pembelian
                             bentukPenerimaan = "K";
                             bentukPembayaran = 5;
                             break;
                }

                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "potongan pembelian")
                {
                }
                else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    // NTP untuk kode dokumen titipan , seperti giro
                    txtNoTrans.Text = Numerator.NextNumber("NTP");
                    bentukPembayaran = 3;
                }
                else
                {
                    // NKJ untuk kode dokumen non giro
                    txtNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                    {
                        penerimaanTitipanInsert(ref db, ref counterdb, PenerimaanUMRowID, bentukPembayaran);
                    }
                    else
                    {
                        penerimaanUMInsert(ref db, ref counterdb, PenerimaanUMRowID, bentukPembayaran, PenerimaanUangRowID);

                        if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "potongan pembelian")
                        {
                            penerimaanPotonganPembelian(ref db, ref counterdb);
                        }
                        else
                        {
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + bentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);
                            penerimaanUangInsert(ref dbf, ref counterdbf, PenerimaanUangRowID, NoTransPenerimaan);
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
                    MessageBox.Show(messageTemp);
                    this.Close();  
                }
                catch(Exception ex)
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
                MessageBox.Show("Tidak bisa menggunakan Giro");
                EnabledControlBG();
                lookUpRekening1.Enabled = false;
                cbxBentukPembayaran.SelectedIndex = 0;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "potongan pembelian")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = false;
            }
        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            /*
            Double sisasbd;
            sisasbd = Convert.ToDouble(lblSisaSubsidi.Text);
            if (txtNominal.GetDoubleValue < sisasbd)
            {
                MessageBox.Show("Pelunasan tidak bisa lebih kecil dari Sisa Subsidi yg tercantum!");
            }
            else
            {
                txtRefund.Text = Convert.ToDouble(txtNominal.GetDoubleValue - sisasbd).ToString("N2");
            }
            */
        }

        private void frmUMSubsidiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPelunasanBrowse)
            {
                Penjualan.frmPelunasanBrowse frmCaller = (Penjualan.frmPelunasanBrowse)this.Caller;
                frmCaller.RefreshRowPiutang(_PenjualanRowID);
                frmCaller.FindRowGrid2("mKodeTrans", _kodeTrans);
                frmCaller.RefreshRowLunas(_rowID);
                frmCaller.FindRowGrid3("dRowID", _rowID.ToString());
            }
        }

        private void txtRefund_Leave(object sender, EventArgs e)
        {
            urusSelisih();
        }

        private void urusSelisih()
        {
            double Nominal = txtNominal.GetDoubleValue;
            double Refund = txtRefund.GetDoubleValue;
            double Selisih = txtSelisih.GetDoubleValue;

            Selisih = Nominal - Refund;
            txtSelisih.Text = Selisih.ToString();
        }
    }
}
