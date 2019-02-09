using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;

namespace ISA.Showroom.Finance.Laporan.HI
{
    public partial class frmLaporanHI : ISA.Controls.BaseForm
    {
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        public frmLaporanHI()
        {
            InitializeComponent();
        }

        private void cbCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaporanHI_Load(object sender, EventArgs e)
        {
            fcbo.fillComboPerusahaan(cboPT);
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(GlobalVar.GetServerDate.Day * -1 + 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            rbDetail.Checked = true;
        }

        int pilTanggal()
        {
            int pil = 0;
            if (rdoTglInput.Checked == true) pil = 1;
            return pil;
        }
        

        private void cbPRINT_Click(object sender, EventArgs e)
        {
            if (cboPT.Text != "" && cboCabang.Text != "")
            {
                Guid _PerusahaanRowID = (Guid)Guid.Empty;
                string _CabangID = "";
                DataRowView drvPT = (DataRowView)cboPT.Items[cboPT.SelectedIndex];
                _PerusahaanRowID = (Guid)drvPT.Row["RowID"];
                DataRowView drvCabang = (DataRowView)cboCabang.Items[cboCabang.SelectedIndex];
                _CabangID = drvCabang.Row["CabangID"].ToString();
                DateTime _TglDari = (DateTime)rangeDateBox1.FromDate;
                DateTime _TglSampai = (DateTime)rangeDateBox1.ToDate;
                double _SaldoAwal = 0;
                DataTable dtHI = new DataTable();

                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@FromDate", SqlDbType.Date, _TglDari));
                prm.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, _PerusahaanRowID));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetSaldoHI"));
                    db.Commands[0].Parameters = prm;
                    _SaldoAwal = double.Parse(Tools.isNull(db.Commands[0].ExecuteScalar(), "0").ToString());
                    db.Commands.Clear();

                    prm.Add(new Parameter("@OwnPtRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    prm.Add(new Parameter("@OwnCabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    prm.Add(new Parameter("@ToDate", SqlDbType.Date, _TglSampai));

                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("CabangID", _CabangID));
                    rptParams.Add(new ReportParameter("FromDate", _TglDari.ToString()));
                    rptParams.Add(new ReportParameter("ToDate", _TglSampai.ToString()));
                    rptParams.Add(new ReportParameter("SaldoAwal", _SaldoAwal.ToString()));

                    if (rbDetail.Checked)
                    {
                        db.Commands.Add(db.CreateCommand("usp_TransaksiHI_FILTER_CabangTanggal"));
                        db.Commands[0].Parameters = prm;
                        dtHI = db.Commands[0].ExecuteDataTable();
                        
                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptDetailHI.rdlc", rptParams, dtHI, "dsHI_LapDetail");
                        ifrmReport.Show();  
                    }
                    else if (rdoKelompokTransaksi.Checked)
                    {
                        db.Commands.Add(db.CreateCommand("usp_TransaksiHIKelompokTransaksi_FILTER_CabangTanggal"));
                        db.Commands[0].Parameters = prm;
                        dtHI = db.Commands[0].ExecuteDataTable();

                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptGlobalHIKelompokTransaksi.rdlc", rptParams, dtHI, "dsHI_LapHIKelompokTrans");
                        ifrmReport.Show();
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_TransaksiHIGlobal_FILTER_CabangTanggal"));
                        db.Commands[0].Parameters = prm;
                        dtHI = db.Commands[0].ExecuteDataTable();

                        frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptGlobalHI.rdlc", rptParams, dtHI, "dsHI_LapGlobal");
                        ifrmReport.Show();
                    }
                }
            }
            else MessageBox.Show("Pilhan perusahaan & cabang harus diIsi !");
        }

        private void cboPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPT.SelectedIndex != 0 && cboPT.DisplayMember.ToString() != "")
                fcbo.fillComboCabang(cboCabang, (Guid)cboPT.SelectedValue);
        }
    }
}
