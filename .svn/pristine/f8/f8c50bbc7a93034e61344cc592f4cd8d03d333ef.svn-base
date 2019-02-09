using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmRencanaCash_Global : ISA.Controls.BaseForm
    {
        #region Var

        DataTable dtH = new DataTable(), dtD = new DataTable(), dtV = new DataTable(), dtR = new DataTable();


        #endregion

        #region Procedure & Funtion

        private void InitVendor()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaGlobal_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtV = db.Commands[0].ExecuteDataTable();
                }
                GVHeader.DataSource = dtV.DefaultView.ToTable();
                if (GVHeader.SelectedCells.Count > 0)
                {
                    Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    InitLayoutRencana();
                    InitRencana(VendorRowID_, monthYearBox1.FirstDateOfMonth, monthYearBox1.LastDateOfMonth);
                    if (tabControl1.SelectedIndex == 1)
                    {
                        cmdSearch.PerformClick();
                    }
                }
                else { 
                
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void InitRencana(Guid RowID_, DateTime FromDAte_, DateTime ToDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaGlobal_Summary]"));
                    if (RowID_ != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@CF_HeaderID", SqlDbType.UniqueIdentifier, RowID_));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, FromDAte_));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtR = db.Commands[0].ExecuteDataTable();
                }
                InitLayoutRencana();
                FillRencana(dtR);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void InitLayoutRencana()
        {

            foreach (Control ctrX in panel1.Controls)
            {
                if (ctrX is Label)
                {
                    ctrX.Visible = true;
                }
                if (ctrX is ISA.Controls.NumericTextBox)
                {
                    ISA.Controls.NumericTextBox ctr = (ISA.Controls.NumericTextBox)ctrX;
                    ctr.ReadOnly = true;
                    ctr.Visible = true;
                    ctr.Enabled = true;
                    ctr.Text = "0";
                    if (rbUSD.Checked)
                    {
                        ctr.Format = "N4";
                    }
                    else
                    {
                        ctr.Format = "N2";
                    }
                    int D = Convert.ToInt32(ctr.Name.Replace("n", ""));
                    int x = 0;
                    x = D - 1;
                    if (monthYearBox1.FirstDateOfMonth.AddDays(x).DayOfWeek == DayOfWeek.Sunday)
                    {
                        ctr.Enabled = false;

                    }
                    if (D > 28 && D > monthYearBox1.LastDateOfMonth.Day)
                    {
                        switch (D)
                        {
                            case 29:
                                label9.Visible = false;
                                n29.Visible = false;
                                break;
                            case 30:
                                label10.Visible = false;
                                n30.Visible = false;
                                break;
                            case 31:
                                label18.Visible = false;
                                n31.Visible = false;
                                break;
                        }

                    }
                }
            }
        }

        private void FillRencana(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string Filter = rbUSD.Checked ? "USD" : "IDR";
            DataRow[] dr = dt.Select("");

            foreach (Control ctrX in panel1.Controls)
            {
                if (ctrX is ISA.Controls.NumericTextBox)
                {
                    ISA.Controls.NumericTextBox ctr = (ISA.Controls.NumericTextBox)ctrX;

                    int D = Convert.ToInt32(ctr.Name.Replace("n", ""));
                    string drName = "D" + Tools.Right("00" + D.ToString(), 2);

                    ctr.Text = dr[0][drName].ToString();


                }
            }

        }

        #region Tab 2

        private void InitInvoice(DateTime dt1, DateTime dt2, Guid VendorRowID_)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

              
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaGlobal_Detail]"));
                        if (VendorRowID_ != Guid.Empty)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@CF_HEaderID", SqlDbType.UniqueIdentifier, VendorRowID_));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, dt1));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, dt2));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        dtH = db.Commands[0].ExecuteDataTable();
                    }
              

               

                dtH.DefaultView.Sort = "Tanggal DESC";
                GVRencana.DataSource = dtH.DefaultView;

               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void RefreshRowDataGridDetail(Guid RowID_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaGlobal_Detail"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {

                GVRencana.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID_.ToString());
                GVRencana.FindRow("RowID3", RowID_.ToString());
                dtD.AcceptChanges();
              
            }

        }

        private void Delete(Guid ROwID_)
        {


            string NoBukti_ = Convert.ToDateTime( GVRencana.SelectedCells[0].OwningRow.Cells["TanggalRencana"].Value).ToString("dd-MM-yyyy");
            if (MessageBox.Show("Hapus Rencana Tanggal  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaGlobal_Detail_DELETE]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, ROwID_));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    int i = 0;
                    int n = 0;
                    i = GVRencana.SelectedCells[0].RowIndex;
                    n = GVRencana.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)GVRencana.SelectedCells[0].OwningRow.DataBoundItem;
                    DataRow dr = dv.Row;
                    dr.Delete();
                    dtH.AcceptChanges();
                    GVRencana.Focus();
                    if (GVRencana.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            GVRencana.CurrentCell = GVRencana.Rows[0].Cells[n];
                            GVRencana.RefreshEdit();
                        }
                        else
                        {
                            GVRencana.CurrentCell = GVRencana.Rows[i - 1].Cells[n];
                            GVRencana.RefreshEdit();
                        }
                    
                    }
                    else
                    {
                       
                    }
                   

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        #endregion

        #endregion


        public frmRencanaCash_Global()
        {
            InitializeComponent();
        }

        private void frmRencanaCash_Global_Load(object sender, EventArgs e)
        {

            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            fromDate.DateValue = monthYearBox1.FirstDateOfMonth;
            toDate.DateValue = monthYearBox1.LastDateOfMonth;
            InitLayoutRencana();
            InitVendor();


        }

        private void monthYearBox1_Validated(object sender, EventArgs e)
        {
            fromDate.DateValue = monthYearBox1.FirstDateOfMonth;
            toDate.DateValue = monthYearBox1.LastDateOfMonth;
            fromDate.DateValue = monthYearBox1.FirstDateOfMonth;
            toDate.DateValue = monthYearBox1.LastDateOfMonth;
            dtH.Rows.Clear();
            dtD.Rows.Clear();
            if (GVHeader.SelectedCells.Count > 0)
            {
                Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                InitLayoutRencana();
                InitRencana(VendorRowID_, monthYearBox1.FirstDateOfMonth, monthYearBox1.LastDateOfMonth);
            }

        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            if (!fromDate.DateValue.HasValue)
            {
                err.SetError(fromDate, "Required !!!");
                return;
            }

            if (!toDate.DateValue.HasValue)
            {
                err.SetError(toDate, "Required !!!");
                return;
            }
            try
            {

                if (GVHeader.SelectedCells.Count > 0)
                {
                    Guid _VD = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    InitInvoice(fromDate.DateValue.Value, toDate.DateValue.Value, _VD);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GVHeader_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                InitLayoutRencana();
                dtH.Rows.Clear();
                dtD.Rows.Clear();
                if (GVHeader.SelectedCells.Count > 0)
                {
                    Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    InitLayoutRencana();
                    InitRencana(VendorRowID_, monthYearBox1.FirstDateOfMonth, monthYearBox1.LastDateOfMonth);
                    if (tabControl1.SelectedIndex == 1)
                    {
                        cmdSearch.PerformClick();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

 

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (GVHeader.SelectedCells.Count > 0)
            {

                Guid rowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                if (rowID_.Equals(Guid.Empty))
                {
                    return;
                }
               
                DataRow[] dr = dtV.Select("RowID='" + rowID_.ToString() + "'  ");

                frmRencanaCashUpdateGlobal ifrmChild = new frmRencanaCashUpdateGlobal(this, dr[0]);
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
                ifrmChild.ShowDialog();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (GVHeader.SelectedCells.Count > 0 && GVRencana.SelectedCells.Count > 0)
            {

                Guid rowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string rowIDX_ = GVRencana.SelectedCells[0].OwningRow.Cells["RowID3"].Value.ToString();
               
                DataRow[] dr = dtV.Select("RowID='" + rowID_ + "'  ");
                DataRow[] dr2 = dtH.Select("RowID='" + rowIDX_ + "' ");

                frmRencanaCashUpdateGlobal ifrmChild = new frmRencanaCashUpdateGlobal(this, dr[0], dr2[0]);
                //ifrmChild.MdiParent = Program.MainFormfrmRencanaCashUpdateGlobal
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
                ifrmChild.ShowDialog();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (GVRencana.SelectedCells.Count > 0)
            {


                string rowIDX_ = GVRencana.SelectedCells[0].OwningRow.Cells["RowID3"].Value.ToString();

                Delete(new Guid(rowIDX_));
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                InitLayoutRencana();
                if (GVHeader.SelectedCells.Count > 0)
                {
                    Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    InitRencana(VendorRowID_, monthYearBox1.FirstDateOfMonth, monthYearBox1.LastDateOfMonth);
                }
            }
        }

     

        
    }
}
