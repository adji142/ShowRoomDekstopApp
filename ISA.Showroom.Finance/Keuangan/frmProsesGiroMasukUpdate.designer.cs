namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmProsesGiroMasukUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProsesGiroMasukUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblNoGiro = new System.Windows.Forms.Label();
            this.lblNominal = new System.Windows.Forms.Label();
            this.lblJatuhTempo = new System.Windows.Forms.Label();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTglStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSetor = new System.Windows.Forms.Button();
            this.btnCair = new System.Windows.Forms.Button();
            this.btnTolak = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnBatalCair = new System.Windows.Forms.Button();
            this.btnBatalSetor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(571, 532);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 36;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 37;
            this.label1.Text = "Bank";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "No. Giro";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "Nominal";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "Jatuh Tempo";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 41;
            this.label5.Text = "Riwayat Giro";
            // 
            // lblBank
            // 
            this.lblBank.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBank.Location = new System.Drawing.Point(263, 50);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(268, 14);
            this.lblBank.TabIndex = 43;
            this.lblBank.Text = ".";
            // 
            // lblNoGiro
            // 
            this.lblNoGiro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoGiro.Location = new System.Drawing.Point(263, 80);
            this.lblNoGiro.Name = "lblNoGiro";
            this.lblNoGiro.Size = new System.Drawing.Size(268, 14);
            this.lblNoGiro.TabIndex = 44;
            this.lblNoGiro.Text = ".";
            // 
            // lblNominal
            // 
            this.lblNominal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNominal.Location = new System.Drawing.Point(263, 111);
            this.lblNominal.Name = "lblNominal";
            this.lblNominal.Size = new System.Drawing.Size(268, 14);
            this.lblNominal.TabIndex = 45;
            this.lblNominal.Text = ".";
            // 
            // lblJatuhTempo
            // 
            this.lblJatuhTempo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblJatuhTempo.Location = new System.Drawing.Point(263, 141);
            this.lblJatuhTempo.Name = "lblJatuhTempo";
            this.lblJatuhTempo.Size = new System.Drawing.Size(268, 14);
            this.lblJatuhTempo.TabIndex = 46;
            this.lblJatuhTempo.Text = ".";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Tanggal,
            this.Status,
            this.NamaRekening});
            this.dataGridView1.Location = new System.Drawing.Point(79, 335);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(508, 134);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 49;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "DescStatusGiro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle2;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // NamaRekening
            // 
            this.NamaRekening.DataPropertyName = "NamaRekening";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NamaRekening.DefaultCellStyle = dataGridViewCellStyle3;
            this.NamaRekening.HeaderText = "NamaRekening";
            this.NamaRekening.Name = "NamaRekening";
            this.NamaRekening.ReadOnly = true;
            // 
            // lblTglStatus
            // 
            this.lblTglStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTglStatus.Location = new System.Drawing.Point(263, 193);
            this.lblTglStatus.Name = "lblTglStatus";
            this.lblTglStatus.Size = new System.Drawing.Size(268, 13);
            this.lblTglStatus.TabIndex = 51;
            this.lblTglStatus.Text = "label7";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Location = new System.Drawing.Point(263, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(268, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "label8";
            // 
            // btnSetor
            // 
            this.btnSetor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetor.Location = new System.Drawing.Point(79, 261);
            this.btnSetor.Name = "btnSetor";
            this.btnSetor.Size = new System.Drawing.Size(97, 34);
            this.btnSetor.TabIndex = 53;
            this.btnSetor.Text = "Setor ke Bank";
            this.btnSetor.UseVisualStyleBackColor = true;
            this.btnSetor.Click += new System.EventHandler(this.btnSetor_Click);
            // 
            // btnCair
            // 
            this.btnCair.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCair.Location = new System.Drawing.Point(182, 261);
            this.btnCair.Name = "btnCair";
            this.btnCair.Size = new System.Drawing.Size(97, 34);
            this.btnCair.TabIndex = 54;
            this.btnCair.Text = "Cair";
            this.btnCair.UseVisualStyleBackColor = true;
            this.btnCair.Click += new System.EventHandler(this.btnCair_Click);
            // 
            // btnTolak
            // 
            this.btnTolak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTolak.Location = new System.Drawing.Point(281, 261);
            this.btnTolak.Name = "btnTolak";
            this.btnTolak.Size = new System.Drawing.Size(97, 34);
            this.btnTolak.TabIndex = 55;
            this.btnTolak.Text = "Ditolak";
            this.btnTolak.UseVisualStyleBackColor = true;
            this.btnTolak.Click += new System.EventHandler(this.btnTolak_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatal.Location = new System.Drawing.Point(490, 261);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(97, 34);
            this.btnBatal.TabIndex = 56;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnBatalCair
            // 
            this.btnBatalCair.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatalCair.Location = new System.Drawing.Point(387, 261);
            this.btnBatalCair.Name = "btnBatalCair";
            this.btnBatalCair.Size = new System.Drawing.Size(97, 34);
            this.btnBatalCair.TabIndex = 58;
            this.btnBatalCair.Text = "Batal Cair";
            this.btnBatalCair.UseVisualStyleBackColor = true;
            this.btnBatalCair.Click += new System.EventHandler(this.btnBatalCair_Click);
            // 
            // btnBatalSetor
            // 
            this.btnBatalSetor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatalSetor.Location = new System.Drawing.Point(387, 261);
            this.btnBatalSetor.Name = "btnBatalSetor";
            this.btnBatalSetor.Size = new System.Drawing.Size(97, 34);
            this.btnBatalSetor.TabIndex = 57;
            this.btnBatalSetor.Text = "BatalSetor";
            this.btnBatalSetor.UseVisualStyleBackColor = true;
            this.btnBatalSetor.Click += new System.EventHandler(this.btnBatalSetor_Click);
            // 
            // frmProsesGiroMasukUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(683, 584);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnTolak);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTglStatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblJatuhTempo);
            this.Controls.Add(this.lblNominal);
            this.Controls.Add(this.lblNoGiro);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.btnBatalCair);
            this.Controls.Add(this.btnBatalSetor);
            this.Controls.Add(this.btnCair);
            this.Controls.Add(this.btnSetor);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmProsesGiroMasukUpdate";
            this.Text = "Proses Giro";
            this.Title = "Proses Giro";
            this.Load += new System.EventHandler(this.frmProsesGiroUpdate_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProsesGiroMasukUpdate_FormClosing);
            this.Controls.SetChildIndex(this.btnSetor, 0);
            this.Controls.SetChildIndex(this.btnCair, 0);
            this.Controls.SetChildIndex(this.btnBatalSetor, 0);
            this.Controls.SetChildIndex(this.btnBatalCair, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblBank, 0);
            this.Controls.SetChildIndex(this.lblNoGiro, 0);
            this.Controls.SetChildIndex(this.lblNominal, 0);
            this.Controls.SetChildIndex(this.lblJatuhTempo, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.lblTglStatus, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnTolak, 0);
            this.Controls.SetChildIndex(this.btnBatal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblNoGiro;
        private System.Windows.Forms.Label lblNominal;
        private System.Windows.Forms.Label lblJatuhTempo;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.Label lblTglStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSetor;
        private System.Windows.Forms.Button btnCair;
        private System.Windows.Forms.Button btnTolak;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnBatalCair;
        private System.Windows.Forms.Button btnBatalSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaRekening;
    }
}
