using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Showroom.Controls
{
    public partial class LookUpStokMotorTLA : UserControl
    {
        public Class.clsStokMotor _motor = new Class.clsStokMotor();
       

        public LookUpStokMotorTLA()
        {
            InitializeComponent();
        }

        void RefreshData()
        {   
            // txtNoPol.Text = _motor.Nopol;
            // kalau di TLA tiban ganti sama NoMesin atau NoRangka aja
            if (String.IsNullOrEmpty(_motor.NoMesin))
            {
                txtNoPol.Text = _motor.NoRangka;
            }
            else
            {
                txtNoPol.Text = _motor.NoMesin;
            }
        }

        private void LookUpMotor_Load(object sender, EventArgs e)
        {
            txtNoPol.Text = "";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsStokMotor.DBSearchStokBARU(txtNoPol.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {
            frmLookUpStokMotorTLA ifrm = new frmLookUpStokMotorTLA(dt);
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
                dt = Class.clsStokMotor.DBSearchStokBARU(txtNoPol.Text);
                if (dt != null && txtNoPol.Text.Trim().Length > 0 && txtNoPol.Text != _motor.Nopol)
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

        private void LookUpStokMotorTLA_Leave(object sender, EventArgs e)
        {

        }


      

    }
}
