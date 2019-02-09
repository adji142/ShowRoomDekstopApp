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
    public partial class frmAdministrasiBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridPenjualan, GridAdministrasi, GridPelunasan };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridPenjualan;

        DateTime _fromDate, _toDate;
        double _saldo;
        Guid _penjRowID, _rowID, _custRowID, _penjHistRowID;
        String _cabangID = GlobalVar.CabangID;

        public frmAdministrasiBrowse()
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
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                cmdADD.Enabled = false;
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

        private void LoadAdministrasi()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    _penjRowID = (Guid) Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty);
                    _custRowID = (Guid) Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["CustRowId"].Value, Guid.Empty);
                    _penjHistRowID = (Guid) Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PenjHistRowID"].Value, Guid.Empty);
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_BiayaAdministrasi_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
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
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
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

                        db.Commands.Add(db.CreateCommand("usp_DaftarTitipanSudahIden_ADM"));
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

        private void frmAdministrasiBrowse_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(-6);// minta from nya itu - 6 bulan ke belakang
            _toDate = GlobalVar.GetServerDate; 

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;

            gvTitipanGiro.AutoGenerateColumns = false; 

            LoadPenjualan();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LoadAdministrasi();
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

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Guid _penjRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                if (_saldo > 0) { cmdADD.Enabled = true; }   // tadinya _saldo != 0
                else { cmdADD.Enabled = false; }
                LoadPembayaran();
                LoadTitipanIden();
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
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if ((bool)Tools.isNull(dt.Rows[0]["cetak"], false) == true)
                {
                    if (_saldo > 0) { cmdADD.Enabled = true; } // tadinya _saldo != 0
                    else { cmdADD.Enabled = false; }
                    cmdDELETE.Enabled = false;
                    cmdPRINTKW.Enabled = true;
                }
                else
                {
                    if (_saldo > 0) { cmdADD.Enabled = true; }
                    else { cmdADD.Enabled = false; } 
                    cmdDELETE.Enabled = true;
                    cmdPRINTKW.Enabled = true;
                }

                // kalo masih enabled cek ke journal
                if(cmdDELETE.Enabled == true)
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
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPenjualan;
            dataGridView1_SelectionChanged(sender, e);
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridAdministrasi;
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
                db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridView3.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
            }
        }

        public void RefreshRowADM(Guid penjRowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_BiayaAdministrasi_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridView2.DataSource = dtRefresh;
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if ((selectedGrid == enumSelectedGrid.GridAdministrasi) || (selectedGrid == enumSelectedGrid.GridPelunasan))
            {
                Penjualan.frmAdministrasiUpdate ifrmChild = new Penjualan.frmAdministrasiUpdate(this, _penjRowID, _custRowID, _penjHistRowID);
                ifrmChild.ShowDialog();
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
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _rowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["dRowID"].Value;


                        if (CheckPrint(_rowID) == true)
                        {
                            MessageBox.Show("Sudah dilakukan cetak kwitansi, tidak diperkenankan menghapus data ini !");
                        }
                        else
                        {
                            if (PenerimaanUang.checkDelete(_rowID, "PenerimaanADM") == true)
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusKwitansiAdministrasi), "Hapus Pelunasan Administrasi.\n Sudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipanIden_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int) Class.enumTipeTitipan.Adm ));
                                db.Commands[0].Parameters.Add(new Parameter("@RowIDTransaksi", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].ExecuteNonQuery();
                            }

                            dataGridView3.Rows.Remove(dataGridView3.SelectedCells[0].OwningRow);
                            this.RefreshRowADM(_penjRowID);
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
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_PenerimaanADM"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
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
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
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

                            // nominal di paling atas yg Administrasi
                            rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["Nominal"]).ToString()));
                            rptParams.Add(new ReportParameter("JnsKw", "Biaya Administrasi"));
                            rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                            rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                            rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                            rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                            rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                            // tambahan untuk kwitansi
                            rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                            rptParams.Add(new ReportParameter("Tipe", "ADM")); 

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
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_LIST"));
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
