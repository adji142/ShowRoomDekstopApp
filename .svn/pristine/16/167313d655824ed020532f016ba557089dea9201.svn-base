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
    public partial class frmLapBPKB : ISA.Controls.BaseForm
    {
        public frmLapBPKB()
        {
            InitializeComponent();
        }

        private void frmLapBPKB_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateExcel(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN JAMINAN BPKB";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 12;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 7;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 10;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 21;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 15;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 17;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 8;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 12;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 8;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 20;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 21;

                string Title = "LAPORAN JAMINAN BPKB";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;                
                ws.Cells[4, 1].Value = "Cabang  : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate);
                ws.Cells[5, 1, 5, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 5, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 5, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 2].Value = "NO. A/R";                
                ws.Cells[startH, 3].Value = "NO. FAKTUR";
                ws.Cells[startH, 4].Value = "TGL. TRANSAKSI";
                ws.Cells[startH, 5].Value = "NAMA CUSTOMER";
                ws.Cells[startH, 6].Value = "MERK";
                ws.Cells[startH, 7].Value = "TYPE";
                ws.Cells[startH, 8].Value = "TAHUN";
                ws.Cells[startH, 9].Value = "NOMOR POLISI";
                ws.Cells[startH, 10].Value = "KONDISI";
                ws.Cells[startH, 11].Value = "NOMOR BPKB";
                ws.Cells[startH, 12].Value = "ATAS NAMA BPKB";

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
                    ws.Cells[idx, 2].Value = dr["NoAR"];
                    ws.Cells[idx, 3].Value = dr["NoFaktur"];
                    ws.Cells[idx, 4].Value = dr["TglTrans"];
                    ws.Cells[idx, 5].Value = dr["NamaCustomer"];
                    ws.Cells[idx, 6].Value = dr["MerkMotor"];
                    ws.Cells[idx, 7].Value = dr["TypeMotor"];
                    ws.Cells[idx, 8].Value = dr["Tahun"];
                    ws.Cells[idx, 9].Value = dr["Nopol"];
                    ws.Cells[idx, 10].Value = dr["Kondisi"];
                    ws.Cells[idx, 11].Value = dr["NoBPKB"];
                    ws.Cells[idx, 12].Value = dr["NamaBPKB"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);              

                ws.Cells[startH + 1, 4, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 1, 1, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 1, idx - 1, 4].Style.WrapText = true;
                ws.Cells[startH + 1, 5, idx - 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 5, idx - 1, 7].Style.WrapText = true;
                ws.Cells[startH + 1, 8, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 8, idx - 1, 10].Style.WrapText = true;
                ws.Cells[startH + 1, 11, idx - 1, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 11, idx - 1, 12].Style.WrapText = true;
                ws.Cells[startH + 1, 1, idx - 1, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Jaminan BPKB";
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
                sf.FileName = "Laporan Jaminan BPKB " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
                    db.Commands.Add(db.CreateCommand("[rsp_LapJaminanBPKB]"));
                    db.Commands[0].Parameters.Add(new Parameter("@From", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@To", SqlDbType.Date, rangeDateBox1.ToDate));
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
    }
}
