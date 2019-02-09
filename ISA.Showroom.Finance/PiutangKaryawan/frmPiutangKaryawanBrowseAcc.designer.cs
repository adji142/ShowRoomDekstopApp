namespace ISA.Showroom.Finance.PiutangKaryawan
{
    partial class frmPiutangKaryawanBrowseAcc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPiutangKaryawanBrowseAcc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridPiutangKaryawan = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.button1 = new System.Windows.Forms.Button();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdAcc = new System.Windows.Forms.Button();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalAcc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalAcc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaKaryawan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalPinjaman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeteranganAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlasanPinjam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPiutangKaryawan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPiutangKaryawan
            // 
            this.dataGridPiutangKaryawan.AllowUserToAddRows = false;
            this.dataGridPiutangKaryawan.AllowUserToDeleteRows = false;
            this.dataGridPiutangKaryawan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridPiutangKaryawan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPiutangKaryawan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPiutangKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPiutangKaryawan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.CreatedOn,
            this.TanggalAcc1,
            this.TanggalAcc2,
            this.NoBukti,
            this.NamaKaryawan,
            this.NominalPinjaman,
            this.KeteranganAcc,
            this.AlasanPinjam});
            this.dataGridPiutangKaryawan.Location = new System.Drawing.Point(26, 69);
            this.dataGridPiutangKaryawan.MultiSelect = false;
            this.dataGridPiutangKaryawan.Name = "dataGridPiutangKaryawan";
            this.dataGridPiutangKaryawan.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridPiutangKaryawan.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridPiutangKaryawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridPiutangKaryawan.Size = new System.Drawing.Size(706, 210);
            this.dataGridPiutangKaryawan.StandardTab = true;
            this.dataGridPiutangKaryawan.TabIndex = 5;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(632, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(26, 43);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 14;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdAcc
            // 
            this.cmdAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAcc.Image = ((System.Drawing.Image)(resources.GetObject("cmdAcc.Image")));
            this.cmdAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAcc.Location = new System.Drawing.Point(26, 285);
            this.cmdAcc.Name = "cmdAcc";
            this.cmdAcc.Size = new System.Drawing.Size(90, 40);
            this.cmdAcc.TabIndex = 16;
            this.cmdAcc.Text = "ACC";
            this.cmdAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAcc.UseVisualStyleBackColor = true;
            this.cmdAcc.Click += new System.EventHandler(this.cmdAcc_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.CreatedOn.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreatedOn.HeaderText = "Tanggal Input";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            // 
            // TanggalAcc1
            // 
            this.TanggalAcc1.DataPropertyName = "TanggalAcc1";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TanggalAcc1.DefaultCellStyle = dataGridViewCellStyle3;
            this.TanggalAcc1.HeaderText = "Tanggal Acc #1";
            this.TanggalAcc1.Name = "TanggalAcc1";
            this.TanggalAcc1.ReadOnly = true;
            // 
            // TanggalAcc2
            // 
            this.TanggalAcc2.DataPropertyName = "TanggalAcc2";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.TanggalAcc2.DefaultCellStyle = dataGridViewCellStyle4;
            this.TanggalAcc2.HeaderText = "Tanggal Acc #2";
            this.TanggalAcc2.Name = "TanggalAcc2";
            this.TanggalAcc2.ReadOnly = true;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No.Bukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // NamaKaryawan
            // 
            this.NamaKaryawan.DataPropertyName = "NamaKaryawan";
            this.NamaKaryawan.HeaderText = "Nama Karyawan";
            this.NamaKaryawan.Name = "NamaKaryawan";
            this.NamaKaryawan.ReadOnly = true;
            this.NamaKaryawan.Width = 250;
            // 
            // NominalPinjaman
            // 
            this.NominalPinjaman.DataPropertyName = "NominalPinjaman";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.NominalPinjaman.DefaultCellStyle = dataGridViewCellStyle5;
            this.NominalPinjaman.HeaderText = "Nominal";
            this.NominalPinjaman.Name = "NominalPinjaman";
            this.NominalPinjaman.ReadOnly = true;
            // 
            // KeteranganAcc
            // 
            this.KeteranganAcc.DataPropertyName = "DescStatusApproval";
            this.KeteranganAcc.HeaderText = "Status";
            this.KeteranganAcc.Name = "KeteranganAcc";
            this.KeteranganAcc.ReadOnly = true;
            this.KeteranganAcc.Width = 150;
            // 
            // AlasanPinjam
            // 
            this.AlasanPinjam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlasanPinjam.DataPropertyName = "AlasanPinjam";
            this.AlasanPinjam.HeaderText = "Keterangan";
            this.AlasanPinjam.Name = "AlasanPinjam";
            this.AlasanPinjam.ReadOnly = true;
            // 
            // frmPiutangKaryawanBrowseAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(753, 349);
            this.Controls.Add(this.cmdAcc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridPiutangKaryawan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPiutangKaryawanBrowseAcc";
            this.Text = "ACC PK";
            this.Title = "ACC PK";
            this.Load += new System.EventHandler(this.frmPiutangKaryawanBrowseAcc_Load);
            this.Controls.SetChildIndex(this.dataGridPiutangKaryawan, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.cmdAcc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPiutangKaryawan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dataGridPiutangKaryawan;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button button1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Button cmdAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalAcc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalAcc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaKaryawan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalPinjaman;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeteranganAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlasanPinjam;
    }
}
