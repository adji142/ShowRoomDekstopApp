namespace ISA.To.GLDOS
{
    partial class ToGL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        protected override void Dispose(bool disposing)
        {
            this.Hide();
        }

        private void DisposetheWindow(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToGL));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.cmdMJU = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sinkronisasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiJurnalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pembelianToGLDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialKeStokBBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keStokBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gudangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toGudangDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toGudangSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toDBFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewJournalDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewGudangDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewStokBahanBakuDBFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokBarangJadiDBFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.commonTextBox3 = new ISA.Controls.CommonTextBox();
            this.commonTextBox2 = new ISA.Controls.CommonTextBox();
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Direktori Kerja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1019, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "No.Perkiraan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jumlah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(985, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jurnal di GL DOS";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.dataGridView4);
            this.groupBox1.Controls.Add(this.cmdMJU);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(130, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 398);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaksi Jurnal";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(14, 19);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(721, 321);
            this.dataGridView4.TabIndex = 17;
            // 
            // cmdMJU
            // 
            this.cmdMJU.Location = new System.Drawing.Point(569, 346);
            this.cmdMJU.Name = "cmdMJU";
            this.cmdMJU.Size = new System.Drawing.Size(100, 40);
            this.cmdMJU.TabIndex = 16;
            this.cmdMJU.Text = "&Mulai";
            this.cmdMJU.UseVisualStyleBackColor = true;
            this.cmdMJU.Click += new System.EventHandler(this.cmdMJU_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 40);
            this.button2.TabIndex = 15;
            this.button2.Text = "&Refresh GL DOS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column13,
            this.Column12,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView1.Location = new System.Drawing.Point(14, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(721, 321);
            this.dataGridView1.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tanggal";
            this.Column1.HeaderText = "Tanggal JU";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "referensi";
            this.Column13.HeaderText = "Ref";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "no_perk";
            this.Column12.HeaderText = "No Perkiraan";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 75;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "keterangan";
            this.Column2.HeaderText = "Keterangan";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "jumlah";
            this.Column3.HeaderText = "Jumlah";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ctanggal";
            this.Column4.HeaderText = "C Tanggal";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "idrec";
            this.Column5.HeaderText = "IDREC";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id_adjust";
            this.Column6.HeaderText = "ID Adjust";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "kdcabang";
            this.Column7.HeaderText = "Kode Cabang";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "idtrdrlain";
            this.Column8.HeaderText = "ID Trdr Lain";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "kdcostcntr";
            this.Column9.HeaderText = "Kode Cost Cntr";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "nmcostcntr";
            this.Column10.HeaderText = "Nama Cost Cntr";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(675, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(739, 235);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(206, 25);
            this.progressBar1.TabIndex = 16;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(623, 508);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(18, 13);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "dir";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(822, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "label12";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(988, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinkronisasiToolStripMenuItem,
            this.resultToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sinkronisasiToolStripMenuItem
            // 
            this.sinkronisasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transaksiJurnalToolStripMenuItem,
            this.materialToolStripMenuItem,
            this.gudangToolStripMenuItem,
            this.supplierToolStripMenuItem});
            this.sinkronisasiToolStripMenuItem.Name = "sinkronisasiToolStripMenuItem";
            this.sinkronisasiToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.sinkronisasiToolStripMenuItem.Text = "&Sinkronisasi";
            // 
            // transaksiJurnalToolStripMenuItem
            // 
            this.transaksiJurnalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pembelianToGLDOSToolStripMenuItem});
            this.transaksiJurnalToolStripMenuItem.Name = "transaksiJurnalToolStripMenuItem";
            this.transaksiJurnalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.transaksiJurnalToolStripMenuItem.Text = "&Transaksi Jurnal";
            // 
            // pembelianToGLDOSToolStripMenuItem
            // 
            this.pembelianToGLDOSToolStripMenuItem.Name = "pembelianToGLDOSToolStripMenuItem";
            this.pembelianToGLDOSToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pembelianToGLDOSToolStripMenuItem.Text = "&Pembelian B.B";
            this.pembelianToGLDOSToolStripMenuItem.Click += new System.EventHandler(this.pembelianToGLDOSToolStripMenuItem_Click);
            // 
            // materialToolStripMenuItem
            // 
            this.materialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialKeStokBBToolStripMenuItem,
            this.keStokBJToolStripMenuItem});
            this.materialToolStripMenuItem.Name = "materialToolStripMenuItem";
            this.materialToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.materialToolStripMenuItem.Text = "&Material";
            // 
            // materialKeStokBBToolStripMenuItem
            // 
            this.materialKeStokBBToolStripMenuItem.Name = "materialKeStokBBToolStripMenuItem";
            this.materialKeStokBBToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.materialKeStokBBToolStripMenuItem.Text = "to Stok B.B";
            this.materialKeStokBBToolStripMenuItem.Click += new System.EventHandler(this.materialKeStokBBToolStripMenuItem_Click);
            // 
            // keStokBJToolStripMenuItem
            // 
            this.keStokBJToolStripMenuItem.Name = "keStokBJToolStripMenuItem";
            this.keStokBJToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.keStokBJToolStripMenuItem.Text = "to Stok B.J";
            this.keStokBJToolStripMenuItem.Click += new System.EventHandler(this.keStokBJToolStripMenuItem_Click);
            // 
            // gudangToolStripMenuItem
            // 
            this.gudangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toGudangDOSToolStripMenuItem,
            this.toGudangSQLToolStripMenuItem});
            this.gudangToolStripMenuItem.Name = "gudangToolStripMenuItem";
            this.gudangToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.gudangToolStripMenuItem.Text = "&Gudang";
            // 
            // toGudangDOSToolStripMenuItem
            // 
            this.toGudangDOSToolStripMenuItem.Name = "toGudangDOSToolStripMenuItem";
            this.toGudangDOSToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.toGudangDOSToolStripMenuItem.Text = "to Gudang DOS";
            this.toGudangDOSToolStripMenuItem.Click += new System.EventHandler(this.toGudangDOSToolStripMenuItem_Click);
            // 
            // toGudangSQLToolStripMenuItem
            // 
            this.toGudangSQLToolStripMenuItem.Name = "toGudangSQLToolStripMenuItem";
            this.toGudangSQLToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.toGudangSQLToolStripMenuItem.Text = "to Gudang SQL";
            this.toGudangSQLToolStripMenuItem.Click += new System.EventHandler(this.toGudangSQLToolStripMenuItem_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toSQLToolStripMenuItem,
            this.toDBFToolStripMenuItem});
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.supplierToolStripMenuItem.Text = "Supplier";
            // 
            // toSQLToolStripMenuItem
            // 
            this.toSQLToolStripMenuItem.Name = "toSQLToolStripMenuItem";
            this.toSQLToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.toSQLToolStripMenuItem.Text = "to SQL";
            this.toSQLToolStripMenuItem.Click += new System.EventHandler(this.toSQLToolStripMenuItem_Click);
            // 
            // toDBFToolStripMenuItem
            // 
            this.toDBFToolStripMenuItem.Name = "toDBFToolStripMenuItem";
            this.toDBFToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.toDBFToolStripMenuItem.Text = "to DBF";
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewJournalDOSToolStripMenuItem,
            this.previewGudangDOSToolStripMenuItem,
            this.previewStokBahanBakuDBFToolStripMenuItem,
            this.stokBarangJadiDBFToolStripMenuItem});
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.resultToolStripMenuItem.Text = "Result";
            // 
            // previewJournalDOSToolStripMenuItem
            // 
            this.previewJournalDOSToolStripMenuItem.Name = "previewJournalDOSToolStripMenuItem";
            this.previewJournalDOSToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.previewJournalDOSToolStripMenuItem.Text = "Journal DBF";
            this.previewJournalDOSToolStripMenuItem.Click += new System.EventHandler(this.previewJournalDOSToolStripMenuItem_Click);
            // 
            // previewGudangDOSToolStripMenuItem
            // 
            this.previewGudangDOSToolStripMenuItem.Name = "previewGudangDOSToolStripMenuItem";
            this.previewGudangDOSToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.previewGudangDOSToolStripMenuItem.Text = "Gudang";
            this.previewGudangDOSToolStripMenuItem.Click += new System.EventHandler(this.previewGudangDOSToolStripMenuItem_Click);
            // 
            // previewStokBahanBakuDBFToolStripMenuItem
            // 
            this.previewStokBahanBakuDBFToolStripMenuItem.Name = "previewStokBahanBakuDBFToolStripMenuItem";
            this.previewStokBahanBakuDBFToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.previewStokBahanBakuDBFToolStripMenuItem.Text = "Stok Bahan Baku DBF";
            this.previewStokBahanBakuDBFToolStripMenuItem.Click += new System.EventHandler(this.previewStokBahanBakuDBFToolStripMenuItem_Click);
            // 
            // stokBarangJadiDBFToolStripMenuItem
            // 
            this.stokBarangJadiDBFToolStripMenuItem.Name = "stokBarangJadiDBFToolStripMenuItem";
            this.stokBarangJadiDBFToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.stokBarangJadiDBFToolStripMenuItem.Text = "Stok Barang Jadi DBF";
            this.stokBarangJadiDBFToolStripMenuItem.Click += new System.EventHandler(this.stokBarangJadiDBFToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(709, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 464);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(11, 261);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(922, 189);
            this.dataGridView3.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Detail Pembelian";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(11, 44);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(922, 198);
            this.dataGridView2.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Pembelian";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 42);
            this.button3.TabIndex = 27;
            this.button3.Text = "Mulai Load Data DBF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // commonTextBox3
            // 
            this.commonTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox3.Location = new System.Drawing.Point(1094, 110);
            this.commonTextBox3.Name = "commonTextBox3";
            this.commonTextBox3.Size = new System.Drawing.Size(142, 20);
            this.commonTextBox3.TabIndex = 3;
            // 
            // commonTextBox2
            // 
            this.commonTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox2.Location = new System.Drawing.Point(1094, 88);
            this.commonTextBox2.Name = "commonTextBox2";
            this.commonTextBox2.Size = new System.Drawing.Size(142, 20);
            this.commonTextBox2.TabIndex = 2;
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Location = new System.Drawing.Point(1094, 65);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.Size = new System.Drawing.Size(142, 20);
            this.commonTextBox1.TabIndex = 1;
            // 
            // ToGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 530);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commonTextBox3);
            this.Controls.Add(this.commonTextBox2);
            this.Controls.Add(this.commonTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ToGL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinkronisasi DBF SQL Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommonTextBox commonTextBox1;
        private ISA.Controls.CommonTextBox commonTextBox2;
        private ISA.Controls.CommonTextBox commonTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyicon1;  //Declare the Notify Icon
        private System.Windows.Forms.ContextMenu contextmenu1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sinkronisasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiJurnalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pembelianToGLDOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialKeStokBBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keStokBJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gudangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toGudangDOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewJournalDOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewGudangDOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewStokBahanBakuDBFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokBarangJadiDBFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toGudangSQLToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdMJU;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDBFToolStripMenuItem;


    }
}

