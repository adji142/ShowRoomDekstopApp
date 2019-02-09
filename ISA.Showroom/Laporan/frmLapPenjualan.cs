using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Reporting.WinForms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ISA.Showroom.Class;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapPenjualan : ISA.Controls.BaseForm
    {
        public frmLapPenjualan()
        {
            InitializeComponent();
        }

        private void GenerateExcel(DataTable dt)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                String statusLunas = "";
                switch(cboStatusLunas.SelectedIndex)
                {
                    case 0 : statusLunas = "Semua"; break;
                    case 1 : statusLunas = "Belum Lunas"; break;
                    case 2 : statusLunas = "Lunas"; break;
                }

                p.Workbook.Properties.Author = "SAS OTOMOTIF";
                p.Workbook.Properties.Title = "LAPORAN PENJUALAN";

                p.Workbook.Worksheets.Add("Stock");
                ExcelWorksheet ws = p.Workbook.Worksheets[1];

                ws.Name = "Sheet1"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri";

                int MaxCol = 37;
                int startH = 8;

                // tambahin sales dan alamat
                ws.Cells[1,  1].Worksheet.Column( 1).Width =  7;    //"N0.";
                ws.Cells[1,  2].Worksheet.Column( 2).Width = 12;    //"NO. TRANS";
                ws.Cells[1,  3].Worksheet.Column (3).Width = 12;    //"NO. BUKTI";
                ws.Cells[1,  4].Worksheet.Column( 4).Width = 15;    //"TGL. JUAL";
                ws.Cells[1,  5].Worksheet.Column( 5).Width = 35;    //"NAMA PELANGGAN";
                ws.Cells[1,  6].Worksheet.Column( 6).Width = 35;    //"KECAMATAN";
                ws.Cells[1,  7].Worksheet.Column( 7).Width = 25;    //"NAMA SALES";
                ws.Cells[1,  8].Worksheet.Column( 8).Width = 20;    //"JENIS PENJUALAN";
                ws.Cells[1,  9].Worksheet.Column( 9).Width = 15;    //"TIPE BUNGA";
                ws.Cells[1,  10].Worksheet.Column( 10).Width = 12;    //"TEMPO";
                ws.Cells[1, 11].Worksheet.Column(11).Width = 20;    //"MEREK";
                ws.Cells[1, 12].Worksheet.Column(12).Width = 25;    //"KODE TIPE";
                ws.Cells[1, 13].Worksheet.Column(13).Width = 25;    //"NAMA TIPE";
                ws.Cells[1, 14].Worksheet.Column(14).Width = 25;    //"NO RANGKA";
                ws.Cells[1, 15].Worksheet.Column(15).Width = 15;    //"NO MESIN";
                ws.Cells[1, 16].Worksheet.Column(16).Width = 25;    //"NAMA BPKB";
                ws.Cells[1, 17].Worksheet.Column(17).Width = 15;    //"NO. POLISI";
                ws.Cells[1, 18].Worksheet.Column(18).Width = 18;    //"HARGA JUAL";
                ws.Cells[1, 19].Worksheet.Column(19).Width = 18;    //"HARGA OTR";
                ws.Cells[1, 20].Worksheet.Column(20).Width = 18;    //"DISCOUNT JUAL";
                ws.Cells[1, 21].Worksheet.Column(21).Width = 18;    //"HARGA BELI";
                ws.Cells[1, 22].Worksheet.Column(22).Width = 18;    //"Tambahan";
                ws.Cells[1, 23].Worksheet.Column(23).Width = 18;    //"HPP";


                ws.Cells[1, 24].Worksheet.Column(24).Width = 19;    //"PROFIT";
                ws.Cells[1, 25].Worksheet.Column(25).Width = 18;    //"BIAYA BALIK NAMA";
                ws.Cells[1, 26].Worksheet.Column(26).Width = 18;    //"BIAYA ADMINISTRASI";
                ws.Cells[1, 27].Worksheet.Column(27).Width = 18;    //"UM SETARA";
                ws.Cells[1, 28].Worksheet.Column(28).Width = 18;    //"UM SUBSIDI";
                ws.Cells[1, 29].Worksheet.Column(29).Width = 18;    //"PIUT POKOK";
                ws.Cells[1, 30].Worksheet.Column(30).Width = 18;    //"SALDO PIUTANG";
                ws.Cells[1, 31].Worksheet.Column(31).Width = 18;    //"TOTAL PEMBAYARAN";
                ws.Cells[1, 32].Worksheet.Column(32).Width = 15;    //"STATUS PELUNASAN";
                ws.Cells[1, 33].Worksheet.Column(33).Width = 15;    //"JUAL/GADAI";
                ws.Cells[1, 34].Worksheet.Column(34).Width = 20;    //"NOMINAL LABA";
                ws.Cells[1, 35].Worksheet.Column(35).Width = 20;    //"BIAYA KOMISI";
                ws.Cells[1, 36].Worksheet.Column(36).Width = 16;    //"ASAL";
                ws.Cells[1, 37].Worksheet.Column(37).Width = 20;    //"STATUS KIRIM";
            
                string Title = "LAPORAN PENJUALAN";

                ws.Cells[1, 1].Value = "";
                ws.Cells[2, 1].Value = Title;
                ws.Cells[3, 1].Value = " ";

                ws.Cells[2, 1, 2, MaxCol].Merge = true;
                ws.Cells[4, 1].Value = "Cabang        : " + GlobalVar.CabangID;
                ws.Cells[4, 1, 4, 4].Merge = true;
                ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[5, 1].Value = "Periode       : " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.FromDate) + " s/d " + string.Format("{0:dd-MM-yyyy}", rangeDateBox1.ToDate);
                ws.Cells[5, 1, 5, 4].Merge = true;
                ws.Cells[5, 1, 5, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[6, 1].Value = "Status Lunas  : " + statusLunas;
                ws.Cells[6, 1, 6, 4].Merge = true;
                ws.Cells[6, 1, 6, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


                ws.Cells[1, 1, 2, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[1, 1, 2, MaxCol].Style.Font.Bold = true;
                ws.Cells[2, 1].Style.Font.Size = 18;
                ws.Cells[4, 1, 6, 4].Style.Font.Size = 12;
                ws.Cells[4, 1, 6, 4].Style.Font.Bold = true;

                #region Generate Header

                // tambahin sales dan alamat
                ws.Cells[startH,  1].Value = "N0.";
                ws.Cells[startH,  2].Value = "NO. TRANS";
                ws.Cells[startH,  3].Value = "NO BUKTI";
                ws.Cells[startH,  4].Value = "TGL. JUAL";
                ws.Cells[startH,  5].Value = "NAMA PELANGGAN";
                ws.Cells[startH,  6].Value = "KECAMATAN";
                ws.Cells[startH,  7].Value = "NAMA SALES";
                ws.Cells[startH,  8].Value = "JENIS PENJUALAN";
                ws.Cells[startH,  9].Value = "TIPE BUNGA";
                ws.Cells[startH,  10].Value = "TEMPO";
                ws.Cells[startH, 11].Value = "MEREK";
                ws.Cells[startH, 12].Value = "KODE TIPE";
                ws.Cells[startH, 13].Value = "NAMA TIPE";
                ws.Cells[startH, 14].Value = "NO RANGKA";
                ws.Cells[startH, 15].Value = "NO MESIN";
                ws.Cells[startH, 16].Value = "NAMA BPKB";
                ws.Cells[startH, 17].Value = "NO. POLISI";
                ws.Cells[startH, 18].Value = "HARGA JUAL";
                ws.Cells[startH, 19].Value = "HARGA OTR";
                ws.Cells[startH, 20].Value = "DISC JUAL";
                ws.Cells[startH, 21].Value = "HARGA BELI";
                ws.Cells[startH, 22].Value = "BIAYA TAMBAHAN";
                ws.Cells[startH, 23].Value = "HPP";
                ws.Cells[startH, 24].Value = "PROFIT";
                ws.Cells[startH, 25].Value = "BIAYA BALIK NAMA";
                ws.Cells[startH, 26].Value = "BIAYA ADM";
                ws.Cells[startH, 27].Value = "UANG MUKA";
                ws.Cells[startH, 28].Value = "UM SUBSIDI";
                ws.Cells[startH, 29].Value = "PIUT POKOK";
                ws.Cells[startH, 30].Value = "SALDO PIUTANG";
                ws.Cells[startH, 31].Value = "TOTAL PEMBAYARAN";
                ws.Cells[startH, 32].Value = "STATUS PELUNASAN";
                ws.Cells[startH, 33].Value = "JUAL/GADAI";
                ws.Cells[startH, 34].Value = "NOMINAL LABA";
                ws.Cells[startH, 35].Value = "BIAYA KOMISI";
                ws.Cells[startH, 36].Value = "ASAL";
                ws.Cells[startH, 37].Value = "STATUS PENGIRIMAN";
                
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
                    ws.Cells[idx,  1].Value = no++;
                    ws.Cells[idx,  2].Value = dr["NoTrans"];
                    ws.Cells[idx,  3].Value = dr["NoBukti"];
                    ws.Cells[idx,  4].Value = dr["TglJual"];
                    ws.Cells[idx,  5].Value = dr["Nama"];
                    ws.Cells[idx,  6].Value = dr["Kecamatan"];
                    ws.Cells[idx,  7].Value = dr["NamaSales"];
                    string temp = "";
                    switch (dr["JenisPenjualan"].ToString())
                    {
                        case "K": temp = "Kredit"; break;
                        case "T": temp = "Tunai - " + dr["KodeTrans"]; break;
                        default : temp = ""; break;
                    }
                    ws.Cells[idx, 8].Value = temp;

                    switch (dr["TipeBunga"].ToString())
                    {
                        case "FLT": temp = "Bunga Tetap"; break;
                        case "APD": temp = "Bunga Menurun"; break;
                        default   : temp = "-"; break;
                    }
                    ws.Cells[idx,  9].Value = temp;
                    ws.Cells[idx,  10].Value = dr["Tempo"];
                    ws.Cells[idx, 11].Value = dr["Merk"];
                    ws.Cells[idx, 12].Value = dr["Type"];
                    ws.Cells[idx, 13].Value = dr["NamaType"];
                    ws.Cells[idx, 14].Value = dr["NoRangka"];
                    ws.Cells[idx, 15].Value = dr["NoMesin"];
                    ws.Cells[idx, 16].Value = dr["NamaBPKB"];
                    ws.Cells[idx, 17].Value = dr["Nopol"];
                    ws.Cells[idx, 18].Value = dr["HargaJual"];
                    ws.Cells[idx, 19].Value = dr["HargaOTR"];
                    ws.Cells[idx, 20].Value = dr["Discount"]; //Convert.ToDouble(Tools.isNull(dr["Biaya"], 0)) + Convert.ToDouble(Tools.isNull(dr["HargaOff"], 0));
                    ws.Cells[idx, 21].Value = dr["HargaBeli"];
                    ws.Cells[idx, 22].Value = dr["tambahan"];
                    ws.Cells[idx, 23].Value = dr["HPP"];
                    ws.Cells[idx, 24].Value = dr["Profit"];
                    ws.Cells[idx, 25].Value = dr["BiayaBBN"];
                    ws.Cells[idx, 26].Value = dr["BiayaADM"];
                    ws.Cells[idx, 27].Value = dr["UMSetara"];
                    ws.Cells[idx, 28].Value = dr["UMSubsidi"];
                    ws.Cells[idx, 29].Value = dr["PiutPokok"];
                    ws.Cells[idx, 30].Value = dr["saldopiutang"];
                    ws.Cells[idx, 31].Value = dr["totalpembayaran"];
                    switch (dr["STATUSLUNAS"].ToString())
                    {
                        case "1": temp = "Lunas"; break;
                        case "2": temp = "Belum Lunas"; break;
                        default : temp = ""; break;
                    }
                    ws.Cells[idx, 32].Value = temp;
                    switch (dr["penjualanorpegadaian"].ToString())
                    {
                        case "PGD": temp = "Pegadaian"; break;
                        default   : temp = ""; break;
                    }
                    ws.Cells[idx, 33].Value = temp;
                    ws.Cells[idx, 34].Value = dr["laba"];
                    ws.Cells[idx, 35].Value = dr["BIayaKomisi"];
                    ws.Cells[idx, 36].Value = dr["Asal"];
                    ws.Cells[idx, 37].Value = dr["StatusKirim"];

                    idx++;
                }
                #endregion

                #region Summary & Formatting
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[startH, 1, startH, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
                ws.Cells[idx, 1].Value = "Total";
                ws.Cells[idx, 1, idx, 13].Merge = true;
                ws.Cells[idx, 1, idx, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
                ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

                // Total HargaJual
                ws.Cells[idx, 18].Formula = "Sum(" + ws.Cells[startH + 1, 18].Address + ":" + ws.Cells[idx - 1, 18].Address + ")"; 
                // Total HargaOTR
                ws.Cells[idx, 19].Formula = "Sum(" + ws.Cells[startH + 1, 19].Address + ":" + ws.Cells[idx - 1, 19].Address + ")";
                // Total Disc Jual
                ws.Cells[idx, 20].Formula = "Sum(" + ws.Cells[startH + 1, 20].Address + ":" + ws.Cells[idx - 1, 20].Address + ")";
                // Total HargaBeli
                ws.Cells[idx, 21].Formula = "Sum(" + ws.Cells[startH + 1, 21].Address + ":" + ws.Cells[idx - 1, 21].Address + ")";
              
                //Total Tambahan
                ws.Cells[idx, 22].Formula = "Sum(" + ws.Cells[startH + 1, 22].Address + ":" + ws.Cells[idx - 1, 22].Address + ")";
                //Total HPP
                ws.Cells[idx, 23].Formula = "Sum(" + ws.Cells[startH + 1, 23].Address + ":" + ws.Cells[idx - 1, 23].Address + ")";
                // Summary Profit
                ws.Cells[idx, 24].Formula = "((" + ws.Cells[idx, 18].Address + "/" + ws.Cells[idx, 23].Address + ") * 100) - 100";
                // Biaya BBN
                ws.Cells[idx, 25].Formula = "Sum(" + ws.Cells[startH + 1, 25].Address + ":" + ws.Cells[idx - 1, 25].Address + ")";
                // total administrasi
                ws.Cells[idx, 26].Formula = "Sum(" + ws.Cells[startH + 1, 26].Address +  ":" + ws.Cells[idx - 1, 26].Address + ")";
               
                // total UM
                ws.Cells[idx, 27].Formula = "Sum(" + ws.Cells[startH + 1, 27].Address + ":" + ws.Cells[idx - 1, 27].Address + ")";
                
                // total UM Sub
                ws.Cells[idx, 28].Formula = "Sum(" + ws.Cells[startH + 1, 28].Address + ":" + ws.Cells[idx - 1, 28].Address + ")";
                // total PiutPokok
                ws.Cells[idx, 29].Formula = "Sum(" + ws.Cells[startH + 1, 29].Address + ":" + ws.Cells[idx - 1, 29].Address + ")";
                //total saldopiut
                ws.Cells[idx, 30].Formula = "Sum(" + ws.Cells[startH + 1, 30].Address + ":" + ws.Cells[idx - 1, 30].Address + ")";
                //total pembayaran
                ws.Cells[idx, 31].Formula = "Sum(" + ws.Cells[startH + 1, 31].Address + ":" + ws.Cells[idx - 1, 31].Address + ")";
                // totallaba
                ws.Cells[idx, 34].Formula = "Sum(" + ws.Cells[startH + 1, 34].Address + ":" + ws.Cells[idx - 1, 34].Address + ")";
                // BiayaKomisi
                ws.Cells[idx, 35].Formula = "Sum(" + ws.Cells[startH + 1, 35].Address + ":" + ws.Cells[idx - 1, 35].Address + ")";

                ws.Cells[startH + 1, 18, idx, 31].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 34, idx, 35].Style.Numberformat.Format = "#,##0.00";
                ws.Cells[startH + 1, 4, idx - 1, 4].Style.Numberformat.Format = "dd-MMM-yyyy";

                // No NoTrans
                ws.Cells[startH + 1, 1, idx - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 1, idx - 1, 2].Style.WrapText = true;
                // TglJual
                ws.Cells[startH + 1, 4, idx - 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[startH + 1, 4, idx - 1, 4].Style.WrapText = true;
                // Nama JenisPenjualan TipeBunga
                ws.Cells[startH + 1, 5, idx - 1, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 5, idx - 1, 9].Style.WrapText = true;
                //Tempo
                ws.Cells[startH + 1, 10, idx - 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 10, idx - 1, 10].Style.WrapText = true;
                // Norangka
                ws.Cells[startH + 1, 11, idx - 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 11, idx - 1, 13].Style.WrapText = true;
                // NoMesin
                ws.Cells[startH + 1, 14, idx - 1, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[startH + 1, 14, idx - 1, 15].Style.WrapText = true;
                // HargaJual -> totalpembayaran
                ws.Cells[startH + 1, 18, idx - 1, 26].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 18, idx - 1, 26].Style.WrapText = true;
                // STATUSLUNAS penjualanorpegadaian
                ws.Cells[startH + 1, 27, idx - 1, 31].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 27, idx - 1, 31].Style.WrapText = true;
                // Laba
                ws.Cells[startH + 1, 32, idx - 1, 32].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 32, idx - 1, 32].Style.WrapText = true;
                // ASAL
                ws.Cells[startH + 1, 33, idx - 1, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells[startH + 1, 33, idx - 1, 33].Style.WrapText = true;

                ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
                ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
                ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells[idx + 4, 1].Value = "Title      : Laporan Penjualan";
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
                sf.FileName = "Laporan Penjualan " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_penjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", rangeDateBox1.FromDate)));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, string.Format("{0:yyyy-MM-dd}", rangeDateBox1.ToDate)));
                    db.Commands[0].Parameters.Add(new Parameter("@customername", SqlDbType.VarChar, lookUpCustomer1.txtNamaCustomer.Text.ToString().Trim() ));
                    db.Commands[0].Parameters.Add(new Parameter("@statuslunas", SqlDbType.SmallInt, cboStatusLunas.SelectedIndex));

                    if (cboKondisi.SelectedIndex == 0)
                    {
                        // baru
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, "BARU"));
                    }
                    else if (cboKondisi.SelectedIndex == 1)
                    {
                        // bekas
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, "ORI"));
                    }
                    else if (cboKondisi.SelectedIndex == 2)
                    {
                        // semua
                        db.Commands[0].Parameters.Add(new Parameter("@Kondisi", SqlDbType.VarChar, "ALL"));
                    }

                    if (rbPenjualan1.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, "T"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
                    }
                    else if (rbPenjualan2.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, "K"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
                    }
                    else if (rbPenjualan3.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, "A"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, "SEM"));
                    }

                    if(lookUpSalesman1._sales.RowID != null && lookUpSalesman1._sales.RowID != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, lookUpSalesman1._sales.RowID));
                    }

                    if(lookUpMotor1._motor.RowID != null && lookUpMotor1._motor.RowID != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@TypeRowID", SqlDbType.UniqueIdentifier, lookUpMotor1._motor.RowID ));
                    }

                    if(String.IsNullOrEmpty(cboKecamatan.Text))
                    {
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Kecamatan", SqlDbType.VarChar, cboKecamatan.Text));
                    }

                    if(String.IsNullOrEmpty(cboOrderBy.Text))
                    {
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@OrderBy", SqlDbType.VarChar, cboOrderBy.Text));
                    }

                    if (rbOrderAsc.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@ASCDESC", SqlDbType.VarChar, "ASC"));
                    }
                    else if (rbOrderDesc.Checked == true)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@ASCDESC", SqlDbType.VarChar, "DESC"));
                    }

                    db.Commands[0].Parameters.Add(new Parameter("@StatusKirim", SqlDbType.VarChar, txtStatusKirim.Text));

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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLapPenjualan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            cboOrderBy.SelectedIndex = 0;
            cboStatusLunas.SelectedIndex = 0;
            cboKondisi.SelectedIndex = 0;
            DataTable dtProp = FillComboBox.DBGetProvinsi(Guid.Empty);
            dtProp.Rows.Add(Guid.Empty, "");
            dtProp.DefaultView.Sort = "Nama ASC";
            cboProvinsi.DisplayMember = "Nama";
            cboProvinsi.ValueMember = "RowID";
            cboProvinsi.DataSource = dtProp.DefaultView;
            txtStatusKirim.SelectedIndex = 0;

            DataTable dummyPR = new DataTable();
            using (Database dbsubPR = new Database())
            {
                dbsubPR.Commands.Add(dbsubPR.CreateCommand("usp_AppSetting_LIST"));
                dbsubPR.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PROVPEMILIKBPKB"));
                dummyPR = dbsubPR.Commands[0].ExecuteDataTable();
                if (dummyPR.Rows.Count > 0)
                    cboProvinsi.Text = dummyPR.Rows[0]["Value"].ToString();
            }
            DataTable dummyKT = new DataTable();
            using (Database dbsubKT = new Database())
            {
                dbsubKT.Commands.Add(dbsubKT.CreateCommand("usp_AppSetting_LIST"));
                dbsubKT.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KOTAPEMILIKBPKB"));
                dummyKT = dbsubKT.Commands[0].ExecuteDataTable();
                if (dummyKT.Rows.Count > 0)
                    cboKota.Text = dummyKT.Rows[0]["Value"].ToString();
            }

            updatePerubahanJenisBayar();
        }

        private void cboProvinsiIdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)cboProvinsi.SelectedValue;
                DataTable dt = FillComboBox.DBGetKota(Guid.Empty, rowID);
                dt.Rows.Add(Guid.Empty, Guid.Empty, "");
                dt.DefaultView.Sort = "Nama ASC";
                cboKota.DisplayMember = "Nama";
                cboKota.ValueMember = "RowID";
                cboKota.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cboKotaIdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)cboKota.SelectedValue;
                DataTable dt = FillComboBox.DBGetKecamatan(Guid.Empty, rowID);
                dt.Rows.Add(Guid.Empty, Guid.Empty, "");
                dt.DefaultView.Sort = "Nama ASC";
                cboKecamatan.DisplayMember = "Nama";
                cboKecamatan.ValueMember = "RowID";
                cboKecamatan.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void rbPenjualan1_CheckedChanged(object sender, EventArgs e)
        {
            updatePerubahanJenisBayar();
        }

        private void rbPenjualan2_CheckedChanged(object sender, EventArgs e)
        {
            updatePerubahanJenisBayar();
        }

        private void rbPenjualan3_CheckedChanged(object sender, EventArgs e)
        {
            updatePerubahanJenisBayar();
        }

        private void updatePerubahanJenisBayar()
        {
            if (rbPenjualan1.Checked == true) // tunai
            {
                this.ListAngsuran("Tunai");
                cboJnsAngsuran.Enabled = true;
                rbPenjualan2.Checked = false;
                rbPenjualan3.Checked = false;
            }
            else if (rbPenjualan2.Checked == true) // kredit
            {
                this.ListAngsuran("Kredit");
                cboJnsAngsuran.Enabled = true;
                rbPenjualan1.Checked = false;
                rbPenjualan3.Checked = false;
            }
            else
            {
                this.ListAngsuran("Semua");
                cboJnsAngsuran.Enabled = false;
                rbPenjualan1.Checked = false;
                rbPenjualan2.Checked = false;
                cboJnsAngsuran.SelectedIndex = 0;
            }
        }

        private void ListAngsuran(String Jenis)
        {
            cboJnsAngsuran.DisplayMember = "Text";
            cboJnsAngsuran.ValueMember = "Value";
            if (Jenis == "Tunai")
            {
                var items = new[] {
                    new { Text = "SEMUA", Value = "SEM" },
                    new { Text = "CASH KERAS", Value = "TUN" },
                    new { Text = "CASH TEMPO", Value = "CTP" },
                    new { Text = "LEASING", Value = "LSG" }
                };
                cboJnsAngsuran.DataSource = items;
            }
            else if (Jenis == "Kredit")
            {
                var items = new[] {
                    new { Text = "SEMUA", Value = "SEM" },
                    new { Text = "BUNGA MENURUN", Value = "APD" },
                    new { Text = "BUNGA TETAP / FLAT", Value = "FLT" }
                };
                cboJnsAngsuran.DataSource = items;
            }
            else
            {
                var items = new[] {
                    new { Text = "SEMUA", Value = "SEM" }
                };
                cboJnsAngsuran.DataSource = items;
            }
        }

        private void rbTipe1_CheckedChanged(object sender, EventArgs e)
        {
            gantiTipe();
        }

        private void rbTipe2_CheckedChanged(object sender, EventArgs e)
        {
            gantiTipe();
        }

        private void gantiTipe()
        {
            //if (rbTipe1.Checked == true)
            //{
            //    rbTipe2.Checked = false;
            //}
            //if (rbTipe2.Checked == true)
            //{
            //    rbTipe1.Checked = false;
            //}
        }

        private void rbOrderAsc_CheckedChanged(object sender, EventArgs e)
        {
            gantiOrder();
        }

        private void rbOrderDesc_CheckedChanged(object sender, EventArgs e)
        {
            gantiOrder();
        }

        private void gantiOrder()
        {
            if (rbOrderAsc.Checked == true)
            {
                rbOrderDesc.Checked = false;
            }
            else if (rbOrderDesc.Checked == true)
            {
                rbOrderAsc.Checked = false;
            }
        }
    }
}
