﻿namespace ISA.Showroom.Controls
{
    partial class frmLookUpSurveyor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookUpSurveyor));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new ISA.Controls.CommonTextBox();
            this.gvSearch = new ISA.Controls.CustomGridView();
            this.NamaSurveyor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoIdentitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TmptLahit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Surveyor";
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(86, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(162, 20);
            this.txtSearch.TabIndex = 15;
            // 
            // gvSearch
            // 
            this.gvSearch.AllowUserToAddRows = false;
            this.gvSearch.AllowUserToDeleteRows = false;
            this.gvSearch.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaSurveyor,
            this.Identitas,
            this.NoIdentitas,
            this.TmptLahit,
            this.TglLahir,
            this.TglMasuk});
            this.gvSearch.Location = new System.Drawing.Point(23, 89);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.ReadOnly = true;
            this.gvSearch.RowHeadersVisible = false;
            this.gvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSearch.Size = new System.Drawing.Size(797, 295);
            this.gvSearch.StandardTab = true;
            this.gvSearch.TabIndex = 14;
            this.gvSearch.DoubleClick += new System.EventHandler(this.gvSearch_DoubleClick);
            this.gvSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSearch_KeyDown);
            // 
            // NamaSurveyor
            // 
            this.NamaSurveyor.DataPropertyName = "Nama";
            this.NamaSurveyor.HeaderText = "Nama Surveyor";
            this.NamaSurveyor.Name = "NamaSurveyor";
            this.NamaSurveyor.ReadOnly = true;
            this.NamaSurveyor.Width = 270;
            // 
            // Identitas
            // 
            this.Identitas.DataPropertyName = "Identitas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Identitas.DefaultCellStyle = dataGridViewCellStyle3;
            this.Identitas.HeaderText = "Identitas";
            this.Identitas.Name = "Identitas";
            this.Identitas.ReadOnly = true;
            this.Identitas.Width = 60;
            // 
            // NoIdentitas
            // 
            this.NoIdentitas.DataPropertyName = "NoIdentitas";
            this.NoIdentitas.HeaderText = "No. Identitas";
            this.NoIdentitas.Name = "NoIdentitas";
            this.NoIdentitas.ReadOnly = true;
            this.NoIdentitas.Width = 130;
            // 
            // TmptLahit
            // 
            this.TmptLahit.DataPropertyName = "TmptLahir";
            this.TmptLahit.HeaderText = "Tempat Lahir";
            this.TmptLahit.Name = "TmptLahit";
            this.TmptLahit.ReadOnly = true;
            this.TmptLahit.Width = 120;
            // 
            // TglLahir
            // 
            this.TglLahir.DataPropertyName = "TglLahir";
            this.TglLahir.HeaderText = "Tanggal Lahir";
            this.TglLahir.Name = "TglLahir";
            this.TglLahir.ReadOnly = true;
            this.TglLahir.Width = 120;
            // 
            // TglMasuk
            // 
            this.TglMasuk.DataPropertyName = "TglMasuk";
            this.TglMasuk.HeaderText = "Tanggal Masuk";
            this.TglMasuk.Name = "TglMasuk";
            this.TglMasuk.ReadOnly = true;
            this.TglMasuk.Width = 120;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(252, 65);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(29, 23);
            this.cmdSearch.TabIndex = 17;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(23, 390);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 12;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(720, 390);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmLookUpSurveyor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 441);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gvSearch);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLookUpSurveyor";
            this.Text = "List Surveyor";
            this.Title = "List Surveyor";
            this.Load += new System.EventHandler(this.frmLookUpSurveyor_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.gvSearch, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtSearch;
        private ISA.Controls.CustomGridView gvSearch;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSurveyor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoIdentitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TmptLahit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMasuk;

    }
}