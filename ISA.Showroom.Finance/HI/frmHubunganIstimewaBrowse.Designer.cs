namespace ISA.Showroom.Finance.HI
{
    partial class frmHubunganIstimewaBrowse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHubunganIstimewaBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeTanggal = new ISA.Controls.RangeDateBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridHI = new ISA.Controls.CustomGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridDetil = new ISA.Controls.CustomGridView();
            this.RowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UraianTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referensi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.RowIDHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h_Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipeNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabangKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KelompokTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHI)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetil)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal";
            // 
            // rangeTanggal
            // 
            this.rangeTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTanggal.FromDate = null;
            this.rangeTanggal.Location = new System.Drawing.Point(105, 61);
            this.rangeTanggal.Name = "rangeTanggal";
            this.rangeTanggal.Size = new System.Drawing.Size(257, 22);
            this.rangeTanggal.TabIndex = 6;
            this.rangeTanggal.ToDate = null;
            this.rangeTanggal.Load += new System.EventHandler(this.rangeTanggal_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridHI
            // 
            this.dataGridHI.AllowUserToAddRows = false;
            this.dataGridHI.AllowUserToDeleteRows = false;
            this.dataGridHI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDHeader,
            this.Tanggal,
            this.NoBukti,
            this.h_Nominal,
            this.TipeNota,
            this.CabangDari,
            this.CabangKe,
            this.KelompokTransaksi});
            this.dataGridHI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHI.EnableHeadersVisualStyles = false;
            this.dataGridHI.Location = new System.Drawing.Point(3, 3);
            this.dataGridHI.MultiSelect = false;
            this.dataGridHI.Name = "dataGridHI";
            this.dataGridHI.ReadOnly = true;
            this.dataGridHI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridHI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridHI.Size = new System.Drawing.Size(701, 154);
            this.dataGridHI.StandardTab = true;
            this.dataGridHI.TabIndex = 8;
            this.dataGridHI.SelectionChanged += new System.EventHandler(this.dataGridHI_SelectionChanged);
            this.dataGridHI.Click += new System.EventHandler(this.dataGridHI_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridHI, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridDetil, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 288);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // dataGridDetil
            // 
            this.dataGridDetil.AllowUserToAddRows = false;
            this.dataGridDetil.AllowUserToDeleteRows = false;
            this.dataGridDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDDetail,
            this.UraianTransaksi,
            this.Nominal,
            this.Referensi});
            this.dataGridDetil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDetil.Location = new System.Drawing.Point(3, 163);
            this.dataGridDetil.MultiSelect = false;
            this.dataGridDetil.Name = "dataGridDetil";
            this.dataGridDetil.ReadOnly = true;
            this.dataGridDetil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDetil.Size = new System.Drawing.Size(701, 122);
            this.dataGridDetil.StandardTab = true;
            this.dataGridDetil.TabIndex = 9;
            this.dataGridDetil.Click += new System.EventHandler(this.dataGridDetil_Click);
            // 
            // RowIDDetail
            // 
            this.RowIDDetail.DataPropertyName = "RowID";
            this.RowIDDetail.HeaderText = "RowID";
            this.RowIDDetail.Name = "RowIDDetail";
            this.RowIDDetail.ReadOnly = true;
            this.RowIDDetail.Visible = false;
            // 
            // UraianTransaksi
            // 
            this.UraianTransaksi.DataPropertyName = "Uraian";
            this.UraianTransaksi.HeaderText = "Uraian Transaksi";
            this.UraianTransaksi.Name = "UraianTransaksi";
            this.UraianTransaksi.ReadOnly = true;
            this.UraianTransaksi.Width = 250;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // Referensi
            // 
            this.Referensi.DataPropertyName = "Referensi";
            this.Referensi.HeaderText = "Referensi";
            this.Referensi.Name = "Referensi";
            this.Referensi.ReadOnly = true;
            this.Referensi.Width = 250;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(532, 386);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 14;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(246, 388);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 13;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(638, 385);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 10;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(140, 387);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 12;
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
            this.cmdADD.Location = new System.Drawing.Point(34, 386);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 11;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // RowIDHeader
            // 
            this.RowIDHeader.DataPropertyName = "RowID";
            this.RowIDHeader.HeaderText = "RowID";
            this.RowIDHeader.Name = "RowIDHeader";
            this.RowIDHeader.ReadOnly = true;
            this.RowIDHeader.Visible = false;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No.Bukti DKN";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            this.NoBukti.Width = 125;
            // 
            // h_Nominal
            // 
            this.h_Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.h_Nominal.DefaultCellStyle = dataGridViewCellStyle1;
            this.h_Nominal.HeaderText = "Nominal";
            this.h_Nominal.Name = "h_Nominal";
            this.h_Nominal.ReadOnly = true;
            this.h_Nominal.Width = 120;
            // 
            // TipeNota
            // 
            this.TipeNota.DataPropertyName = "CTipeNota";
            this.TipeNota.HeaderText = "Tipe ";
            this.TipeNota.Name = "TipeNota";
            this.TipeNota.ReadOnly = true;
            // 
            // CabangDari
            // 
            this.CabangDari.DataPropertyName = "CabangDariID";
            this.CabangDari.HeaderText = "Dari Cabang ";
            this.CabangDari.Name = "CabangDari";
            this.CabangDari.ReadOnly = true;
            // 
            // CabangKe
            // 
            this.CabangKe.DataPropertyName = "CabangKeID";
            this.CabangKe.HeaderText = "Ke Cabang";
            this.CabangKe.Name = "CabangKe";
            this.CabangKe.ReadOnly = true;
            // 
            // KelompokTransaksi
            // 
            this.KelompokTransaksi.DataPropertyName = "KelompokTransaksi";
            this.KelompokTransaksi.HeaderText = "Kelompok Transaksi";
            this.KelompokTransaksi.Name = "KelompokTransaksi";
            this.KelompokTransaksi.ReadOnly = true;
            this.KelompokTransaksi.Width = 250;
            // 
            // frmHubunganIstimewaBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(764, 433);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rangeTanggal);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHubunganIstimewaBrowse";
            this.Text = "Hubungan Istimewa";
            this.Title = "Hubungan Istimewa";
            this.Load += new System.EventHandler(this.frmHubunganIstimewaBrowse_Load);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.rangeTanggal, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHI)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeTanggal;
        private System.Windows.Forms.Button button1;
        private ISA.Controls.CustomGridView dataGridHI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView dataGridDetil;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdDELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn UraianTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referensi;
        private ISA.Controls.CommandButton cmdPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn h_Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipeNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabangKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn KelompokTransaksi;
    }
}
