using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmJournalBrowse : ISA.Controls.BaseForm
    {
        int prevRow = -1;
        Boolean IsHLD = GlobalVar.PerusahaanID == "HLD";
        public frmJournalBrowse()
        {
            InitializeComponent();
        }

        private void frmJournalBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1).AddMonths(1).AddDays(-1);
            setCboCabang();
            RefreshHeader();
            RefreshDetail();
            cmdAdd.Enabled = !IsHLD;
            cmdEdit.Enabled = !IsHLD;
            cmdDelete.Enabled = !IsHLD;

            // dibuat hanya jurnal yang tipe Src nya 'GNR' yang bisa Edit dan Delete
            // buat default kedisable dulu
            cmdEdit.Enabled = false;
            cmdDelete.Enabled = false;

            if (GlobalVar.CabangID == "06A")
            {
                cmdGenerate.Visible = true;
            }
        }

        private void setCboCabang()
        {

            Dictionary<string,string> dta = new   Dictionary<string,string>();

            dta.Add("ALL", "ALL");
            dta.Add("HONDA", "HONDA");
            dta.Add("AVALIS", "AVALIS");
            dta.Add("AHASS", "AHASS");


            cboCabang.DataSource = new BindingSource(dta,null);
            cboCabang.DisplayMember = "Value";
            cboCabang.ValueMember = "Key";
        }

        private void RefreshHeader()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    if (GlobalVar.CabangID.ToUpper().Trim().Contains("06A"))
                    {
                        dt = Journal.ListHeaderbyCabang(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, cboCabang.SelectedValue.ToString());
                    }
                    else
                    {
                        dt = Journal.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                    }
                    ////dt = Journal.ListHeader(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate);
                    //dt = Journal.ListHeaderbyCabang(db, (DateTime)rangeDateBox1.FromDate, (DateTime)rangeDateBox1.ToDate, cboCabang.SelectedValue.ToString());
                }
                dt.DefaultView.Sort = "Tanggal desc, LastUpdatedTime desc, NoReff";
                customGridView1.DataSource = dt.DefaultView;
                //customGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    dtRefresh = Journal.GetHeader(db, _rowID, GlobalVar.PerusahaanRowID);
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

        private void RefreshDetail()
        {
            try 
            { 
                DataTable dt = new DataTable();
                String headerSrc;
                Guid headerID;

                if (customGridView1.SelectedCells.Count > 0)
                {
                    headerID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                    headerSrc = customGridView1.SelectedCells[0].OwningRow.Cells["hSrc"].Value.ToString();
                    cmdEdit.Enabled = false;
                    cmdDelete.Enabled = false;

                    if (headerSrc == "GNR") // kalo Src nya GNR baru boleh edit dan delete
                    {
                        cmdEdit.Enabled = true;
                        cmdDelete.Enabled = true;
                    }
                }
                else
                {
                    headerID = new Guid();
                    cmdEdit.Enabled = false;
                    cmdDelete.Enabled = false;
                }
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    if (GlobalVar.CabangID.ToUpper().Trim().Contains("06A"))
                    {
                        dt = Journal.ListDetailbyCabang(db, headerID, cboCabang.SelectedValue.ToString());
                    }
                    else
                    {
                        dt = Journal.ListDetail(db, headerID);
                    }
                    ////dt = Journal.ListDetail(db, headerID);
                    //dt = Journal.ListDetailbyCabang(db, headerID, cboCabang.SelectedValue.ToString());
                }

                dt.DefaultView.Sort = "Dk, NoPerkiraan, Uraian";
                customGridView2.DataSource = dt.DefaultView;

                
                //customGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // bolehin edit terus selalu dulu
                //cmdEdit.Enabled = true;
                //cmdDelete.Enabled = true;
                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            
        }

        public void FindRow(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetail();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
             
            if (customGridView1.SelectedCells.Count > 0)
            {
                DateTime tglJournal = (DateTime)customGridView1.SelectedCells[0].OwningRow.Cells["hTanggal"].Value;
                string kodeGudang = customGridView1.SelectedCells[0].OwningRow.Cells["hKodeGudang"].Value.ToString();
                string periode = tglJournal.ToString("yyyyMM");
                if (!Class.PeriodeClosing.IsGLClosed(periode, kodeGudang))
                {
                    if (MessageBox.Show("Hapus header record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Guid rowID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                        using (Database db = new Database(GlobalVar.DBHoldingName))
                        {
                            Journal.DeleteHeader(db, rowID);
                            Journal.DeleteDetail(db, rowID);
                        }
                        MessageBox.Show("Berhasil Dihapus", "Informasi");
                        RefreshHeader();
                        RefreshDetail();
                    }
                }
                else
                {
                    MessageBox.Show("Sudah Clossing", "Informasi");
                }

            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                DateTime tglJournal = (DateTime)customGridView1.SelectedCells[0].OwningRow.Cells["hTanggal"].Value;
                string kodeGudang = customGridView1.SelectedCells[0].OwningRow.Cells["hKodeGudang"].Value.ToString();
                string periode = tglJournal.ToString("yyyyMM");
                if (!Class.PeriodeClosing.IsGLClosed(periode, kodeGudang))
                {
                    GL.frmJournalUpdate ifrmChild = new GL.frmJournalUpdate(this,cboCabang.SelectedValue.ToString());
                    ifrmChild.MdiParent = this.MdiParent;
                    ifrmChild.Show();
                    ifrmChild.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    MessageBox.Show("Sudah Closing", "Informasi");
                }
            }
            else
            {
                GL.frmJournalUpdate ifrmChild = new GL.frmJournalUpdate(this, cboCabang.SelectedValue.ToString());
                ifrmChild.MdiParent = this.MdiParent;
                ifrmChild.Show();
                ifrmChild.WindowState = FormWindowState.Maximized;
            }
            

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                DateTime tglJournal = (DateTime)customGridView1.SelectedCells[0].OwningRow.Cells["hTanggal"].Value;
                string kodeGudang = customGridView1.SelectedCells[0].OwningRow.Cells["hKodeGudang"].Value.ToString();
                string periode = tglJournal.ToString("yyyyMM");
                if (!Class.PeriodeClosing.IsGLClosed(periode, kodeGudang))
                {
                    Guid rowID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                    string recID = customGridView1.SelectedCells[0].OwningRow.Cells["hRecordID"].Value.ToString();

                    GL.frmJournalUpdate ifrmChild = new GL.frmJournalUpdate(this, rowID, recID,cboCabang.SelectedValue.ToString());
                    ifrmChild.MdiParent = this.MdiParent;
                    ifrmChild.Show();
                    ifrmChild.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    MessageBox.Show("Sudah Closing", "Informasi");
                }

                
            }
        }

        private void customGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == customGridView1.Columns["hSyncFlag"].Index)
            {
                if (customGridView1.Rows[e.RowIndex].Cells["hDebet"].Value.ToString() != customGridView1.Rows[e.RowIndex].Cells["hKredit"].Value.ToString())
                {
                    customGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    customGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }



        private void customGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int nSubj=0;
                int.TryParse (customGridView2.Rows[e.RowIndex].Cells["dNSubJournal"].Value.ToString(), out nSubj);
               
                if (nSubj >0)
                {
                    customGridView2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void cmdSubJournal_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid _jid = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                frmSubJournalBrowse ifrmChild = new frmSubJournalBrowse(_jid);
                ifrmChild.MdiParent = this.MdiParent;
                ifrmChild.Show();
                ifrmChild.WindowState = FormWindowState.Maximized;
            }
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customGridView2_SelectionChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    String headerSrc;
            //    Guid headerID;

            //    if (customGridView1.SelectedCells.Count > 0 && customGridView2.SelectedCells.Count > 0)
            //    {
            //        headerID = new Guid(customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
            //        headerSrc = customGridView1.SelectedCells[0].OwningRow.Cells["hSrc"].Value.ToString();
            //        String dNoPerkiraan = customGridView2.SelectedCells[0].OwningRow.Cells["dNoPerkiraan"].Value.ToString();
            //        String dNamaPerkiraan = customGridView2.SelectedCells[0].OwningRow.Cells["dNamaPerkiraan"].Value.ToString();
            //        cmdEdit.Enabled = false;
            //        cmdDelete.Enabled = false;

            //        if (headerSrc == "GNR") // kalo Src nya GNR baru boleh edit dan delete
            //        {
            //            cmdEdit.Enabled = true;
            //            cmdDelete.Enabled = true;
            //        }
            //        else if (String.IsNullOrEmpty(dNoPerkiraan.Trim()) || String.IsNullOrEmpty(dNamaPerkiraan.Trim()))
            //        {
            //            cmdEdit.Enabled = true;
            //        }
            //    }
            //    else
            //    {
            //        headerID = new Guid();
            //        cmdEdit.Enabled = false;
            //        cmdDelete.Enabled = false;
            //    }

            //    // bolehin edit dulu
            //    cmdEdit.Enabled = true;
            //    cmdDelete.Enabled = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;

            pnlData.Visible = true;
            pnlData.BringToFront();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            pnlData.Visible = false;
            pnlData.SendToBack();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                monthYearBox1.Enabled = false;
                cmdYes.Enabled = false;
                cmdNo.Enabled = false;
                tableLayoutPanel1.Enabled = false;
                //cmdClose.Enabled = false;
                //cmdAdd.Enabled = false;
                //cmdEdit.Enabled = false;
                //cmdSubJournal.Enabled = false;
                //cboCabang.Enabled = false;

                backgroundWorker1.RunWorkerAsync();

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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            monthYearBox1.Enabled = true;
            cmdYes.Enabled = true;
            cmdNo.Enabled = true;
            tableLayoutPanel1.Enabled = true;

            MessageBox.Show("Proses Generate Succes");
            pnlData.Visible = false;
        }

        void ProsesGenerate()
        {
            using (Database db = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Split_JOURNAL"));
                this.Invoke((MethodInvoker)delegate()
                {
                    db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, monthYearBox1.FirstDateOfMonth.Date));
                    db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, monthYearBox1.LastDateOfMonth.Date));
                    db.Commands[0].Parameters.Add(new Parameter("@isUser", SqlDbType.VarChar, SecurityManager.UserID));
                });
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           ProsesGenerate();
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (prevRow != customGridView1.SelectedCells[0].RowIndex)
                {
                    prevRow = customGridView1.SelectedCells[0].RowIndex;
                    RefreshDetail();
                }
            }
        }

        private void customGridView2_SelectionRowChanged(object sender, EventArgs e)
        {
            
        }

        private void customGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView2.Rows.Count > 0)
            {
                if (Tools.isNull(customGridView2.SelectedCells[0].OwningRow.Cells["dNoPerkiraan"].Value, "").ToString() == "")
                {
                    cmdEdit.Enabled = true;
                    cmdDelete.Enabled = true;
                }
            }
        }
    }
}
