using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.RkBank
{
    public partial class SaldoRkBank : ISA.Controls.BaseForm
    {     
        public SaldoRkBank()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaldoRkBank_Load(object sender, EventArgs e)
        {
            Bank_RefreshData();
            RekBank_RefreshData();
            SaldoRk_RefreshData();
        }
        
        #region Functions
        private void Bank_RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Bank_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridViewBank.DataSource = dt;
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
        private void RekBank_RefreshData()
        {
            if (dataGridViewBank.SelectedCells.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        Guid _BankRowID = (Guid)dataGridViewBank.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Rekening_LIST_FILTER_BankID"));
                        db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, _BankRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridViewRekBank.DataSource = dt;
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
        }
        private void SaldoRk_RefreshData()
        {
            if (dataGridViewRekBank.SelectedCells.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        Guid _RekeningRowID = (Guid)dataGridViewRekBank.SelectedCells[0].OwningRow.Cells["AccountRowID"].Value;
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_SaldoRkBank_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RekeningRowID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dataGridViewSaldoRk.DataSource = dt;
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
        }

        private void AktifPasif(Boolean bTf, int nBrow)
        {
            Boolean lTrue = false;
            if (dataGridViewRekBank.RowCount > 0 && nBrow==3 && !bTf)
            {
                lTrue = true;
            }
            cmdADD.Enabled = lTrue;
            cmdEDIT.Enabled = lTrue;
            cmdDELETE.Enabled = lTrue;
            //cmdREPORT.Enabled = lTrue;
        }
        #endregion

        private void dataGridViewBank_Enter(object sender, EventArgs e)
        {
            AktifPasif(false,1);
            RekBank_RefreshData();
            SaldoRk_RefreshData();
        }
        private void dataGridViewRekBank_Enter(object sender, EventArgs e)
        {
            AktifPasif(false, 2);
            SaldoRk_RefreshData();
        }
        private void dataGridViewSaldoRk_Enter(object sender, EventArgs e)
        {
            AktifPasif(false,3);
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Guid RekeningRowID = (Guid)dataGridViewRekBank.SelectedCells[0].OwningRow.Cells["AccountRowID"].Value;
            String MataUangID = (String)dataGridViewRekBank.SelectedCells[0].OwningRow.Cells["MataUangID"].Value;
            SaldoRkBankUpdate ifrmChild = new SaldoRkBankUpdate(this, RekeningRowID, MataUangID);
            ifrmChild.ShowDialog();
            SaldoRk_RefreshData();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if(this.dataGridViewSaldoRk.Rows.Count >0)
            { 
                Guid RekeningRowID = (Guid)dataGridViewRekBank.SelectedCells[0].OwningRow.Cells["AccountRowID"].Value;
                String MataUangID = (String)dataGridViewRekBank.SelectedCells[0].OwningRow.Cells["MataUangID"].Value;
                Guid RowID = (Guid)dataGridViewSaldoRk.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                SaldoRkBankUpdate ifrmChild = new SaldoRkBankUpdate(this, RekeningRowID, RowID,MataUangID);
                ifrmChild.ShowDialog();
                SaldoRk_RefreshData();
                dataGridViewSaldoRk.FindRow("DetailRowID", RowID.ToString());                
            }

        }

        private void dataGridViewBank_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RekBank_RefreshData();
            SaldoRk_RefreshData();
        }
        private void dataGridViewRekBank_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SaldoRk_RefreshData();
        }
        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            String cPilih;
            cPilih = MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus data", MessageBoxButtons.YesNo).ToString();
            if (cPilih == "Yes")
            {
                using (Database db = new Database())
                {
                    Guid _rowID = (Guid)dataGridViewSaldoRk.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                    db.Commands.Add(db.CreateCommand("usp_SaldoRkBank_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                SaldoRk_RefreshData();
            }
        }

    }
}
