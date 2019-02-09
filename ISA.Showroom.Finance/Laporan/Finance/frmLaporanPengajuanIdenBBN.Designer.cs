namespace ISA.Showroom.Finance.Laporan.Finance
{
    partial class frmLaporanPengajuanIdenBBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanPengajuanIdenBBN));
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.rbrekap = new System.Windows.Forms.RadioButton();
            this.rbdetail = new System.Windows.Forms.RadioButton();
            this.cmdtampil = new ISA.Controls.CommandButton();
            this.cmdclose = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(219, 69);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // rbrekap
            // 
            this.rbrekap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbrekap.AutoSize = true;
            this.rbrekap.Location = new System.Drawing.Point(255, 116);
            this.rbrekap.Name = "rbrekap";
            this.rbrekap.Size = new System.Drawing.Size(59, 18);
            this.rbrekap.TabIndex = 6;
            this.rbrekap.TabStop = true;
            this.rbrekap.Text = "Rekap";
            this.rbrekap.UseVisualStyleBackColor = true;
            // 
            // rbdetail
            // 
            this.rbdetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbdetail.AutoSize = true;
            this.rbdetail.Location = new System.Drawing.Point(400, 116);
            this.rbdetail.Name = "rbdetail";
            this.rbdetail.Size = new System.Drawing.Size(55, 18);
            this.rbdetail.TabIndex = 7;
            this.rbdetail.TabStop = true;
            this.rbdetail.Text = "Detail";
            this.rbdetail.UseVisualStyleBackColor = true;
            // 
            // cmdtampil
            // 
            this.cmdtampil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdtampil.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdtampil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdtampil.Image = ((System.Drawing.Image)(resources.GetObject("cmdtampil.Image")));
            this.cmdtampil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdtampil.Location = new System.Drawing.Point(230, 165);
            this.cmdtampil.Name = "cmdtampil";
            this.cmdtampil.Size = new System.Drawing.Size(100, 40);
            this.cmdtampil.TabIndex = 8;
            this.cmdtampil.Text = "YES";
            this.cmdtampil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdtampil.UseVisualStyleBackColor = true;
            this.cmdtampil.Click += new System.EventHandler(this.cmdtampil_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdclose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.Image = ((System.Drawing.Image)(resources.GetObject("cmdclose.Image")));
            this.cmdclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdclose.Location = new System.Drawing.Point(376, 165);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(100, 40);
            this.cmdclose.TabIndex = 9;
            this.cmdclose.Text = "CLOSE";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // frmLaporanPengajuanIdenBBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.rbrekap);
            this.Controls.Add(this.rbdetail);
            this.Controls.Add(this.cmdclose);
            this.Controls.Add(this.cmdtampil);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanPengajuanIdenBBN";
            this.Text = "Laporan Pengajuan Iden BBN";
            this.Title = "Laporan Pengajuan Iden BBN";
            this.Load += new System.EventHandler(this.frmLaporanPengajuanIdenBBN_Load);
            this.Controls.SetChildIndex(this.cmdtampil, 0);
            this.Controls.SetChildIndex(this.cmdclose, 0);
            this.Controls.SetChildIndex(this.rbdetail, 0);
            this.Controls.SetChildIndex(this.rbrekap, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.RadioButton rbrekap;
        private System.Windows.Forms.RadioButton rbdetail;
        private ISA.Controls.CommandButton cmdtampil;
        private ISA.Controls.CommandButton cmdclose;

    }
}