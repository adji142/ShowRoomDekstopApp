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
    public partial class frmGiroBrowse : ISA.Controls.BaseForm
    {
        Class.FillComboBox fcbo = new Class.FillComboBox();
        string _bankID = "";
        string _bankNama = "";

        public frmGiroBrowse()
        {
            InitializeComponent();
        }

        private void frmGiroBrowse_Load(object sender, EventArgs e)
        {
            fcbo.fillComboBank(cboBank,2);
            rtDtExpired.FromDate = DateTime.MinValue;
            rtDtExpired.ToDate = DateTime.MaxValue;
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
                    db.Commands.Add(db.CreateCommand("usp_BukuGiro_LIST_FILTER_Rekening"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rtDtExpired.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rtDtExpired.ToDate));
                    if ((cboBank.DisplayMember!="") && (cboBank.Text!= "")) db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, cboBank.SelectedValue));
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

        private void cmdADD_Click(object sender, EventArgs e)
        {
            //if ((_bankID == "")||(_bankNama==""))
            //{
            //    MessageBox.Show("Silahkan pilih Bank terlebih dahulu");
            //} else 
            //{
                Master.frmGiroUpdate ifrmChild = new Master.frmGiroUpdate(this);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            //}
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Master.frmGiroUpdate ifrmChild = new Master.frmGiroUpdate(this, rowID);
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
                Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                String NamaRekening = (String)dataGridView1.SelectedCells[0].OwningRow.Cells["NamaRekening"].Value;
                if (MessageBox.Show("Hapus Buku Giro dengan No Rekening: " + NamaRekening + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_BukuGIro_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
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

        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _bankID = cboBank.SelectedValue.ToString();
                _bankNama = cboBank.Text.ToString();
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void rtDtExpired_Validating(object sender, CancelEventArgs e)
        {
            RefreshData();
        }

    }
}
