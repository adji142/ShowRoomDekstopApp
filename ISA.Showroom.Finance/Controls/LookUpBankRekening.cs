using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Showroom.Finance.Controls
{
    public partial class LookUpBankRekening : UserControl
    {
        public LookUpBankRekening()  
        {
            InitializeComponent(); 
        }

        public event EventHandler SelectData;
        Guid _rowID;
        public enum enumFilterPT { All, PTLoginOnly, AllExceptPTLogin }
        enumFilterPT _filterPT = enumFilterPT.All;
        int MaxLength;

        #region properties

        public Guid RowID { get { return _rowID; } set { _rowID = value; } }

        public string BankID { get { return txtLookup.Text; } set { txtLookup.Text = value; } }

        public string NamaBank { get { return lblLookupNamaBank.Text; } set { lblLookupNamaBank.Text = value; } }

        public string NoRekening { get { return lblNoRekening.Text; } set { lblNoRekening.Text = value; } }

        public string Namarekening { get { return lblNamaRekening.Text; } set { lblNamaRekening.Text = value; } }

        [BrowsableAttribute(true),Description("Filter PT pemilik rekening")]
        public enumFilterPT FilterPT { get { return _filterPT; } set { _filterPT = value; } }

        #endregion

        private void ShowDialogForm()
        {
            frmLookupBankRekening ifrmDialog = new frmLookupBankRekening();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmLookupBankRekening ifrmDialog = new frmLookupBankRekening(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK) GetDialogResult(ifrmDialog);
            else Clear();
        }

        private void GetDialogResult(frmLookupBankRekening dialogForm)
        {
            txtLookup.Text = dialogForm.BankID;
            MaxLength = dialogForm.BankID.Length;
            lblLookupNamaBank.Text = dialogForm.NamaBank;
            lblNoRekening.Text = dialogForm.No_Rekening;
            lblNamaRekening.Text = dialogForm.Nama_rekening;
            _rowID = dialogForm.RowID;

            if (this.SelectData != null) this.SelectData(this, new EventArgs());
        }

        public void Clear()
        {
            txtLookup.Text = "";
            lblLookupNamaBank.Text = "";
            lblNoRekening.Text = "";
            lblNamaRekening.Text = "";
            if (this.SelectData != null) this.SelectData(this, new EventArgs());
        }

        private void txtLookup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) SEARCH(txtLookup.Text, false);

        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            SEARCH(txtLookup.Text, true);
        }

        private void txtLookup_KeyUp(object sender, KeyEventArgs e)
        {
      
            if (txtLookup.Text.Length < MaxLength)
            {
                lblLookupNamaBank.Text = "";
                lblNamaRekening.Text = "";
                lblNoRekening.Text = "";
            }
        }

        private DataTable SEARCH(string searchArg, bool _showDlg)
        {
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Rekening_SEARCH"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtLookup.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        _rowID =(Guid)Tools.isNull(dt.Rows[0]["RowID"], Guid.Empty);
                        lblLookupNamaBank.Text = Tools.isNull(dt.Rows[0]["BankID"], "").ToString();
                        txtLookup.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
                        lblNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();
                        lblNamaRekening.Text = Tools.isNull(dt.Rows[0]["NamaRekening"], "").ToString();

                    }
                    switch (_filterPT)
                    {
                        case enumFilterPT.PTLoginOnly:
                            foreach (DataRow dr in dt.Rows)
                                if ((Guid)Tools.isNull(dr["PerusahaanRowID"], Guid.Empty) != GlobalVar.PerusahaanRowID)
                                    dr.Delete();
                            break;
                    }
                    if ((dt.Rows.Count != 1) || (_showDlg)) ShowDialogForm(txtLookup.Text, dt);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return dt;
        }

    }
}
