namespace ISA.Showroom.Master
{
    partial class frmKolektorBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKolektorBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TmptLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoIdentitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatDom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(29, 278);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 20;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Nama,
            this.TmptLahir,
            this.TglLahir,
            this.Identitas,
            this.NoIdentitas,
            this.AlamatIdt,
            this.AlamatDom,
            this.NoTelp,
            this.NoHP,
            this.TglMasuk,
            this.TglKeluar});
            this.dataGridView1.Location = new System.Drawing.Point(26, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(654, 194);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 16;
            //this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama Kolektor";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 150;
            // 
            // TmptLahir
            // 
            this.TmptLahir.DataPropertyName = "TmptLahir";
            this.TmptLahir.HeaderText = "Tempat Lahir";
            this.TmptLahir.Name = "TmptLahir";
            this.TmptLahir.ReadOnly = true;
            // 
            // TglLahir
            // 
            this.TglLahir.DataPropertyName = "TglLahir";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.TglLahir.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglLahir.HeaderText = "Tanggal Lahir";
            this.TglLahir.Name = "TglLahir";
            this.TglLahir.ReadOnly = true;
            // 
            // Identitas
            // 
            this.Identitas.DataPropertyName = "Identitas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Identitas.DefaultCellStyle = dataGridViewCellStyle3;
            this.Identitas.HeaderText = "Identitas";
            this.Identitas.Name = "Identitas";
            this.Identitas.ReadOnly = true;
            this.Identitas.Width = 60;
            // 
            // NoIdentitas
            // 
            this.NoIdentitas.DataPropertyName = "NoIdentitas";
            this.NoIdentitas.HeaderText = "No. Identitas";
            this.NoIdentitas.Name = "NoIdentitas";
            this.NoIdentitas.ReadOnly = true;
            this.NoIdentitas.Width = 150;
            // 
            // AlamatIdt
            // 
            this.AlamatIdt.DataPropertyName = "conIdentitas";
            this.AlamatIdt.HeaderText = "Alamat Identitas";
            this.AlamatIdt.Name = "AlamatIdt";
            this.AlamatIdt.ReadOnly = true;
            this.AlamatIdt.Width = 300;
            // 
            // AlamatDom
            // 
            this.AlamatDom.DataPropertyName = "conDomisili";
            this.AlamatDom.HeaderText = "Alamat Domisili";
            this.AlamatDom.Name = "AlamatDom";
            this.AlamatDom.ReadOnly = true;
            this.AlamatDom.Width = 300;
            // 
            // NoTelp
            // 
            this.NoTelp.DataPropertyName = "NoTelp";
            this.NoTelp.HeaderText = "No. Telpon";
            this.NoTelp.Name = "NoTelp";
            this.NoTelp.ReadOnly = true;
            // 
            // NoHP
            // 
            this.NoHP.DataPropertyName = "NoHP";
            this.NoHP.HeaderText = "No. HP";
            this.NoHP.Name = "NoHP";
            this.NoHP.ReadOnly = true;
            // 
            // TglMasuk
            // 
            this.TglMasuk.DataPropertyName = "TglMasuk";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.TglMasuk.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglMasuk.HeaderText = "Tgl Masuk";
            this.TglMasuk.Name = "TglMasuk";
            this.TglMasuk.ReadOnly = true;
            // 
            // TglKeluar
            // 
            this.TglKeluar.DataPropertyName = "TglKeluar";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle5.NullValue = null;
            this.TglKeluar.DefaultCellStyle = dataGridViewCellStyle5;
            this.TglKeluar.HeaderText = "Tgl Keluar";
            this.TglKeluar.Name = "TglKeluar";
            this.TglKeluar.ReadOnly = true;
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(152, 278);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 17;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(573, 278);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 19;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(276, 278);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 18;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // frmKolektorBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdDELETE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKolektorBrowse";
            this.Text = "Kolektor";
            this.Title = "Kolektor";
            this.Load += new System.EventHandler(this.frmKolektorBrowse_Load);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdDELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn TmptLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoIdentitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatDom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKeluar;

    }
}