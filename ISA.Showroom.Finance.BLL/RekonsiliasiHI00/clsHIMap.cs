using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Showroom.Finance.BLL
{
    public class clsHIMap:clsData
    {
        #region FIELDS
        Guid _hi00RowID;
        Guid _hi11RowID;
        string _src11;
        #endregion

        #region PROPERTIES
        public Guid HI00RowID { get { return _hi00RowID; } set { _hi00RowID = value; } }
        public Guid HI11RowID { get { return _hi11RowID; } set { _hi11RowID = value; } }
        public string Src11 { get { return _src11; } set { _src11 = value; } }
        #endregion

        #region KONSTRUKTOR
        public clsHIMap()
        {
            RowID = new Guid();
        }

        public clsHIMap(Guid hi00, Guid hi11, string src11)
        {
            if ((hi00!=null) && (hi00!=Guid.Empty) && (hi11!=null) && (hi11!=Guid.Empty) && (!string.IsNullOrEmpty(src11))) {
                RowID = Guid.NewGuid();
                _hi00RowID = hi00;
                _hi11RowID = hi11;
                _src11 = src11;
            }
        }
        #endregion

        #region FUNCTIONS
        public void Save(string userId)
        {
            this.DBSave(userId);
        }
        #endregion

        #region DBFunctions
        void DBSave(string userId) {
            string s = "";
            try
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@HI00RowID", SqlDbType.UniqueIdentifier, _hi00RowID));
                prm.Add(new Parameter("@HI11RowID", SqlDbType.UniqueIdentifier, _hi11RowID));
                prm.Add(new Parameter("@Src11", SqlDbType.VarChar, _src11));
                prm.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, userId));

                Database db = new Database();
                db.Commands.Add(db.CreateCommand("usp_HIMap_INSERT"));
                db.Commands[0].Parameters = prm;
                db.Commands[0].ExecuteNonQuery();
                //object result = DBTools.DBGetScalar("usp_HIMap_INSERT", prm);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
        }
        #endregion

    }
}
