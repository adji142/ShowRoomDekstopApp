using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.IO;

namespace ISA.To.GLDOS
{
    class Lookup
    {
        static string _dbfUpload;
        static string _dbfDownload;
        static DateTime _DateOfServer = DateTime.MinValue;
        static string _DBPabrik = ISA.To.GLDOS.Properties.Settings.Default.sqlcon;
        static string _DBDOS = ISA.To.GLDOS.Properties.Settings.Default.dbfcon;
        static List<int> parameterkuncian = new List<int>();

        public static string DBPabrik
        {
            get
            {
                // return _SASFoxpro;
                return _DBPabrik;
            }
            set
            {
                _DBPabrik = value;
            }
        }

        public static string DBDOS
        {
            get
            {
                // return _SASFoxpro;
                return _DBDOS;
            }
            set
            {
                _DBDOS = value;
            }
        }

        public static string DbfUpload
        {
            get
            {
                return _dbfUpload;
            }
            set
            {
                _dbfUpload = value;
            }
        }

        public static string DbfDownload
        {
            get
            {
                return _dbfDownload;
            }
            set
            {
                _dbfDownload = value;
            }
        }

        public static DateTime DateOfServer
        {
            get { return _DateOfServer; }
        }

    }
}
