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
    public partial class frmKelompokTransaksiHIUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _jnsArusUang;
        Guid _rowID;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        DataTable dt;

        public frmKelompokTransaksiHIUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKelompokTransaksiHIUpdate(Form caller, Guid rowID)
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
            fcbo.fillComboPerkiraan(cboPerkiraan1);
            fcbo.fillComboPerkiraan(cboPerkiraan2);
//            fcbo.fillComboUser(cboUserAcc1);
//            fcbo.fillComboUser(cboUserAcc2);
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
                    chkIsUploadable.Checked = ((bool)dt.Rows[0]["IsUploadable"] == true) ? true : false;
                    cboPerkiraan1.SelectedValue = Tools.isNull(dt.Rows[0]["NoPerkiraan01"], "").ToString();
                    cboPerkiraan2.SelectedValue = Tools.isNull(dt.Rows[0]["NoPerkiraan02"], "").ToString();

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
                            db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtJnsTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, txtNamaTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsArusUang", SqlDbType.VarChar, _jnsArusUang));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan01", SqlDbType.VarChar, cboPerkiraan1.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan02", SqlDbType.VarChar, cboPerkiraan2.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@IsUploadable", SqlDbType.Bit, chkIsUploadable.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Kode Transaksi: " + txtJnsTransaksi.Text + " Sudah terdaftar di database");
                                txtJnsTransaksi.Text = string.Empty;
                                txtJnsTransaksi.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, txtNamaTransaksi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsArusUang", SqlDbType.VarChar, _jnsArusUang));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan01", SqlDbType.VarChar, cboPerkiraan1.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan02", SqlDbType.VarChar, cboPerkiraan2.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@IsUploadable", SqlDbType.Bit, chkIsUploadable.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
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
        }

        private void rdoPengeluaran_CheckedChanged(object sender, EventArgs e)
        {
            _jnsArusUang = "O";
        }

        private void set_optArusUang()
        {
            rdoPenerimaan.Checked = (_jnsArusUang == "I") ? true : false;
            rdoPengeluaran.Checked = (_jnsArusUang == "I") ? true : false;
        }
    }
}
