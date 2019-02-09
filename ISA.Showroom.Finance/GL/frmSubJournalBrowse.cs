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
    public partial class frmSubJournalBrowse : ISA.Controls.BaseForm
    {
        int prevRow1 = -1;
        int prevRow2 = -1;

        Guid _JournalID;
        int selectedGrid = 0;
        public frmSubJournalBrowse(Guid journalID)
        {
            InitializeComponent();
            _JournalID = journalID;
        }

        private void RefreshHeader()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    dt = Class.Journal.ListDetail(db, _JournalID);
                }
                dt.DefaultView.Sort = "RecordID";
                customGridView1.DataSource = dt.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show("Refresh Header \n " +ex.Message, "Error"); }
        }

        private void RefreshSubJournal()
        {
            try
            {
                if (customGridView1.SelectedCells.Count > 0)
                {
                    Guid jDetailRowID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());

                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBHoldingName))
                    {
                        dt = Class.Journal.ListSubJournalHeader(db, jDetailRowID);
                    }
                    dt.DefaultView.Sort = "RecordID";
                    customGridView2.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show("Refresh SubJournal \n " + ex.Message); }
        }

        private void RefreshSubJournalDetail()
        {
            try
            {
                if (customGridView2.SelectedCells.Count > 0)
                {
                    Guid subhRowID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["subhRowID"].Value.ToString());

                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBHoldingName))
                    {
                        dt = Class.Journal.ListSubJournalDetail(db, subhRowID);
                    }
                    dt.DefaultView.Sort = "RecordID";
                    customGridView3.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show("Refresh JournalDetail \n "+ ex.Message); }
        }

        public void RefreshRowHeader(string rowID)
        {
            Guid _rowID = new Guid(rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    dtRefresh = Class.Journal.GetHeader(db, _rowID, GlobalVar.PerusahaanRowID);
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    customGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {            
            if (selectedGrid==2 && customGridView1.SelectedCells.Count > 0)
            {
                Guid _jdetailID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                frmSubJournalUpdate ifrmChild = new frmSubJournalUpdate(_jdetailID);  
                ifrmChild.ShowDialog();
            }

            if (selectedGrid == 3 && customGridView2.SelectedCells.Count > 0)
            {
                Guid _subhID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["subhRowID"].Value.ToString());
                frmSubJournalDetailUpdate ifrmChild = new frmSubJournalDetailUpdate(_subhID);
                ifrmChild.ShowDialog();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (selectedGrid == 2 && customGridView1.SelectedCells.Count > 0)
            {
                Guid _jdetailID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                GL.frmSubJournalUpdate ifrmChild = new GL.frmSubJournalUpdate(_jdetailID);
                ifrmChild.ShowDialog();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (selectedGrid == 2 && customGridView2.SelectedCells.Count > 0)
            {
                Guid _dRowID = new Guid(customGridView2.SelectedCells[0].OwningRow.Cells["dRowID"].Value.ToString());
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    Class.Journal.DeleteSubJournalHeader(db, _dRowID);
                }

                DataRowView vw =(DataRowView) customGridView2.SelectedCells[0].OwningRow.DataBoundItem;
                vw.Row.Delete();
                MessageBox.Show(Messages.Confirm.DeleteSuccess);
            }
            else if (customGridView3.SelectedCells.Count > 0 && selectedGrid == 3)
            {
                Guid _dRowID = new Guid(customGridView3.SelectedCells[0].OwningRow.Cells["dRowID"].Value.ToString());
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    Class.Journal.DeleteSubJournalHeader(db, _dRowID);
                }

                DataRowView vw = (DataRowView)customGridView3.SelectedCells[0].OwningRow.DataBoundItem;
                vw.Row.Delete();
                MessageBox.Show(Messages.Confirm.DeleteSuccess);
            }
        }

        private void customGridView2_Enter(object sender, EventArgs e)
        {
            selectedGrid = 2;
        }

        private void customGridView3_Enter(object sender, EventArgs e)
        {
            selectedGrid = 3;
        }

        private void frmSubJournalBrowse_Load(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID == "HLD")
            {
                cmdAdd.Enabled = false;
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = false;
            }
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (prevRow1 != customGridView1.SelectedCells[0].OwningRow.Index)
                {
                    prevRow1 = customGridView1.SelectedCells[0].OwningRow.Index;
                    RefreshSubJournal();
                }
            }
        }

        private void customGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView2.SelectedCells.Count > 0)
            {
                if (prevRow2 != customGridView2.SelectedCells[0].OwningRow.Index)
                {
                    prevRow2 = customGridView2.SelectedCells[0].OwningRow.Index;
                    RefreshSubJournalDetail();
                }
            }
        }

        private void frmSubJournalBrowse_Shown(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void customGridView1_Click(object sender, EventArgs e)
        {
            selectedGrid = 1;
        }

        private void customGridView2_Click(object sender, EventArgs e)
        {
            selectedGrid = 2;
        }

        private void customGridView3_Click(object sender, EventArgs e)
        {
            selectedGrid = 3;
        }


    }
}
