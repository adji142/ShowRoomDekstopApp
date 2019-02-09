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
    public partial class frmPenjualanBrowseTLA : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable dt;
        Guid RowID_;
        DataTable dtCopy;

        public frmPenjualanBrowseTLA()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Database db1 = new Database();
                Database db2 = new Database();
                {
                    dt = new DataTable();
                    db1.Commands.Add(db1.CreateCommand("usp_PenjualanBARU_LIST_FILTER_TANGGAL"));
                    db1.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db1.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db1.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db1.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "BARU"));
                    dt = db1.Commands[0].ExecuteDataTable();
                    
                    DataTable dt2 = new DataTable();
                    db2.Commands.Add(db2.CreateCommand("usp_Koreksi_LIST_FILTER_TANGGAL"));
                    db2.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db2.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db2.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db2.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "BARU"));
                    dt2 = db2.Commands[0].ExecuteDataTable();

                    DataTable dtA = new DataTable();
                    dtA = dt.Copy();
                    dtA.Merge(dt2);

                    dataGridView1.DataSource = dtA;
                    //RowsColor(dataGridView1);
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

        private void frmPenjualanBrowseTLA_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(-12); // khusus penjualan minta sekarang from nya itu dikurang 12 bulan (1 thn)
            _toDate = GlobalVar.GetServerDate;// ke depan // DateTime.Today;

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            //RefreshData();
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
            Penjualan.frmPenjualanUpdateTLA ifrmChild = new Penjualan.frmPenjualanUpdateTLA(this);
            Program.MainForm.CheckMdiChildren(ifrmChild);
            RefreshData();
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

                if (adaKoreksi((Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value))
                {
                    MessageBox.Show("Tidak Bisa Dikoreksi");
                    isOk = false;
                    return;
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

                if (GlobalVar.CabangID.Contains("06"))
                {
                    // beda hari boleh diedit2 , tapi kalau udah ada jurnal penjualan ngga boleh diedit2!
                    using (Database db = new Database())
                    {
                        DataTable dummysub = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_CHECK_Jurnal"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                        dummysub = db.Commands[0].ExecuteDataTable();
                        if (dummysub.Rows.Count > 0)
                        {
                            Guid JouenalRowID = new Guid(Tools.isNull(dummysub.Rows[0]["JournalRowID"], Guid.Empty).ToString());
                            if (JouenalRowID == null || JouenalRowID == Guid.Empty)
                            {
                            }
                            else
                            {
                                MessageBox.Show("Penjualan sudah terjurnal, tidak dapat melakukan perubahan data!");
                                isOk = false;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (_tglJualSelected.Date != GlobalVar.GetServerDate.Date)
                    {
                        tempString = tempString + "Pengeditan Data hanya dapat dilakukan di hari yang sama dengan proses penginputan!\n";
                        isOk = false;
                    }
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
                    Penjualan.frmPenjualanUpdateTLA ifrmChild = new Penjualan.frmPenjualanUpdateTLA(this, rowID);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                    RefreshData();
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
                Guid PengeluaranKomisiRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PengeluaranKomisiRowID"].Value, Guid.Empty).ToString());
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
                            RefreshData();
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

        public void btnCari_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {          
                
                if (dataGridView1.Rows[e.RowIndex].Cells["RowIDKoreksiPenjualan"].Value.ToString() !="")
                {
                    foreach (DataGridViewCell dc in dataGridView1.Rows[e.RowIndex].Cells)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[dc.ColumnIndex].Style.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void RowsColor(DataGridView dgv)
        {
            DataTable dtemp = new DataTable();
            if (dataGridView1.DataSource != null)
            {
                dtemp = dataGridView1.DataSource as DataTable;
                for (int i = 0; i < dtemp.Rows.Count; i++)
                {
                    if (adaKoreksi((Guid)dtemp.Rows[i]["RowID"]))
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 192);
                    }
                    else
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                    }
                }
            }
        }

        private bool adaKoreksi(Guid _rowID)
        {
            DataTable dtcek = new DataTable();
            Database db = new Database();
            {
                db.Commands.Add(db.CreateCommand("usp_Koreksi_LIST_ByRowIDKoreksi"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                dtcek = db.Commands[0].ExecuteDataTable();
            }
            if (dtcek.Rows.Count > 0)
                return true;
            else
                return false;
        }

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

        private void cmdViewDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Penjualan.frmPenjualanUpdateTLA ifrmChild = new Penjualan.frmPenjualanUpdateTLA(this, rowID, "PEEK");
                Program.MainForm.CheckMdiChildren(ifrmChild);
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdGantiStok_Click(object sender, EventArgs e)
        {
            Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Penjualan.frmPenjualanGantiStok ifrmChild = new Penjualan.frmPenjualanGantiStok(this, rowID);
            Program.MainForm.CheckMdiChildren(ifrmChild);
        }

        private void cmdEditOTR_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid PenjRowID = new Guid (Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty).ToString());
                String KodeTrans = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["Pembayaran"].Value, "").ToString();

                if (KodeTrans.ToUpper().Contains("LEASING"))
                {
                    Penjualan.frmPenjualanEditOTR frmChild = new Penjualan.frmPenjualanEditOTR(this, PenjRowID);
                    frmChild.Show();
                }
                else
                {
                    MessageBox.Show("Fungsi ini hanya dapat digunakan untuk penjualan Leasing!");
                    return;
                }
            }
        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        Guid penjRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty).ToString());

                        // apakah print um untuk kwitansi bayar um pertama?
                        bool isFirst = false;
                        
                        string _edp;
                        string _terbilang;
                        string _kotatgl;
                        string _kota;
                        string _copy;
                        int _nprint;
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        frmPrint ifrmDialog = new frmPrint(this, 3);
                        ifrmDialog.ShowDialog();
                        if (ifrmDialog.DialogResult == DialogResult.Yes)
                        { _nprint = ifrmDialog.Result; }
                        else
                        { return; }

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_UM"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                            dt = db.Commands[0].ExecuteDataTable(); 
                            List<ReportParameter> rptParams = new List<ReportParameter>();

                            _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                            _terbilang = Tools.Terbilang(int.Parse(dt.Rows[0]["Nominal"].ToString(), NumberStyles.Currency)) + "RUPIAH";
                            _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();

                            _kota = _kota.Replace("Kota ", "");
                            _kota = _kota.Replace("Kabupaten ", "");

                            DateTime tglBayar;
                            tglBayar = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"].ToString(), GlobalVar.GetServerDate).ToString());
                            // _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                            _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                            
                            if (dt.Rows[0]["Cetak"].ToString() == "true")
                            {
                                if (int.Parse(dt.Rows[0]["nPrint"].ToString()) > 0)
                                {
                                    _copy = "Copy ke-" + dt.Rows[0]["nPrint"].ToString();
                                }
                                else
                                {
                                    _copy = "";
                                }
                            }
                            else
                            {
                                _copy = "";
                            }

                            String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                            String FileName = "";
                            using (Database dbLogo = new Database())
                            {
                                DataTable dtLogo = new DataTable();
                                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILE"));
                                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                                FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                            }

                            IMG_Path = IMG_Path + FileName;
                            rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));

                            String IMG_PathBW = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                            String FileNameBW = "";
                            using (Database dbLogo = new Database())
                            {
                                DataTable dtLogo = new DataTable();
                                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILEBW"));
                                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                                FileNameBW = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                            }

                            IMG_PathBW = IMG_PathBW + FileNameBW;
                            rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));

                            // nominal di paling atas khusus Uang Muka

                            rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["Nominal"]).ToString()));
                            
                            // minta di sampingnya no kontrak di kasih noAR
                            dt.Rows[0]["NoFaktur"] = dt.Rows[0]["NoFaktur"].ToString().Trim() + " - " + dt.Rows[0]["NoTrans"].ToString().Trim();

                            rptParams.Add(new ReportParameter("JnsKw", "UANG MUKA")); // DP Setara
                            rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                            rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                            rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                            rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                            rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                            // tambahan untuk kwitansi
                            rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));

                            //rptParams.Add(new ReportParameter("Tipe", "DPS"));
                            rptParams.Add(new ReportParameter("Tipe", "FIRST"));

                            if ((_nprint == 0) || (_nprint == 1))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansi.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            if ((_nprint == 0) || (_nprint == 2))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy1.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            if ((_nprint == 0) || (_nprint == 3))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy2.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            cmdDELETE.Enabled = false;

                            using (Database dbsub = new Database())
                            {
                                dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                                dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjRowID));
                                dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 9)); // sesuai yg sebelumnya, Cetak8
                                dbsub.Commands[0].ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                String KodeTransPJL = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value.ToString();

                if (KodeTransPJL == "LSG")
                {
                    cmdPRINTKW.Enabled = true;
                }
                else
                {
                    cmdPRINTKW.Enabled = false;
                }
            }
        }

        private void btn_BatalJual_Click(object sender, EventArgs e)
        {
            batal("Batal");
        }

        private void batal(string type)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0 || String.IsNullOrEmpty(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString()))
                {
                    MessageBox.Show("Data Kosong Atau Belum Dipilih");
                    return;
                }
                /*
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
                */
                _fromDate = rdtTanggal.FromDate.Value;
                _toDate = rdtTanggal.ToDate.Value;

                RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                dtCopy = new DataTable();
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenjualanBARU_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "BARU")); // yg baru tapi yg bekas...
                    dtCopy = db.Commands[0].ExecuteDataTable();
                }
                dtCopy.DefaultView.RowFilter = "RowID='" + RowID_ + "'";

                if (type.Equals("Batal"))
                {
                    Penjualan.frmPenjualanBatalJual ifrmChild = new Penjualan.frmPenjualanBatalJual(this, dtCopy.DefaultView.ToTable(), RowID_);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }
                else if(type.Equals("Koreksi"))
                {
                    string notrans = dataGridView1.SelectedCells[0].OwningRow.Cells["NoTransaksi"].Value.ToString();
                    string nobukti = dataGridView1.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                    Penjualan.frmPenjualanKoreksi ifrmChild = new Penjualan.frmPenjualanKoreksi(this, RowID_, dtCopy.DefaultView.ToTable(), notrans, nobukti);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdPrintSJ_Click(object sender, EventArgs e)
        {
            /*
            if (txtSupir.Text == "")
            {
                MessageBox.Show("Supir belum diisi");
                return;
            }
            */

            if (txtSupir.Text == "") txtSupir.Text = "                                   "; 
            try
            {
                Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenjualanSJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@Supir", SqlDbType.VarChar, txtSupir.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatanSJ.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@statuskirim", SqlDbType.Int, 1)); 
                    db.Commands[0].ExecuteNonQuery();
                }
                panelSJ.Visible = false;
                panelSJ.SendToBack();
                dataGridView1.Enabled = true;
                cetakSJ();
                cetakSerahTerima();
                RefreshData();
                FindRow("RowID", RowID_.ToString());
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
           
        }

        private void cmdCloseSJ_Click(object sender, EventArgs e)
        {
            panelSJ.Visible=false;
            panelSJ.SendToBack();
            dataGridView1.Enabled=true;
        }
        private void cetakSJ()
        {
            try
            {
                string _kotatgl;
                string _kota;
                string _copy = "";
                DateTime tglBayar;
                Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                        return;
                    }
                    _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    _kota = _kota.Replace("Kota ", "");
                    _kota = _kota.Replace("Kabupaten ", "");

                    tglBayar = GlobalVar.GetServerDate;
                    _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileName = "";

                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILE"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    IMG_Path = IMG_Path + FileName;
                    rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));

                    String IMG_PathBW = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileNameBW = "";
                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILEBW"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileNameBW = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    IMG_PathBW = IMG_PathBW + FileNameBW;
                    rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));

                    rptParams.Add(new ReportParameter("Judul", "SURAT JALAN".ToString()));
                    rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                    rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                    rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                    rptParams.Add(new ReportParameter("TglSJ", tglBayar.ToString("dd - MM - yyyy")));
                    rptParams.Add(new ReportParameter("Supir", txtSupir.Text));

                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptSJ.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    ifrmReport.Print();
                    frmReportViewer ifrmReport2 = new frmReportViewer("Penjualan.rptSJCopy1.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    ifrmReport2.Print();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cetakSerahTerima()
        {
            try
            {
                string _kotatgl;
                string _kota;
                DateTime tglBayar;
                Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    //if (dt.Rows.Count == 0)
                    //{
                    //    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                    //    return;
                    //}
                    _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    _kota = _kota.Replace("Kota ", "");
                    _kota = _kota.Replace("Kabupaten ", "");

                    tglBayar = GlobalVar.GetServerDate;
                    _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                    String FileName = "";

                    using (Database dbLogo = new Database())
                    {
                        DataTable dtLogo = new DataTable();
                        dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                        dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILE"));
                        dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                        FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                    }

                    IMG_Path = IMG_Path + FileName;
                    rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));
                    rptParams.Add(new ReportParameter("Judul", "BERITA ACARA SERAH TERIMA SEPEDA MOTOR".ToString()));
                    rptParams.Add(new ReportParameter("Tanggal", tglBayar.ToString("dd - MM - yyyy")));

                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptSerahTerima.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    ifrmReport.Print();
                    frmReportViewer ifrmReportCopy1 = new frmReportViewer("Penjualan.rptSerahTerimaCopy1.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    ifrmReportCopy1.Print();
                    frmReportViewer ifrmReportCopy2 = new frmReportViewer("Penjualan.rptSerahTerimaCopy2.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    ifrmReportCopy2.Print();
                    frmReportViewer ifrmReportCopy3 = new frmReportViewer("Penjualan.rptSerahTerimaCopy3.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    ifrmReportCopy3.Print();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cmdCetakSJ_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string _stsKirim = dataGridView1.SelectedCells[0].OwningRow.Cells["StatusKirim"].Value.ToString();

                if (_stsKirim == "Sudah Diterima")
                {
                    if (MessageBox.Show("Barang sudah di terima. Anda yakin ingin mencetak ulang SJ ?", "Informasi",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                panelSJ.Visible = true;
                panelSJ.BringToFront();
                dataGridView1.Enabled = false;
                txtSupir.Text = "";
                txtCatatanSJ.Text = "";
            }
        }

        private void cmdBarangDiterima_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string _stsKirim = dataGridView1.SelectedCells[0].OwningRow.Cells["StatusKirim"].Value.ToString();

                if (_stsKirim == "Belum Dikirim")
                {
                    MessageBox.Show("Barang belum dikirim");
                    return;
                }

                if (_stsKirim == "Sudah Diterima")
                {
                    if (MessageBox.Show("Barang sudah di terima. Anda yakin ingin mengubah status pengiriman data ini ?", "Update Status Kirim", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                try
                {
                    Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenjualanSJ"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@statuskirim", SqlDbType.Int, 2));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshData();
                    FindRow("RowID", RowID_.ToString());
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdBarangGagal_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string _stsKirim = dataGridView1.SelectedCells[0].OwningRow.Cells["StatusKirim"].Value.ToString();

                if (_stsKirim == "Belum Dikirim")
                {
                    MessageBox.Show("Barang belum dikirim");
                    return;
                }

                if (_stsKirim == "Sudah Diterima")
                {
                    if (MessageBox.Show("Barang sudah di terima. Anda yakin ingin mengubah status pengiriman data ini ?", "Update Status Kirim", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                try
                {
                    Guid RowID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenjualanSJ"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@statuskirim", SqlDbType.Int, 3));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshData();
                    FindRow("RowID", RowID_.ToString());
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdKoreksi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                bool isOk = true;
                String tempString = "";

                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DateTime _tglJualSelected = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglJual"].Value;
                String _pembayaran = (String)dataGridView1.SelectedCells[0].OwningRow.Cells["Pembayaran"].Value;
                
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

                DataTable dtCount = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_byPenjualanRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtCount = db.Commands[0].ExecuteDataTable();
                }

                if (adaKoreksi((Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value))
                {
                    MessageBox.Show("Tidak Bisa Dikoreksi");
                    isOk = false;
                    return;
                }

                //if (CheckPrint(rowID) == true)
                //{
                //    tempString = tempString + "Sudah dilakukan cetak faktur, tidak diperkenankan mengedit data ini !\n";
                //    isOk = false;
                //}

                if (_pembayaran.ToString() == "BUNGA TETAP / FLAT")
                {
                    if (dtCount.Rows.Count > 0)
                    {
                        MessageBox.Show("Sudah Ada Angsuran, nota tidak bisa dikoreksi");
                        isOk = false;
                        return;
                    }
                }
                //if (dtUMK.Rows.Count > 0 && (Convert.ToBoolean(dtUMK.Rows[0]["Cetak"].ToString()) == true || int.Parse(dtUMK.Rows[0]["nPrint"].ToString()) > 0))
                //{
                //    tempString = tempString + "Sudah pernah melakukan pencetakan Kwitansi Uang Muka, lakukan proses tarikan, data sudah tidak dapat diedit!\n";
                //    isOk = false;
                //}
                /*
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
                */
                if (GlobalVar.CabangID.Contains("06"))
                {
                    // beda hari boleh diedit2 , tapi kalau udah ada jurnal penjualan ngga boleh diedit2!
                    using (Database db = new Database())
                    {
                        DataTable dummysub = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_CHECK_Jurnal"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                        dummysub = db.Commands[0].ExecuteDataTable();
                        if (dummysub.Rows.Count > 0)
                        {
                            Guid JouenalRowID = new Guid(Tools.isNull(dummysub.Rows[0]["JournalRowID"], Guid.Empty).ToString());
                            if (JouenalRowID == null || JouenalRowID == Guid.Empty)
                            {
                            }
                            else
                            {
                                MessageBox.Show("Penjualan sudah terjurnal, tidak dapat melakukan perubahan data!");
                                isOk = false;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (_tglJualSelected.Date != GlobalVar.GetServerDate.Date)
                    {
                        tempString = tempString + "Pengeditan Data hanya dapat dilakukan di hari yang sama dengan proses penginputan!\n";
                        isOk = false;
                    }
                }
                // cek data komisinya udah masuk jurnal belum
                Guid PengeluaranKomisiRowID = (Guid)Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PengeluaranKomisiRowID"].Value, Guid.Empty);
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
                    batal("Koreksi");
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //RowsColor(dataGridView1);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void btnProcKomisi_Click(object sender, EventArgs e)
        {
            Penjualan.frmKomisiBrowse ifrmChild = null;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                ifrmChild = new Penjualan.frmKomisiBrowse((Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value);

            } else ifrmChild = new Penjualan.frmKomisiBrowse();
            ((frmMain)this.Parent.Parent).CheckMdiChildren(ifrmChild);
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
