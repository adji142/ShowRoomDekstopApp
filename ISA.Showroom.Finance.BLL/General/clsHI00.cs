using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class clsHI00Detail:clsData
    {
        public static DataTable DBListByHeaderRowID(Guid hrowID)
        {
            DataTable dt = null;
            if ((hrowID != null) && (hrowID != Guid.Empty))
                dt = DBTools.DBGetDataTableByRowID("usp_HI00Detail_LIST_FILTER_HeaderID", hrowID);
            return dt;
        }
    }
}
