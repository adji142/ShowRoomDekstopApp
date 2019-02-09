namespace ISA.Showroom.Finance.Kasir
{
    partial class frmIdenBBNPelunasan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdenBBNPelunasan));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_NamaCustomer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_SisaBBN = new ISA.Controls.NumericTextBox();
            this.txt_BayarBBN = new ISA.Controls.NumericTextBox();
            this.txt_NominalBBN = new ISA.Controls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Keterangan = new System.Windows.Forms.TextBox();
            this.txt_KodeTrans = new System.Windows.Forms.TextBox();
            this.txt_NoTrans = new System.Windows.Forms.TextBox();
            this.txt_NoBukti = new System.Windows.Forms.TextBox();
            this.txt_TglJual = new ISA.Controls.DateTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpJnsPengeluaran = new System.Windows.Forms.GroupBox();
            this.pnlBank = new System.Windows.Forms.Panel();
            this.pnlKas = new System.Windows.Forms.Panel();
            this.cboKas = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rdoBank = new System.Windows.Forms.RadioButton();
            this.rdoKas = new System.Windows.Forms.RadioButton();
            this.txt_BBN = new ISA.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdYES = new ISA.Controls.CommandButton();
            this.cmdCANCEL = new ISA.Controls.CommandButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_NoSTNK = new System.Windows.Forms.TextBox();
            this.txt_NoReg = new System.Windows.Forms.TextBox();
            this.txt_NamaSTNK = new System.Windows.Forms.TextBox();
            this.txt_AlamatSTNK = new System.Windows.Forms.TextBox();
            this.txt_NoRangka = new System.Windows.Forms.TextBox();
            this.txt_NoMesin = new System.Windows.Forms.TextBox();
            this.txt_Warna = new System.Windows.Forms.TextBox();
            this.lkpRekening1 = new ISA.Showroom.Finance.Controls.LookUpRekening();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpJnsPengeluaran.SuspendLayout();
            this.pnlBank.SuspendLayout();
            this.pnlKas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(65, 69);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_Warna);
            this.splitContainer1.Panel2.Controls.Add(this.txt_NoMesin);
            this.splitContainer1.Panel2.Controls.Add(this.txt_NoRangka);
            this.splitContainer1.Panel2.Controls.Add(this.txt_AlamatSTNK);
            this.splitContainer1.Panel2.Controls.Add(this.txt_NamaSTNK);
            this.splitContainer1.Panel2.Controls.Add(this.txt_NoReg);
            this.splitContainer1.Panel2.Controls.Add(this.txt_NoSTNK);
            this.splitContainer1.Panel2.Controls.Add(this.label19);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.label17);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.grpJnsPengeluaran);
            this.splitContainer1.Panel2.Controls.Add(this.txt_BBN);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Size = new System.Drawing.Size(788, 482);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_NamaCustomer);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt_SisaBBN);
            this.panel1.Controls.Add(this.txt_BayarBBN);
            this.panel1.Controls.Add(this.txt_NominalBBN);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_Keterangan);
            this.panel1.Controls.Add(this.txt_KodeTrans);
            this.panel1.Controls.Add(this.txt_NoTrans);
            this.panel1.Controls.Add(this.txt_NoBukti);
            this.panel1.Controls.Add(this.txt_TglJual);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 170);
            this.panel1.TabIndex = 0;
            // 
            // txt_NamaCustomer
            // 
            this.txt_NamaCustomer.Enabled = false;
            this.txt_NamaCustomer.Location = new System.Drawing.Point(491, 85);
            this.txt_NamaCustomer.Name = "txt_NamaCustomer";
            this.txt_NamaCustomer.ReadOnly = true;
            this.txt_NamaCustomer.Size = new System.Drawing.Size(176, 20);
            this.txt_NamaCustomer.TabIndex = 17;
            this.txt_NamaCustomer.TextChanged += new System.EventHandler(this.txt_NamaCustomer_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(390, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 16;
            this.label12.Text = "Customer";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txt_SisaBBN
            // 
            this.txt_SisaBBN.Enabled = false;
            this.txt_SisaBBN.Location = new System.Drawing.Point(491, 58);
            this.txt_SisaBBN.Name = "txt_SisaBBN";
            this.txt_SisaBBN.ReadOnly = true;
            this.txt_SisaBBN.Size = new System.Drawing.Size(176, 20);
            this.txt_SisaBBN.TabIndex = 15;
            this.txt_SisaBBN.Text = "0";
            this.txt_SisaBBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_BayarBBN
            // 
            this.txt_BayarBBN.Enabled = false;
            this.txt_BayarBBN.Location = new System.Drawing.Point(491, 34);
            this.txt_BayarBBN.Name = "txt_BayarBBN";
            this.txt_BayarBBN.ReadOnly = true;
            this.txt_BayarBBN.Size = new System.Drawing.Size(176, 20);
            this.txt_BayarBBN.TabIndex = 14;
            this.txt_BayarBBN.Text = "0";
            this.txt_BayarBBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_NominalBBN
            // 
            this.txt_NominalBBN.Enabled = false;
            this.txt_NominalBBN.Location = new System.Drawing.Point(491, 10);
            this.txt_NominalBBN.Name = "txt_NominalBBN";
            this.txt_NominalBBN.ReadOnly = true;
            this.txt_NominalBBN.Size = new System.Drawing.Size(176, 20);
            this.txt_NominalBBN.TabIndex = 13;
            this.txt_NominalBBN.Text = "0";
            this.txt_NominalBBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Sisa BBN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(388, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Bayar BBN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nominal BBN";
            // 
            // txt_Keterangan
            // 
            this.txt_Keterangan.Enabled = false;
            this.txt_Keterangan.Location = new System.Drawing.Point(123, 111);
            this.txt_Keterangan.Multiline = true;
            this.txt_Keterangan.Name = "txt_Keterangan";
            this.txt_Keterangan.ReadOnly = true;
            this.txt_Keterangan.Size = new System.Drawing.Size(544, 54);
            this.txt_Keterangan.TabIndex = 9;
            // 
            // txt_KodeTrans
            // 
            this.txt_KodeTrans.Enabled = false;
            this.txt_KodeTrans.Location = new System.Drawing.Point(123, 84);
            this.txt_KodeTrans.Name = "txt_KodeTrans";
            this.txt_KodeTrans.ReadOnly = true;
            this.txt_KodeTrans.Size = new System.Drawing.Size(193, 20);
            this.txt_KodeTrans.TabIndex = 8;
            // 
            // txt_NoTrans
            // 
            this.txt_NoTrans.Enabled = false;
            this.txt_NoTrans.Location = new System.Drawing.Point(123, 58);
            this.txt_NoTrans.Name = "txt_NoTrans";
            this.txt_NoTrans.ReadOnly = true;
            this.txt_NoTrans.Size = new System.Drawing.Size(193, 20);
            this.txt_NoTrans.TabIndex = 7;
            // 
            // txt_NoBukti
            // 
            this.txt_NoBukti.Enabled = false;
            this.txt_NoBukti.Location = new System.Drawing.Point(123, 35);
            this.txt_NoBukti.Name = "txt_NoBukti";
            this.txt_NoBukti.ReadOnly = true;
            this.txt_NoBukti.Size = new System.Drawing.Size(193, 20);
            this.txt_NoBukti.TabIndex = 6;
            // 
            // txt_TglJual
            // 
            this.txt_TglJual.DateValue = null;
            this.txt_TglJual.Enabled = false;
            this.txt_TglJual.Location = new System.Drawing.Point(123, 10);
            this.txt_TglJual.MaxLength = 10;
            this.txt_TglJual.Name = "txt_TglJual";
            this.txt_TglJual.ReadOnly = true;
            this.txt_TglJual.Size = new System.Drawing.Size(193, 20);
            this.txt_TglJual.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Keterangan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kode Trans";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "No Trans";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "No Bukti";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tgl Jual";
            // 
            // grpJnsPengeluaran
            // 
            this.grpJnsPengeluaran.Controls.Add(this.pnlBank);
            this.grpJnsPengeluaran.Controls.Add(this.pnlKas);
            this.grpJnsPengeluaran.Controls.Add(this.rdoBank);
            this.grpJnsPengeluaran.Controls.Add(this.rdoKas);
            this.grpJnsPengeluaran.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpJnsPengeluaran.Location = new System.Drawing.Point(28, 188);
            this.grpJnsPengeluaran.Name = "grpJnsPengeluaran";
            this.grpJnsPengeluaran.Size = new System.Drawing.Size(712, 107);
            this.grpJnsPengeluaran.TabIndex = 12;
            this.grpJnsPengeluaran.TabStop = false;
            this.grpJnsPengeluaran.Text = "Pengeluaran Dari";
            // 
            // pnlBank
            // 
            this.pnlBank.Controls.Add(this.lkpRekening1);
            this.pnlBank.Location = new System.Drawing.Point(105, 19);
            this.pnlBank.Name = "pnlBank";
            this.pnlBank.Size = new System.Drawing.Size(576, 78);
            this.pnlBank.TabIndex = 58;
            this.pnlBank.Visible = false;
            // 
            // pnlKas
            // 
            this.pnlKas.Controls.Add(this.cboKas);
            this.pnlKas.Controls.Add(this.label11);
            this.pnlKas.Location = new System.Drawing.Point(110, 13);
            this.pnlKas.Name = "pnlKas";
            this.pnlKas.Size = new System.Drawing.Size(586, 86);
            this.pnlKas.TabIndex = 57;
            this.pnlKas.Visible = false;
            // 
            // cboKas
            // 
            this.cboKas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKas.FormattingEnabled = true;
            this.cboKas.Location = new System.Drawing.Point(107, 7);
            this.cboKas.Name = "cboKas";
            this.cboKas.Size = new System.Drawing.Size(303, 22);
            this.cboKas.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 14);
            this.label11.TabIndex = 4;
            this.label11.Text = "Kas";
            // 
            // rdoBank
            // 
            this.rdoBank.AutoSize = true;
            this.rdoBank.Location = new System.Drawing.Point(27, 46);
            this.rdoBank.Name = "rdoBank";
            this.rdoBank.Size = new System.Drawing.Size(52, 18);
            this.rdoBank.TabIndex = 12;
            this.rdoBank.TabStop = true;
            this.rdoBank.Text = "Bank";
            this.rdoBank.UseVisualStyleBackColor = true;
            this.rdoBank.CheckedChanged += new System.EventHandler(this.rdoBank_CheckedChanged);
            // 
            // rdoKas
            // 
            this.rdoKas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoKas.AutoSize = true;
            this.rdoKas.Location = new System.Drawing.Point(27, 19);
            this.rdoKas.Name = "rdoKas";
            this.rdoKas.Size = new System.Drawing.Size(45, 18);
            this.rdoKas.TabIndex = 12;
            this.rdoKas.TabStop = true;
            this.rdoKas.Text = "Kas";
            this.rdoKas.UseVisualStyleBackColor = true;
            this.rdoKas.CheckedChanged += new System.EventHandler(this.rdoKas_CheckedChanged);
            // 
            // txt_BBN
            // 
            this.txt_BBN.Location = new System.Drawing.Point(125, 156);
            this.txt_BBN.Name = "txt_BBN";
            this.txt_BBN.Size = new System.Drawing.Size(193, 20);
            this.txt_BBN.TabIndex = 2;
            this.txt_BBN.Text = "0";
            this.txt_BBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 1;
            this.label10.Text = "BBN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "DATA STNK";
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(90, 557);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 6;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // cmdCANCEL
            // 
            this.cmdCANCEL.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCANCEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("cmdCANCEL.Image")));
            this.cmdCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCANCEL.Location = new System.Drawing.Point(581, 557);
            this.cmdCANCEL.Name = "cmdCANCEL";
            this.cmdCANCEL.Size = new System.Drawing.Size(100, 40);
            this.cmdCANCEL.TabIndex = 7;
            this.cmdCANCEL.Text = "CANCEL";
            this.cmdCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCANCEL.UseVisualStyleBackColor = true;
            this.cmdCANCEL.Click += new System.EventHandler(this.cmdCANCEL_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 14);
            this.label13.TabIndex = 13;
            this.label13.Text = "No STNK";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 14);
            this.label14.TabIndex = 14;
            this.label14.Text = "No Registrasi";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 14);
            this.label15.TabIndex = 15;
            this.label15.Text = "Nama STNK";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 106);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 14);
            this.label16.TabIndex = 16;
            this.label16.Text = "Alamat STNK";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(392, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 14);
            this.label17.TabIndex = 17;
            this.label17.Text = "No Rangka";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(392, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 14);
            this.label18.TabIndex = 18;
            this.label18.Text = "No Mesin";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(392, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 14);
            this.label19.TabIndex = 19;
            this.label19.Text = "Warna";
            // 
            // txt_NoSTNK
            // 
            this.txt_NoSTNK.Location = new System.Drawing.Point(125, 25);
            this.txt_NoSTNK.Name = "txt_NoSTNK";
            this.txt_NoSTNK.Size = new System.Drawing.Size(193, 20);
            this.txt_NoSTNK.TabIndex = 20;
            // 
            // txt_NoReg
            // 
            this.txt_NoReg.Location = new System.Drawing.Point(125, 52);
            this.txt_NoReg.Name = "txt_NoReg";
            this.txt_NoReg.Size = new System.Drawing.Size(193, 20);
            this.txt_NoReg.TabIndex = 21;
            // 
            // txt_NamaSTNK
            // 
            this.txt_NamaSTNK.Location = new System.Drawing.Point(125, 80);
            this.txt_NamaSTNK.Name = "txt_NamaSTNK";
            this.txt_NamaSTNK.Size = new System.Drawing.Size(193, 20);
            this.txt_NamaSTNK.TabIndex = 22;
            // 
            // txt_AlamatSTNK
            // 
            this.txt_AlamatSTNK.Location = new System.Drawing.Point(125, 107);
            this.txt_AlamatSTNK.Multiline = true;
            this.txt_AlamatSTNK.Name = "txt_AlamatSTNK";
            this.txt_AlamatSTNK.Size = new System.Drawing.Size(544, 39);
            this.txt_AlamatSTNK.TabIndex = 23;
            // 
            // txt_NoRangka
            // 
            this.txt_NoRangka.Location = new System.Drawing.Point(493, 25);
            this.txt_NoRangka.Name = "txt_NoRangka";
            this.txt_NoRangka.Size = new System.Drawing.Size(176, 20);
            this.txt_NoRangka.TabIndex = 24;
            // 
            // txt_NoMesin
            // 
            this.txt_NoMesin.Location = new System.Drawing.Point(493, 51);
            this.txt_NoMesin.Name = "txt_NoMesin";
            this.txt_NoMesin.Size = new System.Drawing.Size(176, 20);
            this.txt_NoMesin.TabIndex = 25;
            // 
            // txt_Warna
            // 
            this.txt_Warna.Location = new System.Drawing.Point(493, 79);
            this.txt_Warna.Name = "txt_Warna";
            this.txt_Warna.Size = new System.Drawing.Size(176, 20);
            this.txt_Warna.TabIndex = 26;
            // 
            // lkpRekening1
            // 
            this.lkpRekening1.BankRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkpRekening1.Cursor = System.Windows.Forms.Cursors.Default;
            this.lkpRekening1.Location = new System.Drawing.Point(14, 1);
            this.lkpRekening1.MataUangIDRekening = "";
            this.lkpRekening1.MinimumSize = new System.Drawing.Size(280, 25);
            this.lkpRekening1.Name = "lkpRekening1";
            this.lkpRekening1.PerusahaanID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkpRekening1.RekeningRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkpRekening1.Size = new System.Drawing.Size(435, 75);
            this.lkpRekening1.TabIndex = 14;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmIdenBBNPelunasan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 609);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdCANCEL);
            this.Controls.Add(this.cmdYES);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmIdenBBNPelunasan";
            this.Text = "Pelunasan BBN";
            this.Title = "Pelunasan BBN";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmIdenBBNPelunasan_Load);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCANCEL, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpJnsPengeluaran.ResumeLayout(false);
            this.grpJnsPengeluaran.PerformLayout();
            this.pnlBank.ResumeLayout(false);
            this.pnlKas.ResumeLayout(false);
            this.pnlKas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_NoBukti;
        private ISA.Controls.DateTextBox txt_TglJual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NoTrans;
        private System.Windows.Forms.TextBox txt_Keterangan;
        private System.Windows.Forms.TextBox txt_KodeTrans;
        private ISA.Controls.NumericTextBox txt_SisaBBN;
        private ISA.Controls.NumericTextBox txt_BayarBBN;
        private ISA.Controls.NumericTextBox txt_NominalBBN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.NumericTextBox txt_BBN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.CommandButton cmdYES;
        private ISA.Controls.CommandButton cmdCANCEL;
        private System.Windows.Forms.GroupBox grpJnsPengeluaran;
        private System.Windows.Forms.Panel pnlBank;
        private ISA.Showroom.Finance.Controls.LookUpRekening lkpRekening1;
        private System.Windows.Forms.Panel pnlKas;
        private System.Windows.Forms.ComboBox cboKas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdoBank;
        private System.Windows.Forms.RadioButton rdoKas;
        private System.Windows.Forms.TextBox txt_NamaCustomer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_AlamatSTNK;
        private System.Windows.Forms.TextBox txt_NamaSTNK;
        private System.Windows.Forms.TextBox txt_NoReg;
        private System.Windows.Forms.TextBox txt_NoSTNK;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Warna;
        private System.Windows.Forms.TextBox txt_NoMesin;
        private System.Windows.Forms.TextBox txt_NoRangka;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}