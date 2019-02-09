using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class clsPenerimaan:clsData
    {
        public static DataTable DBGetByRowID(Guid rowID)
        {
            DataTable dt = null;
            if ((rowID != null) && (rowID != Guid.Empty))
                dt = DBTools.DBGetDataTableByRowID("usp_PenerimaanUang_LIST", rowID);
            return dt;
        }
    }
}
