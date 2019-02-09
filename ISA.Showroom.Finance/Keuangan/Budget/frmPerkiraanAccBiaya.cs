using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.IO;
using ISA.Common;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Keuangan.Budget
{
    public partial class frmPerkiraanAccBiaya : ISA.Controls.BaseForm
    {
        enum enumModus { Clear, New, Update }
        enumModus Modus;
        List<string> files = new List<string>();

        public frmPerkiraanAccBiaya()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region functions
        private void SetupEnableDisable()
        {
            panel1.Enabled = Modus != enumModus.Clear;
            cmdADD.Enabled = Modus == enumModus.Clear;
            cmdEDIT.Enabled = Modus == enumModus.Clear && dgPerkiraan.SelectedCells.Count > 0;
            cmdDELETE.Enabled = Modus == enumModus.Clear && dgPerkiraan.SelectedCells.Count > 0;
            cmdSAVE.Enabled = Modus != enumModus.Clear;
            cmdCANCEL.Enabled = Modus != enumModus.Clear;
            cmdUPLOAD.Enabled = Modus == enumModus.Clear;
        }
        private void RefreshGrid()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Tabel_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                dgPerkiraan.DataSource = dt;
            }
        }
        private void RefreshText()
        {
            if (dgPerkiraan.SelectedCells.Count > 0)
            {
                lookupPerkiraan1.NoPerkiraan = dgPerkiraan.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                lookupPerkiraan1.NamaPerkiraan = dgPerkiraan.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
            }
        }
        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\tbKodePerkiraanACCBiaya.zip";
            if (File.Exists(fileZipName)) File.Delete(fileZipName);
            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str)) File.Delete(str);
            }
        }
        #endregion

        private void frmPerkiraanAccBiaya_Load(object sender, EventArgs e)
        {
            SetupEnableDisable();
            RefreshGrid();
            RefreshText();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            Modus = enumModus.New;
            lookupPerkiraan1.NoPerkiraan = "";
            lookupPerkiraan1.NamaPerkiraan = "";
            SetupEnableDisable();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Update;
            SetupEnableDisable();
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin akan menghapus data ini?", "Hapus data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Guid _RowID = (Guid)dgPerkiraan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_AccBy_Tabel_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                Modus = enumModus.Clear;
                SetupEnableDisable();
                RefreshGrid();
                RefreshText();
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            string _NoPerkiraan = lookupPerkiraan1.NoPerkiraan;
            string _Uraian = lookupPerkiraan1.NamaPerkiraan;
            Guid _RowID = Guid.Empty;
            if (Modus == enumModus.Update) _RowID = (Guid)dgPerkiraan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Tabel_UPDATE"));
                if (Modus == enumModus.Update) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerkiraan));
                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, _Uraian));
                db.Commands[0].ExecuteNonQuery();
            }
            Modus = enumModus.Clear;
            SetupEnableDisable();
            RefreshGrid();
            RefreshText();
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetupEnableDisable();
            RefreshText();
        }

        private void dgPerkiraan_SelectionChanged(object sender, EventArgs e)
        {
            SetupEnableDisable();
            RefreshText();
        }

        private void cmdUPLOAD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "BiayaTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical)) File.Delete(Physical);
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("psp_AccBy_UPLOAD_Perkiraan"));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("no_perk", "No_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("uraian", "Uraian", Foxpro.enFoxproTypes.Char, 70));
            fields.Add(new Foxpro.DataStruct("rowid", "RowID", Foxpro.enFoxproTypes.Char, 36));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "BiayaTmp", fields, dt);

            ZipFile(files);
            MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\tbKodePerkiraanACCBiaya.zip");
        }
    }
}
