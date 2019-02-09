using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Globalization;
using ISA.Showroom.Class;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Penjualan
{
    public partial class frmUMBungaBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridHeader, GridSaldo, GridPembayaran };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridHeader;

        DateTime _fromdate = GlobalVar.GetServerDate.AddMonths(-12);
        DateTime _todate = GlobalVar.GetServerDate;
        public frmUMBungaBrowse()
        {
            InitializeComponent();
        }

        private void frmUMBungaBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = _fromdate;
            rangeDateBox1.ToDate = _todate;
            if (cbostatus.Items.Count > 0)
            {
                cbostatus.SelectedIndex = 0;
            }
        }

        public void refreshGrids(Guid PenjRowID, Guid PenerimaanUMRowID)
        {
            cbostatus.SelectedIndex = 2;
            refreshGrid();
            refreshGridDetail(PenjRowID);
            refreshGridDetailBayar(PenjRowID, PenerimaanUMRowID);
            dgTransaksiDetail.FindRow("PenjRowIDListing", PenjRowID.ToString());
            dgUMBunga.FindRow("PenerimaanUMRowID", PenerimaanUMRowID.ToString());
        }

        private void refreshGrid()
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_LIST_by_penjualan")); // tampilin data penjualan
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                dummy = db.Commands[0].ExecuteDataTable();
                dgTransaksiDetail.DataSource = dummy;
            }
        }

        private void refreshGridDetail(Guid PenjRowID)
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_LIST")); // tampilin data penerimaanUM/Angsuran yg ada denda
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                // db.Commands[0].Parameters.Add(new Parameter("@Terbayar", SqlDbType.SmallInt, cbostatus.SelectedIndex));
                dummy = db.Commands[0].ExecuteDataTable();
                dgUMBunga.DataSource = dummy;
                dgBayarUMBunga.DataSource = null;
            }
        }

        private void refreshGridDetailBayar(Guid PenjRowID, Guid PenerimaanUMRowID)
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_LIST_Bayar")); // tampilin data pembayaran UMBunganya
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                dgBayarUMBunga.DataSource = dummy;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate.Value == null || rangeDateBox1.FromDate.ToString() == "")
            {
                MessageBox.Show("Data Tanggal masih error, tidak dapat diproses!");
                return;
            }
            if (rangeDateBox1.ToDate.Value == null || rangeDateBox1.ToDate.ToString() == "")
            {
                MessageBox.Show("Data Tanggal masih error, tidak dapat diproses!");
                return;
            }
            
            if (cbostatus.SelectedIndex < 0 || cbostatus.SelectedIndex > 2)
            {
                MessageBox.Show("Pilihan Status masih error, tidak dapat diproses!");
                return;
            }
            
            refreshGrid();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (dgBayarUMBunga.SelectedCells.Count > 0 && dgUMBunga.SelectedCells.Count > 0)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                Guid RowID;
                Guid PenerimaanUMRowID;
                Guid PenjRowID;
                Guid PenerimaanUangUMBungaRowID;

                RowID = (Guid)dgBayarUMBunga.SelectedCells[0].OwningRow.Cells["RowIDBayarUMBunga"].Value; ;
                PenerimaanUMRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenerimaanUMRowID"].Value;
                PenjRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                PenerimaanUangUMBungaRowID = (Guid)Tools.isNull(dgBayarUMBunga.SelectedCells[0].OwningRow.Cells["PenerimaanUangRowIDUMBunga"].Value, Guid.Empty);
                
                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // cek penerimaanUang nya yg UMBunga itu udah dibuat jurnalnya belum
                    // kalo masih enabled cek ke journal
                    if (PenerimaanUangUMBungaRowID == Guid.Empty || PenerimaanUangUMBungaRowID.ToString().Trim() == "" || PenerimaanUangUMBungaRowID == null)
                    {
                        // kalo kosong ya udah ga usah diapa2in
                    }
                    // kalo iya cek udah ada jurnal blom
                    else
                    {
                        // lakukan pengecekan kalo ada penerimaanUangRowID
                        using (Database dbsub = new Database(GlobalVar.DBFinanceOto))
                        {
                            DataTable dummy = new DataTable();
                            dbsub.Commands.Add(dbsub.CreateCommand("usp_CheckJournalByPenerimaanUangRowID"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanUangUMBungaRowID));
                            dummy = dbsub.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if (dummy.Rows.Count > 0)
                            {
                                MessageBox.Show("Data Pembayaran UMBunga Sudah Terbentuk Jurnal, tidak dapat dihapus.");
                                return;
                            }
                        }
                    }

                    if (Class.PenerimaanUang.checkDelete(RowID, "PenerimaanUMBunga") == true)
                    {
                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.PenerimaanUMBunga_DELETE), "Hapus Penerimaan UMBunga.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini!");
                        if (GlobalVar.pinResult == false) { return; }
                    }

                    Database db = new Database();
                    int looper = 0, counterdb = 0;
                    try
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_DELETE"));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        counterdb++;

                        db.BeginTransaction();
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                        refreshGrids(PenjRowID, PenerimaanUMRowID);
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        MessageBox.Show("Error terjadi, DELETE dibatalkan \n" + ex.Message);
                    }
                
                }
            }
            else
            {
                MessageBox.Show("Pilih data UMBunga yg ingin dihapus terlebih dahulu.");
            }
        }

        private void cmdPELUNASAN_Click(object sender, EventArgs e)
        {
            // cek dulu mesti kepilih 1 data baru bisa melakukan proses pembayaran
            if (dgUMBunga.SelectedCells.Count > 0)
            {
                Guid PenerimaanUMRowID;
                Guid PenjRowID;
                
                PenerimaanUMRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenerimaanUMRowID"].Value;
                PenjRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                
                Penjualan.frmUMBungaUpdate ifrmChild = new Penjualan.frmUMBungaUpdate(this, PenerimaanUMRowID, PenjRowID);
                ifrmChild.ShowDialog();
                // refreshGrid();
                refreshGrids(PenjRowID, PenerimaanUMRowID);
            }
            else
            {
                MessageBox.Show("Pilih data UMBunga yg ingin dilunasi terlebih dahulu.");
            }
        }

        private void dgUMBunga_Click(object sender, EventArgs e)
        {
            if (dgUMBunga.SelectedCells.Count > 0)
            {
                // load juga data BayarUMBunga untuk gridview yg dibawahnya
                // ambil data penjualanrowid sama penerimaanUM/Angsurannya
                Guid PenjRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value; ;
                Guid PenerimaanUMRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenerimaanUMRowID"].Value;
                
                refreshGridDetailBayar(PenjRowID, PenerimaanUMRowID);

                Double SaldoUMBunga = Convert.ToDouble(Tools.isNull(dgUMBunga.SelectedCells[0].OwningRow.Cells["SaldoUMBungaDetail"].Value, 0).ToString());
                
                // kalo udah habis saldo UMBunganya
                if (SaldoUMBunga > 1)
                {
                    cmdPELUNASAN.Enabled = true;
                }
                else
                {
                    cmdPELUNASAN.Enabled = false;
                }
                cmdDELETE.Enabled = false;
            }
        }

        private void dgTransaksiDetail_Click(object sender, EventArgs e)
        {

        }
        private void dgBayarUMBunga_Click(object sender, EventArgs e)
        {
            if (dgBayarUMBunga.SelectedCells.Count > 0)
            {
                cmdKETUMBUNGA.Enabled = true;
                cmdDELETE.Enabled = true;
            }
        }


        private void cmdKETUMBUNGA_Click(object sender, EventArgs e)
        {
            // cek dulu mesti kepilih 1 data baru bisa melakukan proses pembayaran
            if (dgUMBunga.SelectedCells.Count > 0 && dgBayarUMBunga.SelectedCells.Count > 0)
            {
                Guid PenerimaanUMRowID;
                Guid PenjRowID;
                Guid RowID;
                PenerimaanUMRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenerimaanUMRowID"].Value;
                PenjRowID = (Guid)dgUMBunga.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                RowID = (Guid)dgBayarUMBunga.SelectedCells[0].OwningRow.Cells["RowIDBayarUMBunga"].Value;

                Penjualan.frmUMBungaKeterangan ifrmChild = new Penjualan.frmUMBungaKeterangan(this, PenerimaanUMRowID, PenjRowID, RowID);
                ifrmChild.ShowDialog();
                // refreshGrid();
                refreshGrids(PenjRowID, PenerimaanUMRowID);
            }
            else
            {
                MessageBox.Show("Pilih data denda yg ingin diedit keterangannya terlebih dahulu.");
            }
        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGrid == enumSelectedGrid.GridPembayaran)
                {
                    if (dgBayarUMBunga.SelectedCells.Count > 0 && dgUMBunga.SelectedCells.Count > 0 && dgTransaksiDetail.SelectedCells.Count > 0)
                    {
                        Guid rowID = (Guid)dgBayarUMBunga.SelectedCells[0].OwningRow.Cells["RowIDBayarUMBunga"].Value;
                        string _edp, _terbilang, _kotatgl, _kota, _copy, _uraian;
                        int _nprint;
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        frmPrint ifrmDialog = new frmPrint(this, 3);
                        ifrmDialog.ShowDialog();
                        if (ifrmDialog.DialogResult == DialogResult.Yes)
                        { _nprint = ifrmDialog.Result; }
                        else
                        { return; }

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_PenerimaanUMBunga"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                            dt = db.Commands[0].ExecuteDataTable();
                            List<ReportParameter> rptParams = new List<ReportParameter>();

                            int JamBebasPIN = 0;
                            DataTable dummyPIN = new DataTable();
                            using (Database dbsubPIN = new Database())
                            {
                                dbsubPIN.Commands.Add(dbsubPIN.CreateCommand("usp_AppSetting_LIST"));
                                dbsubPIN.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BEBASPIN"));
                                dummyPIN = dbsubPIN.Commands[0].ExecuteDataTable();
                                JamBebasPIN = Convert.ToInt32(Tools.isNull(dummyPIN.Rows[0]["Value"], 0).ToString());
                            }

                            //DateTime LastPrintedOn;
                            //LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn"], DateTime.MaxValue);
                            //if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                            //{
                            //}
                            //else
                            //{
                            //    MessageBox.Show(dt.Rows[0]["Cetak"].ToString());
                            //    if ((bool)dt.Rows[0]["Cetak"] == true)
                            //    {
                            //        // sebelumnya PinId.Bagian.Keuangan
                            //        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
                            //        if (GlobalVar.pinResult == false) { return; }
                            //    }
                            //}

                            _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                            int angka = int.Parse(Tools.isNull(dt.Rows[0]["Nominal"], "0").ToString(), NumberStyles.Currency) + int.Parse(Tools.isNull(dt.Rows[0]["NominalPembulatan"], "0").ToString(), NumberStyles.Currency);
                            _terbilang = Tools.Terbilang(angka) + "RUPIAH";
                            _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();

                            _kota = _kota.Replace("Kota ", "");
                            _kota = _kota.Replace("Kabupaten ", "");

                            DateTime tglBayar;
                            tglBayar = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"].ToString(), GlobalVar.GetServerDate).ToString());
                            // _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                            _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();

                            if ((int)dt.Rows[0]["Cetak"] == 1)
                            {
                                if (int.Parse(dt.Rows[0]["nPrint"].ToString()) > 0)
                                {
                                    _copy = "Copy ke-" + dt.Rows[0]["nPrint"].ToString();
                                }
                                else
                                {
                                    _copy = "";
                                }
                            }
                            else
                            {
                                _copy = "";
                            }

                            String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                            String FileName = "";
                            using (Database dbLogo = new Database())
                            {
                                DataTable dtLogo = new DataTable();
                                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILE"));
                                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                                FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                            }

                            IMG_Path = IMG_Path + FileName;
                            rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));


                            String IMG_PathBW = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
                            String FileNameBW = "";
                            using (Database dbLogo = new Database())
                            {
                                DataTable dtLogo = new DataTable();
                                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILEBW"));
                                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                                FileNameBW = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
                            }

                            IMG_PathBW = IMG_PathBW + FileNameBW;
                            rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));


                            rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["Nominal"]).ToString()));
                            rptParams.Add(new ReportParameter("JnsKw", Tools.isNull(dt.Rows[0]["Uraian"], "").ToString()));
                            rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                            rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                            rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                            rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                            rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                            rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  // GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                            // tambahan untuk kwitansi
                            rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                            rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                            rptParams.Add(new ReportParameter("Tipe", "UMB"));


                            if ((_nprint == 0) || (_nprint == 1))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansi.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            if ((_nprint == 0) || (_nprint == 2))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy1.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            if ((_nprint == 0) || (_nprint == 3))
                            {
                                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy2.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                                ifrmReport.Print();
                            }
                            cmdDELETE.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void dgTransaksiDetail_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridHeader;
        }

        private void dgUMBunga_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridSaldo;
        }

        private void dgBayarUMBunga_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridPembayaran;
        }

        private void dgBayarUMBunga_SelectionChanged(object sender, EventArgs e)
        {
            if (dgBayarUMBunga.SelectedCells.Count > 0)
            {
                cmdPRINTKW.Enabled = true;
            }
        }

        private void dgUMBunga_SelectionChanged(object sender, EventArgs e)
        {
            cmdPRINTKW.Enabled = false;
        }

        private void dgTransaksiDetail_SelectionChanged(object sender, EventArgs e)
        {
            cmdPRINTKW.Enabled = false;
        }

        private void dgTransaksiDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dgTransaksiDetail.SelectedCells.Count > 0)
            {
                Guid PenjRowID = (Guid)dgTransaksiDetail.SelectedCells[0].OwningRow.Cells["PenjRowIDListing"].Value;
                cmdPELUNASAN.Enabled = false;
                cmdDELETE.Enabled = false;
                refreshGridDetail(PenjRowID);
            }
        }
        

    }
}
