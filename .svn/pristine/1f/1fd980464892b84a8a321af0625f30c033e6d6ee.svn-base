using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Net;
using System.Net.Mail;

namespace ISA.Showroom.Finance.PiutangKaryawan
{
    public partial class FrmPiutangKaryawanUpdateHeader : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update, Approve };
        enumFormMode FormMode;
        Guid _rowID;  
        string NoBuktiSementara,UserAcc1,UserAcc2;
        int _statusApproval = 0;
        DataTable dt;
        int IsNeedAcc2;
        String SubmitorAccBy;
        Guid _karyawanRowID;
        Double _totalPinjaman;
        Class.FillComboBox fcbo = new Class.FillComboBox();
        Guid RowIDPiutangKaryawan;
        SmtpClient _smtpClient = new SmtpClient();
        MailMessage _mail = new MailMessage();
        bool hasRight_pk;

       public FrmPiutangKaryawanUpdateHeader()
        {
            InitializeComponent();
        }

       public FrmPiutangKaryawanUpdateHeader(Form caller)
        {
            InitializeComponent();
            FormMode = enumFormMode.New;
            this.Caller = caller;
        }

        public FrmPiutangKaryawanUpdateHeader(Form caller,Guid KaryawanRowId,Double TotalPinjaman)
        {
            InitializeComponent();
            FormMode=enumFormMode.New;
            _karyawanRowID =KaryawanRowId;
            _totalPinjaman = TotalPinjaman;

            this.Caller = caller;
        }


       public FrmPiutangKaryawanUpdateHeader(Form caller, Guid rowID,Guid KaryawanRowID)
        {
            InitializeComponent();
            FormMode = enumFormMode.Update;
            _rowID = rowID;
            _karyawanRowID = KaryawanRowID;
            this.Caller = caller;
        }

       private void FrmPiutangKaryawanUpdateHeader_Load(object sender, EventArgs e)
        {
            //try
            //{

            hasRight_pk = SecurityManager.HasRight("FIN.PK");
            RefreshData();

            txtTanggal.Focus();
            txtTanggal.DateValue = GlobalVar.GetServerDate;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

       private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            closeForm();
            this.Close();
        }

       private void commandButton1_Click(object sender, EventArgs e)
        {

        }

       private Guid GetRowID()
       {
          
           if (_rowID != Guid.Empty)
           {
               return _rowID;
           }
           else
           {
               return RowIDPiutangKaryawan;
           }
       }



       private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {

                if (cboPeminjam.Text.ToString()=="" || cboPeminjam.Text.ToString()==null)
                {
                    MessageBox.Show("Maaf, peminjam belum dipilih.");
                    cboPeminjam.Focus();
                    return;
                }

                if (cboKas.SelectedIndex.Equals(0)) {
                    MessageBox.Show("Jenis Kas belum dipilih.");
                    cboKas.Focus();
                    return;
                }
                if ( txtTanggal.DateValue != null &&
                     (txtTanggal.DateValue.Value < GlobalVar.GetServerDate.Date.AddDays(-3) || txtTanggal.DateValue.Value > GlobalVar.GetServerDate.Date))
                {
                    MessageBox.Show("Hanya dapat memproses data untuk tanggal hari ini sampai H-3 !");
                    return;
                }

                switch (FormMode)
                {
                    // Jika Tambah
                    case enumFormMode.New:
                            //Jika Nominal Pinjaman tidak diisi
                            float nNominal = float.Parse(txtNominal.Text);
                            if (nNominal == 0)
                            {
                                MessageBox.Show("Nominal Pinjaman 0  ");
                                return;
                            }
                            HirarkiAccPK();
                            //if (Tools.isNull(txtNoBukti.Text, "").ToString() == "")
                            //    txtNoBukti.Text = Numerator.GetNomorDokumen("PENGAJUAN_PIUTANGKARYAWAN", "",
                            //                        "/P/" + string.Format("{0:yyMM}", GlobalVar.GetServerDate )
                            //                        , 3, false, true);

                            RowIDPiutangKaryawan = Guid.NewGuid();

                                using (Database db = new Database())
                                {
                                    DataTable dt = new DataTable();
                                    db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_INSERT"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDPiutangKaryawan));
                                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, txtTanggal.DateValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID", SqlDbType.UniqueIdentifier, cboPeminjam.SelectedValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, float.Parse(txtNominal.Text)));
                                    db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].Parameters.Add(new Parameter("@AlasanPinjam", SqlDbType.VarChar, txtAlasanPinjam.Text));
                                    db.Commands[0].Parameters.Add(new Parameter("@UserAcc1", SqlDbType.VarChar, UserAcc1));
                                    db.Commands[0].Parameters.Add(new Parameter("@UserAcc2", SqlDbType.VarChar, UserAcc2));
                                    dt = db.Commands[0].ExecuteDataTable();

                                    //if (dt.Rows.Count > 0)
                                    //{
                                    //    MessageBox.Show("No.Bukti : " + txtNoBukti.Text + " Sudah terdaftar di database");
                                    //    txtNoBukti.Text = string.Empty;
                                    //    txtNoBukti.Focus();
                                    //    return;
                                    //}
                                    //else
                                    //{
                                    //    db.Commands.Clear();
                                    //    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST_FILTER_NoBukti"));
                                    //    db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, txtNoBukti.Text));
                                    //    dt = db.Commands[0].ExecuteDataTable();
                                    //if (dt.Rows.Count > 0) _rowID = (Guid)Tools.isNull(dt.Rows[0]["RowID"], Guid.Empty);
                                    //FormMode = enumFormMode.Update;
                                    //RefreshData();

                                    //}
                                }
                                MessageBox.Show(Messages.Confirm.SaveSuccess);
                        break;
                    // Jika Edit
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_UPDATE"));

                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, GetRowID()));
                            db.Commands[0].Parameters.Add(new Parameter("@KaryawanRowID", SqlDbType.UniqueIdentifier, cboPeminjam.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Float, float.Parse(txtNominal.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@AlasanPinjam", SqlDbType.VarChar, txtAlasanPinjam.Text));
                            dt = db.Commands[0].ExecuteDataTable();

                            MessageBox.Show(Messages.Confirm.UpdateSuccess);
                        }
                        break;
                    // Save Approval  
                    case enumFormMode.Approve:
                        {
                            switch (_statusApproval)
                            {
                                case 1: break;
                                case 2: break;
                                default: break;
                            }
                        }
                        break;
                }
               // DateTime bataswaktu = (DateTime)Tools.DBGetScalar("usp_GetBackDatedLock", new List<Parameter>());
                LoadAfterNew();     
                this.DialogResult = DialogResult.OK;
                closeForm();
                
                //LoadEdit();
               //this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

       private void grpApproval_Enter(object sender, EventArgs e)
        {

        }



       private bool SendingEmail(String EmailTo,bool disetujui,bool tolak)
       {
           //String EmailUserAcc = String.Empty;
           //String EmailSubject = String.Empty;
           //String Emailbody=String.Empty;

           //if (EmailTo== String.Empty && tolak==true)
           //{
           //    EmailUserAcc = Properties.Settings.Default.EmailKasir;
           //    EmailSubject = "Tolak PK";
           //    Emailbody = "Tolak PK oleh :" + SubmitorAccBy + ", untuk pengajuan PK dari karyawan: " + cboPeminjam.Text.ToString() + " karena alasan " + txtAlasanTolak.Text;
           //}

           //if (EmailTo == String.Empty && tolak == false)
           //{
           //    EmailUserAcc = Properties.Settings.Default.EmailKasir;
           //    EmailSubject = "Persetujuan PK";
           //    Emailbody = "Persetujuan PK oleh : " + SubmitorAccBy + ", untuk pengajuan PK dari karyawan: " + cboPeminjam.Text.ToString();
           //}

           //if (EmailTo != String.Empty && disetujui == false && tolak == false)
           //{
           //    EmailSubject = "Acc Piutang Karyawan";
           //    Emailbody = "ACC Pengajuan Piutang Karyawan dengan ID dan nama Karyawan: " + cboPeminjam.Text.ToString() + " oleh " + SubmitorAccBy;
           //    DataTable dt = new DataTable();
           //    using (Database db = new Database())
           //    {
           //        db.Commands.Add(db.CreateCommand("usp_GetEmailUserACCPiutang"));
           //        db.Commands[0].Parameters.Add(new Parameter("@UserId", SqlDbType.VarChar, EmailTo));
           //        dt = db.Commands[0].ExecuteDataTable();
           //    }
           //    if (dt.Rows.Count > 0)
           //    {
           //        EmailUserAcc = dt.Rows[0]["EmailAddress"].ToString();

           //    }
           //}

                    

           //NetworkCredential ncred = new NetworkCredential(Properties.Settings.Default.EmailSenderISA,Properties.Settings.Default.EmailSenderPwd);
           //_smtpClient.Credentials = ncred;

           //_smtpClient.Port =Properties.Settings.Default.PortSendingEmail;
           //    _smtpClient.Host =Properties.Settings.Default.EmailHost ;
           //    _mail.From = new MailAddress(Properties.Settings.Default.EmailSenderISA);
           //    _mail.To.Add(EmailUserAcc);
           //    _mail.Subject = EmailSubject;
           //    _mail.Body = Emailbody;
           //    try
           //    {
           //        this.Cursor = Cursors.WaitCursor;
           //        _smtpClient.Send(_mail);
           //    }
           //    catch 
           //    {
           //        //Error.LogError(Ex);
           //        return false;
           //    }
           //    finally { this.Cursor = Cursors.Default; }
               return true;
       }

    

       private void cmdSubmit_Click(object sender, EventArgs e)
        {
            SubmitorAccBy = SecurityManager.UserID;
            try
            {
                if (SendingEmail("WIWIN", false, false) == true)
                {
                    if ((FormMode != enumFormMode.New) && (_statusApproval == 0))
                    {
                        using (Database db = new Database())
                        {

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_UPDATE_Approve0"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, GetRowID()));
                            db.Commands[0].Parameters.Add(new Parameter("@UserAcc1", SqlDbType.VarChar, txtPICApprove1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        _statusApproval = 1;
                    }
                    RefreshData();

                }
                else
                {
                    MessageBox.Show("Bad Connection.");
                    return;
                }


                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
           
        }

       #region Functions

       private void RefreshData()
        {
           
            
            switch (FormMode)
            {
                case enumFormMode.New:
                    {
                        fcbo.FillComboKaryawan(cboPeminjam, 1,_karyawanRowID);
                        cboPeminjam.Enabled = false;
                        //txtSisapinjam.Text =_totalPinjaman.ToString();//
                         txtSisapinjam.Text =LoadSisaPinjaman().ToString();
                        fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                        if (cboKas.Items.Count > 1)
                        {
                            cboKas.SelectedIndex = 1;
                        }

                        break;
                    }
                case enumFormMode.Update: LoadEdit(); break;
                default: break;
            }
            RefreshAcc();
        }

       private void LoadEdit()
        {
            string CreatedBy ;
            this.Cursor = Cursors.WaitCursor;
            if (FormMode == enumFormMode.Update)
            {
                try
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, GetRowID()));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data           
                    txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
                    //Guid RowIDKaryawan;
                    //RowIDKaryawan = (Guid)dt.Rows[0]["KaryawanRowID"];
                    _karyawanRowID = (Guid)dt.Rows[0]["KaryawanRowID"];
                    fcbo.FillComboKaryawan(cboPeminjam, 1, _karyawanRowID);
                    txtTanggal.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["CreatedOn"], "");
                    txtNominal.Text = Tools.isNull(dt.Rows[0]["NominalPinjaman"], "").ToString();
                    txtAlasanPinjam.Text = Tools.isNull(dt.Rows[0]["AlasanPinjam"], "").ToString();
                    _statusApproval = Convert.ToInt32(dt.Rows[0]["StatusApproval"]);
                    txtPICApprove1.Text = Tools.isNull(dt.Rows[0]["UserIdAcc1"], "").ToString();
                    String _statusAcc2 = Tools.isNull(dt.Rows[0]["StatusAcc2"], "").ToString();
                    int _jumlahAcc = (int)Tools.isNull(dt.Rows[0]["JumlahAcc"], 0);
                    txtAlasanTolak.Text = Tools.isNull(dt.Rows[0]["AlasanTolak"], "").ToString();
                    Guid KasRowID = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
                    fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
                    cboKas.SelectedValue = KasRowID;

                    CreatedBy = Tools.isNull(dt.Rows[0]["CreatedBy"], "").ToString();
                    cboPeminjam.Enabled = false;

                    if (_statusApproval > 0) 
                    { 
                        txtNominal.ReadOnly = true; 
                        txtNominal.TabStop = false; 
                        cboPeminjam.Enabled = false; 
                        cmdSAVE.Enabled = false; 
                        txtAlasanPinjam.Enabled = false; 
                        cboKas.Enabled = false; 
                    }
                    if ((_statusApproval == 8) && hasRight_pk)//&& (CreatedBy == SecurityManager.UserID)) 
                    {
                        txtTglRealisasi.ReadOnly = false; 
                        txtTglRealisasi.Focus(); 
                        txtTglRealisasi.DateValue = GlobalVar.GetServerDate;
                        cboKas.Enabled = true;
                        cmdRealisasi.Visible = true; 
                    }
                    if ((_statusApproval == 9)&&!Convert.IsDBNull(dt.Rows[0]["TanggalPinjam"])) 
                    { 
                        txtTglRealisasi.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalPinjam"], ""); 
                        cmdRealisasi.Visible = false; 
                    }
                    if (_statusApproval >= 2)
                    {
                        if (!Convert.IsDBNull(dt.Rows[0]["TanggalAcc1"])) dtTanggalApproval1.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalAcc1"], "");
                        txtNoApproval1.Text = (String)Tools.isNull(dt.Rows[0]["NoAcc1"], "");
                        // dtTanggalApproval2.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalAcc2"], "");
                    }
                    if ((_statusApproval > 2) || (dtTanggalApproval2.DateValue != null))
                    {
                        if (_jumlahAcc.Equals(1))
                        {

                            dtTanggalApproval2.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalAcc2"], "");
                            txtNoApproval2.Text = (String)Tools.isNull(dt.Rows[0]["NoAcc2"], "");
                        }

                        else
                        {
                            txtPICApprove2.Text = "";
                        }

                    }

                    if (_jumlahAcc.Equals(1)) txtPICApprove2.Text = Tools.isNull(dt.Rows[0]["UserIdAcc2"], "").ToString();
                    else txtPICApprove2.Text = "";



                    //if (CreatedBy != SecurityManager.UserID) { cmdRealisasi.Visible = false; }
                    if (!hasRight_pk) cmdRealisasi.Visible = false; 
                    txtSisapinjam.Text = LoadSisaPinjaman().ToString();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            this.Cursor = Cursors.Default;
        }


       private String LoadAfterRealisasi()
       {
           String NoBuktiBaru=String.Empty;
           DataTable dt = new DataTable();
           using (Database db = new Database())
           {
               db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST"));
               db.Commands[0].Parameters.Add(new Parameter("@RowId", SqlDbType.UniqueIdentifier, this._rowID));
               dt = db.Commands[0].ExecuteDataTable();
           }

           if (dt.Rows.Count > 0)
           {
               NoBuktiBaru = dt.Rows[0]["NoBukti"].ToString();
           }
           return NoBuktiBaru;
       }

       private void LoadAfterNew()
       {
           string CreatedBy;
           this.Cursor = Cursors.WaitCursor;
           
               dt = new DataTable();
               using (Database db = new Database())
               {
                   db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_LIST"));

                   db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, GetRowID()));
                   dt = db.Commands[0].ExecuteDataTable();
               }

               //display data           
               txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
               Guid RowIDKaryawan;
               RowIDKaryawan = (Guid)dt.Rows[0]["KaryawanRowID"];
               fcbo.FillComboKaryawan(cboPeminjam, 1, RowIDKaryawan);
               txtTanggal.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalPinjam"], "");//(DateTime)Tools.isNull(dt.Rows[0]["CreatedOn"], "");
               txtNominal.Text = Tools.isNull(dt.Rows[0]["NominalPinjaman"], "").ToString();
               txtAlasanPinjam.Text = Tools.isNull(dt.Rows[0]["AlasanPinjam"], "").ToString();
               _statusApproval = Convert.ToInt32(dt.Rows[0]["StatusApproval"]);
               txtPICApprove1.Text = Tools.isNull(dt.Rows[0]["UserIdAcc1"], "").ToString();
               txtPICApprove2.Text = Tools.isNull(dt.Rows[0]["UserIdAcc2"], "").ToString();
               txtAlasanTolak.Text = Tools.isNull(dt.Rows[0]["AlasanTolak"], "").ToString();
               Guid KasRowID = (Guid)Tools.isNull(dt.Rows[0]["KasRowID"], Guid.Empty);
               fcbo.fillComboKas(cboKas, GlobalVar.PerusahaanRowID);
               cboKas.SelectedValue = KasRowID;

               CreatedBy = Tools.isNull(dt.Rows[0]["CreatedBy"], "").ToString();
               cboPeminjam.Enabled = false;

               if (_statusApproval > 0) { txtNominal.ReadOnly = true; txtNominal.TabStop = false; cboPeminjam.Enabled = false; cmdSAVE.Enabled = false; txtAlasanPinjam.Enabled = false; cboKas.Enabled = false; }
               if ((_statusApproval == 8) && hasRight_pk) { txtTglRealisasi.ReadOnly = false; txtTglRealisasi.Focus(); txtTglRealisasi.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalPinjam"], "")/*GlobalVar.GetServerDate*/; cmdRealisasi.Visible = true; }
               if (_statusApproval == 9) { txtTglRealisasi.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalPinjam"], ""); cmdRealisasi.Visible = false; };
               if (_statusApproval >= 2) dtTanggalApproval1.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalAcc1"], ""); txtNoApproval1.Text = (String)Tools.isNull(dt.Rows[0]["NoAcc1"], "");// dtTanggalApproval2.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalAcc2"], "");
               if ((_statusApproval > 2) || (dtTanggalApproval2.DateValue != null))
               {
                   dtTanggalApproval2.DateValue = (DateTime)Tools.isNull(dt.Rows[0]["TanggalAcc2"], "");
                   txtNoApproval2.Text = (String)Tools.isNull(dt.Rows[0]["NoAcc2"], "");
               }
               if (hasRight_pk) { cmdRealisasi.Visible = false; }
               txtSisapinjam.Text = LoadSisaPinjaman().ToString();
               FormMode = enumFormMode.Update;
               cmdSubmit.Visible = true;
               cmdSubmit.Focus();
           this.Cursor = Cursors.Default;
       }

       private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPiutangKaryawanBrowse)
                {
                    frmPiutangKaryawanBrowse frmCaller = (frmPiutangKaryawanBrowse)this.Caller;
                    frmCaller.RefreshDataHeaderPiutangKaryawan();
                    frmCaller.LoadPiutangKaryawanByKaryawanID(_karyawanRowID);
                    frmCaller.RefreshDetail();
                    frmCaller.FindRowHeader("HeaderRowID",(String) _karyawanRowID.ToString());
                    frmCaller.FindRow("NoBukti", txtNoBukti.Text);
                    
                }
          }
        }

       private void closeFormRealisasi()
       {
           if (this.DialogResult == DialogResult.OK)
           {
               if (this.Caller is frmPiutangKaryawanBrowse)
               {
                   frmPiutangKaryawanBrowse frmCaller = (frmPiutangKaryawanBrowse)this.Caller;
                   //frmCaller.RefreshData();
                   frmCaller.RefreshDataHeaderPiutangKaryawan();
                   frmCaller.LoadPiutangKaryawanByKaryawanID(_karyawanRowID);
                   frmCaller.RefreshDetail();
                   frmCaller.FindRow("NoBukti", txtNoBukti.Text);
               }
           }
       }


       private void RefreshAcc()
        {
            grpApproval.Visible = (FormMode != enumFormMode.New);
            if (grpApproval.Visible == true)
            {
                switch (_statusApproval)
                {

                    case 0: lblStatusAcc.Text = "Belum Pengajuan"; break;
                    case 1: lblStatusAcc.Text = "Menunggu Acc #1"; break;
                    case 2: lblStatusAcc.Text = "Menunggu Acc #2"; break;
                    case 7: lblStatusAcc.Text = "Ditolak"; break;
                    case 8: lblStatusAcc.Text = "Disetujui"; break;
                    case 9: lblStatusAcc.Text = "Selesai"; break;
                    default: lblStatusAcc.Text = ""; break;
                }

                grpApproval.Visible = (_statusApproval > 0);
                cmdSubmit.Visible = (_statusApproval==0);
                pnlAcc1.Visible = (_statusApproval > 0);
                pnlAcc2.Visible = (_statusApproval > 1);
                txtAlasanTolak.Visible = (_statusApproval >= 1);
                //txtAlasanTolak.Enabled = (FormMode == enumFormMode.Approve);

                if ((txtPICApprove1.Text == SecurityManager.UserID) || (txtPICApprove2.Text == SecurityManager.UserID)) {txtAlasanTolak.Enabled= true   ;} 
                if ((_statusApproval == 0) || (_statusApproval == 9) || (_statusApproval==8)) { txtAlasanTolak.Enabled = false; }
                if (_statusApproval == 7) { txtAlasanTolak.Enabled = false; }
                cmdSubmitAcc1.Visible = ((_statusApproval == 1) && (txtPICApprove1.Text == SecurityManager.UserID));
                cmdRejectAcc1.Visible = ((_statusApproval == 1) && (txtPICApprove1.Text == SecurityManager.UserID));
                cmdSubmitAcc2.Visible = ((_statusApproval == 2) && (txtPICApprove2.Text == SecurityManager.UserID));
                cmdRejectAcc2.Visible = ((_statusApproval == 2) && (txtPICApprove2.Text == SecurityManager.UserID));
            }

        }

       private void Proses_Approved1(int newstatus, int StatusAcc1 ) { 
            try
            {
                if ((FormMode != enumFormMode.New) && (_statusApproval == 1) && (txtPICApprove1.Text == SecurityManager.UserID))
                {
                    using (Database db = new Database())
                    {
                        
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_UPDATE_Approve1"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, newstatus));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc1", SqlDbType.VarChar, txtNoApproval1.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@JumlahAcc", SqlDbType.VarChar, IsNeedAcc2));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusAcc1", SqlDbType.TinyInt, StatusAcc1 ));
                        db.Commands[0].Parameters.Add(new Parameter("@AlasanTolak", SqlDbType.VarChar , txtAlasanTolak.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    _statusApproval = newstatus;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            RefreshData();
        }

       private void Proses_Approved2(int newstatus, int StatusAcc2 )
        {
            try
            {
                if ((FormMode != enumFormMode.New) || (_statusApproval == 2) || (txtPICApprove2.Text == SecurityManager.UserID)) //ganti && ke ||
                {
                    using (Database db = new Database())
                    {

                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_UPDATE_Approve2"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, newstatus));
                        db.Commands[0].Parameters.Add(new Parameter("@NoAcc2", SqlDbType.VarChar, txtNoApproval2.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusAcc2", SqlDbType.TinyInt, StatusAcc2));
                        db.Commands[0].Parameters.Add(new Parameter("@AlasanTolak", SqlDbType.VarChar, txtAlasanTolak.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    _statusApproval = newstatus;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            RefreshData();
        }

       private void Proses_Realisasi(int newstatus)
        {

            try
            {
                using (Database db = new Database())

                {
                    DataTable dt = new DataTable();
                    NoBuktiSementara = txtNoBukti.Text;
                    //txtNoBukti.Text  = Numerator.GetNomorDokumen("REALISASI_PIUTANGKARYAWAN", "",
                      //                      "/PK/" + string.Format("{0:yyMM}", DateTime.Today)
                        //                    , 3, false, true);

                    db.Commands.Add(db.CreateCommand("usp_PiutangKaryawan_UPDATE_Realisasi"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@Nobukti", SqlDbType.VarChar , txtNoBukti.Text  ));
                    db.Commands[0].Parameters.Add(new Parameter("@NobuktiSementara", SqlDbType.VarChar,NoBuktiSementara ));
                    db.Commands[0].Parameters.Add(new Parameter("@TanggalPinjam", SqlDbType.Date , txtTglRealisasi.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KasRowID", SqlDbType.UniqueIdentifier, cboKas.SelectedValue));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusApproval", SqlDbType.TinyInt, newstatus));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _statusApproval = newstatus;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            MessageBox.Show("Piutang Karyawan Sudah di Realisasikan.");
            cmdRealisasi.Enabled = false;

            txtTglRealisasi.Enabled = false;
            cboKas.Enabled = false;

            this.DialogResult = DialogResult.OK;
            closeFormRealisasi();
            //this.Close();
        }
       private void HirarkiAccPK()
       {
           using (Database db = new Database())
           {
               int nUrut1 = 1;
               int nUrut2 = 2;
               dt = new DataTable();
               db.Commands.Add(db.CreateCommand("usp_AccPiutangKaryawanHirarki_LIST_Urutan"));
               db.Commands[0].Parameters.Add(new Parameter("@UrutanAcc", SqlDbType.TinyInt,nUrut1 ));
               dt = db.Commands[0].ExecuteDataTable();
               if (dt.Rows.Count > 0)
               {
                   UserAcc1 = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
               }
               else
               {
                   UserAcc1 = "";
               }
               

               db.Commands.Clear();
               dt = new DataTable();
               db.Commands.Add(db.CreateCommand("usp_AccPiutangKaryawanHirarki_LIST_Urutan"));
               db.Commands[0].Parameters.Add(new Parameter("@UrutanAcc", SqlDbType.TinyInt, nUrut2));
               dt = db.Commands[0].ExecuteDataTable();
               if (dt.Rows.Count > 0)
               {
                   UserAcc2 = Tools.isNull(dt.Rows[0]["UserID"], "").ToString();
               }
               else
               {
                   UserAcc2 = "";
               }
               
           }

       }           

       #endregion

       private void cmdSubmitAcc1_Click(object sender, EventArgs e)
        {
            SubmitorAccBy = SecurityManager.UserID;
            DialogResult result = MessageBox.Show("Butuh Acc ke-2?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if ((FormMode != enumFormMode.New) && (_statusApproval == 1) && (txtPICApprove1.Text == SecurityManager.UserID))
                    if (SendingEmail("WIWIN", false,false).Equals(true))
                    {
                        IsNeedAcc2 = 1;
                        Proses_Approved1(2, 8);

                    }
                    else
                    {
                        MessageBox.Show("Bad Connection.");
                        return;
                    }
    
               
           
            }
            if (result == DialogResult.No)
            {
                if (SendingEmail(String.Empty, true,false) == true)
                {
                    IsNeedAcc2 = 0;
                    Proses_Approved1(8, 8);

                }
                else
                {
                    MessageBox.Show("Bad Connection.");
                    return;
                }
                
                
            }
           
        }

       private void cmdRejectAcc1_Click(object sender, EventArgs e)
        {
            SubmitorAccBy = SecurityManager.UserID;
            if (txtAlasanTolak.Text == "")
            {
                MessageBox.Show("Alasan Tolak Harus Di ISI..!!!");
                return;
            }
            else
            { 
             if (SendingEmail(String.Empty, true,true)==true)
             {
                 

                    if ((FormMode != enumFormMode.New) && (_statusApproval == 1) && (txtPICApprove1.Text == SecurityManager.UserID))
                        Proses_Approved1(7, 7);
             }

             else
             {
                 MessageBox.Show("Bad Connection.");
                 return;
             }
            
            }

                 

        }

       private void cmdSubmitAcc2_Click(object sender, EventArgs e)
        {
            SubmitorAccBy = SecurityManager.UserID; 
           if (SendingEmail(String.Empty, true,false)==true)
            {
                if ((FormMode != enumFormMode.New) && (_statusApproval == 2) && (txtPICApprove2.Text == SecurityManager.UserID))
                    IsNeedAcc2 = 1;
                Proses_Approved2(8, 8);

            }
            else
            {
                MessageBox.Show("Bad Connection.");
                return;  
            }
           
        }

       private void cmdRejectAcc2_Click(object sender, EventArgs e)
        {
            SubmitorAccBy = SecurityManager.UserID;

            if (txtAlasanTolak.Text == "")
            {
                MessageBox.Show("Alasan Tolak Harus Di ISI..!!!");
                return;
            }
            else
            {
                if (SendingEmail(String.Empty, true, true) == true)
                {

                    if ((FormMode != enumFormMode.New) && (_statusApproval == 2) && (txtPICApprove2.Text == SecurityManager.UserID))
                        Proses_Approved2(7, 7);

                }
                else
                {
                    MessageBox.Show("Bad Connection.");
                    return;
                }
            }

           
           
        }

       private String LoadSisaPinjaman()
       {
           String SisaPinjaman;
           dt = new DataTable();
           using (Database db = new Database())
           {
               db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_FILTER_SisaPinjaman"));
               db.Commands[0].Parameters.Add(new Parameter("@RowId", SqlDbType.UniqueIdentifier,cboPeminjam.SelectedValue));
               dt = db.Commands[0].ExecuteDataTable();
               
           }
           SisaPinjaman = dt.Rows[0]["SaldoPinjaman"].ToString();
           return SisaPinjaman;
       }



       private void LoadComboPeminjaman()
       {
           dt = new DataTable();
           using (Database db = new Database())
           {
               db.Commands.Add(db.CreateCommand("Usp_PiutangKaryawan_FILTER_SisaPinjaman"));
               db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cboPeminjam.SelectedValue));
               dt = db.Commands[0].ExecuteDataTable();

           }
           txtSisapinjam.Text = Tools.isNull(dt.Rows[0]["SaldoPinjaman"], "").ToString();
       }

       private void cboPeminjam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeminjam.SelectedIndex != 0)
            {
                LoadComboPeminjaman();
            }

        }

       private void cboPeminjam_Leave(object sender, EventArgs e)
       {
          
       }

       private void cmdRealisasi_Click(object sender, EventArgs e)
       {
           Proses_Realisasi(9);
           txtNoBukti.Text=LoadAfterRealisasi();
       }

     

       private void pnlAcc2_Paint(object sender, PaintEventArgs e)
       {

       }

       private void cboPeminjam_KeyPress(object sender, KeyPressEventArgs e)
       {
           e.KeyChar = (char)Keys.None; 
       }

       private void FrmPiutangKaryawanUpdateHeader_Shown(object sender, EventArgs e)
       {
           txtTanggal.Focus();
           txtTanggal.DateValue = GlobalVar.GetServerDate;
       }


    }
}
