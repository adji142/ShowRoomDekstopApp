using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Globalization;
using ISA.Showroom.Finance.Class;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmIdenBBNPelunasan : ISA.Controls.BaseForm
    {
        #region VARIABLES DECLARATIONS
        //enum enumFormMode { New, Update, Approve };
        //enumFormMode formMode;
        string _bentukPengeluaran;
        bool _needApprove = false;
        GlobalVar.enumStatusApproval _statusApproval = GlobalVar.enumStatusApproval.Closed;
        DateTime _today = GlobalVar.GetServerDate;
        bool _isGroup = false;
        Guid _GPLL = new Guid("579FF9B4-8E53-49D6-84DC-5293004E3ED7");
        Class.FillComboBox fcbo = new Class.FillComboBox();
        String JnsPenerimaan = String.Empty;
        //Guid _PerusahaanRowID;
        Guid PtDari = Guid.Empty;
        Guid PtKe = Guid.Empty;

        Guid PenjualanRowID;
        Guid PembelianRowID;
        Guid CustomerRowID;
        #endregion

        public frmIdenBBNPelunasan()
        {
            InitializeComponent();
        }

        public frmIdenBBNPelunasan(Form _caller, DataTable dt)
        {
            InitializeComponent();
            this.Caller = _caller;

            PenjualanRowID = new Guid(dt.Rows[0]["RowID"].ToString());
            PembelianRowID = new Guid(dt.Rows[0]["PembelianRowID"].ToString());
            CustomerRowID  = new Guid(dt.Rows[0]["CustomerRowID"].ToString());

            txt_TglJual.DateValue   = Convert.ToDateTime(dt.Rows[0]["TglJual"].ToString());
            txt_NoBukti.Text        = dt.Rows[0]["NoBukti"].ToString();
            txt_NoTrans.Text        = dt.Rows[0]["NoTrans"].ToString();
            txt_KodeTrans.Text      = dt.Rows[0]["KodeTrans"].ToString();
            txt_Keterangan.Text     = dt.Rows[0]["Keterangan"].ToString();
            txt_NominalBBN.Text     = dt.Rows[0]["BBN"].ToString();
            txt_BayarBBN.Text       = dt.Rows[0]["BayarBBN"].ToString();
            txt_SisaBBN.Text        = dt.Rows[0]["SisaBBN"].ToString();
            txt_NamaCustomer.Text   = dt.Rows[0]["NamaCust"].ToString();


            txt_NamaSTNK.Text       = dt.Rows[0]["NamaBPKB"].ToString();
            txt_AlamatSTNK.Text     = dt.Rows[0]["Alamat"].ToString();
            txt_NoRangka.Text       = dt.Rows[0]["NoRangka"].ToString();
            txt_NoMesin.Text        = dt.Rows[0]["NoMesin"].ToString();
            txt_Warna.Text          = dt.Rows[0]["Warna"].ToString();
            
            txt_BBN.Text            = dt.Rows[0]["SisaBBN"].ToString();
        }

        private void cmdCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool cekDataSTNK()
        {
            bool hasil = true;
            if (txt_NoSTNK.Text == "")
            {
                errorProvider1.SetError(txt_NoSTNK, "Nomor STNK tidak boleh kosong");
                hasil = false;
            }
            
            if (txt_NoReg.Text == "")
            {
                errorProvider1.SetError(txt_NoReg, "Nomor register tidak boleh kosong");
                hasil = false;
            }

            if (txt_NamaSTNK.Text == "")
            {
                errorProvider1.SetError(txt_NamaSTNK, "Nama STNK tidak boleh kosong");
                hasil = false;
            }

            if(txt_AlamatSTNK.Text == "")
            {
                errorProvider1.SetError(txt_AlamatSTNK, "Alamat tidak boleh kosong");
                hasil = false;
            }
            
            if(txt_NoRangka.Text == "")
            {
                errorProvider1.SetError(txt_NoRangka, "Nomor Rangka tidak boleh kosong");
                hasil = false;
            }
            
            if (txt_NoMesin.Text == "")
            {
                errorProvider1.SetError(txt_NoMesin, "Nomor Mesin tidak boleh kosong");
                hasil = false;
            }
            
            if(txt_Warna.Text == "")
            {
                errorProvider1.SetError(txt_Warna, "Warna tidak boleh kosong");
                hasil = false;
            }
            
            return hasil;
        }
        private void cmdYES_Click(object sender, EventArgs e)
        {
            if (!cekDataSTNK())
            {
                return;
            }


            try
            {
                if (Convert.ToDouble(txt_BBN.Text) > 0)
                {
                    if (rdoKas.Checked == true && (Guid)cboKas.SelectedValue == Guid.Empty)
                    {
                        MessageBox.Show("Kas belum dipilih, silahkan dipilih terlebih dahulu");
                        return;
                    }
                    else if(rdoBank.Checked == true && lkpRekening1.RekeningRowID == Guid.Empty)
                    {
                        MessageBox.Show("Bank belum dipilih, silahkan dipilih terlebih dahulu");
                        return;
                    }

                    //PIN
                    if (Convert.ToDouble(txt_BBN.Text) > Convert.ToDouble(txt_SisaBBN.Text))
                    {
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        DateTime date = GlobalVar.GetServerDate;
                        Calendar cal = dfi.Calendar;
                        int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                        Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting, Convert.ToInt32(PinId.ModulId.PelunasanBBN), "Pembayaran BBN melebihi sisa BBN memerlukan PIN persetujuan bagian Keuangan.");
                        if (GlobalVar.pinResult == false)
                        {
                            return;
                        }
                    }else if (Convert.ToDouble(txt_SisaBBN.Text)- Convert.ToDouble(txt_BBN.Text) > 0 )
                    {
                        DialogResult dialogResult = MessageBox.Show("Pelunasan BBN hanya dapat dilakukan sekali \nTerdapat sisa BBN sebesar " + (Convert.ToDouble(txt_SisaBBN.Text) - Convert.ToDouble(txt_BBN.Text)).ToString() + 
                                    ",  Anda yakin ingin melanjutkan transaksi ?", "Save Pelunasan BBN", MessageBoxButtons.YesNo);
                         if (dialogResult == DialogResult.No)
                         {
                             return;
                         }
                    }

                    Guid _bankRowID = Guid.Empty;
                    Guid _rekeningRowID = Guid.Empty;
        
                    switch (_bentukPengeluaran)
                    {
                        case "K": _rekeningRowID = (Guid)cboKas.SelectedValue; break;
                        case "B":
                            {
                                _rekeningRowID = (Guid)lkpRekening1.RekeningRowID;
                                _bankRowID = (Guid)lkpRekening1.BankRowID;
                                break;
                            }
                        default:
                            _rekeningRowID = (Guid)Guid.Empty;
                            _statusApproval = GlobalVar.enumStatusApproval.Approved;
                            break;
                    }

                    DataTable dt1 = new DataTable();
                    Guid RowIDPU = Guid.NewGuid();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDPU));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalRk", SqlDbType.Date, GlobalVar.GetServerDate.Date));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, GlobalVar.GetServerDate.Date));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@NoApproval", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, new Guid("F0BFEC6B-E92C-44A3-9EEB-F41960503F15")));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, new Guid("F0BFEC6B-E92C-44A3-9EEB-F41960503F15")));
                        db.Commands[0].Parameters.Add(new Parameter("@MataUangRowID", SqlDbType.UniqueIdentifier, new Guid("BC17A644-5DBD-4955-A803-378F8C0A915C")));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, new Guid("CE9075B2-1206-4D8E-9F22-0D12C6DE9939")));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(txt_BBN.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, double.Parse(txt_BBN.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Pembayaran BBN - " + txt_NoBukti.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPengeluaran", SqlDbType.VarChar, _bentukPengeluaran));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsPenerimaan", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, (_needApprove) ? 0 : 9));
                        db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? _rekeningRowID : Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.UniqueIdentifier, _bankRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (_bentukPengeluaran == "K") ? Guid.Empty : _rekeningRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@KeKasRowID", SqlDbType.UniqueIdentifier, Guid.Empty));
                        db.Commands[0].Parameters.Add(new Parameter("@KeRekeningRowID", SqlDbType.UniqueIdentifier,  Guid.Empty));
                        //db.Commands[0].Parameters.Add(new Parameter("@DueDateGiro", SqlDbType.Date, default));
                        db.Commands[0].Parameters.Add(new Parameter("@NoCekGiro", SqlDbType.VarChar,""));
                        db.Commands[0].Parameters.Add(new Parameter("@PengeluaranKe", SqlDbType.Int, 2));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, PenjualanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@IsPembayaran", SqlDbType.Bit, 0));

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
                    }

                    using (Database db = new Database())
                    {
                        
                        db.Commands.Add(db.CreateCommand("usp_MasterSTNK_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@PembelianRowID", SqlDbType.UniqueIdentifier, PembelianRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@PenjualanRowID", SqlDbType.UniqueIdentifier, PenjualanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, CustomerRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@TglLunasBBN", SqlDbType.DateTime, GlobalVar.GetServerDate.Date));
                        db.Commands[0].Parameters.Add(new Parameter("@NoSTNK", SqlDbType.VarChar, txt_NoSTNK.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRegistrasi", SqlDbType.VarChar, txt_NoReg.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txt_NamaSTNK.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txt_AlamatSTNK.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoRangka", SqlDbType.VarChar, txt_NoRangka.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@NoMesin", SqlDbType.VarChar, txt_NoMesin.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Warna", SqlDbType.VarChar, txt_Warna.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    MessageBox.Show(Messages.Confirm.SaveSuccess);
                    if (this.Caller is frmIdenBBNBrowse)
                    {
                        frmIdenBBNBrowse frmCaller = (frmIdenBBNBrowse)this.Caller;
                        frmCaller.RefreshHeader(PenjualanRowID);
                        frmCaller.RefreshDetail(RowIDPU);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void rdoKas_CheckedChanged(object sender, EventArgs e)
        {
            _bentukPengeluaran = "K";
            show_panelPengeluaran();
            TabIndexPengeluaranDari("K");
        }

        private void show_panelPengeluaran()
        {
            pnlKas.Visible = (_bentukPengeluaran == "K");
            pnlBank.Visible = (_bentukPengeluaran == "B");

            //bool _mode_status = ((formMode != enumFormMode.Approve) && _statusApproval == 0);
            //if (formMode == enumFormMode.Approve) _mode_status = false;
            //else
            //    if (_needApprove) { if (_statusApproval == GlobalVar.enumStatusApproval.Closed) _mode_status = false; }
            //    else _mode_status = true;
            //if ((formMode == enumFormMode.Update) && (_isGroup)) _mode_status = ((_groupRowID == null) || (_groupRowID == Guid.Empty));
            //pnlKas.Enabled = _mode_status;
            //pnlBank.Enabled = _mode_status;
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
                        break;
                    }
                case "B":
                    {
                        rdoBank.TabIndex = 12;
                        pnlBank.TabIndex = 13;
                        lkpRekening1.TabIndex = 14;
                        break;
                    }
            }
        }

        private void rdoBank_CheckedChanged(object sender, EventArgs e)
        {
            _bentukPengeluaran = "B";
            show_panelPengeluaran();
            TabIndexPengeluaranDari("B");
            lkpRekening1.Enabled = true;
        }

        private void frmIdenBBNPelunasan_Load(object sender, EventArgs e)
        {
            fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
            cboKas.SelectedIndex = 1;
            rdoKas.Checked = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txt_NamaCustomer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
