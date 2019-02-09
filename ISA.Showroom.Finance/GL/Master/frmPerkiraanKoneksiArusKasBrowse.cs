using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmPerkiraanKoneksiArusKasBrowse : ISA.Controls.BaseForm
    {
        int nBrow = 0;
        public frmPerkiraanKoneksiArusKasBrowse()
        {
            InitializeComponent();
            if (GlobalVar.PerusahaanID != "HLD")
            {
                cmdADD.Enabled = false;
                cmdDELETE.Enabled = false;
            }
        }

        private void RefreshKode()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiKode_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            dt.DefaultView.Sort = "Kode";
            gridKode.DataSource = dt.DefaultView;
        }

        public void RefreshHeader()
        {
            if (gridKode.SelectedCells.Count > 0)
            {
                string kode = gridKode.SelectedCells[0].OwningRow.Cells["kKode"].Value.ToString();
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, kode));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "Kode";
                gridHeader.DataSource = dt.DefaultView;
            }
        }

        public void RefreshDetail()
        {
            if (gridKode.SelectedCells.Count > 0 && gridHeader.SelectedCells.Count > 0)
            {
                Guid headerID = new Guid(gridHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString() );
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "NoPerkiraan";
                gridDetail.DataSource = dt.DefaultView;
            }
        }

        private void frmPerkiraanKoneksiArusKasBrowse_Load(object sender, EventArgs e)
        {
            RefreshKode();
            RefreshHeader();
            RefreshDetail();
        }

        private void gridKode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridKode.SelectedCells.Count > 0)
            {
                RefreshHeader();
            }
        }

        private void gridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                RefreshDetail();
            }
        }

        private void gridKode_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKode.SelectedCells.Count > 0)
            {
                RefreshHeader();
            }
        }

        private void gridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
                RefreshDetail();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (nBrow == 3)
            {
                if (gridDetail.SelectedCells.Count > 0)
                {
                    Guid rowID = new Guid(gridDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value.ToString());
                    string noPerk = gridDetail.SelectedCells[0].OwningRow.Cells["dNoPerkiraan"].Value.ToString();
                    string ket = gridDetail.SelectedCells[0].OwningRow.Cells["dUraian"].Value.ToString();
                    frmPerkiraanKoneksiArusKasUpdate ifrmChild = new frmPerkiraanKoneksiArusKasUpdate(noPerk, ket, rowID, this);
                    ifrmChild.Show();

                }
            }
            else if (nBrow == 2 && GlobalVar.PerusahaanID == "HLD")
            {
                if (gridHeader.SelectedCells.Count > 0)
                {
                    Guid RowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value;
                    string Uraian = gridHeader.SelectedCells[0].OwningRow.Cells["hUraian"].Value.ToString();
                    GL.Master.frmPerkiraanKoneksiArusKasHeaderUpdate ifrmChild = new ISA.Showroom.Finance.GL.Master.frmPerkiraanKoneksiArusKasHeaderUpdate(RowID,Uraian,this);
                    ifrmChild.Show();
                }
            }
        }

        private void gridKode_Enter(object sender, EventArgs e)
        {
            nBrow = 1;
        }

        private void gridHeader_Enter(object sender, EventArgs e)
        {
            nBrow = 2;
        }

        private void gridDetail_Enter(object sender, EventArgs e)
        {
            nBrow = 3;
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (nBrow == 2)
            {
                string Kode = gridKode.SelectedCells[0].OwningRow.Cells["kKode"].Value.ToString();
                GL.Master.frmPerkiraanKoneksiArusKasHeaderUpdate ifrmChild = new ISA.Showroom.Finance.GL.Master.frmPerkiraanKoneksiArusKasHeaderUpdate(Kode,this);
                ifrmChild.Show();
            }
            else if (nBrow == 3)
            {
                if (gridDetail.SelectedCells.Count > 0)
                {
                    Guid HeaderID = new Guid(gridHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                    frmPerkiraanKoneksiArusKasUpdate ifrmChild = new frmPerkiraanKoneksiArusKasUpdate(HeaderID, this);
                    ifrmChild.Show();
                }
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskDelete, "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nBrow == 3)
                {
                    Guid dRowID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["dRowID"].Value;
                    using (Database db = new Database(GlobalVar.DBHoldingName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dRowID));
                        db.Commands[0].ExecuteNonQuery();
                        RefreshDetail();
                        MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    }
                }
                else if (nBrow == 2 && gridDetail.RowCount == 0)
                {
                    Guid hRowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hRowID"].Value;
                    using (Database db = new Database(GlobalVar.DBHoldingName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiKas_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, hRowID));
                        db.Commands[0].ExecuteNonQuery();
                        RefreshHeader();
                        RefreshDetail();
                        MessageBox.Show(Messages.Confirm.DeleteSuccess);
                    }
                }
            }
        }

    }
}
