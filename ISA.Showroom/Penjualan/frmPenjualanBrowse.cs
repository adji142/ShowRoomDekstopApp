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
    public partial class frmPenjualanBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable dt_List_Filter;

        public frmPenjualanBrowse()
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
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "ORI"));
                    dt = db.Commands[0].ExecuteDataTable();                    
                    dataGridView1.DataSource = dt;
                    dt_List_Filter = dt;
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

        private void frmPenjualanBrowse_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(-12); // khusus penjualan minta sekarang from nya itu dikurang 12 bulan (1 thn)
            _toDate = GlobalVar.GetServerDate;// ke depan // DateTime.Today;

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
            Penjualan.frmPenjualanUpdate ifrmChild = new Penjualan.frmPenjualanUpdate(this);
            Program.MainForm.CheckMdiChildren(ifrmChild);
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                bool isOk = true;
                String tempString = "";

                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DateTime _tglJualSelected = (DateTime) dataGridView1.SelectedCells[0].OwningRow.Cells["TglJual"].Value; 
                /*
                Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                     "SELECT * FROM dbo.PenerimaanAngsuran WHERE PenjRowID = @PenjRowID");
                cmdAngs.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID);
                DataTable dtAngs = cmdAngs.ExecuteDataTable();
                */ 
                /*
                Command cmdUMK = new Command(new Database(), CommandType.Text,
                                                     "SELECT * FROM dbo.PenerimaanUM WHERE PenjRowID = @PenjRowID");
                cmdUMK.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID);
                DataTable dtUMK = cmdUMK.ExecuteDataTable();
                */   
                /*
                Command cmdADM = new Command(new Database(), CommandType.Text,
                                                     "SELECT * FROM dbo.PenerimaanADM WHERE PenjRowID = @PenjRowID");
                cmdADM.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID);
                DataTable dtADM = cmdADM.ExecuteDataTable();
                */

                DataTable dtAngs = new DataTable();
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtAngs = db.Commands[0].ExecuteDataTable();                    
                }

                DataTable dtUMK = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtUMK = db.Commands[0].ExecuteDataTable();
                }

                DataTable dtADM = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtADM = db.Commands[0].ExecuteDataTable();
                }

                if (CheckPrint(rowID) == true)
                {
                   tempString = tempString + "Sudah dilakukan cetak faktur, tidak diperkenankan mengedit data ini !\n" ;
                    isOk = false;
                }
                /* // untuk UM di biarkan terlebih dahulu
                if (dtUMK.Rows.Count > 0)
                {
                    tempString = tempString + "Sudah dilakukan pelunasan, tidak diperkenankan mengedit data ini !\n";
                    isOk = false;
                }
                */
                if (dtUMK.Rows.Count > 0 && (Convert.ToBoolean(dtUMK.Rows[0]["Cetak"].ToString()) == true || int.Parse(dtUMK.Rows[0]["nPrint"].ToString()) > 0))
                {
                    tempString = tempString + "Sudah pernah melakukan pencetakan Kwitansi Uang Muka, lakukan proses tarikan, data sudah tidak dapat diedit!\n";
                    isOk = false;
                }
                if (dtADM.Rows.Count > 0)
                {
                    tempString = tempString + "Sudah dilakukan pelunasan Biaya Administrasi, tidak diperkenankan mengedit data ini !\n";
                    isOk = false;
                }
                if (dtAngs.Rows.Count > 0)
                {
                    tempString = tempString + "Sudah dilakukan pelunasan Angsuran, tidak diperkenankan mengedit data ini !\n";
                    isOk = false;
                }
                if (_tglJualSelected.Date != GlobalVar.GetServerDate.Date)
                {
                    tempString = tempString + "Pengeditan Data hanya dapat dilakukan di hari yang sama dengan proses penginputan!\n";
                    isOk = false;
                }

                // cek data komisinya udah masuk jurnal belum
                Guid PengeluaranKomisiRowID = (Guid) Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PengeluaranKomisiRowID"].Value, Guid.Empty);
                DataTable dummy = new DataTable();
                using (Database dbf = new Database(GlobalVar.DBFinanceOto))
                {
                    dbf.Commands.Add(dbf.CreateCommand("usp_CheckJournalByPengeluaranUangRowID"));
                    dbf.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranKomisiRowID));
                    dummy = dbf.Commands[0].ExecuteDataTable();
                    if (dummy.Rows.Count > 0)
                    {
                        tempString = tempString + "Data Komisi sudah masuk ke dalam Jurnal, tidak dapat diedit lagi!\n";
                        isOk = false;
                    }
                }

                if (isOk == true)
                {
                    Penjualan.frmPenjualanUpdate ifrmChild = new Penjualan.frmPenjualanUpdate(this, rowID);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }
                else
                {
                    MessageBox.Show(tempString);
                }
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
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                /*
                Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                     "SELECT * FROM dbo.PenerimaanAngsuran WHERE PenjRowID = @PenjRowID");
                cmdAngs.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID);
                DataTable dtAngs = cmdAngs.ExecuteDataTable();

                Command cmdUMK = new Command(new Database(), CommandType.Text,
                                                     "SELECT * FROM dbo.PenerimaanUM WHERE PenjRowID = @PenjRowID");
                cmdUMK.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID);
                DataTable dtUMK = cmdUMK.ExecuteDataTable();

                Command cmdADM = new Command(new Database(), CommandType.Text,
                                                     "SELECT * FROM dbo.PenerimaanADM WHERE PenjRowID = @PenjRowID");
                cmdADM.AddParameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID);
                DataTable dtADM = cmdADM.ExecuteDataTable();
                */

                DataTable dtAngs = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtAngs = db.Commands[0].ExecuteDataTable();
                }

                DataTable dtUMK = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtUMK = db.Commands[0].ExecuteDataTable();
                }

                DataTable dtADM = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtADM = db.Commands[0].ExecuteDataTable();
                }

                // cek data komisinya udah masuk jurnal belum
                Guid PengeluaranKomisiRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["PengeluaranKomisiRowID"].Value;
                DataTable dummy = new DataTable();
                using (Database dbf = new Database(GlobalVar.DBFinanceOto))
                {
                    dbf.Commands.Add(dbf.CreateCommand("usp_CheckJournalByPengeluaranUangRowID"));
                    dbf.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranKomisiRowID));
                    dummy = dbf.Commands[0].ExecuteDataTable();
                } 

                if (CheckPrint(rowID) == true)
                {
                    MessageBox.Show("Sudah dilakukan cetak faktur, tidak diperkenankan menghapus data ini !");
                }
                else if (dtUMK.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah dilakukan pelunasan, tidak diperkenankan menghapus data ini !");
                }
                else if (dtADM.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah dilakukan pelunasan Biaya Administrasi, tidak diperkenankan menghapus data ini !");
                }
                else if (dtAngs.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah dilakukan pelunasan Angsuran, tidak diperkenankan menghapus data ini !");
                }
                else if (dummy.Rows.Count > 0)
                {
                    MessageBox.Show("Data Komisi sudah masuk ke dalam Jurnal, tidak dapat diedit lagi!\n");
                }    
                else
                {
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {   // pake cekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "Penjualan") == true) // this.ceckDelete(rowID) == true -> ke Penjualan
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusPenjualan), "Hapus Penjualan.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Penjualan_DELETE"));
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
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

            RefreshData();
        }

        public void buttonFalse()
        {
            cmdEDIT.Enabled = false;
            cmdDELETE.Enabled = false;
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string status = dataGridView1.SelectedCells[0].OwningRow.Cells["JenisPenjualan"].Value.ToString();
                Penjualan.frmPenjualanPrint ifrmChild = new Penjualan.frmPenjualanPrint(this, status,rowID);
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
        */
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            // cek kalau lagi klik itu lagi di kolom yg button itu bukan
            int row;
            String col;
            String folderPath;
            if(dataGridView1.SelectedCells.Count > 0)
            {
                // kalo ada yg kepilih ambil kolom mana, dan row mana
                row = dataGridView1.SelectedCells[0].OwningRow.Index;
                col = dataGridView1.SelectedCells[0].OwningColumn.Name;

                if(col == "ViewAttach") // kalo kolom yg di klik itu kolom ViewAttach
                {
                    // ambil folderpathnya, sama PenjRowID
                    folderPath = dataGridView1.SelectedCells[0].OwningRow.Cells["FolderPath"].Value.ToString();
                    Guid PenjRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty).ToString());
                    // buka form browse attachmentnya

                    Penjualan.frmPenjualanBrowseAttachment ifrmChild = new Penjualan.frmPenjualanBrowseAttachment(this, PenjRowID, folderPath);
                    Program.MainForm.CheckMdiChildren(ifrmChild);

                }
            } 
        }

        private void btn_BatalJual_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0 || String.IsNullOrEmpty(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString()))
                {
                    MessageBox.Show("Data Kosong Atau Belum Dipilih");
                    return;
                }
                //if (tanggalAngs <= GlobalVar.GetServerDate.Date.AddDays(-2))
                if (DateTime.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["TglJual"].Value.ToString()) <= GlobalVar.GetServerDate.Date.AddDays(-2))
                {
                    MessageBox.Show("Hanya data hari kemarin dan hari ini yang boleh dibatalkan.");
                    return;
                }

                #region MintaPin
                // minta PIN
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                // minta Pin
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.BatalJual), "Batal Penjualan.\nSudah lewat tanggal, tidak diperkenankan membatalkan penjualan ini !");
                if (GlobalVar.pinResult == false) { return; }
                #endregion


                Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dtCopy = new DataTable();

                _fromDate = rdtTanggal.FromDate.Value;
                _toDate = rdtTanggal.ToDate.Value;

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "ORI"));
                    dtCopy = db.Commands[0].ExecuteDataTable();
                }

                dtCopy.DefaultView.RowFilter = "RowID='" + RowID_ + "'";

                Penjualan.frmPenjualanBatalJual ifrmChild = new Penjualan.frmPenjualanBatalJual(this, dtCopy.DefaultView.ToTable(), RowID_);
                Program.MainForm.CheckMdiChildren(ifrmChild);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
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
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar, "Penjualan"));
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
