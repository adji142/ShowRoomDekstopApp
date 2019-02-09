namespace ISA.Showroom.Finance.GL
{
    partial class frmUploadPerkiraan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadPerkiraan));
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbChanged = new System.Windows.Forms.RadioButton();
            this.labelStart = new System.Windows.Forms.Label();
            this.dateStart = new ISA.Controls.DateTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.cekKoneksi = new System.Windows.Forms.CheckBox();
            this.cekPerkiraan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cekDisgn = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(28, 352);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 1;
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
            this.cmdClose.Location = new System.Drawing.Point(527, 352);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Upload tabel";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(137, 128);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(103, 18);
            this.rbAll.TabIndex = 3;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Semua record";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbChanged
            // 
            this.rbChanged.AutoSize = true;
            this.rbChanged.Location = new System.Drawing.Point(262, 130);
            this.rbChanged.Name = "rbChanged";
            this.rbChanged.Size = new System.Drawing.Size(156, 18);
            this.rbChanged.TabIndex = 4;
            this.rbChanged.TabStop = true;
            this.rbChanged.Text = "Perubahan terakhir saja";
            this.rbChanged.UseVisualStyleBackColor = true;
            this.rbChanged.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(32, 174);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(144, 14);
            this.labelStart.TabIndex = 10;
            this.labelStart.Text = "Perubahan Mulai Tanggal";
            this.labelStart.Visible = false;
            // 
            // dateStart
            // 
            this.dateStart.DateValue = null;
            this.dateStart.Location = new System.Drawing.Point(184, 171);
            this.dateStart.MaxLength = 10;
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(80, 20);
            this.dateStart.TabIndex = 5;
            this.dateStart.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cekDisgn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rbChanged);
            this.panel1.Controls.Add(this.rbAll);
            this.panel1.Controls.Add(this.cekPerkiraan);
            this.panel1.Controls.Add(this.cekKoneksi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboCabang);
            this.panel1.Controls.Add(this.dateStart);
            this.panel1.Controls.Add(this.labelStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(89, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 256);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Upload ke cabang";
            // 
            // cboCabang
            // 
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(184, 200);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(121, 22);
            this.cboCabang.TabIndex = 6;
            // 
            // cekKoneksi
            // 
            this.cekKoneksi.AutoSize = true;
            this.cekKoneksi.Location = new System.Drawing.Point(139, 52);
            this.cekKoneksi.Name = "cekKoneksi";
            this.cekKoneksi.Size = new System.Drawing.Size(127, 18);
            this.cekKoneksi.TabIndex = 1;
            this.cekKoneksi.Text = "Perkiraan koneksi";
            this.cekKoneksi.UseVisualStyleBackColor = true;
            // 
            // cekPerkiraan
            // 
            this.cekPerkiraan.AutoSize = true;
            this.cekPerkiraan.Location = new System.Drawing.Point(139, 28);
            this.cekPerkiraan.Name = "cekPerkiraan";
            this.cekPerkiraan.Size = new System.Drawing.Size(121, 18);
            this.cekPerkiraan.TabIndex = 0;
            this.cekPerkiraan.Text = "Master perkiraan";
            this.cekPerkiraan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "Batasan upload";
            // 
            // cekDisgn
            // 
            this.cekDisgn.AutoSize = true;
            this.cekDisgn.Location = new System.Drawing.Point(139, 74);
            this.cekDisgn.Name = "cekDisgn";
            this.cekDisgn.Size = new System.Drawing.Size(104, 18);
            this.cekDisgn.TabIndex = 2;
            this.cekDisgn.Text = "Report design";
            this.cekDisgn.UseVisualStyleBackColor = true;
            // 
            // frmUploadPerkiraan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(659, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUploadPerkiraan";
            this.Text = "Upload Perkiraan";
            this.Title = "Upload Perkiraan";
            this.Load += new System.EventHandler(this.frmUploadPerkiraan_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbChanged;
        private System.Windows.Forms.Label labelStart;
        private ISA.Controls.DateTextBox dateStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cekPerkiraan;
        private System.Windows.Forms.CheckBox cekKoneksi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cekDisgn;
    }
}
