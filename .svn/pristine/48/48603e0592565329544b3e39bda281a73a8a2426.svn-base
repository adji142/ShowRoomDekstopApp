using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPenjualanShowroomBrowse : ISA.Controls.BaseForm
    {
        public String _noTrans;
        public Guid _rowID;

        public frmPenjualanShowroomBrowse()
        {
            InitializeComponent();
        }

        private void frmPenjualanShowroomBrowse_Load(object sender, EventArgs e)
        {
            _noTrans = "";
            _rowID = Guid.Empty;
            rangeDateBox1.FromDate = GlobalVar.GetServerDate;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate > rangeDateBox1.ToDate)
            {
                DateTime temp = rangeDateBox1.FromDate.Value;
                rangeDateBox1.FromDate = rangeDateBox1.ToDate.Value;
                rangeDateBox1.ToDate = temp;
            }

            using(Database db = new Database(GlobalVar.DBShowroom))
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_FILTER_TANGGAL"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                if (String.IsNullOrEmpty(txtNoTrans.Text.Trim()))
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoTrans.Text));
                }
                db.Commands[0].Parameters.Add(new Parameter("@Komisi", SqlDbType.Int, 1));
                dummy = db.Commands[0].ExecuteDataTable();
                dgPenjualan.DataSource = dummy;
            }            
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (dgPenjualan.SelectedCells.Count > 0)
            {
                _rowID = new Guid(dgPenjualan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _noTrans = dgPenjualan.SelectedCells[0].OwningRow.Cells["NoTrans"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Pilih data Penjualan terlebih dahulu!");
                return;
            }
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            _rowID = Guid.Empty;
            _noTrans = "";
            this.Close();
        }
    }
}
