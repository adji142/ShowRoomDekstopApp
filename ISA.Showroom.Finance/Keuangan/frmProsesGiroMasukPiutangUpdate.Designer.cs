namespace ISA.Showroom.Finance.Keuangan
{
    partial class frmProsesGiroMasukPiutangUpdate
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
            this.label8 = new System.Windows.Forms.Label();
            this.lblTglStatus = new System.Windows.Forms.Label();
            this.lblNominalBGC = new System.Windows.Forms.Label();
            this.lblNominal = new System.Windows.Forms.Label();
            this.lblCabangID = new System.Windows.Forms.Label();
            this.lblCustomerRowID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnTolak = new System.Windows.Forms.Button();
            this.btnBatalCair = new System.Windows.Forms.Button();
            this.btnBatalSetor = new System.Windows.Forms.Button();
            this.btnCair = new System.Windows.Forms.Button();
            this.btnSetor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTglJTBGC = new System.Windows.Forms.Label();
            this.lblNoBGC = new System.Windows.Forms.Label();
            this.lblNoTrans = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Location = new System.Drawing.Point(309, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(313, 14);
            this.label8.TabIndex = 62;
            this.label8.Text = "label8";
            // 
            // lblTglStatus
            // 
            this.lblTglStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTglStatus.Location = new System.Drawing.Point(309, 259);
            this.lblTglStatus.Name = "lblTglStatus";
            this.lblTglStatus.Size = new System.Drawing.Size(313, 14);
            this.lblTglStatus.TabIndex = 61;
            this.lblTglStatus.Text = "label7";
            // 
            // lblNominalBGC
            // 
            this.lblNominalBGC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNominalBGC.Location = new System.Drawing.Point(309, 164);
            this.lblNominalBGC.Name = "lblNominalBGC";
            this.lblNominalBGC.Size = new System.Drawing.Size(313, 15);
            this.lblNominalBGC.TabIndex = 60;
            this.lblNominalBGC.Text = ".";
            // 
            // lblNominal
            // 
            this.lblNominal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNominal.Location = new System.Drawing.Point(309, 132);
            this.lblNominal.Name = "lblNominal";
            this.lblNominal.Size = new System.Drawing.Size(313, 15);
            this.lblNominal.TabIndex = 59;
            this.lblNominal.Text = ".";
            this.lblNominal.Click += new System.EventHandler(this.lblNominal_Click);
            // 
            // lblCabangID
            // 
            this.lblCabangID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCabangID.Location = new System.Drawing.Point(309, 98);
            this.lblCabangID.Name = "lblCabangID";
            this.lblCabangID.Size = new System.Drawing.Size(313, 15);
            this.lblCabangID.TabIndex = 58;
            this.lblCabangID.Text = ".";
            // 
            // lblCustomerRowID
            // 
            this.lblCustomerRowID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCustomerRowID.Location = new System.Drawing.Point(309, 69);
            this.lblCustomerRowID.Name = "lblCustomerRowID";
            this.lblCustomerRowID.Size = new System.Drawing.Size(313, 15);
            this.lblCustomerRowID.TabIndex = 57;
            this.lblCustomerRowID.Text = ".";
            this.lblCustomerRowID.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 56;
            this.label4.Text = "NominalBGC";
            // 
            // btnBatal
            // 
            this.btnBatal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatal.Location = new System.Drawing.Point(556, 299);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(113, 37);
            this.btnBatal.TabIndex = 66;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnTolak
            // 
            this.btnTolak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTolak.Location = new System.Drawing.Point(312, 299);
            this.btnTolak.Name = "btnTolak";
            this.btnTolak.Size = new System.Drawing.Size(113, 37);
            this.btnTolak.TabIndex = 65;
            this.btnTolak.Text = "Ditolak";
            this.btnTolak.UseVisualStyleBackColor = true;
            this.btnTolak.Click += new System.EventHandler(this.btnTolak_Click);
            // 
            // btnBatalCair
            // 
            this.btnBatalCair.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatalCair.Location = new System.Drawing.Point(436, 299);
            this.btnBatalCair.Name = "btnBatalCair";
            this.btnBatalCair.Size = new System.Drawing.Size(113, 37);
            this.btnBatalCair.TabIndex = 68;
            this.btnBatalCair.Text = "Batal Cair";
            this.btnBatalCair.UseVisualStyleBackColor = true;
            this.btnBatalCair.Click += new System.EventHandler(this.btnBatalCair_Click);
            // 
            // btnBatalSetor
            // 
            this.btnBatalSetor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBatalSetor.Location = new System.Drawing.Point(436, 299);
            this.btnBatalSetor.Name = "btnBatalSetor";
            this.btnBatalSetor.Size = new System.Drawing.Size(113, 37);
            this.btnBatalSetor.TabIndex = 67;
            this.btnBatalSetor.Text = "BatalSetor";
            this.btnBatalSetor.UseVisualStyleBackColor = true;
            this.btnBatalSetor.Click += new System.EventHandler(this.btnBatalSetor_Click);
            // 
            // btnCair
            // 
            this.btnCair.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCair.Location = new System.Drawing.Point(197, 299);
            this.btnCair.Name = "btnCair";
            this.btnCair.Size = new System.Drawing.Size(113, 37);
            this.btnCair.TabIndex = 64;
            this.btnCair.Text = "Cair";
            this.btnCair.UseVisualStyleBackColor = true;
            this.btnCair.Click += new System.EventHandler(this.btnCair_Click);
            // 
            // btnSetor
            // 
            this.btnSetor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetor.Location = new System.Drawing.Point(76, 299);
            this.btnSetor.Name = "btnSetor";
            this.btnSetor.Size = new System.Drawing.Size(113, 37);
            this.btnSetor.TabIndex = 63;
            this.btnSetor.Text = "Setor ke Bank";
            this.btnSetor.UseVisualStyleBackColor = true;
            this.btnSetor.Click += new System.EventHandler(this.btnSetor_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 14);
            this.label6.TabIndex = 69;
            this.label6.Text = "Riwayat Giro";
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
            this.dataGridView1.Location = new System.Drawing.Point(73, 403);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(593, 144);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 70;
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 71;
            this.label1.Text = "CustomerRowID";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 72;
            this.label2.Text = "CabangID";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 73;
            this.label3.Text = "Nominal";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 74;
            this.label5.Text = "TglJTBGC";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 75;
            this.label7.Text = "NoBGC";
            // 
            // lblTglJTBGC
            // 
            this.lblTglJTBGC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTglJTBGC.Location = new System.Drawing.Point(309, 197);
            this.lblTglJTBGC.Name = "lblTglJTBGC";
            this.lblTglJTBGC.Size = new System.Drawing.Size(313, 15);
            this.lblTglJTBGC.TabIndex = 76;
            this.lblTglJTBGC.Text = ".";
            // 
            // lblNoBGC
            // 
            this.lblNoBGC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoBGC.Location = new System.Drawing.Point(309, 227);
            this.lblNoBGC.Name = "lblNoBGC";
            this.lblNoBGC.Size = new System.Drawing.Size(313, 15);
            this.lblNoBGC.TabIndex = 77;
            this.lblNoBGC.Text = ".";
            // 
            // lblNoTrans
            // 
            this.lblNoTrans.AutoSize = true;
            this.lblNoTrans.Location = new System.Drawing.Point(103, 50);
            this.lblNoTrans.Name = "lblNoTrans";
            this.lblNoTrans.Size = new System.Drawing.Size(39, 14);
            this.lblNoTrans.TabIndex = 78;
            this.lblNoTrans.Text = "label9";
            // 
            // frmProsesGiroMasukPiutangUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 592);
            this.Controls.Add(this.lblNoTrans);
            this.Controls.Add(this.lblNoBGC);
            this.Controls.Add(this.lblTglJTBGC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnTolak);
            this.Controls.Add(this.btnBatalCair);
            this.Controls.Add(this.btnBatalSetor);
            this.Controls.Add(this.btnCair);
            this.Controls.Add(this.btnSetor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTglStatus);
            this.Controls.Add(this.lblNominalBGC);
            this.Controls.Add(this.lblNominal);
            this.Controls.Add(this.lblCabangID);
            this.Controls.Add(this.lblCustomerRowID);
            this.Controls.Add(this.label4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmProsesGiroMasukPiutangUpdate";
            this.Text = "Proses Giro Masuk (Piutang Usaha)";
            this.Title = "Proses Giro Masuk (Piutang Usaha)";
            this.Load += new System.EventHandler(this.frmProsesGiroUpdate_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProsesGiroMasukPiutangUpdate_FormClosing);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblCustomerRowID, 0);
            this.Controls.SetChildIndex(this.lblCabangID, 0);
            this.Controls.SetChildIndex(this.lblNominal, 0);
            this.Controls.SetChildIndex(this.lblNominalBGC, 0);
            this.Controls.SetChildIndex(this.lblTglStatus, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnSetor, 0);
            this.Controls.SetChildIndex(this.btnCair, 0);
            this.Controls.SetChildIndex(this.btnBatalSetor, 0);
            this.Controls.SetChildIndex(this.btnBatalCair, 0);
            this.Controls.SetChildIndex(this.btnTolak, 0);
            this.Controls.SetChildIndex(this.btnBatal, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblTglJTBGC, 0);
            this.Controls.SetChildIndex(this.lblNoBGC, 0);
            this.Controls.SetChildIndex(this.lblNoTrans, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTglStatus;
        private System.Windows.Forms.Label lblNominalBGC;
        private System.Windows.Forms.Label lblNominal;
        private System.Windows.Forms.Label lblCabangID;
        private System.Windows.Forms.Label lblCustomerRowID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnTolak;
        private System.Windows.Forms.Button btnBatalCair;
        private System.Windows.Forms.Button btnBatalSetor;
        private System.Windows.Forms.Button btnCair;
        private System.Windows.Forms.Button btnSetor;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.CustomGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaRekening;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTglJTBGC;
        private System.Windows.Forms.Label lblNoBGC;
        private System.Windows.Forms.Label lblNoTrans;
    }
}