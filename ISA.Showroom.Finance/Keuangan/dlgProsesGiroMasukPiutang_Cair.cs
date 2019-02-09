using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class dlgProsesGiroMasukPiutang_Cair : ISA.Controls.BaseForm
    {
        bool _lRekening = false;
        String _MtUangID;
        Class.FillComboBox fcbo = new Class.FillComboBox();
        DateTime _TglJTGiro;
        String _uraian = "", _kodeTrans = "";

        public String uraianInsert, potonganInsert, kodeTransInsert;

        public dlgProsesGiroMasukPiutang_Cair()
        {
            InitializeComponent();
        }


        public dlgProsesGiroMasukPiutang_Cair(String kodeTrans, string status, bool lRekening, String MtUangID, Guid rekeningRowID, DateTime TglJTGiro)
        {
            InitializeComponent();
            _TglJTGiro = TglJTGiro;
            _lRekening = lRekening;
            if (status == "Batal Cair" || status == "BatalSetor" || status == "Cair" || status == "Ditolak")
            {
                lookUpRekening1.Enabled = false;
            }
            else
            {
                lookUpRekening1.Enabled = true;
            }
            lookUpRekening1.RekeningRowID = rekeningRowID;
            _MtUangID = MtUangID;
            lblStatus.Text = status;
           
            _kodeTrans = kodeTrans;
            if (kodeTrans == "")
            {
                dtTanggalInsert.Enabled = false;
                txtUraianInsert.Enabled = false;
                // cboKodeTransInsert.Enabled = false;
                // txtPotonganInsert.Enabled = false;
            }
            else if (kodeTrans == Class.enumTipeTitipan.Murni.ToString() || kodeTrans == Class.enumTipeTitipan.UM.ToString() || kodeTrans == Class.enumTipeTitipan.Adm.ToString())
            {
                // tampilin textbox tanggal sama uraian aja
                dtTanggalInsert.Enabled = true;
                txtUraianInsert.Enabled = true;
                // cboKodeTransInsert.Enabled = false;
                // txtPotonganInsert.Enabled = false;
            }
            else if (kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
            {
                // kalo angsuran selain tanggal sama uraian tampilin juga potongan dan kode transaksi nya
                dtTanggalInsert.Enabled = true;
                txtUraianInsert.Enabled = true;
                // cboKodeTransInsert.Enabled = true;
                // txtPotonganInsert.Enabled = true;
            }
        }

        public dlgProsesGiroMasukPiutang_Cair(String kodeTrans, String Uraian, string status, bool lRekening, String MtUangID, Guid rekeningRowID, DateTime TglJTGiro)
        {
            InitializeComponent();
            _TglJTGiro = TglJTGiro;
            _lRekening = lRekening;
            if (status == "Batal Cair" || status == "BatalSetor" || status == "Cair" || status == "Ditolak")
            {
                lookUpRekening1.Enabled = false;
            }
            else
            {
                lookUpRekening1.Enabled = true;
            }
            lookUpRekening1.RekeningRowID = rekeningRowID;
            _MtUangID = MtUangID;
            lblStatus.Text = status;
                       
            _kodeTrans = kodeTrans;
            _uraian = Uraian;
            if (kodeTrans == "")
            {
                dtTanggalInsert.Enabled = false;
                txtUraianInsert.Enabled = false;
                // cboKodeTransInsert.Enabled = false;
                // txtPotonganInsert.Enabled = false;
            }
            else if (kodeTrans == Class.enumTipeTitipan.Murni.ToString() || kodeTrans == Class.enumTipeTitipan.UM.ToString() || kodeTrans == Class.enumTipeTitipan.Adm.ToString())
            {
                // tampilin textbox tanggal sama uraian aja
                dtTanggalInsert.Enabled = true;
                txtUraianInsert.Enabled = true;
                txtUraianInsert.Text = _uraian;
            }
            else if (kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
            {
                // kalo angsuran selain tanggal sama uraian tampilin juga potongan dan kode transaksi nya
                dtTanggalInsert.Enabled = true;
                txtUraianInsert.Enabled = true;
                // cboKodeTransInsert.Enabled = true;
                // txtPotonganInsert.Enabled = true;
                // txtPotonganInsert.Text = "0";
                txtUraianInsert.Text = _uraian;
            }

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (ValidasiData())
            { 
                this.DialogResult = DialogResult.Yes;
                // potonganInsert = txtPotonganInsert.Text;                     
                // kodeTransInsert = cboKodeTransInsert.Text.Substring(0, 3);
                uraianInsert = txtUraianInsert.Text;
                this.Close();
            }
//            this.Close();
        }

        private void dlgProsesGiroMasukPiutang_Cair_Load(object sender, EventArgs e)
        {
            dtTanggalInsert.DateValue = GlobalVar.GetServerDate;

            lookUpRekening1.MataUangIDRekening = _MtUangID;
            lookUpRekening1.PerusahaanID = GlobalVar.PerusahaanRowID; 
        }



        private void dlgProsesGiroMasukPiutang_Cair_Validated(object sender, EventArgs e)
        {
            MessageBox.Show("validated...");
        }

        private void dlgProsesGiroMasukPiutang_Cair_Validating(object sender, CancelEventArgs e)
        {
           // ValidasiData();
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
            // parameter[0] -> backdated, parameter[1] -> postdated
            // backdated ngga usah dulu GlobalVar.GetServerDate >= _TglJTGiro.AddDays(-parameter[0]) &&  // dtTanggal.DateValue
            if (GlobalVar.GetServerDate >= _TglJTGiro.AddDays(+parameter[0])) 
            { Expired = true; }
            return Expired;
        }


        #endregion


        private bool ValidasiData()
        {
            bool lReturn = true;
            if (dtTanggalInsert.Text == "")
            {
                MessageBox.Show("Tanggal belum diisi");
                dtTanggalInsert.Focus();
                return false;
            }
            if (ValidasiSimpan() == true)
            {
                MessageBox.Show("Tidak boleh lebih dari 2 hari yang lalu atau input tanggal diluar ketentuan.");
                dtTanggalInsert.Focus();
                return false;

            }
            if (dtTanggalInsert.DateValue < GlobalVar.GetBackDatedLockValue())
            {
                MessageBox.Show("Tanggal cair sudah melewati batas tanggal input data.");
                dtTanggalInsert.Focus();
                return false;
            }
            if (txtUraianInsert.Text == "")
            {
            }
            
            if (lblStatus.Text == "Batal Cair" || lblStatus.Text == "BatalSetor" || lblStatus.Text == "Cair" || lblStatus.Text == "Ditolak")
            {

                return true;
            }
            else
            {
                if ((Guid)Tools.isNull(lookUpRekening1.RekeningRowID, Guid.Empty) == Guid.Empty)
                {
                    if (lookUpRekening1.txtSearch.Text == "")
                        MessageBox.Show("Kode Rekening belum diisi.");
                    else
                        MessageBox.Show("kode Rekening '" + lookUpRekening1.txtSearch.Text.ToString() +
                                        "' tidak ditemukan di database.");
                    lookUpRekening1.Focus();
                    return false;
                }
            }

            /*
            if (kodeTrans == Class.enumTipeTitipan.Angsuran.ToString())
            {
                if (cboKodeTransInsert.Text == "")
                {
                    MessageBox.Show("Tolong pilih kode transaksi terlebih dahulu.");
                    cboKodeTransInsert.Focus();
                    return false;
                }
                if (txtPotonganInsert.Text == "")
                {
                    MessageBox.Show("Besar Potongan jangan dikosongkan. Isikan 0 jika tidak ada");
                    txtPotonganInsert.Text = "0";
                    txtPotonganInsert.Focus();
                    return false;
                }
            }
            */
            return lReturn;
        }

        private void dtTanggal_TextChanged(object sender, EventArgs e)
        {
            if (ValidasiSimpan() == true)
            {
                cmdSubmit.Enabled = false;
            }
            else
            {
                cmdSubmit.Enabled = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

        }
       
    }
}
