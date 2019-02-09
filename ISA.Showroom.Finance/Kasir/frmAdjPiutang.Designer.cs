namespace ISA.Showroom.Finance.Kasir
{
    partial class frmAdjPiutang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjPiutang));
            this.txtNoTr = new ISA.Controls.CommonTextBox();
            this.txtCustomer = new ISA.Controls.CommonTextBox();
            this.txtSales = new ISA.Controls.CommonTextBox();
            this.txtNoKwitansi = new ISA.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTglTr = new ISA.Controls.DateTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTglAdj = new ISA.Controls.DateTextBox();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNominal = new ISA.Controls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNominalSisa = new ISA.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSaldoPiutang = new ISA.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // txtNoTr
            // 
            this.txtNoTr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoTr.Enabled = false;
            this.txtNoTr.Location = new System.Drawing.Point(154, 63);
            this.txtNoTr.Name = "txtNoTr";
            this.txtNoTr.ReadOnly = true;
            this.txtNoTr.Size = new System.Drawing.Size(100, 20);
            this.txtNoTr.TabIndex = 5;
            // 
            // txtCustomer
            // 
            this.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(386, 66);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(217, 20);
            this.txtCustomer.TabIndex = 6;
            // 
            // txtSales
            // 
            this.txtSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSales.Enabled = false;
            this.txtSales.Location = new System.Drawing.Point(386, 95);
            this.txtSales.Name = "txtSales";
            this.txtSales.ReadOnly = true;
            this.txtSales.Size = new System.Drawing.Size(217, 20);
            this.txtSales.TabIndex = 7;
            // 
            // txtNoKwitansi
            // 
            this.txtNoKwitansi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoKwitansi.Enabled = false;
            this.txtNoKwitansi.Location = new System.Drawing.Point(154, 210);
            this.txtNoKwitansi.Name = "txtNoKwitansi";
            this.txtNoKwitansi.ReadOnly = true;
            this.txtNoKwitansi.Size = new System.Drawing.Size(100, 20);
            this.txtNoKwitansi.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "No Transasksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "No Kwitansi";
            // 
            // txtTglTr
            // 
            this.txtTglTr.DateValue = null;
            this.txtTglTr.Enabled = false;
            this.txtTglTr.Location = new System.Drawing.Point(154, 92);
            this.txtTglTr.MaxLength = 10;
            this.txtTglTr.Name = "txtTglTr";
            this.txtTglTr.ReadOnly = true;
            this.txtTglTr.Size = new System.Drawing.Size(100, 20);
            this.txtTglTr.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tgl Transaksi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tgl Adj";
            // 
            // txtTglAdj
            // 
            this.txtTglAdj.DateValue = null;
            this.txtTglAdj.Enabled = false;
            this.txtTglAdj.Location = new System.Drawing.Point(154, 175);
            this.txtTglAdj.MaxLength = 10;
            this.txtTglAdj.Name = "txtTglAdj";
            this.txtTglAdj.ReadOnly = true;
            this.txtTglAdj.Size = new System.Drawing.Size(100, 20);
            this.txtTglAdj.TabIndex = 15;
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(154, 245);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(405, 20);
            this.txtUraian.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "Uraian";
            // 
            // txtNominal
            // 
            this.txtNominal.Location = new System.Drawing.Point(154, 279);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(100, 20);
            this.txtNominal.TabIndex = 19;
            this.txtNominal.Text = "0";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "Nominal Adj";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(577, 314);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 22;
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
            this.cmdSAVE.Location = new System.Drawing.Point(34, 314);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 21;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "Nominal Sisa";
            // 
            // txtNominalSisa
            // 
            this.txtNominalSisa.Enabled = false;
            this.txtNominalSisa.Location = new System.Drawing.Point(386, 130);
            this.txtNominalSisa.Name = "txtNominalSisa";
            this.txtNominalSisa.ReadOnly = true;
            this.txtNominalSisa.Size = new System.Drawing.Size(100, 20);
            this.txtNominalSisa.TabIndex = 23;
            this.txtNominalSisa.Text = "0";
            this.txtNominalSisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "Saldo Piutang";
            // 
            // txtSaldoPiutang
            // 
            this.txtSaldoPiutang.Enabled = false;
            this.txtSaldoPiutang.Location = new System.Drawing.Point(154, 127);
            this.txtSaldoPiutang.Name = "txtSaldoPiutang";
            this.txtSaldoPiutang.ReadOnly = true;
            this.txtSaldoPiutang.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoPiutang.TabIndex = 25;
            this.txtSaldoPiutang.Text = "0";
            this.txtSaldoPiutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmAdjPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 366);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSaldoPiutang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNominalSisa);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNominal);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTglAdj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoKwitansi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNoTr);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.txtTglTr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAdjPiutang";
            this.Text = "Adjustment Subsidi LSG";
            this.Title = "Adjustment Subsidi LSG";
            this.Load += new System.EventHandler(this.frmAdjPiutang_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTglTr, 0);
            this.Controls.SetChildIndex(this.txtSales, 0);
            this.Controls.SetChildIndex(this.txtCustomer, 0);
            this.Controls.SetChildIndex(this.txtNoTr, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNoKwitansi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTglAdj, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            this.Controls.SetChildIndex(this.txtNominal, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtNominalSisa, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtSaldoPiutang, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommonTextBox txtNoTr;
        private ISA.Controls.CommonTextBox txtCustomer;
        private ISA.Controls.CommonTextBox txtSales;
        private ISA.Controls.CommonTextBox txtNoKwitansi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.DateTextBox txtTglTr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.DateTextBox txtTglAdj;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.NumericTextBox txtNominal;
        private System.Windows.Forms.Label label8;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.NumericTextBox txtNominalSisa;
        private System.Windows.Forms.Label label10;
        private ISA.Controls.NumericTextBox txtSaldoPiutang;

    }
}