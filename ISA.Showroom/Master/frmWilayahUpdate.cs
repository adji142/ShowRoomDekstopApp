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
    public partial class frmWilayahUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enum enumFormState { Area, Wilayah, Kolektor };
        enumFormMode formMode;
        enumFormState formState;
        Guid _areaRowID, _rowID, _kolRowID;
        string _area;
        string _cabangID = GlobalVar.CabangID;

        public frmWilayahUpdate(Form caller, string State, string Nama, Guid rowID, string Mode)
        {
            InitializeComponent();
            this.Caller = caller;
            if (Mode.Equals("New")) formMode = enumFormMode.New;
            else formMode = enumFormMode.Update;
            if (Mode.Equals("New")) _rowID = Guid.NewGuid();
            else _rowID = rowID;

            switch (State)
            {
                case "Area":
                    formState = enumFormState.Area;
                    break;
                case "Wilayah":
                    formState = enumFormState.Wilayah;
                    if (Mode.Equals("New")) _areaRowID = rowID;
                    _area = Nama;
                    break;
                case "Kolektor":
                    formState = enumFormState.Kolektor;
                    if (Mode.Equals("New")) _areaRowID = rowID;
                    _area = Nama;
                    break;
            }   
        }

        private void displayPanel(string State)
        {
            pnlArea.Visible = (State == "Area") ? true : false;
            pnlWilayah.Visible = (State == "Wilayah") ? true : false;
            pnlKolektor.Visible = (State == "Kolektor") ? true : false;;
        }

        private void LoadArea()
        {
            displayPanel("Area");

            if (formMode == enumFormMode.New)
            {
                txtArea.Text = "";
                this.Text = "Wilayah";
                this.Title = "Wilayah";
            }
            else
            {
                DataTable dt = FillComboBox.DBGetArea(_rowID);
                txtArea.Text = Tools.isNull(dt.Rows[0]["Area"], "").ToString();
                this.Text = "Wilayah Update";
                this.Title = "Wilayah Update";
            }
        }

        private void LoadWilayah()
        {
            displayPanel("Wilayah");
            DataTable dtProp, dt;

            if (formMode == enumFormMode.New)
            {
                txtWilArea.Text = _area;                
                dtProp = FillComboBox.DBGetProvinsi(Guid.Empty);
                dtProp.DefaultView.Sort = "Nama ASC";
                cboProvinsi.DisplayMember = "Nama";
                cboProvinsi.ValueMember = "RowID";
                cboProvinsi.DataSource = dtProp.DefaultView;
                this.Text = "Master Kota";
                this.Title = "Master Kota";

                // ambil dari app setting
                DataTable dummyPR = new DataTable();
                using (Database dbsubPR = new Database())
                {
                    dbsubPR.Commands.Add(dbsubPR.CreateCommand("usp_AppSetting_LIST"));
                    dbsubPR.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "PROVPEMILIKBPKB"));
                    dummyPR = dbsubPR.Commands[0].ExecuteDataTable();
                    if (dummyPR.Rows.Count > 0)
                        cboProvinsi.Text = dummyPR.Rows[0]["Value"].ToString();
                }
                DataTable dummyKT = new DataTable();
                using (Database dbsubKT = new Database())
                {
                    dbsubKT.Commands.Add(dbsubKT.CreateCommand("usp_AppSetting_LIST"));
                    dbsubKT.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "KOTAPEMILIKBPKB"));
                    dummyKT = dbsubKT.Commands[0].ExecuteDataTable();
                    if (dummyKT.Rows.Count > 0)
                        cboKota.Text = dummyKT.Rows[0]["Value"].ToString();
                }
            }
            else
            {
                dt = FillComboBox.DBGetWilayah(_rowID, Guid.Empty, Guid.Empty);
                dtProp = FillComboBox.DBGetProvinsi(Guid.Empty);
                dtProp.DefaultView.Sort = "Nama ASC";
                cboProvinsi.DisplayMember = "Nama";
                cboProvinsi.ValueMember = "RowID";
                cboProvinsi.DataSource = dtProp.DefaultView;
                txtWilArea.Text = _area;
                _areaRowID = (Guid)Tools.isNull(dt.Rows[0]["AreaRowID"], "");
                cboProvinsi.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();
                cboKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                cboKecamatan.Text = Tools.isNull(dt.Rows[0]["Kecamatan"], "").ToString();
                this.Text = "Master Kota Update";
                this.Title = "Master Kota Update";
            }
        }

        private void LoadKolektor()
        {
            displayPanel("Kolektor");
            DataTable dtKol, dt;

            if (formMode == enumFormMode.New)
            {
                txtKolArea.Text = _area;
                lkKolektor.txtNamaKolektor.Text = "";
                txtTMT.Text = "";
                this.Text = "Master Kolektor";
                this.Title = "Master Kolektor";
            }
            else
            {
                dt = FillComboBox.DBGetAreaKolektor(_rowID, Guid.Empty, Guid.Empty);
                txtKolArea.Text = _area;
                _areaRowID = (Guid)Tools.isNull(dt.Rows[0]["AreaRowID"], "");
                _kolRowID = (Guid)Tools.isNull(dt.Rows[0]["KolektorRowID"], "");
                dtKol = FillComboBox.DBGetKolektor(_kolRowID);                
                lkKolektor.txtNamaKolektor.Text = Tools.isNull(dtKol.Rows[0]["Nama"], "").ToString();                
                txtTMT.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TMT"], "");
                this.Text = "Master Kolektor Update";
                this.Title = "Master Kolektor Update";
            }
        }

        private void cboProvinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid rowID = (Guid)cboProvinsi.SelectedValue;
            DataTable dtK = FillComboBox.DBGetKota(Guid.Empty, rowID);
            dtK.DefaultView.Sort = "Nama ASC";
            cboKota.DisplayMember = "Nama";
            cboKota.ValueMember = "RowID";
            cboKota.DataSource = dtK.DefaultView;
        }

        private void cboKota_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid rowID = (Guid)cboKota.SelectedValue;
            DataTable dtK = FillComboBox.DBGetKecamatan(Guid.Empty, rowID);
            dtK.DefaultView.Sort = "Nama ASC";
            cboKecamatan.DisplayMember = "Nama";
            cboKecamatan.ValueMember = "RowID";
            cboKecamatan.DataSource = dtK.DefaultView;
        }

        private void frmWilayahUpdate_Load(object sender, EventArgs e)
        {
            switch (formState)
            {
                case enumFormState.Area :
                    this.LoadArea();
                    break;
                case enumFormState.Wilayah :
                    this.LoadWilayah();
                    break;
                case enumFormState.Kolektor :
                    this.LoadKolektor();
                    break;
            }
        }

        private void tambah_data()
        {
            switch (formState)
            {
                case enumFormState.Area :
                    this.tambah_area();
                    break;
                case enumFormState.Wilayah :
                    this.tambah_wilayah();
                    break;
                case enumFormState.Kolektor :
                    this.tambah_kolektor();
                    break;
            }
        }

        private void ubah_data()
        {
            switch (formState)
            {
                case enumFormState.Area :
                    this.ubah_area();
                    break;
                case enumFormState.Wilayah :
                    this.ubah_wilayah();
                    break;
                case enumFormState.Kolektor :
                    this.ubah_kolektor();
                    break;
            }
        }

        private void tambah_area()
        {
            try
            {
                if (string.IsNullOrEmpty(txtArea.Text))
                {
                    MessageBox.Show("Area belum diisi !");
                    txtArea.Focus();
                    return;
                }
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Area", SqlDbType.VarChar, txtArea.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal ditambahkan\n" + ex.Message);
            }
        }

        private void ubah_area()
        {
            try
            {
                if (string.IsNullOrEmpty(txtArea.Text))
                {
                    MessageBox.Show("Area belum diisi !");
                    txtArea.Focus();
                    return;
                }
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Area", SqlDbType.VarChar, txtArea.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate\n" + ex.Message);
            }
        }

        private void tambah_wilayah()
        {
            try
            {
                if (string.IsNullOrEmpty(cboProvinsi.Text))
                {
                    MessageBox.Show("Provinsi belum dipilih !");
                    cboProvinsi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKota.Text))
                {
                    MessageBox.Show("Kota belum dipilih !");
                    cboKota.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKecamatan.Text))
                {
                    MessageBox.Show("Kecamatan belum dipilih !");
                    cboKecamatan.Focus();
                    return;
                }
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Wilayah_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, cboKecamatan.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal ditambahkan\n" + ex.Message);
            }
        }

        private void ubah_wilayah()
        {
            try
            {
                if (string.IsNullOrEmpty(cboProvinsi.Text))
                {
                    MessageBox.Show("Provinsi belum dipilih !");
                    cboProvinsi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKota.Text))
                {
                    MessageBox.Show("Kota belum dipilih !");
                    cboKota.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKecamatan.Text))
                {
                    MessageBox.Show("Kecamatan belum dipilih !");
                    cboKecamatan.Focus();
                    return;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Wilayah_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, cboKecamatan.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate\n" + ex.Message);
            }
        }

        private void tambah_kolektor()
        {
            try
            {
                if (string.IsNullOrEmpty(lkKolektor.txtNamaKolektor.Text))
                {
                    MessageBox.Show("Kolektor belum dipilih !");
                    lkKolektor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTMT.Text))
                {
                    MessageBox.Show("TMT belum diisi !");
                    txtTMT.Focus();
                    return;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_Kolektor_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lkKolektor._Kolektor.RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.Date, txtTMT.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal ditambahkan\n" + ex.Message);
            }
        }

        private void ubah_kolektor()
        {
            try
            {
                if (string.IsNullOrEmpty(lkKolektor.txtNamaKolektor.Text))
                {
                    MessageBox.Show("Kolektor belum dipilih !");
                    lkKolektor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTMT.Text))
                {
                    MessageBox.Show("TMT belum diisi !");
                    txtTMT.Focus();
                    return;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Area_Kolektor_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@AreaRowID", SqlDbType.UniqueIdentifier, _areaRowID));
                    if (lkKolektor._Kolektor.RowID == Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, _kolRowID));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lkKolektor._Kolektor.RowID));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.Date, txtTMT.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate\n" + ex.Message);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New :
                    this.tambah_data();
                    break;
                case enumFormMode.Update :
                    this.ubah_data();
                    break;
            }
        }

        private void frmWilayahUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmWilayah)
            {
                Master.frmWilayah frmCaller = (Master.frmWilayah)this.Caller;

                switch (formState)
                {
                    case enumFormState.Area :
                        frmCaller.RefreshRowData("Area", Guid.Empty, _rowID);
                        break;
                    case enumFormState.Wilayah :
                        frmCaller.RefreshRowData("Wilayah", _areaRowID, _rowID);
                        break;
                    case enumFormState.Kolektor :
                        frmCaller.RefreshRowData("Kolektor", _areaRowID, _rowID);
                        break;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cmdSave.Focus();
            }
        }

        private void txtKolArea_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lkKolektor.txtNamaKolektor.Focus();
            }
        }

        private void lkKolektor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtTMT.Focus();
            }
        }

        private void txtTMT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cmdSave.Focus();
            }
        }

        private void txtWilArea_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cboProvinsi.Focus();
            }
        }

        private void cboProvinsi_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cboKota.Focus();
            }
        }

        private void cboKota_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cboKecamatan.Focus();
            }
        }

        private void cboKecamatan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cmdSave.Focus();
            }
        }
    }
}
