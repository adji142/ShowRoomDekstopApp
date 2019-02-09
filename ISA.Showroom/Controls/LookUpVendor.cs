using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Showroom.Controls
{
    public partial class LookUpVendor : UserControl
    {
        public Class.clsVendor _vendor = new Class.clsVendor();

        public LookUpVendor()
        {
            InitializeComponent();
        }

        void RefreshData()
        {
            txtNamaVendor.Text = _vendor.NamaVendor;
        }

        private void LookUpVendor_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsVendor.DBSearch(txtNamaVendor.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {
            frmLookUpVendor ifrm = new frmLookUpVendor(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _vendor = ifrm.Vendor;
                RefreshData();
            }
        }

        private void txtNamaVendor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Class.clsVendor.DBSearch(txtNamaVendor.Text);
                if (dt != null && txtNamaVendor.Text.Trim().Length > 0 && txtNamaVendor.Text != _vendor.NamaVendor)
                {
                    switch (dt.Rows.Count)
                    {
                        case 0: break;
                        case 1:
                            {
                                _vendor.SetFromDataRow(dt.Rows[0]);
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
                _vendor = new Class.clsVendor(t_rowID);
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
