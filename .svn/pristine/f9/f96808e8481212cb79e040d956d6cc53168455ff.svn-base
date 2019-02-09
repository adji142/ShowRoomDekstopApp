using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.HI
{
    public partial class frmDKNUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update};
        enumFormMode formMode;

        Guid _rowID;
        enum enumTipeNota { DebitNote, CreditNote };
        enumTipeNota _tipeNota ;
        bool _syncFlag = false;
        bool _canSave = true;

        DateTime _today = GlobalVar.GetServerDate;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        #region KONSTRUKTOR
        public frmDKNUpdate()
        {
            InitializeComponent();
        }

        public frmDKNUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmDKNUpdate(Form caller, Guid rowID, bool editable)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _canSave = editable;
            this.Caller = caller;
        }
        #endregion

        #region UDF
        private void toggleCabangEnabled(enumTipeNota tipe)
        {
            if (_canSave)
                //switch (tipe)
                {
                    _tipeNota = tipe;
                //    case enumTipeNota.DebitNote:
                        cboPTDari.SelectedValue = GlobalVar.PerusahaanRowID;
                        cboCabangDari.SelectedValue = GlobalVar.CabangID;
                        cboPTDari.Enabled = false;
                        cboPTKe.Enabled = true;
                        //cboCabangDari.Enabled = false;
                        //cboCabangKe.Enabled = true;
                //        break;
                //    case enumTipeNota.CreditNote:
                //        cboPTKe.SelectedValue = GlobalVar.PerusahaanRowID;
                //        cboCabangKe.SelectedValue = GlobalVar.CabangID;
                //        cboPTDari.Enabled = true;
                //        cboPTKe.Enabled = false;
                //        //cboCabangDari.Enabled = true;
                //        //cboCabangKe.Enabled = false;
                //        break;
                }
            else
            {
                cboPTDari.Enabled = false;
                cboPTKe.Enabled = false;
                cboCabangDari.Enabled = false;
                cboCabangKe.Enabled = false;
            }
        }
        #endregion

        #region Controls events
        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHubunganIstimewaUpdate_Load(object sender, EventArgs e)
        {
            fcbo.fillComboPerusahaan(cboPTDari);
            fcbo.fillComboPerusahaan(cboPTKe);
            fcbo.fillComboKelompokHI(cboKelompokTransaksi);
            RefreshData();

            if (GlobalVar.IsNewDNKN && formMode == enumFormMode.New)
            {
                cboPTKe.SelectedValue = cboPTDari.SelectedValue;
                cboPTKe.Enabled = false;
            }
        }

        private bool ValidasiManipulasi()
        {
            //DateTime Tanggal = (DateTime)this.dataGridHI.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;
            //bool Expired = false;
            //List<int> parameter = ParameterKuncian();
            //if (Tanggal <= DateTime.Now.AddDays(-parameter[0]) || Tanggal >= DateTime.Now.AddDays(+parameter[1]))
            //{ Expired = true; }
            //return Expired;
            bool result = false;
            //if (dataGridHI.SelectedCells.Count > 0)
            //{
            //    Guid rowID = (Guid)Tools.isNull(dataGridHI.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value, Guid.Empty);
                if ((_rowID!=null) && (_rowID != Guid.Empty))
                {
                    Class.clsDKN _dkn = new Class.clsDKN(_rowID);
                    string s = _dkn.ValidasiManipulasi();
                    result = (s == "Ok");
                    //if (!result) MessageBox.Show(s);
                }
                else MessageBox.Show("Data tidak ditemukan");
            //}
            //else MessageBox.Show("Tidak ada data yang dipilih..");
            //return (Tanggal < GlobalVar.GetBackDatedLockValue());
            return result;
        }

        private void RefreshData()  {
            switch (formMode)
            {
                case enumFormMode.New:
                    cboPTDari.SelectedValue = GlobalVar.PerusahaanRowID;
                    cboCabangDari.SelectedValue = GlobalVar.CabangID;
                    dtTanggal.DateValue = GlobalVar.GetServerDate;
                    cboCabangDari.Enabled = false;

                    break;
                case enumFormMode.Update:
                    try
                    {
                        grpTipeNote.Enabled = false;
                        DataTable dt = Class.clsDKN.DBGetDKN(_rowID); //new DataTable();
                        //Class.clsDKN _dkn = new ISA.Showroom.Finance.Class.clsDKN(_rowID);
                        //using (Database db = new Database())
                        //{
                            //db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST"));
                            //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            //dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                //db.Commands.Clear();
                                //db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST_FILTER_Group"));
                                //db.Commands[0].Parameters.Add(new Parameter("@GroupRowID", SqlDbType.UniqueIdentifier, _rowID));
//                                db.Commands[1].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                                DataTable dt2 = Class.clsDKN.DBGetByGroupRowID(_rowID);  //db.Commands[0].ExecuteDataTable();
                                if (dt2.Rows.Count > 0)
                                //{
                                    dataGridView1.DataSource = dt2;
                                    //dt2.Columns["TipeNota"].DataType = typeof(enumTipeNota);
                                    //_canSave = false; 
                                //}
                                else dataGridView1.DataSource = dt;
                            }
                        //}
                        if (dt.Rows.Count > 0)
                        {
                            _tipeNota = (enumTipeNota)int.Parse(dt.Rows[0]["TipeNota"].ToString());
                            txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"],"").ToString();
                            dtTanggal.DateValue = (DateTime)dt.Rows[0]["Tanggal"];
                            cboPTDari.SelectedValue = Tools.isNull(dt.Rows[0]["PerusahaanDariRowID"], Guid.Empty);
                            cboPTKe.SelectedValue = Tools.isNull(dt.Rows[0]["PerusahaanKeRowID"], Guid.Empty);
                            cboCabangDari.SelectedValue = Tools.isNull(dt.Rows[0]["CabangDariID"], "").ToString();
                            cboCabangKe.SelectedValue = Tools.isNull(dt.Rows[0]["CabangKeID"], "").ToString();
                            cboKelompokTransaksi.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["KelompokTransaksiRowID"], Guid.Empty);
                            _syncFlag = (bool)Tools.isNull(dt.Rows[0]["SyncFlag"], false);
                            _canSave = (_canSave && !_syncFlag && (Tools.isNull(dt.Rows[0]["Src"],"").ToString()=="INP")
                                        && (Tools.isNull(dt.Rows[0]["NoRequest"], "").ToString() == ""));
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
            
            //dtTanggal.Enabled = false;
            rdoNoteCredit.Checked = (_tipeNota == enumTipeNota.CreditNote);
            rdoNoteDebet.Checked = (_tipeNota == enumTipeNota.DebitNote);
            cmdSAVE.Visible = _canSave;
        }

        private void rdoNoteDebet_CheckedChanged(object sender, EventArgs e)
        {
            toggleCabangEnabled(enumTipeNota.DebitNote);
        }

        private void rdoNoteCredit_CheckedChanged(object sender, EventArgs e)
        {
            toggleCabangEnabled(enumTipeNota.CreditNote);
        }


        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            //object d = DBTools.DBGetScalar("usp_GetBackDatedLock", new List<Parameter>());
            if ((_tipeNota != enumTipeNota.DebitNote) && (_tipeNota != enumTipeNota.CreditNote))
            {
                MessageBox.Show("Tipe Nota (DN/KN) belum dipilih ...");
                return;
            }

            if (string.IsNullOrEmpty(dtTanggal.Text.ToString()))
            {
                MessageBox.Show("Tanggal belum diinput...");
                return;
            }
            else
            {
                if (dtTanggal.DateValue < GlobalVar.GetBackDatedLockValue()) 
                {
                    MessageBox.Show("Tidak boleh input data lebih dari batas waktu input / ubah data");
                    return;
                }
            }

            try {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_INSERT_GROUP"));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.TinyInt, _tipeNota));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, cboPTDari.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, cboPTKe.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, cboCabangDari.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangKeID",SqlDbType.VarChar, cboCabangKe.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, "~INPUTMANUAL~"));
                                db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiRowID", SqlDbType.UniqueIdentifier, cboKelompokTransaksi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();

                                if (dt.Rows.Count<=0) if (dt.Rows[0][0].ToString()!="0") 
                                    MessageBox.Show("Error No. : '" + dt.Rows[0]["Result"].ToString() + 
                                                    "\n"  + dt.Rows[0]["Message"].ToString());
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_UPDATE_GROUP"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiRowID", SqlDbType.UniqueIdentifier, cboKelompokTransaksi.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            //dt = db.Commands[0].ExecuteDataTable();

                            //if (dt.Rows.Count <= 0) if (dt.Rows[0][0].ToString() != "0")
                            //        MessageBox.Show("Error No. : '" + dt.Rows[0]["Result"].ToString() +
                            //                        "\n" + dt.Rows[0]["Message"].ToString());
                        }
                        break;
                }
            }catch (Exception ex) { 
                Error.LogError(ex);
            } finally{
                this.Cursor=Cursors.Default;
            }
            this.closeForm();
            this.Close();

        }

        private void closeForm()
        {
            //if (this.DialogResult == DialogResult.OK)
            //{
                if (this.Caller is frmDKNBrowse)
                {
                    frmDKNBrowse frmCaller = (frmDKNBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRowID("RowIDHeader",_rowID.ToString());
                }
            //}
            //this.Close();
        }

        private void cboPTDari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboPTDari.DataSource!=null) && (cboPTDari.SelectedIndex > 0))
            {
                fcbo.fillComboCabang(cboCabangDari, (Guid)cboPTDari.SelectedValue);
            }
        }

        private void cboCabangDari_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboPTKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPTKe.SelectedIndex > 0)
            {
                fcbo.fillComboCabang(cboCabangKe, (Guid)cboPTKe.SelectedValue);
            }
        }

        #endregion

    }
}
