using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.HI
{
    public partial class frmHI11 : BaseForm
    { 
        public frmHI11()
        {
            InitializeComponent();
        }

        #region variables

        String CabID = string.Empty;
        Guid KelRowid = Guid.Empty;
        String NamaKel=String.Empty;
        #endregion


        #region Load data

        private DataTable LoadDataDKN11(String CabangID, Guid RowIDKelompokTrans, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    if (!(RowIDKelompokTrans.Equals(Guid.Empty)))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksi", SqlDbType.UniqueIdentifier, RowIDKelompokTrans));
                    }
                    if (!(CabangID.Equals(String.Empty)))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                    }

                    dt = db.Commands[0].ExecuteDataTable();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        private DataTable LoadDataPengeluaran11(String CabangID, Guid RowIDKelompokTrans, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang11_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                   
                    if (!(CabangID.Equals(String.Empty)))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                    }

                    dt = db.Commands[0].ExecuteDataTable();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        private DataTable LoadDataPenerimaan11(String CabangID, Guid RowIDKelompokTrans, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang11_LIST_FILTER_TANGGAL"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                 
                    if (!(CabangID.Equals(String.Empty)))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                    }

                    dt = db.Commands[0].ExecuteDataTable();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        private void LoadDataSelectedBy()
        {
            switch (TabControlDKN.SelectedIndex)
            {
                case 0:
                    {
                        dgvHI11.DataSource = LoadDataDKN11(String.Empty, Guid.Empty, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                        lblInfo.Text = "Semua Data HI 11";
                        CabID = string.Empty;
                        KelRowid = Guid.Empty;
                        dgvKelTrans.Enabled = true;
                        cmdPRINT_Multy.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        dgvPengeluaran.DataSource = LoadDataPengeluaran11(String.Empty, Guid.Empty, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                        lblInfo.Text = "Semua Data pengeluaran";
                        CabID = string.Empty;
                        KelRowid = Guid.Empty;
                        dgvKelTrans.Enabled = false;
                        cmdPRINT_Multy.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        dgvPenerimaan.DataSource = LoadDataPenerimaan11(String.Empty, Guid.Empty, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                        lblInfo.Text = "Semua Data Penerimaan";
                        CabID = string.Empty;
                        KelRowid = Guid.Empty;
                        dgvKelTrans.Enabled = false;
                        cmdPRINT_Multy.Enabled = true;
                        break;
                    }
            }
        }

        private DataTable LoadDataCabang()
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception Ex)
            { Error.LogError(Ex); }
            finally { this.Cursor = Cursors.Default; }
            return dt;
        }

        private DataTable LoadDataKelompokTransaksiHI()
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KelompokTransaksiHI_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception Ex)
            { Error.LogError(Ex); }
            finally { this.Cursor = Cursors.Default; }
            return dt;
        }


        private void RangeTanggal()
        {
            DateTime _today = GlobalVar.GetServerDate;
            rangeDateBox1.ToDate = _today;
            rangeDateBox1.FromDate = _today.AddDays(1 - _today.Day);
        }
        #endregion

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            LoadDataSelectedBy();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmHI11_Load(object sender, EventArgs e)
        {
            TabControlDKN.SelectedIndex = 0;
            RangeTanggal();
            dgvCabang.DataSource = LoadDataCabang();
            if (dgvCabang.Rows.Count > 0)
            {
                LoadDataSelectedBy();
            }

            dgvKelTrans.DataSource = LoadDataKelompokTransaksiHI();
        }


        private void LoadDataSelectedByCabang()
        {
            if (dgvCabang.SelectedCells.Count>0)
            {
                CabID = (String)dgvCabang.SelectedCells[0].OwningRow.Cells["CabangID"].Value;
                switch (TabControlDKN.SelectedIndex)
                {
                    case 0:
                        {
                            dgvHI11.DataSource = LoadDataDKN11(CabID, Guid.Empty, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                            lblInfo.Text = "Data HI Cabang " + CabID;
                            break;
                        }
                    case 1:
                        {
                            dgvPengeluaran.DataSource = LoadDataPengeluaran11(CabID, Guid.Empty, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                            lblInfo.Text = "Data pengeluaran Cabang " + CabID;
                            break;
                        }
                    case 2:
                        {
                            dgvPenerimaan.DataSource = LoadDataPenerimaan11(CabID, Guid.Empty, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                            lblInfo.Text = "Data penerimaan Cabang " + CabID;
                            break;
                        }
                }
                
                KelRowid = Guid.Empty;
            }
        }

        private void LoadDataSelectedBykelompokTransaksi()
        {
            if (dgvKelTrans.SelectedCells.Count>0)
            {

                String CabangID = string.Empty;
                KelRowid = (Guid)this.dgvKelTrans.SelectedCells[0].OwningRow.Cells["RowIDKel"].Value;
                NamaKel = (String)this.dgvKelTrans.SelectedCells[0].OwningRow.Cells["keterangan"].Value;

                if (CabID.Equals(string.Empty))
                {
                    CabangID = "Semua Cabang";
                }
                else
                {
                    CabangID = CabID;
                }

                switch (TabControlDKN.SelectedIndex)
                {
                    case 0:
                        {
                            dgvHI11.DataSource = LoadDataDKN11(CabID,KelRowid, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                            lblInfo.Text = "Data HI Cabang [" + CabangID + "] , Kelompok Transaksi HI: " + NamaKel;
                            break;
                        }
                  
                }

            }
        }
    

        private void dgvCabang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataSelectedByCabang();
           
        }

        private void dgvKelTrans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataSelectedBykelompokTransaksi();
           
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DateTime _TglDari = (DateTime)rangeDateBox1.FromDate;
            DateTime _TglSampai = (DateTime)rangeDateBox1.ToDate;
            String Title=String.Empty;
            List<ReportParameter> rptParam = new List<ReportParameter>();
            rptParam.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParam.Add(new ReportParameter("FromDate", _TglDari.ToString()));
            rptParam.Add(new ReportParameter("ToDate", _TglSampai.ToString()));
            

            if (!(CabID.Equals(String.Empty)))
            {
                rptParam.Add(new ReportParameter("CabangID", CabID));
            }
            else
            {
                rptParam.Add(new ReportParameter("CabangID", "Semua"));
            }
            if (!(KelRowid.Equals(Guid.Empty)))
            {
                rptParam.Add(new ReportParameter("KelompokTransaksi", NamaKel));
            }
            else
            {
                rptParam.Add(new ReportParameter("KelompokTransaksi", "Semua"));
            }

            switch (TabControlDKN.SelectedIndex)
            {
                case 0:
                    {
                       
                        if (dgvHI11.Rows.Count > 0)
                        {
                            rptParam.Add(new ReportParameter("Title", "LAPORAN DATA HI11"));
                            frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptHI11.rdlc", rptParam, dgvHI11.DataSource as DataTable, "dsHI11_HI11");
                            ifrmReport.Show();

                        }
                        else
                        {
                            MessageBox.Show("Maaf, tidak bisa di lakukan Cetak laporan, karena data kosong.");
                            return;
                        }
                        break;
                    }
                case 1:
                    {

                        rptParam.Add(new ReportParameter("Title", "LAPORAN DATA PENGELUARAN 11"));
                        if (dgvPengeluaran.Rows.Count > 0)
                        {

                            frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptHI11.rdlc", rptParam, dgvPengeluaran.DataSource as DataTable, "dsHI11_HI11");
                            ifrmReport.Show();

                        }
                        else
                        {
                            MessageBox.Show("Maaf, tidak bisa di lakukan Cetak laporan, karena data kosong.");
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        
                        rptParam.Add(new ReportParameter("Title", "LAPORAN DATA PENERIMAAN 11"));
                        if (dgvPenerimaan.Rows.Count > 0)
                        {

                            frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptHI11.rdlc", rptParam, dgvPenerimaan.DataSource as DataTable, "dsHI11_HI11");
                            ifrmReport.Show();

                        }
                        else
                        {
                            MessageBox.Show("Maaf, tidak bisa di lakukan Cetak laporan, karena data kosong.");
                            return;
                        }
                        break;
                    }
            }

           


        }

        private void dgvCabang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataSelectedByCabang();
        }

        private void dgvKelTrans_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataSelectedBykelompokTransaksi();
        }

        private void TabControlDKN_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataSelectedBy();
        }

        private void cmdPRINT_Multy_Click(object sender, EventArgs e)
        {
            int InOut = TabControlDKN.SelectedIndex;
            DateTime _FromDate = rangeDateBox1.FromDate.Value;
            DateTime _ToDate = rangeDateBox1.ToDate.Value;
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_HI_MultiSheet"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].Parameters.Add(new Parameter("@InOut", SqlDbType.Int, InOut));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI_Multy.rdlc", rptParams, dt, "dsHI_DKN");
                ifrmReport.Show();
            }

        }

      
    }
}
