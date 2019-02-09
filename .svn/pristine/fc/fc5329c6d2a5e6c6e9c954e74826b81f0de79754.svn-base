using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmKoreksiKeuangan : ISA.Controls.BaseForm
    {
        Guid _RowID, _JnsTransRowID;
        DataTable dt;
        string _Jns, _Sumber;
        Class.FillComboBox cbo = new ISA.Showroom.Finance.Class.FillComboBox();
        
        public frmKoreksiKeuangan(Guid RowID, string Sumber)
        {
            InitializeComponent();
            _RowID = RowID;
            _Sumber = Sumber;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKoreksiKeuangan_Load(object sender, EventArgs e)
        {
            if (_Sumber == "KM")
            {
                Title = "Koreksi Penerimaan Uang";
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                txtTanggal.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"], "").ToString());
                String MataUangID = Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString();
                textMataUang.Text = MataUangID;
                lookUpRekening2.MataUangIDRekening = MataUangID;
                Guid PtRowID = GlobalVar.PerusahaanRowID;
                lookUpRekening2.PerusahaanID = PtRowID;
                txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], 0).ToString();
                txtNominalRp.Text = Tools.isNull(dt.Rows[0]["NominalRp"], 0).ToString();
                txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                textKePT.Text = Tools.isNull(dt.Rows[0]["NamaPerusahaan"], "").ToString();
                textKeCabang.Text = Tools.isNull(dt.Rows[0]["CabangKe"], "").ToString();
                textJnsTransaksi.Text = Tools.isNull(dt.Rows[0]["NamaTransaksi"], "").ToString();
                txtNoApproval.Text = Tools.isNull(dt.Rows[0]["NoApproval"], "").ToString();
                lookUpRekening1.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                _JnsTransRowID = (Guid)Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], Guid.Empty);
                _Jns = Tools.isNull(dt.Rows[0]["JnsPenerimaan"], "").ToString();
                if (_Jns == "K")
                {
                    rdoKas.Checked = true;
                    lookUpRekening2.Enabled = false;
                }
                if (_Jns == "G")
                {
                    rdoGiro.Checked = true;
                    lookUpRekening2.Enabled = false;
                }
                if (_Jns == "B")
                {
                    rdoBank.Checked = true;
                    lookUpRekening2.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                }

                cbo.fillComboCabang(cboCabangKor);
                cboCabangKor.SelectedValue = Tools.isNull(dt.Rows[0]["CabangKe"], "").ToString();
                cbo.fillComboJnsTransaksi(cboJnsTransaksi);
                cboJnsTransaksi.SelectedValue = Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], "").ToString();
            }
            else
            {
                Title = "Koreksi Pengeluaran Uang";
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                txtTanggal.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"], "").ToString());
                String MataUangID = Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString();
                textMataUang.Text = MataUangID;
                lookUpRekening2.MataUangIDRekening = MataUangID;
                Guid PtRowID = GlobalVar.PerusahaanRowID;
                lookUpRekening2.PerusahaanID = PtRowID;
                txtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], 0).ToString();
                txtNominalRp.Text = Tools.isNull(dt.Rows[0]["NominalRp"], 0).ToString();
                txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
                textKePT.Text = Tools.isNull(dt.Rows[0]["NamaPerusahaan"], "").ToString();
                textKeCabang.Text = Tools.isNull(dt.Rows[0]["CabangKeID"], "").ToString();
                textJnsTransaksi.Text = Tools.isNull(dt.Rows[0]["NamaTransaksi"], "").ToString();
                txtNoApproval.Text = Tools.isNull(dt.Rows[0]["NoApproval"], "").ToString();
                lookUpRekening1.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                _JnsTransRowID = (Guid)Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], Guid.Empty);
                _Jns = Tools.isNull(dt.Rows[0]["JnsPengeluaran"], "").ToString();
                if (_Jns == "K")
                {
                    rdoKas.Checked = true;
                    lookUpRekening2.Enabled = false;
                }
                if (_Jns == "G")
                {
                    rdoGiro.Checked = true;
                    lookUpRekening2.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                }
                if (_Jns == "B")
                {
                    rdoBank.Checked = true;
                    lookUpRekening2.RekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"], Guid.Empty);
                }

                cbo.fillComboCabang(cboCabangKor);
                cboCabangKor.SelectedValue = Tools.isNull(dt.Rows[0]["CabangKeID"], "").ToString();
                cbo.fillComboJnsTransaksi(cboJnsTransaksi);
                cboJnsTransaksi.SelectedValue = Tools.isNull(dt.Rows[0]["JnsTransaksiRowID"], "").ToString();
            }
            dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KoreksiKeuangan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@TransRowID", SqlDbType.UniqueIdentifier, _RowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0) cmdSAVE.Enabled = false;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            string CabangKeOld = textKeCabang.Text;
            string CabangKeNew = cboCabangKor.SelectedValue.ToString();
            Guid RekeningOld = lookUpRekening1.RekeningRowID;
            Guid RekeningNew = lookUpRekening2.RekeningRowID;
            Guid JnsTransaksiOld = _JnsTransRowID;
            Guid JnsTransaksiNew = (Guid)Guid.Empty;
            if (cboJnsTransaksi.Text != "") JnsTransaksiNew = (Guid)cboJnsTransaksi.SelectedValue;

            if (CabangKeNew != CabangKeOld || RekeningNew != RekeningOld || JnsTransaksiNew != JnsTransaksiOld)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KoreksiKeuangan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@TransRowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, _Sumber));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                    if (CabangKeNew != CabangKeOld) db.Commands[0].Parameters.Add(new Parameter("@CabangKe", SqlDbType.VarChar, CabangKeNew));
                    if (RekeningNew != RekeningOld) db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, RekeningNew));
                    if (JnsTransaksiNew != JnsTransaksiOld) db.Commands[0].Parameters.Add(new Parameter("@JnsTransaksiRowID", SqlDbType.UniqueIdentifier, JnsTransaksiNew));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            this.Close();
        }

        private void cmdHISTORY_Click(object sender, EventArgs e)
        {
            frmKoreksiKeuanganHistory ifrmChild = new frmKoreksiKeuanganHistory(_RowID,_Sumber);
            ifrmChild.Show();
        }
    }
}
