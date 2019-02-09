using System;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Controls
{
    public partial class LookUpPerkiraan : UserControl
    {
        public event EventHandler SelectData;

        Guid _rowID;
        string _noPerkiraan;
        
        public Guid RowID
        {
            get { return _rowID; }
            set { _rowID = value; }
        }

        public string NoPerkiraan {
            get { return _noPerkiraan; }
            set
            {
                _noPerkiraan = value;
                this.txtLookUpSearch.Text = _noPerkiraan;
            }
        }

        public LookUpPerkiraan()
        {
            InitializeComponent();
        }

        private void txtLookUpSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) SEARCH(txtLookUpSearch.Text, false);
        }

        private DataTable SEARCH(string searchArg, bool _showDlg) { 
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtLookUpSearch.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtLookUpSearch.Text = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                        lblFound.Text = Tools.isNull(dt.Rows[0]["NamaPerkiraan"], "").ToString();
                    }
                    if ((dt.Rows.Count != 1) || (_showDlg)) ShowDialogForm(txtLookUpSearch.Text, dt);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return dt;
        }

        private void Clear()
        {
            _rowID = new Guid();
            txtLookUpSearch.Text = "";
            _noPerkiraan = "";
            lblFound.Text = "";
            if (this.SelectData != null) this.SelectData(this, new EventArgs());
        }

        private void ShowDialogForm()
        {
            frmPerkiraanLookUp ifrmDialog = new frmPerkiraanLookUp();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK) GetDialogResult(ifrmDialog);
        }


        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmPerkiraanLookUp ifrmDialog = new frmPerkiraanLookUp(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK) GetDialogResult(ifrmDialog); else Clear();
        }

        private void GetDialogResult(frmPerkiraanLookUp dialogForm)
        {
            _noPerkiraan = dialogForm.NomorPerkiraan;
            txtLookUpSearch.Text = dialogForm.NomorPerkiraan;
         
            lblFound.Text = dialogForm.Keterangan;
            if (this.SelectData != null) this.SelectData(this, new EventArgs());
        }

        private void cmdLookUp_Click(object sender, EventArgs e)
        {
            SEARCH(txtLookUpSearch.Text,true);
        }

        private void txtLookUpSearch_TextChanged(object sender, EventArgs e)
        {
            _noPerkiraan = txtLookUpSearch.Text;
        }

        private void txtLookUpSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtLookUpSearch.Text.Length <= 1)
            {
                lblFound.Text = "";
            }
           
        }
    }
}
