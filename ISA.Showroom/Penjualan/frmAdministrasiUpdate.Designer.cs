namespace ISA.Showroom.Penjualan
{
    partial class frmAdministrasiUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrasiUpdate));
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.lblKelkec = new System.Windows.Forms.Label();
            this.lblKotaProv = new System.Windows.Forms.Label();
            this.lblNoFaktur = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblTglJual = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKodeTrans = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNoTrans = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTglLunas = new ISA.Controls.DateTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.lblSisaUM = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpRekening1 = new ISA.Showroom.Controls.LookUpRekening();
            this.cbxBentukPembayaran = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTglBG = new ISA.Controls.DateTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoBG = new ISA.Controls.CommonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNominal = new ISA.Controls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grpPBL = new System.Windows.Forms.GroupBox();
            this.txtNominalPembayaranPBL = new ISA.Controls.NumericTextBox();
            this.txtNominalPembulatan = new ISA.Controls.NumericTextBox();
            this.cboPembulatan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpPBL.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(171, 542);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(26, 542);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblKelkec
            // 
            this.lblKelkec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKelkec.AutoSize = true;
            this.lblKelkec.Location = new System.Drawing.Point(139, 60);
            this.lblKelkec.Name = "lblKelkec";
            this.lblKelkec.Size = new System.Drawing.Size(0, 14);
            this.lblKelkec.TabIndex = 63;
            // 
            // lblKotaProv
            // 
            this.lblKotaProv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKotaProv.AutoSize = true;
            this.lblKotaProv.Location = new System.Drawing.Point(139, 85);
            this.lblKotaProv.Name = "lblKotaProv";
            this.lblKotaProv.Size = new System.Drawing.Size(0, 14);
            this.lblKotaProv.TabIndex = 64;
            // 
            // lblNoFaktur
            // 
            this.lblNoFaktur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNoFaktur.AutoSize = true;
            this.lblNoFaktur.Location = new System.Drawing.Point(463, 35);
            this.lblNoFaktur.Name = "lblNoFaktur";
            this.lblNoFaktur.Size = new System.Drawing.Size(0, 14);
            this.lblNoFaktur.TabIndex = 55;
            // 
            // lblAlamat
            // 
            this.lblAlamat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(139, 35);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(0, 14);
            this.lblAlamat.TabIndex = 53;
            // 
            // lblTglJual
            // 
            this.lblTglJual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTglJual.AutoSize = true;
            this.lblTglJual.Location = new System.Drawing.Point(463, 10);
            this.lblTglJual.Name = "lblTglJual";
            this.lblTglJual.Size = new System.Drawing.Size(0, 14);
            this.lblTglJual.TabIndex = 54;
            // 
            // lblNama
            // 
            this.lblNama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(139, 10);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(0, 14);
            this.lblNama.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 44;
            this.label2.Text = "No. Faktur";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 14);
            this.label11.TabIndex = 42;
            this.label11.Text = "Alamat";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(338, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 14);
            this.label13.TabIndex = 43;
            this.label13.Text = "Tgl. Penjualan";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "Terima Dari";
            // 
            // lblKodeTrans
            // 
            this.lblKodeTrans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKodeTrans.AutoSize = true;
            this.lblKodeTrans.Location = new System.Drawing.Point(137, 72);
            this.lblKodeTrans.Name = "lblKodeTrans";
            this.lblKodeTrans.Size = new System.Drawing.Size(0, 14);
            this.lblKodeTrans.TabIndex = 106;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 105;
            this.label4.Text = "Kode Transaksi";
            // 
            // lblNoTrans
            // 
            this.lblNoTrans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNoTrans.AutoSize = true;
            this.lblNoTrans.Location = new System.Drawing.Point(137, 43);
            this.lblNoTrans.Name = "lblNoTrans";
            this.lblNoTrans.Size = new System.Drawing.Size(0, 14);
            this.lblNoTrans.TabIndex = 104;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 41);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(74, 14);
            this.label30.TabIndex = 103;
            this.label30.Text = "No. Kwitansi";
            // 
            // txtTglLunas
            // 
            this.txtTglLunas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTglLunas.DateValue = null;
            this.txtTglLunas.Location = new System.Drawing.Point(134, 101);
            this.txtTglLunas.MaxLength = 10;
            this.txtTglLunas.Name = "txtTglLunas";
            this.txtTglLunas.Size = new System.Drawing.Size(110, 20);
            this.txtTglLunas.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 102);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(87, 14);
            this.label29.TabIndex = 101;
            this.label29.Text = "Tgl. Pelunasan";
            // 
            // cboMataUang
            // 
            this.cboMataUang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMataUang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(135, 131);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(89, 22);
            this.cboMataUang.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 131);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 90;
            this.label27.Text = "Mata Uang";
            // 
            // lblSisaUM
            // 
            this.lblSisaUM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSisaUM.AutoSize = true;
            this.lblSisaUM.Location = new System.Drawing.Point(137, 17);
            this.lblSisaUM.Name = "lblSisaUM";
            this.lblSisaUM.Size = new System.Drawing.Size(0, 14);
            this.lblSisaUM.TabIndex = 47;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 14);
            this.label15.TabIndex = 41;
            this.label15.Text = "Biaya Administrasi";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblKelkec);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNama);
            this.panel1.Controls.Add(this.lblKotaProv);
            this.panel1.Controls.Add(this.lblTglJual);
            this.panel1.Controls.Add(this.lblAlamat);
            this.panel1.Controls.Add(this.lblNoFaktur);
            this.panel1.Location = new System.Drawing.Point(26, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 118);
            this.panel1.TabIndex = 115;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtUraian);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lookUpRekening1);
            this.panel2.Controls.Add(this.cbxBentukPembayaran);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtTglBG);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNoBG);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtNominal);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lblSisaUM);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.cboMataUang);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.txtTglLunas);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.lblNoTrans);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblKodeTrans);
            this.panel2.Location = new System.Drawing.Point(26, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 269);
            this.panel2.TabIndex = 116;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtUraian
            // 
            this.txtUraian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(134, 168);
            this.txtUraian.MaxLength = 250;
            this.txtUraian.Multiline = true;
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(260, 86);
            this.txtUraian.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 14);
            this.label7.TabIndex = 140;
            this.label7.Text = "Uraian";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 138;
            this.label5.Text = "Rekening";
            // 
            // lookUpRekening1
            // 
            this.lookUpRekening1.Location = new System.Drawing.Point(444, 46);
            this.lookUpRekening1.NamaRekening = null;
            this.lookUpRekening1.Name = "lookUpRekening1";
            this.lookUpRekening1.NoPerkiraanRekening = null;
            this.lookUpRekening1.NoRekening = null;
            this.lookUpRekening1.RekeningRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpRekening1.Size = new System.Drawing.Size(227, 39);
            this.lookUpRekening1.TabIndex = 3;
            // 
            // cbxBentukPembayaran
            // 
            this.cbxBentukPembayaran.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBentukPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBentukPembayaran.FormattingEnabled = true;
            this.cbxBentukPembayaran.Items.AddRange(new object[] {
            "Tunai",
            "Transfer",
            "Titipan"});
            this.cbxBentukPembayaran.Location = new System.Drawing.Point(450, 14);
            this.cbxBentukPembayaran.Name = "cbxBentukPembayaran";
            this.cbxBentukPembayaran.Size = new System.Drawing.Size(129, 22);
            this.cbxBentukPembayaran.TabIndex = 2;
            this.cbxBentukPembayaran.SelectedIndexChanged += new System.EventHandler(this.cbxBentukPembayaran_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 14);
            this.label9.TabIndex = 135;
            this.label9.Text = "Bentuk Pembayaran";
            // 
            // txtTglBG
            // 
            this.txtTglBG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTglBG.DateValue = null;
            this.txtTglBG.Location = new System.Drawing.Point(452, 117);
            this.txtTglBG.MaxLength = 10;
            this.txtTglBG.Name = "txtTglBG";
            this.txtTglBG.Size = new System.Drawing.Size(173, 20);
            this.txtTglBG.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 133;
            this.label6.Text = "Tgl. Jatuh Tempo";
            // 
            // txtNoBG
            // 
            this.txtNoBG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoBG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBG.Location = new System.Drawing.Point(452, 91);
            this.txtNoBG.MaxLength = 15;
            this.txtNoBG.Name = "txtNoBG";
            this.txtNoBG.Size = new System.Drawing.Size(173, 20);
            this.txtNoBG.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 132;
            this.label8.Text = "No. BG/CH/TR";
            // 
            // txtNominal
            // 
            this.txtNominal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNominal.Enabled = false;
            this.txtNominal.Format = "N0";
            this.txtNominal.Location = new System.Drawing.Point(452, 141);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.ReadOnly = true;
            this.txtNominal.Size = new System.Drawing.Size(173, 20);
            this.txtNominal.TabIndex = 6;
            this.txtNominal.Text = "0";
            this.txtNominal.TextChanged += new System.EventHandler(this.txtNominal_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(298, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 14);
            this.label12.TabIndex = 130;
            this.label12.Text = "Nominal Pelunasan";
            // 
            // grpPBL
            // 
            this.grpPBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPBL.Controls.Add(this.txtNominalPembayaranPBL);
            this.grpPBL.Controls.Add(this.txtNominalPembulatan);
            this.grpPBL.Controls.Add(this.cboPembulatan);
            this.grpPBL.Controls.Add(this.label3);
            this.grpPBL.Controls.Add(this.label10);
            this.grpPBL.Controls.Add(this.label14);
            this.grpPBL.Location = new System.Drawing.Point(26, 450);
            this.grpPBL.Name = "grpPBL";
            this.grpPBL.Size = new System.Drawing.Size(672, 88);
            this.grpPBL.TabIndex = 117;
            this.grpPBL.TabStop = false;
            this.grpPBL.Text = "Pembulatan";
            // 
            // txtNominalPembayaranPBL
            // 
            this.txtNominalPembayaranPBL.Enabled = false;
            this.txtNominalPembayaranPBL.Location = new System.Drawing.Point(449, 53);
            this.txtNominalPembayaranPBL.Name = "txtNominalPembayaranPBL";
            this.txtNominalPembayaranPBL.ReadOnly = true;
            this.txtNominalPembayaranPBL.Size = new System.Drawing.Size(147, 20);
            this.txtNominalPembayaranPBL.TabIndex = 5;
            this.txtNominalPembayaranPBL.Text = "0";
            // 
            // txtNominalPembulatan
            // 
            this.txtNominalPembulatan.Enabled = false;
            this.txtNominalPembulatan.Location = new System.Drawing.Point(143, 53);
            this.txtNominalPembulatan.Name = "txtNominalPembulatan";
            this.txtNominalPembulatan.ReadOnly = true;
            this.txtNominalPembulatan.Size = new System.Drawing.Size(147, 20);
            this.txtNominalPembulatan.TabIndex = 4;
            this.txtNominalPembulatan.Text = "0";
            // 
            // cboPembulatan
            // 
            this.cboPembulatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPembulatan.FormattingEnabled = true;
            this.cboPembulatan.Items.AddRange(new object[] {
            "100",
            "500",
            "1000"});
            this.cboPembulatan.Location = new System.Drawing.Point(143, 25);
            this.cboPembulatan.Name = "cboPembulatan";
            this.cboPembulatan.Size = new System.Drawing.Size(147, 22);
            this.cboPembulatan.TabIndex = 3;
            this.cboPembulatan.SelectedIndexChanged += new System.EventHandler(this.cboPembulatan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nominal Pembayaran";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 14);
            this.label10.TabIndex = 1;
            this.label10.Text = "Nominal Pembulatan";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Pembulatan";
            // 
            // frmAdministrasiUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 594);
            this.Controls.Add(this.grpPBL);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdministrasiUpdate";
            this.Text = "Kwitansi Biaya Administrasi";
            this.Title = "Kwitansi Biaya Administrasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmAdministrasiUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdministrasiUpdate_FormClosed);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.grpPBL, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpPBL.ResumeLayout(false);
            this.grpPBL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label lblKelkec;
        private System.Windows.Forms.Label lblKotaProv;
        private System.Windows.Forms.Label lblNoFaktur;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblTglJual;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKodeTrans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNoTrans;
        private System.Windows.Forms.Label label30;
        private ISA.Controls.DateTextBox txtTglLunas;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblSisaUM;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private ISA.Showroom.Controls.LookUpRekening lookUpRekening1;
        private System.Windows.Forms.ComboBox cbxBentukPembayaran;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.DateTextBox txtTglBG;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.CommonTextBox txtNoBG;
        private System.Windows.Forms.Label label8;
        private ISA.Controls.NumericTextBox txtNominal;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpPBL;
        private ISA.Controls.NumericTextBox txtNominalPembayaranPBL;
        private ISA.Controls.NumericTextBox txtNominalPembulatan;
        private System.Windows.Forms.ComboBox cboPembulatan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
    }
}