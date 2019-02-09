namespace ISA.Showroom.Finance.GL
{
    partial class frmJournalNotaPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalNotaPS));
            this.cboPers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.TabJournal = new System.Windows.Forms.TabControl();
            this.TabNota = new System.Windows.Forms.TabPage();
            this.GvHeaderA = new ISA.Controls.CustomGridView();
            this.TabRetur = new System.Windows.Forms.TabPage();
            this.GVHeaderB = new ISA.Controls.CustomGridView();
            this.TabKPJ = new System.Windows.Forms.TabPage();
            this.GVHeaderC = new ISA.Controls.CustomGridView();
            this.TabKRJ = new System.Windows.Forms.TabPage();
            this.GVHeaderD = new ISA.Controls.CustomGridView();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.Progress = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TabIden = new System.Windows.Forms.TabPage();
            this.GVHeaderE = new ISA.Controls.CustomGridView();
            this.TabJournal.SuspendLayout();
            this.TabNota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvHeaderA)).BeginInit();
            this.TabRetur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderB)).BeginInit();
            this.TabKPJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderC)).BeginInit();
            this.TabKRJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderD)).BeginInit();
            this.Progress.SuspendLayout();
            this.TabIden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderE)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPers
            // 
            this.cboPers.FormattingEnabled = true;
            this.cboPers.Location = new System.Drawing.Point(355, 61);
            this.cboPers.Name = "cboPers";
            this.cboPers.Size = new System.Drawing.Size(186, 22);
            this.cboPers.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Periode";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(75, 61);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 7;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(558, 63);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 8;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // TabJournal
            // 
            this.TabJournal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabJournal.Controls.Add(this.TabNota);
            this.TabJournal.Controls.Add(this.TabRetur);
            this.TabJournal.Controls.Add(this.TabKPJ);
            this.TabJournal.Controls.Add(this.TabKRJ);
            this.TabJournal.Controls.Add(this.TabIden);
            this.TabJournal.Location = new System.Drawing.Point(9, 89);
            this.TabJournal.Name = "TabJournal";
            this.TabJournal.SelectedIndex = 0;
            this.TabJournal.Size = new System.Drawing.Size(706, 359);
            this.TabJournal.TabIndex = 9;
            // 
            // TabNota
            // 
            this.TabNota.Controls.Add(this.GvHeaderA);
            this.TabNota.Location = new System.Drawing.Point(4, 23);
            this.TabNota.Name = "TabNota";
            this.TabNota.Padding = new System.Windows.Forms.Padding(3);
            this.TabNota.Size = new System.Drawing.Size(698, 332);
            this.TabNota.TabIndex = 0;
            this.TabNota.Text = "Nota";
            this.TabNota.UseVisualStyleBackColor = true;
            // 
            // GvHeaderA
            // 
            this.GvHeaderA.AllowUserToAddRows = false;
            this.GvHeaderA.AllowUserToDeleteRows = false;
            this.GvHeaderA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvHeaderA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvHeaderA.Location = new System.Drawing.Point(3, 3);
            this.GvHeaderA.MultiSelect = false;
            this.GvHeaderA.Name = "GvHeaderA";
            this.GvHeaderA.ReadOnly = true;
            this.GvHeaderA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GvHeaderA.Size = new System.Drawing.Size(692, 326);
            this.GvHeaderA.StandardTab = true;
            this.GvHeaderA.TabIndex = 0;
            // 
            // TabRetur
            // 
            this.TabRetur.Controls.Add(this.GVHeaderB);
            this.TabRetur.Location = new System.Drawing.Point(4, 23);
            this.TabRetur.Name = "TabRetur";
            this.TabRetur.Padding = new System.Windows.Forms.Padding(3);
            this.TabRetur.Size = new System.Drawing.Size(698, 332);
            this.TabRetur.TabIndex = 1;
            this.TabRetur.Text = "Retur";
            this.TabRetur.UseVisualStyleBackColor = true;
            // 
            // GVHeaderB
            // 
            this.GVHeaderB.AllowUserToAddRows = false;
            this.GVHeaderB.AllowUserToDeleteRows = false;
            this.GVHeaderB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeaderB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeaderB.Location = new System.Drawing.Point(3, 3);
            this.GVHeaderB.MultiSelect = false;
            this.GVHeaderB.Name = "GVHeaderB";
            this.GVHeaderB.ReadOnly = true;
            this.GVHeaderB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeaderB.Size = new System.Drawing.Size(692, 326);
            this.GVHeaderB.StandardTab = true;
            this.GVHeaderB.TabIndex = 0;
            // 
            // TabKPJ
            // 
            this.TabKPJ.Controls.Add(this.GVHeaderC);
            this.TabKPJ.Location = new System.Drawing.Point(4, 23);
            this.TabKPJ.Name = "TabKPJ";
            this.TabKPJ.Padding = new System.Windows.Forms.Padding(3);
            this.TabKPJ.Size = new System.Drawing.Size(698, 332);
            this.TabKPJ.TabIndex = 2;
            this.TabKPJ.Text = "KPJ";
            this.TabKPJ.UseVisualStyleBackColor = true;
            // 
            // GVHeaderC
            // 
            this.GVHeaderC.AllowUserToAddRows = false;
            this.GVHeaderC.AllowUserToDeleteRows = false;
            this.GVHeaderC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeaderC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeaderC.Location = new System.Drawing.Point(3, 3);
            this.GVHeaderC.MultiSelect = false;
            this.GVHeaderC.Name = "GVHeaderC";
            this.GVHeaderC.ReadOnly = true;
            this.GVHeaderC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeaderC.Size = new System.Drawing.Size(692, 326);
            this.GVHeaderC.StandardTab = true;
            this.GVHeaderC.TabIndex = 0;
            // 
            // TabKRJ
            // 
            this.TabKRJ.Controls.Add(this.GVHeaderD);
            this.TabKRJ.Location = new System.Drawing.Point(4, 23);
            this.TabKRJ.Name = "TabKRJ";
            this.TabKRJ.Padding = new System.Windows.Forms.Padding(3);
            this.TabKRJ.Size = new System.Drawing.Size(698, 332);
            this.TabKRJ.TabIndex = 3;
            this.TabKRJ.Text = "KRJ";
            this.TabKRJ.UseVisualStyleBackColor = true;
            // 
            // GVHeaderD
            // 
            this.GVHeaderD.AllowUserToAddRows = false;
            this.GVHeaderD.AllowUserToDeleteRows = false;
            this.GVHeaderD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeaderD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeaderD.Location = new System.Drawing.Point(3, 3);
            this.GVHeaderD.MultiSelect = false;
            this.GVHeaderD.Name = "GVHeaderD";
            this.GVHeaderD.ReadOnly = true;
            this.GVHeaderD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeaderD.Size = new System.Drawing.Size(692, 326);
            this.GVHeaderD.StandardTab = true;
            this.GVHeaderD.TabIndex = 0;
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(509, 461);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 10;
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
            this.cmdClose.Location = new System.Drawing.Point(615, 461);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Progress.Controls.Add(this.progressBar1);
            this.Progress.Location = new System.Drawing.Point(13, 447);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(343, 54);
            this.Progress.TabIndex = 12;
            this.Progress.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 24);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(331, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // TabIden
            // 
            this.TabIden.Controls.Add(this.GVHeaderE);
            this.TabIden.Location = new System.Drawing.Point(4, 23);
            this.TabIden.Name = "TabIden";
            this.TabIden.Padding = new System.Windows.Forms.Padding(3);
            this.TabIden.Size = new System.Drawing.Size(698, 332);
            this.TabIden.TabIndex = 4;
            this.TabIden.Text = "Iden";
            this.TabIden.UseVisualStyleBackColor = true;
            // 
            // GVHeaderE
            // 
            this.GVHeaderE.AllowUserToAddRows = false;
            this.GVHeaderE.AllowUserToDeleteRows = false;
            this.GVHeaderE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeaderE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeaderE.Location = new System.Drawing.Point(3, 3);
            this.GVHeaderE.MultiSelect = false;
            this.GVHeaderE.Name = "GVHeaderE";
            this.GVHeaderE.ReadOnly = true;
            this.GVHeaderE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeaderE.Size = new System.Drawing.Size(692, 326);
            this.GVHeaderE.StandardTab = true;
            this.GVHeaderE.TabIndex = 1;
            // 
            // frmJournalNotaPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(718, 504);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.TabJournal);
            this.Controls.Add(this.cboPers);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJournalNotaPS";
            this.Text = "Journal Nota";
            this.Title = "Journal Nota";
            this.Load += new System.EventHandler(this.frmJournalNotaPS_Load);
            this.Controls.SetChildIndex(this.cboPers, 0);
            this.Controls.SetChildIndex(this.TabJournal, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.Progress, 0);
            this.TabJournal.ResumeLayout(false);
            this.TabNota.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvHeaderA)).EndInit();
            this.TabRetur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderB)).EndInit();
            this.TabKPJ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderC)).EndInit();
            this.TabKRJ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderD)).EndInit();
            this.Progress.ResumeLayout(false);
            this.TabIden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeaderE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPers;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.TabControl TabJournal;
        private System.Windows.Forms.TabPage TabNota;
        private System.Windows.Forms.TabPage TabRetur;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CustomGridView GvHeaderA;
        private ISA.Controls.CustomGridView GVHeaderB;
        private System.Windows.Forms.TabPage TabKPJ;
        private ISA.Controls.CustomGridView GVHeaderC;
        private System.Windows.Forms.TabPage TabKRJ;
        private ISA.Controls.CustomGridView GVHeaderD;
        private System.Windows.Forms.GroupBox Progress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage TabIden;
        private ISA.Controls.CustomGridView GVHeaderE;
    }
}
