﻿namespace ISA.Showroom.Finance.GL
{
    partial class frmDownloadPerkiraan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadPerkiraan));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.commonTextBox2 = new ISA.Controls.CommonTextBox();
            this.txtStatus = new ISA.Controls.CommonTextBox();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folder Download";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nama File";
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Enabled = false;
            this.commonTextBox1.Location = new System.Drawing.Point(166, 26);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.ReadOnly = true;
            this.commonTextBox1.Size = new System.Drawing.Size(182, 20);
            this.commonTextBox1.TabIndex = 6;
            this.commonTextBox1.Text = "C:\\TEMP\\DOWNLOAD";
            // 
            // commonTextBox2
            // 
            this.commonTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox2.Enabled = false;
            this.commonTextBox2.Location = new System.Drawing.Point(166, 73);
            this.commonTextBox2.Name = "commonTextBox2";
            this.commonTextBox2.ReadOnly = true;
            this.commonTextBox2.Size = new System.Drawing.Size(100, 20);
            this.commonTextBox2.TabIndex = 7;
            this.commonTextBox2.Text = "NOPERK.ZIP";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatus.ForeColor = System.Drawing.Color.Lime;
            this.txtStatus.Location = new System.Drawing.Point(272, 73);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(76, 20);
            this.txtStatus.TabIndex = 8;
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(31, 250);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(128, 40);
            this.cmdYes.TabIndex = 9;
            this.cmdYes.Text = "DOWNLOAD";
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
            this.cmdClose.Location = new System.Drawing.Point(468, 250);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 206);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(589, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.commonTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.commonTextBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(72, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 125);
            this.panel1.TabIndex = 12;
            // 
            // frmDownloadPerkiraan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(597, 314);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDownloadPerkiraan";
            this.Text = "Download Perkiraan";
            this.Title = "Download Perkiraan";
            this.Load += new System.EventHandler(this.frmDownloadPerkiraan_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox commonTextBox1;
        private ISA.Controls.CommonTextBox commonTextBox2;
        private ISA.Controls.CommonTextBox txtStatus;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
    }
}
