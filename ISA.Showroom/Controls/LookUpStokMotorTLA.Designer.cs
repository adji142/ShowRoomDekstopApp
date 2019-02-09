namespace ISA.Showroom.Controls
{
    partial class LookUpStokMotorTLA
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
            this.txtNoPol = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNoPol
            // 
            this.txtNoPol.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNoPol.Location = new System.Drawing.Point(9, 2);
            this.txtNoPol.Name = "txtNoPol";
            this.txtNoPol.Size = new System.Drawing.Size(149, 20);
            this.txtNoPol.TabIndex = 16;
            this.txtNoPol.Validating += new System.ComponentModel.CancelEventHandler(this.txtNamaMotor_Validating);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdSearch.Image = global::ISA.Showroom.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(162, 0);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(30, 23);
            this.cmdSearch.TabIndex = 17;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // LookUpStokMotorTLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNoPol);
            this.Name = "LookUpStokMotorTLA";
            this.Size = new System.Drawing.Size(202, 25);
            this.Load += new System.EventHandler(this.LookUpMotor_Load);
            this.Leave += new System.EventHandler(this.LookUpStokMotorTLA_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        public System.Windows.Forms.TextBox txtNoPol;
    }
}
