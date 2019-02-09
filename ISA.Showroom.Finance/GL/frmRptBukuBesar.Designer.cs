namespace ISA.Showroom.Finance.GL
{
    partial class frmRptBukuBesar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptBukuBesar));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.cmdOK = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.chkCetakSaldoNol = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.lookupPerkiraan2 = new ISA.Showroom.Finance.Controls.LookUpPerkiraan();
            this.lookupPerkiraan1 = new ISA.Showroom.Finance.Controls.LookUpPerkiraan();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Periode";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(126, 30);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "No Perkiraan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kode Cabang";
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(126, 143);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 3;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOK.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(49, 324);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 40);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "YES";
            this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(532, 324);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // chkCetakSaldoNol
            // 
            this.chkCetakSaldoNol.AutoSize = true;
            this.chkCetakSaldoNol.Location = new System.Drawing.Point(126, 207);
            this.chkCetakSaldoNol.Name = "chkCetakSaldoNol";
            this.chkCetakSaldoNol.Size = new System.Drawing.Size(15, 14);
            this.chkCetakSaldoNol.TabIndex = 4;
            this.chkCetakSaldoNol.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cetak Saldo Nol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "S/D";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboCabang);
            this.panel1.Controls.Add(this.lookupPerkiraan2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lookupPerkiraan1);
            this.panel1.Controls.Add(this.chkCetakSaldoNol);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lookupGudang1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rangeDateBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(49, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 251);
            this.panel1.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "Cabang";
            // 
            // cboCabang
            // 
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(128, 117);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(184, 22);
            this.cboCabang.TabIndex = 20;
            // 
            // lookupPerkiraan2
            // 
            this.lookupPerkiraan2.Location = new System.Drawing.Point(126, 88);
            this.lookupPerkiraan2.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraan2.Name = "lookupPerkiraan2";
            this.lookupPerkiraan2.NoPerkiraan = "[CODE]";
            this.lookupPerkiraan2.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupPerkiraan2.Size = new System.Drawing.Size(429, 33);
            this.lookupPerkiraan2.TabIndex = 18;
            // 
            // lookupPerkiraan1
            // 
            this.lookupPerkiraan1.Location = new System.Drawing.Point(126, 60);
            this.lookupPerkiraan1.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraan1.Name = "lookupPerkiraan1";
            this.lookupPerkiraan1.NoPerkiraan = "[CODE]";
            this.lookupPerkiraan1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupPerkiraan1.Size = new System.Drawing.Size(429, 31);
            this.lookupPerkiraan1.TabIndex = 19;
            // 
            // frmRptBukuBesar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(680, 387);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptBukuBesar";
            this.Text = "Buku Besar";
            this.Title = "Buku Besar";
            this.Load += new System.EventHandler(this.frmRpt02BukuBesar_Load);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.LookupGudang lookupGudang1;
        private ISA.Controls.CommandButton cmdOK;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.CheckBox chkCetakSaldoNol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private ISA.Showroom.Finance.Controls.LookUpPerkiraan lookupPerkiraan2;
        private ISA.Showroom.Finance.Controls.LookUpPerkiraan lookupPerkiraan1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCabang;
    }
}
