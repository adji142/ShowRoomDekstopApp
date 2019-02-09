using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmJournalPreview : ISA.Controls.BaseForm
    {
        private DataTable dtaHeader; 
        private DataTable dtaDetail;

        private string scurrentfilter = "";

        public frmJournalPreview()
        {
            InitializeComponent();
        }

        public frmJournalPreview(Form Caller, DataTable dtHeader, DataTable dtDetail)
        {
            InitializeComponent();
            this.Caller = Caller;
            dgHeader.AutoGenerateColumns = false;
            dgDetail.AutoGenerateColumns = false;
            dgHeader.Columns["RowIDHeader"].Visible = false;
            dgHeader.Columns["RecordIDHeader"].Visible = false;
           
            dgDetail.Columns["RowIDDetail"].Visible = false;
            dgDetail.Columns["HeaderIDDetail"].Visible = false;
            dgDetail.Columns["RecordIDDetail"].Visible = false;
            dgDetail.Columns["HRecordIDDetail"].Visible = false;

            dtaHeader = dtHeader;
            dtaDetail = dtDetail;
            var dtvHeader = dtaHeader.DefaultView;
            var dtvDetail = dtaDetail.DefaultView;
            dtaHeader.DefaultView.RowFilter = "Owner='ALL'";


            //setting setiap header jurnal
            string hid;
            double sumD=0;
            double sumK=0;
            Guid newGuid;

            foreach (DataRow dr in dtHeader.Rows)
            {
                hid = dr["RowID"].ToString();
                newGuid = (Guid)dr["RowID"];
                sumD = dtDetail.AsEnumerable().Where(x => x.Field<Guid>("HeaderID") == newGuid).Sum(r => r.Field<double?>("Debet")) ?? 0;
                sumK = dtDetail.AsEnumerable().Where(x => x.Field<Guid>("HeaderID") == newGuid).Sum(r => r.Field<double?>("Kredit")) ?? 0;
                dr["Debet"] = sumD;
                dr["Kredit"] = sumK;
            }


            dgHeader.DataSource = dtvHeader;//.DefaultView;
            dgDetail.DataSource = dtaDetail;//.DefaultView;
        }

        private void frmJournalPreview_Load(object sender, EventArgs e)
        {
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dgHeader.SelectedCells.Count > 0)
            {
                string sparam;
                if (scurrentfilter == "")
                    sparam = "";
                else
                    sparam = " AND " + scurrentfilter;

                Guid HRowID = new Guid(Tools.isNull(dgHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value, Guid.Empty).ToString());
                (dgDetail.DataSource as DataTable).DefaultView.RowFilter = string.Format("HeaderID = '{0}'", HRowID.ToString());                   

                dgHeader.Columns["RowIDHeader"].Visible = false;
                dgHeader.Columns["RecordIDHeader"].Visible = false;
                dgDetail.Columns["RowIDDetail"].Visible = false;
                dgDetail.Columns["HeaderIDDetail"].Visible = false;
                dgDetail.Columns["RecordIDDetail"].Visible = false;
                dgDetail.Columns["HRecordIDDetail"].Visible = false;
            }
            else
            {
                (dgDetail.DataSource as DataTable).DefaultView.RowFilter = "HeaderID = 'KOSONG'";
            }
        }

        private void dgHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgHeader.Rows[e.RowIndex].Cells["DebetHeader"].Value.ToString() != dgHeader.Rows[e.RowIndex].Cells["KreditHeader"].Value.ToString())
            {
                dgHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
            }
        }

        private void rdoTrading_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo.Checked)
            {
                if (sender == rdoAll)
                {
                    scurrentfilter = "Owner='ALL'";
                }
                if (sender == rdoTrading)
                {
                    scurrentfilter = "Owner='TRD'";
                }
                if (sender == rdoAvalis)
                {
                    scurrentfilter = "Owner='AVL'";
                }
                if (sender == rdoAhass)
                {
                    scurrentfilter = "Owner='AHS'";
                }
                dtaHeader.DefaultView.RowFilter = scurrentfilter;
            }

        }
    }
}
