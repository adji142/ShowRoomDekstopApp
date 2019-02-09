namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmPenerimaanUangIdentifikasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanUangIdentifikasi));
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.txtRpIden = new ISA.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaldo = new ISA.Controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNominal = new ISA.Controls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKe = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDari = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saldo = new ISA.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt = new ISA.Controls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(388, 289);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 2;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(494, 289);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 6;
            this.commandButton2.Text = "CANCEL";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(199, 132);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 0;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Location = new System.Drawing.Point(85, 135);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.ReadOnly = true;
            this.commonTextBox1.Size = new System.Drawing.Size(108, 20);
            this.commonTextBox1.TabIndex = 8;
            this.commonTextBox1.TabStop = false;
            // 
            // txtRpIden
            // 
            this.txtRpIden.Location = new System.Drawing.Point(85, 186);
            this.txtRpIden.Name = "txtRpIden";
            this.txtRpIden.Size = new System.Drawing.Size(108, 20);
            this.txtRpIden.TabIndex = 1;
            this.txtRpIden.Text = "0";
            this.txtRpIden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "NoBukti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Rp Iden";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Format = "N2";
            this.txtSaldo.Location = new System.Drawing.Point(388, 92);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(169, 20);
            this.txtSaldo.TabIndex = 29;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.Text = "0.00";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "Saldo";
            // 
            // txtNominal
            // 
            this.txtNominal.Enabled = false;
            this.txtNominal.Format = "N2";
            this.txtNominal.Location = new System.Drawing.Point(388, 69);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.ReadOnly = true;
            this.txtNominal.Size = new System.Drawing.Size(169, 20);
            this.txtNominal.TabIndex = 26;
            this.txtNominal.TabStop = false;
            this.txtNominal.Text = "0.00";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Nominal";
            // 
            // txtKe
            // 
            this.txtKe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKe.Enabled = false;
            this.txtKe.Location = new System.Drawing.Point(85, 89);
            this.txtKe.Name = "txtKe";
            this.txtKe.ReadOnly = true;
            this.txtKe.Size = new System.Drawing.Size(35, 20);
            this.txtKe.TabIndex = 33;
            this.txtKe.Text = "IDR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ke";
            // 
            // txtDari
            // 
            this.txtDari.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDari.Enabled = false;
            this.txtDari.Location = new System.Drawing.Point(85, 66);
            this.txtDari.Name = "txtDari";
            this.txtDari.ReadOnly = true;
            this.txtDari.Size = new System.Drawing.Size(82, 20);
            this.txtDari.TabIndex = 31;
            this.txtDari.Text = "IDR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "Dari";
            // 
            // saldo
            // 
            this.saldo.Enabled = false;
            this.saldo.Format = "N2";
            this.saldo.Location = new System.Drawing.Point(388, 158);
            this.saldo.Name = "saldo";
            this.saldo.ReadOnly = true;
            this.saldo.Size = new System.Drawing.Size(169, 20);
            this.saldo.TabIndex = 37;
            this.saldo.TabStop = false;
            this.saldo.Text = "0.00";
            this.saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 14);
            this.label7.TabIndex = 36;
            this.label7.Text = "Saldo";
            // 
            // txt
            // 
            this.txt.Enabled = false;
            this.txt.Format = "N2";
            this.txt.Location = new System.Drawing.Point(388, 132);
            this.txt.Name = "txt";
            this.txt.ReadOnly = true;
            this.txt.Size = new System.Drawing.Size(169, 20);
            this.txt.TabIndex = 35;
            this.txt.TabStop = false;
            this.txt.Text = "0.00";
            this.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(329, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 34;
            this.label8.Text = "Nominal";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(27, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(566, 2);
            this.label9.TabIndex = 38;
            this.label9.Text = "line";
            // 
            // frmPenerimaanUangIdentifikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(606, 341);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.saldo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDari);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNominal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commonTextBox1);
            this.Controls.Add(this.txtRpIden);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenerimaanUangIdentifikasi";
            this.Text = "Iden";
            this.Title = "Iden";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPenerimaanUangIdentifikasi_Load);
            this.Controls.SetChildIndex(this.txtRpIden, 0);
            this.Controls.SetChildIndex(this.commonTextBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtNominal, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDari, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtKe, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.saldo, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommonTextBox commonTextBox1;
        private ISA.Controls.NumericTextBox txtRpIden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.NumericTextBox txtSaldo;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.NumericTextBox txtNominal;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox txtKe;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtDari;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.NumericTextBox saldo;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.NumericTextBox txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
