using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;

namespace ISA.Showroom.Penjualan
{
    public partial class frmPenjualanUpdate : ISA.Controls.BaseForm
    {
        enum FormMode { New, Update };
        FormMode mode = new FormMode();
        Guid _rowID, _pembRowID, _custRowID, _salesRowID, _kolRowID, _leasingRowID;
        Guid _pengeluaranKomisirowID = Guid.Empty;

        string _pejualan = "";
        string _cabangID = GlobalVar.CabangID;
        bool isCetak1 = false;
        bool isCetak2 = false;
        bool isCetak3 = false;
        bool isCetak4 = false;
        bool isCetak5 = false;
        bool isCetak6 = false;
        bool isCetak7 = false;
        bool isCetak8 = false;

        public frmPenjualanUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.New;
            _rowID = Guid.NewGuid(); // ini row id penjualan baru
        }

        public frmPenjualanUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.Update;
            _rowID = rowID;
        }

        private void frmPenjualanUpdate_Load(object sender, EventArgs e)
        {
            dgFile.AutoGenerateColumns = false;
            int j;
            for (j = 0; j < dgFile.Columns.Count; j++)
            {
                dgFile.Columns[j].ReadOnly = true;
            }
            dgFile.Columns["Keterangan"].ReadOnly = false;
                try
                {
                    DataTable dt = FillComboBox.DBGetMataUang(Guid.Empty, "");
                    dt.DefaultView.Sort = "MataUangID ASC";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.ValueMember = "MataUangID";
                    cboMataUang.DataSource = dt.DefaultView;

                    this.ListLeasing();
                    this.ListPembulatan();

                    if (mode == FormMode.New)
                    {
                        cbxADM.Checked = true;
                        cbxADM.Enabled = false;
                        DataTable dummyMU = new DataTable();
                        using (Database dbsubMU = new Database())
                        {
                            dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                            dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                            dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                            cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                        }

                        txtTglJual.DateValue = GlobalVar.GetServerDate;
                        rbPenjualan1.Checked = true;
                        lookUpStokMotor1.txtNopol.Text = "";
                        lookUpCustomer1.txtNamaCustomer.Text = "";
                        lookUpKolektor1.txtNamaKolektor.Text = "";
                        lookUpSalesman1.txtNamaSales.Text = "";
                        this.ListAngsuran("Tunai");
                        txtVia.Text = "";
                        txtHarga.Text = "0";
                        txtBBN.Text = "0";
                        txtBiayaADM.Text = "0";
                        txtUangMuka.Text = "";
                        txtBunga.Text = "0.00";
                        numKredit.Value = 0;

                        // numTgl.Value = 1;

                        txtTotal.Text = "0";
                        txtTglAwalAngs.Text = "";
                        txtKeterangan.Text = "";
                        txtUangMuka.ReadOnly = true;
                        txtUangMuka.Enabled = false;
                        numKredit.ReadOnly = true;
                        numKredit.Enabled = false;
                        cboLeasing.Enabled = false;

                        //numTgl.ReadOnly = true;

                        txtBunga.ReadOnly = true;
                        cboPembulatan.Enabled = false;
                        cmdUbahBunga.Visible = true;
                        cmdUbahBunga.Enabled = false;

                        cbxBentukPembayaran.SelectedIndex = 0;
                        cbxBentukPembayaran.Enabled = false;
                        lookUpRekening1.Enabled = false;
                        lookUpRekening1.Visible = false;
                        lookUpRekening1.RekeningRowID = Guid.Empty;
                        lookUpRekening1.NamaRekening = "";

                        // tambahan lagi untuk bayarUM langsung (kredit)
                        if (cbxBentukPembayaran.Items.Count > 0)
                        {
                            cbxBentukPembayaran.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        cbxADM.Visible = true;
                        cbxADM.Checked = true;
                        cbxADM.Enabled = false;
                        DataTable _dt = new DataTable();

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Penjualan_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            _dt = db.Commands[0].ExecuteDataTable();
                        }

                        // ambil data biaya komisinya juga
                        txtBiayaKomisi.Text = Tools.isNull(_dt.Rows[0]["BiayaKomisi"], "").ToString();
                        _pengeluaranKomisirowID = (Guid)Tools.isNull(_dt.Rows[0]["PengeluaranKomisiRowID"], Guid.Empty);

                        txtFaktur.Text = Tools.isNull(_dt.Rows[0]["NoBukti"], "").ToString();
                        txtNoNota.Text = Tools.isNull(_dt.Rows[0]["NoTrans"], "").ToString();
                        txtTglJual.DateValue = (DateTime)Tools.isNull(_dt.Rows[0]["TglJual"], DateTime.MinValue);

                        cmdUbahBunga.Visible = false;
                        cmdUbahBunga.Enabled = false;
                        if (Tools.isNull(_dt.Rows[0]["JnsPenjualan"], "").ToString() == "TUNAI")
                        {
                            rbPenjualan1.Checked = true;
                            this.ListAngsuran("Tunai");
                            txtUangMuka.ReadOnly = true;
                            numKredit.ReadOnly = true;
                            cboLeasing.Enabled = false;

                            // numTgl.ReadOnly = true;

                            txtBunga.ReadOnly = true;
                            cboPembulatan.Enabled = false;
                            txtTglAwalAngs.ReadOnly = true;

                            // kalo tunai yg berkaitan sama angsuran di disable dan readonly
                            txtUangMuka.Text = "0";
                            numKredit.Value = 0;
                            txtBunga.Text = "0";
                            txtTglAwalAngs.Text = "";
                            numKredit.Enabled = false;

                            // tambahan lagi untuk bayarUM langsung, kalo tunai di disable 
                            if (cbxBentukPembayaran.Items.Count > 0)
                            {
                                cbxBentukPembayaran.SelectedIndex = 0;
                            }
                            cbxBentukPembayaran.Enabled = false;
                            cbxBentukPembayaran.Visible = false;
                            lookUpRekening1.Enabled = false;
                            lookUpRekening1.Visible = false;
                            lookUpRekening1.RekeningRowID = Guid.Empty;
                            lookUpRekening1.NamaRekening = "";
                        }
                        else
                        {
                            // kalo kredit 

                            rbPenjualan2.Checked = true;
                            this.ListAngsuran("Kredit");
                            txtUangMuka.ReadOnly = false;
                            numKredit.ReadOnly = false;
                            cboLeasing.Enabled = false;

                            // numTgl.ReadOnly = false;

                            txtBunga.ReadOnly = true;
                            cboPembulatan.Enabled = true;
                            txtTglAwalAngs.ReadOnly = false;
                            numKredit.Enabled = true;

                            // kalo pas update masuk ke sini, nanti mesti ambil data UM nya dari penerimaanUM
                            // untuk ngisi data bentuk pembayaran dan rekening
                            // ambil data UM  
                            DataTable _dtum = new DataTable();
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                                _dtum = db.Commands[0].ExecuteDataTable();
                            }

                            // tambahan lagi untuk bayarUM langsung, kalo kredit perlu diurus 
                            if (cbxBentukPembayaran.Items.Count > 0)
                            {
                                cbxBentukPembayaran.SelectedItem = _dtum.Rows[0]["BentukPembayaran"].ToString();
                            }
                            cbxBentukPembayaran.Enabled = true;
                            cbxBentukPembayaran.Visible = true;
                            lookUpRekening1.Enabled = false;
                            lookUpRekening1.Visible = false;

                            // kalo transfer baru ngurus data rekening
                            if (_dtum.Rows[0]["BentukPembayaran"].ToString().ToLower() == "transfer")
                            {
                                DataTable _dtrek = new DataTable();
                                using (Database dbf = new Database(GlobalVar.DBFinanceOto))
                                {
                                    dbf.Commands.Add(dbf.CreateCommand("usp_Rekening_LIST"));
                                    dbf.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)_dtum.Rows[0]["RekeningRowID"]));
                                    _dtrek = dbf.Commands[0].ExecuteDataTable();
                                }
                                lookUpRekening1.RekeningRowID = (Guid)_dtum.Rows[0]["RekeningRowID"];
                                lookUpRekening1.SetLabelNoRekening(_dtrek.Rows[0]["NoRekening"].ToString());
                                lookUpRekening1.NamaRekening = _dtrek.Rows[0]["NamaRekening"].ToString();
                                lookUpRekening1.SetTextBoxNamaRekening(_dtrek.Rows[0]["NamaRekening"].ToString());
                                lookUpRekening1.Enabled = true;
                                lookUpRekening1.Visible = true;
                            }
                            else
                            {
                                lookUpRekening1.RekeningRowID = Guid.Empty;
                                lookUpRekening1.NamaRekening = "";
                            }

                        }

                        _pembRowID = (Guid)Tools.isNull(_dt.Rows[0]["PembRowID"], Guid.Empty);
                        lookUpStokMotor1.txtNopol.Text = Tools.isNull(_dt.Rows[0]["Nopol"], "").ToString();
                        lookUpStokMotor1._motor.RowID = _pembRowID;
                        _custRowID = (Guid)Tools.isNull(_dt.Rows[0]["CustRowId"], Guid.Empty);
                        lookUpCustomer1.txtNamaCustomer.Text = Tools.isNull(_dt.Rows[0]["Customer"], "").ToString();
                        lookUpCustomer1._customer.RowID = _custRowID;
                        _salesRowID = (Guid)Tools.isNull(_dt.Rows[0]["SalesRowID"], Guid.Empty);
                        lookUpSalesman1.txtNamaSales.Text = Tools.isNull(_dt.Rows[0]["Sales"], "").ToString();
                        lookUpSalesman1._sales.RowID = _salesRowID;
                        _kolRowID = (Guid)Tools.isNull(_dt.Rows[0]["KolektorRowID"], Guid.Empty);
                        lookUpKolektor1.txtNamaKolektor.Text = Tools.isNull(_dt.Rows[0]["Kolektor"], "").ToString();
                        lookUpKolektor1._Kolektor.RowID = _kolRowID;
                        switch (Tools.isNull(_dt.Rows[0]["KodeTrans"], "").ToString())
                        {
                            case "TUN":
                                cboJnsAngsuran.Text = "Cash Keras";
                                cboLeasing.Enabled = false;
                                break;
                            case "CTP":
                                cboJnsAngsuran.Text = "Cash Tempo";
                                cboLeasing.Enabled = false;
                                break;
                            case "LSG":
                                cboJnsAngsuran.Text = "Leasing";
                                cboLeasing.Enabled = true;
                                break;
                            case "APD":
                                cboJnsAngsuran.Text = "Bunga Menurun";
                                cboLeasing.Enabled = false;
                                break;
                            case "FLT":
                                cboJnsAngsuran.Text = "Bunga Tetap / Flat";
                                cboLeasing.Enabled = false;
                                break;
                        }
                        cboLeasing.Text = Tools.isNull(_dt.Rows[0]["Leasing"], "").ToString();
                        _leasingRowID = (Guid)Tools.isNull(_dt.Rows[0]["LeasingRowID"], Guid.Empty);
                        //cboPembulatan.Text = Tools.isNull(_dt.Rows[0]["Pembulatan"], "").ToString();
                        txtVia.Text = Tools.isNull(_dt.Rows[0]["Via"], "").ToString();
                        cboMataUang.Text = Tools.isNull(_dt.Rows[0]["MataUangID"], "").ToString();
                        txtHarga.Text = Tools.isNull(_dt.Rows[0]["HargaJadi"], "").ToString();
                        txtBBN.Text = Tools.isNull(_dt.Rows[0]["BBN"], "").ToString();
                        txtBiayaADM.Text = Tools.isNull(_dt.Rows[0]["BiayaADM"], "").ToString();
                        txtUangMuka.Text = Tools.isNull(_dt.Rows[0]["UangMuka"], "").ToString();
                        numKredit.Value = int.Parse(Tools.isNull(_dt.Rows[0]["TempoAngsuran"], "0").ToString());

                        // numTgl.Value = int.Parse(Tools.isNull(_dt.Rows[0]["TglJT"], "1").ToString());

                        txtKeterangan.Text = Tools.isNull(_dt.Rows[0]["Keterangan"], "").ToString();
                        if (string.IsNullOrEmpty(_dt.Rows[0]["TglAwalAngs"].ToString())) { txtTglAwalAngs.Text = ""; }
                        else { txtTglAwalAngs.DateValue = (DateTime)Tools.isNull(_dt.Rows[0]["TglAwalAngs"], DateTime.MinValue); }
                        txtBunga.Text = Tools.isNull(_dt.Rows[0]["Bunga"], "").ToString();
                        txtTotal.Text = Tools.isNull(_dt.Rows[0]["HargaOff"], "").ToString();
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak1"], 0)) > 0)
                        {
                            isCetak1 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak2"], 0)) > 0)
                        {
                            isCetak2 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak3"], 0)) > 0)
                        {
                            isCetak3 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak4"], 0)) > 0)
                        {
                            isCetak4 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak5"], 0)) > 0)
                        {
                            isCetak5 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak6"], 0)) > 0)
                        {
                            isCetak6 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak7"], 0)) > 0)
                        {
                            isCetak7 = true;
                        }
                        if (Convert.ToDouble(Tools.isNull(_dt.Rows[0]["Cetak8"], 0)) > 0)
                        {
                            isCetak8 = true;
                        }

                        // saat update ngga boleh pindah kredit <-> tunai dulu dan nopolnya juga di lock , tgl jualnya juga
                        txtTglJual.Enabled = false;
                        rbPenjualan1.Enabled = false;
                        rbPenjualan2.Enabled = false;
                        lookUpStokMotor1.Enabled = false;

                        // bagian update, isikan dgFilenya dengan data attachment sebelumnya
                        DataTable _dtFile = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Penjualan_Attachment_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _rowID));
                            _dtFile = db.Commands[0].ExecuteDataTable();
                            // dgFile.DataSource = _dtFile; // ngga bisa pake data source biar bisa tetep diedit
                            // harus masukkin satu per satu
                            int i = 0, tempcurrent;
                            for (i = 0; i < _dtFile.Rows.Count; i++)
                            {
                                tempcurrent = dgFile.Rows.Add();
                                dgFile.Rows[tempcurrent].Cells["RowID"].Value = _dtFile.Rows[tempcurrent]["RowID"].ToString();
                                dgFile.Rows[tempcurrent].Cells["FilePath"].Value = _dtFile.Rows[tempcurrent]["FilePath"].ToString();
                                dgFile.Rows[tempcurrent].Cells["FileName"].Value = _dtFile.Rows[tempcurrent]["FileName"].ToString();
                                dgFile.Rows[tempcurrent].Cells["Keterangan"].Value = _dtFile.Rows[tempcurrent]["Keterangan"].ToString();
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

        private void ListAngsuran(String Jenis)
        {
            cboJnsAngsuran.DisplayMember = "Text";
            cboJnsAngsuran.ValueMember = "Value";
            if (Jenis == "Tunai")
            {
                var items = new[] {
                    new { Text = "CASH KERAS", Value = "TUN" },
                    new { Text = "CASH TEMPO", Value = "CTP" },
                    new { Text = "LEASING", Value = "LSG" }
                };
                cboJnsAngsuran.DataSource = items;
            }
            else if (Jenis == "Kredit")
            {
                var items = new[] {
                    new { Text = "BUNGA MENURUN", Value = "APD" },
                    new { Text = "BUNGA TETAP / FLAT", Value = "FLT" }
                };
                cboJnsAngsuran.DataSource = items;
            }            
        }

        private void ListPembulatan()
        {
            cboPembulatan.DisplayMember = "Text";
            cboPembulatan.ValueMember = "Value";
            var items = new[] { // semua yg lama jadi 100 dulu
                new { Text = "100", Value = "100" },   // { Text = "0", Value = "0" },   // mau diubah jadi 100 , 500 , 1000 ???
                new { Text = "500", Value = "500" }, // { Text = "50", Value = "50" },
                new { Text = "1000", Value = "1000" } // { Text = "100", Value = "100" }
            };
            cboPembulatan.DataSource = items;
        }

        private void ListLeasing()
        {
            try
            {
                DataTable dt = FillComboBox.DBGetLeasing(Guid.Empty);

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "Nama ASC";
                    cboLeasing.DisplayMember = "Nama";
                    cboLeasing.ValueMember = "RowID";
                    DataRow dr = dt.NewRow();
                    dr["RowID"] = Guid.Empty;
                    dr["Nama"] = "";
                    dt.Rows.Add(dr);
                    cboLeasing.DataSource = dt.DefaultView;
                }
                else
                {
                    dt.Clear();
                    cboLeasing.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void rbPenjualan1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPenjualan1.Checked == true)
            {
                this.ListAngsuran("Tunai");
                txtUangMuka.ReadOnly = true;
                numKredit.ReadOnly = true;
                cboLeasing.Enabled = false;
                txtBunga.ReadOnly = true;
                cboPembulatan.Enabled = false;
                txtTglAwalAngs.ReadOnly = true;

                // kalo tunai yg berkaitan sama angsuran di disable dan readonly
                txtUangMuka.Text = "0";
                numKredit.Value = 0;
                txtBunga.Text = "0";
                txtTglAwalAngs.Text = "";
                numKredit.Enabled = false;
                txtUangMuka.Enabled = false;

                // urus untuk pembayaranUM juga
                cbxBentukPembayaran.Enabled = false;
                cbxBentukPembayaran.Visible = false;
                lookUpRekening1.Enabled = false;
                lookUpRekening1.Visible = false;
            }
            else
            {
                this.ListAngsuran("Kredit");
                txtUangMuka.ReadOnly = false;
                numKredit.ReadOnly = false;
                cboLeasing.Enabled = false;
                
                // numTgl.ReadOnly = false;
                
                txtBunga.ReadOnly = true;
                cboPembulatan.Enabled = true;
                txtTglAwalAngs.ReadOnly = false;
                txtUangMuka.Enabled = true;
                numKredit.Enabled = true;

                // urus untuk pembayaranUM juga
                if (cbxBentukPembayaran.Items.Count > 0)
                {
                    cbxBentukPembayaran.SelectedIndex = 0;
                }
                cbxBentukPembayaran.Enabled = true;
                cbxBentukPembayaran.Visible = true;
                lookUpRekening1.Enabled = false;
                lookUpRekening1.Visible = false;
            }
            urusSisaPokok();
            urusJmlAngs();
        }

        private void rbPenjualan2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPenjualan2.Checked == true)
            {
                this.ListAngsuran("Kredit");
                txtUangMuka.ReadOnly = false;
                numKredit.ReadOnly = false;
                numKredit.Enabled = true;
                cboLeasing.Enabled = false;
                
                // numTgl.ReadOnly = false;
                
                txtBunga.ReadOnly = true;
                cboPembulatan.Enabled = true;
                txtTglAwalAngs.ReadOnly = false;
                txtUangMuka.Enabled = true;
                numKredit.Enabled = true;

                // urus untuk pembayaranUM juga
                if (cbxBentukPembayaran.Items.Count > 0)
                {
                    cbxBentukPembayaran.SelectedIndex = 0;
                }
                cbxBentukPembayaran.Enabled = true;
                cbxBentukPembayaran.Visible = true;
                lookUpRekening1.Enabled = false;
                lookUpRekening1.Visible = false;
            }
            else
            {
                this.ListAngsuran("Tunai");
                txtUangMuka.ReadOnly = true;
                numKredit.ReadOnly = true;
                cboLeasing.Enabled = false;
                txtBunga.ReadOnly = true;
                cboPembulatan.Enabled = false;
                txtTglAwalAngs.ReadOnly = true;

                // kalo tunai yg berkaitan sama angsuran di disable dan readonly
                txtUangMuka.Text = "0";
                numKredit.Value = 0;
                txtBunga.Text = "0";
                txtTglAwalAngs.Text = "";
                numKredit.Enabled = false;
                txtUangMuka.Enabled = false;

                // urus untuk pembayaranUM juga
                cbxBentukPembayaran.Enabled = false;
                cbxBentukPembayaran.Visible = false;
                lookUpRekening1.Enabled = false;
                lookUpRekening1.Visible = false;
            }
            urusSisaPokok();
            urusJmlAngs();
        }

        private void cboJnsAngsuran_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboJnsAngsuran.SelectedValue.ToString())
            {
                case "TUN":
                    txtUangMuka.ReadOnly = true;
                    numKredit.ReadOnly = true;
                    cboLeasing.Enabled = false;
                    txtTglAwalAngs.ReadOnly = true;
                    cmdUbahBunga.Enabled = false;
                    break;
                case "CTP":
                    txtUangMuka.ReadOnly = true;
                    numKredit.ReadOnly = true;
                    cboLeasing.Enabled = false;
                    txtTglAwalAngs.ReadOnly = true;
                    cmdUbahBunga.Enabled = false;
                    break;
                case "LSG":
                    txtUangMuka.ReadOnly = false;
                    numKredit.ReadOnly = true;
                    cboLeasing.Enabled = true;
                    txtTglAwalAngs.ReadOnly = true;
                    cmdUbahBunga.Enabled = false;
                    break;
                case "APD":
                    txtUangMuka.ReadOnly = false;
                    numKredit.ReadOnly = false;
                    cboLeasing.Enabled = false;
                    txtTglAwalAngs.ReadOnly = false;
                    txtBunga.Text = "3.00";
                    cmdUbahBunga.Enabled = true;
                    break;
                case "FLT":
                    txtUangMuka.ReadOnly = false;
                    numKredit.ReadOnly = false;
                    cboLeasing.Enabled = false;
                    txtTglAwalAngs.ReadOnly = false;
                    txtBunga.Text = "2.00";
                    cmdUbahBunga.Enabled = true;
                    break;
            }
        }

        private void numKredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (txtHarga.GetIntValue + txtBBN.GetIntValue + txtBiayaADM.GetIntValue).ToString();
            urusSisaPokok();
            urusJmlAngs();
        }

        private void txtBBN_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (txtHarga.GetIntValue + txtBBN.GetIntValue + txtBiayaADM.GetIntValue).ToString();
            urusSisaPokok();
            urusJmlAngs();
        }

        private void txtBiayaADM_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (txtHarga.GetIntValue + txtBBN.GetIntValue + txtBiayaADM.GetIntValue).ToString();
            urusSisaPokok();
            urusJmlAngs();
        }

        private void frmPenjualanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmPenjualanBrowse)
            {
                Penjualan.frmPenjualanBrowse frmCaller = (Penjualan.frmPenjualanBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("NoBukti", txtFaktur.Text);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateSave( ref Guid rekeningRowID )
        {
            if (string.IsNullOrEmpty(txtTglJual.Text))
            {
                MessageBox.Show("Tanggal Penjualan belum diisi !");
                txtTglJual.Focus();
                return false;
            }

            if (txtTglJual.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
            {
                if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                }
                else
                {
                    txtTglJual.Focus();
                    return false;
                }
            }

            if (Convert.ToDouble(Tools.isNull(txtHarga.Text, 0)) == 0)
            {
                MessageBox.Show("Harga Jual tidak boleh 0 (nol) !");
                txtHarga.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtBBN.Text))
            {
                MessageBox.Show("Bea Balik Nama belum diisi !\nIsikan 0 (nol) bila tidak ada Bea Balik Nama.");
                txtBBN.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtBiayaADM.Text))
            {
                MessageBox.Show("Biaya Administrasi belum diisi !\nIsikan 0 (nol) bila tidak ada Biaya Administrasi.");
                txtBiayaADM.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(lookUpStokMotor1.txtNopol.Text) || lookUpStokMotor1._motor.RowID == null || lookUpStokMotor1._motor.RowID == Guid.Empty)
            {
                MessageBox.Show("Nomor Polisi belum dipilih !");
                lookUpStokMotor1.txtNopol.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(lookUpCustomer1.txtNamaCustomer.Text) || lookUpCustomer1._customer.RowID == null || lookUpCustomer1._customer.RowID == Guid.Empty)
            {
                MessageBox.Show("Pelanggan belum diisi !");
                lookUpCustomer1.txtNamaCustomer.Focus();
                return false;
            }
            if (lookUpSalesman1._sales.RowID == null || lookUpSalesman1._sales.RowID == Guid.Empty)
            {
                MessageBox.Show("Data Salesman belum diisi !");
                lookUpSalesman1.Focus();
                return false;
            }
            if (lookUpKolektor1._Kolektor.RowID == null || lookUpKolektor1._Kolektor.RowID == Guid.Empty)
            {
                MessageBox.Show("Data Kolektor belum diisi !");
                lookUpKolektor1.Focus();
                return false;
            }

            /* // ngga usah katanya
            // mulai pengecekan customer ada berapa transaksi yg berjalan
            DataTable dtsub = new DataTable();
            using (Database dbsub = new Database())
            {
                dbsub.Commands.Add(dbsub.CreateCommand("usp_CekNumTransaksiBerjalanCustomer"));
                dbsub.Commands[0].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                dtsub = dbsub.Commands[0].ExecuteDataTable();
            }
            if (dtsub.Rows.Count > 0)
            {
                int ygtunai = Convert.ToInt32(dtsub.Rows[0]["TunaiBerjalan"].ToString());
                int ygkredit = Convert.ToInt32(dtsub.Rows[0]["KreditBerjalan"].ToString());
                // kalo ada data cek yg kredit ada berapa yg berjalan, yg tunai ada berapa
                if (ygkredit >= 2) // kalo yg berjalan kreditnya itu ada 2 atau lebih
                {
                    if (rbPenjualan2.Checked == true) // dan masih mau kredit lagi
                    {
                        MessageBox.Show("Masih ada 2 proses kredit yang masih berjalan, silahkan ganti mode penjualan ke tunai!");
                        rbPenjualan2.Focus();
                        return false;
                    }
                }
            }
            // akhir pengecekan customer ada berapa transaksi yg berjalan 
            */

            if ((cboJnsAngsuran.SelectedValue.ToString() == "LSG") && string.IsNullOrEmpty(cboLeasing.Text))
            {
                MessageBox.Show("Leasing belum dipilih !");
                cboLeasing.Focus();
                return false;
            }
            if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) == 0))
            {
                MessageBox.Show("Bunga tidak boleh 0 (nol) !");
                txtBunga.Focus();
                return false;
            }

            if (rbPenjualan2.Checked == true)
            {
                if (numKredit.Value == 0)
                {
                    MessageBox.Show("Cicilan tidak bisa 0 kali");
                    numKredit.Focus();
                    return false;
                }
                if (cboJnsAngsuran.SelectedValue.ToString() == "APD" && numKredit.Value > 12)
                {
                    MessageBox.Show("Bunga menurun maximal tempo hanya 12 bln");
                    numKredit.Focus();
                    return false;
                }
                else if (cboJnsAngsuran.SelectedValue.ToString() == "FLT" && numKredit.Value > 24)
                {
                    MessageBox.Show("Bunga menurun maximal tempo hanya 24 bln");
                    numKredit.Focus();
                    return false;
                }
            }
            if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 100))
            {
                MessageBox.Show("Bunga tidak boleh lebih dari 100 !");
                txtBunga.Focus();
                return false;
            }
            if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtUangMuka.Text, 0)) > Convert.ToDouble(Tools.isNull(txtTotal.Text, 0))))
            {
                MessageBox.Show("Uang Muka lebih besar dari pada harga total kesepakatan !");
                txtUangMuka.Focus();
                return false;
            }
            if ((rbPenjualan2.Checked == true) && (Convert.ToDouble(Tools.isNull(txtUangMuka.Text, 0)) == 0))
            {
                MessageBox.Show("Uang Muka tidak boleh 0 (nol) !");
                txtUangMuka.Focus();
                return false;
            }
            /*
            // kalo kredit, UM harus > 25% harga jadi
            if( Convert.ToDecimal(txtHarga.Text) > 0)
            {
                if ((rbPenjualan2.Checked == true) && ( Convert.ToDouble(Tools.isNull(txtUangMuka.Text, 0)) < ( (Convert.ToDouble(Tools.isNull(txtHarga.Text, 0))) * 25 / 100) ))
                {
                    MessageBox.Show("Uang Muka tidak boleh kurang dari 25% harga jadi !");
                    txtUangMuka.Focus();
                    return false;
                }
            }
            */
            // cek untuk kalau kredit, bentuk pembayaran (dan rekening) tidak boleh kosong
            if ((rbPenjualan2.Checked == true) && ( String.IsNullOrEmpty(cbxBentukPembayaran.SelectedItem.ToString()) ))
            {
                MessageBox.Show("Pilih bentuk pembayaran terlebih dahulu !");
                txtUangMuka.Focus();
                return false;
            }

            // cek kalau misalnya bentuk pembayarannya transfer jangan sampai kosong no rekeningnya
            if ((rbPenjualan2.Checked == true) && ( cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer" ) )
            {
                if ((lookUpRekening1.RekeningRowID == Guid.Empty || lookUpRekening1.RekeningRowID == null) || string.IsNullOrEmpty(Tools.isNull(lookUpRekening1.NamaRekening, "").ToString()))
                {
                    MessageBox.Show("Data Rekening masih kosong !");
                    txtUangMuka.Focus();
                    return false;
                }
                else
                {
                    rekeningRowID = lookUpRekening1.RekeningRowID;
                }
            }


            //  numTgl ini mau dihapus
            /*
                if ((rbPenjualan2.Checked == true) && (int.Parse(string.Format("{0:dd}", (DateTime)txtTglAwalAngs.DateValue)) != numTgl.Value))
                {
                    MessageBox.Show("Tanggal Awal Angsuran tidak sama dengan Tanggal Angsuran Bulanan !");
                    txtTglAwalAngs.Focus();
                    return;
                }
            */

            if ((rbPenjualan2.Checked == true) && ( Tools.isNull(txtTglAwalAngs.DateValue, "").ToString() == ""))
            {
                MessageBox.Show("Tolong isikan Tanggal Awal Angsuran terlebih dahulu !");
                txtTglAwalAngs.Focus();
                return false;
            }

            if ((rbPenjualan2.Checked == true) && (txtTglAwalAngs.DateValue < txtTglJual.DateValue))
            {
                MessageBox.Show("Tanggal Awal Angsuran lebih kecil dari pada Tanggal Penjualan !");
                txtTglAwalAngs.Focus();
                return false;
            }

            if ((rbPenjualan2.Checked == true) && (txtTglAwalAngs.DateValue > GlobalVar.GetServerDate))
            {
                MessageBox.Show("Tanggal Awal Angsuran tidak boleh melebihi tanggal hari ini!");
                txtTglAwalAngs.Focus();
                return false;
            }


            if ((rbPenjualan2.Checked == true) && (txtTglAwalAngs.DateValue > txtTglJual.DateValue.Value.AddMonths(1)))
            {
                MessageBox.Show("Tanggal Awal Angsuran tidak boleh lebih dari 1 bulan dari tanggal penjualan !");
                txtTglAwalAngs.Focus();
                return false;
            }

            if (((DateTime)txtTglJual.DateValue).Date < GlobalVar.GetServerDate.Date)
            {
                MessageBox.Show("Tanggal Penjualan lebih kecil dari pada Tanggal Sekarang !");
                txtTglJual.Focus();
                return false;
            }

            if(mode == FormMode.Update)
            {
                if ((isCetak1 == true) || (isCetak2 == true) || (isCetak3 == true) || (isCetak4 == true) || 
                    (isCetak5 == true) || (isCetak6 == true) || (isCetak7 == true) || (isCetak8 == true))
                {
                    MessageBox.Show("Sudah dilakukan pencetakan tidak diperkenankan diupdate !");
                    return false;
                }
            }

            if (mode == FormMode.New)
            {
                if (cekJualRugi.Checked == true)
                {
                }
                else
                {
                    Double tempHarga = 0;
                    tempHarga = lookUpStokMotor1._motor.HargaJadi + lookUpStokMotor1._motor.BiayaRep + lookUpStokMotor1._motor.BiayaTam;
                    tempHarga = tempHarga * 1.05; // dari 1.1 jadi 1.05 , karena jadinya 5 % aja batasannya
                    if (Convert.ToDouble(txtHarga.Text) < (tempHarga))
                    {
                        MessageBox.Show("Harga jual minimal 5% lebih besar dari harga beli!"); // tadinya 10%
                        txtHarga.Focus();
                        return false;
                    }
                }
            }


            return true;
        }

        private void penjualanInsert(ref Database db, ref int counterdb, Guid pengeluaranUangKomisiRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotor1._motor.RowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoNota.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtFaktur.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, txtTglJual.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, lookUpSalesman1._sales.RowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, _pejualan));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, txtHarga.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BBN", SqlDbType.Money, txtBBN.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaADM", SqlDbType.Money, txtBiayaADM.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, txtTotal.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Via", SqlDbType.VarChar, txtVia.Text));
            if (cboLeasing.Enabled == true) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cboLeasing.SelectedValue));

            if (txtTglAwalAngs.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Int, Convert.ToInt32(txtTglAwalAngs.Text.ToString().Substring(0, 2))));

            if (txtUangMuka.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, txtUangMuka.Text));
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga.Text)));
            /* ngga pake pembulatan dulu
            if (cboPembulatan.Enabled == true) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.Text)));
            */
            if (numKredit.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, numKredit.Value));
            if (txtTglAwalAngs.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngs.DateValue));
            if (txtTglAwalAngs.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, TglAkhirAngs));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, txtKeterangan.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            if (Convert.ToDouble(Tools.isNull(txtBiayaKomisi.Text, 0)) > 0)
            {
                // masukkan data biaya komisi
                db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaKomisi", SqlDbType.Money, Convert.ToDouble( Tools.isNull(txtBiayaKomisi.Text, 0).ToString() )));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranKomisiRowID", SqlDbType.UniqueIdentifier, pengeluaranUangKomisiRowID ));
            }

            counterdb++;
        }

        // masukkin ke penerimaanUM

        private void penerimaanUMInsert(ref Database db, ref int counterdb, Double decNilaiBGC, Double decNilaiNominal, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid penerimaanUMRowID, String transNKJ, String tempUraian)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUMRowID)); // rowID nya buat baru
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _rowID)); // ini dari yg dibuat di sini
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID)); // globalVar
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, transNKJ)); // buat noTrans baru
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, tempUraian)); // default Text "Pembayaran UM untuk Nopol"
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, String.Empty)); // kosongin
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMK")); // langsung 'UMK'
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglJual.DateValue)); // tanggal sekarang GlobalVar
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, null)); // kosongin
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue)); //
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal)); // dari data UM nya
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, decNilaiBGC)); // 0
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds())); // sama
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID)); // sama
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID)); // sama
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1)); // 1 -> Tunai, 2 -> Transfer
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID)); // dari lookupRekening / kosong

            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
            }
            else
            {
                // hanya insert parameter ini kalo bukan giro dan bukan titipan
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }
            counterdb++;
        }

        // Masukkin ke PenerimaanUang juga langsung
        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Double newNominal, String transNKJ, String tempUraian, String NoBuktiPenerimaan, String Jnstransaksi)
        {
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
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_MataUang_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                if (Jnstransaksi == "UM")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.UMK).ToString()));  // UM -> Uang Muka Penjualan   (28)
                }
                else if (Jnstransaksi == "ADM")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.ADM).ToString()));  // ADM -> Biaya Adm Penjualan   (30)
                }
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID)); // buat baru lagi
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoBuktiPenerimaan)); // sbeelumnya transNKJ buat baru lagi //  txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglJual.DateValue)); // TanggalPenjualan txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglJual.DateValue)); // TanggalPenjualan // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));  // sama
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID)); // sama
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID)); // sama
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID)); // sama
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, newNominal)); // dari UM nya
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, newNominal)); // dari UM nya 
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, tempUraian + "UM Penjualan | " + lookUpCustomer1._customer.NamaCustomer.Trim() + " | " + lookUpStokMotor1._motor.Nopol.Trim() ));  // Default Text Pembayaran UM untuk NoPol
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini uang muka ('K' atau 'B')
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }                   
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID)); // dari lookuprekening1
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID)); // sama
            counterdbf++;
        }


        private void penjualanUpdate(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
            if (lookUpStokMotor1._motor.RowID == Guid.Empty)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _pembRowID));
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotor1._motor.RowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, txtNoNota.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtFaktur.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJual", SqlDbType.Date, txtTglJual.DateValue));
            if ((!string.IsNullOrEmpty(lookUpCustomer1.txtNamaCustomer.Text)) && (lookUpCustomer1._customer.RowID == Guid.Empty))
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, _custRowID));
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
            }
            if ((!string.IsNullOrEmpty(lookUpSalesman1.txtNamaSales.Text)) && (lookUpSalesman1._sales.RowID == Guid.Empty))
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, _salesRowID));
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, lookUpSalesman1._sales.RowID));
            }
            if ((!string.IsNullOrEmpty(lookUpKolektor1.txtNamaKolektor.Text)) && (lookUpKolektor1._Kolektor.RowID == Guid.Empty))
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, _kolRowID));
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, _pejualan));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, txtHarga.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BBN", SqlDbType.Money, txtBBN.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaADM", SqlDbType.Money, txtBiayaADM.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HargaOff", SqlDbType.Money, txtTotal.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Via", SqlDbType.VarChar, txtVia.Text));
            if (cboLeasing.Enabled == true) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cboLeasing.SelectedValue));

            if (txtTglAwalAngs.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Int, Convert.ToInt32(txtTglAwalAngs.Text.ToString().Substring(0, 2))));

            if (txtUangMuka.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@UangMuka", SqlDbType.VarChar, txtUangMuka.Text));
            
            db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga.Text)));
            /* // ngga pake pembulatan dulu
            if (cboPembulatan.Enabled == true) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.Text)));
            */
            if (numKredit.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, numKredit.Value));
            if (txtTglAwalAngs.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtTglAwalAngs.DateValue));
            if (txtTglAwalAngs.ReadOnly == false) 
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, TglAkhirAngs));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, txtKeterangan.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            
            /*
            // update data biaya komisinya di tempat lain sekalian ke pengeluaran uang
            // update juga data biaya komisinya
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaKomisi", SqlDbType.Money, Convert.ToDouble(Tools.isNull(txtBiayaKomisi.Text, 0).ToString())));
            */

            counterdb++;
        }

        private void penjualanUpdate_UM(ref Database db, ref int counterdb, Double newNominal)
        {
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPenerimaan = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (titipan)
            }

            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_UangMuka"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, (Guid) _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@UangMuka", SqlDbType.Money, newNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.Int, (cbxBentukPembayaran.SelectedIndex + 1) ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            counterdb++;
        }

        private void penjualanUpdate_Komisi(ref Database db, ref int counterdb)
        {
            String JnsPengeluaran = string.Empty;
            Exception exDE = new DataException();
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPengeluaran = "K"; break;
                case 1: JnsPengeluaran = "B"; break;
                case 2: JnsPengeluaran = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPengeluaran = "K"; throw (exDE); break; // mestinya ngga bisa ke sini (titipan)
            }

            db.Commands.Add(db.CreateCommand("usp_Penjualan_UPDATE_Komisi"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, (Guid)_rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Komisi", SqlDbType.Money, Convert.ToDouble(txtBiayaKomisi.Text.ToString()) ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.Int, 1 )); // 1 itu kas // Bentuk Pembayarannya (cbxBentukPembayaran.SelectedIndex + 1)
            db.Commands[counterdb].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, "K" )); // selalu 'K' JnsPengeluaran
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            counterdb++;
        }

        // fungsi - fungsi untuk file attachment

        private void insertPenjualanAttachment(ref Database db, ref int counterdb, String FilePath, String FileName, String dirPath, Guid penjualan_attachmentRowID, String Keterangan)
        {
            String newFileName = FileName;
            String newFilePath = dirPath + FileName;
            // kalo di tempat attachment udah ada tapi sourcenya ngga ada, diemin aja 
            if (File.Exists(dirPath + FileName) && !File.Exists(FilePath))
            {
            }
            // kalo sourcenya ada datanya tiban aja yg di attachment
            else if (File.Exists(FilePath))
            {
                // kalo filenya udah ada
                if(File.Exists(dirPath + FileName))
                {
                    int i = 0;
                    for (i = 1; i < 99999; i++)
                    {
                        if (File.Exists(dirPath + FileName.Insert(FileName.IndexOf('.'), i.ToString())))
                        {
                        }
                        else
                        {
                            newFileName = FileName.Insert(FileName.IndexOf('.'), i.ToString());
                            newFilePath = dirPath + FileName.Insert(FileName.IndexOf('.'), i.ToString());
                            File.Copy(FilePath, dirPath + FileName.Insert(FileName.IndexOf('.'), i.ToString()), true);
                            i = int.MaxValue - 5;
                        }
                    }
                }
                else 
                {
                    // kalo blom ada, kopi aja
                    File.Copy(FilePath, dirPath + FileName, true);
                }
            }
            else
            {
                DataException de = new DataException("Data File tidak ditemukan baik di lokasi sumber file maupun di target pengkopian file!");
                throw de;
            }

            db.Commands.Add(db.CreateCommand("usp_Penjualan_Attachment_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjualan_attachmentRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@FilePath", SqlDbType.VarChar, newFilePath));
            db.Commands[counterdb].Parameters.Add(new Parameter("@FileName", SqlDbType.VarChar, newFileName));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Keterangan));
            counterdb++;
        }

        private void deletePenjualanAttachment(ref Database db, ref int counterdb, Guid penjualan_attachmentRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_Penjualan_Attachment_DELETE"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penjualan_attachmentRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _rowID));
            counterdb++;
        }

        // untuk memasukkan data biaya Komisi
        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran)
        {
            Guid _JnsTransaksiRowID = Guid.Empty, _MataUangRowID = Guid.Empty;
            // [usp_MataUang_LIST] @MataUangID varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_MataUang_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _MataUangRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.BiayaKomisi).ToString()));  // Komisi, sementara 31-Biaya Kantor dan PJ Lainnya dulu...
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            dbf.Commands.Add(dbf.CreateCommand("usp_PengeluaranUang_INSERT_SIMPLE"));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.GetServerDate)); // tglrk.DateValue 
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, string.Empty)); // txtNoAcc.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, string.Empty)); // txtNoApproval1.Text

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPengeluaran)); // mestinya pake numerator

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, DBNull.Value)); // vendor rowid saat pengeluaran Komisi dibuat null saja
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));  //  31-Biaya Kantor dan PJ Lainnya dulu...
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDecimal(txtBiayaKomisi.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Convert.ToDecimal(txtBiayaKomisi.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, " Biaya Komisi untuk | " + lookUpCustomer1._customer.NamaCustomer.Trim() + " | " + lookUpStokMotor1._motor.Nopol.Trim()));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9)); // defaultin 9

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukPengeluaran)); // mestinya selalu 'K'
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty)); // kosongin // aman untuk jurnal pengeluaran
            
            /*
            if (cbxBentukPembayaran.SelectedIndex == 0) // kalo tunai baru kas rowid
            {*/ // harusnya selalu kas
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // dari globalvar
            /*
            }
            else if (cbxBentukPembayaran.SelectedIndex == 1) // kalo transfer baru rekening rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (Guid)Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty)));
            }*/

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2)); // defaultin ke 2 (ke perusahaan)
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }


        private void penerimaanAdministrasiInsert(ref Database db, ref int counterdb, Double decNilaiBGC, Double decNilaiNominal, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid penerimaanADMRowID, String TransNKJ, String TempUraian)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanADM_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanADMRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, TransNKJ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, TempUraian));

            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, ""));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglJual.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, null));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, decNilaiBGC));

            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));

            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
            }
            else
            {
                // hanya insert parameter ini kalo bukan giro dan bukan titipan
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            }
            counterdb++;
        }

        DateTime TglAwalAngs;
        DateTime TglAkhirAngs;

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto);

            int counterdb = 0;
            int counterdbf = 0;

            Guid rekeningRowID = Guid.Empty;
            String TransNKJ = String.Empty;
            String tempUraian = String.Empty;
            String dirPath;
            int rowGV;
            Guid pengeluaranUangKomisiRowID = Guid.Empty;
            try
            {
                if (ValidateSave(ref rekeningRowID))
                {
                }
                else
                {
                    return;
                }

                if (rbPenjualan1.Checked == true)
                {
                    _pejualan = "T";
                }
                else
                {
                    _pejualan = "K";
                    int jmlKredit = int.Parse(numKredit.Value.ToString());
                    TglAwalAngs = (DateTime)txtTglAwalAngs.DateValue;
                    TglAkhirAngs = TglAwalAngs.AddMonths(jmlKredit);
                }
                
                this.Cursor = Cursors.WaitCursor;
                switch (mode)
                {
                    case FormMode.New :
                        txtFaktur.Text = Numerator.NextNumber("NFJ");
                        txtNoNota.Text = Numerator.NextNumber("NNJ"); // no nota ini nanti jadi nama folder untuk menyimpan attachment nya
                        
                        if (Convert.ToDouble(Tools.isNull(txtBiayaKomisi.Text, 0)) > 0)
                        {
                            pengeluaranUangKomisiRowID = Guid.NewGuid();
                        }

                        penjualanInsert(ref db, ref counterdb, pengeluaranUangKomisiRowID);
                        if (dgFile.Rows.Count > 0)
                        {
                            dirPath = GlobalVar.PJLAttachPath + "\\" + txtNoNota.Text + "\\";
                            // mulai looping di sini untuk menyiapkan query untuk memasukkan data attachment
                            if (Directory.Exists(dirPath))
                            {
                            }
                            else
                            {
                                Directory.CreateDirectory(dirPath);
                            }

                            rowGV = 0;
                            for (rowGV = 0; rowGV < dgFile.Rows.Count; rowGV++)
                            {
                                insertPenjualanAttachment(ref db, ref counterdb, dgFile.Rows[rowGV].Cells["FilePath"].Value.ToString(), dgFile.Rows[rowGV].Cells["FileName"].Value.ToString(),
                                                          dirPath, new Guid(Tools.isNull(dgFile.Rows[rowGV].Cells["RowID"].Value, Guid.Empty).ToString()), dgFile.Rows[rowGV].Cells["Keterangan"].Value.ToString());
                            }
                        }
                        // setelah melakukan insert data penjualan langsung masukkan juga data Uang Muka(jika ada)
                        if ( rbPenjualan2.Checked == true && Convert.ToDouble(txtUangMuka.Text.ToString()) > 0)
                        {
                            // buat rowID untuk penerimaanUM dan penerimaanUang
                            Guid newPenerimaanUM = Guid.NewGuid();
                            Guid newPenerimaanUang = Guid.NewGuid();

                            // buat no Bukti PenerimaanUang baru
                            String tempBentukPenerimaan = "";
                            TransNKJ = "K" + Numerator.NextNumber("NKJ");

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
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            tempUraian = "Pembayaran Uang Muka untuk NoPol " + lookUpStokMotor1._motor.Nopol;
                            // lakukan penambahan data ke penerimaanUM dan penerimaanUang
                            penerimaanUMInsert(ref db, ref counterdb, 0, Convert.ToDouble(txtUangMuka.Text.ToString()), rekeningRowID, newPenerimaanUang, newPenerimaanUM, TransNKJ, tempUraian);
                            penerimaanUangInsert(ref dbf, ref counterdbf, rekeningRowID, newPenerimaanUang, Convert.ToDouble(txtUangMuka.Text.ToString()), TransNKJ, tempUraian, NoTransPenerimaan, "UM");
                        }

                        // BAGIAN ADM --> ini selalu anggap dibayarkan
                        if (txtBiayaADM.GetDoubleValue > 0) // cbxADM.Checked == true && 
                        {
                            // buat rowID untuk penerimaanADM dan penerimaanUang
                            Guid newPenerimaanADM = Guid.NewGuid();
                            Guid newPenerimaanUang = Guid.NewGuid();

                            // buat no Bukti PenerimaanUang baru
                            String tempBentukPenerimaan = "";
                            // no kwitansi baru, untuk yg administrasi
                            TransNKJ = "K" + Numerator.NextNumber("NKJ");

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
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);


                            // lakukan penambahan data ke penerimaanADM dan penerimaanUang
                            tempUraian = "Pembayaran Administrasi untuk NoPol " + lookUpStokMotor1._motor.Nopol;
                            penerimaanAdministrasiInsert(ref db, ref counterdb, 0, Convert.ToDouble(txtBiayaADM.Text.ToString()), rekeningRowID, newPenerimaanUang, newPenerimaanADM, TransNKJ, tempUraian);
                            penerimaanUangInsert(ref dbf, ref counterdbf, rekeningRowID, newPenerimaanUang, Convert.ToDouble(txtBiayaADM.Text.ToString()), TransNKJ, tempUraian, NoTransPenerimaan, "ADM");
                        }

                        // juga kalau ada biaya komisi, itu mesti dibuatkan data pengeluaran uang
                        if (Convert.ToDouble(Tools.isNull(txtBiayaKomisi.Text, 0)) > 0)
                        {
                            // kalau komisi dianggap kas terus
                            String tempBentukPengeluaran = "K";

                            // di bawah ini itu ngebentuk Bukti Uang Keluar untuk komisi!!!
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPengeluaran + "K/" +
                                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                            // -- !!!!!!!!!!!!!!!!!!!! tadinya pengeluaranUangRowID itu newGuid !!!, mesti cepet2 dibenerin!!!
                            pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranUangKomisiRowID, tempBentukPengeluaran, NoTransPengeluaran); // ngga kirim vendor rowid saat komisi
                        }

                        break;

                    case FormMode.Update:
                        penjualanUpdate(ref db, ref counterdb);
                        
                        // pas update hapus semua data attachment sebelumnya
                        // bagian update, isikan dgFilenya dengan data attachment sebelumnya
                        DataTable _dtFile = new DataTable();
                        using (Database dbsub = new Database())
                        {
                            dbsub.Commands.Add(db.CreateCommand("usp_Penjualan_Attachment_LIST"));
                            dbsub.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _rowID));
                            _dtFile = dbsub.Commands[0].ExecuteDataTable();
                        }
                        int i = 0;
                        for (i = 0; i < _dtFile.Rows.Count; i++)
                        {
                            deletePenjualanAttachment(ref db, ref counterdb, (Guid)_dtFile.Rows[i]["RowID"]);
                        }

                        // lakukan insert ulang data attachment sesuai yang di gridview
                        if (dgFile.Rows.Count > 0)
                        {
                            dirPath = GlobalVar.PJLAttachPath + "\\" + txtNoNota.Text + "\\";
                            // mulai looping di sini untuk menyiapkan query untuk memasukkan data attachment
                            if (Directory.Exists(dirPath))
                            {
                            }
                            else
                            {
                                Directory.CreateDirectory(dirPath);
                            }

                            rowGV = 0;
                            for (rowGV = 0; rowGV < dgFile.Rows.Count; rowGV++)
                            {
                                insertPenjualanAttachment(ref db, ref counterdb, dgFile.Rows[rowGV].Cells["FilePath"].Value.ToString(), dgFile.Rows[rowGV].Cells["FileName"].Value.ToString(),
                                                          dirPath, new Guid(Tools.isNull(dgFile.Rows[rowGV].Cells["RowID"].Value, Guid.Empty).ToString()), dgFile.Rows[rowGV].Cells["Keterangan"].Value.ToString());
                            }
                        }
                        // update juga ke penerimaanUM dan penerimaanUang
                        penjualanUpdate_UM(ref db, ref counterdb, Convert.ToDouble(txtUangMuka.Text.ToString()) );
                        // update juga komisi nya ke pengeluaran uang
                        penjualanUpdate_Komisi(ref db, ref counterdb);

                        break;
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
                MessageBox.Show("Data berhasil diproses");
                this.Close();
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                dbf.RollbackTransaction();
                MessageBox.Show("Data gagal diupdate !\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // numTgl mau dihapus, ambil dari txtTglAwalAngs
        /*
        private void numTgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        */

        #region moreHandler
        private void txtTglJual_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void rbPenjualan1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpStokMotor1.txtNopol.Focus();
            }
        }

        private void rbPenjualan2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpStokMotor1.txtNopol.Focus();
            }
        }

        private void lookUpCustomer1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpSalesman1.txtNamaSales.Focus();
            }
        }

        private void lookUpStokMotor1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpCustomer1.txtNamaCustomer.Focus();
            }
        }

        private void lookUpSalesman1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                lookUpKolektor1.txtNamaKolektor.Focus();
            }
        }

        private void lookUpKolektor1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                cboJnsAngsuran.Focus();
            }
        }

        private void cboJnsAngsuran_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboLeasing_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtVia_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtKeterangan.Focus();
            }
        }

        private void txtKeterangan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMataUang_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
        
        private void txtHarga_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBBN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBiayaADM_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtTglAwalAngs.Focus();
            }
        }

        private void txtTglAwalAngs_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtUangMuka_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBunga_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboPembulatan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void numKredit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        // numTgl mau dihapus, ambil dari txtTglAwalAngs
        /*
        private void numTgl_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
        */

        private void txtBunga_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (txtBunga.ReadOnly == true)
            {
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.BungaAngsuran), "Bunga Angsuran.\nAnda membutuhkan PIN untuk merubah Bunga Angsuran !");
                if (GlobalVar.pinResult == false) { return; }
            }

            txtBunga.ReadOnly = false;
        }

        private void lookUpStokMotor1_Load(object sender, EventArgs e)
        {

        }
            #endregion

        private void numKredit_ValueChanged(object sender, EventArgs e)
        {
            if(rbPenjualan1.Checked == true)
            {
                numKredit.Value = 0;
            }
            urusSisaPokok();
            urusJmlAngs();
        }

        private void cmdUbahBunga_Click(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (txtBunga.ReadOnly == true)
            {
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, 
                            Convert.ToInt32(PinId.ModulId.BungaAngsuran), 
                            "Bunga Angsuran.\nAnda membutuhkan PIN untuk merubah Bunga Angsuran !", _rowID);

                if (GlobalVar.pinResult == false) { return; }
            }
            txtBunga.Enabled = true;
            txtBunga.ReadOnly = false;
            txtBunga.Focus();
        }

        private void txtBunga_TextChanged(object sender, EventArgs e)
        {
            urusSisaPokok();
            urusJmlAngs();
        }

        private void txtBunga_Leave(object sender, EventArgs e)
        {
            txtBunga.Enabled = false;
            txtBunga.ReadOnly = true;
            if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 100)
            {
                MessageBox.Show("Bunga tidak boleh melebihi 100%!");
                txtBunga.Text = "100.00";
                txtBunga.Focus();
            }
            if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) < 0)
            {
                MessageBox.Show("Bunga tidak boleh kurang dari 0%!");
                txtBunga.Text = "0.00";
                txtBunga.Focus();
            }

        }

        private void cekJualRugi_CheckedChanged(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = GlobalVar.GetServerDate;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            if (cekJualRugi.Checked == true)
            {
                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting,
                          Convert.ToInt32(PinId.ModulId.JualRugi),
                          "Jual Rugi.\nAnda membutuhkan PIN untuk melakukan penjualan dengan harga di bawah ketentuan !", _rowID);

                if (GlobalVar.pinResult == false) 
                {
                    cekJualRugi.Checked = false;
                    return; 
                }
            }
        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                lookUpRekening1.Enabled = true;
                lookUpRekening1.Visible = true;
                lookUpRekening1.NamaRekening = "";
                lookUpRekening1.RekeningRowID = Guid.Empty;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai")
            {
                lookUpRekening1.Enabled = false;
                lookUpRekening1.Visible = false;
                lookUpRekening1.NamaRekening = "";
                lookUpRekening1.RekeningRowID = Guid.Empty;
            }
        }

        private void txtTglAwalAngs_TextChanged(object sender, EventArgs e)
        {

        }

        private void lookUpKolektor1_Enter(object sender, EventArgs e)
        {
            // lakukan cek kalau keluar dari control LookUpCustomer supaya bisa isi ke lookUpKolektornya
            UpdateLookUpKolektor();
        }

        private void lookUpCustomer1_Leave(object sender, EventArgs e)
        {
            // lakukan cek kalau keluar dari control LookUpCustomer supaya bisa isi ke lookUpKolektornya
            UpdateLookUpKolektor();
            if (lookUpCustomer1._customer.RowID == null || lookUpCustomer1._customer.RowID == Guid.Empty)
            {
                MessageBox.Show("Data Customer belum terpilih! Pastikan sudah dilakukan pencarian data!");
            }
        }

        private void UpdateLookUpKolektor()
        {
            // kalo lookUpKolektornya dapat fokus, ATAU ada event Leave dari lookupCustomer
            // cek ke lookupCustomer, kalau udah ada data customer, 
            // usahakan supaya bisa keisi dengan data kolektor pertama yang ditemukan yg sesuai dengan KecamatanDom nya si customer
            
            if (lookUpCustomer1._customer.RowID != null && lookUpCustomer1._customer.RowID != Guid.Empty)
            {
                // berarti ada nih data customernya
                Guid CustomerRowID = lookUpCustomer1._customer.RowID;
                
                // ambil data KecamatanDom si Customer
                DataTable dummy = new DataTable();
                using (Database dbsub = new Database(GlobalVar.DBShowroom))
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_Customer_LIST"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, CustomerRowID));
                    dummy = dbsub.Commands[0].ExecuteDataTable();
                }

                if (dummy.Rows.Count > 0)
                {
                    // kalo ada datanya ambil KecamatanDom nya buat ambil data kolektor yg sesuai
                    String KecamatanDom = dummy.Rows[0]["KecamatanDom"].ToString();

                    // dengan kecamatandom ini nanti ke tabel Area->AreaKolektor->Kolektor, 
                    // untuk ambil 1 data kolektor pertama

                    DataTable dummy2 = new DataTable();
                    using (Database dbsub2 = new Database(GlobalVar.DBShowroom))
                    {
                        dbsub2.Commands.Add(dbsub2.CreateCommand("usp_Kolektor_GETOne_ByKecamatan"));
                        dbsub2.Commands[0].Parameters.Add(new Parameter("@Kecamatan", SqlDbType.VarChar, KecamatanDom));
                        dummy2 = dbsub2.Commands[0].ExecuteDataTable();
                    }

                    Guid KolektorRowID = Guid.Empty;
                    if (dummy2.Rows.Count > 0)
                    {
                        KolektorRowID = new Guid(Tools.isNull(dummy2.Rows[0]["KolektorRowID"], Guid.Empty).ToString());
                    }

                    // ambil nama kolektornya 
                    DataTable dummy3 = new DataTable();
                    using (Database dbsub3 = new Database(GlobalVar.DBShowroom))
                    {
                        dbsub3.Commands.Add(dbsub3.CreateCommand("usp_Kolektor_LIST"));
                        dbsub3.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, KolektorRowID));
                        dummy3 = dbsub3.Commands[0].ExecuteDataTable();
                    }

                    if(dummy3.Rows.Count > 0)
                    {
                        lookUpKolektor1._Kolektor.RowID = (Guid) dummy3.Rows[0]["RowID"];
                        lookUpKolektor1._Kolektor.NamaKolektor = dummy3.Rows[0]["Nama"].ToString();
                        lookUpKolektor1.txtNamaKolektor.Text = dummy3.Rows[0]["Nama"].ToString();
                    }
                }
            }
        }

        private void lookUpStokMotor1_Leave(object sender, EventArgs e)
        {
            if (lookUpStokMotor1._motor.RowID == null || lookUpStokMotor1._motor.RowID == Guid.Empty)
            {
                MessageBox.Show("Data Motor masih belum terisi! Pastikan sudah melakukan pencarian data terlebih dahulu!");
            }
            /* // ngga dipake dulu fitur ini
            // cek ada udah kepilih belum motornya
            if (lookUpStokMotor1._motor.RowID == null || lookUpStokMotor1._motor.RowID == Guid.Empty)
            {
                // kalo masih kosong gpp
            }
            else
            {
                // kalo ngga kosong cek ke data pembelian ambil tanggalnya bandingin sama tanggal penjualan
                String tempNoPol = lookUpStokMotor1._motor.Nopol;
                
                DataTable dummy = new DataTable();
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Check_TglPembelian_byNoPol"));
                    db.Commands[0].Parameters.Add(new Parameter("@Nopol", SqlDbType.VarChar, tempNoPol));
                    dummy = db.Commands[0].ExecuteDataTable();
                }
                if (dummy.Rows.Count > 0)
                {
                    int tempAda = Convert.ToInt32(Tools.isNull(dummy.Rows[0]["Ada"], 0).ToString());
                    if (tempAda == 0)
                    {
                        // berarti data motornya udah kejual dong!!!
                        MessageBox.Show("Data motor yg ditemukan sudah terjual, tidak dapat melakukan penjualan untuk motor ini.");
                        lookUpStokMotor1.Focus();
                    }
                    else
                    {
                        // cek tgl beli yg didapat sama tgl penjualannya
                        DateTime tempTglBeli = Convert.ToDateTime( Tools.isNull(dummy.Rows[0]["TglBeli"], DateTime.MinValue).ToString() );
                        if (tempTglBeli == DateTime.MinValue)
                        {
                            MessageBox.Show("Data Tanggal Pembelian Motor tidak didapatkan, silahkan ganti motor.");
                            lookUpStokMotor1.Focus();
                        }
                        else if(tempTglBeli.Date == txtTglJual.DateValue)
                        {
                            MessageBox.Show("Data Tanggal Pembelian Motor sama dengan tanggal penjualan, tidak diperbolehkan melakukan penjualan, silahkan pilih motor lain.");
                            lookUpStokMotor1.Focus();
                        }
                        else
                        {
                        }
                    }
                }
            }
            */
        }

        private void cmdAddFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String filePath = openFileDialog1.FileName;
            String fileName = openFileDialog1.SafeFileName;

            try
            {
                Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File gambar tidak dapat diproses!");
                return;
            }

            if (    fileName.ToLower().EndsWith(".exe") || fileName.ToLower().EndsWith( ".ws") || fileName.ToLower().EndsWith(".wsf") || fileName.ToLower().EndsWith(".bat")
                 || fileName.ToLower().EndsWith(".com") || fileName.ToLower().EndsWith(".cmd") || fileName.ToLower().EndsWith(".inf") || fileName.ToLower().EndsWith(".ins")
                 || fileName.ToLower().EndsWith(".msi") || fileName.ToLower().EndsWith(".msp") || fileName.ToLower().EndsWith(".reg") || fileName.ToLower().EndsWith(".rgs"))
            {
                MessageBox.Show("Tidak boleh mengupload data aplikasi!");
            }
            else
            {
                int i;
                bool isOK = true, isEXE = false;
                for (i = 0; i < dgFile.Rows.Count; i++)
                {
                    if (dgFile.Rows[i].Cells["FileName"].Value.ToString() == fileName)
                    {
                        isOK = false;
                    }
                }

                if (isOK == false)
                {
                    MessageBox.Show("File dengan nama sama terpilih, silahkan ganti atau ubah nama file terlebih dahulu.");
                }
                else if (File.Exists(filePath))
                {
                    // kalo filenya ada, masukkin ke gridview sementara, kalau bisa path sama filenamenya dipisah
                    int lastrow = dgFile.Rows.Add();
                    dgFile.Rows[lastrow].Cells["FilePath"].Value = filePath;
                    dgFile.Rows[lastrow].Cells["FileName"].Value = fileName;
                    dgFile.Rows[lastrow].Cells["Keterangan"].Value = "Keterangan File";
                    dgFile.Rows[lastrow].Cells["RowID"].Value = Guid.NewGuid();
                }
                else
                {
                    MessageBox.Show("Tidak ada data terpilih.");
                }
            }
        }

        private void cmdDeleteFile_Click(object sender, EventArgs e)
        {
            if (dgFile.SelectedCells.Count > 0)
            {
                var confirmResult = MessageBox.Show("Yakin melakukan penghapusan daftar data file yang ingin diupload? Proses ini tidak dapat dibatalkan!",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // ambil row keberapa yang dipilih
                    int rowidx = dgFile.SelectedCells[0].OwningRow.Index;
                    dgFile.Rows.RemoveAt(rowidx);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu!");
            }
        }

        private void urusSisaPokok()
        {
            // dari sp nya
            // (ISNULL(@HargaJadi,0) + ISNULL(@BBN,0)) - ISNULL(@UangMuka,0) -> ini itu piutang pokok
            // (txtHarga + txtBBN) - txtUangMuka
            bool tempresult = false;
            double tempdump = 0;
            double temphargajadi;
            double tempBBN;
            double tempUM;

            tempresult = Double.TryParse( txtHarga.Text, out tempdump);
            if(tempresult)
            {
                temphargajadi = tempdump;
            }
            else
            {
                temphargajadi = 0;
            }
            tempresult = Double.TryParse( txtBBN.Text, out tempdump);
            if(tempresult)
            {
                tempBBN = tempdump;
            }
            else
            {
                tempBBN = 0;
            }
            tempresult = Double.TryParse( txtUangMuka.Text, out tempdump);
            if(tempresult)
            {
                tempUM = tempdump;
            }
            else
            {
                tempUM = 0;
            }
            txtSisaPokok.Text = ((temphargajadi + tempBBN) - tempUM).ToString();
        }

        private void urusJmlAngs()
        {
            // dari sp nya
            // FLT -> pokok = SisaPokok / JmlAngsuran
            //        bunga = SisaPokok * (%Bunga / 100)
            //        angs  = pokok + bunga
            // APD -> pokok = SisaPokok / JmlAngsuran
            //        bunga = SisaPokok * (%Bunga / 100)
            //        angs  = pokok + bunga
            // untuk awalan FLT dan APD itu perhitungannya mirip

            if (rbPenjualan2.Checked == true) // kalau kredit
            {
                int tempTempo = Convert.ToInt32(Tools.isNull(numKredit.Value, 1));
                double tempPersenBunga = Convert.ToDouble(Tools.isNull(txtBunga.Text, "0"));
                if (tempTempo == 0 || tempPersenBunga == 0)
                {
                    txtJmlAngsuran.Text = "0";
                    txtBungaBulanan.Text = "0";
                }
                else
                {
                    double tempSisaPokok = Convert.ToDouble(Tools.isNull(txtSisaPokok.Text, "0"));
                    double tempBunga = tempSisaPokok * (tempPersenBunga / 100);
                    double tempPokok = tempSisaPokok / tempTempo;
                    double tempAngs = tempBunga + tempPokok;
                    txtBungaBulanan.Text = tempBunga.ToString();
                    txtJmlAngsuran.Text = tempAngs.ToString();
                }
                if (cboJnsAngsuran.SelectedValue.ToString() == "APD")
                {
                    txtBungaBulanan.Text = "0";
                }
            }
            else
            {
                txtBungaBulanan.Text = "0";
                txtJmlAngsuran.Text = "0";
            }
        }

        private void txtUangMuka_TextChanged(object sender, EventArgs e)
        {
            urusSisaPokok();
            urusJmlAngs();
        }

        private void txtBiayaKomisi_TextChanged(object sender, EventArgs e)
        {
            urusSisaPokok();
            urusJmlAngs();
        }

        private void lookUpSalesman1_Leave(object sender, EventArgs e)
        {
            if (lookUpSalesman1._sales.RowID == null || lookUpSalesman1._sales.RowID == Guid.Empty)
            {
                MessageBox.Show("Data Salesman masih belum terisi! Pastikan sudah melakukan pencarian data terlebih dahulu!");
            }
        }

        private void lookUpKolektor1_Leave(object sender, EventArgs e)
        {
            if (lookUpKolektor1._Kolektor.RowID == null || lookUpKolektor1._Kolektor.RowID == Guid.Empty)
            {
                MessageBox.Show("Data Kolektor belum terpilih! Pastikan sudah dilakukan pencarian data!");
            }
        }

        private void lookUpCustomer1_SelectData(object sender, EventArgs e)
        {
            DataTable dtcek = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    List<Parameter> prm = new List<Parameter>();
                    prm.Add(new Parameter("@CustRowID", SqlDbType.UniqueIdentifier, lookUpCustomer1._customer.RowID));
                    Command cmd = db.CreateCommand("usp_cek_blcaklist");
                    cmd.Parameters = prm;
                    dtcek = cmd.ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtcek.Rows.Count > 0)
            {
                MessageBox.Show("Customer ada di daftar Blacklist !! Silahkan Konfirmasi Pusat untuk UnBlackList");
                lookUpCustomer1.SetByRowID(Guid.Empty);
                lookUpCustomer1._customer.RowID = Guid.Empty;
                return;
            }
        }



    }
}
