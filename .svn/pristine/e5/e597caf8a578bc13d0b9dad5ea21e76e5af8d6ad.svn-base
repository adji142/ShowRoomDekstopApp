using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Administrasi
{
    public partial class frmPindahPerusahaan : ISA.Controls.BaseForm
    {
        public frmPindahPerusahaan()
        {
            InitializeComponent();
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        frmMain frmMain = new frmMain();

        private void PindahPT()
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                Guid _rowID = (Guid)dataGridView.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (_rowID != null)
                {
                    if (Program.MainForm.CekLoadedForm())
                    {
                        GlobalVar.initialize(_rowID);
                        Program.MainForm.RefreshStatus();
                        MessageBox.Show("Berhasil berpindah ke PT " + GlobalVar.PerusahaanName, "Pindah Perusahaan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else MessageBox.Show("Masih ada form yang dibuka, \n Silakan tutup dahulu sebelum melanjutkan proses", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Tidak ada PT yang dipilih.");
            }

        }


        private void cmdYES_Click(object sender, EventArgs e)
        {
            PindahPT();                        
        }

        


        private void frmPindahPerusahaan_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        #region UserDefinedFunctions
        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    //for (int i = 0; i < dt.Rows.Count - 1; i++)
                    //{
                    //    if (dt.Rows[i]["InitPerusahaan"].ToString()=="ECR")
                    //    {
                    //        dt.Rows[i].Delete();
                    //    }
                        dataGridView.DataSource = dt;
                    //}

                        
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

        #endregion

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PindahPT();
        }
    }
}
