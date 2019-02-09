using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Reporting.WinForms;


namespace ISA.Showroom.Laporan
{
    public partial class frmLapPiutangSaldo : ISA.Controls.BaseForm
    {
        public frmLapPiutangSaldo()
        {
            InitializeComponent();
        }


        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_PiutangFLT_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, txtTglJual.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Todate", SqlDbType.DateTime, txtTglJual.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@FromPeriode", SqlDbType.DateTime, txtBayar.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToPeriode", SqlDbType.DateTime,txtBayar.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    this.LapPiutangAngsuranOverdueKREDIT(dt); //iki
                }
                else
                {
                    MessageBox.Show("Tidak ada data...");                    
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

        private void LapPiutangAngsuranOverdueKREDIT(DataTable dt)
        {
            //String KorT = "Kredit";

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PENJUALAN KREDIT BERSALDO " ;//+ KorT.ToUpper();

                p.Workbook.Worksheets.Add("PiutangSaldo");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "PenjKreditBersaldo"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 31;
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
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15; // TglAlkhir Angsuran --
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15; // Piutang Pokok --
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Piutang Bunga -- 
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Piutang Uang Muka --
                ws.Cells[1, 14].Worksheet.Column(14).Width = 12; // Tempo --
                ws.Cells[1, 15].Worksheet.Column(15).Width = 12; // Bunga --
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // AngsPokok/Bulan --
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // AngsBunga/Bulan --
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Total Angs --

                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // AngsPokokPerio --
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // AngsPokokPerio--
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // AngsPokokPerio --


                ws.Cells[1, 22].Worksheet.Column(22).Width = 18; // AngsPokokTerima --
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18; // AngsBungaTerima --
                ws.Cells[1, 24].Worksheet.Column(24).Width = 18; // TotalAngsTerima --
                ws.Cells[1, 25].Worksheet.Column(25).Width = 18; // Terakhir Bayar --
                ws.Cells[1, 26].Worksheet.Column(26).Width = 15; // Tgl. JT selanjutnya --
                ws.Cells[1, 27].Worksheet.Column(27).Width = 15; // UM Diterima --
                ws.Cells[1, 28].Worksheet.Column(28).Width = 18; // Overdue 30 --
                //ws.Cells[1, 26].Worksheet.Column(26).Width = 25; // Overdue 31 60 --
                //ws.Cells[1, 27].Worksheet.Column(27).Width = 18; // Overdue 61 90 --
                //ws.Cells[1, 28].Worksheet.Column(28).Width = 18; // Overdue > 90 --
                ws.Cells[1, 29].Worksheet.Column(29).Width = 18; // TotalOverdue --
                ws.Cells[1, 30].Worksheet.Column(30).Width = 18; // Sisa Piut Pokok
                ws.Cells[1, 31].Worksheet.Column(31).Width = 18; // Sisa Piut UM

                string Title = "LAPORAN PENJUALAN KREDIT BERSALDO"; // +KorT.ToUpper();

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

               // ws.Cells[2, 1, 2, MaxCol].Merge = true;

                ws.Cells[4, 1].Value = "Penjualan          : " + string.Format("{0:dd-MM-yyyy}", txtTglJual.FromDate.Value) + " s/d " + string.Format("{0:dd-MM-yyyy}", txtTglJual.ToDate.Value);
                ws.Cells[5, 1].Value = "Bulan Berjalan  : " + string.Format("{0:dd-MM-yyyy}", txtBayar.FromDate.Value) + " s/d " + string.Format("{0:dd-MM-yyyy}",txtBayar.ToDate.Value); 
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[2, 1].Style.Font.Color.SetColor(Color.DarkSlateGray);
                ws.Cells[4, 1, 5, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 5, 4].Style.Font.Bold = true;
                ws.Cells[4, 1, 5, 4].Style.Font.Color.SetColor(Color.DarkSlateGray);
                

                #region Generate Header

                ws.Cells[startH, 1].Value = "NO.";
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

                ws.Cells[startH, 10].Value = "TGL AKHIR ANGS";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "PIUTANG POKOK";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "PIUTANG BUNGA";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "PIUTANG UM";
                ws.Cells[startH, 13, startH + 1, 13].Merge = true;

                ws.Cells[startH, 14].Value = "TEMPO";
                ws.Cells[startH, 14, startH + 1, 14].Merge = true;

                //ws.Cells[startH, 13].Value = "TOTAL PIUTANG JT";
                //ws.Cells[startH, 13, startH, 16].Merge = true;
                //ws.Cells[startH + 1, 13].Value = "< 30";
                //ws.Cells[startH + 1, 14].Value = "30 - 60";
                //ws.Cells[startH + 1, 15].Value = "61 - 90";
                //ws.Cells[startH + 1, 16].Value = "> 90";

                ws.Cells[startH, 15].Value = "BUNGA";
                ws.Cells[startH, 15, startH + 1, 15].Merge = true;

                ws.Cells[startH, 16].Value = "ANGSURAN PER BULAN";
                ws.Cells[startH, 16, startH, 18].Merge = true;
                ws.Cells[startH + 1, 16].Value = "POKOK";
                ws.Cells[startH + 1, 17].Value = "BUNGA";
                ws.Cells[startH + 1, 18].Value = "TOTAL";

                ws.Cells[startH, 19].Value = "ANGSURAN DITERIMA BULAN BERJALAN";
                ws.Cells[startH, 19, startH, 21].Merge = true;
                ws.Cells[startH + 1, 19].Value = "POKOK";
                ws.Cells[startH + 1, 20].Value = "BUNGA";
                ws.Cells[startH + 1, 21].Value = "TOTAL";



                ws.Cells[startH, 22].Value = "ANGSURAN DITERIMA KESELURUHAN";
                ws.Cells[startH, 22, startH, 24].Merge = true;
                ws.Cells[startH + 1, 22].Value = "POKOK";
                ws.Cells[startH + 1, 23].Value = "BUNGA";
                ws.Cells[startH + 1, 24].Value = "TOTAL";

                ws.Cells[startH, 25].Value = "TERAKHIR BAYAR";
                ws.Cells[startH, 25, startH + 1, 25].Merge = true;

                ws.Cells[startH, 26].Value = "JT SELANJUTNYA";
                ws.Cells[startH, 26, startH + 1, 26].Merge = true;

                ws.Cells[startH, 27].Value = "UM DITERIMA";
                ws.Cells[startH, 27, startH + 1, 27].Merge = true;

                ws.Cells[startH, 28].Value = "UMUR OVERDUE HARI";
                ws.Cells[startH, 28, startH + 1, 28].Merge = true;

                ws.Cells[startH, 29].Value = "TOTAL OVERDUE";
                ws.Cells[startH, 29, startH + 1, 29].Merge = true;

                ws.Cells[startH, 30].Value = "SISA PIUT POKOK";
                ws.Cells[startH, 30, startH+1, 30].Merge = true;

                ws.Cells[startH, 31].Value = "SISA PIUT UM";
                ws.Cells[startH, 31, startH+1, 31].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
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
                    ws.Cells[idx, 2].Value = dr["TglJual"]; 
                    ws.Cells[idx, 3].Value = dr["NoTrans"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["Nama"];
                    ws.Cells[idx, 6].Value = dr["AlamatDom"];
                    ws.Cells[idx, 7].Value = dr["AlamatIdt"];
                    ws.Cells[idx, 8].Value = dr["Nopol"];
                    ws.Cells[idx, 9].Value = dr["Type"];
                    ws.Cells[idx, 10].Value = dr["TglAkhirAngs"];
                    ws.Cells[idx, 11].Value = dr["PiutPokok"];
                    ws.Cells[idx, 12].Value = dr["PiutBunga"];
                    ws.Cells[idx, 13].Value = dr["UangMuka"];
                    ws.Cells[idx, 14].Value = dr["TempoAngs"];
                    ws.Cells[idx, 15].Value = dr["Bunga"];
                    ws.Cells[idx, 16].Value = dr["pokokperbulan"];
                    ws.Cells[idx, 17].Value = dr["bungaperbulan"];
                    ws.Cells[idx, 18].Value = dr["angsperbulan"];
                    ws.Cells[idx, 19].Value = dr["PokokPeriod"];
                    ws.Cells[idx, 20].Value = dr["BungaPeriod"];
                    ws.Cells[idx, 21].Value = dr["TotalPeriod"];
                    ws.Cells[idx, 22].Value = dr["pokokditerima"];
                    ws.Cells[idx, 23].Value = dr["bungaditerima"];
                    ws.Cells[idx, 24].Value = dr["angsditerima"];
                    ws.Cells[idx, 25].Value = dr["TglAngsAkhir"];
                    ws.Cells[idx, 26].Value = dr["TglJTNext"];
                    ws.Cells[idx, 27].Value = dr["UMditerima"];
                    ws.Cells[idx, 28].Value = dr["UmurOverdue"];
                    ws.Cells[idx, 29].Value = dr["overdue"];
                    ws.Cells[idx, 30].Value = dr["SaldoPokok"];
                    ws.Cells[idx, 31].Value = dr["SaldoUM"];
                    
                    ws.Cells[startH, 16, idx, 18].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[startH, 16, idx, 18].Style.Fill.BackgroundColor.SetColor(Color.LavenderBlush);
                    ws.Cells[startH, 19, idx, 21].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[startH, 19, idx, 21].Style.Fill.BackgroundColor.SetColor(Color.LemonChiffon);
                    ws.Cells[startH, 22, idx, 24].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[startH, 22, idx, 24].Style.Fill.BackgroundColor.SetColor(Color.Honeydew);

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.DarkTurquoise);


                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gainsboro);


                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 10].Merge = true;
                ws.Cells[idx, 1, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 2, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 2, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                ws.Cells[idx, 13].Formula = "Sum(" + ws.Cells[startH + 2, 13].Address + ":" + ws.Cells[idx - 1, 13].Address + ")";
                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 2, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";
                ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";

                ws.Cells[idx, 27].Formula = "Sum(" + ws.Cells[startH + 2, 27].Address + ":" + ws.Cells[idx - 1, 27].Address + ")";
                ws.Cells[idx, 29].Formula = "Sum(" + ws.Cells[startH + 2, 29].Address + ":" + ws.Cells[idx - 1, 29].Address + ")";
                ws.Cells[idx, 30].Formula = "Sum(" + ws.Cells[startH + 2, 30].Address + ":" + ws.Cells[idx - 1, 30].Address + ")";
                ws.Cells[idx, 31].Formula = "Sum(" + ws.Cells[startH + 2, 31].Address + ":" + ws.Cells[idx - 1, 31].Address + ")";

                ws.Cells[startH + 2, 11, idx, 13].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 14, idx, 14].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 2, 15, idx, 23].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 24, idx, 24].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 25, idx, 25].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 2, 29, idx, 31].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 25, idx - 1, 26].Style.Numberformat.Format = "dd-MMM-yyyy";

                // No.
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 2, idx - 1, 4].Style.WrapText = true;
                
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 5, idx - 1, 9].Style.WrapText = true;
           
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 10, idx - 1, 10].Style.WrapText = true;

                //ws.Cells[startH + 2, 16, idx - 1, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                //ws.Cells[startH + 2, 16, idx - 1, 18].Style.WrapText = true;

                //ws.Cells[startH + 2, 19, idx - 1, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                //ws.Cells[startH + 2, 19, idx - 1, 20].Style.WrapText = true;
             
                ws.Cells[startH + 2, 11, idx - 1, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 11, idx - 1, 21].Style.WrapText = true;

                ws.Cells[startH + 2, 28, idx - 1, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 28, idx - 1, 28].Style.WrapText = true;
                ws.Cells[startH + 2, 28, idx, 28].Style.Numberformat.Format = "#,##";

               ws.Cells[startH + 2, 29, idx - 1, 29].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 29, idx - 1, 29].Style.WrapText = true;

               
                ws.Cells[startH + 2, 27, idx - 1, 31].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 27, idx - 1, 31].Style.WrapText = true;
                ws.Cells[startH + 2, 27, idx, 31].Style.Numberformat.Format = "#,##0.00";

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd - MMM - yyyy HH:mm:ss");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Penjualan Kredit Bersaldo "; // +KorT;
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
                sf.FileName = GlobalVar.CabangID + "_Laporan_Piutang_Kredit_Bersaldo_" + txtTglJual.FromDate.Value.ToString("dd-MM-yyy")+"sd"+ txtTglJual.ToDate.Value.ToString("dd-MM-yyy") + ".xlsx";

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


        private void DisplayReport(DataTable dt)
        {
            string _userid = "Created by " + SecurityManager.UserID + " on " + GlobalVar.GetServerDateTime;
            List<ReportParameter> rptParams = new List<ReportParameter>();


            rptParams.Add(new ReportParameter("fromDate", txtTglJual.FromDate.Value.ToString("dd-MM-yyyy")));
            rptParams.Add(new ReportParameter("toDate", txtTglJual.ToDate.Value.ToString("dd-MM-yyyy")));
            rptParams.Add(new ReportParameter("userid", _userid));
            rptParams.Add(new ReportParameter("cabang", GlobalVar.CabangID.ToString()));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptPiutangSaldo.rdlc", rptParams, dt, "dsPiutangSaldo_Data");
            ifrmReport.Show();
        }

        private void frmLapPiutangSaldo_Load(object sender, EventArgs e)
        {
            DateTime value = new DateTime(2000, 1, 1);
            txtTglJual.FromDate = value;
            txtTglJual.ToDate = GlobalVar.GetServerDate;

            txtBayar.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            txtBayar.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
