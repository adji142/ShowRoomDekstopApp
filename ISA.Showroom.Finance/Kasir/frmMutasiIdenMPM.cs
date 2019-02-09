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

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmMutasiIdenMPM : ISA.Controls.BaseForm
    {

        DateTime _fromDate, _toDate;

        Guid _headerRowID, _detailRowID;
        double _nominalIden;
        
        public frmMutasiIdenMPM()
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(-1 * (_toDate.Day - 1));
            rgtglKlr.ToDate = _toDate;
            rgtglKlr.FromDate = _fromDate;
        }

        public frmMutasiIdenMPM(Guid _header, Guid _detail, double _nominal)
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(-1 * (_toDate.Day - 1));
            rgtglKlr.ToDate = _toDate;
            rgtglKlr.FromDate = _fromDate;
            _headerRowID = _header;
            _detailRowID = _detail;
            _nominalIden = _nominal;
        }

        private void frmMutasiIdenMPM_Load(object sender, EventArgs e)
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                Guid _rowID = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                if (_headerRowID == _rowID)
                {
                    MessageBox.Show("Mutasi tidak dapat dilakukan ke data yang sama");
                    return;
                }

                if (Double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["NominalSisa"].Value.ToString()) < _nominalIden)
                {
                    MessageBox.Show("Nominal Sisa tidak mencukupi");
                    return;
                }

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_IdenPembayaranMPM_mutasi"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerRowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _detailRowID));
                    db.Commands[0].ExecuteNonQuery();
                }

                this.Close();

            }

        }
    }
}
