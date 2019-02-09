using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.Class.GL
{
    class JournalPS
    {
        public static DataTable dtNota(DateTime FromDate, DateTime ToDate, Guid PT)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_JournalNota_LIST_Transaksi"));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanROwID", SqlDbType.UniqueIdentifier, PT));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable dtRetur(DateTime FromDate, DateTime ToDate, Guid PT)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalRetur_LIST_Transaksi]"));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanROwID", SqlDbType.UniqueIdentifier, PT));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable dtKPJ(DateTime FromDate, DateTime ToDate, Guid PT)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalKPJ_LIST_Transaksi]"));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanROwID", SqlDbType.UniqueIdentifier, PT));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable dtKRJ(DateTime FromDate, DateTime ToDate, Guid PT)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalKRJ_LIST_Transaksi]"));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanROwID", SqlDbType.UniqueIdentifier, PT));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable dtIden(DateTime FromDate, DateTime ToDate, Guid PT)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalIden_LIST_Transaksi]"));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanROwID", SqlDbType.UniqueIdentifier, PT));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }


        public static DataTable NoPerkNota(Guid SjRowID, string NoBppb, int SubNoBPB)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_JournalNota_LIST_Noperkiraan"));

                    db.Commands[0].Parameters.Add(new Parameter("@SjRowID", SqlDbType.UniqueIdentifier, SjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBppb", SqlDbType.VarChar, NoBppb));
                    db.Commands[0].Parameters.Add(new Parameter("@SubNoBPB", SqlDbType.Int, SubNoBPB));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable NoPerkRetur(Guid ReturID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalRetur_LIST_Noperkiraan]"));

                    db.Commands[0].Parameters.Add(new Parameter("@returRowID", SqlDbType.UniqueIdentifier, ReturID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static void AddJournalNota(DataRow dr)
        {
            using (Database db = new Database())
            {
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Nota PJ - {0}", dr["Gudang"].ToString());
                double RpNota = Convert.ToDouble(dr["RpNota"]);

                db.BeginTransaction();

                int result = Journal.AddHeader(db, GlobalVar.GetPT.SAP, RowID, RecordID, Convert.ToDateTime(dr["TglNota"]), dr["NoNota"].ToString(),
                   Uraian, "TRD", Gudang, false);
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD header");
                }

                Uraian = string.Format("Piutang {0} - Nota Jual", dr["Gudang"].ToString());
                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, dr["NoPerkHI"].ToString(),
Uraian, RpNota, 0, "D", Guid.Empty, RpNota
                    );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Debet");
                }
                DataTable dtDetail = NoPerkNota((Guid)dr["HeaderID"], dr["NoBPPB"].ToString(), Convert.ToInt32(dr["SubNoBPB"]));
                string NoPerk = string.Empty;
                foreach (DataRow drd in dtDetail.Rows)
                {
                    Uraian = string.Format("Piutang {0} - Nota Jual {1}", dr["Gudang"].ToString(), drd["KLP"].ToString());
                    NoPerk = Tools.isNull(drd["NoPerkiraan"], "").ToString();
                    RpNota = Convert.ToDouble(drd["RpNota"]);

                    if (NoPerk.Equals(""))
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Kredit, Kelompok " + drd["KLP"].ToString() + " belum ada No Perkiraan");
                    }

                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerk,
Uraian, 0, RpNota, "K", Guid.Empty, RpNota
             );
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Kredit");
                    }
                }
                UpdateTrans(db, RowID, (Guid)dr["HeaderID"], dr["NoBPPB"].ToString(), Convert.ToInt32(dr["SubNoBPB"]), "PJK");
                db.CommitTransaction();
            }
        }

        public static void AddJournalRetur(DataRow dr)
        {
            using (Database db = new Database())
            {
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Nota RJ - {0}", dr["Gudang"].ToString());
                double RpNota = Convert.ToDouble(dr["RpNota"]);

                db.BeginTransaction();

                int result = Journal.AddHeader(db, GlobalVar.GetPT.SAP, RowID, RecordID, Convert.ToDateTime(dr["TglNota"]), dr["NoNota"].ToString(),
                   Uraian, "TRD", Gudang, false);
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD header");
                }

                Uraian = string.Format("Piutang {0} - Nota Retur Jual", dr["Gudang"].ToString());
                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, dr["NoPerkHI"].ToString(),
Uraian, 0, RpNota, "K", Guid.Empty, RpNota
                    );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Kredit");
                }
                DataTable dtDetail = NoPerkRetur((Guid)dr["RowID"]);
                string NoPerk = string.Empty;
                foreach (DataRow drd in dtDetail.Rows)
                {
                    Uraian = string.Format("Piutang {0} - Nota Retur Jual {1}", dr["Gudang"].ToString(), drd["KLP"].ToString());
                    NoPerk = Tools.isNull(drd["NoPerkiraan"], "").ToString();
                    RpNota = Convert.ToDouble(drd["RpNota"]);

                    if (NoPerk.Equals(""))
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Debet, Kelompok " + drd["KLP"].ToString() + " belum ada No Perkiraan");
                    }

                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerk,
Uraian, RpNota, 0, "D", Guid.Empty, RpNota
             );
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Debet");
                    }
                }
                UpdateTrans(db, RowID, (Guid)dr["RowID"], "RET");
                db.CommitTransaction();
            }
        }


        public static void AddJournalKPJ(DataRow dr)
        {
            using (Database db = new Database())
            {
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Koreksi Penjualan - {0}", dr["Gudang"].ToString());
                double RpNota = Convert.ToDouble(dr["RpKoreksi"]);
                RpNota = Math.Abs(RpNota);
                double RpKredit = RpNota;
                double RpDebet = RpNota;
                db.BeginTransaction();

                int result = Journal.AddHeader(db, GlobalVar.GetPT.SAP, RowID, RecordID, Convert.ToDateTime(dr["TglKoreksi"]), dr["NoKoreksi"].ToString(),
                   Uraian, "TRD", Gudang, false);
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD header");
                }
                string NoPerkD = string.Empty;
                string NoPerkK = string.Empty;
                string UraianD = string.Empty;
                string UraianK = string.Empty;
                if (dr["DKR"].ToString() == "D")
                {
                    NoPerkD = dr["NoperkHI"].ToString();
                    NoPerkK = dr["NoPerkiraan"].ToString();
                    UraianD = string.Format("Piutang {0} - Koreksi Penjualan ", dr["Gudang"].ToString());
                    UraianK = string.Format("Piutang {0} - Koreksi Penjualan {1}", dr["Gudang"].ToString(), dr["KLP"].ToString());
                }
                else
                {
                    NoPerkD = dr["NoPerkiraan"].ToString();
                    NoPerkK = dr["NoperkHI"].ToString();
                    UraianD = string.Format("Piutang {0} - Koreksi Penjualan {1}", dr["Gudang"].ToString(), dr["KLP"].ToString());
                    UraianK = string.Format("Piutang {0} - Koreksi Penjualan ", dr["Gudang"].ToString());
                }


                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkD,
UraianD, RpDebet, 0, "D", Guid.Empty, RpNota
                    );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Debet");
                }
                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkK,
Uraian, 0, RpKredit, "K", Guid.Empty, RpNota
         );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Kredit");
                }
                UpdateTrans(db, RowID, (Guid)dr["RowID"], "KPJ");
                db.CommitTransaction();
            }
        }

        public static void AddJournalKRJ(DataRow dr)
        {
            using (Database db = new Database())
            {
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Koreksi Retur Penjualan - {0}", dr["Gudang"].ToString());
                double RpNota = Convert.ToDouble(dr["RpKoreksi"]);
                RpNota = Math.Abs(RpNota);
                double RpKredit = RpNota;
                double RpDebet = RpNota;
                db.BeginTransaction();

                int result = Journal.AddHeader(db, GlobalVar.GetPT.SAP, RowID, RecordID, Convert.ToDateTime(dr["TglKoreksi"]), dr["NoKoreksi"].ToString(),
                   Uraian, "TRD", Gudang, false);
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD header");
                }
                string NoPerkD = string.Empty;
                string NoPerkK = string.Empty;
                string UraianD = string.Empty;
                string UraianK = string.Empty;
                if (dr["DKR"].ToString() == "D")
                {
                    NoPerkD = dr["NoperkHI"].ToString();
                    NoPerkK = dr["NoPerkiraan"].ToString();
                    UraianD = string.Format("Piutang {0} - Koreksi Retur Penjualan ", dr["Gudang"].ToString());
                    UraianK = string.Format("Piutang {0} - Koreksi Retur Penjualan {1}", dr["Gudang"].ToString(), dr["KLP"].ToString());
                }
                else
                {
                    NoPerkD = dr["NoPerkiraan"].ToString();
                    NoPerkK = dr["NoperkHI"].ToString();
                    UraianD = string.Format("Piutang {0} - Koreksi Retur Penjualan {1}", dr["Gudang"].ToString(), dr["KLP"].ToString());
                    UraianK = string.Format("Piutang {0} - Koreksi Retur Penjualan ", dr["Gudang"].ToString());
                }


                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkD,
UraianD, RpDebet, 0, "D", Guid.Empty, RpNota
                    );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Debet");
                }
                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkK,
Uraian, 0, RpKredit, "K", Guid.Empty, RpNota
         );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Kredit");
                }


                UpdateTrans(db, RowID, (Guid)dr["RowID"], "KRJ");
                db.CommitTransaction();
            }
        }

        public static void AddJournalIden(DataRow dr)
        {
            using (Database db = new Database())
            {
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Identifikasi Piutang - {0}", dr["Gudang"].ToString());
                double RpNota = Convert.ToDouble(dr["Nominal"]);
                RpNota = Math.Abs(RpNota);
                double RpKredit = RpNota;
                double RpDebet = RpNota;
                db.BeginTransaction();

                int result = Journal.AddHeader(db, GlobalVar.GetPT.SAP, RowID, RecordID, Convert.ToDateTime(dr["TglTrans"]), dr["NoTrans"].ToString(),
                   Uraian, "TRD", Gudang, false);
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD header");
                }
                string NoPerkD = string.Empty;
                string NoPerkK = string.Empty;
                string UraianD = string.Empty;
                string UraianK = string.Empty;

                NoPerkD = dr["NoperkHI"].ToString();
                NoPerkK = "1103.51.100";
                UraianD = string.Format("{0} ", dr["Uraian"].ToString());
                UraianK = string.Format("{0}  ", dr["Uraian"].ToString());


                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkD,
UraianD, RpDebet, 0, "D", Guid.Empty, RpNota
                    );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Debet");
                }
                result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkK,
UraianK, 0, RpKredit, "K", Guid.Empty, RpNota
         );
                if (result != 0)
                {
                    db.RollbackTransaction();
                    throw new Exception("Error ADD Detail Kredit");
                }
                UpdateTrans(db, RowID, (Guid)dr["RowID"], "KAS");
                db.CommitTransaction();
            }
        }

        private static void UpdateTrans(Database db, Guid JournalRowID, Guid RowID, string Trans)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("[usp_JournalPS_UPDATE_JOURNAL]"));

            db.Commands[0].Parameters.Add(new Parameter("@JournalRowiD", SqlDbType.UniqueIdentifier, JournalRowID));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Trans));
            db.Commands[0].Parameters.Add(new Parameter("@LastUPdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();

        }


        private static void UpdateTrans(Database db, Guid JournalRowID, Guid SjRowID, string NoBppb, int SubNoBpb, string Trans)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("[usp_JournalPS_UPDATE_JOURNAL]"));

            db.Commands[0].Parameters.Add(new Parameter("@JournalRowiD", SqlDbType.UniqueIdentifier, JournalRowID));
            db.Commands[0].Parameters.Add(new Parameter("@SjRowID", SqlDbType.UniqueIdentifier, SjRowID));
            db.Commands[0].Parameters.Add(new Parameter("@NoBppb", SqlDbType.VarChar, NoBppb));
            db.Commands[0].Parameters.Add(new Parameter("@subBppb", SqlDbType.Int, SubNoBpb));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Trans));
            db.Commands[0].Parameters.Add(new Parameter("@LastUPdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();

        }

    }

    class JournalBS
    {

        public static DataTable dtKAS(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_KasBon_LIST_FILTER_Tanggal]"));

                    db.Commands[0].Parameters.Add(new Parameter("@ToJournal", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalAwal", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalAkhir", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable dtVJU(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_KasBonVJU_LIST]"));

                    db.Commands[0].Parameters.Add(new Parameter("@ToJournal", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static DataTable dtPSL(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_KasBonPenyelesaian_LIST]"));

                    db.Commands[0].Parameters.Add(new Parameter("@ToJournal", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@FRomDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }


        public static void AddJournalKAS(DataRow dr, bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail)
        {
            using (Database db = new Database())
            {
                //string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.OTO);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal  BS  - {0}", dr["Uraian"].ToString());
                double RpNota = Convert.ToDouble(dr["Nominal"]);
                RpNota = Math.Abs(RpNota);
                double RpKredit = RpNota;
                double RpDebet = RpNota;

                if (isSimulate == true)
                {
                    dtHeader.Rows.Add();
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["RowID"] = RowID;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["RecordID"] = RecordID;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Tanggal"] = dr["Tanggal"];
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["NoReff"] = dr["No_bukti"];
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Cbg"] = Gudang;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Src"] = "BS";
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Uraian"] = Uraian;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Debet"] = RpDebet;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Kredit"] = RpKredit;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Owner"] = "ALL";

                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, dr["NoPerkiraan"].ToString()));
                    DataTable dttemp = db.Commands[0].ExecuteDataTable();
                    db.Commands.Clear();

                    string NamaPerkiraan = "";
                    if (dttemp.Rows.Count > 0)
                    {
                        NamaPerkiraan = dttemp.Rows[0]["NamaPerkiraan"].ToString();
                    }

                    dtDetail.Rows.Add();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RowID"] = Guid.NewGuid();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HeaderID"] = RowID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RecordID"] = Tools.CreateFingerPrint();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HRecordID"] = RecordID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = "116099100";
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = "UM Lainnya";
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Uraian"] = dr["Uraian"].ToString();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["DK"] = 'D';
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Debet"] = RpDebet;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Kredit"] = 0;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["MataUang"] = null;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NilaiOri"] = RpNota;

                    dtDetail.Rows.Add();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RowID"] = Guid.NewGuid();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HeaderID"] = RowID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RecordID"] = Tools.CreateFingerPrint();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HRecordID"] = RecordID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = dr["NoPerkiraan"];
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = NamaPerkiraan;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Uraian"] = dr["Uraian"].ToString();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["DK"] = 'K';
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Debet"] = 0;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Kredit"] = RpKredit;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["MataUang"] = null;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NilaiOri"] = RpNota;
                }
                else
                {
                    db.BeginTransaction();

                    int result = Journal.AddHeader(db, GlobalVar.GetPT.OTO, RowID, RecordID, Convert.ToDateTime(dr["Tanggal"]), dr["No_bukti"].ToString(), Uraian, "BS", Gudang, false);
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD header");
                    }

                    string NoPerkD = "116099100"; // "1160.99.100";
                    string NoPerkK = dr["NoPerkiraan"].ToString();
                    //string UraianD = "UM Lainnya " //sebelum
                    string UraianD = dr["Uraian"].ToString();
                    string UraianK = dr["Uraian"].ToString();


                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkD, UraianD, RpDebet, 0, "D", Guid.Empty, RpNota);
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Debet");
                    }
                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkK, UraianK, 0, RpKredit, "K", Guid.Empty, RpNota);
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Kredit");
                    }
                    UpdateTrans(db, RowID, (Guid)dr["RowId"], "KAS");
                    db.CommitTransaction();
                }
            }
        }

        public static void AddJournalVJU(DataRow dr, bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail)
        {
            using (Database db = new Database())
            {
                //string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.OTO);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Realisasi BS  - {0}", dr["Uraian"].ToString());
                double RpNota = Convert.ToDouble(dr["Kredit"]);
                RpNota = Math.Abs(RpNota);
                double RpKredit = RpNota;
                double RpDebet = RpNota;

                if (isSimulate == true)
                {
                    dtHeader.Rows.Add();
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["RowID"] = RowID;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["RecordID"] = RecordID;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Tanggal"] = dr["Tanggal"];
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["NoReff"] = dr["No_bukti"];
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Cbg"] = Gudang;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Src"] = "BS";
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Uraian"] = Uraian;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Debet"] = RpDebet;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Kredit"] = RpKredit;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Owner"] = "ALL";

                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, dr["NoPerkiraan"].ToString()));
                    DataTable dttemp = db.Commands[0].ExecuteDataTable();
                    db.Commands.Clear();

                    string NamaPerkiraan = "";
                    if (dttemp.Rows.Count > 0)
                    {
                        NamaPerkiraan = dttemp.Rows[0]["NamaPerkiraan"].ToString();
                    }

                    dtDetail.Rows.Add();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RowID"] = Guid.NewGuid();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HeaderID"] = RowID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RecordID"] = Tools.CreateFingerPrint();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HRecordID"] = RecordID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = "";
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = "";
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Uraian"] = dr["Uraian"].ToString();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["DK"] = 'D';
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Debet"] = RpDebet;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Kredit"] = 0;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["MataUang"] = null;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NilaiOri"] = RpNota;

                    dtDetail.Rows.Add();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RowID"] = Guid.NewGuid();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HeaderID"] = RowID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RecordID"] = Tools.CreateFingerPrint();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HRecordID"] = RecordID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = "116099100";
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = "UM Lainnya";
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Uraian"] = dr["Uraian"].ToString();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["DK"] = 'K';
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Debet"] = 0;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Kredit"] = RpKredit;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["MataUang"] = null;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NilaiOri"] = RpNota;
                }
                else
                {
                    db.BeginTransaction();

                    int result = Journal.AddHeader(db, GlobalVar.GetPT.OTO, RowID, RecordID, Convert.ToDateTime(dr["Tanggal"]), dr["No_bukti"].ToString(),
                       Uraian, "BS", Gudang, false);
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD header");
                    }
                    string NoPerkD = dr["NoPerkiraan"].ToString();
                    string NoPerkK = "116099100"; // "1160.99.100";
                    string UraianD = dr["Uraian"].ToString();
                    string UraianK = dr["Uraian"].ToString();
                    // string UraianK = "UM Lainnya "; //sebelumnya


                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkD,
    UraianD, RpDebet, 0, "D", Guid.Empty, RpNota
                        );
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Debet");
                    }
                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkK,
    UraianK, 0, RpKredit, "K", Guid.Empty, RpNota
             );
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Kredit");
                    }
                    UpdateTrans(db, RowID, (Guid)dr["RowID"], "VJU");
                    db.CommitTransaction();
                }
            }
        }

        public static void AddJournalPSL(DataRow dr, bool isSimulate, ref DataTable dtHeader, ref DataTable dtDetail)
        {
            using (Database db = new Database())
            {
                //string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.SAP);
                string Gudang = AutoJournal.GetGudangIDByPTRowID(GlobalVar.GetPT.OTO);
                Guid RowID = Guid.NewGuid();
                string RecordID = Tools.CreateFingerPrint();
                string Uraian = string.Format("Journal Penyelesaian BS  - {0}", dr["Uraian"].ToString());
                double RpNota = Convert.ToDouble(dr["Debet"]) + Convert.ToDouble(dr["Kredit"]);  
                RpNota = Math.Abs(RpNota);
                double RpKredit = RpNota;
                double RpDebet = RpNota;
                string Jenis = dr["No_bukti"].ToString().Substring(4,3);

                if (isSimulate == true)
                {
                    dtHeader.Rows.Add();
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["RowID"] = RowID;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["RecordID"] = RecordID;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Tanggal"] = dr["Tanggal"];
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["NoReff"] = dr["No_bukti"];
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Cbg"] = Gudang;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Src"] = "BS";
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Uraian"] = Uraian;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Debet"] = RpDebet;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Kredit"] = RpKredit;
                    dtHeader.Rows[dtHeader.Rows.Count - 1]["Owner"] = "ALL";

                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, dr["NoPerkiraan"].ToString()));
                    DataTable dttemp = db.Commands[0].ExecuteDataTable();
                    db.Commands.Clear();

                    string NamaPerkiraan = "";
                    if (dttemp.Rows.Count > 0)
                    {
                        NamaPerkiraan = dttemp.Rows[0]["NamaPerkiraan"].ToString();
                    }

                    dtDetail.Rows.Add();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RowID"] = Guid.NewGuid();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HeaderID"] = RowID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RecordID"] = Tools.CreateFingerPrint();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HRecordID"] = RecordID;
                    if (Jenis == "BKK")
                    {
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = "116099100";
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = "UM Lainnya";
                    }
                    else
                    {
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = dr["NoPerkiraan"];
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = NamaPerkiraan;
                    }
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Uraian"] = dr["Uraian"].ToString();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["DK"] = 'D';
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Debet"] = RpDebet;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Kredit"] = 0;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["MataUang"] = null;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NilaiOri"] = RpNota;

                    dtDetail.Rows.Add();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RowID"] = Guid.NewGuid();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HeaderID"] = RowID;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["RecordID"] = Tools.CreateFingerPrint();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["HRecordID"] = RecordID;
                    if (Jenis != "BKK")
                    {
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = "116099100";
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = "UM Lainnya";
                    }
                    else
                    {
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NoPerkiraan"] = dr["NoPerkiraan"];
                        dtDetail.Rows[dtDetail.Rows.Count - 1]["NamaPerkiraan"] = NamaPerkiraan;
                    }
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Uraian"] = dr["Uraian"].ToString();
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["DK"] = 'K';
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Debet"] = 0;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["Kredit"] = RpKredit;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["MataUang"] = null;
                    dtDetail.Rows[dtDetail.Rows.Count - 1]["NilaiOri"] = RpNota;
                }
                else
                {
                    db.BeginTransaction();

                    int result = Journal.AddHeader(db, GlobalVar.GetPT.OTO, RowID, RecordID, Convert.ToDateTime(dr["Tanggal"]), dr["No_bukti"].ToString(),
                       Uraian, "BS", Gudang, false);
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD header");
                    }
                    string NoPerkD = dr["NoPerkiraan"].ToString();
                    string NoPerkK = "116099100"; // "1160.99.100";
                    string UraianD = dr["Uraian"].ToString();
                    string UraianK = dr["Uraian"].ToString();
                    //string UraianK = "UM Lainnya "; //sebelumnya

                    if (dr["DKR"].ToString() == "K")
                    {
                        NoPerkK = dr["NoPerkiraan"].ToString();
                        NoPerkD = "116099100"; // "1160.99.100";
                        UraianK = dr["Uraian"].ToString();
                        UraianD = dr["Uraian"].ToString();
                        //      UraianD = "UM Lainnya "; //sebelumnya
                    }


                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkD,
    UraianD, RpDebet, 0, "D", Guid.Empty, RpNota
                        );
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Debet");
                    }
                    result = Journal.AddDetail(db, Guid.NewGuid(), RowID, Tools.CreateFingerPrint(), RecordID, NoPerkK,
    UraianK, 0, RpKredit, "K", Guid.Empty, RpNota
             );
                    if (result != 0)
                    {
                        db.RollbackTransaction();
                        throw new Exception("Error ADD Detail Kredit");
                    }
                    UpdateTrans(db, RowID, (Guid)dr["RowID"], "PSL");
                    db.CommitTransaction();
                }
            }
        }

        private static void UpdateTrans(Database db, Guid JournalRowID, Guid RowID, string mode)
        {
            int Trans = (mode.ToUpper().Equals("KAS") ? 0 : (mode.ToUpper().Equals("VJU") ? 1 : 2));

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("[usp_JournalBS_Link]"));

            db.Commands[0].Parameters.Add(new Parameter("@JournalRowiD", SqlDbType.UniqueIdentifier, JournalRowID));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@Mode", SqlDbType.Int, Trans));
            db.Commands[0].Parameters.Add(new Parameter("@LastUPdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();

        }
    }

    class JournalGiro
    {
        public static DataTable dtPenerimaan(Guid PenerimaanID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_JournalGiro_Kanvaser_LIST]"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                return dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                return dt;
            }
        }

        public static void UpdateTrans(Database db, Guid JournalRowID, Guid RowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("[usp_JournalGiro_Kanvaser_Update]"));

            db.Commands[0].Parameters.Add(new Parameter("@JournalRowiD", SqlDbType.UniqueIdentifier, JournalRowID));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUPdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();
        }

        // batas updatetransver2 -> untuk non using, pake database manual
        public static void UpdateTrans_ver_2(ref Database dbf, ref int counterdbf, Guid JournalRowID, Guid RowID)
        {
            dbf.Commands.Add(dbf.CreateCommand("[usp_JournalGiro_Kanvaser_Update]"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JournalRowiD", SqlDbType.UniqueIdentifier, JournalRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@LastUPdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
            counterdbf++;
        }

        public static void DeleteTrans(Database db, Guid PenerimaanRowID)
        {


            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("[usp_JournalGiro_Kanvaser_DELETE]"));

            db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PenerimaanRowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUPdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();

        }
    }
}

