using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel; 
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;


namespace ISA.Showroom.Finance.BLL
{
    public abstract class clsData
    {
        Guid _rowID;
        protected Enums.enumClsState _state;
        string _lastUpdatedBy;
        DateTime _lastUpdatedTime;
        protected string _dbID;
        clsError _error;

        public clsData() {
            _state = Enums.enumClsState.New;
            _error = new clsError();
            ResetError();
        }

        

        public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public string LastUpdatedBy { get { return _lastUpdatedBy; } set { _lastUpdatedBy = value; } }
        public DateTime LastUpdatedTime { get { return _lastUpdatedTime; } set { _lastUpdatedTime = value; } }
        public Enums.enumClsState State { get { return _state; } set { _state = value; } }
        public int ErrorNo { get { return _error.Nomor; } }
        public string ErrorMsg { get { return _error.Pesan; } }

        //public event PropertyChangedEventHandler PropertyChanged;

        public void ResetError() { _error.ResetError(); }
        public void SetError(int No, string msg) { _error.SetError(No, msg); }
    }



    public class clsError
    {
        int _nomor;
        string _pesan;

        public int Nomor { get { return _nomor; } set { _nomor = value; } }
        public string Pesan { get { return _pesan; } set { _pesan = Pesan; } }

        public clsError()
        {
            ResetError();
        }

        public void SetError(int t_nomor, string t_pesan) { 
            _nomor=t_nomor;
            _pesan = t_pesan;
        }

        public void ResetError()
        {
            _nomor = 0;
            _pesan = "";
        }
    }
}
