using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Showroom.Controls
{
    public partial class LookUpKolektor: UserControl
    {
        public Class.clsKolektor _Kolektor = new Class.clsKolektor();

        public LookUpKolektor()
        {
            InitializeComponent();
        }

        void RefreshData()
        {
            txtNamaKolektor.Text = _Kolektor.NamaKolektor;
        }

        private void LookUpKolektorman_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsKolektor.DBSearch(txtNamaKolektor.Text);           
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {

            frmLookUpKolektor ifrm = new frmLookUpKolektor(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _Kolektor = ifrm.Kolektor;
                RefreshData();           
            }           
        }

        private void txtNamaKolektor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable() ;
                dt = Class.clsKolektor.DBSearch(txtNamaKolektor.Text);
               
                if (dt != null && txtNamaKolektor.Text.Trim().Length>0 && txtNamaKolektor.Text != _Kolektor.NamaKolektor)
                {
                    switch (dt.Rows.Count)
                    {
                        case 0: break;
                        case 1:
                        {
                            _Kolektor.SetFromDataRow(dt.Rows[0]);
                            RefreshData();
                        } 
                        break;
                        default:
                            ShowFormDialog(dt);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

         public void SetByRowID(Guid t_rowID)
        {
            try
            {
                _Kolektor = new Class.clsKolektor(t_rowID);
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
