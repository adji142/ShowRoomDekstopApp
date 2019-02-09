using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmJournalList : ISA.Controls.BaseForm
    {
        DataTable dtH;
        DataTemplates.dsJurnal  ds;
        public frmJournalList()
        {
            InitializeComponent();
        }

        public frmJournalList(DataTemplates.dsJurnal dsJournal)
        {
            InitializeComponent();
            ds = dsJournal;
            dtH = (DataTable)dsJournal.Journal;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJournalList_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Journal";

            dataGridView2.AutoGenerateColumns = false;
            ds.JournalDetail.DefaultView.Sort = "DK";
            dataGridView2.DataSource = ds.JournalDetail.DefaultView;
            //label1.Text = ((ds.Journal.
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void RefreshDetail()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid _hRowID = (Guid)Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value, Guid.Empty);
                ds.JournalDetail.DefaultView.RowFilter = string.Format("HeaderID = '{0}'", _hRowID);

            }
        }
    }
}
