namespace ISA.Showroom.Penjualan
{
    partial class frmReCalculateAngsuran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReCalculateAngsuran));
            this.lblPBngOld = new System.Windows.Forms.Label();
            this.lblAngsBulananOld = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNominalPokokOld = new System.Windows.Forms.Label();
            this.lblNominalBungaOld = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNominalPokokNew = new System.Windows.Forms.Label();
            this.lblNominalBungaNew = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPBngNew = new System.Windows.Forms.Label();
            this.lblAngsBulananNew = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSisaPokok = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTargetAngsBulanan = new ISA.Controls.NumericTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPBngOld
            // 
            this.lblPBngOld.AutoSize = true;
            this.lblPBngOld.Location = new System.Drawing.Point(178, 25);
            this.lblPBngOld.Name = "lblPBngOld";
            this.lblPBngOld.Size = new System.Drawing.Size(66, 14);
            this.lblPBngOld.TabIndex = 174;
            this.lblPBngOld.Text = "lblPBngOld";
            // 
            // lblAngsBulananOld
            // 
            this.lblAngsBulananOld.AutoSize = true;
            this.lblAngsBulananOld.Location = new System.Drawing.Point(179, 116);
            this.lblAngsBulananOld.Name = "lblAngsBulananOld";
            this.lblAngsBulananOld.Size = new System.Drawing.Size(110, 14);
            this.lblAngsBulananOld.TabIndex = 172;
            this.lblAngsBulananOld.Text = "lblAngsBulananOld";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(21, 116);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(124, 14);
            this.label28.TabIndex = 171;
            this.label28.Text = "Jumlah Angsuran/Bln";
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(606, 57);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(37, 14);
            this.label32.TabIndex = 170;
            this.label32.Text = "bulan";
            // 
            // lblTempo
            // 
            this.lblTempo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(577, 57);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(58, 14);
            this.lblTempo.TabIndex = 169;
            this.lblTempo.Text = "lblTempo";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(419, 57);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 14);
            this.label26.TabIndex = 168;
            this.label26.Text = "Tempo";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(52, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 14);
            this.label22.TabIndex = 161;
            this.label22.Text = "Sisa Pokok";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(243, 298);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 40;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(381, 298);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 41;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.lblNominalPokokOld);
            this.groupBox1.Controls.Add(this.lblNominalBungaOld);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblPBngOld);
            this.groupBox1.Controls.Add(this.lblAngsBulananOld);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Location = new System.Drawing.Point(31, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 153);
            this.groupBox1.TabIndex = 177;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sebelum";
            // 
            // lblNominalPokokOld
            // 
            this.lblNominalPokokOld.AutoSize = true;
            this.lblNominalPokokOld.Location = new System.Drawing.Point(178, 86);
            this.lblNominalPokokOld.Name = "lblNominalPokokOld";
            this.lblNominalPokokOld.Size = new System.Drawing.Size(116, 14);
            this.lblNominalPokokOld.TabIndex = 183;
            this.lblNominalPokokOld.Text = "lblPokokBulananOld";
            // 
            // lblNominalBungaOld
            // 
            this.lblNominalBungaOld.AutoSize = true;
            this.lblNominalBungaOld.Location = new System.Drawing.Point(178, 55);
            this.lblNominalBungaOld.Name = "lblNominalBungaOld";
            this.lblNominalBungaOld.Size = new System.Drawing.Size(116, 14);
            this.lblNominalBungaOld.TabIndex = 182;
            this.lblNominalBungaOld.Text = "lblNominalBungaOld";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 181;
            this.label3.Text = "Nominal Pokok/Bln";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 180;
            this.label2.Text = "Nominal Bunga/Bln";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 179;
            this.label1.Text = "%Bunga";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.lblNominalPokokNew);
            this.groupBox2.Controls.Add(this.lblNominalBungaNew);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblPBngNew);
            this.groupBox2.Controls.Add(this.lblAngsBulananNew);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(381, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 150);
            this.groupBox2.TabIndex = 178;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sesudah";
            // 
            // lblNominalPokokNew
            // 
            this.lblNominalPokokNew.AutoSize = true;
            this.lblNominalPokokNew.Location = new System.Drawing.Point(195, 83);
            this.lblNominalPokokNew.Name = "lblNominalPokokNew";
            this.lblNominalPokokNew.Size = new System.Drawing.Size(123, 14);
            this.lblNominalPokokNew.TabIndex = 191;
            this.lblNominalPokokNew.Text = "lblNominalPokokNew";
            // 
            // lblNominalBungaNew
            // 
            this.lblNominalBungaNew.AutoSize = true;
            this.lblNominalBungaNew.Location = new System.Drawing.Point(195, 52);
            this.lblNominalBungaNew.Name = "lblNominalBungaNew";
            this.lblNominalBungaNew.Size = new System.Drawing.Size(122, 14);
            this.lblNominalBungaNew.TabIndex = 190;
            this.lblNominalBungaNew.Text = "lblNominalBungaNew";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 14);
            this.label8.TabIndex = 189;
            this.label8.Text = "Nominal Pokok/Bln";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 14);
            this.label9.TabIndex = 188;
            this.label9.Text = "Nominal Bunga/Bln";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 14);
            this.label10.TabIndex = 187;
            this.label10.Text = "%Bunga";
            // 
            // lblPBngNew
            // 
            this.lblPBngNew.AutoSize = true;
            this.lblPBngNew.Location = new System.Drawing.Point(195, 22);
            this.lblPBngNew.Name = "lblPBngNew";
            this.lblPBngNew.Size = new System.Drawing.Size(72, 14);
            this.lblPBngNew.TabIndex = 186;
            this.lblPBngNew.Text = "lblPBngNew";
            // 
            // lblAngsBulananNew
            // 
            this.lblAngsBulananNew.AutoSize = true;
            this.lblAngsBulananNew.Location = new System.Drawing.Point(196, 113);
            this.lblAngsBulananNew.Name = "lblAngsBulananNew";
            this.lblAngsBulananNew.Size = new System.Drawing.Size(116, 14);
            this.lblAngsBulananNew.TabIndex = 185;
            this.lblAngsBulananNew.Text = "lblAngsBulananNew";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 14);
            this.label13.TabIndex = 184;
            this.label13.Text = "Jumlah Angsuran/Bln";
            // 
            // lblSisaPokok
            // 
            this.lblSisaPokok.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSisaPokok.AutoSize = true;
            this.lblSisaPokok.Location = new System.Drawing.Point(210, 57);
            this.lblSisaPokok.Name = "lblSisaPokok";
            this.lblSisaPokok.Size = new System.Drawing.Size(78, 14);
            this.lblSisaPokok.TabIndex = 184;
            this.lblSisaPokok.Text = "lblSisaPokok";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 14);
            this.label4.TabIndex = 185;
            this.label4.Text = "Target Jumlah Angsuran/Bln";
            // 
            // txtTargetAngsBulanan
            // 
            this.txtTargetAngsBulanan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTargetAngsBulanan.Location = new System.Drawing.Point(381, 261);
            this.txtTargetAngsBulanan.Name = "txtTargetAngsBulanan";
            this.txtTargetAngsBulanan.Size = new System.Drawing.Size(111, 20);
            this.txtTargetAngsBulanan.TabIndex = 186;
            this.txtTargetAngsBulanan.Text = "0";
            this.txtTargetAngsBulanan.TextChanged += new System.EventHandler(this.txtTargetAngsBulanan_TextChanged);
            this.txtTargetAngsBulanan.Leave += new System.EventHandler(this.txtTargetAngsBulanan_Leave);
            // 
            // frmReCalculateAngsuran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 361);
            this.Controls.Add(this.txtTargetAngsBulanan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSisaPokok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.label26);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReCalculateAngsuran";
            this.Text = "Recalculate Angsuran";
            this.Title = "Recalculate Angsuran";
            this.Load += new System.EventHandler(this.frmReCalculateAngsuran_Load);
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.lblTempo, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lblSisaPokok, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtTargetAngsBulanan, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPBngOld;
        private System.Windows.Forms.Label lblAngsBulananOld;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label22;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNominalPokokOld;
        private System.Windows.Forms.Label lblNominalBungaOld;
        private System.Windows.Forms.Label lblNominalPokokNew;
        private System.Windows.Forms.Label lblNominalBungaNew;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPBngNew;
        private System.Windows.Forms.Label lblAngsBulananNew;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSisaPokok;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.NumericTextBox txtTargetAngsBulanan;
    }
}