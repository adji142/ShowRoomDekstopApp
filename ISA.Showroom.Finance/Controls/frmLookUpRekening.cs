using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Controls
{ 
    public partial class frmLookUpRekening : ISA.Controls.BaseForm
    {
        private DataRow _dr; 
        private string _sqlSearch;
        private String _txtSearch;
        private String _matauangID="";
        private Guid _PerusahaanRowID;

        [Browsable (true)]
        public string MUID
        {
            get { return _matauangID; }
            set { _matauangID = value; }
        }
        

        public frmLookUpRekening()  
        {
            InitializeComponent();
        }

        public DataRow GetResult()
        {
            return _dr;
        }

        public frmLookUpRekening(string sqlSearch)
        {
            InitializeComponent();
            _sqlSearch = sqlSearch;
        }

        public frmLookUpRekening(string sqlSearch, String MtUangID,Guid perusahaanRowID,String TextSearch)
        {
            InitializeComponent();
            _matauangID = MtUangID;
            _sqlSearch = sqlSearch;
            _PerusahaanRowID = perusahaanRowID;
            _txtSearch = TextSearch;
        }


        public frmLookUpRekening(string searchArg, DataTable dt, string sqlSearch)
        {
            InitializeComponent();
            txtSearch.Text = searchArg;
            dataGridView1.DataSource = dt;
            _sqlSearch = sqlSearch;
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ConfirmSelect();
                this.Close();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            //if (_matauangID.Equals(""))
            //{
                RefreshData2();
            //}
            //else
            //{
            //    RefreshData2();
            //}
            
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand(_sqlSearch));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        public void RefreshData2()
        {
         
           
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand(_sqlSearch));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, _matauangID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); //_PerusahaanRowID 
                    dt = db.Commands[0].ExecuteDataTable();
                    //dt.DefaultView.RowFilter = "MataUangID = '" + _matauangID + "'";
                    dataGridView1.DataSource = dt.DefaultView.ToTable();
                    if (dataGridView1.RowCount == 0)
                    {
                        //MessageBox.Show("Data " + _matauangID + " Kosong");
                    }      

                }
 
        }

        private void frmLookUpRekening_Load(object sender, EventArgs e)
        {
            //txtSearch.Focus();
            txtSearch.Text = _txtSearch;
            ////if (!string.IsNullOrEmpty(_txtSearch))
            if (!(txtSearch.Text.Equals(String.Empty)))
            {
                cmdSearch_Click(null, null);
            }
            if (dataGridView1.Rows.Count > 0) dataGridView1.Focus();
           
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
           
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                txtSearch.Text = dataGridView1.SelectedRows[0].Cells["NamaRekening"].Value.ToString();
                _dr = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {


            RefreshData2();
           
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    ConfirmSelect();
                }
                       
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count == 1)
                {
                    ConfirmSelect();
                }
            }
        }

    
 


    }
}
