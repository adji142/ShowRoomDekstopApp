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

namespace ISA.Showroom.Finance.HI
{
    public partial class frmDonwloadDKN : ISA.Controls.BaseForm
    {
        DataTable tblHeader;
        DataTable dtSdhDownload;
        //Class.clsDKN00 dkn00;
        enum enumDKN00State { Download, Input }
        enumDKN00State _state = enumDKN00State.Download;

        public frmDonwloadDKN()
        {
            InitializeComponent();
        }


        private String GetExtensiFile(String Filename)
        {
            String Ext=String.Empty;
            int FileNameLength = Filename.Length;
            Ext = Filename.Substring(FileNameLength - 4, 4);
            return Ext;
        }


        private void ExtractDataZip()
        {
           int FileNameLength= txtFileName.Text.Length;
           string extensiFileName = txtFileName.Text.Substring(FileNameLength - 4, 4);
           string FileName = txtFileName.Text.Substring(0, FileNameLength - 4);
           string Path = String.Concat(FileName, "\\datahi.dbf");
           Zip.UnZipFiles(txtFileName.Text, FileName, false);

           ExtractData(Path);
        }


        private void Extract(String ExtFile,String FileName)
        {
            switch (ExtFile)
            {
                case ".ZIP":
                    {
                        ExtractDataZip();
                        break;
                    }
                case ".DBF":
                    {
                        ExtractData(FileName);
                        break;
                    }
            }
        }

        private void ExtractData(String FileName)
        {
           // string fileNameH = txtFileName.Text; // "datahi.dbf";

//            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            if (File.Exists(FileName))
            {
                try
                {
                    tblHeader = Foxpro.ReadFile(FileName);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    dataGridView1.DataSource = tblHeader;
                    dataGridView1.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // ADP
                    dataGridView1.Columns["jumlah"].DefaultCellStyle.Format = "N2"; // ADP
                    label3.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
                    //this.Title = fileNameH;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        public string Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            dtSdhDownload = tblHeader.Clone();

            DataTable dt = new DataTable();
//            int result = 0;
            string _dk = "";
            object rslt = null;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.BeginTransaction();
                // HEADERS
                db.Commands.Add(db.CreateCommand("usp_DKN_Download"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    try
                    {
                        //add parameters
                        _dk = (Tools.isNull(dr["dk"], "").ToString()=="D") ? "K" : "D"; 
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idhead"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddetail"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dr["tanggal"]));
                        db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, Tools.isNull(dr["no_dkn"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, _dk));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cabang"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CD", SqlDbType.VarChar, Tools.isNull(dr["cd"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr["src"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, (dr["jumlah"])));
                        db.Commands[0].Parameters.Add(new Parameter("@Dari", SqlDbType.VarChar, Tools.isNull(dr["dari"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tolak", SqlDbType.Bit, (dr["ltolak"])));
                        db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["alasan"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        //transaksi per record ?
                        //result = db.Commands[0].ExecuteNonQuery();
                        rslt = db.Commands[0].ExecuteScalar();
                        //result = int.Parse(rslt.ToString());
                        //grid and form status
                        if (Tools.isNull(rslt, "").ToString() == "Ok")
                        {
                            dr["cUploaded"] = true;
                            counter++;
                            progressBar1.Increment(1);
                            label3.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                        else break;
                    }
                    catch (Exception ex)
                    {
                        rslt = "Catch error : " + ex.Message;
                        MessageBox.Show(rslt.ToString());
                        break;
                    }
                }
                if (Tools.isNull(rslt, "").ToString() == "Ok") db.CommitTransaction(); else db.RollbackTransaction();
            }
            return Tools.isNull(rslt,"").ToString();
        }        

        private void frmDonwloadDKN_Load(object sender, EventArgs e)
        {
            txtFileName.Text = GlobalVar.DbfDownload + "\\datahi.dbf";
            openFileDialog1.InitialDirectory = GlobalVar.DbfDownload;
            openFileDialog1.Filter = "ZIP Files|*.zip|DBF Files|*.dbf";
            //ExtractData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDwnld_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download DKN ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    ISA.Showroom.Finance.BLL.CommonObject.UserObject _userObject = new ISA.Showroom.Finance.BLL.CommonObject.UserObject();
                    _userObject.CabangID = GlobalVar.CabangID;
                    _userObject.SelectedPerusahaanRowID = GlobalVar.PerusahaanRowID;
                    _userObject.UserID = SecurityManager.UserID;
                    //string result = ISA.Showroom.Finance.BLL.clsHI11.DKN00To11(tblHeader,_userObject);
                    string result = string.Empty;
                    if (GlobalVar.IsNewDNKN)
                    {
                        result = ISA.Showroom.Finance.BLL.clsHI11.DKN00To11_new(tblHeader, _userObject, true);
                    }
                    else
                    {
                        result = ISA.Showroom.Finance.BLL.clsHI11.DKN00To11(tblHeader, _userObject);
                    }
                        //Download();
                    MessageBox.Show((result=="Ok")?Messages.Confirm.DownloadSuccess:"Gagal : ("+result.ToString()+")");

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmdTolak_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataRow dr = (DataRow)(dataGridView1.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                bool _tolak = (bool)Tools.isNull(dr["ltolak"], "false");
                string _hrecordid = Tools.isNull(dr["idhead"], "").ToString();
                foreach (DataRow d in tblHeader.Rows)
                {
                    if (Tools.isNull(d["idhead"], "").ToString() == _hrecordid) d["ltolak"] = !_tolak;
                }
                dataGridView1.Refresh();
                cmdTolak.Text = (_tolak)?"Ditolak":"Diterima";
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                bool _tolak = (bool)Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["ltolak"].Value, false);
                cmdTolak.Text = (_tolak) ? "DITERIMA" : "DITOLAK" ;
                cmdTolak.Visible = true;
            }
            else cmdTolak.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
                txtFileName.Refresh();
                String extFile = GetExtensiFile(txtFileName.Text);
                Extract(extFile, txtFileName.Text.Trim());
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (tblHeader==null)
            {
                tblHeader = Class.clsDKN00.CreateDataTable(); //ADP
                //tblHeader.Rows.Add();
                dataGridView1.DataSource = tblHeader; //ADP
            }
            Class.clsDKN00 _dkn00 = new Class.clsDKN00();
            string nodkn = "";
            if (dataGridView1.Rows.Count > 0)
            {
                nodkn = Tools.isNull(((dataGridView1.SelectedCells.Count > 0) ?
                    dataGridView1.SelectedCells[0].OwningRow.Cells["no_dkn"].Value :
                    dataGridView1.Rows[0].Cells["no_dkn"].Value), "").ToString();
            }
            DKN.frmDownloadDKNUpdate ifrm = new DKN.frmDownloadDKNUpdate(tblHeader,nodkn);

            ifrm.ShowDialog() ;
            if (ifrm.DialogResult == DialogResult.OK)
            {
                _state = enumDKN00State.Input;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if ((_state == enumDKN00State.Input) && dataGridView1.SelectedCells.Count>0)
            {
                string id = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["iddetail"].Value,"").ToString();
                if (id.Substring(0,3) == GlobalVar.PerusahaanID) // ADP
                {
                    if (!string.IsNullOrEmpty(id))
                        foreach (DataRow dr in tblHeader.Rows)
                        {
                            if (dr["iddetail"].ToString() == id)
                            {
                                DKN.frmDownloadDKNUpdate ifrm = new ISA.Showroom.Finance.DKN.frmDownloadDKNUpdate(dr);
                                ifrm.ShowDialog();
                                break;
                            }
                        }
                }
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            DKN.frmDownloadDKNUpdate2 ifm = new ISA.Showroom.Finance.DKN.frmDownloadDKNUpdate2();
            ifm.ShowDialog();
        }

    }
}
