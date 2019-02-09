namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmPenerimaanMutasiDKN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanMutasiDKN));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.Tanggal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipeNota1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsalCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsalPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangTujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTTujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldoaa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KelompokTransaksi1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(26, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(936, 223);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GVHeader);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(928, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pengeluaran Uang Lain Lain";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal1,
            this.RowID4,
            this.NoBukti2,
            this.TipeNota1,
            this.AsalCabang,
            this.AsalPT,
            this.Src1,
            this.CabangTujuan,
            this.PTTujuan,
            this.Nominal3,
            this.Column2,
            this.Saldoaa,
            this.KelompokTransaksi1});
            this.GVHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeader.EnableHeadersVisualStyles = false;
            this.GVHeader.Location = new System.Drawing.Point(3, 3);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GVHeader.RowHeadersWidth = 20;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(922, 190);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 16;
            this.GVHeader.DoubleClick += new System.EventHandler(this.GVHeader_DoubleClick);
            this.GVHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GVHeader_KeyDown_1);
            // 
            // Tanggal1
            // 
            this.Tanggal1.DataPropertyName = "Tanggal";
            dataGridViewCellStyle5.Format = "dd-MM-yyyy";
            this.Tanggal1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tanggal1.HeaderText = "Tanggal";
            this.Tanggal1.Name = "Tanggal1";
            this.Tanggal1.ReadOnly = true;
            // 
            // RowID4
            // 
            this.RowID4.DataPropertyName = "RowID";
            this.RowID4.HeaderText = "RowID4";
            this.RowID4.Name = "RowID4";
            this.RowID4.ReadOnly = true;
            this.RowID4.Visible = false;
            // 
            // NoBukti2
            // 
            this.NoBukti2.DataPropertyName = "NoBukti";
            this.NoBukti2.HeaderText = "NoBukti";
            this.NoBukti2.Name = "NoBukti2";
            this.NoBukti2.ReadOnly = true;
            // 
            // TipeNota1
            // 
            this.TipeNota1.DataPropertyName = "CTipeNota";
            this.TipeNota1.HeaderText = "TipeNota";
            this.TipeNota1.Name = "TipeNota1";
            this.TipeNota1.ReadOnly = true;
            // 
            // AsalCabang
            // 
            this.AsalCabang.DataPropertyName = "CabangKeID";
            this.AsalCabang.HeaderText = "AsalCabang";
            this.AsalCabang.Name = "AsalCabang";
            this.AsalCabang.ReadOnly = true;
            // 
            // AsalPT
            // 
            this.AsalPT.DataPropertyName = "InitPT";
            this.AsalPT.HeaderText = "AsalPT";
            this.AsalPT.Name = "AsalPT";
            this.AsalPT.ReadOnly = true;
            // 
            // Src1
            // 
            this.Src1.DataPropertyName = "Src";
            this.Src1.HeaderText = "Src";
            this.Src1.Name = "Src1";
            this.Src1.ReadOnly = true;
            // 
            // CabangTujuan
            // 
            this.CabangTujuan.DataPropertyName = "BranchTo";
            this.CabangTujuan.HeaderText = "CabangTujuan";
            this.CabangTujuan.MinimumWidth = 100;
            this.CabangTujuan.Name = "CabangTujuan";
            this.CabangTujuan.ReadOnly = true;
            // 
            // PTTujuan
            // 
            this.PTTujuan.DataPropertyName = "DestinyPT";
            this.PTTujuan.HeaderText = "PT Tujuan";
            this.PTTujuan.MinimumWidth = 150;
            this.PTTujuan.Name = "PTTujuan";
            this.PTTujuan.ReadOnly = true;
            this.PTTujuan.Width = 150;
            // 
            // Nominal3
            // 
            this.Nominal3.DataPropertyName = "Nominal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.Nominal3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Nominal3.HeaderText = "Nominal";
            this.Nominal3.MinimumWidth = 150;
            this.Nominal3.Name = "Nominal3";
            this.Nominal3.ReadOnly = true;
            this.Nominal3.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RpKredit";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Pembayaran";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Saldoaa
            // 
            this.Saldoaa.DataPropertyName = "Saldo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Saldoaa.DefaultCellStyle = dataGridViewCellStyle8;
            this.Saldoaa.HeaderText = "Saldo";
            this.Saldoaa.Name = "Saldoaa";
            this.Saldoaa.ReadOnly = true;
            // 
            // KelompokTransaksi1
            // 
            this.KelompokTransaksi1.DataPropertyName = "KelompokTransaksi";
            this.KelompokTransaksi1.HeaderText = "Klp. Trans.";
            this.KelompokTransaksi1.Name = "KelompokTransaksi1";
            this.KelompokTransaksi1.ReadOnly = true;
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(862, 298);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 7;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(756, 298);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 6;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmPenerimaanMutasiDKN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(970, 341);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPenerimaanMutasiDKN";
            this.Text = "Mutasi PLL";
            this.Title = "Mutasi PLL";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmMutasiPenerimaanPLL_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ISA.Controls.CustomGridView GVHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID4;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipeNota1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsalCabang;
        private System.Windows.Forms.DataGridViewTextBoxColumn AsalPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangTujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTTujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldoaa;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelompokTransaksi1;
    }
}
