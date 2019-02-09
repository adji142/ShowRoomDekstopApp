using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using ISA.Showroom.Utility;

namespace ISA.Showroom.Penjualan
{
    public partial class frmKomisiBrowse : ISA.Controls.BaseForm
    {
        Guid PJID;

        public frmKomisiBrowse()
        {
            InitializeComponent();
        }

        public frmKomisiBrowse(Guid PJRowID)
        {
            InitializeComponent();

            PJID = PJRowID;
        }

        public frmKomisiBrowse(string NoBukti)
        {
            InitializeComponent();

            txtNoBukti.Text = NoBukti;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                if (PJID == null) PJID = Guid.Empty;
                using (var db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_KomisiPenjualan_LIST]"));
                    if (PJID == Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                        if (txtNoBukti.Text.Trim() != "") db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@PJRowID", SqlDbType.UniqueIdentifier, PJID));
                        PJID = Guid.Empty;
                    }

                    DataTable dtbl = db.Commands[0].ExecuteDataTable();
                    GVMain.DataSource = dtbl.DefaultView;

                    checkBox1_CheckedChanged(null, null);
                    GVMain_SelectionRowChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReColorGridView()
        {
            foreach (DataGridViewRow cur in GVMain.Rows)
            {
                if (cur.Cells["IsFixed"].Value.ToString() == "1") cur.Cells["Status"].Style.BackColor = Color.FromArgb(201, 255, 122);
            }
        }

        private void GVMain_SelectionRowChanged(object sender, EventArgs e)
        {
            if (GVMain.SelectedCells.Count > 0)
            {
                DataGridViewRow cur = GVMain.SelectedCells[0].OwningRow;
                btnProcess.Enabled = btnEdit.Enabled = cur.Cells["IsFixed"].Value.ToString() == "0";
            }
            else btnProcess.Enabled = btnEdit.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataView cur = GVMain.DataSource as DataView;
            if (cur.Count <= 0 && cur.RowFilter == "") return;
            cur.RowFilter = checkBox1.Checked ? "IsFixed = '0'" : "";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow cur = GVMain.SelectedCells[0].OwningRow;
                using (var db = new Database())
                {
                    Guid PenjualanRowID = (Guid)cur.Cells["RowID"].Value;

                    db.Commands.Add(db.CreateCommand("[usp_Penjualan_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenjualanRowID));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();

                    if (dtbl.Rows.Count <= 0)
                    {
                        MessageBox.Show("Record penjualan tidak di temukan");

                        // refresh view
                        btnShow_Click(null, null);
                        return;
                    }
                    DataRow dcur = dtbl.Rows[0];

                    Guid MataUangRowID;
                    Guid JnsTransaksiRowID;
                    Guid PengeluaranUangRowID = Guid.NewGuid();
                    string bentukKeluaran = "K";
                    string NoTransPengeluaran = "";

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("[usp_MataUang_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, dcur["MataUangID"].ToString()));
                    DataTable tmp1 = db.Commands[0].ExecuteDataTable();
                    MataUangRowID = (Guid)tmp1.Rows[0]["RowID"];

                    using (var fdb = new Database(GlobalVar.DBFinanceOto))
                    {
                        NoTransPengeluaran = Numerator.GetNomorDokumen(fdb, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + bentukKeluaran + "K/" + string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);

                        fdb.Commands.Clear();
                        fdb.Commands.Add(fdb.CreateCommand("[usp_JnsTransaksi_LIST]"));
                        fdb.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                        fdb.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLABiayaKomisi).ToString()));
                        tmp1 = fdb.Commands[0].ExecuteDataTable();
                        JnsTransaksiRowID = (Guid)tmp1.Rows[0]["RowID"];

                        // force validate record not yet processed
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("[usp_KomisiPenjualan_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@PJRowID", SqlDbType.UniqueIdentifier, PenjualanRowID));
                        tmp1 = db.Commands[0].ExecuteDataTable();

                        if (tmp1.Rows.Count <= 0)
                        {
                            MessageBox.Show("Record penjualan tidak di temukan");

                            // refresh view
                            btnShow_Click(null, null);
                            return;
                        }
                        else if (tmp1.Rows[0]["IsFixed"].ToString() == "1")
                        {
                            MessageBox.Show("Penjualan telah di proses, tidak dapat di proses ulang");

                            // refresh view
                            btnShow_Click(null, null);
                            return;
                        }

                        // sensitive query
                        db.BeginTransaction();
                        fdb.BeginTransaction();

                        // sensitive case, double wrap
                        try
                        {
                            fdb.Commands.Clear();
                            fdb.Commands.Add(fdb.CreateCommand("[usp_PengeluaranUang_INSERT_SIMPLE]"));
                            fdb.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.GetServerDate));
                            fdb.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate));
                            fdb.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, string.Empty));
                            fdb.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, string.Empty));
                            fdb.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPengeluaran));
                            fdb.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, DBNull.Value));
                            fdb.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, MataUangRowID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, JnsTransaksiRowID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, dcur["BiayaKomisi"]));
                            fdb.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, dcur["BiayaKomisi"]));
                            fdb.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Biaya Komisi"));
                            fdb.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9));
                            fdb.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukKeluaran));
                            fdb.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty));
                            fdb.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID));
                            fdb.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2));
                            fdb.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            fdb.Commands[0].ExecuteNonQuery();

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("[usp_Penjualan_UPDATE_KomisiADD]"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjualanRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Komisi", SqlDbType.Money, dcur["BiayaKomisi"]));
                            db.Commands[0].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, PengeluaranUangRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                            // flush query if all done good
                            db.CommitTransaction();
                            fdb.CommitTransaction();

                            // refresh view
                            btnShow_Click(null, null);
                        }
                        catch (Exception ex2)
                        {
                            // rollback if something happen
                            db.RollbackTransaction();
                            fdb.RollbackTransaction();

                            MessageBox.Show("Gagal, pesan error:\n" + ex2.Message);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal, pesan error:\n" + ex.Message);

                // refresh view, reduce fail data because record has updated by others
                btnShow_Click(null, null);
            }
        }

        InPopup pKomisiEdit;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (pKomisiEdit == null) pKomisiEdit = new InPopup(this, pnlEditKomisi);
            if (GVMain.SelectedCells.Count <= 0) return;

            DataGridViewRow cur = GVMain.SelectedCells[0].OwningRow;
            txtEditNoTransaksi.Text = cur.Cells["NoTransaksi"].Value.ToString();
            txtEditNoBukti.Text = cur.Cells["NoBukti"].Value.ToString();
            txtEditKomisiBefore.Text = cur.Cells["Nominal"].Value.ToString();
            txtEditKomisiAfter.Text = "0";

            pKomisiEdit.Open(this, (r) =>
            {
                if (r) // OK
                {
                    try
                    {
                        if (double.Parse(txtEditKomisiAfter.Text) == 0)
                        {
                            if (MessageBox.Show(this, "Yakin biaya komisi 0, berarti tidak ada komisi?", "Edit Komisi", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }

                        using (var db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_KomisiPenjualan_EDIT"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, (Guid)cur.Cells["RowID"].Value));
                            db.Commands[0].Parameters.Add(new Parameter("@BiayaKomisi", SqlDbType.Money, double.Parse(txtEditKomisiAfter.Text)));

                            DataTable dtbl = db.Commands[0].ExecuteDataTable();
                            if (dtbl.Rows.Count > 0)
                            {
                                DataRow dcur = dtbl.Rows[0];
                                if (dcur["Result"].ToString() == "1")
                                {
                                    MessageBox.Show(this, "Komisi telah berhasil di update");
                                    btnShow_Click(null, null);
                                }
                                else MessageBox.Show(this, "Gagal,\n" + dcur["Msg"]);
                            }
                            else MessageBox.Show(this, "Gagal");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message);
                    }
                }
            });
            txtEditKomisiAfter.Focus();
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            if (sender == btnEditOK)
            {
                pKomisiEdit.Close((txtEditKomisiBefore.Text != txtEditKomisiAfter.Text));
            }
            else if (sender == btnEditCancel)
            {
                pKomisiEdit.Close(false);
            }
        }

        private void frmKomisiBrowse_Load(object sender, EventArgs e)
        {
            DateTime now = GlobalVar.DateOfServer;
            DateTime tmp = DateTime.Parse(now.ToString("yyyy-MM") + "-01");
            rangeDateBox1.FromDate = tmp;
            tmp = tmp.AddMonths(1);
            tmp = tmp.AddDays(-1);
            rangeDateBox1.ToDate = tmp;

            btnShow_Click(null, null);
        }

        private void GVMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (var i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                DataGridViewRow cur = GVMain.Rows[i];
                if (cur.Cells["IsFixed"].Value.ToString() == "1") cur.Cells["Status"].Style.BackColor = Color.FromArgb(201, 255, 122);
                else cur.Cells["Status"].Style.BackColor = Color.FromArgb(255, 204, 204);
            }
        }
    }
}
