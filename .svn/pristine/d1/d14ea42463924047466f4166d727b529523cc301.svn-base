using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapTutupBukuHarianTLA : ISA.Controls.BaseForm
    {
        public frmLapTutupBukuHarianTLA()
        {
            InitializeComponent();
        }

        private void frmLapTutupBukuHarianTLA_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            rbSimple.Checked = true;
            if (cboTipe.Items.Count > 0)
            {
                cboTipe.SelectedIndex = 0;
            }

            if (cboPenjualan.Items.Count > 0)
            {
                cboPenjualan.SelectedIndex = 0;
            }
        }

        private void cboTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipe.SelectedIndex >= 0 && cboTipe.SelectedIndex <= cboTipe.Items.Count)
            {

            }
            else
            {
                if (cboTipe.Items.Count > 0)
                {
                    cboTipe.SelectedIndex = 0;
                }
            }
        }
        
        private void cboPenjualan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPenjualan.SelectedIndex == 0 || cboPenjualan.SelectedIndex == 1 || cboPenjualan.SelectedIndex == 2)
            {

            }
            else
            {
                if (cboPenjualan.Items.Count > 0)
                {
                    cboPenjualan.SelectedIndex = 0;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate.Value > rangeDateBox1.ToDate.Value)
            {
                DateTime temp = rangeDateBox1.FromDate.Value;
                rangeDateBox1.FromDate = rangeDateBox1.ToDate;
                rangeDateBox1.ToDate = temp;
            }

            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                DataTable dtAngsuranTitipan = new DataTable(); 
                if (cboTipe.SelectedIndex == 0) // Angsuran
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanANG_FILTER_TANGGAL"));
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanANG_VIA_TITIPAN_FILTER_TANGGAL")); 
                }
                else if (cboTipe.SelectedIndex == 1) // Uang Muka
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanUM_FILTER_TANGGAL"));
                }
                else if (cboTipe.SelectedIndex == 2) // Pelunasan
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanPLS_FILTER_TANGGAL"));
                }
                else if (cboTipe.SelectedIndex == 3) // Denda/Bunga
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanDND_FILTER_TANGGAL"));
                }
                else if (cboTipe.SelectedIndex == 4) // Titipan
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanTTP_FILTER_TANGGAL"));
                }
                else if (cboTipe.SelectedIndex == 5) // Tarikan
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanTRK_FILTER_TANGGAL"));
                }
                else if (cboTipe.SelectedIndex == 6) // Administrasi
                {
                    db.Commands.Add(db.CreateCommand("rsp_PenerimaanADM_FILTER_TANGGAL"));
                }

                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                
                if(cboPenjualan.SelectedIndex == 0) // baru
                {
                    db.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "BARU"));
                }
                else if(cboPenjualan.SelectedIndex == 1) // bekas
                {
                    db.Commands[0].Parameters.Add(new Parameter("@FlagSource", SqlDbType.VarChar, "ORI"));
                }
                else // semua
                {
                }

                if (cboTipe.SelectedIndex == 0) // Angsuran
                {
                    for (int ctr = 0; ctr <= db.Commands[0].Parameters.Count - 1; ctr++)
                    {
                        db.Commands[1].Parameters.Add(db.Commands[0].Parameters[ctr]); 
                    }
                    dtAngsuranTitipan = db.Commands[1].ExecuteDataTable(); 
                }


                dt = db.Commands[0].ExecuteDataTable();

                if (dt.Rows.Count > 0)
                {
                    DataView dv = dt.DefaultView;
                    dv.Sort = "NoKwitansi asc";
                    DataTable sortedDT = dv.ToTable();

                    if (cboTipe.SelectedIndex == 0) // Angsuran
                    {
                        DataView dvAngTitipan = dtAngsuranTitipan.DefaultView;
                        dvAngTitipan.Sort = "NoKwitansi asc";
                        DataTable sortedDTAngTitipan = dvAngTitipan.ToTable();

                        if (rbSimple.Checked == true)
                        {
                            LapHarianANG(sortedDT, sortedDTAngTitipan);
                        }
                        else
                        {
                            LapHarianANG(dt, sortedDTAngTitipan);
                        }
                    }
                    else if (cboTipe.SelectedIndex == 1) // Uang Muka
                    {
                        if (rbSimple.Checked == true)
                        {
                            LapHarianUM(sortedDT);
                        }
                        else
                        {
                            LapHarianUM(dt);
                        }
                    }
                    else if (cboTipe.SelectedIndex == 2) // Pelunasan
                    {
                        if (rbSimple.Checked == true)
                        {
                            LapHarianPLS(sortedDT);
                        }
                        else
                        {
                            LapHarianPLS(dt);
                        }
                    }
                    else if (cboTipe.SelectedIndex == 3) // Denda
                    {
                        if (rbSimple.Checked == true)
                        {
                            LapHarianDND(sortedDT);
                        }
                        else
                        {
                            LapHarianDND(dt);
                        }
                    }
                    else if (cboTipe.SelectedIndex == 4) // Titipan
                    {
                        if (rbSimple.Checked == true)
                        {
                            LapHarianTTP(sortedDT);
                        }
                        else
                        {
                            LapHarianTTP(dt);
                        }
                    }
                    else if (cboTipe.SelectedIndex == 5) // Tarikan
                    {
                        if (rbSimple.Checked == true)
                        {
                            LapHarianTRK(sortedDT);
                        }
                        else
                        {
                            LapHarianTRK(dt);
                        }
                    }
                    else if (cboTipe.SelectedIndex == 6) // Administrasi
                    {
                        if (rbSimple.Checked == true)
                        {
                            LapHarianADM(sortedDT);
                        }
                        else
                        {
                            LapHarianADM(dt);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada data ditemukan!");
                }
            }
        }

       
        private void LapHarianANG(DataTable dt,DataTable dtAngTitipan)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR PENERIMAAN ANGSURAN";
                p.Workbook.Protection.LockStructure = true;
                
            
                #region "Worksheet No.1"
                
                p.Workbook.Worksheets.Add("Pen. ANG");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");
              

                ws.Name = "Pen. ANG"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 14;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width = 15; // tanggal
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // NoKwitansi -o 
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 25; // Customer -o
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 12; // NoKontrak -o
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 12; // NoAR -o
                ws.Cells[1,  6].Worksheet.Column( 6).Width =  8; // Keterangan -o
                ws.Cells[1,  7].Worksheet.Column( 7).Width =  8; // Ang Ke -o
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 15; // CH/GB Mundur
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 18; // Pokok
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // Bunga
                ws.Cells[1, 11].Worksheet.Column(11).Width = 18; // NominalPembayaran -o
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // NoBuktiPokok
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // NoBuktiBunga
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // NoBuktiPBL

                string Title = "DAFTAR PENERIMAAN ANGSURAN";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "Ang Ke";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "CH/GB Mundur";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "Pokok";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "Bunga";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "Nominal Pembayaran";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "No. Bukti Pokok";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "No. Bukti Bunga";
                ws.Cells[startH, 13, startH + 1, 13].Merge = true;

                ws.Cells[startH, 14].Value = "No. Bukti PBL";
                ws.Cells[startH, 14, startH + 1, 14].Merge = true;


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
                    ws.Cells[idx, 1].Value = dr["Tanggal"];
                    ws.Cells[idx, 2].Value = dr["NoKwitansi"];
                    ws.Cells[idx, 3].Value = dr["Nama"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["NoTrans"];
                    ws.Cells[idx, 6].Value = dr["KodeTrans"];
                    ws.Cells[idx, 7].Value = dr["AngsuranKe"];
                    ws.Cells[idx, 8].Value = "";
                    ws.Cells[idx, 9].Value = dr["NominalPokok"];
                    ws.Cells[idx,10].Value = dr["Bunga"];
                    ws.Cells[idx,11].Value = dr["NominalAR"];
                    ws.Cells[idx,12].Value = dr["NoBuktiPokok"];
                    ws.Cells[idx,13].Value = dr["NoBuktiBunga"];
                    ws.Cells[idx,14].Value = dr["NoBuktiPBL"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 8].Merge = true;
                ws.Cells[idx, 1, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 1, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx,10].Formula = "Sum(" + ws.Cells[startH + 1,10].Address + ":" + ws.Cells[idx - 1,10].Address + ")";
                ws.Cells[idx,11].Formula = "Sum(" + ws.Cells[startH + 1,11].Address + ":" + ws.Cells[idx - 1,11].Address + ")";
                
                ws.Cells[startH + 2, 9, idx, 11].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 9, idx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2,  2, idx - 1,  8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 12, idx - 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                
                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Angsuran";
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
                    ws.Column( 1).Style.Hidden = true; // tanggal
                    ws.Column( 8).Style.Hidden = true; // CH/GB Mundur
                    ws.Column( 9).Style.Hidden = true; // Pokok
                    ws.Column(10).Style.Hidden = true; // Bunga
                    ws.Column(12).Style.Hidden = true; // NoBuktiPokok
                    ws.Column(13).Style.Hidden = true; // NoBuktiBunga
                    ws.Column(14).Style.Hidden = true; // NoBuktiPBL

                    ws.Column( 1).Hidden = true; // tanggal
                    ws.Column( 8).Hidden = true; // CH/GB Mundur
                    ws.Column( 9).Hidden = true; // Pokok
                    ws.Column(10).Hidden = true; // Bunga
                    ws.Column(12).Hidden = true; // NoBuktiPokok
                    ws.Column(13).Hidden = true; // NoBuktiBunga
                    ws.Column(14).Hidden = true; // NoBuktiPBL
                }

                #endregion


                #region "Worksheet No.2"

                p.Workbook.Worksheets.Add("Pen. ANG - TITIPAN");
                ws = p.Workbook.Worksheets[2];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. ANG - TITIPAN"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                MaxCol = 14;
                startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 15; // tanggal
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12; // NoKwitansi -o 
                ws.Cells[1, 3].Worksheet.Column(3).Width = 25; // Customer -o
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12; // NoKontrak -o
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12; // NoAR -o
                ws.Cells[1, 6].Worksheet.Column(6).Width = 8; // Keterangan -o
                ws.Cells[1, 7].Worksheet.Column(7).Width = 8; // Ang Ke -o
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15; // CH/GB Mundur
                ws.Cells[1, 9].Worksheet.Column(9).Width = 18; // Pokok
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // Bunga
                ws.Cells[1, 11].Worksheet.Column(11).Width = 18; // NominalPembayaran -o
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // NoBuktiPokok
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // NoBuktiBunga
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // NoBuktiPBL

                Title = "DAFTAR PENERIMAAN ANGSURAN - BENTUK PEMBAYARAN TITIPAN";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "Ang Ke";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "CH/GB Mundur";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "Pokok";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "Bunga";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "Nominal Pembayaran";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "No. Bukti Pokok";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "No. Bukti Bunga";
                ws.Cells[startH, 13, startH + 1, 13].Merge = true;

                ws.Cells[startH, 14].Value = "No. Bukti PBL";
                ws.Cells[startH, 14, startH + 1, 14].Merge = true;


                ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

                #endregion

                #region FillData
                idx = startH + 2;
                no = 1;

                foreach (DataRow dr in dtAngTitipan.Rows)
                {
                    ws.Cells[idx, 1].Value = dr["Tanggal"];
                    ws.Cells[idx, 2].Value = dr["NoKwitansi"];
                    ws.Cells[idx, 3].Value = dr["Nama"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["NoTrans"];
                    ws.Cells[idx, 6].Value = dr["KodeTrans"];
                    ws.Cells[idx, 7].Value = dr["AngsuranKe"];
                    ws.Cells[idx, 8].Value = "";
                    ws.Cells[idx, 9].Value = dr["NominalPokok"];
                    ws.Cells[idx, 10].Value = dr["Bunga"];
                    ws.Cells[idx, 11].Value = dr["NominalAR"];
                    ws.Cells[idx, 12].Value = dr["NoBuktiPokok"];
                    ws.Cells[idx, 13].Value = dr["NoBuktiBunga"];
                    ws.Cells[idx, 14].Value = dr["NoBuktiPBL"];
                    idx++;
                }

                idx = (idx==startH + 2?idx+1:idx);
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 8].Merge = true;
                ws.Cells[idx, 1, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 1, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 1, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 1, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";

                ws.Cells[startH + 2, 9, idx, 11].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 9, idx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 12, idx - 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Angsuran";
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                border = ws.Cells[startH, 1, idx, MaxCol].Style.Border;
                border.Bottom.Style =
                 border.Top.Style =
                 border.Left.Style =
                 border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                if (rbSimple.Checked == true)
                {
                    ws.Column(1).Style.Hidden = true; // tanggal
                    ws.Column(8).Style.Hidden = true; // CH/GB Mundur
                    ws.Column(9).Style.Hidden = true; // Pokok
                    ws.Column(10).Style.Hidden = true; // Bunga
                    ws.Column(12).Style.Hidden = true; // NoBuktiPokok
                    ws.Column(13).Style.Hidden = true; // NoBuktiBunga
                    ws.Column(14).Style.Hidden = true; // NoBuktiPBL

                    ws.Column(1).Hidden = true; // tanggal
                    ws.Column(8).Hidden = true; // CH/GB Mundur
                    ws.Column(9).Hidden = true; // Pokok
                    ws.Column(10).Hidden = true; // Bunga
                    ws.Column(12).Hidden = true; // NoBuktiPokok
                    ws.Column(13).Hidden = true; // NoBuktiBunga
                    ws.Column(14).Hidden = true; // NoBuktiPBL
                }


                #endregion 


                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Penerimaan Angsuran " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapHarianUM(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR PENERIMAAN UANG MUKA";

                p.Workbook.Worksheets.Add("Pen. UM");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. UM"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 10;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 15; // tanggal
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12; // NoKwitansi -o
                ws.Cells[1, 3].Worksheet.Column(3).Width = 25; // Customer -o
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12; // NoKontrak -o
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12; // NoAR -o
                ws.Cells[1, 6].Worksheet.Column(6).Width =  8; // Keterangan -o
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15; // CH/GB Mundur
                ws.Cells[1, 8].Worksheet.Column(8).Width = 18; // NominalPembayaran -o
                ws.Cells[1, 9].Worksheet.Column(9).Width = 18; // NoBukti
                ws.Cells[1,10].Worksheet.Column(10).Width = 18; // NoBuktiPBL

                string Title = "DAFTAR PENERIMAAN UANG MUKA";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "CH/GB Mundur";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "Nominal Pembayaran";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "No Bukti";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "No Bukti PBL";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

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
                    ws.Cells[idx, 1].Value = dr["Tanggal"];
                    ws.Cells[idx, 2].Value = dr["NoKwitansi"];
                    ws.Cells[idx, 3].Value = dr["Nama"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["NoTrans"];
                    ws.Cells[idx, 6].Value = dr["KodeTrans"];
                    ws.Cells[idx, 7].Value = "";
                    ws.Cells[idx, 8].Value = dr["NominalAR"];
                    ws.Cells[idx, 9].Value = dr["NoBuktiUang"];
                    ws.Cells[idx, 10].Value = dr["NoBuktiPBL"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 6].Merge = true;
                ws.Cells[idx, 1, idx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 1, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";
                
                ws.Cells[startH + 2, 8, idx, 8].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 8, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1,  7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 9, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Uang Muka";
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
                    ws.Column(1).Style.Hidden = true; // tanggal
                    ws.Column(7).Style.Hidden = true; // CH/GB Mundur
                    ws.Column(9).Style.Hidden = true; // NoBukti
                    ws.Column(10).Style.Hidden = true; // NoBuktiPBL

                    ws.Column(1).Hidden = true; // tanggal
                    ws.Column(7).Hidden = true; // CH/GB Mundur
                    ws.Column(9).Hidden = true; // NoBukti
                    ws.Column(10).Hidden = true; // NoBuktiPBL
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Penerimaan Uang Muka " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapHarianPLS(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR PENERIMAAN PELUNASAN";

                p.Workbook.Worksheets.Add("Pen. PLS");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. PLS"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 15;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width = 15; // tanggal
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // NoKwitansi -o
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 25; // Customer -o
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 12; // NoKontrak -o
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 12; // NoAR -o
                ws.Cells[1,  6].Worksheet.Column( 6).Width =  8; // Keterangan -o
                ws.Cells[1,  7].Worksheet.Column( 7).Width =  8; // Ang Ke -o
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 15; // CH/GB Mundur
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 18; // Pokok
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // Bunga
                ws.Cells[1, 11].Worksheet.Column(11).Width = 18; // Nominal -o
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // Potongan
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // NoBukti Pokok
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // NoBukti Bunga
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // NoBukti PBL

                string Title = "DAFTAR PENERIMAAN PELUNASAN";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "Ang Ke";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "CH/GB Mundur";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "Jumlah";
                ws.Cells[startH, 9, startH, 12].Merge = true;

                ws.Cells[startH + 1,  9].Value = "Pokok";
                ws.Cells[startH + 1, 10].Value = "Bunga";
                ws.Cells[startH + 1, 11].Value = "Nominal";
                ws.Cells[startH + 1, 12].Value = "Pot. Pls.";

                ws.Cells[startH, 13].Value = "No Bukti Pokok";
                ws.Cells[startH, 13, startH + 1, 13].Merge = true;

                ws.Cells[startH, 14].Value = "No Bukti Bunga";
                ws.Cells[startH, 14, startH + 1, 14].Merge = true;

                ws.Cells[startH, 15].Value = "No Bukti PBL";
                ws.Cells[startH, 15, startH + 1, 15].Merge = true;

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
                    ws.Cells[idx,  1].Value = dr["Tanggal"];
                    ws.Cells[idx,  2].Value = dr["NoKwitansi"];
                    ws.Cells[idx,  3].Value = dr["Nama"];
                    ws.Cells[idx,  4].Value = dr["NoBukti"];
                    ws.Cells[idx,  5].Value = dr["NoTrans"];
                    ws.Cells[idx,  6].Value = dr["KodeTrans"];
                    ws.Cells[idx,  7].Value = dr["AngsuranKe"];
                    ws.Cells[idx,  8].Value = "";
                    ws.Cells[idx,  9].Value = dr["NominalPokok"];
                    ws.Cells[idx, 10].Value = dr["Bunga"];
                    ws.Cells[idx, 11].Value = dr["NominalAR"];
                    ws.Cells[idx, 12].Value = dr["Potongan"];
                    ws.Cells[idx, 13].Value = dr["NoBuktiPokok"];
                    ws.Cells[idx, 14].Value = dr["NoBuktiBunga"];
                    ws.Cells[idx, 15].Value = dr["NoBuktiPBL"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 8].Merge = true;
                ws.Cells[idx, 1, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx,  9].Formula = "Sum(" + ws.Cells[startH + 1,  9].Address + ":" + ws.Cells[idx - 1,  9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 1, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")"; 
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 1, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 12].Formula = "Sum(" + ws.Cells[startH + 1, 12].Address + ":" + ws.Cells[idx - 1, 12].Address + ")";
                
                ws.Cells[startH + 2, 9, idx, 12].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 9, idx, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 13, idx - 1, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Pelunasan";
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
                    ws.Column( 1).Style.Hidden = true; // tanggal
                    ws.Column( 8).Style.Hidden = true; // CH/GB Mundur
                    ws.Column( 9).Style.Hidden = true; // Pokok
                    ws.Column(10).Style.Hidden = true; // Bunga
                    ws.Column(12).Style.Hidden = true; // Potongan
                    ws.Column(13).Style.Hidden = true; // NoBukti Pokok
                    ws.Column(14).Style.Hidden = true; // NoBukti Bunga
                    ws.Column(15).Style.Hidden = true; // NoBukti PBL
                    
                    ws.Column( 1).Hidden = true; // tanggal
                    ws.Column( 8).Hidden = true; // CH/GB Mundur
                    ws.Column( 9).Hidden = true; // Pokok
                    ws.Column(10).Hidden = true; // Bunga
                    ws.Column(12).Hidden = true; // Potongan
                    ws.Column(13).Hidden = true; // NoBukti Pokok
                    ws.Column(14).Hidden = true; // NoBukti Bunga
                    ws.Column(15).Hidden = true; // NoBukti PBL
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Penerimaan Pelunasan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapHarianDND(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR PENERIMAAN DENDA/UMBUNGA";

                p.Workbook.Worksheets.Add("Pen. DND");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. DND"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 12;
                int startH = 7;

                ws.Cells[1,  1].Worksheet.Column( 1).Width = 15; // tanggal
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12; // NoKwitansi -o
                ws.Cells[1,  3].Worksheet.Column( 3).Width = 25; // Customer -o
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 12; // NoKontrak -o
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 12; // NoAR -o
                ws.Cells[1,  6].Worksheet.Column( 6).Width =  8; // Keterangan -o
                ws.Cells[1,  7].Worksheet.Column( 7).Width =  8; // Ang Ke -o
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 15; // CH/GB Mundur
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 18; // A/R - Denda tapinya -o
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // Potongan - Denda tapinya
                ws.Cells[1, 11].Worksheet.Column(11).Width = 18; // NoBukti Denda
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // NoBukti PBL

                string Title = "DAFTAR PENERIMAAN DENDA/UMBUNGA";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "Ang Ke";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "CH/GB Mundur";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "Jumlah";
                ws.Cells[startH, 9, startH, 10].Merge = true;

                ws.Cells[startH + 1, 9].Value = "Jumlah Denda";
                ws.Cells[startH + 1, 10].Value = "Potongan";

                ws.Cells[startH, 11].Value = "No Bukti";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "No Bukti PBL";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

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
                    ws.Cells[idx,  1].Value = dr["Tanggal"];
                    ws.Cells[idx,  2].Value = dr["NoKwitansi"];
                    ws.Cells[idx,  3].Value = dr["Nama"];
                    ws.Cells[idx,  4].Value = dr["NoBukti"];
                    ws.Cells[idx,  5].Value = dr["NoTrans"];
                    ws.Cells[idx,  6].Value = dr["KodeTrans"];
                    ws.Cells[idx,  7].Value = dr["AngsuranKe"];
                    ws.Cells[idx,  8].Value = "";
                    ws.Cells[idx,  9].Value = dr["NominalAR"];
                    ws.Cells[idx, 10].Value = dr["Potongan"];
                    ws.Cells[idx, 11].Value = dr["NoBuktiDND"];
                    ws.Cells[idx, 12].Value = dr["NoBuktiPBL"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 8].Merge = true;
                ws.Cells[idx, 1, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan potongan denda 
                ws.Cells[idx,  9].Formula = "Sum(" + ws.Cells[startH + 1,  9].Address + ":" + ws.Cells[idx - 1,  9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 1, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";

                ws.Cells[startH + 2, 9, idx, 10].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 9, idx, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 11, idx - 1, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Denda/UMBunga";
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
                    ws.Column( 1).Style.Hidden = true; // tanggal
                    ws.Column( 8).Style.Hidden = true; // CH/GB Mundur
                    ws.Column(10).Style.Hidden = true; // Potongan - Denda tapinya
                    ws.Column(11).Style.Hidden = true; // NoBukti Denda
                    ws.Column(12).Style.Hidden = true; // NoBukti PBL
                    
                    ws.Column( 1).Hidden = true; // tanggal
                    ws.Column( 8).Hidden = true; // CH/GB Mundur
                    ws.Column(10).Hidden = true; // Potongan - Denda tapinya
                    ws.Column(11).Hidden = true; // NoBukti Denda
                    ws.Column(12).Hidden = true; // NoBukti PBL
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Penerimaan Denda_UMBunga " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapHarianTTP(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR PENERIMAAN TITIPAN";

                p.Workbook.Worksheets.Add("Pen. TTP");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. TTP"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";


                int MaxCol = 9;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 15; // tanggal
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12; // NoKwitansi -o
                ws.Cells[1, 3].Worksheet.Column(3).Width = 25; // Customer -o
                ws.Cells[1, 4].Worksheet.Column(4).Width = 15; // CH/GB Mundur
                ws.Cells[1, 5].Worksheet.Column(5).Width = 18; // A/R -o
                ws.Cells[1, 6].Worksheet.Column(6).Width = 18; // Terident -o
                ws.Cells[1, 7].Worksheet.Column(7).Width = 18; // Sisa -o
                ws.Cells[1, 8].Worksheet.Column(8).Width = 18; // NoBukti
                ws.Cells[1, 9].Worksheet.Column(9).Width = 18; // No A/R

                string Title = "DAFTAR PENERIMAAN TITIPAN";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "CH/GB Mundur";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "Nominal Pembayaran";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Nominal Terident";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "Nominal Sisa";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;
                
                ws.Cells[startH, 8].Value = "No Bukti";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "No A/R";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

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
                    ws.Cells[idx, 1].Value = dr["Tanggal"];
                    ws.Cells[idx, 2].Value = dr["NoKwitansi"];
                    ws.Cells[idx, 3].Value = dr["Nama"];
                    ws.Cells[idx, 4].Value = "";
                    ws.Cells[idx, 5].Value = dr["NominalAR"];
                    ws.Cells[idx, 6].Value = dr["NominalTeriden"];
                    ws.Cells[idx, 7].Value = dr["NominalSisa"];
                    ws.Cells[idx, 8].Value = dr["NoBuktiUang"];
                    ws.Cells[idx, 9].Value = dr["NoAR"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 4].Merge = true;
                ws.Cells[idx, 1, idx, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 1, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";

                ws.Cells[startH + 2, 5, idx, 7].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 5, idx, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 8, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Titipan";
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
                    ws.Column(1).Style.Hidden = true; // tanggal
                    ws.Column(4).Style.Hidden = true; // CH/GB Mundur
                    ws.Column(6).Style.Hidden = true; // NoBukti
                    ws.Column(7).Style.Hidden = true; // NoAR

                    ws.Column(1).Hidden = true; // tanggal
                    ws.Column(4).Hidden = true; // CH/GB Mundur
                    ws.Column(6).Hidden = true; // NoBukti
                    ws.Column(7).Hidden = true; // NoAR
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Penerimaan Titipan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapHarianTRK(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR TRANSAKSI TARIKAN";

                p.Workbook.Worksheets.Add("Pen. TRK");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. TRK"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 15;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 15; // tanggal
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12; // NoKwitansi -o
                ws.Cells[1, 3].Worksheet.Column(3).Width = 25; // Customer -o
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12; // NoKontrak -o
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12; // NoAR -o
                ws.Cells[1, 6].Worksheet.Column(6).Width =  8; // Keterangan -o
                ws.Cells[1, 7].Worksheet.Column(7).Width =  8; // Ang Ke -o
                ws.Cells[1, 8].Worksheet.Column(8).Width = 15; // CH/GB Mundur
                ws.Cells[1, 9].Worksheet.Column(9).Width = 18; // Pokok
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // Bunga
                ws.Cells[1, 11].Worksheet.Column(11).Width = 18; // NominalPembayaran -o
                ws.Cells[1, 12].Worksheet.Column(12).Width = 18; // NoBuktiPokok
                ws.Cells[1, 13].Worksheet.Column(13).Width = 18; // NoBuktiBunga
                ws.Cells[1, 14].Worksheet.Column(14).Width = 18; // NoBuktiPBL
                ws.Cells[1, 15].Worksheet.Column(15).Width = 18; // HargaEstimasiMotor

                string Title = "DAFTAR TRANSAKSI TARIKAN";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "Ang Ke";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "CH/GB Mundur";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "Pokok";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "Bunga";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

                ws.Cells[startH, 11].Value = "Nominal Pembayaran";
                ws.Cells[startH, 11, startH + 1, 11].Merge = true;

                ws.Cells[startH, 12].Value = "No. Bukti Pokok";
                ws.Cells[startH, 12, startH + 1, 12].Merge = true;

                ws.Cells[startH, 13].Value = "No. Bukti Bunga";
                ws.Cells[startH, 13, startH + 1, 13].Merge = true;

                ws.Cells[startH, 14].Value = "No. Bukti PBL";
                ws.Cells[startH, 14, startH + 1, 14].Merge = true;

                ws.Cells[startH, 15].Value = "Harga Estimasi";
                ws.Cells[startH, 15, startH + 1, 15].Merge = true;

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
                    ws.Cells[idx, 1].Value = dr["Tanggal"];
                    ws.Cells[idx, 2].Value = dr["NoKwitansi"];
                    ws.Cells[idx, 3].Value = dr["Nama"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["NoTrans"];
                    ws.Cells[idx, 6].Value = dr["KodeTrans"];
                    ws.Cells[idx, 7].Value = dr["AngsuranKe"];
                    ws.Cells[idx, 8].Value = "";
                    ws.Cells[idx, 9].Value = dr["NominalPokok"];
                    ws.Cells[idx, 10].Value = dr["Bunga"];
                    ws.Cells[idx, 11].Value = dr["NominalAR"];
                    ws.Cells[idx, 12].Value = dr["NoBuktiPokok"];
                    ws.Cells[idx, 13].Value = dr["NoBuktiBunga"];
                    ws.Cells[idx, 14].Value = dr["NoBuktiPBL"];
                    ws.Cells[idx, 15].Value = dr["TarikanEstimasiHrgMotor"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 8].Merge = true;
                ws.Cells[idx, 1, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx, 9].Formula = "Sum(" + ws.Cells[startH + 1, 9].Address + ":" + ws.Cells[idx - 1, 9].Address + ")";
                ws.Cells[idx, 10].Formula = "Sum(" + ws.Cells[startH + 1, 10].Address + ":" + ws.Cells[idx - 1, 10].Address + ")";
                ws.Cells[idx, 11].Formula = "Sum(" + ws.Cells[startH + 1, 11].Address + ":" + ws.Cells[idx - 1, 11].Address + ")";
                ws.Cells[idx, 15].Formula = "Sum(" + ws.Cells[startH + 1, 15].Address + ":" + ws.Cells[idx - 1, 15].Address + ")";

                ws.Cells[startH + 2, 9, idx, 11].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 9, idx, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                ws.Cells[startH + 2, 15, idx, 15].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 15, idx, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 12, idx - 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Transaksi Tarikan";
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
                    ws.Column( 1).Style.Hidden = true; // tanggal
                    ws.Column( 8).Style.Hidden = true; // CH/GB Mundur
                    ws.Column( 9).Style.Hidden = true; // Pokok
                    ws.Column(10).Style.Hidden = true; // Bunga
                    ws.Column(12).Style.Hidden = true; // NoBuktiPokok
                    ws.Column(13).Style.Hidden = true; // NoBuktiBunga
                    ws.Column(14).Style.Hidden = true; // NoBuktiPBL
                    ws.Column(11).Style.Hidden = true; // Nominal Pembayaran
                    //ws.Column(15).Style.Hidden = true; // HargaEstimasiMotor
                    
                    ws.Column( 1).Hidden = true; // tanggal
                    ws.Column( 8).Hidden = true; // CH/GB Mundur
                    ws.Column( 9).Hidden = true; // Pokok
                    ws.Column(10).Hidden = true; // Bunga
                    ws.Column(12).Hidden = true; // NoBuktiPokok
                    ws.Column(13).Hidden = true; // NoBuktiBunga
                    ws.Column(14).Hidden = true; // NoBuktiPBL
                    ws.Column(11).Hidden = true; // Nominal Pembayaran
                   // ws.Column(15).Hidden = true; // HargaEstimasiMotor
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Transaksi Tarikan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

        private void LapHarianADM(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "DAFTAR PENERIMAAN ADMINISTRASI";

                p.Workbook.Worksheets.Add("Pen. UM");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Protection.IsProtected = true;
                ws.Protection.AllowSelectLockedCells = false;
                ws.Protection.AllowSelectUnlockedCells = false;
                ws.Protection.SetPassword("bukaproteksi");

                ws.Name = "Pen. UM"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 10;
                int startH = 7;

                ws.Cells[1, 1].Worksheet.Column(1).Width = 15; // tanggal
                ws.Cells[1, 2].Worksheet.Column(2).Width = 12; // NoKwitansi -o
                ws.Cells[1, 3].Worksheet.Column(3).Width = 25; // Customer -o
                ws.Cells[1, 4].Worksheet.Column(4).Width = 12; // NoKontrak -o
                ws.Cells[1, 5].Worksheet.Column(5).Width = 12; // NoAR -o
                ws.Cells[1, 6].Worksheet.Column(6).Width = 8; // Keterangan -o
                ws.Cells[1, 7].Worksheet.Column(7).Width = 15; // CH/GB Mundur
                ws.Cells[1, 8].Worksheet.Column(8).Width = 18; // NominalPembayaran -o
                ws.Cells[1, 9].Worksheet.Column(9).Width = 18; // NoBukti
                ws.Cells[1, 10].Worksheet.Column(10).Width = 18; // NoBuktiPBL

                string Title = "DAFTAR PENERIMAAN ADMINISTRASI";

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

                ws.Cells[startH, 1].Value = "Tanggal";
                ws.Cells[startH, 1, startH + 1, 1].Merge = true;

                ws.Cells[startH, 2].Value = "NoKwitansi";
                ws.Cells[startH, 2, startH + 1, 2].Merge = true;

                ws.Cells[startH, 3].Value = "Customer";
                ws.Cells[startH, 3, startH + 1, 3].Merge = true;

                ws.Cells[startH, 4].Value = "NoKontrak";
                ws.Cells[startH, 4, startH + 1, 4].Merge = true;

                ws.Cells[startH, 5].Value = "No. AR";
                ws.Cells[startH, 5, startH + 1, 5].Merge = true;

                ws.Cells[startH, 6].Value = "Ket.";
                ws.Cells[startH, 6, startH + 1, 6].Merge = true;

                ws.Cells[startH, 7].Value = "CH/GB Mundur";
                ws.Cells[startH, 7, startH + 1, 7].Merge = true;

                ws.Cells[startH, 8].Value = "Nominal Pembayaran";
                ws.Cells[startH, 8, startH + 1, 8].Merge = true;

                ws.Cells[startH, 9].Value = "No Bukti";
                ws.Cells[startH, 9, startH + 1, 9].Merge = true;

                ws.Cells[startH, 10].Value = "No Bukti PBL";
                ws.Cells[startH, 10, startH + 1, 10].Merge = true;

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
                    ws.Cells[idx, 1].Value = dr["Tanggal"];
                    ws.Cells[idx, 2].Value = dr["NoKwitansi"];
                    ws.Cells[idx, 3].Value = dr["Nama"];
                    ws.Cells[idx, 4].Value = dr["NoBukti"];
                    ws.Cells[idx, 5].Value = dr["NoTrans"];
                    ws.Cells[idx, 6].Value = dr["KodeTrans"];
                    ws.Cells[idx, 7].Value = "";
                    ws.Cells[idx, 8].Value = dr["NominalAR"];
                    ws.Cells[idx, 9].Value = dr["NoBuktiUang"];
                    ws.Cells[idx, 10].Value = dr["NoBuktiPBL"];
                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 6].Merge = true;
                ws.Cells[idx, 1, idx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // AR dan denda 
                ws.Cells[idx, 8].Formula = "Sum(" + ws.Cells[startH + 1, 8].Address + ":" + ws.Cells[idx - 1, 8].Address + ")";

                ws.Cells[startH + 2, 8, idx, 8].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
                ws.Cells[startH + 2, 8, idx, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
                ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[startH + 2, 2, idx - 1, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 2, 9, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Daftar Penerimaan Administrasi";
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
                    ws.Column(1).Style.Hidden = true; // tanggal
                    ws.Column(7).Style.Hidden = true; // CH/GB Mundur
                    ws.Column(9).Style.Hidden = true; // NoBukti
                    ws.Column(10).Style.Hidden = true; // NoBuktiPBL

                    ws.Column(1).Hidden = true; // tanggal
                    ws.Column(7).Hidden = true; // CH/GB Mundur
                    ws.Column(9).Hidden = true; // NoBukti
                    ws.Column(10).Hidden = true; // NoBuktiPBL
                }

                #region Output
                Byte[] bin = p.GetAsByteArray();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Daftar Penerimaan Administrasi " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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
            if(rbSimple.Checked == true)
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
    }
}
