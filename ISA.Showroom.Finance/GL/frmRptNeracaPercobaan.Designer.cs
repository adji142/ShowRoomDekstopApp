namespace ISA.Showroom.Finance.GL
{
    partial class frmRptNeracaPercobaan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptNeracaPercobaan));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbSaldo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPerbandingan = new System.Windows.Forms.RadioButton();
            this.rdoTunggal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoGlobal = new System.Windows.Forms.RadioButton();
            this.rdoDetail = new System.Windows.Forms.RadioButton();
            this.rdoSebelum = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoSetelah = new System.Windows.Forms.RadioButton();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Periode";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(288, 69);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kode Cabang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(288, 125);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cetak Saldo 0 (nol)";
            // 
            // ckbSaldo
            // 
            this.ckbSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckbSaldo.AutoSize = true;
            this.ckbSaldo.Location = new System.Drawing.Point(288, 194);
            this.ckbSaldo.Name = "ckbSaldo";
            this.ckbSaldo.Size = new System.Drawing.Size(15, 14);
            this.ckbSaldo.TabIndex = 2;
            this.ckbSaldo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rdoPerbandingan);
            this.groupBox1.Controls.Add(this.rdoTunggal);
            this.groupBox1.Location = new System.Drawing.Point(186, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jenis Laporan";
            // 
            // rdoPerbandingan
            // 
            this.rdoPerbandingan.AutoSize = true;
            this.rdoPerbandingan.Location = new System.Drawing.Point(228, 29);
            this.rdoPerbandingan.Name = "rdoPerbandingan";
            this.rdoPerbandingan.Size = new System.Drawing.Size(101, 18);
            this.rdoPerbandingan.TabIndex = 1;
            this.rdoPerbandingan.TabStop = true;
            this.rdoPerbandingan.Text = "Perbandingan";
            this.rdoPerbandingan.UseVisualStyleBackColor = true;
            // 
            // rdoTunggal
            // 
            this.rdoTunggal.AutoSize = true;
            this.rdoTunggal.Checked = true;
            this.rdoTunggal.Location = new System.Drawing.Point(6, 29);
            this.rdoTunggal.Name = "rdoTunggal";
            this.rdoTunggal.Size = new System.Drawing.Size(68, 18);
            this.rdoTunggal.TabIndex = 0;
            this.rdoTunggal.TabStop = true;
            this.rdoTunggal.Text = "Tunggal";
            this.rdoTunggal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.rdoGlobal);
            this.groupBox2.Controls.Add(this.rdoDetail);
            this.groupBox2.Location = new System.Drawing.Point(186, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 68);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Source";
            // 
            // rdoGlobal
            // 
            this.rdoGlobal.AutoSize = true;
            this.rdoGlobal.Location = new System.Drawing.Point(228, 29);
            this.rdoGlobal.Name = "rdoGlobal";
            this.rdoGlobal.Size = new System.Drawing.Size(59, 18);
            this.rdoGlobal.TabIndex = 1;
            this.rdoGlobal.TabStop = true;
            this.rdoGlobal.Text = "Global";
            this.rdoGlobal.UseVisualStyleBackColor = true;
            // 
            // rdoDetail
            // 
            this.rdoDetail.AutoSize = true;
            this.rdoDetail.Checked = true;
            this.rdoDetail.Location = new System.Drawing.Point(6, 29);
            this.rdoDetail.Name = "rdoDetail";
            this.rdoDetail.Size = new System.Drawing.Size(55, 18);
            this.rdoDetail.TabIndex = 0;
            this.rdoDetail.TabStop = true;
            this.rdoDetail.Text = "Detail";
            this.rdoDetail.UseVisualStyleBackColor = true;
            // 
            // rdoSebelum
            // 
            this.rdoSebelum.AutoSize = true;
            this.rdoSebelum.Checked = true;
            this.rdoSebelum.Location = new System.Drawing.Point(6, 28);
            this.rdoSebelum.Name = "rdoSebelum";
            this.rdoSebelum.Size = new System.Drawing.Size(139, 18);
            this.rdoSebelum.TabIndex = 2;
            this.rdoSebelum.TabStop = true;
            this.rdoSebelum.Text = "Sebelum Tutup Buku";
            this.rdoSebelum.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.rdoSetelah);
            this.groupBox3.Controls.Add(this.rdoSebelum);
            this.groupBox3.Location = new System.Drawing.Point(186, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 69);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Posisi Periode";
            // 
            // rdoSetelah
            // 
            this.rdoSetelah.AutoSize = true;
            this.rdoSetelah.Location = new System.Drawing.Point(228, 28);
            this.rdoSetelah.Name = "rdoSetelah";
            this.rdoSetelah.Size = new System.Drawing.Size(131, 18);
            this.rdoSetelah.TabIndex = 3;
            this.rdoSetelah.TabStop = true;
            this.rdoSetelah.Text = "Setelah Tutup Buku";
            this.rdoSetelah.UseVisualStyleBackColor = true;
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(31, 501);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 6;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(627, 501);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "Unit";
            // 
            // cboCabang
            // 
            this.cboCabang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(288, 97);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(235, 22);
            this.cboCabang.TabIndex = 22;
            // 
            // frmRptNeracaPercobaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(759, 574);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCabang);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbSaldo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptNeracaPercobaan";
            this.Text = "Neraca Percobaan";
            this.Title = "Neraca Percobaan";
            this.Load += new System.EventHandler(this.frmRptNeracaPercobaan_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ckbSaldo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cboCabang, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbSaldo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPerbandingan;
        private System.Windows.Forms.RadioButton rdoTunggal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoGlobal;
        private System.Windows.Forms.RadioButton rdoDetail;
        private System.Windows.Forms.RadioButton rdoSebelum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSetelah;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCabang;

    }
}
