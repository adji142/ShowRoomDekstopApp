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
    public partial class frmPerkiraanCabangOnly : ISA.Controls.BaseForm
    {
        string _NoPerk;
        public frmPerkiraanCabangOnly()
        {
            InitializeComponent();
        }

        public frmPerkiraanCabangOnly(string NoPerk)
        {
            InitializeComponent();
            _NoPerk = NoPerk;
        }

        private void frmPerkiraanCabangOnly_Load(object sender, EventArgs e)
        {
            DataTable dtCbg = new DataTable();
            DataTable dtData = new DataTable();
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                dtCbg = db.Commands[0].ExecuteDataTable();
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_PerkiraanCabangOnly_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerk));
                dtData = db.Commands[0].ExecuteDataTable();
                foreach (DataRow drCbg in dtCbg.Rows)
                {
                    bool lOk = false;
                    foreach (DataRow drData in dtData.Rows)
                    {
                        if (drData["CabangID"].ToString() == drCbg["CabangID"].ToString()) lOk = true;
                    }
                    clistCabang.Items.Add(drCbg["CabangID"].ToString(), lOk);
                    clistCabang_SelectedIndexChanged(sender, e);
                }
            }

        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_PerkiraanCabangOnly_DELETE"));
                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerk));
                db.Commands[0].ExecuteNonQuery();
                CheckedListBox.CheckedItemCollection clCek = clistCabang.CheckedItems;
                foreach (object item in clCek)
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanCabangOnly_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, _NoPerk));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, item.ToString()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            this.Close();
        }

        private void clistCabang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cList = "";
            int nList = 0;
            CheckedListBox.CheckedItemCollection clCek = clistCabang.CheckedItems;
            foreach (object item in clCek)
            {
                nList = nList + 1;
                if (nList > 1) cList = cList + ", ";
                cList = cList + item.ToString();
            }
            textCabang.Text = cList;
        }
    }
}
