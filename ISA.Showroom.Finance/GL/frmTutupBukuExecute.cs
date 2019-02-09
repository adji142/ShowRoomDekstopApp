using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Showroom.Finance;
using ISA.Showroom.Finance.DataTemplates;
using ISA.DAL;
using ISA.Showroom.Finance.Class;
using ISA.Common;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmTutupBukuExecute : ISA.Controls.BaseForm
    {
        //DateTime tglProses;
        string _periode;
        string _kodeGudang;
        string _tabel;
        string _unitusaha;

        DataTable dtClosing = new DataTable();
        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();

        int prevRow1 = -1;
        int _year, _month;

        public frmTutupBukuExecute(string periode, string kodeGudang, DataTable pClosingGL, dsJurnal.JournalDataTable dtJournal, dsJurnal.JournalDetailDataTable dtJournalDetail)
        {
            InitializeComponent();

            _periode = periode;
            _year = Convert.ToInt32(periode.Substring(0, 4));
            _month = Convert.ToInt32(periode.Substring(4, 2));
            _kodeGudang = kodeGudang;
            dtClosing = pClosingGL;
            dtJurnalH = dtJournal;
            dtJurnalD = dtJournalDetail;
            initializeUnitCombo();
            dtClosing.DefaultView.RowFilter = "unit='all'";
            dtJurnalH.DefaultView.RowFilter = "unit='all'";
        }

        private void initializeUnitCombo()
        {
            Dictionary<string, string> lst = new Dictionary<string, string>();
            lst.Add("all", "ALL");
            lst.Add("honda", "HONDA");
            lst.Add("avalis", "AVALIS");
            lst.Add("ahass", "AHASS");
            cboCabang.DataSource = new BindingSource(lst, null);
            cboCabang.DisplayMember = "Key";
            cboCabang.DisplayMember = "Value";
            cboCabang.SelectedIndex = 0;
        }


        public frmTutupBukuExecute(string periode, string kodeGudang, DataTable pClosingGL, dsJurnal.JournalDataTable dtJournal, dsJurnal.JournalDetailDataTable dtJournalDetail, string tabel)
        {
            InitializeComponent();

            _periode = periode;
            _year = Convert.ToInt32(periode.Substring(0, 4));
            _month = Convert.ToInt32(periode.Substring(4, 2));
            _kodeGudang = kodeGudang;
            _tabel = tabel;
            dtClosing = pClosingGL;
            dtJurnalH = dtJournal;
            dtJurnalD = dtJournalDetail;
            initializeUnitCombo();
            dtClosing.DefaultView.RowFilter = "unit='all'";
            dtJurnalH.DefaultView.RowFilter = "unit='all'";
        }

        private void frmTutupBukuPreview_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show(dtClosing.DefaultView.Count.ToString());
             gridClosingGL.DataSource = dtClosing.DefaultView;
            customGridView1.DataSource = dtJurnalH.DefaultView;
            customGridView2.DataSource = dtJurnalD.DefaultView;
            RefreshDetail();
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskSave, "Tutup Buku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime lbbDate = new DateTime(Convert.ToInt32(_periode.Substring(0, 4)), Convert.ToInt32(_periode.Substring(4, 2)), 1).AddMonths(1);
                DateTime closingDate = lbbDate.AddDays(-1);

                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.BeginTransaction();

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_GL_ClearTutupBuku_dv"));
                    db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, _periode));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, _kodeGudang));
                    //db.Commands[0].Parameters.Add(new Parameter("@tabel", SqlDbType.VarChar, _tabel));
                    db.Commands[0].ExecuteNonQuery();

                    string unit = "";

                    foreach (DataRow dr in dtClosing.Rows)
                    {
                        unit = dr["Unit"] + "";
                        switch (unit)
                        {
                            case "all":
                                unit = "Journal";
                                break;
                            case "honda":
                                unit = "JournalHonda";
                                break;
                            case "avalis":
                                unit = "JournalAvalis";
                                break;
                            case "ahass":
                                unit = "JournalAhass";
                                break;

                        }
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_ClosingGL_INSERT_byCabang"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _periode));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, dr["KodeGudang"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, dr["NoPerkiraan"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglProses", SqlDbType.DateTime, dr["TglProses"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RpAkhir", SqlDbType.Money, dr["RpAkhir"]));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                        db.Commands[0].Parameters.Add(new Parameter("@tabel", SqlDbType.VarChar, unit));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    foreach (DataRow dr in dtJurnalH.Rows)
                    {
                        unit = dr["Unit"] + "";
                        switch (unit)
                        {
                            case "all":
                                unit = "Journal";
                                break;
                            case "honda":
                                unit = "JournalHonda";
                                break;
                            case "avalis":
                                unit = "JournalAvalis";
                                break;
                            case "ahass":
                                unit = "JournalAhass";
                                break;

                        }
                        Journal.AddHeader_ver_5(db,
                            GlobalVar.PerusahaanRowID,
                            new Guid(dr["RowID"].ToString()),
                            dr["RecordID"].ToString(),
                            Convert.ToDateTime(dr["Tanggal"]),
                            dr["NoReff"].ToString(),
                            dr["Uraian"].ToString(),
                            dr["Src"].ToString(),
                            dr["KodeGudang"].ToString(),
                            Convert.ToBoolean(dr["SyncFlag"]),
                            unit,
                            dr["UnitUsaha"].ToString());

                    }

                    foreach (DataRow dr in dtJurnalD.Rows)
                    {
                        unit = dr["Unit"] + "";
                        switch (unit)
                        {
                            case "all":
                                unit = "JournalDetail";
                                break;
                            case "honda":
                                unit = "JournalDetailHonda";
                                break;
                            case "avalis":
                                unit = "JournalDetailAvalis";
                                break;
                            case "ahass":
                                unit = "JournalDetailAhass";
                                break;

                        }
                        Journal.AddDetail_ver_5(db,
                            new Guid(dr["RowID"].ToString()),
                            new Guid(dr["HeaderID"].ToString()),
                            dr["RecordID"].ToString(),
                            dr["HRecordID"].ToString(),
                            dr["NoPerkiraan"].ToString(),
                            dr["Uraian"].ToString(),
                            Convert.ToDouble(dr["Debet"]),
                            Convert.ToDouble(dr["Kredit"]),
                            dr["DK"].ToString(),
                            new Guid(Guid.Empty.ToString()),
                            Convert.ToDouble(0),
                            unit);
                    }

                    db.CommitTransaction();

                    MessageBox.Show(Messages.Confirm.ProcessFinished);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RefreshDetail()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string journalID = customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString();
                dtJurnalD.DefaultView.RowFilter = "HeaderID='" + journalID + "'";
                
                prevRow1 = customGridView1.SelectedCells[0].RowIndex;    
            }
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (prevRow1 != customGridView1.SelectedCells[0].RowIndex)
                {
                    RefreshDetail();
                }
            }
            //else
            //{
            //    dtJurnalD.DefaultView.RowFilter = "RowID=''";
            //}
        }

        private void frmTutupBukuExecute_Load(object sender, EventArgs e)
        {
            if (_tabel == "Journal")
            {
                _unitusaha = "";
            }
            else if (_tabel == "JournalHonda")
            {
                _unitusaha = "HONDA";
            }
            else if (_tabel == "JournalAhass")
            {
                _unitusaha = "AHASS";
            }
            else if (_tabel == "JournalAvalis")
            {
                _unitusaha = "AVALIS";
            }

            if (!dtJurnalH.Columns.Contains("UnitUsaha"))
            {
                DataColumn newcol = new DataColumn("UnitUsaha", typeof(string));
                dtJurnalH.Columns.Add(newcol);
            }

            foreach (DataRow dr in dtJurnalH.Rows)
            {
                dr["UnitUsaha"] = _unitusaha;
            }
        }

        private void cboCabang_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> dta = (KeyValuePair<string, string>) cboCabang.SelectedValue;
            Console.WriteLine(dta.Key);
            dtClosing.DefaultView.RowFilter = "unit='" + dta.Key + "'";
            dtJurnalH.DefaultView.RowFilter = "unit='" + dta.Key + "'";
        }

    }
}
