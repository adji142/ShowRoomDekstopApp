namespace ISA.Showroom.Controls
{
    partial class frmLookUpRekening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookUpRekening));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.gvRek = new ISA.Controls.CustomGridView();
            this.NamaRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvRek)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(31, 402);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 13;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(611, 402);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // gvRek
            // 
            this.gvRek.AllowUserToAddRows = false;
            this.gvRek.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvRek.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvRek.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvRek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaRekening,
            this.NoRekening,
            this.MataUangID,
            this.NoPerkiraan,
            this.NamaBank,
            this.RowID});
            this.gvRek.Location = new System.Drawing.Point(31, 50);
            this.gvRek.Name = "gvRek";
            this.gvRek.ReadOnly = true;
            this.gvRek.RowHeadersVisible = false;
            this.gvRek.Size = new System.Drawing.Size(680, 331);
            this.gvRek.StandardTab = true;
            this.gvRek.TabIndex = 15;
            this.gvRek.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRek_CellDoubleClick);
            this.gvRek.DoubleClick += new System.EventHandler(this.gvRek_DoubleClick);
            this.gvRek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvRek_KeyDown);
            this.gvRek.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRek_CellContentClick);
            // 
            // NamaRekening
            // 
            this.NamaRekening.DataPropertyName = "NamaRekening";
            this.NamaRekening.HeaderText = "Nama Rekening";
            this.NamaRekening.Name = "NamaRekening";
            this.NamaRekening.ReadOnly = true;
            this.NamaRekening.Width = 200;
            // 
            // NoRekening
            // 
            this.NoRekening.DataPropertyName = "NoRekening";
            this.NoRekening.HeaderText = "No Rekening";
            this.NoRekening.Name = "NoRekening";
            this.NoRekening.ReadOnly = true;
            // 
            // MataUangID
            // 
            this.MataUangID.DataPropertyName = "MataUangID";
            this.MataUangID.HeaderText = "";
            this.MataUangID.Name = "MataUangID";
            this.MataUangID.ReadOnly = true;
            this.MataUangID.Width = 60;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "No Perkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            // 
            // NamaBank
            // 
            this.NamaBank.DataPropertyName = "NamaBank";
            this.NamaBank.HeaderText = "Nama Bank";
            this.NamaBank.Name = "NamaBank";
            this.NamaBank.ReadOnly = true;
            this.NamaBank.Width = 250;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmLookUpRekening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 463);
            this.Controls.Add(this.gvRek);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLookUpRekening";
            this.Text = "Rekening Bank";
            this.Title = "Rekening Bank";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLookUpRekening_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.gvRek, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvRek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView gvRek;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaRekening;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRekening;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}