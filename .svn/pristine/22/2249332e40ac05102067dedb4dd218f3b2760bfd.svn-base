using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Controls;
using ISA.DAL;
using ISA.Finance;
namespace ISA.Showroom.Finance.Master.Karyawan
{
    public partial class frmKaryawanUpdate :BaseForm
    {

        #region variables

        enum enumFormMode { New, update };
        enumFormMode FormMode;
        Guid _rowId;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        #endregion

        #region Methodes

        private void FillComboAgama()
        {
            cboAgama.Items.Add("");
            cboAgama.Items.Add("Islam");
            cboAgama.Items.Add("Kristen");
            cboAgama.Items.Add("Protestan");
            cboAgama.Items.Add("Konghucu");
            cboAgama.Items.Add("Hindu");
            cboAgama.Items.Add("Budha");
        }

        private void FillComboStatusNikah()
        {
            cboStatusNikah.Items.Add("");
            cboStatusNikah.Items.Add("Belum Menikah");
            cboStatusNikah.Items.Add("Sudah Menikah");
        }

        private void FillComboStatusKaryawan()
        {
            cboStatusKaryawan.Items.Add("");
            cboStatusKaryawan.Items.Add("tetap");
            cboStatusKaryawan.Items.Add("Tidak tetap");
        }

        private void FillComboBagian()
        {
            fcbo.fillComboBagianDanSub(cboBagian);
            cboBagian.SelectedIndex = 0;
        }

        private void FillComboPendidikanTerakhir()
        {
            cboPendidikanTerakhir.Items.Add("");
            cboPendidikanTerakhir.Items.Add("S2");
            cboPendidikanTerakhir.Items.Add("S1");
            cboPendidikanTerakhir.Items.Add("D3");
            cboPendidikanTerakhir.Items.Add("D2");
            cboPendidikanTerakhir.Items.Add("D1");
            cboPendidikanTerakhir.Items.Add("SMA");
            cboPendidikanTerakhir.Items.Add("SMP");
          
        }


        private String JenisKelamin()
        {
            String jk = String.Empty;
            if (rdoLaki.Checked == true)
            {
                return jk = "Laki-Laki";
            }
            else
            {
                return jk = "Perempuan";
            }
        }

        private String CreateIDKaryawan(DateTime TglMasuk)
        {
            String KaryawanID = String.Empty;
            String strTglMasuk = TglMasuk.ToString();
            String[] strSplit=strTglMasuk.Split(new Char[]{'/'});
            String strTahunMasuk = strSplit[0].Substring(4, 4);
            
            return KaryawanID;
        }


        private bool validasiInputan()
        {
            if (txtKaryawanID.Text.Equals(""))
            {
                txtKaryawanID.Focus();
                return false;
            }
            if (txtNamakaryawan.Text.Equals(""))
            {
                txtNamakaryawan.Focus();
                return false;
            }
           
            if (txtInitial.Text.Equals(""))
            {
                txtInitial.Focus();
                return false;
            }
            if (rdoLaki.Checked == false && rdoPerempuan.Checked == false)
            {
                MessageBox.Show("Jenis Kelamin belum dipilih.");
                grpJK.Focus();
                return false;
            }
            //if (cboAgama.Text.ToString().Equals(""))
            //{
            //    MessageBox.Show("Agama belum dipilih.");
            //    cboAgama.Focus();
            //    return false;
            //}
            //if (cboStatusNikah.Text.ToString().Equals(""))
            //{
            //    MessageBox.Show("Status Nikah belum dipilih.");
            //    cboStatusNikah.Focus();
            //    return false;
            //}
            //if (cboStatusKaryawan.Text.ToString().Equals(""))
            //{
            //    MessageBox.Show("Status karyawan belum dipilih.");
            //    cboStatusKaryawan.Focus();
            //    return false;
            //}
            //if (txtTempatLahir.Text.Equals(""))
            //{
            //    MessageBox.Show("Tempat lahir belum diisi.");
            //    txtTempatLahir.Focus();
            //    return false;
            //}
            //if (dateLahir.Text.ToString().Equals(""))
            //{
            //    MessageBox.Show("Tanggal lahir belum diisi.");
            //    dateLahir.Focus();
            //    return false;
            //}
            //if (txtAlamat.Text.Equals(""))
            //{
            //    MessageBox.Show("Alamat karyawan belum diisi.");
            //    txtAlamat.Focus();
            //    return false;
            //}
            if (cboBagian.Text.ToString().Equals(""))
            {
                MessageBox.Show("Bagian belum diisi.");
                cboBagian.Focus();
                return false;

            }
            //if (cboPendidikanTerakhir.Text.ToString().Equals(""))
            //{
            //    MessageBox.Show("Pendidikan terakhir belum diisi.");
            //    cboPendidikanTerakhir.Focus();
            //    return false;
            //}
            //if (txtReferensi.Text.Equals(""))
            //{
            //    MessageBox.Show("Referensi belum diisi.");
            //    txtReferensi.Focus();
            //    return false;
            //}
            //if (txtInfoSK.Text.Equals(""))
            //{
            //    MessageBox.Show("InformSK belum diisi.");
            //    txtInfoSK.Focus();
            //    return false;
            //}
            //if (dateMasuk.Text.Equals(""))
            //{
            //    MessageBox.Show("Tanggal masuk belum diisi.");
            //    dateMasuk.Focus();
            //    return false;
            //}
            //if (dateKeluar.Text.Equals(""))
            //{
            //    MessageBox.Show("Tanggal keluar belum diisi.");
            //    dateKeluar.Focus();
            //    return false;
            //}
            return true;

        }

        private void Notifikasi()
        {
            switch (FormMode)
            {
                case enumFormMode.New:
                    {
                        MessageBox.Show(Messages.Confirm.SaveSuccess);
                        break;
                    }
                case enumFormMode.update:
                    {
                        MessageBox.Show(Messages.Confirm.UpdateSuccess);
                        break;
                    }
                    
            }
            this.DialogResult = DialogResult.OK;
            CloseForm();
            this.Close();
        }

        private void LoadFormManipulasiData()
        {
            switch (FormMode)
            {
                case enumFormMode.update:
                    {
                        DataTable dt=new DataTable();
                        using(Database db=new Database())
                        {
                            db.Commands.Add(db.CreateCommand("Usp_Karyawan_LIST_Header"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowId));
                            dt = db.Commands[0].ExecuteDataTable();
                            txtKaryawanID.Text=Tools.isNull(dt.Rows[0]["KaryawanID"],"").ToString();
                            txtNamakaryawan.Text=Tools.isNull(dt.Rows[0]["NamaKaryawan"],"").ToString();
                            txtInitial.Text=Tools.isNull(dt.Rows[0]["Initial"],"").ToString();
                            String JK=Tools.isNull(dt.Rows[0]["JenisKelamin"],"").ToString();
                            switch(JK)
                            {
                                case "Laki-Laki":
                                    {
                                        rdoLaki.Checked=true;
                                        break;
                                    }
                                case "Perempuan":
                                    {
                                        rdoPerempuan.Checked=true;
                                        break;
                                    }
                            }

                            String agama = Tools.isNull(dt.Rows[0]["Agama"], "").ToString();
                            FillComboAgama();
                            switch (agama)
                            {
                                case "Islam":
                                    { cboAgama.SelectedIndex = 1; break; }
                                case "Kristen":
                                    { cboAgama.SelectedIndex = 2; break; }
                                case "Protestan":
                                    { cboAgama.SelectedIndex = 3; break; }
                                case "Konghucu":
                                    { cboAgama.SelectedIndex = 4; break; }
                                case "Hindu":
                                    { cboAgama.SelectedIndex = 5; break; }
                                case "Budha":
                                    { cboAgama.SelectedIndex = 6; break; }
                            }

                            String StatusNikah = Tools.isNull(dt.Rows[0]["StatusNikah"], "").ToString();
                            FillComboStatusNikah();
                            switch (StatusNikah)
                            { 
                                case "Belum Menikah":
                                    { cboStatusNikah.SelectedIndex = 1; break; }
                                case "Sudah Menikah":
                                    { cboStatusNikah.SelectedIndex = 2; break; }
                            }
                            if (cboStatusNikah.SelectedIndex == 1)
                            {
                                nudJumlahAnak.Enabled = false;
                            }
                            else
                            {
                                nudJumlahAnak.Enabled = true;
                            }
                            nudJumlahAnak.Value = (int)Tools.isNull(dt.Rows[0]["JumlahAnak"],0);

                            String StatusKaryawan = Tools.isNull(dt.Rows[0]["StatusKaryawan"], "").ToString();
                            FillComboStatusKaryawan();
                            switch (StatusKaryawan)
                            {
                                case "tetap":
                                    { cboStatusKaryawan.SelectedIndex = 1; break; }
                                case "Tidak tetap":
                                    { cboStatusKaryawan.SelectedIndex = 2; break; }
                            }
                            txtTempatLahir.Text = Tools.isNull(dt.Rows[0]["TempatLahir"], "").ToString();
                            dateLahir.Text = Tools.isNull(dt.Rows[0]["TanggalLahir"], "").ToString();
                            txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                            fcbo.fillComboBagianDanSub(cboBagian);
                            Guid RowId = (Guid)Tools.isNull(dt.Rows[0]["BagianRowID"],Guid.Empty);
                            cboBagian.SelectedValue = RowId;
                            String PendAkhir = Tools.isNull(dt.Rows[0]["Pendidikan"], "").ToString();
                            FillComboPendidikanTerakhir();
                            switch (PendAkhir)
                            {
                                case "S2":
                                    { cboPendidikanTerakhir.SelectedIndex = 1; break; }
                                case "S1":
                                    { cboPendidikanTerakhir.SelectedIndex = 2; break; }
                                case "D3":
                                    { cboPendidikanTerakhir.SelectedIndex = 3; break; }
                                case "D2":
                                    { cboPendidikanTerakhir.SelectedIndex = 4; break; }
                                case "D1":
                                    { cboPendidikanTerakhir.SelectedIndex = 5; break; }
                                case "SMA":
                                    { cboPendidikanTerakhir.SelectedIndex = 6; break; }
                                case "SMP":
                                    { cboPendidikanTerakhir.SelectedIndex = 7; break; }
                            }
                            txtReferensi.Text = Tools.isNull(dt.Rows[0]["Referensi"], "").ToString();
                            txtInfoSK.Text = Tools.isNull(dt.Rows[0]["InfomSK"], "").ToString();
                            dateMasuk.Text = Tools.isNull(dt.Rows[0]["TanggalMasuk"], "").ToString();
                            dateKeluar.Text = Tools.isNull(dt.Rows[0]["TanggalKeluar"], "").ToString();

                        }
                               
                
                        break;
                    }
                case enumFormMode.New:
                    {
                        FillComboAgama();
                        FillComboPendidikanTerakhir();
                        FillComboStatusKaryawan();
                        FillComboStatusNikah();
                        FillComboBagian();
                        break;
                    }
            }
        }

        private void save_update_data()
        {
           if(validasiInputan())

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Karyawan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,_rowId));
                    db.Commands[0].Parameters.Add(new Parameter("@KaryawanId", SqlDbType.VarChar, txtKaryawanID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@BagianRowID", SqlDbType.UniqueIdentifier, cboBagian.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaKaryawan", SqlDbType.VarChar, txtNamakaryawan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Initial", SqlDbType.VarChar, txtInitial.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@JK", SqlDbType.VarChar, JenisKelamin()));
                    db.Commands[0].Parameters.Add(new Parameter("@Agama", SqlDbType.VarChar, cboAgama.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusNikah", SqlDbType.VarChar, cboStatusNikah.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@JumlahAnak", SqlDbType.VarChar, nudJumlahAnak.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusKaryawan", SqlDbType.VarChar, cboStatusKaryawan.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TempatLahir", SqlDbType.VarChar, txtTempatLahir.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalLahir", SqlDbType.VarChar, dateLahir.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Pendidikan", SqlDbType.VarChar, cboPendidikanTerakhir.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Referensi", SqlDbType.VarChar, txtReferensi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@InfomSK", SqlDbType.VarChar, txtInfoSK.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalMasuk", SqlDbType.VarChar, dateMasuk.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalKeluar", SqlDbType.VarChar, dateKeluar.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    dt=db.Commands[0].ExecuteDataTable();

                   Notifikasi();
           
                }

            }
            catch (Exception Ex)
            {
                Error.LogError(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKaryawanBrowse)
                {
                    frmKaryawanBrowse frmCaller = (frmKaryawanBrowse)this.Caller;
                    frmCaller.LoadDataKaryawan();
                    frmCaller.FindRow("KaryawanID", txtKaryawanID.Text);
                }
            }
        }



        #endregion

        public frmKaryawanUpdate(Form caller)
        {
            InitializeComponent();
            FormMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKaryawanUpdate(Form caller,Guid RowID)
        {
            InitializeComponent();
            FormMode = enumFormMode.update;
            this.Caller = caller;
            _rowId = RowID;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cboBagian.Items.Count != 1)
            {
                save_update_data();
            }
            else { MessageBox.Show("Maaf, data Bagian pada Form Bagian dan Sub Bagian diisi dulu."); return; }
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKaryawanUpdate_Load(object sender, EventArgs e)
        {
            LoadFormManipulasiData();
        }

        private void cboStatusNikah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatusNikah.SelectedIndex == 1)
            {
                nudJumlahAnak.Enabled = false;
            }
            else
            {
                nudJumlahAnak.Enabled = true;
            }
        }



    }
}
