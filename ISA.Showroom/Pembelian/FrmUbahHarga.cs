using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Pembelian
{
    public partial class FrmUbahHarga : ISA.Controls.BaseForm
    {
        Guid HrowID1, HrowID2, HrowID3, HrowID4;
        Guid _RowID; String _NamVendor;
        //String _NoFaktur, _Notransact; Double _HargaLama
        public FrmUbahHarga(Form Caller, Guid RowID, String NoFaktur, String NoTransact, String NamaVendor, String hargaLama)
        {
            InitializeComponent();
            _RowID = RowID;
            this.Caller = Caller;
            this.Title =_NamVendor = NamaVendor;
            lblNoFaktur.Text = NoFaktur;
            lblNoTransact.Text = NoTransact;
            txtHargaLama.Text = hargaLama;
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtHargaBaru.GetIntValue <= 0)
                {
                    MessageBox.Show("Harga baru tidak boleh kurang dari sama dengan Nol(0)");
                    txtHargaBaru.Focus();
                    return;
                }
                pictureBox1.Visible = true;
                label8.Visible = true;
                txtHargaLama.Enabled = false;
                cmdADD.Enabled = false;
                cmdCLOSE.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
                

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }



        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet ds = new DataSet();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Pembelian_EditHarga]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@HargaBaru", SqlDbType.Int, txtHargaBaru.GetIntValue));
                ds = db.Commands[0].ExecuteDataSet();
            }
            Pembalik(ds);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_Pembelian_EditHarga]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@HargaBaru", SqlDbType.Int, txtHargaBaru.GetIntValue));
                db.Commands[0].Parameters.Add(new Parameter("@JournalPblPembalikRowID", SqlDbType.UniqueIdentifier, HrowID1));
                db.Commands[0].Parameters.Add(new Parameter("@JournalPbyPembalikRowID", SqlDbType.UniqueIdentifier, HrowID3));
                db.Commands[0].Parameters.Add(new Parameter("@JournalHPPPembalikRowID", SqlDbType.UniqueIdentifier, HrowID4));
                db.Commands[0].Parameters.Add(new Parameter("@UbahBy", SqlDbType.VarChar, SecurityManager.UserName));
                ds = db.Commands[0].ExecuteDataSet();
            }
        }
        
        private void Pembalik(DataSet ds) 
        {
            if (ds.Tables.Count != 0) 
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    String HrecordID = Tools.CreateFingerPrint();
                     HrowID1 = Guid.NewGuid();
                    foreach (DataRow row in ds.Tables[0].Rows) // Loop over the rows.
                    {
                        ProsesPembalik(row, 0, HrecordID, HrowID1);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows) // Loop over the rows.
                        {
                            ProsesPembalik(row, 1, HrecordID, HrowID1);
                        }
                    }
                }
               
                if (ds.Tables[2].Rows.Count > 0)
                {
                    String HrecordID = Tools.CreateFingerPrint();
                     HrowID2 = Guid.NewGuid();
                    foreach (DataRow row in ds.Tables[2].Rows) // Loop over the rows.
                    {
                        ProsesPembalik(row, 0, HrecordID, HrowID2);
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[3].Rows) // Loop over the rows.
                        {
                            ProsesPembalik(row, 1, HrecordID, HrowID2);
                        }
                    }
                }
                if (ds.Tables[4].Rows.Count > 0)
                {

                    foreach (DataRow row in ds.Tables[4].Rows) // Loop over the rows.
                    {
                        ProsesPembalik(row, 2, "", HrowID3);
                    }
                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    String HrecordID = Tools.CreateFingerPrint();
                    HrowID4 = Guid.NewGuid();
                    foreach (DataRow row in ds.Tables[5].Rows) // Loop over the rows.
                    {
                        ProsesPembalik(row, 0, HrecordID, HrowID4);
                    }
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[6].Rows) // Loop over the rows.
                        {
                            ProsesPembalik(row, 1, HrecordID, HrowID4);
                        }
                    }
                }
                
            }
        }

        private void ProsesPembalik(DataRow row, int detail, String _HRecordId, Guid HrowID) 
        {
            switch (detail)
            {
                case 0 :
                    using (Database db = new Database())
                    {
                        
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[ISAFinanceOtoDbTLA].[dbo].[usp_Journal_INSERT]"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, new Guid(row["PerusahaanRowID"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HrowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _HRecordId));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, row["ref"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Batal - "+row["Uraian"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, row["Src"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, row["KodeGudang"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, row["SyncFlag"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    break;
                case 1:
                    using (Database db = new Database())
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[ISAFinanceOtoDbTLA].[dbo].[usp_JournalDetail_INSERT]")); db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HrowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HRecordId));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, row["NoPerkiraan"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Batal - " + row["Uraian"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, row["Kredit"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, row["Debet"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, row["DK"].ToString() == "K" ? "D" : "K"));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, row["NoReff"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, new Guid(row["MataUangRowID"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalOri", SqlDbType.Money, Convert.ToDouble(row["NominalOri"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    break; 
                case 2:
                    using (Database db = new Database())
                    {

                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + "B" + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.DateOfServer)
                                                        , 4, false, true);
                        HrowID3 = Guid.NewGuid();
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[ISAFinanceOtoDbTLA].[dbo].[usp_PenerimaanUang_INSERT]")); 
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HrowID3));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.DateOfServer));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, Convert.ToDateTime(row["TanggalRk"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, row["NoApproval"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, row["PerusahaanDariRowID"].ToString() != "" ? new Guid(row["PerusahaanDariRowID"].ToString()) : Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, row["PerusahaanKeRowID"].ToString() != "" ? new Guid(row["PerusahaanKeRowID"].ToString()) : Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, row["CabangKeID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, row["CabangDariID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, new Guid( row["MataUangRowID"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, new Guid( row["JnsTransaksiRowID"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDouble(row["Nominal"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Convert.ToDouble(row["NominalRp"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar," Batal - "+ row["Uraian"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, row["JnsPenerimaan"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, row["KasRowID"].ToString() !="" ?  new Guid(row["KasRowID"].ToString()) : Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, row["RekeningRowID"].ToString() != "" ? new Guid(row["RekeningRowID"].ToString()) : Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, row["RekeningRowID"].ToString() != "" ? new Guid(row["RekeningRowID"].ToString()) : Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, row["NoCekGiro"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaGiro", SqlDbType.VarChar, ""));//row["KotaGiro"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalGiroCair", SqlDbType.VarChar, row["DueDateGiro"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@JournalRowID", SqlDbType.UniqueIdentifier, HrowID2));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    break;
           }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            label8.Visible = false;
            this.Close();
        }

        private void FrmUbahHarga_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Pembelian.frmPembelianBrowseTLA)
            {
                Pembelian.frmPembelianBrowseTLA frmCaller = (Pembelian.frmPembelianBrowseTLA)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("RowID", _RowID.ToString());
            }
        }
       
    }
}
