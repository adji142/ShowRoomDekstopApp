using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using Microsoft.Reporting.WinForms;
using ISA.Showroom.DataTemplates;
using System.Globalization;

namespace ISA.Showroom.Laporan
{
    public partial class frmLapTagihan : ISA.Controls.BaseForm
    {
        String _cabangID = GlobalVar.CabangID;
        String _kodeTransPJL = "";
        DataTable dtHeader = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtDetailTunai = new DataTable();
        String _JnsPenjualan = "";
        int _PrevGrid1 = -1;

        #region Code
        private void Init()
        {

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DateTime Now = GlobalVar.GetServerDate;
            rangeDateBox1.FromDate = new DateTime(Now.Year, Now.Month, 1);
            rangeDateBox1.ToDate = Now;

            cmdPRINTKW.Enabled = true;

            DataTable dtX = new DataTable();
            dtX.Columns.Add("Jenis", typeof(string));
            
            dtX.Rows.Add("Semua");
            dtX.Rows.Add("Overdue");
            dtX.Rows.Add("Non Overdue");
            comboBox1.DataSource = dtX;
            comboBox1.DisplayMember = "Jenis";
            comboBox1.ValueMember = "Jenis";

            

        }

        private void GetDataTableOverdue()
        {

            if (!rangeDateBox1.FromDate.HasValue || !rangeDateBox1.ToDate.HasValue)
            {
                Error.SetError(rangeDateBox1, "Isi Dengan Benar !!!");
                return;
            }
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[usp_PenjualanKredit_LIST_FILTER_OVERDUE]"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate.Value));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                var na = lookUpCustomer1.txtNamaCustomer.Text.Trim();
                db.Commands[0].Parameters.Add(new Parameter("@NamaCUstomer", SqlDbType.VarChar, na.ToString()));
                if (comboBox1.SelectedValue.ToString().ToLower()!="semua")
                {
                    db.Commands[0].Parameters.Add(new Parameter("@StatusOVerdue", SqlDbType.VarChar, comboBox1.SelectedValue.ToString().ToLower()));
                }
                db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Tools.isNull(txtNoTrans.Text, "") ));
                dt = db.Commands[0].ExecuteDataTable();

            }
            //dt.DefaultView.RowFilter = "PenjHistRowID<>''";
            dtHeader = dt.DefaultView.ToTable().Copy();
            dataGridView1.DataSource = dtHeader;

            if (dtHeader.Rows.Count > 0)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    _JnsPenjualan = dataGridView1.SelectedCells[0].OwningRow.Cells["JnsPenjualan"].Value.ToString();
                    RefreshDetail(HeaderID_);
                }
                else
                {
                    dtDetail.Clear();
                    dataGridView2.DataSource = dtDetail;
                }
            }
            else
            {
                dtDetail.Clear();
                dataGridView2.DataSource = dtDetail;
            }

        }

        private void RefreshDetail(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_Pelunasan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID_));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dtDetailTunai = db.Commands[0].ExecuteDataTable();
                        dgTunai.DataSource = dtDetailTunai;
                        tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                        tableLayoutPanel1.RowStyles[0].Height   = 65;
                        tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Absolute;
                        tableLayoutPanel1.RowStyles[1].Height   = 1;
                        tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
                        tableLayoutPanel1.RowStyles[2].Height   = 34.9F;

                        if (_JnsPenjualan.ToUpper().Contains("LSG"))
                        {
                            lblNominal.Visible = false;
                            lblSisaUM.Visible = false;
                            lblSisaUM2.Visible = false;
                            lblUraian.Visible = false;

                            lblNominal.Enabled = false;
                            lblSisaUM.Enabled = false;
                            lblSisaUM2.Enabled = false;
                            lblUraian.Enabled = false;

                            txtNominal.Visible = false;
                            txtSisaUM.Visible = false;
                            txtSisaUM2.Visible = false;
                            txtUraian.Visible = false;

                            txtNominal.Enabled = false;
                            txtSisaUM.Enabled = false;
                            txtSisaUM2.Enabled = false;
                            txtUraian.Enabled = false;

                            txtSisaUM.Text = "0";
                            txtSisaUM2.Text = "0";
                            txtUraian.Text = "";
                            txtNominal.Text = "0";

                            cmdKwitansiKosong.Enabled = false;
                            cmdKwitansiKosong.Visible = false;

                        }
                        else
                        {
                            if (dtDetailTunai.Rows.Count > 0)
                            {
                                txtSisaUM.Text = Convert.ToDouble(Tools.isNull(dtDetailTunai.Rows[0]["SaldoTagihan"], 0)).ToString();
                            }

                            lblNominal.Visible = true;
                            lblSisaUM.Visible = true;
                            lblSisaUM2.Visible = true;
                            lblUraian.Visible = true;

                            lblNominal.Enabled = true;
                            lblSisaUM.Enabled = false;
                            lblSisaUM2.Enabled = false;
                            lblUraian.Enabled = true;

                            txtNominal.Visible = true;
                            txtSisaUM.Visible = true;
                            txtSisaUM2.Visible = true;
                            txtUraian.Visible = true;

                            txtNominal.Enabled = true;
                            txtSisaUM.Enabled = false;
                            txtSisaUM2.Enabled = false;
                            txtUraian.Enabled = true;

                            txtUraian.Text = "";
                            txtNominal.Text = "0";
                            urusSisaUM();

                            cmdKwitansiKosong.Enabled = false;
                            cmdKwitansiKosong.Visible = false;

                        }
                    }
                }
                else
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Angsuran_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        dtDetail = db.Commands[0].ExecuteDataTable();
                        dataGridView2.DataSource = dtDetail;
                        tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                        tableLayoutPanel1.RowStyles[0].Height   = 65;
                        tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                        tableLayoutPanel1.RowStyles[1].Height   = 34.9F;
                        tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                        tableLayoutPanel1.RowStyles[2].Height   = 1;

                        if (dtDetail.Rows.Count > 0)
                        {
                            txtSisaUM.Text = Convert.ToDouble(Tools.isNull(dtDetail.Rows[0]["PiutangUM"], 0)).ToString();
                        }

                        lblNominal.Visible = true;
                        lblSisaUM.Visible = true;
                        lblSisaUM2.Visible = true;
                        lblUraian.Visible = true;

                        lblNominal.Enabled = true;
                        lblSisaUM.Enabled = false;
                        lblSisaUM2.Enabled = false;
                        lblUraian.Enabled = true;

                        txtNominal.Visible = true;
                        txtSisaUM.Visible = true;
                        txtSisaUM2.Visible = true;
                        txtUraian.Visible = true;

                        txtNominal.Enabled = true;
                        txtSisaUM.Enabled = false;
                        txtSisaUM2.Enabled = false;
                        txtUraian.Enabled = true;

                        txtUraian.Text = "";
                        txtNominal.Text = "0";
                        urusSisaUM();

                        cmdKwitansiKosong.Enabled = true;
                        cmdKwitansiKosong.Visible = true;

                    }
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

        private void PrintTagihTunai(Guid RowID_)
        {
            try
            {
                DataSet dt = new DataSet();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("RSP_SuratTagihan_Tunai"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, RowID_));
                    dt = db.Commands[0].ExecuteDataSet();
                }
                if (dt.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data !!!");
                    return;
                }

                if (_kodeTransPJL == "LSG")
                {
                    DisplayReport(dt, RowID_);
                }
                else
                {
                    CetakKwintasnsi(RowID_);
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void PrintTagih(Guid RowID_, String mode)
        {
            try
            {
                DataSet dt = new DataSet();
                using (Database db = new Database())
                {
                    /*if (GlobalVar.CabangID.Contains("06"))
                    {*/
                        db.Commands.Add(db.CreateCommand("RSP_SuratTagihanTLA")); //RSP_SuratTagihan
                    /*}
                    else
                    {
                        db.Commands.Add(db.CreateCommand("RSP_SuratTagihan"));
                    }*/
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, RowID_));
                    dt = db.Commands[0].ExecuteDataSet();
                }
                if (dt.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Data !!!");
                    return;
                }
                
                if(mode == "K")
                {
                    CetakKwintasnsi(RowID_);
                }
                else
                {
                    DisplayReport(dt, RowID_);
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void DisplayReport(DataSet ds, Guid RowiD_)
        {
            string periode;

            periode = String.Format("{0} ", GlobalVar.GetServerDate.ToString("dd-MM-yyyy"));
            string TglJual_;

            TglJual_ = String.Format("{0} ", Convert.ToDateTime(ds.Tables[1].Rows[0]["TglJual"]).ToString("dd-MMM-yyyy"));
            //construct parameter

            List<ReportParameter> rptParams = new List<ReportParameter>();
            int _nprint;
            String IMG_Path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
            String FileName = "";
            using (Database dbLogo = new Database())
            {
                DataTable dtLogo = new DataTable();
                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "WMF4ASLI"));
                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                FileName = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
            }

            IMG_Path = IMG_Path + FileName;
            rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));
        
            String IMG_PathCOPY = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
            String FileNameCOPY = "";
            using (Database dbLogo = new Database())
            {
                DataTable dtLogo = new DataTable();
                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "WMF4COPY"));
                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                FileNameCOPY = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
            }

            IMG_PathCOPY = IMG_PathCOPY + FileNameCOPY;
            rptParams.Add(new ReportParameter("IMG_PathCopy", IMG_PathCOPY));

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
            string IPserver = ISA.DAL.Database.Host;

            if (IPserver == "172.16.61.253")
                rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));
            else
                rptParams.Add(new ReportParameter("IMG_PathBW", ""));
            
            String KWKSNG = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(0, System.Reflection.Assembly.GetEntryAssembly().CodeBase.LastIndexOf("/") + 1); // Application.ExecutablePath.LastIndexOf("/")
            String FileNameKWKSNG = "";
            using (Database dbLogo = new Database())
            {
                DataTable dtLogo = new DataTable();
                dbLogo.Commands.Add(dbLogo.CreateCommand("usp_AppSetting_LIST"));
                dbLogo.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KWKSNG"));
                dtLogo = dbLogo.Commands[0].ExecuteDataTable();
                FileNameKWKSNG = Tools.isNull(dtLogo.Rows[0]["Value"], 0).ToString().Trim();
            }

            KWKSNG = KWKSNG + FileNameKWKSNG;
            rptParams.Add(new ReportParameter("KWKSNG", KWKSNG));

            rptParams.Add(new ReportParameter("Tgl", periode));
            rptParams.Add(new ReportParameter("TglJual", TglJual_));
            String NoDok = Numerator.NextNumber("NST");
            rptParams.Add(new ReportParameter("NoDok", NoDok));

            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);
            pTable.Add(ds.Tables[2]);

            List<string> pDatasetName = new List<string>();
            if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
            {
                pDatasetName.Add("dsPenjualan_TagihanTunai");
            }
            else
            {
                pDatasetName.Add("dsPenjualan_Tagihan");
            }
            pDatasetName.Add("dsPenjualan_Faktur");
            pDatasetName.Add("dsPenjualan_PT");

            //call report viewer

            frmPrint ifrmDialog = new frmPrint(this, 2);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.Yes)
            { _nprint = ifrmDialog.Result; }
            else
            { return; }



            if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
            {
                if ((_nprint == 0) || (_nprint == 1))
                {
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.rptTagihanTunai.rdlc", rptParams, pTable, pDatasetName);
                    //ifrmReport.Text = "Penjualan Bruto";
                    ifrmReport.Print();
                    // ifrmReport.Show();
                }
                if ((_nprint == 0) || (_nprint == 2))
                {
                    frmReportViewer ifrmReportCOPY = new frmReportViewer("Laporan.rptTagihanTunaiCopy1.rdlc", rptParams, pTable, pDatasetName);
                    ifrmReportCOPY.Print();
                }
            }

            else if (_JnsPenjualan.ToUpper().Contains("FLT"))// if(GlobalVar.CabangID.Contains("06A"))
            {

                rptParams.Add(new ReportParameter("TotAngsuran", TotAngsuran(pTable[0]).ToString()));
                rptParams.Add(new ReportParameter("TotDenda", TotDenda(pTable[0]).ToString()));
                if ((_nprint == 0) || (_nprint == 1))
                { // RptTagihan , RptTagihanCopy1
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.RptTagihanTLA_FLT.rdlc", rptParams, pTable, pDatasetName);
                    //ifrmReport.Text = "Penjualan Bruto";
                    ifrmReport.Print();
                    // ifrmReport.Show();
                }
                if ((_nprint == 0) || (_nprint == 2))
                {
                    frmReportViewer ifrmReportCOPY = new frmReportViewer("Laporan.RptTagihanTLACopy1_FLT.rdlc", rptParams, pTable, pDatasetName);
                    ifrmReportCOPY.Print();
                }
            }
            else // if(GlobalVar.CabangID.Contains("06A"))
            {
                if ((_nprint == 0) || (_nprint == 1))
                { // RptTagihan , RptTagihanCopy1
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.RptTagihanTLA.rdlc", rptParams, pTable, pDatasetName);
                    //ifrmReport.Text = "Penjualan Bruto";
                    ifrmReport.Print();
                    // ifrmReport.Show();
                }
                if ((_nprint == 0) || (_nprint == 2))
                {
                    frmReportViewer ifrmReportCOPY = new frmReportViewer("Laporan.RptTagihanTLACopy1.rdlc", rptParams, pTable, pDatasetName);
                    ifrmReportCOPY.Print();
                }
            }/*
            else
            {
                if ((_nprint == 0) || (_nprint == 1))
                {
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.RptTagihan.rdlc", rptParams, pTable, pDatasetName);
                    //ifrmReport.Text = "Penjualan Bruto";
                    ifrmReport.Print();
                    // ifrmReport.Show();
                }
                else if ((_nprint == 0) || (_nprint == 2))
                {
                    frmReportViewer ifrmReportCOPY = new frmReportViewer("Laporan.RptTagihanCopy1.rdlc", rptParams, pTable, pDatasetName);
                    ifrmReportCOPY.Print();
                }
            }*/
            /*
            if (GlobalVar.CabangID.Contains("06"))
            {
            }
            else
            {
                CetakKwintasnsi(RowiD_);
            }
            */
            using (Database dbST = new Database())
            {
                dbST.Commands.Add(dbST.CreateCommand("usp_SuratTagihanLog_INSERT"));
                dbST.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                dbST.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, RowiD_));
                dbST.Commands[0].Parameters.Add(new Parameter("@NoDok", SqlDbType.VarChar, NoDok));
                dbST.Commands[0].Parameters.Add(new Parameter("@TglCetak", SqlDbType.Date, GlobalVar.GetServerDate.Date));
                dbST.Commands[0].Parameters.Add(new Parameter("@NominalDenda", SqlDbType.Money, ds.Tables[0].Compute("SUM(SaldoDenda)", "")));
                dbST.Commands[0].Parameters.Add(new Parameter("@isProcessed", SqlDbType.TinyInt, 0));
                dbST.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                dbST.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dbST.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dbST.Commands[0].ExecuteNonQuery();
            }
        }

        public double TotAngsuran(DataTable dt) {
            double i = 0;
            double Angsuran = 0;
            double AngsuranActual = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if ((DateTime)dr["TglJT"] <= GlobalVar.DateOfServer)
                {
                    Angsuran += Convert.ToDouble(dr["Angsuran"]);
                    AngsuranActual += Convert.ToDouble(dr["PembayaranAngsuranActual"]);
                }
            }
            i = Angsuran - AngsuranActual;
            return i;

        }
        public double TotDenda(DataTable dt)
        {

            double i = 0;
            double Denda = 0;
            double DendaActual = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if ((DateTime)dr["TglJT"] <= GlobalVar.DateOfServer)
                {
                    Denda += Convert.ToDouble(Tools.isNull(dr["Denda"],0.0));
                    DendaActual += Convert.ToDouble(Tools.isNull(dr["BayarDenda"],0.0));
                }
            }
            i = Denda - DendaActual;
            return i;

        }

        private void CetakKwintasnsi(Guid RowiD_)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView2.RowCount > 0)
            {
                // HeaderID itu RowID nya Penjualan
                Guid HeaderID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid PenjHistRowID = (Guid) new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PenjHistRowID"].Value, Guid.Empty).ToString());

                // cek, kalau udah lunas, ngga usah print lagi... tapi mestinya klo ada overdue itu karena udah lunas kan...?
                using (Database db = new Database())
                {
                    DataTable dummysub = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_CHECK_Lunas"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, PenjHistRowID));
                    dummysub = db.Commands[0].ExecuteDataTable();
                    if (dummysub.Rows.Count > 0)
                    {
                        string tempdata = dummysub.Rows[0]["StatusLunas"].ToString();
                        if (tempdata == "LUNAS")
                        {
                            MessageBox.Show("Data Penjualan ini sudah Lunas, tidak perlu surat tagihan lagi!");
                            return;
                        }
                    }
                }
            }

            try
            {
                Guid rowID = RowiD_;
                string _edp, _terbilang, _kotatgl, _kota, _copy, _uraian;
                int _nprint;
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                String NoKwitansi = "";

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    if ((_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT"))
                    {
                        db.Commands.Add(db.CreateCommand("[rpt_KwitansiKosong_Tagihan]"));
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("[rpt_Kwitansi_Kosong]"));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0 && (_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT"))
                    {
                        dt.Rows[0]["Nominal"] = Convert.ToInt32(Tools.isNull(txtNominal.GetDoubleValue, 0));
                        NoKwitansi = "K" + Numerator.NextNumber("NKJ");
                        dt.Rows[0]["NoTrans"] = NoKwitansi;
                        
                        Double Selisih = txtSisaUM.GetDoubleValue - txtNominal.GetDoubleValue;
                        if(Selisih > 0)
                        {
                            dt.Rows[0]["Uraian3"] = "Sisa : " + Selisih.ToString("N0") + " - Ket.: " + txtUraian.Text.Trim();
                        }
                        else
                        {
                        }
                    }

                    List<ReportParameter> rptParams = new List<ReportParameter>();

                    _edp = String.Format("{0:d/MM/yyyy}", dt.Rows[0]["Tanggal"]);
                    if (dt.Rows.Count > 0 && (_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT"))
                    {
                        rptParams.Add(new ReportParameter("NominalAtas", Convert.ToDouble(dt.Rows[0]["Nominal"]).ToString()));
                        _terbilang = Tools.Terbilang(int.Parse(dt.Rows[0]["Nominal"].ToString(), NumberStyles.Currency)) + "RUPIAH";
                    }
                    else
                    {
                        _terbilang = "";
                    }
                    _kota = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();

                    _kota = _kota.Replace("Kota ", "");
                    _kota = _kota.Replace("Kabupaten ", "");

                    DateTime tglBayar;
                    tglBayar = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"].ToString(), GlobalVar.GetServerDate).ToString());
                    // _kotatgl = _kota + ", " + GlobalVar.GetServerDate.Day.ToString() + " " + Tools.BulanPanjang(GlobalVar.GetServerDate.Month) + " " + GlobalVar.GetServerDate.Year.ToString();
                    // _kotatgl = _kota + ", " + tglBayar.Day.ToString() + " " + Tools.BulanPanjang(tglBayar.Month) + " " + tglBayar.Year.ToString();
                    _kotatgl = _kota + ", ............................";
                    _copy = "";

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
                    rptParams.Add(new ReportParameter("IMG_Path", IMG_Path));

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
                    rptParams.Add(new ReportParameter("IMG_PathBW", IMG_PathBW));
                    
                    if (dt.Rows.Count > 0 && (_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT"))
                    {
                        rptParams.Add(new ReportParameter("JnsKw", "UANG MUKA"/*Tools.isNull(dt.Rows[0]["Uraian"], "").ToString()*/));
                    }
                    else
                    {
                        rptParams.Add(new ReportParameter("JnsKw", ""/*Tools.isNull(dt.Rows[0]["Uraian"], "").ToString()*/));
                    }
                    rptParams.Add(new ReportParameter("TipeKw", "KWITANSI"));
                    rptParams.Add(new ReportParameter("EDP", "Tahun : " + dt.Rows[0]["Tahun"].ToString() + ", Warna : " + dt.Rows[0]["Warna"].ToString() + ", Nopol : " + dt.Rows[0]["Nopol"].ToString() + ", No. BPKB : " + dt.Rows[0]["NoBPKB"].ToString()));
                    rptParams.Add(new ReportParameter("Terbilang", _terbilang.ToUpper()));
                    rptParams.Add(new ReportParameter("KotaTgl", _kotatgl.ToUpper()));
                    rptParams.Add(new ReportParameter("Copy", _copy.ToString()));
                    rptParams.Add(new ReportParameter("Pembuat", SecurityManager.UserID + "  " + dt.Rows[0]["idrec"].ToString() + "  " + GlobalVar.GetServerDateTime_RealTime.ToString() ));  //GlobalVar.GetServerDateTime_RealTime.ToString() sebelumnya -> GlobalVar.GetServerDate.ToString()
                    
                    // tambahan untuk kwitansi
                    rptParams.Add(new ReportParameter("Admin", SecurityManager.UserName.ToString()));
                    rptParams.Add(new ReportParameter("CabangID", GlobalVar.CabangID.Substring(0, 2)));
                    if (dt.Rows.Count > 0 && (_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT"))
                    {
                        rptParams.Add(new ReportParameter("Tipe", "FIRST"));
                    }
                    else
                    {
                        rptParams.Add(new ReportParameter("Tipe", "KSG"));
                    }


                    frmPrint ifrmDialog = new frmPrint(this, 3);
                    ifrmDialog.ShowDialog();
                    if (ifrmDialog.DialogResult == DialogResult.Yes)
                    { _nprint = ifrmDialog.Result; }
                    else
                    { return; }


                    if ((_nprint == 0) || (_nprint == 1))
                    {
                        frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansi.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                        ifrmReport.Print();
                    }

                    if (_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT")
                    {

                        if ((_nprint == 0) || (_nprint == 2))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy1.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                            ifrmReport.Print();
                        }

                        if ((_nprint == 0) || (_nprint == 3))
                        {
                            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptKwitansiCopy2.rdlc", rptParams, dt, "dsPenjualan_Kwitansi");
                            ifrmReport.Print();
                        }
                    }

                    if (dt.Rows.Count > 0 && (_kodeTransPJL == "TUN" || _kodeTransPJL == "CTP" || _kodeTransPJL == "FLT"))
                    {
                        // masukkin detail kwitansi kosongnya ke database
                        using (Database dbsub = new Database())
                        {
                            dbsub.Commands.Add(dbsub.CreateCommand("usp_KwitansiKosong_INSERT"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@NoKwitansi", SqlDbType.VarChar, NoKwitansi));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, rowID));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text.Trim()));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.VarChar, GlobalVar.GetServerDate));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dbsub.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dicetak !\n" + ex.Message);
            }
        }

        #endregion


        public frmLapTagihan()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetDataTableOverdue();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLapTagihan_Load(object sender, EventArgs e)
        {
            try
            {
                Init();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void doPrint(String mode)
        {
            if (dataGridView1.SelectedCells.Count > 0 && (dataGridView2.RowCount > 0 || dgTunai.RowCount > 0))
            {
                // HeaderID itu RowID nya Penjualan
                Guid HeaderID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid PenjHistRowID = new Guid(Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["PenjHistRowID"].Value, Guid.Empty).ToString());

                _kodeTransPJL = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value, "").ToString();

                if ( (mode == "P" && ( _kodeTransPJL == "TUN" || _kodeTransPJL == "CTP") )
                     || (mode == "K" && _kodeTransPJL == "FLT") )
                {
                    if (txtNominal.GetDoubleValue < -1 || txtNominal.GetDoubleValue > txtSisaUM.GetDoubleValue)
                    {
                        MessageBox.Show("Tolong periksa isian Nominal Terlebih dahulu!");
                        return;
                    }
                    if (txtSisaUM.GetDoubleValue < 1)
                    {
                        MessageBox.Show("UM Sudah Lunas!");
                        return;
                    }
                }

                // cek, kalau udah lunas, ngga usah print lagi... tapi mestinya klo ada overdue itu karena udah lunas kan...?
                using (Database db = new Database())
                {
                    DataTable dummysub = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Penjualan_CHECK_Lunas"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                    if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                    {
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, PenjHistRowID));
                    }
                    dummysub = db.Commands[0].ExecuteDataTable();
                    if (dummysub.Rows.Count > 0)
                    {
                        string tempdata = dummysub.Rows[0]["StatusLunas"].ToString();
                        if (tempdata == "LUNAS")
                        {
                            MessageBox.Show("Data Penjualan ini sudah Lunas, tidak perlu surat tagihan lagi!");
                            return;
                        }
                    }
                }

                // cek dulu perlakuan print nya 
                // ambil data angsuran, terakhir bayar itu tanggal berapa
                DataTable dummy = new DataTable();
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_GET_LatestData"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_GET_LatestData"));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, PenjHistRowID));
                    }
                    dummy = db.Commands[0].ExecuteDataTable();
                }

                // ambil juga data, terakhir ada sempet ngeprint ngga sebelum ini
                DataTable dummy2 = new DataTable();
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    db.Commands.Add(db.CreateCommand("usp_PrintLog_GET_LastPrint"));
                    db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, PinId.ModulId.SuratTagihan_PrintLog));
                    if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@ModulHeaderRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderTableName", SqlDbType.VarChar, "Penjualan"));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@ModulHeaderRowID", SqlDbType.UniqueIdentifier, PenjHistRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderTableName", SqlDbType.VarChar, "Penjualan_Hist"));
                    }
                    dummy2 = db.Commands[0].ExecuteDataTable();
                }

                // ambil tanggal nya 
                DateTime lastPayment = DateTime.MinValue;
                DateTime lastPrint = DateTime.MinValue;
                DateTime today = GlobalVar.GetServerDate;

                if (dummy.Rows.Count > 0)
                {
                    lastPayment = Convert.ToDateTime(dummy.Rows[0]["Tanggal"].ToString());
                }
                else if (dummy2.Rows.Count > 0)
                {
                    lastPrint = Convert.ToDateTime(dummy2.Rows[0]["PrintedDate"].ToString());
                }

                bool isOKPrint = true;

                // list kasus yg mesti bikin PIN, selain itu anggap boleh print aja
                // kalau ada data pembayaran dan pernah print, cek dengan hari ini dulu
                if (lastPrint == DateTime.MinValue && lastPayment == DateTime.MinValue)
                {
                    if (lastPayment < lastPrint)
                    // kalau bayaran terakhir itu lebih lampau dari pencetakan terakhir
                    // berarti dari pencetakan terakhir itu belum ada pembayaran, cek PIN
                    {
                        isOKPrint = false;
                    }
                }
                // kalau udah pernah print, tapi belum pernah ada bayar
                else if (lastPrint != DateTime.MinValue && lastPayment == DateTime.MinValue)
                {
                    // ngga boleh print lagi, minta PIN dulu
                    isOKPrint = false;
                }
                // selain kondisi di atas, boleh print aja
                else
                {
                }

                if (isOKPrint == true)
                {
                    // log ke data PrintLog dulu
                    Database db = new Database(GlobalVar.DBShowroom);
                    int counterdb = 0;
                    try
                    {
                        // yang PrintLog
                        db.Commands.Add(db.CreateCommand("usp_PrintLog_INSERT"));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)Guid.NewGuid()));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, Convert.ToInt32(PinId.ModulId.SuratTagihan_PrintLog)));

                        // di modul ini, yg penting itu hanya PenjHistRowID nya, makanya yg dipake hanya ModulHeaderRowID dan HeaderTableName nya
                        if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                        {
                            db.Commands[counterdb].Parameters.Add(new Parameter("@ModulHeaderRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                            db.Commands[counterdb].Parameters.Add(new Parameter("@HeaderTableName", SqlDbType.VarChar, "Penjualan"));
                        }
                        else
                        {
                            db.Commands[counterdb].Parameters.Add(new Parameter("@ModulHeaderRowID", SqlDbType.UniqueIdentifier, PenjHistRowID));
                            db.Commands[counterdb].Parameters.Add(new Parameter("@HeaderTableName", SqlDbType.VarChar, "Penjualan_Hist"));
                        }
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PrintedDate", SqlDbType.DateTime, GlobalVar.GetServerDate));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PrintedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        counterdb++;
                        if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                        {
                            PrintTagihTunai(HeaderID_);
                        }
                        else
                        {
                            PrintTagih(HeaderID_, mode);
                        }

                        int looper = 0;
                        db.BeginTransaction();
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        MessageBox.Show("Terjadi Error : " + ex.Message);
                    }
                }
                else
                {
                    
                    // minta PIN
                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                    DateTime date = GlobalVar.GetServerDate;
                    Calendar cal = dfi.Calendar;
                    int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                    // minta Pin
                    Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Piutang,
                              Convert.ToInt32(PinId.ModulId.SuratTagihan_PrintLog), "Sudah dilakukan pencetakan Kwitansi tetapi belum ada data pembayaran!",
                              PenjHistRowID, Guid.Empty, _JnsPenjualan.ToUpper().Contains("TUNAI") ? "Penjualan" : "Penjualan_Hist", String.Empty, true);
                    if (GlobalVar.pinResult == false && GlobalVar.CabangID != "06A") // TLA Bebas Pin
                    {
                        // berarti ngga boleh Print
                        MessageBox.Show("Proses Pencetakan tidak dapat dilakukan!");
                        return;
                    }
                    else
                    {
                        // kalau masuk sini, baru boleh Print
                        if (_JnsPenjualan.ToUpper().Contains("TUNAI"))
                        {
                            PrintTagihTunai(HeaderID_);
                        }
                        else
                        {
                            PrintTagih(HeaderID_, mode);
                        }
                    }
                }
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            doPrint("P");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                _JnsPenjualan = dataGridView1.SelectedCells[0].OwningRow.Cells["JnsPenjualan"].Value.ToString();
                _kodeTransPJL = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value.ToString();
                RefreshDetail(HeaderID_);
            }
        }

        private void cmdPRINTKW_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView2.RowCount > 0)
            {
                Guid HeaderID_ = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                CetakKwintasnsi(HeaderID_);
            }
        }
        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.RowCount>0)
            {
                int ovd = 0;
                ovd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["overdue"].Value);
                if (ovd>0)
                {

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.Yellow;
                    }
                }

            }
        }
        
        private void txtSisaUM_Leave(object sender, EventArgs e)
        {
            urusSisaUM();
        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {
            urusSisaUM();
        }

        private void urusSisaUM()
        {
            if (txtNominal.GetDoubleValue > txtSisaUM.GetDoubleValue)
            {
                MessageBox.Show("Tidak dapat menginputkan pembayaran lebih dari Sisa Saldo!");
                txtNominal.Text = txtSisaUM.Text;
            }
            txtSisaUM2.Text = (txtSisaUM.GetDoubleValue - txtNominal.GetDoubleValue).ToString();
        }

        private void cmdKwitansiKosong_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && _kodeTransPJL == "FLT")
            {
                doPrint("K");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

 
    }
}
