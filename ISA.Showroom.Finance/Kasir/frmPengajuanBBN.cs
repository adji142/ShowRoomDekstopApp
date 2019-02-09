using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmPengajuanBBN : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable _DataDetail;

        public frmPengajuanBBN()
        {
            InitializeComponent();
        }

        private void frmPengajuanBBN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader(Guid.Empty);
        }

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail(Guid.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    {
                        Kasir.frmPengajuanBBNHeader ifrmChild = new Kasir.frmPengajuanBBNHeader(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    };
                    break;
                case enumSelectedGrid.DetailSelected:
                    {
                        if (GVHeader.Rows.Count == 0)
                        {
                            return;
                        }
                        Guid _rowID = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        DateTime _tgl = (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;

                        if (_tgl.Date < GlobalVar.DateOfServer.Date)
                        {
                            MessageBox.Show("Sudah Lewat Periode");
                            return;
                        }
                        Kasir.frmIdenPelunasanBBN ifrmChild2 = new Kasir.frmIdenPelunasanBBN(this, _rowID);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
                    }
                    break;
                default: break;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count == 0)
            {
                return;
            }

            if (GVDetail.Rows.Count == 0)
            {
                return;
            }

            DateTime _tgl = (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;

            if (_tgl.Date < GlobalVar.DateOfServer.Date)
            {
                MessageBox.Show("Sudah Lewat Periode");
                return;
            }

            if (MessageBox.Show("Yakin Data akan dihapus..", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN_ListDetail"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier, (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    _DataDetail = dt;
                    GVDetail.DataSource = dt;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshHeader(Guid RowID)
        {
            try
            {
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN_ListHeader"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                GVHeader.DataSource = dtHeader;

                if (dtHeader.Rows.Count > 0)
                {
                    if (RowID != Guid.Empty)
                    {
                        GVHeader.FindRow("RowID", RowID.ToString());
                    }
                }
                else
                {
                    GVDetail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDetail(Guid RowIDD)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN_ListDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _DataDetail = dt;
                GVDetail.DataSource = dt;

                if (dt.Rows.Count > 0 && RowIDD != Guid.Empty)
                {
                    GVDetail.FindRow("RowID_PU", RowIDD.ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GVHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void GVDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count == 0)
            {
                return;
            }

            if (GVDetail.Rows.Count == 0)
            {
                return;
            }
            int _tgl = (Int32)GVHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value;

            if (_tgl > 0)
            {
                MessageBox.Show("Data Pengajuan sudah di Print");
                return;
            }
            try
            {
                string _created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.GetServerDate;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NoBukti", GVHeader.SelectedCells[0].OwningRow.Cells["NoBukti_PU"].Value.ToString()));
                rptParams.Add(new ReportParameter("Tanggal", ((DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["Tanggal"].Value).ToString("dd/MM/yyyy")));
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Created", _created));
                frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptPengajuanBBN.rdlc", rptParams, _DataDetail, "dsPengajuanBBN_Data");
                ifrmReport.Show();

                Guid _rowID = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                RefreshHeader(_rowID);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
