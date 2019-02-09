using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapOmzetPenjualan : ISA.Controls.BaseForm
    {
        public frmLapOmzetPenjualan()
        {
            InitializeComponent();
        }

        private void ListKondisi()
        {
            cboKondisi.DisplayMember = "Text";
            cboKondisi.ValueMember = "Value";
            var items = new[] {
                new { Text = "Baru", Value = "Baru" },
                new { Text = "Bekas", Value = "Bekas" },
                new { Text = "Semua", Value = "" }
            };
            cboKondisi.DataSource = items;
        }

        private void ListPenjualan()
        {
            cboPenjualan.DisplayMember = "Text";
            cboPenjualan.ValueMember = "Value";
            var items = new[] {
                new { Text = "Tunai", Value = "Tunai" },
                new { Text = "Kredit", Value = "Kredit" },
                new { Text = "Semua", Value = "" }
            };
            cboPenjualan.DataSource = items;
        }

        private void frmLapOmzetPenjualan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddMonths(-1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            this.ListKondisi();
            this.ListPenjualan();
            cboKondisi.Text = "Semua";
            cboPenjualan.Text = "Semua";
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateExcel(DataTable dt, DataTable dt2)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                        p.Workbook.Properties.Author = "SAS OTOMOTIF";
                        p.Workbook.Properties.Title = "LAPORAN OMZET PENJUALAN";

                        p.Workbook.Worksheets.Add("OMZET");
                        ExcelWorksheet ws = p.Workbook.Worksheets[1];

                        ws.Name = "OMZET"; //Setting Sheet's name
                        ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        int MaxCol = 28;
                        int startH = 9;

                        ws.Cells[1,  1].Worksheet.Column( 1).Width =  7;    // No
                        ws.Cells[1,  2].Worksheet.Column( 2).Width = 12;    // NoAR
                        ws.Cells[1,  3].Worksheet.Column( 3).Width = 12;    // NoBukti
                        ws.Cells[1,  4].Worksheet.Column( 4).Width = 11;    // Tgl Jual
                        ws.Cells[1,  5].Worksheet.Column( 5).Width = 30;    // Nama Customer
                        ws.Cells[1,  6].Worksheet.Column( 6).Width = 25;    // Surveyor
                        ws.Cells[1,  7].Worksheet.Column( 7).Width = 25;    // Sales
                        ws.Cells[1,  8].Worksheet.Column( 8).Width = 10;    // TipeIDT
                        ws.Cells[1,  9].Worksheet.Column( 9).Width = 15;    // No. IDT
                        ws.Cells[1, 10].Worksheet.Column(10).Width = 99;    // AlamatDom
                        ws.Cells[1, 11].Worksheet.Column(11).Width = 99;    // AlamatIDt
                        ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    // No. Telp
                        ws.Cells[1, 13].Worksheet.Column(13).Width = 25;    // Merk/Type
                        ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    // Thn
                        ws.Cells[1, 15].Worksheet.Column(15).Width = 25;    // No. Rangka
                        ws.Cells[1, 16].Worksheet.Column(16).Width = 25;    // No. Mesin
                        ws.Cells[1, 17].Worksheet.Column(17).Width = 15;    // Warna
                        ws.Cells[1, 18].Worksheet.Column(18).Width = 15;    // No. Polisi
                        ws.Cells[1, 19].Worksheet.Column(19).Width = 18;    // Harga Jual
                        ws.Cells[1, 20].Worksheet.Column(20).Width = 18;    // H.P.P.
                        ws.Cells[1, 21].Worksheet.Column(21).Width = 18;    // B.B.N.
                        ws.Cells[1, 22].Worksheet.Column(22).Width = 18;    // Uang Muka
                        ws.Cells[1, 23].Worksheet.Column(23).Width = 18;    // Piutang Pokok
                        ws.Cells[1, 24].Worksheet.Column(24).Width = 18;    // Bunga
                        ws.Cells[1, 25].Worksheet.Column(25).Width = 18;    // Jumlah
                        ws.Cells[1, 26].Worksheet.Column(26).Width = 18;    // Angsuran/Bln
                        ws.Cells[1, 27].Worksheet.Column(27).Width = 14;    // Tempo Angs.
                        ws.Cells[1, 28].Worksheet.Column(28).Width = 11;    // Tgl JT Pertama

                        string Title = "LAPORAN OMZET PENJUALAN";

                        ws.Cells[1, 1].Value = "";
                        ws.Cells[2, 1].Value = Title;
                        ws.Cells[3, 1].Value = " ";

                        ws.Cells[2, 1, 2, MaxCol].Merge = true;
                        ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                        ws.Cells[4, 1, 4, 4].Merge = true;
                        ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[5, 1].Value = "Kondisi      : " + cboKondisi.Text;
                        ws.Cells[5, 1, 5, 4].Merge = true;
                        ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[6, 1].Value = "Penjualan : " + cboPenjualan.Text;
                        ws.Cells[6, 1, 6, 4].Merge = true;
                        ws.Cells[6, 1, 6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[7, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate) + " - " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate);
                        ws.Cells[7, 1, 7, 4].Merge = true;
                        ws.Cells[7, 1, 7, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                        ws.Cells[2, 1].Style.Font.Size = 18;
                        ws.Cells[4, 1, 7, 4].Style.Font.Size = 12;
                        ws.Cells[4, 1, 7, 4].Style.Font.Bold = true;

                        #region Generate Header

                        ws.Cells[startH,  1].Value = "N0.";              ws.Cells[startH,  1, startH + 1,  1].Merge = true;
                        ws.Cells[startH,  2].Value = "NO. A/R";          ws.Cells[startH,  2, startH + 1,  2].Merge = true;
                        ws.Cells[startH,  3].Value = "No. BUKTI";        ws.Cells[startH,  3, startH + 1,  3].Merge = true;
                        ws.Cells[startH,  4].Value = "TGL. JUAL";        ws.Cells[startH,  4, startH + 1,  4].Merge = true;
                        ws.Cells[startH,  5].Value = "NAMA CUSTOMER";    ws.Cells[startH,  5, startH + 1,  5].Merge = true;
                        ws.Cells[startH,  6].Value = "SURVEYOR";         ws.Cells[startH,  6, startH + 1,  6].Merge = true;
                        ws.Cells[startH,  7].Value = "SALESMAN";         ws.Cells[startH,  7, startH + 1,  7].Merge = true;
                        ws.Cells[startH,  8].Value = "IDT";              ws.Cells[startH,  8, startH + 1,  8].Merge = true;
                        ws.Cells[startH,  9].Value = "NO IDT";           ws.Cells[startH,  9, startH + 1,  9].Merge = true;
                        ws.Cells[startH, 10].Value = "ALAMAT DOM";           ws.Cells[startH, 10, startH + 1, 10].Merge = true;
                        ws.Cells[startH, 11].Value = "ALAMAT IDT";           ws.Cells[startH, 10, startH + 1, 10].Merge = true;
                        ws.Cells[startH, 12].Value = "NO TELP";          ws.Cells[startH, 11, startH + 1, 11].Merge = true;
                        
                        ws.Cells[startH, 13].Value = "DATA KENDARAAN";
                        ws.Cells[startH, 13, startH, 18].Merge = true;
                        ws.Cells[startH + 1, 13].Value = "MERK / TYPE";
                        ws.Cells[startH + 1, 14].Value = "TAHUN";
                        ws.Cells[startH + 1, 15].Value = "NO. RANGKA";
                        ws.Cells[startH + 1, 16].Value = "NO. MESIN";
                        ws.Cells[startH + 1, 17].Value = "WARNA";
                        ws.Cells[startH + 1, 18].Value = "NO. POLISI";
                        
                        ws.Cells[startH, 19].Value = "HARGA JUAL";
                        ws.Cells[startH, 19, startH + 1, 19].Merge = true;
                        ws.Cells[startH, 20].Value = "HPP";
                        ws.Cells[startH, 20, startH + 1, 20].Merge = true;
                        ws.Cells[startH, 21].Value = "BBN";
                        ws.Cells[startH, 21, startH + 1, 21].Merge = true;
                        ws.Cells[startH, 22].Value = "UANG MUKA";
                        ws.Cells[startH, 22, startH + 1, 22].Merge = true;
                        if(GlobalVar.CabangID.Contains("06"))
                        {
                            ws.Cells[startH, 23].Value = "DATA AVALIS";
                        }
                        else 
                        {
                            ws.Cells[startH, 23].Value = "KREDIT";
                        }
                        ws.Cells[startH, 23, startH, 28].Merge = true;
                        ws.Cells[startH + 1, 23].Value = "PIUTANG POKOK";
                        ws.Cells[startH + 1, 24].Value = "BUNGA";
                        ws.Cells[startH + 1, 25].Value = "JUMLAH";
                        ws.Cells[startH + 1, 26].Value = "ANGS/BULAN";
                        ws.Cells[startH + 1, 27].Value = "TEMPO ANGS";
                        ws.Cells[startH + 1, 28].Value = "TGL. JT. PERTAMA";

                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                        #endregion

                        #region FillData
                        int idx = startH + 2;
                        int no = 1;

                        foreach (DataRow dr in dt.Rows)
                        {
                            ws.Cells[idx,  1].Value = no++;
                            ws.Cells[idx,  2].Value = dr["NoAR"];
                            ws.Cells[idx,  3].Value = dr["NoBukti"];
                            ws.Cells[idx,  4].Value = dr["Tanggal"];
                            ws.Cells[idx,  5].Value = dr["Customer"];
                            ws.Cells[idx,  6].Value = dr["Surveyor"];
                            ws.Cells[idx,  7].Value = dr["Sales"];
                            ws.Cells[idx,  8].Value = dr["Identitas"];
                            ws.Cells[idx,  9].Value = dr["NoIdentitas"];
                            ws.Cells[idx, 10].Value = dr["AlamatDom"];
                            ws.Cells[idx, 11].Value = dr["AlamatIdt"];
                            ws.Cells[idx, 12].Value = dr["NoTelp"];
                            ws.Cells[idx, 13].Value = dr["MerkType"];
                            ws.Cells[idx, 14].Value = dr["Tahun"];
                            ws.Cells[idx, 15].Value = dr["NoRangka"];
                            ws.Cells[idx, 16].Value = dr["NoMesin"];
                            ws.Cells[idx, 17].Value = dr["Warna"];
                            ws.Cells[idx, 18].Value = dr["Nopol"];
                            ws.Cells[idx, 19].Value = dr["HargaJual"];
                            ws.Cells[idx, 20].Value = dr["HPP"];
                            ws.Cells[idx, 21].Value = dr["BBN"];
                            ws.Cells[idx, 22].Value = dr["UangMuka"];
                            ws.Cells[idx, 23].Value = dr["Pokok"];
                            ws.Cells[idx, 24].Value = dr["Bunga"];
                            ws.Cells[idx, 25].Value = dr["Jumlah"];
                            ws.Cells[idx, 26].Value = dr["Angsuran"];
                            ws.Cells[idx, 27].Value = dr["TempoAngsuran"];
                            ws.Cells[idx, 28].Value = dr["TglJTPertama"];
                            idx++;
                        }
                        #endregion

                        #region Summary & Formatting
                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                        ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                        ws.Cells[idx, 1].Value = "Total";
                        ws.Cells[idx, 1, idx, 18].Merge = true;
                        ws.Cells[idx, 1, idx, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                        ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                        ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                        ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                        ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                        ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                        ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 2, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";
                        ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                        ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 2, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";
                        ws.Cells[idx, 26].Formula = "Sum(" + ws.Cells[startH + 2, 26].Address + ":" + ws.Cells[idx - 1, 26].Address + ")";

                        ws.Cells[startH + 2, 19, idx, 26].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                        ws.Cells[startH + 2, 19, idx, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        ws.Cells[startH + 2, 11, idx - 1, MaxCol].Style.WrapText = true;

                        ws.Cells[startH + 2, 4, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";
                        ws.Cells[startH + 2, 1, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[startH + 2, 1, idx - 1, 4].Style.WrapText = true;

                        ws.Cells[startH + 2, 28, idx - 1, 28].Style.Numberformat.Format = "dd-MMM-yyyy";
                        ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;

                        ws.Cells[startH + 2, 5, idx - 1, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[startH + 2, 5, idx - 1, 18].Style.WrapText = true;

                        ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                        ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                        ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[idx + 4, 1].Value = "Title      : Laporan Omzet Penjualan";
                        ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                        ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                        border.Bottom.Style =
                         border.Top.Style =
                         border.Left.Style =
                         border.Right.Style = ExcelBorderStyle.Thin;
                        #endregion


                    #region Laporan Omzet Tarikan
                    if(dt2.Rows.Count > 0)
                    {
                            p.Workbook.Worksheets.Add("OMZET-TRK");
                            ws = p.Workbook.Worksheets[2];

                            ws.Name = "OMZET-TRK"; //Setting Sheet's name
                            ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                            ws.Cells.Style.Font.Name = "Calibri";

                            MaxCol = 31;
                            startH = 9;

                            ws.Cells[1,  1].Worksheet.Column( 1).Width =  7;    // No
                            ws.Cells[1,  2].Worksheet.Column( 2).Width = 12;    // NoAR
                            ws.Cells[1,  3].Worksheet.Column( 3).Width = 12;    // NoBukti
                            ws.Cells[1,  4].Worksheet.Column( 4).Width = 11;    // Tgl Jual
                            ws.Cells[1,  5].Worksheet.Column( 5).Width = 30;    // Nama Customer
                            ws.Cells[1,  6].Worksheet.Column( 6).Width = 25;    // Surveyor
                            ws.Cells[1,  7].Worksheet.Column( 7).Width = 25;    // Sales
                            ws.Cells[1,  8].Worksheet.Column( 8).Width = 10;    // TipeIDT
                            ws.Cells[1,  9].Worksheet.Column( 9).Width = 15;    // No. IDT
                            ws.Cells[1, 10].Worksheet.Column(10).Width = 99;    // AlamatDom
                            ws.Cells[1, 11].Worksheet.Column(11).Width = 99;    // AlamatIdt
                            ws.Cells[1, 12].Worksheet.Column(12).Width = 15;    // No. Telp
                            ws.Cells[1, 13].Worksheet.Column(13).Width = 25;    // Merk/Type
                            ws.Cells[1, 14].Worksheet.Column(14).Width = 12;    // Thn
                            ws.Cells[1, 15].Worksheet.Column(15).Width = 25;    // No. Rangka
                            ws.Cells[1, 16].Worksheet.Column(16).Width = 25;    // No. Mesin
                            ws.Cells[1, 17].Worksheet.Column(17).Width = 15;    // Warna
                            ws.Cells[1, 18].Worksheet.Column(18).Width = 15;    // No. Polisi
                            ws.Cells[1, 19].Worksheet.Column(19).Width = 18;    // Harga Jual
                            ws.Cells[1, 20].Worksheet.Column(20).Width = 18;    // H.P.P.
                            ws.Cells[1, 21].Worksheet.Column(21).Width = 18;    // B.B.N.
                            ws.Cells[1, 22].Worksheet.Column(22).Width = 18;    // Uang Muka
                            ws.Cells[1, 23].Worksheet.Column(23).Width = 18;    // Piutang Pokok
                            ws.Cells[1, 24].Worksheet.Column(24).Width = 18;    // Bunga
                            ws.Cells[1, 25].Worksheet.Column(25).Width = 18;    // Jumlah
                            ws.Cells[1, 26].Worksheet.Column(26).Width = 18;    // Angsuran/Bln
                            ws.Cells[1, 27].Worksheet.Column(27).Width = 14;    // Tempo Angs.
                            ws.Cells[1, 28].Worksheet.Column(28).Width = 18;    // Esitmasi
                            ws.Cells[1, 29].Worksheet.Column(29).Width = 18;    // Saldo Pokok
                            ws.Cells[1, 30].Worksheet.Column(30).Width = 18;    // Terima Pokok
                            ws.Cells[1, 31].Worksheet.Column(31).Width = 11;    // Tgl JT Pertama

                            Title = "LAPORAN OMZET TARIKAN PENJUALAN";

                            ws.Cells[1, 1].Value = "";
                            ws.Cells[2, 1].Value = Title;
                            ws.Cells[3, 1].Value = " ";

                            ws.Cells[2, 1, 2, MaxCol].Merge = true;
                            ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                            ws.Cells[4, 1, 4, 4].Merge = true;
                            ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            ws.Cells[5, 1].Value = "Kondisi      : " + cboKondisi.Text;
                            ws.Cells[5, 1, 5, 4].Merge = true;
                            ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            ws.Cells[6, 1].Value = "Penjualan : " + cboPenjualan.Text;
                            ws.Cells[6, 1, 6, 4].Merge = true;
                            ws.Cells[6, 1, 6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            ws.Cells[7, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate) + " - " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate);
                            ws.Cells[7, 1, 7, 4].Merge = true;
                            ws.Cells[7, 1, 7, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                            ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                            ws.Cells[2, 1].Style.Font.Size = 18;
                            ws.Cells[4, 1, 7, 4].Style.Font.Size = 12;
                            ws.Cells[4, 1, 7, 4].Style.Font.Bold = true;

                            #region Generate Header

                            ws.Cells[startH, 1].Value = "N0."; ws.Cells[startH, 1, startH + 1, 1].Merge = true;
                            ws.Cells[startH, 2].Value = "NO. A/R"; ws.Cells[startH, 2, startH + 1, 2].Merge = true;
                            ws.Cells[startH, 3].Value = "No. BUKTI"; ws.Cells[startH, 3, startH + 1, 3].Merge = true;
                            ws.Cells[startH, 4].Value = "TGL. JUAL"; ws.Cells[startH, 4, startH + 1, 4].Merge = true;
                            ws.Cells[startH, 5].Value = "NAMA CUSTOMER"; ws.Cells[startH, 5, startH + 1, 5].Merge = true;
                            ws.Cells[startH, 6].Value = "SURVEYOR"; ws.Cells[startH, 6, startH + 1, 6].Merge = true;
                            ws.Cells[startH, 7].Value = "SALESMAN"; ws.Cells[startH, 7, startH + 1, 7].Merge = true;
                            ws.Cells[startH, 8].Value = "IDT"; ws.Cells[startH, 8, startH + 1, 8].Merge = true;
                            ws.Cells[startH, 9].Value = "NO IDT"; ws.Cells[startH, 9, startH + 1, 9].Merge = true;
                            ws.Cells[startH, 10].Value = "ALAMAT DOM"; ws.Cells[startH, 10, startH + 1, 10].Merge = true;
                            ws.Cells[startH, 11].Value = "ALAMAT IDT"; ws.Cells[startH, 10, startH + 1, 10].Merge = true;
                            ws.Cells[startH, 12].Value = "NO TELP"; ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                            ws.Cells[startH, 13].Value = "DATA KENDARAAN";
                            ws.Cells[startH, 13, startH, 18].Merge = true;
                            ws.Cells[startH + 1, 13].Value = "MERK / TYPE";
                            ws.Cells[startH + 1, 14].Value = "TAHUN";
                            ws.Cells[startH + 1, 15].Value = "NO. RANGKA";
                            ws.Cells[startH + 1, 16].Value = "NO. MESIN";
                            ws.Cells[startH + 1, 17].Value = "WARNA";
                            ws.Cells[startH + 1, 18].Value = "NO. POLISI";

                            ws.Cells[startH, 19].Value = "HARGA JUAL";
                            ws.Cells[startH, 19, startH + 1, 19].Merge = true;
                            ws.Cells[startH, 20].Value = "HPP";
                            ws.Cells[startH, 20, startH + 1, 20].Merge = true;
                            ws.Cells[startH, 21].Value = "BBN";
                            ws.Cells[startH, 21, startH + 1, 21].Merge = true;
                            ws.Cells[startH, 22].Value = "UANG MUKA";
                            ws.Cells[startH, 22, startH + 1, 22].Merge = true;
                            if (GlobalVar.CabangID.Contains("06"))
                            {
                                ws.Cells[startH, 23].Value = "DATA AVALIS";
                            }
                            else
                            {
                                ws.Cells[startH, 23].Value = "KREDIT";
                            }
                            ws.Cells[startH, 23, startH, 28].Merge = true;
                            ws.Cells[startH + 1, 23].Value = "PIUTANG POKOK";
                            ws.Cells[startH + 1, 24].Value = "BUNGA";
                            ws.Cells[startH + 1, 25].Value = "JUMLAH";
                            ws.Cells[startH + 1, 26].Value = "ANGS/BULAN";
                            ws.Cells[startH + 1, 27].Value = "TEMPO ANGS";
                            ws.Cells[startH + 1, 28].Value = "TGL. JT. PERTAMA";

                            ws.Cells[startH, 29].Value = "DATA TARIKAN";
                            ws.Cells[startH, 29, startH, 31].Merge = true;
                            ws.Cells[startH + 1, 29].Value = "ESTIMASI-TRK";
                            ws.Cells[startH + 1, 30].Value = "SALDO POKOK";
                            ws.Cells[startH + 1, 31].Value = "TERIMA POKOK";
 
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                            #endregion

                            #region FillData
                            idx = startH + 2;
                            no = 1;

                            foreach (DataRow dr in dt2.Rows)
                            {
                                ws.Cells[idx,  1].Value = no++;
                                ws.Cells[idx,  2].Value = dr["NoAR"];
                                ws.Cells[idx,  3].Value = dr["NoBukti"];
                                ws.Cells[idx,  4].Value = dr["Tanggal"];
                                ws.Cells[idx,  5].Value = dr["Customer"];
                                ws.Cells[idx,  6].Value = dr["Surveyor"];
                                ws.Cells[idx,  7].Value = dr["Sales"];
                                ws.Cells[idx,  8].Value = dr["Identitas"];
                                ws.Cells[idx,  9].Value = dr["NoIdentitas"];
                                ws.Cells[idx, 10].Value = dr["AlamatDom"];
                                ws.Cells[idx, 11].Value = dr["AlamatIdt"];
                                ws.Cells[idx, 12].Value = dr["NoTelp"];
                                ws.Cells[idx, 13].Value = dr["MerkType"];
                                ws.Cells[idx, 14].Value = dr["Tahun"];
                                ws.Cells[idx, 15].Value = dr["NoRangka"];
                                ws.Cells[idx, 16].Value = dr["NoMesin"];
                                ws.Cells[idx, 17].Value = dr["Warna"];
                                ws.Cells[idx, 18].Value = dr["Nopol"];
                                ws.Cells[idx, 19].Value = dr["HargaJual"];
                                ws.Cells[idx, 20].Value = dr["HPP"];
                                ws.Cells[idx, 21].Value = dr["BBN"];
                                ws.Cells[idx, 22].Value = dr["UangMuka"];
                                ws.Cells[idx, 23].Value = dr["Pokok"];
                                ws.Cells[idx, 24].Value = dr["Bunga"];
                                ws.Cells[idx, 25].Value = dr["Jumlah"];
                                ws.Cells[idx, 26].Value = dr["Angsuran"];
                                ws.Cells[idx, 27].Value = dr["TempoAngsuran"];
                                ws.Cells[idx, 28].Value = dr["TglJTPertama"];
                                ws.Cells[idx, 29].Value = dr["HargaEstimasi"];
                                ws.Cells[idx, 30].Value = dr["SisaPokok"];
                                ws.Cells[idx, 31].Value = dr["BayarPokok"];
                                idx++;
                            }
                            #endregion

                            #region Summary & Formatting
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                            ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                            ws.Cells[idx, 1].Value = "Total";
                            ws.Cells[idx, 1, idx, 17].Merge = true;
                            ws.Cells[idx, 1, idx, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                            ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                            ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                            ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                            ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                            ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                            ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 2, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";
                            ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                            ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 2, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";
                            ws.Cells[idx, 26].Formula = "Sum(" + ws.Cells[startH + 2, 26].Address + ":" + ws.Cells[idx - 1, 26].Address + ")";
                            ws.Cells[idx, 29].Formula = "Sum(" + ws.Cells[startH + 2, 28].Address + ":" + ws.Cells[idx - 1, 28].Address + ")";
                            ws.Cells[idx, 30].Formula = "Sum(" + ws.Cells[startH + 2, 29].Address + ":" + ws.Cells[idx - 1, 29].Address + ")";
                            ws.Cells[idx, 31].Formula = "Sum(" + ws.Cells[startH + 2, 30].Address + ":" + ws.Cells[idx - 1, 30].Address + ")";

                            ws.Cells[startH + 2, 19, idx, 26].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                            ws.Cells[startH + 2, 19, idx, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[startH + 2, 19, idx - 1, 27].Style.WrapText = true;
                
                            ws.Cells[startH + 2, 29, idx, 31].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                            ws.Cells[startH + 2, 29, idx, 31].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            ws.Cells[startH + 2, 29, idx - 1, 31].Style.WrapText = true;

                            ws.Cells[startH + 2, 4, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";
                            ws.Cells[startH + 2, 1, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[startH + 2, 1, idx - 1, 4].Style.WrapText = true;

                            ws.Cells[startH + 2, 28, idx - 1, 28].Style.Numberformat.Format = "dd-MMM-yyyy";
                            ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;

                            ws.Cells[startH + 2, 5, idx - 1, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            ws.Cells[startH + 2, 5, idx - 1, 18].Style.WrapText = true;

                            ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                            ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                            ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            ws.Cells[idx + 4, 1].Value = "Title      : Laporan Omzet Penjualan";
                            ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                            ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                            border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                            border.Bottom.Style =
                             border.Top.Style =
                             border.Left.Style =
                             border.Right.Style = ExcelBorderStyle.Thin;
                            #endregion
                    }
                    #endregion

                    #region Output
                    Byte[] bin = p.GetAsByteArray();

                    SaveFileDialog sf = new SaveFileDialog();
                    sf.InitialDirectory = "C:\\Temp\\";
                    sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    sf.FileName = "Laporan Omzet Penjualan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate > rangeDateBox1.ToDate)
            {
                DateTime temp = rangeDateBox1.FromDate.Value;
                rangeDateBox1.FromDate = rangeDateBox1.ToDate;
                rangeDateBox1.ToDate = temp;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_LapPenjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, rangeDateBox1.ToDate));
                    if (!string.IsNullOrEmpty(cboKondisi.SelectedValue.ToString()))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, cboKondisi.SelectedValue));
                    }
                    if (!string.IsNullOrEmpty(cboPenjualan.SelectedValue.ToString()))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, cboPenjualan.SelectedValue));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                using (Database db2 = new Database())
                {
                    db2.Commands.Add(db2.CreateCommand("rsp_LapPenjualan_Tarikan"));
                    db2.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db2.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, rangeDateBox1.ToDate));
                    if (!string.IsNullOrEmpty(cboKondisi.SelectedValue.ToString()))
                    {
                        db2.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, cboKondisi.SelectedValue));
                    }
                    if (!string.IsNullOrEmpty(cboPenjualan.SelectedValue.ToString()))
                    {
                        db2.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, cboPenjualan.SelectedValue));
                    }
                    db2.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt2 = db2.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    this.GenerateExcel(dt, dt2);
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
    }
}
