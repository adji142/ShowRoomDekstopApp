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
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmDendaBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridHeader, GridSaldo, GridPembayaran};
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridHeader;

        DateTime _fromdate = GlobalVar.GetServerDate.AddMonths(-12);
        DateTime _todate = GlobalVar.GetServerDate;
        public frmDendaBrowse()
        {
            InitializeComponent();
        }

        private void frmDendaBrowse_Load(object sender, EventArgs e)
        {
            if (GlobalVar.CabangID.ToUpper() == "06B" || GlobalVar.CabangID.ToUpper() == "06C" || GlobalVar.CabangID.ToUpper() == "06D" || GlobalVar.CabangID.ToUpper() == "06E")
            {
                _fromdate = new DateTime(2000, 1, 1);
                _todate = GlobalVar.GetServerDate;
            } 
            rangeDateBox1.FromDate = _fromdate;
            rangeDateBox1.ToDate = _todate;
            if (cbostatus.Items.Count > 0)
            {
                cbostatus.SelectedIndex = 0;
            }
        }

        public void refreshGrids(Guid PenjRowID, Guid SrcRowID, String Source)
        {
            cbostatus.SelectedIndex = 2;
            refreshGrid();
            refreshGridDetail(PenjRowID);
            refreshGridDetailBayar(PenjRowID, SrcRowID, Source);
            dgTransaksiDetail.FindRow("PenjRowIDListing", PenjRowID.ToString());
            dgDenda.FindRow("SrcDendaRowID", SrcRowID.ToString());
        }

        private void refreshGrid()
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_LIST_by_penjualan")); // tampilin data penjualan
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
                db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_LIST")); // tampilin data penerimaanUM/Angsuran yg ada denda
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                // db.Commands[0].Parameters.Add(new Parameter("@Terbayar", SqlDbType.SmallInt, cbostatus.SelectedIndex));
                dummy = db.Commands[0].ExecuteDataTable();
                dgDenda.DataSource = dummy;
                dgBayarDenda.DataSource = null;
            }
        }

        private void refreshGridDetailBayar(Guid PenjRowID, Guid SrcRowID, String Src)
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_LIST_Bayar")); // tampilin data pembayaran dendanya
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, SrcRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Src));
                dummy = db.Commands[0].ExecuteDataTable();
                dgBayarDenda.DataSource = dummy;
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
            if (dgBayarDenda.SelectedCells.Count > 0 && dgDenda.SelectedCells.Count > 0)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                Guid RowID;
                Guid SrcRowID;
                Guid PenjRowID;
                String Source;
                Guid PenerimaanUangDendaRowID;

                RowID = (Guid)dgBayarDenda.SelectedCells[0].OwningRow.Cells["RowIDBayarDenda"].Value; ;
                SrcRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["SrcDendaRowID"].Value;
                PenjRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                PenerimaanUangDendaRowID = (Guid)Tools.isNull(dgBayarDenda.SelectedCells[0].OwningRow.Cells["PenerimaanUangRowIDDenda"].Value, Guid.Empty);
                Source = dgDenda.SelectedCells[0].OwningRow.Cells["SrcDenda"].Value.ToString();

                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // cek penerimaanUang nya yg denda itu udah dibuat jurnalnya belum
                    // kalo masih enabled cek ke journal
                    if (PenerimaanUangDendaRowID == Guid.Empty || PenerimaanUangDendaRowID.ToString() == "" || PenerimaanUangDendaRowID == null)
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
                            dbsub.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanUangDendaRowID));
                            dummy = dbsub.Commands[0].ExecuteDataTable();
                            // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                            if (dummy.Rows.Count > 0)
                            {
                                MessageBox.Show("Data Pembayaran Denda Sudah Terbentuk Jurnal, tidak dapat dihapus.");
                                return;
                            }
                        }
                    }

                    if (Class.PenerimaanUang.checkDelete(RowID, "PenerimaanDenda") == true)
                    {
                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PenerimaanDenda_DELETE), "Hapus Penerimaan Denda.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini!");
                        if (GlobalVar.pinResult == false) { return; }
                    }

                    Database db = new Database();
                    int looper = 0, counterdb = 0;
                    try
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_DELETE"));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, SrcRowID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Source));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        counterdb++;

                        db.BeginTransaction();
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                        refreshGrids(PenjRowID, SrcRowID, Source);
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
                MessageBox.Show("Pilih data denda yg ingin dihapus terlebih dahulu.");
            }
        }

        private void cmdPELUNASAN_Click(object sender, EventArgs e)
        {
            // cek dulu mesti kepilih 1 data baru bisa melakukan proses pembayaran
            if (dgDenda.SelectedCells.Count > 0)
            {
                Guid SrcRowID;
                Guid PenjRowID;
                Guid PenjHistRowID;
                String Source;

                SrcRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["SrcDendaRowID"].Value;
                PenjRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                PenjHistRowID = (Guid)Tools.isNull(dgDenda.SelectedCells[0].OwningRow.Cells["PenjHistRowID"].Value, Guid.Empty);
                Source = dgDenda.SelectedCells[0].OwningRow.Cells["SrcDenda"].Value.ToString();

                Penjualan.frmDendaUpdate ifrmChild = new Penjualan.frmDendaUpdate(this, SrcRowID, PenjRowID, Source, PenjHistRowID);
                ifrmChild.ShowDialog();
                // refreshGrid();
                refreshGrids(PenjRowID, SrcRowID, Source);
            }
            else
            {
                MessageBox.Show("Pilih data denda yg ingin dilunasi terlebih dahulu.");
            }
        }

        private void dgDenda_Click(object sender, EventArgs e)
        {
            if (dgDenda.SelectedCells.Count > 0)
            {
                // load juga data BayarDenda untuk gridview yg dibawahnya
                // ambil data penjualanrowid sama penerimaanUM/Angsurannya
                Guid PenjRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value; ;
                Guid SrcRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["SrcDendaRowID"].Value;
                String Src = dgDenda.SelectedCells[0].OwningRow.Cells["SrcDenda"].Value.ToString();
                
                refreshGridDetailBayar(PenjRowID, SrcRowID, Src);

                Double SaldoDenda = Convert.ToDouble(Tools.isNull(dgDenda.SelectedCells[0].OwningRow.Cells["SaldoDendaDetail"].Value, 0).ToString());
                
                // kalo udah habis saldo dendanya
                if (SaldoDenda > 1)
                {
                    cmdPELUNASAN.Enabled = true;
                }
                else
                {
                    cmdPELUNASAN.Enabled = false;
                }
                 
                cmdDELETE.Enabled = false;
                cmdKETDENDA.Enabled = true;
            }
        }

        private void dgTransaksiDetail_Click(object sender, EventArgs e)
        {
            if (dgTransaksiDetail.SelectedCells.Count > 0)
            {
                Guid PenjRowID = (Guid)dgTransaksiDetail.SelectedCells[0].OwningRow.Cells["PenjRowIDListing"].Value;
                cmdPELUNASAN.Enabled = false;
                cmdDELETE.Enabled = false;
                cmdKETDENDA.Enabled = false;
                refreshGridDetail(PenjRowID);
            }
        }

        private void cmdKETDENDA_Click(object sender, EventArgs e)
        {
            // cek dulu mesti kepilih 1 data baru bisa melakukan proses pembayaran
            if (dgDenda.SelectedCells.Count > 0)
            {
                Guid SrcRowID;
                Guid PenjRowID;
                Guid PenjHistRowID;
                String Source;

                SrcRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["SrcDendaRowID"].Value;
                PenjRowID = (Guid)dgDenda.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
                PenjHistRowID = (Guid)Tools.isNull(dgDenda.SelectedCells[0].OwningRow.Cells["PenjHistRowID"].Value, Guid.Empty);
                Source = dgDenda.SelectedCells[0].OwningRow.Cells["SrcDenda"].Value.ToString();

                Penjualan.frmDendaKeterangan ifrmChild = new Penjualan.frmDendaKeterangan(this, SrcRowID, PenjRowID, Source, PenjHistRowID);
                ifrmChild.ShowDialog();
                // refreshGrid();
                refreshGrids(PenjRowID, SrcRowID, Source);
            }
            else
            {
                MessageBox.Show("Pilih data denda yg ingin diedit keterangannya terlebih dahulu.");
            }
        }

        private void dgBayarDenda_Click(object sender, EventArgs e)
        {
            if (dgBayarDenda.SelectedCells.Count > 0)
            {
                cmdDELETE.Enabled = true;
            }
        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGrid == enumSelectedGrid.GridPembayaran)
                {
                    if (dgBayarDenda.SelectedCells.Count > 0 && dgDenda.SelectedCells.Count > 0 && dgTransaksiDetail.SelectedCells.Count > 0)
                    {
                        Guid rowID = (Guid)dgBayarDenda.SelectedCells[0].OwningRow.Cells["RowIDBayarDenda"].Value;
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
                            db.Commands.Add(db.CreateCommand("rpt_Kwitansi_PenerimaanDenda"));
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

                            DateTime LastPrintedOn;
                            LastPrintedOn = (DateTime)Tools.isNull(dt.Rows[0]["LastPrintedOn"], DateTime.MaxValue);
                            if (LastPrintedOn < GlobalVar.GetServerDateTime_RealTime && GlobalVar.GetServerDateTime_RealTime < LastPrintedOn.AddHours(JamBebasPIN))
                            {
                            }
                            else
                            {
                                if ((bool)dt.Rows[0]["Cetak"] == true)
                                {
                                    // sebelumnya PinId.Bagian.Keuangan
                                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
                                    if (GlobalVar.pinResult == false) { return; }
                                }
                            }
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

                            if ((bool)dt.Rows[0]["Cetak"] == true)
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
                            rptParams.Add(new ReportParameter("Tipe", "DND"));


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

        private void dgBayarDenda_Enter(object sender, EventArgs e)
        {
            // data pembayaran denda
            selectedGrid = enumSelectedGrid.GridPembayaran;
        }

        private void dgDenda_Enter(object sender, EventArgs e)
        {
            // detil saldo denda
            selectedGrid = enumSelectedGrid.GridSaldo;
        }

        private void dgTransaksiDetail_Enter(object sender, EventArgs e)
        {
            // header sumber denda
            selectedGrid = enumSelectedGrid.GridHeader;
        }

        private void dgBayarDenda_SelectionChanged(object sender, EventArgs e)
        {
            if (dgBayarDenda.SelectedCells.Count > 0)
            {
                cmdPRINTKW.Enabled = true;
            }
        }

        private void dgDenda_SelectionChanged(object sender, EventArgs e)
        {
            cmdPRINTKW.Enabled = false;
        }

        private void dgTransaksiDetail_SelectionChanged(object sender, EventArgs e)
        {
            cmdPRINTKW.Enabled = false;
        }
    }
}
