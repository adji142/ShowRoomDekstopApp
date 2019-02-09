namespace ISA.Showroom.Laporan
{
    partial class frmLapPenjualan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapPenjualan));
            this.lookUpCustomer1 = new ISA.Showroom.Controls.LookUpCustomer();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cboStatusLunas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdPRINT = new ISA.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboKondisi = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbOrderAsc = new System.Windows.Forms.RadioButton();
            this.rbOrderDesc = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lookUpMotor1 = new ISA.Showroom.Controls.LookUpMotor();
            this.cboOrderBy = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lookUpSalesman1 = new ISA.Showroom.Controls.LookUpSalesman();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProvinsi = new System.Windows.Forms.ComboBox();
            this.cboKota = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboKecamatan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboJnsAngsuran = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbPenjualan3 = new System.Windows.Forms.RadioButton();
            this.rbPenjualan2 = new System.Windows.Forms.RadioButton();
            this.rbPenjualan1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStatusKirim = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lookUpCustomer1
            // 
            this.lookUpCustomer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpCustomer1.Location = new System.Drawing.Point(135, 47);
            this.lookUpCustomer1.Name = "lookUpCustomer1";
            this.lookUpCustomer1.Size = new System.Drawing.Size(228, 25);
            this.lookUpCustomer1.TabIndex = 5;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(133, 15);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // cboStatusLunas
            // 
            this.cboStatusLunas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboStatusLunas.FormattingEnabled = true;
            this.cboStatusLunas.Items.AddRange(new object[] {
            "Semua",
            "Ada Pembayaran",
            "Belum Ada Pembayaran"});
            this.cboStatusLunas.Location = new System.Drawing.Point(145, 115);
            this.cboStatusLunas.Name = "cboStatusLunas";
            this.cboStatusLunas.Size = new System.Drawing.Size(121, 22);
            this.cboStatusLunas.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tanggal Penjualan";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nama Customer";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status Lunas";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(444, 498);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 12;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(269, 498);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 11;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.txtStatusKirim);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cboKondisi);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.cboOrderBy);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lookUpSalesman1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboProvinsi);
            this.panel1.Controls.Add(this.cboKota);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboKecamatan);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboJnsAngsuran);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rangeDateBox1);
            this.panel1.Controls.Add(this.cboStatusLunas);
            this.panel1.Controls.Add(this.lookUpCustomer1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(49, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 442);
            this.panel1.TabIndex = 13;
            // 
            // cboKondisi
            // 
            this.cboKondisi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboKondisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKondisi.FormattingEnabled = true;
            this.cboKondisi.Items.AddRange(new object[] {
            "Baru",
            "Bekas",
            "Semua"});
            this.cboKondisi.Location = new System.Drawing.Point(144, 80);
            this.cboKondisi.Name = "cboKondisi";
            this.cboKondisi.Size = new System.Drawing.Size(120, 22);
            this.cboKondisi.TabIndex = 117;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 14);
            this.label12.TabIndex = 116;
            this.label12.Text = "Tipe Penjualan";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.rbOrderAsc);
            this.panel4.Controls.Add(this.rbOrderDesc);
            this.panel4.Location = new System.Drawing.Point(408, 396);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 27);
            this.panel4.TabIndex = 115;
            // 
            // rbOrderAsc
            // 
            this.rbOrderAsc.AutoSize = true;
            this.rbOrderAsc.Checked = true;
            this.rbOrderAsc.Location = new System.Drawing.Point(5, 4);
            this.rbOrderAsc.Name = "rbOrderAsc";
            this.rbOrderAsc.Size = new System.Drawing.Size(66, 18);
            this.rbOrderAsc.TabIndex = 113;
            this.rbOrderAsc.TabStop = true;
            this.rbOrderAsc.Text = "A-Z, 1-9";
            this.rbOrderAsc.UseVisualStyleBackColor = true;
            this.rbOrderAsc.CheckedChanged += new System.EventHandler(this.rbOrderAsc_CheckedChanged);
            // 
            // rbOrderDesc
            // 
            this.rbOrderDesc.AutoSize = true;
            this.rbOrderDesc.Location = new System.Drawing.Point(118, 4);
            this.rbOrderDesc.Name = "rbOrderDesc";
            this.rbOrderDesc.Size = new System.Drawing.Size(66, 18);
            this.rbOrderDesc.TabIndex = 114;
            this.rbOrderDesc.Text = "Z-A, 9-1";
            this.rbOrderDesc.UseVisualStyleBackColor = true;
            this.rbOrderDesc.CheckedChanged += new System.EventHandler(this.rbOrderDesc_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.lookUpMotor1);
            this.panel3.Location = new System.Drawing.Point(135, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(409, 38);
            this.panel3.TabIndex = 112;
            // 
            // lookUpMotor1
            // 
            this.lookUpMotor1.Location = new System.Drawing.Point(-2, 6);
            this.lookUpMotor1.Name = "lookUpMotor1";
            this.lookUpMotor1.Size = new System.Drawing.Size(265, 25);
            this.lookUpMotor1.TabIndex = 106;
            // 
            // cboOrderBy
            // 
            this.cboOrderBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderBy.FormattingEnabled = true;
            this.cboOrderBy.Items.AddRange(new object[] {
            "Nama Customer",
            "Status Lunas",
            "Jenis Penjualan",
            "Jenis Transaksi",
            "Nama Salesman",
            "Kecamatan",
            "Tipe Motor",
            "Tanggal Jual",
            "No Trans"});
            this.cboOrderBy.Location = new System.Drawing.Point(145, 398);
            this.cboOrderBy.Name = "cboOrderBy";
            this.cboOrderBy.Size = new System.Drawing.Size(245, 22);
            this.cboOrderBy.TabIndex = 108;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 401);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 14);
            this.label11.TabIndex = 107;
            this.label11.Text = "Urutkan Berdasarkan";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 105;
            this.label7.Text = "Tipe";
            // 
            // lookUpSalesman1
            // 
            this.lookUpSalesman1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpSalesman1.Location = new System.Drawing.Point(133, 191);
            this.lookUpSalesman1.Name = "lookUpSalesman1";
            this.lookUpSalesman1.Size = new System.Drawing.Size(265, 27);
            this.lookUpSalesman1.TabIndex = 103;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 14);
            this.label6.TabIndex = 104;
            this.label6.Text = "Sales";
            // 
            // cboProvinsi
            // 
            this.cboProvinsi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboProvinsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvinsi.FormattingEnabled = true;
            this.cboProvinsi.Location = new System.Drawing.Point(145, 233);
            this.cboProvinsi.Name = "cboProvinsi";
            this.cboProvinsi.Size = new System.Drawing.Size(249, 22);
            this.cboProvinsi.TabIndex = 100;
            this.cboProvinsi.SelectedIndexChanged += new System.EventHandler(this.cboProvinsiIdt_SelectedIndexChanged);
            // 
            // cboKota
            // 
            this.cboKota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboKota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKota.FormattingEnabled = true;
            this.cboKota.Location = new System.Drawing.Point(144, 270);
            this.cboKota.Name = "cboKota";
            this.cboKota.Size = new System.Drawing.Size(249, 22);
            this.cboKota.TabIndex = 101;
            this.cboKota.SelectedIndexChanged += new System.EventHandler(this.cboKotaIdt_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 14);
            this.label10.TabIndex = 102;
            this.label10.Text = "Provinsi";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 99;
            this.label5.Text = "Kota";
            // 
            // cboKecamatan
            // 
            this.cboKecamatan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboKecamatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKecamatan.FormattingEnabled = true;
            this.cboKecamatan.Location = new System.Drawing.Point(144, 309);
            this.cboKecamatan.Name = "cboKecamatan";
            this.cboKecamatan.Size = new System.Drawing.Size(249, 22);
            this.cboKecamatan.TabIndex = 98;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 97;
            this.label8.Text = "Kecamatan";
            // 
            // cboJnsAngsuran
            // 
            this.cboJnsAngsuran.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboJnsAngsuran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJnsAngsuran.FormattingEnabled = true;
            this.cboJnsAngsuran.Location = new System.Drawing.Point(494, 156);
            this.cboJnsAngsuran.Name = "cboJnsAngsuran";
            this.cboJnsAngsuran.Size = new System.Drawing.Size(210, 22);
            this.cboJnsAngsuran.TabIndex = 95;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 14);
            this.label9.TabIndex = 96;
            this.label9.Text = "Jenis Transaksi";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.rbPenjualan3);
            this.panel2.Controls.Add(this.rbPenjualan2);
            this.panel2.Controls.Add(this.rbPenjualan1);
            this.panel2.Location = new System.Drawing.Point(144, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 24);
            this.panel2.TabIndex = 85;
            // 
            // rbPenjualan3
            // 
            this.rbPenjualan3.AutoSize = true;
            this.rbPenjualan3.Location = new System.Drawing.Point(128, 4);
            this.rbPenjualan3.Name = "rbPenjualan3";
            this.rbPenjualan3.Size = new System.Drawing.Size(63, 18);
            this.rbPenjualan3.TabIndex = 107;
            this.rbPenjualan3.Text = "Semua";
            this.rbPenjualan3.UseVisualStyleBackColor = true;
            this.rbPenjualan3.CheckedChanged += new System.EventHandler(this.rbPenjualan3_CheckedChanged);
            // 
            // rbPenjualan2
            // 
            this.rbPenjualan2.AutoSize = true;
            this.rbPenjualan2.Location = new System.Drawing.Point(64, 3);
            this.rbPenjualan2.Name = "rbPenjualan2";
            this.rbPenjualan2.Size = new System.Drawing.Size(58, 18);
            this.rbPenjualan2.TabIndex = 7;
            this.rbPenjualan2.Text = "Kredit";
            this.rbPenjualan2.UseVisualStyleBackColor = true;
            this.rbPenjualan2.CheckedChanged += new System.EventHandler(this.rbPenjualan2_CheckedChanged);
            // 
            // rbPenjualan1
            // 
            this.rbPenjualan1.AutoSize = true;
            this.rbPenjualan1.Checked = true;
            this.rbPenjualan1.Location = new System.Drawing.Point(3, 3);
            this.rbPenjualan1.Name = "rbPenjualan1";
            this.rbPenjualan1.Size = new System.Drawing.Size(54, 18);
            this.rbPenjualan1.TabIndex = 6;
            this.rbPenjualan1.TabStop = true;
            this.rbPenjualan1.Text = "Tunai";
            this.rbPenjualan1.UseVisualStyleBackColor = true;
            this.rbPenjualan1.CheckedChanged += new System.EventHandler(this.rbPenjualan1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 14);
            this.label2.TabIndex = 86;
            this.label2.Text = "Jenis Penjualan";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(373, 198);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 14);
            this.label13.TabIndex = 118;
            this.label13.Text = "Status Pengiriman";
            // 
            // txtStatusKirim
            // 
            this.txtStatusKirim.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStatusKirim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtStatusKirim.FormattingEnabled = true;
            this.txtStatusKirim.Items.AddRange(new object[] {
            "Semua",
            "Belum Dikirim",
            "Proses Pengiriman",
            "Sudah Diterima",
            "Gagal Kirim"});
            this.txtStatusKirim.Location = new System.Drawing.Point(494, 195);
            this.txtStatusKirim.Name = "txtStatusKirim";
            this.txtStatusKirim.Size = new System.Drawing.Size(210, 22);
            this.txtStatusKirim.TabIndex = 119;
            // 
            // frmLapPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdPRINT);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLapPenjualan";
            this.Text = "Laporan Penjualan";
            this.Title = "Laporan Penjualan";
            this.Load += new System.EventHandler(this.frmLapPenjualan_Load);
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Showroom.Controls.LookUpCustomer lookUpCustomer1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.ComboBox cboStatusLunas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdPRINT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbPenjualan2;
        private System.Windows.Forms.RadioButton rbPenjualan1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboJnsAngsuran;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboKecamatan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboProvinsi;
        private System.Windows.Forms.ComboBox cboKota;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private ISA.Showroom.Controls.LookUpSalesman lookUpSalesman1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Showroom.Controls.LookUpMotor lookUpMotor1;
        private System.Windows.Forms.RadioButton rbPenjualan3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboOrderBy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbOrderDesc;
        private System.Windows.Forms.RadioButton rbOrderAsc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboKondisi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox txtStatusKirim;
        private System.Windows.Forms.Label label13;
    }
}