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
    public partial class frmUangMukaIden : ISA.Controls.BaseForm
    {
        List<UangMukaIden> _listUangMukaIden;
        UangMukaDetail UangMukaDetailAkanDiIden;
        DataTable dtTitipanDataDiiden = new DataTable();
        String _KodeTrans = ""; // isinya bisa -> UMK , UMT , TRK

        public frmUangMukaIden()
        {
            InitializeComponent();
        }

        public frmUangMukaIden(Form caller, UangMukaDetail pUangMukaDetail, List<UangMukaIden> pListUangMukaIden, String kodeTrans)
        {
            InitializeComponent();
            this.Caller = caller; 
            gvIdentifkasi.AutoGenerateColumns = false;
            _listUangMukaIden = pListUangMukaIden;
            UangMukaDetailAkanDiIden = pUangMukaDetail;
            _KodeTrans = kodeTrans;
        }

        //Penjualan.frmUangMukaIden ifrmChild = new Penjualan.frmUangMukaIden(this, _penjHistID, _penjRowID);

        private void frmUangMukaIden_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }

        private void BindData()
        {
            txtCustomerNama.Text = UangMukaDetailAkanDiIden.CustomerName.ToString();
            txtPembayaran.Text = UangMukaDetailAkanDiIden.NominalPembayaran.ToString();
            txtMataUangID.Text = UangMukaDetailAkanDiIden.MataUangID.ToString();
            txtUMBunga.Text = UangMukaDetailAkanDiIden.UMBunga.ToString();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_titipandapatdiiden"));
                    db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, UangMukaDetailAkanDiIden.CustomerRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, UangMukaDetailAkanDiIden.MataUangID));
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
            // Kalau UMT, itu ngga ditetapkan jumlahnya, jadinya bebas
            if ((Convert.ToDouble(ntbNominalIden.Text) != (Convert.ToDouble(txtPembayaran.Text) + UangMukaDetailAkanDiIden.UMBunga)) // + UangMukaDetailAkanDiIden.UMBunga
                 && _KodeTrans != "UMT" // selain UMT harus sesuai yg ditetapkan
               )
            {
                MessageBox.Show("Nominal yang Identifikasi harus sama dengan nominal Uang Muka (+ UMBunga jika dibayarkan) yang sudah di tetapkan");
            }
            else
            {
                //simpan ke list<> 
                SimpanDraftIdentifikasi();
                this.Close();
            }
        }

        private void txtPembayaran_TextChanged(object sender, EventArgs e)
        {
        }


        private void gvIdentifkasi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string NamaKolom = gvIdentifkasi.Columns[e.ColumnIndex].Name.ToString().ToUpper();
            DataRow drIden = (DataRow)(gvIdentifkasi.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            
            if (NamaKolom.ToLower() == "nominaliden")
            {
                if (Convert.ToDouble(Tools.isNull(drIden["nominaliden"], 0)) >= 1)
                {
                    if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominaliden"].Value, 0)) > Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[e.RowIndex].Cells["nominalsisa"].Value, 0)))
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

        private void SimpanDraftIdentifikasi()
        {
            int rowGV = 0;
            double sumIden = 0;
            UangMukaIden nUangMukaIden;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0)) > 0)
                {
                    nUangMukaIden = new UangMukaIden();
                    nUangMukaIden.TitipanRowID = new Guid(gvIdentifkasi.Rows[rowGV].Cells["TitipanRowID"].Value.ToString());
                    nUangMukaIden.NominalIden = Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
                    nUangMukaIden.BentukPembayaran = gvIdentifkasi.Rows[rowGV].Cells["BentukPembayaran"].Value.ToString();
                    _listUangMukaIden.Add(nUangMukaIden);
                }
            }
            UangMukaDetailAkanDiIden.TotalNominalIden = Convert.ToDouble(ntbNominalIden.Text);
            UangMukaDetailAkanDiIden.BentukPembayaran = "???"; ///--////
        }

        private void frmUangMukaIden_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmUangMukaUpdate)
            {
                Penjualan.frmUangMukaUpdate frmCaller = (Penjualan.frmUangMukaUpdate)this.Caller;
                frmCaller.RefreshControlsTitipan();
            }
        }

        private void gvIdentifkasi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gvIdentifkasi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.ToString());
            }
        }
    }
}
