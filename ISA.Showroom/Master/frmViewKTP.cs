using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Master
{
    public partial class frmViewKTP : ISA.Controls.BaseForm
    {
        public frmViewKTP()
        {
            InitializeComponent();
        }

        public frmViewKTP(String NoKTP)
        {
            InitializeComponent();
            uploadFotoKtp1.NomorKtp = NoKTP;
            //uploadFotoKtp1.Enabled = false;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uploadFotoKtp1_FinishUploaded(object sender, EventArgs e)
        {
            uploadFotoKtp1.resetpicture();
        }

        private void frmViewKTP_Load(object sender, EventArgs e)
        {

        }
    }
}
