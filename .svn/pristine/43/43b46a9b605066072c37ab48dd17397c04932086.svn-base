using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Showroom.Finance.DataTemplates;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;


namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmRptPiutangLainLain_SaldoBank : ISA.Controls.BaseForm
    {
        Class.FillComboBox fcbo = new Class.FillComboBox();
        String terhadapPT = "";
        
        public frmRptPiutangLainLain_SaldoBank()
        {
            InitializeComponent();
        }

        private void frmRptPiutangLainLain_SaldoBank_Load(object sender, EventArgs e)
        {
            cboJenis.SelectedIndex = 2;
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            fcbo.fillComboPerusahaan(cboTerhadapPT);
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    Guid PerusahaanRowIDCari = (Guid)cboTerhadapPT.SelectedValue;
                    

                    db.Commands.Add(db.CreateCommand("[rsp_PiutangLainLain_SaldoBank]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, cboJenis.SelectedItem.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowIDLogin", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    if(PerusahaanRowIDCari==Guid.Empty) {
                        terhadapPT = "Seluruh PT";
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowIDCari", SqlDbType.UniqueIdentifier, null));
                    } else {
                        terhadapPT = cboTerhadapPT.Text.ToString();
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowIDCari", SqlDbType.UniqueIdentifier, PerusahaanRowIDCari));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }



                //DisplayReport(dt);
                GenerateExcell(dt);

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


        private void GenerateExcell(DataTable dt)
        {
            

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS";
                p.Workbook.Properties.Title = "LAPORAN SALDO BANK";


                p.Workbook.Worksheets.Add("Sheet1");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";


                String periode = String.Format("Periode : {0} s/d {1}", rangeDateBox1.FromDate.Value.ToString("dd-MM-yyyy"), rangeDateBox1.ToDate.Value.ToString("dd-MM-yyyy"));

                ws.Cells[1, 1].Value = periode;
                ws.Cells[2, 1].Value = "Saldo Bank " + cboJenis.SelectedItem.ToString();
                ws.Cells[3, 1].Value = "TerHadap " + terhadapPT;

                int k = 0;
                int b = 4;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 14;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 14;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 53;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12;

                ws.Cells[b, 1].Value = "Tanggal";
                ws.Cells[b, 2].Value = "No. Bukti";
                ws.Cells[b, 3].Value = "Uraian";
                ws.Cells[b, 4].Value = "Debet";
                ws.Cells[b, 5].Value = "Kredit";
                ws.Cells[b, 6].Value = "Saldo";

                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ws.Cells[b+i, 1].Value = dr["Tanggal"];
                    ws.Cells[b + i, 2].Value = dr["NoBukti"];
                    ws.Cells[b + i, 3].Value = dr["Uraian"];
                    ws.Cells[b + i, 4].Value = dr["Debet"];
                    ws.Cells[b + i, 5].Value = dr["Kredit"];
                    if(i==1 ) {
                        ws.Cells[b + i, 6].Formula = ws.Cells[b + i, 4].Address + "-" + ws.Cells[b + i, 5].Address;
                    } else {
                        ws.Cells[b + i, 6].Formula = "+" + ws.Cells[(b + i) - 1, 6].Address + "+" + ws.Cells[b + i, 4].Address + "-"+ws.Cells[b + i, 5].Address;
                    }
                    i++;
                }


                ws.Cells[b + 1, 1, b + i, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[b+1, 4,b + i, 6].Style.Numberformat.Format = "#,##0;(#,##0);0";
                var border = ws.Cells[b, 1, b + i, 6].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;

                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\rpt02BukuBesar.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Saldo Bank " + cboJenis.SelectedItem.ToString() + ".xlsx";

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

            try
            {



                string periode = string.Empty;
                periode = String.Format("Periode : {0} s/d {1}", rangeDateBox1.FromDate.Value.ToString("dd-MM-yyyy"), rangeDateBox1.ToDate.Value.ToString("dd-MM-yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Title", "Saldo Bank "+cboJenis.SelectedItem.ToString()));
               
              



                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptPiutangLainLain_SaldoBank.rdlc", rptParams, dt, "dsSaldoBank_Data");
                 ifrmReport.Show();


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
