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

namespace ISA.Showroom.Penjualan
{
    public partial class frmAngsuranChange : ISA.Controls.BaseForm
    {
        enum FormMode { UMT, UbahAngsuran };
        FormMode mode = new FormMode();
        Guid _rowID, _penjRowID, _penjHistID;
        string _kodeTrans;
        string _cabangID = GlobalVar.CabangID;
        DateTime _tglJT, _tgjJual;
        int _angsKe;
        Double _interest, _nominal, _saldo;

        public frmAngsuranChange(Form caller, Guid penjHistID, Guid penjRowID, string strMode)
        {
            InitializeComponent();
            _penjRowID = penjRowID;
            _rowID = Guid.NewGuid();
            this.Caller = caller;
            _penjHistID = penjHistID;
            switch (strMode)
            {
                case "UMT":
                    mode = FormMode.UMT;
                    break;
                case "UbahAngsuran":
                    mode = FormMode.UbahAngsuran;
                    break;
            }
        }

        private void refresh()
        {
            try
            {
                switch (mode)
                {
                    case FormMode.UMT:
                        using (Database _db = new Database())
                        {
                            DataTable _dt = new DataTable();
                            _db.Commands.Add(_db.CreateCommand("usp_Angsuran_LIST_ALL"));
                            _db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                            _db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            _db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            _db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, "UMT"));
                            _db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTglLunas1.DateValue));
                            _dt = _db.Commands[0].ExecuteDataTable();

                            this.Text = "Kwitansi Uang Muka Tambahan";
                            this.Title = "Kwitansi Uang Muka Tambahan";
                            _kodeTrans = Tools.isNull(_dt.Rows[0]["KodeTrans"], "").ToString();
                            txtTglLunas1.DateValue = (DateTime)_dt.Rows[0]["Tanggal"];
                            txtTglLunas1.ReadOnly = true;
                            txtUangMuka1.Text = Tools.isNull(_dt.Rows[0]["TerimaUM"], 0).ToString();
                            txtUangMuka1.ReadOnly = true;
                            txtPiutangPokok1.Text = Tools.isNull(_dt.Rows[0]["PiutangPokok"], 0).ToString();
                            txtPiutangPokok1.ReadOnly = true;
                            txtTerimaPokok1.Text = Tools.isNull(_dt.Rows[0]["TerimaPokok"], 0).ToString();
                            txtTerimaPokok1.ReadOnly = true;
                            txtSaldoPokok1.Text = Tools.isNull(_dt.Rows[0]["SaldoPokok"], 0).ToString();
                            txtSaldoPokok1.ReadOnly = true;
                            txtTempo1.Text = Tools.isNull(_dt.Rows[0]["TempoAngsuran"], 0).ToString();
                            txtTempo1.ReadOnly = true;
                            txtBunga1.Text = Tools.isNull(_dt.Rows[0]["Bunga"], 0).ToString();
                            txtBunga1.ReadOnly = true;
                            txtTglJT1.Text = Tools.isNull(_dt.Rows[0]["TglJT"], 0).ToString();
                            txtTglJT1.ReadOnly = true;
                            txtAwalAngs1.DateValue = (DateTime)_dt.Rows[0]["TglAwalAngs"];
                            txtAwalAngs1.ReadOnly = true;
                            txtAkhirAngs1.DateValue = (DateTime)_dt.Rows[0]["TglAkhirAngs"];
                            txtAkhirAngs1.ReadOnly = true;
                            txtPembulatan.Text = Tools.isNull(_dt.Rows[0]["Pembulatan"], 0).ToString();
                            txtPembulatan.ReadOnly = true;
                            txtAngsKe1.Text = Tools.isNull(_dt.Rows[0]["AngsuranKe"], 0).ToString();
                            txtAngsKe1.ReadOnly = true;
                            txtSistemAngs1.Text = Tools.isNull(_dt.Rows[0]["SistemAngs"], "").ToString();
                            txtSistemAngs1.ReadOnly = true;
                            txtMataUang1.Text = Tools.isNull(_dt.Rows[0]["MataUangID"], 0).ToString();
                            txtMataUang1.ReadOnly = true;
                            txtUMT1.Text = Tools.isNull(_dt.Rows[0]["TambahUM"], 0).ToString();
                            txtUMT1.ReadOnly = true;
                            txtTglLunas2.DateValue = GlobalVar.GetServerDate;
                            txtTglLunas2.ReadOnly = false;
                            txtSaldoPindahan.Text = Tools.isNull(_dt.Rows[0]["SaldoPokok"], 0).ToString(); ;
                            txtSaldoPindahan.ReadOnly = true;
                            lblUMT.Text = "UMT";
                            txtUMT2.Text = "0";
                            txtUMT2.ReadOnly = false;
                            txtSisaPokok2.Text = Tools.isNull(_dt.Rows[0]["SaldoPokok"], 0).ToString(); ;
                            txtSisaPokok2.ReadOnly = true;
                            txtPiutangBunga.Text = "0";
                            txtPiutangBunga.ReadOnly = true;
                            txtTempo2.Text = Tools.isNull(_dt.Rows[0]["TempoAngsuranNew"], 0).ToString();
                            txtTempo2.ReadOnly = true;
                            txtBunga2.Text = Tools.isNull(_dt.Rows[0]["Bunga"], 0).ToString();
                            txtBunga2.ReadOnly = true;
                            numTgl.Value = int.Parse(string.Format("{0:dd}", (DateTime)GlobalVar.GetServerDate));
                            numTgl.ReadOnly = false;
                            txtAwalAngs2.DateValue = GlobalVar.GetServerDate;
                            txtAwalAngs2.ReadOnly = false;
                            _tglJT = (DateTime)GlobalVar.GetServerDate;
                            txtAkhirAngs2.DateValue = _tglJT.AddMonths(int.Parse(txtTempo1.Text) - int.Parse(txtAngsKe1.Text));
                            txtAkhirAngs2.ReadOnly = true;
                            txtAngsKe2.Text = (Convert.ToDouble(txtAngsKe1.Text) + 1).ToString();
                            txtAngsKe2.ReadOnly = true;
                            txtSistemAngs2.Text = Tools.isNull(_dt.Rows[0]["SistemAngs"], "").ToString();
                            txtSistemAngs2.ReadOnly = true;
                            txtJumlahPiutang.Text = "0";
                            txtJumlahPiutang.ReadOnly = true;
                        }
                        break;
                    case FormMode.UbahAngsuran:
                        using (Database _db = new Database())
                        {
                            DataTable _dt = new DataTable();
                            _db.Commands.Add(_db.CreateCommand("usp_UbahAngsuran_LIST"));
                            _db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                            _db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            _db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            _dt = _db.Commands[0].ExecuteDataTable();

                            this.Text = "Ubah Sistem Angsuran";
                            this.Title = "Ubah Sistem Angsuran";
                            _kodeTrans = Tools.isNull(_dt.Rows[0]["KodeTransNew"], "").ToString();
                            txtTglLunas1.DateValue = (DateTime)_dt.Rows[0]["Tanggal"];
                            txtTglLunas1.ReadOnly = true;
                            txtUangMuka1.Text = Tools.isNull(_dt.Rows[0]["TerimaUM"], 0).ToString();
                            txtUangMuka1.ReadOnly = true;
                            txtPiutangPokok1.Text = Tools.isNull(_dt.Rows[0]["PiutangPokok"], 0).ToString();
                            txtPiutangPokok1.ReadOnly = true;
                            txtTerimaPokok1.Text = Tools.isNull(_dt.Rows[0]["TerimaPokok"], 0).ToString();
                            txtTerimaPokok1.ReadOnly = true;
                            txtSaldoPokok1.Text = Tools.isNull(_dt.Rows[0]["SaldoPokok"], 0).ToString();
                            txtSaldoPokok1.ReadOnly = true;
                            txtTempo1.Text = Tools.isNull(_dt.Rows[0]["TempoAngsuran"], 0).ToString();
                            txtTempo1.ReadOnly = true;
                            txtBunga1.Text = Tools.isNull(_dt.Rows[0]["Bunga"], 0).ToString();
                            txtBunga1.ReadOnly = true;
                            txtTglJT1.Text = Tools.isNull(_dt.Rows[0]["TglJT"], 0).ToString();
                            txtTglJT1.ReadOnly = true;
                            txtAwalAngs1.DateValue = (DateTime)_dt.Rows[0]["TglAwalAngs"];
                            txtAwalAngs1.ReadOnly = true;
                            txtAkhirAngs1.DateValue = (DateTime)_dt.Rows[0]["TglAkhirAngs"];
                            txtAkhirAngs1.ReadOnly = true;
                            txtPembulatan.Text = Tools.isNull(_dt.Rows[0]["Pembulatan"], 0).ToString();
                            txtPembulatan.ReadOnly = true;
                            txtAngsKe1.Text = Tools.isNull(_dt.Rows[0]["AngsuranKe"], 0).ToString();
                            txtAngsKe1.ReadOnly = true;
                            txtSistemAngs1.Text = Tools.isNull(_dt.Rows[0]["SistemAngs"], "").ToString();
                            txtSistemAngs1.ReadOnly = true;
                            txtMataUang1.Text = Tools.isNull(_dt.Rows[0]["MataUangID"], 0).ToString();
                            txtMataUang1.ReadOnly = true;
                            txtUMT1.Text = Tools.isNull(_dt.Rows[0]["TambahUM"], 0).ToString();
                            txtUMT1.ReadOnly = true;
                            txtTglLunas2.DateValue = GlobalVar.GetServerDate;
                            txtTglLunas2.ReadOnly = false;
                            txtSaldoPindahan.Text = Tools.isNull(_dt.Rows[0]["SaldoPokok"], 0).ToString(); ;
                            txtSaldoPindahan.ReadOnly = true;
                            lblUMT.Text = "Harga Tafsiran";
                            txtUMT2.Text = "0";
                            txtUMT2.ReadOnly = false;
                            txtSisaPokok2.Text = Tools.isNull(_dt.Rows[0]["SaldoPokok"], 0).ToString(); ;
                            txtSisaPokok2.ReadOnly = true;
                            txtPiutangBunga.Text = "0";
                            txtPiutangBunga.ReadOnly = true;
                            txtTempo2.Text = Tools.isNull(_dt.Rows[0]["TempoAngsuranNew"], 0).ToString();
                            txtTempo2.ReadOnly = true;
                            txtBunga2.Text = "0";
                            txtBunga2.ReadOnly = false;
                            numTgl.Value = int.Parse(string.Format("{0:dd}", (DateTime)GlobalVar.GetServerDate));
                            numTgl.ReadOnly = false;
                            txtAwalAngs2.DateValue = GlobalVar.GetServerDate;
                            txtAwalAngs2.ReadOnly = false;
                            _tglJT = (DateTime)txtAwalAngs2.DateValue;
                            txtAkhirAngs2.DateValue = _tglJT.AddMonths(int.Parse(txtTempo1.Text) - int.Parse(txtAngsKe1.Text));
                            txtAkhirAngs2.ReadOnly = true;
                            txtAngsKe2.Text = (Convert.ToDouble(txtAngsKe1.Text) + 1).ToString();
                            txtAngsKe2.ReadOnly = true;
                            txtSistemAngs2.Text = Tools.isNull(_dt.Rows[0]["SistemAngsNew"], "").ToString();
                            txtSistemAngs2.ReadOnly = true;
                            txtJumlahPiutang.Text = "0";
                            txtJumlahPiutang.ReadOnly = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmAngsuranChange_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_LIST_ALL"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblTglJual.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglJual"]);
                    _tgjJual = (DateTime)dt.Rows[0]["TglJual"];
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    lblNoTrans.Text = "K" + Numerator.NextNumber("NKJ");
                    _saldo = Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"], 0));

                    DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                    dt2.DefaultView.Sort = "MataUangID ASC";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.ValueMember = "MataUangID";
                    cboMataUang.DataSource = dt2.DefaultView;

                    this.ListPembulatan();
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

        private void ListPembulatan()
        {
            cboPembulatan.DisplayMember = "Text";
            cboPembulatan.ValueMember = "Value";
            var items = new[] {
                new { Text = "0", Value = "0" },
                new { Text = "50", Value = "50" },
                new { Text = "100", Value = "100" }
            };
            cboPembulatan.DataSource = items;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAngsuranChange_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmAngsuranBrowse)
            {
                Penjualan.frmAngsuranBrowse frmCaller = (Penjualan.frmAngsuranBrowse)this.Caller;
                frmCaller.RefreshRowANG(_penjRowID);
                frmCaller.FindRowGrid2("mTanggal", String.Format("{0:dd-MMM-yyyy}", txtTglLunas2.Text));
                frmCaller.RefreshRowLunas(_rowID);
                frmCaller.FindRowGrid3("dRowID", _rowID.ToString());
            }
        }

        private void txtUMT2_TextChanged(object sender, EventArgs e)
        {
            if (mode == FormMode.UMT)
            {
                txtSisaPokok2.Text = (Convert.ToDouble(Tools.isNull(txtSaldoPindahan.Text,0)) - Convert.ToDouble(Tools.isNull(txtUMT2.Text,0))).ToString();
                try
                {
                    if ((Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(txtTempo2.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(txtBunga2.Text, 0)) > 0))
                    {   /*
                        Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                         "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                         "  FROM dbo.fn_HitungBungaMenurun (@Pokok,@Jml,@Bunga) ");
                        cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text);
                        cmdAngs.AddParameter("@Jml", SqlDbType.Int, txtTempo2.Text);
                        cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text);
                        DataTable dtAngs = cmdAngs.ExecuteDataTable();
                        */

                        DataTable dtAngs = new DataTable();
                        using(Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangMenurun"));
                            db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text));
                            dtAngs = db.Commands[0].ExecuteDataTable();
                        }

                        if (cboPembulatan.SelectedValue.ToString() == "0")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text,0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text,0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "50")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text,0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text,0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "100")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text,0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text,0))).ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else if (mode == FormMode.UbahAngsuran)
            {
                if (Convert.ToDouble(Tools.isNull(txtUMT2.Text, 0)) == 0) { txtSisaPokok2.Text = txtSaldoPindahan.Text; }
                else { txtSisaPokok2.Text = txtUMT2.Text; }
                try
                {
                    if ((Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(txtTempo2.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(txtBunga2.Text, 0)) > 0))
                    {   /*
                        Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                         "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                         "  FROM dbo.fn_HitungBungaTetap (@Pokok,@Jml,@Bunga) ");
                        cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text);
                        cmdAngs.AddParameter("@Jml", SqlDbType.Int, txtTempo2.Text);
                        cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text);
                        DataTable dtAngs = cmdAngs.ExecuteDataTable();
                        */

                        DataTable dtAngs = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangTetap"));
                            db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text));
                            dtAngs = db.Commands[0].ExecuteDataTable();
                        }

                        if (cboPembulatan.SelectedValue.ToString() == "0")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "50")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "100")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cboPembulatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode == FormMode.UMT)
            {
                try
                {
                    if ((Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) > 0) &&
                        (Convert.ToDouble(Tools.isNull(txtTempo2.Text, 0)) > 0) &&
                        (Convert.ToDouble(Tools.isNull(txtBunga2.Text, 0)) > 0))
                    {   /*
                        Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                         "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                         "  FROM dbo.fn_HitungBungaMenurun (@Pokok,@Jml,@Bunga) ");
                        cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text);
                        cmdAngs.AddParameter("@Jml", SqlDbType.Int, txtTempo2.Text);
                        cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text);
                        DataTable dtAngs = cmdAngs.ExecuteDataTable();
                        */

                        DataTable dtAngs = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangMenurun"));
                            db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text));
                            dtAngs = db.Commands[0].ExecuteDataTable();
                        }

                        if (cboPembulatan.SelectedValue.ToString() == "0")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "50")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "100")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else if (mode == FormMode.UbahAngsuran)
            {
                try
                {
                    if ((Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) > 0) &&
                        (Convert.ToDouble(Tools.isNull(txtTempo2.Text, 0)) > 0) &&
                        (Convert.ToDouble(Tools.isNull(txtBunga2.Text, 0)) > 0))
                    {   /*
                        Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                         "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                         "  FROM dbo.fn_HitungBungaTetap (@Pokok,@Jml,@Bunga) ");
                        cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text);
                        cmdAngs.AddParameter("@Jml", SqlDbType.Int, txtTempo2.Text);
                        cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text);
                        DataTable dtAngs = cmdAngs.ExecuteDataTable();
                        */
                        DataTable dtAngs = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangTetap"));
                            db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text));
                            dtAngs = db.Commands[0].ExecuteDataTable();
                        }

                        if (cboPembulatan.SelectedValue.ToString() == "0")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "50")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "100")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (mode)
                {
                    case FormMode.UMT :
                        if (Convert.ToDouble(Tools.isNull(txtUMT2.Text, 0)) == 0)
                        {
                            MessageBox.Show("Uang Muka Tambahan belum diisi !");
                            txtUMT2.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(txtAwalAngs2.Text))
                        {
                            MessageBox.Show("Awal Angsuran belum diisi !");
                            txtAwalAngs2.Focus();
                            return;
                        }
                        if (int.Parse(string.Format("{0:dd}", (DateTime)txtAwalAngs2.DateValue)) != numTgl.Value)
                        {
                            MessageBox.Show("Tanggal Awal Angsuran tidak sama dengan Tanggal Jatuh Tempo !");
                            txtAwalAngs2.Focus();
                            return;
                        }
                        if (txtTglLunas2.DateValue < GlobalVar.GetServerDate)
                        {
                            MessageBox.Show("Tanggal lebih kecil dari pada tanggal hari ini !");
                            txtTglLunas2.Focus();
                            return;
                        }
                        if (txtAwalAngs2.DateValue < txtTglLunas2.DateValue)
                        {
                            MessageBox.Show("Tanggal Awal Angsuran lebih kecil dari pada tanggal hari ini !");
                            txtAwalAngs2.Focus();
                            return;
                        }
                        if (Convert.ToDouble(txtUMT2.Text) >= Convert.ToDouble(txtSisaPokok2.Text))
                        {
                            MessageBox.Show("Uang Muka Tambahan lebih besar atau sama dengan Sisa Pokok !");
                            txtUMT2.Focus();
                            return;
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanUMT_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));                            
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, lblNoFaktur.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglUM", SqlDbType.DateTime, txtTglLunas2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.VarChar, numTgl.Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                            db.Commands[0].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Int, int.Parse(txtAngsKe2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtAwalAngs2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, txtAkhirAngs2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.SelectedValue.ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@UangMuka", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TerimaUM", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@PiutangPokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PiutangBunga", SqlDbType.Money, txtPiutangBunga.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TerimaAngs", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TerimaBunga", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TambahUM", SqlDbType.Money, txtUMT2.Text));                            
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoPindahan", SqlDbType.Money, txtSaldoPindahan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "UANG MUKA TAMBAHAN"));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case FormMode.UbahAngsuran :
                        if (Convert.ToDouble(Tools.isNull(txtUMT2.Text, 0)) == 0)
                        {
                            MessageBox.Show("Harga Tafsiran belum diisi !");
                            txtUMT2.Focus();
                            return;
                        }
                        if (Convert.ToDouble(Tools.isNull(txtBunga2.Text, 0)) == 0)
                        {
                            MessageBox.Show("Bunga belum diisi !");
                            txtBunga2.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(txtAwalAngs2.Text))
                        {
                            MessageBox.Show("Awal Angsuran belum diisi !");
                            txtAwalAngs2.Focus();
                            return;
                        }
                        if (int.Parse(string.Format("{0:dd}", (DateTime)txtAwalAngs2.DateValue)) != numTgl.Value)
                        {
                            MessageBox.Show("Tanggal Awal Angsuran tidak sama dengan Tanggal Jatuh Tempo !");
                            txtAwalAngs2.Focus();
                            return;
                        }
                        if (txtTglLunas2.DateValue < GlobalVar.GetServerDate)
                        {
                            MessageBox.Show("Tanggal lebih kecil dari pada tanggal hari ini !");
                            txtTglLunas2.Focus();
                            return;
                        }
                        if (txtAwalAngs2.DateValue < txtTglLunas2.DateValue)
                        {
                            MessageBox.Show("Tanggal Awal Angsuran lebih kecil dari pada tanggal hari ini !");
                            txtAwalAngs2.Focus();
                            return;
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_UbahAngsuran_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenjHistID", SqlDbType.UniqueIdentifier, _penjHistID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, lblNoFaktur.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglUM", SqlDbType.DateTime, txtTglLunas2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.VarChar, numTgl.Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, _kodeTrans));
                            db.Commands[0].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@AngsuranKe", SqlDbType.Int, int.Parse(txtAngsKe2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtAwalAngs2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, txtAkhirAngs2.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.SelectedValue.ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@UangMuka", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TerimaUM", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@PiutangPokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PiutangBunga", SqlDbType.Money, txtPiutangBunga.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TerimaAngs", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TerimaBunga", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@TambahUM", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoPindahan", SqlDbType.Money, txtSaldoPindahan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "UBAH ANGSURAN"));
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

        private void txtBunga2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtBunga2.Text) > 100)
            {
                MessageBox.Show("Bunga tidak boleh lebih dari 100 !");
                txtBunga2.Focus();
                return;
            }
            if (mode == FormMode.UbahAngsuran)
            {
                try
                {
                    if ((Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) > 0) &&
                        (Convert.ToDouble(Tools.isNull(txtTempo2.Text, 0)) > 0) &&
                        (Convert.ToDouble(Tools.isNull(txtBunga2.Text, 0)) > 0))
                    {   /*
                        Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                         "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                         "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                         "  FROM dbo.fn_HitungBungaTetap (@Pokok,@Jml,@Bunga) ");
                        cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text);
                        cmdAngs.AddParameter("@Jml", SqlDbType.Int, txtTempo2.Text);
                        cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text);
                        DataTable dtAngs = cmdAngs.ExecuteDataTable();
                        */

                        DataTable dtAngs = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangTetap"));
                            db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtSisaPokok2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, txtTempo2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga2.Text));
                            dtAngs = db.Commands[0].ExecuteDataTable();
                        }


                        if (cboPembulatan.SelectedValue.ToString() == "0")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "50")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                        else if (cboPembulatan.SelectedValue.ToString() == "100")
                        {
                            txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                            txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtSisaPokok2.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void txtAwalAngs2_TextChanged(object sender, EventArgs e)
        {
            _tglJT = (DateTime)txtAwalAngs2.DateValue;
            txtAkhirAngs2.DateValue = _tglJT.AddMonths(int.Parse(txtTempo1.Text) - int.Parse(txtAngsKe1.Text));
        }

        private void txtTempo2_TextChanged(object sender, EventArgs e)
        {
            _tglJT = (DateTime)txtAwalAngs2.DateValue;
            txtAkhirAngs2.DateValue = _tglJT.AddMonths(int.Parse(txtTempo1.Text) - int.Parse(txtAngsKe1.Text));
        }
    }
}
