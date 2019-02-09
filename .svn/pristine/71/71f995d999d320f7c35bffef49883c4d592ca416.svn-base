using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;

namespace ISA.Showroom.Master
{
    public partial class frmSurveyorUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID;
        String _cabangID = GlobalVar.CabangID;

        public frmSurveyorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmSurveyorUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmSurveyorUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ListIdentitas();

                if (formMode == enumFormMode.Update)
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Surveyor_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                        txtTempat.Text = Tools.isNull(dt.Rows[0]["TmptLahir"], "").ToString();
                        if (string.IsNullOrEmpty(dt.Rows[0]["TglLahir"].ToString()))
                        {
                            txtTglLahir.Text = "";
                        }
                        else
                        {
                            txtTglLahir.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TglLahir"], "");
                        }
                        string _idt = dt.Rows[0]["Identitas"].ToString();
                        switch (Tools.Left(_idt, 1))
                        {
                            case "K":
                                cboIdentitas.SelectedIndex = 1;
                                break;
                            case "S":
                                cboIdentitas.SelectedIndex = 2;
                                break;
                            case "P":
                                cboIdentitas.SelectedIndex = 3;
                                break;
                        }
                        txtNoIdentitas.Text = Tools.isNull(dt.Rows[0]["NoIdentitas"], "").ToString();
                        txtAlamatIdt.Text = Tools.isNull(dt.Rows[0]["AlamatIdt"], "").ToString();
                        txtRTIdt.Text = Tools.isNull(dt.Rows[0]["RTIdt"], "").ToString();
                        txtRWIdt.Text = Tools.isNull(dt.Rows[0]["RWIdt"], "").ToString();

                        DataTable dtProp = FillComboBox.DBGetProvinsi(Guid.Empty);
                        dtProp.DefaultView.Sort = "Nama ASC";
                        cboProvinsiIdt.DisplayMember = "Nama";
                        cboProvinsiIdt.ValueMember = "RowID";
                        cboProvinsiIdt.DataSource = dtProp.DefaultView;
                        cboProvinsiIdt.Text = Tools.isNull(dt.Rows[0]["ProvinsiIdt"], "").ToString();

                        cboKotaIdt.Text = Tools.isNull(dt.Rows[0]["KotaIdt"], "").ToString();
                        cboKecamatanIdt.Text = Tools.isNull(dt.Rows[0]["KecamatanIdt"], "").ToString();
                        cboKelurahanIdt.Text = Tools.isNull(dt.Rows[0]["KelurahanIdt"], "").ToString();

                        txtAlamatDom.Text = Tools.isNull(dt.Rows[0]["AlamatDom"], "").ToString();
                        txtRTDom.Text = Tools.isNull(dt.Rows[0]["RTDom"], "").ToString();
                        txtRWDom.Text = Tools.isNull(dt.Rows[0]["RWDom"], "").ToString();

                        cboProvinsiDom.DisplayMember = "Nama";
                        cboProvinsiDom.ValueMember = "RowID";
                        cboProvinsiDom.DataSource = dtProp.DefaultView;
                        cboProvinsiDom.Text = Tools.isNull(dt.Rows[0]["ProvinsiDom"], "").ToString();

                        cboKotaDom.Text = Tools.isNull(dt.Rows[0]["KotaDom"], "").ToString();
                        cboKecamatanDom.Text = Tools.isNull(dt.Rows[0]["KecamatanDom"], "").ToString();
                        cboKelurahanDom.Text = Tools.isNull(dt.Rows[0]["KelurahanDom"], "").ToString();

                        txtTelp.Text = Tools.isNull(dt.Rows[0]["NoTelp"], "").ToString();
                        txtHP.Text = Tools.isNull(dt.Rows[0]["NoHP"], "").ToString();

                        if (string.IsNullOrEmpty(dt.Rows[0]["TglMasuk"].ToString()))
                        {
                            txtTglMasuk.Text = "";
                        }
                        else
                        {
                            txtTglMasuk.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TglMasuk"], "");
                        }
                        if (string.IsNullOrEmpty(dt.Rows[0]["TglKeluar"].ToString()))
                        {
                            txtTglKeluar.Text = "";
                        }
                        else
                        {
                            txtTglKeluar.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TglKeluar"], "");
                        }
                    }
                }
                else
                {
                    this.ListProvinsiIdentitas();
                    this.ListProvinsiDomisili();

                    /*
                    DataTable dtn = new DataTable();
                    dtn.Clear();
                    cboKecamatanIdt.DataSource = dtn;
                    cboKecamatanDom.DataSource = dtn;
                    cboKelurahanIdt.DataSource = dtn;
                    cboKelurahanDom.DataSource = dtn;
                    */

                    txtNama.Text = "";
                    txtTempat.Text = "";
                    txtTglLahir.Text = "";
                    txtNoIdentitas.Text = "";
                    txtAlamatIdt.Text = "";
                    txtRTIdt.Text = "";
                    txtRWIdt.Text = "";
                    cboKelurahanIdt.Text = "";
                    cboKecamatanIdt.Text = "";
                    cboKotaIdt.Text = "";
                    cboProvinsiIdt.Text = "";
                    txtAlamatDom.Text = "";
                    txtRTDom.Text = "";
                    txtRWDom.Text = "";
                    cboKelurahanDom.Text = "";
                    cboKecamatanDom.Text = "";
                    cboKotaDom.Text = "";
                    cboProvinsiDom.Text = "";
                    txtTelp.Text = "";
                    txtHP.Text = "";
                    txtTglMasuk.Text = "";
                    txtTglKeluar.Text = "";

                    // ambil dari app setting
                    DataTable dummyPR = new DataTable();
                    using (Database dbsubPR = new Database())
                    {
                        dbsubPR.Commands.Add(dbsubPR.CreateCommand("usp_AppSetting_LIST"));
                        dbsubPR.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PROVPEMILIKBPKB"));
                        dummyPR = dbsubPR.Commands[0].ExecuteDataTable();
                        if (dummyPR.Rows.Count > 0)
                        {
                            cboProvinsiIdt.Text = dummyPR.Rows[0]["Value"].ToString();
                            cboProvinsiDom.Text = dummyPR.Rows[0]["Value"].ToString();
                        }
                    }
                    DataTable dummyKT = new DataTable();
                    using (Database dbsubKT = new Database())
                    {
                        dbsubKT.Commands.Add(dbsubKT.CreateCommand("usp_AppSetting_LIST"));
                        dbsubKT.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KOTAPEMILIKBPKB"));
                        dummyKT = dbsubKT.Commands[0].ExecuteDataTable();
                        if (dummyKT.Rows.Count > 0)
                        {
                            cboKotaIdt.Text = dummyKT.Rows[0]["Value"].ToString();
                            cboKotaDom.Text = dummyKT.Rows[0]["Value"].ToString();
                        }
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

        private void ListProvinsiIdentitas()
        {
            try
            {
                DataTable dt = FillComboBox.DBGetProvinsi(Guid.Empty);

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "Nama ASC";
                    cboProvinsiIdt.DisplayMember = "Nama";
                    cboProvinsiIdt.ValueMember = "RowID";
                    cboProvinsiIdt.DataSource = dt.DefaultView;
                }
                else
                {
                    dt.Clear();
                    cboProvinsiIdt.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ListProvinsiDomisili()
        {
            try
            {
                DataTable dt = FillComboBox.DBGetProvinsi(Guid.Empty);

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "Nama ASC";
                    cboProvinsiDom.DisplayMember = "Nama";
                    cboProvinsiDom.ValueMember = "RowID";
                    cboProvinsiDom.DataSource = dt.DefaultView;
                }
                else
                {
                    dt.Clear();
                    cboProvinsiDom.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ListIdentitas()
        {
            cboIdentitas.DisplayMember = "Text";
            cboIdentitas.ValueMember = "Value";
            var items = new[] {
                new { Text = "", Value = "" },
                new { Text = "KTP", Value = "KTP" },
                new { Text = "SIM", Value = "SIM" },
                new { Text = "PASPORT", Value = "PASPORT" }
            };
            cboIdentitas.DataSource = items;
        }

        private void frmSurveyorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmSurveyorBrowse)
            {
                Master.frmSurveyorBrowse frmCaller = (Master.frmSurveyorBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("Nama", txtNama.Text);
            }   
        }

        DataTable dt_;
        private bool cekNoIdentitas(string NoIdentitas, string strMode, Guid RowID)
        {
            bool cek = false;
            //Command cmd;

            if (strMode == "ADD")
            {   /*
                cmd = new Command(new Database(), CommandType.Text,
                                    "SELECT * FROM dbo.Surveyor WHERE NoIdentitas LIKE '%'+@NoIdentitas+'%' ");
                cmd.AddParameter("@NoIdentitas", SqlDbType.VarChar, NoIdentitas);
                dt_ = cmd.ExecuteDataTable();
                */
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CekDoubleIdentitasSurveyor"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoIdentitas", SqlDbType.VarChar, NoIdentitas));
                    dt_ = db.Commands[0].ExecuteDataTable();
                }
            }
            else if (strMode == "UPDATE")
            {   /*
                cmd = new Command(new Database(), CommandType.Text,
                                    "SELECT * FROM dbo.Surveyor WHERE NoIdentitas LIKE '%'+@NoIdentitas+'%' AND RowID <> @RowID ");
                cmd.AddParameter("@NoIdentitas", SqlDbType.VarChar, NoIdentitas);
                cmd.AddParameter("@RowID", SqlDbType.UniqueIdentifier, RowID);
                dt_ = cmd.ExecuteDataTable();
                */
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CekDoubleIdentitasSurveyor"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoIdentitas", SqlDbType.VarChar, NoIdentitas));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt_ = db.Commands[0].ExecuteDataTable();
                } 
            }

            if (dt_.Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNama.Text))
                {
                    MessageBox.Show("Nama belum diisi !");
                    txtNama.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTempat.Text))
                {
                    MessageBox.Show("Tempat Lahir belum diisi !");
                    txtTempat.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTglLahir.Text))
                {
                    MessageBox.Show("Tanggal Lahir belum diisi !");
                    txtTglLahir.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboIdentitas.Text))
                {
                    MessageBox.Show("Identitas belum dipilih !");
                    cboIdentitas.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNoIdentitas.Text))
                {
                    MessageBox.Show("Nomor Identitas belum diisi !");
                    txtNoIdentitas.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtAlamatIdt.Text))
                {
                    MessageBox.Show("Alamat Identitas belum diisi !");
                    txtAlamatIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRTIdt.Text))
                {
                    MessageBox.Show("RT Identitas belum diisi !");
                    txtRTIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRWIdt.Text))
                {
                    MessageBox.Show("RW Identitas belum diisi !");
                    txtRWIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKelurahanIdt.Text))
                {
                    MessageBox.Show("Kelurahan Identitas belum dipilih !");
                    cboKelurahanIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKecamatanIdt.Text))
                {
                    MessageBox.Show("Kecamatan Identitas belum dipilih !");
                    cboKecamatanIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKotaIdt.Text))
                {
                    MessageBox.Show("Kota Identitas belum dipilih !");
                    cboKotaIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboProvinsiIdt.Text))
                {
                    MessageBox.Show("Provinsi Identitas belum dipilih !");
                    cboProvinsiIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtAlamatDom.Text))
                {
                    MessageBox.Show("Alamat Domisili belum diisi ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    txtAlamatIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRTDom.Text))
                {
                    MessageBox.Show("RT Domisili belum diisi ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    txtRTIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtRWDom.Text))
                {
                    MessageBox.Show("RW Domisili belum diisi ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    txtRWIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKelurahanDom.Text))
                {
                    MessageBox.Show("Kelurahan Domisili belum dipilih ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    cboKelurahanIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKecamatanDom.Text))
                {
                    MessageBox.Show("Kecamatan Domisili belum dipilih ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    cboKecamatanIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKotaDom.Text))
                {
                    MessageBox.Show("Kota Domisili belum dipilih ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    cboKotaIdt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboProvinsiDom.Text))
                {
                    MessageBox.Show("Provinsi Domisili belum dipilih ! Bila isinya sama dengan Identitas maka centang Sama dengan Identitas.");
                    cboProvinsiIdt.Focus();
                    return;
                }               

                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        if (this.cekNoIdentitas(txtNoIdentitas.Text, "ADD", _rowID))
                        {
                            MessageBox.Show("Nomor Identitas sudah terdapat di database !");
                            txtNoIdentitas.Focus();
                            return;
                        }
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Surveyor_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TmptLahir", SqlDbType.VarChar, txtTempat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.Date, txtTglLahir.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Identitas", SqlDbType.VarChar, cboIdentitas.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoIdentitas", SqlDbType.VarChar, txtNoIdentitas.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatIdt", SqlDbType.VarChar, txtAlamatIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RTIdt", SqlDbType.VarChar, txtRTIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RWIdt", SqlDbType.VarChar, txtRWIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KelurahanIdt", SqlDbType.VarChar, cboKelurahanIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KecamatanIdt", SqlDbType.VarChar, cboKecamatanIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KotaIdt", SqlDbType.VarChar, cboKotaIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ProvinsiIdt", SqlDbType.VarChar, cboProvinsiIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatDom", SqlDbType.VarChar, txtAlamatDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RTDom", SqlDbType.VarChar, txtRTDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RWDom", SqlDbType.VarChar, txtRWDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KelurahanDom", SqlDbType.VarChar, cboKelurahanDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KecamatanDom", SqlDbType.VarChar, cboKecamatanDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KotaDom", SqlDbType.VarChar, cboKotaDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ProvinsiDom", SqlDbType.VarChar, cboProvinsiDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoHP", SqlDbType.VarChar, txtHP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.Date, txtTglMasuk.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.Date, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        MessageBox.Show("Data berhasil ditambahkan");
                        break;
                    case enumFormMode.Update:
                        if (this.cekNoIdentitas(txtNoIdentitas.Text, "UPDATE", _rowID))
                        {
                            MessageBox.Show("Nomor Identitas sudah terdapat di database !");
                            txtNoIdentitas.Focus();
                            return;
                        }
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Surveyor_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TmptLahir", SqlDbType.VarChar, txtTempat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.Date, txtTglLahir.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Identitas", SqlDbType.VarChar, cboIdentitas.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoIdentitas", SqlDbType.VarChar, txtNoIdentitas.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatIdt", SqlDbType.VarChar, txtAlamatIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RTIdt", SqlDbType.VarChar, txtRTIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RWIdt", SqlDbType.VarChar, txtRWIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KelurahanIdt", SqlDbType.VarChar, cboKelurahanIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KecamatanIdt", SqlDbType.VarChar, cboKecamatanIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KotaIdt", SqlDbType.VarChar, cboKotaIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ProvinsiIdt", SqlDbType.VarChar, cboProvinsiIdt.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatDom", SqlDbType.VarChar, txtAlamatDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RTDom", SqlDbType.VarChar, txtRTDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RWDom", SqlDbType.VarChar, txtRWDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KelurahanDom", SqlDbType.VarChar, cboKelurahanDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KecamatanDom", SqlDbType.VarChar, cboKecamatanDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KotaDom", SqlDbType.VarChar, cboKotaDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ProvinsiDom", SqlDbType.VarChar, cboProvinsiDom.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTelp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoHP", SqlDbType.VarChar, txtHP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMasuk", SqlDbType.Date, txtTglMasuk.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.Date, txtTglKeluar.DateValue));
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

        private void ckDomisili_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDomisili.Checked == true)
            {
                txtAlamatDom.Text = txtAlamatIdt.Text;
                txtRTDom.Text = txtRTIdt.Text;
                txtRWDom.Text = txtRWIdt.Text;
                cboProvinsiDom.Text = cboProvinsiIdt.Text;
                cboKotaDom.Text = cboKotaIdt.Text;
                cboKecamatanDom.Text = cboKecamatanIdt.Text;
                cboKelurahanDom.Text = cboKelurahanIdt.Text;
            }
            else
            {
                txtAlamatDom.Text = "";
                txtRTDom.Text = "";
                txtRWDom.Text = "";
                cboKelurahanDom.Text = "";
                cboKecamatanDom.Text = "";
                cboKotaDom.Text = "";
                cboProvinsiDom.Text = "";
            }
        }

        private void cboProvinsiIdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKelurahanIdt.DataSource = null;
            try
            {
                Guid rowID = (Guid)cboProvinsiIdt.SelectedValue;
                DataTable dt = FillComboBox.DBGetKota(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKotaIdt.DisplayMember = "Nama";
                cboKotaIdt.ValueMember = "RowID";
                cboKotaIdt.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cboKotaIdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKelurahanIdt.DataSource = null;
            try
            {
                Guid rowID = (Guid)cboKotaIdt.SelectedValue;
                DataTable dt = FillComboBox.DBGetKecamatan(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKecamatanIdt.DisplayMember = "Nama";
                cboKecamatanIdt.ValueMember = "RowID";
                cboKecamatanIdt.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cboKecamatanIdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)cboKecamatanIdt.SelectedValue;
                DataTable dt = FillComboBox.DBGetKelurahan(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKelurahanIdt.DisplayMember = "Nama";
                cboKelurahanIdt.ValueMember = "RowID";
                cboKelurahanIdt.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cboProvinsiDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKelurahanDom.DataSource = null;
            try
            {
                Guid rowID = (Guid)cboProvinsiDom.SelectedValue;
                DataTable dt = FillComboBox.DBGetKota(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKotaDom.DisplayMember = "Nama";
                cboKotaDom.ValueMember = "RowID";
                cboKotaDom.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cboKotaDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboKelurahanDom.DataSource = null;
            try
            {
                Guid rowID = (Guid)cboKotaDom.SelectedValue;
                DataTable dt = FillComboBox.DBGetKecamatan(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKecamatanDom.DisplayMember = "Nama";
                cboKecamatanDom.ValueMember = "RowID";
                cboKecamatanDom.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cboKecamatanDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Guid rowID = (Guid)cboKecamatanDom.SelectedValue;
                DataTable dt = FillComboBox.DBGetKelurahan(Guid.Empty, rowID);
                dt.DefaultView.Sort = "Nama ASC";
                cboKelurahanDom.DisplayMember = "Nama";
                cboKelurahanDom.ValueMember = "RowID";
                cboKelurahanDom.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtNoIdentitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar.Equals('.')))
            {
                e.Handled = true;
            }
        }

        private void txtTelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar.Equals(' ')) && !(e.KeyChar.Equals('(')) && !(e.KeyChar.Equals(')')) && !(e.KeyChar.Equals('-')))
            {
                e.Handled = true;
            }
        }

        private void txtHP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar.Equals(' ')) && !(e.KeyChar.Equals('(')) && !(e.KeyChar.Equals(')')) && !(e.KeyChar.Equals('-')))
            {
                e.Handled = true;
            }
        }

        private void txtRTIdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRWIdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRTDom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRWDom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNama_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTempat_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTglLahir_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboIdentitas_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNoIdentitas_KeyDown(object sender, KeyEventArgs e)
        {
            // txtAlamatIdt.Focus();
        }

        private void txtRTIdt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtRWIdt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboProvinsiIdt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKotaIdt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKecamatanIdt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKelurahanIdt_KeyDown(object sender, KeyEventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            tabPage2.Focus();
            txtAlamatDom.Focus();
        }

        private void txtRTDom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtRWDom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboProvinsiDom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKotaDom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKecamatanDom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboKelurahanDom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtTelp.Focus();
            }
        }

        private void txtTelp_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtHP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTglMasuk_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTglKeluar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
