using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.HI
{
    public partial class frmHubunganIstimewaBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { dataGridHI, dataGridDetil }
        enumSelectedGrid _selectedGrid;

        #region Form Preparation
        public frmHubunganIstimewaBrowse()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rangeTanggal_Load(object sender, EventArgs e)
        {
            DateTime _today = GlobalVar.GetServerDate;
            rangeTanggal.ToDate = _today;
            rangeTanggal.FromDate = _today.AddDays(1 - _today.Day);
        }

        private void frmHubunganIstimewaBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        #endregion

        #region UDF
        public void RefreshData() {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    using (Database db = new Database())
            //    {
            //        DataTable dt = new DataTable();
            //        db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_FILTER_Tanggal"));
            //        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeTanggal.FromDate));
            //        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeTanggal.ToDate));
            //        dt = db.Commands[0].ExecuteDataTable();
            //        dataGridHI.DataSource = dt;
            dataGridHI.DataSource = GetHeaderData((DateTime)rangeTanggal.FromDate,(DateTime)rangeTanggal.ToDate);

                    if (dataGridHI.SelectedCells.Count > 0)
                    {
                        dataGridHI.Focus();
                        RefreshDataDetail();
                    }
                    else
                    {
                        dataGridDetil.DataSource = null;
                    }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Error.LogError(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        private DataTable GetHeaderData(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return dt;
        }

        private void RefreshDataDetail()  
        {
            if (dataGridHI.SelectedCells.Count > 0)
            {
                Guid headerRowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                dataGridDetil.DataSource = GetDetailData(headerRowID);
            }
        }

        private DataTable GetDetailData(Guid headerRowID)
        {
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, headerRowID));
                    dt = db.Commands[0].ExecuteDataTable();
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
            return dt;
        }

        private DataTable GetDetailData(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));
                    dt = db.Commands[0].ExecuteDataTable();
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
            return dt;
        }

        public void FindRowID(string columnName, string value)
        {
            dataGridHI.FindRow(columnName, value);
        }

        public void FindRowDetil(string columnName, string value)
        {
            dataGridDetil.FindRow(columnName, value);
        }

        #endregion

        #region Controls events
        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridHI.SelectedCells.Count > 0)
            {
                Guid _headerRowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                string _noBukti = dataGridHI.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                switch (_selectedGrid)
                {
                    case enumSelectedGrid.dataGridHI:
                        {
                            HI.frmHubunganIstimewaUpdate ifrmChild = new HI.frmHubunganIstimewaUpdate(this, _headerRowID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        break;
                    case enumSelectedGrid.dataGridDetil:
                        if (dataGridDetil.SelectedCells.Count > 0)
                        {
                            Guid _detailRowID = (Guid)dataGridDetil.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                            HI.frmHubunganIstimewaUpdateDetail ifrmChild = new HI.frmHubunganIstimewaUpdateDetail(this, _noBukti, _detailRowID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        break;
                }
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (_selectedGrid)
            {
                case enumSelectedGrid.dataGridHI:
                    {
                        HI.frmHubunganIstimewaUpdate ifrmChild = new HI.frmHubunganIstimewaUpdate(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.dataGridDetil:
                    {
                        if (dataGridHI.SelectedCells.Count > 0)
                        {
                            Guid _headerRowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                            string _noBukti = dataGridHI.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                            HI.frmHubunganIstimewaUpdateDetail ifrmChild = new HI.frmHubunganIstimewaUpdateDetail(this,_headerRowID,_noBukti);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                    }
                    break;
            }
        } 

        private void dataGridHI_Click(object sender, EventArgs e)
        {
            _selectedGrid = enumSelectedGrid.dataGridHI;
        }

        private void dataGridDetil_Click(object sender, EventArgs e)
        {
            _selectedGrid = enumSelectedGrid.dataGridDetil;
        }

        private void dataGridHI_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDataDetail();
        }

        #endregion

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dataGridHI.SelectedCells.Count > 0)
            {
                try {
                    List<DataTable> dt = new List<DataTable>();
                    List<string> ds = new List<string>();
                    ds.Add("dsHI_HubunganIstimewa");
                    ds.Add("dsHI_HubunganIstimewaDetail");
                    using (Database db = new Database()) {
                        Guid _rowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                        //db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST"));
                        //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        //dt.Add(db.Commands[0].ExecuteDataTable());
                        dt.Add(GetHeaderData((DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate));
                        dt.Add(GetDetailData((DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate));

                        //construct sender           
                        List<ReportParameter> rptParams = new List<ReportParameter>();
                        rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

                        //call report viewer
//                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI.rdlc", rptParams, dt, ds);
                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI.rdlc", rptParams, dt, ds);
                        ifrmReport.Show();
                    }
                } catch (Exception ex) {
                    Error.LogError(ex);
                }
            }
        }

    }
}
