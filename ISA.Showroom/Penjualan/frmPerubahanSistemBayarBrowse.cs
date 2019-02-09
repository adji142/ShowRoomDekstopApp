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
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPerubahanSistemBayarBrowse : ISA.Controls.BaseForm
    {
        public frmPerubahanSistemBayarBrowse()
        {
            InitializeComponent();
        }

        public void RefreshGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST_UbahSistemBayar"));
                dt = db.Commands[0].ExecuteDataTable();
                dgPenjualan.DataSource = dt;
            }
            this.Cursor = Cursors.Default;
        }

        private void frmPerubahanSistemBayarBrowse_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            cmdTUNkeCTP.Enabled = false;
            cmdUbahKeKredit.Enabled = false;
            cmdUbahKeLeasing.Enabled = false;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUbahKeLeasing_Click(object sender, EventArgs e)
        {
            if (dgPenjualan.SelectedCells.Count > 0)
            {
                String kodeTransPJL = dgPenjualan.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value.ToString().Trim().ToUpper();
                Guid PenjRowID = new Guid (dgPenjualan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                if (kodeTransPJL == "LSG")
                {
                }
                else
                {
                    Penjualan.frmPerubahanSistemKeLeasing ifrmChild = new Penjualan.frmPerubahanSistemKeLeasing(this, PenjRowID);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }
            }
        }

        private void cmdUbahKeKredit_Click(object sender, EventArgs e)
        {
            if (dgPenjualan.SelectedCells.Count > 0)
            {
                String kodeTransPJL = dgPenjualan.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value.ToString().Trim().ToUpper();
                Guid PenjRowID = new Guid(dgPenjualan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                
                if (kodeTransPJL == "FLT")
                {
                }
                else
                {
                    Penjualan.frmPerubahanSistemKeKredit ifrmChild = new Penjualan.frmPerubahanSistemKeKredit(this, PenjRowID);
                    Program.MainForm.CheckMdiChildren(ifrmChild);
                }

            }
        }

        private void dgPenjualan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPenjualan.SelectedCells.Count > 0)
            {
                String kodeTransPJL = dgPenjualan.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value.ToString().Trim().ToUpper();
                DateTime TglJual = Convert.ToDateTime(dgPenjualan.SelectedCells[0].OwningRow.Cells["TglJual"].Value.ToString());
                if (GlobalVar.GetServerDate > TglJual.AddDays(30)) // lebih dari 1 bulan ngga boleh ngapa2in
                {
                    cmdUbahKeKredit.Enabled = false;
                    cmdUbahKeLeasing.Enabled = false;
                }
                else if (kodeTransPJL == "FLT")
                {
                    cmdUbahKeKredit.Enabled = false;
                    cmdUbahKeLeasing.Enabled = true;
                }
                else if (kodeTransPJL == "LSG")
                {
                    cmdUbahKeKredit.Enabled = true;
                    cmdUbahKeLeasing.Enabled = false;
                }
                else
                {
                    cmdUbahKeKredit.Enabled = true;
                    cmdUbahKeLeasing.Enabled = true;
                }
                if (kodeTransPJL == "TUN")
                {
                    cmdTUNkeCTP.Enabled = true;
                    cmdTUNkeCTP.Visible = true;
                }
                else
                {
                    cmdTUNkeCTP.Enabled = false;
                    cmdTUNkeCTP.Visible = false;
                }

            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cmdTUNkeCTP_Click(object sender, EventArgs e)
        {
            if (dgPenjualan.SelectedCells.Count > 0)
            {
                String kodeTransPJL = dgPenjualan.SelectedCells[0].OwningRow.Cells["KodeTransPJL"].Value.ToString().Trim().ToUpper();
                Guid PenjRowID = new Guid(dgPenjualan.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                if (kodeTransPJL == "TUN")
                {
                    if (MessageBox.Show("Anda yakin akan mengubah data penjualan Cash Keras ini menjadi Cash Tempo ?", Messages.Question.AskSave, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (Database db = new Database())
                        {
                            db.BeginTransaction();
                            int counterdb = 0;
                            try
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenjualanLog_INSERT_UbahSistemBayar"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTransNew", SqlDbType.VarChar, "CTP"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@Logtype", SqlDbType.VarChar, "Koreksi PJL"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@LogDescription", SqlDbType.VarChar, "Perubahan Sistem Bayar dari : TUN menjadi CTP"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[counterdb].ExecuteNonQuery();
                                counterdb++;


                                db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_SistemBayar"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjRowID));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTransNew", SqlDbType.VarChar, "CTP"));
                                db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[counterdb].ExecuteNonQuery();
                                counterdb++;
                                db.CommitTransaction();
                            }
                            catch (Exception ex)
                            {
                                db.RollbackTransaction();
                                MessageBox.Show("Terjadi Error : " + ex.Message);
                            }
                        }
                        RefreshGrid();
                    }
                }
            }
        }
    }
}
