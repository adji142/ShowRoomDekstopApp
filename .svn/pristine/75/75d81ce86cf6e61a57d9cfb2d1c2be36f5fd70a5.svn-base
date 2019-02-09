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
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;

namespace ISA.Showroom.Penjualan
{
    public partial class frmUMSubsidiBrowse : ISA.Controls.BaseForm
    {
        public frmUMSubsidiBrowse()
        {
            InitializeComponent();
        }

        private void frmUangMukaSubsidiBrowse_Load(object sender, EventArgs e)
        {
            rdtTanggal.FromDate = GlobalVar.GetServerDate.AddMonths(-1);
            rdtTanggal.ToDate = GlobalVar.GetServerDate;
            dgDetilPenerimaanSubsidi.AutoGenerateColumns = false;
            dgPenjualanBersubsidi.AutoGenerateColumns = false;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using(Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanBersubsidi_LIST_FILTER_TANGGAL"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rdtTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rdtTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dgPenjualanBersubsidi.DataSource = dt;
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (dgPenjualanBersubsidi.SelectedCells.Count > 0)
            {
                Guid PenjRowID = new Guid(Tools.isNull(dgPenjualanBersubsidi.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value.ToString(), Guid.Empty).ToString());
                Penjualan.frmUMSubsidiUpdate ifrmChild = new Penjualan.frmUMSubsidiUpdate(this, PenjRowID, "SBD");
                ifrmChild.ShowDialog();
                RefreshData();
                dgPenjualanBersubsidi.FindRow("PenjRowID", PenjRowID.ToString());
                RefreshDataDetail(PenjRowID);
            }
        }

        private void RefreshData()
        {
            DataTable dt = new DataTable();
            using(Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanBersubsidi_LIST_FILTER_TANGGAL"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rdtTanggal.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rdtTanggal.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dgPenjualanBersubsidi.DataSource = dt;
            }
        }

        private void RefreshDataDetail(Guid PenjRowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUMSubsidi_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dgDetilPenerimaanSubsidi.DataSource = dt;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPenjualanBersubsidi_SelectionChanged(object sender, EventArgs e)
        {
            cmdADD.Enabled = false;
            if(dgPenjualanBersubsidi.SelectedCells.Count > 0)
            {
                Guid PenjRowID = new Guid(Tools.isNull(dgPenjualanBersubsidi.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value.ToString(), Guid.Empty).ToString());
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUMSubsidi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgDetilPenerimaanSubsidi.DataSource = dt;
                }
                cmdADD.Enabled = true;
            }
        }

        private void dgDetilPenerimaanSubsidi_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
