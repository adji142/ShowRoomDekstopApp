namespace ISA.Showroom.Finance.Master
{
    partial class frmJnsTransaksiUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJnsTransaksiUpdate));
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJnsTransaksi = new ISA.Controls.CommonTextBox();
            this.txtNamaTransaksi = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsAktif = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpJnsArus = new System.Windows.Forms.GroupBox();
            this.rdoPengeluaran = new System.Windows.Forms.RadioButton();
            this.rdoPenerimaan = new System.Windows.Forms.RadioButton();
            this.lblAcc1 = new System.Windows.Forms.Label();
            this.lblAcc2 = new System.Windows.Forms.Label();
            this.cboUserAcc1 = new System.Windows.Forms.ComboBox();
            this.cboUserAcc2 = new System.Windows.Forms.ComboBox();
            this.lblCekAcc = new System.Windows.Forms.Label();
            this.chkAcc = new System.Windows.Forms.CheckBox();
            this.lookUpPerkiraan2 = new ISA.Showroom.Finance.Controls.LookUpPerkiraan();
            this.lookUpPerkiraan1 = new ISA.Showroom.Finance.Controls.LookUpPerkiraan();
            this.grpJnsArus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(371, 374);
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
            this.cmdSAVE.Location = new System.Drawing.Point(158, 374);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 8;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Keterangan";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kode";
            // 
            // txtJnsTransaksi
            // 
            this.txtJnsTransaksi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtJnsTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJnsTransaksi.Location = new System.Drawing.Point(218, 66);
            this.txtJnsTransaksi.MaxLength = 3;
            this.txtJnsTransaksi.Name = "txtJnsTransaksi";
            this.txtJnsTransaksi.Size = new System.Drawing.Size(30, 20);
            this.txtJnsTransaksi.TabIndex = 10;
            // 
            // txtNamaTransaksi
            // 
            this.txtNamaTransaksi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNamaTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaTransaksi.Location = new System.Drawing.Point(218, 91);
            this.txtNamaTransaksi.MaxLength = 25;
            this.txtNamaTransaksi.Name = "txtNamaTransaksi";
            this.txtNamaTransaksi.Size = new System.Drawing.Size(275, 20);
            this.txtNamaTransaksi.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "No.Perkiraan 2";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "No. Perkiraan 1";
            // 
            // chkIsAktif
            // 
            this.chkIsAktif.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkIsAktif.AutoSize = true;
            this.chkIsAktif.Location = new System.Drawing.Point(218, 159);
            this.chkIsAktif.Name = "chkIsAktif";
            this.chkIsAktif.Size = new System.Drawing.Size(15, 14);
            this.chkIsAktif.TabIndex = 22;
            this.chkIsAktif.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "Arus ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Aktif";
            // 
            // grpJnsArus
            // 
            this.grpJnsArus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpJnsArus.Controls.Add(this.rdoPengeluaran);
            this.grpJnsArus.Controls.Add(this.rdoPenerimaan);
            this.grpJnsArus.Location = new System.Drawing.Point(218, 113);
            this.grpJnsArus.Name = "grpJnsArus";
            this.grpJnsArus.Size = new System.Drawing.Size(226, 40);
            this.grpJnsArus.TabIndex = 25;
            this.grpJnsArus.TabStop = false;
            // 
            // rdoPengeluaran
            // 
            this.rdoPengeluaran.AutoSize = true;
            this.rdoPengeluaran.Location = new System.Drawing.Point(115, 13);
            this.rdoPengeluaran.Name = "rdoPengeluaran";
            this.rdoPengeluaran.Size = new System.Drawing.Size(94, 18);
            this.rdoPengeluaran.TabIndex = 1;
            this.rdoPengeluaran.TabStop = true;
            this.rdoPengeluaran.Text = "Pengeluaran";
            this.rdoPengeluaran.UseVisualStyleBackColor = true;
            this.rdoPengeluaran.CheckedChanged += new System.EventHandler(this.rdoPengeluaran_CheckedChanged);
            // 
            // rdoPenerimaan
            // 
            this.rdoPenerimaan.AutoSize = true;
            this.rdoPenerimaan.Location = new System.Drawing.Point(6, 13);
            this.rdoPenerimaan.Name = "rdoPenerimaan";
            this.rdoPenerimaan.Size = new System.Drawing.Size(90, 18);
            this.rdoPenerimaan.TabIndex = 0;
            this.rdoPenerimaan.TabStop = true;
            this.rdoPenerimaan.Text = "Pemasukan";
            this.rdoPenerimaan.UseVisualStyleBackColor = true;
            this.rdoPenerimaan.CheckedChanged += new System.EventHandler(this.rdoPenerimaan_CheckedChanged);
            // 
            // lblAcc1
            // 
            this.lblAcc1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAcc1.AutoSize = true;
            this.lblAcc1.Location = new System.Drawing.Point(137, 313);
            this.lblAcc1.Name = "lblAcc1";
            this.lblAcc1.Size = new System.Drawing.Size(36, 14);
            this.lblAcc1.TabIndex = 26;
            this.lblAcc1.Text = "Acc 1";
            // 
            // lblAcc2
            // 
            this.lblAcc2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAcc2.AutoSize = true;
            this.lblAcc2.Location = new System.Drawing.Point(137, 338);
            this.lblAcc2.Name = "lblAcc2";
            this.lblAcc2.Size = new System.Drawing.Size(36, 14);
            this.lblAcc2.TabIndex = 27;
            this.lblAcc2.Text = "Acc 2";
            // 
            // cboUserAcc1
            // 
            this.cboUserAcc1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboUserAcc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserAcc1.Enabled = false;
            this.cboUserAcc1.FormattingEnabled = true;
            this.cboUserAcc1.Location = new System.Drawing.Point(218, 310);
            this.cboUserAcc1.Name = "cboUserAcc1";
            this.cboUserAcc1.Size = new System.Drawing.Size(275, 22);
            this.cboUserAcc1.TabIndex = 28;
            // 
            // cboUserAcc2
            // 
            this.cboUserAcc2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboUserAcc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserAcc2.Enabled = false;
            this.cboUserAcc2.FormattingEnabled = true;
            this.cboUserAcc2.Location = new System.Drawing.Point(218, 335);
            this.cboUserAcc2.Name = "cboUserAcc2";
            this.cboUserAcc2.Size = new System.Drawing.Size(275, 22);
            this.cboUserAcc2.TabIndex = 29;
            // 
            // lblCekAcc
            // 
            this.lblCekAcc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCekAcc.AutoSize = true;
            this.lblCekAcc.Location = new System.Drawing.Point(108, 284);
            this.lblCekAcc.Name = "lblCekAcc";
            this.lblCekAcc.Size = new System.Drawing.Size(103, 14);
            this.lblCekAcc.TabIndex = 32;
            this.lblCekAcc.Text = "Memerlukan Acc.";
            // 
            // chkAcc
            // 
            this.chkAcc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAcc.AutoSize = true;
            this.chkAcc.Location = new System.Drawing.Point(218, 284);
            this.chkAcc.Name = "chkAcc";
            this.chkAcc.Size = new System.Drawing.Size(15, 14);
            this.chkAcc.TabIndex = 33;
            this.chkAcc.UseVisualStyleBackColor = true;
            this.chkAcc.CheckedChanged += new System.EventHandler(this.chkAcc_CheckedChanged);
            // 
            // lookUpPerkiraan2
            // 
            this.lookUpPerkiraan2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpPerkiraan2.Location = new System.Drawing.Point(218, 224);
            this.lookUpPerkiraan2.Name = "lookUpPerkiraan2";
            this.lookUpPerkiraan2.NoPerkiraan = null;
            this.lookUpPerkiraan2.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpPerkiraan2.Size = new System.Drawing.Size(415, 26);
            this.lookUpPerkiraan2.TabIndex = 31;
            this.lookUpPerkiraan2.Visible = false;
            // 
            // lookUpPerkiraan1
            // 
            this.lookUpPerkiraan1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookUpPerkiraan1.Location = new System.Drawing.Point(218, 192);
            this.lookUpPerkiraan1.Name = "lookUpPerkiraan1";
            this.lookUpPerkiraan1.NoPerkiraan = null;
            this.lookUpPerkiraan1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpPerkiraan1.Size = new System.Drawing.Size(415, 26);
            this.lookUpPerkiraan1.TabIndex = 30;
            this.lookUpPerkiraan1.Load += new System.EventHandler(this.lookUpPerkiraan1_Load);
            // 
            // frmJnsTransaksiUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(633, 426);
            this.Controls.Add(this.chkAcc);
            this.Controls.Add(this.lblCekAcc);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNamaTransaksi);
            this.Controls.Add(this.grpJnsArus);
            this.Controls.Add(this.lookUpPerkiraan2);
            this.Controls.Add(this.lookUpPerkiraan1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboUserAcc1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIsAktif);
            this.Controls.Add(this.cboUserAcc2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJnsTransaksi);
            this.Controls.Add(this.lblAcc1);
            this.Controls.Add(this.lblAcc2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJnsTransaksiUpdate";
            this.Text = "Jenis Transaksi";
            this.Title = "Jenis Transaksi";
            this.Load += new System.EventHandler(this.frmJnsTransaksiUpdate_Load);
            this.Controls.SetChildIndex(this.lblAcc2, 0);
            this.Controls.SetChildIndex(this.lblAcc1, 0);
            this.Controls.SetChildIndex(this.txtJnsTransaksi, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboUserAcc2, 0);
            this.Controls.SetChildIndex(this.chkIsAktif, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboUserAcc1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookUpPerkiraan1, 0);
            this.Controls.SetChildIndex(this.lookUpPerkiraan2, 0);
            this.Controls.SetChildIndex(this.grpJnsArus, 0);
            this.Controls.SetChildIndex(this.txtNamaTransaksi, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.lblCekAcc, 0);
            this.Controls.SetChildIndex(this.chkAcc, 0);
            this.grpJnsArus.ResumeLayout(false);
            this.grpJnsArus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtJnsTransaksi;
        private ISA.Controls.CommonTextBox txtNamaTransaksi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsAktif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpJnsArus;
        private System.Windows.Forms.RadioButton rdoPengeluaran;
        private System.Windows.Forms.RadioButton rdoPenerimaan;
        private System.Windows.Forms.Label lblAcc1;
        private System.Windows.Forms.Label lblAcc2;
        private System.Windows.Forms.ComboBox cboUserAcc1;
        private System.Windows.Forms.ComboBox cboUserAcc2;
        private ISA.Showroom.Finance.Controls.LookUpPerkiraan lookUpPerkiraan1;
        private ISA.Showroom.Finance.Controls.LookUpPerkiraan lookUpPerkiraan2;
        private System.Windows.Forms.Label lblCekAcc;
        private System.Windows.Forms.CheckBox chkAcc;
    }
}
