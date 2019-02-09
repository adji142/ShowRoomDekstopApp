using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Net.Mail;
using System.Net.Mime;

namespace ISA.Showroom.Finance.Class
{
    class EmailOtomatis
    {
        static DateTime AwalBlnLalu = GlobalVar.GetServerDate.Date.AddDays(-((GlobalVar.GetServerDate.Day) - 1)).AddMonths(-1).Date;
        static DateTime AwalBlnIni = GlobalVar.GetServerDate.Date.AddDays(-((GlobalVar.GetServerDate.Day) - 1)).Date;
        static DateTime Today = GlobalVar.GetServerDate.Date.AddDays(-1).Date;


        public static void StartEmailOtomatis()
        {
            if (Today.DayOfWeek.ToString() == "Sunday")
            {
                Today = Today.Date.AddDays(-1).Date;
            }

            bool CekKirimToday = CekEmailToday();
            //CekKirimToday = false;
            
            if (CekKirimToday == false)
            {
                KirimEmail();
            }
        }

        private static Boolean CekEmailToday()
        {
            bool CekEmail = false;
            Object Hasil;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_EmailAlertCekToday"));
                db.Commands[0].Parameters.Add(new Parameter("@modul", SqlDbType.VarChar, "SelisihSaldo"));
                Hasil = db.Commands[0].ExecuteScalar();
            }

            if (Convert.ToInt32(Hasil) > 0)
            {
                CekEmail = true;
            }
            return CekEmail;
        }

        private static void KirimEmail()
        {
            DateTime FromDate = GlobalVar.GetServerDate.AddDays(-4).Date; //Request pak novi
            DateTime ToDate = GlobalVar.GetServerDate.AddDays(-1).Date;
            DateTime FromDate_Proses = FromDate;

            //Lihat di Tabel EmailAlertModul
            String Module = "SelisihSaldo";

            DataTable dt_lampiran = new DataTable();
            dt_lampiran.Clear();
            dt_lampiran.Columns.Add("Tgl");
            dt_lampiran.Columns.Add("Filename");

            DataTable dt_BodyEmail = new DataTable();
            dt_BodyEmail.Clear();
            dt_BodyEmail.Columns.Add("Tgl");
            dt_BodyEmail.Columns.Add("KasOpname");
            dt_BodyEmail.Columns.Add("KasAkhir");
            dt_BodyEmail.Columns.Add("Selisih");

            while (FromDate_Proses.Date <= ToDate.Date)
            {
                String [] array_email = Createlampiran1(FromDate_Proses, ToDate);
                if ( String.IsNullOrEmpty(array_email[0])== false)
                {
                    DataRow _lampiran = dt_lampiran.NewRow();
                    _lampiran["Tgl"] = FromDate_Proses.ToString("ddMMyyyy");
                    _lampiran["Filename"] = array_email.GetValue(0).ToString();
                    dt_lampiran.Rows.Add(_lampiran);

                    DataRow _BodyEmail = dt_BodyEmail.NewRow();
                    _BodyEmail["Tgl"] = FromDate_Proses.ToString("dd MMM yyyy");
                    _BodyEmail["KasOpname"] = array_email.GetValue(1).ToString();
                    _BodyEmail["KasAkhir"] = array_email.GetValue(2).ToString();
                    _BodyEmail["Selisih"] = array_email.GetValue(3).ToString();
                    dt_BodyEmail.Rows.Add(_BodyEmail);
                }
                FromDate_Proses = FromDate_Proses.AddDays(1);
            }

            String[] array_email2 = CreateLampiranHarian();
            if (String.IsNullOrEmpty(array_email2[0]) == false)
            {
                DataRow _lampiran = dt_lampiran.NewRow();
                _lampiran["Tgl"] = Today.ToString("ddMMyyyy");
                _lampiran["Filename"] = array_email2.GetValue(0).ToString();
                dt_lampiran.Rows.Add(_lampiran);
            }

            if (dt_lampiran.Rows.Count > 0)
            {
                //Bikin Subject dan Body Email
                String MSubject = "Laporan Perbandingan Saldo Kas dan Laporan Harian – " + GlobalVar.Gudang;
                String MBody = isiPesan(dt_BodyEmail, FromDate, ToDate);
                
                DataTable dt_penerima = PenerimaEmail(@Module);
                SendEmail(FromDate, ToDate, dt_lampiran, dt_penerima, MSubject, MBody, Module);

                foreach (DataRow dr in dt_lampiran.Rows)
                {
                    File.Delete(dr["Filename"].ToString());
                }
            }
        }

        private static string isiPesan(DataTable dt_BodyEmail, DateTime FromDate, DateTime ToDate)
        {
            string s = "<html>";
            s += "<body>";            
            //s += "<br>Periode  : " + FromDate.ToString("dd-MM-yyyy") + " S/D " + ToDate.ToString("dd-MM-yyyy");

            s += "Berikut merupakan email otomatis dari aplikasi ISAFinance Otomotif. Untuk meningkatkan kontrol keuangan, sehubungan dengan adanya ketidaksamaan saldo Kas Opname dengan saldo Laporan Mutasi Kas & Bank maka melalui email ini kami sampaikan informasi ringkasan saldo tersebut, sebagai berikut:<br>";
            s += "<br>"+ GlobalVar.PerusahaanName.ToString();            
            s += "<br>Cabang   : " + GlobalVar.CabangID.ToString();
            s += "<br>Jenis Transaksi : Kas Besar";
            s += "<table border='1' style='text-align:right;border-collapse:collapse;padding:2px 2px 2px 2px;'><tr style='text-align:center; font-weight:bold;'><td style='width:100px;background-color:#CED8F6;'>Tanggal</td><td style='width:150px;background-color:#CED8F6'>Saldo Kas Opname</td><td style='width:150px;background-color:#CED8F6'>Saldo Mutasi kas & Bank</td><td style='width:150px;background-color:#CED8F6'>Perbedaan Saldo</td></tr>";
            foreach (DataRow dr in dt_BodyEmail.Rows)
            {
                s += "<tr><td style='text-align:left'>" + dr["Tgl"].ToString() + "</td>";
                s += "<td>" + dr["KasOpname"].ToString() + "</td>";
                s += "<td>" + dr["KasAkhir"].ToString() + "</td>";
                s += "<td>" + dr["Selisih"].ToString() + "</td></tr>";
            }
            s += "</table>";

            s += "<br>untuk membantu pengecekan ketidaksamaan saldo, terlampir file excel detail laporan di atas.";
            s += "<br>Sebagai tambahan informasi email ini akan senantiasa otomatis dikirim jika masih terdapat ketidaksamaan antara saldo kas opname dengan saldo laporan mutasi kas & bank pada aplikasi ISAFinance Otomotif selama 3(tiga) hari ke belakang dari hari ini.";
            s += "<br><br>Terimakasih.<br><br>";
            s += "<body><footer>*mohon tidak membalas email ini.</footer></html>";
            return s;
        }

        private static DataTable PenerimaEmail(String Module)
        {
            DataTable dt_penerima = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_EmailOto_ListPenerima"));
                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.VarChar, Module));
                dt_penerima = db.Commands[0].ExecuteDataTable();
            }
            return dt_penerima;
        }

        private static String[] Createlampiran1(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtTrans = new DataTable();
            Double _KasAkhir = 0;
            Double Debet = 0; Double Kredit = 0;
            Double _KasOpname = 0; Double _KasAwal = 0;
            String fileLampiran = "";
            Guid _KasRowID;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_EmailOto_GetKasRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                _KasRowID = new Guid(db.Commands[0].ExecuteScalar().ToString());
            }


            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TransaksiKas_LIST_FILTER_Tanggal"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, FromDate.Date));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, FromDate.Date));
                db.Commands[0].Parameters.Add(new Parameter("@InOut", SqlDbType.Char, 'A'));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                db.Commands[0].Parameters.Add(new Parameter("@PilihanTransaksi", SqlDbType.Int, 0));
                db.Commands[0].Parameters.Add(new Parameter("@IsVendor", SqlDbType.Bit, 0));
                db.Commands[0].Parameters.Add(new Parameter("@Kas", SqlDbType.Bit, 1));
                db.Commands[0].Parameters.Add(new Parameter("@Giro", SqlDbType.Bit, 0));
                db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.Bit, 0));
                dtTrans = db.Commands[0].ExecuteDataTable();
                dtTrans.DefaultView.Sort = "Tanggal";

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GetSaldoKasV2"));
                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, ""));
                db.Commands[0].Parameters.Add(new Parameter("@tglsaldoawal", SqlDbType.Date, FromDate.Date));

                _KasAwal = Double.Parse(Tools.isNull(db.Commands[0].ExecuteScalar(), "0").ToString());
                _KasAkhir += _KasAwal;
            }

            if (!String.IsNullOrEmpty(dtTrans.Compute("SUM(Debet)", "").ToString()))
            {
                Debet = Convert.ToDouble(dtTrans.Compute("SUM(Debet)", ""));
                _KasAkhir += Debet;
            }
            if (!String.IsNullOrEmpty(dtTrans.Compute("SUM(Kredit)", "").ToString()))
            {
                Kredit = Convert.ToDouble(dtTrans.Compute("SUM(Kredit)", ""));
                _KasAkhir -= Kredit;
            }

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_KasOpname_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (!String.IsNullOrEmpty(dt.Compute("SUM(Nominal)", "").ToString()))
            {
                _KasOpname = Convert.ToDouble(dt.Compute("SUM(Nominal)", ""));
            }
            
            String[] array = new String[4];
            if (_KasAkhir != _KasOpname)
            {
                DataTable dt_kasOpname = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_EmailOto_KasOpname"));
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.Date, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt_kasOpname = db.Commands[0].ExecuteDataTable();
                }
                if (dtTrans.Rows.Count > 0)
                {
                    fileLampiran = LampiranExcel(dt_kasOpname, FromDate, _KasOpname, dtTrans, _KasAwal, _KasAkhir, ToDate);
                }
            
                array[0]= fileLampiran;
                array[1] = String.Format("{0:N}", _KasOpname).ToString();
                array[2] = String.Format("{0:N}", _KasAkhir).ToString();
                array[3] = String.Format("{0:N}", (_KasOpname - _KasAkhir)).ToString();
            }
            return array ;
        }

        private static String LampiranExcel(DataTable dtKasOpname, DateTime FromDate, Double _kasOpname, DataTable dtTransKasBank, Double _kasAwal, Double _kasAkhir, DateTime ToDate)
        {

            using (ExcelPackage ex = new ExcelPackage())
            {
                //buat workbook
                ex.Workbook.Properties.Author = "ISA SHOWROOM FINANCE";
                ex.Workbook.Properties.Title = "LAPORAN PERBEDAAN SALDO";

                //buat worksheet 1
                ex.Workbook.Worksheets.Add("KasOpname");
                ExcelWorksheet ws = ex.Workbook.Worksheets[1];

                //namai worksheet
                ws.Name = "KasOpname";

                //atur font worksheet
                ws.Cells.Style.Font.Name = "Tahoma";
                ws.Cells.Style.Font.Size = 9;

                //atur lebar kolom
                ws.Cells[1, 1].Worksheet.Column(1).Width = 15;//Satuan
                ws.Cells[1, 2].Worksheet.Column(2).Width = 19;//Lembar
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15;//Jumlah
                ws.Cells[1, 4].Worksheet.Column(4).Width = 8;//

                int maxCol = 4;

                //buat judul laporan
                ws.Cells[1, 1].Value = "Kas Opname "+GlobalVar.PerusahaanName;
                ws.Cells[2, 1].Value = "Periode  :" + FromDate.ToString("dd-MM-yyyy") + " S/D " + FromDate.ToString("dd-MM-yyyy");
                ws.Cells[3, 1].Value = "Cabang   :" + GlobalVar.CabangID.ToString();
                ws.Cells[4, 1].Value = "Tipe Kas : KAS BESAR" ;


                //ws.Cells[3, 1].Value = "Cabang   :" + dtKasOpname.Rows[0]["CabangID"].ToString();
                //ws.Cells[4, 1].Value = "Tipe Kas :" + dtKasOpname.Rows[0]["NamaKas"].ToString();

                //ws.Cells[1, 1, 1, maxCol].Merge = true;
                ws.Cells[1, 1, 1, maxCol].Style.Font.Size = 18;
                ws.Cells[1, 1, 1, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 1, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 4, maxCol].Style.Font.Bold = true;

                int row = 6;
                int rowTable = row;
                int rowTable2 = row;

                //buat header   
                ws.Cells[row, 1].Value = "Satuan";
                ws.Cells[row, 2].Value = "Jum Keping/Lembar";
                ws.Cells[row, 3].Value = "Jumlah";
                ws.Cells[row, 1, row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[row, 1, row, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, 1, row, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[row, 1, row, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                ws.Cells[row, 1, row, 3].Style.Font.Bold = true;
                row++;
                ws.Cells[row++, 1].Value = "Rp 100.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 50.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 20.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 10.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 5.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 2.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 1.000,00 x";
                ws.Cells[row++, 1].Value = "Rp 500,00 x";
                ws.Cells[row++, 1].Value = "Rp 200,00 x";
                ws.Cells[row++, 1].Value = "Rp 100,00 x";
                ws.Cells[row++, 1].Value = "Rp 50,00 x";
                ws.Cells[row++, 1].Value = "Rp 25,00 x";
                ws.Cells[row, 1].Value = "JUMLAH";
                ws.Cells[row, 1].Style.Font.Bold = true;
                ws.Cells[row, 1, row, 2].Merge = true;
                row++;

                if (dtKasOpname.Rows.Count > 0)
                {
                    rowTable++;
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p100000"];
                    ws.Cells[rowTable++, 3].Value = (dtKasOpname.Rows[0]["h100000"]);
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p50000"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h50000"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p20000"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h20000"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p10000"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h10000"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p5000"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h5000"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p2000"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h2000"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p1000"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h1000"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p500"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h500"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p200"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h200"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p100"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h100"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p50"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h50"];
                    ws.Cells[rowTable, 2].Value = dtKasOpname.Rows[0]["p25"];
                    ws.Cells[rowTable++, 3].Value = dtKasOpname.Rows[0]["h25"];
                    ws.Cells[rowTable, 3].Value = _kasOpname;
                    ws.Cells[rowTable, 3].Style.Font.Bold = true;
                }

                //atur border tabel
                var border = ws.Cells[rowTable2, 1, rowTable, 3].Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                ws.Cells[rowTable2 + 1, 1, row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[rowTable2 + 1, 1, row, 3].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";




                //==================================================================================================================================//
                //buat worksheet 2
                ex.Workbook.Worksheets.Add("LapTransKas&Bank");
                ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

                //namai worksheet
                ws2.Name = "Mutasi Kas";

                //atur font worksheet
                ws2.Cells.Style.Font.Name = "Tahoma";
                ws2.Cells.Style.Font.Size = 9;

                //atur lebar kolom
                ws2.Cells[1, 1].Worksheet.Column(1).Width = 10;//Tanggal
                ws2.Cells[1, 2].Worksheet.Column(2).Width = 15;//No Bukti
                ws2.Cells[1, 3].Worksheet.Column(3).Width = 5;//DCab
                ws2.Cells[1, 4].Worksheet.Column(4).Width = 5;//KCab
                ws2.Cells[1, 5].Worksheet.Column(5).Width = 60;//Uraian
                ws2.Cells[1, 6].Worksheet.Column(6).Width = 6;//Jenis
                ws2.Cells[1, 7].Worksheet.Column(7).Width = 16;//Debet
                ws2.Cells[1, 8].Worksheet.Column(8).Width = 16;//Kredit
                ws2.Cells[1, 9].Worksheet.Column(9).Width = 5;//PT
                ws2.Cells[1, 10].Worksheet.Column(10).Width = 30;//NamaBank
                ws2.Cells[1, 11].Worksheet.Column(11).Width = 8;//NoGiro
                ws2.Cells[1, 12].Worksheet.Column(12).Width = 10;//TglJatuhTempo
                ws2.Cells[1, 13].Worksheet.Column(13).Width = 10;//Matauang
                ws2.Cells[1, 14].Worksheet.Column(14).Width = 15;//Nilai Ori
                ws2.Cells[1, 15].Worksheet.Column(15).Width = 10;//Kurs
                ws2.Cells[1, 16].Worksheet.Column(16).Width = 25;//Jnis Transaksi

                maxCol = 16;

                //buat judul laporan
                ws2.Cells[1, 1].Value = "";
                ws2.Cells[2, 1].Value = "Transaksi Kas " + GlobalVar.PerusahaanName;
                ws2.Cells[3, 1].Value = "Periode  : " + FromDate.ToString("dd-MM-yyyy") + " S/D " + FromDate.ToString("dd-MM-yyyy");
                ws2.Cells[4, 1].Value = "Cabang   : " + GlobalVar.CabangID.ToString();
                ws2.Cells[5, 1].Value = "Jenis Transaksi : Kas Besar (Semua transaksi)";

                ws2.Cells[2, 1, 2, maxCol].Merge = true;
                ws2.Cells[2, 1, 2, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[2, 1, 2, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[2, 1, 2, maxCol].Style.Font.Size = 18;
                ws2.Cells[2, 1, 5, maxCol].Style.Font.Bold = true;

                row = 7;
                rowTable = row;
                rowTable2 = row;

                //buat header   
                ws2.Cells[row, 1].Value = "Tanggal";
                ws2.Cells[row, 2].Value = "No Bukti";
                ws2.Cells[row, 3].Value = "Dari Cab";
                ws2.Cells[row, 4].Value = "Ke Cab";
                ws2.Cells[row, 5].Value = "Uraian";
                ws2.Cells[row, 6].Value = "Jenis";
                ws2.Cells[row, 7].Value = "Debet";
                ws2.Cells[row, 8].Value = "Kredit";
                ws2.Cells[row, 9].Value = "PT";
                ws2.Cells[row, 10].Value = "Nama Bank";
                ws2.Cells[row, 11].Value = "No Giro";
                ws2.Cells[row, 12].Value = "Tgl Jatuh Tempo";
                ws2.Cells[row, 13].Value = "Matauang";
                ws2.Cells[row, 14].Value = "Nilai (Ori)";
                ws2.Cells[row, 15].Value = "Kurs";
                ws2.Cells[row, 16].Value = "Jenis Transaksi";

                //atur style header
                ws2.Cells[row, 1, row, maxCol].Style.Font.Bold = true;
                ws2.Cells[row, 1, row, maxCol].Style.WrapText = true;
                ws2.Cells[row, 1, row, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[row, 1, row, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[row, 1, row, maxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[row, 1, row, maxCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                row++;

                //isikan data ke tabel
                ws2.Cells[row, 7].Value = _kasAwal;
                ws2.Cells[row, 5].Value = "SALDO AWAL";
                row++;

                Double Dbt = _kasAwal; Double Kdt = 0;
                if (dtTransKasBank.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTransKasBank.Rows)
                    {
                        ws2.Cells[row, 1].Value = dr["Tanggal"];
                        ws2.Cells[row, 2].Value = dr["NoBukti"];
                        ws2.Cells[row, 3].Value = dr["CabangDari"];
                        ws2.Cells[row, 4].Value = dr["CabangKe"];
                        ws2.Cells[row, 5].Value = dr["Uraian"];
                        ws2.Cells[row, 6].Value = dr["Jenis"];
                        ws2.Cells[row, 7].Value = dr["Debet"];
                        ws2.Cells[row, 8].Value = dr["Kredit"];
                        ws2.Cells[row, 9].Value = dr["InitPerusahaan"];
                        ws2.Cells[row, 10].Value = dr["NamaBank"];
                        ws2.Cells[row, 11].Value = dr["NoCekGiro"];
                        ws2.Cells[row, 12].Value = dr["DueDateGiro"];
                        ws2.Cells[row, 13].Value = dr["MataUangID"];
                        ws2.Cells[row, 14].Value = dr["NominalOri"];
                        ws2.Cells[row, 15].Value = (Convert.ToDouble(dr["Debet"]) + Convert.ToDouble(dr["Kredit"])) / Convert.ToDouble(dr["NominalOri"]);
                        ws2.Cells[row, 16].Value = dr["JnsTransaksi"];
                        row++;
                    }

                    if (!String.IsNullOrEmpty(dtTransKasBank.Compute("SUM(Debet)", "").ToString()))
                    {
                        Dbt += Convert.ToDouble(dtTransKasBank.Compute("SUM(Debet)", ""));
                    }
                    if (!String.IsNullOrEmpty(dtTransKasBank.Compute("SUM(Kredit)", "").ToString()))
                    {
                        Kdt = Convert.ToDouble(dtTransKasBank.Compute("SUM(Kredit)", ""));
                    }
                    ws2.Cells[row, 1].Value = "TOTAL  ";
                    ws2.Cells[row + 1, 1].Value = "SALDO  ";

                    ws2.Cells[row, 7].Value = Dbt;
                    ws2.Cells[row, 8].Value = Kdt;
                }
                //atur border tabel
                var border2 = ws2.Cells[rowTable, 1, row + 1, maxCol].Style.Border;
                border2.Bottom.Style = border2.Top.Style = border2.Left.Style = border2.Right.Style = ExcelBorderStyle.Thin;

                //formatting tanggal dan harga
                ws2.Cells[rowTable + 1, 1, row, 1].Style.Numberformat.Format = "dd-MM-yyyy";
                ws2.Cells[rowTable + 1, 12, row, 12].Style.Numberformat.Format = "dd-MM-yyyy";
                ws2.Cells[rowTable + 1, 5, row, 5].Style.WrapText = true;
                //ws2.Cells[rowTable + 1, 6, row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //ws2.Cells[rowTable + 1, 5, row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[rowTable + 1, 7, row + 1, 8].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws2.Cells[rowTable + 1, 14, row, 14].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws2.Cells[row, 1, row, 6].Merge = true;
                row++;
                
                ws2.Cells[row, 7].Value = Dbt - Kdt;
                ws2.Cells[row, 1, row, 6].Merge = true;
                ws2.Cells[row - 1, 1, row, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws2.Cells[row - 1, 1, row, maxCol].Style.Font.Bold = true;
            
                row++; row++; row++;
                ws2.Cells[row, 1].Value =
                    "Berdasarkan laporan kas opname [sheet 1] dan laporan saldo akhir mutasi kas di atas, terdapat perbedaan saldo sebesar ";
                ws2.Cells[row, 8].Value = (_kasOpname - _kasAkhir);
                row++; row++;
                ws2.Cells[row, 2].Value = ToDate.ToString("ddMMMyyyy") + "-" + GlobalVar.Gudang + "-" + GlobalVar.PerusahaanName;

                //Atur Footer
                ws2.Cells[row - 2, 1, row - 2, 7].Merge = true;
                ws2.Cells[row - 2, 1, row - 2, 8].Style.Font.Bold = true;
                ws2.Cells[row - 2, 1, row - 2, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws2.Cells[row - 2, 1, row - 2, 7].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws2.Cells[row - 2, 8].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws2.Cells[row - 3, 1, row - 1, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells[row - 3, 1, row - 1, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                var border3 = ws2.Cells[row - 3, 1, row - 3, 9].Style.Border;
                var border4 = ws2.Cells[row - 3, 9, row - 1, 9].Style.Border;
                var border5 = ws2.Cells[row - 1, 1, row - 1, 9].Style.Border;
                var border6 = ws2.Cells[row - 3, 1, row - 1, 1].Style.Border;

                border5.Bottom.Style = border3.Top.Style = border6.Left.Style = border4.Right.Style = ExcelBorderStyle.Thin;
                ws2.Cells[row, 2].Style.Font.Size = 8;
                ws2.Cells[row, 2].Style.Font.Name = "Arial";


                Byte[] bin = ex.GetAsByteArray();
                SaveFileDialog sv = new SaveFileDialog();
                sv.FileName = "C:\\Temp\\" + FromDate.ToString("dd MMM yyyy") + " - PERBANDINGAN SALDO KAS" + ".xlsx";
                //sv.FileName = "C:\\Temp\\" + GlobalVar.GetServerDate.ToString("dd MMM yyyy") + " - PERBANDINGAN SALDO KAS - " + FromDate.ToString("dd MMM yyyy") + ".xlsx";
                string file = sv.FileName.ToString();
                File.WriteAllBytes(file, bin);

                return file;
            }
        }

        private static void SendEmail(DateTime FromDate, DateTime ToDate, DataTable dt_attachment, DataTable dt_MailTo, String Subject, String Body, String Module)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(ISA.Showroom.Finance.Properties.Settings.Default.Smtp.ToString());

            mail.From = new MailAddress(ISA.Showroom.Finance.Properties.Settings.Default.smtpLogin.ToString());
            foreach (DataRow dr in dt_MailTo.Rows)
            {
                mail.To.Add(dr["Email"].ToString());
            }

            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            SmtpServer.Port = Convert.ToInt32(ISA.Showroom.Finance.Properties.Settings.Default.smtpPort.ToString());
            SmtpServer.Credentials = new System.Net.NetworkCredential(ISA.Showroom.Finance.Properties.Settings.Default.smtpLogin.ToString(), ISA.Showroom.Finance.Properties.Settings.Default.smtpPass.ToString());
            SmtpServer.EnableSsl = true;

            if (dt_attachment.Rows.Count > 0)
            {
                //Upload file
                foreach (DataRow dr in dt_attachment.Rows)
                {
                    String attachmentFilename = dr["Filename"].ToString();
                    Attachment attachment = new Attachment(attachmentFilename);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                    disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                    disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                    disposition.FileName = Path.GetFileName(attachmentFilename);
                    disposition.Size = new FileInfo(attachmentFilename).Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    mail.Attachments.Add(attachment);
                }
            }
            SmtpServer.Send(mail);
            mail.Dispose();
            SaveLog(Module, Subject);
        }

        private static void SaveLog(String Module, String Keterangan)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_EmailOto_SaveLog"));
                db.Commands[0].Parameters.Add(new Parameter("@Module", SqlDbType.VarChar, Module));
                db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, GlobalVar.GetServerDate));
                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Keterangan));
                db.Commands[0].Parameters.Add(new Parameter("@LastCreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteDataTable();
            }
        }


        private static String[] CreateLampiranHarian()
        {
            DataSet ds_BARU_BEKAS = new DataSet();
            String fileLampiran = "";

            DataTable dtSaldo = new DataTable();
            dtSaldo.Columns.Add("Keterangan", typeof(string));
            dtSaldo.Columns.Add("Nilai", typeof(double));

            object saldoawal;


            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_EmailOto_LaporanHarian"));
                ds_BARU_BEKAS = db.Commands[0].ExecuteDataSet();
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetSaldoKasV2"));
                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, ""));
                db.Commands[0].Parameters.Add(new Parameter("@tglsaldoawal", SqlDbType.DateTime, AwalBlnLalu));
                saldoawal = db.Commands[0].ExecuteScalar();
                dtSaldo.Rows.Add("SaldoAwalBulanLalu", Convert.ToDouble(saldoawal));
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetSaldoKasV2"));
                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, ""));
                db.Commands[0].Parameters.Add(new Parameter("@tglsaldoawal", SqlDbType.DateTime, AwalBlnIni));
                saldoawal = db.Commands[0].ExecuteScalar();
                dtSaldo.Rows.Add("SaldoAwalBulanIni", Convert.ToDouble(saldoawal));
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetSaldoKasV2"));
                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, ""));
                db.Commands[0].Parameters.Add(new Parameter("@tglsaldoawal", SqlDbType.DateTime, Today));
                saldoawal = db.Commands[0].ExecuteScalar();
                dtSaldo.Rows.Add("SaldoAwalHariIni", Convert.ToDouble(saldoawal));
            }



            String[] array = new String[1];
            fileLampiran = LampiranExcelLapHarian(ds_BARU_BEKAS, dtSaldo);
            array[0] = fileLampiran;

            return array;
        }

        private static String LampiranExcelLapHarian(DataSet dsBARU_BEKAS, DataTable dtSaldo)
        {
            try
            {
                using (ExcelPackage ex = new ExcelPackage())
                {
                    //buat workbook
                    ex.Workbook.Properties.Author = "ISA SHOWROOM FINANCE";
                    ex.Workbook.Properties.Title = "LAPORAN HARIAN";

                    ////====================   WS : BARU  ==============================================================================================================//
                    #region
                    //buat worksheet 1
                    ex.Workbook.Worksheets.Add("BARU");
                    ExcelWorksheet ws = ex.Workbook.Worksheets[1];

                    //namai worksheet
                    ws.Name = "BARU";

                    //atur font worksheet
                    ws.Cells.Style.Font.Name = "Tahoma";
                    ws.Cells.Style.Font.Size = 9;

                    //atur lebar kolom
                    ws.Cells[1, 1].Worksheet.Column(1).Width = 5;//A
                    ws.Cells[1, 2].Worksheet.Column(2).Width = 20;//B
                    ws.Cells[1, 3].Worksheet.Column(3).Width = 20;//C
                    ws.Cells[1, 4].Worksheet.Column(4).Width = 20;//D
                    ws.Cells[1, 5].Worksheet.Column(5).Width = 20;//E
                    ws.Cells[1, 6].Worksheet.Column(6).Width = 20;//F
                    ws.Cells[1, 7].Worksheet.Column(7).Width = 20;//G
                    ws.Cells[1, 8].Worksheet.Column(8).Width = 20;//H
                    ws.Cells[1, 9].Worksheet.Column(9).Width = 20;//I

                    int maxCol = 9;

                    //buat judul laporan
                    ws.Cells[1, 1].Value = "Laporan Harian - " + GlobalVar.PerusahaanName;
                    ws.Cells[2, 1].Value = "Tanggal  :" + GlobalVar.GetServerDate.Date.ToString("dd-MM-yyyy");
                    ws.Cells[3, 1].Value = "Cabang   :" + GlobalVar.CabangID.ToString();
                    ws.Cells[4, 1].Value = "BARU";


                    ws.Cells[1, 1, 1, maxCol].Merge = true;
                    ws.Cells[1, 1, 1, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[1, 1, 1, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1, 1, maxCol].Style.Font.Size = 18;
                    ws.Cells[1, 1, 5, maxCol].Style.Font.Bold = true;

                    int row = 6;
                    int rowTable = row;
                    int rowTable2 = row; ;

                    //  ----------------------  Laporan Stock  -------------
                    #region
                    //buat header   
                    ws.Cells[row, 2].Value = "Laporan Stock";
                    ws.Cells[row, 4].Value = "Tgl " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws.Cells[row + 1, 4].Value = "Bulan Lalu";
                    ws.Cells[row + 2, 4].Value = "Unit";
                    ws.Cells[row + 2, 5].Value = "Rp";
                    ws.Cells[row + 1, 6].Value = "Bulan Ini";
                    ws.Cells[row + 2, 6].Value = "Unit";
                    ws.Cells[row + 2, 7].Value = "Rp";

                    ws.Cells[row, 8].Value = "Hari ini Tgl " + Today.ToString("dd/MM/yyyy");
                    ws.Cells[row + 2, 8].Value = "Unit";
                    ws.Cells[row + 2, 9].Value = "Rp";


                    //atur style header

                    ws.Cells[row, 2, row + 2, maxCol].Style.Font.Bold = true;
                    ws.Cells[row, 2, row + 2, 3].Style.WrapText = true; //lap Stock
                    ws.Cells[row, 4, row, 7].Style.WrapText = true; //Tgl pertama
                    ws.Cells[row + 1, 4, row + 1, 5].Style.WrapText = true; //bulan lalu
                    ws.Cells[row + 1, 6, row + 1, 7].Style.WrapText = true; //bulan ini
                    ws.Cells[row, 8, row + 1, 9].Style.WrapText = true; //Tgl hari ini

                    ws.Cells[row, 2, row + 2, 3].Merge = true; //lap Stock
                    ws.Cells[row, 4, row, 7].Merge = true; //Tgl pertama
                    ws.Cells[row + 1, 4, row + 1, 5].Merge = true; //bulan lalu
                    ws.Cells[row + 1, 6, row + 1, 7].Merge = true; //bulan ini
                    ws.Cells[row, 8, row + 1, 9].Merge = true; //Tgl hari ini


                    ws.Cells[row, 2, row + 2, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[row, 2, row + 2, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, 2, row + 2, maxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[row, 2, row + 2, maxCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    row = 9;

                    if (dsBARU_BEKAS.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBARU_BEKAS.Tables[0].Rows)
                        {
                            ws.Cells[row, 2, row, 3].Merge = true;
                            ws.Cells[row, 2].Value = dr["Keterangan"];
                            ws.Cells[row, 4].Value = dr["QtyBulanLalu"];
                            ws.Cells[row, 5].Value = dr["NomBulanLalu"];
                            ws.Cells[row, 6].Value = dr["QtyBulanIni"];
                            ws.Cells[row, 7].Value = dr["NomBulanIni"];
                            ws.Cells[row, 8].Value = dr["QtyHariIni"];
                            ws.Cells[row, 9].Value = dr["NomHariIni"];
                            row++;
                        }
                    }
                    //atur border tabel
                    var border = ws.Cells[rowTable, 2, row - 1, maxCol].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    //formatting tanggal dan harga
                    ws.Cells[rowTable + 3, 4, row, maxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion
                    // -----------------        Laporan Penjualan
                    #region
                    //buat header   
                    ws.Cells[row, 2].Value = "Laporan Penjualan";
                    ws.Cells[row, 4].Value = "Tgl " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws.Cells[row + 1, 4].Value = "Bulan Lalu";
                    ws.Cells[row + 1, 5].Value = "Bulan Ini";

                    ws.Cells[row, 6].Value = "Hari ini Tgl " + Today.ToString("dd/MM/yyyy");


                    //atur style header

                    ws.Cells[row, 2, row + 1, 6].Style.Font.Bold = true;
                    ws.Cells[row, 2, row + 1, 3].Style.WrapText = true; //lap Penjualan
                    ws.Cells[row, 4, row, 7].Style.WrapText = true; //Tgl pertama

                    ws.Cells[row, 2, row + 1, 3].Merge = true; //lap Stock
                    ws.Cells[row, 4, row, 5].Merge = true; //Tgl pertama
                    ws.Cells[row, 6, row + 1, 6].Merge = true; //Tgl hari ini


                    ws.Cells[row, 2, row + 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[row, 2, row + 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, 2, row + 1, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[row, 2, row + 1, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    rowTable = row;
                    row = row + 2;

                    if (dsBARU_BEKAS.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBARU_BEKAS.Tables[1].Rows)
                        {
                            ws.Cells[row, 2, row, 3].Merge = true;
                            ws.Cells[row, 2].Value = dr["Keterangan"];
                            ws.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                    }
                    //atur border tabel
                    var border2 = ws.Cells[rowTable, 2, row - 1, 6].Style.Border;
                    border2.Bottom.Style = border2.Top.Style = border2.Left.Style = border2.Right.Style = ExcelBorderStyle.Thin;

                    //formatting tanggal dan harga
                    ws.Cells[rowTable + 2, 4, row, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion

                    // -----------------        Laporan Cash Flow
                    #region
                    //buat header   
                    int row_jmlSaldoAwal;
                    int row_jmlPenerimaan;
                    int row_jmlPengeluaran;
                    int row_jmlMutasi;

                    ws.Cells[row, 2].Value = "Laporan Cash Flow";
                    ws.Cells[row, 4].Value = "Tgl " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws.Cells[row + 1, 4].Value = "Bulan Lalu";
                    ws.Cells[row + 1, 5].Value = "Bulan Ini";
                    ws.Cells[row, 6].Value = "Hari ini Tgl " + Today.ToString("dd/MM/yyyy");


                    //atur style header

                    ws.Cells[row, 2, row + 1, 6].Style.Font.Bold = true;
                    ws.Cells[row, 2, row + 1, 3].Style.WrapText = true;
                    ws.Cells[row, 4, row, 6].Style.WrapText = true;

                    ws.Cells[row, 2, row + 1, 3].Merge = true; //lap CF
                    ws.Cells[row, 4, row, 5].Merge = true; //Tgl pertama
                    ws.Cells[row, 6, row + 1, 6].Merge = true; //Tgl hari ini


                    ws.Cells[row, 2, row + 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[row, 2, row + 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, 2, row + 1, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[row, 2, row + 1, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    rowTable = row;
                    row = row + 2;
                    if (dsBARU_BEKAS.Tables[1].Rows.Count > 0)
                    {
                        DataTable dt_Saldo = new DataTable();
                        DataTable dt_penerimaan = new DataTable();
                        DataTable dt_pengeluaran = new DataTable();
                        DataTable dt_Mutasi = new DataTable();

                        dt_Saldo = dsBARU_BEKAS.Tables[4].Copy();
                        dt_Saldo.DefaultView.RowFilter = "Jenis='Saldo'";

                        dt_penerimaan = dsBARU_BEKAS.Tables[4].Copy();
                        dt_penerimaan.DefaultView.RowFilter = "Jenis='Penerimaan'";

                        dt_pengeluaran = dsBARU_BEKAS.Tables[4].Copy();
                        dt_pengeluaran.DefaultView.RowFilter = "Jenis='Pengeluaran'";

                        dt_Mutasi = dsBARU_BEKAS.Tables[4].Copy();
                        dt_Mutasi.DefaultView.RowFilter = "Jenis='Mutasi'";

                        ws.Cells[row, 2].Value = "SALDO :";
                        row++;
                        rowTable2 = row;
                        ws.Cells[row, 3].Value = "Kas";
                        ws.Cells[row, 4].Value = dtSaldo.Rows[0]["Nilai"];
                        ws.Cells[row, 5].Value = dtSaldo.Rows[1]["Nilai"];
                        ws.Cells[row, 6].Value = dtSaldo.Rows[2]["Nilai"];
                        row++;
                        ws.Cells[row, 3].Value = "Bank";
                        foreach (DataRow dr in dt_Saldo.DefaultView.ToTable().Rows)
                        {
                            //ws.Cells[row, 2].Value = dr["Jenis"];
                            ws.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlSaldoAwal = row;
                        ws.Cells[row, 2].Value = "Jumlah";
                        ws.Cells[row, 4].Formula = "SUM(" + ws.Cells[rowTable2, 4].Address + ":" + ws.Cells[row - 1, 4].Address + ")";
                        ws.Cells[row, 5].Formula = "SUM(" + ws.Cells[rowTable2, 5].Address + ":" + ws.Cells[row - 1, 5].Address + ")";
                        ws.Cells[row, 6].Formula = "SUM(" + ws.Cells[rowTable2, 6].Address + ":" + ws.Cells[row - 1, 6].Address + ")";
                        ws.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++; row++;


                        ws.Cells[row, 2].Value = "Penerimaan :";
                        row++;
                        rowTable2 = row;
                        foreach (DataRow dr in dt_penerimaan.DefaultView.ToTable().Rows)
                        {
                            //ws.Cells[row, 2].Value = dr["Jenis"];
                            ws.Cells[row, 3].Value = dr["Keterangan"];
                            ws.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlPenerimaan = row;
                        ws.Cells[row, 2].Value = "Jumlah";
                        ws.Cells[row, 4].Formula = "SUM(" + ws.Cells[rowTable2, 4].Address + ":" + ws.Cells[row - 1, 4].Address + ")";
                        ws.Cells[row, 5].Formula = "SUM(" + ws.Cells[rowTable2, 5].Address + ":" + ws.Cells[row - 1, 5].Address + ")";
                        ws.Cells[row, 6].Formula = "SUM(" + ws.Cells[rowTable2, 6].Address + ":" + ws.Cells[row - 1, 6].Address + ")";
                        ws.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++; row++;

                        ws.Cells[row, 2].Value = "Pengeluaran :";
                        row++;
                        rowTable2 = row;
                        foreach (DataRow dr in dt_pengeluaran.DefaultView.ToTable().Rows)
                        {
                            //ws.Cells[row, 2].Value = dr["Jenis"];
                            ws.Cells[row, 3].Value = dr["Keterangan"];
                            ws.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlPengeluaran = row;
                        ws.Cells[row, 2].Value = "Jumlah";
                        ws.Cells[row, 4].Formula = "SUM(" + ws.Cells[rowTable2, 4].Address + ":" + ws.Cells[row - 1, 4].Address + ")";
                        ws.Cells[row, 5].Formula = "SUM(" + ws.Cells[rowTable2, 5].Address + ":" + ws.Cells[row - 1, 5].Address + ")";
                        ws.Cells[row, 6].Formula = "SUM(" + ws.Cells[rowTable2, 6].Address + ":" + ws.Cells[row - 1, 6].Address + ")";
                        ws.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++; row++;


                        ws.Cells[row, 2].Value = "Mutasi :";
                        row++;
                        rowTable2 = row;
                        foreach (DataRow dr in dt_Mutasi.DefaultView.ToTable().Rows)
                        {
                            ws.Cells[row, 3].Value = dr["Keterangan"];
                            ws.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlMutasi = row;
                        ws.Cells[row, 2].Value = "Jumlah";
                        ws.Cells[row, 4].Formula = "SUM(" + ws.Cells[rowTable2, 4].Address + ":" + ws.Cells[row - 1, 4].Address + ")";
                        ws.Cells[row, 5].Formula = "SUM(" + ws.Cells[rowTable2, 5].Address + ":" + ws.Cells[row - 1, 5].Address + ")";
                        ws.Cells[row, 6].Formula = "SUM(" + ws.Cells[rowTable2, 6].Address + ":" + ws.Cells[row - 1, 6].Address + ")";
                        ws.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++;

                        row++; row++;
                        ws.Cells[row, 2].Value = "SALDO AKHIR";
                        ws.Cells[row, 4].Formula = "(" + ws.Cells[row_jmlSaldoAwal, 4].Address + "+" + ws.Cells[row_jmlPenerimaan, 4].Address + "-" + ws.Cells[row_jmlPengeluaran, 4].Address + "+" + ws.Cells[row_jmlMutasi, 4].Address + ")";
                        ws.Cells[row, 5].Formula = "(" + ws.Cells[row_jmlSaldoAwal, 5].Address + "+" + ws.Cells[row_jmlPenerimaan, 5].Address + "-" + ws.Cells[row_jmlPengeluaran, 5].Address + "+" + ws.Cells[row_jmlMutasi, 5].Address + ")";
                        ws.Cells[row, 6].Formula = "(" + ws.Cells[row_jmlSaldoAwal, 6].Address + "+" + ws.Cells[row_jmlPenerimaan, 6].Address + "-" + ws.Cells[row_jmlPengeluaran, 6].Address + "+" + ws.Cells[row_jmlMutasi, 6].Address + ")";
                        ws.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++;

                    }


                    //atur border tabel
                    border = ws.Cells[rowTable, 2, row - 1, 6].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    //formatting tanggal dan harga
                    ws.Cells[rowTable + 2, 4, row, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion
                    #endregion
                    ////====================   WS : BEKAS  ==============================================================================================================//
                    ////buat worksheet 2
                    #region
                    ex.Workbook.Worksheets.Add("BEKAS");
                    ExcelWorksheet ws2 = ex.Workbook.Worksheets[2];

                    //namai worksheet
                    ws2.Name = "BEKAS";

                    //atur font worksheet
                    ws2.Cells.Style.Font.Name = "Tahoma";
                    ws2.Cells.Style.Font.Size = 9;

                    //atur lebar kolom
                    ws2.Cells[1, 1].Worksheet.Column(1).Width = 5;//A
                    ws2.Cells[1, 2].Worksheet.Column(2).Width = 20;//B
                    ws2.Cells[1, 3].Worksheet.Column(3).Width = 20;//C
                    ws2.Cells[1, 4].Worksheet.Column(4).Width = 20;//D
                    ws2.Cells[1, 5].Worksheet.Column(5).Width = 20;//E
                    ws2.Cells[1, 6].Worksheet.Column(6).Width = 20;//F
                    ws2.Cells[1, 7].Worksheet.Column(7).Width = 20;//G
                    ws2.Cells[1, 8].Worksheet.Column(8).Width = 20;//H
                    ws2.Cells[1, 9].Worksheet.Column(9).Width = 20;//I

                    maxCol = 9;

                    //buat judul laporan
                    ws2.Cells[1, 1].Value = "Laporan Harian - " + GlobalVar.PerusahaanName;
                    ws2.Cells[2, 1].Value = "Tanggal  :" + GlobalVar.GetServerDate.Date.ToString("dd-MM-yyyy");
                    ws2.Cells[3, 1].Value = "Cabang   :" + GlobalVar.CabangID.ToString();
                    ws2.Cells[4, 1].Value = "BEKAS";


                    ws2.Cells[1, 1, 1, maxCol].Merge = true;
                    ws2.Cells[1, 1, 1, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws2.Cells[1, 1, 1, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws2.Cells[1, 1, 1, maxCol].Style.Font.Size = 18;
                    ws2.Cells[1, 1, 5, maxCol].Style.Font.Bold = true;

                    row = 6;
                    rowTable = row;
                    rowTable2 = row; ;

                    //  ---------------------  Laporan Stock        --------------------
                    #region
                    //buat header   
                    ws2.Cells[row, 2].Value = "Laporan Stock";
                    ws2.Cells[row, 4].Value = "Tgl " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws2.Cells[row + 1, 4].Value = "Bulan Lalu";
                    ws2.Cells[row + 2, 4].Value = "Unit";
                    ws2.Cells[row + 2, 5].Value = "Rp";
                    ws2.Cells[row + 1, 6].Value = "Bulan Ini";
                    ws2.Cells[row + 2, 6].Value = "Unit";
                    ws2.Cells[row + 2, 7].Value = "Rp";

                    ws2.Cells[row, 8].Value = "Hari ini Tgl " + Today.ToString("dd/MM/yyyy");
                    ws2.Cells[row + 2, 8].Value = "Unit";
                    ws2.Cells[row + 2, 9].Value = "Rp";


                    //atur style header

                    ws2.Cells[row, 2, row + 2, maxCol].Style.Font.Bold = true;
                    ws2.Cells[row, 2, row + 2, 3].Style.WrapText = true; //lap Stock
                    ws2.Cells[row, 4, row, 7].Style.WrapText = true; //Tgl pertama
                    ws2.Cells[row + 1, 4, row + 1, 5].Style.WrapText = true; //bulan lalu
                    ws2.Cells[row + 1, 6, row + 1, 7].Style.WrapText = true; //bulan ini
                    ws2.Cells[row, 8, row + 1, 9].Style.WrapText = true; //Tgl hari ini

                    ws2.Cells[row, 2, row + 2, 3].Merge = true; //lap Stock
                    ws2.Cells[row, 4, row, 7].Merge = true; //Tgl pertama
                    ws2.Cells[row + 1, 4, row + 1, 5].Merge = true; //bulan lalu
                    ws2.Cells[row + 1, 6, row + 1, 7].Merge = true; //bulan ini
                    ws2.Cells[row, 8, row + 1, 9].Merge = true; //Tgl hari ini


                    ws2.Cells[row, 2, row + 2, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws2.Cells[row, 2, row + 2, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws2.Cells[row, 2, row + 2, maxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws2.Cells[row, 2, row + 2, maxCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    row = 9;

                    if (dsBARU_BEKAS.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBARU_BEKAS.Tables[2].Rows)
                        {
                            ws2.Cells[row, 2, row, 3].Merge = true;
                            ws2.Cells[row, 2].Value = dr["Keterangan"];
                            ws2.Cells[row, 4].Value = dr["QtyBulanLalu"];
                            ws2.Cells[row, 5].Value = dr["NomBulanLalu"];
                            ws2.Cells[row, 6].Value = dr["QtyBulanIni"];
                            ws2.Cells[row, 7].Value = dr["NomBulanIni"];
                            ws2.Cells[row, 8].Value = dr["QtyHariIni"];
                            ws2.Cells[row, 9].Value = dr["NomHariIni"];
                            row++;
                        }
                    }
                    //atur border tabel
                    border = ws2.Cells[rowTable, 2, row - 1, maxCol].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    //formatting tanggal dan harga
                    ws2.Cells[rowTable + 3, 4, row, maxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion

                    // ----------------------  Laporan Penjualan    --------------------
                    #region
                    //buat header   
                    ws2.Cells[row, 2].Value = "Laporan Penjualan";
                    ws2.Cells[row, 4].Value = "Tgl " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws2.Cells[row + 1, 4].Value = "Bulan Lalu";
                    ws2.Cells[row + 1, 5].Value = "Bulan Ini";

                    ws2.Cells[row, 6].Value = "Hari ini Tgl " + Today.ToString("dd/MM/yyyy");


                    //atur style header

                    ws2.Cells[row, 2, row + 1, 6].Style.Font.Bold = true;
                    ws2.Cells[row, 2, row + 1, 3].Style.WrapText = true; //lap Penjualan
                    ws2.Cells[row, 4, row, 7].Style.WrapText = true; //Tgl pertama

                    ws2.Cells[row, 2, row + 1, 3].Merge = true; //lap Stock
                    ws2.Cells[row, 4, row, 5].Merge = true; //Tgl pertama
                    ws2.Cells[row, 6, row + 1, 6].Merge = true; //Tgl hari ini


                    ws2.Cells[row, 2, row + 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws2.Cells[row, 2, row + 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws2.Cells[row, 2, row + 1, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws2.Cells[row, 2, row + 1, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    rowTable = row;
                    row = row + 2;

                    if (dsBARU_BEKAS.Tables[3].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBARU_BEKAS.Tables[3].Rows)
                        {
                            ws2.Cells[row, 2, row, 3].Merge = true;
                            ws2.Cells[row, 2].Value = dr["Keterangan"];
                            ws2.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws2.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws2.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                    }
                    //atur border tabel
                    border2 = ws2.Cells[rowTable, 2, row - 1, 6].Style.Border;
                    border2.Bottom.Style = border2.Top.Style = border2.Left.Style = border2.Right.Style = ExcelBorderStyle.Thin;

                    //formatting tanggal dan harga
                    ws2.Cells[rowTable + 2, 4, row, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion


                    // ----------------------  Laporan Cash Flow    --------------------
                    #region
                    //buat header   
                    ws2.Cells[row, 2].Value = "Laporan Cash Flow";
                    ws2.Cells[row, 4].Value = "Tgl " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws2.Cells[row + 1, 4].Value = "Bulan Lalu";
                    ws2.Cells[row + 1, 5].Value = "Bulan Ini";
                    ws2.Cells[row, 6].Value = "Hari ini Tgl " + Today.ToString("dd/MM/yyyy");


                    //atur style header

                    ws2.Cells[row, 2, row + 1, 6].Style.Font.Bold = true;
                    ws2.Cells[row, 2, row + 1, 3].Style.WrapText = true;
                    ws2.Cells[row, 4, row, 6].Style.WrapText = true;

                    ws2.Cells[row, 2, row + 1, 3].Merge = true; //lap CF
                    ws2.Cells[row, 4, row, 5].Merge = true; //Tgl pertama
                    ws2.Cells[row, 6, row + 1, 6].Merge = true; //Tgl hari ini


                    ws2.Cells[row, 2, row + 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws2.Cells[row, 2, row + 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws2.Cells[row, 2, row + 1, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws2.Cells[row, 2, row + 1, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    rowTable = row;
                    row = row + 2;
                    if (dsBARU_BEKAS.Tables[4].Rows.Count > 0)
                    {
                        DataTable dt_Saldo = new DataTable();
                        DataTable dt_penerimaan = new DataTable();
                        DataTable dt_pengeluaran = new DataTable();
                        DataTable dt_Mutasi = new DataTable();

                        dt_Saldo = dsBARU_BEKAS.Tables[4].Copy();
                        dt_Saldo.DefaultView.RowFilter = "Jenis='Saldo'";

                        dt_penerimaan = dsBARU_BEKAS.Tables[4].Copy();
                        dt_penerimaan.DefaultView.RowFilter = "Jenis='Penerimaan'";

                        dt_pengeluaran = dsBARU_BEKAS.Tables[4].Copy();
                        dt_pengeluaran.DefaultView.RowFilter = "Jenis='Pengeluaran'";

                        dt_Mutasi = dsBARU_BEKAS.Tables[4].Copy();
                        dt_Mutasi.DefaultView.RowFilter = "Jenis='Mutasi'";

                        ws2.Cells[row, 2].Value = "SALDO :";
                        row++;
                        rowTable2 = row;
                        ws2.Cells[row, 3].Value = "Kas";
                        ws2.Cells[row, 4].Value = dtSaldo.Rows[0]["Nilai"];
                        ws2.Cells[row, 5].Value = dtSaldo.Rows[1]["Nilai"];
                        ws2.Cells[row, 6].Value = dtSaldo.Rows[2]["Nilai"];
                        row++;
                        ws2.Cells[row, 3].Value = "Bank";
                        foreach (DataRow dr in dt_Saldo.DefaultView.ToTable().Rows)
                        {
                            //ws2.Cells[row, 2].Value = dr["Jenis"];
                            ws2.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws2.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws2.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlSaldoAwal = row;
                        ws2.Cells[row, 2].Value = "Jumlah";
                        ws2.Cells[row, 4].Formula = "SUM(" + ws2.Cells[rowTable2, 4].Address + ":" + ws2.Cells[row - 1, 4].Address + ")";
                        ws2.Cells[row, 5].Formula = "SUM(" + ws2.Cells[rowTable2, 5].Address + ":" + ws2.Cells[row - 1, 5].Address + ")";
                        ws2.Cells[row, 6].Formula = "SUM(" + ws2.Cells[rowTable2, 6].Address + ":" + ws2.Cells[row - 1, 6].Address + ")";
                        ws2.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++; row++;


                        ws2.Cells[row, 2].Value = "Penerimaan :";
                        row++;
                        rowTable2 = row;
                        foreach (DataRow dr in dt_penerimaan.DefaultView.ToTable().Rows)
                        {
                            //ws2.Cells[row, 2].Value = dr["Jenis"];
                            ws2.Cells[row, 3].Value = dr["Keterangan"];
                            ws2.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws2.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws2.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlPenerimaan = row;
                        ws2.Cells[row, 2].Value = "Jumlah";
                        ws2.Cells[row, 4].Formula = "SUM(" + ws2.Cells[rowTable2, 4].Address + ":" + ws2.Cells[row - 1, 4].Address + ")";
                        ws2.Cells[row, 5].Formula = "SUM(" + ws2.Cells[rowTable2, 5].Address + ":" + ws2.Cells[row - 1, 5].Address + ")";
                        ws2.Cells[row, 6].Formula = "SUM(" + ws2.Cells[rowTable2, 6].Address + ":" + ws2.Cells[row - 1, 6].Address + ")";
                        ws2.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++; row++;

                        ws2.Cells[row, 2].Value = "Pengeluaran :";
                        row++;
                        rowTable2 = row;
                        foreach (DataRow dr in dt_pengeluaran.DefaultView.ToTable().Rows)
                        {
                            //ws2.Cells[row, 2].Value = dr["Jenis"];
                            ws2.Cells[row, 3].Value = dr["Keterangan"];
                            ws2.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws2.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws2.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlPengeluaran = row;
                        ws2.Cells[row, 2].Value = "Jumlah";
                        ws2.Cells[row, 4].Formula = "SUM(" + ws2.Cells[rowTable2, 4].Address + ":" + ws2.Cells[row - 1, 4].Address + ")";
                        ws2.Cells[row, 5].Formula = "SUM(" + ws2.Cells[rowTable2, 5].Address + ":" + ws2.Cells[row - 1, 5].Address + ")";
                        ws2.Cells[row, 6].Formula = "SUM(" + ws2.Cells[rowTable2, 6].Address + ":" + ws2.Cells[row - 1, 6].Address + ")";
                        ws2.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++; row++;


                        ws2.Cells[row, 2].Value = "Mutasi :";
                        row++;
                        rowTable2 = row;
                        foreach (DataRow dr in dt_Mutasi.DefaultView.ToTable().Rows)
                        {
                            ws2.Cells[row, 3].Value = dr["Keterangan"];
                            ws2.Cells[row, 4].Value = dr["NomBulanLalu"];
                            ws2.Cells[row, 5].Value = dr["NomBulanIni"];
                            ws2.Cells[row, 6].Value = dr["NomHariIni"];
                            row++;
                        }
                        row_jmlMutasi = row;
                        ws2.Cells[row, 2].Value = "Jumlah";
                        ws2.Cells[row, 4].Formula = "(" + ws2.Cells[rowTable2, 4].Address + "-" + ws2.Cells[row - 1, 4].Address + ")";
                        ws2.Cells[row, 5].Formula = "(" + ws2.Cells[rowTable2, 5].Address + "-" + ws2.Cells[row - 1, 5].Address + ")";
                        ws2.Cells[row, 6].Formula = "(" + ws2.Cells[rowTable2, 6].Address + "-" + ws2.Cells[row - 1, 6].Address + ")";
                        ws2.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++;

                        row++; row++;
                        ws2.Cells[row, 2].Value = "SALDO AKHIR";
                        ws2.Cells[row, 4].Formula = "(" + ws2.Cells[row_jmlSaldoAwal, 4].Address + "+" + ws2.Cells[row_jmlPenerimaan, 4].Address + "-" + ws2.Cells[row_jmlPengeluaran, 4].Address + "+" + ws2.Cells[row_jmlMutasi, 4].Address + ")";
                        ws2.Cells[row, 5].Formula = "(" + ws2.Cells[row_jmlSaldoAwal, 5].Address + "+" + ws2.Cells[row_jmlPenerimaan, 5].Address + "-" + ws2.Cells[row_jmlPengeluaran, 5].Address + "+" + ws2.Cells[row_jmlMutasi, 5].Address + ")";
                        ws2.Cells[row, 6].Formula = "(" + ws2.Cells[row_jmlSaldoAwal, 6].Address + "+" + ws2.Cells[row_jmlPenerimaan, 6].Address + "-" + ws2.Cells[row_jmlPengeluaran, 6].Address + "+" + ws2.Cells[row_jmlMutasi, 6].Address + ")";
                        ws2.Cells[row, 2, row, 6].Style.Font.Bold = true;
                        row++;

                    }


                    //atur border tabel
                    border = ws2.Cells[rowTable, 2, row - 1, 6].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    //formatting tanggal dan harga
                    ws2.Cells[rowTable + 2, 4, row, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                    row++; row++; row++;
                    #endregion

                    #endregion


                    ////====================   WS : REKAP PENJ DAN PIUT BARU  ==============================================================================================================//
                    ////buat worksheet 3
                    #region
                    ex.Workbook.Worksheets.Add("REKAP PENJ DAN PIUT BARU");
                    ExcelWorksheet ws3 = ex.Workbook.Worksheets[3];

                    //namai worksheet
                    ws3.Name = "REKAP PENJ DAN PIUT BARU";

                    //atur font worksheet
                    ws3.Cells.Style.Font.Name = "Tahoma";
                    ws3.Cells.Style.Font.Size = 9;

                    //atur lebar kolom
                    ws3.Cells[1, 1].Worksheet.Column(1).Width = 5;//A
                    ws3.Cells[1, 2].Worksheet.Column(2).Width = 20;//B
                    ws3.Cells[1, 3].Worksheet.Column(3).Width = 20;//C
                    ws3.Cells[1, 4].Worksheet.Column(4).Width = 20;//D
                    ws3.Cells[1, 5].Worksheet.Column(5).Width = 20;//E
                    ws3.Cells[1, 6].Worksheet.Column(6).Width = 20;//F
                    ws3.Cells[1, 7].Worksheet.Column(7).Width = 20;//G
                    ws3.Cells[1, 8].Worksheet.Column(8).Width = 20;//H
                    ws3.Cells[1, 9].Worksheet.Column(9).Width = 20;//I
                    ws3.Cells[1, 10].Worksheet.Column(10).Width = 20;//J
                    ws3.Cells[1, 11].Worksheet.Column(11).Width = 20;//K
                    ws3.Cells[1, 12].Worksheet.Column(12).Width = 20;//L
                    ws3.Cells[1, 13].Worksheet.Column(13).Width = 20;//M
                    ws3.Cells[1, 14].Worksheet.Column(14).Width = 20;//N
                    ws3.Cells[1, 15].Worksheet.Column(15).Width = 20;//O
                    ws3.Cells[1, 16].Worksheet.Column(16).Width = 20;//P
                    ws3.Cells[1, 17].Worksheet.Column(17).Width = 20;//Q

                    maxCol = 17;

                    //buat judul laporan
                    #region
                    ws3.Cells[1, 1].Value = "LAPORAN PENJUALAN PER SALES - " + GlobalVar.PerusahaanName;
                    ws3.Cells[2, 1].Value = "Periode  : " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws3.Cells[3, 1].Value = "Cabang   : " + GlobalVar.CabangID.ToString();
                    ws3.Cells[4, 1].Value = "REKAP PENJ DAN PIUT BARU";


                    ws3.Cells[1, 1, 1, maxCol].Merge = true;
                    ws3.Cells[1, 1, 1, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws3.Cells[1, 1, 1, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws3.Cells[1, 1, 1, maxCol].Style.Font.Size = 18;
                    ws3.Cells[1, 1, 5, maxCol].Style.Font.Bold = true;
                    #endregion

                    row = 6;
                    rowTable = row;
                    rowTable2 = row; ;

                    //buat header laporan 
                    #region
                    ws3.Cells[row, 2].Value = "NAMA SALES";
                    ws3.Cells[row, 4].Value = "REALISASI PENJUALAN";
                    ws3.Cells[row + 1, 4].Value = "CASH";
                    ws3.Cells[row + 1, 5].Value = "AVALIS";
                    ws3.Cells[row + 1, 6].Value = "LEASING";
                    ws3.Cells[row + 2, 6].Value = "FIF";
                    ws3.Cells[row + 2, 7].Value = "MPMF";
                    ws3.Cells[row + 2, 8].Value = "SOF";
                    ws3.Cells[row + 2, 9].Value = "INDOMOBIL";
                    ws3.Cells[row + 2, 10].Value = "ADIRA";
                    ws3.Cells[row + 2, 11].Value = "RADANA";
                    ws3.Cells[row + 2, 12].Value = "WOM";
                    ws3.Cells[row + 2, 13].Value = "TOTAL";
                    ws3.Cells[row + 1, 14].Value = "TOTAL PENJUALAN";
                    ws3.Cells[row, 15].Value = "TARGET";
                    ws3.Cells[row, 16].Value = "+/-";
                    ws3.Cells[row, 17].Value = "%";


                    //atur style header
                    ws3.Cells[row, 2, row + 2, maxCol].Style.Font.Bold = true;
                    ws3.Cells[row, 2, row + 2, 3].Style.WrapText = true; //Nama Sales
                    ws3.Cells[row + 1, 13, row + 2, 13].Style.WrapText = true; //Total Penjualan

                    ws3.Cells[row, 2, row + 2, 3].Merge = true; //Nama Sales
                    ws3.Cells[row, 4, row, 14].Merge = true; //Realisasi Penjualan
                    ws3.Cells[row + 1, 4, row + 2, 4].Merge = true; //Cash
                    ws3.Cells[row + 1, 5, row + 2, 5].Merge = true; //Avalis
                    ws3.Cells[row + 1, 6, row + 1, 13].Merge = true; //Leasing
                    ws3.Cells[row + 1, 14, row + 1, 14].Merge = true; //Total Penjualan
                    ws3.Cells[row, 15, row + 2, 15].Merge = true; //Target
                    ws3.Cells[row, 16, row + 2, 16].Merge = true; // +/-
                    ws3.Cells[row, 17, row + 2, 17].Merge = true; // %


                    ws3.Cells[row, 2, row + 2, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws3.Cells[row, 2, row + 2, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws3.Cells[row, 2, row + 2, maxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws3.Cells[row, 2, row + 2, maxCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    row = 9;
                    string NamaSalesSebelumnya = "";
                    if (dsBARU_BEKAS.Tables[5].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBARU_BEKAS.Tables[5].Rows)
                        {

                            if (row == 9 || NamaSalesSebelumnya != dr["NamaSales"].ToString())
                            {
                                ws3.Cells[row, 2].Value = dr["NamaSales"];
                                NamaSalesSebelumnya = dr["NamaSales"].ToString();
                            }
                            ws3.Cells[row, 3].Value = dr["Keterangan"];
                            ws3.Cells[row, 4].Value = dr["Cash"];
                            ws3.Cells[row, 5].Value = dr["Avalis"];
                            ws3.Cells[row, 6].Value = dr["Lsg_ADIRA"];
                            ws3.Cells[row, 7].Value = dr["Lsg_FIF"];
                            ws3.Cells[row, 8].Value = dr["Lsg_INDOMOBIL"];
                            ws3.Cells[row, 9].Value = dr["Lsg_MPMF"];
                            ws3.Cells[row, 10].Value = dr["Lsg_RADANA"];
                            ws3.Cells[row, 11].Value = dr["Lsg_SOF"];
                            ws3.Cells[row, 12].Value = dr["Lsg_WOM"];
                            ws3.Cells[row, 13].Formula = "SUM(" + ws3.Cells[row, 6].Address + ":" + ws3.Cells[row, 12].Address + ")"; //Total
                            ws3.Cells[row, 14].Formula = "SUM(" + ws3.Cells[row, 4].Address + ":" + ws3.Cells[row, 12].Address + ")"; //Total Penjualan
                            ws3.Cells[row, 15].Value = dr["TargetSales"];
                            ws3.Cells[row, 16].Formula = "(" + ws3.Cells[row, 14].Address + "-" + ws3.Cells[row, 15].Address + ")"; //Selisih Target
                            ws3.Cells[row, 17].Formula = "(" + ws3.Cells[row, 16].Address + "/" + ws3.Cells[row, 15].Address + ") * 100"; // %
                            row++;
                            if (dr["Keterangan"].ToString() == "Bulan Ini")
                            {
                                ws3.Cells[row, 3].Value = "+/-";
                                ws3.Cells[row, 4].Formula = "(" + ws3.Cells[row - 1, 4].Address + "-" + ws3.Cells[row - 2, 4].Address + ")"; //Cash
                                ws3.Cells[row, 5].Formula = "(" + ws3.Cells[row - 1, 5].Address + "-" + ws3.Cells[row - 2, 5].Address + ")"; //Avalis
                                ws3.Cells[row, 6].Formula = "(" + ws3.Cells[row - 1, 6].Address + "-" + ws3.Cells[row - 2, 6].Address + ")";
                                ws3.Cells[row, 7].Formula = "(" + ws3.Cells[row - 1, 7].Address + "-" + ws3.Cells[row - 2, 7].Address + ")";
                                ws3.Cells[row, 8].Formula = "(" + ws3.Cells[row - 1, 8].Address + "-" + ws3.Cells[row - 2, 8].Address + ")";
                                ws3.Cells[row, 9].Formula = "(" + ws3.Cells[row - 1, 9].Address + "-" + ws3.Cells[row - 2, 9].Address + ")";
                                ws3.Cells[row, 10].Formula = "(" + ws3.Cells[row - 1, 10].Address + "-" + ws3.Cells[row - 2, 10].Address + ")";
                                ws3.Cells[row, 11].Formula = "(" + ws3.Cells[row - 1, 11].Address + "-" + ws3.Cells[row - 2, 11].Address + ")";
                                ws3.Cells[row, 12].Formula = "(" + ws3.Cells[row - 1, 12].Address + "-" + ws3.Cells[row - 2, 12].Address + ")";
                                ws3.Cells[row, 13].Formula = "(" + ws3.Cells[row - 1, 13].Address + "-" + ws3.Cells[row - 2, 13].Address + ")";
                                ws3.Cells[row, 14].Formula = "(" + ws3.Cells[row - 1, 14].Address + "-" + ws3.Cells[row - 2, 14].Address + ")";
                                ws3.Cells[row, 15].Formula = "(" + ws3.Cells[row - 1, 15].Address + "-" + ws3.Cells[row - 2, 15].Address + ")";
                                ws3.Cells[row, 16].Formula = "(" + ws3.Cells[row - 1, 16].Address + "-" + ws3.Cells[row - 2, 16].Address + ")";
                                ws3.Cells[row, 17].Formula = "(" + ws3.Cells[row, 16].Address + "/" + ws3.Cells[row, 15].Address + ") * 100"; // %
                                ws3.Cells[row, 2, row, maxCol].Style.Font.Bold = true;
                                row++;
                            }
                        }
                    }
                    //atur border tabel
                    border = ws3.Cells[rowTable, 2, row - 1, maxCol].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    //formatting harga
                    ws3.Cells[rowTable + 3, 4, row, maxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion

                    #endregion


                    ////====================   WS : REKAP PENJ DAN PIUT BEKAS  ==============================================================================================================//
                    ////buat worksheet 4
                    #region
                    ex.Workbook.Worksheets.Add("REKAP PENJ DAN PIUT BEKAS");
                    ExcelWorksheet ws4 = ex.Workbook.Worksheets[4];

                    //namai worksheet
                    ws4.Name = "REKAP PENJ DAN PIUT BEKAS";

                    //atur font worksheet
                    ws4.Cells.Style.Font.Name = "Tahoma";
                    ws4.Cells.Style.Font.Size = 9;

                    //atur lebar kolom
                    ws4.Cells[1, 1].Worksheet.Column(1).Width = 5;//A
                    ws4.Cells[1, 2].Worksheet.Column(2).Width = 20;//B
                    ws4.Cells[1, 3].Worksheet.Column(3).Width = 20;//C
                    ws4.Cells[1, 4].Worksheet.Column(4).Width = 20;//D
                    ws4.Cells[1, 5].Worksheet.Column(5).Width = 20;//E
                    ws4.Cells[1, 6].Worksheet.Column(6).Width = 20;//F
                    ws4.Cells[1, 7].Worksheet.Column(7).Width = 20;//G
                    ws4.Cells[1, 8].Worksheet.Column(8).Width = 20;//H
                    ws4.Cells[1, 9].Worksheet.Column(9).Width = 20;//I
                    ws4.Cells[1, 10].Worksheet.Column(10).Width = 20;//J
                    ws4.Cells[1, 11].Worksheet.Column(11).Width = 20;//K
                    ws4.Cells[1, 12].Worksheet.Column(12).Width = 20;//L
                    ws4.Cells[1, 13].Worksheet.Column(13).Width = 20;//M
                    ws4.Cells[1, 14].Worksheet.Column(14).Width = 20;//N
                    ws4.Cells[1, 15].Worksheet.Column(15).Width = 20;//O
                    ws4.Cells[1, 16].Worksheet.Column(16).Width = 20;//P
                    ws4.Cells[1, 17].Worksheet.Column(17).Width = 20;//Q

                    maxCol = 17;

                    //buat judul laporan
                    #region
                    ws4.Cells[1, 1].Value = "LAPORAN PENJUALAN PER SALES - " + GlobalVar.PerusahaanName;
                    ws4.Cells[2, 1].Value = "Periode  : " + AwalBlnLalu.ToString("dd/MM/yyyy") + " sd " + Today.ToString("dd/MM/yyyy");
                    ws4.Cells[3, 1].Value = "Cabang   : " + GlobalVar.CabangID.ToString();
                    ws4.Cells[4, 1].Value = "REKAP PENJ DAN PIUT BEKAS";


                    ws4.Cells[1, 1, 1, maxCol].Merge = true;
                    ws4.Cells[1, 1, 1, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws4.Cells[1, 1, 1, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws4.Cells[1, 1, 1, maxCol].Style.Font.Size = 18;
                    ws4.Cells[1, 1, 5, maxCol].Style.Font.Bold = true;
                    #endregion

                    row = 6;
                    rowTable = row;
                    rowTable2 = row; ;

                    //buat header laporan 
                    #region
                    ws4.Cells[row, 2].Value = "NAMA SALES";
                    ws4.Cells[row, 4].Value = "REALISASI PENJUALAN";
                    ws4.Cells[row + 1, 4].Value = "CASH";
                    ws4.Cells[row + 1, 5].Value = "AVALIS";
                    ws4.Cells[row + 1, 6].Value = "LEASING";
                    ws4.Cells[row + 2, 6].Value = "FIF";
                    ws4.Cells[row + 2, 7].Value = "MPMF";
                    ws4.Cells[row + 2, 8].Value = "SOF";
                    ws4.Cells[row + 2, 9].Value = "INDOMOBIL";
                    ws4.Cells[row + 2, 10].Value = "ADIRA";
                    ws4.Cells[row + 2, 11].Value = "RADANA";
                    ws4.Cells[row + 2, 12].Value = "WOM";
                    ws4.Cells[row + 2, 13].Value = "TOTAL";
                    ws4.Cells[row + 1, 14].Value = "TOTAL PENJUALAN";
                    ws4.Cells[row, 15].Value = "TARGET";
                    ws4.Cells[row, 16].Value = "+/-";
                    ws4.Cells[row, 17].Value = "%";


                    //atur style header
                    ws4.Cells[row, 2, row + 2, maxCol].Style.Font.Bold = true;
                    ws4.Cells[row, 2, row + 2, 3].Style.WrapText = true; //Nama Sales
                    ws4.Cells[row + 1, 13, row + 2, 13].Style.WrapText = true; //Total Penjualan

                    ws4.Cells[row, 2, row + 2, 3].Merge = true; //Nama Sales
                    ws4.Cells[row, 4, row, 14].Merge = true; //Realisasi Penjualan
                    ws4.Cells[row + 1, 4, row + 2, 4].Merge = true; //Cash
                    ws4.Cells[row + 1, 5, row + 2, 5].Merge = true; //Avalis
                    ws4.Cells[row + 1, 6, row + 1, 13].Merge = true; //Leasing
                    ws4.Cells[row + 1, 14, row + 1, 14].Merge = true; //Total Penjualan
                    ws4.Cells[row, 15, row + 2, 15].Merge = true; //Target
                    ws4.Cells[row, 16, row + 2, 16].Merge = true; // +/-
                    ws4.Cells[row, 17, row + 2, 17].Merge = true; // %


                    ws4.Cells[row, 2, row + 2, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws4.Cells[row, 2, row + 2, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws4.Cells[row, 2, row + 2, maxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws4.Cells[row, 2, row + 2, maxCol].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    row = 9;
                    NamaSalesSebelumnya = "";
                    if (dsBARU_BEKAS.Tables[6].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBARU_BEKAS.Tables[6].Rows)
                        {

                            if (row == 9 || NamaSalesSebelumnya != dr["NamaSales"].ToString())
                            {
                                ws4.Cells[row, 2].Value = dr["NamaSales"];
                                NamaSalesSebelumnya = dr["NamaSales"].ToString();
                            }
                            ws4.Cells[row, 3].Value = dr["Keterangan"];
                            ws4.Cells[row, 4].Value = dr["Cash"];
                            ws4.Cells[row, 5].Value = dr["Avalis"];
                            ws4.Cells[row, 6].Value = dr["Lsg_ADIRA"];
                            ws4.Cells[row, 7].Value = dr["Lsg_FIF"];
                            ws4.Cells[row, 8].Value = dr["Lsg_INDOMOBIL"];
                            ws4.Cells[row, 9].Value = dr["Lsg_MPMF"];
                            ws4.Cells[row, 10].Value = dr["Lsg_RADANA"];
                            ws4.Cells[row, 11].Value = dr["Lsg_SOF"];
                            ws4.Cells[row, 12].Value = dr["Lsg_WOM"];
                            ws4.Cells[row, 13].Formula = "SUM(" + ws4.Cells[row, 6].Address + ":" + ws4.Cells[row, 12].Address + ")"; //Total Penjualan
                            ws4.Cells[row, 14].Formula = "SUM(" + ws4.Cells[row, 4].Address + ":" + ws4.Cells[row, 12].Address + ")"; //Total Penjualan
                            ws4.Cells[row, 15].Value = dr["TargetSales"];
                            ws4.Cells[row, 16].Formula = "(" + ws4.Cells[row, 14].Address + "-" + ws4.Cells[row, 15].Address + ")"; //Selisih Target
                            ws4.Cells[row, 17].Formula = "(" + ws4.Cells[row, 16].Address + "/" + ws4.Cells[row, 15].Address + ") * 100"; // %
                            row++;
                            if (dr["Keterangan"].ToString() == "Bulan Ini")
                            {
                                ws4.Cells[row, 3].Value = "+/-";
                                ws4.Cells[row, 4].Formula = "(" + ws4.Cells[row - 1, 4].Address + "-" + ws4.Cells[row - 2, 4].Address + ")"; //Cash
                                ws4.Cells[row, 5].Formula = "(" + ws4.Cells[row - 1, 5].Address + "-" + ws4.Cells[row - 2, 5].Address + ")"; //Avalis
                                ws4.Cells[row, 6].Formula = "(" + ws4.Cells[row - 1, 6].Address + "-" + ws4.Cells[row - 2, 6].Address + ")";
                                ws4.Cells[row, 7].Formula = "(" + ws4.Cells[row - 1, 7].Address + "-" + ws4.Cells[row - 2, 7].Address + ")";
                                ws4.Cells[row, 8].Formula = "(" + ws4.Cells[row - 1, 8].Address + "-" + ws4.Cells[row - 2, 8].Address + ")";
                                ws4.Cells[row, 9].Formula = "(" + ws4.Cells[row - 1, 9].Address + "-" + ws4.Cells[row - 2, 9].Address + ")";
                                ws4.Cells[row, 10].Formula = "(" + ws4.Cells[row - 1, 10].Address + "-" + ws4.Cells[row - 2, 10].Address + ")";
                                ws4.Cells[row, 11].Formula = "(" + ws4.Cells[row - 1, 11].Address + "-" + ws4.Cells[row - 2, 11].Address + ")";
                                ws4.Cells[row, 12].Formula = "(" + ws4.Cells[row - 1, 12].Address + "-" + ws4.Cells[row - 2, 12].Address + ")";
                                ws4.Cells[row, 13].Formula = "(" + ws4.Cells[row - 1, 13].Address + "-" + ws4.Cells[row - 2, 13].Address + ")";
                                ws4.Cells[row, 14].Formula = "(" + ws4.Cells[row - 1, 14].Address + "-" + ws4.Cells[row - 2, 14].Address + ")";
                                ws4.Cells[row, 15].Formula = "(" + ws4.Cells[row - 1, 15].Address + "-" + ws4.Cells[row - 2, 15].Address + ")";
                                ws4.Cells[row, 16].Formula = "(" + ws4.Cells[row - 1, 16].Address + "-" + ws4.Cells[row - 2, 16].Address + ")";
                                ws4.Cells[row, 17].Formula = "(" + ws4.Cells[row, 16].Address + "/" + ws4.Cells[row, 15].Address + ") * 100"; // %
                                ws4.Cells[row, 2, row, maxCol].Style.Font.Bold = true;
                                row++;
                            }
                        }
                    }
                    //atur border tabel
                    border = ws4.Cells[rowTable, 2, row - 1, maxCol].Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    //formatting harga
                    ws4.Cells[rowTable + 3, 4, row, maxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                    row++; row++; row++;
                    #endregion

                    #endregion

                    Byte[] bin = ex.GetAsByteArray();
                    SaveFileDialog sv = new SaveFileDialog();
                    sv.FileName = "C:\\Temp\\" + Today.ToString("dd MMM yyyy") + " - Laporan Harian" + ".xlsx";
                    //sv.FileName = "C:\\Temp\\" + GlobalVar.GetServerDate.ToString("dd MMM yyyy") + " - PERBANDINGAN SALDO KAS - " + FromDate.ToString("dd MMM yyyy") + ".xlsx";
                    string file = sv.FileName.ToString();
                    File.WriteAllBytes(file, bin);

                    return file;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return "Gagal";
        }

    }
}
