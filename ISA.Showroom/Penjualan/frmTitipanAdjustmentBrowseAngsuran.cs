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
    public partial class frmTitipanAdjustmentBrowseAngsuran : ISA.Controls.BaseForm
    {
        Guid _CustomerRowID = Guid.Empty;

        public Guid _AngsRowID = Guid.Empty;
        public Guid _PenjRowID = Guid.Empty;
        public Guid _PenjHistRowID = Guid.Empty;
        public String _NoKwitansi = "";

        public frmTitipanAdjustmentBrowseAngsuran(Form Caller, Guid CustomerRowID)
        {
            InitializeComponent();
            this.Caller = Caller;
            _CustomerRowID = CustomerRowID;
        }

        private void frmTitipanAdjustmentBrowseAngsuran_Load(object sender, EventArgs e)
        {
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_Adjustment"));
                db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                dgAngsuran.DataSource = dummy;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            _NoKwitansi = String.Empty;
            _AngsRowID = Guid.Empty;
            _PenjRowID = Guid.Empty;
            _PenjHistRowID = Guid.Empty;

            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (dgAngsuran.SelectedCells.Count > 0)
            {
                _NoKwitansi = dgAngsuran.SelectedCells[0].OwningRow.Cells["NoTrans"].Value.ToString();
                _AngsRowID = new Guid(dgAngsuran.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _PenjRowID = new Guid(dgAngsuran.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _PenjHistRowID = new Guid(dgAngsuran.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());

                this.Close();
            }
        }
    }
}
