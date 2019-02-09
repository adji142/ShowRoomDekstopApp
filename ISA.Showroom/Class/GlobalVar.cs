using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.IO;


namespace ISA.Showroom
{
    class GlobalVar
    {
        static string _applicationID = "D11001";
        static string _perusahaanID;
        static string _cabangID;
        static string _gudang;
        static string _pjawab;
        static string _noktppj;
        static string _jabatan;
        static string _direktur;
        static string _dbfUpload;
        static string _dbfDownload;


        static Boolean _pinResult;
        static Boolean _pinReport;

        static string _SASFoxpro;
        static string _PerusahaanName;
        static DateTime _LastPJTClosing;        
        static string _DBShowroom = ISA.Showroom.Properties.Settings.Default.DBShowroom;
        static string _DBFinanceOto = ISA.Showroom.Properties.Settings.Default.DBFinanceOto;
        static DateTime _currentDate = DateTime.MinValue;
        static DateTime _currentDateTime = DateTime.MinValue;
        static List<int> parameterkuncian = new List<int>();
        static DateTime _DateOfServer = DateTime.MinValue;
        static System.Guid _PerusahaanRowID;

        static System.Guid _KasBesarRowID;
        static string _pjlattachpath;
        static string _AktifIMG;
        static string _masterSTNKattachpath;
        static string _AktifIMG_KTP;
        static string _AktifIMG_KK;
        static string _AktifIMG_FotoDebitur;
        static string _AktifIMG_FotoKendaraan;
        static string _AktifIMG_STNK;
        static string _AktifIMG_BPKB;
        static string _AktifIMG_CekFisik;
        static string _AktifIMG_SuratPersetujuanKredit;
        static string _AktifIMG_SuratPersetujuanPenarikan;
        static string _AktifIMG_Lainlain;

        /// <summary>
        /// ISAShowroomDb
        /// </summary>
        /// 

        public static string Aktif_IMG
        {
            get
            {
                return _AktifIMG;
            }
            set
            {
                _AktifIMG = value;
            }
        }

        public static string AktifIMG_KTP
        {
            get { return _AktifIMG_KTP; }
            set{_AktifIMG_KTP = value;}
        }
        public static string Aktif_IMG_KK
        {
            get { return _AktifIMG_KK; }
            set { _AktifIMG_KK = value; }
        }
        public static string Aktif_IMG_FotoDebitur
        {
            get { return _AktifIMG_FotoDebitur; }
            set { _AktifIMG_FotoDebitur = value; }
        }
        public static string Aktif_IMG_FotoKendaraan
        {
            get { return _AktifIMG_FotoKendaraan; }
            set { _AktifIMG_FotoKendaraan = value; }
        }
        public static string Aktif_IMG_STNK
        {
            get { return _AktifIMG_STNK; }
            set { _AktifIMG_STNK = value; }
        }
        public static string Aktif_IMG_BPKB
        {
            get { return _AktifIMG_BPKB; }
            set { _AktifIMG_BPKB = value; }
        }
        public static string Aktif_IMG_CekFisik
        {
            get { return _AktifIMG_CekFisik; }
            set { _AktifIMG_CekFisik = value; }
        }
        public static string Aktif_IMG_SuratPersetujuanKredit
        {
            get { return _AktifIMG_SuratPersetujuanKredit; }
            set { _AktifIMG_SuratPersetujuanKredit = value; }
        }
        public static string Aktif_IMG_SuratPersetujuanPenarikan
        {
            get { return _AktifIMG_SuratPersetujuanPenarikan; }
            set { _AktifIMG_SuratPersetujuanPenarikan = value; }
        }
        public static string Aktif_IMG_Lainlain
        {
            get { return _AktifIMG_Lainlain; }
            set { _AktifIMG_Lainlain = value; }
        }


        public static string MasterSTNK_AttachPath
        {
            get
            {
                return _masterSTNKattachpath;
            }
            set
            {
                _masterSTNKattachpath = value;
            }
        }

        public static string PJLAttachPath
        {
            get
            {
                return _pjlattachpath;
            }
            set
            {
                _pjlattachpath = value;
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

        public static string ApplicationID
        {
            get
            {
                return _applicationID;
            }
        }

        public static string PerusahaanID
        {
            get
            {
                return _perusahaanID;
            }
            set
            {
                _perusahaanID = value;
            }
        }

        public static string PerusahaanName
        {
            get
            {
                return _PerusahaanName;
            }
            set
            {
                _PerusahaanName = value;
            }
        }

        public static string CabangID
        {
            get
            {
                return _cabangID;
            }
            set
            {
                _cabangID = value;
            }
        }

        public static string Gudang
        {
            get
            {
                return _gudang;
            }
            set
            {
                _gudang = value;
            }
        }

        public static string PenanggungJawab
        {
            get
            {
                return _pjawab;
            }
            set
            {
                _pjawab = value;
            }
        }

        public static string NoKTPPJ
        {
            get
            {
                return _noktppj;
            }
            set
            {
                _noktppj = value;
            }
        }

        public static string Jabatan
        {
            get
            {
                return _jabatan;
            }
            set
            {
                _jabatan = value;
            }
        }

        public static string Direktur
        {
            get
            {
                return _direktur;
            }
            set
            {
                _direktur = value;
            }
        }

        public static Guid PerusahaanRowID
        {
            get
            {
                return _PerusahaanRowID;
            }
        }

        public static Guid KasBesarRowID
        {
            get
            {
                return _KasBesarRowID;
            }
        }

        public static string DbfUpload
        {
            get
            {
                return _dbfUpload;
            }
            set
            {
                _dbfUpload = value;
            }
        }

        public static string DbfDownload
        {
            get
            {
                return _dbfDownload;
            }
            set
            {
                _dbfDownload = value;
            }
        }

        public static string SASFoxpro
        {
            get
            {
                // return _SASFoxpro;
                return "C:\\Temp\\Program Asli\\Database";
            }
            set
            {
                _SASFoxpro = value;
            }
        }

        public static void initialize()
        {
            //load data perusahaan
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _perusahaanID = Tools.isNull(dt.Rows[0]["InitPerusahaan"], "").ToString();
                    _PerusahaanName = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    _cabangID = Tools.isNull(dt.Rows[0]["CabangID"], "").ToString();
                    _pjawab = Tools.isNull(dt.Rows[0]["PenanggungJawab"], "").ToString();
                    _noktppj = Tools.isNull(dt.Rows[0]["NoKTP_PJ"], "").ToString();
                    _jabatan = Tools.isNull(dt.Rows[0]["Jabatan"], "").ToString();
                    _direktur = Tools.isNull(dt.Rows[0]["Direktur"], "").ToString();
                    _PerusahaanRowID =  new System.Guid(Tools.isNull(dt.Rows[0]["RowID"], System.Guid.Empty.ToString()).ToString());
                }

                _LastPJTClosing = new DateTime(1900, 1, 1);
            }

            // load data untuk KasBesar
            using (Database dbf = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dt = new DataTable();
                dbf.Commands.Add(dbf.CreateCommand("usp_Kas_LIST"));
                dbf.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, (Guid)(Tools.isNull(_PerusahaanRowID, System.Guid.Empty.ToString()))));
                dbf.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, "Kas Besar"));
                dt = dbf.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _KasBesarRowID = new System.Guid(Tools.isNull(dt.Rows[0]["RowID"], System.Guid.Empty.ToString()).ToString());
                }
            }

            // ambil Path untuk menyimpan Attachment data Penjualan
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PJLATTACHPATH"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _pjlattachpath = Tools.isNull(dt.Rows[0]["Value"], "").ToString();
                    if (!Directory.Exists(_pjlattachpath))
                    {
                        try
                        {
                            Directory.CreateDirectory(_pjlattachpath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                else
                {
                }
            }

            // ambil status apakah KTP digunakan atau tidak
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "AKTIF_IMG"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0){ _AktifIMG = Tools.isNull(dt.Rows[0]["Value"], "0").ToString();}
                else{_AktifIMG = "0";}
            }

            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_KTP"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_KTP = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_KTP = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_KK"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_KK = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_KK = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_FotoDebitur"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_FotoDebitur = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_FotoDebitur = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_FotoKendaraan"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_FotoKendaraan = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_FotoKendaraan = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_STNK"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_STNK = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_STNK = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_BPKB"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_BPKB = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_BPKB = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_CekFisik"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_CekFisik = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_CekFisik = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_SuratPersetujuanKredit"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_SuratPersetujuanKredit = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_SuratPersetujuanKredit = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_SuratPersetujuanPenarikan"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_SuratPersetujuanPenarikan = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_SuratPersetujuanPenarikan = "0"; }
            }
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PNJ_LainLain"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0) { _AktifIMG_Lainlain = Tools.isNull(dt.Rows[0]["Value"], "0").ToString(); }
                else { _AktifIMG_Lainlain = "0"; }
            }


            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "MASTERSTNK_ATTACHPATH"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _masterSTNKattachpath = Tools.isNull(dt.Rows[0]["Value"], "").ToString();
                    if (!Directory.Exists(_masterSTNKattachpath))
                    {
                        try
                        {
                            Directory.CreateDirectory(_masterSTNKattachpath);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            _DateOfServer = GetServerDate;
                
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

        public static DateTime LastClosingDate
        {
            get
            {
                DateTime result;
                using (Database db = new Database())
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

        public static DateTime GetServerDateTime
        {
            get
            {
                if (_currentDateTime == DateTime.MinValue)
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["TanggalJam"] != System.DBNull.Value) _currentDateTime = (DateTime)dt.Rows[0]["TanggalJam"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message.ToString();
                    }
                }
                return _currentDateTime;
            }
        }


        public static DateTime GetServerDateTime_RealTime
        {
            get
            {
                DataTable dt = new DataTable();
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GetServerDate"));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["TanggalJam"] != System.DBNull.Value) _currentDateTime = (DateTime)dt.Rows[0]["TanggalJam"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                }
                return _currentDateTime;
            }
        }


        public static DateTime DateOfServer
        {
            get { return _DateOfServer; }
        }
        public static List<int> ParameterKuncian
        {
            get
            {
                return parameterkuncian;
            }
        }

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

        public static SPT GetPT
        {
            get
            {
                SPT PT = new SPT();

                return PT;
            }
        }
    }

    struct SPT
    {
        public Guid HTS
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
}
