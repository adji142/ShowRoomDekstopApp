namespace ISA.Showroom.Master
{
    partial class frmStokMotorBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokMotorBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nopol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerkRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mesin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tahun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoMesin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRangka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBPKB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaJadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaOTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Nopol,
            this.MerkRowID,
            this.Produk,
            this.KodeType,
            this.Type,
            this.CC,
            this.Mesin,
            this.Warna,
            this.Tahun,
            this.Keterangan,
            this.NoMesin,
            this.NoRangka,
            this.NoBPKB,
            this.HargaJadi,
            this.HargaOTR,
            this.Stok});
            this.dataGridView1.Location = new System.Drawing.Point(28, 57);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(654, 226);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 21;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(582, 293);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Nopol
            // 
            this.Nopol.DataPropertyName = "Nopol";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Nopol.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nopol.HeaderText = "No. Polisi";
            this.Nopol.Name = "Nopol";
            this.Nopol.ReadOnly = true;
            this.Nopol.Width = 80;
            // 
            // MerkRowID
            // 
            this.MerkRowID.DataPropertyName = "MerkMotor";
            this.MerkRowID.HeaderText = "Merk";
            this.MerkRowID.Name = "MerkRowID";
            this.MerkRowID.ReadOnly = true;
            this.MerkRowID.Width = 90;
            // 
            // Produk
            // 
            this.Produk.DataPropertyName = "Produk";
            this.Produk.HeaderText = "Produk";
            this.Produk.Name = "Produk";
            this.Produk.ReadOnly = true;
            // 
            // KodeType
            // 
            this.KodeType.DataPropertyName = "KodeType";
            this.KodeType.HeaderText = "Type";
            this.KodeType.Name = "KodeType";
            this.KodeType.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "TypeMotor";
            this.Type.HeaderText = "Type Motor";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 175;
            // 
            // CC
            // 
            this.CC.DataPropertyName = "Cc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CC.DefaultCellStyle = dataGridViewCellStyle3;
            this.CC.HeaderText = "CC";
            this.CC.Name = "CC";
            this.CC.ReadOnly = true;
            this.CC.Width = 40;
            // 
            // Mesin
            // 
            this.Mesin.DataPropertyName = "Mesin";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mesin.DefaultCellStyle = dataGridViewCellStyle4;
            this.Mesin.HeaderText = "Mesin";
            this.Mesin.Name = "Mesin";
            this.Mesin.ReadOnly = true;
            this.Mesin.Width = 50;
            // 
            // Warna
            // 
            this.Warna.DataPropertyName = "Warna";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Warna.DefaultCellStyle = dataGridViewCellStyle5;
            this.Warna.HeaderText = "Warna";
            this.Warna.Name = "Warna";
            this.Warna.ReadOnly = true;
            // 
            // Tahun
            // 
            this.Tahun.DataPropertyName = "Tahun";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tahun.DefaultCellStyle = dataGridViewCellStyle6;
            this.Tahun.HeaderText = "Tahun";
            this.Tahun.Name = "Tahun";
            this.Tahun.ReadOnly = true;
            this.Tahun.Width = 50;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 175;
            // 
            // NoMesin
            // 
            this.NoMesin.DataPropertyName = "NoMesin";
            this.NoMesin.HeaderText = "No. Mesin";
            this.NoMesin.Name = "NoMesin";
            this.NoMesin.ReadOnly = true;
            this.NoMesin.Width = 125;
            // 
            // NoRangka
            // 
            this.NoRangka.DataPropertyName = "NoRangka";
            this.NoRangka.HeaderText = "No. Rangka";
            this.NoRangka.Name = "NoRangka";
            this.NoRangka.ReadOnly = true;
            this.NoRangka.Width = 125;
            // 
            // NoBPKB
            // 
            this.NoBPKB.DataPropertyName = "NoBPKB";
            this.NoBPKB.HeaderText = "No. BPKB";
            this.NoBPKB.Name = "NoBPKB";
            this.NoBPKB.ReadOnly = true;
            this.NoBPKB.Width = 125;
            // 
            // HargaJadi
            // 
            this.HargaJadi.DataPropertyName = "HargaJadi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.HargaJadi.DefaultCellStyle = dataGridViewCellStyle7;
            this.HargaJadi.HeaderText = "Harga Beli";
            this.HargaJadi.Name = "HargaJadi";
            this.HargaJadi.ReadOnly = true;
            // 
            // HargaOTR
            // 
            this.HargaOTR.DataPropertyName = "HargaOTR";
            this.HargaOTR.HeaderText = "HargaOTR";
            this.HargaOTR.Name = "HargaOTR";
            this.HargaOTR.ReadOnly = true;
            // 
            // Stok
            // 
            this.Stok.DataPropertyName = "Stok";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stok.DefaultCellStyle = dataGridViewCellStyle8;
            this.Stok.HeaderText = "Stok";
            this.Stok.Name = "Stok";
            this.Stok.ReadOnly = true;
            this.Stok.Width = 80;
            // 
            // frmStokMotorBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStokMotorBrowse";
            this.Text = "Stok Motor";
            this.Title = "Stok Motor";
            this.Load += new System.EventHandler(this.frmStokMotorBrowse_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nopol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerkRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoMesin;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRangka;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBPKB;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaJadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaOTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stok;
    }
}