using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Controls
{
    public partial class LookUpRekening : UserControl
    {

        private System.Guid _rekeningRowID ;
        private string _noRekening;
        private string _noPerkiraanRekening;
        private string _namaPerkiraanRekening;

        public System.Guid RekeningRowID
        {
            get
            {
                return this._rekeningRowID; 
            }
            set
            {
                this._rekeningRowID = value;
            }

        }

        public string NoRekening
        {
            get
            {
                return this._noRekening;
            }
            set
            {
                this._noRekening = value;
            }

        }

        public string NoPerkiraanRekening
        {
            get
            {
                return this._noPerkiraanRekening;
            }
            set
            {
                this._noPerkiraanRekening = value;
            }

        }

        public string NamaRekening
        {
            get
            {
                return this._namaPerkiraanRekening;
            }
            set
            {
                this._namaPerkiraanRekening = value;
            }

        }


        public LookUpRekening()
        {
            InitializeComponent();
        }

        private void txtNamaRekening_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (Database db = new Database(GlobalVar.DBFinanceOto))
            {
                db.Commands.Add(db.CreateCommand("usp_Rekening_SEARCH"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNamaRekening.Text));
                //db.Commands[0].AddParameter("@searchArg", SqlDbType.VarChar, txtNamaRekening.Text);
                
                dt = db.Commands[0].ExecuteDataTable(); 

                 if (dt.Rows.Count == 1)
                {
                    _rekeningRowID = new System.Guid(dt.Rows[0]["RowID"].ToString());
                    _noRekening = dt.Rows[0]["NoRekening"].ToString();
                    _noPerkiraanRekening = dt.Rows[0]["NoPerkiraan"].ToString();
                    lblNoRek.Text = _noRekening;
                    txtNamaRekening.Text = dt.Rows[0]["NamaRekening"].ToString();
                    _namaPerkiraanRekening = dt.Rows[0]["NamaRekening"].ToString();
                }
                else
                {
                    ShowFormDialog(dt);
                }              
            }           
        }


        private void ShowFormDialog(DataTable dt)
        {

            frmLookUpRekening ifrm = new frmLookUpRekening(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _rekeningRowID = ifrm._rekeningRowID ;
                _noRekening = ifrm._noRekening;
                _noPerkiraanRekening = ifrm._noPerkiraanRekening;
                lblNoRek.Text = _noRekening + " ( " + _noPerkiraanRekening + " ) ";
                txtNamaRekening.Text = ifrm._namaRekening;
                NamaRekening = ifrm._namaRekening; 
                
            }
        }

        public void SetTextBoxNamaRekening(string namaRekening)
        {
            txtNamaRekening.Text = namaRekening; 
        }

        public void SetLabelNoRekening(string noRekening)
        {
            lblNoRek.Text = noRekening; 
        }

    }
}
