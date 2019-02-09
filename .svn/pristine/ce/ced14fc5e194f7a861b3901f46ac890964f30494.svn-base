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
using System.Globalization;
using System.IO;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPenjualanBrowseAttachment : ISA.Controls.BaseForm
    {
        Guid _penjRowID;
        String _dirPath;
        public frmPenjualanBrowseAttachment()
        {
            InitializeComponent();
        }

        public frmPenjualanBrowseAttachment(Form caller, Guid PenjRowID, String dirPath)
        {
            InitializeComponent();
            Caller = caller;
            _penjRowID = PenjRowID;
            _dirPath = dirPath;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenjualanBrowseAttachment_Load(object sender, EventArgs e)
        {
            cmdOPENIMAGE.Enabled = false;
            cmdSAVE.Enabled = false;
            dgAttachment.AutoGenerateColumns = false;
            using (Database db = new Database())
            {
                DataTable dummy = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Penjualan_Attachment_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                dgAttachment.DataSource = dummy;

                if (dummy.Rows.Count > 0)
                {
                }
                else
                {
                    MessageBox.Show("Tidak Ada Data Attachment!");
                    //this.Close();
                }

            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if(dgAttachment.SelectedCells.Count > 0)
            {
                folderBrowserDialog1.ShowDialog();
                if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                {
                    String targetDir = folderBrowserDialog1.SelectedPath;
                    String tempPath, tempName;
                    try
                    {
                        tempPath = dgAttachment.SelectedCells[0].OwningRow.Cells["FilePath"].Value.ToString();
                        tempName = dgAttachment.SelectedCells[0].OwningRow.Cells["FileName"].Value.ToString();

                        // file barusan langsung copy aja ke tempat yg baru
                        File.Copy(tempPath, targetDir + "\\" + tempName, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi Error !\n" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Lokasi yg dipilih tidak ditemukan!");
                    return;
                }
            }
        }

        private void cmdOPENIMAGE_Click(object sender, EventArgs e)
        {
            if (dgAttachment.SelectedCells.Count > 0)
            {
                String tempPath, tempName;
                try
                {
                    tempPath = dgAttachment.SelectedCells[0].OwningRow.Cells["FilePath"].Value.ToString();
                    tempName = dgAttachment.SelectedCells[0].OwningRow.Cells["FileName"].Value.ToString();
                    Image tobeOpened = Image.FromFile(tempPath);

                    Showroom.Controls.frmViewImage ifrmChild = new Showroom.Controls.frmViewImage(this, tobeOpened);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi Error !\n" + ex.Message);
                }
            }
        }

        private void dgAttachment_Click(object sender, EventArgs e)
        {

            if (dgAttachment.SelectedCells.Count > 0)
            {
                try
                {
                    // coba tes open image nya nanti error ngga, kalau bukan image, ngga usah di enable buttonnya
                    cmdOPENIMAGE.Enabled = true;
                    cmdSAVE.Enabled = true;

                    String tempPath = dgAttachment.SelectedCells[0].OwningRow.Cells["FilePath"].Value.ToString();
                    Image tobeOpened = Image.FromFile(tempPath);
                }
                catch (Exception ex)
                {
                    // kalo ada error berarti bukan gambar
                    cmdOPENIMAGE.Enabled = false;
                }
            }
        }

    }
}
