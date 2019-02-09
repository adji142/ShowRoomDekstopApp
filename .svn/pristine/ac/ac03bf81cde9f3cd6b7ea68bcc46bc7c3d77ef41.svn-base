using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ISA.Showroom.Master
{
    public partial class frmVendorBrowser : ISA.Controls.BaseForm
    {
        public frmVendorBrowser()
        {
            InitializeComponent();
            cboFilterNameInitial.SelectedIndex = 1;
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                String init = "";
                if (cboFilterNameInitial.SelectedItem.ToString().ToUpper() == "ALL")
                {
                    init = null;
                }
                else
                {
                    init = cboFilterNameInitial.SelectedItem.ToString();
                }

                using (Database db = new Database())
                {                   
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    if (cboFilterNameInitial.SelectedItem.ToString().ToUpper() == "ALL")
                    {
                        init = null;
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FilterInit", SqlDbType.VarChar, init));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                    DataColumn cConcatenated1 = new DataColumn("conIdentitas", Type.GetType("System.String"), "AlamatIdt + ' RT/RW ' + RTIdt + '/' + RWIdt + ' Kel. ' + KelurahanIdt + ' Kec. ' + KecamatanIdt + ' ' + KotaIdt + ' ' + ProvinsiIdt");
                    dt.Columns.Add(cConcatenated1);
                    DataColumn cConcatenated2 = new DataColumn("conDomisili", Type.GetType("System.String"), "AlamatDom + ' RT/RW ' + RTDom + '/' + RWDom + ' Kel. ' + KelurahanDom + ' Kec. ' + KecamatanDom + ' ' + KotaDom + ' ' + ProvinsiDom");
                    dt.Columns.Add(cConcatenated2);
                    dataGridView1.DataSource = dt;
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

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmVendorUpdate ifrmChild = new Master.frmVendorUpdate(this);
            Program.MainForm.CheckMdiChildren(ifrmChild);
        }

        private void frmVendorBrowser_Load(object sender, EventArgs e)
        {
            cboFilterNameInitial.SelectedItem = "A-E";
            RefreshData();
        }

        public void FindRow(String ColumnName, String value)
        {
            dataGridView1.FindRow(ColumnName, value);
        }        

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (dataGridView1.SelectedCells.Count > 0)
            {
                string namavendor = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable _dtBeli = FillComboBox.DBGetPembelian(Guid.Empty, rowID, Guid.Empty);
                        if (_dtBeli.Rows.Count > 0)
                        {
                            MessageBox.Show("Terdapat keterkaitan data !");
                            return;
                        }
                        else
                        {   // pake cekDelete punya Pak Novi
                            if (Class.PenerimaanUang.checkDelete(rowID, "Vendor") == true) // this.ceckDelete(rowID) == true -> ke Vendor
                            {
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusMaster), "Hapus Master.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                                if (GlobalVar.pinResult == false) { return; }
                            }

                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Vendor_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                dt = db.Commands[0].ExecuteDataTable();
                            }
                            dataGridView1.Rows.Remove(dataGridView1.SelectedCells[0].OwningRow);
                            MessageBox.Show("Data berhasil dihapus");
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmVendorUpdate ifrmChild = new Master.frmVendorUpdate(this, rowID);
                Program.MainForm.CheckMdiChildren(ifrmChild);
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }
        /*
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell iCell in iRow.Cells)
                    {
                        if (iRow.Index % 2 == 0)
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 128);
                        }
                        else
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 255);
                        }
                    }
                }
            }
        }
        */
        /*
        private bool ceckDelete(Guid rowID)
        {
            bool hapus = false;
            DataTable dt = new DataTable();

            Command cmd = new Command(new Database(), CommandType.Text,
                                        " SELECT *                                                        " +
                                        "   FROM dbo.Vendor                                               " +
                                        "  WHERE RowID = @RowID                                           " +
                                        "    AND CONVERT(DATE,LastUpdatedOn) = CONVERT(DATE,GETDATE())    "
                                     );
            cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, rowID);
            dt = cmd.ExecuteDataTable();

            if (dt.Rows.Count > 0) hapus = false;
            else hapus = true;

            return hapus;
        }
        */
        private void cboFilterNameInitial_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdCreateExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet dt = new DataSet();
                String init = "";
                if (cboFilterNameInitial.SelectedItem.ToString().ToUpper() == "ALL")
                {
                    init = null;
                }
                else
                {
                    init = cboFilterNameInitial.SelectedItem.ToString();
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    if (cboFilterNameInitial.SelectedItem.ToString().ToUpper() == "ALL")
                    {
                        init = null;
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FilterInit", SqlDbType.VarChar, init));
                    }
                    dt = db.Commands[0].ExecuteDataSet();
                    DataColumn cConcatenated1 = new DataColumn("conIdentitas", Type.GetType("System.String"), "AlamatIdt + ' RT/RW ' + RTIdt + '/' + RWIdt + ' Kel. ' + KelurahanIdt + ' Kec. ' + KecamatanIdt + ' ' + KotaIdt + ' ' + ProvinsiIdt");
                    dt.Tables[0].Columns.Add(cConcatenated1);
                    DataColumn cConcatenated2 = new DataColumn("conDomisili", Type.GetType("System.String"), "AlamatDom + ' RT/RW ' + RTDom + '/' + RWDom + ' Kel. ' + KelurahanDom + ' Kec. ' + KecamatanDom + ' ' + KotaDom + ' ' + ProvinsiDom");
                    dt.Tables[0].Columns.Add(cConcatenated2);
                    GenerateExcell(dt);
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

        private void GenerateExcell(DataSet ds)
        {
            DataTable dt1 = new DataTable();

            dt1 = ds.Tables[0].Copy();

            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = SecurityManager.UserName;
                p.Workbook.Properties.Title = "DAFTAR VENDOR FILTER - " + cboFilterNameInitial.SelectedItem.ToString();


                p.Workbook.Worksheets.Add("DAFTAR VENDOR FILTER - " + cboFilterNameInitial.SelectedItem.ToString());
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                //int MaxCol = 8;
                int MaxCol = 9;
                int startH = 5;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 5;
                ws.Cells[1, 2].Worksheet.Column(2).Width = 40;
                ws.Cells[1, 3].Worksheet.Column(3).Width = 12;
                ws.Cells[1, 4].Worksheet.Column(4).Width = 25;
                ws.Cells[1, 5].Worksheet.Column(5).Width = 65;
                ws.Cells[1, 6].Worksheet.Column(6).Width = 65;
                for (int i = 7; i <= MaxCol; i++)
                {
                    ws.Cells[1, i].Worksheet.Column(i).Width = 18;
                }

                string Title = "DAFTAR VENDOR";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[2, 1].Style.Font.Bold = true;
                //ws.Cells[3, 1].Value = dateTextBox1.DateValue.Value.ToString("dd-MM-yyyy");
                ws.Cells[3, 1].Value = "FILTER - " + cboFilterNameInitial.SelectedItem.ToString();

                ws.Cells[2, 1, 2, MaxCol].Merge = true;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 14;
                ws.Cells[3, 1].Style.Font.Size = 12;

                #region Generate Header

                ws.Cells[startH, 1].Value = "No";
                ws.Cells[startH, 2].Value = "Nama Customer";
                ws.Cells[startH, 3].Value = "Identitas";
                ws.Cells[startH, 4].Value = "No. Identitas";
                ws.Cells[startH, 5].Value = "Alamat Identitas";
                ws.Cells[startH, 6].Value = "Alamat Domisili";
                ws.Cells[startH, 7].Value = "No. Telpon";
                ws.Cells[startH, 8].Value = "No. HP";
                ws.Cells[startH, 9].Value = "Keterangan";

                ws.Cells[startH, 1, startH, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                #endregion

                #region FillData
                int idx = startH + 1;
                int No = 1;
                foreach (DataRow dr in dt1.Rows)
                {
                    ws.Cells[idx, 1].Value = No;
                    ws.Cells[idx, 2].Value = dr["Nama"];
                    ws.Cells[idx, 3].Value = dr["Identitas"];
                    ws.Cells[idx, 4].Value = dr["NoIdentitas"];
                    ws.Cells[idx, 5].Value = dr["conIdentitas"];
                    ws.Cells[idx, 6].Value = dr["conDomisili"];
                    ws.Cells[idx, 7].Value = dr["NoTelp"];
                    ws.Cells[idx, 8].Value = dr["NoHP"];
                    ws.Cells[idx, 9].Value = dr["Keterangan"];

                    idx++;
                    No++;
                }
                if (dt1.Rows.Count == 0)
                {
                    idx++;
                }

                //ws.Cells[idx, 1, idx, 3].Merge = true;

                //idx++;

                ws.Cells[idx, 1].Value = "Tgl. Process: " + GlobalVar.GetServerDate.ToString();
                ws.Cells[idx + 1, 1].Value = "Process By: " + SecurityManager.UserName.ToString();

                ws.Cells[idx, 1].Style.Font.Size = 8;
                ws.Cells[idx, 1].Style.Font.Italic = true;
                ws.Cells[idx + 1, 1].Style.Font.Size = 8;
                ws.Cells[idx + 1, 1].Style.Font.Italic = true;

                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                //ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                //ws.Cells[idx, 1].Value = "Total";

                //ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH+1, 5].Address +
                //        ":" + ws.Cells[idx-1,5].Address + ")";
                //ws.Cells[idx, 6].Formula = "Sum(" + ws.Cells[startH + 1, 6].Address +
                //      ":" + ws.Cells[idx - 1, 6].Address + ")";

                //ws.Cells[startH + 1, 4, idx, MaxCol].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                //ws.Cells[startH + 1, 2, idx - 1, 2].Style.Numberformat.Format = "dd-MMM-yyyy";
                //ws.Cells[5, 2].Style.Numberformat.Format = "dd-MMM-yyyy";

                //ws.Cells[startH + 1, 1, idx, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                // ws.Cells[startH + 1, 1, idx, 1].Style.Numberformat.Format = "#,###;(#,##);0";
                //ws.Cells[startH + 1, 4, idx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                //ws.Cells[startH + 1, 4, idx, MaxCol].Style.WrapText = true;

                
                var border = ws.Cells[startH, 1, idx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                #endregion

                #region Output
                Byte[] bin = p.GetAsByteArray();

                //string file = "C:\\Temp\\RekapHutanDetailPerInvoice.xls";
                //ws.Cells.Style.ShrinkToFit = true;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Vendor List - " + cboFilterNameInitial.SelectedItem.ToString() + ".xlsx";

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
    }
}
