using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Master
{

    public partial class frmRekeningBrowse : ISA.Controls.BaseForm 
    {
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public frmRekeningBrowse() 
        {
            InitializeComponent();
        }

        private void frmRekeningBrowse_Load(object sender, EventArgs e)
        {
            fcbo.fillComboBank(cboBank,2);
            RefreshData();
            rdoAll.Checked = true;
            //togleFilter(false);
        }

        public void RefreshData() 
        {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Rekening_LIST_FILTER_BankID"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        if ((cboBank.DisplayMember!="") && (cboBank.Text.ToString() != ""))
                            db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, cboBank.SelectedValue));
                        if (rdoAktif.Checked == true)
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                        else if (rdoPasif.Checked == true)
                            db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, false));
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


        private void togleFilter(bool lFilter)
        {
            //_lFilter = lFilter;
            //cboBank.Enabled = _lFilter;
            //grpAktif.Enabled = _lFilter;
            //cmdCari.Visible = _lFilter;
            //cmdFilter.Visible = !_lFilter;
            //dataGridView1.Visible = !_lFilter;
            //cboBank.Refresh();
            //grpAktif.Refresh();
            //cmdFilter.Refresh();
            //cmdCari.Refresh();
            //dataGridView1.Refresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Master.frmRekeningUpdate ifrmChild = new Master.frmRekeningUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmRekeningUpdate ifrmChild = new Master.frmRekeningUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string rowID = dataGridView1.SelectedCells[0].OwningRow.Cells["NoRekening"].Value.ToString();
                if (MessageBox.Show("Hapus Rekening No. : " + rowID + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Rekening_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        this.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            togleFilter(true);
        }

        private void cmdCari_Click(object sender, EventArgs e)
        {
            RefreshData(); 
            togleFilter(false);
        }

        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rdoPasif_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void rdoAktif_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
