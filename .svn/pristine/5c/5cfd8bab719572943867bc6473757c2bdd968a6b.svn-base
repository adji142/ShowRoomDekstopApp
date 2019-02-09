using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Master
{
    public partial class frmMotorUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID, _merkRowID, _produkRowID;
        string _merkMotor;

        DataTable dt;

        public frmMotorUpdate(Form caller, Guid MerkRowID, string MerkMotor, Guid ProdukRowID)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _merkRowID = MerkRowID;
            _merkMotor = MerkMotor;
            _produkRowID = ProdukRowID;
            _rowID = Guid.NewGuid();
        }

        public frmMotorUpdate(Form caller, Guid RowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            _rowID = RowID;
        }

        private void frmMotorUpdate_Load(object sender, EventArgs e)
        {
            txtKodeType.CharacterCasing = CharacterCasing.Normal;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ListMesin();
                this.setcboProduk();
                this.setcboMerk();
                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Type_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    _merkRowID = (Guid)dt.Rows[0]["MerkRowID"];

                    this.setcboKodeType();
                    if ((Guid)Tools.isNull(dt.Rows[0]["KodeTypeID"], Guid.Empty) != Guid.Empty)
                    {
                        cboKodeType.SelectedValue = (Guid)dt.Rows[0]["KodeTypeID"];
                    }

                    if ((Guid)Tools.isNull(dt.Rows[0]["ProdukID"], Guid.Empty) != Guid.Empty)
                    {
                        cboProduk.SelectedValue = (Guid)dt.Rows[0]["ProdukID"];
                    }

                    //DataTable dt2 = new DataTable();
                    //using (Database db2 = new Database())
                    //{
                    //    db2.Commands.Add(db2.CreateCommand("usp_Merk_LIST"));
                    //    db2.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _merkRowID));
                    //    dt2 = db2.Commands[0].ExecuteDataTable();
                    //}

                    cboMerk.SelectedValue = _merkRowID;
                    txtKodeType.Text = Tools.isNull(dt.Rows[0]["Type"], "").ToString();
                    txtCC.Text = Tools.isNull(dt.Rows[0]["Cc"], "").ToString();
                    string _idt = dt.Rows[0]["Mesin"].ToString();
                    switch (Tools.Left(_idt, 1))
                    {
                        case "2":
                            cboMesin.SelectedIndex = 0;
                            break;
                        case "4":
                            cboMesin.SelectedIndex = 1;
                            break;
                    } 
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    
                }
                else
                {
                    cboProduk.SelectedValue = _produkRowID;
                    txtKodeType.Text = "";
                    txtCC.Text = "";
                    txtKeterangan.Text = "";
                    cboMerk.SelectedIndex = 0;
                    if (_merkRowID != Guid.Empty)
                    {
                        cboMerk.SelectedValue = _merkRowID;
                    }
                    this.setcboKodeType();
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

        private void ListMesin()
        {
            cboMesin.DisplayMember = "Text";
            cboMesin.ValueMember = "Value";
            var items = new[] {
                new { Text = "2", Value = "2" },
                new { Text = "4", Value = "4" }
            };
            cboMesin.DataSource = items;
        }

        private void setcboProduk()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Produk_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Produk ASC";
                    cboProduk.DisplayMember = "Produk";
                    cboProduk.ValueMember = "RowID";
                    cboProduk.DataSource = dt.DefaultView;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void setcboMerk()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Merk_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Merk ASC";

                    cboMerk.DisplayMember = "Merk";
                    cboMerk.ValueMember = "RowID";
                    cboMerk.DataSource = dt.DefaultView;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void setcboKodeType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KodeType_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@MerkID", SqlDbType.UniqueIdentifier, _merkRowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    dt.DefaultView.Sort = "NamaType ASC";
                    cboKodeType.DisplayMember = "NamaType";
                    cboKodeType.ValueMember = "RowID";
                    cboKodeType.DataSource = dt.DefaultView;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmMotorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmMotor)
            {
                Master.frmMotor frmCaller = (Master.frmMotor)this.Caller;
                frmCaller.RefreshMerk();
                frmCaller.FindRowMerk("RowIDMerk", cboMerk.SelectedValue.ToString());
                frmCaller.RefreshData();
                frmCaller.FindRow("Type", txtKodeType.Text);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtKodeType.Text))
                {
                    MessageBox.Show("Kode Type Motor belum diisi !");
                    txtKodeType.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtCC.Text))
                {
                    MessageBox.Show("CC Motor belum diisi !");
                    txtCC.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cboKodeType.Text))
                {
                    MessageBox.Show("Type Motor belum dipilih !");
                    txtCC.Focus();
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.New)
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Type_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@MerkRowID", SqlDbType.UniqueIdentifier, (Guid)cboMerk.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, txtKodeType.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Cc", SqlDbType.VarChar, txtCC.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Mesin", SqlDbType.VarChar, cboMesin.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                        db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@Produk", SqlDbType.UniqueIdentifier, (Guid)cboProduk.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeType", SqlDbType.UniqueIdentifier, (Guid)cboKodeType.SelectedValue));
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
                        db.Commands.Add(db.CreateCommand("usp_Type_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@MerkRowID", SqlDbType.UniqueIdentifier, (Guid)cboMerk.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, txtKodeType.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Cc", SqlDbType.VarChar, txtCC.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Mesin", SqlDbType.VarChar, cboMesin.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@Produk", SqlDbType.UniqueIdentifier, (Guid)cboProduk.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeType", SqlDbType.UniqueIdentifier, (Guid)cboKodeType.SelectedValue));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    MessageBox.Show("Data berhasil diupdate");
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update data gagal " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtMerk_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCC_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMesin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtKeterangan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            _merkRowID = (Guid)cboMerk.SelectedValue;
             setcboKodeType();
        }
    }
}
