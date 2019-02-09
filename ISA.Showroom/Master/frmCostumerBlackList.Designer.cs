namespace ISA.Showroom.Master
{
    partial class frmCostumerBlackList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostumerBlackList));
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoIdentitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatDom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pekerjaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBlackList = new System.Windows.Forms.Button();
            this.btnUnblacklist = new System.Windows.Forms.Button();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.CustRowID,
            this.Nama,
            this.Identitas,
            this.NoIdentitas,
            this.AlamatIdt,
            this.AlamatDom,
            this.NoTelp,
            this.NoHP,
            this.Pekerjaan,
            this.Keterangan});
            this.dataGridView1.Location = new System.Drawing.Point(28, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(654, 237);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 26;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // CustRowID
            // 
            this.CustRowID.DataPropertyName = "CustRowID";
            this.CustRowID.HeaderText = "CustRowID";
            this.CustRowID.Name = "CustRowID";
            this.CustRowID.ReadOnly = true;
            this.CustRowID.Visible = false;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama Customer";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 150;
            // 
            // Identitas
            // 
            this.Identitas.DataPropertyName = "Identitas";
            this.Identitas.HeaderText = "Identitas";
            this.Identitas.Name = "Identitas";
            this.Identitas.ReadOnly = true;
            // 
            // NoIdentitas
            // 
            this.NoIdentitas.DataPropertyName = "NoIdentitas";
            this.NoIdentitas.HeaderText = "No. Identitas";
            this.NoIdentitas.Name = "NoIdentitas";
            this.NoIdentitas.ReadOnly = true;
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
            this.AlamatDom.Visible = false;
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
            // Pekerjaan
            // 
            this.Pekerjaan.DataPropertyName = "Pekerjaan";
            this.Pekerjaan.HeaderText = "Pekerjaan";
            this.Pekerjaan.Name = "Pekerjaan";
            this.Pekerjaan.ReadOnly = true;
            this.Pekerjaan.Visible = false;
            // 
            // Keterangan
            // 
            this.Keterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            // 
            // btnBlackList
            // 
            this.btnBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBlackList.Location = new System.Drawing.Point(28, 320);
            this.btnBlackList.Name = "btnBlackList";
            this.btnBlackList.Size = new System.Drawing.Size(100, 40);
            this.btnBlackList.TabIndex = 30;
            this.btnBlackList.Text = "BLACKLIST";
            this.btnBlackList.UseVisualStyleBackColor = true;
            this.btnBlackList.Click += new System.EventHandler(this.btnBlackList_Click);
            // 
            // btnUnblacklist
            // 
            this.btnUnblacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnblacklist.Location = new System.Drawing.Point(134, 320);
            this.btnUnblacklist.Name = "btnUnblacklist";
            this.btnUnblacklist.Size = new System.Drawing.Size(100, 40);
            this.btnUnblacklist.TabIndex = 31;
            this.btnUnblacklist.Text = "UNBLACKLIST";
            this.btnUnblacklist.UseVisualStyleBackColor = true;
            this.btnUnblacklist.Click += new System.EventHandler(this.btnUnblacklist_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(582, 318);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 29;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // frmCostumerBlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 405);
            this.Controls.Add(this.btnUnblacklist);
            this.Controls.Add(this.btnBlackList);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdCLOSE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCostumerBlackList";
            this.Text = "Customer Blacklist";
            this.Title = "Customer Blacklist";
            this.Load += new System.EventHandler(this.frmCostumerBlackList_Load);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnBlackList, 0);
            this.Controls.SetChildIndex(this.btnUnblacklist, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Button btnBlackList;
        private System.Windows.Forms.Button btnUnblacklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoIdentitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatDom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pekerjaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;

    }
}