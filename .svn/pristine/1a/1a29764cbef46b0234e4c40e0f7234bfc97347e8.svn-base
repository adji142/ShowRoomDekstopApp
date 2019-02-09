using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPenerimaanUangIdentifikasi : ISA.Controls.BaseForm
    {
        DataRow drH = null;
        DataRow drD = null;
        Guid _RowID;

        private bool NotValid()
        {
            ErrorProvider err = new ErrorProvider();
            bool invalid = false;
            if (drD == null)
            {
                err.SetError(cmdSearch, "Pilih Datanya");
                invalid = true;
            }
            else
            {
                if (Convert.ToDouble(drD["RpSisa"]) - txtRpIden.GetDoubleValue < 0)
                {
                    err.SetError(txtRpIden, "MAX : " + Convert.ToDouble(drH["RpSisa"]).ToString("#,##0"));
                    invalid = true;
                }

                if (txtSaldo.GetDoubleValue - txtRpIden.GetDoubleValue < 0)
                {
                    err.SetError(txtRpIden, "Tidak boleh lebih dari Saldo  : " + txtSaldo.GetDoubleValue.ToString("#,##0"));
                    invalid = true;
                }
            }

            return invalid;
        }

        private void Insert()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _RowID = Guid.NewGuid();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_LIST_PLL_INSERT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, drH["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, drD["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NominalRP", SqlDbType.Money, txtRpIden.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }


                if (this.Caller is frmPengeluaranPiutangLainBrowse)
                {
                    frmPengeluaranPiutangLainBrowse frmCaller = (frmPengeluaranPiutangLainBrowse)this.Caller;
                    frmCaller.RefreshRowDataGridDetailO(_RowID, (Guid)drH["RowID"]);
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        public frmPenerimaanUangIdentifikasi()
        {
            InitializeComponent();
        }

        public frmPenerimaanUangIdentifikasi(Form caller, DataRow drr)
        {
            InitializeComponent();
            this.Caller = caller;
            drH = drr;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }
            Insert();

        }

        private void frmPenerimaanUangIdentifikasi_Load(object sender, EventArgs e)
        {
            txtDari.Text = GlobalVar.PerusahaanID;
            txtKe.Text = drH["NamaPerusahaanKe"].ToString();
            txtSaldo.Text = drH["Saldo"].ToString();
            txtNominal.Text = drH["Nominal"].ToString();

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeaderO = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_PLL_IDEN"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKe", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDari", SqlDbType.UniqueIdentifier, drH["PerusahaanKeRowID"]));
                    dtHeaderO = db.Commands[0].ExecuteDataTable();
                }


                if (dtHeaderO.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Penerimaan");
                    return;
                }
                frmPenerimaanSpesial ifrmChild = new frmPenerimaanSpesial(dtHeaderO);
                ifrmChild.ShowDialog();
                if (ifrmChild.DialogResult == DialogResult.OK)
                {
                    drD = ifrmChild.GetData;
                    commonTextBox1.Text = drD["NoBukti"].ToString();
                    txtRpIden.Focus();
                    txt.Text = drD["Nominal"].ToString();
                    saldo.Text = drD["RpSisa"].ToString();
                }
                else
                {
                    drD = null;
                    commonTextBox1.Text = "";
                    txt.Text = "";
                    saldo.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
