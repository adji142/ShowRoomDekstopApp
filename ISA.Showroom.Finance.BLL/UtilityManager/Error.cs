﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;


namespace ISA.Showroom.Finance.BLL.UtilityManager
{
    class Error
    {
        public int No = 0;
        public string Message = "";

        public void SetError(int no, string message)
        {
            No = no;
            Message = message;
        }

        public static string LogError(Exception ex, string userID)
        {
            string errorID;
            DateTime errorDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            using (Database db = new Database())
            {
                db.Open();

                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_ErrorLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@tglError", SqlDbType.DateTime, errorDate));
                db.Commands[0].Parameters.Add(new Parameter("@source", SqlDbType.VarChar, ex.Source != null ? ex.Source : ""));
                db.Commands[0].Parameters.Add(new Parameter("@message", SqlDbType.VarChar, ex.Message != null ? ex.Message : ""));
                db.Commands[0].Parameters.Add(new Parameter("@stackTrace", SqlDbType.VarChar, ex.StackTrace != null ? ex.StackTrace : ""));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, userID));
                errorID = db.Commands[0].ExecuteScalar().ToString();

                db.Close();
                db.Dispose();
            }
            return (String.Format("Error ID : {0}\nError ini telah di-log kedalam system. Pesan error adalah sebagai berikut:\n{1} ", errorID, ex.Message));
        }

        public static string  LogError(Exception ex, string message, string userID) 
        {
            string errorID;
            DateTime errorDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            using (Database db = new Database())
            {
                db.Open();

                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_ErrorLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@tglError", SqlDbType.DateTime, errorDate));
                db.Commands[0].Parameters.Add(new Parameter("@source", SqlDbType.VarChar, ex.Source));
                db.Commands[0].Parameters.Add(new Parameter("@message", SqlDbType.VarChar, ex.Message));
                db.Commands[0].Parameters.Add(new Parameter("@stackTrace", SqlDbType.VarChar, ex.StackTrace));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, userID));
                errorID = db.Commands[0].ExecuteScalar().ToString();

                db.Close();
                db.Dispose();
            }
            return message;
        }
    }
}
