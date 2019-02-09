using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.DKN
{
    public partial class PembebananCabang_detail : ISA.Controls.BaseForm 
    {
        enum enumFormMode { New, Update };
        enum enumFromGrid { Satu, Dua };
        enumFormMode formMode;
        enumFromGrid formGrid;
        Class.FillComboBox fcbo = new ISA.Showroom.Finance.Class.FillComboBox();
        Guid _HeaderRowID, _DetailRowID;
        
        public PembebananCabang_detail(Form _caller) // grid 1 add
        {
            InitializeComponent();
            formGrid = enumFromGrid.Satu;
            formMode = enumFormMode.New;
            this.Caller = _caller;
        }
        public PembebananCabang_detail(Form _caller, Guid RowID) // grid 1 edit
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            formGrid = enumFromGrid.Satu;
            _HeaderRowID = RowID;
            this.Caller = _caller;
        }
        public PembebananCabang_detail(Form _caller, Guid HeaderRowID, Guid RowID) // grid 2 add, grid 2 edit
        {
            InitializeComponent();
            _HeaderRowID = HeaderRowID;
            if (RowID == Guid.Empty)
            {
                formMode = enumFormMode.New;
                formGrid = enumFromGrid.Dua;
            }
            else
            {
                formMode = enumFormMode.Update;
                formGrid = enumFromGrid.Dua;
                _DetailRowID = RowID;
            }
            this.Caller = _caller;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PembebananCabang_detail_Load(object sender, EventArgs e)
        {
            if (formGrid == enumFromGrid.Satu)
            {
                panel2.Enabled = false;
                if (formMode == enumFormMode.Update) RefreshData();
                else dateMulai.DateValue = (DateTime)GlobalVar.GetServerDate;
            }
            else 
            {
                panel1.Enabled = false;
                fcbo.fillComboCabangNonCabangIDLocal(cboCabang, GlobalVar.PerusahaanRowID, "11");
                fcbo.fillComboPerusahaanNoPerusahaanIDLocal(cboPT, 11);
                fcbo.fillComboKelompokHI(cboTransaksiHI);
                RefreshData();
                numNominal.Enabled = optTetap.Checked;
                if (formMode == enumFormMode.Update) RefreshDataDetail();
            }
        }

        private void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PembebananCabang_LIST_BY_RowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _HeaderRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            txtNamaBeban.Text = dt.Rows[0]["NamaBeban"].ToString();
            optTetap.Checked = Convert.ToBoolean(dt.Rows[0]["Tetap"]) == true;
            optTdkTetap.Checked = Convert.ToBoolean(dt.Rows[0]["Tetap"]) == false;
            dateMulai.DateValue = Convert.ToDateTime(dt.Rows[0]["Tgl_mulai"]);
            if (Tools.isNull(dt.Rows[0]["Tgl_berakhir"].ToString(), "") != "") dateBerakhir.DateValue = Convert.ToDateTime(dt.Rows[0]["Tgl_berakhir"]);
        }

        private void RefreshDataDetail()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PembebananCabangDetail_LIST_BY_RowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _DetailRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (Tools.isNull(dt.Rows[0]["BebanCabangID"].ToString(), "") != "") cboCabang.SelectedValue = dt.Rows[0]["BebanCabangID"].ToString();
            if (Tools.isNull(dt.Rows[0]["BebanPerusahaanRowID"].ToString(), "") != "") cboPT.SelectedValue = dt.Rows[0]["BebanPerusahaanRowID"].ToString();
            cboTransaksiHI.SelectedValue = dt.Rows[0]["JenisTransaksiRowID"].ToString();
            numNominal.Text = dt.Rows[0]["NominalRp"].ToString();
            numTiapTanggal.Value = Convert.ToDecimal(dt.Rows[0]["TiapTanggal"].ToString());
            txtUraian.Text = dt.Rows[0]["Uraian"].ToString();
            if (Tools.isNull(dt.Rows[0]["Tgl_berakhir"].ToString(), "") != "") txtTglAkhirCabang.DateValue = Convert.ToDateTime(dt.Rows[0]["Tgl_berakhir"]);
        }
        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (formGrid == enumFromGrid.Satu)
            {
                if (txtNamaBeban.Text == "")
                {
                    MessageBox.Show("Nama Pembebanan belum di isi!");
                    txtNamaBeban.Focus();
                    return;
                }
                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (formMode == enumFormMode.New)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabang_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBeban", SqlDbType.VarChar, txtNamaBeban.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Tetap", SqlDbType.Bit, optTetap.Checked));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl_mulai", SqlDbType.Date, dateMulai.DateValue));
                        if (dateBerakhir.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@Tgl_berakhir", SqlDbType.Date, dateBerakhir.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabang_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _HeaderRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaBeban", SqlDbType.VarChar, txtNamaBeban.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Tetap", SqlDbType.Bit, optTetap.Checked));
                        db.Commands[0].Parameters.Add(new Parameter("@Tgl_mulai", SqlDbType.Date, dateMulai.DateValue));
                        if (dateBerakhir.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@Tgl_berakhir", SqlDbType.Date, dateBerakhir.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    frmPembebananCabang ifrm = (frmPembebananCabang)this.Caller;
                    ifrm.RefreshData();
                    this.Close();
                }
            }
            else 
            {
                if ((cboCabang.Text.ToString() == "" && cboPT.Text.ToString() == "") || (cboCabang.Text.ToString() != "" && cboPT.Text.ToString() != ""))
                {
                    MessageBox.Show("Pilih Salah 1 antara pembebanan ke Cabang atau ke PT !");
                    cboCabang.Focus();
                    return;
                }
                if (optTetap.Checked && Convert.ToDouble(numNominal.Text) == 0)
                {
                    MessageBox.Show("Nominal belum di isi!");
                    numNominal.Focus();
                    return;
                }
                if (cboTransaksiHI.Text.ToString() == "")
                {
                    MessageBox.Show("Silahkan pilih Jenis Transaksi!");
                    cboTransaksiHI.Focus();
                    return;
                }
                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (formMode == enumFormMode.New)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabangDetail_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, _HeaderRowID));
                        if (cboCabang.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cboCabang.Text.ToString()));
                        if (cboPT.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPT.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@JenisTransaksiRowID", SqlDbType.UniqueIdentifier, cboTransaksiHI.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDouble(numNominal.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@TiapTanggal", SqlDbType.Int, numTiapTanggal.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        if (txtTglAkhirCabang.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@TglBerakhir", SqlDbType.Date, txtTglAkhirCabang.DateValue));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabangDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _DetailRowID));
                        if (cboCabang.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, cboCabang.Text.ToString()));
                        if (cboPT.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, cboPT.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@JenisTransaksiRowID", SqlDbType.UniqueIdentifier, cboTransaksiHI.SelectedValue));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDouble(numNominal.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@TiapTanggal", SqlDbType.Int, numTiapTanggal.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        if (txtTglAkhirCabang.Text.ToString() != "") db.Commands[0].Parameters.Add(new Parameter("@TglBerakhir", SqlDbType.Date, txtTglAkhirCabang.DateValue));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    frmPembebananCabang ifrm = (frmPembebananCabang)this.Caller;
                    ifrm.RefreshDataDetail();
                    this.Close();
                }
            }
        }

    }
}
