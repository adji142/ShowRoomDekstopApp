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
    public partial class dlgProsesGiroStatus : ISA.Controls.BaseForm
    {
        DateTime _today = GlobalVar.GetServerDate;

        DateTime? _tglBatasInput = GlobalVar.GetBackDatedLockValue();

        bool _lRekening = false;
        String _MtUangID;
        Class.FillComboBox fcbo = new Class.FillComboBox();
        DateTime _TglJTGiro;
        public dlgProsesGiroStatus()
        {
           
            InitializeComponent();
        }

        public dlgProsesGiroStatus(string status, bool lRekening,String MtUangID, Guid rekeningRowID, DateTime TglJTGiro)
        {
            InitializeComponent();
            _lRekening = lRekening;
            _TglJTGiro = TglJTGiro;
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
           
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (ValidasiData())
            { 
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
//            this.Close();

        }

        private void dlgProsesGiroStatus_Load(object sender, EventArgs e)
        {
            dtTanggal.DateValue = GlobalVar.GetServerDate;

            lookUpRekening1.MataUangIDRekening = _MtUangID;
            lookUpRekening1.PerusahaanID = GlobalVar.PerusahaanRowID; 
        }

      

        private void dlgProsesGiroStatus_Validated(object sender, EventArgs e)
        {
            MessageBox.Show("validated...");
        }

        private void dlgProsesGiroStatus_Validating(object sender, CancelEventArgs e)
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
            //if (dtTanggal.DateValue >= GlobalVar.GetServerDate.AddDays(-parameter[0]) && dtTanggal.DateValue <= GlobalVar.GetServerDate.AddDays(+parameter[1]))
            if (GlobalVar.GetServerDate >= _TglJTGiro.AddDays(+parameter[0]) )
            { Expired = true; }
            return Expired;
        }


        #endregion


        private bool ValidasiData()
        {
            bool lReturn = true;
            if (dtTanggal.Text == "")
            {
                MessageBox.Show("Tanggal belum diisi");
                dtTanggal.Focus();
                return false;
            }

                if (ValidasiSimpan() == true)
                {
                    MessageBox.Show("Tidak boleh lebih dari 2 hari yang lalu atau input tanggal diluar ketentuan.");
                    dtTanggal.Focus();
                    return false;

                }
  

            if (dtTanggal.DateValue < _tglBatasInput)
            {
                MessageBox.Show("Tanggal cair sudah melewati batas tanggal input data.");
                dtTanggal.Focus();
                return false;
            }

            if (lblStatus.Text == "Batal Cair" || lblStatus.Text == "BatalSetor" || lblStatus.Text == "Cair" || lblStatus.Text == "Ditolak")
            {
            
                return true;
            }
            else
            {
                if ((Guid)Tools.isNull(lookUpRekening1.RekeningRowID,Guid.Empty)==Guid.Empty)
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

       
    }

}
