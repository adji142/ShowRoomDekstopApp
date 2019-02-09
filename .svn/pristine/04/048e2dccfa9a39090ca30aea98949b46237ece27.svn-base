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

namespace ISA.Showroom.Laporan
{
    public partial class frmLapSuratSomasi : ISA.Controls.BaseForm
    {
        public frmLapSuratSomasi()
        {
            InitializeComponent();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmLapSuratSomasi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_TelatBayar"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgvPembayaran.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPerusahaan = DataPerusahaan(GlobalVar.PerusahaanRowID);

            string NoTrans = dgvPembayaran.SelectedCells[0].OwningRow.Cells["NoTrans"].Value.ToString();
            string Nama = dgvPembayaran.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
            string Alamat = dgvPembayaran.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
            string Kabupaten = dgvPembayaran.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
            double Nominal = Convert.ToDouble(dgvPembayaran.SelectedCells[0].OwningRow.Cells["Total"].Value);
            string Angsuran = dgvPembayaran.SelectedCells[0].OwningRow.Cells["Angsuran"].Value.ToString();
            int Angsuran2 = Convert.ToInt32(dgvPembayaran.SelectedCells[0].OwningRow.Cells["Angsuran"].Value);
            int Jenis = Convert.ToInt32(dgvPembayaran.SelectedCells[0].OwningRow.Cells["JenisSP"].Value);
            String NoDok = Numerator.NextNumber("NST");
            Guid _penjRowID = (Guid)dgvPembayaran.SelectedCells[0].OwningRow.Cells["PenjRowID"].Value;
            DateTime TglAngsuran = (DateTime)dgvPembayaran.SelectedCells[0].OwningRow.Cells["TglAngsuran"].Value;

            //Untuk Cek apakah surat peringatan sudah pernah dicetak, karena hanya bisa dicetak satu kali
            DataTable dtCek = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CekSuratSomasi"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAngsuran", SqlDbType.Date, TglAngsuran));
                    db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.Int, Jenis));
                    dtCek = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            if (dtCek.Rows.Count > 0)
            {
                MessageBox.Show("Tidak bisa Cetak, Surat Peringatan sudah pernah dicetak.");
                return;
            }

            //Mengambil Lokasi Logo
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

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Detail_TelatBayar"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            double _totNominal = Convert.ToDouble(dt.Rows[0]["SaldoPiutang"]);
            string _stotNominal = _totNominal.ToString("N0");

            KWKSNG = KWKSNG + FileNameKWKSNG;

            if (Jenis == 2)
            {
                Nominal = 2 * Nominal;
                Angsuran2 = Angsuran2 + 1;
            }

            string sNominal = Nominal.ToString("N0");
            string sAngsuran = Angsuran2.ToString();

            List<ReportParameter> rptparam = new List<ReportParameter>();
            rptparam.Add(new ReportParameter("NoTrans", NoTrans));
            rptparam.Add(new ReportParameter("Nama", Nama));
            rptparam.Add(new ReportParameter("Alamat", Alamat));
            rptparam.Add(new ReportParameter("Kabupaten", Kabupaten));
            rptparam.Add(new ReportParameter("Perusahaan", GlobalVar.PerusahaanName));
            rptparam.Add(new ReportParameter("Tanggal", GlobalVar.GetServerDate.ToString("dd MMM yyyy")));
            rptparam.Add(new ReportParameter("User", SecurityManager.UserName));
            rptparam.Add(new ReportParameter("NoDok", NoDok));
            rptparam.Add(new ReportParameter("KWKSNG", KWKSNG));

            string namafile = "Laporan.rptSuratSomasi" + Jenis + ".rdlc";

            if (Jenis != 3)
            {
                rptparam.Add(new ReportParameter("Nominal", sNominal));
                rptparam.Add(new ReportParameter("Angsuran", Angsuran));
                rptparam.Add(new ReportParameter("NominalTotal", _stotNominal));
                if (Jenis == 2)
                {
                    rptparam.Add(new ReportParameter("Angsuran2", sAngsuran));
                }

                frmReportViewer frm = new frmReportViewer(namafile, rptparam, dtPerusahaan, "dsPenjualan_PT");
                frm.Print();
            }
            else
            {
                //DataTable dt = new DataTable();
                //try
                //{
                //    using (Database db = new Database())
                //    {
                //        db.Commands.Add(db.CreateCommand("usp_Detail_TelatBayar"));
                //        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                //        dt = db.Commands[0].ExecuteDataTable();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}

                //Nominal = Convert.ToDouble(dt.Rows[0]["SaldoPiutang"]);
                //sNominal = Nominal.ToString("N0");

                sNominal = _totNominal.ToString("N0");

                rptparam.Add(new ReportParameter("Nominal", sNominal));
                rptparam.Add(new ReportParameter("TglAmbil", GlobalVar.DateOfServer.AddDays(7).ToString("dd MMM yyyy")));

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(dtPerusahaan);
                pTable.Add(dt);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsPenjualan_PT");
                pDatasetName.Add("dsPenjualan_TelatBayarDetail");

                frmReportViewer frm = new frmReportViewer(namafile, rptparam, pTable, pDatasetName);
                frm.Print();
            }

            //Untuk save data ke Database, agar surat Somasi hanya bisa dicetak satu kali.

            SaveData(_penjRowID, TglAngsuran, Jenis);
        }

        static DataTable DataPerusahaan(Guid RowID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        void SaveData(Guid PenjRowID, DateTime TglAngsuran, int Jenis)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SuratSomasi"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjrowID", SqlDbType.UniqueIdentifier, PenjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.DateOfServer));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAngsuran", SqlDbType.Date, TglAngsuran));
                    db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.Int, Jenis));
                    db.Commands[0].Parameters.Add(new Parameter("@IsUser", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
