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
    public partial class frmPenerimaanLinkPiutang : ISA.Controls.BaseForm
    {

        DataTable dtPenerimaan = new DataTable(), dtHeader = new DataTable();
        Guid RowIDPenerimaan;
        double Saldo = 0;
        bool Start = false;
        bool edit = false;

        private bool NotValid()
        {
            bool valid = false;


            return valid;

        }

        private double GetSaldo
        {
            get {
                double val = 0;
                if(dtHeader.DefaultView.ToTable().Compute("SUM(RpIden)", "Ok=true AND RpIden>0").ToString()=="")
                {
                    val = txtNominal.GetDoubleValue;
                }else {
                    val =txtNominal.GetDoubleValue - Convert.ToDouble(dtHeader.DefaultView.ToTable().Compute("SUM(RpIden)", "Ok=true AND RpIden>0"));
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
                    db.Commands.Add(db.CreateCommand("[usp_PiutangHeader_LIST]"));
                    //db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Lunas", SqlDbType.Bit, 0));
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
                GVHeader.Columns["Ok"].ReadOnly = false;
                double g = GetSaldo;
                Start = true;
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
                    db.Commands.Add(db.CreateCommand("[usp_PiutangHeader_Reset]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtPenerimaan.Rows[0]["RowID"] ));
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
                    db.Commands.Add(db.CreateCommand("[psp_PiutangDetail_INSERT]"));
                    db.Commands[X].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[X].Parameters.Add(new Parameter("@HeaderID", SqlDbType.VarChar, dv["RowID"]));
                    db.Commands[X].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, dtPenerimaan.Rows[0]["Uraian"].ToString()));
                    db.Commands[X].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text.Trim()));
                    db.Commands[X].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                    db.Commands[X].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, "IDR"));
                    db.Commands[X].Parameters.Add(new Parameter("@TglBukti", SqlDbType.DateTime, txtTglKasir.DateValue));
                    db.Commands[X].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, "KAS"));
                    db.Commands[X].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, dv["RpIden"]));
                    db.Commands[X].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkRetur", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkKPJ", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkPenerimaan", SqlDbType.UniqueIdentifier, dtPenerimaan.Rows[0]["RowID"]));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkPengeluaran", SqlDbType.UniqueIdentifier, SqlGuid.Null));
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


        public frmPenerimaanLinkPiutang()
        {
            InitializeComponent();
        }

        public frmPenerimaanLinkPiutang(Guid RowIDPenerimaan_)
        {
            InitializeComponent();
            RowIDPenerimaan = RowIDPenerimaan_;

        }

        public frmPenerimaanLinkPiutang(Guid RowIDPenerimaan_, bool edited_)
        {
            InitializeComponent();
            RowIDPenerimaan = RowIDPenerimaan_;
            edit = edited_;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit)
                {
                    ResetPiutang();
                }
                DataTable dt = dtHeader.DefaultView.ToTable().Copy();
                dt.DefaultView.RowFilter = "Ok=true AND RpIden>0";
                if (dtHeader.DefaultView.ToTable().Rows.Count == 0)
                {
                    Start = true;
                    throw new Exception("Belum Ada data yang di pilih");
                }
                else if (txtNominal.GetDoubleValue - Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(RpIden)", string.Empty)) < 0) 
                {
                    Start = true;
                    throw new Exception("Nominal Iden Lebih Besar daripada RpKasir");
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

        private void frmPenerimaanLinkPiutang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPenerimaan();

                rangeDateBox1.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox1.ToDate = GlobalVar.GetServerDate;
                RefreshDataGVHeader();

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
                     else {
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
    }
}
