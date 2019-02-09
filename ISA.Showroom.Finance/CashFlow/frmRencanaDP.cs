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
    public partial class frmRencanaDP : ISA.Controls.BaseForm
    {
        #region Var

        DataTable dtH = new DataTable(), dtD = new DataTable(), dtV = new DataTable(), dtR = new DataTable();
        DataTable dtS = new DataTable();


        #endregion

        #region Procedure & Funtion

        private void InitVendor()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    dtV = db.Commands[0].ExecuteDataTable();
                }
                dtV.DefaultView.RowFilter = "TipeVendor=1 AND IsAktif=true";
                dtV.DefaultView.Sort = "NamaVendor";
                GVHeader.DataSource = dtV.DefaultView.ToTable();
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

        private void InitRencana(Guid RowID_, int Year_, int Month_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranUangMuka_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Year_));
                    db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, Month_));
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

        public void InitDataRencana(Guid RowID_, int Year_, int Month_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("CF_RencanaPembayaranUangMuka"));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Year_));
                    db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, Month_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].ExecuteNonQuery();
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
                        ctr.Format = "#,##0";
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
            DataRow[] dr = dt.Select("MataUangID='" + Filter + "'");

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

                //if (GlobalVar.PerusahaanID == "SAP")
                //{
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranDPHeader_List]"));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, dt1));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, dt2));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        dtH = db.Commands[0].ExecuteDataTable();
                    }
                //}
                //else
                //{ 
                //  using (Database db = new Database(GlobalVar.DBName))
                //    {
                //        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranHutangPabrikHeader_List]"));
                //        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID_));
                //        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, dt1));
                //        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, dt2));
                //        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                //        dtH = db.Commands[0].ExecuteDataTable();
                //    }
                //}

               

                dtH.DefaultView.Sort = "TglPL DESC";
                GVPL.DataSource = dtH.DefaultView;

                if (GVPL.SelectedCells.Count > 0)
                {

                    Guid _PL = (Guid)GVPL.SelectedCells[0].OwningRow.Cells["PLRowID"].Value;
                    Guid _MU = (Guid)GVPL.SelectedCells[0].OwningRow.Cells["MataUangRowID"].Value;

                    InitRencanaDetail(VendorRowID_, _MU, _PL);

                }
                else
                {
                    dtD.Rows.Clear();
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

        private void InitRencanaDetail(Guid VendorRowID_, Guid MataUangRowID_, Guid PLRowID_)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranUangMukaDetail_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@POrowID", SqlDbType.UniqueIdentifier, PLRowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtD = db.Commands[0].ExecuteDataTable();
                }

                dtD.DefaultView.Sort = "TanggalRencana DESC";
                GVRencana.DataSource = dtD.DefaultView;

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
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranUangMukaDetail_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {

                GVRencana.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID_.ToString());
                GVRencana.FindRow("RowID3", RowID_.ToString());
                dtD.AcceptChanges();

                DataRowView dv = (DataRowView)GVPL.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.BeginEdit();
                dr["SaldoUSD"] = Convert.ToDouble(dr["NominalUSD"]) - Convert.ToDouble(dtD.Compute("SUM(USDNominal)", ""));
                dr["SaldoIDR"] = Convert.ToDouble(dr["NominalIDR"]) - Convert.ToDouble(dtD.Compute("SUM(IDRNominal)", ""));
                GVPL.SelectedCells[0].OwningRow.Cells["SaldoUSD"].Value = dr["SaldoUSD"];
                GVPL.SelectedCells[0].OwningRow.Cells["SaldoIDR"].Value = dr["SaldoIDR"];
                dr.EndEdit();
                dr.AcceptChanges();
                
                dtH.AcceptChanges();
                
                GVPL.RefreshEdit();
              
            }

        }


     


        private void Delete(Guid ROwID_)
        {


            string NoBukti = GVRencana.SelectedCells[0].OwningRow.Cells["TanggalRencana"].Value.ToString();
            if (MessageBox.Show("Hapus Rencana Tanggal  " + NoBukti + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranUangMukaDetail_DELETE]"));
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
                    dtD.AcceptChanges();
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
                         dv = (DataRowView)GVPL.SelectedCells[0].OwningRow.DataBoundItem;
                          dr = dv.Row;
                        dr.BeginEdit();
                        dr["SaldoUSD"] = Convert.ToDouble(dr["NominalUSD"]) - Convert.ToDouble(dtD.Compute("SUM(USDNominal)", ""));
                        dr["SaldoIDR"] = Convert.ToDouble(dr["NominalIDR"]) - Convert.ToDouble(dtD.Compute("SUM(IDRNominal)", ""));
                        GVPL.SelectedCells[0].OwningRow.Cells["SaldoUSD"].Value = dr["SaldoUSD"];
                        GVPL.SelectedCells[0].OwningRow.Cells["SaldoIDR"].Value = dr["SaldoIDR"];
                        dr.EndEdit();
                        dr.AcceptChanges();

                        dtH.AcceptChanges();

                        GVPL.RefreshEdit();
                    }
                    else
                    {
                        dv = (DataRowView)GVPL.SelectedCells[0].OwningRow.DataBoundItem;
                        dr = dv.Row;
                        dr.BeginEdit();
                        dr["SaldoUSD"] = Convert.ToDouble(dr["NominalUSD"]);
                        dr["SaldoIDR"] = Convert.ToDouble(dr["NominalIDR"]);
                        GVPL.SelectedCells[0].OwningRow.Cells["SaldoUSD"].Value = dr["SaldoUSD"];
                        GVPL.SelectedCells[0].OwningRow.Cells["SaldoIDR"].Value = dr["SaldoIDR"];
                        dr.EndEdit();
                        dr.AcceptChanges();

                        dtH.AcceptChanges();

                        GVPL.RefreshEdit();
                    }
                   

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void Delete2(Guid ROwID_)
        {


            string NoBukti = GVSubDetail.SelectedCells[0].OwningRow.Cells["TglRencana"].Value.ToString();
            if (MessageBox.Show("Hapus Rencana Tanggal  " + NoBukti + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranUangMukaSubDetail_DELETE]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, ROwID_));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    int i = 0;
                    int n = 0;
                    i = GVSubDetail.SelectedCells[0].RowIndex;
                    n = GVSubDetail.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)GVSubDetail.SelectedCells[0].OwningRow.DataBoundItem;
                    DataRow dr = dv.Row;
                    dr.Delete();
                    dtS.AcceptChanges();
                    GVSubDetail.Focus();
                    if (GVRencana.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            GVSubDetail.CurrentCell = GVRencana.Rows[0].Cells[n];
                            GVSubDetail.RefreshEdit();
                        }
                        else
                        {
                            GVSubDetail.CurrentCell = GVRencana.Rows[i - 1].Cells[n];
                            GVSubDetail.RefreshEdit();
                        }


                        GVSubDetail.RefreshEdit();
                    }
                   


                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        #endregion

        #region Tab 3

        private void InitDP(int Year, int Month,  Guid VendorRowID_)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (GlobalVar.PerusahaanID == "SAP")
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranUangMukaSubDetail_List]"));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@year", SqlDbType.Int, Year));
                        db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int , Month));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        dtS = db.Commands[0].ExecuteDataTable();
                    }
                }
                else
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranUangMukaSubDetail_List"));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@year", SqlDbType.Int, Year));
                        db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, Month));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        dtS = db.Commands[0].ExecuteDataTable();
                    }
                }



                dtS.DefaultView.Sort = "TglRencana DESC";
                GVSubDetail.DataSource = dtS.DefaultView;

              

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

        public void RefreshRowDataGridDetail2(Guid RowID_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranUangMukaSubDetail_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {


                GVSubDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID_.ToString());
                GVSubDetail.FindRow("RowIDSubDetail", RowID_.ToString());
                dtD.AcceptChanges();

                DataRowView dv = (DataRowView)GVSubDetail.SelectedCells[0].OwningRow.DataBoundItem;
                dtS.AcceptChanges();

                GVSubDetail.RefreshEdit();

            }

        }
        #endregion


        #endregion


        public frmRencanaDP()
        {
            InitializeComponent();
        }

        private void frmRencanaDP_Load(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID != "SAP" && GlobalVar.PerusahaanID != "PBR")
            {
                this.Close();
                return;
            }

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
                Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
                InitLayoutRencana();
                InitRencana(VendorRowID_, monthYearBox1.Year, monthYearBox1.Month);
            }

        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbUSD_CheckedChanged(object sender, EventArgs e)
        {
            InitLayoutRencana();
            if (GVHeader.SelectedCells.Count > 0)
            {
                Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
                InitLayoutRencana();
                InitRencana(VendorRowID_, monthYearBox1.Year, monthYearBox1.Month);
            }
        }

        private void rbIDR_CheckedChanged(object sender, EventArgs e)
        {
            InitLayoutRencana();
            if (GVHeader.SelectedCells.Count > 0)
            {
                Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
                InitLayoutRencana();
                InitRencana(VendorRowID_, monthYearBox1.Year, monthYearBox1.Month);
            }
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
                    Guid _VD = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
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
                    Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
                    InitLayoutRencana();
                    InitRencana(VendorRowID_, monthYearBox1.Year, monthYearBox1.Month);
                    if (tabControl1.SelectedIndex == 1)
                    {
                        cmdSearch.PerformClick();
                    }
                    else if (tabControl1.SelectedIndex == 2)
                    {
                         

                            InitDP(monthYearBox1.Year, monthYearBox1.Month, VendorRowID_);
                         
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GVPL_SelectionChanged(object sender, EventArgs e)
        {
            if (GVPL.SelectedCells.Count > 0 && GVHeader.SelectedCells.Count > 0)
            {
                try
                {
                    Guid _VD = (Guid)GVPL.SelectedCells[0].OwningRow.Cells["VendorRowID2"].Value;
                    Guid _PL = (Guid)GVPL.SelectedCells[0].OwningRow.Cells["PLRowID"].Value;
                    Guid _MU = (Guid)GVPL.SelectedCells[0].OwningRow.Cells["MataUangRowID"].Value;

                    InitRencanaDetail(_VD, _MU, _PL);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                dtD.Rows.Clear();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (GVPL.SelectedCells.Count > 0  )
            {

                string rowID_ = GVPL.SelectedCells[0].OwningRow.Cells["PLRowID"].Value.ToString();
                string MT_ = GVPL.SelectedCells[0].OwningRow.Cells["MataUangRowID"].Value.ToString();
                DataRow[] dr = dtH.Select("RowID='" + rowID_ + "' ");

                frmRencanaDPUpdate ifrmChild = new frmRencanaDPUpdate(this, dr[0]);
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
                ifrmChild.ShowDialog();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (GVPL.SelectedCells.Count > 0 && GVRencana.SelectedCells.Count>0)
            {

                string rowID_ = GVPL.SelectedCells[0].OwningRow.Cells["PLRowID"].Value.ToString();
                string rowIDX_ = GVRencana.SelectedCells[0].OwningRow.Cells["RowID3"].Value.ToString();
                string MT_ = GVPL.SelectedCells[0].OwningRow.Cells["MataUangRowID"].Value.ToString();
                DataRow[] dr = dtH.Select("RowID='" + rowID_ + "' ");
                DataRow[] dr2 = dtD.Select("RowID='" + rowIDX_ + "' ");

                frmRencanaDPUpdate ifrmChild = new frmRencanaDPUpdate(this, dr[0], dr2[0]);
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
                ifrmChild.ShowDialog();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (GVPL.SelectedCells.Count > 0 && GVRencana.SelectedCells.Count > 0)
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
                    Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;

                    InitRencana(VendorRowID_, monthYearBox1.Year, monthYearBox1.Month);
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (GVHeader.SelectedCells.Count > 0)
                {
                    Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;

                    InitDP(monthYearBox1.Year, monthYearBox1.Month, VendorRowID_);
                }
            
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void commandButton5_Click(object sender, EventArgs e)
        {
            if (GVHeader.SelectedCells.Count > 0)
            {

                string rowID_ = GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value.ToString();

                DataRow[] dr = dtV.Select("RowID='" + rowID_ + "' ");

                frmRencanaDPUpdate_2 ifrmChild = new frmRencanaDPUpdate_2(this, dr[0]);
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
                ifrmChild.ShowDialog();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            if (GVSubDetail.SelectedCells.Count > 0 && GVHeader.SelectedCells.Count > 0)
            {

               
                string rowIDX_ = GVSubDetail.SelectedCells[0].OwningRow.Cells["RowIDSubDetail"].Value.ToString();
  
                DataRow[] dr2 = dtS.Select("RowID='" + rowIDX_ + "' ");

                string rowID_ = GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value.ToString();

                DataRow[] dr = dtV.Select("RowID='" + rowID_ + "' ");

                frmRencanaDPUpdate_2 ifrmChild = new frmRencanaDPUpdate_2(this, dr[0], dr2[0]);
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
                ifrmChild.ShowDialog();
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (GVSubDetail.SelectedCells.Count > 0 )
            {


                string rowIDX_ = GVSubDetail.SelectedCells[0].OwningRow.Cells["RowIDSubDetail"].Value.ToString();

                Delete2(new Guid(rowIDX_));
            }
            else { MessageBox.Show(Messages.Error.RowNotSelected); }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
