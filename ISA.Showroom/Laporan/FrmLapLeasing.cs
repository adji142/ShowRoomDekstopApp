using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ISA.Showroom.Class;

namespace ISA.Showroom.Laporan
{
    public partial class FrmLapLeasing : ISA.Controls.BaseForm
    {
        public FrmLapLeasing()
        {
            InitializeComponent();
        }

        private void CMDTampil_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(rangeDateBox1.FromDate.ToString())) && (string.IsNullOrEmpty(rangeDateBox1.ToDate.ToString())))
            {
                MessageBox.Show("Tanggal belum diisi !");
                return;
            }
            if (rangeDateBox1.FromDate > rangeDateBox1.ToDate)
            {
                MessageBox.Show("Tanggal awal lebih besar dari pada tanggal akhir !");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_penjualanLSG"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", rangeDateBox1.FromDate)));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", rangeDateBox1.ToDate)));
                    db.Commands[0].Parameters.Add(new Parameter("@customername", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@statuslunas", SqlDbType.SmallInt, cboStatusLunas.SelectedIndex));
                    db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, "ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, "T"));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, "LSG"));
                   // db.Commands[0].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, ""));
                   //db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, ""));
                   // db.Commands[0].Parameters.Add(new Parameter("@TipeMotor", SqlDbType.VarChar, ""));
                   // db.Commands[0].Parameters.Add(new Parameter("@Kecamatan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@OrderBy", SqlDbType.VarChar, "No Trans"));
                    db.Commands[0].Parameters.Add(new Parameter("@ASCDESC", SqlDbType.VarChar, "ASC"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                   this.GenerateExcel(dt);
                }
                else
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan!");
                }
            }
             catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GenerateExcel(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                String statusLunas = "";
                switch (cboStatusLunas.SelectedIndex)
                {
                    case 0: statusLunas = "Semua"; break;
                    case 1: statusLunas = "Belum Lunas"; break;
                    case 2: statusLunas = "Lunas"; break;
                }

                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PENJUALAN LEASING";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 45;
                int startH = 8;

                // tambahin sales dan alamat
                ws.Cells[1, 1].Worksheet.Column(1).Width = 7;    //"N0.";
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12;    //"NO. TRANS";
                ws.Cells[1, 3].Worksheet.Column(3).Width = 12;    //"NO. BUKTI";
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15;    //"TGL. JUAL";
                ws.Cells[1, 5].Worksheet.Column(5).Width = 35;    //"NAMA PELANGGAN";
                ws.Cells[1, 6].Worksheet.Column(6).Width = 35;    //"KECAMATAN";
                ws.Cells[1, 7].Worksheet.Column(7).Width = 25;    //"NAMA SALES";
                ws.Cells[1, 8].Worksheet.Column(8).Width = 20;    //"JENIS PENJUALAN";
                ws.Cells[1, 9].Worksheet.Column(9).Width = 15;    //"TIPE BUNGA";
                ws.Cells[1, 10].Worksheet.Column(10).Width = 12;    //"TEMPO";
                ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //"MEREK";
                ws.Cells[1, 12].Worksheet.Column(12).Width = 25;    //"TIPE";
                ws.Cells[1, 13].Worksheet.Column(13).Width = 25;    //"NAMA BPKB";
                ws.Cells[1, 14].Worksheet.Column(14).Width = 15;    //"NO. POLISI";
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18;    //"HARGA JUAL";
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18;    //"HARGA OTR";
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18;    //"HARGA BELI";
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18;    //"Tambahan";
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18;    //"HPP";


                ws.Cells[1, 20].Worksheet.Column(20).Width = 19;    //"PROFIT";
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18;    //"BIAYA BALIK NAMA";
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18;    //"BIAYA ADMINISTRASI";
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18;    //"UM SETARA";
                ws.Cells[1, 24].Worksheet.Column(24).Width = 18;    //"UM SUBSIDI";
                ws.Cells[1, 25].Worksheet.Column(25).Width = 18;    //"UM MURNI";
                ws.Cells[1, 26].Worksheet.Column(26).Width = 18;    //"PIUT POKOK";
                ws.Cells[1, 27].Worksheet.Column(27).Width = 18;    //"PEMB UM SUBSIDI";
                ws.Cells[1, 28].Worksheet.Column(28).Width = 18;    //"PEMB UM MURNI";
                ws.Cells[1, 29].Worksheet.Column(29).Width = 18;    //"PEMB PIUT POKOK LSG";
                ws.Cells[1, 30].Worksheet.Column(30).Width = 18;    //"BUKTI PEMB UM SUB";
                ws.Cells[1, 31].Worksheet.Column(31).Width = 18;    //"BUKTI PEMB UM MURNI";
                ws.Cells[1, 32].Worksheet.Column(32).Width = 18;    //"BUKTI PEMB PIUT LSG";
                ws.Cells[1, 30].Worksheet.Column(33).Width = 15;    //"TGL PEMB UM SUB";
                ws.Cells[1, 31].Worksheet.Column(34).Width = 15;    //"TGL PEMB UM MURNI";
                ws.Cells[1, 32].Worksheet.Column(35).Width = 15;    //"TGL PEMB PIUT LSG";
                ws.Cells[1, 32].Worksheet.Column(36).Width = 12;    //"NAMA LSG";

                ws.Cells[1, 33].Worksheet.Column(37).Width = 18;    //"SALDO PIUTANG";
                ws.Cells[1, 34].Worksheet.Column(38).Width = 18;    //"TOTAL PEMBAYARAN";
                ws.Cells[1, 35].Worksheet.Column(39).Width = 15;    //"STATUS PELUNASAN";
                ws.Cells[1, 36].Worksheet.Column(40).Width = 15;    //"JUAL/GADAI";
                ws.Cells[1, 37].Worksheet.Column(41).Width = 20;    //"SELISIH BYR SUBSIDI";
                ws.Cells[1, 42].Worksheet.Column(42).Width = 20;    //"ADJ / ALOKASI KERUGIAN";
                ws.Cells[1, 43].Worksheet.Column(43).Width = 20;    //"NOMINAL LABA";
                ws.Cells[1, 44].Worksheet.Column(44).Width = 20;    //"BIAYA KOMISI";
                ws.Cells[1, 45].Worksheet.Column(45).Width = 16;    //"ASAL";

                string Title = "LAPORAN PENJUALAN LEASING";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang        : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode       : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate);
                ws.Cells[5, 1, 5, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1].Value = "Status Lunas  : " + statusLunas;
                ws.Cells[6, 1, 6, 4].Merge = true;
                ws.Cells[6, 1, 6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 6, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 6, 4].Style.Font.Bold = true;

                #region Generate Header

                // tambahin sales dan alamat
                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 2].Value = "NO. TRANS";
                ws.Cells[startH, 3].Value = "NO BUKTI";
                ws.Cells[startH, 4].Value = "TGL. JUAL";
                ws.Cells[startH, 5].Value = "NAMA PELANGGAN";
                ws.Cells[startH, 6].Value = "KECAMATAN";
                ws.Cells[startH, 7].Value = "NAMA SALES";
                ws.Cells[startH, 8].Value = "JENIS PENJUALAN";
                ws.Cells[startH, 9].Value = "TIPE BUNGA";
                ws.Cells[startH, 10].Value = "TEMPO";
                ws.Cells[startH, 11].Value = "MEREK";
                ws.Cells[startH, 12].Value = "TIPE";
                ws.Cells[startH, 13].Value = "NAMA BPKB";
                ws.Cells[startH, 14].Value = "NO. POLISI";
                ws.Cells[startH, 15].Value = "HARGA JUAL";
                ws.Cells[startH, 16].Value = "HARGA OTR";
                ws.Cells[startH, 17].Value = "HARGA BELI";
                ws.Cells[startH, 18].Value = "BIAYA TAMBAHAN";
                ws.Cells[startH, 19].Value = "HPP";
                ws.Cells[startH, 20].Value = "PROFIT";
                ws.Cells[startH, 21].Value = "BIAYA BALIK NAMA";
                ws.Cells[startH, 22].Value = "BIAYA ADM";
                ws.Cells[startH, 23].Value = "UANG MUKA";
                ws.Cells[startH, 24].Value = "UM SUBSIDI";
                ws.Cells[startH, 25].Value = "UM MURNI";
                ws.Cells[startH, 26].Value = "PIUT POKOK LSG";
                ws.Cells[startH, 27].Value = "PBYR UM SBD";
                ws.Cells[startH, 28].Value = "PBYR UM MURNI";
                ws.Cells[startH, 29].Value = "PBYR PIUT POK LSG";
                ws.Cells[startH, 30].Value = "BUKTI PBYR SBD";
                ws.Cells[startH, 31].Value = "BUKTI PBYR MUR";
                ws.Cells[startH, 32].Value = "BUKTI PBYR P LSG";
                ws.Cells[startH, 33].Value = "TGL PBYR SBD";
                ws.Cells[startH, 34].Value = "TGL PBYR MUR";
                ws.Cells[startH, 35].Value = "TGL PBYR P LSG";
                ws.Cells[startH, 36].Value = "LEASING";


                ws.Cells[startH, 37].Value = "SALDO PIUTANG";
                ws.Cells[startH, 38].Value = "TOTAL PEMBAYARAN";
                ws.Cells[startH, 39].Value = "STATUS PELUNASAN";
                ws.Cells[startH, 40].Value = "JUAL/GADAI";
                ws.Cells[startH, 41].Value = "SELISIH BYR SBD";
                ws.Cells[startH, 42].Value = "ADJ / ALOKASI KERUGIAN";
                ws.Cells[startH, 43].Value = "NOMINAL LABA";
                ws.Cells[startH, 44].Value = "BIAYA KOMISI";
                ws.Cells[startH, 45].Value = "ASAL";

                ws.Cells[startH, 1, startH, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH, MaxCol].Style.WrapText = true;

                #endregion

                #region FillData
                int idx = startH + 1;
                int no = 1;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[idx, 1].Value = no++;
                    ws.Cells[idx, 2].Value = dr["NoTrans"];
                    ws.Cells[idx, 3].Value = dr["NoBukti"];
                    ws.Cells[idx, 4].Value = dr["TglJual"];
                    ws.Cells[idx, 5].Value = dr["Nama"];
                    ws.Cells[idx, 6].Value = dr["Kecamatan"];
                    ws.Cells[idx, 7].Value = dr["NamaSales"];
                    string temp = "";
                    switch (dr["JenisPenjualan"].ToString())
                    {
                        case "K": temp = "Kredit"; break;
                        case "T": temp = "Tunai - " + dr["KodeTrans"]; break;
                        default: temp = ""; break;
                    }
                    ws.Cells[idx, 8].Value = temp;

                    switch (dr["TipeBunga"].ToString())
                    {
                        case "FLT": temp = "Bunga Tetap"; break;
                        case "APD": temp = "Bunga Menurun"; break;
                        default: temp = "-"; break;
                    }
                    ws.Cells[idx, 9].Value = temp;
                    ws.Cells[idx, 10].Value = dr["Tempo"];
                    ws.Cells[idx, 11].Value = dr["Merk"];
                    ws.Cells[idx, 12].Value = dr["Type"];
                    ws.Cells[idx, 13].Value = dr["NamaBPKB"];
                    ws.Cells[idx, 14].Value = dr["Nopol"];
                    ws.Cells[idx, 15].Value = dr["HargaJual"];
                    ws.Cells[idx, 16].Value = dr["HargaOTR"];
                    ws.Cells[idx, 17].Value = dr["HargaBeli"]; //Convert.ToDouble(Tools.isNull(dr["Biaya"], 0)) + Convert.ToDouble(Tools.isNull(dr["HargaOff"], 0));
                    ws.Cells[idx, 18].Value = dr["tambahan"];
                    ws.Cells[idx, 19].Value = dr["HPP"];
                    ws.Cells[idx, 20].Value = dr["Profit"];
                    ws.Cells[idx, 21].Value = dr["BiayaBBN"];
                    ws.Cells[idx, 22].Value = dr["BiayaADM"];
                    ws.Cells[idx, 23].Value = dr["UMSetara"];
                    ws.Cells[idx, 24].Value = dr["UMSubsidi"];
                    ws.Cells[idx, 25].Value = dr["UMMurni"];
                    ws.Cells[idx, 26].Value = dr["PiutPokok"];
                    ws.Cells[idx, 27].Value = dr["UMTerimaSBD"];
                    ws.Cells[idx, 28].Value = dr["UMTerimaUMK"];
                    ws.Cells[idx, 29].Value = dr["UMTerimaLSG"];
                    ws.Cells[idx, 30].Value = dr["NoBuktiSBD"];
                    ws.Cells[idx, 31].Value = dr["NoBuktiUMK"];
                    ws.Cells[idx, 32].Value = dr["NoBuktiLSG"];
                    ws.Cells[idx, 33].Value = dr["TGLSBD"];
                    ws.Cells[idx, 34].Value = dr["TGLUMK"];
                    ws.Cells[idx, 35].Value = dr["TGLLGS"];
                    ws.Cells[idx, 36].Value = dr["NamaLsg"];

                    ws.Cells[idx, 37].Value = dr["saldopiutang"];
                    ws.Cells[idx, 38].Value = dr["totalpembayaran"];
                    switch (dr["STATUSLUNAS"].ToString())
                    {
                        case "1": temp = "Lunas"; break;
                        case "2": temp = "Belum Lunas"; break;
                        default: temp = ""; break;
                    }
                    ws.Cells[idx, 39].Value = temp;
                    switch (dr["penjualanorpegadaian"].ToString())
                    {
                        case "PGD": temp = "Pegadaian"; break;
                        default: temp = ""; break;
                    }
                    ws.Cells[idx, 40].Value = temp;
                    ws.Cells[idx, 41].Value = Convert.ToDouble(Tools.isNull(dr["UMSubsidi"],0)) - Convert.ToDouble(Tools.isNull(dr["UMTerimaSBD"],0));
                    ws.Cells[idx, 42].Value = dr["Adj"];
                    ws.Cells[idx, 43].Value = dr["laba"];
                    ws.Cells[idx, 44].Value = dr["BIayaKomisi"];
                    ws.Cells[idx, 45].Value = dr["Asal"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 13].Merge = true;
                ws.Cells[idx, 1, idx, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // Total HargaJual
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 1, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                // Total HargaOTR
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 1, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                // Total HargaBeli
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 1, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                //Total Tambahan
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 1, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                //Total HPP
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 1, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                // Summary Profit
                ws.Cells[idx, 20].Formula = "((" + ws.Cells[idx, 15].Address + "/" + ws.Cells[idx, 19].Address + ") * 100) - 100";
                // Biaya BBN
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 1, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                // total administrasi
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 1, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";

                // total UM
                ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 1, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";

                // total UM Sub
                ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 1, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                // total UM Murni
                ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 1, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";
                // total PiutPokok
                ws.Cells[idx, 26].Formula = "Sum(" + ws.Cells[startH + 1, 26].Address + ":" + ws.Cells[idx - 1, 26].Address + ")";
                // total Pemb UM SBD
                ws.Cells[idx, 27].Formula = "Sum(" + ws.Cells[startH + 1, 27].Address + ":" + ws.Cells[idx - 1, 27].Address + ")";
                // total Piemb UM MUR
                ws.Cells[idx, 28].Formula = "Sum(" + ws.Cells[startH + 1, 28].Address + ":" + ws.Cells[idx - 1, 28].Address + ")";
                // total PEMB PiutPokok LSG
                ws.Cells[idx, 29].Formula = "Sum(" + ws.Cells[startH + 1, 29].Address + ":" + ws.Cells[idx - 1, 29].Address + ")";
                //total saldopiut
                ws.Cells[idx, 37].Formula = "Sum(" + ws.Cells[startH + 1, 37].Address + ":" + ws.Cells[idx - 1, 37].Address + ")";
                //total pembayaran
                ws.Cells[idx, 38].Formula = "Sum(" + ws.Cells[startH + 1, 38].Address + ":" + ws.Cells[idx - 1, 38].Address + ")";
                // SelisihBayarSubsidi
                ws.Cells[idx, 41].Formula = "Sum(" + ws.Cells[startH + 1, 41].Address + ":" + ws.Cells[idx - 1, 41].Address + ")";
                // adj
                ws.Cells[idx, 42].Formula = "Sum(" + ws.Cells[startH + 1, 42].Address + ":" + ws.Cells[idx - 1, 42].Address + ")";
                // totallaba
                ws.Cells[idx, 43].Formula = "Sum(" + ws.Cells[startH + 1, 43].Address + ":" + ws.Cells[idx - 1, 43].Address + ")";
                // BiayaKomisi
                ws.Cells[idx, 44].Formula = "Sum(" + ws.Cells[startH + 1, 44].Address + ":" + ws.Cells[idx - 1, 44].Address + ")";

                ws.Cells[startH + 1, 15, idx, 29].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 37, idx, 38].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 41, idx, 41].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 42, idx, 42].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 42, idx, 44].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 4, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 1, 33, idx - 1, 35].Style.Numberformat.Format = "dd-MMM-yyyy";

                // No NoTrans
                ws.Cells[startH + 1, 1, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 1, idx - 1, 2].Style.WrapText = true;
                // TglJual
                ws.Cells[startH + 1, 4, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 4, idx - 1, 4].Style.WrapText = true;
                // Nama JenisPenjualan TipeBunga
                ws.Cells[startH + 1, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 5, idx - 1, 9].Style.WrapText = true;
                //Tempo
                ws.Cells[startH + 1, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 10, idx - 1, 10].Style.WrapText = true;
                // Merk Type NamaBPKB
                ws.Cells[startH + 1, 11, idx - 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 11, idx - 1, 13].Style.WrapText = true;
                // NoPol
                ws.Cells[startH + 1, 14, idx - 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 14, idx - 1, 14].Style.WrapText = true;
                // HargaJual -> totalpembayaran
                ws.Cells[startH + 1, 15, idx - 1, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 15, idx - 1, 22].Style.WrapText = true;
                // TglPelunasanLSG
                ws.Cells[startH + 1, 33, idx - 1, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 33, idx - 1, 33].Style.WrapText = true;
                // nama LEASING
                ws.Cells[startH + 1, 36, idx - 1, 36].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 36, idx - 1, 36].Style.WrapText = true;
                // STATUSLUNAS penjualanorpegadaian
                ws.Cells[startH + 1, 39, idx - 1, 40].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 39, idx - 1, 40].Style.WrapText = true;
                // SelisihBayarSBD
                ws.Cells[startH + 1, 41, idx - 1, 42].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 41, idx - 1, 42].Style.WrapText = true;
                // ADJ
                ws.Cells[startH + 1, 42, idx - 1, 43].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 42, idx - 1, 43].Style.WrapText = true;
                // Laba
                ws.Cells[startH + 1, 43, idx - 1, 44].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 43, idx - 1, 44].Style.WrapText = true;
                // ASAL
                ws.Cells[startH + 1, 45, idx - 1, 45].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 45, idx - 1, 45].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Penjualan Leasing";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "LapPenjualanLSG " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    File.WriteAllBytes(file, bin);
                    MessageBox.Show("Laporan Selesai. " + file);
                    Process.Start(sf.FileName.ToString());
                }

                #endregion
            }
        }
        private void FrmLapLeasing_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;           
            cboStatusLunas.SelectedIndex = 0;
        }

        private void CMdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
