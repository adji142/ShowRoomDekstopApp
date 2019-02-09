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
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPenerimaanTitipan : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { GridTitipan, GridIden };
        enumSelectedGrid selectedGrid = enumSelectedGrid.GridTitipan;
        DataTable dtcustomer = new DataTable();

        public frmPenerimaanTitipan()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (GvCustomerByPjl.SelectedCells.Count > 0)
            {
                Guid cust = new Guid(GvCustomerByPjl.SelectedCells[0].OwningRow.Cells["CustID"].Value.ToString());
                string custn = GvCustomerByPjl.SelectedCells[0].OwningRow.Cells["NamaCustomer"].Value.ToString();

                Penjualan.frmTitipanUpdate ifrmChild = new Penjualan.frmTitipanUpdate(this, cust, custn);
                Program.MainForm.CheckMdiChildren(ifrmChild);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
              string selectedTitipanRowID = "";

              bool deletable = true;
              if (gvDaftarTitipan.SelectedCells.Count > 0)
              {
                  Guid RowID = new Guid(gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                  if (CheckPrint(RowID) == true)
                  {
                      MessageBox.Show("Sudah dilakukan pencetakan kwitansi tidak dapat menghapus data ini!");
                      return;
                  }
                  Guid penerimaanUangRowID = (Guid)Tools.isNull(gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["PenerimaanUangRowID"].Value, Guid.Empty);
                  // cek data penerimaan angsurannya itu punya penerimaanrowid ngga 
                  if (penerimaanUangRowID == Guid.Empty || penerimaanUangRowID.ToString() == "" || penerimaanUangRowID == null)
                  {
                      // kalo kosong ya udah ga usah diapa2in
                  }
                  // kalo iya cek udah ada jurnal blom
                  else
                  {
                      // lakukan pengecekan kalo ada penerimaanUangRowID
                      using(Database db = new Database(GlobalVar.DBFinanceOto))
                      {
                          DataTable dummy = new DataTable();
                          db.Commands.Add(db.CreateCommand("usp_CheckJournalByPenerimaanUangRowID"));
                          db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
                          dummy = db.Commands[0].ExecuteDataTable();
                          // kalo di dummy ada datanya, 1 aja itu berarti udah ada data jurnal, jadi deletenya di disable
                          if(dummy.Rows.Count > 0)
                          {
                              deletable = false;
                          }
                      }
                      
                  }
              }
              if(deletable == true)
              {
                  if (gvDaftarTitipan.SelectedCells.Count >= 1)
                  {
                      selectedTitipanRowID = gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                      
                      if (CheckDeleteRule(new Guid(selectedTitipanRowID)) == true )
                      {
                          DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                          DateTime date = GlobalVar.GetServerDate;
                          Calendar cal = dfi.Calendar;
                          int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                          Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusKwitansiPelunasan), "Hapus Pelunasan Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                          if (GlobalVar.pinResult == false) { return; }
                                                
                          try
                          {
                              using (Database db = new Database())
                              {

                                  DataTable dtDaftarTitipan = new DataTable();
                                  db.Commands.Add(db.CreateCommand("usp_TitipanDelete"));
                                  db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.Date, rdbTanggalTitip.FromDate.Value));
                                  db.Commands[0].ExecuteNonQuery();
                                  MessageBox.Show("Delete penerimaan titipan berhasil", "Konfirmasi");
                                  RefreshGridTitipan();  
                              }
                          }
                          catch (Exception ex)
                          {
                              Error.LogError(ex, "Error pada saat menampilkan daftar titipan");
                          }

                      }
                      //boleh didelete di hari yg sama dan belum ada iden 
                      else if (CheckDeleteRule(new Guid(selectedTitipanRowID)) == false && gvDaftarIden.Rows.Count == 0)
                      {
                          try
                          {
                              using (Database db = new Database())
                              {

                                  DataTable dtDaftarTitipan = new DataTable();
                                  db.Commands.Add(db.CreateCommand("usp_TitipanDelete"));
                                  db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(selectedTitipanRowID)));
                                  db.Commands[0].ExecuteNonQuery();
                                  MessageBox.Show("Delete penerimaan titipan berhasil", "Konfirmasi");
                              }
                          }
                          catch (Exception ex)
                          {
                              Error.LogError(ex, "Error pada saat menampilkan daftar titipan");
                          }
                      }
                      else if (CheckDeleteRule(new Guid(selectedTitipanRowID)) == false && gvDaftarIden.Rows.Count >= 1)
                      {
                          MessageBox.Show("Sudah ada identifikasi, delete tidak diperbolehkan", "Konfirmasi"); 
                      }
                          

                  }
              }
              else
              {
                  MessageBox.Show("Data Jurnal Sudah terbentuk, tidak dapat melakukan penghapusan data.");
              }
        }

       
        private void gvDaftarTitipan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void frmPenerimaanTitipan_Load(object sender, EventArgs e)
        {
            DateTime dtServerDate = GlobalVar.GetServerDate;
            rdbTanggalTitip.FromDate = new DateTime(dtServerDate.Year, dtServerDate.Month, 1).AddMonths(-6);// minta from nya dimin 6 bulan ke belakang
            rdbTanggalTitip.ToDate = dtServerDate.Date; 

            cbxStatusSaldoTitip.SelectedIndex = 0;
            RefreshGridTitipan();

            rdbTanggalTitip2.FromDate = new DateTime(dtServerDate.Year, dtServerDate.Month, 1);
            rdbTanggalTitip2.ToDate = dtServerDate.Date;

            RefreshGridCustomer2();
        }

        private void gvDaftarTitipan_SelectionChanged(object sender, EventArgs e)
        {
            BindDataIden();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshGridCustomer();
        }


        public void RefreshGridCustomer()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtDaftarTitipan = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Customer_List_ByPjl"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, rdbTanggalTitip.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, rdbTanggalTitip.ToDate.Value));
                    if (txtNoAR.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@noar", SqlDbType.VarChar, txtNoAR.Text));
                    }
                    dtcustomer = db.Commands[0].ExecuteDataTable();

                    GvCustomerByPjl.DataSource = dtcustomer;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "Error pada saat menampilkan daftar titipan");
            }
        }

        private void GvCustomerByPjl_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshGridTitipan();
        }


        public void RefreshGridTitipan()
        {
            Guid custid = new Guid();
            if(GvCustomerByPjl.SelectedCells.Count > 0)
            {
                custid = new Guid(GvCustomerByPjl.SelectedCells[0].OwningRow.Cells["CustID"].Value.ToString());

                try
                {
                    using(Database db = new Database())
                    {
                        DataTable dtDaftarTitipan = new DataTable(); 
                         db.Commands.Add(db.CreateCommand("usp_DaftarTitipan"));
                         db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, rdbTanggalTitip.FromDate.Value));
                         db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, rdbTanggalTitip.ToDate.Value));
                         db.Commands[0].Parameters.Add(new Parameter("@statusSaldo", SqlDbType.SmallInt, cbxStatusSaldoTitip.SelectedIndex ));
                         db.Commands[0].Parameters.Add(new Parameter("@custid", SqlDbType.UniqueIdentifier, custid));
                         dtDaftarTitipan = db.Commands[0].ExecuteDataTable();


                         if (dtDaftarTitipan.Rows.Count > 0)
                         {
                             gvDaftarTitipan.DataSource = dtDaftarTitipan;
                         }
                         else
                         {
                             gvDaftarTitipan.DataSource = null;
                         }
                    }
                }
                catch(Exception ex)
                {
                    Error.LogError(ex, "Error pada saat menampilkan daftar titipan"); 
                }
            }
        }

        public void FindRowGridDaftarTitipan(string columnName, string value)
        {
            gvDaftarTitipan.FindRow(columnName, value);             
        }

        private void cmdEditTitipan_Click(object sender, EventArgs e)
        {
                string selectedTitipanRowID = "";
                if (gvDaftarTitipan.SelectedCells.Count >= 1)
                {
                    selectedTitipanRowID = gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                    Guid RowID = new Guid(gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                    if (CheckPrint(RowID) == true)
                    {
                        MessageBox.Show("Sudah dilakukan pencetakan kwitansi tidak dapat mengedit data lagi!");
                        return;
                    }
                    if (CheckDeleteRule(new Guid(selectedTitipanRowID)) == false)
                    {
                        Penjualan.frmTitipanUpdate ifrmChild = new Penjualan.frmTitipanUpdate(this, selectedTitipanRowID);
                        Program.MainForm.CheckMdiChildren(ifrmChild);
                    }
                    else
                    {
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.HapusKwitansiPelunasan), "Hapus Pelunasan Pembelian.\nSudah lewat tanggal, tidak diperkenankan menghapus data ini !");
                        if (GlobalVar.pinResult == false) { return; }

                        Penjualan.frmTitipanUpdate ifrmChild = new Penjualan.frmTitipanUpdate(this, selectedTitipanRowID);
                        Program.MainForm.CheckMdiChildren(ifrmChild);
                    }
                }           
        }


        private bool CheckDeleteRule(Guid rowID)
        {
            bool hapus = false;
            DataTable dt = new DataTable();


            DateTime dateRecordCreatedOn = DateTime.MinValue;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Check_TanggalInput_Record"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@TableName", SqlDbType.VarChar, "PenerimaanTitipan"));
                object objRecordCreatedOn = db.Commands[0].ExecuteScalar();
                if (objRecordCreatedOn != DBNull.Value)
                {
                    dateRecordCreatedOn = Convert.ToDateTime(objRecordCreatedOn);
                }

            }

            if (dateRecordCreatedOn.Date == GlobalVar.GetServerDate.Date) hapus = false;
            else hapus = true;

            return hapus;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


        private void gvDaftarTitipan_SelectionRowChanged(object sender, EventArgs e)
        {

        }


        private void BindDataIden()
        {
            
            if (gvDaftarTitipan.SelectedCells.Count >= 1)
            {
                System.Guid titipanRowID = new System.Guid();
                titipanRowID = (Guid)gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_titipaniden_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, titipanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    gvDaftarIden.DataSource = dt;

                }
            }

        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDaftarTitipan.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string _edp;
                    string _terbilang;
                    string _kotatgl;
                    string _kota;
                    string _copy;
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
                        db.Commands.Add(db.CreateCommand("rpt_Kwitansi_PenerimaanTitipan"));
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
                                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang, Convert.ToInt32(PinId.ModulId.KwitansiPenjualan), "Sudah dilakukan cetak Kwitansi Penjualan !");
                                if (GlobalVar.pinResult == false) { return; }
                            }
                        }

                        _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                        _terbilang = Tools.Terbilang(int.Parse(dt.Rows[0]["Nominal"].ToString(), NumberStyles.Currency)) + "RUPIAH";
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


                        // nominal di paling atas yg Administrasi
                        rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["Nominal"]).ToString()));

                        rptParams.Add(new ReportParameter("JnsKw", "Bukti Penitipan"));
                        rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                        rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                        rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                        rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                        rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                        rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString()));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()

                        // tambahan untuk kwitansi
                        rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                        rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                        rptParams.Add(new ReportParameter("Tipe", "TTP"));

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
                        //cmdEditTitipan.Enabled = false;
                        //cmdDelete.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        private void gvDaftarTitipan_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridTitipan;
            gvDaftarTitipan_SelectionChanged(sender, e);
        }

        private void gvDaftarIden_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.GridIden;
        }

        private bool CheckPrint(Guid rowID)
        {
            bool _cetak = false;

            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    _cetak = (bool)Tools.isNull(dt.Rows[0]["Cetak"], false);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return _cetak;
        }

        private void cmdAdjustment_Click(object sender, EventArgs e)
        {
            if (gvDaftarTitipan.SelectedCells.Count >= 1)
            {
                Guid TitipanRowID = new Guid(gvDaftarTitipan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                frmTitipanAdjustment ifrmChild = new frmTitipanAdjustment(this, TitipanRowID);
                ifrmChild.Show();
            }
        }

        private void cbxStatusSaldoTitip_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGridTitipan();
        }

        public void RefreshGridCustomer2()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    DataTable dtDaftarTitipan = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Customer_Titipan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, rdbTanggalTitip2.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, rdbTanggalTitip2.ToDate.Value));
                    dt = db.Commands[0].ExecuteDataTable();

                    GVCustomer2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "Error pada saat menampilkan daftar titipan");
            }
        }

        public void RefreshGridTitipan2()
        {
            Guid custid = new Guid();
            if (GVCustomer2.SelectedCells.Count > 0)
            {
                custid = new Guid(GVCustomer2.SelectedCells[0].OwningRow.Cells["CustID2"].Value.ToString());

                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        DataTable dtDaftarTitipan = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_DaftarTitipan"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, rdbTanggalTitip.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, rdbTanggalTitip.ToDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@statusSaldo", SqlDbType.SmallInt, 2));
                        db.Commands[0].Parameters.Add(new Parameter("@custid", SqlDbType.UniqueIdentifier, custid));
                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            GV_DataTitipan2.DataSource = dt;
                        }
                        else
                        {
                            GV_DataTitipan2.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex, "Error pada saat menampilkan daftar titipan");
                }
            }
        }

        private void RefreshGridIden2()
        {
            try
            {
                if (GV_DataTitipan2.SelectedCells.Count >= 1)
                {
                    System.Guid titipanRowID = new System.Guid();
                    titipanRowID = (Guid)GV_DataTitipan2.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                    DataTable dt = new DataTable();

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_titipaniden_list"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, titipanRowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        GV_Iden2.DataSource = dt;

                    }
                }
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GVCustomer2_SelectionRowChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            RefreshGridCustomer2();
        }

        private void GV_DataTitipan2_SelectionRowChanged(object sender, EventArgs e)
        {
          
        }

        private void GVCustomer2_SelectionChanged(object sender, EventArgs e)
        {
            RefreshGridTitipan2();
        }

        private void GV_DataTitipan2_SelectionChanged(object sender, EventArgs e)
        {
            RefreshGridIden2();
        }
    }
}
