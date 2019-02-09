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

namespace ISA.Showroom.Pembelian
{
    public partial class frmPembelianBrowseTLA : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        int _nprint;

        public frmPembelianBrowseTLA()
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
                    db.Commands.Add(db.CreateCommand("usp_PembelianBARU_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "BARU"));
                    dt = db.Commands[0].ExecuteDataTable();
                    DataColumn cConcatenated1 = new DataColumn("MerkType", Type.GetType("System.String"), "MerkMotor + ' / ' + TypeMotor");
                    dt.Columns.Add(cConcatenated1);
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

        private void frmPembelianBrowseTLA_Load(object sender, EventArgs e)
        {
            _fromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            _toDate = GlobalVar.GetServerDate;

            rdtTanggal.FromDate = _fromDate;
            rdtTanggal.ToDate = _toDate;
            
            RefreshData();
            cmdBA.Enabled = false;
            cmdCekList.Enabled = false;

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
            Pembelian.frmPembelianUpdateTLA ifrmChild = new Pembelian.frmPembelianUpdateTLA(this);
            Program.MainForm.CheckMdiChildren(ifrmChild);
            RefreshData();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                int intTotalRecPembayaran = 0; 
                
                
                using (Database db = new Database())
                {      
                    
                    db.Commands.Add(db.CreateCommand("usp_TotalRecPembayaran"));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                    object objTotalRecPembayaran = db.Commands[0].ExecuteScalar();

                    if (objTotalRecPembayaran != DBNull.Value)
                    {
                        intTotalRecPembayaran = Convert.ToInt32(objTotalRecPembayaran);

                    }
                }

                DataTable dtCekJurnal = new DataTable(); //cek udah di link jurnal belum, Heri
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PembelianBARU_CekJournal"));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtCekJurnal = db.Commands[0].ExecuteDataTable();
                }

                DataTable dtCekJual = new DataTable(); //cek udah terjual belum, Heri
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_CekJual"));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtCekJual = db.Commands[0].ExecuteDataTable();
                }

                if (CheckPrint(rowID) == true)
                {
                    MessageBox.Show("Sudah dilakukan cetak faktur, tidak diperkenankan mengedit data ini..");
                }

                else if (intTotalRecPembayaran > 0)
                {
                    MessageBox.Show("Sudah dilakukan pembayaran, tidak diperkenankan mengedit data ini..");
                }

                else if (dtCekJurnal.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah dilakukan link jurnal, tidak diperkenankan mengedit data ini..");
                }

                else if (dtCekJual.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah dilakukan penjualan atas motor ini, tidak diperkenankan mengedit data ini..");
                }
                              
                else
                {
                    Pembelian.frmPembelianUpdateTLA ifrmChild = new Pembelian.frmPembelianUpdateTLA(this, rowID);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                    RefreshData();
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

                int intTotalRecPembayaran = 0;


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TotalRecPembayaran"));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                    object objTotalRecPembayaran = db.Commands[0].ExecuteScalar();
                    if (objTotalRecPembayaran != DBNull.Value)
                    {
                        intTotalRecPembayaran = Convert.ToInt32(objTotalRecPembayaran);
                    }
                }
                using (Database db = new Database())
                {
                    DataTable dummy = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_CHECK_TglTerima"));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                    dummy = db.Commands[0].ExecuteDataTable();
                    if (dummy.Rows.Count > 0)
                    {
                        DateTime? test = Convert.ToDateTime(Tools.isNull(dummy.Rows[0]["TglTerima"], DateTime.MinValue));
                        if (Convert.ToDateTime(Tools.isNull(test, DateTime.MinValue)) == DateTime.MinValue)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Motor sudah diterima, tidak dapat menghapus data pembelian!");
                            return;
                        }
                    }
                }


                if (CheckPrint(rowID) == true)
                {
                    MessageBox.Show("Sudah dilakukan cetak faktur, tidak diperkenankan menghapus data ini !");
                }
                else if (intTotalRecPembayaran > 0)
                {
                    MessageBox.Show("Sudah dilakukan pembayaran, tidak diperkenankan menghapus data ini !");
                }
                else
                {
                    if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {   // pake CekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "Pembelian") == true) // this.ceckDelete(rowID) == true -> ke Pembelian
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusPembelian), "Hapus Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Pembelian_DELETE"));
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
                    db.Commands.Add(db.CreateCommand("usp_PembelianBARU_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Cetak1"],0)) > 0)
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

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _edp;
                    string _terbilang;
                    string _kotatgl;
                    string _kota;
                    string _copy;

                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                    frmPrint ifrmDialog = new frmPrint(this, 3);
                    ifrmDialog.ShowDialog();
                    if (ifrmDialog.DialogResult == DialogResult.Yes)
                    {
                        _nprint = ifrmDialog.Result;
                    }
                    else
                    {
                        return;
                    }

                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("rpt_Faktur_Pembelian"));
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
                            JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0));
                        }

                        DateTime LastPrintedOn;
                        LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn1"], DateTime.MaxValue);
                        if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                        {
                        }
                        else
                        {
                            if (int.Parse(dt.Rows[0]["Cetak1"].ToString()) > 1)
                            {   // Keuangan
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.FakturPembelian), "Sudah dilakukan cetak Faktur Pembelian !");
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }

                        _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["TglBeli"]);
                        _terbilang = Tools.Terbilang(int.Parse(dt.Rows[0]["HargaJadi"].ToString(), NumberStyles.Currency)) + "RUPIAH";
                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();

                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");

                        DateTime tglBayar;
                        if(GlobalVar.CabangID.Contains("06"))
                        {
                            tglBayar = GlobalVar.GetServerDate;// Convert.ToDateTime(Tools.isNull(dt.Rows[0]["TglBeli"].ToString(), GlobalVar.GetServerDate).ToString());
                        }
                        else
                        {
                            tglBayar = GlobalVar.GetServerDate;
                        }

                        // _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                        _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                        if (int.Parse(dt.Rows[0]["Cetak1"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (int.Parse(dt.Rows[0]["Cetak1"].ToString()) - 1).ToString();
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
                        if (GlobalVar.CabangID == "06A")
                        {
                            IMG_PathBW = "";
                        }
                        rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));

                        rptParams.Add(new ReportParameter("Judul", "FAKTUR PEMBELIAN".ToString()));
                        rptParams.Add(new ReportParameter("EDP", _edp));
                        rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                        rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                        rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                        rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                        if ((_nprint == 0) || (_nprint == 1))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptFaktur.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            ifrmReport.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 2))
                        {
                            frmReportViewer ifrmReport2 = new frmReportViewer("Pembelian.rptFakturCopy1.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            ifrmReport2.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 3))
                        {
                            frmReportViewer ifrmReport3 = new frmReportViewer("Pembelian.rptFakturCopy2.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            ifrmReport3.Print();
                        }
                        cmdEDIT.Enabled = false;
                        cmdDELETE.Enabled = false;

                        db.Commands.Add(db.CreateCommand("usp_Pembelian_UpdateCounterFaktur"));
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));                        
                        db.Commands[1].ExecuteNonQuery(); 

                        
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

        private void cmdCekList_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Pembelian.frmCekListUpdate ifrmChild = new Pembelian.frmCekListUpdate(this, rowID, "BARU");
                ifrmChild.ShowDialog();              
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            cmdBA.Enabled = true;
            cmdCekList.Enabled = true;
        }

        private void cmdBA_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _edp;
                    string _bulan;
                    string _tanggal;
                    string _tahun;
                    string _hari;
                    string _copy;

                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                    frmPrint ifrmDialog = new frmPrint(this, 2);
                    ifrmDialog.ShowDialog();
                    if (ifrmDialog.DialogResult == DialogResult.Yes)
                    {
                        _nprint = ifrmDialog.Result;
                    }
                    else
                    {
                        return;
                    }
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("rpt_Kelengkapan_BA_Pembelian"));
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
                        LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn2"], DateTime.MaxValue);
                        if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                        {
                        }
                        else
                        {
                            if (int.Parse(dt.Rows[0]["Cetak2"].ToString()) > 1)
                            {   // Keuangan
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.BeritaAcaraPembelian), "Sudah dilakukan cetak Berita Acara Serah Terima Barang !");
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }

                        _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["TglBeli"]);
                        _tanggal = GlobalVar.GetServerDate.Day.ToString();
                        _bulan = Tools.BulanPanjang(GlobalVar.GetServerDate.Month);
                        _tahun = GlobalVar.GetServerDate.Year.ToString();
                        _hari = Tools.HariPanjang(GlobalVar.GetServerDate);

                        if (int.Parse(dt.Rows[0]["Cetak2"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (int.Parse(dt.Rows[0]["Cetak2"].ToString()) - 1).ToString();
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
                        rptParams.Add(new ReportParameter("Judul", "BERITA ACARA SERAH TERIMA BARANG".ToString()));
                        rptParams.Add(new ReportParameter("EDP", _edp));
                        rptParams.Add(new ReportParameter("Tanggal", _tanggal.ToUpper()));
                        rptParams.Add(new ReportParameter("Bulan", _bulan.ToUpper()));
                        rptParams.Add(new ReportParameter("Tahun", _tahun.ToString()));
                        rptParams.Add(new ReportParameter("Hari", _hari.ToString()));
                        rptParams.Add(new ReportParameter("PenanggungJawab", GlobalVar.PenanggungJawab));
                        rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                        rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                        if ((_nprint == 0) || (_nprint == 1))
                        {
                            frmReportViewer ifrmReport1 = new frmReportViewer("Pembelian.rptBA1.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            ifrmReport1.Print();
                            //frmReportViewer ifrmReport2 = new frmReportViewer("Pembelian.rptBA2.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            //ifrmReport2.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 2))
                        {
                            frmReportViewer ifrmReport3 = new frmReportViewer("Pembelian.rptBA1.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            ifrmReport3.Print();
                            //frmReportViewer ifrmReport4 = new frmReportViewer("Pembelian.rptBA2.rdlc", rptParams, dt, "dsPembelian_Faktur");
                            //ifrmReport4.Print();
                        }
                       

                        db.Commands.Add(db.CreateCommand("usp_Pembelian_UpdateCounterBeritaAcara"));
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[1].ExecuteNonQuery(); 
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
        private void cmdEditTglTerima_Click(object sender, EventArgs e)
        {
            Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Pembelian.frmTglTerimaUpdate ifrmChild = new Pembelian.frmTglTerimaUpdate(this, rowID);
            ifrmChild.ShowDialog();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime exp = GlobalVar.DateOfServer.AddDays(-1);
                if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells[TglBeli.Name].Value < exp) { MessageBox.Show("Tanggal Pembelian kurang dari "+exp.ToString("dd-MMM-yyyy")+" tidak bisa di batalkan"); return; }
                if (Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells[TJ.Name].Value, "").ToString() != "") { MessageBox.Show("Barang sudah di jual tidak bisa di batalkan"); return; }
                if (Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells[JRI.Name].Value, "").ToString() != "") { MessageBox.Show("Barang sudah di Jurnal tidak bisa di batalkan"); return; }

                #region MintaPin
                // minta PIN
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                // minta Pin
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusPembelian), "Hapus Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                if (GlobalVar.pinResult == false) { return; }
                #endregion


                DialogResult dialogResult = MessageBox.Show("Apakah anda Yakin ingin membatalkan pembalian ini", "Pembatalan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }


                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Pembelian_Batal]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    object objPesan = db.Commands[0].ExecuteScalar();
                    //if (objTotalRecPembayaran != DBNull.Value)
                    //{
                    //  //  intTotalRecPembayaran = Convert.ToInt32(objTotalRecPembayaran);
                    //}
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                #region cek udah dibayar belum pembelian tsb

                DataTable dtcekPemb = new DataTable(); //cek udah di link jurnal belum, Heri
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Pembelian_CekPembayaranPemb]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, rowID));
                    dtcekPemb = db.Commands[0].ExecuteDataTable();
                }
                if (dtcekPemb.Rows.Count > 0)
                    {
                        MessageBox.Show("Telah dilakukan pembayaran hutang untuk pembelian ini, \n Anda tidak diperkenankan mengedit harga pembelian..");
                        return;
                    }
                #endregion

                #region MintaPin
                // minta PIN
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                // minta Pin
                //Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.HapusPembelian), "Hapus Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                //if (GlobalVar.pinResult == false) { return; }
                #endregion

                
                String Nofaktur = (String)dataGridView1.SelectedCells[0].OwningRow.Cells[NoFaktur.Name].Value;
                String Notransact = (String)dataGridView1.SelectedCells[0].OwningRow.Cells[NoTransaksi.Name].Value;
                String Namavendor = (String)dataGridView1.SelectedCells[0].OwningRow.Cells[NamaVendor.Name].Value;
                String HargaBeli = dataGridView1.SelectedCells[0].OwningRow.Cells[HargaJadi.Name].Value.ToString();
                Pembelian.FrmUbahHarga ifrmChild = new Pembelian.FrmUbahHarga(this,rowID,Nofaktur,Notransact,Namavendor,HargaBeli);
                Program.MainForm.CheckMdiChildren(ifrmChild);
                ifrmChild.Show();

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
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar, "Pembelian"));
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
