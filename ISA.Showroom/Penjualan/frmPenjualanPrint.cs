using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ISA.DAL;
using ISA.Showroom.Class;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPenjualanPrint : ISA.Controls.BaseForm
    {
        enum enumFormMode { Tunai, Kredit };
        enumFormMode formMode;
        Guid _rowID;
        int _nprint;
        string _cabangID = GlobalVar.CabangID;

        public frmPenjualanPrint(Form caller, String status, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            if (status == "TUNAI") formMode = enumFormMode.Tunai;
            else formMode = enumFormMode.Kredit;
            _rowID = rowID;
        }

        private void frmPenjualanPrint_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Tunai) rbPrintPenjualan9.Enabled = false;
            if (formMode == enumFormMode.Kredit && GlobalVar.CabangID.Contains("06"))
            {
                rbKartuPiutang.Enabled = true;
                rbKartuPiutang.Visible = true;
            }
            else
            {
                rbKartuPiutang.Enabled = false;
                rbKartuPiutang.Visible = false;
            }
            rbPrintPenjualan1.Checked = true;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                this.Close();
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void cetak_faktur()
        {
            try
            {
                string _kotatgl;
                string _kota;
                string _copy;
                System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                System.Globalization.Calendar cal = dfi.Calendar;
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
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    List<ReportParameter> rptParams = new List<ReportParameter>();

                    if (dt.Rows.Count > 0)
                    {
                        int JamBebasPIN = 0;
                        DataTable dummyPIN = new DataTable();
                        using (Database dbsubPIN = new Database())
                        {
                            dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                            dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                            dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                            JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                        }

                        DateTime LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn1"], DateTime.MaxValue.AddDays(-1));
                        if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                        {
                        }
                        else
                        {
                            if (Int64.Parse(dt.Rows[0]["Cetak1"].ToString()) > 2) // sebelumnya 1 sekarang 2 kalo > 1 berarti boleh 2 kali print
                            {
                                // sebelumnya PinId.Bagian.Piutang
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.FakturPenjualan), "Sudah dilakukan cetak Faktur Penjualan !");
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        DateTime tglBayar;
                        if (GlobalVar.CabangID.Contains("06"))
                        {
                            tglBayar = GlobalVar.GetServerDate;// Convert.ToDateTime(Tools.isNull(dt.Rows[0]["TglJual"].ToString(), GlobalVar.GetServerDate).ToString());
                        }
                        else
                        {
                            tglBayar = GlobalVar.GetServerDate;
                        }
                        _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak1"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak1"].ToString()) - 1).ToString();
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

                        rptParams.Add(new ReportParameter("Judul", "FAKTUR PENJUALAN".ToString()));
                        rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                        rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                        rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()
                        
                        if ((_nprint == 0) || (_nprint == 1))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptFaktur.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                            ifrmReport.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 2))
                        {
                            frmReportViewer ifrmReport2 = new frmReportViewer("Penjualan.rptFakturCopy1.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                            ifrmReport2.Print();
                        }
                        if ((_nprint == 0 && !GlobalVar.CabangID.Contains("06") ) || (_nprint == 3))
                        {
                            frmReportViewer ifrmReport3 = new frmReportViewer("Penjualan.rptFakturCopy2.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                            ifrmReport3.Print();
                        }

                        using (Database dbsub = new Database())
                        {
                            dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 1)); // sesuai yg sebelumnya, Cetak1
                            dbsub.Commands[0].ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cetak_order()
        {
            try
            {
                string _kotatgl;
                string _kota;
                string _copy;
                System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                System.Globalization.Calendar cal = dfi.Calendar;
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
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    List<ReportParameter> rptParams = new List<ReportParameter>();

                    if (dt.Rows.Count > 0)
                    {
                        int JamBebasPIN = 0;
                        DataTable dummyPIN = new DataTable();
                        using (Database dbsubPIN = new Database())
                        {
                            dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                            dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                            dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                            JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                        }

                        DateTime LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn2"], DateTime.MaxValue.AddDays(-1));
                        if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                        {
                        }
                        else
                        {
                            if (Int64.Parse(dt.Rows[0]["Cetak2"].ToString()) > 2) // sebelumnya 1, sekarang 2 kalo > 1 berarti boleh 2 kali print
                            {
                                // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.OrderPenjualan), "Sudah dilakukan cetak Order Penjualan !");
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak2"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak2"].ToString()) - 1).ToString();
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

                        rptParams.Add(new ReportParameter("Judul", "ORDER PENJUALAN".ToString()));
                        rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                        rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                        rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()
                        if ((_nprint == 0) || (_nprint == 1))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptOder.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                            ifrmReport.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 2))
                        {
                            frmReportViewer ifrmReport2 = new frmReportViewer("Penjualan.rptOderCopy1.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                            ifrmReport2.Print();
                        }
                        if ((_nprint == 0) || (_nprint == 3))
                        {
                            frmReportViewer ifrmReport3 = new frmReportViewer("Penjualan.rptOderCopy2.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                            ifrmReport3.Print();
                        }
                        /*
                        Command cmd = new Command(new Database(), CommandType.Text,
                                        "BEGIN                                                                          " +
                                        "   DECLARE @Cetak int = 0;                                                     " +
                                        "   SET @Cetak = (SELECT Cetak2 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                        "   UPDATE dbo.Penjualan SET Cetak2 = @Cetak WHERE RowID = @RowID;              " +
                                        "END                                                                            "
                                       );
                        cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                        cmd.ExecuteNonQuery();
                        */
                        using (Database dbsub = new Database())
                        {
                            dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 2)); // sesuai yg sebelumnya, Cetak2
                            dbsub.Commands[0].ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cetak_perjanjian()
        {
            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            System.Globalization.Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            string _copy = "";
            string _kota = "";
            string _kotatgl = "";
            string copies = "";
            
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    int JamBebasPIN = 0;
                    DataTable dummyPIN = new DataTable();
                    using (Database dbsubPIN = new Database())
                    {
                        dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                        dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                        JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                    }
                    DateTime LastPrintedOn = (DateTime) Tools.isNull(dt.Rows[0]["LastPrintedOn3"], DateTime.MaxValue.AddDays(-1));
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (Int64.Parse(dt.Rows[0]["Cetak3"].ToString()) > 2) // sebelumnya 1, sekarang 2 kalo > 1 berarti boleh 2 kali print
                        {
                            // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.PerjanjianSewaBeli), "Sudah dilakukan cetak Perjanjian Sewa Beli !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }

                    String SourceFile = @"C:\\Temp\\Document\\PERJANJIAN SEWA BELI.docx";
                    String DestinationFile = @"C:\\Temp\\PERJANJIAN SEWA BELI (" + dt.Rows[0]["NoTrans"].ToString() +  ").docx";
                   
                    if (File.Exists((string)SourceFile))
                    {
                        if (File.Exists(DestinationFile)) { File.Delete(DestinationFile); }
                        File.Copy(SourceFile, DestinationFile, true);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(DestinationFile, true);
                        Body body = wordDoc.MainDocumentPart.Document.Body;
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        string HariTanggal = Tools.HariPanjang(GlobalVar.GetServerDate) + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                        this.FindAndReplaceText(wordDoc, "Nomor : [NoFaktur]", "Nomor : " + dt.Rows[0]["NoFaktur"].ToString());
                        this.FindAndReplaceText(wordDoc, "Pada hari ini [HariTanggal], Saya yang membubuhkan tandatangan di", "Pada hari ini " + HariTanggal + ", Saya yang membubuhkan tandatangan di");
                        this.FindAndReplaceText(wordDoc, "[PenanggungJawab]", GlobalVar.PenanggungJawab);
                        this.FindAndReplaceText(wordDoc, "[Jabatan]", GlobalVar.Jabatan);
                        this.FindAndReplaceText(wordDoc, "[NamaCustomer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[PekerjaanCustomer]", dt.Rows[0]["Pekerjaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatCustomer]", dt.Rows[0]["AlamatCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KelurahanCustomer]", dt.Rows[0]["KelurahanCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaCustomer]", dt.Rows[0]["KotaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Identitas]", dt.Rows[0]["Identitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoIdentitas]", dt.Rows[0]["NoIdentitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[MerkMotor]", dt.Rows[0]["MerkMotor"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Tahun]", dt.Rows[0]["Tahun"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoRangka]", dt.Rows[0]["NoRangka"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoMesin]", dt.Rows[0]["NoMesin"].ToString());
                        this.FindAndReplaceText(wordDoc, "[TypeMotor]", dt.Rows[0]["TypeMotor"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Cc]", dt.Rows[0]["Cc"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Warna]", dt.Rows[0]["Warna"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Nopol]", dt.Rows[0]["Nopol"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Kondisi]", dt.Rows[0]["Kondisi"].ToString());

                        string Angsuran = string.Format("{0:#,##0}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["Angsuran"], 0))) + " (" + Tools.Terbilang(Int64.Parse(Tools.isNull(dt.Rows[0]["Angsuran"], 0).ToString(), System.Globalization.NumberStyles.Currency)) + ")";
                        string HargaJadi = string.Format("{0:#,##0}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["HargaJadi_PJB"], 0))) + " (" + Tools.Terbilang(Int64.Parse(Tools.isNull(dt.Rows[0]["HargaJadi_PJB"], 0).ToString(), System.Globalization.NumberStyles.Currency)) + ")";
                        string UangMuka = string.Format("{0:#,##0}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["UangMuka"], 0))) + " (" + Tools.Terbilang(Int64.Parse(Tools.isNull(dt.Rows[0]["UangMuka"], 0).ToString(), System.Globalization.NumberStyles.Currency)) + ")";
                        string SisaPokok = string.Format("{0:#,##0}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokok_PJB"], 0))) + " (" + Tools.Terbilang(Int64.Parse(Tools.isNull(dt.Rows[0]["SisaPokok_PJB"], 0).ToString(), System.Globalization.NumberStyles.Currency)) + ")";
                        string TglAwalAngs = "";
                        if (!string.IsNullOrEmpty(dt.Rows[0]["TglAwalAngs"].ToString()))
                        {
                            DateTime _tglawalangs = (DateTime)dt.Rows[0]["TglAwalAngs"];
                            TglAwalAngs = _tglawalangs.Day.ToString() + " " + Tools.BulanPanjang(_tglawalangs.Month) + " " + _tglawalangs.Year.ToString();
                        }

                        this.FindAndReplaceText(wordDoc, "RpAngs", Angsuran);
                        this.FindAndReplaceText(wordDoc, "[TempoAngsuran]", Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0).ToString());
                        this.FindAndReplaceText(wordDoc, "[TglAwalAngs]", TglAwalAngs);
                        this.FindAndReplaceText(wordDoc, "[HargaJadi]", HargaJadi);
                        this.FindAndReplaceText(wordDoc, "[UangMuka]", UangMuka);
                        this.FindAndReplaceText(wordDoc, "SisaPokok", SisaPokok);
                        this.FindAndReplaceText(wordDoc, "t1", Tools.isNull(dt.Rows[0]["TeksAngsuran1"], "").ToString());
                        this.FindAndReplaceText(wordDoc, "text2", Tools.isNull(dt.Rows[0]["TeksAngsuran2"], "").ToString());
                        this.FindAndReplaceText(wordDoc, "[TglJT]", Tools.isNull(dt.Rows[0]["TglJT"], "").ToString());
                        this.FindAndReplaceText(wordDoc, "[Kota]", dt.Rows[0]["Kota"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Copy]", _copy);

                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        wordDoc.Close();

                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(DestinationFile);
                            info.Verb = "PrintTo";
                            info.Arguments = pd.PrinterSettings.PrinterName;                            
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("File " + SourceFile.ToString() + " tidak diketemukan !");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
            finally
            {   /*             
                Command cmd = new Command(new Database(), CommandType.Text,
                                    "BEGIN                                                                          " +
                                    "   DECLARE @Cetak int = 0;                                                     " +
                                    "   SET @Cetak = (SELECT Cetak3 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                    "   UPDATE dbo.Penjualan SET Cetak3 = @Cetak WHERE RowID = @RowID;              " +
                                    "END                                                                            "
                                   );
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                cmd.ExecuteNonQuery();
                */
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 3)); // sesuai yg sebelumnya, Cetak3
                    dbsub.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void cetak_ringkasan()
        {
            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            System.Globalization.Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            string _copy = "";
            string _kota = "";
            string _kotatgl = "";

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    int JamBebasPIN = 0;
                    DataTable dummyPIN = new DataTable();
                    using (Database dbsubPIN = new Database())
                    {
                        dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                        dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                        JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                    }
                    DateTime LastPrintedOn = (DateTime) Tools.isNull(dt.Rows[0]["LastPrintedOn4"], DateTime.MaxValue.AddDays(-1));
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (Int64.Parse(dt.Rows[0]["Cetak4"].ToString()) > 2) // sebelumnya 1 sekarang 2 kalo > 1, berarti boleh 2 kali print 
                        {
                            // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.RingkasanPerjanianSewaBeli), "Sudah dilakukan cetak Ringkasan Perjanjian Sewa Beli !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }
                    String SourceFile = @"C:\\Temp\\Document\\RINGKASAN SURAT PERJANJIAN SEWA BELI.docx";
                    String DestinationFile = @"C:\\Temp\\RINGKASAN SURAT PERJANJIAN SEWA BELI (" + dt.Rows[0]["NoTrans"].ToString() + ").docx";

                    if (File.Exists((string)SourceFile))
                    {
                        if (File.Exists(DestinationFile)) { File.Delete(DestinationFile); }
                        File.Copy(SourceFile, DestinationFile, true);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(DestinationFile, true);
                        Body body = wordDoc.MainDocumentPart.Document.Body;
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }
                       
                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak4"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak4"].ToString()) - 1).ToString();
                        }
                        else
                        {
                            _copy = "";
                        }

                        string HariTanggal = Tools.HariPanjang(GlobalVar.GetServerDate) + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                        this.FindAndReplaceText(wordDoc, "[KotaTgl]", _kotatgl);
                        this.FindAndReplaceText(wordDoc, "[PenanggungJawab]", GlobalVar.PenanggungJawab);
                        this.FindAndReplaceText(wordDoc, "[NamaCustomer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Copy]", _copy);
                        
                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        wordDoc.Close();
                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(DestinationFile);
                            info.Verb = "PrintTo";
                            info.Arguments = pd.PrinterSettings.PrinterName;
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);                            
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("File " + SourceFile.ToString() + " tidak diketemukan !");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
            finally
            {   /*
                Command cmd = new Command(new Database(), CommandType.Text,
                                    "BEGIN                                                                          " +
                                    "   DECLARE @Cetak int = 0;                                                     " +
                                    "   SET @Cetak = (SELECT Cetak4 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                    "   UPDATE dbo.Penjualan SET Cetak4 = @Cetak WHERE RowID = @RowID;              " +
                                    "END                                                                            "
                                   );
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                cmd.ExecuteNonQuery();
                */
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 4)); // sesuai yg sebelumnya, Cetak4
                    dbsub.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void cetak_pernyataan()
        {
            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            System.Globalization.Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            string _copy = "";
            string _kota = "";
            string _kotatgl = "";

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    int JamBebasPIN = 0;
                    DataTable dummyPIN = new DataTable();
                    using (Database dbsubPIN = new Database())
                    {
                        dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                        dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                        JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                    }
                    DateTime LastPrintedOn = (DateTime) Tools.isNull(dt.Rows[0]["LastPrintedOn5"], DateTime.MaxValue.AddDays(-1));
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (Int64.Parse(dt.Rows[0]["Cetak5"].ToString()) > 2) // sebelumnya 1, sekarang 2 kalo > 1 berarti boleh 2 kali print
                        {
                            // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.SuratPernyataan), "Sudah dilakukan cetak Surat Pernyataan !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }

                    String SourceFile = @"C:\\Temp\\Document\\SURAT PERNYATAAN.docx";
                    String DestinationFile = @"C:\\Temp\\SURAT PERNYATAAN (" + dt.Rows[0]["NoTrans"].ToString() + ").docx";

                    if (File.Exists((string)SourceFile))
                    {
                        if (File.Exists(DestinationFile)) { File.Delete(DestinationFile); }
                        File.Copy(SourceFile, DestinationFile, true);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(DestinationFile, true);
                        Body body = wordDoc.MainDocumentPart.Document.Body;
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak5"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak5"].ToString()) - 1).ToString();
                        }
                        else
                        {
                            _copy = "";
                        }

                        string Tanggal = Convert.ToDateTime(txtTglPenulasan.DateValue).Day.ToString() + " " + Tools.BulanPanjang(Convert.ToDateTime(txtTglPenulasan.DateValue).Month) + " " + Convert.ToDateTime(txtTglPenulasan.DateValue).Year.ToString();
                        this.FindAndReplaceText(wordDoc, "[NamaCustomer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[PekerjaanCustomer]", dt.Rows[0]["Pekerjaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatCustomer]", dt.Rows[0]["AlamatCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KelurahanCustomer]", dt.Rows[0]["KelurahanCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaCustomer]", dt.Rows[0]["KotaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "Adalah customer dari [NamaPerusahaan] dari kendaraan :", "Adalah customer dari " + dt.Rows[0]["NamaPerusahaan"].ToString() + " dari kendaraan :");
                        this.FindAndReplaceText(wordDoc, "[MerkMotor]", dt.Rows[0]["MerkMotor"].ToString() + " / " + dt.Rows[0]["TypeMotor"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Tahun]", dt.Rows[0]["Tahun"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Warna]", dt.Rows[0]["Warna"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Nopol]", dt.Rows[0]["Nopol"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NamaBPKB]", dt.Rows[0]["NamaBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatBPKB]", dt.Rows[0]["AlamatBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaBPKB]", dt.Rows[0]["KotaBPKB"].ToString());                        
                        this.FindAndReplaceText(wordDoc, "[NamaPerusahaan]", dt.Rows[0]["NamaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[PenanggungJawab]", GlobalVar.PenanggungJawab);
                        this.FindAndReplaceText(wordDoc, "[Tanggal]", Tanggal);
                        this.FindAndReplaceText(wordDoc, "[KotaTgl]", _kotatgl);
                        this.FindAndReplaceText(wordDoc, "Customer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Copy]", _copy);

                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        wordDoc.Close();
                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(DestinationFile);
                            info.Verb = "PrintTo";
                            info.Arguments = pd.PrinterSettings.PrinterName;
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + SourceFile.ToString() + " tidak diketemukan !");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
            finally
            {   /*
                Command cmd = new Command(new Database(), CommandType.Text,
                                    "BEGIN                                                                          " +
                                    "   DECLARE @Cetak int = 0;                                                     " +
                                    "   SET @Cetak = (SELECT Cetak5 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                    "   UPDATE dbo.Penjualan SET Cetak5 = @Cetak WHERE RowID = @RowID;              " +
                                    "END                                                                            "
                                   );
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                cmd.ExecuteNonQuery();
                */
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 5)); // sesuai yg sebelumnya, Cetak5
                    dbsub.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void cetak_kuasa()
        {
            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            System.Globalization.Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            string _copy = "";
            string _kota = "";
            string _kotatgl = "";

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    int JamBebasPIN = 0;
                    DataTable dummyPIN = new DataTable();
                    using (Database dbsubPIN = new Database())
                    {
                        dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                        dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                        JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                    }

                    DateTime LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn6"], DateTime.MaxValue.AddDays(-1));
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (Int64.Parse(dt.Rows[0]["Cetak6"].ToString()) > 2) // sebelumnya 1 sekarang 2 kalo > 1 berarti boleh print 2 kali
                        {
                            // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.SuratKuasa), "Sudah dilakukan cetak Surat Kuasa !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }

                    String SourceFile = @"C:\\Temp\\Document\\SURAT KUASA.docx";
                    String DestinationFile = @"C:\\Temp\\SURAT KUASA (" + dt.Rows[0]["NoTrans"].ToString() + ").docx";

                    if (File.Exists((string)SourceFile))
                    {
                        if (File.Exists(DestinationFile)) { File.Delete(DestinationFile); }
                        File.Copy(SourceFile, DestinationFile, true);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(DestinationFile, true);
                        Body body = wordDoc.MainDocumentPart.Document.Body;
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak6"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak6"].ToString()) - 1).ToString();
                        }
                        else
                        {
                            _copy = "";
                        }

                        string HariTanggal = Tools.HariPanjang(GlobalVar.GetServerDate) + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                        this.FindAndReplaceText(wordDoc, "[KotaTgl]", _kotatgl);
                        this.FindAndReplaceText(wordDoc, "[PenanggungJawab]", GlobalVar.PenanggungJawab);
                        this.FindAndReplaceText(wordDoc, "[NamaCustomer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Pekerjaan]", dt.Rows[0]["Pekerjaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatCustomer]", dt.Rows[0]["AlamatCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KelurahanCustomer]", dt.Rows[0]["KelurahanCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaCustomer]", dt.Rows[0]["KotaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "No. [Identitas]", "No. " + dt.Rows[0]["Identitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoIdentitas]", dt.Rows[0]["NoIdentitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[MerkMotor]", dt.Rows[0]["MerkMotor"].ToString() + " / " + dt.Rows[0]["TypeMotor"].ToString());
                        this.FindAndReplaceText(wordDoc, "Thn", dt.Rows[0]["Tahun"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoRangka]", dt.Rows[0]["NoRangka"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoMesin]", dt.Rows[0]["NoMesin"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoBPKB]", dt.Rows[0]["NoBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Warna]", dt.Rows[0]["Warna"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Nopol]", dt.Rows[0]["Nopol"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NamaPerusahaan] ", dt.Rows[0]["NamaPerusahaan"].ToString() + " ");
                        this.FindAndReplaceText(wordDoc, " [AlamatPerusahaan]", " " + dt.Rows[0]["AlamatPerusahaan"].ToString() + " " + dt.Rows[0]["KotaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Copy]", _copy);

                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        wordDoc.Close();
                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(DestinationFile);
                            info.Verb = "PrintTo";
                            info.Arguments = pd.PrinterSettings.PrinterName;
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + SourceFile.ToString() + " tidak diketemukan !");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
            finally
            {   /*
                Command cmd = new Command(new Database(), CommandType.Text,
                                    "BEGIN                                                                          " +
                                    "   DECLARE @Cetak int = 0;                                                     " +
                                    "   SET @Cetak = (SELECT Cetak6 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                    "   UPDATE dbo.Penjualan SET Cetak6 = @Cetak WHERE RowID = @RowID;              " +
                                    "END                                                                            "
                                   );
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                cmd.ExecuteNonQuery();
                */
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 6)); // sesuai yg sebelumnya, Cetak6
                    dbsub.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void cetak_penyerahan()
        {
            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            System.Globalization.Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            string _copy = "";
            string _kota = "";
            string _kotatgl = "";

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    int JamBebasPIN = 0;
                    DataTable dummyPIN = new DataTable();
                    using (Database dbsubPIN = new Database())
                    {
                        dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                        dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                        JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                    }
                    DateTime LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn7"], DateTime.MaxValue.AddDays(-1));
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (Int64.Parse(dt.Rows[0]["Cetak7"].ToString()) > 2) // sebelumnya 1 sekarang 2 kalo > 1 mestinya udah boleh 2 kali print
                        {
                            // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.SuratPenyerahanKendaraan), "Sudah dilakukan cetak Surat Penyerahan Kembali Kendaraan !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }

                    String SourceFile = @"C:\\Temp\\Document\\PENYERAHAN KEMBALI KENDARAAN.docx";
                    String DestinationFile = @"C:\\Temp\\PENYERAHAN KEMBALI KENDARAAN (" + dt.Rows[0]["NoTrans"].ToString() + ").docx";

                    if (File.Exists((string)SourceFile))
                    {
                        if (File.Exists(DestinationFile)) { File.Delete(DestinationFile); }
                        File.Copy(SourceFile, DestinationFile, true);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(DestinationFile, true);
                        Body body = wordDoc.MainDocumentPart.Document.Body;
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak7"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak7"].ToString()) - 1).ToString();
                        }
                        else
                        {
                            _copy = "";
                        }

                        string Tanggal = GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                        this.FindAndReplaceText(wordDoc, "[KotaTgl]", _kotatgl);
                        this.FindAndReplaceText(wordDoc, "PenanggungJawab", GlobalVar.PenanggungJawab);
                        this.FindAndReplaceText(wordDoc, "[NamaCustomer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "NmCustomer", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "Work", dt.Rows[0]["Pekerjaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatCustomer]", dt.Rows[0]["AlamatCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KelurahanCustomer]", dt.Rows[0]["KelurahanCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaCustomer]", dt.Rows[0]["KotaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "No. [Identitas]", "No. " + dt.Rows[0]["Identitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoIdentitas]", dt.Rows[0]["NoIdentitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[MerkMotor]", dt.Rows[0]["MerkMotor"].ToString() + " / " + dt.Rows[0]["TypeMotor"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Tahun]", dt.Rows[0]["Tahun"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoRangka]", dt.Rows[0]["NoRangka"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoMesin]", dt.Rows[0]["NoMesin"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoBPKB]", dt.Rows[0]["NoBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Warna]", dt.Rows[0]["Warna"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Nopol]", dt.Rows[0]["Nopol"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NamaPerusahaan]", dt.Rows[0]["NamaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "prshn", dt.Rows[0]["NamaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "Tggl", Tanggal);
                        this.FindAndReplaceText(wordDoc, "[Copy]", _copy);

                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        wordDoc.Close();
                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(DestinationFile);
                            info.Verb = "PrintTo";
                            info.Arguments = pd.PrinterSettings.PrinterName;
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + SourceFile.ToString() + " tidak diketemukan !");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
            finally
            {   /*
                Command cmd = new Command(new Database(), CommandType.Text,
                                    "BEGIN                                                                          " +
                                    "   DECLARE @Cetak int = 0;                                                     " +
                                    "   SET @Cetak = (SELECT Cetak7 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                    "   UPDATE dbo.Penjualan SET Cetak7 = @Cetak WHERE RowID = @RowID;              " +
                                    "END                                                                            "
                                   );
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                cmd.ExecuteNonQuery();
                */
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 7)); // sesuai yg sebelumnya, Cetak7
                    dbsub.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void cetak_pengakuan()
        {
            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            System.Globalization.Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            string _copy = "";
            string _kota = "";
            string _kotatgl = "";

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    int JamBebasPIN = 0;
                    DataTable dummyPIN = new DataTable();
                    using (Database dbsubPIN = new Database())
                    {
                        dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                        dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                        JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                    }
                    DateTime LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn8"], DateTime.MaxValue.AddDays(-1));
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (Int64.Parse(dt.Rows[0]["Cetak8"].ToString()) > 2) // sekarang 2 sebelumnya 1 kalo > 1 mestinya udah boleh 2 kali print
                        {
                            // sebelumnya PinId.Bagian.Keuangan, biar bisa jalan sementara jadiin PinId.Bagian.Piutang
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.SuratPengakuanHutang), "Sudah dilakukan cetak Surat Pengakuan Hutang !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }
                    String SourceFile = @"C:\\Temp\\Document\\SURAT PENGAKUAN HUTANG.docx";
                    String DestinationFile = @"C:\\Temp\\SURAT PENGAKUAN HUTANG (" + dt.Rows[0]["NoTrans"].ToString() + ").docx";

                    if (File.Exists((string)SourceFile))
                    {
                        if (File.Exists(DestinationFile)) { File.Delete(DestinationFile); }
                        File.Copy(SourceFile, DestinationFile, true);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(DestinationFile, true);
                        Body body = wordDoc.MainDocumentPart.Document.Body;
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kota = _kota.Replace("Kota ", "");
                        _kota = _kota.Replace("Kabupaten ", "");
                        _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();

                        if (Int64.Parse(dt.Rows[0]["Cetak8"].ToString()) > 1)
                        {
                            _copy = "Copy ke-" + (Int64.Parse(dt.Rows[0]["Cetak8"].ToString()) - 1).ToString();
                        }
                        else
                        {
                            _copy = "";
                        }

                        string HariPelunasan = Tools.HariPanjang((DateTime) txtTglPenulasan.DateValue);
                        string TanggalPelunasan = Convert.ToDateTime(txtTglPenulasan.DateValue).Day.ToString();
                        string BulanPelunasan = Tools.BulanPanjang(Convert.ToDateTime(txtTglPenulasan.DateValue).Month);
                        string TahunPelunasan = Convert.ToDateTime(txtTglPenulasan.DateValue).Year.ToString();
                        string TglPelunasan = string.Format("{0:d-MM-yyyy}", txtTglPenulasan.DateValue);
                        string SisaPokok = string.Format("{0:#,##0}", Convert.ToDouble(Tools.isNull(dt.Rows[0]["SisaPokok"], 0)));
                        string SisaPokokTerbilang = Tools.Terbilang(Int64.Parse(Tools.isNull(dt.Rows[0]["SisaPokok"], 0).ToString(), System.Globalization.NumberStyles.Currency));

                        this.FindAndReplaceText(wordDoc, "[KotaTgl]", _kotatgl);
                        this.FindAndReplaceText(wordDoc, "[PenanggungJawab]", GlobalVar.PenanggungJawab);
                        this.FindAndReplaceText(wordDoc, "[NamaCustomer]", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "cs", dt.Rows[0]["NamaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Work", dt.Rows[0]["Pekerjaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatCustomer]", dt.Rows[0]["AlamatCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KelurahanCustomer]", dt.Rows[0]["KelurahanCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaCustomer]", dt.Rows[0]["KotaCustomer"].ToString());
                        this.FindAndReplaceText(wordDoc, "No. [Identitas]", "No. " + dt.Rows[0]["Identitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoIdentitas]", dt.Rows[0]["NoIdentitas"].ToString());
                        this.FindAndReplaceText(wordDoc, "SisaPokok", SisaPokok);
                        this.FindAndReplaceText(wordDoc, "SisaPokokTerbilang", SisaPokokTerbilang);
                        this.FindAndReplaceText(wordDoc, "[Penjualan]", dt.Rows[0]["Penjualan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NoFaktur]", dt.Rows[0]["NoFaktur"].ToString());
                        this.FindAndReplaceText(wordDoc, "[MerkMotor]", dt.Rows[0]["MerkMotor"].ToString() + " / " + dt.Rows[0]["TypeMotor"].ToString());                        
                        this.FindAndReplaceText(wordDoc, "[Tahun]", dt.Rows[0]["Tahun"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NamaBPKB]", dt.Rows[0]["NamaBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[AlamatBPKB]", dt.Rows[0]["AlamatBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[KotaBPKB]", dt.Rows[0]["KotaBPKB"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Warna]", dt.Rows[0]["Warna"].ToString());
                        this.FindAndReplaceText(wordDoc, "[Nopol]", dt.Rows[0]["Nopol"].ToString());
                        this.FindAndReplaceText(wordDoc, "[NamaPerusahaan]", dt.Rows[0]["NamaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "NamaPerusahaan", dt.Rows[0]["NamaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "AlamatPerusahaan", dt.Rows[0]["AlamatPerusahaan"].ToString() + " " + dt.Rows[0]["KotaPerusahaan"].ToString());
                        this.FindAndReplaceText(wordDoc, "[HariPelunasan]", HariPelunasan);
                        this.FindAndReplaceText(wordDoc, "TanggalPelunasan", TanggalPelunasan);
                        this.FindAndReplaceText(wordDoc, "[BulanPelunasan]", BulanPelunasan);
                        this.FindAndReplaceText(wordDoc, "TahunPelunasan", TahunPelunasan);
                        this.FindAndReplaceText(wordDoc, "[TglPelunasan]", TglPelunasan);
                        this.FindAndReplaceText(wordDoc, "[Copy]", _copy);

                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }
                        wordDoc.Close();
                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(DestinationFile);
                            info.Verb = "PrintTo"; 
                            info.Arguments = pd.PrinterSettings.PrinterName;
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + SourceFile.ToString() + " tidak diketemukan !");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal dicetak, tidak ada data ditemukan !\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
            finally
            {   /*
               Command cmd = new Command(new Database(), CommandType.Text,
                                    "BEGIN                                                                          " +
                                    "   DECLARE @Cetak int = 0;                                                     " +
                                    "   SET @Cetak = (SELECT Cetak8 + 1 FROM dbo.Penjualan WHERE RowID = @RowID);   " +
                                    "   UPDATE dbo.Penjualan SET Cetak8 = @Cetak WHERE RowID = @RowID;              " +
                                    "END                                                                            "
                                   );
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, _rowID);
                cmd.ExecuteNonQuery();
                */
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 8)); // sesuai yg sebelumnya, Cetak8
                    dbsub.Commands[0].ExecuteNonQuery();
                }
            }
        }

        private void cetak_kartu()
        {
            try
            {   
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("rpt_Faktur_Penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    frmReportViewer ifrmReport;

                    if (rbHal1.Checked == true)
                    {
                        ifrmReport = new frmReportViewer("Penjualan.rptKartuAngsuran.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    }
                    else
                    {
                        ifrmReport = new frmReportViewer("Penjualan.rptKartuAngsuran2.rdlc", rptParams, dt, "dsPenjualan_Faktur");
                    }
                    ifrmReport.Show();                                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void cetak_kwitansiUM()
        {
            try
            {
                Guid rowID = _rowID;
                string _edp, _terbilang, _kotatgl, _kota, _copy, _uraian;
                int _nprint;
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                System.Globalization.Calendar cal = dfi.Calendar;
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
                    LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn"], DateTime.MaxValue);
                    if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                    {
                    }
                    else
                    {
                        if (dt.Rows[0]["Cetak"].ToString() == "true")
                        {
                            // sebelumnya PinId.Bagian.Keuangan
                            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
                            if (GlobalVar.pinResult == false) { return; }
                        }
                    }
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

                    // kalau di TLA maunya ditampilin totalan di atasnya aja, pokok, bunga sama pembulatan dilewatin
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["NominalTotal"]).ToString()));
                        // pokok, bunga sama pembulatan jadiin 0
                        dt.Rows[0]["NominalPembulatan"] = 0;
                    }
                    // minta di sampingnya no kontrak di kasih noAR
                    dt.Rows[0]["NoFaktur"] = dt.Rows[0]["NoFaktur"].ToString().Trim() + " - " + dt.Rows[0]["NoTrans"].ToString().Trim();

                    rptParams.Add(new ReportParameter("JnsKw", "UANG MUKA")); // DP/Uang Muka Setara
                    rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                    rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                    rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                    rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                    rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                    rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  // GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                    // tambahan untuk kwitansi
                    rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                    rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));

                    rptParams.Add(new ReportParameter("Tipe", "FIRST")); 
                    //rptParams.Add(new ReportParameter("Tipe", "DPS"));

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

                    using (Database dbsub = new Database())
                    {
                        dbsub.Commands.Add(dbsub.CreateCommand("usp_Penjualan_UPDATE_TargetCetak"));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dbsub.Commands[0].Parameters.Add(new Parameter("@TargetCetak", SqlDbType.Int, 9)); // sesuai yg sebelumnya, Cetak8
                        dbsub.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }


        private void cetak_kartuPiutang()
        {
            DataTable dtRpt = new DataTable();
            DataTable dtStat = new DataTable();
            using (Database db = new Database())
            {
                DataSet ds = new DataSet();
                db.Commands.Add(db.CreateCommand("rsp_KartuPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _rowID));
                ds = db.Commands[0].ExecuteDataSet();
                if (ds.Tables.Count > 0) // mestinya ada 2 tabel
                {
                    dtRpt = ds.Tables[0];
                    dtStat = ds.Tables[1];
                }

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NoBukti", Tools.isNull(dtStat.Rows[0]["NoBukti"], "").ToString()));
                rptParams.Add(new ReportParameter("NoTrans", Tools.isNull(dtStat.Rows[0]["NoTrans"], "").ToString()));
                rptParams.Add(new ReportParameter("Nopol", Tools.isNull(dtStat.Rows[0]["Nopol"], "").ToString()));
                rptParams.Add(new ReportParameter("NoRangka", Tools.isNull(dtStat.Rows[0]["NoRangka"], "").ToString()));
                rptParams.Add(new ReportParameter("NoMesin", Tools.isNull(dtStat.Rows[0]["NoMesin"], "").ToString()));
                rptParams.Add(new ReportParameter("Alamat", Tools.isNull(dtStat.Rows[0]["Alamat"], "").ToString()));
                rptParams.Add(new ReportParameter("NamaPelanggan", Tools.isNull(dtStat.Rows[0]["NamaCustomer"], "").ToString()));
                rptParams.Add(new ReportParameter("TglJual", Tools.isNull(dtStat.Rows[0]["TglJual"], DateTime.MinValue).ToString()));
                rptParams.Add(new ReportParameter("TempoAngsuran", Tools.isNull(dtStat.Rows[0]["TempoAngsuran"], "0").ToString()));
                rptParams.Add(new ReportParameter("Angsuran", Tools.isNull(dtStat.Rows[0]["Angsuran"], "0").ToString()));
                rptParams.Add(new ReportParameter("Harga", Tools.isNull(dtStat.Rows[0]["Harga"], "0").ToString()));
                rptParams.Add(new ReportParameter("UangMuka", Tools.isNull(dtStat.Rows[0]["UangMuka"], "0").ToString()));
                rptParams.Add(new ReportParameter("SisaPokok", Tools.isNull(dtStat.Rows[0]["SisaPokok"], "0").ToString()));
                rptParams.Add(new ReportParameter("Bunga", Tools.isNull(dtStat.Rows[0]["Bunga"], "0").ToString()));
                rptParams.Add(new ReportParameter("Jumlah", Tools.isNull(dtStat.Rows[0]["Jumlah"], "0").ToString()));
                rptParams.Add(new ReportParameter("MerkTypeTahun", Tools.isNull(dtStat.Rows[0]["MerkTypeTahun"], "").ToString()));
                
                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(dtRpt);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsPenjualan_SimulasiAngsuran");

                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKartuPiutang.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Print();

            }
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            if (rbPrintPenjualan1.Checked == true)
                this.cetak_faktur();
            else if (rbPrintPenjualan2.Checked == true)
                this.cetak_order();
            else if (rbPrintPenjualan3.Checked == true)
                this.cetak_perjanjian();
            else if (rbPrintPenjualan4.Checked == true)
                this.cetak_ringkasan();
            else if (rbPrintPenjualan5.Checked == true)
                this.cetak_pernyataan();
            else if (rbPrintPenjualan6.Checked == true)
                this.cetak_kuasa();
            else if (rbPrintPenjualan7.Checked == true)
                this.cetak_penyerahan();
            else if (rbPrintPenjualan8.Checked == true)
                this.cetak_pengakuan();
            else if (rbPrintPenjualan9.Checked == true)
                this.cetak_kartu();
            else if (rbKwitansiUM.Checked == true)
                this.cetak_kwitansiUM();
            else if (rbKartuPiutang.Checked == true)
                this.cetak_kartuPiutang();

            if (this.Caller is Penjualan.frmPenjualanBrowse)
            {
                Penjualan.frmPenjualanBrowse ifrmCaller = (Penjualan.frmPenjualanBrowse)this.Caller;
                ifrmCaller.buttonFalse();
            }
            if (this.Caller is Penjualan.frmPegadaianBrowse)
            {
                Penjualan.frmPegadaianBrowse ifrmCaller = (Penjualan.frmPegadaianBrowse)this.Caller;
                ifrmCaller.buttonFalse();
            }
        }

        private void FindAndReplaceText(WordprocessingDocument wordprocessingDocument, string findText, string replaceText)
        {
            var ps = wordprocessingDocument.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
            foreach (DocumentFormat.OpenXml.Wordprocessing.Paragraph par in ps)
            {
                string modifiedString = "";
                Run[] runArr = par.Descendants<Run>().ToArray();
                foreach (Run run in runArr)
                {
                    string innerText = run.InnerText;
                    if (innerText == findText)
                    {
                        modifiedString = run.InnerText.Replace(innerText, replaceText);
                        if (modifiedString != run.InnerText)
                        {
                            Text t = new Text(modifiedString);
                            run.RemoveAllChildren<Text>();
                            run.AppendChild<Text>(t);
                        }
                    }
                }
            }

            wordprocessingDocument.MainDocumentPart.Document.Save();
        }

        private string GetPrinterName()
        {
            PrintDocument doc = new PrintDocument();
            return doc.PrinterSettings.PrinterName;
        }
               
        private void rbPrintPenjualan1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan1.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan2.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan3.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan4.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan5.Checked == true)
            {
                label1.Text = "Tanggal Penyerahan";
                panel1.Visible = false;
                panel2.Visible = true;
                rbHal1.Visible = false;
                rbHal2.Visible = false;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan6_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan6.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan7_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan7.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan8_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan8.Checked == true)
            {
                label1.Text = "Tanggal Pelunasan";
                panel1.Visible = false;
                panel2.Visible = true;
                rbHal1.Visible = false;
                rbHal2.Visible = false;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void rbPrintPenjualan9_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrintPenjualan9.Checked == true)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                label1.Visible = false;
                txtTglPenulasan.Visible = false;
                rbHal1.Visible = true;
                rbHal2.Visible = true;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }
    }
}
