using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Finance.HI
{
    class clsHI:Class.BaseUI
    {
        enum enumTipeNota { DebitNote, CreditNote }

        #region FIELDS
        private string _noBukti;
        private DateTime _tanggal;
/*
        private string _cabangDari;
        private string _cabangKe;
        private enumTipeNota _tipeNota;
        private string _kelompokTransaksi;
*/
        #endregion

        #region properties
        public string NoBukti
        {
            get { return _noBukti; }
            set { _noBukti = value; }
        }

        public DateTime Tanggal
        {
            get { return _tanggal; }
            set { _tanggal = (DateTime)value; }
        }

        #endregion

        #region Konstruktor
        public clsHI() 
        {
            Initialize();
        } 

        public clsHI(Guid rowID)
        {
            Initialize();
            this.RowID = rowID;
            this.SQLGetData(this.RowID);
        }
        #endregion

        public void Initialize() {
            this.uspList = "usp_HubunganIstimewa_LIST";
            this.uspInsert = "usp_HubunganIstimewa_INSERT";
            this.uspUpdate = "usp_HubunganIstimewa_UPDATE";
            this.uspDelete = "usp_HubunganIstimewa_DELETE";
        }

        #region Methodes

        #endregion
    }
}
