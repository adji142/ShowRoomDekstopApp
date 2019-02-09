namespace ISA.Showroom.Finance.Master
{
    partial class frmKursBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKursBrowse));
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalKurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpOptFilter = new System.Windows.Forms.GroupBox();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.rgdTglKurs = new ISA.Controls.RangeDateBox();
            this.rdoMataUang = new System.Windows.Forms.RadioButton();
            this.rdoTanggal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.grpOptFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.MataUangID,
            this.TanggalKurs,
            this.Kurs,
            this.Keterangan,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(31, 172);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(640, 112);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // MataUangID
            // 
            this.MataUangID.DataPropertyName = "MataUangID";
            this.MataUangID.HeaderText = "Mata Uang";
            this.MataUangID.Name = "MataUangID";
            this.MataUangID.ReadOnly = true;
            // 
            // TanggalKurs
            // 
            this.TanggalKurs.DataPropertyName = "TanggalKurs";
            this.TanggalKurs.HeaderText = "Tanggal";
            this.TanggalKurs.Name = "TanggalKurs";
            this.TanggalKurs.ReadOnly = true;
            // 
            // Kurs
            // 
            this.Kurs.DataPropertyName = "Kurs";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Kurs.DefaultCellStyle = dataGridViewCellStyle1;
            this.Kurs.HeaderText = "Kurs";
            this.Kurs.Name = "Kurs";
            this.Kurs.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "NamaMataUang";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LastUpdatedBy";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LastUpdatedTime";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(571, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(277, 289);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 12;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(153, 289);
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
            this.cmdADD.Location = new System.Drawing.Point(30, 289);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 10;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.Controls.Add(this.grpOptFilter);
            this.pnlFilter.Location = new System.Drawing.Point(31, 67);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(640, 99);
            this.pnlFilter.TabIndex = 14;
            // 
            // grpOptFilter
            // 
            this.grpOptFilter.Controls.Add(this.cboMataUang);
            this.grpOptFilter.Controls.Add(this.rgdTglKurs);
            this.grpOptFilter.Controls.Add(this.rdoMataUang);
            this.grpOptFilter.Controls.Add(this.rdoTanggal);
            this.grpOptFilter.Location = new System.Drawing.Point(3, 15);
            this.grpOptFilter.Name = "grpOptFilter";
            this.grpOptFilter.Size = new System.Drawing.Size(453, 68);
            this.grpOptFilter.TabIndex = 0;
            this.grpOptFilter.TabStop = false;
            this.grpOptFilter.Text = "Filter Berdasar : ";
            // 
            // cboMataUang
            // 
            this.cboMataUang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(147, 39);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(121, 22);
            this.cboMataUang.TabIndex = 4;
            this.cboMataUang.SelectedIndexChanged += new System.EventHandler(this.cboMataUang_SelectedIndexChanged);
            // 
            // rgdTglKurs
            // 
            this.rgdTglKurs.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgdTglKurs.FromDate = null;
            this.rgdTglKurs.Location = new System.Drawing.Point(108, 10);
            this.rgdTglKurs.Name = "rgdTglKurs";
            this.rgdTglKurs.Size = new System.Drawing.Size(257, 22);
            this.rgdTglKurs.TabIndex = 3;
            this.rgdTglKurs.ToDate = null;
            this.rgdTglKurs.Validating += new System.ComponentModel.CancelEventHandler(this.rgdTglKurs_Validating);
            // 
            // rdoMataUang
            // 
            this.rdoMataUang.AutoSize = true;
            this.rdoMataUang.Location = new System.Drawing.Point(6, 41);
            this.rdoMataUang.Name = "rdoMataUang";
            this.rdoMataUang.Size = new System.Drawing.Size(81, 18);
            this.rdoMataUang.TabIndex = 1;
            this.rdoMataUang.TabStop = true;
            this.rdoMataUang.Text = "Mata Uang";
            this.rdoMataUang.UseVisualStyleBackColor = true;
            this.rdoMataUang.CheckedChanged += new System.EventHandler(this.rdoMataUang_CheckedChanged);
            // 
            // rdoTanggal
            // 
            this.rdoTanggal.AutoSize = true;
            this.rdoTanggal.Location = new System.Drawing.Point(6, 14);
            this.rdoTanggal.Name = "rdoTanggal";
            this.rdoTanggal.Size = new System.Drawing.Size(96, 18);
            this.rdoTanggal.TabIndex = 0;
            this.rdoTanggal.TabStop = true;
            this.rdoTanggal.Text = "Tanggal Kurs";
            this.rdoTanggal.UseVisualStyleBackColor = true;
            this.rdoTanggal.CheckedChanged += new System.EventHandler(this.rdoTanggal_CheckedChanged);
            // 
            // frmKursBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKursBrowse";
            this.Text = "Kurs Mata Uang";
            this.Title = "Kurs Mata Uang";
            this.Load += new System.EventHandler(this.frmKursBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.grpOptFilter.ResumeLayout(false);
            this.grpOptFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpOptFilter;
        private System.Windows.Forms.RadioButton rdoMataUang;
        private System.Windows.Forms.RadioButton rdoTanggal;
        private ISA.Controls.RangeDateBox rgdTglKurs;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalKurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
