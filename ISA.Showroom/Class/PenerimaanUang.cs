using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data;

namespace ISA.Showroom.Class
{
    class PenerimaanUang
    {
        public static bool checkDelete(Guid rowID, String namaTabel)
        {
            bool hapus = false;
            DataTable dt = new DataTable();

            DateTime dateRecordCreatedOn = DateTime.MinValue;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Check_TanggalInput_Record"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar, namaTabel));
                object objRecordCreatedOn = db.Commands[0].ExecuteScalar();
                if (objRecordCreatedOn != DBNull.Value)
                {
                    dateRecordCreatedOn = Convert.ToDateTime(objRecordCreatedOn);
                }

            }

            if (dateRecordCreatedOn.Date == GlobalVar.GetServerDate.Date) hapus = false;
            else hapus = true;

            return hapus;

        }
    }
}
