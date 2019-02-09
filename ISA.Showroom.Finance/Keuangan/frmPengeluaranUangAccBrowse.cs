using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPengeluaranUangAccBrowse : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;

        public frmPengeluaranUangAccBrowse()
        {
            InitializeComponent();
            _toDate = GlobalVar.GetServerDate;
            _fromDate = _toDate.AddDays(-1 * (_toDate.Day - 1));
            rgtglKlr.ToDate = _toDate;
            rgtglKlr.FromDate = _fromDate;
        }

        private void frmPengeluaranAccBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST_FILTER_Acc"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _fromDate = (DateTime)rgtglKlr.FromDate;
            _toDate = (DateTime)rgtglKlr.ToDate;
            RefreshData();
        }

        private void cmdAcc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int _AccKe = 1; // int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["PengeluaranKe"].ToString());
                if ((_AccKe == 1) || (_AccKe == 2))
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, rowID, 1);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

    }
}
