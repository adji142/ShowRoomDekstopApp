using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.DKN
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
        //int flag;
        #endregion


        #region Load data

        private DataTable LoadDataDKN11(String CabangID,Guid RowIDKelompokTrans,DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeTanggal.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeTanggal.ToDate));
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
            rangeTanggal.ToDate = _today;
            rangeTanggal.FromDate = _today.AddDays(1 - _today.Day);
        }
        #endregion

        

        private void frmHI11_Load(object sender, EventArgs e)
        {
            RangeTanggal();
            dgvCabang.DataSource = LoadDataCabang();
            if (dgvCabang.Rows.Count > 0)
            {
                dgvDataH11.DataSource = LoadDataDKN11(String.Empty,Guid.Empty ,(DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate);
            }
            
            dgvKelompokTransaksiHI.DataSource = LoadDataKelompokTransaksiHI();
        }

        private void dgvCabang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex > -1)
            {
                CabID = (String)dgvCabang.SelectedCells[0].OwningRow.Cells["CabangID"].Value;
                dgvDataH11.DataSource = LoadDataDKN11(CabID,Guid.Empty,(DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate);
                grpSemuaData.Text = "Data HI Cabang " + CabID;
                KelRowid = Guid.Empty;
            }
        }

        private void dgvKelompokTransaksiHI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex > -1)
            {
                KelRowid = (Guid)this.dgvKelompokTransaksiHI.SelectedCells[0].OwningRow.Cells["RowIDKel"].Value;
                String Nama=(String)this.dgvKelompokTransaksiHI.SelectedCells[0].OwningRow.Cells["keterangan"].Value;
                dgvDataH11.DataSource = LoadDataDKN11(CabID, KelRowid, (DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate);
                grpSemuaData.Text = "Data HI Cabang [" + CabID +"] , Kelompok Transaksi HI: "+ Nama;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            
            dgvDataH11.DataSource = LoadDataDKN11(String.Empty, Guid.Empty, (DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate);
            grpSemuaData.Text = "Semua Data HI11";
            CabID = string.Empty;
            KelRowid = Guid.Empty;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dgvDataH11.Rows.Count > 0)
            {
                
                //try
                //{
                    //this.Cursor = Cursors.WaitCursor;
                    List<DataTable> dt=new List<DataTable>();
                    List<String>ds=new List<String>();
                    ds.Add("dsHI11_HubunganIstimewa");
                    ds.Add("dsHI11_HubunganIstimewaDetail");
                    ds.Add("dsHI11_KelompokTransaksiHI");
                    dt.Add(LoadDataDKN11(CabID,KelRowid,(DateTime)rangeTanggal.FromDate,(DateTime)rangeTanggal.ToDate));
                    
                    List<ReportParameter> rptParam = new List<ReportParameter>();
                    //rptParam.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptHI11.rdlc", rptParam, dt, ds);
                    ifrmReport.Show();
                //}

                //catch (Exception Ex) { Error.LogError(Ex); }
                //finally { this.Cursor = Cursors.Default; }
            }
        }


      

    }
}
