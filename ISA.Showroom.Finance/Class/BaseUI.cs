using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;
using System.Data;

namespace ISA.Showroom.Finance.Class
{
    public abstract class BaseUI
    {
        #region FIELDS
        static Guid _rowID;
//        static string _uID;
        static string _lastUpdatedBy;
        static DateTime _lastUpdatedTime;
        static string _dbID = null;
//        static List<string> _cmd_List;
        static string _usp_List;
        static string _usp_Insert;
        static string _usp_Update;
        static string _usp_Delete;
        #endregion

//        ComboBox cbo;


        #region PROPERTIES
        public string DBID
        {
            set { _dbID = value; }
        }

        public Guid RowID
        {
            get { return _rowID; }
            set { _rowID = value; }
        }

        public string uspList
        {
            get { return _usp_List; }
            set { _usp_List = value; }
        }

        public string uspInsert
        {
            get { return _usp_Insert; }
            set { _usp_Insert = value; }
        }

        public string uspUpdate
        {
            get { return _usp_Update; }
            set { _usp_Update = value; }
        }

        public string uspDelete
        {
            get { return _usp_Delete; }
            set { _usp_Delete = value; }
        }

        public string lastUpdatedBy
        {
            get { return _lastUpdatedBy; }
            set { _lastUpdatedBy = value; }
        }

        public DateTime lastUpdatedTime
        {
            get { return _lastUpdatedTime; }
            set { _lastUpdatedTime = value; }
        }
        #endregion


        #region KONSTRUKTOR

        public BaseUI()
        {
        }

        public BaseUI(Guid rowID)
        {
            _rowID = rowID;
        }
        #endregion


        #region UDF
        //public void Add_usp_List(string _usp)
        //{
        //    _cmd_List.Add(_usp);
        //}

        public void SQLAddData() { }
        public void SQLUpdateData() { }
        public void SQLDeleteData() { }
        public DataTable SQLGetData(Guid rowID)
        {
            DataTable dt = new DataTable();
            try
            {
                Database db = DBConnect();
                db.Commands.Add(db.CreateCommand(_usp_List));
                if ((rowID != Guid.Empty) && (rowID != null)) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return dt;
        }
        public void SQLGetData(string uid)
        {

        }

        public bool FindRowID()
        {
            bool retVal = false;
            DataTable dt = SQLGetData(_rowID);
            if (dt.Rows.Count > 0)
            {
            }
            return retVal;
        }

        private Database DBConnect()
        {
            Database db;
            if (string.IsNullOrEmpty(_dbID)) db = new Database(); else db = new Database(_dbID);
            return db;
        }

        #endregion
    }
}
