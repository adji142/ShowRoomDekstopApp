namespace ISA.Showroom.Finance.GL
{
    partial class frmPostingJournalAccrual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostingJournalAccrual));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Accrual = new System.Windows.Forms.TabPage();
            this.dgJurnalAccrual = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdRefresh = new ISA.Controls.CommandButton();
            this.cmdProses = new ISA.Controls.CommandButton();
            this.PenjRowIDACR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenjHistRowIDACR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransACR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBuktiACR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PiutangBungaACR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACRHasilProses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.Accrual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJurnalAccrual)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Periode Accrual";
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.monthYearBox1.Location = new System.Drawing.Point(319, 54);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(267, 21);
            this.monthYearBox1.TabIndex = 22;
            this.monthYearBox1.Year = 2014;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Accrual);
            this.tabControl1.Location = new System.Drawing.Point(36, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 330);
            this.tabControl1.TabIndex = 18;
            // 
            // Accrual
            // 
            this.Accrual.BackColor = System.Drawing.SystemColors.Menu;
            this.Accrual.Controls.Add(this.dgJurnalAccrual);
            this.Accrual.Location = new System.Drawing.Point(4, 23);
            this.Accrual.Name = "Accrual";
            this.Accrual.Size = new System.Drawing.Size(599, 303);
            this.Accrual.TabIndex = 2;
            this.Accrual.Text = "Accrual";
            this.Accrual.UseVisualStyleBackColor = true;
            // 
            // dgJurnalAccrual
            // 
            this.dgJurnalAccrual.AllowUserToAddRows = false;
            this.dgJurnalAccrual.AllowUserToDeleteRows = false;
            this.dgJurnalAccrual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgJurnalAccrual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgJurnalAccrual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJurnalAccrual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PenjRowIDACR,
            this.PenjHistRowIDACR,
            this.NoTransACR,
            this.NoBuktiACR,
            this.PiutangBungaACR,
            this.ACRHasilProses});
            this.dgJurnalAccrual.Location = new System.Drawing.Point(3, 2);
            this.dgJurnalAccrual.Name = "dgJurnalAccrual";
            this.dgJurnalAccrual.ReadOnly = true;
            this.dgJurnalAccrual.RowHeadersVisible = false;
            this.dgJurnalAccrual.Size = new System.Drawing.Size(593, 298);
            this.dgJurnalAccrual.StandardTab = true;
            this.dgJurnalAccrual.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(561, 437);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 20;
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
            this.cmdRefresh.Location = new System.Drawing.Point(285, 437);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(100, 40);
            this.cmdRefresh.TabIndex = 21;
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
            this.cmdProses.Location = new System.Drawing.Point(28, 437);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(100, 40);
            this.cmdProses.TabIndex = 19;
            this.cmdProses.Text = "YES";
            this.cmdProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // PenjRowIDACR
            // 
            this.PenjRowIDACR.DataPropertyName = "PenjRowID";
            this.PenjRowIDACR.HeaderText = "PenjRowID";
            this.PenjRowIDACR.Name = "PenjRowIDACR";
            this.PenjRowIDACR.ReadOnly = true;
            this.PenjRowIDACR.Visible = false;
            // 
            // PenjHistRowIDACR
            // 
            this.PenjHistRowIDACR.DataPropertyName = "PenjHistRowID";
            this.PenjHistRowIDACR.HeaderText = "PenjHistRowID";
            this.PenjHistRowIDACR.Name = "PenjHistRowIDACR";
            this.PenjHistRowIDACR.ReadOnly = true;
            this.PenjHistRowIDACR.Visible = false;
            // 
            // NoTransACR
            // 
            this.NoTransACR.DataPropertyName = "NoTrans";
            this.NoTransACR.HeaderText = "No. Trans";
            this.NoTransACR.Name = "NoTransACR";
            this.NoTransACR.ReadOnly = true;
            this.NoTransACR.Width = 125;
            // 
            // NoBuktiACR
            // 
            this.NoBuktiACR.DataPropertyName = "NoBukti";
            this.NoBuktiACR.HeaderText = "No. Bukti";
            this.NoBuktiACR.Name = "NoBuktiACR";
            this.NoBuktiACR.ReadOnly = true;
            this.NoBuktiACR.Width = 125;
            // 
            // PiutangBungaACR
            // 
            this.PiutangBungaACR.DataPropertyName = "Interest";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.PiutangBungaACR.DefaultCellStyle = dataGridViewCellStyle2;
            this.PiutangBungaACR.HeaderText = "Piutang Bunga";
            this.PiutangBungaACR.Name = "PiutangBungaACR";
            this.PiutangBungaACR.ReadOnly = true;
            this.PiutangBungaACR.Width = 150;
            // 
            // ACRHasilProses
            // 
            this.ACRHasilProses.DataPropertyName = "Hasil";
            this.ACRHasilProses.HeaderText = "HasilProses";
            this.ACRHasilProses.Name = "ACRHasilProses";
            this.ACRHasilProses.ReadOnly = true;
            this.ACRHasilProses.Width = 125;
            // 
            // frmPostingJournalAccrual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 482);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthYearBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdProses);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPostingJournalAccrual";
            this.Text = "Posting Journal Accrual";
            this.Title = "Posting Journal Accrual";
            this.Load += new System.EventHandler(this.frmPostingJournalPenjualanBrowse_Load);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.tabControl1.ResumeLayout(false);
            this.Accrual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgJurnalAccrual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Accrual;
        private ISA.Controls.CustomGridView dgJurnalAccrual;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdRefresh;
        private ISA.Controls.CommandButton cmdProses;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjRowIDACR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjHistRowIDACR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransACR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBuktiACR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PiutangBungaACR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACRHasilProses;
    }
}