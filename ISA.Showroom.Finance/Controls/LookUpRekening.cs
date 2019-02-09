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
    public partial class LookUpRekening : UserControl
    {

        #region Variables
          
        private string _sqlSearch = "usp_Rekening_SEARCH";
        private string _sqlSearchByMataUang = "usp_Rekening_SEARCH_BY_MataUang_BY_PT";
        private Guid _bankRowID, _rekeningRowID;
        private String _MataUangID="";
        private Guid _PerusahaanRowID;
        private int MaxLength;
        #endregion

        #region konstraktor

        public LookUpRekening()
        {
            InitializeComponent();
        }

        public LookUpRekening(String MataUangID)
        {
          
            InitializeComponent();
        }

        #endregion

        #region properties

        public Guid BankRowID
        {
            get { return _bankRowID; }
            set { _bankRowID = value; }
        }

        public Guid RekeningRowID
        {
            get { return _rekeningRowID; }
            set
            {
                _rekeningRowID = value;
               GetRekening();
            }
        }


        public String MataUangIDRekening
        {
            get { return _MataUangID; }
            set { _MataUangID = value; }
        }

        public Guid PerusahaanID
        {
            get { return _PerusahaanRowID; }
            set { _PerusahaanRowID = value; }
        }

        #endregion

        #region User Defined Functions
        public void SetRekeningRowID(Guid rekeningRowID)
        {
            _rekeningRowID = rekeningRowID;
            GetRekening();
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            SEARCH(txtSearch.Text, true);
        }

        private void ShowDialogForm()
        {

            frmLookUpRekening ifrmDialog = new frmLookUpRekening(_sqlSearch);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK) GetDialogResult(ifrmDialog.GetResult()); else BlankData();
        }
     
        /// <summary>
        /// ShowDialog2 untuk select No rekening by Mata Uang tertentu!
        /// </summary>
        /// <param name="p"></param>
        /// <param name="dt"></param>
        /// 
        private void ShowDialogForm2(String p,DataTable dt)
        {

            frmLookUpRekening ifrmDialog = new frmLookUpRekening(_sqlSearchByMataUang, _MataUangID,_PerusahaanRowID,txtSearch.Text);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK) GetDialogResult(ifrmDialog.GetResult()); else BlankData();
        }

        private void ShowDialogForm(string p, DataTable dt)
        {
            frmLookUpRekening ifrmDialog = new frmLookUpRekening(txtSearch.Text, dt, _sqlSearchByMataUang);//_sqlSearch);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK) GetDialogResult(ifrmDialog.GetResult()); else BlankData();
        }

        private void GetDialogResult(DataRow dr)
        {
            MaxLength = dr["NamaRekening"].ToString().Length;
            txtSearch.Text = dr["NamaRekening"].ToString();
            lblNoRekening.Text = dr["NoRekening"].ToString();
            lblBank.Text = dr["NamaBank"].ToString();
            _bankRowID = (Guid)Tools.isNull(dr["BankRowID"], Guid.Empty);
            _rekeningRowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
        }

        private void RefreshData(DataRow dr, bool setRek)
        {
            MaxLength = dr["NamaRekening"].ToString().Length;
            txtSearch.Text = dr["NamaRekening"].ToString();
            lblBank.Text = dr["NamaBank"].ToString();
            lblNoRekening.Text = dr["NoRekening"].ToString();
            _bankRowID = (Guid)Tools.isNull(dr["BankRowID"], Guid.Empty);
            if (setRek) _rekeningRowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
        }

        private void BlankData()
        {
            txtSearch.Text = "";
            lblBank.Text = "";
            lblNoRekening.Text = "";
            _bankRowID = Guid.Empty;
            _rekeningRowID = Guid.Empty;
        }

        private void GetRekening()
        {
            if ((_rekeningRowID != null) && (_rekeningRowID != Guid.Empty))
            {
                DataTable dt = Class.clsRekening.DBGetByRowID(_rekeningRowID);
                if ((dt!=null)&&(dt.Rows.Count == 1)) RefreshData(dt.Rows[0], false);
            }
        }

        private DataTable SEARCH(string searchArg, bool _showDlg)
        {
            // sementara agak hardcode...
            //MataUangIDRekening = "IDR";
            //PerusahaanID = new Guid("F0BFEC6B-E92C-44A3-9EEB-F41960503F15");
            DataTable dt = Class.clsRekening.DBGetByMataUang(_sqlSearchByMataUang, searchArg, MataUangIDRekening, PerusahaanID);
            if ((dt != null) && (dt.Rows.Count == 1) && (!_showDlg))
            {
                txtSearch.Text = Tools.isNull(dt.Rows[0]["NamaRekening"], "").ToString();
                lblNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();
                lblBank.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
            } else ShowDialogForm2(txtSearch.Text, dt); //else BlankData();
            return dt;
        }

        #endregion

        #region Controls Events
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13) SEARCH(txtSearch.Text, false);
            //if (e.KeyChar == 13)
            //{
                //if (txtSearch.Text == "")
                //{
                //    _bankRowID = Guid.Empty;
                //    _rekeningRowID = Guid.Empty;
                //}
                //else
                //{
                //    try
                //    {
                //        this.Cursor = Cursors.WaitCursor;
                //        using (Database db = new Database())
                //        {
                //            db.Commands.Add(db.CreateCommand(_sqlSearchByMataUang));//_sqlSearch));
                //            db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                //            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, MataUangIDRekening));
                //            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, PerusahaanID));
                //            DataTable dt = db.Commands[0].ExecuteDataTable();

                //            if (dt.Rows.Count == 1) RefreshData(dt.Rows[0], true); else ShowDialogForm(txtSearch.Text, dt);

                //        }

                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    finally
                //    {
                //        this.Cursor = Cursors.Default;
                //    }
                //}
            //}
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length < MaxLength)
            {
                lblNoRekening.Text = "";
                lblBank.Text = "";
            }

        }
        #endregion

    }
}
