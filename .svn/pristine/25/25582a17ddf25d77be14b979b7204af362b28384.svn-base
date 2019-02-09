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
    public partial class frmJournalUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        //Guid _HeaderID;
        string _recID;

        DataTable dtRowHeader;
        DataTable dtRowDetail;

        public frmJournalUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = Guid.NewGuid();
            _recID = ISA.Common.Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            this.Caller = caller;
        }

        private void setCboCabang()
        {
            cboUnitUsaha.Items.Clear();
            Dictionary<string, string> dta = new Dictionary<string, string>();

            dta.Add("ALL", "ALL");
            dta.Add("HONDA", "HONDA");
            dta.Add("AVALIS", "AVALIS");
            dta.Add("AHASS", "AHASS");


            cboUnitUsaha.DataSource = new BindingSource(dta, null);
            cboUnitUsaha.DisplayMember = "Value";
            cboUnitUsaha.ValueMember = "Key";
        }
        public frmJournalUpdate(Form caller,string cabang)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = Guid.NewGuid();
            _recID = ISA.Common.Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            this.Caller = caller;
            setCboCabang();
            cboUnitUsaha.SelectedValue = cabang;
        }

        public frmJournalUpdate(Form caller, Guid rowID, string recID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _recID = recID;
            this.Caller = caller;
            setCboCabang();
        }

        public frmJournalUpdate(Form caller, Guid rowID, string recID, string cabang)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _recID = recID;
            this.Caller = caller;
            setCboCabang();
            cboUnitUsaha.SelectedValue = cabang;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable dtJournalDetail()
        {
            return dtRowDetail;
        }

        private void frmJournalUpdate_Load(object sender, EventArgs e)
        {
            this.Title = ""; 
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    dtRowHeader = Class.Journal.GetHeader_dv(db, _rowID, GlobalVar.PerusahaanRowID,cboUnitUsaha.SelectedValue.ToString());
                    dtRowDetail = Class.Journal.ListDetail_dv(db, _rowID, cboUnitUsaha.SelectedValue.ToString());
                }
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    if (dtRowHeader.Rows.Count > 0)
                    {

                        //display data
                        txtTanggal.Text = ((DateTime)dtRowHeader.Rows[0]["Tanggal"]).ToString("dd/MM/yyyy");
                        txtNoReff.Text = dtRowHeader.Rows[0]["NoReff"].ToString();
                        txtUraian.Text = dtRowHeader.Rows[0]["Uraian"].ToString();
                        lookupGudang1.GudangID = dtRowHeader.Rows[0]["KodeGudang"].ToString();
                        //Tambahan UnitUsaha
                        //if ((Tools.isNull(dtRowHeader.Rows[0]["UnitUsaha"], "").ToString()) != "")
                        //{
                        //    cboUnitUsaha.SelectedItem = dtRowHeader.Rows[0]["UnitUsaha"].ToString();
                        //}
                        
                        dtRowDetail.DefaultView.Sort = "RecordID";
                        customGridView1.DataSource = dtRowDetail.DefaultView;

                    }
                }
                else
                {
                    txtTanggal.Text = GlobalVar.GetServerDate.ToString("dd/MM/yyyy");                    
                    txtNoReff.Text = Numerator.BookNumerator("VJU");
                    lookupGudang1.GudangID = GlobalVar.Gudang;
                    dtRowDetail.DefaultView.Sort = "RecordID";
                    customGridView1.DataSource = dtRowDetail.DefaultView;
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (dtRowDetail.Rows.Count > 0 && txtSelisih.GetDoubleValue == 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database(GlobalVar.DBHoldingName))
                            {
                                db.BeginTransaction();
                                Class.Journal.AddHeader_ver_4_dv(db, GlobalVar.PerusahaanRowID, _rowID, _recID, (DateTime)txtTanggal.DateValue, txtNoReff.Text, txtUraian.Text, "GNR", lookupGudang1.GudangID, false, cboUnitUsaha.Text,cboUnitUsaha.SelectedValue.ToString());
                                foreach (DataRow drDetail in dtRowDetail.Rows)
                                {
                                    //Guid dJournalID = Guid.NewGuid();
                                    //string journalRecID = ISA.Common.Tools.CreateFingerPrint (GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                                    Class.Journal.AddDetail_dv(db, (Guid)drDetail["RowID"], (Guid)drDetail["HeaderID"], drDetail["RecordID"].ToString(), drDetail["HRecordID"].ToString(), drDetail["NoPerkiraan"].ToString(), drDetail["Uraian"].ToString(), double.Parse(drDetail["Debet"].ToString()), double.Parse(drDetail["Kredit"].ToString()), drDetail["DK"].ToString(), Guid.Empty, 0,cboUnitUsaha.SelectedValue.ToString());
                                }
                                db.CommitTransaction();
                                dtRowDetail.AcceptChanges();
                                formMode = enumFormMode.Update;
                            }
                            break;
                        case enumFormMode.Update:
                            using (Database db = new Database(GlobalVar.DBHoldingName))
                            {
                                db.BeginTransaction();
                                Class.Journal.UpdateHeader(db, _rowID, _recID, (DateTime)txtTanggal.DateValue, txtNoReff.Text, txtUraian.Text, "GNR", lookupGudang1.GudangID, false, cboUnitUsaha.Text,cboUnitUsaha.SelectedValue.ToString());

                                DataTable dtInsert, dtUpdate, dtDelete;
                                dtInsert = dtRowDetail.GetChanges(DataRowState.Added);
                                dtUpdate = dtRowDetail.GetChanges(DataRowState.Modified);
                                dtDelete = dtRowDetail.GetChanges(DataRowState.Deleted);

                                if (dtInsert != null)
                                    foreach (DataRow drDetail in dtInsert.Rows)
                                        Class.Journal.AddDetail_dv(db, (Guid)drDetail["RowID"], (Guid)drDetail["HeaderID"], drDetail["RecordID"].ToString(), drDetail["HRecordID"].ToString(), drDetail["NoPerkiraan"].ToString(), drDetail["Uraian"].ToString(), double.Parse(drDetail["Debet"].ToString()), double.Parse(drDetail["Kredit"].ToString()), drDetail["DK"].ToString(), Guid.Empty, 0,cboUnitUsaha.SelectedValue.ToString());
                                if (dtUpdate != null)
                                    foreach (DataRow drDetail in dtUpdate.Rows)
                                        Class.Journal.UpdateDetail_dv(db, (Guid)drDetail["RowID"], (Guid)drDetail["HeaderID"], drDetail["RecordID"].ToString(), drDetail["HRecordID"].ToString(), drDetail["NoPerkiraan"].ToString(), drDetail["Uraian"].ToString(), double.Parse(drDetail["Debet"].ToString()), double.Parse(drDetail["Kredit"].ToString()), drDetail["DK"].ToString(), Guid.Empty, 0,cboUnitUsaha.SelectedValue.ToString());
                                if (dtDelete != null)
                                    foreach (DataRow drDetail in dtDelete.Rows)
                                    {
                                        var rid = (Guid)drDetail["RowID", DataRowVersion.Original];
                                        Class.Journal.DeleteDetail_dv(db, rid, cboUnitUsaha.SelectedValue.ToString());
                                    }
                                db.CommitTransaction();
                                dtRowDetail.AcceptChanges();
                            }
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show(ISA.Common.Messages.Confirm.UpdateSuccess);
                    closeForm();
                    this.Close();
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
            else
            {
                MessageBox.Show("Debet-Kredit masih belum balance");
            }
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmJournalBrowse)
                {
                    frmJournalBrowse frmCaller = (frmJournalBrowse)this.Caller;
                    frmCaller.RefreshRowHeader(_rowID.ToString());
                    frmCaller.FindRow("hRowID", _rowID.ToString());
                }
            }
            //this.Close();
        }

        private void frmJournalUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            GL.frmJournalDetailUpdate ifrmChild = new GL.frmJournalDetailUpdate(_rowID,this);
            ifrmChild.Uraian = txtUraian.Text;
            if (Convert.ToDouble(txtSelisih.Text) > 0) ifrmChild.Kredit = Convert.ToDouble(txtSelisih.Text);
            else ifrmChild.Debet = Convert.ToDouble(txtSelisih.Text)*-1;
            ifrmChild.ShowDialog();

            if (ifrmChild.DialogResult == DialogResult.Yes)
            {
                DataRow dr = dtRowDetail.NewRow();
                dr["RowID"] = Guid.NewGuid();
                dr["HeaderID"] = (Guid)_rowID;
                dr["RecordID"] = ISA.Common.Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                dr["HRecordID"] = _recID;
                dr["NoPerkiraan"] = ifrmChild.NoPerkiraan;
                dr["NamaPerkiraan"] = ifrmChild.NamaPerkiraan;
                dr["Uraian"] = ifrmChild.Uraian;
                dr["DK"] = ifrmChild.DK;
                dr["Debet"] = ifrmChild.Debet;
                dr["Kredit"] = ifrmChild.Kredit;
                dtRowDetail.Rows.Add(dr);

                HitungTotal();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                DataRow drDel = ((DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                drDel.Delete();
                HitungTotal();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid _HeaderID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["cHeaderID"].Value;
                DataRow dr = ((DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                GL.frmJournalDetailUpdate ifrmChild = new GL.frmJournalDetailUpdate(_HeaderID,this);
                ifrmChild.NoPerkiraan = dr["NoPerkiraan"].ToString();
                ifrmChild.NamaPerkiraan = dr["NamaPerkiraan"].ToString();
                ifrmChild.Uraian = dr["Uraian"].ToString();
                ifrmChild.Debet = double.Parse(dr["Debet"].ToString());
                ifrmChild.Kredit = double.Parse(dr["Kredit"].ToString());
                ifrmChild.ShowDialog();
                if (ifrmChild.DialogResult == DialogResult.Yes)
                {
                    dr["NoPerkiraan"] = ifrmChild.NoPerkiraan;
                    dr["NamaPerkiraan"] = ifrmChild.NamaPerkiraan;
                    dr["Uraian"] = ifrmChild.Uraian;
                    dr["DK"] = ifrmChild.DK;
                    dr["Debet"] = ifrmChild.Debet;
                    dr["Kredit"] = ifrmChild.Kredit;

                    HitungTotal();
                }
            }
        }

        private void HitungTotal()
        {
            double debet = 0;
            double kredit = 0;
            
            if (dtRowDetail.Rows.Count > 0)
            {
                double.TryParse(dtRowDetail.Compute("SUM(Debet)", "").ToString(), out debet);
                double.TryParse(dtRowDetail.Compute("SUM(Kredit)", "").ToString(), out kredit);
            }
            txtTDebet.Text = debet.ToString("#,##0");
            txtTKredit.Text = kredit.ToString("#,##0");
            txtSelisih.Text = (debet - kredit).ToString("#,##0");
            if (txtSelisih.Text == "0" || txtSelisih.Text == "")
            {
                txtSelisih.BackColor = Color.White;
            }
            else
            {
                txtSelisih.BackColor = Color.Red;
            }

        }

    }
}
