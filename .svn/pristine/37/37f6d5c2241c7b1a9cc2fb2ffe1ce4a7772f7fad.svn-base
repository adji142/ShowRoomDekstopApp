using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace ISA.Showroom.Controls
{
    public partial class frmLookUpCustomerALL : ISA.Controls.BaseForm
    {
        DataTable _dtCari = new DataTable();
        public Class.clsCostumer Customer { get; set; }

        #region Konstruktor
        public frmLookUpCustomerALL()
        {
            InitializeComponent();
        }

        public frmLookUpCustomerALL(DataTable dt)
        {
            if (dt != null) _dtCari = dt;            
            InitializeComponent();
        }
        #endregion

        #region Events
        private void frmLookUpCustomerALL_Load(object sender, EventArgs e)
        {
            Customer = new Class.clsCostumer();
            cboFilterNameInitial.Text = "TOP 200";
            RefreshGrid();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DBGetList();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gvSearch.SelectedCells.Count > 0))
                {
                    DataRow dr = (DataRow)(gvSearch.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                    Customer.SetFromDataRow(dr);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        #region UDF
        void RefreshGrid()
        {
            try
            {
                DataColumn cConcatenated1 = new DataColumn("conAlamat", Type.GetType("System.String"), "AlamatIdt + ' RT/RW ' + RTIdt + '/' + RWIdt + ' Kel. ' + KelurahanIdt + ' Kec. ' + KecamatanIdt + ' ' + KotaIdt + ' ' + ProvinsiIdt");
                _dtCari.Columns.Add(cConcatenated1);
                gvSearch.DataSource = _dtCari;
                gvSearch.Focus();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        void DBGetList()
        {
            try
            {
                _dtCari = Class.clsCostumer.DBSearchALL(txtSearch.Text.Trim(), cboFilterNameInitial.Text);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        #endregion

        private void gvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((gvSearch.SelectedRows.Count > 0))
                {
                    if (e.KeyCode == Keys.Enter && gvSearch.SelectedRows.Count == 1)
                    {
                        DataRow dr = (DataRow)(gvSearch.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                        Customer.SetFromDataRow(dr);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void gvSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((gvSearch.SelectedCells.Count > 0))
                {
                    DataRow dr = (DataRow)(gvSearch.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row;
                    Customer.SetFromDataRow(dr);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        /*
        private void gvSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvSearch.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in gvSearch.Rows)
                {
                    foreach (DataGridViewCell iCell in iRow.Cells)
                    {
                        if (iRow.Index % 2 == 0)
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 128);
                        }
                        else
                        {
                            iCell.Style.BackColor = Color.FromArgb(255, 255, 255);
                        }
                    }
                }
            }
        }
        */
    }
}
