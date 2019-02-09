using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.Reporting.WinForms;
using ISA.Common;
using ISA.Showroom.Finance;
using ISA.Showroom.Finance.DataTemplates;

namespace ISA.Showroom.Finance.GL
{
    public partial class frmTutupBuku : ISA.Controls.BaseForm
    {
        string periode;
        string kodeGudang;

        private string[] unittype = {"all","honda","ahass","avalis"};
        
        DataTable dtClosingGL = new DataTable();
        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();
        public frmTutupBuku()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            GetSaldoTutupBuku();
            DisplayExecuteForm();
        }

        private void frmTutupBuku_Load(object sender, EventArgs e)
        {
            SetControl();
        }

        private void SetControl()
        {
            monthYearBox1.Month = GlobalVar.GetServerDate.Month;
            monthYearBox1.Year = GlobalVar.GetServerDate.Year;
            textGudang.Text = GlobalVar.Gudang;
            label3.Text = GlobalVar.PerusahaanName;
            //cboCabang.SelectedIndex = 0;
        }


        private void GetSaldoTutupBuku()
        {
            DataTable dtTutupBuku;
            periode = monthYearBox1.Year.ToString().PadRight(4, '0') + monthYearBox1.Month.ToString().PadLeft(2, '0'); // yyyymm (ex. 201404)
            kodeGudang = textGudang.Text;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                dtJurnalH.Rows.Clear();
                dtJurnalD.Rows.Clear();

                using (Database db = new Database(GlobalVar.DBHoldingName))
                {
                    db.Commands.Add(db.CreateCommand("psp_Get_GL_TutupBuku_dv"));
                    db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, periode));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    //db.Commands[0].Parameters.Add(new Parameter("@tabel", SqlDbType.VarChar, cboCabang.SelectedValue));
                    dtClosingGL = db.Commands[0].ExecuteDataTable();

                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_GL_TutupBuku_GetSaldo_dv"));
                    db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, periode));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, kodeGudang));
                    //db.Commands[0].Parameters.Add(new Parameter("@tabel", SqlDbType.VarChar, cboCabang.SelectedValue));
                    dtTutupBuku = db.Commands[0].ExecuteDataTable();
                }

                DataTable noPerkLbB = Class.Perkiraan.GetPerkiraanKoneksiDetail("LBBLN", kodeGudang);
                DataTable noPerkLbT = Class.Perkiraan.GetPerkiraanKoneksiDetail("LBTHN", kodeGudang);
                double lbBln = 0;

                //call untuk setiap unit. 
                foreach (var itm in unittype)
                {

                    //Construct CLS
                    Guid jID = Guid.NewGuid();
                    string jrecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                    DateTime closingDate = new DateTime(monthYearBox1.Year, monthYearBox1.Month, 1).AddMonths(1).AddDays(-1);
                    string noReff = "CLS-" + kodeGudang + "/" + closingDate.ToString("MM/yyyy");
                    string uraian = "TUTUP BUKU";
                    string src = "CLS";
                    double tDebet = 0;
                    double tKredit = 0;
                    double.TryParse(dtTutupBuku.Compute("SUM(Debet)","unit='"+itm+"'").ToString(), out tDebet);
                    double.TryParse(dtTutupBuku.Compute("SUM(Kredit)","unit='"+itm+"'").ToString(), out tKredit);
                    InsertJournalHeader(jID, jrecID, closingDate, noReff, uraian, src, kodeGudang, false, tDebet, tKredit,itm);

                    foreach (DataRow dr in dtTutupBuku.Rows)
                    {
                        if (dr["Unit"].ToString() == itm)
                        {
                            Guid jdID = Guid.NewGuid();
                            string jdRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                            InsertJournalDetail(jdID, jID, jdRecID, jrecID, dr["NoPerkiraan"].ToString(), dr["Uraian"].ToString(), Convert.ToDouble(dr["Debet"].ToString()), Convert.ToDouble(dr["Kredit"].ToString()), dr["DK"].ToString(), itm);
                            if (dr["NoPerkiraan"].ToString() == noPerkLbB.Rows[0]["NoPerkiraan"].ToString())
                            {
                                lbBln = Convert.ToDouble(dr["Debet"].ToString()) - Convert.ToDouble(dr["Kredit"].ToString());
                            }
                        }
                    }

                    //Construct LBB
                    jID = Guid.NewGuid();
                    jrecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                    DateTime lbbDate = closingDate.AddDays(1);
                    noReff = lbbDate.ToString("yyyyMMdd" + "LBB" + kodeGudang);
                    uraian = "Alokasi laba bulan berjalan " + lbbDate.ToString("dd-MMM-yyyy");
                    src = "LBB";
                    tDebet = lbBln;
                    if (tDebet < 0) tDebet = -tDebet;
                    tKredit = lbBln;
                    if (tKredit < 0) tKredit = -tKredit;
                    InsertJournalHeader(jID, jrecID, lbbDate, noReff, uraian, src, kodeGudang, false, tDebet, tKredit,itm);


                    //INSERT LBBLN
                    Guid lbblnID = Guid.NewGuid();
                    string lbblnRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                    string lbblnDK = "D";
                    double lbblnDebet = 0;
                    double lbblnKredit = 0;

                    if (lbBln >= 0)
                    {
                        lbblnKredit = lbBln;
                        lbblnDK = "K";
                    }
                    else
                    {
                        lbblnDebet = -lbBln;
                        lbblnDK = "D";
                    }
                    InsertJournalDetail(lbblnID, jID, lbblnRecID, jrecID, noPerkLbB.Rows[0]["NoPerkiraan"].ToString(), noPerkLbB.Rows[0]["Uraian"].ToString(), lbblnDebet, lbblnKredit, lbblnDK,itm);

                    //INSERT LBTHN
                    Guid lbthnID = Guid.NewGuid();
                    string lbthnRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                    string lbthnDK = "D";
                    double lbthnDebet = 0;
                    double lbthnKredit = 0;

                    if (lbBln >= 0)
                    {
                        lbthnDebet = lbBln;
                        lbthnDK = "D";
                    }
                    else
                    {
                        lbthnKredit = -lbBln;
                        lbthnDK = "K";
                    }
                    InsertJournalDetail(lbthnID, jID, lbthnRecID, jrecID, noPerkLbT.Rows[0]["NoPerkiraan"].ToString(), noPerkLbT.Rows[0]["Uraian"].ToString(), lbthnDebet, lbthnKredit, lbthnDK,itm);

                    // kalau tutup buku di bulan 12, ada jurnal tutup buku tambahan untuk memindahkan 
                    // laba tahun berjalan ke laba ditahan
                    if (monthYearBox1.Month == 12)
                    {
                        // Construct LTB
                        String NoPerkLD = Class.AutoJournal.GetPerkiraanKoneksiDetail("LBDTHN", "SHW", GlobalVar.CabangID);
                        String NoPerkLTB = Class.AutoJournal.GetPerkiraanKoneksiDetail("LBTHN", "SHW", GlobalVar.CabangID);
                        jID = Guid.NewGuid();
                        jrecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                        DateTime ltbDate = new DateTime((monthYearBox1.Year + 1), 1, 1);

                        Double LabaTahunBerjalanDesember = 0;
                        // ambil laba tahun berjalannya desember
                        using (Database db = new Database())
                        {
                            DataTable dummy = new DataTable();
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_GetHitungLabaThnAkhir_dv"));
                            db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.Date, ltbDate.AddMonths(-1)));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraanLTB", SqlDbType.VarChar, NoPerkLTB));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, kodeGudang));
                            db.Commands[0].Parameters.Add(new Parameter("@tabel", SqlDbType.VarChar, itm));
                            dummy = db.Commands[0].ExecuteDataTable();
                            if (dummy.Rows.Count > 0)
                            {
                                LabaTahunBerjalanDesember = Convert.ToDouble(Tools.isNull(dummy.Rows[0]["LabaTahunAkhir"].ToString(), "0"));
                            }
                        }
                        Double NominalLTB = lbBln + LabaTahunBerjalanDesember;
                        noReff = ltbDate.ToString("yyyyMMdd" + "LTB" + kodeGudang);
                        uraian = "Alokasi laba tahun berjalan " + ltbDate.ToString("dd-MMM-yyyy");
                        src = "LTB";
                        tDebet = NominalLTB;
                        if (tDebet < 0)
                        {
                            tDebet = -tDebet;
                        }
                        tKredit = NominalLTB;
                        if (tKredit < 0)
                        {
                            tKredit = -tKredit;
                        }
                        InsertJournalHeader(jID, jrecID, lbbDate, noReff, uraian, src, kodeGudang, false, tDebet, tKredit, itm);

                        //INSERT LTBLN
                        Guid ltblnID = Guid.NewGuid();
                        string ltblnRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                        string ltblnDK = "D";
                        double ltblnDebet = 0;
                        double ltblnKredit = 0;

                        if (NominalLTB >= 0)
                        {
                            ltblnKredit = NominalLTB;
                            ltblnDK = "K";
                        }
                        else
                        {
                            ltblnDebet = -NominalLTB;
                            ltblnDK = "D";
                        }
                        InsertJournalDetail(ltblnID, jID, ltblnRecID, jrecID, NoPerkLTB, "Laba Tahun Berjalan", ltblnDebet, ltblnKredit, ltblnDK,itm);

                        //INSERT LBDTHN
                        Guid lbdthnID = Guid.NewGuid();
                        string lbdthnRecID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserID);
                        string lbdthnDK = "D";
                        double lbdthnDebet = 0;
                        double lbdthnKredit = 0;

                        if (NominalLTB >= 0)
                        {
                            lbdthnDebet = NominalLTB;
                            lbdthnDK = "D";
                        }
                        else
                        {
                            lbdthnKredit = -NominalLTB;
                            lbdthnDK = "K";
                        }
                        InsertJournalDetail(lbdthnID, jID, lbdthnRecID, jrecID, NoPerkLD, "Laba Ditahan", lbdthnDebet, lbdthnKredit, lbdthnDK,itm);
                    }
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

        private void DisplayExecuteForm()
        {
            GL.frmTutupBukuExecute ifrmChild = new GL.frmTutupBukuExecute(periode, kodeGudang, dtClosingGL, dtJurnalH, dtJurnalD);
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.ShowDialog();
        }

        private DataRow InsertJournalHeader(Guid rowID, string recordID, DateTime tanggal, string noReff, string uraian, string src, string kodeGudang, bool syncFlag, double debet, double kredit, string unit)
        {
            dsJurnal.JournalRow hdrNew = (dsJurnal.JournalRow)dtJurnalH.NewRow();
            hdrNew.RowID = rowID;
            hdrNew.RecordID = recordID;
            hdrNew.Tanggal = tanggal;
            hdrNew.NoReff = noReff;
            hdrNew.Uraian = uraian;
            hdrNew.Src = src;
            hdrNew.KodeGudang = kodeGudang;
            hdrNew.SyncFlag = syncFlag;
            hdrNew.Debet = debet;
            hdrNew.Kredit = kredit;
            hdrNew.Unit = unit;
            dtJurnalH.Rows.Add(hdrNew);
            return (DataRow)hdrNew;
        }

        private DataRow InsertJournalDetail(Guid rowID, Guid headerID, string recordID, string hRecordID, string noPerkiraan, string uraian, double debet, double kredit, string DK, string unit)
        {
            dsJurnal.JournalDetailRow dtlNew = (dsJurnal.JournalDetailRow)dtJurnalD.NewRow();
            dtlNew.RowID = rowID;
            dtlNew.HeaderID = headerID;
            dtlNew.RecordID = recordID;
            dtlNew.HRecordID = hRecordID;
            dtlNew.NoPerkiraan = noPerkiraan;
            dtlNew.Uraian = uraian;
            dtlNew.Debet = debet;
            dtlNew.Kredit = kredit;
            dtlNew.DK = DK;
            dtlNew.Unit = unit;
            dtJurnalD.Rows.Add(dtlNew);
            return (DataRow)dtlNew;
        }
    }
}
