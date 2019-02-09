using System;
using System.Collections.Generic;
using System.Data;
using ISA.DAL;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlTypes;
using System.IO;
using ISA.Showroom.Class;

namespace ISA.Showroom
{
    class Tools
    {
        public static object isNull(object value, object nullValue)
        {
            if (value == null)
            {
                return nullValue;
            }
            else
            {
                if (value.ToString().Trim() == "")
                    return nullValue;
                else
                    return value;
            }
        }
        
        public static string CreateFingerPrint()
        {
            string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHH:mm:ss}", GlobalVar.GetServerDate) + SecurityManager.UserInitial + " ";            
            return HtrId;
        }

        public static string CreateFingerPrintMilliseconds()
        {
            string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyMMddHHmmssfff}", GlobalVar.GetServerDate) + SecurityManager.UserInitial;
            return HtrId;
        }

        public static string CreateFingerPrintMilliseconds(int i)
        {
            string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyMMddHHmmssfff}", GlobalVar.GetServerDate) + SecurityManager.UserInitial;

            HtrId = HtrId.Substring(0, 18) + i.ToString().PadLeft(2, '0') + HtrId.Substring(18,3);
            return HtrId;
        }

        public static string CreateShortFingerPrint(int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 3, 3);
            string HtrId = CreateFingerPrint().Substring(0, 20) + nomor;
            return HtrId;
        }

        public static string CreateShortSortFingerPrint(int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 3, 3);
            string HtrId = CreateFingerPrint().Substring(0, 20) + nomor;
            HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmss}", GlobalVar.GetServerDate) + nomor;
            return HtrId;
        }
       
        public static DataTable GetGeneralNumerator(string doc)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static DataTable GetGeneralNumerator(string doc, string depan)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static string FormatNumerator(int nomor, int lebar, string prefix, string sufix)
        {
            string result;
            result = nomor.ToString();
            for (int i = 0; i < lebar; i++)
            {
                result = "0" + result;
            }
            result = Right(result, lebar);
            result = prefix + result + sufix;
            return result;
        }

        public static string GeneralInitial()
        {
            //string Cab = ToCode("A");
            string Thn = ToCode("F");
            string Bln = ToCode("D");
            return "A" + Thn + Bln;
        }


        public static string ToCode(string initial)
        {
            string aFilm = "FILMKARTUN";
            string aDouble = "DOUBLEIMPACT";
            string aAbjad = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string bln = "ABCDEFGHIJKL";
            string thn = "ABCDEFGHIJKL";

            switch (initial)
            {
                case ("F"):
                    initial = aFilm.Substring((Convert.ToInt32(GlobalVar.GetServerDate.Year.ToString().Substring(3, 1))) - 1, 1);
                    break;
                case ("D"):
                    initial = aDouble.Substring((Convert.ToInt32(GlobalVar.GetServerDate.Month.ToString())) - 1, 1);
                    break;
                case ("NOTA_PT_M"):
                    initial = bln.Substring((Convert.ToInt32(GlobalVar.GetServerDate.Month.ToString())) - 1, 1);
                    break;
                case ("NOTA_PT_Y"):
                    initial = thn.Substring((Convert.ToInt32(GlobalVar.GetServerDate.Month)) - 1, 1);
                    break;
            }
            return initial;

        }
            
        public static string Right(string param, int length)
        {
            int pjg = param.Length - length;
            string result = param.Substring(pjg, length);
            //return the result of the operation
            return result;
        }

        public static string Left(string param, int length)
        {
            try
            {
                int pjg = param.Length - length;
                string result = param.Substring(0, length);
                //return the result of the operation
                return result;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string GetAntiNumeric(string numericValue)
        {            
            string result = "";
            if (numericValue.Contains("-"))
            {
                numericValue = numericValue.Replace("-", "");
                result = "-";
            }

            string antiNumeric = "DTHAMESVOR";
            string chr;
            int counter = 0;
            while (counter < numericValue.Length)
            {
                chr = numericValue.Substring(counter, 1);
                if (chr != "." && chr != ",")
                {
                    result += antiNumeric.Substring(int.Parse(chr), 1);
                }
                else
                {
                    result += chr;
                }
                counter++;
            }
            result = result.Replace("(", "");
            result = result.Replace(")", "");
            return result;
        }

        public static string GetAntiNumeric(string numericValue,bool SIP)
        {
            string result = "";
            string antiNumeric = "DTHAMESVOR";
            string chr;
            int counter = 0;
            while (counter < numericValue.Length)
            {
                chr = numericValue.Substring(counter, 1);
                if (chr != "." && chr != ",")
                {
                    result += antiNumeric.Substring(int.Parse(chr), 1);
                }
                else
                {
                    result += chr;
                }
                counter++;
            }

            return result;
        }

        public static string BulanPanjang(int n)
        {
            string[] bulans = {"Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"};
            string result = "";

            result = bulans[n - 1];
            return result;
        }

        public static string BulanPendek(int n)
        {
            string[] bulans = { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agt", "Sep", "Okt", "Nov", "Des" };
            string result = "";

            result = bulans[n];
            return result;
        }

        public static string HariPanjang(DateTime dt)
        {
            string hari = "";
            DayOfWeek dw = dt.DayOfWeek;
            switch (dw.ToString())
            {
                case "Monday" :
                    hari = "Senin";
                    break;
                case "Tuesday" :
                    hari = "Selasa";
                    break;
                case "Wednesday" :
                    hari = "Rabu";
                    break;
                case "Thursday" :
                    hari = "Kamis";
                    break;
                case "Friday" :
                    hari = "Jumat";
                    break;
                case "Saturday" :
                    hari = "Sabtu";
                    break;
                case "Sunday" :
                    hari = "Minggu";
                    break;
            }       

            return hari;
        }

        public static string HariPendek(DateTime dt)
        {
            string hari = "";
            DayOfWeek dw = dt.DayOfWeek;
            switch (dw.ToString())
            {
                case "Monday":
                    hari = "Sen";
                    break;
                case "Tuesday":
                    hari = "Sel";
                    break;
                case "Wednesday":
                    hari = "Rab";
                    break;
                case "Thursday":
                    hari = "Kam";
                    break;
                case "Friday":
                    hari = "Jum";
                    break;
                case "Saturday":
                    hari = "Sab";
                    break;
                case "Sunday":
                    hari = "Min";
                    break;
            }

            return hari;
        }
             
        public static string Terbilang(Int64 n)
        {
            string[] numbers = {"", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"};            
            string result = "";

            if (n < 12)
            {
                result = result + numbers[n];
            }
            else if (n < 20)
            {
                result = Terbilang(n - 10).ToString() + " belas";
            }
            else if (n < 100)
            {
                result = Terbilang(n / 10).ToString() + " puluh " + Terbilang(n % 10);
            }
            else if (n < 200)
            {
                result = "seratus " + Terbilang(n - 100);
            }
            else if (n < 1000)
            {
                result = Terbilang(n / 100) + " ratus " + Terbilang(n % 100);
            }
            else if (n < 2000)
            {
                result = "seribu " + Terbilang(n - 1000);
            }
            else if (n < 1000000)
            {
                result = Terbilang(n / 1000) + " ribu " + Terbilang(n % 1000);
            }
            else if (n < 1000000000)
            {
                result = Terbilang(n / 1000000) + " juta " + Terbilang(n % 1000000);
            }
            else if (n < 1000000000000)
            {
                result = Terbilang(n / 1000000000) + " miliar " + Terbilang(n % 1000000000);
            }

            return result;
        }

        public static int GetHariSales(string transactionType, int hariSalesToko)
        {
            int hariSales = 0;

            if (transactionType.Trim() == "" || transactionType.Substring(0, 1) == "T")
            {
                hariSales = 0;
            }
            else
            {
                if (transactionType == "KH" || transactionType == "KB" ||
                    transactionType == "KV" ||
                    transactionType == "KT" || transactionType == "KA")
                {
                    hariSales = 30;
                }
                else if (transactionType == "KL")
                {
                    hariSales = 40;
                }
                else if (transactionType == "KJ")
                {
                    hariSales = 14;
                }
                else if (transactionType == "KG")
                {
                    hariSales = 21;
                }
                else if (transactionType == "KZ")
                {
                    hariSales = 60;
                }
                else
                {
                    if (hariSalesToko == 0)
                    {
                        hariSales = 60;
                    }
                    else
                    {
                        hariSales = hariSalesToko;
                    }
                }
            }
            return hariSales;
        }

        // normalnya
        public static void pin(int periodePin, int mingguKe, DateTime tanggal, int Bagian, int modulId, string keterangan)
        {
            GlobalVar.pinResult = true;
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                db.Commands[0].Parameters.Add(new Parameter("@select", SqlDbType.Int, 1));
                db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, modulId));
                db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, mingguKe));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime2, tanggal));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, periodePin));
                dt = db.Commands[0].ExecuteDataTable();

            }
            if (dt.Rows.Count == 0)
            {
                GlobalVar.pinReport = false;
                GlobalVar.pinResult = false;
                DialogResult dialogResult = MessageBox.Show("Proses ini memerlukan pin. \n Apakah anda ingin melanjutkan ? ", "Peringatan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GlobalVar.pinReport = true;
                    Pin.frmPin ifrmChild = new Pin.frmPin(periodePin, Bagian, modulId, mingguKe, tanggal, keterangan);
                    ifrmChild.WindowState = FormWindowState.Normal;
                    ifrmChild.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    GlobalVar.pinResult = false;
                }
            }

        }

        // overload buat kalo di penjualan
        public static void pin(int periodePin, int mingguKe, DateTime tanggal, int Bagian, int modulId, string keterangan, Guid srcRowID)
        {
            GlobalVar.pinResult = true;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                db.Commands[0].Parameters.Add(new Parameter("@select", SqlDbType.Int, 1));
                db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, modulId));
                db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, mingguKe));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime2, tanggal));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, periodePin));
                db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, srcRowID));
                dt = db.Commands[0].ExecuteDataTable();

            }
            if (dt.Rows.Count == 0)
            {
                GlobalVar.pinReport = false;
                GlobalVar.pinResult = false;
                DialogResult dialogResult = MessageBox.Show("Proses ini memerlukan pin. \n Apakah anda ingin melanjutkan ? ", "Peringatan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GlobalVar.pinReport = true;
                    Pin.frmPin ifrmChild = new Pin.frmPin(periodePin, Bagian, modulId, mingguKe, tanggal, keterangan, srcRowID);
                    ifrmChild.WindowState = FormWindowState.Normal;
                    ifrmChild.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    GlobalVar.pinResult = false;
                }
            }
        }

        // overload untuk Print Tagihan
        // cek Pin nya berdasarkan Tanggal (Hari) dan PenjualanRowID nya
        public static void pin(int periodePin, int mingguKe, DateTime tanggal, int Bagian, int modulId, string keterangan, Guid modulHeaderRowID, Guid modulDetailRowID, String headerTableName, String detailTableName, bool printLog)
        {
            GlobalVar.pinResult = true;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                db.Commands[0].Parameters.Add(new Parameter("@select", SqlDbType.Int, 1));
                db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, modulId));
                db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, mingguKe));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime2, tanggal));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, periodePin));
                    // di bagian print masukkin modulHeader/Detail RowID nya
                    if (modulDetailRowID == Guid.Empty && modulHeaderRowID == Guid.Empty)
                    {
                        // ngga perlu kasih parameter
                    }
                    // prioritas pertama yg jadi srcRowID itu modulDetailRowID
                    else if (modulDetailRowID != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, modulDetailRowID));
                    }
                    // baru modeulHeaderRowID yg jadi srcRowID
                    else if (modulHeaderRowID != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, modulHeaderRowID));
                    }
                dt = db.Commands[0].ExecuteDataTable();

            }
            if (dt.Rows.Count == 0)
            {
                GlobalVar.pinReport = false;
                GlobalVar.pinResult = false;
                DialogResult dialogResult = MessageBox.Show("Proses ini memerlukan pin. \n Apakah anda ingin melanjutkan ? ", "Peringatan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GlobalVar.pinReport = true;
                    Pin.frmPin ifrmChild = new Pin.frmPin(periodePin, Bagian, modulId, mingguKe, tanggal, keterangan, modulHeaderRowID, modulDetailRowID, headerTableName, detailTableName, printLog);
                    ifrmChild.WindowState = FormWindowState.Normal;
                    ifrmChild.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    GlobalVar.pinResult = false;
                }
            }
        }

        /// <summary>
        /// Delete Record On DataTable using where statement
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="filterExpression">WHere Statement</param>
        public static void DeleteDataTable(DataTable dt, string filterExpression)
        {
            DataRow[] toBeDeleted;
            toBeDeleted = dt.Select(filterExpression);

            if (toBeDeleted.Length > 0)
            {
                foreach (DataRow dr in toBeDeleted)
                {
                    dt.Rows.Remove(dr);

                }
            }
            dt.AcceptChanges();
        }

        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int a = 0;
            a = Math.Abs((d1.Month - d2.Month) + 12 * (d1.Year - d2.Year));
            return a;
        }

        /// <summary>
        /// Koncian Level 1
        /// Mengunci Transaksi berdasarkan parameter kuncian di table
        /// </summary>
        /// <param name="Tgl">Tanggal validasi</param>
        /// <returns>True or False</returns>
        public static bool IsExpiredLevel1(DateTime Tgl)
        {
            bool Expired = false;
            List<int> parameter = GlobalVar.ParameterKuncian;
            if (Tgl <= GlobalVar.DateOfServer.AddDays(-parameter[0])) { Expired = true; }
            if (Tgl >= GlobalVar.DateOfServer.AddDays(+parameter[1])) { Expired = true; }
            return Expired;
        }

        public static bool IsExpiredLevel0(DateTime Tgl)
        {
            bool Expired = false;
            List<int> parameter = GlobalVar.ParameterKuncian;
            if (Tgl <= GlobalVar.DateOfServer.AddDays(-parameter[0])) { Expired = true; }
    
            return Expired;
        }

        /// <summary>
        /// Koncian Level 2
        /// Mengunci Transaksi berdasarkan parameter kuncian di table
        /// Dengan spare Time, tanggal Record dibuat
        /// </summary>
        /// <param name="Tgl">Tanggal validasi</param>
        /// <param name="RecordCreatedDate">Tanggal Record Dibuat</param>
        /// <returns>True or False</returns>
        public static bool IsExpiredLevel2(DateTime Tgl, DateTime RecordCreatedDate)
        {
            bool Expired = false;
            List<int> parameter = GlobalVar.ParameterKuncian;
            if (Tgl <= GlobalVar.DateOfServer.AddDays(-parameter[0])) { Expired = true; }
            if (Tgl >= GlobalVar.DateOfServer.AddDays(+parameter[1])) { Expired = true; }
            if (GlobalVar.DateOfServer == RecordCreatedDate) { Expired = false; }
            return Expired;
        }

        /// <summary>
        /// Koncian level3
        /// Max 1 bulan Ke belakang
        /// </summary>
        /// <param name="Tgl"></param>
        /// <returns></returns>
        public static bool IsExpiredLevel3(DateTime Tgl)
        {
            // hanya untuk bulan ini dan bulan-bulan depannya

            bool Expired = false;
            List<int> parameter = GlobalVar.ParameterKuncian;
            DateTime ExpireDate = new DateTime(Tgl.Year,Tgl.Month,parameter[0]  ).AddMonths(1);

           
            if (GlobalVar.DateOfServer > ExpireDate) { Expired = true; } 
            return Expired;
        }

        /// <summary>
        /// Koncian Level4, kalo sudah lewat bulan di close
        /// </summary>
        /// <param name="Tgl">Tanggal </param>
        /// <returns>valid or not</returns>
        public static bool IsExpiredLevel4(DateTime Tgl)
        {            
            bool Expired = false;
            DateTime DateServer = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            DateTime ExpDate = new DateTime(Tgl.Year, Tgl.Month, 1);

            if (DateServer!=ExpDate)
            {
                Expired = true;
            }
            return Expired;
        }

        public static bool IsExpiredLevel5(DateTime Tgldb, DateTime Tgltextbox)
        {
            bool Expired = false;
            DateTime DateServer = new DateTime(GlobalVar.DateOfServer.Year, GlobalVar.DateOfServer.Month, 1);
            DateTime tabel = new DateTime(Tgldb.Year, Tgldb.Month, 1);
            DateTime textbox = new DateTime(Tgltextbox.Year, Tgltextbox.Month, 1);

            if (tabel == null || tabel == DateTime.MinValue)
            {
                if(textbox != DateServer) 
                    Expired = true;
            }
            else
            {
                if(tabel != DateServer || textbox != DateServer)                 
                    Expired = true;
            }

            return Expired;
        }

        public static bool IsExpiredLevel6(DateTime Tgl)
        {

            bool Expired = false;
            DateTime Dateserver = GlobalVar.GetServerDate;

            if ((Dateserver.Day >= 16) && (Tgl.Day >= 16)  && (Tgl<=Dateserver) && (Tgl.Month == Dateserver.Month) && (Tgl.Year == Dateserver.Year))
            {
                Expired = true;
            }
            else if ((Dateserver.Day <= 15) && (Tgl.Day <= 15) && (Tgl <= Dateserver) && (Tgl.Month == Dateserver.Month) && (Tgl.Year == Dateserver.Year))
            {
                Expired = true;
            }
            return Expired;

        }

        public static bool IsExpired2(DateTime? tgl)
        {
            return (tgl < (DateTime?)(GlobalVar.GetServerDate.AddDays(-GlobalVar.ParameterKuncian[2])));
        }

        public static SqlGuid ToNull(object value)
        {
            SqlGuid VAR = SqlGuid.Null;

            VAR = (Guid)isNull(value, Guid.Empty) == Guid.Empty ? SqlGuid.Null : (Guid)value;
            return VAR;
        }

        public static SqlDateTime ToNull(DateTime? Date)
        {
            SqlDateTime var = SqlDateTime.Null;
            var = Date.HasValue ? Date.Value : SqlDateTime.Null;
            return var;
        }

        public static void IfExistDelete(string FileLocation)
        {
            if (File.Exists(FileLocation))
            {
                File.Delete(FileLocation);
            }
        }

        public static void ZipFile(List<string> files_, string NamaZip)
        {
            List<string> files = new List<string>();
            files = files_;

            string fileZipName = GlobalVar.DbfUpload + "\\" + NamaZip + ".zip";


            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            foreach (string var in files)
            {
                if (File.Exists(var))
                {
                    File.Delete(var);
                }
            }
        }

        // untuk pembulatan
        public static Double RoundUp(Double Value, int Pembulatan)
        {
            Double tempValue = 0;
            tempValue = Math.Ceiling(Value / Pembulatan);
            tempValue = tempValue * Pembulatan;
            return tempValue;
            /* // pembulatan ke bawah
                tempValue = Math.Ceiling(Value / Pembulatan);
                tempValue = (tempValue - 1) * Pembulatan;
            */
        }

    }
}
