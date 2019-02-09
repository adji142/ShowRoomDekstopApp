using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapMutasiPiutang : ISA.Controls.BaseForm
    {
        public frmLapMutasiPiutang()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLapMutasiPiutang_Load(object sender, EventArgs e)
        {
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tempDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, DateTime.DaysInMonth(monthYearBox1.Year, monthYearBox1.Month) );
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_LaporanMutasiPiutang"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAkhir", SqlDbType.Date, tempDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
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
            DateTime tempDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, DateTime.DaysInMonth(monthYearBox1.Year, monthYearBox1.Month));
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN MUTASI PIUTANG";

                p.Workbook.Worksheets.Add("MutasiPiutang");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Mutasi Piutang"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 25;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width =  7; // No
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // A/R - NoTrans
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 15; // NoFaktur - NoBukti
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 25; // Customer - NamaCustomer
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 15; // NoPol
                ws.Cells[1,  6].Worksheet.Column( 6).Width = 18; // Saldo Awal - Pokok
                ws.Cells[1,  7].Worksheet.Column( 7).Width = 18; // Saldo Awal - Bunga
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 18; // Saldo Awal - UM
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 18; // Mutasi Debet - Pokok
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // Mutasi Debet - Bunga
                ws.Cells[1, 11].Worksheet.Column(11).Width = 18; // Mutasi Debet - UM
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Mutasi Kredit - Pokok
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Mutasi Kredit - Bunga
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // Mutasi Kredit - UM
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // Saldo Akhir - Pokok
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // Saldo Akhir - Bunga
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // Saldo Akhir - UM
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Saldo Piutang
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // Saldo PiutangDanUM
                // tambahan
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // Saldo Awal - TTP
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // Saldo Debet - TTP
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18; // Saldo Kredit - TTP
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18; // Saldo Akhir - TTP
                ws.Cells[1, 24].Worksheet.Column(24).Width = 18; // Terima Denda Bulan ini
                ws.Cells[1, 25].Worksheet.Column(25).Width = 18; // Terima Denda Akumulasi

                string Title = "LAPORAN MUTASI PIUTANG";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Periode      : " + string.Format("{0:MM-yyyy}", tempDate);
                ws.Cells[4, 1, 5, 4].Merge = true;
                ws.Cells[4, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 4, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 4, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "A/R";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "NO. FAKTUR";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NAMA PELANGGAN";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "NOMOR POLISI";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                // Bagian SALDO AWAL
                ws.Cells[startH, 6].Value = "SALDO AWAL";
                ws.Cells[startH, 6, startH, 8].Merge = true;

                ws.Cells[startH + 1, 6].Value = "POKOK";
                ws.Cells[startH + 1, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH + 1, 7].Value = "BUNGA";
                ws.Cells[startH + 1, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH + 1, 8].Value = "UANG MUKA";
                ws.Cells[startH + 1, 8, startH + 1, 8].Merge = true;

                // Bagian MUTASI DEBET
                ws.Cells[startH, 9].Value = "MUTASI DEBET";
                ws.Cells[startH, 9, startH, 11].Merge = true;

                ws.Cells[startH + 1, 9].Value = "POKOK";
                ws.Cells[startH + 1, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH + 1, 10].Value = "BUNGA";
                ws.Cells[startH + 1, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH + 1, 11].Value = "UANG MUKA";
                ws.Cells[startH + 1, 11, startH + 1, 11].Merge = true;

                // Bagian MUTASI KREDIT
                ws.Cells[startH, 12].Value = "MUTASI KREDIT";
                ws.Cells[startH, 12, startH, 14].Merge = true;

                ws.Cells[startH + 1, 12].Value = "POKOK";
                ws.Cells[startH + 1, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH + 1, 13].Value = "BUNGA";
                ws.Cells[startH + 1, 13, startH + 1, 13].Merge = true;

                ws.Cells[startH + 1, 14].Value = "UANG MUKA";
                ws.Cells[startH + 1, 14, startH + 1, 14].Merge = true;

                // Bagian SALDO AKHIR
                ws.Cells[startH, 15].Value = "SALDO AKHIR";
                ws.Cells[startH, 15, startH, 17].Merge = true;

                ws.Cells[startH + 1, 15].Value = "POKOK";
                ws.Cells[startH + 1, 15, startH + 1, 15].Merge = true;

                ws.Cells[startH + 1, 16].Value = "BUNGA";
                ws.Cells[startH + 1, 16, startH + 1, 16].Merge = true;

                ws.Cells[startH + 1, 17].Value = "UANG MUKA";
                ws.Cells[startH + 1, 17, startH + 1, 17].Merge = true;

                // Bagian SALDO AKHIR
                ws.Cells[startH, 18].Value = "SALDO PIUTANG";
                ws.Cells[startH, 18, startH + 1, 18].Merge = true;

                ws.Cells[startH, 19].Value = "SALDO PIUTANG+UM";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                // Bagian TITIPAN
                ws.Cells[startH, 20].Value = "TITIPAN";
                ws.Cells[startH, 20, startH, 23].Merge = true;

                ws.Cells[startH + 1, 20].Value = "AWAL";
                ws.Cells[startH + 1, 20, startH + 1, 20].Merge = true;

                ws.Cells[startH + 1, 21].Value = "DEBET";
                ws.Cells[startH + 1, 21, startH + 1, 21].Merge = true;

                ws.Cells[startH + 1, 22].Value = "KREDIT";
                ws.Cells[startH + 1, 22, startH + 1, 22].Merge = true;

                ws.Cells[startH + 1, 23].Value = "AKHIR";
                ws.Cells[startH + 1, 23, startH + 1, 23].Merge = true;

                // BAGIAN DENDA
                ws.Cells[startH, 24].Value = "DENDA BLN BERJALAN";
                ws.Cells[startH, 24, startH + 1, 24].Merge = true;

                ws.Cells[startH, 25].Value = "DENDA AKUMULASI";
                ws.Cells[startH, 25, startH + 1, 25].Merge = true;

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
                    ws.Cells[idx,  2].Value = dr["NoTransPJL"]; // ada PenjHistRowID abis ini tapi ngga dimunculin
                    ws.Cells[idx,  3].Value = dr["NoBuktiPJL"];
                    ws.Cells[idx,  4].Value = dr["NamaCustomer"];
                    ws.Cells[idx,  5].Value = dr["NoPol"];
                    ws.Cells[idx,  6].Value = Tools.isNull(dr["PiutangPokok"], 0);
                    ws.Cells[idx,  7].Value = Tools.isNull(dr["PiutangBunga"], 0);
                    ws.Cells[idx,  8].Value = Tools.isNull(dr["PiutangUM"], 0);
                    ws.Cells[idx,  9].Value = Tools.isNull(dr["DebetPokok"], 0);
                    ws.Cells[idx, 10].Value = Tools.isNull(dr["DebetBunga"], 0);
                    ws.Cells[idx, 11].Value = Tools.isNull(dr["DebetUM"], 0);
                    ws.Cells[idx, 12].Value = Tools.isNull(dr["KreditPokok"], 0);
                    ws.Cells[idx, 13].Value = Tools.isNull(dr["KreditBunga"], 0);
                    ws.Cells[idx, 14].Value = Tools.isNull(dr["KreditUM"], 0);
                    ws.Cells[idx, 15].Value = Tools.isNull(dr["SaldoAkhirPokok"], 0);
                    ws.Cells[idx, 16].Value = Tools.isNull(dr["SaldoAkhirBunga"], 0);
                    ws.Cells[idx, 17].Value = Tools.isNull(dr["SaldoAkhirUM"], 0);
                    ws.Cells[idx, 18].Value = Tools.isNull(dr["SaldoPiutang"], 0);
                    ws.Cells[idx, 19].Value = Tools.isNull(dr["SaldoPiutangDanUM"], 0);
                    ws.Cells[idx, 20].Value = Tools.isNull(dr["SaldoAwalTTP"], 0);
                    ws.Cells[idx, 21].Value = Tools.isNull(dr["DebetTTP"], 0);
                    ws.Cells[idx, 22].Value = Tools.isNull(dr["KreditTTP"], 0);
                    ws.Cells[idx, 23].Value = Tools.isNull(dr["SaldoAkhirTTP"], 0);
                    ws.Cells[idx, 24].Value = Tools.isNull(dr["DendaBerjalan"], 0);
                    ws.Cells[idx, 25].Value = Tools.isNull(dr["DendaAkum"], 0);
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 5].Merge = true;
                ws.Cells[idx, 1, idx, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx,  6].Formula = "Sum(" + ws.Cells[startH + 2,  6].Address + ":" + ws.Cells[idx - 1,  6].Address + ")";
                ws.Cells[idx,  7].Formula = "Sum(" + ws.Cells[startH + 2,  7].Address + ":" + ws.Cells[idx - 1,  7].Address + ")";
                ws.Cells[idx,  8].Formula = "Sum(" + ws.Cells[startH + 2,  8].Address + ":" + ws.Cells[idx - 1,  8].Address + ")";
                ws.Cells[idx,  9].Formula = "Sum(" + ws.Cells[startH + 2,  9].Address + ":" + ws.Cells[idx - 1,  9].Address + ")";
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
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 2, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 2, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";
                ws.Cells[idx, 24].Formula = "Sum(" + ws.Cells[startH + 2, 24].Address + ":" + ws.Cells[idx - 1, 24].Address + ")";
                ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 2, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";

                // Nama Daerah Nopol Tipe
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                ws.Cells[startH + 2, 2, idx - 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 2, idx - 1, 5].Style.WrapText = true;

                ws.Cells[startH + 2, 6, idx, 25].Style.Numberformat.Format = "#,##0.00;(#,##0.00);-";
                ws.Cells[startH + 2, 6, idx - 1, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 6, idx - 1, 25].Style.WrapText = true;

                if (rbSimple.Checked == true)
                {
                    ws.Column(20).Style.Hidden = true; // Saldo Awal - TTP
                    ws.Column(21).Style.Hidden = true; // Saldo Debet - TTP
                    ws.Column(22).Style.Hidden = true; // Saldo Kredit - TTP
                    ws.Column(23).Style.Hidden = true; // Saldo Akhir - TTP
                    ws.Column(24).Style.Hidden = true; // Terima Denda Bulan ini
                    ws.Column(25).Style.Hidden = true; // Terima Denda Akumulasi

                    ws.Column(20).Hidden = true; // Saldo Awal - TTP
                    ws.Column(21).Hidden = true; // Saldo Debet - TTP
                    ws.Column(22).Hidden = true; // Saldo Kredit - TTP
                    ws.Column(23).Hidden = true; // Saldo Akhir - TTP
                    ws.Column(24).Hidden = true; // Terima Denda Bulan ini
                    ws.Column(25).Hidden = true; // Terima Denda Akumulasi
                }

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Mutasi Piutang";
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
                sf.FileName = "Laporan Mutasi Piutang " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void rbSimple_CheckedChanged(object sender, EventArgs e)
        {
            urusMode();
        }

        private void rbDetailed_CheckedChanged(object sender, EventArgs e)
        {
            urusMode();
        }

        private void urusMode()
        {
            if (rbSimple.Checked == true)
            {
                rbDetailed.Checked = false;
                rbSimple.Checked = true;
            }
            else if (rbDetailed.Checked == true)
            {
                rbDetailed.Checked = true;
                rbSimple.Checked = false;
            }
        }
    }
}
