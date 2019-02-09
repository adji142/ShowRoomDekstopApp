using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Finance.Class
{
    class clsPenerimaan
    {
        public enum enumState { Empty, New, Update }
        private enumState _state = enumState.Empty;
        Guid _rowID;
        Guid _perusahaanRowID;
        string _noBukti;
        string _cabangID;
        string _cabangDariID;

        public clsPenerimaan(Guid t_rowID) { }

        #region Functions
        public void CreateFromGroupRowID(Guid t_rowID)
        {
            DataTable dt = DBGetByGroupRowID(t_rowID);
            bool rslt;
            if (dt.Rows.Count > 0)
            {
                rslt = true;
                DataRow dr = dt.Rows[0];
                try {
                    _rowID = dr.Field<Guid>("RowID");
                    _noBukti = dr.Field<string>("NoBukti");
                    //_cabangID = dr.Field<string>("CabangDariID");
                } catch {
                    rslt = false;
                }
            } rslt = false;
        }
        #endregion

        #region DBFunctions
        public static DataTable DBGetByRowID(Guid t_rowID)
        {
            return ((t_rowID == null) || (t_rowID == Guid.Empty)) ? null : DBTools.DBGetDataTableByRowID("usp_PenerimaanUang_LIST", t_rowID);
        }

        public static DataTable DBGetByGroupRowID(Guid t_rowID)
        {
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@GroupRowID",SqlDbType.UniqueIdentifier,t_rowID));
            return ((t_rowID == null) || (t_rowID == Guid.Empty)) ? null : DBTools.DBGetDataTable("usp_PenerimaanUang_LIST_FILTER_Group", prm);
        }

        #endregion
    }
}
