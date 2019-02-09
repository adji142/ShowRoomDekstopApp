namespace ISA.Showroom.Controls
{
    partial class frmLookUpMotor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookUpMotor));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new ISA.Controls.CommonTextBox();
            this.gvSearch = new ISA.Controls.CustomGridView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.MerkMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mesin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Merk / Type Motor";
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(130, 64);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(162, 20);
            this.txtSearch.TabIndex = 14;
            // 
            // gvSearch
            // 
            this.gvSearch.AllowUserToAddRows = false;
            this.gvSearch.AllowUserToDeleteRows = false;
            this.gvSearch.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MerkMotor,
            this.Type,
            this.TypeMotor,
            this.Produk,
            this.Cc,
            this.Mesin,
            this.Keterangan});
            this.gvSearch.Location = new System.Drawing.Point(12, 86);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.ReadOnly = true;
            this.gvSearch.RowHeadersVisible = false;
            this.gvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSearch.Size = new System.Drawing.Size(633, 216);
            this.gvSearch.StandardTab = true;
            this.gvSearch.TabIndex = 13;
            this.gvSearch.DoubleClick += new System.EventHandler(this.gvSearch_DoubleClick);
            this.gvSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSearch_KeyDown);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(296, 63);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(29, 23);
            this.cmdSearch.TabIndex = 16;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 308);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 11;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(545, 308);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // MerkMotor
            // 
            this.MerkMotor.DataPropertyName = "Merk";
            this.MerkMotor.HeaderText = "Merk Motor";
            this.MerkMotor.Name = "MerkMotor";
            this.MerkMotor.ReadOnly = true;
            this.MerkMotor.Width = 175;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "KodeType";
            this.Type.HeaderText = "Kode Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // TypeMotor
            // 
            this.TypeMotor.DataPropertyName = "Type";
            this.TypeMotor.HeaderText = "Nama type";
            this.TypeMotor.Name = "TypeMotor";
            this.TypeMotor.ReadOnly = true;
            this.TypeMotor.Width = 205;
            // 
            // Produk
            // 
            this.Produk.DataPropertyName = "Produk";
            this.Produk.HeaderText = "Produk";
            this.Produk.Name = "Produk";
            this.Produk.ReadOnly = true;
            // 
            // Cc
            // 
            this.Cc.DataPropertyName = "Cc";
            this.Cc.HeaderText = "CC";
            this.Cc.Name = "Cc";
            this.Cc.ReadOnly = true;
            this.Cc.Width = 75;
            // 
            // Mesin
            // 
            this.Mesin.DataPropertyName = "Mesin";
            this.Mesin.HeaderText = "Mesin";
            this.Mesin.Name = "Mesin";
            this.Mesin.ReadOnly = true;
            this.Mesin.Width = 75;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 150;
            // 
            // frmLookUpMotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 360);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gvSearch);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLookUpMotor";
            this.Text = "List Merk && Type Motor";
            this.Title = "List Merk && Type Motor";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLookUpMotor_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.gvSearch, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtSearch;
        private ISA.Controls.CustomGridView gvSearch;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerkMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;

    }
}