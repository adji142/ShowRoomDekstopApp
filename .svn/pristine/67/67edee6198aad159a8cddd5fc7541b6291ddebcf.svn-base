using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class clsCabang : clsData
    {
        #region FIELDS
        string _cabangID;
        string _nama;
        Guid _perusahaanRowID;
        #endregion

        #region PROPERTIES
        public string CabangID { get { return _cabangID; } set { _cabangID = value; } }
        public string Nama { get { return _nama; } set { _nama = value; } }
        public Guid PerusahaanRowID { get { return _perusahaanRowID; } set { _perusahaanRowID = value; } }
        #endregion

        #region FUNCTIONS
        void SetFromDataRow(DataRow dr)
        {
            try
            {
                _cabangID = dr["CabangID"].ToString();
                _nama = dr["Nama"].ToString();
                _perusahaanRowID = new Guid(dr["PerusahaanRowID"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Konstruktor
        public clsCabang(string cabangID)
        {
            DataTable dt = new DataTable();
            dt = DBGetByID(cabangID);
            if ((dt != null) && (dt.Rows.Count > 0)) SetFromDataRow(dt.Rows[0]);
        }
        #endregion

        #region DBFunctions

        public static DataTable DBGetGudang(string cabangID)
        {
            DataTable dt = new DataTable();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            dt = DBTools.DBGetDataTable("usp_gudang_LIST", prm);
            return dt;
        }

        public static DataTable DBGetList()
        {
            DataTable dt = DBTools.DBGetDataTable("usp_Cabang_LIST",new List<Parameter>());
            return dt;
        }

        public static DataTable DBGetByID(string cabangID)
        {
            DataTable dt = new DataTable();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            dt = DBTools.DBGetDataTable("usp_Cabang_LIST",prm);
            return dt;
        }

        public static DataTable DBGetListplusHO(string _cabangID, Guid _ptRowID)
        {
            return DBGetListplusHO(_cabangID, _ptRowID, false);
        }

        public static DataTable DBGetListplusHO(string _cabangID, Guid _ptRowID, bool _cabIncl)
        {
            DataTable dtCabang = DBTools.DBGetDataTable("usp_Cabang_LIST", new List<Parameter>());
            DataTable dtPerusahaan = DBTools.DBGetDataTable("usp_Perusahaan_LIST", new List<Parameter>());
            DataTable dt = new DataTable();
            dt.Columns.Add("CabangID", typeof(System.String));
            dt.Columns.Add("Nama", typeof(System.String));
            string cab;
            Guid pt;
            bool _add;
            foreach (DataRow r in dtCabang.Rows)
            {
                cab = r["CabangID"].ToString();
                if ((_cabIncl)||(cab != _cabangID)&&(_cabangID!="11"))
                {
                    DataRow dr = dt.Rows.Add();
                    dr["CabangID"] = r["CabangID"];
                    dr["Nama"] = r["CabangID"].ToString() + " | " + r["Nama"].ToString();
                }
            }

            foreach (DataRow r in dtPerusahaan.Rows)
            {
                cab = r["InitGudang"].ToString();
                pt = new Guid(r["RowID"].ToString());
                _add = (_cabangID==r["InitCabang"].ToString())?(_ptRowID!=pt):(_ptRowID==pt);
                
                if ((_cabIncl)||(!string.IsNullOrEmpty(cab) && _add))
                {
                    DataRow dr = dt.Rows.Add();
                    dr["CabangID"] = r["InitGudang"].ToString();
                    //dr["Nama"] = r["InitGudang"].ToString() + " | (" + r["InitPerusahaan"].ToString()+") Palur - HO";
                    dr["Nama"] = r["InitGudang"].ToString() + " | Palur - " + r["InitPerusahaan"].ToString();
                }
            }
            dt.DefaultView.Sort = "CabangID ASC";
            return dt;
        }
        #endregion 
    }
}
