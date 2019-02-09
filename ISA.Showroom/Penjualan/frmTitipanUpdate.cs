using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class; 

namespace ISA.Showroom.Penjualan
{
    public partial class frmTitipanUpdate : ISA.Controls.BaseForm
    {
        enum FormMode { New, Update };
        FormMode mode = new FormMode();
        System.Guid _selectedTitipanRowID;

        enum enumTipeTitipan { Murni, UM, Angsuran, Adm };

        #region "Event Handler"
        
        public frmTitipanUpdate()
        {
            InitializeComponent();
        }

        public frmTitipanUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.New;
           
        }

        public frmTitipanUpdate(Form caller, Guid customer, string nama)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.New;
            lucPelanggan._customer.RowID = customer;
            lucPelanggan._customer.NamaCustomer = nama;
        }

        public frmTitipanUpdate(Form caller, string selectedTitipanRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.Update;
            _selectedTitipanRowID = new Guid(selectedTitipanRowID);
        }

        private void frmTitipanUpdate_Load(object sender, EventArgs e)
        {
            InitControls();
            
            if (mode == FormMode.New)
            {
                txtTglTitip.DateValue = GlobalVar.GetServerDate;
                cboMataUang.SelectedIndex = 0;

                DataTable dummyMU = new DataTable();
                using (Database dbsubMU = new Database())
                {
                    dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                    dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                    dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                    cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                }

                cboTipeTitipan.SelectedIndex = 0;
                lblMotor.Visible = false;
                lookUpStokMotor1.Visible = false;
                lookUpStokMotor1.Enabled = false;
                _selectedTitipanRowID = System.Guid.Empty; 
                
            }
            else if (mode == FormMode.Update )
            {
                BindData();
                cboTipeTitipan.Enabled = false;
                lookUpStokMotor1.Enabled = false;
            }
            txtTglTitip.Enabled = true;
            txtTglTitip.ReadOnly = false;
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void PenerimaanTitipanInsert(ref Database db, ref int counterdb, Double decNilaiNominal, Double decNilaiBGC, Guid rowIDNewTitipan, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, int tempTipeTitipan)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowIDNewTitipan));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, lucPelanggan._customer.RowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoTransaksi.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglTitip.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));

            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, tempTipeTitipan)); // murni itu 0, UM itu 1

            // tambahan untuk PembelianRowID -- hanya kalau tipe titipannya jadi titipan um
            if (cboTipeTitipan.SelectedIndex == 1) // -- index titipan UM mestinya di 1
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembelianRowID", SqlDbType.UniqueIdentifier, (Guid)lookUpStokMotor1._motor.RowID));
            }
            // kalo tipe pembayarannya itu tunai/transfer baru boleh masukkin ke data penerimaanUang
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }
            counterdb++;
        }

        private void PenerimaanUangInsert(ref Database dbf, ref int counterdbf, Double decNilaiNominal, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            // masukkan juga ke penerimaanUang
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPenerimaan = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (titipan)
            }
            // [usp_MataUang_LIST] @MataUangID varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbf.CreateCommand("usp_MataUang_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbf.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                if (cboTipeTitipan.SelectedIndex == 0) // -- index titipan Murni di 0 harusnya
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TTP).ToString() ));  // Titipan Murni/TTP -> Penerimaan Belum Iden (31)
                }
                else if (cboTipeTitipan.SelectedIndex == 1) // -- index titipan UM mestinya di 1
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMK).ToString() ));  // UM -> Uang Muka Penjualan   (28)
                }

                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglTitip.DateValue)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglTitip.DateValue)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, decNilaiNominal));

            String tambahanUraian = String.Empty;
            if (cboTipeTitipan.SelectedIndex == 1) // -- index titipan UM mestinya di 1
            {
                // berarti ada data motornya, tambahin
                tambahanUraian = " | " + lookUpStokMotor1._motor.Nopol;
            }

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " | " + lucPelanggan._customer.NamaCustomer + tambahanUraian));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); 
            
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }  
                
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void PenerimaanTitipanUpdate(ref Database db, ref int counterdb, Double decNilaiNominal, Double decNilaiBGC, Guid rekeningPembayaranRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_UPDATE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _selectedTitipanRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, lucPelanggan._customer.RowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));
            counterdb++;
        }

        private void cmdSaveTitipan_Click(object sender, EventArgs e)
        {
            if (validasiInputan())
            {
                Double decNilaiBGC = 0;
                Double decNilaiNominal = 0;
                int bentukPembayaran = 1;
                System.Guid rekeningPembayaranRowID = System.Guid.Empty;
                decNilaiNominal = Convert.ToDouble(txtPembayaran.Text);

                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
                {
                    bentukPembayaran = 2;
                    rekeningPembayaranRowID = lookUpRekening1.RekeningRowID;
                }
                else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    bentukPembayaran = 3;
                    decNilaiBGC = Convert.ToDouble(txtPembayaran.Text);
                    decNilaiNominal = 0;
                }

                if (mode == FormMode.New)
                {
                    int tempTipeTitipan = 0;
                    if(cboTipeTitipan.SelectedIndex == 0)
                    {
                        // berarti yang titipan murni
                        tempTipeTitipan = 0;
                        txtNoTransaksi.Text = Numerator.NextNumber("NTP");
                        if (txtNoTransaksi.Text == "")
                        {
                            MessageBox.Show("No Transaksi masih kosong");
                            return;
                        }
                    }
                    else if (cboTipeTitipan.SelectedIndex == 1)
                    {
                        // berarti titipan UM
                        tempTipeTitipan = 1;
                        txtNoTransaksi.Text = "K" + Numerator.NextNumber("NKJ");
                        if (txtNoTransaksi.Text == "")
                        {
                            MessageBox.Show("No Transaksi masih kosong");
                            return;
                        }
                    }

                    System.Guid rowIDNewTitipan = new System.Guid();
                    Guid penerimaanUangRowID;
                    penerimaanUangRowID = Guid.NewGuid();
                    rowIDNewTitipan = System.Guid.NewGuid();
                    _selectedTitipanRowID = rowIDNewTitipan;

                    Database db = new Database();
                    Database dbf = new Database(GlobalVar.DBFinanceOto);
                    int counterdb = 0, counterdbf = 0;

                    try
                    {
                        PenerimaanTitipanInsert(ref db, ref counterdb, decNilaiNominal, decNilaiBGC, rowIDNewTitipan, rekeningPembayaranRowID, penerimaanUangRowID, tempTipeTitipan);

    
                        // kalo tipe pembayarannya itu tunai/transfer baru boleh masukkin ke data penerimaanUang
                        if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
                        {
                            String tempBentukPenerimaan = "";
                            switch (cbxBentukPembayaran.SelectedIndex + 1)
                            {
                                case 1: // kalau kas
                                    tempBentukPenerimaan = "K";
                                    break;
                                case 2: // kalau transfer
                                    tempBentukPenerimaan = "B";
                                    break;
                                case 3: // kalau giro
                                    tempBentukPenerimaan = "G";
                                    break;
                                case 4: // kalau titipan
                                    tempBentukPenerimaan = "K";
                                    break;
                            }
                            // buat no trans penerimaanUang nya dulu
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);
                            PenerimaanUangInsert(ref dbf, ref counterdbf, decNilaiNominal, rekeningPembayaranRowID, penerimaanUangRowID, NoTransPenerimaan);
                        }

                        db.BeginTransaction();
                        dbf.BeginTransaction();
                        int looper = 0;
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        for (looper = 0; looper < counterdbf; looper++)
                        {
                            dbf.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                        dbf.CommitTransaction();
    
                        MessageBox.Show("Data berhasil ditambahkan");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        db.RollbackTransaction();
                        dbf.RollbackTransaction(); 
                        Error.LogError(ex);
                        MessageBox.Show("Penambahan penerimaan titipan gagal disimpan : " + ex.Message.ToString());  
                    }
                }
                else if (mode == FormMode.Update)
                {                    
                    Database db = new Database();
                    int counterdb = 0;
                    try
                    {     

                        PenerimaanTitipanUpdate(ref db, ref counterdb, decNilaiNominal, decNilaiBGC, rekeningPembayaranRowID);
                        db.BeginTransaction();
                        int looper = 0;
                        for (looper = 0; looper < counterdb; looper++)
                        {
                            db.Commands[looper].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                        MessageBox.Show("Data berhasil diupdate");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        Error.LogError(ex);
                        MessageBox.Show("Data gagal diproses : " + ex.Message.ToString());
                    }
                }
            }
        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = false;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                DisabledControlBG();
                lookUpRekening1.Enabled = true;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                EnabledControlBG();
                lookUpRekening1.Enabled = false;
            }
        }

        private void frmTitipanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPenerimaanTitipan)
            {
                Penjualan.frmPenerimaanTitipan frmCaller = (Penjualan.frmPenerimaanTitipan)this.Caller;
                frmCaller.RefreshGridTitipan();
                frmCaller.FindRowGridDaftarTitipan("RowID", _selectedTitipanRowID.ToString());

            }
        }

        private void cmdCloseTitipan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        #region "Custom Function"
        private bool validasiInputan()
        {
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                if (lookUpRekening1.NamaRekening.ToString() == ""|| lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                {
                    MessageBox.Show("Rekening Bank belum terisi");
                    lookUpRekening1.Focus();
                    return false;

                }
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {               
                if ( (Convert.ToDouble(Tools.isNull(txtNoBG.Text, 0)) <= 0) && (String.IsNullOrEmpty(txtNoBG.Text)) )
                {
                    MessageBox.Show("No. BGC belum diisi !");
                    txtNoBG.Focus();
                    return false;
                }

                if (txtTglBG.Text == "")
                {
                    MessageBox.Show("Tanggal Jatuh Tempo BGC belum diisi !");
                    txtTglBG.Focus();
                    return false;
                }

                if (((DateTime)txtTglBG.DateValue).Date < GlobalVar.GetServerDate.Date)
                {
                    MessageBox.Show("Tgl. BGC lebih kecil dari pada tanggal hari ini !");
                    txtTglBG.Focus();
                    return false;
                }
            }


           
            if (lucPelanggan._customer == null || lucPelanggan._customer.RowID == null || lucPelanggan._customer.RowID == Guid.Empty)
            {
                MessageBox.Show("Data pelanggan belum dipilih");
                return false; 
            }

            if (cboTipeTitipan.SelectedIndex == 1) // 1 itu kalo titipan UM
            {
                if (lookUpStokMotor1.txtNopol.Text == "" || lookUpStokMotor1._motor.RowID == null || lookUpStokMotor1._motor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Pilih Motor yang dibayarkan UM nya terlebih dahulu.");
                    return false;
                }
            }

            if (txtTglTitip.DateValue.Value < GlobalVar.GetServerDate.Date || txtTglTitip.DateValue.Value > GlobalVar.GetServerDate.Date.AddDays(2))
            {
                MessageBox.Show("Tanggal hanya bisa diinputkan hanya bisa hari ini sampai H + 2!");
                return false;
            }

            if (txtTglTitip.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
            {
                if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                }
                else
                {
                    txtTglTitip.Focus();
                    return false;
                }
            }

            return true; 
        }

        private void DisabledControlBG()
        {
            txtNoBG.Enabled = false;
            txtTglBG.Enabled = false;
        }

        private void EnabledControlBG()
        {
            txtNoBG.Enabled = true;
            txtTglBG.Enabled = true;
        }

        private void InitControls()
        {
            DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
            dt2.DefaultView.Sort = "MataUangID ASC";
            cboMataUang.DisplayMember = "MataUangID";
            cboMataUang.ValueMember = "MataUangID";
            cboMataUang.DataSource = dt2.DefaultView;
            cbxBentukPembayaran.SelectedIndex = 0; 
        }

        private void BindData()
        {

            try
            {
                using (Database db = new Database())
                {
                    DataTable dtTitipanDetail = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_TitipanGetDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@TitipanRowID", SqlDbType.UniqueIdentifier, _selectedTitipanRowID ));
                    dtTitipanDetail = db.Commands[0].ExecuteDataTable();

                    if (dtTitipanDetail.Rows.Count >= 1)
                    {
                        txtNoTransaksi.Text = dtTitipanDetail.Rows[0]["NoTrans"].ToString();
                        txtTglTitip.DateValue = Convert.ToDateTime(dtTitipanDetail.Rows[0]["Tanggal"]);

                        System.Guid selectedCustomerRowID = new Guid(Convert.ToString(dtTitipanDetail.Rows[0]["CustomerRowID"]));
                        lucPelanggan._customer = new Class.clsCostumer(selectedCustomerRowID);
                        lucPelanggan.txtNamaCustomer.Text = lucPelanggan._customer.NamaCustomer;
                        cbxBentukPembayaran.SelectedIndex = Convert.ToInt16(dtTitipanDetail.Rows[0]["BentukPembayaran"])-1;
                        txtUraian.Text = dtTitipanDetail.Rows[0]["Uraian"].ToString();

                        if (dtTitipanDetail.Rows[0]["TipeTitipan"].ToString() == "0")
                        {
                            // kalo tipenya titipan murni ngga ada apa2
                            cboTipeTitipan.SelectedIndex = 0;
                            lblMotor.Visible = false;
                            lookUpStokMotor1.Visible = false;
                            lookUpStokMotor1.Enabled = false;
                        }
                        else if (dtTitipanDetail.Rows[0]["TipeTitipan"].ToString() == "1")
                        {                                              
                            // kalo tipenya titipan um ngga ada apa2
                            cboTipeTitipan.SelectedIndex = 1;
                            // berarti ada data pembelian row id
                            lblMotor.Visible = true;
                            lookUpStokMotor1.Visible = true;
                            lookUpStokMotor1.Enabled = true;

                            System.Guid selectedPembelianRowID = new Guid(Convert.ToString(dtTitipanDetail.Rows[0]["PembelianRowID"]));
                            lookUpStokMotor1._motor = new Class.clsStokMotor(selectedPembelianRowID);
                            lookUpStokMotor1.txtNopol.Text = lookUpStokMotor1._motor.Nopol;
                        
                        }

                        //karena hanya IDR dan NewIDR , jd dimanualkan saja 
                        cboMataUang.SelectedIndex = Convert.ToString(dtTitipanDetail.Rows[0]["MataUangID"]) == "IDR" ? 0 : 1;  
                        

                        if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai")
                        {
                            DisabledControlBG();
                            lookUpRekening1.Enabled = false;
                            txtPembayaran.Text = dtTitipanDetail.Rows[0]["Nominal"].ToString(); 
                        }
                        else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
                        {
                            DisabledControlBG();
                            lookUpRekening1.Enabled = true;

                            DataTable dtRekeningDetail = new DataTable(); 
                            Database dbFinance = new Database(GlobalVar.DBFinanceOto);
                            dbFinance.Commands.Add(dbFinance.CreateCommand("usp_Rekening_LIST"));
                            dbFinance.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier , new Guid(Convert.ToString(dtTitipanDetail.Rows[0]["RekeningRowID"]))));
                            dtRekeningDetail = dbFinance.Commands[0].ExecuteDataTable();
                            txtPembayaran.Text = dtTitipanDetail.Rows[0]["Nominal"].ToString(); 

                            if (dtRekeningDetail.Rows.Count >= 1)
                            {
                                lookUpRekening1.RekeningRowID = new Guid(Convert.ToString(dtTitipanDetail.Rows[0]["RekeningRowID"]));
                                lookUpRekening1.SetLabelNoRekening(dtRekeningDetail.Rows[0]["NoRekening"].ToString());
                                lookUpRekening1.SetTextBoxNamaRekening(dtRekeningDetail.Rows[0]["NamaRekening"].ToString());
                                lookUpRekening1.NoRekening = dtRekeningDetail.Rows[0]["NoRekening"].ToString();
                                lookUpRekening1.NamaRekening = dtRekeningDetail.Rows[0]["NamaRekening"].ToString();
                            }

                        }
                        else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                        {
                            EnabledControlBG();
                            lookUpRekening1.Enabled = false;
                            txtPembayaran.Text = dtTitipanDetail.Rows[0]["NominalBGC"].ToString();
                            txtTglBG.Text = dtTitipanDetail.Rows[0]["tgljtbgc"].ToString();
                            txtNoBG.Text = dtTitipanDetail.Rows[0]["NoBGC"].ToString(); ;
                        }

                    }

                }

                cboMataUang.Enabled = false; 

            }
            catch(Exception ex)
            {
                Error.LogError(ex, "Load data titipan detail gagal"); 
            }

        }

        #endregion


        private void lookUpStokMotor1_Load(object sender, EventArgs e)
        {

        }

        private void cboTipeTitipan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipeTitipan.SelectedIndex == 0)
            {
                lookUpStokMotor1.Visible = false;
                lookUpStokMotor1.Enabled = false;
                lblMotor.Visible = false;
            }
            else if (cboTipeTitipan.SelectedIndex == 1)
            {
                lookUpStokMotor1.Visible = true;
                lookUpStokMotor1.Enabled = true;
                lblMotor.Visible = true;
            }
        }

        private void lblMotor_Click(object sender, EventArgs e)
        {

        }

       


        


    }
}
