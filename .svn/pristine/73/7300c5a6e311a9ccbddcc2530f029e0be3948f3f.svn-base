using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmPerkiraanKoneksiModulLainBrowse : ISA.Controls.BaseForm
    {
        string DuplikatCabang = "";
        public frmPerkiraanKoneksiModulLainBrowse()
        {
            InitializeComponent();
        }

        private void frmPerkiraanKoneksiModulLainBrowse_Load(object sender, EventArgs e)
        {
            lookupGudang1.GudangID = GlobalVar.Gudang;
            panel1.Visible = false;
            if (GlobalVar.PerusahaanID != "HLD") lookupGudang1.Enabled = false;
        }


        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (lookupGudang1.GudangID != "")
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBHoldingName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiDetail_LIST_NonKasir"));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, lookupGudang1.GudangID));                        
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    dt.DefaultView.Sort = "Mdl, KodeTrn, NoPerkiraan";
                    customGridView1.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmPerkiraanKoneksiModulLainBrowse_Shown(object sender, EventArgs e)
        {            
            RefreshData();
        }

        private void lookupGudang1_SelectData(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Guid RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["cRowID"].Value;
            string KodeTrans = customGridView1.SelectedCells[0].OwningRow.Cells["cKodeTrn"].Value.ToString();
            string Uraian = customGridView1.SelectedCells[0].OwningRow.Cells["cUraian"].Value.ToString();
            string NoPerkiraan = customGridView1.SelectedCells[0].OwningRow.Cells["cNoPerkiraan"].Value.ToString();
            GL.Master.frmPerkiraanKoneksiModulLainUpdate ifrmChild = new ISA.Showroom.Finance.GL.Master.frmPerkiraanKoneksiModulLainUpdate(RowID,KodeTrans,Uraian,NoPerkiraan,this);
            ifrmChild.MdiParent = this.MdiParent;
            ifrmChild.Show();
        }

        private void cmdREFRESH_Click(object sender, EventArgs e)
        {
            if (lookupGudang1.GudangID != "")
            {
                Boolean pst = lookupGudang1.GudangID.Substring(0,2) == "11";
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiModulLain_REFRESH"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, lookupGudang1.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@pst", SqlDbType.Bit, pst));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshData();
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            DuplikatCabang = lookupGudang2.GudangID.ToString();
            if (lookupGudang1.GudangID != "")
            {
                Boolean pst = lookupGudang1.GudangID.Substring(0, 2) == "11";
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PerkiraanKoneksiModulLain_REFRESH"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, lookupGudang1.GudangID));
                    if (DuplikatCabang != "" && DuplikatCabang != "[Code]") db.Commands[0].Parameters.Add(new Parameter("@DuplikatCabang", SqlDbType.VarChar, DuplikatCabang));
                    db.Commands[0].Parameters.Add(new Parameter("@pst", SqlDbType.Bit, pst));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshData();
            }
            panel1.Visible = false;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            lookupGudang2.Focus();
        }
    }
}
