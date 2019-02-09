using System;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Master
{
    public partial class frmGiroUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        DataTable dt;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public frmGiroUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmGiroUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            lookUpRekening1.RekeningRowID = rowID;
            this.Caller = caller;
        }


        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lookUpRekening1.txtSearch.Text))
            {
                MessageBox.Show("No. Rekening belum diisi");
                cboNoRekening.Focus();
                return;
            }


                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        {
                            using (Database db = new Database())
                            {
                                try
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_BukuGiro_INSERT"));

                                    db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoGiroAwal", SqlDbType.VarChar, txtNoGiroAwal.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoGiroAkhir", SqlDbType.VarChar, txtNoGiroAkhir.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Pemegang", SqlDbType.VarChar, txtPemegang.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, numTahun.Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@TanggalKadaluarsa", SqlDbType.Date, dtTanggalKadaluarsa.DateValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    dt = db.Commands[0].ExecuteDataTable();

                                    if (dt.Rows.Count > 0)
                                    {
                                        MessageBox.Show("No.Rekening : " + cboNoRekening.Text + " Sudah terdaftar di database");
                                        cboNoRekening.Text = string.Empty;
                                        cboNoRekening.Focus();
                                        return;
                                    }
                                    MessageBox.Show(Messages.Confirm.SaveSuccess);
                                    this.DialogResult = DialogResult.OK;
                                    closeForm();
                                    this.Close();
                                }
                                catch (Exception Ex) { Error.LogError(Ex); }
                                finally { this.Cursor = Cursors.Default; }
                            }
                           
                            break;
                        }
                    case enumFormMode.Update:
                        {
                            using (Database db = new Database())
                            {
                                try
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_BukuGiro_UPDATE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoGiroAwal", SqlDbType.VarChar, txtNoGiroAwal.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoGiroAkhir", SqlDbType.VarChar, txtNoGiroAkhir.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Pemegang", SqlDbType.VarChar, txtPemegang.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, numTahun.Value));
                                    db.Commands[0].Parameters.Add(new Parameter("@TanggalKadaluarsa", SqlDbType.Date, dtTanggalKadaluarsa.DateValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();

                                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                                    this.DialogResult = DialogResult.OK;
                                    closeForm();
                                    this.Close();
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

                            break;
                            
                        }

               

                }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCabangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmGiroBrowse)
                {
                    frmGiroBrowse frmCaller = (frmGiroBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("NoRekening", cboNoRekening.Text);
                }
            }
        }

        private void frmGiroUpdate_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

       


        private void RefreshData() {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_BukuGiro_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    lookUpRekening1.BankRowID = (Guid)Tools.isNull(dt.Rows[0]["BankRowID"], Guid.Empty);
                    lookUpRekening1.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                    lookUpRekening1.Enabled = false;
                    txtNoGiroAwal.Text = Tools.isNull(dt.Rows[0]["NoGiroAwal"], "").ToString();
                    txtNoGiroAkhir.Text = Tools.isNull(dt.Rows[0]["NoGiroAkhir"], "").ToString();
                    txtPemegang.Text = Tools.isNull(dt.Rows[0]["Pemegang"], "").ToString();
                    numTahun.Value = int.Parse(Tools.isNull(dt.Rows[0]["Tahun"], "0").ToString());
                    if (Tools.isNull(dt.Rows[0]["TanggalKadaluarsa"], "").ToString() != "")
                        dtTanggalKadaluarsa.DateValue = (DateTime)dt.Rows[0]["TanggalKadaluarsa"];
                }
                else
                {
                    DefaultTahunIni();
                    TahunKadaluwasaPlus5();
                    //DateTime d = new DateTime(GlobalVar.GetServerDate.Year, 12, 31);
                    //dtTanggalKadaluarsa.DateValue = d;
                    
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

        #region SetTahunDefault

        private void DefaultTahunIni()
        {
            numTahun.Value = GlobalVar.GetServerDate.Year;
        }

        private void TahunKadaluwasaPlus5()
        {
            dtTanggalKadaluarsa.DateValue = GlobalVar.GetServerDate.AddYears(5);
        }

        #endregion



    }
}
