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
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmPembayaranMPM : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;
        DataTable dtHeader, dtDetail;
        DateTime _fromDate, _toDate; 

        
        //untuk memastikan cbLeasing sudah selesai diisi 
        bool v_cbLeasing = false;

        public frmPembayaranMPM()
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(-1 * (_toDate.Day - 1));
            rgtglKlr.ToDate = _toDate;
            rgtglKlr.FromDate = _fromDate;
        }

        private void frmPembayaranMPM_Load(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rgtglKlr.FromDate;
            _toDate = (DateTime)rgtglKlr.ToDate;
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PembayaranMPM_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    GVHeader.DataSource = dt;
                    dtHeader = dt;
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

        public void RefreshData(Guid _RowID)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PembayaranMPM_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    GVHeader.DataSource = dt;
                    dtHeader = dt;
                }
                if (GVHeader.Rows.Count > 0)
                {
                    GVHeader.FindRow("RowID", _RowID.ToString());
                    refreshDetail();
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

        public void refreshDetail()
        {
            if (GVHeader.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PembayaranMPM_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                        dt = db.Commands[0].ExecuteDataTable();
                        GVDetail.DataSource = dt;
                        dtDetail = dt;
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
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rgtglKlr.FromDate;
            _toDate = (DateTime)rgtglKlr.ToDate;
            RefreshData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, "idenMPM");
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
                case enumSelectedGrid.Detail:
                    Guid RowIDHeader = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    Kasir.frmPembayaranMPMIdenHutang ifrmChild2 = new Kasir.frmPembayaranMPMIdenHutang(this, RowIDHeader);
                    ifrmChild2.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild2);
                    ifrmChild2.Show();                    
                    break;
            }

            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GVHeader_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
            cmdADD.Enabled = true;
        }

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                refreshDetail();
                cmdADD.Enabled = true;
            }
        }

        private void GVHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgS = enumSelectedGrid.Header;
            cmdADD.Enabled = true;
        }

        private void GVDetail_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
            if (GVHeader.Rows.Count > 0)
            {
                if (Double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["NominalSisa"].Value.ToString()) > 0)
                {
                    cmdADD.Enabled = true;
                }
                else
                {
                    cmdADD.Enabled = false;
                }
            }
        }

        private void GVDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
            if (GVHeader.Rows.Count > 0)
            {
                if (Double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["NominalSisa"].Value.ToString()) > 0)
                {
                    cmdADD.Enabled = true;
                }
                else
                {
                    cmdADD.Enabled = false;
                }
            }
        }

        private void cmdBatalIden_Click(object sender, EventArgs e)
        {
            if (GVDetail.Rows.Count > 0)
            {
                deleteIden();
            }
        }

        private void deleteIden()
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:

                    MessageBox.Show("Header tidak boleh dihapus");
                    return;
                //if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    Guid _rowID = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                //    using (Database db = new Database(GlobalVar.DBShowroom))
                //    {
                    //        db.Commands.Add(db.CreateCommand("[usp_IdenMPM_DELETE]"));
                //        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                //        db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, "header"));
                //        db.Commands[0].ExecuteNonQuery();
                //    }
                //    MessageBox.Show("Data berhasil dihapus");
                //    RefreshData();   
                //}

                break;
                case enumSelectedGrid.Detail:

                DateTime _tglIden = ((DateTime)GVDetail.SelectedCells[0].OwningRow.Cells["TanggalIden"].Value).AddDays(1).Date;

                if (_tglIden<DateTime.Now.Date)
                {
                    MessageBox.Show("Anda hanya diperbolehkan membatalkan data hari ini dan/atau kemarin");
                    return;
                }

                if (GVDetail.SelectedCells[0].OwningRow.Cells["JenisPelunasan"].Value.ToString() == "Penerimaan Uang")
                {
                    MessageBox.Show("Iden dari Penerimaan Uang tidak dapat di hapus");
                    return;
                  }

                     if (GVDetail.SelectedCells[0].OwningRow.Cells["JournalMPMRowID"].Value.ToString() != "")
                {
                    MessageBox.Show("Data sudah dijurnal, Anda tidak diperbolehkan Mutasi data ini.");
                    return;
                  }

                    


                if (MessageBox.Show(Messages.Question.AskDelete, "Anda yakin akan menghapus data ini ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid _rowID = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["PelRowID"].Value;

                    using (Database db = new Database(GlobalVar.DBShowroom))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_IdenMPM_DELETE]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@type", SqlDbType.VarChar, "detail"));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Data berhasil dihapus");
                    Guid RowIDHeader = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    RefreshData(RowIDHeader);
                }             
                  break;
            }
        }

        private void cmdMutasi_Click(object sender, EventArgs e)
        {
            if (GVDetail.Rows.Count > 0)
            {
                DateTime _tglIden = ((DateTime)GVDetail.SelectedCells[0].OwningRow.Cells["TanggalIden"].Value).AddDays(1).Date;

                if (_tglIden < DateTime.Now.Date)
                {
                    MessageBox.Show("Anda hanya diperbolehkan mutasi data hari ini dan/atau kemarin");
                    return;
                }

                if (GVDetail.SelectedCells[0].OwningRow.Cells["JenisPelunasan"].Value.ToString() == "Penerimaan Uang")
                {
                    MessageBox.Show("Iden dari Penerimaan Uang tidak dapat di hapus");
                    return;
                }

                if (GVDetail.SelectedCells[0].OwningRow.Cells["JournalMPMRowID"].Value.ToString() != "")
                {
                    MessageBox.Show("Data sudah dijurnal, Anda tidak diperbolehkan Mutasi data ini.");
                    return;
                }

                Guid RowIDHeader = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid RowID = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["PelRowID"].Value;
                double nominal = Double.Parse(GVDetail.SelectedCells[0].OwningRow.Cells["NIden"].Value.ToString());

                Kasir.frmMutasiIdenMPM ifrmChild2 = new Kasir.frmMutasiIdenMPM(RowIDHeader, RowID, nominal);
                ifrmChild2.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild2);
                ifrmChild2.Show();

                refreshDetail();

                

            }
        }

        private void cmdKoreksi_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                DateTime _tglPengeluaran = ((DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["Tanggal"].Value).AddDays(1).Date;

                if (_tglPengeluaran < DateTime.Now.Date)
                {
                    MessageBox.Show("Anda hanya diperbolehkan Koreksi Nominal data hari ini dan/atau kemarin");
                    return;
                }

                if (Double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["NominalSisa"].Value.ToString()) == 0)
                {
                    MessageBox.Show("Sisa Saldo 0");
                    return;
                }

                Guid RowID= (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                double nominal= Double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["NominalSisa"].Value.ToString());

                Keuangan.frmPenerimaanUangUpdate ifrmChild = new Keuangan.frmPenerimaanUangUpdate(this, RowID, nominal);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();              
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                if (GVHeader.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Detail");
                    return;
                }
                try
                {

                    DataTable dt = new DataTable();
                    dt = dtHeader.Copy();
                    dt.DefaultView.RowFilter = "RowID='" + GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";
                                      
                    List<DataTable> ListDT = new List<DataTable>();
                    ListDT.Add(dt.DefaultView.ToTable());
                    ListDT.Add(dtDetail);

                    List<string> ListDS = new List<string>();
                    ListDS.Add("dsPengeluaranUang_Data");
                    ListDS.Add("dsIdenMPM_Data");


                    string _userid = "Created by " + SecurityManager.UserID + " on " + DateTime.Now;

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", _userid));

                    frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptIdenMPM.rdlc", rptParams, ListDT, ListDS);
                    ifrmReport.Show();

                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }

        private void CMDPrintRekap_Click(object sender, EventArgs e)
        {
            try
            {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBFinanceOto))
                    {
                        db.Commands.Add(db.CreateCommand("rpt_idenMPM_rekap"));
                        db.Commands[0].Parameters.Add(new Parameter("@From", SqlDbType.DateTime, rgtglKlr.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@To", SqlDbType.DateTime, rgtglKlr.ToDate));
                        dt = db.Commands[0].ExecuteDataTable();  
                    }
                    if (dt.Rows.Count == 0)
                    {                       
                        MessageBox.Show("Tidak ada data...");                       
                    }
                    else
                    {
                        DisplayReport(dt);
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
        private void DisplayReport(DataTable dt)
        {
            string _userid = "Created by " + SecurityManager.UserID + " on " + DateTime.Now;
            _fromDate = (DateTime)rgtglKlr.FromDate;
            _toDate = (DateTime)rgtglKlr.ToDate;
            List<ReportParameter> rptParams = new List<ReportParameter>();
            
            rptParams.Add(new ReportParameter("fromdate", _fromDate.ToString()));
            rptParams.Add(new ReportParameter("todate", _toDate.ToString()));
            rptParams.Add(new ReportParameter("user", _userid));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.RptIdenMPMRekap.rdlc", rptParams, dt, "DsIdenMPMRekap_Data");
            ifrmReport.Show();


        }
    }
}
