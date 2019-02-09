using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using ISA.Showroom.Finance.Class;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Net.NetworkInformation;


namespace ISA.Showroom.Finance
{
    public partial class frmMain : Form
    {
        Ping ping = new Ping();
        PingReply pingresult;
        public frmMain()
        {
            InitializeComponent();
        }

        private void DisabledNonSAPLogin()
        {
            Boolean IsHLD = GlobalVar.PerusahaanID == "HLD";
            Boolean IsSAP = GlobalVar.PerusahaanID == "SAP";
            Boolean ISECR = GlobalVar.PerusahaanID == "ECR";
            if (GlobalVar.PerusahaanRowID == GlobalVar.GetPT.ECR)
            {
                transaksiToolStripMenuItem.Enabled = true;
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (item.Name.ToUpper() == "transaksiToolStripMenuItem".ToUpper())
                    {
                        foreach (Object items in item.DropDownItems)
                        {
                            if (items is ToolStripSeparator)
                            {
                                ToolStripSeparator menu = (ToolStripSeparator)items;
                                menu.Enabled = true;
                                menu.Visible = true;
                            }
                            if (items is ToolStripMenuItem)
                            {
                                ToolStripMenuItem menu = (ToolStripMenuItem)items;
                                if (menu.Name.ToUpper() == "piutangLainLainToolStripMenuItem".ToUpper())
                                {
                                    menu.Enabled = true;
                                    menu.Visible = true;
                                }
                                else if (menu.Name.ToUpper() == "hutangLainLainToolStripMenuItem".ToUpper())
                                {
                                    menu.Enabled = true;
                                    menu.Visible = true;
                                }
                                else
                                {
                                    menu.Enabled = false;
                                    menu.Visible = false;
                                }
                            }
                        }
                    }

                }


            }
            else
            {
                transaksiToolStripMenuItem.Enabled = true;
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (item.Name.ToUpper() == "transaksiToolStripMenuItem".ToUpper())
                    {
                        foreach (Object items in item.DropDownItems)
                        {
                            if (items is ToolStripSeparator)
                            {
                                ToolStripSeparator menu = (ToolStripSeparator)items;
                                menu.Enabled = true;
                                menu.Visible = true;
                            }
                            if (items is ToolStripMenuItem)
                            {
                                ToolStripMenuItem menu = (ToolStripMenuItem)items;
                                if (menu.Name.ToUpper() == "piutangLainLainToolStripMenuItem".ToUpper())
                                {
                                    menu.Enabled = true;
                                    menu.Visible = true;
                                }
                                else if (menu.Name.ToUpper() == "hutangLainLainToolStripMenuItem".ToUpper())
                                {
                                    menu.Enabled = true;
                                    menu.Visible = true;
                                }
                                else
                                {
                                    menu.Enabled = true;
                                    menu.Visible = true;
                                }
                            }
                        }
                    }

                }
            }

            if (GlobalVar.PerusahaanID != "ECR")
            {
                //piutangKaryawanToolStripMenuItem.Enabled = IsSAP;
                //bonSementaraToolStripMenuItem.Enabled = IsSAP;
                //accPiutangKaryawanToolStripMenuItem.Enabled = IsSAP;
           
                masterToolStripMenuItem.Enabled = !IsHLD;
                transaksiToolStripMenuItem.Enabled = !IsHLD;
                dknToolStripMenuItem.Enabled = !IsHLD;
                laporanToolStripMenuItem.Enabled = !IsHLD;
                postingJurnalKasirFinanceToolStripMenuItem.Enabled = !IsHLD;
                syncronizeDownloadToolStripMenuItem.Enabled = !IsHLD;
                syncronizeUploadToolStripMenuItem.Enabled = !IsHLD;
                securityToolStripMenuItem.Enabled = !IsHLD;
                prosesTutupBukuToolStripMenuItem.Enabled = !IsHLD;
                journalTransaksiToolStripMenuItem.Enabled = !IsHLD;
                perkiraanToolStripMenuItem1.Enabled = IsHLD;
                perkiraanToolStripMenuItem2.Enabled = !IsHLD;
                journalTransaksiToolStripMenuItem1.Enabled = IsHLD;
                //gLToolStripMenuItem.Enabled = !ISECR;

            }
            else
            {

                transaksiToolStripMenuItem.Enabled = IsSAP;
                //dknToolStripMenuItem.Enabled = IsSAP;
                //toolStripMenuItem4.Enabled = false;
                //hI11ToolStripMenuItem.Enabled = false;
                //gLToolStripMenuItem.Enabled = IsSAP;
                if (GlobalVar.PerusahaanRowID == GlobalVar.GetPT.ECR)
                {
                    transaksiToolStripMenuItem.Enabled = true;
                }
            }

       
            
        }

     

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            //SecurityManager.AlwaysAuthenticate();
            GlobalVar.initialize(GlobalVar.PerusahaanRowID);
            RefreshStatus();
            //DisabledForECR();
            //DisabledNonSAPLogin();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();

            if (!CekData.CekKasOpname())  //pas released harus di balikin -> disuruh andreas andi wijaya 
            //if (false)
            {
                menuStrip1.Enabled = false;
                MessageBox.Show("Kemarin belum melakukan kas opname, silahkan input terlebih dahulu");

                // pin
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                DateTime date = GlobalVar.GetServerDate;
                Calendar cal = dfi.Calendar;
                int mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                Tools.pin(PinId.Periode.Hari, mingguKe, date, PinId.Bagian.Accounting,
                Convert.ToInt32(PinId.ModulId.KasOpnamePrevDay), "Untuk melakukan kas opname kemarin memerlukan PIN!");

                if (GlobalVar.pinResult == false) { return; }
                else
                {
                    menuStrip1.Enabled = true;
                }
            }
        }

        public void RefreshStatus() {  
            //statusStrip1.Items[0].Text = SecurityManager.UserID;
            DisabledNonSAPLogin();
            if (!SecurityManager.IsManager())
            {
                PerformSecurityCheck();
            }
            tsUserID.Text = "User ID: " + SecurityManager.UserID +"/"+ GlobalVar.PerusahaanID; 
            tsHost.Text = "Host: " + ISA.DAL.Database.Host + "(" + GlobalVar.CabangID + ")";
            tsServerDate.Text = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.GetServerDate);
            tsPerusahaan.Text = GlobalVar.PerusahaanName;
            LableDKN.Text = GlobalVar.IsNewDNKN ? "New DKN :ON" : "New DKN OFF";
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string About = string.Format(CultureInfo.InvariantCulture, @"Version: {0}.{1}.{2} (r{3})", v.Major, v.Minor, v.Build, v.Revision);
            tsVer.Text = About;
      
        }

        private void PerformSecurityCheck()
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
            
                CheckMenuAuthorization(item);
                GetSubMenu(item);
            }
        }

        private void GetSubMenu(ToolStripMenuItem current)
        {
            foreach (Object item in current.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu = (ToolStripMenuItem)item;
                    if (!SecurityManager.IsManager() && !SecurityManager.IsAdministrator())
                    {
                        CheckMenuAuthorization(menu);
                    }
                    GetSubMenu(menu);
                }
            }

        }

       

        private void CheckMenuAuthorization(ToolStripMenuItem item)
        {
            if (item.Tag != null)
            {
                if (item.Tag.ToString() != "")
                {
                    
                        string partID = item.Tag.ToString();
                        if (!SecurityManager.HasPart(partID))
                        {
                            item.Visible = false;
                        }
                        else
                        {
                            item.Visible = true;
                        }    
          
                    
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ifrmChild = new frmChangePassword();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecurityManager.SetUserLogin(SecurityManager.UserID, false);

            SecurityManager.LogOut();
           
            this.Close();
            Program.LoginForm.AskLogin();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecurityManager.SetUserLogin(SecurityManager.UserID, false);
            Application.Exit();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreferences ifrmChild = new frmPreferences();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
        private void cabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmCabangBrowse ifrmChild = new Master.frmCabangBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
        private void gudangToolStripMenuItem_Click(object sender, EventArgs e){}
        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        
        private void jnsTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmJnsTransaksiBrowse ifrmChild = new Master.frmJnsTransaksiBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }


        private void rekeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmRekeningBrowse ifrmChild = new Master.frmRekeningBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
        
        public void RegisterChild(Control iform){}
        
        private void errorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmErrorBrowse ifrmChild = new Administrasi.frmErrorBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penanggungJawabRakToolStripMenuItem_Click(object sender, EventArgs e){
        }
        
        private void identitasPerusahaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmIdentitasPerusahaan ifrmChild = new Administrasi.frmIdentitasPerusahaan();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void giroToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Master.frmGiroBrowse ifrmChild = new Master.frmGiroBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        //private void frmRTestToolStripMenuItem_Click(object sender, EventArgs e){}

        //private void lookUpToolStripMenuItem_Click(object sender, EventArgs e) { }

        //private void setNumeratorToolStripMenuItem_Click(object sender, EventArgs e) { }

        //private void syncronizeDownloadToolStripMenuItem_Click(object sender, EventArgs e){}

        //private void syncronizeUploadToolStripMenuItem_Click(object sender, EventArgs e){}

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)        
                        {
                            if (SecurityManager.State == SecurityManager.enState.LogIn)
                            {
                                SecurityManager.SetUserLogin(SecurityManager.UserID, false);
                                Application.Exit();
                            }
                            else
                            {
                                Program.LoginForm.AskLogin();
                            }
                        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //string iphost = ISA.DAL.Database.Host.ToString();
            //string[] result = iphost.Split(new string[] { "," }, StringSplitOptions.None);
            //pingresult = ping.Send(result[0].ToString());
            //if (pingresult.Status.ToString() == "Success")
            //{
            //    tshost2.Text = "Server : Connected"; tshost2.ForeColor = Color.Green;
            //}

            //else
            //{
            //    tshost2.Text = "Server : Disconnected.."; tshost2.ForeColor = Color.Red;
            //}
       
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            SecurityManager.ResetCounter();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            SecurityManager.ResetCounter();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
        }

        private void memoPeminjmanBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void memoBarangKeluarDariGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangKembaliKePenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangDiterimaGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
        }

        private void rekapMutasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerMutasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pinjamanJatuhTempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void antarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void bedaKirimTerimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void hppToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void aGBelumDiterimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dOToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void backOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void mPRToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaReturJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void orderPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangDiterimaGudangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void mPRBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangDiterimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stokGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stokOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aCCHargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void upgradeSastokToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void transferOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadSaldoAkhirToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangYgDoubleIDBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangYgTidakAdaIDRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangBelum3XHitungToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangBelumTerOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void perbandinganToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void infoBarangBelumTerkirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void detailOpnamePerBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void detailOpnamePerKElompokToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void masterKosongToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void detailKosongToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void masterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void barangBelumTerkirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void analisaHasilStokOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void detailPerKodeRakToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void opnameversiGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void partsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityPartsBrowse ifrmChild = new Administrasi.frmSecurityPartsBrowse(GlobalVar.ApplicationID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRolesBrowse ifrmChild = new Administrasi.frmSecurityRolesBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityUsersBrowse ifrmChild = new Administrasi.frmSecurityUsersBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rightsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRightsBrowse ifrmChild = new Administrasi.frmSecurityRightsBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityApplicationsBrowse ifrmChild = new Administrasi.frmSecurityApplicationsBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kartuStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stokPerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rataRataJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stokBanyakToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void standarStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stokTipisToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stokTipisYgBelumLinkKePBOToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void analisaBackOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangBelumTerpenuhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void arusPembelianDanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekaptulasiPembelianBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void arusBarangPerTanggalToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void arusPembelianBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pembelianPerNamaBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerKoreksiPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void barangBelumDiterimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapKoreksiReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void returBeliPerNamaBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerKoreksiReturBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void closingStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapitulasiPenjualanDiBawahHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void perbandinganDONOtaBOToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dOBatalToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapitulasiPenjualanSamaDenganHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void omsetPerKotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void absensiSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void dOBelumJadiNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /* Laporan > Toko  */

        private void penyelesaianOrderPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aCCHargaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void aCCHargaDitolakToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pengirimanGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerKoreksiPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerPenjualanTunaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void jWJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaYangBelumDibikinkanSuratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaYangSudahDibikinkanSuratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void analisaPer3BulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void omzetTertinggiTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void omzetABETokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void evaluasiPenyelesaianOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void evaluasiOmzetPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void analisaTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapKoliMenurutToko00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapPenyelesaianPackingListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void rekapReturJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void returJualPerTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerKoreksiReturJualPerKelompokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void analisaKunjunganSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void hargaKhususToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void informasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void informasiNotaBelumDiSelesaikanOlehCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void informasiProduktifitasSalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void informasiNotaBelumAdaSuratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void informasiNotaBelumAdaTandaTerimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void hPPHPPRatarataDanHargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapitulasiHPPPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaJualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void koreksiJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notaReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void koreksiReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
        }

        private void barangToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
        }

        private void registerPenjulanPerSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registerPenjualanSalesHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void RegisterReturPenjualantoolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            //Laporan.Barang.frmReturJualPerNamaBarangFilter ifrmChild = new Laporan.Barang.frmReturJualPerNamaBarangFilter();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
        }

        private void RegisterReturPenjualantoolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
        }

        private void PenjualanBerdasrkanABEtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void RekapKoliSalestoolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void HargaKhusustoolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {
        }

        private void rekapitulasiPenjualanSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PerbandinganDOdanRealisasiOmzetPersales_Click(object sender, EventArgs e)
        {
        }

        private void tokoOrderBaruMenu_Click(object sender, EventArgs e)
        {
        }

        private void riwayatHPPRata2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HPPA.frmHPPAProses ifrmChild = new HPPA.frmHPPAProses();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void infoBarangBelumTerkirimMenu_Click(object sender, EventArgs e)
        {
        }

        private void omzetPerPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PenjualanHItoolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void fTPSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void AnalisaSalesman_Click(object sender, EventArgs e)
        {
        }


        private void uploadAntarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadAntarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadTransaksiToolStripMenuItem6_Click(object sender, EventArgs e)
        {
        }

        private void downloadTransaksiDari00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void downloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void downloadPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadPembelianAntarCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadDataKe11Menu_Click(object sender, EventArgs e)
        {
        }

        private void uploadDataKeC1Menu_Click(object sender, EventArgs e)
        {
        }

        private void downloadDariC2Menu_Click(object sender, EventArgs e)
        {
        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void downloadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }


        private void transaksiToolStripMenuItem6_Click(object sender, EventArgs e)
        {
        }

        private void transaksiToolStripMenuItem7_Click(object sender, EventArgs e)
        {
        }

        private void transaksiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void dOBelumACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void dOACCSemuaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void dOACCSebagianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void dOTolakACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void dOTolakACCDetailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void penyimpanganACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void analisaAuditACCToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void penjualanPotonganToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void goodInTransitMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void laporanInputSerahTerimaMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void laporanNotaNotaAnakCabangMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stockLookUpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }


        private void stockLookUpToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
        }


        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void uploadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void downloadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
        }


        private void potonganToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void sIPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
        }

        private void tabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
        }

        private void downloadDariPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadKePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapReturJualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void rekapReturJualPerTokoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapReturJualPerBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void rekapReturJualPenyelesainyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void returBelumLinkKePiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dODownloadPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dOUploadPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void transaksiToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
        }

        private void penyimpanganACCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void doBelumACCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void dOACCSemuaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void sIPToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void dOTolakACCToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void stokOpnameToolStripMenuItem3_Click(object sender, EventArgs e)
        {
        }

        private void sistemInformasiDanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void confirmationUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dOTolakACCDetailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void analisaAuditACCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void tabulasiBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pengajuanBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tabelPerolehanBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void prosesDataBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void hargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dumpUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadToPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadDariPosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void perhitunganBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void transferDataPengajuanBonusKe11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadPengajuanKe11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadPengajuanDari11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadDataBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dumpUploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void pJTToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
        }

        private void dataKasirPiutangPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void backOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void pajakToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void fTagihToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void koreksiRJToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void bonusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void downloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void downloadManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadManualISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dataViewerISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadINPMANToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uploadISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void downloadFileISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadManualISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void closingPJTToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadKoreksiPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void penjualanBOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selisihPengakuanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void memoReturToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void transaksiISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pJTISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void potonganISAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void transaksiISAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void transaksiISAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmBankBrowse ifrmChild = new Master.frmBankBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void vendortoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmVendorBrowse ifrmChild = new Master.frmVendorBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void penerimaanKasBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmPenerimaanUangBrowse ifrmChild = new Keuangan.frmPenerimaanUangBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pengeluaranKasBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmPengeluaranUangBrowse ifrmChild = new Keuangan.frmPengeluaranUangBrowse(false);
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void accPengeluaranKasBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmPengeluaranUangAccBrowse ifrmChild = new Keuangan.frmPengeluaranUangAccBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void piutangKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PiutangKaryawan.frmPiutangKaryawanBrowse ifrmChild = new PiutangKaryawan.frmPiutangKaryawanBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void bonSementaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonSementara.frmKasbonBrowse ifrmChild = new BonSementara.frmKasbonBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();

        }

        private void mutasiKasBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmMutasiUangBrowse ifrmChild = new Keuangan.frmMutasiUangBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mataUangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKursBrowse ifrmChild = new Master.frmKursBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void prosesGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmProsesGiroBrowse ifrmChild = new Keuangan.frmProsesGiroBrowse();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void accPiutangKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PiutangKaryawan.frmPiutangKaryawanBrowseAcc  ifrmChild = new PiutangKaryawan.frmPiutangKaryawanBrowseAcc();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hubunganIstimewaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pindahPerusahaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.MainForm.MdiChildren.Length > 0) MessageBox.Show("Masih ada form yang dibuka...");
            else
            {
                Administrasi.frmPindahPerusahaan ifrmChild = new Administrasi.frmPindahPerusahaan();
                ifrmChild.MdiParent = this;
                this.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }


        public bool CekLoadedForm()
        {
            bool result = true;
            Form[] afrm = this.MdiChildren;
            switch (afrm.Length)
            {
                case 0: break;
                case 1: 
                    if (!(afrm[0] is Administrasi.frmPindahPerusahaan)) result = false;
                    break;
                case 2:
                    if (!(afrm[0] is Administrasi.frmPindahPerusahaan) || 
                        !(afrm[0] is Administrasi.frmIdentitasPerusahaan) ||
                        !(afrm[1] is Administrasi.frmPindahPerusahaan) ||
                        !(afrm[1] is Administrasi.frmIdentitasPerusahaan)) result = false;
                    break;
                default: result = false;  break;
            }
            return result;
        }

        private void saldoNKBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RkBank.SaldoRkBank ifrmChild = new RkBank.SaldoRkBank();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRekonsiliasiBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanRekonsiliasiBank ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanRekonsiliasiBank();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void kelompokHubuntganIstimewaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKelompokTransaksiHIBrowse ifrmChild = new ISA.Showroom.Finance.Master.frmKelompokTransaksiHIBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void transferDataFinanceKeHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmFin2DKNBrowse ifrmChild = new ISA.Showroom.Finance.Keuangan.frmFin2DKNBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanTransaksiKasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Laporan.Finance.frmLaporanTransaksiKas ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanTransaksiKas();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanGiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanGiro ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanGiro();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanRekapitulasiBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanRekapBank ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanRekapBank();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Keuangan.frmPengeluaranUangBrowse ifrmChild = new Keuangan.frmPengeluaranUangBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            HI.frmDKNBrowse ifrmChild = new HI.frmDKNBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void perkiraanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanBrowse ifrmChild = new GL.frmPerkiraanBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void jurnalUmumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmJournalBrowse ifrmChild = new GL.frmJournalBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void laporanRekeningKoranHubunganIstimewaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.HI.frmLaporanHI ifrmChild = new ISA.Showroom.Finance.Laporan.HI.frmLaporanHI();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            GL.frmGlReportDesign ifrmChild = new ISA.Showroom.Finance.GL.frmGlReportDesign();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void bukuBesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRptBukuBesar ifrmChild = new ISA.Showroom.Finance.GL.frmRptBukuBesar();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void laporanJournalTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRptJournalTransaksi ifrmChild = new ISA.Showroom.Finance.GL.frmRptJournalTransaksi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void neracaPercobaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRptNeracaPercobaan ifrmChild = new ISA.Showroom.Finance.GL.frmRptNeracaPercobaan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void transaksiKasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanKoneksiArusKasBrowse ifrmChild = new ISA.Showroom.Finance.GL.frmPerkiraanKoneksiArusKasBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void transaksiUmumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPerkiraanKoneksiModulLainBrowse ifrmChild = new ISA.Showroom.Finance.GL.frmPerkiraanKoneksiModulLainBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void dKNDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HI.frmDonwloadDKN ifrmChild = new HI.frmDonwloadDKN();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void aToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GL.frmRptAuditTrans ifrmChild = new ISA.Showroom.Finance.GL.frmRptAuditTrans();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void journalTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmUploadJournal ifrmChild = new ISA.Showroom.Finance.GL.frmUploadJournal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void dKNUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HI.frmUploadDKN ifrmChild = new HI.frmUploadDKN();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void postingJurnalKasirFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmProsesJournalBrowse ifrmChild = new ISA.Showroom.Finance.Keuangan.frmProsesJournalBrowse();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt05ALabaRugi ifrmChild = new ISA.Showroom.Finance.GL.frmRpt05ALabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void detailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GL.frmRpt05BLabaRugi ifrmChild = new ISA.Showroom.Finance.GL.frmRpt05BLabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void globalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmRpt05CLabaRugi ifrmChild = new ISA.Showroom.Finance.GL.frmRpt05CLabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void detailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmRpt05DLabaRugi ifrmChild = new ISA.Showroom.Finance.GL.frmRpt05DLabaRugi();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void neracaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //GL.frmRpt06NeracaGabung ifrmChild = new ISA.Showroom.Finance.GL.frmRpt06NeracaGabung();

            GL.frmRpt06Neraca ifrmChild = new ISA.Showroom.Finance.GL.frmRpt06Neraca();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            GL.frmRptCatLapKeuangan ifrmChild = new ISA.Showroom.Finance.GL.frmRptCatLapKeuangan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void perkiraanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmUploadPerkiraan ifrmChild = new ISA.Showroom.Finance.GL.frmUploadPerkiraan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void hI11ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            HI.frmHI11 ifrmChild = new HI.frmHI11();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
       
        }

        private void prosesTutupBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmTutupBuku ifrmChild = new ISA.Showroom.Finance.GL.frmTutupBuku();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void riwayatSaldoTutupBukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRiwayatSaldoTutupBuku ifrmChild = new ISA.Showroom.Finance.GL.frmRiwayatSaldoTutupBuku();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void cashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt08CashFlow ifrmChild = new ISA.Showroom.Finance.GL.frmRpt08CashFlow();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void prosesAkhirBulanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmClosingKeuangan ifrmChild = new Keuangan.frmClosingKeuangan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.Karyawan.frmKaryawanBrowse ifrm = new Master.Karyawan.frmKaryawanBrowse();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void bagianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.Karyawan.frmBagian ifrm = new Master.Karyawan.frmBagian();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;

        }

        private void subBagianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.Karyawan.frmSubBagian ifrm = new Master.Karyawan.frmSubBagian();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void perkiraanToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GL.frmDownloadPerkiraan ifrmChild = new ISA.Showroom.Finance.GL.frmDownloadPerkiraan();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void journalTransaksiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GL.frmDownloadJournal ifrmChild = new ISA.Showroom.Finance.GL.frmDownloadJournal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void tokoLookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            Master.frmKasSaldo ifrmChild = new ISA.Showroom.Finance.Master.frmKasSaldo();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanRekapKasBank ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanRekapKasBank();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void postingJurnalTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPostingJournalTrading ifrmChild = new ISA.Showroom.Finance.GL.frmPostingJournalTrading();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void laporanRekonBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Laporan.Finance.frmLaporanRekonBank ifrm = new Laporan.Finance.frmLaporanRekonBank();
            //ifrm.MdiParent = this;
            //ifrm.Show();
            //ifrm.WindowState = FormWindowState.Maximized;
        }

        private void lapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanRekonBank ifrm = new Laporan.Finance.frmLaporanRekonBank();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void pembebananCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKN.frmPembebananCabang ifrm = new ISA.Showroom.Finance.DKN.frmPembebananCabang();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void jenisTransaksiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_JenisTransaksi ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_JenisTransaksi();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void rencanaPembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RencanaPembayaran ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RencanaPembayaran();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void realisasiPembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RealisasiPembayaran ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RealisasiPembayaran();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void rencanaRealisasiPembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapRencRealPembayaran ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_LapRencRealPembayaran();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;

        }

        private void rencanaSetoranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RencanaSetoran ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RencanaSetoran();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void realisasiSetoranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RealisasiSetoran ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RealisasiSetoran();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void rencanaDanRealisasiSetoranCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapRencRealSetoran ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_LapRencRealSetoran();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void laporanCashFlowHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapCashFlow_Harian ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_LapCashFlow_Harian();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void plafonBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_PlafonBank ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_PlafonBank();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void laporanCashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapCashFlow_Global ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_LapCashFlow_Global();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void realisasiHubuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RealisasiHI ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RealisasiHI();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void rencanaPembayaranLuarNegeriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CashFlow.frmCF_RencanaLuarNegeri ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RencanaLuarNegeri();
            //ifrm.MdiParent = this;
            //ifrm.Show();
            //ifrm.WindowState = FormWindowState.Maximized;
            CashFlow.frmRencanaCash ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRencanaCash();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void realisasiPembayaranLuarNegeriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CashFlow.frmCF_RealisasiLuarNegeri ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RealisasiLuarNegeri();
            //ifrm.MdiParent = this;
            //ifrm.Show();
            //ifrm.WindowState = FormWindowState.Maximized;

            CashFlow.frmRealisasiCash ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRealisasiCash();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rencanaDanRealisasiPembayaranLuarNegeriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapRencRealPembayaranLuarNegeri ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_LapRencRealPembayaranLuarNegeri();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void budgetingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.Budget.frmAccBiaya ifrm = new ISA.Showroom.Finance.Keuangan.Budget.frmAccBiaya();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void realisasiPembayaranKe00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RealisasiPembayaranHI ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RealisasiPembayaranHI();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void rencanaPembayaranKeCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RencanaPembayaranHI ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RencanaPembayaranHI();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void laporanPlafonBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapPlafon ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_LapPlafon();
            ifrm.MdiParent = this;
            ifrm.Show();
            ifrm.WindowState = FormWindowState.Maximized;
        }

        private void toolStripMenuItem13_Click_1(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanRekonsiliasi ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanRekonsiliasi();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* HI.frmGenerateRegister ifrm1 = new HI.frmGenerateRegister();
            ifrm1.WindowState = FormWindowState.Normal;
            ifrm1.ShowDialog(); 

            HI.frmGenerateRegister ifrmChild = new HI.frmGenerateRegister();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
            */
        }

        private void koreksiRencanaSetoranCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_RencanaSetoran_koreksi ifrm = new ISA.Showroom.Finance.CashFlow.frmCF_RencanaSetoran_koreksi();
            ifrm.WindowState = FormWindowState.Normal;
            ifrm.Show();
        }

        private void rencanaPembayaranLuarNegriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmRencanaCash ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRencanaCash();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void realisasiPembayranHutangLuarNegriNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CashFlow.frmRealisasiCash ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRealisasiCash();
            //ifrmChild.MdiParent = this;
            //this.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void laporanCashFLowRencanaRealisasiPembayranHutangLuarNegriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmRptRencanaPemabayaran ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRptRencanaPemabayaran();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void piutangLainLainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmPengeluaranPiutangLainBrowse ifrmChild = new ISA.Showroom.Finance.Keuangan.frmPengeluaranPiutangLainBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
 

        private void rencanaPembayaranHutangLokalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmRencanaCashLokal ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRencanaCashLokal();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
 

        private void neracaGabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmRpt06NeracaGabung ifrmChild = new ISA.Showroom.Finance.GL.frmRpt06NeracaGabung();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void rencanaPembayaranUangMukaLokalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmRencanaDPLokal ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRencanaDPLokal();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void rencanaPembayaranUangMukaImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmRencanaDP ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRencanaDP();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        private void laporanCashFlowRencanaUangMukaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CashFlow.frmRptRencanaDP ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRptRencanaDP();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rencanaCashFLowGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmRencanaCash_Global ifrmChild = new ISA.Showroom.Finance.CashFlow.frmRencanaCash_Global();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanCashFlowSubGLobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlow.frmCF_LapCashFlow_SubGlobal ifrmChild = new ISA.Showroom.Finance.CashFlow.frmCF_LapCashFlow_SubGlobal();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void rekapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmRptPiutangLainLain_Rekap ifrmChild = new Keuangan.frmRptPiutangLainLain_Rekap();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void detailToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Keuangan.frmRptPiutangLainLain_Detail ifrmChild = new Keuangan.frmRptPiutangLainLain_Detail();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void hutangLainLainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmHutangLainLain_Browse ifrmChild = new ISA.Showroom.Finance.Keuangan.frmHutangLainLain_Browse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPerbandinganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanPerbandinganGLdanRekapBank ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanPerbandinganGLdanRekapBank();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void saldoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Laporan.Finance.frmRptPiutangLainLain_Saldo ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmRptPiutangLainLain_Saldo();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void perbandingnaGLDengnSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmRptHLLPLL_GL ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmRptHLLPLL_GL();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void postingJurnalEceranPabrikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmJournalNotaPS ifrmChild = new GL.frmJournalNotaPS();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmRptPiutangLainLain_Saldo_Detail ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmRptPiutangLainLain_Saldo_Detail();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void saldoBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmRptPiutangLainLain_SaldoBank ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmRptPiutangLainLain_SaldoBank();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPLLHLLVersiAccountingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanPLLAccounting ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanPLLAccounting();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pLLHLLVersiAccountingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanPLLAccounting ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanPLLAccounting();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void jurnalAccrualToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void postingJurnalShowroomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPostingJournalShowroomBrowse ifrmChild = new GL.frmPostingJournalShowroomBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void postingJurnalAccrualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPostingJournalAccrual ifrmChild = new GL.frmPostingJournalAccrual();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void postingJurnalPotonganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.frmPostingJournalPotongan ifrmChild = new GL.frmPostingJournalPotongan();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void kasOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keuangan.frmKasOpnameBrowse ifrmChild = new Keuangan.frmKasOpnameBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.WindowState = FormWindowState.Maximized;
            ifrmChild.Show();
        }

        private void laporanPerbandinganKasOpnameDanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLapKasOpnameVSSaldoInput ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLapKasOpnameVSSaldoInput();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void bulananToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void laporanPertanggungjawabanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmRptLaporanPertanggungJawaban ifrmChild = new Laporan.Finance.frmRptLaporanPertanggungJawaban();
            ifrmChild.MdiParent = this;
            ifrmChild.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string IPserver = ISA.DAL.Database.Host;
            if (   IPserver == "172.16.61.253" 
                //|| IPserver == "172.16.62.253" 
                //|| IPserver == "172.16.63.253" 
                //|| IPserver == "172.16.64.253" 
                //|| IPserver == "172.16.65.253" 
                //|| IPserver == "172.16.131.254" 
                //|| IPserver == "172.16.132.253"
                )
            {
                //EmailOtoLapHarian.StartEmailOtomatis();
                EmailOtomatis.StartEmailOtomatis();
                Thread.Sleep(15000);
            }
            else
            {
                //EmailOtomatis.StartEmailOtomatis();
                //Thread.Sleep(15000);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void leasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmPenerimaanLeasingBrowse ifrmChild = new ISA.Showroom.Finance.Kasir.frmPenerimaanLeasingBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void idenPembayaranMPMToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Kasir.frmPembayaranMPM ifrmChild = new ISA.Showroom.Finance.Kasir.frmPembayaranMPM();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pengajuanBBNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kasir.frmPengajuanBBN ifrmChild = new ISA.Showroom.Finance.Kasir.frmPengajuanBBN();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void pelunasanBBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kasir.frmIdenBBNBrowse ifrmChild = new ISA.Showroom.Finance.Kasir.frmIdenBBNBrowse();
            ifrmChild.MdiParent = this;
            this.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void laporanPelunasanBBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanPelunasanBBN ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanPelunasanBBN();
            ifrmChild.ShowDialog();
            //ifrmChild.MdiParent = this;
            //this.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void laporanSaldoLeasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.Finance.frmLaporanSaldoLeasing ifrmChild = new ISA.Showroom.Finance.Laporan.Finance.frmLaporanSaldoLeasing();
            ifrmChild.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

 
    }
}
