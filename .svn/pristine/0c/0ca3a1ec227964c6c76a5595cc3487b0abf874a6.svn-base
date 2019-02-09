using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Data.SqlTypes;

namespace ISA.Showroom.Penjualan
{
    public partial class frmKonversiUpdate : ISA.Controls.BaseForm
    {
        Guid _rowID, _penjRowID, _pembRowID, _salesRowID;

        string _keterangan = "";
        string _cabangID = GlobalVar.CabangID;
        DateTime _tglJT;

        public frmKonversiUpdate(Form caller, Guid penjRowID)
        {
            InitializeComponent();
            this.Caller = caller;
            _rowID = Guid.NewGuid();
            _penjRowID = penjRowID;
        }

        private void ListAngsuran()
        {
            cboJnsAngsuran.DisplayMember = "Text";
            cboJnsAngsuran.ValueMember = "Value";
            var items = new[] {
                            new { Text = "BUNGA MENURUN", Value = "APD" },
                            new { Text = "BUNGA TETAP / FLAT", Value = "FLT" }
                        };
            cboJnsAngsuran.DataSource = items;
        }

        private void ListPembulatan()
        {
            cboPembulatan.DisplayMember = "Text";
            cboPembulatan.ValueMember = "Value";
            var items = new[] {
                new { Text = "0", Value = "0" },
                new { Text = "50", Value = "50" },
                new { Text = "100", Value = "100" }
            };
            cboPembulatan.DataSource = items;
        }

        private void frmKonversiUpdate_Load(object sender, EventArgs e)
        {
            this.ListAngsuran();
            this.ListPembulatan();            

            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Konversi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    dt = db.Commands[0].ExecuteDataTable();

                    lblNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    lblAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    lblKelkec.Text = Tools.isNull(dt.Rows[0]["KelKec"], "").ToString();
                    lblKotaProv.Text = Tools.isNull(dt.Rows[0]["KotaProv"], "").ToString();
                    lblTglJual.Text = String.Format("{0:dd-MM-yyyy}", (DateTime)dt.Rows[0]["TglJual"]);
                    lblNoFaktur.Text = Tools.isNull(dt.Rows[0]["NoFaktur"], "").ToString();
                    lblNoTrans.Text = Tools.isNull(dt.Rows[0]["NoTrans"], "").ToString();
                    lblJnsPenjualan.Text = Tools.isNull(dt.Rows[0]["JnsPenjualan"], "").ToString();
                    lblMerkType.Text = Tools.isNull(dt.Rows[0]["Merk"], "").ToString() + " / " + Tools.isNull(dt.Rows[0]["Type"], "").ToString();;
                    lblHargaJadi.Text = Tools.isNull(dt.Rows[0]["HargaJadi"], 0).ToString();
                    lblBBN.Text = Tools.isNull(dt.Rows[0]["BBN"], "").ToString();
                    lblHargaTotal.Text = (Convert.ToDouble(lblHargaJadi.Text) + Convert.ToDouble(lblBBN.Text)).ToString();
                    _pembRowID = (Guid)Tools.isNull(dt.Rows[0]["PembRowID"], "");
                    _salesRowID = (Guid)Tools.isNull(dt.Rows[0]["SalesRowID"], "");
                    _keterangan = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();

                    DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                    dt2.DefaultView.Sort = "MataUangID ASC";
                    cboMataUang.DisplayMember = "MataUangID";
                    cboMataUang.ValueMember = "MataUangID";
                    cboMataUang.DataSource = dt2.DefaultView;

                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }

                    txtTglLunas.DateValue = GlobalVar.GetServerDate;
                    txtUangMuka.Text = Tools.isNull(dt.Rows[0]["UangMuka"], 0).ToString();
                    txtPiutangPokok.Text = (Convert.ToDouble(lblHargaTotal.Text) - Convert.ToDouble(txtUangMuka.Text)).ToString();
                    txtPiutangBunga.Text = "0";
                    txtJumlahPiutang.Text = (Convert.ToDouble(lblHargaTotal.Text) - Convert.ToDouble(txtUangMuka.Text)).ToString();
                    numKredit.Value = 0;
                    txtBunga.Text = "0.00";
                    numTgl.Value = int.Parse(String.Format("{0:dd}", txtTglLunas.DateValue));
                    txtAwalAngs.DateValue = txtTglLunas.DateValue;
                    _tglJT = (DateTime)txtAwalAngs.DateValue;
                    txtAkhirAngs.DateValue = _tglJT.AddMonths(int.Parse(numKredit.Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKonversiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmKonversiBrowse)
            {
                Penjualan.frmKonversiBrowse frmCaller = (Penjualan.frmKonversiBrowse)this.Caller;
                frmCaller.refreshHeader(_penjRowID);
            }
        }

        private void hitung()
        {
            try
            {  
                if ((cboJnsAngsuran.SelectedValue.ToString() == "APD") &&
                    (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(numKredit.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 0))
                {   /*
                    Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                     "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                     "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                     "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                     "  FROM dbo.fn_HitungBungaMenurun (@Pokok,@Jml,@Bunga) ");
                    cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtPiutangPokok.Text);
                    cmdAngs.AddParameter("@Jml", SqlDbType.Int, numKredit.Text);
                    cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga.Text);
                    DataTable dtAngs = cmdAngs.ExecuteDataTable();
                    */
                    DataTable dtAngs = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangMenurun"));
                        db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtPiutangPokok.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, numKredit.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga.Text));
                        dtAngs = db.Commands[0].ExecuteDataTable();
                    }

                    if (cboPembulatan.SelectedValue.ToString() == "0")
                    {
                        txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                        txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                    }
                    else if (cboPembulatan.SelectedValue.ToString() == "50")
                    {
                        txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                        txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                    }
                    else if (cboPembulatan.SelectedValue.ToString() == "100")
                    {
                        txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                        txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                    }
                }                
                else if ((cboJnsAngsuran.SelectedValue.ToString() == "FLT") &&
                    (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(numKredit.Text, 0)) > 0) &&
                    (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) > 0))
                {   /*
                    Command cmdAngs = new Command(new Database(), CommandType.Text,
                                                     "SELECT ROUND(SUM(Interest), -2, 1) + 0 AS Bunga0,     " +
                                                     "       ROUND(SUM(Interest), -2, 1) + 50 AS Bunga50,   " +
                                                     "       ROUND(SUM(Interest), -2, 1) + 100 AS Bunga100  " +
                                                     "  FROM dbo.fn_HitungBungaTetap (@Pokok,@Jml,@Bunga) ");
                    cmdAngs.AddParameter("@Pokok", SqlDbType.Money, txtPiutangPokok.Text);
                    cmdAngs.AddParameter("@Jml", SqlDbType.Int, numKredit.Text);
                    cmdAngs.AddParameter("@Bunga", SqlDbType.Decimal, txtBunga.Text);
                    DataTable dtAngs = cmdAngs.ExecuteDataTable();
                    */
                    DataTable dtAngs = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Angsuran_GetPembulatan_PiutangTetap"));
                        db.Commands[0].Parameters.Add(new Parameter("@Pokok", SqlDbType.Money, txtPiutangPokok.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Jml", SqlDbType.Int, numKredit.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, txtBunga.Text));
                        dtAngs = db.Commands[0].ExecuteDataTable();
                    }


                    if (cboPembulatan.SelectedValue.ToString() == "0")
                    {
                        txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga0"], 0).ToString();
                        txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                    }
                    else if (cboPembulatan.SelectedValue.ToString() == "50")
                    {
                        txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga50"], 0).ToString();
                        txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                    }
                    else if (cboPembulatan.SelectedValue.ToString() == "100")
                    {
                        txtPiutangBunga.Text = Tools.isNull(dtAngs.Rows[0]["Bunga100"], 0).ToString();
                        txtJumlahPiutang.Text = (Convert.ToDouble(Tools.isNull(txtPiutangPokok.Text, 0)) + Convert.ToDouble(Tools.isNull(txtPiutangBunga.Text, 0))).ToString();
                    }
                }                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(txtAwalAngs.Text))
                {
                    MessageBox.Show("Awal Angsuran belum diisi !");
                    txtAwalAngs.Focus();
                    return;
                }
                if (int.Parse(string.Format("{0:dd}", (DateTime)txtAwalAngs.DateValue)) != numTgl.Value)
                {
                    MessageBox.Show("Tanggal Awal Angsuran tidak sama dengan Tanggal Jatuh Tempo !");
                    txtAwalAngs.Focus();
                    return;
                }
                if (Convert.ToDouble(Tools.isNull(txtBunga.Text, 0)) == 0)
                {
                    MessageBox.Show("Bunga belum diisi !");
                    txtBunga.Focus();
                    return;
                }
                if (((DateTime) txtTglLunas.DateValue).Date < GlobalVar.GetServerDate.Date)
                {
                    MessageBox.Show("Tanggal lebih kecil dari pada tanggal hari ini !");
                    txtTglLunas.Focus();
                    return;
                }
                if (txtAwalAngs.DateValue < txtTglLunas.DateValue)
                {
                    MessageBox.Show("Tanggal Awal Angsuran lebih kecil dari pada Tanggal !");
                    txtAwalAngs.Focus();
                    return;
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Konversi_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PenjRowID", SqlDbType.UniqueIdentifier, _penjRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, _pembRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTrans", SqlDbType.VarChar, lblNoTrans.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, lblNoFaktur.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJual", SqlDbType.DateTime, txtTglLunas.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@SalesRowID", SqlDbType.UniqueIdentifier, _salesRowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KolektorRowID", SqlDbType.UniqueIdentifier, lookUpKolektor1._Kolektor.RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Penjualan", SqlDbType.VarChar, "K"));
                    db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HargaJadi", SqlDbType.Money, lblHargaJadi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@BBN", SqlDbType.Money, lblBBN.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTrans", SqlDbType.VarChar, cboJnsAngsuran.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJT", SqlDbType.VarChar, numTgl.Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@UangMuka", SqlDbType.Money, txtUangMuka.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAwalAngs", SqlDbType.Date, txtAwalAngs.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAkhirAngs", SqlDbType.Date, txtAkhirAngs.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Bunga", SqlDbType.Decimal, Convert.ToDecimal(txtBunga.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@Pembulatan", SqlDbType.Int, int.Parse(cboPembulatan.SelectedValue.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@TempoAngsuran", SqlDbType.Int, numKredit.Value));                    
                    db.Commands[0].Parameters.Add(new Parameter("@PiutangBunga", SqlDbType.Money, txtPiutangBunga.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@PiutangPokok", SqlDbType.Money, txtPiutangPokok.Text));                    
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, _keterangan));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil ditambahkan");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal ditambahkan !\n " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void numKredit_ValueChanged(object sender, EventArgs e)
        {
            this.hitung();
            _tglJT = (DateTime)txtAwalAngs.DateValue;
            txtAkhirAngs.DateValue = _tglJT.AddMonths(int.Parse(numKredit.Value.ToString()));
        }

        private void txtBunga_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtBunga.Text) <= 100)
            {
                this.hitung();
            }
        }

        private void cboPembulatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hitung();
        }

        private void cboJnsAngsuran_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hitung();
        }

        private void txtAwalAngs_TextChanged(object sender, EventArgs e)
        {
            _tglJT = (DateTime)txtAwalAngs.DateValue;
            txtAkhirAngs.DateValue = _tglJT.AddMonths(int.Parse(numKredit.Value.ToString()));
        }

        private void numKredit_Leave(object sender, EventArgs e)
        {
            _tglJT = (DateTime)txtAwalAngs.DateValue;
            txtAkhirAngs.DateValue = _tglJT.AddMonths(int.Parse(numKredit.Value.ToString()));
        }
    }
}
