using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.GL.Master
{
    public partial class frmPerkiraanKoneksiArusKasHeaderUpdate : ISA.Controls.BaseForm
    {
        Guid _RowID;
        string _Modus,_Kode;
        public frmPerkiraanKoneksiArusKasHeaderUpdate()
        {
            InitializeComponent();
        }

        public frmPerkiraanKoneksiArusKasHeaderUpdate(string Kode, Form Caller)
        {
            InitializeComponent();
            _Modus = "Tambah";
            _Kode = Kode;
            this.Caller = Caller;
        }

        public frmPerkiraanKoneksiArusKasHeaderUpdate(Guid RowID, string Uraian, Form Caller)
        {
            InitializeComponent();
            textUraian.Text = Uraian;
            _RowID = RowID;
            _Modus = "Edit";
            this.Caller = Caller;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (_Modus == "Edit")
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiKas_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, textUraian.Text.ToString()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            else
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiKas_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, textUraian.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, _Kode));
                    db.Commands[0].Parameters.Add(new Parameter("@UserInit", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPrs", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            frmPerkiraanKoneksiArusKasBrowse ifrm = (frmPerkiraanKoneksiArusKasBrowse)this.Caller;
            ifrm.RefreshHeader();
            this.Close();
        }
    }
}
