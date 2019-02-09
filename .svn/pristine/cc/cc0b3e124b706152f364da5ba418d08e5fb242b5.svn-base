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
    public partial class frmKaryawanBrowse : BaseForm
    {
        public frmKaryawanBrowse()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Master.Karyawan.frmKaryawanUpdate ifrm = new Master.Karyawan.frmKaryawanUpdate(this);
            Program.MainForm.RegisterChild(ifrm);
            ifrm.ShowDialog();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedCells.Count != 0)
            {
                Master.Karyawan.frmKaryawanUpdate ifrm = new Master.Karyawan.frmKaryawanUpdate(this,_karyawanRowID);
                Program.MainForm.RegisterChild(ifrm);
                ifrm.ShowDialog();
            }
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            delete_data();
        }

        private void frmKaryawanBrowse_Load(object sender, EventArgs e)
        {
            txtCariNamaKaryawan.Focus();
            LoadDataKaryawan();
            if (this.dgvKaryawan.Rows.Count > 0)
            {
                dgvKaryawan_Click(null, null);   
            }
        }

        #region Variables
        #endregion
        Guid _karyawanRowID=Guid.Empty;
        #region Methodes

        public void LoadDataKaryawan()
        {
            try
            {
                this.Cursor = Cursors.Default;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("Usp_Karyawan_LIST_Header"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dgvKaryawan.DataSource = dt;
               
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

        public void FindRow(String ColumnName, String Value)
        {
            dgvKaryawan.FindRow(ColumnName, Value);
        }

        private void delete_data()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DialogResult Result = MessageBox.Show("Anda yakin untuk menghapus data ini?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Karyawan_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _karyawanRowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    LoadDataKaryawan();
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

        private void dgvKaryawan_Click(object sender, EventArgs e)
        {
            _karyawanRowID = (Guid)this.dgvKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
        }

        private void txtCariNamaKaryawan_KeyUp(object sender, KeyEventArgs e)
        {
           
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Karyawan_SEARCH"));
                db.Commands[0].Parameters.Add(new Parameter("@Search", SqlDbType.VarChar, txtCariNamaKaryawan.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dgvKaryawan.DataSource = dt;
            }
        }

        private void dgvKaryawan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid RowIDKaryawan = (Guid)this.dgvKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Master.Karyawan.frmKaryawanSubBagian ifrm = new Master.Karyawan.frmKaryawanSubBagian(this,RowIDKaryawan);
            ifrm.ShowDialog();

        }



    }
}
