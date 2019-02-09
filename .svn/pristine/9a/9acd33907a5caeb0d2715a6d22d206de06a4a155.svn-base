using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmCF_KelompokTransaksi : ISA.Controls.BaseForm
    {
        enum enumGrid {Satu,Dua};
        enum enumModus {New,Update};
        enumGrid eGrid;
        enumModus eModus;

        public frmCF_KelompokTransaksi()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCF_KelompokTransaksi_Load(object sender, EventArgs e)
        {
            RefreshGridHeader();
            SetupEnable(false);
        }
        #region Functions

        private void RefreshGridHeader()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                dgHeader.DataSource = dt;
            }
        }
        private void RefreshGridDetail(Guid HeaderRowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, HeaderRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dgDetail.DataSource = dt;
            }
        }
        private void RefreshText()
        {
            if (eGrid == enumGrid.Satu && dgHeader.SelectedCells.Count > 0)
            {
                txtCF.Text = dgHeader.SelectedCells[0].OwningRow.Cells["hJnsTransaksi"].Value.ToString();
            }
            if (dgDetail.SelectedCells.Count > 0)
            {
                txtTrans.Text = dgDetail.SelectedCells[0].OwningRow.Cells["gJnsTransaksi"].Value.ToString();
            }
        }
        private void SetupEnable(bool bTf)
        {
            txtCF.Enabled = bTf && eGrid == enumGrid.Satu; ;
            txtTrans.Enabled = bTf && eGrid == enumGrid.Dua; ;
            //cmdADD1.Enabled = !bTf && (eGrid == enumGrid.Satu || (eGrid == enumGrid.Dua && dgHeader.SelectedCells.Count > 0));
            //cmdEDIT1.Enabled = !bTf && ((eGrid == enumGrid.Satu && dgHeader.SelectedCells.Count > 0) || (eGrid == enumGrid.Dua && dgDetail.SelectedCells.Count > 0));
            //cmdDELETE1.Enabled = !bTf && ((eGrid == enumGrid.Satu && dgHeader.SelectedCells.Count > 0 && dgDetail.SelectedCells.Count == 0) || (eGrid == enumGrid.Dua && dgDetail.SelectedCells.Count > 0));
            cmdADD1.Enabled = !bTf && eGrid == enumGrid.Dua && dgHeader.SelectedCells.Count > 0;
            cmdEDIT1.Enabled = !bTf && eGrid == enumGrid.Dua && dgDetail.SelectedCells.Count > 0;
            cmdDELETE1.Enabled = !bTf && eGrid == enumGrid.Dua && dgDetail.SelectedCells.Count > 0;
            cmdSAVE.Enabled = bTf;
            cmdCANCEL.Enabled = bTf;
        }
        #endregion

        private void dgHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dgHeader.SelectedCells.Count > 0)
            {
                Guid HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value;
                RefreshGridDetail(HeaderRowID);
            }
            RefreshText();
            SetupEnable(false);
        }

        private void dgHeader_Enter(object sender, EventArgs e)
        {
            eGrid = enumGrid.Satu;
            SetupEnable(false);
        }

        private void dgDetail_Enter(object sender, EventArgs e)
        {
            eGrid = enumGrid.Dua;
            SetupEnable(false);
        }

        private void cmdADD1_Click(object sender, EventArgs e)
        {
            eModus = enumModus.New;
            SetupEnable(true);
            if (eGrid == enumGrid.Satu) txtCF.Text = "";
            else txtTrans.Text = "";
        }

        private void cmdEDIT1_Click(object sender, EventArgs e)
        {
            eModus = enumModus.Update;
            SetupEnable(true);
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (eGrid == enumGrid.Satu)
            {
                Guid RowID = (Guid)Guid.Empty;
                if (eModus == enumModus.Update) RowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtCF.Text));
                    if (eModus == enumModus.Update) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshGridHeader();
            }
            else
            {
                Guid HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value;
                Guid RowID = (Guid)Guid.Empty;
                if (eModus == enumModus.Update) RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["gRowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtTrans.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, HeaderRowID));
                    if (eModus == enumModus.Update) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshGridDetail(HeaderRowID);
            }
            SetupEnable(false);
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            SetupEnable(false);
        }

        private void dgDetail_SelectionChanged(object sender, EventArgs e)
        {
            RefreshText();
        }

        private void cmdDELETE1_Click(object sender, EventArgs e)
        {
            Guid HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value;
            if (MessageBox.Show("Anda yakin akan menghapus data ini?","Hapus data!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Guid RowID = HeaderRowID;
                if (eGrid == enumGrid.Dua) RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["gRowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, HeaderRowID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            if (eGrid == enumGrid.Satu) RefreshGridHeader();
            else RefreshGridDetail(HeaderRowID);
        }

    }
}
