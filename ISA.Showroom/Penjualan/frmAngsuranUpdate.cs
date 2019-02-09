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
using System.Globalization;
using Microsoft.Reporting.WinForms;
using ISA.Showroom.DataTemplates;

namespace ISA.Showroom.Penjualan
{
    public partial class frmAngsuranUpdate : ISA.Controls.BaseForm
    {
        enum FormMode { Angsuran = 0, Pelunasan = 1, Tarikan = 2, Adjustment = 3, Tarikanv2 = 4
        , TarikanNV1 = 5, TarikanNV2 = 6
        };
        bool _isHitung = false;

        FormMode mode = new FormMode();
        Guid _rowID, _penjRowID, _penjHistID, _CustomerRowID ;
        string _kodeTrans; // bisa berisikan FLT atau APD  
        DateTime _tglJual, _tglAkhirAngs;
        int _tempo;
        int _angsKe;
        bool _boolPeriodeAngsuranSama = false;
        List<AngsuranIden> _listAngsuranIden;
        AngsuranDetail _selectedAngsuranDetail;
        Double Denda, _saldo, _saldoBunga;
        bool _kenaDenda;
        int periodeDenda, hariDenda;
        bool _tidakperlubayarbunga = false;

        Double tambahanTunaiTitipan = 0;
        Double tambahanTunaiTitipanPembulatan = 0;
        Double bayarBulatTambahanTunaiTitipan = 0;

        Guid newPembelianRowID = Guid.NewGuid();
        int modeBayarTitipan = 0; // 0 itu titipan murni , 1 itu titipan + tunai
        String _nopol;

        enum enumTipeTitipan { Murni, UM, Angsuran, Adm };
        bool _fromSuratTagih = false;
        DateTime _cetakST = DateTime.MinValue;
        Double _dendaST = -1;
        string _tipeMode = "";

        

        #region "Event Handler" 
        
        public frmAngsuranUpdate(Form caller, Guid penjHistID, Guid penjRowID, string strMode)
        {
            InitializeComponent();
            _penjRowID = penjRowID;

            this.Caller = caller;
            _penjHistID = penjHistID;
            _tipeMode = strMode;
            switch (strMode)
            {
                case "Angsuran" :
                    mode = FormMode.Angsuran;
                    break;
                case "Pelunasan" :
                    mode = FormMode.Pelunasan;
                    break;
                case "Tarikan":
                    mode = FormMode.Tarikan;
                    break;
                case "Tarikanv2":
                    mode = FormMode.Tarikanv2;
                    break;
                case "ADJ":
                    mode = FormMode.Adjustment;
                    break;
                case "TarikanNV1":
                    mode = FormMode.TarikanNV1;
                    break;
                case "TarikanNV2":
                    mode = FormMode.TarikanNV2;
                    break;
            }
            if (mode == FormMode.TarikanNV1)
            {
                dtbTglAcc.Enabled = false;
                txtNoAcc.Enabled = false;
            }
        }

        public frmAngsuranUpdate(Form caller, Guid penjHistID, Guid penjRowID, Double saldoBunga, string strMode)
        {
            InitializeComponent();
            _penjRowID = penjRowID;
            _saldoBunga = saldoBunga;

            this.Caller = caller;
            _penjHistID = penjHistID;
            _tipeMode = strMode;
            switch (strMode)
            {
                case "Angsuran":
                    mode = FormMode.Angsuran;
                    break;
                case "Pelunasan":
                    mode = FormMode.Pelunasan;
                    break;
                case "Tarikan":
                    mode = FormMode.Tarikan;
                    break;
                case "Tarikanv2":
                    mode = FormMode.Tarikanv2;
                    break;
                case "ADJ":
                    mode = FormMode.Adjustment;
                    break;
                case "TarikanNV1":
                    mode = FormMode.TarikanNV1;
                    break;
                case "TarikanNV2":
                    mode = FormMode.TarikanNV2;
                    break;
            }
        }

        public frmAngsuranUpdate(Form caller, Guid penjHistID, Guid penjRowID, string strMode, bool isHitung)
        {
            InitializeComponent();
            _penjRowID = penjRowID;
            _isHitung = isHitung;
            txtTglLunas.Enabled = true;

            this.Caller = caller;
            _penjHistID = penjHistID;
            _tipeMode = strMode;
            switch (strMode)
            {
                case "Angsuran":
                    mode = FormMode.Angsuran;
                    break;
                case "Pelunasan":
                    mode = FormMode.Pelunasan;
                    break;
                case "Tarikan":
                    mode = FormMode.Tarikan;
                    break;
                case "Tarikanv2":
                    mode = FormMode.Tarikanv2;
                    break;
                case "ADJ":
                    mode = FormMode.Adjustment;
                    break;
                case "TarikanNV1":
                    mode = FormMode.TarikanNV1;
                    break;
                case "TarikanNV2":
                    mode = FormMode.TarikanNV2;
                    break;
            }

        }

        private void frmAngsuranUpdate_Load(object sender, EventArgs e)
        {
            cmdHitung.Enabled = false;
            cmdHitung.Visible = false;
            cboMode.Enabled = false;
            cboMode.Visible = false;
            cmdPrint.Visible = false;
            cmdPrint.Enabled = false;

            cbxDenda.Enabled = false;
            cbxDenda.Checked = false;
            _rowID = Guid.NewGuid();

            if (GlobalVar.CabangID.Contains("13"))
            {
                txtNoAcc.Enabled=false;
                dtbTglAcc.Enabled=false;
            }

            if (mode == FormMode.Angsuran || mode == FormMode.Pelunasan)
            {
                txtNoAcc.Enabled = false;
                dtbTglAcc.Enabled = false;
            }



            if (mode == FormMode.TarikanNV1)
            {
                ntbEstimasiHrgMotor.Enabled = true;
            }

            if (mode == FormMode.TarikanNV2)
            {
                ntbEstimasiHrgMotor.Enabled = false;               
            }


            //jangan bolehin ubah2 tanggal pelunasan
            if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
            {
                txtTglLunas.Enabled = false;
            }
            else
            {
                txtTglLunas.Enabled = true;
            }
            txtTglLunas.DateValue = GlobalVar.GetServerDate;
            BindData();
            tambahanTunaiTitipan = 0;

            // pembulatan
            cboPembulatan.SelectedIndex = 0;
            refreshPembulatan();
            controlPembulatanSet();
            updateTxtNominal();

            if (_isHitung)
            {
                // disable semua, kecuali tombol close, hitung dan textbox tanggal
                // disable all
                mode = FormMode.Angsuran;
                cboMode.SelectedIndex = 0;
                DisableControls(this);
                cmdSave.Enabled = false;
                cmdSave.Visible = false;
                this.Enabled = true;
                cmdClose.Enabled = true;
                cmdClose.Visible = true;
                panel1.Enabled = true;
                //txtTglLunas.Enabled = true;
                cmdHitung.Enabled = true;
                cmdHitung.Visible = true;
                cboMode.Enabled = true;
                cboMode.Visible = true;
                if (_kodeTrans == "FLT" && cboMode.SelectedIndex == 1)
                {
                    cmdPrint.Visible = true;
                    cmdPrint.Enabled = true;
                }
            }
            
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }

        private void controlPembulatanSet()
        {
            lblHargaJual.Visible = false;
            lblCustomer.Visible = false;
            ntbHargaJual.Visible = false;
            lookUpCustomer1.Visible = false;

            // untuk angsuran cek kasusnya, kalau lagi FLT, APD ataupun tarrikan itu ada beberapa kejadian
            switch (mode)
            {
                case FormMode.Angsuran:
                    if (_kodeTrans == "FLT")
                    {
                        // kalau sedang melakukan angsuran FLT, ngga usah lakukan input uang harusnya
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        // kalau sedang melakukan angsuran APD, boleh dia ubah2 pembayarannya
                        txtPembayaran.Enabled = true;
                        txtPembayaran.ReadOnly = false;
                    }
                    break;
                case FormMode.Pelunasan:
                    if (_kodeTrans == "FLT")
                    {
                        // kalau sedang pelunasan sih harusnya ngga perlu isi apa2
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        // kalau sedang pelunasan sih harusnya ngga perlu isi apa2
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    break;
                case (FormMode.Tarikan):
                    if (_kodeTrans == "FLT")
                    {
                        // kalau sedang tarikan sih harusnya ngga perlu isi apa2, hanya dari yg biaya lain-lain dan harga estimasi motor yg berubah
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        // kalau sedang tarikan sih harusnya ngga perlu isi apa2, hanya dari yg biaya lain-lain dan harga estimasi motor yg berubah
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    //txtNoAcc.Enabled = true;
                    break;
                case (FormMode.Tarikanv2):
                    if (_kodeTrans == "FLT")
                    {
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    lblHargaJual.Visible = true;
                    lblCustomer.Visible = true;
                    ntbHargaJual.Visible = true;
                    lookUpCustomer1.Visible = true;
                    //txtNoAcc.Enabled = true;
                    break;
                case FormMode.Adjustment:
                    if (_kodeTrans == "FLT")
                    {
                        // kalau sedang pelunasan sih harusnya ngga perlu isi apa2
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        // kalau sedang pelunasan sih harusnya ngga perlu isi apa2
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }

                    //cbxBentukPembayaran.Items.Add("Adjusment");
                    //cbxBentukPembayaran.Text = "Adjusment";
                    //cbxBentukPembayaran.SelectedItem = "Adjusment";
                    cbxBentukPembayaran.Enabled = false;
                    txtPotongan.Enabled = false;
                    lookUpKolektor.Enabled = false;
                    cboPelunasan.Enabled = true;
                    //txtNoAcc.Enabled = true;
                    break;
              case (FormMode.TarikanNV1):
                    if (_kodeTrans == "FLT")
                    {
                        // kalau sedang tarikan sih harusnya ngga perlu isi apa2, hanya dari yg biaya lain-lain dan harga estimasi motor yg berubah
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        // kalau sedang tarikan sih harusnya ngga perlu isi apa2, hanya dari yg biaya lain-lain dan harga estimasi motor yg berubah
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                   // txtNoAcc.Enabled = true;
                    ntbBiayaKolektor.Enabled = false;
                    ntbBiayaTarikan.Enabled = false;
                    break;
               case (FormMode.TarikanNV2):
                    if (_kodeTrans == "FLT")
                    {
                        // kalau sedang tarikan sih harusnya ngga perlu isi apa2, hanya dari yg biaya lain-lain dan harga estimasi motor yg berubah
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                    }
                    else if (_kodeTrans == "APD")
                    {
                        // kalau sedang tarikan sih harusnya ngga perlu isi apa2, hanya dari yg biaya lain-lain dan harga estimasi motor yg berubah
                        txtPembayaran.Enabled = false;
                        txtPembayaran.ReadOnly = true;
                        updateTxtNominal();
                    }
                    //txtNoAcc.Enabled = true;
                    txtEstimasiBiayaTarikan.Enabled = false;
                    //ntbBiayaKolektor.Enabled = false;
                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAngsuranUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmAngsuranBrowse)
            {
                Penjualan.frmAngsuranBrowse frmCaller = (Penjualan.frmAngsuranBrowse)this.Caller;
                if (mode == FormMode.TarikanNV1 && this.DialogResult == DialogResult.OK)
                {
                    frmCaller.setTglTarikan((DateTime)txtTglLunas.DateValue);
                }
                frmCaller.RefreshRowANG(_penjRowID);
                frmCaller.FindRowGrid2("mRowID", _penjHistID.ToString());
                frmCaller.RefreshRowLunas(_rowID);
                frmCaller.FindRowGrid3("dRowID", _rowID.ToString());
            }
        }


        private void txtTglLunas_Leave(object sender, EventArgs e)
        {
            if (mode == FormMode.Adjustment)
            {

            }
            else
            {
                this.refresh();
            }
        }

        private void txtTglLunas_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.refresh();
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPembayaran_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                txtUraian.Focus();
            }
        }

        private void cbxBentukPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDenda.Enabled = true;
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "tunai")
            {
                if (mode == FormMode.Angsuran)
                {
                    txtPembayaran.Enabled = true;
                }
                DisabledControlBG();
                lookUpRekening1.Enabled = false;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
            {
                if (mode == FormMode.Angsuran)
                {
                    txtPembayaran.Enabled = true;
                }
                DisabledControlBG();
                lookUpRekening1.Enabled = true;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                cbxDenda.Enabled = false;
                cbxDenda.Checked = false;
                txtBayarDenda.Text = "0";
                if (mode == FormMode.Angsuran)
                {
                    txtPembayaran.Enabled = true;
                }
                EnabledControlBG();
                lookUpRekening1.Enabled = false;
            }
            else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                cbxDenda.Enabled = false;
                DisabledControlBG();
                lookUpRekening1.Enabled = false;

                _selectedAngsuranDetail = new AngsuranDetail();
                _selectedAngsuranDetail.CustomerRowID = _CustomerRowID;
                _selectedAngsuranDetail.CustomerName = lblNama.Text;
                _selectedAngsuranDetail.SaldoPiutangPokok = Convert.ToDouble(txtPiutangPokok.Text);
                _selectedAngsuranDetail.Denda = Convert.ToDouble(txtBayarDenda.Text);
                _selectedAngsuranDetail.TotalAngsuran = (Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text));
                _selectedAngsuranDetail.NominalPembayaran = Convert.ToDouble(txtPembayaran.Text);
                _selectedAngsuranDetail.PotonganBunga = Convert.ToDouble(txtBayarPokok.Text);                
                _selectedAngsuranDetail.BayarBunga = Convert.ToDouble(ntbNominalBunga.Text);
                
                _selectedAngsuranDetail.MataUangID = cboMataUang.SelectedValue.ToString();
                _selectedAngsuranDetail.TipeBunga = _kodeTrans;

                _listAngsuranIden = new List<AngsuranIden>();
                Penjualan.frmAngsuranIden ifrmChild = new Penjualan.frmAngsuranIden(this, _selectedAngsuranDetail,  _listAngsuranIden);
                ifrmChild.ShowDialog();
                modeBayarTitipan = ifrmChild.modeBayar;
                if (modeBayarTitipan == 1) // ini berarti titipan + tunai
                {
                    tambahanTunaiTitipan = ifrmChild.nominalTambahan;
                    tambahanTunaiTitipanPembulatan = ifrmChild.nominalPembulatan;
                    bayarBulatTambahanTunaiTitipan = ifrmChild.nominalBayarTunaiBulat;
                }
                //this.refresh();
                cbxBentukPembayaran.Enabled = true;
                txtPembayaran.Enabled = false;
            }
            refreshPembulatan();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion


        #region "Custom Function" 
        
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

        private void updateLogST(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@isProcessed", SqlDbType.TinyInt, 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (mode == FormMode.Pelunasan) // if (GlobalVar.CabangID.Contains("13"))
            {
                // cek dulu apakah denda nya ada yg belum lunas, minta lunasin dulu baru bisa pelunasan
                using (Database db = new Database())
                {
                    DataTable dtRefresh = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_CheckSaldo"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                    if (dtRefresh.Rows.Count > 0)
                    {
                        Double SaldoDenda = Convert.ToDouble(Tools.isNull(dtRefresh.Rows[0]["SaldoDenda"], 0).ToString());
                        if (SaldoDenda > 0)
                        {
                            MessageBox.Show("Tolong lunasi denda terlebih dahulu sebelum melakukan Pencetakan!");
                            return;
                        }
                    }
                }
            }

            //if (mode == FormMode.Adjustment) // if (GlobalVar.CabangID.Contains("13"))
            //{
            //    if (txtNoAcc.Text.Replace(" ", "") == "") 
            //    { 
            //        MessageBox.Show("No ACC harus diisi");
            //        txtNoAcc.Focus();
            //        return; 
            //    }
            //    if (dtbTglAcc.Text.Replace(" ", "") == "")
            //    { 
            //        MessageBox.Show("Tanggal ACC harus diisi");
            //        dtbTglAcc.Focus();
            //        return; 
            //    }
            //    insertAdj();
            //}

            if (mode != FormMode.Adjustment) // if (GlobalVar.CabangID.Contains("13"))
            {
                #region presave validate
                Double decNilaiBGC = 0;
                Double decNilaiNominal = 0;
                int bentukPembayaran = 1;
                System.Guid rekeningPembayaranRowID = System.Guid.Empty;

                if (cbxBentukPembayaran.SelectedIndex <= -1)
                {
                    MessageBox.Show("Bentuk pembayaran belum dipilih");
                    return;
                }

                decNilaiNominal = Convert.ToDouble(txtPembayaran.Text); // nilai pembayaran yg disimpan itu ngga usah memperhitungkan denda
                /* // karena nominal bayar denda udah dipisah  ngga perlu lagi
                if (Convert.ToDouble(txtDenda.Text) > 0 && cbxDenda.Checked == true) // kalo lagi iya bayar denda dendanya itu jangan diitung ke dalam situ
                {
                    decNilaiNominal = decNilaiNominal - Convert.ToDouble(txtDenda.Text);
                }
                */

                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
                {
                    bentukPembayaran = 2;
                    rekeningPembayaranRowID = lookUpRekening1.RekeningRowID;
                    if (Tools.isNull(lookUpRekening1.NamaRekening, "").ToString() == "" || lookUpRekening1.RekeningRowID == null || lookUpRekening1.RekeningRowID == Guid.Empty)
                    {
                        MessageBox.Show("Rekening Bank belum terisi");
                        lookUpRekening1.Focus();
                        return;
                    }
                }
                else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    bentukPembayaran = 3;
                    decNilaiBGC = Convert.ToDouble(txtPembayaran.Text); // nilai pembayaran yg disimpan itu ngga usah memperhitungkan denda

                    /* // karena nominal bayar denda udah dipisah, ngga perlu lagi
                    if (Convert.ToDouble(txtDenda.Text) > 0 && cbxDenda.Checked == true)
                    {
                        decNilaiBGC = decNilaiBGC - Convert.ToDouble(txtDenda.Text); // kalo lagi iya bayar denda dendanya itu jangan diitung ke dalam situ
                    }
                    */
                    decNilaiNominal = 0;
                    if (String.IsNullOrEmpty(txtNoBG.Text))
                    {
                        MessageBox.Show("No. BGC belum diisi !");
                        txtNoBG.Focus();
                        return;
                    }

                    if (txtTglBG.Text == "")
                    {
                        MessageBox.Show("Tanggal Jatuh Tempo BGC belum diisi !");
                        txtTglBG.Focus();
                        return;
                    }

                    if (((DateTime)txtTglBG.DateValue).Date < _tglJual.Date)
                    {
                        MessageBox.Show("Tgl. BGC lebih kecil dari pada Tanggal Penjualan !");
                        txtTglBG.Focus();
                        return;
                    }

                }
                else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
                {
                    bentukPembayaran = 4;
                }

                //if (mode == FormMode.Tarikan || mode == FormMode.Tarikanv2)
                //{
                //    if (txtNoAcc.Text.Replace(" ", "") == "")
                //    {
                //        MessageBox.Show("No ACC harus diisi");
                //        txtNoAcc.Focus();
                //        return;
                //    }
                //    if (dtbTglAcc.Text.Replace(" ", "") == "")
                //    {
                //        MessageBox.Show("Tanggal ACC harus diisi");
                //        dtbTglAcc.Focus();
                //        return;
                //    }

                //    if (!dtbTglTarikan.DateValue.HasValue)
                //    {
                //        MessageBox.Show("Tgl Tarikan belum diisi");
                //        dtbTglTarikan.Focus();
                //        return;
                //    }


                //    if (Convert.ToDouble(Tools.isNull(ntbEstimasiHrgMotor.Text, "0")) <= 0)
                //    {
                //        MessageBox.Show("Harga estimasi motor belum diisi");
                //        dtbTglTarikan.Focus();
                //        return;
                //    }
                //    // kalo tarikan jadinya perlu cek atau ngga, kalo cek juga begini atau gimana???
                //    if (decNilaiBGC < Convert.ToDouble(ntbNominalBunga.Text) && decNilaiNominal < Convert.ToDouble(ntbNominalBunga.Text))
                //    {
                //        if (_kodeTrans == "FLT" && (decNilaiNominal != ((Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)) - (Convert.ToDouble(ntbBiayaKolektor.Text) + Convert.ToDouble(ntbBiayaTarikan.Text))) && (decNilaiBGC != (Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)) - (Convert.ToDouble(ntbBiayaKolektor.Text) + Convert.ToDouble(ntbBiayaTarikan.Text)))))
                //        {
                //            MessageBox.Show("Pembayaran angsuran harus sama dengan angsuran yg ditetapkan, jika lebih maka sisanya mohon diinputkan ke titipan");
                //            return;
                //        }
                //        else if (_kodeTrans == "APD" && (decNilaiBGC < Convert.ToDouble(ntbNominalBunga.Text) && decNilaiNominal < Convert.ToDouble(ntbNominalBunga.Text)))
                //        {
                //            MessageBox.Show("Minimum angsuran harus sama dengan nominal bunga");
                //            return;
                //        }
                //    }
                //}

                if ((mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2) && GlobalVar.CabangID.Contains("06"))
                {
                    if (mode == FormMode.TarikanNV2)
                    {
                        if (txtNoAcc.Text.Replace(" ", "") == "")
                        {
                            MessageBox.Show("No ACC harus diisi");
                            txtNoAcc.Focus();
                            return;
                        }
                        if (dtbTglAcc.Text.Replace(" ", "") == "")
                        {
                            MessageBox.Show("Tanggal ACC harus diisi");
                            dtbTglAcc.Focus();
                            return;
                        }
                    }
                    if (!dtbTglTarikan.DateValue.HasValue)
                    {
                        MessageBox.Show("Tgl Tarikan belum diisi");
                        dtbTglTarikan.Focus();
                        return;
                    }

                    //Request Teo txtEstimasiBiayaTarikan dihilangkan 
                    //if(Convert.ToDouble(txtEstimasiBiayaTarikan.Text) <=0)
                    //{
                    //    MessageBox.Show("Estimasi Biaya Tarikan Belum Diisi");
                    //    return;
                    //}

                    if (Convert.ToDouble(txtEstimasiBiayaTarikan.Text) < Convert.ToDouble(ntbBiayaTarikan.Text))
                    {
                        MessageBox.Show("Biaya Tarikan tidak boleh lebih besar dari Estimasi Biaya Tarikan");
                        return;
                    }
                    // kalo tarikan jadinya perlu cek atau ngga, kalo cek juga begini atau gimana???
                    if (decNilaiBGC < Convert.ToDouble(ntbNominalBunga.Text) && decNilaiNominal < Convert.ToDouble(ntbNominalBunga.Text))
                    {
                        if (_kodeTrans == "FLT" && (decNilaiNominal != ((Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)) - (Convert.ToDouble(ntbBiayaKolektor.Text) + Convert.ToDouble(ntbBiayaTarikan.Text))) && (decNilaiBGC != (Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)) - (Convert.ToDouble(ntbBiayaKolektor.Text) + Convert.ToDouble(ntbBiayaTarikan.Text)))))
                        {
                            MessageBox.Show("Pembayaran angsuran harus sama dengan angsuran yg ditetapkan, jika lebih maka sisanya mohon diinputkan ke titipan");
                            return;
                        }
                        else if (_kodeTrans == "APD" && (decNilaiBGC < Convert.ToDouble(ntbNominalBunga.Text) && decNilaiNominal < Convert.ToDouble(ntbNominalBunga.Text)))
                        {
                            MessageBox.Show("Minimum angsuran harus sama dengan nominal bunga");
                            return;
                        }
                    }
                }
                else
                {
                   //if (_kodeTrans == "FLT" && (decNilaiNominal != (Convert.ToDouble(ntbNominalBunga.Text)  + Convert.ToDouble(txtBayarPokok.Text)) && (decNilaiBGC != (Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)))))
                    //if (_kodeTrans == "FLT" && (decNilaiNominal != ((Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)) - (Convert.ToDouble(ntbBiayaKolektor.Text) + Convert.ToDouble(ntbBiayaTarikan.Text))) && (decNilaiBGC != (Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtBayarPokok.Text)) - (Convert.ToDouble(ntbBiayaKolektor.Text) + Convert.ToDouble(ntbBiayaTarikan.Text)))))
                    //{
                    //    MessageBox.Show("Pembayaran angsuran harus sama dengan angsuran yg ditetapkan, jika lebih maka sisanya mohon diinputkan ke titipan");
                    //    return;
                    //}
                    //else 
                    if (_kodeTrans == "APD" && (decNilaiBGC < Convert.ToDouble(ntbNominalBunga.Text) && decNilaiNominal < Convert.ToDouble(ntbNominalBunga.Text)))
                    {
                        MessageBox.Show("Minimum angsuran harus sama dengan nominal bunga");
                        return;
                    }
                }

                /* -- boleh ngga isi kolektor
                if (lookUpKolektor._Kolektor.RowID == System.Guid.Empty)
                {
                    MessageBox.Show("Kolektor belum dipilih!");
                    lookUpKolektor.Focus();
                    return;
                }
                */

                if (_boolPeriodeAngsuranSama && mode == FormMode.Angsuran)
                {
                    // txtBayarPokok.Text = txtPembayaran.Text; // ini koreksi dari Pak Novi
                    // txtTotal.Text = txtPembayaran.Text;
                }

                if (mode == FormMode.Tarikanv2)
                {
                    if (txtNoAcc.Text.Replace(" ", "") == "")
                    {
                        MessageBox.Show("No ACC harus diisi");
                        txtNoAcc.Focus();
                        return;
                    }
                    if (dtbTglAcc.Text.Replace(" ", "") == "")
                    {
                        MessageBox.Show("Tanggal ACC harus diisi");
                        dtbTglAcc.Focus();
                        return;
                    }
                    if (Convert.ToDouble(ntbHargaJual.Text) < 1)
                    {
                        MessageBox.Show("Harga jual motor belum diisi");
                        ntbHargaJual.Focus();
                        return;
                    }

                    if (lookUpCustomer1.txtNamaCustomer.Text == "")
                    {
                        MessageBox.Show("Nama Customer belum diisi");
                        lookUpCustomer1.txtNamaCustomer.Focus();
                        return;
                    }
                }

                #endregion
                /*
            if(GlobalVar.CabangID.Contains("06"))
            {
                if ((GlobalVar.GetServerDateTime_RealTime.Hour > 14) && (txtTglLunas.DateValue == GlobalVar.GetServerDateTime_RealTime.Date) && GlobalVar.CabangID.Contains("06"))
                {
                    MessageBox.Show("Sudah di atas jam 3 sore, transaksi seharusnya menjadi transaksi untuk keesokan harinya");
                    txtTglLunas.DateValue = GlobalVar.GetServerDateTime_RealTime.AddDays(1).DayOfWeek == DayOfWeek.Sunday ? 
                                            GlobalVar.GetServerDateTime_RealTime.AddDays(2) : GlobalVar.GetServerDateTime_RealTime.AddDays(1);
                    txtTglLunas.Focus();
                    return;
                }
            }
            */
                /*
                if (txtTglLunas.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
                {
                    if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        txtTglLunas.Focus();
                        return;
                    }
                }
                */
                this.Cursor = Cursors.WaitCursor;
                if (_kodeTrans == "APD")
                {
                    SimpanAngsuran(decNilaiNominal, decNilaiBGC);
                }
                else if (_kodeTrans == "FLT")
                {
                    SimpanAngsuran(decNilaiNominal, decNilaiBGC);
                }
                this.Cursor = Cursors.Arrow;
            }

        }

        private bool ValidateSave()
        {
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
                if (_listAngsuranIden.Count == 0)
                {
                    MessageBox.Show("Identifikasi titipan belum dilakukan." + Environment.NewLine + "Pastikan minimal 1 transaksi titipan sudah diiden ke pembayaran ini");
                    return false;
                }
            }

            // cek tanggal JT giro ngga boleh lebih dari jt nya angsuran untuk periode yg lagi diproses
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                if (((DateTime)txtTglBG.DateValue).Date > dtbTglJTAngsuran.DateValue)
                {
                    MessageBox.Show("Tanggal Jatuh Tempo BGC tidak boleh melebihi tanggal jatuh tempo angsuran!");
                    txtTglBG.Focus();
                    return false;
                }
            }

            /* // ngga bisa cek di sini , dan ngga perlu generate noTrans di sini lagi
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
                _rowID = Guid.NewGuid();
                lblNoTrans.Text = Numerator.NextNumber("NTP");
                if (lblNoTrans.Text == "")
                {
                    MessageBox.Show("No Transaksi masih kosong");
                    return false;
                }
            }
            else
            {
                lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                if (lblNoTrans.Text == "")
                {
                    MessageBox.Show("No Transaksi masih kosong");
                    return false;
                }
            }
            */
            
            if (GlobalVar.CabangID.Contains("06"))
            {
                // kalau cabang 06, tgl lunas nya dibebasin, perlu di cek -- per 2016 jangan dong
               // txtTglLunas.Enabled = true;
               // txtTglLunas.ReadOnly = false;
                if (txtTglLunas.DateValue.HasValue)
                {
                    //if (_fromSuratTagih == true)
                    //{
                    //    if (txtTglLunas.DateValue != _cetakST)
                    //    {
                    //        txtTglLunas.DateValue = _cetakST;
                    //        txtTglLunas.Focus();
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                        if (txtTglLunas.DateValue.Value < GlobalVar.GetServerDate.Date || txtTglLunas.DateValue.Value > GlobalVar.GetServerDate.Date.AddDays(2))
                        {
                            MessageBox.Show("Tanggal hanya dapat diisikan tanggal hari ini sampai +2 hari ke depan!");
                            txtTglLunas.Focus();
                            return false;
                        }

                        if (txtTglLunas.DateValue.Value == GlobalVar.GetServerDateTime_RealTime.Date && GlobalVar.GetServerDateTime_RealTime.Hour > 14 && GlobalVar.CabangID.Contains("06"))
                        {
                            if (MessageBox.Show("Anda melakukan input setelah pukul 15:00, yakin Anda tidak merubah tanggalnya?", "Anda yakin akan menyimpan data ini?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                            }
                            else
                            {
                                txtTglLunas.Focus();
                                return false;
                            }
                        }
                    //}
                }
                else
                {
                    MessageBox.Show("Tolong isikan tanggal terlebih dahulu!");
                    txtTglLunas.Focus();
                    return false;
                }
            }

            if (mode == FormMode.Pelunasan || mode == FormMode.Adjustment)
            {
                if (GlobalVar.CabangID.Contains("06"))
                {
                    if (ntbNominalBunga.GetDoubleValue < 0)
                    {
                        txtPotongan.Text = (-1 * ntbNominalBunga.GetDoubleValue).ToString();
                    }
                    else
                    {
                        if (txtPotongan.GetDoubleValue > (1 * ntbNominalBunga.GetDoubleValue))// tadinya 0.8
                        {
                            MessageBox.Show("Maksimal nominal Potongan adalah sebesar nominal Bunga (" + (1 * ntbNominalBunga.GetDoubleValue).ToString("N2") + ") !"); // 80%, 0.8
                            txtPotongan.Text = (1 * ntbNominalBunga.GetDoubleValue).ToString();
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        // di Penerimaan Titipan 1 data kayak biasa
        private void penerimaanTitipanInsert(ref Database db, ref int counterdb, Double decNilaiBGC, Guid newRowID, String newNoTrans)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, newNoTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); //GlobalVar.GetServerDate
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, decNilaiBGC));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, txtTglBG.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Angsuran));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, mode == FormMode.Angsuran ? "ANG" : (mode == FormMode.Pelunasan ? "PLS" : "TRK")));
            counterdb++;
        }

        // kalo penerimaan titipan yg tunai tambahan langsung ke titipan, titipaniden, dan penerimaanuang
        private void penerimaanTitipanInsertTambahanTunai(ref Database db, ref int counterdb, Double decNilai, Guid newRowID, String newNoTrans, ref Database dbf, ref int counterdbf, Guid penerimaanPBLRowID)
        {
            Guid PenerimaanUangRowIDTambahan = Guid.NewGuid();
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            String KodeTrans = string.Empty;
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; break;
                case 3: JnsPenerimaan = "K"; break;
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
            // ambil kodetrans dulu buat tau tipe angsurannya
            // usp_Penjualan_LIST   dengan @RowID = _penjRowID
            using (Database dbfsub = new Database())
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_Penjualan_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                KodeTrans = dtfsub.Rows[0]["KdTrans"].ToString();
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TTP).ToString()));  // Titipan Murni/TTP -> Penerimaan Belum Iden (31)
                /*
                if (KodeTrans == "FLT")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PiutangBunga).ToString()));  // ANG 36 - Piutang Bunga
                }
                else if (KodeTrans == "APD")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString()));  // ANG 18 - Pendapatan Bunga Kredit
                }
                else
                {
                    throw (exDE);
                }
                */

                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            String notransTitipTunai = Numerator.NextNumber("NTP");
            // ke penerimaan titipan dulu
            db.Commands.Add(db.CreateCommand("usp_PenerimaanTitipan_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, notransTitipTunai));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // GlobalVar.GetServerDate
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilai)); // tunai
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalBGC", SqlDbType.Money, 0)); // bukan giro
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1)); // harus tunai
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJTBGC", SqlDbType.Date, null));
            db.Commands[counterdb].Parameters.Add(new Parameter("@StatusBGC", SqlDbType.SmallInt, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBGC", SqlDbType.VarChar, ""));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            // tambahan untuk tipe titipan
            db.Commands[counterdb].Parameters.Add(new Parameter("@TipeTitipan", SqlDbType.SmallInt, (int)Class.enumTipeTitipan.Murni));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowIDTambahan));
            
            /*
             * kena pembulatan tapi data pembulatannya di angsurannya aja!!!
            // di penerimaan Titipan kalau lagi yang bayar angsuran dengan Titipan+Tunai kena pembulatan
            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
            }
            */
            
            counterdb++;

            // ke penerimaan titipaniden
            db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanAngsuranRowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, decNilai));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;

            string tempBentukPenerimaan = "K"; // mestinya sih selalu K
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
            Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
            String NoTransPenerimaanBaru = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                        string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                        , 4, false, true);

            // ke penerimaanuang

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowIDTambahan));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaanBaru)); // tadinya newNoTrans txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilai));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, decNilai));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (txtUraian.Text + " - Tambahan titipan Tunai") + " | " + lblNama.Text + " | " + _nopol ));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini angsuran 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }                  
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

                     //penerimaanAngsuranInsert(ref db, ref counterdb, nominalBGC, nominalPembayaran, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Pokok, _rowIDNew, noTransNew, penerimaanUangRowID_Bunga, penerimaanUangRowID_Denda, penerimaanPBLRowID, PotonganPelunasanRowID);
        private void penerimaanAngsuranInsert(ref Database db, ref int counterdb, Double decNilaiBGC, Double decNilaiNominal, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, Guid newRowID, String newNoTrans, Guid penerimaanUangRowID_Bunga, Guid penerimaanUangRowID_Denda, Guid penerimaanPBLRowID, Guid PotonganPelunasanRowID)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, newRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, newNoTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, mode == FormMode.Angsuran ? "ANG" : _tipeMode == "ADJ" ? "PLA"  : (mode == FormMode.Pelunasan ? "PLS" : "TRK")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (txtUraian.Text) ));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); //GlobalVar.GetServerDate
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.Date, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Date, dtbTglJTAngsuran.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Float, Convert.ToDouble(lblAngsuranKe.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue.ToString()));
            if (mode == FormMode.Tarikanv2)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, Convert.ToDouble(_saldoBunga.ToString())));
            }
            else if (mode == FormMode.TarikanNV1)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, 0));
            }
            else //tarikanNV2
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, Convert.ToDouble(ntbNominalBunga.Text)));
            }

            if (mode == FormMode.TarikanNV1)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, 0));
            
                db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0));
                
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPokok", SqlDbType.Money, 0));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, 0));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0));
            }
            else // tarikanNV2
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, decNilaiNominal));
            
                db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, decNilaiBGC));
                
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPokok", SqlDbType.Money, Convert.ToDouble(txtBayarPokok.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, Convert.ToDouble(txtDenda.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0));
            }
            
            if (lookUpKolektor._Kolektor.RowID == System.Guid.Empty)
            {
            }
            else
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor._Kolektor.RowID));
            }
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            
            // kalo modenya Tarikan jadinya bentuk pembayarannya 5
            //if (mode == FormMode.Tarikan || mode == FormMode.Tarikanv2)
            //{
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5)); // kalau tarikan selalu 5
            //}
            //else
            if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5)); // kalau tarikan selalu 5
            }
            else // selain tarikan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, cbxBentukPembayaran.SelectedIndex + 1));
            }

            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, lookUpRekening1.RekeningRowID));

            // dan ga boleh mode tarikan
            if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2 || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
            {
            }
            //else if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
            //{
            //}
            else //bukan tarikan dan bukan giro atau titipan
            {
                // hanya insert parameter ini kalo bukan giro dan bukan titipan
                if (Convert.ToDecimal(txtBayarPokok.Text) > 0)
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
                }
                if (Convert.ToDecimal(ntbNominalBunga.Text) > 0)
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowIDBNG", SqlDbType.UniqueIdentifier, penerimaanUangRowID_Bunga));
                }
                if (Convert.ToDecimal(txtDenda.Text) > 0 && cbxDenda.Checked == true) // memang dibayarkan
                {
                    // hitung periode dendanya
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PeriodeDenda", SqlDbType.Int, periodeDenda));
                    
                    /* // masuknya sekarang ke penerimaanDenda saja!!!
                        db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowIDDND", SqlDbType.UniqueIdentifier, penerimaanUangRowID_Denda));
                    */
                }
            }

            //if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
            //{
            //}

            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
                {
                    //ga usah create penerimaanuangrowid kalau dia tarikan
                }
                else
                {
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
                }
            }

            if (mode == FormMode.Pelunasan && GlobalVar.CabangID.Contains("06") && txtPotongan.GetDoubleValue > 0)
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PotonganPelunasan", SqlDbType.Money, txtPotongan.GetDoubleValue));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PotonganPengeluaranUangRowID", SqlDbType.UniqueIdentifier, PotonganPelunasanRowID));
                
            }

            //if (mode == FormMode.Tarikan || mode == FormMode.Tarikanv2) 
            //{
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@TglACC", SqlDbType.Date, dtbTglAcc.DateValue));
            //}
            //else
            if ((mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2) && GlobalVar.CabangID.Contains("06"))
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
                db.Commands[counterdb].Parameters.Add(new Parameter("@TglACC", SqlDbType.Date, dtbTglAcc.DateValue));
            }
            //if (mode == FormMode.Tarikanv2)
            //{
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@HargaJual", SqlDbType.Money, ntbHargaJual.GetDoubleValue));
            //    db.Commands[counterdb].Parameters.Add(new Parameter("@Customer", SqlDbType.Text, lookUpCustomer1.txtNamaCustomer.Text));            
            //}

            counterdb++;
        }

        private void penerimaanTitipanIdenInsert(ref Database db, ref int counterdb, Guid PenerimaanAngsuranRowID, Guid PenerimaanDendaRowID)
        {
            Double NominalDenda = 0;
            Double Nominal = txtPembayaran.GetDoubleValue;
            Double tempCurrAmount = 0;
            Double tempCurrInsert = 0;
            if(_kenaDenda == true && cbxDenda.Checked == true && txtBayarDenda.GetDoubleValue > 0)
            {
                NominalDenda = txtBayarDenda.GetDoubleValue;
            }
            foreach(AngsuranIden rowAngsuranIden in _listAngsuranIden)
            {
                tempCurrAmount = rowAngsuranIden.NominalIden;
                if(tempCurrAmount > 0 && NominalDenda > 0)
                {
                    if (tempCurrAmount >= NominalDenda)
                    {
                        tempCurrInsert = NominalDenda;
                        tempCurrAmount = tempCurrAmount - NominalDenda;
                        NominalDenda = 0;
                    }
                    else if (tempCurrAmount < NominalDenda)
                    {
                        tempCurrInsert = tempCurrAmount;
                        tempCurrAmount = 0;
                        NominalDenda = NominalDenda - tempCurrAmount;
                    }
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAngsuranIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanDNDRowID", SqlDbType.UniqueIdentifier, PenerimaanDendaRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value )); // GlobalVar.GetServerDate
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrInsert));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
                if(tempCurrAmount > 0 && Nominal > 0)
                {
                    if (tempCurrAmount >= Nominal)
                    {
                        tempCurrInsert = Nominal;
                        tempCurrAmount = tempCurrAmount - Nominal;
                        Nominal = 0;
                    }
                    else if (tempCurrAmount < Nominal)
                    {
                        tempCurrInsert = tempCurrAmount;
                        tempCurrAmount = 0;
                        Nominal = Nominal - tempCurrAmount;
                    }
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAngsuranIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanAngsuranRowID", SqlDbType.UniqueIdentifier, PenerimaanAngsuranRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); //GlobalVar.GetServerDate
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrInsert));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
                if (tempCurrAmount > 0 && Nominal < 1 && NominalDenda < 1) // kalau masih ada sisa juga, masukkin ke angsurannya aja
                {
                    db.Commands.Add(db.CreateCommand("usp_TitipanIden_Insert"));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, System.Guid.NewGuid()));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanTitipanRowID", SqlDbType.UniqueIdentifier, rowAngsuranIden.TitipanRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanAngsuranRowID", SqlDbType.UniqueIdentifier, PenerimaanAngsuranRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value )); // GlobalVar.GetServerDate
                    db.Commands[counterdb].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, tempCurrAmount));
                    db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    counterdb++;
                }
            }
        }

        // penerimaanUang jadi 3 data
        private void penerimaanUangInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String newNoTrans, Decimal newNominal, String suffix, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException(); 
            String KodeTrans = string.Empty;
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
            // ambil kodetrans dulu buat tau tipe angsurannya
            // usp_Penjualan_LIST   dengan @RowID = _penjRowID
            using (Database dbfsub = new Database())
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_Penjualan_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                KodeTrans = dtfsub.Rows[0]["KdTrans"].ToString();
            }
            // [usp_JnsTransaksi_LIST] @JnsTransaksi varchar 3
            using (Database dbfsub = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dtfsub = new DataTable();
                dbfsub.Commands.Add(dbfsub.CreateCommand("usp_JnsTransaksi_LIST"));
                dbfsub.Commands[0].Parameters.Add(new Parameter("@isAktif", SqlDbType.Int, 2));

                // main ngecek JnsTransaksinya dari suffix nya deh!!!
                if (suffix == " - Denda")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLADenda).ToString()));
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.Denda).ToString()));
                    }
                }
                else if (suffix == " - Pokok")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PiutangUsahaTetap).ToString()));
                }
                else if (suffix == " - Jual2")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLAPiutangUangMuka).ToString()));
                }
                else if (suffix == " - Bunga" && KodeTrans == "FLT")
                {
                    if (GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString())); //enumJnsTransaksi.PiutangBungaTetapTLA
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString()));
                    }
                }
                else if (suffix == " - Bunga" && KodeTrans == "APD")
                {
                    if(GlobalVar.CabangID.Contains("06"))
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString())); //enumJnsTransaksi.PiutangBungaMenurunTLA 
                    }
                    else
                    {
                        dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.PendapatanBungaKredit).ToString())); 
                    }
                }
                else
                {
                    throw (exDE);
                }
                    
                /*    
                else if (KodeTrans == "FLT")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.FLT).ToString() )); 
                }
                else if (KodeTrans == "APD")
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.APD).ToString())); 
                }
                */
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> newNoTrans / txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, newNominal));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, newNominal));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (txtUraian.Text + suffix) + " | " + lblNama.Text + " | " + _nopol));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini angsuran
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }                   
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private Guid simpanTarikan(ref Database db, ref int counterdb)
        {
            //Simpan Info Tarikan 
            System.Guid guidVendorRowID = System.Guid.Empty;
            db.Commands.Add(db.CreateCommand("usp_tarikanpenjualan_update"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(ntbEstimasiHrgMotor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanKolektor", SqlDbType.Money, Convert.ToDouble(ntbBiayaKolektor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanLainLain", SqlDbType.Money, Convert.ToDouble(ntbBiayaTarikan.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganTarikan", SqlDbType.VarChar, txtKeteranganTarikan.Text));
            counterdb++;

            //Copy Customer ke Vendor , sblm insert dicek dl, apakah rowidnya udah ada / blm atau no identitasnya udah ada atau blm 
            db.Commands.Add(db.CreateCommand("usp_CopyCustomerToVendor"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            object objVendorRowID = db.Commands[counterdb].ExecuteScalar();
            if (objVendorRowID != null)
            {
                guidVendorRowID = new System.Guid(Convert.ToString(objVendorRowID));
            }
            else
            {
                throw new Exception("Data Vendor tidak berhasil dibentuk !");
            }
            counterdb++;

            //Simpan Ke Pembelian                             
            db.Commands.Add(db.CreateCommand("usp_TarikanInsertKePembelian"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NewRowID", SqlDbType.UniqueIdentifier, newPembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, guidVendorRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(ntbEstimasiHrgMotor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserInitial));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTransPembayaranPembelian", SqlDbType.VarChar, Numerator.NextNumber("NTB")));
            counterdb++;

            return guidVendorRowID;
        }

        private Guid simpanTarikanv2(ref Database db, ref int counterdb)
        {
            System.Guid guidVendorRowID = System.Guid.Empty;
            db.Commands.Add(db.CreateCommand("usp_tarikanpenjualan_update"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(ntbEstimasiHrgMotor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanKolektor", SqlDbType.Money, Convert.ToDouble(ntbBiayaKolektor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanLainLain", SqlDbType.Money, Convert.ToDouble(ntbBiayaTarikan.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganTarikan", SqlDbType.VarChar, txtKeteranganTarikan.Text));
            counterdb++;

            return guidVendorRowID;
        }


        // kalo tarikkan masukkan ke PengeluaranUang
        private void pengeluaranUangInsert(ref Database dbf, ref int counterdbf, Guid pengeluaranUangRowID, String bentukPengeluaran, String NoTransPengeluaran, Guid VendorRowID, Double NominalKeluar, String JnsTransaksi, String InFix)
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
                dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, JnsTransaksi)); 
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }
            dbf.Commands.Add(dbf.CreateCommand("usp_PengeluaranUang_INSERT_SIMPLE"));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue.Value)); // tglrk.DateValue 
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, string.Empty)); // txtNoAcc.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, string.Empty)); // txtNoApproval1.Text

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPengeluaran)); // mestinya pake numerator

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));

            if (VendorRowID == Guid.Empty)
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, DBNull.Value));
            }
            else
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, VendorRowID));
            }

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));  // 32 - Pembelian Motor
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, NominalKeluar));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, NominalKeluar));

            if (VendorRowID == Guid.Empty)
            {
                // uraian nya lagi untuk potongan pelunasan
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - " + InFix + " | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            }
            else
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text + " - Tarikan " + InFix + " | " + lblNama.Text.Trim() + " | " + _nopol.Trim()));
            }

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, bentukPengeluaran)); // dari bentukPembayaran kah???
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, string.Empty)); // kosongin // aman untuk jurnal pengeluaran

            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, 9)); // defaultin 9

            if (cbxBentukPembayaran.SelectedIndex == 0) // kalo tunai baru kas rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // dari globalvar
            }
            else if (cbxBentukPembayaran.SelectedIndex == 1) // kalo transfer baru rekening rowid
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (Guid)Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty)));
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2)); // defaultin ke 2 (ke perusahaan)
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            if (mode == FormMode.Tarikanv2)
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@HargaJual", SqlDbType.Money, ntbHargaJual.GetDoubleValue));
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Customer", SqlDbType.Text, lookUpCustomer1.txtNamaCustomer.Text));
            }
            
            counterdbf++;
        }

        private void penerimaanPembulatanInsert(ref Database dbf, ref int counterdbf, Guid rekeningPembayaranRowID, Guid penerimaanUangRowID, String NoTransPenerimaan)
        {
            Guid _MataUangRowID, _JnsTransaksiRowID;
            String JnsPenerimaan = string.Empty;
            Exception exDE = new DataException();
            switch (cbxBentukPembayaran.SelectedIndex)
            {
                case 0: JnsPenerimaan = "K"; break;
                case 1: JnsPenerimaan = "B"; break;
                case 2: JnsPenerimaan = "G"; throw (exDE); break; // mestinya ngga bisa ke sini (giro)
                case 3: JnsPenerimaan = "K"; break;// kalau titipan + tunai bisa ke sini
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
                if (GlobalVar.CabangID.Contains("06"))
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.TLADenda).ToString())); // untuk 06 All masukin ke Pend Dend Angsuran 
                }
                else
                {
                    dbfsub.Commands[0].Parameters.Add(new Parameter("@JnsTransaksi", SqlDbType.VarChar, ((int)enumJnsTransaksi.Pembulatan).ToString()));  // Pembulatan -> Pendapatan Lain - Lain (32)
                }               
                dtfsub = dbfsub.Commands[0].ExecuteDataTable();
                _JnsTransaksiRowID = (Guid)dtfsub.Rows[0]["RowID"];
            }

            dbf.Commands.Add(dbf.CreateCommand("usp_PenerimaanUang_INSERT_nonGiro"));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan)); // NoTransPenerimaan sebelumnya -> lblNoTrans.Text / txtNoBukti.Text
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txtTanggal.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, txtTglLunas.DateValue.Value)); // txttglRK.DateValue
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, String.Empty));  // masukin empty string
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PenerimaanDari", SqlDbType.TinyInt, 0)); // default 0 cboPenerimaanDari.SelectedIndex
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID)); // samain
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangDari", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, GlobalVar.CabangID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, _MataUangRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, _JnsTransaksiRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txtNominalPembulatan.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txtNominalPembulatan.Text)));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Pembulatan " + cboPembulatan.Text + " untuk Angsuran | " + lblNama.Text + " | " + _nopol));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, JnsPenerimaan)); // ini administrasi 
            if (JnsPenerimaan == "K")
            {
                dbf.Commands[counterdbf].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, GlobalVar.KasBesarRowID)); // kalo jenisnya kas, kasih KasRowID
            }
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningPembayaranRowID));
            dbf.Commands[counterdbf].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdbf++;
        }

        private void penerimaanDendaInsert(ref Database db, ref int counterdb, Guid PenerimaanDenda, Guid SrcRowID, String Src, Double Nominal, Guid penerimaanPBLRowID, Guid penerimaanUangRowID_Denda, String NoTransDenda)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenDendaRowID", SqlDbType.UniqueIdentifier, PenerimaanDenda));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDendaRowID", SqlDbType.UniqueIdentifier, SrcRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDenda", SqlDbType.VarChar, Src));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, NoTransDenda));

            /*
             * kena pembulatan tapi data pembulatannya di angsurannya aja!!!
            // di penerimaan Denda kalau lagi yang bayar angsuran kena denda
            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
            {
                // kalo nominal pembulatannya ngga 0, masukkin data RowID dan nominal pembulatannya
                db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPembulatan", SqlDbType.Money, Convert.ToDouble(txtNominalPembulatan.Text)));
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanPBLRowID", SqlDbType.UniqueIdentifier, penerimaanPBLRowID));
            }
            */
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, txtTglLunas.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, (cbxBentukPembayaran.SelectedIndex + 1)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            // ngga boleh titipan, kalau titipan, ngga masukkin data penerimaan uang baru
            if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan")
            {
            }
            else if(Convert.ToDecimal(txtDenda.Text) > 0 && cbxDenda.Checked == true && _kenaDenda == true) // memang dibayarkan
            {
                db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, penerimaanUangRowID_Denda));
            }
            counterdb++;
        }

        private void updateSuratTagihanLog(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_SuratTagihanLog_UPDATE_isProcessed"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@isProcessed", SqlDbType.TinyInt, 1));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            counterdb++;
        }

        private void SimpanAngsuran(Double nominalPembayaran, Double nominalBGC)
        {  
            Database db = new Database();
            Database dbf = new Database(GlobalVar.DBFinanceOto); 
            int counterdb = 0,counterdbf = 0;
            try
            {
                Guid penerimaanUangRowID_Pokok, penerimaanUangRowID_Bunga, penerimaanUangRowID_Denda, penerimaanUangRowID;
                penerimaanUangRowID_Pokok = Guid.Empty;
                penerimaanUangRowID_Bunga = Guid.Empty;
                penerimaanUangRowID_Denda = Guid.Empty;
                penerimaanUangRowID = Guid.Empty;

                Guid penerimaanPBLRowID = Guid.NewGuid();

                // _rowID = Guid.NewGuid();

                Guid _rowIDNew;
                Guid PotonganPelunasanRowID = Guid.NewGuid();
                _rowIDNew = _rowID;

                String noTransNew = "";


                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
            

                if (ValidateSave())
                {
                }
                else
                {
                    return;
                }

                // buat rowID untuk penerimaanAngsuran dan noTrans nya
                _rowIDNew = Guid.NewGuid();
                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    noTransNew = Numerator.NextNumber("NTP");
                }
                else
                {
                    noTransNew = "K" + Numerator.NextNumber("NKJ");
                }
                // buat penerimaanUangRowId nya 

                // mau input 3 kali sekali jalan jadinya
                if( Convert.ToDecimal(txtBayarPokok.Text) > 0)
                {
                    penerimaanUangRowID_Pokok = Guid.NewGuid();
                }
                if( Convert.ToDecimal(ntbNominalBunga.Text) > 0)
                {
                    penerimaanUangRowID_Bunga = Guid.NewGuid();
                }
                if (Convert.ToDecimal(txtDenda.Text) > 0)
                {
                    penerimaanUangRowID_Denda = Guid.NewGuid();
                }
                if (Convert.ToDecimal(ntbHargaJual.Text) > 0)
                {
                    penerimaanUangRowID = Guid.NewGuid();
                }
                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {
                    // kalo titipan kayak biasa
                    penerimaanTitipanInsert(ref db, ref counterdb, nominalBGC, _rowIDNew, noTransNew);
                }
                else
                {
                    if (mode == FormMode.Tarikanv2) 
                    {
                        penerimaanAngsuranInsert(ref db, ref counterdb, nominalBGC, nominalPembayaran, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Pokok, _rowIDNew, noTransNew, penerimaanUangRowID_Bunga, penerimaanUangRowID_Denda, penerimaanPBLRowID, PotonganPelunasanRowID);

                        String NoTransPengeluaran2 = "";
                        Guid tempVendorRowID = Guid.Empty;

                        tempVendorRowID = simpanTarikanv2(ref db, ref counterdb);

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

                        if (ntbBiayaTarikan.GetDoubleValue > 0)
                        {
                            // ini untuk biaya lain - lain
                            Database dbfNumerator2 = new Database(GlobalVar.DBFinanceOto);
                            Guid pengeluaranTarikanRowID = Guid.NewGuid();
                            NoTransPengeluaran2 = Numerator.GetNomorDokumen(dbfNumerator2, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                        string.Format("{0:yyMM}", txtTglLunas.DateValue.Value), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                            pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranTarikanRowID, tempBentukPenerimaan, NoTransPengeluaran2, tempVendorRowID, ntbBiayaTarikan.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Tarikan");
                        }
                        
                        //insert bkm untuk harga jual ke dua (ntbHargaJual)
                        Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                    "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                    string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                                    , 4, false, true);
                        penerimaanUangInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Pokok, noTransNew, Convert.ToDecimal(ntbHargaJual.Text), " - Jual2", NoTransPenerimaan);

                    }
                    else if (mode == FormMode.TarikanNV1) 
                    {
                        penerimaanAngsuranInsert(ref db, ref counterdb, nominalBGC, nominalPembayaran, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Pokok, _rowIDNew, noTransNew, penerimaanUangRowID_Bunga, penerimaanUangRowID_Denda, penerimaanPBLRowID, PotonganPelunasanRowID);
                        //String NoTransPengeluaran2 = "";
                        Guid tempVendorRowID = Guid.Empty;
                        tempVendorRowID = simpanTarikanNV1(ref db, ref counterdb);
                    }
                    
                   else { 
                        penerimaanAngsuranInsert(ref db, ref counterdb, nominalBGC, nominalPembayaran, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Pokok, _rowIDNew, noTransNew, penerimaanUangRowID_Bunga, penerimaanUangRowID_Denda, penerimaanPBLRowID, PotonganPelunasanRowID);
                        //if (mode != FormMode.Adjustment)
                        //{
                        // selain pembayaran dari giro dan titipan buat data penerimaan uang pembayaran ambil dari titipan 
                        if (cbxBentukPembayaran.SelectedIndex + 1 == 4)
                        {
                            Guid PenerimaanDendaNewRowID = Guid.NewGuid();
                            penerimaanTitipanIdenInsert(ref db, ref counterdb, _rowIDNew, PenerimaanDendaNewRowID);

                            // kalau kena denda dan bayar dengan titipan, penerimaan dendanya mesti dimasukkin juga
                            if (cbxDenda.Checked == true && Convert.ToDecimal(txtDenda.Text) > 0 && _kenaDenda == true) // berarti mau bayar denda
                            {
                                // masukkin ke penerimaan denda
                                String NoTransDenda = Numerator.NextNumber("NKD");
                                penerimaanDendaInsert(ref db, ref counterdb, PenerimaanDendaNewRowID, _rowIDNew, "Angsuran", Convert.ToDouble(txtDenda.Text.ToString()), penerimaanPBLRowID, penerimaanUangRowID_Denda, NoTransDenda);
                            }

                            if (modeBayarTitipan == 1) // titipan + tunai
                            {
                                penerimaanTitipanInsertTambahanTunai(ref db, ref counterdb, tambahanTunaiTitipan, _rowIDNew, noTransNew, ref dbf, ref counterdbf, penerimaanPBLRowID);
                                // kalau titipan tambah tunai itu masukkin juga pembulatannya, jadi perlu dicek
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
                                if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
                                {
                                    Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                                    String NoTransPenerimaanPBL = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                                "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                                string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                                                , 4, false, true);
                                    penerimaanPembulatanInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanPBLRowID, NoTransPenerimaanPBL);
                                }
                            }
                        }
                        // selain pembayaran dari giro dan titipan buat data penerimaan uang dan ga oleh mode tarikan
                        if (mode == FormMode.Tarikan || mode == FormMode.Tarikanv2 || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "titipan" || cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                        {
                        }
                        else if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
                        {

                        }
                        else
                        {
                            // buat no Bukti PenerimaanUang baru
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

                            // hanya insert ke penerimaan uang ini kalo bukan giro dan bukan titipan
                            if (Convert.ToDecimal(txtBayarPokok.Text) > 0)
                            {
                                // buat no trans penerimaanUang nya dulu
                                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                            "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                                            , 4, false, true);
                                penerimaanUangInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Pokok, noTransNew, Convert.ToDecimal(txtBayarPokok.Text), " - Pokok", NoTransPenerimaan);
                            }
                            if (Convert.ToDecimal(ntbNominalBunga.Text) > 0)
                            {
                                // buat no trans penerimaanUang nya dulu
                                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                            "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                                            , 4, false, true);
                                penerimaanUangInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Bunga, noTransNew, Convert.ToDecimal(ntbNominalBunga.Text), " - Bunga", NoTransPenerimaan);
                            }
                            if (Convert.ToDecimal(txtDenda.Text) > 0 || _kenaDenda == true)
                            {
                                if (cbxDenda.Checked == true) // berarti mau bayar denda
                                {
                                    // buat no trans penerimaanUang nya dulu
                                    Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                    String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                                "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                                string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                                                , 4, false, true);
                                    penerimaanUangInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanUangRowID_Denda, noTransNew, Convert.ToDecimal(txtDenda.Text), " - Denda", NoTransPenerimaan);

                                    // masukkin ke penerimaan denda
                                    Guid PenerimaanDendaNewRowID = Guid.NewGuid();
                                    String NoTransDenda = Numerator.NextNumber("NKD");
                                    penerimaanDendaInsert(ref db, ref counterdb, PenerimaanDendaNewRowID, _rowIDNew, "Angsuran", Convert.ToDouble(txtDenda.Text.ToString()), penerimaanPBLRowID, penerimaanUangRowID_Denda, NoTransDenda);

                                }
                                else if (cbxDenda.Checked == false) // berarti ngga mau bayar denda
                                {
                                    // kalo ngga bayar...
                                    // ngga perlu masukkin data ke penerimaanUang dan ke penerimaanDenda
                                }
                            }

                            // masukkin data pembulatan ke penerimaanUang
                            if (Convert.ToDouble(Tools.isNull(txtNominalPembulatan.Text, 0).ToString()) > 0)
                            {
                                Database dbfNumeratorsub = new Database(GlobalVar.DBFinanceOto);
                                String NoTransPenerimaanPBL = Numerator.GetNomorDokumen(dbfNumeratorsub, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                            "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value)
                                                            , 4, false, true);
                                penerimaanPembulatanInsert(ref dbf, ref counterdbf, lookUpRekening1.RekeningRowID, penerimaanPBLRowID, NoTransPenerimaanPBL);
                            }

                        }

                        //simpan tarikan lama
                        if (mode == FormMode.Tarikan || mode == FormMode.Tarikanv2)
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
                            String NoTransPengeluaran = "";
                            String NoTransPengeluaran2 = "";
                            Guid tempVendorRowID = Guid.Empty;

                            tempVendorRowID = simpanTarikan(ref db, ref counterdb);
                            // di bawah ini itu ngebentuk Bukti Uang Keluar bukan bukti bayar pembelian !!!

                            if (ntbBiayaKolektor.GetDoubleValue > 0)
                            {
                                // ini untuk biaya kolektor
                                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                Guid pengeluaranKolektorRowID = Guid.NewGuid();
                                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                                pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranKolektorRowID, tempBentukPenerimaan, NoTransPengeluaran, tempVendorRowID, ntbBiayaKolektor.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Kolektor");

                                if (GlobalVar.CabangID.Contains("13")) // cabang 13, KTS-BYL ngga boleh diproses pembayaran pembeliannya
                                {
                                }
                                else
                                {
                                    // per tanggal 27 jul 2016 biaya tarikan tidak usah ditambah di pembayaran pemb karena udah include di HPP pembelian, kalau dimasukin ntar double
                                    // pembayaranPembInsert(ref db, ref counterdb, pengeluaranTarikanRowID, "TARIKAN", ntbBiayaTarikan.GetDoubleValue);
                                }
                            }

                            if (ntbBiayaTarikan.GetDoubleValue > 0)
                            {
                                // ini untuk biaya lain - lain
                                Database dbfNumerator2 = new Database(GlobalVar.DBFinanceOto);
                                Guid pengeluaranTarikanRowID = Guid.NewGuid();
                                NoTransPengeluaran2 = Numerator.GetNomorDokumen(dbfNumerator2, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                                pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranTarikanRowID, tempBentukPenerimaan, NoTransPengeluaran2, tempVendorRowID, ntbBiayaTarikan.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Tarikan");

                                if (GlobalVar.CabangID.Contains("13")) // cabang 13, KTS-BYL ngga boleh diproses pembayaran pembeliannya
                                {
                                }
                                else
                                {
                                    pembayaranPembInsert(ref db, ref counterdb, pengeluaranTarikanRowID, "TARIKAN", ntbBiayaTarikan.GetDoubleValue);
                                }
                            }
                        }

                        // simpanTarikanNV1 tarikan baru Tarikan 2
                        if (mode == FormMode.TarikanNV2)
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
                            String NoTransPengeluaran = "";
                            String NoTransPengeluaran2 = "";
                            Guid tempVendorRowID = Guid.Empty;

                            tempVendorRowID = simpanTarikanNV2(ref db, ref counterdb);
                            // di bawah ini itu ngebentuk Bukti Uang Keluar bukan bukti bayar pembelian !!!

                            if (ntbBiayaKolektor.GetDoubleValue > 0)
                            {
                                // ini untuk biaya kolektor
                                Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                                Guid pengeluaranKolektorRowID = Guid.NewGuid();
                                NoTransPengeluaran = Numerator.GetNomorDokumen(dbfNumerator, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                                pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranKolektorRowID, tempBentukPenerimaan, NoTransPengeluaran, tempVendorRowID, ntbBiayaKolektor.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Kolektor");

                                if (GlobalVar.CabangID.Contains("13")) // cabang 13, KTS-BYL ngga boleh diproses pembayaran pembeliannya
                                {
                                }
                                else
                                {
                                    pembayaranPembInsert(ref db, ref counterdb, pengeluaranKolektorRowID, "KOLEKTOR", ntbBiayaKolektor.GetDoubleValue);
                                }
                            }

                            if (ntbBiayaTarikan.GetDoubleValue > 0)
                            {
                                // ini untuk biaya lain - lain
                                Database dbfNumerator2 = new Database(GlobalVar.DBFinanceOto);
                                Guid pengeluaranTarikanRowID = Guid.NewGuid();
                                NoTransPengeluaran2 = Numerator.GetNomorDokumen(dbfNumerator2, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                            string.Format("{0:yyMM}", txtTglLunas.DateValue.Value), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                                pengeluaranUangInsert(ref dbf, ref counterdbf, pengeluaranTarikanRowID, tempBentukPenerimaan, NoTransPengeluaran2, tempVendorRowID, ntbBiayaTarikan.GetDoubleValue, ((int)enumJnsTransaksi.BiayaTarikan).ToString(), "Biaya Tarikan");

                                //if (GlobalVar.CabangID.Contains("13")) // cabang 13, KTS-BYL ngga boleh diproses pembayaran pembeliannya
                                //{
                                //}
                                //else
                                //{
                                //    // per tanggal 27 jul 2016 biaya tarikan tidak usah ditambah di pembayaran pemb karena udah include di HPP pembelian, kalau dimasukin ntar double
                                //     pembayaranPembInsert(ref db, ref counterdb, pengeluaranTarikanRowID, "TARIKAN", ntbBiayaTarikan.GetDoubleValue);
                                //}
                            }

                        }
                    }
                }

                if(mode == FormMode.Pelunasan && GlobalVar.CabangID.Contains("06"))
                {
                    if (txtPotongan.GetDoubleValue > 0)
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
                        // ini untuk impasin pelunasan yg masuk, supaya berkuran sejumlah potongan
                        Database dbfNumerator2 = new Database(GlobalVar.DBFinanceOto);
                        String NoTransPengeluaran2 = Numerator.GetNomorDokumen(dbfNumerator2, "PENGAJUAN_PENGELUARAN_UANG", GlobalVar.PerusahaanID, "/B" + tempBentukPenerimaan + "K/" +
                                                                    string.Format("{0:yyMM}", txtTglLunas.DateValue.Value), 4, false, true);  // pake ambil numeratornya finance dan coba pake koding yg punya pengeluaranuang insert??? 

                        pengeluaranUangInsert(ref dbf, ref counterdbf, PotonganPelunasanRowID, tempBentukPenerimaan, NoTransPengeluaran2, Guid.Empty, txtPotongan.GetDoubleValue, ((int)enumJnsTransaksi.TLAPotonganPelunasan).ToString(), "Potongan Pelunasan");
                    }

                }

                updateSuratTagihanLog(ref db, ref counterdb);

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
                this.DialogResult = DialogResult.OK;
                _rowID = _rowIDNew;
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                dbf.RollbackTransaction();    
                Error.LogError(ex, "Insert data angsuran gagal" ); 
            }
        }

        private void pembayaranPembInsert(ref Database db, ref int counterdb, Guid pengeluaranUangRowID, String Ket, Double Nominal)
        {
            db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid())); //_rowID
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, Numerator.NextNumber("NKB")));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "TAM")); // pasti tambahan

            db.Commands[counterdb].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, newPembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.Text, "TRK|" + Ket + "-" + txtUraian.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[counterdb].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

            db.Commands[counterdb].Parameters.Add(new Parameter("@PengeluaranUangRowID", SqlDbType.UniqueIdentifier, pengeluaranUangRowID));

            // tambahin bentuk pembayarannya sama rekening rowID nya
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1)); // pasti tunai

            counterdb++;
        }

        private void BindData()
        {
            try
            {
                // potongan hanya kelihatan kalau pas Pelunasan di TLA
                lblPotongan.Visible = false;
                txtPotongan.Visible = false;

                cbxBentukPembayaran.SelectedIndex = 0; 
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value));
                    dt = db.Commands[0].ExecuteDataTable();
                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblTglJual.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglJual"]);
                    _tglJual = (DateTime)dt.Rows[0]["TglJual"];
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    if (mode == FormMode.TarikanNV1)
                    {
                        lblAngsuranKe.Text = Tools.isNull(dt.Rows[0]["AngsuranTerakhir"], "0").ToString();
                    }
                    else
                    {
                        lblAngsuranKe.Text = Tools.isNull(dt.Rows[0]["AngsuranKe"], "").ToString();
                    }

                   txtEstimasiBiayaTarikan.Text = Tools.isNull(dt.Rows[0]["EstimasiBiayaTarikan"], "0").ToString();
                    
                    if (mode == FormMode.TarikanNV2)
                    {
                        ntbEstimasiHrgMotor.Text = Tools.isNull(dt.Rows[0]["TarikanEstimasiHrgMotor"], "0").ToString();
                        ntbBiayaTarikan.Text=Tools.isNull(dt.Rows[0]["EstimasiBiayaTarikan"], "0").ToString();                        
                        dtbTglTarikan.DateValue = (DateTime)dt.Rows[0]["TarikanTgl2"];
                    }
                    
                    dtbTglJTAngsuran.DateValue = Convert.ToDateTime(dt.Rows[0]["TglJTAngsuran"]);
                    _boolPeriodeAngsuranSama = Convert.ToBoolean(dt.Rows[0]["FlagPeriodeAngsuranSama"]);
                    _CustomerRowID = new Guid(dt.Rows[0]["CustomerRowID"].ToString()); 

                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    _nopol = Tools.isNull(dt.Rows[0]["NoPol"], "").ToString();

                    _tidakperlubayarbunga = Convert.ToBoolean(dt.Rows[0]["FlagTidakPerluBayarBunga"]);

                    txtBebasBunga.DateValue = (DateTime)dt.Rows[0]["tglbebasbunga"];
                    txtBebasDenda.DateValue = (DateTime)dt.Rows[0]["tglbebasdenda"];

                    DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                    dt2.DefaultView.Sort = "MataUangID ASC";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.ValueMember = "MataUangID";
                    cboMataUang.DataSource = dt2.DefaultView;

                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }

                    // tes data surat tagihan
                    int batasST = 0;
                    DataTable dtBatasST = new DataTable();
                    using (Database dbBatasST = new Database())
                    {
                        dbBatasST.Commands.Add(dbBatasST.CreateCommand("usp_AppSetting_LIST"));
                        dbBatasST.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "BATASSURATTAGIH"));
                        dtBatasST = dbBatasST.Commands[0].ExecuteDataTable();
                        batasST = Convert.ToInt32(dtBatasST.Rows[0]["Value"].ToString());
                    }

                    DataTable dtST = new DataTable();
                    using (Database dbST = new Database())
                    {
                        dbST.Commands.Add(dbST.CreateCommand("usp_SuratTagihanLog_LIST"));
                        dbST.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        dbST.Commands[0].Parameters.Add(new Parameter("@isProcessed", SqlDbType.TinyInt, 0));
                        dtST = dbST.Commands[0].ExecuteDataTable();
                        if (dtST.Rows.Count > 0)
                        {
                            _fromSuratTagih = true;
                            _cetakST = Convert.ToDateTime(dtST.Rows[0]["TglCetak"].ToString());
                            _dendaST = Convert.ToDouble(dtST.Rows[0]["NominalDenda"].ToString());
                            if(_cetakST >= GlobalVar.GetServerDateTime_RealTime.AddDays(-3) && (_cetakST <= GlobalVar.GetServerDateTime_RealTime ))
                            {
                                

                            }
                            else
                            {
                                _fromSuratTagih = false;
                                _cetakST = DateTime.MinValue;
                                _dendaST = -1;
                            }
                        }
                        else
                        {
                            _fromSuratTagih = false;
                            _cetakST = DateTime.MinValue;
                            _dendaST = -1;
                        }
                    }


                    this.refresh();
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

        private void refresh()
        {
            try
            {

                //harusnya bukan di tanggal lunasnya, tp pas query ke db utk ngehitung rincian angsurannya yg tglnya diubah , 
                //seolah - olah mundur 
                //if (_fromSuratTagih == true)
                //{
                //    txtTglLunas.DateValue = _cetakST;
                //    txtTglLunas.Enabled = false;
                //    txtTglLunas.ReadOnly = true;
                //}

                //if (_fromSuratTagih == true && GlobalVar.CabangID.Contains("06")) matiin dulu ntar kas nya selisih dong kalau mundur2 lagian di KTS juga udah ga berlaku
                //{
                //    txtTglLunas.DateValue = _cetakST;
                //    txtTglLunas.Enabled = false;
                //    txtTglLunas.ReadOnly = true;
                //}


                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Angsuran_PiutangBerjalan"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "ANG"));

                    //if (_fromSuratTagih == true)
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, _cetakST));
                    //  }
                    //else
                    //{
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue.Value));
                   // }

                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtSaldoTitipan.Text = Tools.isNull(dt.Rows[0]["SaldoTTP"], 0).ToString();
                _kodeTrans = Tools.isNull(dt.Rows[0]["KodeTrans"], "").ToString();
                _tempo = Convert.ToInt32(Tools.isNull(dt.Rows[0]["TempoAngsuran"], 0).ToString());

                _tglAkhirAngs = _tglJual.AddMonths(_tempo);
                _angsKe = int.Parse(lblAngsuranKe.Text);
                DateTime Today = GlobalVar.GetServerDate;

                if (_kodeTrans == "FLT")
                {
                    lblslash.Visible = true;
                    lblMax.Visible = true;
                    txtMaxDenda.Visible = true;

                    lblBebasBunga.Visible = false;
                    txtBebasBunga.Visible = false;

                    lblBebasDenda.Visible = true;
                    txtBebasDenda.Visible = true;
                    txtBebasDenda.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["TglBebasDenda"], DateTime.MinValue).ToString());
                }
                else if (_kodeTrans == "APD")
                {
                    lblslash.Visible = false;
                    lblMax.Visible = false;
                    txtMaxDenda.Visible = false;

                    lblBebasBunga.Visible = true;
                    txtBebasBunga.Visible = true;

                    lblBebasDenda.Visible = true;
                    txtBebasDenda.Visible = true;
                }

                txtBayarDenda.Text = "0";
                cbxDenda.Enabled = false;
                cboPembulatan.SelectedIndex = 0;
                cbxBentukPembayaran.SelectedIndex = 0;
                switch (mode)
                {
                    case FormMode.Angsuran:
                        this.Text = this.Title = "Kwitansi Angsuran";

                        _angsKe = int.Parse(lblAngsuranKe.Text);

                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();
                        txtPiutangPokok.ReadOnly = txtBayarPokok.ReadOnly = true;
                        
                        /*
                        lblSaldoBunga.Text = "Angsuran Ke-";
                        txtPiutangBunga.Text = _angsKe.ToString();
                        */

                        //if (_boolPeriodeAngsuranSama)
                        //{
                        //    ntbNominalBunga.Text = txtDenda.Text = txtTotal.Text = txtBayarPokok.Text = "0";
                        //}
                        //else
                        //{  
                        //txtMaxDenda.Text = Tools.isNull(dt.Rows[0]["Denda"], 0).ToString();
                        if (_kodeTrans == "APD")
                        {
                            txtDenda.Text = Tools.isNull(dt.Rows[0]["Denda"], 0).ToString();
                        }
                        else
                        {
                            txtDenda.Text = Tools.isNull(dt.Rows[0]["DendaHarian"], 0).ToString();
                        }
                        // txtTotal.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Angsuran"], 0))).ToString(); // kalo totalnya ngga usah perhitungkan denda // + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))).ToString();
                        if (_tempo == _angsKe && _kodeTrans == "FLT")
                        {
                            txtBayarPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();
                            txtPembayaran.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString()) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0))).ToString();
                        }
                        else
                        {
                            txtBayarPokok.Text = Tools.isNull(dt.Rows[0]["AngsuranPokok"], 0).ToString(); // Tools.isNull(dt.Rows[0]["AngsuranPokok"], 0).ToString();
                            txtPembayaran.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Angsuran"], 0).ToString()).ToString();// + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))).ToString();
                        }
                         //}
                        
                        if (_tidakperlubayarbunga)
                        {
                            ntbNominalBunga.Text = "0";
                            // berarti txt Pembayarannya defaultnya hanya bayar pokoknya saja
                            txtPembayaran.Text = txtBayarPokok.Text;
                        }
                        else
                        {
                            Double SaldoBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0).ToString());
                            ntbNominalBunga.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)).ToString();
                            //string saldobunga_ = SaldoBunga.ToString();
                            //MessageBox.Show ("Saldo bunga = "+saldobunga_);

                            //if (ntbNominalBunga.GetDoubleValue > SaldoBunga)
                            //{
                            //    Double Selisih = ntbNominalBunga.GetDoubleValue - SaldoBunga;
                            //    ntbNominalBunga.Text = SaldoBunga.ToString();
                            //    txtPembayaran.Text = (txtPembayaran.GetDoubleValue - Selisih).ToString();
                            //}
                        }
                       // txtPembayaran.ReadOnly = true;
                        txtUraian.Text = "ANGSURAN KE - " + _angsKe.ToString();
                        txtNoBG.Text = txtTglBG.Text = "";
                        //txtPembayaran.Enabled = false;

                        // cek apakah kena denda?
                        if (_kodeTrans == "FLT" && Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0)
                        {
                            if (GlobalVar.CabangID.Contains("06"))
                            {   /*
                                    if (dtbTglJTAngsuran.DateValue.Value.Year == txtTglLunas.DateValue.Value.Year &&
                                        dtbTglJTAngsuran.DateValue.Value.Month == txtTglLunas.DateValue.Value.Month)
                                    {
                                        // kalau kena denda tapi masih 1 bulan ngga kena dulu, 
                                        // kalau udah ganti bulan baru kena denda pas angsuran
                                        _kenaDenda = false;
                                        Denda = 0;
                                        cbxDenda.Enabled = false;
                                        cbxDenda.Checked = false;
                                        txtBayarDenda.Text = "0";
                                        txtDenda.Text = "0";
                                    }
                                    else
                                    {*/
                                _kenaDenda = true;
                                if (_kodeTrans == "APD")
                                {
                                    Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0));
                                    cbxDenda.Enabled = true;
                                    cbxDenda.Checked = true;
                                    txtBayarDenda.Text = Denda.ToString();
                                    periodeDenda = 0;
                                    hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));

                                }
                                else if (_kodeTrans == "FLT")
                                {
                                    _kenaDenda = true;
                                    Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0));
                                    cbxDenda.Enabled = true;
                                    cbxDenda.Checked = true;
                                    txtBayarDenda.Text = Denda.ToString();
                                    periodeDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["PeriodeDenda"], 0));
                                    hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                                    txtMaxDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaMax"], 0).ToString()).ToString();
                                }
                                //}

                            }
                            else
                            {
                                if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0 || Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0)
                                {
                                    if (_kodeTrans == "APD")
                                    {
                                        _kenaDenda = true;
                                        Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0));
                                        cbxDenda.Enabled = true;
                                        cbxDenda.Checked = true;
                                        txtBayarDenda.Text = Denda.ToString();
                                        periodeDenda = 0;
                                        hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                                    }
                                    else if (_kodeTrans == "FLT" && Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0)
                                    {
                                        _kenaDenda = true;
                                        Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0));
                                        cbxDenda.Enabled = true;
                                        cbxDenda.Checked = true;
                                        txtBayarDenda.Text = Denda.ToString();
                                        periodeDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["PeriodeDenda"], 0));
                                        hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                                        txtMaxDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaMax"], 0).ToString()).ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0 || Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0)
                            {
                                if (_kodeTrans == "APD")
                                {
                                    _kenaDenda = true;
                                    Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0));
                                    cbxDenda.Enabled = true;
                                    cbxDenda.Checked = true;
                                    txtBayarDenda.Text = Denda.ToString();
                                    periodeDenda = 0;
                                    hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                                }
                                else if (_kodeTrans == "FLT" && Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0)
                                {
                                    _kenaDenda = true;
                                    Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0));
                                    cbxDenda.Enabled = true;
                                    cbxDenda.Checked = true;
                                    txtBayarDenda.Text = Denda.ToString();
                                    periodeDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["PeriodeDenda"], 0));
                                    hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                                    txtMaxDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaMax"], 0).ToString()).ToString();
                                }
                            }
                        }

                        // kalau ini cabang 06, tgl pelunasannya boleh diisi manual dengan batasan hanya +1 / +2 hari saja
                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}

                        break;
                    case FormMode.Pelunasan:
                        this.Text = this.Title = "Kwitansi Pelunasan";

                        if (GlobalVar.CabangID.Contains("06"))
                        {
                            // berarti lagi pelunasan di TLA
                            lblPotongan.Visible = true;
                            txtPotongan.Visible = true;
                            txtPotongan.Text = "0";
                        }


                        _angsKe = int.Parse(lblAngsuranKe.Text);
                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();
                        txtPiutangPokok.ReadOnly = txtBayarPokok.ReadOnly = true;

                        /*
                        lblSaldoBunga.Text = "Angsuran Ke-";
                        txtPiutangBunga.Text = _angsKe.ToString();
                        */

                        if (_kodeTrans == "APD")
                        {
                            ntbNominalBunga.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)).ToString();
                            if (_kodeTrans == "APD")
                            {
                                txtDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)).ToString();
                            }
                            else
                            {
                                txtDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)).ToString();
                            }
                            if (_tidakperlubayarbunga || _boolPeriodeAngsuranSama)
                            {
                                ntbNominalBunga.Text = "0";
                                // berarti txt Pembayarannya defaultnya hanya bayar pokoknya saja
                                txtPembayaran.Text = txtBayarPokok.Text;
                            }
                            else
                            {
                                ntbNominalBunga.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)).ToString();
                            }
                        }
                        else if (_kodeTrans == "FLT")
                        {
                            if (_boolPeriodeAngsuranSama)
                            {
                                //ditambah appsetting 
                                //ga ditambah bunganya, krn udah 2x pembayaran di periode sama, jd hanya 1x bunga, kalo ditambah bunga pembayaran sblmnya jdnya 2x jg 
                                // nope, ngga kena bunga sama sekali
                                if (GlobalVar.CabangID.Contains("06")) // kalau kode cabang itu GRUP depannya "06" 
                                {
                                    // hitungan tambah bunganya berbeda
                                    // cek bayaran ke nya
                                    Double Pokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPokok"], 0).ToString());
                                    Double Bunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0).ToString());
                                    Double SaldoPokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString());
                                    Double SaldoBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0).ToString());
                                    Double HapusBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["POTBNGTLA"], 0).ToString());
                                    Double BayaranBunga = (SaldoBunga) * 20 / 100; // SaldoBunga - HapusBunga;


                                    //jika ada data pembayaran pokok terpotong, berarti dikarenakan codingan dibawah ini, dan dianggap salah 
                                    //sehingga jika masih ditemukan, perbaiki secara data dan perhatikan accountingnya 
                                    //txtPiutangPokok.Text = (SaldoPokok - Bunga).ToString();
                                    txtPiutangPokok.Text = (SaldoPokok).ToString();

                                    ntbNominalBunga.Text = ((SaldoBunga + Bunga) * 20 / 100).ToString();// (SaldoBunga - HapusBunga).ToString();
                                }
                                else
                                {
                                    // klo periode sama di FLT cabang 13, ini -1 aja bunga nya
                                    int selisihBulan = 0;
                                    if (Today.AddMonths(1) < _tglAkhirAngs)
                                    {
                                        selisihBulan = ((Today.Date.Year - _tglJual.Date.Year) * 12) + (Today.Date.Month - _tglJual.Date.Month);
                                    }
                                    else
                                    {
                                        selisihBulan = ((_tglAkhirAngs.Date.Year - _tglJual.Date.Year) * 12) + (_tglAkhirAngs.Date.Month - _tglJual.Date.Month);
                                    }

                                    selisihBulan = selisihBulan - (_angsKe - 1); //_angsKe - 1 digunakan agar bunga tidak minus dan seharusnya 0
                                    ntbNominalBunga.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)) * selisihBulan).ToString();
                                    //if (ntbNominalBunga.GetDoubleValue < 0) ntbNominalBunga.Text = "0";
                                }
                            }
                            else if (GlobalVar.CabangID.Contains("06")) // kalau kode cabang itu GRUP depannya "06" 
                            {
                                Double Pokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPokok"], 0).ToString());
                                Double Bunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0).ToString());
                                Double SaldoPokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString());
                                Double SaldoBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0).ToString());
                                Double HapusBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["POTBNGTLA"], 0).ToString());

                                Double BayaranBunga = SaldoBunga - HapusBunga; // (SaldoBunga) * 20 / 100;

                                txtPiutangPokok.Text = (SaldoPokok).ToString();
                                ntbNominalBunga.Text = BayaranBunga.ToString();
                                //if (ntbNominalBunga.GetDoubleValue < 0) ntbNominalBunga.Text = "0";
                            }
                            else
                            {
                                //ditambah appsetting 
                                // untuk kts byl perlu tahu kontrak habisnya kapan jadi ngga kelebihan dendanya
                                // klo periode sama di FLT cabang 13, ini -1 aja bunga nya
                                int selisihBulan = 0;
                                if (Today.AddMonths(1) < _tglAkhirAngs)
                                {
                                    selisihBulan = ((Today.Date.Year - _tglJual.Date.Year) * 12) + (Today.Date.Month - _tglJual.Date.Month);
                                }
                                else
                                {
                                    selisihBulan = ((_tglAkhirAngs.Date.Year - _tglJual.Date.Year) * 12) + (_tglAkhirAngs.Date.Month - _tglJual.Date.Month);
                                }
                                selisihBulan = selisihBulan - (_angsKe - 1);
                                ntbNominalBunga.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)) * selisihBulan).ToString();
                                if (ntbNominalBunga.GetDoubleValue < 0) ntbNominalBunga.Text = "0";
                            }
                        }
                        if (_kodeTrans == "APD")
                        {
                            txtDenda.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0))).ToString();
                        }
                        else
                        {
                            txtDenda.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0))).ToString();
                        }


                        txtBayarPokok.Text = txtPiutangPokok.Text;
                        // txtTotal.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(ntbNominalBunga.Text)).ToString(); // kalo total ngga usah perhitungkan denda //  + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))
                        txtPembayaran.Text = (Convert.ToDouble(txtPiutangPokok.Text) + Convert.ToDouble(ntbNominalBunga.Text)).ToString(); // + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) 
                        txtUraian.Text = "Pelunasan Angsuran";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtPembayaran.Enabled = false;
                        // cek apakah kena denda?
                        if (_kodeTrans == "FLT" && (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0 || Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) > 0))
                        {
                            _kenaDenda = true;
                            Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0));
                            cbxDenda.Enabled = true;
                            cbxDenda.Checked = true;
                            txtBayarDenda.Text = Denda.ToString();
                            periodeDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["PeriodeDenda"], 0));
                            hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                            txtMaxDenda.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaMax"], 0).ToString()) + (Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)).ToString())).ToString();
                        }
                        else if (_kodeTrans == "APD" && (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) > 0 || Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) > 0))
                        {
                            _kenaDenda = true;
                            Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0));
                            cbxDenda.Enabled = true;
                            cbxDenda.Checked = true;
                            txtBayarDenda.Text = Denda.ToString();
                            periodeDenda = 0;
                            hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                        }

                        // kalau ini cabang 06, tgl pelunasannya boleh diisi manual dengan batasan hanya +1 / +2 hari saja
                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}
                        break;
                    case FormMode.Tarikan:
                        this.Text = this.Title = "Kwitansi Tarikan";
                        _angsKe = int.Parse(lblAngsuranKe.Text);

                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();

                        /*
                        lblSaldoBunga.Text = "Angsuran Ke-";
                        txtPiutangBunga.Text = _angsKe.ToString();
                        */

                        txtBayarPokok.ReadOnly = txtPiutangPokok.ReadOnly = true;
                        ntbNominalBunga.Text = txtDenda.Text = "0";
                        txtBayarPokok.Text = txtPiutangPokok.Text;
                        // txtTotal.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0))+ Convert.ToDouble(ntbNominalBunga.Text)).ToString(); //  + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))  // kalo total ngga usah perhitungkan denda
                        txtPembayaran.Text = (Convert.ToDouble(txtPiutangPokok.Text) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) + Convert.ToDouble(ntbNominalBunga.Text)).ToString();
                        txtUraian.Text = "Tarikan Motor";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtPembayaran.Enabled = cbxBentukPembayaran.Enabled = ntbBiayaKolektor.Enabled = false;
                        cbxBentukPembayaran.SelectedIndex = 0;
                        grpTarikan.Visible = true;
                        ntbBiayaKolektor.Text = "0";

                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    ntbBiayaKolektor.Text = "0";
                        //}

                        _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                        // kalo tarikan tambahin juga biaya kolektor dan biaya tarikannya
                        txtPembayaran.Text = (_saldo + Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0))).ToString();

                        // kalo udah tarikan denda ngga usah diitung dulu // + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))

                        //using (Database db = new Database())
                        //{
                        //    DataTable dt = new DataTable();
                        //    db.Commands.Add(db.CreateCommand("usp_Angsuran_LIST_ALL"));
                        //    db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                        //    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                        //    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        //    db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "TRK"));
                        //    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue.Value));
                        //    dt = db.Commands[0].ExecuteDataTable();

                        //    this.Text = "Kwitansi Tarikan Motor";
                        //    this.Title = "Kwitansi Tarikan Motor";
                        //    _kodeTrans = "TRK";
                        //    _angsKe = 0;
                        //    lblSaldoPokok.Text = "Saldo Piutang Pokok";
                        //    txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["SaldoPokok"], 0).ToString();
                        //    txtPiutangPokok.ReadOnly = true;
                        //    lblSaldoBunga.Text = "Saldo Piutang Bunga";
                        //    txtPiutangBunga.Text = Tools.isNull(dt.Rows[0]["SaldoBunga"], 0).ToString();
                        //    txtPiutangBunga.ReadOnly = true;
                        //    lblBayarPokok.Text = "Potongan Bunga";
                        //    txtBayarPokok.Text = Tools.isNull(dt.Rows[0]["Potongan"], 0).ToString();
                        //    txtBayarPokok.ReadOnly = true;
                        //    //_nominal = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoPokok"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0));
                        //    lblDenda.Text = "Denda";
                        //    txtDenda.Text = Tools.isNull(dt.Rows[0]["Denda"], 0).ToString();
                        //    txtDenda.ReadOnly = true;
                        //    lblTotal.Text = "Total";
                        //    txtTotal.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoPokok"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) - Convert.ToDouble(Tools.isNull(dt.Rows[0]["Potongan"], 0))).ToString();
                        //    txtTotal.ReadOnly = true;
                        //    lblPotongan.Visible = true;
                        //    txtPotongan.Visible = true;
                        //    txtPotongan.Text = "0";
                        //    txtPotongan.ReadOnly = true;
                        //    lblTarikMotor.Visible = true;
                        //    txtTarikan.Visible = true;
                        //    txtTarikan.Text = "0";
                        //    txtTarikan.ReadOnly = false;
                        //    txtPembayaran.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoPokok"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) - Convert.ToDouble(Tools.isNull(dt.Rows[0]["Potongan"], 0))).ToString();
                        //    txtPembayaran.ReadOnly = false;
                        //    txtUraian.Text = "TARIKAN MOTOR";

                        //    txtNoBG.Text = "";

                        //    txtTglBG.Text = "";
                        //}
                        // kalau ini cabang 06, tgl pelunasannya boleh diisi manual dengan batasan hanya +1 / +2 hari saja
                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}
                        break;
                    case FormMode.Tarikanv2:
                        this.Text = this.Title = "Kwitansi Tarikan";
                        _angsKe = int.Parse(lblAngsuranKe.Text);
                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();
                        txtBayarPokok.ReadOnly = txtPiutangPokok.ReadOnly = true;
                        ntbNominalBunga.Text = txtDenda.Text = "0";
                        txtBayarPokok.Text = txtPiutangPokok.Text;
                        txtPembayaran.Text = (Convert.ToDouble(txtPiutangPokok.Text) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) + Convert.ToDouble(ntbNominalBunga.Text)).ToString();
                        txtUraian.Text = "Tarikan Motor";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtPembayaran.Enabled = cbxBentukPembayaran.Enabled = ntbBiayaKolektor.Enabled = false;
                        cbxBentukPembayaran.SelectedIndex = 0;
                        grpTarikan.Visible = true;
                        ntbBiayaKolektor.Text = "0";

                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    ntbBiayaKolektor.Text = "0";
                        //}

                        _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                        txtPembayaran.Text = (_saldo + Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0))).ToString();
                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}
                        lblHargaJual.Visible = true;
                        lblCustomer.Visible = true;
                        ntbHargaJual.Visible = true;
                        lookUpCustomer1.Visible = true;
                        break;
                    case FormMode.Adjustment:
                        this.Text = this.Title = "Kwitansi Pelunasan";

                        if (GlobalVar.CabangID.Contains("06"))
                        {
                            // berarti lagi pelunasan di TLA
                            lblPotongan.Visible = true;
                            txtPotongan.Visible = true;
                            txtPotongan.Text = "0";
                        }

                        _angsKe = int.Parse(lblAngsuranKe.Text);
                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();
                        txtPiutangPokok.ReadOnly = txtBayarPokok.ReadOnly = true;

                        /*
                        lblSaldoBunga.Text = "Angsuran Ke-";
                        txtPiutangBunga.Text = _angsKe.ToString();
                        */

                        if (_kodeTrans == "APD")
                        {
                            ntbNominalBunga.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)).ToString();
                            if (_kodeTrans == "APD")
                            {
                                txtDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)).ToString();
                            }
                            else
                            {
                                txtDenda.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)).ToString();
                            }
                            if (_tidakperlubayarbunga || _boolPeriodeAngsuranSama)
                            {
                                ntbNominalBunga.Text = "0";
                                // berarti txt Pembayarannya defaultnya hanya bayar pokoknya saja
                                txtPembayaran.Text = txtBayarPokok.Text;
                            }
                            else
                            {
                                ntbNominalBunga.Text = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)).ToString();
                            }
                        }
                        else if (_kodeTrans == "FLT")
                        {
                            if (_boolPeriodeAngsuranSama)
                            {
                                //ditambah appsetting 
                                //ga ditambah bunganya, krn udah 2x pembayaran di periode sama, jd hanya 1x bunga, kalo ditambah bunga pembayaran sblmnya jdnya 2x jg 
                                // nope, ngga kena bunga sama sekali
                                if (GlobalVar.CabangID.Contains("06")) // kalau kode cabang itu GRUP depannya "06" 
                                {
                                    // hitungan tambah bunganya berbeda
                                    // cek bayaran ke nya
                                    Double Pokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPokok"], 0).ToString());
                                    Double Bunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0).ToString());
                                    Double SaldoPokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString());
                                    Double SaldoBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0).ToString());
                                    Double HapusBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["POTBNGTLA"], 0).ToString());
                                    Double BayaranBunga = (SaldoBunga) * 20 / 100; // SaldoBunga - HapusBunga;

                                    //jika ada data pembayaran pokok terpotong, berarti dikarenakan codingan dibawah ini, dan dianggap salah 
                                    //sehingga jika masih ditemukan, perbaiki secara data dan perhatikan accountingnya 
                                    //txtPiutangPokok.Text = (SaldoPokok - Bunga).ToString();
                                    txtPiutangPokok.Text = (SaldoPokok).ToString();

                                    ntbNominalBunga.Text = ((SaldoBunga + Bunga) * 20 / 100).ToString();// (SaldoBunga - HapusBunga).ToString();
                                }
                                else
                                {
                                    // klo periode sama di FLT cabang 13, ini -1 aja bunga nya
                                    int selisihBulan = 0;
                                    if (Today.AddMonths(1) < _tglAkhirAngs)
                                    {
                                        selisihBulan = ((Today.Date.Year - _tglJual.Date.Year) * 12) + (Today.Date.Month - _tglJual.Date.Month);
                                    }
                                    else
                                    {
                                        selisihBulan = ((_tglAkhirAngs.Date.Year - _tglJual.Date.Year) * 12) + (_tglAkhirAngs.Date.Month - _tglJual.Date.Month);
                                    }
                                    selisihBulan = selisihBulan - _angsKe;
                                    ntbNominalBunga.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)) * selisihBulan).ToString();
                                    if (ntbNominalBunga.GetDoubleValue < 0) ntbNominalBunga.Text = "0";
                                }
                            }
                            else if (GlobalVar.CabangID.Contains("06")) // kalau kode cabang itu GRUP depannya "06" 
                            {
                                Double Pokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["AngsuranPokok"], 0).ToString());
                                Double Bunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0).ToString());
                                Double SaldoPokok = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString());
                                Double SaldoBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoBunga"], 0).ToString());
                                Double HapusBunga = Convert.ToDouble(Tools.isNull(dt.Rows[0]["POTBNGTLA"], 0).ToString());

                                Double BayaranBunga = SaldoBunga - HapusBunga; // (SaldoBunga) * 20 / 100;

                                txtPiutangPokok.Text = (SaldoPokok).ToString();
                                ntbNominalBunga.Text = BayaranBunga.ToString();
                            }
                            else
                            {
                                //ditambah appsetting 
                                // untuk kts byl perlu tahu kontrak habisnya kapan jadi ngga kelebihan dendanya
                                // klo periode sama di FLT cabang 13, ini -1 aja bunga nya
                                int selisihBulan = 0;
                                if (Today.AddMonths(1) < _tglAkhirAngs)
                                {
                                    selisihBulan = ((Today.Date.Year - _tglJual.Date.Year) * 12) + (Today.Date.Month - _tglJual.Date.Month);
                                }
                                else
                                {
                                    selisihBulan = ((_tglAkhirAngs.Date.Year - _tglJual.Date.Year) * 12) + (_tglAkhirAngs.Date.Month - _tglJual.Date.Month);
                                }
                                selisihBulan = selisihBulan - (_angsKe - 1);
                                ntbNominalBunga.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Interest"], 0)) * selisihBulan).ToString();
                                if (ntbNominalBunga.GetDoubleValue < 0) ntbNominalBunga.Text = "0";
                            }
                        }
                        if (_kodeTrans == "APD")
                        {
                            txtDenda.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0))).ToString();
                        }
                        else
                        {
                            txtDenda.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0))).ToString();
                        }


                        txtBayarPokok.Text = txtPiutangPokok.Text;
                        // txtTotal.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(ntbNominalBunga.Text)).ToString(); // kalo total ngga usah perhitungkan denda //  + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))
                        txtPembayaran.Text = (Convert.ToDouble(txtPiutangPokok.Text) + Convert.ToDouble(ntbNominalBunga.Text)).ToString(); // + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) 
                        txtUraian.Text = "Pelunasan Angsuran";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtPembayaran.Enabled = false;
                        // cek apakah kena denda?
                        if (_kodeTrans == "FLT" && (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0)) > 0 || Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) > 0))
                        {
                            _kenaDenda = true;
                            Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaHarian"], 0));
                            cbxDenda.Enabled = true;
                            cbxDenda.Checked = true;
                            txtBayarDenda.Text = Denda.ToString();
                            periodeDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["PeriodeDenda"], 0));
                            hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                            txtMaxDenda.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["DendaMax"], 0).ToString()) + (Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)).ToString())).ToString();
                        }
                        else if (_kodeTrans == "APD" && (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) > 0 || Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) > 0))
                        {
                            _kenaDenda = true;
                            Denda = Convert.ToDouble(Tools.isNull(dt.Rows[0]["SaldoDenda"], 0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0));
                            cbxDenda.Enabled = true;
                            cbxDenda.Checked = true;
                            txtBayarDenda.Text = Denda.ToString();
                            periodeDenda = 0;
                            hariDenda = Convert.ToInt32(Tools.isNull(dt.Rows[0]["HariDenda"], 0));
                        }

                        // kalau ini cabang 06, tgl pelunasannya boleh diisi manual dengan batasan hanya +1 / +2 hari saja
                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}
                        break;
                    case FormMode.TarikanNV1:
                        this.Text = this.Title = "Kwitansi Tarikan 1";
                        _angsKe = int.Parse(lblAngsuranKe.Text);

                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();

                        txtBayarPokok.ReadOnly = txtPiutangPokok.ReadOnly = true;
                        ntbNominalBunga.Text = txtDenda.Text = "0";
                        txtBayarPokok.Text = txtPiutangPokok.Text;
                        // txtTotal.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0))+ Convert.ToDouble(ntbNominalBunga.Text)).ToString(); //  + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))  // kalo total ngga usah perhitungkan denda
                        txtPembayaran.Text = (Convert.ToDouble(txtPiutangPokok.Text) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) + Convert.ToDouble(ntbNominalBunga.Text)).ToString();
                        txtUraian.Text = "Tarikan Motor 1";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtPembayaran.Enabled = cbxBentukPembayaran.Enabled = ntbBiayaKolektor.Enabled = false;
                        cbxBentukPembayaran.SelectedIndex = 0;
                        grpTarikan.Visible = true;
                        ntbBiayaKolektor.Text = "0";

                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    ntbBiayaKolektor.Text = "0";
                        //}

                        _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                        // kalo tarikan tambahin juga biaya kolektor dan biaya tarikannya
                        txtPembayaran.Text = (_saldo + Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0))).ToString();

                        if (Convert.ToDouble(ntbEstimasiHrgMotor.Text) == 0)
                        ntbEstimasiHrgMotor.Text = _saldo.ToString();

                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}
                        break;
                    case FormMode.TarikanNV2:
                        this.Text = this.Title = "Kwitansi Tarikan 2";
                        _angsKe = int.Parse(lblAngsuranKe.Text);

                        txtPiutangPokok.Text = Tools.isNull(dt.Rows[0]["Saldo"], 0).ToString();

                        txtBayarPokok.ReadOnly = txtPiutangPokok.ReadOnly = true;
                        ntbNominalBunga.Text = txtDenda.Text = "0";
                        txtBayarPokok.Text = txtPiutangPokok.Text;
                        // txtTotal.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0))+ Convert.ToDouble(ntbNominalBunga.Text)).ToString(); //  + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0))  // kalo total ngga usah perhitungkan denda
                        txtPembayaran.Text = (Convert.ToDouble(txtPiutangPokok.Text) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["Denda"], 0)) + Convert.ToDouble(ntbNominalBunga.Text)).ToString();
                        txtUraian.Text = "Tarikan Motor 2";
                        txtNoBG.Text = txtTglBG.Text = "";
                        txtPembayaran.Enabled = cbxBentukPembayaran.Enabled = ntbBiayaKolektor.Enabled = false;
                        cbxBentukPembayaran.SelectedIndex = 0;
                        grpTarikan.Visible = true;
                        ntbBiayaKolektor.Text = "0";

                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    ntbBiayaKolektor.Text = "0";
                        //}

                        _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));
                        // kalo tarikan tambahin juga biaya kolektor dan biaya tarikannya
                        txtPembayaran.Text = (_saldo + Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0))).ToString();

                        //if (GlobalVar.CabangID.Contains("06"))
                        //{
                        //    txtTglLunas.Enabled = true;
                        //    txtTglLunas.ReadOnly = false;
                        //}
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            if (txtDenda.GetDoubleValue < 0)
            {
                txtDenda.Text = "0";
            }
            // ngga bisa bayar denda di sini
            cbxDenda.Enabled = false;
            cbxDenda.Checked = false;
            txtBayarDenda.Text = "0";
            cbxDenda.Visible = false;
        }


        public void RefreshControlsTitipan()
        {
            txtPembayaran.Text = _selectedAngsuranDetail.TotalNominalIden.ToString();
            cbxBentukPembayaran.Enabled = true;
            txtPembayaran.Enabled = false; 
        }

        #endregion

        private void numericTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ntbBiayaTarikan_TextChanged(object sender, EventArgs e)
        {
            updateTxtNominal();
        }

        private void ntbBiayaTarikan_Leave(object sender, EventArgs e)
        {
            updateTxtNominal();
        }

        private void updateTxtNominal()
        {
            if (mode == FormMode.Tarikan || mode == FormMode.Tarikanv2)
            {
                // kalo tarikan ngga usah urus denda dulu //  + Denda
                txtPembayaran.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(Tools.isNull(ntbBiayaTarikan.Text, 0))).ToString();
                ntbEstimasiHrgMotor.Text = (Convert.ToDouble(Tools.isNull(txtNominalPembayaranPBL.Text, 0))).ToString();
            }

            else if (mode == FormMode.TarikanNV2)
            {
                // kalo tarikan ngga usah urus denda dulu //  + Denda
                txtNominalPembayaranPBL.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(Tools.isNull(ntbBiayaTarikan.Text, 0))).ToString();
                txtPembayaran.Text = (_saldo + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(Tools.isNull(ntbBiayaTarikan.Text, 0))).ToString();
            }
        }

        private void txtPembayaran_Leave(object sender, EventArgs e)
        {
            // asal kalo dia APD dulu aja  _boolPeriodeAngsuranSama && mode == FormMode.Angsuran &&   && Microsoft.VisualBasic.Information.IsNumeric(txtPembayaran.Text)
            if ( _kodeTrans == "APD")
            {
                // kalo pas APD ini, kena dikurangin denda juga bayar pokoknya
                Double tempMinimum = 0;
                tempMinimum = (Convert.ToDouble(ntbNominalBunga.Text)); // ngga usah perhitungkan denda // + Convert.ToDouble(Tools.isNull(txtDenda.Text, "0")));
                txtBayarPokok.Text = (Convert.ToDouble(txtPembayaran.Text) - tempMinimum).ToString();
                // txtTotal.Text = txtPembayaran.Text;
                if (Convert.ToDouble(txtBayarPokok.Text) < 0) txtBayarPokok.Text = "0";
                tempMinimum = Convert.ToDouble(txtPembayaran.Text) - tempMinimum;
                if (tempMinimum < 0)
                {
                    MessageBox.Show("Minimum pembayaran harus sejumlah total bunga dengan denda(jika ada)!");
                    txtPembayaran.Focus();
                }
            }
        }

        private void cbxDenda_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDenda.Checked == true) // berarti mau dibayarkan
            {
                txtBayarDenda.Text = txtDenda.Text;
                // txtPembayaran.Text = (Convert.ToDouble(txtPembayaran.Text.ToString()) + Convert.ToDouble(txtDenda.Text.ToString())).ToString();
            }
            else if (cbxDenda.Checked == false) // berarti ngga mau dibayar
            {
                txtBayarDenda.Text = "0";
                // txtPembayaran.Text = (Convert.ToDouble(txtPembayaran.Text.ToString()) - Convert.ToDouble(txtDenda.Text.ToString())).ToString();
            }
            // kalau ada bayar denda, sekarang itu kehitung HANYA pembulatannya, nominal bayarnya juga tapi tidak masuk ke database
            refreshPembulatan();
        } 

        private void refreshPembulatan()
        {
            // default tulisannya itu
            lblnominalpembayaran.Text = "Nominal Pembayaran";
            lblnominalpembulatan.Text = "Nominal Pembulatan";

            // kalo lagi angsuran APD, perlu cek beberapa hal tambahan
            if ( _kodeTrans == "APD" )
            {
                // kalau lagi bayar angsuran biasa, tapi dengan kondisi belum sisa nominalpokoknya lunas
                // ambil dia bayar berapa, bunganya berapa
                Double pembayaran = Convert.ToDouble(txtPembayaran.Text);
                Double bunga = Convert.ToDouble(ntbNominalBunga.Text);
                Double sisapokok = Convert.ToDouble(txtPiutangPokok.Text);
                Double byrdenda = Convert.ToDouble(txtBayarDenda.Text);

                Double Value =  pembayaran - bunga;
                Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));

                // kalo pembulatan dari (pembayaran - bunga) itu menghasilkan bayaran pokoknya dan sama atau > dari sisa pokok
                if ( PBLValue >= sisapokok)
                {
                    // dibuat baik, jadinya nominal pembayarannya itu jadi nominal pelunasan minimal (sisapokok + bunga)
                    Double agarLunas = sisapokok + bunga;
                    txtPembayaran.Text = agarLunas.ToString();
                    // buletin lagi, dan ditambah DENDA kalau dia kena denda
                    Value = agarLunas + byrdenda ;

                    if (txtPotongan.GetDoubleValue > 0)
                    {
                        Value = Value - txtPotongan.GetDoubleValue;
                    }

                    PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                    // berarti lakukan pembulatan, dan perhitungkan juga sisa pokoknya di sini
                    txtNominalPembulatan.Text = (PBLValue - Value).ToString(); // semua nominal setelah pelunasan pokok itu jadi pembulatannya
                   // txtNominalPembayaranPBL.Text = PBLValue.ToString();
                    txtNominalPembayaranPBL.Text = (PBLValue+Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(Tools.isNull(ntbBiayaTarikan.Text, 0))).ToString();
                    if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
                    {

                    }
                    else
                    {
                        ntbEstimasiHrgMotor.Text = Convert.ToDouble(Tools.isNull(txtNominalPembayaranPBL.Text, 0)).ToString();
                    }
                    
                }
                else
                {
                    // di sini denda saja yg kena pembulatan
                    lblnominalpembayaran.Text = "Pembayaran Denda";
                    lblnominalpembulatan.Text = "Pembulatan Denda";
                    Value = byrdenda;

                    if (txtPotongan.GetDoubleValue > 0)
                    {
                        Value = Value - txtPotongan.GetDoubleValue;
                    }

                    PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                    txtNominalPembulatan.Text = (PBLValue - Value).ToString(); // pembulatannya hanya dari pembulatan dendanya
                    txtNominalPembayaranPBL.Text = (PBLValue + Convert.ToDouble(Tools.isNull(ntbBiayaKolektor.Text, 0)) + Convert.ToDouble(Tools.isNull(ntbBiayaTarikan.Text, 0))).ToString();
                    //txtNominalPembayaranPBL.Text = (PBLValue).ToString(); // jadiin sama seperti txtPembayaran aja (ditambah dendanya kalau dia ada bayar denda)
                    if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
                    {

                    }
                    else
                    {
                        ntbEstimasiHrgMotor.Text = Convert.ToDouble(Tools.isNull(txtNominalPembayaranPBL.Text, 0)).ToString();
                    }
                    
                }
            }
            else
            {
                if (cbxBentukPembayaran.Text.ToLower() == "titipan")
                {
                    Double byrdenda = Convert.ToDouble(txtBayarDenda.Text);
                    Double Value;
                    Double PBLValue;
                    // cek titipannya itu pake + tunai ngga
                    if (modeBayarTitipan == 1) // ini berarti titipan + tunai
                    {
                        lblnominalpembayaran.Text = "Bayar Titipan Tunai";
                        lblnominalpembulatan.Text = "Pembulatan Titipan Tunai";
                        // totalkan dendanya juga
                        Value = byrdenda + bayarBulatTambahanTunaiTitipan;

                        if (txtPotongan.GetDoubleValue > 0)
                        {
                            Value = Value - txtPotongan.GetDoubleValue;
                        }

                        PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));

                        // kalo iya, nominal pembulatan sama bayarannya diubah sesuai titipannya tadi
                        txtNominalPembulatan.Text = (PBLValue - Value + tambahanTunaiTitipanPembulatan).ToString(); // pembulatannya 0
                        txtNominalPembayaranPBL.Text = PBLValue.ToString(); // jadiin sama seperti txtPembayaran aja

                        ntbEstimasiHrgMotor.Text = Convert.ToDouble(Tools.isNull(txtNominalPembayaranPBL.Text, 0)).ToString();
                    }
                    else
                    {
                        // kalau di titipan murni hanya dendanya yg dibulatkan
                        lblnominalpembayaran.Text = "Bayar Denda";
                        lblnominalpembulatan.Text = "Pembulatan Denda";
                        Value = byrdenda;

                        if (txtPotongan.GetDoubleValue > 0)
                        {
                            Value = Value - txtPotongan.GetDoubleValue;
                        }

                        PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));

                        // kalo titipan ngga ada nominal pembulatan
                        txtNominalPembulatan.Text = (PBLValue - Value).ToString(); // pembulatannya 0
                        txtNominalPembayaranPBL.Text = PBLValue.ToString(); // jadiin 0 juga, titipan ngga ada apa2 mestinya
                        if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
                        {

                        }
                        else
                        {
                            ntbEstimasiHrgMotor.Text = Convert.ToDouble(Tools.isNull(txtNominalPembayaranPBL.Text, 0)).ToString();
                        }
                        
                    }
                }
                else 
                {
                    // index 0 -> 100, 1 -> 500, 2 -> 1000
                    if (cboPembulatan.SelectedIndex >= 0)
                    {
                        Double byrdenda = Convert.ToDouble(txtBayarDenda.Text);
                        // ini berarti FLT dan bayarnya dengan selain titipan
                        // perhitungkan dendanya juga
                        Double Value = Convert.ToDouble(Tools.isNull(txtPembayaran.Text, 0)) + byrdenda;

                        if (txtPotongan.GetDoubleValue > 0)
                        {
                            Value = Value - txtPotongan.GetDoubleValue;
                        }

                        Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                        txtNominalPembulatan.Text = (PBLValue - Value).ToString();
                        txtNominalPembayaranPBL.Text = PBLValue.ToString();
                        if (mode == FormMode.TarikanNV1 || mode == FormMode.TarikanNV2)
                        {

                        }
                        else
                        {
                            ntbEstimasiHrgMotor.Text = Convert.ToDouble(Tools.isNull(txtNominalPembayaranPBL.Text, 0)).ToString();
                        }
                        
                    }
                }
            }
        }

        private void cboPembulatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void txtPembayaran_TextChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void txtPotongan_Enter(object sender, EventArgs e)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = txtTglLunas.DateValue.Value;
            Calendar cal = dfi.Calendar;
            int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting,
                      Convert.ToInt32(PinId.ModulId.PotonganPelunasanTLA),
                      "Pemberian Potongan, Anda memerlukan PIN untuk menambahkan Potongan ini!", _rowID);

            if (GlobalVar.pinResult == false)
            {
                txtPotongan.Text = "0";
                return;
            }
        }

        private void txtPotongan_Leave(object sender, EventArgs e)
        {
            if (txtPotongan.GetDoubleValue > (1 * ntbNominalBunga.GetDoubleValue)) // tadinya 0.8
            {
                MessageBox.Show("Maksimal nominal Potongan adalah sebesar nominal Bunga (" + (1 * ntbNominalBunga.GetDoubleValue).ToString("N2") + ") !"); //80% dari 
                txtPotongan.Text = (1 * ntbNominalBunga.GetDoubleValue).ToString();
            }
            refreshPembulatan();
        }

        private void txtPotongan_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdHitung_Click(object sender, EventArgs e)
        {
            HitungUlang();
        }

        private void HitungUlang()
        {
            BindData();
            refreshPembulatan();
            controlPembulatanSet();

            DisableControls(this);
            cmdSave.Enabled = false;
            cmdSave.Visible = false;
            this.Enabled = true;
            cmdClose.Enabled = true;
            cmdClose.Visible = true;
            panel1.Enabled = true;
            txtTglLunas.Enabled = true;
            cmdHitung.Enabled = true;
            cmdHitung.Visible = true;
            cboMode.Enabled = true;
            cboMode.Visible = true;
            if (_kodeTrans == "FLT" && cboMode.SelectedIndex == 1)
            {
                cmdPrint.Visible = true;
                cmdPrint.Enabled = true;
            }
        }

        private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMode.SelectedIndex == 0)
            {
                mode = FormMode.Angsuran;
                if (_kodeTrans == "FLT")
                {
                    cmdPrint.Visible = false;
                    cmdPrint.Enabled = false;
                }
            }
            else if (cboMode.SelectedIndex == 1)
            {
                mode = FormMode.Pelunasan;
                if (_kodeTrans == "FLT")
                {
                    cmdPrint.Visible = true;
                    cmdPrint.Enabled = true;
                }
            }
            HitungUlang();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DataTable dtRpt = new DataTable();
            DataTable dtStat = new DataTable();
            using (Database db = new Database())
            {
                DataSet ds = new DataSet();
                db.Commands.Add(db.CreateCommand("rsp_SimulasiAngsuran"));
                db.Commands[0].Parameters.Add(new Parameter("@PJHistRowID", SqlDbType.UniqueIdentifier, _penjHistID));
                db.Commands[0].Parameters.Add(new Parameter("@TglLunas", SqlDbType.Date, txtTglLunas.DateValue));
                ds = db.Commands[0].ExecuteDataSet();
                if (ds.Tables.Count > 0) // mestinya ada 2 tabel
                {
                    dtRpt = ds.Tables[0];
                    dtStat = ds.Tables[1];
                }

                int RealCurrAng = 0;
                DateTime dateLooper = _tglJual;
                while (dateLooper.Date < txtTglLunas.DateValue.Value.Date)
                {
                    RealCurrAng = RealCurrAng + 1;
                    dateLooper = dateLooper.AddMonths(1);
                }

                int selisihAng = RealCurrAng - _angsKe;
                if (selisihAng < 0) selisihAng = 0;
                if (txtTglLunas.DateValue < dateLooper.Date) RealCurrAng = RealCurrAng - 1;
                if (selisihAng < 0) selisihAng = 0;
                Double tunggakanAngsuran = (/*selisihAng*/RealCurrAng * Convert.ToDouble(Tools.isNull(dtStat.Rows[0]["Angsuran"], 0).ToString())) - Convert.ToDouble(Tools.isNull(dtStat.Rows[0]["TotalBayar"], "0").ToString());
                if (tunggakanAngsuran < 0) tunggakanAngsuran = 0;
                selisihAng = _tempo - (_angsKe - 1)/*(RealCurrAng)*/;
                Double belumJT = (selisihAng * Convert.ToDouble(Tools.isNull(dtStat.Rows[0]["Angsuran"], 0).ToString())) - tunggakanAngsuran;
                
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NoBukti", Tools.isNull(dtStat.Rows[0]["NoBukti"], "").ToString()));
                rptParams.Add(new ReportParameter("NamaPelanggan", Tools.isNull(dtStat.Rows[0]["Nama"], "").ToString()));
                rptParams.Add(new ReportParameter("TglPelunasan", Convert.ToDateTime(Tools.isNull(txtTglLunas.DateValue, DateTime.MinValue).ToString()).ToString("dd-MM-yyyy")));
                rptParams.Add(new ReportParameter("TempoAngsuran", Tools.isNull(dtStat.Rows[0]["TempoAngsuran"], "0").ToString()));
                rptParams.Add(new ReportParameter("JumlahAngsuran", Tools.isNull(dtStat.Rows[0]["Angsuran"], "0").ToString()));
                rptParams.Add(new ReportParameter("TglJT", Convert.ToDateTime(Tools.isNull(dtbTglJTAngsuran.DateValue, DateTime.MinValue).ToString()).ToString("dd-MM-yyyy")));
                rptParams.Add(new ReportParameter("JumlahPiutang", Tools.isNull(dtStat.Rows[0]["Total"], "0").ToString()));
                rptParams.Add(new ReportParameter("JumlahTerbayar", Tools.isNull(dtStat.Rows[0]["TotalBayar"], "0").ToString()));
                rptParams.Add(new ReportParameter("TunggakanAngsuran", Tools.isNull(tunggakanAngsuran, "0").ToString()));
                rptParams.Add(new ReportParameter("AngsuranBelumJT", Tools.isNull(belumJT, "0").ToString()));
                rptParams.Add(new ReportParameter("PenghapusanBunga", Tools.isNull(dtStat.Rows[0]["PenghapusanBunga"], "0").ToString()));
                rptParams.Add(new ReportParameter("Denda", Tools.isNull(txtDenda.GetDoubleValue, "0").ToString()));
                rptParams.Add(new ReportParameter("PokokHutang", Tools.isNull(dtStat.Rows[0]["PokokTotal"], "0").ToString()));
                rptParams.Add(new ReportParameter("TotalBunga", Tools.isNull(dtStat.Rows[0]["BungaTotal"], "0").ToString()));
                rptParams.Add(new ReportParameter("TotalHutang", Tools.isNull(dtStat.Rows[0]["Total"], "0").ToString()));

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(dtRpt);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsPenjualan_SimulasiAngsuran");

                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptSimulasiAngsuran.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Print();

            }

        }

        private void cboPelunasan_CheckedChanged(object sender, EventArgs e)
        {
            if (cboPelunasan.Checked)
            {
                cbxBentukPembayaran.Enabled = true;
                txtPotongan.Enabled = true;
                lookUpKolektor.Enabled = true;
                txtPelunasan.Enabled = true;
            }
            else
            {
                cbxBentukPembayaran.Enabled = false;
                txtPotongan.Enabled = false;
                lookUpKolektor.Enabled = false;
                txtPelunasan.Enabled = false;
                txtPelunasan.Text = "0";
            }
        }

        private void insertAdj()
        {
            if (Double.Parse(txtPelunasan.Text) > Double.Parse(txtPiutangPokok.Text))
            {
                MessageBox.Show("Nominal Pelunasan tidak boleh > Hutang Pokok");
                txtPelunasan.Focus();
                return;
            }
            Database db = new Database();

            string noTransNew = "K" + Numerator.NextNumber("NKJ");
            double nominalAdj =Double.Parse(txtPiutangPokok.Text)-Double.Parse(txtPelunasan.Text);
            adjAngsuranInsert(db, 0, Guid.NewGuid(), noTransNew, nominalAdj);


            if (cboPelunasan.Checked && Double.Parse(txtPelunasan.Text) > 0)
            {
                txtPiutangPokok.Text = txtPelunasan.Text;
                txtBayarPokok.Text = txtPelunasan.Text;
                txtPembayaran.Text = txtPelunasan.Text;
                ntbNominalBunga.Text = "0";
                txtBayarDenda.Text = "0";
                txtDenda.Text = "0";
                txtMaxDenda.Text = "0";

                mode = FormMode.Pelunasan;
            }
            else
            {
                this.Close();
            }
        }

        private void adjAngsuranInsert(Database db, int counterdb, Guid penerimaanUangRowID, String newNoTrans, double nominalAdj)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, newNoTrans));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, ""));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "ADJ"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (txtUraian.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTglLunas.DateValue.Value));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglBG", SqlDbType.Date, txtTglBG.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglJT", SqlDbType.Date, dtbTglJTAngsuran.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Float, Convert.ToDouble(lblAngsuranKe.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue.ToString()));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, 0));

            db.Commands[counterdb].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, nominalAdj));

            db.Commands[counterdb].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0));

            db.Commands[counterdb].Parameters.Add(new Parameter("@NominalPokok", SqlDbType.Money, nominalAdj));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, null));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, txtNoAcc.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglACC", SqlDbType.Date, dtbTglAcc.DateValue));
            db.Commands[counterdb].ExecuteNonQuery();
        }

        private Guid simpanTarikanNV1(ref Database db, ref int counterdb)
        {
            //Simpan Info Tarikan 
            System.Guid guidVendorRowID = System.Guid.Empty;
            db.Commands.Add(db.CreateCommand("usp_tarikanpenjualan_updateNV1"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(ntbEstimasiHrgMotor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@EstimasiBiayaTarikan", SqlDbType.Money, Convert.ToDouble(txtEstimasiBiayaTarikan.Text)));
            counterdb++;

            //Copy Customer ke Vendor , sblm insert dicek dl, apakah rowidnya udah ada / blm atau no identitasnya udah ada atau blm 
            db.Commands.Add(db.CreateCommand("usp_CopyCustomerToVendor"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            object objVendorRowID = db.Commands[counterdb].ExecuteScalar();
            if (objVendorRowID != null)
            {
                guidVendorRowID = new System.Guid(Convert.ToString(objVendorRowID));
            }
            else
            {
                throw new Exception("Data Vendor tidak berhasil dibentuk !");
            }
            counterdb++;

            //Simpan Ke Pembelian                             
            db.Commands.Add(db.CreateCommand("usp_TarikanInsertKePembelianTarikan"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NewRowID", SqlDbType.UniqueIdentifier, newPembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, guidVendorRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue));
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(txtPiutangPokok.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserInitial));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTransPembayaranPembelian", SqlDbType.VarChar, Numerator.NextNumber("NTB")));
            counterdb++;

            return guidVendorRowID;
        }

        private Guid simpanTarikanNV2(ref Database db, ref int counterdb)
        {
            //Simpan Info Tarikan 
            System.Guid guidVendorRowID = System.Guid.Empty;
            db.Commands.Add(db.CreateCommand("usp_tarikanpenjualan_updateNV2"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue)); 
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanKolektor", SqlDbType.Money, Convert.ToDouble(ntbBiayaKolektor.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@BiayaTarikanLainLain", SqlDbType.Money, Convert.ToDouble(ntbBiayaTarikan.Text)));
            db.Commands[counterdb].Parameters.Add(new Parameter("@KeteranganTarikan", SqlDbType.VarChar, txtKeteranganTarikan.Text));
            counterdb++;

            //Copy Customer ke Vendor , sblm insert dicek dl, apakah rowidnya udah ada / blm atau no identitasnya udah ada atau blm 
            db.Commands.Add(db.CreateCommand("usp_CopyCustomerToVendor"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, _CustomerRowID));
            object objVendorRowID = db.Commands[counterdb].ExecuteScalar();
            if (objVendorRowID != null)
            {
                guidVendorRowID = new System.Guid(Convert.ToString(objVendorRowID));
            }
            else
            {
                throw new Exception("Data Vendor tidak berhasil dibentuk !");
            }
            counterdb++;

            //Simpan Ke Pembelian  
            Double BiayaTarikan = Convert.ToDouble(ntbBiayaTarikan.Text); 
            Double BiayaKolektor = Convert.ToDouble(ntbBiayaKolektor.Text);
            Double Pembulatan = Convert.ToDouble(txtNominalPembulatan.Text);
            Double SaldoPiutPokok = Convert.ToDouble(txtPiutangPokok.Text);
            Double HPP = SaldoPiutPokok + BiayaTarikan + BiayaKolektor + Pembulatan;

            db.Commands.Add(db.CreateCommand("usp_TarikanInsertKePembelian"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NewRowID", SqlDbType.UniqueIdentifier, newPembelianRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, _penjRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@VendorRowID", SqlDbType.UniqueIdentifier, guidVendorRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@TglTarikan", SqlDbType.Date, dtbTglTarikan.DateValue)); // tanggal pembelian sesuai dengan tanggal input tarikan ke 2 bukan sesuai dengan tanggal tarikan
            db.Commands[counterdb].Parameters.Add(new Parameter("@HrgEstimasiMotor", SqlDbType.Money, Convert.ToDouble(HPP))); // hpp = saldopiutpokom + by tarikan + by kolektor + pembulatan
            db.Commands[counterdb].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserInitial));
            db.Commands[counterdb].Parameters.Add(new Parameter("@NoTransPembayaranPembelian", SqlDbType.VarChar, Numerator.NextNumber("NTB")));
            counterdb++;

            return guidVendorRowID;
        }

        private void ntbBiayaKolektor_TextChanged(object sender, EventArgs e)
        {
            updateTxtNominal();
        }

        private void ntbBiayaKolektor_Leave(object sender, EventArgs e)
        {
            updateTxtNominal();
        }



















        /*
        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Double decNilaiBGC = 0;
                Double decNilaiNominal = 0;
                int bentukPembayaran = 1;
                System.Guid rekeningPembayaranRowID = System.Guid.Empty;


                if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "transfer")
                {
                    bentukPembayaran = 2;
                    rekeningPembayaranRowID = lookUpRekening1.RekeningRowID;

                    if (Tools.isNull(lookUpRekening1.NamaRekening, "").ToString() == "")
                    {
                        MessageBox.Show("Rekening Bank belum terisi");
                        lookUpRekening1.Focus();
                        return;

                    }
                }
                else if (cbxBentukPembayaran.SelectedItem.ToString().ToLower() == "giro")
                {

                    bentukPembayaran = 3;
                    decNilaiBGC = Convert.ToDouble(txtPembayaran.Text);
                    decNilaiNominal = 0;
                    if ((Convert.ToDouble(Tools.isNull(txtNoBG.Text, 0)) > 0) && (String.IsNullOrEmpty(txtNoBG.Text)))
                    {
                        MessageBox.Show("No. BG/CH/TR belum diisi !");
                        txtNoBG.Focus();
                        return;
                    }

                    if (txtTglBG.Text == "")
                    {
                        MessageBox.Show("Tanggal Jatuh Tempo BGC belum diisi !");
                        txtTglBG.Focus();
                        return;
                    }

                    if (((DateTime)txtTglBG.DateValue).Date < _tglJual.Date)
                    {
                        MessageBox.Show("Tgl. BG lebih kecil dari pada Tanggal Penjualan !");
                        txtTglBG.Focus();
                        return;
                    }
                }


                switch (mode)
                {
                    case FormMode.Angsuran :
                        using (Database db = new Database())
                        {


                            if ((_kodeTrans == "APD") && ((decNilaiBGC + decNilaiNominal) < Convert.ToDouble(_interest)))
                            {
                                MessageBox.Show("Nominal pembayaran lebih kecil dari pada bunga !");
                                txtPembayaran.Focus();
                                return;
                            }
                            if (((decNilaiBGC + decNilaiNominal) - ( _interest + Convert.ToDouble(Tools.isNull(txtDenda.Text, 0)))) > _saldo)
                            {
                                MessageBox.Show("Nominal pembayaran lebih besar dari Saldo Pokok !");
                                txtPembayaran.Focus();
                                return;
                            }                            
                            //if (((decNilaiBGC + decNilaiNominal) - Convert.ToDouble(Tools.isNull(txtDenda.Text, 0))) >= ((2 * _nominal) - Convert.ToDouble(Tools.isNull(txtDenda.Text, 0))))
                            //{
                            //    MessageBox.Show("Nominal pembayaran lebih besar atau sama dengan 2 x angsuran per bulan !");
                            //    txtPembayaran.Focus();
                            //    return;
                            //}
                            
                            // ini utk apa ya ? kan customer bs bayar lbh kecil dari angsuran utk APD, minimal biaya bunga 
                            // kalo dibawah angsuran dianggep titip ? atau dibawah angsuran ga boleh input ? 
                            //if ((decNilaiBGC + decNilaiNominal) < Convert.ToDouble(Tools.isNull(txtTotal.Text, 0)))
                            //{
                            //    _kodeTrans = "TTP";
                            //    txtUraian.Text = "TITIPAN ANGSURAN KE-" + _angsKe.ToString();
                            //    _nominal = decNilaiBGC + decNilaiNominal;
                            //    _interest = 0;
                            //}


                            if ((decNilaiBGC + decNilaiNominal) > Convert.ToDouble(Tools.isNull(txtTotal.Text, 0)))
                            {
                                try
                                {
                                    lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                                    using (Database _db = new Database())
                                    {
                                        _db.Commands.Add(_db.CreateCommand("usp_PenerimaanANG_INSERT"));
                                        _db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                        _db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                                        _db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                                        _db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                                        _db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                                        _db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
                                        _db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                                        _db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                                        _db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue.Value));
                                        _db.Commands[0].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
                                        _db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.DateTime, _tglJT));
                                        _db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Decimal, Convert.ToDecimal(_angsKe)));
                                        _db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                                        _db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, _interest));
                                        _db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));


                                        //if (Convert.ToDouble(txtNilaiBG.Text) > _nominal)
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, _nominal));
                                        //}
                                        //if ((Convert.ToDouble(txtNilaiBG.Text) > 0) && (Convert.ToDouble(txtNilaiBG.Text) <= _nominal))
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, txtNilaiBG.Text));
                                        //}
                                        //if (Convert.ToDouble(txtNilaiBG.Text) == 0)
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, 0));
                                        //}
                                        //if (((Convert.ToDouble(txtPembayaran.Text) + Convert.ToDouble(txtNilaiBG.Text)) >= _nominal) && (Convert.ToDouble(txtNilaiBG.Text) >= _nominal))
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, 0));
                                        //}
                                        //if (((Convert.ToDouble(txtPembayaran.Text) + Convert.ToDouble(txtNilaiBG.Text)) >= _nominal) && (Convert.ToDouble(txtNilaiBG.Text) > 0))
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, _nominal - Convert.ToDouble(txtNilaiBG.Text)));
                                        //}
                                        //if (((Convert.ToDouble(txtPembayaran.Text) + Convert.ToDouble(txtNilaiBG.Text)) >= _nominal) && (Convert.ToDouble(txtNilaiBG.Text) == 0))
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, _nominal));
                                        //}
                                        //if (((Convert.ToDouble(txtPembayaran.Text) + Convert.ToDouble(txtNilaiBG.Text)) < _nominal) && (Convert.ToDouble(txtNilaiBG.Text) == 0))
                                        //{
                                        //    _db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, txtPembayaran.Text));
                                        //}
                                        _db.Commands[0].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, txtDenda.Text));
                                        _db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0));
                                        _db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor._Kolektor.RowID));
                                        _db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                                        _db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                        _db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                        _db.Commands[0].ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Error.LogError(ex);
                                }

                                _kodeTrans = "TTP";
                                _interest = 0;
                                _angsKe = _angsKe + 1;
                                txtDenda.Text = "0";
                                //_nominal = (Convert.ToDouble(txtNilaiBG.Text) + Convert.ToDouble(txtPembayaran.Text)) - (Convert.ToDouble(txtTotal.Text) + Convert.ToDouble(txtDenda.Text));
                                
                                txtNoBG.Text = "";
                                
                                //txtPembayaran.Text = ((Convert.ToDouble(txtNilaiBG.Text) + Convert.ToDouble(txtPembayaran.Text)) - (Convert.ToDouble(txtTotal.Text) + Convert.ToDouble(txtDenda.Text))).ToString();
                                txtUraian.Text = "TITIPAN ANGSURAN KE-" + _angsKe.ToString();
                                _rowID = Guid.NewGuid();
                                lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                            }

                            
                            lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                            //db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, txtBank.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.DateTime, _tglJT));
                            db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Decimal, Convert.ToDecimal(_angsKe)));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, _interest));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));
                            //db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, txtNilaiBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, txtPembayaran.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, txtDenda.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor._Kolektor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case FormMode.Pelunasan :
                        using (Database db = new Database())
                        {
                            if ((Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0))) > _saldo)
                            {
                                MessageBox.Show("Nominal pembayaran lebih besar dari Saldo Pokok !");
                                txtPembayaran.Focus();
                                return;
                            }
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                            //db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, txtBank.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));                            
                            db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Decimal, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, txtPiutangBunga.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));
                            //db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, txtNilaiBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, txtPembayaran.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, txtDenda.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, txtPotongan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor._Kolektor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case FormMode.Tarikan :
                        using (Database db = new Database())
                        {
                            if ((Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0))) > _saldo)
                            {
                                MessageBox.Show("Nominal pembayaran lebih besar dari Saldo Pokok !");
                                txtPembayaran.Focus();
                                return;
                            }
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                            //db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, txtBank.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, txtNoBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@TglBG", SqlDbType.DateTime, txtTglBG.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Decimal, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Money, txtPiutangBunga.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _nominal));
                            //db.Commands[0].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, txtNilaiBG.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bayar", SqlDbType.Money, txtPembayaran.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Denda", SqlDbType.Money, Convert.ToDouble(txtDenda.Text) + Convert.ToDouble(txtTarikan.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@Potongan", SqlDbType.Money, txtPotongan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor._Kolektor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal ditambahkan !\n " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        */

    }
}
