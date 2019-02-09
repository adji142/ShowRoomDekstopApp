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
    public partial class frmLapStock : ISA.Controls.BaseForm
    {
        string Kondisi;

        public frmLapStock()
        {
            InitializeComponent();
        }

        private void frmLapStock_Load(object sender, EventArgs e)
        {
            txtTanggal.DateValue = GlobalVar.GetServerDate;
            rbBaru.Checked = true;
            if (GlobalVar.CabangID.Contains("06A"))
            {
                rbTerima.Checked = true;
            }
            else
            {
                rbBeli.Checked = true;
            }
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
                p.Workbook.Properties.Title = "LAPORAN STOCK KENDARAAN";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 12;
                int startH = 8;

                if (rbBaru.Checked) { Kondisi = "Baru"; }
                else if (rbBekas.Checked) { Kondisi = "Bekas"; }
                else { Kondisi = "Semua"; }

                ws.Cells[1, 1].Worksheet.Column(1).Width = 6;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 9;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 23;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 8;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 19;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 19;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 11;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 15;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 17;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 12;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 19;

                string Title = "LAPORAN STOCK KENDARAAN";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;                
                ws.Cells[4, 1].Value = "Cabang  : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 3].Merge = true;
                ws.Cells[4, 1, 4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Kondisi  : " + Kondisi;
                ws.Cells[5, 1, 5, 3].Merge = true;
                ws.Cells[5, 1, 5, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1].Value = "Periode : " + string.Format("{0:dd-MM-yyyy}", txtTanggal.DateValue);
                ws.Cells[6, 1, 6, 3].Merge = true;
                ws.Cells[6, 1, 6, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 6, 3].Style.Font.Size = 12;
                ws.Cells[4, 1, 6, 3].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "NO.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;
                ws.Cells[startH, 2].Value = "NO. STOCK";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;
                ws.Cells[startH, 3].Value = "DATA KENDARAAN";
                ws.Cells[startH, 3, startH, 7].Merge = true;
                ws.Cells[startH + 1, 3].Value = "MERK / TYPE";
                ws.Cells[startH + 1, 4].Value = "TAHUN";
                ws.Cells[startH + 1, 5].Value = "NO. RANGKA";
                ws.Cells[startH + 1, 6].Value = "NO. MESIN";
                ws.Cells[startH + 1, 7].Value = "NO. POLISI";
                ws.Cells[startH, 8].Value = "HARGA BELI";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;
                ws.Cells[startH, 9].Value = "BIAYA LAIN - LAIN";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;
                ws.Cells[startH, 10].Value = "HARGA BELI + BIAYA LAIN - LAIN";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;
                ws.Cells[startH, 10, startH + 1, 10].Style.WrapText = true;
                ws.Cells[startH, 11].Value = "TGL. BELI";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;
                ws.Cells[startH, 12].Value = "KELENGKAPAN";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;


                #endregion

                #region FillData
                int idx = startH + 2;

                foreach (DataRow dr in dt.Rows)
                {
                    ws.Row(idx).Height = 30;
                    ws.Cells[idx, 1].Value = dr["Nomor"];
                    ws.Cells[idx, 2].Value = dr["NoStock"];
                    ws.Cells[idx, 3].Value = dr["MerkType"];
                    ws.Cells[idx, 4].Value = dr["Tahun"];
                    ws.Cells[idx, 5].Value = dr["NoRangka"];
                    ws.Cells[idx, 6].Value = dr["NoMesin"];
                    ws.Cells[idx, 7].Value = dr["Nopol"];
                    ws.Cells[idx, 8].Value = dr["HargaJadi"];
                    ws.Cells[idx, 9].Value = dr["REPTAM"];
                    ws.Cells[idx, 10].Value = dr["HargaOff"];
                    ws.Cells[idx, 11].Value = dr["TglBeli"];
                    ws.Cells[idx, 12].Value = dr["Kelengkapan"];
                    ws.Cells[idx, 12].Style.WrapText = true;
                    ws.Cells[idx, 1, idx, 12].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 7].Merge = true;
                ws.Cells[idx, 1, idx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;
                
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 2, 8].Address +
                           ":" + ws.Cells[idx - 1, 8].Address + ")";

                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 2, 9].Address +
                           ":" + ws.Cells[idx - 1, 9].Address + ")";

                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 2, 10].Address +
                           ":" + ws.Cells[idx - 1, 10].Address + ")";

                ws.Cells[startH + 2, 8, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 11, idx - 1, 11].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 2, 1, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 1, idx - 1, 2].Style.WrapText = true;
                ws.Cells[startH + 2, 4, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 4, idx - 1, 4].Style.WrapText = true;
                ws.Cells[startH + 2, 7, idx - 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 7, idx - 1, 7].Style.WrapText = true;
                ws.Cells[startH + 2, 8, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 8, idx - 1, 10].Style.WrapText = true;
                ws.Cells[startH + 2, 11, idx - 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 12, idx - 1, 12].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Stock Kendaraan";
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
                sf.FileName = "Laporan Stock Kendaraan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

                if (rbBaru.Checked) { Kondisi = "Baru"; }
                else if (rbBekas.Checked) { Kondisi = "Bekas"; }
                else { Kondisi = ""; }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LapStock]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                    if (!String.IsNullOrEmpty(Kondisi))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, Kondisi));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    if(rbBeli.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FilterBy", SqlDbType.Int, 1)); 
                    }
                    else if (rbTerima.Checked)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FilterBy", SqlDbType.Int, 2));
                    }
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

        private void rbBeli_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbTerima_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
