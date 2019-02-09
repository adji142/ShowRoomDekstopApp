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
    public partial class frmVendorUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        enum enumTipeVendor { Lokal, Import };
        enumTipeVendor tipeVendor;
        bool _isAktif = true;
        Guid _rowID;

        DataTable dt;

        public frmVendorUpdate()
        {
            InitializeComponent();
        }

        public frmVendorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmVendorUpdate(Form caller, Guid rowID)
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

        private void frmVendorUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string _namaNegara = "Indonesia";
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtVendorID.Text = Tools.isNull(dt.Rows[0]["VendorID"], "").ToString();
                    //txtVendorID.Enabled = false;
                    txtNamaVendor.Text = Tools.isNull(dt.Rows[0]["NamaVendor"], "").ToString();
                    tipeVendor = (enumTipeVendor)Tools.isNull(dt.Rows[0]["TipeVendor"],0);
                    cboTipeVendor.Text = tipeVendor.ToString();
                    _isAktif = bool.Parse(Tools.isNull(dt.Rows[0]["IsAktif"], "false").ToString());
                    chkIsAktif.Checked = _isAktif;
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    _namaNegara = Tools.isNull(dt.Rows[0]["Negara"], "").ToString();
                    txtNoTelp.Text = Tools.isNull(dt.Rows[0]["NoTelp"], "").ToString();
                }

                DataTable dt1 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Negara_LIST"));
                    dt1 = db.Commands[0].ExecuteDataTable();
                    dt1.Rows.Add("");
                    dt1.DefaultView.Sort = "NamaNegara";
                    cboNegara.DataSource = dt1;
                    cboNegara.ValueMember = "NamaNegara";
                    cboNegara.DisplayMember = "NamaNegara";
                }
                cboNegara.Text = _namaNegara;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            chkIsAktif.Checked = _isAktif;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if ((formMode!=enumFormMode.New)&&(string.IsNullOrEmpty(txtVendorID.Text)))
            {
                MessageBox.Show("Kode belum diisi");
                txtVendorID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNamaVendor.Text))
            {
                MessageBox.Show("Cabang belum diisi");
                txtNamaVendor.Focus();
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
                            if (string.IsNullOrEmpty(txtVendorID.Text.ToString()))
                                    txtVendorID.Text = Numerator.GetNomorDokumen("KODE_VENDOR", "V","", 3, true, false);
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Vendor_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@VendorID", SqlDbType.VarChar, txtVendorID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaVendor", SqlDbType.VarChar, txtNamaVendor.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TipeVendor", SqlDbType.VarChar, cboTipeVendor.SelectedIndex));
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Negara", SqlDbType.VarChar, cboNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ContactPerson", SqlDbType.VarChar, txtContactPerson.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Vendor ID: " + txtVendorID.Text + " Sudah terdaftar di database");
                                txtVendorID.Text = string.Empty;
                                txtVendorID.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Vendor_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@VendorID", SqlDbType.VarChar, txtVendorID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaVendor", SqlDbType.VarChar, txtNamaVendor.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TipeVendor", SqlDbType.VarChar, cboTipeVendor.SelectedIndex));
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, chkIsAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Negara", SqlDbType.VarChar, cboNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ContactPerson", SqlDbType.VarChar, txtContactPerson.Text));
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
                if (this.Caller is frmVendorBrowse)
                {
                    frmVendorBrowse frmCaller = (frmVendorBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("VendorID", txtVendorID.Text);
                }
            }
            //this.Close();
        }

        private void cboTipeVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s =  cboTipeVendor.Text.ToString();
            if (s == "Lokal") {
                cboNegara.Text = "Indonesia";
                cboNegara.Enabled = false;
            } else {
                cboNegara.Enabled = true;
            }
            cboNegara.Refresh();
        }
    }
}
