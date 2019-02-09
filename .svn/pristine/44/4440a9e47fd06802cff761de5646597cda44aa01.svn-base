using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Keuangan
{
    public partial class frmClosingKeuangan : ISA.Controls.BaseForm
    {
        private DataSet ds = new DataSet();
        DateTime tglAwal, tglAkhir;
         private string _lastClosing, _periode;

        public frmClosingKeuangan()
        {
            InitializeComponent();
        }

        private void frmClosingKeuangan_Load(object sender, EventArgs e)
        {
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@PerusahaanRowID",SqlDbType.UniqueIdentifier,GlobalVar.PerusahaanRowID));
            _lastClosing = DBTools.DBGetScalar("usp_GetLastMonthClosingKasir", prm).ToString();
            if (string.IsNullOrEmpty(_lastClosing))
            {
                DateTime d = GlobalVar.GetServerDate;
                spnTahun.Value = d.Year;
                cboBulan.SelectedIndex = d.Month - 1;
            }
            else
            {
                spnTahun.Value = int.Parse(_lastClosing.Substring(0,4));
                cboBulan.SelectedIndex = int.Parse(_lastClosing.Substring(4, 2));
            }
            RefreshData();
        }

        void SetPeriode()
        {
            string ctanggal = spnTahun.Value.ToString().PadLeft(4,'0') + cboBulan.SelectedIndex.ToString().PadLeft(2,'0') + "01";
            DateTime t = DateTime.ParseExact(ctanggal, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            //tglAwal = t.AddMonths(-1);
            //tglAkhir = t.AddDays(-1);
            //_periode = tglAwal.Year.ToString().PadLeft(4, '0') + tglAwal.Month.ToString().PadLeft(2, '0');
            _periode = t.Year.ToString().PadLeft(4, '0') + t.Month.ToString().PadLeft(2, '0');
        }

        void RefreshData()
        {
            //int t = int.Parse(Tools.DBGetScalar("usp_GetBackDatedValue", new List<Parameter>()).ToString());
            DateTime tanggal = GlobalVar.GetServerDate;
            string tahunbulan = spnTahun.Value.ToString() + cboBulan.SelectedIndex.ToString().PadLeft(2, '0');
                               //tanggal.Year.ToString().PadLeft(4,'0') + tanggal.Month.ToString().PadLeft(2,'0');
            SetPeriode();
            if (tglAwal>tanggal) MessageBox.Show("Belum saatnya proses akhir bulan,\n Periode terakhir sudah diproses.");
            else
            {
                List<Parameter> prm = new List<Parameter>();
                prm.Clear();
                //prm.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                prm.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, _periode));
                prm.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                ds.Tables.Clear();
                RefreshGrid(dataGridView1, "psp_Kasir_Closing_Kas_LIST", prm, "SaldoKas");
                RefreshGrid(dataGridView2, "psp_Kasir_Closing_Rekening_LIST", prm, "SaldoRekening");
                //RefreshGrid(dataGridView3, "psp_SelisihKurs_LIST", prm, "SelisihKurs");
            }
        }

        void RefreshGrid(DataGridView dgv, string sql, List<Parameter> prm, string tblname)
        {
            dgv.DataSource = null;
            dgv.Refresh();
            DataTable dt = Tools.DBGetDataTable(sql, prm);
            dt.Columns.Add("Hasil", typeof(string));
            dt.TableName = tblname;
            ds.Tables.Add(dt);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = ds;
            dgv.DataMember = tblname;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (ProsesSaldoKas()=="") ProsesSaldoRekening();
            this.Cursor = Cursors.Default;
        }

        private string ProsesSaldoKas() { 
            int nresult = 0;
            string sresult = "";

            using (Database db = new Database()) {
                DateTime tanggal = DateTime.ParseExact(_periode+"01", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddMonths(1);
                tanggal.AddMonths(1);
                string thbl = tanggal.Year.ToString() + tanggal.Month.ToString().PadLeft(2,'0');
                Guid kasRowID;
                double saldoAwal;
                try
                {
                    db.BeginTransaction();
                    DataTable dt = ds.Tables["SaldoKas"];
                    db.Commands.Add(db.CreateCommand("psp_Kasir_Closing_Kas_INSERT"));
                    foreach (DataRow dr in dt.Rows)
                    {
                        kasRowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
                        saldoAwal = double.Parse(Tools.isNull(dr["SaldoAkhirRp"],0).ToString());
                        if ((kasRowID != Guid.Empty) && (saldoAwal != 0))
                        {
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, kasRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, thbl));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwal", SqlDbType.Money, saldoAwal));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    nresult = 999;
                    sresult = ex.Message;
                } 
                finally
                {
                    if (nresult == 0) db.CommitTransaction(); else db.RollbackTransaction();
                }
                if (nresult != 0) MessageBox.Show(sresult);
                return sresult;
            }
        }

        private void ProsesSaldoRekening()
        {
            int nresult = 0;
            string sresult = "";
            using (Database db = new Database())
            {
                DateTime tanggal = DateTime.ParseExact(_periode + "01", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddMonths(1);
                string thbl = tanggal.Year.ToString() + tanggal.Month.ToString().PadLeft(2, '0');
                string mataUangID;
                Guid rekeningRowID;
                double saldoRp, saldoOri, kurs, selisihKurs, saldoRpRk, saldoOriRk;
                try
                {
                    db.BeginTransaction();
                    DataTable dt = ds.Tables["SaldoRekening"];
                    db.Commands.Add(db.CreateCommand("usp_RekeningSaldo_INSERT"));
                    foreach (DataRow dr in dt.Rows)
                    {
                        rekeningRowID = (Guid)Tools.isNull(dr["RowID"], Guid.Empty);
                        mataUangID = Tools.isNull(dr["MataUangID"], "").ToString();
                        saldoOri = double.Parse(Tools.isNull(dr["SaldoAkhirOri"], 0).ToString());
                        saldoRp = double.Parse(Tools.isNull(dr["SaldoAkhirRp"], 0).ToString());
                        kurs = double.Parse(Tools.isNull(dr["Kurs"], 0).ToString());
                        selisihKurs = double.Parse(Tools.isNull(dr["SelisihKurs"], 0).ToString());

                        saldoOriRk = double.Parse(Tools.isNull(dr["SaldoAkhirOriRk"], 0).ToString());
                        saldoRpRk = double.Parse(Tools.isNull(dr["SaldoAkhirRpRk"], 0).ToString());

                        if ((rekeningRowID != Guid.Empty) && (saldoRp != 0) )
                        {
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, rekeningRowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, thbl));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwal", SqlDbType.Money, saldoOri));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwalRp", SqlDbType.Money, saldoRp));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwalRpRk", SqlDbType.Money, saldoRpRk));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoAwalOriRk", SqlDbType.Money, saldoOriRk));
                            db.Commands[0].Parameters.Add(new Parameter("@Kurs", SqlDbType.Money, kurs));
                            db.Commands[0].Parameters.Add(new Parameter("@SelisihKurs", SqlDbType.Money, selisihKurs));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception ex)
                {
                    nresult = 999;
                    sresult = ex.Message;
                }
                finally
                {
                    if (nresult == 0) db.CommitTransaction(); else db.RollbackTransaction();
                }
                if (nresult == 0)
                {
                    if (ProsesSelisihKurs() == 0) 
                        MessageBox.Show("Closing Rekening Bank Selesai.");
                }else MessageBox.Show("Error : \n " + sresult);
            }
        }

        private int ProsesSelisihKurs()
        {
            int nrslt = 0;
            DateTime tanggal = DateTime.ParseExact(_periode + "01", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            string thbl = tanggal.Year.ToString() + tanggal.Month.ToString().PadLeft(2, '0');
            try
            {
                Database db = new Database();
                Command cmd = db.CreateCommand("psp_SelisihKurs");
                cmd.AddParameter("@TahunBulan", SqlDbType.VarChar, thbl);
                cmd.AddParameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return nrslt;
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
