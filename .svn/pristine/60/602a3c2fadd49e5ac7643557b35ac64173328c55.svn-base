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
    public partial class frmLapPembelian : ISA.Controls.BaseForm
    {
        public frmLapPembelian()
        {
            InitializeComponent();
        }

        private void ListKondisi()
        {
            cboKondisi.DisplayMember = "Text";
            cboKondisi.ValueMember = "Value";
            var items = new[] {
                new { Text = "Baru", Value = "Baru" },
                new { Text = "Bekas", Value = "Bekas" },
                new { Text = "Semua", Value = "" }
            };
            cboKondisi.DataSource = items;
        }

        private void ListPembelian()
        {
            cboPembelian.DisplayMember = "Text";
            cboPembelian.ValueMember = "Value";
            var items = new[] {
                new { Text = "Tunai", Value = "Tunai" },
                new { Text = "Kredit", Value = "Kredit" },
                new { Text = "Semua", Value = "" }
            };
            cboPembelian.DataSource = items;
        }

        private void frmLapPembelian_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            this.ListKondisi();
            this.ListPembelian();
            cboKondisi.Text = "Semua";
            cboPembelian.Text = "Semua";
            cboStatJual.Text = "Semua";
            cboStatBPKB.Text = "Semua";
            cboStatBayar.SelectedIndex = 0;

            if (GlobalVar.CabangID.Contains("06"))
            {
                rbTerima.Checked = true;
                rbBeli.Checked = false;
            }
            else
            {
                rbBeli.Checked = true;
                rbTerima.Checked = false;
                rbTerima.Enabled = false;
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
                p.Workbook.Properties.Title = "LAPORAN PEMBELIAN";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 25;
                int startH = 9;

                ws.Cells[1,  1].Worksheet.Column( 1).Width =  7; // No -o
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // No DO
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 12; // No Faktur -o
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 12; // No Shipping -o
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 11; // Tanggal
                ws.Cells[1,  6].Worksheet.Column( 6).Width = 11; // Tgl. Terima
                ws.Cells[1,  7].Worksheet.Column( 7).Width = 11; // Tgl. Jual
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 11; // Tgl. JT
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 21; // Vendor
                ws.Cells[1, 10].Worksheet.Column(10).Width = 25; // Data Kendaraan - Merk/Type -o
                ws.Cells[1, 11].Worksheet.Column(11).Width =  8; // Data Kendaraan - Tahun
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Data Kendaraan - No. Rangka -o
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // Data Kendaraan - No. Mesin -o
                ws.Cells[1, 14].Worksheet.Column(14).Width = 12; // Data Kendaraan - No. Polisi
                ws.Cells[1, 15].Worksheet.Column(15).Width = 12; // Data Kendaraan - Warna
                ws.Cells[1, 16].Worksheet.Column(16).Width = 18; // Harga -o
                ws.Cells[1, 17].Worksheet.Column(17).Width = 18; // Biaya Onderdil + Lain-Lain
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18; // Potongan
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18; // Harga + Biaya
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18; // Uang Muka
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18; // Total Pembayaran
                ws.Cells[1, 22].Worksheet.Column(22).Width = 25; // Nama BPKB
                ws.Cells[1, 23].Worksheet.Column(23).Width =  10; // Status BPKB
                ws.Cells[1, 24].Worksheet.Column(24).Width = 15; // Tgl Bayar HutPemb
                ws.Cells[1, 25].Worksheet.Column(25).Width = 15; // Tgl Bayar HutPemb                 

                string Title = "LAPORAN PEMBELIAN";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;                
                ws.Cells[4, 1].Value = "Cabang      : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Kondisi      : " + cboKondisi.Text;
                ws.Cells[5, 1, 5, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1].Value = "Pembelian : " + cboPembelian.Text;
                ws.Cells[6, 1, 6, 4].Merge = true;
                ws.Cells[6, 1, 6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[7, 1].Value = "Periode     : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate);
                ws.Cells[7, 1, 7, 4].Merge = true;
                ws.Cells[7, 1, 7, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 7, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 7, 4].Style.Font.Bold = true;

                #region Generate Header

                ws.Cells[startH, 1].Value = "N0.";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NOMOR DO";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;
                
                ws.Cells[startH, 3].Value = "NOMOR FAKTUR";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;
                ws.Cells[startH, 4].Value = "NOMOR SHIPPING";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "TANGGAL";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;
                ws.Cells[startH, 6].Value = "TGL.TERIMA";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "TGL. JUAL";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;
                
                ws.Cells[startH, 8].Value = "TGL. JT";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "VENDOR";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;
                
                ws.Cells[startH, 10].Value = "DATA KENDARAAN";
                ws.Cells[startH, 10, startH, 15].Merge = true;
                ws.Cells[startH + 1, 10].Value = "MERK / TYPE";
                ws.Cells[startH + 1, 11].Value = "TAHUN";
                ws.Cells[startH + 1, 12].Value = "NO. RANGKA";
                ws.Cells[startH + 1, 13].Value = "NO. MESIN";
                ws.Cells[startH + 1, 14].Value = "NO. POLISI";
                ws.Cells[startH + 1, 15].Value = "WARNA";

                ws.Cells[startH, 16].Value = "HARGA";
                ws.Cells[startH, 16, startH + 1, 16].Merge = true;
                ws.Cells[startH, 17].Value = "BIAYA ONDERDIL + LAIN-LAIN";
                ws.Cells[startH, 17, startH + 1, 17].Merge = true;
                ws.Cells[startH, 18].Value = "POTONGAN"; //tambahan
                ws.Cells[startH, 18, startH + 1, 18].Merge = true;
                ws.Cells[startH, 19].Value = "(HARGA + BIAYA)-POT";
                ws.Cells[startH, 19, startH + 1, 19].Merge = true;

                ws.Cells[startH, 20].Value = "UANG MUKA";
                ws.Cells[startH, 20, startH + 1, 20].Merge = true;
                ws.Cells[startH, 21].Value = "TOTAL PEMBAYARAN";
                ws.Cells[startH, 21, startH + 1, 21].Merge = true;
                ws.Cells[startH, 22].Value = "NAMA BPKB";
                ws.Cells[startH, 22, startH + 1, 22].Merge = true;
                ws.Cells[startH, 23].Value = "STATUS BPKB";
                ws.Cells[startH, 23, startH + 1, 23].Merge = true;
                ws.Cells[startH, 24].Value = "TGL BAYAR HUTPEMB";
                ws.Cells[startH, 24, startH + 1, 24].Merge = true;
                ws.Cells[startH, 25].Value = "NO BUKTI PEMBYR";
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
                    ws.Cells[idx,  2].Value = dr["NoDO"];
                    ws.Cells[idx,  3].Value = dr["NoFaktur"];
                    ws.Cells[idx,  4].Value = dr["NoShipping"];
                    ws.Cells[idx,  5].Value = dr["Tanggal"];
                    ws.Cells[idx,  6].Value = dr["TglTerima"];
                    ws.Cells[idx,  7].Value = dr["TglJual"];
                    ws.Cells[idx,  8].Value = dr["TglJT"];
                    ws.Cells[idx,  9].Value = dr["Vendor"];
                    ws.Cells[idx, 10].Value = dr["MerkType"];
                    ws.Cells[idx, 11].Value = dr["Tahun"];
                    ws.Cells[idx, 12].Value = dr["NoRangka"];
                    ws.Cells[idx, 13].Value = dr["NoMesin"];
                    ws.Cells[idx, 14].Value = dr["Nopol"];
                    ws.Cells[idx, 15].Value = dr["Warna"];
                    ws.Cells[idx, 16].Value = dr["HargaJadi"];
                    ws.Cells[idx, 17].Value = dr["Biaya"];
                    ws.Cells[idx, 18].Value = dr["TotalPot"];
                    ws.Cells[idx, 19].Value = (Convert.ToDouble(Tools.isNull(dr["Biaya"], 0)) + Convert.ToDouble(Tools.isNull(dr["HargaOff"], 0)))-Convert.ToDouble(Tools.isNull(dr["TotalPot"],0));
                    ws.Cells[idx, 20].Value = dr["UangMuka"];
                    ws.Cells[idx, 21].Value = dr["AllTotal"];
                    ws.Cells[idx, 22].Value = dr["NamaBPKB"];
                    ws.Cells[idx, 23].Value = dr["StatusBPKB"];
                    ws.Cells[idx, 24].Value = dr["TglBayarPemb"];
                    ws.Cells[idx, 25].Value = dr["NOBBM"];
                    
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.CornflowerBlue);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 15].Merge = true;
                ws.Cells[idx, 1, idx, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                ws.Cells[idx, 16].Formula = "Sum(" + ws.Cells[startH + 2, 16].Address + ":" + ws.Cells[idx - 1, 16].Address + ")";
                ws.Cells[idx, 17].Formula = "Sum(" + ws.Cells[startH + 2, 17].Address + ":" + ws.Cells[idx - 1, 17].Address + ")";
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 2, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")";
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 2, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 2, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 2, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                

                ws.Cells[startH + 2, 16, idx, 21].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";     
                ws.Cells[startH + 2, 5, idx - 1, 8].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 24, idx - 1, 24].Style.Numberformat.Format = "dd-MMM-yyyy";

                ws.Cells[startH + 2, 1, idx - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 1, idx - 1, 8].Style.WrapText = true;
                ws.Cells[startH + 2, 9, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 9, idx - 1, 10].Style.WrapText = true;
                ws.Cells[startH + 2, 11, idx - 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 11, idx - 1, 11].Style.WrapText = true;
                ws.Cells[startH + 2, 12, idx - 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 12, idx - 1, 13].Style.WrapText = true;
                ws.Cells[startH + 2, 14, idx - 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 14, idx - 1, 14].Style.WrapText = true;
                ws.Cells[startH + 2, 15, idx - 1, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 15, idx - 1, 15].Style.WrapText = true;
                ws.Cells[startH + 2, 16, idx - 1, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 16, idx - 1, 20].Style.WrapText = true;

                ws.Cells[startH + 2, 21, idx - 1, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 21, idx - 1, 21].Style.WrapText = true;

                ws.Cells[startH + 2, 22, idx - 1, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 2, 22, idx - 1, 22].Style.WrapText = true;

                ws.Cells[startH + 2, 1, idx - 1, 22].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                
                ws.Cells[startH + 2, 18, idx - 1, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 18, idx - 1, 18].Style.WrapText = true;

                ws.Cells[startH + 2, 1, idx - 1, 18].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Pembelian";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                var border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                if (rbSimple.Checked == true)
                {
                    ws.Column(2).Style.Hidden = true; // No DO
                    ws.Column(5).Style.Hidden = true; // Tanggal
                    ws.Column(6).Style.Hidden = true; // Tgl. Terima
                    ws.Column(7).Style.Hidden = true; // Tgl. Jual
                    ws.Column(8).Style.Hidden = true; // Tgl. JT
                    ws.Column(9).Style.Hidden = true; // Vendor
                    ws.Column(11).Style.Hidden = true; // Data Kendaraan - Tahun
                    ws.Column(14).Style.Hidden = true; // Data Kendaraan - No. Polisi
                    ws.Column(15).Style.Hidden = true; // Data Kendaraan - Warna
                    ws.Column(17).Style.Hidden = true; // Biaya Onderdil + Lain-Lain
                    ws.Column(18).Style.Hidden = true; // Potongan
                    ws.Column(19).Style.Hidden = true; // Harga + Biaya
                    ws.Column(20).Style.Hidden = true; // Uang Muka
                    ws.Column(21).Style.Hidden = true; // Total Pembayaran
                    ws.Column(22).Style.Hidden = true; // Nama BPKB
                    ws.Column(23).Style.Hidden = true; // Status BPKB
                   

                    ws.Column(2).Hidden = true; // No DO
                    ws.Column(5).Hidden = true; // Tanggal
                    ws.Column(6).Hidden = true; // Tgl. Terima
                    ws.Column(7).Hidden = true; // Tgl. Jual
                    ws.Column(8).Hidden = true; // Tgl. JT
                    ws.Column(9).Hidden = true; // Vendor
                    ws.Column(11).Hidden = true; // Data Kendaraan - Tahun
                    ws.Column(14).Hidden = true; // Data Kendaraan - No. Polisi
                    ws.Column(15).Hidden = true; // Data Kendaraan - Warna
                    ws.Column(17).Hidden = true; // Biaya Onderdil + Lain-Lain
                    ws.Column(18).Hidden = true; // Potongan
                    ws.Column(19).Hidden = true; // Harga + Biaya
                    ws.Column(20).Hidden = true; // Uang Muka
                    ws.Column(21).Hidden = true; // Total Pembayaran
                    ws.Column(22).Hidden = true; // Nama BPKB
                    ws.Column(23).Hidden = true; // Status BPKB
                    ws.Column(24).Hidden = true; // TGL bayar pembhut
                    
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Laporan Pembelian " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
            if (rbBeli.Checked == false && rbTerima.Checked == false)
            {
                rbBeli.Checked = true;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[rsp_LapPembelian]"));
                    db.Commands[0].Parameters.Add(new Parameter("@From", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@To", SqlDbType.Date, rangeDateBox1.ToDate));

                    if (rbTerima.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, "TERIMA"));
                    }
                    else if (rbBeli.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Type", SqlDbType.VarChar, "BELI"));
                    }

                    if (!string.IsNullOrEmpty(cboKondisi.SelectedValue.ToString()))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, cboKondisi.SelectedValue));
                    }
                    if (!string.IsNullOrEmpty(cboPembelian.SelectedValue.ToString()))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Pembelian", SqlDbType.VarChar, cboPembelian.SelectedValue));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagTglJual", SqlDbType.Int, cboStatJual.SelectedIndex));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagStatBPKB", SqlDbType.Int, cboStatBPKB.SelectedIndex));
                    db.Commands[0].Parameters.Add(new Parameter("@Pembayaran", SqlDbType.Int, cboStatBayar.SelectedIndex));
                    
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

        private void urusTipeTanggal()
        {
            if (rbTerima.Checked == true)
            {
                rbTerima.Checked = true;
                rbBeli.Checked = false;
            }
            else
            {
                rbTerima.Checked = false;
                rbBeli.Checked = true;
            }
        }

        private void rbBeli_CheckedChanged(object sender, EventArgs e)
        {
            urusTipeTanggal();
        }

        private void rbTerima_CheckedChanged(object sender, EventArgs e)
        {
            urusTipeTanggal();
        }

        private void rbSimple_CheckedChanged(object sender, EventArgs e)
        {
            rbTypeChanged();
        }

        private void rbDetailed_CheckedChanged(object sender, EventArgs e)
        {
            rbTypeChanged();
        }

        private void rbTypeChanged()
        {
            if (rbSimple.Checked == true)
            {
                rbSimple.Checked = true;
                rbDetailed.Checked = false;
            }
            else if (rbDetailed.Checked == true)
            {
                rbSimple.Checked = false;
                rbDetailed.Checked = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
