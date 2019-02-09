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
    public partial class frmKelompokHICabangBrowse : ISA.Controls.BaseForm
    {
        Guid _rowID = Guid.Empty;
        Class.FillComboBox fcbo = new Class.FillComboBox();
//        string _namaTransaksi = "";

        public frmKelompokHICabangBrowse()
        {
            InitializeComponent();
        }

        public frmKelompokHICabangBrowse(Guid rowID, string namaTransaksi)
        {
            InitializeComponent();
            _rowID = rowID;
            label2.Text = namaTransaksi;
            fcbo.fillComboCabang(cboCabang,GlobalVar.PerusahaanRowID);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmJnsTransaksiCabangBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokHICabang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KelompokHIRowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboCabang.Text))
            {
                MessageBox.Show("Cabang belum diisi");
                cboCabang.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokHICabang_INSERT"));

                    db.Commands[0].Parameters.Add(new Parameter("@KelompokHIRowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cboCabang.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        string _result = dt.Rows[0]["Result"].ToString();
                        switch (_result)
                        {
                            case "1":
                                MessageBox.Show("Jenis / Kode Transaksi :  Tidak ditemukan di database ");
                                break;
                            case "2":
                                MessageBox.Show("Cabang : " + cboCabang.Text + " Tidak ditemukan di database ");
                                break;
                            case "3":
                                MessageBox.Show("Jenis / Kode Transaksi :  Sudah terdaftar di Cabang " + cboCabang.Text);
                                break;
                        }
                        cboCabang.Text = string.Empty;
                        cboCabang.Focus();
                        return;
                    }
                    else
                        RefreshData();
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

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                if (MessageBox.Show("Hapus Jenis Transaksi : " + label2.Text + " di Cabang " + 
                        cboCabang.SelectedValue.ToString() + " ?", "DELETE", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KelompokHICabang_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.VarChar, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }
    }
}
