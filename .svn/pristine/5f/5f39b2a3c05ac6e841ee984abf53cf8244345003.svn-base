using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using ISA.Common;
using System.IO;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Keuangan.Budget
{
    public partial class frmAccBiaya : ISA.Controls.BaseForm
    {
        enum enumModus { Clear, Download, Update };
        enumModus Modus;
        string _downPath,_tempPath,fileZipName;
        protected DataTable dtAjuanAccBiaya;
        List<string> files = new List<string>();

        public frmAccBiaya()
        {
            InitializeComponent();
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(GlobalVar.GetServerDate.Day * -1 + 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
        }

        private void cmdTABEL_Click(object sender, EventArgs e)
        {
            frmPerkiraanAccBiaya ifrm = new frmPerkiraanAccBiaya();
            ifrm.Show();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAccBiaya_Load(object sender, EventArgs e)
        {
            IsiComboGudang();
            IsiComboDownload();
            RefreshData();
            Modus = enumModus.Clear;
            SetEnable();
        }

        #region functions
        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\ISA-JawabanACCBiaya.zip";
            if (File.Exists(fileZipName)) File.Delete(fileZipName);
            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str)) File.Delete(str);
            }
        }
        private void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cboGUDANG.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dgTransAccBiaya.DataSource = dt;
            }
        }
        private void IsiComboDownload()
        {
            _downPath = GlobalVar.DbfDownload;
            string[] files = Directory.GetFiles(_downPath);
            List<string> ar = new List<string>();
            int n = 0;
            foreach (string file in files)
            {
                n = n + 1;
                ar.Add(file);
            }
            cboFiles.DataSource = ar;
            fileZipName = cboFiles.Text.ToString();
        }
        private void IsiComboGudang()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_gudang_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                cboGUDANG.DataSource = dt;
                cboGUDANG.DisplayMember = "GudangID";
                cboGUDANG.ValueMember = "GudangID";
            }
        }
        private void SetEnable()
        {
            panelUpdate.Visible = Modus == enumModus.Update;
            panelDownload.Visible = Modus == enumModus.Download;
            cmdUPLOAD.Enabled = Modus == enumModus.Clear;
            cmdUPDATE.Enabled = Modus == enumModus.Clear;
            cmdDOWNLOAD.Enabled = Modus == enumModus.Clear;
        }
        private void DownloadProses()
        {
            string fileName = _tempPath + "TransAccTmp.DBF";
            DataTable result = ValidateFile(fileName, dtAjuanAccBiaya);

            using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_AccBy_DownloadAjuan"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.VarChar, dr["RowID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, dr["CabangID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dr["Uraian"].ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, dr["NoBukti"].ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, dr["NoPerk"].ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Transaksi", SqlDbType.VarChar, dr["Transaksi"].ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Rp", SqlDbType.Money, dr["Rp"]));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl_pengajuan", SqlDbType.Date, dr["TglAjuan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@UploadKe11", SqlDbType.Date, dr["UploadKe11"]));

                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        private DataTable ValidateFile(string fileName, DataTable table)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    table = Foxpro.ReadFile(fileName);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }
        #endregion

        private void cmdUPLOAD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "TransAccTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical)) File.Delete(Physical);
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, cboGUDANG.Text));
                db.Commands[0].Parameters.Add(new Parameter("@UploadKe00", SqlDbType.Date, GlobalVar.GetServerDate));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("CabangID", "CabangID", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglAjuan", "TglAjuan", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Transaksi", "Transaksi", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("NoPerk", "NoPerk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("NoBukti", "NoBukti", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 55));
            fields.Add(new Foxpro.DataStruct("Rp", "Rp", Foxpro.enFoxproTypes.Numeric, 17));
            fields.Add(new Foxpro.DataStruct("NoAcc", "NoAcc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("TglAcc", "TglAcc", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 55));
            fields.Add(new Foxpro.DataStruct("UploadKe11", "UploadKe11", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("UploadKe00", "UploadKe00", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TransAccTmp", fields, dt);
            ZipFile(files);
            MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\ISA-JawabanACCBiaya.zip");

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, cboGUDANG.Text));
                db.Commands[0].Parameters.Add(new Parameter("@UploadKe00", SqlDbType.Date, GlobalVar.GetServerDate));
                db.Commands[0].Parameters.Add(new Parameter("@IsUpdate", SqlDbType.Bit, true));
                db.Commands[0].ExecuteNonQuery();
            }
            Modus = enumModus.Clear;
            RefreshData();
        }

        private void cmdDOWNLOAD_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Download;
            SetEnable();
        }

        private void cmdDownloadGo_Click(object sender, EventArgs e)
        {
            _tempPath = GlobalVar.DbfDownload + "\\AccBiaya\\";
            if (!Directory.Exists(_tempPath)) Directory.CreateDirectory(_tempPath);
            else
            {
                string[] files = Directory.GetFiles(_tempPath);
                foreach (string file in files)
                { 
                    File.Delete(file);
                }
            }
            Zip.UnZipFiles(fileZipName, _tempPath, false);

            DownloadProses();
            MessageBox.Show(Messages.Confirm.ProcessFinished);
            Modus = enumModus.Clear;
            SetEnable();
            RefreshData();
        }

        private void cmdDownloadClose_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetEnable();
        }

        private void cboFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileZipName = cboFiles.Text.ToString();
        }

        private void cmdUpdateSave_Click(object sender, EventArgs e)
        {
            if (txtNoAcc.Text == "" && txtKeterangan.Text == "") MessageBox.Show("Jika ditolak, silahkan isi alasan penolakannya di kolom Keterangan", "Perhatian!");
            else
            {
                Guid _RowID = (Guid)dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, txtNoAcc.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAcc", SqlDbType.Date, txtTglAcc.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                    db.Commands[0].ExecuteNonQuery();
                }
                Modus = enumModus.Clear;
                RefreshData();
                SetEnable();
            }
        }

        private void cmdUPDATE_Click(object sender, EventArgs e)
        {
            if (Tools.isNull(dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["TglAcc"].Value, "").ToString() == "")
            {
                txt00.Text = dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
                txtTglAjuan.DateValue = (DateTime)dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["TglPengajuan"].Value;
                txtTransaksi.Text = dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["Transaksi"].Value.ToString();
                txtUraian.Text = dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                txtJumlah.Text = dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
                txtNoAcc.Text = dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["NoAcc"].Value.ToString();
                txtTglAcc.DateValue = GlobalVar.GetServerDate;
                txtKeterangan.Text = dgTransAccBiaya.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();
                Modus = enumModus.Update;
                SetEnable();
            }
            else MessageBox.Show("Data dimaksud sudah pernah diAcc/diTolak", "Perhatian!");
        }

        private void cmdUpdateClose_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetEnable();
        }

        private void rangeDateBox1_Leave(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtNoAcc_Leave(object sender, EventArgs e)
        {
            if (Tools.isNull(txtNoAcc.Text, "") != "") txtKeterangan.Text = "ACC";
            else txtKeterangan.Text = "";
        }

        private void cboGUDANG_Leave(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
