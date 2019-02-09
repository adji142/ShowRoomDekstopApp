namespace ISA.Showroom.Finance.Administrasi
{
    partial class frmPindahPerusahaan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPindahPerusahaan));
            this.cmdYES = new ISA.Controls.CommandButton();
            this.cmdCANCEL = new ISA.Controls.CommandButton();
            this.dataGridView = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitPerusahaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdYES
            // 
            this.cmdYES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYES.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(31, 293);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 5;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // cmdCANCEL
            // 
            this.cmdCANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCANCEL.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCANCEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("cmdCANCEL.Image")));
            this.cmdCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCANCEL.Location = new System.Drawing.Point(611, 293);
            this.cmdCANCEL.Name = "cmdCANCEL";
            this.cmdCANCEL.Size = new System.Drawing.Size(100, 40);
            this.cmdCANCEL.TabIndex = 6;
            this.cmdCANCEL.Text = "CANCEL";
            this.cmdCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCANCEL.UseVisualStyleBackColor = true;
            this.cmdCANCEL.Click += new System.EventHandler(this.cmdCANCEL_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.InitPerusahaan,
            this.Nama,
            this.InitCabang,
            this.InitGudang,
            this.Alamat});
            this.dataGridView.Location = new System.Drawing.Point(63, 50);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(603, 229);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // InitPerusahaan
            // 
            this.InitPerusahaan.DataPropertyName = "InitPerusahaan";
            this.InitPerusahaan.HeaderText = "Initial";
            this.InitPerusahaan.Name = "InitPerusahaan";
            this.InitPerusahaan.ReadOnly = true;
            this.InitPerusahaan.Width = 75;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Perusahaan";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 200;
            // 
            // InitCabang
            // 
            this.InitCabang.DataPropertyName = "InitCabang";
            this.InitCabang.HeaderText = "Cabang";
            this.InitCabang.Name = "InitCabang";
            this.InitCabang.ReadOnly = true;
            this.InitCabang.Width = 50;
            // 
            // InitGudang
            // 
            this.InitGudang.DataPropertyName = "InitGudang";
            this.InitGudang.HeaderText = "Gudang";
            this.InitGudang.Name = "InitGudang";
            this.InitGudang.ReadOnly = true;
            this.InitGudang.Width = 50;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat Perusahaan ";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.Width = 200;
            // 
            // frmPindahPerusahaan
            // 
            this.AcceptButton = this.cmdYES;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.cmdCANCEL;
            this.ClientSize = new System.Drawing.Size(723, 345);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.cmdCANCEL);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPindahPerusahaan";
            this.Text = "Pindah Perusahaan";
            this.Title = "Pindah Perusahaan";
            this.Load += new System.EventHandler(this.frmPindahPerusahaan_Load);
            this.Controls.SetChildIndex(this.cmdCANCEL, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.dataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdYES;
        private ISA.Controls.CommandButton cmdCANCEL;
        private ISA.Controls.CustomGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitPerusahaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
    }
}
