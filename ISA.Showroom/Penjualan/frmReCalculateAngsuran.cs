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
using System.Transactions;


namespace ISA.Showroom.Penjualan
{
    public partial class frmReCalculateAngsuran : ISA.Controls.BaseForm
    {
        Guid _penjRowID, _penjHistRowID, Rowidjournalbatal;
        Decimal _realBunga = 0;
        Decimal _sisapokok;
        Decimal _angsPBL;
        int suksesbalik;

        public frmReCalculateAngsuran(Form caller, Guid PenjRowID, Guid PenjHistRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _penjRowID = PenjRowID;
            _penjHistRowID = PenjHistRowID;
        }

        private void frmReCalculateAngsuran_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    lblTempo.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0)).ToString();
                    lblSisaPokok.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokokMurni"], 0)).ToString("N2");
                    lblAngsBulananOld.Text = lblAngsBulananNew.Text = txtTargetAngsBulanan.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0)).ToString();
                    decimal tempSisaPokok = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["SisaPokokMurni"], 0));
                    decimal tempPokok = tempSisaPokok / Convert.ToDecimal(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0));
                    decimal nominalbungatarget = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0)) - tempPokok;
                    _sisapokok = tempSisaPokok;
                    lblNominalPokokNew.Text = lblNominalPokokOld.Text = tempPokok.ToString("N2");
                    _realBunga = (nominalbungatarget / tempSisaPokok) * 100;
                    lblPBngOld.Text = lblPBngNew.Text = _realBunga.ToString("N2");
                    _angsPBL = Convert.ToDecimal(Tools.isNull(dt.Rows[0]["AngsuranPBL"], 0));
                    Decimal tempBunga = tempSisaPokok * (_realBunga / 100);
                    lblNominalBungaNew.Text = lblNominalBungaOld.Text = tempBunga.ToString("N2");
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

        private void penjualanHistUPDATETambahUMBARU(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_Hist_UPDATE_TambahUM"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TambahanUM", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "BARU"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RPBunga", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            
            counterdb++;
        }

        private void penjualanLogInsert(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PerubahanBNG", SqlDbType.Decimal, _realBunga));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi BNG"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Perubahan Bunga Cicilan menjadi : " + _realBunga.ToString("N10")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@rowidjournalbatal", SqlDbType.UniqueIdentifier, Rowidjournalbatal));

            counterdb++;
        }
        private void jurnalbalik(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenjLSG_JourBalik"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@rowidpenj", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@rowidjournalbatal", SqlDbType.UniqueIdentifier, Rowidjournalbatal));
            counterdb++;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (_realBunga < 0)
            {
                MessageBox.Show("Data tidak dapat diproses, silahkan input target angsuran baru!");
                txtTargetAngsBulanan.Focus();
                return;
            }
            if ((txtTargetAngsBulanan.GetDoubleValue > Convert.ToDouble(_sisapokok)) || (_realBunga > 99))
            {
                MessageBox.Show("Data tidak dapat diproses, silahkan input target angsuran baru!");
                txtTargetAngsBulanan.Focus();
                return;
            }
            
            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);
            int counterdb = 0, counterdbf = 0;            
            try
            {
                //DataTable dtCekJurnal = new DataTable(); //cek udah di link jurnal belum, Heri
                //using (Database dbC = new Database())
                //{
                //    dbC.Commands.Add(dbC.CreateCommand("usp_Penj_CekJournal"));
                //    dbC.Commands[0].Parameters.Add(new Parameter("@rowidpenj", SqlDbType.UniqueIdentifier, _penjRowID));
                //    dtCekJurnal = dbC.Commands[0].ExecuteDataTable();
                //}
                //if (Convert.ToDouble(Tools.isNull(dtCekJurnal.Rows[0]["hasil"], 0)) > 0) // jika udah maka dibikin journal pembalik
                //{
                //    Rowidjournalbatal = Guid.NewGuid();
                //    jurnalbalik(ref db, ref counterdb);
                //}
                    penjualanLogInsert(ref db, ref counterdb);
                    penjualanHistUPDATETambahUMBARU(ref db, ref counterdb);
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
                    MessageBox.Show("Data berhasil ditambahkan");
                    this.Close();             
            }
            catch (Exception ex)
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


        private void txtTargetAngsBulanan_Leave(object sender, EventArgs e)
        {
            recalculateBunga();
        }

        private void recalculateBunga()
        {
            // cek dulu, jumlah angsuran per bulan yg baru ngga boleh lebih kecil dari angsuran pokok per bulannya
            if (txtTargetAngsBulanan.GetDoubleValue > 0) // kalau kredit
            {
                int tempTempo = Convert.ToInt16(lblTempo.Text);
                decimal jmlangsurantarget = Convert.ToDecimal(Tools.isNull(txtTargetAngsBulanan.Text, "0"));

                if (tempTempo == 0)
                {
                    txtTargetAngsBulanan.Text = "0";
                    lblNominalBungaNew.Text = "0";
                    lblNominalPokokNew.Text = "0";
                    lblPBngNew.Text = "0";
                    cmdSave.Enabled = false;
                }
                else
                {
                    Decimal tempSisaPokok = _sisapokok;
                    Decimal tempPokok = tempSisaPokok / tempTempo;
                    if (tempPokok != 0 && tempSisaPokok != 0)
                    {
                        if (Convert.ToDecimal(Tools.isNull(txtTargetAngsBulanan.Text, Decimal.MinValue).ToString()) < tempPokok)
                        {
                            MessageBox.Show("Angsuran yg diinginkan tidak boleh lebih kecil dari angsuran pokok");
                            txtTargetAngsBulanan.Focus();
                            return;
                        }
                        else
                        {
                            decimal nominalbungatarget = jmlangsurantarget - tempPokok;
                            _realBunga = (nominalbungatarget / tempSisaPokok) * 100;
                            lblPBngNew.Text = _realBunga.ToString("N2");
                            lblNominalBungaNew.Text = nominalbungatarget.ToString("N2");
                            lblAngsBulananNew.Text = jmlangsurantarget.ToString("N2");
                            // hitung angsuran dan bunga jika kondisinya bukan ikut target
                            tempSisaPokok = _sisapokok;
                        }
                    }
                }
            }
            else
            {
                txtTargetAngsBulanan.Text = "0";
                lblNominalBungaNew.Text = "0";
                lblNominalPokokNew.Text = "0";
                lblPBngNew.Text = "0";
                cmdSave.Enabled = false;
            }
        }

        

        private void txtTargetAngsBulanan_TextChanged(object sender, EventArgs e)
        {
            recalculateBunga();
        }
    }
}
