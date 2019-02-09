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
using ISA.Showroom.DataTemplates;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPelunasanBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridPenjualan, GridPiutang, GridPelunasan };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridPenjualan;

        DateTime _fromDate, _toDate;
        double _saldo;
        String _kodeTrans;
        String _kodeTransPJL;
        Guid _penjRowID, _rowID;
        String _cabangID = GlobalVar.CabangID;

        public frmPelunasanBrowse()
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
                    db.Commands.Add(db.CreateCommand("usp_PenjualanTunai_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                cmdADD.Enabled = false;
                cmdDELETE.Enabled = false;
                cmdPRINTKW.Enabled = false;
                cmdBABPKB.Enabled = false;
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

        private void LoadPiutang()
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
                        db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
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

        private void LoadPembayaran()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                try
                {
                    _penjRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                    string _kodeTrans = dataGridView2.SelectedCells[0].OwningRow.Cells["mKodeTrans"].Value.ToString();

                    if (GlobalVar.CabangID.Contains("06") && (_kodeTrans == "CTP" || _kodeTrans == "SBD"))
                    {
                        cmdRencanaUM.Enabled = true;
                    }
                    else
                    {
                        cmdRencanaUM.Enabled = false;
                    }

                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridView3.DataSource = dt;
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

        private void frmPelunasanBrowse_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(-6); // dikurang 6 bulan
            _toDate = GlobalVar.GetServerDate;

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            LoadPenjualan();
            cmdTambahUM.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                _kodeTransPJL = dataGridView1.SelectedCells[0].OwningRow.Cells["SistemAngs"].Value.ToString();
                LoadPiutang();
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
                cmdTambahUM.Enabled = false;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Guid _penjRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                _kodeTrans = dataGridView2.SelectedCells[0].OwningRow.Cells["mKodeTrans"].Value.ToString();
                
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                if (_saldo > 0) { cmdADD.Enabled = true; cmdTARIKAN.Enabled = true; cmdBABPKB.Enabled = false; } // tadinya _saldo != 0
                else { cmdADD.Enabled = false; cmdTARIKAN.Enabled = false; cmdBABPKB.Enabled = true; }

                if (_kodeTransPJL == "LEASING" && (_kodeTrans == "SBD" || _kodeTrans == "UMK") && _penjRowID != Guid.Empty && _penjRowID != null && GlobalVar.CabangID.Contains("06"))
                {
                    cmdTambahUM.Enabled = true;
                }
                else
                {
                    cmdTambahUM.Enabled = false;
                }

                if (_kodeTransPJL == "LEASING" && _kodeTrans == "SBD" && _penjRowID != Guid.Empty && _penjRowID != null && GlobalVar.CabangID.Contains("06"))
                {
                    cmdRencanaUM.Text = "VIEW DETIL SUBSIDI";
                    cmdRencanaUM.Enabled = true;
                }
                else if (_kodeTransPJL == "LEASING" && _kodeTrans == "UMK" && _penjRowID != Guid.Empty && _penjRowID != null && GlobalVar.CabangID.Contains("06"))
                {
                    cmdRencanaUM.Text = "VIEW RENCANA UM";
                    cmdRencanaUM.Enabled = true;
                }
                else
                {
                    cmdRencanaUM.Enabled = false;
                }

                LoadPembayaran();

                if (_kodeTransPJL == "LEASING" && (_kodeTrans == "SBD" || _kodeTrans == "LSG" ))
                {
                    cmdADD.Enabled = false;
                    cmdTARIKAN.Enabled = false;
                }

            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
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
                    if (_saldo > 0) { cmdADD.Enabled = true; cmdTARIKAN.Enabled = true; cmdBABPKB.Enabled = false; } // tadinya _saldo != 0
                    else { cmdADD.Enabled = false; cmdTARIKAN.Enabled = false; cmdBABPKB.Enabled = true; } 
                    cmdDELETE.Enabled = false;
                    cmdPRINTKW.Enabled = true;
                }
                else
                {
                    if (_saldo > 0) { cmdADD.Enabled = true; cmdTARIKAN.Enabled = true; cmdBABPKB.Enabled = false; } // tadinya _saldo != 0
                    else { cmdADD.Enabled = false; cmdTARIKAN.Enabled = false; cmdBABPKB.Enabled = true; }
                    cmdDELETE.Enabled = true;
                    cmdPRINTKW.Enabled = true;
                }

                // kalo masih enabled cek ke journal
                if (cmdDELETE.Enabled == true)
                {
                    Guid penerimaanUangRowID = (Guid)Tools.isNull(dataGridView3.SelectedCells[0].OwningRow.Cells["PenerimaanUangRowID"].Value, Guid.Empty);
                    // cek data penerimaan angsurannya itu punya penerimaanrowid ngga 
                    if (penerimaanUangRowID == Guid.Empty || penerimaanUangRowID.ToString() == "" || penerimaanUangRowID == null)
                    {
                        // kalo kosong ya udah ga usah diapa2in
                    }
                    // kalo iya cek udah ada jurnal blom
                    else
                    {
                        // lakukan pengecekan kalo ada penerimaanUangRowID
                        using (Database db = new Database(GlobalVar.DBFinanceOto))
                        {
                            DataTable dummy = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_CheckJournalByPenerimaanUangRowID"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
                            dummy = db.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if (dummy.Rows.Count > 0)
                            {
                                cmdDELETE.Enabled = false;
                            }
                        }

                        // cek lagi, kalau ada denda, dan dendanya itu udah masuk jurnal, ngga boleh juga
                        using (Database db = new Database(GlobalVar.DBShowroom))
                        {
                            DataTable dummy = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_CheckJurnalDenda"));
                            db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "Pelunasan"));
                            dummy = db.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if (dummy.Rows.Count > 0)
                            {
                                cmdDELETE.Enabled = false;
                            }
                        }

                    }
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
            selectedGrid = enumSelectedGrid.GridPiutang;
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

        public void RefreshRowPiutang(Guid penjRowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST"));
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
            if ((selectedGrid == enumSelectedGrid.GridPiutang) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (_kodeTrans == "SBD")
                {
                    Penjualan.frmUMSubsidiUpdate ifrmChild = new Penjualan.frmUMSubsidiUpdate(this, _penjRowID, _kodeTrans);
                    ifrmChild.ShowDialog();
                }
                else
                {
                    Penjualan.frmPelunasanUpdate ifrmChild = new Penjualan.frmPelunasanUpdate(this, _penjRowID, _kodeTrans, "Pelunasan");
                    ifrmChild.ShowDialog();
                }
            }
        }

        private void cmdTARIKAN_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridPiutang) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    String FlagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value, "ORI").ToString();
                    if (FlagSource == "BARU")
                    {
                        // MessageBox.Show("Data BARU tidak dapat dilakukan penarikan!");
                        // bisa tarikan
                        Penjualan.frmPelunasanUpdate ifrmChild = new Penjualan.frmPelunasanUpdate(this, _penjRowID, _kodeTrans, "Tarikan");
                        ifrmChild.ShowDialog();
                    }
                    else
                    {
                        Penjualan.frmPelunasanUpdate ifrmChild = new Penjualan.frmPelunasanUpdate(this, _penjRowID, _kodeTrans, "Tarikan");
                        ifrmChild.ShowDialog();
                    }
                }
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            
            if (selectedGrid == enumSelectedGrid.GridPelunasan)
            {
                if (dataGridView3.SelectedCells.Count > 0)
                {
                    DateTime tanggalAngsBat = Convert.ToDateTime(dataGridView3.SelectedCells[0].OwningRow.Cells["Tanggal"].Value.ToString());
                    
                    if (tanggalAngsBat > GlobalVar.GetServerDate.Date.AddDays(0))
                    {
                        MessageBox.Show("Anda tidak diperkenankan menghapus data kemarin");
                        return;
                    }
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool isOKTarikan = true;

                        String DetilKodeTrans;
                        string _BentukPembayaran = "";

                        DetilKodeTrans = dataGridView3.SelectedCells[0].OwningRow.Cells["KodeTrans"].Value.ToString();
                        _rowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                        _BentukPembayaran = dataGridView3.SelectedCells[0].OwningRow.Cells["BentukPembayaran"].Value.ToString();

                        if (DetilKodeTrans == "UMP")
                        {
                            MessageBox.Show("Tidak dapat menghapus data ini!");
                            return;
                        }

                        if (DetilKodeTrans == "TRK") // kalo kode trans nya itu tarikan, cek apakah data tarikannya udah dilakukan penjualan
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
                                if (String.IsNullOrEmpty(dummy.Rows[0]["Result"].ToString()))
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
                        else if( isOKTarikan == false)
                        {
                            MessageBox.Show("Data tarikan sudah digunakan untuk penjualan, tidak dapat dihapus !");
                        }
                        else
                        {   // pake cekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(_rowID, "PenerimaanUM") == true) // this.ceckDelete(_rowID) == true -> ke PenerimaanUM
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusKwitansiPelunasan), "Hapus Pelunasan Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
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

                                db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_DELETE"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                counterdb++;

                                if (_BentukPembayaran.ToLower() == "titipan")
                                {
                                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_PelunasanDELETE"));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _rowID));
                                    counterdb++;

                                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipanIden_DELETE"));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowIDTransaksi", SqlDbType.UniqueIdentifier, _rowID));
                                    db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.Int, 1));
                                    counterdb++;
                                }


                                db.BeginTransaction();
                                for (looper = 0; looper < counterdb; looper++)
                                {
                                    db.Commands[looper].ExecuteNonQuery();
                                }
                                db.CommitTransaction();
                            }
                            catch (Exception ex)
                            {
                                db.RollbackTransaction();
                                MessageBox.Show("Error terjadi, DELETE dibatalkan \n" + ex.Message);
                            }

                            dataGridView3.Rows.Remove(dataGridView3.SelectedCells[0].OwningRow);
                            LoadPiutang();
                            this.RefreshRowPiutang(_penjRowID);
                            this.FindRowGrid2("mRowID", _penjRowID.ToString());
                            MessageBox.Show("Data berhasil dihapus");
                        }
                    }
                }
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
                        String kodeTrn = dataGridView3.SelectedCells[0].OwningRow.Cells["KodeTrans"].Value.ToString();

                        if (kodeTrn.Contains("UMP") || kodeTrn.Contains("SBP"))
                        {
                            MessageBox.Show("Tidak dapat membuat kwitansi untuk transaksi ini!");
                            return;
                        }

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
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_Pelunasan"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            dt = db.Commands[0].ExecuteDataTable();
                            List<ReportParameter> rptParams = new List<ReportParameter>();

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

                            switch (dt.Rows[0]["KodeTrans"].ToString())
                            {
                                case "TUN":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran Tunai"));
                                    break;
                                case "CTP":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran Secara Tempo (Cash Tempo)"));
                                    break;
                                case "LSG":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran Pokok Leasing"));
                                    break;
                                case "UMK":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran DP Leasing"));
                                    break;
                                case "UMT":
                                    rptParams.Add(new ReportParameter("JnsKw", "Penambahan DP Leasing"));
                                    break;
                                case "UMP":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pengembalian DP Leasing"));
                                    break;
                                case "SBD":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran DP Subsidi Leasing"));
                                    break;
                                case "SBT":
                                    rptParams.Add(new ReportParameter("JnsKw", "Penambahan DP Subsidi Leasing"));
                                    break;
                                case "SBP":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pengurangan DP Subsidi Leasing"));
                                    break;
                                case "BKS":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran Tunai"));
                                    break;
                                case "IDN":
                                    rptParams.Add(new ReportParameter("JnsKw", "Pembayaran Tunai Iden"));
                                    break;
                            }

                            if (kodeTrn.Contains("UMP"))
                            {
                                rptParams.Add(new ReportParameter("TipeKw", "DEBIT NOTE"));
                            }
                            else
                            {
                                rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                            }

                            // nominal di paling atas yg Pelunasan
                            rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["Nominal"]).ToString()));

                            rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                            rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                            rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                            rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                            // tambahan untuk kwitansi
                            rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                            if (isFirst == true || _kodeTrans == "TUN")
                            {
                                rptParams.Add(new ReportParameter("Tipe", "FIRST"));
                            }
                            else
                            {
                                rptParams.Add(new ReportParameter("Tipe", "PLS"));
                            }

                            if (Convert.ToDouble(dt.Rows[0]["NominalTitip"])==0)
                            {
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
                            }
                            else
                            {
                                rptParams.Add(new ReportParameter("KetTitipan", "Pembayaran Titipan"));
                                rptParams.Add(new ReportParameter("NominalTitip", Convert.ToDouble(dt.Rows[0]["NominalTitip"]).ToString()));

                                if ((_nprint == 0) || (_nprint == 1))
                                {
                                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiTitipan.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                    ifrmReport.Print();
                                }
                                if ((_nprint == 0) || (_nprint == 2))
                                {
                                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiTitipanCopy1.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                    ifrmReport.Print();
                                }
                                if ((_nprint == 0) || (_nprint == 3))
                                {
                                    frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiTitipanCopy2.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                    ifrmReport.Print();
                                }
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
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar, "PenerimaanUM"));
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
        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void cmdBABPKB_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value; // grid1 itu data penjualan

                    // pas mau print ba bpkb ini perlu cek data denda mesti lunas baru boleh cetak
                    DataTable dtdummy = new DataTable();
                    using (Database dbsub = new Database())
                    {
                        dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanDendaxPenerimaanUMBunga_CheckSaldo"));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, rowID));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                        dtdummy = dbsub.Commands[0].ExecuteDataTable();
                    }
                    if (dtdummy.Rows.Count > 0)
                    {
                        Double BayarDenda = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["DendaSumBayar"], 0).ToString());
                        Double BayarUMBunga = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["UMBungaSumBayar"], 0).ToString());
                        Double TotalDenda = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["DendaSum"], 0).ToString());
                        Double TotalUMBunga = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["UMbungaSum"], 0).ToString());

                        if (BayarDenda < TotalDenda)
                        {
                            MessageBox.Show("Ada nominal Denda yang masih belum dibayarkan, mohon diurus terlebih dahulu sebelum melakukan proses ini!");
                            return;
                        }
                    }

                    bool pass = false;
                    if(GlobalVar.CabangID.Contains("06"))
                    {
                        Penjualan.frmBABPKB_TLA ifrmChild = new Penjualan.frmBABPKB_TLA(this, rowID);
                        ifrmChild.ShowDialog();
                        string result = ifrmChild.result;
                        if (result == "print") // ini berarti mau print
                        {
                            pass = true;
                        }
                    }
                    else
                    {
                        pass = true;
                    }

                    if(pass)
                    {
                            string _bulan;
                            string _tanggal;
                            string _tahun;
                            string _hari;
                            string _copy;

                            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                            DateTime date = GlobalVar.GetServerDate;
                            Calendar cal = dfi.Calendar;
                            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("rpt_BABPKB_Penjualan"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                                dt = db.Commands[0].ExecuteDataTable();
                                db.Commands[0].Parameters.Clear();
                                List<ReportParameter> rptParams = new List<ReportParameter>();

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
                                LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintBABPKBOn"], DateTime.MaxValue);
                                if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                                {
                                }
                                else
                                {
                                    if (Tools.isNull(dt.Rows[0]["PrintBABPKB"], "").ToString().Trim() == "")
                                    {
                                        MessageBox.Show("Data tidak Valid untuk jumlah kali pencetakan BABPKB!");
                                    }
                                    else if ((int)dt.Rows[0]["PrintBABPKB"] > 1)
                                    {
                                        // sebelumnya PinId.Bagian.Keuangan
                                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PrintBABPKBPenjualan), "Sudah dilakukan cetak BABPKB !");
                                        if (GlobalVar.pinResult == false) { return; }
                                    }
                                }

                                _tanggal = GlobalVar.GetServerDate.Day.ToString();
                                _bulan = Tools.BulanPanjang(GlobalVar.GetServerDate.Month);
                                _tahun = GlobalVar.GetServerDate.Year.ToString();
                                _hari = Tools.HariPanjang(GlobalVar.GetServerDate);

                                rptParams.Add(new ReportParameter("Date", GlobalVar.GetServerDate.ToString("yyyy-MM-dd")));
                                rptParams.Add(new ReportParameter("PrintBy", SecurityManager.UserID.ToString()));
                                rptParams.Add(new ReportParameter("Now", GlobalVar.GetServerDate.ToString()));
                                                                
                                db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_CounterBABPKB"));
                                db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[1].Parameters.Add(new Parameter("@LastPrintedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[1].ExecuteNonQuery();

                                frmReportViewer ifrmReport1 = new frmReportViewer("Penjualan.rptBABPKB.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport1.Print();

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

        private void cmdRencanaUM_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridPiutang) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if (_penjRowID != Guid.Empty && _penjRowID != null && GlobalVar.CabangID.Contains("06"))
                {
                    if (cmdRencanaUM.Text == "VIEW RENCANA UM")
                    {
                        Penjualan.frmRencanaUMBrowse ifrmChild = new Penjualan.frmRencanaUMBrowse(this, _penjRowID);
                        ifrmChild.ShowDialog();
                    }
                    else if (cmdRencanaUM.Text == "VIEW DETIL SUBSIDI")
                    {
                        Penjualan.frmDPSubsidiBrowse ifrmChild = new Penjualan.frmDPSubsidiBrowse(this, _penjRowID);
                        ifrmChild.ShowDialog();
                    }
                }
            }
        }

        private void cmdTambahUM_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridPiutang) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                if ((_kodeTrans == "SBD" || _kodeTrans == "UMK") && _penjRowID != Guid.Empty && _penjRowID != null && GlobalVar.CabangID.Contains("06"))
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        // pas mau print ba bpkb ini perlu cek data denda mesti lunas baru boleh cetak
                        DataTable dtdummy = new DataTable();
                        using (Database dbsub = new Database())
                        {
                            dbsub.Commands.Add(dbsub.CreateCommand("usp_Pelunasan_isPokokLunas"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                            dtdummy = dbsub.Commands[0].ExecuteDataTable();
                        }
                        if (dtdummy.Rows.Count > 0)
                        {
                            Double tempSaldo = Convert.ToDouble(Tools.isNull(dtdummy.Rows[0]["Saldo"], 0).ToString());
                            if (tempSaldo > 0)
                            {
                                Penjualan.frmPelunasanTambahUM ifrmChild = new Penjualan.frmPelunasanTambahUM(this, _penjRowID, _kodeTrans);
                                ifrmChild.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Pokok sudah dilunasi tidak dapat melakukan penambahan UM/Subsidi!");
                                return;
                            }
                        }
                        else
                        {
                            Penjualan.frmPelunasanTambahUM ifrmChild = new Penjualan.frmPelunasanTambahUM(this, _penjRowID, _kodeTrans);
                            ifrmChild.ShowDialog();
                        }
                    }
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
