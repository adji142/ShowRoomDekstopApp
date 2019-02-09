using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Showroom.Finance.DataTemplates;

namespace ISA.Showroom.Finance.Laporan.Finance
{
    public partial class frmRptPiutangLainLain_Saldo : ISA.Controls.BaseForm
    {

        Class.FillComboBox fcbo = new Class.FillComboBox();

        private void DisplayReport(DataSet ds)
        {

            try
            {

                

                string periode = string.Empty;
                periode = String.Format("PERIODE : {0} s/d {1}", rangeDateBox1.FromDate.Value.ToString("dd-MM-yyyy"), rangeDateBox1.ToDate.Value.ToString("dd-MM-yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                string title = "";
                if (comboBox1.SelectedIndex == 0)
                {
                    rptParams.Add(new ReportParameter("Title", "PIUTANG LAIN LAIN"));
                    title = "PIUTANG LAIN LAIN";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    rptParams.Add(new ReportParameter("Title", "HUTANG LAIN LAIN "));
                    title = "HUTANG LAIN LAIN";
                }
                 



                string file = string.Empty;
                if (comboBox1.SelectedIndex == 0)
                {
                    file = "Laporan.Finance.rptPiutangLainLain_Saldo_A.rdlc";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    file = "Laporan.Finance.rptPiutangLainLain_Saldo_A.rdlc";
                }
                

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsPLL_dtLain");

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer(file, rptParams, pTable, pDatasetName);
                ifrmReport.Text = title;
                ifrmReport.Show();


            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public frmRptPiutangLainLain_Saldo()
        {
            InitializeComponent();
        }

        private void frmRptPiutangLainLain_Rekap_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
                DataColumn dc = new DataColumn("VAL");
                dtt.Columns.Add(dc);
                dtt.Columns.Add(new DataColumn("Keterangan"));

                dtt.Rows.Add("1", "Piutang  Lain Lain");
                dtt.Rows.Add("2", "Hutang Lain Lain");
                comboBox1.DataSource = dtt;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.DisplayMember = "Keterangan";
                comboBox1.ValueMember = "VAL";

                this.Cursor = Cursors.WaitCursor;
                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox1.ToDate = GlobalVar.GetServerDate;
               



                fcbo.fillComboPerusahaan(cboPTDari);
                cboPTDari.SelectedValue = GlobalVar.PerusahaanRowID;
                fcbo.fillComboPerusahaan(cboPTke);
            }
            catch (System.Exception ex)
            {
                fcbo.fillComboPerusahaan(cboPTDari);
                cboPTDari.SelectedValue = GlobalVar.PerusahaanRowID;
                fcbo.fillComboPerusahaan(cboPTke);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    string SP = comboBox1.SelectedValue.ToString() == "1" ? "[rsp_PIUTANGLAINLAIN_PT_SALDO]" : "[rsp_HUTANGLAINLAIN_PT_SALDO]";
                    db.Commands.Add(db.CreateCommand(SP));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariID", SqlDbType.UniqueIdentifier, cboPTDari.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeID", SqlDbType.UniqueIdentifier, cboPTke.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, Tools.isNull(cboCabang.SelectedValue, "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, Tools.isNull(cboDariCabang.SelectedValue, "").ToString()));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                // dt.DefaultView.Sort = cboSort.SelectedValue.ToString();
                DisplayReport(ds);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }


        private void InitCabang()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox1.ToDate = GlobalVar.GetServerDate;

               
               

                DataTable dtCabang = DBTools.DBGetDataTable("usp_Cabang_LIST", new List<Parameter>());
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "CabangID ASC";
                cboCabang.DataSource = dtCabang;
                cboCabang.DisplayMember = "Cab";
                cboCabang.ValueMember = "CabangID";
                comboBox1.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboPTDari_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPTDari.SelectedValue.ToString() != "" && cboPTDari.SelectedIndex != 0)
            {
                fcbo.fillComboCabang(cboDariCabang, (Guid)cboPTDari.SelectedValue);
            }
            else
            {
                fcbo.fillComboCabang(cboDariCabang, GlobalVar.PerusahaanRowID);
            }

        }

        private void cboPTke_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPTke.SelectedValue.ToString() != "" && cboPTke.SelectedIndex != 0)
            {
                fcbo.fillComboCabang(cboCabang, (Guid)cboPTke.SelectedValue);
            }
            else
            {
                fcbo.fillComboCabang(cboCabang, GlobalVar.PerusahaanRowID);
            }
        }
    }
}
