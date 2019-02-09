namespace ISA.Showroom.Laporan
{
    partial class frmLapPiutangSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapPiutangSaldo));
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdclose = new ISA.Controls.CommandButton();
            this.txtTglJual = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBayar = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(237, 150);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 7;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdclose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.Image = ((System.Drawing.Image)(resources.GetObject("cmdclose.Image")));
            this.cmdclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdclose.Location = new System.Drawing.Point(393, 150);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(100, 40);
            this.cmdclose.TabIndex = 8;
            this.cmdclose.Text = "CLOSE";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // txtTglJual
            // 
            this.txtTglJual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTglJual.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtTglJual.FromDate = null;
            this.txtTglJual.Location = new System.Drawing.Point(311, 61);
            this.txtTglJual.Name = "txtTglJual";
            this.txtTglJual.Size = new System.Drawing.Size(257, 22);
            this.txtTglJual.TabIndex = 17;
            this.txtTglJual.ToDate = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Periode Jual";
            // 
            // txtBayar
            // 
            this.txtBayar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBayar.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtBayar.FromDate = null;
            this.txtBayar.Location = new System.Drawing.Point(311, 89);
            this.txtBayar.Name = "txtBayar";
            this.txtBayar.Size = new System.Drawing.Size(257, 22);
            this.txtBayar.TabIndex = 19;
            this.txtBayar.ToDate = null;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Periode Bayar";
            // 
            // frmLapPiutangSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBayar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTglJual);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdclose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLapPiutangSaldo";
            this.Text = "Laporan Penjualan Kredit Bersaldo";
            this.Title = "Laporan Penjualan Kredit Bersaldo";
            this.Load += new System.EventHandler(this.frmLapPiutangSaldo_Load);
            this.Controls.SetChildIndex(this.cmdclose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.txtTglJual, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBayar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdclose;
        private ISA.Controls.RangeDateBox txtTglJual;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox txtBayar;
        private System.Windows.Forms.Label label2;
    }
}