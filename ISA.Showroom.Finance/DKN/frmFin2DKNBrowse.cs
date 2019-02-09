using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmFin2DKNBrowse : ISA.Controls.BaseForm
    {
        enum enumJenisArusUang { Penerimaan, Pengeluaran };

        public frmFin2DKNBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFin2HIBrowse_Load(object sender, EventArgs e)
        {
            rgtgTransaksi.FromDate = (DateTime)Tools.DBGetScalar("usp_GetPostDatedLock", new List<Parameter>());
            rgtgTransaksi.ToDate = (DateTime)Tools.DBGetScalar("usp_GetBackDatedLock", new List<Parameter>());
            DataTable dtHI = DBTools.DBGetDataTable("usp_KelompokTransaksiHI_LIST", new List<Parameter>());
            dsHI.Tables["KelompokTransaksiHI"].Load(dtHI.CreateDataReader());
            RefreshData(); 
        }

        #region User Defined Functions 
        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    DataTable dtHI = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_FIN2HI_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.Date, rgtgTransaksi.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.Date, rgtgTransaksi.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();

                    //db.Commands.Add(db.CreateCommand("usp_KelompokTransaksiHI_LIST"));
                    //dtHI = db.Commands[1].ExecuteDataTable();

                    dt.Columns.Add(new DataColumn("Proses", typeof(bool)));
                    //dt.Columns.Add("KelompokHI", typeof(string));
                    dt.Columns.Add("KelompokHIRowID", typeof(Guid));
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //dataGridView1.ReadOnly = false;
                }
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
        #endregion

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
//                int n = 0;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    //bool proses = (bool)Tools.isNull(dr.Cells["Proses"].Value, false);
                    //if (proses == true)
                    //{
                        string jnsArus = Tools.isNull(dr.Cells["JnsArus"].Value, "").ToString();
                        string cStrCmd = "";
                        switch (jnsArus)
                        {
                            case "Penerimaan ":
                                {
                                    cStrCmd = "psp_TarikPenerimaan_ke_HI";
                                }
                                break;
                            case "Pengeluaran":
                                {
                                    cStrCmd = "psp_TarikPengeluaran_ke_HI";
                                }
                                break;
                        }

                        if (cStrCmd != "")
                        {
                            try
                            {
                                Guid rowID = (Guid)Tools.isNull(dr.Cells["RowID"].Value, Guid.Empty);
                                Guid kelompokHIRowID = (Guid)Tools.isNull(dr.Cells["KelompokHIRowID"].Value, Guid.Empty);
                                if (kelompokHIRowID != Guid.Empty)
                                {
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Add(db.CreateCommand(cStrCmd));
                                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                        db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiHIRowID", SqlDbType.UniqueIdentifier, kelompokHIRowID));
                                        DataTable dt = db.Commands[0].ExecuteDataTable();
                                        if ((dt.Rows.Count > 0) && (dt.Rows[dt.Rows.Count - 1][0].ToString() != "Ok"))
                                            MessageBox.Show("Error No.Bukti : " + dr.Cells["NoBukti"].Value.ToString() +
                                                            " \nError No. :  " + dt.Rows[0][0].ToString());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                    //} 
                } 
            }
            RefreshData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataRow[] dr = dsHI.Tables["KelompokTransaksiHI"].Select("KodeKelompok='" + e.KeyChar.ToString() + "'");
            if ((dr != null)&&(dr.Length>0)) dataGridView1.SelectedCells[0].OwningRow.Cells["KelompokHIRowID"].Value = dr[0]["RowID"];
            
        }
    }
}
