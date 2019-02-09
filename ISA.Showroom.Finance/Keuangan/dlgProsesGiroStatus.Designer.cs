namespace ISA.Showroom.Finance.Keuangan
{
    partial class dlgProsesGiroStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgProsesGiroStatus));
            this.cmdSubmit = new ISA.Controls.CommandButton();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.dtTanggal = new ISA.Controls.DateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lookUpRekening1 = new ISA.Showroom.Finance.Controls.LookUpRekening();
            this.SuspendLayout();
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSubmit.Image = ((System.Drawing.Image)(resources.GetObject("cmdSubmit.Image")));
            this.cmdSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSubmit.Location = new System.Drawing.Point(97, 227);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(100, 40);
            this.cmdSubmit.TabIndex = 7;
            this.cmdSubmit.Text = "YES";
            this.cmdSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            this.cmdSubmit.Validating += new System.ComponentModel.CancelEventHandler(this.dlgProsesGiroStatus_Validating);
            // 
            // cmdCancel
            // 
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(333, 227);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // dtTanggal
            // 
            this.dtTanggal.DateValue = null;
            this.dtTanggal.Location = new System.Drawing.Point(198, 96);
            this.dtTanggal.MaxLength = 10;
            this.dtTanggal.Name = "dtTanggal";
            this.dtTanggal.Size = new System.Drawing.Size(114, 20);
            this.dtTanggal.TabIndex = 2;
            this.dtTanggal.TextChanged += new System.EventHandler(this.dtTanggal_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tanggal";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(71, 50);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(245, 23);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "label4";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lookUpRekening1
            // 
            this.lookUpRekening1.BankRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpRekening1.Cursor = System.Windows.Forms.Cursors.Default;
            this.lookUpRekening1.Location = new System.Drawing.Point(69, 119);
            this.lookUpRekening1.MataUangIDRekening = "";
            this.lookUpRekening1.MinimumSize = new System.Drawing.Size(280, 27);
            this.lookUpRekening1.Name = "lookUpRekening1";
            this.lookUpRekening1.RekeningRowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookUpRekening1.Size = new System.Drawing.Size(406, 75);
            this.lookUpRekening1.TabIndex = 13;
            // 
            // dlgProsesGiroStatus
            // 
            this.AcceptButton = this.cmdSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(566, 306);
            this.ControlBox = false;
            this.Controls.Add(this.lookUpRekening1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtTanggal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "dlgProsesGiroStatus";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status Giro";
            this.Title = "Status Giro";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.dlgProsesGiroStatus_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.dlgProsesGiroStatus_Validating);
            this.Validated += new System.EventHandler(this.dlgProsesGiroStatus_Validated);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdSubmit, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtTanggal, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.lookUpRekening1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSubmit;
        private ISA.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.Label label1;
        public ISA.Controls.DateTextBox dtTanggal;
        private System.Windows.Forms.Label lblStatus;
        public ISA.Showroom.Finance.Controls.LookUpRekening lookUpRekening1;
    }
}
