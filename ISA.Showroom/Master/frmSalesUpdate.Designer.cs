﻿namespace ISA.Showroom.Master
{
    partial class frmSalesUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesUpdate));
            this.cboIdentitas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHP = new ISA.Controls.CommonTextBox();
            this.txtTelp = new ISA.Controls.CommonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboProvinsiIdt = new System.Windows.Forms.ComboBox();
            this.cboKelurahanIdt = new System.Windows.Forms.ComboBox();
            this.cboKecamatanIdt = new System.Windows.Forms.ComboBox();
            this.cboKotaIdt = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRWIdt = new ISA.Controls.CommonTextBox();
            this.txtRTIdt = new ISA.Controls.CommonTextBox();
            this.txtAlamatIdt = new ISA.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ckDomisili = new System.Windows.Forms.CheckBox();
            this.cboProvinsiDom = new System.Windows.Forms.ComboBox();
            this.cboKotaDom = new System.Windows.Forms.ComboBox();
            this.cboKecamatanDom = new System.Windows.Forms.ComboBox();
            this.cboKelurahanDom = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRWDom = new ISA.Controls.CommonTextBox();
            this.txtRTDom = new ISA.Controls.CommonTextBox();
            this.txtAlamatDom = new ISA.Controls.CommonTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoIdentitas = new ISA.Controls.CommonTextBox();
            this.txtTglLahir = new ISA.Controls.DateTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTempat = new ISA.Controls.CommonTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTglMasuk = new ISA.Controls.DateTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTglKeluar = new ISA.Controls.DateTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label24 = new System.Windows.Forms.Label();
            this.cboKelompok = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboIdentitas
            // 
            this.cboIdentitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdentitas.FormattingEnabled = true;
            this.cboIdentitas.Location = new System.Drawing.Point(169, 137);
            this.cboIdentitas.Name = "cboIdentitas";
            this.cboIdentitas.Size = new System.Drawing.Size(103, 22);
            this.cboIdentitas.TabIndex = 4;
            this.cboIdentitas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboIdentitas_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Identitas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nama Sales";
            // 
            // txtHP
            // 
            this.txtHP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHP.Location = new System.Drawing.Point(536, 432);
            this.txtHP.MaxLength = 20;
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(198, 20);
            this.txtHP.TabIndex = 22;
            this.txtHP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHP_KeyDown);
            this.txtHP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHP_KeyPress);
            // 
            // txtTelp
            // 
            this.txtTelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelp.Location = new System.Drawing.Point(136, 431);
            this.txtTelp.MaxLength = 20;
            this.txtTelp.Name = "txtTelp";
            this.txtTelp.Size = new System.Drawing.Size(198, 20);
            this.txtTelp.TabIndex = 21;
            this.txtTelp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelp_KeyDown);
            this.txtTelp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelp_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 24;
            this.label11.Text = "No Telp";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(42, 176);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 235);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboProvinsiIdt);
            this.tabPage1.Controls.Add(this.cboKelurahanIdt);
            this.tabPage1.Controls.Add(this.cboKecamatanIdt);
            this.tabPage1.Controls.Add(this.cboKotaIdt);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtRWIdt);
            this.tabPage1.Controls.Add(this.txtRTIdt);
            this.tabPage1.Controls.Add(this.txtAlamatIdt);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alamat Identitas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboProvinsiIdt
            // 
            this.cboProvinsiIdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvinsiIdt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvinsiIdt.FormattingEnabled = true;
            this.cboProvinsiIdt.Location = new System.Drawing.Point(583, 13);
            this.cboProvinsiIdt.Name = "cboProvinsiIdt";
            this.cboProvinsiIdt.Size = new System.Drawing.Size(249, 22);
            this.cboProvinsiIdt.TabIndex = 10;
            this.cboProvinsiIdt.SelectedIndexChanged += new System.EventHandler(this.cboProvinsiIdt_SelectedIndexChanged);
            this.cboProvinsiIdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProvinsiIdt_KeyDown);
            // 
            // cboKelurahanIdt
            // 
            this.cboKelurahanIdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKelurahanIdt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKelurahanIdt.FormattingEnabled = true;
            this.cboKelurahanIdt.Location = new System.Drawing.Point(583, 139);
            this.cboKelurahanIdt.Name = "cboKelurahanIdt";
            this.cboKelurahanIdt.Size = new System.Drawing.Size(249, 22);
            this.cboKelurahanIdt.TabIndex = 13;
            this.cboKelurahanIdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKelurahanIdt_KeyDown);
            // 
            // cboKecamatanIdt
            // 
            this.cboKecamatanIdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKecamatanIdt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKecamatanIdt.FormattingEnabled = true;
            this.cboKecamatanIdt.Location = new System.Drawing.Point(583, 94);
            this.cboKecamatanIdt.Name = "cboKecamatanIdt";
            this.cboKecamatanIdt.Size = new System.Drawing.Size(249, 22);
            this.cboKecamatanIdt.TabIndex = 12;
            this.cboKecamatanIdt.SelectedIndexChanged += new System.EventHandler(this.cboKecamatanIdt_SelectedIndexChanged);
            this.cboKecamatanIdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKecamatanIdt_KeyDown);
            // 
            // cboKotaIdt
            // 
            this.cboKotaIdt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKotaIdt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKotaIdt.FormattingEnabled = true;
            this.cboKotaIdt.Location = new System.Drawing.Point(583, 52);
            this.cboKotaIdt.Name = "cboKotaIdt";
            this.cboKotaIdt.Size = new System.Drawing.Size(249, 22);
            this.cboKotaIdt.TabIndex = 11;
            this.cboKotaIdt.SelectedIndexChanged += new System.EventHandler(this.cboKotaIdt_SelectedIndexChanged);
            this.cboKotaIdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKotaIdt_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(490, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Provinsi";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(490, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "Kota";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(490, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "Kecamatan";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(490, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kelurahan";
            // 
            // txtRWIdt
            // 
            this.txtRWIdt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRWIdt.Location = new System.Drawing.Point(234, 142);
            this.txtRWIdt.MaxLength = 2;
            this.txtRWIdt.Name = "txtRWIdt";
            this.txtRWIdt.Size = new System.Drawing.Size(34, 20);
            this.txtRWIdt.TabIndex = 9;
            this.txtRWIdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRWIdt_KeyDown);
            this.txtRWIdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRWIdt_KeyPress);
            // 
            // txtRTIdt
            // 
            this.txtRTIdt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRTIdt.Location = new System.Drawing.Point(90, 142);
            this.txtRTIdt.MaxLength = 3;
            this.txtRTIdt.Name = "txtRTIdt";
            this.txtRTIdt.Size = new System.Drawing.Size(33, 20);
            this.txtRTIdt.TabIndex = 8;
            this.txtRTIdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRTIdt_KeyDown);
            this.txtRTIdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRTIdt_KeyPress);
            // 
            // txtAlamatIdt
            // 
            this.txtAlamatIdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlamatIdt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamatIdt.Location = new System.Drawing.Point(90, 13);
            this.txtAlamatIdt.Multiline = true;
            this.txtAlamatIdt.Name = "txtAlamatIdt";
            this.txtAlamatIdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlamatIdt.Size = new System.Drawing.Size(344, 116);
            this.txtAlamatIdt.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "RW";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "RT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Alamat";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ckDomisili);
            this.tabPage2.Controls.Add(this.cboProvinsiDom);
            this.tabPage2.Controls.Add(this.cboKotaDom);
            this.tabPage2.Controls.Add(this.cboKecamatanDom);
            this.tabPage2.Controls.Add(this.cboKelurahanDom);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtRWDom);
            this.tabPage2.Controls.Add(this.txtRTDom);
            this.tabPage2.Controls.Add(this.txtAlamatDom);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(862, 208);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alamat Domisili";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ckDomisili
            // 
            this.ckDomisili.AutoSize = true;
            this.ckDomisili.Location = new System.Drawing.Point(27, 176);
            this.ckDomisili.Name = "ckDomisili";
            this.ckDomisili.Size = new System.Drawing.Size(151, 18);
            this.ckDomisili.TabIndex = 31;
            this.ckDomisili.Text = "Sama dengan Identitas";
            this.ckDomisili.UseVisualStyleBackColor = true;
            this.ckDomisili.CheckedChanged += new System.EventHandler(this.ckDomisili_CheckedChanged);
            // 
            // cboProvinsiDom
            // 
            this.cboProvinsiDom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvinsiDom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvinsiDom.FormattingEnabled = true;
            this.cboProvinsiDom.Location = new System.Drawing.Point(583, 13);
            this.cboProvinsiDom.Name = "cboProvinsiDom";
            this.cboProvinsiDom.Size = new System.Drawing.Size(249, 22);
            this.cboProvinsiDom.TabIndex = 17;
            this.cboProvinsiDom.SelectedIndexChanged += new System.EventHandler(this.cboProvinsiDom_SelectedIndexChanged);
            this.cboProvinsiDom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProvinsiDom_KeyDown);
            // 
            // cboKotaDom
            // 
            this.cboKotaDom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKotaDom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKotaDom.FormattingEnabled = true;
            this.cboKotaDom.Location = new System.Drawing.Point(583, 52);
            this.cboKotaDom.Name = "cboKotaDom";
            this.cboKotaDom.Size = new System.Drawing.Size(249, 22);
            this.cboKotaDom.TabIndex = 18;
            this.cboKotaDom.SelectedIndexChanged += new System.EventHandler(this.cboKotaDom_SelectedIndexChanged);
            this.cboKotaDom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKotaDom_KeyDown);
            // 
            // cboKecamatanDom
            // 
            this.cboKecamatanDom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKecamatanDom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKecamatanDom.FormattingEnabled = true;
            this.cboKecamatanDom.Location = new System.Drawing.Point(583, 94);
            this.cboKecamatanDom.Name = "cboKecamatanDom";
            this.cboKecamatanDom.Size = new System.Drawing.Size(249, 22);
            this.cboKecamatanDom.TabIndex = 19;
            this.cboKecamatanDom.SelectedIndexChanged += new System.EventHandler(this.cboKecamatanDom_SelectedIndexChanged);
            this.cboKecamatanDom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKecamatanDom_KeyDown);
            // 
            // cboKelurahanDom
            // 
            this.cboKelurahanDom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKelurahanDom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKelurahanDom.FormattingEnabled = true;
            this.cboKelurahanDom.Location = new System.Drawing.Point(583, 139);
            this.cboKelurahanDom.Name = "cboKelurahanDom";
            this.cboKelurahanDom.Size = new System.Drawing.Size(249, 22);
            this.cboKelurahanDom.TabIndex = 20;
            this.cboKelurahanDom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKelurahanDom_KeyDown);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(490, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 14);
            this.label14.TabIndex = 26;
            this.label14.Text = "Provinsi";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(490, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 14);
            this.label15.TabIndex = 25;
            this.label15.Text = "Kota";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(490, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 14);
            this.label16.TabIndex = 24;
            this.label16.Text = "Kecamatan";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(490, 143);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 14);
            this.label17.TabIndex = 23;
            this.label17.Text = "Kelurahan";
            // 
            // txtRWDom
            // 
            this.txtRWDom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRWDom.Location = new System.Drawing.Point(234, 142);
            this.txtRWDom.MaxLength = 2;
            this.txtRWDom.Name = "txtRWDom";
            this.txtRWDom.Size = new System.Drawing.Size(34, 20);
            this.txtRWDom.TabIndex = 16;
            this.txtRWDom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRWDom_KeyDown);
            this.txtRWDom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRWDom_KeyPress);
            // 
            // txtRTDom
            // 
            this.txtRTDom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRTDom.Location = new System.Drawing.Point(90, 142);
            this.txtRTDom.MaxLength = 3;
            this.txtRTDom.Name = "txtRTDom";
            this.txtRTDom.Size = new System.Drawing.Size(33, 20);
            this.txtRTDom.TabIndex = 15;
            this.txtRTDom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRTDom_KeyDown);
            this.txtRTDom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRTDom_KeyPress);
            // 
            // txtAlamatDom
            // 
            this.txtAlamatDom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlamatDom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamatDom.Location = new System.Drawing.Point(90, 13);
            this.txtAlamatDom.Multiline = true;
            this.txtAlamatDom.Name = "txtAlamatDom";
            this.txtAlamatDom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlamatDom.Size = new System.Drawing.Size(344, 116);
            this.txtAlamatDom.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(170, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 14);
            this.label18.TabIndex = 19;
            this.label18.Text = "RW";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(30, 145);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 14);
            this.label19.TabIndex = 18;
            this.label19.Text = "RT";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 14);
            this.label20.TabIndex = 17;
            this.label20.Text = "Alamat";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(437, 435);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 14);
            this.label12.TabIndex = 26;
            this.label12.Text = "No HP";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(169, 68);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(676, 20);
            this.txtNama.TabIndex = 1;
            this.txtNama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNama_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "No Identitas";
            // 
            // txtNoIdentitas
            // 
            this.txtNoIdentitas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoIdentitas.Location = new System.Drawing.Point(535, 139);
            this.txtNoIdentitas.MaxLength = 30;
            this.txtNoIdentitas.Name = "txtNoIdentitas";
            this.txtNoIdentitas.Size = new System.Drawing.Size(310, 20);
            this.txtNoIdentitas.TabIndex = 5;
            this.txtNoIdentitas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoIdentitas_KeyDown);
            this.txtNoIdentitas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoIdentitas_KeyPress);
            // 
            // txtTglLahir
            // 
            this.txtTglLahir.DateValue = null;
            this.txtTglLahir.Location = new System.Drawing.Point(398, 103);
            this.txtTglLahir.MaxLength = 10;
            this.txtTglLahir.Name = "txtTglLahir";
            this.txtTglLahir.Size = new System.Drawing.Size(123, 20);
            this.txtTglLahir.TabIndex = 3;
            this.txtTglLahir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTglLahir_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 14);
            this.label13.TabIndex = 32;
            this.label13.Text = "Tempat / Tgl Lahir";
            // 
            // txtTempat
            // 
            this.txtTempat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTempat.Location = new System.Drawing.Point(169, 103);
            this.txtTempat.MaxLength = 20;
            this.txtTempat.Name = "txtTempat";
            this.txtTempat.Size = new System.Drawing.Size(174, 20);
            this.txtTempat.TabIndex = 2;
            this.txtTempat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempat_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(366, 105);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(10, 14);
            this.label21.TabIndex = 35;
            this.label21.Text = "/";
            // 
            // txtTglMasuk
            // 
            this.txtTglMasuk.DateValue = null;
            this.txtTglMasuk.Location = new System.Drawing.Point(478, 468);
            this.txtTglMasuk.MaxLength = 10;
            this.txtTglMasuk.Name = "txtTglMasuk";
            this.txtTglMasuk.Size = new System.Drawing.Size(125, 20);
            this.txtTglMasuk.TabIndex = 24;
            this.txtTglMasuk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTglMasuk_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(381, 474);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 14);
            this.label22.TabIndex = 36;
            this.label22.Text = "Tgl Masuk";
            // 
            // txtTglKeluar
            // 
            this.txtTglKeluar.DateValue = null;
            this.txtTglKeluar.Location = new System.Drawing.Point(753, 468);
            this.txtTglKeluar.MaxLength = 10;
            this.txtTglKeluar.Name = "txtTglKeluar";
            this.txtTglKeluar.Size = new System.Drawing.Size(125, 20);
            this.txtTglKeluar.TabIndex = 25;
            this.txtTglKeluar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTglKeluar_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(654, 474);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 14);
            this.label23.TabIndex = 38;
            this.label23.Text = "Tgl Keluar";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(495, 518);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 27;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(338, 518);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 26;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(39, 474);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 42;
            this.label24.Text = "Kelompok";
            // 
            // cboKelompok
            // 
            this.cboKelompok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKelompok.FormattingEnabled = true;
            this.cboKelompok.Location = new System.Drawing.Point(137, 468);
            this.cboKelompok.Name = "cboKelompok";
            this.cboKelompok.Size = new System.Drawing.Size(177, 22);
            this.cboKelompok.TabIndex = 23;
            this.cboKelompok.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKelompok_KeyDown);
            // 
            // frmSalesUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 579);
            this.Controls.Add(this.cboKelompok);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txtTglKeluar);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtTglMasuk);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtTempat);
            this.Controls.Add(this.txtTglLahir);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboIdentitas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtTelp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoIdentitas);
            this.KeyPreview = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSalesUpdate";
            this.Text = "Sales";
            this.Title = "Sales";
            this.Load += new System.EventHandler(this.frmSalesUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtNoIdentitas, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtTelp, 0);
            this.Controls.SetChildIndex(this.txtHP, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboIdentitas, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtTglLahir, 0);
            this.Controls.SetChildIndex(this.txtTempat, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.txtTglMasuk, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.txtTglKeluar, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.cboKelompok, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboIdentitas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtHP;
        private ISA.Controls.CommonTextBox txtTelp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboProvinsiIdt;
        private System.Windows.Forms.ComboBox cboKelurahanIdt;
        private System.Windows.Forms.ComboBox cboKecamatanIdt;
        private System.Windows.Forms.ComboBox cboKotaIdt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommonTextBox txtRWIdt;
        private ISA.Controls.CommonTextBox txtRTIdt;
        private ISA.Controls.CommonTextBox txtAlamatIdt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox ckDomisili;
        private System.Windows.Forms.ComboBox cboProvinsiDom;
        private System.Windows.Forms.ComboBox cboKotaDom;
        private System.Windows.Forms.ComboBox cboKecamatanDom;
        private System.Windows.Forms.ComboBox cboKelurahanDom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private ISA.Controls.CommonTextBox txtRWDom;
        private ISA.Controls.CommonTextBox txtRTDom;
        private ISA.Controls.CommonTextBox txtAlamatDom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.CommonTextBox txtNama;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtNoIdentitas;
        private ISA.Controls.DateTextBox txtTglLahir;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.CommonTextBox txtTempat;
        private System.Windows.Forms.Label label21;
        private ISA.Controls.DateTextBox txtTglMasuk;
        private System.Windows.Forms.Label label22;
        private ISA.Controls.DateTextBox txtTglKeluar;
        private System.Windows.Forms.Label label23;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboKelompok;

    }
}