namespace ISA.Showroom.Laporan
{
    partial class FrmLapLeasing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLapLeasing));
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.CMDTampil = new ISA.Controls.CommandButton();
            this.cboStatusLunas = new System.Windows.Forms.ComboBox();
            this.CMdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(224, 61);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(238, 22);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // CMDTampil
            // 
            this.CMDTampil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CMDTampil.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.CMDTampil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CMDTampil.Image = ((System.Drawing.Image)(resources.GetObject("CMDTampil.Image")));
            this.CMDTampil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMDTampil.Location = new System.Drawing.Point(200, 140);
            this.CMDTampil.Name = "CMDTampil";
            this.CMDTampil.Size = new System.Drawing.Size(100, 40);
            this.CMDTampil.TabIndex = 6;
            this.CMDTampil.Text = "SAVE";
            this.CMDTampil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CMDTampil.UseVisualStyleBackColor = true;
            this.CMDTampil.Click += new System.EventHandler(this.CMDTampil_Click);
            // 
            // cboStatusLunas
            // 
            this.cboStatusLunas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboStatusLunas.FormattingEnabled = true;
            this.cboStatusLunas.Items.AddRange(new object[] {
            "Semua",
            "Lunas",
            "Belum Lunas"});
            this.cboStatusLunas.Location = new System.Drawing.Point(260, 96);
            this.cboStatusLunas.Name = "cboStatusLunas";
            this.cboStatusLunas.Size = new System.Drawing.Size(202, 22);
            this.cboStatusLunas.TabIndex = 7;
            // 
            // CMdClose
            // 
            this.CMdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CMdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.CMdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CMdClose.Image = ((System.Drawing.Image)(resources.GetObject("CMdClose.Image")));
            this.CMdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CMdClose.Location = new System.Drawing.Point(329, 140);
            this.CMdClose.Name = "CMdClose";
            this.CMdClose.Size = new System.Drawing.Size(100, 40);
            this.CMdClose.TabIndex = 8;
            this.CMdClose.Text = "CLOSE";
            this.CMdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CMdClose.UseVisualStyleBackColor = true;
            this.CMdClose.Click += new System.EventHandler(this.CMdClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Status Lunas";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Penjualan";
            // 
            // FrmLapLeasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 288);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMdClose);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.CMDTampil);
            this.Controls.Add(this.cboStatusLunas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmLapLeasing";
            this.Text = "LAPORAN PENJUALAN LEASING";
            this.Title = "LAPORAN PENJUALAN LEASING";
            this.Load += new System.EventHandler(this.FrmLapLeasing_Load);
            this.Controls.SetChildIndex(this.cboStatusLunas, 0);
            this.Controls.SetChildIndex(this.CMDTampil, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.CMdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton CMDTampil;
        private System.Windows.Forms.ComboBox cboStatusLunas;
        private ISA.Controls.CommandButton CMdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}