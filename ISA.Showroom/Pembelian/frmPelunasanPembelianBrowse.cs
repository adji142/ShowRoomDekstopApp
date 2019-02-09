using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using ISA.Showroom.Class;
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Showroom.Pembelian
{
    public partial class frmPelunasanPembelianBrowse : BaseForm
    {
        enum enumSelectedGrid { GridPembelian, GridSaldo, GridPelunasan };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridPembelian;

        DateTime _fromDate, _toDate;
        String _jnsPembelian = "";
        double _sisaUM, _sisaBayar;
        Guid _pembRowID, _rowID;
        string _cabangID = GlobalVar.CabangID;
        String _flagSource = "ORI";

        public frmPelunasanPembelianBrowse()
        {
            InitializeComponent();
        }

        public void LoadPembelian()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    DataColumn cConcatenated1 = new DataColumn("MerkType", Type.GetType("System.String"), "MerkMotor + ' / ' + TypeMotor");
                    dt.Columns.Add(cConcatenated1);
                    dataGridView1.DataSource = dt;
                }
                if (GlobalVar.CabangID.Contains("06A"))
                {
                    dataGridView1.Columns[3].Visible = true;
                }
                else
                {
                    dataGridView1.Columns[3].Visible = false;
                }

                cmdADD.Enabled = false;
                cmdDELETE.Enabled = false;
                cmdPRINTKW.Enabled = false;
                cmdPRINTHD.Enabled = false;
                LoadSaldo();
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

        private void LoadSaldo()
        {
            DataTable dt = new DataTable();
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    _pembRowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Pembelian_SALDO"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _pembRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    dataGridView2.DataSource = dt;
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
            DataTable dt = new DataTable();
            if (dataGridView2.SelectedCells.Count > 0)
            {
                try
                {
                    _pembRowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _pembRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    dataGridView3.DataSource = dt;
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

        private void frmPelunasanPembelianBrowse_Load(object sender, EventArgs e)
        {
            if (GlobalVar.CabangID.ToUpper() == "06B" || GlobalVar.CabangID.ToUpper() == "06C" || GlobalVar.CabangID.ToUpper() == "06D" || GlobalVar.CabangID.ToUpper() == "06E")
            {
                _fromDate = new DateTime(2000, 1, 1);
                _toDate = GlobalVar.GetServerDate;
                
                rdtTanggal.FromDate = _fromDate;
                rdtTanggal.ToDate = _toDate;
            }
            else
            {
                _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                _toDate = GlobalVar.GetServerDate;

                rdtTanggal.FromDate = _fromDate;
                rdtTanggal.ToDate = _toDate;
                LoadPembelian();
            }
            if (GlobalVar.CabangID.Contains("06A"))
            {
                dataGridView1.Columns[3].Visible = true;
            }
            else
            {
                dataGridView1.Columns[3].Visible = false;
            }

            cmdPotonganPembelian.Enabled = false;
            if (GlobalVar.CabangID.ToUpper() == "06A")
            {
                cmdADD.Enabled = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                _jnsPembelian = dataGridView1.SelectedCells[0].OwningRow.Cells["Pembelian"].Value.ToString();

                String _flagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value.ToString(), "ORI").ToString();
                if (_flagSource == "BARU")
                {
                    cmdPotonganPembelian.Enabled = true;
                }
                else if (_flagSource == "ORI")
                {
                    cmdPotonganPembelian.Enabled = false;
                }
                this.LoadSaldo();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["mRowID"].Value;

                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_SALDO"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    _sisaUM = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaUM"], 0));
                    _sisaBayar = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaBayar"], 0));
                }

                if ((_sisaUM > 0) && (_sisaBayar > 0))
                {
                    cmdADD.Enabled = true;                    
                }
                else if ((_sisaUM == 0) && (_sisaBayar > 0))
                {
                    cmdADD.Enabled = true;
                }
                else if ((_sisaUM > 0) && (_sisaBayar == 0))
                {
                    cmdADD.Enabled = true;
                }
                else if ((_sisaUM == 0) && (_sisaBayar == 0))
                {
                    if (_flagSource == "ORI")
                    {
                        cmdADD.Enabled = true;
                    }
                    else
                    {
                        cmdADD.Enabled = false;
                    }
                }
                LoadPembayaran();
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
            {
                cmdDELETE.Enabled = true;
                cmdPRINTKW.Enabled = true;
                cmdPRINTHD.Enabled = true;

                if (cmdDELETE.Enabled ==  true)
                {
                    Guid _pembayaranPembRowID = Guid.Empty;                           
                    _pembayaranPembRowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["PelRowID"].Value;

                    Database dbsub = new Database();
                    DataTable dtsub = new DataTable();
                    using(dbsub)
                    {
                        dbsub.Commands.Add(dbsub.CreateCommand("usp_Link_Check_PembayaranPembxPengeluaranUangxJournal"));
                        dbsub.Commands[0].Parameters.Add( new Parameter("@RowID", SqlDbType.UniqueIdentifier, _pembayaranPembRowID));
                        dtsub = dbsub.Commands[0].ExecuteDataTable();
                    }
                    // di sini baru cek 
                    if(dtsub.Rows.Count > 0) // kalo ada isi ini datatable berarti di jurnal udah ada data, ngga boleh diapus
                    {
                        cmdDELETE.Enabled = false;
                    }
                }
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPembelian;
            dataGridView1_SelectionChanged(sender, e);
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridSaldo;
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

        public void RefreshRow(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridView3.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedCells.Count > 0)
            { 
                //validasi, kalau udah laku ga boleh tambah biaya reparasi/tambahan heri
                //if (GlobalVar.CabangID.Contains("13"))
                //{
                //}
                //else 
                //{
                //    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                //    DataTable dtCekJual = new DataTable(); //cek udah terjual belum, Heri
                //    using (Database db = new Database())
                //    {
                //        db.Commands.Add(db.CreateCommand("usp_Pembelian_CekJual_ADDBYPLUS"));
                //        db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                //        dtCekJual = db.Commands[0].ExecuteDataTable();
                //    }
                //    if (dtCekJual.Rows.Count > 0)
                //    {
                //        MessageBox.Show("Motor sudah terjual, tidak diperkenankan menambah BIAYA REPARASI/TAMBAHAN..");
                //        return;
                //    }
                //}               
                    Pembelian.frmPelunasanPembelianUpdate ifrmChild = new Pembelian.frmPelunasanPembelianUpdate(this, _pembRowID, _jnsPembelian.ToUpper());
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
                        _rowID = (Guid)dataGridView3.SelectedCells[0].OwningRow.Cells["PelRowID"].Value;
                        // pake CekDelete punya Pak Novi
                        if (Class.PenerimaanUang.checkDelete(_rowID, "PembayaranPemb") == true) // this.ceckDelete(_rowID) == true -> ke PembayaranPemb
                        {
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusKwitansiPembelian), "Hapus Pelunasan Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                            if (GlobalVar.pinResult == false) { return; }
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        dataGridView3.Rows.Remove(dataGridView3.SelectedCells[0].OwningRow);
                        MessageBox.Show("Data berhasil dihapus");
                        LoadPembelian();
                        LoadSaldo();
                        LoadPembayaran();
                    }
                }
            }
        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.SelectedCells.Count > 0)
                {
                    string NoTrans = dataGridView3.SelectedCells[0].OwningRow.Cells["NoTrans"].Value.ToString();
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
                        db.Commands.Add(db.CreateCommand("rpt_Kwitansi_Pembelian"));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTrans));
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
                        LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn"], DateTime.MaxValue);
                        if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                        {
                        }
                        else
                        {
                            if ((bool)dt.Rows[0]["Cetak"] == true)
                            {
                                // PinId.Bagian.Keuangan
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.KwitansiPembelian), "Sudah dilakukan cetak Kwitansi Pembelian !");
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }
                        _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                        _terbilang = Tools.Terbilang(int.Parse(dt.Rows[0]["Total"].ToString(), NumberStyles.Currency)) + "RUPIAH";
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

      
                        rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                        rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                        rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                        rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()
                        if ((_nprint == 0) || (_nprint == 1))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptKwitansi.rdlc", rptParams, dt, "dsPembelian_Kwitansi");
                            ifrmReport.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 2))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptKwitansiCopy1.rdlc", rptParams, dt, "dsPembelian_Kwitansi");
                            ifrmReport.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 3))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptKwitansiCopy2.rdlc", rptParams, dt, "dsPembelian_Kwitansi");
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
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cmdPRINTHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGrid == enumSelectedGrid.GridPembelian)
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        string _edp;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("rpt_Kartu_Hutang_Dagang"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            dt = db.Commands[0].ExecuteDataTable();
                            List<ReportParameter> rptParams = new List<ReportParameter>();

                            _edp = String.Format("{0:d/MM/yyyy}", GlobalVar.GetServerDate);

                            rptParams.Add(new ReportParameter("Judul", "KARTU HUTANG DAGANG".ToString()));
                            rptParams.Add(new ReportParameter("EDP", _edp));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()
                            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptHutangDagang.rdlc", rptParams, dt, "dsPembelian_Kartu_Hutang_Dagang");
                            ifrmReport.Print();
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
        private void btnCari_Click(object sender, EventArgs e)
        {
            _fromDate = rdtTanggal.FromDate.Value;
            _toDate = rdtTanggal.ToDate.Value;

            LoadPembelian();
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
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar , "PembayaranPemb"));
                object objRecordCreatedOn = db.Commands[0].ExecuteScalar();   
                if(objRecordCreatedOn != DBNull.Value) 
                {
                    dateRecordCreatedOn = Convert.ToDateTime(objRecordCreatedOn); 
                }
                
            }

            if (dateRecordCreatedOn.Date == GlobalVar.GetServerDate.Date) hapus = false;
            else hapus = true;

            return hapus;
        }
        */
        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void cmdPotonganPembelian_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    _flagSource = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["FlagSource"].Value.ToString(), "ORI").ToString();
                    Guid PembelianRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString(), Guid.Empty).ToString());
                    if (_flagSource == "BARU") // ORI biarpun ADS tetep ngga ada potongan
                    {
                        Pembelian.frmTambahPotonganPembelian ifrmChild = new Pembelian.frmTambahPotonganPembelian(this, _pembRowID);
                        ifrmChild.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tidak ada Potongan Pembelian untuk jenis Pembelian non - BARU");
                        return;
                    }
                }
            }
        }       
    }
}
