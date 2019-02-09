using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace ISA.Showroom.Controls
{
    public partial class LookUpMotor : UserControl
    {
        public Class.clsMotor _motor = new Class.clsMotor();
        public event EventHandler SelectData;

        public LookUpMotor()
        {
            InitializeComponent();
        }

        void RefreshData()
        {   
            txtNamaMotor.Text = _motor.MerkMotor + " " + _motor.TypeMotor;
        }

        private void LookUpMotor_Load(object sender, EventArgs e)
        {
            //txtNamaMotor.Text = "";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.clsMotor.DBSearch(txtNamaMotor.Text);
            ShowFormDialog(dt);
        }

        void ShowFormDialog(DataTable dt)
        {
            frmLookUpMotor ifrm = new frmLookUpMotor(dt);
            ifrm.ShowDialog();
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _motor = ifrm.Motor;
                RefreshData();

                if (this.SelectData != null)
                {
                    this.SelectData(this, new EventArgs());
                }
            }
        }

        private void txtNamaMotor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Class.clsMotor.DBSearch(txtNamaMotor.Text);
                if (dt != null && txtNamaMotor.Text.Trim().Length > 0 && txtNamaMotor.Text != _motor.MerkMotor)
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
                _motor = new Class.clsMotor(t_rowID);
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
