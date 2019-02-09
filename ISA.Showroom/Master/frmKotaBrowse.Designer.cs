namespace ISA.Showroom.Master
{
    partial class frmKotaBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKotaBrowse));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridProvinsi = new ISA.Controls.CustomGridView();
            this.ProvRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provinsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridKota = new ISA.Controls.CustomGridView();
            this.KotaRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gridKecamatan = new ISA.Controls.CustomGridView();
            this.gridKelurahan = new ISA.Controls.CustomGridView();
            this.KelRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kelurahan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.KecRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kecamatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WILID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProvinsi)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKota)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKecamatan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKelurahan)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(21, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridProvinsi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(662, 200);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 14;
            // 
            // gridProvinsi
            // 
            this.gridProvinsi.AllowUserToAddRows = false;
            this.gridProvinsi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridProvinsi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProvinsi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProvinsi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridProvinsi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProvinsi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProvRowID,
            this.Provinsi});
            this.gridProvinsi.Location = new System.Drawing.Point(3, 3);
            this.gridProvinsi.MaximumSize = new System.Drawing.Size(350, 500);
            this.gridProvinsi.MultiSelect = false;
            this.gridProvinsi.Name = "gridProvinsi";
            this.gridProvinsi.ReadOnly = true;
            this.gridProvinsi.RowHeadersVisible = false;
            this.gridProvinsi.RowTemplate.Height = 25;
            this.gridProvinsi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridProvinsi.Size = new System.Drawing.Size(154, 195);
            this.gridProvinsi.StandardTab = true;
            this.gridProvinsi.TabIndex = 11;
            this.gridProvinsi.Enter += new System.EventHandler(this.gridProvinsi_Enter);
            this.gridProvinsi.SelectionChanged += new System.EventHandler(this.gridProvinsi_SelectionChanged);
            // 
            // ProvRowID
            // 
            this.ProvRowID.DataPropertyName = "RowID";
            this.ProvRowID.HeaderText = "RowID";
            this.ProvRowID.Name = "ProvRowID";
            this.ProvRowID.ReadOnly = true;
            this.ProvRowID.Visible = false;
            // 
            // Provinsi
            // 
            this.Provinsi.DataPropertyName = "Nama";
            this.Provinsi.HeaderText = "Provinsi";
            this.Provinsi.Name = "Provinsi";
            this.Provinsi.ReadOnly = true;
            this.Provinsi.Width = 326;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridKota);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(498, 200);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridKota
            // 
            this.gridKota.AllowUserToAddRows = false;
            this.gridKota.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridKota.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridKota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridKota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KotaRowID,
            this.Kota});
            this.gridKota.Location = new System.Drawing.Point(3, 3);
            this.gridKota.MaximumSize = new System.Drawing.Size(350, 500);
            this.gridKota.MultiSelect = false;
            this.gridKota.Name = "gridKota";
            this.gridKota.ReadOnly = true;
            this.gridKota.RowHeadersVisible = false;
            this.gridKota.RowTemplate.Height = 25;
            this.gridKota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridKota.Size = new System.Drawing.Size(154, 194);
            this.gridKota.StandardTab = true;
            this.gridKota.TabIndex = 12;
            this.gridKota.Enter += new System.EventHandler(this.gridKota_Enter);
            this.gridKota.SelectionChanged += new System.EventHandler(this.gridKota_SelectionChanged);
            // 
            // KotaRowID
            // 
            this.KotaRowID.DataPropertyName = "RowID";
            this.KotaRowID.HeaderText = "RowID";
            this.KotaRowID.Name = "KotaRowID";
            this.KotaRowID.ReadOnly = true;
            this.KotaRowID.Visible = false;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Nama";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            this.Kota.Width = 326;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gridKecamatan);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gridKelurahan);
            this.splitContainer3.Size = new System.Drawing.Size(334, 200);
            this.splitContainer3.SplitterDistance = 160;
            this.splitContainer3.TabIndex = 0;
            // 
            // gridKecamatan
            // 
            this.gridKecamatan.AllowUserToAddRows = false;
            this.gridKecamatan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridKecamatan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridKecamatan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKecamatan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridKecamatan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKecamatan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KecRowID,
            this.Kecamatan,
            this.WILID});
            this.gridKecamatan.Location = new System.Drawing.Point(3, 3);
            this.gridKecamatan.MaximumSize = new System.Drawing.Size(350, 500);
            this.gridKecamatan.MultiSelect = false;
            this.gridKecamatan.Name = "gridKecamatan";
            this.gridKecamatan.ReadOnly = true;
            this.gridKecamatan.RowHeadersVisible = false;
            this.gridKecamatan.RowTemplate.Height = 25;
            this.gridKecamatan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridKecamatan.Size = new System.Drawing.Size(154, 194);
            this.gridKecamatan.StandardTab = true;
            this.gridKecamatan.TabIndex = 13;
            this.gridKecamatan.Enter += new System.EventHandler(this.gridKecamatan_Enter);
            this.gridKecamatan.SelectionChanged += new System.EventHandler(this.gridKecamatan_SelectionChanged);
            // 
            // gridKelurahan
            // 
            this.gridKelurahan.AllowUserToAddRows = false;
            this.gridKelurahan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridKelurahan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridKelurahan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKelurahan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridKelurahan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKelurahan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KelRowID,
            this.Kelurahan});
            this.gridKelurahan.Location = new System.Drawing.Point(3, 3);
            this.gridKelurahan.MaximumSize = new System.Drawing.Size(350, 500);
            this.gridKelurahan.MultiSelect = false;
            this.gridKelurahan.Name = "gridKelurahan";
            this.gridKelurahan.ReadOnly = true;
            this.gridKelurahan.RowHeadersVisible = false;
            this.gridKelurahan.RowTemplate.Height = 25;
            this.gridKelurahan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridKelurahan.Size = new System.Drawing.Size(164, 194);
            this.gridKelurahan.StandardTab = true;
            this.gridKelurahan.TabIndex = 14;
            this.gridKelurahan.Enter += new System.EventHandler(this.gridKelurahan_Enter);
            // 
            // KelRowID
            // 
            this.KelRowID.DataPropertyName = "RowID";
            this.KelRowID.HeaderText = "RowID";
            this.KelRowID.Name = "KelRowID";
            this.KelRowID.ReadOnly = true;
            this.KelRowID.Visible = false;
            // 
            // Kelurahan
            // 
            this.Kelurahan.DataPropertyName = "Nama";
            this.Kelurahan.HeaderText = "Kelurahan";
            this.Kelurahan.Name = "Kelurahan";
            this.Kelurahan.ReadOnly = true;
            this.Kelurahan.Width = 326;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(276, 277);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 17;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(571, 277);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 18;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(29, 277);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 15;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(152, 277);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 16;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // KecRowID
            // 
            this.KecRowID.DataPropertyName = "RowID";
            this.KecRowID.HeaderText = "RowID";
            this.KecRowID.Name = "KecRowID";
            this.KecRowID.ReadOnly = true;
            this.KecRowID.Visible = false;
            // 
            // Kecamatan
            // 
            this.Kecamatan.DataPropertyName = "Nama";
            this.Kecamatan.HeaderText = "Kecamatan";
            this.Kecamatan.Name = "Kecamatan";
            this.Kecamatan.ReadOnly = true;
            this.Kecamatan.Width = 150;
            // 
            // WILID
            // 
            this.WILID.DataPropertyName = "WILID";
            this.WILID.HeaderText = "WILID";
            this.WILID.Name = "WILID";
            this.WILID.ReadOnly = true;
            // 
            // frmKotaBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdEdit);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKotaBrowse";
            this.Text = "Master Kota";
            this.Title = "Master Kota";
            this.Load += new System.EventHandler(this.frmKotaBrowse_Load);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProvinsi)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKota)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKecamatan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKelurahan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ISA.Controls.CustomGridView gridProvinsi;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ISA.Controls.CustomGridView gridKota;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private ISA.Controls.CustomGridView gridKecamatan;
        private ISA.Controls.CustomGridView gridKelurahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provinsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KotaRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kelurahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn KecRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kecamatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn WILID;


    }
}