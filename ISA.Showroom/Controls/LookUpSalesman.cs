using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Showroom.Controls
{
    public partial class LookUpSalesman : UserControl
    {
        public Class.clsSalesman _sales = new Class.clsSalesman();

        public LookUpSalesman()
        {
            InitializeComponent();
        }

        void RefreshData()
        {
            txtNamaSales.Text = _sales.NamaSales;
        }

        private void LookUpSalesman_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsSalesman.DBSearch(txtNamaSales.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {
            frmLookUpSalesman ifrm = new frmLookUpSalesman(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _sales = ifrm.Sales;
                RefreshData();           
            }           
        }

        private void txtNamaSales_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable() ;
                dt = Class.clsSalesman.DBSearch(txtNamaSales.Text);
                if (dt != null && txtNamaSales.Text.Trim().Length>0 && txtNamaSales.Text != _sales.NamaSales)
                {
                    switch (dt.Rows.Count)
                    {
                        case 0: break;
                        case 1:
                            {
                                _sales.SetFromDataRow(dt.Rows[0]);
                                RefreshData();
                            } break;
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
                _sales = new Class.clsSalesman(t_rowID);
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
