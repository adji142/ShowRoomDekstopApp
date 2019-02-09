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
    public partial class frmLapPiutangOverdue : ISA.Controls.BaseForm
    {
        public frmLapPiutangOverdue()
        {
            InitializeComponent();
        }

        private void frmLapPiutangOverdue_Load(object sender, EventArgs e)
        {
            DateTime value = new DateTime(2017, 9, 1);
            txtTglJual.FromDate = value;
            txtTglJual.ToDate = GlobalVar.GetServerDate;
            txtTglBayarTerakhir.FromDate = value;
            txtTglBayarTerakhir.ToDate = GlobalVar.GetServerDate;
            rbTglJual.Checked = false;
            rbTglBayarTerakhir.Checked = true;
            rbDetail.Checked = true;
            rbRekap.Checked = false;
            if (cboTipeLaporan.Items.Count > 0)
            {
                cboTipeLaporan.SelectedIndex = 0;
            }
            Cursor.Current = Cursors.Default;
            //txtNow.Enabled = false;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LapPiutangAngsuranOverdueALL(DataTable dt)
        {
            String KorT = "";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PIUTANG OVERDUE " + KorT.ToUpper();

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 35;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 7; // No -o
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12; // Tgl Penjualan
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15; // No. Transaksi
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15; // No. Bukti
                ws.Cells[1, 5].Worksheet.Column(5).Width = 35; // Nama Pelanggan
                ws.Cells[1, 6].Worksheet.Column(6).Width = 35; // DaerahDom
                ws.Cells[1, 7].Worksheet.Column(7).Width = 35; // DaerahIdt
                ws.Cells[1, 8].Worksheet.Column(8).Width = 12; // No. Polisi
                ws.Cells[1, 9].Worksheet.Column(9).Width = 20; // Merk/Type
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15; // Tgl. Jatuh Tempo
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15; // Hari Telat
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Total UM Belum JT
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Total UM JT 01 ~ 30
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // Total UM JT 31 ~ 60
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // Total UM JT 61 ~ 90
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // Total UM JT 91 ~ 120
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // Total UM JT 121 ~ 150
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Total UM JT 151 ~ 180
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // Total UM JT 181
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // Total UM Overdue
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // Total UM
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18; // Saldo UM
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18; // Total UM + Saldo UM
                ws.Cells[1, 24].Worksheet.Column(24).Width = 18; // Saldo Titipan
                ws.Cells[1, 25].Worksheet.Column(25).Width = 18; // Saldo Bunga
                ws.Cells[1, 26].Worksheet.Column(26).Width = 15; // Tgl. Faktur Beli
                ws.Cells[1, 27].Worksheet.Column(27).Width = 15; // Tgl. Bayar Terakhir
                ws.Cells[1, 28].Worksheet.Column(28).Width = 18; // Piutang Bunga Overdue
                ws.Cells[1, 29].Worksheet.Column(29).Width = 25; // Keterangan
                ws.Cells[1, 30].Worksheet.Column(30).Width = 18; // Leasing - DP Subsidi
                ws.Cells[1, 31].Worksheet.Column(31).Width = 18; // Leasing - Piutang Pokok
                ws.Cells[1, 32].Worksheet.Column(32).Width = 18; // Leasing - Refund

                ws.Cells[1, 33].Worksheet.Column(33).Width = 15; // Tgl Tagih
                ws.Cells[1, 34].Worksheet.Column(34).Width = 15; // Periode
                ws.Cells[1, 35].Worksheet.Column(35).Width = 30; // KetaranganTagih

                string Title = "LAPORAN PIUTANG OVERDUE " + KorT.ToUpper();

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;

                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TGL. PENJUALAN";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "NO. TRANSAKSI";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NO. BUKTI";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "NAMA PELANGGAN";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "DAERAH DOM";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "DAERAH IDT";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "NO. POLISI";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "MERK / TIPE";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "TGL. JATUH TEMPO";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "HARI TELAT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "TOTAL PIUTANG JT";
                ws.Cells[startH, 13, startH, 19].Merge = true;

                ws.Cells[startH + 1, 13].Value = "< 30";
                ws.Cells[startH + 1, 14].Value = "30 - 60";
                ws.Cells[startH + 1, 15].Value = "61 - 90";
                ws.Cells[startH + 1, 16].Value = "91 - 120";
                ws.Cells[startH + 1, 17].Value = "121 - 150";
                ws.Cells[startH + 1, 18].Value = "151 - 180";
                ws.Cells[startH + 1, 19].Value = "> 180";

                ws.Cells[startH, 20].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 20, startH + 1, 20].Merge = true;

                ws.Cells[startH, 21].Value = "TOTAL PIUTANG";
                ws.Cells[startH, 21, startH + 1, 21].Merge = true;

                ws.Cells[startH, 22].Value = "SALDO UM";
                ws.Cells[startH, 22, startH + 1, 22].Merge = true;

                ws.Cells[startH, 23].Value = "TOTAL PIUTANG + UM";
                ws.Cells[startH, 23, startH + 1, 23].Merge = true;

                ws.Cells[startH, 24].Value = "SALDO TITIPAN";
                ws.Cells[startH, 24, startH + 1, 24].Merge = true;

                ws.Cells[startH, 25].Value = "SALDO BUNGA";
                ws.Cells[startH, 25, startH + 1, 25].Merge = true;

                ws.Cells[startH, 26].Value = "TGL. FAKTUR BELI";
                ws.Cells[startH, 26, startH + 1, 26].Merge = true;

                ws.Cells[startH, 27].Value = "TGL. BAYAR TERAKHIR";
                ws.Cells[startH, 27, startH + 1, 27].Merge = true;

                ws.Cells[startH, 28].Value = "PIUTANG BUNGA OVERDUE";
                ws.Cells[startH, 28, startH + 1, 28].Merge = true;

                ws.Cells[startH, 29].Value = "KETERANGAN";
                ws.Cells[startH, 29, startH + 1, 29].Merge = true;

                ws.Cells[startH, 30].Value = "PIUTANG LEASING";
                ws.Cells[startH, 30, startH, 32].Merge = true;

                ws.Cells[startH + 1, 30].Value = "DP SUBSIDI";
                ws.Cells[startH + 1, 31].Value = "PIUTANG POKOK";
                ws.Cells[startH + 1, 32].Value = "REFUND";

                ws.Cells[startH, 33].Value = "TGL TAGIH";
                ws.Cells[startH, 33, startH + 1, 33].Merge = true;

                ws.Cells[startH, 34].Value = "PERIODE";
                ws.Cells[startH, 34, startH + 1, 34].Merge = true;

                ws.Cells[startH, 35].Value = "KETERANGAN TAGIH";
                ws.Cells[startH, 35, startH + 1, 35].Merge = true;

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
                    ws.Cells[idx, 1].Value = no++;
                    ws.Cells[idx, 2].Value = dr["TglJual"]; // ada PenjHistRowID abis ini tapi ngga dimunculin
                    ws.Cells[idx, 3].Value = dr["NoTrans"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["Nama"];
                    ws.Cells[idx, 6].Value = dr["DaerahDom"];
                    ws.Cells[idx, 7].Value = dr["DaerahIdt"];
                    ws.Cells[idx, 8].Value = dr["Nopol"];
                    ws.Cells[idx, 9].Value = dr["Type"];
                    ws.Cells[idx, 10].Value = dr["TglJT"];
                    ws.Cells[idx, 11].Value = dr["JmlHariTelat"];
                    ws.Cells[idx, 12].Value = dr["TotalPiutangBlmJT"];
                    ws.Cells[idx, 13].Value = dr["TotalPiutangJT0030"];
                    ws.Cells[idx, 14].Value = dr["TotalPiutangJT3160"];
                    ws.Cells[idx, 15].Value = dr["TotalPiutangJT6190"];
                    ws.Cells[idx, 16].Value = dr["TotalPiutangJT91120"];
                    ws.Cells[idx, 17].Value = dr["TotalPiutangJT121150"];
                    ws.Cells[idx, 18].Value = dr["TotalPiutangJT151180"];
                    ws.Cells[idx, 19].Value = dr["TotalPiutangJT181"];
                    ws.Cells[idx, 20].Value = dr["TOTALPIUTANGOVERDUE"];
                    ws.Cells[idx, 21].Value = dr["TOTALPIUTANG"];
                    ws.Cells[idx, 22].Value = dr["saldoum"];
                    ws.Cells[idx, 23].Value = dr["PiutangDanUM"];
                    ws.Cells[idx, 24].Value = dr["SaldoTitipan"];
                    ws.Cells[idx, 25].Value = dr["SaldoBunga"];
                    ws.Cells[idx, 26].Value = dr["TglFakturBeli"];
                    ws.Cells[idx, 27].Value = dr["TanggalBayarTerakir"];
                    ws.Cells[idx, 28].Value = dr["PiutangBungaOverDue"];
                    ws.Cells[idx, 29].Value = dr["Keterangan"];
                    ws.Cells[idx, 30].Value = dr["DPSubsidi"];
                    ws.Cells[idx, 31].Value = dr["PiutangPokokLeasing"];
                    ws.Cells[idx, 32].Value = dr["RefundLeasing"];

                    ws.Cells[idx, 33].Value = dr["TglTagih"];
                    ws.Cells[idx, 34].Value = dr["PeriodeAng"];
                    ws.Cells[idx, 35].Value = dr["KetTagih"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 10].Merge = true;
                ws.Cells[idx, 1, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 2, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";
                ws.Cells[idx, 28].Formula = "Sum(" + ws.Cells[startH + 2, 28].Address + ":" + ws.Cells[idx - 1, 28].Address + ")";
                ws.Cells[idx, 30].Formula = "Sum(" + ws.Cells[startH + 2, 30].Address + ":" + ws.Cells[idx - 1, 30].Address + ")";
                ws.Cells[idx, 31].Formula = "Sum(" + ws.Cells[startH + 2, 31].Address + ":" + ws.Cells[idx - 1, 31].Address + ")";
                ws.Cells[idx, 32].Formula = "Sum(" + ws.Cells[startH + 2, 32].Address + ":" + ws.Cells[idx - 1, 32].Address + ")";

                ws.Cells[startH + 2, 12, idx, 25].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 28, idx, 28].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 26, idx - 1, 26].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 27, idx - 1, 27].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 2, 33, idx - 1, 33].Style.Numberformat.Format = "dd-MMM-yyyy";
                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // No.
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                // TglJual NoTrans NoBukti
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.WrapText = true;
                // Nama Daerah Nopol Tipe
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.WrapText = true;
                // TglJT
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.WrapText = true;
                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 11, idx - 1, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 24].Style.WrapText = true;

                // TotalPiutangBlmJT -> saldoUM -> Saldo Titipan dan Saldo Bunga
                ws.Cells[startH + 2, 12, idx, 24].Style.Numberformat.Format = "#,##0.00";

                // TglFakturBeli TanggalBayarTerakir
                ws.Cells[startH + 2, 26, idx - 1, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 26, idx - 1, 27].Style.WrapText = true;
                // Piutang Bunga Overdue
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;
                ws.Cells[startH + 2, 28, idx, 28].Style.Numberformat.Format = "#,##0.00";

                // Keterangan
                ws.Cells[startH + 2, 29, idx - 1, 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 29, idx - 1, 29].Style.WrapText = true;

                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 30, idx - 1, 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 30, idx - 1, 32].Style.WrapText = true;
                ws.Cells[startH + 2, 30, idx, 32].Style.Numberformat.Format = "#,##0.00";

                ws.Cells[startH + 2, 33, idx - 1, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 33, idx - 1, 33].Style.WrapText = true;

                ws.Cells[startH + 2, 34, idx - 1, 34].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 34, idx - 1, 34].Style.WrapText = true;

                ws.Cells[startH + 2, 35, idx - 1, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 35, idx - 1, 35].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Piutang Overdue " + KorT;
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
                sf.FileName = "Laporan Piutang Overdue " + KorT + " " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapPiutangAngsuranOverdueKREDIT(DataTable dt)
        {
            String KorT = "Kredit";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PIUTANG OVERDUE " + KorT.ToUpper();

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 35;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width =  7; // No -o
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // Tgl Penjualan
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 15; // No. Transaksi
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 15; // No. Bukti
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 35; // Nama Pelanggan
                ws.Cells[1,  6].Worksheet.Column( 6).Width = 35; // DaerahDom
                ws.Cells[1,  7].Worksheet.Column( 7).Width = 35; // DaerahIdt
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 12; // No. Polisi
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 20; // Merk/Type
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15; // Tgl. Jatuh Tempo
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15; // Hari Telat
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Total UM Belum JT
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Total UM JT 01 ~ 30
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // Total UM JT 31 ~ 60
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // Total UM JT 61 ~ 90
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // Total UM JT 91 ~ 120
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // Total UM JT 121 ~ 150
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Total UM JT 151 ~ 180
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // Total UM JT 181
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // Total UM Overdue
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // Total UM
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18; // Saldo UM
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18; // Total UM + Saldo UM
                ws.Cells[1, 24].Worksheet.Column(24).Width = 18; // Saldo Titipan
                ws.Cells[1, 25].Worksheet.Column(25).Width = 18; // Saldo Bunga
                ws.Cells[1, 26].Worksheet.Column(26).Width = 15; // Tgl. Faktur Beli
                ws.Cells[1, 27].Worksheet.Column(27).Width = 15; // Tgl. Bayar Terakhir
                ws.Cells[1, 28].Worksheet.Column(28).Width = 18; // Piutang Bunga Overdue
                ws.Cells[1, 29].Worksheet.Column(29).Width = 25; // Keterangan
                ws.Cells[1, 30].Worksheet.Column(30).Width = 18; // Leasing - DP Subsidi
                ws.Cells[1, 31].Worksheet.Column(31).Width = 18; // Leasing - Piutang Pokok
                ws.Cells[1, 32].Worksheet.Column(32).Width = 18; // Leasing - Refund

                ws.Cells[1, 33].Worksheet.Column(33).Width = 15; // Tgl Tagih
                ws.Cells[1, 34].Worksheet.Column(34).Width = 15; // Periode
                ws.Cells[1, 35].Worksheet.Column(35).Width = 30; // KetaranganTagih

                string Title = "LAPORAN PIUTANG OVERDUE " + KorT.ToUpper();

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;

                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TGL. PENJUALAN";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "NO. TRANSAKSI";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NO. BUKTI";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "NAMA PELANGGAN";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "DAERAH DOM";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "DAERAH IDT";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "NO. POLISI";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "MERK / TIPE";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "TGL. JATUH TEMPO";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "HARI TELAT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "TOTAL PIUTANG JT";
                ws.Cells[startH, 13, startH, 19].Merge = true;

                ws.Cells[startH + 1, 13].Value = "< 30";
                ws.Cells[startH + 1, 14].Value = "30 - 60";
                ws.Cells[startH + 1, 15].Value = "61 - 90";
                ws.Cells[startH + 1, 16].Value = "91 - 120";
                ws.Cells[startH + 1, 17].Value = "121 - 150";
                ws.Cells[startH + 1, 18].Value = "151 - 180";
                ws.Cells[startH + 1, 19].Value = "> 180";

                ws.Cells[startH, 20].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 20, startH + 1, 20].Merge = true;

                ws.Cells[startH, 21].Value = "TOTAL PIUTANG";
                ws.Cells[startH, 21, startH + 1, 21].Merge = true;

                ws.Cells[startH, 22].Value = "SALDO UM";
                ws.Cells[startH, 22, startH + 1, 22].Merge = true;

                ws.Cells[startH, 23].Value = "TOTAL PIUTANG + UM";
                ws.Cells[startH, 23, startH + 1, 23].Merge = true;
            
                ws.Cells[startH, 24].Value = "SALDO TITIPAN";
                ws.Cells[startH, 24, startH + 1, 24].Merge = true;

                ws.Cells[startH, 25].Value = "SALDO BUNGA";
                ws.Cells[startH, 25, startH + 1, 25].Merge = true;

                ws.Cells[startH, 26].Value = "TGL. FAKTUR BELI";
                ws.Cells[startH, 26, startH + 1, 26].Merge = true;

                ws.Cells[startH, 27].Value = "TGL. BAYAR TERAKHIR";
                ws.Cells[startH, 27, startH + 1, 27].Merge = true;

                ws.Cells[startH, 28].Value = "PIUTANG BUNGA OVERDUE";
                ws.Cells[startH, 28, startH + 1, 28].Merge = true;

                ws.Cells[startH, 29].Value = "KETERANGAN";
                ws.Cells[startH, 29, startH + 1, 29].Merge = true;

                ws.Cells[startH, 30].Value = "PIUTANG LEASING";
                ws.Cells[startH, 30, startH, 32].Merge = true;

                ws.Cells[startH + 1, 30].Value = "DP SUBSIDI";
                ws.Cells[startH + 1, 31].Value = "PIUTANG POKOK";
                ws.Cells[startH + 1, 32].Value = "REFUND";

                ws.Cells[startH, 33].Value = "TGL TAGIH";
                ws.Cells[startH, 33, startH + 1, 33].Merge = true;

                ws.Cells[startH, 34].Value = "PERIODE";
                ws.Cells[startH, 34, startH + 1, 34].Merge = true;

                ws.Cells[startH, 35].Value = "KETERANGAN TAGIH";
                ws.Cells[startH, 35, startH + 1, 35].Merge = true;

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
                    ws.Cells[idx,  2].Value = dr["TglJual"]; // ada PenjHistRowID abis ini tapi ngga dimunculin
                    ws.Cells[idx,  3].Value = dr["NoTrans"];
                    ws.Cells[idx,  4].Value = dr["NoBukti"];
                    ws.Cells[idx,  5].Value = dr["Nama"];
                    ws.Cells[idx,  6].Value = dr["DaerahDom"];
                    ws.Cells[idx,  7].Value = dr["DaerahIdt"];
                    ws.Cells[idx,  8].Value = dr["Nopol"];
                    ws.Cells[idx,  9].Value = dr["Type"];
                    ws.Cells[idx, 10].Value = dr["TglJT"];
                    ws.Cells[idx, 11].Value = dr["JmlHariTelat"];
                    ws.Cells[idx, 12].Value = dr["TotalPiutangBlmJT"];
                    ws.Cells[idx, 13].Value = dr["TotalPiutangJT0030"];
                    ws.Cells[idx, 14].Value = dr["TotalPiutangJT3160"];
                    ws.Cells[idx, 15].Value = dr["TotalPiutangJT6190"];
                    ws.Cells[idx, 16].Value = dr["TotalPiutangJT91120"];
                    ws.Cells[idx, 17].Value = dr["TotalPiutangJT121150"];
                    ws.Cells[idx, 18].Value = dr["TotalPiutangJT151180"];
                    ws.Cells[idx, 19].Value = dr["TotalPiutangJT181"];
                    ws.Cells[idx, 20].Value = dr["TOTALPIUTANGOVERDUE"];
                    ws.Cells[idx, 21].Value = dr["TOTALPIUTANG"];
                    ws.Cells[idx, 22].Value = dr["saldoum"];
                    ws.Cells[idx, 23].Value = dr["PiutangDanUM"];
                    ws.Cells[idx, 24].Value = dr["SaldoTitipan"];
                    ws.Cells[idx, 25].Value = dr["SaldoBunga"];
                    ws.Cells[idx, 26].Value = dr["TglFakturBeli"];
                    ws.Cells[idx, 27].Value = dr["TanggalBayarTerakir"];
                    ws.Cells[idx, 28].Value = dr["PiutangBungaOverDue"];
                    ws.Cells[idx, 29].Value = dr["Keterangan"];
                    ws.Cells[idx, 30].Value = dr["DPSubsidi"];
                    ws.Cells[idx, 31].Value = dr["PiutangPokokLeasing"];
                    ws.Cells[idx, 32].Value = dr["RefundLeasing"];

                    ws.Cells[idx, 33].Value = dr["TglTagih"];
                    ws.Cells[idx, 34].Value = dr["PeriodeAng"];
                    ws.Cells[idx, 35].Value = dr["KetTagih"];
                    idx++; 
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 10].Merge = true;
                ws.Cells[idx, 1, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 2, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";
                ws.Cells[idx, 28].Formula = "Sum(" + ws.Cells[startH + 2, 28].Address + ":" + ws.Cells[idx - 1, 28].Address + ")";
                ws.Cells[idx, 30].Formula = "Sum(" + ws.Cells[startH + 2, 30].Address + ":" + ws.Cells[idx - 1, 30].Address + ")";
                ws.Cells[idx, 31].Formula = "Sum(" + ws.Cells[startH + 2, 31].Address + ":" + ws.Cells[idx - 1, 31].Address + ")";
                ws.Cells[idx, 32].Formula = "Sum(" + ws.Cells[startH + 2, 32].Address + ":" + ws.Cells[idx - 1, 32].Address + ")";

                ws.Cells[startH + 2, 12, idx, 25].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 28, idx, 28].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 26, idx - 1, 26].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 27, idx - 1, 27].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 2, 33, idx - 1, 33].Style.Numberformat.Format = "dd-MMM-yyyy";
                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // No.
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                // TglJual NoTrans NoBukti
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.WrapText = true;
                // Nama Daerah Nopol Tipe
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.WrapText = true;
                // TglJT
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.WrapText = true;
                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 11, idx - 1, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 24].Style.WrapText = true;

                // TotalPiutangBlmJT -> saldoUM -> Saldo Titipan dan Saldo Bunga
                ws.Cells[startH + 2, 12, idx, 24].Style.Numberformat.Format = "#,##0.00";

                // TglFakturBeli TanggalBayarTerakir
                ws.Cells[startH + 2, 26, idx - 1, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 26, idx - 1, 27].Style.WrapText = true;
                // Piutang Bunga Overdue
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;
                ws.Cells[startH + 2, 28, idx, 28].Style.Numberformat.Format = "#,##0.00";

                // Keterangan
                ws.Cells[startH + 2, 29, idx - 1, 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 29, idx - 1, 29].Style.WrapText = true;

                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 30, idx - 1, 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 30, idx - 1, 32].Style.WrapText = true;
                ws.Cells[startH + 2, 30, idx, 32].Style.Numberformat.Format = "#,##0.00";

                ws.Cells[startH + 2, 33, idx - 1, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 33, idx - 1, 33].Style.WrapText = true;

                ws.Cells[startH + 2, 34, idx - 1, 34].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 34, idx - 1, 34].Style.WrapText = true;

                ws.Cells[startH + 2, 35, idx - 1, 35].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 35, idx - 1, 35].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Piutang Overdue " + KorT;
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
                sf.FileName = "Laporan Piutang Overdue " + KorT + " " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapPiutangAngsuranOverdueTUNAI(DataTable dt)
        {
            String KorT = "Tunai";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PIUTANG OVERDUE " + KorT.ToUpper();

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 34;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width =  7; // No -o
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // Tgl Penjualan
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 15; // No. Transaksi
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 15; // No. Bukti
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 35; // Nama Pelanggan
                ws.Cells[1,  6].Worksheet.Column( 6).Width = 35; // DaerahDom
                ws.Cells[1,  7].Worksheet.Column( 7).Width = 35; // DaerahIdt
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 12; // No. Polisi
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 20; // Merk/Type
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15; // Tgl. Jatuh Tempo
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15; // Hari Telat
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Total UM Belum JT
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Total UM JT 01 ~ 30
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // Total UM JT 31 ~ 60
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // Total UM JT 61 ~ 90
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // Total UM JT 91 ~ 120
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // Total UM JT 121 ~ 150
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Total UM JT 151 ~ 180
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // Total UM JT 181
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // Total UM Overdue
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // Total UM
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18; // Saldo UM
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18; // Total UM + Saldo UM
                ws.Cells[1, 24].Worksheet.Column(24).Width = 18; // Saldo Titipan
                ws.Cells[1, 25].Worksheet.Column(25).Width = 15; // Tgl. Faktur Beli
                ws.Cells[1, 26].Worksheet.Column(26).Width = 15; // Tgl. Bayar Terakhir
                ws.Cells[1, 27].Worksheet.Column(27).Width = 18; // Piutang Bunga Overdue
                ws.Cells[1, 28].Worksheet.Column(28).Width = 25; // Keterangan
                ws.Cells[1, 29].Worksheet.Column(29).Width = 18; // Leasing - DP Subsidi
                ws.Cells[1, 30].Worksheet.Column(30).Width = 18; // Leasing - Piutang Pokok
                ws.Cells[1, 31].Worksheet.Column(31).Width = 18; // Leasing - Refund

                ws.Cells[1, 32].Worksheet.Column(32).Width = 15; // Tgl Tagih
                ws.Cells[1, 33].Worksheet.Column(33).Width = 15; // Periode
                ws.Cells[1, 34].Worksheet.Column(34).Width = 30; // KetaranganTagih

                string Title = "LAPORAN PIUTANG OVERDUE " + KorT.ToUpper();

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;                                                                                                                                                             

                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TGL. PENJUALAN";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "NO. TRANSAKSI"; 
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NO. BUKTI";  
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "NAMA PELANGGAN"; 
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "DAERAH DOM";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "DAERAH IDT";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "NO. POLISI"; 
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "MERK / TIPE";  
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "TGL. JATUH TEMPO"; 
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "HARI TELAT";  
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;
                
                ws.Cells[startH, 13].Value = "TOTAL PIUTANG JT";
                ws.Cells[startH, 13, startH, 19].Merge = true;

                ws.Cells[startH + 1, 13].Value = "< 30";
                ws.Cells[startH + 1, 14].Value = "30 - 60";
                ws.Cells[startH + 1, 15].Value = "61 - 90";
                ws.Cells[startH + 1, 16].Value = "91 - 120";
                ws.Cells[startH + 1, 17].Value = "121 - 150";
                ws.Cells[startH + 1, 18].Value = "151 - 180";
                ws.Cells[startH + 1, 19].Value = "> 180";

                ws.Cells[startH, 20].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 20, startH + 1, 20].Merge = true;

                ws.Cells[startH, 21].Value = "TOTAL PIUTANG"; 
                ws.Cells[startH, 21, startH + 1, 21].Merge = true;

                ws.Cells[startH, 22].Value = "SALDO UM";
                ws.Cells[startH, 22, startH + 1, 22].Merge = true;

                ws.Cells[startH, 23].Value = "TOTAL PIUTANG + UM";
                ws.Cells[startH, 23, startH + 1, 23].Merge = true;

                ws.Cells[startH, 24].Value = "SALDO TITIPAN";
                ws.Cells[startH, 24, startH + 1, 24].Merge = true;

                ws.Cells[startH, 25].Value = "TGL. FAKTUR BELI"; 
                ws.Cells[startH, 25, startH + 1, 25].Merge = true;

                ws.Cells[startH, 26].Value = "TGL. BAYAR TERAKHIR";
                ws.Cells[startH, 26, startH + 1, 26].Merge = true;

                ws.Cells[startH, 27].Value = "PIUTANG BUNGA OVERDUE"; 
                ws.Cells[startH, 27, startH + 1, 27].Merge = true;

                ws.Cells[startH, 28].Value = "KETERANGAN";
                ws.Cells[startH, 28, startH + 1, 28].Merge = true;

                ws.Cells[startH, 29].Value = "PIUTANG LEASING";
                ws.Cells[startH, 29, startH, 31].Merge = true;

                ws.Cells[startH + 1, 29].Value = "DP SUBSIDI";
                ws.Cells[startH + 1, 30].Value = "PIUTANG POKOK";
                ws.Cells[startH + 1, 31].Value = "REFUND";

                ws.Cells[startH, 32].Value = "TGL TAGIH";
                ws.Cells[startH, 32, startH + 1, 32].Merge = true;

                ws.Cells[startH, 33].Value = "PERIODE";
                ws.Cells[startH, 33, startH + 1, 33].Merge = true;

                ws.Cells[startH, 34].Value = "KETERANGAN TAGIH";
                ws.Cells[startH, 34, startH + 1, 34].Merge = true;

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
                    ws.Cells[idx,  2].Value = dr["TglJual"]; // ada PenjHistRowID abis ini tapi ngga dimunculin
                    ws.Cells[idx,  3].Value = dr["NoTrans"];
                    ws.Cells[idx,  4].Value = dr["NoBukti"];
                    ws.Cells[idx,  5].Value = dr["Nama"];
                    ws.Cells[idx,  6].Value = dr["DaerahDom"];
                    ws.Cells[idx,  7].Value = dr["DaerahIdt"];
                    ws.Cells[idx,  8].Value = dr["Nopol"];
                    ws.Cells[idx,  9].Value = dr["Type"];
                    ws.Cells[idx, 10].Value = dr["TglJT"];
                    ws.Cells[idx, 11].Value = dr["JmlHariTelat"];
                    ws.Cells[idx, 12].Value = dr["TotalPiutangBlmJT"];
                    ws.Cells[idx, 13].Value = dr["TotalPiutangJT0030"];
                    ws.Cells[idx, 14].Value = dr["TotalPiutangJT3160"];
                    ws.Cells[idx, 15].Value = dr["TotalPiutangJT6190"];
                    ws.Cells[idx, 16].Value = dr["TotalPiutangJT91120"];
                    ws.Cells[idx, 17].Value = dr["TotalPiutangJT121150"];
                    ws.Cells[idx, 18].Value = dr["TotalPiutangJT151180"];
                    ws.Cells[idx, 19].Value = dr["TotalPiutangJT181"];
                    ws.Cells[idx, 20].Value = dr["TOTALPIUTANGOVERDUE"];
                    ws.Cells[idx, 21].Value = dr["TOTALPIUTANG"];
                    ws.Cells[idx, 22].Value = dr["saldoum"];
                    ws.Cells[idx, 23].Value = dr["PiutangDanUM"];
                    ws.Cells[idx, 24].Value = dr["SaldoTitipan"];
                    ws.Cells[idx, 25].Value = dr["TglFakturBeli"];
                    ws.Cells[idx, 26].Value = dr["TanggalBayarTerakir"];
                    ws.Cells[idx, 27].Value = dr["PiutangBungaOverDue"];
                    ws.Cells[idx, 28].Value = dr["Keterangan"];
                    ws.Cells[idx, 29].Value = dr["DPSubsidi"];
                    ws.Cells[idx, 30].Value = dr["PiutangPokokLeasing"];
                    ws.Cells[idx, 31].Value = dr["RefundLeasing"];

                    ws.Cells[idx, 32].Value = dr["TglTagih"];
                    ws.Cells[idx, 33].Value = dr["PeriodeAng"];
                    ws.Cells[idx, 34].Value = dr["KetTagih"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 11].Merge = true;
                ws.Cells[idx, 1, idx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 2, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";
                ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                ws.Cells[idx, 27].Formula = "Sum(" + ws.Cells[startH + 2, 27].Address + ":" + ws.Cells[idx - 1, 27].Address + ")";
                ws.Cells[idx, 29].Formula = "Sum(" + ws.Cells[startH + 2, 29].Address + ":" + ws.Cells[idx - 1, 29].Address + ")";
                ws.Cells[idx, 30].Formula = "Sum(" + ws.Cells[startH + 2, 30].Address + ":" + ws.Cells[idx - 1, 30].Address + ")";
                ws.Cells[idx, 31].Formula = "Sum(" + ws.Cells[startH + 2, 31].Address + ":" + ws.Cells[idx - 1, 31].Address + ")";


                ws.Cells[startH + 2, 12, idx, 24].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 27, idx, 27].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 25, idx - 1, 25].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 26, idx - 1, 26].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 2, 32, idx - 1, 33].Style.Numberformat.Format = "dd-MMM-yyyy";
                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // No.
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                // TglJual NoTrans NoBukti
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.WrapText = true;
                // Nama Daerah Nopol Tipe
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.WrapText = true;
                // TglJT
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.WrapText = true;
                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 11, idx - 1, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 24].Style.WrapText = true;

                // TotalPiutangBlmJT -> saldoUM
                ws.Cells[startH + 2, 12, idx, 24].Style.Numberformat.Format = "#,##0.00";

                // TglFakturBeli TanggalBayarTerakir
                ws.Cells[startH + 2, 25, idx - 1, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 25, idx - 1, 26].Style.WrapText = true;
                // Piutang Bunga Overdue
                ws.Cells[startH + 2, 27, idx - 1, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 27, idx - 1, 27].Style.WrapText = true;
                ws.Cells[startH + 2, 27, idx, 27].Style.Numberformat.Format = "#,##0.00";

                // Keterangan
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;

                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 29, idx - 1, 31].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 29, idx - 1, 31].Style.WrapText = true;

                // TotalPiutangBlmJT -> saldoUM
                ws.Cells[startH + 2, 29, idx, 31].Style.Numberformat.Format = "#,##0.00";

                ws.Cells[startH + 2, 32, idx - 1, 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 32, idx - 1, 32].Style.WrapText = true;

                ws.Cells[startH + 2, 33, idx - 1, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 33, idx - 1, 33].Style.WrapText = true;

                ws.Cells[startH + 2, 34, idx - 1, 34].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 34, idx - 1, 34].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Piutang Overdue " + KorT;
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
                sf.FileName = "Laporan Piutang Overdue " + KorT + " " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapPiutangUMOverdue(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PIUTANG UM OVERDUE";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 28;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width =  7; // No
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // Tgl Penjualan
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 15; // No. Transaksi
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 15; // No. Bukti
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 35; // Nama Pelanggan
                ws.Cells[1,  6].Worksheet.Column( 6).Width = 35; // DaerahDom
                ws.Cells[1,  7].Worksheet.Column( 7).Width = 35; // DaerahIdt
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 12; // No. Polisi
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 20; // Merk/Type
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15; // Tgl. Jatuh Tempo
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15; // Hari Telat
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Total UM Belum JT
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Total UM JT 01 ~ 30
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // Total UM JT 31 ~ 60
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // Total UM JT 61 ~ 90
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // Total UM JT 91 ~ 120
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // Total UM JT 121 ~ 150
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Total UM JT 151 ~ 180
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // Total UM JT 181
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // Total UM Overdue
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // Total UM
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18; // Saldo Titipan
                ws.Cells[1, 23].Worksheet.Column(23).Width = 15; // Tgl. Faktur Beli
                ws.Cells[1, 24].Worksheet.Column(24).Width = 15; // Tgl. Bayar Terakhir
                ws.Cells[1, 25].Worksheet.Column(25).Width = 25; // Keterangan

                ws.Cells[1, 26].Worksheet.Column(26).Width = 15; // Tgl Tagih
                ws.Cells[1, 27].Worksheet.Column(27).Width = 15; // Periode
                ws.Cells[1, 28].Worksheet.Column(28).Width = 30; // KetaranganTagih

                string Title = "LAPORAN PIUTANG UM OVERDUE";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;

                if(rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if(rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TGL. PENJUALAN";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "NO. TRANSAKSI";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NO. BUKTI";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "NAMA PELANGGAN";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "DAERAH DOM";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "DAERAH IDT";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "NO. POLISI";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "MERK / TIPE";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "TGL. JATUH TEMPO";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "HARI TELAT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL UM BELUM JT";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "TOTAL UM JT";
                ws.Cells[startH, 13, startH, 19].Merge = true;

                ws.Cells[startH + 1, 13].Value = "< 30";
                ws.Cells[startH + 1, 14].Value = "30 - 60";
                ws.Cells[startH + 1, 15].Value = "61 - 90";
                ws.Cells[startH + 1, 16].Value = "91 - 120";
                ws.Cells[startH + 1, 17].Value = "121 - 150";
                ws.Cells[startH + 1, 18].Value = "151 - 180";
                ws.Cells[startH + 1, 19].Value = "> 181";

                ws.Cells[startH, 20].Value = "TOTAL UM OVERDUE";
                ws.Cells[startH, 20, startH + 1, 20].Merge = true;

                ws.Cells[startH, 21].Value = "TOTAL UM";
                ws.Cells[startH, 21, startH + 1, 21].Merge = true;

                ws.Cells[startH, 22].Value = "SALDO TITIPAN";
                ws.Cells[startH, 22, startH + 1, 22].Merge = true;

                ws.Cells[startH, 23].Value = "TGL. FAKTUR BELI";
                ws.Cells[startH, 23, startH + 1, 23].Merge = true;

                ws.Cells[startH, 24].Value = "TGL. BAYAR TERAKHIR";
                ws.Cells[startH, 24, startH + 1, 24].Merge = true;

                ws.Cells[startH, 25].Value = "KETERANGAN";
                ws.Cells[startH, 25, startH + 1, 25].Merge = true;

                ws.Cells[startH, 26].Value = "TGL TAGIH";
                ws.Cells[startH, 26, startH + 1, 26].Merge = true;

                ws.Cells[startH, 27].Value = "PERIODE";
                ws.Cells[startH, 27, startH + 1, 27].Merge = true;

                ws.Cells[startH, 28].Value = "KETERANGAN TAGIH";
                ws.Cells[startH, 28, startH + 1, 28].Merge = true;

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
                    ws.Cells[idx,  2].Value = dr["TglJual"]; // ada PenjHistRowID abis ini tapi ngga dimunculin
                    ws.Cells[idx,  3].Value = dr["NoTrans"];
                    ws.Cells[idx,  4].Value = dr["NoBukti"];
                    ws.Cells[idx,  5].Value = dr["Nama"];
                    ws.Cells[idx,  6].Value = dr["DaerahDom"];
                    ws.Cells[idx,  7].Value = dr["DaerahIdt"];
                    ws.Cells[idx,  8].Value = dr["Nopol"];
                    ws.Cells[idx,  9].Value = dr["Type"];
                    ws.Cells[idx, 10].Value = dr["TglJT"];
                    ws.Cells[idx, 11].Value = dr["JmlHariTelat"];
                    ws.Cells[idx, 12].Value = dr["TotalPiutangBlmJT"];
                    ws.Cells[idx, 13].Value = dr["TotalPiutangJT0030"];
                    ws.Cells[idx, 14].Value = dr["TotalPiutangJT3160"];
                    ws.Cells[idx, 15].Value = dr["TotalPiutangJT6190"];
                    ws.Cells[idx, 16].Value = dr["TotalPiutangJT91120"];
                    ws.Cells[idx, 17].Value = dr["TotalPiutangJT121150"];
                    ws.Cells[idx, 18].Value = dr["TotalPiutangJT151180"];
                    ws.Cells[idx, 19].Value = dr["TotalPiutangJT181"];
                    ws.Cells[idx, 20].Value = dr["TOTALPIUTANGOVERDUE"];
                    ws.Cells[idx, 21].Value = dr["TOTALPIUTANG"];
                    ws.Cells[idx, 22].Value = dr["SaldoTitipan"];
                    ws.Cells[idx, 23].Value = dr["TglFakturBeli"];
                    ws.Cells[idx, 24].Value = dr["TanggalBayarTerakir"];
                    ws.Cells[idx, 25].Value = dr["Keterangan"];

                    ws.Cells[idx, 26].Value = dr["TglTagih"];
                    ws.Cells[idx, 27].Value = dr["PeriodeAng"];
                    ws.Cells[idx, 28].Value = dr["KetTagih"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 11].Merge = true;
                ws.Cells[idx, 1, idx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                
                ws.Cells[startH + 2, 12, idx, 22].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 23, idx - 1, 24].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 2, 26, idx - 1, 26].Style.Numberformat.Format = "dd-MMM-yyyy";
                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // No.
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                // TglJual NoTrans NoBukti
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.WrapText = true;
                // Nama Daerah Nopol Tipe
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.WrapText = true;
                // TglJT
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.WrapText = true;
                // JmlHariTelat -> saldoUM
                ws.Cells[startH + 2, 11, idx - 1, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 22].Style.WrapText = true;

                // TotalPiutangBlmJT -> saldoUM
                ws.Cells[startH + 2, 12, idx, 22].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // TglFakturBeli TanggalBayarTerakir
                ws.Cells[startH + 2, 23, idx - 1, 24].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 23, idx - 1, 24].Style.WrapText = true;

                ws.Cells[startH + 2, 26, idx - 1, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 26, idx - 1, 26].Style.WrapText = true;

                ws.Cells[startH + 2, 27, idx - 1, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 27, idx - 1, 27].Style.WrapText = true;

                ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Piutang Uang Muka Overdue";
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
                sf.FileName = "Laporan Piutang UM Overdue " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
            DateTime value = new DateTime(2000, 1, 1);
            if(txtTglJual.FromDate > txtTglJual.ToDate)
            {
                DateTime temp = txtTglJual.FromDate.Value;
                txtTglJual.FromDate = txtTglJual.ToDate;
                txtTglJual.ToDate = temp;
            }
            if (txtTglJual.FromDate > value)
            {
                DateTime temp = txtTglJual.FromDate.Value;
                txtTglJual.FromDate = temp;
                //txtTglJual.ToDate = temp;
            }
            if (txtTglBayarTerakhir.FromDate > txtTglBayarTerakhir.ToDate)
            {
                DateTime temp = txtTglBayarTerakhir.FromDate.Value;
                txtTglBayarTerakhir.FromDate = temp;
                //txtTglBayarTerakhir.ToDate = temp;
            }
            if (txtTglBayarTerakhir.FromDate > value )
            {
                DateTime temp = txtTglBayarTerakhir.FromDate.Value;
                txtTglBayarTerakhir.FromDate = temp;
                //txtTglBayarTerakhir.ToDate = temp;
            }

            if (cboTipeLaporan.SelectedIndex >= 0 && cboTipeLaporan.SelectedIndex < cboTipeLaporan.Items.Count)
            {
            }
            else
            {
                MessageBox.Show("Pilih Jenis Laporan yang ingin diproses terlebih dahulu!");
                cboTipeLaporan.Focus();
                return;
            }
            try
            {

                this.Cursor = Cursors.WaitCursor;
                Database db = new Database();
                DataTable dt = new DataTable();
                Database dbS = new Database();
                DataTable dtS = new DataTable();

                if (cboTipeLaporan.SelectedIndex == 0) // Overdue Angsuran
                {
                    if (rbDetail.Checked == true)
                    {
                        db.Commands.Add(db.CreateCommand("rsp_LapPiutangOverdue"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            this.LapPiutangAngsuranOverdueKREDIT(dt);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("rsp_RekapOverdueKREDIT"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Wilayah"));
                        dt = db.Commands[0].ExecuteDataTable();

                        //dbS
                        dbS.Commands.Add(dbS.CreateCommand("rsp_RekapOverdueKREDIT"));
                        if (rbTglJual.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        dbS.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dbS.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Sales"));
                        dtS = dbS.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            this.LapRekapOverdueKREDIT(dt, dtS);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                    
                }
                else if (cboTipeLaporan.SelectedIndex == 1) // Overdue UM
                {
                    if (rbDetail.Checked == true)
                    {
                        db.Commands.Add(db.CreateCommand("rsp_LapPiutangOverdueUM"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            this.LapPiutangUMOverdue(dt);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                    else
                    {
                        //db
                        db.Commands.Add(db.CreateCommand("rsp_RekapPiutangOverdueUM"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Wilayah"));
                        dt = db.Commands[0].ExecuteDataTable();

                        //dbS
                        dbS.Commands.Add(dbS.CreateCommand("rsp_RekapPiutangOverdueUM"));
                        if (rbTglJual.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        dbS.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dbS.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Sales"));
                        dtS = dbS.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            this.LapRekapPiutangUMOverdue(dt, dtS);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                }
                else if (cboTipeLaporan.SelectedIndex == 2) // Overdue Penjualan Tunai
                {
                    if (rbDetail.Checked == true)
                    {
                        db.Commands.Add(db.CreateCommand("rsp_LapPiutangOverdueTUNAI"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            this.LapPiutangAngsuranOverdueTUNAI(dt);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("rsp_RekapPiutangOverdueTUNAI"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Wilayah"));
                        dt = db.Commands[0].ExecuteDataTable();

                        //dbS
                        dbS.Commands.Add(dbS.CreateCommand("rsp_RekapPiutangOverdueTUNAI"));
                        if (rbTglJual.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        dbS.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dbS.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Sales"));
                        dtS = dbS.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            this.LapRekapOverdueTunai(dt, dtS);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                    
                }
                else if (cboTipeLaporan.SelectedIndex == 3) // Overdue Angsuran
                {
                    if (rbDetail.Checked == true)
                    {
                        db.Commands.Add(db.CreateCommand("rsp_LapPiutangOverdue_ALL"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            this.LapPiutangAngsuranOverdueALL(dt);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                    else
                    {
                        //db
                        db.Commands.Add(db.CreateCommand("rsp_RekapOverdueAll"));
                        if (rbTglJual.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Wilayah"));
                        dt = db.Commands[0].ExecuteDataTable();

                        //dbS
                        dbS.Commands.Add(dbS.CreateCommand("rsp_RekapOverdueAll"));
                        if (rbTglJual.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglJual.ToDate)));
                        }
                        else if (rbTglBayarTerakhir.Checked == true)
                        {
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarStart", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.FromDate)));
                            dbS.Commands[0].Parameters.Add(new Parameter("@TglTerakhirBayarEnd", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", txtTglBayarTerakhir.ToDate)));
                        }
                        dbS.Commands[0].Parameters.Add(new Parameter("@CustomerName", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text));
                        dbS.Commands[0].Parameters.Add(new Parameter("@Category", SqlDbType.VarChar, "Sales"));
                        dtS = dbS.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            this.LapRekapOverdueAll(dt, dtS);
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada data untuk ditampilkan!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
                
        }

        private void rbTglJual_CheckedChanged(object sender, EventArgs e)
        {
            urusFilter();
        }

        private void rbTglBayarTerakhir_CheckedChanged(object sender, EventArgs e)
        {
            urusFilter();
        }

        private void urusFilter()
        {
            if (rbTglBayarTerakhir.Checked == true)
            {
                rbTglJual.Checked = false;
                txtTglBayarTerakhir.Enabled = true;
                txtTglJual.Enabled = false;
            }
            else if(rbTglJual.Checked == true)
            {
                rbTglBayarTerakhir.Checked = false;
                txtTglBayarTerakhir.Enabled = false;
                txtTglJual.Enabled = true;
            }
        }

        private void LapRekapOverdueAll(DataTable dt, DataTable dtS)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                #region SETTING EXCEL TITLE & TANGGAL
                /*FROM HERE SET EXCEL*/
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN REKAP OVERDUE";
                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                int MaxCol = 19;
                int jarak = 7;
                int startH = jarak;
                for (int i = 1; i <= 19; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 15;
                }

                /*FROM HERE SET TITLE*/
                string Title = "LAPORAN REKAP PIUTANG OVERDUE";
                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;

                /*FROM HERE SET TANGGAL*/
                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                ws.Cells[6, 1].Value = "Overdue Wilayah";
                ws.Cells[6, 1, 6, 2].Merge = true;
                ws.Cells[6, 1, 6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1, 6, 2].Style.Font.Size = 10;
                ws.Cells[6, 1, 6, 2].Style.Font.Bold = true;

                #endregion

                #region Wilayah

                #region Generate Header

                ws.Cells[startH, 1].Value = "WILAYAH";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                int idx = startH + 2;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary
                
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;
                
                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                
                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                
                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Sales

                #region Generate Header
                int jarak2 = 3;
                startH = startH + idx + 1 - jarak + jarak2;

                ws.Cells[startH-1, 1].Value = "Overdue Salesman";
                ws.Cells[startH-1, 1, startH-1, 2].Merge = true;
                ws.Cells[startH-1, 1, startH-1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH-1, 1, startH-1, 2].Style.Font.Size = 10;
                ws.Cells[startH-1, 1, startH-1, 2].Style.Font.Bold = true;

                ws.Cells[startH, 1].Value = "SALES";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                idx = startH + 2;

                foreach (DataRow dr in dtS.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Overdue";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Footer
                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Overdue";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Rekap Piutang Overdue " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapRekapOverdueTunai(DataTable dt, DataTable dtS)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                #region SETTING EXCEL TITLE & TANGGAL
                /*FROM HERE SET EXCEL*/

                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN REKAP PIUTANG OVERDUE TUNAI";
                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                int MaxCol = 19;
                int jarak = 7;
                int startH = jarak;
                for (int i = 1; i <= 19; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 15;
                }

                /*FROM HERE SET TITLE*/
                string Title = "LAPORAN REKAP PIUTANG OVERDUE TUNAI";
                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;

                /*FROM HERE SET TANGGAL*/
                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                ws.Cells[6, 1].Value = "Overdue Wilayah";
                ws.Cells[6, 1, 6, 2].Merge = true;
                ws.Cells[6, 1, 6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1, 6, 2].Style.Font.Size = 10;
                ws.Cells[6, 1, 6, 2].Style.Font.Bold = true;

                #endregion

                #region Wilayah

                #region Generate Header

                ws.Cells[startH, 1].Value = "WILAYAH";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                int idx = startH + 2;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Sales

                #region Generate Header
                int jarak2 = 3;
                startH = startH + idx + 1 - jarak + jarak2;

                ws.Cells[startH - 1, 1].Value = "Overdue Salesman";
                ws.Cells[startH - 1, 1, startH - 1, 2].Merge = true;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.Font.Size = 10;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.Font.Bold = true;

                ws.Cells[startH, 1].Value = "SALES";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                idx = startH + 2;

                foreach (DataRow dr in dtS.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Overdue";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Footer
                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Overdue";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Rekap Piutang Overdue Tunai " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapRekapPiutangUMOverdue(DataTable dt, DataTable dtS)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                #region SETTING EXCEL TITLE & TANGGAL
                /*FROM HERE SET EXCEL*/

                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN REKAP PIUTANG UM OVERDUE";
                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                int MaxCol = 19;
                int jarak = 7;
                int startH = jarak;
                for (int i = 1; i <= 19; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 15;
                }

                /*FROM HERE SET TITLE*/
                string Title = "LAPORAN REKAP PIUTANG UM OVERDUE";
                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;

                /*FROM HERE SET TANGGAL*/
                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                ws.Cells[6, 1].Value = "Overdue Wilayah";
                ws.Cells[6, 1, 6, 2].Merge = true;
                ws.Cells[6, 1, 6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1, 6, 2].Style.Font.Size = 10;
                ws.Cells[6, 1, 6, 2].Style.Font.Bold = true;

                #endregion

                #region Wilayah

                #region Generate Header

                ws.Cells[startH, 1].Value = "WILAYAH";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                int idx = startH + 2;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Sales

                #region Generate Header
                int jarak2 = 3;
                startH = startH + idx + 1 - jarak + jarak2;

                ws.Cells[startH - 1, 1].Value = "Overdue Salesman";
                ws.Cells[startH - 1, 1, startH - 1, 2].Merge = true;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.Font.Size = 10;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.Font.Bold = true;

                ws.Cells[startH, 1].Value = "SALES";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                idx = startH + 2;

                foreach (DataRow dr in dtS.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Footer
                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Piutang UM Overdue";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Rekap Piutang UM Overdue " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapRekapOverdueKREDIT(DataTable dt, DataTable dtS)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                #region SETTING EXCEL TITLE & TANGGAL
                /*FROM HERE SET EXCEL*/

                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN REKAP PIUTANG OVERDUE KREDIT";
                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";
                int MaxCol = 19;
                int jarak = 7;
                int startH = jarak;
                for (int i = 1; i <= 19; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 15;
                }

                /*FROM HERE SET TITLE*/
                string Title = "LAPORAN REKAP PIUTANG OVERDUE KREDIT";
                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";
                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;

                /*FROM HERE SET TANGGAL*/
                if (rbTglJual.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Jual           : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                else if (rbTglBayarTerakhir.Checked == true)
                {
                    ws.Cells[4, 1].Value = "Tanggal Bayar Terakhir : " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", txtTglBayarTerakhir.ToDate.Value);
                    ws.Cells[4, 1, 4, 4].Merge = true;
                    ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                ws.Cells[6, 1].Value = "Overdue Wilayah";
                ws.Cells[6, 1, 6, 2].Merge = true;
                ws.Cells[6, 1, 6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1, 6, 2].Style.Font.Size = 10;
                ws.Cells[6, 1, 6, 2].Style.Font.Bold = true;

                #endregion

                #region Wilayah

                #region Generate Header

                ws.Cells[startH, 1].Value = "WILAYAH";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                int idx = startH + 2;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Sales

                #region Generate Header
                int jarak2 = 3;
                startH = startH + idx + 1 - jarak + jarak2;

                ws.Cells[startH - 1, 1].Value = "Overdue Salesman";
                ws.Cells[startH - 1, 1, startH - 1, 2].Merge = true;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.Font.Size = 10;
                ws.Cells[startH - 1, 1, startH - 1, 2].Style.Font.Bold = true;

                ws.Cells[startH, 1].Value = "SALES";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL PIUTANG JT Rp.";
                ws.Cells[startH, 3, startH, 9].Merge = true;

                ws.Cells[startH + 1, 3].Value = "< 30";
                ws.Cells[startH + 1, 4].Value = "30 - 60";
                ws.Cells[startH + 1, 5].Value = "61 - 90";
                ws.Cells[startH + 1, 6].Value = "91 - 120";
                ws.Cells[startH + 1, 7].Value = "121 - 150";
                ws.Cells[startH + 1, 8].Value = "151 - 180";
                ws.Cells[startH + 1, 9].Value = "> 180";

                ws.Cells[startH, 10].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "TOTAL PIUTANG BELUM JT";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "TOTAL PIUTANG JT UNIT";
                ws.Cells[startH, 12, startH, 18].Merge = true;

                ws.Cells[startH + 1, 12].Value = "< 30";
                ws.Cells[startH + 1, 13].Value = "30 - 60";
                ws.Cells[startH + 1, 14].Value = "61 - 90";
                ws.Cells[startH + 1, 15].Value = "91 - 120";
                ws.Cells[startH + 1, 16].Value = "121 - 150";
                ws.Cells[startH + 1, 17].Value = "151 - 180";
                ws.Cells[startH + 1, 18].Value = "> 180";

                ws.Cells[startH, 19].Value = "TOTAL PIUTANG OVERDUE";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region Data
                idx = startH + 2;

                foreach (DataRow dr in dtS.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["KATEGORI"];
                    ws.Cells[idx, 2].Value = dr["TOTALPIUTANGBELUMJTRP"];
                    ws.Cells[idx, 3].Value = dr["TOTALPIUTANGJT0030RP"];
                    ws.Cells[idx, 4].Value = dr["TOTALPIUTANGJT3160RP"];
                    ws.Cells[idx, 5].Value = dr["TOTALPIUTANGJT6190RP"];
                    ws.Cells[idx, 6].Value = dr["TOTALPIUTANGJT91120RP"];
                    ws.Cells[idx, 7].Value = dr["TOTALPIUTANGJT121150RP"];
                    ws.Cells[idx, 8].Value = dr["TOTALPIUTANGJT151180RP"];
                    ws.Cells[idx, 9].Value = dr["TOTALPIUTANGJT181RP"];
                    ws.Cells[idx, 10].Value = dr["TOTALPIUTANGOVERDUERP"];
                    ws.Cells[idx, 11].Value = dr["TOTALPIUTANGBELUMJTUNIT"];
                    ws.Cells[idx, 12].Value = dr["TOTALPIUTANGJT0030UNIT"];
                    ws.Cells[idx, 13].Value = dr["TOTALPIUTANGJT3160UNIT"];
                    ws.Cells[idx, 14].Value = dr["TOTALPIUTANGJT6190UNIT"];
                    ws.Cells[idx, 15].Value = dr["TOTALPIUTANGJT91120UNIT"];
                    ws.Cells[idx, 16].Value = dr["TOTALPIUTANGJT121150UNIT"];
                    ws.Cells[idx, 17].Value = dr["TOTALPIUTANGJT151180UNIT"];
                    ws.Cells[idx, 18].Value = dr["TOTALPIUTANGJT181UNIT"];
                    ws.Cells[idx, 19].Value = dr["TOTALPIUTANGOVERDUEUNIT"];

                    idx++;
                }
                #endregion

                #region Summary

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 2, 2].Address + ":" + ws.Cells[idx - 1, 2].Address + ")";
                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 2, 3].Address + ":" + ws.Cells[idx - 1, 3].Address + ")";
                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 2, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 2, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";
                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 2, 6].Address + ":" + ws.Cells[idx - 1, 6].Address + ")";
                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 2, 7].Address + ":" + ws.Cells[idx - 1, 7].Address + ")";
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 14].Formula = "Sum(" + ws.Cells[startH + 2, 14].Address + ":" + ws.Cells[idx - 1, 14].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 2, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";

                #endregion

                #region Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[startH + 2, 2, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";

                // tanggal/faktur -> center, tulisan -> left, angka -> right
                // Wilayah
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                // Total Piutang Belum JT Rp -> Total Piutang Overdue Rp
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 2, idx - 1, 10].Style.WrapText = true;

                // Total Piutang Belum JT Unit -> Total Piutang Overdue Unit
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 19].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Overdue Kredit";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #endregion

                #region Footer
                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Rekap Overdue Kredit";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Rekap Piutang Overdue Kredit " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
    }
}
