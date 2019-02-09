using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Showroom.Class;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPenjualanBatalJual : BaseForm
    {
        DataTable dt, dt_Pembayaran, dt_RowID;
        Guid RowID;
        DataSet ds;
        Guid MataUangRowID;
                        

        public frmPenjualanBatalJual()
        {
            InitializeComponent();
        }


        public frmPenjualanBatalJual(Form caller, DataTable dt_BatalJual, Guid _RowID)
        {
            InitializeComponent();
            this.Caller = caller;
            dt = dt_BatalJual;
            RowID = _RowID;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_BatalJual"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                ds = db.Commands[0].ExecuteDataSet();
            }
            dt_Pembayaran = ds.Tables[0];
            dt_RowID = ds.Tables[1];
        }

        private void frmPenjualanBatalJual_Load(object sender, EventArgs e)
        {
            MataUangRowID = (Guid)Tools.isNull(dt.Rows[0]["MataUangRowID"], null);
            txt_NoTrans.Text = Tools.isNull(dt.Rows[0]["NoTrans"], "").ToString();
            txt_NoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
            txt_NoRangka.Text = Tools.isNull(dt.Rows[0]["NoRangka"], "").ToString();
            txt_NoMesin.Text = Tools.isNull(dt.Rows[0]["Nomesin"], "").ToString();
            txt_Pelanggan.Text = Tools.isNull(dt.Rows[0]["Customer"], "").ToString();
            txt_Alamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            txt_TglJual.DateValue = Convert.ToDateTime( dt.Rows[0]["TglJual"]);
            txt_JenisPenjualan.Text = Tools.isNull(dt.Rows[0]["JnsPenjualan"], "").ToString();
            txt_Harga.Text = Tools.isNull(dt.Rows[0]["HargaOff"], "").ToString();
            txt_UM.Text = Tools.isNull(dt.Rows[0]["UangMuka"], "").ToString();
            txt_Angsuran.Text = Tools.isNull(dt.Rows[0]["Angsuran"], "").ToString();
            txt_Tempo.Text = Tools.isNull(dt.Rows[0]["TempoAngsuran"], "").ToString();
            txt_BBN.Text = Tools.isNull(dt.Rows[0]["BBN"], "").ToString();
            txt_Komisi.Text = Tools.isNull(dt.Rows[0]["BiayaKomisi"], "").ToString();
            txt_Diskon.Text = Tools.isNull(dt.Rows[0]["Discount"], "").ToString();
            txt_BiayaAdm.Text = Tools.isNull(dt.Rows[0]["BiayaAdm"], "").ToString();

            txt_RB_UangMuka.Text = Tools.isNull(dt_Pembayaran.Rows[0]["UangMuka"], "").ToString();
            txt_RB_Pembayaran.Text = Tools.isNull(dt_Pembayaran.Rows[0]["TotalAngsuran"], "").ToString();
            txt_BiayaAdministrasi.Select();
           }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Database dbfsub = new Database(GlobalVar.DBFinanceOto);
            Database db = new Database();
            int Counterdb = 0 ;
            try
            {
                errorProvider1.Clear();
                if (String.IsNullOrEmpty(txt_KetPembatalan.Text))
                {
                    errorProvider1.SetError(txt_KetPembatalan, "Silakan isi terlebih dahulu alasan pembatalan dan di ACC oleh siapa");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Apakah anda Yakin ingin membatalkan penjualan ini", "Penjualan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    String bentukPengeluaran = "K";
                    String NoTransPengeluaran;
                    Database dbfNumeratorsub;
                    Database dbfNumerator;
                    Database dbRead;
                    Guid RowID_BalikJournal = new Guid();
                    Guid RowID_BalikJournalHPP = new Guid();

                    //using (db)
                    //{
                        if (txt_BiayaAdministrasi.GetDoubleValue > 0)
                        {
                            dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaanBaru = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG_BIAYA_ADM_BATAL_JUAL", GlobalVar.PerusahaanID,
                                                        "/B" + bentukPengeluaran + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);
                            Guid _JnsTransaksiRowID;

                            using (dbfsub)
                            {
                                DataTable dtfsub = new DataTable();
                                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST")); //01
                                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAADM).ToString()));  // ADM -> Biaya Adm Penjualan   (30)
                                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
                            }

                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BiayaAdm")); //02
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaanBaru)); // tadinya newNoTrans txtNoBukti.Text
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, MataUangRowID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txt_BiayaAdministrasi.GetDoubleValue));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, txt_BiayaAdministrasi.GetDoubleValue));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Biaya Administrasi Pembatalan Penjualan NO Trans : " + txt_NoTrans.Text));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, bentukPengeluaran)); // ini angsuran 
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                //db.Commands[Counterdb].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "YUSUF"));
                                Counterdb++;
                        }

                        //Perulangan untuk membuat BKK dan insert row ke tabel Delete penerimaan ADM, Angsuran, dan UM
                        foreach (DataRow dr in dt_RowID.Rows)
                        {
                            dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                                       string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);
                            Guid RowID_BKK = Guid.NewGuid();
                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BatalSave")); //3 
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_BKK));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, dr["PenerimaanUangRowID"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@TabelRowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@NamaTabel", SqlDbType.VarChar, dr["NamaTabel"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@NoBKK", SqlDbType.VarChar, NoTransPengeluaran.ToString()));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, SecurityManager.UserID));
                                //db.Commands[Counterdb].Parameters.Add(new Parameter("@CancelBy", SqlDbType.VarChar, "YUSUF"));
                                Counterdb++;
                        }

                        //Balik Journal
                        if (Tools.isNull(dt.Rows[0]["JournalRowID"], "").ToString() != "")
                        {
                            RowID_BalikJournal = Guid.NewGuid();
                            String RecordIDJournal = Tools.CreateFingerPrint();
                            DataTable dt_JournalDetail = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BalikJournal")); //4
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, dt.Rows[0]["JournalRowID"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_BalikJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowIDPenjualan", SqlDbType.UniqueIdentifier, RowID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordIDJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                Counterdb++;
                        
                            using (dbRead = new Database())
                            {
                                dbRead.Commands.Add(dbRead.CreateCommand("usp_PenjualanBaru_GetJournalDetailRowID"));
                                dbRead.Commands[0].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, dt.Rows[0]["JournalRowID"]));
                                dt_JournalDetail = dbRead.Commands[0].ExecuteDataTable();
                            }

                            foreach (DataRow dr in dt_JournalDetail.Rows)
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BalikJournalDetail")); //5
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowIDPenjualan", SqlDbType.UniqueIdentifier, RowID_BalikJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, RecordIDJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                Counterdb++;
                            }
                        }

                        //Balik JournalHPP
                        if (Tools.isNull(dt.Rows[0]["JournalHPPRowID"], "").ToString() != "")
                        {
                            RowID_BalikJournalHPP = Guid.NewGuid();
                            String RecordIDJournal = Tools.CreateFingerPrint();
                            DataTable dt_JournalDetail = new DataTable();

                            db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BalikJournal")); //6
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, dt.Rows[0]["JournalHPPRowID"]));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_BalikJournalHPP));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@RowIDPenjualan", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordIDJournal));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            Counterdb++;

                            using (dbRead = new Database())
                            {
                                dbRead.Commands.Add(dbRead.CreateCommand("usp_PenjualanBaru_GetJournalDetailRowID"));
                                dbRead.Commands[0].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, dt.Rows[0]["JournalRowID"]));
                                dt_JournalDetail = dbRead.Commands[0].ExecuteDataTable();
                            }
                            foreach (DataRow dr in dt_JournalDetail.Rows)
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BalikJournalDetail")); //7
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowIDPenjualan", SqlDbType.UniqueIdentifier, RowID_BalikJournalHPP));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, RecordIDJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                Counterdb++;
                            }
                        }

                        //Perulangan untuk menghapus row tabel penerimaan ADM, Angsuran, dan UM
                        foreach (DataRow dr in dt_RowID.Rows)
                        {
                            db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_DELETE_Penerimaan"));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@TabelRowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@NamaTabel", SqlDbType.VarChar, dr["NamaTabel"]));
                            Counterdb++;
                        }

                        //Pengecekan KomisiRowID dan pembuatan BKM nya
                        if (Tools.isNull(dt.Rows[0]["PengeluaranKomisiRowID"], "").ToString() != "")
                        {
                            dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaanBaru = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG_KOMISI", GlobalVar.PerusahaanID,
                                                        "/B" + bentukPengeluaran + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_PenerimaanKomisi"));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@PengeluaranKomisiRowID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["PengeluaranKomisiRowID"]));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, NoTransPenerimaanBaru));
                            db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            Counterdb++;
                        }

                        #region awal
                        
                        //Cek JournalHPPRowID PembayaranPemb
                        Object JournalHPPRowIDPembayaranPemb;
                        using (dbRead = new Database())
                        {
                            dbRead.Commands.Add(dbRead.CreateCommand("usp_PenjualanBaru_CekJournalHPPRowIDPembayaranPemb"));
                            dbRead.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            JournalHPPRowIDPembayaranPemb = dbRead.Commands[0].ExecuteScalar();
                        }

                        if (Tools.isNull(JournalHPPRowIDPembayaranPemb, "").ToString() != "")
                        {
                            RowID_BalikJournalHPP = Guid.NewGuid();
                            String RecordIDJournal = Tools.CreateFingerPrint();
                            DataTable dt_JournalDetail = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BalikJournal"));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, (Guid)JournalHPPRowIDPembayaranPemb));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_BalikJournalHPP));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowIDPenjualan", SqlDbType.UniqueIdentifier, RowID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordIDJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "UpdateJournalPembayaranPemb"));
                                Counterdb++;

                            using (dbRead = new Database())
                            {
                                dbRead.Commands.Add(dbRead.CreateCommand("usp_PenjualanBaru_GetJournalDetailRowID"));
                                dbRead.Commands[0].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, dt.Rows[0]["JournalRowID"]));
                                dt_JournalDetail = dbRead.Commands[0].ExecuteDataTable();
                            }

                            foreach (DataRow dr in dt_JournalDetail.Rows)
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_BalikJournalDetail"));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RowIDPenjualan", SqlDbType.UniqueIdentifier, RowID_BalikJournalHPP));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, RecordIDJournal));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[Counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                Counterdb++;
                            }
                        }
                         
                        #endregion

                        //Menyimpan data penjualan ke PenjualanDeleted kemudian data penjualan menghapusnya
                        db.Commands.Add(db.CreateCommand("usp_PenjualanBaru_SaveDelete"));
                        db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID_BalikJournal", SqlDbType.UniqueIdentifier, RowID_BalikJournal));
                        db.Commands[Counterdb].Parameters.Add(new Parameter("@RowID_BalikJournalHPP", SqlDbType.UniqueIdentifier, RowID_BalikJournalHPP));
                        db.Commands[Counterdb].Parameters.Add(new Parameter("@KetBatal", SqlDbType.VarChar, txt_KetPembatalan.Text));
                        db.Commands[Counterdb].Parameters.Add(new Parameter("@DeletedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        Counterdb++;

                        db.BeginTransaction();
                        for (int i = 0; i < Counterdb; i++)
                        {
                            db.Commands[i].ExecuteNonQuery();
                        }
                        db.CommitTransaction();

                    MessageBox.Show("Anda berhasil membatalkan penjualan.");

                    if (this.Caller is frmPenjualanBrowseTLA)
                    {
                        frmPenjualanBrowseTLA frmCaller = (frmPenjualanBrowseTLA)this.Caller;
                        frmCaller.RefreshData();
                    }else
                    if (this.Caller is frmPenjualanBrowseADS)
                    {
                        frmPenjualanBrowseADS frmCaller = (frmPenjualanBrowseADS)this.Caller;
                        frmCaller.RefreshData();
                    }else
                    if (this.Caller is frmPenjualanBrowse)
                    {
                        frmPenjualanBrowse frmCaller = (frmPenjualanBrowse)this.Caller;
                        frmCaller.RefreshData();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Error.LogError(ex);
            }
            finally
            {

            }
        }
    }
}
