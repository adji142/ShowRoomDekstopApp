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
    public partial class frmKasbonVJU : ISA.Controls.BaseForm
    {
        DateTime _TglNow;
        enum enumFormMode { New, Update };
        enumFormMode FormMode;
        Guid _rowID, _headRowId;
        DataTable dt;
        Int32 nSisa, nRealSisa;

        public frmKasbonVJU()
        {
            InitializeComponent();
        }

        public frmKasbonVJU(Form _caller, Guid headRowId)
        {
            InitializeComponent();
            _TglNow = GlobalVar.GetServerDate;
            txtTanggal.DateValue = _TglNow;
            this.Caller = _caller;
            FormMode = enumFormMode.New;
            _headRowId = headRowId;
        }

        public frmKasbonVJU(Form _caller, Guid headRowId, Guid RowId)
        {
            InitializeComponent();
            _TglNow = GlobalVar.GetServerDate;
            txtTanggal.DateValue = _TglNow;
            this.Caller = _caller;
            FormMode = enumFormMode.Update;
            _headRowId = headRowId;
            _rowID = RowId;
        }

        private void frmKasbonVJU_Load(object sender, EventArgs e)
        {
            Class.FillComboBox fcbo = new Class.FillComboBox();
            try
            {
                //fcbo.fillComboJnsKasBon(cboJnsKasBon);
                fcbo.fillComboJnsTransaksiEQUAL(cboJnsKasBon, false);
                LoadForm();
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
        private Int32 nBs, nVju;
        private void LoadForm()
        {
            DataTable dtBs = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Kasbon_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headRowId));
                dtBs = db.Commands[0].ExecuteDataTable();
                txtTanggalBs.DateValue = (DateTime)Tools.isNull(dtBs.Rows[0]["Tanggal"], "");
                txtNomorBs.Text = Tools.isNull(dtBs.Rows[0]["No_bukti"], "").ToString();
                txtNamaPegawai.Text = Tools.isNull(dtBs.Rows[0]["NamaKaryawan"], "").ToString();
                txtKeperluan.Text = Tools.isNull(dtBs.Rows[0]["Uraian"], "").ToString();
                txtKasbon.Text = Tools.isNull(dtBs.Rows[0]["Nominal"], "").ToString();
                txtTotalRealisasi.Text = Tools.isNull(dtBs.Rows[0]["Vju"], "").ToString();
                nRealSisa = Convert.ToInt32(dtBs.Rows[0]["Sisa"]);
                nBs = Convert.ToInt32(dtBs.Rows[0]["Nominal"]);
                nVju = Convert.ToInt32(dtBs.Rows[0]["Vju"]);
                nSisa = nBs - nVju;
                txtSisaKasbon.Text = Tools.isNull(nSisa, "").ToString();
                if (nSisa > 0)
                {
                    label11.Text = "BKM atas kelebihan kasbon";
                }
                else
                {
                    label11.Text = "BKK atas kekurangan kasbon";
                }

                Vju_RefreshData();
                dataGridViewVju.FindRow("VjuRowID", _rowID.ToString());
                ClearTextBox();
                LoadEdit();
                if (FormMode == enumFormMode.Update )
                {
                    cmdCLOSE.Enabled = false;
                }
            }
        }

        private void LoadEdit()
        {
            if (FormMode == enumFormMode.Update)
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KasbonVJU_SEEK"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtTanggal.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["Tanggal"], "");
                txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                txtNominal.Text = Tools.isNull(dt.Rows[0]["Kredit"], "").ToString();
                txtNo_bukti.Text = Tools.isNull(dt.Rows[0]["No_bukti"], "").ToString();
            }
        }

        private void closeForm()
        {
            if (this.Caller is frmKasbonBrowse)
            {
                frmKasbonBrowse frmCaller = (frmKasbonBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("RowID", _headRowId.ToString(), 1);
                frmCaller.Vju_RefreshData();
                frmCaller.FindRow("VjuRowID", _rowID.ToString(), 2);
            }
        }

        private void Vju_RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KasBonVJU_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headRowId));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridViewVju.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ClearTextBox()
        {
            txtTanggal.DateValue = _TglNow;
            txtNo_bukti.Text = "";
            txtUraian.Text = txtKeperluan.Text;
            txtNominal.Text = "";
        }

        #endregion

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            bool valid = true;
            if (txtUraian.Text == ""   )
            {
                Error.ErrorMessage(txtUraian, "isi !!!");
                valid = false;
            }
            if (txtNominal.Text == "")
            {
                Error.ErrorMessage(txtNominal, "isi !!!");
                valid = false;
            }

            if (txtUraian.Text != "" && txtNominal.Text != "" && valid)
            {
                switch (FormMode)
                {
                    case enumFormMode.New:
                        {
                            string cNo_vju = Numerator.GetNomorDokumen("VOUCHER_JOURNAL", "",
                                                "/VJU/" + string.Format("{0:yyMM}",GlobalVar.GetServerDate)
                                                , 3, false, true);
                            dt = new DataTable();
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_KasbonVJU_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@KasbonRowId", SqlDbType.UniqueIdentifier, _headRowId));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@No_bukti", SqlDbType.Char, cNo_vju ));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsKasBonRowID", SqlDbType.UniqueIdentifier, cboJnsKasBon.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Float, float.Parse(txtNominal.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID ));
                                dt = db.Commands[0].ExecuteDataTable();

                            }
                            LoadForm();
                            dataGridViewVju.FindRow("No_vju", cNo_vju.PadRight(20));
                            ClearTextBox();
                            txtTanggal.Focus();
                            break;
                        }
                    case enumFormMode.Update:
                        {
                            dt = new DataTable();
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_KasbonVJU_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowId", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsKasBonRowID", SqlDbType.UniqueIdentifier, cboJnsKasBon.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Float, float.Parse(txtNominal.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID ));
                                dt = db.Commands[0].ExecuteDataTable();
                            }
                            closeForm();
                            this.Close();
                            break;
                        }
                }
            }
           
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            using (Database db = new Database())
            {
                if (nSisa > 0)
                {
                    string cNoBKM = Numerator.GetNomorDokumen("PENERIMAAN_UANG", "",
                                                "/BKM/" + string.Format("{0:yyMM}",GlobalVar.GetServerDate)
                                                , 3, false, true);
                    db.Commands.Add(db.CreateCommand("usp_KasbonPenyelesaian_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@No_bukti", SqlDbType.Char, cNoBKM));
                    db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Float, float.Parse(nSisa.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Float, float.Parse(0.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Sisa BS: " + txtNamaPegawai.Text));
                }
                else if (nSisa < 0)
                {
                    nSisa = Math.Abs(nSisa);
                    string cNoBKK = Numerator.GetNomorDokumen("PENGAJUAN_PENGELUARAN_UANG", "",
                                                "/BKK/" + string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                , 3, false, true);
                    db.Commands.Add(db.CreateCommand("usp_KasbonPenyelesaian_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@No_bukti", SqlDbType.Char, cNoBKK));
                    db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Float, float.Parse(0.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Float, float.Parse(nSisa.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Kekurangan BS: " + txtNamaPegawai.Text));
                }
                if (nSisa == 0)
                {
                }
                else
                {
                    db.Commands[0].Parameters.Add(new Parameter("@KasbonRowId", SqlDbType.UniqueIdentifier, _headRowId));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, _TglNow));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            closeForm();
            this.Close();
        }

        private void cmdEXIT_Click(object sender, EventArgs e)
        {
            closeForm();
            this.Close();
        }

    }
}
