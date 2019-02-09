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
    public partial class frmDKNBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { dataGridHI, dataGridDetil }
        enumSelectedGrid _selectedGrid;

        public DataTable _dt;
        protected bool _editable=false;

        #region Form Preparation
        public frmDKNBrowse()
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
            PembebananCabangLupaInput();
        }

        private void PembebananCabangLupaInput()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PembebananCabang_LIST_LupaInput"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                DKN.frmPembebananCabang_LupaInput ifrm = new ISA.Showroom.Finance.DKN.frmPembebananCabang_LupaInput();
                ifrm.dgBebanCabang.AutoGenerateColumns = false;
                ifrm.dgBebanCabang.DataSource = dt;
                ifrm.Show();
            }
        }
        #endregion

        #region UDF
        public void RefreshData() {
            
        _dt= Class.clsDKN.DBGetListByDate(rangeTanggal.FromDate, rangeTanggal.ToDate, GlobalVar.PerusahaanRowID);
        //_dt = Class.clsDKN.DBGetListByDateUnion(rangeTanggal.FromDate, rangeTanggal.ToDate, GlobalVar.PerusahaanRowID);
            dataGridHI.DataSource = _dt.DefaultView;
            //GetHeaderData((DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate);
            if (dataGridHI.SelectedCells.Count > 0)
            {
                dataGridHI.Focus();
                RefreshDataDetail();
            } else {
                dataGridDetil.DataSource = null;
            }
            dataGridHI.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //private DataTable GetHeaderData(DateTime fromDate, DateTime toDate)
        //{
        //    return Class.clsDKN.DBGetListByDate(rangeTanggal.FromDate, rangeTanggal.ToDate, GlobalVar.PerusahaanRowID);
        //}

        public void RefreshDataDetail()  
        {
            if (dataGridHI.SelectedCells.Count > 0)
            {
                Guid headerRowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                dataGridDetil.DataSource = Class.clsDKNDetail.DBGetListByHeaderID(headerRowID); //GetDetailData(headerRowID);
            }
        }

        //private DataTable GetDetailData(Guid headerRowID)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        using (Database db = new Database())
        //        {
        //            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_LIST_FILTER_HeaderID"));
        //            db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, headerRowID));
        //            dt = db.Commands[0].ExecuteDataTable();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //    return dt;
        //}

        //private DataTable GetDetailData(DateTime fromDate, DateTime toDate)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        using (Database db = new Database())
        //        {
        //            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_LIST_FILTER_Tanggal"));
        //            db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate));
        //            db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate));
        //            dt = db.Commands[0].ExecuteDataTable();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //    return dt;
        //}

        public void FindRowID(string columnName, string value)
        {
            dataGridHI.FindRow(columnName, value);
        }

        public void FindRowDetil(string columnName, string value)
        {
            dataGridDetil.FindRow(columnName, value);
        }

        private void JournalPreview()
        {
        }

        #endregion

        #region Controls events
        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            String src = (String)this.dataGridHI.SelectedCells[0].OwningRow.Cells["Src"].Value;
            //if (!src.Equals("INP"))
            //{
            //    MessageBox.Show("Maaf, data ini tidak bisa diedit.");
            //    return;
            //}

            //if (ValidasiManipulasi() == true)
            //{
            //    MessageBox.Show("Maaf, proses Edit data sudah tidak bisa dilakukan," + Environment.NewLine + "karena sudah di luar dari batas waktu yang ditentukan.");
            //    return;
            //}
            //else if ((Guid)Tools.isNull(this.dataGridHI.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value,Guid.Empty)!=Guid.Empty)
            //            {
            //                MessageBox.Show("Maaf, data ini tidak bisa diedit karena sudah masuk jurnal.");
            //                return;
            //            }
            //else
            //{
            _editable = ValidasiManipulasi();
                if (dataGridHI.SelectedCells.Count > 0)
                {
                    Guid _headerRowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                    string _noBukti = dataGridHI.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                    switch (_selectedGrid)
                    {
                        case enumSelectedGrid.dataGridHI:
                            {
                                HI.frmDKNUpdate ifrmChild = new HI.frmDKNUpdate(this, _headerRowID, _editable);
                                ifrmChild.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild);
                                ifrmChild.Show();
                            }
                            break;
                        case enumSelectedGrid.dataGridDetil:
                            if (dataGridDetil.SelectedCells.Count > 0)
                            {
                                Guid _detailRowID = (Guid)dataGridDetil.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                                HI.frmDKNUpdateDetail ifrmChild = new HI.frmDKNUpdateDetail(this, _noBukti, _detailRowID, _editable);
                                ifrmChild.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild);
                                ifrmChild.Show();
                            }
                            break;
                    }
                }
            //}
         }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (_selectedGrid)
            {
                case enumSelectedGrid.dataGridHI:
                    {
                        HI.frmDKNUpdate ifrmChild = new HI.frmDKNUpdate(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.dataGridDetil:
                    {
                        if (dataGridHI.SelectedCells.Count > 0) 
                        {
                            if (ValidasiManipulasi() == true)
                            {
                            //    MessageBox.Show("Tidak dapat menambah item data," + Environment.NewLine + "karena sudah di luar dari batas waktu yang ditentukan.");
                            //    return;
                            //}
                            //else if ((Guid)Tools.isNull(this.dataGridHI.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value, Guid.Empty) != Guid.Empty)
                            //{
                            //    MessageBox.Show("Tidak dapat menambah item data, karena sudah masuk jurnal.");
                            //    return;
                            //}
                            //else
                            //{
                                Guid _headerRowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                                string _noBukti = dataGridHI.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
                                HI.frmDKNUpdateDetail ifrmChild = new HI.frmDKNUpdateDetail(this, _headerRowID, _noBukti);
                                ifrmChild.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmChild);
                                ifrmChild.Show();
                            }
                        }
                    }
                    break;
            }
        }

        #region Parameter Lock


        //private List<int> ParameterKuncian()
        //{
        //    List<int> _parameterkuncian = new List<int>();
        //    using (Database db = new Database())
        //    {
        //        DataTable dt = new DataTable();
        //        db.Commands.Add(db.CreateCommand("usp_Lock"));
        //        dt = db.Commands[0].ExecuteDataTable();
        //        _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);
        //        _parameterkuncian.Add((int)dt.Rows[0]["PostdatedLock"]);

        //    }
        //    return _parameterkuncian;
        //}

        private bool ValidasiManipulasi()
        {
            //DateTime Tanggal = (DateTime)this.dataGridHI.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;
            //bool Expired = false;
            //List<int> parameter = ParameterKuncian();
            //if (Tanggal <= DateTime.Now.AddDays(-parameter[0]) || Tanggal >= DateTime.Now.AddDays(+parameter[1]))
            //{ Expired = true; }
            //return Expired;
            bool result = false;
            if (dataGridHI.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)Tools.isNull(dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value, Guid.Empty);
                if (rowID != Guid.Empty)
                {
                    Class.clsDKN _dkn = new Class.clsDKN(rowID);
                    string s = _dkn.ValidasiManipulasi();
                    result = (s == "Ok");
                    if (!result) MessageBox.Show(s);
                }
                else MessageBox.Show("Data tidak ditemukan");
            }
            else MessageBox.Show("Tidak ada data yang dipilih..");
            //return (Tanggal < GlobalVar.GetBackDatedLockValue());
            return result;
        }


        #endregion

        private void delete_data()
        {
            switch (_selectedGrid)
            {
                case enumSelectedGrid.dataGridHI:
                    {
                        Guid RowIDHIHeader = (Guid)this.dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;

                        if ((Guid)Tools.isNull(this.dataGridHI.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value,Guid.Empty)!=Guid.Empty)
                        {
                            MessageBox.Show("Maaf, data ini tidak bisa dihapus karena sudah masuk jurnal.");
                            return;
                        }
                        
                        DataTable dt= new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDHIHeader));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show(Messages.Confirm.DeleteSuccess);
                        RefreshData();
                        break;
                    }
                case enumSelectedGrid.dataGridDetil:
                    {
                        if (dataGridDetil.SelectedCells.Count > 0)
                        {
                            Guid rowID = (Guid)Tools.isNull(dataGridDetil.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value, Guid.Empty);
                            Class.clsDKNDetail _d = new Class.clsDKNDetail(rowID);
                            _d.Delete();
                            RefreshDataDetail();
                        }
                    } break;
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
                    //using (Database db = new Database()) {
                        Guid _rowID = (Guid)dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                        //db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST"));
                        //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        //dt.Add(db.Commands[0].ExecuteDataTable());
                        //dt.Add(GetHeaderData((DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate));
                        //dt.Add(GetDetailData((DateTime)rangeTanggal.FromDate, (DateTime)rangeTanggal.ToDate));
                        dt.Add(Class.clsDKN.DBGetDKN(_rowID));
                        dt.Add(Class.clsDKNDetail.DBGetListByHeaderID(_rowID));

                    //construct sender           
                        List<ReportParameter> rptParams = new List<ReportParameter>();
                        rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

                        //call report viewer
//                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI.rdlc", rptParams, dt, ds);
                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI.rdlc", rptParams, dt, ds);
                        ifrmReport.Show();
                    //}
                } catch (Exception ex) {
                    Error.LogError(ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rangeTanggal_Validated(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (ValidasiManipulasi() == true)
            {
            //    MessageBox.Show("Maaf, proses delete sudah tidak bisa dilakukan," + Environment.NewLine + "karena sudah di luar dari batas waktu yang ditentukan.");
            //    return;
            //}
            //else
            //{
                delete_data();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            DataTemplates.dsJurnal dsJ = new DataTemplates.dsJurnal();
            if (dataGridHI.SelectedRows.Count > 0)
            {
                Class.clsDKN _dkn;
                DataTemplates.dsJurnal dsj = new DataTemplates.dsJurnal();
                DataGridViewRow dgr = dataGridHI.SelectedRows[0];
                //foreach (DataGridViewRow dgr in dataGridHI.SelectedRows)
                //{
                Guid rowID = (Guid)Tools.isNull(dgr.Cells["RowIDHeader"].Value, Guid.Empty);
                _dkn = new Class.clsDKN(rowID);
                if (_dkn.State == Class.clsDKN.enumState.Empty) errMsg = "Data tidak dapat ditemukan";
                else
                {
                    _dkn.DSJournal(dsj);
                    if (_dkn.ErrorNo != 0)
                    {
                        errMsg = _dkn.ErrorMsg;
                        //break;
                    }
                }
                //}
                if (errMsg == "")
                {
                    GL.frmJournalList fChild = new GL.frmJournalList(dsj);
                    //fChild.MdiParent = Program.MainForm;
                    fChild.ShowDialog();
                    //DataRow dr = dsj.Tables["Journal"].Rows.Add();
                    //dr["RowID"] = rowID;
                }
                else MessageBox.Show(errMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cmdPRINT_Multy_Click(object sender, EventArgs e)
        {
            if (dataGridHI.SelectedCells.Count > 0)
            {
                DKN.frmDknMultiSheet frmChild = new DKN.frmDknMultiSheet(rangeTanggal.FromDate.Value,rangeTanggal.ToDate.Value);
                frmChild.Show();
            }

        }

    }
}
