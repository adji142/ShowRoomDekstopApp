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
    public partial class frmHubunganIstimewaUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update};
        enumFormMode formMode;

        Guid _rowID;
        enum enumTipeNota { DebitNote, CreditNote };
        enumTipeNota _tipeNota ;

        DateTime _today = GlobalVar.GetServerDate;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        #region KONSTRUKTOR
        public frmHubunganIstimewaUpdate()
        {
            InitializeComponent();
        }

        public frmHubunganIstimewaUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmHubunganIstimewaUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }
        #endregion

        #region UDF
        private void toggleCabangEnabled(enumTipeNota tipe)
        {
            switch (tipe)
            {
                case enumTipeNota.DebitNote:
                    cboCabangDari.SelectedValue = GlobalVar.CabangID;
                    cboCabangDari.Enabled = false;
                    cboCabangKe.Enabled = true;
                    break;
                case enumTipeNota.CreditNote:
                    cboCabangKe.SelectedValue = GlobalVar.CabangID;
                    cboCabangKe.Enabled = false;
                    cboCabangDari.Enabled = true;
                    break;
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
            fcbo.fillComboCabang(cboCabangDari);
            fcbo.fillComboCabang(cboCabangKe);
            fcbo.fillComboKelompokHI(cboKelompokTransaksi);
            RefreshData();
        }

        private void RefreshData()  {
            switch (formMode)
            {
                case enumFormMode.New:
                    dtTanggal.DateValue = GlobalVar.GetServerDate;
                    break;
                case enumFormMode.Update:
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            _tipeNota = (enumTipeNota)int.Parse(dt.Rows[0]["TipeNota"].ToString());
                            txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"],"").ToString();
                            dtTanggal.DateValue = (DateTime)dt.Rows[0]["Tanggal"];
                            cboCabangDari.SelectedValue = Tools.isNull(dt.Rows[0]["CabangDariID"], "").ToString();
                            cboCabangKe.SelectedValue = Tools.isNull(dt.Rows[0]["CabangKeID"], "").ToString();
                            cboKelompokTransaksi.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["KelompokTransaksiRowID"], Guid.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
        }

        private void rdoNoteDebet_CheckedChanged(object sender, EventArgs e)
        {
            toggleCabangEnabled(enumTipeNota.DebitNote);
        }

        private void rdoNoteCredit_CheckedChanged(object sender, EventArgs e)
        {
            toggleCabangEnabled(enumTipeNota.CreditNote);
        }


        #region Parameter Lock

        private List<int> ParameterKuncian()
        {
            List<int> _parameterkuncian = new List<int>();
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Lock"));
                dt = db.Commands[0].ExecuteDataTable();
                _parameterkuncian.Add((int)dt.Rows[0]["BackdatedLock"]);

            }
            return _parameterkuncian;
        }

        private bool CheckBackDate()
        {
            bool Expired = false;
            List<int> parameter = ParameterKuncian();
            if (dtTanggal.DateValue <= GlobalVar.GetServerDate.AddDays(-parameter[0])) { Expired = true; }
            return Expired;
        }



        #endregion


        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            bool lproses = true;
            if ((_tipeNota != enumTipeNota.DebitNote) && (_tipeNota != enumTipeNota.CreditNote))
            {
                MessageBox.Show("Tipe Nota (DN/KN) belum dipilih ...");
                lproses = false;
            }

            if (string.IsNullOrEmpty(dtTanggal.Text.ToString()))
            {
                MessageBox.Show("Tanggal belum diinput...");
                lproses = false;
            }
            else
            {

                if (CheckBackDate() == true)
                {
                    MessageBox.Show("Tidak boleh input data lebih dari 2 hari yang lalu");
                    lproses = false;
                }

                //if (dtTanggal.DateValue <= _today.AddDays(-2))
                //{
                //    MessageBox.Show("Tidak boleh input data lebih dari 2 hari yang lalu");
                //    return;
                //}
            } 

            if (lproses)
            try {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        {
                            txtNoBukti.Text = Numerator.GetNomorDokumen("PENGAJUAN_PENGELUARAN_UANG", "", "/" + 
                                                ((_tipeNota == enumTipeNota.DebitNote) ? "D" :"K") + "/" +
                                                string.Format("{0:yyMM}", dtTanggal.DateValue)
                                                , 3, false, true);
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.TinyInt, _tipeNota));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangDariID",SqlDbType.VarChar, cboCabangDari.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangKeID",SqlDbType.VarChar, cboCabangKe.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiRowID",SqlDbType.UniqueIdentifier,cboKelompokTransaksi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();

                                if (dt.Rows.Count>0) { 
                                    MessageBox.Show("No. Bukti : '" + txtNoBukti.Text + "' sudah ada...");
                                }
                            }
                    }
                    break;
                    case enumFormMode.Update:
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dtTanggal.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.TinyInt, _tipeNota));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangDariID",SqlDbType.VarChar, cboCabangDari.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@CabangKeID",SqlDbType.VarChar, cboCabangKe.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiRowID",SqlDbType.UniqueIdentifier,cboKelompokTransaksi.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
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
                if (this.Caller is frmHubunganIstimewaBrowse)
                {
                    frmHubunganIstimewaBrowse frmCaller = (frmHubunganIstimewaBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRowID("NoBukti",txtNoBukti.Text);
                }
            //}
            //this.Close();
        }

        #endregion
    }
}
