using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Finance.Class
{
    class clsHistoryGiro
    {
        #region FIELDS
        public enum enumArahGiro { Keluar, Masuk }
        protected Guid _rowID;
        protected enumArahGiro _arahGiro;
        protected string _noGiro;
        //protected int _statusGiro;
        #endregion

        #region PROPERTIES
        public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public enumArahGiro ArahGiro { get { return _arahGiro; } set { _arahGiro = value; } }
        public string NoGiro { get { return _noGiro; } set { _noGiro = value; } }
        #endregion

        #region DBFunctions

        #endregion

    }

    class clsHistoryGiroMasuk : clsHistoryGiro
    {
        #region
        public enum enumStatusGiroMasuk { Diterima, Disetor, BatalSetor, Cair, BatalCair, Ditolak, Batal }
        #endregion

        private void d()
        {
        }
    }

    class clsHistoryGiroKeluar : clsHistoryGiro
    {
    }
}
