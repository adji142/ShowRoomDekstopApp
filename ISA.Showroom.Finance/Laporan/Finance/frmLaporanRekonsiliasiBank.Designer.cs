namespace ISA.Showroom.Finance.Laporan.Finance
{
    partial class frmLaporanRekonsiliasiBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanRekonsiliasiBank));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCANCEL = new ISA.Controls.CommandButton();
            this.cmdPRINT = new ISA.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.lookUpBankRekening1 = new ISA.Showroom.Finance.Controls.LookUpBankRekening();
            this.rdtgltransaksi = new System.Windows.Forms.RadioButton();
            this.rdtglinput = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Periode Tanggal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.cmdCANCEL);
            this.panel1.Controls.Add(this.cmdPRINT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 60);
            this.panel1.TabIndex = 3;
            // 
            // cmdCANCEL
            // 
            this.cmdCANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCANCEL.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCANCEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("cmdCANCEL.Image")));
            this.cmdCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCANCEL.Location = new System.Drawing.Point(579, 13);
            this.cmdCANCEL.Name = "cmdCANCEL";
            this.cmdCANCEL.Size = new System.Drawing.Size(100, 40);
            this.cmdCANCEL.TabIndex = 21;
            this.cmdCANCEL.Text = "CANCEL";
            this.cmdCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCANCEL.UseVisualStyleBackColor = true;
            this.cmdCANCEL.Click += new System.EventHandler(this.cmdCANCEL_Click);
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(473, 13);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 20;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(285, 130);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(262, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookUpBankRekening1
            // 
            this.lookUpBankRekening1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lookUpBankRekening1.BankID = "";
            this.lookUpBankRekening1.FilterPT = ISA.Showroom.Finance.Controls.LookUpBankRekening.enumFilterPT.PTLoginOnly;
            this.lookUpBankRekening1.Location = new System.Drawing.Point(166, 175);
            this.lookUpBankRekening1.NamaBank = "";
            this.lookUpBankRekening1.Namarekening = "";
            this.lookUpBankRekening1.Name = "lookUpBankRekening1";
            this.lookUpBankRekening1.NoRekening = "";
            this.lookUpBankRekening1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpBankRekening1.Size = new System.Drawing.Size(370, 100);
            this.lookUpBankRekening1.TabIndex = 1;
            // 
            // rdtgltransaksi
            // 
            this.rdtgltransaksi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdtgltransaksi.AutoSize = true;
            this.rdtgltransaksi.Location = new System.Drawing.Point(444, 100);
            this.rdtgltransaksi.Name = "rdtgltransaksi";
            this.rdtgltransaksi.Size = new System.Drawing.Size(143, 18);
            this.rdtgltransaksi.TabIndex = 39;
            this.rdtgltransaksi.TabStop = true;
            this.rdtgltransaksi.Text = "Tanggal Transaksi/RK";
            this.rdtgltransaksi.UseVisualStyleBackColor = true;
            // 
            // rdtglinput
            // 
            this.rdtglinput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdtglinput.AutoSize = true;
            this.rdtglinput.Location = new System.Drawing.Point(321, 100);
            this.rdtglinput.Name = "rdtglinput";
            this.rdtglinput.Size = new System.Drawing.Size(99, 18);
            this.rdtglinput.TabIndex = 38;
            this.rdtglinput.TabStop = true;
            this.rdtglinput.Text = "Tanggal Input";
            this.rdtglinput.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 14);
            this.label3.TabIndex = 37;
            this.label3.Text = "Berdasarkan Tanggal";
            // 
            // frmLaporanRekonsiliasiBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(691, 444);
            this.Controls.Add(this.rdtgltransaksi);
            this.Controls.Add(this.rdtglinput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpBankRekening1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanRekonsiliasiBank";
            this.Text = "Laporan Rekening Koran Bank";
            this.Title = "Laporan Rekening Koran Bank";
            this.Load += new System.EventHandler(this.frmLaporanRekonsiliasiBank_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.lookUpBankRekening1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rdtglinput, 0);
            this.Controls.SetChildIndex(this.rdtgltransaksi, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.CommandButton cmdCANCEL;
        private ISA.Controls.CommandButton cmdPRINT;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Showroom.Finance.Controls.LookUpBankRekening lookUpBankRekening1;
        private System.Windows.Forms.RadioButton rdtgltransaksi;
        private System.Windows.Forms.RadioButton rdtglinput;
        private System.Windows.Forms.Label label3;
    }
}
