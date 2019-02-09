using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom
{
    public partial class frmPrint : ISA.Controls.BaseForm
    {
        int Rangkap = 0;

        public int Result
        {
            get
            {                
                if (rdbRangkap1.Checked == true)
                    return 1;
                else if (rdbRangkap2.Checked == true)
                    return 2;
                else if (rdbRangkap3.Checked == true)
                    return 3;
                else 
                    return 0;
            }
        }

        public frmPrint(Form caller, int _rangkap)
        {
            InitializeComponent();
            this.Caller = caller;
            Rangkap = _rangkap;
        }

        public frmPrint(Form caller, int _rangkap, string _customcaller )
        {
            InitializeComponent();
            this.Caller = caller;
            Rangkap = _rangkap;
        }


        private void frmPrint_Load(object sender, EventArgs e)
        {
            rdbSemua.Checked = true;
            rdbRangkap1.Checked = false;
            rdbRangkap2.Checked = false;
            rdbRangkap3.Checked = false;

            if (Rangkap == 1)
            {
                rdbRangkap1.Enabled = true;
                rdbRangkap2.Enabled = false;
                rdbRangkap3.Enabled = false;
            }
            else if (Rangkap == 2)
            {
                rdbRangkap1.Enabled = true;
                rdbRangkap2.Enabled = true;
                rdbRangkap3.Enabled = false;
            }
            else if (Rangkap == 3)
            {
                rdbRangkap1.Enabled = true;
                rdbRangkap2.Enabled = true;
                rdbRangkap3.Enabled = true;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
