namespace ISA.Showroom.Controls
{
    partial class LookUpVendor
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
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtNamaVendor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(161, 0);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(30, 23);
            this.cmdSearch.TabIndex = 15;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtNamaVendor
            // 
            this.txtNamaVendor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNamaVendor.Location = new System.Drawing.Point(9, 2);
            this.txtNamaVendor.Name = "txtNamaVendor";
            this.txtNamaVendor.Size = new System.Drawing.Size(149, 20);
            this.txtNamaVendor.TabIndex = 14;
            this.txtNamaVendor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNamaVendor_Validating);
            // 
            // LookUpVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNamaVendor);
            this.Name = "LookUpVendor";
            this.Size = new System.Drawing.Size(202, 25);
            this.Load += new System.EventHandler(this.LookUpVendor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        public System.Windows.Forms.TextBox txtNamaVendor;

    }
}
