using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Controls;
using ISA.DAL;


namespace ISA.Showroom.Finance.Controls 
{
    public partial class frmLookupBankRekening : Form//ISA.Controls.BaseForm
    {
        string _bankID;
        string _namaBank; 
        string _NoRekening; 
        string _Namarekening;
        Guid _rowID;
        LookUpBankRekening.enumFilterPT _filterPT = LookUpBankRekening.enumFilterPT.All;
        //String _textsearch;

        public Guid RowID
        {
            get
            {
                return _rowID;
            }

            set
            {
                _rowID = value;
            }
        }

        public string BankID
        {
            get
            {
                return _bankID;
            }

            set
            {
                _bankID = value;
            }
        }

        public string NamaBank
        {
            get
            {
                return _namaBank;
            }
            set
            {
                _namaBank = value;
            }
        }

        public string No_Rekening
        {
            get { return _NoRekening; }
            set { _NoRekening = value; }
        }

        public string Nama_rekening
        {
            get { return _Namarekening; }
            set { _Namarekening = value; }
        }

        public frmLookupBankRekening()
        {

            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
            //_textsearch = textSearch;
            //customGridView1.AutoGenerateColumns = false;
        }

        public frmLookupBankRekening(LookUpBankRekening.enumFilterPT filterPT)
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
            _filterPT = filterPT;
        }
        public frmLookupBankRekening(string searchArg, DataTable dt)
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
            txtSearch.Text = searchArg;
            customGridView1.DataSource = dt/*.DefaultView*/;            
        }

        public frmLookupBankRekening(string searchArg, DataTable dt, LookUpBankRekening.enumFilterPT filterPT)
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
            txtSearch.Text = searchArg;
            _filterPT = filterPT;
            customGridView1.DataSource = dt/*.DefaultView*/;
        }

        public void RefreshData()
        {            
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_Rekening_SEARCH"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                dt = db.Commands[0].ExecuteDataTable();
                switch (_filterPT)
                {
                    case LookUpBankRekening.enumFilterPT.PTLoginOnly:
                        foreach (DataRow dr in dt.Rows)
                            if ((Guid)Tools.isNull(dr["PerusahaanRowID"], Guid.Empty) == GlobalVar.PerusahaanRowID)
                                dr.Delete();
                        break;
                }
                customGridView1.DataSource = dt/*.DefaultView*/;
            }
        }



        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                _bankID = customGridView1.SelectedCells[0].OwningRow.Cells["cBankID"].Value.ToString();
                _namaBank = customGridView1.SelectedCells[0].OwningRow.Cells["cNamaBank"].Value.ToString();
                _NoRekening = customGridView1.SelectedCells[0].OwningRow.Cells["cNoRekening"].Value.ToString();
                _Namarekening = customGridView1.SelectedCells[0].OwningRow.Cells["cNamaRekening"].Value.ToString();
                _rowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["cRowID"].Value;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


     
        private void frmLookupBank_Load(object sender, EventArgs e)
        {
            //txtSearch.Focus();
           // txtSearch.Text = _textsearch;
            if(!(txtSearch.Text.Equals(String.Empty))) cmdSearch_Click(null, null);
            customGridView1.AutoGenerateColumns = false;
        }



        private void customGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1) ConfirmSelect();
        }


        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) cmdSearch.PerformClick();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length < 1) RefreshData(); else RefreshData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) if (customGridView1.Rows.Count == 1) ConfirmSelect();
        }
    }
}
