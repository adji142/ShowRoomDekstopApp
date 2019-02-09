namespace ISA.Showroom.Finance.CashFlow
{
    partial class PlafonBankUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlafonBankUpdate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTanggal = new ISA.Controls.DateTextBox();
            this.txtJumlah = new ISA.Controls.NumericTextBox();
            this.lblMataUangID = new System.Windows.Forms.Label();
            this.cmdCANCEL = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.cmdCANCEL);
            this.panel1.Controls.Add(this.cmdSAVE);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 68);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Jumlah Plafon";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tanggal";
            // 
            // txtTanggal
            // 
            this.txtTanggal.DateValue = null;
            this.txtTanggal.Location = new System.Drawing.Point(240, 77);
            this.txtTanggal.MaxLength = 10;
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(140, 20);
            this.txtTanggal.TabIndex = 0;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(280, 103);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(100, 20);
            this.txtJumlah.TabIndex = 1;
            this.txtJumlah.Text = "0";
            this.txtJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMataUangID
            // 
            this.lblMataUangID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMataUangID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMataUangID.Location = new System.Drawing.Point(240, 103);
            this.lblMataUangID.Name = "lblMataUangID";
            this.lblMataUangID.Size = new System.Drawing.Size(37, 20);
            this.lblMataUangID.TabIndex = 16;
            this.lblMataUangID.Text = ".";
            this.lblMataUangID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCANCEL
            // 
            this.cmdCANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCANCEL.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCANCEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("cmdCANCEL.Image")));
            this.cmdCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCANCEL.Location = new System.Drawing.Point(386, 12);
            this.cmdCANCEL.Name = "cmdCANCEL";
            this.cmdCANCEL.Size = new System.Drawing.Size(100, 40);
            this.cmdCANCEL.TabIndex = 1;
            this.cmdCANCEL.Text = "CANCEL";
            this.cmdCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCANCEL.UseVisualStyleBackColor = true;
            this.cmdCANCEL.Click += new System.EventHandler(this.cmdCANCEL_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(280, 12);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 0;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // PlafonBankUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 255);
            this.Controls.Add(this.lblMataUangID);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.txtTanggal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlafonBankUpdate";
            this.Text = "Plafon Bank";
            this.Title = "Plafon Bank";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.PlafonBankUpdate_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTanggal, 0);
            this.Controls.SetChildIndex(this.txtJumlah, 0);
            this.Controls.SetChildIndex(this.lblMataUangID, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdCANCEL;
        private ISA.Controls.CommandButton cmdSAVE;
        private ISA.Controls.DateTextBox txtTanggal;
        private ISA.Controls.NumericTextBox txtJumlah;
        private System.Windows.Forms.Label lblMataUangID;
    }
}