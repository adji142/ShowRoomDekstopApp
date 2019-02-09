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
    public partial class frmPerkiraanKoneksiModulLainUpdate : ISA.Controls.BaseForm
    {
        Guid _RowID;
        public frmPerkiraanKoneksiModulLainUpdate()
        {
            InitializeComponent();
        }
        public frmPerkiraanKoneksiModulLainUpdate(Guid RowID,string KodeTrans,string Uraian, string NoPerkiraan,Form Caller)
        {
            InitializeComponent();
            textKodeTrans.Text = KodeTrans;
            textUraian.Text = Uraian;
            lookUpPerkiraan1.NoPerkiraan = NoPerkiraan;
            _RowID = RowID;
            this.Caller = Caller;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            string NoPerkiraan = lookUpPerkiraan1.NoPerkiraan;
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiModulLain_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerkiraan));
                db.Commands[0].ExecuteNonQuery();
            }
            frmPerkiraanKoneksiModulLainBrowse ifrm = (frmPerkiraanKoneksiModulLainBrowse)this.Caller;
            ifrm.RefreshData();
            this.Close();
        }

        private void textNoPerkiraan_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
