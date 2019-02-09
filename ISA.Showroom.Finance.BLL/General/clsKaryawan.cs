using System.Collections.Generic;
using System.Data;
using ISA.DAL;
using System;

namespace ISA.Showroom.Finance.BLL
{
    public class clsKaryawan:clsData
    {
        public static DataTable DBGetList()
        {
            return DBTools.DBGetDataTable("Usp_Karyawan_LIST_Header", new List<Parameter>());
        }

        public static DataTable DBGetList(string cabangID)
        {
            DataTable dt = null;
            try
            {
                string _dbID = UtilityManager.SecurityManager.DatabaseID(cabangID);
                Parameters p = new Parameters();
                p.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                dt = DBTools.DBGetDataTable(_dbID,"Usp_Karyawan_LIST_Header", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
