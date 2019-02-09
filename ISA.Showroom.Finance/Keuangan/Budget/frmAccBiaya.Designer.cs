namespace ISA.Showroom.Finance.Keuangan.Budget
{
    partial class frmAccBiaya
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccBiaya));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGUDANG = new System.Windows.Forms.ComboBox();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.dgTransAccBiaya = new ISA.Controls.CustomGridView();
            this.CabangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPengajuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadKe11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadKe00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdTABEL = new System.Windows.Forms.Button();
            this.cmdDOWNLOAD = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUPLOAD = new ISA.Controls.CommandButton();
            this.cmdUPDATE = new System.Windows.Forms.Button();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.cmdDownloadClose = new ISA.Controls.CommandButton();
            this.cmdDownloadGo = new ISA.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFiles = new System.Windows.Forms.ComboBox();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.txtTglAjuan = new ISA.Controls.DateTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdUpdateClose = new ISA.Controls.CommandButton();
            this.cmdUpdateSave = new ISA.Controls.CommandButton();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.txtTglAcc = new ISA.Controls.DateTextBox();
            this.txtNoAcc = new ISA.Controls.CommonTextBox();
            this.txtJumlah = new ISA.Controls.NumericTextBox();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.txtTransaksi = new ISA.Controls.CommonTextBox();
            this.txt00 = new ISA.Controls.CommonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransAccBiaya)).BeginInit();
            this.panelDownload.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(772, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cabang ID";
            // 
            // cboGUDANG
            // 
            this.cboGUDANG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGUDANG.FormattingEnabled = true;
            this.cboGUDANG.Location = new System.Drawing.Point(848, 35);
            this.cboGUDANG.Name = "cboGUDANG";
            this.cboGUDANG.Size = new System.Drawing.Size(84, 22);
            this.cboGUDANG.TabIndex = 1;
            this.cboGUDANG.Leave += new System.EventHandler(this.cboGUDANG_Leave);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(833, 423);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // dgTransAccBiaya
            // 
            this.dgTransAccBiaya.AllowUserToAddRows = false;
            this.dgTransAccBiaya.AllowUserToDeleteRows = false;
            this.dgTransAccBiaya.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTransAccBiaya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransAccBiaya.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CabangID,
            this.TglPengajuan,
            this.Transaksi,
            this.NoBukti,
            this.Uraian,
            this.Jumlah,
            this.NoAcc,
            this.TglAcc,
            this.Keterangan,
            this.UploadKe11,
            this.UploadKe00,
            this.RowID});
            this.dgTransAccBiaya.Location = new System.Drawing.Point(12, 69);
            this.dgTransAccBiaya.MultiSelect = false;
            this.dgTransAccBiaya.Name = "dgTransAccBiaya";
            this.dgTransAccBiaya.ReadOnly = true;
            this.dgTransAccBiaya.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgTransAccBiaya.Size = new System.Drawing.Size(921, 344);
            this.dgTransAccBiaya.StandardTab = true;
            this.dgTransAccBiaya.TabIndex = 2;
            // 
            // CabangID
            // 
            this.CabangID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CabangID.DataPropertyName = "CabangID";
            this.CabangID.HeaderText = "CabangID";
            this.CabangID.Name = "CabangID";
            this.CabangID.ReadOnly = true;
            this.CabangID.Width = 83;
            // 
            // TglPengajuan
            // 
            this.TglPengajuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglPengajuan.DataPropertyName = "Tgl_pengajuan";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.TglPengajuan.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglPengajuan.HeaderText = "Tanggal Pengajuan";
            this.TglPengajuan.Name = "TglPengajuan";
            this.TglPengajuan.ReadOnly = true;
            this.TglPengajuan.Width = 123;
            // 
            // Transaksi
            // 
            this.Transaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Transaksi.DataPropertyName = "Transaksi";
            this.Transaksi.HeaderText = "Transaksi";
            this.Transaksi.Name = "Transaksi";
            this.Transaksi.ReadOnly = true;
            this.Transaksi.Width = 86;
            // 
            // NoBukti
            // 
            this.NoBukti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 74;
            // 
            // Uraian
            // 
            this.Uraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            // 
            // Jumlah
            // 
            this.Jumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Jumlah.DataPropertyName = "Rp";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.Jumlah.HeaderText = "Jumlah";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            this.Jumlah.Width = 72;
            // 
            // NoAcc
            // 
            this.NoAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoAcc.DataPropertyName = "NoAcc";
            this.NoAcc.HeaderText = "No Acc";
            this.NoAcc.Name = "NoAcc";
            this.NoAcc.ReadOnly = true;
            this.NoAcc.Width = 64;
            // 
            // TglAcc
            // 
            this.TglAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TglAcc.DataPropertyName = "TglAcc";
            this.TglAcc.HeaderText = "Tanggal ACC";
            this.TglAcc.Name = "TglAcc";
            this.TglAcc.ReadOnly = true;
            this.TglAcc.Width = 93;
            // 
            // Keterangan
            // 
            this.Keterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 95;
            // 
            // UploadKe11
            // 
            this.UploadKe11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UploadKe11.DataPropertyName = "UploadKe11";
            this.UploadKe11.HeaderText = "Upload ke 11";
            this.UploadKe11.Name = "UploadKe11";
            this.UploadKe11.ReadOnly = true;
            this.UploadKe11.Width = 82;
            // 
            // UploadKe00
            // 
            this.UploadKe00.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UploadKe00.DataPropertyName = "UploadKe00";
            this.UploadKe00.HeaderText = "Upload ke 00";
            this.UploadKe00.Name = "UploadKe00";
            this.UploadKe00.ReadOnly = true;
            this.UploadKe00.Width = 82;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(127, 38);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(253, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            this.rangeDateBox1.Leave += new System.EventHandler(this.rangeDateBox1_Leave);
            // 
            // cmdTABEL
            // 
            this.cmdTABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTABEL.Location = new System.Drawing.Point(638, 423);
            this.cmdTABEL.Name = "cmdTABEL";
            this.cmdTABEL.Size = new System.Drawing.Size(144, 40);
            this.cmdTABEL.TabIndex = 6;
            this.cmdTABEL.Text = "TABEL ACC BIAYA";
            this.cmdTABEL.UseVisualStyleBackColor = true;
            this.cmdTABEL.Click += new System.EventHandler(this.cmdTABEL_Click);
            // 
            // cmdDOWNLOAD
            // 
            this.cmdDOWNLOAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDOWNLOAD.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDOWNLOAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDOWNLOAD.Image = ((System.Drawing.Image)(resources.GetObject("cmdDOWNLOAD.Image")));
            this.cmdDOWNLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDOWNLOAD.Location = new System.Drawing.Point(504, 423);
            this.cmdDOWNLOAD.Name = "cmdDOWNLOAD";
            this.cmdDOWNLOAD.Size = new System.Drawing.Size(128, 40);
            this.cmdDOWNLOAD.TabIndex = 5;
            this.cmdDOWNLOAD.Text = "DOWNLOAD";
            this.cmdDOWNLOAD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDOWNLOAD.UseVisualStyleBackColor = true;
            this.cmdDOWNLOAD.Click += new System.EventHandler(this.cmdDOWNLOAD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tanggal pengajuan";
            // 
            // cmdUPLOAD
            // 
            this.cmdUPLOAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUPLOAD.CommandType = ISA.Controls.CommandButton.enCommandType.Upload;
            this.cmdUPLOAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUPLOAD.Image = ((System.Drawing.Image)(resources.GetObject("cmdUPLOAD.Image")));
            this.cmdUPLOAD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUPLOAD.Location = new System.Drawing.Point(363, 423);
            this.cmdUPLOAD.Name = "cmdUPLOAD";
            this.cmdUPLOAD.Size = new System.Drawing.Size(128, 40);
            this.cmdUPLOAD.TabIndex = 4;
            this.cmdUPLOAD.Text = "UPLOAD";
            this.cmdUPLOAD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUPLOAD.UseVisualStyleBackColor = true;
            this.cmdUPLOAD.Click += new System.EventHandler(this.cmdUPLOAD_Click);
            // 
            // cmdUPDATE
            // 
            this.cmdUPDATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUPDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUPDATE.Location = new System.Drawing.Point(12, 423);
            this.cmdUPDATE.Name = "cmdUPDATE";
            this.cmdUPDATE.Size = new System.Drawing.Size(96, 40);
            this.cmdUPDATE.TabIndex = 3;
            this.cmdUPDATE.Text = "UPDATE 11";
            this.cmdUPDATE.UseVisualStyleBackColor = true;
            this.cmdUPDATE.Click += new System.EventHandler(this.cmdUPDATE_Click);
            // 
            // panelDownload
            // 
            this.panelDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDownload.Controls.Add(this.cmdDownloadClose);
            this.panelDownload.Controls.Add(this.cmdDownloadGo);
            this.panelDownload.Controls.Add(this.label3);
            this.panelDownload.Controls.Add(this.cboFiles);
            this.panelDownload.Location = new System.Drawing.Point(513, 177);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(404, 130);
            this.panelDownload.TabIndex = 24;
            // 
            // cmdDownloadClose
            // 
            this.cmdDownloadClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdDownloadClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownloadClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownloadClose.Image")));
            this.cmdDownloadClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownloadClose.Location = new System.Drawing.Point(285, 77);
            this.cmdDownloadClose.Name = "cmdDownloadClose";
            this.cmdDownloadClose.Size = new System.Drawing.Size(100, 40);
            this.cmdDownloadClose.TabIndex = 3;
            this.cmdDownloadClose.Text = "CLOSE";
            this.cmdDownloadClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownloadClose.UseVisualStyleBackColor = true;
            this.cmdDownloadClose.Click += new System.EventHandler(this.cmdDownloadClose_Click);
            // 
            // cmdDownloadGo
            // 
            this.cmdDownloadGo.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdDownloadGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownloadGo.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownloadGo.Image")));
            this.cmdDownloadGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownloadGo.Location = new System.Drawing.Point(15, 77);
            this.cmdDownloadGo.Name = "cmdDownloadGo";
            this.cmdDownloadGo.Size = new System.Drawing.Size(128, 40);
            this.cmdDownloadGo.TabIndex = 2;
            this.cmdDownloadGo.Text = "DOWNLOAD";
            this.cmdDownloadGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownloadGo.UseVisualStyleBackColor = true;
            this.cmdDownloadGo.Click += new System.EventHandler(this.cmdDownloadGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nama file yang akan diDownload";
            // 
            // cboFiles
            // 
            this.cboFiles.FormattingEnabled = true;
            this.cboFiles.Location = new System.Drawing.Point(15, 43);
            this.cboFiles.Name = "cboFiles";
            this.cboFiles.Size = new System.Drawing.Size(370, 22);
            this.cboFiles.TabIndex = 0;
            this.cboFiles.SelectedIndexChanged += new System.EventHandler(this.cboFiles_SelectedIndexChanged);
            // 
            // panelUpdate
            // 
            this.panelUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUpdate.Controls.Add(this.txtTglAjuan);
            this.panelUpdate.Controls.Add(this.label11);
            this.panelUpdate.Controls.Add(this.label10);
            this.panelUpdate.Controls.Add(this.label9);
            this.panelUpdate.Controls.Add(this.label8);
            this.panelUpdate.Controls.Add(this.label7);
            this.panelUpdate.Controls.Add(this.label6);
            this.panelUpdate.Controls.Add(this.label5);
            this.panelUpdate.Controls.Add(this.label4);
            this.panelUpdate.Controls.Add(this.cmdUpdateClose);
            this.panelUpdate.Controls.Add(this.cmdUpdateSave);
            this.panelUpdate.Controls.Add(this.txtKeterangan);
            this.panelUpdate.Controls.Add(this.txtTglAcc);
            this.panelUpdate.Controls.Add(this.txtNoAcc);
            this.panelUpdate.Controls.Add(this.txtJumlah);
            this.panelUpdate.Controls.Add(this.txtUraian);
            this.panelUpdate.Controls.Add(this.txtTransaksi);
            this.panelUpdate.Controls.Add(this.txt00);
            this.panelUpdate.Location = new System.Drawing.Point(20, 111);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(471, 293);
            this.panelUpdate.TabIndex = 25;
            // 
            // txtTglAjuan
            // 
            this.txtTglAjuan.DateValue = null;
            this.txtTglAjuan.Location = new System.Drawing.Point(149, 42);
            this.txtTglAjuan.MaxLength = 10;
            this.txtTglAjuan.Name = "txtTglAjuan";
            this.txtTglAjuan.ReadOnly = true;
            this.txtTglAjuan.Size = new System.Drawing.Size(80, 20);
            this.txtTglAjuan.TabIndex = 18;
            this.txtTglAjuan.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "Keterangan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Tanggal ACC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nomor ACC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Jumlah";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Uraian transaksi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Kode transaksi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tanggal pengajuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "CabangID";
            // 
            // cmdUpdateClose
            // 
            this.cmdUpdateClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdUpdateClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpdateClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdateClose.Image")));
            this.cmdUpdateClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpdateClose.Location = new System.Drawing.Point(342, 233);
            this.cmdUpdateClose.Name = "cmdUpdateClose";
            this.cmdUpdateClose.Size = new System.Drawing.Size(100, 40);
            this.cmdUpdateClose.TabIndex = 9;
            this.cmdUpdateClose.Text = "CLOSE";
            this.cmdUpdateClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpdateClose.UseVisualStyleBackColor = true;
            this.cmdUpdateClose.Click += new System.EventHandler(this.cmdUpdateClose_Click);
            // 
            // cmdUpdateSave
            // 
            this.cmdUpdateSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdUpdateSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpdateSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdateSave.Image")));
            this.cmdUpdateSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpdateSave.Location = new System.Drawing.Point(27, 233);
            this.cmdUpdateSave.Name = "cmdUpdateSave";
            this.cmdUpdateSave.Size = new System.Drawing.Size(100, 40);
            this.cmdUpdateSave.TabIndex = 8;
            this.cmdUpdateSave.Text = "SAVE";
            this.cmdUpdateSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpdateSave.UseVisualStyleBackColor = true;
            this.cmdUpdateSave.Click += new System.EventHandler(this.cmdUpdateSave_Click);
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(149, 201);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(284, 20);
            this.txtKeterangan.TabIndex = 7;
            // 
            // txtTglAcc
            // 
            this.txtTglAcc.DateValue = null;
            this.txtTglAcc.Location = new System.Drawing.Point(149, 175);
            this.txtTglAcc.MaxLength = 10;
            this.txtTglAcc.Name = "txtTglAcc";
            this.txtTglAcc.ReadOnly = true;
            this.txtTglAcc.Size = new System.Drawing.Size(80, 20);
            this.txtTglAcc.TabIndex = 6;
            this.txtTglAcc.TabStop = false;
            // 
            // txtNoAcc
            // 
            this.txtNoAcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoAcc.Location = new System.Drawing.Point(149, 149);
            this.txtNoAcc.Name = "txtNoAcc";
            this.txtNoAcc.Size = new System.Drawing.Size(135, 20);
            this.txtNoAcc.TabIndex = 5;
            this.txtNoAcc.Leave += new System.EventHandler(this.txtNoAcc_Leave);
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(149, 123);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.ReadOnly = true;
            this.txtJumlah.Size = new System.Drawing.Size(100, 20);
            this.txtJumlah.TabIndex = 4;
            this.txtJumlah.TabStop = false;
            this.txtJumlah.Text = "0";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(149, 97);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.ReadOnly = true;
            this.txtUraian.Size = new System.Drawing.Size(284, 20);
            this.txtUraian.TabIndex = 3;
            this.txtUraian.TabStop = false;
            // 
            // txtTransaksi
            // 
            this.txtTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransaksi.Location = new System.Drawing.Point(149, 71);
            this.txtTransaksi.Name = "txtTransaksi";
            this.txtTransaksi.ReadOnly = true;
            this.txtTransaksi.Size = new System.Drawing.Size(100, 20);
            this.txtTransaksi.TabIndex = 2;
            this.txtTransaksi.TabStop = false;
            // 
            // txt00
            // 
            this.txt00.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt00.Location = new System.Drawing.Point(149, 19);
            this.txt00.Name = "txt00";
            this.txt00.ReadOnly = true;
            this.txt00.Size = new System.Drawing.Size(72, 20);
            this.txt00.TabIndex = 0;
            this.txt00.TabStop = false;
            // 
            // frmAccBiaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(945, 492);
            this.Controls.Add(this.panelUpdate);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.cmdUPDATE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGUDANG);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.dgTransAccBiaya);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdTABEL);
            this.Controls.Add(this.cmdDOWNLOAD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdUPLOAD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAccBiaya";
            this.Text = "Proses ACC Biaya";
            this.Title = "Proses ACC Biaya";
            this.Load += new System.EventHandler(this.frmAccBiaya_Load);
            this.Controls.SetChildIndex(this.cmdUPLOAD, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdDOWNLOAD, 0);
            this.Controls.SetChildIndex(this.cmdTABEL, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.dgTransAccBiaya, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cboGUDANG, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdUPDATE, 0);
            this.Controls.SetChildIndex(this.panelDownload, 0);
            this.Controls.SetChildIndex(this.panelUpdate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransAccBiaya)).EndInit();
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGUDANG;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CustomGridView dgTransAccBiaya;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Button cmdTABEL;
        private ISA.Controls.CommandButton cmdDOWNLOAD;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdUPLOAD;
        private System.Windows.Forms.Button cmdUPDATE;
        private System.Windows.Forms.Panel panelDownload;
        private ISA.Controls.CommandButton cmdDownloadClose;
        private ISA.Controls.CommandButton cmdDownloadGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFiles;
        private System.Windows.Forms.Panel panelUpdate;
        private ISA.Controls.CommonTextBox txtKeterangan;
        private ISA.Controls.DateTextBox txtTglAcc;
        private ISA.Controls.CommonTextBox txtNoAcc;
        private ISA.Controls.NumericTextBox txtJumlah;
        private ISA.Controls.CommonTextBox txtUraian;
        private ISA.Controls.CommonTextBox txtTransaksi;
        private ISA.Controls.CommonTextBox txt00;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommandButton cmdUpdateClose;
        private ISA.Controls.CommandButton cmdUpdateSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.DateTextBox txtTglAjuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPengajuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKe11;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKe00;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
