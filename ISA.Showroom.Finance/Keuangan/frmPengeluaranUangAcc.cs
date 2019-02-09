using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPengeluaranUangAcc : ISA.Controls.BaseForm
    {
        public frmPengeluaranUangAcc()
        {
            InitializeComponent();
        }

        private void cmdBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
