using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Finance;
using System.Data.SqlTypes;

namespace ISA.Showroom.Finance
{
    class Tools
    {
        // tambahan dari isashowroom


        public static string CreateFingerPrintMilliseconds()
        {
            string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyMMddHHmmssfff}", GlobalVar.GetServerDate) + SecurityManager.UserInitial;
            return HtrId;
        }

        public static string CreateFingerPrintMilliseconds(int i)
        {
            string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyMMddHHmmssfff}", GlobalVar.GetServerDate) + SecurityManager.UserInitial;

            HtrId = HtrId.Substring(0, 18) + i.ToString().PadLeft(2, '0') + HtrId.Substring(18, 3);
            return HtrId;
        }


        // akhir dari isashowroom

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
            //string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHH:mm:ss}", GlobalVar.GetServerDate) + SecurityManager.UserInitial + " ";
            //GlobalVar.PerusahaanID + Left((String.Format("{0:yyMMddHHmmssFFF}", DateTime.Now) + SecurityManager.UserInitial + Guid.NewGuid().ToString()), 20);
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID",SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
            prm.Add(new Parameter("@UserID",SqlDbType.VarChar, SecurityManager.UserID));
            string HtrId = Tools.DBGetScalar("fsp_CreateFingerPrint", prm).ToString();
            
            return HtrId;
        }

        public static string CreateFingerPrint(string PerusahaanID, string userInitial)
        {
            string HtrId = PerusahaanID + String.Format("{0:yyyyMMddHH:mm:ss}", GlobalVar.GetServerDate) + userInitial + " ";
            return HtrId;
        }

        public static string CreateFingerPrint2()
        {
            string RecordID = GlobalVar.PerusahaanID + Left((String.Format("{0:yyMMddHHmmssFFF}", GlobalVar.GetServerDate) + SecurityManager.UserInitial + Guid.NewGuid().ToString()), 20);
            return RecordID;
        }

        public static string CreateShortFingerPrint(int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 3, 3);
            string HtrId = CreateFingerPrint().Substring(0, 20) + nomor;
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
            string Cab = ToCode("A");
            string Thn = ToCode("F");
            string Bln = ToCode("D");
            return Cab + Thn + Bln;
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
                case ("A"):
                    initial = aAbjad.Substring(int.Parse(GlobalVar.CabangID) - 1, 1);
                    break;
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
            int pjg = param.Length - length;
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string GetAntiNumeric(string numericValue)
        {
            string result="";
            string antiNumeric = "DTHAMESFOR";
            string chr;
            int counter=0;
            while (counter < numericValue.Length)
            {
                chr = numericValue.Substring(counter, 1);
                if (chr != "." && chr != "," && chr != "-")
                {
                    result += antiNumeric.Substring (int.Parse( chr),1);
                }
                else
                {
                    result += chr;
                }
                counter++;
            }
            
            if(numericValue.Contains('-'))
            {
                result = "(" + result + ")";
            }

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

        //public static bool SetNumerator(string doc)
        //{
        //    DataTable dt = new DataTable();
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
        //        db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
        //        dt = db.Commands[0].ExecuteDataTable();

        //        int lebar = Convert.ToInt32(dt.Rows[0]["Lebar"]);
        //        int nomor = Convert.ToInt32(dt.Rows[0]["Nomor"]) + 1;
        //        string belakang = dt.Rows[0]["Belakang"].ToString();
        //        db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
        //        db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
        //        db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, Depan()));
        //        db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
        //        db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, nomor));
        //        db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
        //        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
        //        db.Commands[1].ExecuteNonQuery();
        //        return true;
        //    }
        //}

        public static string Nominal(int n)
        {
            string sN = n.ToString();
            string ret = "", temp = "";
            int count = 1;

            for (int i = sN.Length - 1; i >= 0; i--)
            {
                temp = temp + sN[i];
                if (count % 3 == 0 && i!=0)
                    temp = temp + ".";
                count++;
            }

            for (int i = temp.Length - 1; i >= 0; i--)
            {
                ret = ret + temp[i];
            }

            return ret + ",-";
        }

        private static string getNumbers(int n)
        {
            string ret = "";
            switch (n)
            {
                case 0: ret = "nol"; break;
                case 1: ret = "satu"; break;
                case 2: ret = "dua"; break;
                case 3: ret = "tiga"; break;
                case 4: ret = "empat"; break;
                case 5: ret = "lima"; break;
                case 6: ret = "enam"; break;
                case 7: ret = "tujuh"; break;
                case 8: ret = "delapan"; break;
                case 9: ret = "sembilan"; break;
            }
            return ret;
        }

        private static string getTails(int d)
        {
            string ret = "";
            switch (d)
            {
                case 0: ret = ""; break;
                case 1: ret = "belas"; break;
                case 2: ret = "puluh"; break;
                case 3: ret = "ratus"; break;
                case 4: ret = "ribu"; break;
                case 7: ret = "juta"; break;
            }
            return ret;
        }

        public static string Terbilang(int n)
        {
            string sN = n.ToString();
            string temp = "";
            int count = 1, countdown = sN.Length, no0=0, no=0, no1=0, no2=0;

            string[] numbers = {"nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan"};
            string[] tail = {"","","","","","",""};

            for (int i = 0; i < sN.Length; i++)
            {
                if (i > 0) no0 = int.Parse(sN[i - 1].ToString());
                no = int.Parse(sN[i].ToString());
                if (sN.Length - i > 1) no1 = int.Parse(sN[i + 1].ToString());
                if (sN.Length - i > 2) no2 = int.Parse(sN[i + 2].ToString());
                switch (sN.Length-i)
                {
                    case 7 :temp = temp + getNumbers(no) + " " + getTails(7) + " ";
                            break;
                    case 6 :if (no == 0)
                                break;
                            if (no1 == 0 && no2 == 0)
                            {
                                if (no == 1)
                                    temp = temp + "se" + getTails(3) + " " + getTails(4) + " "; //100.nnn
                                else
                                    temp = temp + getNumbers(no) + " " + getTails(7) + " "; //n00.nnn
                            }
                            else
                                temp = temp + getNumbers(no) + " " + getTails(3) + " "; //n0n.nnn
                            break;
                    case 5 :if (no == 0)
                                break;
                            if (no == 1)
                            {
                                if (no1 == 0)
                                    temp = temp + "se" + getTails(2) + " " + getTails(4) + " "; //10.nnn
                                else if (no1 == 1)
                                    temp = temp + "se" + getTails(1) + " " + getTails(4) + " "; //11.nnn
                                else
                                    temp = temp + getNumbers(no1) + " " + getTails(1) + " " + getTails(4) + " "; //1n.nnn
                            }
                            else
                            {
                                if (no1 == 0)
                                {
                                    temp = temp + getNumbers(no) + " " + getTails(2) + " " + getTails(4) + " "; //n0.nnn
                                }
                                else
                                    temp = temp + getNumbers(no) + " " + getTails(2) + " "; //nx.nnn
                            }
                            break;
                    case 4 :if (no == 0 || no0 == 1)
                                break;
                            if(no == 1)
                                temp = temp + "se" + getTails(4) + " "; //1.nnnn
                            else
                                temp = temp + getNumbers(no) + " " + getTails(4) + " "; //n.nnn
                            break;
                    case 3 :if (no == 0)
                                break;
                            if (no == 1)
                            {
                                if (no1 == 0 && no2 == 0)
                                {
                                    temp = temp + "se" + getTails(3); //100
                                    return temp.ToUpper();
                                }
                                else
                                    temp = temp + "se" + getTails(3) + " ";//1xx
                            }
                            else
                            {
                                if (no1 == 0 && no2 == 0)
                                {
                                    temp = temp + getNumbers(no) + " " + getTails(3); //x00
                                    return temp.ToUpper();
                                }
                                else
                                    temp = temp + getNumbers(no) + " " + getTails(3) + " "; //xxx
                            }
                            break;
                    case 2 :if (no == 0)
                                break;
                            if (no == 1)
                            {
                                if (no1 == 0)
                                    temp = temp + "se" + getTails(2); //10
                                else if (no1 == 1)
                                    temp = temp + "se" + getTails(1); //11
                                else
                                    temp = temp + getNumbers(no1) + " " + getTails(1); //1n
                                return temp.ToUpper();
                            }
                            else
                            {
                                if (no1 == 0)
                                {
                                    temp = temp + getNumbers(no) + " " + getTails(2); //n0
                                    return temp.ToUpper();
                                }
                                else
                                    temp = temp + getNumbers(no) + " " + getTails(2) + " "; //nn
                            }
                            break;
                    case 1: if ((no == 0 || no0 == 1) && sN.Length!=1)
                                break;
                            temp = temp + getNumbers(no); //x
                            break;
                    case 0 :temp = ""; //
                            break;
                }
            }

            return temp.ToUpper();
        }

        /*public static string Terbilang(int n)
        {
            string[] numbers = {"nol", "satu", "dua", "tiga", "empat", 
                                   "lima", "enam", "tujuh", "delapan", "sembilan"};
            string[] tail  = { "", "", " puluh", " ratus", " ribu", " puluh", " ratus", " juta" };
            string[] tail2 = { "", "", " puluh", " ratus", " ribu", " puluh ribu", " ratus ribu", " juta" };
            string result = "";
            int curNumber, nDigit, temp = n;


            string sN = n.ToString();

            if (sN.Length > 7)
            {
                result = "";
            }
            else
            {
                for (int i = sN.Length - 1; i >= 0; i--)
                {
                    curNumber = int.Parse(sN.Substring(i, 1));
                    nDigit = sN.Length - i;

                    if ((curNumber == 1 || curNumber == 0) && sN.Length != 1)
                    {
                        if (curNumber == 1)
                        {
                            if (nDigit == 2)
                            {
                                if (result == numbers[0])
                                    result = "sepuluh";
                                else
                                {
                                    if (result == numbers[1])
                                        result = "sebelas";
                                    else
                                        result = result + "belas";
                                }
                            }
                            result = "se" + tail[nDigit].Trim();
                        }
                    }
                    else
                    {
                        result = numbers[curNumber] + tail[nDigit] + " " + result;
                    }

                    temp = (int) temp / 10;
                }
            }

            result = result.Trim();

            result = result.Substring(0, 1).ToUpper() + result.Substring(1, result.Length - 1);

            return result;
        }*/

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

        public static string DescStatusApproval(GlobalVar.enumStatusApproval statusApproval)
        {
            string result = "";
            switch (statusApproval)
            {
                case GlobalVar.enumStatusApproval.Open: result = "Belum Pengajuan"; break;
                case GlobalVar.enumStatusApproval.Waiting1: result= "Menunggu Acc #1"; break;
                case GlobalVar.enumStatusApproval.Waiting2: result = "Menunggu Acc #2"; break;
                case GlobalVar.enumStatusApproval.Rejected: result = "Ditolak"; break;
                case GlobalVar.enumStatusApproval.Approved: result = "Disetujui"; break;
                case GlobalVar.enumStatusApproval.Closed: result = "Selesai / Realisasi"; break;
                default: result = ""; break;
            }
            return result;
        }

        public static float GetCurrencyRate(Guid MataUangRowID, DateTime TanggalKurs)
        {
            float rate = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetCurrencyRate"));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, MataUangRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalKurs", SqlDbType.Date, TanggalKurs));
                    rate = float.Parse(isNull(db.Commands[0].ExecuteScalar(),"0").ToString());
//                    rate = float.Parse(oRate.ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return rate;
        }

        public static DataTable DBGetDataTable(string sql, List<Parameter> parameters)

        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = parameters;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        public static object DBGetScalar(string sql, List<Parameter> parameters)
        {
            object result = null;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = parameters;
                    result = db.Commands[0].ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return result;
        }


        public static string GetLookUpValue(string lookupCode)
        {
            string val = string.Empty;
            try
            {
                DataTable dtLookup = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, lookupCode));
                    dtLookup = db.Commands[0].ExecuteDataTable();
                }
                if (dtLookup.Rows.Count > 0)
                {
                    val = dtLookup.Rows[0]["Value"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return val;
        }

        /// <summary>
        /// Koncian level3
        /// </summary>
        /// <param name="Tgl"></param>
        /// <returns></returns>
        public static bool IsExpiredLevel3(DateTime Tgl)
        {
            bool Expired = false;
            List<int> parameter = GlobalVar.ParameterKuncian;
            DateTime ExpireDate = new DateTime(Tgl.Year, Tgl.Month, parameter[0]).AddMonths(1);


            if (GlobalVar.DateOfServer > ExpireDate) { Expired = true; }
            return Expired;
        }


        public static double GetKurs(DateTime tgl, double value, string from, string to)
        {
            double val = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[fsp_GetKurs]"));
                db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.Date, tgl));
                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, value));
                db.Commands[0].Parameters.Add(new Parameter("@From", SqlDbType.VarChar, from));
                db.Commands[0].Parameters.Add(new Parameter("@To", SqlDbType.VarChar, to));
                dt = db.Commands[0].ExecuteDataTable();
            }
            val = Convert.ToDouble(dt.Rows[0][0]);
            return val;
        }


        public static SqlGuid ToNull(object value)
        {
            SqlGuid VAR = SqlGuid.Null;

            VAR = (Guid)isNull(value, Guid.Empty) == Guid.Empty ? SqlGuid.Null : (Guid)value; 
            return VAR;
        }

        public static void AutoGrid(ISA.Controls.CustomGridView GV, DataTable dt, List<string> HideField, string FormatMoney)
        {
            GV.AutoGenerateColumns = true;

            GV.DataSource = dt; GV.Refresh();
            if (FormatMoney.Equals(string.Empty))
            {
                FormatMoney = "#,##0";
            }
            foreach (DataGridViewColumn cols in GV.Columns)
            {
                string cumi = cols.Name;
                foreach (string ss in HideField)
                {
                    if (cumi.Contains(ss))
                    {
                        cols.Visible = false;
                    }
                   
                }

                if (cols.Name.Contains("Row") || cols.Name.Contains("Last") || cols.Name.Contains("Last") || cols.Name.Contains("id"))
                {
                    cols.Visible = false;
                }
                if (cols.Name.Contains("Tanggal") || cols.Name.Contains("Tgl"))
                {
                    cols.DefaultCellStyle.Format = "dd-MM-yyyy";
                }

                if (cols.Name.Contains("Rp") || cols.Name.Contains("Amount") || cols.Name.Contains("Nominal") || cols.Name.Contains("Debet") || cols.Name.Contains("Kredit"))
                {
                    cols.DefaultCellStyle.Format = FormatMoney;
                    cols.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

             
            }
            GV.Refresh();
        }

        public static void AutoGrid(ISA.Controls.CustomGridView GV, DataView dt, List<string> HideField, string FormatMoney)
        {
            GV.AutoGenerateColumns = true;

            GV.DataSource = dt; GV.Refresh();
            if (FormatMoney.Equals(string.Empty))
            {
                FormatMoney = "#,##0";
            }
            foreach (DataGridViewColumn cols in GV.Columns)
            {
                string cumi = cols.Name;
                foreach (string ss in HideField)
                {
                    if (cumi.Contains(ss))
                    {
                        cols.Visible = false;
                    }

                }

                if (cols.Name.Contains("Row") || cols.Name.Contains("Last") || cols.Name.Contains("Last") || cols.Name.Contains("id"))
                {
                    cols.Visible = false;
                }
                if (cols.Name.Contains("Tanggal") || cols.Name.Contains("Tgl"))
                {
                    cols.DefaultCellStyle.Format = "dd-MM-yyyy";
                }

                if (cols.Name.Contains("Rp") || cols.Name.Contains("Amount") || cols.Name.Contains("Nominal") || cols.Name.Contains("Debet") || cols.Name.Contains("Kredit"))
                {
                    cols.DefaultCellStyle.Format = FormatMoney;
                    cols.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }


            }
            GV.Refresh();
        }


        public static bool checkLockEditDelete(String JnsTransaksi)
        {
            // kalau data penerimaan/pengeluaran uang, jenis transaksi tertentu, 
            // yg dari showroom itu tidak boleh diedit maupun didelete
            bool result = false;

            if (JnsTransaksi == "12") // 12 - Hutang Lain - Lain - 210499130101 -- 0E8FF1D4-C658-446F-AEA8-AC05EDBD1783
            {
                result = false; // bebasin yg 12
            }
            else if (JnsTransaksi == "18") // 18 - Pendapatan Bunga Kredit - 710100130210 -- 4E4D8438-B473-4CF5-A04D-B3CF3D2C07F8
            {
                result = true;
            }
            else if (JnsTransaksi == "22") // 22 - Persediaan Barang - 110801130100 -- C56F15A2-1C5C-4E23-A688-9F9D81A87ABC
            {
                result = true;
            }
            else if (JnsTransaksi == "24") // 24 - Piutang Usaha Tetap - 110341130102 -- ABD654FE-6A43-4F8B-BD80-B7D4B9D04356
            {
                result = true;
            }
            else if (JnsTransaksi == "28") // 28 - Uang Muka Penjualan - 210500130200 -- 208591F1-D9C3-48CF-972F-1AAA740E2AB1 
            {
                result = true;
            }
            else if (JnsTransaksi == "29") // 29 - UM Pelanggan - 210500130100 -- 72E64D29-6AAA-4C38-861E-035A1D9BAC1E
            {
                result = true;
            }
            else if (JnsTransaksi == "30") // 30 - Pendapatan Denda ADM dan Salesman - 710401130100 -- AC777B16-22C1-46C3-94EF-E4922BECE8DE
            {
                result = true;
            }
            else if (JnsTransaksi == "31") // 31 - Biaya Kantor dan PJ Lainnya - 619900130100 -- 9C8684BA-7D46-44C0-800C-85BE6F2A85A0
            {
                result = false; // bebasin yg 31
            }
            else if (JnsTransaksi == "32") // 32 - Pendapatan Lain2xnya - 712999130100 -- D1D9FBBD-2782-4A8B-9928-23CE46CD1143
            {
                result = false; // bebasin yg 32
            }

            return result;
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

    }
}
