using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Text.RegularExpressions;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmPengeluaranUangUpdate0 : ISA.Controls.BaseForm 
    {
        #region VARIABLES DECLARATIONS  
        enum enumFormMode { New, Update, Approve };
        enumFormMode formMode;
        string _bentukPengeluaran;  
        string _bentukPenerimaan;
        bool _needApprove = false;
        GlobalVar.enumStatusApproval _statusApproval = GlobalVar.enumStatusApproval.Closed;
        DateTime _today = GlobalVar.GetServerDate;
        bool _isNeedApproval;
        bool _isGroup = false;
        Guid _HIRowID;
        Guid _JournalRowID;
        DateTime _tanggal;
        String ComboCabangID;
        Guid _rowID, _groupRowID, _rekeningRowID;
        Guid _perusahaanRowID, _perusahaanKeRowID;
        Guid Guid_JnsTrans;
        Guid _GPLL = new Guid("579FF9B4-8E53-49D6-84DC-5293004E3ED7");
        //Guid _kasRowID;, _penerimaanRowID;

        Guid _RowIDForward;

        int _accKe;
        DataTable dt;
        Class.FillComboBox fcbo = new Class.FillComboBox();
        String JnsPenerimaan = String.Empty;
        //Guid _PerusahaanRowID;
        bool flagF2=false;
        Guid PtDari = Guid.Empty;
        Guid PtKe = Guid.Empty;
        Guid _bankRowID = Guid.Empty;
        int _pengeluaranKe;
        Double KursValueMataUang = 0;
        int IsRegex;
        bool _ForwardDariPenerimaan = false;
        Guid _rowIDPenerimaan;
        bool _IsPembayaran = false;

        bool _PLL = false;
        #endregion
         
        public frmPengeluaranUangUpdate0() 
        {
            InitializeComponent(); 
        }

        public frmPengeluaranUangUpdate0(Guid RowIDPenerimaan,bool HasilForwardPenerimaan)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowIDPenerimaan = RowIDPenerimaan;
            _ForwardDariPenerimaan = HasilForwardPenerimaan;
        }

        public frmPengeluaranUangUpdate0(Form caller, bool isNeedApproval)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _isNeedApproval = isNeedApproval;
            this.Caller = caller;
        }

        public frmPengeluaranUangUpdate0(Form caller, bool isNeedApproval, bool PLL_)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _isNeedApproval = isNeedApproval;
            this.Caller = caller;
            _PLL = true;
        }

        public frmPengeluaranUangUpdate0(Form caller, bool isNeedApproval, Guid rowID, bool PLL_)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _isNeedApproval = isNeedApproval;
            _PLL = true;
            this.Caller = caller;
        }


        public frmPengeluaranUangUpdate0(Form caller, bool isNeedApproval, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _isNeedApproval = isNeedApproval;
           
            this.Caller = caller;
        }

        public frmPengeluaranUangUpdate0(Form caller, Guid rowID, int AccKe)
        {
            InitializeComponent();
            formMode = enumFormMode.Approve;
            _rowID = rowID;
            _accKe = AccKe;
            _isNeedApproval = true;
            _needApprove = true;
            this.Caller = caller;
        }

        private void EnabledControls()
        {
            cboPengeluaranKe.Enabled = false;
            cboCabangKe.Enabled = false;
            cboPerusahaanKe.Enabled = false;
            cboVendor.Enabled = false;
            lblJenisTransaksi.Enabled = false;
            grpJnsPengeluaran.Enabled = true;
            
            cboCabangDari.Enabled = false;
            cboPerusahaan.Enabled = false;
            cboMataUang.Enabled = true;
            if (cboMataUang.Text.ToString() == "IDR")
            {
                txtNominalRp.Enabled = false;
                
            }
            else
                txtNominalRp.Enabled = true;

            if (PtDari.Equals(PtKe))
            {
                grpJnsPenerimaan.Enabled = false;
            }
            else
            { grpJnsPenerimaan.Enabled = true; }

            txtUraian.Enabled = true;
         //   txtTanggal.Enabled = true;
            txtNominal.Enabled = true;
        }

        private void disabled()
        {
            cboPengeluaranKe.Enabled = false;
            cboCabangKe.Enabled = false;
            cboPerusahaanKe.Enabled = false;
            cboVendor.Enabled = false;
            lblJenisTransaksi.Enabled = false;
            grpJnsPenerimaan.Enabled = false;
            grpJnsPengeluaran.Enabled = false;

            cboCabangDari.Enabled = false;
            cboPerusahaan.Enabled = false;
            cboMataUang.Enabled = false;
            txtNominal.Enabled = false;
           
            txtUraian.Enabled = false;
            txtTanggal.Enabled = false;

            txtNominalRp.Enabled = false;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
            closeForm();
            this.Close();
        }

        private void frmPengeluaranUangUpdate0_Load(object sender, EventArgs e)
        {
            UnForwardControl();

            this.Title = ((!_isNeedApproval) ? "" : "Pengajuan ") + "Pengeluaran Uang";

            fcbo.fillComboPerusahaan(cboPerusahaan);
            fcbo.fillComboPerusahaan(cboPerusahaanKe);
            fcbo.fillComboCabang(cboCabangDari, GlobalVar.PerusahaanRowID, GlobalVar.CabangID);
          
            fcbo.fillComboCabangNonCabangIDLogin(cboCabangKe);
            fcbo.fillComboVendor(cboVendor);

            
            fcbo.fillComboMataUang(cboMataUang);
            fcbo.fillComboKas(cboKas,GlobalVar.PerusahaanRowID);
 
            pnlKas.Left = 105;
            pnlKas.Top = 18;

            pnlBank.Left = 105;
            pnlBank.Top = 18;

            pnlGiro.Left = 105;
            pnlGiro.Top = 18;

            pnlTrmKas.Left = 105;
            pnlTrmKas.Top = 18;

            pnlTrmBank.Left = 105;
            pnlTrmBank.Top = 18;

            pnlBankLuar.Left = 105;
            pnlBankLuar.Top = 18;

            LoadComboPengeluaranK();
            RefreshData();

            if (_PLL)
            {
                 cboPengeluaranKe.SelectedIndex = 2;
                 cboPengeluaranKe.Enabled = false;
             
              //  cboPerusahaanKe.Enabled = false;
                fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, false);
                  show_panelPenerimaan();
                // cboJnsTransaksi.SelectedValue = _GPLL;
                //cboJnsTransaksi.Enabled = false;
                //if (formMode == enumFormMode.New)
                //{
                //    cboPerusahaanKe.SelectedValue = GlobalVar.PerusahaanRowID;
                //    txtTanggal.Enabled = true;
                //    txtTanggal.ReadOnly = false;
                //}
                cboJnsTransaksi.SelectedValue = _GPLL;
                cboJnsTransaksi.Enabled = false;

                if (_PLL && cboPerusahaanKe.DataSource !=null)
                {
                    int x = cboPerusahaanKe.Items.Count;
                    DataTable dtT = (DataTable)cboPerusahaanKe.DataSource;

                    string kk = GlobalVar.PerusahaanRowID.ToString();
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
            
        }

        private void LoadComboPengeluaranK()
        {

            cboPengeluaranKe.Items.Add("Ke Cabang");
            cboPengeluaranKe.Items.Add("Ke Vendor");
            cboPengeluaranKe.Items.Add("Ke Perusahaan");
        }

        private void EditControl(bool isGroup,Guid JournalRowID)
        {
            if (_isGroup == true || JournalRowID!=Guid.Empty)
            { 
                cmdSAVE.Enabled = false;
                disabled();
     
            }
            else 
            { 
                cmdSAVE.Enabled = true;
                EnabledControls();
              
            }
        }

        private void ResetInputan()
        {
            txtNoBukti.Clear();
            txtTanggal.Enabled = true;
            cboMataUang.Enabled = true;
            txtNominal.Enabled = true;
            txtNominal.Clear();
            txtUraian.Enabled = true;
            txtUraian.Clear();
            cboPengeluaranKe.Enabled = true;
            cboPengeluaranKe.SelectedIndex = 0;
            cboVendor.Enabled = true;
            cboPerusahaanKe.Enabled = true;
            cboCabangKe.Enabled = true;
            cboJnsTransaksi.Enabled = true;
            grpJnsPengeluaran.Enabled = true;
            grpJnsPenerimaan.Enabled = true;
            rdoKas.Checked = true;
            rdoTrmKas.Checked=true;
            fcbo.fillComboPerusahaan(cboPerusahaanKe);
            lblJenisTransaksi.Enabled = true;
            cmdSAVE.Enabled = true;
        }


        private void LoadDataForwardPenerimaan()
        {
            
            cboCabangDari.SelectedValue = GlobalVar.CabangID;
            cboCabangDari.Enabled = false;
            cboPengeluaranKe.SelectedIndex = 2;
            cboPengeluaranKe.Enabled = false;
            txtTanggal.Enabled = true;
            cmdAdd.Visible = false;
            numKurs.Enabled = true;
            grpJnsPengeluaran.Enabled = false;
            cmdForward.Visible = false;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier,_rowIDPenerimaan));
                dt=db.Commands[0].ExecuteDataTable();
            }

            Guid F_PerusahaanDari = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanKeRowID"], Guid.Empty);
            fcbo.fillComboPerusahaan(cboPerusahaan);
            cboPerusahaan.SelectedValue = F_PerusahaanDari;
            cboPerusahaan.Enabled = false;

            fcbo.fillComboPerusahaanNoPerusahaanIDLocal(cboPerusahaanKe, 1);
            txtTanggal.DateValue =(DateTime) Tools.isNull(dt.Rows[0]["Tanggal"], DateTime.MinValue);
            String F_jnsPenerimaan = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();
            numKurs.Text=Tools.isNull(dt.Rows[0]["Kurs"], 0).ToString();
            Guid F_MtUangRowID = (Guid)Tools.isNull(dt.Rows[0]["MataUangRowID"], Guid.Empty);
            fcbo.fillComboMataUang(cboMataUang);
            cboMataUang.SelectedValue = F_MtUangRowID;

            cboJnsTransaksi.Text = 
            txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], 0).ToString();
            txtNominalRp.Text = Tools.isNull(dt.Rows[0]["NominalRp"], 0).ToString();
            txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
            cboJnsTransaksi.Text = Tools.isNull(dt.Rows[0]["NamaTransaksi"], "").ToString();

            rdoKas.Checked = F_jnsPenerimaan == "K";
            rdoBank.Checked = F_jnsPenerimaan == "B";
            rdoGiro.Checked = F_jnsPenerimaan == "G";
            if (F_jnsPenerimaan == "K")
            {
                fcbo.fillComboKas(cboKas,F_PerusahaanDari);
                Guid KasRowIDKeluar;
                KasRowIDKeluar = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                cboKas.SelectedValue = KasRowIDKeluar;
            }
            if (F_jnsPenerimaan == "B")
            {
                Guid hh = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                lkpRekening1.SetRekeningRowID(hh);
                //lookUpRekening2.SetRekeningRowID((Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty));
                //txtNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();
            }
            if (F_jnsPenerimaan == "G")
            { 
                
            }

        }


        private void RefreshData()
        {
            try
            {
                if (_ForwardDariPenerimaan.Equals(true))
                {
                    LoadDataForwardPenerimaan();
                  
                }
                else
                {
                 
                    this.Cursor = Cursors.WaitCursor;
                    _rekeningRowID = Guid.Empty;
                    if ((formMode == enumFormMode.Update) || (formMode == enumFormMode.Approve))
                    {
                        //retrieving data
                        cmdAdd.Enabled = true;
                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        //display data


                        txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                        txtNoBukti.Enabled = false;
                        if (dt.Rows[0]["Tanggal"] == System.DBNull.Value) txtTanggal.Text = "";
                        else _tanggal = (DateTime)(dt.Rows[0]["Tanggal"]); txtTanggal.DateValue = _tanggal;
                        tglrk.DateValue = (DateTime)(dt.Rows[0]["TanggalRk"]);
                        txtNoApproval1.Text = Tools.isNull(dt.Rows[0]["NoApproval"], "").ToString();
                        PtDari = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanDariRowID"], Guid.Empty);
                        cboPerusahaan.SelectedValue = PtDari;
                        cboCabangDari.SelectedValue = Tools.isNull(dt.Rows[0]["CabangDariID"], "").ToString();
                        checkCF.Checked = Convert.ToBoolean(Tools.isNull(dt.Rows[0]["IsPembayaran"], false));

                        cboVendor.SelectedValue = Tools.isNull(dt.Rows[0]["VendorRowID"], Guid.Empty);
                        cboMataUang.SelectedValue = Tools.isNull(dt.Rows[0]["MataUangRowID"], Guid.Empty);
                        txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
                        txtNominalRp.Text = Tools.isNull(dt.Rows[0]["NominalRp"], "").ToString();
                        txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                        cboJnsTransaksi.Text = Tools.isNull(dt.Rows[0]["NamaTransaksi"], "").ToString();
                        String NoAcc =  Tools.isNull(dt.Rows[0]["NoAcc"], "").ToString();
                        if (NoAcc != "")
                        {
                            txtNoAcc.Visible = true;
                            txtNoAcc.Text = Tools.isNull(dt.Rows[0]["NoAcc"], "").ToString();
                        }
                        _bentukPengeluaran = Tools.isNull(dt.Rows[0]["JnsPengeluaran"], "").ToString();
                        _bentukPenerimaan = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();

                        _rekeningRowID = (Guid)(Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty));
                        _statusApproval = (GlobalVar.enumStatusApproval)(int.Parse(Tools.isNull(dt.Rows[0]["StatusApproval"], "").ToString()));

                        Guid JournalRowID = (Guid)Tools.isNull(dt.Rows[0]["JournalRowID"], Guid.Empty);

                        _HIRowID = (Guid)Tools.isNull(dt.Rows[0]["HIRowID"], Guid.Empty);
                        _JournalRowID = (Guid)Tools.isNull(dt.Rows[0]["JournalRowID"], Guid.Empty);
                        ValidasiTanggalTransaksi(_tanggal, _HIRowID, _JournalRowID);



                        int PengeluaranKe;
                        PengeluaranKe = Convert.ToInt32(Tools.isNull(dt.Rows[0]["PengeluaranKe"], 0));


                        if (PengeluaranKe == 0)
                        {


                            String CabangID;
                            CabangID = Tools.isNull(dt.Rows[0]["CabangKeID"], "").ToString();
                            fcbo.fillComboCabang(cboCabangKe, CabangID);
                        }
                        else if (PengeluaranKe == 1)
                        {

                            Guid Guid_vendor;
                            Guid_vendor = (Guid)Tools.isNull(dt.Rows[0]["VendorRowID"], Guid.Empty);
                            fcbo.fillComboVendor(cboVendor, Guid_vendor);

                        }
                        else
                        {

                            PtKe = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanKeRowID"], Guid.Empty);
                            fcbo.fillComboPerusahaan(cboPerusahaanKe, PtKe);
                        }

                        cboPengeluaranKe.SelectedIndex = PengeluaranKe;




                        if (_bentukPengeluaran == "K")
                        {


                            fcbo.fillComboKas(cboKas, (Guid)cboPerusahaan.SelectedValue);
                            Guid KasRowIDKeluar;
                            KasRowIDKeluar = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                            cboKas.SelectedValue = KasRowIDKeluar;

                        }
                        else
                        {
                            fcbo.fillComboKas(cboKas, (Guid)cboPerusahaan.SelectedValue);
                        }

                        if (_bentukPengeluaran == "B") lkpRekening1.SetRekeningRowID(_rekeningRowID); //cboRekening1.SelectedValue = _rekeningRowID;
                        if (_bentukPengeluaran == "G") lkpRekening2.SetRekeningRowID(_rekeningRowID); //cboRekening2.SelectedValue = _rekeningRowID;
                        txtNoGiro.Text = Tools.isNull(dt.Rows[0]["NoCekGiro"], "").ToString();
                        if (dt.Rows[0]["DueDateGiro"] != System.DBNull.Value) dtDueDateGiro.DateValue = (DateTime)(dt.Rows[0]["DueDateGiro"]);
                        if (_bentukPenerimaan == "K")
                        {
                            fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaanKe.SelectedValue);
                            Guid KasRowID;
                            KasRowID = (Guid)Tools.isNull(dt.Rows[0]["KeKasRowID"], Guid.Empty);
                            cboKasTerima.SelectedValue = KasRowID;
                            txtNoRekening.Text = "";
                        }
                        else
                        {
                            fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaanKe.SelectedValue);

                        }


                        if (_bentukPenerimaan == "B")
                        {
                            lookUpRekening2.SetRekeningRowID((Guid)Tools.isNull(dt.Rows[0]["KeRekeningRowID"], Guid.Empty));
                            txtNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();
                        }




                        Guid groupRowID = (Guid)Tools.isNull(dt.Rows[0]["GroupRowID"], Guid.Empty);
                        if (groupRowID.Equals(Guid.Empty))
                        {
                            _groupRowID = Guid.Empty;
                        }



                        Guid_JnsTrans = (Guid)Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], Guid.Empty);
                        cboJnsTransaksi.Enabled = false;
                        cboJnsTransaksi.SelectedValue = Guid_JnsTrans;
                        //fcbo.fillComboJnsTransaksi(cboJnsTransaksi, Guid_JnsTrans);

                        //txtNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();

                        //Approve #1
                        txtPICApprove1.Text = Tools.isNull(dt.Rows[0]["AccOleh1"], "").ToString();
                        txtNoApproval1.Text = Tools.isNull(dt.Rows[0]["AccNo1"], "").ToString();
                        dtTanggalApproval1.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["AccTanggal1"], DateTime.MinValue);

                        //Approve #2
                        txtPICApprove2.Text = Tools.isNull(dt.Rows[0]["AccOleh2"], "").ToString();
                        txtNoApproval2.Text = Tools.isNull(dt.Rows[0]["AccNo2"], "").ToString();
                        dtTanggalApproval2.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["AccTanggal1"], DateTime.MinValue);


                        // disabled();

                        //rdoTrmBank.Checked = (_bentukPenerimaan != "K");
                        rdoTrmBank.Checked = (_bentukPenerimaan == "B");
                        rdoTrmKas.Checked = (_bentukPenerimaan == "K");

                        _isGroup = (bool)Tools.isNull(dt.Rows[0]["IsGroup"], false);


                        EditControl(_isGroup, JournalRowID);
                        //if (PtDari.Equals(PtKe))
                        //{
                        //    grpJnsPenerimaan.Enabled = false;
                        //}
                        //else
                        //{ grpJnsPenerimaan.Enabled = true; }
                    }
                    else
                    {
                        cmdAdd.Enabled = false;
                        txtTanggal.DateValue = GlobalVar.GetServerDate; // DateTime.Today;
                        tglrk.DateValue = GlobalVar.GetServerDate;
                        cboCabangDari.SelectedValue = GlobalVar.CabangID; // "11";
                        cboPerusahaan.SelectedValue = GlobalVar.PerusahaanRowID;
                        ResetInputan();
                        cboPengeluaranKe.SelectedIndex = 0;
                        //fcbo.fillComboCabang(cboCabangKe);

                        cboCabangDari.Enabled = false;
                        cboPerusahaan.Enabled = false;
                        //cboPengeluaranKe.Enabled = !((formMode == enumFormMode.Update) && (_isGroup));
                        //cboCabangKe.Enabled = !((formMode == enumFormMode.Update) && (_isGroup));
                        cboPerusahaanKe.Enabled = !((formMode == enumFormMode.Update) && (_isGroup));
                        show_panelPengeluaran();
                        show_panelPenerimaan();
                    }
                    _needApprove = (_statusApproval != GlobalVar.enumStatusApproval.Closed);
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
            switch (_bentukPengeluaran)
            {
                case "K": rdoKas.Checked = true; break;
                case "B": rdoBank.Checked = true; break;
                case "G": rdoGiro.Checked = true; break;
                default: rdoKas.Checked = true; break;
            }
            bool _updateable;
            switch (formMode)
            {
                case enumFormMode.New: _updateable = true; break;
                case enumFormMode.Approve: _updateable = false; break;
                default:
                    _updateable = ((_statusApproval == GlobalVar.enumStatusApproval.Open) || !_needApprove);
                    break;
            }
            pnlDetil1.Enabled = _updateable;
            cmdSAVE.Visible = _updateable;
            cmdRealisasi.Visible = ((_statusApproval == GlobalVar.enumStatusApproval.Approved) && _needApprove && 
                                    ((Guid)Tools.isNull(_groupRowID,Guid.Empty)==Guid.Empty));
            RefreshAcc();

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
            if (txtTanggal.DateValue <= GlobalVar.GetServerDate.AddDays(-parameter[0]) || txtTanggal.DateValue >= GlobalVar.GetServerDate.AddDays(+parameter[1])) 
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

        private void GetCurrencyRate()
        {
            float rate = 0;
            if ((txtTanggal.Text != "") && (cboMataUang.Text != ""))
            {
                rate = Tools.GetCurrencyRate((Guid)cboMataUang.SelectedValue, (DateTime)txtTanggal.DateValue);
                numKurs.Text = string.Format("{0:0,0.0}", rate);
            }
        }

        private void HitungKurs()
        {
            if (string.IsNullOrEmpty(txtNominal.Text.ToString()) || string.IsNullOrEmpty(numKurs.Text.ToString()))
                txtNominalRp.Text = "0";
            else 
            txtNominalRp.Text = (Convert.ToDouble(txtNominal.Text)*Convert.ToDouble(numKurs.Text)).ToString();
        }

        private bool IsValid()
        {
            if (_needApprove && (_statusApproval > 0))
            {
                MessageBox.Show("Tidak boleh mengubah data setelah pengajuan Acc");
                return false;
            }

            if (!_needApprove && string.IsNullOrEmpty(txtTanggal.DateValue.ToString()))
            {
                MessageBox.Show("Tanggal belum diisi");
                txtTanggal.Focus();
                return false ;
            }

            if (txtTanggal.DateValue < GlobalVar.GetBackDatedLockValue())
            {
                MessageBox.Show("Tidak boleh input data lebih dari batas waktu input / ubah data");
                return false;
            }

            DataTable dtcek = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCek"));
                db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, cboJnsTransaksi.Text));
                dtcek = db.Commands[0].ExecuteDataTable();
            }
            if (dtcek.Rows.Count != 0 && txtNoAcc.Text == "")
            {
                MessageBox.Show("No ACC harus diisi");
                return false;
            }

            //DataTable dtceknoacc = new DataTable();
            //using (Database db = new Database())
            //{
            //    db.Commands.Add(db.CreateCommand("usp_NoACCCek"));
            //    db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
            //    dtceknoacc = db.Commands[0].ExecuteDataTable();
            //}
            //if (dtceknoacc.Rows.Count != 0 && txtNoAcc.Text != "")
            //{
            //    MessageBox.Show("No ACC sudah pernah diinput");
            //    return false;
            //}
            if (formMode == enumFormMode.New)
            {
                DataTable dtceknoacc = new DataTable();
                using (Database db1 = new Database())
                {
                    db1.Commands.Add(db1.CreateCommand("usp_NoACCCek"));
                    db1.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
                    dtceknoacc = db1.Commands[0].ExecuteDataTable();
                }
                if (dtceknoacc.Rows.Count != 0 && txtNoAcc.Text != "")
                {

                    MessageBox.Show("No ACC sudah pernah diinput");
                    return false;

                }
            }

            if (formMode == enumFormMode.Update)
            {
                dt = new DataTable();
                using (Database db2 = new Database())
                {
                    db2.Commands.Add(db2.CreateCommand("usp_PengeluaranUang_LIST"));
                    db2.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db2.Commands[0].ExecuteDataTable();
                }
                String NoAcc = Tools.isNull(dt.Rows[0]["NoAcc"], "").ToString();
                DataTable dtceknoacc = new DataTable();
                using (Database db3 = new Database())
                {
                    db3.Commands.Add(db3.CreateCommand("usp_NoACCCek"));
                    db3.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
                    dtceknoacc = db3.Commands[0].ExecuteDataTable();
                }

                if (dtceknoacc.Rows.Count > 0)
                {
                    String NoAccNew = Tools.isNull(dtceknoacc.Rows[0]["NoAcc"], "").ToString();

                    if (dtceknoacc.Rows.Count != 0 && NoAcc != NoAccNew)
                    {

                        MessageBox.Show("No ACC sudah pernah diinput");
                        return false;

                    }
                }
            }

            if (string.IsNullOrEmpty(cboMataUang.Text.ToString()))
            {
                MessageBox.Show("Mata Uang ID belum dipilih.");
                cboMataUang.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNominal.Text.ToString()) || (double.Parse(txtNominal.Text) == 0))
            {
                MessageBox.Show("Nominal belum diisi");
                txtNominal.Focus();
                return false;
            }

            if (cboMataUang.Text.ToString() != "IDR")
            { 
                if(String.IsNullOrEmpty(txtNominalRp.Text.ToString()) || (double.Parse(txtNominalRp.Text)==0))
                {
                    MessageBox.Show("Nominal Rupiah belum diisi.");
                    txtNominalRp.Focus();
                    return false;
                }
            }

            if (cboPengeluaranKe.Items.Count == 3)
            {
                switch (cboPengeluaranKe.SelectedIndex)
                {
                    case 0:
                        if (string.IsNullOrEmpty(cboCabangKe.Text.ToString()))
                        {
                            MessageBox.Show("Cabang Penerima belum dipilih");
                            cboCabangKe.Focus();
                            return false;
                        }
                        cboVendor.SelectedValue = Guid.Empty;
                        break;
                    case 1:
                        if (string.IsNullOrEmpty(cboVendor.Text.ToString()))
                        {
                            MessageBox.Show("Vendor belum dipilih");
                            cboVendor.Focus();
                            return false;
                        }
                        cboCabangKe.Text = "";
                        break;
                    case 2:
                        if (String.IsNullOrEmpty(cboPerusahaanKe.Text.ToString()))
                        {
                            MessageBox.Show("Perusahaan belum dipilih");
                            cboPerusahaanKe.Focus();
                            return false;
                        }
                        break; 
                }
            }

            if (cboPengeluaranKe.Items.Count == 2)
            {
                switch (cboPengeluaranKe.SelectedIndex)
                {
                    case 0:
                        if (string.IsNullOrEmpty(cboVendor.Text.ToString()))
                        {
                            MessageBox.Show("Vendor Penerima belum diisi");
                            cboVendor.Focus();
                            return false;
                        }
                        cboVendor.SelectedValue = Guid.Empty;
                        break;
                    case 1:
                        if (String.IsNullOrEmpty(cboPerusahaanKe.Text.ToString()))
                        {
                            MessageBox.Show("Perusahaan Penerima belum diisi");
                            cboPerusahaanKe.Focus();
                            return false;
                        }
                        break;

                }
            }


           

            switch (_bentukPengeluaran)
            {
                case "K":
                    if (string.IsNullOrEmpty(cboKas.Text))
                    {
                        MessageBox.Show("Kas harus dipilih.");
                        cboKas.Focus();
                        return false;
                    }
                    break;
                case "B":
                    if (string.IsNullOrEmpty(lkpRekening1.txtSearch.Text))
                    {
                        MessageBox.Show("kode Rekening Bank belum dipilih");
                        lkpRekening1.btnLookUp.Focus();
                        return false;
                    }
                    break;
                case "G":
                    if (string.IsNullOrEmpty(lkpRekening2.txtSearch.Text))
                    {
                        MessageBox.Show("Kode rekeing Bank belum dipilih");
                        lkpRekening2.btnLookUp.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNoGiro.Text.ToString()))
                    {
                        MessageBox.Show("Nomor Giro Belum diisi");
                        txtNoGiro.Focus();
                        return false;
                    }

                    if (String.IsNullOrEmpty(dtDueDateGiro.Text.ToString()))
                    {
                        MessageBox.Show("Tanggal Jatuh Tempo harus diisi.");
                        dtDueDateGiro.Focus();
                        return false;
                    }
                    break;
            }

            if (string.IsNullOrEmpty(cboJnsTransaksi.Text.ToString()))
            {
                MessageBox.Show("Jenis transaksi belum dipilih.");
                cboJnsTransaksi.Focus();
                return false;
            }
            return true;
        }

        private void SimpanData()
        {
            Database db = new Database();
            ///if (CheckValidasiUraian("09"))

            //bool result = false;


            if (IsValid())
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Guid _bankRowID = Guid.Empty;
                    //db.BeginTransaction();
                    switch (_bentukPengeluaran)
                    {
                        case "K": _rekeningRowID = (Guid)cboKas.SelectedValue; break;
                        case "B":
                            {
                                _rekeningRowID = (Guid)lkpRekening1.RekeningRowID;
                                _bankRowID = (Guid)lkpRekening1.BankRowID;
                                break;
                            }
                        case "G":
                            {
                                _rekeningRowID = (Guid)lkpRekening2.RekeningRowID;
                                _bankRowID = (Guid)lkpRekening2.BankRowID;
                                break;
                            }
                        default:
                            _rekeningRowID = (Guid)Guid.Empty;
                            _statusApproval = GlobalVar.enumStatusApproval.Approved;
                            break;
                    }

                    if ((_bentukPengeluaran == "B") && ((Guid)Tools.isNull(_rekeningRowID, Guid.Empty) == Guid.Empty))
                    {
                        MessageBox.Show("Rekening Pengirim kosong / tidak valid");
                        return;
                    }

                    if (txtTanggal.DateValue < GlobalVar.GetBackDatedLockValue())
                    {
                        MessageBox.Show("Tidak boleh input data lebih dari batas waktu input / ubah data");
                        return;
                    }

                   


                    Guid perusahaanDariRowID = (Guid)cboPerusahaan.SelectedValue;
                    Guid perusahaanKeRowID = (Guid)cboPerusahaanKe.SelectedValue;
                    if ((cboPengeluaranKe.SelectedIndex == 0) && ((perusahaanKeRowID == null) || (perusahaanKeRowID == Guid.Empty)))
                    {
                        DataRowView dr = (DataRowView)cboCabangKe.SelectedItem; // .Items[cboCabangKe.SelectedIndex];
                        perusahaanKeRowID = (Guid)dr["PerusahaanRowID"];
                    }

                    Guid _keKasRowID = Guid.Empty;
                    Guid _keRekeningRowID = Guid.Empty;
                    if ((cboPengeluaranKe.SelectedIndex != 1) && (perusahaanDariRowID != perusahaanKeRowID))
                    {

                        if (_bentukPenerimaan == "K") _keKasRowID = (Guid)cboKasTerima.SelectedValue;
                        else _keRekeningRowID = lookUpRekening2.RekeningRowID;//lkpRekening2.RekeningRowID;
                    }
                    //else txtNoRekening.Text = "";

                    if (rdoTrmBank.Checked == true)
                    {
                        if (cboPengeluaranKe.SelectedIndex == 0 || cboPengeluaranKe.SelectedIndex == 1)
                        {
                            if (txtNoRekening.Text == "")
                            {
                                MessageBox.Show("No rekening belum diisi."); txtNoRekening.Focus(); return;
                            }
                        }
                        else
                        {
                            if (!(cboPerusahaanKe.SelectedIndex == 2))
                            {
                                //if (lookUpRekening2.txtSearch.Text.Equals(""))
                                if ((Guid)Tools.isNull(lookUpRekening2.RekeningRowID,Guid.Empty)==Guid.Empty)
                                {
                                    MessageBox.Show("Kode Rekening Bank belum diisi.");
                                    lookUpRekening2.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                if (txtNoRekening.Text == "")
                                {
                                    MessageBox.Show("Nomor Rekening Bank belum diisi.");
                                    txtNoRekening.Focus();
                                    return;
                                }
                            }


                        }
                    }

                    else
                    {
                        if (cboPengeluaranKe.SelectedIndex == 2)
                        {
                            if (cboPerusahaanKe.SelectedIndex != 2)
                            {

                                if (!(cboPerusahaan.Text.ToString().Equals(cboPerusahaanKe.Text.ToString())))
                                {


                                    if (cboKasTerima.Text.ToString().Equals(""))
                                    {
                                       // MessageBox.Show("Kas belum dipilih.");
                                        //cboKasTerima.Focus();
                                        //return;
                                    }
                                }

                            }
                        }


                    }


                    // result = true;
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            //if (Tools.isNull(txtNoBukti.Text, "").ToString() == "")
                            //    txtNoBukti.Text = Numerator.GetNomorDokumen("PENGAJUAN_PENGELUARAN_UANG", "",
                            //        (_needApprove == true) ? "/P/" + string.Format("{0:yyMM}", DateTime.Today) :
                            //                        "/B" + _bentukPengeluaran + "K/" +
                            //                        string.Format("{0:yyMM}", txtTanggal.DateValue)
                            //                        , 3, false, true);
                            DataTable dt1 = new DataTable();
                            _rowID = Guid.NewGuid();
                            //                        using (Database db = new Database())
                            {

                                string str;
                                if ((perusahaanDariRowID == perusahaanKeRowID) || (cboPengeluaranKe.SelectedIndex == 1))
                                {
                                    str = "usp_PengeluaranUang_INSERT";
                                }
                                else
                                { str = "usp_PengeluaranUang_INSERT_ANTAR_PT"; }
                                str = "[usp_PengeluaranUang_INSERT_PLL_TAB2]";
                                db.Commands.Add(db.CreateCommand(str));
                                //db.Commands.Add(db.CreateCommand(((perusahaanDariRowID==perusahaanKeRowID)||(cboPengeluaranKe.SelectedIndex==1))?"usp_PengeluaranUang_INSERT":"usp_PengeluaranUang_INSERT_ANTAR_PT"));
                                //db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                //db.Commands[0].Parameters.Add(new Parameter("PengerimaanRowID",SqlDbType.UniqueIdentifier,
                                //db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, tglrk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, txtNoApproval1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, cboCabangDari.SelectedValue));
                                switch (cboPengeluaranKe.SelectedIndex)
                                {
                                    case 0:
                                        db.Commands[0].Parameters.Add(new Parameter("@CabangKeID", SqlDbType.VarChar, cboCabangKe.SelectedValue));
                                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPerusahaanKe.SelectedValue));
                                        break;
                                    case 1:
                                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, cboVendor.SelectedValue));
                                        break;
                                    case 2:
                                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPerusahaanKe.SelectedValue));
                                        break;
                                }
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJnsTransaksi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalRp.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, _bentukPengeluaran));
                                //if ((cboPengeluaranKe.SelectedIndex != 1) && (perusahaanDariRowID != perusahaanKeRowID))

                                //if (_isNeedApproval || !_isNeedApproval)
                                //{

                                if (cboPerusahaan.SelectedValue.ToString().Equals(cboPerusahaanKe.SelectedValue.ToString() ))
                                {

                                    db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, ""));
                                }
                                else
                                {

                                    if ((rdoTrmKas.Checked == false) && (rdoTrmBank.Checked == false))
                                    {
                                        MessageBox.Show("Jenis pengeluaran ke belum dipilih.");
                                        grpJnsPenerimaan.Focus();
                                        return;
                                    }


                                    db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, _bentukPenerimaan));
                                }

                                //}


                                db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, (_needApprove) ? 0 : 9));
                                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? _rekeningRowID : Guid.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.UniqueIdentifier, _bankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? Guid.Empty : _rekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@KeKasRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? _keKasRowID : Guid.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@KeRekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? Guid.Empty : _keRekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, txtNoRekening.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@DueDateGiro", SqlDbType.Date, dtDueDateGiro.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, (_bentukPengeluaran == "G") ? txtNoGiro.Text : ""));
                                db.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, cboPengeluaranKe.SelectedIndex));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@IsPembayaran", SqlDbType.Bit, checkCF.Checked));

                                //db.Commands[0].ExecuteNonQuery();
                                dt1 = db.Commands[0].ExecuteDataTable();
                                if (dt1.Rows.Count > 0)
                                {
                                    try
                                    {
                                        if (dt1.Rows[0]["Result"].ToString() != "0")
                                        {
                                            MessageBox.Show("Error (" + dt1.Rows[0]["Result"].ToString() + ") : \n" +
                                                             dt1.Rows[0]["Message"].ToString() + "\n");
                                            return;
                                        }
                                    }
                                    catch { /*string s = "Unknown Error";*/ }
                                }
                                //else
                                //{
                                //    if (cboPengeluaranKe.SelectedIndex == 2) SimpanPenerimaan(db);
                                //}

                                //


                                if (_isNeedApproval)
                                {
                                    MessageBox.Show(Messages.Confirm.SaveSuccess);
                                    this.DialogResult = DialogResult.OK;
                                    closeForm();
                                    this.Close();
                                }
                                else
                                {
                                    if (cboPengeluaranKe.SelectedIndex == 2)
                                    {
                                        MessageBox.Show(Messages.Confirm.SaveSuccess);
                                        _perusahaanRowID = (Guid)cboPerusahaan.SelectedValue;
                                        _perusahaanKeRowID = (Guid)cboPerusahaanKe.SelectedValue;
                                        RefreshForward();
                                        ForwardControl();
                                        EditForward();
                                        if (_PLL)
                                        {
                                            if (this.Caller is frmPengeluaranPiutangLainBrowse)
                                            {
                                                frmPengeluaranPiutangLainBrowse frmCaller = (frmPengeluaranPiutangLainBrowse)this.Caller;
                                                frmCaller.RefreshRowDataGridHeaderO(_rowID);
                                            }
                                            cboPerusahaanKe.Enabled = false;
                                        }
                                    }

                                    else
                                    {
                                        MessageBox.Show(Messages.Confirm.SaveSuccess);
                                        this.DialogResult = DialogResult.OK;
                                        closeForm();
                                        this.Close();
                                    }
                                }



                            }
                            break;
                        case enumFormMode.Update:
                            //                        using (Database db = new Database())
                            {
                                string str;
                                if (_isGroup == false)
                                {
                                    str = "usp_PengeluaranUang_UPDATE";
                                }
                                else
                                { str = "usp_PengeluaranUang_UPDATE_ANTAR_PT"; }
                                str = "[usp_PengeluaranUang_UPDATE_PLL_TAB2]";
                                db.Commands.Add(db.CreateCommand(str));
                                //db.Commands.Add(db.CreateCommand((_isGroup) ? "usp_PengeluaranUang_UPDATE_ANTAR_PT" : "usp_PengeluaranUang_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, _groupRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, txtNoAcc.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, tglrk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, txtNoApproval1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPerusahaanKe.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, cboCabangDari.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangKeID", SqlDbType.VarChar, (cboPengeluaranKe.SelectedIndex == 0) ? cboCabangKe.SelectedValue : ""));
                                db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, (cboPengeluaranKe.SelectedIndex == 0) ? Guid.Empty : cboVendor.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJnsTransaksi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalRp.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, _bentukPengeluaran));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, _statusApproval));
                                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? _rekeningRowID : System.Data.SqlTypes.SqlGuid.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.UniqueIdentifier, _bankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? System.Data.SqlTypes.SqlGuid.Null : _rekeningRowID));
                                //if (_isGroup) db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, _bentukPenerimaan));
                                if (cboPerusahaan.SelectedValue.ToString().Equals(cboPerusahaanKe.SelectedValue.ToString()))
                              //  if (cboPerusahaan.Text.ToString().Equals(cboPerusahaanKe.Text.ToString()))
                                {
                                    db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, ""));
                                }
                                else
                                {
                                    if ((rdoTrmKas.Checked == false) && (rdoTrmBank.Checked == false))
                                    {
                                        MessageBox.Show("Jenis pengeluaran ke belum dipilih.");
                                        grpJnsPenerimaan.Focus();
                                        return;
                                    }
                                    db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, _bentukPenerimaan));
                                }

                                db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, txtNoRekening.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, (_bentukPengeluaran == "G") ? txtNoGiro.Text : ""));
                                db.Commands[0].Parameters.Add(new Parameter("@DueDateGiro", SqlDbType.Date, dtDueDateGiro.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, cboPengeluaranKe.SelectedIndex));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@IsPembayaran", SqlDbType.Bit, checkCF.Checked));
                                dt1 = db.Commands[0].ExecuteDataTable();
                                if (dt1.Rows.Count > 0)
                                {
                                    try
                                    {
                                        if (dt1.Rows[0]["Result"].ToString() != "0")
                                        {
                                            MessageBox.Show("Error (" + dt1.Rows[0]["Result"].ToString() + ") : \n" +
                                                             dt1.Rows[0]["Message"].ToString() + "\n");
                                            return;
                                        }
                                    }
                                    catch { /*string s = "Unknown Error"; */ }
                                }
                                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                                if (_PLL)
                                {
                                    if (this.Caller is frmPengeluaranPiutangLainBrowse)
                                    {
                                        frmPengeluaranPiutangLainBrowse frmCaller = (frmPengeluaranPiutangLainBrowse)this.Caller;
                                        frmCaller.RefreshRowDataGridHeaderO(_rowID);
                                        this.Close();
                                    }
                                }
                            }
                            
                            break;
                           
                    }
                    //this.DialogResult = DialogResult.OK;
                    //closeForm();

                    ////this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                    //result = false;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    //if (result) db.CommitTransaction(); else db.RollbackTransaction();
                }
        }

        private void RegexGudangID(String input, String GudangID)
        {

            String pola = "^*("+GudangID+")$*";

            foreach (Match cocok in Regex.Matches(input, pola))
            {
                
                SimpanData();
                IsRegex = 1;
            }


        }

        private void cmdSAVE_Click(object sender, EventArgs e) 
        {
 
            {
                CheckValidasiUraian("09");
            }
            this.Close();
            //if (result)
            //{
            //    //db = new Database();
            //    //db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST_FILTER_NoBukti"));
            //    //db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
            //    //dt = db.Commands[0].ExecuteDataTable();
            //    //if (dt.Rows.Count > 0) _rowID = (Guid)Tools.isNull(dt.Rows[0]["RowID"], Guid.Empty);
            //    formMode = enumFormMode.Update;
            //    RefreshData();
            //}
            //closeForm();
            //                this.Close();
        }

        private void rdoKas_CheckedChanged(object sender, EventArgs e)
        {
            //if (grpJnsPengeluaran.Enabled == true)
            //{
                _bentukPengeluaran = "K";
                show_panelPengeluaran();
            //}
                TabIndexPengeluaranDari("K");
            
        }

        private void rdoBank_CheckedChanged(object sender, EventArgs e)
        {
            //if (grpJnsPengeluaran.Enabled == true)
            //{
                _bentukPengeluaran = "B";
                show_panelPengeluaran();
            //}
                TabIndexPengeluaranDari("B");
                if (cboMataUang.Text.ToString().Equals(""))
                {
                    lkpRekening1.Enabled = false;
                }
                else
                {
                    lkpRekening1.Enabled = true;
                }
        }

        private void rdoGiro_CheckedChanged(object sender, EventArgs e)
        {
            //if (grpJnsPengeluaran.Enabled == true)
            //{
                _bentukPengeluaran = "G";
                show_panelPengeluaran();
            //}
                TabIndexPengeluaranDari("G");
        }

        private void  show_panelPengeluaran()
        {
            pnlKas.Visible = (_bentukPengeluaran == "K");
            pnlBank.Visible = (_bentukPengeluaran == "B");
            pnlGiro.Visible = (_bentukPengeluaran == "G");

            bool _mode_status = ((formMode != enumFormMode.Approve) && _statusApproval == 0);
            if (formMode == enumFormMode.Approve) _mode_status = false;
            else
                if (_needApprove) { if (_statusApproval == GlobalVar.enumStatusApproval.Closed) _mode_status = false; }
                else _mode_status = true;
            if ((formMode == enumFormMode.Update) && (_isGroup)) _mode_status = ((_groupRowID == null) || (_groupRowID == Guid.Empty));
            pnlKas.Enabled = _mode_status;
            pnlBank.Enabled = _mode_status;
            pnlGiro.Enabled = _mode_status;
        }

        private void show_panelPenerimaan()
        {

            if (flagF2 == true)
            {
                pnlTrmKas.Visible = ((cboPengeluaranKe.SelectedIndex == 1) && (_bentukPenerimaan == "K") && (cboPerusahaanKe.SelectedIndex!=2));
                
                pnlTrmBank.Visible = ((cboPengeluaranKe.SelectedIndex == 1) && (_bentukPenerimaan == "B") && (cboPerusahaanKe.SelectedIndex!=2));
                pnlBankLuar.Visible = ((cboPengeluaranKe.SelectedIndex != 1 || cboPerusahaanKe.SelectedIndex==2) && (_bentukPenerimaan == "B"));

                switch (cboPengeluaranKe.SelectedIndex)
                {
                    case 0:
                        {
                            grpJnsPenerimaan.Enabled = true;
                            break;
                        }
                    case 1:
                        {
                            if (cboPerusahaan.Text.ToString().Equals(cboPerusahaanKe.Text.ToString()))
                            {
                                grpJnsPenerimaan.Enabled = false;
                            }
                            else
                            {
                                grpJnsPenerimaan.Enabled = true;

                            }
                            break;
                        }
                }

               


                bool _mode_status = ((formMode != enumFormMode.Approve) && ((_statusApproval == 0) || (!_isNeedApproval)));
                if ((formMode == enumFormMode.Update) && (_isGroup)) _mode_status = ((_groupRowID != null) && (_groupRowID != Guid.Empty));

                //pnlTrmKas.Enabled = _mode_status;
                //pnlTrmBank.Enabled = _mode_status;
                //rdoTrmBank.Enabled = _mode_status;
                //rdoTrmKas.Enabled = _mode_status;
            }
            else
            {
                //pnlTrmKas.Visible = ((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));
                //pnlTrmBank.Visible = ((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "B"));
                //pnlBankLuar.Visible = ((cboPengeluaranKe.SelectedIndex != 2) && (_bentukPenerimaan == "B"));

               
                
                pnlTrmKas.Visible = ((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K") && (cboPerusahaanKe.SelectedIndex!=2));
                pnlTrmBank.Visible = ((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "B") && (cboPerusahaanKe.SelectedIndex!=2));
                pnlBankLuar.Visible = ((cboPengeluaranKe.SelectedIndex != 2 || cboPerusahaanKe.SelectedIndex==2) && (_bentukPenerimaan == "B"));


                //if ((cboPengeluaranKe.SelectedIndex == 2) && (cboPerusahaanKe.SelectedIndex == 2))
                //{
                //    if (rdoTrmKas.Checked == true)
                //    {
                //        pnlTrmKas.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));
                //        pnlTrmBank.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "B"));
                //        pnlBankLuar.Visible = false;//!((cboPengeluaranKe.SelectedIndex != 2) && (_bentukPenerimaan == "B"));
                //    }
                //    else
                //    {
                //        pnlTrmKas.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));
                //        pnlTrmBank.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "B"));
                //        pnlBankLuar.Visible = true;//!((cboPengeluaranKe.SelectedIndex != 2) && (_bentukPenerimaan == "B"));
                //    }


                //}


                if (cboPerusahaan.Text.ToString().Equals(cboPerusahaanKe.Text.ToString()))
                {
                    grpJnsPenerimaan.Enabled = false;
                }
                else
                {
                    
                    grpJnsPenerimaan.Enabled = true;
                    if (cboPerusahaanKe.SelectedIndex != 0)
                    {
                        lookUpRekening2.PerusahaanID = (Guid)cboPerusahaanKe.SelectedValue;
                    }
                }


                //bool _mode_status = ((formMode != enumFormMode.Approve) && ((_statusApproval == 0) || (!_isNeedApproval)));
                //if ((formMode == enumFormMode.Update) && (_isGroup)) _mode_status = ((_groupRowID != null) && (_groupRowID != Guid.Empty));

                pnlTrmKas.Enabled = true; //_mode_status;
                pnlTrmBank.Enabled = true;// _mode_status;
                rdoTrmBank.Enabled = true; //_mode_status;
                rdoTrmKas.Enabled = true; //_mode_status;
            }

      
      
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPengeluaranUangBrowse)
                {
                    frmPengeluaranUangBrowse frmCaller = (frmPengeluaranUangBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("NoBukti", txtNoBukti.Text);
                }
            }
        }

        private void cboJnsPengeluaran_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboJnsTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJnsTransaksi.SelectedIndex > 0)
            {
                string JnsTransaksiID = cboJnsTransaksi.SelectedValue.ToString();
                DataView dvJnsTransaksi = ((DataTable)cboJnsTransaksi.DataSource).DefaultView;
                _needApprove = (bool)dvJnsTransaksi[cboJnsTransaksi.SelectedIndex]["IsNeedApproval"];
                if (formMode == enumFormMode.New) _statusApproval = (_needApprove) ? GlobalVar.enumStatusApproval.Open : GlobalVar.enumStatusApproval.Closed;
                //                if (_statusApproval >= GlobalVar.enumStatusApproval.Closed) _statusApproval = 0;
                if (_needApprove) txtTanggal.Text = "";
                //txtTanggal.Enabled = !_needApprove;
                //txtTanggal.Enabled = false;
            }

            if (cboJnsTransaksi.SelectedIndex > 0)
            {
                DataTable dtcek = new DataTable();
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCek"));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, cboJnsTransaksi.Text));
                    dtcek = db.Commands[0].ExecuteDataTable();
                }
                if (dtcek.Rows.Count != 0)
                {
                    lblnoacc.Visible = true;
                    txtNoAcc.Visible = true;
                }
                else
                {
                    lblnoacc.Visible = false;
                    txtNoAcc.Visible = false;
                    txtNoAcc.Text = "";
                    
                }

            }

            RefreshAcc();

        }

        private void cmdApprov_Click(object sender, EventArgs e)
        {
            Keuangan.frmMutasiUangBrowse ifrmChild = new Keuangan.frmMutasiUangBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if ((_statusApproval == 0) && _needApprove)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {

                        DataTable dt = new DataTable();
                        DataView dvJnsTransaksi = ((DataTable)cboJnsTransaksi.DataSource).DefaultView;
                        db.Commands.Add(db.CreateCommand("usp_AccPengeluaranHirarki_LIST_FILTER_Urutan"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, dvJnsTransaksi[cboJnsTransaksi.SelectedIndex]["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@UrutanAcc", SqlDbType.Int, 1));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            txtPICApprove1.Text = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
                            db.Commands.Clear();
                            dt.Clear();
                            db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_UPDATE_Approve0"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@AccOleh1", SqlDbType.VarChar, txtPICApprove1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        else
                        {
                            MessageBox.Show("Data PIC Tidak ditemukan...");
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
                //                _statusApproval = 1;
                //                RefreshAcc();
                RefreshData();
            }
        }

        #region SetTabIndex

        private void TabIndexPengeluaranKe()
        {
            switch (cboPengeluaranKe.SelectedIndex)
            {
                case 0:
                    {
                        cboCabangKe.TabIndex = 9;
                        break;
                    }
                case 1:
                    {
                        cboVendor.TabIndex = 9;
                        break;
                    }
                case 2:
                    {
                        cboPerusahaanKe.TabIndex = 9;
                        break;
                    }
            }

        }

        private void TabIndexPengeluaranDari(String KeyPengeluaranDari)
        {
            switch (KeyPengeluaranDari)
            {
                case "K":
                    {
                        rdoKas.TabIndex = 12;
                        pnlKas.TabIndex = 13;
                        cboKas.TabIndex = 14;
                        grpJnsPenerimaan.TabIndex = 15;

                        break;
                    }
                case "B":
                    {
                        rdoBank.TabIndex = 12;
                        pnlBank.TabIndex = 13;
                        lkpRekening1.TabIndex = 14;
                        grpJnsPenerimaan.TabIndex = 15;
                        break;
                    }
                case "G":
                    {
                        rdoGiro.TabIndex = 12;
                        pnlGiro.TabIndex = 13;
                        lkpRekening2.TabIndex = 14;
                        txtNoGiro.TabIndex = 15;
                        dtDueDateGiro.TabIndex = 16;
                        grpJnsPenerimaan.TabIndex = 17;
                        break;
                    }
            }
        }

        #endregion

        private void cboPengeluaranKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabIndexPengeluaranKe();
            checkCF.Visible = cboPengeluaranKe.SelectedIndex == 0;
            label16.Visible = cboPengeluaranKe.SelectedIndex == 0;
            if (flagF2 == true)
            {
                switch (cboPengeluaranKe.SelectedIndex)
                {
                    case 0: 
                        {
                            cboVendor.Visible = true;
                            cboVendor.Enabled = true;
                            cboPerusahaanKe.Visible = false;
                            cboPerusahaanKe.Enabled = false;
                            grpJnsPenerimaan.Enabled = true;
                            break;
                        }
                    case 1:
                        {
                            cboVendor.Visible = false;
                            cboVendor.Enabled = false;
                            cboPerusahaanKe.Visible = true;
                            fcbo.fillComboPerusahaan(cboPerusahaanKe);
                            cboPerusahaanKe.SelectedValue = (Guid)cboPerusahaan.SelectedValue;
                            break;
                        }
                }

               
               
            }
            else
            {
                cboCabangKe.Visible = (cboPengeluaranKe.SelectedIndex == 0);
                cboVendor.Visible = (cboPengeluaranKe.SelectedIndex == 1);
                cboPerusahaanKe.Visible = (cboPengeluaranKe.SelectedIndex == 2);

                //grpJnsPenerimaan.Visible = (cboPengeluaranKe.SelectedIndex != 1);
                grpJnsPenerimaan.Enabled = true;
                //!((formMode == enumFormMode.Update) && (_isGroup)); // && ((Guid)Tools.isNull(_groupRowID,Guid.Empty)!=Guid.Empty)
               // cboCabangKe.SelectedIndex = 0;
                cboPerusahaanKe.SelectedIndex = 0;
                cboVendor.SelectedIndex = 0;
                cboCabangKe.Refresh();
                cboVendor.Refresh();
                cboPengeluaranKe.Refresh();
            }
            
            
//         

            show_panelPenerimaan();
        }

        private void grpApproval_Enter(object sender, EventArgs e)
        {

        }

        private void RefreshAcc()
        {
            bool _modeApproved = (formMode == enumFormMode.Approve);
            grpApproval.Visible = _needApprove;
            //(_modeApproved || ((_needApprove==true) && (_statusApproval<GlobalVar.enumStatusApproval.Approved)));
            lblStatusAcc.Text = Tools.DescStatusApproval(_statusApproval);
            cmdSubmit.Visible = ((formMode != enumFormMode.New) && (_statusApproval == 0) && ((Guid)Tools.isNull(_groupRowID,Guid.Empty)==Guid.Empty));
            pnlAcc1.Visible = (_needApprove && _statusApproval >= GlobalVar.enumStatusApproval.Waiting1);
            pnlAcc2.Visible = (_needApprove && _statusApproval >= GlobalVar.enumStatusApproval.Waiting2);

            _modeApproved = (_modeApproved && ((Guid)Tools.isNull(_groupRowID,Guid.Empty)==Guid.Empty));

            cmdSubmitAcc1.Visible = (_modeApproved && (_statusApproval == GlobalVar.enumStatusApproval.Waiting1) && (txtPICApprove1.Text.Trim() == SecurityManager.UserID.Trim()));
            cmdRejectAcc1.Visible = (_modeApproved && (_statusApproval == GlobalVar.enumStatusApproval.Waiting1) && (txtPICApprove1.Text.Trim() == SecurityManager.UserID.Trim()));

            cmdSubmitAcc2.Visible = (_modeApproved && (_statusApproval == GlobalVar.enumStatusApproval.Waiting2) && (txtPICApprove2.Text.Trim() == SecurityManager.UserID.Trim()));
            cmdRejectAcc2.Visible = (_modeApproved && (_statusApproval == GlobalVar.enumStatusApproval.Waiting2) && (txtPICApprove2.Text.Trim() == SecurityManager.UserID.Trim()));

            txtAccKeterangan.Enabled = (formMode == enumFormMode.Approve);

            //            cmdSAVE.Visible = (formMode != enumFormMode.Approve);
        }

        private void cmdSubmitAcc1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Disetujui ?", "Acc", MessageBoxButtons.OKCancel);
            Process_Approved1(true);
        }

        private void cmdRejectAcc1_Click(object sender, EventArgs e)
        {
            Process_Approved1(false);
        }

        private void Process_Approved1(bool IsApproved)
        {
            if ((_statusApproval == GlobalVar.enumStatusApproval.Waiting1) && _needApprove)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {

                        DataTable dt = new DataTable();
                        DataView dvJnsTransaksi = ((DataTable)cboJnsTransaksi.DataSource).DefaultView;
                        GlobalVar.enumStatusApproval statusApprove = _statusApproval;
                        db.Commands.Add(db.CreateCommand("usp_AccPengeluaranHirarki_LIST_FILTER_Urutan"));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, dvJnsTransaksi[cboJnsTransaksi.SelectedIndex]["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@UrutanAcc", SqlDbType.Int, 2));
                        dt = db.Commands[0].ExecuteDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            txtPICApprove2.Text = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
                            statusApprove = (IsApproved == true) ? GlobalVar.enumStatusApproval.Waiting2 : GlobalVar.enumStatusApproval.Rejected;
                        }
                        else statusApprove = (IsApproved == true) ? GlobalVar.enumStatusApproval.Approved : GlobalVar.enumStatusApproval.Rejected;
                        db.Commands.Clear();
                        dt.Clear();

                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_UPDATE_Approve1"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@AccOleh2", SqlDbType.VarChar, txtPICApprove2.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, statusApprove));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();

                        _statusApproval = statusApprove;
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
                _statusApproval = GlobalVar.enumStatusApproval.Waiting1;
                closeForm();
                RefreshData();
            }
        }

        private void Process_Approved2(bool IsApproved)
        {
            if ((_statusApproval == GlobalVar.enumStatusApproval.Waiting2) && _needApprove)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {

                        DataTable dt = new DataTable();
                        DataView dvJnsTransaksi = ((DataTable)cboJnsTransaksi.DataSource).DefaultView;
                        GlobalVar.enumStatusApproval statusApprove = (IsApproved == true) ? GlobalVar.enumStatusApproval.Approved : GlobalVar.enumStatusApproval.Rejected;
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_UPDATE_Approve2"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, statusApprove));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();

                        _statusApproval = statusApprove;
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
                _statusApproval = GlobalVar.enumStatusApproval.Waiting1;
                closeForm();
                RefreshData();
            }
        }

        private void cmdSubmitAcc2_Click(object sender, EventArgs e)
        {
            Process_Approved2(true);
        }

        private void cmdRejectAcc2_Click(object sender, EventArgs e)
        {
            Process_Approved2(false);
        }

        private void cmdRealisasi_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tgl = GlobalVar.GetServerDate;
                string _noTemp;
                _noTemp = txtNoBukti.Text;
                txtTanggal.DateValue = GlobalVar.GetServerDate;

                using (Database db = new Database())
                {
                    //_noBukti = Numerator.GetNomorDokumen("PENGAJUAN_PENGELUARAN_UANG", "",
                    //                    "/B" + _bentukPengeluaran + "K/" +
                    //                    string.Format("{0:yyMM}", txtTanggal.DateValue)
                    //                    , 3, false, true);

                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_UPDATE_Realisasi"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    //db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, _noBukti));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0) 
                    {
                        string Result = Tools.isNull(dt.Rows[0]["Result"],"").ToString();
                        if (Result=="0")
                            _statusApproval = GlobalVar.enumStatusApproval.Closed;
                        else 
                            MessageBox.Show("Error No. : " + Result + "\n" + 
                                             Tools.isNull(dt.Rows[0]["Message"],"").ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            RefreshData();
        }

        private void rdoTrmKas_CheckedChanged(object sender, EventArgs e)
        {
            if (grpJnsPenerimaan.Enabled == true)
            {
                _bentukPenerimaan = "K";
                show_panelPenerimaan();
            }
            
        }

        private void rdoTrmBank_CheckedChanged(object sender, EventArgs e)
        {
            if (grpJnsPenerimaan.Enabled == true)
            {
                    _bentukPenerimaan = "B";
                    show_panelPenerimaan();
                   
                    
            }
        }

        private void RefreshRekeningPerusahaanKe()
        {
            lookUpRekening2.txtSearch.Text = String.Empty;
            lookUpRekening2.lblNoRekening.Text = String.Empty;
            lookUpRekening2.lblBank.Text = String.Empty;
        }

        private void cboPerusahaanKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            RefreshRekeningPerusahaanKe();
            LoadComboKas();

            if (_isNeedApproval == false)
            {
                if (!(cboPerusahaanKe.Text.ToString().Equals("")))
                {

                    fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, false);
                    show_panelPenerimaan();
                    //if (cboPerusahaanKe.Text.ToString().Equals(cboPerusahaan.Text.ToString()))
                    //{
                    //    fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, false);
                    //    show_panelPenerimaan();
                        
                    //}
                    //else
                    //{
                    //    fcbo.fillComboJnsTransaksiDIFFER_Pengeluaran(cboJnsTransaksi, false);
                    //    show_panelPenerimaan();

                    //}
                    //cboJnsTransaksi.Enabled = true;
                }
                else { cboJnsTransaksi.DataSource = null; cboJnsTransaksi.Enabled = false; }
            }
            else
            {
                if (!(cboPerusahaanKe.Text.ToString().Equals("")))
                {


                    fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, true);
                       show_panelPenerimaan();
                    //if (cboPerusahaanKe.Text.ToString().Equals(cboPerusahaan.Text.ToString()))
                    //{
                    //    fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, true);
                    //    show_panelPenerimaan();


                    //}
                    //else
                    //{
                    //    fcbo.fillComboJnsTransaksiDIFFER_Pengeluaran(cboJnsTransaksi, true);
                    //    show_panelPenerimaan();

                    //}
                    //cboJnsTransaksi.Enabled = true;
                }
                else { cboJnsTransaksi.DataSource = null; cboJnsTransaksi.Enabled = false; }
            }

           // if (Guid_JnsTrans != null) cboJnsTransaksi.SelectedValue = Guid_JnsTrans;
           
            if (_PLL  )
            {
                cboJnsTransaksi.SelectedValue = _GPLL;
                cboJnsTransaksi.Enabled = false;

            }
        }

        private void LoadComboKas()
        {
            
            fcbo.fillComboKas(cboKasTerima, Guid.Empty);

            switch(cboPengeluaranKe.Items.Count)
            {
                case 2:
                    {

                        switch (cboPengeluaranKe.SelectedIndex)
                        {
                           
                            case 0:
                                {
                                    if (cboVendor.SelectedIndex != 0)
                                    {

                                        fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaan.SelectedValue);

                                    }
                                    else
                                    {

                                        fcbo.fillComboKas(cboKasTerima, Guid.Empty);

                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (cboPerusahaanKe.SelectedIndex != 0)
                                    {

                                        if (cboPerusahaanKe.SelectedIndex != 2)
                                        {
                                            if (cboPerusahaanKe.SelectedIndex != 1)
                                            {
                                                // fcbo.fillComboKas(cboKas, (Guid)(cboPerusahaan.SelectedValue));
                                                fcbo.fillComboKas(cboKasTerima, (Guid)(cboPerusahaanKe.SelectedValue));
                                                //cboKasTerima.Visible = true;
                                            }
                                            else
                                            {
                                                //fcbo.fillComboKas(cboKas, (Guid)(cboPerusahaan.SelectedValue));
                                                fcbo.fillComboKas(cboKasTerima, (Guid)(cboPerusahaan.SelectedValue));
                                                // cboKasTerima.Visible = true;
                                            }

                                            //rdoTrmKas.Checked = true;
                                            //pnlTrmKas.Visible = true;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));


                                        }
                                        else
                                        {
                                            //rdoTrmKas.Checked = true;
                                            //pnlTrmKas.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));
                                            //pnlTrmBank.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "B"));
                                            //pnlBankLuar.Visible = true;//!((cboPengeluaranKe.SelectedIndex != 2) && (_bentukPenerimaan == "B"));


                                            //fcbo.fillComboKas(cboKas, (Guid)(cboPerusahaan.SelectedValue));
                                            fcbo.fillComboKas(cboKasTerima, Guid.Empty);
                                            //cboKasTerima.Visible = false;
                                        }


                                    }
                                    else
                                    {
                                        //fcbo.fillComboKas(cboKas, Guid.Empty);
                                        fcbo.fillComboKas(cboKasTerima, Guid.Empty);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {

                        switch (cboPengeluaranKe.SelectedIndex)
                        {
                            case 0:
                                {
                                    //              cboPengeluaranKe.Items.Add("Ke Cabang");
                                    //cboPengeluaranKe.Items.Add("Ke Vendor");
                                    //cboPengeluaranKe.Items.Add("Ke Perusahaan");



                                    if (cboCabangKe.SelectedIndex != 0)
                                    {
                                        fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaan.SelectedValue);

                                    }
                                    else
                                    {
                                        fcbo.fillComboKas(cboKasTerima, Guid.Empty);
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (cboVendor.SelectedIndex != 0)
                                    {

                                        fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaan.SelectedValue);

                                    }
                                    else
                                    {

                                        fcbo.fillComboKas(cboKasTerima, Guid.Empty);

                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (cboPerusahaanKe.SelectedIndex != 0)
                                    {

                                        if (cboPerusahaanKe.SelectedIndex != 2)
                                        {
                                            if (cboPerusahaanKe.SelectedIndex != 1)
                                            {
                                                // fcbo.fillComboKas(cboKas, (Guid)(cboPerusahaan.SelectedValue));
                                                fcbo.fillComboKas(cboKasTerima, (Guid)(cboPerusahaanKe.SelectedValue));
                                                //cboKasTerima.Visible = true;
                                            }
                                            else
                                            {
                                                //fcbo.fillComboKas(cboKas, (Guid)(cboPerusahaan.SelectedValue));
                                                fcbo.fillComboKas(cboKasTerima, (Guid)(cboPerusahaan.SelectedValue));
                                                // cboKasTerima.Visible = true;
                                            }

                                            //rdoTrmKas.Checked = true;
                                            //pnlTrmKas.Visible = true;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));


                                        }
                                        else
                                        {
                                            //rdoTrmKas.Checked = true;
                                            //pnlTrmKas.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "K"));
                                            //pnlTrmBank.Visible = false;//!((cboPengeluaranKe.SelectedIndex == 2) && (_bentukPenerimaan == "B"));
                                            //pnlBankLuar.Visible = true;//!((cboPengeluaranKe.SelectedIndex != 2) && (_bentukPenerimaan == "B"));


                                            //fcbo.fillComboKas(cboKas, (Guid)(cboPerusahaan.SelectedValue));
                                            fcbo.fillComboKas(cboKasTerima, Guid.Empty);
                                            //cboKasTerima.Visible = false;
                                        }


                                    }
                                    else
                                    {
                                        //fcbo.fillComboKas(cboKas, Guid.Empty);
                                        fcbo.fillComboKas(cboKasTerima, Guid.Empty);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }



           
        }

        private DataTable GetListGudangID(String CabangID)
        { 
                    DataTable dt = new DataTable();
                    using(Database db=new Database())
                    {
                        db.Commands.Add(db.CreateCommand("GetGudangID_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, CabangID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    return dt;
        }

        private void AppendUraian(String CabID)
        {
            if (cboCabangKe.SelectedIndex != 0)
            {

                String textAppend =CabID+" ";
                int strLength = textAppend.Length;
                String ComboCabangID = cboCabangKe.Text.ToString().Substring(0, 2);
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

        private void cboCabangKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppendUraian("09");
            

            LoadComboKas();

            if (_isNeedApproval == false)
            {
                
                if (!(cboCabangKe.Text.ToString().Equals("")))
                {
                   
                    if (!(cboCabangDari.Text.ToString().Equals(cboCabangKe.Text.ToString())))
                    {
                        fcbo.fillComboJnsTransaksiDIFFER_Pengeluaran(cboJnsTransaksi, false);
                    }
                    cboJnsTransaksi.Enabled = true;

                }
                else
                {
                    cboJnsTransaksi.DataSource = null; cboJnsTransaksi.Enabled = false;

                }
            }
            else
            {
                if (!(cboCabangKe.Text.ToString().Equals("")))
                {

                   

                    if (!(cboCabangDari.Text.ToString().Equals(cboCabangKe.Text.ToString())))
                    {
                        fcbo.fillComboJnsTransaksiDIFFER_Pengeluaran(cboJnsTransaksi, true);
                    }
                    cboJnsTransaksi.Enabled = true;

                }
                else
                {
                    cboJnsTransaksi.DataSource = null; cboJnsTransaksi.Enabled = false;

                }
            }

       
     
            
        }

        private void cboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboKas();
            if (!(cboVendor.Text.ToString().Equals("")))
            {
                
                    fcbo.fillComboJnsTransaksi(cboJnsTransaksi);
                    cboJnsTransaksi.Enabled = true;


                    if (!_PLL && cboVendor.Text.ToString() != "")
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
            else { cboJnsTransaksi.DataSource = null; cboJnsTransaksi.Enabled = false; }
        }

        #region RefreshCboMataUangID

        private void RefreshCboMataUangID()
        {

            lkpRekening1.txtSearch.Text = String.Empty;
            lkpRekening1.lblNoRekening.Text = String.Empty;
            lkpRekening1.lblBank.Text = String.Empty;
            lkpRekening2.txtSearch.Text = String.Empty;
            lkpRekening2.lblNoRekening.Text = String.Empty;
            lkpRekening2.lblBank.Text = String.Empty;
            lookUpRekening2.txtSearch.Text = String.Empty;
            lookUpRekening2.lblNoRekening.Text = String.Empty;
            lookUpRekening2.lblBank.Text = String.Empty;
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

        private void cboMataUang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNominal.Text = "0";
            txtNominalRp.Text ="0";
            if (cboMataUang.Text.ToString().Equals(""))
            {
                lkpRekening1.Enabled = false;
            }
            else
            {
                lkpRekening1.Enabled = true;
            }

            // 5 Jun 2012 by Eko : sementara bisa diedit klu matauang bukan IDR
            txtNominalRp.Enabled = (cboMataUang.Text != "IDR");
            numKurs.Enabled = txtNominalRp.Enabled;

            GetCurrencyRate();
            HitungKurs();
        }

        private void txtTanggal_TextChanged(object sender, EventArgs e)
        {
            //ValidasiTanggalTransaksi(_tanggal, _HIRowID, _JournalRowID);
            GetCurrencyRate();
            HitungKurs();
        }

        #region Forward pengeluaran uang



        private void RefreshForward()
        { 
        
            // try
            //{
            
                Guid PtDari=Guid.Empty;
                Guid PtKe=Guid.Empty;
                this.Cursor = Cursors.WaitCursor;
                _rekeningRowID = Guid.Empty;
                //if ((formMode == enumFormMode.Update) || (formMode == enumFormMode.Approve))
                //{
                    //retrieving data
                   
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                 
                     
                    txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                    txtNoBukti.Enabled = false;
                    if (dt.Rows[0]["Tanggal"] == System.DBNull.Value) txtTanggal.Text = "";
                    else txtTanggal.DateValue = (DateTime)(dt.Rows[0]["Tanggal"]);
                    txtNoApproval1.Text = Tools.isNull(dt.Rows[0]["NoApproval"], "").ToString();
                    PtDari = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanDariRowID"], Guid.Empty);
                    cboPerusahaan.SelectedValue =PtDari; 
                    cboCabangDari.SelectedValue = Tools.isNull(dt.Rows[0]["CabangDariID"], "").ToString();
                    
                    cboVendor.SelectedValue = Tools.isNull(dt.Rows[0]["VendorRowID"], Guid.Empty);
                    cboMataUang.SelectedValue = Tools.isNull(dt.Rows[0]["MataUangRowID"], Guid.Empty);
                    txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();
                    txtNominalRp.Text = Tools.isNull(dt.Rows[0]["NominalRp"], "").ToString();
                    txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                    _bentukPengeluaran = Tools.isNull(dt.Rows[0]["JnsPengeluaran"], "").ToString();
                    _bentukPenerimaan = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();
                   
                    _rekeningRowID = (Guid)(Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty));
                    _statusApproval = (GlobalVar.enumStatusApproval)(int.Parse(Tools.isNull(dt.Rows[0]["StatusApproval"], "").ToString()));

                    int PengeluaranKe;
                    PengeluaranKe = int.Parse(dt.Rows[0]["PengeluaranKe"].ToString());
                    
                    if (PengeluaranKe == 1)
                    {
                        fcbo.fillComboVendor(cboVendor);
                        Guid Guid_vendor;
                        Guid_vendor = (Guid)Tools.isNull(dt.Rows[0]["VendorRowID"], Guid.Empty);
                        //fcbo.fillComboVendor(cboVendor, Guid_vendor);
                        cboVendor.SelectedValue = Guid_vendor;
                    }
                    else if(PengeluaranKe==2)
                    {
                        fcbo.fillComboPerusahaan(cboPerusahaanKe);
                        PtKe = (Guid)Tools.isNull(dt.Rows[0]["PerusahaanKeRowID"], Guid.Empty);
                        cboPerusahaanKe.SelectedValue = PtKe;
                    }

                    cboPengeluaranKe.SelectedIndex = PengeluaranKe;


                    if (_bentukPengeluaran == "K")
                    {

                        fcbo.fillComboKas(cboKas, (Guid)cboPerusahaan.SelectedValue);

                        Guid KasRowID;
                        KasRowID = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                        cboKas.SelectedValue = KasRowID;

                    }
                    else
                    {
                        fcbo.fillComboKas(cboKas, (Guid)cboPerusahaan.SelectedValue);
                    }
                    
                    if (_bentukPengeluaran == "B") lkpRekening1.SetRekeningRowID(_rekeningRowID); 
                    if (_bentukPengeluaran == "G") lkpRekening2.SetRekeningRowID(_rekeningRowID); 
                    txtNoGiro.Text = Tools.isNull(dt.Rows[0]["NoCekGiro"], "").ToString();
                    if (dt.Rows[0]["DueDateGiro"] != System.DBNull.Value) dtDueDateGiro.DateValue = (DateTime)(dt.Rows[0]["DueDateGiro"]);
                    if (_bentukPenerimaan == "K")
                    {
                        fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaanKe.SelectedValue);
                        Guid KasRowID;
                        KasRowID = (Guid)Tools.isNull(dt.Rows[0]["KeKasRowID"], Guid.Empty);
                        cboKasTerima.SelectedValue = KasRowID;
                        txtNoRekening.Text = "";
                    }
                    else
                    {
                        fcbo.fillComboKas(cboKasTerima, (Guid)cboPerusahaanKe.SelectedValue);
                        
                    }


                    if (_bentukPenerimaan == "B")
                    {
                        lookUpRekening2.SetRekeningRowID((Guid)Tools.isNull(dt.Rows[0]["KeRekeningRowID"], Guid.Empty));
                        txtNoRekening.Text = Tools.isNull(dt.Rows[0]["NoRekening"], "").ToString();
                    } 
                    
                  


                   Guid groupRowID = (Guid)Tools.isNull(dt.Rows[0]["GroupRowID"], Guid.Empty);
                   if (groupRowID.Equals(Guid.Empty))
                   {
                       _groupRowID = Guid.Empty;
                   }

                   Guid Guid_JnsTrans;
                   Guid_JnsTrans = (Guid)Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], Guid.Empty);
                   cboJnsTransaksi.Enabled = false;
                   cboJnsTransaksi.SelectedValue = Guid_JnsTrans;      

                    //Approve #1
                    txtPICApprove1.Text = Tools.isNull(dt.Rows[0]["AccOleh1"], "").ToString();
                    txtNoApproval1.Text = Tools.isNull(dt.Rows[0]["AccNo1"], "").ToString();
                    dtTanggalApproval1.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["AccTanggal1"], DateTime.MinValue);

                    //Approve #2
                    txtPICApprove2.Text = Tools.isNull(dt.Rows[0]["AccOleh2"], "").ToString();
                    txtNoApproval2.Text = Tools.isNull(dt.Rows[0]["AccNo2"], "").ToString();
                    dtTanggalApproval2.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["AccTanggal1"], DateTime.MinValue);

                   
                   // disabled();

                    //rdoTrmBank.Checked = (_bentukPenerimaan != "K");
                    rdoTrmBank.Checked = (_bentukPenerimaan == "B");
                    rdoTrmKas.Checked = (_bentukPenerimaan == "K");

                    _isGroup = (bool)Tools.isNull(dt.Rows[0]["IsGroup"], false);

                    //EditControl(_isGroup);

                    //if (PtDari.Equals(PtKe))
                    //{
                    //    grpJnsPenerimaan.Enabled = false;
                    //}
                    //show_panelPenerimaan();
                    //else
                    //{ grpJnsPenerimaan.Enabled = true; }
                //}
        }


        private void EditForward()
        {
            formMode = enumFormMode.Update;
            txtTanggal.Enabled = false;
            cboMataUang.Enabled = true;
            txtNominal.Enabled = true;
            if (cboMataUang.Text.ToString() == "IDR")
            {
                txtNominalRp.Enabled = false;
            }
            else
            {
                txtNominalRp.Enabled = true;    
            }
            
            txtUraian.Enabled = true;
            rdoKas.Enabled = true;
            rdoBank.Enabled = true;
            rdoGiro.Enabled = true;
            cboKas.Enabled = true;
            cmdSaveF2.Visible = false;
            txtNoGiro.Enabled = true;
            dtDueDateGiro.Enabled = true;



            cboCabangDari.Enabled = false;
            cboPerusahaan.Enabled = false;
            cboPengeluaranKe.Enabled = false;
            cboPerusahaanKe.Enabled = !((formMode == enumFormMode.Update) && (_isGroup));
            //show_panelPengeluaran();
            //show_panelPenerimaan();

        }

        private void ForwardInputan()
        {

            Guid RowIDKas=Guid.Empty;
            Guid RowIDRekening=Guid.Empty;
            txtNoBukti.Text = String.Empty;

            
            cboPengeluaranKe.Items.RemoveAt(0);
            fcbo.fillComboPerusahaan(cboPerusahaan);
            RowIDKas =(Guid)cboKasTerima.SelectedValue;
            RowIDRekening=(Guid)lookUpRekening2.RekeningRowID;
            cboPerusahaan.SelectedValue = (Guid)cboPerusahaanKe.SelectedValue;
            fcbo.fillComboPerusahaan(cboPerusahaanKe);
            cboPerusahaanKe.SelectedValue = (Guid)cboPerusahaan.SelectedValue;

            lkpRekening1.PerusahaanID = (Guid)cboPerusahaan.SelectedValue;

            fcbo.fillComboKas(cboKas, (Guid)cboPerusahaan.SelectedValue);
            if (rdoTrmKas.Checked == true)
            {
                rdoKas.Checked = true;
                cboKas.SelectedValue = RowIDKas;
            }
            else
            {
                rdoBank.Checked = true;
                lkpRekening1.SetRekeningRowID(RowIDRekening);
            }

                      
            cboPengeluaranKe.Enabled = true;
            cboPerusahaanKe.Enabled = false;
            cboJnsTransaksi.Enabled = true;
            txtTanggal.Enabled = true;
            txtNominal.Enabled = false;
            txtNominalRp.Enabled = false;
            txtUraian.Enabled = false;
            grpJnsPengeluaran.Enabled = true;
            cmdForward.Visible = false;
            cboMataUang.Enabled = true;
            lblJenisTransaksi.Enabled = true;
            rdoKas.Enabled = true;
            rdoBank.Enabled = true;
            rdoGiro.Enabled = true;
            cboKas.Enabled = true;
            cmdSaveF2.Visible = true;
            cmdSAVE.Visible = false;
            cmdSaveF2.Focus();
            cboMataUang.Enabled = false;
            txtNoGiro.Enabled = true;
            dtDueDateGiro.Enabled = true;



            cboCabangDari.Enabled = false;
            cboPerusahaan.Enabled = false;

            cboPerusahaanKe.Enabled = !((formMode == enumFormMode.Update) && (_isGroup));
            //show_panelPengeluaran();
            //show_panelPenerimaan();

            rdoTrmKas.Checked = false;
            rdoTrmBank.Checked = false;
            
            

        }


        private void UnForwardControl()
        {
            cmdSAVE.Visible = true;
            cmdSaveF2.Visible = false;
            cmdForward.Enabled = false;

        }


        private void ForwardControl()
        {
            if (_ForwardDariPenerimaan.Equals(true))
            {
                Close();

            }
            else
            {
                cmdSAVE.Visible = false;
                cmdSaveF2.Visible = false;
                cmdForward.Enabled = ((cboPengeluaranKe.SelectedIndex == 2) && (_perusahaanRowID != _perusahaanKeRowID));
                //cboJnsTransaksi.Enabled = false;
            }
            
        }


        private void cmdForward_Click(object sender, EventArgs e)
        {
            this.Title =this.Title + " [FORWARD]"; 
                flagF2 = true;
                ForwardInputan();
                //fcbo.fillComboJnsTransaksiEQUAL(cboJnsTransaksi, false);
        }


        


        private void cmdSaveF2_Click(object sender, EventArgs e)
        {
            //bool result = false;
            Database db = new Database();

            if (IsValid())
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Guid _bankRowID = Guid.Empty;
                   
                    switch (_bentukPengeluaran)
                    {
                        case "K": _rekeningRowID = (Guid)cboKas.SelectedValue; break;
                        case "B":
                            {
                                _rekeningRowID = (Guid)lkpRekening1.RekeningRowID;
                                _bankRowID = (Guid)lkpRekening1.BankRowID;
                                break;
                            }
                        case "G":
                            {
                                _rekeningRowID = (Guid)lkpRekening2.RekeningRowID;
                                _bankRowID = (Guid)lkpRekening2.BankRowID;
                                break;
                            }
                        default:
                            _rekeningRowID = (Guid)Guid.Empty;
                            _statusApproval = GlobalVar.enumStatusApproval.Approved;
                            break;
                    }

                    if ((_bentukPengeluaran == "B") && ((Guid)Tools.isNull(_rekeningRowID, Guid.Empty) == Guid.Empty))
                    {
                        MessageBox.Show("NoRekening masih kosong / tidak ditemukan");
                        return;
                    }

                    Guid perusahaanDariRowID = (Guid)cboPerusahaan.SelectedValue;
                    Guid perusahaanKeRowID = (Guid)cboPerusahaanKe.SelectedValue;
                    if ((cboPengeluaranKe.SelectedIndex == 0) && ((perusahaanKeRowID == null) || (perusahaanKeRowID == Guid.Empty)))
                    {
                        DataRowView dr = (DataRowView)cboCabangKe.SelectedItem; 
                        perusahaanKeRowID = (Guid)dr["PerusahaanRowID"];
                    }

                    Guid _keKasRowID = Guid.Empty;
                    Guid _keRekeningRowID = Guid.Empty;
                    if ((cboPengeluaranKe.SelectedIndex != 1) && (perusahaanDariRowID != perusahaanKeRowID))
                    {

                        if (_bentukPenerimaan == "K") _keKasRowID = (Guid)cboKasTerima.SelectedValue;
                        else _keRekeningRowID = lookUpRekening2.RekeningRowID;
                    }


                    if ((_bentukPenerimaan == "B") && (cboPengeluaranKe.SelectedIndex == 2) &&
                            ((Guid)Tools.isNull(_keRekeningRowID, Guid.Empty) == Guid.Empty))
                    {
                        MessageBox.Show("Rekening Penerima masih kosong / tidak valid");
                        return;
                    }
                    if (rdoTrmBank.Checked == true)
                    {
                        if (cboPengeluaranKe.SelectedIndex == 0 || cboPengeluaranKe.SelectedIndex == 1)
                        {
                            if (txtNoRekening.Text == "")
                            {
                                MessageBox.Show("No rekening belum diisi."); txtNoRekening.Focus(); return;
                            }
                        }
                        else
                        {
                            if (!(cboPerusahaanKe.SelectedIndex == 2))
                            {
                                if (lookUpRekening2.txtSearch.Text.Equals(""))
                                {
                                    MessageBox.Show("Kode Rekening Bank belum diisi.");
                                    lookUpRekening2.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                if (txtNoRekening.Text == "")
                                {
                                    MessageBox.Show("Nomor Rekening Bank belum diisi.");
                                    txtNoRekening.Focus();
                                    return;
                                }
                            }


                        }
                    }

                    else
                    {
                        if (cboPengeluaranKe.SelectedIndex == 2)
                        {
                            if (cboPerusahaanKe.SelectedIndex != 2)
                            {

                                if (!(cboPerusahaan.Text.ToString().Equals(cboPerusahaanKe.Text.ToString())))
                                {


                                    if (cboKasTerima.Text.ToString().Equals(""))
                                    {
                                        MessageBox.Show("Kas belum dipilih.");
                                        cboKasTerima.Focus();
                                        return;
                                    }
                                }

                            }
                        }


                    }
                    
                    
                     
                            DataTable dt1 = new DataTable();
                            _RowIDForward = Guid.NewGuid();
                           
                            {

                                string str;
                                //bool bQuery=false;
                                if ((perusahaanDariRowID == perusahaanKeRowID) || (cboPengeluaranKe.SelectedIndex == 0))
                                {
                                    str = "usp_PengeluaranUang_INSERT"; //bQuery = true;
                                }
                                else
                                { str = "usp_PengeluaranUang_INSERT_ANTAR_PT"; }
                                db.Commands.Add(db.CreateCommand(str));
                                
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDForward));
                                //if (bQuery == true)
                                //{
                                //    db.Commands[0].Parameters.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, _rowID));    
                                //}
                                db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, tglrk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, txtNoAcc.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, txtNoApproval1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, cboPerusahaan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, cboCabangDari.SelectedValue));
                                switch (cboPengeluaranKe.Text.ToString())
                                {
                                                                         
                                    case "Ke Vendor":
                                        _pengeluaranKe = 1;
                                        db.Commands[0].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, cboVendor.SelectedValue));
                                        break;
                                    case "Ke Perusahaan":
                                        _pengeluaranKe = 2;
                                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPerusahaanKe.SelectedValue));
                                        break;
                                }
                                db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, cboMataUang.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, cboJnsTransaksi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominal.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalRp.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, _bentukPengeluaran));
                               
                                if (cboPerusahaan.Text.ToString().Equals(cboPerusahaanKe.Text.ToString()))
                                {

                                    db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, ""));
                                }
                                else
                                {

                                    if ((rdoTrmKas.Checked == false) && (rdoTrmBank.Checked == false))
                                    {
                                        MessageBox.Show("Jenis pengeluaran ke belum dipilih.");
                                        grpJnsPenerimaan.Focus();
                                        return;
                                    }


                                    db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, _bentukPenerimaan));
                                }

                                //}



                                db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, (_needApprove) ? 0 : 9));
                                db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? _rekeningRowID : Guid.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.UniqueIdentifier, _bankRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? Guid.Empty : _rekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@KeKasRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? _keKasRowID : Guid.Empty));
                                db.Commands[0].Parameters.Add(new Parameter("@KeRekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPenerimaan == "K") ? Guid.Empty : _keRekeningRowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRekening", SqlDbType.VarChar, txtNoRekening.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@DueDateGiro", SqlDbType.Date, dtDueDateGiro.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar, (_bentukPengeluaran == "G") ? txtNoGiro.Text : ""));
                                db.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, _pengeluaranKe));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                dt1 = db.Commands[0].ExecuteDataTable();
                       

                                MessageBox.Show(Messages.Confirm.SaveSuccess);
                                //RefreshForward();
                                //ForwardControl();
                            }
    
                    this.DialogResult = DialogResult.OK;
                    closeForm();
                    this.Close();


                    lblnoacc.Visible = false;
                    txtNoAcc.Visible = false;

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                    //result = false;
                }
                finally
                {
                    this.Cursor = Cursors.Default;

                }


        }

        #endregion

        private void cboMataUang_Leave(object sender, EventArgs e)
        {
            if (_ForwardDariPenerimaan.Equals(false))
            {
                if (!(cboMataUang.Text.ToString().Equals("")))
                {
                    if (!(cboMataUang.Text.ToString() == "IDR"))
                    {

                        Double
                        KursValue = GetKursValue((DateTime)txtTanggal.DateValue, (Guid)cboMataUang.SelectedValue);
                        if (KursValue > 0)
                        {
                            KursValueMataUang = KursValue;
                            txtNominal.Focus();
                        }
                        else KursValueMataUang = 1;

                    }
                    else { 
                        txtNominal.Focus(); 
                        if (!flagF2) txtNominalRp.Text = "0"; 
                    }


                    RefreshCboMataUangID();

                    lkpRekening1.Enabled = true;
                    lkpRekening2.Enabled = true;
                    lookUpRekening2.Enabled = true;
                    lkpRekening1.MataUangIDRekening = cboMataUang.Text.ToString();
                    lkpRekening2.MataUangIDRekening = cboMataUang.Text.ToString();
                    lookUpRekening2.MataUangIDRekening = cboMataUang.Text.ToString();
                    lkpRekening1.PerusahaanID = (Guid)cboPerusahaan.SelectedValue;
                    lkpRekening2.PerusahaanID = (Guid)cboPerusahaan.SelectedValue;
                    lookUpRekening2.PerusahaanID = (Guid)cboPerusahaanKe.SelectedValue;

                }
                else
                {
                    txtNominalRp.Enabled = false;
                    lkpRekening1.Enabled = false;
                    lkpRekening2.Enabled = false;
                    lookUpRekening2.Enabled = false;
                    RefreshCboMataUangID();
                }
            }
            
        }

        private void txtNominal_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNominal.Text))
            {

                if (cboMataUang.Text.ToString() == "IDR") 
                {
                    txtNominalRp.Text = txtNominal.Text ;
//                    txtNominalRp.Text = Convert.ToString(txtNominal.GetDoubleValue * KursValueMataUang).Trim();

                }
            }
            else
            {
                txtNominalRp.Text = "0";
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            formMode=enumFormMode.New;
            RefreshData();
        }

        private void CheckValidasiUraian(String CabID)
        {
            String textAppend =CabID;
            int strLength = textAppend.Length;
            DataTable dt_ = new DataTable();
            dt_ = GetListGudangID(CabID);
            ArrayList arrGudangID = new ArrayList();
         
            IsRegex =0;
            if ((cboPengeluaranKe.SelectedIndex == 0) && (cboCabangKe.SelectedIndex!=0))
            {
                //try
                //{
                    ComboCabangID = cboCabangKe.Text.ToString().Substring(0, 2);
                //}
                //catch { } 
            }

            if (cboPengeluaranKe.SelectedIndex == 1 || cboPengeluaranKe.SelectedIndex == 2)
            {
                SimpanData();
                return;
            }

            DataTable dtcek = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_JnsTransaksiCek"));
                db.Commands[0].Parameters.Add(new Parameter("@NamaTransaksi", SqlDbType.VarChar, cboJnsTransaksi.Text));
                dtcek = db.Commands[0].ExecuteDataTable();
            }
            if (dtcek.Rows.Count != 0 && txtNoAcc.Text == "")
            {
                MessageBox.Show("No ACC harus diisi", "Informasi");
                return;
            }

            if (formMode == enumFormMode.New)
            {
                DataTable dtceknoacc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NoACCCek"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
                    dtceknoacc = db.Commands[0].ExecuteDataTable();
                }
                if (dtceknoacc.Rows.Count != 0 && txtNoAcc.Text != "")
                {

                    MessageBox.Show("No ACC sudah pernah diinput");
                    return;

                }
            }
            if (formMode == enumFormMode.Update)
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                String NoAcc = Tools.isNull(dt.Rows[0]["NoAcc"], "").ToString();
                DataTable dtceknoacc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NoACCCek"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
                    dtceknoacc = db.Commands[0].ExecuteDataTable();
                }
                if (dtceknoacc.Rows.Count > 0)
                {
                    String NoAccNew = Tools.isNull(dtceknoacc.Rows[0]["NoAcc"], "").ToString();
                    if (dtceknoacc.Rows.Count != 0 && NoAcc != NoAccNew)
                    {

                        MessageBox.Show("No ACC sudah pernah diinput");
                        return;

                    }
                }
            }

            if ((ComboCabangID!=null) && (ComboCabangID.Equals("09")))
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
            { SimpanData();
            lblnoacc.Visible = false;
            txtNoAcc.Visible = false;
            txtNoAcc.Text = "";
            }
        }

        private void numKurs_TextChanged(object sender, EventArgs e)
        {
            //HitungKurs();
            if (cboMataUang.SelectedText != "IDR")
            {
                if (Convert.ToDouble(txtNominalRp.Text) == 0) txtNominalRp.Text = (Convert.ToDouble(txtNominal.Text) * Convert.ToDouble(numKurs.Text)).ToString();
                else if (Convert.ToDouble(txtNominal.Text) == 0) txtNominal.Text = (Convert.ToDouble(txtNominalRp.Text) / Convert.ToDouble(numKurs.Text)).ToString();
            }

        }

        private void pnlDetil1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
