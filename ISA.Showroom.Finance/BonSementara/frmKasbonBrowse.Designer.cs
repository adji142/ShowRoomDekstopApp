namespace ISA.Showroom.Finance.BonSementara
{
    partial class frmKasbonBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasbonBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaKaryawan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_bukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keperluan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penyelesaian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangeTanggal = new ISA.Controls.RangeDateBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.dataGridViewVju = new ISA.Controls.CustomGridView();
            this.Tgl_vju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VjuRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_vju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UraianVju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalVju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewBkm = new ISA.Controls.CustomGridView();
            this.Tgl_Bkm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BkmRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_Bkm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UraianBkm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVju)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBkm)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NamaKaryawan,
            this.Tanggal,
            this.No_bukti,
            this.Keperluan,
            this.NominalBS,
            this.Vju,
            this.Penyelesaian,
            this.Sisa});
            this.dataGridView1.Location = new System.Drawing.Point(10, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(808, 178);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Enter);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NamaKaryawan
            // 
            this.NamaKaryawan.DataPropertyName = "NamaKaryawan";
            this.NamaKaryawan.HeaderText = "Nama Karyawan";
            this.NamaKaryawan.Name = "NamaKaryawan";
            this.NamaKaryawan.ReadOnly = true;
            this.NamaKaryawan.Width = 200;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle14.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle14;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 90;
            // 
            // No_bukti
            // 
            this.No_bukti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.No_bukti.DataPropertyName = "No_bukti";
            this.No_bukti.HeaderText = "No_bukti";
            this.No_bukti.Name = "No_bukti";
            this.No_bukti.ReadOnly = true;
            this.No_bukti.Width = 5;
            // 
            // Keperluan
            // 
            this.Keperluan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Keperluan.DataPropertyName = "uraian";
            this.Keperluan.HeaderText = "Keperluan";
            this.Keperluan.Name = "Keperluan";
            this.Keperluan.ReadOnly = true;
            // 
            // NominalBS
            // 
            this.NominalBS.DataPropertyName = "Nominal";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.NominalBS.DefaultCellStyle = dataGridViewCellStyle15;
            this.NominalBS.HeaderText = "Nominal";
            this.NominalBS.Name = "NominalBS";
            this.NominalBS.ReadOnly = true;
            // 
            // Vju
            // 
            this.Vju.DataPropertyName = "Vju";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Vju.DefaultCellStyle = dataGridViewCellStyle16;
            this.Vju.HeaderText = "Realisasi";
            this.Vju.Name = "Vju";
            this.Vju.ReadOnly = true;
            // 
            // Penyelesaian
            // 
            this.Penyelesaian.DataPropertyName = "Selesai";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            this.Penyelesaian.DefaultCellStyle = dataGridViewCellStyle17;
            this.Penyelesaian.HeaderText = "Penyelesaian";
            this.Penyelesaian.Name = "Penyelesaian";
            this.Penyelesaian.ReadOnly = true;
            // 
            // Sisa
            // 
            this.Sisa.DataPropertyName = "Sisa";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = null;
            this.Sisa.DefaultCellStyle = dataGridViewCellStyle18;
            this.Sisa.HeaderText = "Sisa";
            this.Sisa.Name = "Sisa";
            this.Sisa.ReadOnly = true;
            // 
            // rangeTanggal
            // 
            this.rangeTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTanggal.FromDate = null;
            this.rangeTanggal.Location = new System.Drawing.Point(10, 10);
            this.rangeTanggal.Name = "rangeTanggal";
            this.rangeTanggal.Size = new System.Drawing.Size(257, 22);
            this.rangeTanggal.TabIndex = 9;
            this.rangeTanggal.ToDate = null;
            this.rangeTanggal.Leave += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(9, 222);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 210);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewVju);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(801, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Realisasi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(703, 438);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(226, 438);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 7;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(120, 438);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 6;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(14, 438);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 5;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // dataGridViewVju
            // 
            this.dataGridViewVju.AllowUserToAddRows = false;
            this.dataGridViewVju.AllowUserToDeleteRows = false;
            this.dataGridViewVju.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVju.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVju.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewVju.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVju.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tgl_vju,
            this.VjuRowID,
            this.No_vju,
            this.UraianVju,
            this.NominalVju});
            this.dataGridViewVju.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewVju.MultiSelect = false;
            this.dataGridViewVju.Name = "dataGridViewVju";
            this.dataGridViewVju.ReadOnly = true;
            this.dataGridViewVju.RowHeadersVisible = false;
            this.dataGridViewVju.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewVju.Size = new System.Drawing.Size(795, 177);
            this.dataGridViewVju.StandardTab = true;
            this.dataGridViewVju.TabIndex = 0;
            this.dataGridViewVju.Enter += new System.EventHandler(this.dataGridViewVju_Enter);
            this.dataGridViewVju.Click += new System.EventHandler(this.dataGridViewVju_Enter);
            // 
            // Tgl_vju
            // 
            this.Tgl_vju.DataPropertyName = "Tanggal";
            this.Tgl_vju.HeaderText = "Tanggal";
            this.Tgl_vju.Name = "Tgl_vju";
            this.Tgl_vju.ReadOnly = true;
            // 
            // VjuRowID
            // 
            this.VjuRowID.DataPropertyName = "RowID";
            this.VjuRowID.HeaderText = "RowID";
            this.VjuRowID.Name = "VjuRowID";
            this.VjuRowID.ReadOnly = true;
            this.VjuRowID.Visible = false;
            // 
            // No_vju
            // 
            this.No_vju.DataPropertyName = "No_bukti";
            this.No_vju.HeaderText = "No.Bukti";
            this.No_vju.Name = "No_vju";
            this.No_vju.ReadOnly = true;
            this.No_vju.Width = 120;
            // 
            // UraianVju
            // 
            this.UraianVju.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UraianVju.DataPropertyName = "Uraian";
            this.UraianVju.HeaderText = "Uraian";
            this.UraianVju.Name = "UraianVju";
            this.UraianVju.ReadOnly = true;
            // 
            // NominalVju
            // 
            this.NominalVju.DataPropertyName = "Kredit";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N2";
            this.NominalVju.DefaultCellStyle = dataGridViewCellStyle21;
            this.NominalVju.HeaderText = "Nominal";
            this.NominalVju.Name = "NominalVju";
            this.NominalVju.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewBkm);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(801, 183);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Penyelesaian";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBkm
            // 
            this.dataGridViewBkm.AllowUserToAddRows = false;
            this.dataGridViewBkm.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBkm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewBkm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBkm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tgl_Bkm,
            this.BkmRowID,
            this.No_Bkm,
            this.UraianBkm,
            this.Debet,
            this.Kredit});
            this.dataGridViewBkm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBkm.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBkm.MultiSelect = false;
            this.dataGridViewBkm.Name = "dataGridViewBkm";
            this.dataGridViewBkm.ReadOnly = true;
            this.dataGridViewBkm.RowHeadersVisible = false;
            this.dataGridViewBkm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewBkm.Size = new System.Drawing.Size(801, 183);
            this.dataGridViewBkm.StandardTab = true;
            this.dataGridViewBkm.TabIndex = 0;
            this.dataGridViewBkm.Enter += new System.EventHandler(this.dataGridViewVju_Enter);
            this.dataGridViewBkm.Click += new System.EventHandler(this.dataGridViewVju_Enter);
            // 
            // Tgl_Bkm
            // 
            this.Tgl_Bkm.DataPropertyName = "Tanggal";
            this.Tgl_Bkm.HeaderText = "Tanggal";
            this.Tgl_Bkm.Name = "Tgl_Bkm";
            this.Tgl_Bkm.ReadOnly = true;
            // 
            // BkmRowID
            // 
            this.BkmRowID.DataPropertyName = "RowID";
            this.BkmRowID.HeaderText = "RowID";
            this.BkmRowID.Name = "BkmRowID";
            this.BkmRowID.ReadOnly = true;
            this.BkmRowID.Visible = false;
            // 
            // No_Bkm
            // 
            this.No_Bkm.DataPropertyName = "No_bukti";
            this.No_Bkm.HeaderText = "No.Bukti";
            this.No_Bkm.Name = "No_Bkm";
            this.No_Bkm.ReadOnly = true;
            this.No_Bkm.Width = 120;
            // 
            // UraianBkm
            // 
            this.UraianBkm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UraianBkm.DataPropertyName = "Uraian";
            this.UraianBkm.HeaderText = "Uraian";
            this.UraianBkm.Name = "UraianBkm";
            this.UraianBkm.ReadOnly = true;
            // 
            // Debet
            // 
            this.Debet.DataPropertyName = "Debet";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            this.Debet.DefaultCellStyle = dataGridViewCellStyle23;
            this.Debet.HeaderText = "Debet";
            this.Debet.Name = "Debet";
            this.Debet.ReadOnly = true;
            // 
            // Kredit
            // 
            this.Kredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle24.Format = "N2";
            this.Kredit.DefaultCellStyle = dataGridViewCellStyle24;
            this.Kredit.HeaderText = "Kredit";
            this.Kredit.Name = "Kredit";
            this.Kredit.ReadOnly = true;
            // 
            // frmKasbonBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(830, 490);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rangeTanggal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdADD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKasbonBrowse";
            this.Text = "Bon Sementara";
            this.Title = "Bon Sementara";
            this.Load += new System.EventHandler(this.frmKasbonBrowse_Load);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.rangeTanggal, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVju)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBkm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.RangeDateBox rangeTanggal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private ISA.Controls.CustomGridView dataGridViewVju;
        private ISA.Controls.CustomGridView dataGridViewBkm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tgl_vju;
        private System.Windows.Forms.DataGridViewTextBoxColumn VjuRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_vju;
        private System.Windows.Forms.DataGridViewTextBoxColumn UraianVju;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalVju;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaKaryawan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_bukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keperluan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vju;
        private System.Windows.Forms.DataGridViewTextBoxColumn Penyelesaian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tgl_Bkm;
        private System.Windows.Forms.DataGridViewTextBoxColumn BkmRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Bkm;
        private System.Windows.Forms.DataGridViewTextBoxColumn UraianBkm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kredit;
    }
}
