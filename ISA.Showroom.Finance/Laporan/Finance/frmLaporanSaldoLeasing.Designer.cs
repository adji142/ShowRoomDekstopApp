namespace ISA.Showroom.Finance.Laporan.Finance
{
    partial class frmLaporanSaldoLeasing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanSaldoLeasing));
            this.rdTanggal = new ISA.Controls.RangeDateBox();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.lbl_Leasing = new System.Windows.Forms.Label();
            this.cb_Leasing = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdTanggal
            // 
            this.rdTanggal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdTanggal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdTanggal.FromDate = null;
            this.rdTanggal.Location = new System.Drawing.Point(143, 61);
            this.rdTanggal.Name = "rdTanggal";
            this.rdTanggal.Size = new System.Drawing.Size(257, 22);
            this.rdTanggal.TabIndex = 5;
            this.rdTanggal.ToDate = null;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(12, 190);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(317, 190);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lbl_Leasing
            // 
            this.lbl_Leasing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Leasing.AutoSize = true;
            this.lbl_Leasing.Location = new System.Drawing.Point(61, 110);
            this.lbl_Leasing.Name = "lbl_Leasing";
            this.lbl_Leasing.Size = new System.Drawing.Size(51, 14);
            this.lbl_Leasing.TabIndex = 23;
            this.lbl_Leasing.Text = "Leasing";
            // 
            // cb_Leasing
            // 
            this.cb_Leasing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cb_Leasing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Leasing.FormattingEnabled = true;
            this.cb_Leasing.Location = new System.Drawing.Point(180, 107);
            this.cb_Leasing.Name = "cb_Leasing";
            this.cb_Leasing.Size = new System.Drawing.Size(129, 22);
            this.cb_Leasing.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tanggal Jual";
            // 
            // frmLaporanSaldoLeasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Leasing);
            this.Controls.Add(this.cb_Leasing);
            this.Controls.Add(this.rdTanggal);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanSaldoLeasing";
            this.Text = "Laporan Tagihan Leasing";
            this.Title = "Laporan Tagihan Leasing";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLaporanSaldoLeasing_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.rdTanggal, 0);
            this.Controls.SetChildIndex(this.cb_Leasing, 0);
            this.Controls.SetChildIndex(this.lbl_Leasing, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rdTanggal;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label lbl_Leasing;
        private System.Windows.Forms.ComboBox cb_Leasing;
        private System.Windows.Forms.Label label1;
    }
}