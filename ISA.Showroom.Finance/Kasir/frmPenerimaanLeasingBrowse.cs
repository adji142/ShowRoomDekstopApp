using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using System.Web;
using System.Globalization;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmPenerimaanLeasingBrowse : ISA.Controls.BaseForm
    {
        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;
        DataTable dtHeader;
        DataTable dtDetail;
        DataTable dtIdenNonPNJ;
        List<Guid> selectedTransRowID = new List<Guid>();
        
        //untuk memastikan cbLeasing sudah selesai diisi 
        bool v_cbLeasing = false;

        public frmPenerimaanLeasingBrowse()
        {
            InitializeComponent();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                if(dgvHAdj.Rows.Count >0)
                {
                    if (Double.Parse(dgvHAdj.SelectedCells[0].OwningRow.Cells["Sisa"].Value.ToString()) == 0)
                    {
                        MessageBox.Show("Sisa Iden 0");
                        return;
                    }
                    Guid _rowIDP = (Guid)dgvHAdj.SelectedCells[0].OwningRow.Cells["RowIDHAdj"].Value;
                    string _notrans = dgvHAdj.SelectedCells[0].OwningRow.Cells["NoTransHAdj"].Value.ToString();
                    string _customer = dgvHAdj.SelectedCells[0].OwningRow.Cells["CustomerHAdj"].Value.ToString();
                    string _sales = dgvHAdj.SelectedCells[0].OwningRow.Cells["Sales"].Value.ToString();
                    double _saldo = Double.Parse(dgvHAdj.SelectedCells[0].OwningRow.Cells["NominalPiutang"].Value.ToString());
                    double _sisa = Double.Parse(dgvHAdj.SelectedCells[0].OwningRow.Cells["Sisa"].Value.ToString());
                    DateTime _tgltr = (DateTime)dgvHAdj.SelectedCells[0].OwningRow.Cells["TglJual"].Value;

                    Kasir.frmAdjPiutang ifrmChild = new Kasir.frmAdjPiutang(this, _rowIDP,_notrans, _customer, _sales, _saldo, _sisa, _tgltr, 0);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
            }
            else
            {
                switch (dgS)
                {
                    case enumSelectedGrid.Header:
                        Keuangan.frmPenerimaanUangUpdate ifrmChild = new Keuangan.frmPenerimaanUangUpdate(this, "PiutangLsgBelumIden");
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                    case enumSelectedGrid.Detail:
                        Guid RowIDHeader = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                        Kasir.frmPenerimaanLeasingIdentifikasiPiutang ifrmChild2 = new Kasir.frmPenerimaanLeasingIdentifikasiPiutang(this, RowIDHeader);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
                        break;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenerimaanLeasingBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            btn_Search.PerformClick();
            GV_DetailNonPNJ.AutoGenerateColumns = false;
            cmdBatalIden.Enabled = true;
            cmdIdenNonPnj.Enabled = false;
            cmdAcc.Text = "ACC Iden";
            cmdAdjLaporan.Text = "Laporan ADJ";
            tabControl1_SelectedIndexChanged(new object(), new EventArgs());
        }

        public void RefreshHeader(Guid RowID)
        {
            dtHeader = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingHeader"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dtHeader = db.Commands[0].ExecuteDataTable();
            }

            GVHeader.DataSource = dtHeader;
            if (RowID != Guid.Empty)
            {
                GVHeader.FindRow("RowID", RowID.ToString());
            }
        }

        public void RefreshDetail(Guid RowID)
        {
            if (GVHeader.Rows.Count > 0)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }

                GVDetail.DataSource = dtDetail;
                if (RowID != Guid.Empty)
                {
                    GVDetail.FindRow("RowIDD", RowID.ToString());
                }
            }
            else
            {
                GVDetail.DataSource = new DataTable();
            }
        }
        
        public void RefreshDetailT2(Guid RowID)
        {
            if (GVHeader.Rows.Count > 0)
            {
                dtIdenNonPNJ = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingDetailNonPNJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    dtIdenNonPNJ = db.Commands[0].ExecuteDataTable();
                }

                GV_DetailNonPNJ.DataSource = dtIdenNonPNJ;
                if (RowID != Guid.Empty)
                {
                    GV_DetailNonPNJ.FindRow("RowIDD", RowID.ToString());
                }
            }
            else
            {
                GV_DetailNonPNJ.DataSource = new DataTable();
            }
        }

        private void RefreshHeader2(Guid RowID)
        {
            if (v_cbLeasing == true)
            {
                DataTable dtHeader2 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingTab2Header"));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)Tools.isNull(cb_Leasing.SelectedValue, Guid.Empty)));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    dtHeader2 = db.Commands[0].ExecuteDataTable();
                }
                
                GVHeader2.DataSource = dtHeader2;
                txt_SaldoPiutang.Text = dtHeader2.DefaultView.ToTable().Compute("SUM(SaldoSBD) +SUM(SaldoLSG) ","").ToString();

                if (RowID != Guid.Empty)
                {
                    GVDetail.FindRow("RowIDD", RowID.ToString());
                }
            }
        }

        private void RefreshDetail2(Guid RowID)
        {
            if (GVHeader2.Rows.Count > 0)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingTab2Detail"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GVHeader2.SelectedCells[0].OwningRow.Cells["RowID2"].Value));
                    GVDetail2.DataSource = db.Commands[0].ExecuteDataTable();
                }

                if (RowID != Guid.Empty)
                {
                    GVDetail2.FindRow("RowIDD", RowID.ToString());
                }

                SetSuratTagihan();
            }
            else
            {
                //Kosong
                GVDetail2.DataSource = new DataTable();
            }
        }

        private void RefreshHeader3()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("[usp_idenLeasing_Adj]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgvHAdj.DataSource = dt;
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                RefreshHeader(Guid.Empty);
                RefreshDetail(Guid.Empty);
                RefreshDetailT2(Guid.Empty);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                RefreshHeader2(Guid.Empty);
                RefreshDetail2(Guid.Empty);
            }
            else
            {
                RefreshHeader3();
            }
        }

        private void GVDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
        }

        private void GVHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgS = enumSelectedGrid.Header;
        }

        private void GVHeader_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
        }

        private void GVDetail_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                lbl_Leasing.Visible = true;
                lbl_SaldoPiutang.Visible = true;
                txt_SaldoPiutang.Visible = true;
                cb_Leasing.Visible = true;
                cmdPRINT.Visible = true;
                CmdRekapSaldo.Visible = true;
                cmdIdenNonPnj.Visible = true;
                CmdSuratTagihan.Visible = true;
                cmdAcc.Visible = false;
                cmdAdjLaporan.Visible = false;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                lbl_Leasing.Visible = false;
                lbl_SaldoPiutang.Visible = false;
                txt_SaldoPiutang.Visible = false;
                cb_Leasing.Visible = false;
                cmdPRINT.Visible = false;
                CmdRekapSaldo.Visible = false;
                cmdIdenNonPnj.Visible = false;
                CmdSuratTagihan.Visible = false;
                cmdAcc.Visible = true;
                cmdAdjLaporan.Visible = true;
            }
            else
            {
                lbl_Leasing.Visible = false;
                lbl_SaldoPiutang.Visible = false;
                txt_SaldoPiutang.Visible = false;
                cb_Leasing.Visible = false;
                cmdPRINT.Visible = true;
                CmdRekapSaldo.Visible = true;
                cmdIdenNonPnj.Visible = true;
                CmdSuratTagihan.Visible = false;
                cmdAcc.Visible = false;
                cmdAdjLaporan.Visible = false;
            }
        }

        private void cb_Leasing_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshHeader2(Guid.Empty);
            RefreshDetail2(Guid.Empty);
        }

        private void cb_Leasing_VisibleChanged(object sender, EventArgs e)
        {
            if (cb_Leasing.Visible == true)
            {
                v_cbLeasing = false;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    db.Commands.Add(db.CreateCommand("usp_Leasing_LIST"));
                    cb_Leasing.DataSource = db.Commands[0].ExecuteDataTable();
                    cb_Leasing.ValueMember = "RowID";
                    cb_Leasing.DisplayMember = "Nama";
                }
                v_cbLeasing = true;
                RefreshHeader2(Guid.Empty);
                //cb_Leasing.Items.Add("Semua");
            }
        }

        private void GVHeader2_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail2(Guid.Empty);
        }

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail(Guid.Empty);
            RefreshDetailT2(Guid.Empty);
        }

        private void cmdBatalIden_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                if (dgvDAdj.SelectedCells.Count > 0)
                {
                    Guid dgvHAdjRowID = new Guid(dgvHAdj.SelectedCells[0].OwningRow.Cells["RowIDHAdj"].Value.ToString());
                    string _jurnal = Tools.isNull(dgvDAdj.SelectedCells[0].OwningRow.Cells["JournalRowID"].Value, "").ToString();
                    string _src = Tools.isNull(dgvDAdj.SelectedCells[0].OwningRow.Cells["Src"].Value, "").ToString();

                    if (_src == "Batal")
                    {
                        MessageBox.Show("Data pembatalan");
                        return;
                    }

                    if (_jurnal != "")
                    {
                        MessageBox.Show("Data Sudah dijurnal");
                        return;
                    }
                    try
                    {
                        Guid _rowIDI = (Guid)dgvDAdj.SelectedCells[0].OwningRow.Cells["RowIDDAdj"].Value;
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBShowroom))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_idenLeasing_Adj_Delete]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDI));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }
                        RefreshHeader3();
                        dgvHAdj.FindRow("RowIDHAdj", dgvHAdjRowID.ToString());
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
            else
            {
                try
                {
                    DateTime TanggalUM = Convert.ToDateTime("1990-01-01");
                    Guid PenerimaanUMRowID = Guid.Empty;
                    if (tabControl1.SelectedIndex == 0)
                    {
                        if (GVDetail.Rows.Count > 0)
                        {
                            PenerimaanUMRowID = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["PenerimaanUMRowID"].Value;
                            TanggalUM = Convert.ToDateTime(Tools.isNull(GVDetail.SelectedCells[0].OwningRow.Cells["TanggalUM"].Value, "1990-01-01"));
                        }
                    }
                    //else
                    //{
                    //    if (GVDetail.Rows.Count > 0)
                    //    {
                    //        PenerimaanUMRowID = (Guid)GVDetail2.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    //    }
                    //}

                    if (tabControl1.SelectedIndex != 0 || PenerimaanUMRowID == Guid.Empty)
                    {
                        return;
                    }
                    if (TanggalUM.Date < GlobalVar.GetServerDate.AddDays(-1).Date)
                    {
                        MessageBox.Show("Sudah lebih dari 1 hari.");
                        return;
                    }

                    if (MessageBox.Show("Anda yakin ingin membatalkan iden ?", "Batal Iden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingBatalIden"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@DeletedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                        MessageBox.Show("Iden berhasil dibatalkan.");
                        RefreshDetail(Guid.Empty);
                    }

                    return;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dtHeader.Copy();
                dt.DefaultView.RowFilter = "RowID='" + GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";  

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("judul", "Laporan Penerimaan Iden Leasing"));

                List<DataTable> ListDT = new List<DataTable>();
                ListDT.Add(dt.DefaultView.ToTable());
                ListDT.Add(dtDetail);
                ListDT.Add(dtIdenNonPNJ);

                List<string> ListDS = new List<string>();
                ListDS.Add("dsPenerimaanLeasing_Header");
                ListDS.Add("dsPenerimaanLeasing_Detail");
                ListDS.Add("dsPenerimaanLeasing_IdenNonPenjualan");
                frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptPenerimaanLeasing.rdlc", rptParams, ListDT, ListDS);
                ifrmReport.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void CmdRekapSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinanceOto))
                {
                    db.Commands.Add(db.CreateCommand("[rpt_idenLSG_rekap]"));
                    db.Commands[0].Parameters.Add(new Parameter("@From", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@To", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data...");                       

                }
                else
                {
                    DisplayReport(dt);
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
        private void DisplayReport(DataTable dt)
        {
            string _userid = "Created by " + SecurityManager.UserID + " on " + DateTime.Now;
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("fromdate", rangeDateBox1.FromDate.Value.ToString("dd-MM-yyyy")));
            rptParams.Add(new ReportParameter("todate", rangeDateBox1.ToDate.Value.ToString("dd-MM-yyyy")));
            rptParams.Add(new ReportParameter("user", _userid));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.RptLSGIdenRekap.rdlc", rptParams, dt, "DsLSGIdenRekap_Data");
            ifrmReport.Show();


        }

        private void cmdIdenNonPnj_Click(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                if (double.Parse(GVHeader.SelectedCells[0].OwningRow.Cells["SALDO"].Value.ToString()) > 0)
                {
                    DataTable dt_Iden = new DataTable();
                    dt_Iden = dtHeader.Copy();
                    dt_Iden.DefaultView.RowFilter = "RowID = '" + GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                    Kasir.frmPenerimaanLeasingNonPJL ifrmChild = new frmPenerimaanLeasingNonPJL(this, dt_Iden.DefaultView.ToTable());
                    //ifrmChild.MdiParent = Program.MainForm;
                    //Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tidak mempunyai sisa saldo");
                    return;
                }
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 0)
            {
                cmdBatalIden.Enabled = true;
                cmdIdenNonPnj.Enabled = false;
            }
            else if (tabControl2.SelectedIndex == 1)
            {
                cmdBatalIden.Enabled = false;
                cmdIdenNonPnj.Enabled = true;
            }
            else
            {
                cmdBatalIden.Enabled = false;
                cmdIdenNonPnj.Enabled = false;
            }
        }

        private void dgvHAdj_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dgvHAdj.SelectedCells.Count > 0)
            {
                RefreshDetail3();

                if (Tools.isNull(dgvHAdj.SelectedCells[0].OwningRow.Cells["NoAccIdenLeasing"].Value, "").ToString() == "")
                {
                    cmdADD.Enabled = false;
                    cmdBatalIden.Enabled = false;
                }
                else
                {
                    cmdADD.Enabled = true;
                    cmdBatalIden.Enabled = true;
                }
            }
        }

        public void RefreshDetail3()
        {
            if (dgvHAdj.SelectedCells.Count > 0)
            {
                try
                {
                    Guid _rowIDP = (Guid)dgvHAdj.SelectedCells[0].OwningRow.Cells["RowIDHAdj"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBShowroom))
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("[usp_idenLeasing_AdjDetail]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDP));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                        dgvDAdj.DataSource = dt;
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

        public void RefreshHeader3(string kode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("[usp_idenLeasing_Adj]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgvHAdj.DataSource = dt;
                }

                if (dgvHAdj.Rows.Count > 0)
                {
                    dgvHAdj.FindRow("RowIDHAdj", kode.ToString());
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

        private void dgvHAdj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHAdj.Columns[e.ColumnIndex].Name == "AccLeasing" && e.RowIndex >= 0)
            {
                var temp = dgvHAdj.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp.Value = dgvHAdj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                double cek = Convert.ToDouble(dgvHAdj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                DataGridViewCheckBoxCell dc = (DataGridViewCheckBoxCell)temp;
                if (cek == 0)
                {
                    dc.Selected = true;
                    dgvHAdj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                }
                else
                {
                    dgvHAdj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    dc.Selected = false;
                }
            }
        }

        private void dgvHAdj_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvHAdj.Columns[e.ColumnIndex].Name == "AccLeasing")
            {
                double c = 0;
                int headercount = (int)dgvHAdj.Rows.Count;
                foreach (DataGridViewRow item in dgvHAdj.Rows)
                {
                    double a = Convert.ToDouble(item.Cells["AccLeasing"].Value);
                    if (a == 1) { c = c + a; }
                }

                foreach (DataGridViewRow item in dgvHAdj.Rows)
                {
                    var temp = dgvHAdj.Rows[item.Index].Cells[e.ColumnIndex];
                    DataGridViewCheckBoxCell dc = (DataGridViewCheckBoxCell)temp;
                    if (headercount != c)
                    {
                        dc.Selected = true;
                        dgvHAdj.Rows[item.Index].Cells[e.ColumnIndex].Value = 1;
                    }
                    else
                    {
                        dc.Selected = false;
                        dgvHAdj.Rows[item.Index].Cells[e.ColumnIndex].Value = 0;
                    }
                }
            }
        }

        private void cmdAcc_Click(object sender, EventArgs e)
        {
            int selectedTrans = 0;
            foreach (DataGridViewRow dgvr in dgvHAdj.Rows)
            {
                if (Tools.isNull(dgvr.Cells["AccLeasing"].Value, "0").ToString() == "1" && Tools.isNull(dgvr.Cells["NoACCIdenLeasing"].Value, "").ToString() == "")
                {
                    selectedTrans++;
                    selectedTransRowID.Add(new Guid(Tools.isNull(dgvr.Cells["RowIDHAdj"].Value, Guid.Empty.ToString()).ToString()));
                }
            }

            if (dgvHAdj.SelectedCells.Count > 0 || selectedTrans > 0)
            {
                if (selectedTrans == 0)
                {
                    if (Tools.isNull(dgvHAdj.SelectedCells[0].OwningRow.Cells["NoACCIdenLeasing"].Value, "").ToString() != "")
                    {
                        return;
                    }

                    selectedTransRowID.Add(new Guid(Tools.isNull(dgvHAdj.SelectedCells[0].OwningRow.Cells["RowIDHAdj"].Value, Guid.Empty.ToString()).ToString()));
                }
                txtTanggal.Text = GlobalVar.GetServerDate.ToString("dd/MM/yyyy");
                txtNomor.Text = "";

                pnlACC.Visible = true;
            }
            else 
            {
                MessageBox.Show("Tidak ada data terpilih.");
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            pnlACC.Visible = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtNomor.Text == "")
            {
                MessageBox.Show("No ACC harus di isi.");
                return;
            }
            
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                db.BeginTransaction();
                try
                {
                    int cmd = 0;
                    foreach (Guid PenjRowID in selectedTransRowID)
                    {
                        db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_AccLeasing"));
                        db.Commands[cmd].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                        db.Commands[cmd].Parameters.Add(new Parameter("@NomorACC", SqlDbType.VarChar, txtNomor.Text));
                        db.Commands[cmd].Parameters.Add(new Parameter("@TglACC", SqlDbType.Date, txtTanggal.DateValue));
                        db.Commands[cmd].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        cmd++;
                    }

                    for (int loop = 0; loop < cmd; loop++)
                    {
                        db.Commands[loop].ExecuteNonQuery();
                    }

                    //foreach (DataGridViewRow dgvr in dgvHAdj.Rows)
                    //{
                    //    var temp = dgvr.Cells["AccLeasing"];
                    //    temp.Value = dgvr.Cells["AccLeasing"];
                    //    double cek = Convert.ToDouble(Tools.isNull(dgvr.Cells["AccLeasing"].Value, 0).ToString());
                    //    DataGridViewCheckBoxCell dc = (DataGridViewCheckBoxCell)temp;
                    //    dgvr.Cells["AccLeasing"].Value = 0;
                    //    dc.Selected = false;
                    //}

                    db.CommitTransaction();
                }
                catch(Exception ex)
                {
                    Error.LogError(ex);
                    db.RollbackTransaction();
                }
            }
            RefreshHeader3();
            dgvHAdj.FindRow("RowIDHAdj", selectedTransRowID[0].ToString());
            pnlACC.Visible = false;
        }

        private void pnlACC_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlACC.Visible == false)
            {
                selectedTransRowID.Clear();
            }
            cmdADD.Enabled = !pnlACC.Visible;
            cmdBatalIden.Enabled = !pnlACC.Visible;
            cmdAcc.Enabled = !pnlACC.Visible;
        }

        private void cmdAdjLaporan_Click(object sender, EventArgs e)
        {
            pnlLapADJ.Visible = true;
        }

        private void cmdCancelLap_Click(object sender, EventArgs e)
        {
            pnlLapADJ.Visible = false;
        }

        private void pnlLapADJ_VisibleChanged(object sender, EventArgs e)
        {
            rgLaporan.FromDate = rangeDateBox1.FromDate;
            rgLaporan.ToDate = rangeDateBox1.ToDate;
            if (pnlLapADJ.Visible == false)
            {
                txtNoAcc.Text = "";
            }
            cmdADD.Enabled = !pnlLapADJ.Visible;
            cmdBatalIden.Enabled = !pnlLapADJ.Visible;
            cmdAcc.Enabled = !pnlLapADJ.Visible;
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBShowroom))
            {
                db.Commands.Add(db.CreateCommand("usp_idenLeasing_AdjDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rgLaporan.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rgLaporan.ToDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                if (txtNoAcc.Text != "")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, txtNoAcc.Text));
                }
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                List<ReportParameter> prm = new List<ReportParameter>();
                prm.Add(new ReportParameter("Param1", "Periode"));
                prm.Add(new ReportParameter("Param2", ": " + rgLaporan.FromDate.Value.ToString("dd-MM-yy") + " s.d. " + rgLaporan.ToDate.Value.ToString("dd-MM-yy")));
                prm.Add(new ReportParameter("Param3", "No Acc "));
                prm.Add(new ReportParameter("Param4", ": " + txtNoAcc.Text));
                prm.Add(new ReportParameter("Param5", ""));
                prm.Add(new ReportParameter("Param6", ""));
                prm.Add(new ReportParameter("Param7", ""));
                prm.Add(new ReportParameter("Param8", ""));
                prm.Add(new ReportParameter("Identitas", SecurityManager.UserID + " - " + GlobalVar.GetServerDate.ToString("dd-MM-yy HH:mm:ss")));
                frmReportViewer frm = new frmReportViewer("Kasir.rptAdjLeasing.rdlc", prm, dt, "dsPenerimaanLeasing_IdenAdj");
                frm.Show();
            }
            else
            {
                MessageBox.Show("Tidak ada data.");
            }
        }

        private void CmdSuratTagihan_Click(object sender, EventArgs e)
        {
            pnlSuratTagihan.Show();
        }

        private void CmdPrintSuratTagihan_Click(object sender, EventArgs e)
        {
            List<ReportParameter> rptParamsSBD = new List<ReportParameter>();
            List<ReportParameter> rptParamsLSG = new List<ReportParameter>();

            DataTable dt_rsp = new DataTable();
            Database db_rsp = new Database();
            db_rsp.Commands.Add(db_rsp.CreateCommand("rsp_ReportSuratTagihan"));
            db_rsp.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, GVHeader2.Rows[GVHeader2.CurrentCell.RowIndex].Cells[2].Value.ToString()));
            dt_rsp = db_rsp.Commands[0].ExecuteDataTable();

            if (rbST1.Checked)
            {
                printSubsidi(rptParamsSBD, dt_rsp);
                printLeasing(rptParamsLSG, dt_rsp);
                printLeasingCopy1(rptParamsLSG, dt_rsp);
            }
            else if (rbST2.Checked)
            {
                printSubsidi(rptParamsSBD, dt_rsp);
            }
            else if (rbST3.Checked)
            {
                printLeasing(rptParamsLSG, dt_rsp);
                printLeasingCopy1(rptParamsLSG, dt_rsp);
            }
            else if (rbST4.Checked)
            {
                printLeasing(rptParamsLSG, dt_rsp);
            }
            else if (rbST5.Checked)
            {
                printLeasingCopy1(rptParamsLSG, dt_rsp);
            }
        }

        private void printSubsidi(List<ReportParameter> rptParamsSBD, DataTable dt_rsp)
        {
            rptParamsSBD.Add(new ReportParameter("Leasing", dt_rsp.Rows[0]["Leasing"].ToString()));
            rptParamsSBD.Add(new ReportParameter("Konsumen", dt_rsp.Rows[0]["Konsumen"].ToString()));
            rptParamsSBD.Add(new ReportParameter("NoKontrak", dt_rsp.Rows[0]["NoKontrak"].ToString()));
            rptParamsSBD.Add(new ReportParameter("Alamat", dt_rsp.Rows[0]["AlamatKonsumen"].ToString()));
            rptParamsSBD.Add(new ReportParameter("TahunWarna", dt_rsp.Rows[0]["TahunWarna"].ToString()));
            rptParamsSBD.Add(new ReportParameter("MerkType", dt_rsp.Rows[0]["MerkType"].ToString()));
            int nominal = ((int)Double.Parse(dt_rsp.Rows[0]["SaldoSBD"].ToString()));
            rptParamsSBD.Add(new ReportParameter("NominalSBD", "Rp " + Tools.Nominal(nominal)));
            rptParamsSBD.Add(new ReportParameter("Terbilang", Tools.Terbilang(nominal) + " RUPIAH"));
            rptParamsSBD.Add(new ReportParameter("UntukPembayaran", dt_rsp.Rows[0]["UntukPembayaran"].ToString()));
            rptParamsSBD.Add(new ReportParameter("KotaPerusahaan", dt_rsp.Rows[0]["KotaPerusahaan"].ToString()));
            rptParamsSBD.Add(new ReportParameter("Tanggal", dt_rsp.Rows[0]["Tanggal"].ToString()));

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptSBD.rdlc", rptParamsSBD, dt_rsp, "dsSuratTahigan_Subsidi");
            ifrmReport.Print();
        }

        private void printLeasing(List<ReportParameter> rptParamsLSG, DataTable dt_rsp)
        {
            rptParamsLSG.Add(new ReportParameter("NamaPerusahaan", dt_rsp.Rows[0]["NamaPerusahaan"].ToString()));
            rptParamsLSG.Add(new ReportParameter("Alamat", dt_rsp.Rows[0]["Alamat"].ToString()));
            rptParamsLSG.Add(new ReportParameter("Kontak", dt_rsp.Rows[0]["Kontak"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NoTrans", dt_rsp.Rows[0]["NoTrans"].ToString()));
            rptParamsLSG.Add(new ReportParameter("TerimaDari", dt_rsp.Rows[0]["TerimaDari"].ToString() + ", " + dt_rsp.Rows[0]["AlamatKonsumen"].ToString()));
            int nominal = ((int)Double.Parse(dt_rsp.Rows[0]["SaldoLSG"].ToString()));
            rptParamsLSG.Add(new ReportParameter("Terbilang", Tools.Terbilang(nominal) + " RUPIAH"));
            rptParamsLSG.Add(new ReportParameter("NoKontrak", dt_rsp.Rows[0]["NoKontrak"].ToString()));
            rptParamsLSG.Add(new ReportParameter("TanggalJTTempo", dt_rsp.Rows[0]["TanggalJTTempo"].ToString()));
            rptParamsLSG.Add(new ReportParameter("TahunWarna", dt_rsp.Rows[0]["TahunWarna"].ToString()));
            rptParamsLSG.Add(new ReportParameter("MerkType", dt_rsp.Rows[0]["MerkType"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NoRangka", dt_rsp.Rows[0]["NoRangka"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NoMesin", dt_rsp.Rows[0]["NoMesin"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NominalLSG", Tools.Nominal(nominal)));
            rptParamsLSG.Add(new ReportParameter("KotaPerusahaan", dt_rsp.Rows[0]["KotaPerusahaan"].ToString()));
            getLogo(rptParamsLSG, dt_rsp);

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptLSG.rdlc", rptParamsLSG, dt_rsp, "dsSuratTahigan_LSG");
            ifrmReport.Print();
        }

        private void printLeasingCopy1(List<ReportParameter> rptParamsLSG, DataTable dt_rsp)
        {
            rptParamsLSG.Add(new ReportParameter("NamaPerusahaan", dt_rsp.Rows[0]["NamaPerusahaan"].ToString()));
            rptParamsLSG.Add(new ReportParameter("Alamat", dt_rsp.Rows[0]["Alamat"].ToString()));
            rptParamsLSG.Add(new ReportParameter("Kontak", dt_rsp.Rows[0]["Kontak"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NoTrans", dt_rsp.Rows[0]["NoTrans"].ToString()));
            rptParamsLSG.Add(new ReportParameter("TerimaDari", dt_rsp.Rows[0]["TerimaDari"].ToString() + ", " + dt_rsp.Rows[0]["AlamatKonsumen"].ToString()));
            int nominal = ((int)Double.Parse(dt_rsp.Rows[0]["SaldoLSG"].ToString()));
            rptParamsLSG.Add(new ReportParameter("Terbilang", Tools.Terbilang(nominal) + " RUPIAH"));
            rptParamsLSG.Add(new ReportParameter("NoKontrak", dt_rsp.Rows[0]["NoKontrak"].ToString()));
            rptParamsLSG.Add(new ReportParameter("TanggalJTTempo", dt_rsp.Rows[0]["TanggalJTTempo"].ToString()));
            rptParamsLSG.Add(new ReportParameter("TahunWarna", dt_rsp.Rows[0]["TahunWarna"].ToString()));
            rptParamsLSG.Add(new ReportParameter("MerkType", dt_rsp.Rows[0]["MerkType"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NoRangka", dt_rsp.Rows[0]["NoRangka"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NoMesin", dt_rsp.Rows[0]["NoMesin"].ToString()));
            rptParamsLSG.Add(new ReportParameter("NominalLSG", Tools.Nominal(nominal)));
            rptParamsLSG.Add(new ReportParameter("KotaPerusahaan", dt_rsp.Rows[0]["KotaPerusahaan"].ToString()));
            getLogo(rptParamsLSG, dt_rsp);

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.rptLSGCopy1.rdlc", rptParamsLSG, dt_rsp, "dsSuratTahigan_LSGCopy1");
            ifrmReport.Print();
        }

        private void getLogo(List<ReportParameter> rptParamsLSG, DataTable dt_rsp)
        {
            String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
            String FileName = "";
            using (Database dbLogo = new Database())
            {
                DataTable dtLogo = new DataTable();
                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILE"));
                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
            }

            IMG_Path = IMG_Path + FileName;
            rptParamsLSG.Add(new ReportParameter("IMG_Path", IMG_Path));

            String IMG_PathBW = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
            String FileNameBW = "";
            using (Database dbLogo = new Database())
            {
                DataTable dtLogo = new DataTable();
                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "LOGOFILEBW"));
                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                FileNameBW = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
            }

            IMG_PathBW = IMG_PathBW + FileNameBW;
            rptParamsLSG.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));
        }

        private void CmdCancelSuratTagihan_Click(object sender, EventArgs e)
        {
            pnlSuratTagihan.Hide();
        }

        private void SetSuratTagihan()
        {
            //MessageBox.Show(GVHeader2.CurrentCell.RowIndex + "," + GVHeader2.CurrentCell.ColumnIndex);
            bool isSubsidiZero = (double.Parse(GVHeader2.Rows[GVHeader2.CurrentCell.RowIndex].Cells[11].Value.ToString()) <= 0);
            bool isPiutLSGZero = (double.Parse(GVHeader2.Rows[GVHeader2.CurrentCell.RowIndex].Cells[12].Value.ToString()) <= 0);
            if (isSubsidiZero && isPiutLSGZero)
            {
                CmdSuratTagihan.Enabled = false;
            }
            else
            {
                CmdSuratTagihan.Enabled = true;
                if (isSubsidiZero)
                {
                    rbST1.Enabled = false;
                    rbST2.Enabled = false;
                    rbST3.Enabled = true;
                    rbST4.Enabled = true;
                    rbST5.Enabled = true;
                    rbST3.Checked = true;
                }
                else if (isPiutLSGZero)
                {
                    rbST1.Enabled = false;
                    rbST2.Enabled = true;
                    rbST3.Enabled = false;
                    rbST4.Enabled = false;
                    rbST5.Enabled = false;
                    rbST2.Checked = true;
                }
                else
                {
                    rbST1.Enabled = true;
                    rbST2.Enabled = true;
                    rbST3.Enabled = true;
                    rbST4.Enabled = true;
                    rbST5.Enabled = true;
                    rbST1.Checked = true;
                }
            }
        }
    }
}
