namespace ISA.Showroom.Penjualan
{
    partial class frmKomisiBrowse
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
            this.GVMain = new ISA.Controls.CustomGridView();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoBukti = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pnlEditKomisi = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEditKomisiAfter = new ISA.Controls.NumericTextBox();
            this.txtEditKomisiBefore = new ISA.Controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEditNoBukti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEditNoTransaksi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnEditOK = new System.Windows.Forms.Button();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoBKK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglBKK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFixed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GVMain)).BeginInit();
            this.pnlEditKomisi.SuspendLayout();
            this.SuspendLayout();
            // 
            // GVMain
            // 
            this.GVMain.AllowUserToAddRows = false;
            this.GVMain.AllowUserToDeleteRows = false;
            this.GVMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GVMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NoTransaksi,
            this.NoBukti,
            this.Tanggal,
            this.Status,
            this.Nominal,
            this.NoBKK,
            this.TglBKK,
            this.Customer,
            this.Sales,
            this.IsFixed});
            this.GVMain.Location = new System.Drawing.Point(29, 93);
            this.GVMain.Name = "GVMain";
            this.GVMain.ReadOnly = true;
            this.GVMain.RowHeadersVisible = false;
            this.GVMain.Size = new System.Drawing.Size(751, 273);
            this.GVMain.StandardTab = true;
            this.GVMain.TabIndex = 5;
            this.GVMain.SelectionRowChanged += new System.EventHandler(this.GVMain_SelectionRowChanged);
            this.GVMain.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GVMain_RowsAdded);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(138, 65);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tanggal Penjualan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter NoBukti";
            // 
            // txtNoBukti
            // 
            this.txtNoBukti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoBukti.Location = new System.Drawing.Point(487, 66);
            this.txtNoBukti.Name = "txtNoBukti";
            this.txtNoBukti.Size = new System.Drawing.Size(212, 20);
            this.txtNoBukti.TabIndex = 9;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(705, 64);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "Tampilkan";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(29, 396);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(109, 39);
            this.btnProcess.TabIndex = 11;
            this.btnProcess.Text = "Proses";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(671, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 39);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(144, 396);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 39);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 372);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(205, 18);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Tampilkan yang belum di proses";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pnlEditKomisi
            // 
            this.pnlEditKomisi.Controls.Add(this.label7);
            this.pnlEditKomisi.Controls.Add(this.label6);
            this.pnlEditKomisi.Controls.Add(this.txtEditKomisiAfter);
            this.pnlEditKomisi.Controls.Add(this.txtEditKomisiBefore);
            this.pnlEditKomisi.Controls.Add(this.label5);
            this.pnlEditKomisi.Controls.Add(this.txtEditNoBukti);
            this.pnlEditKomisi.Controls.Add(this.label4);
            this.pnlEditKomisi.Controls.Add(this.txtEditNoTransaksi);
            this.pnlEditKomisi.Controls.Add(this.label3);
            this.pnlEditKomisi.Controls.Add(this.btnEditCancel);
            this.pnlEditKomisi.Controls.Add(this.btnEditOK);
            this.pnlEditKomisi.Location = new System.Drawing.Point(259, 201);
            this.pnlEditKomisi.Name = "pnlEditKomisi";
            this.pnlEditKomisi.Size = new System.Drawing.Size(462, 213);
            this.pnlEditKomisi.TabIndex = 15;
            this.pnlEditKomisi.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(421, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Edit Komisi";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Komisi Baru";
            // 
            // txtEditKomisiAfter
            // 
            this.txtEditKomisiAfter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditKomisiAfter.Location = new System.Drawing.Point(155, 128);
            this.txtEditKomisiAfter.Name = "txtEditKomisiAfter";
            this.txtEditKomisiAfter.Size = new System.Drawing.Size(290, 20);
            this.txtEditKomisiAfter.TabIndex = 9;
            this.txtEditKomisiAfter.Text = "0";
            // 
            // txtEditKomisiBefore
            // 
            this.txtEditKomisiBefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditKomisiBefore.Location = new System.Drawing.Point(155, 101);
            this.txtEditKomisiBefore.Name = "txtEditKomisiBefore";
            this.txtEditKomisiBefore.ReadOnly = true;
            this.txtEditKomisiBefore.Size = new System.Drawing.Size(290, 20);
            this.txtEditKomisiBefore.TabIndex = 8;
            this.txtEditKomisiBefore.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Komisi Sebelumnya";
            // 
            // txtEditNoBukti
            // 
            this.txtEditNoBukti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditNoBukti.Location = new System.Drawing.Point(155, 75);
            this.txtEditNoBukti.Name = "txtEditNoBukti";
            this.txtEditNoBukti.ReadOnly = true;
            this.txtEditNoBukti.Size = new System.Drawing.Size(290, 20);
            this.txtEditNoBukti.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "No. Bukti";
            // 
            // txtEditNoTransaksi
            // 
            this.txtEditNoTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditNoTransaksi.Location = new System.Drawing.Point(155, 50);
            this.txtEditNoTransaksi.Name = "txtEditNoTransaksi";
            this.txtEditNoTransaksi.ReadOnly = true;
            this.txtEditNoTransaksi.Size = new System.Drawing.Size(290, 20);
            this.txtEditNoTransaksi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "No. Transaksi";
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCancel.Location = new System.Drawing.Point(289, 171);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(75, 27);
            this.btnEditCancel.TabIndex = 1;
            this.btnEditCancel.Text = "Cancel";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEdit_Clicked);
            // 
            // btnEditOK
            // 
            this.btnEditOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOK.Location = new System.Drawing.Point(370, 171);
            this.btnEditOK.Name = "btnEditOK";
            this.btnEditOK.Size = new System.Drawing.Size(75, 27);
            this.btnEditOK.TabIndex = 0;
            this.btnEditOK.Text = "OK";
            this.btnEditOK.UseVisualStyleBackColor = true;
            this.btnEditOK.Click += new System.EventHandler(this.btnEdit_Clicked);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NoTransaksi
            // 
            this.NoTransaksi.DataPropertyName = "NoTransaksi";
            this.NoTransaksi.HeaderText = "No. Transaksi";
            this.NoTransaksi.Name = "NoTransaksi";
            this.NoTransaksi.ReadOnly = true;
            // 
            // NoBukti
            // 
            this.NoBukti.DataPropertyName = "NoBukti";
            this.NoBukti.HeaderText = "No. Bukti";
            this.NoBukti.Name = "NoBukti";
            this.NoBukti.ReadOnly = true;
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tgl";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.Tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // NoBKK
            // 
            this.NoBKK.DataPropertyName = "NoBKK";
            this.NoBKK.HeaderText = "No. BKK";
            this.NoBKK.Name = "NoBKK";
            this.NoBKK.ReadOnly = true;
            // 
            // TglBKK
            // 
            this.TglBKK.DataPropertyName = "TglBKK";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.TglBKK.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglBKK.HeaderText = "Tgl. BKK";
            this.TglBKK.Name = "TglBKK";
            this.TglBKK.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // Sales
            // 
            this.Sales.DataPropertyName = "Sales";
            this.Sales.HeaderText = "Sales";
            this.Sales.Name = "Sales";
            this.Sales.ReadOnly = true;
            // 
            // IsFixed
            // 
            this.IsFixed.DataPropertyName = "IsFixed";
            this.IsFixed.HeaderText = "IsFixed";
            this.IsFixed.Name = "IsFixed";
            this.IsFixed.ReadOnly = true;
            this.IsFixed.Visible = false;
            // 
            // frmKomisiBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(809, 456);
            this.Controls.Add(this.pnlEditKomisi);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.GVMain);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoBukti);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProcess);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKomisiBrowse";
            this.Text = "Proses Komisi";
            this.Title = "Proses Komisi";
            this.Load += new System.EventHandler(this.frmKomisiBrowse_Load);
            this.Controls.SetChildIndex(this.btnProcess, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnShow, 0);
            this.Controls.SetChildIndex(this.txtNoBukti, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.GVMain, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.pnlEditKomisi, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GVMain)).EndInit();
            this.pnlEditKomisi.ResumeLayout(false);
            this.pnlEditKomisi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView GVMain;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoBukti;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel pnlEditKomisi;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnEditOK;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.NumericTextBox txtEditKomisiBefore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEditNoBukti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditNoTransaksi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.NumericTextBox txtEditKomisiAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBKK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglBKK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFixed;
    }
}
