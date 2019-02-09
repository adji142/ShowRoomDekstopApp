namespace ISA.Showroom.Finance.Laporan.Finance
{
    partial class frmLaporanGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanGiro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.rbTerimaGiro = new System.Windows.Forms.RadioButton();
            this.rbTitipGiro = new System.Windows.Forms.RadioButton();
            this.rbCairGiro = new System.Windows.Forms.RadioButton();
            this.rbTolakGiro = new System.Windows.Forms.RadioButton();
            this.rbBatalTitip = new System.Windows.Forms.RadioButton();
            this.rbBatalCair = new System.Windows.Forms.RadioButton();
            this.rbBatalTolak = new System.Windows.Forms.RadioButton();
            this.groupTransaksi = new System.Windows.Forms.GroupBox();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.rbSaldoTolak = new System.Windows.Forms.RadioButton();
            this.rbSaldoTitip = new System.Windows.Forms.RadioButton();
            this.rbSaldoGiro = new System.Windows.Forms.RadioButton();
            this.cboJnsLaporan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPT = new System.Windows.Forms.ComboBox();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.rangeDatePeriode = new ISA.Controls.RangeDateBox();
            this.labelTanggal = new System.Windows.Forms.Label();
            this.cboRekening = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelPeriode = new System.Windows.Forms.Label();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupTransaksi.SuspendLayout();
            this.groupStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.commandButton2);
            this.panel1.Controls.Add(this.commandButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 62);
            this.panel1.TabIndex = 9;
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(599, 10);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 1;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(493, 10);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 0;
            this.commandButton1.Text = "PRINT";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // rbTerimaGiro
            // 
            this.rbTerimaGiro.AutoSize = true;
            this.rbTerimaGiro.Checked = true;
            this.rbTerimaGiro.Location = new System.Drawing.Point(37, 26);
            this.rbTerimaGiro.Name = "rbTerimaGiro";
            this.rbTerimaGiro.Size = new System.Drawing.Size(118, 18);
            this.rbTerimaGiro.TabIndex = 6;
            this.rbTerimaGiro.TabStop = true;
            this.rbTerimaGiro.Text = "Penerimaan Giro";
            this.rbTerimaGiro.UseVisualStyleBackColor = true;
            this.rbTerimaGiro.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbTitipGiro
            // 
            this.rbTitipGiro.AutoSize = true;
            this.rbTitipGiro.Location = new System.Drawing.Point(37, 50);
            this.rbTitipGiro.Name = "rbTitipGiro";
            this.rbTitipGiro.Size = new System.Drawing.Size(142, 18);
            this.rbTitipGiro.TabIndex = 7;
            this.rbTitipGiro.Text = "Setoran Giro ke Bank";
            this.rbTitipGiro.UseVisualStyleBackColor = true;
            this.rbTitipGiro.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbCairGiro
            // 
            this.rbCairGiro.AutoSize = true;
            this.rbCairGiro.Location = new System.Drawing.Point(37, 74);
            this.rbCairGiro.Name = "rbCairGiro";
            this.rbCairGiro.Size = new System.Drawing.Size(106, 18);
            this.rbCairGiro.TabIndex = 8;
            this.rbCairGiro.Text = "Pencairan Giro";
            this.rbCairGiro.UseVisualStyleBackColor = true;
            this.rbCairGiro.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbTolakGiro
            // 
            this.rbTolakGiro.AutoSize = true;
            this.rbTolakGiro.Location = new System.Drawing.Point(37, 98);
            this.rbTolakGiro.Name = "rbTolakGiro";
            this.rbTolakGiro.Size = new System.Drawing.Size(94, 18);
            this.rbTolakGiro.TabIndex = 9;
            this.rbTolakGiro.Text = "Tolakan Giro";
            this.rbTolakGiro.UseVisualStyleBackColor = true;
            this.rbTolakGiro.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbBatalTitip
            // 
            this.rbBatalTitip.AutoSize = true;
            this.rbBatalTitip.Location = new System.Drawing.Point(37, 132);
            this.rbBatalTitip.Name = "rbBatalTitip";
            this.rbBatalTitip.Size = new System.Drawing.Size(162, 18);
            this.rbBatalTitip.TabIndex = 10;
            this.rbBatalTitip.Text = "Pembatalan Setoran Giro";
            this.rbBatalTitip.UseVisualStyleBackColor = true;
            this.rbBatalTitip.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbBatalCair
            // 
            this.rbBatalCair.AutoSize = true;
            this.rbBatalCair.Location = new System.Drawing.Point(37, 156);
            this.rbBatalCair.Name = "rbBatalCair";
            this.rbBatalCair.Size = new System.Drawing.Size(173, 18);
            this.rbBatalCair.TabIndex = 11;
            this.rbBatalCair.Text = "Pembatalan Pencairan Giro";
            this.rbBatalCair.UseVisualStyleBackColor = true;
            this.rbBatalCair.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbBatalTolak
            // 
            this.rbBatalTolak.AutoSize = true;
            this.rbBatalTolak.Location = new System.Drawing.Point(37, 185);
            this.rbBatalTolak.Name = "rbBatalTolak";
            this.rbBatalTolak.Size = new System.Drawing.Size(161, 18);
            this.rbBatalTolak.TabIndex = 12;
            this.rbBatalTolak.Text = "Pembatalan Tolakan Giro";
            this.rbBatalTolak.UseVisualStyleBackColor = true;
            this.rbBatalTolak.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // groupTransaksi
            // 
            this.groupTransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupTransaksi.Controls.Add(this.rdbAll);
            this.groupTransaksi.Controls.Add(this.rbBatalTolak);
            this.groupTransaksi.Controls.Add(this.rbBatalCair);
            this.groupTransaksi.Controls.Add(this.rbBatalTitip);
            this.groupTransaksi.Controls.Add(this.rbTolakGiro);
            this.groupTransaksi.Controls.Add(this.rbCairGiro);
            this.groupTransaksi.Controls.Add(this.rbTitipGiro);
            this.groupTransaksi.Controls.Add(this.rbTerimaGiro);
            this.groupTransaksi.Location = new System.Drawing.Point(434, 71);
            this.groupTransaksi.Name = "groupTransaksi";
            this.groupTransaksi.Size = new System.Drawing.Size(253, 236);
            this.groupTransaksi.TabIndex = 2;
            this.groupTransaksi.TabStop = false;
            this.groupTransaksi.Text = "Jenis Transaksi Giro";
            // 
            // groupStatus
            // 
            this.groupStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupStatus.Controls.Add(this.rbSaldoTolak);
            this.groupStatus.Controls.Add(this.rbSaldoTitip);
            this.groupStatus.Controls.Add(this.rbSaldoGiro);
            this.groupStatus.Location = new System.Drawing.Point(152, 99);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(200, 122);
            this.groupStatus.TabIndex = 1;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "Status Giro";
            // 
            // rbSaldoTolak
            // 
            this.rbSaldoTolak.AutoSize = true;
            this.rbSaldoTolak.Location = new System.Drawing.Point(36, 78);
            this.rbSaldoTolak.Name = "rbSaldoTolak";
            this.rbSaldoTolak.Size = new System.Drawing.Size(127, 18);
            this.rbSaldoTolak.TabIndex = 2;
            this.rbSaldoTolak.Text = "Saldo Giro Tolakan";
            this.rbSaldoTolak.UseVisualStyleBackColor = true;
            this.rbSaldoTolak.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbSaldoTitip
            // 
            this.rbSaldoTitip.AutoSize = true;
            this.rbSaldoTitip.Location = new System.Drawing.Point(36, 54);
            this.rbSaldoTitip.Name = "rbSaldoTitip";
            this.rbSaldoTitip.Size = new System.Drawing.Size(122, 18);
            this.rbSaldoTitip.TabIndex = 1;
            this.rbSaldoTitip.Text = "Saldo Giro Titipan";
            this.rbSaldoTitip.UseVisualStyleBackColor = true;
            this.rbSaldoTitip.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // rbSaldoGiro
            // 
            this.rbSaldoGiro.AutoSize = true;
            this.rbSaldoGiro.Checked = true;
            this.rbSaldoGiro.Location = new System.Drawing.Point(36, 30);
            this.rbSaldoGiro.Name = "rbSaldoGiro";
            this.rbSaldoGiro.Size = new System.Drawing.Size(132, 18);
            this.rbSaldoGiro.TabIndex = 0;
            this.rbSaldoGiro.TabStop = true;
            this.rbSaldoGiro.Text = "Saldo Giro Ditangan";
            this.rbSaldoGiro.UseVisualStyleBackColor = true;
            this.rbSaldoGiro.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // cboJnsLaporan
            // 
            this.cboJnsLaporan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboJnsLaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJnsLaporan.FormattingEnabled = true;
            this.cboJnsLaporan.Items.AddRange(new object[] {
            "Laporan Transaksi Giro",
            "Laporan Saldo Giro"});
            this.cboJnsLaporan.Location = new System.Drawing.Point(152, 71);
            this.cboJnsLaporan.Name = "cboJnsLaporan";
            this.cboJnsLaporan.Size = new System.Drawing.Size(276, 22);
            this.cboJnsLaporan.TabIndex = 0;
            this.cboJnsLaporan.SelectedIndexChanged += new System.EventHandler(this.cboJnsLaporan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Jenis Laporan";
            // 
            // cboPT
            // 
            this.cboPT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPT.FormattingEnabled = true;
            this.cboPT.Location = new System.Drawing.Point(152, 229);
            this.cboPT.Name = "cboPT";
            this.cboPT.Size = new System.Drawing.Size(276, 22);
            this.cboPT.TabIndex = 3;
            this.cboPT.SelectedIndexChanged += new System.EventHandler(this.cboPT_SelectedIndexChanged);
            // 
            // cboCabang
            // 
            this.cboCabang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(152, 257);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(276, 22);
            this.cboCabang.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Perusahaan (PT)";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "Cabang";
            // 
            // cboBank
            // 
            this.cboBank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(152, 285);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(276, 22);
            this.cboBank.TabIndex = 5;
            this.cboBank.SelectedIndexChanged += new System.EventHandler(this.cboBank_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nama Bank";
            // 
            // txtTanggal
            // 
            this.txtTanggal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(152, 341);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(80, 20);
            this.txtTanggal.TabIndex = 7;
            // 
            // rangeDatePeriode
            // 
            this.rangeDatePeriode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rangeDatePeriode.BackColor = System.Drawing.Color.Transparent;
            this.rangeDatePeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDatePeriode.FromDate = null;
            this.rangeDatePeriode.Location = new System.Drawing.Point(152, 367);
            this.rangeDatePeriode.Name = "rangeDatePeriode";
            this.rangeDatePeriode.Size = new System.Drawing.Size(257, 22);
            this.rangeDatePeriode.TabIndex = 8;
            this.rangeDatePeriode.ToDate = null;
            // 
            // labelTanggal
            // 
            this.labelTanggal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTanggal.AutoSize = true;
            this.labelTanggal.Location = new System.Drawing.Point(36, 344);
            this.labelTanggal.Name = "labelTanggal";
            this.labelTanggal.Size = new System.Drawing.Size(98, 14);
            this.labelTanggal.TabIndex = 25;
            this.labelTanggal.Text = "Periode Laporan";
            // 
            // cboRekening
            // 
            this.cboRekening.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboRekening.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRekening.FormattingEnabled = true;
            this.cboRekening.Location = new System.Drawing.Point(152, 313);
            this.cboRekening.Name = "cboRekening";
            this.cboRekening.Size = new System.Drawing.Size(369, 22);
            this.cboRekening.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "Rekening";
            // 
            // labelPeriode
            // 
            this.labelPeriode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPeriode.AutoSize = true;
            this.labelPeriode.Location = new System.Drawing.Point(36, 367);
            this.labelPeriode.Name = "labelPeriode";
            this.labelPeriode.Size = new System.Drawing.Size(98, 14);
            this.labelPeriode.TabIndex = 29;
            this.labelPeriode.Text = "Periode Laporan";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(37, 205);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(48, 18);
            this.rdbAll.TabIndex = 13;
            this.rdbAll.Text = "ALL";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // frmLaporanGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(711, 494);
            this.Controls.Add(this.labelPeriode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboRekening);
            this.Controls.Add(this.labelTanggal);
            this.Controls.Add(this.rangeDatePeriode);
            this.Controls.Add(this.txtTanggal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCabang);
            this.Controls.Add(this.cboPT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboJnsLaporan);
            this.Controls.Add(this.groupStatus);
            this.Controls.Add(this.groupTransaksi);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanGiro";
            this.Text = "Laporan Giro";
            this.Title = "Laporan Giro";
            this.Load += new System.EventHandler(this.frmLaporanGiro_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupTransaksi, 0);
            this.Controls.SetChildIndex(this.groupStatus, 0);
            this.Controls.SetChildIndex(this.cboJnsLaporan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboPT, 0);
            this.Controls.SetChildIndex(this.cboCabang, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboBank, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtTanggal, 0);
            this.Controls.SetChildIndex(this.rangeDatePeriode, 0);
            this.Controls.SetChildIndex(this.labelTanggal, 0);
            this.Controls.SetChildIndex(this.cboRekening, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.labelPeriode, 0);
            this.panel1.ResumeLayout(false);
            this.groupTransaksi.ResumeLayout(false);
            this.groupTransaksi.PerformLayout();
            this.groupStatus.ResumeLayout(false);
            this.groupStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.RadioButton rbTerimaGiro;
        private System.Windows.Forms.RadioButton rbTitipGiro;
        private System.Windows.Forms.RadioButton rbCairGiro;
        private System.Windows.Forms.RadioButton rbTolakGiro;
        private System.Windows.Forms.RadioButton rbBatalTitip;
        private System.Windows.Forms.RadioButton rbBatalCair;
        private System.Windows.Forms.RadioButton rbBatalTolak;
        private System.Windows.Forms.GroupBox groupTransaksi;
        private System.Windows.Forms.GroupBox groupStatus;
        private System.Windows.Forms.RadioButton rbSaldoTolak;
        private System.Windows.Forms.RadioButton rbSaldoTitip;
        private System.Windows.Forms.RadioButton rbSaldoGiro;
        private System.Windows.Forms.ComboBox cboJnsLaporan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPT;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.DateTextBox txtTanggal;
        private ISA.Controls.RangeDateBox rangeDatePeriode;
        private System.Windows.Forms.Label labelTanggal;
        private System.Windows.Forms.ComboBox cboRekening;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPeriode;
        private System.Windows.Forms.RadioButton rdbAll;
    }
}
