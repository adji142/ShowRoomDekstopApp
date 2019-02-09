namespace ISA.Showroom.Finance.Kasir
{
    partial class frmIdenPelunasanBBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdenPelunasanBBN));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.GVDetail = new ISA.Controls.CustomGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BayarBBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SisaBBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new ISA.Controls.CommandButton();
            this.btnSave = new ISA.Controls.CommandButton();
            this.btnSearch = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tanggal";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(93, 69);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 12;
            this.rangeDateBox1.ToDate = null;
            // 
            // GVDetail
            // 
            this.GVDetail.AllowUserToAddRows = false;
            this.GVDetail.AllowUserToDeleteRows = false;
            this.GVDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.RowID,
            this.TglJual,
            this.NoBukti,
            this.NoTrans,
            this.NamaCust,
            this.BBN,
            this.BayarBBN,
            this.SisaBBN,
            this.KodeTrans,
            this.Keterangan});
            this.GVDetail.Location = new System.Drawing.Point(31, 108);
            this.GVDetail.Name = "GVDetail";
            this.GVDetail.ReadOnly = true;
            this.GVDetail.RowHeadersVisible = false;
            this.GVDetail.Size = new System.Drawing.Size(650, 169);
            this.GVDetail.StandardTab = true;
            this.GVDetail.TabIndex = 14;
            this.GVDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVDetail_CellContentClick);
            // 
            // check
            // 
            this.check.HeaderText = "ALL";
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Width = 35;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 66;
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
            this.Keterangan.Width = 95;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(581, 291);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "CANCEL";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(31, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearch.Location = new System.Drawing.Point(356, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmIdenPelunasanBBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 347);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.GVDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.btnSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmIdenPelunasanBBN";
            this.Text = "Daftar Hutang BBN";
            this.Title = "Daftar Hutang BBN";
            this.Load += new System.EventHandler(this.frmIdenPelunasanBBN_Load);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.GVDetail, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton btnSearch;
        private ISA.Controls.CustomGridView GVDetail;
        private ISA.Controls.CommandButton btnSave;
        private ISA.Controls.CommandButton btnClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
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