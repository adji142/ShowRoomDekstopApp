using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.Master
{
    public partial class frmLstBank : ISA.Controls.BaseForm
    {
        public frmLstBank()
        {
            InitializeComponent();
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYES_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Bank_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                if (dt.Rows.Count > 0)
                {
                    DisplayReport(dt);
                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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

            //construct sender            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Laporan.Master.rptLstBank.rdlc", rptParams, dt, "dsBank_Data");
            ifrmReport.Show();
        }

    }
}
