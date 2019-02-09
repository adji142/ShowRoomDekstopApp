namespace ISA.Showroom.Master
{
    partial class frmWilayah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWilayah));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridArea = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridWilayah = new ISA.Controls.CustomGridView();
            this.WilRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wilayah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridKolektor = new ISA.Controls.CustomGridView();
            this.KolRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolektor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArea)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWilayah)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKolektor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(276, 278);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 21;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(573, 278);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(29, 278);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 19;
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
            this.cmdEdit.Location = new System.Drawing.Point(152, 278);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 20;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(31, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridArea);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(649, 196);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 18;
            // 
            // gridArea
            // 
            this.gridArea.AllowUserToAddRows = false;
            this.gridArea.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridArea.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Area});
            this.gridArea.Location = new System.Drawing.Point(3, 3);
            this.gridArea.MaximumSize = new System.Drawing.Size(650, 600);
            this.gridArea.MultiSelect = false;
            this.gridArea.Name = "gridArea";
            this.gridArea.ReadOnly = true;
            this.gridArea.RowHeadersVisible = false;
            this.gridArea.RowTemplate.Height = 25;
            this.gridArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridArea.Size = new System.Drawing.Size(310, 190);
            this.gridArea.StandardTab = true;
            this.gridArea.TabIndex = 12;
            this.gridArea.Enter += new System.EventHandler(this.gridArea_Enter);
            //this.gridArea.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridArea_CellFormatting);
            this.gridArea.SelectionChanged += new System.EventHandler(this.gridArea_SelectionChanged);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Area
            // 
            this.Area.DataPropertyName = "Area";
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 380;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 540;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.MaximumSize = new System.Drawing.Size(650, 600);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(323, 190);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridWilayah);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(315, 163);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Wilayah";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridWilayah
            // 
            this.gridWilayah.AllowUserToAddRows = false;
            this.gridWilayah.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridWilayah.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridWilayah.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWilayah.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridWilayah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWilayah.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WilRowID,
            this.Wilayah});
            this.gridWilayah.Location = new System.Drawing.Point(0, 0);
            this.gridWilayah.MaximumSize = new System.Drawing.Size(635, 600);
            this.gridWilayah.MultiSelect = false;
            this.gridWilayah.Name = "gridWilayah";
            this.gridWilayah.ReadOnly = true;
            this.gridWilayah.RowHeadersVisible = false;
            this.gridWilayah.RowTemplate.Height = 25;
            this.gridWilayah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridWilayah.Size = new System.Drawing.Size(315, 167);
            this.gridWilayah.StandardTab = true;
            this.gridWilayah.TabIndex = 13;
            this.gridWilayah.Enter += new System.EventHandler(this.gridWilayah_Enter);
            //this.gridWilayah.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridWilayah_CellFormatting);
            // 
            // WilRowID
            // 
            this.WilRowID.DataPropertyName = "RowID";
            this.WilRowID.HeaderText = "RowID";
            this.WilRowID.Name = "WilRowID";
            this.WilRowID.ReadOnly = true;
            this.WilRowID.Visible = false;
            // 
            // Wilayah
            // 
            this.Wilayah.DataPropertyName = "conWilayah";
            this.Wilayah.HeaderText = "Wilayah";
            this.Wilayah.MinimumWidth = 410;
            this.Wilayah.Name = "Wilayah";
            this.Wilayah.ReadOnly = true;
            this.Wilayah.Width = 630;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridKolektor);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(315, 163);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kolektor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridKolektor
            // 
            this.gridKolektor.AllowUserToAddRows = false;
            this.gridKolektor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridKolektor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridKolektor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKolektor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKolektor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KolRowID,
            this.Kolektor,
            this.TMT});
            this.gridKolektor.Location = new System.Drawing.Point(0, 0);
            this.gridKolektor.MaximumSize = new System.Drawing.Size(635, 600);
            this.gridKolektor.MultiSelect = false;
            this.gridKolektor.Name = "gridKolektor";
            this.gridKolektor.ReadOnly = true;
            this.gridKolektor.RowHeadersVisible = false;
            this.gridKolektor.RowTemplate.Height = 25;
            this.gridKolektor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridKolektor.Size = new System.Drawing.Size(315, 167);
            this.gridKolektor.StandardTab = true;
            this.gridKolektor.TabIndex = 13;
            this.gridKolektor.Enter += new System.EventHandler(this.gridKolektor_Enter);
            //this.gridKolektor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridKolektor_CellFormatting);
            // 
            // KolRowID
            // 
            this.KolRowID.DataPropertyName = "RowID";
            this.KolRowID.HeaderText = "RowID";
            this.KolRowID.Name = "KolRowID";
            this.KolRowID.ReadOnly = true;
            this.KolRowID.Visible = false;
            // 
            // Kolektor
            // 
            this.Kolektor.DataPropertyName = "Kolektor";
            this.Kolektor.HeaderText = "Kolektor";
            this.Kolektor.MinimumWidth = 410;
            this.Kolektor.Name = "Kolektor";
            this.Kolektor.ReadOnly = true;
            this.Kolektor.Width = 500;
            // 
            // TMT
            // 
            this.TMT.DataPropertyName = "TMT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.TMT.DefaultCellStyle = dataGridViewCellStyle4;
            this.TMT.HeaderText = "TMT";
            this.TMT.MinimumWidth = 100;
            this.TMT.Name = "TMT";
            this.TMT.ReadOnly = true;
            this.TMT.Width = 130;
            // 
            // frmWilayah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmWilayah";
            this.Text = "Wilayah";
            this.Title = "Wilayah";
            this.Load += new System.EventHandler(this.frmWilayah_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArea)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridWilayah)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKolektor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ISA.Controls.CustomGridView gridArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ISA.Controls.CustomGridView gridWilayah;
        private System.Windows.Forms.DataGridViewTextBoxColumn WilRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wilayah;
        private System.Windows.Forms.TabPage tabPage2;
        private ISA.Controls.CustomGridView gridKolektor;
        private System.Windows.Forms.DataGridViewTextBoxColumn KolRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolektor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMT;


    }
}