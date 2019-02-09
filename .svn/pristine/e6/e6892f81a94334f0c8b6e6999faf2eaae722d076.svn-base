using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Class
{
    public class clsSalesman:clsBase
    {
        #region FIELDS
		string _namaSales;
		DateTime? _tglMasuk;
		DateTime? _tglKeluar;
        #endregion

        #region PROPERTIES
        public string NamaSales { get { return _namaSales; } set { _namaSales = value; } }
        public DateTime? TglMasuk { get { return _tglMasuk; } set { _tglMasuk = value; } }
        public DateTime? TglKeluar { get { return _tglKeluar; } set { _tglKeluar = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsSalesman()
        {
        }

        public clsSalesman(Guid t_rowID)
        {
            try
            {
                DataTable dt = DBGetByRowID(t_rowID);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    SetFromDataRow(dt.Rows[0]);
                    _clsState = enumClsState.Update;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FUNCTIONS
        public void Reset()
        {
            _namaSales = "";
            _tglMasuk = GlobalVar.GetServerDate;
            _tglKeluar = null;
        } 

        public void Baru() { 
            try
            {
                Reset();
                RowID = Guid.NewGuid();
                LastUpdatedBy = SecurityManager.UserID;
                base._clsState = enumClsState.New;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetFromDataRow(DataRow dr)
        {
            try
            {
                RowID = (Guid)dr["RowID"];
                _namaSales = dr["Nama"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DBFunctions
        public static DataTable DBSearch(string _searchArg)
        {
            DataTable dt = new DataTable();
                try
                {
                    using (Database db = new Database())
                    {
                        List<Parameter> prm = new List<Parameter>();
                        prm.Add(new Parameter("@Nama", SqlDbType.VarChar, _searchArg));
                        Command cmd = db.CreateCommand("usp_Sales_LIST");
                        cmd.Parameters = prm;
                        dt = cmd.ExecuteDataTable();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return dt;
        }

        public bool DBFind(string _searchArg)
        {
            bool result = false;
            try
            {
                DataTable dt = DBSearch(_searchArg);
                if ((dt != null) && (dt.Rows.Count == 1))
                {
                    SetFromDataRow(dt.Rows[0]);
                    base._clsState = enumClsState.Update;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool DBFind(Guid t_rowID)
        {
            bool result = false;
            try
            {
                DataTable dt = DBTools.DBGetDataTableByRowID("usp_Sales_LIST", t_rowID);
                if ((dt != null) && (dt.Rows.Count > 0)) result = true;
                //DataTable dt = DBGetByRowID(t_rowID);
                //if ((dt != null) && (dt.Rows.Count == 1))
                //{
                //    SetFromDataRow(dt.Rows[0]);
                //    base._clsState = enumClsState.Update;
                //    result = true;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region
        DataTable DBGetByRowID(Guid t_rowID)
        {
            return DBTools.DBGetDataTableByRowID("usp_Sales_LIST",t_rowID);
        }
        #endregion
    }
}
