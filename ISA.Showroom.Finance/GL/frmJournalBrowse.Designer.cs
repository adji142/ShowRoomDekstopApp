namespace ISA.Showroom.Finance.GL
{
    partial class frmJournalBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalBrowse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.hRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hNoReff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hSyncFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.dRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHeaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDebet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dKredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataUang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NominalOri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNSubJournal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referensi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdGo = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmdSubJournal = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.cmdNo = new ISA.Controls.CommandButton();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(7, 4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(113, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 6;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(219, 4);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 7;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(587, 4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customGridView2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 416);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.AllowUserToResizeRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hRowID,
            this.hRecordID,
            this.hTanggal,
            this.hNoReff,
            this.hKodeGudang,
            this.hSrc,
            this.hUraian,
            this.hDebet,
            this.hKredit,
            this.hSyncFlag});
            this.customGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView1.Location = new System.Drawing.Point(3, 43);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(693, 144);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_RowEnter);
            this.customGridView1.SelectionRowChanged += new System.EventHandler(this.customGridView1_SelectionRowChanged);
            this.customGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.customGridView1_CellFormatting);
            this.customGridView1.SelectionChanged += new System.EventHandler(this.customGridView1_SelectionChanged);
            this.customGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellContentClick);
            // 
            // hRowID
            // 
            this.hRowID.DataPropertyName = "RowID";
            this.hRowID.HeaderText = "RowID";
            this.hRowID.Name = "hRowID";
            this.hRowID.ReadOnly = true;
            this.hRowID.Visible = false;
            // 
            // hRecordID
            // 
            this.hRecordID.DataPropertyName = "RecordID";
            this.hRecordID.HeaderText = "RecordID";
            this.hRecordID.Name = "hRecordID";
            this.hRecordID.ReadOnly = true;
            this.hRecordID.Visible = false;
            // 
            // hTanggal
            // 
            this.hTanggal.DataPropertyName = "Tanggal";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.hTanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.hTanggal.HeaderText = "Tanggal";
            this.hTanggal.Name = "hTanggal";
            this.hTanggal.ReadOnly = true;
            // 
            // hNoReff
            // 
            this.hNoReff.DataPropertyName = "NoReff";
            this.hNoReff.HeaderText = "NoReff";
            this.hNoReff.Name = "hNoReff";
            this.hNoReff.ReadOnly = true;
            // 
            // hKodeGudang
            // 
            this.hKodeGudang.DataPropertyName = "KodeGudang";
            this.hKodeGudang.HeaderText = "Cbg";
            this.hKodeGudang.Name = "hKodeGudang";
            this.hKodeGudang.ReadOnly = true;
            this.hKodeGudang.Width = 40;
            // 
            // hSrc
            // 
            this.hSrc.DataPropertyName = "Src";
            this.hSrc.HeaderText = "Src";
            this.hSrc.Name = "hSrc";
            this.hSrc.ReadOnly = true;
            this.hSrc.Width = 40;
            // 
            // hUraian
            // 
            this.hUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hUraian.DataPropertyName = "Uraian";
            this.hUraian.HeaderText = "Uraian";
            this.hUraian.Name = "hUraian";
            this.hUraian.ReadOnly = true;
            this.hUraian.Width = 66;
            // 
            // hDebet
            // 
            this.hDebet.DataPropertyName = "Debet";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.hDebet.DefaultCellStyle = dataGridViewCellStyle2;
            this.hDebet.HeaderText = "Debet";
            this.hDebet.Name = "hDebet";
            this.hDebet.ReadOnly = true;
            this.hDebet.Width = 125;
            // 
            // hKredit
            // 
            this.hKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.hKredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.hKredit.HeaderText = "Kredit";
            this.hKredit.Name = "hKredit";
            this.hKredit.ReadOnly = true;
            this.hKredit.Width = 125;
            // 
            // hSyncFlag
            // 
            this.hSyncFlag.DataPropertyName = "SyncFlag";
            this.hSyncFlag.HeaderText = "SyncFlag";
            this.hSyncFlag.Name = "hSyncFlag";
            this.hSyncFlag.ReadOnly = true;
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.AllowUserToResizeRows = false;
            this.customGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dRowID,
            this.dHeaderID,
            this.dRecordID,
            this.dHRecordID,
            this.dNoPerkiraan,
            this.dNamaPerkiraan,
            this.dUraian,
            this.dDK,
            this.dDebet,
            this.dKredit,
            this.MataUang,
            this.NominalOri,
            this.dNSubJournal,
            this.Referensi});
            this.customGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView2.Location = new System.Drawing.Point(3, 213);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.customGridView2.RowHeadersVisible = false;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(693, 144);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 1;
            this.customGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.customGridView2_CellFormatting);
            this.customGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView2_CellClick);
            this.customGridView2.SelectionChanged += new System.EventHandler(this.customGridView2_SelectionChanged);
            // 
            // dRowID
            // 
            this.dRowID.DataPropertyName = "RowID";
            this.dRowID.HeaderText = "RowID";
            this.dRowID.Name = "dRowID";
            this.dRowID.ReadOnly = true;
            this.dRowID.Visible = false;
            // 
            // dHeaderID
            // 
            this.dHeaderID.DataPropertyName = "HeaderID";
            this.dHeaderID.HeaderText = "HeaderID";
            this.dHeaderID.Name = "dHeaderID";
            this.dHeaderID.ReadOnly = true;
            this.dHeaderID.Visible = false;
            // 
            // dRecordID
            // 
            this.dRecordID.DataPropertyName = "RecordID";
            this.dRecordID.HeaderText = "RecordID";
            this.dRecordID.Name = "dRecordID";
            this.dRecordID.ReadOnly = true;
            this.dRecordID.Visible = false;
            // 
            // dHRecordID
            // 
            this.dHRecordID.DataPropertyName = "HRecordID";
            this.dHRecordID.HeaderText = "HRecordID";
            this.dHRecordID.Name = "dHRecordID";
            this.dHRecordID.ReadOnly = true;
            this.dHRecordID.Visible = false;
            // 
            // dNoPerkiraan
            // 
            this.dNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.dNoPerkiraan.HeaderText = "NoPerkiraan";
            this.dNoPerkiraan.Name = "dNoPerkiraan";
            this.dNoPerkiraan.ReadOnly = true;
            // 
            // dNamaPerkiraan
            // 
            this.dNamaPerkiraan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dNamaPerkiraan.DataPropertyName = "NamaPerkiraan";
            this.dNamaPerkiraan.HeaderText = "NamaPerkiraan";
            this.dNamaPerkiraan.Name = "dNamaPerkiraan";
            this.dNamaPerkiraan.ReadOnly = true;
            this.dNamaPerkiraan.Width = 115;
            // 
            // dUraian
            // 
            this.dUraian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dUraian.DataPropertyName = "Uraian";
            this.dUraian.HeaderText = "Uraian";
            this.dUraian.Name = "dUraian";
            this.dUraian.ReadOnly = true;
            this.dUraian.Width = 66;
            // 
            // dDK
            // 
            this.dDK.DataPropertyName = "DK";
            this.dDK.HeaderText = "DK";
            this.dDK.Name = "dDK";
            this.dDK.ReadOnly = true;
            this.dDK.Width = 30;
            // 
            // dDebet
            // 
            this.dDebet.DataPropertyName = "Debet";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.dDebet.DefaultCellStyle = dataGridViewCellStyle4;
            this.dDebet.HeaderText = "Debet";
            this.dDebet.Name = "dDebet";
            this.dDebet.ReadOnly = true;
            // 
            // dKredit
            // 
            this.dKredit.DataPropertyName = "Kredit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.dKredit.DefaultCellStyle = dataGridViewCellStyle5;
            this.dKredit.HeaderText = "Kredit";
            this.dKredit.Name = "dKredit";
            this.dKredit.ReadOnly = true;
            // 
            // MataUang
            // 
            this.MataUang.DataPropertyName = "MataUangID";
            this.MataUang.HeaderText = "Mata Uang";
            this.MataUang.Name = "MataUang";
            this.MataUang.ReadOnly = true;
            // 
            // NominalOri
            // 
            this.NominalOri.DataPropertyName = "NominalOri";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            dataGridViewCellStyle6.NullValue = null;
            this.NominalOri.DefaultCellStyle = dataGridViewCellStyle6;
            this.NominalOri.HeaderText = "Nilai (Ori)";
            this.NominalOri.Name = "NominalOri";
            this.NominalOri.ReadOnly = true;
            // 
            // dNSubJournal
            // 
            this.dNSubJournal.DataPropertyName = "NSubJournal";
            this.dNSubJournal.HeaderText = "NSubJournal";
            this.dNSubJournal.Name = "dNSubJournal";
            this.dNSubJournal.ReadOnly = true;
            // 
            // Referensi
            // 
            this.Referensi.DataPropertyName = "Referensi";
            this.Referensi.HeaderText = "Referensi";
            this.Referensi.Name = "Referensi";
            this.Referensi.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboCabang);
            this.panel1.Controls.Add(this.rangeDateBox1);
            this.panel1.Controls.Add(this.cmdGo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 34);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cabang";
            // 
            // cboCabang
            // 
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(417, 6);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(121, 22);
            this.cboCabang.TabIndex = 17;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(86, 7);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 11;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdGo
            // 
            this.cmdGo.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdGo.Image = ((System.Drawing.Image)(resources.GetObject("cmdGo.Image")));
            this.cmdGo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdGo.Location = new System.Drawing.Point(551, 5);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(80, 23);
            this.cmdGo.TabIndex = 12;
            this.cmdGo.Text = "Search";
            this.cmdGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tanggal";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdClose);
            this.panel2.Controls.Add(this.cmdAdd);
            this.panel2.Controls.Add(this.cmdEdit);
            this.panel2.Controls.Add(this.cmdDelete);
            this.panel2.Controls.Add(this.cmdGenerate);
            this.panel2.Controls.Add(this.cmdSubJournal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 50);
            this.panel2.TabIndex = 14;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGenerate.Image = global::ISA.Showroom.Finance.Properties.Resources.Setting32;
            this.cmdGenerate.Location = new System.Drawing.Point(457, 4);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(107, 40);
            this.cmdGenerate.TabIndex = 15;
            this.cmdGenerate.Text = "GENERATE";
            this.cmdGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Visible = false;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cmdSubJournal
            // 
            this.cmdSubJournal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSubJournal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSubJournal.Location = new System.Drawing.Point(326, 4);
            this.cmdSubJournal.Name = "cmdSubJournal";
            this.cmdSubJournal.Size = new System.Drawing.Size(124, 40);
            this.cmdSubJournal.TabIndex = 14;
            this.cmdSubJournal.Text = "SUB JOURNAL";
            this.cmdSubJournal.UseVisualStyleBackColor = true;
            this.cmdSubJournal.Click += new System.EventHandler(this.cmdSubJournal_Click);
            // 
            // pnlData
            // 
            this.pnlData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlData.Controls.Add(this.cmdNo);
            this.pnlData.Controls.Add(this.cmdYes);
            this.pnlData.Controls.Add(this.monthYearBox1);
            this.pnlData.Controls.Add(this.label3);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Location = new System.Drawing.Point(168, 127);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(363, 189);
            this.pnlData.TabIndex = 16;
            this.pnlData.Visible = false;
            // 
            // cmdNo
            // 
            this.cmdNo.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(244, 125);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 4;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(15, 125);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 3;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(77, 65);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(282, 21);
            this.monthYearBox1.TabIndex = 2;
            this.monthYearBox1.Year = 2017;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Periode Generate Data";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmJournalBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 468);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJournalBrowse";
            this.Text = "Journal";
            this.Title = "Journal";
            this.Load += new System.EventHandler(this.frmJournalBrowse_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CustomGridView customGridView2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdGo;
        private System.Windows.Forms.Button cmdSubJournal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hNoReff;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKodeGudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn hSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn hUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn hKredit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hSyncFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHeaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHRecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNamaPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDebet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dKredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataUang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NominalOri;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNSubJournal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referensi;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton cmdNo;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}
