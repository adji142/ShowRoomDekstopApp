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
    public partial class frmAdministrasiIden : ISA.Controls.BaseForm
    {
        List<AdministrasiIden> _listAdministrasiIden;
        AdministrasiDetail AdministrasiDetailAkanDiIden;
        DataTable dtTitipanDataDiiden = new DataTable();

        public frmAdministrasiIden()
        {
            InitializeComponent();
        }

        public frmAdministrasiIden(Form caller, AdministrasiDetail pAdministrasiDetail, List<AdministrasiIden> pListAdministrasiIden)
        {
            InitializeComponent();
            this.Caller = caller; 
            gvIdentifkasi.AutoGenerateColumns = false;
            _listAdministrasiIden = pListAdministrasiIden;
            AdministrasiDetailAkanDiIden = pAdministrasiDetail;
        }

        //Penjualan.frmAdministrasiIden ifrmChild = new Penjualan.frmAdministrasiIden(this, _penjHistID, _penjRowID);

        private void frmAdministrasiIden_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }

        private void BindData()
        {
            txtCustomerNama.Text = AdministrasiDetailAkanDiIden.CustomerName.ToString();
            txtPembayaran.Text = AdministrasiDetailAkanDiIden.NominalPembayaran.ToString();
            txtMataUangID.Text = AdministrasiDetailAkanDiIden.MataUangID.ToString();
            
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_titipandapatdiiden"));
                    db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, AdministrasiDetailAkanDiIden.CustomerRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, AdministrasiDetailAkanDiIden.MataUangID));
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
            if (Convert.ToDouble(ntbNominalIden.Text) != Convert.ToDouble(txtPembayaran.Text))
            {
                MessageBox.Show("Nominal yang Identifikasi harus sama dengan nominal administrasi yang sudah di tetapkan");
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

        private void SimpanDraftIdentifikasi()
        {
            int rowGV = 0;
            double sumIden = 0;
            AdministrasiIden nAdministrasiIden;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0)) > 0)
                {
                    nAdministrasiIden = new AdministrasiIden();
                    nAdministrasiIden.TitipanRowID = new Guid(gvIdentifkasi.Rows[rowGV].Cells["TitipanRowID"].Value.ToString());
                    nAdministrasiIden.NominalIden = Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
                    _listAdministrasiIden.Add(nAdministrasiIden);
                }
            }
            AdministrasiDetailAkanDiIden.TotalNominalIden = Convert.ToDouble(ntbNominalIden.Text);
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


        private void frmAdministrasiIden_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmAdministrasiUpdate)
            {
                Penjualan.frmAdministrasiUpdate frmCaller = (Penjualan.frmAdministrasiUpdate)this.Caller;
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
