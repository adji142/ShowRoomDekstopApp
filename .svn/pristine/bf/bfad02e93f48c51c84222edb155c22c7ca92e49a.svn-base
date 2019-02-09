using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.Windows.Forms;

namespace ISA.Showroom.Finance.Keuangan
{
	public partial class frmKoreksiKeuanganHistory : ISA.Controls.BaseForm
	{
        Guid _TransRowID;
        String _Sumber;

        private ISA.Controls.CustomGridView customGridView1;
        private Panel panel1;
        private ISA.Controls.CommonTextBox txtNoBukti;
        private Label label3;
        private Label label1;
        private ISA.Controls.DateTextBox txtTanggal;
        private Label label2;
        private Label label8;
        private ISA.Controls.NumericTextBox txtNominal;
        private Label label7;
        private ISA.Controls.CommonTextBox txtJnsTransaksi;
        private Label label6;
        private Label label5;
        private ISA.Controls.CommonTextBox txtBank;
        private ISA.Controls.CommonTextBox txtCabang;
        private Label label4;
        private ISA.Controls.CommonTextBox txtUraian;
        private DataGridViewTextBoxColumn dTanggal;
        private DataGridViewTextBoxColumn cCabang;
        private DataGridViewTextBoxColumn cJnsTransaksi;
        private DataGridViewTextBoxColumn cNamaTransaksi;
        private DataGridViewTextBoxColumn cBank;
        private DataGridViewTextBoxColumn cNoRekening;
        private DataGridViewTextBoxColumn cNamaRekening;
        private ISA.Controls.CommandButton cmdCLOSE;
    
		public frmKoreksiKeuanganHistory(Guid TransRowID, string Sumber)
		{
			InitializeComponent();
            _TransRowID = TransRowID;
            _Sumber = Sumber;
		}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKoreksiKeuanganHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNominal = new ISA.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtJnsTransaksi = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBank = new ISA.Controls.CommonTextBox();
            this.txtCabang = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.txtNoBukti = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCabang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJnsTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNamaTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNamaRekening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(580, 405);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 5;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dTanggal,
            this.cCabang,
            this.cJnsTransaksi,
            this.cNamaTransaksi,
            this.cBank,
            this.cNoRekening,
            this.cNamaRekening});
            this.customGridView1.Location = new System.Drawing.Point(31, 250);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(649, 139);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNominal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtJnsTransaksi);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtBank);
            this.panel1.Controls.Add(this.txtCabang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtUraian);
            this.panel1.Controls.Add(this.txtNoBukti);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTanggal);
            this.panel1.Location = new System.Drawing.Point(31, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 144);
            this.panel1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "Nominal";
            // 
            // txtNominal
            // 
            this.txtNominal.Location = new System.Drawing.Point(114, 76);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.ReadOnly = true;
            this.txtNominal.Size = new System.Drawing.Size(108, 20);
            this.txtNominal.TabIndex = 12;
            this.txtNominal.Text = "0";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Jenis transaksi";
            // 
            // txtJnsTransaksi
            // 
            this.txtJnsTransaksi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJnsTransaksi.Location = new System.Drawing.Point(369, 75);
            this.txtJnsTransaksi.Name = "txtJnsTransaksi";
            this.txtJnsTransaksi.ReadOnly = true;
            this.txtJnsTransaksi.Size = new System.Drawing.Size(216, 20);
            this.txtJnsTransaksi.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bank";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cabang";
            // 
            // txtBank
            // 
            this.txtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBank.Location = new System.Drawing.Point(369, 49);
            this.txtBank.Name = "txtBank";
            this.txtBank.ReadOnly = true;
            this.txtBank.Size = new System.Drawing.Size(218, 20);
            this.txtBank.TabIndex = 7;
            // 
            // txtCabang
            // 
            this.txtCabang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCabang.Location = new System.Drawing.Point(369, 23);
            this.txtCabang.Name = "txtCabang";
            this.txtCabang.ReadOnly = true;
            this.txtCabang.Size = new System.Drawing.Size(218, 20);
            this.txtCabang.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Keterangan";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(111, 105);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.ReadOnly = true;
            this.txtUraian.Size = new System.Drawing.Size(474, 20);
            this.txtUraian.TabIndex = 4;
            // 
            // txtNoBukti
            // 
            this.txtNoBukti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoBukti.Location = new System.Drawing.Point(114, 49);
            this.txtNoBukti.Name = "txtNoBukti";
            this.txtNoBukti.ReadOnly = true;
            this.txtNoBukti.Size = new System.Drawing.Size(108, 20);
            this.txtNoBukti.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nomor bukti";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanggal transaksi";
            // 
            // txtTanggal
            // 
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(114, 23);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.ReadOnly = true;
            this.txtTanggal.Size = new System.Drawing.Size(108, 20);
            this.txtTanggal.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Riwayat Koreksi";
            // 
            // dTanggal
            // 
            this.dTanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.dTanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.dTanggal.HeaderText = "Tanggal";
            this.dTanggal.Name = "dTanggal";
            this.dTanggal.ReadOnly = true;
            // 
            // cCabang
            // 
            this.cCabang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cCabang.DataPropertyName = "CabangKe";
            this.cCabang.HeaderText = "Cabang";
            this.cCabang.Name = "cCabang";
            this.cCabang.ReadOnly = true;
            this.cCabang.Width = 73;
            // 
            // cJnsTransaksi
            // 
            this.cJnsTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cJnsTransaksi.DataPropertyName = "JnsTransaksi";
            this.cJnsTransaksi.HeaderText = "Jenis Transaksi";
            this.cJnsTransaksi.Name = "cJnsTransaksi";
            this.cJnsTransaksi.ReadOnly = true;
            this.cJnsTransaksi.Width = 110;
            // 
            // cNamaTransaksi
            // 
            this.cNamaTransaksi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNamaTransaksi.DataPropertyName = "NamaTransaksi";
            this.cNamaTransaksi.HeaderText = "Nama Transaksi";
            this.cNamaTransaksi.Name = "cNamaTransaksi";
            this.cNamaTransaksi.ReadOnly = true;
            this.cNamaTransaksi.Width = 110;
            // 
            // cBank
            // 
            this.cBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cBank.DataPropertyName = "NamaBank";
            this.cBank.HeaderText = "Bank";
            this.cBank.Name = "cBank";
            this.cBank.ReadOnly = true;
            this.cBank.Width = 59;
            // 
            // cNoRekening
            // 
            this.cNoRekening.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNoRekening.DataPropertyName = "NoRekening";
            this.cNoRekening.HeaderText = "Nomor Rekening";
            this.cNoRekening.Name = "cNoRekening";
            this.cNoRekening.ReadOnly = true;
            this.cNoRekening.Width = 114;
            // 
            // cNamaRekening
            // 
            this.cNamaRekening.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNamaRekening.DataPropertyName = "NamaRekening";
            this.cNamaRekening.HeaderText = "Nama Rekening";
            this.cNamaRekening.Name = "cNamaRekening";
            this.cNamaRekening.ReadOnly = true;
            this.cNamaRekening.Width = 107;
            // 
            // frmKoreksiKeuanganHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 468);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdCLOSE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKoreksiKeuanganHistory";
            this.Text = "Riwayat Koreksi Keuangan";
            this.Title = "Riwayat Koreksi Keuangan";
            this.Load += new System.EventHandler(this.frmKoreksiKeuanganHistory_Load);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKoreksiKeuanganHistory_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                if (_Sumber=="KM") db.Commands.Add(db.CreateCommand("usp_PenerimaanUang_LIST"));
                else db.Commands.Add(db.CreateCommand("usp_PengeluaranUang_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _TransRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            txtNoBukti.Text = Tools.isNull(dt.Rows[0]["NoBukti"], "").ToString();
            txtTanggal.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["Tanggal"], "").ToString());
            txtNominal.Text = Tools.isNull(dt.Rows[0]["NominalRp"], 0).ToString();
            txtUraian.Text = Tools.isNull(dt.Rows[0]["Uraian"], "").ToString();
            if (_Sumber=="KM") txtCabang.Text = Tools.isNull(dt.Rows[0]["CabangKe"], "").ToString();
            else txtCabang.Text = Tools.isNull(dt.Rows[0]["CabangKeID"], "").ToString();
            txtJnsTransaksi.Text = Tools.isNull(dt.Rows[0]["NamaTransaksi"], "").ToString();
            
            dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KoreksiKeuangan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@TransRowID", SqlDbType.UniqueIdentifier, _TransRowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt;
        }
	}
}
