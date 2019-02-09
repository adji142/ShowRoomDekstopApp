using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;

namespace ISA.Showroom.Master
{
    public partial class frmLeasingUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        String _cabangID = GlobalVar.CabangID;

        DataTable dt;

        public frmLeasingUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _rowID = Guid.NewGuid();
        }

        public frmLeasingUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            _rowID = rowID;
        }

        private void frmLeasingUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Leasing_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtTelepon.Text = Tools.isNull(dt.Rows[0]["Telepon"], "").ToString();

                    DataTable dt2 = FillComboBox.DBGetProvinsi(Guid.Empty);
                    dt2.DefaultView.Sort = "Nama ASC";
                    cboProvinsi.DisplayMember = "Nama";
                    cboProvinsi.ValueMember = "RowID";
                    cboProvinsi.DataSource = dt2.DefaultView;
                    cboProvinsi.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();

                    Guid _provRowID = (Guid)cboProvinsi.SelectedValue;
                    DataTable dt3 = FillComboBox.DBGetKota(Guid.Empty, _provRowID);

                    dt3.DefaultView.Sort = "Nama ASC";
                    cboKota.DisplayMember = "Nama";
                    cboKota.ValueMember = "RowID";
                    cboKota.DataSource = dt3.DefaultView;
                    cboKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                }
                else
                {
                    DataTable dt = FillComboBox.DBGetProvinsi(Guid.Empty);
                    dt.DefaultView.Sort = "Nama ASC";
                    cboProvinsi.DisplayMember = "Nama";
                    cboProvinsi.ValueMember = "RowID";
                    cboProvinsi.DataSource = dt.DefaultView;

                    Guid _provRowID = (Guid)cboProvinsi.SelectedValue;
                    DataTable dt2 = FillComboBox.DBGetKota(Guid.Empty, _provRowID);

                    dt2.DefaultView.Sort = "Nama ASC";
                    cboKota.DisplayMember = "Nama";
                    cboKota.ValueMember = "RowID";
                    cboKota.DataSource = dt2.DefaultView;
                    // ambil dari app setting
                    DataTable dummyPR = new DataTable();
                    using (Database dbsubPR = new Database())
                    {
                        dbsubPR.Commands.Add(dbsubPR.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPR.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PROVPEMILIKBPKB"));
                        dummyPR = dbsubPR.Commands[0].ExecuteDataTable();
                        if (dummyPR.Rows.Count > 0)
                            cboProvinsi.Text = dummyPR.Rows[0]["Value"].ToString();
                    }
                    DataTable dummyKT = new DataTable();
                    using (Database dbsubKT = new Database())
                    {
                        dbsubKT.Commands.Add(dbsubKT.CreateCommand("usp_AppSetting_LIST"));
                        dbsubKT.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KOTAPEMILIKBPKB"));
                        dummyKT = dbsubKT.Commands[0].ExecuteDataTable();
                        if (dummyKT.Rows.Count > 0)
                            cboKota.Text = dummyKT.Rows[0]["Value"].ToString();
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

        private void cboProvinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid _provRowID = (Guid)cboProvinsi.SelectedValue;
                DataTable dt = FillComboBox.DBGetKota(Guid.Empty, _provRowID);

                dt.DefaultView.Sort = "Nama ASC";
                cboKota.DisplayMember = "Nama";
                cboKota.ValueMember = "RowID";
                cboKota.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeasingUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmLeasing)
            {
                Master.frmLeasing frmCaller = (Master.frmLeasing)this.Caller;
                frmCaller.RefreshData(_rowID);
                frmCaller.FindRow("Nama", txtNama.Text);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNama.Text))
                {
                    MessageBox.Show("Nama belum diisi !");
                    txtNama.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtAlamat.Text))
                {
                    MessageBox.Show("Alamat belum diisi !");
                    txtAlamat.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboProvinsi.Text))
                {
                    MessageBox.Show("Provinsi belum dipilih !");
                    cboProvinsi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKota.Text))
                {
                    MessageBox.Show("Kota belum dipilih !");
                    cboKota.Focus();
                    return;
                }
                
                this.Cursor = Cursors.WaitCursor;

                if (formMode == enumFormMode.New)
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Leasing_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, cboKota.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Provinsi", SqlDbType.VarChar, cboProvinsi.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Telepon", SqlDbType.VarChar, txtTelepon.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    MessageBox.Show("Data berhasil ditambahkan");
                    this.Close();
                }
                else
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Leasing_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, cboKota.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Provinsi", SqlDbType.VarChar, cboProvinsi.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Telepon", SqlDbType.VarChar, txtTelepon.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    MessageBox.Show("Data berhasil diupdate");
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtNama_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboProvinsi_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKota_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTelepon_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

    }
}
