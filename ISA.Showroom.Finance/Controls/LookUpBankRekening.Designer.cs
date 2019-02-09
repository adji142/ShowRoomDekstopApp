namespace ISA.Showroom.Finance.Controls
{
    partial class LookUpBankRekening
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdLookup = new System.Windows.Forms.Button();
            this.lblLookupNamaBank = new System.Windows.Forms.Label();
            this.txtLookup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoRekening = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNamaRekening = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdLookup
            // 
            this.cmdLookup.BackgroundImage = global::ISA.Showroom.Finance.Properties.Resources.Search16;
            this.cmdLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdLookup.Location = new System.Drawing.Point(285, 2);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(26, 25);
            this.cmdLookup.TabIndex = 1;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // lblLookupNamaBank
            // 
            this.lblLookupNamaBank.AutoSize = true;
            this.lblLookupNamaBank.Location = new System.Drawing.Point(95, 31);
            this.lblLookupNamaBank.Name = "lblLookupNamaBank";
            this.lblLookupNamaBank.Size = new System.Drawing.Size(0, 13);
            this.lblLookupNamaBank.TabIndex = 15;
            // 
            // txtLookup
            // 
            this.txtLookup.Location = new System.Drawing.Point(98, 5);
            this.txtLookup.MaxLength = 12;
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.Size = new System.Drawing.Size(181, 20);
            this.txtLookup.TabIndex = 0;
            this.txtLookup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLookup_KeyUp);
            this.txtLookup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookup_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Bank ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nama Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "No.Rekening";
            // 
            // lblNoRekening
            // 
            this.lblNoRekening.AutoSize = true;
            this.lblNoRekening.Location = new System.Drawing.Point(95, 56);
            this.lblNoRekening.Name = "lblNoRekening";
            this.lblNoRekening.Size = new System.Drawing.Size(0, 13);
            this.lblNoRekening.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nama Rekening";
            // 
            // lblNamaRekening
            // 
            this.lblNamaRekening.AutoSize = true;
            this.lblNamaRekening.Location = new System.Drawing.Point(95, 78);
            this.lblNamaRekening.Name = "lblNamaRekening";
            this.lblNamaRekening.Size = new System.Drawing.Size(0, 13);
            this.lblNamaRekening.TabIndex = 22;
            // 
            // LookUpBankRekening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNamaRekening);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNoRekening);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.lblLookupNamaBank);
            this.Controls.Add(this.txtLookup);
            this.Name = "LookUpBankRekening";
            this.Size = new System.Drawing.Size(337, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtLookup;
        public System.Windows.Forms.Label lblNoRekening;
        public System.Windows.Forms.Label lblNamaRekening;
        public System.Windows.Forms.Label lblLookupNamaBank;
    }
}
