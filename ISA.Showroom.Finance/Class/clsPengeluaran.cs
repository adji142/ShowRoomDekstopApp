using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ISA.DAL;

namespace ISA.Showroom.Finance.Class
{
    class clsPengeluaran
    {
        #region Fields
        public enum enumState { Empty, New, Update }
        public enum enumJournalTipe { Pengeluaran, DKN, ProsesGiro }
        public enum enumJournalStatus { NonJournal, BelumJournal, SudahJournal }
        public enum enumPengeluaranKe { Cabang, Vendor, Perusahaan } 
        private enumState _state = enumState.Empty;
        private Guid _rowID;
        private Guid _perusahaanDariRowID;
        private Guid _perusahaanKeRowID;
        private Guid _journalRowID;
        private Guid _mataUangRowID;
        //        private Guid _jnsTransaksiRowID;
        private string _noBukti;
        private string _cabangDariID;
        private string _cabangKeID;
        private string _cabangOriID;
        private string _gudangID;
        private DateTime _tanggal;
        private DateTime _dueDateGiro;
        private double _nominal;
        private double _nominalRp;
        private string _noPerkiraan01;
        private string _noPerkiraan02;
        private string _noPerkiraan03;
        private string _noPerkiraan04;
        private string _jnsPengeluaran;
        private int _pengeluaranKe;
        private string _uraian;
        public Guid _kasRowID;
        public Guid _rekeningRowID;
        private Guid _jnsTransaksi;
        private string _unitusaha;
        private GlobalVar.enumStatusApproval _statusApproval;
        //        private enumJournalTipe _journalTipe;
        //        private enumJournalStatus _journalStatus;
        private bool _journal2;
        public DataRow _dr;
        #endregion

        #region Properties
        public enumState State { get { return _state; } }
        public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public Guid PerusahaanDariRowID { get { return _perusahaanDariRowID; } set { _perusahaanDariRowID = value; } }
        public Guid PerusahaanKeRowID { get { return _perusahaanKeRowID; } set { _perusahaanKeRowID = value; } }
        public string NoBukti { get { return _noBukti; } set { _noBukti = value; } }
        public string CabangDariID { get { return _cabangDariID; } set { _cabangDariID = value; } }
        public string CabangKeID { get { return _cabangKeID; } set { _cabangKeID = value; } }
        public string CabangOriID { get { return _cabangOriID; } set { _cabangOriID = value; } }
        public string GudangID { get { return _gudangID; } }
        public double Nominal { get { return _nominal; } set { _nominal = value; } }
        public Guid MataUangRowID { get { return _mataUangRowID; } set { _mataUangRowID = value; } }
        public double NominalRp { get { return _nominalRp; } set { _nominalRp = value; } }
        public string NoPerkiraan01 { get { return _noPerkiraan01; } }
        public string NoPerkiraan02 { get { return _noPerkiraan02; } }
        public string NoPerkiraan03 { get { return _noPerkiraan03; } }
        public string NoPerkiraan04 { get { return _noPerkiraan04; } }
        public string JnsPengeluaran { get { return _jnsPengeluaran; } set { _jnsPengeluaran = value; } }
        public string Uraian { get { return _uraian; } set { _uraian = value; } }
        public string UnitUsaha { get { return _unitusaha; } set { _unitusaha = value; } }
        public GlobalVar.enumStatusApproval StatusApproval { get { return _statusApproval; } set { _statusApproval = value; } }
        public DateTime Tanggal { get { return _tanggal; } set { _tanggal = value; } }
        public DateTime DueDateGiro { get { return _dueDateGiro; } set { _dueDateGiro = value; } }
        public bool Journal2 { get { return _journal2; } }
        public Guid JournalRowID { get { return _journalRowID; } }
        public int PengeluaranKe { get { return _pengeluaranKe; } }
        #endregion

        #region Konstruktor
        public clsPengeluaran(Guid t_rowID)
        {
            DBGetByRowID(t_rowID);
        }
        #endregion

        #region DB Functions
        private int DBGetByRowID(Guid t_rowID)
        {
            int nresult = 0;
            if ((t_rowID == null) || (t_rowID == Guid.Empty)) nresult = 1;
            else
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, t_rowID));
                        DataTable dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            _dr = dr;
                            _rowID = t_rowID;
                            _perusahaanDariRowID = (Guid)dr["PerusahaanDariRowID"];
                            _perusahaanKeRowID = (Convert.IsDBNull(dr["PerusahaanKeRowID"]) ? Guid.Empty : (Guid)dr["PerusahaanKeRowID"]);
                            _noBukti = dr["NoBukti"].ToString();
                            _tanggal = (Convert.IsDBNull(dr["Tanggal"])) ? DateTime.MinValue : (DateTime)dr["Tanggal"];
                            _dueDateGiro = (Convert.IsDBNull(dr["DueDateGiro"])) ? DateTime.MinValue : (DateTime)dr["DueDateGiro"];
                            _cabangDariID = dr["CabangDariID"].ToString();
                            _cabangKeID = (Convert.IsDBNull(dr["CabangkeID"]) ? "" : dr["CabangKeID"].ToString());
                            _cabangOriID = (Convert.IsDBNull(dr["CabangIDOri"]) ? _cabangKeID : dr["CabangIDOri"].ToString());
                            _gudangID = AutoJournal.GetGudangIDByPTRowID(_perusahaanDariRowID);
                            _uraian = (Convert.IsDBNull(dr["Uraian"]) ? "" : dr["Uraian"].ToString());
                            _jnsPengeluaran = dr["JnsPengeluaran"].ToString();
                            //                            _jnsTransaksiRowID = dr["JnsTransaksiRowID"];
                            _pengeluaranKe = Convert.IsDBNull(dr["PengeluaranKe"]) ? 0 : int.Parse(dr["PengeluaranKe"].ToString());
                            _noPerkiraan01 = dr["NoPerkiraan01"].ToString();
                            _nominal = (Convert.IsDBNull(dr["Nominal"])) ? 0 : double.Parse(dr["Nominal"].ToString());
                            _nominalRp = (Convert.IsDBNull(dr["NominalRp"])) ? _nominal : double.Parse(dr["NominalRp"].ToString());
                            if (_nominalRp == 0) _nominalRp = _nominal;
                            _statusApproval = (GlobalVar.enumStatusApproval)dr.Field<byte>("StatusApproval");
                            _kasRowID = (Guid)Tools.isNull(dr["KasRowID"], Guid.Empty);
                            _rekeningRowID = (Guid)Tools.isNull(dr["RekeningRowID"], Guid.Empty);
                            _journalRowID = (Guid)Tools.isNull(dr["JournalRowID"], Guid.Empty);
                            _mataUangRowID = (Guid)Tools.isNull(dr["MataUangRowID"], Guid.Empty);
                            _jnsTransaksi = (Guid)Tools.isNull(dr["JnsTransaksiRowID"], Guid.Empty);
                            _unitusaha = dr["UnitUsaha"].ToString();
                            if ((_perusahaanKeRowID == Guid.Empty) || (_cabangKeID != _cabangOriID)) GetPerusahaanKeRowID();
                            SetNoPerkiraan01();
                            SetNoPerkiraan02();
                            if ((_perusahaanKeRowID != null) && (_perusahaanKeRowID != Guid.Empty) && (_perusahaanKeRowID != _perusahaanDariRowID))
                            {
                                SetNoPerkiraan03();
                                SetNoPerkiraan04();
                              
                                if(!GlobalVar.IsNewDNKN && (_jnsTransaksi != GlobalVar.GetTransaksi.PLL || _jnsTransaksi != GlobalVar.GetTransaksi.HLL) )
                                _journal2 = true;
                            }
                            else _journal2 = false;
                            _state = enumState.Update;
                        }
                        else nresult = 2;
                    }
                }
                catch (Exception ex)
                {
                    nresult = 3;
                    string s = ex.Message;
                }
            }
            if (nresult != 0) Kosongkan();
            return nresult;
        }

        private void SetNoPerkiraan01()
        {
            switch (_pengeluaranKe)
            {
                case 0:
                    _noPerkiraan01 = AutoJournal.GetPerkiraanDKNCabang(_cabangKeID);
                    break;
                case 1: break;
                case 2:
                    if (_perusahaanDariRowID != _perusahaanKeRowID)
                    {
                        if (!GlobalVar.IsNewDNKN)
                        {
                            _noPerkiraan01 = AutoJournal.GetPerkiraanDKNPT(_perusahaanDariRowID, _perusahaanKeRowID);
                        }
                        else
                        {
                            if (_jnsTransaksi == GlobalVar.GetTransaksi.HLL)
                            {
                                _noPerkiraan01 = AutoJournal.GetPerkiraanDKNPT_HLL(_perusahaanKeRowID); 
                            }
                            else if (_jnsTransaksi == GlobalVar.GetTransaksi.PLL)
                            {
                                _noPerkiraan01 = AutoJournal.GetPerkiraanDKNPT_PLL(_perusahaanKeRowID); 
                            }
                            else
                            {
                                _noPerkiraan01 = AutoJournal.GetPerkiraanNewDKNPT(_perusahaanDariRowID, _perusahaanKeRowID);
                            }

                        }
                        
                    
                    }

                    break;
                default: break;
            }
        }

        private void SetNoPerkiraan02()
        {
            switch (_jnsPengeluaran)
            {
                case "K":
                    {
                        _noPerkiraan02 = AutoJournal.GetPerkiraanKas(_kasRowID);
                    } break;
                case "B":
                    {
                        _noPerkiraan02 = AutoJournal.GetPerkiraanRekening(_rekeningRowID);
                    } break;
                case "G":
                    goto case "B";
                    //{
                    //    //_noPerkiraan02 = AutoJournal.GetPerkiraanKoneksiDetail("HUTBG");
                    //} break;
            }
        }

        private void GetPerusahaanKeRowID()
        {
            if (string.IsNullOrEmpty(_cabangOriID) || (_cabangOriID == _cabangKeID))
            {
                _perusahaanKeRowID = _perusahaanDariRowID;
            }
            else
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangOriID));
                DataTable dt = Tools.DBGetDataTable("usp_Cabang_LIST", prm);
                if (dt.Rows.Count > 0) _perusahaanKeRowID = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanRowID"], Guid.Empty);
            }
        }

        private void SetNoPerkiraan03()
        {
            _noPerkiraan03 = "";
            if (!string.IsNullOrEmpty(_cabangOriID) && (_cabangOriID != _cabangKeID))
            {
                // beda cabang lintas pt
                _noPerkiraan03 = AutoJournal.GetPerkiraanDKNCabang(_cabangOriID);
            }
            else if ((_perusahaanKeRowID != null) && (_perusahaanKeRowID != Guid.Empty) && (_perusahaanDariRowID != _perusahaanKeRowID))
            {
                // antar PT
                // klu trx pengeluaran cuma 1 record, musti dicari cabang HO penerima    
                if (!GlobalVar.IsNewDNKN)//
                {
                    if (string.IsNullOrEmpty(_cabangOriID) || (_cabangKeID == _cabangOriID))
                    {
                        // klu trx pengeluaran cuma 1 record, gak perlu nyari trx penerimaan-nya ...
                        List<Parameter> prm = new List<Parameter>();
                        prm.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, _rowID));
                        DataTable dt = Tools.DBGetDataTable("usp_PenerimaanUang_LIST_FILTER_Group", prm);
                        if (dt.Rows.Count > 0)
                        {
                            string _jnsPenerimaan = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();
                            switch (_jnsPenerimaan)
                            {
                                case "K":
                                    {
                                        Guid _kasTrmRowID = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                                        _noPerkiraan03 = AutoJournal.GetPerkiraanKas(_kasTrmRowID);
                                    } break;
                                case "B":
                                    {
                                        Guid _rekRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                                        _noPerkiraan03 = AutoJournal.GetPerkiraanRekening(_rekRowID);
                                    } break;
                                default: break;
                            }
                        }

                    }
                    else _noPerkiraan03 = AutoJournal.GetPerkiraanDKNPT(_perusahaanKeRowID, _perusahaanDariRowID);
                }
                else // DKN baru
                {
                    if (string.IsNullOrEmpty(_cabangOriID) || (_cabangKeID == _cabangOriID))
                    {
                        // klu trx pengeluaran cuma 1 record, gak perlu nyari trx penerimaan-nya ...
                        List<Parameter> prm = new List<Parameter>();
                        prm.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, _rowID));
                        DataTable dt = Tools.DBGetDataTable("usp_PenerimaanUang_LIST_FILTER_Group", prm);
                        if (dt.Rows.Count > 0)
                        {
                            string _jnsPenerimaan = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();
                            switch (_jnsPenerimaan)
                            {
                                case "K":
                                    {
                                        Guid _kasTrmRowID = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                                        _noPerkiraan03 = AutoJournal.GetPerkiraanKas(_kasTrmRowID);
                                    } break;
                                case "B":
                                    {
                                        Guid _rekRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                                        _noPerkiraan03 = AutoJournal.GetPerkiraanRekening(_rekRowID);
                                    } break;
                                default: break;
                            }
                        }

                    }
                    else _noPerkiraan03 = 
                        _jnsTransaksi.Equals(GlobalVar.GetTransaksi.HLL) ? AutoJournal.GetPerkiraanDKNPT_HLL(_perusahaanDariRowID) : 
                        AutoJournal.GetPerkiraanNewDKNPT(_perusahaanKeRowID, _perusahaanDariRowID);
                }
             
            }
        }

        private void SetNoPerkiraan04()
        {
            _noPerkiraan04 = "";
            if ((_perusahaanKeRowID != null) && (_perusahaanKeRowID != Guid.Empty) && (_perusahaanDariRowID != _perusahaanKeRowID))
            {
                if (!GlobalVar.IsNewDNKN)
                {
                    // antar PT
                    _noPerkiraan04 = AutoJournal.GetPerkiraanDKNPT(_perusahaanKeRowID, _perusahaanDariRowID);
                }
                else
                {
                    _noPerkiraan04 = _jnsTransaksi.Equals(GlobalVar.GetTransaksi.HLL) ? AutoJournal.GetPerkiraanDKNPT_HLL(_perusahaanDariRowID) :
                        AutoJournal.GetPerkiraanNewDKNPT(_perusahaanKeRowID, _perusahaanDariRowID);
                }
            }
        }

        private void Kosongkan()
        {
            _rowID = Guid.Empty;
            _noBukti = "";

            _nominal = 0;
            _nominalRp = 0;
            _state = enumState.Empty;
        }
        #endregion
    }


}
