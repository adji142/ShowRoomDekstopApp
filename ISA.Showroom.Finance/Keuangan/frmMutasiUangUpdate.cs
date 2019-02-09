using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmMutasiUangUpdate : ISA.Controls.BaseForm
    { 
        enum enumFormMode { New, Update } 
        enumFormMode formMode;
         
        DataTable dt = new DataTable(); 
        Guid _rowID;  
        enum enumVia { Kas , Bank , Giro }
        enumVia _bentukPenerimaan, _bentukPengeluaran = new enumVia();
        string[,] _aBentuk = { { "K", "Kas" }, { "B", "Bank" }, { "G", "Giro" } };

        DateTime _today = GlobalVar.GetServerDate;
         
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public frmMutasiUangUpdate()
        {
            InitializeComponent();
        }

        public frmMutasiUangUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmMutasiUangUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMutasiUangUpdate_Load(object sender, EventArgs e)
        {
            cboUnitUsaha.SelectedIndex = 0;
            fcbo.fillComboPerusahaan(cboPerusahaan);
            fcbo.fillComboBank((ComboBox)cboBankKeluar);
            fcbo.fillComboBank((ComboBox)cboBankTerima);
            fcbo.fillComboMataUang(cboMataUangKeluar);
            if (cboMataUangKeluar.Items.Count > 1)
            {
                cboMataUangKeluar.SelectedIndex = 1;
            }
            fcbo.fillComboMataUang(cboMataUangTerima);
            if (cboMataUangTerima.Items.Count > 1)
            {
                cboMataUangTerima.SelectedIndex = 1;
            }
            
            fcbo.fillComboKas(cboKasKeluar, GlobalVar.PerusahaanRowID);
            if (cboKasKeluar.Items.Count > 1)
            {
                cboKasKeluar.SelectedIndex = 1;
            }
            fcbo.fillComboKas(cboKasTerima, GlobalVar.PerusahaanRowID);
            if (cboKasTerima.Items.Count > 1)
            {
                cboKasTerima.SelectedIndex = 1;
            }
            fcbo.fillComboCabang(cboCabang);
            RefreshData();

        }

        #region Parameter Lock

        private List<int> ParameterKuncian()
        {
            List<int> _parameterkuncian = new List<int>();
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Lock"));
                dt = db.Commands[0].ExecuteDataTable();
                _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);
                _parameterkuncian.Add((int)dt.Rows[0]["PostdatedLock"]);

            }
            return _parameterkuncian;
        }

        private bool ValidasiSimpan()
        {

            bool Expired = false;
            List<int> parameter = ParameterKuncian();
            if (dtTanggal.DateValue <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || dtTanggal.DateValue >= GlobalVar.GetServerDate.AddDays(+parameter[1]))
            { Expired = true; }
            return Expired;
        }


        #endregion

        private void SetTabIndexKeluarDari(String keyChar)
        {
            /*
            switch (keyChar)
            {
                case "K":
                    {
                        rdoKasKeluar.TabIndex = 6;
                        cboMataUangKeluar.TabIndex = 7;
                        txtNominalKeluar.TabIndex = 8;
                        cboKasKeluar.TabIndex = 9;
                        grpJnsPenerimaan.TabIndex = 10;

                        break;
                    }
                case "B":
                        {
                            rdoBankKeluar.TabIndex = 6;
                            cboMataUangKeluar.TabIndex = 7;
                            txtNominalKeluar.TabIndex = 8;
                            lkpRekeningKeluar.TabIndex = 9;
                            grpJnsPenerimaan.TabIndex = 10;
                            break;
                        }
                case "G":
                        {
                            break;
                        }
            }
            */
        }

        private void RefreshData()
        {
            //enumVia via = enumVia.Kas;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_MutasiUang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                    txtNoBukti.Enabled = false;
                    if (dt.Rows[0]["Tanggal"] == System.DBNull.Value) dtTanggal.Text = "";
                    else dtTanggal.DateValue = (DateTime)(dt.Rows[0]["Tanggal"]);
                    txttglrk.DateValue = (DateTime)(dt.Rows[0]["TanggalRk"]);
                    txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                    cboPerusahaan.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanRowID"], Guid.Empty);
                    cboCabang.SelectedValue = Tools.isNull(dt.Rows[0]["CabangID"], "").ToString();
                    _bentukPengeluaran = (enumVia)int.Parse(Tools.isNull(dt.Rows[0]["JnsPengeluaran"], "").ToString());
                    _bentukPenerimaan = (enumVia)int.Parse(Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString());
                    numKursKeluar.Text = Tools.isNull(dt.Rows[0]["Kurs"], "").ToString();
                    switch (_bentukPengeluaran)
                    {
                        case enumVia.Kas:
                            {

                                rdoKasKeluar.Checked = true;

                                break;
                            }
                        case enumVia.Bank:
                            {


                                rdoBankKeluar.Checked = true;

                                break;
                            }

                    }

                    showPanelPengeluaran(_bentukPengeluaran);



                    switch (_bentukPenerimaan)
                    {
                        case enumVia.Kas:
                            {
                                rdoKasTerima.Checked = true;
                                break;
                            }
                        case enumVia.Bank:
                            {
                                rdoBankTerima.Checked = true;
                                break;
                            }
                    }

                    showPanelPenerimaan(_bentukPenerimaan);

                    cboMataUangKeluar.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["MataUangDariRowID"], Guid.Empty);
                    cboMataUangTerima.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["MataUangKeRowID"], Guid.Empty);
                    txtNominalKeluar.Text = Tools.isNull(dt.Rows[0]["NominalDari"], "").ToString();
                    txtNominalTerima.Text = Tools.isNull(dt.Rows[0]["NominalKe"], "").ToString();
                    numNominalRpKeluar.Text = Tools.isNull(dt.Rows[0]["NominalDariRp"], "").ToString();
                    numNominalRpTerima.Text = Tools.isNull(dt.Rows[0]["NominalKeRp"], "").ToString();

                    cboKasKeluar.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["KasDariRowID"], Guid.Empty);
                    cboKasTerima.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["KasKeRowID"], Guid.Empty);
                    cboBankKeluar.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["BankDariRowID"], Guid.Empty);
                    cboBankTerima.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["BankKeRowID"], Guid.Empty);
                    Guid RekRowKeluar=(Guid)Tools.isNull(dt.Rows[0]["RekeningDariRowID"],Guid.Empty);
                    if(!RekRowKeluar.Equals(Guid.Empty))
                    {
                        lkpRekeningKeluar.RekeningRowID = RekRowKeluar;
                    }
                    
                    Guid RekRowKe = (Guid)Tools.isNull(dt.Rows[0]["RekeningKeRowID"],Guid.Empty);
                    //lkpRekeningMasuk.RekeningRowID (Guid)Tools.isNull(dt.Rows[0]["RekeningKeRowID"], System.Data.SqlTypes.SqlGuid.Null);
                    if(!RekRowKe.Equals(Guid.Empty))
                    {
                        lkpRekeningMasuk.RekeningRowID = RekRowKe;
                    }

                    //Tambahan UnitUsaha
                    if ((Tools.isNull(dt.Rows[0]["UnitUsaha"], "").ToString()) != "")
                    {
                        cboUnitUsaha.SelectedItem = dt.Rows[0]["UnitUsaha"].ToString();
                    }
                    
                }
                else
                {
                    rdoBankKeluar.Checked = true;
                    rdoBankTerima.Checked = true;
                    dtTanggal.DateValue = _today;
                    txttglrk.DateValue = _today;
                    cboPerusahaan.SelectedValue = GlobalVar.PerusahaanRowID;
                    cboCabang.SelectedValue = GlobalVar.CabangID;
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

            switch (formMode)
            {
                case enumFormMode.New:
                    {
                        rdoKasKeluar.Checked = true;
                        rdoKasTerima.Checked = true;
                        break;
                    }
                case enumFormMode.Update: break;
            }
            //showPanelPenerimaan(via);
            //showPanelPengeluaran(via);
        }

        private void rdoKasKeluar_CheckedChanged(object sender, EventArgs e)
        {
            showPanelPengeluaran(enumVia.Kas);
            SetTabIndexKeluarDari("K");
        }

        private void rdoBankKeluar_CheckedChanged(object sender, EventArgs e)
        {

            showPanelPengeluaran(enumVia.Bank);
            SetTabIndexKeluarDari("B");
           
        }

        private void rdoGiroKeluar_CheckedChanged(object sender, EventArgs e)
        {
            showPanelPengeluaran(enumVia.Giro);
            SetTabIndexKeluarDari("G");
        }

        private void rdoKasTerima_CheckedChanged(object sender, EventArgs e)
        {
            showPanelPenerimaan(enumVia.Kas);
          
        }

        private void rdoBankTerima_CheckedChanged(object sender, EventArgs e)
        {
            showPanelPenerimaan(enumVia.Bank);
           
        }

        private void rdoGiroTerima_CheckedChanged(object sender, EventArgs e)
        {
            showPanelPenerimaan(enumVia.Giro);
     
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrEmpty(dtTanggal.DateValue.ToString()))
                {
                    MessageBox.Show("Tanggal belum diisi");
                    dtTanggal.Focus();
                    return;
                }

                //if (dtTanggal.DateValue < Convert.ToDateTime(GlobalVar.GetServerDate).AddDays(-3))
                //{
                //    MessageBox.Show("Tidak diijinkan input tanggal jika lebih dari 3 hari", "Informasi");
                //    return;
                //}


                if (string.IsNullOrEmpty(cboMataUangKeluar.Text.ToString()))
                {
                    MessageBox.Show("Combo Mata Uang ID keluar belum dipilih.");
                    cboMataUangKeluar.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNominalKeluar.Text.ToString()) || (double.Parse(txtNominalKeluar.Text) == 0))
                {
                    MessageBox.Show("Nominal Keluar belum diisi");
                    txtNominalKeluar.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cboMataUangTerima.Text.ToString()))
                {
                    MessageBox.Show("Combo Mata Uang ID terima belum dipilih.");
                    cboMataUangTerima.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNominalTerima.Text.ToString()) || (double.Parse(txtNominalTerima.Text) == 0))
                {
                    MessageBox.Show("Nominal Terima belum diisi");
                    txtNominalTerima.Focus();
                    return;    
                }

                //if ((string.IsNullOrEmpty(numKurs.Text.ToString())||(double.Parse(numKurs.Text.ToString()) == 0)))
                //{
                //    MessageBox.Show("Nilai Kurs belum diisi");
                //    numKurs.Focus();
                //    return;
                //}

                if (string.IsNullOrEmpty(numNominalRp.Text.ToString())||(double.Parse(numNominalRp.Text.ToString()) == 0))
                {
                    MessageBox.Show("Nominal Rp. belum diisi");
                    numNominalRp.Focus();
                    return;
                }

                if (dtTanggal.DateValue < GlobalVar.GetBackDatedLockValue())
                {
                    MessageBox.Show("Tidak boleh input data lebih dari batas waktu input / ubah data");
                    return;
                }

                if (string.IsNullOrEmpty(cboCabang.Text.ToString()))
                {
                    MessageBox.Show("Cabang Penerima");
                    cboCabang.Focus();
                    return;
                }

                switch (_bentukPenerimaan)
                {
                    case enumVia.Kas:
                        if (string.IsNullOrEmpty(cboKasTerima.Text.ToString())) { 
                            MessageBox.Show("Jenis Kas terima belum dipilih");
                            cboKasTerima.Focus();
                            return;
                        }
                        break;
                    case enumVia.Bank:
                        if ((Guid)Tools.isNull(lkpRekeningMasuk.RekeningRowID,Guid.Empty)==Guid.Empty)
                        {
                            if (string.IsNullOrEmpty(lkpRekeningMasuk.txtSearch.Text.ToString()))
                                MessageBox.Show("No. Rekening Bank terima belum dipilih");
                            else
                                MessageBox.Show("Kode Rekening '" + lkpRekeningMasuk.txtSearch.Text.ToString() + 
                                                "' tidak ditemukan di database.");
                            cboRekeningTerima.Focus();
                            return;
                        }
                        break;
                    case enumVia.Giro:
                        if (string.IsNullOrEmpty(cboBankTerima.Text.ToString()))
                        {
                            MessageBox.Show(" Bank Penerima belum dipilih");
                            cboBankTerima.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(txtNoGiroTerima.Text.ToString()))
                        {
                            MessageBox.Show(" Nomor Giro PenerimaBelum diisi.");
                            txtNoGiroTerima.Focus();
                            return;
                        }
                        break;
                }

                switch (_bentukPengeluaran)
                {
                    case enumVia.Kas:
                        if (string.IsNullOrEmpty(cboKasKeluar.Text.ToString())) {
                            MessageBox.Show("Jenis Kas keluar belum dipilih.");
                            cboKasKeluar.Focus();
                            return;
                        }
                        break;
                    case enumVia.Bank:
                        if ((Guid)Tools.isNull(lkpRekeningKeluar.RekeningRowID,Guid.Empty)==Guid.Empty)
                        {
                            if (string.IsNullOrEmpty(lkpRekeningKeluar.txtSearch.Text.ToString()))
                                MessageBox.Show("No. Rekening Bank keluar belum dipilih");
                            else
                                MessageBox.Show("Kode Rekening '" + lkpRekeningKeluar.txtSearch.Text.ToString() +
                                                "' tidak dapat ditemukan di database");
                            cboRekeningKeluar.Focus();
                            return;
                        }
                        break;
                    case enumVia.Giro:
                        if (string.IsNullOrEmpty(cboBankKeluar.Text.ToString()))
                        {
                            MessageBox.Show(" Bank Penerima belum dipilih");
                            cboBankKeluar.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(txtNoGiroKeluar.Text.ToString()))
                        {
                            MessageBox.Show(" Nomor Giro PenerimaBelum diisi");
                            txtNoGiroKeluar.Focus();
                            return;
                        }
                        break;
                }

                //if (!(cboMataUangKeluar.Text.ToString().Equals(cboMataUangTerima.Text.ToString())))
                //{
                //    if (string.IsNullOrEmpty(numKursKeluar.Text.ToString()) || (numKursKeluar.GetDoubleValue == 0))
                //    {
                //        MessageBox.Show("Nilai Kurs Lintas Mata Uang harus diisi dan tidak boleh 0.");
                //        numKursKeluar.Focus();
                //        return;
                //    }
                //}

                //try
                //{
                    this.Cursor = Cursors.WaitCursor;
                
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            {
                            using (Database db = new Database())
                            { 
                            
                                // if (Tools.isNull(txtNoBukti.Text, "").ToString() == "")
                                //{
                                    //string _prefix = _aBentuk[(int)_bentukPengeluaran, 0] + _aBentuk[(int)_bentukPenerimaan, 0];

                                    //txtNoBukti.Text = Numerator.GetNomorDokumen("MUTASI_UANG", "", "/B" + _prefix + "T/" + 
                                    //                    string.Format("{0:yyMM}", dtTanggal.DateValue)
                                    //                    , 3, false, true);
                                //}
                                DataTable dt = new DataTable();
                                _rowID = Guid.NewGuid();//XXX
                                db.Commands.Add(db.CreateCommand("usp_MutasiUang_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));//XXX
                                db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txttglrk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cboCabang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.TinyInt, _bentukPengeluaran));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.TinyInt, _bentukPenerimaan));
                                db.Commands[0].Parameters.Add(new Parameter("@KasDariRowID", SqlDbType.UniqueIdentifier, cboKasKeluar.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@KasKeRowID", SqlDbType.UniqueIdentifier, cboKasTerima.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@BankDariRowID ", SqlDbType.UniqueIdentifier, lkpRekeningKeluar.BankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@BankKeRowID", SqlDbType.UniqueIdentifier, lkpRekeningMasuk.BankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningDariRowID", SqlDbType.UniqueIdentifier, lkpRekeningKeluar.RekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningKeRowID", SqlDbType.UniqueIdentifier, lkpRekeningMasuk.RekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangDariRowID", SqlDbType.UniqueIdentifier, cboMataUangKeluar.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@MatauangKeRowID", SqlDbType.UniqueIdentifier, cboMataUangTerima.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@kurs", SqlDbType.Money, numKurs.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalDari", SqlDbType.Money, double.Parse(txtNominalKeluar.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalKe", SqlDbType.Money, double.Parse(txtNominalTerima.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalDariRp", SqlDbType.Money, double.Parse(numNominalRp.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalKeRp", SqlDbType.Money, double.Parse(numNominalRp.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@UnitUsaha", SqlDbType.VarChar, cboUnitUsaha.Text));
                                dt = db.Commands[0].ExecuteDataTable();

                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("No.Bukti : " + txtNoBukti.Text + " Sudah terdaftar di database");
                                    txtNoBukti.Text = string.Empty;
                                    txtNoBukti.Focus();
                                    return;
                                }
                                MessageBox.Show(Messages.Confirm.SaveSuccess);
                            }

                            break;
                            }
                        
                      
           
               
                        case enumFormMode.Update:
                            {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_MutasiUang_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txttglrk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cboCabang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.TinyInt, _bentukPengeluaran));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.TinyInt, _bentukPenerimaan));
                                db.Commands[0].Parameters.Add(new Parameter("@KasDariRowID", SqlDbType.UniqueIdentifier, cboKasKeluar.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@KasKeRowID", SqlDbType.UniqueIdentifier, cboKasTerima.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@BankDariRowID ", SqlDbType.UniqueIdentifier, lkpRekeningKeluar.BankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@BankKeRowID", SqlDbType.UniqueIdentifier, lkpRekeningMasuk.BankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningDariRowID", SqlDbType.UniqueIdentifier, lkpRekeningKeluar.RekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningKeRowID", SqlDbType.UniqueIdentifier, lkpRekeningMasuk.RekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangDariRowID", SqlDbType.UniqueIdentifier, cboMataUangKeluar.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@MatauangKeRowID", SqlDbType.UniqueIdentifier, cboMataUangTerima.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@kurs", SqlDbType.Money, numKursKeluar.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalDari", SqlDbType.Money, double.Parse(txtNominalKeluar.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalKe", SqlDbType.Money, double.Parse(txtNominalTerima.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalDariRp", SqlDbType.Money, double.Parse(numNominalRpKeluar.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalKeRp", SqlDbType.Money, double.Parse(numNominalRpTerima.Text.ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@UnitUsaha", SqlDbType.VarChar, cboUnitUsaha.Text));
                                db.Commands[0].ExecuteNonQuery();
                                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                            }
                            break;
                           }   
                    }
                    this.DialogResult = DialogResult.OK;
                    closeForm();
                    this.Close();
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    this.Cursor = Cursors.Default;
                //}

            }
        }

        private void cboBankKeluar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboBankKeluar.DisplayMember!="") && (cboBankKeluar.Text!="")) fcbo.fillComboRekening(cboRekeningKeluar, (Guid)cboBankKeluar.SelectedValue);
        }

        private void cboBankTerima_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboBankTerima.DisplayMember!="") && (cboBankTerima.Text!="")) fcbo.fillComboRekening(cboRekeningTerima,(Guid)cboBankTerima.SelectedValue);
        }

        #region refreshCboMataUangID

        private void RefreshCboMataUangIDKeluar()
        {
            lkpRekeningKeluar.txtSearch.Text = String.Empty;
            lkpRekeningKeluar.lblNoRekening.Text = String.Empty;
            lkpRekeningKeluar.lblBank.Text = String.Empty;
            if (cboMataUangKeluar.Text == "IDR")
            {
                if (!string.IsNullOrEmpty(cboMataUangTerima.Text) && (cboMataUangTerima.Text != "IDR") && (string.IsNullOrEmpty(numKurs.Text) || (numKurs.Text == "0")))
                    GetCurrencyRateKeluar();
                    
            }
        }

        private void RefreshCboMataUangIDMasuk()
        {
            lkpRekeningMasuk.txtSearch.Text = String.Empty;
            lkpRekeningMasuk.lblNoRekening.Text = String.Empty;
            lkpRekeningMasuk.lblBank.Text = String.Empty;

        }

        #endregion

        private void cboMataUangKeluar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboMataUangKeluar.Text))
            {
                RefreshCboMataUangIDKeluar();
                lkpRekeningKeluar.Enabled = true;
                lkpRekeningKeluar.MataUangIDRekening = cboMataUangKeluar.Text.ToString();
                if (cboPerusahaan.SelectedIndex != 0)
                {
                    lkpRekeningKeluar.PerusahaanID = (Guid)cboPerusahaan.SelectedValue;
                }
                //if (cboMataUangTerima.Text == cboMataUangKeluar.Text)
                //{
                //    txtNominalKeluar.Text = txtNominalTerima.Text;
                //    numKursKeluar.Text = numKursTerima.Text;
                //    numNominalRpKeluar.Text = numNominalRpTerima.Text;
                //    MataUangSama();
                //}
                //else
                //{
                //    MataUangKeluar();
                //    GetCurrencyRateKeluar();
                //    HitungNominalRpKeluar();
                //}
            }
            else 
            {
                RefreshCboMataUangIDKeluar();
                lkpRekeningKeluar.Enabled = false; 
            }
            lblKurs.Text = "Kurs " + cboMataUangKeluar.Text + " terhadap " + cboMataUangTerima.Text;
            HitungKurs();
        }

        private void txtNominalKeluar_TextChanged(object sender, EventArgs e)
        {
            if (cboMataUangKeluar.Text == cboMataUangTerima.Text) MataUangSama();
            else
            {
                //MataUangKeluar();
                //HitungNominalRpKeluar();
            }
            HitungKurs();
        }

        #region Functions
        void MataUangKeluar()
        {
            bool isIDR = (cboMataUangKeluar.Text == "IDR");
            numKursKeluar.Enabled = !isIDR;
            numNominalRpKeluar.Enabled = !isIDR;
                if (isIDR)
            {
                numKursKeluar.Text = Convert.ToString(1);
                numNominalRpKeluar.Text = txtNominalKeluar.Text;
            }
        }

        void MataUangTerima()
        {
            bool isIDR = ((cboMataUangTerima.Text == "IDR"));//||(cboMataUangTerima.Text==cboMataUangKeluar.Text)) ;
            numKursTerima.Enabled = !isIDR;
            numNominalRpTerima.Enabled = !isIDR;
            if (isIDR)
            {
                numKursTerima.Text = Convert.ToString(1);
                numNominalRpTerima.Text = txtNominalTerima.Text;
            }
        }

        private void showPanelPenerimaan(enumVia via)
        {
            _bentukPenerimaan = via;
            lblKasTerima.Visible = (via == enumVia.Kas);
            cboKasTerima.Visible = (via == enumVia.Kas);
            lblBankTerima.Visible = (via != enumVia.Kas);
            lkpRekeningMasuk.Visible = (via != enumVia.Kas);
            cboBankTerima.Visible = (via != enumVia.Kas);
            lblRekeningTerima.Visible = (via != enumVia.Kas);
            cboRekeningTerima.Visible = (via == enumVia.Bank);
            txtRekeningTerima.Visible = (via == enumVia.Giro);
            lblGiroTerima.Visible = (via == enumVia.Giro);
            txtNoGiroTerima.Visible = (via == enumVia.Giro);
        }

        private void showPanelPengeluaran(enumVia via)
        {
           
                _bentukPengeluaran = via;
                lblKasKeluar.Visible = (via == enumVia.Kas);
                cboKasKeluar.Visible = (via == enumVia.Kas);
                lkpRekeningKeluar.Visible = (via != enumVia.Kas);
                lblBankKeluar.Visible = (via != enumVia.Kas);
                cboBankKeluar.Visible = (via != enumVia.Kas);
                lblRekeningKeluar.Visible = (via != enumVia.Kas);
                cboRekeningKeluar.Visible = (via == enumVia.Bank);
                txtRekeningKeluar.Visible = (via == enumVia.Giro);
                lblGiroKeluar.Visible = (via == enumVia.Giro);
                txtNoGiroKeluar.Visible = (via == enumVia.Giro);
               
           
        }

        private float GetCurrencyRateKeluar() {
            float rate = 0;
            if ((dtTanggal.Text != "") && (cboMataUangKeluar.Text != ""))
            {
                try
                {
                    rate = Tools.GetCurrencyRate((Guid)cboMataUangKeluar.SelectedValue, (DateTime)dtTanggal.DateValue);
                }
                catch { }
                numKursKeluar.Text = string.Format("{0:0,0.0}", rate);
                numKurs.Text = numKursKeluar.Text;
            }
            return rate;
        }

        private void GetCurrencyRateTerima()
        {
            //float rate = 0;
            //if ((dtTanggal.Text != "") && (cboMataUangTerima.Text != ""))
            //{
            //    rate = Tools.GetCurrencyRate((Guid)cboMataUangTerima.SelectedValue, (DateTime)dtTanggal.DateValue);
            //    numKursTerima.Text = string.Format("{0:0,0.0}", rate);
            //}
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMutasiUangBrowse)
                {
                    frmMutasiUangBrowse frmCaller = (frmMutasiUangBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("NoBukti", txtNoBukti.Text);
                }
            }
            //this.Close();
        }

        void HitungNominalKeluar()
        {

        }

        #endregion Functions

        private void dtTanggal_TextChanged(object sender, EventArgs e)
        {

            GetCurrencyRateKeluar();
            GetCurrencyRateTerima();

            //if (ValidasiSimpan() == true)
            //        {
            //            cmdSAVE.Enabled = false;
                       
            //        }
            //        else { cmdSAVE.Enabled = true; }
                
            

        }

        private void cboMataUangTerima_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboMataUangTerima.Text.ToString().Equals("")))
            {
                RefreshCboMataUangIDMasuk();
                lkpRekeningMasuk.Enabled = true;
                lkpRekeningMasuk.MataUangIDRekening = cboMataUangTerima.Text.ToString();
                if (cboPerusahaan.SelectedIndex != 0)
                {
                    lkpRekeningMasuk.PerusahaanID = (Guid)cboPerusahaan.SelectedValue;
                }
                if (cboMataUangTerima.Text == cboMataUangKeluar.Text)
                {
                    txtNominalTerima.Text = txtNominalKeluar.Text;
                    numKursTerima.Text = numKursKeluar.Text;
                    numNominalRpTerima.Text = numNominalRpKeluar.Text;
                }
                else
                {
                    MataUangTerima();
                    HitungNominalRpTerima();
                }
            }
            else { lkpRekeningMasuk.Enabled = false; RefreshCboMataUangIDMasuk(); }
            lblKurs.Text = "Kurs " + cboMataUangKeluar.Text + " terhadap " + cboMataUangTerima.Text;
            HitungKurs();
        }

        private void MataUangSama()
        {
            if (cboMataUangKeluar.Text.ToString() == "" || cboMataUangTerima.Text.ToString() == "")
            {
                numKursKeluar.Enabled = false;
            }
            else
            {

                if (cboMataUangKeluar.Text.ToString().Equals(cboMataUangTerima.Text.ToString()))
                {
                    txtNominalTerima.Text = txtNominalKeluar.Text;
                    txtNominalTerima.Enabled = false;
                    numKursKeluar.Enabled = false;
                    numKursKeluar.Text = "1";
                }
                else
                {
                    txtNominalTerima.Enabled = true;
                    txtNominalTerima.Refresh();
                    numKursKeluar.Enabled = true;
                    //numNilaiKurs.Text = "0";
                }
            }


        }

        private void cboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNominalTerima_TextChanged(object sender, EventArgs e)
        {
            //MataUangTerima();
            //HitungNominalRpTerima();
            HitungKurs();
        }

        private void numKursKeluar_TextChanged(object sender, EventArgs e)
        {
            MataUangKeluar();
            HitungNominalRpKeluar();
        }

        void HitungNominalRpKeluar() {
            if (!string.IsNullOrEmpty(txtNominalKeluar.Text)&&!string.IsNullOrEmpty(numKursKeluar.Text))
            {
                numNominalRpKeluar.Text = (double.Parse(txtNominalKeluar.Text.ToString()) * ((cboMataUangKeluar.Text == "IDR") ? 1 : double.Parse(numKursKeluar.Text.ToString()))).ToString();
                //if (cboMataUangKeluar.Text == "IDR") numNominalRpKeluar.Text = txtNominalKeluar.Text;
            }
            else numNominalRpKeluar.Text = "0";
        }

        void HitungNominalRpTerima()
        {
            if (!string.IsNullOrEmpty(txtNominalTerima.Text)&&!string.IsNullOrEmpty(numKursTerima.Text))
            {
                numNominalRpTerima.Text = (double.Parse(txtNominalTerima.Text.ToString()) * ((cboMataUangTerima.Text == "IDR") ? 1 : double.Parse(numKursTerima.Text.ToString()))).ToString();
                //if (cboMataUangTerima.Text == "IDR") numNominalRpTerima.Text = txtNominalTerima.Text;
            }
            else numNominalRpTerima.Text = "0";
        }

        private void txtNominalKeluar_KeyUp(object sender, KeyEventArgs e)
        {
            HitungNominalRpKeluar();
        }

        private void txtNominalTerima_KeyUp(object sender, KeyEventArgs e)
        {
            HitungNominalRpTerima();
        }

        private void numKursTerima_TextChanged(object sender, EventArgs e)
        {
            HitungNominalRpTerima();
        }

        private void numKurs_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(numKurs.Text) && !string.IsNullOrEmpty(txtNominalKeluar.Text))
            {

            }
        }

        void HitungKurs()
        {
            if (cboMataUangKeluar.Text == "IDR" || cboMataUangTerima.Text == "IDR")
            {
                if (cboMataUangKeluar.Text == "IDR")
                {
                    numNominalRp.Text = txtNominalKeluar.Text;
                    if (cboMataUangTerima.Text == "IDR") txtNominalTerima.Text = txtNominalKeluar.Text;
                }
                else if (cboMataUangTerima.Text == "IDR") numNominalRp.Text = txtNominalTerima.Text;
                numNominalRp.Enabled = false;
            }
            else numNominalRp.Enabled = true;
        }
    }
}
