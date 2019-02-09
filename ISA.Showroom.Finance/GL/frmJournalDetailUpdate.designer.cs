namespace ISA.Showroom.Finance.GL
{
    partial class frmJournalDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalDetailUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDebet = new ISA.Controls.NumericTextBox();
            this.txtKredit = new ISA.Controls.NumericTextBox();
            this.cmdOk = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lookupPerkiraan1 = new ISA.Showroom.Finance.Controls.LookupPerkiraanISA();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Perkiraan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Uraian";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(215, 89);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(469, 20);
            this.txtUraian.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Debet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kredit";
            // 
            // txtDebet
            // 
            this.txtDebet.Location = new System.Drawing.Point(264, 130);
            this.txtDebet.Name = "txtDebet";
            this.txtDebet.Size = new System.Drawing.Size(125, 20);
            this.txtDebet.TabIndex = 2;
            this.txtDebet.Text = "0";
            // 
            // txtKredit
            // 
            this.txtKredit.Location = new System.Drawing.Point(458, 130);
            this.txtKredit.Name = "txtKredit";
            this.txtKredit.Size = new System.Drawing.Size(125, 20);
            this.txtKredit.TabIndex = 3;
            this.txtKredit.Text = "0";
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOk.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(31, 395);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(100, 40);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "YES";
            this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(708, 395);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.txtUraian);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDebet);
            this.panel1.Controls.Add(this.lookupPerkiraan1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtKredit);
            this.panel1.Location = new System.Drawing.Point(31, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 208);
            this.panel1.TabIndex = 0;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRowID,
            this.cHeaderID,
            this.cRecordID,
            this.cHRecordID,
            this.cNoPerkiraan,
            this.cNamaPerkiraan,
            this.cUraian,
            this.cDK,
            this.cDebet,
            this.cKredit});
            this.customGridView1.Enabled = false;
            this.customGridView1.EnableHeadersVisualStyles = false;
            this.customGridView1.Location = new System.Drawing.Point(31, 38);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(777, 122);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 10;
            this.customGridView1.TabStop = false;
            // 
            // cRowID
            // 
            this.cRowID.DataPropertyName = "RowID";
            this.cRowID.HeaderText = "RowID";
            this.cRowID.Name = "cRowID";
            this.cRowID.ReadOnly = true;
            this.cRowID.Visible = false;
            // 
            // cHeaderID
            // 
            this.cHeaderID.DataPropertyName = "HeaderID";
            this.cHeaderID.HeaderText = "HeaderID";
            this.cHeaderID.Name = "cHeaderID";
            this.cHeaderID.ReadOnly = true;
            this.cHeaderID.Visible = false;
            // 
            // cRecordID
            // 
            this.cRecordID.DataPropertyName = "RecordID";
            this.cRecordID.HeaderText = "RecordID";
            this.cRecordID.Name = "cRecordID";
            this.cRecordID.ReadOnly = true;
            this.cRecordID.Visible = false;
            // 
            // cHRecordID
            // 
            this.cHRecordID.DataPropertyName = "HRecordID";
            this.cHRecordID.HeaderText = "HRecordID";
            this.cHRecordID.Name = "cHRecordID";
            this.cHRecordID.ReadOnly = true;
            this.cHRecordID.Visible = false;
            // 
            // cNoPerkiraan
            // 
            this.cNoPerkiraan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.cNoPerkiraan.HeaderText = "NoPerkiraan";
            this.cNoPerkiraan.Name = "cNoPerkiraan";
            this.cNoPerkiraan.ReadOnly = true;
            this.cNoPerkiraan.Width = 99;
            // 
            // cNamaPerkiraan
            // 
            this.cNamaPerkiraan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.cNamaPerkiraan.HeaderText = "NamaPerkiraan";
            this.cNamaPerkiraan.Name = "cNamaPerkiraan";
            this.cNamaPerkiraan.ReadOnly = true;
            this.cNamaPerkiraan.Width = 115;
            // 
            // cUraian
            // 
            this.cUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cUraian.DataPropertyName = "Uraian";
            this.cUraian.HeaderText = "Uraian";
            this.cUraian.MinimumWidth = 200;
            this.cUraian.Name = "cUraian";
            this.cUraian.ReadOnly = true;
            this.cUraian.Width = 200;
            // 
            // cDK
            // 
            this.cDK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDK.DataPropertyName = "DK";
            this.cDK.HeaderText = "DK";
            this.cDK.Name = "cDK";
            this.cDK.ReadOnly = true;
            this.cDK.Width = 46;
            // 
            // cDebet
            // 
            this.cDebet.DataPropertyName = "Debet";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            this.cDebet.DefaultCellStyle = dataGridViewCellStyle1;
            this.cDebet.HeaderText = "Debet";
            this.cDebet.Name = "cDebet";
            this.cDebet.ReadOnly = true;
            this.cDebet.Width = 150;
            // 
            // cKredit
            // 
            this.cKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.cKredit.DefaultCellStyle = dataGridViewCellStyle2;
            this.cKredit.HeaderText = "Kredit";
            this.cKredit.Name = "cKredit";
            this.cKredit.ReadOnly = true;
            this.cKredit.Width = 150;
            // 
            // lookupPerkiraan1
            // 
            this.lookupPerkiraan1.Location = new System.Drawing.Point(215, 33);
            this.lookupPerkiraan1.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraan1.NamaPerkiraan = "";
            this.lookupPerkiraan1.Name = "lookupPerkiraan1";
            this.lookupPerkiraan1.NoPerkiraan = "[CODE]";
            this.lookupPerkiraan1.Size = new System.Drawing.Size(269, 47);
            this.lookupPerkiraan1.TabIndex = 0;
            this.lookupPerkiraan1.Load += new System.EventHandler(this.lookupPerkiraan1_Load);
            // 
            // frmJournalDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(833, 458);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOk);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJournalDetailUpdate";
            this.ShowInTaskbar = false;
            this.Text = "Journal Detail";
            this.Title = "Journal Detail";
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ISA.Showroom.Finance.Controls.LookupPerkiraanISA lookupPerkiraan1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.NumericTextBox txtDebet;
        private ISA.Controls.NumericTextBox txtKredit;
        private ISA.Controls.CommandButton cmdOk;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Panel panel1;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKredit;
    }
}
