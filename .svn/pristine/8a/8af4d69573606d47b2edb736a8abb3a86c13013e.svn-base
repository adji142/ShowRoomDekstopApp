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


namespace ISA.Showroom.Finance.DKN
{
    public partial class frmDknMultiSheet : Form
    {
        Class.FillComboBox fcbo = new Class.FillComboBox();
        public frmDknMultiSheet(DateTime FromDate, DateTime ToDate)
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
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("rsp_DKN_MultiSheet"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, _FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, _ToDate));
                if (_CabangID != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI_Multy.rdlc", rptParams, dt, "dsHI_DKN");
                ifrmReport.Show();
            }
            this.Close();
        }

        void show_report()
        {
                //try {
                //    List<DataTable> dt = new List<DataTable>();
                //    List<string> ds = new List<string>();
                //    ds.Add("dsHI_HubunganIstimewa");
                //    ds.Add("dsHI_HubunganIstimewaDetail");
                //        //dt.Add(Class.clsDKN.DBGetListByDate(
                //        dt.Add(Class.clsDKNDetail.DBGetListByHeaderID(_rowID));

                //        List<ReportParameter> rptParams = new List<ReportParameter>();
                //        rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

                //        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptNotaHI.rdlc", rptParams, dt, ds);
                //        ifrmReport.Show();
                //    }
                //} catch (Exception ex) {
                //    Error.LogError(ex);
                //}        
        }
    }
}
