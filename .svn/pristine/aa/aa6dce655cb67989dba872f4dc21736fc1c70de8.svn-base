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

namespace ISA.Showroom.Pembelian
{
    public partial class frmPelunasanPembelianUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID, _pembRowID;
        string _cabangID = GlobalVar.CabangID;
        Double _nominal, _hargaOff, _uangmuka, _potongan;
        String _jenis;
        String _nopol;
        Decimal _Angsuran, _DP;
        String _flagSource;

        public frmPelunasanPembelianUpdate(Form caller, Guid pembRowID, string jenis)
        {
            InitializeComponent();
            _pembRowID = pembRowID;
            
            _jenis = jenis;
            this.Caller = caller;
        }

        private void frmPelunasanPembelianUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _pembRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    lblSisaPembayaran.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaBayar"], 0)));
                    _hargaOff = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Harga"], 0));
                    _uangmuka = Convert.ToDouble(Tools.isNull(dt.Rows[0]["UangMuka"], 0));
                    lblSisaUangMuka.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["UangMuka"], 0)));

                    if (GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
                    {
                        txtTanggal.DateValue = GlobalVar.GetServerDateTime_RealTime;
                    }
                    else
                    {
                        txtTanggal.DateValue = GlobalVar.GetServerDateTime_RealTime;
                    }

                    _nopol = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();
                    
                    _DP = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["UangMuka"], "").ToString());
                    _Angsuran = (Convert.ToDecimal(Tools.isNull(dt.Rows[0]["SisaBayar"], 0).ToString()) - Convert.ToDecimal(Tools.isNull(dt.Rows[0]["UangMuka"], 0).ToString()) );
                    
                    DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                    dt2.DefaultView.Sort = "MataUangID ASC";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.ValueMember = "MataUangID";
                    cboMataUang.DataSource = dt2.DefaultView;
                    
                    _flagSource = Tools.isNull(dt.Rows[0]["FlagSource"], "ORI").ToString();
                    _potongan = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Potongan"], 0));

                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }
                    if (GlobalVar.CabangID == "06B")
                    {
                        cbxJnsTransaksi.SelectedIndex = 1;
                    }
                    else
                    {
                        cbxJnsTransaksi.SelectedIndex = 0;
                    }
                    cbxBentukPembayaran.SelectedIndex = 0;

                    if (_flagSource == "BARU")
                    {
                        // mestinya kalau 'BARU' ini harusnya DP = 0, dan sisa piutangnya itu dikurangin Potongan untuk nentuin sisa bayarnya
                        lblSisaUangMuka.Text = "0";
                        lblSisaPembayaran.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaBayarBARU"], 0)));
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
            if (String.IsNullOrEmpty(txtNominal.Text) || Convert.ToDecimal(txtNominal.Text) < 1)
            {
                MessageBox.Show("Nominal Pelunasan belum diisi !");
                txtNominal.Focus();
                return false;
            }

            if(cbxJnsTransaksi.SelectedIndex == 0) // yg 0 itu yang DP
            {
               if(Convert.ToDecimal(txtNominal.Text) > Convert.ToDecimal(lblSisaUangMuka.Text))
               {
                   MessageBox.Show("Nominal Pelunasan lebih besar dari pada Sisa Pembayaran !");
                   txtNominal.Focus();
                   return false;
               }
            }

            if(cbxJnsTransaksi.SelectedIndex == 1) // yg 1 itu yang Pelunasan
            {
               if(Convert.ToDecimal(txtNominal.Text) > Convert.ToDecimal(lblSisaPembayaran.Text))
               {
                   MessageBox.Show("Nominal Pelunasan lebih besar dari pada Sisa Pembayaran !");
                   txtNominal.Focus();
                   return false;
               }
            }

            if(cbxBentukPembayaran.SelectedIndex == 1)  // yg 1 itu kalo transfer
            {
                if (lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID.ToString() == "" || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    MessageBox.Show("Tolong pilih rekening terlebih dahulu !");
                    lookUpRekening1.Focus();
                    return false;
                }
            }

            if (txtTanggal.DateValue < GlobalVar.GetServerDateTime_RealTime.Date || txtTanggal.DateValue > GlobalVar.GetServerDateTime_RealTime.Date.AddDays(2))
            {
                MessageBox.Show("Isian Tanggal di luar batasan yg berlaku!");
                txtTanggal.DateValue = GlobalVar.GetServerDateTime_RealTime.Date;
                return false;
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
            return true;
        }

        private void pembayaranPembInsert(ref Database db, ref int counterdb, Guid pengeluaranUangRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
            
            if(cbxJnsTransaksi.SelectedIndex == 0) // 0 itu DP
            {   /*
                if (_jenis == "TUNAI")
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "TUN"));
                }
                else
                { */
                db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "UMK"));
                //} // jadiin UMK terus dulu aja kalo tipenya DP
            }
            else if(cbxJnsTransaksi.SelectedIndex == 1) // 1 itu Pelunasan
            {           
                db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "ANG"));
            }                                                            
            else if(cbxJnsTransaksi.SelectedIndex == 2) // 2 itu Reparasi
            {             
                db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "REP"));
            } 
            else if(cbxJnsTransaksi.SelectedIndex == 3) // 3 itu Tambahan
            {         
                db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "TAM"));
            } 

            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _pembRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

            // tambahin bentuk pembayarannya sama rekening rowID nya
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, (cbxBentukPembayaran.SelectedIndex + 1) ));
            if ((cbxBentukPembayaran.SelectedIndex + 1) == 2) // kalo transfer baru kasih RekeningRowID nya
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            }

            counterdb++;
        }

        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran)
        {
            DataTable dtsub = new DataTable();
            Guid _JnsTransaksiRowID = Guid.Empty, _MataUangRowID = Guid.Empty;
            // ambil data dari pembelian dulu
            using(Database dbsub = new Database())
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_Pembelian_LIST"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _pembRowID));
                dtsub = dbsub.Commands[0].ExecuteDataTable();
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
                    if (_flagSource == "ORI")
                    {
                        if (cbxJnsTransaksi.SelectedIndex == 2 || cbxJnsTransaksi.SelectedIndex == 3) // 2 itu Reparasi // 3 itu tambahan
                        {
                            dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAReparasiMotorBekas).ToString()));  // Pembelian Motor Bekas -> (55) 
                        }
                        else
                        {
                            dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPembelianMotorBekas).ToString()));  // Pembelian Motor Bekas -> (55) 
                        }
                    }
                    else if (_flagSource == "BARU")
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPembelianMotorBaru).ToString()));  // Pembelian Motor Baru -> (54) 
                    }
                }
                else
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PembelianMotor).ToString()));  // Pembelian Motor -> (22) PersediaanBarang
                }
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            dbf.Commands.Add(dbf.CreateCommand("usp_PengeluaranUang_INSERT_SIMPLE"));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));
            
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTanggal.DateValue)); // tglrk.DateValue 
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, string.Empty)); // txtNoAcc.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, string.Empty)); // txtNoApproval1.Text

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPengeluaran)); // mestinya pake numerator
            
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, (Guid) Tools.isNull(dtsub.Rows[0]["VendorRowID"], Guid.Empty)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));  // 32 - Pembelian Motor
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDecimal(txtNominal.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Convert.ToDecimal(txtNominal.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukPengeluaran)); // dari bentukPembayaran kah???
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty)); // kosongin // aman untuk jurnal pengeluaran
            
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9)); // defaultin 9
            
            if(cbxBentukPembayaran.SelectedIndex == 0) // kalo tunai baru kas rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // dari globalvar
            }
            else if (cbxBentukPembayaran.SelectedIndex == 1) // kalo transfer baru rekening rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (Guid) Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty)));
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2)); // defaultin ke 2 (ke perusahaan)
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            int counterdb = 0, counterdbf = 0;
            String bentukPengeluaran = "";
            Guid pengeluaranUangRowID = Guid.NewGuid();
            String NoTransPengeluaran;

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

                switch (cbxBentukPembayaran.SelectedIndex)
                {
                    case 0: // kalo 0 itu tunai -> K
                        bentukPengeluaran = "K"; 
                        break;
                    case 1: // kalo 1 itu transfer -> B
                        bentukPengeluaran = "B";
                        break;
                }
                _rowID = Guid.NewGuid();
                

                lblNoTrans.Text = Numerator.NextNumber("NKB");

                // di bawah ini itu ngebentuk Bukti Uang Keluar bukan bukti bayar pembelian !!!
                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                            string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4,false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 
                
                if (Convert.ToDouble(txtNominal.Text) > 0)
                {
                    pembayaranPembInsert(ref db, ref counterdb, pengeluaranUangRowID);
                    pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranUangRowID, bentukPengeluaran, NoTransPengeluaran); 
                    // hmm di penjualan itu biasanya pake notrans transaksinya, ngga buat dari numerator (penerimaan/pengeluaran) baru
                }

                int looper = 0;
                db.BeginTransaction();
                dbf.BeginTransaction();
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
                MessageBox.Show("Data berhasil diproses");
                this.Close();                
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                dbf.RollbackTransaction();
                MessageBox.Show("Data gagal disimpan !\n " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmPelunasanPembelianUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Pembelian.frmPelunasanPembelianBrowse)
            {
                Pembelian.frmPelunasanPembelianBrowse frmCaller = (Pembelian.frmPelunasanPembelianBrowse)this.Caller;
                frmCaller.RefreshRow(_rowID);
                frmCaller.FindRowGrid3("NoTrans", lblNoTrans.Text);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxJnsTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxJnsTransaksi.SelectedIndex)
            {
                // 0 itu DP
                case 0:  if (GlobalVar.CabangID == "06B")
                         {
                             MessageBox.Show("Tidak bisa menggunakan tipe ini!");
                             cbxJnsTransaksi.SelectedIndex = 1;
                         }
                         txtNominal.Enabled = false;
                         txtNominal.ReadOnly = true;
                         txtNominal.Text = _DP.ToString();
                         break;
                // 1 itu Pelunasan
                case 1 : // cek dulu, udah pernah bayar DP blom, kalo blom, arahin bayar DP nya dulu
                         // lihat di label sisa bayar Um nya
                         if (Convert.ToDouble(lblSisaUangMuka.Text.ToString()) > 0)
                         {
                             // kalo masih ada sisa bayaran UM
                             MessageBox.Show("Belum dapat melakukan proses pelunasan, lunasi DP terlebih dahulu.");
                             cbxJnsTransaksi.SelectedIndex = 0;
                             cbxJnsTransaksi.Refresh();
                             txtNominal.Enabled = false;
                             txtNominal.ReadOnly = true;
                             txtNominal.Text = _DP.ToString();
                         }
                         else
                         {
                             txtNominal.Enabled = false;
                             txtNominal.ReadOnly = true;
                             txtNominal.Text = _Angsuran.ToString();
                             // tapi kalau tipe pembeliannya kredit angsuran, ini bisa diedit nominalnya
                             // kalau _FlagSource nya 'BARU' juga bisa berkali kali
                             if (_jenis.ToUpper() == "KREDIT" || _flagSource == "BARU")
                             {
                                 txtNominal.Enabled = true;
                                 txtNominal.ReadOnly = false;
                             }
                         }
                         break;   
                // 2 itu Reparasi
                case 2: txtNominal.Enabled = true;
                        txtNominal.ReadOnly = false;
                        break;   
                // 3 itu Tambahan
                case 3: txtNominal.Enabled = true;
                        txtNominal.ReadOnly = false;
                        break;
            }

            txtUraian.Text = "PMBYRN " + cbxJnsTransaksi.Text + " Motor " + _nopol + " | " + lblNoFaktur.Text + " | " + lblNama.Text;
        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBentukPembayaran.SelectedIndex == 0) // kalo tunai
            {
                lookUpRekening1.Enabled = false;
            }
            else if(cbxBentukPembayaran.SelectedIndex == 1) // kalo transfer
            {
                lookUpRekening1.Enabled = true;
            }
        }


    }
}
