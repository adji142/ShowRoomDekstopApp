using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Showroom.Finance.Kasir
{
    public partial class frmPenerimaanLeasingIdentifikasiPiutang : ISA.Controls.BaseForm
    {
        Guid PenerimaanUangRowID = Guid.Empty;
        DataTable dt;
        Decimal SaldoAwal = 0;
        Decimal SaldoAwalLSG = 0;
        Decimal SaldoAwalSBD = 0;

        public frmPenerimaanLeasingIdentifikasiPiutang()
        {
            InitializeComponent();
        }

        public frmPenerimaanLeasingIdentifikasiPiutang(Form _Caller, Guid RowIDH)
        {
            InitializeComponent();
            Caller = _Caller;

            dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingHeaderIdenPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDH));
                dt = db.Commands[0].ExecuteDataTable();
            }
            PenerimaanUangRowID = RowIDH;
            txt_Leasing.Text = dt.Rows[0]["Leasing"].ToString();
            txt_Nominal.Text = dt.Rows[0]["Nominal"].ToString();
            txt_NoPembayaran.Text = dt.Rows[0]["NoBukti"].ToString();
            SaldoAwal = Convert.ToDecimal(dt.Rows[0]["Saldo"].ToString());
            txt_Saldo.Text = SaldoAwal.ToString();
            txt_TglPenerimaan.DateValue = Convert.ToDateTime(dt.Rows[0]["Tanggal"]);
        }

        private void RefreshHeader()
        {
            DataTable dtHeader = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@LeasingRowID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["LeasingRowID"]));
                GV_Penjualan.DataSource = db.Commands[0].ExecuteDataTable();
            }
        }

        private void RefreshDetail()
        {
            if (GV_Penjualan.Rows.Count > 0)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenerimaanLeasingPenerimaanUM"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)GV_Penjualan.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                    GV_PenerimaanUM.DataSource = db.Commands[0].ExecuteDataTable();
                }
                SaldoAwalLSG = Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[0].Cells["Saldo"].Value, 0));
                SaldoAwalSBD = Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[1].Cells["Saldo"].Value, 0));
            }
            GV_Penjualan.Enabled = true;
            GV_Penjualan.ReadOnly = false;

        }

        private void frmPenerimaanLeasingIdentifikasiPiutang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.GetServerDate.AddDays(-21).Date;
            rangeDateBox1.ToDate = GlobalVar.GetServerDate.Date;
            btnSearch.PerformClick();

            GV_PenerimaanUM.ReadOnly = false;
            GV_PenerimaanUM.Enabled = true;
            GV_PenerimaanUM.Columns["KodeTrans"].ReadOnly = true;
            GV_PenerimaanUM.Columns["JenisTransaksi"].ReadOnly = true;
            GV_PenerimaanUM.Columns["Piutang"].ReadOnly = true;
            GV_PenerimaanUM.Columns["Saldo"].ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
            if (GV_Penjualan.Rows.Count > 0)
            {
                RefreshDetail();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txt_Saldo.Text) < 0)
                {
                    MessageBox.Show("Qty Iden melebihi Qty Nominal, silahkan di cek lagi");
                    return;     
                }

                if (Convert.ToDecimal(GV_PenerimaanUM.Rows[0].Cells[4].Value) < 0)
                {
                    MessageBox.Show("Qty Saldo pada kode transaksi LSG kurang dari 0, silahkan di cek lagi");
                    return; 
                }

                if (Convert.ToDecimal(GV_PenerimaanUM.Rows[1].Cells[4].Value) < 0)
                {
                    MessageBox.Show("Qty Saldo pada kode transaksi SBD kurang dari 0, silahkan di cek lagi");
                    return;
                }

                int xx = 0;
                Guid PenjualanRowID = (Guid)GV_Penjualan.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                String KodeTrans = "";
                Guid PenerimaanUMRowID = Guid.Empty;
                using (Database db = new Database(GlobalVar.DBShowroom))
                {
                    foreach (DataGridViewRow row in GV_PenerimaanUM.Rows)
                    {
                        //if (Convert.ToDecimal(row.Cells["Saldo"].Value) < 0)
                        //{
                        //    MessageBox.Show("Terdapat saldo < 0, silahkan di cek ulang.");
                        //    return;
                        //}
                        if (Convert.ToDecimal(Tools.isNull(row.Cells["Iden"].Value.ToString(),0)) > 0)
                        {
                            KodeTrans = row.Cells["KodeTrans"].Value.ToString();
                            PenerimaanUMRowID = Guid.NewGuid();

                            db.Commands.Add(db.CreateCommand("usp_PenerimaanUM_INSERT"));
                            db.Commands[xx].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, PenerimaanUMRowID));
                            db.Commands[xx].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, PenjualanRowID));
                            db.Commands[xx].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, GlobalVar.CabangID));
                            db.Commands[xx].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, "K" + Numerator.NextNumber("NKJ")));
                            db.Commands[xx].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "Identifikasi - " + txt_NoPembayaran.Text));

                            //if (KodeTrans == "LSG")
                            //{
                            //    db.Commands[xx].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "PENERIMAAN PIUTANG LEASING - "
                            //        + GV_Penjualan.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString() + " - "
                            //        + GV_Penjualan.SelectedCells[0].OwningRow.Cells["Customer"].Value.ToString()));
                            //}
                            //else
                            //{
                            //    db.Commands[xx].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, "PENERIMAAN SUBSIDI LEASING - " 
                            //        + GV_Penjualan.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString() + " - " 
                            //        + GV_Penjualan.SelectedCells[0].OwningRow.Cells["Customer"].Value.ToString()));
                            //}
                            db.Commands[xx].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, KodeTrans));
                            db.Commands[xx].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, GlobalVar.GetServerDate.Date));
                            db.Commands[xx].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, GV_Penjualan.SelectedCells[0].OwningRow.Cells["MataUangID"].Value.ToString()));
                            db.Commands[xx].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Convert.ToDecimal(row.Cells["Iden"].Value)));
                            db.Commands[xx].Parameters.Add(new Parameter("@NilaiBG", SqlDbType.Money, Convert.ToDecimal(0)));
                            db.Commands[xx].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[xx].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[xx].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            if (dt.Rows[0]["RekeningRowID"].ToString() == "")
                            {
                                db.Commands[xx].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 1));
                            }
                            else
                            {
                                db.Commands[xx].Parameters.Add(new Parameter("@RekeningRowID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["RekeningRowID"]));
                                db.Commands[xx].Parameters.Add(new Parameter("@BentukPembayaran", SqlDbType.SmallInt, 2));
                            }
                            db.Commands[xx].Parameters.Add(new Parameter("@PenerimaanUangRowID", SqlDbType.UniqueIdentifier, PenerimaanUangRowID));
                            xx++;
                        }
                    }
                    db.BeginTransaction();
                    for (int a = 0; a < xx; a++)
                    {
                        db.Commands[a].ExecuteNonQuery();
                    }
                    db.CommitTransaction();

                    SaldoAwal = (SaldoAwal
                    - Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[0].Cells["iden"].Value, 0))
                    - Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[1].Cells["iden"].Value, 0)));
                }
                MessageBox.Show("Data berhasil dimasukkan.");
                RefreshDetail();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GV_Penjualan_SelectionRowChanged(object sender, EventArgs e)
        {
                RefreshDetail();
        }

        private void GV_PenerimaanUM_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GV_PenerimaanUM.Rows.Count > 0)
            {
                txt_Saldo.Text = (SaldoAwal
                                    - Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[0].Cells["iden"].Value, 0))
                                    - Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[1].Cells["iden"].Value, 0))
                                ).ToString();
                
                Decimal Iden = Convert.ToDecimal(Tools.isNull(GV_PenerimaanUM.Rows[e.RowIndex].Cells["iden"].Value, 0));
                DataRow drr = (DataRow)(GV_PenerimaanUM.Rows[e.RowIndex].DataBoundItem as DataRowView).Row; 
                if(e.RowIndex == 0)
                {
                    drr["Saldo"] = (SaldoAwalLSG - Iden);
                }
                else
                {
                    drr["Saldo"] = (SaldoAwalSBD - Iden);
                }


                if (Convert.ToDecimal(txt_Saldo.Text) != Convert.ToDecimal(SaldoAwal))
                {
                    GV_Penjualan.Enabled = false;
                    GV_Penjualan.ReadOnly = true;
                }
                else
                {
                    GV_Penjualan.Enabled = true;
                    GV_Penjualan.ReadOnly = false;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (this.Caller is Kasir.frmPenerimaanLeasingBrowse)
            {
                Kasir.frmPenerimaanLeasingBrowse frmCaller = (Kasir.frmPenerimaanLeasingBrowse)this.Caller;
                frmCaller.RefreshHeader(PenerimaanUangRowID);
                frmCaller.RefreshDetail(Guid.Empty);
            }
            this.Close();
        }

        private void GV_Penjualan_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Hanya boleh memasukkan angka.");
        }

        private void GV_PenerimaanUM_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Hanya boleh memasukkan angka.");
        }
    }
}
