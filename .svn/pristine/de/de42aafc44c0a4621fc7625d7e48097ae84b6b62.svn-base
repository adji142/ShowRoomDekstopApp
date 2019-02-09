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
    public partial class frmUMBungaKeterangan : ISA.Controls.BaseForm
    {
        Guid _penerimaanUMRowID = Guid.Empty;
        Guid _penjRowID = Guid.Empty;
        Guid _custRowID = Guid.Empty;
        Guid _rowID = Guid.Empty;
        String _namaCustomer = String.Empty;
        String _uraian = String.Empty;

        public frmUMBungaKeterangan()
        {
            InitializeComponent();
        }

        public frmUMBungaKeterangan(Form caller, Guid PenerimaanUMRowID, Guid PenjRowID, Guid RowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _penjRowID = PenjRowID;
            _penerimaanUMRowID = PenerimaanUMRowID;
            _rowID = RowID;
        }

        private void frmUMBungaKeterangan_Load(object sender, EventArgs e)
        {
            // ambil data dari database dulu
            DataTable dummy = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanUMBunga_DETAIL_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _penerimaanUMRowID));
                dummy = db.Commands[0].ExecuteDataTable();
            }
            if (dummy.Rows.Count > 0)
            {
                lblUMBunga.Text = dummy.Rows[0]["Nominal"].ToString();
                lblMataUang.Text = dummy.Rows[0]["MataUangIDSrc"].ToString();
                lblNoTrans.Text = dummy.Rows[0]["NoTrans"].ToString();
                lblTglTrans.Text = dummy.Rows[0]["TanggalTransaksi"].ToString();

                // ambil data keterangan UMBunganya, kalau ada
                DataTable dummy2 = new DataTable();
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanUM_GET_KeteranganUMBunga"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _penerimaanUMRowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dummy2 = dbsub.Commands[0].ExecuteDataTable();
                }
                if (dummy2.Rows.Count > 0)
                {
                    txtKeteranganUMBunga.Text = Tools.isNull(dummy2.Rows[0]["KeteranganUMBunga"], "").ToString();
                }
                else
                {
                    MessageBox.Show("Data keterangan UMBunga tidak dapat diambil!");
                }
            }
            else
            {
                MessageBox.Show("Data tidak dapat diambil!");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateSave()
        {
            bool result = true;
            String tempError = String.Empty;

            /*
            if (txtKeteranganUMBunga.Text == "")
            {
            }
            */

            if (tempError != String.Empty || result == false)
            {
                MessageBox.Show(tempError);
            }
            return result;
        }

        private void updateKeteranganUMBunga(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_UPDATE_KeteranganUMBunga"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@PenerimaanUMRowID", SqlDbType.UniqueIdentifier, _penerimaanUMRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeteranganUMBunga.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            counterdb++;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(validateSave())
            {
                Database db = new Database();
                int counterdb = 0;

                try
                {
                    updateKeteranganUMBunga(ref db, ref counterdb);

                    db.BeginTransaction();
                    int looper = 0;
                    for (looper = 0; looper < counterdb; looper++)
                    {
                        db.Commands[looper].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                    MessageBox.Show("Data berhasil diproses!");
                    this.Close();
                }
                catch(Exception ex)
                {
                    db.RollbackTransaction();
                    MessageBox.Show("Terjadi Error : " + ex.Message);
                }
            }
            else
            {
            }
        }
    }
}
