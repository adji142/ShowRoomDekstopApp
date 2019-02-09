namespace ISA.Showroom.Finance.DKN
{
    partial class frmDownloadDKNUpdate2:ISA.Controls.BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadDKNUpdate2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpDK = new System.Windows.Forms.GroupBox();
            this.rdoKN = new System.Windows.Forms.RadioButton();
            this.rdoDN = new System.Windows.Forms.RadioButton();
            this.txtNoDKN = new ISA.Controls.CommonTextBox();
            this.dtTanggal = new ISA.Controls.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDari = new System.Windows.Forms.ComboBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdConvert = new ISA.Controls.CommandButton();
            this.grpDK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "No.DKN 00 ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Dari";
            // 
            // grpDK
            // 
            this.grpDK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpDK.Controls.Add(this.rdoKN);
            this.grpDK.Controls.Add(this.rdoDN);
            this.grpDK.Location = new System.Drawing.Point(452, 102);
            this.grpDK.Name = "grpDK";
            this.grpDK.Size = new System.Drawing.Size(100, 37);
            this.grpDK.TabIndex = 13;
            this.grpDK.TabStop = false;
            // 
            // rdoKN
            // 
            this.rdoKN.AutoSize = true;
            this.rdoKN.Location = new System.Drawing.Point(55, 11);
            this.rdoKN.Name = "rdoKN";
            this.rdoKN.Size = new System.Drawing.Size(39, 18);
            this.rdoKN.TabIndex = 1;
            this.rdoKN.TabStop = true;
            this.rdoKN.Text = "KN";
            this.rdoKN.UseVisualStyleBackColor = true;
            // 
            // rdoDN
            // 
            this.rdoDN.AutoSize = true;
            this.rdoDN.Location = new System.Drawing.Point(6, 11);
            this.rdoDN.Name = "rdoDN";
            this.rdoDN.Size = new System.Drawing.Size(39, 18);
            this.rdoDN.TabIndex = 0;
            this.rdoDN.TabStop = true;
            this.rdoDN.Text = "DN";
            this.rdoDN.UseVisualStyleBackColor = true;
            // 
            // txtNoDKN
            // 
            this.txtNoDKN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoDKN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoDKN.Location = new System.Drawing.Point(178, 119);
            this.txtNoDKN.Name = "txtNoDKN";
            this.txtNoDKN.Size = new System.Drawing.Size(100, 20);
            this.txtNoDKN.TabIndex = 10;
            // 
            // dtTanggal
            // 
            this.dtTanggal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtTanggal.DateValue = null;
            this.dtTanggal.Location = new System.Drawing.Point(178, 145);
            this.dtTanggal.MaxLength = 10;
            this.dtTanggal.Name = "dtTanggal";
            this.dtTanggal.Size = new System.Drawing.Size(100, 20);
            this.dtTanggal.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tanggal";
            // 
            // cboDari
            // 
            this.cboDari.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboDari.FormattingEnabled = true;
            this.cboDari.Location = new System.Drawing.Point(452, 145);
            this.cboDari.Name = "cboDari";
            this.cboDari.Size = new System.Drawing.Size(174, 22);
            this.cboDari.TabIndex = 15;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(262, 388);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 16;
            this.cmdSave.Text = "YES";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(377, 388);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 17;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDetail.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.Location = new System.Drawing.Point(92, 196);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetail.Size = new System.Drawing.Size(534, 129);
            this.txtDetail.TabIndex = 18;
            this.txtDetail.WordWrap = false;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.AllowUserToResizeRows = false;
            this.customGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Uraian,
            this.Nominal,
            this.Cabang});
            this.customGridView1.Location = new System.Drawing.Point(92, 208);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(534, 138);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 19;
            this.customGridView1.Visible = false;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 300;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // Cabang
            // 
            this.Cabang.DataPropertyName = "Cabang";
            this.Cabang.HeaderText = "Cabang";
            this.Cabang.Name = "Cabang";
            this.Cabang.ReadOnly = true;
            this.Cabang.Width = 80;
            // 
            // cmdConvert
            // 
            this.cmdConvert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdConvert.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConvert.Location = new System.Drawing.Point(526, 377);
            this.cmdConvert.Name = "cmdConvert";
            this.cmdConvert.Size = new System.Drawing.Size(100, 40);
            this.cmdConvert.TabIndex = 20;
            this.cmdConvert.Text = "commandButton1";
            this.cmdConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdConvert.UseVisualStyleBackColor = true;
            this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
            // 
            // frmDownloadDKNUpdate2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(726, 440);
            this.Controls.Add(this.cmdConvert);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpDK);
            this.Controls.Add(this.txtNoDKN);
            this.Controls.Add(this.dtTanggal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDari);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDownloadDKNUpdate2";
            this.Text = "Input DKN 00";
            this.Title = "Input DKN 00";
            this.Load += new System.EventHandler(this.frmDownloadDKNUpdate2_Load);
            this.Controls.SetChildIndex(this.cboDari, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtTanggal, 0);
            this.Controls.SetChildIndex(this.txtNoDKN, 0);
            this.Controls.SetChildIndex(this.grpDK, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.txtDetail, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdConvert, 0);
            this.grpDK.ResumeLayout(false);
            this.grpDK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpDK;
        private System.Windows.Forms.RadioButton rdoKN;
        private System.Windows.Forms.RadioButton rdoDN;
        private ISA.Controls.CommonTextBox txtNoDKN;
        private ISA.Controls.DateTextBox dtTanggal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDari;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.TextBox txtDetail;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdConvert;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabang;
    }
}
