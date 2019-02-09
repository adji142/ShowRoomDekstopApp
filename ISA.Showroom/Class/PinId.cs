using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Class
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
            public const string FakturPembelian = "01";
            public const string KwitansiPembelian = "02";
            public const string BeritaAcaraPembelian = "03";
            public const string FakturPenjualan = "04";
            public const string OrderPenjualan = "05";
            public const string PerjanjianSewaBeli = "06";
            public const string RingkasanPerjanianSewaBeli = "07";
            public const string SuratPernyataan = "08";
            public const string SuratKuasa = "09";
            public const string SuratPenyerahanKendaraan = "10";
            public const string SuratPengakuanHutang = "11";
            public const string BatasTempoUangMuka = "12";
            public const string KwitansiPenjualan = "13";
            public const string BatasTempoCashTempo = "14";
            public const string BatasTempoAdministrasi = "15";
            public const string HapusMaster = "16";
            public const string BungaAngsuran = "17";
            public const string HapusPembelian = "18";
            public const string HapusKwitansiPembelian = "19";
            public const string HapusPenjualan = "20";
            public const string HapusKwitansiAdministrasi = "21";
            public const string HapusKwitansiUangMuka = "22";
            public const string HapusKwitansiAngsuran = "23";
            public const string HapusKwitansiPelunasan = "24";
            public const string HapusKonsinyasi = "25";
            public const string BiayaAdministrasi = "26";
            public const string HapusUbahAngsuran = "27";
            // tambahan modul buat kalo jual rugi di layar penjualan
            public const string JualRugi = "28";
            // tambahan modul buat cek print kwitansi
            public const string SuratTagihan_PrintLog = "29";
            // tambahan modul PenerimaanDenda
            public const string PenerimaanDenda_DELETE = "30";
            // tambahan modul Refinance
            public const string Refinance_Bayar_Kelewatan = "31";
            public const string RefinanceOverTempo = "32";
            public const string RefinancePotongan = "33";
            public const string AngsuranOverTempoFLT = "34";
            public const string Refinance_Pelunasan_Kelewatan = "35";
            public const string PelunasanOverTempoFLT = "36";
            public const string PotonganPenerimaanDenda = "37";
            public const string AngsuranOverTempoAPD = "38";
            public const string PelunasanOverTempoAPD = "39";
            public const string PrintBABPKBPenjualan = "40";
            // tambahan pembelian lebih mahal dari harga beli sebelumnya
            public const string PembelianHargaLebih = "41";
            // tambahan modul PenerimaanUMBunga
            public const string PenerimaanUMBunga_DELETE = "42";
            public const string PotonganPenerimaanUMBunga = "43";
            // tambahan modul Recalculate Angsuran TLA
            public const string RecalculateAngsuranTLA = "44";
            // tambahan kalau nopol bukan AD
            public const string MotorNonAD = "45";
            // tambahan Potongan Pelunasan TLA
            public const string PotonganPelunasanTLA = "46";
            public const string BatalJual = "47";
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
