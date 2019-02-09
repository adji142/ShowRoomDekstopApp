using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Master
{
    public partial class frmKasSaldo : ISA.Controls.BaseForm
    {
        DataTable dt;
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        string modus;

        public frmKasSaldo()
        {
            InitializeComponent();
            fcbo.fillComboKas(cboKas,GlobalVar.PerusahaanRowID);
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            monthYearBox2.Month = GlobalVar.GetServerDate.Month;
            monthYearBox2.Year = GlobalVar.GetServerDate.Year;
        }

        private void frmKasSaldo_Load(object sender, EventArgs e)
        {
            RefreshData(false);
            RefreshTextbox();
        }

        private void RefreshData(bool aktif)
        {
            cboKas.Enabled = aktif;
            myPeriode.Enabled = aktif;
            txtSaldo.Enabled = aktif;

            cmdADD.Enabled = !aktif;
            cmdEDIT.Enabled = !aktif;
            cmdDELETE.Enabled = !aktif;
            cmdSAVE.Enabled = aktif;
            cmdCANCEL.Enabled = aktif;

            string BulanAwal = monthYearBox1.Year.ToString() + monthYearBox1.Month.ToString().PadLeft(2,'0');
            string BulanAkhir = monthYearBox2.Year.ToString() + monthYearBox2.Month.ToString().PadLeft(2,'0');

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KasSaldo_LIST_BY_Tanggal"));
                db.Commands[0].Parameters.Add(new Parameter("@TahunBulanAwal", SqlDbType.VarChar, BulanAwal));
                db.Commands[0].Parameters.Add(new Parameter("@TahunBulanAkhir", SqlDbType.VarChar, BulanAkhir));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt;
            }
        }

        private void RefreshTextbox()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                cboKas.Text = customGridView1.SelectedCells[0].OwningRow.Cells["JenisKas"].Value.ToString();
                myPeriode.Month = Convert.ToInt16(customGridView1.SelectedCells[0].OwningRow.Cells["Periode"].Value.ToString().Substring(4, 2));
                myPeriode.Year = Convert.ToInt16(customGridView1.SelectedCells[0].OwningRow.Cells["Periode"].Value.ToString().Substring(0, 4));
                txtSaldo.Text = customGridView1.SelectedCells[0].OwningRow.Cells["Saldo"].Value.ToString();
            }
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            myPeriode.Month = GlobalVar.GetServerDate.Month;
            myPeriode.Year = GlobalVar.GetServerDate.Year;
            modus = "Add";
            RefreshData(true);
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            modus = "Edit";
            RefreshData(true);
            RefreshTextbox();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Guid _KasRowID = (Guid)Guid.Empty;
            if (cboKas.Text != "")
            {
                DataRowView drvKas = (DataRowView)cboKas.Items[cboKas.SelectedIndex];
                _KasRowID = (Guid)drvKas.Row["RowID"];
            }
            Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string _TahunBulan = myPeriode.Year.ToString() + myPeriode.Month.ToString().PadLeft(2,'0');
            using (Database db = new Database(GlobalVar.DBName))
            {
                if (modus == "Add") db.Commands.Add(db.CreateCommand("usp_KasSaldo_INSERT"));
                else
                {
                    db.Commands.Add(db.CreateCommand("usp_KasSaldo_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                }

                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, _KasRowID));
                db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, _TahunBulan)); 
                db.Commands[0].Parameters.Add(new Parameter("@SaldoAwal", SqlDbType.Money, txtSaldo.Text)); 
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                db.Commands[0].ExecuteNonQuery();
            }
            RefreshData(false);
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            RefreshData(false);
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void monthYearBox1_Leave(object sender, EventArgs e)
        {
            RefreshData(false);
        }

        private void customGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RefreshTextbox();
        }

        private void customGridView1_Click(object sender, EventArgs e)
        {
            RefreshTextbox();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data ini ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KasSaldo_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshData(false);
            }
        }
    }
}
