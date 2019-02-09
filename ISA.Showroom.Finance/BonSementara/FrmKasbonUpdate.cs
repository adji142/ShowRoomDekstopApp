using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.BonSementara
{
    public partial class FrmKasbonUpdate : ISA.Controls.BaseForm
    {
        DateTime _TglNow;
        enum enumFormMode { New, Update };
        enumFormMode FormMode;
        Guid _rowID;
        DataTable dt;
        string cNoBKK;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public FrmKasbonUpdate(Form _caller)
        {
            InitializeComponent();
            _TglNow = GlobalVar.GetServerDate;
            txtTanggal.DateValue  = _TglNow;
            FormMode = enumFormMode.New;
            this.Caller = _caller;
        }

        public FrmKasbonUpdate(Form _caller, Guid rowID)
        {
            InitializeComponent();
            _TglNow = GlobalVar.GetServerDate;
            txtTanggal.DateValue = _TglNow;
            FormMode = enumFormMode.Update;
            this.Caller = _caller;
            _rowID = rowID;
        }

        private void FrmKasbonUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                LoadForm();
                this.Cursor = Cursors.WaitCursor;
                cboUnitUsaha.SelectedIndex = 0;
                if (FormMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_KasBon_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    txtTanggal.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["Tanggal"], "");
                    txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                    txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
                    txtNo_bukti.Text = Tools.isNull(dt.Rows[0]["No_bukti"], "").ToString();
                    Guid KasRowID = (Guid)(Tools.isNull(dt.Rows[0]["KasRowID"],Guid.Empty));
                    fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                    cboKas.SelectedValue = KasRowID;
                    //Tambahan UnitUsaha
                    if ((Tools.isNull(dt.Rows[0]["UnitUsaha"], "").ToString()) != "")
                    {
                        cboUnitUsaha.SelectedItem = dt.Rows[0]["UnitUsaha"].ToString();
                    }
                }
                else
                {
                    fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
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
        
        #region Functions
        private void LoadForm()
        {
            DataTable dtPgw = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("Usp_Karyawan_LIST_Header"));
                dtPgw = db.Commands[0].ExecuteDataTable();

                cboPegawai.DataSource = dtPgw;
                cboPegawai.DisplayMember = "NamaKaryawan";
                cboPegawai.ValueMember = "RowID";
                LoadEdit();
            }
        }

        private void LoadEdit()
        {
            if (FormMode == enumFormMode.Update)
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kasbon_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                cboPegawai.Text = Tools.isNull(dt.Rows[0]["NamaKaryawan"], "").ToString();
            }
        }

        private void closeForm()
        {
            if (this.Caller is frmKasbonBrowse)
            {
                frmKasbonBrowse frmCaller = (frmKasbonBrowse)this.Caller;
                frmCaller.RefreshData();
                switch (FormMode)
                {
                    case enumFormMode.New:
                        {
                            frmCaller.FindRow("No_bukti", cNoBKK.PadRight(20), 1);
                            break;
                        }
                    case enumFormMode.Update:
                        {
                            frmCaller.FindRow("RowID", _rowID.ToString(), 1);
                            break;
                        }
                }
            }
        }

        #endregion

        private void commandSAVE_Click(object sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            if (cboKas.SelectedValue.ToString() == "" || cboKas.SelectedValue.ToString()== Guid.Empty.ToString())
            {

                err.SetError(cboKas, "Pilih Datanya");
                return;
            }

            if (cboPegawai.SelectedValue.ToString() == "")
            {

                err.SetError(cboPegawai, "Pilih Datanya");
                return;
            }
            if (!txtTanggal.DateValue.HasValue)
            {
                err.SetError(txtTanggal, "Isi Datanya");
                return;
            }
           
            switch (FormMode)
            {
                case enumFormMode.New:
                    {
                        if (txtNominal.GetDoubleValue <= 0)
                        {
                            err.SetError(txtNominal, "Isi Datanya");
                            return;
                        }

                        cNoBKK = Numerator.GetNomorDokumen("PENGELUARAN_KASBON", "",
                                                    "/BS/" + string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                    , 3, false, true);
                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Kasbon_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue ));
                            db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowId", SqlDbType.UniqueIdentifier, cboPegawai.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text ));
                            db.Commands[0].Parameters.Add(new Parameter("@No_bukti", SqlDbType.Char, cNoBKK));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, txtNominal.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier,cboKas.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID ));
                            db.Commands[0].Parameters.Add(new Parameter("@UnitUsaha", SqlDbType.VarChar, cboUnitUsaha.Text));

                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show(Messages.Confirm.SaveSuccess);
                        }
                        closeForm();
                        this.Close();
                        break;
                    }
                case enumFormMode.Update:
                    {
                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Kasbon_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowId", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowId", SqlDbType.UniqueIdentifier, cboPegawai.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, float.Parse(txtNominal.Text.ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID ));
                            db.Commands[0].Parameters.Add(new Parameter("@UnitUsaha", SqlDbType.VarChar, cboUnitUsaha.Text));

                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show(Messages.Confirm.UpdateSuccess);
                        }
                        closeForm();
                        this.Close();
                        break;
                    }
            }
        }

        private void commandCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
