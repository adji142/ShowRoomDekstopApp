namespace ISA.Showroom.Penjualan
{
    partial class frmKonsinyasiUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKonsinyasiUpdate));
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHarga = new ISA.Controls.NumericTextBox();
            this.cboMataUang = new System.Windows.Forms.ComboBox();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.lblNoBukti = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lookUpStokMotor1 = new ISA.Showroom.Controls.LookUpStokMotor();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(245, 304);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(93, 304);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lookUpStokMotor1);
            this.panel1.Controls.Add(this.txtHarga);
            this.panel1.Controls.Add(this.cboMataUang);
            this.panel1.Controls.Add(this.cboCabang);
            this.panel1.Controls.Add(this.txtTanggal);
            this.panel1.Controls.Add(this.lblNoBukti);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Location = new System.Drawing.Point(26, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 220);
            this.panel1.TabIndex = 12;
            // 
            // txtHarga
            // 
            this.txtHarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtHarga.Enabled = false;
            this.txtHarga.Format = "N0";
            this.txtHarga.Location = new System.Drawing.Point(159, 136);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(150, 20);
            this.txtHarga.TabIndex = 4;
            this.txtHarga.Text = "0";
            // 
            // cboMataUang
            // 
            this.cboMataUang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cboMataUang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMataUang.FormattingEnabled = true;
            this.cboMataUang.Location = new System.Drawing.Point(159, 106);
            this.cboMataUang.Name = "cboMataUang";
            this.cboMataUang.Size = new System.Drawing.Size(89, 22);
            this.cboMataUang.TabIndex = 3;
            // 
            // cboCabang
            // 
            this.cboCabang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(159, 166);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(210, 22);
            this.cboCabang.TabIndex = 5;
            // 
            // txtTanggal
            // 
            this.txtTanggal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(159, 76);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(110, 20);
            this.txtTanggal.TabIndex = 2;
            // 
            // lblNoBukti
            // 
            this.lblNoBukti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblNoBukti.AutoSize = true;
            this.lblNoBukti.Location = new System.Drawing.Point(159, 51);
            this.lblNoBukti.Name = "lblNoBukti";
            this.lblNoBukti.Size = new System.Drawing.Size(0, 14);
            this.lblNoBukti.TabIndex = 111;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(52, 171);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 14);
            this.label28.TabIndex = 110;
            this.label28.Text = "Cabang";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(52, 81);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 14);
            this.label29.TabIndex = 109;
            this.label29.Text = "Tanggal";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(52, 51);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 14);
            this.label30.TabIndex = 108;
            this.label30.Text = "No. Bukti";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(52, 111);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 14);
            this.label31.TabIndex = 107;
            this.label31.Text = "Mata Uang";
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(52, 141);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(38, 14);
            this.label33.TabIndex = 105;
            this.label33.Text = "Harga";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(52, 21);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(57, 14);
            this.label34.TabIndex = 104;
            this.label34.Text = "No. Polisi";
            // 
            // lookUpStokMotor1
            // 
            this.lookUpStokMotor1.Location = new System.Drawing.Point(145, 17);
            this.lookUpStokMotor1.Name = "lookUpStokMotor1";
            this.lookUpStokMotor1.Size = new System.Drawing.Size(238, 25);
            this.lookUpStokMotor1.TabIndex = 1;
            this.lookUpStokMotor1.Click += new System.EventHandler(this.lookUpStokMotor1_Click);
            this.lookUpStokMotor1.Leave += new System.EventHandler(this.lookUpStokMotor1_Leave);
            // 
            // frmKonsinyasiUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKonsinyasiUpdate";
            this.Text = "Konsinyasi";
            this.Title = "Konsinyasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmKonsinyasiUpdate_Load);
            this.MouseEnter += new System.EventHandler(this.frmKonsinyasiUpdate_MouseEnter);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKonsinyasiUpdate_FormClosed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmKonsinyasiUpdate_MouseMove);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.NumericTextBox txtHarga;
        private System.Windows.Forms.ComboBox cboMataUang;
        private System.Windows.Forms.ComboBox cboCabang;
        private ISA.Controls.DateTextBox txtTanggal;
        private System.Windows.Forms.Label lblNoBukti;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private ISA.Showroom.Controls.LookUpStokMotor lookUpStokMotor1;
    }
}