namespace ISA.Showroom.Master
{
    partial class frmJenisKendaraan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJenisKendaraan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GVJenisMotor = new ISA.Controls.CustomGridView();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.txtHarga = new ISA.Controls.NumericTextBox();
            this.txtTypeMotor = new ISA.Controls.CommonTextBox();
            this.txtMerkMotor = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJudul = new System.Windows.Forms.Label();
            this.IDType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GVJenisMotor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // GVJenisMotor
            // 
            this.GVJenisMotor.AllowUserToAddRows = false;
            this.GVJenisMotor.AllowUserToDeleteRows = false;
            this.GVJenisMotor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVJenisMotor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVJenisMotor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVJenisMotor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDType,
            this.IDHarga,
            this.Merk,
            this.Type,
            this.TglAktif,
            this.Harga,
            this.Keterangan});
            this.GVJenisMotor.Location = new System.Drawing.Point(26, 50);
            this.GVJenisMotor.Name = "GVJenisMotor";
            this.GVJenisMotor.ReadOnly = true;
            this.GVJenisMotor.RowHeadersVisible = false;
            this.GVJenisMotor.Size = new System.Drawing.Size(657, 225);
            this.GVJenisMotor.StandardTab = true;
            this.GVJenisMotor.TabIndex = 5;
            // 
            // cmdEdit
            // 
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(5, 0);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 7;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(583, 290);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cmdEdit);
            this.groupBox1.Location = new System.Drawing.Point(26, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // panelAdd
            // 
            this.panelAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAdd.Controls.Add(this.txtKeterangan);
            this.panelAdd.Controls.Add(this.label1);
            this.panelAdd.Controls.Add(this.cmdCancel);
            this.panelAdd.Controls.Add(this.cmdSave);
            this.panelAdd.Controls.Add(this.txtHarga);
            this.panelAdd.Controls.Add(this.txtTypeMotor);
            this.panelAdd.Controls.Add(this.txtMerkMotor);
            this.panelAdd.Controls.Add(this.label4);
            this.panelAdd.Controls.Add(this.label3);
            this.panelAdd.Controls.Add(this.label2);
            this.panelAdd.Controls.Add(this.txtJudul);
            this.panelAdd.Location = new System.Drawing.Point(139, 62);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(413, 233);
            this.panelAdd.TabIndex = 11;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(93, 142);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(295, 20);
            this.txtKeterangan.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Keterangan";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(288, 184);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(17, 184);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(93, 110);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(100, 20);
            this.txtHarga.TabIndex = 6;
            this.txtHarga.Text = "0";
            this.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTypeMotor
            // 
            this.txtTypeMotor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeMotor.Location = new System.Drawing.Point(93, 81);
            this.txtTypeMotor.Name = "txtTypeMotor";
            this.txtTypeMotor.ReadOnly = true;
            this.txtTypeMotor.Size = new System.Drawing.Size(295, 20);
            this.txtTypeMotor.TabIndex = 5;
            // 
            // txtMerkMotor
            // 
            this.txtMerkMotor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMerkMotor.Location = new System.Drawing.Point(93, 46);
            this.txtMerkMotor.Name = "txtMerkMotor";
            this.txtMerkMotor.ReadOnly = true;
            this.txtMerkMotor.Size = new System.Drawing.Size(295, 20);
            this.txtMerkMotor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Harga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Merk";
            // 
            // txtJudul
            // 
            this.txtJudul.AutoSize = true;
            this.txtJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.txtJudul.Location = new System.Drawing.Point(126, 3);
            this.txtJudul.Name = "txtJudul";
            this.txtJudul.Size = new System.Drawing.Size(185, 25);
            this.txtJudul.TabIndex = 0;
            this.txtJudul.Text = "Insert Jenis Motor";
            // 
            // IDType
            // 
            this.IDType.DataPropertyName = "IDType";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.IDType.DefaultCellStyle = dataGridViewCellStyle1;
            this.IDType.HeaderText = "IDType";
            this.IDType.Name = "IDType";
            this.IDType.ReadOnly = true;
            this.IDType.Visible = false;
            // 
            // IDHarga
            // 
            this.IDHarga.DataPropertyName = "IDHarga";
            this.IDHarga.HeaderText = "IDHarga";
            this.IDHarga.Name = "IDHarga";
            this.IDHarga.ReadOnly = true;
            this.IDHarga.Visible = false;
            // 
            // Merk
            // 
            this.Merk.DataPropertyName = "Merk";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Merk.DefaultCellStyle = dataGridViewCellStyle2;
            this.Merk.HeaderText = "Merk";
            this.Merk.Name = "Merk";
            this.Merk.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Type.DefaultCellStyle = dataGridViewCellStyle3;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // TglAktif
            // 
            this.TglAktif.DataPropertyName = "TglAktif";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TglAktif.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglAktif.HeaderText = "TglAktif";
            this.TglAktif.Name = "TglAktif";
            this.TglAktif.ReadOnly = true;
            // 
            // Harga
            // 
            this.Harga.DataPropertyName = "Harga";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.Harga.DefaultCellStyle = dataGridViewCellStyle5;
            this.Harga.HeaderText = "Harga";
            this.Harga.Name = "Harga";
            this.Harga.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 250;
            // 
            // frmJenisKendaraan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 348);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.GVJenisMotor);
            this.Controls.Add(this.panelAdd);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJenisKendaraan";
            this.Text = "Harga Type Motor";
            this.Title = "Harga Type Motor";
            this.Load += new System.EventHandler(this.frmJenisKendaraan_Load);
            this.Controls.SetChildIndex(this.panelAdd, 0);
            this.Controls.SetChildIndex(this.GVJenisMotor, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVJenisMotor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            this.panelAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView GVJenisMotor;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelAdd;
        private ISA.Controls.CommandButton cmdCancel;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.NumericTextBox txtHarga;
        private ISA.Controls.CommonTextBox txtTypeMotor;
        private ISA.Controls.CommonTextBox txtMerkMotor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtJudul;
        private ISA.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Harga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
    }
}