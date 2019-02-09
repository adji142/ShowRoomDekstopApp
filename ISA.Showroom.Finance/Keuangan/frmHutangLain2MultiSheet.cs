using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmHutangLain2MultiSheet : Form
    {
        Class.FillComboBox fcbo = new Class.FillComboBox();
        public frmHutangLain2MultiSheet(DateTime FromDate, DateTime ToDate)
        {
            InitializeComponent();
            rangeTanggal.FromDate = FromDate;
            rangeTanggal.ToDate = ToDate;
            fcbo.fillComboCabang(cboCabang);
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            DateTime _FromDate = rangeTanggal.FromDate.Value;
            DateTime _ToDate = rangeTanggal.ToDate.Value;
            string _CabangID = cboCabang.SelectedValue.ToString();
            DataTable dt = Class.clsHutangLain2.RptHutangLain2Multi(_FromDate, _ToDate, _CabangID);
            if (dt.Rows.Count > 0)
            {
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptHutangLain2_Multi.rdlc", rptParams, dt, "dsHutangLainLain_HutangLainLain");
                ifrmReport.Show();
            }
            else
            {
                MessageBox.Show("Tidak ada Data Hutang Lain-lain untuk Cabang : " + _CabangID);
            }
            this.Close();
        }
    }
}
