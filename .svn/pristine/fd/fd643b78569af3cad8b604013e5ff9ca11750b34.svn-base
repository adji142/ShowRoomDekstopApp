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
    public partial class frmUangMukaBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridPenjualan, GridUangMuka, GridPelunasan };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridPenjualan;

        DateTime _fromDate, _toDate, _tglAwalAngs;
        double _saldo;
        Guid _penjRowID, _rowID, _custRowID, _penjHistRowID;
        String _cabangID = GlobalVar.CabangID;

        /*
            datagrid1 -> isinya data penjualan tipe kredit
            datagrid2 -> isinya data penerimaan UM
        */
        
        public frmUangMukaBrowse()
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
                    db.Commands.Add(db.CreateCommand("usp_PenjualanKredit_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                cmdADD.Enabled = false;
                cmdTAMBAHUM.Enabled = false;
                cmdDELETE.Enabled = false;
                cmdPRINTKW.Enabled = false;
               
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

        private void LoadUangMuka()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    _penjRowID = (Guid)Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty);
                    _custRowID = (Guid)Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["CustRowID"].Value, Guid.Empty);
                    _penjHistRowID = (Guid)Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PenjHistRowID"].Value, Guid.Empty);
                    _tglAwalAngs = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglAwalAngs"].Value; 
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_UangMuka_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridView2.DataSource = dt;
                        cmdADD.Enabled = false;
                        cmdTAMBAHUM.Enabled = false;
                        cmdDELETE.Enabled = false;
                        cmdPRINTKW.Enabled = false;
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

        private void LoadPembayaran()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                try
                {
                    _penjRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                    string _kodeTrans = dataGridView2.SelectedCells[0].OwningRow.Cells["mKodeTrans"].Value.ToString();
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        // db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridView3.DataSource = dt;

                    }
                    cmdRencanaUM.Enabled = false;
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


        public void LoadTitipanIden()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                _penjRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();

                        db.Commands.Add(db.CreateCommand("usp_DaftarTitipanSudahIden_UM"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));

                        dt = db.Commands[0].ExecuteDataTable();
                        gvTitipanGiro.DataSource = dt;
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

        public void FindRowGrid3(string columnName, string value)
        {
            dataGridView3.FindRow(columnName, value);
        }

        private void frmUangMukaBrowse_Load(object sender, EventArgs e)
        {
            cmdReCalcAngs.Enabled = false;
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(-6);// minta sekarang from nya itu dikurang 6 bulan ke belakang
            _toDate = GlobalVar.GetServerDate; 

            gvTitipanGiro.AutoGenerateColumns = false; 

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            LoadPenjualan();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LoadUangMuka();
                if (dataGridView2.RowCount > 0)
                {
                    LoadPembayaran();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dataGridView3.DataSource = dt;
                }
            }
        }

        private void DisableTambahUMCheckTarikan()
        {
            int rowGV = 0;
            double sumIden = 0;
            for (rowGV = 0; rowGV < dataGridView3.Rows.Count; rowGV++)
            {
                if (dataGridView3.Rows[rowGV].Cells["KodeTrans"].Value.ToString() == "TRK")
                {
                    cmdTAMBAHUM.Enabled = false;
                    break;
                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count > 0)
            {
                _penjRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                if (_saldo > 0) { cmdADD.Enabled = true; cmdTARIKAN.Enabled = true; cmdTAMBAHUM.Enabled = false; } // tadinya _saldo != 0
                else { cmdADD.Enabled = false; cmdTARIKAN.Enabled = false; cmdTAMBAHUM.Enabled = true; }

                LoadPembayaran();
                LoadTitipanIden();
                DisableTambahUMCheckTarikan();
                String kodeTrans = dataGridView1.SelectedCells[0].OwningRow.Cells["SistemAngs"].Value.ToString();

                if (GlobalVar.CabangID.Contains("06") && (kodeTrans.Contains("BUNGA TETAP / FLAT") || kodeTrans.Contains("FLT") || kodeTrans.Contains("FL") ))
                {
                    cmdReCalcAngs.Enabled = true;
                }
                else
                {
                    cmdReCalcAngs.Enabled = false;
                }
                if (GlobalVar.CabangID.Contains("06"))
                {
                    cmdRencanaUM.Enabled = true;
                }
                else
                {
                    cmdRencanaUM.Enabled = false;
                } 
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count > 0)
            {                
                _rowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {  
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();                    
                }

                if ((bool)Tools.isNull(dt.Rows[0]["cetak"], false) == true)
                {
                    if (_saldo > 0) // tadinya _saldo != 0
                    {
                        cmdADD.Enabled = true;
                        cmdTAMBAHUM.Enabled = false; 
                    }
                    else
                    {
                        cmdADD.Enabled = false;
                        cmdTAMBAHUM.Enabled = true; 
                    }
                    cmdDELETE.Enabled = false;
                    cmdPRINTKW.Enabled = true;
                    cmdTARIKAN.Enabled = false;
                }
                else
                {
                    if (_saldo > 0) // tadinya _saldo != 0
                    {
                        cmdADD.Enabled = true;
                        cmdTAMBAHUM.Enabled = false;
                        cmdTARIKAN.Enabled = true;
                    }
                    else
                    {
                        cmdADD.Enabled = false;
                        cmdTAMBAHUM.Enabled = true;
                        cmdTARIKAN.Enabled = false;
                    }
                    cmdDELETE.Enabled = true;
                    cmdPRINTKW.Enabled = true;                    
                }

                // cek dari data tanggal awal angsuran dengan hari ini
                // kalo hari ini udah melewati 1 bulan dari tanggal awal angsuran
               // if (((DateTime)GlobalVar.GetServerDate.Date).Date > Convert.ToDateTime(dataGridView1.SelectedCells[0].OwningRow.Cells["TglAwalAngs"].Value).Date.AddDays(DateTime.DaysInMonth(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month) - 1)) kalau di min 1 kayak gini ntar satu bulan kurang sehari sudah disabled
                if (((DateTime)GlobalVar.GetServerDate.Date).Date > Convert.ToDateTime(dataGridView1.SelectedCells[0].OwningRow.Cells["TglAwalAngs"].Value).Date.AddDays(DateTime.DaysInMonth(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month)))
                {
                    cmdTAMBAHUM.Enabled = false;
                }

                DisableTambahUMCheckTarikan();
                
                // kalo masih enabled cek ke journal
                if(cmdDELETE.Enabled == true)
                {
                    Guid penerimaanUangRowID = (Guid) Tools.isNull(dataGridView3.SelectedCells[0].OwningRow.Cells["PenerimaanUangRowID"].Value, Guid.Empty);
                    // cek data penerimaan angsurannya itu punya penerimaanrowid ngga 
                    if (penerimaanUangRowID == Guid.Empty || penerimaanUangRowID.ToString() == "" || penerimaanUangRowID == null)
                    {
                        // kalo kosong ya udah ga usah diapa2in
                    }
                    // kalo iya cek udah ada jurnal blom
                    else
                    {
                        // lakukan pengecekan kalo ada penerimaanUangRowID
                        using(Database db = new Database(GlobalVar.DBFinanceOto))
                        {
                            DataTable dummy = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_CheckJournalByPenerimaanUangRowID"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
                            dummy = db.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if(dummy.Rows.Count > 0)
                            {
                                cmdDELETE.Enabled = false;
                            }
                        }
                        
                    }
                }
                String kodeTrans = dataGridView1.SelectedCells[0].OwningRow.Cells["SistemAngs"].Value.ToString();
                if (GlobalVar.CabangID.Contains("06") && (kodeTrans.Contains("BUNGA TETAP / FLAT") || kodeTrans.Contains("FLT") || kodeTrans.Contains("FL")))
                {
                    cmdReCalcAngs.Enabled = true;
                }
                else
                {
                    cmdReCalcAngs.Enabled = false;
                }
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPenjualan;
            dataGridView1_SelectionChanged(sender, e);
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridUangMuka;
            dataGridView2_SelectionChanged(sender, e);
        }

        private void dataGridView3_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPelunasan;
            dataGridView3_SelectionChanged(sender, e);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshRowLunas(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridView3.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
            }
        }

        public void RefreshRowUM(Guid penjRowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_UangMuka_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridView2.DataSource = dtRefresh;
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridUangMuka) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                Penjualan.frmUangMukaUpdate ifrmChild = new Penjualan.frmUangMukaUpdate(this, _penjRowID, _custRowID, _penjHistRowID, _tglAwalAngs, "BayarUM");
                ifrmChild.ShowDialog();
            }
        }

        private void cmdTARIKAN_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridUangMuka) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                    if (FlagSource == "BARU")
                    {
                        // MessageBox.Show("Data BARU tidak dapat dilakukan penarikan!");
                        // bisa tarikan
                        Penjualan.frmUangMukaUpdate ifrmChild = new Penjualan.frmUangMukaUpdate(this, _penjRowID, _custRowID, _penjHistRowID, _tglAwalAngs, "Tarikan");
                        ifrmChild.ShowDialog();
                    }
                    else
                    {
                        Penjualan.frmUangMukaUpdate ifrmChild = new Penjualan.frmUangMukaUpdate(this, _penjRowID, _custRowID, _penjHistRowID, _tglAwalAngs, "Tarikan");
                        ifrmChild.ShowDialog();
                    }
                }
            }
        }

        private void cmdTAMBAHUM_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridUangMuka) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                Penjualan.frmUangMukaUpdate ifrmChild = new Penjualan.frmUangMukaUpdate(this, _penjRowID, _custRowID, _penjHistRowID, _tglAwalAngs, "TambahUM");
                ifrmChild.ShowDialog();
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            // kalau udah ada angsuran, ngga ada yg boleh dihapus bagian UM
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanAngsuran_CHECK_isPaid"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                if (dummy.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah ada pembayaran angsuran tidak diperbolehkan menghapus data!");
                    return;
                }
            }

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            try
            {
                if (selectedGrid == enumSelectedGrid.GridPelunasan)
                {
                    if (dataGridView3.SelectedCells.Count > 0)
                    {
                        if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool isOKTarikan = true;

                            _rowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                            String _kodeTrans = "";
                            Decimal _nominal = 0;
                            _kodeTrans = dataGridView3.SelectedCells[0].OwningRow.Cells["KodeTrans"].Value.ToString();

                            if (_kodeTrans == "UMT") // kalo uang muka tambahan ambil nominalnya untuk ngeupdate
                            {
                                _nominal = Convert.ToDecimal(dataGridView3.SelectedCells[0].OwningRow.Cells["Nominal"].Value.ToString());
                            }

                            if (_kodeTrans == "TRK") // kalo kode trans nya itu tarikan, cek apakah data tarikannya udah dilakukan penjualan
                            {
                                DataTable dummy = new DataTable();
                                using (Database dbsub = new Database(GlobalVar.DBShowroom))
                                {
                                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Pembelian_GET_Tarikan"));
                                    dbsub.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                    dummy = dbsub.Commands[0].ExecuteDataTable();
                                }
                                if (dummy.Rows.Count > 0)
                                {
                                    if ( String.IsNullOrEmpty( dummy.Rows[0]["Result"].ToString() ) )
                                    {
                                        // kalo data TglJual (Result) yg dikembalikan itu kosong/NULL, berarti boleh dihapus
                                    }
                                    else
                                    {
                                        // kalo ngga kosong, berarti itu berisi tanggal, ngga boleh dihapus
                                        isOKTarikan = false;
                                    }
                                }
                            }

                            if (CheckPrint(_rowID) == true)
                            {
                                MessageBox.Show("Sudah dilakukan cetak kwitansi, tidak diperkenankan menghapus data ini !");
                            }
                            else if (isOKTarikan == false)
                            {
                                MessageBox.Show("Data tarikan sudah digunakan untuk penjualan, tidak dapat dihapus !");
                            }
                            else
                            {
                                if (PenerimaanUang.checkDelete(_rowID, "PenerimaanUM") == true)
                                {
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusKwitansiUangMuka), "Hapus Pelunasan Uang Muka.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }

                                Database db = new Database();
                                int looper = 0, counterdb = 0;
                                try
                                {
                                    // kalo udah masuk sampe sini berarti emang udah boleh melakukan delete
                                    if (_kodeTrans == "TRK")
                                    {
                                        // lakukan revert data tarikan
                                        db.Commands.Add(db.CreateCommand("usp_RevertTarikan_Penjualan"));
                                        db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                        counterdb++;
                                    }

                                    if (_kodeTrans == "UMT") // kalo uang muka tambahan ambil nominalnya untuk ngeupdate
                                    {
                                        db.Commands.Add(db.CreateCommand("usp_Penjualan_Hist_UPDATE_TambahUM_DELETED"));
                                        db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistRowID));
                                        db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                        db.Commands[counterdb].Parameters.Add(new Parameter("@TambahanUM", SqlDbType.Money, _nominal));
                                        counterdb++;
                                    }

                                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_DELETE"));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    counterdb++;
                                
                                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipanIden_DELETE"));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.UM));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowIDTransaksi", SqlDbType.UniqueIdentifier, _rowID));
                                    counterdb++;

                                    db.BeginTransaction();
                                    for (looper = 0; looper < counterdb; looper++)
                                    {
                                        db.Commands[looper].ExecuteNonQuery();
                                    }
                                    db.CommitTransaction();
                                    dataGridView3.Rows.Remove(dataGridView3.SelectedCells[0].OwningRow);

                                    this.RefreshRowUM(_penjRowID);
                                    FindRowGrid2("mRowID", _penjRowID.ToString());
                                    MessageBox.Show("Data berhasil dihapus");

                                    frmReCalculateAngsuran ifrmChild = new frmReCalculateAngsuran(this, _penjRowID, _penjHistRowID);
                                    ifrmChild.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    db.RollbackTransaction();
                                    MessageBox.Show("Error terjadi, DELETE dibatalkan \n" + ex.Message);
                                }
                            }
                        }
                    }
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

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGrid == enumSelectedGrid.GridPelunasan)
                {
                    if (dataGridView3.SelectedCells.Count > 0)
                    {
                        Guid rowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                        Guid penjRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                        // apakah print um untuk kwitansi bayar um pertama?
                        bool isFirst = false;
                        Guid firstRowID = Guid.Empty;

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_Check_First"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, penjRowID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                firstRowID = new Guid(dt.Rows[0]["RowID"].ToString());
                                if (firstRowID != Guid.Empty && rowID != Guid.Empty
                                    && firstRowID != null && rowID != null)
                                {
                                    if (firstRowID == rowID)
                                    {
                                        isFirst = true;
                                    }
                                }
                            }
                        }
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
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_PenerimaanUM"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            dt = db.Commands[0].ExecuteDataTable();
                            List<ReportParameter> rptParams = new List<ReportParameter>();

                            string kdtran = Tools.isNull(dt.Rows[0]["KodeTrans"].ToString(), "").ToString();

                            int JamBebasPIN = 0;
                            DataTable dummyPIN = new DataTable();
                            using (Database dbsubPIN = new Database())
                            {
                                dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                                dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                                dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                                JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                            }

                            DateTime LastPrintedOn;
                            LastPrintedOn = (DateTime) Tools.isNull(dt.Rows[0]["LastPrintedOn"], DateTime.MaxValue);
                            if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                            {
                            }
                            else
                            {
                                if ((bool)dt.Rows[0]["Cetak"] == true)
                                {
                                    // sebelumnya PinId.Bagian.Keuangan
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }
                            }

                            _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                            int angka = int.Parse(Tools.isNull(dt.Rows[0]["Nominal"], "0").ToString(), NumberStyles.Currency) + int.Parse(Tools.isNull(dt.Rows[0]["NominalPembulatan"], "0").ToString(), NumberStyles.Currency);
                            _terbilang = Tools.Terbilang(angka) + "RUPIAH";
                            _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();

                            _kota = _kota.Replace("Kota ", "");
                            _kota = _kota.Replace("Kabupaten ", "");

                            DateTime tglBayar;
                            tglBayar = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"].ToString(), GlobalVar.GetServerDate).ToString());
                            // _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                            _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                            if ((bool)dt.Rows[0]["Cetak"] == true)
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

                            if (kdtran == "TRK")
                            {
                                rptParams.Add(new ReportParameter("JnsKw", "Tarikan"));
                            }
                            else
                            {
                                rptParams.Add(new ReportParameter("JnsKw", "Uang Muka"));
                            }
                            rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                            rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                            rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                            rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                            rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                            // tambahan untuk kwitansi
                            rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                            
                            if (isFirst == true)
                            {
                                rptParams.Add(new ReportParameter("Tipe", "FIRST"));
                            }
                            else
                            {
                                rptParams.Add(new ReportParameter("Tipe", "UM"));
                            }

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
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

            LoadPenjualan();
        }

        private bool CheckPrint(Guid rowID)
        {
            bool _cetak = false;
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    _cetak = (bool)Tools.isNull(dt.Rows[0]["Cetak"], false);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return _cetak;
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

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dataGridView3.Rows)
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

        private void cmdReCalcAngs_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView2.SelectedCells.Count > 0)
            {
                //cek bulannya, kalau beda bulan jangan dibolehin batal 
                string MonthServer = GlobalVar.GetServerDate.Month.ToString();
                string YearServer = GlobalVar.GetServerDate.Year.ToString();
                DateTime tanggalAngsBat = Convert.ToDateTime(dataGridView1.SelectedCells[0].OwningRow.Cells["TglJual"].Value.ToString());
                string MonthBatal = tanggalAngsBat.Month.ToString();
                string YearBatal = tanggalAngsBat.Year.ToString();
                if (MonthBatal != MonthServer)
                {
                    //MessageBox.Show("Sudah beda bulan, Anda tidak diperkenankan Recalculate Angsuran penjualan ini...");
                    //return;
                }
                else if (YearBatal != YearServer)
                {
                    MessageBox.Show("Sudah ganti tahun, Anda tidak diperkenankan Recalculate Angsuran penjualan ini...");
                    return;
                }



                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                if (PenerimaanUang.checkDelete(_rowID, "PenerimaanUM") == true)
                {
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.RecalculateAngsuranTLA), "Untuk melakukan perhitungan ulang Angsuran, perlu PIN persetujuan!");
                    if (GlobalVar.pinResult == false) { return; }
                }

                frmReCalculateAngsuran ifrmChild = new frmReCalculateAngsuran(this, _penjRowID, _penjHistRowID);
                ifrmChild.ShowDialog();
                this.RefreshRowUM(_penjRowID);
                FindRowGrid2("mRowID", _penjRowID.ToString());
            }
        }

        private void cmdRencanaUM_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridUangMuka) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (_penjRowID != Guid.Empty && _penjRowID != null && GlobalVar.CabangID.Contains("06"))
                {
                    Penjualan.frmRencanaUMBrowse ifrmChild = new Penjualan.frmRencanaUMBrowse(this, _penjRowID);
                    ifrmChild.ShowDialog();
                }
            }
        }
    }
}
