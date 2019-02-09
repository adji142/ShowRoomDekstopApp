namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmPenerimaanLinkPiutang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenerimaanLinkPiutang));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.RowIDHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ok = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpIden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoBukti = new ISA.Controls.CommonTextBox();
            this.txtTglKasir = new ISA.Controls.DateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.commonTextBox2 = new ISA.Controls.CommonTextBox();
            this.txtNominal = new ISA.Controls.NumericTextBox();
            this.txtSaldo = new ISA.Controls.NumericTextBox();
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tgl Nota";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(95, 115);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 8;
            this.rangeDateBox1.ToDate = null;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDHeader,
            this.Ok,
            this.TglNota,
            this.NoNota,
            this.Customer,
            this.NominalJual,
            this.NominalBayar,
            this.RpIden,
            this.SaldoPiutang});
            this.GVHeader.Location = new System.Drawing.Point(12, 143);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.RowHeadersVisible = false;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(816, 212);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 11;
            this.GVHeader.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.GVHeader_CellBeginEdit);
            this.GVHeader.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVHeader_CellEndEdit);
            this.GVHeader.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GVHeader_DataError);
            // 
            // RowIDHeader
            // 
            this.RowIDHeader.DataPropertyName = "RowID";
            this.RowIDHeader.HeaderText = "RowID";
            this.RowIDHeader.Name = "RowIDHeader";
            this.RowIDHeader.ReadOnly = true;
            this.RowIDHeader.Visible = false;
            // 
            // Ok
            // 
            this.Ok.DataPropertyName = "Ok";
            this.Ok.HeaderText = "Checked";
            this.Ok.Name = "Ok";
            this.Ok.ReadOnly = true;
            this.Ok.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ok.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglBPPB";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.TglNota.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglNota.HeaderText = "TglNota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "NoNota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // NominalJual
            // 
            this.NominalJual.DataPropertyName = "Nominal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.NominalJual.DefaultCellStyle = dataGridViewCellStyle2;
            this.NominalJual.HeaderText = "RpDebet";
            this.NominalJual.Name = "NominalJual";
            this.NominalJual.ReadOnly = true;
            // 
            // NominalBayar
            // 
            this.NominalBayar.DataPropertyName = "RpKredit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.NominalBayar.DefaultCellStyle = dataGridViewCellStyle3;
            this.NominalBayar.HeaderText = "RpKredit";
            this.NominalBayar.Name = "NominalBayar";
            this.NominalBayar.ReadOnly = true;
            // 
            // RpIden
            // 
            this.RpIden.DataPropertyName = "RpIden";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.RpIden.DefaultCellStyle = dataGridViewCellStyle4;
            this.RpIden.HeaderText = "Rp Iden";
            this.RpIden.Name = "RpIden";
            this.RpIden.ReadOnly = true;
            // 
            // SaldoPiutang
            // 
            this.SaldoPiutang.DataPropertyName = "SaldoPiutang";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.SaldoPiutang.DefaultCellStyle = dataGridViewCellStyle5;
            this.SaldoPiutang.HeaderText = "SaldoPiutang";
            this.SaldoPiutang.Name = "SaldoPiutang";
            this.SaldoPiutang.ReadOnly = true;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(358, 114);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 10;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(619, 361);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 12;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(725, 361);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CANCEL";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "NoBukti";
            // 
            // txtNoBukti
            // 
            this.txtNoBukti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBukti.Enabled = false;
            this.txtNoBukti.Location = new System.Drawing.Point(95, 63);
            this.txtNoBukti.Name = "txtNoBukti";
            this.txtNoBukti.ReadOnly = true;
            this.txtNoBukti.Size = new System.Drawing.Size(100, 20);
            this.txtNoBukti.TabIndex = 15;
            this.txtNoBukti.TabStop = false;
            // 
            // txtTglKasir
            // 
            this.txtTglKasir.DateValue = null;
            this.txtTglKasir.Enabled = false;
            this.txtTglKasir.Location = new System.Drawing.Point(95, 86);
            this.txtTglKasir.MaxLength = 10;
            this.txtTglKasir.Name = "txtTglKasir";
            this.txtTglKasir.ReadOnly = true;
            this.txtTglKasir.Size = new System.Drawing.Size(100, 20);
            this.txtTglKasir.TabIndex = 16;
            this.txtTglKasir.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tgl Kasir";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nominal";
            // 
            // commonTextBox2
            // 
            this.commonTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox2.Enabled = false;
            this.commonTextBox2.Location = new System.Drawing.Point(293, 62);
            this.commonTextBox2.Name = "commonTextBox2";
            this.commonTextBox2.ReadOnly = true;
            this.commonTextBox2.Size = new System.Drawing.Size(35, 20);
            this.commonTextBox2.TabIndex = 19;
            this.commonTextBox2.Text = "IDR";
            // 
            // txtNominal
            // 
            this.txtNominal.Enabled = false;
            this.txtNominal.Format = "N2";
            this.txtNominal.Location = new System.Drawing.Point(334, 63);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.ReadOnly = true;
            this.txtNominal.Size = new System.Drawing.Size(169, 20);
            this.txtNominal.TabIndex = 20;
            this.txtNominal.TabStop = false;
            this.txtNominal.Text = "0.00";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Format = "N2";
            this.txtSaldo.Location = new System.Drawing.Point(334, 86);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(169, 20);
            this.txtSaldo.TabIndex = 23;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.Text = "0.00";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Enabled = false;
            this.commonTextBox1.Location = new System.Drawing.Point(293, 85);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.ReadOnly = true;
            this.commonTextBox1.Size = new System.Drawing.Size(35, 20);
            this.commonTextBox1.TabIndex = 22;
            this.commonTextBox1.Text = "IDR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "Saldo";
            // 
            // frmPenerimaanLinkPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(835, 404);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.commonTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNominal);
            this.Controls.Add(this.commonTextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTglKasir);
            this.Controls.Add(this.txtNoBukti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.GVHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdSearch);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenerimaanLinkPiutang";
            this.Text = "Identifikasi Piutang";
            this.Title = "Identifikasi Piutang";
            this.Load += new System.EventHandler(this.frmPenerimaanLinkPiutang_Load);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.GVHeader, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNoBukti, 0);
            this.Controls.SetChildIndex(this.txtTglKasir, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.commonTextBox2, 0);
            this.Controls.SetChildIndex(this.txtNominal, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.commonTextBox1, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CustomGridView GVHeader;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtNoBukti;
        private ISA.Controls.DateTextBox txtTglKasir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox commonTextBox2;
        private ISA.Controls.NumericTextBox txtNominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDHeader;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpIden;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoPiutang;
        private ISA.Controls.NumericTextBox txtSaldo;
        private ISA.Controls.CommonTextBox commonTextBox1;
        private System.Windows.Forms.Label label5;
    }
}
