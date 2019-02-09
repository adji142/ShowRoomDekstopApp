using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Controls
{
    public partial class LookUpCustomerALL : UserControl
    {
        public event EventHandler SelectData;
        public Class.clsCostumer _customer = new Class.clsCostumer();

        public LookUpCustomerALL()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsCostumer.DBSearch(txtNamaCustomer.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {

            frmLookUpCustomerALL ifrm = new frmLookUpCustomerALL(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _customer = ifrm.Customer;
                RefreshData();
                if (this.SelectData != null)
                {
                    this.SelectData(this, new EventArgs());
                }
            }
        }

        void RefreshData()
        {
            txtNamaCustomer.Text = _customer.NamaCustomer;
        }

        private void LookUpCustomerALL_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtNamaCustomer_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Class.clsCostumer.DBSearch(txtNamaCustomer.Text);

                if (dt != null && txtNamaCustomer.Text.Trim().Length > 0 && txtNamaCustomer.Text != _customer.NamaCustomer)
                {
                    switch (dt.Rows.Count)
                    {
                        case 0: break;
                        case 1:
                            {
                                _customer.SetFromDataRow(dt.Rows[0]);
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
                _customer = new Class.clsCostumer(t_rowID, "ALL");
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
