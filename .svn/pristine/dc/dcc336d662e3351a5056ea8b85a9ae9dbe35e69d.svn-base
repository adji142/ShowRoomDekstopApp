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
    public partial class frmPerkiraanBrowse : ISA.Controls.BaseForm
    {
        public frmPerkiraanBrowse()
        {
            InitializeComponent();
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerkiraanBrowse_Load(object sender, EventArgs e)
        {
            customGridView1.ReadOnly = true;            
            RefreshData();
            /*if (GlobalVar.PerusahaanID != "HLD")
            {
                cmdAdd.Enabled = false;
                cmd.Enabled = false;
                cmdDelete.Enabled = false;
                button1.Enabled = false;
            }*/
        }

        public void RefreshData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "NoPerkiraan";
                customGridView1.DataSource = dt.DefaultView;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshRowData(string rowID)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBHoldingName))
            {
                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                customGridView1.RefreshDataRow(dtRefresh.Rows[0], "NoPerkiraan", rowID);                
            }
        }

        public void FindRow(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanUpdate ifrmChild = new GL.frmPerkiraanUpdate(this);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
            if (ifrmChild.DialogResult==DialogResult.OK) RefreshData();
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            Guid RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            GL.frmPerkiraanUpdate ifrmChild = new GL.frmPerkiraanUpdate(this,RowID);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
            if (ifrmChild.DialogResult == DialogResult.OK) RefreshData();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {

   
            if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    string rowID = customGridView1.SelectedCells[0].OwningRow.Cells["colNoPerkiraan"].Value.ToString();
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                DataRowView dv = (DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NoPerk = customGridView1.SelectedCells[0].OwningRow.Cells["colNoPerkiraan"].Value.ToString();
            if (NoPerk.Trim().Length == 11)
            {
                GL.Master.frmPerkiraanCabangOnly ifrmChild = new GL.Master.frmPerkiraanCabangOnly(NoPerk);
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.ShowDialog();
            }
            else MessageBox.Show("Registrasi cabang pengguna hanya dapat diberlakukan pada perkiraan level 5 saja!", "Perhatian!");
        }
    }
}
