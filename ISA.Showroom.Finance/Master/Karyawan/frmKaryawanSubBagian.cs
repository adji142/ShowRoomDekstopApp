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
    public partial class frmKaryawanSubBagian : BaseForm
    {

        Guid _KaryawaRowID; 
        Class.FillComboBox fcbo = new Class.FillComboBox();
        //Guid _rowID;
        String _namaKaryawan = String.Empty;
        Guid _KaryawanSubBagianRowID;
        public frmKaryawanSubBagian(Form caller,Guid RowID)
        {
            InitializeComponent();
            _KaryawaRowID = RowID;
        }

        private DataTable Loadkaryawan()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("Usp_Karyawan_LIST_Header"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _KaryawaRowID));
                dt = db.Commands[0].ExecuteDataTable();

            }
            return dt;
        }

        private DataTable LoadDataKaryawanSubBagian(Guid RowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_KaryawanSubBagian_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID", SqlDbType.UniqueIdentifier, _KaryawaRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            dgvKaryawanSubBagian.DataSource = dt;
            return dt;
        }

        private void DisplayKaryawanSubBagian()
        {
            DataTable dt_Karyawan = new DataTable();
            
            dt_Karyawan= Loadkaryawan();
            
            _namaKaryawan= Tools.isNull(dt_Karyawan.Rows[0]["NamaKaryawan"], "").ToString();
            txtNamaKaryawan.Text = _namaKaryawan;
            
            fcbo.fillComboBagianDanSub(cboSubBagian);
        }

        //private Guid GetCheckRowID()
        //{
           
        //    if (!_KaryawanSubBagianRowID.Equals(Guid.Empty))
        //    {
        //        return _KaryawanSubBagianRowID;
        //    }
        //    else
        //    {
        //        return _rowID;
        //    }
        //}



        private void save_data()
        {
            DataTable dt = new DataTable();

                for (int i = 0; i < dgvKaryawanSubBagian.Rows.Count; i++)
                {
                    Guid RowIDDGV = (Guid)this.dgvKaryawanSubBagian.Rows[i].Cells["SubBagianRowID"].Value;

                    if (RowIDDGV.Equals(cboSubBagian.SelectedValue))
                    {
                        MessageBox.Show("Maaf, SubBagian " + cboSubBagian.Text.ToString() + " untuk karyawan " + _namaKaryawan + " sudah ada.");
                        return;
                    }
                }



            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_KaryawanSubBagian_INSERT"));
                if ((Guid)Tools.isNull(_KaryawanSubBagianRowID,Guid.Empty)!=Guid.Empty)
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _KaryawanSubBagianRowID));
                db.Commands[0].Parameters.Add(new Parameter("@SubBagianRowID",SqlDbType.UniqueIdentifier,cboSubBagian.SelectedValue));
                db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID",SqlDbType.UniqueIdentifier,_KaryawaRowID));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if ((Guid)Tools.isNull(_KaryawanSubBagianRowID, Guid.Empty) != Guid.Empty)
            {
                MessageBox.Show(Messages.Confirm.SaveSuccess);
                LoadDataKaryawanSubBagian(_KaryawaRowID);
            }
            else
            {
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                LoadDataKaryawanSubBagian(_KaryawaRowID);
            }

    
            cboSubBagian.SelectedIndex = 0;
            _KaryawanSubBagianRowID = Guid.Empty;
        }

        private void delete_data()
        {
            try
            {
                Guid RowIdKaryawanSubBagian = (Guid)this.dgvKaryawanSubBagian.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                String NamaSubBagian = (String)this.dgvKaryawanSubBagian.SelectedCells[0].OwningRow.Cells["NamaSubBagian"].Value;

                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus SubBagian " + NamaSubBagian + Environment.NewLine +" untuk karyawan " + _namaKaryawan + "?","Perhatian",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_KaryawanSubBagian_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIdKaryawanSubBagian));
                        dt = db.Commands[0].ExecuteDataTable();
                        MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    }
                    LoadDataKaryawanSubBagian(_KaryawaRowID);
                }    
                
            }
            catch (Exception Ex)
            {
                Error.LogError(Ex);
            }

        }

        private void frmKaryawanSubBagian_Load(object sender, EventArgs e)
        {
            cmdCancel.Enabled = false;
            lblStatusEditDelete.Visible = false;
            lblStatusTambah.Visible = true;
            DisplayKaryawanSubBagian();
            LoadDataKaryawanSubBagian(_KaryawaRowID);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!cboSubBagian.Text.ToString().Equals(""))
            {
                save_data();
            }
            else
            {
                MessageBox.Show("Combo belum dipilih.");
                return;
            }

            
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            delete_data();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKaryawanSubBagian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKaryawanSubBagian.SelectedCells.Count > 0)
            {
                _KaryawanSubBagianRowID= (Guid)this.dgvKaryawanSubBagian.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid SubBagianRowID=(Guid)this.dgvKaryawanSubBagian.SelectedCells[0].OwningRow.Cells["SubBagianRowID"].Value;
                fcbo.fillComboBagianDanSub(cboSubBagian);
                cboSubBagian.SelectedValue = SubBagianRowID;
                
                lblStatusEditDelete.Visible = true;
                lblStatusTambah.Visible = false;
                cmdCancel.Enabled = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _KaryawanSubBagianRowID = Guid.Empty;
            cboSubBagian.SelectedIndex = 0;
            cmdCancel.Enabled = false;
            lblStatusTambah.Visible = true;
            lblStatusEditDelete.Visible = false;
        }
    }
}
