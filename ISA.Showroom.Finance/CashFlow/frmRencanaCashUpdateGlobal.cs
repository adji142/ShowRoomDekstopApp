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
    public partial class frmRencanaCashUpdateGlobal : ISA.Controls.BaseForm
    {

        #region Var

        DataRow drH, drD ;
        Guid RowH, RowD;
        enum enumFormMode { New, Update };
        enumFormMode FormMode;
 

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
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaGlobal_Detail_INSERT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowD));
                    db.Commands[0].Parameters.Add(new Parameter("@CF_HeaderID", SqlDbType.UniqueIdentifier, drH["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date,txtTglRencana.DateValue.Value  ));
                    db.Commands[0].Parameters.Add(new Parameter("@Value", SqlDbType.Money,txtIDR.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, "IDR"));
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
                    db.Commands.Add(db.CreateCommand("[usp_CF_RencanaGlobal_Detail_UPDATE]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowD));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglRencana.DateValue.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Value", SqlDbType.Money, txtIDR.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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
            if (this.Caller is frmRencanaCash_Global)
            {
                frmRencanaCash_Global frmCaller = (frmRencanaCash_Global)this.Caller;
                frmCaller.RefreshRowDataGridDetail(RowD);
            }
        }

        #endregion




        public frmRencanaCashUpdateGlobal()
        {
            InitializeComponent();
        }

        public frmRencanaCashUpdateGlobal(Form caller, DataRow drH_)
        {
            this.Caller = caller;
            drH = drH_;
            RowH = (Guid)drH_["RowID"];
            FormMode = enumFormMode.New;
            InitializeComponent();
        }


        public frmRencanaCashUpdateGlobal(Form caller, DataRow drH_, DataRow drD_)
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

        private void frmRencanaCashUpdateGlobal_Load(object sender, EventArgs e)
        {
             

            switch (FormMode)
            {
                case enumFormMode.New:
                    txtTglRencana.DateValue = GlobalVar.GetServerDate;
                    txtIDR.Focus();
                    txtIDR.SelectAll();
                    txtKelompokCashFlow.Text = drH["KlpCashFlow"].ToString();
                    txtKelompokTransaksi.Text = drH["KlpTransaksi"].ToString();
                    txtJenisTransaksi.Text = drH["JnsTransaksi"].ToString();
                    break;
                case enumFormMode.Update:
                    txtTglRencana.DateValue = Convert.ToDateTime(drD["Tanggal"]);
      
                    txtIDR.Text = drD["Value"].ToString();
                   
                    txtTglRencana.ReadOnly = true;
                    txtKelompokCashFlow.Text = drD["KlpCashFlow"].ToString();
                    txtKelompokTransaksi.Text = drD["KlpTransaksi"].ToString();
                    txtJenisTransaksi.Text = drD["JnsTransaksi"].ToString();
                    break;

            }
        }



    }
}
