using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Finance.Class
{
    class PinId
    {
        public struct Bagian
        {
            public const int Stok = 1;
            public const int Penjualan = 2;
            public const int Direksi = 3;
            public const int Keuangan = 4;
            public const int Piutang = 5;
            public const int Accounting = 6;
        }

        public struct ModulId
        {
            public const string KasOpnamePrevDay = "01";
            public const string PelunasanBBN = "02";
            public const string PiutangKaryawan = "03";
        }

        public struct Periode
        {
            public const int Hari = 0;
            public const int Minggu = 1;
            public const int Bulan = 2;
            public const int Tahun = 2;
        }
    }
}
