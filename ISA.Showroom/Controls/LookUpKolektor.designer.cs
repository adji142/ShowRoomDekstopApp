namespace ISA.Showroom.Controls
{
    partial class LookUpKolektor
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
            this.txtNamaKolektor = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNamaKolektor
            // 
            this.txtNamaKolektor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNamaKolektor.Location = new System.Drawing.Point(9, 2);
            this.txtNamaKolektor.Name = "txtNamaKolektor";
            this.txtNamaKolektor.Size = new System.Drawing.Size(149, 20);
            this.txtNamaKolektor.TabIndex = 12;
            this.txtNamaKolektor.Validating += new System.ComponentModel.CancelEventHandler(this.txtNamaKolektor_Validating);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(161, 0);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(30, 23);
            this.cmdSearch.TabIndex = 13;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // LookUpKolektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNamaKolektor);
            this.Name = "LookUpKolektor";
            this.Size = new System.Drawing.Size(202, 25);
            this.Load += new System.EventHandler(this.LookUpKolektorman_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtNamaKolektor;
        private System.Windows.Forms.Button cmdSearch;
    }
}
