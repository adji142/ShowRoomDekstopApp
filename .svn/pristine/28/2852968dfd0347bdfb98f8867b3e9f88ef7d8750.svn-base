using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;
using ISA.Showroom.Finance.Class;
using System.Diagnostics;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmDownloadJournal : ISA.Controls.BaseForm
    {
        string fileZipName,_tempPath,_downPath;
        protected DataTable dtJournal,dtJournalDetail,dtClosingGL;

        public frmDownloadJournal()
        {
            InitializeComponent();
        }

        private bool CekISA(DataTable dt)
        {
            bool YesISA = false;
            int JmlField = dt.Columns.Count;
            for (int n = 0; n <= JmlField-1; n ++)
            {
                if (dt.Columns[n].ColumnName.ToLower() == "rowid" || dt.Columns[n].ColumnName.ToLower() == "headerid")
                {
                    YesISA = true;
                }
            }
            return YesISA;
        }
        private void DownloadJournal()
        {
            string fileName = _tempPath + "TransactTmp.DBF";
            DataTable result = ValidateFile(fileName, dtJournal);
            bool YesISA = CekISA(result);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadJournal"));
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    int nProgress = 0;
                    try
                    {
                        foreach (DataRow dr in result.Rows)
                        {
                            db.Commands[0].Parameters.Clear();
                            if (YesISA == true) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(dr["rowid"].ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, (Guid)GlobalVar.PerusahaanRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idtrans"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, Tools.isNull(dr["tanggal"], "0000-00-00").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, Tools.isNull(dr["no_reff"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr["src"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, Convert.ToInt16(Tools.isNull(dr["id_match"].ToString().Trim(), "0"))));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands[0].ExecuteNonQuery();
                            progressBar1.Increment(1);
                            nProgress = nProgress + 1;
                            labelProgress.Text = progressBar1.Value.ToString().Trim() + "/" + progressBar1.Maximum.ToString().Trim();
                            labelProgress.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : \n Record Ke : " + nProgress.ToString().Trim() + Keys.Enter + ex.Message);
                    }
                }
            }
        }

        private void DownloadJournalDetail()
        {
            string fileName = _tempPath + "JournalTmp.DBF";
            DataTable result = ValidateFile(fileName, dtJournalDetail);
            bool YesISA = CekISA(result);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadJournalDetail"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    int nProgress = 0;
                    string NoPerk;
                    foreach (DataRow dr in result.Rows)
                    {
                        NoPerk = Tools.isNull(dr["no_perk"], "").ToString();
                        if (NoPerk != "" && NoPerk.Trim().Length == 9) NoPerk = NoPerk.Substring(0,4) + "." + NoPerk.Substring(4, 2) + "." + NoPerk.Substring(6, 3);
                        db.Commands[0].Parameters.Clear();
                        if (YesISA == true) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(dr["rowid"].ToString())));
                        if (YesISA == true) db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, new Guid(dr["headerid"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrecordID", SqlDbType.VarChar, Tools.isNull(dr["idtrans"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerk ));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dr["Debet"], "0")));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["Kredit"], "0")));
                        db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(dr["dk"], "D").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(GlobalVar.Gudang, "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                        nProgress = nProgress + 1;
                        labelProgress.Text = progressBar1.Value.ToString().Trim() + "/" + progressBar1.Maximum.ToString().Trim();
                        labelProgress.Refresh();
                    }
                }
            }
        }

        private void DownloadClosingGL()
        {
            string fileName = _tempPath + "TutupTmp.DBF";
            DataTable result = ValidateFile(fileName, dtClosingGL);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadClosingGL"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    int nProgress = 0;
                    string NoPerk;
                    foreach (DataRow dr in result.Rows)
                    {
                        NoPerk = Tools.isNull(dr["kode"], "").ToString();
                        if (NoPerk != "" && NoPerk.Trim().Length == 9) NoPerk = NoPerk.Substring(0, 4) + "." + NoPerk.Substring(4, 2) + "." + NoPerk.Substring(6, 3);
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, Tools.isNull(dr["periode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["idcompany"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerk));
                        db.Commands[0].Parameters.Add(new Parameter("@TglProses", SqlDbType.Date, Convert.ToDateTime(Tools.isNull(dr["tgl_proses"], ""))));
                        db.Commands[0].Parameters.Add(new Parameter("@RpAkhir", SqlDbType.Money, Tools.isNull(dr["akhir"], "0")));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                        nProgress = nProgress + 1;
                        labelProgress.Text = progressBar1.Value.ToString().Trim() + "/" + progressBar1.Maximum.ToString().Trim();
                        labelProgress.Refresh();
                    }
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

        
        private void DownloadProcess()
        {
            DownloadJournal();
            DownloadJournalDetail();
            DownloadClosingGL();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            _tempPath = GlobalVar.DbfDownload + "\\Journal\\";

            if (!Directory.Exists(_tempPath))
            {
                Directory.CreateDirectory(_tempPath);
            }
            else
            {
                string[] files = Directory.GetFiles(_tempPath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            Zip.UnZipFiles(fileZipName, _tempPath, false);

            DownloadProcess();
            MessageBox.Show(Messages.Confirm.ProcessFinished);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDownloadJournal_Load_1(object sender, EventArgs e)
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
        }

        private void cboFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileZipName = cboFiles.Text.ToString();
            if (File.Exists(fileZipName)) cmdYes.Enabled = true;
            else cmdYes.Enabled = false;
        }
    }
}
