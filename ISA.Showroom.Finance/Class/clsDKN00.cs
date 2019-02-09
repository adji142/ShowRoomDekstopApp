using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ISA.Showroom.Finance.Class
{
    class clsDKN00
    {
        #region FIELDS
        public enum enumState { Empty, New, Update }
        enumState _state;
        string _idhead;
        string _iddetail;
        DateTime _tanggal;
        string _no_dkn;
        string _dk;
        string _cabang;
        string _cd;
        string _src;
        string _no_perk;
        string _uraian;
        double _jumlah;
        string _dari;
        bool _ltolak;
        string _alasan;
        #endregion

        #region KONSTRUKTOR
        public clsDKN00()
        {
            _tanggal = GlobalVar.GetServerDate;
            _iddetail = Tools.CreateFingerPrint();
            _dk = "D";
            _state = enumState.New;
        }

        public clsDKN00(DataRow dr)
        {
            GetFromDataRow(dr);
            _state = enumState.Update;
        }
        #endregion

        #region PROPERTIES
        public string idhead { get { return _idhead; } set { _idhead = value; } }
        public string iddetail { get { return _iddetail; } set { _iddetail = value; } }
        public DateTime tanggal { get { return _tanggal; } set { _tanggal = value; } }
        public string no_dkn { get { return _no_dkn; } set { _no_dkn = value; } }
        public string dk { get { return _dk; } set { _dk = value; } }
        public string cabang { get { return _cabang; } set { _cabang = value; } }
        public string cd { get { return _cd; } set { _cd = value; } }
        public string src { get { return _src; } set { _src = value; } }
        public string no_perk { get { return _no_perk; } set { _no_perk = value; } }
        public string uraian { get { return _uraian; } set { _uraian = value; } }
        public double jumlah { get { return _jumlah; } set { _jumlah = value; } }
        public string dari { get { return _dari; } set { _dari = value; } }
        public bool ltolak { get { return _ltolak; } set { _ltolak = value; } }
        public string alasan { get { return _alasan; } set { _alasan = value; } }
        public enumState state { get { return _state; } }
        #endregion

        #region FUNCTIONS
        object isNull(object value, object nullValue)
        {
            if (value == null)
            {
                return nullValue;
            }
            else
            {
                if (value.ToString().Trim() == "")
                    return nullValue;
                else
                    return value;
            }
        }

        public static DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("tanggal", typeof(DateTime));
            dt.Columns.Add("no_dkn", typeof(string));
            dt.Columns.Add("dk", typeof(string));
            dt.Columns.Add("cabang",typeof(string));
            dt.Columns.Add("idhead",typeof(string));
            dt.Columns.Add("cd",typeof(string));
            dt.Columns.Add("src",typeof(string));
            dt.Columns.Add("iddetail",typeof(string));
            dt.Columns.Add("no_perk",typeof(string));
            dt.Columns.Add("uraian", typeof(string));
            dt.Columns.Add("jumlah",typeof(double));
            dt.Columns.Add("dari",typeof(string));
            dt.Columns.Add("ltolak",typeof(bool));
            dt.Columns.Add("alasan",typeof(string));
            dt.Columns.Add("cUploaded", typeof(bool));
            return dt;
        }

        public void GetFromDataRow(DataRow dr)
        {
            try
            {
                _tanggal = (DateTime)isNull(dr["tanggal"], DateTime.MinValue);
                _no_dkn = isNull(dr["no_dkn"],"").ToString();
                _dk = isNull(dr["dk"],"").ToString() ;
                _cabang = isNull(dr["cabang"],"").ToString();
                _idhead = isNull(dr["idhead"],"").ToString() ;
                _cd = isNull(dr["cd"],"").ToString();
                _src = isNull(dr["src"],"").ToString();
                _iddetail = isNull(dr["iddetail"],"").ToString();
                _no_perk = isNull(dr["no_perk"],"").ToString() ;
                _uraian = isNull(dr["uraian"],"").ToString();
                double.TryParse(dr["jumlah"].ToString(), out _jumlah);
                _dari = dr["dari"].ToString();
                _ltolak = (bool)isNull(dr["ltolak"],false); // Tools.isNull(_ltolak, false);
                _alasan = isNull(dr["alasan"],"").ToString();
            }
            catch { 
                
            }
        }

        public void AddToDataRow(DataRow dr)
        {
            try
            {
                dr["tanggal"] = _tanggal;
                dr["no_dkn"] = _no_dkn;
                dr["dk"] = _dk;
                dr["cabang"] = _cabang;
                dr["idhead"] = _idhead;
                dr["cd"] = _cd;
                dr["src"] = _src;
                dr["iddetail"] = _iddetail;
                dr["no_perk"] = _no_perk;
                dr["uraian"] = _uraian;
                dr["jumlah"] = _jumlah;
                dr["dari"] = _dari;
                dr["ltolak"] = _ltolak; // Tools.isNull(_ltolak, false);
                dr["alasan"] = _alasan;
            }
            catch { }
        }

        public void AddToDataTable(DataTable dt)
        {
            DataRow dr = dt.Rows.Add();
            AddToDataRow(dr);
        }
        #endregion
    }

    class clsDKN00Header
    {
        #region FIELDS
        //string _idhead;
        //string _no_dkn;
        //DateTime _tanggal;
        //string _dari;
        //string _dk;
        #endregion


    }
}
