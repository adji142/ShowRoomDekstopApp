using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.HI
{
    public partial class frmHubunganIstimewaUpdateDetail : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _headerRowID, _detailRowID;
        string _noBukti;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public frmHubunganIstimewaUpdateDetail()
        {
            InitializeComponent();
        }

        public frmHubunganIstimewaUpdateDetail(Form caller, Guid headerRowID, string noBukti)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New;
            _headerRowID = headerRowID;
            _noBukti = noBukti;
        }

        public frmHubunganIstimewaUpdateDetail(Form caller, string noBukti, Guid detailRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.Update;
            _detailRowID = detailRowID;
            _noBukti = noBukti;
        }

        private void frmHubunganIstimewaUpdateDetail_Load(object sender, EventArgs e)
        {
//            fcbo.fillComboPerkiraan(cboNoPerkiraan);
            RefreshData();
        }

        private void RefreshData() {
            switch (formMode)
            {
                case enumFormMode.New:
                    {
                    }
                    break;
                case enumFormMode.Update:
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _detailRowID));
                                dt = db.Commands[0].ExecuteDataTable();

                                if (dt.Rows.Count > 0)
                                {
                                    txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                                    txtReferensi.Text = Tools.isNull(dt.Rows[0]["Referensi"], "").ToString();
                                    txtNominal.Text = string.Format("{0:0.0,0}",dt.Rows[0]["Nominal"]);
//                                    cboNoPerkiraan.SelectedValue = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                                    lookUpPerkiraan1.NoPerkiraan = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                                }
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
                    break;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID",SqlDbType.UniqueIdentifier,_headerRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan",SqlDbType.VarChar,lookUpPerkiraan1.NoPerkiraan));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Error...");
                                    return;
                                }
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _detailRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan",SqlDbType.VarChar,lookUpPerkiraan1.NoPerkiraan));
                                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            this.DialogResult = DialogResult.OK;
            this.closeForm();
            this.Close();
        }

        private void closeForm()
        {
            //if (this.DialogResult == DialogResult.OK)
            //{
            if (this.Caller is frmHubunganIstimewaBrowse)
            {
                frmHubunganIstimewaBrowse frmCaller = (frmHubunganIstimewaBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRowID("NoBukti", _noBukti);
            }
            //}
            //this.Close();
        }

    }
}
