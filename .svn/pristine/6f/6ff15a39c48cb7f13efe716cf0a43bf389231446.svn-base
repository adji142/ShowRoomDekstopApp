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
    public partial class frmPerubahanSistemKeKredit : ISA.Controls.BaseForm
    {
        Guid _penjRowID = Guid.Empty;
        Decimal _realBunga = 2.00M;
        String _FlagSource;
        int _MaxTempo;

        public frmPerubahanSistemKeKredit()
        {
            InitializeComponent();
        }

        public frmPerubahanSistemKeKredit(Form Caller, Guid PenjRowID)
        {
            InitializeComponent();
            _penjRowID = PenjRowID;
            this.Caller = Caller;
        }

        private void frmPerubahanSistemKeKredit_Load(object sender, EventArgs e)
        {

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
                txtTglJual.DateValue = Convert.ToDateTime(Tools.isNull(_dt.Rows[0]["TglJual"], DateTime.MaxValue).ToString());
                txtTglAwalAngs.DateValue = txtTglJual.DateValue;
                txtHargaJadi.Text = _dt.Rows[0]["HargaJadi"].ToString();
                txtBBN.Text = _dt.Rows[0]["BBN"].ToString();
                txtBiayaADM.Text = _dt.Rows[0]["BiayaADM"].ToString();
                txtBiayaADMBaru.Text = _dt.Rows[0]["BiayaADM"].ToString();
                txtDiscountPrev.Text = _dt.Rows[0]["Discount"].ToString();
                txtDiscount.Text = "0";
                txtBayarUM.Text = _dt.Rows[0]["BayarUM"].ToString();

                txtHargaOTR.Text = (txtHargaJadi.GetDoubleValue + txtBBN.GetDoubleValue).ToString();
                txtHargaOff.Text = _dt.Rows[0]["HargaOff"].ToString();
                txtFauxTotal.Text = (txtHargaOTR.GetDoubleValue - txtDiscount.GetDoubleValue).ToString();
                txtUangMuka.Text = _dt.Rows[0]["UangMuka"].ToString();
                txtDPSubsidi.Text = _dt.Rows[0]["DPSubsidi"].ToString();

                txtDPPelanggan.Text = (txtUangMuka.GetDoubleValue - txtDPSubsidi.GetDoubleValue).ToString();

                _FlagSource = Tools.isNull(_dt.Rows[0]["FlagSource"], "ORI").ToString();

                if (_FlagSource == "ORI")
                {
                    _MaxTempo = 36;
                }
                else if (_FlagSource == "BARU")
                {
                    _MaxTempo = 30;
                }
                else
                {
                    _MaxTempo = 36;
                }

                txtUMBaru.Text = txtBayarUM.Text;
                txtSisaPokok.Text = (txtFauxTotal.GetDoubleValue - txtUMBaru.GetDoubleValue - txtBiayaADM.GetDoubleValue).ToString();
                txtBunga.Text = "3";
                numKredit.Value = 12;
            }
            else
            {
                MessageBox.Show("Data invalid. Closing Window...!");
                this.Close();
            }
        }


        private void urusJmlAngs()
        {
            // pasti jadi FLT
            int tempTempo = Convert.ToInt32(Tools.isNull(numKredit.Value, 1));
            Decimal tempPersenBunga = _realBunga /*Convert.ToDouble(Tools.isNull(txtBunga.Text, "0"))*/;
            if (tempTempo == 0 || tempPersenBunga == 0)
            {
                txtJmlAngsuran.Text = "0";
                txtBungaBulanan.Text = "0";
            }
            else
            {
                Decimal tempSisaPokok = Convert.ToDecimal(Tools.isNull(txtSisaPokok.Text, "0"));
                Decimal tempBunga = tempSisaPokok * (tempPersenBunga / 100);
                Decimal tempPokok = tempSisaPokok / tempTempo;
                Decimal tempAngs = tempBunga + tempPokok;
                txtBungaBulanan.Text = tempBunga.ToString();
                txtJmlAngsuran.Text = tempAngs.ToString();
            }
        }

        private void recalculateBunga()
        {
            // pasti FLT
            int tempTempo = Convert.ToInt32(Tools.isNull(numKredit.Value, 1));
            decimal jmlangsurantarget = Convert.ToDecimal(Tools.isNull(txtJmlAngsuran.Text, "0"));
            if (tempTempo == 0)
            {
                txtJmlAngsuran.Text = "0";
                txtBungaBulanan.Text = "0";
                txtBunga.Text = "2";
                _realBunga = 2.00M;
            }
            else
            {
                decimal tempSisaPokok = Convert.ToDecimal(Tools.isNull(txtSisaPokok.Text, "0"));
                decimal tempPokok = tempSisaPokok / tempTempo;
                if (tempPokok != 0 && tempSisaPokok != 0)
                {
                    if (Convert.ToDecimal(Tools.isNull(txtJmlAngsuran.Text, Decimal.MinValue).ToString()) < tempPokok)
                    {

                        TextBox target = (TextBox)txtJmlAngsuran;
                        ToolTip message = new ToolTip();
                        message.Show("Isian Jumlah Angsuran tidak boleh lebih kecil dari " + tempPokok.ToString("N2") + "!", target, 0, 22, 2500);
                        txtJmlAngsuran.Focus();
                        return;
                    }
                    else
                    {
                        decimal nominalbungatarget = jmlangsurantarget - tempPokok;
                        _realBunga = (nominalbungatarget / tempSisaPokok) * 100;
                        txtBunga.Text = _realBunga.ToString("N2");
                    }
                }
            }
        }

        private void urusJmlAngs_verBunga()
        {
            // pasti FLT
            int tempTempo = Convert.ToInt32(Tools.isNull(numKredit.Value, 1));
            double tempPersenBunga = Convert.ToDouble(Tools.isNull(txtBunga.Text, "0"));
            if (tempTempo == 0 || tempPersenBunga == 0)
            {
                txtJmlAngsuran.Text = "0";
                txtBungaBulanan.Text = "0";
            }
            else
            {
                double tempSisaPokok = Convert.ToDouble(Tools.isNull(txtSisaPokok.Text, "0"));
                double tempBunga = tempSisaPokok * (tempPersenBunga / 100);
                double tempPokok = tempSisaPokok / tempTempo;
                double tempAngs = tempBunga + tempPokok;
                txtBungaBulanan.Text = tempBunga.ToString();
                txtJmlAngsuran.Text = tempAngs.ToString();
            }
        }

        private void urusSisaPokok()
        {
            txtSisaPokok.Text = (txtFauxTotal.GetDoubleValue - (txtUMBaru.GetDoubleValue + txtBiayaADM.GetDoubleValue)).ToString();
        }

        public bool validateSave()
        {
            bool tempResult = true;
            String tempError = String.Empty;

            if (numKredit.Value > _MaxTempo)
            {
                tempError = tempError + "Maksimal tempo Cicilan adalah " + _MaxTempo.ToString() + " bulan! \n";
                numKredit.Value = _MaxTempo;
                tempResult = false;
            }

            if (numKredit.Value < 1)
            {
                tempError = tempError + "Tempo Cicilan tidak bisa kurang dari 1 bulan! \n";
                numKredit.Value = 1;
                tempResult = false;
            }

            if (txtUMBaru.GetDoubleValue < txtBayarUM.GetDoubleValue)
            {
                tempError = tempError + "Nominal Uang Muka tidak bisa lebih kecil dari Nominal yg sudah terbayarkan! \n";
                txtUMBaru.Text = txtBayarUM.Text;
                tempResult = false;
            }
            
            if (txtTglAwalAngs.DateValue > txtTglJual.DateValue.Value.AddMonths(1))
            {
                tempError = tempError + "Tanggal Awal angsuran tidak bisa lebih dari 1 bulan dari Tanggal Penjualan! \n";
                txtTglAwalAngs.DateValue = txtTglJual.DateValue.Value.AddMonths(1);
                tempResult = false;
            }
            
            if (txtTglAwalAngs.DateValue < txtTglJual.DateValue)
            {
                tempError = tempError + "Tanggal Awal angsuran tidak bisa lebih dulu dari Tanggal Penjualan! \n";
                txtTglAwalAngs.DateValue = txtTglJual.DateValue;
                tempResult = false;
            }

            if (txtUMBaru.GetDoubleValue > (txtHargaOTR.GetDoubleValue - (txtDiscount.GetDoubleValue + txtBiayaADM.GetDoubleValue)) )
            {
                tempError = tempError + "Nominal Uang Muka tidak bisa lebih besar dari Harga Jual Nett! \n";
                txtUMBaru.Text = (txtHargaOTR.GetDoubleValue - (txtDiscount.GetDoubleValue + txtBiayaADM.GetDoubleValue)).ToString();
                tempResult = false;
            }

            if (lookUpSurveyor1._Surveyor.RowID == null || lookUpSurveyor1._Surveyor.RowID == Guid.Empty)
            {
                tempError = tempError + "Pilih Surveyor terlebih dahulu! \n";
                lookUpSurveyor1.Focus();
                tempResult = false;
            }

            if (tempError != String.Empty || tempResult != true)
            {
                MessageBox.Show(tempError);
                tempResult = false;
            }

            return tempResult;
        }


        public void updatePenjualan(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_SistemBayar"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTransNew", SqlDbType.VarChar, "FLT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuranNew", SqlDbType.Int, numKredit.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BungaNew", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@UangMukaNew", SqlDbType.Money, txtUMBaru.GetDoubleValue));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@DPSubsidiNew", SqlDbType.Money, txtDPSubsidi.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@ADMNew", SqlDbType.Money, txtBiayaADMBaru.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PiutangPokokNew", SqlDbType.Money, txtSisaPokok.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngs.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SurveyorRowID", SqlDbType.UniqueIdentifier, lookUpSurveyor1._Surveyor.RowID));
            counterdb++;
        }

        public void InsertLog(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT_UbahSistemBayar"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTransNew", SqlDbType.VarChar, "FLT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuranNew", SqlDbType.Int, numKredit.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BungaNew", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@UangMukaNew", SqlDbType.Money, txtUMBaru.GetDoubleValue));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@DPSubsidiNew", SqlDbType.Money, txtDPSubsidi.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@ADMNew", SqlDbType.Money, txtBiayaADMBaru.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PiutangPokokNew", SqlDbType.Money, txtSisaPokok.GetDoubleValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Logtype", SqlDbType.VarChar, "Koreksi PJL"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Perubahan Sistem Bayar dari : " + txtSistemBayar.Text + " menjadi Kredit - FLAT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        public void updatePembayaran(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_PenerimaanUM_ALL"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numKredit_Leave(object sender, EventArgs e)
        {
            if (numKredit.Value > _MaxTempo)
            {
                MessageBox.Show("Maksimal tempo Cicilan adalah " + _MaxTempo + " bulan!");
                numKredit.Value = _MaxTempo;
            }
            if (numKredit.Value < 1)
            {
                MessageBox.Show("Tempo Cicilan tidak bisa kurang dari 1 bulan!");
                numKredit.Value = 1;
            }

            urusSisaPokok();
            recalculateBunga();
            urusJmlAngs();
        }

        private void txtBunga_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 100)
            {
                MessageBox.Show("Bunga tidak boleh melebihi 100%!");
                txtBunga.Text = "100.00";
                txtBunga.Focus();
            }
            if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) < 0)
            {
                MessageBox.Show("Bunga tidak boleh kurang dari 0%!");
                txtBunga.Text = "0.00";
                txtBunga.Focus();
            }
            _realBunga = Convert.ToDecimal(txtBunga.GetDoubleValue);
            urusSisaPokok();
            urusJmlAngs_verBunga();
        }

        private void txtUMBaru_Leave(object sender, EventArgs e)
        {
            if (txtUMBaru.GetDoubleValue < txtBayarUM.GetDoubleValue)
            {
                MessageBox.Show("Nominal Uang Muka tidak bisa lebih kecil dari Nominal yg sudah terbayarkan!");
                txtUMBaru.Text = txtBayarUM.Text;
            }

            if (txtUMBaru.GetDoubleValue > (txtHargaOTR.GetDoubleValue - (txtDiscount.GetDoubleValue + txtBiayaADM.GetDoubleValue)) )
            {
                MessageBox.Show("Nominal Uang Muka tidak bisa lebih besar dari Harga Jual Nett!");
                txtUMBaru.Text = (txtHargaOTR.GetDoubleValue - (txtDiscount.GetDoubleValue + txtBiayaADM.GetDoubleValue)).ToString();
            }

            urusSisaPokok();
            recalculateBunga();
            urusJmlAngs();
        }

        private void txtJmlAngsuran_Leave(object sender, EventArgs e)
        {
            if (txtJmlAngsuran.GetDoubleValue > txtSisaPokok.GetDoubleValue)
            {
                MessageBox.Show("Jumlah Angsuran tidak bisa melebihi Sisa Pokok Angsuran!");
                txtJmlAngsuran.Text = txtSisaPokok.Text;
            }

            urusSisaPokok();
            recalculateBunga();
            urusJmlAngs();
        }

        private void txtTglAwalAngs_Leave(object sender, EventArgs e)
        {
            if (txtTglAwalAngs.DateValue > txtTglJual.DateValue.Value.AddMonths(1))
            {
                MessageBox.Show("Tanggal Awal angsuran tidak bisa lebih dari 1 bulan dari Tanggal Penjualan!");
                txtTglAwalAngs.DateValue = txtTglJual.DateValue.Value.AddMonths(1);
            }
            if (txtTglAwalAngs.DateValue < txtTglJual.DateValue)
            {
                MessageBox.Show("Tanggal Awal angsuran tidak bisa lebih dulu dari Tanggal Penjualan!");
                txtTglAwalAngs.DateValue = txtTglJual.DateValue;
            }
        }

        private void frmPerubahanSistemKeKredit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPerubahanSistemBayarBrowse)
            {
                Penjualan.frmPerubahanSistemBayarBrowse frm = (Penjualan.frmPerubahanSistemBayarBrowse)this.Caller;
                frm.RefreshGrid();
            }
        }
    }
}
