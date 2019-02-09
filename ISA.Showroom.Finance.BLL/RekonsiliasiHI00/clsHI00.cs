using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class clsHI00:clsData
    {

#region DBFunctions

        public static DataTable DBGetByRowID(Guid t_rowID)
        {
            DataTable dt = null;
            if ((t_rowID!=null) && (t_rowID!=Guid.Empty))
            dt = DBTools.DBGetDataTableByRowID("usp_HI00_LIST", t_rowID);
            return dt;
        }

        public static DataTable DBGetListByDate(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));

            dt = DBTools.DBGetDataTable("usp_HI00_LIST_FILTER_CabangTanggal", prm);
            return dt;
        }

        public static DataTable DBGetListSummary(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));

            dt = DBTools.DBGetDataTable("usp_HI00_LIST_Summary", prm);
            return dt;
        }

       public static DataTable DBGetListReconcile(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));

            dt = DBTools.DBGetDataTable("usp_HI00_LIST_Reconcile", prm);
            return dt;
        }

       public static DataTable DBGetListPendingReconcile(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
       {
           DataTable dt = null;
           List<Parameter> prm = new List<Parameter>();
           prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
           prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
           prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
           prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));

           dt = DBTools.DBGetDataTable("usp_HI00_LIST_Reconcile_Pending", prm);
           return dt;
       }

       public static DataTable DBGetSaldoAwalHI00(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
       {
           DataTable dt = null;
           List<Parameter> prm = new List<Parameter>();
           prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
           prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
           prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));

           dt = DBTools.DBGetDataTable("usp_GetSaldoHI00", prm);
           return dt;
       }
#endregion

    }
}
