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

namespace ISA.Showroom.Finance.GL
{
    public partial class frmUploadPerkiraan : ISA.Controls.BaseForm
    {
        List<string> files = new List<string>();
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        string _CabangID;

        public frmUploadPerkiraan()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadPerkiraan()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "NoPerkTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Perkiraan"));
                if (rbChanged.Checked) db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateStart.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("ref", "ref", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 70));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hapus", "hapus", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("rowid", "rowid", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("old_perk", "old_perk", Foxpro.enFoxproTypes.Char, 12));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "NoPerkTmp", fields, dt);
        }

        private void UploadKoneksi()
        {
            DataTable dt = new DataTable();
            string Physical1 = GlobalVar.DbfUpload + "\\" + "hKoneksiTmp.DBF";
            files.Add(Physical1);
            if (File.Exists(Physical1))
            {
                File.Delete(Physical1);
            }
            string Physical2 = GlobalVar.DbfUpload + "\\" + "dKoneksiTmp.DBF";
            files.Add(Physical2);
            if (File.Exists(Physical2))
            {
                File.Delete(Physical2);
            }

            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_KoneksiHeader"));
                if (rbChanged.Checked) db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateStart.DateValue));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fieldsHd = new List<Foxpro.DataStruct>();
            fieldsHd.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 36));
            fieldsHd.Add(new Foxpro.DataStruct("RecordID", "RecordID", Foxpro.enFoxproTypes.Char, 25));
            fieldsHd.Add(new Foxpro.DataStruct("Kode", "Kode", Foxpro.enFoxproTypes.Char, 3));
            fieldsHd.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 30));
            fieldsHd.Add(new Foxpro.DataStruct("Hapus", "Hapus", Foxpro.enFoxproTypes.Numeric, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "hKoneksiTmp", fieldsHd, dt);

            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_KoneksiDetail"));
                if (rbChanged.Checked) db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateStart.DateValue));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fieldsDt = new List<Foxpro.DataStruct>();
            fieldsDt.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 36));
            fieldsDt.Add(new Foxpro.DataStruct("RecordID", "RecordID", Foxpro.enFoxproTypes.Char, 25));
            fieldsDt.Add(new Foxpro.DataStruct("HRecordID", "HrecordID", Foxpro.enFoxproTypes.Char, 25));
            fieldsDt.Add(new Foxpro.DataStruct("HeaderID", "HeaderID", Foxpro.enFoxproTypes.Char, 36));
            fieldsDt.Add(new Foxpro.DataStruct("No_perk", "No_perk", Foxpro.enFoxproTypes.Char, 12));
            fieldsDt.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 30));
            fieldsDt.Add(new Foxpro.DataStruct("Mdl", "Mdl", Foxpro.enFoxproTypes.Char, 3));
            fieldsDt.Add(new Foxpro.DataStruct("KodeTrn", "KodeTrn", Foxpro.enFoxproTypes.Char, 10));
            fieldsDt.Add(new Foxpro.DataStruct("KodeCabang", "KodeCabang", Foxpro.enFoxproTypes.Char, 4));
            fieldsDt.Add(new Foxpro.DataStruct("Hapus", "Hapus", Foxpro.enFoxproTypes.Numeric, 1));
            fieldsDt.Add(new Foxpro.DataStruct("Old_perk", "Old_perk", Foxpro.enFoxproTypes.Char, 12));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "dKoneksiTmp", fieldsDt, dt);
        }

        private void UploadDesign()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "DesignTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            DataRowView drvCabang = (DataRowView)cboCabang.Items[cboCabang.SelectedIndex];
            _CabangID = drvCabang.Row["CabangID"].ToString();
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Design"));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _CabangID));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("Report", "Report", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Ref", "Ref", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("NoUrut", "NoUrut", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Tipe", "Tipe", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 200));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 200));
            fields.Add(new Foxpro.DataStruct("Formula", "Formula", Foxpro.enFoxproTypes.Char, 200));
            fields.Add(new Foxpro.DataStruct("Lminus", "Lminus", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("TUnderLine", "TUnderLine", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("DunderLine", "DUnderLine", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Bold", "Bold", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("CabangID", "CabangID", Foxpro.enFoxproTypes.Char, 4));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "DesignTmp", fields, dt);
        }

        private void UploadProcess()
        {
            try
            {
                if (cekPerkiraan.Checked) UploadPerkiraan();
                if (cekKoneksi.Checked) UploadKoneksi();
                if (cekDisgn.Checked) UploadDesign();
                if (cekPerkiraan.Checked || cekKoneksi.Checked || cekDisgn.Checked)
                {
                    ZipFile(files);
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\NoPerk.ZIP");
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\NoPerk.zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }
            
            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DataRowView drvCabang = (DataRowView)cboCabang.Items[cboCabang.SelectedIndex];
            _CabangID = drvCabang.Row["CabangID"].ToString();
            if (cboCabang.Text != "")
            {
                UploadProcess();
                this.Close();
            }
            else MessageBox.Show("Pilih salah satu cabang!", "Perhatian!");
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            dateStart.Visible = rbChanged.Checked;
            labelStart.Visible = rbChanged.Checked;
            dateStart.DateValue = GlobalVar.GetServerDate;
            if (rbAll.Checked) dateStart.DateValue = null;
        }

        private void frmUploadPerkiraan_Load(object sender, EventArgs e)
        {
            fcbo.fillComboCabang(cboCabang);
        }


    }
}
