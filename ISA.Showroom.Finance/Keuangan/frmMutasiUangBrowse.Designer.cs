namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmMutasiUangBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMutasiUangBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rgTglMts = new ISA.Controls.RangeDateBox();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalRk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatailDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(364, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rgTglMts
            // 
            this.rgTglMts.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgTglMts.FromDate = null;
            this.rgTglMts.Location = new System.Drawing.Point(85, 67);
            this.rgTglMts.Name = "rgTglMts";
            this.rgTglMts.Size = new System.Drawing.Size(257, 22);
            this.rgTglMts.TabIndex = 30;
            this.rgTglMts.ToDate = null;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(30, 70);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(50, 14);
            this.lblTanggal.TabIndex = 29;
            this.lblTanggal.Text = "Tanggal";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(575, 287);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 28;
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
            this.cmdDELETE.Location = new System.Drawing.Point(273, 287);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 27;
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
            this.cmdEDIT.Location = new System.Drawing.Point(149, 287);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 26;
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
            this.cmdADD.Location = new System.Drawing.Point(26, 287);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 25;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NoBukti,
            this.Tanggal,
            this.TanggalRk,
            this.Dari,
            this.DatailDari,
            this.MataUangDari,
            this.Uraian,
            this.Nominal,
            this.Ke,
            this.DetailKe,
            this.MataUangKe,
            this.NominalKe,
            this.Kurs});
            this.dataGridView1.Location = new System.Drawing.Point(33, 96);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(649, 164);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 32;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No. Bukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal Input";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 80;
            // 
            // TanggalRk
            // 
            this.TanggalRk.DataPropertyName = "TanggalRk";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.TanggalRk.DefaultCellStyle = dataGridViewCellStyle2;
            this.TanggalRk.HeaderText = "Tanggal Rk";
            this.TanggalRk.Name = "TanggalRk";
            this.TanggalRk.ReadOnly = true;
            // 
            // Dari
            // 
            this.Dari.DataPropertyName = "KetJnsPengeluaran";
            this.Dari.HeaderText = "Dari";
            this.Dari.Name = "Dari";
            this.Dari.ReadOnly = true;
            this.Dari.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Dari.Width = 60;
            // 
            // DatailDari
            // 
            this.DatailDari.DataPropertyName = "DetalDari";
            this.DatailDari.HeaderText = "DetailDari";
            this.DatailDari.Name = "DatailDari";
            this.DatailDari.ReadOnly = true;
            // 
            // MataUangDari
            // 
            this.MataUangDari.DataPropertyName = "MataUangIDDari";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MataUangDari.DefaultCellStyle = dataGridViewCellStyle3;
            this.MataUangDari.HeaderText = "Mata Uang";
            this.MataUangDari.Name = "MataUangDari";
            this.MataUangDari.ReadOnly = true;
            this.MataUangDari.Width = 60;
            // 
            // Uraian
            // 
            this.Uraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 66;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "NominalDari";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle4;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            this.Nominal.Width = 120;
            // 
            // Ke
            // 
            this.Ke.DataPropertyName = "KetJnsPenerimaan";
            this.Ke.HeaderText = "Ke";
            this.Ke.Name = "Ke";
            this.Ke.ReadOnly = true;
            this.Ke.Width = 60;
            // 
            // DetailKe
            // 
            this.DetailKe.DataPropertyName = "DetailKe";
            this.DetailKe.HeaderText = "DetailKe";
            this.DetailKe.Name = "DetailKe";
            this.DetailKe.ReadOnly = true;
            // 
            // MataUangKe
            // 
            this.MataUangKe.DataPropertyName = "MataUangIDKe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MataUangKe.DefaultCellStyle = dataGridViewCellStyle5;
            this.MataUangKe.HeaderText = "Mata Uang";
            this.MataUangKe.Name = "MataUangKe";
            this.MataUangKe.ReadOnly = true;
            this.MataUangKe.Width = 60;
            // 
            // NominalKe
            // 
            this.NominalKe.DataPropertyName = "NominalKe";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.NominalKe.DefaultCellStyle = dataGridViewCellStyle6;
            this.NominalKe.HeaderText = "Nominal";
            this.NominalKe.Name = "NominalKe";
            this.NominalKe.ReadOnly = true;
            this.NominalKe.Width = 120;
            // 
            // Kurs
            // 
            this.Kurs.DataPropertyName = "Kurs";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0.00";
            dataGridViewCellStyle7.NullValue = null;
            this.Kurs.DefaultCellStyle = dataGridViewCellStyle7;
            this.Kurs.HeaderText = "Kurs";
            this.Kurs.Name = "Kurs";
            this.Kurs.ReadOnly = true;
            this.Kurs.Visible = false;
            // 
            // frmMutasiUangBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(703, 339);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rgTglMts);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMutasiUangBrowse";
            this.Text = "Mutasi Uang";
            this.Title = "Mutasi Uang";
            this.Load += new System.EventHandler(this.frmPengeluaranUangAcc_Load);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblTanggal, 0);
            this.Controls.SetChildIndex(this.rgTglMts, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private ISA.Controls.RangeDateBox rgTglMts;
        private System.Windows.Forms.Label lblTanggal;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalRk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dari;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatailDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ke;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kurs;

    }
}
