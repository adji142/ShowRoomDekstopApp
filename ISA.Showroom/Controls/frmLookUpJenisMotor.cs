using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Controls
{
    public partial class frmLookUpJenisMotor : ISA.Controls.BaseForm
    {

        string jenisMotor_ = "";
        string tahun_ = "";
        double harga_ = 0;
        Guid rowID_ = Guid.Empty;


        public string _JenisMotor
        {
            get
            {
                return jenisMotor_;
            }
            set
            {
                jenisMotor_ = value;
            }
        }

        public string _Tahun
        {
            get
            {
                return tahun_;
            }
            set
            {
                tahun_ = value;
            }
        }

        public Double _Harga
        {
            get
            {
                return harga_;
            }
            set
            {
                harga_ = value;
            }
        }

        public Guid _RowID
        {
            get
            {
                return rowID_;
            }
            set
            {
                rowID_ = value;
            }
        }

        public frmLookUpJenisMotor()
        {
            InitializeComponent();
        }

        public frmLookUpJenisMotor(DataTable dt, string srcarg)
        {
            InitializeComponent();
            txtSearch.Text = srcarg;
            GVJenisMotor.AutoGenerateColumns = false;
            GVJenisMotor.DataSource = dt;
        }

        private void GVJenisMotor_KeyDown(object sender, KeyEventArgs e)
        {
            if (GVJenisMotor.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ConfirmSelect();
                }
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (GVJenisMotor.Rows.Count > 0)
            {
                    ConfirmSelect();
            }
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void ConfirmSelect()
        {
            if (GVJenisMotor.SelectedCells.Count == 1)
            {
                _RowID = (Guid)GVJenisMotor.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                _JenisMotor = GVJenisMotor.SelectedCells[0].OwningRow.Cells["JenisMotor"].Value.ToString();
                _Tahun = GVJenisMotor.SelectedCells[0].OwningRow.Cells["Tahun"].Value.ToString();
                _Harga = Double.Parse(GVJenisMotor.SelectedCells[0].OwningRow.Cells["Harga"].Value.ToString());

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GVJenisMotor_DoubleClick(object sender, EventArgs e)
        {
            if (GVJenisMotor.Rows.Count > 0)
            {
                ConfirmSelect();
            }
        }
    }
}
