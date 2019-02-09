using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.DKN
{
	public partial class frmPembebananCabang : ISA.Controls.BaseForm
    {
        private Panel panel1;
        private Panel panel2;
        private ISA.Controls.CustomGridView dgHeader;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CustomGridView dgDetail;
        private ISA.Controls.CommandButton cmdADD1;
        private ISA.Controls.CommandButton cmdEDIT1;
        private ISA.Controls.CommandButton cmdDELETE1;
        private ISA.Controls.CommandButton cmdDELETE2;
        private ISA.Controls.CommandButton cmdEDIT2;
        private ISA.Controls.CommandButton cmdADD2;
        private DataGridViewTextBoxColumn NamaBeban;
        private DataGridViewTextBoxColumn Jenis;
        private DataGridViewTextBoxColumn Tgl_mulai;
        private DataGridViewTextBoxColumn Tgl_berakhir;
        private DataGridViewTextBoxColumn RowID;
        private Button btnDETAIL;
        private Button button1;
        private DataGridViewTextBoxColumn CabangID;
        private DataGridViewTextBoxColumn NamaPT;
        private DataGridViewTextBoxColumn PerusahaanKeRowID;
        private DataGridViewTextBoxColumn JenisTransaksi;
        private DataGridViewTextBoxColumn JenisTransaksiRowID;
        private DataGridViewTextBoxColumn Uraian;
        private DataGridViewTextBoxColumn Nominal;
        private DataGridViewTextBoxColumn TiapTanggal;
        private DataGridViewTextBoxColumn dTgl_berakhir;
        private DataGridViewTextBoxColumn RowID2;
        private DataGridViewTextBoxColumn HeaderRowID;
        private CheckBox checkBerakhir;
    
		public frmPembebananCabang()
		{
			InitializeComponent();
		}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPembebananCabang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDELETE1 = new ISA.Controls.CommandButton();
            this.cmdEDIT1 = new ISA.Controls.CommandButton();
            this.cmdADD1 = new ISA.Controls.CommandButton();
            this.dgHeader = new ISA.Controls.CustomGridView();
            this.NamaBeban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tgl_mulai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tgl_berakhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDETAIL = new System.Windows.Forms.Button();
            this.cmdDELETE2 = new ISA.Controls.CommandButton();
            this.cmdEDIT2 = new ISA.Controls.CommandButton();
            this.cmdADD2 = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.dgDetail = new ISA.Controls.CustomGridView();
            this.checkBerakhir = new System.Windows.Forms.CheckBox();
            this.CabangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerusahaanKeRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisTransaksiRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiapTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTgl_berakhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHeader)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdDELETE1);
            this.panel1.Controls.Add(this.cmdEDIT1);
            this.panel1.Controls.Add(this.cmdADD1);
            this.panel1.Controls.Add(this.dgHeader);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 190);
            this.panel1.TabIndex = 9;
            // 
            // cmdDELETE1
            // 
            this.cmdDELETE1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE1.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE1.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE1.Image")));
            this.cmdDELETE1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE1.Location = new System.Drawing.Point(215, 147);
            this.cmdDELETE1.Name = "cmdDELETE1";
            this.cmdDELETE1.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE1.TabIndex = 3;
            this.cmdDELETE1.Text = "DELETE";
            this.cmdDELETE1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE1.UseVisualStyleBackColor = true;
            this.cmdDELETE1.Click += new System.EventHandler(this.cmdDELETE1_Click);
            // 
            // cmdEDIT1
            // 
            this.cmdEDIT1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT1.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT1.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT1.Image")));
            this.cmdEDIT1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT1.Location = new System.Drawing.Point(109, 146);
            this.cmdEDIT1.Name = "cmdEDIT1";
            this.cmdEDIT1.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT1.TabIndex = 2;
            this.cmdEDIT1.Text = "EDIT";
            this.cmdEDIT1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT1.UseVisualStyleBackColor = true;
            this.cmdEDIT1.Click += new System.EventHandler(this.cmdEDIT1_Click);
            // 
            // cmdADD1
            // 
            this.cmdADD1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD1.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD1.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD1.Image")));
            this.cmdADD1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD1.Location = new System.Drawing.Point(3, 146);
            this.cmdADD1.Name = "cmdADD1";
            this.cmdADD1.Size = new System.Drawing.Size(100, 40);
            this.cmdADD1.TabIndex = 1;
            this.cmdADD1.Text = "ADD";
            this.cmdADD1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD1.UseVisualStyleBackColor = true;
            this.cmdADD1.Click += new System.EventHandler(this.cmdADD1_Click);
            // 
            // dgHeader
            // 
            this.dgHeader.AllowUserToAddRows = false;
            this.dgHeader.AllowUserToDeleteRows = false;
            this.dgHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaBeban,
            this.Jenis,
            this.Tgl_mulai,
            this.Tgl_berakhir,
            this.RowID});
            this.dgHeader.Location = new System.Drawing.Point(3, 2);
            this.dgHeader.MultiSelect = false;
            this.dgHeader.Name = "dgHeader";
            this.dgHeader.ReadOnly = true;
            this.dgHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgHeader.Size = new System.Drawing.Size(831, 138);
            this.dgHeader.StandardTab = true;
            this.dgHeader.TabIndex = 0;
            this.dgHeader.Click += new System.EventHandler(this.dgHeader_Click);
            // 
            // NamaBeban
            // 
            this.NamaBeban.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaBeban.DataPropertyName = "NamaBeban";
            this.NamaBeban.HeaderText = "Nama Pembebanan";
            this.NamaBeban.Name = "NamaBeban";
            this.NamaBeban.ReadOnly = true;
            this.NamaBeban.Width = 125;
            // 
            // Jenis
            // 
            this.Jenis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Jenis.DataPropertyName = "Jenis";
            this.Jenis.HeaderText = "Jenis";
            this.Jenis.Name = "Jenis";
            this.Jenis.ReadOnly = true;
            this.Jenis.Width = 62;
            // 
            // Tgl_mulai
            // 
            this.Tgl_mulai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tgl_mulai.DataPropertyName = "tgl_mulai";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle1.NullValue = "-";
            this.Tgl_mulai.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tgl_mulai.HeaderText = "Tanggal Berlaku";
            this.Tgl_mulai.Name = "Tgl_mulai";
            this.Tgl_mulai.ReadOnly = true;
            this.Tgl_mulai.Width = 109;
            // 
            // Tgl_berakhir
            // 
            this.Tgl_berakhir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tgl_berakhir.DataPropertyName = "tgl_berakhir";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = "-";
            this.Tgl_berakhir.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tgl_berakhir.HeaderText = "Tanggal Berakhir";
            this.Tgl_berakhir.Name = "Tgl_berakhir";
            this.Tgl_berakhir.ReadOnly = true;
            this.Tgl_berakhir.Width = 114;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnDETAIL);
            this.panel2.Controls.Add(this.cmdDELETE2);
            this.panel2.Controls.Add(this.cmdEDIT2);
            this.panel2.Controls.Add(this.cmdADD2);
            this.panel2.Controls.Add(this.cmdCLOSE);
            this.panel2.Controls.Add(this.dgDetail);
            this.panel2.Location = new System.Drawing.Point(12, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 170);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(455, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "LINK NOW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDETAIL
            // 
            this.btnDETAIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDETAIL.Location = new System.Drawing.Point(321, 127);
            this.btnDETAIL.Name = "btnDETAIL";
            this.btnDETAIL.Size = new System.Drawing.Size(128, 39);
            this.btnDETAIL.TabIndex = 7;
            this.btnDETAIL.Text = "JADWAL PEMBEBANAN";
            this.btnDETAIL.UseVisualStyleBackColor = true;
            this.btnDETAIL.Click += new System.EventHandler(this.btnDETAIL_Click);
            // 
            // cmdDELETE2
            // 
            this.cmdDELETE2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE2.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE2.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE2.Image")));
            this.cmdDELETE2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE2.Location = new System.Drawing.Point(215, 126);
            this.cmdDELETE2.Name = "cmdDELETE2";
            this.cmdDELETE2.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE2.TabIndex = 6;
            this.cmdDELETE2.Text = "DELETE";
            this.cmdDELETE2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE2.UseVisualStyleBackColor = true;
            this.cmdDELETE2.Click += new System.EventHandler(this.cmdDELETE2_Click);
            // 
            // cmdEDIT2
            // 
            this.cmdEDIT2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT2.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT2.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT2.Image")));
            this.cmdEDIT2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT2.Location = new System.Drawing.Point(109, 127);
            this.cmdEDIT2.Name = "cmdEDIT2";
            this.cmdEDIT2.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT2.TabIndex = 5;
            this.cmdEDIT2.Text = "EDIT";
            this.cmdEDIT2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT2.UseVisualStyleBackColor = true;
            this.cmdEDIT2.Click += new System.EventHandler(this.cmdEDIT2_Click);
            // 
            // cmdADD2
            // 
            this.cmdADD2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD2.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD2.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD2.Image")));
            this.cmdADD2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD2.Location = new System.Drawing.Point(3, 126);
            this.cmdADD2.Name = "cmdADD2";
            this.cmdADD2.Size = new System.Drawing.Size(100, 40);
            this.cmdADD2.TabIndex = 4;
            this.cmdADD2.Text = "ADD";
            this.cmdADD2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD2.UseVisualStyleBackColor = true;
            this.cmdADD2.Click += new System.EventHandler(this.cmdADD2_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(734, 126);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 1;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click_1);
            // 
            // dgDetail
            // 
            this.dgDetail.AllowUserToAddRows = false;
            this.dgDetail.AllowUserToDeleteRows = false;
            this.dgDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CabangID,
            this.NamaPT,
            this.PerusahaanKeRowID,
            this.JenisTransaksi,
            this.JenisTransaksiRowID,
            this.Uraian,
            this.Nominal,
            this.TiapTanggal,
            this.dTgl_berakhir,
            this.RowID2,
            this.HeaderRowID});
            this.dgDetail.Location = new System.Drawing.Point(3, 3);
            this.dgDetail.MultiSelect = false;
            this.dgDetail.Name = "dgDetail";
            this.dgDetail.ReadOnly = true;
            this.dgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDetail.Size = new System.Drawing.Size(831, 117);
            this.dgDetail.StandardTab = true;
            this.dgDetail.TabIndex = 0;
            // 
            // checkBerakhir
            // 
            this.checkBerakhir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBerakhir.AutoSize = true;
            this.checkBerakhir.Location = new System.Drawing.Point(648, 43);
            this.checkBerakhir.Name = "checkBerakhir";
            this.checkBerakhir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBerakhir.Size = new System.Drawing.Size(198, 18);
            this.checkBerakhir.TabIndex = 11;
            this.checkBerakhir.Text = "Termasuk yang sudah berakhir";
            this.checkBerakhir.UseVisualStyleBackColor = true;
            this.checkBerakhir.CheckedChanged += new System.EventHandler(this.checkBerakhir_CheckedChanged);
            // 
            // CabangID
            // 
            this.CabangID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CabangID.DataPropertyName = "BebanCabangID";
            this.CabangID.HeaderText = "Cabang";
            this.CabangID.Name = "CabangID";
            this.CabangID.ReadOnly = true;
            this.CabangID.Width = 73;
            // 
            // NamaPT
            // 
            this.NamaPT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaPT.DataPropertyName = "BebanNamaPT";
            this.NamaPT.HeaderText = "Nama PT";
            this.NamaPT.Name = "NamaPT";
            this.NamaPT.ReadOnly = true;
            this.NamaPT.Width = 79;
            // 
            // PerusahaanKeRowID
            // 
            this.PerusahaanKeRowID.DataPropertyName = "PerusahaanKeRowID";
            this.PerusahaanKeRowID.HeaderText = "PerusahaanKeRowID";
            this.PerusahaanKeRowID.Name = "PerusahaanKeRowID";
            this.PerusahaanKeRowID.ReadOnly = true;
            this.PerusahaanKeRowID.Visible = false;
            // 
            // JenisTransaksi
            // 
            this.JenisTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JenisTransaksi.DataPropertyName = "JenisTransaksi";
            this.JenisTransaksi.HeaderText = "Jenis Transaksi";
            this.JenisTransaksi.Name = "JenisTransaksi";
            this.JenisTransaksi.ReadOnly = true;
            this.JenisTransaksi.Width = 109;
            // 
            // JenisTransaksiRowID
            // 
            this.JenisTransaksiRowID.DataPropertyName = "JenisTransaksiRowID";
            this.JenisTransaksiRowID.HeaderText = "JenisTransaksiRowID";
            this.JenisTransaksiRowID.Name = "JenisTransaksiRowID";
            this.JenisTransaksiRowID.ReadOnly = true;
            this.JenisTransaksiRowID.Visible = false;
            // 
            // Uraian
            // 
            this.Uraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "Uraian";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 66;
            // 
            // Nominal
            // 
            this.Nominal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nominal.DataPropertyName = "NominalRp";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            this.Nominal.Width = 76;
            // 
            // TiapTanggal
            // 
            this.TiapTanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TiapTanggal.DataPropertyName = "TiapTanggal";
            this.TiapTanggal.HeaderText = "Tiap Tanggal";
            this.TiapTanggal.Name = "TiapTanggal";
            this.TiapTanggal.ReadOnly = true;
            this.TiapTanggal.Width = 92;
            // 
            // dTgl_berakhir
            // 
            this.dTgl_berakhir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dTgl_berakhir.DataPropertyName = "Tgl_berakhir";
            this.dTgl_berakhir.HeaderText = "Tanggal Berakhir";
            this.dTgl_berakhir.Name = "dTgl_berakhir";
            this.dTgl_berakhir.ReadOnly = true;
            this.dTgl_berakhir.Width = 114;
            // 
            // RowID2
            // 
            this.RowID2.DataPropertyName = "RowID";
            this.RowID2.HeaderText = "RowID";
            this.RowID2.Name = "RowID2";
            this.RowID2.ReadOnly = true;
            this.RowID2.Visible = false;
            // 
            // HeaderRowID
            // 
            this.HeaderRowID.DataPropertyName = "HeaderRowID";
            this.HeaderRowID.HeaderText = "HeaderRowID";
            this.HeaderRowID.Name = "HeaderRowID";
            this.HeaderRowID.ReadOnly = true;
            this.HeaderRowID.Visible = false;
            // 
            // frmPembebananCabang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(858, 458);
            this.Controls.Add(this.checkBerakhir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPembebananCabang";
            this.Text = "Pembebanan Cabang";
            this.Title = "Pembebanan Cabang";
            this.Load += new System.EventHandler(this.frmPembebananCabang_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.checkBerakhir, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHeader)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void cmdCLOSE_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdADD1_Click(object sender, EventArgs e)
        {
            DKN.PembebananCabang_detail ifrmChild = new PembebananCabang_detail(this);
            ifrmChild.Show();
        }

        private void cmdEDIT1_Click(object sender, EventArgs e)
        {
            if (dgHeader.Rows.Count > 0)
            {
                Guid RowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DKN.PembebananCabang_detail ifrmChild = new PembebananCabang_detail(this, RowID);
                ifrmChild.Show();
            }
        }

        private void cmdADD2_Click(object sender, EventArgs e)
        {
            if (dgHeader.Rows.Count > 0)
            {
                Guid HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid RowID = Guid.Empty; // empty
                DKN.PembebananCabang_detail ifrmChild = new PembebananCabang_detail(this, HeaderRowID, RowID);
                ifrmChild.Show();
            }
        }

        private void cmdEDIT2_Click(object sender, EventArgs e)
        {
            if (dgDetail.Rows.Count > 0)
            {
                Guid HeaderRowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                Guid RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                DKN.PembebananCabang_detail ifrmChild = new PembebananCabang_detail(this, HeaderRowID, RowID);
                ifrmChild.Show();
            }
        }

        private void frmPembebananCabang_Load(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDataDetail();
        }
        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_PembebananCabang_LIST_BY_Closed"));
                db.Commands[0].Parameters.Add(new Parameter("@Closed", SqlDbType.Bit, checkBerakhir.Checked));
                db.Commands[0].Parameters.Add(new Parameter("@PerusahaanRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                dt = db.Commands[0].ExecuteDataTable();
                dgHeader.DataSource = dt;
            }
        }
        public void RefreshDataDetail()
        {
            if (dgHeader.Rows.Count > 0)
            {
                Guid _HeaderRowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PembebananCabangDetail_LIST_BY_HeaderRowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, _HeaderRowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgDetail.DataSource = dt;
                }
            }
        }

        private void cmdDELETE1_Click(object sender, EventArgs e)
        {
            if (dgHeader.Rows.Count > 0 && dgDetail.Rows.Count == 0)
            {
                if (MessageBox.Show("Hapus data ini?", "Hapus data", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Guid RowID = (Guid)dgHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabang_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshData();
                }
            }
        }

        private void checkBerakhir_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dgHeader_Click(object sender, EventArgs e)
        {
            RefreshDataDetail();
        }

        private void cmdDELETE2_Click(object sender, EventArgs e)
        {
            if (dgDetail.Rows.Count > 0)
            {
                if (MessageBox.Show("Hapus data ini?", "Hapus data", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Guid RowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_PembebananCabangDetail_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    RefreshDataDetail();
                }
            }
        }

        private void btnDETAIL_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(dgHeader.SelectedCells[0].OwningRow.Cells["Jenis"].Value) == "Tidak Tetap")
            {
                Guid _DetailRowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                string _NamaBeban = dgHeader.SelectedCells[0].OwningRow.Cells["NamaBeban"].Value.ToString();
                string _CabangID = dgDetail.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
                string _NamaPT = dgDetail.SelectedCells[0].OwningRow.Cells["NamaPT"].Value.ToString();
                string _Uraian = dgDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                Guid _JenisTransaksi = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["JenisTransaksiRowID"].Value;
                int _TiapTanggal = Convert.ToInt16(dgDetail.SelectedCells[0].OwningRow.Cells["TiapTanggal"].Value);
                frmPembebananCabang_subdetail ifrmChild = new frmPembebananCabang_subdetail(_DetailRowID,_NamaBeban,_CabangID,_NamaPT,_TiapTanggal,_JenisTransaksi,_Uraian);
                ifrmChild.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgHeader.SelectedCells[0].OwningRow.Cells["Jenis"].Value.ToString() == "Tetap")
            {
                int TiapTanggal = Convert.ToInt16(dgDetail.SelectedCells[0].OwningRow.Cells["TiapTanggal"].Value);
                int Bulan = GlobalVar.GetServerDate.Month;
                int Tahun = GlobalVar.GetServerDate.Year;
                if (GlobalVar.GetServerDate.Day < TiapTanggal)
                {
                    if (Bulan == 1)
                    {
                        Bulan = 12;
                        Tahun = Tahun - 1;
                    }
                    else Bulan = Bulan - 1;
                }
                string _TiapTanggal = TiapTanggal.ToString().PadLeft(2, '0');
                string _Bulan = Bulan.ToString().PadLeft(2, '0');
                string _Tahun = Tahun.ToString().PadLeft(4, '0');
                DataTable dt = new DataTable();

                DateTime Tanggal = Convert.ToDateTime(_Tahun + "-" + _Bulan + "-" + _TiapTanggal);
                Guid RowID = (Guid)Guid.NewGuid();
                Guid RefID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["RowID2"].Value;
                Guid PerusahaanKeRowID = GlobalVar.PerusahaanRowID;
                Guid JenisTransaksi = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["JenisTransaksiRowID"].Value;
                string RecordID = GlobalVar.PerusahaanID + GlobalVar.GetServerDate.Year.ToString() + GlobalVar.GetServerDate.Month.ToString() + GlobalVar.GetServerDate.Day.ToString() + GlobalVar.GetServerDate.TimeOfDay.ToString().Substring(0, 8) + SecurityManager.UserInitial;
                string CabangKeID = dgDetail.SelectedCells[0].OwningRow.Cells["CabangID"].Value.ToString();
                string Uraian = dgDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                Double Nominal = Convert.ToDouble(dgDetail.SelectedCells[0].OwningRow.Cells["Nominal"].Value);
                if (Tools.isNull(dgDetail.SelectedCells[0].OwningRow.Cells["PerusahaanKeRowID"].Value, "").ToString() != "")
                {
                    PerusahaanKeRowID = (Guid)dgDetail.SelectedCells[0].OwningRow.Cells["PerusahaanKeRowID"].Value;
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_CEK_RefID"));
                    db.Commands[0].Parameters.Add(new Parameter("@RefID", SqlDbType.UniqueIdentifier, RefID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, Tanggal));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 0)
                    {
                        db.Commands.Clear();

                        db.Commands.Add(db.CreateCommand("usp_HubunganIstimewa_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RefID", SqlDbType.UniqueIdentifier, RefID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Date, Tanggal));
                        db.Commands[0].Parameters.Add(new Parameter("@TipeNota", SqlDbType.TinyInt, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanDariRowID", SqlDbType.UniqueIdentifier, GlobalVar.PerusahaanRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@PerusahaanKeRowID", SqlDbType.UniqueIdentifier, PerusahaanKeRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangDariID", SqlDbType.VarChar, "11"));
                        db.Commands[0].Parameters.Add(new Parameter("@CabangKeID", SqlDbType.VarChar, CabangKeID));
                        db.Commands[0].Parameters.Add(new Parameter("@KelompokTransaksiRowID", SqlDbType.UniqueIdentifier, JenisTransaksi));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, "BEBANCAB_DMNL"));
                        db.Commands[0].ExecuteNonQuery();

                        db.Commands.Clear();

                        db.Commands.Add(db.CreateCommand("usp_HubunganIstimewaDetail_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderRowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Uraian));
                        db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@NominalRp", SqlDbType.Money, Nominal));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Maaf, tombol ini hanya untuk pembebanan tetap saja", "Perhatian!");
            }
        }

    }
}
