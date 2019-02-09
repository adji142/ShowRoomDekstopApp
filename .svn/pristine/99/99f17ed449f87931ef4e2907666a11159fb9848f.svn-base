
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Showroom.Finance.Class
{
    class clsHutangLain2
    {
        public static DataTable GetHLLHeader(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewaAntarPTMINUS_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static DataTable GetHLLDetail(Guid HiRowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_Filter_HI]"));
                db.Commands[0].Parameters.Add(new Parameter("@HiRowID", SqlDbType.UniqueIdentifier, HiRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static DataTable RptHLLHeader(Guid HiRowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaAntarPTMINUS_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HiRowID));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static DataTable RptHLLDetail(Guid HiRowID)
        {
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, HiRowID));
            return DBTools.DBGetDataTable("usp_HubunganIstimewaDetail_LIST_FILTER_HeaderID", prm);
        }

        public static DataTable RptHutangLain2Multi(DateTime _FromDate, DateTime _ToDate, string _CabangID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_HutangLainLain_MultiSheet"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _ToDate));
                if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }


        /// <summary>
        /// Get DKN HI
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <param name="PersFrom"></param>
        /// <param name="PersTo"></param>
        /// <param name="Nota">1 : PLL 
        /// 2 : HLL 
        /// </param>
        /// <returns></returns>
        public static DataTable GetHI_DKN(DateTime? FromDate, DateTime? ToDate, SqlGuid PersFrom, SqlGuid PersTo, int Nota)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewa_LIST_CROSSPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate.HasValue ? FromDate.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate.HasValue ? ToDate.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PersTo));
                    db.Commands[0].Parameters.Add(new Parameter("@TIpeNota", SqlDbType.Int, Nota));
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

        public static DataTable GetHI_DKN(DateTime? FromDate, DateTime? ToDate, SqlGuid PersFrom, SqlGuid PersTo,string Cabang, int Nota)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewa_LIST_CROSSPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate.HasValue ? FromDate.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate.HasValue ? ToDate.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PersTo));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Cabang));
                    db.Commands[0].Parameters.Add(new Parameter("@TIpeNota", SqlDbType.Int, Nota));


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

        public static DataTable GetHI_DKN(Guid RowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewa_LIST_CROSSPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
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


        public static DataTable GetPengeluaranHLL_DKN_Header(SqlGuid HIRowID, SqlGuid PersFrom)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_DKN_HeaderID]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@HIRowID", SqlDbType.UniqueIdentifier, HIRowID));
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

        public static DataTable GetPengeluaranHLL_DKN_Header(Guid ROwID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_DKN_HeaderID]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, ROwID));
             
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


        public static void LinkPengeluaran_DKN(Guid RowID, Guid HIRowiD)
        {

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LINK_HLL_DKN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HIRowiD));
                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);

            }

        }


        public static DataTable GetPenenerimaan_HLL(DateTime? FromDate, DateTime? ToDate, SqlGuid PersFrom, SqlGuid PersTo, SqlGuid JnsTrans)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_LIST_HLL]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FRomDate", SqlDbType.DateTime, FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Todate", SqlDbType.DateTime, ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKe", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDari", SqlDbType.UniqueIdentifier, PersTo));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.UniqueIdentifier, JnsTrans));
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
       
        public static DataTable GetPenenerimaan_HLL(Guid RowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_LIST_HLL]"));
                     
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
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


        public static DataTable GetPengeluaran_HLL_PenerimaanID(SqlGuid PenerimaanROwID, SqlGuid JnsTransaksi)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_HLL_ByPenerimaan]"));

                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PenerimaanROwID));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.UniqueIdentifier, JnsTransaksi));
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

        public static DataTable GetPengeluaran_HLL_PenerimaanID(SqlGuid RowID )
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_HLL_ByPenerimaan]"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
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
        public static void LinkPengeluaran_Penerimaan(Guid RowID, Guid HIRowiD)
        {

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LINK_HLL_Penerimaan]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HIRowiD));
                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);

            }

        }
    }

    class clsPiutangLain2
    {
        public enum enumTipeHI {  HLL,PLL }
        /// <summary>
        /// Header HLL TAB 2
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <param name="PersFrom"></param>
        /// <param name="PersTo"></param>
        /// <returns></returns>
        public static DataTable GetPengeluaranHLL_CrossPT(DateTime? FromDate, DateTime? ToDate, SqlGuid PersFrom, SqlGuid PersTo)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_CrossPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDate.HasValue ? FromDate.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate.HasValue ? ToDate.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PersTo));
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

        /// <summary>
        /// Header HLL TAB 2
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public static DataTable GetPengeluaranHLL_CrossPT(Guid RowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_CrossPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
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

        /// <summary>
        /// Detail Tab 2 HLL
        /// </summary>
        /// <param name="PengeluaranROwID"></param>
        /// <param name="PersFrom"></param>
        /// <returns></returns>
        public static DataTable GetPengeluaranHLL_CrossPT_Header(SqlGuid PengeluaranROwID, SqlGuid PersFrom)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_CrossPT_HeaderID]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, PengeluaranROwID));
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

        /// <summary>
        /// Detail TAb 2 HLL
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public static DataTable GetPengeluaranHLL_CrossPT_Header(Guid RowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_CrossPT_HeaderID]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
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

        /// <summary>
        /// Penerimaan PLL Filter PEngeluaran
        /// </summary>
        /// <param name="PengeluaranRowID"></param>
        /// <param name="PersTo"></param>
        /// <param name="PersFrom"></param>
        /// <returns></returns>
        public static DataTable GetPenerimaanPLL_CrossPT(Guid PengeluaranRowID, SqlGuid PersTo, SqlGuid PersFrom)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_PLL_HEADER"));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, PengeluaranRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKe", SqlDbType.UniqueIdentifier, PersTo));

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

        /// <summary>
        ///  Penerimaan PLL  
        /// </summary>
        /// <param name="RowID"></param>
        /// <returns></returns>
        public static DataTable GetPenerimaanPLL_CrossPT(Guid RowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_PLL_HEADER"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));

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

        

        public static DataTable GetPengeluaran_Mutasi(Guid PnerimaanRowID, Guid PerusahaanKeRowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_PLL_MUTASI_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PnerimaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PerusahaanKeRowID));

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


        public static DataTable GetPengeluaran_Mutasi(Guid PnerimaanRowID,Guid PerusahaanDariRowID, Guid PerusahaanKeRowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_PLL_MUTASI_LIST_2"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PnerimaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PerusahaanDariRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PerusahaanKeRowID));
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
    
        public static DataTable GetPLLDKN_Mutasi(Guid HIRowID, enumTipeHI TipeHI)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewa_LIST_CROSSPT_MUTASI]"));
                    db.Commands[0].Parameters.Add(new Parameter("@HIRowID", SqlDbType.UniqueIdentifier, HIRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.Int, Convert.ToInt32(TipeHI)));
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


        public static void LinkPengeluaran_CrossPT(Guid RowID, Guid HeaderPengeluaran)
        {

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LINK_HLL_CrossPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderPengeluaran));
                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mode">-- Mode : 0 Mutasi Dari PLL TAB 2 NON ECERAN</param>
        /// <param name="PenerimaanRowID"></param>
        /// <param name="PengeluaranRowID"></param>
        /// <param name="LinkID"></param>
        public static void SetPengeluaranUangPLL_Mutasi(int Mode, SqlGuid PenerimaanRowID, SqlGuid PengeluaranRowID, Guid LinkID)
        {
           
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_PLL_MUTASI_UPDaTE"));
                    db.Commands[0].Parameters.Add(new Parameter("@Mode", SqlDbType.Int, Mode));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PenerimaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, PengeluaranRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.UniqueIdentifier, LinkID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands[0].ExecuteNonQuery();
                }
                 
            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);
                 
            }
        }

 /// <summary>
 /// 
 /// </summary>
 /// <param name="PenerimaanRowID"></param>
 /// <param name="PengeluaranRowID"></param>
        public static void SetPengeluaranUangPLL_Mutasi( SqlGuid PenerimaanRowID, SqlGuid PengeluaranRowID)
        {

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_PLL_MUTASI_UPDaTE_2"));
             
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PenerimaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, PengeluaranRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PersFrom">Perusahaan Login</param>
        /// <param name="PersTo">PerusahaanDari</param>
        /// <returns></returns>
        public static DataTable GetPengeluaranHLL_History(SqlGuid PersFrom, SqlGuid PersTo)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_HLL_CrossPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, PersFrom));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PersTo));
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


        public static void SetDKN_Mutasi(SqlGuid PenerimaanRowID, SqlGuid HiRowID)
        {

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKN_PLL_MUTASI_UPDaTE"));

                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, PenerimaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HIRowID", SqlDbType.UniqueIdentifier, HiRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);

            }
        }


        public static void SetDKNHLL_Mutasi(SqlGuid PengeluaranRowID, SqlGuid HiRowID)
        {

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKN_HLL_MUTASI_UPDaTE"));

                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, PengeluaranRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HIRowID", SqlDbType.UniqueIdentifier, HiRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {

                Error.LogError(ex);

            }
        }
    }

}
