using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.IO;


namespace ISA.Showroom.Finance
{
    class GlobalVar
    {
        #region FIELDS
        static string _applicationID = "E11001";
        static string _cabangID;
        static string _perusahaanID;
        static Guid _perusahaanRowID;
        static string _gudang="";
        static string _dbfUpload;
        static string _dbfDownload;

        static Boolean _pinResult;
        static Boolean _pinReport;

        static string _SASFoxpro;
        static string _PerusahaanName;
        static DateTime _LastPJTClosing;

        static string _DBHoldingName = "";
        static string _DBName = ISA.Showroom.Finance.Properties.Settings.Default.DBFinanceOto;
        static string _DBShowroom = ISA.Showroom.Finance.Properties.Settings.Default.DBShowroom;
        static string _DBFinanceOto = ISA.Showroom.Finance.Properties.Settings.Default.DBFinanceOto;

        static DateTime _currentDate = new DateTime();
        static List<int> parameterkuncian = new List<int>();
        static DateTime _DateOfServer = DateTime.MinValue;
        //static string _rekeningAyatSilang;

        //        static string _jnsTransPiutangKaryawan = "04";
        #endregion 

        public static void initialize()
        {
            //            initialize(new Guid("e4a9ad4d-02cb-415a-8946-64f73fe2a63c"));
            _cabangID = "";
            _perusahaanID = "";
            _perusahaanRowID = Guid.Empty;
            _PerusahaanName = "";
            _gudang = "";
        }

        #region PROPERTIES


        public static Boolean pinResult
        {
            get
            {
                return _pinResult;
            }
            set
            {
                _pinResult = value;
            }
        }

        public static Boolean pinReport
        {
            get
            {
                return _pinReport;
            }
            set
            {
                _pinReport = value;
            }
        }

        public static string DBHoldingName
        {
            get
            {
                return _DBHoldingName;
            }
            set
            {
                _DBHoldingName = value;
            }
        }

        public static string DBName
        {
            get
            {
                return _DBName;
            }
            set
            {
                _DBName = value;
            }
        }

        public static string DBShowroom
        {
            get
            {
                return _DBShowroom;
            }
            set
            {
                _DBShowroom = value;
            }
        }

        public static string DBFinanceOto
        {
            get
            {
                return _DBFinanceOto;
            }
            set
            {
                _DBFinanceOto = value;
            }
        }

        public enum enumStatusApproval { Open = 0, Waiting1 = 1, Waiting2 = 2, Rejected = 7, Approved = 8, Closed = 9 } 

        
        public static string ApplicationID { get { return _applicationID; } }

        public static string CabangID { get { return _cabangID; } set { _cabangID = value; } }

        public static string PerusahaanID { get { return _perusahaanID; } set { _perusahaanID = value; } }

        public static Guid PerusahaanRowID { get { return _perusahaanRowID; } set { _perusahaanRowID = value; } }

        public static string PerusahaanName { get { return _PerusahaanName; } set { _PerusahaanName = value; } }

        public static string Gudang { get { return _gudang; } set { _gudang = value; } }

        public static string DbfUpload { get { return _dbfUpload; } set { _dbfUpload = value; } }

        public static string DbfDownload { get { return _dbfDownload; } set { _dbfDownload = value; } }



        public static string SASFoxpro { get {  return "C:\\Temp\\Program Asli\\Database"; } set { _SASFoxpro = value; } }

        public static DateTime LastClosingDate
        {
            get
            {
                DateTime result;
                using (Database db=new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_fnGetClosingStok"));
                    db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "PJT"));

                    db.Commands[0].Parameters.Add(new Parameter("@tglAwal", SqlDbType.DateTime, (_LastPJTClosing != new DateTime(1900, 1, 1)) ? _LastPJTClosing : GlobalVar.GetServerDate.Date));
                    result = (DateTime)db.Commands[0].ExecuteScalar();
                }
                return result;
            }

            set { _LastPJTClosing = value; }
        }

        public static DateTime GetServerDate
         {
             get
             {
                 if (_currentDate == DateTime.MinValue)
                 {
                     DataTable dt = new DataTable();
                     try
                     {
                         using (Database db = new Database())
                         {

                             db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                             dt = db.Commands[0].ExecuteDataTable();
                             //dt = db.Commands[0].ExecuteDataTable();
                             if (dt.Rows.Count > 0)
                             {
                                 if (dt.Rows[0]["Tanggal"] != System.DBNull.Value) _currentDate = (DateTime)dt.Rows[0]["Tanggal"];
                             }
                         }
                     }
                     catch (Exception ex)
                     {
                         string s = ex.Message.ToString();
                     }
                 }
                 return _currentDate;
             }
         }

        public static DateTime? GetBackDatedLockValue()
        {
            DateTime tgl = GetServerDate;
            DataTable dt = DBTools.DBGetDataTable("usp_ParameterKuncian_LIST", new List<Parameter>());
            if (dt.Rows.Count > 0) tgl = tgl.AddDays(- int.Parse(Tools.isNull(dt.Rows[0]["BackdatedLock"], 0).ToString()));
            return tgl;
        }

        #endregion

         public static void initialize(Guid rowID)
         {            //load data perusahaan
             using (Database db = new Database())
             {
                 DataTable dt = new DataTable();
                 db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                 if ((Guid)Tools.isNull(rowID, Guid.Empty) != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                 dt = db.Commands[0].ExecuteDataTable();
                 if (dt.Rows.Count > 0)
                 {
                     _cabangID = Tools.isNull(dt.Rows[0]["CabangID"].ToString(), "").ToString();
                     _perusahaanID = Tools.isNull(dt.Rows[0]["InitPerusahaan"].ToString(), "").ToString();
                     _perusahaanRowID = (Guid)Tools.isNull(dt.Rows[0]["RowID"], System.DBNull.Value);
                     _PerusahaanName = Tools.isNull(dt.Rows[0]["Nama"].ToString(), "").ToString();
                     _gudang = Tools.isNull(dt.Rows[0]["InitGudang"].ToString(), "").ToString();
                     _cabangID = Tools.isNull(dt.Rows[0]["InitCabang"].ToString(), "").ToString();
                    
                 }



                 _LastPJTClosing = new DateTime(1900, 1, 1);
             }


             using (Database db = new Database(GlobalVar.DBFinanceOto))
             {
                 DataTable dt = new DataTable();

                 db.Commands.Add(db.CreateCommand("usp_Lock"));
                 dt = db.Commands[0].ExecuteDataTable();
                 parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);
                 parameterkuncian.Add((int)dt.Rows[0]["PostdatedLock"]);
             }

             //load preferences            
             _dbfUpload = Properties.Settings.Default.DBFUpload;

             _dbfDownload = Properties.Settings.Default.DBFDownload;

             if (!Directory.Exists(_dbfUpload))
             {
                 Directory.CreateDirectory(_dbfUpload);
             }
             if (!Directory.Exists(_dbfDownload))
             {
                 Directory.CreateDirectory(_dbfDownload);
             }
         }

         public static List<int> ParameterKuncian
         {
             get
             {

                 return parameterkuncian;
             }
         }

         public static DateTime DateOfServer
         {
             get { return _DateOfServer; }
         }


         public static bool IsNewDNKN
         {
             get
             {
                 return ISA.Showroom.Finance.Properties.Settings.Default.NewDNKN;
             }
         }

         public static SPT GetPT
         {

             get {
                 SPT PT = new SPT();
                  
                 return PT;
             }
         }

        public static JnsTransaksi GetTransaksi
         {
             get
             {
                 JnsTransaksi Trans = new JnsTransaksi();

                 return Trans;
             }
         }
    }

    struct SPT
    {
        public  Guid HTS
        {

            get { return new Guid("DF656B13-9C20-45F6-8F67-2F673483EC9A"); }
        }

        public Guid PBR
        {

            get { return new Guid("BE7FB0F0-0433-44F6-A9C8-49E374C5A819"); }
        }
        public Guid ECR
        {

            get { return new Guid("A5267FB4-5CD0-4768-A1AC-4D420CE6A672"); }
        }
        public Guid SAP
        {

            get { return new Guid("8D505B68-EC73-4C10-B28B-995A5BE0DEC0"); }
        }
        public Guid DIS
        {

            get { return new Guid("57A3ACB6-8F71-42B3-976D-BEFCC8F74AFC"); }
        }
        public Guid HLD
        {

            get { return new Guid("84B06E3F-7D6D-45DE-81D8-C58AE60B87F5"); }
        }
        public Guid OTO
        {

            get { return new Guid("F0BFEC6B-E92C-44A3-9EEB-F41960503F15"); }
        }

    }

    struct JnsTransaksi {
        public Guid HLL
        {

            get { return new Guid("777458DA-235C-45B5-9DEE-006BEE9E7C2C"); }
        }

        public Guid PLL
        {

            get { return new Guid("579FF9B4-8E53-49D6-84DC-5293004E3ED7"); }
        }

        public Guid PWilA
        {
            get { return new Guid("47939376-93EB-4B6B-9974-13C6152181A8"); }
        }
    }
}
