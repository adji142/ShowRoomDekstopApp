using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Net.Mail;
using System.Net.Mime;

namespace ISA.Showroom.Finance.Class
{
    class CekData
    {
        static DateTime TglCek = GlobalVar.GetServerDate.Date.AddDays(-1).Date;


        public static bool CekKasOpname()
        {
            bool hasil = false;

            if (TglCek.DayOfWeek.ToString() == "Sunday")
            {
                TglCek = TglCek.Date.AddDays(-1).Date;
            }

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_KasOpname_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, TglCek));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, TglCek));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if(dt.Rows.Count > 0)
            {
                hasil = true;
            }

            return hasil;
        }


    }
}
