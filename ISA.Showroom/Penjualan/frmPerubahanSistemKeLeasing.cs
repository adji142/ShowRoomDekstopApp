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
    public partial class frmPerubahanSistemKeLeasing : ISA.Controls.BaseForm
    {
        Guid _penjRowID = Guid.Empty;

        public frmPerubahanSistemKeLeasing()
        {
            InitializeComponent();
        }

        public frmPerubahanSistemKeLeasing(Form Caller, Guid PenjRowID)
        {
            InitializeComponent();
            _penjRowID = PenjRowID;
            this.Caller = Caller;
        }

        private void ListLeasing()
        {
            try
            {
                DataTable dt = FillComboBox.DBGetLeasing(Guid.Empty);

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "Nama ASC";
                    cboLeasing.DisplayMember = "Nama";
                    cboLeasing.ValueMember = "RowID";
                    DataRow dr = dt.NewRow();
                    dr["RowID"] = Guid.Empty;
                    dr["Nama"] = "";
                    dt.Rows.Add(dr);
                    cboLeasing.DataSource = dt.DefaultView;
                }
                else
                {
                    dt.Clear();
                    cboLeasing.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmPerubahanSistemKeLeasing_Load(object sender, EventArgs e)
        {
            ListLeasing();

            if (cboLeasing.Items.Count > 1)
            {
                cboLeasing.SelectedIndex = 1;
            }
            else if (cboLeasing.Items.Count > 0)
            {
                cboLeasing.SelectedIndex = 0;
            }

            DataTable _dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_To_LSG_FLT"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                _dt = db.Commands[0].ExecuteDataTable();
            }

            if (_dt.Rows.Count > 0)
            {
                txtNoTrans.Text = _dt.Rows[0]["NoTrans"].ToString();
                txtNoBukti.Text = _dt.Rows[0]["NoBukti"].ToString();
                txtNama.Text = _dt.Rows[0]["Nama"].ToString();
                txtNoRangka.Text = _dt.Rows[0]["NoRangka"].ToString();
                txtSistemBayar.Text = _dt.Rows[0]["SistemBayar"].ToString();
                txtTglJual.Text = _dt.Rows[0]["TglJual"].ToString();
                txtHargaJadi.Text = _dt.Rows[0]["HargaJadi"].ToString();
                txtBBN.Text = _dt.Rows[0]["BBN"].ToString();
                txtBiayaADM.Text = _dt.Rows[0]["BiayaADM"].ToString();

                txtDiscountPrev.Text = _dt.Rows[0]["Discount"].ToString();
                txtDiscount.Text = "0";

                txtBayarUM.Text = _dt.Rows[0]["BayarUM"].ToString();

                txtHargaOTR.Text = (txtHargaJadi.GetDoubleValue + txtBBN.GetDoubleValue).ToString();
                txtFauxTotal.Text = (txtHargaOTR.GetDoubleValue - txtDiscount.GetDoubleValue).ToString();
                
                txtUangMuka.Text = _dt.Rows[0]["BayarUM"].ToString();
                txtDPPelanggan.Text = _dt.Rows[0]["BayarUM"].ToString();
                txtDPSubsidi.Text = "0";
            }
            else
            {
                MessageBox.Show("Data invalid. Closing Window...!");
                this.Close();
            }
            
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void updatePenjualan(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_SistemBayar"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTransNew", SqlDbType.VarChar, "LSG"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cboLeasing.SelectedValue));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuranNew", SqlDbType.Int, numKredit.Value));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@BungaNew", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@UangMukaNew", SqlDbType.Money, txtUangMuka.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@DPSubsidiNew", SqlDbType.Money, txtDPSubsidi.GetDoubleValue));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@PiutangPokokNew", SqlDbType.Money, txtSisaPokok.GetDoubleValue));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngs.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        public void InsertLog(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT_UbahSistemBayar"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTransNew", SqlDbType.VarChar, "LSG"));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuranNew", SqlDbType.Int, numKredit.Value));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@BungaNew", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@UangMukaNew", SqlDbType.Money, txtUangMuka.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@DPSubsidiNew", SqlDbType.Money, txtDPSubsidi.GetDoubleValue));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@PiutangPokokNew", SqlDbType.Money, txtSisaPokok.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Logtype", SqlDbType.VarChar, "Koreksi PJL"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Perubahan Sistem Bayar dari : " + txtSistemBayar.Text + " menjadi Tunai - Leasing"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cboLeasing.SelectedValue));
            counterdb++;
        }

        public void updatePembayaran(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_PenerimaanUM_ALL"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        public bool validateSave()
        {
            bool tempResult = true;
            String tempError = String.Empty;

            if ( ((txtUangMuka.GetDoubleValue - txtDPSubsidi.GetDoubleValue) < txtBayarUM.GetDoubleValue) 
                 || (txtDPPelanggan.GetDoubleValue < txtBayarUM.GetDoubleValue) )

            {
                tempError = tempError + "Minimum DP dari pelanggan harus sesuai dengan nominal DP yg telah dibayarkan Pelanggan! \n";
                txtDPPelanggan.Text = txtBayarUM.Text;
                txtUangMuka.Text = txtBayarUM.Text;
                txtDPSubsidi.Text = (txtUangMuka.GetDoubleValue - txtDPPelanggan.GetDoubleValue).ToString();
                tempResult = false;
            }

            if (txtUangMuka.GetDoubleValue > txtFauxTotal.GetDoubleValue)
            {
                tempError = tempError + "Uang Muka tidak bisa lebih besar dari harga jadi nett! \n";
                txtUangMuka.Text = txtFauxTotal.Text;
                tempResult = false;
            }

            if (txtDPPelanggan.GetDoubleValue > txtUangMuka.GetDoubleValue)
            {
                tempError = tempError + "Uang Muka Pelanggan tidak bisa lebih besar dari uang muka total! \n";
                txtDPPelanggan.Text = txtUangMuka.Text;
                tempResult = false;
            }

            if (string.IsNullOrEmpty(cboLeasing.Text))
            {
                tempError = tempError + "Pilih Leasing terlebih dahulu! \n";
                cboLeasing.Focus();
                tempResult = false;
            }

            if (tempError != String.Empty || tempResult != true)
            {
                MessageBox.Show(tempError);
                tempResult = false;
            }

            return tempResult;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (validateSave())
            {

                Database db = new Database();
                Database dbf = new Database(GlobalVar.DBFinanceOto);

                int counterdb = 0;
                int counterdbf = 0;

                try
                {
                    InsertLog(ref db, ref counterdb);
                    //updatePembayaran(ref db, ref counterdb);
                    updatePenjualan(ref db, ref counterdb);

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
                    MessageBox.Show("Data berhasil diupdate!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    dbf.RollbackTransaction();
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        public void urusDPPelanggan()
        {
            Double tempUangMuka = txtUangMuka.GetDoubleValue;
            Double tempDPSubsidi = txtDPSubsidi.GetDoubleValue;
            Double tempDPTerbayar = txtBayarUM.GetDoubleValue;
            Double tempDPPelanggan = txtDPPelanggan.GetDoubleValue;
            if ((tempUangMuka - tempDPSubsidi < tempDPTerbayar) || (tempDPPelanggan < tempDPTerbayar))
            {
                MessageBox.Show("Minimum DP dari pelanggan harus sesuai dengan nominal DP yg telah dibayarkan Pelanggan!");
                txtDPPelanggan.Text = txtBayarUM.Text;
                txtUangMuka.Text = txtBayarUM.Text;
                txtDPSubsidi.Text = (txtUangMuka.GetDoubleValue - txtDPPelanggan.GetDoubleValue).ToString();
            }
            else
            {
                txtDPSubsidi.Text = (txtUangMuka.GetDoubleValue - txtDPPelanggan.GetDoubleValue).ToString();
                txtDPPelanggan.Text = (txtUangMuka.GetDoubleValue - txtDPSubsidi.GetDoubleValue).ToString();

                if ((tempUangMuka - tempDPSubsidi < tempDPTerbayar) || (tempDPPelanggan < tempDPTerbayar))
                {
                    MessageBox.Show("Minimum DP dari pelanggan harus sesuai dengan nominal DP yg telah dibayarkan Pelanggan!");
                    txtDPPelanggan.Text = txtBayarUM.Text;
                    txtUangMuka.Text = txtBayarUM.Text;
                    txtDPSubsidi.Text = (txtUangMuka.GetDoubleValue - txtDPPelanggan.GetDoubleValue).ToString();
                }
            }
        }

        private void txtUangMuka_Leave(object sender, EventArgs e)
        {
            if(txtUangMuka.GetDoubleValue > txtFauxTotal.GetDoubleValue)
            {
                MessageBox.Show("Uang Muka tidak bisa lebih besar dari harga jadi nett!");
                txtUangMuka.Text = txtFauxTotal.Text;
            }
            urusDPPelanggan();
        }

        private void txtDPPelanggan_Leave(object sender, EventArgs e)
        {
            if ( txtDPPelanggan.GetDoubleValue > txtUangMuka.GetDoubleValue )
            {
                MessageBox.Show("Uang Muka Pelanggan tidak bisa lebih besar dari uang muka total!");
                txtDPPelanggan.Text = txtUangMuka.Text;
            }
            urusDPPelanggan();
        }

        private void frmPerubahanSistemKeLeasing_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPerubahanSistemBayarBrowse)
            {
                Penjualan.frmPerubahanSistemBayarBrowse frm = (Penjualan.frmPerubahanSistemBayarBrowse)this.Caller;
                frm.RefreshGrid();
            }
        }

        private void cboLeasing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
