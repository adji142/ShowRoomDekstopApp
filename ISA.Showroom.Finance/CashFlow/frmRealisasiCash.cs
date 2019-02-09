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
    public partial class frmRealisasiCash : ISA.Controls.BaseForm
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
                    db.Commands.Add(db.CreateCommand("usp_Vendor_LIST"));
                    dtV = db.Commands[0].ExecuteDataTable();
                }
                dtV.DefaultView.RowFilter = " IsAktif=true";
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
            string Filter = rbUSD.Checked ? "USD" : (rbCNY.Checked ? "CNY" : "IDR");
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

        private void InitRencana(Guid RowID_, int Year_, int Month_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_CF_RealisasiPembayaranHutang_List]"));
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

        private void GetRealisasi(Guid RowID_, DateTime fromDate, DateTime ToDAte)
        {
            try
            {


                this.Cursor = Cursors.WaitCursor;
                if (GlobalVar.PerusahaanID == "SAP")
                {

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RealisasiPembayaranHutang_REfresh_ALL]"));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDAte));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                else
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_CF_RealisasiPembayaranHutangPabrik_REfresh_ALL]"));
                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, ToDAte));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                InitRencana(RowID_, fromDate.Year, fromDate.Month);
                MessageBox.Show("Selesai");
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
       
        #endregion


        public frmRealisasiCash()
        {
            InitializeComponent();
        }

        private void frmRealisasiCash_Load(object sender, EventArgs e)
        {
            if (GlobalVar.PerusahaanID != "SAP" && GlobalVar.PerusahaanID != "PBR")
            {
                this.Close();
                return;
            }
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            InitLayoutRencana();
            InitVendor();

        }

        private void monthYearBox1_Validated(object sender, EventArgs e)
        {
            
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
           
        }

        private void rbCNY_CheckedChanged(object sender, EventArgs e)
        {
            InitLayoutRencana();
            if (GVHeader.SelectedCells.Count > 0)
            {
                Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
                InitLayoutRencana();
                InitRencana(VendorRowID_, monthYearBox1.Year, monthYearBox1.Month);
            }
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
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            InitLayoutRencana();
            if (GVHeader.SelectedCells.Count > 0)
            {
                Guid VendorRowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["VendorRowID"].Value;
                InitLayoutRencana();
                GetRealisasi(VendorRowID_, monthYearBox1.FirstDateOfMonth, monthYearBox1.LastDateOfMonth);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

       
    }
}
