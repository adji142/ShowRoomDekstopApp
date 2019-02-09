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

namespace ISA.Showroom.Pembelian
{
    public partial class frmTambahPotonganPembelian : ISA.Controls.BaseForm
    {
        Guid _PembelianRowID;
        
        public frmTambahPotonganPembelian()
        {
            InitializeComponent();
        }

        public frmTambahPotonganPembelian(Form Caller, Guid PembelianRowID)
        {
            InitializeComponent();
            this.Caller = Caller;
            _PembelianRowID = PembelianRowID;
        }

        private void frmTambahPotonganPembelian_Load(object sender, EventArgs e)
        {
            DataTable dummy = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Pembelian_LIST_for_PotonganPembelian"));
                db.Commands[0].Parameters.Add(new Parameter("@PembelianRowID", SqlDbType.UniqueIdentifier, _PembelianRowID));
                dummy = db.Commands[0].ExecuteDataTable();
                if (dummy.Rows.Count > 0)
                {
                    lblNoPol.Text = Tools.isNull(dummy.Rows[0]["Nopol"].ToString(), "").ToString();
                    lblAlamat.Text = Tools.isNull(dummy.Rows[0]["Alamat"].ToString(), "").ToString();
                    lblKelkec.Text = Tools.isNull(dummy.Rows[0]["KelKec"].ToString(), "").ToString();
                    lblKotaProv.Text = Tools.isNull(dummy.Rows[0]["KotaProv"].ToString(), "").ToString();
                    lblNoFaktur.Text = Tools.isNull(dummy.Rows[0]["Nofaktur"].ToString(), "").ToString();
                    lblNama.Text = Tools.isNull(dummy.Rows[0]["Nama"].ToString(), "").ToString();
                    lblSisaPembayaran.Text = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["SisaBayarBARU"], 0).ToString()).ToString("#,##0");
                    lblNoTrans.Text = "";
                    txtUraian.Text = "POTONGAN PEMBELIAN " + Tools.isNull(dummy.Rows[0]["Nofaktur"].ToString(), "").ToString();
                }
            }
        }

        private bool ValidateSave()
        {
            if ( txtNominal.GetDoubleValue == 0 )
            {
                MessageBox.Show("Isikan Nominal potongan terlebih dahulu!");
                txtNominal.Focus();
                return false;
            }
            if (txtNominal.GetDoubleValue > Convert.ToDouble(Tools.isNull(lblSisaPembayaran.Text, 0)) )
            {
                MessageBox.Show("Potongan tidak bisa melebihi sisa pembayaran!");
                txtNominal.Focus();
                return false;
            }
            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                lblNoTrans.Text = Numerator.NextNumber("NKB");
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PembayaranPemb_Potongan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid() ));
                    db.Commands[0].Parameters.Add(new Parameter("@Jenis", SqlDbType.VarChar, "POT"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "Potongan " + txtUraian.Text + " | " + lblNoPol.Text.Trim() + " - " + lblNama.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _PembelianRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, txtNominal.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 5));
                    db.Commands[0].ExecuteDataTable();
                    MessageBox.Show("Data berhasil diproses!");
                    this.Close();
                }
            }
        }   

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNominal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNominal_Leave(object sender, EventArgs e)
        {

        }

        private void frmTambahPotonganPembelian_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Pembelian.frmPelunasanPembelianBrowse)
            {
                Pembelian.frmPelunasanPembelianBrowse frmCaller = (Pembelian.frmPelunasanPembelianBrowse)this.Caller;
                frmCaller.RefreshRow(_PembelianRowID);
                frmCaller.FindRowGrid3("NoTrans", lblNoTrans.Text);
            }
        }
    }
}
