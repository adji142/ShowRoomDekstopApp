using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.Showroom.Finance.BLL;

namespace ISA.Showroom.Finance.Class.HI00
{
    class clsHI00 : clsData
    {
        #region FIELDS
        DateTime? _tanggal;
        clsPerusahaan _perusahaanDari = new clsPerusahaan();
        clsPerusahaan _perusahaanKe = new clsPerusahaan();
        #endregion

        #region PROPERTIES
        public DateTime? Tanggal { get { return _tanggal; } set { value = _tanggal; } }
        public clsPerusahaan PerusahaanDari { get { return _perusahaanDari; } set { value = _perusahaanDari; } }
        public clsPerusahaan PerusahaanKe { get { return _perusahaanKe; } set { value = _perusahaanKe; } }
        #endregion

        #region FUNCTIONS
        public void setPerusahaanDariRowID(Guid t_rowid) {
            bool retVal = ((t_rowid!=null)&&(t_rowid!=Guid.Empty));
            if (retVal)_perusahaanDari = new clsPerusahaan(t_rowid);
        }

        public void setPerusahaanKeRowID(Guid t_RowID)
        {
            bool retVal = ((t_RowID != null) && (t_RowID != Guid.Empty));
            if (retVal) _perusahaanKe = new clsPerusahaan(t_RowID);
        }
        #endregion 

        #region DBFunctions
        #endregion  
    }
}
