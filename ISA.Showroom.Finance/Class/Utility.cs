using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Finance.Class
{
    public enum enumStatusGiro { Diterima, Disetor, BatalSetor, Cair, BatalCair, Ditolak, Batal }
    public enum enumTipeTitipan { Murni, UM, Angsuran, Adm };

    enum enumJnsTransaksi
        {
            ANG = 18, // Pendapatan Bunga Kredit
            FLT = 18, 
            APD = 18,
            UMK = 28, // Uang Muka Penjualan
            UMT = 28, // kasusnya itu dia bisa 24 / 28 (Piutang atau sebagi UM), dibuat defaultnya sebagai UM, tapi nanti pas posting ada pengecekannya sendiri 
            ADM = 12, // tadinya administrasi itu 30 -> Pendapatan Denda Adm & Salesman, kata bu wiwid, jadinya itu 12 -> Hutang Lain-lainnya
            TTP = 29, // um pelanggan
            CTP = 28,
            LSG = 28, // CTP LSG dan TUN dianggap 28 (UMK) dulu 
            TUN = 24, // bukan 19 (penjualan) tapi 24(piutang usaha tetap) // sebelumnya 28 (UM Penjualan) kalau tun mestinya ke Penjualan nih 
            PembelianMotor = 22,
            Denda = 30, // di TLA jadi 62
            PiutangUsahaTetap = 24,
            PendapatanBungaKredit = 18,
            Pembulatan = 32, // 32 itu Pendapatan Lain - Lain
            BiayaKomisi = 31, // sementara 31 dulu???
            PinjamanFisik = 31, // bener2 ngga adda yg cocok, katanya sih Piutang USaha/Pegadaian, tapi belum ada!!!
            BiayaTarikan = 51,
            // -- Bagian TLA
            TLAADM = 32, // ADM di TLA itu Komisi Penjualan
            TLAPiutangUangMuka = 28,
            TLAPiutangPokokLeasing = 59,
            TLADenda = 62,
            TLABiayaKomisi = 63,
            TLASBD = 52, // masih dummy belum diketahui nomor jenis transaksi untuk UM Subsidi
            TLASBT = 52, // Subsidi Tambahan kodenya samain dulu
            TLAUMBunga = 32, // pendapatan lain2, taddinya 62 denda angsuran // untuk sementara UMBunga jenistransaksinya mirip dendaTLA
            TLAPembelianMotorBaru = 54,
            TLAPembelianMotorBekas = 55,
            TLAReparasiMotorBekas = 95, // Persediaan Biaya Reparasi
            TLAPiutangBungaTetap = 56, //56 // maunya tetep pendapatan bunga kredit
            TLAPiutangBungaMenurun = 57, //57 
            TLATUN = 28,
            TLAPotonganPelunasan = 97
          };
}
