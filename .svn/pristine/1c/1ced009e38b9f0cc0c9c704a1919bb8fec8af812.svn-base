using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmPerkiraanUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _NoPerkiraan;

        DataTable dt;


        public frmPerkiraanUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPerkiraanUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }
        public frmPerkiraanUpdate(Form caller, string NoPerkiraan)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            txtNoPerkiraan.ReadOnly = true;
            _NoPerkiraan = NoPerkiraan;
            this.Caller = caller;
        }


        public frmPerkiraanUpdate()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerkiraanUpdate_Load(object sender, EventArgs e)
        {
            // untuk sementara dari levelnya 1 2 3 4 5, jadi hanya level 5 saja dulu 
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBHoldingName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtNoPerkiraan.Text = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                    txtUraian.Text = Tools.isNull(dt.Rows[0]["NamaPerkiraan"], "").ToString();
                    txtRef.Text = Tools.isNull(dt.Rows[0]["Ref"], "").ToString();
                    cboLevel.Text = Tools.isNull(dt.Rows[0]["Level"], "").ToString();
                    chkPassive.Checked = (bool)dt.Rows[0]["Pasif"];
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

        private bool validasiSave()
        {
            bool tempresult = true;
            string temperror = "";

            if (cboLevel.Text == "")
            {
                temperror = temperror + "Level perlu diisikan!\n";
                cboLevel.Text = "5";
                tempresult = false;
            }
            else if (txtNoPerkiraan.Text == "")
            {
                temperror = temperror + "Nomor Perkiraan perlu diisikan!\n";
                tempresult = false;
            }
            else if(txtUraian.Text == "")
            {
                temperror = temperror + "Uraian Perkiraan perlu diisikan!\n";
                tempresult = false;
            }

            // cek apakah nomor perkiraan yg lagi diinput/diupdate itu udah ada atau belum
            // ini perlu cek hanya pas insert
            if (formMode == enumFormMode.New)
            {
                DataTable dummy = new DataTable();
                using(Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Perkiraan_LIST"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                    dummy = dbsub.Commands[0].ExecuteDataTable();
                    if (dummy.Rows.Count > 0)
                    {
                        temperror = temperror + "Nomor Perkiraan sudah digunakan!\n";
                        tempresult = false;
                    }
                }
            }
            if (temperror != "" || tempresult == false)
            {
                MessageBox.Show(temperror, "Informasi");
            }

            return tempresult;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(validasiSave())
            {
                UpSert();
            }
        }

        private void UpSert()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database(GlobalVar.DBHoldingName))
                        {

                            db.Commands.Add(db.CreateCommand("usp_Perkiraan_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, txtRef.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Level", SqlDbType.VarChar, cboLevel.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                            db.Commands[0].Parameters.Add(new Parameter("@Pasif", SqlDbType.VarChar, chkPassive.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            this._NoPerkiraan = txtNoPerkiraan.Text;
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database(GlobalVar.DBHoldingName))
                        {

                            db.Commands.Add(db.CreateCommand("usp_Perkiraan_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, txtRef.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Level", SqlDbType.VarChar, cboLevel.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                            db.Commands[0].Parameters.Add(new Parameter("@Pasif", SqlDbType.VarChar, chkPassive.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
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

        private bool InputIsValid()
        {
            bool valid = true;

            if (txtNoPerkiraan.Text == string.Empty)
            {
                txtNoPerkiraan.Focus();
                errorProvider1.SetError(txtNoPerkiraan, Messages.Error.InputRequired);
                valid = false;
            }
            if (txtUraian.Text == string.Empty)
            {
                txtUraian.Focus();
                errorProvider1.SetError(txtUraian, Messages.Error.InputRequired);
                valid = false;
            }
            if (txtRef.Text == string.Empty)
            {
                txtRef.Focus();
                errorProvider1.SetError(txtRef, Messages.Error.InputRequired);
                valid = false;
            }

            return valid;
        }

        private void frmPerkiraanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is GL.frmPerkiraanBrowse)
                {
                    GL.frmPerkiraanBrowse frmCaller = (GL.frmPerkiraanBrowse)this.Caller;
                    frmCaller.RefreshRowData(_rowID.ToString());
                    if (this.formMode == enumFormMode.New)
                    {
                        frmCaller.FindRow("RowID", _rowID.ToString());
                    }
                }
            }
            
        }
    }
}
