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
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Penjualan
{
    public partial class frmTitipanAdjustment : ISA.Controls.BaseForm
    {
        Guid _TitipanRowID = Guid.Empty;
        Guid _CustomerRowID = Guid.Empty;
        Guid _PenjRowID = Guid.Empty;
        Guid _PenjHistRowID = Guid.Empty;
        Guid _AngsuranRowId = Guid.Empty;

        public frmTitipanAdjustment(Form Caller, Guid TitipanRowID)
        {
            InitializeComponent();
            _TitipanRowID = TitipanRowID;
            this.Caller = Caller;
        }

        private void frmTitipanAdjustment_Load(object sender, EventArgs e)
        {
            txtTanggal.DateValue = GlobalVar.GetServerDate;

            DataTable dt = FillComboBox.DBGetMataUang(Guid.Empty, "");
            dt.DefaultView.Sort = "MataUangID ASC";
            cboMataUang.DisplayMember = "MataUangID";
            cboMataUang.ValueMember = "MataUangID";
            cboMataUang.DataSource = dt.DefaultView;

            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_LIST_Adjustment"));
                db.Commands[0].Parameters.Add(new Parameter("@TitipanRowID", SqlDbType.UniqueIdentifier, _TitipanRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                if (dummy.Rows.Count > 0)
                {
                    _CustomerRowID = new Guid(Tools.isNull(dummy.Rows[0]["CustomerRowID"], Guid.Empty).ToString());
                    lblNama.Text = Tools.isNull(dummy.Rows[0]["Nama"], "").ToString().Trim();
                    lblNoTrans.Text = Tools.isNull(dummy.Rows[0]["NoTrans"], "").ToString().Trim();
                    txtNominal.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["SaldoTitipan"], "").ToString()).ToString();
                    txtSaldoTitipan.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["SaldoTitipan"], "").ToString()).ToString();

                    txtSaldoTitipan.Enabled = false;
                    txtSaldoTitipan.ReadOnly = true;

                    rbKorPA.Checked = true;
                    cmdSearch.Enabled = true;
                    txtNoAngs.Enabled = false;
                    txtNoAngs.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Data tidak dapat diproses!");
                    this.Close();
                    return;
                }
            }
        }


        private void penerimaanTitipanIdenInsert(ref Database db, ref int counterdb, Guid PengeluaranUangRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, _TitipanRowID));
            if(rbKorPA.Checked == true)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _PenjHistRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanAngsuranKoreksiRowID", SqlDbType.UniqueIdentifier, _AngsuranRowId));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _PenjRowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue.Value)); // GlobalVar.GetServerDate
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, txtNominal.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
            
            counterdb++;
        }

        // untuk memasukkan data biaya Komisi
        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran)
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
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TTP).ToString())); // UM Pelanggan
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
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Koreksi Titipan | " + lblNoTrans.Text.Trim() + " - " + lblNama.Text.Trim() ));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9)); // defaultin 9

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukPengeluaran)); // mestinya selalu 'K'
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty)); // kosongin // aman untuk jurnal pengeluaran

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // dari globalvar
            
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2)); // defaultin ke 2 (ke perusahaan)
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private bool validateSave()
        {
            if (txtNominal.GetDoubleValue > txtSaldoTitipan.GetDoubleValue)
            {
                MessageBox.Show("Tidak bisa mengkoreksi lebih besar dari Saldo yg tersisa!");
                txtNominal.Focus();
                return false;
            }

            if (cbxBentukPembayaran.SelectedIndex == 1)
            {
                if (lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    MessageBox.Show("Pilih Rekening Terlebih dahulu!");
                    lookUpRekening1.Focus();
                    return false;
                }
            }

            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (validateSave())
            {
                Database db = new Database();
                Database dbf = new Database(GlobalVar.DBFinanceOto);

                Guid pengeluaranUangRowID = Guid.NewGuid();
                String bentukPengeluaran = "";

                switch (cbxBentukPembayaran.SelectedIndex)
                {
                    case 0: bentukPengeluaran = "K";
                        break;
                    case 1: bentukPengeluaran = "B";
                        break;
                }

                int counterdb = 0;
                int counterdbf = 0;
                try
                {
                    penerimaanTitipanIdenInsert(ref db, ref counterdb, pengeluaranUangRowID);

                    Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                    String NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukPengeluaran + "K/" +
                                                                string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                    pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranUangRowID, bentukPengeluaran, NoTransPengeluaran);

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
                    MessageBox.Show("Data berhasil diproses");
                    this.Close();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    dbf.RollbackTransaction();
                    MessageBox.Show("Data gagal diupdate !\n" + ex.Message);
                }
            }
            else
            {
                return;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            frmTitipanAdjustmentBrowseAngsuran ifrmChild = new frmTitipanAdjustmentBrowseAngsuran(this, _CustomerRowID);
            ifrmChild.ShowDialog();
            _PenjRowID = ifrmChild._PenjRowID;
            _PenjHistRowID = ifrmChild._PenjHistRowID;
            _AngsuranRowId = ifrmChild._AngsRowID;
            txtNoAngs.Text = ifrmChild._NoKwitansi;
        }

        private void rbKorPA_CheckedChanged(object sender, EventArgs e)
        {
            urusKoreksi();
        }

        private void rbKorPT_CheckedChanged(object sender, EventArgs e)
        {
            urusKoreksi();
        }

        private void urusKoreksi()
        {
            if (rbKorPA.Checked == true)
            {
                cmdSearch.Enabled = true;
                txtNoAngs.Enabled = false;
                txtNoAngs.ReadOnly = true;
            }
            else if (rbKorPT.Checked == true)
            {
                cmdSearch.Enabled = false;
                txtNoAngs.Enabled = false;
                txtNoAngs.ReadOnly = true;
                _PenjRowID = Guid.Empty;
                _PenjHistRowID = Guid.Empty;
                _AngsuranRowId = Guid.Empty;
                txtNoAngs.Text = "";
            }
        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            urusBentukPembayaran();
        }

        private void urusBentukPembayaran()
        {
            if (cbxBentukPembayaran.SelectedIndex == 0)
            {
                // tunai
                lookUpRekening1.Enabled = false;
                lookUpRekening1.RekeningRowID = Guid.Empty;
                lookUpRekening1.NamaRekening = "";
            }
            else if (cbxBentukPembayaran.SelectedIndex == 1)
            {
                lookUpRekening1.Enabled = true;
            }
        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            if (txtNominal.GetDoubleValue > txtSaldoTitipan.GetDoubleValue)
            {
                MessageBox.Show("Tidak bisa mengkoreksi lebih besar dari Saldo yg tersisa!");
                txtNominal.Text = txtSaldoTitipan.Text;
                txtNominal.Focus();
            }
        }

    }
}
