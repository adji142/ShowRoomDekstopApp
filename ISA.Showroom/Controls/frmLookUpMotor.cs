﻿using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace ISA.Showroom.Controls
{
    public partial class frmLookUpMotor : ISA.Controls.BaseForm
    {
        DataTable _dtCari = new DataTable();
        public Class.clsMotor Motor { get; set; }
        bool pusat = false;

        #region Konstruktor
        public frmLookUpMotor()
        {
            InitializeComponent();
        }

        public frmLookUpMotor(DataTable dt)
        {
            if (dt != null) _dtCari = dt;
            InitializeComponent();
        }
        #endregion

        #region Events
        private void frmLookUpMotor_Load(object sender, EventArgs e)
        {
            Motor = new Class.clsMotor();
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
                    Motor.SetFromDataRow(dr);
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
                _dtCari = Class.clsMotor.DBSearch(txtSearch.Text.Trim());
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
                        Motor.SetFromDataRow(dr);
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
                    Motor.SetFromDataRow(dr);
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
