namespace ISA.Showroom.Master
{
    partial class frmMotor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvProduk = new ISA.Controls.CustomGridView();
            this.RowIDProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMerk = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerkRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mesin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDMerk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerk)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.MerkRowID,
            this.KodeType,
            this.Type,
            this.CC,
            this.Mesin,
            this.Keterangan});
            this.dataGridView1.Location = new System.Drawing.Point(3, 113);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(641, 106);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 16;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(573, 278);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 20;
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
            this.cmdDELETE.Location = new System.Drawing.Point(276, 278);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 19;
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
            this.cmdEDIT.Location = new System.Drawing.Point(152, 278);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 18;
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
            this.cmdADD.Location = new System.Drawing.Point(29, 278);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 17;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvProduk, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvMerk, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 222);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // dgvProduk
            // 
            this.dgvProduk.AllowUserToAddRows = false;
            this.dgvProduk.AllowUserToDeleteRows = false;
            this.dgvProduk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProduk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDProduk,
            this.NamaProduk});
            this.dgvProduk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduk.Location = new System.Drawing.Point(3, 3);
            this.dgvProduk.Name = "dgvProduk";
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.RowHeadersVisible = false;
            this.dgvProduk.Size = new System.Drawing.Size(641, 49);
            this.dgvProduk.StandardTab = true;
            this.dgvProduk.TabIndex = 17;
            this.dgvProduk.SelectionRowChanged += new System.EventHandler(this.dgvProduk_SelectionRowChanged);
            // 
            // RowIDProduk
            // 
            this.RowIDProduk.DataPropertyName = "RowID";
            this.RowIDProduk.HeaderText = "RowID";
            this.RowIDProduk.Name = "RowIDProduk";
            this.RowIDProduk.ReadOnly = true;
            this.RowIDProduk.Visible = false;
            // 
            // NamaProduk
            // 
            this.NamaProduk.DataPropertyName = "Produk";
            this.NamaProduk.HeaderText = "Nama Produk";
            this.NamaProduk.Name = "NamaProduk";
            this.NamaProduk.ReadOnly = true;
            this.NamaProduk.Width = 300;
            // 
            // dgvMerk
            // 
            this.dgvMerk.AllowUserToAddRows = false;
            this.dgvMerk.AllowUserToDeleteRows = false;
            this.dgvMerk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMerk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDMerk,
            this.Merk});
            this.dgvMerk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMerk.Location = new System.Drawing.Point(3, 58);
            this.dgvMerk.Name = "dgvMerk";
            this.dgvMerk.ReadOnly = true;
            this.dgvMerk.RowHeadersVisible = false;
            this.dgvMerk.Size = new System.Drawing.Size(641, 49);
            this.dgvMerk.StandardTab = true;
            this.dgvMerk.TabIndex = 18;
            this.dgvMerk.SelectionRowChanged += new System.EventHandler(this.dgvMerk_SelectionRowChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // MerkRowID
            // 
            this.MerkRowID.DataPropertyName = "MerkRowID";
            this.MerkRowID.HeaderText = "MerkRowID";
            this.MerkRowID.Name = "MerkRowID";
            this.MerkRowID.ReadOnly = true;
            this.MerkRowID.Visible = false;
            this.MerkRowID.Width = 150;
            // 
            // KodeType
            // 
            this.KodeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KodeType.DataPropertyName = "KodeType";
            this.KodeType.HeaderText = "Type";
            this.KodeType.Name = "KodeType";
            this.KodeType.ReadOnly = true;
            this.KodeType.Width = 58;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Kode Type";
            this.Type.MinimumWidth = 250;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 250;
            // 
            // CC
            // 
            this.CC.DataPropertyName = "Cc";
            this.CC.HeaderText = "CC";
            this.CC.MinimumWidth = 75;
            this.CC.Name = "CC";
            this.CC.ReadOnly = true;
            this.CC.Width = 75;
            // 
            // Mesin
            // 
            this.Mesin.DataPropertyName = "Mesin";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mesin.DefaultCellStyle = dataGridViewCellStyle6;
            this.Mesin.HeaderText = "Mesin";
            this.Mesin.MinimumWidth = 75;
            this.Mesin.Name = "Mesin";
            this.Mesin.ReadOnly = true;
            this.Mesin.Width = 75;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.MinimumWidth = 300;
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 300;
            // 
            // RowIDMerk
            // 
            this.RowIDMerk.DataPropertyName = "RowID";
            this.RowIDMerk.HeaderText = "RowID";
            this.RowIDMerk.Name = "RowIDMerk";
            this.RowIDMerk.ReadOnly = true;
            this.RowIDMerk.Visible = false;
            // 
            // Merk
            // 
            this.Merk.DataPropertyName = "Merk";
            this.Merk.HeaderText = "Merk Motor";
            this.Merk.Name = "Merk";
            this.Merk.ReadOnly = true;
            this.Merk.Width = 300;
            // 
            // frmMotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMotor";
            this.Text = "Master Motor";
            this.Title = "Master Motor";
            this.Load += new System.EventHandler(this.frmMotor_Load);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView dgvProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaProduk;
        private ISA.Controls.CustomGridView dgvMerk;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerkRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDMerk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
    }
}