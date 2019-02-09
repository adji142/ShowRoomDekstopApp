using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL ;

namespace ISA.Showroom.Finance.PiutangKaryawan
{
    public partial class FrmPiutangKaryawanUpdateDetail : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update, Approve };
        enumFormMode FormMode;
        Guid _headerID,_detailID;
        string _kdTrans; 
        Double Saldototal;
        DataTable dt;
        Double SaldoTotalPiutang;
        Class.FillComboBox fcbo = new Class.FillComboBox();

        public FrmPiutangKaryawanUpdateDetail()
        {
            InitializeComponent();
        }

        public FrmPiutangKaryawanUpdateDetail(Form caller,Guid headerID,Double Saldo)
        {
            InitializeComponent();
            FormMode = enumFormMode.New;
            Saldototal = Saldo;
            _headerID = headerID;
            this.Caller = caller;
        }

        public FrmPiutangKaryawanUpdateDetail(Form caller,Guid headerID,Guid rowID )
        {
            InitializeComponent();
            FormMode = enumFormMode.Update ;
            _headerID = headerID;
            _detailID = rowID;
            this.Caller = caller;
        }

   

        private void PiutangKaryawanUpdateDetail_Load(object sender, EventArgs e)
        {
            rdoPembayaran.Checked = true;
            rdoPotongan.Checked = false;
            rdoPotongan.Enabled = false;
            if (rdoPembayaran.Checked == false && rdoPotongan.Checked == false)
            {
                cmdSave.Enabled = false;
                cboKas.Enabled = false;
            }
            else
            {
                LoadDetail();
                if (SaldoTotalPiutang == Convert.ToDouble(0.00))
                {
                    cmdSave.Enabled = false;
                    cboKas.Enabled = false;
                }
                else

                {
                    fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                    if (cboKas.Items.Count > 1)
                    {
                        cboKas.SelectedIndex = 1;
                    }
                    cmdSave.Enabled = true;
                    cboKas.Enabled = true;
                }

            }
            txtTanggalDetail.Focus();
           // frmLoadDetail();
        }

        private void commonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region function


        private void LoadPiutangBayar()
        { 
            
        }

        private void LoadDetail()
        {
            

            //switch (FormMode)
            //{
            //    case enumFormMode.New:
            //        {


                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanHeaderIsApproval_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headerID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }


                        txtNamaPeminjam.Text = Tools.isNull(dt.Rows[0]["NamaKaryawan"], "").ToString();
                        
                        SaldoTotalPiutang = (Double)dt.Rows[0]["saldo"];
                        if (SaldoTotalPiutang != 0.00)
                        {
                            txtSaldoPinjaman.Text = SaldoTotalPiutang.ToString();
                        }
                        else
                        {
                            txtSaldoPinjaman.Text = Saldototal.ToString();
                        }

                        txtTanggalDetail.DateValue = GlobalVar.GetServerDate;
                        // txtTanggalDetail.Enabled = false; // mau bisa input 3 hari ke belakang soalnya
                        /*
                        txtKeteranganDetail.Enabled = false;
                        txtNominalDetail.Enabled = false;
                        */
                        
                        
                        this.Cursor = Cursors.Default;


                        switch (FormMode)
                        {
                            case enumFormMode.Update: frmEditDetail(); break;
                            default: break;
                        }
        //                break;
        //            }
        //        case enumFormMode.Update:
        //            {
        //                break;
        //            }
        //}
    }
    

        





        private void  frmLoadDetail()
        { 
            this.Cursor = Cursors.WaitCursor;
//            if (FormMode == enumFormMode.New)
//            {

            switch (FormMode)
            {
                case enumFormMode.Update: frmEditDetail(); break;
                default: break;
            }


                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanHeaderIsApproval_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headerID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                //display data           


                txtNamaPeminjam.Text = Tools.isNull(dt.Rows[0]["NamaKaryawan"], "").ToString();
                
                SaldoTotalPiutang = (Double)dt.Rows[0]["saldo"];
                if (SaldoTotalPiutang != 0.00)
                {
                    txtSaldoPinjaman.Text = SaldoTotalPiutang.ToString();
                }
                else
                {
                    txtSaldoPinjaman.Text = Saldototal.ToString();
                }
              // txtSaldoPinjaman.Text = Tools.isNull(dt.Rows[0]["Saldo"], "").ToString();

                txtTanggalDetail.DateValue = GlobalVar.GetServerDate;
                // txtTanggalDetail.Enabled = false; // mau bisa input 3 hari ke belakang soalnya
                txtKeteranganDetail.Enabled = false;
                txtNominalDetail.Enabled = false;


                this.Cursor = Cursors.Default;
//            }
        

        }

        private void frmEditDetail()
        {

            this.Cursor = Cursors.WaitCursor;
            if (FormMode == enumFormMode.Update)
            {
                dt = new DataTable();
                using (Database db = new Database()) 

                {
                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanPembayaran_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _detailID ));
                    dt = db.Commands[0].ExecuteDataTable();
                
                }
                
                txtNoBuktiDetail.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                txtTanggalDetail.DateValue  = (DateTime)Tools.isNull(dt.Rows[0]["TanggalBayar"], "");
                txtKeteranganDetail.Text  = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                txtNominalDetail.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();

                Guid KasRowID = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                cboKas.SelectedValue = KasRowID;

                label1.Text = Tools.isNull(dt.Rows[0]["KdTransaksi"], "").ToString();
                if (label1.Text == "KAS") rdoPembayaran.Checked =true    ;
                if (label1.Text == "POT") rdoPotongan.Checked = true;
                this.Cursor = Cursors.Default;
            }


        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPiutangKaryawanBrowse)
                {
                    frmPiutangKaryawanBrowse frmCaller = (frmPiutangKaryawanBrowse)this.Caller;
                    frmCaller.RefreshDataHeaderPiutangKaryawan();
                    frmCaller.FindRowHeader("HeaderRowID", (String)_headerID.ToString());
                    frmCaller.RefreshDataHeaderPiutangKaryawan();
                    frmCaller.RefreshDetail();
                    frmCaller.FindRowDetail("NoBuktiDetail", txtNoBuktiDetail.Text);
                }
            }
        }

        #endregion 

        private void cmdSave_Click(object sender, EventArgs e)
        {
            float nbyr = float.Parse(txtNominalDetail.Text);
            float nSld = float.Parse(txtSaldoPinjaman.Text);
            if (nbyr > nSld)
            {
                MessageBox.Show("Total Pembayaran melebihi Piutang Karyawan!"); 
                return;
            } 
            else if(cboKas.SelectedValue == null || cboKas.SelectedValue == "" || (Guid) cboKas.SelectedValue == Guid.Empty)
            {
                MessageBox.Show("Pilih bentuk Kas terlebih dahulu!");
                return;
            }
            else if (txtTanggalDetail.Text == "" || txtTanggalDetail.Text == null)
            {
                MessageBox.Show("Isikan tanggal terlebih dahulu!");
                return;
            }
            else if (txtTanggalDetail.DateValue != null &&
                     (txtTanggalDetail.DateValue.Value < GlobalVar.GetServerDate.Date.AddDays(-3) || txtTanggalDetail.DateValue.Value > GlobalVar.GetServerDate.Date ))
            {
                MessageBox.Show("Hanya dapat memproses data untuk tanggal hari ini sampai H-3 !");
                return;
            }
            else
            {
                try
                {
                    switch (FormMode)
                    {
                        case enumFormMode.New:
                            {
                                //if (Tools.isNull(txtNoBuktiDetail.Text, "").ToString() == "")
                                //    txtNoBuktiDetail.Text = Numerator.GetNomorDokumen("PENERIMAAN_KAS", "",
                                //                    "/BKM/" + string.Format("{0:yyMM}",GlobalVar.GetServerDate)
                                //                    , 3, false, true);

                                using (Database db = new Database())
                                {

                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanPembayaran_INSERT"));
                                    //db.Commands[0].Parameters.Add(new Parameter("@PiutangKaryawanRowID", SqlDbType.UniqueIdentifier, _headerID ));
                                    db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID", SqlDbType.UniqueIdentifier, _headerID));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBuktiDetail.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@TanggalBayar", SqlDbType.DateTime, txtTanggalDetail.DateValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeteranganDetail.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, float.Parse(txtNominalDetail.Text)));
                                    db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].Parameters.Add(new Parameter("@KdTransaksi", SqlDbType.VarChar, _kdTrans));
                                    dt = db.Commands[0].ExecuteDataTable();

                                }

                                break;
                            }

                        case enumFormMode.Update:
                            {

                                using (Database db = new Database())
                                {

                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawanPembayaran_UPDATE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _detailID));
                                    db.Commands[0].Parameters.Add(new Parameter("@TanggalBayar", SqlDbType.DateTime, txtTanggalDetail.DateValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeteranganDetail.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, float.Parse(txtNominalDetail.Text)));
                                    db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@KdTransaksi", SqlDbType.VarChar, _kdTrans));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    dt = db.Commands[0].ExecuteDataTable();

                                }

                                break;
                            }
                    }
                    this.DialogResult = DialogResult.OK;
                    closeForm();
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void rdoPembayaran_CheckedChanged(object sender, EventArgs e)
        {
            _kdTrans = "KAS";
            groupBox1.Text = "Pembayaran";
            txtTanggalDetail.Enabled = true;
            txtKeteranganDetail.Enabled = true;
            txtNominalDetail.Enabled = true;
            txtKeteranganDetail.Focus();
            label1.Text = "KAS";

            switch (FormMode)
            {
                case enumFormMode.New:
                    {
                        fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                        break;
                    }

            }
          
            cboKas.Enabled = true;
           
            if (txtSaldoPinjaman.GetDoubleValue==0.0)
            {
                cmdSave.Enabled = false;
            }
            else
            {
                cmdSave.Enabled = true;
            }

        }

        private void rdoPotongan_CheckedChanged(object sender, EventArgs e)
        {
            _kdTrans = "POT";
            groupBox1.Text = "Potongan";
            txtTanggalDetail.Enabled = true;
            txtKeteranganDetail.Enabled = true;
            txtNominalDetail.Enabled = true;
            txtKeteranganDetail.Focus();
            label1.Text = "POT";

            cboKas.Enabled = false;
            fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
            cboKas.SelectedIndex = 0;
            if (txtSaldoPinjaman.GetDoubleValue==0.0)
            {
                cmdSave.Enabled = false;
            }
            else
            {
                cmdSave.Enabled = true;
            }
        }

        private void FrmPiutangKaryawanUpdateDetail_Shown(object sender, EventArgs e)
        {
            txtTanggalDetail.Focus();
        }

                      
        
    }    
}