using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmProsesGiroKeluarUpdate : ISA.Controls.BaseForm
    {
        enum enumStatusGiro { Diserahkan, Cair, BatalCair, Ditolak, Batal } 

        Guid _rowID, _rekeningRowID;
        String MataUangID;
        DateTime _GiroStatusTanggal;
        enumStatusGiro _GiroStatusLast;
        DateTime _TglJTGiro;
        public frmProsesGiroKeluarUpdate()
        {
            InitializeComponent();
        }
        public frmProsesGiroKeluarUpdate(Form caller, Guid rowID, DateTime TglJTGiro)
        {
            InitializeComponent();
            _rowID = rowID;
            _TglJTGiro = TglJTGiro;
            this.Caller = caller;
        }

        #region UDF
        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //retrieving data
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                //display data
                lblBank.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
                lblNoGiro.Text = Tools.isNull(dt.Rows[0]["NoCekGiro"], "").ToString();
                MataUangID = Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString();
                lblNominal.Text = MataUangID + " " +
                            string.Format("{0:0,0.0}", Tools.isNull(dt.Rows[0]["Nominal"], 0));
                lblJatuhTempo.Text = string.Format("{0:dd-MMM-yyyy}", dt.Rows[0]["DueDateGiro"]);
                _rekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"],Guid.Empty);

                using (Database db = new Database())
                {
                    dt.Clear();
                    db.Commands.Add(db.CreateCommand("usp_GiroHistory_LIST_FILTER_RefID"));
                    db.Commands[0].Parameters.Add(new Parameter("@RefID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        int no = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            int tno = int.Parse(Tools.isNull(dr["RecID"], "0").ToString());
                            if (no < tno)
                            {
                                _GiroStatusTanggal = (DateTime)dr["Tanggal"];
                                _GiroStatusLast = (enumStatusGiro)int.Parse(dr["StatusGiro"].ToString());
                                no = tno;
                            }
                        }
                    }
                    lblTglStatus.Text = _GiroStatusTanggal.ToString();
                    label8.Text = _GiroStatusLast.ToString();
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
            //btnSetor.Enabled = ((_GiroStatusLast == enumStatusGiro.Diterima) || (_GiroStatusLast == enumStatusGiro.BatalSetor));
            //btnBatalSetor.Visible = (_GiroStatusLast == enumStatusGiro.Disetor);
            btnCair.Enabled = ((_GiroStatusLast == enumStatusGiro.Diserahkan) || (_GiroStatusLast == enumStatusGiro.BatalCair));
            btnBatalCair.Visible = (_GiroStatusLast == enumStatusGiro.Cair);
            btnTolak.Enabled = ((_GiroStatusLast == enumStatusGiro.Diserahkan) || (_GiroStatusLast == enumStatusGiro.Cair));
            btnBatal.Visible = false;
            btnBatal.Enabled = (_GiroStatusLast <= enumStatusGiro.Diserahkan);

        }

        private void Simpan(enumStatusGiro _GiroStatusNew, string _ketStatus)
        {
            bool lOk = true;

            DateTime dTgl = GlobalVar.GetServerDate;
            //Guid _rekeningRowID = Guid.Empty;
            switch (_GiroStatusNew)
            {
                case enumStatusGiro.Cair:
                    lOk = ((_GiroStatusLast == enumStatusGiro.Diserahkan) || (_GiroStatusLast == enumStatusGiro.Cair) || _GiroStatusLast==enumStatusGiro.BatalCair);
                    break;
                case enumStatusGiro.BatalCair:
                    lOk = (_GiroStatusLast == enumStatusGiro.Cair);
                    break;
                case enumStatusGiro.Ditolak:
                    break;
                case enumStatusGiro.Batal:
                    break;
                default: lOk = false; break;
            }
            if (lOk)
            {
                dlgProsesGiroStatus dlg = new dlgProsesGiroStatus(_ketStatus, false, MataUangID, _rekeningRowID, _TglJTGiro);
                dlg.ShowDialog();
                lOk = (dlg.DialogResult == DialogResult.Yes);

                if (lOk)
                {
                    dTgl = (DateTime)dlg.dtTanggal.DateValue;

                    if (((DateTime)Tools.isNull(dTgl, DateTime.MinValue) == DateTime.MinValue) || (dTgl < _GiroStatusTanggal))
                    {
                        lOk = false;
                    }
//                    if (lRekening) _rekeningRowID = (Guid)dlg.cboRekening.SelectedValue;
                }
            }

            if (lOk == true)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GiroHistory_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RefID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@JnsGiro", SqlDbType.TinyInt, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, lblNoGiro.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dTgl));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusGiro", SqlDbType.TinyInt, _GiroStatusNew));
                        //if (lRekening)
                        //{
                        db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, _rekeningRowID));
                        //}
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }
        #endregion

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProsesGiroKeluarUpdate_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnCair_Click(object sender, EventArgs e)
        {
           
            Simpan(enumStatusGiro.Cair, btnCair.Text);
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            Simpan(enumStatusGiro.Ditolak, btnCair.Text);
        }

        private void btnBatalCair_Click(object sender, EventArgs e)
        {
            Simpan(enumStatusGiro.BatalCair, btnCair.Text);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Simpan(enumStatusGiro.Batal, btnCair.Text);
        }

    }
}
