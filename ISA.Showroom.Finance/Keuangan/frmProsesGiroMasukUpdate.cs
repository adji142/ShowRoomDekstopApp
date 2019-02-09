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
    public partial class frmProsesGiroMasukUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID;
        String _noGiro;
        String MataUangID;

        DateTime _GiroStatusTanggal = DateTime.MinValue;
        Class.enumStatusGiro _GiroStatusLast = Class.enumStatusGiro.Diterima;
        Guid _rekeningRowID = Guid.Empty;
        DateTime _TglJTGiro;
        public frmProsesGiroMasukUpdate()
        {
            InitializeComponent();
        } 

        public frmProsesGiroMasukUpdate(Form caller, Guid rowID, String NoGiro, DateTime TglJTGiro)
        {
            InitializeComponent();
            _rowID = rowID;
            _noGiro = NoGiro;
            _TglJTGiro = TglJTGiro;
            this.Caller = caller;
        }

        private void frmProsesGiroUpdate_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        #region Controls Events
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetor_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.Disetor, btnSetor.Text, true);
        }

        private void btnCair_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.Cair, btnCair.Text, true);
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            DataTable dt_tglCair = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTanggalCairGiroHistory"));
                db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, _noGiro));
                dt_tglCair = db.Commands[0].ExecuteDataTable();
            }


            if (dt_tglCair.Rows.Count > 0)
            {
                DateTime TglCair = (DateTime)dt_tglCair.Rows[0]["Tanggal"];
                DateTime TglSetelah3Hari = TglCair.AddDays(3);

                if (TglCair <= TglSetelah3Hari)
                {
                    Simpan(Class.enumStatusGiro.Ditolak, btnTolak.Text, true);
                }
                else
                {
                    MessageBox.Show("Maaf, Proses Giro tolak sudah lebih dari 3 hari.");
                    return;
                }
            }
            else
            {
                Simpan(Class.enumStatusGiro.Ditolak, btnTolak.Text, true);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.Batal, btnBatal.Text, false);
        }

        private void btnBatalSetor_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.BatalSetor, btnBatalSetor.Text, true);
        }

        private void btnBatalCair_Click(object sender, EventArgs e)
        {
            Simpan(Class.enumStatusGiro.BatalCair, btnBatalCair.Text, true);
        }
        #endregion

        #region UserDefinedFunctions
        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                    //retrieving data
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        lblBank.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
                        lblNoGiro.Text = Tools.isNull(dt.Rows[0]["NoCekGiro"], "").ToString();
                        _rekeningRowID = (Guid)Tools.isNull(dt.Rows[0]["RekeningRowID"],Guid.Empty);
                        MataUangID = Tools.isNull(dt.Rows[0]["MataUangID"], "").ToString();
                        lblNominal.Text = MataUangID + " " +
                                    string.Format("{0:0,0.0}", Tools.isNull(dt.Rows[0]["Nominal"], 0));
                        lblJatuhTempo.Text = string.Format("{0:dd-MMM-yyyy}", dt.Rows[0]["TanggalGiroCair"]);
                    }

                using (Database db = new Database())
                {
                    dt.Clear();
                    db.Commands.Add(db.CreateCommand("usp_GiroHistory_LIST_FILTER_RefID"));
                    db.Commands[0].Parameters.Add(new Parameter("@RefID",SqlDbType.UniqueIdentifier,_rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        int no = 0;
                        foreach (DataRow dr in dt.Rows) {
                            int tno = int.Parse(Tools.isNull(dr["RecID"], "0").ToString());
                            if (no < tno)
                            {
                                _GiroStatusTanggal = (DateTime)dr["Tanggal"];
                                _GiroStatusLast = (Class.enumStatusGiro)int.Parse(dr["StatusGiro"].ToString());
                                no = tno;
                            }
                        }
                    }
                    lblTglStatus.Text =_GiroStatusTanggal.ToString();
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
            btnSetor.Enabled = ((_GiroStatusLast == Class.enumStatusGiro.Diterima) || (_GiroStatusLast == Class.enumStatusGiro.BatalSetor));
            btnBatalSetor.Visible = (_GiroStatusLast == Class.enumStatusGiro.Disetor);
            btnCair.Enabled = ((_GiroStatusLast == Class.enumStatusGiro.Disetor) || (_GiroStatusLast == Class.enumStatusGiro.BatalCair));
            btnBatalCair.Visible = (_GiroStatusLast == Class.enumStatusGiro.Cair);
            btnTolak.Enabled = ((_GiroStatusLast == Class.enumStatusGiro.Disetor) || (_GiroStatusLast == Class.enumStatusGiro.Cair));
            btnBatal.Enabled = (_GiroStatusLast <= Class.enumStatusGiro.Diterima);
        }


        private void Simpan(Class.enumStatusGiro _GiroStatusNew, string _ketStatus, bool lRekening) {
            bool lOk = true;

            DateTime dTgl = GlobalVar.GetServerDate;
            //Guid _rekeningRowID = Guid.Empty;
            switch (_GiroStatusNew)
            {
                case Class.enumStatusGiro.Disetor:
                    lOk = ((_GiroStatusLast == Class.enumStatusGiro.Diterima) || (_GiroStatusLast == Class.enumStatusGiro.BatalSetor));
                    break;
                case Class.enumStatusGiro.BatalSetor:
                    lOk = (_GiroStatusLast == Class.enumStatusGiro.Disetor);
                    break;
                case Class.enumStatusGiro.Cair:
                    if (_GiroStatusLast != Class.enumStatusGiro.Cair)
                    {
                        lOk = true;
                    }
                    else
                    {
                        lOk = ((_GiroStatusLast == Class.enumStatusGiro.Disetor) || (_GiroStatusLast == Class.enumStatusGiro.Cair));
                    }
                    
                    break;
                case Class.enumStatusGiro.BatalCair:
                    lOk = (_GiroStatusLast == Class.enumStatusGiro.Cair);
                    break;
                case Class.enumStatusGiro.Ditolak:
                    break;
                case Class.enumStatusGiro.Batal:
                    break;
                default: lOk = false; break;
            }
            if (lOk)
            {
                dlgProsesGiroStatus dlg = new dlgProsesGiroStatus(_ketStatus, lRekening, MataUangID, _rekeningRowID, _TglJTGiro);
                dlg.ShowDialog();
                lOk = (dlg.DialogResult == DialogResult.Yes);

                if (lOk)
                {
                    dTgl = (DateTime)dlg.dtTanggal.DateValue;

                    if (((DateTime)Tools.isNull(dTgl, DateTime.MinValue) == DateTime.MinValue) || (dTgl < _GiroStatusTanggal)) lOk = false;

                    if (_ketStatus == "Batal Cair" || _ketStatus == "BatalSetor" ||_ketStatus=="Cair" || _ketStatus=="Ditolak")
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_GetLastRekeningRowIDGiroHistory"));
                            db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, lblNoGiro.Text));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (lRekening) _rekeningRowID = (Guid)dt.Rows[0]["RekeningRowID"];
                        }
                    }
                    else
                    {
                        if (lRekening) _rekeningRowID = (Guid)dlg.lookUpRekening1.RekeningRowID;
                    }
                }
            }

            if (lOk==true)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_GiroHistory_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RefID", SqlDbType.UniqueIdentifier, _rowID));

                        // sebelum akhirnya ubah sp
                        //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));

                        if (_GiroStatusNew == Class.enumStatusGiro.Cair)
                        {
                            String tempBentukPenerimaan = "B";
                            Database dbfNumerator = new Database(GlobalVar.DBFinanceOto);
                            String NoTransPenerimaan = Numerator.GetNomorDokumen(dbfNumerator, "PENERIMAAN_UANG", GlobalVar.PerusahaanID,
                                                        "/B" + tempBentukPenerimaan.Trim() + "M/" +
                                                        string.Format("{0:yyMM}", GlobalVar.GetServerDate)
                                                        , 4, false, true);

                            // buatin parameter, kirimin numeratornya
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoTransPenerimaan));
                        }
                        db.Commands[0].Parameters.Add(new Parameter("@JnsGiro", SqlDbType.TinyInt, 1));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, lblNoGiro.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, dTgl));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusGiro", SqlDbType.TinyInt, _GiroStatusNew));
                        if (lRekening)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID",SqlDbType.UniqueIdentifier,_rekeningRowID));
                        }
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

        private void frmProsesGiroMasukUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            MdiParent.Activate();
        }

    }
}
