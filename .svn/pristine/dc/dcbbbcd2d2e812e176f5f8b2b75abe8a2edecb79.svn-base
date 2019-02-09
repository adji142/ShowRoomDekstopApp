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
using System.Data.SqlTypes;

namespace ISA.Showroom.Pembelian
{
    public partial class frmCekListUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID;
        string _cabangID = GlobalVar.CabangID;
        string _flagSource = "ORI";

        public frmCekListUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _rowID = rowID;
        }

        public frmCekListUpdate(Form caller, Guid rowID, String FlagSource)
        {
            InitializeComponent();
            this.Caller = caller;
            _rowID = rowID;
            _flagSource = FlagSource; // mestinya constructor ini hanya dari yang pembelian TLA
        }

        private void frmCekListUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                    lblNama.Text = Tools.isNull(dt.Rows[0]["NamaVendor"], "").ToString();
                    lblTglBeli.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglBeli"]);
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    lblMerkType.Text = Tools.isNull(dt.Rows[0]["MerkMotor"], "").ToString() + " / " + Tools.isNull(dt.Rows[0]["TypeMotor"], "").ToString();
                    lblWarna.Text = Tools.isNull(dt.Rows[0]["Warna"], "").ToString();
                    lblNopol.Text = Tools.isNull(dt.Rows[0]["Nopol"], "").ToString();
                    lblNoRangka.Text = Tools.isNull(dt.Rows[0]["NoRangka"], "").ToString();
                    lblNoMesin.Text = Tools.isNull(dt.Rows[0]["NoMesin"], "").ToString();
                    lblNoBPKB.Text = Tools.isNull(dt.Rows[0]["NoBPKB"], "").ToString();
                    lblNamaBPKB.Text = Tools.isNull(dt.Rows[0]["NamaBPKB"], "").ToString();
                    if ((bool)Tools.isNull(dt.Rows[0]["cekFisik"], false) == true) rbFisik1.Checked = true;
                    else rbFisik2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekBPKB"], false) == true) rbBPKB1.Checked = true;
                    else rbBPKB2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekSTNK"], false) == true) rbSTNK1.Checked = true;
                    else rbSTNK2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekManualBook"], false) == true) rbManual1.Checked = true;
                    else rbManual2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekKunciUtama"], false) == true) rbKontakUt1.Checked = true;
                    else rbKontakUt2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekKunciDuplikat"], false) == true) rbKontakCad1.Checked = true;
                    else rbKontakCad2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekKunciPas"], false) == true) rbKunciPas1.Checked = true;
                    else rbKunciPas2.Checked = true;
                    if ((bool)Tools.isNull(dt.Rows[0]["cekBukuServis"], false) == true) rbServis1.Checked = true;
                    else rbServis2.Checked = true;
                }

                if (_flagSource == "BARU")
                {
                    label29.Visible = false; // label BPKB
                    label30.Visible = false; // label STNK
                    panel5.Visible = false; // panel BPKB
                    panel6.Visible = false; // panel STNK
                    rbBPKB1.Visible = false;
                    rbBPKB2.Visible = false;
                    rbSTNK1.Visible = false;
                    rbSTNK2.Visible = false;
                }
                else
                {
                    label29.Visible = true; // label BPKB
                    label30.Visible = true; // label STNK
                    panel5.Visible = true; // panel BPKB
                    panel6.Visible = true; // panel STNK
                    rbBPKB1.Visible = true;
                    rbBPKB2.Visible = true;
                    rbSTNK1.Visible = true;
                    rbSTNK2.Visible = true;
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

        bool _fisik = false;
        bool _bpkb = false;
        bool _stnk = false;
        bool _kontakut = false;
        bool _kontakcad = false;
        bool _kuncipas = false;
        bool _manual = false;
        bool _servis = false;
        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (rbFisik1.Checked == true)
                {
                    _fisik = true;
                }
                else
                {
                    _fisik = false;
                }

                if (rbBPKB1.Checked == true)
                {
                    _bpkb = true;
                }
                else
                {
                    _bpkb = false;
                }

                if (rbSTNK1.Checked == true)
                {
                    _stnk = true;
                }
                else
                {
                    _stnk = false;
                }

                if (rbKontakUt1.Checked == true)
                {
                    _kontakut = true;
                }
                else
                {
                    _kontakut = false;
                }

                if (rbKontakCad1.Checked == true)
                {
                    _kontakcad = true;
                }
                else
                {
                    _kontakcad = false;
                }

                if (rbKunciPas1.Checked == true)
                {
                    _kuncipas = true;
                }
                else
                {
                    _kuncipas = false;
                }

                if (rbManual1.Checked == true)
                {
                    _manual = true;
                }
                else
                {
                    _manual = false;
                }

                if (rbServis1.Checked == true)
                {
                    _servis = true;
                }
                else
                {
                    _servis = false;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pembelian_UPDATE_CHECK"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@cekFisik", SqlDbType.Bit, _fisik));
                    db.Commands[0].Parameters.Add(new Parameter("@cekBPKB", SqlDbType.Bit, _bpkb));
                    db.Commands[0].Parameters.Add(new Parameter("@cekSTNK", SqlDbType.Bit, _stnk));
                    db.Commands[0].Parameters.Add(new Parameter("@cekManualBook", SqlDbType.Bit, _manual));
                    db.Commands[0].Parameters.Add(new Parameter("@cekKunciUtama", SqlDbType.Bit, _kontakut));
                    db.Commands[0].Parameters.Add(new Parameter("@cekKunciDuplikat", SqlDbType.Bit, _kontakcad));
                    db.Commands[0].Parameters.Add(new Parameter("@cekKunciPas", SqlDbType.Bit, _kuncipas));
                    db.Commands[0].Parameters.Add(new Parameter("@cekBukuServis", SqlDbType.Bit, _servis));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil diupdate");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate !\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCekListUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Pembelian.frmPembelianBrowse)
            {
                Pembelian.frmPembelianBrowse frmCaller = (Pembelian.frmPembelianBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("NoFaktur", lblNoFaktur.Text);
            }
        }
    }
}
