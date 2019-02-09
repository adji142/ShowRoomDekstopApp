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
    public partial class frmCF_JenisTransaksi : ISA.Controls.BaseForm
    {
        enum enumModus { New, Update };
        enum enumGrid { Satu, Dua };
        enumModus Modus;
        enumGrid Grid;
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();

        public frmCF_JenisTransaksi()
        {
            InitializeComponent();
            IsiComboGroupCF();
            fcbo.fillComboJnsTransaksi(cboTransaksiFinance);
            fcbo.fillComboCabang(cboCabang);
        }

        #region Functions
        private void SetupEnableDisable(Boolean tfText)
        {
            Boolean Cek1 = dgHeader.RowCount > 0;
            Boolean Cek2 = dgDetail.RowCount > 0;

            txtTransakiCF.Enabled = tfText && Grid == enumGrid.Satu;
            cboGroupCF.Enabled = tfText && Grid == enumGrid.Satu;
            cboGroupTrans.Enabled = tfText && Grid == enumGrid.Satu;
            cmdADD1.Enabled = !tfText && Grid == enumGrid.Satu;
            cmdEDIT1.Enabled = !tfText && Cek1 && Grid == enumGrid.Satu;
            cmdDELETE1.Enabled = !tfText && Cek1 && !Cek2 && Grid == enumGrid.Satu;
            cmdSAVE1.Enabled = tfText && Grid == enumGrid.Satu;
            cmdCANCEL1.Enabled = tfText && Grid == enumGrid.Satu;

            cboTransaksiFinance.Enabled = tfText && Grid == enumGrid.Dua;
            cboCabang.Enabled = tfText && Grid == enumGrid.Dua;
            lookUpBankRekening1.Enabled = tfText && Grid == enumGrid.Dua;
            cmdADD2.Enabled = !tfText && Cek1 && Grid == enumGrid.Dua;
            cmdEDIT2.Enabled = !tfText && Cek2 && Grid == enumGrid.Dua;
            cmdDELETE2.Enabled = !tfText && Cek2 && Grid == enumGrid.Dua;
            cmdSAVE2.Enabled = tfText && Grid == enumGrid.Dua;
            cmdCANCEL2.Enabled = tfText && Grid == enumGrid.Dua;
        }
        private void RefreshHeader()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_header_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dgHeader.DataSource = dt;
            }
        }
        private void RefreshDetail()
        {
            if (dgHeader.SelectedCells.Count > 0)
            {
                Guid HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_detail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, HeaderRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgDetail.DataSource = dt;
                }
            }
        }
        private void DisplayHeader()
        {
            if (dgHeader.SelectedCells.Count > 0)
            {
                txtTransakiCF.Text = dgHeader.SelectedCells[0].OwningRow.Cells["JnsTransaksi"].Value.ToString();
                cboGroupCF.SelectedValue = dgHeader.SelectedCells[0].OwningRow.Cells["KlpCashFlow"].Value.ToString();
                cboGroupTrans.SelectedValue = dgHeader.SelectedCells[0].OwningRow.Cells["KlpTransaksi"].Value.ToString();
            }
        }
        private void DisplayDetail()
        {
            if (dgDetail.SelectedCells.Count > 0)
            {
                cboTransaksiFinance.SelectedValue = dgDetail.SelectedCells[0].OwningRow.Cells["JnsTransRowID"].Value.ToString();
                txtKodeTransaksi.Text = dgDetail.SelectedCells[0].OwningRow.Cells["TransaksiID"].Value.ToString();
                txtNoPerkiraan.Text = dgDetail.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                lookUpBankRekening1.RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RekeningRowID"].Value;
            }
        }
        private void IsiComboGroupCF()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                cboGroupCF.DataSource = dt;
            }
            cboGroupCF.DisplayMember = "JnsTransaksi";
            cboGroupCF.ValueMember = "RowID";
        }
        private void IsiComboGroupTrans()
        {
            if (Tools.isNull(cboGroupCF.SelectedValue, "").ToString() != "")
            {
                DataRowView drv = (DataRowView)cboGroupCF.SelectedItem;
                Guid _HeaderRowID = (Guid)drv["RowID"];
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_group_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, _HeaderRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    cboGroupTrans.DataSource = dt;
                }
                cboGroupTrans.DisplayMember = "JnsTransaksi";
                cboGroupTrans.ValueMember = "RowID";
            }
        }
        #endregion

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCF_JenisTransaksi_Load(object sender, EventArgs e)
        {
            SetupEnableDisable(false);
            RefreshHeader();
            RefreshDetail();
        }

        private void cmdADD1_Click(object sender, EventArgs e)
        {
            Modus = enumModus.New;
            SetupEnableDisable(true);
            txtTransakiCF.Text = "";
            cboGroupCF.SelectedValue = "";
            txtTransakiCF.Focus();
        }

        private void dgHeader_Click(object sender, EventArgs e)
        {
            Grid = enumGrid.Satu;
            SetupEnableDisable(false);
        }

        private void dgDetail_Click(object sender, EventArgs e)
        {
            Grid = enumGrid.Dua;
            SetupEnableDisable(false);
        }

        private void cmdEDIT1_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Update;
            SetupEnableDisable(true);
            DisplayHeader();
            txtTransakiCF.Focus();
        }

        private void cmdADD2_Click(object sender, EventArgs e)
        {
            Modus = enumModus.New;
            SetupEnableDisable(true);
            cboTransaksiFinance.Focus();
        }

        private void cmdEDIT2_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Update;
            SetupEnableDisable(true);
            DisplayDetail();
            cboTransaksiFinance.Focus();
        }

        private void cmdSAVE1_Click(object sender, EventArgs e)
        {
            if (Tools.isNull(cboGroupCF.SelectedValue,"").ToString() == "")
            {
                cboGroupCF.Focus();
                return;
            }
            if (Modus == enumModus.New)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_header_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtTransakiCF.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, cboGroupTrans.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            else
            {
                Guid RowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_header_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, txtTransakiCF.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, cboGroupTrans.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            SetupEnableDisable(false);
            RefreshHeader();
        }

        private void cmdCANCEL1_Click(object sender, EventArgs e)
        {
            SetupEnableDisable(false);
        }

        private void cmdSAVE2_Click(object sender, EventArgs e)
        {
            Guid HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataRowView drv = (DataRowView)cboTransaksiFinance.Items[cboTransaksiFinance.SelectedIndex];
            string CabangID = Tools.isNull(cboCabang.SelectedValue, "").ToString();
            string RekeningID = lookUpBankRekening1.txtLookup.Text;
            if (
                (drv[2].ToString() != "" && RekeningID == "" && CabangID == "") || 
                (drv[2].ToString() == "" && RekeningID != "" && CabangID == "") ||
                (drv[2].ToString() == "" && RekeningID == "" && CabangID != "")
                )
            {
                Guid RekeningRowID = Guid.Empty;
                if (RekeningID != "") RekeningRowID = (Guid)lookUpBankRekening1.RowID;
                
                Guid JnsTransRowID = Guid.Empty;
                if (drv[2].ToString() != "") JnsTransRowID = (Guid)drv["RowID"];
                
                if (Modus == enumModus.New)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_detail_INSERT"));
                        if (JnsTransRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@JnsTransRowID", SqlDbType.UniqueIdentifier, JnsTransRowID));
                        if (RekeningRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                        if (CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, HeaderRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                else
                {
                    Guid RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_detail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        if (JnsTransRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@JnsTransRowID", SqlDbType.UniqueIdentifier, JnsTransRowID));
                        if (RekeningRowID != Guid.Empty) db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, RekeningRowID));
                        if (CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu antara Jenis Transaksi, Rekening Bank, atau Cabang !","Perhatian!");
            }

            SetupEnableDisable(false);
            RefreshDetail();
        }

        private void cmdCANCEL2_Click(object sender, EventArgs e)
        {
            SetupEnableDisable(false);
        }

        private void cmdDELETE1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Guid RowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_header_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            RefreshHeader();
        }

        private void cboTransaksiFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboTransaksiFinance.Items[cboTransaksiFinance.SelectedIndex];
            txtKodeTransaksi.Text = drv["JnsTransaksi"].ToString();
            txtNoPerkiraan.Text = drv["NoPerkiraan01"].ToString();
        }

        private void dgHeader_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetail();
            DisplayHeader();
        }

        private void cmdDELETE2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Guid RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCF_detail_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            RefreshDetail();
        }

        private void cboGroupCF_SelectedValueChanged(object sender, EventArgs e)
        {
            IsiComboGroupTrans();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_KelompokTransaksi ifrm = new frmCF_KelompokTransaksi();
            //ifrm.MdiParent = this;
            ifrm.Show();
            //ifrm.WindowState = FormWindowState.Maximized;
        }

    }
}
