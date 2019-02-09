using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Showroom.Class;

namespace ISA.Showroom.Penjualan
{
    public partial class frmMasterSTNKPengambilan : ISA.Controls.BaseForm
    {
        Guid MasterSTNKRowID;
        Guid PembelianRowID;
        Guid PenjualanRowID;
        Guid CustomerRowID;

        String _action = "";

        public frmMasterSTNKPengambilan()
        {
            InitializeComponent();
        }

        //public frmMasterSTNKPengambilan(Form _caller, DataTable dt)
        //{
        //    InitializeComponent();
        //    this.Caller = _caller;

        //    MasterSTNKRowID = new Guid(dt.Rows[0]["RowID"].ToString());
        //    PenjualanRowID  = new Guid(dt.Rows[0]["PenjualanRowID"].ToString());
        //    PembelianRowID  = new Guid(dt.Rows[0]["PembelianRowID"].ToString());
        //    CustomerRowID   = new Guid(dt.Rows[0]["CustomerRowID"].ToString());

        //    txt_TglLunasBBN.DateValue   = Convert.ToDateTime(dt.Rows[0]["TglLunasBBN"].ToString());
        //    txt_NoSTNK.Text             = dt.Rows[0]["NoSTNK"].ToString();
        //    txt_NoRegistrasi.Text       = dt.Rows[0]["NoRegistrasi"].ToString();
        //    txt_NamaSTNK.Text           = dt.Rows[0]["NamaSTNK"].ToString();
        //    txt_AlamatSTNK.Text         = dt.Rows[0]["Alamat"].ToString();
        //    txt_NoRangka.Text           = dt.Rows[0]["NoRangka"].ToString();
        //    txt_NoMesin.Text            = dt.Rows[0]["NoMesin"].ToString();
        //    txt_Warna.Text              = dt.Rows[0]["Warna"].ToString();

        //    txt_TglPengambilan.DateValue = GlobalVar.GetServerDate.Date;

        //    GV_Attachment.ReadOnly = false;
        //    //GV_Attachment.Columns["RowID"].ReadOnly = true;
        //    //GV_Attachment.Columns["FilePath"].ReadOnly = true;
        //    //GV_Attachment.Columns["FileName"].ReadOnly = true;
        //    //GV_Attachment.Columns["Keterangan"].ReadOnly = false;
        //}

        public frmMasterSTNKPengambilan(Form _caller, DataTable dt, string action)
        {
            InitializeComponent();
            this.Caller = _caller;

            _action = action;
            MasterSTNKRowID = new Guid(dt.Rows[0]["RowID"].ToString());
            PenjualanRowID = new Guid(dt.Rows[0]["PenjualanRowID"].ToString());
            PembelianRowID = new Guid(dt.Rows[0]["PembelianRowID"].ToString());
            CustomerRowID = new Guid(dt.Rows[0]["CustomerRowID"].ToString());

            txt_TglLunasBBN.DateValue = Convert.ToDateTime(dt.Rows[0]["TglLunasBBN"].ToString());
            txt_NoSTNK.Text = dt.Rows[0]["NoSTNK"].ToString();
            txt_NoRegistrasi.Text = dt.Rows[0]["NoRegistrasi"].ToString();
            txt_NamaSTNK.Text = dt.Rows[0]["NamaSTNK"].ToString();
            txt_AlamatSTNK.Text = dt.Rows[0]["Alamat"].ToString();
            txt_NoRangka.Text = dt.Rows[0]["NoRangka"].ToString();
            txt_NoMesin.Text = dt.Rows[0]["NoMesin"].ToString();
            txt_Warna.Text = dt.Rows[0]["Warna"].ToString();

            if (action == "viewSTNK")
            {
                txt_TglPengambilan.DateValue = Convert.ToDateTime(dt.Rows[0]["TglPengambilan"].ToString());
                txt_NamaPengambil.Text = dt.Rows[0]["NamaPengambil"].ToString();
                txt_AlamatPengambil.Text = dt.Rows[0]["AlamatPengambil"].ToString();
                txt_NoKTP.Text = dt.Rows[0]["NoKTPAmbilSTNK"].ToString();
            }

            if (action == "viewBPKB")
            {
                txt_TglPengambilan.DateValue = Convert.ToDateTime(dt.Rows[0]["TglPengambilanBPKB"].ToString());
                txt_NamaPengambil.Text = dt.Rows[0]["NamaPengambil"].ToString();
                txt_AlamatPengambil.Text = dt.Rows[0]["AlamatPengambil"].ToString();
                txt_NoKTP.Text = dt.Rows[0]["NoKTPAmbilBPKB"].ToString();
            }

            if (action == "ambilSTNK")
            {
                Text = "Pengambilan STNK";
                txt_TglPengambilan.DateValue = GlobalVar.GetServerDate.Date;
                txt_NamaPengambil.Text = dt.Rows[0]["NamaPengambil"].ToString();
                txt_AlamatPengambil.Text = dt.Rows[0]["AlamatPengambil"].ToString();
                txt_NoKTP.Text = dt.Rows[0]["NoKTPAmbilSTNK"].ToString();
            
            }

            if (action == "ambilBPKB")
            {
                this.Title = "Pengambilan BPKB";
                txt_TglPengambilan.DateValue = GlobalVar.GetServerDate.Date;
                txt_NamaPengambil.Text = dt.Rows[0]["NamaPengambilBPKB"].ToString();
                txt_AlamatPengambil.Text = dt.Rows[0]["AlamatPengambilBPKB"].ToString();
                txt_NoKTP.Text = dt.Rows[0]["NoKTPAmbilBPKB"].ToString();
            }
            
            GV_Attachment.AutoGenerateColumns = false;
            if (action == "viewSTNK" || action == "viewBPKB")
            {
                txt_NamaPengambil.ReadOnly = true;
                txt_AlamatPengambil.ReadOnly = true;
                txt_NoKTP.ReadOnly = true;
                cmdSAVE.Visible = false;

                btn_AddFile.Enabled = false;
                btnDeleteFile.Enabled = false;
                
                setGV_Attachment();
                GV_Attachment.ReadOnly = true;
            }
            else
            {
                GV_Attachment.ReadOnly = false;
            }
        }

        private void setGV_Attachment()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinanceOto))
                {
                    db.Commands.Add(db.CreateCommand("usp_Attchment_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@MasterSTNKRowID", SqlDbType.UniqueIdentifier, MasterSTNKRowID));
                    if (_action == "viewBPKB")
                        db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "BPKB"));
                    else
                        db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "STNK"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                GV_Attachment.DataSource = dt;
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmMasterSTNKPengambilan_Load(object sender, EventArgs e)
        {
            if(GlobalVar.Aktif_IMG == "0")
            {
                btn_AddFile.Enabled = false;
                btnDeleteFile.Enabled = false;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String filePath = openFileDialog1.FileName;
            String fileName = openFileDialog1.SafeFileName;

            try
            {
                Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File gambar tidak dapat diproses!");
                return;
            }

            if (fileName.ToLower().EndsWith(".exe") || fileName.ToLower().EndsWith(".ws") || fileName.ToLower().EndsWith(".wsf") || fileName.ToLower().EndsWith(".bat")
                 || fileName.ToLower().EndsWith(".com") || fileName.ToLower().EndsWith(".cmd") || fileName.ToLower().EndsWith(".inf") || fileName.ToLower().EndsWith(".ins")
                 || fileName.ToLower().EndsWith(".msi") || fileName.ToLower().EndsWith(".msp") || fileName.ToLower().EndsWith(".reg") || fileName.ToLower().EndsWith(".rgs"))
            {
                MessageBox.Show("Tidak boleh mengupload data aplikasi!");
            }
            else
            {
                int i;
                bool isOK = true;
                for (i = 0; i < GV_Attachment.Rows.Count; i++)
                {
                    if (GV_Attachment.Rows[i].Cells["FileName"].Value.ToString() == fileName)
                    {
                        isOK = false;
                    }
                }

                if (isOK == false)
                {
                    MessageBox.Show("File dengan nama sama terpilih, silahkan ganti atau ubah nama file terlebih dahulu.");
                }
                else if (File.Exists(filePath))
                {
                    // kalo filenya ada, masukkin ke gridview sementara, kalau bisa path sama filenamenya dipisah
                    int lastrow = GV_Attachment.Rows.Count;
                    Guid rowID = Guid.NewGuid();

                    GV_Attachment.Rows.Add(new object[] { rowID, filePath, fileName, "Attachment Pengambilan STNK"});

                    GV_Attachment.ClearSelection();
                    GV_Attachment.Rows[GV_Attachment.Rows.Count - 1].Selected = true;
                    //GV_Attachment.Rows[lastrow].Cells["FilePath"].Value = filePath;
                    //GV_Attachment.Rows[lastrow].Cells["FileName"].Value = fileName;
                    //GV_Attachment.Rows[lastrow].Cells["Keterangan"].Value = "Attachment Pengambilan STNK";
                    //GV_Attachment.Rows[lastrow].Cells["RowID"].Value = Guid.NewGuid();
                }
                else
                {
                    MessageBox.Show("Tidak ada data terpilih.");
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (GV_Attachment.SelectedCells.Count > 0)
            {
                var confirmResult = MessageBox.Show("Yakin melakukan penghapusan daftar data file yang ingin diupload? Proses ini tidak dapat dibatalkan!",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // ambil row keberapa yang dipilih
                    int rowidx = GV_Attachment.SelectedCells[0].OwningRow.Index;
                    GV_Attachment.Rows.RemoveAt(rowidx);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu!");
            }
        }

        private bool cekSave()
        {
            bool hasil = true;

            if (txt_NamaPengambil.Text == "")
            {
                hasil = false;
                errorProvider1.SetError(txt_NamaPengambil, "Nama Pengambil harus diisi");
            }

            if (txt_AlamatPengambil.Text == "")
            {
                hasil = false;
                errorProvider1.SetError(txt_AlamatPengambil, "Alamat harus diisi");
            }

            if (txt_NoKTP.Text == "")
            {
                hasil = false;
                errorProvider1.SetError(txt_NoKTP, "nomor KTP harus diisi");
            }

            //if (txt_TglPengambilan.Text == "")
            //{
            //    hasil = false;
            //    errorProvider1.SetError(txt_TglPengambilan, "Tanggal harus diisi");
            //}
            //else if (Convert.ToDateTime(txt_TglPengambilan) < Convert.ToDateTime(GlobalVar.GetServerDate.Date))
            //{
            //    hasil = false;
            //    errorProvider1.SetError(txt_TglPengambilan, "Tanggal Pengambilan Tidak boleh kurang dari hari ini");
            //}

            return hasil;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Database db = new Database(GlobalVar.DBFinanceOto);
            try
            {
                if (!cekSave())
                {
                    return;
                }

                //DataTable dt_cek = new DataTable();
                //using (Database dbCek = new Database(GlobalVar.DBFinanceOto))
                //{
                //    dbCek.Commands.Add(db.CreateCommand("usp_MasterSTNK_CekKTP"));
                //    dbCek.Commands[0].Parameters.Add(new Parameter("@NoKTP", SqlDbType.VarChar, txt_NoKTP.Text));
                //    dt_cek = dbCek.Commands[0].ExecuteDataTable();
                //}

                //if (dt_cek.Rows.Count > 0)
                //{
                //    String stnk = "";
                //    String bpkb = "";

                //    foreach (DataRow dr in dt_cek.Rows)
                //    {
                //        if (dr["NoSTNK"].ToString() != "")
                //        {
                //            stnk += dr["NoSTNK"].ToString() + ", ";
                //        }
                //        if (dr["NoBPKB"].ToString() != "")
                //        {
                //            bpkb += dr["NoBPKB"].ToString() + ", ";
                //        }
                //    }

                //    DialogResult dialogResult = MessageBox.Show("Data pengambil pernah mengambil STNK : "+ stnk+" dan BPKB : "+bpkb+" \n Apakah anda ingin melanjutkan proses ini ?", "Warning", MessageBoxButtons.YesNo);
                //    if (dialogResult == DialogResult.No)
                //    {
                //        return;
                //    }
                //}

                int counterdb = 0;

                if (GlobalVar.Aktif_IMG == "1" && GV_Attachment.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak memiliki file attachment, silahkan pilih file yang akan di upload terlebih dahulu.");
                    return;
                }

                if (GlobalVar.Aktif_IMG == "0")
                {
                    String dirPath;
                    dirPath = GlobalVar.MasterSTNK_AttachPath + "\\";
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    if (GV_Attachment.Rows.Count > 0)
                    {
                        int rowGV = 0;
                        string NamaFileSave;

                        for (rowGV = 0; rowGV < GV_Attachment.Rows.Count; rowGV++)
                        {
                            if (_action == "ambilBPKB")
                                NamaFileSave = "BPKB_" + txt_NamaSTNK.Text + "_" + GlobalVar.GetServerDate.ToString("ddMMyyyyHHmmss") + Path.GetExtension(GV_Attachment.Rows[rowGV].Cells["FileName"].Value.ToString());
                            else
                                NamaFileSave = "STNK_" + txt_NamaSTNK.Text + "_" + GlobalVar.GetServerDate.ToString("ddMMyyyyHHmmss") + Path.GetExtension(GV_Attachment.Rows[rowGV].Cells["FileName"].Value.ToString());

                            insertAttachment(ref db, ref counterdb, GV_Attachment.Rows[rowGV].Cells["FilePath"].Value.ToString(), GV_Attachment.Rows[rowGV].Cells["FileName"].Value.ToString(),
                               dirPath, new Guid(Tools.isNull(GV_Attachment.Rows[rowGV].Cells["RowID"].Value, Guid.Empty).ToString()), GV_Attachment.Rows[rowGV].Cells["Keterangan"].Value.ToString(), NamaFileSave);
                        }

                        //ftpmanagementfile.Upload(GV_Attachment.Rows[0].Cells["FilePath"].Value.ToString(), GV_Attachment.Rows[0].Cells["FileName"].Value.ToString());
                    }
                }

                if (_action == "ambilBPKB")
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterSTNK_UpdateBPKP"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglPengambilanBPKB", SqlDbType.DateTime, txt_TglPengambilan.DateValue));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NamaPengambilBPKB", SqlDbType.VarChar, txt_NamaPengambil.Text));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@AlamatPengambilBPKB", SqlDbType.VarChar, txt_AlamatPengambil.Text));
                }
                else
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterSTNK_Update"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@TglPengambilan", SqlDbType.DateTime, txt_TglPengambilan.DateValue));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NamaPengambil", SqlDbType.VarChar, txt_NamaPengambil.Text));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@AlamatPengambil", SqlDbType.VarChar, txt_AlamatPengambil.Text));
                }
                db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, MasterSTNKRowID));
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoKTP", SqlDbType.VarChar, txt_NoKTP.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                counterdb++;
                db.BeginTransaction();
                int looper = 0;
                for (looper = 0; looper < counterdb; looper++)
                {
                    db.Commands[looper].ExecuteNonQuery();
                }
                db.CommitTransaction();
                MessageBox.Show("Data berhasil diproses");

                if (this.Caller is frmMasterSTNK)
                {
                    frmMasterSTNK frmCaller = (frmMasterSTNK)this.Caller;
                    frmCaller.RefreshData(MasterSTNKRowID);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show("Data gagal diproses !\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void insertAttachment(ref Database db, ref int counterdb, String FilePath, String FileName, String dirPath, Guid attachmentRowID, String Keterangan, String NamaFileSimpan)
        {
            //String newFileName = FileName;
            //String newFilePath = dirPath + FileName;

            String newFileName = NamaFileSimpan;
            String newFilePath = dirPath + NamaFileSimpan;


            // kalo di tempat attachment udah ada tapi sourcenya ngga ada, diemin aja 
            if (File.Exists(dirPath + NamaFileSimpan) && !File.Exists(FilePath))
            {
            }
            // kalo sourcenya ada datanya tiban aja yg di attachment
            else if (File.Exists(FilePath))
            {
                // kalo filenya udah ada
                if (File.Exists(dirPath + NamaFileSimpan))
                {
                    int i = 0;
                    for (i = 1; i < 99999; i++)
                    {
                        if (File.Exists(dirPath + NamaFileSimpan.Insert(NamaFileSimpan.IndexOf('.'), i.ToString())))
                        {
                        }
                        else
                        {
                            newFileName = NamaFileSimpan.Insert(NamaFileSimpan.IndexOf('.'), i.ToString());
                            newFilePath = dirPath + NamaFileSimpan.Insert(NamaFileSimpan.IndexOf('.'), i.ToString());
                            File.Copy(FilePath, dirPath + NamaFileSimpan.Insert(NamaFileSimpan.IndexOf('.'), i.ToString()), true);
                            i = int.MaxValue - 5;
                        }
                    }
                }
                else
                {
                    // kalo blom ada, kopi aja
                            
                    File.Copy(FilePath, dirPath + NamaFileSimpan, true);
                }
            }
            else
            {
                DataException de = new DataException("Data File tidak ditemukan baik di lokasi sumber file maupun di target pengkopian file!");
                throw de;
            }

            db.Commands.Add(db.CreateCommand("usp_Attachment_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, attachmentRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MasterSTNKRowID", SqlDbType.UniqueIdentifier, MasterSTNKRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@FilePath", SqlDbType.VarChar, newFilePath));
            db.Commands[counterdb].Parameters.Add(new Parameter("@FileName", SqlDbType.VarChar, NamaFileSimpan));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Keterangan));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void deleteAttachment(ref Database db, ref int counterdb, Guid penjualan_attachmentRowID)
        {
            //db.Commands.Add(db.CreateCommand("usp_Attachment_DELETE"));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjualan_attachmentRowID));
            //db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _rowID));
            //counterdb++;
        }

        private void GV_Attachment_SelectionChanged(object sender, EventArgs e)
        {
            if (GV_Attachment.Rows.Count > 0 && GV_Attachment.SelectedCells.Count > 0)
            {
                string Path = GV_Attachment.SelectedCells[0].OwningRow.Cells["FilePath"].Value.ToString();
                if (Path != "")
                {
                    pictureBox1.ImageLocation = Path;
                }
            }
        }
    }
}
