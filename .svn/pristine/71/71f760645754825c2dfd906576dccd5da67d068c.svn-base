using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Showroom.Controls
{
    public partial class LookUpStokMotor : UserControl
    {
        public Class.clsStokMotor _motor = new Class.clsStokMotor();
       

        public LookUpStokMotor()
        {
            InitializeComponent();
        }

        void RefreshData()
        {   
            txtNopol.Text = _motor.Nopol;
            
        }

        private void LookUpMotor_Load(object sender, EventArgs e)
        {
            txtNopol.Text = "";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsStokMotor.DBSearch(txtNopol.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {
            frmLookUpStokMotor ifrm = new frmLookUpStokMotor(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _motor = ifrm.Motor;
                RefreshData();
            }
        }

        private void txtNamaMotor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Class.clsStokMotor.DBSearch(txtNopol.Text);
                if (dt != null && txtNopol.Text.Trim().Length > 0 && txtNopol.Text != _motor.Nopol)
                {
                    switch (dt.Rows.Count)
                    {
                        case 0: break;
                        case 1:
                            {
                                _motor.SetFromDataRow(dt.Rows[0]);
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
                _motor = new Class.clsStokMotor(t_rowID);
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void LookUpStokMotor_Leave(object sender, EventArgs e)
        {

        }


      

    }
}
