using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Finance.Class
{
    public abstract class clsData
    {
        #region FIELDS
        Guid _rowID;
        DateTime _lastUpdatedTime;
        #endregion 
 
        #region PROPERTIES
        public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public DateTime LastUpdatedTime { get { return _lastUpdatedTime; } set { _lastUpdatedTime = value; } }
        #endregion
    }
}
