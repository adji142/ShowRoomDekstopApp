using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.Common;
using ISA.DAL;

namespace ISA.Showroom.Finance.Class
{
    class DKN
    {
        static string _recordID;
        static string _recordIDDetail = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

        static Guid _rowID;
        public static void DKNInsert(Database db, string DK, string refTipe, string CD, string src, DateTime tglBukti, string cabang, string refNoBukti, Guid refRowIDHeader)
        {
            string _noDKN = numeratorDKN(DK, cabang);
            _rowID = Guid.NewGuid();
            _recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial)+cabang.Substring(0, 2);
            db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_DKN_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordID));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tglBukti));
                db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, _noDKN));
                db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, DK));
                db.Commands[0].Parameters.Add(new Parameter("@CD", SqlDbType.VarChar, CD));
                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, src));
                db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, cabang));
                db.Commands[0].Parameters.Add(new Parameter("@RefTipe", SqlDbType.VarChar, refTipe));
                db.Commands[0].Parameters.Add(new Parameter("@RefNoBukti", SqlDbType.VarChar, refNoBukti));
                db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowIDHeader));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            
        }

        public static void DKNDetailInsert(Database db, string noPerkiraan, string uraian, double jumlah, Guid refRowIDDetail)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_DKNDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, refRowIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, jumlah));
            db.Commands[0].Parameters.Add(new Parameter("@Dari", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, ""));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();

        }

        public static string numeratorDKN(string DK, string cabang)
        {
            string _noDKN=string.Empty;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinanceOto))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_BOOK"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "DKN"));
                dt = db.Commands[0].ExecuteDataTable();
            }

            string nomor = dt.Rows[0]["Nomor"].ToString();
            if (nomor.Length == 1)
                nomor = "00" + nomor;
            else if (nomor.Length == 2)
                nomor = "0" + nomor;
            if (DK=="K")
            {
                _noDKN = nomor.Substring(0, 3) + "KN" + GlobalVar.CabangID.Substring(0, 2) + cabang.Substring(0, 2);
            }
            else
            {
                _noDKN = nomor.ToString().Substring(0, 3) + "DN" + GlobalVar.CabangID.Substring(0, 2) + cabang.Substring(0, 2);
            }
            return _noDKN;
        }
    }
}
