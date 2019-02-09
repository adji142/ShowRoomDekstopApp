using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;

namespace ISA.Showroom.Master
{
    public partial class frmCostumerBlackList : ISA.Controls.BaseForm
    {
        public frmCostumerBlackList()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Customer_BlackList"));
                    dt = db.Commands[0].ExecuteDataTable();
                    DataColumn cConcatenated1 = new DataColumn("conIdentitas", Type.GetType("System.String"), "AlamatIdt + ' RT/RW ' + RTIdt + '/' + RWIdt + ' Kel. ' + KelurahanIdt + ' Kec. ' + KecamatanIdt + ' ' + KotaIdt + ' ' + ProvinsiIdt");
                    dt.Columns.Add(cConcatenated1);
                    DataColumn cConcatenated2 = new DataColumn("conDomisili", Type.GetType("System.String"), "AlamatDom + ' RT/RW ' + RTDom + '/' + RWDom + ' Kel. ' + KelurahanDom + ' Kec. ' + KecamatanDom + ' ' + KotaDom + ' ' + ProvinsiDom");
                    dt.Columns.Add(cConcatenated2);
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

        private void frmCostumerBlackList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnBlackList_Click(object sender, EventArgs e)
        {
            Master.frmCostumerBlackListUpdate ifrm = new frmCostumerBlackListUpdate(this);
            ifrm.formMode = frmCostumerBlackListUpdate.enumFormMode.Blacklist;
            Program.MainForm.CheckMdiChildren(ifrm);
        }

        private void btnUnblacklist_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid RowIDCust = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["CustRowID"].Value;
                string Nama = dataGridView1.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();

                Master.frmCostumerBlackListUpdate ifrm = new frmCostumerBlackListUpdate(this, RowIDCust, Nama);
                ifrm.formMode = frmCostumerBlackListUpdate.enumFormMode.Unblacklist;
                Program.MainForm.CheckMdiChildren(ifrm);
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {

        }
    }
}
