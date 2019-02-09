using System;
using System.Collections.Generic;
using System.Net;
using System.Data;
using ISA.DAL;
using ISA.Showroom.Finance.BLL.CommonObject;


namespace ISA.Showroom.Finance.BLL.UtilityManager 
{
    public  class SecurityManager 
    {
        public enum enAppRole { Manager, Admin, Operator, Auditor };
        public enum enBnsRole { Penjualan, Stock, Checker, Piutang, Accounting }
        public enum enState { LogIn, LogOut }

        #region FIELDS
        static string _clientIP = "";
        static enState _state = enState.LogOut;
        static int _timeOutCounter = 0;
        static UserObject _userObject;
        #endregion

        #region PROPERTIES
        public static UserObject UserObject { get { return _userObject; } set { _userObject = value; } }

        public static string ClientIP { get { return _clientIP; } }

        public static enState State { get { return _state; } }

        public static int TimeOutCounter { get { return _timeOutCounter; } }

        public static string ClientIPAddress { 
            get 
            { 
                if (_clientIP == "")
                {
                    //get IP Address
                    IPAddress[] localIPs = Dns.GetHostAddresses(System.Net.Dns.GetHostName());

                    foreach (IPAddress localIP in localIPs)
                    {
                        if (!IPAddress.IsLoopback(localIP) && !localIP.IsIPv6LinkLocal && !localIP.IsIPv6Multicast && !localIP.IsIPv6SiteLocal)
                        {
                            _clientIP = localIP.ToString();
                        }
                    }
                }
                return _clientIP;
            }
        }

        public static string ClientHostName
        {
            get
            {
                string host = string.Empty;
                host = Dns.GetHostName();
                return host;
            }
        }

        public static bool IsAuthenticate(string userID, string password, UserObject pUserObject) 
        {
            bool valid = false;

            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SecurityUsers_AUTHENTICATE"));
                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, password));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {

                pUserObject.UserID = userID;
                pUserObject.UserName = dt.Rows[0]["UserName"].ToString();
                pUserObject.UserInitial  = dt.Rows[0]["Initial"].ToString();
                pUserObject.TglPassword = DateTime.Parse(Tools.isNull(dt.Rows[0]["TglPassword"], DateTime.Today).ToString());
                pUserObject.Active = bool.Parse(dt.Rows[0]["Active"].ToString());
                pUserObject.CabangID =  Tools.isNull(dt.Rows[0]["CabangID"],"").ToString();

                if (pUserObject.Active)
                {
                    using (Database db = new Database())
                    {
                        //Get Parts
                        db.Commands.Add(db.CreateCommand("usp_vwSecurityPartsUsers_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        dt = db.Commands[0].ExecuteDataTable();
                        pUserObject.Parts = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            pUserObject.Parts.Add(dr["PartID"].ToString());
                        }

                        //Get Rights
                        db.Commands.Add(db.CreateCommand("usp_SecurityUsersRights_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        dt = db.Commands[1].ExecuteDataTable();
                        pUserObject.Rights = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            pUserObject.Rights.Add(dr["RightID"].ToString());
                        }

                        //Get App Roles
                        db.Commands.Add(db.CreateCommand("usp_SecurityRolesUsers_LIST"));
                        db.Commands[2].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        db.Commands[2].Parameters.Add(new Parameter("@roleType", SqlDbType.VarChar, "Application"));
                        dt = db.Commands[2].ExecuteDataTable();
                        pUserObject.AppRoles  = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            pUserObject.AppRoles.Add(dr["RoleID"].ToString());
                        }

                        //Get Biz Roles
                        db.Commands.Add(db.CreateCommand("usp_SecurityRolesUsers_LIST"));
                        db.Commands[3].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        db.Commands[3].Parameters.Add(new Parameter("@roleType", SqlDbType.VarChar, "Business"));
                        dt = db.Commands[3].ExecuteDataTable();
                        pUserObject.BizRoles = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            pUserObject.BizRoles.Add(dr["RoleID"].ToString());
                        }
                    }
                    valid = true;
                }
            }


            //get IP Address
            IPAddress[] localIPs = Dns.GetHostAddresses(System.Net.Dns.GetHostName());

            if (valid)
            {
                SecurityManager.ResetCounter();
                _state = enState.LogIn;
            }
            return valid;
        }

        public static bool IsLogin(string pUserID) 
        {
           
                bool Valid = false;
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_LoginUser_AUTHENTICATE]"));
                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, pUserID));
                        db.Commands[0].Parameters.Add(new Parameter("@HostName", SqlDbType.VarChar, SecurityManager.ClientHostName));
                        db.Commands[0].Parameters.Add(new Parameter("@IpAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                        Valid = Convert.ToBoolean(db.Commands[0].ExecuteScalar());
                        if (pUserID == "KAMORO")
                        {
                            Valid = false;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    UtilityManager.Error.LogError(ex, pUserID);
                    
                }
                return Valid;
            
        }

        public static string GetUserLogin(string pUserID)
        {
            string Msgg = string.Empty;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_LoginUser_List]"));

                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, pUserID));
                dt = db.Commands[0].ExecuteDataTable();

            }
            Msgg = "User : " + pUserID + "\tSudah login pada \nPC : " + dt.Rows[0]["HostName"].ToString() + "\t IP : " + dt.Rows[0]["IPAddress"].ToString();
            return Msgg;

        }

        public static void SetUserLogin(string UserID_, bool Status_)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_LoginUser_UPDATE]"));

                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, UserID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HostName", SqlDbType.VarChar, SecurityManager.ClientHostName));
                    db.Commands[0].Parameters.Add(new Parameter("@IpAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusLogin", SqlDbType.Bit, Status_));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex, UserID_);
            }
        }

        public static void AlwaysAuthenticate()
        {
            //_userID = "RAY";
            //_userInitial = "RAY";

            //SecurityManager.IsAuthenticate("RAY", EncodePassword("12345"));
            //SecurityManager.IsAuthenticate("WRT", EncodePassword("wirwir"));
            //IsAuthenticate("WRT", EncodePassword("wirwir"));
            //SecurityManager.RecordLoginHistory();

            //if (SecurityManager.IsPasswordExpired())
            //{
            //    frmChangePassword ifrmChild = new frmChangePassword(true);
            //    ifrmChild.Show();
            //}


            //_state = enState.LogIn;
        }

        public static bool IsAppRole(string role, UserObject pUserObject)
        {
            bool valid = false;
            if (pUserObject.AppRoles != null)
            {
                if (pUserObject.AppRoles.Contains(role))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool IsBizRole(string role, UserObject pUserObject)
        {
            bool valid = false;
            if (pUserObject.BizRoles != null)
            {
                if (pUserObject.BizRoles.Contains(role))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool IsPenjualan(UserObject pUserObject)
        {
            return IsBizRole("TRD.PENJUALAN", pUserObject);
        }

        public static bool IsAccounting(UserObject pUserObject)
        {
            return IsBizRole("TRD.ACC", pUserObject);
        }

        public static bool IsChecker(UserObject pUserObject)
        {
            return IsBizRole("TRD.CHECKER", pUserObject);
        }

        public static bool IsExpedisi(UserObject pUserObject)
        {
            return IsBizRole("TRD.EXPEDISI", pUserObject);
        }

        public static bool IsGudang(UserObject pUserObject)
        {
            return IsBizRole("TRD.GUDANG", pUserObject);
        }

        public static bool IsPiutang(UserObject pUserObject)
        {
            return IsBizRole("TRD.PIUTANG", pUserObject);
        }

        public static bool HasRight(string right,UserObject pUserObject)
        {
            bool valid = false;

            if (pUserObject.Rights != null)
            {
                if (pUserObject.Rights.Contains(right))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool HasPart(string part, UserObject pUserObject)
        {
            bool valid = false;
            if (pUserObject.Parts  != null)
            {
                if (pUserObject.Parts.Contains(part))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool IsManager( UserObject pUserObject)
        {
            return IsAppRole("TRD.MANAGER", pUserObject);
        }

        public static bool IsAdministrator( UserObject pUserObject)
        {
            return IsAppRole("TRD.ADMIN", pUserObject);
        }

        public static bool IsAOperator(UserObject pUserObject)
        {
            return IsAppRole("TRD.OPERATOR", pUserObject);
        }

        public static bool IsAuditor(UserObject pUserObject)
        {
            return IsAppRole("TRD.AUDITOR", pUserObject);
        }

        public static void ChangePassword(string newPassword, UserObject pUserObject)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SecurityUsers_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, pUserObject.UserID));
                db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, pUserObject.UserName));
                db.Commands[0].Parameters.Add(new Parameter("@initial", SqlDbType.VarChar, pUserObject.UserInitial));
                db.Commands[0].Parameters.Add(new Parameter("@Password", SqlDbType.VarChar, newPassword));
                db.Commands[0].Parameters.Add(new Parameter("@TglPassword", SqlDbType.DateTime, DateTime.Now));
                db.Commands[0].Parameters.Add(new Parameter("@Active", SqlDbType.VarChar, pUserObject.Active));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, pUserObject.UserID));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        public static void LogOut(UserObject pUserObject)
        {
            pUserObject.UserID = "";
            pUserObject.UserInitial = "";
            ClearCredential(pUserObject);
            _state = enState.LogOut;
        }

        public static void ResetCounter()
        {
            _timeOutCounter = 0;
        }

        public static void AddCounter()
        {
            _timeOutCounter++;
        }

        public static void ClearCredential(UserObject pUserObject)
        {
            pUserObject.Parts = null;
            pUserObject.Rights = null;
            pUserObject.BizRoles = null;
            pUserObject.AppRoles = null;
        }

        public static void DisableUser(string userID, UserObject pUserObject)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityUsers_ENABLED"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                    db.Commands[0].Parameters.Add(new Parameter("@active", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "SYSTEM"));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, pUserObject.UserID);
            }
        }

        public static string DecodePassword(string password)
        {
            string result = "";

            password = password.Trim();

            for (int i = 0; i < password.Length; i++)
            {
                int x = (int)password[i];

                result += char.ConvertFromUtf32((x / 2) - 5);
            }
            return result;
        }

        public static string EncodePassword(string password)
        {
            string result = "";

            password = password.Trim();

            for (int i = 0; i < password.Length; i++)
            {
                int x = (int)password[i];

                result += char.ConvertFromUtf32((x + 5) * 2);
            }
            return result;
        }

        public static void RecordLoginHistory(UserObject pUserObject)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityLoginHistory_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, pUserObject.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglLogin", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@ipAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, pUserObject.UserID);
            }
        }

        public static void RecordLoginAttempt(string userID)
        {
            try
            {
                //                int maxAttempt = int.Parse ( LookupInfo.GetValue("SECURITY", "MAX_LOGIN_ATTEMPT"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityLoginAttempt_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglLogin", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@ipAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, userID);
            }
        }

        public static void ClearLoginAttempt(string userID)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityLoginAttempt_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, userID);
            }
        }

        public static bool IsPasswordExpired(UserObject pUserObject)
        {
            bool expired = false;


            int maxAge = 0;
            //int.Parse(LookupInfo.GetValue("SECURITY", "PASSWORD_AGE"));
            if (maxAge > 0)
            {
                int datediff = DateTime.Now.Subtract(pUserObject.TglPassword).Days;

                if (datediff > maxAge)
                {
                    expired = true;
                }
            }

            return expired;
        }

        public static bool IsExist(string userID)
        {
            bool valid = false;

            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SecurityUsers_EXIST"));
                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }

            return valid;
        }

        public static string DatabaseID(string cabangID) {
            string result = "";
            string cabID = cabangID.Substring(0,2);
            if (!string.IsNullOrEmpty(cabangID)) 
            switch (cabID) { 
                case "11":result="ISAWebPalur";break;
                default:result="ISAWebCabang";break;
            }
            return result;
        }
        #endregion
    }
}
