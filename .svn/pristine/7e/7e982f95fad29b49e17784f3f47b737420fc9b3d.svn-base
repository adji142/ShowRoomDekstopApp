using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmIdenBBNBrowse : ISA.Controls.BaseForm
    {
        DataTable dtHeader;
        public frmIdenBBNBrowse()
        {
            InitializeComponent();
        }

        private void frmIdenBBNBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            check_Lunas.Checked = false;
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshHeader(Guid.Empty);
            }
            catch
            {
            }
        }

        public void RefreshHeader(Guid RowID)
        {
            try
            {
                dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPelunasanBBN_ListHeader"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                GVHeader.DataSource = dtHeader;

                if (dtHeader.Rows.Count > 0)
                {
                    if (RowID != Guid.Empty)
                    {
                        GVHeader.FindRow("RowID", RowID.ToString());
                    }
                }
                else
                {
                    GVDetail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDetail(Guid RowIDD)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenBBNDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                GVDetail.DataSource = dt;

                if (dt.Rows.Count > 0 && RowIDD != Guid.Empty)
                {
                    GVDetail.FindRow("RowID_PU", RowIDD.ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail(Guid.Empty);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLunas_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                if (GVDetail.Rows.Count > 0)
                {
                    MessageBox.Show("Sudah pernah dilakukan pelunasan BBN");
                    return;
                }
                else
                {
                    if (double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["SisaBBN"].Value.ToString()) > 0)
                    {
                        DataTable dt_BBN = new DataTable();
                        dt_BBN = dtHeader.Copy();
                        dt_BBN.DefaultView.RowFilter = "RowID = '" + GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                        Kasir.frmIdenBBNPelunasan ifrmChild = new frmIdenBBNPelunasan(this, dt_BBN.DefaultView.ToTable());
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tidak mempunyai sisa BBN");
                        return;
                    }
                }
            }
        }

    }
}
