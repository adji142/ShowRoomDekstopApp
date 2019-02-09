
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ISA.DAL;
using ISA.Showroom.Finance.BLL;

namespace ISA.Showroom.Finance.Class
{
    class clsDKN
    {
        #region FIELDS
        public enum enumTipeNota { DN, KN }
        public enum enumState { Empty, New, Update }
        public enum enumLingkupNota { AntarCabang, AntarPT, HI }
        public enum enumJournalStatus { NonJournal, BelumJournal, SudahJournal }
        public enum enumJournalViewMode { Preview, Post }
        private Guid _rowID;
        private Guid _groupRowID;
        private string _noBukti;
        private string _noGroup;
        private bool _isGroup;
        private DateTime _tanggal;
        private Guid _perusahaanDariRowID;
        private Guid _perusahaanKeRowID;
        private enumState _state = enumState.Empty;
        private string _cabangDariID;
        private string _cabangKeID;
        private string _gudangID;
        private double _nominal;
        private double _nominalRp;
        private string _noPerkiraan;
        private enumTipeNota _tipeNota;
        private enumLingkupNota _lingkupNota;
        private List<clsDKN> DKNChilds = new List<clsDKN>();
        private enumJournalStatus _journalStatus;
        //private bool _isValid2Post;
        private bool _isPosted;
        private Guid _journalRowID;
        private Guid _mataUangRowID;
        private int _errorNo;
        private string _errorMsg;
        private string _src;
        //private clsJournal _journal;
        private DataTable _dtDetail;
        private Guid _journalRowID2;
        #endregion

        #region PROPERTIES
        public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public string NoBukti { get { return _noBukti; } set { _noBukti = value; } }
        public bool IsGroup { get { return _isGroup; } }
        public bool IsPosted { get { return _isPosted; } }
        public Guid PerusahaanDariRowID { get { return _perusahaanDariRowID; } set { _perusahaanDariRowID = value; } }
        public Guid PerusahaanKeRowID { get { return _perusahaanKeRowID; } set { _perusahaanKeRowID = value; } }
        public string CabangDariID { get { return _cabangDariID; } set { _cabangDariID = value; } }
        public string CabangKeID { get { return _cabangKeID; } set { _cabangKeID = value; } }
        public double Nominal { get { return _nominal; } set { _nominal = value; } }
        public Guid MataUangRowID { get { return _mataUangRowID; } set { _mataUangRowID = value; } }
        public double NominalRp { get { return _nominalRp; } set { _nominalRp = value; } }
        public string NoPerkiraan { get { return _noPerkiraan; } set { _noPerkiraan = value; } }
        public enumTipeNota TipeNota { get { return _tipeNota; } set { _tipeNota = value; } }
        public enumLingkupNota LingkupNota { get { return _lingkupNota; } }
        public enumState State { get { return _state; } }
        public int ErrorNo { get { return (int)Tools.isNull(_errorNo, 0); } }
        public string ErrorMsg { get { return string.IsNullOrEmpty(_errorMsg) ? "Ok" : _errorMsg; } }
        //public clsJournal clsJournal { get { return _journal; } }
        public Guid CompanyTo { get; set; }
        public string BranchTo { get; set; }

        public bool Kodomain
        {
            get;
            set;

        }
        #endregion

        #region KONSTRUKTOR
        public clsDKN()
        {
            _journalStatus = enumJournalStatus.NonJournal;
            _isGroup = false;
            BranchTo = string.Empty;
            CompanyTo = Guid.Empty;
            Kodomain = false;
        }

        public clsDKN(Guid t_rowID)
        {
            Kodomain = false;
            BranchTo = string.Empty;
            CompanyTo = Guid.Empty;
            if (DBGetByRowID(t_rowID) == 0) _state = enumState.Update; else _state = enumState.Empty;
        }

        public clsDKN(Guid t_rowID, bool Lawan)
        {
            Kodomain = true;
            BranchTo = string.Empty;
            CompanyTo = Guid.Empty;
            Kodomain = true;
            if (DBGetByRowID(t_rowID) == 0) _state = enumState.Update; else _state = enumState.Empty;
        }

        public clsDKN(Guid t_rowID, string t_noGroup)
        {
            BranchTo = string.Empty;
            CompanyTo = Guid.Empty;
            if (DBGetByRowID(t_rowID) == 0) _state = enumState.Update; else _state = enumState.Empty;
            _noGroup = t_noGroup;
        }

        public string ValidasiManipulasi()
        {
            string sresult = "Ok";
            if (_isPosted) sresult = "Sudah dijurnal";
            else if (_tanggal < GlobalVar.GetBackDatedLockValue()) sresult = "Sudah kadaluarsa";
            //else if ((_hiRowID != null) && (_hiRowID != Guid.Empty)) sresult = "Sudah diproses HI";
            return sresult;
        }

        #endregion

        #region FUNCTIONS
        private void SetError(int errNo, string errMsg)
        {
            _errorNo = errNo;
            _errorMsg = errMsg;
        }

        private bool JournalValidating(enumJournalViewMode mode)
        {
            if (_state == enumState.Empty) SetError(1, "Status DKN kosong");
            if (_errorNo == 0) if ((_perusahaanDariRowID == _perusahaanKeRowID) && (_cabangDariID == _cabangKeID)) SetError(3, "Jurnal : Bukan Transaksi DKN");
            if (_errorNo == 0) if (_src == "KSR") SetError(31, "DKN hasil import transaksi Kasir");
            if (_errorNo == 0) if ((_journalRowID != null) && (_journalRowID != Guid.Empty)) SetError(5, "Sudah Pernah dijurnal");
            _dtDetail = DBGetDetail(_rowID);
            if (_errorNo == 0) if (_dtDetail.Rows.Count <= 0) SetError(2, "DKN tidak mempunyai detail.");
            return (_errorNo == 0);
        }

        public List<clsJournal> GetGLJournal(enumJournalViewMode mode)
        {
            List<clsJournal> _j = new List<clsJournal>();
            clsJournal jh;
            clsJournalDetail jd;
            _isPosted = false;

            if (JournalValidating(mode))
            {
                string l_cabangHO = clsPerusahaan.DBGetInitCabang(_perusahaanDariRowID);
                string l_noperk1, l_noperk2, l_uraian, l_dk1, l_dk2;
                double l_nominalRp, l_nominalOri;
                //double l_totalRp = 0;
                //double l_totalOri = 0;
                Guid l_mataUangRowID;
                clsPerusahaan _hts = new clsPerusahaan("HTS");

                #region Journal #1
                // Insert Header#1 : 
                jh = new clsJournal(_perusahaanDariRowID, _tanggal, _noBukti, "Journal DKN ", "DKN", _gudangID);

                // Insert Detail#1 di Header#1 : 
                // Case : 1. CabangDari = CabangHO --> getPerkiraanDetal
                //        2. getPerkiraanDKNCabangDari
                if (CompanyTo == Guid.Empty)
                {


                    l_noperk1 = AutoJournal.GetPerkiraanDKNCabang(_cabangDariID);
                    l_noperk2 = (_perusahaanDariRowID == _perusahaanKeRowID) ?
                                AutoJournal.GetPerkiraanDKNCabang(_cabangKeID) :
                                ((_perusahaanDariRowID == _hts.RowID) ? AutoJournal.GetPerkiraanDKNHTS(_perusahaanKeRowID)
                                : AutoJournal.GetPerkiraanDKNPT(_perusahaanKeRowID));
                    l_dk1 = (_tipeNota == 0) ? "K" : "D";
                    l_dk2 = (_tipeNota == 0) ? "D" : "K";

                    foreach (DataRow dr in _dtDetail.Rows)
                    {
                        if (_cabangDariID == l_cabangHO) l_noperk1 = dr["NoPerkiraan"].ToString();
                        l_uraian = dr["Uraian"].ToString();
                        l_nominalRp = double.Parse(Tools.isNull(dr["Nominal"], "0").ToString());
                        l_nominalOri = double.Parse(Tools.isNull(dr["NominalRp"], "0").ToString());
                        if (l_nominalRp == 0) l_nominalRp = l_nominalOri;
                        l_mataUangRowID = (Guid)Tools.isNull(dr["MataUangRowID"], Guid.Empty);

                        //--> case 1 : jika cabangdari = cabangHO, bikin detilnya di sini 
                        //                    if (_cabangDariID == l_cabangHO)
                        //                    {
                        jd = new clsJournalDetail(jh.RowID, l_noperk1, l_uraian, l_dk1, l_nominalRp,
                                                  l_mataUangRowID, l_nominalOri, _noBukti);
                        jh.AddDetail(jd);
                        //                    }
                        jd = new clsJournalDetail(jh.RowID, l_noperk2, l_uraian, l_dk2, l_nominalRp,
                                                  l_mataUangRowID, l_nominalOri, _noBukti);
                        jh.AddDetail(jd);

                        //l_totalRp = l_totalRp + l_nominalRp;
                        //l_totalOri = l_totalOri + l_nominalOri;
                    }
                }
                else
                {
                    //1
                    if (_tipeNota != 0)
                    {
                        l_dk1 = (_tipeNota == 0) ? "K" : "D"; //D
                        l_dk2 = (_tipeNota == 0) ? "D" : "K"; //K
                        //D
                        l_noperk1 = AutoJournal.GetPerkiraanDKNPT_PLL(CompanyTo);
                        //K
                        l_noperk2 = AutoJournal.GetPerkiraanDKNCabang(_cabangKeID);
                     
                    }
                    else//0
                    {
                        l_dk2 = (_tipeNota == 0) ? "K" : "D"; //K
                        l_dk1 = (_tipeNota == 0) ? "D" : "K"; //D

                        l_noperk1 = AutoJournal.GetPerkiraanDKNCabang(_cabangKeID);
                        l_noperk2 = AutoJournal.GetPerkiraanDKNPT_HLL(CompanyTo);
                    }

                    foreach (DataRow dr in _dtDetail.Rows)
                    {
                        // if (_cabangDariID == l_cabangHO) l_noperk1 = dr["NoPerkiraan"].ToString();
                        l_uraian = dr["Uraian"].ToString();
                        l_nominalRp = double.Parse(Tools.isNull(dr["Nominal"], "0").ToString());
                        l_nominalOri = double.Parse(Tools.isNull(dr["NominalRp"], "0").ToString());
                        if (l_nominalRp == 0) l_nominalRp = l_nominalOri;
                        l_mataUangRowID = (Guid)Tools.isNull(dr["MataUangRowID"], Guid.Empty);

                        //--> case 1 : jika cabangdari = cabangHO, bikin detilnya di sini 
                        //                    if (_cabangDariID == l_cabangHO)
                        //                    {
                        jd = new clsJournalDetail(jh.RowID, l_noperk1, l_uraian, l_dk1, l_nominalRp,
                                                  l_mataUangRowID, l_nominalOri, _noBukti);
                        jh.AddDetail(jd);
                        //                    }
                        jd = new clsJournalDetail(jh.RowID, l_noperk2, l_uraian, l_dk2, l_nominalRp,
                                                  l_mataUangRowID, l_nominalOri, _noBukti);
                        jh.AddDetail(jd);

                        //l_totalRp = l_totalRp + l_nominalRp;
                        //l_totalOri = l_totalOri + l_nominalOri;
                    }
                }


                /*
                                // --> lha klu yang ini case 2 : klu cabangdari gak sama cabangHO, nambah detilnya di sini 
                                // \m/ --> klu di YM, nongol smiley-icon metalll !!!!!
                                if (_cabangDariID != l_cabangHO)
                                {
                                    l_noperk = AutoJournal.GetPerkiraanDKNCabang(_cabangDariID);
                                    jd = new clsJournalDetail(jh.RowID, l_noperk, "HI Cabang " + _cabangDariID, l_dk, l_totalRp, _mataUangRowID, l_totalOri, _noBukti);
                                    jh.AddDetail(jd);
                                }

                                // Insert Detail#2 di Header#1 : 
                                // Case : 1. PerusahaanDari = PerusahaanKe --> getPerkiraanDKNPTKe
                                //        2. getPerkiraanCabangKe
                                l_dk = (_tipeNota == 0) ? "D" : "K";
                                l_noperk = (_perusahaanDariRowID == _perusahaanKeRowID) ? AutoJournal.GetPerkiraanDKNCabang(_cabangKeID) : AutoJournal.GetPerkiraanDKNPT(_perusahaanKeRowID);
                                jd = new clsJournalDetail(jh.RowID, l_noperk, "Journal DKN", l_dk, l_totalRp, _mataUangRowID, l_totalOri, _noBukti);
                                jh.AddDetail(jd);
                */
                _j.Add(jh);

                #endregion

                #region Journal #2
                // Insert Header#2 (Jika Beda PT) :
                if ((_perusahaanDariRowID != _perusahaanKeRowID)  )
                {
                    if (CompanyTo == Guid.Empty)
                    {


                        jh = new clsJournal(_perusahaanKeRowID, _tanggal, _noBukti, "Journal DKN", "DKN",
                                            clsPerusahaan.DBGetInitGudang(_perusahaanKeRowID));

                        l_dk1 = (_tipeNota == 0) ? "K" : "D";
                        l_dk2 = (_tipeNota == 0) ? "D" : "K";

                        l_noperk1 = (_perusahaanKeRowID == _hts.RowID) ? AutoJournal.GetPerkiraanDKNHTS(_perusahaanDariRowID) : AutoJournal.GetPerkiraanDKNPT(_perusahaanDariRowID);
                        l_noperk2 = AutoJournal.GetPerkiraanDKNCabang(_cabangKeID);
                        l_cabangHO = clsPerusahaan.DBGetInitCabang(_perusahaanKeRowID);
                        // Insert Detail#1 di Header#2 : getPerkiraanDKNPTDari
                        //jd = new clsJournalDetail(jh.RowID, AutoJournal.GetPerkiraanDKNPT(_perusahaanDariRowID),
                        //                    "Journal DKN", ((_tipeNota == 0) ? "K" : "D"), l_totalRp, _mataUangRowID,
                        //                    l_totalOri, _noBukti);
                        //jh.AddDetail(jd);

                        // Insert Detail#2 di Header#2 : 
                        // case 1. cabangKe = cabangHOKe -> getPerkiraanDetail
                        //      2. getPerkiraanDKNCabangKe
                        //                    if (_cabangKeID == clsPerusahaan.DBGetInitCabang(_perusahaanKeRowID))
                        foreach (DataRow dr in _dtDetail.Rows)
                        {
                            if (_cabangKeID == l_cabangHO) l_noperk2 = dr["NoPerkiraan"].ToString();
                            l_uraian = dr["Uraian"].ToString();
                            l_nominalRp = double.Parse(Tools.isNull(dr["Nominal"], "0").ToString());
                            l_nominalOri = double.Parse(Tools.isNull(dr["NominalRp"], "0").ToString());
                            if (l_nominalRp == 0) l_nominalRp = l_nominalOri;
                            l_mataUangRowID = (Guid)Tools.isNull(dr["MataUangRowID"], Guid.Empty);

                            jd = new clsJournalDetail(jh.RowID, l_noperk1, l_uraian, l_dk1, l_nominalRp,
                                                      l_mataUangRowID, l_nominalOri, _noBukti);
                            jh.AddDetail(jd);

                            jd = new clsJournalDetail(jh.RowID, l_noperk2, l_uraian, l_dk2, l_nominalRp,
                                                      l_mataUangRowID, l_nominalOri, _noBukti);
                            jh.AddDetail(jd);
                        }
                        /*
                                            else
                                            {
                                                jd = new clsJournalDetail(jh.RowID, AutoJournal.GetPerkiraanDKNCabang(_cabangKeID),
                                                                    "Journal DKN", ((_tipeNota == 0) ? "D" : "K"), l_totalRp, _mataUangRowID,
                                                                    l_totalOri, _noBukti);
                                                jh.AddDetail(jd);
                                            }
                        */
                        _j.Add(jh);

                    }
                    else
                    {

                        
                        /*
                                            else
                                            {
                                                jd = new clsJournalDetail(jh.RowID, AutoJournal.GetPerkiraanDKNCabang(_cabangKeID),
                                                                    "Journal DKN", ((_tipeNota == 0) ? "D" : "K"), l_totalRp, _mataUangRowID,
                                                                    l_totalOri, _noBukti);
                                                jh.AddDetail(jd);
                                            }
                        */
                        _j.Add(jh);


                    }

                }
                #endregion
            }
            else
            {
                if (_errorNo == 5)
                {
                    _isPosted = true;
                    if (DKNChilds.Count > 0)
                    {
                        foreach (clsDKN d in DKNChilds)
                        {
                            jh = new clsJournal(d._journalRowID);
                            SetError(jh.ErrNo, jh.ErrMsg);
                            if (jh.ErrNo == 0)
                                if (_j.Find(delegate(clsJournal j) { return j.RowID == jh.RowID; }) == null) _j.Add(jh);
                                else break;
                        }
                    }
                    else
                    {
                        if ((Guid)Tools.isNull(_journalRowID, Guid.Empty) != Guid.Empty)
                        {
                            jh = new clsJournal(_journalRowID);
                            SetError(jh.ErrNo, jh.ErrMsg);
                            if (jh.ErrNo == 0) _j.Add(jh);
                        }
                    }
                }
            }
            return _j;
        }

        public void DSJournal(DataTemplates.dsJurnal dsj)
        {
            List<clsJournal> ljournal = GetGLJournal(enumJournalViewMode.Preview); //GetGLJournal_Group();
            if (ljournal.Count > 0) foreach (clsJournal j in ljournal) j.AddToDataSet(dsj);
        }

        #endregion

        #region DB Functions
        private int DBGetByRowID(Guid t_rowID)
        {
            SetError(0, "Ok");
            if ((t_rowID == null) || (t_rowID == Guid.Empty)) SetError(1, "ID DKN kosong");
            if (_errorNo == 0)
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, t_rowID));
                        DataTable dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            RowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
                            if (RowID != Guid.Empty)
                            {
                                _noBukti = Tools.isNull(dr["NoBukti"], "").ToString();
                                _groupRowID = (Guid)Tools.isNull(dr["GroupRowID"], Guid.Empty);
                                _isGroup = (_groupRowID == Guid.Empty);
                                _tanggal = (DateTime)Tools.isNull(dr["Tanggal"], DateTime.MinValue);
                                _tipeNota = (enumTipeNota)int.Parse(Tools.isNull(dr["TipeNota"], "0").ToString());
                                _perusahaanDariRowID = (Guid)Tools.isNull(dr["PerusahaanDariRowID"], Guid.Empty);
                                _perusahaanKeRowID = (Guid)Tools.isNull(dr["PerusahaanKeRowID"], Guid.Empty);
                                _cabangDariID = Tools.isNull(dr["CabangDariID"], "").ToString();
                                _cabangKeID = Tools.isNull(dr["CabangKeID"], "").ToString();
                                _gudangID = AutoJournal.GetGudangIDByPTRowID(_perusahaanDariRowID);
                                _lingkupNota = (_perusahaanDariRowID == _perusahaanKeRowID) ? enumLingkupNota.AntarCabang : enumLingkupNota.AntarPT;
                                //_noPerkiraan = DBGetNoPerkiraan();
                                _isPosted = (bool)Tools.isNull(dr["IsPosted"], false);
                                _journalRowID = (Guid)Tools.isNull(dr["JournalRowID"], Guid.Empty);
                                if (_journalRowID != Guid.Empty) _isPosted = true;
                                _mataUangRowID = (Guid)Tools.isNull(dr["MataUangRowID"], Guid.Empty);
                                //if (Kodomain)
                                //{
                                //    _journalRowID2 = (Guid)Tools.isNull(dr["JournalRowID2"], Guid.Empty);
                                //    _journalStatus = ((_journalRowID2 != Guid.Empty)) ? enumJournalStatus.SudahJournal : enumJournalStatus.BelumJournal;
                                //}
                                //else
                                //{
                                    _journalStatus = ((_isPosted) || (_journalRowID != Guid.Empty)) ? enumJournalStatus.SudahJournal : enumJournalStatus.BelumJournal;
                                //}

                                _src = Tools.isNull(dr["Src"], "").ToString();
                                BranchTo = Tools.isNull(dr["BranchTo"], "").ToString();
                                CompanyTo = (Guid)Tools.isNull(dr["CompanyTo"], Guid.Empty);

                            }
                        }

                        if (_groupRowID == Guid.Empty)
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_FILTER_Group"));
                            db.Commands[0].Parameters.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    Guid drowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
                                    if (drowID != Guid.Empty) DKNChilds.Add(new clsDKN(drowID, _noBukti));
                                }
                            }
                            _isGroup = (DKNChilds.Count > 0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    SetError(2, "(DBGetByRowID) \n" + ex.Message);
                }
            return _errorNo;
        }

        public static DataTable DBGetDKN(Guid t_rowID)
        {
            return DBTools.DBGetDataTableByRowID("usp_HubunganIstimewa_LIST", t_rowID);
        }

        public static DataTable DBGetByGroupRowID(Guid t_groupRowID)
        {
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, t_groupRowID));
            return DBTools.DBGetDataTable("usp_HubunganIstimewa_LIST_FILTER_Group", prm);
        }

        public static DataTable DBGetListByDate(DateTime? fromDate, DateTime? toDate, Guid perusahaanRowID)
        {
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));

            return DBTools.DBGetDataTable("usp_HubunganIstimewa_LIST_FILTER_Tanggal", prm);
        }

        public static DataTable DBGetListByDateUnion(DateTime? fromDate, DateTime? toDate, Guid perusahaanRowID)
        {
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
            prm.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));
            prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, perusahaanRowID));

            return DBTools.DBGetDataTable("[usp_HubunganIstimewa_LIST_FILTER_Tanggal_NEW]", prm);
        }

        private DataTable DBGetDetail(Guid t_rowID)
        {
            return clsDKNDetail.DBGetListByHeaderID(t_rowID);
        }

        public string DBPostJournal()
        {
            string result = "Ok";
            List<clsJournal> ljournal = GetGLJournal(enumJournalViewMode.Post);
            if (ljournal.Count > 0)
                using (Database db = new Database())
                {
                    db.BeginTransaction();
                    foreach (clsJournal j in ljournal)
                    {
                        if (result == "Ok")
                        {
                            if (j.DBPostJournal(db))
                            {
                                if (j.PerusahaanRowID == _perusahaanDariRowID)
                                    result = AutoJournal.UpdateJournalRowID(db, "usp_HubunganIstimewa_UPDATE_JournalRowID", _rowID, j.RowID);
                                //if (result != 0) SetError(result, "Update Journal ID di DKN : " + result);
                                foreach (clsDKN d in DKNChilds)
                                {
                                    if (d.PerusahaanDariRowID == j.PerusahaanRowID)
                                    {
                                        result = AutoJournal.UpdateJournalRowID(db,
                                                    "usp_HubunganIstimewa_UPDATE_JournalRowID", d.RowID, j.RowID);
                                        if (result != "Ok")
                                        {
                                            SetError(3, "Update Journal ID di DKN : \n" + result);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                result = "Gagal Posting";
                                SetError(1, "Gagal Posting");
                                break;
                            }
                        }
                    }
                    if (result == "Ok") db.CommitTransaction(); else db.RollbackTransaction();
                }
            return result;
        }

        #endregion
    }

    class clsDKNDetail
    {
        Error _err = new Error();
        Guid _rowID;
        Guid _headerRowID;
        bool _isPosted;

        #region PROPERTIES
        public Guid HeaderID { get { return _headerRowID; } set { _headerRowID = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsDKNDetail(Guid t_rowID)
        {
            DataTable dt = DBGetByRowID(t_rowID);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                DataRow dr = dt.Rows[0];
                _rowID = t_rowID;
                try
                {
                    _headerRowID = dr.Field<Guid>("HeaderID");
                }
                catch (Exception ex)
                {
                    _err.SetError(999, ex.Message);
                }
            }
        }
        #endregion


        #region Functions
        public void Delete()
        {
            DBDelete(_rowID);
        }

        public bool IsPosted()
        {
            bool result = false;
            if ((_isPosted == null) && (_headerRowID != null) && (_headerRowID != Guid.Empty))
            {
                clsDKN _dkn = new clsDKN(_headerRowID);
                if ((_dkn.State == clsDKN.enumState.Update) && (_dkn.IsPosted != null)) result = _dkn.IsPosted;
            }
            return result;
        }
        #endregion

        #region DBFunctions

        public static DataTable DBGetListByHeaderID(Guid t_rowID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, t_rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch //(Exception ex)
            {
                //string s = ex.Message;
                //_err.SetError(3, "(DBGetDetail) \n" + ex.Message);
            }
            return dt;
        }

        public static DataTable DBGetByRowID(Guid t_rowID)
        {
            return DBTools.DBGetDataTableByRowID("usp_HubunganIstimewaDetail_LIST", t_rowID);
        }

        public void DBDelete(Guid t_rowID)
        {
            DBTools.DBGetDataTableByRowID("usp_HubunganIstimewaDetail_DELETE", t_rowID);
        }
        #endregion
    }
}
