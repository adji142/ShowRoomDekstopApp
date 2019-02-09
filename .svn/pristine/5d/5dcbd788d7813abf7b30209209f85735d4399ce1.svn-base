using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ISA.DAL;
using ISA.Showroom.Finance.BLL.UtilityManager;

namespace ISA.Showroom.Finance.BLL
{
    public class clsPengeluaran:clsData
    {  
        public static DataTable DBGetByRowID(Guid rowID)
        {
            DataTable dt = null;
            if ((rowID !=null) && (rowID!=Guid.Empty)) 
            dt = DBTools.DBGetDataTableByRowID("usp_PengeluaranUang_LIST", rowID);
            return dt;

        }
    }
}
