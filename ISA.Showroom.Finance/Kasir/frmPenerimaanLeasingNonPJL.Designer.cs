namespace ISA.Showroom.Finance.Kasir
{
    partial class frmPenerimaanLeasingNonPJL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanLeasingNonPJL));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NoPembayaran = new System.Windows.Forms.TextBox();
            this.txt_Tanggal = new ISA.Controls.DateTextBox();
            this.txt_Nominal = new ISA.Controls.NumericTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Saldo = new ISA.Controls.NumericTextBox();
            this.txt_Leasing = new ISA.Controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GV_NonPNJ = new ISA.Controls.CustomGridView();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksiRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_NonPNJ)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "No Pembayaran";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tanggal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nominal";
            // 
            // txt_NoPembayaran
            // 
            this.txt_NoPembayaran.Enabled = false;
            this.txt_NoPembayaran.Location = new System.Drawing.Point(110, 8);
            this.txt_NoPembayaran.Name = "txt_NoPembayaran";
            this.txt_NoPembayaran.ReadOnly = true;
            this.txt_NoPembayaran.Size = new System.Drawing.Size(123, 20);
            this.txt_NoPembayaran.TabIndex = 8;
            // 
            // txt_Tanggal
            // 
            this.txt_Tanggal.DateValue = null;
            this.txt_Tanggal.Enabled = false;
            this.txt_Tanggal.Location = new System.Drawing.Point(110, 33);
            this.txt_Tanggal.MaxLength = 10;
            this.txt_Tanggal.Name = "txt_Tanggal";
            this.txt_Tanggal.ReadOnly = true;
            this.txt_Tanggal.Size = new System.Drawing.Size(123, 20);
            this.txt_Tanggal.TabIndex = 9;
            // 
            // txt_Nominal
            // 
            this.txt_Nominal.Enabled = false;
            this.txt_Nominal.Location = new System.Drawing.Point(110, 58);
            this.txt_Nominal.Name = "txt_Nominal";
            this.txt_Nominal.ReadOnly = true;
            this.txt_Nominal.Size = new System.Drawing.Size(123, 20);
            this.txt_Nominal.TabIndex = 10;
            this.txt_Nominal.Text = "0";
            this.txt_Nominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(26, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GV_NonPNJ);
            this.splitContainer1.Size = new System.Drawing.Size(801, 204);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Saldo);
            this.panel1.Controls.Add(this.txt_Leasing);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_Tanggal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_Nominal);
            this.panel1.Controls.Add(this.txt_NoPembayaran);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 121);
            this.panel1.TabIndex = 0;
            // 
            // txt_Saldo
            // 
            this.txt_Saldo.Enabled = false;
            this.txt_Saldo.Location = new System.Drawing.Point(390, 33);
            this.txt_Saldo.Name = "txt_Saldo";
            this.txt_Saldo.ReadOnly = true;
            this.txt_Saldo.Size = new System.Drawing.Size(126, 20);
            this.txt_Saldo.TabIndex = 14;
            this.txt_Saldo.Text = "0";
            this.txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Leasing
            // 
            this.txt_Leasing.Enabled = false;
            this.txt_Leasing.Location = new System.Drawing.Point(390, 8);
            this.txt_Leasing.Name = "txt_Leasing";
            this.txt_Leasing.ReadOnly = true;
            this.txt_Leasing.Size = new System.Drawing.Size(126, 20);
            this.txt_Leasing.TabIndex = 13;
            this.txt_Leasing.Text = "0";
            this.txt_Leasing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Saldo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Leasing";
            // 
            // GV_NonPNJ
            // 
            this.GV_NonPNJ.AllowUserToAddRows = false;
            this.GV_NonPNJ.AllowUserToDeleteRows = false;
            this.GV_NonPNJ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GV_NonPNJ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GV_NonPNJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_NonPNJ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoBukti,
            this.TglIden,
            this.JenisTransaksi,
            this.MataUang,
            this.NominalIden,
            this.Uraian,
            this.JenisTransaksiRowID,
            this.MataUangRowID});
            this.GV_NonPNJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GV_NonPNJ.Location = new System.Drawing.Point(0, 0);
            this.GV_NonPNJ.Name = "GV_NonPNJ";
            this.GV_NonPNJ.ReadOnly = true;
            this.GV_NonPNJ.RowHeadersVisible = false;
            this.GV_NonPNJ.Size = new System.Drawing.Size(801, 79);
            this.GV_NonPNJ.StandardTab = true;
            this.GV_NonPNJ.TabIndex = 0;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 74;
            // 
            // TglIden
            // 
            this.TglIden.DataPropertyName = "TglIden";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglIden.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglIden.HeaderText = "TglIden";
            this.TglIden.Name = "TglIden";
            this.TglIden.ReadOnly = true;
            this.TglIden.Width = 73;
            // 
            // JenisTransaksi
            // 
            this.JenisTransaksi.DataPropertyName = "JenisTransaksi";
            this.JenisTransaksi.HeaderText = "JenisTransaksi";
            this.JenisTransaksi.Name = "JenisTransaksi";
            this.JenisTransaksi.ReadOnly = true;
            this.JenisTransaksi.Width = 116;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUang";
            this.MataUang.HeaderText = "MataUang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            this.MataUang.Width = 85;
            // 
            // NominalIden
            // 
            this.NominalIden.DataPropertyName = "NominalIden";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.NominalIden.DefaultCellStyle = dataGridViewCellStyle2;
            this.NominalIden.HeaderText = "NominalIden";
            this.NominalIden.Name = "NominalIden";
            this.NominalIden.ReadOnly = true;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 66;
            // 
            // JenisTransaksiRowID
            // 
            this.JenisTransaksiRowID.DataPropertyName = "JenisTransaksiRowID";
            this.JenisTransaksiRowID.HeaderText = "JenisTransaksiRowID";
            this.JenisTransaksiRowID.Name = "JenisTransaksiRowID";
            this.JenisTransaksiRowID.ReadOnly = true;
            this.JenisTransaksiRowID.Visible = false;
            this.JenisTransaksiRowID.Width = 150;
            // 
            // MataUangRowID
            // 
            this.MataUangRowID.DataPropertyName = "MataUangRowID";
            this.MataUangRowID.HeaderText = "MataUangRowID";
            this.MataUangRowID.Name = "MataUangRowID";
            this.MataUangRowID.ReadOnly = true;
            this.MataUangRowID.Visible = false;
            this.MataUangRowID.Width = 119;
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(34, 266);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 12;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(714, 266);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 13;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // frmPenerimaanLeasingNonPJL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 317);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenerimaanLeasingNonPJL";
            this.Text = "IDENTIFIKASI PENERIMAAN LEASING NON PENJUALAN";
            this.Title = "IDENTIFIKASI PENERIMAAN LEASING NON PENJUALAN";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPenerimaanLeasingNonPJL_Load);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_NonPNJ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NoPembayaran;
        private ISA.Controls.DateTextBox txt_Tanggal;
        private ISA.Controls.NumericTextBox txt_Nominal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.NumericTextBox txt_Saldo;
        private ISA.Controls.NumericTextBox txt_Leasing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CustomGridView GV_NonPNJ;
        private ISA.Controls.CommandButton cmdSAVE;
        private ISA.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglIden;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalIden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisTransaksiRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangRowID;
    }
}