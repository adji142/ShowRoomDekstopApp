using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.CashFlow
{
    public partial class frmRencanaCashUpdate : ISA.Controls.BaseForm
    {

        #region Var

        DataRow drH, drD ;
        Guid RowH, RowD;
        enum enumFormMode { New, Update };
        enumFormMode FormMode;
        double KursAwal = 1;

        #endregion

        #region Function

        private bool NotValid()
        {
            bool val = false;
            ErrorProvider err = new ErrorProvider();


            if (!txtTglRencana.DateValue.HasValue)
            {
                err.SetError(txtTglRencana, "Harus di ISI !!!");
                val = true;
            }
            else
            {
                if (txtTglRencana.DateValue.Value.DayOfWeek== DayOfWeek.Sunday)
                {
                    err.SetError(txtTglRencana, "Tidak Boleh Hari Minggu !!!");
                    val = true;
                }

            }

           

            if (txtUSD.GetDoubleValue<=0)
            {
                err.SetError(txtUSD, "Harus di ISI !!!");
                val = true;
            }
            if (txtKurs.GetDoubleValue <= 0)
            {
                err.SetError(txtKurs, "Harus di ISI !!!");
                val = true;
            }


            if (txtIDR.GetDoubleValue <= 0)
            {
                err.SetError(txtIDR, "Harus di ISI !!!");
                val = true;
            }

            return val;
        }

        private void Insert() 
        {
            RowD = Guid.NewGuid();
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaPembayaranHutangDetail_Insert]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowD));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, drH["VendorRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@PLRowiD ", SqlDbType.UniqueIdentifier, drH["RowId"]));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, drH["MataUangRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalRencana", SqlDbType.Date,txtTglRencana.DateValue.Value  ));
                    db.Commands[0].Parameters.Add(new Parameter("@TglPL", SqlDbType.Date,txtTglInvoice.DateValue.Value ));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPL", SqlDbType.VarChar, txtNoInvoice.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@USDNominal", SqlDbType.Money, txtUSD.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@IDRNominal", SqlDbType.Money,txtIDR.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Kurs", SqlDbType.Money,txtKurs.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID ));

                    db.Commands[0].ExecuteNonQuery();

                }

              RefreshGrid();
              this.DialogResult = DialogResult.OK;
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

        private void Update()
        {
           
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CF_RencanaPembayaranHutangDetail_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowD));
                    db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, drD["VendorRowID"]));
                   // db.Commands[0].Parameters.Add(new Parameter("@PLRowiD ", SqlDbType.UniqueIdentifier, drD["PLRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, drD["MataUangRowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalRencana", SqlDbType.Date, txtTglRencana.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@USDNominal", SqlDbType.Money, txtUSD.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@IDRNominal", SqlDbType.Money, txtIDR.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Kurs", SqlDbType.Money, txtKurs.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@PerusahaanID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

                    db.Commands[0].ExecuteNonQuery();

                }

                RefreshGrid();
                this.DialogResult = DialogResult.OK;
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

        private void RefreshGrid()
        {
            if (this.Caller is frmRencanaCash)
            {
                frmRencanaCash frmCaller = (frmRencanaCash)this.Caller;
                frmCaller.RefreshRowDataGridDetail(RowD);
            }
        }

        #endregion




        public frmRencanaCashUpdate()
        {
            InitializeComponent();
        }

        public frmRencanaCashUpdate(Form caller, DataRow drH_)
        {
            this.Caller = caller;
            drH = drH_;
            RowH = (Guid)drH_["RowID"];
            FormMode = enumFormMode.New;
            InitializeComponent();
        }


        public frmRencanaCashUpdate(Form caller, DataRow drH_, DataRow drD_)
        {
            this.Caller = caller;
            drH = drH_;
            drD = drD_;
            RowH = (Guid)drH_["RowID"];
            RowD = (Guid)drD_["RowID"];
            FormMode = enumFormMode.Update;
            InitializeComponent();
        }


        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (NotValid())
            {
                return;
            }
            switch (FormMode)
            { 
                case enumFormMode.New:
                    Insert();
                    break;
                case enumFormMode.Update:
                    Update();
                    break;

            }
        }

        private void frmRencanaCashUpdate_Load(object sender, EventArgs e)
        {

            txtVendor.Text = drH["VendorID"].ToString().Trim() + " - " + drH["NamaVendor"].ToString().Trim();
            txtTglInvoice.DateValue = Convert.ToDateTime(drH["TglPL"]);
            txtNoInvoice.Text = drH["NoPL"].ToString();
            txtMU.Text = drH["MataUangID"].ToString();
            txtNominalUSD.Text = drH["NominalUSD"].ToString();
            txtNominalIDR.Text = drH["NominalIDR"].ToString();
            txtSaldoUSD.Text = drH["SaldoUSD"].ToString();
            txtSaldoIDR.Text = drH["SaldoIDR"].ToString();
            KursAwal = Convert.ToDouble(drH["NominalIDR"]) / Convert.ToDouble(drH["NominalUSD"]);
            switch (FormMode)
            {
                case enumFormMode.New:
                    txtTglRencana.DateValue = GlobalVar.GetServerDate;
                    txtKurs.Text = KursAwal.ToString();
                    break;
                case enumFormMode.Update:
                    txtTglRencana.DateValue = Convert.ToDateTime(drD["TanggalRencana"]);
                    txtUSD.Text = drD["USDNominal"].ToString();
                    txtIDR.Text = drD["IDRNominal"].ToString();
                    txtKurs.Text = drD["Kurs"].ToString();
                    txtTglRencana.ReadOnly = true;
                    break;

            }
        }

        private void txtUSD_Validated(object sender, EventArgs e)
        {
            if (txtUSD.Text == string.Empty || txtUSD.GetDoubleValue == 0)
            {
                txtUSD.Focus();
                txtUSD.SelectAll();
            }
            else {
                txtIDR.Text = (txtUSD.GetDoubleValue * txtKurs.GetDoubleValue).ToString();
            }
        }

        private void txtKurs_Validated(object sender, EventArgs e)
        {
            if (txtKurs.Text == string.Empty || txtKurs.GetDoubleValue == 0)
            {
                txtKurs.Focus();
                txtKurs.SelectAll();
            }
            else
            {
                txtIDR.Text = (txtUSD.GetDoubleValue * txtKurs.GetDoubleValue).ToString();
            }
        }
    }
}
