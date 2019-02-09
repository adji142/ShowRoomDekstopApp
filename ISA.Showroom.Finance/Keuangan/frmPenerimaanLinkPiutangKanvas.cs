using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPenerimaanLinkPiutangKanvas : ISA.Controls.BaseForm
    {

        DataTable dtPenerimaan = new DataTable(), dtHeader = new DataTable(), dtIden = new DataTable();
        Guid RowIDPenerimaan;
        double Saldo = 0;
        bool Start = false;
        bool edit = false;
        bool NewData = true;


        private bool NotValid()
        {
            bool valid = false;
            DataTable dt = dtHeader.DefaultView.ToTable().Copy();


            return valid;

        }

        private double GetSaldo
        {
            get
            {
                double val = 0;
                double val2 = 0;
                if (dtIden.DefaultView.ToTable().Compute("SUM(RpIden)", "RpIden>0").ToString() == "" && dtHeader.DefaultView.ToTable().Compute("SUM(RpIden)", "RpIden>0").ToString() == "")
                {
                    val = txtNominal.GetDoubleValue;
                }
                else
                {
                    double rpHeader = 0;
                    double rpDetail = 0;
                    if (dtHeader.DefaultView.ToTable().Compute("SUM(RpIden)", "RpIden>0").ToString() != "")
                    {
                        rpHeader = Convert.ToDouble(dtHeader.DefaultView.ToTable().Compute("SUM(RpIden)", "RpIden>0"));

                    }
                    if (dtIden.DefaultView.ToTable().Compute("SUM(RpIden)", "RpIden>0").ToString() != "")
                    {
                        rpDetail = Convert.ToDouble(dtIden.DefaultView.ToTable().Compute("SUM(RpIden)", "RpIden>0"));

                    }
                    val = txtNominal.GetDoubleValue - rpHeader - rpDetail;
                }
                txtSaldo.Text = val.ToString();
                return val;
            }
        }

        private void LoadPenerimaan()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDPenerimaan));
                    dtPenerimaan = db.Commands[0].ExecuteDataTable();
                }
                txtNoBukti.Text = dtPenerimaan.Rows[0]["NoBukti"].ToString();
                txtTglKasir.DateValue = (DateTime)dtPenerimaan.Rows[0]["TanggalRk"];
                txtNominal.Text = dtPenerimaan.Rows[0]["NominalRp"].ToString();
                Saldo = txtNominal.GetDoubleValue;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void RefreshDataGVHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!rangeDateBox1.FromDate.HasValue || !rangeDateBox1.ToDate.HasValue)
                {
                    ErrorProvider err = new ErrorProvider();
                    err.SetError(rangeDateBox1, " Must Be Fill !!!");
                    throw new Exception("Date Must Be Fill !!!");
                }
                Start = false;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PiutangHeaderKanvaser_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanRowID", SqlDbType.UniqueIdentifier, RowIDPenerimaan));
                    dtHeader = db.Commands[0].ExecuteDataTable();

                }
                dtHeader.Columns.Add("SaldoPiutang", typeof(Double));
                dtHeader.Columns["SaldoPiutang"].Expression = "RpSisa - RpIden";

                GVHeader.DataSource = dtHeader.DefaultView;
                GVHeader.ReadOnly = false;
                GVHeader.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                for (int i = 0; i < GVHeader.ColumnCount; i++)
                {
                    GVHeader.Columns[i].ReadOnly = true;
                }
                GVHeader.Columns["RpIden"].ReadOnly = false;
                //  GVHeader.Columns["Ok"].ReadOnly = false;

                Start = true;

                if (NewData)
                {
                    dtIden = dtHeader.Clone();
                    GVDetail.DataSource = dtIden.DefaultView;
                    NewData = false;
                }
                double g = GetSaldo;
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


        public void ResetPiutang()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Start = false;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PiutangHeaderKanvaser_Reset]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtPenerimaan.Rows[0]["RowID"]));
                    db.Commands[0].ExecuteNonQuery();

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

        private void InsertRecord(DataTable dtTemp)
        {
            dtHeader.DefaultView.RowFilter = "Ok=true AND RpIden>0";
            //  DataTable dtTemp = dtHeader.DefaultView.ToTable().Copy();
            using (Database db = new Database())
            {
                int X = 0;
                foreach (DataRowView dv in dtTemp.DefaultView)
                {
                    Guid RowID = Guid.NewGuid();
                    db.Commands.Add(db.CreateCommand("[psp_PiutangDetailKanvaser_INSERT]"));
                    db.Commands[X].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[X].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, dv["RowID"]));
                    db.Commands[X].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, dtPenerimaan.Rows[0]["Uraian"].ToString()));
                    db.Commands[X].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text.Trim()));
                    //db.Commands[X].Parameters.Add(new Parameter("@TglBukti", SqlDbType.DateTime, txtTglKasir.DateValue));
                    //db.Commands[X].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, "KAS"));
                    db.Commands[X].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, dv["RpIden"]));
                    db.Commands[X].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkPenerimaan", SqlDbType.UniqueIdentifier, dtPenerimaan.Rows[0]["RowID"]));
                    X++;
                }
                db.BeginTransaction();
                for (int i = 0; i < db.Commands.Count; i++)
                {
                    db.Commands[i].ExecuteNonQuery();
                }
                db.CommitTransaction();

            }
        }


        public frmPenerimaanLinkPiutangKanvas()
        {
            InitializeComponent();
        }

        public frmPenerimaanLinkPiutangKanvas(Guid RowIDPenerimaan_)
        {
            InitializeComponent();
            RowIDPenerimaan = RowIDPenerimaan_;

        }

        public frmPenerimaanLinkPiutangKanvas(Guid RowIDPenerimaan_, bool edited_)
        {
            InitializeComponent();
            RowIDPenerimaan = RowIDPenerimaan_;
            edit = edited_;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dtPenerimaan.Rows[0]["RowID"]));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                this.DialogResult = DialogResult.Abort;
                this.Close();


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }



        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (edit)
                //{
                //    ResetPiutang();
                //}
                DataTable dt = dtIden.DefaultView.ToTable().Copy();
                dt.DefaultView.RowFilter = "RpIden>0";
                if (dt.DefaultView.ToTable().Rows.Count == 0)
                {
                    Start = true;
                    throw new Exception("Belum Ada data yang di pilih");
                }
                else if (txtNominal.GetDoubleValue - Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(RpIden)", string.Empty)) != 0)
                {
                    Start = true;
                    throw new Exception("Nominal Iden tidak sama dengan  RpKasir");
                }
                InsertRecord(dt.DefaultView.ToTable());
                Start = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmPenerimaanLinkPiutangKanvas_Load(object sender, EventArgs e)
        {
            try
            {

                LoadPenerimaan();

                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox1.ToDate = GlobalVar.GetServerDate;
                RefreshDataGVHeader();
                if (edit)
                {
                    ResetPiutang();
                }


            }
            catch (Exception ex)
            {

                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataGVHeader();
        }

        private void GVHeader_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.ToString());
            }

        }

        private void GVHeader_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                Saldo = GetSaldo;
                if (Saldo <= 0)
                {
                    if (Start)
                    {
                        DataRow drr = (DataRow)(GVHeader.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        string NamaKolom = GVHeader.Columns[e.ColumnIndex].Name.ToString().ToUpper();
                        //  DataRow drr = (DataRow)(GVHeader.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                        switch (NamaKolom)
                        {

                            case "OK":
                                {
                                    if (Convert.ToBoolean(drr["Ok"]) == true)
                                    {
                                        drr["RpIden"] = 0;
                                        drr["Ok"] = false;
                                        Saldo = GetSaldo;
                                    }
                                    else
                                    {
                                        drr["RpIden"] = 0;
                                        Saldo = GetSaldo;
                                    }


                                }
                                break;



                        }
                    }


                }
                else if (Start)
                {

                    string NamaKolom = GVHeader.Columns[e.ColumnIndex].Name.ToString().ToUpper();
                    DataRow drr = (DataRow)(GVHeader.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    switch (NamaKolom)
                    {
                        case "RPIDEN":
                            {
                                double RpSisa = Convert.ToDouble(drr["SaldoPiutang"]);
                                // drr["Ok"] = true;
                                if (Saldo - RpSisa >= 0)
                                {
                                    drr["RpIden"] = RpSisa;
                                }
                                else
                                {
                                    drr["RpIden"] = Saldo;
                                }
                            }

                            break;
                        case "OK":
                            {
                                if (Convert.ToBoolean(drr["Ok"]) == true)
                                {
                                    drr["RpIden"] = 0;
                                    drr["Ok"] = false;
                                }
                                else
                                {

                                    double RpSisa = Convert.ToDouble(drr["SaldoPiutang"]);
                                    //drr["Ok"] = true;
                                    if (Saldo - RpSisa >= 0)
                                    {
                                        drr["RpIden"] = RpSisa;
                                    }
                                    else
                                    {
                                        drr["RpIden"] = Saldo;
                                    }
                                }


                            }
                            break;



                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void GVHeader_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Start)
            {
                try
                {
                    string NamaKolom = GVHeader.Columns[e.ColumnIndex].Name.ToString().ToUpper();
                    DataRow drr = (DataRow)(GVHeader.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    if (drr["RpIden"].ToString() == String.Empty)
                    {
                        drr["RpIden"] = 0;
                    }
                    double RpIden_ = Convert.ToDouble(drr["RpIden"]);
                    if (RpIden_ > 0)
                    {
                        drr["Ok"] = true;
                    }
                    else
                    {
                        drr["Ok"] = false;
                    }
                    Saldo = GetSaldo;

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }
        }

        private void GVHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GVHeader.SelectedCells.Count == 0)
            {
                return;
            }
            switch (e.ColumnIndex)
            {
                case 9:

                    //                    DataRowView dv = (DataRowView)GVHeader.SelectedCells[0].OwningRow.DataBoundItem;
                    //DataRow drr = dv.Row;



                    DataRow drr = (DataRow)(GVHeader.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    double RpIden_ = Convert.ToDouble(drr["RpIden"]);
                    if (Convert.ToBoolean(drr["Ok"]) == true && RpIden_ > 0)
                    {

                        if (dtIden.Select("RowID='" + drr["RowID"].ToString() + "'").Length > 0)
                        {
                            MessageBox.Show("Sudah Ada di IdenTifikasi");
                            return;
                        }

                        DataRow drN = dtIden.NewRow();

                        foreach (DataColumn dc in drN.Table.Columns)
                        {
                            drN[dc.ColumnName] = drr[dc.ColumnName];
                        }
                        dtIden.Rows.Add(drN);
                        dtIden.AcceptChanges();
                        drr.Delete();
                        dtHeader.AcceptChanges();
                        GVDetail.RefreshEdit();

                    }

                    break;
            }
        }

        private void GVDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GVDetail.SelectedCells.Count == 0)
            {
                return;
            }
            switch (e.ColumnIndex)
            {
                case 8:
                    DataRow drr = (DataRow)(GVDetail.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    //            DataRowView dv = (DataRowView)GVHeader.SelectedCells[0].OwningRow.DataBoundItem;
                    //DataRow dr = dv.Row;
                    drr.Delete();
                    dtIden.AcceptChanges();

                    double le = GetSaldo;
                    break;
            }
        }

        private void frmPenerimaanLinkPiutangKanvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dtPenerimaan.Rows[0]["RowID"]));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    this.DialogResult = DialogResult.Abort;
                    MessageBox.Show("Identifikasi Piutang di Batalkan");


                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }

        }
    }
}
