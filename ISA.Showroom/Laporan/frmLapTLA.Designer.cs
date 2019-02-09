namespace ISA.Showroom.Laporan
{
    partial class frmLapTLA
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cbLaporan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTahun = new ISA.Controls.NumericTextBox();
            this.lblTahun = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Image = global::ISA.Showroom.Properties.Resources.Close321;
            this.cmdClose.Location = new System.Drawing.Point(486, 200);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(93, 46);
            this.cmdClose.TabIndex = 16;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.Image = global::ISA.Showroom.Properties.Resources.Printer32;
            this.cmdPrint.Location = new System.Drawing.Point(31, 200);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(85, 46);
            this.cmdPrint.TabIndex = 15;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cbLaporan
            // 
            this.cbLaporan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLaporan.FormattingEnabled = true;
            this.cbLaporan.Items.AddRange(new object[] {
            "Penjualan Salesman",
            "Penjualan Tahunan - Per Tipe",
            "Penjualan Tahunan - Per Kecamatan"});
            this.cbLaporan.Location = new System.Drawing.Point(299, 88);
            this.cbLaporan.Name = "cbLaporan";
            this.cbLaporan.Size = new System.Drawing.Size(221, 22);
            this.cbLaporan.TabIndex = 14;
            this.cbLaporan.SelectedIndexChanged += new System.EventHandler(this.cbLaporan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Laporan";
            // 
            // txtTahun
            // 
            this.txtTahun.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTahun.Format = "0000";
            this.txtTahun.Location = new System.Drawing.Point(299, 152);
            this.txtTahun.Name = "txtTahun";
            this.txtTahun.Size = new System.Drawing.Size(44, 20);
            this.txtTahun.TabIndex = 12;
            this.txtTahun.Text = "0000";
            this.txtTahun.Leave += new System.EventHandler(this.txtTahun_Leave);
            // 
            // lblTahun
            // 
            this.lblTahun.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTahun.AutoSize = true;
            this.lblTahun.Location = new System.Drawing.Point(166, 155);
            this.lblTahun.Name = "lblTahun";
            this.lblTahun.Size = new System.Drawing.Size(40, 14);
            this.lblTahun.TabIndex = 11;
            this.lblTahun.Text = "Tahun";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(263, 121);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 18;
            this.rangeDateBox1.ToDate = null;
            // 
            // lblPeriode
            // 
            this.lblPeriode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPeriode.AutoSize = true;
            this.lblPeriode.Location = new System.Drawing.Point(166, 123);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(50, 14);
            this.lblPeriode.TabIndex = 17;
            this.lblPeriode.Text = "Periode";
            // 
            // frmLapTLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 267);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.lblPeriode);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cbLaporan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTahun);
            this.Controls.Add(this.lblTahun);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLapTLA";
            this.Text = "Laporan Penjualan TLA";
            this.Title = "Laporan Penjualan TLA";
            this.Load += new System.EventHandler(this.frmLapTLA_Load);
            this.Controls.SetChildIndex(this.lblTahun, 0);
            this.Controls.SetChildIndex(this.txtTahun, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbLaporan, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lblPeriode, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.ComboBox cbLaporan;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.NumericTextBox txtTahun;
        private System.Windows.Forms.Label lblTahun;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label lblPeriode;
    }
}