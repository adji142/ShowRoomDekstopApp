using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISA.DAL;


namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmRptLaporanPertanggungJawaban : Form
    {
        public frmRptLaporanPertanggungJawaban()
        {
            InitializeComponent();
        }

        private void frmRptLaporanPertanggungJawaban_Load(object sender, EventArgs e)
        {
            tbTanggal.FromDate = DateTime.Today;
            tbTanggal.ToDate = DateTime.Today;
        }

        private void RptPertanggungJawaban(DataSet ds)
        {
            DateTime fromDate;
            DateTime toDate;

            fromDate = (DateTime)tbTanggal.FromDate;
            toDate = (DateTime)tbTanggal.ToDate;

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("fromDate", String.Format("{0:dd-MMM-yyyy}", fromDate)));
            rptParams.Add(new ReportParameter("toDate", String.Format("{0:dd-MMM-yyyy}", toDate)));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0].DefaultView.ToTable());


            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsKasbon_Data");

            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Finance.rptPertanggungjawaban.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Text = "lap_pertanggungjawaban";
            ifrmReport.Name = "LAPORAN PERTANGGUNGJAWABAN";
            ifrmReport.Show();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            DataSet dsKasbon;
            DateTime fromDate;
            DateTime toDate;

            fromDate = (DateTime)tbTanggal.FromDate;
            toDate = (DateTime)tbTanggal.ToDate;

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_PertanggungJawaban"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    dsKasbon = db.Commands[0].ExecuteDataSet();
                }

                if (rbCetM.Checked == true)
                    dsKasbon.Tables[0].DefaultView.RowFilter = "SisaPiutang=0";
                else if (rbCetP.Checked == true)
                    dsKasbon.Tables[0].DefaultView.RowFilter = "SisaPiutang<>0";

                if (dsKasbon.Tables[0].DefaultView.Count != 0)
                {
                    dsKasbon.Tables[0].DefaultView.Sort = "Tanggal";

                    RptPertanggungJawaban(dsKasbon);
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data");
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbTanggal_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rbCetA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbCetM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbCetP_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
