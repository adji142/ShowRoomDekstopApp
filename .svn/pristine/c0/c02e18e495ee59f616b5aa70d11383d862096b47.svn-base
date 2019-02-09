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
    public partial class frmUploadJournal : ISA.Controls.BaseForm
    {
        List<string> files = new List<string>();
        

        public frmUploadJournal()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUploadJournal_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox1.ToDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, DateTime.DaysInMonth(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month));
        }

        private void UploadJournal()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "TransactTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Journal"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("rowid", "rowid", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("idtrans", "idtrans", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_reff", "no_reff", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("src", "src", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));            
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hapus", "hapus", Foxpro.enFoxproTypes.Numeric, 1));            
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TransactTmp", fields, dt);
        }

        private void UploadJournalDetail()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "JournalTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_JournalDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("rowid", "rowid", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("headerrowid", "headerid", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idtrans", "idtrans", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("dk", "dk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("lsub", "lsub", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("hapus", "hapus", Foxpro.enFoxproTypes.Numeric, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "JournalTmp", fields, dt);
        }

        private void UploadClosingGL()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "TutupTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            string FromPeriode = rangeDateBox1.FromDate.Value.Year.ToString() + rangeDateBox1.FromDate.Value.Month.ToString().PadLeft(2,'0');
            string ToPeriode = rangeDateBox1.ToDate.Value.Year.ToString() + rangeDateBox1.ToDate.Value.Month.ToString().PadLeft(2,'0');
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_ClosingGL"));
                db.Commands[0].Parameters.Add(new Parameter("@FromPeriode", SqlDbType.VarChar, FromPeriode ));
                db.Commands[0].Parameters.Add(new Parameter("@ToPeriode", SqlDbType.VarChar, ToPeriode ));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                dt = db.Commands[0].ExecuteDataTable();

            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("periode", "periode", Foxpro.enFoxproTypes.Char, 6));
            fields.Add(new Foxpro.DataStruct("idcompany", "idcompany", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("kode", "kode", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("akhir", "akhir", Foxpro.enFoxproTypes.Numeric, 17));
            fields.Add(new Foxpro.DataStruct("tgl_proses", "tgl_proses", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hapus", "hapus", Foxpro.enFoxproTypes.Numeric, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TutupTmp", fields, dt);
        }

        private void UploadProcess()
        {
            try
            {
                UploadJournal();
                UploadJournalDetail();
                UploadClosingGL();
                ZipFile(files);
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\Journal_" + GlobalVar.Gudang + ".ZIP");

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\Journal_" + GlobalVar.Gudang + ".zip";

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
            UploadProcess();
            this.Close();
        }


    }
}
