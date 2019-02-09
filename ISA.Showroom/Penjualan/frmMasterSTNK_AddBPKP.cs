using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Penjualan
{
    public partial class frmMasterSTNK_AddBPKP : ISA.Controls.BaseForm
    {
        Guid MasterSTNKRowID;
        Guid PembelianRowID;
        Guid PenjualanRowID;
        Guid CustomerRowID;

        public frmMasterSTNK_AddBPKP()
        {
            InitializeComponent();
        }

        public frmMasterSTNK_AddBPKP(Form _caller, DataTable dt)
        {
            InitializeComponent();
            this.Caller = _caller;

            MasterSTNKRowID = new Guid(dt.Rows[0]["RowID"].ToString());
            PenjualanRowID  = new Guid(dt.Rows[0]["PenjualanRowID"].ToString());
            PembelianRowID  = new Guid(dt.Rows[0]["PembelianRowID"].ToString());
            CustomerRowID   = new Guid(dt.Rows[0]["CustomerRowID"].ToString());

            txt_TglLunasBBN.DateValue   = Convert.ToDateTime(dt.Rows[0]["TglLunasBBN"].ToString());
            txt_NoSTNK.Text             = dt.Rows[0]["NoSTNK"].ToString();
            txt_NoRegistrasi.Text       = dt.Rows[0]["NoRegistrasi"].ToString();
            txt_NamaSTNK.Text           = dt.Rows[0]["NamaSTNK"].ToString();
            txt_AlamatSTNK.Text         = dt.Rows[0]["Alamat"].ToString();
            txt_NoRangka.Text           = dt.Rows[0]["NoRangka"].ToString();
            txt_NoMesin.Text            = dt.Rows[0]["NoMesin"].ToString();
            txt_Warna.Text              = dt.Rows[0]["Warna"].ToString();

            txt_TglTerimaBPKB.DateValue = GlobalVar.GetServerDate.Date;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_NoBPKB.Text == "")
                {
                    MessageBox.Show("No BPKB belum diisi");
                    return;
                }
                using (Database db = new Database(GlobalVar.DBFinanceOto))
                {
                    db.Commands.Add(db.CreateCommand("usp_MasterSTNK_UpdateBPKP"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, MasterSTNKRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTerimaBPKB", SqlDbType.DateTime, txt_TglTerimaBPKB.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBPKB", SqlDbType.VarChar, txt_NoBPKB.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil diproses");
                if (this.Caller is frmMasterSTNK)
                {
                    frmMasterSTNK frmCaller = (frmMasterSTNK)this.Caller;
                    frmCaller.RefreshData(MasterSTNKRowID);
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
