using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmHutangLainLain_History : ISA.Controls.BaseForm
    {
        DataTable dtH = new DataTable("PLL");
        DataTable dtHX = new DataTable("HUTANG");
        DataRow[] dr;
        static string _Link = string.Empty;

        public  string Link
        {
            get {
                return _Link;
            }
        }

        public DataRow GetData
        {
            get
            {

                return dr[0];
            }
        }



        public frmHutangLainLain_History()
        {
            InitializeComponent();
        }

        public frmHutangLainLain_History(DataTable dt)
        {
            dtH = dt.Copy();
            InitializeComponent();

        }

        public frmHutangLainLain_History(DataTable dt, DataTable dtX)
        {
            dtH = dt.Copy();
            dtHX = dtX.Copy();
            InitializeComponent();

        }



        private void ConfirmSelect()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (GVHeader.SelectedCells.Count == 1)
                {
                    string _rowID = GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
                    dr = dtH.Select("RowID='" + _rowID + "'");
                }
                _Link = "PLL";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {

            if (GVHeader.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }

        }

        private void GVHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GVHeader.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void frmMutasiPenerimaanPLL_Load(object sender, EventArgs e)
        {
            GVHeader.DataSource = dtH.DefaultView;
           
        }
    }
}
