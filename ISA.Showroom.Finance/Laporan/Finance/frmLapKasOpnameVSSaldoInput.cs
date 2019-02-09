using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Showroom.Finance.Class;
using ISA.DAL;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmLapKasOpnameVSSaldoInput : ISA.Controls.BaseForm
    {
        FillComboBox fcbo = new Class.FillComboBox();

        public frmLapKasOpnameVSSaldoInput()
        {
            InitializeComponent();
        }

        private void frmLapKasOpnameVSSaldoInput_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
            if (cboKas.Items.Count > 1)
            {
                cboKas.SelectedIndex = 1;
            }
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("rsp_LapKasOpname_vs_SaldoInput"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                if (cboKas.SelectedValue == null || cboKas.SelectedValue.ToString().Trim() == "")
                {
                }
                else if( (Guid) cboKas.SelectedValue != Guid.Empty)
                {
                    db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                }
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));     
                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    GenerateExcel(dt);
                }
                else
                {
                    MessageBox.Show("Data Kosong!");
                }
            }
        }

        private void GenerateExcel(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN PERBANDINGAN KAS OPNAME DENGAN SALDO INPUTAN";

                p.Workbook.Worksheets.Add("KAS_OP_VS_INPUT");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "KAS_OP_VS_INPUT"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 6; 
                int startH = 7;
                int colstart = 1;

                ws.Cells[1, colstart].Worksheet.Column(colstart).Width =  7; colstart++; // No
                ws.Cells[1, colstart].Worksheet.Column(colstart).Width = 20; colstart++; // Tanggal
                ws.Cells[1, colstart].Worksheet.Column(colstart).Width = 25; colstart++; // Nama Kas
                ws.Cells[1, colstart].Worksheet.Column(colstart).Width = 20; colstart++; // Saldo Opname
                ws.Cells[1, colstart].Worksheet.Column(colstart).Width = 20; colstart++; // Saldo RK
                ws.Cells[1, colstart].Worksheet.Column(colstart).Width = 15; colstart++; // Saldo Inputan

                MaxCol = colstart - 1;

                string Title = "LAPORAN PERBANDINGAN KAS OPNAME DENGAN SALDO INPUTAN";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode     : " + rangeDateBox1.FromDate.Value.ToString("dd-MMM-yyyy") + " - " + rangeDateBox1.ToDate.Value.ToString("dd-MMM-yyyy");
                ws.Cells[5, 1, 5, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 5, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 5, 4].Style.Font.Bold = true;

                #region Generate Header

                int idxCol_No;
                int idxCol_Tanggal;
                int idxCol_TipeKas;
                int idxCol_Saldo;

                // mulai dari kolom pertama lagi
                colstart = 1;

                // baris, kolom
                ws.Cells[startH, colstart].Value = "NO";
                ws.Cells[startH, colstart, startH, colstart].Merge = true;
                idxCol_No = colstart;
                colstart++;

                ws.Cells[startH, colstart].Value = "TANGGAL";
                ws.Cells[startH, colstart, startH, colstart].Merge = true;
                idxCol_Tanggal = colstart;
                colstart++;

                ws.Cells[startH, colstart].Value = "TIPE KAS";
                ws.Cells[startH, colstart, startH, colstart].Merge = true;
                idxCol_TipeKas = colstart;
                colstart++;

                ws.Cells[startH, colstart].Value = "SALDO OPNAME";
                ws.Cells[startH, colstart, startH, colstart].Merge = true;
                idxCol_Saldo = colstart;
                colstart++;

                ws.Cells[startH, colstart].Value = "SALDO RK";
                ws.Cells[startH, colstart, startH, colstart].Merge = true;
                colstart++;

                ws.Cells[startH, colstart].Value = "SALDO INPUTAN";
                ws.Cells[startH, colstart, startH, colstart].Merge = true;
                colstart++;

                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region FillData
                int idx = startH + 1;
                int no = 1;

                foreach (DataRow dr in dt.Rows)
                {
                    // mulai dari colstart
                    colstart = 1;
                    
                    ws.Cells[idx, colstart].Value = no; no++; colstart++;
                    ws.Cells[idx, colstart].Value = Tools.isNull(dr["Tanggal"], String.Empty); colstart++;
                    ws.Cells[idx, colstart].Value = Tools.isNull(dr["Kas"], String.Empty); colstart++;
                    ws.Cells[idx, colstart].Value = Tools.isNull(dr["SaldoOpname"], String.Empty); colstart++;
                    ws.Cells[idx, colstart].Value = Tools.isNull(dr["SaldoTglRK"], String.Empty); colstart++;
                    ws.Cells[idx, colstart].Value = Tools.isNull(dr["SaldoTglInput"], String.Empty); colstart++;
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                // Nomor...
                ws.Cells[startH + 1, idxCol_No, idx - 1, idxCol_No].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, idxCol_No, idx - 1, idxCol_No].Style.WrapText = true;

                // Tanggal...
                ws.Cells[startH + 1, idxCol_Tanggal, idx - 1, idxCol_Tanggal].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 1, idxCol_Tanggal, idx - 1, idxCol_Tanggal].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, idxCol_Tanggal, idx - 1, idxCol_Tanggal].Style.WrapText = true;

                // Tipe Kas...
                ws.Cells[startH + 1, idxCol_TipeKas, idx - 1, idxCol_TipeKas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, idxCol_TipeKas, idx - 1, idxCol_TipeKas].Style.WrapText = true;

                // Saldo Opname - Rk - Input
                ws.Cells[startH + 1, idxCol_Saldo, idx - 1, MaxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);-";
                ws.Cells[startH + 1, idxCol_Saldo, idx - 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, idxCol_Saldo, idx - 1, MaxCol].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : LAPORAN PERBANDINGAN KAS OPNAME DENGAN SALDO INPUTAN - " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                var border = ws.Cells[startH, 1, idx - 1, MaxCol].Style.Border;
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
                sf.FileName = "LAPORAN KAS OPNAME VS SALDO INPUTAN - " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
