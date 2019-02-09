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
    public partial class frmPengeluaranLinkPiutang : ISA.Controls.BaseForm
    {

        DataTable dtPenerimaan = new DataTable(), dtHeader = new DataTable(), dtHeaderA = new DataTable(),dtHeaderB = new DataTable();
        Guid RowIDPenerimaan;
        double Saldo = 0,SaldoB=0;
        bool Start = false;
        bool StartB = false;
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
                if(dtHeader.DefaultView.ToTable().Compute("SUM(RpADJ)", "Ok=true AND RpADJ>0").ToString()=="")
                {
                    val = txtNominal.GetDoubleValue;
                }else {
                    val =txtNominal.GetDoubleValue - Convert.ToDouble(dtHeader.DefaultView.ToTable().Compute("SUM(RpADJ)", "Ok=true AND RpADJ>0"));
                }
              
                return val;
            }
        }

         private double GetSaldoB
        {
            get {
                double val = 0;
                if(dtHeaderB.DefaultView.ToTable().Compute("SUM(RpKoreksi)", "Ok=true AND RpKoreksi>0").ToString()=="")
                {
                    val = txtNominal.GetDoubleValue;
                }else {
                    val =txtNominal.GetDoubleValue - Convert.ToDouble(dtHeaderB.DefaultView.ToTable().Compute("SUM(RpKoreksi)", "Ok=true AND RpKoreksi>0"));
                }
              
                return val;
            }
        }

        private void LoadPenerimaan()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));

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
                    db.Commands.Add(db.CreateCommand("[psp_PiutangDetail_GET_PENERIMAAN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dtHeaderA = db.Commands[0].ExecuteDataTable();

                }
                GVHeaderA.DataSource = dtHeaderA.DefaultView;

                if (GVHeaderA.SelectedCells.Count > 0)
                {
                  Guid  _RowID = (Guid)GVHeaderA.SelectedCells[0].OwningRow.Cells["RowID"].Value ;
                  RefreshDataGVHeader(_RowID);
                }
                else
                {
                    dtHeader.Rows.Clear();
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

        public void RefreshDataGVHeader(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
              
                Start = false;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[psp_PiutangDetail_GET_PENERIMAAN_Detail]"));
                    db.Commands[0].Parameters.Add(new Parameter("@penerimaanID", SqlDbType.UniqueIdentifier, HeaderID_));
                    dtHeader= db.Commands[0].ExecuteDataTable();

                }

               
                
                dtHeader.Columns.Add("SaldoPiutang", typeof(Double));
                dtHeader.Columns["SaldoPiutang"].Expression = "RpSisa + RpADJ";

                GVDetailA.DataSource = dtHeader.DefaultView;
                GVDetailA.ReadOnly = false;
                GVDetailA.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                for (int i = 0; i < GVDetailA.ColumnCount; i++)
                {
                    GVDetailA.Columns[i].ReadOnly = true;
                }
                GVDetailA.Columns["RpIden"].ReadOnly = false;
                GVDetailA.Columns["Ok"].ReadOnly = false;
           

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
                    db.Commands.Add(db.CreateCommand("[usp_PiutangPengeluaran_Reset]"));
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
            dtHeader.DefaultView.RowFilter = "Ok=true AND RpADJ>0";
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
                    db.Commands[X].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, "ADJ"));
                    db.Commands[X].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Math.Abs(Convert.ToDouble(dv["RpADJ"])) * -1 ));
                    db.Commands[X].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkRetur", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkKPJ", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkPenerimaan", SqlDbType.UniqueIdentifier, SqlGuid.Null));
                    db.Commands[X].Parameters.Add(new Parameter("@LinkPengeluaran", SqlDbType.UniqueIdentifier, dtPenerimaan.Rows[0]["RowID"]));
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


        public void RefreshDataGVHeaderB()
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
                StartB = false;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[psp_PiutangDetail_GET_PENERIMAAN_Pengeluaran]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dtHeaderB = db.Commands[0].ExecuteDataTable();

                }
                GVHeaderB.DataSource = dtHeaderB.DefaultView;

              
                //  dtHeaderB.Columns.Add("SaldoPiutang", typeof(Double));
                //dtHeaderB.Columns["SaldoPiutang"].Expression = "RpSisa + RpKoreksi";

                //GVHeaderB.DataSource = dtHeaderB.DefaultView;
                //GVHeaderB.ReadOnly = false;
                //GVHeaderB.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                //for (int i = 0; i < GVHeaderB.ColumnCount; i++)
                //{
                //    GVHeaderB.Columns[i].ReadOnly = true;
                //}
                //GVHeaderB.Columns["RpKoreksi"].ReadOnly = false;
                //GVHeaderB.Columns["OkB"].ReadOnly = false;
           
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



        public frmPengeluaranLinkPiutang()
        {
            InitializeComponent();
        }

        public frmPengeluaranLinkPiutang(Guid RowIDPenerimaan_)
        {
            InitializeComponent();
            RowIDPenerimaan = RowIDPenerimaan_;

        }

        public frmPengeluaranLinkPiutang(Guid RowIDPenerimaan_, bool edited_)
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
                //if (NotValid())
                //{
                //    return;
                //}
                DataTable dt = dtHeader.DefaultView.ToTable().Copy();
                dt.DefaultView.RowFilter = "Ok=true AND RpADJ>0";
                if (dt.DefaultView.ToTable().Rows.Count == 0)
                {
                    throw new Exception("Belum Ada data yang di pilih");
                }
                else if (txtNominal.GetDoubleValue != Convert.ToDouble(dt.DefaultView.ToTable().Compute("SUM(RpADJ)", string.Empty))) 
                {
                    throw new Exception("Nominal ADJ Harus sama dengan Pengeluaran Kasir");
                }
                InsertRecord(dt.DefaultView.ToTable());


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmPengeluaranLinkPiutang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPenerimaan();
                if (edit)
                {
                    ResetPiutang();
                }
                rangeDateBox2.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
                rangeDateBox2.ToDate = GlobalVar.GetServerDate;
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
                        DataRow drr = (DataRow)(GVDetailA.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        string NamaKolom = GVDetailA.Columns[e.ColumnIndex].Name.ToString().ToUpper();
                      //  DataRow drr = (DataRow)(GVHeader.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                        switch (NamaKolom)
                        {

                            case "OK":
                                {
                                    if (Convert.ToBoolean(drr["Ok"]) == true)
                                    {
                                        drr["RpADJ"] = 0;
                                       // drr["Ok"] = false;
                                        Saldo = GetSaldo;
                                    }
                                    else
                                    {

                                        Saldo = GetSaldo;
                                    }


                                }
                                break;



                        }
                    }

                    e.Cancel = true;
                    return;
                }
                else if (Start)
                {

                    string NamaKolom = GVDetailA.Columns[e.ColumnIndex].Name.ToString().ToUpper();
                    DataRow drr = (DataRow)(GVDetailA.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    switch (NamaKolom)
                    {
                        case "RpADJ":
                            {
                                double RpSisa = Convert.ToDouble(drr["SaldoPiutang"]);
                               // drr["Ok"] = true;
                                if (Saldo - RpSisa >= 0)
                                {
                                    drr["RpADJ"] = RpSisa;
                                }
                                else
                                {
                                    drr["RpADJ"] = Saldo;
                                }
                            }

                            break;
                        case "OK":
                            {
                                if (Convert.ToBoolean(drr["Ok"]) == true)
                                {
                                    drr["RpADJ"] = 0;
                                    drr["Ok"] = false;
                                }
                                else
                                {

                                    double RpSisa = Convert.ToDouble(drr["SaldoPiutang"]);
                                    //drr["Ok"] = true;
                                    if (Saldo - RpSisa >= 0)
                                    {
                                        drr["RpADJ"] = RpSisa;
                                    }
                                    else
                                    {
                                        drr["RpADJ"] = Saldo;
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
                    string NamaKolom = GVDetailA.Columns[e.ColumnIndex].Name.ToString().ToUpper();
                    DataRow drr = (DataRow)(GVDetailA.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                     double RpIden_ = Convert.ToDouble(drr["RpADJ"]);
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

        private void GVHeaderA_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void GVHeaderB_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void GVHeaderB_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void GVHeaderB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            RefreshDataGVHeaderB();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if(GVHeaderB.SelectedCells.Count==1)
            {
            try 
            {


                  Guid  _RowID = (Guid)GVHeaderB.SelectedCells[0].OwningRow.Cells["RowIDHeaderB"].Value ;
                  double _Sisa = Convert.ToDouble(GVHeaderB.SelectedCells[0].OwningRow.Cells["NominalSisaB"].Value);
                  if ( txtNominal.GetDoubleValue >  _Sisa )
                  {
                      throw new Exception("Nilai ADJ lebih besar dari Nominal Sisa (" + _Sisa.ToString("#,##0") + ")");
                  }
                  using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[psp_PiutangDetail_GET_PENERIMAAN_CLOSING]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, dtPenerimaan.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@penerimaanID", SqlDbType.UniqueIdentifier,_RowID));
                    dtHeaderB = db.Commands[0].ExecuteDataTable();

                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            
            }catch(Exception ex)
            {
            Error.LogError(ex);
            }


            }
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
        
        }

         
    }
}
