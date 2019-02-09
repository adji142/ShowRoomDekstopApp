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
    public partial class frmDownloadPerkiraan : ISA.Controls.BaseForm
    {
        string fileZipName = GlobalVar.DbfDownload + "\\NoPerk.zip";
        string _tempPath;
        protected DataTable dtPerkiraan, dtHkoneksi, dtDkoneksi, dtDesign;

        public frmDownloadPerkiraan()
        {
            InitializeComponent();
        }

        private void frmDownloadPerkiraan_Load(object sender, EventArgs e)
        {
            _tempPath = GlobalVar.DbfDownload + "\\NoPerk\\";

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

            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, _tempPath, false);
                txtStatus.Text = "FOUND";
                cmdYes.Enabled = true;
            }
            else
            {
                txtStatus.Text = "NONE";
                cmdYes.Enabled = false;
                return;
            }
        }

        private void DownloadKoneksi()
        {
            string fileName = _tempPath + "hKoneksiTmp.DBF";
            DataTable result = ValidateFile(fileName, dtHkoneksi);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadKoneksiHeader"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Tools.isNull(dr["RowID"], Guid.Empty)));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["RecordID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["Kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                    }
                }
                ShowNotepad(result);
            }

            fileName = _tempPath + "dKoneksiTmp.DBF";
            result = ValidateFile(fileName, dtDkoneksi);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadKoneksiDetail"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Tools.isNull(dr["RowID"], Guid.Empty)));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["RecordID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, Tools.isNull(dr["RowID"], Guid.Empty)));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["RecordID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["No_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Mdl", SqlDbType.VarChar, Tools.isNull(dr["Mdl"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTrn", SqlDbType.VarChar, Tools.isNull(dr["KodeTrn"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, Tools.isNull(dr["KodeCabang"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                    }
                }
                ShowNotepad(result);
            }
        }
        
        private void DownloadDesign()
        {
            string fileName = _tempPath + "DesignTmp.DBF";
            DataTable result = ValidateFile(fileName, dtDesign);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadDesign"));
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Tools.isNull(dr["RowID"], Guid.Empty)));
                        db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.VarChar, Tools.isNull(dr["Report"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Tools.isNull(dr["Ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoUrut", SqlDbType.VarChar, Tools.isNull(dr["NoUrut"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, Tools.isNull(dr["Tipe"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["Keterangan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["Catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Formula", SqlDbType.VarChar, Tools.isNull(dr["Formula"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Lminus", SqlDbType.Int, Convert.ToInt16(Tools.isNull(dr["Lminus"].ToString().Trim(),"0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@TUnderLine",SqlDbType.Bit, Convert.ToBoolean(Tools.isNull(dr["TUnderLine"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@DunderLine", SqlDbType.Bit, Convert.ToBoolean(Tools.isNull(dr["DUnderLine"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@Bold", SqlDbType.Bit, Convert.ToBoolean(Tools.isNull(dr["Bold"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, Tools.isNull(dr["CabangID"], "").ToString().Trim()));

                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                    }
                }
                ShowNotepad(result);
            }

        }

        private void DownloadPerkiraan()
        {
            string fileName = _tempPath + "NoPerkTmp.DBF";
            DataTable result = ValidateFile(fileName, dtPerkiraan);
            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadPerkiraan"));
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    foreach (DataRow dr in result.Rows)
                    {                                                
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Tools.isNull(dr["ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, Convert.ToInt16(Tools.isNull(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@Hapus", SqlDbType.Int, Convert.ToInt16(Tools.isNull(dr["hapus"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.VarChar, dr["rowid"].ToString()));
                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                    }
                }
                ShowNotepad(result);
            }
        }

        private void ShowNotepad(DataTable dt)
        {
           try
           {
               BuildString data = new ISA.Showroom.Finance.Class.BuildString();
               
               data.PROW(true, 1, "HASIL DOWNLOAD NO.PERK DARI 11");
               data.PROW(true, 1, "===============================================================================================");
               data.PROW(true, 1, data.PrintVerticalLine2());
               data.PROW(false, 3, "REF");
               data.PROW(false, 7, data.PrintVerticalLine2());
               data.PROW(false, 10, "No.Perkiraan");
               data.PROW(false, 24, data.PrintVerticalLine2());
               data.PROW(false, 50, "Nama Perkiraan");
               data.PROW(false, 96, data.PrintVerticalLine2());
               data.PROW(true, 1, "-----------------------------------------------------------------------------------------------");
               foreach(DataRow dr in dt.Rows)
               {
                   data.PROW(true, 1, data.PrintVerticalLine2());
                   data.PROW(false,3,Tools.isNull(dr["ref"], "").ToString().Trim());
                   data.PROW(false, 7, data.PrintVerticalLine2());
                   data.PROW(false, 10, Tools.isNull(dr["no_perk"], "").ToString().Trim());
                   data.PROW(false, 24, data.PrintVerticalLine2());
                   data.PROW(false, 26, Tools.isNull(dr["uraian"], "").ToString().Trim());
                   data.PROW(false, 96, data.PrintVerticalLine2());
               }
               data.PROW(true, 1, "===============================================================================================");
               data.Eject();

               if (File.Exists(Properties.Settings.Default.OutputFile + "\\" + "NoPerk.txt"))
               {
                   File.Delete(Properties.Settings.Default.OutputFile + "\\" + "NoPerk.txt");
               }               

               data.SendToTxt("NoPerk.txt", data.GenerateString());
               Process.Start(Properties.Settings.Default.OutputFile + "\\" + "NoPerk.txt");
               

           }
           catch (Exception ex)
           {
               Error.LogError(ex);
               MessageBox.Show(ex.Message);
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
            DownloadPerkiraan();
            DownloadKoneksi();
            DownloadDesign();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DownloadProcess();
            MessageBox.Show(Messages.Confirm.ProcessFinished);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
