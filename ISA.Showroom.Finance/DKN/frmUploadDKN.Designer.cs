namespace ISA.Showroom.Finance.HI
{
    partial class frmUploadDKN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadDKN));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFolder = new ISA.Controls.CommonTextBox();
            this.cmdLocate = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.D_RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadKe00 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TglDKN00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDKN00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H_DK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H_Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDKN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H_GroupRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H_RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(120, 44);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 4;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(642, 45);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 5;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.D_RowID,
            this.NoPerkiraan,
            this.D_Uraian,
            this.D_Nominal});
            this.dataGridView1.Location = new System.Drawing.Point(3, 159);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 150);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 6;
            // 
            // pbUpload
            // 
            this.pbUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUpload.Location = new System.Drawing.Point(12, 390);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(999, 23);
            this.pbUpload.TabIndex = 7;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(911, 435);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOK.BackgroundImage = global::ISA.Showroom.Finance.Properties.Resources.Upload32;
            this.cmdOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdOK.Location = new System.Drawing.Point(12, 437);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(124, 40);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "UPLOAD";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFolder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFolder.Location = new System.Drawing.Point(295, 447);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(502, 20);
            this.txtFolder.TabIndex = 13;
            // 
            // cmdLocate
            // 
            this.cmdLocate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdLocate.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdLocate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdLocate.Image = ((System.Drawing.Image)(resources.GetObject("cmdLocate.Image")));
            this.cmdLocate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdLocate.Location = new System.Drawing.Point(803, 447);
            this.cmdLocate.Name = "cmdLocate";
            this.cmdLocate.Size = new System.Drawing.Size(80, 23);
            this.cmdLocate.TabIndex = 14;
            this.cmdLocate.Text = "Search";
            this.cmdLocate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLocate.UseVisualStyleBackColor = true;
            this.cmdLocate.Click += new System.EventHandler(this.cmdLocate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Lokasi Hasil Upload : ";
            // 
            // cboCabang
            // 
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(477, 42);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(121, 22);
            this.cboCabang.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cabang";
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.AllowUserToResizeRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.H_RowID,
            this.H_GroupRowID,
            this.NoDKN,
            this.H_Tanggal,
            this.Dari,
            this.Cabang,
            this.Src,
            this.H_DK,
            this.NoDKN00,
            this.TglDKN00,
            this.UploadKe00});
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(1013, 150);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 18;
            this.customGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellEnter);
            // 
            // D_RowID
            // 
            this.D_RowID.DataPropertyName = "RowID";
            this.D_RowID.HeaderText = "RowID";
            this.D_RowID.Name = "D_RowID";
            this.D_RowID.ReadOnly = true;
            this.D_RowID.Visible = false;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "NoPerkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            // 
            // D_Uraian
            // 
            this.D_Uraian.DataPropertyName = "Uraian";
            this.D_Uraian.HeaderText = "Uraian";
            this.D_Uraian.Name = "D_Uraian";
            this.D_Uraian.ReadOnly = true;
            this.D_Uraian.Width = 350;
            // 
            // D_Nominal
            // 
            this.D_Nominal.DataPropertyName = "Jumlah";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.D_Nominal.DefaultCellStyle = dataGridViewCellStyle13;
            this.D_Nominal.HeaderText = "Nominal";
            this.D_Nominal.Name = "D_Nominal";
            this.D_Nominal.ReadOnly = true;
            this.D_Nominal.Width = 120;
            // 
            // UploadKe00
            // 
            this.UploadKe00.DataPropertyName = "UploadKe00";
            this.UploadKe00.HeaderText = "UploadKe00";
            this.UploadKe00.Name = "UploadKe00";
            this.UploadKe00.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UploadKe00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TglDKN00
            // 
            this.TglDKN00.DataPropertyName = "TglDKN00";
            dataGridViewCellStyle14.Format = "dd/MM/yyyy";
            this.TglDKN00.DefaultCellStyle = dataGridViewCellStyle14;
            this.TglDKN00.HeaderText = "Tgl.DKN 00";
            this.TglDKN00.Name = "TglDKN00";
            this.TglDKN00.ReadOnly = true;
            // 
            // NoDKN00
            // 
            this.NoDKN00.DataPropertyName = "NoDKN00";
            this.NoDKN00.HeaderText = "No.DKN00";
            this.NoDKN00.Name = "NoDKN00";
            this.NoDKN00.ReadOnly = true;
            // 
            // H_DK
            // 
            this.H_DK.DataPropertyName = "DK";
            this.H_DK.HeaderText = "DK";
            this.H_DK.Name = "H_DK";
            this.H_DK.ReadOnly = true;
            // 
            // Src
            // 
            this.Src.DataPropertyName = "Src";
            this.Src.HeaderText = "Src";
            this.Src.Name = "Src";
            this.Src.ReadOnly = true;
            // 
            // Cabang
            // 
            this.Cabang.DataPropertyName = "Cabang";
            this.Cabang.HeaderText = "Cabang";
            this.Cabang.Name = "Cabang";
            this.Cabang.ReadOnly = true;
            // 
            // Dari
            // 
            this.Dari.DataPropertyName = "Dari";
            this.Dari.HeaderText = "Dari";
            this.Dari.Name = "Dari";
            this.Dari.ReadOnly = true;
            // 
            // H_Tanggal
            // 
            this.H_Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle15.Format = "dd/MM/yyyy";
            this.H_Tanggal.DefaultCellStyle = dataGridViewCellStyle15;
            this.H_Tanggal.HeaderText = "Tanggal";
            this.H_Tanggal.Name = "H_Tanggal";
            this.H_Tanggal.ReadOnly = true;
            // 
            // NoDKN
            // 
            this.NoDKN.DataPropertyName = "NoDKN";
            this.NoDKN.HeaderText = "No.DKN 11";
            this.NoDKN.Name = "NoDKN";
            this.NoDKN.ReadOnly = true;
            // 
            // H_GroupRowID
            // 
            this.H_GroupRowID.DataPropertyName = "GroupRowID";
            this.H_GroupRowID.HeaderText = "GroupRowID";
            this.H_GroupRowID.Name = "H_GroupRowID";
            this.H_GroupRowID.Visible = false;
            // 
            // H_RowID
            // 
            this.H_RowID.DataPropertyName = "RowID";
            this.H_RowID.HeaderText = "RowID";
            this.H_RowID.Name = "H_RowID";
            this.H_RowID.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1019, 312);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // frmUploadDKN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1025, 509);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCabang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdLocate);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.pbUpload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUploadDKN";
            this.Text = "Upload DKN";
            this.Title = "Upload DKN";
            this.Load += new System.EventHandler(this.frmUploadDKN_Load);
            this.Controls.SetChildIndex(this.pbUpload, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.txtFolder, 0);
            this.Controls.SetChildIndex(this.cmdLocate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboCabang, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar pbUpload;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private ISA.Controls.CommonTextBox txtFolder;
        private ISA.Controls.CommandButton cmdLocate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn H_RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn H_GroupRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDKN;
        private System.Windows.Forms.DataGridViewTextBoxColumn H_Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src;
        private System.Windows.Forms.DataGridViewTextBoxColumn H_DK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDKN00;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglDKN00;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UploadKe00;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
