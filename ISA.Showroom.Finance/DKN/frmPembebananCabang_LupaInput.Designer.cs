namespace ISA.Showroom.Finance.DKN
{
    partial class frmPembebananCabang_LupaInput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembebananCabang_LupaInput));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgBebanCabang = new ISA.Controls.CustomGridView();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.NamaBeban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiapTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBebanCabang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBebanCabang
            // 
            this.dgBebanCabang.AllowUserToAddRows = false;
            this.dgBebanCabang.AllowUserToDeleteRows = false;
            this.dgBebanCabang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBebanCabang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBebanCabang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaBeban,
            this.CabangID,
            this.NamaPT,
            this.JenisTransaksi,
            this.TiapTanggal,
            this.Tanggal});
            this.dgBebanCabang.Location = new System.Drawing.Point(26, 22);
            this.dgBebanCabang.MultiSelect = false;
            this.dgBebanCabang.Name = "dgBebanCabang";
            this.dgBebanCabang.ReadOnly = true;
            this.dgBebanCabang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBebanCabang.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgBebanCabang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgBebanCabang.Size = new System.Drawing.Size(937, 252);
            this.dgBebanCabang.StandardTab = true;
            this.dgBebanCabang.TabIndex = 5;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(863, 289);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 6;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // NamaBeban
            // 
            this.NamaBeban.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaBeban.DataPropertyName = "NamaBeban";
            this.NamaBeban.HeaderText = "Nama Pembebanan";
            this.NamaBeban.Name = "NamaBeban";
            this.NamaBeban.ReadOnly = true;
            this.NamaBeban.Width = 115;
            // 
            // CabangID
            // 
            this.CabangID.DataPropertyName = "CabangID";
            this.CabangID.HeaderText = "CabangID";
            this.CabangID.Name = "CabangID";
            this.CabangID.ReadOnly = true;
            this.CabangID.Width = 60;
            // 
            // NamaPT
            // 
            this.NamaPT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaPT.DataPropertyName = "NamaPT";
            this.NamaPT.HeaderText = "NamaPT";
            this.NamaPT.Name = "NamaPT";
            this.NamaPT.ReadOnly = true;
            // 
            // JenisTransaksi
            // 
            this.JenisTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JenisTransaksi.DataPropertyName = "JenisTransaksi";
            this.JenisTransaksi.HeaderText = "Jenis Transaksi";
            this.JenisTransaksi.Name = "JenisTransaksi";
            this.JenisTransaksi.ReadOnly = true;
            this.JenisTransaksi.Width = 97;
            // 
            // TiapTanggal
            // 
            this.TiapTanggal.DataPropertyName = "TiapTanggal";
            this.TiapTanggal.HeaderText = "Tiap Tanggal";
            this.TiapTanggal.Name = "TiapTanggal";
            this.TiapTanggal.ReadOnly = true;
            this.TiapTanggal.Width = 55;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tgl Akan Diproses";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 90;
            // 
            // frmPembebananCabang_LupaInput
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(992, 341);
            this.ControlBox = false;
            this.Controls.Add(this.dgBebanCabang);
            this.Controls.Add(this.cmdCLOSE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmPembebananCabang_LupaInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pembebanan Cabang Belum Di-input";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgBebanCabang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        public ISA.Controls.CustomGridView dgBebanCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBeban;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiapTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
    }
}
