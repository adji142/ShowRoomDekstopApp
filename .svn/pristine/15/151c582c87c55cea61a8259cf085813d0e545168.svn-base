using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom
{
    public class Error 
    {
        public int No;
        public string Message;

        public void SetError(int errNo, string errMsg)
        {
            No = errNo;
            Message = errMsg;
        }

        public static void LogError(Exception ex)
        {
            string errorID;
            DateTime errorDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, GlobalVar.GetServerDate.Day);
            using (Database db = new Database())
            {
                db.Open();

                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_ErrorLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@tglError", SqlDbType.DateTime, errorDate));
                db.Commands[0].Parameters.Add(new Parameter("@source", SqlDbType.VarChar, ex.Source !=null? ex.Source:""));
                db.Commands[0].Parameters.Add(new Parameter("@message", SqlDbType.VarChar, ex.Message !=null? ex.Message:"" ));
                db.Commands[0].Parameters.Add(new Parameter("@stackTrace", SqlDbType.VarChar, ex.StackTrace!=null? ex.StackTrace:""));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID  ));
                errorID = db.Commands[0].ExecuteScalar().ToString();

                db.Close();
                db.Dispose();
            }
            MessageBox.Show(String.Format("Error ID : {0}\nError ini telah di-log kedalam system. Pesan error adalah sebagai berikut:\n{1} " , errorID , ex.Message));
        }

        public static void LogError(Exception ex, string message)
        {
            string errorID;
            DateTime errorDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, GlobalVar.GetServerDate.Day);
            using (Database db = new Database())
            {
                db.Open();

                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_ErrorLog_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@tglError", SqlDbType.DateTime, errorDate));
                db.Commands[0].Parameters.Add(new Parameter("@source", SqlDbType.VarChar, ex.Source));
                db.Commands[0].Parameters.Add(new Parameter("@message", SqlDbType.VarChar, ex.Message));
                db.Commands[0].Parameters.Add(new Parameter("@stackTrace", SqlDbType.VarChar, ex.StackTrace));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                errorID = db.Commands[0].ExecuteScalar().ToString();

                db.Close();
                db.Dispose();
            }
            MessageBox.Show(message + Environment.NewLine + ex.Message.ToString() );
        }

        public static void SetError(Control ctrl, string message)
        {
            ErrorProvider err = new ErrorProvider();
            err.SetError(ctrl, message);

        }
    }
}
