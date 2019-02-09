using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Common;
using ISA.Showroom.Finance.Class;
using ISA.Showroom.Finance.DataTemplates;

namespace ISA.Showroom.Finance.Class
{
    class Perkiraan
    {
        public static DataTable GetPerkiraanKoneksiDetail(string kodeTrn, string kodeCabang)
        {
            DataTable dtResult;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@kodeTrn", SqlDbType.VarChar, kodeTrn));
                db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, kodeCabang));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count == 0)
            {
                throw new Exception(string.Format(Messages.Error.DataNotValid, " Perkiraan Koneksi " + kodeTrn));
            }
            return dtResult;
        }

        public static DataTable GetNoPerkiraanKlpBarang(string klpBarang)
        {
            DataTable dtResult;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));

                db.Commands[0].Parameters.Add(new Parameter("@KelompokBrgID", SqlDbType.VarChar, klpBarang));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count == 0)
            {
                throw new Exception(string.Format(Messages.Error.DataNotValid, " Kelompok Barang " + klpBarang));
            }
            return dtResult;

        }

    }
}
