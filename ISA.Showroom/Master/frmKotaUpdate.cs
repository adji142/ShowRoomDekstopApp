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
    public partial class frmKotaUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enum enumFormState { Prov, Kota, Kec, Kel };
        enumFormMode formMode;
        enumFormState formState;
        Guid _provRowID, _kotaRowID, _kecRowID, _rowID;
        string _namaProv, _namaKota, _namaKec, _namaKel;

        public frmKotaUpdate(Form caller, string State, string Nama, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.New; 

            switch (State)
            {
                case "Provinsi" :
                    formState = enumFormState.Prov;
                    break;
                case "Kota":
                    formState = enumFormState.Kota;
                    _provRowID = rowID;
                    _namaProv = Nama;
                    break;
                case "Kecamatan":
                    formState = enumFormState.Kec;
                    _kotaRowID = rowID;
                    _namaKota = Nama;
                    break;
                case "Kelurahan":
                    formState = enumFormState.Kel;
                    _kecRowID = rowID;
                    _namaKec = Nama;
                    break;        
            }            
        }

        public frmKotaUpdate(Form caller,  string State, Guid RowID)
        {
            InitializeComponent();
            this.Caller = caller;
            formMode = enumFormMode.Update;
            _rowID = RowID;

            switch (State)
            {
                case "Provinsi":
                    formState = enumFormState.Prov;
                    break;
                case "Kota":
                    formState = enumFormState.Kota;
                    break;
                case "Kecamatan":
                    formState = enumFormState.Kec;
                    break;
                case "Kelurahan":
                    formState = enumFormState.Kel;
                    break;
            }      
        }

        private void displayPanel(string State)
        {
            pnlProvinsi.Visible = (State == "Provinsi") ? true : false;
            pnlKota.Visible = (State == "Kota") ? true : false;
            pnlKecamatan.Visible = (State == "Kecamatan") ? true : false;
            pnlKelurahan.Visible = (State == "Kelurahan") ? true : false;
        }

        private void LoadProvinsi()
        {
            displayPanel("Provinsi");            

            if (formMode == enumFormMode.New)
            {
                txtProvinsi.Text = "";
                this.Text = "Master Kota";
                this.Title = "Master Kota";
            }
            else
            {   
                DataTable dt = FillComboBox.DBGetProvinsi(_rowID);
                txtProvinsi.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                this.Text = "Master Kota Update";
                this.Title = "Master Kota Update";
            }
        }

        private void LoadKota()
        {
            displayPanel("Kota");

            if (formMode == enumFormMode.New)
            {
                txtProvKota.Text = Tools.isNull(_namaProv, "").ToString();
                txtKota.Text = "";
                this.Text = "Master Kota";
                this.Title = "Master Kota";
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST_ALL"));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaRowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        txtProvKota.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();
                        _provRowID = (Guid)dt.Rows[0]["RowID"];
                        txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();                        
                        this.Text = "Master Kota Update";
                        this.Title = "Master Kota Update";
                    }                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void LoadKecamatan()
        {
            displayPanel("Kecamatan");

            if (formMode == enumFormMode.New)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST_ALL"));
                        db.Commands[0].Parameters.Add(new Parameter("@KotaRowID", SqlDbType.UniqueIdentifier, _kotaRowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        txtProvKec.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();
                        txtKotaKec.Text = Tools.isNull(_namaKota, "").ToString();
                        txtKecamatan.Text = "";
                        this.Text = "Master Kota";
                        this.Title = "Master Kota";
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST_ALL"));
                        db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        txtProvKec.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();
                        txtKotaKec.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        _kotaRowID = (Guid)dt.Rows[0]["KotaRowID"];
                        txtKecamatan.Text = Tools.isNull(dt.Rows[0]["Kecamatan"], "").ToString();
                        txtWilID.Text = Tools.isNull(dt.Rows[0]["WILID"], "").ToString();  
                        this.Text = "Master Kota Update";
                        this.Title = "Master Kota Update";
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void LoadKelurahan()
        {
            displayPanel("Kelurahan");

            if (formMode == enumFormMode.New)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST_ALL"));
                        db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _kecRowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        txtProvKel.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();
                        txtKotaKel.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        txtKecKel.Text = Tools.isNull(_namaKec, "").ToString();
                        txtKelurahan.Text = "";
                        this.Text = "Master Kota";
                        this.Title = "Master Kota";
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Provinsi_LIST_ALL"));
                        db.Commands[0].Parameters.Add(new Parameter("@KelRowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        txtProvKel.Text = Tools.isNull(dt.Rows[0]["Provinsi"], "").ToString();
                        txtKotaKel.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        txtKecKel.Text = Tools.isNull(dt.Rows[0]["Kecamatan"], "").ToString();
                        _kecRowID = (Guid)dt.Rows[0]["KecRowID"];
                        txtKelurahan.Text = Tools.isNull(dt.Rows[0]["Kelurahan"], "").ToString();                        
                        this.Text = "Master Kota Update";
                        this.Title = "Master Kota Update";
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void frmKotaUpdate_Load(object sender, EventArgs e)
        {
            switch (formState)
            {
                case enumFormState.Prov:
                    LoadProvinsi();
                    break;
                case enumFormState.Kota:
                    LoadKota();
                    break;
                case enumFormState.Kec:
                    LoadKecamatan();
                    break;
                case enumFormState.Kel:
                    LoadKelurahan();
                    break;
            }
        }             

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New :
                    tambah_data();
                    break;
                case enumFormMode.Update:
                    ubah_data();
                    break;
            }
        }

        private void tambah_data()
        {
            switch (formState)
            {
                case enumFormState.Prov :
                    add_provinsi();
                    break;
                case enumFormState.Kota :
                    add_kota();
                    break;
                case enumFormState.Kec :
                    add_kecamatan();
                    break;
                case enumFormState.Kel :
                    add_kelurahan();
                    break;
            }
        }

        private void ubah_data()
        {
            switch (formState)
            {
                case enumFormState.Prov :
                    update_provinsi();
                    break;
                case enumFormState.Kota :
                    update_kota();
                    break;
                case enumFormState.Kec :
                    update_kecamatan();
                    break;
                case enumFormState.Kel :
                    update_kelurahan();
                    break;
            }
        }

        private void add_provinsi()
        {
            _rowID = Guid.NewGuid();
            try
            {
                if (string.IsNullOrEmpty(txtProvinsi.Text))
                {
                    MessageBox.Show("Provinsi belum diisi !");
                    txtProvinsi.Focus();
                    return;
                }
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Provinsi_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtProvinsi.Text));
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

        private void add_kota()
        {
            _rowID = Guid.NewGuid();
            try
            {
                if (string.IsNullOrEmpty(txtKota.Text))
                {
                    MessageBox.Show("Kota belum diisi !");
                    txtKota.Focus();
                    return;
                }
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kota_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@ProvRowID", SqlDbType.UniqueIdentifier, _provRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtKota.Text));
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

        private void add_kecamatan()
        {
            _rowID = Guid.NewGuid();
            try
            {
                if (string.IsNullOrEmpty(txtKecamatan.Text))
                {
                    MessageBox.Show("Kecamatan belum diisi !");
                    txtKecamatan.Focus();
                    return;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kecamatan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KotaRowID", SqlDbType.UniqueIdentifier, _kotaRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtKecamatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@WILID", SqlDbType.VarChar, txtWilID.Text));
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

        private void add_kelurahan()
        {
            _rowID = Guid.NewGuid();
            try
            {
                if (string.IsNullOrEmpty(txtKelurahan.Text))
                {
                    MessageBox.Show("Kelurahan belum diisi !");
                    txtKelurahan.Focus();
                    return;
                }
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kelurahan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _kecRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtKelurahan.Text));
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

        private void update_provinsi()
        {
            try
            {
                if (string.IsNullOrEmpty(txtProvinsi.Text))
                {
                    MessageBox.Show("Provinsi belum diisi !");
                    txtProvinsi.Focus();
                    return;
                }
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Provinsi_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtProvinsi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update data gagal\n" + ex.Message);
            }
        }

        private void update_kota()
        {
            try
            {
                if (string.IsNullOrEmpty(txtKota.Text))
                {
                    MessageBox.Show("Kota belum diisi !");
                    txtKota.Focus();
                    return;
                }
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kota_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@ProvRowID", SqlDbType.UniqueIdentifier, _provRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update data gagal\n" + ex.Message);
            }
        }

        private void update_kecamatan()
        {
            try
            {
                if (string.IsNullOrEmpty(txtKecamatan.Text))
                {
                    MessageBox.Show("Kecamatan belum diisi !");
                    txtKecamatan.Focus();
                    return;
                }
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kecamatan_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KotaRowID", SqlDbType.UniqueIdentifier, _kotaRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtKecamatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@WILID", SqlDbType.VarChar, txtWilID.Text));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update data gagal\n" + ex.Message);
            }
        }

        private void update_kelurahan()
        {
            try
            {
                if (string.IsNullOrEmpty(txtKelurahan.Text))
                {
                    MessageBox.Show("Kelurahan belum diisi !");
                    txtKelurahan.Focus();
                    return;
                }
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kelurahan_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, _kecRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtKelurahan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update data gagal\n" + ex.Message);
            }
        }

        private void frmKotaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmKotaBrowse)
            {
                Master.frmKotaBrowse frmCaller = (Master.frmKotaBrowse)this.Caller;

                switch (formState)
                {
                    case enumFormState.Prov :
                        frmCaller.RefreshRowData("Prov", _rowID);
                        break;
                    case enumFormState.Kota :
                        frmCaller.RefreshRowData("Kota", _rowID);
                        break;
                    case enumFormState.Kec :
                        frmCaller.RefreshRowData("Kec", _rowID);
                        break;
                    case enumFormState.Kel :
                        frmCaller.RefreshRowData("Kel", _rowID);
                        break;
                }
            }
        }
    }
}
