using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Showroom.Finance.Master.Karyawan
{
    public partial class frmBagian : BaseForm
    {
        public frmBagian()
        {
            InitializeComponent();
        }

        #region variables

        Guid _rowID;

        #endregion

        #region methodes

        private void ShowPanelUpdate()
        {
            dgvBagian.Visible = false;
            grpEditForm.Visible = true;
            cmdAdd.Enabled = false;
            cmdEdit.Visible = false;
            cmdSave.Visible = true;
            cmdDelete.Enabled = false;
            cmdClose.Visible = false;
            cmdCancel.Visible = true;
            txtNamaBagian.Focus();

        }

        private void ShowPanelBrowse()
        {
            dgvBagian.Visible = true;
            grpEditForm.Visible = false;
            cmdAdd.Enabled = true;
            cmdEdit.Visible = true;
            cmdSave.Visible = false;
            cmdDelete.Enabled = true;
            cmdClose.Visible = true;
            cmdCancel.Visible = false;
        }

        private void ClearInputan()
        {
           
            txtNamaBagian.Text = "";
        }

        private bool ValidasiInputan()
        {
           
            if (txtNamaBagian.Text.Equals(""))
            {
                MessageBox.Show("Nama Bagian belum diisi.");
                txtNamaBagian.Focus();
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
                    db.Commands.Add(db.CreateCommand("usp_Bagian_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                }
            }
            else
            {

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Bagian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                   db.Close();
                }
            }
            
            return dt;
        }


        private void LoadFormData(Guid RowID)
        {
            if (RowID.Equals(Guid.Empty))
            {
        
                txtNamaBagian.Text = "";
            }
            else
            {
                DataTable dt = new DataTable();
                dt = LoadData(RowID);
               
                txtNamaBagian.Text = Tools.isNull(dt.Rows[0]["NamaBagian"], "").ToString();
            }
        }


        private void save_update_data()
        {
            if(ValidasiInputan())
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt=new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Bagian_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier,_rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaBagian",SqlDbType.VarChar,txtNamaBagian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserID));
                    dt=db.Commands[0].ExecuteDataTable();
 
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


                dgvBagian.DataSource=LoadData(Guid.Empty);

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
                Guid RowID = (Guid)this.dgvBagian.SelectedCells[0].OwningRow.Cells["RowId"].Value;
                DialogResult Result= MessageBox.Show("Yakin data ini akan dihapus?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Result == DialogResult.OK)
                {

                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Bagian_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    }

                    dgvBagian.DataSource = LoadData(Guid.Empty);
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



        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ClearInputan();
            ShowPanelUpdate();
            LoadFormData(Guid.Empty);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            save_update_data();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            _rowID = (Guid)this.dgvBagian.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            LoadFormData(_rowID);
            ShowPanelUpdate();

        }


        private void frmBagian_Load(object sender, EventArgs e)
        {
            ShowPanelBrowse();
            dgvBagian.DataSource=LoadData(Guid.Empty);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            delete_data();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ShowPanelBrowse();
        }

    }
}
