using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using ISA.Showroom.Finance.BLL.CommonObject;
using System.IO;
using ISA.Showroom.Finance.BLL.UtilityManager;
using ISA.Common;

namespace ISA.Showroom.Finance.BLL
{
    [Serializable]
    public class clsHI11:clsData
    {
        
        #region FIELDS
        Guid _rowID;
        string _noBukti;
        DateTime? _tanggal;
        Enums.enumTipeDKN _tipeDKN;
        Enums.enumTipeHI _tipeHI;
        Guid _perusahaanDariRowID;
        Guid _perusahaanKeRowID;
        Guid _kelompokTransaksiRowID;
        string _cabangDariID;
        string _cabangKeID;
        double _nominal;
        #endregion

        #region PROPERTIES
        //public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public DateTime? Tanggal { get { return _tanggal; } set { _tanggal = value; } }
        public Guid PerusahaanDariRowID { get { return _perusahaanDariRowID; } set { _perusahaanDariRowID = value; } }
        public Guid PerusahaanKeRowID { get { return _perusahaanKeRowID; } set { _perusahaanKeRowID = value; } }
        public Guid KelompokTransaksiHIRowID { get { return _kelompokTransaksiRowID; } set { _kelompokTransaksiRowID = value; } }
        public string CabangDariID { get { return _cabangDariID; } set { _cabangDariID = value; } }
        public string CabangKeID { get { return _cabangKeID; } set { _cabangKeID = value; } }
        public string NoBukti { get { return _noBukti; } set { _noBukti = value; } }
        public Enums.enumTipeDKN TipeDKN { get { return _tipeDKN; } set { _tipeDKN = value; } }
        public double Nominal { get { return _nominal; } set { _nominal = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsHI11() { }

        public clsHI11(DataRow dr)
        {
        }

        public clsHI11(Guid _rowID)
        {
            try
            {
                DataTable dt = DBGetByRowID(_rowID);
                GetFromDataRow(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        #endregion

        #region FUNCTIONS
        public string getTipeTransaksi()
        {
            return "HI11";
        }

        void GetFromDataRow(DataRow dr)
        {
            try
            {
                _rowID = dr.Field<Guid>("RowID");
                _noBukti = dr.Field<string>("NoBukti");
                _tanggal = dr.Field<DateTime?>("Tanggal");
                _perusahaanDariRowID = dr.Field<Guid>("PerusahaanDariRowID");
                _perusahaanKeRowID = dr.Field<Guid>("PerusahaanKeRowID");
                _cabangDariID = dr.Field<string>("CabangDariID");
                _cabangKeID = dr.Field<string>("CabangKeID");
                _tipeDKN = (Enums.enumTipeDKN)int.Parse(dr["TipeNota"].ToString());
                _tipeHI = (Enums.enumTipeHI)int.Parse(dr["TipeHI"].ToString());
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        #region Upload-Download
        public static string DKN00To11(DataTable tblHeader, UserObject userObject)
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            DataTable dtSdhDownload = tblHeader.Clone();
            DataTable dt = new DataTable();
            //            int result = 0;
            string _dk = "";
            object rslt = null;

            using (Database db = new Database())
            {
                List<Parameter> prm = new List<Parameter>();
                string _src, _cabId;
                int _tipeHI;
                db.BeginTransaction();
                // HEADERS
                db.Commands.Add(db.CreateCommand("usp_HI00_Download"));
                db.Commands.Add(db.CreateCommand("usp_DKN_Download"));
                bool _cabRowID = tblHeader.Columns.Contains("HRowID");
                foreach (DataRow dr in tblHeader.Rows)
                {
                    try
                    {
                        _src = Tools.isNull(dr["src"], "").ToString();
                        _tipeHI = (_src == "STR") ? 0 : 1;
                        _cabId = Tools.isNull(dr["dari"], "").ToString().Trim();
                        if ((_cabId.Substring(0, 2) != userObject.CabangID) && (userObject.CabangID != "11")) 
                            rslt = "Bukan HI Cabang anda.";

                        else
                        {
                            //add parameters
                            _dk = (Tools.isNull(dr["dk"], "").ToString() == "D") ? "K" : "D";
                            prm.Clear();
                            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, userObject.SelectedPerusahaanRowID));
                            if (_cabRowID==true) prm.Add(new Parameter("@HRowID", SqlDbType.UniqueIdentifier, new Guid(Tools.isNull(dr["HRowID"], Guid.Empty).ToString())));
                            if (_cabRowID == true) prm.Add(new Parameter("@DRowID", SqlDbType.UniqueIdentifier, new Guid(Tools.isNull(dr["DtRowID"], Guid.Empty).ToString())));
                            prm.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idhead"], "").ToString()));
                            prm.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddetail"], "").ToString()));
                            prm.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dr["tanggal"]));
                            prm.Add(new Parameter("@NoDKN", SqlDbType.VarChar, Tools.isNull(dr["no_dkn"], "").ToString()));
                            prm.Add(new Parameter("@TipeHI", SqlDbType.TinyInt, _tipeHI));
                            prm.Add(new Parameter("@DK", SqlDbType.VarChar, _dk));
                            prm.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cabang"], "").ToString()));
                            prm.Add(new Parameter("@CD", SqlDbType.VarChar, Tools.isNull(dr["cd"], "").ToString()));
                            prm.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr["src"], "").ToString()));
                            prm.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString()));
                            prm.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString()));
                            prm.Add(new Parameter("@Jumlah", SqlDbType.Money, (dr["jumlah"])));
                            prm.Add(new Parameter("@Dari", SqlDbType.VarChar, _cabId));
                            prm.Add(new Parameter("@Tolak", SqlDbType.Bit, (dr["ltolak"])));
                            prm.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["alasan"], "").ToString()));
                            prm.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, userObject.UserID));

                            db.Commands[0].Parameters = prm;
                            rslt = db.Commands[0].ExecuteScalar();
                            if ((Tools.isNull(rslt, "").ToString() == "Ok") && (_tipeHI == 1))
                            {
                                db.Commands[1].Parameters = prm;
                                rslt = db.Commands[1].ExecuteScalar();
                            }
                            if (Tools.isNull(rslt, "").ToString() == "Ok") counter++;
                            else
                            {
                                rslt = rslt + "; NoDKN : " + Tools.isNull(dr["no_dkn"], "").ToString()
                                            +"; iddetail : " +Tools.isNull(dr["iddetail"], "").ToString();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        rslt = "Catch error : " + ex.Message + ";  No.DKN : " + Tools.isNull(dr["no_dkn"], "").ToString()
                               +"; iddetail : " +Tools.isNull(dr["iddetail"], "").ToString();
                        break;
                    }
                }
                if (Tools.isNull(rslt, "").ToString() == "Ok") db.CommitTransaction(); else db.RollbackTransaction();
            }
            return Tools.isNull(rslt, "").ToString() ;
        }

        public static String DT11_2_DBF00(DataTable dtH, DataTable dt, String folder, String ZipFileName)
        {
            string sresult = "";
            try
            {
                DataTable dtUpload = new DataTable();
                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("Tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("NoDKN", "no_dkn", Foxpro.enFoxproTypes.Char, 10));
                fields.Add(new Foxpro.DataStruct("DK", "dk", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("HRecordID", "idhead", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("CD", "cd", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Src", "src", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("RecordID", "iddetail", Foxpro.enFoxproTypes.Char, 25));
                fields.Add(new Foxpro.DataStruct("NoPerkiraan", "no_perk", Foxpro.enFoxproTypes.Char, 12));
                fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
                fields.Add(new Foxpro.DataStruct("Jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 15));
                fields.Add(new Foxpro.DataStruct("Dari", "dari", Foxpro.enFoxproTypes.Char, 4));
                fields.Add(new Foxpro.DataStruct("Tolak", "ltolak", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("Alasan", "alasan", Foxpro.enFoxproTypes.Char, 30));

                string filedta = folder.Trim() + "datahi";
                string fileDbf = filedta + ".dbf";
                string fileXml = filedta + ".xml";
                string fileZip = folder.Trim() + ZipFileName.Trim() + ".zip";

                if (File.Exists(fileDbf)) File.Delete(fileDbf);
                if (File.Exists(fileZip)) File.Delete(fileZip);
                dt.WriteXml(fileXml);
                Foxpro.WriteFile(folder.Trim(), "datahi", fields, dt);
                ISA.Common.Zip.ZipFiles(fileDbf, fileZip);
                File.Delete(fileDbf);
                File.Delete(fileXml);

                //set SyncFlag = 1
                using (Database db = new Database())
                {
                    db.BeginTransaction();
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_UPDATE_SyncFlag"));
                    Guid rowID;
                    foreach (DataRow dr in dtUpload.Rows)
                    {
                        try
                        {
                            rowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserObject.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        catch (Exception ex1)
                        {
                            sresult = ex1.Message;
                        }
                    }
                    if (sresult == "") db.CommitTransaction(); else db.RollbackTransaction();
                }
            }
            catch (Exception ex)
            {
                sresult = ex.Message;
            }

            return sresult;
        }

        public static DataTable Extract(String ExtFile, String FolderName, String FileName, String ZipFileName)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(ZipFileName)) Zip.UnZipFiles(FolderName + ZipFileName + ".ZIP", FolderName, false);
                dt = Foxpro.ReadFile(FolderName + FileName + ".DBF");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return dt;
        }

        public static string DKN00To11_new(DataTable tblHeader, UserObject userObject, bool gg)
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            DataTable dtSdhDownload = tblHeader.Clone();
            DataTable dt = new DataTable();
            //            int result = 0;
            string _dk = "";
            object rslt = null;

            using (Database db = new Database())
            {
                List<Parameter> prm = new List<Parameter>();
                string _src, _cabId;
                int _tipeHI;
                db.BeginTransaction();
                // HEADERS
                db.Commands.Add(db.CreateCommand("usp_HI00_Download"));
                db.Commands.Add(db.CreateCommand("[usp_DKN_Download_newDKN]"));
                bool _cabRowID = tblHeader.Columns.Contains("HRowID");
                foreach (DataRow dr in tblHeader.Rows)
                {
                    try
                    {
                        _src = Tools.isNull(dr["src"], "").ToString();
                        _tipeHI = (_src == "STR") ? 0 : 1;
                        _cabId = Tools.isNull(dr["dari"], "").ToString().Trim();
                        if ((_cabId.Substring(0, 2) != userObject.CabangID) && (userObject.CabangID != "11"))
                            rslt = "Bukan HI Cabang anda.";

                        else
                        {
                            //add parameters
                            _dk = (Tools.isNull(dr["dk"], "").ToString() == "D") ? "K" : "D";
                            prm.Clear();
                            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, userObject.SelectedPerusahaanRowID));
                            if (_cabRowID == true) prm.Add(new Parameter("@HRowID", SqlDbType.UniqueIdentifier, new Guid(Tools.isNull(dr["HRowID"], Guid.Empty).ToString())));
                            if (_cabRowID == true) prm.Add(new Parameter("@DRowID", SqlDbType.UniqueIdentifier, new Guid(Tools.isNull(dr["DtRowID"], Guid.Empty).ToString())));
                            prm.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idhead"], "").ToString()));
                            prm.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddetail"], "").ToString()));
                            prm.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dr["tanggal"]));
                            prm.Add(new Parameter("@NoDKN", SqlDbType.VarChar, Tools.isNull(dr["no_dkn"], "").ToString()));
                            prm.Add(new Parameter("@TipeHI", SqlDbType.TinyInt, _tipeHI));
                            prm.Add(new Parameter("@DK", SqlDbType.VarChar, _dk));
                            prm.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cabang"], "").ToString()));
                            prm.Add(new Parameter("@CD", SqlDbType.VarChar, Tools.isNull(dr["cd"], "").ToString()));
                            prm.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr["src"], "").ToString()));
                            prm.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString()));
                            prm.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString()));
                            prm.Add(new Parameter("@Jumlah", SqlDbType.Money, (dr["jumlah"])));
                            prm.Add(new Parameter("@Dari", SqlDbType.VarChar, _cabId));
                            prm.Add(new Parameter("@Tolak", SqlDbType.Bit, (dr["ltolak"])));
                            prm.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["alasan"], "").ToString()));
                            prm.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, userObject.UserID));

                            db.Commands[0].Parameters = prm;
                            rslt = db.Commands[0].ExecuteScalar();
                            if ((Tools.isNull(rslt, "").ToString() == "Ok") && (_tipeHI == 1))
                            {
                                db.Commands[1].Parameters = prm;
                                rslt = db.Commands[1].ExecuteScalar();
                            }
                            if (Tools.isNull(rslt, "").ToString() == "Ok") counter++;
                            else
                            {
                                rslt = rslt + "; NoDKN : " + Tools.isNull(dr["no_dkn"], "").ToString()
                                            + "; iddetail : " + Tools.isNull(dr["iddetail"], "").ToString();
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        rslt = "Catch error : " + ex.Message + ";  No.DKN : " + Tools.isNull(dr["no_dkn"], "").ToString()
                               + "; iddetail : " + Tools.isNull(dr["iddetail"], "").ToString();
                        break;
                    }
                }
                if (Tools.isNull(rslt, "").ToString() == "Ok") db.CommitTransaction(); else db.RollbackTransaction();
            }
            return Tools.isNull(rslt, "").ToString();
        }
        #endregion
        #endregion

        #region DBFunctions
        public static DataTable DBGetByRowID(Guid t_rowID)
        {
            DataTable dt = null;
            if ((t_rowID != null) && (t_rowID != Guid.Empty)) 
                    dt = DBTools.DBGetDataTableByRowID("usp_HubunganIstimewa_LIST", t_rowID); //usp_HI11_LIST
            return dt;
        }

        public static DataTable DBGetListByDate(DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            dt = DBTools.DBGetDataTableByDate("usp_HI11_LIST_ByDate", fromDate, toDate);
            return dt;
        }

        public static DataTable DBGetListHIByDate(UserObject _userObject, Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = DBGetListHIByDate(_userObject.SelectedPerusahaanRowID, _userObject.CabangID, perusahaanRowID, cabangID, fromDate, toDate);
            return dt;
        }

        public static DataTable DBGetListHIByDate(Guid ownPTRowID, string ownCabangID, Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        { 
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, ownPTRowID));
            prm.Add(new Parameter("@OwnCabangID", SqlDbType.VarChar, ownCabangID));
            if ((perusahaanRowID != null) && (perusahaanRowID != Guid.Empty))
                prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@fromDate",SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@toDate",SqlDbType.Date,toDate));

            dt = DBTools.DBGetDataTable("usp_TransaksiHI11_Header", prm);
            //dt = DBTools.DBGetDataTable("usp_TransaksiHI_GroupBy_Header", prm);
            return dt;
        }

        public static DataTable DBGetListDKNByDate(UserObject _userObject, Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, _userObject.SelectedPerusahaanRowID));
            prm.Add(new Parameter("@OwnCabangID", SqlDbType.VarChar, _userObject.CabangID));
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@fromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@toDate", SqlDbType.Date, toDate));

            dt = DBTools.DBGetDataTable("usp_TransaksiDKN11_Summary", prm);
            return dt;
        }

        public static DataTable DBGetRekonHI(Guid ownPtRowID, string ownCabangID, Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, ownPtRowID));
            prm.Add(new Parameter("@OwnCabangID", SqlDbType.VarChar, ownCabangID));
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@fromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@toDate", SqlDbType.Date, toDate));
            dt = DBTools.DBGetDataTable("rsp_RekonsiliasiHI", prm);
            return dt;
        }

        public static DataTable DBGetListDetail(Guid headerRowID)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, headerRowID));
            dt = DBTools.DBGetDataTable("usp_HubunganIstimewaDetail_LIST_FILTER_HeaderID", prm);
            return dt;
        }

        public static DataTable DBGetListDetail(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@fromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@toDate", SqlDbType.Date, toDate));

            dt = DBTools.DBGetDataTable("usp_HubunganIstimewaDetail_LIST_FILTER_Tanggal", prm);
            return dt;
        }

        public static DataSet DBGetListUploadData(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate) {
            DataSet ds = new DataSet();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            if (cabangID != "") prm.Add(new Parameter("@CabangKeID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            prm.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            DataTable dt = DBTools.DBGetDataTable("usp_DKN_Upload", prm);
            dt.Columns.Add("fDownload", typeof(bool));
            foreach (DataRow dr in dt.Rows) dr["fDownload"] = true;
            //DataTable dtH = DBTools.DBGetDataTable("usp_DKN_Upload_Header", prm);
            dt.TableName = "DKNDetail";
            //dtH.TableName = "DKNHeader";
            ds.Tables.Add(dt);
            //ds.Tables.Add(dtH);
            return ds;
        }

        public void DBSave()
        {
            try
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@NoBukti",SqlDbType.VarChar,_noBukti));
                prm.Add(new Parameter("@Tanggal",SqlDbType.Date,_tanggal));
                prm.Add(new Parameter("@PerusahaanDariRowID",SqlDbType.UniqueIdentifier,_perusahaanDariRowID));
                prm.Add(new Parameter("@PerusahaanKeRowID",SqlDbType.UniqueIdentifier,_perusahaanKeRowID));
                prm.Add(new Parameter("@CabangDariID",SqlDbType.VarChar,_cabangDariID));
                prm.Add(new Parameter("@CabangKeID",SqlDbType.VarChar,_cabangKeID));
                prm.Add(new Parameter("@KelompokTransaksiHIRowiD",SqlDbType.UniqueIdentifier,_kelompokTransaksiRowID));
                prm.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserObject.UserID));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HI00_Insert"));
                    db.Commands[0].Parameters = prm;
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        public static DataTable DBGetListRKHI_01(Guid ownPTRowID, string ownCabangID, Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dtHI = null;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiHI_FILTER_CabangTanggal_NEW"));
                    db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, ownPTRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@OwnCabangID", SqlDbType.VarChar, ownCabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
                    dtHI = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return dtHI;
        }

        public static DataTable DBGetListPendingReconcile(Guid perusahaanRowID, string cabangID, DateTime? fromDate, DateTime? toDate)
        {
            DataTable dt = null;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));

            dt = DBTools.DBGetDataTable("usp_HI11_LIST_Reconcile_Pending", prm);
            return dt;
        }

        public static double DBGetSaldoHI(DateTime? tanggal, string cabangID, Guid perusahaanRowID)
        {
            double rslt = 0;
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, tanggal));
            prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, cabangID));
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));

            rslt = double.Parse(Tools.isNull(DBTools.DBGetScalar("usp_GetSaldoHI",prm), "0").ToString());
            return rslt;
        }
        #endregion

    }

    [Serializable]
    public class clsHI11Detail : clsData
    {
        #region FIELDS
        Guid _headerRowID;
        //Guid _rowID;
        string _uraian;
        Guid _mataUangRowID;
        double _nominal;
        double _nominalRp;
        #endregion

        #region PROPERTIES
        public Guid HeaderRowID { get { return _headerRowID; } set { _headerRowID = value; } }
        //public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public string Uraian { get { return _uraian; } set { _uraian = value; } }
        public Guid MataUangRowID { get { return _mataUangRowID; } set { _mataUangRowID = value; } }
        public double Nominal { get { return _nominal; } set { _nominal = value; } }
        public double NominalRp { get { return _nominalRp; } set { _nominalRp = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsHI11Detail() { }
        public clsHI11Detail(Guid t_rowID)
        {
            if ((t_rowID != null) && (t_rowID != Guid.Empty))
            {
            }
        }
        #endregion

        #region FUNCTIONS
        #endregion

        #region DBFunctions
        DataTable DBGetByRowID(Guid t_rowID)
        {
            DataTable dt = null;
            return dt;
        }

        public void DBSave()
        {
            try
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@HeaderRowID",SqlDbType.VarChar,_headerRowID));
                prm.Add(new Parameter("@Uraian",SqlDbType.Date,_uraian));
                prm.Add(new Parameter("@MataUangRowID",SqlDbType.UniqueIdentifier,_mataUangRowID));
                prm.Add(new Parameter("@Nominal",SqlDbType.UniqueIdentifier,_nominal));
                prm.Add(new Parameter("@NominalRp",SqlDbType.VarChar,_nominalRp));
                prm.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserObject.UserID));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HI00_Insert"));
                    db.Commands[0].Parameters = prm;
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        #endregion
    }
}
