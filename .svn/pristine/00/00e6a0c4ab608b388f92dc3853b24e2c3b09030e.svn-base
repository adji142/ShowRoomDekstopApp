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
    public partial class frmLapTargetWilayah : ISA.Controls.BaseForm
    {
        public frmLapTargetWilayah()
        {
            InitializeComponent();
            rngTglJual.FromDate = (DateTime) new DateTime(2000, 1, 1);
            rngTglJual.ToDate = GlobalVar.GetServerDate;
            DataTable dt = Class.FillComboBox.DBGetCabang(string.Empty);
            dt.DefaultView.Sort = "NamaPanjang ASC";
            cbxCabang.DisplayMember = "NamaPanjang";
            cbxCabang.ValueMember = "CabangID";
            cbxCabang.DataSource = dt.DefaultView;
            if(cbxCabang.Items.Count > 0)
            {
                cbxCabang.SelectedIndex = 0;
            }
        }

        private void GenerateExcel(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN KONSOLIDASI OVERDUE - TARGET WILAYAH";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 4;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 20;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 11;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 11;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 18;

                string Title = "LAPORAN TARGET WILAYAH";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang      : " + cbxCabang.Text;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", rngTglJual.FromDate.Value) + " s/d " + string.Format("{0:dd-MM-yyyy}", rngTglJual.ToDate.Value);
                ws.Cells[5, 1, 5, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 5, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 5, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "DAERAH";
                ws.Cells[startH, 1].Merge = true;
                ws.Cells[startH, 2].Value = "CTM";
                ws.Cells[startH, 2].Merge = true;
                ws.Cells[startH, 3].Value = "OVD";
                ws.Cells[startH, 3].Merge = true;
                ws.Cells[startH, 4].Value = "T. OVD";
                ws.Cells[startH, 4].Merge = true;

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
                    ws.Cells[idx, 1].Value = dr["Daerah"];
                    ws.Cells[idx, 2].Value = dr["CTM"];
                    ws.Cells[idx, 3].Value = dr["CTMOVD"];
                    ws.Cells[idx, 4].Value = dr["NominalOVD"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 1].Merge = true;
                ws.Cells[idx, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 2].Formula = "Sum(" + ws.Cells[startH + 1, 2].Address +
                           ":" + ws.Cells[idx - 1, 2].Address + ")";

                ws.Cells[idx, 3].Formula = "Sum(" + ws.Cells[startH + 1, 3].Address +
                           ":" + ws.Cells[idx - 1, 3].Address + ")";

                ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 1, 4].Address +
                           ":" + ws.Cells[idx - 1, 4].Address + ")";

                ws.Cells[startH + 1, 2, idx, 3].Style.Numberformat.Format = "#,##0;(#,##0);0";
                ws.Cells[startH + 1, 4, idx, 4].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                
                ws.Cells[startH + 1, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 1, idx - 1, 1].Style.WrapText = true;
                
                ws.Cells[startH + 1, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 2, idx - 1, 4].Style.WrapText = true;

                ws.Cells[startH + 1, 1, idx - 1, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Target Wilayah - " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";
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
                sf.FileName = "Laporan Target Wilayah - " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
            if( string.IsNullOrEmpty(rngTglJual.FromDate.ToString() ) )
            {
                rngTglJual.FromDate = (DateTime)new DateTime(2000, 1, 1);
            }
            if (string.IsNullOrEmpty(rngTglJual.ToDate.ToString()))
            {                                       
                rngTglJual.ToDate = GlobalVar.GetServerDate;
            }
            try
            {  
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LapPiutangOverdue_TargetWilayah]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.DateTime, rngTglJual.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJualAkhir", SqlDbType.DateTime, rngTglJual.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cbxCabang.SelectedValue));

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
