namespace ISA.Showroom.Finance.GL
{
    partial class frmPostingJournalPotongan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostingJournalPotongan));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPLS = new System.Windows.Forms.TabPage();
            this.dgPLS = new ISA.Controls.CustomGridView();
            this.RowIDANGPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDPJLPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDPJHISTPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransPJLPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBuktiPJLPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransANGPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBungaPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasilPLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdRefresh = new ISA.Controls.CommandButton();
            this.cmdProses = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rgtgTransaksi = new ISA.Controls.RangeDateBox();
            this.tabControl1.SuspendLayout();
            this.tabPLS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPLS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPLS);
            this.tabControl1.Location = new System.Drawing.Point(26, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 372);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPLS
            // 
            this.tabPLS.Controls.Add(this.dgPLS);
            this.tabPLS.Location = new System.Drawing.Point(4, 23);
            this.tabPLS.Name = "tabPLS";
            this.tabPLS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPLS.Size = new System.Drawing.Size(734, 345);
            this.tabPLS.TabIndex = 1;
            this.tabPLS.Text = "Pelunasan";
            this.tabPLS.UseVisualStyleBackColor = true;
            // 
            // dgPLS
            // 
            this.dgPLS.AllowUserToAddRows = false;
            this.dgPLS.AllowUserToDeleteRows = false;
            this.dgPLS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDANGPLS,
            this.RowIDPJLPLS,
            this.RowIDPJHISTPLS,
            this.NoTransPJLPLS,
            this.NoBuktiPJLPLS,
            this.NoTransANGPLS,
            this.TglPLS,
            this.TotalBungaPLS,
            this.HasilPLS});
            this.dgPLS.Location = new System.Drawing.Point(3, 3);
            this.dgPLS.Name = "dgPLS";
            this.dgPLS.ReadOnly = true;
            this.dgPLS.RowHeadersVisible = false;
            this.dgPLS.Size = new System.Drawing.Size(728, 339);
            this.dgPLS.StandardTab = true;
            this.dgPLS.TabIndex = 0;
            // 
            // RowIDANGPLS
            // 
            this.RowIDANGPLS.DataPropertyName = "PenerimaanANGRowID";
            this.RowIDANGPLS.HeaderText = "RowIDANGPLS";
            this.RowIDANGPLS.Name = "RowIDANGPLS";
            this.RowIDANGPLS.ReadOnly = true;
            this.RowIDANGPLS.Visible = false;
            // 
            // RowIDPJLPLS
            // 
            this.RowIDPJLPLS.DataPropertyName = "PenjualanRowID";
            this.RowIDPJLPLS.HeaderText = "RowIDPJLPLS";
            this.RowIDPJLPLS.Name = "RowIDPJLPLS";
            this.RowIDPJLPLS.ReadOnly = true;
            this.RowIDPJLPLS.Visible = false;
            // 
            // RowIDPJHISTPLS
            // 
            this.RowIDPJHISTPLS.DataPropertyName = "PenjHistRowID";
            this.RowIDPJHISTPLS.HeaderText = "RowIDPJHISTPJL";
            this.RowIDPJHISTPLS.Name = "RowIDPJHISTPLS";
            this.RowIDPJHISTPLS.ReadOnly = true;
            this.RowIDPJHISTPLS.Visible = false;
            // 
            // NoTransPJLPLS
            // 
            this.NoTransPJLPLS.DataPropertyName = "NoTransPJL";
            this.NoTransPJLPLS.HeaderText = "NoTrans PJL";
            this.NoTransPJLPLS.Name = "NoTransPJLPLS";
            this.NoTransPJLPLS.ReadOnly = true;
            this.NoTransPJLPLS.Width = 120;
            // 
            // NoBuktiPJLPLS
            // 
            this.NoBuktiPJLPLS.DataPropertyName = "NoBuktiPJL";
            this.NoBuktiPJLPLS.HeaderText = "NoBuktiPJL";
            this.NoBuktiPJLPLS.Name = "NoBuktiPJLPLS";
            this.NoBuktiPJLPLS.ReadOnly = true;
            // 
            // NoTransANGPLS
            // 
            this.NoTransANGPLS.DataPropertyName = "NoTransANG";
            this.NoTransANGPLS.HeaderText = "NoTrans PLS";
            this.NoTransANGPLS.Name = "NoTransANGPLS";
            this.NoTransANGPLS.ReadOnly = true;
            this.NoTransANGPLS.Width = 120;
            // 
            // TglPLS
            // 
            this.TglPLS.DataPropertyName = "TglPLS";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TglPLS.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglPLS.HeaderText = "TglPLS";
            this.TglPLS.Name = "TglPLS";
            this.TglPLS.ReadOnly = true;
            this.TglPLS.Width = 125;
            // 
            // TotalBungaPLS
            // 
            this.TotalBungaPLS.DataPropertyName = "TotalBayarBunga";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.TotalBungaPLS.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalBungaPLS.HeaderText = "Bunga Terbayar";
            this.TotalBungaPLS.Name = "TotalBungaPLS";
            this.TotalBungaPLS.ReadOnly = true;
            this.TotalBungaPLS.Width = 150;
            // 
            // HasilPLS
            // 
            this.HasilPLS.DataPropertyName = "Hasil";
            this.HasilPLS.HeaderText = "Hasil Proses";
            this.HasilPLS.Name = "HasilPLS";
            this.HasilPLS.ReadOnly = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(661, 473);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 17;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdRefresh.CommandType = ISA.Controls.CommandButton.enCommandType.Refresh;
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(344, 473);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(100, 40);
            this.cmdRefresh.TabIndex = 18;
            this.cmdRefresh.Text = "REFRESH";
            this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdProses
            // 
            this.cmdProses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdProses.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdProses.Image = ((System.Drawing.Image)(resources.GetObject("cmdProses.Image")));
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(26, 473);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 16;
            this.cmdProses.Text = "YES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tanggal";
            // 
            // rgtgTransaksi
            // 
            this.rgtgTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rgtgTransaksi.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgtgTransaksi.FromDate = null;
            this.rgtgTransaksi.Location = new System.Drawing.Point(287, 42);
            this.rgtgTransaksi.Name = "rgtgTransaksi";
            this.rgtgTransaksi.Size = new System.Drawing.Size(276, 22);
            this.rgtgTransaksi.TabIndex = 19;
            this.rgtgTransaksi.ToDate = null;
            // 
            // frmPostingJournalPotongan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgtgTransaksi);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPostingJournalPotongan";
            this.Text = "Posting Journal Potongan ";
            this.Title = "Posting Journal Potongan ";
            this.Load += new System.EventHandler(this.frmPostingJournalPotongan_Load);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.rgtgTransaksi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPLS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPLS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPLS;
        private ISA.Controls.CustomGridView dgPLS;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdRefresh;
        private ISA.Controls.CommandButton cmdProses;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rgtgTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDANGPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDPJLPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDPJHISTPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransPJLPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBuktiPJLPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransANGPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBungaPLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasilPLS;
    }
}