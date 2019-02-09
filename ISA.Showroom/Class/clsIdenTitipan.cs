using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Class
{
    class clsIdenTitipan
    {
        private System.Guid _PenerimaanTitipanRowID;
        private System.Guid _PenjualanHistRowID;
        private double _NominalIden;

        public System.Guid PenerimaanTitipanRowID
        {
            get
            {
                return _PenerimaanTitipanRowID;
            }
            set
            {
                _PenerimaanTitipanRowID = value; 
            }
        }


        public System.Guid PenjualanHistRowID
        {
            get
            {
                return _PenjualanHistRowID;
            }
            set
            {
                _PenjualanHistRowID = value;
            }
        }

        public double NominalIden
        {
            get
            {
                return NominalIden;
            }
            set
            {
                _NominalIden = value;
            }
        }

    }
}
