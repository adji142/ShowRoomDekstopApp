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
using System.Text.RegularExpressions;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPenjualanEditOTR : ISA.Controls.BaseForm
    {
        Guid _penjRowID= Guid.Empty;
        Guid HrowID1 ;
        Guid Rowidjournalbatal = Guid.Empty;
        String _mode, _tgljual = "";
        enum FormMode { New, Update };
     

        Double OTROri = 0, OTRPrev = 0, perubahan = 0;

        public frmPenjualanEditOTR(Form caller, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _penjRowID = rowID;
            
        }


        #region Kalkulasi OTR Lama

        // hanya Leasing aja ya yg diurus
        // yang paling penting di layar ini itu proses perhitungan ulangnya untuk OTR nya kalau diubah, juga kalau pas onLoad

        // harga otr <inputan> = harga jadi + bbn + adm 
        // harga jadi <kalkulasi> = harga otr - bbn - adm
        // adm <inputan> = adm
        // bbn <inputan> = bbn
        // diskon <inputan> = diskon
        // total <kalkulasi> = hargajadi + bbn + adm - diskon
        // sisapokok <kalkulasi> = (hargajadi + bbn + adm) - (um + diskon + adm)

        private void urusSisaPokokLama()
        {
            // dari sp nya
            // (ISNULL(@HargaJadi,0) + ISNULL(@BBN,0)) - ISNULL(@UangMuka,0) -> ini itu piutang pokok
            // (txtHarga + txtBBN) - txtUangMuka
            
            bool tempresult = false;
            double tempdump = 0;
            double temphargajualnett;
            double tempUM;
            double tempADM;

            tempresult = Double.TryParse(txtFauxTotalLama.Text, out tempdump);
            if (tempresult)
            {
                temphargajualnett = tempdump;
            }
            else
            {
                temphargajualnett = 0;
            }
            tempresult = Double.TryParse(txtUMTotalLama.Text, out tempdump); // tadinya dari txtUangMuka.Text
            if (tempresult)
            {
                tempUM = tempdump;
            }
            else
            {
                tempUM = 0;
            }
            tempresult = Double.TryParse(txtBiayaADMLama.Text, out tempdump); // tadinya dari txtUangMuka.Text
            if (tempresult)
            {
                tempADM = tempdump;
            }
            else
            {
                tempADM = 0;
            }
            txtSisaPokok.Text = txtSisaPokokLama.Text = (temphargajualnett - (tempUM /*+ tempADM*/)).ToString();
        }

        private void urusLeasingLama()
        {
            // UM subsidi itu hitungan, ngga bisa diubah2
            double umdibayarkan = Convert.ToDouble(Tools.isNull(txtUangMuka.Text, "0").ToString());
            double umtotal = Convert.ToDouble(Tools.isNull(txtUMTotal.Text, "0").ToString());
            if (umdibayarkan > umtotal)
            {
                MessageBox.Show("UM yg mau dibayarkan lebih besar dari UM yg seharusnya!");
                txtUMTotal.Focus();
                return;
            }
            else
            {
                double umsubsidi = umtotal - umdibayarkan;
                txtUMSubsidiLama.Text = txtUMSubsidi.Text = umsubsidi.ToString();
            }
        }

        private void urusHargaLama()
        {
            txtHarga.Text = txtHargaLama.Text = Convert.ToDouble(txtHargaOTRLama.GetDoubleValue - txtBBNLama.GetDoubleValue /*- txtBiayaADMLama.GetDoubleValue*/).ToString();
        }
        private void urusTotalLama()
        {
            txtTotal.Text = txtTotalLama.Text = (txtHargaLama.GetIntValue + txtBBNLama.GetIntValue /*+ txtBiayaADMLama.GetIntValue*/ - txtDiscountLama.GetDoubleValue).ToString();
        }
        private void urusFauxtotalLama()
        {
            // harga otr itu sudah termasuk harga jadi + bbn + adm
            txtFauxTotal.Text = txtFauxTotalLama.Text = (txtHargaOTRLama.GetDoubleValue - txtDiscountLama.GetDoubleValue /*+ txtBiayaADM.GetDoubleValue*/).ToString();
        }

        private void recalcCompiledLama()
        {
            urusHargaLama();
            urusFauxtotalLama();
            urusSisaPokokLama();
        }
        #endregion

        private void frmPenjualanEditOTR_Load(object sender, EventArgs e)
        {
            // pasti leasing!!!
            DataTable _dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                _dt = db.Commands[0].ExecuteDataTable();
            }
            _tgljual = _dt.Rows[0]["TglJual"].ToString();
            // ambil data biaya komisinya juga
            txtDiscountLama.Text = txtDiscount.Text = Tools.isNull(_dt.Rows[0]["Discount"], "0").ToString();
            
            lblNoFaktur.Text = Tools.isNull(_dt.Rows[0]["NoBukti"], "").ToString();
            lblNoNota.Text = Tools.isNull(_dt.Rows[0]["NoTrans"], "").ToString();
            
            // karena hanya leasing yg bisa, anggap tunai saja!!!
            txtUangMuka.Text = "0";
        
            // kalo pas update masuk ke sini, nanti mesti ambil data UM nya dari penerimaanUM
            // untuk ngisi data bentuk pembayaran dan rekening
            // ambil data UM  
            DataTable _dtum = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                _dtum = db.Commands[0].ExecuteDataTable();
            }
            
            txtTotalLama.Text = txtTotal.Text           = Tools.isNull(_dt.Rows[0]["HargaOff"], "").ToString();
            txtUMTotalLama.Text = txtUMTotal.Text       = (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["UangMuka"], 0))).ToString();
            txtBiayaADMLama.Text = txtBiayaADM.Text     = Tools.isNull(_dt.Rows[0]["BiayaADM"], "").ToString();
            txtBBNLama.Text = txtBBN.Text               = Tools.isNull(_dt.Rows[0]["BBN"], "").ToString();
            txtHargaLama.Text = txtHarga.Text           = Tools.isNull(_dt.Rows[0]["HargaJadi"], "").ToString(); // sebelumnya harga jadi
            txtUMSubsidiLama.Text = txtUMSubsidi.Text   = (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["DPSubsidi"], 0))).ToString();
            txtUangMukaLama.Text = txtUangMuka.Text     = (txtUMTotal.GetDoubleValue - txtUMSubsidi.GetDoubleValue).ToString();
            txtHargaOTRLama.Text = txtHargaOTR.Text     = Convert.ToDouble(txtHarga.GetDoubleValue + txtBBN.GetDoubleValue).ToString();
            txtFauxTotalLama.Text = txtFauxTotal.Text   = Convert.ToDouble(txtHargaOTR.GetDoubleValue - txtDiscount.GetDoubleValue
                                                          /*+ txtBiayaADM.GetDoubleValue*/).ToString();
            txtUangMukaLama.Text = txtUangMuka.Text     = (txtUMTotal.GetDoubleValue - txtUMSubsidi.GetDoubleValue).ToString();
            recalcCompiledLama();

            OTROri = txtHargaOTR.GetDoubleValue;
            OTRPrev = OTROri;
            perubahan = 0;

            DisableControls(this.groupBox1);
            DisableControls(this.groupBox2);
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            txtHargaOTR.Enabled = true;
            txtHargaOTR.ReadOnly = false;

        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JurnalPembalik()
        {
            DataTable dtCekJurnal = new DataTable(); //cek udah di link jurnal belum, Heri
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Penj_CekJournal"));
                db.Commands[0].Parameters.Add(new Parameter("@rowidpenj", SqlDbType.UniqueIdentifier, _penjRowID));
                dtCekJurnal = db.Commands[0].ExecuteDataTable();
            }
            if (Convert.ToDouble(Tools.isNull(dtCekJurnal.Rows[0]["hasil"], 0)) > 0) // jika udah maka dibikin journal pembalik
             {
                 Rowidjournalbatal = Guid.NewGuid();
                 DataTable dt = new DataTable();
                 using (Database db = new Database())
                 {
                     db.Commands.Add(db.CreateCommand("usp_PenjLSG_JourBalik"));
                     db.Commands[0].Parameters.Add(new Parameter("@rowidpenj", SqlDbType.UniqueIdentifier, _penjRowID));
                     db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                     db.Commands[0].Parameters.Add(new Parameter("@rowidjournalbatal", SqlDbType.UniqueIdentifier, Rowidjournalbatal));
                     dt = db.Commands[0].ExecuteDataTable();
                 }        
                 
             }
            
        }
            
        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            //cek bulannya, kalau beda bulan jangan dibolehin batal 
            string MonthServer = GlobalVar.GetServerDate.Month.ToString();
            string YearServer = GlobalVar.GetServerDate.Year.ToString();           
            DateTime tanggalAngsBat = Convert.ToDateTime(_tgljual);
            string MonthBatal = tanggalAngsBat.Month.ToString();
            string YearBatal = tanggalAngsBat.Year.ToString();
            if (MonthBatal != MonthServer)
            {
                MessageBox.Show("Sudah beda bulan, Anda tidak diperkenankan mengedit harga OTR penjualan ini...");
                return;
            }
            else if (YearBatal != YearServer)
            {
                MessageBox.Show("Sudah ganti tahun, Anda tidak diperkenankan mengedit harga OTR penjualan ini...");
                return;
            }
            
            updateOTR();
            if(txtHargaOTR.GetDoubleValue < 1)
            {
                MessageBox.Show("Tidak bisa menginput harga ini!");
                return;
            }

            if (MessageBox.Show("Anda yakin akan mengubah harga OTR data ini ?", "Anda yakin akan mengubah harga OTR data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                JurnalPembalik();
                Database db = new Database();
                Database dbf = new Database(GlobalVar.DBFinanceOto);

                int counterdb = 0;
                int counterdbf = 0;
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Ubah Harga OTR dari : " + txtHargaOTRLama.GetDoubleValue.ToString() + " jadi : " + txtHargaOTR.GetDoubleValue.ToString()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi OTR"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanOTR", SqlDbType.Money, perubahan));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@rowidjournalbatal", SqlDbType.UniqueIdentifier, Rowidjournalbatal));
                    counterdb++;

                    db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_HargaOTR"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalOTRBaru", SqlDbType.Money, txtHargaOTR.GetDoubleValue));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[counterdb].ExecuteDataTable();
                    counterdb++;

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
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                return;
            }

        }

        private void txtHargaOTR_Leave(object sender, EventArgs e)
        {
            updateOTR();
        }

        private void txtHargaOTR_Enter(object sender, EventArgs e)
        {
            OTRPrev = txtHargaOTR.GetDoubleValue;
            perubahan = txtHargaOTR.GetDoubleValue - txtHargaOTRLama.GetDoubleValue;
        }

        private void txtHargaOTR_MouseLeave(object sender, EventArgs e)
        {
            updateOTR();
        }

        public void updateOTR()
        {
            if (txtHargaOTR.GetDoubleValue > 0)
            {
                Double tempCurrentOTR;
                tempCurrentOTR = txtHargaOTR.GetDoubleValue;
                txtSisaPokok.Text = (txtSisaPokok.GetDoubleValue + (tempCurrentOTR - OTRPrev)).ToString();
                txtFauxTotal.Text = (txtFauxTotal.GetDoubleValue + (tempCurrentOTR - OTRPrev)).ToString();
                OTRPrev = tempCurrentOTR;
                perubahan = txtHargaOTR.GetDoubleValue - txtHargaOTRLama.GetDoubleValue;
            }
            else
            {
                txtHargaOTR.Text = "0";
            }
        }

        private void txtHargaOTR_TextChanged(object sender, EventArgs e)
        {
            updateOTR();
        }

        private void frmPenjualanEditOTR_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPenjualanBrowseTLA)
            {
                Penjualan.frmPenjualanBrowseTLA frmCaller = (Penjualan.frmPenjualanBrowseTLA)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("RowID", _penjRowID.ToString());
            }
        }
        
    }
}
