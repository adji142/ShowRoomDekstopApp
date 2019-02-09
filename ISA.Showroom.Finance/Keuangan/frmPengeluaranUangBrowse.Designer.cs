namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmPengeluaranUangBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPengeluaranUangBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rgtglKlr = new ISA.Controls.RangeDateBox();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdKOREKSI = new System.Windows.Forms.Button();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JnsTransaksiRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeJnsTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JournalRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalRk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPerusahaanke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangKeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JnsTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusApproval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.JnsTransaksiRowID,
            this.KodeJnsTransaksi,
            this.IsGroup,
            this.HIRowID,
            this.JournalRowID,
            this.GroupRowID,
            this.LastUpdatedTime,
            this.NoBukti,
            this.TanggalInput,
            this.Tanggal,
            this.TanggalRk,
            this.NamaPerusahaanke,
            this.CabangKeID,
            this.NamaVendor,
            this.JnsTransaksi,
            this.MataUang,
            this.Nominal,
            this.Uraian,
            this.StatusApproval,
            this.Bank,
            this.NoHI,
            this.IsPembayaran,
            this.NoAcc});
            this.dataGridView1.Location = new System.Drawing.Point(28, 97);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(651, 170);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(579, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(134, 289);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 11;
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
            this.cmdADD.Location = new System.Drawing.Point(28, 289);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 10;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(366, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rgtglKlr
            // 
            this.rgtglKlr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgtglKlr.FromDate = null;
            this.rgtglKlr.Location = new System.Drawing.Point(87, 69);
            this.rgtglKlr.Name = "rgtglKlr";
            this.rgtglKlr.Size = new System.Drawing.Size(257, 22);
            this.rgtglKlr.TabIndex = 22;
            this.rgtglKlr.ToDate = null;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(32, 72);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(49, 14);
            this.lblTanggal.TabIndex = 21;
            this.lblTanggal.Text = "Tanggal";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(240, 289);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 25;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdKOREKSI
            // 
            this.cmdKOREKSI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdKOREKSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKOREKSI.Location = new System.Drawing.Point(366, 289);
            this.cmdKOREKSI.Name = "cmdKOREKSI";
            this.cmdKOREKSI.Size = new System.Drawing.Size(94, 40);
            this.cmdKOREKSI.TabIndex = 26;
            this.cmdKOREKSI.Text = "KOREKSI";
            this.cmdKOREKSI.UseVisualStyleBackColor = true;
            this.cmdKOREKSI.Click += new System.EventHandler(this.cmdKOREKSI_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // JnsTransaksiRowID
            // 
            this.JnsTransaksiRowID.DataPropertyName = "JnsTransaksiRowID";
            this.JnsTransaksiRowID.HeaderText = "JnsTransaksiRowID";
            this.JnsTransaksiRowID.Name = "JnsTransaksiRowID";
            this.JnsTransaksiRowID.ReadOnly = true;
            this.JnsTransaksiRowID.Visible = false;
            // 
            // KodeJnsTransaksi
            // 
            this.KodeJnsTransaksi.DataPropertyName = "JnsTransaksi";
            this.KodeJnsTransaksi.HeaderText = "JnsTransaksi";
            this.KodeJnsTransaksi.Name = "KodeJnsTransaksi";
            this.KodeJnsTransaksi.ReadOnly = true;
            this.KodeJnsTransaksi.Visible = false;
            // 
            // IsGroup
            // 
            this.IsGroup.DataPropertyName = "IsGroup";
            this.IsGroup.HeaderText = "IsGroup";
            this.IsGroup.Name = "IsGroup";
            this.IsGroup.ReadOnly = true;
            this.IsGroup.Visible = false;
            // 
            // HIRowID
            // 
            this.HIRowID.DataPropertyName = "HIRowID";
            this.HIRowID.HeaderText = "HIRowID";
            this.HIRowID.Name = "HIRowID";
            this.HIRowID.ReadOnly = true;
            this.HIRowID.Visible = false;
            // 
            // JournalRowID
            // 
            this.JournalRowID.DataPropertyName = "JournalRowID";
            this.JournalRowID.HeaderText = "JournalRowID";
            this.JournalRowID.Name = "JournalRowID";
            this.JournalRowID.ReadOnly = true;
            this.JournalRowID.Visible = false;
            // 
            // GroupRowID
            // 
            this.GroupRowID.DataPropertyName = "GroupRowID";
            this.GroupRowID.HeaderText = "GroupRowID";
            this.GroupRowID.Name = "GroupRowID";
            this.GroupRowID.ReadOnly = true;
            this.GroupRowID.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // TanggalInput
            // 
            this.TanggalInput.DataPropertyName = "CreatedTime";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.TanggalInput.DefaultCellStyle = dataGridViewCellStyle1;
            this.TanggalInput.HeaderText = "Tgl. Input";
            this.TanggalInput.Name = "TanggalInput";
            this.TanggalInput.ReadOnly = true;
            this.TanggalInput.Visible = false;
            this.TanggalInput.Width = 75;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tanggal.HeaderText = "Tanggal Input";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // TanggalRk
            // 
            this.TanggalRk.DataPropertyName = "TanggalRk";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.TanggalRk.DefaultCellStyle = dataGridViewCellStyle3;
            this.TanggalRk.HeaderText = "Tanggal Rk";
            this.TanggalRk.Name = "TanggalRk";
            this.TanggalRk.ReadOnly = true;
            // 
            // NamaPerusahaanke
            // 
            this.NamaPerusahaanke.DataPropertyName = "PTKeID";
            this.NamaPerusahaanke.HeaderText = "Ke PT";
            this.NamaPerusahaanke.Name = "NamaPerusahaanke";
            this.NamaPerusahaanke.ReadOnly = true;
            this.NamaPerusahaanke.Width = 70;
            // 
            // CabangKeID
            // 
            this.CabangKeID.DataPropertyName = "CabangKeID";
            this.CabangKeID.HeaderText = "Ke Cab.";
            this.CabangKeID.Name = "CabangKeID";
            this.CabangKeID.ReadOnly = true;
            this.CabangKeID.Width = 50;
            // 
            // NamaVendor
            // 
            this.NamaVendor.DataPropertyName = "NamaVendor";
            this.NamaVendor.HeaderText = "Ke Vendor";
            this.NamaVendor.Name = "NamaVendor";
            this.NamaVendor.ReadOnly = true;
            this.NamaVendor.Width = 50;
            // 
            // JnsTransaksi
            // 
            this.JnsTransaksi.DataPropertyName = "NamaTransaksi";
            this.JnsTransaksi.HeaderText = "Jenis Transaksi";
            this.JnsTransaksi.Name = "JnsTransaksi";
            this.JnsTransaksi.ReadOnly = true;
            this.JnsTransaksi.Width = 150;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            this.MataUang.HeaderText = "Mata Uang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            this.MataUang.Width = 50;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle4;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 200;
            // 
            // StatusApproval
            // 
            this.StatusApproval.DataPropertyName = "DescStatusApproval";
            this.StatusApproval.HeaderText = "Status Acc";
            this.StatusApproval.Name = "StatusApproval";
            this.StatusApproval.ReadOnly = true;
            this.StatusApproval.Width = 150;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "NamaRekening";
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            // 
            // NoHI
            // 
            this.NoHI.DataPropertyName = "NoHI";
            this.NoHI.HeaderText = "No.DKN";
            this.NoHI.Name = "NoHI";
            this.NoHI.ReadOnly = true;
            // 
            // IsPembayaran
            // 
            this.IsPembayaran.DataPropertyName = "IsPembayaran";
            this.IsPembayaran.HeaderText = "IsPembayaran";
            this.IsPembayaran.Name = "IsPembayaran";
            this.IsPembayaran.ReadOnly = true;
            this.IsPembayaran.Visible = false;
            // 
            // NoAcc
            // 
            this.NoAcc.DataPropertyName = "NoAcc";
            this.NoAcc.HeaderText = "NoAcc";
            this.NoAcc.Name = "NoAcc";
            this.NoAcc.ReadOnly = true;
            // 
            // frmPengeluaranUangBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdKOREKSI);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rgtglKlr);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPengeluaranUangBrowse";
            this.Text = "Pengeluaran Uang";
            this.Title = "Pengeluaran Uang";
            this.Load += new System.EventHandler(this.frmPengeluaranUangBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblTanggal, 0);
            this.Controls.SetChildIndex(this.rgtglKlr, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdKOREKSI, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private System.Windows.Forms.Button btnSearch;
        private ISA.Controls.RangeDateBox rgtglKlr;
        private System.Windows.Forms.Label lblTanggal;
        private ISA.Controls.CommandButton cmdDelete;
        private System.Windows.Forms.Button cmdKOREKSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JnsTransaksiRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeJnsTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn HIRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalRk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPerusahaanke;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangKeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn JnsTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusApproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAcc;
    }
}
