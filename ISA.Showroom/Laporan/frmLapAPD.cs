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
    public partial class frmLapAPD : ISA.Controls.BaseForm
    {
        public frmLapAPD()
        {
            InitializeComponent();
        }

        private void frmLapAPD_Load(object sender, EventArgs e)
        {
            txtTanggal.DateValue = GlobalVar.GetServerDate;
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
                p.Workbook.Properties.Title = "LAPORAN ANALISA PIUTANG DAGANG";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 11;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 10;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 21;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 13;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 13;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 17;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 17;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 17;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 9;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 17;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 17;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 20;

                string Title = "LAPORAN ANALISA PIUTANG DAGANG";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;                
                ws.Cells[4, 1].Value = "Cabang  : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 3].Merge = true;
                ws.Cells[4, 1, 4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode : " + string.Format("{0:dd-MM-yyyy}", txtTanggal.DateValue);
                ws.Cells[5, 1, 5, 3].Merge = true;
                ws.Cells[5, 1, 5, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 5, 3].Style.Font.Size = 12;
                ws.Cells[4, 1, 5, 3].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "NO. A/R";
                ws.Cells[startH, 2].Value = "NAMA CUSTOMER";
                ws.Cells[startH, 3].Value = "TGL. TRANSAKSI";
                ws.Cells[startH, 4].Value = "BAYAR AKHIR";
                ws.Cells[startH, 5].Value = "PIUTANG AWAL";
                ws.Cells[startH, 6].Value = "ANGSURAN POKOK";
                ws.Cells[startH, 7].Value = "SALDO REAL";
                ws.Cells[startH, 8].Value = "%";
                ws.Cells[startH, 9].Value = "PENDAPATAN BUNGA";
                ws.Cells[startH, 10].Value = "LABA REAL";
                ws.Cells[startH, 11].Value = "KOLEKTOR";

                ws.Cells[startH, 1, startH, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH, MaxCol].Style.WrapText = true;

                #endregion

                #region FillData
                int idx = startH + 1;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["NoAR"];
                    ws.Cells[idx, 2].Value = dr["NamaCustomer"];
                    ws.Cells[idx, 3].Value = dr["TglTrans"];
                    ws.Cells[idx, 4].Value = dr["ByrAkhir"];
                    ws.Cells[idx, 5].Value = dr["PiutangAwal"];
                    ws.Cells[idx, 6].Value = dr["AngsPokok"];
                    ws.Cells[idx, 7].Value = dr["SaldoReal"];
                    ws.Cells[idx, 8].Value = dr["Prosen"];
                    ws.Cells[idx, 9].Value = dr["PendBunga"];
                    ws.Cells[idx, 10].Value = dr["LabaReal"];
                    ws.Cells[idx, 11].Value = dr["Kolektor"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 1, 5].Address +
                           ":" + ws.Cells[idx - 1, 5].Address + ")";

                ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 1, 6].Address +
                           ":" + ws.Cells[idx - 1, 6].Address + ")";

                ws.Cells[idx, 7].Formula = "Sum(" + ws.Cells[startH + 1, 7].Address +
                           ":" + ws.Cells[idx - 1, 7].Address + ")";

                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 1, 9].Address +
                           ":" + ws.Cells[idx - 1, 9].Address + ")";

                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 1, 10].Address +
                           ":" + ws.Cells[idx - 1, 10].Address + ")";

                ws.Cells[startH + 1, 5, idx, 7].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 1, 8, idx - 1, 8].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 1, 9, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 1, 3, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 1, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 1, idx - 1, 1].Style.WrapText = true;
                ws.Cells[startH + 1, 2, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 2, idx - 1, 2].Style.WrapText = true;
                ws.Cells[startH + 1, 3, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 3, idx - 1, 4].Style.WrapText = true;
                ws.Cells[startH + 1, 5, idx - 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 5, idx - 1, 7].Style.WrapText = true;
                ws.Cells[startH + 1, 8, idx - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 8, idx - 1, 8].Style.WrapText = true;
                ws.Cells[startH + 1, 9, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 9, idx - 1, 10].Style.WrapText = true;
                ws.Cells[startH + 1, 11, idx - 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 11, idx - 1, 11].Style.WrapText = true;
                ws.Cells[startH + 1, 1, idx - 1, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Analisa Piutang Dagang";
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
                sf.FileName = "Laporan Analisa Piutang Dagang " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
            if (string.IsNullOrEmpty(txtTanggal.Text))
            {
                MessageBox.Show("Tanggal belum diisi !");
                txtTanggal.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LapAnalisaPiutangDagang]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
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
