namespace ISA.Showroom.Finance.DKN
{
    partial class frmHI11
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHI11));
            this.rangeTanggal = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDataH11 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipeNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DariCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeCab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KePT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KelompokTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDKN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvKelompokTransaksiHI = new ISA.Controls.CustomGridView();
            this.RowIDKel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodekelompok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCabang = new ISA.Controls.CustomGridView();
            this.CabangId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grpSemuaData = new System.Windows.Forms.GroupBox();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataH11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelompokTransaksiHI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabang)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpSemuaData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeTanggal
            // 
            this.rangeTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTanggal.FromDate = null;
            this.rangeTanggal.Location = new System.Drawing.Point(71, 24);
            this.rangeTanggal.Name = "rangeTanggal";
            this.rangeTanggal.Size = new System.Drawing.Size(314, 22);
            this.rangeTanggal.TabIndex = 5;
            this.rangeTanggal.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal";
            // 
            // dgvDataH11
            // 
            this.dgvDataH11.AllowUserToAddRows = false;
            this.dgvDataH11.AllowUserToDeleteRows = false;
            this.dgvDataH11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataH11.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Tanggal,
            this.NoBukti,
            this.TipeNota,
            this.DariCabang,
            this.KeCab,
            this.KePT,
            this.Nominal,
            this.KelompokTransaksi,
            this.NoDKN});
            this.dgvDataH11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataH11.Location = new System.Drawing.Point(3, 16);
            this.dgvDataH11.MultiSelect = false;
            this.dgvDataH11.Name = "dgvDataH11";
            this.dgvDataH11.ReadOnly = true;
            this.dgvDataH11.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDataH11.Size = new System.Drawing.Size(913, 338);
            this.dgvDataH11.StandardTab = true;
            this.dgvDataH11.TabIndex = 3;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            dataGridViewCellStyle11.NullValue = null;
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle11;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No. Bukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // TipeNota
            // 
            this.TipeNota.DataPropertyName = "CTipeNota";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TipeNota.DefaultCellStyle = dataGridViewCellStyle12;
            this.TipeNota.HeaderText = "Tipe";
            this.TipeNota.Name = "TipeNota";
            this.TipeNota.ReadOnly = true;
            this.TipeNota.Width = 70;
            // 
            // DariCabang
            // 
            this.DariCabang.DataPropertyName = "CabangDariID";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DariCabang.DefaultCellStyle = dataGridViewCellStyle13;
            this.DariCabang.HeaderText = "DariCabang";
            this.DariCabang.Name = "DariCabang";
            this.DariCabang.ReadOnly = true;
            this.DariCabang.Width = 80;
            // 
            // KeCab
            // 
            this.KeCab.DataPropertyName = "CabangKeID";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KeCab.DefaultCellStyle = dataGridViewCellStyle14;
            this.KeCab.HeaderText = "KeCab";
            this.KeCab.Name = "KeCab";
            this.KeCab.ReadOnly = true;
            this.KeCab.Width = 80;
            // 
            // KePT
            // 
            this.KePT.DataPropertyName = "InitPT";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KePT.DefaultCellStyle = dataGridViewCellStyle15;
            this.KePT.HeaderText = "Ke PT";
            this.KePT.Name = "KePT";
            this.KePT.ReadOnly = true;
            this.KePT.Width = 80;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle16;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // KelompokTransaksi
            // 
            this.KelompokTransaksi.DataPropertyName = "KelompokTransaksi";
            this.KelompokTransaksi.HeaderText = "KelompokTransaksi";
            this.KelompokTransaksi.Name = "KelompokTransaksi";
            this.KelompokTransaksi.ReadOnly = true;
            this.KelompokTransaksi.Width = 200;
            // 
            // NoDKN
            // 
            this.NoDKN.DataPropertyName = "NoDKN";
            this.NoDKN.HeaderText = "NoDKN";
            this.NoDKN.Name = "NoDKN";
            this.NoDKN.ReadOnly = true;
            // 
            // dgvKelompokTransaksiHI
            // 
            this.dgvKelompokTransaksiHI.AllowUserToAddRows = false;
            this.dgvKelompokTransaksiHI.AllowUserToDeleteRows = false;
            this.dgvKelompokTransaksiHI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKelompokTransaksiHI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDKel,
            this.kodekelompok,
            this.keterangan});
            this.dgvKelompokTransaksiHI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKelompokTransaksiHI.Location = new System.Drawing.Point(3, 16);
            this.dgvKelompokTransaksiHI.MultiSelect = false;
            this.dgvKelompokTransaksiHI.Name = "dgvKelompokTransaksiHI";
            this.dgvKelompokTransaksiHI.ReadOnly = true;
            this.dgvKelompokTransaksiHI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvKelompokTransaksiHI.Size = new System.Drawing.Size(274, 169);
            this.dgvKelompokTransaksiHI.StandardTab = true;
            this.dgvKelompokTransaksiHI.TabIndex = 1;
            this.dgvKelompokTransaksiHI.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKelompokTransaksiHI_CellClick);
            // 
            // RowIDKel
            // 
            this.RowIDKel.DataPropertyName = "RowID";
            this.RowIDKel.HeaderText = "RowID";
            this.RowIDKel.Name = "RowIDKel";
            this.RowIDKel.ReadOnly = true;
            this.RowIDKel.Visible = false;
            // 
            // kodekelompok
            // 
            this.kodekelompok.DataPropertyName = "kodekelompok";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kodekelompok.DefaultCellStyle = dataGridViewCellStyle17;
            this.kodekelompok.HeaderText = "Kd Kel";
            this.kodekelompok.Name = "kodekelompok";
            this.kodekelompok.ReadOnly = true;
            this.kodekelompok.Width = 65;
            // 
            // keterangan
            // 
            this.keterangan.DataPropertyName = "keterangan";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.keterangan.DefaultCellStyle = dataGridViewCellStyle18;
            this.keterangan.HeaderText = "KelompokTransaksi";
            this.keterangan.Name = "keterangan";
            this.keterangan.ReadOnly = true;
            this.keterangan.Width = 170;
            // 
            // dgvCabang
            // 
            this.dgvCabang.AllowUserToAddRows = false;
            this.dgvCabang.AllowUserToDeleteRows = false;
            this.dgvCabang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CabangId,
            this.Nama});
            this.dgvCabang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCabang.Location = new System.Drawing.Point(3, 16);
            this.dgvCabang.MultiSelect = false;
            this.dgvCabang.Name = "dgvCabang";
            this.dgvCabang.ReadOnly = true;
            this.dgvCabang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCabang.Size = new System.Drawing.Size(274, 146);
            this.dgvCabang.StandardTab = true;
            this.dgvCabang.TabIndex = 2;
            this.dgvCabang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCabang_CellClick);
            // 
            // CabangId
            // 
            this.CabangId.DataPropertyName = "CabangId";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CabangId.DefaultCellStyle = dataGridViewCellStyle19;
            this.CabangId.HeaderText = "Cbg ID";
            this.CabangId.Name = "CabangId";
            this.CabangId.ReadOnly = true;
            this.CabangId.Width = 65;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Nama.DefaultCellStyle = dataGridViewCellStyle20;
            this.Nama.HeaderText = "Nama Cabang";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 170;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(20, 101);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpSemuaData);
            this.splitContainer1.Size = new System.Drawing.Size(1203, 357);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(280, 357);
            this.splitContainer2.SplitterDistance = 165;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCabang);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 165);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter data Per Cabang";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvKelompokTransaksiHI);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 188);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter data Per Kel. Transaksi";
            // 
            // grpSemuaData
            // 
            this.grpSemuaData.Controls.Add(this.dgvDataH11);
            this.grpSemuaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSemuaData.Location = new System.Drawing.Point(0, 0);
            this.grpSemuaData.Name = "grpSemuaData";
            this.grpSemuaData.Size = new System.Drawing.Size(919, 357);
            this.grpSemuaData.TabIndex = 12;
            this.grpSemuaData.TabStop = false;
            this.grpSemuaData.Text = "Semua Data HI11";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(988, 472);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 7;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1112, 472);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(318, 23);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 9;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdSearch);
            this.groupBox1.Controls.Add(this.rangeTanggal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 59);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter data";
            // 
            // frmHI11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdPrint);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHI11";
            this.Text = "HI11";
            this.Title = "HI11";
            this.Load += new System.EventHandler(this.frmHI11_Load);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataH11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelompokTransaksiHI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabang)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.grpSemuaData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeTanggal;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView dgvDataH11;
        private ISA.Controls.CustomGridView dgvKelompokTransaksiHI;
        private ISA.Controls.CustomGridView dgvCabang;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDKel;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodekelompok;
        private System.Windows.Forms.DataGridViewTextBoxColumn keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox grpSemuaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipeNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn DariCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeCab;
        private System.Windows.Forms.DataGridViewTextBoxColumn KePT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelompokTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDKN;
    }
}