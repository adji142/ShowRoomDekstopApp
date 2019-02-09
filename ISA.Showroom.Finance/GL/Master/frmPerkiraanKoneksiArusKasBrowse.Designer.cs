namespace ISA.Showroom.Finance.GL
{
    partial class frmPerkiraanKoneksiArusKasBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerkiraanKoneksiArusKasBrowse));
            this.gridKode = new ISA.Controls.CustomGridView();
            this.kKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridHeader = new ISA.Controls.CustomGridView();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDetail = new ISA.Controls.CustomGridView();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.dRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridKode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridKode
            // 
            this.gridKode.AllowUserToAddRows = false;
            this.gridKode.AllowUserToDeleteRows = false;
            this.gridKode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kKode,
            this.kUraian});
            this.gridKode.Location = new System.Drawing.Point(6, 12);
            this.gridKode.MultiSelect = false;
            this.gridKode.Name = "gridKode";
            this.gridKode.ReadOnly = true;
            this.gridKode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridKode.Size = new System.Drawing.Size(320, 142);
            this.gridKode.StandardTab = true;
            this.gridKode.TabIndex = 3;
            this.gridKode.Enter += new System.EventHandler(this.gridKode_Enter);
            this.gridKode.SelectionChanged += new System.EventHandler(this.gridKode_SelectionChanged);
            this.gridKode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridKode_CellContentClick);
            // 
            // kKode
            // 
            this.kKode.DataPropertyName = "Kode";
            this.kKode.FillWeight = 50F;
            this.kKode.HeaderText = "Kode";
            this.kKode.Name = "kKode";
            this.kKode.ReadOnly = true;
            this.kKode.Width = 50;
            // 
            // kUraian
            // 
            this.kUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kUraian.DataPropertyName = "Uraian";
            this.kUraian.FillWeight = 150F;
            this.kUraian.HeaderText = "Uraian";
            this.kUraian.Name = "kUraian";
            this.kUraian.ReadOnly = true;
            // 
            // gridHeader
            // 
            this.gridHeader.AllowUserToAddRows = false;
            this.gridHeader.AllowUserToDeleteRows = false;
            this.gridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hRowID,
            this.hKode,
            this.hUraian,
            this.hRecordID});
            this.gridHeader.Location = new System.Drawing.Point(332, 12);
            this.gridHeader.MultiSelect = false;
            this.gridHeader.Name = "gridHeader";
            this.gridHeader.ReadOnly = true;
            this.gridHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridHeader.Size = new System.Drawing.Size(384, 142);
            this.gridHeader.StandardTab = true;
            this.gridHeader.TabIndex = 4;
            this.gridHeader.Enter += new System.EventHandler(this.gridHeader_Enter);
            this.gridHeader.SelectionChanged += new System.EventHandler(this.gridHeader_SelectionChanged);
            this.gridHeader.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHeader_CellContentClick);
            // 
            // hRowID
            // 
            this.hRowID.DataPropertyName = "RowID";
            this.hRowID.HeaderText = "RowID";
            this.hRowID.Name = "hRowID";
            this.hRowID.ReadOnly = true;
            this.hRowID.Visible = false;
            // 
            // hKode
            // 
            this.hKode.DataPropertyName = "Kode";
            this.hKode.HeaderText = "Kode";
            this.hKode.Name = "hKode";
            this.hKode.ReadOnly = true;
            this.hKode.Visible = false;
            // 
            // hUraian
            // 
            this.hUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hUraian.DataPropertyName = "Uraian";
            this.hUraian.HeaderText = "Uraian";
            this.hUraian.Name = "hUraian";
            this.hUraian.ReadOnly = true;
            // 
            // hRecordID
            // 
            this.hRecordID.DataPropertyName = "RecordID";
            this.hRecordID.HeaderText = "RecordID";
            this.hRecordID.Name = "hRecordID";
            this.hRecordID.ReadOnly = true;
            this.hRecordID.Visible = false;
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dRowID,
            this.dHeaderID,
            this.dNoPerkiraan,
            this.NamaPerkiraan,
            this.dUraian});
            this.gridDetail.Location = new System.Drawing.Point(6, 160);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetail.Size = new System.Drawing.Size(710, 242);
            this.gridDetail.StandardTab = true;
            this.gridDetail.TabIndex = 5;
            this.gridDetail.Enter += new System.EventHandler(this.gridDetail_Enter);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(112, 409);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 8;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(607, 408);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(6, 408);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 11;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(218, 409);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 12;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // dRowID
            // 
            this.dRowID.DataPropertyName = "RowID";
            this.dRowID.HeaderText = "RowID";
            this.dRowID.Name = "dRowID";
            this.dRowID.ReadOnly = true;
            this.dRowID.Visible = false;
            // 
            // dHeaderID
            // 
            this.dHeaderID.DataPropertyName = "HeaderID";
            this.dHeaderID.HeaderText = "HeaderID";
            this.dHeaderID.Name = "dHeaderID";
            this.dHeaderID.ReadOnly = true;
            this.dHeaderID.Visible = false;
            // 
            // dNoPerkiraan
            // 
            this.dNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.dNoPerkiraan.HeaderText = "NoPerkiraan";
            this.dNoPerkiraan.Name = "dNoPerkiraan";
            this.dNoPerkiraan.ReadOnly = true;
            this.dNoPerkiraan.Width = 150;
            // 
            // NamaPerkiraan
            // 
            this.NamaPerkiraan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.NamaPerkiraan.HeaderText = "NamaPerkiraan";
            this.NamaPerkiraan.Name = "NamaPerkiraan";
            this.NamaPerkiraan.ReadOnly = true;
            this.NamaPerkiraan.Width = 115;
            // 
            // dUraian
            // 
            this.dUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dUraian.DataPropertyName = "Uraian";
            this.dUraian.HeaderText = "Uraian";
            this.dUraian.Name = "dUraian";
            this.dUraian.ReadOnly = true;
            // 
            // frmPerkiraanKoneksiArusKasBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(719, 460);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gridKode);
            this.Controls.Add(this.gridHeader);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.gridDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPerkiraanKoneksiArusKasBrowse";
            this.Text = "Koneksi Perkiraan dengan Arus Kas";
            this.Load += new System.EventHandler(this.frmPerkiraanKoneksiArusKasBrowse_Load);
            this.Controls.SetChildIndex(this.gridDetail, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.gridHeader, 0);
            this.Controls.SetChildIndex(this.gridKode, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridKode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView gridKode;
        private ISA.Controls.CustomGridView gridHeader;
        private ISA.Controls.CustomGridView gridDetail;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn kKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn kUraian;
        private ISA.Controls.CommandButton cmdADD;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private ISA.Controls.CommandButton cmdDELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUraian;
    }
}
