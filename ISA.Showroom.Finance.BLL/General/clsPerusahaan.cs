using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class clsPerusahaan:clsData
    {
        #region FIELDS
        Guid _rowID;
        string _initPerusahaan;
        string _namaPerusahaan;
        string _initCabang;
        string _initGudang;
        string _noPerkiraanDKN;
        string _noPerkiraanDKNHTS;
        #endregion

        #region PROPERTIES;
        //public Guid RowID { get { return _rowID; } }
        public string InitCabang { get { return _initCabang; } set { _initCabang = value; } }
        public string InitPerusahaan { get { return _initPerusahaan; } set { _initPerusahaan = value; } }
        public string NamaPerusahaan { get { return _namaPerusahaan; } set { _namaPerusahaan = value; } }
        public string InitGudang { get { return _initGudang; } set { _initGudang = value; } }
        public string NoPerkiraanDKN { get { return _noPerkiraanDKN; } set { _noPerkiraanDKN = value; } }
        public string NoPerkiraanDKNHTS { get { return _noPerkiraanDKNHTS; } set { _noPerkiraanDKNHTS = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsPerusahaan() { }

        public clsPerusahaan(Guid rowID)
        {
            DataTable dt = DBGetByRowID(rowID);
            setVarFromDataTable(dt);
        }

        public clsPerusahaan(string initPerusahaan)
        {
            DataTable dt = DBGetByInit(initPerusahaan);
            setVarFromDataTable(dt);
        }

        #endregion

        #region Functions
        void setVarFromDataTable(DataTable dt)
        {
            bool _lOk = ((dt != null) && (dt.Rows.Count > 0));
            if (_lOk==true)
            {
                try
                {
                    DataRow dr = dt.Rows[0];
                    _rowID = dr.Field<Guid>("RowID");
                    _initPerusahaan = dr.Field<string>("InitPerusahaan");
                    _namaPerusahaan = dr.Field<string>("Nama");
                    _initCabang = dr.Field<string>("InitCabang");
                    _initGudang = dr.Field<string>("InitGudang");
                    _noPerkiraanDKN = dr.Field<string>("NoPerkiraanDKN");
                    _noPerkiraanDKNHTS = dr.Field<string>("NoPerkiraanHTS");
                }
                catch
                {
                    _lOk = false;
                }
            }
        }

        #endregion

        #region DBFunctions;
        public static DataTable DBGetByRowID(Guid rowID)
        {
            DataTable dt = new DataTable();
            if ((Guid)Tools.isNull(rowID, Guid.Empty) != Guid.Empty)
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));

                dt = DBTools.DBGetDataTable("usp_Perusahaan_LIST", prm);
            }
            return dt;
        }

        public static DataTable DBGetByInit(string initPerusahaan)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(initPerusahaan))
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@InitPerusahaan", SqlDbType.VarChar, initPerusahaan));
                dt = DBTools.DBGetDataTable("usp_Perusahaan_LIST_FILTER_Init", prm);
            }
            return dt;
        }

        public static string DBGetInitPerusahaan(Guid perusahaanrowID)
        {
            DataTable dt = DBGetByRowID(perusahaanrowID);
            string result = "";
            if (dt.Rows.Count > 0) result = dt.Rows[0]["InitPerusahaan"].ToString();
            return result;
        }

        public static string DBGetInitCabang(Guid perusahaanrowID)
        {
            DataTable dt = DBGetByRowID(perusahaanrowID);
            string result = "";
            if (dt.Rows.Count > 0) result = dt.Rows[0]["InitCabang"].ToString();
            return result;
        }

        public static string DBGetInitGudang(Guid perusahaanrowID)
        {
            DataTable dt = DBGetByRowID(perusahaanrowID);
            string result = "";
            if (dt.Rows.Count > 0) result = dt.Rows[0]["InitGudang"].ToString();
            return result;
        }

        public static DataTable DBGetByInitGudang(string initGudang)
        {
            DataTable dt = null;
            if (!string.IsNullOrEmpty(initGudang))
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@InitGudang", SqlDbType.VarChar, initGudang));
                dt = DBTools.DBGetDataTable("usp_Perusahaan_LIST_FILTER_InitGUdang", prm);
            }
            return dt;
        }

        public static DataTable DBGetListPerusahaanNonEceran()
        {
            DataTable dtPerusahaan = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                dtPerusahaan = db.Commands[0].ExecuteDataTable();
            }
            DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
            dtPerusahaan.Columns.Add(cConcatenated);
            //dtPerusahaan.Rows.Add(Guid.Empty);

            dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";
            dtPerusahaan.Rows.Add(Guid.Empty);

            return dtPerusahaan; 
        }

        public static Guid GetRowIDFromCabangOrGudang(string cabangID)
        {
            Guid perusahaanRowID = Guid.Empty;
            if (!string.IsNullOrEmpty(cabangID))
            {
                int l = cabangID.Trim().Length;

                switch (l)
                {
                    case 2:
                        {
                            clsCabang cab = new clsCabang(cabangID);
                            perusahaanRowID = cab.PerusahaanRowID;
                        }
                        break;
                    case 4:
                        {
                            perusahaanRowID = Guid.Empty;
                            DataTable dtPT = clsPerusahaan.DBGetByInitGudang(cabangID);
                            if ((dtPT != null) && (dtPT.Rows.Count > 0) && (!string.IsNullOrEmpty(dtPT.Rows[0]["RowID"].ToString())))
                                perusahaanRowID = new Guid(dtPT.Rows[0]["RowID"].ToString());
                        }
                        break;
                }
            }
            return perusahaanRowID;
        }
        #endregion

    }
}
