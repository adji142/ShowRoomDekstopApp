namespace ISA.Showroom.Penjualan
{
    partial class frmTitipanAdjustmentBrowseAngsuran
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgAngsuran = new ISA.Controls.CustomGridView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenjRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenjHistRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nopol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bunga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalPokok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAngsuran)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAngsuran
            // 
            this.dgAngsuran.AllowUserToAddRows = false;
            this.dgAngsuran.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgAngsuran.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAngsuran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAngsuran.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgAngsuran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAngsuran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.PenjRowID,
            this.PenjHistRowID,
            this.Tanggal,
            this.NoAR,
            this.NoBukti,
            this.NoTrans,
            this.Nopol,
            this.Nominal,
            this.Bunga,
            this.NominalPokok,
            this.Uraian,
            this.Denda});
            this.dgAngsuran.Location = new System.Drawing.Point(31, 69);
            this.dgAngsuran.Name = "dgAngsuran";
            this.dgAngsuran.ReadOnly = true;
            this.dgAngsuran.RowHeadersVisible = false;
            this.dgAngsuran.Size = new System.Drawing.Size(484, 252);
            this.dgAngsuran.StandardTab = true;
            this.dgAngsuran.TabIndex = 5;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = global::ISA.Showroom.Properties.Resources.Close32;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(414, 335);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(101, 48);
            this.cmdClose.TabIndex = 20;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOK.Image = global::ISA.Showroom.Properties.Resources.Ok321;
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(31, 335);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(89, 48);
            this.cmdOK.TabIndex = 19;
            this.cmdOK.Text = "OK";
            this.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // PenjRowID
            // 
            this.PenjRowID.DataPropertyName = "PenjRowID";
            this.PenjRowID.HeaderText = "PenjRowID";
            this.PenjRowID.Name = "PenjRowID";
            this.PenjRowID.ReadOnly = true;
            this.PenjRowID.Visible = false;
            // 
            // PenjHistRowID
            // 
            this.PenjHistRowID.DataPropertyName = "PenjHistRowID";
            this.PenjHistRowID.HeaderText = "PenjHistRowID";
            this.PenjHistRowID.Name = "PenjHistRowID";
            this.PenjHistRowID.ReadOnly = true;
            this.PenjHistRowID.Visible = false;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // NoAR
            // 
            this.NoAR.DataPropertyName = "NoAR";
            this.NoAR.HeaderText = "NoAR";
            this.NoAR.Name = "NoAR";
            this.NoAR.ReadOnly = true;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "NoBukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // NoTrans
            // 
            this.NoTrans.DataPropertyName = "NoTrans";
            this.NoTrans.HeaderText = "NoTrans";
            this.NoTrans.Name = "NoTrans";
            this.NoTrans.ReadOnly = true;
            // 
            // Nopol
            // 
            this.Nopol.DataPropertyName = "Nopol";
            this.Nopol.HeaderText = "Nopol";
            this.Nopol.Name = "Nopol";
            this.Nopol.ReadOnly = true;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // Bunga
            // 
            this.Bunga.DataPropertyName = "Bunga";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Bunga.DefaultCellStyle = dataGridViewCellStyle4;
            this.Bunga.HeaderText = "Bunga";
            this.Bunga.Name = "Bunga";
            this.Bunga.ReadOnly = true;
            // 
            // NominalPokok
            // 
            this.NominalPokok.DataPropertyName = "NominalPokok";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.NominalPokok.DefaultCellStyle = dataGridViewCellStyle5;
            this.NominalPokok.HeaderText = "NominalPokok";
            this.NominalPokok.Name = "NominalPokok";
            this.NominalPokok.ReadOnly = true;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            // 
            // Denda
            // 
            this.Denda.DataPropertyName = "Denda";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Denda.DefaultCellStyle = dataGridViewCellStyle6;
            this.Denda.HeaderText = "Denda";
            this.Denda.Name = "Denda";
            this.Denda.ReadOnly = true;
            // 
            // frmTitipanAdjustmentBrowseAngsuran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 395);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.dgAngsuran);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTitipanAdjustmentBrowseAngsuran";
            this.Text = "Browse Titipan";
            this.Title = "Browse Titipan";
            this.Load += new System.EventHandler(this.frmTitipanAdjustmentBrowseAngsuran_Load);
            this.Controls.SetChildIndex(this.dgAngsuran, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgAngsuran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgAngsuran;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenjHistRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nopol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bunga;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalPokok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denda;
    }
}