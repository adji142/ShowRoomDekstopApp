using System;

namespace ISA.Showroom.Class
{
    public abstract class clsBase
    {
        #region
        public enum enumClsState { Empty, New, Update }
        protected  enumClsState _clsState;
        Guid _rowID;
        string _lastUpdatedBy;
        DateTime _lastUpdatedTime;// = GlobalVar.GetServerDate;
        Error _err = new Error();
        #endregion

        #region PROPERTIES
        public enumClsState State { get { return _clsState; } }
        public Guid RowID { get { return _rowID; } set { _rowID = value; } }
        public string LastUpdatedBy { get { return _lastUpdatedBy; } set { _lastUpdatedBy = value; } }
        public DateTime LastUpdatedTime { get { return _lastUpdatedTime; } }
        public Error Error { get { return _err; } }
        #endregion

        #region FUNCTIONS
        protected void SetError(int no, string msg)
        {
            Error.SetError(no, msg);
        }
        #endregion
    }
}
