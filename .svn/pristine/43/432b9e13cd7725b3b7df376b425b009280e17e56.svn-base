using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Showroom.Class;
using ISA.DAL; 

namespace ISA.Showroom.Penjualan
{
    public partial class frmAngsuranIden : ISA.Controls.BaseForm
    {
        List<AngsuranIden> _listAngsuranIden;
        AngsuranDetail angsuranDetailAkanDiIden;
        DataTable dtTitipanDataDiiden = new DataTable();
        public Double nominalTambahan = 0;
        public int modeBayar = 0;

        public Double nominalPembulatan = 0;
        public Double nominalBayarTunaiBulat = 0;
        string _kodetrans = "";


        public frmAngsuranIden()
        {
            InitializeComponent();
        }

        public frmAngsuranIden(Form caller , AngsuranDetail pAngsuranDetail , List<AngsuranIden> pListAngsuranIden  )
        {
            InitializeComponent();
            this.Caller = caller; 
            gvIdentifkasi.AutoGenerateColumns = false; 
            _listAngsuranIden = pListAngsuranIden; 
            angsuranDetailAkanDiIden = pAngsuranDetail;
           
        }

        public frmAngsuranIden(Form caller, AngsuranDetail pAngsuranDetail, List<AngsuranIden> pListAngsuranIden, string jenis, string kodetrans)
        {
            InitializeComponent();
            this.Caller = caller;
            gvIdentifkasi.AutoGenerateColumns = false;
            _listAngsuranIden = pListAngsuranIden;
            angsuranDetailAkanDiIden = pAngsuranDetail;
            _kodetrans = kodetrans;
            if (jenis == "Leasing")
            {
                this.Text = "Titipan Pelunasan Leasing";
                this.Title = "Titipan Pelunasan Leasing";
                txtTarikan.Visible = false;
                txtPotongan.Visible = false;
                lblPotongan.Visible = false;
                lblTarikMotor.Visible = false;
                txtDenda.Visible = false;
                txtTotal.Visible = false;
                lblDenda.Visible = false;
                lblTotal.Visible = false;
            }
        }

        //Penjualan.frmAngsuranIden ifrmChild = new Penjualan.frmAngsuranIden(this, _penjHistID, _penjRowID);
        
        /* sepertinya end edit aja cukup sih
        private void gvIdentifkasi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string NamaKolom = gvIdentifkasi.Columns[e.ColumnIndex].Name.ToString().ToUpper();
            DataRow drIden = (DataRow)(gvIdentifkasi.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            if (
                    (angsuranDetailAkanDiIden.TipeBunga == "FLT" && Convert.ToDouble(txtPembayaran.Text) <= Convert.ToDouble(ntbNominalIden.Text))
                    ||
                    (angsuranDetailAkanDiIden.TipeBunga == "APD")
                )
            {
                if (NamaKolom.ToLower() == "nominaliden")
                {
                    if(Convert.ToDouble(Tools.isNull(drIden["nominaliden"],0)) >=1 ) 
                    {
                        if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominaliden"].Value, 0)) > Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominalsisa"].Value, 0)) )
                        {
                            gvIdentifkasi.Rows[e.RowIndex].Cells["nominaliden"].Value = Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominalsisa"].Value, 0)); 
                        }
                        
                        int rowGV = 0;
                        double sumIden = 0; 
                        for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
                        {
                            sumIden = sumIden + Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0)); 
                        }

                        ntbNominalIden.Text = sumIden.ToString(); 
                    }
                }                
            }
        }
        */

        private void gvIdentifkasi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string NamaKolom = gvIdentifkasi.Columns[e.ColumnIndex].Name.ToString().ToUpper();
            DataRow drIden = (DataRow)(gvIdentifkasi.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            /* sepertinya cek jumlahnya itu pas klik save aja cukup
            if (
                    (angsuranDetailAkanDiIden.TipeBunga == "FLT" && Convert.ToDouble(txtPembayaran.Text) <= Convert.ToDouble(ntbNominalIden.Text))
                    ||
                    (angsuranDetailAkanDiIden.TipeBunga == "APD")
                )
            {
            */ 
                if (NamaKolom.ToLower() == "nominaliden")
                {
                    if (Convert.ToDouble(Tools.isNull(drIden["nominaliden"], 0)) >= 1)
                    {
                        if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominaliden"].Value, 0)) > Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominalsisa"].Value, 0)))
                        {
                            gvIdentifkasi.Rows[e.RowIndex].Cells["nominaliden"].Value = Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominalsisa"].Value, 0));
                        }
                        
                        int rowGV = 0;
                        Double sumIden = 0;
                        for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
                        {
                            sumIden = sumIden + Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
                        }

                        // tambahan sum iden dari nominaltambahan
                        sumIden = sumIden + nominalTambahan;
                        ntbNominalIden.Text = sumIden.ToString();
                    }
                }
            //}
        }

        private void gvIdentifkasi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.ToString());
            }
        }

        private void frmAngsuranIden_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData(); 
        }


        private void BindData()
        {
            cboModelBayar.SelectedIndex = 0;
            txtNominalTambahan.Text = "0";
            txtNominalTambahan.Enabled = false;
            txtNominalTambahan.ReadOnly = true;

            txtCustomerNama.Text = angsuranDetailAkanDiIden.CustomerName.ToString(); 
            txtPiutangPokok.Text = angsuranDetailAkanDiIden.SaldoPiutangPokok.ToString() ;
            txtDenda.Text = angsuranDetailAkanDiIden.Denda.ToString();
            txtTotal.Text = angsuranDetailAkanDiIden.TotalAngsuran.ToString();
            txtPembayaran.Text = angsuranDetailAkanDiIden.NominalPembayaran.ToString();
            txtPotonganBunga.Text = angsuranDetailAkanDiIden.PotonganBunga.ToString();
            txtPotongan.Text = angsuranDetailAkanDiIden.Potongan.ToString();
            if (_kodetrans == "TUN" || _kodetrans == "CTP")
            {
                ntbNominalBunga.Text = angsuranDetailAkanDiIden.BayarBunga.ToString();
            }
            else
            {
                txtPotonganBunga.Text = angsuranDetailAkanDiIden.BayarBunga.ToString();
            }
            txtTarikan.Text = angsuranDetailAkanDiIden.BiayaTarikMotor.ToString();
            txtMataUangID.Text = angsuranDetailAkanDiIden.MataUangID.ToString();
             
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_titipandapatdiiden"));
                    db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, angsuranDetailAkanDiIden.CustomerRowID ));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, angsuranDetailAkanDiIden.MataUangID));
                    dtTitipanDataDiiden = db.Commands[0].ExecuteDataTable();
                    
                    gvIdentifkasi.DataSource = dtTitipanDataDiiden;
                    gvIdentifkasi.ReadOnly = false;        
                    gvIdentifkasi.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                    for (int i = 0; i < gvIdentifkasi.ColumnCount; i++)
                    {
                        gvIdentifkasi.Columns[i].ReadOnly = true;
                    }
                    gvIdentifkasi.Columns["NominalIden"].ReadOnly = false;
                }

            }
            catch(Exception ex)
            {
                Error.LogError(ex, "Gagal menampilkan daftar titipan yang dapat diInden"); 
            }

            //usp_titipandapatdiiden
        }

        private void InitControl()
        {
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cboModelBayar.SelectedIndex == 1)
            {
                if (Convert.ToDouble(txtNominalTambahan.Text) < 1)
                {
                    MessageBox.Show("Isikan nominal uang tunai tambahan terlebih dahulu");
                    txtNominalTambahan.Focus();
                    return;
                }
            }

            if (angsuranDetailAkanDiIden.TipeBunga == "APD")
            {

                if (Convert.ToDouble(ntbNominalIden.Text) < (Convert.ToDouble(angsuranDetailAkanDiIden.BayarBunga) + Convert.ToDouble(angsuranDetailAkanDiIden.Denda))) // 
                {
                    MessageBox.Show("Identifikasi harus minimal harus sama dengan nominal bunga (+ denda jika dibayarkan)!");
                }
                else
                {
                    //simpan ke list<> 
                    SimpanDraftIdentifikasi();
                    this.Close(); 
                }

            }
            else if (angsuranDetailAkanDiIden.TipeBunga == "FLT")
            {

                if (Convert.ToDouble(ntbNominalIden.Text) != (Convert.ToDouble(txtPembayaran.Text) + Convert.ToDouble(angsuranDetailAkanDiIden.Denda)))
                {
                    MessageBox.Show("Identifikasi harus sama dengan nominal angsuran (+ denda jika dibayarkan) yang sudah di tetapkan");
                }
                else
                {
                    //simpan ke list<> 
                    SimpanDraftIdentifikasi();
                    this.Close(); 

                }
            }
            else if (angsuranDetailAkanDiIden.TipeBunga == "TUN")
            {

                if (Convert.ToDouble(ntbNominalIden.Text) != (Convert.ToDouble(txtPembayaran.Text) + Convert.ToDouble(angsuranDetailAkanDiIden.Denda)))
                {
                    MessageBox.Show("Identifikasi harus sama dengan nominal pembayaran yang sudah di tetapkan");
                }
                else
                {
                    //simpan ke list<> 
                    SimpanDraftIdentifikasi();
                    this.Close();
                    //MessageBox.Show("Proses bayar Tunai");

                }
            }
            else if (angsuranDetailAkanDiIden.TipeBunga == "CTP")
            {

                if (Convert.ToDouble(ntbNominalIden.Text) <= 0)
                {
                    MessageBox.Show("Identifikasi harus lebih dari 0");
                }
                else if (Convert.ToDouble(ntbNominalIden.Text) < Convert.ToDouble(ntbNominalBunga.Text))
                {
                    MessageBox.Show("Identifikasi harus lebih dari nominal bunga");
                }
                else if (Convert.ToDouble(ntbNominalIden.Text) > Convert.ToDouble(ntbNominalBunga.Text) + Convert.ToDouble(txtPembayaran.Text))
                {
                    MessageBox.Show("Identifikasi lebih dari nominal bunga + Pembayaran");
                }
                else
                {
                    //simpan ke list<> 
                    SimpanDraftIdentifikasi();
                    this.Close();
                    //MessageBox.Show("Proses Cash Tempo");

                }
            }


        }

        private void txtPembayaran_TextChanged(object sender, EventArgs e)
        {

        }


        private void SimpanDraftIdentifikasi()
        {
            int rowGV = 0;
            double sumIden = 0;
            AngsuranIden nAngsuranIden;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0)) > 0)
                {
                    nAngsuranIden = new AngsuranIden();
                    nAngsuranIden.TitipanRowID = new Guid(gvIdentifkasi.Rows[rowGV].Cells["TitipanRowID"].Value.ToString());
                    nAngsuranIden.NominalIden = Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
                    _listAngsuranIden.Add(nAngsuranIden); 
                }
            }

            angsuranDetailAkanDiIden.TotalNominalIden = Convert.ToDouble(ntbNominalIden.Text);

            nominalTambahan = Convert.ToDouble(txtNominalTambahan.Text.ToString());
            nominalPembulatan = Convert.ToDouble(txtNominalPembulatan.Text.ToString());
            nominalBayarTunaiBulat = Convert.ToDouble(txtNominalPembayaranPBL.Text.ToString());
        }



        private void frmAngsuranIden_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmAngsuranUpdate)
            {
                Penjualan.frmAngsuranUpdate frmCaller = (Penjualan.frmAngsuranUpdate)this.Caller;
                frmCaller.RefreshControlsTitipan();
                frmCaller.Focus();
            }

        }

        private void txtNominalTambahan_TextChanged(object sender, EventArgs e)
        {
            nominalTambahan = Convert.ToDouble(Tools.isNull(txtNominalTambahan.Text, 0));

            int rowGV = 0;
            Double sumIden = 0;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                sumIden = sumIden + Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
            }

            // tambahan sum iden dari nominaltambahan
            sumIden = sumIden + nominalTambahan;
            ntbNominalIden.Text = sumIden.ToString();
            refreshPembulatan();
        }

        private void cboModelBayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboModelBayar.SelectedIndex == 0) 
            {
                // hanya titipan
                cboPembulatan.Enabled = false;
                cboPembulatan.SelectedIndex = 0;
                txtNominalTambahan.Text = "0";
                txtNominalTambahan.Enabled = false;
                txtNominalTambahan.ReadOnly = true;
                modeBayar = 0;
            }
            else if(cboModelBayar.SelectedIndex == 1) 
            {
                // titipan +  Tunai 
                cboPembulatan.Enabled = true;
                cboPembulatan.SelectedIndex = 0;
                txtNominalTambahan.Text = "0";
                txtNominalTambahan.Enabled = true;
                txtNominalTambahan.ReadOnly = false;
                modeBayar = 1;
            }
            nominalTambahan = 0;
            int rowGV = 0;
            Double sumIden = 0;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                sumIden = sumIden + Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
            }

            // tambahan sum iden dari nominaltambahan
            sumIden = sumIden + nominalTambahan;
            ntbNominalIden.Text = sumIden.ToString();
        }

        private void txtNominalTambahan_Leave(object sender, EventArgs e)
        {
            nominalTambahan = Convert.ToDouble(txtNominalTambahan.Text);
            int rowGV = 0;
            Double sumIden = 0;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                sumIden = sumIden + Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
            }

            // tambahan sum iden dari nominaltambahan
            sumIden = sumIden + nominalTambahan;
            ntbNominalIden.Text = sumIden.ToString();
        }

        private void gvIdentifkasi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboPembulatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPembulatan();
        }

        private void refreshPembulatan()
        {
            if (cboModelBayar.SelectedIndex == 0) // berarti titipan murni
            {
                // kalo titipan ngga ada nominal pembulatan
                txtNominalPembulatan.Text = "0"; // pembulatannya 0
                txtNominalPembayaranPBL.Text = "0"; // berarti ngga ada tambahan tunai , '0'
            }
            else // selain itu mestinya hanya yg titipan + tunai
            {
                // index 0 -> 100, 1 -> 500, 2 -> 1000
                if (cboPembulatan.SelectedIndex >= 0 && cboPembulatan.SelectedIndex <= 2)
                {
                    Double Value = Convert.ToDouble(Tools.isNull(txtNominalTambahan.Text, 0));
                    Double PBLValue = Tools.RoundUp(Value, int.Parse(cboPembulatan.Text.ToString()));
                    txtNominalPembulatan.Text = (PBLValue - Value).ToString();
                    txtNominalPembayaranPBL.Text = PBLValue.ToString();
                }
            }
        }

    }
}
