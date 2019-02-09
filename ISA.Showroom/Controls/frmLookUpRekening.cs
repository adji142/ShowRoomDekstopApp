using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL; 

namespace ISA.Showroom.Controls
{
    public partial class frmLookUpRekening : ISA.Controls.BaseForm
    {

        DataTable _dtCari = new DataTable(); 
        public System.Guid _rekeningRowID;
        public string _noRekening;
        public string _noPerkiraanRekening;
        public string _namaRekening; 

        public frmLookUpRekening()
        {
            InitializeComponent();
        }

        public frmLookUpRekening(DataTable dt)
        {
            if (dt != null) _dtCari = dt;
            InitializeComponent();
        }

        private void frmLookUpRekening_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void gvRek_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvRek.SelectedCells.Count == 1) ConfirmSelect();
        }

        private void gvRek_DoubleClick(object sender, EventArgs e)
        {
            if (gvRek.SelectedCells.Count == 1) ConfirmSelect();
        }

        private void gvRek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gvRek.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();
            }
        }


        private void ConfirmSelect()
        {
            if (gvRek.SelectedCells.Count == 1)
            {

                _rekeningRowID = new System.Guid(gvRek.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                _noRekening = gvRek.SelectedCells[0].OwningRow.Cells["NoRekening"].Value.ToString();
                _noPerkiraanRekening = gvRek.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                _namaRekening = gvRek.SelectedCells[0].OwningRow.Cells["NamaRekening"].Value.ToString();

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public void RefreshData()
        {
            using (Database db = new Database(GlobalVar.DBFinanceOto))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_Rekening_SEARCH"));                
                dt = db.Commands[0].ExecuteDataTable();
                gvRek.DataSource = dt.DefaultView;
            }
        }

        void RefreshGrid()
        {
            try
            {
                gvRek.DataSource = _dtCari;
                gvRek.Focus();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void gvRek_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gvRek.SelectedCells.Count > 0))
                {
                    ConfirmSelect();                    
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        

        


    }
}
