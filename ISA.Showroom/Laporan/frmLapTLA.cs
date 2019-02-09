using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class frmLapTLA : ISA.Controls.BaseForm
    {
        public frmLapTLA()
        {
            InitializeComponent();
        }

        private void frmLapTLA_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month, 1);
            rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month, DateTime.DaysInMonth(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month));
            txtTahun.Text = GlobalVar.GetServerDate.Date.Year.ToString();
            cbLaporan.SelectedIndex = 0;
        }

        private void cbLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLaporan.SelectedIndex == 0)
            {
                // ini yg laporan salesman
                lblTahun.Visible = false;
                txtTahun.Visible = false;
                txtTahun.Text = GlobalVar.GetServerDate.Date.Year.ToString();
                lblPeriode.Visible = true;
                rangeDateBox1.Visible = true;
            }
            else if (cbLaporan.SelectedIndex == 1)
            {
                // ini yg laporan penjualan tahunan - tipe
                lblTahun.Visible = true;
                txtTahun.Visible = true;
                lblPeriode.Visible = false;
                rangeDateBox1.Visible = false;
                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month, 1);
                rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month + 1, 1).AddDays(-1);
            }
            else if (cbLaporan.SelectedIndex == 2)
            {
                // ini yg laporan penjualan tahunan - kecamatan
                lblTahun.Visible = true;
                txtTahun.Visible = true;
                lblPeriode.Visible = false;
                rangeDateBox1.Visible = false;
                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month, 1);
                rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Date.Year, GlobalVar.GetServerDate.Date.Month + 1, 1).AddDays(-1);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (cbLaporan.SelectedIndex == 1 || cbLaporan.SelectedIndex == 2)
            {
                if (txtTahun.GetIntValue > DateTime.MaxValue.Year || txtTahun.GetIntValue < DateTime.MinValue.Year)
                {
                    txtTahun.Text = GlobalVar.GetServerDate.Date.Year.ToString();
                    MessageBox.Show("Tahun yg diinputkan tidak valid !");
                    return;
                }
            }
            else if (cbLaporan.SelectedIndex == 0)
            {
                if (rangeDateBox1.FromDate > rangeDateBox1.ToDate)
                {
                    DateTime temp = rangeDateBox1.FromDate.Value.Date;
                    rangeDateBox1.FromDate = rangeDateBox1.ToDate;
                    rangeDateBox1.ToDate = temp;
                }
            }
            else
            {
                MessageBox.Show("Pilih Jenis laporan terlebih dahulu !");
                return;
            }

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                if (cbLaporan.SelectedIndex == 0) // yg Tipe
                {
                    db.Commands.Add(db.CreateCommand("rpt_LapPenjualan_BySales_Monthly"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                }
                else if (cbLaporan.SelectedIndex == 1)
                {
                    db.Commands.Add(db.CreateCommand("rpt_LapPenjualan_ByType_Annual"));
                    db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, txtTahun.GetIntValue));
                }
                else if (cbLaporan.SelectedIndex == 2) // Laporan
                {
                    db.Commands.Add(db.CreateCommand("rpt_LapPenjualan_ByKecamatan_Annual"));
                    db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, txtTahun.GetIntValue));
                }
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (cbLaporan.SelectedIndex == 0) // yg Laporan Salesman
                {
                    LaporanSalesman(dt);
                }
                else if (cbLaporan.SelectedIndex == 1) // yg Tipe
                {
                    PrintLaporanType(dt);
                }
                else if (cbLaporan.SelectedIndex == 2) // yg Kecamatan
                {
                    PrintLaporanKecamatan(dt);
                }
            }
            else
            {
                MessageBox.Show("Tidak ada data untuk ditampilkan!");
            }
        }

        private void LaporanSalesman(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PENJUALAN SALES";

                p.Workbook.Worksheets.Add("PjlSales");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "PjlSales"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 16;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 6;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 30;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 15;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 15;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 15;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 15;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 15;
                ws.Cells[1, 15].Worksheet.Column(15).Width = 15;
                ws.Cells[1, 16].Worksheet.Column(16).Width = 15;

                string Title = "LAPORAN PENJUALAN SALES";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate.Value) + " - " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate.Value);
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
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;
                ws.Cells[startH, 2].Value = "NAMA SALES";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "TOTAL JUAL";
                ws.Cells[startH, 3, startH, 4].Merge = true;
                ws.Cells[startH + 1, 3].Value = "AUTOMATIC";
                ws.Cells[startH + 1, 4].Value = "MANUAL";

                ws.Cells[startH, 5].Value = "JUMLAH";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "OMSET JUAL";
                ws.Cells[startH, 6, startH, 15].Merge = true;
                ws.Cells[startH + 1, 6].Value = "CASH";
                ws.Cells[startH + 1, 7].Value = "AVALIS";
                ws.Cells[startH + 1, 8].Value = "CASH+AVALIS";

                ws.Cells[startH + 1, 9].Value = "WOM";
                ws.Cells[startH + 1, 10].Value = "MPMF";
                ws.Cells[startH + 1, 11].Value = "RADANA";
                ws.Cells[startH + 1, 12].Value = "SOF";
                ws.Cells[startH + 1, 13].Value = "ADIRA";
                ws.Cells[startH + 1, 14].Value = "FIF";
                ws.Cells[startH + 1, 15].Value = "LEASING";

                ws.Cells[startH, 16].Value = "JUMLAH OMSET";
                ws.Cells[startH, 16, startH + 1, 16].Merge = true;

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
                    ws.Cells[idx, 2].Value = dr["Nama"];
                    ws.Cells[idx, 3].Value = dr["QtyAutomatic"];
                    ws.Cells[idx, 4].Value = dr["QtyManual"];
                    ws.Cells[idx, 5].Value = dr["QtyTranmisi"];
                    ws.Cells[idx, 6].Value = dr["QtyCash"];
                    ws.Cells[idx, 7].Value = dr["QtyKredit"];
                    ws.Cells[idx, 8].Value = dr["QtyCK"];
                    ws.Cells[idx, 9].Value = dr["QtyWOM"];
                    ws.Cells[idx, 10].Value = dr["QtyMPMF"];
                    ws.Cells[idx, 11].Value = dr["QtyRADANA"];
                    ws.Cells[idx, 12].Value = dr["QtySOF"];
                    ws.Cells[idx, 13].Value = dr["QtyADIRA"];
                    ws.Cells[idx, 14].Value = dr["QtyFIF"];
                    ws.Cells[idx, 15].Value = dr["QtyLSG"];
                    ws.Cells[idx, 16].Value = dr["QtyPJL"];


                    //ws.Cells[idx, 9].Value = dr["QtyFIF"];
                    //ws.Cells[idx, 10].Value = dr["QtyMPMF"];
                    //ws.Cells[idx, 11].Value = dr["QtySOF"];
                    //ws.Cells[idx, 12].Value = dr["QtyADIRA"];
                    //ws.Cells[idx, 13].Value = dr["QtyRADANA"];
                    //ws.Cells[idx, 14].Value = dr["QtyWOM"];
                    //ws.Cells[idx, 15].Value = dr["QtyLSG"];
                    //ws.Cells[idx, 16].Value = dr["QtyPJL"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 2].Merge = true;
                ws.Cells[idx, 1, idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

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

                ws.Cells[startH + 2, 3, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 2, 3, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 3, idx, MaxCol].Style.WrapText = true;
                /*
                ws.Cells[startH + 2, 8, idx - 1, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH + 2, 8, idx - 1, 8].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

                ws.Cells[startH + 2, 15, idx - 1, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH + 2, 15, idx - 1, 15].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                */
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : LAPORAN PENJUALAN SALES";
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
                sf.FileName = "Laporan Penjualan Sales " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void PrintLaporanKecamatan(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PENJUALAN TAHUNAN PER KECAMATAN";

                p.Workbook.Worksheets.Add("PjlKecAnn");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "PjlKecAnn"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 14;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 6;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 30;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 15;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 15;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 15;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 15;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 15;

                string Title = "LAPORAN PENJUALAN TAHUNAN PER KECAMATAN";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Tahun       : " + txtTahun.Text;
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
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;
                ws.Cells[startH, 2].Value = "NAMA Kelurahan";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "PENCAPAIAN OMSET";
                ws.Cells[startH, 3, startH, 14].Merge = true;
                ws.Cells[startH + 1, 3].Value = "JAN";
                ws.Cells[startH + 1, 4].Value = "PEB";
                ws.Cells[startH + 1, 5].Value = "MRT";
                ws.Cells[startH + 1, 6].Value = "APR";
                ws.Cells[startH + 1, 7].Value = "MEI";
                ws.Cells[startH + 1, 8].Value = "JUN";
                ws.Cells[startH + 1, 9].Value = "JUL";
                ws.Cells[startH + 1, 10].Value = "AGS";
                ws.Cells[startH + 1, 11].Value = "SEP";
                ws.Cells[startH + 1, 12].Value = "OKT";
                ws.Cells[startH + 1, 13].Value = "NOV";
                ws.Cells[startH + 1, 14].Value = "DES";

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region FillData
                int idx = startH + 2;
                int no = 1;
                String tempKec = "ZZZZZZZZZZZZZZZZZZZZZ";
                foreach (DataRow dr in dt.Rows)
                {
                    if (tempKec != Tools.isNull(dr["Kecamatan"], "").ToString())
                    {
                        tempKec = Tools.isNull(dr["Kecamatan"], "").ToString();
                        ws.Cells[idx, 1].Value = dr["Kecamatan"];
                        ws.Cells[idx, 1, idx, 14].Merge = true;
                        ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                        ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                        idx++;
                    }
                    ws.Cells[idx, 1].Value = no++;
                    ws.Cells[idx, 2].Value = dr["Kelurahan"];
                    ws.Cells[idx, 3].Value = dr["JAN"];
                    ws.Cells[idx, 4].Value = dr["PEB"];
                    ws.Cells[idx, 5].Value = dr["MRT"];
                    ws.Cells[idx, 6].Value = dr["APR"];
                    ws.Cells[idx, 7].Value = dr["MEI"];
                    ws.Cells[idx, 8].Value = dr["JUN"];
                    ws.Cells[idx, 9].Value = dr["JUL"];
                    ws.Cells[idx, 10].Value = dr["AGS"];
                    ws.Cells[idx, 11].Value = dr["SEP"];
                    ws.Cells[idx, 12].Value = dr["OKT"];
                    ws.Cells[idx, 13].Value = dr["NOV"];
                    ws.Cells[idx, 14].Value = dr["DES"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 2].Merge = true;
                ws.Cells[idx, 1, idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

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

                ws.Cells[startH + 2, 3, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 2, 3, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 3, idx, MaxCol].Style.WrapText = true;

                ws.Cells[startH + 2, 2, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.WrapText = true;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : LAPORAN PENJUALAN TAHUNAN PER KECAMATAN";
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
                sf.FileName = "Laporan Penjualan Tahunan per Kecamatan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void PrintLaporanType(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PENJUALAN TAHUNAN PER TIPE MOTOR";

                p.Workbook.Worksheets.Add("PjlTypeAnn");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "PjlTypeAnn"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 14;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 6;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 30;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 15;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 15;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 15;
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15;
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15;
                ws.Cells[1, 9].Worksheet.Column(9).Width = 15;
                ws.Cells[1, 10].Worksheet.Column(10).Width = 15;
                ws.Cells[1, 11].Worksheet.Column(11).Width = 15;
                ws.Cells[1, 12].Worksheet.Column(12).Width = 15;
                ws.Cells[1, 13].Worksheet.Column(13).Width = 15;
                ws.Cells[1, 14].Worksheet.Column(14).Width = 15;

                string Title = "LAPORAN PENJUALAN TAHUNAN PER TIPE MOTOR";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Tahun       : " + txtTahun.Text;
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
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;
                ws.Cells[startH, 2].Value = "NAMA TIPE MOTOR";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "PENCAPAIAN OMSET";
                ws.Cells[startH, 3, startH, 14].Merge = true;
                ws.Cells[startH + 1, 3].Value = "JAN";
                ws.Cells[startH + 1, 4].Value = "PEB";
                ws.Cells[startH + 1, 5].Value = "MRT";
                ws.Cells[startH + 1, 6].Value = "APR";
                ws.Cells[startH + 1, 7].Value = "MEI";
                ws.Cells[startH + 1, 8].Value = "JUN";
                ws.Cells[startH + 1, 9].Value = "JUL";
                ws.Cells[startH + 1, 10].Value = "AGS";
                ws.Cells[startH + 1, 11].Value = "SEP";
                ws.Cells[startH + 1, 12].Value = "OKT";
                ws.Cells[startH + 1, 13].Value = "NOV";
                ws.Cells[startH + 1, 14].Value = "DES";

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
                    ws.Cells[idx, 2].Value = dr["Type"];
                    ws.Cells[idx, 3].Value = dr["JAN"];
                    ws.Cells[idx, 4].Value = dr["PEB"];
                    ws.Cells[idx, 5].Value = dr["MRT"];
                    ws.Cells[idx, 6].Value = dr["APR"];
                    ws.Cells[idx, 7].Value = dr["MEI"];
                    ws.Cells[idx, 8].Value = dr["JUN"];
                    ws.Cells[idx, 9].Value = dr["JUL"];
                    ws.Cells[idx, 10].Value = dr["AGS"];
                    ws.Cells[idx, 11].Value = dr["SEP"];
                    ws.Cells[idx, 12].Value = dr["OKT"];
                    ws.Cells[idx, 13].Value = dr["NOV"];
                    ws.Cells[idx, 14].Value = dr["DES"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 2].Merge = true;
                ws.Cells[idx, 1, idx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

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

                ws.Cells[startH + 2, 3, idx, MaxCol].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 2, 3, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 3, idx, MaxCol].Style.WrapText = true;

                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.WrapText = true;
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 2, idx - 1, 2].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : LAPORAN PENJUALAN TAHUNAN PER TIPE MOTOR";
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
                sf.FileName = "Laporan Penjualan Tahunan per Tipe Motor " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void txtTahun_Leave(object sender, EventArgs e)
        {
            if (txtTahun.GetIntValue > DateTime.MaxValue.Year || txtTahun.GetIntValue < DateTime.MinValue.Year)
            {
                txtTahun.Text = GlobalVar.GetServerDate.Date.Year.ToString();
                MessageBox.Show("Tahun yg diinputkan tidak valid !");
            }
        }


    }
}
