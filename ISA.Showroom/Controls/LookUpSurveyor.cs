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
    public partial class LookUpSurveyor : UserControl
    {
        public Class.clsSurveyor _Surveyor = new Class.clsSurveyor();

        public LookUpSurveyor()
        {
            InitializeComponent();
        }

        void RefreshData()
        {
            txtNamaSurveyor.Text = _Surveyor.NamaSurveyor;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsSurveyor.DBSearch(txtNamaSurveyor.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {

            frmLookUpSurveyor ifrm = new frmLookUpSurveyor(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _Surveyor = ifrm.Surveyor;
                RefreshData();
            }
        }

        private void txtNamaSurveyor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Class.clsSurveyor.DBSearch(txtNamaSurveyor.Text);

                if (dt != null && txtNamaSurveyor.Text.Trim().Length > 0 && txtNamaSurveyor.Text != _Surveyor.NamaSurveyor)
                {
                    switch (dt.Rows.Count)
                    {
                        case 0: break;
                        case 1:
                            {
                                _Surveyor.SetFromDataRow(dt.Rows[0]);
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
                _Surveyor = new Class.clsSurveyor(t_rowID);
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void LookUpSurveyor_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}