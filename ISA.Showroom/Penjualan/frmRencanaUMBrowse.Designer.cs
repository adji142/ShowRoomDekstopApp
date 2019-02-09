namespace ISA.Showroom.Penjualan
{
    partial class frmRencanaUMBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRencanaUMBrowse));
            this.dgDetailCTP = new ISA.Controls.CustomGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailCTP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDetailCTP
            // 
            this.dgDetailCTP.AllowUserToAddRows = false;
            this.dgDetailCTP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgDetailCTP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDetailCTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetailCTP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDetailCTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetailCTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.Nominal,
            this.Uraian});
            this.dgDetailCTP.Location = new System.Drawing.Point(26, 67);
            this.dgDetailCTP.Name = "dgDetailCTP";
            this.dgDetailCTP.ReadOnly = true;
            this.dgDetailCTP.RowHeadersVisible = false;
            this.dgDetailCTP.Size = new System.Drawing.Size(791, 239);
            this.dgDetailCTP.StandardTab = true;
            this.dgDetailCTP.TabIndex = 79;
            // 
            // Tanggal
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            this.Tanggal.Width = 120;
            // 
            // Nominal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            this.Nominal.Width = 120;
            // 
            // Uraian
            // 
            this.Uraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(387, 335);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 80;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // frmRencanaUMBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 387);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.dgDetailCTP);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRencanaUMBrowse";
            this.Text = "Rencana UM";
            this.Title = "Rencana UM";
            this.Load += new System.EventHandler(this.frmRencanaUMBrowse_Load);
            this.Controls.SetChildIndex(this.dgDetailCTP, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailCTP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgDetailCTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private ISA.Controls.CommandButton cmdCLOSE;
    }
}