using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Showroom.Class;
using System.Globalization;

namespace ISA.Showroom.Penjualan
{
    public partial class frmKonsinyasiUpdate : ISA.Controls.BaseForm
    {
        enum FormMode { New, Update };
        FormMode mode = new FormMode();

        Guid _rowID, _pembRowID;
        string _cabangID = GlobalVar.CabangID;
        Double _nominal;

        public frmKonsinyasiUpdate(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.New;
            _rowID = Guid.NewGuid();
        }

        public frmKonsinyasiUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            this.Caller = caller;
            mode = FormMode.Update;
            _rowID = rowID;
        }

        private void frmKonsinyasiUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = FillComboBox.DBGetCabang("");
                dt.DefaultView.Sort = "NamaPanjang ASC";
                cboCabang.DisplayMember = "NamaPanjang";
                cboCabang.ValueMember = "CabangID";
                cboCabang.DataSource = dt.DefaultView;

                DataTable dt2 = FillComboBox.DBGetMataUang(Guid.Empty, "");
                dt2.DefaultView.Sort = "MataUangID ASC";
                cboMataUang.DisplayMember = "MataUangID";
                cboMataUang.ValueMember = "MataUangID";
                cboMataUang.DataSource = dt2.DefaultView;

                if (mode == FormMode.New)
                {
                    
                    lookUpStokMotor1.txtNopol.Text = "";
                    txtTanggal.DateValue = GlobalVar.GetServerDate;
                    txtHarga.Text = "0";
                    
                    DataTable dummyMU = new DataTable();
                    using (Database dbsubMU = new Database())
                    {
                        dbsubMU.Commands.Add(dbsubMU.CreateCommand("usp_AppSetting_LIST"));
                        dbsubMU.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DEFMATAUANG"));
                        dummyMU = dbsubMU.Commands[0].ExecuteDataTable();
                        cboMataUang.Text = dummyMU.Rows[0]["Value"].ToString();
                    }
                }
                else
                {
                    DataTable _dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Konsinyasi_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _cabangID));
                        _dt = db.Commands[0].ExecuteDataTable();
                    }
                    lblNoBukti.Text = Tools.isNull(_dt.Rows[0]["Bukti"], "").ToString();
                    _pembRowID = (Guid)Tools.isNull(_dt.Rows[0]["PembRowID"], Guid.Empty);
                    lookUpStokMotor1.txtNopol.Text = Tools.isNull(_dt.Rows[0]["Nopol"], "").ToString();
                    txtTanggal.DateValue = (DateTime)Tools.isNull(_dt.Rows[0]["Tanggal"], DateTime.MinValue);
                    cboMataUang.Text = Tools.isNull(_dt.Rows[0]["MataUangID"], "").ToString();
                    txtHarga.Text = Tools.isNull(_dt.Rows[0]["Harga"], "").ToString();
                    cboCabang.Text = Tools.isNull(_dt.Rows[0]["CabangPenerima"], "").ToString();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKonsinyasiUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Caller is Penjualan.frmKonsinyasiBrowse)
            {
                Penjualan.frmKonsinyasiBrowse frmCaller = (Penjualan.frmKonsinyasiBrowse)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow("Bukti", lblNoBukti.Text);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            RefreshHargaMotor(); 
            try
            {
                if (lookUpStokMotor1._motor.RowID == null || lookUpStokMotor1._motor.RowID == Guid.Empty)
                {
                    MessageBox.Show("Data Motor masih belum terisi, pastikan tombol Search  telah dipilih, untuk konfirmasi Nopol Motor !");
                    txtTanggal.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTanggal.Text))
                {
                    MessageBox.Show("Tanggal belum diisi !");
                    txtTanggal.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(lookUpStokMotor1.txtNopol.Text))
                {
                    MessageBox.Show("Nomor Polisi belum dipilih !");
                    lookUpStokMotor1.txtNopol.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtHarga.Text))
                {
                    MessageBox.Show("Harga belum diisi !");
                    txtHarga.Focus();
                    return;
                }
                if (((DateTime) txtTanggal.DateValue).Date < GlobalVar.GetServerDate.Date)
                {
                    MessageBox.Show("Tanggal Pelunasan lebih kecil dari pada tanggal hari ini !");
                    txtTanggal.Focus();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                switch (mode)
                {
                    case FormMode.New:
                        
                        lblNoBukti.Text = Numerator.NextNumber("KON");
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Konsinyasi_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));                            
                            db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotor1._motor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, lblNoBukti.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@PengirimCabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaCabangID", SqlDbType.VarChar, cboCabang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Harga", SqlDbType.Money, txtHarga.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrintMilliseconds()));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Data berhasil ditambahkan");
                        break;
                    case FormMode.Update:                       
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Konsinyasi_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@PembRowID", SqlDbType.UniqueIdentifier, lookUpStokMotor1._motor.RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, lblNoBukti.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@PengirimCabangID", SqlDbType.VarChar, _cabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@PenerimaCabangID", SqlDbType.VarChar, cboCabang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@MataUangID", SqlDbType.VarChar, cboMataUang.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Harga", SqlDbType.Money, txtHarga.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Data berhasil diupdate");
                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal diupdate !\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void lookUpStokMotor1_Leave(object sender, EventArgs e)
        {
            RefreshHargaMotor();
        }

        private void lookUpStokMotor1_Click(object sender, EventArgs e)
        {
            RefreshHargaMotor();
        }

        private void RefreshHargaMotor()
        {
            if (lookUpStokMotor1._motor != null)
            {
                double tempharga = 0;
                tempharga = Convert.ToDouble(lookUpStokMotor1._motor.HargaJadi.ToString()) + Convert.ToDouble(lookUpStokMotor1._motor.BiayaRep.ToString()) + Convert.ToDouble(lookUpStokMotor1._motor.BiayaTam.ToString());
                txtHarga.Text = tempharga.ToString();
            }
        }

        private void frmKonsinyasiUpdate_MouseEnter(object sender, EventArgs e)
        {
            RefreshHargaMotor();
        }

        private void frmKonsinyasiUpdate_MouseMove(object sender, MouseEventArgs e)
        {
            RefreshHargaMotor();
        }

        
    }
}
