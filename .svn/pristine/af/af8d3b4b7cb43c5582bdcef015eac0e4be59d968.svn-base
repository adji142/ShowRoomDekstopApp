using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;

namespace ISA.Showroom.Finance.BLL
{
    public class Tools
    {
        public static object isNull(object value, object nullValue)
        {
            if (value == null)
            {
                return nullValue;
            }
            else
            {
                if (value.ToString().Trim() == "")
                    return nullValue;
                else
                    return value;
            }
        }

        public static DateTime? GetServerDate()
        {
            return DBTools.DBGetServerDate();
        }
    }
}