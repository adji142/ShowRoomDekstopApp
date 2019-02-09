using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPegadaianBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        int _nprint;

        public frmPegadaianBrowse()
        {
            InitializeComponent();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Penjualan.frmPegadaianUpdate ifrmChild = new Penjualan.frmPegadaianUpdate(this);
            Program.MainForm.CheckMdiChildren(ifrmChild);
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

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
                    db.Commands.Add(db.CreateCommand("usp_Pegadaian_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
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

        private void frmPegadaianBrowse_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            _toDate = GlobalVar.GetServerDate;

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            RefreshData();
            cmdEDIT.Enabled = false;
            // cmdBA.Enabled = false;
            // cmdCekList.Enabled = false;
        }


        public void FindRow(String ColumnName, String value)
        {
            dataGridView1.FindRow(ColumnName, value);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Guid pegadaianrowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Guid penjualanrowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;


            if (CheckPrint(penjualanrowID) == true)
            {
                MessageBox.Show("Sudah dilakukan cetak faktur, tidak diperkenankan menghapus data ini !");
                return;
            }
            else
            {
                Penjualan.frmPegadaianUpdate ifrmChild = new Penjualan.frmPegadaianUpdate(this, pegadaianrowID, penjualanrowID);
                Program.MainForm.CheckMdiChildren(ifrmChild);
            }
        }

        private bool CheckPrint(Guid rowID)
        {
            bool _cetak = false;

            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if ((int.Parse(dt.Rows[0]["Cetak1"].ToString()) > 0) || (int.Parse(dt.Rows[0]["Cetak2"].ToString()) > 0) ||
                        (int.Parse(dt.Rows[0]["Cetak3"].ToString()) > 0) || (int.Parse(dt.Rows[0]["Cetak4"].ToString()) > 0) ||
                        (int.Parse(dt.Rows[0]["Cetak5"].ToString()) > 0) || (int.Parse(dt.Rows[0]["Cetak6"].ToString()) > 0) ||
                        (int.Parse(dt.Rows[0]["Cetak7"].ToString()) > 0) || (int.Parse(dt.Rows[0]["Cetak8"].ToString()) > 0))
                    {
                        _cetak = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return _cetak;
        }

        private void frmPegadaianBrowse_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            // pas klik, ngga boleh edit kalau misalkan pengeluaran uang untuk yg Pinjaman Fisiknya sudah masuk ke jurnal
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid PengeluaranUangRowID = new Guid((Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PengeluaranUangRowID"].Value, Guid.Empty).ToString()));
                // checking ke pengeluaran uang, ada jurnalnya ngga
                DataTable dummy = new DataTable();
                using (Database dbf = new Database(GlobalVar.DBFinanceOto))
                {
                    dbf.Commands.Add(dbf.CreateCommand("usp_CheckJournalByPengeluaranUangRowID"));
                    dbf.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
                    dummy = dbf.Commands[0].ExecuteDataTable();
                    if (dummy.Rows.Count > 0)
                    {
                        // kalo udah masuk ke jurnal
                        cmdEDIT.Enabled = false;
                    }
                    else
                    {
                        cmdEDIT.Enabled = true;
                    }
                }
            }
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                string status = "KREDIT";// Pegadaian itu selalu Kredit
                Penjualan.frmPenjualanPrint ifrmChild = new Penjualan.frmPenjualanPrint(this, status, rowID);
                ifrmChild.ShowDialog();
            }
        }

        public void buttonFalse()
        {
            cmdEDIT.Enabled = false;
        }
    }
}
