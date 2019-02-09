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

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmRptPiutangLainLain_Rekap : ISA.Controls.BaseForm
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
 
                if (comboBox1.SelectedIndex == 0)
                {
                    rptParams.Add(new ReportParameter("Title", "PIUTANG LAIN LAIN"));
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    rptParams.Add(new ReportParameter("Title", "PIUTANG LAIN LAIN (DKN)"));
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    rptParams.Add(new ReportParameter("Title", "PIUTANG LAIN LAIN (ANTAR PT)"));
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    rptParams.Add(new ReportParameter("Title", "HUTANG LAIN LAIN(DKN)"));
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    rptParams.Add(new ReportParameter("Title", "HUTANG LAIN LAIN(ANTAR PT)"));
                }



                string file = string.Empty;

                List<string> pDatasetName = new List<string>();
                if (comboBox1.SelectedIndex == 0)
                {
                    file = "Keuangan.rptPiutangLainLain_Rekap_A.rdlc";
                    pDatasetName.Add("dsPLL_dtLain");
                }
                //else if (comboBox1.SelectedIndex == 1)
                //{
                //    file = "Keuangan.rptPiutangLainLain_Rekap_B.rdlc";
                //}
                else
                {
                    file = "Keuangan.rptPiutangLainLain_Rekap_C.rdlc";
                    pDatasetName.Add("dsPLLHLL_data");
                }

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);

                

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer(file, rptParams, pTable, pDatasetName);
                ifrmReport.Text = "Piutang Lain - Lain";
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

        public frmRptPiutangLainLain_Rekap()
        {
            InitializeComponent();
        }

        private void frmRptPiutangLainLain_Rekap_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                InitCabang();
                fcbo.fillComboPerusahaan(cboPTDari);
                cboPTDari.SelectedValue = GlobalVar.PerusahaanRowID;
                fcbo.fillComboPerusahaan(cboPTke);
                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox1.ToDate = GlobalVar.GetServerDate;
                comboBox1.SelectedIndex = 0;
                comboBox1_SelectedIndexChanged( sender, e);
               


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

                    db.Commands.Add(db.CreateCommand("[rsp_PIUTANGLAINLAIN_PT_Rekap]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));

                    db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.Int, comboBox1.SelectedIndex));

                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPTDari.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPTke.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, Tools.isNull(cboCabang.SelectedValue, "").ToString()));
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
            switch (comboBox1.SelectedIndex)
            {
                case 0: //PIUTANG LAIN LAIN
                    cboPTke.Visible = false;
                    label5.Visible = false;
                    cboCabang.Visible = false;
                    cboCabang.SelectedIndex = 0;
                    label6.Visible = false;
                    label3.Visible = true;
                    break;
              /*  case 1: //PIUTANG LAIN LAIN DKNm
                    cboPTke.Visible = false;
                    label5.Visible = false;
                    cboCabang.Visible = false;
                    cboCabang.SelectedIndex = 0;
                    label6.Visible = false;
                    label3.Visible = true;
                    break;
                case 3:
                    cboCabang.Visible = true;
                    cboCabang.SelectedIndex = 0;
                    label3.Visible = true;
                    break;
                case 2:
                    cboCabang.Visible = true;
                    cboCabang.SelectedIndex = 0;
                    label3.Visible = true;
                    break; */
                default:
                    cboPTke.Visible = true;
                    label5.Visible = true;
                    cboCabang.Visible = true;
                    cboCabang.SelectedIndex = 0;
                    label6.Visible = true;
                    label3.Visible = true;
                    break;
            }
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
