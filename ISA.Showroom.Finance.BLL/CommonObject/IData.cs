using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Finance.BLL
{
    interface IData
    {
        void ValidatingData();
        void DBGetByRowID(Guid t_rowID);
        void DBAddData();
        void DBUpdateData();
    }
}
