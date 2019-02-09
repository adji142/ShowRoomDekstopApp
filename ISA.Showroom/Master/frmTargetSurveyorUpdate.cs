using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Master
{
    public partial class frmTargetSurveyorUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID, _SurveyorRowID;
        String _cabangID = GlobalVar.CabangID;

        public frmTargetSurveyorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmTargetSurveyorUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lookUpSurveyor1.txtNamaSurveyor.Text))
                {
                    MessageBox.Show("Surveyor belum dipilih !");
                    lookUpSurveyor1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txttmt.Text))
                {
                    MessageBox.Show("TMT belum diisi !");
                    txttmt.Focus();
                    return;
                }                
                if (string.IsNullOrEmpty(txttargetrp.Text))
                {
                    MessageBox.Show("Target Rp belum diisi !");
                    txttargetrp.Focus();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetSurveyor_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@SurveyorRowID", SqlDbType.UniqueIdentifier, lookUpSurveyor1._Surveyor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.Date, txttmt.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetRp", SqlDbType.Money, txttargetrp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        MessageBox.Show("Data berhasil ditambahkan");
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetSurveyor_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            if (lookUpSurveyor1._Surveyor.RowID == Guid.Empty)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@SurveyorRowID", SqlDbType.UniqueIdentifier, _SurveyorRowID));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@SurveyorRowID", SqlDbType.UniqueIdentifier, lookUpSurveyor1._Surveyor.RowID));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.Date, txttmt.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetRp", SqlDbType.Money, txttargetrp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        MessageBox.Show("Data berhasil diupdate");
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate !");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmTargetSurveyorUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (formMode == enumFormMode.Update)
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TargetSurveyor_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        lookUpSurveyor1.txtNamaSurveyor.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                        _SurveyorRowID = (Guid)Tools.isNull(dt.Rows[0]["SurveyorRowID"], "");
                        txttmt.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TMT"], "");                       
                        txttargetrp.Text = Tools.isNull(dt.Rows[0]["Target_Rp"], "").ToString();
                    }
                }
                else
                {
                    txttmt.Text = "";                    
                    txttargetrp.Text = "";
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

        private void frmTargetSurveyorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmTargetSurveyorBrowse)
            {
                Master.frmTargetSurveyorBrowse frmCaller = (Master.frmTargetSurveyorBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("Nama", lookUpSurveyor1.txtNamaSurveyor.Text);
            }
        }

        private void lookUpSurveyor1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txttmt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txttargetrp_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
