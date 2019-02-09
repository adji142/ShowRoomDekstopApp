using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.PiutangKaryawan
{
    public partial class frmPiutangKaryawanBrowse : ISA.Controls.BaseForm
    {

        #region variables
        enum enumSelectedGrid { PKSelected, PKDetailSelected };
        //enumSelectedGrid selectedGrid;// = enumSelectedGrid.PKSelected;    
        DateTime  _fromDate, _toDate; 
        int flag=0;
        Guid PiutangKaryawanRowId;
        Guid KaryawanRowID;
        Double SaldoTotalPinjaman;
        Double _TotalPinjaman;
        Double _TotalPembayaran;
        #endregion
          

        public frmPiutangKaryawanBrowse()
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(1 - _toDate.Day);    //_toDate;
            rangeDateBox1.ToDate = _toDate;
            rangeDateBox1.FromDate= _fromDate;
            rangeDateBox2.ToDate = _toDate;
            rangeDateBox2.FromDate = _toDate;
        }
                    
        
        private void cmdClose_Click(object sender, EventArgs e)

        {
            this.Close();
        }

        private void frmPiutangKaryawanBrowse_Load(object sender, EventArgs e)
        {
            RefreshDataHeaderPiutangKaryawan();

            if (dataGridViewKaryawan.SelectedCells.Count >= 1)
            {

                KaryawanRowID = (Guid)dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                LoadPiutangKaryawanByKaryawanID(KaryawanRowID);
                RefreshDetail();
            }
            //RefreshDataHeader();
            //RefreshData();
        }

        
        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch(flag)
            {
                case 0://enumSelectedGrid.PKSelected :
                    {
                        // pin
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting,
                        Convert.ToInt32(PinId.ModulId.PiutangKaryawan), "Untuk menambah daftar piutang karyawan memerlukan PIN!");

                        if (GlobalVar.pinResult == false) { return; }

                        PiutangKaryawan.FrmPiutangKaryawanUpdateHeader ifrmChild = new PiutangKaryawan.FrmPiutangKaryawanUpdateHeader(this,KaryawanRowID,SaldoTotalPinjaman); //(this); 
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    };
                    break;
                case 1://enumSelectedGrid.PKDetailSelected:
                    {
                        /* Bisa Entry Pembayaran jika sudah realisasi dan masih ada saldo */
                        int statusApproval;
                        if (dataGridPiutangKaryawan.Rows.Count > 0)
                        {
                            statusApproval = (int)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["StatusApproval"].Value;
                            
                                                                     
                        if (Convert.IsDBNull(dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["SaldoPinjaman"].Value) && statusApproval != 9)
                        {
                            MessageBox.Show("Maaf, data piutang ini belum di realisasi.");
                            return;
                        }
                        //else if ( Convert.ToInt32(dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["SaldoPinjaman"].Value)==0)
                        //{
                        //    MessageBox.Show("Sudah Lunas.");
                        //    return;
                        //}
                        else
                        {

                            //Guid _headerID = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            //Guid _headerRowID = (Guid)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                            PiutangKaryawan.FrmPiutangKaryawanUpdateDetail ifrmChild2 = new PiutangKaryawan.FrmPiutangKaryawanUpdateDetail(this, KaryawanRowID,SaldoTotalPinjaman);
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.Show();
                        }


                        }

                    //    if ((statusApproval == 9))
                    //    {
                    //    }
                    //    else MessageBox.Show("Belum direalisasikan atau sudah lunas !!");
                    ////};
                        break;
            }
                default: break;
            }

        }

        

        private void dataGridPiutangKaryawan_SelectionChanged(object sender, EventArgs e)
        {
            //RefreshDetail();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.RefreshData();
            this.RefreshDataHeaderPiutangKaryawan();
        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridPiutangKaryawan.Rows.Count > 0)
            {

                switch (flag)
                {
                    case 0://enumSelectedGrid.PKSelected:
                        {
                            bool lOk = true;
                            Int32 StApv = Convert.ToInt32(dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["StatusApproval"].Value);
                            if (StApv == 8)
                            {
                                if (MessageBox.Show("Apakah anda yakin akan merealisasikan piutang karyawan ini ", "Informasi", MessageBoxButtons.YesNo) == DialogResult.No)
                                    lOk = false;

                            }

                            if (lOk)
                            {
                                Guid _rowID = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                                KaryawanRowID = (Guid)dataGridViewKaryawan.Rows[0].Cells["HeaderRowID"].Value;// SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                                PiutangKaryawan.FrmPiutangKaryawanUpdateHeader ifrmChild = new PiutangKaryawan.FrmPiutangKaryawanUpdateHeader(this, _rowID,KaryawanRowID);
                                ifrmChild.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild);
                                ifrmChild.Show();
                            }
                            break;

                        }
                    case 1://enumSelectedGrid.PKDetailSelected:
                        {
                            /* Bisa Entry Pembayaran jika sudah realisasi */
                            if (dataGridPiutangKaryawanDetail.SelectedCells.Count >= 1)
                            {
                                DateTime dDay = GlobalVar.GetServerDate;
                                DateTime tanggalbayar =(DateTime)dataGridPiutangKaryawanDetail.SelectedCells[0].OwningRow.Cells["TanggalPembayaran"].Value;
                                Guid _headerID = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                                Guid _karyawanRowID = (Guid)dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                                Guid _detailID = (Guid)dataGridPiutangKaryawanDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                                if (CheckBackDate(tanggalbayar) == true)
                                {
                                    MessageBox.Show("Maaf, tidak diperkenankan Edit data.");//MessageBox.Show("Transaksi Sudah Lewat 2 Hari !!");
                                    return;
                                }

                                //if (tanggalbayar < dDay.AddDays(-2))
                                //{
                                //    MessageBox.Show("Transaksi Sudah Lewat 2 Hari !!");
                                //    return;
                                //}
                                else
                                {

                                    //Guid _headerID = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                    //Guid _detailID = (Guid)dataGridPiutangKaryawanDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                                    PiutangKaryawan.FrmPiutangKaryawanUpdateDetail ifrmChild2 = new PiutangKaryawan.FrmPiutangKaryawanUpdateDetail(this, KaryawanRowID, _detailID);
                                    Program.MainForm.RegisterChild(ifrmChild2);
                                    ifrmChild2.Show();
                                }
                            }
                            else MessageBox.Show("Tidak Ada Record..!!");
                        };
                        break;

                    default: break;

                }
            }
        }

        #region Parameter Lock

        private List<int> ParameterKuncian()
        {
            List<int> _parameterkuncian = new List<int>();
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Lock"));
                dt = db.Commands[0].ExecuteDataTable();
                _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);

            }
            return _parameterkuncian;
        }

        private bool CheckBackDate(DateTime dtTanggal)
        {
            bool Expired = false;
            List<int> parameter = ParameterKuncian();
            if (dtTanggal <= GlobalVar.GetServerDate.AddDays(-parameter[0])) { Expired = true; }
            return Expired;
        }



        #endregion

        private void updateNominalSaldo(Guid RowIDPK,Double Nominal)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NominalPinjaman_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDPK));
                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, Nominal));
                dt = db.Commands[0].ExecuteDataTable();
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 0: //enumSelectedGrid.PKSelected:
                    {
                        // Jika sudah SubMit tidak boleh Delete 
                        // Tanggal Transaksi tidak lebih dari 2 hari
                        if (dataGridPiutangKaryawan.SelectedCells.Count > 0)
                        {
                            DateTime dDay = GlobalVar.GetServerDate;
                            DateTime TanggalInput = (DateTime)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["CreatedOn"].Value;
                            int StatusApproval = (int)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["StatusApproval"].Value;
                            Guid JournalRowID = (Guid)Tools.isNull(dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value, Guid.Empty);
                            if (StatusApproval == 0)
                            {
                                if (CheckBackDate(TanggalInput) == true)
                                {
                                    MessageBox.Show("Maaf, tidak diperkenankan hapus data.");//MessageBox.Show("Transaksi Sudah Lewat 2 Hari.. !!");
                                    return;
                                }

                                //if (TanggalInput < dDay.AddDays(-2)) MessageBox.Show("Transaksi Sudah Lewat 2 Hari.. !!");
                                else
                                    DeleteHeader();
                            }

                            else if (StatusApproval != 9 && StatusApproval != 0)
                            {
                                MessageBox.Show(" Sudah Ada Pengajuan...!!");
                            }
                            

                            if (StatusApproval == 9)
                            {
                                if (JournalRowID.Equals(Guid.Empty))
                                {
                                    if (Tools.IsExpiredLevel3(TanggalInput) == false)
                                    {

                                        Double NominalHeader = Convert.ToDouble(this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["TotalPinjaman"].Value);
                                        Double Nominal = Convert.ToDouble(this.dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["NominalPinjam"].Value);
                                        Double JumlahPinjaman = NominalHeader - Nominal;
                                        if (JumlahPinjaman > 0) { DeleteHeader(); }
                                        
                                    }

                                }
                            }
                        }
                     
                        

                    }; break;
                case 1: //enumSelectedGrid.PKDetailSelected:
                    {
                        // Tanggal Transaksi tidak lebih dari 2 hari
                        DateTime dDay = GlobalVar.GetServerDate;
                        DateTime tanggalbayar = (DateTime) dataGridPiutangKaryawanDetail.SelectedCells[0].OwningRow.Cells["TanggalPembayaran"].Value;

                        if (CheckBackDate(tanggalbayar) == true)
                        {
                            MessageBox.Show("Maaf, tidak diperkenankan hapus data.");//MessageBox.Show("Transaksi Sudah Lewat 2 Hari !!");
                            return;
                        }
                        
                        //if (tanggalbayar < dDay.AddDays(-2)) MessageBox.Show("Transaksi Sudah Lewat 2 Hari !!");     
                        else
                            DeleteDetail();
                    };
                    break;
                default: break;
            }

        }


#region Function 

        public void RefreshDataHeader()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Open();
                    _fromDate = (DateTime)rangeDateBox1.FromDate;
                    _toDate = (DateTime)rangeDateBox1.ToDate;

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, _toDate));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridViewKaryawan.DataSource = dt;
                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void RefreshDataHeaderPiutangKaryawan()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Open();
                    _fromDate = (DateTime)rangeDateBox1.FromDate;
                    _toDate = (DateTime)rangeDateBox1.ToDate;

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanHeaderIsApproval_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, _fromDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, _toDate));

                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        dataGridViewKaryawan.DataSource = dt;
                        
                    }
                    

                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void LoadPiutangKaryawanByKaryawanID(Guid RowID)
        {
            try
            {
                using (Database db = new Database())
                {
                    
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanByKaryawanID_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridPiutangKaryawan.DataSource = dt;
                    
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


    

      public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Open();
                    _fromDate = (DateTime)rangeDateBox1.FromDate;
                    _toDate = (DateTime)rangeDateBox1.ToDate;

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST_FILTER_Tanggal"));
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, _fromDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, _toDate));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridPiutangKaryawan.DataSource = dt;
                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

      public void RefreshDetail()
        {
            try
            {
                //if (dataGridPiutangKaryawan.SelectedCells.Count > 0)
                if (dataGridViewKaryawan.SelectedCells.Count > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtDetail = new DataTable();
                    ///Guid _headerID = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Guid _headerID = (Guid)dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanPembayaran_LIST_FILTER_HeaderID"));
                        db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID", SqlDbType.UniqueIdentifier, _headerID));
                        dtDetail = db.Commands[0].ExecuteDataTable();
                        dataGridPiutangKaryawanDetail.DataSource = dtDetail;
                    }

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


      public void FindRowHeader(String ColumnName, String value)
      {
          dataGridViewKaryawan.FindRow(ColumnName, value);
      }

      public void FindRow(string columnName, string value)
      {
          dataGridPiutangKaryawan.FindRow(columnName, value);
      }

      public void FindRowDetail(string columnName, string value)
      {
          dataGridPiutangKaryawanDetail.FindRow(columnName, value);
      }
      private void DeleteHeader()
      {
          if (dataGridPiutangKaryawan.SelectedCells.Count > 0)
          {
              Guid rowID        = (Guid)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
              string cNobukti   = dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
              Guid RowID_pk = (Guid)this.dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
              //Double NominalHeader = Convert.ToDouble(this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["TotalPinjaman"].Value);
              Double Nominal = Convert.ToDouble(this.dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["NominalPinjam"].Value);
              
              int StatusApproval = (int)dataGridPiutangKaryawan.SelectedCells[0].OwningRow.Cells["StatusApproval"].Value;
              
              if (MessageBox.Show("Yakin No.Bukti : " + cNobukti  + " Akan diDelete ??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                  try
                  {
                      using (Database db = new Database())
                      {
                          DataTable dt = new DataTable();
                          db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_DELETE"));
                          db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                          db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, cNobukti ));
                          dt = db.Commands[0].ExecuteDataTable();
                      }

                      if (StatusApproval == 9)
                      {
                          updateNominalSaldo(RowID_pk, Nominal);
                      }
                      
                      


                      MessageBox.Show("Record telah dihapus");
                      //this.RefreshData();
                      RefreshDataHeaderPiutangKaryawan();
                      LoadPiutangKaryawanByKaryawanID(KaryawanRowID);
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
      private void DeleteDetail()
      {
          if (dataGridPiutangKaryawanDetail.SelectedCells.Count > 0)
          {
              Guid rowID = (Guid)dataGridPiutangKaryawanDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
              string cNobukti = dataGridPiutangKaryawanDetail.SelectedCells[0].OwningRow.Cells["NoBuktiDetail"].Value.ToString();
              if (MessageBox.Show("Yakin No.Bukti : " + cNobukti + " Akan diDelete ??", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                  try
                  {
                      using (Database db = new Database())
                      {
                          DataTable dt = new DataTable();
                          db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanPembayaran_DELETE"));
                          db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                          db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, cNobukti));
                          dt = db.Commands[0].ExecuteDataTable();
                      }

                      MessageBox.Show("Record telah dihapus");
                      //this.RefreshData();
                      
                      this.RefreshDetail();
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

#endregion 

      private void dataGridPiutangKaryawan_Click(object sender, EventArgs e)
      {

          //RefreshDetail();
          //selectedGrid = enumSelectedGrid.PKSelected;
      }

      private void dataGridPiutangKaryawanDetail_Click(object sender, EventArgs e)
      {

          //selectedGrid = enumSelectedGrid.PKDetailSelected;

      }

      private void tabPiutangHeaderDetail_SelectedIndexChanged(object sender, EventArgs e)
      {
          switch(tabPiutangHeaderDetail.SelectedIndex)
          {
              case 0:flag = 0;
            
                      break;

              case 1:
                      {

                          flag = 1;
                          break;
                      }
                       
                      
          }  
      }

      private void LoadDataSelected()
      {
          if (dataGridViewKaryawan.SelectedCells.Count > 0)
          {
              if (!Convert.IsDBNull(this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value))
              {
                  PiutangKaryawanRowId = (Guid)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                  KaryawanRowID = (Guid)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                  String NamaKaryawan = (String)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["NamaKaryawanHeader"].Value;
                  _TotalPinjaman = (Double)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["TotalPinjaman"].Value;
                  _TotalPembayaran = Convert.ToDouble(this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["TotalPembayaran"].Value);
                  if (_TotalPinjaman != 0 && _TotalPembayaran == 0)
                  {
                      SaldoTotalPinjaman = _TotalPinjaman;
                  }
                  else
                  {
                      SaldoTotalPinjaman = (Double)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["saldo"].Value;
                  }
                  lblNamaKaryawan.Text = NamaKaryawan;
                  LoadPiutangKaryawanByKaryawanID(PiutangKaryawanRowId);
                  RefreshDetail();
              }
          }
      }

      private void dataGridViewKaryawan_Click(object sender, EventArgs e)
      {
          LoadDataSelected();
      
      }

      private void dataGridViewKaryawan_RowEnter(object sender, DataGridViewCellEventArgs e)
      {

          LoadDataSelected();
      }

      private void commandButton1_Click(object sender, EventArgs e)
      {
          //if (dataGridViewKaryawan.Rows.Count > 0)
          //{
          //    List<DataTable> dt = new List<DataTable>();
          //    List<String> ds = new List<String>();
          //    ds.Add("dsPiutangKaryawan_usp_PiutangKaryawanHeaderIsApproval_LIST");
          //    dt.Add((DataTable)dataGridViewKaryawan.DataSource);

          //    string _tglcutoff = "Tgl Cut Off : " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
          //    List<ReportParameter> rptParam = new List<ReportParameter>();
          //    rptParam.Add(new ReportParameter("UserID", SecurityManager.UserID));
          //    rptParam.Add(new ReportParameter("TglCutOff", _tglcutoff));
          //    frmReportViewer ifrmReport = new frmReportViewer("PiutangKaryawan.rptPiutangKaryawan.rdlc", rptParam, dt, ds);
          //    ifrmReport.Show();
          //}

          panelPrintPK.BringToFront();
          panelPrintPK.Visible = true;
          txtTglCutOff.DateValue = GlobalVar.GetServerDate;
      }

      private void cmdPrintDetail_Click(object sender, EventArgs e)
      {
          if (dataGridViewKaryawan.SelectedCells.Count > 0)
          {
              Guid RowID = (Guid)this.dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

              DataTable dt = new DataTable();
              using (Database db = new Database())
              {
                  db.Commands.Add(db.CreateCommand("rsp_PiutangKaryawan_ByKaryawan_LIST_Detail"));
                  db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID", SqlDbType.UniqueIdentifier, RowID));
                  db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox2.FromDate.Value));
                  db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox2.ToDate.Value));
                  dt = db.Commands[0].ExecuteDataTable();
              }

              if (dt.Rows.Count > 0)
              {
                  String NamaKaryawan = Tools.isNull(dataGridViewKaryawan.SelectedCells[0].OwningRow.Cells["NamaKaryawanHeader"].Value, "").ToString();
                  LaporanDetailPK(dt, NamaKaryawan);
              }
              else
              {
                  MessageBox.Show("Tidak ada data ditemukan!");
              }
          }
      }

      private void LaporanDetailPK(DataTable dt, String NamaKaryawan)
      {
          using (ExcelPackage p = new ExcelPackage())
          {
              p.Workbook.Properties.Author = "SAS FINANCE";
              p.Workbook.Properties.Title = "DETIL PIUTANG KARYAWAN";

              p.Workbook.Worksheets.Add("Det. PK");
              ExcelWorksheet ws = p.Workbook.Worksheets[1];

              ws.Name = "Det. PK"; //Setting Sheet's name
              ws.Cells.Style.Font.Size = 9; //Default font size for whole sheet
              ws.Cells.Style.Font.Name = "Calibri";

              int MaxCol = 6;
              int startH = 7;

              ws.Cells[1, 1].Worksheet.Column(1).Width = 15; // Tanggal
              ws.Cells[1, 2].Worksheet.Column(2).Width = 15; // NoKwitansi
              ws.Cells[1, 3].Worksheet.Column(3).Width = 25; // Keterangan
              ws.Cells[1, 4].Worksheet.Column(4).Width = 18; // Pinjam
              ws.Cells[1, 5].Worksheet.Column(5).Width = 18; // Bayar
              ws.Cells[1, 6].Worksheet.Column(6).Width = 18; // Saldo

              string Title = "DETIL PIUTANG KARYAWAN";

              ws.Cells[1, 1].Value = "";
              ws.Cells[2, 1].Value = Title;
              ws.Cells[3, 1].Value = " ";

              ws.Cells[2, 1, 2, MaxCol].Merge = true;
              ws.Cells[4, 1].Value = "Nama Karyawan  : " + NamaKaryawan;
              ws.Cells[4, 1, 4, 4].Merge = true;
              ws.Cells[4, 1, 4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
              ws.Cells[5, 1].Value = "Per Tanggal : " + string.Format("{0:dd-MM-yyyy}", GlobalVar.GetServerDate);
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

              ws.Cells[startH, 2].Value = "No Bukti";
              ws.Cells[startH, 2, startH + 1, 2].Merge = true;

              ws.Cells[startH, 3].Value = "Keterangan";
              ws.Cells[startH, 3, startH + 1, 3].Merge = true;

              ws.Cells[startH, 4].Value = "Pinjam (D)";
              ws.Cells[startH, 4, startH + 1, 4].Merge = true;

              ws.Cells[startH, 5].Value = "Bayar (K)";
              ws.Cells[startH, 5, startH + 1, 5].Merge = true;

              ws.Cells[startH, 6].Value = "Saldo";
              ws.Cells[startH, 6, startH + 1, 6].Merge = true;

              ws.Cells[startH, 1, startH + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
              ws.Cells[startH, 1, startH + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
              ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Bold = true;
              ws.Cells[startH, 1, startH + 1, MaxCol].Style.Font.Size = 10;
              ws.Cells[startH, 1, startH + 1, MaxCol].Style.WrapText = true;

              #endregion

              #region FillData
              int idx = startH + 2;
              int no = 1;
              Double tempSaldo = 0;
              foreach (DataRow dr in dt.Rows)
              {
                  ws.Cells[idx, 1].Value = dr["Tanggal"];
                  ws.Cells[idx, 2].Value = dr["NoBukti"];
                  ws.Cells[idx, 3].Value = dr["Uraian"];
                  ws.Cells[idx, 4].Value = dr["Pinjam"];
                  ws.Cells[idx, 5].Value = dr["Bayar"];
                  tempSaldo = tempSaldo + Convert.ToDouble(Tools.isNull(dr["Pinjam"].ToString(), 0).ToString());
                  tempSaldo = tempSaldo - Convert.ToDouble(Tools.isNull(dr["Bayar"].ToString(), 0).ToString());
                  ws.Cells[idx, 6].Value = tempSaldo;
                  idx++;
              }
              #endregion

              #region Summary & Formatting
              ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
              ws.Cells[startH, 1, startH + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);

              ws.Cells[idx, 1, idx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
              ws.Cells[idx, 1, idx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Gray);
              ws.Cells[idx, 1].Value = "Total";
              ws.Cells[idx, 1, idx, 3].Merge = true;
              ws.Cells[idx, 1, idx, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
              ws.Cells[idx, 1, idx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
              ws.Cells[idx, 1, idx, MaxCol].Style.Font.Bold = true;
              ws.Cells[idx, 1, idx, MaxCol].Style.Font.Size = 10;

              // AR dan denda 
              ws.Cells[idx, 4].Formula = "Sum(" + ws.Cells[startH + 1, 4].Address + ":" + ws.Cells[idx - 1, 4].Address + ")";
              ws.Cells[idx, 5].Formula = "Sum(" + ws.Cells[startH + 1, 5].Address + ":" + ws.Cells[idx - 1, 5].Address + ")";

              ws.Cells[startH + 2, 4, idx, 6].Style.Numberformat.Format = "#,##0.00;(#,##0.00);0";
              ws.Cells[startH + 2, 4, idx, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
              ws.Cells[startH + 2, 1, idx - 1, 1].Style.Numberformat.Format = "dd-MMM-yyyy";
              ws.Cells[startH + 2, 1, idx - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

              ws.Cells[startH + 2, 2, idx - 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

              ws.Cells[idx + 3, 1].Value = "User ID : " + SecurityManager.UserInitial + " " + GlobalVar.GetServerDate.ToString("dd-MMM-yyyy");
              ws.Cells[idx + 3, 1, idx + 3, 3].Merge = true;
              ws.Cells[idx + 3, 1, idx + 3, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
              ws.Cells[idx + 4, 1].Value = "Title      : Daftar Piutang Karyawan - " + NamaKaryawan;
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
              sf.FileName = "Detil Piutang Karyawan " + NamaKaryawan + " - " + GlobalVar.GetServerDate.ToString("dd-MM-yyy") + ".xlsx";

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

      public DataTable ListPiutangKaryawanCutOff(DateTime Tanggal)
      {
          DataTable dt = new DataTable();
          try
          {
              using (Database db = new Database())
              {
                  db.Open();
                  db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanHeaderIsApproval_LIST_ByTgl"));
                  db.Commands[0].Parameters.Add(new Parameter("@TglCutOff", SqlDbType.Date, Tanggal));

                  dt = db.Commands[0].ExecuteDataTable();

                  db.Close();
                  db.Dispose();
              }
          }
          catch (Exception ex)
          {
              Error.LogError(ex);
          }
          return dt;
      }

      private void cmdPrintCutOff_Click(object sender, EventArgs e)
      {
          panelPrintPK.BringToFront();
          panelPrintPK.Visible = true;
          txtTglCutOff.DateValue = GlobalVar.GetServerDate;
      }

      private void cmdPrintLapPK_Click(object sender, EventArgs e)
      {
          printLapPKbyTanggal();
          panelPrintPK.Visible = false;
          panelPrintPK.SendToBack();
      }

      private void cmdClosePK_Click(object sender, EventArgs e)
      {
          panelPrintPK.Visible = false;
          panelPrintPK.SendToBack();
      }

      private void printLapPKbyTanggal()
      {
          DataTable dtpk = ListPiutangKaryawanCutOff((DateTime)txtTglCutOff.DateValue);
          if (dtpk.Rows.Count == 0)
          {
              MessageBox.Show("No Data");
              return;
          }
          List<DataTable> dt = new List<DataTable>();
          List<String> ds = new List<String>();
          ds.Add("dsPiutangKaryawan_usp_PiutangKaryawanHeaderIsApproval_LIST");
          dt.Add(dtpk);

          string _tglcutoff = "Tgl Cut Off : " + ((DateTime)txtTglCutOff.DateValue).ToString("dd-MMM-yyyy");
          List<ReportParameter> rptParam = new List<ReportParameter>();
          rptParam.Add(new ReportParameter("UserID", SecurityManager.UserID));
          rptParam.Add(new ReportParameter("TglCutOff", _tglcutoff));
          frmReportViewer ifrmReport = new frmReportViewer("PiutangKaryawan.rptPiutangKaryawan.rdlc", rptParam, dt, ds);
          ifrmReport.Show();
      }


    }
}
