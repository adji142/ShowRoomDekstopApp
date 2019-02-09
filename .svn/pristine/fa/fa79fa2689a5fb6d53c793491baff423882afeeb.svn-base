using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;


namespace ISA.Showroom.Finance.HI
{
    public partial class frmUploadDKN : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();
        DataTable dtH = new DataTable();
        DataTable dtUpload;
        List<string> lstCabang = new List<string>();

        public frmUploadDKN()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate != null && rangeDateBox1.ToDate != null)
            {
                RefreshData();
            }
        }

        public void RefreshData()
        {
            try
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                if (cboCabang.SelectedValue != "") prm.Add(new Parameter("@CabangKeID", SqlDbType.VarChar, cboCabang.SelectedValue));
                prm.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                prm.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                this.Cursor = Cursors.WaitCursor;
                dt = DBTools.DBGetDataTable("usp_DKN_Upload", prm);
                dtH = DBTools.DBGetDataTable("usp_DKN_Upload_Header", prm);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = dt;
                customGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                customGridView1.DataSource = dtH;
                customGridView1.ReadOnly = false;
                customGridView1_CellEnter(null, null);
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

        private void Upload()
        {
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("Tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoDKN", "no_dkn", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("DK", "dk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("HRecordID", "idhead", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("CD", "cd", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Src", "src", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("RecordID", "iddetail", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("NoPerkiraan", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("Dari", "dari", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("Tolak", "ltolak", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Alasan", "alasan", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("HeaderRowID", "HRowID", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("RowID", "DtRowID", Foxpro.enFoxproTypes.Char, 50));

            var dataRows =
                from dataRows1 in dtH.AsEnumerable()
                join dataRows2 in dt.AsEnumerable()
                on dataRows1.Field<Guid>("GroupRowID") equals dataRows2.Field<Guid>("HeaderRowID")
                where ((bool)Tools.isNull(dataRows1["UploadKe00"],false) == true)
                select dataRows2; // + dataRows2;

            if (dataRows.Count() > 0)
            {
                dtUpload = dataRows.CopyToDataTable();
                DataTable dt1 = new DataTable();
                string fileDbf = txtFolder.Text.Trim() + "\\datahi.dbf";
                string fileZip;
                var _cabang = (from r in dtUpload.AsEnumerable() select r["Cabang"]).Distinct().ToList();
                foreach (var c in _cabang)
                {
                    IEnumerable<DataRow> dr = dtUpload.Select("Cabang='" + c + "'");
                    dt1 = dr.CopyToDataTable();
                    if (File.Exists(fileDbf)) File.Delete(fileDbf);
                    fileZip = txtFolder.Text.Trim() + "\\dkn_" + c + ".zip";
                    if (File.Exists(fileZip)) File.Delete(fileZip);
                    Foxpro.WriteFile(txtFolder.Text.Trim(), "datahi", fields, dt1, pbUpload);
                    Zip.ZipFiles(fileDbf, fileZip);
                    File.Delete(fileDbf);
                }
            }
        }

        private void frmUploadDKN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            txtFolder.Text = GlobalVar.DbfUpload;
            folderBrowserDialog1.SelectedPath = GlobalVar.DbfUpload;
            Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
            fcbo.fillComboCabang(cboCabang);
        }
        
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Upload();
                    this.Cursor = Cursors.Default;
                    //DisplayReport();
                    if ((dtUpload != null) && (dtUpload.Rows.Count > 0))
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_UPDATE_SyncFlag"));
                            Guid rowID;
                            foreach (DataRow dr in dtUpload.Rows)
                            {
                                rowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, true));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show(Messages.Confirm.ProcessFinished); // + ". Lokasi file: " + GlobalVar.DbfUpload + "\\datahi.dbf");
                    }
                    else MessageBox.Show("Tidak ada data yang diupload.");
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
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }
        }

        private void cmdLocate_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
                txtFolder.Refresh();
            }
        }

        private void customGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string groupRowID = Tools.isNull(customGridView1.SelectedCells[0].OwningRow.Cells["H_GroupRowID"].Value,Guid.Empty).ToString();
                dt.DefaultView.RowFilter = "HeaderRowID='" + groupRowID + "'";
                dataGridView1.DataSource = dt.DefaultView;
            }
        }
    }
}
