using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Class
{
    public class clsStokMotor:clsBase
    {
        #region FIELDS
        string _nopol;
        double _hrgjadi;
        double _biayarep;
        double _biayatam;
        string _nomesin;
        string _norangka;
        #endregion

        #region PROPERTIES
        public string Nopol { get { return _nopol; } set { _nopol = value; } }
        public string NoMesin { get { return _nomesin; } set { _nomesin = value; } }
        public string NoRangka { get { return _norangka; } set { _norangka = value; } }
        public double HargaJadi { get { return _hrgjadi; } set { _hrgjadi = value; } }
        public double BiayaRep { get { return _biayarep; } set { _biayarep = value; } }
        public double BiayaTam { get { return _biayatam; } set { _biayatam = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsStokMotor()
        {
        }

        public clsStokMotor(Guid t_rowID)
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
            _nopol = "";
            _hrgjadi = 0; 
        }

        public void Baru()
        {
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
                _nopol = dr["Nopol"].ToString();
                _nomesin = dr["NoMesin"].ToString();
                _norangka = dr["NoRangka"].ToString();
                _hrgjadi =  Convert.ToDouble( Tools.isNull(dr["HargaJadi"],0));
                _biayarep = Convert.ToDouble( Tools.isNull(dr["BiayaRep"], 0));
                _biayatam = Convert.ToDouble( Tools.isNull(dr["BiayaTam"], 0));
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
                    prm.Add(new Parameter("@Nopol", SqlDbType.VarChar, _searchArg));
                    Command cmd = db.CreateCommand("usp_Stock_LIST");
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

        public static DataTable DBSearchStokBARU(string _searchArg)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    List<Parameter> prm = new List<Parameter>();
                    prm.Add(new Parameter("@SearchArg", SqlDbType.VarChar, _searchArg));
                    Command cmd = db.CreateCommand("usp_StockBARU_LIST");
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
                DataTable dt = DBTools.DBGetDataTableByRowID("usp_Stock_LIST", t_rowID);
                if ((dt != null) && (dt.Rows.Count > 0)) result = true;
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
            return DBTools.DBGetDataTableByRowID("usp_Stock_LIST", t_rowID);
        }
        #endregion
    }
}
