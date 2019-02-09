using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;

namespace ISA.Showroom.Master
{
    public partial class frmMotor : ISA.Controls.BaseForm
    {
        Guid _merkRowID, _produkRowID;
        String _merkMotor;

        public frmMotor()
        {
            InitializeComponent();
        }

        private void frmMotor_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshProduk();
                //RefreshMerk();               
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void RefreshProduk()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Produk_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Produk ASC";
                }

                if (dt.Rows.Count > 0)
                {
                    dgvProduk.DataSource = dt;
                    RefreshMerk();
                }
                else
                {
                    dgvProduk.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshMerk()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Merk_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@ProdukID", SqlDbType.UniqueIdentifier, (Guid)dgvProduk.SelectedCells[0].OwningRow.Cells["RowIDProduk"].Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Merk ASC";
                }

                if (dt.Rows.Count > 0)
                {
                    dgvMerk.DataSource = dt;
                    RefreshData();
                }
                else
                {
                    dgvMerk.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Type_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@ProdukID", SqlDbType.UniqueIdentifier, (Guid)dgvProduk.SelectedCells[0].OwningRow.Cells["RowIDProduk"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@MerkRowID", SqlDbType.UniqueIdentifier, (Guid)dgvMerk.SelectedCells[0].OwningRow.Cells["RowIDMerk"].Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Type ASC";
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        public void FindRowMerk(string columnName, string value)
        {
            dgvMerk.FindRow(columnName, value);
        }

        private void cboMerk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (dgvMerk.SelectedCells.Count > 0)
            {
                _merkRowID = (Guid)dgvMerk.SelectedCells[0].OwningRow.Cells["RowIDMerk"].Value;
            }
            else
            {
                _merkRowID = Guid.Empty;
            }
                
            _produkRowID = (Guid)dgvProduk.SelectedCells[0].OwningRow.Cells["RowIDProduk"].Value;
            _merkMotor = dgvMerk.SelectedCells[0].OwningRow.Cells["Merk"].Value.ToString();

            if (_merkRowID == Guid.Empty)
            {
                MessageBox.Show("Silahkan pilih Merk Motor terlebih dahulu !");
            }
            else
            {
                Master.frmMotorUpdate ifrmChild = new Master.frmMotorUpdate(this, _merkRowID, _merkMotor, _produkRowID);
                ifrmChild.ShowDialog();
            }
            
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmMotorUpdate ifrmChild = new Master.frmMotorUpdate(this, _rowID);
                ifrmChild.ShowDialog();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable _dtBeli = FillComboBox.DBGetPembelian(Guid.Empty, Guid.Empty, _rowID);
                        if (_dtBeli.Rows.Count > 0)
                        {
                            MessageBox.Show("Terdapat keterkaitan data !");
                            return;
                        }
                        else
                        {   // Pake CekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(_rowID, "Type") == true) // this.ceckDelete(_rowID) == true -> ke Type
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Type_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }
                            dataGridView1.Rows.Remove(dataGridView1.SelectedCells[0].OwningRow);
                            MessageBox.Show("Data berhasil dihapus");
                        }
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

        private void dgvProduk_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshMerk();
        }

        private void dgvMerk_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        /*
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell iCell in iRow.Cells)
                    {
                        if (iRow.Index % 2 == 0)
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 128);
                        }
                        else
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 255);
                        }
                    }
                }
            }
        }
        */ 
        /*
        private bool ceckDelete(Guid rowID)
        {
            bool hapus = false;
            DataTable dt = new DataTable();

            Command cmd = new Command(new Database(), CommandType.Text,
                                        " SELECT *                                                        " +
                                        "   FROM dbo.Type                                                 " +
                                        "  WHERE RowID = @RowID                                           " +
                                        "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                     );
            cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
            dt = cmd.ExecuteDataTable();

            if (dt.Rows.Count > 0) hapus = false;
            else hapus = true;

            return hapus;
        }
        */ 
    }
}
