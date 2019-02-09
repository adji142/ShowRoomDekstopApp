using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmPerkiraanKoneksiArusKasUpdate : ISA.Controls.BaseForm
    {
        Guid _RowID, _HeaderID;
        enum enumModus { New, Update };
        enumModus Modus;

        public frmPerkiraanKoneksiArusKasUpdate(Guid HeaderID, Form Caller)
        {
            InitializeComponent();
            _HeaderID = HeaderID;
            this.Caller = Caller;
            if (GlobalVar.PerusahaanID != "HLD")
            {
                lookUpPerkiraan1.Enabled = false;
            }
            Modus = enumModus.New;
        }
        public frmPerkiraanKoneksiArusKasUpdate(string noPerkiraan, string keterangan, Guid RowID, Form Caller)
        {
            InitializeComponent();
            lookUpPerkiraan1.NoPerkiraan = noPerkiraan;
            txtKeterangan.Text = keterangan;
            _RowID = RowID;
            this.Caller = Caller;
            if (GlobalVar.PerusahaanID != "HLD")
            {
                lookUpPerkiraan1.Enabled = false;
            }
            Modus = enumModus.Update;
        }
        private void frmPerkiraanKoneksiArusKasUpdate_Load(object sender, EventArgs e)
        {
            txtKeterangan.CharacterCasing = CharacterCasing.Normal;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_UPDATE"));
                if (Modus == enumModus.Update) db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                else db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, lookUpPerkiraan1.NoPerkiraan));
                db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtKeterangan.Text));
                db.Commands[0].ExecuteNonQuery();
            }
            frmPerkiraanKoneksiArusKasBrowse ifrm = (frmPerkiraanKoneksiArusKasBrowse)this.Caller;
            ifrm.RefreshDetail();
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
