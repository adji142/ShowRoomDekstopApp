using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmPembayaranMPMIdenHutang : ISA.Controls.BaseForm
    {
        Guid PengeluaranUangRowID = Guid.Empty;
        DataTable dt;
        Decimal SaldoAwal = 0;
        Decimal SaldoAwalLSG = 0;
        Decimal SaldoAwalSBD = 0;
        double _saldoSisa = 0;
        double _saldoiden = 0;
        double _nominalPembayaran = 0;
        double _nominalSisaBayar = 0;
        string _jenisPembayaran = "Bank";
        Guid _rowID;
        string lblNoTrans = "";

        public frmPembayaranMPMIdenHutang()
        {
            InitializeComponent();
        }

        public frmPembayaranMPMIdenHutang(Form _Caller, Guid RowIDH)
        {
            InitializeComponent();
            Caller = _Caller;
            PengeluaranUangRowID = RowIDH;
            refreshPengeluaranUang();
        }

        private void refreshPengeluaranUang()
        {
            dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PembayaranMPM_LIST_byId"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            txtNominal.Text = dt.Rows[0]["Nominal"].ToString();
            txtNoBukti.Text = dt.Rows[0]["NoBukti"].ToString();
            txtNamaVendor.Text = dt.Rows[0]["NamaVendor"].ToString();
            _jenisPembayaran=dt.Rows[0]["JnsPengeluaran"].ToString();
            _saldoiden = double.Parse(dt.Rows[0]["NominalIden"].ToString()) + double.Parse(dt.Rows[0]["NominalPenerimaan"].ToString());
            txtSaldoIden.Text = _saldoiden.ToString();
            txtSaldoSisa.Text = dt.Rows[0]["NominalSisa"].ToString();
            _saldoSisa = double.Parse(dt.Rows[0]["NominalSisa"].ToString());
            txtTanggal.DateValue = Convert.ToDateTime(dt.Rows[0]["Tanggal"]);

            
        }

        public void RefreshHeader()
        {
            try
            {
                Console.WriteLine(GlobalVar.CabangID);
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PembelianMPM_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    DataColumn cConcatenated1 = new DataColumn("MerkType", Type.GetType("System.String"), "MerkMotor + ' / ' + TypeMotor");
                    dt.Columns.Add(cConcatenated1);
                    GVPembelian.DataSource = dt;
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

        private void RefreshDetail()
        {
            if (GVPembelian.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_SALDO"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GVPembelian.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    GVIden.DataSource = dt;
                }

                if (GVIden.Rows.Count > 0)
                {
                    _nominalPembayaran = double.Parse(dt.Rows[0]["Pembayaran"].ToString()); ;
                    _nominalSisaBayar = double.Parse(dt.Rows[0]["SisaBayar"].ToString()); ;
                }
            }
            
        }

        private void frmPembayaranMPMIdenHutang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            btnSearch.PerformClick();
            //GVIden.ReadOnly = false;

            GVIden.ReadOnly = false;
            GVIden.Enabled = true;
            GVIden.Columns["HutangUM"].ReadOnly = true;
            GVIden.Columns["BayarUM"].ReadOnly = true;
            GVIden.Columns["SisaUM"].ReadOnly = true;
            GVIden.Columns["HutangPokok"].ReadOnly = true;
            GVIden.Columns["Pembayaran"].ReadOnly = true;
            GVIden.Columns["SisaBayar"].ReadOnly = true;
            GVIden.Columns["BiayaRepr"].ReadOnly = true;
            GVIden.Columns["BiayaTamb"].ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            if (GVPembelian.Rows.Count > 0)
            {
                RefreshDetail();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            double Iden = Double.Parse(Tools.isNull(GVIden.SelectedCells[0].OwningRow.Cells["NominalIden"].Value, "0").ToString());
            if (Iden <= 0)
            {
                MessageBox.Show("Nominal Iden belum diisi");
                return;
            }
            prosesSave();
        }


        private void pembayaranPembInsert(ref Database db, ref int counterdb, Guid pengeluaranUangRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "ANG"));

            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, (Guid)GVPembelian.SelectedCells[0].OwningRow.Cells["RowID"].Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, "Iden MPM " + txtNoBukti.Text + " No PBL " + (string)GVPembelian.SelectedCells[0].OwningRow.Cells["NoFaktur"].Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, "IDR"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Double.Parse(Tools.isNull(GVIden.SelectedCells[0].OwningRow.Cells["NominalIden"].Value, "0").ToString())));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

            // tambahin bentuk pembayarannya sama rekening rowID nya
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1));


            counterdb++;
        }

        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran)
        {
            DataTable dtsub = new DataTable();
            Guid _JnsTransaksiRowID = Guid.Empty, _MataUangRowID = Guid.Empty,
            _KasBesarRowID = Guid.Empty;
            // ambil data dari pembelian dulu
            using (Database dbsub = new Database(GlobalVar.DBShowroom))
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_Pembelian_LIST"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GVPembelian.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                dtsub = dbsub.Commands[0].ExecuteDataTable();
            }
            // [usp_MataUang_LIST] @MataUangID varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_MataUang_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, "IDR"));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));

                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, "22"));
                
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            using (Database db = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(dbf.CreateCommand("usp_Kas_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, (Guid)(Tools.isNull(GlobalVar.PerusahaanRowID, System.Guid.Empty.ToString()))));
                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, "Kas Besar"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _KasBesarRowID = new System.Guid(Tools.isNull(dt.Rows[0]["RowID"], System.Guid.Empty.ToString()).ToString());
                }
            }
        }

        private void prosesSave()
        {
            Database db = new Database(GlobalVar.DBShowroom);
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            int counterdb = 0, counterdbf = 0;
            String bentukPengeluaran = "";
            Guid pengeluaranUangRowID = PengeluaranUangRowID;
            String NoTransPengeluaran;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if(_jenisPembayaran=="Bank"){
                    bentukPengeluaran = "B";
                }
                else{
                    bentukPengeluaran = "K";
                }
                        
                _rowID = Guid.NewGuid();


               lblNoTrans = Numerator.NextNumber("NKB");

                // di bawah ini itu ngebentuk Bukti Uang Keluar bukan bukti bayar pembelian !!!
                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                  string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true); 
                    pembayaranPembInsert(ref db, ref counterdb, pengeluaranUangRowID);
                    pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranUangRowID, bentukPengeluaran, NoTransPengeluaran);
                    // hmm di penjualan itu biasanya pake notrans transaksinya, ngga buat dari numerator (penerimaan/pengeluaran) baru
                
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
                //if (this.Caller is Kasir.frmPembayaranMPM)
                //{
                //    Kasir.frmPembayaranMPM frmCaller = (Kasir.frmPembayaranMPM)this.Caller;
                //    frmCaller.RefreshData(PengeluaranUangRowID);
                //    frmCaller.refreshDetail();
                //}
                //this.Close();
                refreshPengeluaranUang();
                RefreshDetail();

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

      
        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (this.Caller is Kasir.frmPembayaranMPM)
            {
                Kasir.frmPembayaranMPM frmCaller = (Kasir.frmPembayaranMPM)this.Caller;
                frmCaller.RefreshData(PengeluaranUangRowID);
                frmCaller.refreshDetail();
            }
            this.Close();
        }

        private void GV_Penjualan_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Hanya boleh memasukkan angka.");
        }

        private void GV_PenerimaanUM_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Hanya boleh memasukkan angka.");
        }

        private void GVPembelian_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void GVIden_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Hanya boleh memasukkan angka.");
        }

        private void GVIden_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void GVIden_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (GVIden.Rows.Count > 0)
            {
                try
                {
                    double Iden = Double.Parse(Tools.isNull(GVIden.Rows[e.RowIndex].Cells["NominalIden"].Value, "0").ToString());
                    double sisaBayar = _nominalSisaBayar;
                    double SisaSaldo = _saldoSisa;

                    if (Iden > SisaSaldo && SisaSaldo < sisaBayar)
                    {
                        MessageBox.Show("Sisa Saldo Anda Hanya " + SisaSaldo);
                        Iden=SisaSaldo;
                        //GVIden.Rows[e.RowIndex].Cells["NominalIden"].Value = SisaSaldo;
                        //GVIden.Rows[e.RowIndex].Cells["Pembayaran"].Value = _nominalPembayaran + SisaSaldo;
                        //GVIden.Rows[e.RowIndex].Cells["SisaBayar"].Value = _nominalSisaBayar - SisaSaldo;
                        //return;
                    }

                    if (Iden > sisaBayar && sisaBayar <=SisaSaldo)
                    {
                        MessageBox.Show("Sisa Bayar Hanya " + sisaBayar);
                        Iden = sisaBayar;
                        //GVIden.Rows[e.RowIndex].Cells["NominalIden"].Value = sisaBayar;
                        //GVIden.Rows[e.RowIndex].Cells["Pembayaran"].Value = _nominalPembayaran + sisaBayar;
                        //GVIden.Rows[e.RowIndex].Cells["SisaBayar"].Value = _nominalSisaBayar - sisaBayar;
                        //return;
                    }

                    GVIden.Rows[e.RowIndex].Cells["Pembayaran"].Value = _nominalPembayaran + Iden;
                    GVIden.Rows[e.RowIndex].Cells["SisaBayar"].Value = _nominalSisaBayar - Iden;
                    GVIden.Rows[e.RowIndex].Cells["NominalIden"].Value = Iden;

                    txtSaldoSisa.Text = (SisaSaldo - Iden).ToString();
                    txtSaldoIden.Text = (_saldoiden + Iden).ToString();


                }
                catch
                {
                    MessageBox.Show("Inputan harus berupa angka");
                    GVIden.Rows[e.RowIndex].Cells["NominalIden"].Value = 0;
                    return;
                }
            }
        }
    }
}
