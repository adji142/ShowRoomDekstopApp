namespace ISA.Showroom.Finance.Master
{
    partial class frmGiroBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiroBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtDtExpired = new ISA.Controls.RangeDateBox();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoGiroAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoGiroAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pemegang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tahun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalKadaluarsa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NamaRekening,
            this.NoRekening,
            this.NoGiroAwal,
            this.NoGiroAkhir,
            this.Pemegang,
            this.Tahun,
            this.TanggalKadaluarsa});
            this.dataGridView1.Location = new System.Drawing.Point(9, 102);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(688, 171);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(598, 279);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(224, 279);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 12;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(118, 279);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 11;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(12, 279);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 10;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cboBank
            // 
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(129, 51);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(243, 22);
            this.cboBank.TabIndex = 14;
            this.cboBank.SelectedIndexChanged += new System.EventHandler(this.cboBank_SelectedIndexChanged);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(28, 54);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(34, 14);
            this.lblBank.TabIndex = 15;
            this.lblBank.Text = "Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tgl.Kadaluarsa";
            // 
            // rtDtExpired
            // 
            this.rtDtExpired.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rtDtExpired.FromDate = null;
            this.rtDtExpired.Location = new System.Drawing.Point(129, 74);
            this.rtDtExpired.Name = "rtDtExpired";
            this.rtDtExpired.Size = new System.Drawing.Size(257, 22);
            this.rtDtExpired.TabIndex = 17;
            this.rtDtExpired.ToDate = null;
            this.rtDtExpired.Validating += new System.ComponentModel.CancelEventHandler(this.rtDtExpired_Validating);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NamaRekening
            // 
            this.NamaRekening.DataPropertyName = "NamaRekening";
            this.NamaRekening.HeaderText = "Kode Rekening";
            this.NamaRekening.Name = "NamaRekening";
            this.NamaRekening.ReadOnly = true;
            // 
            // NoRekening
            // 
            this.NoRekening.DataPropertyName = "NoRekening";
            this.NoRekening.HeaderText = "No.Rekening";
            this.NoRekening.Name = "NoRekening";
            this.NoRekening.ReadOnly = true;
            this.NoRekening.Width = 150;
            // 
            // NoGiroAwal
            // 
            this.NoGiroAwal.DataPropertyName = "NoGiroAwal";
            this.NoGiroAwal.HeaderText = "No.Giro Awal";
            this.NoGiroAwal.Name = "NoGiroAwal";
            this.NoGiroAwal.ReadOnly = true;
            this.NoGiroAwal.Width = 150;
            // 
            // NoGiroAkhir
            // 
            this.NoGiroAkhir.DataPropertyName = "NoGiroAkhir";
            this.NoGiroAkhir.HeaderText = "No.Giro Akhir";
            this.NoGiroAkhir.Name = "NoGiroAkhir";
            this.NoGiroAkhir.ReadOnly = true;
            this.NoGiroAkhir.Width = 150;
            // 
            // Pemegang
            // 
            this.Pemegang.DataPropertyName = "Pemegang";
            this.Pemegang.HeaderText = "Pemegang";
            this.Pemegang.Name = "Pemegang";
            this.Pemegang.ReadOnly = true;
            // 
            // Tahun
            // 
            this.Tahun.DataPropertyName = "Tahun";
            this.Tahun.HeaderText = "Tahun Buku";
            this.Tahun.Name = "Tahun";
            this.Tahun.ReadOnly = true;
            // 
            // TanggalKadaluarsa
            // 
            this.TanggalKadaluarsa.DataPropertyName = "TanggalKadaluarsa";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TanggalKadaluarsa.DefaultCellStyle = dataGridViewCellStyle1;
            this.TanggalKadaluarsa.HeaderText = "Tgl. Kadaluarsa";
            this.TanggalKadaluarsa.Name = "TanggalKadaluarsa";
            this.TanggalKadaluarsa.ReadOnly = true;
            // 
            // frmGiroBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.rtDtExpired);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGiroBrowse";
            this.Text = "Buku Giro";
            this.Title = "Buku Giro";
            this.Load += new System.EventHandler(this.frmGiroBrowse_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cboBank, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.lblBank, 0);
            this.Controls.SetChildIndex(this.rtDtExpired, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rtDtExpired;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaRekening;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRekening;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoGiroAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoGiroAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pemegang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalKadaluarsa;
    }
}
