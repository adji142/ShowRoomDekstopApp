namespace ISA.Showroom.Master
{
    partial class frmViewKTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewKTP));
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.uploadFotoKtp1 = new ISA.Showroom.Controls.UploadFotoKtp();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(583, 344);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // uploadFotoKtp1
            // 
            this.uploadFotoKtp1.BackColor = System.Drawing.Color.Transparent;
            this.uploadFotoKtp1.Location = new System.Drawing.Point(49, 50);
            this.uploadFotoKtp1.Name = "uploadFotoKtp1";
            this.uploadFotoKtp1.NomorKtp = "";
            this.uploadFotoKtp1.Size = new System.Drawing.Size(634, 284);
            this.uploadFotoKtp1.SourcePicture = "C:\\Temp\\Cookies\\PictureKtpToko\\ISAShowroom\\default.png";
            this.uploadFotoKtp1.TabIndex = 5;
            this.uploadFotoKtp1.Uploaded = false;
            this.uploadFotoKtp1.FinishUploaded += new System.EventHandler(this.uploadFotoKtp1_FinishUploaded);
            // 
            // frmViewKTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 396);
            this.Controls.Add(this.uploadFotoKtp1);
            this.Controls.Add(this.cmdCLOSE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmViewKTP";
            this.Text = "View KTP";
            this.Title = "View KTP";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmViewKTP_Load);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.uploadFotoKtp1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Showroom.Controls.UploadFotoKtp uploadFotoKtp1;
        private ISA.Controls.CommandButton cmdCLOSE;


    }
}