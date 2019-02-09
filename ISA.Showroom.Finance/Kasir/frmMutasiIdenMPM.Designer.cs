namespace ISA.Showroom.Finance.Kasir
{
    partial class frmMutasiIdenMPM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMutasiIdenMPM));
            this.rgtglKlr = new ISA.Controls.RangeDateBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GVHeader = new ISA.Controls.CustomGridView();
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
            this.NominalIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalSisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusApproval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // rgtglKlr
            // 
            this.rgtglKlr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgtglKlr.FromDate = null;
            this.rgtglKlr.Location = new System.Drawing.Point(104, 69);
            this.rgtglKlr.Name = "rgtglKlr";
            this.rgtglKlr.Size = new System.Drawing.Size(257, 22);
            this.rgtglKlr.TabIndex = 31;
            this.rgtglKlr.ToDate = null;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(356, 70);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 30;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tanggal  :";
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.AllowUserToResizeRows = false;
            this.GVHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.NominalIden,
            this.NominalSisa,
            this.Uraian,
            this.StatusApproval,
            this.Bank,
            this.NoHI,
            this.IsPembayaran,
            this.NoAcc});
            this.GVHeader.Location = new System.Drawing.Point(31, 99);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(759, 218);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 32;
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
            this.NamaPerusahaanke.Visible = false;
            this.NamaPerusahaanke.Width = 70;
            // 
            // CabangKeID
            // 
            this.CabangKeID.DataPropertyName = "CabangKeID";
            this.CabangKeID.HeaderText = "Ke Cab.";
            this.CabangKeID.Name = "CabangKeID";
            this.CabangKeID.ReadOnly = true;
            this.CabangKeID.Visible = false;
            this.CabangKeID.Width = 50;
            // 
            // NamaVendor
            // 
            this.NamaVendor.DataPropertyName = "NamaVendor";
            this.NamaVendor.HeaderText = "Ke Vendor";
            this.NamaVendor.Name = "NamaVendor";
            this.NamaVendor.ReadOnly = true;
            this.NamaVendor.Width = 150;
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
            // NominalIden
            // 
            this.NominalIden.DataPropertyName = "NominalIden";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.NominalIden.DefaultCellStyle = dataGridViewCellStyle5;
            this.NominalIden.HeaderText = "Nominal Iden";
            this.NominalIden.Name = "NominalIden";
            this.NominalIden.ReadOnly = true;
            // 
            // NominalSisa
            // 
            this.NominalSisa.DataPropertyName = "NominalSisa";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.NominalSisa.DefaultCellStyle = dataGridViewCellStyle6;
            this.NominalSisa.HeaderText = "Nominal Sisa";
            this.NominalSisa.Name = "NominalSisa";
            this.NominalSisa.ReadOnly = true;
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
            this.StatusApproval.Visible = false;
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
            this.NoHI.Visible = false;
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
            this.NoAcc.Visible = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(31, 341);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 33;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(690, 341);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 34;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmMutasiIdenMPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 385);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.GVHeader);
            this.Controls.Add(this.rgtglKlr);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMutasiIdenMPM";
            this.Text = "Mutasi Iden MPM";
            this.Title = "Mutasi Iden MPM";
            this.Load += new System.EventHandler(this.frmMutasiIdenMPM_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btn_Search, 0);
            this.Controls.SetChildIndex(this.rgtglKlr, 0);
            this.Controls.SetChildIndex(this.GVHeader, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rgtglKlr;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView GVHeader;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalIden;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalSisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusApproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAcc;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
    }
}