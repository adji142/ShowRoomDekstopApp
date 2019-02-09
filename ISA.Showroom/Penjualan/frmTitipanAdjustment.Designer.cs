namespace ISA.Showroom.Penjualan
{
    partial class frmTitipanAdjustment
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
            this.rbKorPA = new System.Windows.Forms.RadioButton();
            this.rbKorPT = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldoTitipan = new ISA.Controls.NumericTextBox();
            this.lblNoTrans = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.txtNominal = new ISA.Controls.NumericTextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtNoAngs = new ISA.Controls.CommonTextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbxBentukPembayaran = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpRekening1 = new ISA.Showroom.Controls.LookUpRekening();
            this.SuspendLayout();
            // 
            // rbKorPA
            // 
            this.rbKorPA.AutoSize = true;
            this.rbKorPA.Location = new System.Drawing.Point(44, 104);
            this.rbKorPA.Name = "rbKorPA";
            this.rbKorPA.Size = new System.Drawing.Size(194, 18);
            this.rbKorPA.TabIndex = 5;
            this.rbKorPA.TabStop = true;
            this.rbKorPA.Text = "Koreksi Penerimaan Angsuran";
            this.rbKorPA.UseVisualStyleBackColor = true;
            this.rbKorPA.CheckedChanged += new System.EventHandler(this.rbKorPA_CheckedChanged);
            // 
            // rbKorPT
            // 
            this.rbKorPT.AutoSize = true;
            this.rbKorPT.Location = new System.Drawing.Point(44, 128);
            this.rbKorPT.Name = "rbKorPT";
            this.rbKorPT.Size = new System.Drawing.Size(108, 18);
            this.rbKorPT.TabIndex = 6;
            this.rbKorPT.TabStop = true;
            this.rbKorPT.Text = "Koreksi Titipan";
            this.rbKorPT.UseVisualStyleBackColor = true;
            this.rbKorPT.CheckedChanged += new System.EventHandler(this.rbKorPT_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "No Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Saldo Titipan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nominal Pengurangan";
            // 
            // txtSaldoTitipan
            // 
            this.txtSaldoTitipan.Location = new System.Drawing.Point(450, 73);
            this.txtSaldoTitipan.Name = "txtSaldoTitipan";
            this.txtSaldoTitipan.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoTitipan.TabIndex = 10;
            this.txtSaldoTitipan.Text = "0";
            // 
            // lblNoTrans
            // 
            this.lblNoTrans.AutoSize = true;
            this.lblNoTrans.Location = new System.Drawing.Point(144, 76);
            this.lblNoTrans.Name = "lblNoTrans";
            this.lblNoTrans.Size = new System.Drawing.Size(56, 14);
            this.lblNoTrans.TabIndex = 11;
            this.lblNoTrans.Text = "-noTrans";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nama Pelanggan";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(145, 50);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(41, 14);
            this.lblNama.TabIndex = 13;
            this.lblNama.Text = "-Nama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tanggal";
            // 
            // txtTanggal
            // 
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(189, 270);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(100, 20);
            this.txtTanggal.TabIndex = 15;
            // 
            // txtNominal
            // 
            this.txtNominal.Location = new System.Drawing.Point(189, 301);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(100, 20);
            this.txtNominal.TabIndex = 16;
            this.txtNominal.Text = "0";
            this.txtNominal.Leave += new System.EventHandler(this.txtNominal_Leave);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = global::ISA.Showroom.Properties.Resources.Close32;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(468, 337);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(101, 48);
            this.cmdClose.TabIndex = 18;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = global::ISA.Showroom.Properties.Resources.Save321;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(32, 337);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(94, 48);
            this.cmdSave.TabIndex = 17;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtNoAngs
            // 
            this.txtNoAngs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoAngs.Location = new System.Drawing.Point(271, 103);
            this.txtNoAngs.Name = "txtNoAngs";
            this.txtNoAngs.Size = new System.Drawing.Size(125, 20);
            this.txtNoAngs.TabIndex = 19;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(402, 102);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(27, 23);
            this.cmdSearch.TabIndex = 20;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cboMataUang
            // 
            this.cboMataUang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMataUang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(189, 242);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(89, 22);
            this.cboMataUang.TabIndex = 130;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(42, 245);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 131;
            this.label27.Text = "Mata Uang";
            // 
            // cbxBentukPembayaran
            // 
            this.cbxBentukPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBentukPembayaran.FormattingEnabled = true;
            this.cbxBentukPembayaran.Items.AddRange(new object[] {
            "Tunai",
            "Transfer"});
            this.cbxBentukPembayaran.Location = new System.Drawing.Point(175, 155);
            this.cbxBentukPembayaran.Name = "cbxBentukPembayaran";
            this.cbxBentukPembayaran.Size = new System.Drawing.Size(129, 22);
            this.cbxBentukPembayaran.TabIndex = 146;
            this.cbxBentukPembayaran.SelectedIndexChanged += new System.EventHandler(this.cbxBentukPembayaran_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 14);
            this.label9.TabIndex = 147;
            this.label9.Text = "Bentuk Pembayaran";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 151;
            this.label4.Text = "Rekening";
            // 
            // lookUpRekening1
            // 
            this.lookUpRekening1.Location = new System.Drawing.Point(164, 183);
            this.lookUpRekening1.NamaRekening = null;
            this.lookUpRekening1.Name = "lookUpRekening1";
            this.lookUpRekening1.NoPerkiraanRekening = null;
            this.lookUpRekening1.NoRekening = null;
            this.lookUpRekening1.RekeningRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpRekening1.Size = new System.Drawing.Size(231, 53);
            this.lookUpRekening1.TabIndex = 150;
            // 
            // frmTitipanAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 406);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookUpRekening1);
            this.Controls.Add(this.cbxBentukPembayaran);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboMataUang);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNoAngs);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtNominal);
            this.Controls.Add(this.txtTanggal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaldoTitipan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbKorPT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbKorPA);
            this.Controls.Add(this.lblNoTrans);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTitipanAdjustment";
            this.Text = "Adjustment Titipan";
            this.Title = "Adjustment Titipan";
            this.Load += new System.EventHandler(this.frmTitipanAdjustment_Load);
            this.Controls.SetChildIndex(this.lblNoTrans, 0);
            this.Controls.SetChildIndex(this.rbKorPA, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rbKorPT, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSaldoTitipan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblNama, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtTanggal, 0);
            this.Controls.SetChildIndex(this.txtNominal, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.txtNoAngs, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.cboMataUang, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cbxBentukPembayaran, 0);
            this.Controls.SetChildIndex(this.lookUpRekening1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbKorPA;
        private System.Windows.Forms.RadioButton rbKorPT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.NumericTextBox txtSaldoTitipan;
        private System.Windows.Forms.Label lblNoTrans;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.DateTextBox txtTanggal;
        private ISA.Controls.NumericTextBox txtNominal;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private ISA.Controls.CommonTextBox txtNoAngs;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbxBentukPembayaran;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private ISA.Showroom.Controls.LookUpRekening lookUpRekening1;
    }
}