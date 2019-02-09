namespace ISA.Showroom.Finance.Kasir
{
    partial class frmPenerimaanLeasingIdentifikasiPiutang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanLeasingIdentifikasiPiutang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.txt_Saldo = new ISA.Controls.NumericTextBox();
            this.txt_Leasing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Nominal = new ISA.Controls.NumericTextBox();
            this.txt_TglPenerimaan = new ISA.Controls.DateTextBox();
            this.txt_NoPembayaran = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GV_Penjualan = new ISA.Controls.CustomGridView();
            this.GV_PenerimaanUM = new ISA.Controls.CustomGridView();
            this.KodeTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leasing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrgKosong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BiayaADM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaNett = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_Penjualan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_PenerimaanUM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.rangeDateBox1);
            this.panel1.Controls.Add(this.txt_Saldo);
            this.panel1.Controls.Add(this.txt_Leasing);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_Nominal);
            this.panel1.Controls.Add(this.txt_TglPenerimaan);
            this.panel1.Controls.Add(this.txt_NoPembayaran);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(31, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 133);
            this.panel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(358, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tanggal";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(106, 99);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 11;
            this.rangeDateBox1.ToDate = null;
            // 
            // txt_Saldo
            // 
            this.txt_Saldo.Enabled = false;
            this.txt_Saldo.Location = new System.Drawing.Point(513, 58);
            this.txt_Saldo.Name = "txt_Saldo";
            this.txt_Saldo.ReadOnly = true;
            this.txt_Saldo.Size = new System.Drawing.Size(100, 20);
            this.txt_Saldo.TabIndex = 10;
            this.txt_Saldo.Text = "0";
            this.txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Leasing
            // 
            this.txt_Leasing.Enabled = false;
            this.txt_Leasing.Location = new System.Drawing.Point(513, 18);
            this.txt_Leasing.Name = "txt_Leasing";
            this.txt_Leasing.ReadOnly = true;
            this.txt_Leasing.Size = new System.Drawing.Size(100, 20);
            this.txt_Leasing.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Saldo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Leasing";
            // 
            // txt_Nominal
            // 
            this.txt_Nominal.Enabled = false;
            this.txt_Nominal.Location = new System.Drawing.Point(143, 66);
            this.txt_Nominal.Name = "txt_Nominal";
            this.txt_Nominal.ReadOnly = true;
            this.txt_Nominal.Size = new System.Drawing.Size(100, 20);
            this.txt_Nominal.TabIndex = 6;
            this.txt_Nominal.Text = "0";
            this.txt_Nominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_TglPenerimaan
            // 
            this.txt_TglPenerimaan.DateValue = null;
            this.txt_TglPenerimaan.Enabled = false;
            this.txt_TglPenerimaan.Location = new System.Drawing.Point(143, 44);
            this.txt_TglPenerimaan.MaxLength = 10;
            this.txt_TglPenerimaan.Name = "txt_TglPenerimaan";
            this.txt_TglPenerimaan.ReadOnly = true;
            this.txt_TglPenerimaan.Size = new System.Drawing.Size(100, 20);
            this.txt_TglPenerimaan.TabIndex = 5;
            // 
            // txt_NoPembayaran
            // 
            this.txt_NoPembayaran.Enabled = false;
            this.txt_NoPembayaran.Location = new System.Drawing.Point(143, 19);
            this.txt_NoPembayaran.Name = "txt_NoPembayaran";
            this.txt_NoPembayaran.ReadOnly = true;
            this.txt_NoPembayaran.Size = new System.Drawing.Size(100, 20);
            this.txt_NoPembayaran.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 14);
            this.label4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nominal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tanggal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Pembayaran ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(31, 186);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GV_Penjualan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GV_PenerimaanUM);
            this.splitContainer1.Size = new System.Drawing.Size(835, 396);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 6;
            // 
            // GV_Penjualan
            // 
            this.GV_Penjualan.AllowUserToAddRows = false;
            this.GV_Penjualan.AllowUserToDeleteRows = false;
            this.GV_Penjualan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.GV_Penjualan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GV_Penjualan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_Penjualan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NoTrans,
            this.NoBukti,
            this.Tanggal,
            this.Leasing,
            this.Customer,
            this.Sales,
            this.MataUangID,
            this.HrgKosong,
            this.BBN,
            this.BiayaADM,
            this.HargaNett});
            this.GV_Penjualan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GV_Penjualan.Location = new System.Drawing.Point(0, 0);
            this.GV_Penjualan.MultiSelect = false;
            this.GV_Penjualan.Name = "GV_Penjualan";
            this.GV_Penjualan.ReadOnly = true;
            this.GV_Penjualan.RowHeadersVisible = false;
            this.GV_Penjualan.Size = new System.Drawing.Size(835, 197);
            this.GV_Penjualan.StandardTab = true;
            this.GV_Penjualan.TabIndex = 0;
            this.GV_Penjualan.CellErrorTextChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_Penjualan_CellErrorTextChanged);
            this.GV_Penjualan.SelectionRowChanged += new System.EventHandler(this.GV_Penjualan_SelectionRowChanged);
            // 
            // GV_PenerimaanUM
            // 
            this.GV_PenerimaanUM.AllowUserToAddRows = false;
            this.GV_PenerimaanUM.AllowUserToDeleteRows = false;
            this.GV_PenerimaanUM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GV_PenerimaanUM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_PenerimaanUM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeTrans,
            this.JenisTransaksi,
            this.Piutang,
            this.Iden,
            this.Saldo});
            this.GV_PenerimaanUM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GV_PenerimaanUM.Location = new System.Drawing.Point(0, 0);
            this.GV_PenerimaanUM.Name = "GV_PenerimaanUM";
            this.GV_PenerimaanUM.ReadOnly = true;
            this.GV_PenerimaanUM.RowHeadersVisible = false;
            this.GV_PenerimaanUM.Size = new System.Drawing.Size(835, 195);
            this.GV_PenerimaanUM.StandardTab = true;
            this.GV_PenerimaanUM.TabIndex = 0;
            this.GV_PenerimaanUM.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_PenerimaanUM_CellValueChanged);
            this.GV_PenerimaanUM.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GV_PenerimaanUM_DataError);
            // 
            // KodeTrans
            // 
            this.KodeTrans.DataPropertyName = "KodeTrans";
            this.KodeTrans.HeaderText = "KodeTrans";
            this.KodeTrans.Name = "KodeTrans";
            this.KodeTrans.ReadOnly = true;
            // 
            // JenisTransaksi
            // 
            this.JenisTransaksi.DataPropertyName = "JenisTransaksi";
            this.JenisTransaksi.HeaderText = "JenisTransaksi";
            this.JenisTransaksi.Name = "JenisTransaksi";
            this.JenisTransaksi.ReadOnly = true;
            // 
            // Piutang
            // 
            this.Piutang.DataPropertyName = "Piutang";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Piutang.DefaultCellStyle = dataGridViewCellStyle6;
            this.Piutang.HeaderText = "Piutang";
            this.Piutang.Name = "Piutang";
            this.Piutang.ReadOnly = true;
            // 
            // Iden
            // 
            this.Iden.DataPropertyName = "Iden";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.Iden.DefaultCellStyle = dataGridViewCellStyle7;
            this.Iden.HeaderText = "Iden";
            this.Iden.Name = "Iden";
            this.Iden.ReadOnly = true;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle8;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(766, 588);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(31, 588);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 12;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 47;
            // 
            // NoTrans
            // 
            this.NoTrans.DataPropertyName = "NoTrans";
            this.NoTrans.HeaderText = "NoTrans";
            this.NoTrans.Name = "NoTrans";
            this.NoTrans.ReadOnly = true;
            this.NoTrans.Width = 77;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 74;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 74;
            // 
            // Leasing
            // 
            this.Leasing.DataPropertyName = "Leasing";
            this.Leasing.HeaderText = "Leasing";
            this.Leasing.Name = "Leasing";
            this.Leasing.ReadOnly = true;
            this.Leasing.Width = 76;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Width = 88;
            // 
            // Sales
            // 
            this.Sales.DataPropertyName = "Sales";
            this.Sales.HeaderText = "Sales";
            this.Sales.Name = "Sales";
            this.Sales.ReadOnly = true;
            this.Sales.Width = 62;
            // 
            // MataUangID
            // 
            this.MataUangID.DataPropertyName = "MataUangID";
            this.MataUangID.HeaderText = "MataUang";
            this.MataUangID.Name = "MataUangID";
            this.MataUangID.ReadOnly = true;
            this.MataUangID.Width = 85;
            // 
            // HrgKosong
            // 
            this.HrgKosong.DataPropertyName = "HargaOff";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.HrgKosong.DefaultCellStyle = dataGridViewCellStyle2;
            this.HrgKosong.HeaderText = "HrgKosong";
            this.HrgKosong.Name = "HrgKosong";
            this.HrgKosong.ReadOnly = true;
            this.HrgKosong.Width = 93;
            // 
            // BBN
            // 
            this.BBN.DataPropertyName = "BBN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.BBN.DefaultCellStyle = dataGridViewCellStyle3;
            this.BBN.HeaderText = "BBN";
            this.BBN.Name = "BBN";
            this.BBN.ReadOnly = true;
            this.BBN.Width = 53;
            // 
            // BiayaADM
            // 
            this.BiayaADM.DataPropertyName = "BiayaADM";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.BiayaADM.DefaultCellStyle = dataGridViewCellStyle4;
            this.BiayaADM.HeaderText = "BiayaADM";
            this.BiayaADM.Name = "BiayaADM";
            this.BiayaADM.ReadOnly = true;
            this.BiayaADM.Width = 85;
            // 
            // HargaNett
            // 
            this.HargaNett.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HargaNett.DataPropertyName = "HargaOff";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.HargaNett.DefaultCellStyle = dataGridViewCellStyle5;
            this.HargaNett.HeaderText = "HargaNett";
            this.HargaNett.Name = "HargaNett";
            this.HargaNett.ReadOnly = true;
            this.HargaNett.Width = 85;
            // 
            // frmPenerimaanLeasingIdentifikasiPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 640);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenerimaanLeasingIdentifikasiPiutang";
            this.Text = "Identifikasi Piutang Leasing";
            this.Title = "Identifikasi Piutang Leasing";
            this.Load += new System.EventHandler(this.frmPenerimaanLeasingIdentifikasiPiutang_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GV_Penjualan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_PenerimaanUM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NoPembayaran;
        private ISA.Controls.DateTextBox txt_TglPenerimaan;
        private ISA.Controls.NumericTextBox txt_Nominal;
        private ISA.Controls.NumericTextBox txt_Saldo;
        private System.Windows.Forms.TextBox txt_Leasing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CustomGridView GV_Penjualan;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CustomGridView GV_PenerimaanUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leasing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrgKosong;
        private System.Windows.Forms.DataGridViewTextBoxColumn BBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BiayaADM;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaNett;
    }
}