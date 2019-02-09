using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Showroom.Finance.Class
{
    class clsRekening
    {
        #region DBFunctions
        public static DataTable DBGetByRowID(Guid rowID) {
            return DBTools.DBGetDataTableByRowID("usp_Rekening_LIST",rowID);
        }

        public static DataTable DBGetByMataUang(string sql, string searcArg, string mataUangID, Guid perusahaanID)
        {
            DataTable dt = new DataTable();
            string result = "Ok";
            if (string.IsNullOrEmpty(sql)) result = "SQL Command belum diisi";
            else if (string.IsNullOrEmpty(mataUangID)) result = "Kode Mata Uang belum diisi";
            else if ((perusahaanID==null)||(perusahaanID==Guid.Empty)) result = "Kode Perusahaan belum diisi";
            if (result == "Ok")
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand(sql));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, searcArg));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, mataUangID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanID)); // sebelumnya mataUangID
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                }
                catch { }
            }
            return dt;
        }
        #endregion
    }
}
