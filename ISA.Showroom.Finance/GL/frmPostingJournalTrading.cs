using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmPostingJournalTrading : ISA.Controls.BaseForm
    {
        DateTime TglProses = GlobalVar.GetServerDate;
        public frmPostingJournalTrading()
        {
            InitializeComponent();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdREFRESH_Click(object sender, EventArgs e)
        {
            if (dateTglProses.DateValue.ToString() != "")
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_HutangPembelian_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTglProses.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                    dtHeaderPBI.DataSource = dt;

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_HutangPembelian_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTglProses.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Journal", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dtJournalPBI.DataSource = dt;

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_IdentifikasiHutang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTglProses.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                    dtHeaderINI.DataSource = dt;

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_IdentifikasiHutang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTglProses.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Journal", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dtJournalINI.DataSource = dt;

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_RevaluasiHutang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTglProses.DateValue));
                    dt = db.Commands[0].ExecuteDataTable();
                    dtHeaderRVI.DataSource = dt;

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_RevaluasiHutang_LIST_FILTER_Tanggal"));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dateTglProses.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Journal", SqlDbType.Bit, 1));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dtJournalRVI.DataSource = dt;
                }
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if ((dtJournalPBI != null) && (dtJournalPBI.Rows.Count > 0))
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PostingJournalTrading"));
                    foreach (DataGridViewRow dr in dtJournalPBI.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dr.Cells["TanggalPBI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, dr.Cells["NoReffPBI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, dr.Cells["NoPerkiraanPBI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dr.Cells["UraianPBI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, dr.Cells["DebetPBI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, dr.Cells["KreditPBI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "PBI"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, dr.Cells["MataUangRowID_PBI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalOri", SqlDbType.Money, dr.Cells["OriginalAmountPBI"].Value));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            if ((dtJournalINI != null) && (dtJournalINI.Rows.Count > 0))
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PostingJournalTrading"));
                    foreach (DataGridViewRow dr in dtJournalINI.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dr.Cells["TanggalINI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, dr.Cells["NoReffINI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, dr.Cells["NoPerkiraanINI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dr.Cells["UraianINI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, dr.Cells["DebetINI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, dr.Cells["KreditINI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "INI"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, dr.Cells["MataUangRowID_INI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalOri", SqlDbType.Money, dr.Cells["OriginalAmountINI"].Value));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            if ((dtJournalRVI != null) && (dtJournalRVI.Rows.Count > 0))
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PostingJournalTrading"));
                    foreach (DataGridViewRow dr in dtJournalRVI.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dr.Cells["TanggalRVI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReff", SqlDbType.VarChar, dr.Cells["NoReffRVI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, dr.Cells["NoPerkiraanRVI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, dr.Cells["UraianRVI"].Value.ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, dr.Cells["DebetRVI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, dr.Cells["KreditRVI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, "RVI"));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, dr.Cells["MataUangRowID_RVI"].Value));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalOri", SqlDbType.Money, dr.Cells["OriginalAmountRVI"].Value));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            this.Close();
        }
    }
}
