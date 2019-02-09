using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.DKN
{
    public partial class frmDownloadDKNUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update }
        enumFormMode formMode = enumFormMode.New;
        Class.clsDKN00 _dkn00;
        DataRow _dr;
        DataTable _dt;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public DataRow dr { get { return _dr; } }

        public frmDownloadDKNUpdate()
        {
            InitializeComponent();
        }

        //public frmDownloadDKNUpdate(Class.clsDKN00 dkn)
        //{
        //    InitializeComponent();
        //}

        public frmDownloadDKNUpdate(DataRow dr)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _dr = dr;
            _dkn00 = new Class.clsDKN00(_dr);
            _dt = dr.Table;
        }

        public frmDownloadDKNUpdate(DataTable dt, string nodkn)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _dkn00 = new Class.clsDKN00();
            if (!string.IsNullOrEmpty(nodkn)) CariNoDKN(nodkn, dt);
            _dr = dt.Rows.Add();
            _dt = dt;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New) _dr.Table.Rows.Remove(_dr);
            this.Close();
        }

        private void frmDownloadDKNUpdate_Load(object sender, EventArgs e)
        {
            //_dkn00 = new Class.clsDKN00();
            fcbo.fillComboCabangPlustHO(cboCabang);
            //fcbo.fillComboCabang(cboDari, GlobalVar.PerusahaanRowID);
            fcbo.fillComboCabangNonCabangIDLocal(cboDari,GlobalVar.PerusahaanRowID,GlobalVar.CabangID);
            fcbo.fillComboKodeHILama(cboCD);
            RefreshData();
        }

        void RefreshData()
        {
            txtNoDKN.Text = _dkn00.no_dkn;
            dtTanggal.DateValue = _dkn00.tanggal;
            cboDari.SelectedValue = Tools.isNull(_dkn00.dari,"").ToString();
            cboCabang.SelectedValue = Tools.isNull(_dkn00.cabang,"").ToString();
            rdoDN.Checked = (_dkn00.dk == "D");
            rdoKN.Checked = (_dkn00.dk == "K");
            cboCD.SelectedValue = Tools.isNull(_dkn00.cd, "").ToString();
            txtSrc.Text = _dkn00.src;
            txtNoPerkiraan.Text = _dkn00.no_perk;
            txtUraian.Text = _dkn00.uraian;
            txtJumlah.Text = _dkn00.jumlah.ToString();
            chkTolak.Checked = _dkn00.ltolak;
            txtAlasan.Text = _dkn00.alasan;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //if (_dr==null) _dr = Class.clsDKN00.CreateDataTable().Rows.Add();
            bool result = (_dr != null);
            //Class.clsDKN00.AddToDataRow(_dr);
            if (result)
            {
                try
                {
                    _dkn00.no_dkn = txtNoDKN.Text;
                    _dkn00.tanggal = (DateTime)Tools.isNull(dtTanggal.DateValue, DateTime.MinValue);
                    _dkn00.dari = Tools.isNull(cboDari.SelectedValue, "").ToString();
                    _dkn00.cabang = Tools.isNull(cboCabang.SelectedValue, "").ToString();
                    _dkn00.dk = (rdoDN.Checked) ? "D" : "K";
                    _dkn00.cd = Tools.isNull(cboCD.SelectedValue, "").ToString();
                    _dkn00.src = txtSrc.Text;
                    _dkn00.no_perk = txtNoPerkiraan.Text;
                    _dkn00.uraian = txtUraian.Text;
                    _dkn00.jumlah = Convert.ToDouble(txtJumlah.Text.ToString());
                    _dkn00.ltolak = chkTolak.Checked;
                    _dkn00.alasan = txtAlasan.Text;

                    if (string.IsNullOrEmpty(_dkn00.idhead))
                    {
                        DataTable dt = _dr.Table;
                        foreach (DataRow d in dt.Rows)
                        {
                            if (d["no_dkn"].ToString().Trim() == _dkn00.no_dkn.ToString().Trim()) // ADP
                            {
                                _dkn00.idhead = d["idhead"].ToString();
                                break;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(_dkn00.idhead)) _dkn00.idhead = Tools.CreateFingerPrint();
                }
                catch {
                    result = false;
                }
            }
            if (result)
            {
                _dkn00.AddToDataRow(_dr);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (formMode == enumFormMode.New) _dr.Table.Rows.Remove(_dr);
        }

        DataRow CariNoDKN(string _noDKn, DataTable dt)
        {
            DataRow dr = null;
            if (!string.IsNullOrEmpty(_noDKn) && (dt != null))
            {
                foreach (DataRow r in dt.Rows)
                    if (Tools.isNull(r["no_dkn"], "").ToString() == _noDKn)
                    {
                        dr = r;
                        if (dr != null)
                        {
                            _dkn00.GetFromDataRow(dr);
                            _dkn00.cabang = "";
                            _dkn00.uraian = "";
                            _dkn00.jumlah = 0;
                            _dkn00.no_perk = "";
                            _dkn00.iddetail = Tools.CreateFingerPrint();
                            RefreshData();
                        }
                        else if (string.IsNullOrEmpty(_dkn00.idhead)) _dkn00.idhead = Tools.CreateFingerPrint();
                        break;
                    }
            }
            return dr;
        }

        private void txtNoDKN_TextChanged(object sender, EventArgs e)
        {
            if (txtNoDKN.Text != "")
            {
                DataRow dr = CariNoDKN(txtNoDKN.Text, _dt);
            }
        }
    }
}
