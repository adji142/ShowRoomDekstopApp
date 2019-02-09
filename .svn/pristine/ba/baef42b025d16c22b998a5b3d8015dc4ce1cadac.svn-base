using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Master
{
    public partial class frmTargetKolektorUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID, _kolektorRowID;
        String _cabangID = GlobalVar.CabangID;

        public frmTargetKolektorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmTargetKolektorUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lookUpKolektor1.txtNamaKolektor.Text))
                {
                    MessageBox.Show("Kolektor belum dipilih !");
                    lookUpKolektor1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboKecamatan.Text))
                {
                    MessageBox.Show("TMT belum diisi !");
                    cboKecamatan.Focus();
                    return;
                }                
                if (string.IsNullOrEmpty(txttargetrp.Text))
                {
                    MessageBox.Show("Target Rp belum diisi !");
                    txttargetrp.Focus();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetKolektor_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.Date, monthYearBox1.FirstDateOfMonth));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetRp", SqlDbType.Money, txttargetrp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, (Guid)cboKecamatan.SelectedValue));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        MessageBox.Show("Data berhasil ditambahkan");
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_TargetKolektor_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                            if (lookUpKolektor1._Kolektor.RowID == Guid.Empty)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, _kolektorRowID));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@TMT", SqlDbType.Date, monthYearBox1.FirstDateOfMonth));
                            db.Commands[0].Parameters.Add(new Parameter("@TargetRp", SqlDbType.Money, txttargetrp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@KecRowID", SqlDbType.UniqueIdentifier, (Guid)cboKecamatan.SelectedValue));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        MessageBox.Show("Data berhasil diupdate");
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate !");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmTargetKolektorUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                loadKecamatan();
                monthYearBox1.Month = GlobalVar.DateOfServer.Month;
                monthYearBox1.Year = GlobalVar.DateOfServer.Year;

                if (formMode == enumFormMode.Update)
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_TargetKolektor_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        lookUpKolektor1.txtNamaKolektor.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                        _kolektorRowID = (Guid)Tools.isNull(dt.Rows[0]["KecRowID"], "");

                        monthYearBox1.Month = ((DateTime)Tools.isNull(dt.Rows[0]["TMT"], "")).Month;
                        monthYearBox1.Year = ((DateTime)Tools.isNull(dt.Rows[0]["TMT"], "")).Year;
                        cboKecamatan.SelectedValue = (Guid)Tools.isNull(dt.Rows[0]["KecRowID"], "");                   
                        txttargetrp.Text = Tools.isNull(dt.Rows[0]["Target_Rp"], "").ToString();
                    }
                }
                else
                {                 
                    txttargetrp.Text = "";
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

        private void frmTargetKolektorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Master.frmTargetKolektorBrowse)
            {
                Master.frmTargetKolektorBrowse frmCaller = (Master.frmTargetKolektorBrowse)this.Caller;
                frmCaller.RefreshBln();
                frmCaller.FindRowBln("Periode", monthYearBox1.FirstDateOfMonth.ToString("dd MMM yyyy"));
                frmCaller.RefreshData();
                frmCaller.FindRow("Nama", lookUpKolektor1.txtNamaKolektor.Text);
            }
        }

        private void lookUpKolektor1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txttmt_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txttargetrp_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void loadKecamatan()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_TargetKolektor_LISTWilayah"));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                cboKecamatan.DisplayMember = "Keterangan";
                cboKecamatan.ValueMember = "RowID";
                cboKecamatan.DataSource = dt;
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
    }
}
