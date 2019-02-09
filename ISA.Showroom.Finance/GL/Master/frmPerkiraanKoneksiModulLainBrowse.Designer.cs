namespace ISA.Showroom.Finance.GL
{
    partial class frmPerkiraanKoneksiModulLainBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerkiraanKoneksiModulLainBrowse));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMdl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKodeTrn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdREFRESH = new ISA.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupGudang2 = new ISA.Controls.LookupGudang();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRowID,
            this.cMdl,
            this.cKodeTrn,
            this.cNoPerkiraan,
            this.cUraian});
            this.customGridView1.Location = new System.Drawing.Point(6, 107);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(697, 236);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            // 
            // cRowID
            // 
            this.cRowID.DataPropertyName = "RowID";
            this.cRowID.HeaderText = "RowID";
            this.cRowID.Name = "cRowID";
            this.cRowID.ReadOnly = true;
            this.cRowID.Visible = false;
            // 
            // cMdl
            // 
            this.cMdl.DataPropertyName = "Mdl";
            this.cMdl.HeaderText = "Modul";
            this.cMdl.Name = "cMdl";
            this.cMdl.ReadOnly = true;
            this.cMdl.Width = 60;
            // 
            // cKodeTrn
            // 
            this.cKodeTrn.DataPropertyName = "KodeTrn";
            this.cKodeTrn.HeaderText = "Kode";
            this.cKodeTrn.Name = "cKodeTrn";
            this.cKodeTrn.ReadOnly = true;
            this.cKodeTrn.Width = 75;
            // 
            // cNoPerkiraan
            // 
            this.cNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.cNoPerkiraan.HeaderText = "No Perkiraan";
            this.cNoPerkiraan.Name = "cNoPerkiraan";
            this.cNoPerkiraan.ReadOnly = true;
            this.cNoPerkiraan.Width = 150;
            // 
            // cUraian
            // 
            this.cUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cUraian.DataPropertyName = "Uraian";
            this.cUraian.HeaderText = "Uraian";
            this.cUraian.Name = "cUraian";
            this.cUraian.ReadOnly = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(599, 349);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(86, 47);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 8;
            this.lookupGudang1.SelectData += new System.EventHandler(this.lookupGudang1_SelectData);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cabang";
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(6, 349);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 10;
            this.cmdEDIT.TabStop = false;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdREFRESH
            // 
            this.cmdREFRESH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdREFRESH.CommandType = ISA.Controls.CommandButton.enCommandType.Refresh;
            this.cmdREFRESH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdREFRESH.Image = ((System.Drawing.Image)(resources.GetObject("cmdREFRESH.Image")));
            this.cmdREFRESH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdREFRESH.Location = new System.Drawing.Point(112, 349);
            this.cmdREFRESH.Name = "cmdREFRESH";
            this.cmdREFRESH.Size = new System.Drawing.Size(120, 40);
            this.cmdREFRESH.TabIndex = 11;
            this.cmdREFRESH.TabStop = false;
            this.cmdREFRESH.Text = "REFRESH";
            this.cmdREFRESH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdREFRESH.UseVisualStyleBackColor = true;
            this.cmdREFRESH.Click += new System.EventHandler(this.cmdREFRESH_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.commandButton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lookupGudang2);
            this.panel1.Location = new System.Drawing.Point(185, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 142);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Duplikat dr cabang";
            // 
            // lookupGudang2
            // 
            this.lookupGudang2.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang2.GudangID = "[CODE]";
            this.lookupGudang2.KodeCabang = null;
            this.lookupGudang2.Location = new System.Drawing.Point(58, 38);
            this.lookupGudang2.NamaGudang = "";
            this.lookupGudang2.Name = "lookupGudang2";
            this.lookupGudang2.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang2.TabIndex = 10;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(271, 84);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 12;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(238, 350);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 13;
            this.commandButton2.Text = "DUPLIKAT";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // frmPerkiraanKoneksiModulLainBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(711, 401);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdREFRESH);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPerkiraanKoneksiModulLainBrowse";
            this.Text = "Perkiraan Koneksi Arus Kas";
            this.Title = "Perkiraan Koneksi Arus Kas";
            this.Load += new System.EventHandler(this.frmPerkiraanKoneksiModulLainBrowse_Load);
            this.Shown += new System.EventHandler(this.frmPerkiraanKoneksiModulLainBrowse_Shown);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdREFRESH, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.LookupGudang lookupGudang1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMdl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKodeTrn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUraian;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdREFRESH;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.LookupGudang lookupGudang2;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
    }
}
