namespace ISA.Showroom.Laporan
{
    partial class frmLapPiutangOverdue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapPiutangOverdue));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbDetail = new System.Windows.Forms.RadioButton();
            this.rbRekap = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipeLaporan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTglBayarTerakhir = new System.Windows.Forms.RadioButton();
            this.rbTglJual = new System.Windows.Forms.RadioButton();
            this.txtTglJual = new ISA.Controls.RangeDateBox();
            this.txtTglBayarTerakhir = new ISA.Controls.RangeDateBox();
            this.lookUpCustomer1 = new ISA.Showroom.Controls.LookUpCustomer();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdPRINT = new ISA.Controls.CommandButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboTipeLaporan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbTglBayarTerakhir);
            this.panel1.Controls.Add(this.rbTglJual);
            this.panel1.Controls.Add(this.txtTglJual);
            this.panel1.Controls.Add(this.txtTglBayarTerakhir);
            this.panel1.Controls.Add(this.lookUpCustomer1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(45, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 180);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbDetail);
            this.panel2.Controls.Add(this.rbRekap);
            this.panel2.Location = new System.Drawing.Point(208, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 27);
            this.panel2.TabIndex = 21;
            // 
            // rbDetail
            // 
            this.rbDetail.AutoSize = true;
            this.rbDetail.Location = new System.Drawing.Point(6, 4);
            this.rbDetail.Name = "rbDetail";
            this.rbDetail.Size = new System.Drawing.Size(55, 18);
            this.rbDetail.TabIndex = 19;
            this.rbDetail.TabStop = true;
            this.rbDetail.Text = "Detail";
            this.rbDetail.UseVisualStyleBackColor = true;
            // 
            // rbRekap
            // 
            this.rbRekap.AutoSize = true;
            this.rbRekap.Location = new System.Drawing.Point(117, 5);
            this.rbRekap.Name = "rbRekap";
            this.rbRekap.Size = new System.Drawing.Size(59, 18);
            this.rbRekap.TabIndex = 20;
            this.rbRekap.TabStop = true;
            this.rbRekap.Text = "Rekap";
            this.rbRekap.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Jenis";
            // 
            // cboTipeLaporan
            // 
            this.cboTipeLaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipeLaporan.FormattingEnabled = true;
            this.cboTipeLaporan.Items.AddRange(new object[] {
            "Overdue Angsuran",
            "Overdue Uang Muka",
            "Overdue Penjualan Tunai",
            "Overdue"});
            this.cboTipeLaporan.Location = new System.Drawing.Point(208, 105);
            this.cboTipeLaporan.Name = "cboTipeLaporan";
            this.cboTipeLaporan.Size = new System.Drawing.Size(214, 22);
            this.cboTipeLaporan.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tipe Laporan";
            // 
            // rbTglBayarTerakhir
            // 
            this.rbTglBayarTerakhir.AutoSize = true;
            this.rbTglBayarTerakhir.Location = new System.Drawing.Point(45, 48);
            this.rbTglBayarTerakhir.Name = "rbTglBayarTerakhir";
            this.rbTglBayarTerakhir.Size = new System.Drawing.Size(149, 18);
            this.rbTglBayarTerakhir.TabIndex = 15;
            this.rbTglBayarTerakhir.TabStop = true;
            this.rbTglBayarTerakhir.Text = "Tanggal Bayar Terakhir";
            this.rbTglBayarTerakhir.UseVisualStyleBackColor = true;
            this.rbTglBayarTerakhir.CheckedChanged += new System.EventHandler(this.rbTglBayarTerakhir_CheckedChanged);
            // 
            // rbTglJual
            // 
            this.rbTglJual.AutoSize = true;
            this.rbTglJual.Location = new System.Drawing.Point(45, 20);
            this.rbTglJual.Name = "rbTglJual";
            this.rbTglJual.Size = new System.Drawing.Size(123, 18);
            this.rbTglJual.TabIndex = 14;
            this.rbTglJual.TabStop = true;
            this.rbTglJual.Text = "Tanggal Penjualan";
            this.rbTglJual.UseVisualStyleBackColor = true;
            this.rbTglJual.CheckedChanged += new System.EventHandler(this.rbTglJual_CheckedChanged);
            // 
            // txtTglJual
            // 
            this.txtTglJual.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtTglJual.FromDate = null;
            this.txtTglJual.Location = new System.Drawing.Point(199, 19);
            this.txtTglJual.Name = "txtTglJual";
            this.txtTglJual.Size = new System.Drawing.Size(257, 22);
            this.txtTglJual.TabIndex = 13;
            this.txtTglJual.ToDate = null;
            // 
            // txtTglBayarTerakhir
            // 
            this.txtTglBayarTerakhir.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtTglBayarTerakhir.FromDate = null;
            this.txtTglBayarTerakhir.Location = new System.Drawing.Point(199, 47);
            this.txtTglBayarTerakhir.Name = "txtTglBayarTerakhir";
            this.txtTglBayarTerakhir.Size = new System.Drawing.Size(257, 22);
            this.txtTglBayarTerakhir.TabIndex = 12;
            this.txtTglBayarTerakhir.ToDate = null;
            // 
            // lookUpCustomer1
            // 
            this.lookUpCustomer1.Location = new System.Drawing.Point(198, 74);
            this.lookUpCustomer1.Name = "lookUpCustomer1";
            this.lookUpCustomer1.Size = new System.Drawing.Size(234, 25);
            this.lookUpCustomer1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nama Customer";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(330, 277);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 15;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(155, 277);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 14;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // frmLapPiutangOverdue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdPRINT);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLapPiutangOverdue";
            this.Text = "Laporan Piutang Overdue";
            this.Title = "Laporan Piutang Overdue";
            this.Load += new System.EventHandler(this.frmLapPiutangOverdue_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdPRINT;
        private System.Windows.Forms.Panel panel1;
        private ISA.Showroom.Controls.LookUpCustomer lookUpCustomer1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.RangeDateBox txtTglJual;
        private ISA.Controls.RangeDateBox txtTglBayarTerakhir;
        private System.Windows.Forms.RadioButton rbTglJual;
        private System.Windows.Forms.RadioButton rbTglBayarTerakhir;
        private System.Windows.Forms.ComboBox cboTipeLaporan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbRekap;
        private System.Windows.Forms.RadioButton rbDetail;
        private System.Windows.Forms.Panel panel2;
    }
}