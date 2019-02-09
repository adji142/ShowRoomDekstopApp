using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmPenerimaanLeasingNonPJL : ISA.Controls.BaseForm
    {
        Guid RowIDH;

        public frmPenerimaanLeasingNonPJL()
        {
            InitializeComponent();
        }

        public frmPenerimaanLeasingNonPJL(Form _caller, DataTable dt)
        {
            InitializeComponent();
            this.Caller = _caller;

            RowIDH = new Guid(dt.Rows[0]["RowID"].ToString());
            txt_NoPembayaran.Text = dt.Rows[0]["NoBukti"].ToString();
            txt_Tanggal.DateValue = Convert.ToDateTime(dt.Rows[0]["Tanggal"].ToString());
            txt_Nominal.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["NominalTunai"],0)) + Convert.ToDouble(Tools.isNull(dt.Rows[0]["NominalTransfer"],0))).ToString();
            txt_Leasing.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["NomTerIden"],0))).ToString();
            txt_Saldo.Text = (Convert.ToDouble(Tools.isNull(dt.Rows[0]["Saldo"],0))).ToString();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenerimaanLeasingNonPJL_Load(object sender, EventArgs e)
        {
            RefreshData();
            GV_NonPNJ.ReadOnly = false;

            for (int a = 0; a < GV_NonPNJ.Columns.Count; a++)
            {
                GV_NonPNJ.Columns[a].ReadOnly = true;
            }
            GV_NonPNJ.Columns[4].ReadOnly = false;
        }

        private void RefreshData()
        {
            DataTable dt = new DataTable();
            //using (Database db = new Database())
            //{
            //    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingNonPenjualanBrowse"));
            //    db.Commands[0].Parameters.Add(new Parameter())
            //}
            dt.Columns.Add("NoBukti", typeof(String));
            dt.Columns.Add("TglIden", typeof(DateTime));
            dt.Columns.Add("JenisTransaksiRowID", typeof(Guid));
            dt.Columns.Add("JenisTransaksi", typeof(String));
            dt.Columns.Add("MataUangRowID", typeof(Guid));
            dt.Columns.Add("MataUang", typeof(String));
            dt.Columns.Add("NominalIden", typeof(Double));
            dt.Columns.Add("Uraian", typeof(String));

            String NoBukti = Numerator.GetNomorDokumen("LEASING_IDENNONPENJUALAN", "", "/LBK/" +
                                string.Format("{0:yyMM}", GlobalVar.GetServerDate.Date)
                                , 3, false, true);
            
            dt.Rows.Add( NoBukti, Convert.ToDateTime(GlobalVar.GetServerDate.Date.ToString()) ,"9657911C-8BD5-4F8B-87A6-0F8391B85502", "Penerimaan dari leasing",
                        "BC17A644-5DBD-4955-A803-378F8C0A915C", "IDR", 0, "Penerimaan Leasing Iden : " + txt_NoPembayaran.Text);

            GV_NonPNJ.DataSource = dt;

        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(GV_NonPNJ.SelectedCells[0].OwningRow.Cells["NominalIden"].Value.ToString()) > double.Parse(txt_Saldo.Text))
                {
                    MessageBox.Show("Nominal Iden tidak boleh melebihi sisa saldo.");
                    return;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasing_IdenNonPenjualan"));
                    db.Commands[0].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, RowIDH));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, GV_NonPNJ.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, Convert.ToDateTime(GV_NonPNJ.SelectedCells[0].OwningRow.Cells["TglIden"].Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@JenisTransaksiRowID", SqlDbType.UniqueIdentifier, new Guid(GV_NonPNJ.SelectedCells[0].OwningRow.Cells["JenisTransaksiRowID"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@MatauangRowID", SqlDbType.UniqueIdentifier, new Guid(GV_NonPNJ.SelectedCells[0].OwningRow.Cells["MataUangRowID"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, double.Parse(GV_NonPNJ.SelectedCells[0].OwningRow.Cells["NominalIden"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, GV_NonPNJ.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil dimasukkan");

                if (this.Caller is frmPenerimaanLeasingBrowse)
                {
                    frmPenerimaanLeasingBrowse frmCaller = (frmPenerimaanLeasingBrowse)this.Caller;
                    frmCaller.RefreshHeader(RowIDH);
                    frmCaller.RefreshDetailT2(Guid.Empty);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
