using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;



namespace ISA.Showroom.Finance.GL
{
    public partial class frmRpt06NeracaGabung : ISA.Controls.BaseForm
    {
        DateTime fromDate = new DateTime();
        DateTime toDate = new DateTime();
        string kodeGudang = GlobalVar.Gudang;

        public frmRpt06NeracaGabung()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRpt06LabaRugi_Load(object sender, EventArgs e)
        {
            SetControl();
            Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
            fcbo.fillComboPerusahaanNonECR(cboPerusahaan);
            if (cboPerusahaan.Items.Count > 1) cboPerusahaan.SelectedIndex = 0;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                fromDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);

                //Create Exel File
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                Excel.Range chartRange;
                Excel.Range chartRange1;
                xlApp = new Excel.ApplicationClass();
                //xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkBook = xlApp.Workbooks.Add(1);

                //xlApp.Visible = true;
                //-------------------------------------
                //Name Perusahaan
                string KodeIp = cboPerusahaan.Text ;
                DataTable dtp = new DataTable();
                using (Database dbp = new Database(GlobalVar.DBHoldingName))
                    {
                        dbp.Commands.Add(dbp.CreateCommand("[rsp_GL_06Neraca_List_Pt]"));
                        dbp.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                        dbp.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                        dbp.Commands[0].Parameters.Add(new Parameter("@KodeIP", SqlDbType.VarChar, (KodeIp)));
                        dtp = dbp.Commands[0].ExecuteDataTable();
                    }

                    if (dtp.Rows.Count == 0)
                    {
                        MessageBox.Show(Messages.Confirm.NoDataAvailable);
                        return;
                    }

                    int colWS = 0;
                    int rowWS = 0;
                    string Nmpt = "";

                    foreach (DataRow drp in dtp.Rows)
                    {
                        rowWS = rowWS + 1;
                        foreach (DataColumn dcp in dtp.Columns)
                        {
                            colWS = colWS + 1;
                            Nmpt = drp[dcp.ColumnName].ToString();
                        }

                        //Create WorkSheet Neraca
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(misValue, misValue, misValue, misValue);
                        xlWorkSheet.Name = "N_" + Nmpt;
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("N_" + Nmpt);
                        {


                            //    ///-----------------------------------------------------
                            //    //add data Header Report
                            DataTable dth = new DataTable();
                            using (Database dbh = new Database(GlobalVar.DBHoldingName))
                            {
                                dbh.Commands.Add(dbh.CreateCommand("[rsp_GL_06Neraca_List_Cab]"));
                                dbh.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                                dbh.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                                dbh.Commands[0].Parameters.Add(new Parameter("@KodeIP", SqlDbType.VarChar, (Nmpt)));
                                dth = dbh.Commands[0].ExecuteDataTable();
                            }
                            if (dth.Rows.Count >= 1)
                            {
                                xlWorkSheet.Cells[1, 2] = "SAS";
                                xlWorkSheet.Cells[2, 2] = "NERACA";//// +" " + (GlobalVar.PerusahaanID);
                                xlWorkSheet.Cells[3, 2] = "Untuk periode yang berakhir pada tanggal-tanggal";
                                DateTime prevPeriode = fromDate.AddDays(-1);
                                xlWorkSheet.Cells[4, 2] = "Periode : " + toDate.ToString("dd-MMM-yyyy") + " dan " + prevPeriode.ToString("dd-MMM-yyyy");

                                xlWorkSheet.Cells[6, 2] = "KETERANGAN";


                                int rowIndex = 1;
                                int colIndex;
                                int rowIndexTemp;
                                foreach (DataRow drh in dth.Rows)
                                {
                                    rowIndex = rowIndex + 1;
                                    colIndex = 6;
                                    foreach (DataColumn dch in dth.Columns)
                                    {
                                        colIndex = colIndex + 1;
                                        xlWorkSheet.Cells[colIndex, rowIndex + 1] = "'" + drh[dch.ColumnName].ToString();
                                    }
                                }

                                rowIndex = rowIndex + 2;
                                xlWorkSheet.Cells[6, rowIndex] = "Bulan                       Berjalan"; //xlWorkSheet.Cells[7,rowIndex] = "Bln Berjalan";
                                rowIndex = rowIndex + 1;
                                xlWorkSheet.Cells[6, rowIndex] = "Bulan                       Sebelumnya"; //xlWorkSheet.Cells[7,rowIndex] = "Bln Sebelumnya";


                                //int i = 0;
                                for (int i = 1; i <= 7; i++)
                                {
                                    if (i <= 4)
                                    {
                                        xlWorkSheet.get_Range(xlWorkSheet.Cells[i, 2], xlWorkSheet.Cells[i, rowIndex]).Merge(false);
                                        chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[i, 2], xlWorkSheet.Cells[i, rowIndex]);
                                    }
                                    chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[i, 2], xlWorkSheet.Cells[i, rowIndex]);
                                    chartRange.HorizontalAlignment = 3;
                                    chartRange.VerticalAlignment = 3;
                                    chartRange.Font.Bold = true;
                                    if (i == 1) chartRange.Font.Size = 16;
                                    if (i == 2) chartRange.Font.Size = 10;
                                    if (i == 3) chartRange.Font.Size = 8;
                                    if (i == 4) chartRange.Font.Size = 8;

                                    chartRange.Font.Name = "Arial";
                                    //chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                }

                                //rowTemp
                                rowIndexTemp = rowIndex;

                                ///-----------------------------------------------------
                                //add data Detail Report

                                DataTable dt = new DataTable();
                                using (Database db = new Database(GlobalVar.DBHoldingName))
                                {
                                    db.Commands.Add(db.CreateCommand("[rsp_GL_06Neraca_All_Cab]"));
                                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeIP", SqlDbType.VarChar, (Nmpt)));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }

                                if (dt.Rows.Count >= 1)
                                {
                                    //xlApp.Visible = true;
                                    int CabId = dth.Rows.Count;
                                    rowIndex = 6;
                                    int ColCabId;
                                    string huruf = "";
                                    string Tipe = "";

                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        rowIndex = rowIndex + 1;
                                        colIndex = 0;
                                        ColCabId = 1;
                                        foreach (DataColumn dc in dt.Columns)
                                        {
                                            colIndex = colIndex + 1;
                                            if (colIndex == 3)
                                            {
                                                Tipe = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex == 4)
                                            {
                                                ColCabId = ColCabId + 1;
                                                xlWorkSheet.Cells[rowIndex + 1, ColCabId] = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex == 10)
                                            {
                                                huruf = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex >= 12 && colIndex <= CabId + 11)
                                            {
                                                ColCabId = ColCabId + 1;
                                                xlWorkSheet.Cells[rowIndex + 1, ColCabId] = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex == 38 || colIndex == 39)
                                            {
                                                ColCabId = ColCabId + 1;
                                                xlWorkSheet.Cells[rowIndex + 1, ColCabId] = dr[dc.ColumnName].ToString();
                                            }


                                            chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[rowIndex + 1, ColCabId], xlWorkSheet.Cells[rowIndex + 1, ColCabId]);
                                            chartRange.HorizontalAlignment = 1;
                                            if (rowIndex >= 8 && colIndex == 4) { chartRange.HorizontalAlignment = 2; }
                                            chartRange.NumberFormat = "#,###"; chartRange.ColumnWidth = 16;
                                            chartRange.VerticalAlignment = 3;
                                            chartRange.Font.Bold = false;
                                            chartRange.Font.Size = 8;
                                            chartRange.Font.Name = "Arial";

                                            if (huruf == "True") chartRange.Font.Bold = true;
                                            if (Tipe == "T")
                                            {
                                                chartRange1 = xlWorkSheet.get_Range(xlWorkSheet.Cells[rowIndex + 1, 2], xlWorkSheet.Cells[62, rowIndexTemp]);
                                                chartRange1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                                Tipe = "";
                                            }
                                            if (Tipe == "TT")
                                            {
                                                chartRange1 = xlWorkSheet.get_Range(xlWorkSheet.Cells[rowIndex + 1, 2], xlWorkSheet.Cells[62, rowIndexTemp]);
                                                chartRange1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                            }
                                        }
                                    }
                                    xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 1]).ColumnWidth = 1;
                                    xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 2], xlWorkSheet.Cells[1, 2]).ColumnWidth = 45;

                                    for (int i = 2; i <= rowIndexTemp; i++)
                                    {
                                        chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[6, i], xlWorkSheet.Cells[7, i]);
                                        chartRange.Merge(false);
                                        chartRange.WrapText = (true);
                                        chartRange.HorizontalAlignment = 3;
                                        chartRange.VerticalAlignment = 3;
                                        chartRange.Font.Bold = true;
                                        chartRange.Font.Size = 9;
                                        chartRange.Font.Name = "Arial";
                                        chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                    }

                                    for (int i = 2; i <= rowIndexTemp; i++)
                                    {

                                        xlWorkSheet.get_Range(xlWorkSheet.Cells[8, i], xlWorkSheet.Cells[62, i]).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                    }

                                }

                            }

                        }



                        //Create WorkSheet Laba Rugi
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(misValue, misValue, misValue, misValue);
                        xlWorkSheet.Name = "L_" + Nmpt;
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("L_" + Nmpt);
                        {


                            ///-----------------------------------------------------
                            //add data Header Report
                            DataTable dth = new DataTable();
                            using (Database dbh = new Database(GlobalVar.DBHoldingName))
                            {
                                dbh.Commands.Add(dbh.CreateCommand("[rsp_GL_06Neraca_List_Cab]"));
                                dbh.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                                dbh.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                                dbh.Commands[0].Parameters.Add(new Parameter("@KodeIP", SqlDbType.VarChar, (Nmpt)));
                                dth = dbh.Commands[0].ExecuteDataTable();
                            }
                            if (dth.Rows.Count >= 1)
                            {
                                xlWorkSheet.Cells[1, 2] = "SAS";
                                xlWorkSheet.Cells[2, 2] = "LABA RUGI & PERUBAHAN MODAL";//// +" " + (GlobalVar.PerusahaanID);
                                xlWorkSheet.Cells[3, 2] = "Untuk periode yang berakhir pada tanggal-tanggal";
                                DateTime prevPeriode = fromDate.AddDays(-1);
                                xlWorkSheet.Cells[4, 2] = "Periode : " + toDate.ToString("dd-MMM-yyyy") + " dan " + prevPeriode.ToString("dd-MMM-yyyy");

                                xlWorkSheet.Cells[6, 2] = "KETERANGAN";


                                int rowIndex = 1;
                                int colIndex;
                                int rowIndexTemp;
                                foreach (DataRow drh in dth.Rows)
                                {
                                    rowIndex = rowIndex + 1;
                                    colIndex = 6;
                                    foreach (DataColumn dch in dth.Columns)
                                    {
                                        colIndex = colIndex + 1;
                                        xlWorkSheet.Cells[colIndex, rowIndex + 1] = "'" + drh[dch.ColumnName].ToString();
                                    }
                                }

                                rowIndex = rowIndex + 2;
                                xlWorkSheet.Cells[6, rowIndex] = "Bulan                       Berjalan"; //xlWorkSheet.Cells[7,rowIndex] = "Bln Berjalan";
                                rowIndex = rowIndex + 1;
                                xlWorkSheet.Cells[6, rowIndex] = "Bulan                       Sebelumnya"; //xlWorkSheet.Cells[7,rowIndex] = "Bln Sebelumnya";


                                //int i = 0;
                                for (int i = 1; i <= 7; i++)
                                {
                                    if (i <= 4)
                                    {
                                        xlWorkSheet.get_Range(xlWorkSheet.Cells[i, 2], xlWorkSheet.Cells[i, rowIndex]).Merge(false);
                                        chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[i, 2], xlWorkSheet.Cells[i, rowIndex]);
                                    }
                                    chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[i, 2], xlWorkSheet.Cells[i, rowIndex]);
                                    chartRange.HorizontalAlignment = 3;
                                    chartRange.VerticalAlignment = 3;
                                    chartRange.Font.Bold = true;
                                    if (i == 1) chartRange.Font.Size = 16;
                                    if (i == 2) chartRange.Font.Size = 10;
                                    if (i == 3) chartRange.Font.Size = 8;
                                    if (i == 4) chartRange.Font.Size = 8;

                                    chartRange.Font.Name = "Arial";
                                    //chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                }

                                //rowTemp
                                rowIndexTemp = rowIndex;

                                ///-----------------------------------------------------
                                //add data Detail Report

                                DataTable dt = new DataTable();
                                using (Database db = new Database(GlobalVar.DBHoldingName))
                                {
                                    db.Commands.Add(db.CreateCommand("[rsp_GL_05ALabaRugi_All_Cab]"));
                                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeIP", SqlDbType.VarChar, (Nmpt)));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }

                                if (dt.Rows.Count >= 1)
                                {
                                    //xlApp.Visible = true;
                                    int CabId = dth.Rows.Count;
                                    rowIndex = 6;
                                    int ColCabId;
                                    string huruf = "";
                                    string Tipe = "";

                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        rowIndex = rowIndex + 1;
                                        colIndex = 0;
                                        ColCabId = 1;
                                        foreach (DataColumn dc in dt.Columns)
                                        {
                                            colIndex = colIndex + 1;
                                            if (colIndex == 3)
                                            {
                                                Tipe = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex == 4)
                                            {
                                                ColCabId = ColCabId + 1;
                                                xlWorkSheet.Cells[rowIndex + 1, ColCabId] = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex == 10)
                                            {
                                                huruf = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex >= 12 && colIndex <= CabId + 11)
                                            {
                                                ColCabId = ColCabId + 1;
                                                xlWorkSheet.Cells[rowIndex + 1, ColCabId] = dr[dc.ColumnName].ToString();
                                            }
                                            else if (colIndex == 38 || colIndex == 39)
                                            {
                                                ColCabId = ColCabId + 1;
                                                xlWorkSheet.Cells[rowIndex + 1, ColCabId] = dr[dc.ColumnName].ToString();
                                            }


                                            chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[rowIndex + 1, ColCabId], xlWorkSheet.Cells[rowIndex + 1, ColCabId]);
                                            chartRange.HorizontalAlignment = 1;
                                            if (rowIndex >= 8 && colIndex == 4) { chartRange.HorizontalAlignment = 2; }
                                            chartRange.NumberFormat = "#,###"; chartRange.ColumnWidth = 16;
                                            chartRange.VerticalAlignment = 3;
                                            chartRange.Font.Bold = false;
                                            chartRange.Font.Size = 8;
                                            chartRange.Font.Name = "Arial";

                                            if (huruf == "True") chartRange.Font.Bold = true;
                                            if (Tipe == "T")
                                            {
                                                chartRange1 = xlWorkSheet.get_Range(xlWorkSheet.Cells[rowIndex + 1, 2], xlWorkSheet.Cells[93, rowIndexTemp]);
                                                chartRange1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                                Tipe = "";
                                            }
                                            if (Tipe == "TT")
                                            {
                                                chartRange1 = xlWorkSheet.get_Range(xlWorkSheet.Cells[rowIndex + 1, 2], xlWorkSheet.Cells[93, rowIndexTemp]);
                                                chartRange1.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                            }
                                        }
                                    }
                                    xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 1]).ColumnWidth = 1;
                                    xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 2], xlWorkSheet.Cells[1, 2]).ColumnWidth = 45;

                                    for (int i = 2; i <= rowIndexTemp; i++)
                                    {
                                        chartRange = xlWorkSheet.get_Range(xlWorkSheet.Cells[6, i], xlWorkSheet.Cells[7, i]);
                                        chartRange.Merge(false);
                                        chartRange.WrapText = (true);
                                        chartRange.HorizontalAlignment = 3;
                                        chartRange.VerticalAlignment = 3;
                                        chartRange.Font.Bold = true;
                                        chartRange.Font.Size = 9;
                                        chartRange.Font.Name = "Arial";
                                        chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                    }

                                    for (int i = 2; i <= rowIndexTemp; i++)
                                    {

                                        xlWorkSheet.get_Range(xlWorkSheet.Cells[8, i], xlWorkSheet.Cells[93, i]).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                                    }

                                }

                            }

                        }



                    }
                //Finis Perusahaan

                xlApp.Visible = true;

                //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Quit();
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
        private void SetControl()
        {
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            lookupGudang1.GudangID = "";
            if (GlobalVar.PerusahaanID != "HLD") lookupGudang1.Enabled = false;
        }

        private void ShowReport(DataTable dt)
        {
            //construct parameter
            //string periode;
            DateTime currPeriode = toDate;
            DateTime prevPeriode = fromDate.AddDays(-1);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", currPeriode.ToString("dd-MMM-yyyy") + " dan " + prevPeriode.ToString("dd-MMM-yyyy")));
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserInitial));
                rptParams.Add(new ReportParameter("KodeGudang", kodeGudang));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("GL.Laporan.rpt06Neraca.rdlc", rptParams, dt, "dsGL_Data");
                ifrmReport.Text = "Buku Besar";
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
