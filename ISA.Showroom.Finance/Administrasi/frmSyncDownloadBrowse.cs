﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Showroom.Finance.Administrasi
{
    public partial class frmSyncDownloadBrowse : BaseForm
    {
        public frmSyncDownloadBrowse()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_SyncDownload_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rgbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rgbTgl.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangPengirim", SqlDbType.VarChar , txtKode.Text ));
                    
                    dt = db.Commands[0].ExecuteDataTable();
                    dgv.DataSource = dt;
                 }
              }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmSyncDownloadBrowse_Load(object sender, EventArgs e)
        {
            rgbTgl.FromDate = new DateTime(GlobalVar.GetServerDate.Year, GlobalVar.GetServerDate.Month, 1);
            rgbTgl.ToDate = GlobalVar.GetServerDate;
        } 
        
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            Guid rowID = (Guid)dgv.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Administrasi.frmSyncDownloadDetailBrowse  ifrmChild = new Administrasi.frmSyncDownloadDetailBrowse (this, rowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        
        
    }
}
