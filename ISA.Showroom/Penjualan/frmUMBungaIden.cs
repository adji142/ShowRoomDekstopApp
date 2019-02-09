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
    public partial class frmUMBungaIden : ISA.Controls.BaseForm
    {
        List<UMBungaIden> _listUMBungaIden;
        UMBungaDetail UMBungaDetailAkanDiIden;
        DataTable dtTitipanDataDiiden = new DataTable();
        public Double nominalIden = 0;

        public frmUMBungaIden()
        {
            InitializeComponent();
        }

        public frmUMBungaIden(Form caller, UMBungaDetail pUMBungaDetail, List<UMBungaIden> pListUMBungaIden)
        {
            InitializeComponent();
            this.Caller = caller; 
            gvIdentifkasi.AutoGenerateColumns = false;
            _listUMBungaIden = pListUMBungaIden;
            UMBungaDetailAkanDiIden = pUMBungaDetail;
        }

        private void BindData()
        {
            txtCustomerNama.Text = UMBungaDetailAkanDiIden.CustomerName.ToString();
            txtPembayaran.Text = UMBungaDetailAkanDiIden.NominalPembayaran.ToString();
            txtMataUangID.Text = UMBungaDetailAkanDiIden.MataUangID.ToString();
            txtpotongan.Text = UMBungaDetailAkanDiIden.Potongan.ToString();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_titipandapatdiiden"));
                    db.Commands[0].Parameters.Add(new Parameter("@CustomerRowID", SqlDbType.UniqueIdentifier, UMBungaDetailAkanDiIden.CustomerRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, UMBungaDetailAkanDiIden.MataUangID));
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
            catch (Exception ex)
            {
                Error.LogError(ex, "Gagal menampilkan daftar titipan yang dapat diInden");
            }
            //usp_titipandapatdiiden
        }

        private void InitControl()
        {
        }

        private void frmUMBungaIden_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(ntbNominalIden.Text) != (Convert.ToDouble(txtPembayaran.Text) - Convert.ToDouble(txtpotongan.Text)))
            {
                if (MessageBox.Show(Messages.Question.AskSave, "Nominal yang Identifikasi tidak sama dengan nominal UMBunga yang sudah di tetapkan!\nYakin lanjut melakukan penyimpanan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //simpan ke list<> 
                    SimpanDraftIdentifikasi();
                    this.Close();
                }
            }
            else
            {
                //simpan ke list<> 
                SimpanDraftIdentifikasi();
                this.Close();
            }
        }

        private void SimpanDraftIdentifikasi()
        {
            int rowGV = 0;
            double sumIden = 0;
            UMBungaIden nUMBungaIden;
            for (rowGV = 0; rowGV < gvIdentifkasi.Rows.Count; rowGV++)
            {
                if (Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0)) > 0)
                {
                    nUMBungaIden = new UMBungaIden();
                    nUMBungaIden.TitipanRowID = new Guid(gvIdentifkasi.Rows[rowGV].Cells["TitipanRowID"].Value.ToString());
                    nUMBungaIden.NominalIden = Convert.ToDouble(Tools.isNull(gvIdentifkasi.Rows[rowGV].Cells["nominaliden"].Value, 0));
                    nUMBungaIden.BentukPembayaran = gvIdentifkasi.Rows[rowGV].Cells["BentukPembayaran"].Value.ToString();
                    _listUMBungaIden.Add(nUMBungaIden);
                }
            }
            UMBungaDetailAkanDiIden.TotalNominalIden = Convert.ToDouble(ntbNominalIden.Text);
            nominalIden = UMBungaDetailAkanDiIden.TotalNominalIden;
            UMBungaDetailAkanDiIden.BentukPembayaran = "???"; ///--////
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

        private void frmUMBungaIden_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmUMBungaIden_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmUMBungaUpdate)
            {
                Penjualan.frmUMBungaUpdate frmCaller = (Penjualan.frmUMBungaUpdate)this.Caller;
                frmCaller.RefreshControlsTitipan();
            }
        }


    }
}
