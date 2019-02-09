using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Controls;
using ISA.DAL;

namespace ISA.Showroom.Finance.Master.Karyawan
{
    public partial class frmSubBagian : BaseForm
    {
        public frmSubBagian()
        {
            InitializeComponent();
        }

        #region variables

        Class.FillComboBox fcbo = new Class.FillComboBox();
        Guid _rowID;

        #endregion

        #region methodes

        private void ShowPanelUpdate()
        {
            dgvSubBagian.Visible = false;
            grpEditForm.Visible = true;
            cmdAdd.Enabled = false;
            cmdEdit.Visible = false;
            cmdSave.Visible = true;
            cmdDelete.Enabled = false;
            cmdClose.Visible = false;
            cmdCancel.Visible = true;
            txtNamaSub.Focus();

        }

        private void ClearInputan()
        {
            txtNamaSub.Text = "";
            txtNamaSub.Text = "";
                 
        }

        private void ShowPanelBrowse()
        {
            dgvSubBagian.Visible = true;
            grpEditForm.Visible = false;
            cmdAdd.Enabled = true;
            cmdEdit.Visible = true;
            cmdSave.Visible = false;
            cmdDelete.Enabled = true;
            cmdClose.Visible = true;
            cmdCancel.Visible = false;
        }


        private bool ValidasiInputan()
        {
            
            if (txtNamaSub.Text.Equals(""))
            {
                MessageBox.Show("Nama SubBagian Belum diisi.");
                txtNamaSub.Focus();
                return false;
            }
            if (cboBagian.Text.ToString().Equals(""))
            {
                MessageBox.Show("Nama Bagian pada ComboBox belum dipilih.");
                cboBagian.Focus();
                return false;
            }
            return true;
        }

        private DataTable LoadData(Guid RowID)
        {
            DataTable dt = new DataTable();
            if (RowID.Equals(Guid.Empty))
            {

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SubBagian_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                }
            }
            else
            {

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SubBagian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                }
            }

            return dt;
        }


        private void LoadFormData(Guid RowID)
        {
            if (RowID.Equals(Guid.NewGuid()))
            {
               
                txtNamaSub.Text = "";
                fcbo.fillComboBagian(cboBagian);
                cboBagian.SelectedIndex = 0;
            }
            else
            {
                DataTable dt = new DataTable();
                dt = LoadData(RowID);

                txtNamaSub.Text = Tools.isNull(dt.Rows[0]["NamaSubBagian"], "").ToString();
                fcbo.fillComboBagian(cboBagian);
                Guid BagianRowID = (Guid)Tools.isNull(dt.Rows[0]["BagianRowID"], Guid.Empty);
                cboBagian.SelectedValue = BagianRowID;

            }
        }


        private void save_update_data()
        {
            if(ValidasiInputan())
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SubBagian_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaSubBagian", SqlDbType.VarChar, txtNamaSub.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@BagianRowID", SqlDbType.UniqueIdentifier, cboBagian.SelectedValue));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                if (_rowID.Equals(Guid.Empty))
                {
                    MessageBox.Show(Messages.Confirm.SaveSuccess);
                    ShowPanelBrowse();
                }
                else
                {
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                    ShowPanelBrowse();
                }


                dgvSubBagian.DataSource = LoadData(Guid.Empty);

            }
            catch (Exception Ex)
            {
                Error.LogError(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void delete_data()
        {
            try
            {
                Guid RowID = (Guid)this.dgvSubBagian.SelectedCells[0].OwningRow.Cells["RowId"].Value;
                DialogResult Result = MessageBox.Show("Yakin data ini akan dihapus?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Result == DialogResult.OK)
                {

                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_SubBagian_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    }

                    dgvSubBagian.DataSource = LoadData(Guid.Empty);
                }


            }
            catch (Exception Ex)
            {
                Error.LogError(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        private void frmSubBagian_Load(object sender, EventArgs e)
        {
            ShowPanelBrowse();
            dgvSubBagian.DataSource=LoadData(Guid.Empty);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ClearInputan();
            ShowPanelUpdate();
            fcbo.fillComboBagian(cboBagian);
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            ShowPanelUpdate();
            _rowID = (Guid)this.dgvSubBagian.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            LoadFormData(_rowID);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ShowPanelBrowse();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            save_update_data();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            delete_data();
        }


    }
}
