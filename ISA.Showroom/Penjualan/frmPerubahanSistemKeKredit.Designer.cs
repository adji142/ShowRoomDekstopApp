namespace ISA.Showroom.Penjualan
{
    partial class frmPerubahanSistemKeKredit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerubahanSistemKeKredit));
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.txtDPSubsidi = new ISA.Controls.NumericTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtUangMuka = new ISA.Controls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDPPelanggan = new ISA.Controls.NumericTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFauxTotal = new ISA.Controls.NumericTextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txtHargaOTR = new ISA.Controls.NumericTextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtTglJual = new ISA.Controls.DateTextBox();
            this.txtSistemBayar = new ISA.Controls.CommonTextBox();
            this.txtNoRangka = new ISA.Controls.CommonTextBox();
            this.txtNama = new ISA.Controls.CommonTextBox();
            this.txtNoBukti = new ISA.Controls.CommonTextBox();
            this.txtNoTrans = new ISA.Controls.CommonTextBox();
            this.txtBayarUM = new ISA.Controls.NumericTextBox();
            this.txtDiscount = new ISA.Controls.NumericTextBox();
            this.txtBiayaADM = new ISA.Controls.NumericTextBox();
            this.txtBBN = new ISA.Controls.NumericTextBox();
            this.txtHargaJadi = new ISA.Controls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBungaBulanan = new ISA.Controls.NumericTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtJmlAngsuran = new ISA.Controls.NumericTextBox();
            this.txtSisaPokok = new ISA.Controls.NumericTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBunga = new ISA.Controls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.numKredit = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.txtUMBaru = new ISA.Controls.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtHargaOff = new ISA.Controls.NumericTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTglAwalAngs = new ISA.Controls.DateTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDiscountPrev = new ISA.Controls.NumericTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSurveyor = new System.Windows.Forms.Label();
            this.lookUpSurveyor1 = new ISA.Showroom.Controls.LookUpSurveyor();
            this.txtBiayaADMBaru = new ISA.Controls.NumericTextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numKredit)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(351, 420);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 27;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(507, 420);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 28;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // txtDPSubsidi
            // 
            this.txtDPSubsidi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDPSubsidi.Enabled = false;
            this.txtDPSubsidi.Format = "N0";
            this.txtDPSubsidi.Location = new System.Drawing.Point(470, 309);
            this.txtDPSubsidi.Name = "txtDPSubsidi";
            this.txtDPSubsidi.ReadOnly = true;
            this.txtDPSubsidi.Size = new System.Drawing.Size(151, 20);
            this.txtDPSubsidi.TabIndex = 16;
            this.txtDPSubsidi.TabStop = false;
            this.txtDPSubsidi.Text = "0";
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(341, 312);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 14);
            this.label44.TabIndex = 211;
            this.label44.Text = "DP Subsidi";
            // 
            // txtUangMuka
            // 
            this.txtUangMuka.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUangMuka.Enabled = false;
            this.txtUangMuka.Format = "N0";
            this.txtUangMuka.Location = new System.Drawing.Point(470, 270);
            this.txtUangMuka.Name = "txtUangMuka";
            this.txtUangMuka.ReadOnly = true;
            this.txtUangMuka.Size = new System.Drawing.Size(151, 20);
            this.txtUangMuka.TabIndex = 15;
            this.txtUangMuka.TabStop = false;
            this.txtUangMuka.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(341, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 210;
            this.label12.Text = "Uang Muka";
            // 
            // txtDPPelanggan
            // 
            this.txtDPPelanggan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDPPelanggan.Enabled = false;
            this.txtDPPelanggan.Format = "N0";
            this.txtDPPelanggan.Location = new System.Drawing.Point(470, 343);
            this.txtDPPelanggan.Name = "txtDPPelanggan";
            this.txtDPPelanggan.ReadOnly = true;
            this.txtDPPelanggan.Size = new System.Drawing.Size(151, 20);
            this.txtDPPelanggan.TabIndex = 17;
            this.txtDPPelanggan.TabStop = false;
            this.txtDPPelanggan.Text = "0";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(341, 346);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 14);
            this.label23.TabIndex = 209;
            this.label23.Text = "DP Dibayarkan";
            // 
            // txtFauxTotal
            // 
            this.txtFauxTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFauxTotal.Enabled = false;
            this.txtFauxTotal.Location = new System.Drawing.Point(142, 343);
            this.txtFauxTotal.Name = "txtFauxTotal";
            this.txtFauxTotal.ReadOnly = true;
            this.txtFauxTotal.Size = new System.Drawing.Size(151, 20);
            this.txtFauxTotal.TabIndex = 8;
            this.txtFauxTotal.TabStop = false;
            this.txtFauxTotal.Text = "0";
            // 
            // label55
            // 
            this.label55.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(48, 346);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(88, 14);
            this.label55.TabIndex = 205;
            this.label55.Text = "Harga Jual Nett";
            // 
            // txtHargaOTR
            // 
            this.txtHargaOTR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHargaOTR.Enabled = false;
            this.txtHargaOTR.Location = new System.Drawing.Point(142, 309);
            this.txtHargaOTR.Name = "txtHargaOTR";
            this.txtHargaOTR.ReadOnly = true;
            this.txtHargaOTR.Size = new System.Drawing.Size(151, 20);
            this.txtHargaOTR.TabIndex = 7;
            this.txtHargaOTR.TabStop = false;
            this.txtHargaOTR.Text = "0";
            // 
            // label53
            // 
            this.label53.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(48, 312);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(63, 14);
            this.label53.TabIndex = 203;
            this.label53.Text = "Harga OTR";
            // 
            // txtTglJual
            // 
            this.txtTglJual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTglJual.DateValue = null;
            this.txtTglJual.Enabled = false;
            this.txtTglJual.Location = new System.Drawing.Point(470, 66);
            this.txtTglJual.MaxLength = 10;
            this.txtTglJual.Name = "txtTglJual";
            this.txtTglJual.ReadOnly = true;
            this.txtTglJual.Size = new System.Drawing.Size(151, 20);
            this.txtTglJual.TabIndex = 9;
            this.txtTglJual.TabStop = false;
            // 
            // txtSistemBayar
            // 
            this.txtSistemBayar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSistemBayar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSistemBayar.Enabled = false;
            this.txtSistemBayar.Location = new System.Drawing.Point(470, 98);
            this.txtSistemBayar.Name = "txtSistemBayar";
            this.txtSistemBayar.ReadOnly = true;
            this.txtSistemBayar.Size = new System.Drawing.Size(151, 20);
            this.txtSistemBayar.TabIndex = 10;
            this.txtSistemBayar.TabStop = false;
            // 
            // txtNoRangka
            // 
            this.txtNoRangka.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoRangka.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoRangka.Enabled = false;
            this.txtNoRangka.Location = new System.Drawing.Point(470, 130);
            this.txtNoRangka.Name = "txtNoRangka";
            this.txtNoRangka.ReadOnly = true;
            this.txtNoRangka.Size = new System.Drawing.Size(151, 20);
            this.txtNoRangka.TabIndex = 11;
            this.txtNoRangka.TabStop = false;
            // 
            // txtNama
            // 
            this.txtNama.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Enabled = false;
            this.txtNama.Location = new System.Drawing.Point(142, 130);
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(151, 20);
            this.txtNama.TabIndex = 2;
            this.txtNama.TabStop = false;
            // 
            // txtNoBukti
            // 
            this.txtNoBukti.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoBukti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBukti.Enabled = false;
            this.txtNoBukti.Location = new System.Drawing.Point(142, 98);
            this.txtNoBukti.Name = "txtNoBukti";
            this.txtNoBukti.ReadOnly = true;
            this.txtNoBukti.Size = new System.Drawing.Size(151, 20);
            this.txtNoBukti.TabIndex = 1;
            this.txtNoBukti.TabStop = false;
            // 
            // txtNoTrans
            // 
            this.txtNoTrans.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoTrans.Enabled = false;
            this.txtNoTrans.Location = new System.Drawing.Point(142, 66);
            this.txtNoTrans.Name = "txtNoTrans";
            this.txtNoTrans.ReadOnly = true;
            this.txtNoTrans.Size = new System.Drawing.Size(151, 20);
            this.txtNoTrans.TabIndex = 0;
            this.txtNoTrans.TabStop = false;
            // 
            // txtBayarUM
            // 
            this.txtBayarUM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBayarUM.Enabled = false;
            this.txtBayarUM.Location = new System.Drawing.Point(142, 270);
            this.txtBayarUM.Name = "txtBayarUM";
            this.txtBayarUM.ReadOnly = true;
            this.txtBayarUM.Size = new System.Drawing.Size(151, 20);
            this.txtBayarUM.TabIndex = 6;
            this.txtBayarUM.TabStop = false;
            this.txtBayarUM.Text = "0";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(470, 237);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(151, 20);
            this.txtDiscount.TabIndex = 14;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.Text = "0";
            // 
            // txtBiayaADM
            // 
            this.txtBiayaADM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBiayaADM.Enabled = false;
            this.txtBiayaADM.Location = new System.Drawing.Point(470, 175);
            this.txtBiayaADM.Name = "txtBiayaADM";
            this.txtBiayaADM.ReadOnly = true;
            this.txtBiayaADM.Size = new System.Drawing.Size(151, 20);
            this.txtBiayaADM.TabIndex = 12;
            this.txtBiayaADM.TabStop = false;
            this.txtBiayaADM.Text = "0";
            // 
            // txtBBN
            // 
            this.txtBBN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBBN.Enabled = false;
            this.txtBBN.Location = new System.Drawing.Point(142, 207);
            this.txtBBN.Name = "txtBBN";
            this.txtBBN.ReadOnly = true;
            this.txtBBN.Size = new System.Drawing.Size(151, 20);
            this.txtBBN.TabIndex = 4;
            this.txtBBN.TabStop = false;
            this.txtBBN.Text = "0";
            // 
            // txtHargaJadi
            // 
            this.txtHargaJadi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHargaJadi.Enabled = false;
            this.txtHargaJadi.Location = new System.Drawing.Point(142, 175);
            this.txtHargaJadi.Name = "txtHargaJadi";
            this.txtHargaJadi.ReadOnly = true;
            this.txtHargaJadi.Size = new System.Drawing.Size(151, 20);
            this.txtHargaJadi.TabIndex = 3;
            this.txtHargaJadi.TabStop = false;
            this.txtHargaJadi.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(341, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 14);
            this.label11.TabIndex = 190;
            this.label11.Text = "No Rangka";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(341, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 14);
            this.label10.TabIndex = 189;
            this.label10.Text = "Sistem Pembayaran";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 14);
            this.label9.TabIndex = 188;
            this.label9.Text = "Nama";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 187;
            this.label8.Text = "No Trans";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 14);
            this.label7.TabIndex = 186;
            this.label7.Text = "No Bukti";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 185;
            this.label6.Text = "Harga Jadi";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 184;
            this.label5.Text = "Tanggal Jual";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 180;
            this.label1.Text = "Bayar UM";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 181;
            this.label2.Text = "Discount";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 182;
            this.label3.Text = "BBN";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 183;
            this.label4.Text = "Biaya ADM";
            // 
            // txtBungaBulanan
            // 
            this.txtBungaBulanan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBungaBulanan.Enabled = false;
            this.txtBungaBulanan.Format = "N0";
            this.txtBungaBulanan.Location = new System.Drawing.Point(779, 309);
            this.txtBungaBulanan.Name = "txtBungaBulanan";
            this.txtBungaBulanan.ReadOnly = true;
            this.txtBungaBulanan.Size = new System.Drawing.Size(150, 20);
            this.txtBungaBulanan.TabIndex = 25;
            this.txtBungaBulanan.TabStop = false;
            this.txtBungaBulanan.Text = "0";
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(644, 312);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(108, 14);
            this.label31.TabIndex = 225;
            this.label31.Text = "Nominal Bunga/Bln";
            // 
            // txtJmlAngsuran
            // 
            this.txtJmlAngsuran.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtJmlAngsuran.Format = "N0";
            this.txtJmlAngsuran.Location = new System.Drawing.Point(779, 343);
            this.txtJmlAngsuran.Name = "txtJmlAngsuran";
            this.txtJmlAngsuran.Size = new System.Drawing.Size(150, 20);
            this.txtJmlAngsuran.TabIndex = 26;
            this.txtJmlAngsuran.Text = "0";
            this.txtJmlAngsuran.Leave += new System.EventHandler(this.txtJmlAngsuran_Leave);
            // 
            // txtSisaPokok
            // 
            this.txtSisaPokok.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSisaPokok.Format = "N0";
            this.txtSisaPokok.Location = new System.Drawing.Point(779, 270);
            this.txtSisaPokok.Name = "txtSisaPokok";
            this.txtSisaPokok.ReadOnly = true;
            this.txtSisaPokok.Size = new System.Drawing.Size(150, 20);
            this.txtSisaPokok.TabIndex = 24;
            this.txtSisaPokok.TabStop = false;
            this.txtSisaPokok.Text = "0";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(644, 346);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(124, 14);
            this.label30.TabIndex = 224;
            this.label30.Text = "Jumlah Angsuran/Bln";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(644, 273);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 14);
            this.label29.TabIndex = 223;
            this.label29.Text = "Sisa Pokok";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(837, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 14);
            this.label14.TabIndex = 222;
            this.label14.Text = "%";
            // 
            // txtBunga
            // 
            this.txtBunga.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBunga.Format = "N2";
            this.txtBunga.Location = new System.Drawing.Point(779, 207);
            this.txtBunga.Name = "txtBunga";
            this.txtBunga.Size = new System.Drawing.Size(52, 20);
            this.txtBunga.TabIndex = 22;
            this.txtBunga.Text = "0.00";
            this.txtBunga.Leave += new System.EventHandler(this.txtBunga_Leave);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(644, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 14);
            this.label13.TabIndex = 221;
            this.label13.Text = "Bunga";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(837, 178);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 14);
            this.label26.TabIndex = 220;
            this.label26.Text = "Bulan";
            // 
            // numKredit
            // 
            this.numKredit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numKredit.Location = new System.Drawing.Point(779, 176);
            this.numKredit.Name = "numKredit";
            this.numKredit.Size = new System.Drawing.Size(52, 20);
            this.numKredit.TabIndex = 21;
            this.numKredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numKredit.Leave += new System.EventHandler(this.numKredit_Leave);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(644, 178);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 14);
            this.label24.TabIndex = 219;
            this.label24.Text = "Tempo Angsuran";
            // 
            // txtUMBaru
            // 
            this.txtUMBaru.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUMBaru.Format = "N0";
            this.txtUMBaru.Location = new System.Drawing.Point(779, 130);
            this.txtUMBaru.Name = "txtUMBaru";
            this.txtUMBaru.Size = new System.Drawing.Size(150, 20);
            this.txtUMBaru.TabIndex = 20;
            this.txtUMBaru.Text = "0";
            this.txtUMBaru.Leave += new System.EventHandler(this.txtUMBaru_Leave);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(644, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 14);
            this.label15.TabIndex = 227;
            this.label15.Text = "Uang Muka";
            // 
            // txtHargaOff
            // 
            this.txtHargaOff.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHargaOff.Enabled = false;
            this.txtHargaOff.Location = new System.Drawing.Point(142, 237);
            this.txtHargaOff.Name = "txtHargaOff";
            this.txtHargaOff.ReadOnly = true;
            this.txtHargaOff.Size = new System.Drawing.Size(151, 20);
            this.txtHargaOff.TabIndex = 5;
            this.txtHargaOff.TabStop = false;
            this.txtHargaOff.Text = "0";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(48, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 14);
            this.label16.TabIndex = 229;
            this.label16.Text = "Harga Off";
            // 
            // txtTglAwalAngs
            // 
            this.txtTglAwalAngs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTglAwalAngs.DateValue = null;
            this.txtTglAwalAngs.Enabled = false;
            this.txtTglAwalAngs.Location = new System.Drawing.Point(779, 98);
            this.txtTglAwalAngs.MaxLength = 10;
            this.txtTglAwalAngs.Name = "txtTglAwalAngs";
            this.txtTglAwalAngs.ReadOnly = true;
            this.txtTglAwalAngs.Size = new System.Drawing.Size(150, 20);
            this.txtTglAwalAngs.TabIndex = 19;
            this.txtTglAwalAngs.Leave += new System.EventHandler(this.txtTglAwalAngs_Leave);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(644, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 14);
            this.label17.TabIndex = 231;
            this.label17.Text = "Tgl Awal Angsuran";
            // 
            // txtDiscountPrev
            // 
            this.txtDiscountPrev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscountPrev.Enabled = false;
            this.txtDiscountPrev.Location = new System.Drawing.Point(470, 207);
            this.txtDiscountPrev.Name = "txtDiscountPrev";
            this.txtDiscountPrev.ReadOnly = true;
            this.txtDiscountPrev.Size = new System.Drawing.Size(151, 20);
            this.txtDiscountPrev.TabIndex = 13;
            this.txtDiscountPrev.TabStop = false;
            this.txtDiscountPrev.Text = "0";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(341, 210);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 14);
            this.label18.TabIndex = 232;
            this.label18.Text = "Discount Asli";
            // 
            // lblSurveyor
            // 
            this.lblSurveyor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSurveyor.AutoSize = true;
            this.lblSurveyor.Location = new System.Drawing.Point(340, 383);
            this.lblSurveyor.Name = "lblSurveyor";
            this.lblSurveyor.Size = new System.Drawing.Size(57, 14);
            this.lblSurveyor.TabIndex = 235;
            this.lblSurveyor.Text = "Surveyor";
            // 
            // lookUpSurveyor1
            // 
            this.lookUpSurveyor1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpSurveyor1.Location = new System.Drawing.Point(466, 373);
            this.lookUpSurveyor1.Name = "lookUpSurveyor1";
            this.lookUpSurveyor1.Size = new System.Drawing.Size(219, 31);
            this.lookUpSurveyor1.TabIndex = 18;
            // 
            // txtBiayaADMBaru
            // 
            this.txtBiayaADMBaru.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBiayaADMBaru.Location = new System.Drawing.Point(779, 237);
            this.txtBiayaADMBaru.Name = "txtBiayaADMBaru";
            this.txtBiayaADMBaru.Size = new System.Drawing.Size(150, 20);
            this.txtBiayaADMBaru.TabIndex = 23;
            this.txtBiayaADMBaru.Text = "0";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(644, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 14);
            this.label19.TabIndex = 236;
            this.label19.Text = "Biaya ADM Baru";
            // 
            // frmPerubahanSistemKeKredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 472);
            this.Controls.Add(this.txtBiayaADMBaru);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblSurveyor);
            this.Controls.Add(this.lookUpSurveyor1);
            this.Controls.Add(this.txtDiscountPrev);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtTglAwalAngs);
            this.Controls.Add(this.txtHargaOff);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtUMBaru);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBungaBulanan);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtJmlAngsuran);
            this.Controls.Add(this.txtSisaPokok);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBunga);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.numKredit);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.txtDPSubsidi);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.txtUangMuka);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDPPelanggan);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtFauxTotal);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.txtHargaOTR);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.txtTglJual);
            this.Controls.Add(this.txtSistemBayar);
            this.Controls.Add(this.txtNoRangka);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtNoBukti);
            this.Controls.Add(this.txtNoTrans);
            this.Controls.Add(this.txtBayarUM);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtBiayaADM);
            this.Controls.Add(this.txtBBN);
            this.Controls.Add(this.txtHargaJadi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPerubahanSistemKeKredit";
            this.Text = "Konversi Ke Kredit Bunga Tetap";
            this.Title = "Konversi Ke Kredit Bunga Tetap";
            this.Load += new System.EventHandler(this.frmPerubahanSistemKeKredit_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPerubahanSistemKeKredit_FormClosed);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtHargaJadi, 0);
            this.Controls.SetChildIndex(this.txtBBN, 0);
            this.Controls.SetChildIndex(this.txtBiayaADM, 0);
            this.Controls.SetChildIndex(this.txtDiscount, 0);
            this.Controls.SetChildIndex(this.txtBayarUM, 0);
            this.Controls.SetChildIndex(this.txtNoTrans, 0);
            this.Controls.SetChildIndex(this.txtNoBukti, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.txtNoRangka, 0);
            this.Controls.SetChildIndex(this.txtSistemBayar, 0);
            this.Controls.SetChildIndex(this.txtTglJual, 0);
            this.Controls.SetChildIndex(this.label53, 0);
            this.Controls.SetChildIndex(this.txtHargaOTR, 0);
            this.Controls.SetChildIndex(this.label55, 0);
            this.Controls.SetChildIndex(this.txtFauxTotal, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.txtDPPelanggan, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtUangMuka, 0);
            this.Controls.SetChildIndex(this.label44, 0);
            this.Controls.SetChildIndex(this.txtDPSubsidi, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.numKredit, 0);
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtBunga, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label29, 0);
            this.Controls.SetChildIndex(this.label30, 0);
            this.Controls.SetChildIndex(this.txtSisaPokok, 0);
            this.Controls.SetChildIndex(this.txtJmlAngsuran, 0);
            this.Controls.SetChildIndex(this.label31, 0);
            this.Controls.SetChildIndex(this.txtBungaBulanan, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtUMBaru, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtHargaOff, 0);
            this.Controls.SetChildIndex(this.txtTglAwalAngs, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtDiscountPrev, 0);
            this.Controls.SetChildIndex(this.lookUpSurveyor1, 0);
            this.Controls.SetChildIndex(this.lblSurveyor, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtBiayaADMBaru, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numKredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSAVE;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.NumericTextBox txtDPSubsidi;
        private System.Windows.Forms.Label label44;
        private ISA.Controls.NumericTextBox txtUangMuka;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.NumericTextBox txtDPPelanggan;
        private System.Windows.Forms.Label label23;
        private ISA.Controls.NumericTextBox txtFauxTotal;
        private System.Windows.Forms.Label label55;
        private ISA.Controls.NumericTextBox txtHargaOTR;
        private System.Windows.Forms.Label label53;
        private ISA.Controls.DateTextBox txtTglJual;
        private ISA.Controls.CommonTextBox txtSistemBayar;
        private ISA.Controls.CommonTextBox txtNoRangka;
        private ISA.Controls.CommonTextBox txtNama;
        private ISA.Controls.CommonTextBox txtNoBukti;
        private ISA.Controls.CommonTextBox txtNoTrans;
        private ISA.Controls.NumericTextBox txtBayarUM;
        private ISA.Controls.NumericTextBox txtDiscount;
        private ISA.Controls.NumericTextBox txtBiayaADM;
        private ISA.Controls.NumericTextBox txtBBN;
        private ISA.Controls.NumericTextBox txtHargaJadi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.NumericTextBox txtBungaBulanan;
        private System.Windows.Forms.Label label31;
        private ISA.Controls.NumericTextBox txtJmlAngsuran;
        private ISA.Controls.NumericTextBox txtSisaPokok;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label14;
        private ISA.Controls.NumericTextBox txtBunga;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown numKredit;
        private System.Windows.Forms.Label label24;
        private ISA.Controls.NumericTextBox txtUMBaru;
        private System.Windows.Forms.Label label15;
        private ISA.Controls.NumericTextBox txtHargaOff;
        private System.Windows.Forms.Label label16;
        private ISA.Controls.DateTextBox txtTglAwalAngs;
        private System.Windows.Forms.Label label17;
        private ISA.Controls.NumericTextBox txtDiscountPrev;
        private System.Windows.Forms.Label label18;
        private ISA.Showroom.Controls.LookUpSurveyor lookUpSurveyor1;
        private System.Windows.Forms.Label lblSurveyor;
        private ISA.Controls.NumericTextBox txtBiayaADMBaru;
        private System.Windows.Forms.Label label19;
    }
}