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
    public partial class frmKursMataUangUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        Class.FillComboBox fcbo = new Class.FillComboBox();
        DataTable dt;

        public frmKursMataUangUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKursMataUangUpdate(Form caller, Guid rowID)
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

        private void frmMataUangUpdate_Load(object sender, EventArgs e)
        {
            fcbo.fillComboMataUang(cboMataUang);
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
                        db.Commands.Add(db.CreateCommand("usp_KursMataUang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    cboMataUang.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["MataUangRowID"], Guid.Empty);
                    cboMataUang.Enabled = false;
                    txtTanggal.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalKurs"], "");
                    txtKurs.Text = String.Format("{0:N}", Tools.isNull(dt.Rows[0]["Kurs"], ""));
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
            if (string.IsNullOrEmpty(cboMataUang.Text))
            {
                MessageBox.Show("Mata Uang belum diisi");
                cboMataUang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTanggal.Text))
            {
                MessageBox.Show("Tanggal belum diisi");
                txtTanggal.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_KursMataUang_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TanggalKurs", SqlDbType.Date, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kurs", SqlDbType.Float, float.Parse(txtKurs.Text.ToString())));
                            //float.Parse(txtKurs.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Mata Uang ID: " + cboMataUang.Text + " Sudah terdaftar di database");
                                cboMataUang.Text = string.Empty;
                                cboMataUang.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KursMataUang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TanggalKurs", SqlDbType.DateTime, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kurs", SqlDbType.Float,  float.Parse(txtKurs.Text.ToString())));
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
                if (this.Caller is frmKursBrowse)
                {
                    frmKursBrowse frmCaller = (frmKursBrowse)this.Caller;
                    frmCaller.RefreshData();
//                    frmCaller.FindRow("RowID", _rowID);
                }
            }
            //this.Close();
        }
    }
}
