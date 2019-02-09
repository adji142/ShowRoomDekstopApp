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
    public partial class frmDendaKeterangan : ISA.Controls.BaseForm
    {
        Guid _srcRowID = Guid.Empty;
        Guid _penjRowID = Guid.Empty;
        Guid _custRowID = Guid.Empty;
        Guid _penjHistRowID = Guid.Empty;
        String _namaCustomer = String.Empty;
        String _src = String.Empty;
        String _uraian = String.Empty;
        Guid PenerimaanDendaNewRowID = Guid.NewGuid();

        public frmDendaKeterangan()
        {
            InitializeComponent();
        }

        public frmDendaKeterangan(Form caller, Guid SrcRowID, Guid PenjRowID, String Src, Guid PenjHistRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _srcRowID = SrcRowID;
            _penjRowID = PenjRowID;
            _src = Src;
            _penjHistRowID = PenjHistRowID;
        }

        private void frmDendaKeterangan_Load(object sender, EventArgs e)
        {
            // ambil data dari database dulu
            DataTable dummy = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanDenda_DETAIL_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                db.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _srcRowID));
                db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, _src));
                dummy = db.Commands[0].ExecuteDataTable();
            }
            if (dummy.Rows.Count > 0)
            {
                lblDenda.Text = dummy.Rows[0]["Nominal"].ToString();
                lblMataUang.Text = dummy.Rows[0]["MataUangIDSrc"].ToString();
                lblNoTrans.Text = dummy.Rows[0]["NoTrans"].ToString();
                lblSrc.Text = dummy.Rows[0]["SrcDenda"].ToString();
                lblTglTrans.Text = dummy.Rows[0]["TanggalTransaksi"].ToString();

                // ambil data keterangan dendanya, kalau ada
                DataTable dummy2 = new DataTable();
                using (Database dbsub = new Database())
                {
                    dbsub.Commands.Add(dbsub.CreateCommand("usp_PenerimaanANG_UM_GET_KeteranganDenda"));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _srcRowID));
                    dbsub.Commands[0].Parameters.Add(new Parameter("@SrcDenda", SqlDbType.VarChar, _src));
                    dummy2 = dbsub.Commands[0].ExecuteDataTable();
                }
                if (dummy2.Rows.Count > 0)
                {
                    txtKeteranganDenda.Text = Tools.isNull(dummy2.Rows[0]["KeteranganDenda"], "").ToString();
                }
                else
                {
                    MessageBox.Show("Data keterangan denda tidak dapat diambil!");
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
            if (txtKeteranganDenda.Text == "")
            {
            }
            */

            if (tempError != String.Empty || result == false)
            {
                MessageBox.Show(tempError);
            }
            return result;
        }

        private void updateKeteranganDenda(ref Database db, ref int counterdb)
        {
            db.Commands.Add(db.CreateCommand("usp_PenerimaanANG_UM_UPDATE_KeteranganDenda"));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcRowID", SqlDbType.UniqueIdentifier, _srcRowID));
            db.Commands[counterdb].Parameters.Add(new Parameter("@SrcDenda", SqlDbType.VarChar, _src));
            db.Commands[counterdb].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeteranganDenda.Text));
            db.Commands[counterdb].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
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
                    updateKeteranganDenda(ref db, ref counterdb);

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
