using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Showroom.Finance;

namespace ISA.Showroom.Finance
{
    static class Numerator
    {

        // tambahan dari isashowroom

        public static string NextNumber(String Doc)
        {
            string result;
            string nomor = "";
            string depan = "";
            string belakang = "";

            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, Doc));
                dt = db.Commands[0].ExecuteDataTable();
            }

                depan = Tools.isNull(dt.Rows[0]["Depan"], "").ToString();
                belakang = Tools.isNull(dt.Rows[0]["Belakang"], "").ToString();

            DataTable dt2 = new DataTable();
            using (Database db2 = new Database())
            {
                db2.Commands.Add(db2.CreateCommand("usp_BikinNomorDokumen"));
                db2.Commands[0].Parameters.Add(new Parameter("@Doc", SqlDbType.VarChar, dt.Rows[0]["Doc"].ToString()));
                db2.Commands[0].Parameters.Add(new Parameter("@Depan", SqlDbType.VarChar, dt.Rows[0]["Depan"].ToString()));
                db2.Commands[0].Parameters.Add(new Parameter("@Belakang", SqlDbType.VarChar, dt.Rows[0]["Belakang"].ToString()));
                db2.Commands[0].Parameters.Add(new Parameter("@Lebar", SqlDbType.Int, dt.Rows[0]["Lebar"]));
                db2.Commands[0].Parameters.Add(new Parameter("@IsShowPrefix", SqlDbType.Bit, 0));
                db2.Commands[0].Parameters.Add(new Parameter("@IsShowSufix", SqlDbType.Bit, 0));
                db2.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt2 = db2.Commands[0].ExecuteDataTable();
            }
            nomor = dt2.Rows[0]["NomorDokumen"].ToString();

            depan = depan.Replace("romawibulan", Romawi(Bulan()));
            depan = depan.Replace("bulan2", Bulan2().ToString());
            depan = depan.Replace("bulan", Bulan().ToString());
            depan = depan.Replace("tahun2", Tahun2());
            depan = depan.Replace("tahun", Tahun());

            belakang = belakang.Replace("romawibulan", Romawi(Bulan()));
            belakang = belakang.Replace("bulan2", Bulan2().ToString());
            belakang = belakang.Replace("bulan", Bulan().ToString());
            belakang = belakang.Replace("tahun2", Tahun2());
            belakang = belakang.Replace("tahun", Tahun());

            result = depan + nomor + belakang;
            return result;
        }

        private static int Bulan()
        {
            return GlobalVar.GetServerDate.Month;
        }

        private static string Bulan2()
        {
            string _bln;
            if (GlobalVar.GetServerDate.Month < 10)
            {
                _bln = "0" + GlobalVar.GetServerDate.Month.ToString();
            }
            else
            {
                _bln = GlobalVar.GetServerDate.Month.ToString();
            }
            return _bln;
        }

        private static string Tahun()
        {
            return GlobalVar.GetServerDate.Year.ToString();
        }

        private static string Tahun2()
        {
            return Tahun().Substring(2, 2);
        }

        private static string Romawi(int number)
        {
            if (-9999 >= number || number >= 9999)
            {
                throw new ArgumentOutOfRangeException("number");
            }

            if (number == 0)
            {
                return "nul";
            }

            StringBuilder sb = new StringBuilder(10);

            if (number < 0)
            {
                sb.Append('-');
                number *= -1;
            }

            string[,] table = new string[,] {
                    { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" }, 
                    { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" }, 
                    { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" },
                    { "", "M", "MM", "MMM", "M(V)", "(V)", "(V)M", "(V)MM", "(V)MMM", "M(X)" } 
                };

            for (int i = 1000, j = 3; i > 0; i /= 10, j--)
            {
                int digit = number / i;
                sb.Append(table[j, digit]);
                number -= digit * i;
            }

            return sb.ToString();
        }

        // akhir dari isashowroom

        public static string GetNumerator(string doc)
        {
            string result;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST_RENDER"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + dt.Rows[0]["Nomor"].ToString().TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd();
            return result;
        }

        public static string GetNextNumerator(string doc)
        {
            string result;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST_RENDER"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + (Convert.ToInt32(dt.Rows[0]["Nomor"])+1).ToString().TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd();
            return result;
        }

        public static string BookNumerator(string doc)
        {
                string result = "";
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                        db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count>0)
                    result = dt.Rows[0]["Depan"].ToString().TrimEnd() + dt.Rows[0]["Nomor"].ToString().TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(0, 2).TrimEnd() + "/" + (dt.Rows[0]["Belakang"].ToString()).Substring(2, 2).TrimEnd();
                }
                catch { }

            return result;
        }

        public static string BookDKNNumerator(string doc)
        {
            string result = "";
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["Depan"].ToString().TrimEnd() + dt.Rows[0]["Nomor"].ToString().TrimEnd() + dt.Rows[0]["Belakang"].ToString().TrimEnd();
            return result;
        }


        public static string GetNomorDokumen(Database pDb, string Doc, string Depan, string Belakang, int Lebar,
                                       bool IsShowPrefix, bool IsShowSufix)
        {
            string result = "";
            DataTable dt = new DataTable();
            Database db = pDb;


            db.Commands.Add(db.CreateCommand("usp_BikinNomorDokumen"));
            db.Commands[0].Parameters.Add(new Parameter("@Doc", SqlDbType.VarChar, Doc));
            db.Commands[0].Parameters.Add(new Parameter("@Depan", SqlDbType.VarChar, Depan));
            db.Commands[0].Parameters.Add(new Parameter("@Belakang", SqlDbType.VarChar, Belakang));
            db.Commands[0].Parameters.Add(new Parameter("@Lebar", SqlDbType.Int, Lebar));
            db.Commands[0].Parameters.Add(new Parameter("@IsShowPrefix", SqlDbType.Bit, IsShowPrefix));
            db.Commands[0].Parameters.Add(new Parameter("@IsShowSufix", SqlDbType.Bit, IsShowSufix));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            dt = db.Commands[0].ExecuteDataTable();

            result = dt.Rows[0]["NomorDokumen"].ToString();
            return result;

        }


        public static string GetNomorDokumen(string Doc, string Depan, string Belakang, int Lebar, 
                                      bool IsShowPrefix, bool IsShowSufix)
        {
            Database pDb = new Database(); 
            string result = GetNomorDokumen(pDb, Doc, Depan, Belakang, Lebar,
                                        IsShowPrefix, IsShowSufix);
            return result;
        }
    }
}
