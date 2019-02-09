using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Master
{
    public partial class frmRekeningUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        Class.FillComboBox fcbo = new Class.FillComboBox();

        DataTable dt;

        public frmRekeningUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmRekeningUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmRekeningUpdate_Load(object sender, EventArgs e)
        {
            fcbo.fillComboBank(cboBank);
//            fcbo.fillComboPerkiraan(cboPerkiraan);
            fcbo.fillComboPerusahaan(cboPerusahaan);
            RefreshData();
        }

        private void RefreshData()
    {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid _mataUangRowID = Guid.Empty;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rekening_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtNamaRekening.Text = Tools.isNull(dt.Rows[0]["NamaRekening"], "").ToString();
                    txtNamaRekening.Enabled = false;
                    cboBank.SelectedValue= Tools.isNull(dt.Rows[0]["BankRowID"], (Guid)Guid.Empty);
                    cboBank.Enabled = false;
                    txtNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();
                    //txtNoRekening.Enabled = false;
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["NamaRekening"], "").ToString();
                    _mataUangRowID = (Convert.IsDBNull(dt.Rows[0]["MataUangRowID"])) ? Guid.Empty : (Guid)dt.Rows[0]["MataUangRowID"];
                    //cboMataUang.Text = Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString();
                    chkIsAktif.Checked = bool.Parse(Tools.isNull(dt.Rows[0]["IsAktif"],"").ToString());
                    cboPerusahaan.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanRowID"],Guid.Empty);
                    lookUpPerkiraan1.NoPerkiraan = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                    chkCash.Checked = Convert.ToBoolean(dt.Rows[0]["CashFlow"]);
                }
                else
                {
                    chkIsAktif.Checked = true;
                    cboPerusahaan.SelectedValue = GlobalVar.PerusahaanRowID;
                }

                DataTable dt1 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_MataUang_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    dt1 = db.Commands[0].ExecuteDataTable();
                    dt1.Rows.Add(Guid.Empty);
                    cboMataUang.DataSource = dt1;
                    cboMataUang.ValueMember = "RowID";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.SelectedValue = _mataUangRowID;
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

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboBank.Text))
            {
                MessageBox.Show("Bank belum diisi");
                cboBank.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNoRekening.Text))
            {
                MessageBox.Show("No. Rekening belum diisi");
                txtNoRekening.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Rekening_INSERT"));

                                db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, txtNoRekening.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaRekening", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, cboBank.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, lookUpPerkiraan1.NoPerkiraan));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                int x = (chkCash.Checked) ? 1 :0;
                                db.Commands[0].Parameters.Add(new Parameter("@CashFlow", SqlDbType.Bit, x));
                               dt= db.Commands[0].ExecuteDataTable();
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("No.Rekening : " + txtNoRekening.Text + " Sudah terdaftar di database");
                                    txtNoRekening.Text = string.Empty;
                                    txtNoRekening.Focus();
                                    return;
                                }

                                MessageBox.Show(Messages.Confirm.SaveSuccess);
                            }

                            catch (Exception Ex) { Error.LogError(Ex); }
                            finally { this.Cursor = Cursors.Default; }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {

                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Rekening_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, txtNoRekening.Text.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaRekening", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, cboBank.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, lookUpPerkiraan1.NoPerkiraan));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                int x = (chkCash.Checked) ? 1 : 0;
                                db.Commands[0].Parameters.Add(new Parameter("@CashFlow", SqlDbType.Bit, x));
                                db.Commands[0].ExecuteNonQuery();

                                MessageBox.Show(Messages.Confirm.UpdateSuccess);

                            }
                            catch (Exception Ex) { Error.LogError(Ex); }
                            finally { this.Cursor = Cursors.Default; }
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                closeForm();
                this.Close();
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCabangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmRekeningBrowse)
                {
                    frmRekeningBrowse frmCaller = (frmRekeningBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("NoRekening", txtNoRekening.Text);
                }
            }
            //this.Close();
        }

        private void lookupDO1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNoRekening_TextChanged(object sender, EventArgs e)
        {

        }
/*
        private void fillComboBank()
        {
            try
            {
                DataTable dtBank = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Bank_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    dtBank = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "BankID + ' | ' + NamaBank");
                dtBank.Columns.Add(cConcatenated);
                dtBank.Rows.Add((Guid)Guid.NewGuid());
                dtBank.DefaultView.Sort = "BankID ASC";

                cboBank.DataSource = dtBank;
                cboBank.DisplayMember = "Concatenated";
                cboBank.ValueMember = "RowID";

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
    }
*/
    }
}
