using System;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Controls
{
    public partial class frmPerkiraanLookUp : ISA.Controls.BaseForm
    {
        private string _noPerkiraan;
        private string _namaPerkiraan;
        private DataRow _dr;

        public frmPerkiraanLookUp()
        {
            InitializeComponent();
        }

        public DataRow Baris
        {
            get { return _dr; }
        }

        public string NomorPerkiraan
        {
            get { return _noPerkiraan; }
        }

        public string Keterangan
        {
            get { return _namaPerkiraan; }
        }

        public frmPerkiraanLookUp(string searchArg, DataTable dt) 
        {
            InitializeComponent();
            txtSearch.Text = searchArg;
            dataGridView1.DataSource = dt;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
            if (txtSearch.Text.Length == 0)
            {
                _noPerkiraan = "";
                _namaPerkiraan = "";
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtSearch.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        _noPerkiraan = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                        _namaPerkiraan = Tools.isNull(dt.Rows[0]["NamaPerkiraan"], "").ToString();
                        this.txtSearch.Text = _noPerkiraan;
                        dataGridView1.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void LoadDataSearch()
        {
            try
            {
                
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtSearch.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                   
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void frmPerkiraanLookUp_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) dataGridView1.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) cmdSearch.PerformClick();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1) ConfirmSelect();
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
//                _noPerkiraan = dataGridView1.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                _dr = ((DataRowView)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].DataBoundItem).Row;
                _noPerkiraan = _dr["NoPerkiraan"].ToString();
                _namaPerkiraan = _dr["NamaPerkiraan"].ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count > 0) ConfirmSelect();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1) ConfirmSelect();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDataSearch();
        }

    }
}
