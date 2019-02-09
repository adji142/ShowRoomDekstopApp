namespace ISA.Showroom.Controls
{
    partial class LookUpRekening
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
            this.txtNamaRekening = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.lblNoRek = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNamaRekening
            // 
            this.txtNamaRekening.Location = new System.Drawing.Point(9, 2);
            this.txtNamaRekening.Name = "txtNamaRekening";
            this.txtNamaRekening.Size = new System.Drawing.Size(149, 20);
            this.txtNamaRekening.TabIndex = 0;
            this.txtNamaRekening.Validating += new System.ComponentModel.CancelEventHandler(this.txtNamaRekening_Validating);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(161, 0);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(30, 23);
            this.cmdSearch.TabIndex = 16;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // lblNoRek
            // 
            this.lblNoRek.AutoSize = true;
            this.lblNoRek.Location = new System.Drawing.Point(9, 20);
            this.lblNoRek.Name = "lblNoRek";
            this.lblNoRek.Size = new System.Drawing.Size(0, 13);
            this.lblNoRek.TabIndex = 17;
            // 
            // LookUpRekening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoRek);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNamaRekening);
            this.Name = "LookUpRekening";
            this.Size = new System.Drawing.Size(202, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNamaRekening;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Label lblNoRek;
    }
}
