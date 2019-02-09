using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPenerimaanUangUpdate : ISA.Controls.BaseForm
    {
        DataTable dtCabang, dtCabangPengirim = new DataTable();
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        enum enumReceivedFrom { Perusahaan, Cabang, Vendor };
        Guid _rowID, _groupRowID;
        Guid _HIRowID = Guid.Empty;
        DateTime _tanggal;
        Guid _JournalRowiD = Guid.Empty;
        bool _isGroup = false;
        int key;
        Double KursValueMataUang = 0;
        String ComboCabangID;
        Guid RowID_4Forward = Guid.Empty;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        DateTime _today = GlobalVar.GetServerDate;
        int IsRegex;
        string[,] _aBentuk = { { "K", "Kas" }, { "B", "Bank" }, { "G", "Giro" } };
        string _bentukPenerimaan = "K";

        DataTable dt;

        bool _PLL = false;
        SqlGuid _HeaderID = SqlGuid.Null;
        Guid _GPLL = new Guid("579FF9B4-8E53-49D6-84DC-5293004E3ED7");

        String _JenisTransaksi = "";

        Guid _pengeluaranUangRowID;
        double _nominalPengeluaranUang;
        string _pengUang = "";

        public frmPenerimaanUangUpdate()
        {
            InitializeComponent();
        }

        public frmPenerimaanUangUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPenerimaanUangUpdate(Form caller, Guid pengeluaranUangRowID, double nominal)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _pengeluaranUangRowID = pengeluaranUangRowID;
            _nominalPengeluaranUang = nominal;
            _pengUang = "Koreksi";
        }

        public frmPenerimaanUangUpdate(Form caller, String JenisTransaksi)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _JenisTransaksi = JenisTransaksi;
            //if (_JenisTransaksi != "") cboJnsTransaksi.SelectedValue = "D35058D1-2A51-4AC1-9A32-947190427C81";
        }

        public frmPenerimaanUangUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        public frmPenerimaanUangUpdate(Form caller, Guid HeaderID_, bool PLL_)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _PLL = true;
            _HeaderID = HeaderID_;
        }

        public frmPenerimaanUangUpdate(Form caller, Guid RowiD_, Guid HeaderID_, bool PLL_)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            _PLL = true;
            _HeaderID = HeaderID_;
            _rowID = RowiD_;
        }

        private void TabIndexRadioButton(String rdo)
        {
            switch (rdo)
            {
                case "K":
                    {
                        cboKas.TabIndex = 16; // 14
                        pnlKas.TabIndex = 17; // 13
                        cmdSAVE.TabIndex = 18;
                        cmdCLOSE.TabIndex = 19;

                        break;
                    }
                case "B":
                    {
                        cboBank2.TabIndex = 16;//13
                        pnlBank.TabIndex = 17;//14
                        txtNoGiro.TabIndex = 18;
                        txtKota.TabIndex = 19;
                        dtJTGiro.TabIndex = 20;
                        cmdSAVE.TabIndex = 21;
                        cmdCLOSE.TabIndex = 22;
                        break;
                    }
                case "G":
                    {
                        pnlGiro.TabIndex = 16;
                        lookUpRekening1.TabIndex = 17;
                        cmdSAVE.TabIndex = 18;
                        cmdCLOSE.TabIndex = 19;
                        break;
                    }
            }

        }

        private void rdoKas_CheckedChanged(object sender, EventArgs e)
        {
            if (grpJnsPenerimaan.Enabled == true)
            {
                _bentukPenerimaan = "K";
                show_panelPenerimaan();
            }

            TabIndexRadioButton("K");



        }

        private void rdoBank_CheckedChanged(object sender, EventArgs e)
        {
            if (grpJnsPenerimaan.Enabled == true)
            {
                _bentukPenerimaan = "B";
                show_panelPenerimaan();
            }

            TabIndexRadioButton("B");
        }

        private void rdoGiro_CheckedChanged(object sender, EventArgs e)
        {
            if (grpJnsPenerimaan.Enabled == true)
            {
                _bentukPenerimaan = "G";
                show_panelPenerimaan();
            }

            TabIndexRadioButton("G");
        }

        private void frmPenerimaanUangUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                cboUnitUsaha.SelectedIndex = 0;

                fcbo.fillComboPerusahaan(cboPerusahaan);
                fcbo.fillComboPerusahaanNonPTCabangIDLokal(cboPerusahaanDari);
                fcbo.fillComboMataUang(cboMataUang);
                fcbo.fillComboBank(cboBank2, 2);
                fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                if (cboKas.Items.Count > 1)
                {
                    cboKas.SelectedIndex = 1;
                }
                fcbo.fillComboCabang(cboCabangDari);

                fcbo.fillComboCabangNonCabangIDLocal(cboCabangDari, GlobalVar.PerusahaanRowID, GlobalVar.CabangID);
                fcbo.fillComboCabang(cboCabangKe, GlobalVar.PerusahaanRowID, GlobalVar.CabangID);
                fcbo.fillComboJnsTransaksi(cboJnsTransaksi);

                pnlKas.Left = 7;
                pnlKas.Top = 220;

                pnlBank.Left = 7;
                pnlBank.Top = 220;

                pnlGiro.Left = 7;
                pnlGiro.Top = 220;

                RefreshData();


                if (_PLL)
                {
                    cboPenerimaanDari.SelectedItem = "Dari PT";
                    cboPenerimaanDari.Enabled = false;

                    if (formMode == enumFormMode.New)
                    {
                        cboPerusahaanDari.SelectedValue = GlobalVar.PerusahaanRowID;
                        txtTanggal.Enabled = true;
                        txtTanggal.ReadOnly = false;
                    }
                    cboPerusahaanDari.Enabled = false;
                    cboJnsTransaksi.SelectedValue = _GPLL;
                    cboJnsTransaksi.Enabled = false;
                }
                else if (GlobalVar.IsNewDNKN && formMode == enumFormMode.New)
                {
                    // fcbo.fillComboCabangNonCabangIDLogin(cboCabangKe, true);
                    fcbo.fillComboPerusahaan(cboPerusahaanDari, true);

                    cboPenerimaanDari.SelectedItem = "Dari PT";
                    if( cboPerusahaanDari.Items.Count > 1 ) cboPerusahaanDari.SelectedIndex = 1;

                }



                if (formMode == enumFormMode.Update)
                {
                    // kalau lagi update, hanya JnsTransaksi aja yg boleh diubah2
                    disableWhenUpdating();
                    // hanya jnstransaksi yg di enable
                    cboJnsTransaksi.Enabled = true;
                }

                //Piutang Belum Iden
                if (_JenisTransaksi == "PiutangLsgBelumIden") cboJnsTransaksi.SelectedValue = "d35058d1-2a51-4ac1-9a32-947190427c81";

                if (_pengUang == "Koreksi")
                {
                    cboPenerimaanDari.Enabled = false;
                    cboPerusahaanDari.Enabled = false;
                    cboJnsTransaksi.Enabled = false;
                    cboJnsTransaksi.Text = "Pembayaran MPM";
                    txtNominal.Text = _nominalPengeluaranUang.ToString();
                    txtNominalRp.Text = _nominalPengeluaranUang.ToString();
                    txtUraian.Text = "Koreksi Pengeluaran Uang";
                    rdoBank.Checked = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void disableWhenUpdating()
        {
            txtNoBukti.Enabled = false;
            txtTanggal.Enabled = false;
            txttglRK.Enabled = false;
            lookUpRekening1.Enabled = false;

            cboPerusahaan.Enabled = false;
            lookUpRekening1.Enabled = false;
            cboPerusahaanDari.Enabled = false;
            cboCabangKe.Enabled = false;

            cboCabangDari.Enabled = false;
            cboMataUang.Enabled = false;


            // txtUraian.Enabled = false; // pengen bisa ubah uraian

            txtNominal.Enabled = false;
            txtKota.Enabled = false;
            cboBank2.Enabled = false;
            txtNoGiro.Enabled = false;
            dtJTGiro.Enabled = false;
            cboPenerimaanDari.Enabled = false;

            cboPerusahaanDari.Enabled = false;
            cboCabangDari.Enabled = false;

            cboKas.Enabled = false;
            lookUpRekening1.Enabled = false;
            cboBank2.Enabled = false;
            
            // khusus ini dibebasin 
            // cboJnsTransaksi.Enabled = false;

            rdoBank.Enabled = false;
            rdoKas.Enabled = false;
            rdoGiro.Enabled = false;

            cboPerusahaanDari.Enabled = false;
            cboPenerimaanDari.Enabled = false;
            
            txtIden.Enabled = false;
        }


        private void LoadCboTransaksi()
        {
            if (cboPenerimaanDari.SelectedIndex == 0)
            {
                if (cboPerusahaanDari.SelectedIndex != 0)
                {
                    if (cboPerusahaanDari.Text.ToString().Equals(cboPerusahaan.Text.ToString()))
                    {
                        fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, false);
                    }
                    else
                    {
                        fcbo.fillComboJnsTransaksiDIFFER_Penerimaan(cboJnsTransaksi, false);
                    }

                }
            }
            if (cboPenerimaanDari.SelectedIndex == 1)
            {
                if (!(cboCabangDari.Text.ToString().Equals(cboCabangKe.Text.ToString())))
                {
                    fcbo.fillComboJnsTransaksiDIFFER_Penerimaan(cboJnsTransaksi, false);
                }
            }
        }


        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    _groupRowID = (Guid)Tools.isNull(dt.Rows[0]["GroupRowID"], Guid.Empty);
                    txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                    txtNoBukti.Enabled = false;
                    _tanggal = (DateTime)Tools.isNull(dt.Rows[0]["Tanggal"], "");
                    txtTanggal.DateValue = _tanggal;
                    DateTime _tglrk = (DateTime)Tools.isNull(dt.Rows[0]["TanggalRK"], "");
                    if (_tglrk != null)
                    {
                        txttglRK.DateValue = _tglrk;
                    }


                    _HIRowID = (Guid)Tools.isNull(dt.Rows[0]["HIRowID"], Guid.Empty);
                    _JournalRowiD = (Guid)Tools.isNull(dt.Rows[0]["JournalRowID"], Guid.Empty);
                    //ValidasiTanggalTransaksi(_tanggal, _HIRowID, _JournalRowiD);

                    String MataUangID = (String)Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString(); ;
                    lookUpRekening1.MataUangIDRekening = MataUangID;
                    txtNoApproval.Text = Tools.isNull(dt.Rows[0]["NoApproval"], "").ToString();
                    Guid PTRowID = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanKeRowID"], Guid.Empty);
                    cboPerusahaan.SelectedValue = PTRowID;
                    lookUpRekening1.PerusahaanID = PTRowID;
                    Guid PTRowIDDari = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanDariRowID"], Guid.Empty);
                    cboPerusahaanDari.SelectedValue = PTRowIDDari;
                    cboCabangKe.SelectedValue = Tools.isNull(dt.Rows[0]["CabangKe"], "").ToString();

                    fcbo.fillComboCabang(cboCabangDari);

                    cboCabangDari.SelectedValue = Tools.isNull(dt.Rows[0]["CabangDari"], "").ToString(); ;
                    Guid RowIDMataUang = (Guid)Tools.isNull(dt.Rows[0]["MataUangRowID"], Guid.Empty);
                    cboMataUang.SelectedValue = RowIDMataUang;

                    txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
                    txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["KotaGiro"], "").ToString();
                    //cboBank1.SelectedValue = Tools.isNull(dt.Rows[0]["BankRowID"], Guid.Empty);
                    Guid bankRowID = (Guid)Tools.isNull(dt.Rows[0]["BankRowID"], Guid.Empty);
                    cboBank2.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["BankRowID"], Guid.Empty);
                    //cboRekening1.SelectedValue = Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                    //lookUpRekening1.SetRekeningRowID((Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty));
                    txtNoGiro.Text = Tools.isNull(dt.Rows[0]["NoCekGiro"], "").ToString();
                    if (dt.Rows[0]["TanggalGiroCair"].ToString() != "") dtJTGiro.DateValue = DateTime.Parse(dt.Rows[0]["TanggalGiroCair"].ToString());
                    _bentukPenerimaan = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();
                    int CboPenriDari = int.Parse(dt.Rows[0]["PenerimaanDari"].ToString());
                    cboPenerimaanDari.SelectedIndex = CboPenriDari;//= int.Parse(dt.Rows[0]["PenerimaanDari"].ToString());

                    if (CboPenriDari == 0) { cboPerusahaanDari.Visible = true; } else { cboCabangDari.Visible = true; }


                    if (_bentukPenerimaan == "K") cboKas.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                    if (_bentukPenerimaan == "B") lookUpRekening1.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                    if (_bentukPenerimaan == "G") cboBank2.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["BankRowID"], Guid.Empty);
                    _isGroup = (bool)Tools.isNull(dt.Rows[0]["IsGroup"], false);
                    //grpJnsPenerimaan.Enabled = false;

                    //Tambahan UnitUsaha
                    if ((Tools.isNull(dt.Rows[0]["UnitUsaha"], "").ToString()) != "")
                    {
                        cboUnitUsaha.SelectedItem = dt.Rows[0]["UnitUsaha"].ToString();
                    }

                    LoadCboTransaksi();
                    Guid JnsTransRowID = (Guid)Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], Guid.Empty);

                    cboJnsTransaksi.SelectedValue = JnsTransRowID;


                    if (cboJnsTransaksi.Text == "PIUTANG BELUM IDEN")
                    {
                        cb_Leasing.Visible = true;
                        cb_Leasing.SelectedValue = (Guid)dt.Rows[0]["LeasingRowID"];
                    }

                    rdoBank.Enabled = false;
                    rdoKas.Enabled = false;
                    rdoGiro.Enabled = false;
                    //cboCabangDari.Enabled = false;
                    cboPerusahaanDari.Enabled = false;
                    cboPenerimaanDari.Enabled = false;
                    cboJnsTransaksi.Enabled = true;

                    if (dt.Columns.Contains("IdentifikasiPiutang"))
                    {
                        if (dt.Rows[0]["IdentifikasiPiutang"].ToString().Trim().Length != 0)
                        {
                            var _IDEN = dt.Rows[0]["IdentifikasiPiutang"].ToString().Split(';');
                            StringBuilder ss = new StringBuilder();
                            foreach (string value in _IDEN)
                            {
                                ss.Append(value.Replace('[', ' ').Replace(']', ' ').Trim() + System.Environment.NewLine);
                            }
                            txtIden.Text = ss.ToString();
                            txtIden.Visible = true;
                            cboJnsTransaksi.Enabled = false;
                        }

                    }
                }


                else
                {
                    txttglRK.DateValue = _today;
                    txtTanggal.DateValue = _today;
                    cboPenerimaanDari.SelectedIndex = 1;
                    cboCabangKe.SelectedValue = GlobalVar.CabangID;
                    cboPerusahaan.SelectedValue = GlobalVar.PerusahaanRowID;

                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }
                }
                show_panelPenerimaan();
                RefreshPenerimaanDari();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            switch (_bentukPenerimaan)
            {
                case "K": rdoKas.Checked = true; break;
                case "B": rdoBank.Checked = true; break;
                case "G": rdoGiro.Checked = true; break;
                default: rdoKas.Checked = true; break;
            }
        }

        private void fillComboPerusahaan()
        {
            try
            {
                DataTable dtPerusahaan = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dtPerusahaan = db.Commands[0].ExecuteDataTable();
                }
                /*
                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                                dtPerusahaan.Columns.Add(cConcatenated);
                                dtPerusahaan.Rows.Add("");
                */
                dtPerusahaan.DefaultView.Sort = "InitPerusahaan ASC";

                cboPerusahaan.DataSource = dtPerusahaan;
                cboPerusahaan.DisplayMember = "Nama";
                cboPerusahaan.ValueMember = "InitPerusahaan";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void fillComboPerusahaanDari()
        {
            try
            {
                DataTable dtPerusahaanDari = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dtPerusahaanDari = db.Commands[0].ExecuteDataTable();
                }
                /*
                                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "InitPerusahaan + ' | ' + Nama");
                                dtPerusahaan.Columns.Add(cConcatenated);
                                dtPerusahaan.Rows.Add("");
                */
                dtPerusahaanDari.DefaultView.Sort = "InitPerusahaan ASC";

                cboPerusahaanDari.DataSource = dtPerusahaanDari;
                cboPerusahaanDari.DisplayMember = "Nama";
                cboPerusahaanDari.ValueMember = "InitPerusahaan";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void fillComboCabang()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dtCabang = db.Commands[0].ExecuteDataTable();
                    dtCabangPengirim = db.Commands[0].ExecuteDataTable();
                }

                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabang.Columns.Add(cConcatenated);
                dtCabang.Rows.Add(System.DBNull.Value);
                dtCabang.DefaultView.Sort = "CabangID ASC";

                cboCabangKe.DataSource = dtCabang;
                cboCabangKe.DisplayMember = "Concatenated";
                cboCabangKe.ValueMember = "CabangID";

                DataColumn cConcatenated1 = new DataColumn("Concatenated1", Type.GetType("System.String"), "CabangID + ' | ' + Nama");
                dtCabangPengirim.Columns.Add(cConcatenated1);
                dtCabangPengirim.Rows.Add(System.DBNull.Value);
                dtCabangPengirim.DefaultView.Sort = "CabangID ASC";

                cboCabangDari.DataSource = dtCabangPengirim;
                cboCabangDari.DisplayMember = "Concatenated1";
                cboCabangDari.ValueMember = "CabangID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void fillComboJnsTransaksi()
        {
            try
            {
                DataTable dtJnsTransaksi = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksi_LIST"));
                    dtJnsTransaksi = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "JnsTransaksi + ' | ' + NamaTransaksi");
                dtJnsTransaksi.Columns.Add(cConcatenated);
                dtJnsTransaksi.Rows.Add(Guid.Empty);
                dtJnsTransaksi.DefaultView.Sort = "JnsTransaksi ASC";

                cboJnsTransaksi.DataSource = dtJnsTransaksi;
                cboJnsTransaksi.DisplayMember = "Concatenated";
                cboJnsTransaksi.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void fillComboMataUang()
        {
            try
            {
                DataTable dtMataUang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_MataUang_LIST_FILTER_Aktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@IsAktif", SqlDbType.Bit, true));
                    dtMataUang = db.Commands[0].ExecuteDataTable();
                }
                /*              DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "MataUangID + ' | ' + NamaMataUang");
                                dtMataUang.Columns.Add(cConcatenated);
                                dtMataUang.Rows.Add((Guid)Guid.NewGuid());
                */
                dtMataUang.DefaultView.Sort = "MataUangID ASC";

                cboMataUang.DataSource = dtMataUang;
                cboMataUang.DisplayMember = "MataUangID";
                cboMataUang.ValueMember = "RowID";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
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
            if (txtTanggal.DateValue <= _today.AddDays(-parameter[0]) || txtTanggal.DateValue >= _today.AddDays(+parameter[1]))
            { Expired = true; }
            return Expired;
        }

        private void ValidasiTanggalTransaksi(DateTime Tanggal, Guid HIRowID, Guid JournalRowID)
        {

            List<int> parameter = ParameterKuncian();
            if (Tanggal >= _today.AddDays(-parameter[0]) || (HIRowID != Guid.Empty || JournalRowID != Guid.Empty) || ValidasiSimpan().Equals(true))
            {
                cmdSAVE.Enabled = false;
            }
            else
            { cmdSAVE.Enabled = true; }


        }
        #endregion


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            if (this.Caller is frmPenerimaanUangBrowse)
            {
                frmPenerimaanUangBrowse frmCaller = (frmPenerimaanUangBrowse)this.Caller;
                frmCaller.RefreshData();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPenerimaanUangBrowse)
                {
                    frmPenerimaanUangBrowse frmCaller = (frmPenerimaanUangBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("NoBukti", txtNoBukti.Text);
                }
            }
            //this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0:yyMM}", txtTanggal.DateValue));
        }



        private void commandButton1_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = cboCabangKe.SelectedIndex;
            Object selectedItem = cboCabangKe.SelectedItem;

            MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
                   "Index: " + selectedIndex.ToString());

            MessageBox.Show("Tes : " + cboCabangKe.Items.IndexOf(selectedItem).ToString());
        }

        private void show_panelPenerimaan()
        {
            pnlKas.Visible = (_bentukPenerimaan == "K") ? true : false;
            pnlBank.Visible = (_bentukPenerimaan == "B") ? true : false;
            pnlGiro.Visible = (_bentukPenerimaan == "G") ? true : false;
            bool _mode_status = !((formMode == enumFormMode.Update) && (_isGroup));
            pnlKas.Enabled = _mode_status;
            pnlBank.Enabled = _mode_status;
            pnlGiro.Enabled = _mode_status;
        }

        private void cboPengeluaranKe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPenerimaanDari_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cboPenerimaanDari.SelectedIndex == 0) // kalo diubah jadi pilih dari PT.
            {
                key = 0;
                cboCabangDari.TabIndex = 0;
                cboPerusahaanDari.TabIndex = 7;
            }
            else if (cboPenerimaanDari.SelectedIndex == 1) // kalo diubah jadi  dari Cabang
            {
                key = 1;
                cboCabangDari.TabIndex = 7;
                cboPerusahaanDari.TabIndex = 0;
            }
            else { }
            RefreshPenerimaanDari();
        }

        private void RefreshPenerimaanDari()
        {     
            cboCabangDari.Visible = (cboPenerimaanDari.SelectedIndex == 1) ? true : false;
            cboPerusahaanDari.Visible = (cboPenerimaanDari.SelectedIndex == 0) ? true : false; 
            // kalo ada yang berubah visibilitasnya yang ngga tampil dikin milih yang kosong
            // langsung reset juga pilihan jenis transaksinya
            if (cboCabangDari.Visible)
            {
                cboPerusahaanDari.SelectedIndex = 0;
                cboJnsTransaksi.SelectedItem = "";
            }
            if (cboPerusahaanDari.Visible)
            {
                cboCabangDari.SelectedIndex = 0;
                cboJnsTransaksi.SelectedItem = "";
            }
            cboCabangDari.Refresh();
            cboPerusahaan.Refresh();

        }

        private void SimpanData()
        {
            if (string.IsNullOrEmpty(txtTanggal.DateValue.ToString()))
            {
                MessageBox.Show("Tanggal belum diisi");
                txtTanggal.Focus();
                return;
            }

            if (txtTanggal.DateValue < GlobalVar.GetBackDatedLockValue())
            {
                MessageBox.Show("Tidak boleh input data lebih dari batas waktu input / ubah data");
                return;
            }

            if (string.IsNullOrEmpty(cboMataUang.Text.ToString()))
            {
                MessageBox.Show("MataUangID pada combobox nominal belum dipilih.");
                cboMataUang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNominal.Text.ToString()) || (double.Parse(txtNominal.Text) == 0))
            {
                MessageBox.Show("Nominal belum diisi");
                txtNominal.Focus();
                return;
            }

            if (key == 0)
            {
                if (string.IsNullOrEmpty(cboPerusahaanDari.Text.ToString()))
                {
                    MessageBox.Show("Asal Perusahaan[PT.] pada combobox belum dipilih.");
                    cboPerusahaanDari.Focus();
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(cboCabangDari.Text.ToString().Trim()))
                {
                    MessageBox.Show("Asal Cabang pada combobox belum dipilih.");
                    cboCabangDari.Focus();
                    return;
                }
            }



            if (string.IsNullOrEmpty(cboCabangKe.Text.ToString()))
            {
                MessageBox.Show("Cabang Penerima");
                cboCabangKe.Focus();
                return;
            }


            if (String.IsNullOrEmpty(cboJnsTransaksi.Text.ToString()))
            {
                MessageBox.Show("Jenis Transaksi pada Combo transaksi belum dipilih.");
                cboJnsTransaksi.Focus();
                return;
            }


            Guid _rekeningRowID = new Guid();
            Guid _bankRowID = new Guid();
            switch (_bentukPenerimaan)
            {
                case "K":
                    if (string.IsNullOrEmpty(cboKas.Text))
                    {
                        MessageBox.Show("Kas harus dipilih.");
                        cboKas.Focus();
                        return;
                    }
                    else _rekeningRowID = (Guid)cboKas.SelectedValue;
                    break;
                case "B":
                    //if (string.IsNullOrEmpty(lookUpRekening1.txtSearch.Text.ToString()))
                    if ((Guid)Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty) == Guid.Empty)
                    {
                        MessageBox.Show("No. Rekening Bank belum dipilih / tidak ditemukan di database");
                        lookUpRekening1.Focus();
                        return;
                    }
                    else
                    {
                        _rekeningRowID = lookUpRekening1.RekeningRowID;
                        _bankRowID = lookUpRekening1.BankRowID;
                    }
                    break;
                case "G":
                    if (string.IsNullOrEmpty(cboBank2.Text))
                    {
                        MessageBox.Show("Bank pada combobox belum dipilih.");
                        cboBank2.Focus();
                        return;
                    }
                    else
                    {
                        _bankRowID = (Guid)cboBank2.SelectedValue;
                    }
                    if (string.IsNullOrEmpty(txtNoGiro.Text.ToString()))
                    {
                        MessageBox.Show(" Nomor Giro Belum diisi");
                        txtNoGiro.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(txtKota.Text.ToString()))
                    {
                        MessageBox.Show("Kota belum diisi.");
                        txtKota.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(dtJTGiro.DateValue.ToString()))
                    {
                        MessageBox.Show("Tanggal Jatuh tempo harus diisi.");
                        dtJTGiro.Focus();
                        return;
                    }
                    break;
            }

            //            int nerror = 0;
            Database db = new Database();
            //            db.BeginTransaction();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        //                        using (Database db = new Database())
                        {
                            //if (Tools.isNull(txtNoBukti.Text, "").ToString() == "")
                            //    txtNoBukti.Text = Numerator.GetNomorDokumen("PENERIMAAN_KAS", GlobalVar.PerusahaanID,
                            //                        "/B" + _bentukPenerimaan.Trim() + "M/" +
                            //                        string.Format("{0:yyMM}", txtTanggal.DateValue)
                            //                        , 3, false, true);
                            DataTable dt = new DataTable();
                            _rowID = Guid.NewGuid();
                            RowID_4Forward = _rowID;
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            if (_PLL)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));

                            }
                            else if (_pengUang == "Koreksi")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _pengeluaranUangRowID));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txttglRK.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, txtNoApproval.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, cboPenerimaanDari.SelectedIndex));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, cboPerusahaanDari.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, cboCabangDari.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, cboCabangKe.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJnsTransaksi.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalRp.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, _bentukPenerimaan));
                            db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? _rekeningRowID : System.Data.SqlTypes.SqlGuid.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? System.Data.SqlTypes.SqlGuid.Null : _bankRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? System.Data.SqlTypes.SqlGuid.Null : _rekeningRowID));
                            if (_bentukPenerimaan == "G")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, txtNoGiro.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KotaGiro", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalGiroCair", SqlDbType.VarChar, dtJTGiro.DateValue));

                                // mestinya kalau input penerimaan uang dari giro ada history giro dibuat baru dengan status gironya baru diterima

                            }
                            if (cb_Leasing.Visible == true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cb_Leasing.SelectedValue));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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

                            if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && GlobalVar.PerusahaanID == "PBR" && cboJnsTransaksi.Text == "PIUTANG USAHA")
                            {
                                frmPenerimaanLinkPiutang ifrmChild = new frmPenerimaanLinkPiutang(_rowID);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                {
                                    MessageBox.Show("Link piutang berhasil");
                                }
                            }

                            if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && GlobalVar.PerusahaanID == "SAP" && cboJnsTransaksi.Text == "PIUTANG WIL A")
                            {
                                frmPenerimaanLinkPiutangKanvas ifrmChild = new frmPenerimaanLinkPiutangKanvas(_rowID);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                {
                                    MessageBox.Show("Link piutang berhasil");
                                    
                                }
                                else
                                {
                                    this.Close();
                                }
                            }


                            if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && (GlobalVar.PerusahaanID == "PBR" || GlobalVar.PerusahaanID == "ECR") && cboJnsTransaksi.Text == "PIUTANG WIL A")
                            {
                                frmPenerimaanLinkPiutangPBRECER ifrmChild = new frmPenerimaanLinkPiutangPBRECER(_rowID);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                {
                                    MessageBox.Show("Link piutang berhasil");

                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                        if (this.Caller is Kasir.frmPembayaranMPM)
                        {
                            Kasir.frmPembayaranMPM frmCaller = (Kasir.frmPembayaranMPM)this.Caller;
                            frmCaller.RefreshData(_pengeluaranUangRowID);
                            frmCaller.refreshDetail();
                        }
                        break;
                    case enumFormMode.Update:
                        //                        using (Database db = new Database())
                        if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && GlobalVar.PerusahaanID == "PBR" && cboJnsTransaksi.Text == "PIUTANG USAHA")
                        {
                            if (txtIden.Text != "")
                            {
                                if (MessageBox.Show("Perubahan Akan Merubah Data Link Piutang   ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                                {
                                    return;
                                }
                            }
                        }
                        if (_isGroup) MessageBox.Show("Untuk sementara transaksi ini tidak dapat diupdate...");
                        else
                        {
                            DataTable dt = new DataTable();
                            List<Parameter> parameters = new List<Parameter>();
                            if (_isGroup)
                            {
                                if ((_groupRowID == null) || (_groupRowID == Guid.Empty))
                                {
                                    parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _groupRowID));
                                    dt = Tools.DBGetDataTable("usp_PengeluaranUang_LIST", parameters);
                                    parameters.Clear();
                                    if (dt.Rows.Count > 0)
                                    {
                                    }
                                }
                            }
                            dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txttglRK.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, txtNoApproval.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, cboPenerimaanDari.SelectedIndex));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, cboPerusahaanDari.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, cboCabangDari.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, cboCabangKe.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJnsTransaksi.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalRp.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, _bentukPenerimaan));
                            db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? _rekeningRowID : System.Data.SqlTypes.SqlGuid.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@BankRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? System.Data.SqlTypes.SqlGuid.Null : _bankRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? System.Data.SqlTypes.SqlGuid.Null : _rekeningRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, (_bentukPenerimaan == "G") ? txtNoGiro.Text : ""));
                            db.Commands[0].Parameters.Add(new Parameter("@KotaGiro", SqlDbType.VarChar, (_bentukPenerimaan == "G") ? txtKota.Text : ""));
                            db.Commands[0].Parameters.Add(new Parameter("@TanggalGiroCair", SqlDbType.Date, dtJTGiro.DateValue));
                            if (cb_Leasing.Visible == true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)cb_Leasing.SelectedValue));
                            } 
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@UnitUsaha", SqlDbType.VarChar, cboUnitUsaha.Text));
                            db.Commands[0].ExecuteNonQuery();
                            MessageBox.Show(Messages.Confirm.UpdateSuccess);
                            if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && GlobalVar.PerusahaanID == "PBR" && cboJnsTransaksi.Text == "PIUTANG USAHA")
                            {
                                frmPenerimaanLinkPiutang ifrmChild = new frmPenerimaanLinkPiutang(_rowID, true);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                {
                                    MessageBox.Show("Link piutang berhasil");
                                }
                            }

                            if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && GlobalVar.PerusahaanID == "SAP" && cboJnsTransaksi.Text == "PIUTANG WIL A")
                            {
                                frmPenerimaanLinkPiutangKanvas ifrmChild = new frmPenerimaanLinkPiutangKanvas(_rowID, true);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                {
                                    MessageBox.Show("Link piutang berhasil");
                                }
                               else
                                {
                                    this.Close();
                                }
                               
                            }



                            if (cboPerusahaanDari.SelectedValue.ToString() == GlobalVar.PerusahaanRowID.ToString() && (GlobalVar.PerusahaanID == "PBR" || GlobalVar.PerusahaanID == "ECR") && cboJnsTransaksi.Text == "PIUTANG WIL A")
                            {
                                frmPenerimaanLinkPiutangPBRECER ifrmChild = new frmPenerimaanLinkPiutangPBRECER(_rowID, true);
                                ifrmChild.ShowDialog();
                                if (ifrmChild.DialogResult == DialogResult.OK)
                                {
                                    MessageBox.Show("Link piutang berhasil");

                                }
                                else
                                {
                                    this.Close();
                                }
                            }

                        }

                        break;
                    default: break;
                }
                if (_PLL)
                {
                    if (this.Caller is frmPengeluaranPiutangLainBrowse)
                    {
                        frmPengeluaranPiutangLainBrowse frmCaller = (frmPengeluaranPiutangLainBrowse)this.Caller;
                        frmCaller.RefreshRowDataGridDetail(_rowID, (Guid)_HeaderID);
                    }

                }

                if (this.Caller is Kasir.frmPenerimaanLeasingBrowse)
                {
                    Kasir.frmPenerimaanLeasingBrowse frmCaller = (Kasir.frmPenerimaanLeasingBrowse)this.Caller;
                    frmCaller.RefreshHeader(_rowID);
                    this.Close();
                }

                if (cboPenerimaanDari.SelectedIndex == 1)
                {

                    cmdForward.Enabled = true;
                    cmdSAVE.Enabled = false;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    closeForm();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                //                if (nerror == 0) db.CommitTransaction(); else db.RollbackTransaction();
            }
        }


        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            //if (txtTanggal.DateValue < Convert.ToDateTime(GlobalVar.GetServerDate).AddDays(-3))
            //{
            //    MessageBox.Show("Tidak diijinkan input tanggal jika lebih dari 3 hari", "Informasi");
            //}
            //else
            if (_pengUang == "Koreksi")
            {
                if (Double.Parse(txtNominalRp.Text) > _nominalPengeluaranUang)
                {
                    MessageBox.Show("Saldo Tidak Mencukupi");
                    txtNominal.Text = _nominalPengeluaranUang.ToString();
                    return;
                }
            }
            {
                CheckValidasiUraian("09");
            }
        }

        private void txtTanggal_TextChanged(object sender, EventArgs e)
        {
            //ValidasiTanggalTransaksi(_tanggal,_HIRowID,_JournalRowiD);
            //if (ValidasiSimpan() == true)
            //{
            //    cmdSAVE.Enabled = false;

            //}
            //else { cmdSAVE.Enabled = true; }
        }



        #region RefreshCboMataUangID

        private void RefreshCboMataUangID()
        {
            lookUpRekening1.txtSearch.Text = String.Empty;
            lookUpRekening1.lblNoRekening.Text = String.Empty;
            lookUpRekening1.lblBank.Text = String.Empty;
        }


        #endregion


        private Double GetKursValue(DateTime tgl, Guid MataUangRowID)
        {
            Double Kurs = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetKursMataUangIDR_LAST"));
                db.Commands[0].Parameters.Add(new Parameter("@TglKurs", SqlDbType.Date, tgl));
                db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, MataUangRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                Kurs = (Double)dt.Rows[0]["Kurs"];
            }
            return Kurs;
        }




        private void cboCabangDari_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppendUraian("09");

            if (!(cboCabangDari.Text.ToString().Equals("")))
            {
                if (!(cboCabangDari.Text.ToString().Equals(cboCabangKe.Text.ToString())))
                {
                    fcbo.fillComboJnsTransaksiDIFFER_Penerimaan(cboJnsTransaksi, false);
                }
                cboJnsTransaksi.Enabled = true;
            }
            else
            {

                fcbo.fillComboJnsTransaksi(cboJnsTransaksi, Guid.Empty);
                cboJnsTransaksi.Enabled = false;

            }
        }

        private void cboPerusahaanDari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboPerusahaanDari.Text.ToString().Equals("")))
            {
                if (cboPerusahaanDari.Text.ToString().Equals(cboPerusahaan.Text.ToString()))
                {
                    fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, false);

                    if (!_PLL)
                    {
                        int x = cboJnsTransaksi.Items.Count;
                        DataTable dtT = (DataTable)cboJnsTransaksi.DataSource;

                        string kk = _GPLL.ToString();
                        bool pll_ = false;
                        int y = 0;
                        for (int i = 0; i < dtT.Rows.Count; i++)
                        {
                            if (kk.Equals(dtT.Rows[i]["RowID"].ToString()))
                            {
                                pll_ = true;
                                y = i;
                                break;
                            }

                        }
                        if (pll_)
                        {
                            dtT.Rows[y].Delete();

                        }
                    }
                }
                else
                {
                    fcbo.fillComboJnsTransaksiDIFFER_Penerimaan(cboJnsTransaksi, false);
                }

                cboJnsTransaksi.Enabled = true;

            }
            else
            {
                fcbo.fillComboJnsTransaksi(cboJnsTransaksi, Guid.Empty);
                cboJnsTransaksi.Enabled = false;
            }
        }




        private void txtNominal_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(txtNominal.Text.Equals(String.Empty)))
            {

                if (cboMataUang.Text.ToString() == "IDR") txtNominalRp.Text = txtNominal.Text;
                //{

                //txtNominalRp.Text = Convert.ToString(txtNominal.GetDoubleValue * KursValueMataUang).Trim();
                //}
            }
            else
            {
                txtNominalRp.Text = "0";
            }

        }



        private void cboMataUang_Leave(object sender, EventArgs e)
        {


            if (cboMataUang.SelectedIndex > 0)
            {


                if (!(cboMataUang.Text.ToString().Equals("IDR")))
                {


                    Double
                    KursValue = GetKursValue((DateTime)txtTanggal.DateValue, (Guid)cboMataUang.SelectedValue);
                    if (KursValue > 0)
                    {
                        KursValueMataUang = KursValue;
                        txtNominal.Focus();
                    }
                    // di-remark oleh : Eko (05 Jul 2012) sementara nominalRp diketik manual
                    //else
                    //{
                    //    MessageBox.Show("Maaf, Kurs BI tanggal " + txtTanggal.Text + " belum di-update." + Environment.NewLine + "Silakan Update Kurs Mata Uang.");
                    //    cboMataUang.SelectedIndex = 0;
                    //    txtTanggal.Focus();
                    //    return;
                    //}


                }
                else
                {
                    txtNominal.Focus();
                    txtNominalRp.Text = "0";

                }


                RefreshCboMataUangID();

                lookUpRekening1.Enabled = true;
                lookUpRekening1.MataUangIDRekening = cboMataUang.Text.ToString();
                lookUpRekening1.PerusahaanID = (Guid)cboPerusahaan.SelectedValue;


            }
            else
            {

                lookUpRekening1.Enabled = false;

                RefreshCboMataUangID();
            }
        }

        private void cboMataUang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMataUang.SelectedIndex == 0)
            {
                lookUpRekening1.Enabled = false;
            }
            else
            {
                txtNominal.Text = "0";
                txtNominalRp.Text = "0";
                lookUpRekening1.Enabled = true;

            }

            // 5 Jun 2012 by Eko : sementara bisa diedit klu matauang bukan IDR
            txtNominalRp.Enabled = (cboMataUang.Text != "IDR");
            label18.Visible = txtNominalRp.Enabled;
            txtKurs.Visible = label18.Visible;
        }


        private void AppendUraian(String CabID)
        {
            if (cboCabangDari.SelectedIndex != 0)
            {

                String textAppend = CabID + " ";
                int strLength = textAppend.Length;

                if (cboPenerimaanDari.SelectedIndex == 0)
                {
                    return;
                }

                if (cboPenerimaanDari.SelectedIndex == 1)
                {
                    ComboCabangID = cboCabangDari.Text.ToString().Substring(0, 2);

                    if (ComboCabangID.Equals(CabID))
                    {
                        if (!txtUraian.Text.Contains(textAppend))
                        {
                            if (txtUraian.Text != String.Empty)
                            {
                                txtUraian.Text = txtUraian.Text.Insert(0, textAppend);
                            }
                            else
                            {
                                txtUraian.Text = txtUraian.Text.Insert(0, textAppend);
                            }
                        }
                    }
                    else
                    {
                        if (txtUraian.Text.Contains(textAppend))
                        {
                            txtUraian.Text = txtUraian.Text.Remove(0, strLength);
                        }
                    }
                }
            }

        }

        private DataTable GetListGudangID(String CabangID)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("GetGudangID_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        private void RegexGudangID(String input, String GudangID)
        {

            String pola = "^*(" + GudangID + ")$*";

            foreach (Match cocok in Regex.Matches(input, pola))
            {
                SimpanData();
                IsRegex = 1;
            }
        }

        private void CheckValidasiUraian(String CabID)
        {
            String textAppend = CabID;
            int strLength = textAppend.Length;
            DataTable dt_ = new DataTable();
            dt_ = GetListGudangID(CabID);
            ArrayList arrGudangID = new ArrayList();
            IsRegex = 0;
            if (cboPenerimaanDari.SelectedIndex == 1)
            {
                if (cboCabangDari.Text.ToString() == "")
                {
                    MessageBox.Show("Tolong pilih Asal Cabang terlebih dahulu");
                    return;
                }

                ComboCabangID = cboCabangDari.Text.ToString().Substring(0, 2);
            }

            if (cboPenerimaanDari.SelectedIndex == 0)
            {
                SimpanData();
                return;
            }

            //ComboCabangID = cboCabangDari.Text.ToString().Substring(0, 2);
            if (ComboCabangID.Equals("09"))
            {
                for (int i = 0; i < dt_.Rows.Count; i++)
                {
                    arrGudangID.Add(dt_.Rows[i]["GudangID"]);
                    RegexGudangID(txtUraian.Text, arrGudangID[i].ToString());
                }

                if (IsRegex.Equals(0))
                {

                    if (!strLength.Equals(4))
                    {


                        StringBuilder builder = new StringBuilder();
                        foreach (String itm in arrGudangID)
                        {

                            builder.Append(itm.ToString()).AppendLine();

                        }

                        foreach (String item in arrGudangID)
                        {



                            if (!item.Equals(arrGudangID[0].ToString()))
                            {
                                MessageBox.Show("Silakan isikan pada inputan Uraian pada awal text uraian sesuai dengan Gudang ID pada cabang " + CabID + "." + Environment.NewLine
                                    + "Cabang " + CabID + " memiliki beberapa Gudang ID: " + Environment.NewLine + builder.ToString());
                                return;
                            }

                        }

                    }
                }
            }
            else
            { SimpanData(); }
        }

        private void numericTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (cboMataUang.SelectedText != "IDR")
            {
                if (Convert.ToDouble(txtNominalRp.Text) == 0) txtNominalRp.Text = (Convert.ToDouble(txtNominal.Text) * Convert.ToDouble(txtKurs.Text)).ToString();
                else if (Convert.ToDouble(txtNominal.Text) == 0) txtNominal.Text = (Convert.ToDouble(txtNominalRp.Text) / Convert.ToDouble(txtKurs.Text)).ToString();
            }
        }

        private void cmdForward_Click(object sender, EventArgs e)
        {

            Keuangan.panelStok ifrm = new Keuangan.panelStok(RowID_4Forward, true);
            ifrm.Show();
            cmdForward.Visible = false;

        }

        private void txtNominal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNominal.Text)))
            {

                if (cboMataUang.Text.ToString() == "IDR") txtNominalRp.Text = txtNominal.Text;
                //{

                //txtNominalRp.Text = Convert.ToString(txtNominal.GetDoubleValue * KursValueMataUang).Trim();
                //}
            }
            else
            {
                txtNominalRp.Text = "0";
            }
        }

        private void cboJnsTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String asd  = cboJnsTransaksi.SelectedItem.ToString();
            //String asd1 = cboJnsTransaksi.SelectedValue.ToString();
            //String asd2 = cboJnsTransaksi.SelectedIndex.ToString();
            //String asd3 = cboJnsTransaksi.SelectedText.ToString();

            //cek apakah dari jns transaksi "PIUTANG LSG BELUM IDEN"
            if (cboJnsTransaksi.SelectedValue.ToString() == Convert.ToString("d35058d1-2a51-4ac1-9a32-947190427c81"))
            {

                lbl_Leasing.Visible = true;
                cb_Leasing.Visible = true;
                rdoBank.Checked = true;
                rdoGiro.Visible = false;
            }
            else
            {
                lbl_Leasing.Visible = false;
                cb_Leasing.Visible = false;
                rdoGiro.Visible = true;
            }
        }

        private void cb_Leasing_VisibleChanged(object sender, EventArgs e)
        {
            if (cb_Leasing.Visible == true)
            {
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    db.Commands.Add(db.CreateCommand("usp_Leasing_LIST"));
                    cb_Leasing.DataSource = db.Commands[0].ExecuteDataTable();
                    cb_Leasing.ValueMember = "RowID";
                    cb_Leasing.DisplayMember = "Nama";
                }
                //cb_Leasing.SelectedIndex = 0;
            }
        }

    }
}
