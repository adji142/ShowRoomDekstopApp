using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISA.Showroom.Class
{
    enum enumStatusGiro { Diterima, Disetor, BatalSetor, Cair, BatalCair, Ditolak, Batal }
    enum enumTipeTitipan { Murni, UM, Angsuran, Adm };

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
            TLAADM = 32, // ADM di TLA itu Pendapatan Lain Lain
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
            TLAPotonganPelunasan = 97,
            TLAPiutangUMMurni =99
          };



    public class AngsuranDetail
    {
        public System.Guid CustomerRowID;
        public System.Guid PenjualanHistoryRowID;
        public System.Guid PenjualanRowID;
        public string CustomerName;
        public string MataUangID;
        public double SaldoPiutangPokok;
        public double Denda;
        public double TotalAngsuran;
        public string TipeBunga;
        public double NominalPembayaran;
        public double PotonganBunga;
        public double BayarBunga;
        public double BiayaTarikMotor;
        public double Potongan;

        public double TotalNominalIden;
        public string BentukPembayaran;
    }

    public class AngsuranIden
    {
        public System.Guid TitipanRowID;
        public double NominalIden;
        public string BentukPembayaran;
    }

    // class - class untuk yang uang muka

    public class UangMukaDetail
    {
        public System.Guid CustomerRowID;
        public System.Guid PenjualanHistoryRowID;
        public System.Guid PenjualanRowID;
        public string CustomerName;
        public string MataUangID;
        public double UMBunga;

        public double NominalPembayaran;
        public double TotalNominalIden;
        public string BentukPembayaran;
    }

    public class UangMukaIden
    {
        public System.Guid TitipanRowID;
        public double NominalIden;
        public string BentukPembayaran;
    }

    // class - class untuk yang administrasi

    public class AdministrasiDetail
    {
        public System.Guid CustomerRowID;
        public System.Guid PenjualanHistoryRowID;
        public System.Guid PenjualanRowID;
        public string CustomerName;
        public string MataUangID;
        
        public double NominalPembayaran;
        public double TotalNominalIden;
        public string BentukPembayaran;
    }

    public class AdministrasiIden
    {
        public System.Guid TitipanRowID;
        public double NominalIden;
        public string BentukPembayaran;
    }

    // class - class untuk yang Denda

    public class DendaDetail
    {
        public Guid CustomerRowID;
        public Guid PenjualanHistoryRowID;
        public Guid PenjualanRowID;
        public string CustomerName;
        public string MataUangID;

        public double NominalPembayaran;
        public double TotalNominalIden;
        public string BentukPembayaran;
    }

    public class DendaIden
    {
        public Guid TitipanRowID;
        public double NominalIden;
        public string BentukPembayaran;
    }

    // class - class untuk yang UMBunga

    public class UMBungaDetail
    {
        public Guid CustomerRowID;
        public Guid PenjualanRowID;
        public string CustomerName;
        public string MataUangID;

        public double NominalPembayaran;
        public double TotalNominalIden;
        public double Potongan;
        public string BentukPembayaran;
    }

    public class UMBungaIden
    {
        public Guid TitipanRowID;
        public double NominalIden;
        public string BentukPembayaran;
    }
}
