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
    public partial class frmKonsinyasiBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        String _cabangID = GlobalVar.CabangID;

        public frmKonsinyasiBrowse()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Konsinyasi_LIST_FILTER_TANGGAL"));
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

        private void frmKonsinyasiBrowse_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            _toDate = GlobalVar.GetServerDate;

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            RefreshData();
        }

        public void FindRow(String ColumnName, String value)
        {
            dataGridView1.FindRow(ColumnName, value);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Penjualan.frmKonsinyasiUpdate ifrmChild = new Penjualan.frmKonsinyasiUpdate(this);
            ifrmChild.ShowDialog();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                Penjualan.frmKonsinyasiUpdate ifrmChild = new Penjualan.frmKonsinyasiUpdate(this, rowID);
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
                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    try
                    {   // pake cekdelete punya Pak Novi
                        if (Class.PenerimaanUang.checkDelete(rowID, "Konsinyasi") == true ) // this.ceckDelete(rowID) == true -> ke Konsinyasi
                        {
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusKonsinyasi), "Hapus Konsinyasi.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                            if (GlobalVar.pinResult == false) { return; }
                        }

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Konsinyasi_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        dataGridView1.Rows.Remove(dataGridView1.SelectedCells[0].OwningRow);
                        MessageBox.Show("Data berhasil dihapus");
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

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

            DateTime dateRecordCreatedOn = DateTime.MinValue;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Check_TanggalInput_Record"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar, "Konsinyasi"));
                object objRecordCreatedOn = db.Commands[0].ExecuteScalar();
                if (objRecordCreatedOn != DBNull.Value)
                {
                    dateRecordCreatedOn = Convert.ToDateTime(objRecordCreatedOn);
                }

            }

            if (dateRecordCreatedOn.Date == GlobalVar.GetServerDate.Date) hapus = false;
            else hapus = true;

            return hapus;

           
        }
        */ 
    }
}
