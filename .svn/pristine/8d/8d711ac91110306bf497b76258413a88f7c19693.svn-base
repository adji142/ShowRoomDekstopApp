using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Showroom;
using ISA.DAL;
using System.Reflection;
using System.Globalization;
using System.Net.NetworkInformation;

namespace ISA.Showroom
{
    public partial class frmMain : Form
    {
        int waktu;
        DateTime startTime = DateTime.Now;
        bool message = true;
        Ping ping = new Ping();
        PingReply pingresult;
        public frmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {   
            GlobalVar.initialize();
            timer1.Enabled = true;
            timer1.Start();
            if (!SecurityManager.IsManager())
            {
                PerformSecurityCheck();
            }
            tsUserID.Text = "User ID: " + SecurityManager.UserID + "/" + GlobalVar.PerusahaanID;
            tsHost.Text = "Host: " + ISA.DAL.Database.Host + " (" +  GlobalVar.CabangID + ")";
            tsServerDate.Text = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.GetServerDate);
            tsPerusahaan.Text = GlobalVar.PerusahaanName;
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string About = string.Format(CultureInfo.InvariantCulture, @"Version: {0}.{1}.{2} (r{3})", v.Major, v.Minor, v.Build, v.Revision);
            tsVer.Text = About;

            if (GlobalVar.CabangID.Contains("06A"))
            {
                perubahanBBNToolStripMenuItem.Enabled = false;
                perubahanBBNToolStripMenuItem.Visible = false;
                leasingToolStripMenuItem1.Enabled = true;
                leasingToolStripMenuItem1.Visible = true;
                customerBlacklistToolStripMenuItem.Enabled = true;
                customerBlacklistToolStripMenuItem.Visible = true;
            }
            else
            {
                perubahanBBNToolStripMenuItem.Enabled = false;
                perubahanBBNToolStripMenuItem.Visible = false;
                leasingToolStripMenuItem1.Enabled = false;
                leasingToolStripMenuItem1.Visible = false;
                customerBlacklistToolStripMenuItem.Enabled = false;
                customerBlacklistToolStripMenuItem.Visible = false;
            }

            if (GlobalVar.CabangID.Contains("06"))
            {
                JualToolStripMenuItem.Visible = false;
                JualToolStripMenuItem.Enabled = false;
            }
            else
            {
                stokMotorBaruToolStripMenuItem.Visible = false;
                stokMotorBaruToolStripMenuItem.Enabled = false;
                pembelianBaruToolStripMenuItem.Visible = false;
                pembelianBaruToolStripMenuItem.Enabled = false;
                penjualanBaruToolStripMenuItem.Visible = false;
                penjualanBaruToolStripMenuItem.Enabled = false;
                uMBungaToolStripMenuItem.Visible = false;
                uMBungaToolStripMenuItem.Enabled = false;
                uMSubsidiToolStripMenuItem.Visible = false;
                uMSubsidiToolStripMenuItem.Enabled = false;
                perubahanSistemBayarToolStripMenuItem.Visible = false;
                perubahanSistemBayarToolStripMenuItem.Enabled = false;
                penjualanBekasToolStripMenuItem.Visible = false;
                penjualanBekasToolStripMenuItem.Enabled = false;
            }
            saldoUangMukaToolStripMenuItem.Visible = false;
            saldoUangMukaToolStripMenuItem.Enabled = false;

            generateKetTagih();
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

        public void RegisterChild(Control iform) { }

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

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ifrmChild = new frmChangePassword();
            ifrmChild.Show();            
        }

        private void ErrorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmErrorBrowse ifrmChild = new Administrasi.frmErrorBrowse();
            CheckMdiChildren(ifrmChild);
        }
        
        public void CheckMdiChildren(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == form.GetType())
                {
                    frm.Focus();
                    return;
                }
            }

            form.MdiParent = this;
            this.RegisterChild(form);
            form.Show();
        }

        private void IdentitasPerusahaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmIdentitasPerusahaan ifrmChild = new Administrasi.frmIdentitasPerusahaan();
            CheckMdiChildren(ifrmChild);
        }

        private void ApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityApplicationsBrowse ifrmChild = new Administrasi.frmSecurityApplicationsBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void PartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityPartsBrowse ifrmChild = new Administrasi.frmSecurityPartsBrowse(GlobalVar.ApplicationID);
            CheckMdiChildren(ifrmChild);
        }

        private void RolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRolesBrowse ifrmChild = new Administrasi.frmSecurityRolesBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityUsersBrowse ifrmChild = new Administrasi.frmSecurityUsersBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void RightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmSecurityRightsBrowse ifrmChild = new Administrasi.frmSecurityRightsBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void MotorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmMotor ifrmChild = new Master.frmMotor();
            CheckMdiChildren(ifrmChild);
        }

        private void KotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKotaBrowse ifrmChild = new Master.frmKotaBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void LeasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmLeasing ifrmChild = new Master.frmLeasing();
            CheckMdiChildren(ifrmChild);
        }

        private void VendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmVendorBrowser ifrmChild = new Master.frmVendorBrowser();
            CheckMdiChildren(ifrmChild);
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmCostumerBrowse ifrmChild = new Master.frmCostumerBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void WilayahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmWilayah ifrmChild = new Master.frmWilayah();
            CheckMdiChildren(ifrmChild);
        }

        private void SalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmSalesBrowse ifrmChild = new Master.frmSalesBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void KolektorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmKolektorBrowse ifrmChild = new Master.frmKolektorBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void TargetSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetSalesBrowse ifrmChild = new Master.frmTargetSalesBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void TargetKolektorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmTargetKolektorBrowse ifrmChild = new Master.frmTargetKolektorBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void BeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmPembelianBrowse ifrmChild = new Pembelian.frmPembelianBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrasi.frmPengaturanBrowse ifrmChild = new Administrasi.frmPengaturanBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void HutangPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmPelunasanPembelianBrowse ifrmChild = new Pembelian.frmPelunasanPembelianBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void StokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmStokMotorBrowse ifrmChild = new Master.frmStokMotorBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void JualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanBrowse ifrmChild = new Penjualan.frmPenjualanBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void UangMukaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmUangMukaBrowse ifrmChild = new Penjualan.frmUangMukaBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void PelunasanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPelunasanBrowse ifrmChild = new Penjualan.frmPelunasanBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void AdministrasiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Penjualan.frmAdministrasiBrowse ifrmChild = new Penjualan.frmAdministrasiBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void BungaMenurunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmKonsinyasiBrowse ifrmChild = new Penjualan.frmKonsinyasiBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void AngsuranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmAngsuranBrowse ifrmChild = new Penjualan.frmAngsuranBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void UbahAngsuranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmKonversiBrowse ifrmChild = new Penjualan.frmKonversiBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void LapStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapStock ifrmChild = new Laporan.frmLapStock();
            CheckMdiChildren(ifrmChild);
        }

        private void LapAnalisaPiutangBungaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapAPD ifrmChild = new Laporan.frmLapAPD();
            CheckMdiChildren(ifrmChild);
        }

        private void LapJaminanBPKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapBPKB ifrmChild = new Laporan.frmLapBPKB();
            CheckMdiChildren(ifrmChild);
        }

        private void LapPenerimaanPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapPenerimaanPiutang ifrmChild = new Laporan.frmLapPenerimaanPiutang();
            CheckMdiChildren(ifrmChild);
        }

        private void LapBeliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapPembelian ifrmChild = new Laporan.frmLapPembelian();
            CheckMdiChildren(ifrmChild);
        }

        private void LapOmzetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapOmzetPenjualan ifrmChild = new Laporan.frmLapOmzetPenjualan();
            CheckMdiChildren(ifrmChild);
        }

        private void LapPiutangOverdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapPiutangOverdue ifrmChild = new Laporan.frmLapPiutangOverdue();
            CheckMdiChildren(ifrmChild);
        }

        private void LapJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapPenjualan ifrmChild = new Laporan.frmLapPenjualan();
            CheckMdiChildren(ifrmChild);
        }

        private void titipanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenerimaanTitipan ifrmChild = new Penjualan.frmPenerimaanTitipan();
            CheckMdiChildren(ifrmChild); 
        }

        private void pegadaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPegadaianBrowse ifrmChild = new Penjualan.frmPegadaianBrowse();
            CheckMdiChildren(ifrmChild); 
        }
        private void LapSuratTagihanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapTagihan ifrmChild = new Laporan.frmLapTagihan();
            CheckMdiChildren(ifrmChild); 
        }

        private void targetWilayahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapTargetWilayah ifrmChild = new Laporan.frmLapTargetWilayah();
            CheckMdiChildren(ifrmChild); 
        }

        private void suratTagihanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapTagihan ifrmChild = new Laporan.frmLapTagihan();
            CheckMdiChildren(ifrmChild); 
        }

        private void dendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmDendaBrowse ifrmChild = new Penjualan.frmDendaBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void mutasiPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapMutasiPiutang ifrmChild = new Laporan.frmLapMutasiPiutang();
            CheckMdiChildren(ifrmChild); 
        }

        private void pembelianBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembelian.frmPembelianBrowseTLA ifrmChild = new Pembelian.frmPembelianBrowseTLA();
            CheckMdiChildren(ifrmChild);
        }

        private void penjualanBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanBrowseTLA ifrmChild = new Penjualan.frmPenjualanBrowseTLA();
            CheckMdiChildren(ifrmChild);
        }

        private void stokMotorBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmStokMotorBrowseTLA ifrmChild = new Master.frmStokMotorBrowseTLA();
            CheckMdiChildren(ifrmChild);
        }

        private void uMSubsidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmUMSubsidiBrowse ifrmChild = new Penjualan.frmUMSubsidiBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void uMBungaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmUMBungaBrowse ifrmChild = new Penjualan.frmUMBungaBrowse();
            CheckMdiChildren(ifrmChild);
        }

        private void surveyorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmSurveyorBrowse ifrmChild = new Master.frmSurveyorBrowse(); ;
            CheckMdiChildren(ifrmChild);
        }

        private void penerimaanHarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapTutupBukuHarianTLA ifrmChild = new Laporan.frmLapTutupBukuHarianTLA();
            CheckMdiChildren(ifrmChild);
        }

        private void perubahanSistemBayarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPerubahanSistemBayarBrowse ifrmChild = new Penjualan.frmPerubahanSistemBayarBrowse();
            CheckMdiChildren(ifrmChild); 
        }

        private void tLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapTLA ifrmChild = new Laporan.frmLapTLA();
            CheckMdiChildren(ifrmChild);
        }

        private void penjualanBekasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmPenjualanBrowseADS ifrmChild = new Penjualan.frmPenjualanBrowseADS(); ;
            CheckMdiChildren(ifrmChild);
        }

        private void perubahanBBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //Penjualan.frmPerubahanBBNBrowse ifrmChild = new Penjualan.frmPerubahanBBNBrowse(); ;
            //CheckMdiChildren(ifrmChild);
        }

        private void leasingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.FrmLapLeasing ifrmChild = new Laporan.FrmLapLeasing();
            CheckMdiChildren(ifrmChild);
        }

        private void transaksiBermasalahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmTrBermasalah ifrmChild = new Laporan.frmTrBermasalah();
            CheckMdiChildren(ifrmChild);
        }
        //
        private void frmMain_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void stokTarikanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapStockTarikan ifrmChild = new Laporan.frmLapStockTarikan();
            CheckMdiChildren(ifrmChild);
        }

        private void piutangBersaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (GlobalVar.CabangID.Contains("06"))
            //{
                Laporan.frmLapPiutangSaldo ifrmChild = new Laporan.frmLapPiutangSaldo();
                CheckMdiChildren(ifrmChild);
            //}            
        }

        private void customerBlacklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmCostumerBlackList ifrmChild = new Master.frmCostumerBlackList();
            CheckMdiChildren(ifrmChild);
        }

        private void masterSTNKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmMasterSTNK ifrmChild = new Penjualan.frmMasterSTNK();
            CheckMdiChildren(ifrmChild);
        }

        private void lapSTNKDanBPKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapMasterSTNK ifrmChild = new Laporan.frmLapMasterSTNK();
            ifrmChild.ShowDialog();
        }

        private void generateKetTagih()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KeteranganTagih_GenerateAuto"));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void jenisKendaraanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmJenisKendaraan ifrmChild = new Master.frmJenisKendaraan(); ;
            CheckMdiChildren(ifrmChild);
        }

        private void suratSomasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapSuratSomasi ifrmChild = new Laporan.frmLapSuratSomasi();
            CheckMdiChildren(ifrmChild);
        }

        private void indenPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmIndenPenjualan ifrmChild = new Penjualan.frmIndenPenjualan(); ;
            CheckMdiChildren(ifrmChild);
        }

        private void indenPenjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Laporan.frmLaporanIndenPenjualan ifrmChild = new Laporan.frmLaporanIndenPenjualan();
            CheckMdiChildren(ifrmChild);
        }

        private void wilayahBaruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master.frmWilayahBaru ifrmChild = new Master.frmWilayahBaru();
            CheckMdiChildren(ifrmChild);
        }

        private void suratJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan.frmLapSuratJalan ifrmChild = new Laporan.frmLapSuratJalan();
            CheckMdiChildren(ifrmChild);
        }

        private void pengeluaranKomisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penjualan.frmKomisiBrowse ifrmChild = new Penjualan.frmKomisiBrowse();
            CheckMdiChildren(ifrmChild);
        }
    }
}
