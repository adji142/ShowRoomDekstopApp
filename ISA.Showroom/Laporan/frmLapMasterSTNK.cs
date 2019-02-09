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

namespace ISA.Showroom.Laporan
{
    public partial class frmLapMasterSTNK : ISA.Controls.BaseForm
    {
        public frmLapMasterSTNK()
        {
            InitializeComponent();
        }

        private void frmLapMasterSTNK_Load(object sender, EventArgs e)
        {
            rb_TglJual.Checked = true;
            rb_STNK.Checked = true;
            rb_Diterima.Checked = true;
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-(GlobalVar.GetServerDate.Day - 1)).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;

        }

        private void cmdPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinanceOto))
                {
                    db.Commands.Add(db.CreateCommand("rsp_MasterSTNK"));
                    if (rb_TglJual.Checked == true)
                        db.Commands[0].Parameters.Add(new Parameter("@JenisTgl", SqlDbType.Int, 0));
                    else
                        db.Commands[0].Parameters.Add(new Parameter("@JenisTgl", SqlDbType.Int, 1));
                    
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    if (rb_STNK.Checked == true)
                        db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "STNK"));
                    else
                        db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "BPKB"));

                    if (rb_Diterima.Checked == true)
                        db.Commands[0].Parameters.Add(new Parameter("@Pilihan", SqlDbType.Int, 0));
                    else
                        db.Commands[0].Parameters.Add(new Parameter("@Pilihan", SqlDbType.Int, 1));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data");
                    return;
                }

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

                rptParams.Add(new ReportParameter("Tanggal", rangeDateBox1.FromDate.Value.ToString("dd/MM/yyyy") + " sd " + rangeDateBox1.ToDate.Value.ToString("dd/MM/yyyy")));
                if (rb_STNK.Checked == true)
                    rptParams.Add(new ReportParameter("Judul", "LAPORAN STNK"));
                else
                    rptParams.Add(new ReportParameter("Judul", "LAPORAN BPKB"));

                if (rb_Diterima.Checked == true)
                    rptParams.Add(new ReportParameter("Pilihan", "Diterima"));
                else
                    rptParams.Add(new ReportParameter("Pilihan", "Diambil"));

                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptMasterSTNK.rdlc", rptParams, dt, "dsPenjualan_MasterSTNK");
                ifrmReport.Show();

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
    }
}
