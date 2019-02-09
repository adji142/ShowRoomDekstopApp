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
    public partial class frmPengajuanBBNHeader : ISA.Controls.BaseForm
    {
        Guid _HeaderID;
        public frmPengajuanBBNHeader()
        {
            InitializeComponent();
        }

        public frmPengajuanBBNHeader(Form Caller)
        {
            InitializeComponent();
            this.Caller = Caller;
        }

        private void frmPengajuanBBNHeader_Load(object sender, EventArgs e)
        {
            txtTanggal.DateValue = GlobalVar.GetServerDate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _HeaderID = Guid.NewGuid();
                string _NoBukti = ""; ;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_IdenPengajuanBBN"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, txtTanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, _NoBukti));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                this.closeForm();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPengajuanBBN)
                {
                    frmPengajuanBBN ifrmcaller = (frmPengajuanBBN)this.Caller;
                    ifrmcaller.RefreshHeader(_HeaderID);
                }
            }
            this.Close();
        }
    }
}
