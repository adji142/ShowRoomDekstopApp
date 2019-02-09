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
    public partial class frmPenjualanGantiStok : ISA.Controls.BaseForm
    {
        Guid _penjRowID;
        public frmPenjualanGantiStok(Form Caller, Guid PenjRowID)
        {
            InitializeComponent();
            this.Caller = Caller;
            _penjRowID = PenjRowID;
        }

        private void frmPenjualanGantiStok_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_GantiStok"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        lblTipeMerekOld.Text = Tools.isNull(dt.Rows[0]["Type"], "").ToString() + "/" + Tools.isNull(dt.Rows[0]["Merk"], "").ToString();
                        txtHargaJadiOld.Text = Tools.isNull(dt.Rows[0]["HargaJadi"], "0").ToString();
                        lblNopolOld.Text = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();
                        lblNoRangkaOld.Text = Tools.isNull(dt.Rows[0]["NoRangka"], "").ToString();
                        lblNoMesinOld.Text = Tools.isNull(dt.Rows[0]["NoMesin"], "").ToString();
                        lblNoBPKBOld.Text = Tools.isNull(dt.Rows[0]["NoBPKB"], "").ToString();
                        lblNamaBPKBOld.Text = Tools.isNull(dt.Rows[0]["NamaBPKB"], "").ToString();
                        lblAlamatBPKBOld.Text = Tools.isNull(dt.Rows[0]["AlamatBPKB"], "").ToString();
                        lblKotaBPKBOld.Text = Tools.isNull(dt.Rows[0]["KotaBPKB"], "").ToString();
                        lblKeteranganOld.Text = Tools.isNull(dt.Rows[0]["KeteranganBPKB"], "").ToString();

                        lblTipeMerekNew.Text = "";
                        txtHargaJadiNew.Text = "";
                        lblNopolNew.Text = "";
                        lblNoRangkaNew.Text = "";
                        lblNoMesinNew.Text = "";
                        lblNoBPKBNew.Text = "";
                        lblNamaBPKBNew.Text = "";
                        lblAlamatBPKBNew.Text = "";
                        lblKotaBPKBNew.Text = "";
                        lblKeteranganNew.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan!");
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

        private void lookUpStokMotorTLA1_Leave(object sender, EventArgs e)
        {
            if (lookUpStokMotorTLA1._motor.RowID != null && lookUpStokMotorTLA1._motor.RowID != Guid.Empty)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_GantiStok"));
                        db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotorTLA1._motor.RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            lblTipeMerekNew.Text = Tools.isNull(dt.Rows[0]["Type"], "").ToString() + "/" + Tools.isNull(dt.Rows[0]["Merk"], "").ToString();
                            txtHargaJadiNew.Text = Tools.isNull(dt.Rows[0]["HargaJadi"], "0").ToString();
                            lblNopolNew.Text = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();
                            lblNoRangkaNew.Text = Tools.isNull(dt.Rows[0]["NoRangka"], "").ToString();
                            lblNoMesinNew.Text = Tools.isNull(dt.Rows[0]["NoMesin"], "").ToString();
                            lblNoBPKBNew.Text = Tools.isNull(dt.Rows[0]["NoBPKB"], "").ToString();
                            lblNamaBPKBNew.Text = Tools.isNull(dt.Rows[0]["NamaBPKB"], "").ToString();
                            lblAlamatBPKBNew.Text = Tools.isNull(dt.Rows[0]["AlamatBPKB"], "").ToString();
                            lblKotaBPKBNew.Text = Tools.isNull(dt.Rows[0]["KotaBPKB"], "").ToString();
                            lblKeteranganNew.Text = Tools.isNull(dt.Rows[0]["KeteranganBPKB"], "").ToString();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan!");
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
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookUpStokMotorTLA1._motor.RowID != null && lookUpStokMotorTLA1._motor.RowID != Guid.Empty)
            {
            }
            else
            {
                MessageBox.Show("Pilih motor pengganti terlebih dahulu!");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskSave, "Anda yakin akan mengganti Stok Motor penjualan ini ?",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }


            Database db = new Database();
            int counterdb = 0;

            try
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Ganti Stok motor dari NoRangka : " + lblNoRangkaOld.Text.Trim() + " jadi : " + lblNoRangkaNew.Text.Trim()));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowIDNew", SqlDbType.UniqueIdentifier, lookUpStokMotorTLA1._motor.RowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LogType", SqlDbType.VarChar, "Koreksi Stok"));
                counterdb++;

                db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_GantiStok"));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotorTLA1._motor.RowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                counterdb++;

                db.BeginTransaction();
                int looper = 0;
                for (looper = 0; looper < counterdb; looper++)
                {
                    db.Commands[looper].ExecuteNonQuery();
                }
                db.CommitTransaction();
                MessageBox.Show("Stok motor berhasil diubah!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error : " + ex.Message);
                db.RollbackTransaction();
            }
        }

        private void lookUpStokMotorTLA1_MouseLeave(object sender, EventArgs e)
        {
            if (lookUpStokMotorTLA1._motor.RowID != null && lookUpStokMotorTLA1._motor.RowID != Guid.Empty)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_GantiStok"));
                        db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotorTLA1._motor.RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            lblTipeMerekNew.Text = Tools.isNull(dt.Rows[0]["Type"], "").ToString() + "/" + Tools.isNull(dt.Rows[0]["Merk"], "").ToString();
                            txtHargaJadiNew.Text = Tools.isNull(dt.Rows[0]["HargaJadi"], "0").ToString();
                            lblNopolNew.Text = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();
                            lblNoRangkaNew.Text = Tools.isNull(dt.Rows[0]["NoRangka"], "").ToString();
                            lblNoMesinNew.Text = Tools.isNull(dt.Rows[0]["NoMesin"], "").ToString();
                            lblNoBPKBNew.Text = Tools.isNull(dt.Rows[0]["NoBPKB"], "").ToString();
                            lblNamaBPKBNew.Text = Tools.isNull(dt.Rows[0]["NamaBPKB"], "").ToString();
                            lblAlamatBPKBNew.Text = Tools.isNull(dt.Rows[0]["AlamatBPKB"], "").ToString();
                            lblKotaBPKBNew.Text = Tools.isNull(dt.Rows[0]["KotaBPKB"], "").ToString();
                            lblKeteranganNew.Text = Tools.isNull(dt.Rows[0]["KeteranganBPKB"], "").ToString();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan!");
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
        }

        private void frmPenjualanGantiStok_FormClosed(object sender, FormClosedEventArgs e)
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
