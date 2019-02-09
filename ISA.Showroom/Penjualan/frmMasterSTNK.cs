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


namespace ISA.Showroom.Penjualan
{
    public partial class frmMasterSTNK : ISA.Controls.BaseForm
    {
        DataTable dtSTNK;
        public frmMasterSTNK()
        {
            InitializeComponent();
        }

        private void frmMasterSTNK_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            btnSearch.PerformClick();

            if (GlobalVar.Aktif_IMG == "0")
            {
                cmdVIEW.Enabled = false;
                cmdViewBPKB.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData(Guid.Empty);
        }

        public void RefreshData(Guid RowID)
        {
            try
            {
                dtSTNK = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinanceOto))
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterSTNK_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    dtSTNK = db.Commands[0].ExecuteDataTable();
                }
                GV_STNK.DataSource = dtSTNK;

                if (dtSTNK.Rows.Count > 0)
                {
                    if (RowID != Guid.Empty)
                    {
                        GV_STNK.FindRow("RowID", RowID.ToString());
                    }
                }
                else
                {
                    GV_STNK.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPengambilan_Click(object sender, EventArgs e)
        {
            if (GV_STNK.Rows.Count > 0 && GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilan"].Value.ToString() == "")
            {
                DataTable dt = new DataTable();
                dt = dtSTNK.Copy();
                dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                Penjualan.frmMasterSTNKPengambilan ifrmChild = new frmMasterSTNKPengambilan(this, dt.DefaultView.ToTable(), "ambilSTNK");
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show("STNK Sudah pernah diambil");
                return;
            }
        }

        private void cmdVIEW_Click(object sender, EventArgs e)
        {
            if (GV_STNK.Rows.Count > 0 && GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilan"].Value.ToString() != "")
            {
                DataTable dt = new DataTable();
                dt = dtSTNK.Copy();
                dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                Penjualan.frmMasterSTNKPengambilan ifrmChild = new frmMasterSTNKPengambilan(this, dt.DefaultView.ToTable(), "viewSTNK");
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show("STNK belum pernah diambil");
                return;
            }
        }

        private void cmdAddBPKP_Click(object sender, EventArgs e)
        {
            if (GV_STNK.Rows.Count > 0) 
            {
                if(GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilanBPKB"].Value.ToString() != "")
                {
                    MessageBox.Show("BPKP sudah diambil");
                    return;
                }
            
                DataTable dt = new DataTable();
                dt = dtSTNK.Copy();
                dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                Penjualan.frmMasterSTNK_AddBPKP ifrmChild = new frmMasterSTNK_AddBPKP(this, dt.DefaultView.ToTable());
                ifrmChild.ShowDialog();
                //ifrmChild.MdiParent = Program.MainForm;
                //Program.MainForm.RegisterChild(ifrmChild);
                //ifrmChild.Show();
            }
            else
            {
                MessageBox.Show("Tidak ada data yang dipilih");
                return;
            }
        }

        private void cmdPengambilanBPKB_Click(object sender, EventArgs e)
        {
            if (GV_STNK.Rows.Count > 0)
            {
                if (GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilanBPKB"].Value.ToString() == ""
                    && GV_STNK.SelectedCells[0].OwningRow.Cells["TglTerimaBPKB"].Value.ToString() != "")
                {
                    DataTable dt = new DataTable();
                    dt = dtSTNK.Copy();
                    dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                    Penjualan.frmMasterSTNKPengambilan ifrmChild = new frmMasterSTNKPengambilan(this, dt.DefaultView.ToTable(), "ambilBPKB");
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                else
                {
                    MessageBox.Show("BPKB belum ada");
                    return;
                }
            }
            else
            {
                MessageBox.Show("BPKB Sudah pernah diambil");
                return;
            }
        }

        private void cmdViewBPKB_Click(object sender, EventArgs e)
        {
            if (GV_STNK.Rows.Count > 0 && GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilanBPKB"].Value.ToString() != "")
            {
                DataTable dt = new DataTable();
                dt = dtSTNK.Copy();
                dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                Penjualan.frmMasterSTNKPengambilan ifrmChild = new frmMasterSTNKPengambilan(this, dt.DefaultView.ToTable(), "viewBPKB");
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show("BPKB belum pernah diambil");
                return;
            }
        }

        private void cmdPRINTSTNK_Click(object sender, EventArgs e)
        {
            try
            {
                if (GV_STNK.Rows.Count > 0 && GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilan"].Value.ToString() == "")
                {
                    MessageBox.Show("STNK belum diambil");
                    return;
                }

                DataTable dt = new DataTable();
                dt = dtSTNK.Copy();
                dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserName));
                rptParams.Add(new ReportParameter("Judul", "SURAT PERNYATAAN PENGAMBILAN STNK DAN PLAT NOMER KENDARAAN"));
                rptParams.Add(new ReportParameter("NamaPengambil", dt.DefaultView.ToTable().Rows[0]["NamaPengambil"].ToString()));
                rptParams.Add(new ReportParameter("AlamatPengambil", dt.DefaultView.ToTable().Rows[0]["AlamatPengambil"].ToString()));
                rptParams.Add(new ReportParameter("NoKTP", dt.DefaultView.ToTable().Rows[0]["NoKTPAmbilSTNK"].ToString()));
                rptParams.Add(new ReportParameter("TglPengambilan", dt.DefaultView.ToTable().Rows[0]["tglAmbilSTNK"].ToString()));
                rptParams.Add(new ReportParameter("JamPengambilan", dt.DefaultView.ToTable().Rows[0]["jamAmbilSTNK"].ToString()));
                rptParams.Add(new ReportParameter("NamaSTNK", dt.DefaultView.ToTable().Rows[0]["NamaSTNK"].ToString()));
                rptParams.Add(new ReportParameter("NoRangka", dt.DefaultView.ToTable().Rows[0]["NoRangka"].ToString()));
                rptParams.Add(new ReportParameter("NoMesin", dt.DefaultView.ToTable().Rows[0]["NoMesin"].ToString()));
                rptParams.Add(new ReportParameter("NoRegistrasi", dt.DefaultView.ToTable().Rows[0]["NoRegistrasi"].ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptMasterSTNK_printSTNK.rdlc", rptParams);
                ifrmReport.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdPRINTBPKB_Click(object sender, EventArgs e)
        {
            try
            {
                if (GV_STNK.Rows.Count > 0 && GV_STNK.SelectedCells[0].OwningRow.Cells["TglPengambilanBPKB"].Value.ToString() == "")
                {
                    MessageBox.Show("BPKB belum diambil");
                    return;
                }

                DataTable dt = new DataTable();
                dt = dtSTNK.Copy();
                dt.DefaultView.RowFilter = "RowID = '" + GV_STNK.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString() + "'";

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserName));
                rptParams.Add(new ReportParameter("Judul", "SURAT PERNYATAAN PENGAMBILAN BPKB"));
                rptParams.Add(new ReportParameter("NamaPengambil", dt.DefaultView.ToTable().Rows[0]["NamaPengambilBPKB"].ToString()));
                rptParams.Add(new ReportParameter("AlamatPengambil", dt.DefaultView.ToTable().Rows[0]["AlamatPengambilBPKB"].ToString()));
                rptParams.Add(new ReportParameter("NoKTP", dt.DefaultView.ToTable().Rows[0]["NoKTPAmbilBPKB"].ToString()));
                rptParams.Add(new ReportParameter("TglPengambilan", dt.DefaultView.ToTable().Rows[0]["tglAmbilBPKB"].ToString()));
                rptParams.Add(new ReportParameter("JamPengambilan", dt.DefaultView.ToTable().Rows[0]["jamAmbilBPKB"].ToString()));
                rptParams.Add(new ReportParameter("NamaSTNK", dt.DefaultView.ToTable().Rows[0]["NamaSTNK"].ToString()));
                rptParams.Add(new ReportParameter("NoRangka", dt.DefaultView.ToTable().Rows[0]["NoRangka"].ToString()));
                rptParams.Add(new ReportParameter("NoMesin", dt.DefaultView.ToTable().Rows[0]["NoMesin"].ToString()));
                rptParams.Add(new ReportParameter("NoRegistrasi", dt.DefaultView.ToTable().Rows[0]["NoRegistrasi"].ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptMasterSTNK_printBPKB.rdlc", rptParams);
                ifrmReport.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            Laporan.frmLapMasterSTNK ifrmChild = new Laporan.frmLapMasterSTNK();
            ifrmChild.ShowDialog();
        }
    }
}
