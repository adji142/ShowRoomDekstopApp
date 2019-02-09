using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using System.Data.SqlTypes;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmHutangLainLain_Browse : ISA.Controls.BaseForm
    {
        #region Var
        enum enumSelectedGrid { Header, Detail };
        DataTable dtHeaderA = new DataTable(), dtDetailA1 = new DataTable(), dtDetailA2 = new DataTable();
        DataTable dtHeaderB = new DataTable(), dtDetailB1 = new DataTable(), dtDetailB2 = new DataTable();
        DataTable dtHeaderC = new DataTable(), dtDetailC1 = new DataTable(), dtDetailC2 = new DataTable();
        DataTable dtHeaderD = new DataTable(), dtDetailD1 = new DataTable(), dtDetailD2 = new DataTable();
        enumSelectedGrid SelectedGridA = enumSelectedGrid.Header;
        enumSelectedGrid SelectedGridB = enumSelectedGrid.Header;
        enumSelectedGrid SelectedGridC = enumSelectedGrid.Header;
        enumSelectedGrid SelectedGridD = enumSelectedGrid.Header;
        private void InitTotal()
        {
            dtDetailA2.Clear();
            dtDetailA2.Dispose();
            dtDetailA2 = new DataTable();
            dtDetailA2.Columns.Add("MataUangID", typeof(string));
            dtDetailA2.Columns.Add("Nominal", typeof(double));

            dtDetailB2.Clear();
            dtDetailB2.Dispose();
            dtDetailB2 = new DataTable();
            dtDetailB2.Columns.Add("MataUangID", typeof(string));
            dtDetailB2.Columns.Add("Nominal", typeof(double));

            dtDetailC2.Clear();
            dtDetailC2.Dispose();
            dtDetailC2 = new DataTable();
            dtDetailC2.Columns.Add("MataUangID", typeof(string));
            dtDetailC2.Columns.Add("Nominal", typeof(double));

            dtDetailD2.Clear();
            dtDetailD2.Dispose();
            dtDetailD2 = new DataTable();
            dtDetailD2.Columns.Add("MataUangID", typeof(string));
            dtDetailD2.Columns.Add("Nominal", typeof(double));


        }

        #endregion

        private void SetError(Control ctrl, string Pesan)
        {
            ErrorProvider err = new ErrorProvider();
            err.SetError(ctrl, Pesan);

        }

        #region Tab1

        private void GetDataHeaderA(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtHeaderA = Class.clsHutangLain2.GetHLLHeader(fromDate_, toDate_);
                GVHeaderA.DataSource = dtHeaderA.DefaultView;
                if (GVHeaderA.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderA.SelectedCells[0].OwningRow.Cells["RowIDHeaderA"].Value;
                    GetPengeluaranA(HeaderID_);
                }
                else
                {
                    dtDetailA1.Rows.Clear();
                    dtDetailA2.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetPengeluaranA(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetailA1 = Class.clsHutangLain2.GetHLLDetail(HeaderID_);
                dtDetailA1.DefaultView.Sort = "Tanggal DESC,NoBukti ASC";
                GVDetailA.DataSource = dtDetailA1.DefaultView;
                DataTable dt = dtDetailA1.Copy();
                GetTotalPengeluaranA(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetTotalPengeluaranA(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetailA2.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetailA2.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetailA2.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetailA2.Rows.Add(drr);
                }
                dtDetailA2.AcceptChanges();
                GVDetailAA.DataSource = dtDetailA2.DefaultView;
            }
        }

        public void RefreshRowDataGridHeaderA(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewaAntarPTMINUS_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                GVHeaderA.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeaderA.FindRow("RowIDHeaderA", rowID_.ToString());
                dtHeaderA.AcceptChanges();

            }
        }

        public void RefreshRowDataGridDetailA(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh;

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_Filter_HI]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                RefreshRowDataGridHeaderA((Guid)dtRefresh.Rows[0]["HiRowID"]);

                GVDetailA.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetailA.FindRow("RowIDDetailA", rowID_.ToString());
                dtDetailA1.AcceptChanges();
                GVDetailA.DataSource = dtDetailA1.DefaultView;
                DataTable dt = dtDetailA1.Copy();
                GetTotalPengeluaranA(dt);

            }
        }

        private List<int> ParameterKuncian()
        {
            List<int> _parameterkuncian = new List<int>();
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Lock"));
                dt = db.Commands[0].ExecuteDataTable();
                _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);
                _parameterkuncian.Add((int)dt.Rows[0]["PostdatedLock"]);

            }
            return _parameterkuncian;
        }

        private void DeleteDetailA()
        {

            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVDetailA.SelectedCells[0].OwningRow.Cells["JournalRowIDDetail1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVDetailA.SelectedCells[0].OwningRow.Cells["TglInputA"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }


            Guid rowID_ = (Guid)GVDetailA.SelectedCells[0].OwningRow.Cells["RowIDDetailA"].Value;
            Guid HeaderIDA_ = (Guid)GVDetailA.SelectedCells[0].OwningRow.Cells["HeaderIDA"].Value;

            string NoBukti_ = GVDetailA.SelectedCells[0].OwningRow.Cells["nbA"].Value.ToString();
            if (MessageBox.Show("Hapus Pengeluaran :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                int exs = 0;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_DELETE]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    exs = db.Commands[0].ExecuteNonQuery();
                }
                if (exs <= 0)
                {
                    return;
                }

                int i = 0;
                int n = 0;
                i = GVDetailA.SelectedCells[0].RowIndex;
                n = GVDetailA.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVDetailA.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtDetailA1.AcceptChanges();

                if (GVDetailA.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVDetailA.CurrentCell = GVDetailA.Rows[0].Cells[n];
                        GVDetailA.RefreshEdit();
                    }
                    else
                    {
                        GVDetailA.CurrentCell = GVDetailA.Rows[i - 1].Cells[n];
                        GVDetailA.RefreshEdit();
                    }

                }
                else
                {

                    dtDetailA2.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        
        private void MutasiDKN(DataRow Header_, DataRow Detail_)
        {
            DataTable dt = Class.clsPiutangLain2.GetPLLDKN_Mutasi((Guid)Header_["RowID"], clsPiutangLain2.enumTipeHI.HLL);
            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("Tidak Ada Data");
                return;
            }
            frmPenerimaanMutasiDKN ifrmChild = new frmPenerimaanMutasiDKN(dt);
            ifrmChild.ShowDialog();

            if (ifrmChild.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("No Selected Data");
                return;
            }

            Class.clsPiutangLain2.SetDKNHLL_Mutasi(Tools.ToNull(Detail_["RowID"]), (Guid)ifrmChild.GetData["RowID"]);

        }



        #endregion

        #region Tab2
        private void LoadPers()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_Perusahaan_LIST_FILTER_OtherPT]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            dt.Rows.Add(DBNull.Value);
            dt.DefaultView.Sort = "InitPerusahaan";
            cboPers.DataSource = dt.DefaultView;
            cboPers.DisplayMember = "InitPerusahaan";
            cboPers.ValueMember = "RowID";
            cboPers.DropDownStyle = ComboBoxStyle.DropDownList;

            cboPers2.DataSource = dt.DefaultView;
            cboPers2.DisplayMember = "InitPerusahaan";
            cboPers2.ValueMember = "RowID";
            cboPers2.DropDownStyle = ComboBoxStyle.DropDownList;


            cboPTDari.DataSource = dt.DefaultView;
            cboPTDari.DisplayMember = "InitPerusahaan";
            cboPTDari.ValueMember = "RowID";
            cboPTDari.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void GetDataHeaderB(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlGuid val = SqlGuid.Null;
                if (cboPers.SelectedIndex != 0)
                {
                    val = (Guid)cboPers.SelectedValue;
                }
                dtHeaderB = Class.clsPiutangLain2.GetPengeluaranHLL_CrossPT(fromDate_, toDate_, val, GlobalVar.PerusahaanRowID);
                GVHeaderB.DataSource = dtHeaderB.DefaultView;


                if (GVHeaderB.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderB.SelectedCells[0].OwningRow.Cells["RowIDHeaderB"].Value;
                    GetPengeluaranB(HeaderID_);
                }
                else
                {
                    dtDetailB1.Rows.Clear();
                    dtDetailB2.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetPengeluaranB(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetailB1 = Class.clsPiutangLain2.GetPengeluaranHLL_CrossPT_Header(HeaderID_, GlobalVar.PerusahaanRowID);
                dtDetailB1.DefaultView.Sort = "Tanggal DESC,NoBukti ASC";
                GVDetailB.DataSource = dtDetailB1.DefaultView;
                DataTable dt = dtDetailB1.Copy();
                GetTotalPengeluaranB(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetTotalPengeluaranB(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetailB2.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetailB2.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetailB2.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetailB2.Rows.Add(drr);
                }
                dtDetailB2.AcceptChanges();
                GVDetailBA.DataSource = dtDetailB2.DefaultView;
            }
        }

        public void RefreshRowDataGridHeaderB(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;

            dtRefresh = Class.clsPiutangLain2.GetPengeluaranHLL_CrossPT(rowID_).Copy();

            if (dtRefresh.Rows.Count > 0)
            {
                GVHeaderB.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeaderB.FindRow("RowIDHeaderB", rowID_.ToString());
                dtHeaderB.AcceptChanges();

            }
        }


        public void RefreshRowDataGridHeaderB(string rowID_)
        {

            cmdSearch2.PerformClick();

            GVHeaderB.FindRow("RowIDHeaderB", rowID_.ToString());



        }

        public void RefreshRowDataGridDetailB(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh = Class.clsPiutangLain2.GetPengeluaranHLL_CrossPT_Header(rowID_).Copy();




            dtRefresh = Class.clsPiutangLain2.GetPengeluaranHLL_CrossPT_Header(rowID_).Copy();
            if (dtRefresh.Rows.Count > 0)
            {
                RefreshRowDataGridHeaderB((Guid)dtRefresh.Rows[0]["PengeluaranRowID"]);

                GVDetailB.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetailB.FindRow("RowIDDetailB", rowID_.ToString());
                dtDetailB1.AcceptChanges();
                GVDetailB.DataSource = dtDetailB1.DefaultView;
                DataTable dt = dtDetailB1.Copy();
                GetTotalPengeluaranB(dt);

            }
        }


        private void AddHistory(DataRow _Header)
        {
            DataTable dt = Class.clsPiutangLain2.GetPengeluaranHLL_History(GlobalVar.PerusahaanRowID, (Guid)_Header["PerusahaanDariRowID"]);
            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("Tidak Ada Data");
                return;
            }
            frmHutangLainLain_History ifrmChild = new frmHutangLainLain_History(dt);
            ifrmChild.ShowDialog();

            if (ifrmChild.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("No Selected Data");
                return;
            }

            Class.clsPiutangLain2.LinkPengeluaran_CrossPT((Guid)ifrmChild.GetData["RowID"], (Guid)_Header["RowID"]);

        }
        #endregion

        #region Tab3
        private void GetDataHeaderC(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlGuid val = SqlGuid.Null;
                if (cboPers2.SelectedIndex != 0)
                {
                    val = (Guid)cboPers2.SelectedValue;
                }


                dtHeaderC = Class.clsHutangLain2.GetHI_DKN(fromDate_, toDate_, val, GlobalVar.PerusahaanRowID, 1);
                GVHeaderC.DataSource = dtHeaderC.DefaultView;
                if (GVHeaderC.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderC.SelectedCells[0].OwningRow.Cells["RowIDHeaderC"].Value;
                    GetPengeluaranC(HeaderID_);
                }
                else
                {
                    dtDetailC1.Rows.Clear();
                    dtDetailC2.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetPengeluaranC(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetailC1 = Class.clsHutangLain2.GetPengeluaranHLL_DKN_Header(HeaderID_, GlobalVar.PerusahaanRowID);
                dtDetailC1.DefaultView.Sort = "Tanggal DESC,NoBukti ASC";
                GVDetailC.DataSource = dtDetailC1.DefaultView;
                DataTable dt = dtDetailC1.Copy();
                GetTotalPengeluaranC(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetTotalPengeluaranC(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetailC2.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetailC2.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetailC2.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetailC2.Rows.Add(drr);
                }
                dtDetailC2.AcceptChanges();
                GVDetailCA.DataSource = dtDetailC2.DefaultView;
            }
        }

        public void RefreshRowDataGridHeaderC(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;

            dtRefresh = Class.clsHutangLain2.GetHI_DKN(rowID_).Copy();

            if (dtRefresh.Rows.Count > 0)
            {
                GVHeaderC.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeaderC.FindRow("RowIDHeaderC", rowID_.ToString());
                dtHeaderC.AcceptChanges();

            }
        }


        public void RefreshRowDataGridHeaderC(string rowID_)
        {

            cmdSearch3.PerformClick();

            GVHeaderC.FindRow("RowIDHeaderC", rowID_.ToString());



        }

        public void RefreshRowDataGridDetailC(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh = Class.clsHutangLain2.GetPengeluaranHLL_DKN_Header(rowID_).Copy();




            dtRefresh = Class.clsHutangLain2.GetPengeluaranHLL_DKN_Header(rowID_).Copy();
            if (dtRefresh.Rows.Count > 0)
            {
                RefreshRowDataGridHeaderC((Guid)dtRefresh.Rows[0]["HiRowID"]);

                GVDetailC.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetailC.FindRow("RowIDDetailC", rowID_.ToString());
                dtDetailC1.AcceptChanges();
                GVDetailC.DataSource = dtDetailC1.DefaultView;
                DataTable dt = dtDetailC1.Copy();
                GetTotalPengeluaranC(dt);

            }
        }



        #endregion

        #region Tab 4

        private void GetDataHeaderD(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlGuid val = SqlGuid.Null;
                if (cboPTDari.SelectedIndex != 0)
                {
                    val = (Guid)cboPTDari.SelectedValue;
                }


                dtHeaderD = Class.clsHutangLain2.GetPenenerimaan_HLL(fromDate_,toDate_,GlobalVar.PerusahaanRowID,val,GlobalVar.GetTransaksi.HLL);
                dtHeaderD.DefaultView.Sort = "Tanggal DESC,NoBukti ASC";
                GVHeaderD.DataSource = dtHeaderD.DefaultView;
                if (GVHeaderD.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderD.SelectedCells[0].OwningRow.Cells["RowIDHeaderD"].Value;
                    GetPengeluaranD(HeaderID_);
                }
                else
                {
                    dtDetailD1.Rows.Clear();
                    dtDetailD2.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetPengeluaranD(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetailD1 = Class.clsHutangLain2.GetPengeluaran_HLL_PenerimaanID(HeaderID_,GlobalVar.GetTransaksi.HLL);
                dtDetailD1.DefaultView.Sort = "Tanggal DESC,NoBukti ASC";
                GVDetailD.DataSource = dtDetailD1.DefaultView;
                DataTable dt = dtDetailD1.Copy();
                GetTotalPengeluaranD(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetTotalPengeluaranD(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetailD2.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetailD2.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetailD2.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetailD2.Rows.Add(drr);
                }
                dtDetailD2.AcceptChanges();
                GVDetailDA.DataSource = dtDetailD2.DefaultView;
            }
        }

        public void RefreshRowDataGridHeaderD(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;

            dtRefresh = Class.clsHutangLain2.GetPenenerimaan_HLL(rowID_).Copy();

            if (dtRefresh.Rows.Count > 0)
            {
                GVHeaderD.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeaderD.FindRow("RowIDHeaderD", rowID_.ToString());
                dtHeaderD.AcceptChanges();

            }
        }


        public void RefreshRowDataGridHeaderD(string rowID_)
        {

            cmdSearch4.PerformClick();

            GVHeaderD.FindRow("RowIDHeaderD", rowID_.ToString());



        }

        public void RefreshRowDataGridDetailD(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh = Class.clsHutangLain2.GetPengeluaran_HLL_PenerimaanID(rowID_).Copy();




             
            if (dtRefresh.Rows.Count > 0)
            {
                RefreshRowDataGridHeaderD((Guid)dtRefresh.Rows[0]["PenerimaanRowID"]);

                GVDetailD.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetailD.FindRow("RowIDDetailD", rowID_.ToString());
                dtDetailD1.AcceptChanges();
                GVDetailD.DataSource = dtDetailD1.DefaultView;
                DataTable dt = dtDetailD1.Copy();
                GetTotalPengeluaranD(dt);

            }
        }

        private void DeleteHeaderD()
        {
            Guid rowID_ = (Guid)GVHeaderD.SelectedCells[0].OwningRow.Cells["RowIDHeaderD"].Value;

            if (GVDetailD.RowCount > 0)
            {
                MessageBox.Show("Sudah ada Penerimaan");
                return;
            }
            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVHeaderD.SelectedCells[0].OwningRow.Cells["JournalRowIDHeader4"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVHeaderD.SelectedCells[0].OwningRow.Cells["TanggalInput4"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }

            string NoBukti_ = GVHeaderD.SelectedCells[0].OwningRow.Cells["NoBukti1OO"].Value.ToString();
            if (MessageBox.Show("Hapus Penerimaan :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_DELETE_PLL]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVHeaderD.SelectedCells[0].RowIndex;
                n = GVHeaderD.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVHeaderD.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtHeaderD.AcceptChanges();
                GVHeaderD.Focus();
                if (GVHeaderD.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVHeaderD.CurrentCell = GVHeaderD.Rows[0].Cells[n];
                        GVHeaderD.RefreshEdit();
                    }
                    else
                    {
                        GVHeaderD.CurrentCell = GVHeaderD.Rows[i - 1].Cells[n];
                        GVHeaderD.RefreshEdit();
                    }

                }
                else
                {
                    dtDetailD1.Rows.Clear();
                    dtDetailD1.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void DeleteDetailD()
        {
            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVDetailD.SelectedCells[0].OwningRow.Cells["JournalRowIDDetail4"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVDetailD.SelectedCells[0].OwningRow.Cells["TglInputD2"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }


            try
            {

                Guid rowID_ = (Guid)GVDetailD.SelectedCells[0].OwningRow.Cells["RowIDDetailD"].Value;

                string NoBukti_ = GVDetailD.SelectedCells[0].OwningRow.Cells["dataGridViewTextBoxColumn70"].Value.ToString();
                if (MessageBox.Show("Hapus Pengeluaran :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_DELETE_PLL]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVDetailD.SelectedCells[0].RowIndex;
                n = GVDetailD.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVDetailD.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtDetailD1.AcceptChanges();

                if (GVDetailD.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVDetailD.CurrentCell = GVDetailD.Rows[0].Cells[n];
                        GVDetailD.RefreshEdit();
                    }
                    else
                    {
                        GVDetailD.CurrentCell = GVDetailD.Rows[i - 1].Cells[n];
                        GVDetailD.RefreshEdit();
                    }

                }
                else
                {

                    dtDetailD2.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


        }

        #endregion

        public frmHutangLainLain_Browse()
        {
            InitializeComponent();
        }

        private void frmHutangLainLain_Browse_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1 = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                DateTime dt2 = GlobalVar.GetServerDate;
                tabControl1.TabPages.RemoveAt(2);
                tabControl1.TabPages.RemoveAt(1);
                rangeDateA.FromDate = dt1;
                rangeDateA.ToDate = dt2;
                rangeDateB.FromDate = dt1;
                rangeDateB.ToDate = dt2;
                rangeDateC.FromDate = dt1;
                rangeDateC.ToDate = dt2;

                InitTotal();
                cmdSearchA.PerformClick();
                cmdSearch2.PerformClick();

                cmdAddHistory.Text = "From History";

                rangeDateBoxD.FromDate = dt1;
                rangeDateBoxD.ToDate = dt2;
                LoadPers();
                GVHeaderD.AutoGenerateColumns = false;
          

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }


        #region Event TAb1

        private void cmdCloseA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAddA_Click(object sender, EventArgs e)
        {

            switch (SelectedGridA)
            {
                case enumSelectedGrid.Header:
                    {
                        //frmDNKNUpdate ifrmChild = new frmDNKNUpdate(this);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        //ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVHeaderA.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DataRow drr = (DataRow)(GVHeaderA.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Guid HeaderID_ = (Guid)drr["RowID"];
                        Guid PTDari_ = (Guid)drr["PerusahaanDariRowID"];

                        DataRow[] dr = dtHeaderA.Select("RowID='" + HeaderID_.ToString() + "'");

                        if (PTDari_ != GlobalVar.PerusahaanRowID)
                        {
                            return;
                        }
                        Keuangan.frmHutangLainLain_Pengeluaran ifrmChild = new Keuangan.frmHutangLainLain_Pengeluaran(this, !true, true, dr[0]);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
            }
        }

        private void cmdEditA_Click(object sender, EventArgs e)
        {
            switch (SelectedGridA)
            {
                case enumSelectedGrid.Header:
                    {
                        //frmDNKNUpdate ifrmChild = new frmDNKNUpdate(this);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        //ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {

                        if (GVDetailA.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DataRow drr = (DataRow)(GVDetailA.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Guid _RowID = (Guid)drr["RowID"];
                        Guid _HiROwID = (Guid)drr["HiRowID"];
                        Guid PTDari_ = (Guid)drr["PerusahaanDariRowID"];

                        DataRow[] dr = dtHeaderA.Select("RowID='" + _HiROwID.ToString() + "'");

                        if (PTDari_ != GlobalVar.PerusahaanRowID)
                        {
                            return;
                        }
                        Keuangan.frmHutangLainLain_Pengeluaran ifrmChild = new Keuangan.frmHutangLainLain_Pengeluaran(this, !true, _RowID, true, dr[0]);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
            }
        }

        private void DeleteHeaderA()
        {

            if (GVDetailA.RowCount > 0)
            {
                MessageBox.Show("Sudah Ada Penerimaan !!!");
                return;
            }

            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVHeaderA.SelectedCells[0].OwningRow.Cells["JournalRowIDHeader1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVHeaderA.SelectedCells[0].OwningRow.Cells["Tanggal1"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }

            Guid rowID_ = (Guid)GVHeaderA.SelectedCells[0].OwningRow.Cells["RowIDHeaderA"].Value;

            string NoBukti_ = GVHeaderA.SelectedCells[0].OwningRow.Cells["NoBukti2"].Value.ToString();
            if (MessageBox.Show("Hapus DKN :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewaAntarPT_DELETE]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVHeaderA.SelectedCells[0].RowIndex;
                n = GVHeaderA.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVHeaderA.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtHeaderA.AcceptChanges();

                if (GVHeaderA.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVHeaderA.CurrentCell = GVHeaderA.Rows[0].Cells[n];
                        GVHeaderA.RefreshEdit();
                    }
                    else
                    {
                        GVHeaderA.CurrentCell = GVHeaderA.Rows[i - 1].Cells[n];
                        GVHeaderA.RefreshEdit();
                    }

                }
                else
                {

                    dtDetailA1.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cdmDeleteD_Click(object sender, EventArgs e)
        {
            switch (SelectedGridA)
            {
                case enumSelectedGrid.Header:
                    {

                        if (GVHeaderA.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        if (GVDetailA.RowCount > 0)
                        {
                            MessageBox.Show("Hapus Detail dulu");
                            return;
                        }
                        DeleteHeaderA();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {

                        if (GVDetailA.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        DeleteDetailA();
                    }
                    break;
            }
        }

        private void cmdSearchA_Click(object sender, EventArgs e)
        {
            if (!rangeDateA.FromDate.HasValue || !rangeDateA.ToDate.HasValue)
            {
                return;
            }
            GetDataHeaderA(rangeDateA.FromDate.Value, rangeDateA.ToDate.Value);
        }

        private void GVHeaderA_Click(object sender, EventArgs e)
        {
            SelectedGridA = enumSelectedGrid.Header;
        }

        private void GVHeaderA_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridA = enumSelectedGrid.Header;
        }

        private void GVHeaderA_SelectionChanged(object sender, EventArgs e)
        {
            if (GVHeaderA.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeaderA.SelectedCells[0].OwningRow.Cells["RowIDHeaderA"].Value;
                GetPengeluaranA(HeaderID_);
            }
            else
            {
                dtDetailA1.Rows.Clear();
                dtDetailA2.Rows.Clear();
            }
        }

        private void GVDetailA_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridA = enumSelectedGrid.Detail;
        }

        private void GVDetailA_Click(object sender, EventArgs e)
        {
            SelectedGridA = enumSelectedGrid.Detail;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (GVHeaderA.SelectedCells.Count > 0)
            {
                try
                {
                    List<DataTable> dt = new List<DataTable>();
                    List<string> ds = new List<string>();
                    ds.Add("dsHutangLainLain_HLHeader");
                    ds.Add("dsHutangLainLain_HLDetail");

                    Guid _rowID = (Guid)GVHeaderA.SelectedCells[0].OwningRow.Cells["RowIDHeaderA"].Value;
                    dt.Add(Class.clsHutangLain2.RptHLLHeader(_rowID));
                    dt.Add(Class.clsHutangLain2.RptHLLDetail(_rowID));

                    //construct sender           
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

                    //call report viewer
                    frmReportViewer ifrmReport = new frmReportViewer("Laporan.HI.rptHutangLain2.rdlc", rptParams, dt, ds);
                    ifrmReport.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdPRINT_Multy_Click(object sender, EventArgs e)
        {
            if (GVHeaderA.SelectedCells.Count > 0)
            {
                Keuangan.frmHutangLain2MultiSheet frmChild = new Keuangan.frmHutangLain2MultiSheet(rangeDateA.FromDate.Value, rangeDateA.ToDate.Value);
                frmChild.Show();
            }
        }
        #endregion

        #region Event TAb 2
        private void commandButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch2_Click(object sender, EventArgs e)
        {
            SelectedGridB = enumSelectedGrid.Header;
            if (rangeDateB.FromDate.HasValue && rangeDateB.ToDate.HasValue)
            {
                GetDataHeaderB(rangeDateB.FromDate.Value, rangeDateB.ToDate.Value);
            }
            else
            {
                SetError(rangeDateB, "Must Be Filled");
            }
        }

        private void GVHeaderB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridB = enumSelectedGrid.Header;
        }

        private void GVHeaderB_SelectionChanged(object sender, EventArgs e)
        {
            if (GVHeaderB.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeaderB.SelectedCells[0].OwningRow.Cells["RowIDHeaderB"].Value;
                GetPengeluaranB(HeaderID_);
            }
            else
            {
                dtDetailB1.Rows.Clear();
                dtDetailB2.Rows.Clear();
            }
        }

        private void GVHeaderB_Click(object sender, EventArgs e)
        {
            SelectedGridB = enumSelectedGrid.Header;
        }

        private void GVDetailB_Click(object sender, EventArgs e)
        {
            SelectedGridB = enumSelectedGrid.Detail;
        }

        private void GVDetailB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridB = enumSelectedGrid.Detail;
        }

        private void cmdAddB_Click(object sender, EventArgs e)
        {
            switch (SelectedGridB)
            {

                case enumSelectedGrid.Detail:
                    {
                        if (GVHeaderB.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DataRow drr = (DataRow)(GVHeaderB.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Guid HeaderID_ = (Guid)drr["RowID"];
                        Guid PTDari_ = (Guid)drr["PerusahaanDariRowID"];

                        DataRow[] dr = dtHeaderB.Select("RowID='" + HeaderID_.ToString() + "'");


                        Keuangan.frmHutangLainLain_PengeluaranB ifrmChild = new Keuangan.frmHutangLainLain_PengeluaranB(this, !true, true, dr[0]);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
            }

        }

        private void cmdEditB_Click(object sender, EventArgs e)
        {

            if (GVDetailB.SelectedCells.Count == 0)
            {
                return;
            }
            DataRow drr = (DataRow)(GVDetailB.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            Guid _RowID = (Guid)drr["RowID"];
            Guid _HiROwID = (Guid)drr["PengeluaranRowID"];


            DataRow[] dr = dtHeaderB.Select("RowID='" + _HiROwID.ToString() + "'");


            Keuangan.frmHutangLainLain_PengeluaranB ifrmChild = new Keuangan.frmHutangLainLain_PengeluaranB(this, !true, _RowID, true, dr[0]);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdDeleteB_Click(object sender, EventArgs e)
        {

        }

        private void cmdMutasi_Click(object sender, EventArgs e)
        {

            try
            {
                if (GVHeaderB.SelectedCells.Count == 0)
                {
                    return;
                }
                DataRow drHeader = (DataRow)(GVHeaderB.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;


                AddHistory(drHeader);
                Guid HeaderID_ = (Guid)drHeader["RowID"];
                cmdSearch2.PerformClick();
                RefreshRowDataGridHeaderB(HeaderID_.ToString());
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GVHeaderB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GVHeaderB.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeaderB.Rows[e.RowIndex].Cells["adasd"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeaderB.ColumnCount; i++)
                    {
                        GVHeaderB.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }


        #endregion

        #region Event Tab3

        private void GVHeaderC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GVHeaderC.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeaderC.Rows[e.RowIndex].Cells["sasa"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeaderC.ColumnCount; i++)
                    {
                        GVHeaderC.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }

        private void GVHeaderC_SelectionChanged(object sender, EventArgs e)
        {
            if (GVHeaderC.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeaderC.SelectedCells[0].OwningRow.Cells["RowIDHeaderC"].Value;
                GetPengeluaranC(HeaderID_);
            }
            else
            {
                dtDetailC1.Rows.Clear();
                dtDetailC2.Rows.Clear();
            }
        }

        private void cmdSearch3_Click(object sender, EventArgs e)
        {
            SelectedGridB = enumSelectedGrid.Header;
            if (rangeDateC.FromDate.HasValue && rangeDateC.ToDate.HasValue)
            {
                GetDataHeaderC(rangeDateC.FromDate.Value, rangeDateC.ToDate.Value);
            }
            else
            {
                SetError(rangeDateC, "Must Be Filled");
            }
        }

        private void cmdAdd3_Click(object sender, EventArgs e)
        {

            if (GVHeaderC.SelectedCells.Count == 0)
            {
                return;
            }
            DataRow drr = (DataRow)(GVHeaderC.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            Guid HeaderID_ = (Guid)drr["RowID"];
            Guid PTDari_ = (Guid)drr["PerusahaanDariRowID"];

            DataRow[] dr = dtHeaderC.Select("RowID='" + HeaderID_.ToString() + "'");


            Keuangan.frmHutangLainLain_PengeluaranC ifrmChild = new Keuangan.frmHutangLainLain_PengeluaranC(this, !true, true, dr[0]);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();



        }

        private void cmdEdit3_Click(object sender, EventArgs e)
        {
            if (GVDetailC.SelectedCells.Count == 0)
            {
                return;
            }
            DataRow drr = (DataRow)(GVDetailC.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            Guid _RowID = (Guid)drr["RowID"];
            Guid _HiROwID = (Guid)drr["HiRowID"];


            DataRow[] dr = dtHeaderA.Select("RowID='" + _HiROwID.ToString() + "'");


            Keuangan.frmHutangLainLain_PengeluaranC ifrmChild = new Keuangan.frmHutangLainLain_PengeluaranC(this, !true, _RowID, true, dr[0]);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }


        private void cboPers_SelectedValueChanged(object sender, EventArgs e)
        {
            cmdSearch2.PerformClick();
        }

        private void cboPers2_SelectedValueChanged(object sender, EventArgs e)
        {
            cmdSearch3.PerformClick();
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }



        #region Event TAb 4


        private void cmdSearch4_Click(object sender, EventArgs e)
        {
            if (rangeDateBoxD.FromDate.HasValue && rangeDateBoxD.ToDate.HasValue)
            {
                GetDataHeaderD(rangeDateBoxD.FromDate.Value, rangeDateBoxD.ToDate.Value);
            }
            else
            {
                SetError(rangeDateBoxD, "Isi dengan Benar");
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDelte4_Click(object sender, EventArgs e)
        {
            switch (SelectedGridD)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeaderD.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DeleteHeaderD();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVDetailD.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DeleteDetailD();
                    }
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

        }

        private void cmdAdd4_Click(object sender, EventArgs e)
        {
            switch (SelectedGridD)
            {
                case enumSelectedGrid.Header:
                    {

                    
                    Keuangan.frmHutangLainLain_PenerimaanD ifrmChild = new Keuangan.frmHutangLainLain_PenerimaanD(this);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {

                  
                    if (GVHeaderD.SelectedCells.Count == 0)
                    {
                        return;
                    }
                    DataRow drr = (DataRow)(GVHeaderD.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                    Guid HeaderID_ = (Guid)drr["RowID"];
                    Guid PTDari_ = (Guid)drr["PerusahaanDariRowID"];

                    DataRow[] dr = dtHeaderD.Select("RowID='" + HeaderID_.ToString() + "'");


                    Keuangan.frmHutangLainLain_PengeluaranD ifrmChild = new Keuangan.frmHutangLainLain_PengeluaranD(this, !true, true, dr[0]);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    }
                    break;
            }
        }

        private void cboPTDari_SelectedValueChanged(object sender, EventArgs e)
        {
            cmdSearch4.PerformClick();
        }

        private void GVHeaderD_Click(object sender, EventArgs e)
        {
            SelectedGridD = enumSelectedGrid.Header;
        }

        private void customGridView2_Click(object sender, EventArgs e)
        {
            SelectedGridD = enumSelectedGrid.Detail;
        }

        private void GVHeaderD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridD = enumSelectedGrid.Header;
        }

        private void GVHeaderD_SelectionChanged(object sender, EventArgs e)
        {
            SelectedGridD = enumSelectedGrid.Header;
            if (GVHeaderD.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeaderD.SelectedCells[0].OwningRow.Cells["RowIDHeaderD"].Value;
                GetPengeluaranD(HeaderID_);
            }
            else
            {
                dtDetailD1.Rows.Clear();
                dtDetailD2.Rows.Clear();
            }
        }

        private void GVHeaderD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GVHeaderD.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeaderD.Rows[e.RowIndex].Cells["Saldo"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeaderD.ColumnCount; i++)
                    {
                        GVHeaderD.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }

        private void customGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "TabHLL2":
                    if (rangeDateBoxD.FromDate.HasValue && rangeDateBoxD.ToDate.HasValue)
                    {
                        GetDataHeaderD(rangeDateBoxD.FromDate.Value, rangeDateBoxD.ToDate.Value);
                    }
                    break;
                case "TabHutang":
                    cmdSearchA.PerformClick();
                    break;
            }
        }

        private void cmdMutasiY_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVHeaderA.SelectedCells.Count == 0 || GVDetailA.SelectedCells.Count == 0)
                {
                    return;
                }
                DataRow drHeader = (DataRow)(GVHeaderA.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                DataRow drDetail = (DataRow)(GVDetailA.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;

                MutasiDKN(drHeader, drDetail);
                Guid HeaderID_ = (Guid)drHeader["RowID"];
                cmdSearchA.PerformClick();
                RefreshRowDataGridHeaderA(HeaderID_);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }





    }
}