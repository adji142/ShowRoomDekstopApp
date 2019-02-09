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
    public partial class frmJnsTransaksiUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _jnsArusUang = "";
        Guid _rowID;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        DataTable dt;

        public frmJnsTransaksiUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmJnsTransaksiUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJnsTransaksiUpdate_Load(object sender, EventArgs e)
        {
            fcbo.fillComboUser(cboUserAcc1);
            fcbo.fillComboUser(cboUserAcc2);
            RefreshData();
        }
        
        private void RefreshData() {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtJnsTransaksi.Text = Tools.isNull(dt.Rows[0]["JnsTransaksi"], "").ToString();
                    txtJnsTransaksi.Enabled = false;
                    txtNamaTransaksi.Text = Tools.isNull(dt.Rows[0]["namaTransaksi"], "").ToString();
                    _jnsArusUang = Tools.isNull(dt.Rows[0]["JnsArusUang"], "").ToString();
                    chkIsAktif.Checked = ((bool)dt.Rows[0]["IsAktif"]==true)?true:false;
                    chkAcc.Checked = ((bool)dt.Rows[0]["IsNeedApproval"] == true) ? true : false;
                    lookUpPerkiraan1.NoPerkiraan = Tools.isNull(dt.Rows[0]["NoPerkiraan01"], "").ToString();
                    lookUpPerkiraan2.NoPerkiraan = Tools.isNull(dt.Rows[0]["NoPerkiraan02"], "").ToString();

                    using (Database db = new Database()) 
                    { 
                        db.Commands.Add(db.CreateCommand("usp_AccPengeluaranHirarki_LIST_FILTER_Urutan"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID",SqlDbType.UniqueIdentifier,_rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows) 
                            {
                                string _urutan, _userID ;
                                _urutan = Tools.isNull(row["UrutanAcc"], "").ToString() ;
                                _userID = Tools.isNull(row["UserID"],"").ToString();
                                switch (_urutan)
                                {
                                    case "1": cboUserAcc1.SelectedValue = _userID; break;
                                    case "2": cboUserAcc2.SelectedValue = _userID; break;
                                }
                            }
                        }
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
            set_optArusUang();
            toggleAcc();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJnsTransaksi.Text))
            {
                MessageBox.Show("Kode belum diisi");
                txtJnsTransaksi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNamaTransaksi.Text))
            {
                MessageBox.Show("Nama Transaksi belum diisi");
                txtNamaTransaksi.Focus();
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
                            DataTable dt = new DataTable();
                            _rowID = Guid.NewGuid();
                            db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtJnsTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, txtNamaTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsArusUang", SqlDbType.VarChar, _jnsArusUang));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan01", SqlDbType.VarChar, lookUpPerkiraan1.NoPerkiraan));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan02", SqlDbType.VarChar, lookUpPerkiraan2.NoPerkiraan));
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@IsNeedApproval", SqlDbType.Bit, chkAcc.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kode Transaksi: " + txtJnsTransaksi.Text + " Sudah terdaftar di database");
                                txtJnsTransaksi.Text = string.Empty;
                                txtJnsTransaksi.Focus();
                                return;
                            }
                            else
                            {
                                if (chkAcc.Checked)
                                {
                                    if (cboUserAcc1.Text != "") SaveAcc(db, cboUserAcc1.SelectedValue.ToString(), 1);
                                    if (cboUserAcc2.Text != "") SaveAcc(db, cboUserAcc2.SelectedValue.ToString(), 2);
                                }
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtJnsTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, txtNamaTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsArusUang", SqlDbType.VarChar, _jnsArusUang));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan01", SqlDbType.VarChar, lookUpPerkiraan1.NoPerkiraan));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan02", SqlDbType.VarChar, lookUpPerkiraan2.NoPerkiraan));
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@IsNeedApproval", SqlDbType.Bit, chkAcc.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            if (chkAcc.Checked)
                            {
                                if (cboUserAcc1.Text != "") SaveAcc(db, cboUserAcc1.SelectedValue.ToString(), 1);
                                if (cboUserAcc2.Text != "") SaveAcc(db, cboUserAcc2.SelectedValue.ToString(), 2);
                            }
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

        private void SaveAcc(Database _db,string userAcc, int urutanAcc)
        {
            _db.Commands.Clear();
            _db.Commands.Add(_db.CreateCommand("usp_AccPengeluaranHirarki_INSERT"));
            _db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier,  _rowID));
            _db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, userAcc));
            _db.Commands[0].Parameters.Add(new Parameter("@UrutanAcc", SqlDbType.TinyInt, urutanAcc));
            _db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            _db.Commands[0].ExecuteNonQuery();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmJnsTransaksiBrowse) 
                {
                    frmJnsTransaksiBrowse frmCaller = (frmJnsTransaksiBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("JnsTransaksi", txtJnsTransaksi.Text);
                }
            }
            //this.Close();
        }

        private void rdoPenerimaan_CheckedChanged(object sender, EventArgs e)
        {
            _jnsArusUang = "I";
            chkAcc.Checked = false;
            toggleAcc();
        }

        private void rdoPengeluaran_CheckedChanged(object sender, EventArgs e)
        {
            _jnsArusUang = "O";
            toggleAcc();
        }

        private void set_optArusUang()
        {
            rdoPenerimaan.Checked = (_jnsArusUang == "I") ? true : false;
            rdoPengeluaran.Checked = (_jnsArusUang == "O") ? true : false;
        }

        private void chkAcc_CheckedChanged(object sender, EventArgs e)
        {
            cboUserAcc1.Enabled = ((chkAcc.Checked) && (_jnsArusUang=="O"));
            cboUserAcc2.Enabled = ((chkAcc.Checked) && (_jnsArusUang == "O"));
        }

        private void lookUpPerkiraan1_Load(object sender, EventArgs e)
        {

        }

        private void toggleAcc()
        {
            bool _visible = (Tools.isNull(_jnsArusUang,"").ToString()=="O");
            if (_jnsArusUang != "O") chkAcc.Checked = false;
            lblCekAcc.Visible = _visible;
            chkAcc.Visible = _visible;
            lblAcc1.Visible = _visible;
            cboUserAcc1.Visible = _visible;
            lblAcc2.Visible = _visible;
            cboUserAcc2.Visible = _visible;
        }
    }
}
