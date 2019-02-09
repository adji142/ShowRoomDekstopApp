namespace ISA.Showroom.Finance.Master
{
    partial class frmRekeningUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRekeningUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.txtNoRekening = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.chkIsAktif = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPerusahaan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNamaRekening = new ISA.Controls.CommonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lookUpPerkiraan1 = new ISA.Showroom.Finance.Controls.LookUpPerkiraan();
            this.label9 = new System.Windows.Forms.Label();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "No.Rekening";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bank";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(180, 156);
            this.txtKeterangan.MaxLength = 25;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(275, 20);
            this.txtKeterangan.TabIndex = 3;
            // 
            // txtNoRekening
            // 
            this.txtNoRekening.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoRekening.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoRekening.Location = new System.Drawing.Point(180, 130);
            this.txtNoRekening.MaxLength = 25;
            this.txtNoRekening.Name = "txtNoRekening";
            this.txtNoRekening.Size = new System.Drawing.Size(275, 20);
            this.txtNoRekening.TabIndex = 2;
            this.txtNoRekening.TextChanged += new System.EventHandler(this.txtNoRekening_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mata Uang";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(260, 301);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 9;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(154, 301);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 8;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // cboBank
            // 
            this.cboBank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(180, 102);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(275, 22);
            this.cboBank.TabIndex = 1;
            // 
            // cboMataUang
            // 
            this.cboMataUang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboMataUang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(180, 182);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(119, 22);
            this.cboMataUang.TabIndex = 4;
            // 
            // chkIsAktif
            // 
            this.chkIsAktif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkIsAktif.AutoSize = true;
            this.chkIsAktif.Location = new System.Drawing.Point(224, 211);
            this.chkIsAktif.Name = "chkIsAktif";
            this.chkIsAktif.Size = new System.Drawing.Size(15, 14);
            this.chkIsAktif.TabIndex = 5;
            this.chkIsAktif.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Perkiraan Masuk";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Aktif";
            // 
            // cboPerusahaan
            // 
            this.cboPerusahaan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboPerusahaan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerusahaan.Enabled = false;
            this.cboPerusahaan.FormattingEnabled = true;
            this.cboPerusahaan.Location = new System.Drawing.Point(180, 258);
            this.cboPerusahaan.Name = "cboPerusahaan";
            this.cboPerusahaan.Size = new System.Drawing.Size(121, 22);
            this.cboPerusahaan.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Perusahaan";
            // 
            // txtNamaRekening
            // 
            this.txtNamaRekening.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNamaRekening.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaRekening.Location = new System.Drawing.Point(180, 76);
            this.txtNamaRekening.Name = "txtNamaRekening";
            this.txtNamaRekening.Size = new System.Drawing.Size(275, 20);
            this.txtNamaRekening.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "Kode";
            // 
            // lookUpPerkiraan1
            // 
            this.lookUpPerkiraan1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lookUpPerkiraan1.Location = new System.Drawing.Point(178, 228);
            this.lookUpPerkiraan1.Name = "lookUpPerkiraan1";
            this.lookUpPerkiraan1.NoPerkiraan = null;
            this.lookUpPerkiraan1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpPerkiraan1.Size = new System.Drawing.Size(189, 24);
            this.lookUpPerkiraan1.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "CashFlow";
            // 
            // chkCash
            // 
            this.chkCash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkCash.AutoSize = true;
            this.chkCash.Location = new System.Drawing.Point(345, 208);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(15, 14);
            this.chkCash.TabIndex = 20;
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // frmRekeningUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(502, 353);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkCash);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNamaRekening);
            this.Controls.Add(this.lookUpPerkiraan1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPerusahaan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkIsAktif);
            this.Controls.Add(this.cboMataUang);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoRekening);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRekeningUpdate";
            this.Text = "Rekening";
            this.Title = "Rekening";
            this.Load += new System.EventHandler(this.frmRekeningUpdate_Load);
            this.Controls.SetChildIndex(this.txtNoRekening, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboBank, 0);
            this.Controls.SetChildIndex(this.cboMataUang, 0);
            this.Controls.SetChildIndex(this.chkIsAktif, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboPerusahaan, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lookUpPerkiraan1, 0);
            this.Controls.SetChildIndex(this.txtNamaRekening, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.chkCash, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtKeterangan;
        private ISA.Controls.CommonTextBox txtNoRekening;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.CheckBox chkIsAktif;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPerusahaan;
        private System.Windows.Forms.Label label7;
        private ISA.Showroom.Finance.Controls.LookUpPerkiraan lookUpPerkiraan1;
        private ISA.Controls.CommonTextBox txtNamaRekening;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkCash;
    }
}
