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
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmKonversiBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridPenjualan, GridKonversi };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridPenjualan;

        DateTime _fromDate, _toDate;
        Guid _penjRowID, _rowID;
        String _cabangID = GlobalVar.CabangID;

        public frmKonversiBrowse()
        {
            InitializeComponent();
        }

        private void LoadPenjualan()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Konversi_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                cmdADD.Enabled = false;
                cmdDELETE.Enabled = false;
                cmdPRINT.Enabled = false;

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

        private void LoadKonversi()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    _penjRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Angsuran_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridView2.DataSource = dt;
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
        }

        public void FindRowGrid1(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        public void FindRowGrid2(string columnName, string value)
        {
            dataGridView2.FindRow(columnName, value);
        }

        public void refreshHeader(Guid penjRowID)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Angsuran_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmKonversiBrowse_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            _toDate = GlobalVar.GetServerDate;

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            LoadPenjualan();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LoadKonversi();
                _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Konversi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Jumlah"], 0)) > 0) 
                { 
                    cmdADD.Enabled = false;
                    cmdPRINT.Enabled = true;
                }
                else 
                { 
                    cmdADD.Enabled = true;
                    cmdPRINT.Enabled = false;
                }
                if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["TerimaAngs"], 0)) == 0) { cmdDELETE.Enabled = true; }
                else { cmdDELETE.Enabled = false; }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Konversi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Jumlah"], 0)) > 0)
                {
                    cmdADD.Enabled = false;
                    cmdPRINT.Enabled = true;
                }
                else
                {
                    cmdADD.Enabled = true;
                    cmdPRINT.Enabled = false;
                }
                if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["TerimaAngs"], 0)) == 0) { cmdDELETE.Enabled = true; }
                else { cmdDELETE.Enabled = false; }
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPenjualan;
            dataGridView1_SelectionChanged(sender, e);
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridKonversi;
            dataGridView2_SelectionChanged(sender, e);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

            LoadPenjualan();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.GridPenjualan)
            {
                Penjualan.frmKonversiUpdate ifrmChild = new Penjualan.frmKonversiUpdate(this, _penjRowID);
                ifrmChild.ShowDialog();
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (selectedGrid == enumSelectedGrid.GridKonversi)
            {
                if (dataGridView2.SelectedCells.Count > 0)
                {
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;

                        if (CheckPrint(_rowID) == true)
                        {
                            MessageBox.Show("Sudah dilakukan pelunasan Angsuran, tidak diperkenankan menghapus data ini !");
                        }
                        else
                        {   // pake cekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(_rowID, "Penjualan_Hist") == true) // this.ceckDelete(_rowID) == true -> ke Penjualan_Hist
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusUbahAngsuran), "Hapus Ubah Angsuran.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_Konversi_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            dataGridView2.Rows.Remove(dataGridView2.SelectedCells[0].OwningRow);
                            this.LoadPenjualan();                            
                            MessageBox.Show("Data berhasil dihapus");
                        }
                    }
                }
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
                    db.Commands.Add(db.CreateCommand("usp_Konversi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["TerimaAngs"], 0)) == 0) { _cetak = false; }
                    else { _cetak = true; }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return _cetak;
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string status = "KREDIT";
                Penjualan.frmPenjualanPrint ifrmChild = new Penjualan.frmPenjualanPrint(this, status, rowID);
                ifrmChild.ShowDialog();
            }
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

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dataGridView2.Rows)
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
                                        "   FROM dbo.Penjualan_Hist                                       " +
                                        "  WHERE PenjRowID = @RowID                                       " +
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
