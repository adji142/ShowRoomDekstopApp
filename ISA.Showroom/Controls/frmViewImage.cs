using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Controls
{
    public partial class frmViewImage : ISA.Controls.BaseForm
    {
        Image _file;

        public frmViewImage()
        {
            InitializeComponent();
        }

        public frmViewImage(Form caller, Image tobeOpened)
        {
            InitializeComponent();
            Caller = caller;
            _file = tobeOpened;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewImage_Load(object sender, EventArgs e)
        {
            pboImage.Image = _file;
            pboImage.SizeMode = PictureBoxSizeMode.Zoom;
        }


    }
}
