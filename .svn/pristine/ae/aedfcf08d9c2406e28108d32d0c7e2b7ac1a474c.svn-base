using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmProsesGiroMasukPiutangUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID, _penjualanRowID;
        String _noGiro;
        String MataUangID;
        
        DateTime _GiroStatusTanggal = DateTime.MinValue;
        Class.enumStatusGiro _GiroStatusLast = Class.enumStatusGiro.Diterima;
        Guid _rekeningRowID = Guid.Empty;

        public frmProsesGiroMasukPiutangUpdate()
        {
            InitializeComponent();
        }

        public frmProsesGiroMasukPiutangUpdate(Form caller, Guid rowID, String NoGiro, Guid penjualanRowID)
        {
            InitializeComponent();
            _rowID = rowID;
            _noGiro = NoGiro;
            _penjualanRowID = penjualanRowID;
            this.Caller = caller;
        }

        private void frmProsesGiroUpdate_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        #region Controls Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetor_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.Disetor, btnSetor.Text, true);
        }

        private void btnCair_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.Cair, btnCair.Text, true);
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            DataTable dt_tglCair = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTanggalCairGiroHistory"));
                db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, _noGiro));
                dt_tglCair = db.Commands[0].ExecuteDataTable();
            }


            if (dt_tglCair.Rows.Count > 0)
            {
                DateTime TglCair = (DateTime)dt_tglCair.Rows[0]["Tanggal"];
                DateTime TglSetelah3Hari = TglCair.AddDays(3);

                if (TglCair <= TglSetelah3Hari)
                {
                    Simpan(Class.enumStatusGiro.Ditolak, btnTolak.Text, true);
                }
                else
                {
                    MessageBox.Show("Maaf, Proses Giro tolak sudah lebih dari 3 hari.");
                    return;
                }
            }
            else
            {
                Simpan(Class.enumStatusGiro.Ditolak, btnTolak.Text, true);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.Batal, btnBatal.Text, false);
        }

        private void btnBatalSetor_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.BatalSetor, btnBatalSetor.Text, true);
        }

        private void btnBatalCair_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.BatalCair, btnBatalCair.Text, true);
        }
        #endregion

        #region UserDefinedFunctions
        private void RefreshData()
        {
            bool enabledBatalCair = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //retrieving data
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                //display data
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    lblCustomerRowID.Text = Tools.isNull(dt.Rows[0]["CustomerRowID"], "").ToString();
                    lblCabangID.Text = Tools.isNull(dt.Rows[0]["CabangID"], "").ToString();
                    _rekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"],Guid.Empty);
                    MataUangID = Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString();
                    lblNominal.Text = MataUangID + " " +
                                string.Format("{0:0,0.0}", Tools.isNull(dt.Rows[0]["Nominal"], 0));
                    lblNominalBGC.Text = MataUangID + " " +
                                string.Format("{0:0,0.0}", Tools.isNull(dt.Rows[0]["NominalBGC"], 0));
                    lblTglJTBGC.Text = string.Format("{0:dd-MMM-yy}", dt.Rows[0]["TglJTBGC"]);
                    lblNoBGC.Text = Tools.isNull(dt.Rows[0]["NoBGC"], "").ToString();
                    lblNoTrans.Text = Tools.isNull(dt.Rows[0]["NoTrans"], "").ToString();

                    // kalo tipe titipannya itu titipan murni, cek juga ke tabel titipaniden, ini titipan pernah dipake ngga
                    // kalo pernah dipake ngga boleh dibatalin cairnya
                    string kodeTrans = dt.Rows[0]["TipeTitipan"].ToString();

                    switch (kodeTrans)
                    {
                        case "0": kodeTrans = Class.enumTipeTitipan.Murni.ToString();
                            break;
                        case "1": kodeTrans = Class.enumTipeTitipan.UM.ToString();
                            break;
                        case "2": kodeTrans = Class.enumTipeTitipan.Angsuran.ToString();
                            break;
                        case "3": kodeTrans = Class.enumTipeTitipan.Adm.ToString();
                            break;
                    }
                    if (kodeTrans == Class.enumTipeTitipan.Murni.ToString())
                    {
                        using (Database db2new = new Database(GlobalVar.DBShowroom))
                        {
                            DataTable dt_tipiden = new DataTable();
                            db2new.Commands.Add(db2new.CreateCommand("usp_titipaniden_list"));
                            db2new.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt_tipiden = db2new.Commands[0].ExecuteDataTable();
                            if (dt_tipiden.Rows.Count > 0)
                            {
                                // kalo ada berarti udah pernah di iden, buat lOk jadi false
                                enabledBatalCair = false;
                            }
                        }

                    }
                }

                using (Database db = new Database())
                {
                    dt.Clear();
                    db.Commands.Add(db.CreateCommand("usp_GiroHistory_LIST_FILTER_RefID"));
                    db.Commands[0].Parameters.Add(new Parameter("@RefID",SqlDbType.UniqueIdentifier,_rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        int no = 0;
                        foreach (DataRow dr in dt.Rows) {
                            int tno = int.Parse(Tools.isNull(dr["RecID"], "0").ToString());
                            if (no < tno)
                            {
                                _GiroStatusTanggal = (DateTime)dr["Tanggal"];
                                _GiroStatusLast = (Class.enumStatusGiro)int.Parse(dr["StatusGiro"].ToString());
                                no = tno;
                            }
                        }
                    }
                    lblTglStatus.Text =_GiroStatusTanggal.ToString();
                    label8.Text = _GiroStatusLast.ToString();
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
            btnSetor.Enabled = ((_GiroStatusLast == Class.enumStatusGiro.Diterima) || (_GiroStatusLast == Class.enumStatusGiro.BatalSetor));
            btnBatalSetor.Visible = (_GiroStatusLast == Class.enumStatusGiro.Disetor);
            btnCair.Enabled = ((_GiroStatusLast == Class.enumStatusGiro.Disetor) || (_GiroStatusLast == Class.enumStatusGiro.BatalCair));
            
            btnBatalCair.Visible = (_GiroStatusLast == Class.enumStatusGiro.Cair);
            btnBatalCair.Enabled = enabledBatalCair;  // dari cek yg di atas, kalo titipan murni pernah diiden, button ini ngga boleh di klik

            btnTolak.Enabled = ((_GiroStatusLast == Class.enumStatusGiro.Disetor) || (_GiroStatusLast == Class.enumStatusGiro.Cair));
            btnBatal.Enabled = (_GiroStatusLast <= Class.enumStatusGiro.Diterima);

            // tambahan, kalo udah cair satusnya, semua button di disable/ hide dulu aja
            if (_GiroStatusLast == Class.enumStatusGiro.Cair)
            {
                btnSetor.Enabled = false;
                btnBatalSetor.Visible = false;
                btnCair.Enabled = false;
                btnBatalCair.Visible = false;
                btnBatalCair.Enabled = false;
                btnTolak.Enabled = false;
                btnBatal.Enabled = false;
            }
        }

        private void PenerimaanANGDelete(ref Database db, ref int counterdb, DataTable dummy)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_DELETE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void PenerimaanUMDelete(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_DELETE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }
        
        private void PenerimaanUMBungaDelete(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_DELETE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }
        private void PenerimaanADMDelete(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_DELETE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            counterdb++;
        }

        private void PenerimaanTitipanIdenDelete(ref Database db, ref int counterdb, int enumTipeTitipanVal, string KodeTrans)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipanIden_DELETE"));
            switch(enumTipeTitipanVal)
            {
                case (int)Class.enumTipeTitipan.Angsuran:
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Angsuran));
                    break;
                case (int)Class.enumTipeTitipan.UM:
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.UM));
                    break;
                case (int)Class.enumTipeTitipan.Adm:
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Adm));
                    break;
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowIDTransaksi", SqlDbType.UniqueIdentifier, _rowID));
            if (KodeTrans.ToUpper() == "UMB")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, KodeTrans));
            }
            counterdb++;
        }

        private void PenerimaanUMBungaInsert(ref Database db, ref int counterdb, DataTable dummy, dlgProsesGiroMasukPiutang_Cair dlg, Guid newRowID, int _GiroStatusNew)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMBungaRowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["AttachedRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, dummy.Rows[0]["NominalBGC"]));

            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, dummy.Rows[0]["Tanggal"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 3)); // giro itu 3
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, Convert.ToDouble(dummy.Rows[0]["Potongan"].ToString())));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dlg.uraianInsert + " - UMBunga"));
            counterdb++;
        }

        private void PenerimaanUMInsert(ref Database db, ref int counterdb, DataTable dummy, dlgProsesGiroMasukPiutang_Cair dlg, Guid newRowID, int _GiroStatusNew)
        {
            // berarti di sininya perlu ambil data UM nya sekaligus penjualannya buat tahu flag sourcenya, 
            // jadi bisa masukkin Bunga juga, kalau kena UMBunga, ataupun lagi Bayar DPSubsidi
// ======================================================================================================================================================
            DataTable dtsub = new DataTable();
            using (Database dbsub = new Database(GlobalVar.DBShowroom))
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanUM_LIST_ALL"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
                dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
                dtsub = dbsub.Commands[0].ExecuteDataTable();
                if (dtsub.Rows.Count > 0)
                {
                    // do something!
                }
            }

            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID)); // --> row ID penerimaan UM
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKJ")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dlg.uraianInsert)); // Inputan Manual nanti mseti dibuat dialog box entryan dulu barengan sama tanggal
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, dummy.Rows[0]["NoBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, Tools.isNull(dummy.Rows[0]["KodeTrans"], "UMK").ToString())); // "UMK" // defaultin UMK -- dummy.Rows[0]["KodeTrans"]
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dlg.dtTanggalInsert.DateValue)); // jangan pake ini entry manual lewat dialog dulu
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, dummy.Rows[0]["Tanggal"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, dummy.Rows[0]["NominalBGC"])); // masukkin ke data nominal barunya data nominal bgc nya karena dicairin
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, dummy.Rows[0]["NominalBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 3));  // karena di bagian Giro, default '3'
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RekeningRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.Int, _GiroStatusNew));
            counterdb++;
        }

        private void PenerimaanANGInsert(ref Database db, ref int counterdb, DataTable dummy, dlgProsesGiroMasukPiutang_Cair dlg, Guid newRowID, float angsuranke, DataTable dummy3, Guid PenerimaanUangRowID, Guid PenerimaanUangRowIDBunga)
        {
            float angsuranke_new;
            double nominalbunga_new;
            double nominalgiro = Convert.ToDouble(dummy.Rows[0]["NominalBGC"].ToString());
            // khusus untuk angsuran, kasus kalo misalnya dia udah ngasih giro tapi trus bayar tunai/transfer, biar saldonya ngga jadi numpuk
            // pas giro dicairin cek, layaknya kalo menekan tombol bayar di layar penerimaan Angsuran
            // inget denda selalu 0 di sini!!!
            DataTable dtsub = new DataTable();
            using (Database dbsub = new Database(GlobalVar.DBShowroom))
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanANG_LIST_ALL"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
                dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));  
                dtsub = dbsub.Commands[0].ExecuteDataTable();

                angsuranke_new = (float) Convert.ToDouble(Tools.isNull(dtsub.Rows[0]["AngsuranKe"], "").ToString());
                    
            }
            DataTable dtsub2 = new DataTable();
            using (Database dbsub = new Database(GlobalVar.DBShowroom))
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_Angsuran_PiutangBerjalan"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
                dbsub.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
                dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
                dbsub.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "ANG"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, GlobalVar.GetServerDate));
                dtsub2 = dbsub.Commands[0].ExecuteDataTable();

                nominalbunga_new = Convert.ToDouble(Tools.isNull(dtsub2.Rows[0]["Interest"], 0));
            }

            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RowID"]));  // khusus ini jangan guid baru tapi pake rowid penerimaan titipan sebelumnya
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKJ")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, dummy.Rows[0]["NoBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, Tools.isNull(dummy.Rows[0]["KodeTrans"], "ANG").ToString())); // sebelumnya "ANG" // isi sendiri default ANG // dulu dlg.kodeTransInsert
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dlg.uraianInsert));   // ini isi manual
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dlg.dtTanggalInsert.DateValue)); //isi manual
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.Date, dummy.Rows[0]["Tanggal"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Date, dummy.Rows[0]["TglJTBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Float, angsuranke_new));  // ini jadinya ambil dari kayak proses bayar angsuran
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, nominalbunga_new ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, nominalgiro));  // masukkin ke data nominal barunya data nominal bgc nya karena dicairin
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, nominalgiro));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPokok", SqlDbType.Money, Tools.isNull(dummy3.Rows[0]["AngsuranPokok"], 0)));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, 0 )); // kalo sampe di sini itu dendanya 0 in terus // sebelumnya Tools.isNull(dummy3.Rows[0]["Denda"], 0)
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0)); // ini isi manual default 0 // dulu dlg.potonganInsert
            db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["KolektorRowID"])); // ini ambil dari dialog juga mungkin
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 3)); // default 3 karena bentuknya giro
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RekeningRowID"]));

            // langsung masukkan ke penerimaanUangRowID nya 
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowIDBNG", SqlDbType.UniqueIdentifier, PenerimaanUangRowIDBunga));
            
            counterdb++;
        }

        private void PenerimaanADMInsert(ref Database db, ref int counterdb, DataTable dummy, dlgProsesGiroMasukPiutang_Cair dlg, Guid newRowID, int _GiroStatusNew)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID)); // --> rowID penerimaanADM
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKJ")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dlg.uraianInsert)); // entry manual

            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, dummy.Rows[0]["NoBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dlg.dtTanggalInsert.DateValue)); // entry manual
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, dummy.Rows[0]["Tanggal"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"]));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, dummy.Rows[0]["NominalBGC"])); // masukkin ke data nominal barunya data nominal bgc nya karena dicairin
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, dummy.Rows[0]["NominalBGC"]));

            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 3)); // ini bagian giro default 3
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RekeningRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.Int, _GiroStatusNew));
            
            counterdb++;
        }

        public void TitipanIdenInsert(ref Database db, ref int counterdb, DataTable dummy, dlgProsesGiroMasukPiutang_Cair dlg, Guid newRowID, int tipeTitipanVal)
        {
            // masukkin data titipan iden baru sebagai data penerimaan UM
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));            
            switch(tipeTitipanVal)
            {
                case (int)Class.enumTipeTitipan.Adm:
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanADMRowID", SqlDbType.UniqueIdentifier, newRowID)); // --> rowID penerimaanADM
                    break;
                case (int)Class.enumTipeTitipan.Angsuran:
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanAngsuranRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RowID"])); // row id angsuran di sini = row id penerimaan titipan
                    break;
                case (int)Class.enumTipeTitipan.UM:   
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, newRowID));  // row id UM
                    break;
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dlg.dtTanggalInsert.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, dummy.Rows[0]["NominalBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        public void TitipanIdenInsert(ref Database db, ref int counterdb, DataTable dummy, dlgProsesGiroMasukPiutang_Cair dlg, Guid newRowID, String KodeTrans)
        {
            // mestinya yg masuk sini hanya yg pengecualian2, seperti UMBunga 
            // masukkin data titipan iden baru sebagai data penerimaan UM
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
            if(KodeTrans.ToUpper() == "UMB")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMBNGRowID", SqlDbType.UniqueIdentifier, newRowID)); // --> rowID penerimaanUMBunga
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dlg.dtTanggalInsert.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, dummy.Rows[0]["NominalBGC"]));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }


        private void PenerimaanTitipanUpdateStatusGiro(ref Database db, ref int counterdb, int _GiroStatusNew)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_UPD_StatusGiro"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusGiro", SqlDbType.TinyInt, _GiroStatusNew));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void GiroHistoryInsert(ref Database dbf, ref int counterdbf, bool lRekening, DateTime dTgl, int _GiroStatusNew, DataTable dummy, string _kodeTrans, Guid PenerimaanUangRowID, Guid PenerimaanUangRowIDBunga)
        {
            dbf.Commands.Add(dbf.CreateCommand("usp_GiroHistory_INSERT"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RefID", SqlDbType.UniqueIdentifier, _rowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsGiro", SqlDbType.TinyInt, 1));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, _noGiro));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dTgl));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusGiro", SqlDbType.TinyInt, _GiroStatusNew));
            if (lRekening)
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, _rekeningRowID));
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            // kalo masuk ke bawah ini, berarti kemungkinan besar lagi proses pencairan
            if (dummy != null)
            {
                DataTable dtsub2 = new DataTable();
                Double nominalbunga_new = 0;
                Double nominalpokok = 0;
                // cek kalo kodeTrans - nya itu Angsuran siapin ambil data Angsuran untuk ambil data Piutang Pokok dan Piutang Bunganya
                if (_kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
                {
                    using (Database dbsub = new Database(GlobalVar.DBShowroom))
                    {
                        dbsub.Commands.Add(dbsub.CreateCommand("usp_Angsuran_PiutangBerjalan"));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "ANG"));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, GlobalVar.GetServerDate));
                        dtsub2 = dbsub.Commands[0].ExecuteDataTable();

                        nominalbunga_new = Convert.ToDouble(Tools.isNull(dtsub2.Rows[0]["Interest"], 0));
                        nominalpokok = Convert.ToDouble(dummy.Rows[0]["NominalBGC"].ToString() ) - nominalbunga_new; // harusnya nominalbgc dikurang nominal bunga!!! sebelumnya -- Convert.ToDouble(Tools.isNull(dtsub2.Rows[0]["AngsuranPokok"], 0));
                    }
                }

                // yg kepake di bawah ini !!!
                Guid _MataUangRowID, _JnsTransaksiRowID, _JnsTransaksiRowIDBunga;
                String JnsPenerimaan = string.Empty;
                Exception exDE = new DataException();
                String KodeTrans = string.Empty;
                string tempStrUraian = " - Pemasukkan Uang melalui Pencairan Giro tipe - ";
                switch (1) // harusnya selalu bank ( kalo dari giro itu ke bank )
                {
                    case 0: JnsPenerimaan = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (tunai)
                    case 1: JnsPenerimaan = "B"; break; // mestinya ke sini doang, soalnya ini di proses giro -> masuknya ke bank
                    case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                    case 3: JnsPenerimaan = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (titipan)
                }

                // [usp_MataUang_LIST] @MataUangID varchar 3
                using (Database dbfsub = new Database())
                {
                    DataTable dtfsub = new DataTable();
                    dbfsub.Commands.Add(dbfsub.CreateCommand("usp_MataUang_LIST"));
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dummy.Rows[0]["MataUangID"].ToString()));
                    dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                    _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
                }

                // ambil kodetrans dulu buat tau tipe angsurannya
                // usp_Penjualan_LIST   dengan @RowID = _penjRowID
                using (Database dbfsub = new Database(GlobalVar.DBShowroom))
                {
                    DataTable dtfsub = new DataTable();
                    dbfsub.Commands.Add(dbfsub.CreateCommand("usp_Penjualan_LIST"));
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
                    dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                    KodeTrans = dtfsub.Rows[0]["KdTrans"].ToString();
                }

                // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
                using (Database dbfsub = new Database())
                {
                    DataTable dtfsub = new DataTable();
                    dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));

                    if (KodeTrans == "FLT")
                    {
                        tempStrUraian = tempStrUraian + "Angsuran Tetap";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PiutangUsahaTetap).ToString())); 
                    }
                    else if (KodeTrans == "APD")
                    {
                        tempStrUraian = tempStrUraian + "Angsuran Menurun";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PiutangUsahaTetap).ToString())); 
                    }
                    else if (KodeTrans == "TTP") 
                    {
                        tempStrUraian = tempStrUraian + "Titipan";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TTP).ToString())); 
                    }
                    else if (KodeTrans == "UMK" || KodeTrans == "UMT") 
                    {
                        tempStrUraian = tempStrUraian + "Uang Muka";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMK).ToString())); 
                    }
                    else if (KodeTrans == "CTP") 
                    {
                        tempStrUraian = tempStrUraian + "Cash Tempo";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.CTP).ToString())); 
                    }
                    else if (KodeTrans == "TUN") 
                    {
                        tempStrUraian = tempStrUraian + "Tunai";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TUN).ToString()));
                    }
                    else if (KodeTrans == "LSG") 
                    {
                        tempStrUraian = tempStrUraian + "Leasing";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.LSG).ToString())); 
                    }
                    else if (KodeTrans == "ADM") 
                    {
                        tempStrUraian = tempStrUraian + "Administrasi";
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.ADM).ToString()));
                    }
                    else
                    {
                        throw (exDE);
                    }
                    dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                    _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
                }

                // kalau FLT/APD siapin JnsTransaksiBunga nya
                if (_kodeTrans == Class.enumTipeTitipan.Angsuran.ToString() && (KodeTrans == "FLT" || KodeTrans == "APD"))
                {
                    using (Database dbfsub = new Database())
                    {
                        DataTable dtfsub = new DataTable();
                        dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString()));
                        dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                        _JnsTransaksiRowIDBunga = (Guid)dtfsub.Rows[0]["RowID"];
                        dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowIDBunga", SqlDbType.UniqueIdentifier, _JnsTransaksiRowIDBunga));
                    }
                }

                // kiriman dari penerimaan uang insert punya angsuran
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NewNoBukti", SqlDbType.VarChar, dummy.Rows[0]["NoTrans"])); // txtNoBukti.Text
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanNewRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangNewID", SqlDbType.VarChar, GlobalVar.CabangID));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dummy.Rows[0]["Uraian"] + tempStrUraian));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NewJnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini angsuran
   
                // kirimin rowID penerimaanTitipannya
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["RowID"])); // penerimaanTitipanRowID
                
                // kalo angsuran ada parameter lainnya
                if (_kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
                {
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsProcess", SqlDbType.VarChar, "ANG"));
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalBunga", SqlDbType.Money, nominalbunga_new)); 
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NewNominal",   SqlDbType.Money, nominalpokok)); // kalo angsuran new nominalnya pake yg angsuranpokok
                }
                else // kalo bukan angsuran parameternya ada yg beda lagi
                {
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsProcess", SqlDbType.VarChar, "NOTANG"));
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NewNominal", SqlDbType.Money, dummy.Rows[0]["NominalBGC"])); // kalo bukan angsuran nominalnya nominal bgc
                }

                // kalo lagi memproses Giro Cair, buatkan numerator untuk penerimaanUang
                if(_GiroStatusNew == 3) // kalo 3 itu baru cair
                {
                    String tempBentukPenerimaan = "B";
                    Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                    String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                , 4, false, true);

                    // buatin parameter, kirimin numeratornya
                    dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan));

                    // kalo angsuran buatin 1 parameter lagi
                    if (_kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
                    {
                        Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPenerimaansub = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                    "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                    string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                    , 4, false, true);
                        dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowIDBunga", SqlDbType.UniqueIdentifier, PenerimaanUangRowIDBunga));
                        dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBuktiBunga", SqlDbType.VarChar, NoTransPenerimaansub));
                    }

                }
            }   

            counterdbf++;
        }


        private void Simpan(Class.enumStatusGiro _GiroStatusNew, string _ketStatus, bool lRekening) 
        {
            bool lOk = true;
            bool isOkBatalCair = true;
            // untuk proses giro masuk piutang cair

            string tipeTitipan = "";
            string kodeTrans = "";
            string kodeTransTTP = "";

            string RealKodeTrans = ""; // ini yg keisi UMK, UMT, ANG, PLS
            dlgProsesGiroMasukPiutang_Cair dlg = null;
            DataTable dummy = null, dummy3 = null;
            string angsuranke = "";


            dummy = new DataTable();
            using (Database dbnew = new Database(GlobalVar.DBShowroom))
            {
                dbnew.Commands.Add(dbnew.CreateCommand("usp_Link_Get_PenerimaanTitipanxPenjualanxPenjualanHist"));
                dbnew.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                dummy = dbnew.Commands[0].ExecuteDataTable();
            }

            if (_GiroStatusNew == Class.enumStatusGiro.BatalCair)
            {
                // kalo tipe titipannya itu titipan murni, cek juga ke tabel titipaniden, ini titipan pernah dipake ngga
                // kalo pernah dipake ngga boleh dibatalin cairnya
                tipeTitipan = dummy.Rows[0]["TipeTitipan"].ToString();
                kodeTransTTP = dummy.Rows[0]["KodeTrans"].ToString();
                switch (tipeTitipan)
                {
                    case "0": kodeTrans = Class.enumTipeTitipan.Murni.ToString();
                        break;
                    case "1": kodeTrans = Class.enumTipeTitipan.UM.ToString();
                        break;
                    case "2": kodeTrans = Class.enumTipeTitipan.Angsuran.ToString();
                        break;
                    case "3": kodeTrans = Class.enumTipeTitipan.Adm.ToString();
                        break;
                }
                if (kodeTrans == Class.enumTipeTitipan.Murni.ToString())
                {
                    using (Database db2new = new Database(GlobalVar.DBShowroom))
                    {
                        DataTable dt_tipiden = new DataTable();
                        db2new.Commands.Add(db2new.CreateCommand("usp_titipaniden_list"));
                        db2new.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt_tipiden = db2new.Commands[0].ExecuteDataTable();
                        if (dt_tipiden.Rows.Count > 0)
                        {
                            // kalo ada berarti udah pernah di iden, buat lOk jadi false
                            isOkBatalCair = false;
                            MessageBox.Show("Giro tidak dapat dibatalkan pencairannya karena sudah diidentifikasikan untuk pembayaran.");
                            return;
                        } 
                    }

                }
            }
            else if (_GiroStatusNew == Class.enumStatusGiro.Cair && (_penjualanRowID.ToString() != "" && _penjualanRowID != Guid.Empty))
            {
                DataTable result;
                using (Database db2 = new Database(GlobalVar.DBShowroom))
                {
                    db2.Commands.Add(db2.CreateCommand("usp_GetTipeTitipan_LIST"));
                    db2.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjualanRowID));
                    db2.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    result = db2.Commands[0].ExecuteDataTable();
                }
                
                kodeTrans = result.Rows[0]["TipeTitipan"].ToString();


                switch (kodeTrans)
                {
                    case "0": kodeTrans = Class.enumTipeTitipan.Murni.ToString();
                               break;
                    case "1": kodeTrans = Class.enumTipeTitipan.UM.ToString();
                               break;
                    case "2": kodeTrans = Class.enumTipeTitipan.Angsuran.ToString();
                               break;
                    case "3": kodeTrans = Class.enumTipeTitipan.Adm.ToString();
                               break;
                }
            }
            else
            {
                kodeTrans = "";
            }

            if (kodeTrans == Class.enumTipeTitipan.Angsuran.ToString()) // kalo ini cuma bisa masukin sebagai ANG dan PLS di yg mau diinsert
            {
                // bagian angsuran perlu mengambil data - data angsurannya terlebih dahulu
                DataTable dummy2 = new DataTable();
                dummy3 = new DataTable();
                // persiapan untuk data angsuran dulu

                // ambil data dari usp_PenerimaanANG_LIST_ALL
                using (Database db2 = new Database(GlobalVar.DBShowroom))
                {
                    db2.Commands.Add(db2.CreateCommand("usp_PenerimaanANG_LIST_ALL"));
                    db2.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
                    db2.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"])); 
                    dummy2 = db2.Commands[0].ExecuteDataTable();
                }
                angsuranke = "";
                if (dummy2.Rows.Count > 0)
                {
                    angsuranke = Tools.isNull(dummy2.Rows[0]["AngsuranKe"], "").ToString();
                }
                else
                {
                    angsuranke = "1";
                }

                // ambil data dari usp_Angsuran_PiutangBerjalan
                using (Database db2 = new Database(GlobalVar.DBShowroom))
                {
                    db2.Commands.Add(db2.CreateCommand("usp_Angsuran_PiutangBerjalan"));
                    db2.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjHistRowID"]));
                    db2.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, dummy.Rows[0]["PenjualanRowID"]));
                    db2.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dummy.Rows[0]["CabangID"]));
                    db2.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "ANG"));
                    db2.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, GlobalVar.GetServerDate));  // ini emang pake global server date
                    dummy3 = db2.Commands[0].ExecuteDataTable();
                }
                // kalo di bagian ini yang perlu diisikan manual kodetransaksinya yg mana, uraian juga, iya potongan juga boleh   
                string tempAngsuranStr = "Angsuran Ke-" + angsuranke;
                dlg = new dlgProsesGiroMasukPiutang_Cair(kodeTrans, tempAngsuranStr, _ketStatus, lRekening, MataUangID, _rekeningRowID, (DateTime)dummy.Rows[0]["TglJTBGC"]);
                dlg.ShowDialog();
            }
            else if (kodeTrans == Class.enumTipeTitipan.Murni.ToString() || kodeTrans == Class.enumTipeTitipan.UM.ToString() || kodeTrans == Class.enumTipeTitipan.Adm.ToString())
            {
                dummy = new DataTable();
                using (Database dbnew = new Database(GlobalVar.DBShowroom))
                {
                    dbnew.Commands.Add(dbnew.CreateCommand("usp_Link_Get_PenerimaanTitipanxPenjualanxPenjualanHist"));
                    dbnew.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dummy = dbnew.Commands[0].ExecuteDataTable();
                }
                dlg = new dlgProsesGiroMasukPiutang_Cair(kodeTrans, dummy.Rows[0]["Uraian"].ToString(), _ketStatus, lRekening, MataUangID, _rekeningRowID, (DateTime) dummy.Rows[0]["TglJTBGC"]);
                dlg.ShowDialog();
            }
            else if (kodeTrans == "")
            {
                dlg = new dlgProsesGiroMasukPiutang_Cair(kodeTrans, _ketStatus, lRekening, MataUangID, _rekeningRowID, (DateTime) dummy.Rows[0]["TglJTBGC"]);
                dlg.ShowDialog();
            }

            DateTime dTgl = GlobalVar.GetServerDate;
            //Guid _rekeningRowID = Guid.Empty;
            switch (_GiroStatusNew)
            {
                case Class.enumStatusGiro.Disetor:
                    lOk = ((_GiroStatusLast == Class.enumStatusGiro.Diterima) || (_GiroStatusLast == Class.enumStatusGiro.BatalSetor));
                    break;
                case Class.enumStatusGiro.BatalSetor:
                    lOk = (_GiroStatusLast == Class.enumStatusGiro.Disetor);
                    break;
                case Class.enumStatusGiro.Cair:
                    if (_GiroStatusLast != Class.enumStatusGiro.Cair)
                    {
                        lOk = true;
                    }
                    else
                    {
                        lOk = ((_GiroStatusLast == Class.enumStatusGiro.Disetor) || (_GiroStatusLast == Class.enumStatusGiro.Cair));
                    }
                    
                    break;
                case Class.enumStatusGiro.BatalCair:
                    lOk = ((_GiroStatusLast == Class.enumStatusGiro.Cair) && isOkBatalCair);
                    break;
                case Class.enumStatusGiro.Ditolak:
                    break;
                case Class.enumStatusGiro.Batal:
                    break;
                default: lOk = false; break;
            }

            // selesai tambahan update ke penerimaan titipan

            if (lOk)
            {
                lOk = (dlg.DialogResult == DialogResult.Yes);

                if (lOk)
                {
                    dTgl = (DateTime)dlg.dtTanggalInsert.DateValue;

                    if (((DateTime)Tools.isNull(dTgl, DateTime.MinValue) == DateTime.MinValue) || (dTgl < _GiroStatusTanggal)) lOk = false;

                    if (_ketStatus == "Batal Cair" || _ketStatus == "BatalSetor" ||_ketStatus=="Cair" || _ketStatus=="Ditolak")
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_GetLastRekeningRowIDGiroHistory"));
                            db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, lblNoBGC.Text));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (lRekening) _rekeningRowID = (Guid)dt.Rows[0]["RekeningRowID"];
                        }
                    }
                    else
                    {
                        if (lRekening) _rekeningRowID = (Guid)dlg.lookUpRekening1.RekeningRowID;
                    }
                }
            }

            // di sini itu yang bener2 proses menyimpan data
            if (lOk==true)
            {
                Database dbf = new Database();
                Database db = new Database(GlobalVar.DBShowroom);
                int counterdb = 0, counterdbf = 0;

                // ini Guid khusus untuk PenerimaanAngsuran, jadi simpan terlebih dahulu 
                // PenerimaanUangRowID / PenerimaanUangRowIDBunga nya
                Guid tempPenerimaanUangRowID = Guid.NewGuid();
                Guid tempPenerimaanUangRowIDBunga = Guid.NewGuid();

                RealKodeTrans = dummy.Rows[0]["KodeTrans"].ToString();
                try
                {
                    if (_GiroStatusNew == Class.enumStatusGiro.BatalCair)
                    {
                        // hapus data penerimaan angsuran yang bekas cair nya
                        using (Database db2new = new Database(GlobalVar.DBShowroom))
                        {
                            // penerimaan ang delete
                            PenerimaanANGDelete(ref db, ref counterdb, dummy);
                            if (kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
                            {
                                // penerimaan titipan iden delete
                                PenerimaanTitipanIdenDelete(ref db, ref counterdb, (int)Class.enumTipeTitipan.Angsuran, RealKodeTrans);
                            }
                        }
                        if (kodeTrans == Class.enumTipeTitipan.UM.ToString() && RealKodeTrans == "UMB")
                        {
                            PenerimaanUMBungaDelete(ref db, ref counterdb);
                            PenerimaanTitipanIdenDelete(ref db, ref counterdb, (int)Class.enumTipeTitipan.UM, RealKodeTrans);
                        }
                        else if (kodeTrans == Class.enumTipeTitipan.UM.ToString())
                        {
                            PenerimaanUMDelete(ref db, ref counterdb);
                            PenerimaanTitipanIdenDelete(ref db, ref counterdb, (int)Class.enumTipeTitipan.UM, RealKodeTrans);
                        }
                        else if (kodeTrans == Class.enumTipeTitipan.Adm.ToString())
                        {
                            PenerimaanADMDelete(ref db, ref counterdb);
                            PenerimaanTitipanIdenDelete(ref db, ref counterdb, (int)Class.enumTipeTitipan.Adm, RealKodeTrans);
                        }
                    }
                    // kalo bentuknya titipan murni ngga perlu diapa2in, update status aja cukup!!!
                    // kalo status giro narunya itu cair lakukan insert ke tabel lainnya
                    else if (_GiroStatusNew == Class.enumStatusGiro.Cair && (_penjualanRowID.ToString() != "" && _penjualanRowID != Guid.Empty))
                    {
                        //MessageBox.Show(kodeTrans);

                        // kalo mau ngisi NULL  var a = SqlDateTime.Null - tanggal, kalo GUID pake SQLGUID.NULL
                        // jangan pake yang getdate atau guid.null punya c#
                        if (kodeTrans == Class.enumTipeTitipan.UM.ToString() && RealKodeTrans == "UMB") // kalo ini jadiin UMK aja
                        {
                            // urus buat kalo ngisi ke tabel penerimaanUM 
                            // yang perlu diisikan di bagian sini dari dialog itu uraian dan tanggal inputnya
                            // yg perlu dari dialog -> tanggal dan uraian
                            Guid newRowID = Guid.NewGuid();
                            PenerimaanUMBungaInsert(ref db, ref counterdb, dummy, dlg, newRowID, (int)_GiroStatusNew);
                            TitipanIdenInsert(ref db, ref counterdb, dummy, dlg, newRowID, RealKodeTrans);
                        }
                        else if (kodeTrans == Class.enumTipeTitipan.UM.ToString()) // kalo ini jadiin UMK aja
                        {
                            // urus buat kalo ngisi ke tabel penerimaanUM 
                            // yang perlu diisikan di bagian sini dari dialog itu uraian dan tanggal inputnya
                            // yg perlu dari dialog -> tanggal dan uraian
                            Guid newRowID = Guid.NewGuid();
                            PenerimaanUMInsert(ref db, ref counterdb, dummy, dlg, newRowID, (int)_GiroStatusNew);
                            TitipanIdenInsert(ref db, ref counterdb, dummy, dlg, newRowID, (int)Class.enumTipeTitipan.UM);
                        }
                        // yang masuk ke pembayaran angsuran
                        // // baru bisa diurus yang masuk ke angsuran sama titipan 
                        else if (kodeTrans == Class.enumTipeTitipan.Angsuran.ToString()) // kalo ini cuma bisa masukin sebagai ANG dan PLS di yg mau diinsert
                        {
                            lOk = (dlg.DialogResult == DialogResult.Yes);

                            if (lOk == false)
                            {
                                Exception Cancellation = new Exception("Data Batal Diproses!");
                                throw Cancellation;
                            }
                            else if (lOk == true)
                            {
                                //  yang dari dialog -> uraian, tanggal, kodetrans, potongan
                                Guid newRowID = Guid.NewGuid();

                                PenerimaanANGInsert(ref db, ref counterdb, dummy, dlg, newRowID, float.Parse(angsuranke), dummy3, tempPenerimaanUangRowID, tempPenerimaanUangRowIDBunga); // di penerimaanAngInsert, kirimkan PenerimaanUAng RowID nya
                                TitipanIdenInsert(ref db, ref counterdb, dummy, dlg, newRowID, (int)Class.enumTipeTitipan.Angsuran);
                            }
                        }
                        // Awal yang ADM 
                        else if (kodeTrans == Class.enumTipeTitipan.Adm.ToString())
                        {
                            // yang dari dialog itu -> tanggal, uraian 
                            Guid newRowID = Guid.NewGuid();
                            PenerimaanADMInsert(ref db, ref counterdb, dummy, dlg, newRowID, (int)_GiroStatusNew);
                            TitipanIdenInsert(ref db, ref counterdb, dummy, dlg, newRowID, (int)Class.enumTipeTitipan.Adm);
                        }
                        // Akhir yang ADM 
                    }
                        
                    // mulai bagian update ke penerimaan titipan
                    // tambahan update juga ke penerimaan titipan

                    // kemungkinan proses ini bikin blocking, jadinya 
                    // proses ini digabung ke proses GiroHistoryInsert
                    // PenerimaanTitipanUpdateStatusGiro(ref db, ref counterdb, (int)_GiroStatusNew);
                    
                    // GiroHistoryInsert
                    GiroHistoryInsert(ref dbf, ref counterdbf, lRekening, dTgl, (int)_GiroStatusNew, dummy, kodeTrans, tempPenerimaanUangRowID, tempPenerimaanUangRowIDBunga);
                    
                    /*
                    db.BeginTransaction();
                    dbf.BeginTransaction();
                    int looper = 0;
                    for (looper = 0; looper < counterdb; looper++)
                    {
                        db.Commands[looper].ExecuteNonQuery();
                    }
                    for (looper = 0; looper < counterdbf; looper++)
                    {
                        if (looper == counterdbf - 1) // -> karena giro history insert itu yg paling terakhir terus
                        {
                            // commit yg sebelumnya dulu baru mulai lagi, karena yg giro history
                            db.CommitTransaction();
                            dbf.CommitTransaction();
                            dbf.BeginTransaction();
                        }
                        dbf.Commands[looper].ExecuteNonQuery();
                    }
                    // db.CommitTransaction(); // karena udah dipanggil di sebelumnya
                    dbf.CommitTransaction();
                    */
                    
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
                    
                    
                    RefreshData();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    dbf.RollbackTransaction(); 
                    Error.LogError(ex);
                }
            }
        }
        #endregion

        private void lblNominal_Click(object sender, EventArgs e)
        {

        }

        private void frmProsesGiroMasukPiutangUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            MdiParent.Activate();
        }

    }

    
}
