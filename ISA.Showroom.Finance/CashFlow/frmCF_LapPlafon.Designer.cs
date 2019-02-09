namespace ISA.Showroom.Finance.CashFlow
{
    partial class frmCF_LapPlafon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCF_LapPlafon));
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdPRINT = new ISA.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(226, 85);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(243, 25);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Periode mulai";
            // 
            // cmdPRINT
            // 
            this.cmdPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPRINT.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPRINT.Image = ((System.Drawing.Image)(resources.GetObject("cmdPRINT.Image")));
            this.cmdPRINT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPRINT.Location = new System.Drawing.Point(31, 162);
            this.cmdPRINT.Name = "cmdPRINT";
            this.cmdPRINT.Size = new System.Drawing.Size(100, 40);
            this.cmdPRINT.TabIndex = 7;
            this.cmdPRINT.Text = "PRINT";
            this.cmdPRINT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPRINT.UseVisualStyleBackColor = true;
            this.cmdPRINT.Click += new System.EventHandler(this.cmdPRINT_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(454, 162);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 8;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // frmCF_LapPlafon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(585, 226);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdPRINT);
            this.Controls.Add(this.cmdCLOSE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCF_LapPlafon";
            this.Text = "Laporan Plafon";
            this.Title = "Laporan Plafon";
            this.Load += new System.EventHandler(this.frmCF_LapPlafon_Load);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdPRINT, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdPRINT;
        private ISA.Controls.CommandButton cmdCLOSE;
    }
}
