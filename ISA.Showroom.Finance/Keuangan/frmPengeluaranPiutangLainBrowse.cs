using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPengeluaranPiutangLainBrowse : ISA.Controls.BaseForm
    {

        #region Var
        DataTable dtHeaderO = new DataTable(), dtDetail1O = new DataTable(), dtDetail2O = new DataTable();
        DataTable dtHeader = new DataTable(), dtDetail1 = new DataTable(), dtDetail2 = new DataTable();
        DataTable dtHeaderX = new DataTable(), dtDetail1X = new DataTable(), dtDetail2X = new DataTable();
        DataTable dtHeaderY = new DataTable(), dtDetail1Y = new DataTable(), dtDetail2Y = new DataTable();

        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid SelectedGrid = enumSelectedGrid.Header;
        enumSelectedGrid SelectedGridY = enumSelectedGrid.Header;
        enumSelectedGrid SelectedGridO = enumSelectedGrid.Header;

        #endregion

        #region Procedure

        private void getPengeluaran(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_PIUTANGLAINLAIN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }

                GVHeader.DataSource = dtHeader.DefaultView;
                if (GVHeader.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    getPenerimaan(HeaderID_);
                }
                else
                {
                    dtDetail1.Rows.Clear();
                    dtDetail2.Rows.Clear();
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

        private void getPenerimaan(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_FILTER_HEADER"));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    dtDetail1 = db.Commands[0].ExecuteDataTable();
                }

                GVDetail.DataSource = dtDetail1.DefaultView;
                DataTable dt = dtDetail1.Copy();
                getTotalPenerimaan(dt);


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

        private void getTotalPenerimaan(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetail2.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetail2.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetail2.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetail2.Rows.Add(drr);
                }
                dtDetail2.AcceptChanges();
                GVDetail2.DataSource = dtDetail2.DefaultView;
            }
        }

        private void InitTotal()
        {

            dtDetail2.Clear();
            dtDetail2.Dispose();

            dtDetail2 = new DataTable();

            dtDetail2.Columns.Add("MataUangID", typeof(string));
            dtDetail2.Columns.Add("Nominal", typeof(double));

            dtDetail2X.Clear();
            dtDetail2X.Dispose();

            dtDetail2X = new DataTable();

            dtDetail2X.Columns.Add("MataUangID", typeof(string));
            dtDetail2X.Columns.Add("Nominal", typeof(double));


            dtDetail2Y = new DataTable();
            dtDetail2Y.Columns.Add("MataUangID", typeof(string));
            dtDetail2Y.Columns.Add("Nominal", typeof(double));


            dtDetail2O = new DataTable();
            dtDetail2O.Columns.Add("MataUangID", typeof(string));
            dtDetail2O.Columns.Add("Nominal", typeof(double));
        }


        private void DeleteHeader()
        {
            Guid rowID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

            if (GVDetail.RowCount > 0)
            {
                MessageBox.Show("Sudah ada Penerimaan");
                return;
            }
            //string _result = ValidasiDelete();
            //if (_result != "Valid")
            //{
            //    MessageBox.Show(_result);
            //    return;
            //}

            string sresult = "Valid";
            
            if ((Guid)Tools.isNull(this.GVHeader.SelectedCells[0].OwningRow.Cells["JournalRowID1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            if ((Guid)Tools.isNull(this.GVHeader.SelectedCells[0].OwningRow.Cells["HIRowID1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah link HI"; //validasi cek HI
            {
                DateTime TanggalInput = (DateTime)this.GVHeader.SelectedCells[0].OwningRow.Cells["TanggalKasir"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }



            string NoBukti_ = GVHeader.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
            if (MessageBox.Show("Hapus Pengeluaran :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVHeader.SelectedCells[0].RowIndex;
                n = GVHeader.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVHeader.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtHeader.AcceptChanges();
                GVHeader.Focus();
                if (GVHeader.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVHeader.CurrentCell = GVHeader.Rows[0].Cells[n];
                        GVHeader.RefreshEdit();
                    }
                    else
                    {
                        GVHeader.CurrentCell = GVHeader.Rows[i - 1].Cells[n];
                        GVHeader.RefreshEdit();
                    }

                }
                else
                {
                    dtDetail1.Rows.Clear();
                    dtDetail2.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void DeleteDetail()
        {
            //string gg = ValidasiDelete2();
            //if (gg != "Valid")
            //{
            //    MessageBox.Show(gg);
            //    return;
            //}

            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVDetail.SelectedCells[0].OwningRow.Cells["JournalRowID2"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            if ((Guid)Tools.isNull(this.GVDetail.SelectedCells[0].OwningRow.Cells["HIRowID2"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah link HI"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVDetail.SelectedCells[0].OwningRow.Cells["TanggalInput"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }



            Guid rowID_ = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowID1"].Value;

            string NoBukti_ = GVDetail.SelectedCells[0].OwningRow.Cells["NoBukti1"].Value.ToString();
            if (MessageBox.Show("Hapus Penerimaan :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVDetail.SelectedCells[0].RowIndex;
                n = GVDetail.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVDetail.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtDetail1.AcceptChanges();

                if (GVDetail.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVDetail.CurrentCell = GVDetail.Rows[0].Cells[n];
                        GVDetail.RefreshEdit();
                    }
                    else
                    {
                        GVDetail.CurrentCell = GVDetail.Rows[i - 1].Cells[n];
                        GVDetail.RefreshEdit();
                    }

                }
                else
                {

                    dtDetail2.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void RefreshRowDataGridHeader(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST_PIUTANGLAINLAIN"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                GVHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeader.FindRow("RowID", rowID_.ToString());
                dtHeader.AcceptChanges();

            }
        }

        public void RefreshRowDataGridDetail(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_FILTER_HEADER"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {

                RefreshRowDataGridHeader((Guid)dtRefresh.Rows[0]["PengeluaranRowID"]);
                GVDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetail.FindRow("RowID1", rowID_.ToString());
                dtDetail1.AcceptChanges();
                GVDetail.DataSource = dtDetail1.DefaultView;
                DataTable dt = dtDetail1.Copy();
                getTotalPenerimaan(dt);

            }
        }


        private void MutasiPenerimaan(Guid RowID_, Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataTable dtX = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_PIUTANGLAINLAIN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_vw_HutangPembelian_list]"));
                    dtX = db.Commands[0].ExecuteDataTable();
                }

                frmMutasiPenerimaanPLL ifrmChild = new frmMutasiPenerimaanPLL(dt, dtX);
                ifrmChild.ShowDialog();

                if (ifrmChild.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("No Selected Data");
                    return;
                }



                Guid newPLL = (Guid)ifrmChild.GetData["RowID"];

                if (newPLL == HeaderID_)
                {
                    return;
                }
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_UPDATE_MutasiHutang]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, newPLL));
                    db.Commands[0].Parameters.Add(new Parameter("@Link", SqlDbType.VarChar, ifrmChild.Link));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdateBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }

                GVDetail.Rows.Remove(GVDetail.SelectedCells[0].OwningRow);
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


        private void MutasiPLL(DataRow Header_, DataRow Detail_)
        {
            DataTable dt = Class.clsPiutangLain2.GetPengeluaran_Mutasi((Guid)Detail_["RowID"],(Guid)Header_["PerusahaanDariRowID"], (Guid)Header_["PerusahaanKeRowID"]);
            if (dt.Rows.Count == 0)
            {
                 
                MessageBox.Show("Tidak Ada Data");
                return;
            }
            frmPenerimaanMutasi ifrmChild = new frmPenerimaanMutasi(dt);
            ifrmChild.ShowDialog();

            if (ifrmChild.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("No Selected Data");
                return;
            }

            Class.clsPiutangLain2.SetPengeluaranUangPLL_Mutasi( Tools.ToNull(Detail_["RowID"]),  (Guid)ifrmChild.GetData["RowID"]);

        }


        private void MutasiDKN(DataRow Header_, DataRow Detail_)
        {
            DataTable dt = Class.clsPiutangLain2.GetPLLDKN_Mutasi(  (Guid)Header_["RowID"], clsPiutangLain2.enumTipeHI.PLL );
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

            Class.clsPiutangLain2.SetDKN_Mutasi(Tools.ToNull(Detail_["RowID"]), (Guid)ifrmChild.GetData["RowID"]);

        }

        #endregion


        #region Tab2
        private void getPengeluaran2(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_vw_HutangPembelian_list]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@SUmber", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                    dtHeaderX = db.Commands[0].ExecuteDataTable();

                }

                GVHeaderX.DataSource = dtHeaderX.DefaultView;
                if (GVHeaderX.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderX.SelectedCells[0].OwningRow.Cells["RowIDHutang"].Value;
                    getPenerimaan2(HeaderID_);
                }
                else
                {
                    dtDetail1X.Rows.Clear();
                    dtDetail2X.Rows.Clear();
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

        private void getPenerimaan2(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_LIST_FILTER_Hutang]"));
                    db.Commands[0].Parameters.Add(new Parameter("@HutangROwID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    dtDetail1X = db.Commands[0].ExecuteDataTable();
                }

                GVDetailX.DataSource = dtDetail1X.DefaultView;
                DataTable dt = dtDetail1X.Copy();
                getTotalPenerimaan2(dt);


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

        private void getTotalPenerimaan2(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetail2X.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetail2X.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetail2X.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetail2X.Rows.Add(drr);
                }
                dtDetail2X.AcceptChanges();
                GVDetail2X.DataSource = dtDetail2X.DefaultView;
            }
        }

        private void DeleteDetail2()
        {
            string gg = ValidasiDelete2();
            //if (gg != "Valid")
            //{
            //    MessageBox.Show(gg);
            //    return;
            //}

            Guid rowID_ = (Guid)GVDetailX.SelectedCells[0].OwningRow.Cells["RowIDX"].Value;

            string NoBukti_ = GVDetailX.SelectedCells[0].OwningRow.Cells["NoBuktiX"].Value.ToString();
            if (MessageBox.Show("Hapus Penerimaan :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVDetailX.SelectedCells[0].RowIndex;
                n = GVDetailX.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVDetailX.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtDetail1X.AcceptChanges();

                if (GVDetailX.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVDetailX.CurrentCell = GVDetailX.Rows[0].Cells[n];
                        GVDetailX.RefreshEdit();
                    }
                    else
                    {
                        GVDetailX.CurrentCell = GVDetailX.Rows[i - 1].Cells[n];
                        GVDetailX.RefreshEdit();
                    }

                }
                else
                {

                    dtDetail2X.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void RefreshRowDataGridDetail2(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh;
            DataTable dtRefresh2;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_FILTER_Hutang"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_vw_HutangPembelian_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtRefresh.Rows[0]["HutangRowID"]));
                    dtRefresh2 = db.Commands[0].ExecuteDataTable();
                }

                GVHeaderX.RefreshDataRow(dtRefresh2.Rows[0], "RowID", dtRefresh2.Rows[0]["RowID"].ToString());
                GVHeaderX.FindRow("RowIDHutang", dtRefresh2.Rows[0]["RowID"].ToString());

                GVDetailX.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetailX.FindRow("RowIDX", rowID_.ToString());
                dtDetail1X.AcceptChanges();
                GVDetailX.DataSource = dtDetail1X.DefaultView;
                DataTable dt = dtDetail1X.Copy();
                getTotalPenerimaan2(dt);

            }
        }

        private void MutasiPenerimaan2(Guid RowID_, Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataTable dtX = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_PIUTANGLAINLAIN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_vw_HutangPembelian_list]"));
                    dtX = db.Commands[0].ExecuteDataTable();
                }

                frmMutasiPenerimaanPLL ifrmChild = new frmMutasiPenerimaanPLL(dt, dtX);
                ifrmChild.ShowDialog();

                if (ifrmChild.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("No Selected Data");
                    return;
                }



                Guid newPLL = (Guid)ifrmChild.GetData["RowID"];

                if (newPLL == HeaderID_)
                {
                    return;
                }
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_UPDATE_MutasiHutang]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, newPLL));
                    db.Commands[0].Parameters.Add(new Parameter("@Link", SqlDbType.VarChar, ifrmChild.Link));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdateBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }

                GVDetailX.Rows.Remove(GVDetailX.SelectedCells[0].OwningRow);
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

        #endregion

        #region Tab3
        private void getPengeluaranY(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewa_LIST_CROSSPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.Int, 1));
                    dtHeaderY = db.Commands[0].ExecuteDataTable();
                }
                 
                GVHeaderY.DataSource = dtHeaderY.DefaultView;
                if (GVHeaderY.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderY.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
                    getPenerimaanY(HeaderID_);
                }
                else
                {
                    dtDetail1Y.Rows.Clear();
                    dtDetail2Y.Rows.Clear();
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

        private void getPenerimaanY(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_LIST_FILTER_HI]"));
                    db.Commands[0].Parameters.Add(new Parameter("@HiRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    dtDetail1Y = db.Commands[0].ExecuteDataTable();
                }

                GVDetailY.DataSource = dtDetail1Y.DefaultView;
                DataTable dt = dtDetail1Y.Copy();
                getTotalPenerimaanY(dt);


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

        private void getTotalPenerimaanY(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetail2Y.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetail2Y.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetail2Y.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetail2Y.Rows.Add(drr);
                }
                dtDetail2Y.AcceptChanges();
                GVDetailYY.DataSource = dtDetail2Y.DefaultView;
            }
        }

        public void RefreshRowDataGridHeaderY(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_HubunganIstimewa_LIST_CROSSPT]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                GVHeaderY.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeaderY.FindRow("RowID4", rowID_.ToString());
                dtHeaderY.AcceptChanges();

            }
        }

        public void RefreshRowDataGridDetailY(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh;
            DataTable dtRefresh2;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_FILTER_HI"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_CROSSPT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtRefresh.Rows[0]["HiRowID"]));
                    dtRefresh2 = db.Commands[0].ExecuteDataTable();
                }
                GVHeaderY.RefreshDataRow(dtRefresh2.Rows[0], "RowID", dtRefresh2.Rows[0]["RowID"].ToString());
                GVHeaderY.FindRow("RowID4", dtRefresh2.Rows[0]["RowID"].ToString());

                GVDetailY.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
               // GVDetailY.FindRow("dataGridViewTextBoxColumn4", rowID_.ToString());
                GVDetailY.FindRow("RowIDDetailY", rowID_.ToString());
                
                dtDetail1Y.AcceptChanges();
                GVDetailY.DataSource = dtDetail1Y.DefaultView;
                DataTable dt = dtDetail1Y.Copy();
                getTotalPenerimaanY(dt);

            }
        }

        private void DeleteHeaderY()
        {
            //  string gg = ValidasiDelete2();
            //if (gg != "Valid")
            //{
            //    MessageBox.Show(gg);
            //    return;
            //}
            if (GVDetailYY.RowCount > 0)
            {
                MessageBox.Show("Sudah Ada Penerimaan !!!");
                return;
            }

            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVHeaderY.SelectedCells[0].OwningRow.Cells["JournalRowIDY1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVHeaderY.SelectedCells[0].OwningRow.Cells["Tanggal1"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }



            Guid rowID_ = (Guid)GVHeaderY.SelectedCells[0].OwningRow.Cells["RowID4"].Value;

            string NoBukti_ = GVHeaderY.SelectedCells[0].OwningRow.Cells["NoBukti2"].Value.ToString();
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
                i = GVHeaderY.SelectedCells[0].RowIndex;
                n = GVHeaderY.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVHeaderY.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtHeaderY.AcceptChanges();

                if (GVHeaderY.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVHeaderY.CurrentCell = GVHeaderY.Rows[0].Cells[n];
                        GVHeaderY.RefreshEdit();
                    }
                    else
                    {
                        GVHeaderY.CurrentCell = GVHeaderY.Rows[i - 1].Cells[n];
                        GVHeaderY.RefreshEdit();
                    }

                }
                else
                {

                    dtDetail1Y.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void DeleteDetailY()
        {
            //  string gg = ValidasiDelete2();
            //if (gg != "Valid")
            //{
            //    MessageBox.Show(gg);
            //    return;
            //}

            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVDetailY.SelectedCells[0].OwningRow.Cells["JournalRowIDY2"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVDetailY.SelectedCells[0].OwningRow.Cells["TanggalInputY2"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }


            Guid rowID_ = (Guid)GVDetailY.SelectedCells[0].OwningRow.Cells["RowIDDetailY"].Value;

            string NoBukti_ = GVDetailY.SelectedCells[0].OwningRow.Cells["NoBuktiY"].Value.ToString();
            if (MessageBox.Show("Hapus Penerimaan :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_DELETE]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVDetailY.SelectedCells[0].RowIndex;
                n = GVDetailY.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVDetailY.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtDetail1Y.AcceptChanges();

                if (GVDetailY.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVDetailY.CurrentCell = GVDetailY.Rows[0].Cells[n];
                        GVDetailY.RefreshEdit();
                    }
                    else
                    {
                        GVDetailY.CurrentCell = GVDetailY.Rows[i - 1].Cells[n];
                        GVDetailY.RefreshEdit();
                    }

                }
                else
                {

                    dtDetail2Y.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        #region TAb AntarPT

        private void getPengeluaranO(DateTime fromDate_, DateTime toDate_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_PLL_CrossPT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, fromDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, toDate_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dtHeaderO = db.Commands[0].ExecuteDataTable();
                }

                GVHeaderO.DataSource = dtHeaderO.DefaultView;
                if (GVHeaderO.SelectedCells.Count > 0)
                {
                    Guid HeaderID_ = (Guid)GVHeaderO.SelectedCells[0].OwningRow.Cells["RowIDO"].Value;
                    getPenerimaanO(HeaderID_);
                }
                else
                {
                    dtDetail1O.Rows.Clear();
                    dtDetail2O.Rows.Clear();
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

        private void getPenerimaanO(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_PLL_HEADER"));
                    db.Commands[0].Parameters.Add(new Parameter("@PengeluaranRowID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKe", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    dtDetail1O = db.Commands[0].ExecuteDataTable();
                }

                GVDetailO.DataSource = dtDetail1O.DefaultView;
                DataTable dt = dtDetail1O.Copy();
                getTotalPenerimaanO(dt);


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

        private void getTotalPenerimaanO(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dtDetail2O.Rows.Clear();
            }
            else
            {
                DataTable dTemp = dt.DefaultView.ToTable(true, "MataUangID").Copy();
                dtDetail2O.Rows.Clear();

                foreach (DataRow dr in dTemp.Rows)
                {
                    DataRow drr = dtDetail2O.NewRow();

                    drr["MataUangID"] = dr["MataUangID"];
                    dt.DefaultView.RowFilter = "MataUangID='" + dr["MataUangID"].ToString() + "'";
                    drr["Nominal"] = Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(Nominal)", ""));
                    dtDetail2O.Rows.Add(drr);
                }
                dtDetail2O.AcceptChanges();
                GVDetail2O.DataSource = dtDetail2O.DefaultView;
            }
        }



        private void DeleteHeaderO()
        {
            Guid rowID_ = (Guid)GVHeaderO.SelectedCells[0].OwningRow.Cells["RowIDO"].Value;

            if (GVDetailO.RowCount > 0)
            {
                MessageBox.Show("Sudah ada Penerimaan");
                return;
            }

            //string _result = ValidasiDelete();
            //if (_result != "Valid")
            //{
            //    MessageBox.Show(_result);
            //    return;
            //}

            string sresult = "Valid";
            
            if ((Guid)Tools.isNull(this.GVHeaderO.SelectedCells[0].OwningRow.Cells["JournalRowIDO1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            if ((Guid)Tools.isNull(this.GVHeaderO.SelectedCells[0].OwningRow.Cells["HIRowIDO1"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah link HI"; //validasi cek journal
            {
                DateTime TanggalInput = (DateTime)this.GVHeaderO.SelectedCells[0].OwningRow.Cells["TanggalO1"].Value;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }

            if (sresult != "Valid")
            {
                MessageBox.Show(sresult);
                return;
            }



            string NoBukti_ = GVHeaderO.SelectedCells[0].OwningRow.Cells["NoBuktiOO"].Value.ToString();
            if (MessageBox.Show("Hapus Pengeluaran :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_DELETE_PLL]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVHeaderO.SelectedCells[0].RowIndex;
                n = GVHeaderO.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVHeaderO.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtHeaderO.AcceptChanges();
                GVHeaderO.Focus();
                if (GVHeaderO.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVHeaderO.CurrentCell = GVHeaderO.Rows[0].Cells[n];
                        GVHeaderO.RefreshEdit();
                    }
                    else
                    {
                        GVHeaderO.CurrentCell = GVHeaderO.Rows[i - 1].Cells[n];
                        GVHeaderO.RefreshEdit();
                    }

                }
                else
                {
                    dtDetail1O.Rows.Clear();
                    dtDetail2O.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }


        private void DeleteDetailO()
        {
            string sresult = "Valid";

            if ((Guid)Tools.isNull(this.GVDetailO.SelectedCells[0].OwningRow.Cells["JournalRowIDO2"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal"; //validasi cek journal
            if ((Guid)Tools.isNull(this.GVDetailO.SelectedCells[0].OwningRow.Cells["HIRowIDO2"].Value, Guid.Empty) != Guid.Empty) sresult = "Sudah link HI"; //validasi cek HI
            {
                DateTime TanggalInput = (DateTime)this.GVDetailO.SelectedCells[0].OwningRow.Cells["TanggalInputO2"].Value;
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

                Guid rowID_ = (Guid)GVDetailO.SelectedCells[0].OwningRow.Cells["RowID1O"].Value;

                string NoBukti_ = GVDetailO.SelectedCells[0].OwningRow.Cells["NoBukti1OO"].Value.ToString();
                if (MessageBox.Show("Hapus Penerimaan :  " + NoBukti_ + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_DELETE_PLL]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                    db.Commands[0].ExecuteNonQuery();
                }
                int i = 0;
                int n = 0;
                i = GVDetailO.SelectedCells[0].RowIndex;
                n = GVDetailO.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)GVDetailO.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dtDetail1.AcceptChanges();

                if (GVDetail.RowCount > 0)
                {
                    if (i == 0)
                    {
                        GVDetailO.CurrentCell = GVDetailO.Rows[0].Cells[n];
                        GVDetailO.RefreshEdit();
                    }
                    else
                    {
                        GVDetailO.CurrentCell = GVDetailO.Rows[i - 1].Cells[n];
                        GVDetailO.RefreshEdit();
                    }

                }
                else
                {

                    dtDetail2.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

           
        }


        public void RefreshRowDataGridHeaderO(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_PLL_CrossPT]"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                GVHeaderO.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVHeaderO.FindRow("RowIDO", rowID_.ToString());
                dtHeaderO.AcceptChanges();

            }
            getPenerimaanO(rowID_);
        }

        public void RefreshRowDataGridDetailO(Guid rowID_, Guid HeaderID_)
        {


            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST_PLL_HEADER"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                RefreshRowDataGridHeaderO((Guid)dtRefresh.Rows[0]["PengeluaranRowID"]);
                GVDetailO.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
                GVDetailO.FindRow("RowID1O", rowID_.ToString());
                dtDetail1O.AcceptChanges();
                GVDetailO.DataSource = dtDetail1O.DefaultView;
                DataTable dt = dtDetail1O.Copy();
                getTotalPenerimaanO(dt);
            }
        }


        private void MutasiPenerimaanO(Guid RowID_, Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                DataTable dtX = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PengeluaranUang_LIST_PIUTANGLAINLAIN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_vw_HutangPembelian_list]"));
                    dtX = db.Commands[0].ExecuteDataTable();
                }

                frmMutasiPenerimaanPLL ifrmChild = new frmMutasiPenerimaanPLL(dt, dtX);
                ifrmChild.ShowDialog();

                if (ifrmChild.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("No Selected Data");
                    return;
                }



                Guid newPLL = (Guid)ifrmChild.GetData["RowID"];

                if (newPLL == HeaderID_)
                {
                    return;
                }
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenerimaanUang_UPDATE_MutasiHutang]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, newPLL));
                    db.Commands[0].Parameters.Add(new Parameter("@Link", SqlDbType.VarChar, ifrmChild.Link));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdateBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }

                GVDetail.Rows.Remove(GVDetail.SelectedCells[0].OwningRow);
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

        #endregion

        #region Parameter Lock

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

        private string ValidasiDelete()
        {
            string sresult = "Valid";
            DataRow dr = (DataRow)(GVHeader.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;

            DateTime TglInput = (DateTime)dr["CreatedTime"];
            List<int> parameter = ParameterKuncian();
            if (TglInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TglInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                sresult = "Sudah lewat batas waktu pengeditan.";

            return sresult;
        }


        private string ValidasiDelete2()
        {
            string sresult = "Valid";
            DataRow dr = (DataRow)(GVDetail.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            if ((Guid)Tools.isNull(dr["HIRowID"], Guid.Empty) != Guid.Empty) sresult = "Sudah diproses DKN";
            else if ((Guid)Tools.isNull(dr["JournalRowID"], Guid.Empty) != Guid.Empty) sresult = "Sudah dijurnal";
            {
                DateTime TanggalInput = (DateTime)this.GVDetail.SelectedCells[0].OwningRow.Cells["TanggalInput"].Value;
                //bool Expired = false;
                List<int> parameter = ParameterKuncian();
                if (TanggalInput <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || TanggalInput >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
                    sresult = "Kadaluarsa : Tanggal sudah melewati batas perubahan data";
            }
            return sresult;
        }

        #endregion

        public frmPengeluaranPiutangLainBrowse()
        {
            InitializeComponent();


        }

        private void frmPengeluaranPiutangLainBrowse_Load(object sender, EventArgs e)
        {
            Class.FillComboBox fcbo = new Class.FillComboBox();
            InitTotal();
            rangeDateBox1.ToDate = GlobalVar.GetServerDate;
            rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            cmdSearch.PerformClick();
            rangeDateBox2.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox2.ToDate = GlobalVar.GetServerDate;
            rangeDateBox3.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox3.ToDate = GlobalVar.GetServerDate;

            rangeDateBox4.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rangeDateBox4.ToDate = GlobalVar.GetServerDate;
             

        }

        private void GVHeader_SelectionChanged(object sender, EventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Header;
            if (GVHeader.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                getPenerimaan(HeaderID_);
            }

        }

        private void GVHeader_Click(object sender, EventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Header;
        }

        private void GVHeader_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Header;
        }

        private void GVDetail_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Detail;
        }

        private void GVDetail_Click(object sender, EventArgs e)
        {
            SelectedGrid = enumSelectedGrid.Detail;
        }

        private void GVDetail_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (!rangeDateBox1.FromDate.HasValue || !rangeDateBox1.ToDate.HasValue)
            {
                return;
            }
            getPengeluaran(rangeDateBox1.FromDate.Value, rangeDateBox1.ToDate.Value);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (SelectedGrid)
            {
                case enumSelectedGrid.Header:
                    {

                        Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, !true, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVHeader.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Keuangan.frmPenerimaanUangUpdate ifrmChild = new Keuangan.frmPenerimaanUangUpdate(this, HeaderID_, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

                    }
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            switch (SelectedGrid)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeader.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                        Keuangan.panelStok ifrmChild = new Keuangan.panelStok(this, !true, HeaderID_, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVDetail.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        Guid rowID_ = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowID1"].Value;
                        Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Keuangan.frmPenerimaanUangUpdate ifrmChild = new Keuangan.frmPenerimaanUangUpdate(this, rowID_, HeaderID_, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

                    }
                    break;
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (SelectedGrid)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeader.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DeleteHeader();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVDetail.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DeleteDetail();
                    }
                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdMutasi_Click(object sender, EventArgs e)
        {
            switch (SelectedGrid)
            {

                case enumSelectedGrid.Detail:
                    {
                        if (GVDetail.SelectedCells.Count == 1)
                        {
                            Guid HeaderID_ = (Guid)GVHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            Guid rowID_ = (Guid)GVDetail.SelectedCells[0].OwningRow.Cells["RowID1"].Value;
                            MutasiPenerimaan(rowID_, HeaderID_);
                        }



                    }
                    break;
            }
        }

        private void cmdSearch2_Click(object sender, EventArgs e)
        {
            if (!rangeDateBox2.FromDate.HasValue || !rangeDateBox2.ToDate.HasValue)
            {
                return;
            }
            getPengeluaran2(rangeDateBox2.FromDate.Value, rangeDateBox2.ToDate.Value);
        }

        private void dgDaftarHutang_SelectionChanged(object sender, EventArgs e)
        {
            if (GVHeaderX.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeaderX.SelectedCells[0].OwningRow.Cells["RowIDHutang"].Value;
                getPenerimaan2(HeaderID_);
            }
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (GVDetailX.SelectedCells.Count == 0)
            {
                return;
            }
            DeleteDetail2();
        }

        private void cmdAddX_Click(object sender, EventArgs e)
        {
            if (GVHeaderX.SelectedCells.Count == 0)
            {
                return;
            }
            Guid HeaderID_ = (Guid)GVHeaderX.SelectedCells[0].OwningRow.Cells["RowIDHutang"].Value;
            Keuangan.frmPenerimaanUangUpdateX ifrmChild = new Keuangan.frmPenerimaanUangUpdateX(this, HeaderID_, true);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEditX_Click(object sender, EventArgs e)
        {
            if (GVDetailX.SelectedCells.Count == 0)
            {
                return;
            }

            Guid rowID_ = (Guid)GVDetailX.SelectedCells[0].OwningRow.Cells["RowIDX"].Value;
            Guid HeaderID_ = (Guid)GVHeaderX.SelectedCells[0].OwningRow.Cells["RowIDHutang"].Value;
            Keuangan.frmPenerimaanUangUpdateX ifrmChild = new Keuangan.frmPenerimaanUangUpdateX(this, rowID_, HeaderID_, true);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdMutasiX_Click(object sender, EventArgs e)
        {
            if (GVDetailX.SelectedCells.Count == 1)
            {
                Guid rowID_ = (Guid)GVDetailX.SelectedCells[0].OwningRow.Cells["RowIDX"].Value;
                Guid HeaderID_ = (Guid)GVHeaderX.SelectedCells[0].OwningRow.Cells["RowIDHutang"].Value;
                MutasiPenerimaan2(rowID_, HeaderID_);
            }

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Y
        #endregion
        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (!rangeDateBox3.FromDate.HasValue || !rangeDateBox3.ToDate.HasValue)
            {
                return;
            }
            getPengeluaranY(rangeDateBox3.FromDate.Value, rangeDateBox3.ToDate.Value);
        }

        private void GVHeaderY_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridY = enumSelectedGrid.Header;
        }

        private void GVHeaderY_Click(object sender, EventArgs e)
        {
            SelectedGridY = enumSelectedGrid.Header;
        }

        private void customGridView2_Click(object sender, EventArgs e)
        {
            SelectedGridY = enumSelectedGrid.Detail;
        }

        private void tabControl4_Click(object sender, EventArgs e)
        {
            SelectedGridY = enumSelectedGrid.Detail;
        }

        private void GVHeaderY_SelectionChanged(object sender, EventArgs e)
        {
            if (GVHeaderY.SelectedCells.Count > 0)
            {
                Guid headerRowID_ = (Guid)GVHeaderY.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
                getPenerimaanY(headerRowID_);
            }
            else
            {
                dtDetail1Y.Rows.Clear();
                dtDetail2Y.Rows.Clear();
            }
        }

        private void cmdAddY_Click(object sender, EventArgs e)
        {
            switch (SelectedGridY)
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
                        if (GVHeaderY.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        DataRow drr = (DataRow)(GVHeaderY.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Guid HeaderID_ = (Guid)drr["RowID"];
                        Guid PTKE_ = (Guid)drr["CompanyTo"];

                        //if (PTKE_ != GlobalVar.GetPT.ECR)
                        //{
                        //    MessageBox.Show("Hanya Untuk Eceran");
                        //    return;
                        //}
                     

                        DataRow[] dr = dtHeaderY.Select("RowID='" + HeaderID_.ToString() + "'");
                        Keuangan.frmPenerimaanUangUpdateY ifrmChild = new Keuangan.frmPenerimaanUangUpdateY(this, HeaderID_, true, dr[0]);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
            }
        }

        private void cmdEditY_Click(object sender, EventArgs e)
        {
            switch (SelectedGridY)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeaderY.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        Guid HeaderID_ = (Guid)GVHeaderY.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
                        DataRow[] drr = dtHeaderY.Select("RowID='" + HeaderID_.ToString() + "'");
                        //frmDNKNUpdate ifrmChild = new frmDNKNUpdate(this, drr[0]);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        //ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVHeaderY.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        //Guid rowID_ = (Guid)GVDetailY.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                        //Guid HeaderID_ = (Guid)GVHeaderY.SelectedCells[0].OwningRow.Cells["RowID4"].Value;
                        //Keuangan.frmPenerimaanUangUpdateY ifrmChild = new Keuangan.frmPenerimaanUangUpdateY(this, rowID_, HeaderID_, true);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        //ifrmChild.Show();
                    }
                    break;
            }
        }

        private void cdmDeleteY_Click(object sender, EventArgs e)
        {
            switch (SelectedGridY)
            {
                case enumSelectedGrid.Header:
                    if (GVHeaderY.SelectedCells.Count == 0)
                    {
                        return;
                    }
                    DeleteHeaderY();
                    break;
                case enumSelectedGrid.Detail:
                    if (GVDetailY.SelectedCells.Count == 0)
                    {
                        return;
                    }
                    DeleteDetailY();
                    break;
            }
        }

        private void cmdMutasiY_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVDetailY.SelectedCells.Count == 0 || GVHeaderY.SelectedCells.Count == 0)
                {
                    return;
                }
                DataRow drHeader = (DataRow)(GVHeaderY.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                DataRow drDetail = (DataRow)(GVDetailY.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;

                MutasiDKN(drHeader, drDetail);
                Guid HeaderID_ = (Guid)drHeader["RowID"];
                commandButton1.PerformClick();
                RefreshRowDataGridHeaderY(HeaderID_);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        #region O
        #endregion

        private void GVHeaderO_Click(object sender, EventArgs e)
        {
            SelectedGridO = enumSelectedGrid.Header;
        }

        private void GVHeaderO_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridO = enumSelectedGrid.Header;
        }

        private void GVHeaderO_SelectionChanged(object sender, EventArgs e)
        {
            SelectedGridO = enumSelectedGrid.Header;
            if (GVHeaderO.SelectedCells.Count > 0)
            {
                Guid HeaderID_ = (Guid)GVHeaderO.SelectedCells[0].OwningRow.Cells["RowIDO"].Value;
                getPenerimaanO(HeaderID_);
            }
        }



        private void GVDetailO_Click(object sender, EventArgs e)
        {
            SelectedGridO = enumSelectedGrid.Detail;
        }

        private void GVDetailO_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridO = enumSelectedGrid.Detail;
        }

        private void cmdAdd1_Click(object sender, EventArgs e)
        {
            switch (SelectedGridO)
            {
                case enumSelectedGrid.Header:
                    {

                        Keuangan.frmPengeluaranUangUpdate0 ifrmChild = new Keuangan.frmPengeluaranUangUpdate0(this, !true, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVHeaderO.SelectedCells.Count == 0)
                        {
                            return;
                        }


                        DataRow drr = (DataRow)(GVHeaderO.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Guid HeaderID_ = (Guid)drr["RowID"];
                        Guid PTKE_ = (Guid)drr["PerusahaanKeRowID"];

                        //if (PTKE_ != GlobalVar.GetPT.ECR)
                        //{
                        //    MessageBox.Show("Hanya Untuk Eceran");
                        //    return;
                        //}
                        if (GVHeaderO.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        Keuangan.frmPenerimaanUangUpdateO ifrmChild = new Keuangan.frmPenerimaanUangUpdateO(this, HeaderID_, true, drr);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

            


                    }
                    break;
            }
        }

        private void cmdEdit1_Click(object sender, EventArgs e)
        {

            switch (SelectedGridO)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeaderO.SelectedCells.Count == 0)
                        {
                            return;
                        }

                        if (GVDetailO.SelectedCells.Count >= 0)
                        {
                            return;
                        }

                        Guid HeaderID_ = (Guid)GVHeaderO.SelectedCells[0].OwningRow.Cells["RowIDO"].Value;
                         string sumber_ =  GVHeaderO.SelectedCells[0].OwningRow.Cells["SRC"].Value.ToString();
                         if (sumber_.Equals("PenerimaanDetail"))
                        {
                            MessageBox.Show("Tidak Bisa di Edit" + System.Environment.NewLine + "Hanya Hapus dan Insert");
                            return;
                        }

                        Keuangan.frmPengeluaranUangUpdate0 ifrmChild = new Keuangan.frmPengeluaranUangUpdate0(this, !true, HeaderID_, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVDetailO.SelectedCells.Count == 0)
                        {
                            return;
                        }


                        DataRow drr = (DataRow)(GVHeaderO.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Guid HeaderID_ = (Guid)drr["RowID"];
                        Guid PTKE_ = (Guid)drr["PerusahaanKeRowID"];

                        if (PTKE_ != GlobalVar.GetPT.ECR)
                        {
                            MessageBox.Show("Hanya Untuk Eceran");
                            return;
                        }

                        Guid rowID_ = (Guid)GVDetailO.SelectedCells[0].OwningRow.Cells["RowID1O"].Value;
                        //Guid HeaderID_ = (Guid)GVHeaderO.SelectedCells[0].OwningRow.Cells["RowIDO"].Value;
                        Keuangan.frmPenerimaanUangUpdateO ifrmChild = new Keuangan.frmPenerimaanUangUpdateO(this, rowID_, HeaderID_, true);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();

                    }
                    break;
            }
        }



        private void cmdDelete1_Click(object sender, EventArgs e)
        {
            switch (SelectedGridO)
            {
                case enumSelectedGrid.Header:
                    {
                        if (GVHeaderO.SelectedCells.Count == 0)
                        {
                            return;
                        }
                       DeleteHeaderO();
                    }
                    break;
                case enumSelectedGrid.Detail:
                    {
                        if (GVDetailO.SelectedCells.Count == 0)
                        {
                            return;
                        }
                         DeleteDetailO();
                    }
                    break;
            }
        }

        private void cmdMutasi1_Click(object sender, EventArgs e)
        {

            try
            {
                if (GVDetailO.SelectedCells.Count == 0 || GVHeaderO.SelectedCells.Count==0)
                {
                    return;
                }
                DataRow drHeader = (DataRow)(GVHeaderO.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                DataRow drDetail = (DataRow)(GVDetailO.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;

                MutasiPLL(drHeader, drDetail);
                Guid HeaderID_ = (Guid)drHeader["RowID"];
                cmdSearch1.PerformClick();
                RefreshRowDataGridHeaderO(HeaderID_);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedTab.Name)
            {
                case "TPLL1":
                    cmdSearch.PerformClick();
                    break;
                case "TPLL2":
                    cmdSearch1.PerformClick();
                    break;
                case "TPLL3":
                    cmdSearch2.PerformClick();
                    break;
                case "TPLL4":
                    commandButton1.PerformClick();
                    break;

            }
        }

        private void GVDetailY_Click(object sender, EventArgs e)
        {
            SelectedGridY = enumSelectedGrid.Detail;
        }

        private void GVDetailY_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedGridY = enumSelectedGrid.Detail;
        }

        private void cmdSearch1_Click(object sender, EventArgs e)
        {
            if (rangeDateBox4.FromDate.HasValue && rangeDateBox4.ToDate.HasValue)
            {
                getPengeluaranO(rangeDateBox4.FromDate.Value, rangeDateBox4.ToDate.Value);
            }
        }

        private void GVHeaderY_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GVHeaderY.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeaderY.Rows[e.RowIndex].Cells["Saldoaa"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeaderY.ColumnCount; i++)
                    {
                        GVHeaderY.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }

        private void GVHeaderX_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GVHeaderX.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeaderX.Rows[e.RowIndex].Cells["Saldoa"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeaderX.ColumnCount; i++)
                    {
                        GVHeaderX.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }

        private void GVHeaderO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (GVHeaderO.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeaderO.Rows[e.RowIndex].Cells["Saldosadf"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeaderO.ColumnCount; i++)
                    {
                        GVHeaderO.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }

        private void GVHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (GVHeader.RowCount > 0)
            {
                double va = Convert.ToDouble(GVHeader.Rows[e.RowIndex].Cells["Saldo"].Value);
                if (va <= 0)
                {
                    for (int i = 0; i < GVHeader.ColumnCount; i++)
                    {
                        GVHeader.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(224, 220, 221);
                    }
                }

            }
        }

        private void cmdSpesial_Click(object sender, EventArgs e)
        {
            if (GVHeaderO.SelectedCells.Count == 0)
            {
                return;
            }

            DataRow drr = (DataRow)(GVHeaderO.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
            frmPenerimaanUangIdentifikasi ifrmChild = new frmPenerimaanUangIdentifikasi(this, drr);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        






    }
}
