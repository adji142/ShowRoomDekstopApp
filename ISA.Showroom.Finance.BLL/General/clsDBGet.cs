using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class clsDBGet:clsData
    {
        public static DataTable DBGetListKlpHI()
        {
            DataTable dt = null;
            dt = DBTools.DBGetDataTable("usp_KelompokTransaksiHI_LIST", new List<Parameter>());
            return dt;
        }
    }
}
