namespace ISA.Showroom.Finance.Kasir
{
    partial class frmIdenBBNBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdenBBNBrowse));
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.check_Lunas = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAjuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAjuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BayarBBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SisaBBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVDetail = new ISA.Controls.CustomGridView();
            this.RowID_PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal_PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti_PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalRp_PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian_PU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdLunas = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(84, 59);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(333, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // check_Lunas
            // 
            this.check_Lunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_Lunas.AutoSize = true;
            this.check_Lunas.Location = new System.Drawing.Point(638, 62);
            this.check_Lunas.Name = "check_Lunas";
            this.check_Lunas.Size = new System.Drawing.Size(60, 18);
            this.check_Lunas.TabIndex = 8;
            this.check_Lunas.Text = "Lunas";
            this.check_Lunas.UseVisualStyleBackColor = true;
            this.check_Lunas.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(21, 87);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GVHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GVDetail);
            this.splitContainer1.Size = new System.Drawing.Size(680, 362);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 9;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.TglAjuan,
            this.NoAjuan,
            this.TglJual,
            this.NoBukti,
            this.NoTrans,
            this.NamaCust,
            this.BBN,
            this.BayarBBN,
            this.SisaBBN,
            this.KodeTrans,
            this.Keterangan});
            this.GVHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeader.Location = new System.Drawing.Point(0, 0);
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.Size = new System.Drawing.Size(680, 260);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 0;
            this.GVHeader.SelectionRowChanged += new System.EventHandler(this.GVHeader_SelectionRowChanged);
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
            // TglAjuan
            // 
            this.TglAjuan.DataPropertyName = "TglAjuan";
            this.TglAjuan.HeaderText = "TglAjuan";
            this.TglAjuan.Name = "TglAjuan";
            this.TglAjuan.ReadOnly = true;
            this.TglAjuan.Width = 80;
            // 
            // NoAjuan
            // 
            this.NoAjuan.DataPropertyName = "NoAjuan";
            this.NoAjuan.HeaderText = "NoAjuan";
            this.NoAjuan.Name = "NoAjuan";
            this.NoAjuan.ReadOnly = true;
            this.NoAjuan.Width = 77;
            // 
            // TglJual
            // 
            this.TglJual.DataPropertyName = "TglJual";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglJual.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglJual.HeaderText = "TglJual";
            this.TglJual.Name = "TglJual";
            this.TglJual.ReadOnly = true;
            this.TglJual.Width = 71;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 74;
            // 
            // NoTrans
            // 
            this.NoTrans.DataPropertyName = "NoTrans";
            this.NoTrans.HeaderText = "NoTrans";
            this.NoTrans.Name = "NoTrans";
            this.NoTrans.ReadOnly = true;
            this.NoTrans.Width = 77;
            // 
            // NamaCust
            // 
            this.NamaCust.DataPropertyName = "NamaCust";
            this.NamaCust.HeaderText = "Customer";
            this.NamaCust.Name = "NamaCust";
            this.NamaCust.ReadOnly = true;
            this.NamaCust.Width = 88;
            // 
            // BBN
            // 
            this.BBN.DataPropertyName = "BBN";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.BBN.DefaultCellStyle = dataGridViewCellStyle2;
            this.BBN.HeaderText = "BBN";
            this.BBN.Name = "BBN";
            this.BBN.ReadOnly = true;
            this.BBN.Width = 53;
            // 
            // BayarBBN
            // 
            this.BayarBBN.DataPropertyName = "BayarBBN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.BayarBBN.DefaultCellStyle = dataGridViewCellStyle3;
            this.BayarBBN.HeaderText = "BayarBBN";
            this.BayarBBN.Name = "BayarBBN";
            this.BayarBBN.ReadOnly = true;
            this.BayarBBN.Width = 83;
            // 
            // SisaBBN
            // 
            this.SisaBBN.DataPropertyName = "SisaBBN";
            dataGridViewCellStyle4.Format = "N2";
            this.SisaBBN.DefaultCellStyle = dataGridViewCellStyle4;
            this.SisaBBN.HeaderText = "SisaBBN";
            this.SisaBBN.Name = "SisaBBN";
            this.SisaBBN.ReadOnly = true;
            this.SisaBBN.Width = 76;
            // 
            // KodeTrans
            // 
            this.KodeTrans.DataPropertyName = "KodeTrans";
            this.KodeTrans.HeaderText = "KodeTrans";
            this.KodeTrans.Name = "KodeTrans";
            this.KodeTrans.ReadOnly = true;
            this.KodeTrans.Width = 91;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Visible = false;
            this.Keterangan.Width = 95;
            // 
            // GVDetail
            // 
            this.GVDetail.AllowUserToAddRows = false;
            this.GVDetail.AllowUserToDeleteRows = false;
            this.GVDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID_PU,
            this.Tanggal_PU,
            this.NoBukti_PU,
            this.NominalRp_PU,
            this.Uraian_PU});
            this.GVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVDetail.Location = new System.Drawing.Point(0, 0);
            this.GVDetail.Name = "GVDetail";
            this.GVDetail.ReadOnly = true;
            this.GVDetail.RowHeadersVisible = false;
            this.GVDetail.Size = new System.Drawing.Size(680, 98);
            this.GVDetail.StandardTab = true;
            this.GVDetail.TabIndex = 0;
            // 
            // RowID_PU
            // 
            this.RowID_PU.DataPropertyName = "RowID";
            this.RowID_PU.HeaderText = "RowID";
            this.RowID_PU.Name = "RowID_PU";
            this.RowID_PU.ReadOnly = true;
            this.RowID_PU.Visible = false;
            this.RowID_PU.Width = 46;
            // 
            // Tanggal_PU
            // 
            this.Tanggal_PU.DataPropertyName = "Tanggal";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.Tanggal_PU.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tanggal_PU.HeaderText = "Tanggal";
            this.Tanggal_PU.Name = "Tanggal_PU";
            this.Tanggal_PU.ReadOnly = true;
            this.Tanggal_PU.Width = 74;
            // 
            // NoBukti_PU
            // 
            this.NoBukti_PU.DataPropertyName = "NoBukti";
            this.NoBukti_PU.HeaderText = "NoBukti";
            this.NoBukti_PU.Name = "NoBukti_PU";
            this.NoBukti_PU.ReadOnly = true;
            this.NoBukti_PU.Width = 74;
            // 
            // NominalRp_PU
            // 
            this.NominalRp_PU.DataPropertyName = "NominalRp";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.NominalRp_PU.DefaultCellStyle = dataGridViewCellStyle6;
            this.NominalRp_PU.HeaderText = "NominalRp";
            this.NominalRp_PU.Name = "NominalRp_PU";
            this.NominalRp_PU.ReadOnly = true;
            this.NominalRp_PU.Width = 90;
            // 
            // Uraian_PU
            // 
            this.Uraian_PU.DataPropertyName = "Uraian";
            this.Uraian_PU.HeaderText = "Uraian";
            this.Uraian_PU.Name = "Uraian_PU";
            this.Uraian_PU.ReadOnly = true;
            this.Uraian_PU.Width = 66;
            // 
            // cmdLunas
            // 
            this.cmdLunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdLunas.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdLunas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdLunas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLunas.Location = new System.Drawing.Point(23, 459);
            this.cmdLunas.Name = "cmdLunas";
            this.cmdLunas.Size = new System.Drawing.Size(100, 40);
            this.cmdLunas.TabIndex = 10;
            this.cmdLunas.Text = "PELUNASAN";
            this.cmdLunas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLunas.UseVisualStyleBackColor = true;
            this.cmdLunas.Click += new System.EventHandler(this.cmdLunas_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(602, 459);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 11;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // frmIdenBBNBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 508);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdLunas);
            this.Controls.Add(this.check_Lunas);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmIdenBBNBrowse";
            this.Text = "Pelunasan Hutang BBN";
            this.Title = "Pelunasan Hutang BBN";
            this.Load += new System.EventHandler(this.frmIdenBBNBrowse_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.check_Lunas, 0);
            this.Controls.SetChildIndex(this.cmdLunas, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox check_Lunas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ISA.Controls.CommandButton cmdLunas;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CustomGridView GVHeader;
        private ISA.Controls.CustomGridView GVDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID_PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal_PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti_PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalRp_PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian_PU;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAjuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAjuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn BBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BayarBBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SisaBBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
    }
}